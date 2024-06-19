/*
 __        _______   ______         __________   ___ 
|  |      /  _____| /      |       |   ____\  \ /  / 
|  |     |  |  __  |  ,----' ______|  |__   \  V  /  
|  |     |  | |_ | |  |     |______|   __|   >   <   
|  `----.|  |__| | |  `----.       |  |____ /  .  \  
|_______| \______|  \______|       |_______/__/ \__\                                                                                                             
                                                                                          
                                            -                                             
                                           .-     :===-.                                  
                                            :    :::==--                                  
                              ...           .    .:....:                                  
                               :==:..   ...:---:..:::=:..                                 
                     .---.:------++*++=---====+==+%%%%%%= --.                             
                     :=::::+++-:++*+-=:..:=*##%#*#*==#*+.-=.                              
                         ..- .+*==-:*@%..-+##%%#**-*+++*:-@@-                             
                             :=----=%@@#%%#+=-::.-:::::--:-#=                             
                             --:-===%@@@#=::::...=:---=+-:::+                             
                      ++ .-==-:-==-=%%%#***#####%+:------+%%@*                            
                     .=*%@@@*+=----#@%%@@%%%##@@@=::-*-:==%@@@#:.  **                     
                    .**+#@@@*+==+###%%%%@@@@%%@@@::::=:---#%%@@#*#++*::.                  
                      :+-*@%--=++**######%%%@%@@@:-==+=++++++++*#*##%#=.                  
                      -=  -==-+#*#*#%##**###%%@@#*#####@@#-::::+*+=#++.                   
                          -=---===+*%%#%@@@@@@@@*=--=*%@@#-....*++=*+:.                   
                         .-=:::-=+%+%@@%%@@@@@@%=:  :@%@@*: . :*#+=--:.                   
                         .***#**#*==#%%@%%%@@@%*.  .:*#@@*-..=**+==##-                    
                          +##@@@%#=@@@@%%%%%#%%=:----+*##+: +##@@*#-                      
                         :#-##%%#=-@@@@*%@@@@%###%%%#%%%@@*#%@%%#+==#++-.                 
                    ..:=--==#***+=-@@@@#@@@@@@####***+++++===-=+###%+::+#*.               
                  :=*####%**#%%%%%%%###########***#+======-**%%%%###+ :-=:=.              
                :+++=-##*#%#*#@@@@@@@@@@@@%%#*##**###*-==-=-+%%%%%%%*-.-. =-.             
               ==.+   +%*%%+-++#@@@@@@@@@@%%#+=-.-=++#**++*--@%%@@@@%. =   =-             
              -*. -+. +##%%**++**#@@@##+%+#+**=-=-=:**#++++-=#%%%@@@% -:    ==            
             .*-   ++:+@%##*=**++##@@**+*+#*===::+*=*+*=**==+###%@@@@ =      +=           
             +-     +-+##*%*+--+#%+##+%%#***##+:+++:*++*++=+=*=+#+=#@-:       +-          
            +=      .+=+%%@+%+##+==+*#++*++=*++++=-+=-=+-+=++*=+#--*@+-:.     .=:         
           --.       :#++#%+======+*-+=*#+=#*=*-:-=+-+=++*++++*+*==+@**++**--::=+:        
          :+:       .:+##**=**-=**#+*=**#++*#*#-+==:-=+*==+-*****=:. ..::-::---**+.       
         .+=-=:-==+==-+.:=#+#+=****-*=####*+*+*+*=:--+=+++*-*#+-.            ..: -*.      
         ===+         +:==::###%%%##%%##%**##%#**+++****+====-+==---:             ++.     
        --=-.:.:-::::-=.    .-=++++=:..%@@@@%%%##+==*+   : +- : .=#*+            ::*=..   
       :=:.....:-===:                 .#%@@@@%%##%##*+:::-.=-:=-::              %#+#+==*+ 
       +:                                ........     ...-:---..                 .::::..  
      ==                                                  : =: .                          
     :+:                                                    ==                            
 ==+*=#**#=                                                 :+.                           
 :==+=-:::                                                   +-                           
                                                         =++*#=*+=-                       
                                                         :+=+*+*+*:                      
                                                                                          
  External LGC DSKY for ReEntry LM
  Compiled on VS2022 17.10.3 // .NET Framework 4.8.1
  by Sputterfish
  This project uses fonts from the DSKY-FONTS project @ https://github.com/ehdorrii/dsky-fonts
  This project uses some code from the ReEntryUDP example project @ https://github.com/ReentryGame/ReentryUDP
*/
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Text.Json;
using System.IO;
#if DEBUG
using System.Diagnostics;
#endif
#pragma warning disable CS0168

