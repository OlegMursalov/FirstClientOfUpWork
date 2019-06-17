set httpRequest=createObject("Msxml2.ServerXMLHTTP.6.0")
httpRequest.open "POST", "https://xvex.de/isms/test/asset_management/add_assets.php", False
httpRequest.setRequestHeader "Content-Type", "application/json"
httpRequest.setRequestHeader "Id", "{b65014cf-92cb-478b-a48e-c048a29fb12d}"
httpRequest.send "Id={b65014cf-92cb-478b-a48e-c048a29fb12d}"
MsgBox httpRequest.Status