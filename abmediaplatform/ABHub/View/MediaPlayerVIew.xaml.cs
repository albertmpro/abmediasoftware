using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.TimeSpan;
using ABHub.Code;
using ABHub.Code.Controls;
using Albert.Win32.Controls;
using System.IO;

namespace ABHub.View
{
    /// <summary>
    /// Main Media Player of the Application 
    /// </summary>
    public partial class MediaPlayerView : HubView, IHubTabInit
    {
        public MediaPlayerView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("Media Player", _tab, Close);
            Init();
            
        }
        public MediaPlayerView(TabControl _tab, FileInfo _info)
        {
            InitializeComponent();
            SetupTab(_info.Name, _tab, Close);
            //Load Player 
            myplayer.Source = new Uri(_info.FullName);
            Init();
        }

        public void Init()
        {
          
        }
        public void Close()
        {
            TabDialog.Show("Closing", "Close Media Player", "Close", "Cancel", () =>
                {
                    //Stop the Player
                    myplayer.Stop();
                    //Remove Tab 
                    RemoveTab();
                
                });
        }

        void Media_Click(object sender, RoutedEventArgs e )
        {
            var push = sender as PushButton;

            switch (push.Tag)
            {
                case "FastRewind":
                    // Rewind 3 seconds 
                    myplayer.FastRewind();
                    break;
                case "Rewind":
                    // Rewind 1.5 seconds 
                    myplayer.Rewind();
                    
                    break;
                case "Play":
                    //Play
                    myplayer.Play();
                    break;
                case "Pause":

                    //Pause
                    myplayer.Pause();
                    break;
                case "Stop":
                    //Stop
                    myplayer.Stop();
                    break;
                case "Forward":
                    // Go Forward a 1.5 seconds 
                    myplayer.Forward();
                    break;
                case "FastForward":
                    // Go forawrd a 3 seconds 
                    myplayer.FastRForward();
                    break;
            }

        }
    }
}
