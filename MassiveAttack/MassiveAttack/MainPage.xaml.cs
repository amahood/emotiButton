using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.ComponentModel;

namespace MassiveAttack
{
    public partial class MainPage : PhoneApplicationPage
    {               
        public PressVM ActiveVM = new PressVM();
        public ButtonEntity curentButton = new ButtonEntity("Standard");
        public StorageHelper myStorage = new StorageHelper();
        public ColorConverter myConvert = new ColorConverter();

        //Initialize global variable app scope so I can use the global lib
        public App currentApp = (App)App.Current;
        
        //Initialization of soundeffect/playback stuff
        public static StreamResourceInfo streamInfo;
        public static SoundEffect se;
        public static SoundEffectInstance soundInstance;
        DynamicSoundEffectInstance playback = new DynamicSoundEffectInstance(16000, AudioChannels.Mono);
        byte[] globalBuffer;

        public MainPage()
        {
            InitializeComponent();
            myStorage.LoadAllButtons();

            //Ping PressVM to get the active button for main page
            curentButton = ActiveVM.activeButton;
            
            resetSound();

           //Set up data binding for drawer
            listBox1.ItemsSource = currentApp.globalLib.masterArray;
            listBox1.DataContext = currentApp.globalLib.masterArray;

            bigButton1.DataContext = this.curentButton;

           this.bigButton1.buttonFace.MouseLeftButtonDown += new MouseButtonEventHandler(mouse_playButton);
           this.bigButton1.buttonText.MouseLeftButtonDown += new MouseButtonEventHandler(mouse_playButton);
           ActiveVM.Active += new PressVM.NewActiveHandler(ActiveVM_NewActiveButton);

        }

        //Method/Event handler that responds to a new button being made active - Sets up all the necessary things
        void ActiveVM_NewActiveButton(object sender, EventArgs e)
        {
            SolidColorBrush tempColor = new SolidColorBrush();
            curentButton = ActiveVM.activeButton;
            bigButton1.buttonText.Text = this.curentButton.buttonText;
            tempColor =  (SolidColorBrush)myConvert.Convert(this.curentButton.colorString, null, null, null);
            bigButton1.buttonFace.Fill = tempColor; 
            resetSound();
            Pivot.SelectedItem = Button;
        }
        
        //Method/event handler for pressing the play button
        private void mouse_playButton(object sender, MouseButtonEventArgs e)
        {
            if (curentButton.isDefault == true)
            {
                soundInstance.Play();
            }

            else { playback.SubmitBuffer(globalBuffer); playback.Play(); }
        }

        //Method to create all the necessary sound effect classes/logic once we have a new Uri
        //Reads file from isolated storage if it's a custom user button (Might not want to do this here but in loading)
        private void resetSound()
        {
            if (curentButton.isDefault == true)
            {
                string UriString = @"Sounds/" + curentButton.buttonAudioUri;
                Uri soundUri = new Uri(UriString, UriKind.Relative);

                streamInfo = Application.GetResourceStream(soundUri);
                se = SoundEffect.FromStream(streamInfo.Stream);
                soundInstance = se.CreateInstance();
            }

            else
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = storage.OpenFile(curentButton.buttonText, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        //playback.SubmitBuffer(buffer);
                        globalBuffer = buffer;
                    }
                    
                }
            }
        }

        //Method to determine whether or not to show the app bar (Only shown for drawer)
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Pivot.SelectedItem == Drawer)
            {
                ApplicationBar.Mode = ApplicationBarMode.Default;
                ApplicationBar.IsVisible = true;
                ApplicationBar.IsMenuEnabled = false;
            }

            else
            {
                ApplicationBar.IsVisible = false;
            }
        }

        //Method to activate a button (called from drawer app bar)
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            ButtonEntity tempButton = new ButtonEntity("Standard");
            if (listBox1.SelectedIndex != -1)
            {
                tempButton = currentApp.globalLib.masterArray[listBox1.SelectedIndex];
                ActiveVM.setActiveButton(tempButton);
            }
        }

        //Method to navigate to the new button page (Called from drawer app bar)
        private void ApplicationBarIconButton_AddNew(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewButtonPage.xaml",UriKind.RelativeOrAbsolute));
        }

        //Method to remove a button from master lib (Called from drawer app bar)
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ButtonEntity tempDelete = new ButtonEntity("Standard");
            tempDelete = currentApp.globalLib.masterArray[listBox1.SelectedIndex];
            if (listBox1.SelectedIndex > 2 )
            {            
                currentApp.globalLib.masterArray.RemoveAt(listBox1.SelectedIndex);
            }

            if (tempDelete.isDefault == false)
            {
                myStorage.DeleteNameArray();
                myStorage.SaveNameArray();
                myStorage.DeleteButtonStorage(tempDelete.buttonText);
            }
            
            


        }
    
    }
}