using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public class FrenchLanguageSetting : ILanguageSetting
    {
        public Dictionary<string, string> Contents
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "SendToCetbixRadio", "Envoyez les informations sur votre compte Cetbix" },
                    { "SaveToLocalTxtRadio", "Enregistrez les informations sur votre PC local (* .txt)" },
                    { "Run", "Courir" },
                    { "LabelCetbix", "URI Cetbix (add_assets.php)" },
                    { "SaveToLocalExcelRadio", "Enregistrez les informations sur votre PC local (* .xlsx)" },
                    { "Run_Click_Start", "S'il vous plaît, attendez..." },
                    { "TitleForTrial", "Votre essai est expiré. \nVous pouvez acheter et entrer une nouvelle clé. \nBesoin d’une connexion Internet vérifiant la nouvelle clé." },
                    { "CheckLicenseKey", "Vérifier la clé de licence" },
                    { "LinkToBuyApp", "Lien pour acheter une app" }
                };
            }
        }
        
        public Dictionary<string, string> Messages
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "DataSuccessfullySent", "Données envoyées avec succès à Cetbix." },
                    { "DataSuccessfullySaveToTxt", "Les données ont été sauvegardées avec succès en local (* .txt)." },
                    { "DataSuccessfullySaveToExcel", "Les données ont été sauvegardées avec succès en local (* .xlsx)." },
                    { "FillCetbixURI", "Remplir l'URI Cetbix (add_assets.php)" },
                    { "NotEnteredLicenseKey", "Vous n'avez pas entré de clé de licence." },
                    { "NotDone", "Pas fini." },
                    { "KeyDoesNotExist", "Cette clé n'existe pas." },
                    { "KeyIsActivation", "Pour cette clé, l'activation est terminée." },
                    { "TrialPeriodHasExpired", "Votre période d'essai a expiré." },
                    { "CheckYourInternetConnection", "Vérifiez votre connection internet." }
                };
            }
        }

        public Dictionary<string, string> Titles
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "SaveLogFile", "Enregistrer le fichier journal." }
                };
            }
        }

        public Dictionary<string, string> Strings
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Information", "Les informations" }
                };
            }
        }
    }
}