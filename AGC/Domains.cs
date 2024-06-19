﻿/*
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
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;

#pragma warning disable CS0649

namespace LGC
{
    internal class Funcs
    {
        //This will send the string to the UDP listener in ReEntry
        public static void SendCommand(string command)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("127.0.0.1");
            byte[] sendbuf = Encoding.UTF8.GetBytes(command);
            IPEndPoint ep = new IPEndPoint(broadcast, 8051);
            s.SendTo(sendbuf, ep);
        }
    }

    //Prebuilt the needed DSKY keys as serialized packets
    internal class StoredCmds
    {
        public static void LGC0() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC0,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC1()
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC1,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC2()
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC2,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC3() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC3,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC4() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC4,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC5() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC5,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC6() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC6,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC7() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC7,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC8() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC8,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGC9() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGC9,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCVerb() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCVerb,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCNoun() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCNoun,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCEntr() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCEntr,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCKeyRel() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCKeyRel,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCPro() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCPro,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCClear() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCClr,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCRset() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCRset,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCPlus() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCPlus,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
        public static void LGCMinus() 
        {
            var packet = new DomainModels.DataModel()
            {
                TargetCraft = (int)DomainModels.DataPacket.Craft.LunarModule,
                MessageType = (int)DomainModels.DataPacket.MessageTypes.PushButton,
                ID = (int)DomainModels.LunarModuleButtonID.LGCNeg,
                ToPos = (int)DomainModels.PinPosition.NULL
            };
            string jsonString = JsonSerializer.Serialize(packet);
            Funcs.SendCommand(jsonString);
        }
    }

    //Mostly from the ReEntry example
    internal class DomainModels
    {

        public class DataPacket
        {
            public enum Craft { Mercury, Gemini, CommandModule, LunarModule, SpaceShuttle, Vostok }
            public Craft TargetCraft = Craft.Mercury;
            public enum MessageTypes { SetSwitch, PushButton }
            public MessageTypes MessageType = MessageTypes.SetSwitch;
            public int ID;
            public int ToPos;
        }

        //Added this so we can serialize what data we want to send in the packet
        public class DataModel
        {
            public int TargetCraft { get; set; }
            public int MessageType { get; set; }
            public int ID { get; set; }
            public int ToPos { get; set; }
        }


        public enum MercurySwitchID
        {
            NULL, CabinLight, PhotoLight, LaunchControl, StbyBtry, IsolBtry, Ammeter,
            AudioBus, FansACBus, CabinFan, SuitFan, ASCSAC, ASCSMode, ASCSAuto, ASCSGyro,
            ArmSquib, RetroDelay, RetroAtt, AutoRetroJett, RetractScope, AttitudeSelect,
            WarningLightsBrightness, VOXSwitch, Beacon, Transmit, UHFSelect, UHFDF,
            TLMLoFreq, LandingBag, RescueAids, AudioCabinPress, AudioO2Emer, AudioFuelQuan,
            AudioRetroWarn, LightsTest, AudioH2OCabin, AudioH2OSuit, AudioRetroReset,
            InletValve, Maneuver, Battery1, Battery2, Battery3, Standby1, Standby2, IsolatedBattery
        };

        public enum GeminiSwitchID
        {
            NULL, FUSECoaxCntl,
            SquibBoostInsert, SquibRetroPWR, SquibRetroJett, SquibLanding, SquibRetro1, SquibRetro2, SquibRetro3, SquibRetro4,
            MainBattery1, MainBattery2, MainBattery3, MainBattery4, SquibBattery1, SquibBattery2, SquibBattery3,
            LightsBrightness, LightsTest,
            FuelCell1PurgeO2, FuelCell1PWR, FuelCell2PurgeO2, FuelCell2PWR, FuelCell1A, FuelCell1B, FuelCell1C, FuelCell2A, FuelCell2B, FuelCell2C,
            BusTie1, BusTie2,
            ControllerPWROAMS, ControllerPWRRCSA, ControllerPWRRCSB, ACPowerSource,
            MDIUPower, AuxTapePWR, ComputerPower, HorizonScannerSelect, HorizonScannerHeater,
            SuitFan, FUSESuitFan1, FUSESuitFan2, O2HighRate, CoolPriPumpA, CoolPriPumpB, CoolSecPumpA, CoolSecPumpB,
            RadiatorFlow, EvaporatorHeat, EvaporatprMaxFlow, EventTimerStart, EventTimerDirection, ElapsedTimeStarter,
            H2VacTank, CryoHeaterO2, CryoHeaterH2, OAMReg, PropMotoOAMS, PropMotRCSA, PropMotRCSB, FUSEDCDCConv,
            LightsCabin, LightsFDI, CTRLights,
            FUSEAudioAndUHFTR1, FUSEAudioAndUHFTR2, FUSEUHFRelay, FUSEToneVox, FUSETV, FUSEHFTR, FUSEAntCntl, FUSEWhipAntHF, FUSEWhipAntUHF, FUSEWhipAntDiplex,
            FUSEElectTimer, FUSEEventTimer, FUSEBoostCutoff1, FUSEBoostCutoff2, FUSERetroAuto, FUSERetroMan, FUSETr256, FUSEECSIndLts, FUSEIndLtTest, FUSESeqLightsPWR, FUSESeqLightsCntl, FUSEParaCntl,
            FUSEAttIncCntlRetro, FUSEAttIndCntlLdg, FUSEBoostInsertCntl1, FUSEBoostInsertCntl2, FUSERetroSeqCntl1, FUSERetroSeqCntl2, FUSELandingSecCntl1, FUSELandingSecCntl2, FDI1Controller, GuidanceSwitch,
            FUSEBeaconsC, FUSEBeaconsResc, FUSEBeaconsAcq, FUSEAUXRecp, FUSECryQty, FUSECoolPumpSecB, FUSECoolPumpSecA, FUSECoolPumpPriB, FUSECoolPumpPriA,
            FUSETMAC, FUSEXmtrsDT, FUSEXmtrsRT, FUSEXmtrsStbyPWR, FUSEXmtrsStbyCntl, FUSEPriO2Htrs, FUSEH2OHtrs, FUSEClkLt,
            FUSEOAMSHtrs, FUSEEvapThr, FUSECoolVlvsSec, FUSECoolVlvsPri, FUSEO2RateCntl,
            ACMEBiasPWR, RollJetsSelector, FUSEACMECntl1, FUSEACMECntl2, FUSEOAMSCntlProp, FUSEOAMSCntlReg1, FUSEOAMSCntlReg2, FUSERCSSquibs1, FUSERCSSquibs2,
            OAMSResvSwitch, FUSEManThru9, FUSEManThru10, FUSEManThru11, FUSEManThru12, FUSEManThru13, FUSEManThru14, FUSEManThru15, FUSEManThru16,
            AttitiudeDriversSwitch, FUSEAttThrust1, FUSEAttThrust2, FUSEAttThrust3, FUSEAttThrust4, FUSEAttThrust5, FUSEAttThrust6, FUSEAttThrust7, FUSEAttThrust8,
            ACMELogicYawSelector, ACMELogicPitchSelector, ACMELogicRollSelector, FUSERCSAPitch, FUSERCSAYawL, FUSERCSAYawR, FUSERCSBPitch, FUSERCSBYawL, FUSERCSBYawR,
            FUSEAUXTape, FUSESEOInst, FUSECalib, FUSEBioMedInst, FUSEDCSPWR, FUSEFCO2H2Reg, FUSEFCO2H2HTR, AGENAPWR, AGENASquib1, AGENASquib2, AGENACntl,
            FUSERadarPWR, FUSEACMEInv, FUSERCSHTRSA, FUSERCSHTRSB, FUSETapeRecorderPWR, FUSETapeRecorderCNTL, FUSEFuelCellCntl1, FUSEFuelCellCntl2, FUSEFCdP, AGENAEncoder, AGENAExtrLts,
            FDI2Switch, FUSEBioMedRcdr1, FUSEBioMedRcdr2, FUSERCSHtr, AGENAIndexEvaBars, AGENAEngineARM, AGENABusArm,
            RadarLockOn, TDAUndock, RateGyroPitch, RateGyroYaw, RateGyroRoll, UHFRadioSelect, HFAntennaSelect, RadioSilence, RadioKeying, RadioRecord,
            BeaconResc, BeaconSBand, BeaconCBand, TMCalib, TMSby, TMTM, RadioTapePlayback, RadioAntSel, HfAntControl, TDARigid,
            ABORTHandle, XOver
        };
        public enum GeminiButtonID
        {
            NULL, JettFairing, SepSpcft, IndRetroAtt, RCS, SepOAMSLine, SepElec, SepAdapt, ArmAutoRetro, JettRetro, ManFireRetro,
            Keyboard1, Keyboard2, Keyboard3, Keyboard4, Keyboard5, Keyboard6, Keyboard7, Keyboard8, Keyboard9, KeyboardZero,
            KeyboardReadOut, KeyboardClear, KeyboardEnter, ComputerReset, ComputerStart, PlatformReset, EmerRelease, DCSReceive, IMUReset,
            HiAltDrogue, Para, LdgAtt, ParaJett, EjectDRingCDR, EjectDRingPLT
        };

        public enum CommandModuleSwitchID
        {
            NULL, FC1MNA, FC2MNA, FC3MNA, FC1MNB, FC2MNB, FC3MNB, Inverter1MNA, Inverter2MNB, Inverter3MNAMNB, ACBus1Inv1, ACBus1Inv2, ACBus1Inv3, ACBus2Inv1, ACBus2Inv2, ACBus2Inv3,
            FC1Htr, FC2Htr, FC3Htr, FC1ReactantShutoff, FC2ReactantShutoff, FC3ReactantShutoff, FCReacsValves, CryoH2Htr1, CryoH2Htr2, CryoO2Htr1, CryoO2Htr2, CryoH2Fan1, CryoH2Fan2,
            CryoO2Fan1, CryoO2Fan2, FCRadiator1, FCRadiator2, FCRadiator3, FC1Purge, FC2Purge, FC3Purge, H2PurgeLineHtr, GnNOpticsPWR, GnNIMUPWR, PrplntDumpAuto, TwoEngOut, LVRates, TwrJett1, TwrJett2,
            LVSPSIndaPc, LVSPSIncSIISIV_GP1, CMCAtt, IMUCage, Guidance, SII_SIVBStage, EDS, GNLightACPWR, FDAIScale, FDAISelect, FDAISource, ATTSet, AutoRCSA1, AutoRCSA2, AutoRCSA3, AutoRCSA4,
            AutoRCSB1, AutoRCSB2, AutoRCSB3, AutoRCSB4, AutoRCSC1, AutoRCSC2, AutoRCSC3, AutoRCSC4, AutoRCSD1, AutoRCSD2, AutoRCSD3, AutoRCSD4, SigCondDriverBiasPWR1, SigCondDriverBiasPWR2,
            RCSCommand, RotCntlPWR_Normal1, RotCntlPWR_Normal2, RotCntlPWR_Direct1, RotCntlPWR_Direct2, TransCntlPWR, SCCont, EDSPower, SMRCSHe1A, SMRCSHe1B, SMRCSHe1C, SMRCSHe1D, SMRCSHe2A,
            SMRCSHe2B, SMRCSHe2C, SMRCSHe2D, SMRCSPrplnt1A, SMRCSPrplnt1B, SMRCSPrplnt1C, SMRCSPrplnt1D, SMRCSPrplnt2A, SMRCSPrplnt2B, SMRCSPrplnt2C, SMRCSPrplnt2D, CMPrplntT1, CMPrplntT2,
            SM_RCSIndSel, SM_RCS_Heater_A, SM_RCS_Heater_B, SM_RCS_Heater_C, SM_RCS_Heater_D, AttRate, AttDeadband, AttCycleLimiter, AttManualRoll, AttManualPitch, AttManualYaw, CMCMode,
            BMAGRoll, BMAGPitch, BMAGYaw, TVCPitch, TVCYaw, TVCGimbalMotorsPitch1, TVCGimbalMotorsPitch2, TVCGimbalMotorsYaw1, TVCGimbalMotorsYaw2, TVCGimbalDrivePitch, TVCGimbalDriveYaw,
            TVCServo1, TVCServo2, EventTimerP1_DirectionReset, EventTimerP1_StartStop, EventTimerP1_ModifyMin, EventTimerP1_ModifySec, SPSDirectOn, SPSdVThrustA, SPSdVThrustB, SPSHeVlv1, SPSHeVlv2,
            SPSPSIInd, SPSLineHtrs, SPSTest, SPSOxidFlow, SPSOxidPrimAux, SPSPUGMode, TM_Hrs, TM_Min, TM_Sec, SIVB_LMSep, EMSSetting, EMS_GTA, CM_SM_Sep1, CM_SM_Sep2, CW_Mode, CW_CSM_SM, CW_PWR, CW_LampTest,
            MSNTimerStart, RCSTransfer, CM_RCS_Press, RCSLogic, CM_RCS_Heaters, ELSLogic, ELSAuto, SeqLogic1, SeqLogic2, PyroArmA, PyroArmB, FloatBag1, FloatBag2, FloatBag3, CMRCSPrplntDump, CMRCSPrplntPurge,
            GlycolEvapTempInAuto, O2PressInd, CabinFan1, CabinFan2, SuitCircHeatExch, H2OAccumAuto, H2OAccumPWR, PotH2OHtr, GlycolEvapH2OFlow, H2OWaterQtyInd, SecCoolLoopEvap, SecCoolPumpAC,
            GycolEvapSteamPressAuto, GycolEvapSteamPressMod, CabinTempAuto, FuelCellPumpA, FuelCellPumpB, FuelCellPumpC, BatteryChargerAC, RadiatorFlowContPower, RadiatorFlowContSelector,
            RadiatorManSel, RadiatorHeaterPrimary, RadiatorHeaterSecondary, Radio1Mode, Radio1PadComm, Radio1SBand, Radio1Power, Radio1Intercom, Radio1VHF, Radio1AudioControl, Radio1Suit, Radio1VHFRange,
            Radio2Mode, Radio2PadComm, Radio2SBand, Radio2Power, Radio2Intercom, Radio2VHF, Radio2AudioControl, Radio2Suit, HighGainTrack, HighGainBeam, HighGainServoPwr, HighGainServoSel,
            SBandNormalXpndr, SBandNormalPwrAmplSel, SBandNormalPwrAmplStr, SBandNormalModeVoiceRelay, SBandNormalModePCMKey, SBandNormalModeRng, SBandAUXTapeDNVoiceBU, SBandAUXTVSCI, UpTlmDataDNVoicedBU, UpTlmCmd,
            SBandAntennaOmniABC, SBandAntennaOmniDHiG, SqA_VHFAmA, SqA_VHFAmB, SqA_RcvOnly, SqA_VHFBcn, SqA_VHFRanging, SqB_TapeRec_ANLG_LM, SqB_PlayMode, SqB_TapeSpool, SqB_PwrSCE, SqB_PwrPMP, SqB_PCMBitRate,
            DockingProbeExtend, DockingProbeRetractPrim, DockingProbeRetractSec, ExtLightRUNEVA, ExtLightRNDZ, TunnelLights, LMPower, UpTlm_IU, UpTlm_CM, LogicPower23, Dot05gAllowed, EMSRoll,
            SPSGauging, TelecomGroup1, TelecomGroup2, SuitCompressor1, SuitCompressor2, MainChuteRelease, NonEssBus, MainBusTieAC, MainBusTieBC, MNAUndervoltSensor, MNBUndervoltSensor,
            ORDEAL_FDAI1, ORDEAL_FDAI2, ORDEAL_Mode, ORDEAL_Lighting, ORDEAL_Slew, ORDEAL_Location, CSMLMSep1, CSMLMSep2, XLunarInject,
            //TSS
            WasteH2ODumpHtr, UrineDumpHtr, P3_ACBus1Reset, P3_ACBus2Reset,
            P122_OpticsMode, P122_ControllerSpeed, P122_ControllerCoupling, P122_Tracker, P122_TelescopeTrunnion, P122_ConditionLamps, P122_OpticsUptlm,
            P300_OxygenFlow, P301_OxygenFlow, P302_OxygenFlow,
            P100_UtilityPower, P100_FloodDim, P100_FloodFixed, P100_RendzTpndr, P306_TM_Hrs, P306_TM_Min, P306_TM_Sec, P306_TM_Start,
            P306_EventTimer_DirectionReset, P306_EventTimer_StartStop, P306_EventTimer_ModifyMin, P306_EventTimer_ModifySec,
            P101_RndzXpndrTest, P15_CoasPower, P15_UtilityPower, P15_BeaconLight, P15_DyeMarker, P15_Vent, P376_PLVC,
            P16_DockingTarget, P16_Utility, P16_CoasPower, P227_SCIInst, P180_SBandSquelch, P162_SCIPower, P163_SCIPower,
            P8_FloodDim, P8_FloodFixed, P1_dVCG, P5_FloodDim, P5_FloodFixed,
            P600_EmerO2Valve, P601_RepressO2Valve
        };
        public enum CommandModuleButtonID
        {
            NULL, AGCVerb, AGCNoun, AGCPluss, AGCMinus, AGC0, AGC1, AGC2, AGC3, AGC4, AGC5, AGC6, AGC7, AGC8, AGC9, AGCClear, AGCPro, AGCKeyRel, AGCEntr, AGCRset,
            Liftoff, NoAutoAbort, LESMotorFire, CanardDeploy, CSMLVSep, APEXCoverJett, DrogueDeploy, MainDeploy, CMRCSHeDump, GDCAlign, SPSDirectUllage, SPSThrustOn,
            EMS_Increase, EMS_Decrease, EMS_IncreaseFast, EMS_DecreaseFast, MasterCaution, Abort, P351_EmerCabinPressTest, P380_DemandRegulatorBleedPort
        };
        public enum LunarModuleSwitchID
        {
            NULL, P14_EDVolts, P14_Inverter, P14_DescentBat1LMPHiV, P14_DescentBat1LMPLoV, P14_DescentBat2LMP, P14_DescentBat3CDR, P14_DescentBat4CDRHiV, P14_DescentBat4CDRLoV, P14_DescentBatLunarCDR, P14_DescentBatLunarLMP,
            P14_DesBayDeadface, P14_AscentBat5NormalLMPFeed, P14_AscentBat5BackupCDRFeed, P14_AscentBat6NormalCDRFeed, P14_AscentBat6BackupLMPFeed, P14_UplinkSquelch,
            P02_SysA_ASCFeed1, P02_SysA_ASCFeed2, P02_SysA_Q1, P02_SysA_Q2, P02_SysA_Q3, P02_SysA_Q4, P02_SysB_ASCFeed1, P02_SysB_ASCFeed2, P02_SysB_Q1, P02_SysB_Q2, P02_SysB_Q3, P02_SysB_Q4, P02_Crossfeed, P02_MainSOV_SysA, P02_MainSOV_SysB, P02_ACAProp,
            P03_RCS_Heaters_Q1, P03_RCS_Heaters_Q2, P03_RCS_Heaters_Q3, P03_RCS_Heaters_Q4,
            P01_AttTransFourTwoJetMode, P08_DesPropulsion_FuelVent, P08_DesPropulsion_OxidVent, P08_DesPrplnt_IsolVlv, P08_MasterArm, P08_DesVent, P08_ASCHeSel,
            P08_LandingGearDeploy, P08_HePRESS_RCS, P08_HePRESS_DesStart, P08_HePRESS_Ascent, P08_Stage, P08_StageRelay,
            P01_PrplntQtyMon, P01_PrplntTempMon, P01_AscentHeReg1, P01_AscentHeReg2, P01_DescentHeReg1, P01_DescentHeReg2, P03_DesEngCmdOvrd, P03_EngGmbl, P01_EngineThrustCont_ThrCont_ThrCont, P01_EngineThrustCont_ManThrot, P01_EngineThrustCont_EngArm, P01_EngineThrustCont_BalCpl,
            P03_DeadBand, P03_GyroTest_Attitude, P03_GyroTest_Rate, P03_AttitudeControl_Roll, P03_AttitudeControl_Pitch, P03_AttitudeControl_Yaw, P03_ModeControl_PGNS, P03_ModeControl_AGS, P03_IMUCage,
            P01_GuidCont, P01_ModeSel, P01_RngAltMon, P01_RateErrMon, P01_AltitudeMon, P01_RateScale, P01_ACAProp, P01_ShfTrun, P02_RateErrMon, P02_AltitudeMon,
            P03_LandingAnt, P03_RadarTest, P03_SlewRate, P03_Slew, P03_EventTimer_CountDir_Reset, P03_EventTimer_TimerCount, P03_EventTimer_SlewCountMin, P03_EventTimer_SlewCountSec, P03_SidePanels, P03_Lighting_Flood_OvhdFwd, P03_Lighting_Exterior, P03_XPointerScale,
            P08_Audio_Replay, P08_Coas, P08_Audio_SBand, P08_Audio_ICS, P08_Audio_VHFA, P08_Audio_VHFB, P08_Audio_CommMode, P08_Audio_AudioCont,
            P12_Audio_Replay, P12_Audio_SBand, P12_Audio_ICS, P12_Audio_AudioCont, P12_Audio_CommMode, P12_Audio_VHFA, P12_Audio_VHFB, P12_Audio_UpdataLink,
            P12_Comm_Modulate, P12_Comm_XmitRcvr, P12_Comm_PwrAmpl, P12_Comm_FuncVoice, P12_Comm_FuncPCM, P12_Comm_Range, P12_Comm_VHF_A_Xmtr, P12_Comm_VHF_A_Rcvr, P12_Comm_VHF_B_Xmtr, P12_Comm_VHF_B_Rcvr, P12_Comm_TelemetryBiomed, P12_Comm_TelemetryPCM, P12_Comm_TrackMode, P12_Comm_Recorder,
            P06_AGS_Status, P04_CDR_ACA, P04_CDR_TTCA, P04_LMP_ACA, P04_LMP_TTCA,
            P05_MissionTimer_TimerCont, P05_MissionTimer_Hours, P05_MissionTimer_Min, P05_MissionTimer_Sec,
            P05_Lighting_Sidepanels, P05_Lighting_Integral, P05_Lighting_Num, P05_Lighting_Anun, P05_DesRate, P01_XPointerScale,
            ORDEAL_FDAI1, ORDEAL_FDAI2, ORDEAL_Mode, ORDEAL_Lighting, ORDEAL_Slew, ORDEAL_Location
        };
        public enum LunarModuleButtonID
        {
            NULL, AGSButton1, P05_StartEngine, P06_StopEngine, P05_StopEngine, P01_MasterAlarm, P02_MasterAlarm,
            LGCVerb, LGCNoun, LGCPlus, LGCNeg, LGC0, LGC1, LGC2, LGC3, LGC4, LGC5, LGC6, LGC7, LGC8, LGC9, LGCClr, LGCPro, LGCKeyRel, LGCEntr, LGCRset,
            P05_Transl, P01_Abort, P01_AbortStage, AGSButton0, AGSButton2, AGSButton3, AGSButton4, AGSButton5, AGSButton6, AGSButton7, AGSButton8, AGSButton9, AGSButtonHold, AGSButtonCLR, AGSButtonReadOut, AGSButtonEntr, AGSButtonPos, AGSButtonNeg
        };
        public enum PinPosition { NULL, Left, Middle, Right, Up, Down };
    }
}
