using GTA;
using GTA.Math;
using GTA.Native;
using New_Street_Phone_Missions.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace New_Street_Phone_Missions
{
    public class ReturnStuff 
    {
        /*
        [DllImport("MobileNetwork.asi", ExactSpelling = true, EntryPoint = "SnowFall")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern unsafe bool SnowFall();
        [DllImport("MobileNetwork.asi", ExactSpelling = true, EntryPoint = "LetItSnow")]
        public static extern unsafe void LetItSnow();

        [DllImport("MobileNetwork.asi", ExactSpelling = true, EntryPoint = "BringSunshine")]
        public static extern unsafe void BringSunshine();
        */
        private readonly static List<DanceMoves> MaleDance01 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^5"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^6"),
        };
        private readonly static List<DanceMoves> MaleDance02 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^6")
        };
        private readonly static List<DanceMoves> MaleDance03 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^6")
        };

        private readonly static List<DanceMoves> FemaleDance01 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^6")
        };
        private readonly static List<DanceMoves> FemaleDance02 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^6")
        };
        private readonly static List<DanceMoves> FemaleDance03 = new List<DanceMoves>
        {
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^6"),

            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^1"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^2"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^3"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^4"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^5"),
            new DanceMoves("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^6")
        };

        public static readonly List<string> WeapsList = new List<string>
        {
            "WEAPON_dagger",  //0x92A27487",
            "WEAPON_bat",  //0x958A4A8F",
            "WEAPON_bottle",  //0xF9E6AA4B",
            "WEAPON_crowbar",  //0x84BD7BFD",
            "WEAPON_unarmed",  //0xA2719263",
            "WEAPON_flashlight",  //0x8BB05FD7",
            "WEAPON_golfclub",  //0x440E4788",
            "WEAPON_hammer",  //0x4E875F73",
            "WEAPON_hatchet",  //0xF9DCBF2D",
            "WEAPON_knuckle",  //0xD8DF3C3C",
            "WEAPON_knife",  //0x99B507EA",
            "WEAPON_machete",  //0xDD5DF8D9",
            "WEAPON_switchblade",  //0xDFE37640",
            "WEAPON_nightstick",  //0x678B81B1",
            "WEAPON_wrench",  //0x19044EE0",
            "WEAPON_battleaxe",  //0xCD274149",
            "WEAPON_poolcue",  //0x94117305",
            "WEAPON_stone_hatchet",  //0x3813FC08"--17

            "WEAPON_pistol",  //0x1B06D571",
            "WEAPON_pistol_mk2",  //0xBFE256D4",---------19
            "WEAPON_combatpistol",  //0x5EF9FEC4",
            "WEAPON_appistol",  //0x22D8FE39",
            "WEAPON_pistol50",  //0x99AEEB3B",
            "WEAPON_snspistol",  //0xBFD21232",
            "WEAPON_snspistol_mk2",  //0x88374054",---24
            "WEAPON_heavypistol",  //0xD205520E",
            "WEAPON_vintagepistol",  //0x83839C4",
            "WEAPON_marksmanpistol",  //0xDC4DB296",
            "WEAPON_revolver",  //0xC1B3C3D1",
            "WEAPON_revolver_mk2",  //0xCB96392F",----29
            "WEAPON_doubleaction",  //0x97EA20B8",
            "WEAPON_ceramicpistol",  //0x2B5EF5EC",
            "WEAPON_navyrevolver",  //0x917F6C8C"
            "WEAPON_GADGETPISTOL",  //0xAF3696A1",
            "WEAPON_stungun",  //0x3656C8C1",
            "WEAPON_flaregun",  //0x47757124",
            "WEAPON_raypistol",  //0xAF3696A1",--36

            "WEAPON_microsmg",  //0x13532244",
            "WEAPON_smg",  //0x2BE6766B",
            "WEAPON_smg_mk2",  //0x78A97CD0",-----39
            "WEAPON_assaultsmg",  //0xEFE7E2DF",
            "WEAPON_combatpdw",  //0xA3D4D34",
            "WEAPON_machinepistol",  //0xDB1AA450",
            "WEAPON_minismg",  //0xBD248B55",
            "WEAPON_raycarbine",  //0x476BF155"--44

            "WEAPON_pumpshotgun",  //0x1D073A89",
            "WEAPON_pumpshotgun_mk2",  //0x555AF99A",-----------46
            "WEAPON_sawnoffshotgun",  //0x7846A318",
            "WEAPON_assaultshotgun",  //0xE284C527",
            "WEAPON_bullpupshotgun",  //0x9D61E50F",
            "WEAPON_musket",  //0xA89CB99E",
            "WEAPON_heavyshotgun",  //0x3AABBBAA",
            "WEAPON_dbshotgun",  //0xEF951FBB",
            "WEAPON_autoshotgun",  //0x12E82D3D"--53
            "WEAPON_COMBATSHOTGUN",  //0x5A96BA4--54

            "WEAPON_assaultrifle",  //0xBFEFFF6D",
            "WEAPON_assaultrifle_mk2",  //0x394F415C",-------56
            "WEAPON_carbinerifle",  //0x83BF0278",
            "WEAPON_carbinerifle_mk2",  //0xFAD1F1C9",------58
            "WEAPON_advancedrifle",  //0xAF113F99",
            "WEAPON_specialcarbine",  //0xC0A3098D",
            "WEAPON_specialcarbine_mk2",  //0x969C3D67",------61
            "WEAPON_bullpuprifle",  //0x7F229F94",
            "WEAPON_bullpuprifle_mk2",  //0x84D6FAFD",----63
            "WEAPON_compactrifle",  //0x624FE830"--64
            "WEAPON_MILITARYRIFLE",  //0x624FE830"--65

            "WEAPON_mg",  //0x9D07F764",
            "WEAPON_combatmg",  //0x7FD62962",
            "WEAPON_combatmg_mk2",  //0xDBBD7280",------68
            "WEAPON_gusenberg",  //0x61012683"--69

            "WEAPON_sniperrifle",  //0x5FC3C11",
            "WEAPON_heavysniper",  //0xC472FE2",
            "WEAPON_heavysniper_mk2",  //0xA914799",---72
            "WEAPON_marksmanrifle",  //0xC734385A",
            "WEAPON_marksmanrifle_mk2",  //0x6A6C02E0"--74

            "WEAPON_rpg",  //0xB1CA77B1",
            "WEAPON_grenadelauncher",  //0xA284510B",
            "WEAPON_grenadelauncher_smoke",  //0x4DD2DC56",
            "WEAPON_minigun",  //0x42BF8A85",
            "WEAPON_firework",  //0x7F7497E5",
            "WEAPON_railgun",  //0x6D544C99",
            "WEAPON_hominglauncher",  //0x63AB0442",
            "WEAPON_compactlauncher",  //0x781FE4A",
            "WEAPON_rayminigun",  //0xB62D1F67"--83

            "WEAPON_grenade",  //0x93E220BD",
            "WEAPON_bzgas",  //0xA0973D5E",
            "WEAPON_smokegrenade",  //0xFDBC8A50",
            "WEAPON_flare",  //0x497FACC3",
            "WEAPON_molotov",  //0x24B17070",
            "WEAPON_stickybomb",  //0x2C3731D9",
            "WEAPON_proxmine",  //0xAB564B93",
            "WEAPON_snowball",  //0x787F0BB",
            "WEAPON_pipebomb",  //0xBA45E8B8",
            "WEAPON_ball",  //0x23C9F95C"--93

            "WEAPON_petrolcan",  //0x34A67B97",
            "WEAPON_fireextinguisher",  //0x60EC506",
            "WEAPON_parachute",  //0xFBAB5776",
            "WEAPON_hazardcan",  //0xBA536372"--97

            "WEAPON_EMPLAUNCHER",  // 0xDB26713A--98

            "WEAPON_HEAVYRIFLE",  //0xC78D71B4 --99

            "WEAPON_FERTILIZERCAN",//100

            "WEAPON_STUNGUN_MP",//101

            "WEAPON_METALDETECTOR",

            "WEAPON_PRECISIONRIFLE", //| 0x6E7DDDEC

            "WEAPON_TACTICALRIFLE", //| 0xD1D5F52B
            "WEAPON_PISTOLXM3",//| 
            "WEAPON_CANDYCANE",//| 
            "WEAPON_RAILGUNXM3",//| 
            "WEAPON_ACIDPACKAGE"//| 
        };
        public static readonly List<string> WeapAddonsList = new List<string>
        {
            "COMPONENT_ADVANCEDRIFLE_CLIP_01",//0xFA8FA10F,
            "COMPONENT_ADVANCEDRIFLE_CLIP_02",//0x8EC1C979,
            "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE",//0x377CD377,
            "COMPONENT_APPISTOL_CLIP_01",//0x31C4B22A,
            "COMPONENT_APPISTOL_CLIP_02",//0x249A17D5,
            "COMPONENT_APPISTOL_VARMOD_LUXE",//0x9B76C72C,
            "COMPONENT_ASSAULTRIFLE_CLIP_01",//0xBE5EEA16,
            "COMPONENT_ASSAULTRIFLE_CLIP_02",//0xB1214F9B,
            "COMPONENT_ASSAULTRIFLE_CLIP_03",//0xDBF0A53D,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO",//0x911B24AF,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02",//0x37E5444B,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03",//0x538B7B97,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04",//0x25789F72,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05",//0xC5495F2D,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06",//0xCF8B73B1,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07",//0xA9BB2811,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08",//0xFC674D54,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09",//0x7C7FCD9B,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10",//0xA5C38392,
            "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01",//0xB9B15DB0,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01",//0x8610343F,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02",//0xD12ACA6F,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING",//0xA7DD1E58,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ",//0x63E0A098,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY",//0xFB70D853,
            "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER",//0xEF2C78C1,
            "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE",//0x4EAD7533,
            "COMPONENT_ASSAULTSHOTGUN_CLIP_01",//0x94E81BC7,
            "COMPONENT_ASSAULTSHOTGUN_CLIP_02",//0x86BD7F72,
            "COMPONENT_ASSAULTSMG_CLIP_01",//0x8D1307B0,
            "COMPONENT_ASSAULTSMG_CLIP_02",//0xBB46E417,
            "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER",//0x278C78AF,
            "COMPONENT_AT_AR_AFGRIP",//0xC164F53,
            "COMPONENT_AT_AR_AFGRIP_02",//0x9D65907A,
            "COMPONENT_AT_AR_BARREL_01",//0x43A49D26,
            "COMPONENT_AT_AR_BARREL_02",//0x5646C26A,
            "COMPONENT_AT_AR_FLSH",//0x7BC4CDDC,
            "COMPONENT_AT_AR_SUPP",//0x837445AA,
            "COMPONENT_AT_AR_SUPP_02",//0xA73D4664,
            "COMPONENT_AT_BP_BARREL_01",//0x659AC11B,
            "COMPONENT_AT_BP_BARREL_02",//0x3BF26DC7,
            "COMPONENT_AT_CR_BARREL_01",//0x833637FF,
            "COMPONENT_AT_CR_BARREL_02",//0x8B3C480B,
            "COMPONENT_AT_MG_BARREL_01",//0xC34EF234,
            "COMPONENT_AT_MG_BARREL_02",//0xB5E2575B,
            "COMPONENT_AT_MRFL_BARREL_01",//0x381B5D89,
            "COMPONENT_AT_MRFL_BARREL_02",//0x68373DDC,
            "COMPONENT_AT_MUZZLE_01",//0xB99402D4,
            "COMPONENT_AT_MUZZLE_02",//0xC867A07B,
            "COMPONENT_AT_MUZZLE_03",//0xDE11CBCF,
            "COMPONENT_AT_MUZZLE_04",//0xEC9068CC,
            "COMPONENT_AT_MUZZLE_05",//0x2E7957A,
            "COMPONENT_AT_MUZZLE_06",//0x347EF8AC,
            "COMPONENT_AT_MUZZLE_07",//0x4DB62ABE,
            "COMPONENT_AT_MUZZLE_08",//0x5F7DCE4D,
            "COMPONENT_AT_MUZZLE_09",//0x6927E1A1,
            "COMPONENT_AT_PI_COMP",//0x21E34793,
            "COMPONENT_AT_PI_COMP_02",//0xAA8283BF,
            "COMPONENT_AT_PI_COMP_03",//0x27077CCB,
            "COMPONENT_AT_PI_FLSH",//0x359B7AAE,
            "COMPONENT_AT_PI_FLSH_02",//0x43FD595B,
            "COMPONENT_AT_PI_FLSH_03",//0x4A4965F3,
            "COMPONENT_AT_PI_RAIL",//0x8ED4BB70,
            "COMPONENT_AT_PI_RAIL_02",//0x47DE9258,
            "COMPONENT_AT_PI_SUPP",//0xC304849A,
            "COMPONENT_AT_PI_SUPP_02",//0x65EA7EBB,
            "COMPONENT_AT_SB_BARREL_01",//0xD9103EE1,
            "COMPONENT_AT_SB_BARREL_02",//0xA564D78B,
            "COMPONENT_AT_SCOPE_LARGE",//0xD2443DDC,
            "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM",//0x1C221B1A,
            "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2",//0x5B1C713C,
            "COMPONENT_AT_SCOPE_LARGE_MK2",//0x82C10383,
            "COMPONENT_AT_SCOPE_MACRO",//0x9D2FBF29,
            "COMPONENT_AT_SCOPE_MACRO_02",//0x3CC6BA57,
            "COMPONENT_AT_SCOPE_MACRO_02_MK2",//0xC7ADD105,
            "COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2",//0xE502AB6B,
            "COMPONENT_AT_SCOPE_MACRO_MK2",//0x49B2945,
            "COMPONENT_AT_SCOPE_MAX",//0xBC54DA77,
            "COMPONENT_AT_SCOPE_MEDIUM",//0xA0D89C42,
            "COMPONENT_AT_SCOPE_MEDIUM_MK2",//0xC66B6542,
            "COMPONENT_AT_SCOPE_NV",//0xB68010B0,
            "COMPONENT_AT_SCOPE_SMALL",//0xAA2C45B4,
            "COMPONENT_AT_SCOPE_SMALL_02",//0x3C00AFED,
            "COMPONENT_AT_SCOPE_SMALL_MK2",//0x3F3C8181,
            "COMPONENT_AT_SCOPE_SMALL_SMG_MK2",//0x3DECC7DA,
            "COMPONENT_AT_SCOPE_THERMAL",//0x2E43DA41,
            "COMPONENT_AT_SC_BARREL_01",//0xE73653A9,
            "COMPONENT_AT_SC_BARREL_02",//0xF97F783B,
            "COMPONENT_AT_SIGHTS",//0x420FD713,
            "COMPONENT_AT_SIGHTS_SMG",//0x9FDB5652,
            "COMPONENT_AT_SR_BARREL_01",//0x909630B7,
            "COMPONENT_AT_SR_BARREL_02",//0x108AB09E,
            "COMPONENT_AT_SR_SUPP",//0xE608B35E,
            "COMPONENT_AT_SR_SUPP_03",//0xAC42DF71,
            "COMPONENT_BULLPUPRIFLE_CLIP_01",//0xC5A12F80,
            "COMPONENT_BULLPUPRIFLE_CLIP_02",//0xB3688B0F,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO",//0xAE4055B7,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02",//0xB905ED6B,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03",//0xA6C448E8,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04",//0x9486246C,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05",//0x8A390FD2,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06",//0x2337FC5,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07",//0xEFFFDB5E,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08",//0xDDBDB6DA,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09",//0xCB631225,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10",//0xA87D541E,
            "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01",//0xC5E9AE52,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_01",//0x18929DA,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02",//0xEFB00628,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING",//0xFAA7F5ED,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ",//0x43621710,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY",//0xA99CF95A,
            "COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER",//0x822060A9,
            "COMPONENT_BULLPUPRIFLE_VARMOD_LOW",//0xA857BC78,
            "COMPONENT_CARBINERIFLE_CLIP_01",//0x9FBE33EC,
            "COMPONENT_CARBINERIFLE_CLIP_02",//0x91109691,
            "COMPONENT_CARBINERIFLE_CLIP_03",//0xBA62E935,
            "COMPONENT_CARBINERIFLE_MK2_CAMO",//0x4BDD6F16,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_02",//0x406A7908,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_03",//0x2F3856A4,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_04",//0xE50C424D,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_05",//0xD37D1F2F,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_06",//0x86268483,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_07",//0xF420E076,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_08",//0xAAE14DF8,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_09",//0x9893A95D,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_10",//0x6B13CD3E,
            "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01",//0xDA55CD3F,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_01",//0x4C7A391E,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_02",//0x5DD5DBD5,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING",//0x255D5D57,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ",//0x44032F11,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY",//0x3D25C2A7,
            "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER",//0x1757F566,
            "COMPONENT_CARBINERIFLE_VARMOD_LUXE",//0xD89B9658,
            "COMPONENT_COMBATMG_CLIP_01",//0xE1FFB34A,
            "COMPONENT_COMBATMG_CLIP_02",//0xD6C59CD6,
            "COMPONENT_COMBATMG_MK2_CAMO",//0x4A768CB5,
            "COMPONENT_COMBATMG_MK2_CAMO_02",//0xCCE06BBD,
            "COMPONENT_COMBATMG_MK2_CAMO_03",//0xBE94CF26,
            "COMPONENT_COMBATMG_MK2_CAMO_04",//0x7609BE11,
            "COMPONENT_COMBATMG_MK2_CAMO_05",//0x48AF6351,
            "COMPONENT_COMBATMG_MK2_CAMO_06",//0x9186750A,
            "COMPONENT_COMBATMG_MK2_CAMO_07",//0x84555AA8,
            "COMPONENT_COMBATMG_MK2_CAMO_08",//0x1B4C088B,
            "COMPONENT_COMBATMG_MK2_CAMO_09",//0xE046DFC,
            "COMPONENT_COMBATMG_MK2_CAMO_10",//0x28B536E,
            "COMPONENT_COMBATMG_MK2_CAMO_IND_01",//0xD703C94D,
            "COMPONENT_COMBATMG_MK2_CLIP_01",//0x492B257C,
            "COMPONENT_COMBATMG_MK2_CLIP_02",//0x17DF42E9,
            "COMPONENT_COMBATMG_MK2_CLIP_ARMORPIERCING",//0x29882423,
            "COMPONENT_COMBATMG_MK2_CLIP_FMJ",//0x57EF1CC8,
            "COMPONENT_COMBATMG_MK2_CLIP_INCENDIARY",//0xC326BDBA,
            "COMPONENT_COMBATMG_MK2_CLIP_TRACER",//0xF6649745,
            "COMPONENT_COMBATMG_VARMOD_LOWRIDER",//0x92FECCDD,
            "COMPONENT_COMBATPDW_CLIP_01",//0x4317F19E,
            "COMPONENT_COMBATPDW_CLIP_02",//0x334A5203,
            "COMPONENT_COMBATPDW_CLIP_03",//0x6EB8C8DB,
            "COMPONENT_COMBATPISTOL_CLIP_01",//0x721B079,
            "COMPONENT_COMBATPISTOL_CLIP_02",//0xD67B4F2D,
            "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER",//0xC6654D72,
            "COMPONENT_COMPACTRIFLE_CLIP_01",//0x513F0A63,
            "COMPONENT_COMPACTRIFLE_CLIP_02",//0x59FF9BF8,
            "COMPONENT_COMPACTRIFLE_CLIP_03",//0xC607740E,
            "COMPONENT_GRENADELAUNCHER_CLIP_01",//0x11AE5C97,
            "COMPONENT_GUSENBERG_CLIP_01",//0x1CE5A6A5,
            "COMPONENT_GUSENBERG_CLIP_02",//0xEAC8C270,
            "COMPONENT_HEAVYPISTOL_CLIP_01",//0xD4A969A,
            "COMPONENT_HEAVYPISTOL_CLIP_02",//0x64F9C62B,
            "COMPONENT_HEAVYPISTOL_VARMOD_LUXE",//0x7A6A7B7B,
            "COMPONENT_HEAVYSHOTGUN_CLIP_01",//0x324F2D5F,
            "COMPONENT_HEAVYSHOTGUN_CLIP_02",//0x971CF6FD,
            "COMPONENT_HEAVYSHOTGUN_CLIP_03",//0x88C7DA53,
            "COMPONENT_HEAVYSNIPER_CLIP_01",//0x476F52F4,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO",//0xF8337D02,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_02",//0xC5BEDD65,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_03",//0xE9712475,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_04",//0x13AA78E7,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_05",//0x26591E50,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_06",//0x302731EC,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_07",//0xAC722A78,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_08",//0xBEA4CEDD,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_09",//0xCD776C82,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_10",//0xABC5ACC7,
            "COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01",//0x6C32D2EB,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_01",//0xFA1E1A28,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_02",//0x2CD8FF9D,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_ARMORPIERCING",//0xF835D6D4,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_EXPLOSIVE",//0x89EBDAA7,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_FMJ",//0x3BE948F6,
            "COMPONENT_HEAVYSNIPER_MK2_CLIP_INCENDIARY",//0xEC0F617,
            "COMPONENT_KNUCKLE_VARMOD_BALLAS",//0xEED9FD63,
            "COMPONENT_KNUCKLE_VARMOD_BASE",//0xF3462F33,
            "COMPONENT_KNUCKLE_VARMOD_DIAMOND",//0x9761D9DC,
            "COMPONENT_KNUCKLE_VARMOD_DOLLAR",//0x50910C31,
            "COMPONENT_KNUCKLE_VARMOD_HATE",//0x7DECFE30,
            "COMPONENT_KNUCKLE_VARMOD_KING",//0xE28BABEF,
            "COMPONENT_KNUCKLE_VARMOD_LOVE",//0x3F4E8AA6,
            "COMPONENT_KNUCKLE_VARMOD_PIMP",//0xC613F685,
            "COMPONENT_KNUCKLE_VARMOD_PLAYER",//0x8B808BB,
            "COMPONENT_KNUCKLE_VARMOD_VAGOS",//0x7AF3F785,
            "COMPONENT_MACHINEPISTOL_CLIP_01",//0x476E85FF,
            "COMPONENT_MACHINEPISTOL_CLIP_02",//0xB92C6979,
            "COMPONENT_MACHINEPISTOL_CLIP_03",//0xA9E9CAF4,
            "COMPONENT_MARKSMANRIFLE_CLIP_01",//0xD83B4141,
            "COMPONENT_MARKSMANRIFLE_CLIP_02",//0xCCFD2AC5,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO",//0x9094FBA0,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02",//0x7320F4B2,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03",//0x60CF500F,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04",//0xFE668B3F,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05",//0xF3757559,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06",//0x193B40E8,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07",//0x107D2F6C,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08",//0xC4E91841,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09",//0x9BB1C5D3,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10",//0x3B61040B,
            "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01",//0xB7A316DA,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_01",//0x94E12DCE,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_02",//0xE6CFD1AA,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING",//0xF46FD079,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ",//0xE14A9ED3,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY",//0x6DD7A86E,
            "COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER",//0xD77A22D2,
            "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE",//0x161E9241,
            "COMPONENT_MG_CLIP_01",//0xF434EF84,
            "COMPONENT_MG_CLIP_02",//0x82158B47,
            "COMPONENT_MG_VARMOD_LOWRIDER",//0xD6DABABE,
            "COMPONENT_MICROSMG_CLIP_01",//0xCB48AEF0,
            "COMPONENT_MICROSMG_CLIP_02",//0x10E6BA2B,
            "COMPONENT_MICROSMG_VARMOD_LUXE",//0x487AAE09,
            "COMPONENT_MINISMG_CLIP_01",//0x84C8B2D3,
            "COMPONENT_MINISMG_CLIP_02",//0x937ED0B7,
            "COMPONENT_PISTOL50_CLIP_01",//0x2297BE19,
            "COMPONENT_PISTOL50_CLIP_02",//0xD9D3AC92,
            "COMPONENT_PISTOL50_VARMOD_LUXE",//0x77B8AB2F,
            "COMPONENT_PISTOL_CLIP_01",//0xFED0FD71,
            "COMPONENT_PISTOL_CLIP_02",//0xED265A1C,
            "COMPONENT_PISTOL_MK2_CAMO",//0x5C6C749C,
            "COMPONENT_PISTOL_MK2_CAMO_02",//0x15F7A390,
            "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE",//0x1A1F1260,
            "COMPONENT_PISTOL_MK2_CAMO_03",//0x968E24DB,
            "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE",//0xE4E00B70,
            "COMPONENT_PISTOL_MK2_CAMO_04",//0x17BFA99,
            "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE",//0x2C298B2B,
            "COMPONENT_PISTOL_MK2_CAMO_05",//0xF2685C72,
            "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE",//0xDFB79725,
            "COMPONENT_PISTOL_MK2_CAMO_06",//0xDD2231E6,
            "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE",//0x6BD7228C,
            "COMPONENT_PISTOL_MK2_CAMO_07",//0xBB43EE76,
            "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE",//0x9DDBCF8C,
            "COMPONENT_PISTOL_MK2_CAMO_08",//0x4D901310,
            "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE",//0xB319A52C,
            "COMPONENT_PISTOL_MK2_CAMO_09",//0x5F31B653,
            "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE",//0xC6836E12,
            "COMPONENT_PISTOL_MK2_CAMO_10",//0x697E19A0,
            "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE",//0x43B1B173,
            "COMPONENT_PISTOL_MK2_CAMO_IND_01",//0x930CB951,
            "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE",//0x4ABDA3FA,
            "COMPONENT_PISTOL_MK2_CAMO_SLIDE",//0xB4FC92B0,
            "COMPONENT_PISTOL_MK2_CLIP_01",//0x94F42D62,
            "COMPONENT_PISTOL_MK2_CLIP_02",//0x5ED6C128,
            "COMPONENT_PISTOL_MK2_CLIP_FMJ",//0x4F37DF2A,
            "COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT",//0x85FEA109,
            "COMPONENT_PISTOL_MK2_CLIP_INCENDIARY",//0x2BBD7A3A,
            "COMPONENT_PISTOL_MK2_CLIP_TRACER",//0x25CAAEAF,
            "COMPONENT_PISTOL_VARMOD_LUXE",//0xD7391086,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO",//0xE3BD9E44,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02",//0x17148F9B,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03",//0x24D22B16,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04",//0xF2BEC6F0,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05",//0x85627D,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06",//0xDC2919C5,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07",//0xE184247B,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08",//0xD8EF9356,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09",//0xEF29BFCA,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10",//0x67AEB165,
            "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01",//0x46411A1D,
            "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01",//0xCD940141,
            "COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING",//0x4E65B425,
            "COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE",//0x3BE4465D,
            "COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT",//0xE9582927,
            "COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY",//0x9F8A1BF5,
            "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER",//0xA2D79DDB,
            "COMPONENT_REVOLVER_CLIP_01",//0xE9867CE3,
            "COMPONENT_REVOLVER_MK2_CAMO",//0xC03FED9F,
            "COMPONENT_REVOLVER_MK2_CAMO_02",//0xB5DE24,
            "COMPONENT_REVOLVER_MK2_CAMO_03",//0xA7FF1B8,
            "COMPONENT_REVOLVER_MK2_CAMO_04",//0xF2E24289,
            "COMPONENT_REVOLVER_MK2_CAMO_05",//0x11317F27,
            "COMPONENT_REVOLVER_MK2_CAMO_06",//0x17C30C42,
            "COMPONENT_REVOLVER_MK2_CAMO_07",//0x257927AE,
            "COMPONENT_REVOLVER_MK2_CAMO_08",//0x37304B1C,
            "COMPONENT_REVOLVER_MK2_CAMO_09",//0x48DAEE71,
            "COMPONENT_REVOLVER_MK2_CAMO_10",//0x20ED9B5B,
            "COMPONENT_REVOLVER_MK2_CAMO_IND_01",//0xD951E867,
            "COMPONENT_REVOLVER_MK2_CLIP_01",//0xBA23D8BE,
            "COMPONENT_REVOLVER_MK2_CLIP_FMJ",//0xDC8BA3F,
            "COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT",//0x10F42E8F,
            "COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY",//0xEFBF25,
            "COMPONENT_REVOLVER_MK2_CLIP_TRACER",//0xC6D8E476,
            "COMPONENT_REVOLVER_VARMOD_BOSS",//0x16EE3040,
            "COMPONENT_REVOLVER_VARMOD_GOON",//0x9493B80D,
            "COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE",//0x85A64DF9,
            "COMPONENT_SMG_CLIP_01",//0x26574997,
            "COMPONENT_SMG_CLIP_02",//0x350966FB,
            "COMPONENT_SMG_CLIP_03",//0x79C77076,
            "COMPONENT_SMG_MK2_CAMO",//0xC4979067,
            "COMPONENT_SMG_MK2_CAMO_02",//0x3815A945,
            "COMPONENT_SMG_MK2_CAMO_03",//0x4B4B4FB0,
            "COMPONENT_SMG_MK2_CAMO_04",//0xEC729200,
            "COMPONENT_SMG_MK2_CAMO_05",//0x48F64B22,
            "COMPONENT_SMG_MK2_CAMO_06",//0x35992468,
            "COMPONENT_SMG_MK2_CAMO_07",//0x24B782A5,
            "COMPONENT_SMG_MK2_CAMO_08",//0xA2E67F01,
            "COMPONENT_SMG_MK2_CAMO_09",//0x2218FD68,
            "COMPONENT_SMG_MK2_CAMO_10",//0x45C5C3C5,
            "COMPONENT_SMG_MK2_CAMO_IND_01",//0x399D558F,
            "COMPONENT_SMG_MK2_CLIP_01",//0x4C24806E,
            "COMPONENT_SMG_MK2_CLIP_02",//0xB9835B2E,
            "COMPONENT_SMG_MK2_CLIP_FMJ",//0xB5A715F,
            "COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT",//0x3A1BD6FA,
            "COMPONENT_SMG_MK2_CLIP_INCENDIARY",//0xD99222E5,
            "COMPONENT_SMG_MK2_CLIP_TRACER",//0x7FEA36EC,
            "COMPONENT_SMG_VARMOD_LUXE",//0x27872C90,
            "COMPONENT_SNIPERRIFLE_CLIP_01",//0x9BC64089,
            "COMPONENT_SNIPERRIFLE_VARMOD_LUXE",//0x4032B5E7,
            "COMPONENT_SNSPISTOL_CLIP_01",//0xF8802ED9,
            "COMPONENT_SNSPISTOL_CLIP_02",//0x7B0033B3,
            "COMPONENT_SNSPISTOL_MK2_CAMO",//0xF7BEEDD,
            "COMPONENT_SNSPISTOL_MK2_CAMO_02",//0x8A612EF6,
            "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE",//0x29366D21,
            "COMPONENT_SNSPISTOL_MK2_CAMO_03",//0x76FA8829,
            "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE",//0x3ADE514B,
            "COMPONENT_SNSPISTOL_MK2_CAMO_04",//0xA93C6CAC,
            "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE",//0xE64513E9,
            "COMPONENT_SNSPISTOL_MK2_CAMO_05",//0x9C905354,
            "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE",//0xCD7AEB9A,
            "COMPONENT_SNSPISTOL_MK2_CAMO_06",//0x4DFA3621,
            "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE",//0xFA7B27A6,
            "COMPONENT_SNSPISTOL_MK2_CAMO_07",//0x42E91FFF,
            "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE",//0xE285CA9A,
            "COMPONENT_SNSPISTOL_MK2_CAMO_08",//0x54A8437D,
            "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE",//0x2B904B19,
            "COMPONENT_SNSPISTOL_MK2_CAMO_09",//0x68C2746,
            "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE",//0x22C24F9C,
            "COMPONENT_SNSPISTOL_MK2_CAMO_10",//0x2366E467,
            "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE",//0x8D0D5ECD,
            "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01",//0x441882E6,
            "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE",//0x1F07150A,
            "COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE",//0xE7EE68EA,
            "COMPONENT_SNSPISTOL_MK2_CLIP_01",//0x1466CE6,
            "COMPONENT_SNSPISTOL_MK2_CLIP_02",//0xCE8C0772,
            "COMPONENT_SNSPISTOL_MK2_CLIP_FMJ",//0xC111EB26,
            "COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT",//0x8D107402,
            "COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY",//0xE6AD5F79,
            "COMPONENT_SNSPISTOL_MK2_CLIP_TRACER",//0x902DA26E,
            "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER",//0x8033ECAF,
            "COMPONENT_SPECIALCARBINE_CLIP_01",//0xC6C7E581,
            "COMPONENT_SPECIALCARBINE_CLIP_02",//0x7C8BD10E,
            "COMPONENT_SPECIALCARBINE_CLIP_03",//0x6B59AEAA,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO",//0xD40BB53B,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_02",//0x431B238B,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_03",//0x34CF86F4,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_04",//0xB4C306DD,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_05",//0xEE677A25,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_06",//0xDF90DC78,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_07",//0xA4C31EE,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_08",//0x89CFB0F7,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_09",//0x7B82145C,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_10",//0x899CAF75,
            "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01",//0x5218C819,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_01",//0x16C69281,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_02",//0xDE1FA12C,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING",//0x51351635,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ",//0x503DEA90,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY",//0xDE011286,
            "COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER",//0x8765C68A,
            "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER",//0x730154F2,
            "COMPONENT_SWITCHBLADE_VARMOD_BASE",//0x9137A500,
            "COMPONENT_SWITCHBLADE_VARMOD_VAR1",//0x5B3E7DB6,
            "COMPONENT_SWITCHBLADE_VARMOD_VAR2",//0xE7939662,
            "COMPONENT_VINTAGEPISTOL_CLIP_01",//0x45A3B6BB,
            "COMPONENT_VINTAGEPISTOL_CLIP_02",//0x33BA12E8

            "COMPONENT_AT_AR_FLSH",//
            "COMPONENT_AT_AR_SUPP",//
            "COMPONENT_MILITARYRIFLE_CLIP_01",//
            "COMPONENT_MILITARYRIFLE_CLIP_02",//
            "COMPONENT_MILITARYRIFLE_SIGHT_01",//
            "COMPONENT_AT_SCOPE_SMALL",//
            "COMPONENT_AT_AR_FLSH",//
            "COMPONENT_AT_AR_SUPP",//

            "COMPONENT_HEAVYRIFLE_CLIP_01",// | 0x5AF49386
            "COMPONENT_HEAVYRIFLE_CLIP_02",//");// | 0x6CBF371B
            "COMPONENT_HEAVYRIFLE_SIGHT_01",// | 0xB3E1C452
            "COMPONENT_AT_SCOPE_MEDIUM",// | 0xA0D89C42
            "COMPONENT_AT_AR_FLSH",// | 0x7BC4CDDC
            "COMPONENT_AT_AR_SUPP",// | 0x837445AA
            "COMPONENT_AT_AR_AFGRIP",// | 0xC164F53
            "COMPONENT_HEAVYRIFLE_CAMO1",// | 0xEC9FECD9
            "COMPONENT_APPISTOL_VARMOD_SECURITY",//
            "COMPONENT_MICROSMG_VARMOD_SECURITY",//
            "COMPONENT_PUMPSHOTGUN_VARMOD_SECURITY",//

            "COMPONENT_AT_AR_FLSH_REH", //| 0x9DB1E023
            "COMPONENT_TACTICALRIFLE_CLIP_02", //| 0x8594554F
            "COMPONENT_AT_AR_SUPP_02", ///| 0xA73D4664
            "COMPONENT_AT_AR_AFGRIP", //| 0xC164F53

            "COMPONENT_PISTOLXM3_CLIP_01",
            "COMPONENT_PISTOLXM3_SUPP"
        };

        public static List<string> SuperList = new List<string>
        {
            "PFISTER811",//<!-- 811 -->
            "ADDER",//
            "AUTARCH",//
            "BANSHEE2",//<!-- Banshee 900R -->
            "BULLET",//
            "CHAMPION",//
            "CHEETAH",//
            "CYCLONE",//
            "DEVESTE",//
            "EMERUS",//
            "ENTITYXF",//
            "ENTITY2",//<!-- Entity XXR -->
            "SHEAVA",//<!-- ETR1 -->
            "FMJ",//
            "FURIA",//
            "GP1",//
            "IGNUS",//
            "INFERNUS",//
            "ITALIGTB",//
            "ITALIGTB2",//<!-- Itali GTB Custom -->
            "KRIEGER",//
            "LM87",//
            "OSIRIS",//
            "NERO",//
            "NERO2",//<!-- Nero Custom -->
            "PENETRATOR",//
            "LE7B",//<!-- RE-7B -->
            "REAPER",//
            "VOLTIC2",//<!-- Rocket Voltic -->
            "S80",//
            "SC1",//
            "SULTANRS",//
            "T20",//
            "TAIPAN",//
            "TEMPESTA",//
            "TEZERACT",//
            "THRAX",//
            "TIGON",//
            "TORERO2",//<!-- Torero XO -->
            "TURISMOR",//
            "TYRANT",//
            "TYRUS",//
            "VACCA",//
            "VAGNER",//
            "VISIONE",//
            "VOLTIC",//
            "PROTOTIPO",//<!-- X80 Proto -->
            "XA21",//
            "ZENO",//
            "ZENTORNO",//
            "ZORRUSSO",//
            //"entity3",//Overflod Entity MT - 0x6838FC1D 
            "virtue",//Ocelot Virtue - 0x27E34161 
            "turismo3",     //0xF8AB457B"     //Super
            "pipistrello"     //0xF2AE3F81 "     //Super
        };
        public static List<string> SportList = new List<string>
        {
            "DRAFTER",//<!-- 8F Drafter -->
            "NINEF",//
            "NINEF2",//<!-- 9F Cabrio -->
            "TENF",//
            "TENF2",//<!-- 10F Widebody -->
            "ALPHA",//
            "BANSHEE",//
            "BESTIAGTS",//
            "BLISTA2",//<!-- Blista Compact -->
            "BUFFALO",//
            "BUFFALO2",//<!-- Buffalo S -->
            "CALICO",//<!-- Calico GTF -->
            "CARBONIZZARE",//
            "COMET2",//<!-- Comet -->
            "COMET3",//<!-- Comet Retro Custom -->
            "COMET6",//<!-- Comet S2 -->
            "COMET7",//<!-- Comet S2 Cabrio -->
            "COMET4",//<!-- Comet Safari -->
            "COMET5",//<!-- Comet SR -->
            "COQUETTE",//
            "COQUETTE4",//<!-- Coquette D10 -->
            "CORSITA",//
            "CYPHER",//
            "TAMPA2",//<!-- Drift Tampa -->
            "ELEGY",//<!-- Elegy Retro Custom -->
            "ELEGY2",//<!-- Elegy RH8 -->
            "EUROS",//
            "FELTZER2",//<!-- Feltzer -->
            "FLASHGT",//
            "FUROREGT",//
            "FUSILADE",//
            "FUTO",//
            "FUTO2",//<!-- Futo GTX -->
            "GB200",//
            "BLISTA3",//<!-- Go Go Monkey Blista -->
            "GROWLER",//
            "HOTRING",//
            "IMORGON",//
            "ISSI7",//<!-- Issi Sport -->
            "ITALIGTO",//
            "ITALIRSX",//
            "JESTER",//
            "JESTER2",//<!-- Jester (Racecar) -->
            "JESTER3",//<!-- Jester Classic -->
            "JESTER4",//<!-- Jester RR -->
            "JUGULAR",//
            "KHAMELION",//
            "KOMODA",//
            "KURUMA",//
            "LOCUST",//
            "LYNX",//
            "MASSACRO",//
            "MASSACRO2",//<!-- Massacro (Racecar) -->
            "NEO",//
            "NEON",//
            "OMNIS",//
            "OMNISEGT",//
            "PARAGON",//
            "PARIAH",//
            "PENUMBRA",//
            "PENUMBRA2",//<!-- Penumbra FF -->
            "RAIDEN",//
            "RAPIDGT",//
            "RAPIDGT2",//<!-- Rapid GT Cabrio -->
            "RAPTOR",//
            "REMUS",//
            "REVOLTER",//
            "RT3000",//
            "RUSTON",//
            "SCHAFTER4",//<!-- Schafter LWB -->
            "SCHAFTER3",//<!-- Schafter V12 -->
            "SCHLAGEN",//
            "SCHWARZER",//
            "SENTINEL3",//<!-- Sentinel Classic -->
            "SENTINEL4",//<!-- Sentinel Classic Widebody -->
            "SEVEN70",//
            "SM722",//
            "SPECTER",//
            "SPECTER2",//<!-- Specter Custom -->
            "BUFFALO3",//<!-- Sprunk Buffalo -->
            "STREITER",//
            "SUGOI",//
            "SULTAN",//
            "SULTAN2",//<!-- Sultan Classic -->
            "SULTAN3",//<!-- Sultan RS Classic -->
            "SURANO",//
            "TROPOS",//
            "VSTR",//<!-- V-STR -->
            "VECTRE",//
            "VERLIERER2",//
            "ZR350",//
            "everon2",//Karin Hotring Everon -  - 0xF82BC92E 
            "panthere",//Toundra Panthere -  - 0x7D326F04 
            "r300",//Annis 300R -  - 0x402586F8 
            "coureur",     //0x24626C26"     //Sports
            "gauntlet6",     //0x4FA9970B"     //Sports
            "stingertt",     //0x5649FF41"     //Sports
            "drifteuros",     //0x30F15228",     //Sports
            "driftfuto",     //0xF52D92EE",     //Sports
            "driftjester",     //0x96E6932D",     //Sports
            "driftremus",     //0x9F3273F4",     //Sports
            "drifttampa",     //0x9AE43988"     //Sports
            "driftzr350",     //0x72A6CEBE"     //Sports
            "paragon3",
            "niobe",
            "envisage",
            "driftsentinel",
            "driftcypher"
        };
        public static List<string> CoupeList = new List<string>
        {
            "COGCABRIO",//
            "EXEMPLAR",//
            "F620",//
            "FELON",//
            "FELON2",//<!-- Felon GT -->
            "JACKAL",//
            "KANJOSJ",//
            "ORACLE",//
            "ORACLE2",//<!-- Oracle XS -->
            "POSTLUDE",//
            "PREVION",//
            "SENTINEL2",//<!-- Sentinel -->
            "SENTINEL",//<!-- Sentinel XS -->
            "WINDSOR",//
            "WINDSOR2",//<!-- Windsor Drop -->
            "ZION",//
            "ZION2",//<!-- Zion Cabrio -->
            "driftfr36",     //0xA7C9F9A7"     //Coupes
            "fr36",     //0xE43C11E5"     //Coupes
            "eurosX32"
        };
        public static List<string> MuscleList = new List<string>
        {
            "DUKES3",//<!-- Beater Dukes -->
            "BLADE",//
            "BUCCANEER",//
            "BUCCANEER2",//<!-- Buccaneer Custom -->
            "BUFFALO4",//<!-- Buffalo STX -->
            "STALION2",//<!-- Burger Shot Stallion -->
            "CHINO",//
            "CHINO2",//<!-- Chino Custom -->
            "CLIQUE",//
            "COQUETTE3",//<!-- Coquette BlackFin -->
            "DEVIANT",//
            "DOMINATOR",//
            "DOMINATOR7",//<!-- Dominator ASP -->
            "DOMINATOR8",//<!-- Dominator GTT -->
            "DOMINATOR3",//<!-- Dominator GTX -->
            "YOSEMITE2",//<!-- Drift Yosemite -->
            "DUKES",//
            "ELLIE",//
            "FACTION",//
            "FACTION2",//<!-- Faction Custom -->
            "FACTION3",//<!-- Faction Custom Donk -->
            "GAUNTLET",//
            "GAUNTLET3",//<!-- Gauntlet Classic -->
            "GAUNTLET5",//<!-- Gauntlet Classic Custom -->
            "GAUNTLET4",//<!-- Gauntlet Hellfire -->
            "GREENWOOD",//
            "HERMES",//
            "HOTKNIFE",//
            "HUSTLER",//
            "IMPALER",//
            "SLAMVAN2",//<!-- Lost Slamvan -->
            "LURCHER",//
            "MANANA2",//<!-- Manana Custom -->
            "MOONBEAM",//
            "MOONBEAM2",//<!-- Moonbeam Custom -->
            "NIGHTSHADE",//
            "PEYOTE2",//<!-- Peyote Gasser -->
            "PHOENIX",//
            "PICADOR",//
            "DOMINATOR2",//<!-- Pisswasser Dominator -->
            "RATLOADER",//
            "RATLOADER2",//<!-- Rat-Truck -->
            "GAUNTLET2",//<!-- Redwood Gauntlet -->
            "RUINER",//
            "RUINER4",//<!-- Ruiner ZZ-8 -->
            "SABREGT",//
            "SABREGT2",//<!-- Sabre Turbo Custom -->
            "SLAMVAN",//
            "SLAMVAN3",//<!-- Slamvan Custom -->
            "STALION",//
            "TAMPA",//
            "TULIP",//
            "VAMOS",//
            "VIGERO",//
            "VIGERO2",//<!-- Vigero ZX -->
            "VIRGO",//
            "VIRGO3",//<!-- Virgo Classic -->
            "VIRGO2",//<!-- Virgo Classic Custom -->
            "VOODOO",//
            "VOODOO2",//<!-- Voodoo Custom -->
            "WEEVIL2",//<!-- Weevil Custom -->
            "YOSEMITE",//
            "PICADOR",//
            "broadway",//Classique Broadway -  - 0x8CC51028 
            "eudora",//Willard Eudora -  - 0xB581BF9A 
            "tahoma",//Declasse Tahoma Coupe -  - 0xE478B977 
            "tulip2",//Declasse Tulip M-100 -  - 0x1004EDA4 
            "brigham",     //0xD8FD24D1"     //Muscle
            "buffalo5",     //0x9E478B3"     //Muscle
            "clique2",     //0xC5A12E61"     //Muscle
            "dominator9",     //0xE5B3ACA1"     //Muscle
            "driftyosemite",     //0x9BC400EF"     //Muscle
            "impaler6",     //0xF55D2F7A"     //Muscle
            "Vigero3",     //0x1635C007"     //Muscle
            "dominator10"
        };
        public static List<string> SportClassList = new List<string>
        {
            "Z190",//<!-- 190z -->
            "ARDENT",//
            "CASCO",//
            "CHEBUREK",//
            "CHEETAH2",//<!-- Cheetah Classic -->
            "COQUETTE2",//<!-- Coquette Classic -->
            "DYNASTY",//
            "FAGALOA",//
            "BTYPE2",//<!-- FrÃ¤nken Stange -->
            "GT500",//
            "INFERNUS2",//<!-- Infernus Classic -->
            "JB700",//
            "JB7002",//<!-- JB 700W -->
            "MAMBA",//
            "MANANA",//
            "MICHELLI",//
            "MONROE",//
            "NEBULA",//
            "PEYOTE",//
            "PEYOTE3",//<!-- Peyote Custom -->
            "PIGALLE",//
            "RAPIDGT3",//<!-- Rapid GT Classic -->
            "RETINUE",//
            "RETINUE2",//<!-- Retinue MkII -->
            "BTYPE",//<!-- Roosevelt -->
            "BTYPE3",//<!-- Roosevelt Valor -->
            "SAVESTRA",//
            "STINGER",//
            "STINGERGT",//
            "FELTZER3",//<!-- Stirling GT -->
            "SWINGER",//
            "TORERO",//
            "TORNADO",//
            "TORNADO2",//<!-- Tornado Cabrio -->
            "TORNADO3",//<!-- Rusty Tornado -->
            "TORNADO4",//<!-- Mariachi Tornado -->
            "TORNADO5",//<!-- Tornado Custom -->
            "TORNADO6",//<!-- Tornado Rat Rod -->
            "TURISMO2",//<!-- Turismo Classic -->
            "VISERIS",//
            "ZTYPE",//
            "ZION3",//<!-- Zion Classic -->
            "driftnebula",
            "coquette5"
        };
        public static List<string> SedanList = new List<string>
        {
            "ASEA",//
            "ASTEROPE",//
            "CINQUEMILA",//
            "COGNOSCENTI",//
            "COG55",//<!-- Cognoscenti 55 -->
            "DEITY",//
            "EMPEROR",//
            "EMPEROR2",//<!-- Emperor beater variant -->
            "FUGITIVE",//
            "GLENDALE",//
            "GLENDALE2",//<!-- Glendale Custom -->
            "INGOT",//
            "INTRUDER",//
            "PREMIER",//
            "PRIMO",//
            "PRIMO2",//<!-- Primo Custom -->
            "REGINA",//
            "RHINEHART",//
            "ROMERO",//
            "SCHAFTER2",//
            "STAFFORD",//
            "STANIER",//
            "STRATUM",//
            "STRETCH",//
            "SUPERD",//
            "SURGE",//
            "TAILGATER",//
            "TAILGATER2",//<!-- Tailgater S -->
            "WARRENER",//
            "WARRENER2",//<!-- Warrener HKR -->
            "WASHINGTON",//
            "asterope2",     //0xD3D366B1"     //Sedans
            "impaler5",     //0xE3788BB1"     //Sedans
            "driftvorschlag",
            "vorschlaghammer"
        };
        public static List<string> SUVList = new List<string>
        {
            "ASTRON",//
            "BALLER",//
            "BALLER2",//<!-- Baller 2nd gen variant -->
            "BALLER3",//<!-- Baller LE -->
            "BALLER5",//<!-- Baller LE (Armored) -->
            "BALLER4",//<!-- Baller LE LWB -->
            "BALLER6",//<!-- Baller LE LWB (Armored) -->
            "BALLER7",//<!-- Baller ST -->
            "BJXL",//
            "CAVALCADE",//
            "CAVALCADE2",//<!-- Cavalcade 2nd gen variant -->
            "CONTENDER",//
            "DUBSTA",//
            "DUBSTA2",//<!-- Dubsta black variant -->
            "FQ2",//
            "GRANGER",//
            "GRANGER2",//<!-- Granger 3600LX -->
            "GRESLEY",//
            "HABANERO",//
            "HUNTLEY",//
            "IWAGEN",//
            "JUBILEE",//
            "LANDSTALKER",//
            "LANDSTALKER2",//<!-- Landstalker XL -->
            "MESA",//
            "NOVAK",//
            "PATRIOT",//
            "PATRIOT2",//<!-- Patriot Stretch -->
            "RADI",//
            "REBLA",//
            "ROCOTO",//
            "SEMINOLE",//
            "SEMINOLE2",//<!-- Seminole Frontier -->
            "SERRANO",//
            "SQUADDIE",//
            "TOROS",//
            "XLS",//
            "XLS2",//<!-- XLS (Armored) -->
            "MINIVAN",//
            "MINIVAN2",//<!-- Minivan Custom -->
            "aleutian",     //0xFDAEBF27"     //SUVs
            "baller8",     //0xCC8A305C"     //SUVs
            "cavalcade3",     //0xC29F8F4E"     //SUVs
            "dorado",     //0xD2389392"     //SUVs
            "vivanite",     //0xAE2CC02A"     //SUVs
            "castigator"
            //"issi8"//Weeny Issi Rally -  - 0x5C6C00B4 
        };
        public static List<string> CompactList = new List<string>
        {
            "ASBO",//
            "BLISTA",//
            "KANJO",//<!-- Blista Kanjo -->
            "BRIOSO",//
            "BRIOSO2",//<!-- Brioso 300 -->
            "BRIOSO3",//<!-- Brioso 300 Widebody -->
            "CLUB",//
            "DILETTANTE",//
            "DILETTANTE2",//<!-- Merryweather Dilettante -->
            "ISSI2",//
            "ISSI3",//<!-- Issi Classic -->
            "PANTO",//
            "PRAIRIE",//
            "RHAPSODY",//
            "WEEVIL"//
        };
        public static List<string> OffRoadList = new List<string>
        {
            "BOBCATXL",//
            "SADLER",//
            "CONTENDER",//
            "DUBSTA3",//<!-- Dubsta 6x6 -->
            "GUARDIAN",//
            "BIFTA",//
            "BODHI2",//
            "BRAWLER",//
            "CARACARA2",//<!-- Caracara 4x4 -->
            "TROPHYTRUCK2",//<!-- Desert Raid -->
            "DRAUGUR",//
            "DUBSTA3",//<!-- Dubsta 6x6 -->
            "DUNE",//
            "DLOADER",//
            "EVERON",//
            "FREECRAWLER",//
            "HELLION",//
            "BLAZER3",//<!-- Hot Rod Blazer -->
            "BFINJECTION",//
            "KALAHARI",//
            "KAMACHO",//
            "MESA3",//<!-- Merryweather Mesa -->
            "OUTLAW",//
            "PATRIOT3",//<!-- Patriot Mil-Spec -->
            "RANCHERXL",//
            "REBEL2",//
            "RIATA",//
            "REBEL",//<!-- Rusty Rebel -->
            "SANDKING2",//<!-- Sandking SWB -->
            "SANDKING",//<!-- Sandking XL -->
            "DUNE2",//<!-- Space Docker -->
            "TROPHYTRUCK",//
            "VAGRANT",//
            "WINKY",//
            "YOSEMITE3",//<!-- Yosemite Rancher -->
            "boor",//Karin Boor - 0x3B639C8D 
            "l35",     //0x96E0736B"     //Off-Road
            "monstrociti",     //0x2FDA9E05"     //Off-Road
            "ratel",     //0xE00BADAB"     //Off-Road
            "terminus",     //0x9FC300D"     //Off-Road
            "yosemite1500"
        };
        public static List<string> BennysVeh = new List<string>
        {
            "fcr",
            "diablous",
            "minivan",
            "faction",
            "moonbeam",
            "chino",
            "tornado",
            "virgo3",
            "primo",
            "buccaneer",
            "voodoo2",
            "slamvan",
            "sabregt",
            "peyote",
            "banshee",
            "glendale",
            "faction",
            "COMET2",
            "sultan",
            "specter",
            "elegy",
            "manana",
            "yosemite",
            "brioso2",
            "gauntlet3",
            "youga2",
            "italigtb",
            "nero"
        };
        public static List<string> MotorBikeList = new List<string>
        {
            "AKUMA",//
            "DEATHBIKE",//<!-- Apocalypse Deathbike -->
            "AVARUS",//
            "BAGGER",//
            "BATI",//
            "BATI2",//<!-- Bati 801RR -->
            "BF400",//
            "CARBONRS",//
            "CHIMERA",//
            "CLIFFHANGER",//
            "DAEMON",//<!-- Daemon Lost MC variant -->
            "DAEMON2",//<!-- Daemon Bikers DLC variant -->
            "DEFILER",//
            "DIABLOUS",//
            "DIABLOUS2",//<!-- Diabolus Custom -->
            "DOUBLE",//
            "ENDURO",//
            "ESSKEY",//
            "FAGGIO2",//
            "FAGGIO3",//<!-- Faggio Mod -->
            "FAGGIO",//<!-- Faggio Sport -->
            "FCR",//
            "FCR2",//<!-- FCR 1000 Custom -->
            "DEATHBIKE2",//<!-- Future Shock Deathbike -->
            "GARGOYLE",//
            "HAKUCHOU",//
            "HAKUCHOU2",//<!-- Hakuchou Drag -->
            "HEXER",//
            "INNOVATION",//
            "LECTRO",//
            "MANCHEZ",//
            "MANCHEZ2",//<!-- Manchez Scout -->
            "NEMESIS",//
            "NIGHTBLADE",//
            "DEATHBIKE3",//<!-- Nightmare Deathbike -->
            "OPPRESSOR",//
            "PCJ",//
            "RROCKET",//<!-- Rampant Rocket -->
            "RATBIKE",//
            "REEVER",//
            "RUFFIAN",//
            "SANCHEZ",//<!-- Sanchez livery variant -->
            "SANCHEZ2",//
            "SANCTUS",//
            "SHINOBI",//
            "SHOTARO",//
            "SOVEREIGN",//
            "STRYDER",//
            "THRUST",//
            "VADER",//
            "VINDICATOR",//
            "VORTEX",//
            "WOLFSBANE",//
            "ZOMBIEA",//<!-- Zombie Bobber -->
            "ZOMBIEB",//<!-- Zombie Chopper -->
            "BLAZER",//
            "BLAZER2",//<!-- Blazer Lifeguard -->
            "BLAZER4",//<!-- Street Blazer -->
            "VERUS",//
            "manchez3",//Maibatsu Manchez Scout C -  - 0x5285D628 
            "powersurge",//Western Powersurge -  - 0xAD5E30D7 
            "pizzaboy"
        };
        public static List<string> BusList = new List<string>
        {
            "AIRBUS",//
            "BUS",//
            "COACH",//<!-- Dashound -->
            "PBUS",
            "PBUS2",//<!-- Festival Bus -->
            "RENTALBUS",//<!-- Rental Shuttle Bus -->
            "TOURBUS"//
        };
        public static List<string> IndustrialList = new List<string>
        {
            "AIRTUG",//
            "CADDY",//<!-- Caddy golf variant -->
            "CADDY2",//<!-- Caddy civilian variant -->
            "CADDY3",//<!-- Caddy bunker variant -->
            "FAGGIO2",//
            "FAGGIO3",//<!-- Faggio Mod -->
            "FAGGIO",//<!-- Faggio Sport -->
            "TRACTOR2",//<!-- Fieldmaster -->
            "MOWER",//
            "SLAMTRUCK",//
            "MIXER",//
            "MIXER2",//<!-- Mixer 8-wheel variant -->
            "RUBBLE",//
            "TIPTRUCK",//<!-- Tipper 4-wheel variant -->
            "TIPTRUCK2",//<!-- Tipper 6-wheel variant -->
            "MONSTER",//<!-- Liberator -->
            "MARSHALL",//
            "BRICKADE",//
            "BULLDOZER",//
            "FORKLIFT",//
            "RIPLEY",//
            "TOWTRUCK2",//<!-- Tow Truck Slamvan variant -->
            "TOWTRUCK",//<!-- Towtruck Yankee variant -->
            "TRACTOR",//
            "TRASH",//
            "TRASH2",//<!-- Trashmaster heist variant -->
            "UTILLITRUCK",//<!-- Utility Truck cherry picker variant -->
            "UTILLITRUCK2",//<!-- Utility Truck flatbed variant -->
            "UTILLITRUCK3",//<!-- Utility Truck pick-up variant -->
            //"WASTLNDR",//FInd Correct Name
            "DUMP"//
        };
        public static List<string> TruckList = new List<string>
        {
            "barracks2",
            "HAULER",//
            "HAULER2",//<!-- Hauler Custom -->
            "PACKER",//
            "PHANTOM",//
            "PHANTOM3",//<!-- Phantom Custom -->
            "PHANTOM2",//<!-- Phantom Wedge -->
            "docktug"
        };
        public static List<string> ComercialList = new List<string>
        {
            "BISON",//
            "BISON2",//<!-- McGill-Olsen Bison -->
            "BISON3",//<!-- Mighty Bush Bison -->
            "BENSON",//
            "BIFF",//
            "FLATBED",//
            "MULE",//
            "MULE2",//<!-- Mule ramp door variant -->
            "MULE3",//<!-- Mule heist variant -->
            "MULE5",//<!-- Mule Contract DLC variant -->
            "MULE4",//<!-- Mule Custom -->
            "POUNDER",//
            "POUNDER2",//<!-- Pounder Custom -->
            "STOCKADE",//<!-- Securicar -->
            "TERBYTE",//
            "BOXVILLE5",//<!-- Armored Boxville -->
            "BOXVILLE",//<!-- LSDWP Boxville -->
            "BOXVILLE2",//<!-- Go Postal Boxville -->
            "BOXVILLE3",//<!-- Humane Labs Boxville -->
            "BOXVILLE4",//<!-- PostOp Boxville -->
            "BURRITO",//
            "BURRITO2",//<!-- Burrito Bugstars variant -->
            "BURRITO3",//<!-- Burrito civilian variant -->
            "BURRITO4",//<!-- Burrito McGill-Olsen variant -->
            "CAMPER",//
            "SPEEDO2",//<!-- Clown Van -->
            "GBURRITO",//<!-- Gang Burrito Lost MC variant -->
            "GBURRITO2",//<!-- Gang Burrito heist variant -->
            "JOURNEY",//
            "PARADISE",//
            "PONY",//
            "PONY2",//<!-- Pony Smoke on the Water variant -->
            "RUMPO",//
            "RUMPO2",//<!-- Rumpo Deludamol variant -->
            "RUMPO3",//<!-- Rumpo Custom -->
            "SPEEDO",//
            "SPEEDO4",//<!-- Speedo Custom -->
            "SURFER",//
            "SURFER2",//<!-- Surfer beater variant -->
            "TACO",//
            "YOUGA",//
            "YOUGA2",//<!-- Youga Classic -->
            "YOUGA3",//<!-- Youga Classic 4x4 -->
            "YOUGA4",//<!-- Youga Custom -->
            "RALLYTRUCK",//<!-- Dune -->
            "SCRAP",//  
            "brickade2", //MTL Brickade 6x6 - - 0xA2073353 
            "journey2",//Zirconium Journey II -  - 0x9F04C481 
            "surfer3"//BF Surfer Custom -  - 0xC247AEE5 
        };
        public static List<string> ArmoredList = new List<string>
        {
            "KURUMA2",//<!-- Kuruma (Armored) -->
            "PARAGON2",//<!-- Paragon R (Armored) -->
            "DUKES2",//<!-- Duke O'Death -->
            "COGNOSCENTI2",//<!-- Cognoscenti (Armored) -->
            "COG552",//<!-- Cognoscenti 55 (Armored) -->
            "SCHAFTER6",//<!-- Schafter LWB (Armored) -->
            "SCHAFTER5",//<!-- Schafter V12 (Armored) -->
            "INSURGENT",//
            "NIGHTSHARK"//
        };
        public static List<string> WeaponisedList = new List<string>
        {
            "BARRAGE",//
            "CARACARA",//  
            "CHERNOBOG",//
            "DELUXO",//
            "DUNE3",//<!-- Dune FAV -->
            "RUINER2",//<!-- Ruiner 2000 -->
            "SCRAMJET",//
            "TAMPA3",//<!-- Weaponized Tampa -->
            "LIMO2",//<!-- Turreted Limo -->
            "TECHNICAL",//
            "TECHNICAL3",//<!-- Technical Custom -->     
            "INSURGENT2",//<!-- Insurgent Pick-Up -->
            "INSURGENT3",//<!-- Insurgent Pick-Up Custom -->
            "MENACER",//
            "DUNE4",//<!-- Ramp Buggy mission variant -->
            "DUNE5",//<!-- Ramp Buggy -->
            "HALFTRACK",//          
            "RIOT2",//<!-- RCV -->
            "VIGILANTE",//
            "RHINO",//
            "KHANJALI"//<!-- TM-02 Khanjali -->
        };
        public static List<string> ArenaWarsList = new List<string>
        {
            "ISSI4",//<!-- Apocalypse Issi -->
            "ISSI5",//<!-- Future Shock Issi -->
            "ISSI6",//<!-- Nightmare Issi -->
            "ZR380",//<!-- Apocalypse ZR380 -->
            "ZR3802",//<!-- Future Shock ZR380 -->
            "ZR3803",//<!-- Nightmare ZR380 -->
            "DOMINATOR4",//<!-- Apocalypse Dominator -->
            "IMPALER2",//<!-- Apocalypse Impaler -->
            "IMPERATOR",//<!-- Apocalypse Imperator -->
            "SLAMVAN4",//<!-- Apocalypse Slamvan -->
            "CERBERUS",//<!-- Apocalypse Cerberus -->
            "DOMINATOR5",//<!-- Future Shock Dominator -->
            "IMPALER3",//<!-- Future Shock Impaler -->
            "IMPERATOR2",//<!-- Future Shock Imperator -->
            "SLAMVAN5",//<!-- Future Shock Slamvan -->
            "DOMINATOR6",//<!-- Nightmare Dominator -->
            "IMPALER4",//<!-- Nightmare Impaler -->
            "IMPERATOR3",//<!-- Nightmare Imperator -->
            "SLAMVAN6",//<!-- Nightmare Slamvan -->
            "CERBERUS2",//<!-- Future Shock Cerberus -->
            "CERBERUS3",//<!-- Nightmare Cerberus -->
            "BRUTUS",//<!-- Apocalypse Brutus -->
            "MONSTER3",//<!-- Apocalypse Sasquatch -->       
            "BRUISER",//<!-- Apocalypse Bruiser -->
            "BRUISER2",//<!-- Future Shock Bruiser -->
            "BRUTUS2",//<!-- Future Shock Brutus -->
            "MONSTER4",//<!-- Future Shock Sasquatch -->
            "BRUISER3",//<!-- Nightmare Bruiser -->
            "BRUTUS3",//<!-- Nightmare Brutus -->
            "MONSTER5",//<!-- Nightmare Sasquatch -->
            "SCARAB",//<!-- Apocalypse Scarab -->
            "SCARAB2",//<!-- Future Shock Scarab -->
            "SCARAB3"//<!-- Nightmare Scarab -->
        };
        public static List<string> OpenWheelList = new List<string>
        {
            "OPENWHEEL1",//<!-- BR8, should be Open Wheel class -->
            "OPENWHEEL2",//<!-- DR1, should be Open Wheel class -->
            "FORMULA",//<!-- PR4, should be Open Wheel class -->
            "FORMULA2"//<!-- R88, should be Open Wheel class -->
        };
        public static List<string> CartList = new List<string>
        {
            "VETO",//<!-- Veto Classic -->
            "VETO2"//<!-- Veto Modern -->
        };
        public static List<string> CycleList = new List<string>
        {
            "BMX",//
            "CRUISER",//
            "TRIBIKE2",//<!-- Endurex Race Bike -->
            "FIXTER",//
            "SCORCHER",//
            "TRIBIKE3",//<!-- Tri-Cycles Race Bike -->
            "TRIBIKE",//<!-- Whippet Race Bike -->
            "inductor",     //0xCA7C4AE9"     //Cycles
            "inductor2"     //0x89C45478"     //Cycles
        };
        public static List<string> PlaneComList = new List<string>
        {
            "ALPHAZ1",
            "BESRA",//
            "CUBAN800",//
            "DODO",//
            "DUSTER",//
            "HOWARD",//<!-- Howard NX-25 -->
            "LUXOR",//
            "LUXOR2",//<!-- Luxor Deluxe -->
            "STUNT",//<!-- Mallard -->
            "MAMMATUS",//
            "MOGUL",//
            "NIMBUS",//
            "NOKOTA",//<!-- P-45 Nokota -->
            "SEABREEZE",//
            "SHAMAL",//
            "MICROLIGHT",//<!-- Ultralight -->
            "VELUM",//
            "VELUM2",//<!-- Velum 5-Seater -->
            "VESTRA",//
            "raiju",     //0xE4C8C4D"     //Planes
            "streamer216"     //0xB706A72"     //Planes
        };
        public static List<string> PlaneFightList = new List<string>
        {
            "HYDRA",//
            "LAZER",//<!-- P-996 LAZER -->
            "MOLOTOK",//<!-- V-65 Molotok -->
            "PYRO",//
            "ROGUE",//
            "STARLING"//<!-- LF-22 Starling -->
        };
        public static List<string> HeliComList = new List<string>
        {
            "BUZZARD2",//<!-- Buzzard -->
            "FROGGER",//
            "FROGGER2",//<!-- Frogger Trevor Philips Industries variant -->
            "HAVOK",//
            "MAVERICK",//
            "POLMAV",//
            "SEASPARROW",//
            "SEASPARROW2",//<!-- Sparrow -->
            "SUPERVOLITO",//
            "SUPERVOLITO2",//<!-- SuperVolito Carbon -->
            "SWIFT",//
            "SWIFT2",//<!-- Swift Deluxe -->
            "VOLATUS",//
            "CARGOBOB",//<!-- Military Cargobob -->
            "CARGOBOB2",//<!-- Jetsam Cargobob -->
            "CARGOBOB3",//<!-- Cargobob Trevor Philips Industries variant -->
            "CARGOBOB4",//<!-- Cargobob Drop Zone variant -->
            "CONADA"//
        };
        public static List<string> HeliFightList = new List<string>
        {
            "AKULA",//
            "ANNIHILATOR",//
            "ANNIHILATOR2",//<!-- Annihilator Stealth -->
            "BUZZARD",//<!-- Buzzard Attack Chopper -->
            "HUNTER",//<!-- FH-1 Hunter -->
            "SAVAGE",//
            "VALKYRIE",//
            "VALKYRIE2",//<!-- Valkyrie MOD.0 -->
            "conada2"     //0x9D1D9872"     //Helicopters
        };
        public static List<string> BoatList = new List<string>
        {
            "DINGHY",//
            "DINGHY2",//<!-- Dinghy 2-seater variant -->
            "DINGHY3",//<!-- Dinghy heist variant -->
            "DINGHY4",//<!-- Dinghy yacht variant -->
            "DINGHY5",//<!-- Dinghy weaponized variant -->
            "JETMAX",//
            "LONGFIN",//<!-- Shitzu Longfin -->
            "MARQUIS",//
            "PREDATOR",//
            "PATROLBOAT",//<!-- Kurtz 31 Patrol Boat -->
            "SEASHARK",//
            "SEASHARK2",//<!-- Lifeguard Seashark -->
            "SEASHARK3",//<!-- Seashark yacht variant -->
            "SPEEDER",//
            "SPEEDER2",//<!-- Speeder yacht variant -->
            "SQUALO",//
            "SUNTRAP",//
            "TORO",//
            "TORO2",//<!-- Toro yacht variant -->
            "TROPIC",//
            "TROPIC2",//<!-- Tropic yacht variant -->
        };
        public static List<string> FloatersList = new List<string>
        {
            "APC",//
            "TECHNICAL2",//<!-- Technical Aqua -->
            "BLAZER5",//<!-- Blazer Aqua -->
            "STROMBERG",//
            "TOREADOR",//
            "ZHABA"//
        };
        public static List<string> TowingList = new List<string>
        {
            "SADLER", //
            "BISON", //
            "BISON2", //<!-- McGill-Olsen Bison -->
            "BISON3", //<!-- Mighty Bush Bison -->
            "BOBCATXL", //
            "INSURGENT3", //<!-- Insurgent Pick-Up Custom -->
            "TECHNICAL3" //<!-- Technical Custom -->
        };
        public static List<string> SubList = new List<string>
        {
            "AVISA",//<!-- Kraken Avisa -->
            "SUBMERSIBLE2",//<!-- Kraken -->
            "SUBMERSIBLE",//
        };
        public static List<string> JetSkiList = new List<string>
        {
            "SEASHARK",//
            "SEASHARK2",//<!-- Lifeguard Seashark -->
            "SEASHARK3"//<!-- Seashark yacht variant -->
        };
        public static List<string> PlaneOverSizeList = new List<string>
        {
            "CARGOPLANE",//
            "JET",//
            "MILJET",//
            "BOMBUSHKA",//<!-- RM-10 Bombushka -->
            "ALKONOST",//<!-- RO-86 Alkonost -->
            "TITAN",//
            "VOLATOL",//
            "cargoplane2",//Cargo Plane 0x8B4864E1 
            "STRIKEFORCE",//<!-- B-11 Strikeforce -->
            "TULA"//
        };
        public static List<string> CustomList = new List<string>();
        public static List<string> MCBikeList = new List<string>
        {
            "DEATHBIKE",//<!-- Apocalypse Deathbike -->
            "AVARUS",//
            "BAGGER",//
            "CHIMERA",//
            "CLIFFHANGER",//
            "DAEMON",//<!-- Daemon Lost MC variant -->
            "DAEMON2",//<!-- Daemon Bikers DLC variant -->
            "DEATHBIKE2",//<!-- Future Shock Deathbike -->
            "GARGOYLE",//
            "HEXER",//
            "INNOVATION",//
            "NIGHTBLADE",//
            "DEATHBIKE3",//<!-- Nightmare Deathbike -->
            "RROCKET",//<!-- Rampant Rocket -->
            "RATBIKE",//
            "REEVER",//
            "RUFFIAN",//
            "SANCTUS",//
            "SOVEREIGN",//
            "WOLFSBANE",//
            "ZOMBIEA",//<!-- Zombie Bobber -->
            "ZOMBIEB",//<!-- Zombie Chopper -->
        };
        public static Crash4Cash DamageControl { get; set; }

        private static readonly List<string> CiggsAch = new List<string>
        {
            "prop_champ_01a",
            "v_ret_247_cigs",
            "prop_bottle_cognac",
            "prop_whiskey_bottle",
            "v_ret_ml_beerpride",
            "winerow",
            "v_ret_ml_beeram",
            "v_ret_ml_beerpis2",
            "v_ret_ml_cigs5",
            "v_ret_ml_beerbar",
            "v_ret_ml_cigs6",
            "v_ret_ml_beerbla1",
            "v_ret_ml_cigs2",
            "beerrow_world",
            "v_ret_ml_cigs",
            "v_ret_ml_beerdus",
            "vodkarow",
            "v_ret_ml_beerlog1",
            "prop_beer_am",
            "v_ret_ml_cigs4",
            "v_ret_ml_beerben1",
            "beerrow_local",
            "prop_crate_11e",
            "spiritsrow",
            "v_ret_ml_beerpis1",
            "v_ret_ml_cigs3"
        };
        private static readonly List<string> IPlate = new List<string>
        {
            "JU52FKU",
            "ZR0 KIDZ",
            "MUAHAHA",
            "P54CH0",
            "B88B8BB",
            "P004MAD",
            "CARDIEM",
            "MNNGFUL",
            "SU55PCT",
            "M11LFS",
            "G5POT",
            "H0R5SH1T",
            "CU11NNT",
            "PB4UGO",
            "PMS247",
            "HUF4RTD",
            "N1NJA",
            "STFUPLZ",
            "3JOH22A",
            "4EVERL8",
            "KSMYGAS",
            "EASYRDR",
            "CYABYE",
            "JEDIIAM",
            "X32iAR0",
            "JC51BEL",
            "D4TBOI",
            "YSOFFCR",
            "TPL55FUN",
            "A5RSE",
            "BE11END",
            "UT02SER",
            "PENN15",
            "UG04POO"
        };
        private static readonly List<VehBlips> vehBlips = new List<VehBlips>
        {
            new VehBlips("BUFFALO4",825),
            new VehBlips("CHAMPION",824),
            new VehBlips("DEITY",823),
            new VehBlips("GRANGER2",821),
            new VehBlips("JUBILEE",820),
            new VehBlips("PATRIOT3",818),
            new VehBlips("CRUSADER",800),
            new VehBlips("SLAMVAN2",799),
            new VehBlips("SLAMVAN3", 799),
            new VehBlips("VALKYRIE", 759),
            new VehBlips("VALKYRIE2", 759),
            new VehBlips("SQUADDIE", 757),
            new VehBlips("ardent", 756),///Retro Sport...       
            new VehBlips("cheetah2", 756),///Retro Sport...      
            new VehBlips("infernus2", 756),///Retro Sport...      
            new VehBlips("monroe", 756),///Retro Sport...      
            new VehBlips("stromberg", 756),///Retro Sport...      
            new VehBlips("torero", 756),///Retro Sport...      
            new VehBlips("turismo2", 756),///Retro Sport...      
            new VehBlips("toreador", 756),///Retro Sport...         
            new VehBlips("PATROLBOAT",755),
            new VehBlips("DINGHY5",754),
            new VehBlips("DINGHY5",754),
            new VehBlips("seasparrow2", 753),
            new VehBlips("barracks", 750),
            new VehBlips("barracks3", 750),
            new VehBlips("verus", 749),
            new VehBlips("veto2", 748),
            new VehBlips("veto", 747),
            new VehBlips("avisa", 746),
            new VehBlips("WINKY", 745),
            new VehBlips("ZHABA", 737),
            new VehBlips("VAGRANT", 736),
            new VehBlips("OUTLAW", 735),
            new VehBlips("everon", 734),
            new VehBlips("formula",726),
            new VehBlips("formula2",726),
            new VehBlips("openwheel1",726),
            new VehBlips("openwheel2",726),
            new VehBlips("STRETCH",724),
            new VehBlips("ZR380", 669),
            new VehBlips("ZR3802", 669),
            new VehBlips("ZR3803", 669),
            new VehBlips("SLAMVAN4", 668),
            new VehBlips("SLAMVAN5", 668),
            new VehBlips("SLAMVAN6", 668),
            new VehBlips("SCARAB", 667),
            new VehBlips("SCARAB2", 667),
            new VehBlips("SCARAB3", 667),
            new VehBlips("MONSTER3", 666),
            new VehBlips("MONSTER4", 666),
            new VehBlips("MONSTER5", 666),
            new VehBlips("ISSI4", 665),
            new VehBlips("ISSI5", 665),
            new VehBlips("ISSI6", 665),
            new VehBlips("IMPERATOR", 664),
            new VehBlips("IMPERATOR2", 664),
            new VehBlips("IMPERATOR3", 664),
            new VehBlips("IMPALER2", 663),
            new VehBlips("IMPALER3", 663),
            new VehBlips("IMPALER4", 663),
            new VehBlips("DOMINATOR4", 662),
            new VehBlips("DOMINATOR5", 662),
            new VehBlips("DOMINATOR6", 662),
            new VehBlips("CERBERUS", 660),
            new VehBlips("CERBERUS2", 660),
            new VehBlips("CERBERUS3", 660),
            new VehBlips("BRUTUS", 659),
            new VehBlips("BRUTUS2", 659),
            new VehBlips("BRUTUS3", 659),
            new VehBlips("BRUISER", 658),
            new VehBlips("BRUISER2", 658),
            new VehBlips("BRUISER3", 658),
            new VehBlips("STRIKEFORCE", 640),
            new VehBlips("OPPRESSOR2", 639),
            new VehBlips("SPEEDO4", 637),
            new VehBlips("MULE4", 636),
            new VehBlips("POUNDER2", 635),
            new VehBlips("scramjet", 634),
            new VehBlips("ambulance",632),
            new VehBlips("pbus2",631),
            new VehBlips("caracara",613),
            new VehBlips("seasparrow", 612),
            new VehBlips("APC", 603),
            new VehBlips("akula", 602),
            new VehBlips("insurgent", 601),
            new VehBlips("insurgent3", 601),
            new VehBlips("volatol", 600),
            new VehBlips("alkonost", 600),
            new VehBlips("KHANJALI", 598),
            new VehBlips("DELUXO",  596),
            new VehBlips("bombushka", 585),
            new VehBlips("seabreeze", 584),
            new VehBlips("STARLING", 583),
            new VehBlips("ROGUE", 582),
            new VehBlips("PYRO", 581),
            new VehBlips("nokota", 580),
            new VehBlips("MOLOTOK", 579),
            new VehBlips("mogul", 578),
            new VehBlips("microlight", 577),
            new VehBlips("HUNTER", 576),
            new VehBlips("howard", 575),
            new VehBlips("havok", 574),
            new VehBlips("tula", 573),
            new VehBlips("alphaz1", 572),
            new VehBlips("tampa3", 562),//truureted something
            new VehBlips("DUNE3", 561),
            new VehBlips("HALFTRACK", 560),
            new VehBlips("OPPRESSOR", 559),
            //new VehBlips("", 558),//something somthing turreted
            new VehBlips("TECHNICAL2", 534),
            new VehBlips("voltic2", 533),
            new VehBlips("wastelander", 532),
            new VehBlips("DUNE4", 531),
            new VehBlips("DUNE5", 531),
            new VehBlips("RUINER2", 530),
            new VehBlips("PHANTOM2", 528),
            new VehBlips("hakuchou",522),//ModSportsBike
            new VehBlips("hakuchou2",522),//ModSportsBike
            new VehBlips("shotaro",522),//ModSportsBike
            new VehBlips("pbus",513),//BusssAny
            new VehBlips("blazer",512),//QuadAny
            new VehBlips("blazer2",512),//QuadAny
            new VehBlips("blazer3",512),//QuadAny
            new VehBlips("blazer4",512),//QuadAny
            new VehBlips("blazer5",512),//QuadAny
            new VehBlips("cargobob", 481),
            new VehBlips("cargobob2", 481),
            new VehBlips("cargobob3", 481),
            new VehBlips("cargobob4", 481),
            new VehBlips("armytanker", 479),//Trailler Box
            new VehBlips("armytrailer", 479),//Trailler Box
            new VehBlips("baletrailer", 479),//Trailler Box
            new VehBlips("boattrailer", 479),//Trailler Box
            new VehBlips("docktrailer", 479),//Trailler Box
            new VehBlips("freighttrailer", 479),//Trailler Box
            new VehBlips("graintrailer", 479),//Trailler Box
            new VehBlips("tr2", 479),//Trailler Box
            new VehBlips("tr3", 479),//Trailler Box
            new VehBlips("tr4", 479),//Trailler Box
            new VehBlips("trflat", 479),//Trailler Box
            new VehBlips("tvtrailer", 479),//Trailler Box
            new VehBlips("tanker", 479),//Trailler Box
            new VehBlips("tanker2", 479),//Trailler Box
            new VehBlips("trailerlarge", 479),//Trailler Box
            new VehBlips("trailerlogs", 479),//Trailler Box
            new VehBlips("trailersmall", 479),//Trailler Box
            new VehBlips("tanker", 479),//Trailler Box
            new VehBlips("trailers", 479),//Trailler Box
            new VehBlips("trailers2", 479),//Trailler Box
            new VehBlips("trailers3", 479),//Trailler Box
            new VehBlips("trailers4", 479),//Trailler Box
            new VehBlips("barracks2", 477),//Truck any---not intrucks
            new VehBlips("scrap", 477),//Truck any---not intrucks
            new VehBlips("towtruck", 477),//Truck any---not intrucks
            new VehBlips("rallytruck", 477),//Truck any---not intrucks
            new VehBlips("brickade", 477),//Truck any---not intrucks
            new VehBlips("firetruk",477),
            new VehBlips("seashark", 471),//Seashark
            new VehBlips("seashark2", 471),//Seashark
            new VehBlips("seashark3", 471),//Seashark
            new VehBlips("limo2", 460),
            new VehBlips("technical", 426),
            new VehBlips("technical3", 426),
            new VehBlips("RHINO", 421),
            new VehBlips("marquis",410),
            new VehBlips("avarus",348),//lost bike
            new VehBlips("chimera",348),//lost bike
            new VehBlips("cliffhanger",348),//lost bike
            new VehBlips("daemon",348),//lost bike
            new VehBlips("daemon2",348),//lost bike
            new VehBlips("gargoyle",348),//lost bike
            new VehBlips("hexer",348),//lost bike
            new VehBlips("innovation",348),//lost bike
            new VehBlips("ratbike",348),//lost bike
            new VehBlips("sanctus",348),//lost bike
            new VehBlips("wolfsbane",348),//lost bike
            new VehBlips("zombiea",348),//lost bike
            new VehBlips("zombieb",348),//lost bike
            new VehBlips("trash",318),
            new VehBlips("trash2",318),
            new VehBlips("submersible",308),
            new VehBlips("submersible2",308),
            new VehBlips("jet",307),
            new VehBlips("luxor",307),
            new VehBlips("luxor2",307),
            new VehBlips("miljet",307),
            new VehBlips("nimbus",307),
            new VehBlips("shamal",307),
            new VehBlips("vestra",307),
            new VehBlips("velum",251),
            new VehBlips("velum2",251),
            new VehBlips("stunt",251),
            new VehBlips("mammatus",251),
            new VehBlips("duster",251),
            new VehBlips("dodo",251),
            new VehBlips("cuban800",251),
            new VehBlips("taxi",198),
            new VehBlips("dune",147),
            new VehBlips("stockade",67),
            new VehBlips("trailersmall2",563),
            new VehBlips("docktug",477)
        };
        public static string VehName = "";
        private static string LastVeh = "New";

        public static string WhatpedType()
        {
            string Pt = "";
            if (Game.Player.Character.Model == PedHash.Franklin)
                Pt = "Franklin";
            else if (Game.Player.Character.Model == PedHash.Michael)
                Pt = "Michael";
            else if (Game.Player.Character.Model == PedHash.Trevor)
                Pt = "Trevor";
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
                Pt = "FreeFemale";
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
                Pt = "FreeMale";
            else
                Pt = "" + Game.Player.Character.Model.Hash;
            return Pt;

        }
        public static bool HittingTheBottle(int BottleHash)
        {
            bool B = false;
            for (int i = 0; i < CiggsAch.Count; i++)
            {
                if (BottleHash == Function.Call<int>(Hash.GET_HASH_KEY, CiggsAch[i]))
                    B = true;
            }
            return B;
        }
        public static int WhereAreYou()
        {
            LoggerLight.LogThis("WhereAreYou");

            int iAm;

            Vector3 PlayPos = Game.Player.Character.Position;
            string MyZone = World.GetZoneNameLabel(PlayPos);
            Vector3 Cayo = new Vector3(4713f, -5190f, 1f);
            Vector3 Side01 = new Vector3(-6505f, 6682f, 1f);
            Vector3 Side02 = new Vector3(5293f, -3045f, 1f);
            if (PlayPos.DistanceTo(Cayo) < 1500f)
                iAm = 7;
            else if (PlayPos.DistanceTo(Side01) < 4800f)
                iAm = 8;
            else if (PlayPos.DistanceTo(Side02) < 2300f)
                iAm = 9;
            else if (MyZone == "AIRP" || MyZone == "ELYSIAN" || MyZone == "TERMINA" || MyZone == "CYPRE" || MyZone == "EBURO" || MyZone == "MURRI" || MyZone == "BANNING" || MyZone == "RANCHO" || MyZone == "DAVIS" || MyZone == "STAD" || MyZone == "LOSPUER" || MyZone == "CHAMH" || MyZone == "STRAW" || MyZone == "LMESA" || MyZone == "DELSOL")
                iAm = 1;
            else if (MyZone == "SKID" || MyZone == "LEGSQU" || MyZone == "TEXTI" || MyZone == "PBOX" || MyZone == "DTVINE" || MyZone == "KOREAT" || MyZone == "VCANA" || MyZone == "VESP" || MyZone == "BEACH" || MyZone == "DELBE" || MyZone == "DELPE" || MyZone == "SanAnd" || MyZone == "MOVIE" || MyZone == "MORN" || MyZone == "ROCKF" || MyZone == "BURTON" || MyZone == "ALTA" || MyZone == "HAWICK" || MyZone == "WVINE" || MyZone == "golf")
                iAm = 2;
            else if (MyZone == "RICHM" || MyZone == "PBLUFF" || MyZone == "BHAMCA" || MyZone == "BANHAMC" || MyZone == "CHU" || MyZone == "RGLEN" || MyZone == "TONGVAH" || MyZone == "TONGVAV" || MyZone == "LAGO")
                iAm = 3;
            else if (MyZone == "PALHIGH" || MyZone == "NOOSE" || MyZone == "TATAMO" || MyZone == "MIRR" || MyZone == "EAST_V" || MyZone == "HORS" || MyZone == "CHIL" || MyZone == "PALMPOW" || MyZone == "WINDF" || MyZone == "VINE" || MyZone == "LDAM" || MyZone == "LACT")
                iAm = 4;
            else if (MyZone == "GREATC" || MyZone == "ZANCUDO" || MyZone == "SLAB" || MyZone == "DESRT" || MyZone == "HARMO" || MyZone == "RTRAK" || MyZone == "JAIL" || MyZone == "ZQ_UAR" || MyZone == "SANDY" || MyZone == "ALAMO" || MyZone == "SANCHIA" || MyZone == "HUMLAB" || MyZone == "GRAPES" || MyZone == "GALFISH")
                iAm = 5;
            else if (MyZone == "OCEANA")
            {
                if (PlayPos.Y < -1941.00f)
                    iAm = 1;
                else if (PlayPos.X > 1480.00f && PlayPos.Y < 2450.00f)
                    iAm = 4;
                else if (PlayPos.X < -830.00f && PlayPos.Y < -420.00f)
                    iAm = 2;
                else if (PlayPos.X < -2150.00f && PlayPos.Y > -420.00f && PlayPos.Y < 3580.00f)
                    iAm = 3;
                else if (PlayPos.X > 2460.00f && PlayPos.Y < 5140.00f)
                    iAm = 5;
                else
                    iAm = 6;
            }
            else
                iAm = 6;

            return iAm;
        }
        public static int OhMyBlip(Vehicle MyVehic)
        {
            LoggerLight.LogThis("OhMyBlip");

            int iBeLip = 0;
            if (MyVehic != null)
            {
                int iVehHash = MyVehic.Model.GetHashCode();

                if (MyVehic.ClassType == VehicleClass.Boats)
                    iBeLip = 427;
                else if (MyVehic.ClassType == VehicleClass.Helicopters)
                    iBeLip = 64;
                else if (MyVehic.ClassType == VehicleClass.Motorcycles)
                    iBeLip = 226;
                else if (MyVehic.ClassType == VehicleClass.Planes)
                    iBeLip = 424;
                else if (MyVehic.ClassType == VehicleClass.Vans)
                    iBeLip = 616;
                else if (MyVehic.ClassType == VehicleClass.Commercial)//mule
                    iBeLip = 477;
                else if (MyVehic.ClassType == VehicleClass.Industrial)//trucks
                    iBeLip = 477;
                else if (MyVehic.ClassType == VehicleClass.Service)//buss
                    iBeLip = 513;
                else if (MyVehic.ClassType == VehicleClass.Super)
                    iBeLip = 595;
                else if (MyVehic.ClassType == VehicleClass.Sports)
                    iBeLip = 523;
                else if (MyVehic.ClassType == VehicleClass.Cycles)
                    iBeLip = 376;
                else
                    iBeLip = 225;

                for (int i = 0; i < vehBlips.Count; i++)
                {
                    if (iVehHash == Function.Call<int>(Hash.GET_HASH_KEY, vehBlips[i].VehicleKey))
                        iBeLip = vehBlips[i].BlipNo;
                }
            }

            return iBeLip;
        }
        public static string UnderScoring(string sting)
        {
            string NewTing = "";
            for (int i = 0; i < sting.Length; i++)
            {
                char sPlop = sting[i];
                if (char.IsWhiteSpace(sPlop))
                    NewTing += "_";
                else
                    NewTing += sPlop;
            }
            return NewTing;
        }
        public static string FunPlates()
        {
            LoggerLight.LogThis("FunPlates");
            return IPlate[RandomX.FindRandom("FunPlate01", 0, IPlate.Count - 1)];
        }
        public static int PickThatVeh(int selecta, Vehicle vehick, Vector4 vSpot, int vehList, bool bMods)
        {
            string VicName = GetEntName(VehName);
            UiDisplay.ControlerUI("~INPUT_DETONATE~ " + VicName + " ~INPUT_CONTEXT~", 1);

            if (Game.IsControlJustPressed(2, GTA.Control.Detonate))
            {
                selecta --;
                VehName = SelectAVeh(vehList, selecta);
                if (VehName == "ResetToZero")
                    selecta = 0;
                else if (VehName.Contains("ResetTo"))
                {
                    int iNum = VehName.LastIndexOf("ResetTo") + 7;
                    VehName = VehName.Substring(iNum);
                    selecta = (int)Convert.ToInt32(VehName);
                    selecta--;
                }
            }
            else if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
                selecta++;
                VehName = SelectAVeh(vehList, selecta);

                if (VehName == "ResetToZero")
                    selecta = 0;
                else if (VehName.Contains("ResetTo"))
                {
                    int iNum = VehName.LastIndexOf("ResetTo") + 7;
                    VehName = VehName.Substring(iNum);
                    selecta = (int)Convert.ToInt32(VehName);
                    selecta--;
                }
            }

            if (LastVeh != VehName)
            {
                VehName = SelectAVeh(vehList, selecta);
                MissionData.VehicleList_01.Remove(vehick);
                vehick.CurrentBlip.Remove();
                vehick.Delete();
                MissionData.MishVeh = EntityBuild.VehicleSpawn(new VehMods(VehName, 1, 66, true, DataStore.MyLang.Maptext[1], false, bMods, FunPlates()), vSpot);
                LastVeh = VehName;
            }
            return selecta;
        }
        public static bool IsItARealVehicle(string sVehName)
        {
            LoggerLight.LogThis("IsItARealVehicle, == " + sVehName);
            bool bIsReal = false;

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehName);

            if (Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
                bIsReal = true;

            return bIsReal;
        }
        public static int WhatVehicleAreYou(string sVehName)
        {
            LoggerLight.LogThis("WhatVehicleAreYou, == " + sVehName);

            int iAm = Function.Call<int>(Hash.GET_VEHICLE_CLASS_FROM_NAME, Function.Call<int>(Hash.GET_HASH_KEY, sVehName));

            if (iAm == 16)
                iAm = 2;
            else if (iAm == 14)
                iAm = 3;
            else if (iAm == 15)
                iAm = 4;
            else
                iAm = 1;

            return iAm;
        }
        public static bool Water05_CargoBobed(Vehicle MyVick)
        {
            bool bCargoAttached = false;
            if (Game.Player.Character.IsInVehicle())
            {
                if (Function.Call<bool>(Hash.IS_VEHICLE_ATTACHED_TO_CARGOBOB, Game.Player.Character.CurrentVehicle.Handle, MyVick.Handle))
                    bCargoAttached = true;
            }
            return bCargoAttached;
        }
        public static bool BeenSpotted(Ped Guard, Ped Target, bool bAlive)
        {
            bool bSeeingYou = false;

            if (bAlive)
            {
                Vector3 Vdir = (Target.Position - Guard.Position).Normalized;
                float fDirValue = Vector3.Dot(Vdir, Guard.ForwardVector);
                if (Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY, Guard.Handle, Target.Handle, 17) || Function.Call<bool>(Hash.CAN_PED_HEAR_PLAYER, Target.Handle, Guard.Handle))
                {
                    if (Guard.Position.DistanceTo(Target.Position) < 35.00f)
                    {
                        if (fDirValue > 0.25f)
                            bSeeingYou = true;
                    }
                }
                else if (Guard.IsInCombatAgainst(Target))
                    bSeeingYou = true;
            }
            else
            {
                Vector3 Vdir = (Target.Position - Guard.Position).Normalized;
                float fDirValue = Vector3.Dot(Vdir, Guard.ForwardVector);
                if (Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY, Guard.Handle, Target.Handle, 17) || Function.Call<bool>(Hash.CAN_PED_HEAR_PLAYER, Target.Handle, Guard.Handle))
                {
                    if (Guard.Position.DistanceTo(Target.Position) < 35.00f)
                    {
                        if (fDirValue > 0.25f)
                            bSeeingYou = true;
                    }
                }
            }


            if (bSeeingYou)
                Guard.CurrentBlip.Color = BlipColor.Orange;


            return bSeeingYou;
        }
        public static int TempAgency_06_WhatsMyName(string sLabel)
        {
            int iAm = 0;

            if (sLabel == "ch_prop_toolbox_01a")
                iAm = 89;
            else if (sLabel == "prop_tool_wrench")
                iAm = 90;
            else if (sLabel == "ch_prop_ch_bag_02a")
                iAm = 91;
            else if (sLabel == "hei_prop_heist_box")
                iAm = 92;
            else if (sLabel == "ba_prop_battle_rsply_crate_02a")
                iAm = 92;
            else if (sLabel == "gr_prop_gr_rsply_crate01a")
                iAm = 92;
            else if (sLabel == "gr_prop_gr_rsply_crate03a")
                iAm = 92;
            else if (sLabel == "prop_drop_crate_01")
                iAm = 92;
            else if (sLabel == "prop_suitcase_03")
                iAm = 93;
            else if (sLabel == "sm_prop_smug_crate_s_hazard")
                iAm = 94;
            else if (sLabel == "v_med_barrel")
                iAm = 98;
            else if (sLabel == "xs_prop_arena_barrel_01a_sf")
                iAm = 99;
            else if (sLabel == "prop_barrel_02b")
                iAm = 100;
            else if (sLabel == "ba_prop_battle_control_console")
                iAm = 101;
            else if (sLabel == "v_med_testtubes")
                iAm = 102;
            else if (sLabel == "ba_prop_club_smoke_machine")
                iAm = 103;

            return iAm;
        }
        public static List<Vector3> FarToNear(List<Vector3> ListToFix, Vector3 vStartPoint)
        {
            LoggerLight.LogThis("FarToNear");

            List<Vector3> NewVList = new List<Vector3>();
            float fDist = 9999f;
            int NextVic = -1;
            int NearTo = 0;

            while (ListToFix.Count != 0)
            {
                for (int i = 0; i < ListToFix.Count; i++)
                {
                    float f = ListToFix[i].DistanceTo(vStartPoint);
                    if (f < fDist)
                    {
                        NextVic = i;
                        fDist = f;
                    }
                }

                if (NextVic == -1)
                {
                    NearTo++;
                }
                else
                {
                    NewVList.Add(ListToFix[NextVic]);
                    ListToFix.RemoveAt(NextVic);
                    fDist = 9999f;
                    NextVic = -1;
                }
                Script.Wait(1);
            }

            return NewVList;
        }
        public static List<Vector3> FarToNear(List<Vector3> ListToFix, Vector4 vStartPoint)
        {
            return FarToNear(ListToFix, new Vector3(vStartPoint.X, vStartPoint.Y, vStartPoint.Z));
        }
        public static List<Vehicle> FarToNear(List<Vehicle> ListToFix, Vector3 vStartPoint)
        {
            LoggerLight.LogThis("FarToNear");

            List<Vehicle> NewVList = new List<Vehicle>();
            float fDist = 9999f;
            int NextVic = -1;
            int NearTo = 0;

            while (ListToFix.Count != 0)
            {
                for (int i = 0; i < ListToFix.Count; i++)
                {
                    float f = ListToFix[i].Position.DistanceTo(vStartPoint);
                    if (f < fDist)
                    {
                        NextVic = i;
                        fDist = f;
                    }
                }

                if (NextVic == -1)
                {
                    NearTo++;
                }
                else
                {
                    NewVList.Add(ListToFix[NextVic]);
                    ListToFix.RemoveAt(NextVic);
                    fDist = 9999f;
                    NextVic = -1;
                }
                Script.Wait(1);
            }

            return NewVList;
        }
        public static List<string> ListReverseString(List<string> StrList)
        {

            LoggerLight.LogThis("ListReverseString");

            List<string> SortedList = new List<string>();

            int iList = StrList.Count;

            while (iList > 0)
            {
                iList -= 1;
                SortedList.Add(StrList[iList]);
            }

            return SortedList;
        }
        public static List<float> ListReversefloat(List<float> FlowList)
        {

            LoggerLight.LogThis("ListReversefloat");

            List<float> SortedList = new List<float>();

            int iList = FlowList.Count;

            while (iList > 0)
            {
                iList -= 1;
                SortedList.Add(FlowList[iList]);
            }

            return SortedList;
        }
        public static int MultiDamage(bool bShowPool, bool bPosative, int myPlace)
        {
            int iAmDamagedBy = DamageControl.HealthTotal;
            int iChaChing = DamageControl.CashTotal;
            if (DamageControl != null)
            {
                for (int i = 0; i < DamageControl.VehX.Count; i++)
                {
                    float fVehCheck = DamageControl.VehX[i].BodyHealth + DamageControl.VehX[i].EngineHealth + DamageControl.VehX[i].PetrolTankHealth;
                    iAmDamagedBy -= (int)fVehCheck;
                }

                for (int i = 0; i < DamageControl.PedX.Count; i++)
                    iAmDamagedBy -= DamageControl.PedX[i].Health;

                if (!bPosative)
                {
                    if (iAmDamagedBy > DamageControl.CurrentDamage)
                        DamageControl.CurrentDamage = iAmDamagedBy;
                    else
                        iAmDamagedBy = DamageControl.CurrentDamage;
                }
                float someMath = DamageControl.CashTotal / DamageControl.HealthTotal;

                someMath = someMath * iAmDamagedBy;

                if (bPosative)
                {
                    iChaChing -= DamageControl.CashTotal;
                    iChaChing += (int)someMath;
                }
                else
                    iChaChing -= (int)someMath;
            }

            if (bShowPool)
                UiDisplay.SideBars[myPlace].Data = "$ " + ShowComs(iChaChing, true, false) + "";

            return iChaChing;
        }
        public static string RandNPC(int iRando)
        {
            LoggerLight.LogThis("RandNPC, iRando == " + iRando);

            List<string> sPeds = new List<string>();

            string sPedds = "";

            if (iRando == 1)
            {
                sPeds.Add("a_m_m_og_boss_01");    //"OG Boss" />
                sPeds.Add("g_f_y_ballas_01");    //" Female" />
                sPeds.Add("g_m_y_ballaeast_01");    //"Ballas East Male" />
                sPeds.Add("g_m_y_ballaorig_01");    //"Ballas Original Male" />
                sPeds.Add("g_m_y_ballasout_01");    //"Ballas South Male" />
            }            //Ballas
            else if (iRando == 2)
            {
                sPeds.Add("mp_m_famdd_01");    //"Families DD Male" />
                sPeds.Add("g_f_y_families_01");    //"Families Female" />
                sPeds.Add("g_m_y_famca_01");    //"Families CA Male" />
                sPeds.Add("g_m_y_famdnf_01");    //"Families DNF Male" />
                sPeds.Add("g_m_y_famfor_01");    //"Families FOR Male" />
            }       //Families
            else if (iRando == 3)
            {
                sPeds.Add("g_f_importexport_01");    //"Import Export Female" />
                sPeds.Add("g_f_importexport_01");    //"Gang Female (Import-Export)" />
                sPeds.Add("g_m_importexport_01");    //"Gang Male (Import-Export)" />
            }       //Gang (Import-Export)
            else if (iRando == 4)
            {
                sPeds.Add("g_f_y_vagos_01");    //"Vagos Female" />
                sPeds.Add("g_f_y_lost_01");    //"The Lost MC Female" />
                sPeds.Add("g_m_y_lost_01");    //"The Lost MC Male" />
                sPeds.Add("g_m_y_lost_02");    //"The Lost MC Male 2" />
                sPeds.Add("g_m_y_lost_03");    //"The Lost MC Male 3" />
                sPeds.Add("a_m_m_mlcrisis_01");    //"Midlife Crisis Casino Bikers" />
                sPeds.Add("mp_m_exarmy_01");    //"Ex-Army Male" />
                sPeds.Add("A_F_M_GenBiker_01"); // 0x749B5065
                sPeds.Add("A_M_M_GenBiker_01"); // 0xDEE17D7E
            }       //The Lost MC
            else if (iRando == 5)
            {
                sPeds.Add("g_m_m_korboss_01");    //"Korean Boss" />
                sPeds.Add("g_m_y_korlieut_01");    //"Korean Lieutenant" />
                sPeds.Add("g_m_y_korean_01");    //"Korean Young Male" />
                sPeds.Add("g_m_y_korean_02");    //"Korean Young Male 2" />
                sPeds.Add("a_m_m_ktown_01");    //"Korean Male" />
                sPeds.Add("a_m_o_ktown_01");    //"Korean Old Male" />
                sPeds.Add("a_m_y_ktown_01");    //"Korean Young Male" />
                sPeds.Add("a_m_y_ktown_02");    //"Korean Young Male 2" />
            }       //Korean
            else if (iRando == 6)
            {
                sPeds.Add("g_m_m_armboss_01");    //"Armenian Boss" />
                sPeds.Add("g_m_m_armgoon_01");    //"Armenian Goon" />
                sPeds.Add("g_m_y_armgoon_02");    //"Armenian Goon 2" />
                sPeds.Add("g_m_m_armlieut_01");    //"Armenian Lieutenant" />
            }       //Armenian
            else if (iRando == 7)
            {
                sPeds.Add("g_m_m_chiboss_01");    //"Chinese Boss" />
                sPeds.Add("g_m_m_chigoon_01");    //"Chinese Goon" />
                sPeds.Add("g_m_m_chigoon_02");    //"Chinese Goon 2" />
                sPeds.Add("g_m_m_chicold_01");    //"Chinese Goon Older" />
            }       //Chinese
            else if (iRando == 8)
            {
                sPeds.Add("g_m_m_mexboss_01");    //"Mexican Boss" />
                sPeds.Add("g_m_m_mexboss_02");    //"Mexican Boss 2" />
                sPeds.Add("g_m_y_mexgang_01");    //"Mexican Gang Member" />
                sPeds.Add("g_m_y_mexgoon_01");    //"Mexican Goon" />
                sPeds.Add("g_m_y_mexgoon_02");    //"Mexican Goon 2" />
                sPeds.Add("g_m_y_mexgoon_03");    //"Mexican Goon 3" />
                sPeds.Add("a_m_y_mexthug_01");    //"Mexican Thug" />
            }       //Mexican
            else if (iRando == 9)
            {
                sPeds.Add("g_m_y_pologoon_01");    //"Polynesian Goon" />
                sPeds.Add("g_m_y_pologoon_02");    //"Polynesian Goon 2" />
                sPeds.Add("a_m_m_polynesian_01");    //"Polynesian" />
                sPeds.Add("a_m_y_polynesian_01");    //"Polynesian Young" />
            }       //Polynesian
            else if (iRando == 10)
            {
                sPeds.Add("g_m_y_salvaboss_01");    //"Salvadoran Boss" />
                sPeds.Add("g_m_y_salvagoon_01");    //"Salvadoran Goon" />
                sPeds.Add("g_m_y_salvagoon_02");    //"Salvadoran Goon 2" />
                sPeds.Add("g_m_y_salvagoon_03");    //"Salvadoran Goon 3" />
            }       //Salvadoran
            else if (iRando == 11)
            {
                sPeds.Add("mp_m_g_vagfun_01");    //"Vagos Funeral" />
            }       //Vargos
            else if (iRando == 12)
            {
                sPeds.Add("g_m_y_strpunk_01");    //"Street Punk" />
                sPeds.Add("g_m_y_strpunk_02");    //"Street Punk 2" />
            }       //Street Punk
            else if (iRando == 13)
            {
                sPeds.Add("a_f_m_eastsa_01");    //"East SA Female" />
                sPeds.Add("a_f_m_eastsa_02");    //"East SA Female 2" />
                sPeds.Add("a_f_y_eastsa_01");    //"East SA Young Female" />
                sPeds.Add("a_f_y_eastsa_02");    //"East SA Young Female 2" />
                sPeds.Add("a_f_y_eastsa_03");    //"East SA Young Female 3" />
                sPeds.Add("a_m_m_eastsa_01");    //"East SA Male" />
                sPeds.Add("a_m_m_eastsa_02");    //"East SA Male 2" />
                sPeds.Add("a_m_y_eastsa_01");    //"East SA Young Male" />
                sPeds.Add("a_m_y_eastsa_02");    //"East SA Young Male 2" />
            }       //East SA
            else if (iRando == 14)
            {
                sPeds.Add("a_f_o_genstreet_01");    //"General Street Old Female" />
                sPeds.Add("a_m_o_genstreet_01");    //"General Street Old Male" />
                sPeds.Add("a_m_y_genstreet_01");    //"General Street Young Male" />
                sPeds.Add("a_m_y_genstreet_02");    //"General Street Young Male 2" />
                sPeds.Add("a_m_y_stbla_01");    //"Black Street Male" />
                sPeds.Add("a_m_y_stbla_02");    //"Black Street Male 2" />
                sPeds.Add("a_m_m_stlat_02");    //"Latino Street Male 2" />
                sPeds.Add("a_m_y_stlat_01");    //"Latino Street Young Male" />
                sPeds.Add("a_m_y_latino_01");    //"Latino Young Male" />
                sPeds.Add("a_m_m_afriamer_01");    //"African American Male" />
                sPeds.Add("a_m_y_stwhi_01");    //"White Street Male" />
                sPeds.Add("a_m_y_stwhi_02");    //"White Street Male 2" />
                sPeds.Add("a_m_y_ktown_01");    //"Korean Young Male" />
                sPeds.Add("a_m_y_ktown_02");    //"Korean Young Male 2" />
                sPeds.Add("a_m_m_polynesian_01");    //"Polynesian" />
                sPeds.Add("a_m_y_polynesian_01");    //"Polynesian Young" />
                sPeds.Add("a_m_m_eastsa_01");    //"East SA Male" />
                sPeds.Add("a_m_m_eastsa_02");    //"East SA Male 2" />
                sPeds.Add("a_f_m_ktown_01");    //"Korean Female" />
                sPeds.Add("a_f_m_ktown_02");    //"Korean Female 2" />
                sPeds.Add("a_f_o_ktown_01");    //"Korean Old Female" />
            }       //Street
            else if (iRando == 15)
            {
                sPeds.Add("a_f_m_soucent_01");    //"South Central Female" />
                sPeds.Add("a_f_m_soucent_02");    //"South Central Female 2" />
                sPeds.Add("a_f_m_soucentmc_01");    //"South Central MC Female" />
                sPeds.Add("a_f_o_soucent_01");    //"South Central Old Female" />
                sPeds.Add("a_f_o_soucent_02");    //"South Central Old Female 2" />
                sPeds.Add("a_f_y_soucent_01");    //"South Central Young Female" />
                sPeds.Add("a_f_y_soucent_02");    //"South Central Young Female 2" />
                sPeds.Add("a_f_y_soucent_03");    //"South Central Young Female 3" />
                sPeds.Add("a_m_m_socenlat_01");    //"South Central Latino Male" />
                sPeds.Add("a_m_m_soucent_01");    //"South Central Male" />
                sPeds.Add("a_m_m_soucent_02");    //"South Central Male 2" />
                sPeds.Add("a_m_m_soucent_03");    //"South Central Male 3" />
                sPeds.Add("a_m_m_soucent_04");    //"South Central Male 4" />
                sPeds.Add("a_m_o_soucent_01");    //"South Central Old Male" />
                sPeds.Add("a_m_o_soucent_02");    //"South Central Old Male 2" />
                sPeds.Add("a_m_o_soucent_03");    //"South Central Old Male 3" />
                sPeds.Add("a_m_y_soucent_01");    //"South Central Young Male" />
                sPeds.Add("a_m_y_soucent_02");    //"South Central Young Male 2" />
                sPeds.Add("a_m_y_soucent_03");    //"South Central Young Male 3" />
                sPeds.Add("a_m_y_soucent_04");    //"South Central Young Male 4" />
            }       //South Central
            else if (iRando == 16)
            {
                sPeds.Add("mp_f_stripperlite");    //"Stripper Lite (Female)" />
                sPeds.Add("s_f_y_stripper_01");    //"Stripper" />
                sPeds.Add("s_f_y_stripper_02");    //"Stripper 2" />
                sPeds.Add("s_f_y_stripperlite");    //"Stripper Lite" />
                sPeds.Add("u_f_y_danceburl_01");    //"Female Club Dancer (Burlesque)" />
                sPeds.Add("u_f_y_dancelthr_01");    //"Female Club Dancer (Leather)" />
                sPeds.Add("u_f_y_dancerave_01");    //"Female Club Dancer (Rave)" />
                sPeds.Add("u_m_y_danceburl_01");    //"Male Club Dancer (Burlesque)" />
                sPeds.Add("u_m_y_dancelthr_01");    //"Male Club Dancer (Leather)" />
                sPeds.Add("u_m_y_dancerave_01");    //"Male Club Dancer (Rave)" />
            }       //Dancers
            else if (iRando == 17)
            {
                sPeds.Add("a_m_y_busicas_01");    //"Business Casual" />
                sPeds.Add("a_m_m_business_01");    //"Business Male" />
                sPeds.Add("a_m_y_business_01");    //"Business Young Male" />
                sPeds.Add("a_m_y_business_02");    //"Business Young Male 2" />
                sPeds.Add("a_m_y_business_03");    //"Business Young Male 3" />
                sPeds.Add("a_m_y_smartcaspat_01");    //"Formel Casino Guests" />
            }       //Suits Male
            else if (iRando == 18)
            {
                sPeds.Add("a_f_m_bevhills_01");    //"Beverly Hills Female" />
                sPeds.Add("a_f_m_bevhills_02");    //"Beverly Hills Female 2" />
                sPeds.Add("a_f_y_bevhills_01");    //"Beverly Hills Young Female" />
                sPeds.Add("a_f_y_bevhills_02");    //"Beverly Hills Young Female 2" />
                sPeds.Add("a_f_y_bevhills_03");    //"Beverly Hills Young Female 3" />
                sPeds.Add("a_f_y_bevhills_04");    //"Beverly Hills Young Female 4" />
                sPeds.Add("a_f_m_downtown_01");    //"Downtown Female" />
                sPeds.Add("a_f_y_scdressy_01");    //"Dressy Female" />
                sPeds.Add("a_f_y_vinewood_01");    //"Vinewood Female" />
                sPeds.Add("a_f_y_vinewood_02");    //"Vinewood Female 2" />
                sPeds.Add("a_f_y_vinewood_03");    //"Vinewood Female 3" />
                sPeds.Add("a_f_y_vinewood_04");    //"Vinewood Female 4" />
                sPeds.Add("a_f_y_clubcust_01");    //"Club Customer Female 1" />
                sPeds.Add("a_f_y_clubcust_02");    //"Club Customer Female 2" />
                sPeds.Add("a_f_y_clubcust_03");    //"Club Customer Female 3" />
                sPeds.Add("u_f_y_hotposh_01");    //"Hot Posh Female" />
                sPeds.Add("g_m_m_casrn_01");    //"Casino Guests?" />
                sPeds.Add("a_m_m_bevhills_01");    //"Beverly Hills Male" />
                sPeds.Add("a_m_m_bevhills_02");    //"Beverly Hills Male 2" />
                sPeds.Add("a_m_y_bevhills_01");    //"Beverly Hills Young Male" />
                sPeds.Add("a_m_y_bevhills_02");    //"Beverly Hills Young Male 2" />
                sPeds.Add("a_m_y_downtown_01");    //"Downtown Male" />
                sPeds.Add("a_m_y_hipster_01");    //"Hipster Male" />
                sPeds.Add("a_m_y_hipster_02");    //"Hipster Male 2" />
                sPeds.Add("a_m_y_hipster_03");    //"Hipster Male 3" />
                sPeds.Add("a_m_m_tennis_01");    //"Tennis Player Male" />
                sPeds.Add("a_m_y_vindouche_01");    //"Vinewood Douche" />
                sPeds.Add("a_m_y_vinewood_01");    //"Vinewood Male" />
                sPeds.Add("a_m_y_vinewood_02");    //"Vinewood Male 2" />
                sPeds.Add("a_m_y_vinewood_03");    //"Vinewood Male 3" />
                sPeds.Add("a_m_y_vinewood_04");    //"Vinewood Male 4" />
                sPeds.Add("a_m_y_clubcust_01");    //"Club Customer Male 1" />
                sPeds.Add("a_m_y_clubcust_02");    //"Club Customer Male 2" />
                sPeds.Add("a_m_y_clubcust_03");    //"Club Customer Male 3" />
                sPeds.Add("a_f_y_gencaspat_01");    //"Casual Casino Guest" />
                sPeds.Add("a_f_y_smartcaspat_01");    //"Formel Casino Guest" />
                sPeds.Add("a_f_y_hipster_01");    //"Hipster Female" />
                sPeds.Add("a_f_y_hipster_02");    //"Hipster Female 2" />
                sPeds.Add("a_f_y_hipster_03");    //"Hipster Female 3" />
                sPeds.Add("a_f_y_hipster_04");    //"Hipster Female 4" />
                sPeds.Add("a_f_y_tennis_01");    //"Tennis Player Female" />
                sPeds.Add("a_f_y_femaleagent");    //"Female Agent" />
                sPeds.Add("a_f_y_genhot_01");    //"General Hot Young Female" />
                sPeds.Add("a_m_y_gencaspat_01");    //"Casual Casino Guests" />
                sPeds.Add("a_m_y_smartcaspat_01");    //"Formel Casino Guests" />
            }       //HiClassStreet
            else if (iRando == 19)
            {
                sPeds.Add("a_f_m_business_02");    //"Business Female 2" />
                sPeds.Add("a_f_y_business_01");    //"Business Young Female" />
                sPeds.Add("a_f_y_business_02");    //"Business Young Female 2" />
                sPeds.Add("a_f_y_business_03");    //"Business Young Female 3" />
                sPeds.Add("a_f_y_business_04");    //"Business Young Female 4" />
            }       //Suits Female
            else if (iRando == 20)
            {
                sPeds.Add("a_m_m_hasjew_01");    //"Hasidic Jew Male" />
                sPeds.Add("a_m_y_hasjew_01");    //"Hasidic Jew Young Male" />
            }       //Hasidic
            else if (iRando == 21)
            {
                sPeds.Add("a_m_m_golfer_01");    //"Golfer Male" />
                sPeds.Add("a_m_y_golfer_01");    //"Golfer Young Male" />
                sPeds.Add("a_f_y_golfer_01");    //"Golfer Young Female" />
            }       //Golf
            else if (iRando == 22)
            {
                sPeds.Add("a_f_m_fatbla_01");    //"Fat Black Female" />
                sPeds.Add("a_f_m_fatcult_01");    //"Fat Cult Female" />
                sPeds.Add("a_f_m_fatwhite_01");    //"Fat White Female" />
                sPeds.Add("a_m_m_genfat_01");    //"General Fat Male" />
                sPeds.Add("a_m_m_genfat_02");    //"General Fat Male 2" />
                sPeds.Add("a_m_m_fatlatin_01");    //"Fat Latino Male" />
            }       //Fatties
            else if (iRando == 23)
            {
                sPeds.Add("a_m_m_indian_01");    //"Indian Male" />
                sPeds.Add("a_m_y_indian_01");    //"Indian Young Male" />
                sPeds.Add("a_f_o_indian_01");    //"Indian Old Female" />
                sPeds.Add("a_f_y_indian_01");    //"Indian Young Female" />
            }       //indian
            else if (iRando == 24)
            {
                sPeds.Add("a_m_y_juggalo_01");    //"Juggalo Male" />
                sPeds.Add("a_f_y_juggalo_01");    //"Juggalo Female" />
            }       //Juggalo
            else if (iRando == 25)
            {
                sPeds.Add("a_m_y_methhead_01");    //"Meth Addict" />
                sPeds.Add("a_f_y_rurmeth_01");    //"Rural Meth Addict Female" />
                sPeds.Add("a_f_m_salton_01");    //"Salton Female" />
                sPeds.Add("a_f_o_salton_01");    //"Salton Old Female" />
                sPeds.Add("a_m_m_hillbilly_01");    //"Hillbilly Male" />
                sPeds.Add("a_m_m_hillbilly_02");    //"Hillbilly Male 2" />
                sPeds.Add("a_m_m_rurmeth_01");    //"Rural Meth Addict Male" />
                sPeds.Add("a_m_m_farmer_01");    //"Farmer" />
                sPeds.Add("a_m_m_salton_01");    //"Salton Male" />
                sPeds.Add("a_m_m_salton_02");    //"Salton Male 2" />
                sPeds.Add("a_m_m_salton_03");    //"Salton Male 3" />
                sPeds.Add("a_m_m_salton_04");    //"Salton Male 4" />
                sPeds.Add("a_m_o_salton_01");    //"Salton Old Male" />
                sPeds.Add("a_m_y_salton_01");    //"Salton Young Male" />
                sPeds.Add("a_m_m_mexcntry_01");    //"Mexican Rural" />

            }       //Rural
            else if (iRando == 26)
            {
                sPeds.Add("a_f_m_skidrow_01");    //"Skid Row Female" />
                sPeds.Add("a_m_m_skidrow_01");    //"Skid Row Male" />
                sPeds.Add("a_m_m_tramp_01");    //"Tramp Male" />
                sPeds.Add("a_m_o_tramp_01");    //"Tramp Old Male" />
                sPeds.Add("a_f_m_tramp_01");    //"Tramp Female" />
                sPeds.Add("a_f_m_trampbeac_01");    //"Beach Tramp Female" />
                sPeds.Add("a_m_m_trampbeac_01");    //"Beach Tramp Male" />
            }       //Tramp
            else if (iRando == 27)
            {
                sPeds.Add("a_m_m_paparazzi_01");    //"Paparazzi Male" />
                sPeds.Add("s_f_y_bartender_01");    //"Bartender" />
                sPeds.Add("cs_bankman");    //"Bank Manager" />
                sPeds.Add("mp_s_m_armoured_01");    //"Armoured Van Security Male" />
                sPeds.Add("mp_f_cardesign_01");    //"Office Garage Mechanic (Female)" />
                sPeds.Add("mp_g_m_pros_01");    //"Pros" />
                sPeds.Add("mp_m_securoguard_01");    //"Securoserve Guard (Male)" />
                sPeds.Add("mp_m_shopkeep_01");    //"Shopkeeper (Male)" />
                sPeds.Add("mp_f_bennymech_01");    //"Benny Mechanic (Female)" />
                sPeds.Add("s_f_y_airhostess_01");    //"Air Hostess" />
                sPeds.Add("s_f_m_fembarber");    //"Barber Female" />
                sPeds.Add("s_f_y_casino_01");    //"Casino Staff" />
                sPeds.Add("s_f_y_factory_01");    //"Factory Worker Female" />
                sPeds.Add("s_f_y_hooker_01");    //"Hooker" />
                sPeds.Add("s_f_y_hooker_02");    //"Hooker 2" />
                sPeds.Add("s_f_y_hooker_03");    //"Hooker 3" />
                sPeds.Add("s_f_y_scrubs_01");    //"Hospital Scrubs Female" />
                sPeds.Add("s_f_m_maid_01");    //"Maid" />
                sPeds.Add("s_f_y_migrant_01");    //"Migrant Female" />
                sPeds.Add("s_f_m_sweatshop_01");    //"Sweatshop Worker" />
                sPeds.Add("s_f_y_sweatshop_01");    //"Sweatshop Worker Young" />
                sPeds.Add("s_f_y_clubbar_01");    //"Club Bartender Female" />
                sPeds.Add("s_m_m_armoured_01");    //"Armoured Van Security" />
                sPeds.Add("s_m_m_armoured_02");    //"Armoured Van Security 2" />
                sPeds.Add("s_m_y_autopsy_01");    //"Autopsy Tech" />
                sPeds.Add("s_m_m_autoshop_01");    //"Autoshop Worker" />
                sPeds.Add("s_m_m_autoshop_02");    //"Autoshop Worker 2" />
                sPeds.Add("s_m_y_barman_01");    //"Barman" />
                sPeds.Add("s_m_m_cntrybar_01");    //"Bartender (Rural)" />
                sPeds.Add("s_m_m_bouncer_01");    //"Bouncer" />
                sPeds.Add("s_m_y_busboy_01");    //"Busboy" />
                sPeds.Add("s_m_y_casino_01");    //"Casino Staff" />
                sPeds.Add("s_m_y_chef_01");    //"Chef" />
                sPeds.Add("s_m_m_chemsec_01");    //"Chemical Plant Security" />
                sPeds.Add("s_m_m_ccrew_01");    //"Crew Member" />
                sPeds.Add("s_m_m_dockwork_01");    //"Dock Worker" />
                sPeds.Add("s_m_y_dockwork_01");    //"Dock Worker" />
                sPeds.Add("s_m_m_doctor_01");    //"Doctor" />
                sPeds.Add("s_m_y_doorman_01");    //"Doorman" />
                sPeds.Add("s_m_y_airworker");    //"Air Worker Male" />
                sPeds.Add("s_m_y_dwservice_01");    //"DW Airport Worker" />
                sPeds.Add("s_m_y_dwservice_02");    //"DW Airport Worker 2" />
                sPeds.Add("s_m_y_factory_01");    //"Factory Worker Male" />
                sPeds.Add("s_m_m_gaffer_01");    //"Gaffer" />
                sPeds.Add("s_m_y_garbage");    //"Garbage Worker" />
                sPeds.Add("s_m_m_gardener_01");    //"Gardener" />
                sPeds.Add("s_m_y_grip_01");    //"Grip" />
                sPeds.Add("s_m_m_hairdress_01");    //"Hairdresser Male" />
                sPeds.Add("s_m_m_janitor");    //"Janitor" />
                sPeds.Add("s_m_m_lifeinvad_01");    //"Life Invader Male" />
                sPeds.Add("s_m_m_linecook");    //"Line Cook" />
                sPeds.Add("s_m_m_lsmetro_01");    //"LS Metro Worker Male" />
                sPeds.Add("s_m_y_xmech_01");    //"Mechanic" />
                sPeds.Add("s_m_m_migrant_01");    //"Migrant Male" />
                sPeds.Add("s_m_y_pestcont_01");    //"Pest Control" />
                sPeds.Add("s_m_m_postal_01");    //"Postal Worker Male" />
                sPeds.Add("s_m_m_postal_02");    //"Postal Worker Male 2" />
                sPeds.Add("s_m_y_shop_mask");    //"Mask Salesman" />
                sPeds.Add("s_m_m_scientist_01");    //"Scientist" />
                sPeds.Add("s_m_m_security_01");    //"Security Guard" />
                sPeds.Add("s_m_m_strvend_01");    //"Street Vendor" />
                sPeds.Add("s_m_y_strvend_01");    //"Street Vendor Young" />
                sPeds.Add("s_m_m_gentransport");    //"Transport Worker Male" />
                sPeds.Add("s_m_m_trucker_01");    //"Trucker Male" />
                sPeds.Add("s_m_m_ups_01");    //"UPS Driver" />
                sPeds.Add("s_m_m_ups_02");    //"UPS Driver 2" />
                sPeds.Add("s_m_y_uscg_01");    //"US Coastguard" />
                sPeds.Add("s_m_y_valet_01");    //"Valet" />
                sPeds.Add("s_m_y_waiter_01");    //"Waiter" />
                sPeds.Add("s_m_y_winclean_01");    //"Window Cleaner" />
                sPeds.Add("s_m_y_clubbar_01");    //"Club Bartender Male" />
                sPeds.Add("s_m_y_waretech_01");    //"Warehouse Technician" />
                sPeds.Add("u_f_m_casinocash_01");    //"Casino Cashier" />
                sPeds.Add("u_f_m_casinoshop_01");    //"Casino shop owner" />
                sPeds.Add("u_m_m_bankman");    //"Bank Manager Male" />
                sPeds.Add("u_m_m_bikehire_01");    //"Bike Hire Guy" />
                sPeds.Add("u_m_y_burgerdrug_01");    //"Burger Drug Worker" />
                sPeds.Add("u_m_y_gunvend_01");    //"Gun Vendor" />
                sPeds.Add("u_m_m_jewelsec_01");    //"Jeweller Security" />
                sPeds.Add("u_m_y_paparazzi");    //"Paparazzi Young Male" />
                sPeds.Add("u_m_y_tattoo_01");    //"Tattoo Artist" />
                sPeds.Add("g_m_m_chemwork_01");    //"Chemical Plant Worker" />
            }       //Workers
            else if (iRando == 28)
            {
                sPeds.Add("a_m_m_mexlabor_01");    //"Mexican Labourer" />
                sPeds.Add("s_m_y_construct_01");    //"construction Worker" />
                sPeds.Add("s_m_y_construct_02");    //"construction Worker 2" />
                sPeds.Add("s_m_m_lathandy_01");    //"Latino Handyman Male" />
            }       //construction
            else if (iRando == 29)
            {
                sPeds.Add("a_f_m_beach_01");    //"Beach Female" />
                sPeds.Add("A_F_Y_Beach_02");
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
                sPeds.Add("a_m_m_malibu_01");    //"Malibu Male" />
                sPeds.Add("a_m_y_sunbathe_01");    //"Sunbather Male" />
                sPeds.Add("a_m_y_hippy_01");    //"Hippie Male" />
                sPeds.Add("a_f_y_hippie_01");    //"Hippie Female" />
                sPeds.Add("a_m_y_beachvesp_01");    //"Vespucci Beach Male" />
                sPeds.Add("a_m_y_beachvesp_02");    //"Vespucci Beach Male 2" />
                sPeds.Add("u_m_y_party_01");    //"Partygoer" />
            }       //YachtParty
            else if (iRando == 30)
            {
                sPeds.Add("a_f_m_tourist_01");    //"Tourist Female" />
                sPeds.Add("a_f_y_tourist_01");    //"Tourist Young Female" />
                sPeds.Add("a_f_y_tourist_02");    //"Tourist Young Female 2" />
                sPeds.Add("a_m_m_tourist_01");    //"Tourist Male" />
            }       //Tourist 
            else if (iRando == 31)
            {
                sPeds.Add("a_f_m_beach_01");    //"Beach Female" />
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_f_m_bodybuild_01");    //"Bodybuilder Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_musclbeac_01");    //"Beach Muscle Male" />
                sPeds.Add("a_m_y_musclbeac_02");    //"Beach Muscle Male 2" />
                sPeds.Add("a_m_o_beach_01");    //"Beach Old Male" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
                sPeds.Add("a_m_m_malibu_01");    //"Malibu Male" />
                sPeds.Add("a_m_y_sunbathe_01");    //"Sunbather Male" />
                sPeds.Add("a_m_y_surfer_01");    //"Surfer" />
                sPeds.Add("a_m_y_yoga_01");    //"Yoga Male" />
                sPeds.Add("a_m_y_hippy_01");    //"Hippie Male" />
                sPeds.Add("a_f_y_hippie_01");    //"Hippie Female" />
                sPeds.Add("a_m_y_beachvesp_01");    //"Vespucci Beach Male" />
                sPeds.Add("a_m_y_beachvesp_02");    //"Vespucci Beach Male 2" />
                sPeds.Add("u_m_y_party_01");    //"Partygoer" />
            }       //Beach
            else if (iRando == 32)
            {
                sPeds.Add("u_m_y_baygor");    //"Kifflom Guy" />
                sPeds.Add("a_m_y_epsilon_01");    //"Epsilon Male" />
                sPeds.Add("a_m_y_epsilon_02");    //"Epsilon Male 2" />
                sPeds.Add("a_f_y_epsilon_01");    //"Epsilon Female" />
            }       //Epsilon
            else if (iRando == 33)
            {
                sPeds.Add("a_m_y_hiker_01");    //"Hiker Male" />
                sPeds.Add("a_f_y_hiker_01");    //"Hiker Female" />
                sPeds.Add("a_m_y_runner_01");    //"Jogger Male" />
                sPeds.Add("a_m_y_runner_02");    //"Jogger Male 2" />
                sPeds.Add("a_f_y_fitness_01");    //"Fitness Female" />
                sPeds.Add("a_f_y_fitness_02");    //"Fitness Female 2" />
                sPeds.Add("a_f_y_runner_01");    //"Jogger Female" />
                sPeds.Add("a_f_y_yoga_01");    //"Yoga Female" />
            }       //Outdoors
            else if (iRando == 34)
            {
                sPeds.Add("a_m_y_dhill_01");    //"Downhill Cyclist" />
                sPeds.Add("a_m_y_jetski_01");    //"Jetskier" />
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
                sPeds.Add("a_m_y_roadcyc_01");    //"Road Cyclist" />
                sPeds.Add("u_m_y_cyclist_01");    //"Cyclist Male" />
                sPeds.Add("u_m_y_sbike");    //"Sports Biker" />
            }       //Sports
            else if (iRando == 35)
            {
                sPeds.Add("a_m_m_skater_01");    //"Skater Male" />
                sPeds.Add("a_m_y_skater_01");    //"Skater Young Male" />
                sPeds.Add("a_m_y_skater_02");    //"Skater Young Male 2" />
                sPeds.Add("a_f_y_skater_01");    //"Skater Female" />
            }       //Skater
            else if (iRando == 36)
            {
                sPeds.Add("a_m_y_breakdance_01");    //"Breakdancer Male" />
                sPeds.Add("a_m_y_gay_01");    //"Gay Male" />
                sPeds.Add("a_m_y_gay_02");    //"Gay Male 2" />
                sPeds.Add("a_m_m_tranvest_01");    //"Transvestite Male" />
                sPeds.Add("a_m_m_tranvest_02");    //"Transvestite Male 2" />
                sPeds.Add("csb_bride");    //"Bride" />
                sPeds.Add("s_m_m_movalien_01");    //"Alien" />
                sPeds.Add("s_m_y_mime");    //"Mime Artist" />
                sPeds.Add("s_m_y_clown_01");    //"Clown" />
                sPeds.Add("s_m_o_busker_01");    //"Busker" />
                sPeds.Add("s_m_m_mariachi_01");    //"Mariachi" />
                sPeds.Add("s_m_m_movspace_01");    //"Movie Astronaut" />
                sPeds.Add("s_m_y_prisoner_01");    //"Prisoner" />
                sPeds.Add("s_m_y_prismuscl_01");    //"Prisoner (Muscular)" />
                sPeds.Add("s_m_y_robber_01");    //"Robber" />
                sPeds.Add("s_m_m_strperf_01");    //"Street Performer" />
                sPeds.Add("s_m_m_strpreach_01");    //"Street Preacher" />
                sPeds.Add("u_f_y_spyactress");    //"Spy Actress" />
                sPeds.Add("u_m_y_imporage");    //"Impotent Rage" />
                sPeds.Add("u_m_y_pogo_01");    //"Pogo the Monkey" />
                sPeds.Add("u_m_y_prisoner_01");    //"Prisoner" />
                sPeds.Add("u_m_y_rsranger_01");    //"Republican Space Ranger" />
                sPeds.Add("u_m_y_zombie_01");    //"Zombie" />
            }       //Novalty
            else if (iRando == 37)
            {
                sPeds.Add("a_f_y_clubcust_01");
                sPeds.Add("a_f_y_clubcust_02");
                sPeds.Add("a_f_y_clubcust_03");
                sPeds.Add("a_f_y_clubcust_04");
                sPeds.Add("a_m_y_clubcust_01");
                sPeds.Add("a_m_y_clubcust_02");
                sPeds.Add("a_m_y_clubcust_03");
                sPeds.Add("a_m_y_clubcust_04");
                sPeds.Add("a_f_y_bevhills_01");    //"Beverly Hills Young Female" />
                sPeds.Add("a_f_y_bevhills_02");    //"Beverly Hills Young Female 2" />
                sPeds.Add("a_f_y_bevhills_03");    //"Beverly Hills Young Female 3" />
                sPeds.Add("a_f_y_bevhills_04");    //"Beverly Hills Young Female 4" />
                sPeds.Add("a_f_y_vinewood_01");    //"Vinewood Female" />
                sPeds.Add("a_f_y_vinewood_02");    //"Vinewood Female 2" />
                sPeds.Add("a_f_y_vinewood_03");    //"Vinewood Female 3" />
                sPeds.Add("a_f_y_vinewood_04");    //"Vinewood Female 4" />
                sPeds.Add("a_f_y_gencaspat_01");    
                sPeds.Add("a_f_y_smartcaspat_01");    
                sPeds.Add("a_m_y_gencaspat_01");
                sPeds.Add("a_m_y_smartcaspat_01");
            }       //clubing
            else if (iRando == 38)
            {
                sPeds.Add("G_M_M_CartelGuards_01");
                sPeds.Add("G_M_M_CartelGuards_02");
            }       //CayoMob
            else if (iRando == 39)
            {
                sPeds.Add("s_m_y_swat_01");    //"SWAT" />
                sPeds.Add("s_m_m_marine_01");    //"Marine" />
                sPeds.Add("s_m_m_marine_02");    //"Marine 2" />
                sPeds.Add("s_m_y_marine_01");    //"Marine Young" />
                sPeds.Add("s_m_y_marine_02");    //"Marine Young 2" />
                sPeds.Add("s_m_y_marine_03");    //"Marine Young 3" />
                sPeds.Add("s_m_y_blackops_01");    //"Black Ops Soldier" />
                sPeds.Add("s_m_y_blackops_02");    //"Black Ops Soldier 2" />
                sPeds.Add("s_m_y_blackops_03");    //"Black Ops Soldier 3" />
            }       //Black opps
            else if (iRando == 40)
            {
                sPeds.Add("mp_m_fibsec_01");    //"FIB Security" />
                sPeds.Add("s_m_m_fiboffice_01");    //"FIB Office Worker" />
                sPeds.Add("s_m_m_fiboffice_02");    //"FIB Office Worker 2" />
                sPeds.Add("s_m_m_fibsec_01");    //"FIB Security" />
                sPeds.Add("s_m_m_highsec_01");    //"High Security" />
                sPeds.Add("s_m_m_highsec_02");    //"High Security 2" />
                sPeds.Add("s_m_m_ciasec_01");    //"IAA Security" />
                sPeds.Add("u_m_m_doa_01");    //"DOA Man" />
            }       //Fib
            else if (iRando == 41)
            {

                sPeds.Add("s_m_y_ranger_01");    //"Ranger Male" />
                sPeds.Add("s_f_y_ranger_01");    //"Ranger Female" />
                sPeds.Add("s_m_y_sheriff_01");    //"Sheriff Male" />
                sPeds.Add("s_f_y_sheriff_01");    //"Sheriff Female" />
                sPeds.Add("s_m_y_hwaycop_01");    //"Highway Cop" />
                sPeds.Add("s_m_y_cop_01");    //"Cop Male" />
                sPeds.Add("s_f_y_cop_01");    //"Cop Female" />
            }       //Cops
            else if (iRando == 42)
            {
                sPeds.Add("s_f_y_baywatch_01");    //"Baywatch Female" />
                sPeds.Add("s_m_y_armymech_01");    //"Army Mechanic" />
                sPeds.Add("s_m_y_baywatch_01");    //"Baywatch Male" />
                sPeds.Add("csb_trafficwarden");    //"Traffic Warden" />
                sPeds.Add("s_m_y_fireman_01");    //"Fireman Male" />
                sPeds.Add("s_m_m_paramedic_01");    //"Paramedic" />
                sPeds.Add("s_m_m_prisguard_01");    //"Prison Guard" />
            }       //Random Services
            else if (iRando == 43)
            {
                sPeds.Add("mp_f_helistaff_01");    //"Heli-Staff Female" />
                sPeds.Add("s_m_m_pilot_01");    //"Pilot" />
                sPeds.Add("s_m_y_pilot_01");    //"Pilot" />
                sPeds.Add("s_m_m_pilot_02");    //"Pilot 2" />
            }       //Racist - Pilots
            else if (iRando == 44)
            {
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
            }       //Racist - Cuttin corners F1
            else if (iRando == 45)
            {
                sPeds.Add("a_m_y_jetski_01");    //"Jetskier" />
            }       //Racist - Jet ski
            else if (iRando == 46)
            {
                sPeds.Add("a_m_y_cyclist_01");    //"Cyclist Male" />
                sPeds.Add("a_m_y_dhill_01");    //"Downhill Cyclist" />
                sPeds.Add("a_m_y_roadcyc_01");    //"Road Cyclist" />
            }       //Racist - Bike race
            else if (iRando == 47)
            {
                sPeds.Add("s_m_y_armymech_01");    //"Army Mechanic" />
                sPeds.Add("s_m_y_blackops_01");    //"Black Ops Soldier" />
                sPeds.Add("s_m_y_blackops_02");    //"Black Ops Soldier 2" />
                sPeds.Add("s_m_y_blackops_03");    //"Black Ops Soldier 3" />
                sPeds.Add("s_m_m_marine_01");    //"Marine" />
                sPeds.Add("s_m_m_marine_02");    //"Marine 2" />
                sPeds.Add("s_m_y_marine_01");    //"Marine Young" />
                sPeds.Add("s_m_y_marine_02");    //"Marine Young 2" />
                sPeds.Add("s_m_y_marine_03");    //"Marine Young 3" />
            }       //Racist - Havoc
            else if (iRando == 48)
            {
                sPeds.Add("a_m_y_motox_01");    //"Motocross Biker" />
                sPeds.Add("a_m_y_motox_02");    //"Motocross Biker 2" />
                sPeds.Add("g_f_y_vagos_01");    //"Vagos Female" />
                sPeds.Add("g_f_y_lost_01");    //"The Lost MC Female" />
                sPeds.Add("g_m_y_lost_01");    //"The Lost MC Male" />
                sPeds.Add("g_m_y_lost_02");    //"The Lost MC Male 2" />
                sPeds.Add("g_m_y_lost_03");    //"The Lost MC Male 3" />
                sPeds.Add("a_m_m_mlcrisis_01");    //"Midlife Crisis Casino Bikers" />
                sPeds.Add("mp_m_exarmy_01");    //"Ex-Army Male" />
            }       //Racist - Motobikes
            else if (iRando == 49)
            {
                sPeds.Add("a_f_y_beach_01");    //"Beach Young Female" />
                sPeds.Add("a_m_m_beach_01");    //"Beach Male" />
                sPeds.Add("a_m_m_beach_02");    //"Beach Male 2" />
                sPeds.Add("a_m_y_beach_01");    //"Beach Young Male" />
                sPeds.Add("a_m_y_beach_02");    //"Beach Young Male 2" />
                sPeds.Add("a_m_y_beach_03");    //"Beach Young Male 3" />
            }       //Racist - Yachts
            else if (iRando == 50)
            {
                sPeds.Add("A_F_Y_CarClub_01");
                sPeds.Add("A_M_Y_CarClub_01");
                sPeds.Add("CSB_DrugDealer");
                sPeds.Add("S_F_M_RetailStaff_01");
                sPeds.Add("S_M_M_RaceOrg_01");

            }       //carmeat
            else
            {
                sPeds.Add("a_m_m_tramp_01");    //"Tramp Male" />
            }


            if (sPeds.Count > 0)
            {
                if (sPeds.Count > 1)
                    sPedds = sPeds[RandomX.RandInt(0, sPeds.Count - 1)];
                else
                    sPedds = sPeds[0];
            }
            else
                sPedds = "a_m_m_tramp_01";

            return sPedds;
        }
        public static int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        public static DanceMoves DanceList(bool bMale, int iSpeed)
        {
            LoggerLight.LogThis("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);
            DanceMoves MyMoves;
            if (bMale)
            {
                if (iSpeed == 1)
                    MyMoves = MaleDance01[RandomX.FindRandom("DanceList01", 0, MaleDance01.Count - 1)];
                else if (iSpeed == 2)
                    MyMoves = MaleDance02[RandomX.FindRandom("DanceList02", 0, MaleDance02.Count - 1)];
                else
                    MyMoves = MaleDance03[RandomX.FindRandom("DanceList03", 0, MaleDance03.Count - 1)];
            }
            else
            {
                if (iSpeed == 1)
                    MyMoves = FemaleDance01[RandomX.FindRandom("DanceList04", 0, FemaleDance01.Count - 1)];
                else if (iSpeed == 2)
                    MyMoves = FemaleDance02[RandomX.FindRandom("DanceList05", 0, FemaleDance02.Count - 1)];
                else
                    MyMoves = FemaleDance03[RandomX.FindRandom("DanceList06", 0, FemaleDance03.Count - 1)];
            }

            return MyMoves;
        }
        public static int PedWalkies(Ped Peddy, List<Vector3> MyLister, int iLocalList)
        {
            LoggerLight.LogThis("PedWalkies");

            iLocalList ++;
            if (iLocalList == MyLister.Count())
                iLocalList = 0;

            EntityBuild.WalkThisWay(Peddy, MyLister[iLocalList], 1.00f);

            return iLocalList;
        }
        public static bool PedRunToFoward(Ped Peddy, List<Vector3> MyLister, int iLocal, float fSpeed)
        {
            LoggerLight.LogThis("PedRunToFoward");

            bool bInUse = true;

            if (iLocal < MyLister.Count)
                EntityBuild.WalkThisWay(Peddy, MyLister[iLocal], fSpeed);
            else
                bInUse = false;

            return bInUse;
        }
        public static string AddRandomVeh(int iVechList)
        {
            string myVehicle = "ASEA";

            if (iVechList == 1)
                myVehicle = SuperList[RandomX.FindRandom("RanVeh01", 0, SuperList.Count - 1)];          //Super
            else if (iVechList == 2)
                myVehicle = SportList[RandomX.FindRandom("RanVeh02", 0, SportList.Count - 1)];          //Sports
            else if (iVechList == 3)
                myVehicle = CoupeList[RandomX.FindRandom("RanVeh03", 0, CoupeList.Count - 1)];          //Coupe
            else if (iVechList == 4)
                myVehicle = MuscleList[RandomX.FindRandom("RanVeh04", 0, MuscleList.Count - 1)];        //Muscle
            else if (iVechList == 5)
                myVehicle = SportClassList[RandomX.FindRandom("RanVeh05", 0, SportClassList.Count - 1)];//SportsClassic
            else if (iVechList == 6)
                myVehicle = SedanList[RandomX.FindRandom("RanVeh06", 0, SedanList.Count - 1)];          //Sedan
            else if (iVechList == 7)
                myVehicle = SUVList[RandomX.FindRandom("RanVeh07", 0, SUVList.Count - 1)];              //Suv
            else if (iVechList == 8)
                myVehicle = CompactList[RandomX.FindRandom("RanVeh08", 0, CompactList.Count - 1)];      //Compact
            else if (iVechList == 9)
                myVehicle = OffRoadList[RandomX.FindRandom("RanVeh09", 0, OffRoadList.Count - 1)];      //OffRoad
            else if (iVechList == 10)
                myVehicle = MotorBikeList[RandomX.FindRandom("RanVeh11", 0, MotorBikeList.Count - 1)];  //Motorbike
            else if (iVechList == 11)
                myVehicle = BennysVeh[RandomX.FindRandom("RanVeh10", 0, BennysVeh.Count - 1)];          //Bennys
            else if (iVechList == 12)
                myVehicle = BusList[RandomX.FindRandom("RanVeh12", 0, BusList.Count - 1)];              //Bus
            else if (iVechList == 13)
                myVehicle = IndustrialList[RandomX.FindRandom("RanVeh13", 0, IndustrialList.Count - 1)];//Industrial
            else if (iVechList == 14)
                myVehicle = TruckList[RandomX.FindRandom("RanVeh14", 0, TruckList.Count - 1)];          //Trucks
            else if (iVechList == 15)
                myVehicle = ComercialList[RandomX.FindRandom("RanVeh15", 0, ComercialList.Count - 1)];  //Comercial
            else if (iVechList == 16)
                myVehicle = ArmoredList[RandomX.FindRandom("RanVeh16", 0, ArmoredList.Count - 1)];      //Armored
            else if (iVechList == 17)
                myVehicle = WeaponisedList[RandomX.FindRandom("RanVeh17", 0, WeaponisedList.Count - 1)];//Weaponised
            else if (iVechList == 18)
                myVehicle = ArenaWarsList[RandomX.FindRandom("RanVeh18", 0, ArenaWarsList.Count - 1)];  //AreaWars
            else if (iVechList == 19)
                myVehicle = OpenWheelList[RandomX.FindRandom("RanVeh19", 0, OpenWheelList.Count - 1)];  //OpenWheel(F1)
            else if (iVechList == 20)
                myVehicle = CartList[RandomX.FindRandom("RanVeh20", 0, CartList.Count - 1)];            //GoCarts
            else if (iVechList == 21)
                myVehicle = CycleList[RandomX.FindRandom("RanVeh21", 0, CycleList.Count - 1)];          //Cycles
            else if (iVechList == 22)
                myVehicle = PlaneComList[RandomX.FindRandom("RanVeh22", 0, PlaneComList.Count - 1)];    //Planes
            else if (iVechList == 23)
                myVehicle = PlaneFightList[RandomX.FindRandom("RanVeh23", 0, PlaneFightList.Count - 1)];//WarPlanes
            else if (iVechList == 24)
                myVehicle = HeliComList[RandomX.FindRandom("RanVeh24", 0, HeliComList.Count - 1)];      //Helicopters
            else if (iVechList == 25)
                myVehicle = HeliFightList[RandomX.FindRandom("RanVeh25", 0, HeliFightList.Count - 1)];  //WarHelecoters
            else if (iVechList == 26)
                myVehicle = BoatList[RandomX.FindRandom("RanVeh26", 0, BoatList.Count - 1)];            //Boats
            else if (iVechList == 27)
                myVehicle = FloatersList[RandomX.FindRandom("RanVeh27", 0, FloatersList.Count - 1)];    //Amphibious
            else if (iVechList == 28)
                myVehicle = TowingList[RandomX.FindRandom("RanVeh28", 0, TowingList.Count - 1)];    //Towing
            else if (iVechList == 29)
                myVehicle = SubList[RandomX.FindRandom("RanVeh30", 0, SubList.Count - 1)];    //sub
            else if (iVechList == 30)
                myVehicle = JetSkiList[RandomX.FindRandom("RanVeh31", 0, JetSkiList.Count - 1)];    //JetSki
            else if (iVechList == 31)
                myVehicle = CustomList[RandomX.RandInt(0, CustomList.Count - 1)];    //Custom
            else if (iVechList == 32)
                myVehicle = MCBikeList[RandomX.FindRandom("RanVeh32", 0, MCBikeList.Count - 1)];    //Mc

            return myVehicle;
        }
        public static string SelectAVeh(int iVechList, int iPos)
        {
            string myVehicle = "ResetToZero";

            if (iVechList == 1 && iPos < SuperList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SuperList.Count;
                else
                    myVehicle = SuperList[iPos];          //Super
            }
            else if (iVechList == 2 && iPos < SportList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SportList.Count;
                else
                    myVehicle = SportList[iPos];          //Sport
            }
            else if (iVechList == 3 && iPos < CoupeList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + CoupeList.Count;
                else
                    myVehicle = CoupeList[iPos];          //Coupe
            }
            else if (iVechList == 4 && iPos < MuscleList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + MuscleList.Count;
                else
                    myVehicle = MuscleList[iPos];          //Muscle
            }
            else if (iVechList == 5 && iPos < SportClassList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SportClassList.Count;
                else
                    myVehicle = SportClassList[iPos];          //SportsClassic
            }
            else if (iVechList == 6 && iPos < SedanList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SedanList.Count;
                else
                    myVehicle = SedanList[iPos];          //Sedan
            }
            else if (iVechList == 7 && iPos < SUVList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SUVList.Count;
                else
                    myVehicle = SUVList[iPos];          //Suv
            }
            else if (iVechList == 8 && iPos < CompactList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + CompactList.Count;
                else
                    myVehicle = CompactList[iPos];          //Compact
            }
            else if (iVechList == 9 && iPos < OffRoadList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + OffRoadList.Count;
                else
                    myVehicle = OffRoadList[iPos];          //OffRoad
            }
            else if (iVechList == 10 && iPos < MotorBikeList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + MotorBikeList.Count;
                else
                    myVehicle = MotorBikeList[iPos];          //Motorbike
            }
            else if (iVechList == 11 && iPos < BennysVeh.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + BennysVeh.Count;
                else
                    myVehicle = BennysVeh[iPos];          //Bennys
            }
            else if (iVechList == 12 && iPos < BusList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + BusList.Count;
                else
                    myVehicle = BusList[iPos];          //Bus
            }
            else if (iVechList == 13 && iPos < IndustrialList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + IndustrialList.Count;
                else
                    myVehicle = IndustrialList[iPos];          //Industrial
            }
            else if (iVechList == 14 && iPos < TruckList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + TruckList.Count;
                else
                    myVehicle = TruckList[iPos];          //Trucks
            }
            else if (iVechList == 15 && iPos < ComercialList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + ComercialList.Count;
                else
                    myVehicle = ComercialList[iPos];          //Comercial
            }
            else if (iVechList == 16 && iPos < ArmoredList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + ArmoredList.Count;
                else
                    myVehicle = ArmoredList[iPos];          //Armored
            }
            else if (iVechList == 17 && iPos < WeaponisedList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + WeaponisedList.Count;
                else
                    myVehicle = WeaponisedList[iPos];          //Weaponised
            }
            else if (iVechList == 18 && iPos < ArenaWarsList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + ArenaWarsList.Count;
                else
                    myVehicle = ArenaWarsList[iPos];          //AreaWars
            }
            else if (iVechList == 19 && iPos < OpenWheelList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + OpenWheelList.Count;
                else
                    myVehicle = OpenWheelList[iPos];          //OpenWheel(F1)
            }
            else if (iVechList == 20 && iPos < CartList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + CartList.Count;
                else
                    myVehicle = CartList[iPos];          //GoCarts
            }
            else if (iVechList == 21 && iPos < CycleList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + CycleList.Count;
                else
                    myVehicle = CycleList[iPos];          //Cycles
            }
            else if (iVechList == 22 && iPos < PlaneComList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + PlaneComList.Count;
                else
                    myVehicle = PlaneComList[iPos];          //Planes
            }
            else if (iVechList == 23 && iPos < PlaneFightList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + PlaneFightList.Count;
                else
                    myVehicle = PlaneFightList[iPos];          //WarPlanes
            }
            else if (iVechList == 24 && iPos < HeliComList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + HeliComList.Count;
                else
                    myVehicle = HeliComList[iPos];          //Helicopters
            }
            else if (iVechList == 25 && iPos < HeliFightList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + HeliFightList.Count;
                else
                    myVehicle = HeliFightList[iPos];          //WarHelecoters
            }
            else if (iVechList == 26 && iPos < BoatList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + BoatList.Count;
                else
                    myVehicle = BoatList[iPos];          //Boats
            }
            else if (iVechList == 27 && iPos < FloatersList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + FloatersList.Count;
                else
                    myVehicle = FloatersList[iPos];          //Amphibious
            }
            else if (iVechList == 28 && iPos < TowingList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + TowingList.Count;
                else
                    myVehicle = TowingList[iPos];          //Towing
            }
            else if (iVechList == 29 && iPos < SubList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + SubList.Count;
                else
                    myVehicle = SubList[iPos];          //Sub
            }
            else if (iVechList == 30 && iPos < JetSkiList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + JetSkiList.Count;
                else
                    myVehicle = JetSkiList[iPos];          //Jetski
            }
            else if (iVechList == 31 && iPos < CustomList.Count)
            {
                if (iPos < 0)
                    myVehicle = "ResetTo" + CustomList.Count;
                else
                    myVehicle = CustomList[iPos];          //Custom
            }

            return myVehicle;
        }
        public static void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        public static bool WhileButtonDown(int CButt)
        {
            ButtonDisabler(CButt);
            bool bButt = Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);

            if (bButt)
            {
                while (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, 0, CButt))
                {
                    ButtonDisabler(CButt);
                    Script.Wait(1);
                }
            }

            return bButt;
        }
        public static bool ButtonDown(int CButt)
        {
            ButtonDisabler(CButt);

            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static bool ButtonDownNoDis(int CButt)
        {
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static bool PickupBling(Prop pLop)
        {
            bool bPlop = false;
            if (Game.Player.Character.Position.DistanceTo(pLop.Position) < 1.60f)
            {
                MissionData.PropList_01.Remove(pLop);
                pLop.Delete();
                Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "CHECKPOINT_UNDER_THE_BRIDGE", "HUD_MINI_GAME_SOUNDSET", true);
                bPlop = true;
            }
            return bPlop;
        }
        public static float RandFlow(float minNumber, float maxNumber)
        {
            return Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, minNumber, maxNumber);
        }
        public static bool BeInRange(float fRange, float fValue_01, float fValue_02)
        {
            bool bInRange = false;

            if (fValue_01 < fValue_02 + fRange)
            {
                if (fValue_01 > fValue_02 - fRange)
                    bInRange = true;
            }

            return bInRange;
        }
        public static bool BeInAngle(float fRange, float fValue_01, float fValue_02)
        {
            bool bInRange = false;

            if (fValue_01 < fRange)
            {
                if (fValue_02 > 360.00 - fRange)
                    bInRange = true;
            }
            else if (fValue_02 < fRange)
            {
                if (fValue_01 > 360.00 - fRange)
                    bInRange = true;
            }
            else if (fValue_01 < fValue_02 + fRange)
            {
                if (fValue_01 > fValue_02 - fRange)
                    bInRange = true;
            }

            return bInRange;
        }
        public static string ShowComs(int iNumber, bool bMoney, bool bHalfSecs)
        {
            string sThis = "";

            if (bMoney)
            {
                int iTrashed = iNumber;
                int imill = 0;
                int iThou = 0;
                int irest = 0;
                string sZero1 = "";
                string sZero2 = "";
                string sDone = "";
                if (iTrashed < 1000)
                {
                    irest = iTrashed;
                    sDone = "" + irest;
                }
                else if (iTrashed < 1000000)
                {
                    iThou = iTrashed / 1000;
                    irest = iTrashed - (iThou * 1000);
                    if (irest < 10)
                        sDone = "" + iThou + ",00" + irest;
                    else if (irest < 100)
                        sDone = "" + iThou + ",0" + irest;
                    else
                        sDone = "" + iThou + "," + irest;
                }
                else
                {

                    imill = iTrashed / 1000000;

                    iThou = iTrashed - (imill * 1000000);
                    iThou = iThou / 1000;

                    irest = iTrashed - (imill * 1000000);
                    irest = irest - (iThou * 1000);

                    if (iThou < 10)
                        sZero1 = "00";
                    else if (iThou < 100)
                        sZero1 = "0";
                    else
                        sZero1 = "";

                    if (irest < 10)
                        sZero2 = "00";
                    else if (irest < 100)
                        sZero2 = "0";
                    else
                        sZero2 = "";
                    sDone = "" + imill + "," + sZero1 + iThou + "," + sZero2 + irest;
                }

                sThis = sDone;
            }
            else
            {
                int iLapMin = iNumber;
                int iLapSec = iNumber;
                int iLapHse = iNumber;
                string Zero_01 = "";
                string Zero_02 = "";
                string Zero_03 = "";

                iLapMin = iNumber / 60000;
                if (iLapMin < 0)
                    iLapMin = 0;
                else
                {
                    iLapSec = iNumber - (iLapMin * 60000);
                    iLapHse = iNumber - (iLapMin * 60000);
                }
                iLapSec = iLapSec / 1000;
                if (iLapSec < 0)
                    iLapSec = 0;
                else
                    iLapHse = iLapHse - (iLapSec * 1000);
                iLapHse = iLapHse / 10;
                if (iLapHse < 0)
                    iLapHse = 0;

                if (iLapMin < 10)
                    Zero_01 = "0";
                else
                    Zero_01 = "";

                if (iLapSec < 10)
                    Zero_02 = "0";
                else
                    Zero_02 = "";

                if (iLapHse < 10)
                    Zero_03 = "0";
                else
                    Zero_03 = "";

                if (bHalfSecs)
                    sThis = "" + Zero_01 + iLapMin + ":" + Zero_02 + iLapSec + ":" + Zero_03 + iLapHse + "";
                else
                    sThis = "" + Zero_01 + "" + iLapMin + ":" + Zero_02 + "" + iLapSec + "";
            }

            return sThis;
        }
        public static List<string> RaceCounter(int iNumber)
        {
            int iLapMin = iNumber;
            int iLapSec = iNumber;
            int iLapHse = iNumber;
            string Zero_01 = "";
            string Zero_02 = "";
            string Zero_03 = "";
            string Out01 = "";
            string Out02 = "";
            string Out03 = "";

            iLapMin = iNumber / 60000;
            if (iLapMin < 0)
                iLapMin = 0;
            else
            {
                iLapSec = iNumber - (iLapMin * 60000);
                iLapHse = iNumber - (iLapMin * 60000);
            }
            iLapSec = iLapSec / 1000;
            if (iLapSec < 0)
                iLapSec = 0;
            else
                iLapHse = iLapHse - (iLapSec * 1000);
            iLapHse = iLapHse / 10;
            if (iLapHse < 0)
                iLapHse = 0;

            if (iLapMin < 10)
                Zero_01 = "0";
            else
                Zero_01 = "";

            if (iLapSec < 10)
                Zero_02 = "0";
            else
                Zero_02 = "";

            if (iLapHse < 10)
                Zero_03 = "0";
            else
                Zero_03 = "";


            Out01 = Zero_01 + iLapMin + ":"; Out02 = Zero_02 + iLapSec + ":"; Out03 = Zero_03 + iLapHse + "";

            return new List<string> { Out01, Out02, Out03 };
        }
        public static string GetEntName(string MyEnt)
        {
            string VehName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, Function.Call<int>(Hash.GET_HASH_KEY, MyEnt));
            if (Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, VehName))
                VehName = Function.Call<string>(Hash._GET_LABEL_TEXT, VehName);
            else
                VehName = "";

            return VehName;
        }
        public static string GetEntNameHash(int iHash)
        {
            LoggerLight.LogThis("GetEntNameHash");
            string VehName = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, iHash);
            if (Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, VehName))
                VehName = Function.Call<string>(Hash._GET_LABEL_TEXT, VehName);
            else
                VehName = "";

            return VehName;
        }
        public static bool CopsAreNear(Vector3 Pos)
        {
            bool TheyAre = false;
            List<Vehicle> FindCops = SearchFor.GetLocalVeh(Pos, 60f);

            for (int i = 0; i < FindCops.Count; i++)
            {
                if (FindCops[i].HasSiren)
                    TheyAre = true;
            }
            return TheyAre;
        }
        public static bool BeRightOnTime(int iMin, int iMax)
        {
            bool bRight = false;
            int iTime = Function.Call<int>(Hash.GET_CLOCK_HOURS);

            if (iTime >= iMin)
            {
                if (iTime <= iMax)
                    bRight = true;
            }

            return bRight;
        }
        public static int NSPMCoin(int iGet)
        {
            int iCash;
            int iStat = 0;
            if (Game.Player.Character.Model == PedHash.Franklin)
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP1_TOTAL_CASH");
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP2_TOTAL_CASH");
            else
                iStat = Function.Call<int>(Hash.GET_HASH_KEY, "SP0_TOTAL_CASH");

            unsafe
            {
                Function.Call<bool>(Hash.STAT_GET_INT, iStat, &iCash, -1);
            }


            if (iGet != 0)
            {
                iCash += iGet;
                Function.Call<bool>(Hash.STAT_SET_INT, iStat, iCash, true);
            }
            return iCash;
        }
        public static Vector3 AlterZHight(Vector3 MyVector, float fAddSub)
        {
            return new Vector3(MyVector.X, MyVector.Y, MyVector.Z + fAddSub);
        }
        public static Vector3 SetZHight(Vector3 MyVector, float fHeight)
        {
            return new Vector3(MyVector.X, MyVector.Y, fHeight);
        }
        public static bool AmIFar(Vector3 vFar, float fDist)
        {
            Vector3 Play = Game.Player.Character.Position;
            if (Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, vFar.X, vFar.Y, vFar.Z, Play.X, Play.Y, Play.Z, true) > fDist)
                return true;
            else
                return false;
        }
        public static bool AreUFar(Vector3 vYou, Vector3 vFar, float fDist)
        {
            if (Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, vFar.X, vFar.Y, vFar.Z, vYou.X, vYou.Y, vYou.Z, true) > fDist)
                return true;
            else
                return false;
        }
        public static bool AmINear(Vector3 vNear, float fDist)
        {
            Vector3 Play = Game.Player.Character.Position;
            if (Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, vNear.X, vNear.Y, vNear.Z, Play.X, Play.Y, Play.Z, true) < fDist)
                return true;
            else
                return false;
        }
        public static bool AreUNear(Vector3 vYou, Vector3 vNear, float fDist)
        {
            if (Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, vNear.X, vNear.Y, vNear.Z, vYou.X, vYou.Y, vYou.Z, true) < fDist)
                return true;
            else
                return false;
        }
        public static bool NearEnough(float Point1, float Point2, float PlusMinus)
        {
            bool iAmNear = false;
            if (Point1 + PlusMinus > Point2 && Point1 - PlusMinus < Point2)
                iAmNear = true;

            return iAmNear;
        }
        public static float RoadDistance(Vector3 vStart, Vector3 vEnd)
        {
            return Function.Call<float>(Hash.CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS, vStart.X, vStart.Y, vStart.Z, vEnd.X, vEnd.Y, vEnd.Z);
        }
        public static float VehTopSpeed(Vehicle Vhick)
        {
            float f = Function.Call<float>((Hash)0x53AF99BAA671CA47, Vhick.Handle);
            LoggerLight.LogThis("VehTopSpeed == " + f);
            return f;
        }
        public static float VehCurrentSpeed(Vehicle Vhick)
        {
            float f = Function.Call<float>(Hash.GET_ENTITY_SPEED, Vhick.Handle);
            return f;
        }
        public static VehCol VehColorCatch(Vehicle vHick)
        {
            int col01 = -10;
            int col02 = -10;

            unsafe
            {
                Function.Call(Hash.GET_VEHICLE_COLOURS, vHick.Handle, &col01, &col02);
            }

            return new VehCol(col01, col02);
        }
        public static RGBA VehNeonCatch(Vehicle vHick)
        {
            int colR = -1;
            int colG = -1;
            int colB = -1;
            int colA = 255;

            unsafe
            {
                Function.Call(Hash._GET_VEHICLE_NEON_LIGHTS_COLOUR, vHick.Handle, &colR, &colG, &colB);
            }

            return new RGBA(colR, colG, colB, colA);
        }
        public static string StreetSpirit(Vector3 vPos)
        {
            return World.GetStreetName(vPos);
        }
        public static int AppeyNess(Vector3 MyAppy, string Name)
        {
            LoggerLight.LogThis("AppeyNess, MyAppy == " + MyAppy);
            int iApt = 0;
            if (Name != "")
                iApt = Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS_WITH_TYPE, MyAppy.X, MyAppy.Y, MyAppy.Z, Name);
            else
                iApt = Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, MyAppy.X, MyAppy.Y, MyAppy.Z);

            bool bDisabled = Function.Call<bool>(Hash.IS_INTERIOR_DISABLED, iApt);
            bool bCapped = Function.Call<bool>(Hash.IS_INTERIOR_CAPPED, iApt);

            if (Function.Call<bool>(Hash.IS_VALID_INTERIOR, iApt))
            {
                Function.Call((Hash)0x2CA429C029CCF247, iApt);
                Function.Call(Hash.SET_INTERIOR_ACTIVE, iApt, true);
                if (bDisabled)
                    Function.Call(Hash.DISABLE_INTERIOR, iApt, false);
                if (bCapped)
                    Function.Call(Hash.CAP_INTERIOR, iApt, false);
            }

            return iApt;
        }
        public static List<Vector4> IndoorPed(int lod)
        {
            List<Vector4> ReturnDoor = new List<Vector4>();

            if (lod == 1)
            {
                ReturnDoor.Add(new Vector4(1087.834f, -3099.447f, -38.99996f, 270.6761f));  //start
                ReturnDoor.Add(new Vector4(1095.322f, -3102.153f, -38.99996f, 80.77405f));
                ReturnDoor.Add(new Vector4(1099.526f, -3098.207f, -38.99996f, 162.5741f));
                ReturnDoor.Add(new Vector4(1105.11f, -3099.305f, -38.99996f, 89.95913f));
            }//small ware
            else if (lod == 2)
            {
                ReturnDoor.Add(new Vector4(1048.118f, -3097.007f, -38.99994f, 267.8056f));  //start
                ReturnDoor.Add(new Vector4(1057.044f, -3099.27f, -38.99994f, 93.666f));
                ReturnDoor.Add(new Vector4(1064.229f, -3098.874f, -38.99994f, 276.2046f));
                ReturnDoor.Add(new Vector4(1068.006f, -3099.428f, -38.99994f, 105.2667f));
                ReturnDoor.Add(new Vector4(1068.895f, -3105.988f, -38.99994f, 341.0544f));
                ReturnDoor.Add(new Vector4(1058.048f, -3105.529f, -38.99994f, 7.79666f));
                ReturnDoor.Add(new Vector4(1072.947f, -3102.51f, -38.99994f, 89.88791f));
            }//mid ware
            else if (lod == 3)
            {
                ReturnDoor.Add(new Vector4(992.2966f, -3097.777f, -38.99586f, 264.8933f));  //start
                ReturnDoor.Add(new Vector4(996.9451f, -3106.916f, -38.99989f, 299.7871f));
                ReturnDoor.Add(new Vector4(999.5788f, -3091.714f, -38.99974f, 219.1729f));
                ReturnDoor.Add(new Vector4(1012.614f, -3094.458f, -38.99987f, 272.1759f));
                ReturnDoor.Add(new Vector4(1014.76f, -3094.401f, -38.99987f, 89.85229f));
                ReturnDoor.Add(new Vector4(1011.716f, -3099.968f, -38.99987f, 54.73924f));
                ReturnDoor.Add(new Vector4(1008.026f, -3105.985f, -38.99987f, 111.544f));
                ReturnDoor.Add(new Vector4(1021.681f, -3108.634f, -38.99987f, 339.0309f));
                ReturnDoor.Add(new Vector4(1023.271f, -3105.876f, -38.99987f, 111.9582f));
                ReturnDoor.Add(new Vector4(1013.595f, -3111.381f, -38.99987f, 275.2288f));
                ReturnDoor.Add(new Vector4(1027.417f, -3101.232f, -38.99987f, 84.40113f));
            }//lg ware
            else if (lod == 4)
            {
                ReturnDoor.Add(new Vector4(894.5801f, -3245.898f, -98.25877f, 90f));     //start
                ReturnDoor.Add(new Vector4(868.2318f, -3230.087f, -98.29446f, 90f));
                ReturnDoor.Add(new Vector4(886.4559f, -3212.001f, -98.19621f, 90f));
                ReturnDoor.Add(new Vector4(908.8542f, -3211.221f, -98.22218f, 90f));
                ReturnDoor.Add(new Vector4(906.2184f, -3229.914f, -98.29436f, 90f));
                ReturnDoor.Add(new Vector4(943.6704f, -3236.479f, -98.2968f, 90f));
                ReturnDoor.Add(new Vector4(931.1979f, -3214.218f, -98.26333f, 90f));
                ReturnDoor.Add(new Vector4(940.9261f, -3197.448f, -98.26443f, 90f));
                ReturnDoor.Add(new Vector4(893.1318f, -3179.854f, -97.11796f, 90f));
                ReturnDoor.Add(new Vector4(904.9841f, -3200.06f, -97.18797f, 90f));
                ReturnDoor.Add(new Vector4(893.9405f, -3206.172f, -98.18995f, 90f));
                ReturnDoor.Add(new Vector4(882.6129f, -3204.415f, -98.1963f, 90f));
                ReturnDoor.Add(new Vector4(866.1926f, -3217.693f, -97.87908f, 90f));
                ReturnDoor.Add(new Vector4(856.3937f, -3228.032f, -98.47646f, 90f));
                ReturnDoor.Add(new Vector4(855.9623f, -3230.793f, -98.47524f, 90f));
                ReturnDoor.Add(new Vector4(868.3938f, -3238.448f, -98.29231f, 90f));
            }//bunker
            else if (lod == 5)
            {
                ReturnDoor.Add(new Vector4(970.8076f, -2987.8f, -39.64699f, 181.0559f));
                ReturnDoor.Add(new Vector4(977.7619f, -2997.935f, -39.64699f, 148.1641f));
                ReturnDoor.Add(new Vector4(1012.042f, -3002.676f, -35.92745f, 106.4563f));
                ReturnDoor.Add(new Vector4(998.7262f, -3025.299f, -39.64695f, 341.1441f));
                ReturnDoor.Add(new Vector4(954.6639f, -3035.869f, -39.64697f, 265.2446f));
                ReturnDoor.Add(new Vector4(962.5816f, -2992.112f, -39.64696f, 170.1995f));
                ReturnDoor.Add(new Vector4(959.4156f, -3008.098f, -38.94985f, 276.8085f));
                ReturnDoor.Add(new Vector4(970.4828f, -2994.294f, -47.55187f, 273.0119f));
                ReturnDoor.Add(new Vector4(958.6985f, -3006.813f, -47.54687f, 333.0554f));
            }//carware--new Vector3(994.5925, -3002.594, -39.64699)
            else if (lod == 6)
            {
                ReturnDoor.Add(new Vector4(152.2600f, -1004.4700f, -99.00f, 348.2809f));
                ReturnDoor.Add(new Vector4(154.063f, -1004.887f, -98.41931f, 84.49715f));
                ReturnDoor.Add(new Vector4(154.1099f, -1001.027f, -99.00001f, 107.7697f));
            }//motel
            else if (lod == 10)
            {
                ReturnDoor.Add(new Vector4(-1436.746f, -257.7867f, 16.7775f, 339.679f));
                ReturnDoor.Add(new Vector4(-1415.929f, -243.8792f, 16.80637f, 253.2587f));
                ReturnDoor.Add(new Vector4(-1415.654f, -231.795f, 21.04895f, 65.12151f));
                ReturnDoor.Add(new Vector4(-1425.085f, -245.5259f, 16.80289f, 125.1166f));
                ReturnDoor.Add(new Vector4(-1435.214f, -227.6448f, 22.56793f, 272.0168f));
            }//Theater
            else if (lod == 15)
            {
                ReturnDoor.Add(new Vector4(2737.941f, -374.1741f, -47.99302f, 178.2159f));
                ReturnDoor.Add(new Vector4(2739.557f, -381.7286f, -48.39503f, 126.5467f));
                ReturnDoor.Add(new Vector4(2733.664f, -390.3447f, -48.39503f, 356.968f));
                ReturnDoor.Add(new Vector4(2726.821f, -386.3262f, -48.99297f, 77.67194f));
                ReturnDoor.Add(new Vector4(2723.947f, -377.3462f, -47.39993f, 353.1122f));
                ReturnDoor.Add(new Vector4(2726.94f, -377.8167f, -47.39296f, 43.83427f));
            }//Arcade
            else if (lod == 49)
            {
                ReturnDoor.Add(new Vector4(91.70937f, 3745.089f, 40.76893f, 56.10439f));
                ReturnDoor.Add(new Vector4(90.85267f, 3750.306f, 40.77384f, 234.1594f));
                ReturnDoor.Add(new Vector4(93.22286f, 3752.184f, 40.77081f, 133.2975f));
                ReturnDoor.Add(new Vector4(94.01864f, 3755.359f, 40.77143f, 159.3139f));
            }//trailer
            else if (lod == 50)
            {
                ReturnDoor.Add(new Vector4(265.1543f, -1000.97f, -99.00858f, 0f)); //Start--works
                ReturnDoor.Add(new Vector4(255.6427f, -1001.104f, -99.00988f, 90f));
                ReturnDoor.Add(new Vector4(261.9597f, -1002.951f, -99.00864f, 90f));
                ReturnDoor.Add(new Vector4(265.3889f, -995.8669f, -99.00861f, 90f));
            }//lowendApp
            else if (lod == 51)
            {
                ReturnDoor.Add(new Vector4(346.5643f, -1002.414f, -99.19627f, 0f)); //Start--
                ReturnDoor.Add(new Vector4(338.8605f, -1003.227f, -99.19618f, 90f));
                ReturnDoor.Add(new Vector4(343.8432f, -1002.688f, -99.19618f, 90f));
                ReturnDoor.Add(new Vector4(351.9203f, -995.3839f, -99.19619f, 90f));
                ReturnDoor.Add(new Vector4(347.5306f, -994.1599f, -99.19618f, 90f));
            }//MidEndApp
            else if (lod == 52)
            {
                ReturnDoor.Add(new Vector4(172.7176f, -1008.034f, -98.9999f, 358.0579f));
                ReturnDoor.Add(new Vector4(174.8638f, -1003.423f, -99.67892f, 169.9682f));
                ReturnDoor.Add(new Vector4(171.0718f, -1003.313f, -99.67917f, 179.7587f));
                ReturnDoor.Add(new Vector4(172.25f, -999.51f, -97.94f, -11f));//case
            }//2CarGar
            else if (lod == 53)
            {
                ReturnDoor.Add(new Vector4(201.7643f, -1007.369f, -99f, 1.044594f));
                ReturnDoor.Add(new Vector4(201.7898f, -998.2261f, -99.67917f, 191.4218f));
                ReturnDoor.Add(new Vector4(197.4461f, -998.3278f, -99.67913f, 189.5971f));
                ReturnDoor.Add(new Vector4(192.84f, -998.2251f, -99.67934f, 187.5891f));
                ReturnDoor.Add(new Vector4(202.1313f, -1004.278f, -99.67912f, 179.6499f));
                ReturnDoor.Add(new Vector4(197.2721f, -1003.977f, -99.67915f, 179.0924f));
                ReturnDoor.Add(new Vector4(192.9765f, -1004.077f, -99.67918f, 180.2277f));
                ReturnDoor.Add(new Vector4(206.04f, -993.87f, -97.97f, 22.45f));//case
            }//6CarGar
            else if (lod == 54)
            {
                ReturnDoor.Add(new Vector4(231.6752f, -1006.353f, -98.9999f, 6.977743f));
                ReturnDoor.Add(new Vector4(224.8628f, -984.1489f, -99.61839f, 247.2113f));
                ReturnDoor.Add(new Vector4(232.2393f, -983.4969f, -99.5919f, 108.9255f));
                ReturnDoor.Add(new Vector4(224.3197f, -988.2136f, -99.70198f, 247.6503f));
                ReturnDoor.Add(new Vector4(232.5084f, -987.912f, -99.32076f, 109.0127f));
                ReturnDoor.Add(new Vector4(224.1519f, -992.2954f, -99.28339f, 248.3775f));
                ReturnDoor.Add(new Vector4(232.3163f, -991.978f, -99.73936f, 110.8574f));
                ReturnDoor.Add(new Vector4(223.9675f, -995.766f, -99.47842f, 247.2027f));
                ReturnDoor.Add(new Vector4(232.6274f, -996.7224f, -99.6416f, 105.9475f));
                ReturnDoor.Add(new Vector4(223.6955f, -1000.018f, -99.2728f, 249.0427f));
                ReturnDoor.Add(new Vector4(233.0081f, -1001.4f, -99.50631f, 115.4192f));
                ReturnDoor.Add(new Vector4(234.73f, -975.37f, -97.97f, 8f));//case
            }//10CarGar
            else if (lod == 55)
            {
                ReturnDoor.Add(new Vector4(-774.23f, 342.00f, 196.6862f, 90f)); //start
                ReturnDoor.Add(new Vector4(-755.1921f, 324.9401f, 199.4861f, 90f));
                ReturnDoor.Add(new Vector4(-756.4911f, 321.966f, 199.5233f, 90f));
                ReturnDoor.Add(new Vector4(-763.6169f, 318.8523f, 199.4911f, 90f));
                ReturnDoor.Add(new Vector4(-763.3571f, 328.4738f, 199.4863f, 90f));
                ReturnDoor.Add(new Vector4(-778.1786f, 315.4348f, 195.8864f, 90f));
                ReturnDoor.Add(new Vector4(-778.4504f, 327.8043f, 196.086f, 90f));
                ReturnDoor.Add(new Vector4(-763.5885f, 331.035f, 196.086f, 90f));
                ReturnDoor.Add(new Vector4(-773.4202f, 334.114f, 196.086f, 90f));
            }//App--EclipseCustom
            else if (lod == 56)
            {
                ReturnDoor.Add(new Vector4(-31.17531f, -595.0803f, 80.03091f, -110f));  //Start    
                ReturnDoor.Add(new Vector4(-41.4437f, -583.9338f, 78.83031f, -110f));
                ReturnDoor.Add(new Vector4(-34.13421f, -583.5911f, 78.86551f, -110f));
                ReturnDoor.Add(new Vector4(-27.02728f, -580.8799f, 79.23077f, -110f));
                ReturnDoor.Add(new Vector4(-11.76741f, -586.218f, 79.43074f, -110f));
                ReturnDoor.Add(new Vector4(-9.632593f, -595.597f, 79.43023f, -110f));
                ReturnDoor.Add(new Vector4(-9.363688f, -597.8205f, 79.43023f, -110f));
            }//App-- 4 Integrity Way, Apt 28 	Vector3 Xmark = Vector3(-18.07856, -583.6725, 79.46569);//4 Integrity Way, Apt 30 	Vector3 Xmark = Vector3(-35.31277, -580.4199, 88.71221);
            else if (lod == 57)
            {
                ReturnDoor.Add(new Vector4(-1452.375f, -540.3256f, 74.04432f, 40.14954f));
                ReturnDoor.Add(new Vector4(-1468.309f, -526.5028f, 73.44362f, 95.99065f));
                ReturnDoor.Add(new Vector4(-1475.864f, -538.9135f, 73.44415f, 162.2601f));
                ReturnDoor.Add(new Vector4(-1466.511f, -549.707f, 73.24417f, 36.77481f));
                ReturnDoor.Add(new Vector4(-1458.053f, -552.476f, 72.87893f, 303.5532f));
                ReturnDoor.Add(new Vector4(-1449.63f, -548.6891f, 72.84374f, 125.56f));
                ReturnDoor.Add(new Vector4(-1450.211f, -555.7941f, 72.84374f, 37.56693f));
                ReturnDoor.Add(new Vector4(-1453.352f, -556.166f, 72.88095f, 302.9384f));
            }//App--Dell Perro Heights, Apt 4 	Vector3 Xmark = Vector3(-1468.14, -541.815, 73.4442);//Dell Perro Heights, Apt 7 	Vector3 Xmark = Vector3(-1477.14, -538.7499, 55.5264);
            else if (lod == 58)
            {
                ReturnDoor.Add(new Vector4(-922.9813f, -378.5054f, 85.48054f, 213.1062f));
                ReturnDoor.Add(new Vector4(-917.5322f, -374.2621f, 85.48547f, 116.361f));
                ReturnDoor.Add(new Vector4(-898.2595f, -378.2869f, 84.0779f, 341.304f));
                ReturnDoor.Add(new Vector4(-899.8299f, -368.5951f, 84.07792f, 130.4221f));
                ReturnDoor.Add(new Vector4(-908.8607f, -367.5494f, 84.08708f, 174.2083f));
                ReturnDoor.Add(new Vector4(-906.4951f, -380.6722f, 79.27319f, 358.612f));
                ReturnDoor.Add(new Vector4(-899.624f, -378.6077f, 79.2732f, 105.1332f));
                ReturnDoor.Add(new Vector4(-910.753f, -374.3173f, 79.27322f, 302.731f));
                ReturnDoor.Add(new Vector4(-904.0492f, -369.552f, 79.28397f, 141.086f));
            }//Richard Majestic, Apt 2 	Vector3 Xmark = Vector3(-915.811, -379.432, 113.6748);
            else if (lod == 59)
            {
                ReturnDoor.Add(new Vector4(-605.1456f, 51.42239f, 93.62614f, 169.6311f));
                ReturnDoor.Add(new Vector4(-597.8266f, 52.38469f, 93.6317f, 137.9482f));
                ReturnDoor.Add(new Vector4(-589.0139f, 54.04784f, 92.22357f, 218.6635f));
                ReturnDoor.Add(new Vector4(-579.5641f, 50.12477f, 92.22357f, 105.1784f));
                ReturnDoor.Add(new Vector4(-579.1388f, 40.89782f, 92.22448f, 44.00978f));
                ReturnDoor.Add(new Vector4(-591.3568f, 41.01477f, 87.41889f, 27.44259f));
                ReturnDoor.Add(new Vector4(-585.1638f, 40.05229f, 87.41884f, 343.4908f));
                ReturnDoor.Add(new Vector4(-592.2482f, 49.34888f, 87.41885f, 244.723f));
                ReturnDoor.Add(new Vector4(-584.1119f, 50.77825f, 87.42963f, 99.92526f));
            }//Tinsel Towers, Apt 42 	Vector3 Xmark = Vector3(-614.86, 40.6783, 97.60007);
            else if (lod == 60)
            {
                ReturnDoor.Add(new Vector4(-173.8757f, 497.8188f, 137.666f, -170f)); //Start
                ReturnDoor.Add(new Vector4(-172.6292f, 492.1187f, 130.0437f, -170f));
                ReturnDoor.Add(new Vector4(-173.6727f, 490.9218f, 130.0437f, -170f));
                ReturnDoor.Add(new Vector4(-167.9145f, 490.3182f, 133.8722f, -170f));
                ReturnDoor.Add(new Vector4(-166.1767f, 494.7598f, 133.8438f, -170f));
                ReturnDoor.Add(new Vector4(-166.8645f, 479.2725f, 133.8438f, -170f));
                ReturnDoor.Add(new Vector4(-164.5432f, 479.6711f, 133.8438f, -170f));
                ReturnDoor.Add(new Vector4(-165.7053f, 484.7502f, 137.2585f, -170f));
                ReturnDoor.Add(new Vector4(-167.4492f, 495.1891f, 137.6537f, -170f));
            }//3655 Wild Oats Drive 	Vector3 Xmark = Vector3(-169.286, 486.4938, 137.4436);
            else if (lod == 61)
            {
                ReturnDoor.Add(new Vector4(342.1456f, 438.0135f, 149.3808f, 124.159f));
                ReturnDoor.Add(new Vector4(341.5247f, 431.3412f, 149.3807f, 13.09949f));
                ReturnDoor.Add(new Vector4(330.6915f, 424.5193f, 148.9925f, 321.1824f));
                ReturnDoor.Add(new Vector4(326.897f, 425.2338f, 145.5708f, 296.0932f));
                ReturnDoor.Add(new Vector4(341.3937f, 429.2928f, 145.5735f, 120.3788f));
                ReturnDoor.Add(new Vector4(336.6023f, 429.7068f, 145.5992f, 275.9349f));
                ReturnDoor.Add(new Vector4(335.4503f, 435.5359f, 141.7708f, 238.5861f));
                ReturnDoor.Add(new Vector4(336.5234f, 433.8808f, 141.7708f, 352.1756f));
                ReturnDoor.Add(new Vector4(337.2106f, 436.7173f, 141.7708f, 167.8721f));
            }//2044 North Conker Avenue 	Vector3 Xmark = Vector3(340.9412, 437.1798, 149.3925);
            else if (lod == 62)
            {
                ReturnDoor.Add(new Vector4(373.5078f, 423.9499f, 145.9077f, 176.8234f));
                ReturnDoor.Add(new Vector4(377.5177f, 418.8811f, 145.9001f, 74.09467f));
                ReturnDoor.Add(new Vector4(374.35f, 407.2583f, 145.5277f, 51.43473f));
                ReturnDoor.Add(new Vector4(372.8817f, 403.5052f, 142.1002f, 24.30258f));
                ReturnDoor.Add(new Vector4(378.7715f, 416.8028f, 142.1003f, 194.052f));
                ReturnDoor.Add(new Vector4(374.9395f, 413.6715f, 142.1281f, 342.3974f));
                ReturnDoor.Add(new Vector4(377.2823f, 432.046f, 138.3001f, 109.4185f));
                ReturnDoor.Add(new Vector4(376.8639f, 430.4342f, 138.3001f, 87.88316f));
                ReturnDoor.Add(new Vector4(375.2288f, 432.2997f, 138.3001f, 215.8686f));
            }//2045 North Conker Avenue 	Vector3 Xmark = Vector3(373.023, 416.105, 145.7006);
            else if (lod == 63)
            {
                ReturnDoor.Add(new Vector4(-859.7592f, 691.0971f, 152.8607f, 181.7961f));
                ReturnDoor.Add(new Vector4(-854.5609f, 688.0287f, 152.8529f, 97.30418f));
                ReturnDoor.Add(new Vector4(-853.956f, 676.033f, 152.4805f, 59.058f));
                ReturnDoor.Add(new Vector4(-854.1311f, 671.276f, 149.0531f, 16.9372f));
                ReturnDoor.Add(new Vector4(-852.8832f, 686.9157f, 149.0531f, 183.5831f));
                ReturnDoor.Add(new Vector4(-855.5569f, 682.488f, 149.0809f, 14.35541f));
                ReturnDoor.Add(new Vector4(-858.8535f, 699.8838f, 145.253f, 96.969f));
                ReturnDoor.Add(new Vector4(-860.3242f, 699.3693f, 145.2529f, 303.5038f));
                ReturnDoor.Add(new Vector4(-858.6984f, 698.0011f, 145.2529f, 20.91333f));
            }//2874 Hillcrest Avenue 	Vector3 Xmark = Vector3(-852.9005,694.7808,148.0741);
            else if (lod == 64)
            {
                ReturnDoor.Add(new Vector4(-758.2975f, 619.0817f, 144.1408f, 103.5211f));
                ReturnDoor.Add(new Vector4(-759.7515f, 613.1013f, 144.1406f, 18.83379f));
                ReturnDoor.Add(new Vector4(-770.7853f, 608.4284f, 143.7524f, 349.2306f));
                ReturnDoor.Add(new Vector4(-775.56f, 608.636f, 140.3307f, 290.8351f));
                ReturnDoor.Add(new Vector4(-759.9415f, 610.2443f, 140.3307f, 109.327f));
                ReturnDoor.Add(new Vector4(-765.3878f, 611.6942f, 140.3591f, 269.7463f));
                ReturnDoor.Add(new Vector4(-764.5774f, 617.8854f, 136.5306f, 196.8052f));
                ReturnDoor.Add(new Vector4(-763.2961f, 617.0836f, 136.5306f, 114.3854f));
                ReturnDoor.Add(new Vector4(-764.5446f, 616.2765f, 136.5306f, 347.5606f));
            }//2868 Hillcrest Avenue	Vector3 Xmark = Vector3(-753.4206, 620.2255, 141.8517);
            else if (lod == 65)
            {
                ReturnDoor.Add(new Vector4(-682.3058f, 592.5394f, 145.3925f, 228.7884f));
                ReturnDoor.Add(new Vector4(-675.7626f, 593.7087f, 145.3797f, 137.7519f));
                ReturnDoor.Add(new Vector4(-668.4958f, 585.1605f, 144.9914f, 113.3778f));
                ReturnDoor.Add(new Vector4(-665.5734f, 580.4192f, 141.5698f, 53.16618f));
                ReturnDoor.Add(new Vector4(-673.9216f, 594.2621f, 141.5699f, 225.5861f));
                ReturnDoor.Add(new Vector4(-673.0537f, 589.1637f, 141.5982f, 25.58833f));
                ReturnDoor.Add(new Vector4(-677.6174f, 587.1633f, 137.7697f, 37.98262f));
                ReturnDoor.Add(new Vector4(-679.6929f, 587.998f, 137.7697f, 274.1265f));
                ReturnDoor.Add(new Vector4(-679.2336f, 586.2867f, 137.7697f, 319.9241f));
            }//2862 Hillcrest Avenue	Vector3 Xmark = Vector3(-733.4767, 593.2111, 141.5178);
            else if (lod == 66)
            {
                ReturnDoor.Add(new Vector4(117.4815f, 559.4827f, 184.3049f, 180f)); //Start
                ReturnDoor.Add(new Vector4(117.9137f, 567.4348f, 176.6971f, 180f));
                ReturnDoor.Add(new Vector4(118.6697f, 569.1439f, 176.6971f, 180f));
                ReturnDoor.Add(new Vector4(124.1776f, 555.1124f, 180.4973f, 180f));
                ReturnDoor.Add(new Vector4(123.6576f, 541.2617f, 180.4975f, 180f));
                ReturnDoor.Add(new Vector4(126.0195f, 543.5494f, 183.9233f, 180f));
                ReturnDoor.Add(new Vector4(123.7556f, 555.7462f, 184.2971f, 180f));
            }//2677 Whispymound Drive 	Vector3 Xmark = Vector3(120.5, 549.952, 184.097);
            else if (lod == 67)
            {
                ReturnDoor.Add(new Vector4(-1290.016f, 449.6957f, 97.90252f, 182.5185f));
                ReturnDoor.Add(new Vector4(-1284.817f, 445.4036f, 97.89471f, 80.06165f));
                ReturnDoor.Add(new Vector4(-1285.128f, 433.7893f, 97.52222f, 60.6204f));
                ReturnDoor.Add(new Vector4(-1286.78f, 429.5173f, 94.17101f, 5.474075f));
                ReturnDoor.Add(new Vector4(-1283.307f, 444.5426f, 94.09481f, 181.868f));
                ReturnDoor.Add(new Vector4(-1285.979f, 440.2654f, 94.12266f, 354.7365f));
                ReturnDoor.Add(new Vector4(-1289.976f, 458.7243f, 90.29469f, 183.3593f));
                ReturnDoor.Add(new Vector4(-1289.883f, 456.8919f, 90.29469f, 347.2509f));
                ReturnDoor.Add(new Vector4(-1288.131f, 458.5259f, 90.29469f, 97.04778f));
            }//2133 Mad Wayne Thunder 	Vector3 Xmark = Vector3(-1288, 440.748, 97.69459); 
            else if (lod == 68)
            {

            }//2117 Milton Road    Vector3 Xmark = Vector3(-559.6165,663.6034,144.5187);
            else if (lod == 69)
            {

            }//2862 Hillcrest Avenue  Vector3 Xmark = Vector3 - 685.5753, 595.7667, 143.0528);
            else if (lod == 70)
            {
                ReturnDoor.Add(new Vector4(-890.693f, -453.1191f, 95.46118f, 90f));  //Start
                ReturnDoor.Add(new Vector4(-899.3471f, -434.4514f, 89.2646f, 90f));
                ReturnDoor.Add(new Vector4(-894.4338f, -441.2721f, 89.26263f, 90f));
                ReturnDoor.Add(new Vector4(-891.5045f, -428.4247f, 89.25385f, 90f));
                ReturnDoor.Add(new Vector4(-900.9719f, -430.0855f, 94.05854f, 90f));
                ReturnDoor.Add(new Vector4(-900.9902f, -438.8939f, 94.05856f, 90f));
                ReturnDoor.Add(new Vector4(-899.51f, -440.603f, 94.05856f, 90f));
                ReturnDoor.Add(new Vector4(-895.0486f, -446.9772f, 95.46671f, 90f));
                ReturnDoor.Add(new Vector4(-881.1011f, -447.6875f, 95.46118f, 90f));
            }//Weazel Plaza
            else if (lod == 71)
            {

            }//Alta
            else if (lod == 97)
            {
                ReturnDoor.Add(new Vector4(1110.157f, -3166.864f, -37.51859f, 7.875401f));
                ReturnDoor.Add(new Vector4(1121.04f, -3143.584f, -37.06277f, 249.331f));
                ReturnDoor.Add(new Vector4(1123.108f, -3143.336f, -37.06277f, 161.4612f));
                ReturnDoor.Add(new Vector4(1123.101f, -3145.813f, -37.06277f, 358.7493f));
                ReturnDoor.Add(new Vector4(1122.466f, -3152.201f, -37.06277f, 173.8543f));
                ReturnDoor.Add(new Vector4(1115.062f, -3143.568f, -37.06277f, 172.132f));
                ReturnDoor.Add(new Vector4(1115.165f, -3146.383f, -37.06277f, 358.1128f));
                ReturnDoor.Add(new Vector4(1124.512f, -3160.981f, -37.06276f, 2.167449f));
                ReturnDoor.Add(new Vector4(1119.253f, -3162.024f, -36.87049f, 290.5875f));
                ReturnDoor.Add(new Vector4(1099.456f, -3142.424f, -38.04898f, 252.5797f));//Bikes
                ReturnDoor.Add(new Vector4(1099.507f, -3143.796f, -38.04887f, 249.272f));
                ReturnDoor.Add(new Vector4(1099.54f, -3144.963f, -38.04957f, 244.4926f));
                ReturnDoor.Add(new Vector4(1099.427f, -3146.419f, -38.04683f, 245.7102f));
                ReturnDoor.Add(new Vector4(1099.315f, -3148.148f, -38.05756f, 247.3653f));
                ReturnDoor.Add(new Vector4(1103.686f, -3142.324f, -38.04933f, 106.4427f));
                ReturnDoor.Add(new Vector4(1103.761f, -3143.687f, -38.04748f, 104.8831f));
                ReturnDoor.Add(new Vector4(1103.594f, -3145.222f, -38.04726f, 107.4198f));
                ReturnDoor.Add(new Vector4(1103.702f, -3146.639f, -38.04709f, 105.7766f));
                ReturnDoor.Add(new Vector4(1103.599f, -3148.043f, -38.08725f, 109.1343f));
                ReturnDoor.Add(new Vector4(1117.083f, -3161.23f, -36.06f, 2f));//Case
            }//Clubhouse1
            else if (lod == 98)
            {
                ReturnDoor.Add(new Vector4(996.949f, -3158.032f, -38.90714f, 280.1646f));
                ReturnDoor.Add(new Vector4(997.598f, -3170.229f, -34.07751f, 353.0032f));
                ReturnDoor.Add(new Vector4(998.3001f, -3168.446f, -34.05178f, 173.5241f));
                ReturnDoor.Add(new Vector4(1000.42f, -3164.119f, -34.07746f, 358.1814f));
                ReturnDoor.Add(new Vector4(1001.179f, -3170.135f, -34.06691f, 171.3261f));
                ReturnDoor.Add(new Vector4(1007.58f, -3149.555f, -38.90712f, 173.1569f));
                ReturnDoor.Add(new Vector4(1007.706f, -3152.32f, -38.90712f, 350.3316f));
                ReturnDoor.Add(new Vector4(1015.966f, -3150.513f, -38.89821f, 130.9942f));
                ReturnDoor.Add(new Vector4(1007.694f, -3159.322f, -39.44004f, 159.5504f));
                ReturnDoor.Add(new Vector4(1006.246f, -3159.234f, -39.45366f, 158.7197f));//bikes
                ReturnDoor.Add(new Vector4(1004.769f, -3159.211f, -39.43634f, 159.4728f));
                ReturnDoor.Add(new Vector4(1003.299f, -3159.111f, -39.43793f, 156.2102f));
                ReturnDoor.Add(new Vector4(1001.825f, -3159.099f, -39.47125f, 161.0683f));
                ReturnDoor.Add(new Vector4(1007.722f, -3162.569f, -39.44278f, 14.00995f));
                ReturnDoor.Add(new Vector4(1006.364f, -3162.621f, -39.43671f, 14.52713f));
                ReturnDoor.Add(new Vector4(1004.876f, -3162.576f, -39.46144f, 11.80989f));
                ReturnDoor.Add(new Vector4(1003.312f, -3162.593f, -39.43824f, 16.24312f));
                ReturnDoor.Add(new Vector4(1001.809f, -3162.691f, -39.4365f, 13.95953f));
                ReturnDoor.Add(new Vector4(1007.235f, -3170.273f, -39.11707f, 130.1323f));
                ReturnDoor.Add(new Vector4(1007.22f, -3170.36f, -38.90f, 168f));//case
            }//Clubhouse2
            else if (lod == 100)
            {
                ReturnDoor.Add(new Vector4(1173.633f, -3196.652f, -39.00793f, 94f));  //start
                ReturnDoor.Add(new Vector4(1157.049f, -3198.495f, -39.00798f, 90f));
                ReturnDoor.Add(new Vector4(1159.132f, -3191.732f, -39.00798f, 0f));
                ReturnDoor.Add(new Vector4(1164.112f, -3192.009f, -39.00798f, 0f));
                ReturnDoor.Add(new Vector4(1166.495f, -3196.158f, -39.00798f, 0f));
            }//Forg
            else if (lod == 101)
            {
                ReturnDoor.Add(new Vector4(1088.527f, -3187.533f, -38.99347f, 178f));  //start
                ReturnDoor.Add(new Vector4(1101.271f, -3197.999f, -38.99346f, 180f));
                ReturnDoor.Add(new Vector4(1093.563f, -3194.035f, -38.99346f, 0f));
                ReturnDoor.Add(new Vector4(1093.422f, -3197.22f, -38.99346f, 0f));
                ReturnDoor.Add(new Vector4(1087.632f, -3196.166f, -38.99346f, 0f));
            }//Coke
            else if (lod == 102)
            {
                ReturnDoor.Add(new Vector4(1066.199f, -3183.4f, -39.16352f, 88f));  //start
                ReturnDoor.Add(new Vector4(1042.56f, -3195.37f, -38.16234f, 0f));
                ReturnDoor.Add(new Vector4(1036.336f, -3206.347f, -38.17264f, 0f));
                ReturnDoor.Add(new Vector4(1054.596f, -3200.797f, -39.16124f, 0f));
                ReturnDoor.Add(new Vector4(1058.92f, -3193.996f, -39.16131f, 0f));
            }//Weed
            else if (lod == 103)
            {
                ReturnDoor.Add(new Vector4(1138.255f, -3198.998f, -39.66573f, 354f));  //start
                ReturnDoor.Add(new Vector4(1137.116f, -3194.313f, -40.39756f, 0f));
                ReturnDoor.Add(new Vector4(1127.94f, -3194.983f, -40.40163f, 0f));
                ReturnDoor.Add(new Vector4(1121.973f, -3195.467f, -40.40202f, 0f));
                ReturnDoor.Add(new Vector4(1117.973f, -3195.85f, -40.40057f, 0f));
            }//Cash
            else if (lod == 104)
            {
                ReturnDoor.Add(new Vector4(997.0231f, -3200.69f, -36.39368f, 271f)); //start
                ReturnDoor.Add(new Vector4(1016.395f, -3195.819f, -38.99313f, -90f));
                ReturnDoor.Add(new Vector4(1009.775f, -3200.557f, -38.99313f, 0f));
                ReturnDoor.Add(new Vector4(1003.916f, -3195.244f, -38.99313f, 0f));
                ReturnDoor.Add(new Vector4(999.0506f, -3199.958f, -38.99313f, 0f));
            }//Meth
            else if (lod == 200)
            {
                ReturnDoor.Add(new Vector4(128.614f, -1298.435f, 29.23277f, 22.18723f));
                ReturnDoor.Add(new Vector4(125.3322f, -1298.012f, 30.01303f, 298.4472f));
            }//Vanilla Unicorn
            else if (lod == 201)
            {
                ReturnDoor.Add(new Vector4(82.34214f, -1391.567f, 29.38897f, 274.4248f));
                ReturnDoor.Add(new Vector4(74.68323f, -1393.061f, 30.31373f, 290.2546f));
            }//Strawberry Discount Store
            else if (lod == 202)
            {
                ReturnDoor.Add(new Vector4(28.96781f, -1349.253f, 29.49702f, 349.537f));
                ReturnDoor.Add(new Vector4(25.11718f, -1345.543f, 30.48776f, 231.9489f));
            }//Strawberry Discount Store
            else if (lod == 203)
            {
                ReturnDoor.Add(new Vector4(-52.88647f, -1756.554f, 29.43416f, 143.6043f));
                ReturnDoor.Add(new Vector4(-46.79836f, -1757.04f, 30.41177f, 51.86034f));
            }//Davis LTD
            else if (lod == 204)
            {
                ReturnDoor.Add(new Vector4(133.3009f, -1711.617f, 29.29162f, 326.2934f));
                ReturnDoor.Add(new Vector4(134.2193f, -1708.729f, 30.26126f, 157.8225f));
            }//Davis Hurr Kutz Barber
            else if (lod == 205)
            {
                ReturnDoor.Add(new Vector4(811.8664f, -2148.177f, 29.61852f, 355.3167f));
                ReturnDoor.Add(new Vector4(819.6428f, -2154.499f, 30.67029f, 177.8436f));
            }//Cypress Flats Amunation
            else if (lod == 206)
            {
                ReturnDoor.Add(new Vector4(844.1276f, -1025.068f, 28.19486f, 6.730502f));
                ReturnDoor.Add(new Vector4(843.0151f, -1034.622f, 29.18494f, 17.27457f));
            }//La Messa Amunation
            else if (lod == 207)
            {
                ReturnDoor.Add(new Vector4(418.667f, -807.4464f, 29.49735f, 88.0585f));
                ReturnDoor.Add(new Vector4(426.3434f, -806.0979f, 30.42874f, 11.71891f));
            }//Textile city Binco
            else if (lod == 208)
            {
                ReturnDoor.Add(new Vector4(435.0849f, -981.7736f, 30.68999f, 93.36529f));
                ReturnDoor.Add(new Vector4(441.772f, -980.2394f, 31.88856f, 201.317f));
            }//Textile city Binco
            else if (lod == 210)
            {
                ReturnDoor.Add(new Vector4(232.1651f, 215.5015f, 106.2866f, 115.3194f));
                ReturnDoor.Add(new Vector4(261.084f, 206.4645f, 111.1749f, 198.9992f));
            }//Pacific Standard
            else if (lod == 211)
            {
                ReturnDoor.Add(new Vector4(321.3401f, 178.618f, 103.5865f, 54.3286f));
                ReturnDoor.Add(new Vector4(320.5998f, 181.025f, 104.6017f, 163.6563f));
            }//Blazing Tattoo
            else if (lod == 212)
            {
                ReturnDoor.Add(new Vector4(244.2425f, -45.33199f, 69.94102f, 259.0576f));
                ReturnDoor.Add(new Vector4(253.1506f, -50.18687f, 70.93226f, 73.36457f));
            }//Hawick Amunation
            else if (lod == 213)
            {
                ReturnDoor.Add(new Vector4(315.0778f, -276.4368f, 54.1745f, 344.6878f));
                ReturnDoor.Add(new Vector4(312.8551f, -287.5802f, 54.98235f, 348.5132f));
            }//Alta Fleeca
            else if (lod == 214)
            {
                ReturnDoor.Add(new Vector4(126.934f, -211.6729f, 54.55783f, 0.2745851f));
                ReturnDoor.Add(new Vector4(125.927f, -224.7314f, 55.49731f, 65.34232f));
            }//Hawick Suburban
            else if (lod == 215)
            {
                ReturnDoor.Add(new Vector4(-30.74291f, -148.107f, 57.0765f, 329.8208f));
                ReturnDoor.Add(new Vector4(-30.70009f, -150.9005f, 58.04656f, 97.13786f));
            }//Hair on Hawick
            else if (lod == 216)
            {
                ReturnDoor.Add(new Vector4(-156.864f, -305.4727f, 39.73328f, 259.0328f));
                ReturnDoor.Add(new Vector4(-163.8519f, -301.683f, 40.64306f, 268.3352f));
            }//Burton Ponsonbys
            else if (lod == 217)
            {
                ReturnDoor.Add(new Vector4(376.6949f, 323.3237f, 103.5729f, 355.8451f));
                ReturnDoor.Add(new Vector4(373.6239f, 328.0529f, 104.552f, 186.5067f));
            }//Downtown Vinewood 247
            else if (lod == 218)
            {
                ReturnDoor.Add(new Vector4(-350.1593f, -47.16426f, 49.04629f, 329.2907f));
                ReturnDoor.Add(new Vector4(-352.0561f, -58.33133f, 49.85812f, 82.51366f));
            }//Burton Fleeca
            else if (lod == 219)
            {
                ReturnDoor.Add(new Vector4(-716.1667f, -156.3794f, 37.41482f, 115.5722f));
                ReturnDoor.Add(new Vector4(-708.7256f, -153.5514f, 38.32484f, 136.9997f));
            }//Rockford Hills Ponsonbys
            else if (lod == 220)
            {
                ReturnDoor.Add(new Vector4(-822.8028f, -187.6799f, 37.56889f, 117.8194f));
                ReturnDoor.Add(new Vector4(-822.6823f, -184.4743f, 38.69706f, 301.5481f));
            }//Bob Mulet
            else if (lod == 221)
            {
                ReturnDoor.Add(new Vector4(-1214.375f, -328.0323f, 37.7812f, 5.189023f));
                ReturnDoor.Add(new Vector4(-1207.439f, -337.5352f, 38.59914f, 328.72f));
            }//Rockford Hills Fleeca
            else if (lod == 222)
            {
                ReturnDoor.Add(new Vector4(-1455.566f, -232.7532f, 49.79681f, 280.5753f));
                ReturnDoor.Add(new Vector4(-1450.507f, -238.8029f, 50.72213f, 68.06214f));
            }//Morningwood Ponsonbys
            else if (lod == 223)
            {
                ReturnDoor.Add(new Vector4(-1314.089f, -390.3267f, 36.69578f, 258.118f));
                ReturnDoor.Add(new Vector4(-1306.408f, -395.5128f, 37.6856f, 347.6946f));
            }//Morningwood Amunation
            else if (lod == 224)
            {
                ReturnDoor.Add(new Vector4(-1490.896f, -383.0551f, 40.16344f, 118.0251f));
                ReturnDoor.Add(new Vector4(-1485.374f, -379.7059f, 41.14347f, 143.8573f));
            }//Morningwood Robs Liquor
            else if (lod == 225)
            {
                ReturnDoor.Add(new Vector4(-1226.19f, -902.724f, 12.32649f, 28.43521f));
                ReturnDoor.Add(new Vector4(-1223.806f, -908.7477f, 13.30652f, 61.89384f));
            }//Vespucci Robs Liquor
            else if (lod == 226)
            {
                ReturnDoor.Add(new Vector4(-1287.599f, -1116.341f, 6.990116f, 84.65291f));
                ReturnDoor.Add(new Vector4(-1284.975f, -1115.544f, 7.964797f, 177.4811f));
            }//Beach Comb Over
            else if (lod == 227)
            {
                ReturnDoor.Add(new Vector4(-1154.706f, -1423.771f, 4.954461f, 317.0113f));
                ReturnDoor.Add(new Vector4(-1152.613f, -1424.466f, 5.971513f, 204.5794f));
            }//The Pit
            else if (lod == 228)
            {
                ReturnDoor.Add(new Vector4(-817.5858f, -1079.004f, 11.32602f, 34.50697f));
                ReturnDoor.Add(new Vector4(-822.9397f, -1073.192f, 12.26582f, 160.5977f));
            }//Vespucci Binco
            else if (lod == 229)
            {
                ReturnDoor.Add(new Vector4(-663.9017f, -944.2525f, 21.82922f, 177.0881f));
                ReturnDoor.Add(new Vector4(-663.5569f, -934.3276f, 22.82356f, 166.6555f));
            }//Little Seoul Amunation
            else if (lod == 230)
            {
                ReturnDoor.Add(new Vector4(-711.7455f, -916.4935f, 19.21559f, 170.116f));
                ReturnDoor.Add(new Vector4(-706.7984f, -914.6143f, 20.20385f, 178.0635f));
            }//Little Seoul Ltd
            else if (lod == 231)
            {
                ReturnDoor.Add(new Vector4(17.3216f, -1114.846f, 29.79753f, 178.665f));
                ReturnDoor.Add(new Vector4(12.23986f, -1106.567f, 30.85271f, 347.8857f));
            }//Pillbox Hill Amunation
            else if (lod == 232)
            {
                ReturnDoor.Add(new Vector4(150.8087f, -1037.847f, 29.37671f, 348.7251f));
                ReturnDoor.Add(new Vector4(148.5216f, -1049.169f, 30.18564f, 338.3234f));
            }//Legion Square Fleeca
            else if (lod == 240)
            {
                ReturnDoor.Add(new Vector4(-1095.742f, 2706.564f, 19.11933f, 187.9728f));
                ReturnDoor.Add(new Vector4(-1098.936f, 2714.363f, 20.04887f, 259.8563f));
            }//Route 68 Discount Store
            else if (lod == 241)
            {
                ReturnDoor.Add(new Vector4(-1113.155f, 2690.582f, 18.58048f, 30.80967f));
                ReturnDoor.Add(new Vector4(-1118.929f, 2699.01f, 19.54269f, 215.4088f));
            }//Route 68 Discount Store
            else if (lod == 242)
            {
                ReturnDoor.Add(new Vector4(-3164.419f, 1082.431f, 20.84674f, 265.6428f));
                ReturnDoor.Add(new Vector4(-3171.098f, 1088.883f, 21.83148f, 164.8269f));
            }//Chumash Amunation
            else if (lod == 243)
            {
                ReturnDoor.Add(new Vector4(-3168.188f, 1074.181f, 20.82917f, 246.0388f));
                ReturnDoor.Add(new Vector4(-3170.168f, 1073.559f, 21.86175f, 297.512f));
            }//Ink Inc
            else if (lod == 244)
            {
                ReturnDoor.Add(new Vector4(-3168.665f, 1055.827f, 20.86321f, 327.7726f));
                ReturnDoor.Add(new Vector4(-3169.666f, 1044.281f, 21.80242f, 114.5455f));
            }//Chumash Suburban
            else if (lod == 245)
            {
                ReturnDoor.Add(new Vector4(-3240.104f, 1004.307f, 12.87186f, 259.7368f));
                ReturnDoor.Add(new Vector4(-3243.794f, 1000.808f, 13.82119f, 89.20248f));
            }//Chumash Pier 247
            else if (lod == 246)
            {
                ReturnDoor.Add(new Vector4(-3038.654f, 589.4277f, 7.915496f, 282.9906f));
                ReturnDoor.Add(new Vector4(-3040.766f, 584.6509f, 8.896173f, 136.2227f));
            }//Banham Canyon 247
            else if (lod == 247)
            {
                ReturnDoor.Add(new Vector4(-2973.268f, 390.8301f, 15.04401f, 86.79399f));
                ReturnDoor.Add(new Vector4(-2966.992f, 389.2687f, 16.02059f, 108.5509f));
            }//Banham Canyon Robs
            else if (lod == 248)
            {
                ReturnDoor.Add(new Vector4(-2965.739f, 482.7742f, 15.69728f, 81.19646f));
                ReturnDoor.Add(new Vector4(-2954.123f, 484.3406f, 16.51488f, 339.2026f));
            }//Banham Canyon Fleeca
            else if (lod == 249)
            {
                ReturnDoor.Add(new Vector4(-1822.363f, 788.2674f, 138.1878f, 34.48137f));
                ReturnDoor.Add(new Vector4(-1819.824f, 793.0262f, 139.085f, 27.99921f));
            }//Richmond Glen LTD
            else if (lod == 250)
            {
                ReturnDoor.Add(new Vector4(1159.49f, -326.6035f, 69.22066f, 197.08f));
                ReturnDoor.Add(new Vector4(1163.882f, -322.1779f, 70.18836f, 152.9416f));
            }//Mirror Park LTD
            else if (lod == 251)
            {
                ReturnDoor.Add(new Vector4(1207.609f, -470.6983f, 66.20802f, 265.8058f));
                ReturnDoor.Add(new Vector4(1210.76f, -470.5638f, 67.17793f, 347.0766f));
            }//Mirror Park Hurr Kutz Barber
            else if (lod == 252)
            {
                ReturnDoor.Add(new Vector4(1141.251f, -981.0311f, 46.41581f, 258.5204f));
                ReturnDoor.Add(new Vector4(1134.445f, -980.5383f, 47.38715f, 234.6131f));
            }//Mirror Park Robs
            else if (lod == 253)
            {
                ReturnDoor.Add(new Vector4(1321.828f, -1650.137f, 52.28809f, 172.1863f));
                ReturnDoor.Add(new Vector4(1324.058f, -1650.701f, 53.29829f, 116.5949f));
            }//Los Santos Tattoos
            else if (lod == 254)
            {
                ReturnDoor.Add(new Vector4(2559.422f, 385.2873f, 108.6228f, 259.9387f));
                ReturnDoor.Add(new Vector4(2555.482f, 381.5786f, 109.6052f, 300.563f));
            }//Tataviam Mountains 247
            else if (lod == 255)
            {
                ReturnDoor.Add(new Vector4(2569.648f, 303.0545f, 108.7347f, 167.7597f));
                ReturnDoor.Add(new Vector4(2566.538f, 294.8987f, 109.7278f, 185.4707f));
            }//Tataviam Mountains Amunation
            else if (lod == 260)
            {
                ReturnDoor.Add(new Vector4(1174.946f, 2703.739f, 38.17236f, 162.7261f));
                ReturnDoor.Add(new Vector4(1173.675f, 2715.21f, 38.90606f, 69.10246f));
            }//Route 68 Fleesa
            else if (lod == 261)
            {
                ReturnDoor.Add(new Vector4(2681.709f, 3282.71f, 55.24113f, 242.5486f));
                ReturnDoor.Add(new Vector4(2676.935f, 3280.838f, 56.22447f, 72.42136f));
            }//Senora Fwy 247
            else if (lod == 262)
            {
                ReturnDoor.Add(new Vector4(1166.46f, 2704.063f, 38.16911f, 172.3756f));
                ReturnDoor.Add(new Vector4(1167.856f, 2710.205f, 39.13784f, 305.1126f));
            }//Scoops Liquor Barn
            else if (lod == 263)
            {
                ReturnDoor.Add(new Vector4(544.2431f, 2672.567f, 42.15654f, 16.03061f));
                ReturnDoor.Add(new Vector4(548.7296f, 2669.543f, 43.14573f, 20.92217f));
            }//Route 68 247
            else if (lod == 264)
            {
                ReturnDoor.Add(new Vector4(1964.995f, 3740.852f, 32.34375f, 200.6326f));
                ReturnDoor.Add(new Vector4(1959.736f, 3741.908f, 33.33325f, 220.1731f));
            }//Sandy Shores 247
            else if (lod == 265)
            {
                ReturnDoor.Add(new Vector4(1699.23f, 4929.234f, 42.06367f, 56.24549f));
                ReturnDoor.Add(new Vector4(1697.513f, 4923.969f, 43.05441f, 207.9999f));
            }//Grapeseed LTD
            else if (lod == 266)
            {
                ReturnDoor.Add(new Vector4(1990.352f, 3053.177f, 47.21531f, 322.5372f));
                ReturnDoor.Add(new Vector4(1984.934f, 3054.209f, 48.27825f, 331.2032f));
            }//Yellow Jack
            else if (lod == 267)
            {
                ReturnDoor.Add(new Vector4(1198.05f, 2703.375f, 38.23367f, 162.539f));
                ReturnDoor.Add(new Vector4(1196.388f, 2710.984f, 39.16017f, 153.4857f));
            }//Route 68 Discount Store
            else if (lod == 268)
            {
                ReturnDoor.Add(new Vector4(618.1059f, 2751.207f, 42.08809f, 182.9029f));
                ReturnDoor.Add(new Vector4(613.6006f, 2763.615f, 43.02694f, 358.8626f));
            }//Route 68 Suburban
            else if (lod == 269)
            {
                ReturnDoor.Add(new Vector4(1394.044f, 3599.894f, 34.98093f, 202.3793f));
                ReturnDoor.Add(new Vector4(1391.909f, 3605.599f, 35.98448f, 213.949f));
            }//Liquor Ace
            else if (lod == 270)
            {
                ReturnDoor.Add(new Vector4(1699.1f, 3752.683f, 34.70535f, 218.5117f));
                ReturnDoor.Add(new Vector4(1692.296f, 3760.092f, 35.69522f, 224.0666f));
            }//Sandy Shores Amunation
            else if (lod == 271)
            {
                ReturnDoor.Add(new Vector4(1860.348f, 3749.212f, 33.03185f, 110.9768f));
                ReturnDoor.Add(new Vector4(1864.513f, 3750.736f, 33.49981f, 266.3651f));
            }//Sandy Shores Tattoo
            else if (lod == 272)
            {
                ReturnDoor.Add(new Vector4(1933.468f, 3725.668f, 32.84442f, 238.6861f));
                ReturnDoor.Add(new Vector4(1931.329f, 3727.591f, 33.81389f, 315.7338f));
            }//O'Sheas Barbers
            else if (lod == 273)
            {
                ReturnDoor.Add(new Vector4(1686.866f, 4820.591f, 42.05852f, 94.18993f));
                ReturnDoor.Add(new Vector4(1695.807f, 4818.688f, 42.99728f, 84.88461f));
            }//Grapeseed Discount Stores
            else if (lod == 280)
            {
                ReturnDoor.Add(new Vector4(-110.2628f, 6463.395f, 31.62671f, 135.2242f));
                ReturnDoor.Add(new Vector4(-104.7238f, 6477.178f, 32.49498f, 352.3399f));
            }//Blane County Savings Bank
            else if (lod == 281)
            {
                ReturnDoor.Add(new Vector4(1731.257f, 6411.465f, 35.03723f, 150.7993f));
                ReturnDoor.Add(new Vector4(1729.08f, 6416.471f, 36.02796f, 237.5733f));
            }//Mount Chiliad 247
            else if (lod == 282)
            {
                ReturnDoor.Add(new Vector4(-0.8054564f, 6516.674f, 31.8792f, 40.45451f));
                ReturnDoor.Add(new Vector4(5.329187f, 6512.088f, 32.81543f, 97.91228f));
            }//Paleto Discount Store
            else if (lod == 283)
            {
                ReturnDoor.Add(new Vector4(-281.0984f, 6232.146f, 31.69552f, 45.12634f));
                ReturnDoor.Add(new Vector4(-278.5479f, 6230.81f, 32.6653f, 326.3536f));
            }//Paleto Herr Cuts
            else if (lod == 284)
            {
                ReturnDoor.Add(new Vector4(-289.7814f, 6199.538f, 31.48728f, 305.4105f));
                ReturnDoor.Add(new Vector4(-291.5757f, 6199.076f, 32.48285f, 276.8309f));
            }//Paleto Tattoo
            else if (lod == 285)
            {
                ReturnDoor.Add(new Vector4(-325.3472f, 6076.281f, 31.45477f, 243.8993f));
                ReturnDoor.Add(new Vector4(-332.3784f, 6083.077f, 32.44584f, 249.7347f));
            }//Paleto Amunation
            else if (lod == 300)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//LSIA Nightclub
            else if (lod == 301)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Elysian Island Nightclub
            else if (lod == 302)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Cypress Flats Nightclub
            else if (lod == 303)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//La Mesa Nightclub
            else if (lod == 304)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Stawberry Nightclub
            else if (lod == 305)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Mission Row Nightclub
            else if (lod == 306)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Downtown Vinewood Nightclub
            else if (lod == 307)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//West Vinewood Nightclub
            else if (lod == 308)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Vespucci Canals Nightclub
            else if (lod == 309)
            {
                ReturnDoor.Add(new Vector4(-1569.667f, -3017.43f, -74.40616f, 15.0804f));
            }//Del Perro Nightclub
            return ReturnDoor;
        }
        public static List<int> VehModBennys(int Spoilers, int FrontBumper, int RearBumper, int SideSkirt, int Exhaust, int Frame, int Grille, int Hood, int Fender, int RightFender, int Roof, int Engine, int Brakes, int Transmission, int Horns, int Suspension, int Armor, int Turbo, int Xenon, int FrontWheels, int Plateholders, int VanityPlates, int TrimDesign, int Ornaments, int Dashboard, int DialDesign, int DoorSpeaker, int Seats, int SteeringWheel, int ShiftLever, int Plaques, int Speakers, int Trunk, int Hydraulics, int EngineBlock, int Airfilter, int Struts, int ArchCover, int Aerials, int Trim, int Tank, int Windows, int Livery, int Plate, int WindowTint, int Colour1, int Colour2)
        {
            List<int> MyMods = new List<int>
            {
                Spoilers, FrontBumper, RearBumper, SideSkirt, Exhaust, Frame, Grille, Hood, Fender, RightFender, Roof, Engine, Brakes, Transmission, Horns, Suspension, Armor, -10, Turbo, -10, -10, -10, Xenon, FrontWheels, FrontWheels, Plateholders, VanityPlates, TrimDesign, Ornaments, Dashboard, DialDesign, DoorSpeaker, Seats, SteeringWheel, ShiftLever, Plaques, Speakers, Trunk, Hydraulics, EngineBlock, Airfilter, Struts, ArchCover, Aerials, Trim, Tank, Windows, -10, Livery, -10, -10, -10, -10, Plate, -10, WindowTint, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, Colour1, Colour2
            };
            return MyMods;
        }
        public static List<int> VehMod(int Spoilers, int FrontBumper, int RearBumper, int SideSkirt, int Exhaust, int Frame, int Grille, int Hood, int Fender, int RightFender, int Roof, int Engine, int Brakes, int Transmission, int Horns, int Suspension, int Armor, int Turbo, int Xenon, int FrontWheels, int Livery, int Plate, int WindowTint, int Colour1, int Colour2)
        {
            List<int> MyMods = new List<int>
            {
                Spoilers, FrontBumper, RearBumper, SideSkirt, Exhaust, Frame, Grille, Hood, Fender, RightFender, Roof, Engine, Brakes, Transmission, Horns, Suspension, Armor, -10, Turbo, -10, -10, -10, Xenon, FrontWheels, FrontWheels, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, Livery, -10, -10, -10, -10, Plate, -10, WindowTint, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, Colour1, Colour2
            };
            return MyMods;
        }
        public static List<int> VehPaint(int paint1, int paint2, int livery)
        {
            List<int> MyMods = new List<int>
            {
                -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, livery, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, paint1, paint2
            };
            return MyMods;
        }
        public static List<int> RandVehMod()
        {
            List<int> MyMods = new List<int>
            {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -10, -1, -10, -10, -10, -1, -1, -1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -1, -10, -10, -10, -10, -1, -10, -1, -10, -10, -10, -10, -10, -10, -10, -10, -10, -10, -1, -1
            };
            return MyMods;
        }
        public static PedFeat BikerPeds(int iBiz, bool bGuard, int iBlipColour, int iBlipText, int iTask)//37
        {
            bool bMale = false;
            int iGun = 0;
            if (bGuard)
                iGun = 3;
            PedFeat MyFeet;
            if (iBiz == 100) 
            {
                string sPed = "mp_f_forgery_01";
                if (RandomX.FindRandom("BikerPeds01", 1, 10) < 5 || bGuard)
                {
                    sPed = "mp_m_forgery_01";
                    bMale = true;
                }
                MyFeet = new PedFeat(sPed, false, 160, iTask, 0, null, iGun, true, iBlipColour, DataStore.MyLang.Maptext[iBlipText], new ClothBank("BikerPeds", false, false, bMale, BikerRaids_BizzPedsWork(iBiz, bGuard, bMale)));
            }//Forg
            else if (iBiz == 101) 
            {
                string sPed = "mp_f_cocaine_01";
                if (RandomX.FindRandom("BikerPeds01", 1, 10) < 5 || bGuard)
                {
                    sPed = "mp_m_cocaine_01";
                    bMale = true;
                }
                MyFeet = new PedFeat(sPed, false, 160, iTask, 0, null, iGun, true, iBlipColour, DataStore.MyLang.Maptext[iBlipText], new ClothBank("BikerPeds", false, false, bMale, BikerRaids_BizzPedsWork(iBiz, bGuard, bMale)));
            }//Coke
            else if (iBiz == 102) 
            {
                string sPed = "mp_f_weed_01";
                if (RandomX.FindRandom("BikerPeds01", 1, 10) < 5 || bGuard)
                {
                    sPed = "mp_m_weed_01";
                    bMale = true;
                }
                MyFeet = new PedFeat(sPed, false, 160, iTask, 0, null, iGun, true, iBlipColour, DataStore.MyLang.Maptext[iBlipText], new ClothBank("BikerPeds", false, false, bMale, BikerRaids_BizzPedsWork(iBiz, bGuard, bMale)));
            }//Weed
            else if (iBiz == 103) 
            {
                string sPed = "mp_f_counterfeit_01";
                if (RandomX.FindRandom("BikerPeds01", 1, 10) < 5 || bGuard)
                {
                    sPed = "mp_m_counterfeit_01";
                    bMale = true;
                }
                MyFeet = new PedFeat(sPed, false, 160, iTask, 0, null, iGun, true, iBlipColour, DataStore.MyLang.Maptext[iBlipText], new ClothBank("BikerPeds", false, false, bMale, BikerRaids_BizzPedsWork(iBiz, bGuard, bMale)));
            }//Cash
            else 
            {
                string sPed = "mp_f_meth_01";
                if (RandomX.FindRandom("BikerPeds01", 1, 10) < 5 || bGuard)
                {
                    sPed = "mp_m_meth_01";
                    bMale = true;
                }
                MyFeet = new PedFeat(sPed, false, 160, iTask, 0, null, iGun, true, iBlipColour, DataStore.MyLang.Maptext[iBlipText], new ClothBank("BikerPeds", false, false, bMale, BikerRaids_BizzPedsWork(iBiz, bGuard, bMale)));
            }//Meth

            return MyFeet;
        }
        public static ClothX BikerRaids_BizzPedsWork(int iBiz, bool bGuard, bool bMale)
        {
            LoggerLight.LogThis("BikerRaids_BizzPedsWork, iVariant == " + iBiz + ", bMale == " + bMale);

            List<int> iComp = new List<int>();
            List<int> itext = new List<int>();

            if (bMale)
            {
                if (bGuard)
                {   
                    if (iBiz == 100)
                    {
                        iComp.Add(3); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(3); itext.Add(0);//Torso
                        iComp.Add(3); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(1); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }           //forgery_
                    else if (iBiz == 101)
                    {
                        iComp.Add(1); itext.Add(2);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(1); itext.Add(0);//hair
                        iComp.Add(1); itext.Add(0);//Torso
                        iComp.Add(1); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(1); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(1); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }      //cocaine_
                    else if (iBiz == 102)
                    {
                        iComp.Add(1); itext.Add(2);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(1); itext.Add(0);//hair
                        iComp.Add(1); itext.Add(0);//Torso
                        iComp.Add(1); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(1); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(1); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }      //weed_
                    else if (iBiz == 103)
                    {
                        iComp.Add(3); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(2); itext.Add(0);//hair
                        iComp.Add(2); itext.Add(0);//Torso
                        iComp.Add(3); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }      //counterfeit_
                    else
                    {
                        iComp.Add(2); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(2); itext.Add(0);//hair
                        iComp.Add(2); itext.Add(0);//Torso
                        iComp.Add(1); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(2); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }                       //meth_
                }
                else
                {
                    if (iBiz == 100)
                    {
                        iComp.Add(RandomX.RandInt(0, 2)); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(0); itext.Add(0);//Torso
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//Legs
                        iComp.Add(1); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }           //forgery_
                    else if (iBiz == 101)
                    {
                        int iRace = RandomX.RandInt(0, 1);
                        iComp.Add(iRace); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(0); itext.Add(iRace);//Torso
                        iComp.Add(0); itext.Add(iRace);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(iRace);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }      //cocaine_
                    else if (iBiz == 102)
                    {
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//Torso
                        iComp.Add(RandomX.RandInt(0, 3)); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }      //weed_
                    else if (iBiz == 103)
                    {
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(0); itext.Add(0);//Torso
                        iComp.Add(0); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(1); itext.Add(0);//Top2
                    }      //counterfeit_
                    else
                    {
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//head
                        iComp.Add(0); itext.Add(0);//beard
                        iComp.Add(0); itext.Add(0);//hair
                        iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//Torso
                        iComp.Add(0); itext.Add(0);//Legs
                        iComp.Add(0); itext.Add(0);//Hands
                        iComp.Add(0); itext.Add(0);//shoes
                        iComp.Add(0); itext.Add(0);//Scarf
                        iComp.Add(0); itext.Add(0);//AccTop
                        iComp.Add(0); itext.Add(0);//Armor
                        iComp.Add(0); itext.Add(0);//Emb--not used
                        iComp.Add(0); itext.Add(0);//Top2
                    }                       //meth_
                }
            }
            else
            {
                if (iBiz == 100)
                {
                    int iRace = RandomX.RandInt(0, 3);
                    iComp.Add(iRace); itext.Add(0);//head
                    iComp.Add(0); itext.Add(0);//beard
                    if (iRace == 0)
                        iComp.Add(RandomX.RandInt(0, 1));
                    else if (iRace == 1)
                        iComp.Add(2);
                    else if (iRace == 2)
                        iComp.Add(4);
                    else
                        iComp.Add(5);
                    itext.Add(0);//hair
                    if (iRace == 0)
                        iComp.Add(RandomX.RandInt(0, 1));
                    else if (iRace == 1)
                        iComp.Add(2);
                    else if (iRace == 2)
                        iComp.Add(3);
                    else
                        iComp.Add(4);
                    itext.Add(0);//Torso
                    if (iRace == 0)
                        iComp.Add(0);
                    else if (iRace == 1)
                        iComp.Add(3);
                    else if (iRace == 2)
                        iComp.Add(4);
                    else
                        iComp.Add(5);
                    itext.Add(0);//Legs
                    iComp.Add(0); itext.Add(0);//Hands
                    iComp.Add(0); itext.Add(0);//shoes
                    iComp.Add(0); itext.Add(0);//Scarf
                    iComp.Add(2); itext.Add(0);//AccTop
                    iComp.Add(0); itext.Add(0);//Armor
                    iComp.Add(0); itext.Add(0);//Emb--not used
                    iComp.Add(0); itext.Add(0);//Top2
                }           //forgery_
                else if (iBiz == 101)
                {
                    int iRace = RandomX.RandInt(0, 1);
                    iComp.Add(iRace); itext.Add(0);//head
                    if (iRace == 0)
                        iRace = 1;
                    else
                        iRace = 3;
                    iComp.Add(0); itext.Add(0);//beard
                    iComp.Add(0); itext.Add(2);//hair
                    iComp.Add(0); itext.Add(iRace);//Torso
                    iComp.Add(0); itext.Add(iRace);//Leggs
                    iComp.Add(0); itext.Add(0);//Hands
                    if (iRace == 1)
                        iRace = 2;
                    else
                        iRace = 1;
                    iComp.Add(0); itext.Add(iRace);//shoes
                    iComp.Add(0); itext.Add(0);//Scarf
                    iComp.Add(0); itext.Add(0);//AccTop
                    iComp.Add(0); itext.Add(0);//Armor
                    iComp.Add(0); itext.Add(0);//Emb--not used
                    iComp.Add(0); itext.Add(0);//Top2
                }      //cocaine_
                else if (iBiz == 102)
                {
                    iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//head
                    iComp.Add(0); itext.Add(0);//beard
                    iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//hair
                    iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//Torso
                    iComp.Add(0); itext.Add(0);//Legs
                    iComp.Add(0); itext.Add(0);//Hands
                    iComp.Add(0); itext.Add(0);//shoes
                    iComp.Add(0); itext.Add(0);//Scarf
                    iComp.Add(0); itext.Add(0);//AccTop
                    iComp.Add(0); itext.Add(0);//Armor
                    iComp.Add(0); itext.Add(0);//Emb--not used
                    iComp.Add(0); itext.Add(0);//Top2
                }       //weed_
                else if (iBiz == 103)
                {
                    int iRace = RandomX.RandInt(0, 2);

                    iComp.Add(iRace); itext.Add(0);//head
                    iComp.Add(0); itext.Add(0);//beard
                    iComp.Add(RandomX.RandInt(0, 2)); itext.Add(0);//hair
                    if (iRace == 0)
                        iComp.Add(1);
                    else
                        iComp.Add(0);
                    itext.Add(0);//Torso
                    iComp.Add(RandomX.RandInt(0, 1)); itext.Add(0);//Legs
                    iComp.Add(0); itext.Add(0);//Hands
                    iComp.Add(0); itext.Add(0);//shoes
                    iComp.Add(0); itext.Add(0);//Scarf
                    iComp.Add(0); itext.Add(0);//AccTop
                    iComp.Add(0); itext.Add(0);//Armor
                    iComp.Add(0); itext.Add(0);//Emb--not used
                    iComp.Add(0); itext.Add(0);//Top2
                }       //counterfeit_
                else 
                {
                    iComp.Add(0); itext.Add(0);//head
                    iComp.Add(0); itext.Add(0);//beard
                    iComp.Add(0); itext.Add(0);//hair
                    iComp.Add(0); itext.Add(0);//Torso
                    iComp.Add(0); itext.Add(0);//Legs
                    iComp.Add(0); itext.Add(0);//Hands
                    iComp.Add(0); itext.Add(0);//shoes
                    iComp.Add(0); itext.Add(0);//Scarf
                    iComp.Add(0); itext.Add(0);//AccTop
                    iComp.Add(0); itext.Add(0);//Armor
                    iComp.Add(0); itext.Add(0);//Emb--not used
                    iComp.Add(0); itext.Add(0);//Top2
                }                       //meth_
            }
            return new ClothX("Biker Grove", iComp, itext, new List<int>(), new List<int>());
        }
        public static bool IsTargetDead(Ped NotTHisPed)
        {
            bool bDead = false;
            try
            {
               if ( Game.Player.GetTargetedEntity() != null)
                {
                    if (Game.Player.GetTargetedEntity().Handle != NotTHisPed.Handle && Game.Player.GetTargetedEntity().IsDead)
                        bDead = true;
                }
                return bDead;
            }
            catch
            {
                LoggerLight.LogThis("IsTargetDead -- Is At Fualt");
                return bDead;
            }
        }
        public static void FindFriends()
        {

        }

        public static ClothX PickAnOutfit(int pedHash)
        {
            string LoadInDir = "";
            if (pedHash == PedHash.Michael.GetHashCode())
                LoadInDir = "" + Directory.GetCurrentDirectory() + "/Outfits/Michael";
            else if (pedHash == PedHash.Franklin.GetHashCode())
                LoadInDir = "" + Directory.GetCurrentDirectory() + "/Outfits/Franklin";
            else if (pedHash == PedHash.Michael.GetHashCode())
                LoadInDir = "" + Directory.GetCurrentDirectory() + "/Outfits/Trevor";
            else if (pedHash == PedHash.FreemodeFemale01.GetHashCode())
                LoadInDir = "" + Directory.GetCurrentDirectory() + "/Outfits/Female";
            else if (pedHash == PedHash.FreemodeMale01.GetHashCode())
                LoadInDir = "" + Directory.GetCurrentDirectory() + "/Outfits/Male";

            if (Directory.Exists(LoadInDir))
            {
                string[] findOuts = Directory.GetFiles(LoadInDir);

                if ((int)findOuts.Count() > 0)
                {
                    int iRando = 0;

                    if (pedHash == PedHash.Michael.GetHashCode())
                        iRando = RandomX.FindRandom("PickOut_01", 0, (int)findOuts.Count() - 1);
                    else if (pedHash == PedHash.Franklin.GetHashCode())
                        iRando = RandomX.FindRandom("PickOut_02", 0, (int)findOuts.Count() - 1);
                    else if (pedHash == PedHash.Michael.GetHashCode())
                        iRando = RandomX.FindRandom("PickOut_03", 0, (int)findOuts.Count() - 1);
                    else if (pedHash == PedHash.FreemodeFemale01.GetHashCode())
                        iRando = RandomX.FindRandom("PickOut_04", 0, (int)findOuts.Count() - 1);
                    else if (pedHash == PedHash.FreemodeMale01.GetHashCode())
                        iRando = RandomX.FindRandom("PickOut_05", 0, (int)findOuts.Count() - 1);

                    return EntityLog.LoadIniOutfit(findOuts[iRando]);
                }
                else
                    return new ClothX();
            }
            else
                return new ClothX();
        }
    }
}
