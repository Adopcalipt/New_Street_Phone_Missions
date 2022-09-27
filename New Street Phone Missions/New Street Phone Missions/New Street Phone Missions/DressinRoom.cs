using GTA;
using GTA.Native;
using System.Collections.Generic;
using New_Street_Phone_Missions.Classes;
using System.IO;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class DressinRoom 
    {
        private static readonly List<Tattoo> maleTats01 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_M", Name = "Painted Micro SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_M", Name = "Weapon King" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_M", Name = "Sniff Sniff" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_M", Name = "Charm Pattern" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_M", Name = "Witch & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_M", Name = "Pumpkin Bug" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_M", Name = "Sinner" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_M", Name = "Gray Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_M", Name = "Hood Heart" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_M", Name = "Los Santos Tag" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_M", Name = "Blessed Boombox" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_M", Name = "Chamberlain Hills" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_M", Name = "Smoking Barrels" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_M", Name = "Dollar Guns Crossed" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_M", Name = "Skull Surfer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_M", Name = "Speaker Tower" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_M", Name = "Record Shot" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_M", Name = "Record Head" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_M", Name = "Tropical Sorcerer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_M", Name = "Rose Panther" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_M", Name = "Paradise Ukulele" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_M", Name = "Paradise Nap" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_M", Name = "Wild Dancers" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_M", Name = "Space Rangers" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_M", Name = "Robot Bubblegum" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_M", Name = "LS Shield" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_M", Name = "Howitzer" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_M", Name = "Bananas Gone Bad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_M", Name = "Epsilon" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_M", Name = "Mount Chiliad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_M", Name = "Bigfoot" },//

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_M", Name = "Play Your Ace" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_M", Name = "The Table" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_M", Name = "Show Your Hand" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_M", Name = "Roll the Dice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_M", Name = "The Jolly Joker" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_M", Name = "Life's a Gamble" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_M", Name = "Photo Finish" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_M", Name = "Till Death Do Us Part" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_M", Name = "Snake Eyes" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_M", Name = "777" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_M", Name = "Wheel of Suits" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_M", Name = "Jackpot" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_M", Name = "Molon Labe" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_M", Name = "Dragon Slayer" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_M", Name = "Spartan and Horse" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_M", Name = "Spartan and Lion" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_M", Name = "Odin and Raven" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_M", Name = "Samurai Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_M", Name = "Weathered Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_M", Name = "Spartan Shield" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_M", Name = "Norse Rune" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_M", Name = "Ghost Dragon" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_M", Name = "Kabuto" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_M", Name = "Claimed By The Beast" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_M", Name = "Pirate Captain" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_M", Name = "X Marks The Spot" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_M", Name = "Finders Keepers" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_M", Name = "Framed Tall Ship" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_M", Name = "Skull Compass" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_M", Name = "Torn Wings" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_M", Name = "Tall Ship Conflict" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_M", Name = "Never Surrender" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_M", Name = "Give Nothing Back" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_M", Name = "Eagle Eyes" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_M", Name = "Parachute Belle" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_M", Name = "Balloon Pioneer" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_M", Name = "Winged Bombshell" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_M", Name = "Pilot Skull" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_M", Name = "Explosive Heart" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_M", Name = "Pistol Wings" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_M", Name = "Dual Wield Skull" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_M", Name = "Backstabber" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_M", Name = "Wolf Insignia" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_M", Name = "Butterfly Knife" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_M", Name = "Crossed Weapons" },//
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_M", Name = "Bullet Proof" },//

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_M", Name = "Talk Shit Get Hit" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_M", Name = "Take the Wheel" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_M", Name = "Serpents of Destruction" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_M", Name = "Tuned to Death" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_M", Name = "Power Plant" },//
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_M", Name = "Block Back" },//

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_M", Name = "Ride Forever" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_M", Name = "Brothers For Life" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_M", Name = "Flaming Reaper" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_M", Name = "Clawed Beast" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_M", Name = "R.I.P. My Brothers" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_M", Name = "Freedom Wheels" },//
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_M", Name = "Chopper Freedom" },//

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_M", Name = "Racing Doll" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_M", Name = "Full Throttle" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_M", Name = "Brapp" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_M", Name = "Monkey Chopper" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_M", Name = "Big Grills" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_M", Name = "Feather Road Kill" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_M", Name = "Man's Ruin" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_M", Name = "Majestic Finish" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_M", Name = "Winged Wheel" },//
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_M", Name = "Road Kill" },//

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_M", Name = "Reign Over" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_M", Name = "Dead Pretty" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_M", Name = "Love the Game" },//
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_M", Name = "SA Assault" },//

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_M", Name = "Sad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_M", Name = "Love is Blind" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_M", Name = "Bad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_M", Name = "Amazon" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_M", Name = "Geometric Design" },//   
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_M", Name = "Cloaked Angel" },//  
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_024_M", Name = "Feather Mural" },//    
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_006_M", Name = "Adorned Wolf" },//   

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_015", Name = "Japanese Warrior" },//  
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_011", Name = "Roaring Tiger" },//      
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_006", Name = "Carp Shaded" },//   
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_005", Name = "Carp Outline" },//   

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_046", Name = "Triangles" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_041", Name = "Tooth" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_032", Name = "Paper Plane" },// 
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_031", Name = "Skateboard" },//   
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_030", Name = "Shark Fin" },//
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_025", Name = "Watch Your Step" },//  
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_024", Name = "Pyamid" },//   
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_012", Name = "Antlers" },//  
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_011", Name = "Infinity" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_000", Name = "Crossed Arrows" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Back_000", Name = "Makin' Paper" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Back_000", Name = "Ship Arms" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_045", Name = "Skulls and Rose" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_030", Name = "Lucky Celtic Dogs" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_020", Name = "Dragon" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_019", Name = "The Wages of Sin" },//Survival Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_016", Name = "Evil Clown" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_013", Name = "Eagle and Serpent" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_011", Name = "LS Script" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_009", Name = "Skull on the Cross" },//

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_019", Name = "Clown Dual Wield Dollars" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_018", Name = "Clown Dual Wield" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_017", Name = "Clown and Gun" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_016", Name = "Clown" },//
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_014", Name = "Trust No One" },//Car Bomb Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_008", Name = "Los Santos Customs" },//Mod a Car Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_005", Name = "Angel" },//Win Every Game Mode Award
          //Unknowen
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_046", Name = "Zip?" },//Zip???
            new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_M", Name = "Unknowen" }//
        };
        private static readonly List<Tattoo> maleTats02 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_M", Name = "Bullet Mouth" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_M", Name = "Smoking Barrel" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_M", Name = "Carved Pumpkin" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_M", Name = "Branched Werewolf" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_M", Name = "Winged Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_M", Name = "Shrieking Dragon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_M", Name = "Swords & City" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_M", Name = "All From The Same Tree" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_M", Name = "King of the Jungle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_M", Name = "Night Owl" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_M", Name = "Techno Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_M", Name = "Paradise Sirens" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_M", Name = "LS Panic" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_M", Name = "LS City" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_M", Name = "Dignity" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_M", Name = "Davis" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_M", Name = "Blood Money" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_M", Name = "Royal Flush" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_M", Name = "In the Pocket" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_M", Name = "Spartan Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_M", Name = "Medusa's Gaze" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_M", Name = "Strike Force" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_M", Name = "Native Warrior" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_M", Name = "Thor - Goblin" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_M", Name = "Dead Tales" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_M", Name = "Lost At Sea" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_M", Name = "No Honor" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_M", Name = "Bless The Dead" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_M", Name = "Turbulence" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_M", Name = "Micro SMG Chain" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_M", Name = "Crowned Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_M", Name = "Dog Tags" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_M", Name = "Dollar Daggers" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_M", Name = "We Are The Mods!" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_M", Name = "Faggio" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_M", Name = "Reaper Vulture" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_M", Name = "Unforgiven" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_M", Name = "No Regrets" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_M", Name = "Brotherhood of Bikes" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_M", Name = "Western Eagle" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_M", Name = "Bone Wrench" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_M", Name = "American Dream" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_M", Name = "Western MC" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_M", Name = "Gruesome Talons" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_M", Name = "Skeletal Chopper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_M", Name = "Demon Crossbones" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_M", Name = "Made In America" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_M", Name = "Both Barrels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_M", Name = "Demon Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_M", Name = "Ram Skull" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_M", Name = "Sugar Skull Trucker" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_M", Name = "Punk Road Hog" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_M", Name = "Engine Heart" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_M", Name = "Vintage Bully" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_M", Name = "Wheels of Death" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_M", Name = "Death Behind" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_M", Name = "Royal Kiss" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_M", Name = "Royal Takeover" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_M", Name = "Love Gamble" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_M", Name = "Holy Mary" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_M", Name = "King Fight" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_M", Name = "Cobra Dawn" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_M", Name = "Reaper Sway" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_M", Name = "Geometric Galaxy" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_M", Name = "The Howler" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_M", Name = "Smoking Sisters" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_M", Name = "Ancient Queen" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_M", Name = "Flying Eye" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_M", Name = "Eye of the Griffin" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_019", Name = "Royal Dagger Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_018", Name = "Royal Dagger Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_017", Name = "Loose Lips Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_016", Name = "Loose Lips Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_009", Name = "Time To Die" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_047", Name = "Cassette" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_033", Name = "Stag" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_013", Name = "Boombox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_002", Name = "Chemistry" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_001", Name = "$$$" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_000", Name = "Rich" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_001", Name = "Tribal Shark" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_000", Name = "Tribal Hammerhead" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_044", Name = "Stone Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_034", Name = "Flaming Shamrock" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_025", Name = "LS Bold" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_024", Name = "Flaming Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_010", Name = "LS Flames" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_013", Name = "Seven Deadly Sins" },//Kill 1000 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_012", Name = "Embellished Scroll" },//Kill 500 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_011", Name = "Blank Scroll" },////Kill 100 Players Award?
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_003", Name = "Blackjack" }
        };
        private static readonly List<Tattoo> maleTats03 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_M", Name = "Concealed" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_M", Name = "Cursed Saki" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_M", Name = "Smouldering Bat & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_M", Name = "Blaine County" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_M", Name = "Angry Possum" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_M", Name = "Floral Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_M", Name = "Beatbox Silhouette" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_M", Name = "Davis Flames" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_M", Name = "Radio Tape" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_M", Name = "Skeleton Breeze" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_M", Name = "LadyBug" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_M", Name = "Fatal Incursion" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_M", Name = "Gambling Royalty" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_M", Name = "Cash Mouth" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_M", Name = "Rose and Aces" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_M", Name = "Skull of Suits" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_M", Name = "Spartan Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_M", Name = "Jolly Roger" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_M", Name = "See You In Hell" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_M", Name = "Dead Lies" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_M", Name = "Bombs Away" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_M", Name = "Win Some Lose Some" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_M", Name = "Cash Money" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_M", Name = "Biker Mount" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_M", Name = "Gas Guzzler" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_M", Name = "Gear Head" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_M", Name = "Skull Of Taurus" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_M", Name = "Web Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_M", Name = "Bat Cat of Spades" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_M", Name = "Punk Biker" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_M", Name = "Two Face" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_M", Name = "Lady Liberty" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_M", Name = "Gun Mic" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_M", Name = "Abstract Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_028", Name = "Executioner" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_013", Name = "Lizard" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_035", Name = "Sewn Heart" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_029", Name = "Sad" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_006", Name = "Feather Birds" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Stomach_000", Name = "Refined Hustler" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_001", Name = "Wheel" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_000", Name = "Swordfish" },


            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_036", Name = "Way of the Gun" },//500 Pistol kills Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_029", Name = "Trinity Knot" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_012", Name = "Los Santos Bills" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_004", Name = "Faith" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_004", Name = "Hustler" },//Make 50000 from betting Award
        };
        private static readonly List<Tattoo> maleTats04 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_M", Name = "Live Fast Mono" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_M", Name = "Live Fast Color" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_M", Name = "Branched Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_M", Name = "Scythed Corpse" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_M", Name = "Scythed Corpse & Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_M", Name = "Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_M", Name = "Pierced Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_M", Name = "Lip Drip" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_M", Name = "Skin Mask" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_M", Name = "Webbed Scythe" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_M", Name = "Oni Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_M", Name = "Bat Wings" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_M", Name = "Bright Diamond" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_M", Name = "Hustle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_M", Name = "Black Widow" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_M", Name = "Clubs" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_M", Name = "Diamonds" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_M", Name = "Hearts" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_M", Name = "Thong's Sword" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_M", Name = "Wanted" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_M", Name = "UFO" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_M", Name = "Teddy Bear" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_M", Name = "Stitches" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_M", Name = "Space Monkey" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_M", Name = "Sleepy" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_M", Name = "On/Off" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_M", Name = "LS Wings" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_M", Name = "LS Star" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_M", Name = "Razor Pop" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_M", Name = "Lipstick Kiss" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_M", Name = "Green Leaf" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_M", Name = "Knifed" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_M", Name = "Ice Cream" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_M", Name = "Two Horns" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_M", Name = "Crowned" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_M", Name = "Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_M", Name = "Bandage" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_M", Name = "Assault Rifle" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_M", Name = "Animal" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_M", Name = "Ace of Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_M", Name = "Five Stars" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_M", Name = "Thief" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_M", Name = "Sinner" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_M", Name = "Lock and Load" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_M", Name = "Western Stylized" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_M", Name = "FTW" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_M", Name = "Morbid Arachnid" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_M", Name = "Flaming Quad" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_M", Name = "Bat Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_M", Name = "Toxic Spider" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_M", Name = "Scorpion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_M", Name = "Stunt Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_029", Name = "Beautiful Death" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_025", Name = "Snake Head Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_024", Name = "Snake Head Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_007", Name = "Los Muertos" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_021", Name = "Geo Fox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_005", Name = "Beautiful Eye" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_003", Name = "$100" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_002", Name = "Script Dollar Sign" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_001", Name = "Bold Dollar Sign" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_000", Name = "Cash is King" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_002", Name = "Shark" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_001", Name = "Surfs Up" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_000", Name = "Little Fish" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_001", Name = "Surf LS" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_000", Name = "Pirate Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_000", Name = "Skull" }
        };
        private static readonly List<Tattoo> maleTats05 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_M", Name = "Bigness Chimp" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_M", Name = "Up-n-Atomizer Design" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_M", Name = "Rocket Launcher Girl" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_M", Name = "Laser Eyes Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_M", Name = "Classic Vampire" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_M", Name = "Demon Drummer" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_M", Name = "Skeleton Shot" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_M", Name = "Music Is The Remedy" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_M", Name = "Serpent Mic" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_M", Name = "Weed Knuckles" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_M", Name = "Scratch Panther" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_M", Name = "Mighty Thog" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_M", Name = "Tiger Heart" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_M", Name = "Banknote Rose" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_M", Name = "Can't Win Them All" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_M", Name = "Vice" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_M", Name = "Get Lucky" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_M", Name = "Suits" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_M", Name = "Cerberus" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_M", Name = "Winged Serpent" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_M", Name = "Katana" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_M", Name = "Spartan Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_M", Name = "Tiger and Mask" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_M", Name = "Viking Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_M", Name = "Mermaid's Curse" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_M", Name = "Horrors Of The Deep" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_M", Name = "Honor" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_M", Name = "Toxic Trails" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_M", Name = "Serpent Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_M", Name = "Praying Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_M", Name = "Blood Money" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_M", Name = "Spiked Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_M", Name = "Bandolier" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_M", Name = "Sidearm" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_M", Name = "Scarlett" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_M", Name = "Piston Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_M", Name = "Poison Scorpion" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_M", Name = "Muffler Helmet" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_M", Name = "Ride Hard Die Fast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_M", Name = "Chain Fist" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_M", Name = "Good Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_M", Name = "Live to Ride" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_M", Name = "Cranial Rose" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_M", Name = "Macabre Tree" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_M", Name = "Urban Stunter" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_M", Name = "Engine Arm" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_M", Name = "Kaboom" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_M", Name = "Stuntman's End" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_M", Name = "Tanked" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_M", Name = "Piston Head" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_M", Name = "Moonlight Ride" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_M", Name = "Big Cat" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_M", Name = "8 Eyed Skull" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_M", Name = "My Crazy Life" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_M", Name = "Skeleton Party" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_M", Name = "Love Hustle" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_M", Name = "City Sorrow" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_M", Name = "Los Santos Life" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_M", Name = "No Evil" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_M", Name = "Python Skull" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_M", Name = "Divine Goddess" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_M", Name = "Egyptian Mural" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_M", Name = "Fatal Dagger" },


            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_M", Name = "Gabriel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_M", Name = "Archangel and Mary" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_M", Name = "Floral Symmetry" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_021", Name = "Time's Up Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_020", Name = "Time's Up Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_012", Name = "8 Ball Skull" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_010", Name = "Electric Snake" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_000", Name = "Skull Rider" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_048", Name = "Peace" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_043", Name = "Triangle White" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_039", Name = "Sleeve" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_037", Name = "Sunrise" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_034", Name = "Stop" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_028", Name = "Thorny Rose" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_027", Name = "Padlock" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_026", Name = "Pizza" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_016", Name = "Lightning Bolt" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_015", Name = "Mustache" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_007", Name = "Bricks" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_003", Name = "Diamond Sparkle" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_001", Name = "All-Seeing Eye" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_000", Name = "$100 Bill" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_000", Name = "Tiki Tower" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_001", Name = "Mermaid L.S." },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_041", Name = "Dope Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_031", Name = "Lady M" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_015", Name = "Zodiac Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_006", Name = "Oriental Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_005", Name = "Serpents" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_015", Name = "Racing Brunette" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_007", Name = "Racing Blonde" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_001", Name = "Burning Heart" },//50 Death Match Award
                                                                                                                                          //not on list
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_M", Name = "Geometric Design" }
        };
        private static readonly List<Tattoo> maleTats06 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_M", Name = "Nothing Mini About It" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_M", Name = "Snake Revolver" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_M", Name = "Weapon Sleeve" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_M", Name = "Centipede" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_M", Name = "Fleshy Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_M", Name = "Armored Arm" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_M", Name = "Demon Smile" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_M", Name = "Angel & Devil" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_M", Name = "Death Is Certain" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_M", Name = "Hood Skeleton" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_M", Name = "Peacock" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_M", Name = "Ballas 4 Life" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_M", Name = "Ascension" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_M", Name = "Zombie Rhymes" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_M", Name = "Dog Fist" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_M", Name = "K.U.L.T.99.1 FM" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_M", Name = "Octopus Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_M", Name = "Shark Water" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_M", Name = "Still Slipping" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_M", Name = "Soulwax" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_M", Name = "Smiley Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_M", Name = "Skeleton DJ" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_M", Name = "Music Locker" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_M", Name = "LSUR" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_M", Name = "Lighthouse" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_M", Name = "Jellyfish Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_M", Name = "Tropical Dude" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_M", Name = "Headphone Splat" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_M", Name = "LS Monogram" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_M", Name = "Skull and Aces" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_M", Name = "Queen of Roses" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_M", Name = "The Gambler's Life" },
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_M", Name = "Lady Luck" },

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_M", Name = "Spartan Mural" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_M", Name = "Samurai Tallship" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_M", Name = "Muscle Tear" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_M", Name = "Feather Sleeve" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_M", Name = "Celtic Band" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_M", Name = "Tiger Headdress" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_M", Name = "Medusa" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_M", Name = "Stylized Kraken" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_M", Name = "Mutiny" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_M", Name = "Crackshot" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_M", Name = "Combat Reaper" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_M", Name = "Have a Nice Day" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_M", Name = "Grenade" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_M", Name = "Drive Forever" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_M", Name = "Engulfed Block" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_M", Name = "Dialed In" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_M", Name = "Mechanical Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_M", Name = "Mum" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_M", Name = "These Colors Don't Run" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_M", Name = "Snake Bike" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_M", Name = "Skull Chain" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_M", Name = "Grim Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_M", Name = "Eagle Emblem" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_M", Name = "Lady Mortality" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_M", Name = "Swooping Eagle" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_M", Name = "Seductive Mechanic" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_M", Name = "One Down Five Up" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_M", Name = "Biker Stallion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_M", Name = "Coffin Racer" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_M", Name = "Grave Vulture" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_M", Name = "Arachnid of Death" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_M", Name = "Poison Wrench" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_M", Name = "Black Tears" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_M", Name = "Loving Los Muertos" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_M", Name = "Lady Vamp" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_M", Name = "Seductress" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_M", Name = "Floral Print" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_M", Name = "Heavenly Deity" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_M", Name = "Intrometric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_M", Name = "Geisha Bloom" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_M", Name = "Mermaid Harpist" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_M", Name = "Floral Raven" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_027", Name = "Fuck Luck Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_026", Name = "Fuck Luck Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_023", Name = "You're Next Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_022", Name = "You're Next Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_008", Name = "Death Before Dishonor" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_004", Name = "Snake Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_003", Name = "Snake Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_045", Name = "Mesh Band" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_044", Name = "Triangle Black" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_036", Name = "Shapes" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_023", Name = "Smiley" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_022", Name = "Pencil" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_020", Name = "Geo Pattern" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_018", Name = "Origami" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_017", Name = "Eye Triangle" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_014", Name = "Spray Can" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_010", Name = "Horseshoe" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_008", Name = "Cube" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_004", Name = "Bone" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_001", Name = "Single Arrow" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_001", Name = "Green" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_000", Name = "Dollar Skull" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_001", Name = "Vespucci Beauty" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_000", Name = "Tribal Sun" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_047", Name = "Lion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_038", Name = "Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_028", Name = "Mermaid" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_027", Name = "Virgin Mary" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_018", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_014", Name = "Flower Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_003", Name = "Dragons and Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_001", Name = "Dragons" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_000", Name = "Brotherhood" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_010", Name = "Ride or Die" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_002", Name = "Grim Reaper Smoking Gun" },
                    //Not In List
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_M", Name = "Geometric Design" }
        };
        private static readonly List<Tattoo> maleTats07 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_M", Name = "Cobra Biker" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_M", Name = "Minimal SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_M", Name = "Minimal Advanced Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_M", Name = "Minimal Sniper Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_M", Name = "Many-eyed Goat" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_M", Name = "Mobster Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_M", Name = "Wounded Head" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_M", Name = "Stabbed Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_M", Name = "Tiger Blade" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_M", Name = "LS Smoking Cartridges" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_M", Name = "Trust" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_M", Name = "Soundwaves" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_M", Name = "Skull Waters" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_M", Name = "Glow Princess" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_M", Name = "Pineapple Skull" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_M", Name = "Tropical Serpent" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_M", Name = "Love Fist" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_M", Name = "8-Ball Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_M", Name = "One-armed Bandit" },//

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_M", Name = "Rose Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_M", Name = "Death Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_M", Name = "Stylized Tiger" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_M", Name = "Patriot Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_M", Name = "Laughing Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_M", Name = "Bone Cruiser" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_M", Name = "Ride Free" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_M", Name = "Scorched Soul" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_M", Name = "Engulfed Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_M", Name = "Bad Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_M", Name = "Ride or Die" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_M", Name = "Rose Tribute" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_M", Name = "Stunt Jesus" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_M", Name = "Quad Goblin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_M", Name = "Golden Cobra" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_M", Name = "Dirt Track Hero" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_M", Name = "Dagger Devil" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_M", Name = "Death Us Do Part" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_M", Name = "Presidents" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_M", Name = "LS Serpent" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_M", Name = "Cross of Roses" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_M", Name = "Serpent of Death" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_002", Name = "Spider Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_001", Name = "Spider Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_040", Name = "Black Anchor" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_019", Name = "Charm" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_009", Name = "Squares" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Lleg_000", Name = "Tribal Star" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_032", Name = "Faith" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_037", Name = "Grim Reaper" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_035", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_033", Name = "Chinese Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_026", Name = "Smoking Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_023", Name = "Hottie" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_021", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_008", Name = "Dragon Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_002", Name = "Melting Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_009", Name = "Dragon and Dagger" },
        };
        private static readonly List<Tattoo> maleTats08 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_M", Name = "Skull Grenade" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_M", Name = "Three-eyed Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_M", Name = "Smoldering Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_M", Name = "Gold Gun" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_M", Name = "Blue Serpent" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_M", Name = "Night Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_M", Name = "Bandana Knife" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_M", Name = "Graffiti Skull" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_M", Name = "Skullphones" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_M", Name = "Kifflom" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_M", Name = "Cash is King" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_M", Name = "Homeward Bound" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_M", Name = "Pistol Ace" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_M", Name = "Restless Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_M", Name = "Combat Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_M", Name = "STFU" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_M", Name = "American Made" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_M", Name = "Dusk Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_M", Name = "Western Insignia" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_M", Name = "Dragon's Fury" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_M", Name = "Brake Knife" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_M", Name = "Severed Hand" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_M", Name = "Wheelie Mouse" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_M", Name = "Speed Freak" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_M", Name = "Piston Angel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_M", Name = "Praying Gloves" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_M", Name = "Demon Spark Plug" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_M", Name = "San Andreas Prayer" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_M", Name = "Dance of Hearts" },
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_M", Name = "Ink Me" },

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_M", Name = "Starmetric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_M", Name = "Elaborate Los Muertos" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_014", Name = "Floral Dagger" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_042", Name = "Sparkplug" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_038", Name = "Grub" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Rleg_000", Name = "Tribal Tiki Tower" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_043", Name = "Indian Ram" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_042", Name = "Flaming Scorpion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_040", Name = "Flaming Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_039", Name = "Broken Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_022", Name = "Fiery Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_017", Name = "Tribal" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_007", Name = "The Warrior" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_006", Name = "Skull and Sword" }
        };

        private static readonly List<Tattoo> femaleTats01 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_F", Name = "Painted Micro SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_F", Name = "Weapon King" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_F", Name = "Sniff Sniff" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_F", Name = "Charm Pattern" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_F", Name = "Witch & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_F", Name = "Pumpkin Bug" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_F", Name = "Sinner" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_F", Name = "Gray Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_F", Name = "Hood Heart" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_F", Name = "Los Santos Tag" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_F", Name = "Blessed Boombox" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_F", Name = "Chamberlain Hills" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_F", Name = "Smoking Barrels" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_F", Name = "Dollar Guns Crossed" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_F", Name = "Skull Surfer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_F", Name = "Speaker Tower" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_F", Name = "Record Shot" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_F", Name = "Record Head" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_F", Name = "Tropical Sorcerer" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_F", Name = "Rose Panther" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_F", Name = "Paradise Ukulele" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_F", Name = "Paradise Nap" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_F", Name = "Wild Dancers" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_F", Name = "Space Rangers" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_F", Name = "Robot Bubblegum" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_F", Name = "LS Shield" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_F", Name = "Howitzer" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_F", Name = "Bananas Gone Bad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_F", Name = "Epsilon" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_F", Name = "Mount Chiliad" },//
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_F", Name = "Bigfoot" },//

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_F", Name = "Play Your Ace" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_F", Name = "The Table" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_F", Name = "Show Your Hand" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_F", Name = "Roll the Dice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_F", Name = "The Jolly Joker" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_F", Name = "Life's a Gamble" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_F", Name = "Photo Finish" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_F", Name = "Till Death Do Us Part" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_F", Name = "Snake Eyes" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_F", Name = "777" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_F", Name = "Wheel of Suits" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_F", Name = "Jackpot" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_F", Name = "Molon Labe" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_F", Name = "Dragon Slayer" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_F", Name = "Spartan and Horse" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_F", Name = "Spartan and Lion" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_F", Name = "Odin and Raven" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_F", Name = "Samurai Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_F", Name = "Weathered Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_F", Name = "Spartan Shield" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_F", Name = "Norse Rune" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_F", Name = "Ghost Dragon" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_F", Name = "Kabuto" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_F", Name = "Claimed By The Beast" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_F", Name = "Pirate Captain" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_F", Name = "X Marks The Spot" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_F", Name = "Finders Keepers" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_F", Name = "Framed Tall Ship" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_F", Name = "Skull Compass" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_F", Name = "Torn Wings" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_F", Name = "Tall Ship Conflict" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_F", Name = "Never Surrender" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_F", Name = "Give Nothing Back" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_F", Name = "Eagle Eyes" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_F", Name = "Parachute Belle" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_F", Name = "Balloon Pioneer" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_F", Name = "Winged Bombshell" },
            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_F", Name = "Pilot Skull" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_F", Name = "Explosive Heart" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_F", Name = "Pistol Wings" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_F", Name = "Dual Wield Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_F", Name = "Backstabber" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_F", Name = "Wolf Insignia" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_F", Name = "Butterfly Knife" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_F", Name = "Crossed Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_F", Name = "Bullet Proof" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_F", Name = "Talk Shit Get Hit" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_F", Name = "Take the Wheel" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_F", Name = "Serpents of Destruction" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_F", Name = "Tuned to Death" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_F", Name = "Power Plant" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_F", Name = "Block Back" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_F", Name = "Ride Forever" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_F", Name = "Brothers For Life" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_F", Name = "Flaming Reaper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_F", Name = "Clawed Beast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_F", Name = "R.I.P. My Brothers" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_F", Name = "Freedom Wheels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_F", Name = "Chopper Freedom" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_F", Name = "Racing Doll" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_F", Name = "Full Throttle" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_F", Name = "Brapp" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_F", Name = "Monkey Chopper" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_F", Name = "Big Grills" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_F", Name = "Feather Road Kill" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_F", Name = "Man's Ruin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_F", Name = "Majestic Finish" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_F", Name = "Winged Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_F", Name = "Road Kill" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_F", Name = "Reign Over" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_F", Name = "Dead Pretty" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_F", Name = "Love the Game" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_F", Name = "SA Assault" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_F", Name = "Sad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_F", Name = "Love is Blind" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_F", Name = "Bad Angel" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_F", Name = "Amazon" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_F", Name = "Geometric Design" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_F", Name = "Cloaked Angel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_024_F", Name = "Feather Mural" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_006_F", Name = "Adorned Wolf" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_015", Name = "Japanese Warrior" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_011", Name = "Roaring Tiger" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_006", Name = "Carp Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_005", Name = "Carp Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_046", Name = "Triangles" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_041", Name = "Tooth" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_032", Name = "Paper Plane" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_031", Name = "Skateboard" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_030", Name = "Shark Fin" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_025", Name = "Watch Your Step" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_024", Name = "Pyamid" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_012", Name = "Antlers" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_011", Name = "Infinity" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_000", Name = "Crossed Arrows" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_001", Name = "Gold Digger" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_000", Name = "Respect" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_000", Name = "Sea Horses" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_002", Name = "Shrimp" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_001", Name = "Catfish" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_000", Name = "Rock Solid" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_001", Name = "Hibiscus Flower Duo" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_045", Name = "Skulls and Rose" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_030", Name = "Lucky Celtic Dogs" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_020", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_019", Name = "The Wages of Sin" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_016", Name = "Evil Clown" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_013", Name = "Eagle and Serpent" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_011", Name = "LS Script" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_009", Name = "Skull on the Cross" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_019", Name = "Clown Dual Wield Dollars" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_018", Name = "Clown Dual Wield" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_017", Name = "Clown and Gun" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_016", Name = "Clown" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_014", Name = "Trust No One" },//Car Bomb Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_008", Name = "Los Santos Customs" },//Mod a Car Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_005", Name = "Angel" },//Win Every Game Mode Award
                                                                                                                              //Not In List
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_046", Name = "Zip?" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" },
            new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_F", Name = "???" }
        };
        private static readonly List<Tattoo> femaleTats02 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_F", Name = "Bullet Mouth" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_F", Name = "Smoking Barrel" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_F", Name = "Carved Pumpkin" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_F", Name = "Branched Werewolf" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_F", Name = "Winged Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_F", Name = "Shrieking Dragon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_F", Name = "Swords & City" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_F", Name = "All From The Same Tree" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_F", Name = "King of the Jungle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_F", Name = "Night Owl" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_F", Name = "Techno Glitch" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_F", Name = "Paradise Sirens" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_F", Name = "LS Panic" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_F", Name = "LS City" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_F", Name = "Dignity" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_F", Name = "Davis" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_F", Name = "Blood Money" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_F", Name = "Royal Flush" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_F", Name = "In the Pocket" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_F", Name = "Spartan Skull" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_F", Name = "Medusa's Gaze" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_F", Name = "Strike Force" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_F", Name = "Native Warrior" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_F", Name = "Thor - Goblin" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_F", Name = "Dead Tales" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_F", Name = "Lost At Sea" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_F", Name = "No Honor" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_F", Name = "Bless The Dead" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_F", Name = "Turbulence" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_F", Name = "Micro SMG Chain" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_F", Name = "Crowned Weapons" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_F", Name = "Dog Tags" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_F", Name = "Dollar Daggers" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_F", Name = "We Are The Mods!" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_F", Name = "Faggio" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_F", Name = "Reaper Vulture" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_F", Name = "Unforgiven" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_F", Name = "No Regrets" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_F", Name = "Brotherhood of Bikes" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_F", Name = "Western Eagle" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_F", Name = "Bone Wrench" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_F", Name = "American Dream" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_F", Name = "Western MC" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_F", Name = "Gruesome Talons" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_F", Name = "Skeletal Chopper" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_F", Name = "Demon Crossbones" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_F", Name = "Made In America" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_F", Name = "Both Barrels" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_F", Name = "Demon Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_F", Name = "Ram Skull" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_F", Name = "Sugar Skull Trucker" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_F", Name = "Punk Road Hog" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_F", Name = "Engine Heart" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_F", Name = "Vintage Bully" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_F", Name = "Wheels of Death" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_F", Name = "Death Behind" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_F", Name = "Royal Kiss" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_F", Name = "Royal Takeover" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_F", Name = "Love Gamble" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_F", Name = "Holy Mary" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_F", Name = "King Fight" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_F", Name = "Cobra Dawn" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_F", Name = "Reaper Sway" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_F", Name = "Geometric Galaxy" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_F", Name = "The Howler" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_F", Name = "Smoking Sisters" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_F", Name = "Ancient Queen" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_F", Name = "Flying Eye" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_F", Name = "Eye of the Griffin" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_019", Name = "Royal Dagger Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_018", Name = "Royal Dagger Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_017", Name = "Loose Lips Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_016", Name = "Loose Lips Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_009", Name = "Time To Die" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_047", Name = "Cassette" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_033", Name = "Stag" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_013", Name = "Boombox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_002", Name = "Chemistry" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_002", Name = "Love Money" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_001", Name = "Makin' Money" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_000", Name = "High Roller" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_001", Name = "Anchor" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_000", Name = "Anchor" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_002", Name = "Los Santos Wreath" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_044", Name = "Stone Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_034", Name = "Flaming Shamrock" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_025", Name = "LS Bold" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_024", Name = "Flaming Cross" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_010", Name = "LS Flames" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_013", Name = "Seven Deadly Sins" },//Kill 1000 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_012", Name = "Embellished Scroll" },//Kill 500 Players Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_011", Name = "Blank Scroll" },////Kill 100 Players Award?
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_003", Name = "Blackjack" }
        };
        private static readonly List<Tattoo> femaleTats03 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_F", Name = "Concealed" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_F", Name = "Cursed Saki" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_F", Name = "Smouldering Bat & Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_F", Name = "Blaine County" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_F", Name = "Angry Possum" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_F", Name = "Floral Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_F", Name = "Beatbox Silhouette" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_F", Name = "Davis Flames" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_F", Name = "Radio Tape" },//
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_F", Name = "Skeleton Breeze" },//

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_F", Name = "LadyBug" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_F", Name = "Fatal Incursion" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_F", Name = "Gambling Royalty" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_F", Name = "Cash Mouth" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_F", Name = "Rose and Aces" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_F", Name = "Skull of Suits" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_F", Name = "Spartan Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_F", Name = "Jolly Roger" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_F", Name = "See You In Hell" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_F", Name = "Dead Lies" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_F", Name = "Bombs Away" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_F", Name = "Win Some Lose Some" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_F", Name = "Cash Money" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_F", Name = "Biker Mount" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_F", Name = "Gas Guzzler" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_F", Name = "Gear Head" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_F", Name = "Skull Of Taurus" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_F", Name = "Web Rider" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_F", Name = "Bat Cat of Spades" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_F", Name = "Punk Biker" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_F", Name = "Two Face" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_F", Name = "Lady Liberty" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_F", Name = "Gun Mic" },//

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_F", Name = "Abstract Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_028", Name = "Executioner" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_013", Name = "Lizard" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_035", Name = "Sewn Heart" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_029", Name = "Sad" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_002", Name = "Money Bag" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_001", Name = "Santo Capra Logo" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_000", Name = "Diamond Back" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_000", Name = "Swallow" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_002", Name = "Dolphin" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_001", Name = "Hibiscus Flower" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RSide_000", Name = "Love Dagger" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_036", Name = "Way of the Gun" },//500 Pistol kills Award
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_029", Name = "Trinity Knot" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_012", Name = "Los Santos Bills" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_004", Name = "Faith" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_004", Name = "Hustler" }
        };
        private static readonly List<Tattoo> femaleTats04 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_F", Name = "Live Fast Mono" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_F", Name = "Live Fast Color" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_F", Name = "Branched Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_F", Name = "Scythed Corpse" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_F", Name = "Scythed Corpse & Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_F", Name = "Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_F", Name = "Pierced Third Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_F", Name = "Lip Drip" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_F", Name = "Skin Mask" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_F", Name = "Webbed Scythe" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_F", Name = "Oni Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_F", Name = "Bat Wings" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_F", Name = "Bright Diamond" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_F", Name = "Hustle" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_F", Name = "Black Widow" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_F", Name = "Clubs" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_F", Name = "Diamonds" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_F", Name = "Hearts" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_F", Name = "Thong's Sword" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_F", Name = "Wanted" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_F", Name = "UFO" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_F", Name = "Teddy Bear" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_F", Name = "Stitches" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_F", Name = "Space Monkey" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_F", Name = "Sleepy" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_F", Name = "On/Off" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_F", Name = "LS Wings" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_F", Name = "LS Star" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_F", Name = "Razor Pop" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_F", Name = "Lipstick Kiss" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_F", Name = "Green Leaf" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_F", Name = "Knifed" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_F", Name = "Ice Cream" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_F", Name = "Two Horns" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_F", Name = "Crowned" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_F", Name = "Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_F", Name = "Bandage" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_F", Name = "Assault Rifle" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_F", Name = "Animal" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_F", Name = "Ace of Spades" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_F", Name = "Five Stars" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_F", Name = "Thief" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_F", Name = "Sinner" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_F", Name = "Lock and Load" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_F", Name = "Western Stylized" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_F", Name = "FTW" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_F", Name = "Morbid Arachnid" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_F", Name = "Flaming Quad" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_F", Name = "Bat Wheel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_F", Name = "Toxic Spider" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_F", Name = "Scorpion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_F", Name = "Stunt Skull" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_029", Name = "Beautiful Death" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_025", Name = "Snake Head Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_024", Name = "Snake Head Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_007", Name = "Los Muertos" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_021", Name = "Geo Fox" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_005", Name = "Beautiful Eye" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_001", Name = "Money Rose" },
            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_000", Name = "Val-de-Grace Logo" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Tribal Butterfly" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Little Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_000", Name = "Skull" }
        };
        private static readonly List<Tattoo> femaleTats05 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_F", Name = "Bigness Chimp" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_F", Name = "Up-n-Atomizer Design" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_F", Name = "Rocket Launcher Girl" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_F", Name = "Laser Eyes Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_F", Name = "Classic Vampire" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_F", Name = "Demon Drummer" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_F", Name = "Skeleton Shot" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_F", Name = "Music Is The Remedy" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_F", Name = "Serpent Mic" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_F", Name = "Weed Knuckles" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_F", Name = "Scratch Panther" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_F", Name = "Mighty Thog" },
            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_F", Name = "Tiger Heart" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_F", Name = "Banknote Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_F", Name = "Can't Win Them All" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_F", Name = "Vice" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_F", Name = "Get Lucky" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_F", Name = "Suits" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_F", Name = "Cerberus" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_F", Name = "Winged Serpent" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_F", Name = "Katana" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_F", Name = "Spartan Combat" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_F", Name = "Tiger and Mask" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_F", Name = "Viking Warrior" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_F", Name = "Mermaid's Curse" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_F", Name = "Horrors Of The Deep" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_F", Name = "Honor" },

            new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_F", Name = "Toxic Trails" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_F", Name = "Serpent Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_F", Name = "Praying Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_F", Name = "Blood Money" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_F", Name = "Spiked Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_F", Name = "Bandolier" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_F", Name = "Sidearm" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_F", Name = "Scarlett" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_F", Name = "Piston Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_F", Name = "Poison Scorpion" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_F", Name = "Muffler Helmet" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_F", Name = "Ride Hard Die Fast" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_F", Name = "Chain Fist" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_F", Name = "Good Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_F", Name = "Live to Ride" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_F", Name = "Cranial Rose" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_F", Name = "Macabre Tree" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_F", Name = "Urban Stunter" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_F", Name = "Engine Arm" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_F", Name = "Kaboom" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_F", Name = "Stuntman's End" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_F", Name = "Tanked" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_F", Name = "Piston Head" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_F", Name = "Moonlight Ride" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_F", Name = "Big Cat" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_F", Name = "8 Eyed Skull" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_F", Name = "My Crazy Life" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_F", Name = "Skeleton Party" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_F", Name = "Love Hustle" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_F", Name = "City Sorrow" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_F", Name = "Los Santos Life" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_F", Name = "No Evil" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_F", Name = "Python Skull" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_F", Name = "Divine Goddess" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_F", Name = "Egyptian Mural" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_F", Name = "Fatal Dagger" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_F", Name = "Gabriel" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_F", Name = "Archangel and Mary" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_F", Name = "Floral Symmetry" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_021", Name = "Time's Up Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_020", Name = "Time's Up Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_012", Name = "8 Ball Skull" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_010", Name = "Electric Snake" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_000", Name = "Skull Rider" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_048", Name = "Peace" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_043", Name = "Triangle White" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_039", Name = "Sleeve" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_037", Name = "Sunrise" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_034", Name = "Stop" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_028", Name = "Thorny Rose" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_027", Name = "Padlock" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_026", Name = "Pizza" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_016", Name = "Lightning Bolt" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_015", Name = "Mustache" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_007", Name = "Bricks" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_003", Name = "Diamond Sparkle" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LArm_000", Name = "Greed is Good" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_001", Name = "Parrot" },
            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_000", Name = "Tribal Flower" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_041", Name = "Dope Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_031", Name = "Lady M" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_015", Name = "Zodiac Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_006", Name = "Oriental Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_005", Name = "Serpents" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_015", Name = "Racing Brunette" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_007", Name = "Racing Blonde" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_001", Name = "Burning Heart" },//50 Death Match Award
                                                                                                                                      //not on list
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_F", Name = "Geometric Design" }
        };
        private static readonly List<Tattoo> femaleTats06 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_F", Name = "Nothing Mini About It" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_F", Name = "Snake Revolver" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_F", Name = "Weapon Sleeve" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_F", Name = "Centipede" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_F", Name = "Fleshy Eye" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_F", Name = "Armored Arm" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_F", Name = "Demon Smile" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_F", Name = "Angel & Devil" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_F", Name = "Death Is Certain" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_F", Name = "Hood Skeleton" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_F", Name = "Peacock" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_F", Name = "Ballas 4 Life" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_F", Name = "Ascension" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_F", Name = "Zombie Rhymes" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_F", Name = "Dog Fist" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_F", Name = "K.U.L.T.99.1 FM" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_F", Name = "Octopus Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_F", Name = "Shark Water" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_F", Name = "Still Slipping" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_F", Name = "Soulwax" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_F", Name = "Smiley Glitch" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_F", Name = "Skeleton DJ" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_F", Name = "Music Locker" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_F", Name = "LSUR" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_F", Name = "Lighthouse" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_F", Name = "Jellyfish Shades" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_F", Name = "Tropical Dude" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_F", Name = "Headphone Splat" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_F", Name = "LS Monogram" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_F", Name = "Skull and Aces" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_F", Name = "Queen of Roses" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_F", Name = "The Gambler's Life" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_F", Name = "Lady Luck" },//

            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_F", Name = "Spartan Mural" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_F", Name = "Samurai Tallship" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_F", Name = "Muscle Tear" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_F", Name = "Feather Sleeve" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_F", Name = "Celtic Band" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_F", Name = "Tiger Headdress" },
            new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_F", Name = "Medusa" },

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_F", Name = "Stylized Kraken" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_F", Name = "Mutiny" },
            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_F", Name = "Crackshot" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_F", Name = "Combat Reaper" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_F", Name = "Have a Nice Day" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_F", Name = "Grenade" },

            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_F", Name = "Drive Forever" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_F", Name = "Engulfed Block" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_F", Name = "Dialed In" },
            new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_F", Name = "Mechanical Sleeve" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_F", Name = "Mum" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_F", Name = "These Colors Don't Run" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_F", Name = "Snake Bike" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_F", Name = "Skull Chain" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_F", Name = "Grim Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_F", Name = "Eagle Emblem" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_F", Name = "Lady Mortality" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_F", Name = "Swooping Eagle" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_F", Name = "Seductive Mechanic" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_F", Name = "One Down Five Up" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_F", Name = "Biker Stallion" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_F", Name = "Coffin Racer" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_F", Name = "Grave Vulture" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_F", Name = "Arachnid of Death" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_F", Name = "Poison Wrench" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_F", Name = "Black Tears" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_F", Name = "Loving Los Muertos" },
            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_F", Name = "Lady Vamp" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_F", Name = "Seductress" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_F", Name = "Floral Print" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_F", Name = "Heavenly Deity" },
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_F", Name = "Intrometric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_F", Name = "Geisha Bloom" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_F", Name = "Mermaid Harpist" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_F", Name = "Floral Raven" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_027", Name = "Fuck Luck Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_026", Name = "Fuck Luck Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_023", Name = "You're Next Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_022", Name = "You're Next Outline" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_008", Name = "Death Before Dishonor" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_004", Name = "Snake Shaded" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_003", Name = "Snake Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_045", Name = "Mesh Band" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_044", Name = "Triangle Black" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_036", Name = "Shapes" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_023", Name = "Smiley" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_022", Name = "Pencil" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_020", Name = "Geo Pattern" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_018", Name = "Origami" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_017", Name = "Eye Triangle" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_014", Name = "Spray Can" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_010", Name = "Horseshoe" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_008", Name = "Cube" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_004", Name = "Bone" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_001", Name = "Single Arrow" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RArm_000", Name = "Dollar Sign" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RArm_001", Name = "Tribal Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_047", Name = "Lion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_038", Name = "Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_028", Name = "Mermaid" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_027", Name = "Virgin Mary" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_018", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_014", Name = "Flower Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_003", Name = "Dragons and Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_001", Name = "Dragons" },
                //TatThis.Addnew Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_000", Name = "Brotherhood" } ,-empty load?

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_010", Name = "Ride or Die" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_002", Name = "Grim Reaper Smoking Gun" },//Clear 5 Gang Atacks in a Day Award
                                                                                                                                                //Not In List
            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_F", Name = "Geometric Design" }
        };
        private static readonly List<Tattoo> femaleTats07 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_F", Name = "Cobra Biker" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_F", Name = "Minimal SMG" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_F", Name = "Minimal Advanced Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_F", Name = "Minimal Sniper Rifle" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_F", Name = "Many-eyed Goat" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_F", Name = "Mobster Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_F", Name = "Wounded Head" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_F", Name = "Stabbed Skull" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_F", Name = "Tiger Blade" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_F", Name = "LS Smoking Cartridges" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_F", Name = "Trust" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_F", Name = "Soundwaves" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_F", Name = "Skull Waters" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_F", Name = "Glow Princess" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_F", Name = "Pineapple Skull" },
            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_F", Name = "Tropical Serpent" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_F", Name = "Love Fist" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_F", Name = "8-Ball Rose" },//
            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_F", Name = "One-armed Bandit" },//

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_F", Name = "Rose Revolver" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_F", Name = "Death Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_F", Name = "Stylized Tiger" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_F", Name = "Patriot Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_F", Name = "Laughing Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_F", Name = "Bone Cruiser" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_F", Name = "Ride Free" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_F", Name = "Scorched Soul" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_F", Name = "Engulfed Skull" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_F", Name = "Bad Luck" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_F", Name = "Ride or Die" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_F", Name = "Rose Tribute" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_F", Name = "Stunt Jesus" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_F", Name = "Quad Goblin" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_F", Name = "Golden Cobra" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_F", Name = "Dirt Track Hero" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_F", Name = "Dagger Devil" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_F", Name = "Death Us Do Part" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_F", Name = "Presidents" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_F", Name = "LS Serpent" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_F", Name = "Cross of Roses" },
            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_F", Name = "Serpent of Death" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_002", Name = "Spider Color" },
            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_001", Name = "Spider Outline" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_040", Name = "Black Anchor" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_019", Name = "Charm" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_009", Name = "Squares" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LLeg_000", Name = "Single" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_032", Name = "Faith" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_037", Name = "Grim Reaper" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_035", Name = "Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_033", Name = "Chinese Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_026", Name = "Smoking Dagger" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_023", Name = "Hottie" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_021", Name = "Serpent Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_008", Name = "Dragon Mural" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_002", Name = "Melting Skull" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_009", Name = "Dragon and Dagger" }
        };
        private static readonly List<Tattoo> femaleTats08 = new List<Tattoo>
        {
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_F", Name = "Skull Grenade" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_F", Name = "Three-eyed Demon" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_F", Name = "Smoldering Reaper" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_F", Name = "Gold Gun" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_F", Name = "Blue Serpent" },
            new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_F", Name = "Night Demon" },

            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_F", Name = "Bandana Knife" },
            new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_F", Name = "Graffiti Skull" },

            new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_F", Name = "Skullphones" },

            new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_F", Name = "Kifflom" },

            new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_F", Name = "Cash is King" },//

            new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_F", Name = "Homeward Bound" },

            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_F", Name = "Pistol Ace" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_F", Name = "Restless Skull" },
            new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_F", Name = "Combat Skull" },

            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_F", Name = "STFU" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_F", Name = "American Made" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_F", Name = "Dusk Rider" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_F", Name = "Western Insignia" },
            new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_F", Name = "Dragon's Fury" },

            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_F", Name = "Brake Knife" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_F", Name = "Severed Hand" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_F", Name = "Wheelie Mouse" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_F", Name = "Speed Freak" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_F", Name = "Piston Angel" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_F", Name = "Praying Gloves" },
            new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_F", Name = "Demon Spark Plug" },

            new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_F", Name = "San Andreas Prayer" },

            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_F", Name = "Dance of Hearts" },//
            new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_F", Name = "Ink Me" },//

            new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_F", Name = "Starmetric" },

            new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_F", Name = "Elaborate Los Muertos" },

            new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_014", Name = "Floral Dagger" },

            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_042", Name = "Sparkplug" },
            new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_038", Name = "Grub" },

            new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RLeg_000", Name = "Diamond Crown" },

            new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RLeg_000", Name = "School of Fish" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_043", Name = "Indian Ram" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_042", Name = "Flaming Scorpion" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_040", Name = "Flaming Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_039", Name = "Broken Skull" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_022", Name = "Fiery Dragon" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_017", Name = "Tribal" },
            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_007", Name = "The Warrior" },

            new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_006", Name = "Skull and Sword" }
        };

        public static void LoadPlayerOut()
        {
            LoggerLight.LogThis("LoadPlayerOut");

            string sDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe";
            if (Directory.Exists(sDir))
            {
                string sFreeM = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml";
                string sFreeF = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml";

                if (File.Exists(sFreeF))
                    DataStore.FemaleCloth = ReadWriteXML.LoadXmlCloth(sFreeF);

                if (File.Exists(sFreeM))
                    DataStore.MaleCloth = ReadWriteXML.LoadXmlCloth(sFreeM);
            }
        }
        public static int DoesThisExist(string sPed, string sTitle)
        {
            string sOutDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe";

            int iFind = -1;
            if (File.Exists(sOutDir + "/" + sPed + ".Xml"))
            {
                ClothBankXML MyWardrobe = ReadWriteXML.LoadXmlCloth(sOutDir + "/" + sPed + ".Xml");

                for (int i = 0; i < MyWardrobe.Outfits.Count(); i++)
                {
                    if (MyWardrobe.Outfits[i].Title == sTitle)
                    {
                        iFind = i;
                    }
                }
            }

            return iFind;
        }
        public static void UpdateOldXMLs()
        {
            LoggerLight.LogThis("UpdateOldXMLs");

            string sOldDir = "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit";

            if (Directory.Exists(sOldDir))
            {
                ClothBankXML Franklin = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Franklin.Xml");
                ClothBankXML Michael = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Michael.Xml");
                ClothBankXML Trevor = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Trevor.Xml");
                ClothBankXML FreemodeFemale = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml");
                ClothBankXML FreemodeMale = ReadWriteXML.LoadXmlCloth("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml");

                string[] sWrite = Directory.GetFiles("" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Outfit");
                for (int i = 0; i < sWrite.Count(); i++)
                {
                    if (File.Exists(sWrite[i]))
                    {
                        ClothBank NewBank = ReadWriteXML.LoadXmlClothDefault(sWrite[i]);

                        if (sWrite[i].Contains("_"))
                        {
                            string sting = sWrite[i];
                            int iNum = sting.LastIndexOf("_") + 1;
                            sting = sting.Substring(iNum);
                            NewBank.Title = sting.Substring(0, sting.Count() - 4);

                            if (sWrite[i].Contains("Franklin"))
                            {
                                int iAm = DoesThisExist("Franklin", NewBank.Title);
                                if (iAm == -1)
                                    Franklin.Outfits.Add(NewBank);
                                else
                                    Franklin.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("Michael"))
                            {
                                int iAm = DoesThisExist("Michael", NewBank.Title);
                                if (iAm == -1)
                                    Michael.Outfits.Add(NewBank);
                                else
                                    Michael.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("Trevor"))
                            {
                                int iAm = DoesThisExist("Trevor", NewBank.Title);
                                if (iAm == -1)
                                    Trevor.Outfits.Add(NewBank);
                                else
                                    Trevor.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("FreeFemale"))
                            {
                                int iAm = DoesThisExist("FreemodeFemale", NewBank.Title);
                                if (iAm == -1)
                                    FreemodeFemale.Outfits.Add(NewBank);
                                else
                                    FreemodeFemale.Outfits[iAm] = NewBank;
                            }
                            else if (sWrite[i].Contains("FreeMale"))
                            {
                                int iAm = DoesThisExist("FreemodeMale", NewBank.Title);
                                if (iAm == -1)
                                    FreemodeMale.Outfits.Add(NewBank);
                                else
                                    FreemodeMale.Outfits[iAm] = NewBank;
                            }
                        }
                        File.Delete(sWrite[i]);
                    }
                }
                ReadWriteXML.SaveXmlCloth(Franklin, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Franklin.Xml");
                ReadWriteXML.SaveXmlCloth(Michael, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Michael.Xml");
                ReadWriteXML.SaveXmlCloth(Trevor, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/Trevor.Xml");
                ReadWriteXML.SaveXmlCloth(FreemodeFemale, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeFemale.Xml");
                ReadWriteXML.SaveXmlCloth(FreemodeMale, "" + Directory.GetCurrentDirectory() + "/Scripts/NSPM/Wardrobe/FreemodeMale.Xml");
                Directory.Delete(sOldDir);
            }

            LoadPlayerOut();
        }
        public static void WardrobeScan(int iOutfit)
        {
            LoggerLight.LogThis("WardrobeScan, iOutfit == " + iOutfit);

            ClothBank ThisOut = new ClothBank();
            Ped Peddy = Game.Player.Character;

            int iPed;

            if (Peddy.Model == PedHash.Franklin)
                iPed = 1;
            else if (Peddy.Model == PedHash.Michael)
                iPed = 2;
            else if (Peddy.Model == PedHash.Trevor)
                iPed = 3;
            else if (Peddy.Model == PedHash.FreemodeFemale01)
                iPed = 4;
            else if (Peddy.Model == PedHash.FreemodeMale01)
                iPed = 5;
            else
                iPed = 99;
            if (iPed == 99)
            {
                if (iOutfit == 2)
                    TheMissions.Deliverwho_Backpack(iPed);
            }
            else
            {
                int iCloth = 0;
                while (iCloth < 12)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Peddy.Handle, iCloth);
                    ThisOut.ClothA.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Peddy.Handle, iCloth);
                    ThisOut.ClothB.Add(iTextId);
                    iCloth = iCloth + 1;
                }
                int iExtra = 0;
                while (iExtra < 5)
                {
                    int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Peddy.Handle, iExtra);
                    ThisOut.ExtraA.Add(iDrawId);
                    int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Peddy.Handle, iExtra);
                    ThisOut.ExtraB.Add(iTextId);
                    iExtra = iExtra + 1;
                }

                if (iOutfit == 1)
                {
                    ReadWriteXML.SaveXmlClothDefault(ThisOut, DataStore.sDefaulted);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
                    TheMissions.TempAgency_04_Discises(iPed);
                }
                else if (iOutfit == 2)
                {
                    ReadWriteXML.SaveXmlClothDefault(ThisOut, DataStore.sDefaulted);
                    Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
                    TheMissions.Deliverwho_Backpack(iPed);
                }
            }
        }
        public static void PedDresser(Ped Peddy, ClothBank MyCloth)
        {
            LoggerLight.LogThis("PedDresser");

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy.Handle);
            for (int i = 0; i < MyCloth.ClothA.Count; i++)
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, i, MyCloth.ClothA[i], MyCloth.ClothB[i], 2);

            for (int i = 0; i < MyCloth.ExtraA.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, i, MyCloth.ExtraA[i], MyCloth.ExtraB[i], false);
        }
        private static void RandPlayerTypes(Ped Pedx, bool bMale)
        {
            LoggerLight.LogThis("RandPlayerTypes, bMale == " + bMale);

            int shapeFirstID = 0;
            int shapeSecondID = 0;
            int shapeThirdID = 0;
            int skinFirstID = 1;
            int skinSecondID = 1;
            int skinThirdID = 1;
            int iHairStyle = 0;
            float shapeMix = 0.0f;
            float skinMix = 0.0f;
            float thirdMix = 0.0f;
            bool isParent = false;

            if (bMale)
            {
                shapeFirstID = RandomNum.RandInt(0, 20);
                shapeSecondID = RandomNum.RandInt(0, 20);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
                iHairStyle = RandomNum.RandInt(25, 76);
            }
            else
            {
                shapeFirstID = RandomNum.RandInt(21, 41);
                shapeSecondID = RandomNum.RandInt(21, 41);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
                iHairStyle = RandomNum.RandInt(25, 80);
            }

            shapeMix = ReturnStuff.RandFlow(-0.9f, 0.9f);
            skinMix = ReturnStuff.RandFlow(0.9f, 0.99f);
            thirdMix = ReturnStuff.RandFlow(-0.9f, 0.9f);

            Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Pedx.Handle, shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix, isParent);

            for (int i = 0; i < 12; i++)
            {
                int iColour = 0;
                int iChange = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HEAD_OVERLAY_VALUES, i));
                float fVar = ReturnStuff.RandFlow(0.45f, 0.99f);

                if (i == 0)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Blemishes
                else if (i == 1)
                {
                    if (bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Facial Hair
                else if (i == 2)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                    iColour = 1;
                }//Eyebrows
                else if (i == 3)
                {
                    iChange = 255;
                }//Ageing
                else if (i == 4)
                {
                    int iFace = RandomNum.RandInt(0, 50);
                    if (iFace < 30)
                    {
                        iChange = RandomNum.RandInt(0, 15);
                    }
                    else if (iFace < 45)
                    {
                        iChange = RandomNum.RandInt(0, iChange);
                        fVar = ReturnStuff.RandFlow(0.85f, 0.99f);
                    }
                    else
                        iChange = 255;
                }//Makeup
                else if (i == 5)
                {
                    if (!bMale)
                    {
                        iChange = RandomNum.RandInt(0, iChange);
                        fVar = ReturnStuff.RandFlow(0.15f, 0.39f);
                    }
                    else
                        iChange = 255;
                    iColour = 2;
                }//Blush
                else if (i == 6)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Complexion
                else if (i == 7)
                {
                    iChange = 255;
                }//Sun Damage
                else if (i == 8)
                {
                    if (!bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Lipstick
                else if (i == 9)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Moles/Freckles
                else if (i == 10)
                {
                    if (bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Chest Hair
                else if (i == 11)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Body Blemishes

                int AddColour = RandomNum.RandInt(0, 64);

                Function.Call(Hash.SET_PED_HEAD_OVERLAY, Pedx.Handle, i, iChange, fVar);

                if (iColour > 0)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Pedx.Handle, i, iColour, AddColour, 0);
            }


            int iHair = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
            int iHair2 = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));

            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, iHairStyle, 0, 2);//hair

            Function.Call(Hash._SET_PED_HAIR_COLOR, Pedx.Handle, iHair, iHair2);

            if (RandomNum.RandInt(1, 10) < 5)
            {
                List<Tattoo> Tatty = AddRandTats(bMale);
                int iCount = RandomNum.RandInt(1, Tatty.Count);

                for (int i = 0; i < iCount; i++)
                {
                    int iTat = RandomNum.RandInt(0, Tatty.Count - 1);
                    Function.Call(Hash._SET_PED_DECORATION, Pedx.Handle, Function.Call<int>(Hash.GET_HASH_KEY, Tatty[iTat].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, Tatty[iTat].TatName));
                    Tatty.RemoveAt(iTat);
                }
            }
        }
        private static List<Tattoo> AddRandTats(bool bMale)
        {
            LoggerLight.LogThis("FreemodePed.AddRandTats");
            List<Tattoo> Tatlist = new List<Tattoo>();

            if (bMale)
            {
                Tatlist.Add(maleTats01[RandomNum.RandInt(0, maleTats01.Count - 1)]);
                Tatlist.Add(maleTats02[RandomNum.RandInt(0, maleTats02.Count - 1)]);
                Tatlist.Add(maleTats03[RandomNum.RandInt(0, maleTats03.Count - 1)]);
                Tatlist.Add(maleTats04[RandomNum.RandInt(0, maleTats04.Count - 1)]);
                Tatlist.Add(maleTats05[RandomNum.RandInt(0, maleTats05.Count - 1)]);
                Tatlist.Add(maleTats06[RandomNum.RandInt(0, maleTats06.Count - 1)]);
                Tatlist.Add(maleTats07[RandomNum.RandInt(0, maleTats07.Count - 1)]);
                Tatlist.Add(maleTats08[RandomNum.RandInt(0, maleTats08.Count - 1)]);
            }
            else
            {
                Tatlist.Add(femaleTats01[RandomNum.RandInt(0, femaleTats01.Count - 1)]);
                Tatlist.Add(femaleTats02[RandomNum.RandInt(0, femaleTats02.Count - 1)]);
                Tatlist.Add(femaleTats03[RandomNum.RandInt(0, femaleTats03.Count - 1)]);
                Tatlist.Add(femaleTats04[RandomNum.RandInt(0, femaleTats04.Count - 1)]);
                Tatlist.Add(femaleTats05[RandomNum.RandInt(0, femaleTats05.Count - 1)]);
                Tatlist.Add(femaleTats06[RandomNum.RandInt(0, femaleTats06.Count - 1)]);
                Tatlist.Add(femaleTats07[RandomNum.RandInt(0, femaleTats07.Count - 1)]);
                Tatlist.Add(femaleTats08[RandomNum.RandInt(0, femaleTats08.Count - 1)]);
            }

            return Tatlist;
        }
        public static void OnlinePlayers(Ped Pedx, bool bMale, int iPreset)
        {
            LoggerLight.LogThis("OnlinePlayers, bMale == " + bMale + ", iPreset == " + iPreset);

            if (bMale)
            {
                if (iPreset == 2)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 134, 8, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 3, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 106, 8, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 83, 8, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 274, 8, 2);//Top2
                }
                else if (iPreset == 3)
                {
                    int iBe = RandomNum.RandInt(0, 9);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, RandomNum.RandInt(37, 76), 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 102, iBe, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 59, iBe, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 52, iBe, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 24, 0, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 15, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 54, 0, 2);//Top2
                    RandPlayerTypes(Pedx, bMale);
                }
                else if (iPreset == 4)
                {
                    RandPlayerTypes(Pedx, bMale);
                    int iRan = RandomNum.FindRandom(66, 1, 197);
                    while (iRan == 11 || iRan == 12 || iRan == 27 || iRan == 28 || iRan == 29 || iRan == 32 || iRan == 35 || iRan == 36 || iRan == 47 || iRan == 48 || iRan == 52 || iRan == 53 || iRan == 55 || iRan == 56 || iRan == 57 || iRan == 58 || iRan == 73 || iRan == 102 || iRan == 109 || iRan == 114 || iRan == 120 || iRan == 121 || iRan == 122 || iRan == 123 || iRan == 134 || iRan == 145 || iRan == 146 || iRan == 148 || iRan == 166 || iRan == 169 || iRan == 194)
                    { iRan = RandomNum.FindRandom(66, 1, 197); Script.Wait(1); }
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, iRan, RandomNum.RandInt(0, Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Pedx.Handle, 1)), 2);//
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 0, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 135, 1, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 45, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 12, 0, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 0, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 364, 1, 2);//Top2
                }
                else
                {
                    if (DataStore.MaleCloth.Outfits.Count > 0)
                        PedDresser(Pedx, DataStore.MaleCloth.Outfits[RandomNum.FindRandom(103, 0, DataStore.MaleCloth.Outfits.Count - 1)]);
                    else
                    {
                        int RanChar = RandomNum.RandInt(1, 5);
                        if (RanChar == 1)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 12, 4, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 1, 5, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 65, 3, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 22, 4, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 11, 0, 2);//Top2
                        }
                        else if (RanChar == 2)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 14, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 0, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 17, 0, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 23, 4, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 40, 1, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 26, 3, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 35, 0, 2);//Top2
                        }
                        else if (RanChar == 3)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 147, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 167, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 33, 0, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 36, 1, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 289, 0, 2);//Top2
                        }
                        else if (RanChar == 4)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 11, 4, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 19, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 88, 7, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 14, 2, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 273, 15, 2);//Top2
                        }
                        else
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 125, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 114, 6, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 78, 6, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 6, 2);//Top2
                        }
                    }
                    RandPlayerTypes(Pedx, bMale);
                }
            }
            else
            {
                if (iPreset == 2)
                {
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 134, 8, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 13, 0, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 113, 8, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 87, 8, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, -1, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 8, 2);//Top2
                }
                else if (iPreset == 3)
                {
                    int iBe = RandomNum.RandInt(0, 9);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, RandomNum.RandInt(37, 80), 0, 2);//hair
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 117, iBe, 2);//Torso
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 61, iBe, 2);//Legs
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 52, iBe, 2);//Hands
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 24, 0, 2);//shoes
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 3, 0, 2);//AccTop
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 47, 0, 2);//Top2
                    RandPlayerTypes(Pedx, bMale);
                }
                else
                {
                    if (DataStore.FemaleCloth.Outfits.Count > 0)
                        PedDresser(Pedx, DataStore.FemaleCloth.Outfits[RandomNum.FindRandom(104, 0, DataStore.FemaleCloth.Outfits.Count - 1)]);
                    else
                    {
                        int RanChar = RandomNum.RandInt(1, 5);
                        if (RanChar == 1)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 146, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 0, 0, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 1, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 113, 1, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 23, 8, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 0, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 287, 1, 2);//Top2
                        }
                        else if (RanChar == 2)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 11, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 169, 12, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 93, 4, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 3, 0, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, -1, 0, 2);//Top2
                        }
                        else if (RanChar == 3)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 13, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, -1, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 98, 4, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 71, 4, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 1, 5, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 254, 4, 2);//Top2
                        }
                        else if (RanChar == 4)
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 10, 1, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 15, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 9, 6, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 54, 3, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 100, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, 36, 1, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 13, 5, 2);//Top2
                        }
                        else
                        {
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 1, 0, 0, 2);//mask
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, 2, 3, 2);//hair
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 3, 11, 0, 2);//Torso
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 4, 75, 1, 2);//Legs
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 5, 0, 0, 2);//Hands
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 6, 20, 5, 2);//shoes
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 7, 0, 0, 2);//Scarf
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 8, -1, 0, 2);//AccTop
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 9, 0, 0, 2);//Armor
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 10, 0, 0, 2);//Emb--not used
                            Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 11, 208, 4, 2);//Top2
                        }
                    }
                    RandPlayerTypes(Pedx, bMale);
                }
            }
        }
    }
}
