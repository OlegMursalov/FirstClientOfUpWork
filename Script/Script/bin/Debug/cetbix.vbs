' ' --------------------------------------------------------------------
' Compliance tool
' Technology used - VBS, CloudFunctions, BigQuery and DataStudio with
' SQL Queries

' Cetbix ISMS System Analysis, January 2017 - January 2019

' This script will collect specific data from your asset in order to
' check if it is compliant to our policy
' --------------------------------------------------------------------
' 

Dim computerName, computerDate, httpRequest, strComputerRole
Const HKEY_LOCAL_MACHINE = &H80000002
strComputer = "."
Set objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")
Set objSWbemLocator = CreateObject("WbemScripting.SWbemLocator") 
Set objWMIService= objSWbemLocator.ConnectServer(".", "root\cimv2")

' Variable where all the data will be stored - and then sent to the server or to a specific file
outputDataBigQuery = ""

' Define which separator key will be used to concat data with the same key
keySeparator = "||"
sizeKeySeparator = len(keySeparator)

' The token will be stored online and will be used only once
complianceToken = "long number"

' Allow to collect the asset to be collected offline
ONLINE_MODE = True
' In cas of using the offline mode, specify a NAS server in order to retreive data
' Otherwise, data will be stored on the asset 
NAT_SERVER = ""
If Not ONLINE_MODE Then
Dim objFSO, outputFile
Set objFSO = CreateObject("Scripting.FileSystemObject")
End If

' Defining URL 1st: retreive registry keys to check and 2nd: where to upload the dataReturned
retrieveComplianceDataURl = "https://+++++++++++++++.net/getcompliancetool"
'The script will retrieve registry key to check from Google and will send them to our database
'registry keys are used in order to collect the RDP and the anti virus configuraiton
'It retrieve data from a data storage. It help us to manage easily antivirus version. You don't have to redeploy the tool every time. For example, with this functionality we were able to check every asset that was potentially vulnerable to the latest Windows RDP vulnerability without having to redeploy on all assets
importComplianceDataURl = "https://+++++++++++++.net/importComplianceData"
' This value will be usefull in order to retry sending the post request. The server might be long to answer or might be occupied. This will allow to retry a max of 10 times to send/retreive data
nbUnsuccessfullSendReqest = 10

Set GlobalDict = CreateObject("Scripting.Dictionary")

retrieveComplianceData()

Function retrieveComplianceData()
    basicAssetInfo()
    getSystemUptime()
    wksType()
    getComputerIP()
    osInformation()
    getJavaVersion()
    ' getAdobeVersion()
    checkSMBv1()
    getLAPSInstalled()
    ' checkRegistry()
    checkAntivirusParameters()
    patchLevel()
    passwordPolicy()
    getSharedFolders()
    ' checkFiles()
    sendData()
End Function

Function basicAssetInfo()
    computerName = getComputerName()
    computerDomain = CreateObject("WScript.Network").UserDomain
    appendToGlobalDict "Domain", computerDomain
    appendToGlobalDict "CetbixVulnerabilityScannerVersion", "2.7 Data Security"
    computerDate = getDate()
End Function

Function appendToGlobalDict(key, value)
    GlobalDict.Add key, value
End Function

Function appendOutputFile(key, value)
    If (outputDataBigQuery <> "") Then
        outputDataBigQuery = outputDataBigQuery&","
    End If
    outputDataBigQuery = outputDataBigQuery&""""&key&""":"""&Replace(value & "", """", "\""")&""""
End Function

Function getComputerName()
    Dim WshNetwork
    Set WshNetwork = CreateObject("WScript.Network")
    getComputerName = WshNetwork.ComputerName
    appendToGlobalDict "Hostname", WshNetwork.ComputerName
End Function

' Get all the informaiton from regitries. The configuration file will be used in order to get specific data
' readFromRegistry will take the key of the registry and will return the value, if it exists. Otherwise an empty value will be returned
Function readFromRegistry(strRegistryKey)
    Dim WSHShell, value
    On Error Resume Next
    Set WSHShell = CreateObject("WScript.Shell")
    value = WSHShell.RegRead(strRegistryKey)
    If Err.Number <> 0 Then
        readFromRegistry = Empty
    Else
        readFromRegistry = value
    End If