namespace LGC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool AreWeDarkMode;

        public MainWindow()
        {
            InitializeComponent();
            AreWeDarkMode = false;
            MouseDown += Window_MouseDown;
        }

        //MainWindow movement
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        //Updates all the displayed values and flashes the anun lights
        public void UpdateStoredValues()
        {

            Verb.Content = LGCStorage.VerbD1 + LGCStorage.VerbD2;
            Noun.Content = LGCStorage.NounD1 + LGCStorage.NounD2;
            Prog.Content = LGCStorage.ProgramD1 + LGCStorage.ProgramD2;
            Register1.Content = LGCStorage.Register1Sign + " " + LGCStorage.Register1D1 + LGCStorage.Register1D2 + LGCStorage.Register1D3 + LGCStorage.Register1D4 + LGCStorage.Register1D5;
            Register2.Content = LGCStorage.Register2Sign + " " + LGCStorage.Register2D1 + LGCStorage.Register2D2 + LGCStorage.Register2D3 + LGCStorage.Register2D4 + LGCStorage.Register2D5;
            Register3.Content = LGCStorage.Register3Sign + " " + LGCStorage.Register3D1 + LGCStorage.Register3D2 + LGCStorage.Register3D3 + LGCStorage.Register3D4 + LGCStorage.Register3D5;

            // COMP ACTY
            if (LGCStorage.IlluminateCompLight==true)
            {
                CompActy.Visibility = Visibility.Visible;
            }
            else { CompActy.Visibility = Visibility.Hidden; }

            //LEFT SIDE LIGHTS
            //UPLINK ACTY
            if (LGCStorage.IlluminateUplinkActy > 0) 
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/uplinkacty.png", UriKind.Relative);
                UplinkActy.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    UplinkActy.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/uplinkacty.png", UriKind.Relative);
                    UplinkActy.Source = new BitmapImage(uriSource);
                }
            }
            //NO ATT
            if (LGCStorage.IlluminateNoAtt > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/noatt.png", UriKind.Relative);
                NoAtt.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    NoAtt.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/noatt.png", UriKind.Relative);
                    NoAtt.Source = new BitmapImage(uriSource);
                }
            }
            //STBY
            if (LGCStorage.IlluminateStby > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/stby.png", UriKind.Relative);
                Stby.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Stby.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/stby.png", UriKind.Relative);
                    Stby.Source = new BitmapImage(uriSource);
                }
            }
            //KEY REL
            if (LGCStorage.IlluminateKeyRel > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/keyrel.png", UriKind.Relative);
                KeyRel.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    KeyRel.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/keyrel.png", UriKind.Relative);
                    KeyRel.Source = new BitmapImage(uriSource);
                }
            }
            //OPR ERR
            if (LGCStorage.IlluminateOprErr > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/oprerr.png", UriKind.Relative);
                OprErr.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    OprErr.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/oprerr.png", UriKind.Relative);
                    OprErr.Source = new BitmapImage(uriSource);
                }
            }

            //RIGHT SIDE LIGHTS
            //TEMP
            if (LGCStorage.IlluminateTemp > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/temp.png", UriKind.Relative);
                Temp.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Temp.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/temp.png", UriKind.Relative);
                    Temp.Source = new BitmapImage(uriSource);
                }
            }
            //GIMBAL LOCK
            if (LGCStorage.IlluminateGimbalLock > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/gimballock.png", UriKind.Relative);
                Gimballock.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Gimballock.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/gimballock.png", UriKind.Relative);
                    Gimballock.Source = new BitmapImage(uriSource);
                }
            }
            //PROG
            if (LGCStorage.IlluminateProg > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/prog.png", UriKind.Relative);
                Program.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Program.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/prog.png", UriKind.Relative);
                    Program.Source = new BitmapImage(uriSource);
                }
            }
            //RESTART
            if (LGCStorage.IlluminateRestart > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/restart.png", UriKind.Relative);
                Restart.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Restart.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/restart.png", UriKind.Relative);
                    Restart.Source = new BitmapImage(uriSource);
                }
            }
            //TRACKER
            if (LGCStorage.IlluminateTracker > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/tracker.png", UriKind.Relative);
                Tracker.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Tracker.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/tracker.png", UriKind.Relative);
                    Tracker.Source = new BitmapImage(uriSource);
                }
            }
            //ALT
            if (LGCStorage.IlluminateAlt > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/alt.png", UriKind.Relative);
                Alt.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Alt.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/alt.png", UriKind.Relative);
                    Alt.Source = new BitmapImage(uriSource);
                }
            }
            //VEL
            if (LGCStorage.IlluminateVel > 0)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/lit/vel.png", UriKind.Relative);
                Vel.Source = new BitmapImage(uriSource);
            }
            else
            {
                if (AreWeDarkMode == true)
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                    Vel.Source = new BitmapImage(uriSource);
                }
                else
                {
                    var uriSource = new Uri(@"/LGC;component/images/lights/unlit/vel.png", UriKind.Relative);
                    Vel.Source = new BitmapImage(uriSource);
                }
            }
            if (AreWeDarkMode==true)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                Unlit1.Source = new BitmapImage(uriSource);
                Unlit2.Source = new BitmapImage(uriSource);
            }
            else if (AreWeDarkMode==false)
            {
                var uriSource = new Uri(@"/LGC;component/images/lights/unlit/unlit.png", UriKind.Relative);
                Unlit1.Source = new BitmapImage(uriSource);
                Unlit2.Source = new BitmapImage(uriSource);
            }
        }

        //DESERIALIZE OUR JSON AND MOVE TO STORAGE
        public static void GetLGCdata()
        {
            string folderRelativeFromLocalAppData = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "LocalLow"));
            string fileName = folderRelativeFromLocalAppData + "//Wilhelmsen Studios//ReEntry//Export//Apollo//outputLGC.json";//Maybe subject to change in future ReEntry Updates

            try
            {
                string jsonString = File.ReadAllText(fileName);
                LGCValues LGCValues = JsonSerializer.Deserialize<LGCValues>(jsonString);
                LGCStorage.VerbD1 = LGCValues.VerbD1;
                LGCStorage.VerbD2 = LGCValues.VerbD2;
                LGCStorage.NounD1 = LGCValues.NounD1;
                LGCStorage.NounD2 = LGCValues.NounD2;
                LGCStorage.ProgramD1 = LGCValues.ProgramD1;
                LGCStorage.ProgramD2 = LGCValues.ProgramD2;
                LGCStorage.Register1D1 = LGCValues.Register1D1;
                LGCStorage.Register1D2 = LGCValues.Register1D2;
                if (String.IsNullOrEmpty(LGCValues.Register1D3)) { LGCStorage.Register1D3 = " "; }
                else { LGCStorage.Register1D3 = LGCValues.Register1D3; }
                LGCStorage.Register1D4 = LGCValues.Register1D4;
                LGCStorage.Register1D5 = LGCValues.Register1D5;
                LGCStorage.Register1Sign = LGCValues.Register1Sign;
                LGCStorage.Register2D1 = LGCValues.Register2D1;
                LGCStorage.Register2D2 = LGCValues.Register2D2;
                if (String.IsNullOrEmpty(LGCValues.Register2D3)) { LGCStorage.Register2D3 = " "; }
                else { LGCStorage.Register2D3 = LGCValues.Register2D3; }
                LGCStorage.Register2D4 = LGCValues.Register2D4;
                LGCStorage.Register2D5 = LGCValues.Register2D5;
                LGCStorage.Register2Sign = LGCValues.Register2Sign;
                LGCStorage.Register3D1 = LGCValues.Register3D1;
                LGCStorage.Register3D2 = LGCValues.Register3D2;
                if (String.IsNullOrEmpty(LGCValues.Register3D3)) { LGCStorage.Register3D3 = " "; }
                else { LGCStorage.Register3D3 = LGCValues.Register3D3; }
                LGCStorage.Register3D4 = LGCValues.Register3D4;
                LGCStorage.Register3D5 = LGCValues.Register3D5;
                LGCStorage.Register3Sign = LGCValues.Register3Sign;
                LGCStorage.IlluminateCompLight = LGCValues.IlluminateCompLight;
                LGCStorage.IlluminateTemp = LGCValues.IlluminateTemp;
                LGCStorage.IlluminateGimbalLock = LGCValues.IlluminateGimbalLock;
                LGCStorage.IlluminateProg = LGCValues.IlluminateProg;
                LGCStorage.IlluminateRestart = LGCValues.IlluminateRestart;
                LGCStorage.IlluminateTracker = LGCValues.IlluminateTracker;
                LGCStorage.IlluminateAlt = LGCValues.IlluminateAlt;
                LGCStorage.IlluminateVel = LGCValues.IlluminateVel;
                LGCStorage.IlluminateUplinkActy = LGCValues.IlluminateUplinkActy;
                LGCStorage.IlluminateNoAtt = LGCValues.IlluminateNoAtt;
                LGCStorage.IlluminateStby = LGCValues.IlluminateStby;
                LGCStorage.IlluminateKeyRel = LGCValues.IlluminateKeyRel;
                LGCStorage.IlluminateOprErr = LGCValues.IlluminateOprErr;
            }
