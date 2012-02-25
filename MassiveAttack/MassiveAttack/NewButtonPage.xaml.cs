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
using Microsoft.Xna.Framework.Audio;
using System.IO.IsolatedStorage;

namespace MassiveAttack
{
    public partial class NewButtonPage : PhoneApplicationPage
    {
        ButtonEntity customButton = new ButtonEntity("Standard");
        public App currentApp = (App)App.Current;
        public StorageHelper newStore = new StorageHelper();//Not sure if this will work, might want to just make this global

        // XNA objects for record and playback
        Microphone buttonMic;
        DynamicSoundEffectInstance buttonPlayback; //Might not need
        // Used for storing captured buffers
        List<byte[]> buttonBufferCollection = new List<byte[]>();

        public NewButtonPage()
        {
            InitializeComponent();


            // Create new Microphone and set event handler
            buttonMic = Microphone.Default;
            buttonMic.BufferReady += OnMicrophoneBufferReady;
            buttonPlayback = new DynamicSoundEffectInstance(buttonMic.SampleRate, AudioChannels.Mono);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            customButton.buttonText = newText.Text;
            customButton.buttonColor.Color = chooseColor.Color;
            customButton.colorString = customButton.buttonColor.Color.ToString();
            customButton.isDefault = false;

            currentApp.globalLib.masterArray.Add(customButton);
            //call memory savers here
            newStore.AddNameArray(customButton.buttonText);
            newStore.SaveNameArray();
            newStore.AddButtonStorage(customButton);
            NavigationService.GoBack();
        }

        void OnMicrophoneBufferReady(object sender, EventArgs args)
        {
            // Get buffer from microphone and add to collection
            byte[] buffer = new byte[buttonMic.GetSampleSizeInBytes(buttonMic.BufferDuration)];
            int bytesReturned = buttonMic.GetData(buffer);
            buttonBufferCollection.Add(buffer);

        }

        void OnRecordButtonClick(object sender, RoutedEventArgs args)
        {
            if (buttonMic.State == MicrophoneState.Stopped)
            {
                // Clear the collection for storing buffers
                buttonBufferCollection.Clear();

                // Stop any playback in progress (not really necessary, but polite I guess)
                buttonPlayback.Stop();

                // Start recording
                buttonMic.Start();
                recordButton.Content = "Stop";
            }
            else
            {
                StopRecording();
                recordButton.Content = "Record Sound";
            }

        }

        void StopRecording()
        {
            // Get the last partial buffer
            int sampleSize = buttonMic.GetSampleSizeInBytes(buttonMic.BufferDuration);
            byte[] extraBuffer = new byte[sampleSize];
            int extraBytes = buttonMic.GetData(extraBuffer);

            // Stop recording
            buttonMic.Stop();

            // Save data in isolated storage
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = storage.CreateFile(newText.Text))
                {
                    // Write buffers from collection
                    foreach (byte[] buffer in buttonBufferCollection)
                        stream.Write(buffer, 0, buffer.Length);

                    // Write partial buffer
                    stream.Write(extraBuffer, 0, extraBytes);
                }
            }
        }



    }
}