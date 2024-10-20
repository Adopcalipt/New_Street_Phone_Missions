using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;
using System.Linq;

namespace New_Street_Phone_Missions
{
    public class EntityClear
    {
        public static List<Vehicle> PassiveVeh { get; set; }

        public static void CleanCams()
        {
            LoggerLight.LogThis("CleanCams");

            if (MissionData.cCams != null)
            {
                Function.Call(Hash.RENDER_SCRIPT_CAMS, 0, 1, 0, 0, 0);
                MissionData.cCams.Destroy();
                Function.Call(Hash.DISPLAY_RADAR, true);
                MissionData.cCams = null;
            }
        }
        public static void RemoveTargets()
        {
            LoggerLight.LogThis("RemoveTargets");

            for (int i = 0; i < MissionData.BlipList_01.Count; i++)
                EntityLog.CleanUp(MissionData.BlipList_01[i]);
            MissionData.BlipList_01.Clear();

            if (MissionData.Target_01 != null)
            {
                EntityLog.CleanUp(MissionData.Target_01);
                MissionData.Target_01 = null;
            }

            for (int i = 0; i < MissionData.iCoronaList.Count; i++)
                EntityLog.CleanUp(MissionData.iCoronaList[i], -1, -1);

            MissionData.iCoronaList.Clear();
        }
        public static void ClearOutAllStuff()
        {
            for (int i = 0; i < MissionData.iCoronaList.Count; i++)
                EntityLog.CleanUp(MissionData.iCoronaList[i], -1, -1);

            for (int i = 0; i < MissionData.PedList_01.Count; i++)
                EntityLog.CleanUp(MissionData.PedList_01[i], false);

            for (int i = 0; i < MissionData.PropList_01.Count; i++)
                EntityLog.CleanUp(MissionData.PropList_01[i], false);

            for (int i = 0; i < MissionData.VehicleList_01.Count; i++)
                EntityLog.CleanUp(MissionData.VehicleList_01[i], false);

            for (int i = 0; i < MissionData.BlipList_01.Count; i++)
                EntityLog.CleanUp(MissionData.BlipList_01[i]);

            MissionData.iCoronaList.Clear();
            MissionData.PedList_01.Clear();
            MissionData.PropList_01.Clear();
            MissionData.VehicleList_01.Clear();
            MissionData.BlipList_01.Clear();
        }
        public static void CleanMultiPed(bool bJustBlip, bool bDelete)
        {
            LoggerLight.LogThis("CleanMultiPed");

            for (int i = 0; i < NSPM.MultiPed.Count; i++)
            {
                if (NSPM.MultiPed[i].MyBlip != null)
                    NSPM.MultiPed[i].MyBlip.Remove();

                if (!bJustBlip)
                {
                    if (NSPM.MultiPed[i].MyVehicle != null)
                    {
                        EntityLog.CleanUp(NSPM.MultiPed[i].MyVehicle, false);
                        MissionData.VehicleList_01.Remove(NSPM.MultiPed[i].MyVehicle);
                    }
                    if (NSPM.MultiPed[i].MyPed != null)
                    {
                        if (NSPM.MultiPed[i].MyPed.Exists())
                        {
                            if (bDelete)
                                EntityLog.CleanUp(NSPM.MultiPed[i].MyPed, true);
                            else
                            {
                                NSPM.MultiPed[i].MyPed.Task.ClearAll();
                                NSPM.MultiPed[i].MyPed.Task.FleeFrom(Game.Player.Character);
                                NSPM.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                            }
                        }
                        MissionData.PedList_01.Remove(NSPM.MultiPed[i].MyPed);
                    }
                }
            }
            NSPM.MultiPed.Clear();
        }
        public static void CleanPedBlips()
        {
            LoggerLight.LogThis("CleanPedBlips");
            MissionData.iTracking = Game.GameTime + 1000;

            for (int i = 0; i < MissionData.PedList_01.Count; i++)
            {
                if (MissionData.PedList_01[i].Exists())
                {
                    if (MissionData.PedList_01[i].CurrentBlip.Exists())
                        MissionData.PedList_01[i].CurrentBlip.Remove();
                }
            }
        }
        public static void SimpleTracker()
        {
            MissionData.iTracking = Game.GameTime + 1000;

            for (int i = 0; i < MissionData.PedList_01.Count; i++)
            {
                if (MissionData.PedList_01[i].IsDead)
                {
                    if (Function.Call<int>(Hash.GET_WEAPON_DAMAGE_TYPE, Function.Call<int>(Hash.GET_PED_CAUSE_OF_DEATH, MissionData.PedList_01[i].Handle)) < 3)
                        MissionData.iUltMelle++;

                    if (MissionData.PedList_01[i].CurrentBlip.Exists())
                        MissionData.PedList_01[i].CurrentBlip.Remove();
                    if (MissionData.PedList_01[i].IsInVehicle())
                    {
                        if (MissionData.PedList_01[i].CurrentVehicle.CurrentBlip.Exists())
                            MissionData.PedList_01[i].CurrentVehicle.CurrentBlip.Remove();
                    }
                    MissionData.PedList_01[i].MarkAsNoLongerNeeded();
                    MissionData.PedList_01.RemoveAt(i);
                    MissionData.iUltPed01++;
                }
            }
        }
        public static void MultiPedTracker()
        {
            MissionData.iTracking = Game.GameTime + 1000;

            for (int i = 0; i < NSPM.MultiPed.Count; i++)
            {
                if (NSPM.MultiPed[i].MyPed == null)
                {
                    if (NSPM.MultiPed[i].MyBlip != null)
                        NSPM.MultiPed[i].MyBlip.Remove();
                    NSPM.MultiPed.RemoveAt(i);
                }
                else if (NSPM.MultiPed[i].MyPed.IsDead)
                {
                    if (NSPM.MultiPed[i].MyBlip != null)
                        NSPM.MultiPed[i].MyBlip.Remove();

                    if (Function.Call<int>(Hash.GET_WEAPON_DAMAGE_TYPE, Function.Call<int>(Hash.GET_PED_CAUSE_OF_DEATH, MissionData.PedList_01[i].Handle)) < 3)
                        MissionData.iUltMelle += 1;

                    MissionData.PedList_01.Remove(NSPM.MultiPed[i].MyPed);
                    NSPM.MultiPed[i].MyPed.MarkAsNoLongerNeeded();
                    NSPM.MultiPed.RemoveAt(i);
                    MissionData.iUltPed01 += 1;
                }
                else if (NSPM.MultiPed[i].MyVehicle != null)
                {
                    if (NSPM.MultiPed[i].MyPed.IsInVehicle(NSPM.MultiPed[i].MyVehicle))
                    {
                        if (!NSPM.MultiPed[i].MySwitch_01)
                        {
                            if (NSPM.MultiPed[i].MyBlip != null)
                                NSPM.MultiPed[i].MyBlip.Remove();
                            NSPM.MultiPed[i].MyBlip = EntityBuild.VehBlip(new BlipForm(NSPM.MultiPed[i].MyTask_01, NSPM.MultiPed[i].MyName), NSPM.MultiPed[i].MyVehicle);
                            NSPM.MultiPed[i].MySwitch_01 = true;
                        }
                    }
                    else
                    {
                        if (NSPM.MultiPed[i].MySwitch_01)
                        {
                            if (NSPM.MultiPed[i].MyBlip != null)
                                NSPM.MultiPed[i].MyBlip.Remove();
                            NSPM.MultiPed[i].MyBlip = EntityBuild.PedBlimp(new BlipForm(NSPM.MultiPed[i].MyTask_01, NSPM.MultiPed[i].MyName), NSPM.MultiPed[i].MyPed);
                            NSPM.MultiPed[i].MySwitch_01 = false;
                        }
                    }
                }
                else
                {
                    if (NSPM.MultiPed[i].MyPed.IsInVehicle())
                    {
                        if (!NSPM.MultiPed[i].MySwitch_01)
                        {
                            if (NSPM.MultiPed[i].MyBlip != null)
                                NSPM.MultiPed[i].MyBlip.Remove();
                            NSPM.MultiPed[i].MySwitch_01 = true;
                        }
                    }
                    else
                    {
                        if (NSPM.MultiPed[i].MySwitch_01)
                        {
                            if (NSPM.MultiPed[i].MyBlip != null)
                                NSPM.MultiPed[i].MyBlip.Remove();
                            NSPM.MultiPed[i].MyBlip = EntityBuild.PedBlimp(new BlipForm(NSPM.MultiPed[i].MyTask_01, NSPM.MultiPed[i].MyName), NSPM.MultiPed[i].MyPed);
                            NSPM.MultiPed[i].MySwitch_01 = false;
                        }
                    }
                }
            }
        }
        public static void PostMess()
        {
            LoggerLight.LogThis("PostMess");

            RemoveTargets();

            UiDisplay.sSubDisplay = "";
            UiDisplay.bSubDisplay = false;

            UiDisplay.bUiDisplay = false;
            UiDisplay.bMMDisplay01 = false;
            UiDisplay.bMMDisplay02 = false;
            UiDisplay.FolPed = null;

            SearchFor.MakeCarz.Clear();
            SearchFor.MakeFrenz.Clear();
            SearchFor.StreetFrenz.Clear();
            SearchFor.BackSeat.Clear();
            PassiveVeh.Clear();

            DataStore.iLookForPB = 0;
            DataStore.OnTheJob = false;

            MissionData.MishNpc = null;
            MissionData.MishVeh = null;
            MissionData.Pick_01 = null;
            MissionData.vFuMiss = Vector3.Zero;

            DataStore.LookingForPB = true;

            Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
            Function.Call(Hash.SET_FAR_DRAW_VEHICLES, true);

            CleanMultiPed(true, false);
            CleanCams();
            ClearOutAllStuff();
            EntityLog.CleanAss();

            Game.Player.WantedLevel = 0;

            if (DataStore.MySettings.EnemyStrength)
                Function.Call(Hash.SET_AI_WEAPON_DAMAGE_MODIFIER, 1.00f);
        }
        public static void ClearTheWay(bool removeAll, bool CopKiller)
        {
            if (CopKiller)
            {
                List<Vehicle> Cops = SearchFor.GetLocalVeh(Game.Player.Character.Position, 150f);
                for (int i = 0; i < Cops.Count; i++)
                {
                    Vehicle VHick = Cops[i];
                    if (VHick.Model == VehicleHash.Polmav)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.FBI)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.FBI2)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Police)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Police2)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Police3)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Police4)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Policeb)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.PoliceT)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Sheriff)
                        VHick.Delete();
                    else if (VHick.Model == VehicleHash.Sheriff2)
                        VHick.Delete();
                }
            }
            else
            {
                Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
                Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

                Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);
                Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.00f);

                Entity[] Entz = World.GetAllEntities();
                List<Entity> Elist = new List<Entity>();

                for (int i = 0; i < Entz.Count(); i++)
                    Elist.Add(Entz[i]);

                for (int i = 0; i < Elist.Count; i++)
                {
                    try
                    {
                        Entity Ent = Elist[i];
                        if (Ent.Exists())
                        {
                            if (removeAll)
                            {
                                if (Function.Call<bool>(Hash.IS_ENTITY_A_PED, Ent.Handle) && !Ent.IsPersistent)
                                    Ent.Delete();
                            }

                            if (Function.Call<bool>(Hash.IS_ENTITY_A_VEHICLE, Ent.Handle) && !Ent.IsPersistent)
                                Ent.Delete();
                        }


                    }
                    catch
                    {
                        LoggerLight.LogThis("ClearTheWay -- LostData");
                    }
                }
            }
        }
        public static void Racist_PasiveMode()
        {
            for (int i = 0; i < PassiveVeh.Count; i++)
            {
                for (int ii = 0; ii < PassiveVeh.Count; ii++)
                {
                    if (i != ii)
                    {
                        Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, PassiveVeh[ii].Handle, PassiveVeh[i].Handle, true);
                        Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, PassiveVeh[i].Handle, PassiveVeh[ii].Handle, true);
                    }
                }
            }
        }
    }
}