End Function

' checkRegistry will get the configuration file, offline or online, in oder to know with registry will be needed.
'Function checkRegistry()
'    Dim extractedRegistry
'    Set extractedRegistry = CreateObject("Scripting.Dictionary")
'    If ONLINE_MODE Then
'        configValues = Split(retreiveData("config"), vbNewLine)
'        For i = 0 To UBound(configValues)
'            splitedDataRegistry = Split(configValues(i), ",")
'            extractedValueRegistry = readFromRegistry(splitedDataRegistry(1))
'            If extractedRegistry.Exists(splitedDataRegistry(0)) Then
'                If extractedValueRegistry <> Empty Or extractedValueRegistry <> null Or extractedValueRegistry <> "" Then
'                    extractedRegistry(splitedDataRegistry(0)) = extractedValueRegistry
'                End If
'            Else
'                extractedRegistry.Add splitedDataRegistry(0), extractedValueRegistry
'            End If
'        Next
'    Else
'        Set objFile = objFSO.OpenTextFile("config.txt", 1)
'        Do Until objFile.AtEndOfStream
'            line = objFile.Readline
'            splitedDataRegistry = Split(line, ",")
'            extractedValueRegistry = readFromRegistry(splitedDataRegistry(1))
'            If extractedRegistry.Exists(splitedDataRegistry(0)) Then
'                If extractedValueRegistry <> Empty Then
'                    extractedRegistry(splitedDataRegistry(0)) = extractedValueRegistry
'                End If
'            Else
'                extractedRegistry.Add splitedDataRegistry(0), extractedValueRegistry
'            End If
'        Loop
'        objFile.Close
'    End If
'    For i = 0 To extractedRegistry.Count - 1
'        appendToGlobalDict extractedRegistry.Keys()(i), extractedRegistry.Items()(i)
'    Next
'End Function

