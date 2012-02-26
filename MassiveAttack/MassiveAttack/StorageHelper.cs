using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;

namespace MassiveAttack
{
    public class StorageHelper
    {

        IsolatedStorageSettings IsoStore = IsolatedStorageSettings.ApplicationSettings;
        public App currentApp = (App)App.Current;
        string tempString;

        public StorageHelper()
        {
        }

        public int FindIndexByName(string buttonName)
        {
            int index = 0;
            for (int i = 0; i < currentApp.globalLib.masterArray.Count; i++)
            {
                if (currentApp.globalLib.masterArray[i].buttonText == buttonName)
                { index = i; }
            }
            return index;

        }

        public void RetrieveNameArray() 
        {
           
            using (IsolatedStorageFile buttonNameFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (buttonNameFile.FileExists("UserButtons.txt"))
                {
                    int i = 0;
                     using (StreamReader sw = new StreamReader(buttonNameFile.OpenFile("UserButtons.txt",FileMode.Open, FileAccess.Read)))
                     {
                         while ((tempString = sw.ReadLine()) != null)
                         {
                             this.AddNameArray(tempString);
                             i++;
                         }
                     }

                }
                
            }
        }

        public void AddNameArray(string newName)
        {
            if (currentApp.buttonNames[0] == "emptyAdam")
            {
                currentApp.buttonNames[0] = newName;
            }
            else
            {
                string[] ar2 = new string[currentApp.buttonNames.Length + 1];
                currentApp.buttonNames.CopyTo(ar2, 0);
                ar2.SetValue(newName, currentApp.buttonNames.Length);
                currentApp.buttonNames = ar2;
            }
        }

        public void DeleteNameArray()
        {
            //Needs to be called after I have removed the button from the lib
            int ind = 0;
            bool singleFlag = false;
            string[] ar2 = new string[currentApp.buttonNames.Length -1];
            if (currentApp.buttonNames.Length == 1)
            {
                currentApp.buttonNames[0] = "emptyAdam";
                singleFlag = true;
            }

            foreach (ButtonEntity button in currentApp.globalLib.masterArray)
            {
                if (button.isDefault == false)
                {                    
                    ar2[ind] = button.buttonText;
                    ind++;
                }
            }
            if (singleFlag==false)
                currentApp.buttonNames = ar2;
        }

        public void SaveNameArray() 
        {

            using (IsolatedStorageFile buttonNameFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (buttonNameFile.FileExists("UserButtons.txt"))
                {
                    buttonNameFile.DeleteFile("UserButtons.txt");
                }

                using (StreamWriter sw =
                            new StreamWriter(buttonNameFile.OpenFile("UserButtons.txt",
                                FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    for (int i = 0; i < currentApp.buttonNames.Length; i++)
                    {
                        sw.WriteLine(currentApp.buttonNames[i]);
                    }
                }
            }
        }

        public void AddButtonStorage(ButtonEntity newButton)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string header = newButton.buttonText + "_";
            settings.Add(header+"buttonText", newButton.buttonText);
            settings.Add(header + "buttonAudioUri", newButton.buttonAudioUri);
            settings.Add(header + "isDefault", newButton.isDefault);
            settings.Add(header + "colorString", newButton.colorString);
            settings.Add(header + "buttonColor", newButton.buttonColor.ToString());
            settings.Save();
        }

        public void DeleteButtonStorage(string killedButtonName)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string header = killedButtonName + "_";
            settings.Remove(header + "buttonText");
            settings.Remove(header + "buttonAudioUri");
            settings.Remove(header + "isDefault");
            settings.Remove(header + "colorString");
            settings.Remove(header + "buttonColor");
            settings.Save();
        }

        public void LoadAllButtons()
        {
            
            
            this.RetrieveNameArray();
            ButtonEntity[] tempButtonLib = new ButtonEntity[currentApp.buttonNames.Length];
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (currentApp.buttonNames[0] != "emptyAdam")
            {
                int i = 0;
                foreach (string loadName in currentApp.buttonNames)
                {
                    ButtonEntity tempButton = new ButtonEntity("Standard");
                    string header = loadName + "_";
                    tempButton.buttonText = IsolatedStorageSettings.ApplicationSettings[header + "buttonText"] as string;
                    tempButton.buttonAudioUri = IsolatedStorageSettings.ApplicationSettings[header + "buttonAudioUri"] as string;
                    tempButton.isDefault = Convert.ToBoolean(IsolatedStorageSettings.ApplicationSettings[header + "isDefault"] as string);
                    tempButton.colorString = IsolatedStorageSettings.ApplicationSettings[header + "colorString"] as string;
                    tempButtonLib[i] = tempButton;
                    i++;
                }

                foreach (ButtonEntity toAdd in tempButtonLib)
                {
                     currentApp.globalLib.masterArray.Add(toAdd); 
                }
            }

        }

    }
}