#if DEBUG
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Debug.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Debug.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Debug.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
#endif
            catch (Exception e)
            {

            }
        }

        //POWER JSON READER - CLICK
        //GET AGC/LGC DATA & UPDATE THE RENDERER EVERY 100 ms.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Task.Run(() =>
            {
                while (true)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            GetLGCdata();
                            UpdateStoredValues();
                        }
                        catch (IOException ex)
                        { }
                        catch (Exception ex)
                        { }
                    });
                    Task.Delay(100).Wait();
                }
            });
        }

        private void DarkMode_Click(object sender, RoutedEventArgs e)
        {
            if (AreWeDarkMode == false) { AreWeDarkMode = true; }
            else { AreWeDarkMode = false; }
            if (AreWeDarkMode == true)
            {
                var uriSource = new Uri(@"pack://application:,,,/LGC;component/images/agc-bg-darkLGC.png", UriKind.Absolute);
                MainBackground.ImageSource = new BitmapImage(uriSource);
                var uriSource1 = new Uri(@"/LGC;component/images/lights/unlit/unlit-darkmode.png", UriKind.Relative);
                UplinkActy.Source = new BitmapImage(uriSource1);
                Alt.Source = new BitmapImage(uriSource1);
                Gimballock.Source = new BitmapImage(uriSource1);
                KeyRel.Source = new BitmapImage(uriSource1);
                NoAtt.Source = new BitmapImage(uriSource1);
                OprErr.Source = new BitmapImage(uriSource1);
                Restart.Source = new BitmapImage(uriSource1);
                Stby.Source = new BitmapImage(uriSource1);
                Temp.Source = new BitmapImage(uriSource1);
                Tracker.Source = new BitmapImage(uriSource1);
                Vel.Source = new BitmapImage(uriSource1);
                Program.Source = new BitmapImage(uriSource1);
                Unlit1.Source = new BitmapImage(uriSource1);
                Unlit2.Source = new BitmapImage(uriSource1);
            }
            else
            {
                var uriSource = new Uri(@"pack://application:,,,/LGC;component/images/agc-bg.png", UriKind.Absolute);
                MainBackground.ImageSource = new BitmapImage(uriSource);
                var uriSource1 = new Uri(@"/LGC;component/images/lights/unlit/uplinkacty.png", UriKind.Relative);
                UplinkActy.Source = new BitmapImage(uriSource1);
                var uriSource2 = new Uri(@"/LGC;component/images/lights/unlit/noatt.png", UriKind.Relative);
                NoAtt.Source = new BitmapImage(uriSource2);
                var uriSource3 = new Uri(@"/LGC;component/images/lights/unlit/alt.png", UriKind.Relative);
                Alt.Source = new BitmapImage(uriSource3);
                var uriSource4 = new Uri(@"/LGC;component/images/lights/unlit/gimballock.png", UriKind.Relative);
                Gimballock.Source = new BitmapImage(uriSource4);
                var uriSource5 = new Uri(@"/LGC;component/images/lights/unlit/keyrel.png", UriKind.Relative);
                KeyRel.Source = new BitmapImage(uriSource5);
                var uriSource6 = new Uri(@"/LGC;component/images/lights/unlit/oprerr.png", UriKind.Relative);
                OprErr.Source = new BitmapImage(uriSource6);
                var uriSource7 = new Uri(@"/LGC;component/images/lights/unlit/prog.png", UriKind.Relative);
                Program.Source = new BitmapImage(uriSource7);
                var uriSource8 = new Uri(@"/LGC;component/images/lights/unlit/restart.png", UriKind.Relative);
                Restart.Source = new BitmapImage(uriSource8);
                var uriSource9 = new Uri(@"/LGC;component/images/lights/unlit/stby.png", UriKind.Relative);
                Stby.Source = new BitmapImage(uriSource9);
                var uriSource10 = new Uri(@"/LGC;component/images/lights/unlit/temp.png", UriKind.Relative);
                Temp.Source = new BitmapImage(uriSource10);
                var uriSource11 = new Uri(@"/LGC;component/images/lights/unlit/tracker.png", UriKind.Relative);
                Tracker.Source = new BitmapImage(uriSource11);
                var uriSource12 = new Uri(@"/LGC;component/images/lights/unlit/vel.png", UriKind.Relative);
                Vel.Source = new BitmapImage(uriSource12);
                var uriSource13 = new Uri(@"/LGC;component/images/lights/unlit/unlit.png", UriKind.Relative);
                Unlit1.Source = new BitmapImage(uriSource13);
                Unlit2.Source = new BitmapImage(uriSource13);
            }
        }

        //call these from buttons to send the ReEntry UDP API cmds
        private void Pro_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCPro();
        }

        private void Verb_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCVerb();
        }

        private void KeyNoun_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCNoun();
        }

        private void Key3_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC3();
        }

        private void Key2_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC2();
        }

        private void Key1_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC1();
        }

        private void Key0_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC0();
        }

        private void KeyRSET_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCRset();
        }

        private void KeyKeyRel_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCKeyRel();
        }

        private void KeyEntr_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCEntr();
        }

        private void KeyClear_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCClear();
        }

        private void KeyMinus_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCMinus();
        }

        private void Key4_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC4();
        }

        private void Key5_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC5();
        }

        private void Key6_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC6();
        }

        private void Key7_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC7();
        }

        private void Key8_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC8();
        }

        private void Key9_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGC9();
        }

        private void KeyPluss_Click(object sender, RoutedEventArgs e)
        {
            StoredCmds.LGCPlus();
        }
    }

    //values to store the serialized data
    public class LGCStorage
    {
        //public static bool IsInCM;
        public static bool IsInLM;
        public static string ProgramD1;
        public static string ProgramD2;
        public static string VerbD1;
        public static string VerbD2;
        public static string NounD1;
        public static string NounD2;
        public static string Register1D1;
        public static string Register1D2;
        public static string Register1D3;
        public static string Register1D4;
        public static string Register1D5;
        public static string Register1Sign;
        public static string Register2D1;
        public static string Register2D2;
        public static string Register2D3;
        public static string Register2D4;
        public static string Register2D5;
        public static string Register2Sign;
        public static string Register3D1;
        public static string Register3D2;
        public static string Register3D3;
        public static string Register3D4;
        public static string Register3D5;
        public static string Register3Sign;
        public static bool IlluminateCompLight;
        public static int IlluminateUplinkActy;
        public static int IlluminateNoAtt;
        public static int IlluminateStby;
        public static int IlluminateKeyRel;
        public static int IlluminateOprErr;
        public static int IlluminateTemp;
        public static int IlluminateGimbalLock;
        public static int IlluminateProg;
        public static int IlluminateRestart;
        public static int IlluminateTracker;
        public static int IlluminateAlt;
        public static int IlluminateVel;
    }

    //Set of values for serializing the jsons
    public class LGCValues
    {
        //public bool IsInCM { get; set; }
        public bool IsInLM { get; set; }
        public string ProgramD1 { get; set; }
        public string ProgramD2 { get; set; }
        public string VerbD1 { get; set; }
        public string VerbD2 { get; set; }
        public string NounD1 { get; set; }
        public string NounD2 { get; set; }
        public string Register1D1 { get; set; }
        public string Register1D2 { get; set; }
        public string Register1D3 { get; set; }
        public string Register1D4 { get; set; }
        public string Register1D5 { get; set; }
        public string Register1Sign { get; set; }
        public string Register2D1 { get; set; }
        public string Register2D2 { get; set; }
        public string Register2D3 { get; set; }
        public string Register2D4 { get; set; } 
        public string Register2D5 { get; set; }
        public string Register2Sign { get; set; }
        public string Register3D1 { get; set; }
        public string Register3D2 { get; set; }
        public string Register3D3 { get; set; }
        public string Register3D4 { get; set; }
        public string Register3D5 { get; set; }
        public string Register3Sign { get; set; }
        public bool IlluminateCompLight { get; set; }
        public int IlluminateUplinkActy { get; set; }
        public int IlluminateNoAtt { get; set; }
        public int IlluminateStby { get; set; }
        public int IlluminateKeyRel { get; set; }
        public int IlluminateOprErr { get; set; }
        public int IlluminateTemp { get; set; }
        public int IlluminateGimbalLock { get; set; }
        public int IlluminateProg { get; set; }
        public int IlluminateRestart { get; set; }
        public int IlluminateTracker { get; set; }
        public int IlluminateAlt { get; set; }
        public int IlluminateVel { get; set; }
    }
}