Function checkAntivirusParameters()
    If FileExists("C:\Program Files (x86)\F-Secure\Common\POLUTIL.EXE") Then
        appendToGlobalDict "Antivirus protection", Split(console("""C:\Program Files (x86)\F-Secure\Common\POLUTIL.EXE"" g 1.3.6.1.4.1.2213.12.2.140"), vbLf)(0)
        appendToGlobalDict "Antivirus running", Split(console("""C:\Program Files (x86)\F-Secure\common\POLUTIL.EXE"" g 1.3.6.1.4.1.2213.12.2.111.10"), vbLf)(0)
    End If
End Function

'Function checkFiles()
'    If ONLINE_MODE Then
'        configValues = Split(retreiveData("file"), vbNewLine)
'        Set objFSO = CreateObject("Scripting.FileSystemObject")
'        For i = 0 To UBound(configValues)
'            splitedDataFilePath = Split(configValues(i), ",")
'            If InStr(splitedDataFilePath(1), "%") Then
'                sizeFilepath = Split(splitedDataFilePath(1), "%")
'                filePathEnv = CreateObject("WScript.Shell").ExpandEnvironmentStrings("%" & sizeFilepath(1) & "%")
'                splitedDataFilePath(1) = filePathEnv&sizeFilepath(2)
'            End If
'            If InStr(splitedDataFilePath(1), "*") Then
'                sizeFilepath = Split(splitedDataFilePath(1), "\")
'                folderPathWildcard = sizeFilepath(0)
'                fileNameWildcard = Replace(sizeFilepath(UBound(sizeFilepath)), "*", "")
'                For j = 1 To UBound(sizeFilepath) - 1
'                    folderPathWildcard = folderPathWildcard & "\" & sizeFilepath(j)
'                Next
'                Set objFolder = objFSO.GetFolder(folderPathWildcard)
'                Set colFiles = objFolder.Files
'                For Each objFile In colFiles
'                    If InStr(objFile.Name, fileNameWildcard) Then
'                        getFileInformation(folderPathWildcard&"\"&objFile.Name)
'                    End If
'                Next
'            ElseIf FileExists(splitedDataFilePath(1)) Then
'                getFileInformation(splitedDataFilePath(1))
'            Else appendToGlobalDict "File: " & splitedDataFilePath(0), "Does not exist"
'            End If
'        Next
'    End If
'End Function

Function getFileInformation(filePath)
    Set objFile = objFSO.GetFile(filePath)
    appendToGlobalDict "MD5: "&objFile.Name, Split(console("certUtil -hashfile """ & filePath&""" MD5"), vbLf)(1)
    appendToGlobalDict "File: "&objFile.Name, "v."&objFSO.GetFileVersion(filePath)&" - size: "&objFile.Size&" o - last modified "&objFile.DateLastModified
End Function

Function checkSMBv1()
    SMBv1_Registry = readFromRegistry("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters\SMB1")
    SMBv1_ActivationCheck = "Activated"
    If SMBv1_Registry = 1 Or SMBv1_Registry = Empty Then
        SMBv1_PolicyActivated_boolean = 1
        SMBv1_Policy_mrxsmb10 = readFromRegistry("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\mrxsmb10\Start")
        SMBv1_PolicyActivated = readFromRegistry("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanWorkstation\DependOnService")
        For Each strValue In SMBv1_PolicyActivated
            If InStr(strValue, "mrxsmb10") And SMBv1_PolicyActivated_boolean = 1 Then
                SMBv1_PolicyActivated_boolean = 0
            End If
        Next
        If (SMBv1_Policy_mrxsmb10 = 4 Or SMBv1_Policy_mrxsmb10 = Empty) And SMBv1_PolicyActivated_boolean = 1 Then
            SMBv1_ActivationCheck = "Deactivated"
        End If
    Else SMBv1_ActivationCheck = "Deactivated"
    End If
    appendToGlobalDict "SMBv1", SMBv1_ActivationCheck
End Function

Function getLAPSInstalled()
    If FileExists("C:\Program Files\LAPS\CSE\AdmPwd.dll") Or FileExists("C:\Program Files (x86)\LAPS\CSE\AdmPwd.dll") Or FileExists("C:\Program Files\AdmPwd\CSE\AdmPwd.dll") Or FileExists("C:\Program Files (x86)\AdmPwd\CSE\AdmPwd.dll") Then
        appendToGlobalDict "LAPS", "Installed"
    Else
        appendToGlobalDict "LAPS", "not Installed"
    End If
End Function

Function FileExists(FilePath)
    Set fso = CreateObject("Scripting.FileSystemObject")
        If fso.FileExists(FilePath) Then
        FileExists = CBool(1)
    Else
        FileExists = CBool(0)
    End If
End Function

Function getComputerIP()
    On Error Resume Next
    Set regIP = GetObject("winmgmts://./root/default:StdRegProv")
    strKeyPathCards = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkCards"
    strKeyPathIPInterface = "HKLM\SYSTEM\CurrentControlSet\Services\TCPIP\Parameters\Interfaces\"
    regIP.EnumKey HKEY_LOCAL_MACHINE, strKeyPathCards, arrSubKeys
    IPList = ""
    If Not IsNull(arrSubKeys) Then
        For Each subkey In arrSubKeys
            regValue = readFromRegistry("HKLM\" & strKeyPathCards&ServiceName&"\"&subkey&"\ServiceName")
            If IPList = "" Then
                IPList = readFromRegistry(strKeyPathIPInterface&regValue&"\DhcpIPAddress")
            Else
                IPList = IPList&keySeparator&readFromRegistry(strKeyPathIPInterface&regValue&"\DhcpIPAddress")
            End If
        Next
    End If
    appendToGlobalDict "IP", IPList
End Function

Function getDate()
    On Error Resume Next
    Set colItems = objWMIService.ExecQuery("Select * from Win32_UTCTime")

    For Each objItem In colItems
        getDate = objItem.Day & "/" & objItem.Month & "/" & objItem.Year
    Next
End Function

Function getInstalledSoftware()
    On Error Resume Next
    Set colSoftware = objWMIService.ExecQuery ("Select * from Win32_Product")
    tempSoftware = ""
    For Each objSoftware In colSoftware
        If objSoftware.Name <> "" Then
            tempSoftware = objSoftware.Name
        Else
            tempSoftware = tempSoftware&keySeparator&objSoftware.Name
        End If
    Next
    appendToGlobalDict "Software", tempSoftware
    objTextFile.Close
End Function

Function getJavaVersion()
    javaMainVersion = readFromRegistry("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment\CurrentVersion")
    javaDetailledVersion = readFromRegistry("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment\" & javaMainVersion&"\JavaHome")
    javaOutput = ""
    If javaDetailledVersion <> Empty Then
        javaDetailledVersion = Split(javaDetailledVersion, "\")
        appendToGlobalDict "Java", javaDetailledVersion(UBound(javaDetailledVersion))
    Else
        javaMainVersion = readFromRegistry("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\JavaSoft\Java Runtime Environment\CurrentVersion")
        javaDetailledVersion = readFromRegistry("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\JavaSoft\Java Runtime Environment\BrowserJavaVersion")
        If javaMainVersion <> Empty And javaDetailledVersion <> Empty Then
            appendToGlobalDict "Java", javaMainVersion&"_"&split(javaDetailledVersion, ".")(1)
        Else
            appendToGlobalDict "Java", "Not installed"
        End If
    End If
End Function

Function getAdobeVersion()
    On Error Resume Next
    Set Collection = objWMIService.ExecQuery("select Name, Version from " & "Win32_Product where Vendor like '%adobe%'")
    For Each Item In Collection
        appendToGlobalDict Item.Name, Item.Version
    Next
End Function

Function osInformation()
    On Error Resume Next
    Set dtmConvertedDate = CreateObject("WbemScripting.SWbemDateTime")

    Set oss = objWMIService.ExecQuery ("Select * from Win32_OperatingSystem")

    For Each os In oss
        If os.ServicePackMajorVersion > 0 Then
            appendToGlobalDict "OSCaption", os.Caption&" SP "&os.ServicePackMajorVersion
        Else
            appendToGlobalDict "OSCaption", os.Caption
        End If
        appendToGlobalDict "OSVersion", os.Version
        appendToGlobalDict "OSOrganization", os.Organization
    Next
End Function

Function getSystemUptime()
    Set colItems = objWMIService.ExecQuery( "Select * from Win32_OperatingSystem", , 48 )
    For Each objItem In colItems
        numUptime = DateDiff("n", ParseDat(objItem.LastBootUpTime), ParseDat(objItem.LocalDateTime))
        numUptMins = numUptime Mod 60
        numUptHour = (numUptime \ 60) Mod 24
        numUptDays = (numUptime \ 60) \ 24
        If numUptDays > 1 Then
            appendToGlobalDict "System Uptime", numUptDays&" days"
        Else
            appendToGlobalDict "System Uptime", numUptDays&" day"
        End If
    Next
End Function

Function ParseDat(ByVal strDate)
    strYear = Left(strDate, 4)
    strMonth = Mid(strDate, 5, 2)
    strDay = Mid(strDate, 7, 2)
    strDat = strDay & "-" & strMonth & "-" & strYear
    strHour = Mid(strDate, 9, 2) - strTimeShift
    strMins = Mid(strDate, 11, 2)
    strTime = strHour & ":" & strMins
    ParseDat = strDat & " " & strTime
End Function

Function WMIDateStringToDate(dtmBootup)
    WMIDateStringToDate = CDate(Mid(dtmBootup, 5, 2) & "/" & Mid(dtmBootup, 7, 2) & "/" & Left(dtmBootup, 4) & " " & Mid(dtmBootup, 9, 2) & ":" & Mid(dtmBootup, 11, 2) & ":" & Mid(dtmBootup, 13, 2))
End Function

Function patchLevel()
    On Error Resume Next
    Set colQuickFixes = objWMIService.ExecQuery ("Select * from Win32_QuickFixEngineering")
    Dim patchLevelKBList(20)
    For Each objQuickFix In colQuickFixes
        kbValue = CLng(Mid(objQuickFix.HotFixID, 3))
        If objQuickFix.Description = "Update" Or objQuickFix.Description = "Security Update" Then
            For i = 0 To UBound(patchLevelKBList)
                If kbValue > patchLevelKBList(i) Then
                    tmp_i = 0
                    tmp_size = UBound(patchLevelKBList)
                    ' Avec cette fonction on rÃ©cup-re uniquement les valeurs les plus elevees.
                    For j = i + 1 To tmp_size
                        patchLevelKBList(tmp_size - tmp_i) = patchLevelKBList(tmp_size - tmp_i - 1)
                        tmp_i = tmp_i + 1
                    Next
                    patchLevelKBList(i) = kbValue
                    Exit For
                End If
            Next
        End If
    Next
    appendToGlobalDict "MicrosoftKB", Join(patchLevelKBList, ",")
End Function

Function Int8ToSec(ByVal objInt8)
    ' Function to convert Integer8 attributes from
    ' 64-bit numbers to seconds.
    Dim lngHigh, lngLow
    lngHigh = objInt8.HighPart
    ' Account for error in IADsLargeInteger property methods.
    lngLow = objInt8.LowPart
    If lngLow < 0 Then
        lngHigh = lngHigh + 1
    End If
    Int8ToSec = -(lngHigh * (2 ^ 32) + lngLow) / (10000000)
End Function

Function domainInfo()
    On Error Resume Next
    Set colItems = objWMIService.ExecQuery("Select * from Win32_NTDomain")
    tmpDomainName = ""
    tmpDomainControllerName = ""
    tmpDnsForestName = ""
    For Each objItem In colItems
        If Len(objItem.DomainName) > 0 Then
            tmpDomainName = concatSameKeyName(tmpDomainName, objItem.DomainName)
            tmpDomainControllerName = concatSameKeyName(tmpDomainControllerName, objItem.DomainControllerName)
            tmpDnsForestName = concatSameKeyName(tmpDnsForestName, objItem.DnsForestName)
        End If
    Next
    appendToGlobalDict "DomainName", tmpDomainName
    appendToGlobalDict "DomainControllerName", tmpDomainControllerName
    appendToGlobalDict "ForestName", tmpDnsForestName
End Function

' Prendre en compte la Fine grained policy A VERIFIER
' RÃ©cupÃ©ration des motde passe'
Function passwordPolicy()
    extractedPasswordPolicy = Split(console("net accounts"), vbLf) ' rÃ©cupÃ©ration des donnÃ©es de la commande net account en intÃ©rogeant le domaine. La recherche est faire en localle cas Ã©chÃ©ant'
    indexTemp = 0 'utiliser pour dÃ©terminer l'index courant dans la console (uniquement si le split fonctionne)
    For i = 0 To UBound(extractedPasswordPolicy)
        splittedData = Split(extractedPasswordPolicy(i), ":")
        strPasswordPolicy = ""
        If UBound(splittedData) = 1 Then
            If indexTemp <> 0 Then
                Select Case indexTemp
                    Case 1
                        strPasswordPolicy = "MinimumPasswordAge"
                    Case 2
                        strPasswordPolicy = "MaximumPasswordAge"
                    Case 3
                        strPasswordPolicy = "MinimumPasswordLength"
                    Case 4
                        strPasswordPolicy = "PasswordHistory"
                    Case 5
                        strPasswordPolicy = "LockoutThreshold"
                    Case 6
                        strPasswordPolicy = "AccountLockoutDuration"
                    Case 7
                        strPasswordPolicy = "LockoutObservationWindows"
                    Case 8
                        strPasswordPolicy = "ComputerRole"
                End Select
                appendToGlobalDict strPasswordPolicy, CStr(Trim(splittedData(1)))
            End If
            indexTemp = indexTemp + 1
        End If
    Next
End Function

Function wksType()
    Set colComputers = objWMIService.ExecQuery("Select DomainRole from Win32_ComputerSystem")
    For Each objComputer In colComputers
        Select Case objComputer.DomainRole
            Case 0
                strComputerRole = "Standalone Workstation"
            Case 1
                strComputerRole = "Member Workstation"
            Case 2
                strComputerRole = "Standalone Server"
            Case 3
                strComputerRole = "Member Server"
            Case 4
                strComputerRole = "Backup Domain Controller"
            Case 5
                strComputerRole = "Primary Domain Controller"
        End Select
        appendToGlobalDict "Type", strComputerRole
    Next
End Function

Function openPorts()
    ' outputOpenPorts=split(consolePorts("cmd /c ""netStat -ano | find ""ESTABLISHED"""""),vbLf)
    '     for i=0 to ubound(outputOpenPorts)
    '         if outputOpenPorts(i)<>"" Then
    '             appendToGlobalDict "Port-openPorts","toDefine"
    '         End if
    '     next
    Set objFirewall = CreateObject("HNetCfg.FwMgr")
    Set objPolicy = objFirewall.LocalPolicy.CurrentProfile

    Set colPorts = objPolicy.GloballyOpenPorts

    ' For Each objPort in colPorts
    '     wscript.echo "Port name: ", objPort.Name
    '     wscript.echo "Port number: ", objPort.Port
    '     wscript.echo "Port IP version: ", objPort.IPVersion
    '     wscript.echo "Port protocol: ",  objPort.Protocol
    '     wscript.echo "Port scope: ", objPort.Scope
    '     wscript.echo "Port remote addresses: ", objPort.RemoteAddresses
    '     wscript.echo "Port enabled: ", objPort.Enabled
    '     wscript.echo "Port built-in: ", objPort.Builtin
    ' Next
End Function

Function getSharedFolders()
    Set objSWbemLocator = CreateObject("WbemScripting.SWbemLocator") 
    Set objWMIService= objSWbemLocator.ConnectServer(".", "root\cimv2")
     
    Set colShares = objWMIService.ExecQuery("Select * from Win32_Share Where Type=0")
    listOfShares = ""
    If colShares.count > 0 Then
        For Each objShare In colShares
            listOfShares = "To: "&objShare.Name & " - "&objShare.Path & " - Type: " & objShare.Type
            listOfShares = concatSameKeyName(listOfShares, objShare.Name)
            appendToGlobalDict "Shares", listOfShares
        Next
    Else
        appendToGlobalDict "Shares", "No shared folder"
    End If
End Function

Function console(strCmd)
    Dim Wss, Cmd, Return, Output
    isCharDelimiter = 0 'Utiliser pour filtrer le carcatÃ¨re de sÃ©paration ----'
    isEndLocalUser = 0 'Une fois les utilisateurs locaux passÃ©s , les utilisateurs rÃ©seaux avec \ sont affichÃ©s'
  Set Wss = CreateObject("WScript.Shell")
  Set Cmd = Wss.Exec("cmd.exe")
  Cmd.StdIn.WriteLine strCmd & " 2>&1"
  Cmd.StdIn.Close
    While InStr(Cmd.StdOut.ReadLine, ">" & strCmd) = 0 : Wend
  Do : Output = Cmd.StdOut.ReadLine
        If Cmd.StdOut.AtEndOfStream Then Exit Do Else
        dataReturned = dataReturned & Output & vbLf
    Loop
    console = dataReturned
End Function

Function consolePorts(strCmd)
    Dim Wss, Cmd, Return, Output
  Set Wss = CreateObject("WScript.Shell")
  Set Cmd = Wss.Exec("cmd.exe")
  Cmd.StdIn.WriteLine strCmd & " 2>&1"
  Cmd.StdIn.Close
    While InStr(Cmd.StdOut.ReadLine, ">" & strCmd) = 0 : Wend
  Do : OutputPorts = Cmd.StdOut.ReadLine
        If Cmd.StdOut.AtEndOfStream Then Exit Do Else
        If InStr(OutputPorts, ":") > 0 And InStr(OutputPorts, " ") > 0 Then dataReturned = dataReturned & Left(Mid(OutputPorts, InStr(OutputPorts, ":") + 1), 6) & vbLf End If
    Loop
    consolePorts = dataReturned
End Function

Function concatSameKeyName(value, toAdd)
    If (Len(value) <> 0) Then
        concatSameKeyName = value&keySeparator&toAdd
    Else
        concatSameKeyName = toAdd
    End If
End Function

Function hasingCurrentFile()
    hasingCurrentFile = Split(console("certUtil -hashfile complianceTool-v2.3_GDPR.vbs SHA384"), vbLf)(1)
End Function

' Retreive data configuration. This will give us all the registry key to check with the name of the check and the path of the registry
Function retreiveData(param)
    set httpRequest=createObject("Msxml2.ServerXMLHTTP.6.0")
    httpRequest.open "POST", retrieveComplianceDataURl, False
    httpRequest.setRequestHeader "Content-Type", "application/json"
    httpRequest.setRequestHeader "Token", complianceToken
    httpRequest.setRequestHeader "Type", param
    httpRequest.setRequestHeader "Hash", hasingCurrentFile()
    httpRequest.setRequestHeader "Hostname", computerName
    httpRequest.send()
    If httpRequest.Status <> 200 And nbUnsuccessfullSendReqest > 0 Then
        WScript.Sleep(10000)
        nbUnsuccessfullSendReqest = nbUnsuccessfullSendReqest - 1
        retreiveData(param)
    Else retreiveData = httpRequest.ResponseText
    End If
End Function

' Sending all data collected on the Workstation and sending it to a specific url which will take care of importaing those data
Function sendData()
    'If ONLINE_MODE Then
    '    ' Get a temporary token. It will allow the script to upload the data
    '    ' temporaryToken = retreiveData("temporaryToken")
    '    temporaryToken = "YYY" ' For example!!!
    '    If temporaryToken <> Empty Then
    '        set httpRequest=createObject("Msxml2.ServerXMLHTTP.6.0")
    '        httpRequest.open "POST", importComplianceDataURl, False
    '        httpRequest.setRequestHeader "Content-Type", "application/json"
    '        httpRequest.setRequestHeader "Token", complianceToken
    '        ' httpRequest.setRequestHeader "temporaryToken",temporaryToken
    '        httpRequest.send "{" & Replace(Replace(outputDataBigQuery, "\", "\\"), vbCrLf, "") & "}"
    '        If httpRequest.Status <> 200 And nbUnsuccessfullSendReqest > 0 Then
    '            WScript.Sleep(10000)
    '            nbUnsuccessfullSendReqest = nbUnsuccessfullSendReqest - 1
    '            sendData()
    '        End If
    '    End If
    '    ' elseif NAT_SERVER<>EMPTY then
    '    ' wscript.echo "Internal mode. Data will be uploaded on the NAS server"
    'Else
    '    ' Defining output file that will be used to store the data Offline
    '    outputFileName = "complianceData-" & Replace(computerName, "/", "-") & "-" & Replace(computerDate, "/", "-") & ".json"
    '    Set outputFile = objFSO.CreateTextFile(outputFileName, True)
    '    outputFile.WriteLine "{" & CStr(Replace(outputDataBigQuery, "\", "\\")) & "}"
    'End If

    myGuid = CreateObject("Scriptlet.TypeLib").Guid
    myGuid = Left(myGuid, Len(myGuid) - 2) & "}"

    ' set cn = CreateObject("ADODB.Connection")

    ' cn.Open "DATASET" ' SETTING FROM SYSTEM (Control panel on Windows)
    ' cn.Open "Driver={MySQL ODBC 5.1 Unicode Driver};Server=xvex.de;Database=d02eb2b7;Uid=d02eb2b7;Pwd=kmG6PAbTxMWXKSkn;"

    ' cn.execute("INSERT INTO Domains(`Id`, `Domain`) VALUES ('" & myGuid & "','" & GlobalDict.Item("Domain") & "')")

    ' cn.execute("INSERT INTO Hostnames(`Id`, `Hostname`) VALUES ('" & myGuid & "','" & GlobalDict.Item("Hostname") & "')")

    ' cn.execute("INSERT INTO Scans(`Id`, `DateScan`) VALUES ('" & myGuid & "','" & Year(Date()) & "-" & Month(Date()) & "-" & Day(Date()) & "')")

    If GlobalDict.Exists("AccountLockoutDuration") Then
        AccountLockoutDuration = GlobalDict.Item("AccountLockoutDuration")
    End If
    If GlobalDict.Exists("CetbixVulnerabilityScannerVersion") Then
        CetbixVulnerabilityScannerVersion = GlobalDict.Item("CetbixVulnerabilityScannerVersion")
    End If
    If GlobalDict.Exists("ComputerRole") Then
        ComputerRole = GlobalDict.Item("ComputerRole")
    End If
    If GlobalDict.Exists("IP") Then
        IP = GlobalDict.Item("IP")
    End If
    If GlobalDict.Exists("Java") Then
        Java = GlobalDict.Item("Java")
    End If
    If GlobalDict.Exists("LAPS") Then
        LAPS = GlobalDict.Item("LAPS")
    End If
    If GlobalDict.Exists("LockoutObservationWindows") Then
        LockoutObservationWindows = GlobalDict.Item("LockoutObservationWindows")
    End If
    If GlobalDict.Exists("LockoutThreshold") Then
        LockoutThreshold = GlobalDict.Item("LockoutThreshold")
    End If
    If GlobalDict.Exists("MaximumPasswordAge") Then
        MaximumPasswordAge = GlobalDict.Item("MaximumPasswordAge")
    End If
    If GlobalDict.Exists("MicrosoftKB") Then
        MicrosoftKB = GlobalDict.Item("MicrosoftKB")
    End If
    If GlobalDict.Exists("MinimumPasswordAge") Then
        MinimumPasswordAge = GlobalDict.Item("MinimumPasswordAge")
    End If
    If GlobalDict.Exists("MinimumPasswordLength") Then
        MinimumPasswordLength = GlobalDict.Item("MinimumPasswordLength")
    End If
    If GlobalDict.Exists("OSCaption") Then
        OSCaption = GlobalDict.Item("OSCaption")
    End If
    If GlobalDict.Exists("OSOrganization") Then
        OSOrganization = GlobalDict.Item("OSOrganization")
    End If
    If GlobalDict.Exists("OSVersion") Then
        OSVersion = GlobalDict.Item("OSVersion")
    End If
    If GlobalDict.Exists("PasswordHistory") Then
        PasswordHistory = GlobalDict.Item("PasswordHistory")
    End If
    If GlobalDict.Exists("Shares") Then
        Shares = GlobalDict.Item("Shares")
    End If
    If GlobalDict.Exists("SMBv1") Then
        SMBv1 = GlobalDict.Item("SMBv1")
    End If
    If GlobalDict.Exists("SystemUptime") Then
        SystemUptime = GlobalDict.Item("SystemUptime")
    End If
    If GlobalDict.Exists("Type") Then
        TypeVar = GlobalDict.Item("Type")
    End If
    mainCommand = "INSERT INTO KeysValues(`Id`, `AccountLockoutDuration`, `CetbixVulnerabilityScannerVersion`, `ComputerRole`, `IP`, `Java`, `LAPS`, `LockoutObservationWindows`, "
    mainCommand = mainCommand & "`LockoutThreshold`, `MaximumPasswordAge`, `MicrosoftKB`, `MinimumPasswordAge`, `MinimumPasswordLength`, `OSCaption`, `OSOrganization`, `OSVersion`, `PasswordHistory`, "
    mainCommand = mainCommand & "`Shares`, `SMBv1`, `SystemUptime`, `Type`) VALUES ('" & myGuid & "','" & AccountLockoutDuration & "','" & CetbixVulnerabilityScannerVersion & "','"
    mainCommand = mainCommand & ComputerRole & "','" & IP & "','" & Java & "','" & LAPS & "','" & LockoutObservationWindows & "','" & LockoutThreshold & "','" & MaximumPasswordAge & "','"
    mainCommand = mainCommand & MicrosoftKB & "','" & MinimumPasswordAge & "','" & MinimumPasswordLength & "','" & OSCaption & "','" & OSOrganization & "','" & OSVersion & "','"
    mainCommand = mainCommand & PasswordHistory & "','" & Shares & "','" & SMBv1 & "','" & SystemUptime & "','" & TypeVar & "')"

    MsgBox mainCommand

    ' cn.execute(mainCommand)

    ' cn.close

End Function
