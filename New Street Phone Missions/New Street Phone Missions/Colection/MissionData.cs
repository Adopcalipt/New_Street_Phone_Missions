using GTA;
using GTA.Math;
using New_Street_Phone_Missions.Classes;
using System.Collections.Generic;

namespace New_Street_Phone_Missions
{
    public static class MissionData
    {
        public static bool bPickUpHangUp = false;
        public static bool DrivinMissDasy = false;
        public static int iTracking = 0;
        public static int iUltPed01 = 0;
        public static int iUltMelle = 0;

        public static Ped MishNpc = null;

        public static Vehicle MishVeh = null;

        public static Pickup Pick_01 = null;
        public static Blip Target_01 = null;
        public static Camera cCams = null;

        public static Vector3 vFuMiss = Vector3.Zero;

        public static List<int> iCoronaList = new List<int>();
        public static List<int> iFireList = new List<int>();

        public static List<Blip> BlipList_01 = new List<Blip>();
        public static List<Ped> PedList_01 = new List<Ped>();
        public static List<Prop> PropList_01 = new List<Prop>();
        public static List<Pickup> PickList_01 = new List<Pickup>();
        public static List<Vehicle> VehicleList_01 = new List<Vehicle>();

        public static List<Truckers> TruckStop01 = new List<Truckers>();
        public static List<Truckers> TruckStop02 = new List<Truckers>();
        public static List<Truckers> TruckStop03 = new List<Truckers>();
        public static List<Truckers> TruckStop04 = new List<Truckers>();
        public static List<Truckers> TruckStop05 = new List<Truckers>();
        public static List<Truckers> TruckStop06 = new List<Truckers>();
        public static List<Truckers> TruckStop07 = new List<Truckers>();
        public static List<Truckers> TruckStop08 = new List<Truckers>();
        public static List<Truckers> TruckStop09 = new List<Truckers>();

        private static readonly List<Getaways> BankRobberies = new List<Getaways>
        {
            new Getaways(1, new Vector3(153.14f, -1040.56f, 29.36f), new Vector3(146.36f, -1037.06f, 29.36f), new Vector3(149.51f, -1042.43f, 29.37f), new Vector3(143.89f, -1042.30f, 29.36f), new Vector3(153.49f, -1028.8f, 28.27f), new Vector3(150.75f, -1038.1f, 28.37f)),
            new Getaways(2, new Vector3(-1210.38f, -328.4f, 37.78f), new Vector3(-1218.69f, -331.80f, 37.78f), new Vector3(-1213.4f, -332.9f, 37.78f), new Vector3(-1215.89f, -335.14f, 37.78f), new Vector3(-1215.89f, -316.1f, 36.6f), new Vector3(-1213.96f, -328.49f, 36.79f)),
            new Getaways(2, new Vector3(-355.93f, -46.87f, 49.87f), new Vector3(-348.05f, -50.75f, 49.87f), new Vector3(-351.39f, -51.48f, 49.03f), new Vector3(-356.51f, -50.15f, 49.87f), new Vector3(-333.14f, -34.69f, 46.68f), new Vector3(-350.13f, -47.35f, 48.04f)),
            new Getaways(3, new Vector3(-2963.27f, 485.51f, 15.7f), new Vector3(-2965.05f, 478.89f, 15.7f), new Vector3(-2961.03f, 482.98f, 15.7f), new Vector3(-2960.44f, 477.55f, 15.7f), new Vector3(-2973.78f, 481.35f, 14.25f), new Vector3(-2965.327f, 482.8784f, 14.7068f)),
            new Getaways(4, new Vector3(317.33f, -278.82f, 54.16f), new Vector3(309.55f, -275.55f, 54.16f), new Vector3(313.73f, -280.54f, 54.16f), new Vector3(308.59f, -279.34f, 54.16f), new Vector3(318.37f, -268.25f, 52.75f), new Vector3(314.91f, -276.55f, 53.17f)),
            new Getaways(5, new Vector3(1172.02f, 2704.79f, 38.08f), new Vector3(1180.37f, 2704.63f, 38.08f), new Vector3(1174.78f, 2708.3f, 38.08f), new Vector3(1180.47f, 2709.34f, 38.08f), new Vector3(1175.87f, 2696.26f, 36.96f), new Vector3(1175.08f, 2704.38f, 37.09f)),
            new Getaways(6, new Vector3(-113.77f, 6465.91f, 31.62f), new Vector3(-103.79f, 6468.15f, 31.62f), new Vector3(-111.15f, 6470.05f, 31.62f), new Vector3(-101.58f, 6463.33f, 31.62f), new Vector3(-117.14f, 6455.7f, 30.42f), new Vector3(-110.94f, 6462.72f, 30.64f)),
            new Getaways(99, new Vector3(240.84f, 220.54f, 106.28f), new Vector3(256.06f, 212.28f, 106.28f), new Vector3(252.73f, 226.67f, 106.28f), new Vector3(235.14f, 217.75f, 106.28f), new Vector3(226.55f, 211.96f, 104.54f), new Vector3(237.3f, 217.47f, 106.2f))
        };

        private static readonly List<GetawaysEnd> GetAwayEnds = new List<GetawaysEnd>
        {
            new GetawaysEnd(new Vector3(1308.297f, -1102.843f, 39.293f),"frogger",  new Vector4(1294.909f, -1054.381f, 38.968f, 111.613f), false),
            new GetawaysEnd(new Vector3(2329.072f, -2110.374f, 3.809f),"dinghy4", new Vector4(2345.769f, -2139.847f, -0.099f, -179.537f), false),
            new GetawaysEnd(new Vector3(1193.849f, -2652.611f, 6.080f),"velum2",  new Vector4(1203.572f, -2688.191f, 3.555f, 82.570f), true),
            new GetawaysEnd(new Vector3(1441.361f, 2031.346f, 118.143f),"supervolito2",  new Vector4(1419.391f, 2022.221f, 121.430f, 81.491f), false),
            new GetawaysEnd(new Vector3(2748.904f, 1255.312f, 3.381f),"dinghy4",  new Vector4(2798.711f, 1253.342f, 0.955f, -90.329f), false),
            new GetawaysEnd(new Vector3(-400.893f, 1569.692f, 352.506f),"Conada",  new Vector4(-419.706f, 1576.825f, 355.746f, -28.054f), false),
            new GetawaysEnd(new Vector3(-2419.884f, -315.711f, 4.917f),"dinghy3",  new Vector4(-2455.729f, -330.118f, 0.924f, 142.009f), false),
            new GetawaysEnd(new Vector3(-2444.183f, 763.111f, 288.192f),"swift2",  new Vector4(-2510.685f, 756.523f, 301.700f, -98.152f), false),
            new GetawaysEnd(new Vector3(-2107.048f, 2660.610f, 2.320f),"dodo",  new Vector4(-2086.680f, 2598.368f, 1.280f, 90.944f), true),
            new GetawaysEnd(new Vector3(-1830.039f, 4814.854f, 3.873f),"dinghy",  new Vector4(-1830.062f, 4840.844f, 0.946f, 37.564f), false),
            new GetawaysEnd(new Vector3(229.894f, 4375.003f, 43.719f),"dinghy5",  new Vector4(209.927f, 4327.414f, 30.477f, 169.301f), false),
            new GetawaysEnd(new Vector3(1972.935f, 4690.477f, 40.884f),"mogul",  new Vector4(1924.835f, 4709.808f, 41.579f, -65.658f), true),
            new GetawaysEnd(new Vector3(3805.755f, 4460.238f, 3.984f),"marquis",  new Vector4(3849.696f, 4478.333f, 0.209f, -78.995f), false),
            new GetawaysEnd(new Vector3(3330.595f, 5457.236f, 17.800f),"frogger",  new Vector4(3344.930f, 5504.851f, 19.953f, -104.023f), false),
            new GetawaysEnd(new Vector3(260.161f, 6934.811f, 8.098f),"velum2",  new Vector4(312.616f, 6939.503f, 4.231f, -147.951f), true),
            new GetawaysEnd(new Vector3(1739.698f, 3276.775f, 40.614f),"velum2",  new Vector4(1708.314f, 3251.935f, 41.870f, 105.248f), true),
            new GetawaysEnd(new Vector3(1828.590f, 6408.755f, 41.882f),"maverick",  new Vector4(1856.528f, 6402.727f, 46.473f, 91.475f), false)
        };

        public static List<PrePack> PackageDeliverys = new List<PrePack>
        {
            new PrePack(1, false, false, new Vector3(-412.229f, -2840.585f, 5.491673f), new Vector4(-417.4f, -2853.87f, 5.64f, 182.6f), "Mule2", "hei_prop_heist_wooden_box", -10, -10, 4, new List<Vector3> { new Vector3(606.1331f, -3076.071f, 6.06932f), new Vector3(670.8724f, -2656.838f, 6.081181f), new Vector3(368.3771f, -2449.551f, 6.103002f), new Vector3(262.8023f, -2501.746f, 6.440527f), new Vector3(134.7997f, -2477.386f, 5.999991f), new Vector3(116.2258f, -2559.884f, 5.999993f), new Vector3(11.09534f, -2675.23f, 6.008894f), new Vector3(-44.1941f, -2729.565f, 6.147783f), new Vector3(-111.609f, -2675.784f, 6.006345f), new Vector3(-234.9835f, -2663.382f, 6.000295f), new Vector3(-289.2259f, -2459.019f, 7.294806f), new Vector3(-336.0657f, -2457.042f, 7.294814f), new Vector3(-299.5649f, -2598.12f, 6.000296f), new Vector3(-314.4655f, -2777.074f, 5.00024f), new Vector3(1211.444f, -3103.413f, 6.027918f), new Vector3(1195.812f, -3254.429f, 7.095187f), new Vector3(755.6094f, -3181.837f, 7.405778f), new Vector3(821.003f, -3196.436f, 5.900819f), new Vector3(814.2813f, -2982.313f, 6.02089f) }, new List<string>()), //Seaport
            new PrePack(1, false, false, new Vector3(-412.229f, -2840.585f, 5.491673f), new Vector4(-417.4f, -2853.87f, 5.64f, 182.6f), "Mule2", "hei_prop_heist_wooden_box", -10, -10, 4, new List<Vector3> { new Vector3(-541.3153f, -2227.74f, 6.394024f),new Vector3(-623.8204f, -2361.339f, 13.95158f),new Vector3(-685.3821f, -2413.586f, 13.94453f),new Vector3(-705.3857f, -2448.599f, 13.9444f),new Vector3(-710.1678f, -2528.124f, 13.9444f),new Vector3(-815.3716f, -2782.938f, 13.94609f),new Vector3(-925.5151f, -2547.041f, 14.05221f),new Vector3(-863.3908f, -2387.771f, 14.02718f),new Vector3(-832.1877f, -2347.607f, 14.57062f),new Vector3(-1070.43f, -2249.979f, 12.10998f),new Vector3(-1098.497f, -2138.16f, 13.39889f),new Vector3(-1168.532f, -2022.022f, 13.16054f),new Vector3(-1071.398f, -2003.326f, 15.78551f),new Vector3(-967.1698f, -2069.492f, 9.405894f),new Vector3(-821.2372f, -2103.405f, 8.960634f),new Vector3(-754.8344f, -2226.979f, 5.786045f),new Vector3(-429.6969f, -2166.995f, 10.32835f),new Vector3(-457.2208f, -2266.364f, 8.515819f),new Vector3(-110.3373f, -2235.801f, 7.811676f),new Vector3(-398.9398f, -1876.624f, 20.52785f),new Vector3(-468.7385f, -1717.421f, 18.79402f),new Vector3(-553.7200f, -1813.109f, 22.82181f),new Vector3(-591.1908f, -1774.49f, 22.77674f),new Vector3(-586.3838f, -1588.896f, 26.75115f)}, new List<string>()), //Airport
            new PrePack(1, false, false, new Vector3(-412.229f, -2840.585f, 5.491673f), new Vector4(-417.4f, -2853.87f, 5.64f, 182.6f), "Mule2", "hei_prop_heist_wooden_box", -10, -10, 4, new List<Vector3> { new Vector3(1736.674f, -1609.645f, 112.4697f),new Vector3(1561.137f, -2133.279f, 77.4785f),new Vector3(1459.511f, -1935.92f, 71.30696f),new Vector3(1455.132f, -1682.857f, 66.06307f),new Vector3(1193.554f, -1240.154f, 36.32576f),new Vector3(1122.821f, -1303.704f, 34.71646f),new Vector3(994.2419f, -1555.895f, 30.75485f),new Vector3(918.1321f, -1516.955f, 30.96606f),new Vector3(903.4687f, -1590.887f, 30.22392f),new Vector3(804.6454f, -1666.87f, 30.86449f),new Vector3(746.9606f, -1862.089f, 29.29224f),new Vector3(1025.895f, -1686.251f, 33.57116f),new Vector3(928.8152f, -1726.541f, 32.15963f),new Vector3(897.4868f, -1864.518f, 30.61937f),new Vector3(1087.357f, -1970.058f, 31.01467f),new Vector3(973.9832f, -1978.706f, 30.63801f),new Vector3(890.3286f, -2001.457f, 30.61759f),new Vector3(953.8917f, -2117.238f, 30.55156f),new Vector3(879.512f, -2166.26f, 32.27139f),new Vector3(840.3463f, -2292.076f, 30.51253f),new Vector3(864.4549f, -2361.586f, 31.51551f),new Vector3(943.5316f, -2169.565f, 30.5664f),new Vector3(1002.891f, -2161.235f, 30.55158f),new Vector3(1041.598f, -2170.343f, 31.50933f),new Vector3(1019.803f, -2381.706f, 30.49956f),new Vector3(1095.563f, -2227.028f, 31.304f),new Vector3(1091.22f, -2279.994f, 30.14508f),new Vector3(1083.314f, -2413.066f, 30.23936f),new Vector3(923.9042f, -2533.111f, 28.30268f),new Vector3(1211.444f, -3103.413f, 6.027918f),new Vector3(1195.812f, -3254.429f, 7.095187f),new Vector3(755.6094f, -3181.837f, 7.405778f),new Vector3(821.003f, -3196.436f, 5.900819f),new Vector3(814.2813f, -2982.313f, 6.02089f)}, new List<string>()), //cypress.mess
            new PrePack(1, false, false, new Vector3(-412.229f, -2840.585f, 5.491673f), new Vector4(-417.4f, -2853.87f, 5.64f, 182.6f), "Mule2", "hei_prop_heist_wooden_box", -10, -10, 4, new List<Vector3> { new Vector3(109.8548f, -1595.567f, 30.89486f),new Vector3(211.0892f, -1856.77f, 27.20064f),new Vector3(257.4243f, -1801.21f, 27.11315f),new Vector3(479.7857f, -2168.685f, 5.918276f),new Vector3(450.7411f, -1881.882f, 26.81059f),new Vector3(540.288f, -1945.175f, 24.98511f),new Vector3(552.86f, -1639.724f, 28.15303f),new Vector3(488.4154f, -1524.887f, 29.29461f),new Vector3(454.5216f, -1305.83f, 30.12104f),new Vector3(349.7768f, -1246.292f, 32.50904f),new Vector3(150.8443f, -1338.228f, 29.20241f),new Vector3(5.289824f, -1308.736f, 30.16653f),new Vector3(-78.11802f, -1392.021f, 29.32072f),new Vector3(-175.5446f, -1268.026f, 32.59798f),new Vector3(-315.9799f, -1337.25f, 31.37128f),new Vector3(-205.8848f, -1353.025f, 31.26374f),new Vector3(727.3312f, -1191.563f, 24.27694f),new Vector3(866.8922f, -966.7406f, 27.86195f),new Vector3(742.6314f, -949.1918f, 25.63259f),new Vector3(866.7693f, -1059.789f, 28.92712f),new Vector3(895.7161f, -1140.812f, 25.94267f),new Vector3(915.3958f, -1267.584f, 25.56782f),new Vector3(754.502f, -1261.593f, 26.32873f),new Vector3(731.8141f, -1387.889f, 26.48004f)}, new List<string>()), //strawberry
            new PrePack(2, false, false, new Vector3(61.74551f, 99.28784f, 78.44849f), new Vector4(68.3553f, 120.66f, 79.04f, 159.0f), "Boxville2", "prop_cs_cardbox_01", 132, 70, 1, new List<Vector3> { new Vector3(-356.741f, 16.12581f, 47.85474f),new Vector3(-362.0493f, 57.46016f, 54.4298f),new Vector3(-411.5159f, 152.6001f, 81.74309f),new Vector3(-384.4481f, 153.008f, 81.74698f),new Vector3(-303.3091f, 84.56718f, 76.66209f),new Vector3(-313.5391f, 83.60252f, 75.65311f),new Vector3(-332.7193f, 88.68687f, 71.21808f),new Vector3(-263.5449f, 98.93026f, 77.56315f),new Vector3(-188.5497f, 184.8336f, 88.60064f),new Vector3(-154.3215f, 214.6461f, 98.32927f),new Vector3(-143.7316f, 174.7767f, 93.62655f),new Vector3(-161.3621f, 161.0014f, 89.70206f),new Vector3(-206.0126f, -7.720617f, 60.62708f),new Vector3(-161.1083f, -4.599355f, 66.46642f),new Vector3(-102.2039f, -31.8603f, 70.44765f),new Vector3(-18.69028f, -68.38952f, 61.37531f),new Vector3(-27.58074f, -61.06355f, 67.59225f),new Vector3(-21.88984f, -23.86292f, 73.24532f),new Vector3(-14.02445f, -11.82469f, 79.34619f),new Vector3(20.95977f, 114.1915f, 87.27728f),new Vector3(107.7924f, 54.56335f, 81.77329f),new Vector3(189.1337f, 11.49182f, 81.41087f),new Vector3(212.0644f, 1.590603f, 79.19212f),new Vector3(188.576f, 40.0778f, 87.82249f),new Vector3(208.1531f, 73.78002f, 96.09595f),new Vector3(284.9831f, 47.12731f, 96.6929f),new Vector3(254.5233f, 25.36229f, 92.12718f),new Vector3(388.1746f, 2.197361f, 91.41467f),new Vector3(485.1955f, 212.3895f, 108.3095f)}, new List<string>()), //burton vinwood
            new PrePack(2, false, false, new Vector3(61.74551f, 99.28784f, 78.44849f), new Vector4(68.3553f, 120.66f, 79.04f, 159.0f), "Boxville2", "prop_cs_cardbox_01", 132, 70, 1, new List<Vector3> { new Vector3(-1177.005f, -1073.163f, 5.906403f),new Vector3(-1183.198f, -1064.417f, 2.150418f),new Vector3(-1191.016f, -1054.863f, 2.150433f),new Vector3(-1188.258f, -1041.719f, 2.150275f),new Vector3(-1201.109f, -1031.956f, 2.150406f),new Vector3(-1204.234f, -1021.773f, 5.945113f),new Vector3(-1338.218f, -941.2662f, 15.35802f),new Vector3(-1353.765f, -908.0026f, 12.4705f),new Vector3(-1335.845f, -1146.224f, 6.731401f),new Vector3(-1252.488f, -1143.985f, 8.513974f),new Vector3(-1172.675f, -1260.892f, 14.90674f),new Vector3(-1229.549f, -1235.521f, 11.02771f),new Vector3(-1306.429f, -1229.076f, 8.980485f),new Vector3(-1317.88f, -1238.943f, 7.168704f),new Vector3(-1272.146f, -1295.553f, 8.285895f),new Vector3(-1246.816f, -1358.752f, 7.820462f),new Vector3(-1145.777f, -1466.309f, 7.690706f),new Vector3(-1156.229f, -1574.861f, 8.345174f),new Vector3(-1098.117f, -1673.513f, 8.39401f),new Vector3(-1059.984f, -1657.836f, 4.674311f),new Vector3(-1070.926f, -1636.006f, 8.194701f),new Vector3(-1076.572f, -1620.789f, 4.442664f),new Vector3(-1078.258f, -1616.337f, 4.428094f),new Vector3(-1093.088f, -1607.943f, 8.458809f),new Vector3(-1112.636f, -1577.709f, 8.679523f),new Vector3(-1148.522f, -1523.617f, 10.62805f),new Vector3(-1116.498f, -1506.122f, 4.403326f),new Vector3(-1110.924f, -1498.482f, 4.672343f),new Vector3(-1102.588f, -1492.073f, 4.887649f),new Vector3(-1108.559f, -1527.218f, 6.779534f),new Vector3(-1091.374f, -1517.666f, 4.792679f),new Vector3(-1086.088f, -1503.486f, 5.707945f),new Vector3(-1085.366f, -1558.724f, 4.489116f),new Vector3(-1077.584f, -1553.464f, 4.625066f),new Vector3(-1066.284f, -1545.243f, 4.902433f),new Vector3(-1057.291f, -1551.201f, 4.911008f),new Vector3(-1043.943f, -1579.937f, 5.03639f),new Vector3(-1048.449f, -1579.996f, 4.944197f),new Vector3(-1056.9f, -1587.358f, 4.613483f),new Vector3(-1038.341f, -1609.897f, 5.003761f),new Vector3(-956.5812f, -1432.736f, 7.679167f),new Vector3(-868.7635f, -1286.318f, 13.20004f),new Vector3(-936.1241f, -1310.397f, 9.70009f),new Vector3(-869.3542f, -1103.725f, 6.445571f),new Vector3(-903.3987f, -1005.532f, 2.150328f),new Vector3(-913.8767f, -989.0179f, 2.150327f),new Vector3(-908.3992f, -976.228f, 2.150325f),new Vector3(-942.7357f, -969.0355f, 2.150114f),new Vector3(-934.5264f, -939.1158f, 2.145313f),new Vector3(-947.3409f, -927.6057f, 2.145313f),new Vector3(-975.7267f, -909.0048f, 2.159486f),new Vector3(-1022.753f, -896.6989f, 5.41547f),new Vector3(-1023.957f, -912.3516f, 6.961076f),new Vector3(-1042.891f, -924.6329f, 3.154166f),new Vector3(-1053.634f, -929.9891f, 7.554896f),new Vector3(-1061.149f, -943.5154f, 2.182675f),new Vector3(-1091.015f, -925.9146f, 3.146876f),new Vector3(-1161.481f, -973.403f, 2.150194f),new Vector3(-1181.619f, -988.9208f, 2.150193f),new Vector3(-1204.326f, -943.4292f, 8.114918f),new Vector3(-1151.095f, -913.4648f, 6.628778f),new Vector3(-1042.812f, -1024.366f, 2.150358f),new Vector3(-1008.249f, -1036.944f, 2.150358f),new Vector3(-1000.026f, -1030.441f, 2.150311f),new Vector3(-997.8235f, -1012.419f, 2.150311f),new Vector3(-967.3852f, -1008.264f, 2.15031f),new Vector3(-978.1533f, -990.1673f, 4.545312f),new Vector3(-995.0858f, -966.8881f, 2.54532f),new Vector3(-1018.765f, -963.067f, 2.150194f),new Vector3(-1027.697f, -968.8497f, 2.1502f),new Vector3(-1035.725f, -984.0291f, 2.150194f),new Vector3(-1055.298f, -998.6008f, 6.410484f),new Vector3(-1130.638f, -1031.046f, 2.150357f),new Vector3(-1122.727f, -1027.076f, 2.150356f),new Vector3(-1113.141f, -1018.701f, 2.150358f),new Vector3(-1103.691f, -1013.49f, 2.150357f),new Vector3(-1101.415f, -1082.764f, 2.150356f),new Vector3(-1128.448f, -1080.953f, 4.222689f),new Vector3(-1064.395f, -1057.067f, 6.411655f),new Vector3(-1075.633f, -1026.472f, 4.545251f),new Vector3(-921.0966f, -1095.091f, 2.15031f),new Vector3(-946.3143f, -1050.763f, 2.171845f),new Vector3(-951.3636f, -1079.171f, 2.15031f),new Vector3(-960.2056f, -1109.441f, 2.150381f),new Vector3(-982.7823f, -1066.106f, 2.150313f),new Vector3(-982.4726f, -1083.512f, 2.545213f),new Vector3(-970.9428f, -1120.898f, 2.171845f),new Vector3(-991.4828f, -1103.666f, 2.150312f),new Vector3(-986.8842f, -1122.311f, 4.545273f),new Vector3(-1031.39f, -1109.176f, 2.1586f),new Vector3(-1004.998f, -1154.655f, 2.158741f),new Vector3(-1022.293f, -1160.524f, 2.1586f),new Vector3(-1031.984f, -1173.81f, 2.158597f),new Vector3(-1063.752f, -1132.606f, 2.158602f),new Vector3(-1091.859f, -1145.276f, 2.158598f),new Vector3(-1064.242f, -1159.144f, 2.159603f),new Vector3(-1068.306f, -1163.143f, 2.745344f),new Vector3(-1099.331f, -1210.65f, 2.538017f),new Vector3(-1094.835f, -1218.866f, 2.674695f),new Vector3(-1087.718f, -1230.778f, 2.91478f),new Vector3(-1126.017f, -1172.03f, 2.357591f),new Vector3(-1128.641f, -1162.314f, 6.494957f),new Vector3(-1128.47f, -1143.433f, 2.840051f),new Vector3(-1145.392f, -1127.529f, 6.503163f),new Vector3(-1142.907f, -1122.372f, 2.643049f),new Vector3(-1159.114f, -1100.559f, 6.531281f)}, new List<string>()), //little soul vaspuci
            new PrePack(2, false, false, new Vector3(61.74551f, 99.28784f, 78.44849f), new Vector4(68.3553f, 120.66f, 79.04f, 159.0f), "Boxville2", "prop_cs_cardbox_01", 132, 70, 1, new List<Vector3> { new Vector3(-1469.499f, 23.98446f, 53.64318f),new Vector3(-1509.753f, 6.369807f, 56.06623f),new Vector3(-1579.321f, 12.67341f, 61.08215f),new Vector3(-1625.327f, 8.889999f, 62.53669f),new Vector3(-1599.91f, -33.59167f, 58.19274f),new Vector3(-1544.099f, -98.91996f, 54.52899f),new Vector3(-1481.332f, -41.2363f, 56.84435f),new Vector3(-1182.347f, 305.6922f, 69.89175f),new Vector3(-1134.616f, 362.8218f, 74.93424f),new Vector3(-1111.962f, 313.533f, 66.97783f),new Vector3(-1041.385f, 296.4107f, 66.7803f),new Vector3(-1045.758f, 374.5154f, 69.94336f),new Vector3(-870.2264f, 357.041f, 85.10243f),new Vector3(-889.8139f, 311.1008f, 84.12887f),new Vector3(-805.5648f, 250.4268f, 79.11285f),new Vector3(-1043.047f, 237.5888f, 64.16473f),new Vector3(-1020.127f, 162.336f, 58.53504f),new Vector3(-975.7432f, 103.4353f, 55.89742f),new Vector3(-908.3871f, 125.7879f, 55.31467f),new Vector3(-949.7228f, 214.9841f, 67.34995f),new Vector3(-889.1459f, 201.5653f, 69.83292f),new Vector3(-794.7856f, 176.6714f, 72.83533f),new Vector3(-819.6236f, 108.1988f, 56.65382f),new Vector3(-896.2682f, 50.55714f, 50.03809f),new Vector3(-929.5912f, 32.33089f, 49.22243f),new Vector3(-895.6555f, -23.75793f, 41.92866f),new Vector3(-856.2868f, -33.26972f, 44.154f)}, new List<string>()), //delpero rockford
            new PrePack(2, false, false, new Vector3(61.74551f, 99.28784f, 78.44849f), new Vector4(68.3553f, 120.66f, 79.04f, 159.0f), "Boxville2", "prop_cs_cardbox_01", 132, 70, 1, new List<Vector3> { new Vector3(-876.4699f, 486.163f, 87.81596f),new Vector3(-814.6655f, 465.4533f, 90.76906f),new Vector3(-831.5496f, 512.7079f, 94.61716f),new Vector3(-900.957f, 507.1272f, 92.22887f),new Vector3(-859.8825f, 549.3598f, 97.02918f),new Vector3(-903.6682f, 549.173f, 97.32504f),new Vector3(-898.3152f, 598.1339f, 104.9367f),new Vector3(-924.5178f, 562.5059f, 99.80518f),new Vector3(-951.625f, 613.6896f, 109.6659f),new Vector3(-947.6028f, 568.3109f, 101.4761f),new Vector3(-973.9167f, 583.9152f, 101.9155f),new Vector3(-1107.415f, 593.4894f, 104.4546f),new Vector3(-1031.149f, 564.9263f, 100.5148f),new Vector3(-1068.457f, 562.9708f, 102.7286f),new Vector3(-1126.343f, 552.0135f, 102.2961f),new Vector3(-1146.912f, 547.5715f, 101.4294f),new Vector3(-1164.63f, 589.8889f, 101.8328f),new Vector3(-1200.821f, 582.1893f, 100.1303f),new Vector3(-1197.679f, 533.1424f, 96.21648f),new Vector3(-1290.315f, 501.1377f, 97.55988f),new Vector3(-932.3692f, 472.0573f, 85.11881f),new Vector3(-983.5774f, 442.0766f, 79.97154f),new Vector3(-970.5432f, 534.5553f, 81.67139f),new Vector3(-1012.013f, 527.2021f, 79.61324f),new Vector3(-984.8823f, 475.62f, 82.26645f),new Vector3(-1013.231f, 457.128f, 79.36449f),new Vector3(-1060.118f, 515.8932f, 84.381f),new Vector3(-1067.292f, 482.6874f, 85.3016f),new Vector3(-1036.205f, 443.2584f, 72.86395f),new Vector3(-1105.836f, 429.959f, 75.6862f),new Vector3(-1118.202f, 505.9364f, 82.24579f),new Vector3(-1161.977f, 501.0114f, 86.0938f),new Vector3(-1160.795f, 434.7254f, 86.63664f),new Vector3(-1215.607f, 458.8355f, 91.85357f),new Vector3(-1257.983f, 447.0746f, 94.73567f),new Vector3(-1294.518f, 455.4332f, 97.35609f),new Vector3(-1308.411f, 453.3697f, 99.70641f),new Vector3(-1332.115f, 491.9036f, 102.4476f),new Vector3(-1346.35f, 441.8075f, 100.9924f),new Vector3(-1409.876f, 445.3276f, 112.22f),new Vector3(-1392.663f, 517.6506f, 123.292f),new Vector3(-1452.043f, 545.3224f, 120.7994f),new Vector3(-1458.978f, 500.1378f, 117.5965f),new Vector3(-1493.765f, 541.6144f, 118.2722f),new Vector3(-1493.509f, 421.1047f, 111.2437f),new Vector3(-1542.629f, 408.7433f, 109.6781f),new Vector3(-1067.901f, 821.439f, 166.8808f),new Vector3(-1097.104f, 824.2603f, 168.6352f),new Vector3(-1145.602f, 799.0558f, 167.4061f),new Vector3(-1107.727f, 738.1865f, 159.9176f),new Vector3(-1144.178f, 718.804f, 155.4649f),new Vector3(-1197.619f, 694.1948f, 147.4094f),new Vector3(-1219.122f, 665.3551f, 144.5338f),new Vector3(-1223.961f, 636.0889f, 142.7451f),new Vector3(-1262.987f, 692.0536f, 150.6537f),new Vector3(-1282.651f, 663.9969f, 144.8519f),new Vector3(-1270.896f, 629.1021f, 143.23f),new Vector3(-1331.552f, 588.2698f, 134.37f),new Vector3(-1384.961f, 606.8231f, 133.8726f),new Vector3(-1372.576f, 585.5729f, 131.4471f),new Vector3(-1356.573f, 537.3622f, 124.6708f),new Vector3(-1400.062f, 577.7793f, 127.0419f),new Vector3(-599.9012f, 481.0077f, 109.0135f),new Vector3(-585.5557f, 541.2571f, 109.6203f),new Vector3(-615.4255f, 475.7243f, 108.8786f),new Vector3(-640.5946f, 519.4641f, 109.6877f),new Vector3(-657.5634f, 462.1192f, 110.3896f),new Vector3(-679.0991f, 511.4417f, 113.526f),new Vector3(-741.4827f, 507.2439f, 110.1819f),new Vector3(-709.9409f, 439.7062f, 106.8985f),new Vector3(-747.0872f, 409.5476f, 96.0173f),new Vector3(-775.8024f, 476.9246f, 100.1721f),new Vector3(-833.1953f, 404.6588f, 91.55969f),new Vector3(-1070.472f, 749.7695f, 168.0472f),new Vector3(-1059.009f, 712.2664f, 165.5936f),new Vector3(-1020.068f, 718.5629f, 163.9963f),new Vector3(-974.3307f, 685.3311f, 158.0342f),new Vector3(-951.1431f, 683.4838f, 153.578f),new Vector3(-908.5171f, 694.7616f, 151.4326f),new Vector3(-886.0207f, 699.3416f, 151.2711f),new Vector3(-853.3905f, 696.6192f, 148.7828f),new Vector3(-809.6923f, 674.0168f, 147.2904f),new Vector3(-763.8483f, 651.5327f, 145.5013f),new Vector3(-751.5979f, 621.2493f, 142.2435f),new Vector3(-745.7672f, 589.5885f, 142.6156f),new Vector3(-703.7216f, 590.2789f, 142.0164f),new Vector3(-687.9229f, 597.8907f, 143.642f),new Vector3(-643.7551f, 632.6365f, 149.619f),new Vector3(-704.4034f, 627.3926f, 155.1603f),new Vector3(-568.2637f, 665.2595f, 145.4776f),new Vector3(-544.3185f, 694.801f, 146.0745f),new Vector3(-621.2768f, 637.5131f, 151.041f),new Vector3(-707.6903f, 712.0728f, 162.0412f),new Vector3(-663.5795f, 742.3569f, 174.2841f),new Vector3(-601.3591f, 711.8802f, 180.0073f),new Vector3(-608.6313f, 771.2157f, 188.5102f),new Vector3(-554.4477f, 754.2482f, 185.425f),new Vector3(-577.0934f, 812.272f, 191.2517f),new Vector3(-658.4011f, 784.6013f, 196.5904f),new Vector3(-781.4969f, 792.8298f, 214.57f),new Vector3(-818.0649f, 795.6208f, 202.5863f),new Vector3(-859.8956f, 766.4213f, 191.8201f),new Vector3(-906.9011f, 752.5503f, 182.1613f),new Vector3(-931.3448f, 827.0118f, 184.3368f),new Vector3(-956.7988f, 846.5051f, 177.4667f),new Vector3(-953.8853f, 736.2907f, 175.5582f),new Vector3(-1011.727f, 773.0004f, 171.3789f),new Vector3(-1019.988f, 829.1194f, 172.3859f)}, new List<string>()), //vinwood hills
            new PrePack(3, false, false, new Vector3(-3131.44f, 1111.76f, 20.12679f), new Vector4(-3139.27f, 1098.87f, 20.63f, 81.7f), "Rumpo2", "prop_paper_bag_01", -10, -10, 0, new List<Vector3> { new Vector3(-3225.671f, 911.6782f, 13.99328f),new Vector3(-3238.209f, 922.1356f, 13.95989f),new Vector3(-3242.884f, 931.8699f, 17.22135f),new Vector3(-3237.128f, 952.9849f, 13.14549f),new Vector3(-3251.259f, 1027.374f, 11.75769f),new Vector3(-3254.493f, 1063.829f, 11.1462f),new Vector3(-3252.789f, 1077.478f, 11.03329f),new Vector3(-3228.171f, 1092.434f, 10.75639f),new Vector3(-3233.788f, 1110.743f, 10.57354f),new Vector3(-3220.034f, 1137.555f, 9.895407f),new Vector3(-3214.605f, 1149.277f, 9.895408f),new Vector3(-3205.43f, 1151.904f, 9.662267f),new Vector3(-3199.772f, 1165.077f, 9.654344f),new Vector3(-3205.8f, 1186.661f, 9.664678f),new Vector3(-3203.429f, 1206.695f, 12.82314f),new Vector3(-3193.675f, 1230.114f, 10.04832f),new Vector3(-3197.585f, 1274.163f, 12.66765f),new Vector3(-3181.797f, 1310.762f, 14.55494f)}, new List<string>()),
            new PrePack(3, false, false, new Vector3(-3131.44f, 1111.76f, 20.12679f), new Vector4(-3139.27f, 1098.87f, 20.63f, 81.7f), "Rumpo2", "prop_paper_bag_01", -10, -10, 0, new List<Vector3> {new Vector3(-3109.391f, 751.4032f, 24.70188f),new Vector3(-3106.902f, 719.2998f, 20.61939f),new Vector3(-3087.058f, 656.056f, 11.5886f),new Vector3(-3051.573f, 569.4459f, 7.823583f),new Vector3(-3044.509f, 564.0283f, 7.818895f),new Vector3(-3036.565f, 558.9866f, 7.507683f),new Vector3(-3036.482f, 544.608f, 7.507683f),new Vector3(-3041.9f, 523.9325f, 7.426294f),new Vector3(-3038.055f, 492.2998f, 6.767862f),new Vector3(-3053.02f, 487.0674f, 6.779647f),new Vector3(-3049.986f, 474.4078f, 6.779647f),new Vector3(-3069.546f, 454.4254f, 9.643095f),new Vector3(-3073.3f, 452.9189f, 6.357774f),new Vector3(-3080.653f, 406.0587f, 6.968522f),new Vector3(-3090.885f, 379.1903f, 7.112432f),new Vector3(-3102.068f, 367.1784f, 7.119124f),new Vector3(-3100.813f, 361.2336f, 7.59102f),new Vector3(-3110.472f, 335.3844f, 7.493347f),new Vector3(-3111.59f, 315.6106f, 8.38104f),new Vector3(-3115.084f, 303.729f, 8.38104f),new Vector3(-3115.483f, 294.5401f, 8.972106f),new Vector3(-3131.787f, 247.3237f, 12.492f),new Vector3(-3099.842f, 211.6886f, 14.0702f),new Vector3(-2973.217f, 600.1259f, 24.24677f),new Vector3(-2973.584f, 642.0483f, 25.79752f),new Vector3(-2995.112f, 682.2404f, 25.04422f),new Vector3(-2986.079f, 719.8495f, 28.49687f),new Vector3(-3018.052f, 746.3233f, 27.58763f) }, new List<string>()),
            new PrePack(3, false, false, new Vector3(-3131.44f, 1111.76f, 20.12679f), new Vector4(-3139.27f, 1098.87f, 20.63f, 81.7f), "Rumpo2", "prop_paper_bag_01", -10, -10, 0, new List<Vector3> { new Vector3(-1754.303f, -708.6591f, 10.39663f),new Vector3(-1764.108f, -708.2756f, 10.6142f),new Vector3(-1764.566f, -708.1951f, 14.04145f),new Vector3(-1764.033f, -708.2069f, 17.64467f),new Vector3(-1777.351f, -702.067f, 10.4848f),new Vector3(-1776.769f, -691.2233f, 16.97348f),new Vector3(-1780.731f, -680.2358f, 10.44997f),new Vector3(-1793.184f, -673.2136f, 10.57397f),new Vector3(-1803.759f, -662.3365f, 10.7237f),new Vector3(-1817.498f, -657.4927f, 13.81193f),new Vector3(-1827.267f, -652.1654f, 18.04963f),new Vector3(-1834.165f, -641.7821f, 11.47759f),new Vector3(-1836.708f, -631.6794f, 10.74891f),new Vector3(-1838.648f, -629.8493f, 11.0014f),new Vector3(-1879.679f, -606.2506f, 18.92933f),new Vector3(-1885.089f, -600.3168f, 11.89937f),new Vector3(-1885.209f, -600.2053f, 15.5457f),new Vector3(-1884.697f, -600.3395f, 19.14856f),new Vector3(-1890.028f, -592.5482f, 18.331f),new Vector3(-1901.561f, -586.2667f, 11.8717f),new Vector3(-1901.737f, -586.5366f, 15.50729f),new Vector3(-1901.345f, -586.4103f, 18.8586f),new Vector3(-1913.928f, -574.6428f, 11.43515f),new Vector3(-1920.347f, -570.4515f, 11.91194f),new Vector3(-1920.237f, -570.4377f, 14.7448f),new Vector3(-1915.89f, -565.7648f, 17.67347f),new Vector3(-1915.907f, -565.6242f, 20.47274f),new Vector3(-1923.306f, -559.0013f, 12.06105f),new Vector3(-1927.94f, -551.8524f, 11.84189f),new Vector3(-1946.505f, -548.1843f, 14.72549f),new Vector3(-1950.271f, -545.1097f, 14.72549f),new Vector3(-1958.221f, -538.7208f, 11.89937f),new Vector3(-1958.538f, -538.6161f, 15.55085f),new Vector3(-1957.957f, -538.9095f, 19.15357f),new Vector3(-1968.042f, -532.4321f, 12.17067f),new Vector3(-1976.333f, -525.4742f, 18.92434f),new Vector3(-1980.079f, -520.5913f, 11.894f),new Vector3(-1980.366f, -520.8674f, 14.7404f),new Vector3(-1976.356f, -516.4469f, 17.67827f),new Vector3(-1976.218f, -516.0389f, 20.4677f)}, new List<string>()),
            new PrePack(3, false, false, new Vector3(-3131.44f, 1111.76f, 20.12679f), new Vector4(-3139.27f, 1098.87f, 20.63f, 81.7f), "Rumpo2", "prop_paper_bag_01", -10, -10, 0, new List<Vector3> {new Vector3(-1909.111f, 129.635f, 82.45064f),new Vector3(-1859.039f, 207.8242f, 84.29408f),new Vector3(-1959.546f, 212.3604f, 86.51141f),new Vector3(-1893.244f, 251.7575f, 86.25306f),new Vector3(-1981.675f, 244.1014f, 87.61314f),new Vector3(-1908.839f, 292.472f, 88.60768f),new Vector3(-1861.554f, 310.2534f, 89.11358f),new Vector3(-1769.747f, 346.0624f, 93.37177f),new Vector3(-1742.369f, 364.5176f, 88.72827f),new Vector3(-1673.764f, 371.5128f, 85.11893f),new Vector3(-2009.15f, 316.877f, 91.56063f),new Vector3(-1919.008f, 356.4274f, 93.78138f),new Vector3(-1931.474f, 398.6515f, 96.50707f),new Vector3(-2021.623f, 369.8535f, 94.57845f),new Vector3(-1932.137f, 452.8219f, 102.7027f),new Vector3(-2027.374f, 449.6474f, 105.6779f),new Vector3(-2037.174f, 495.6615f, 107.012f),new Vector3(-1923.487f, 543.7314f, 114.82f),new Vector3(-2004.955f, 602.0804f, 117.9033f),new Vector3(-1929.894f, 595.8158f, 122.2849f),new Vector3(-1994.404f, 639.9923f, 122.5362f),new Vector3(-1878.629f, 651.9398f, 130.00f) }, new List<string>()),
            new PrePack(4, false, false, new Vector3(954.853f, -146.4427f, 73.91478f), new Vector4(985.1311f, -138.0587f, 71.72433f, 58.15194f), "SlamVan2", "ng_proc_binbag_01a", -10, -10, 0, new List<Vector3> { new Vector3(1207.021f, -673.2103f, 61.11215f),new Vector3(1213.941f, -701.9628f, 60.30816f),new Vector3(1215.253f, -729.3919f, 58.94733f),new Vector3(995.0197f, -739.0646f, 57.44802f),new Vector3(988.8434f, -710.9371f, 58.0252f),new Vector3(962.9817f, -696.3831f, 58.0994f),new Vector3(957.2084f, -665.1748f, 58.01148f),new Vector3(1002.87f, -591.4628f, 59.20106f),new Vector3(1018.085f, -566.4f, 59.66459f),new Vector3(1004.908f, -526.3587f, 60.40078f),new Vector3(983.4021f, -540.3289f, 59.63057f),new Vector3(964.0696f, -554.757f, 59.00647f),new Vector3(969.8193f, -576.8511f, 58.87088f),new Vector3(962.0546f, -606.3818f, 59.49267f),new Vector3(926.4136f, -570.8307f, 57.92761f),new Vector3(892.5603f, -595.6162f, 57.554f),new Vector3(868.2073f, -578.7185f, 57.647f),new Vector3(857.3127f, -560.0723f, 57.47778f),new Vector3(883.0701f, -550.0735f, 57.53517f),new Vector3(879.7803f, -506.7889f, 57.45839f),new Vector3(918.1938f, -519.1744f, 58.69641f),new Vector3(930.3493f, -485.4208f, 60.08249f),new Vector3(963.7202f, -496.1301f, 61.53802f),new Vector3(965.8538f, -463.4195f, 62.22671f),new Vector3(1014.155f, -460.7629f, 64.06299f),new Vector3(996.7019f, -441.6269f, 63.93599f),new Vector3(1066.67f, -450.9628f, 65.49625f),new Vector3(1061.671f, -477.5435f, 64.04195f),new Vector3(1056.921f, -502.142f, 62.67876f),new Vector3(1082.299f, -489.9038f, 63.51603f),new Vector3(1098.596f, -474.7681f, 66.93564f),new Vector3(1097.893f, -426.1955f, 67.28503f),new Vector3(942.2897f, -255.0595f, 67.49841f),new Vector3(932.2645f, -252.0051f, 68.14607f),new Vector3(927.1663f, -228.3628f, 70.33281f),new Vector3(878.4464f, -210.3623f, 70.78152f),new Vector3(853.2083f, -192.314f, 72.63569f),new Vector3(813.6287f, -168.7192f, 73.92041f),new Vector3(799.2471f, -161.8204f, 73.72651f),new Vector3(787.4902f, -143.8369f, 74.82004f),new Vector3(789.5784f, -121.7295f, 75.86514f),new Vector3(772.9427f, -133.7863f, 74.83371f)}, new List<string>()),
            new PrePack(4, false, false, new Vector3(954.853f, -146.4427f, 73.91478f), new Vector4(985.1311f, -138.0587f, 71.72433f, 58.15194f), "SlamVan2", "ng_proc_binbag_01a", -10, -10, 0, new List<Vector3> { new Vector3(1268.203f, -422.6983f, 69.09253f),new Vector3(1267.012f, -447.5618f, 69.81529f),new Vector3(1269.74f, -483.0303f, 69.09258f),new Vector3(1263.176f, -500.3384f, 69.10938f),new Vector3(1255.999f, -525.82f, 69.04993f),new Vector3(1364.71f, -559.247f, 74.50141f),new Vector3(1379.771f, -592.6221f, 74.51224f),new Vector3(1350.297f, -590.8824f, 74.4875f),new Vector3(1324.882f, -572.6253f, 73.32757f),new Vector3(1251.123f, -570.0441f, 69.21765f),new Vector3(1254.815f, -596.3622f, 69.01241f),new Vector3(1261.984f, -613.939f, 68.88661f),new Vector3(1260.629f, -643.8718f, 67.85249f),new Vector3(1282.915f, -678.0354f, 65.91342f),new Vector3(1262.216f, -717.5988f, 64.4155f),new Vector3(1191.326f, -549.5949f, 64.66839f),new Vector3(1190.161f, -585.5353f, 64.16667f),new Vector3(1191.312f, -600.8296f, 63.97587f),new Vector3(1196.803f, -625.5676f, 63.02939f)}, new List<string>()),
            new PrePack(5, false, true, new Vector3(1977.48f, 4653.158f, 40.45607f), new Vector4(1929.128f, 4645.529f, 39.35381f, 74.04933f), "Scrap", "None", -10, -10, 5, new List<Vector3> { new Vector3(3294.645f, 5188.46f, 18.41536f),new Vector3(2234.094f, 5608.012f, 54.64093f),new Vector3(2256.062f, 5158.674f, 57.96902f),new Vector3(1697.929f, 4874.469f, 42.03117f),new Vector3(1648.552f, 4781.981f, 42.11193f),new Vector3(1717.678f, 4679.414f, 43.65579f),new Vector3(1667.145f, 4680.101f, 43.05535f),new Vector3(1677.29f, 4653.63f, 43.37117f),new Vector3(1364.512f, 4359.951f, 44.4988f),new Vector3(740.5996f, 4170.04f, 41.0878f)}, new List<string>()),
            new PrePack(5, false, true, new Vector3(1977.48f, 4653.158f, 40.45607f), new Vector4(1929.128f, 4645.529f, 39.35381f, 74.04933f), "Scrap", "None", -10, -10, 5, new List<Vector3> { new Vector3(1366.07f, 3648.678f, 33.78039f),new Vector3(1441.558f, 3630.086f, 34.97598f),new Vector3(1424.652f, 3665.129f, 39.72842f),new Vector3(1503.234f, 3699.392f, 39.05916f),new Vector3(1641.75f, 3729.399f, 35.06714f),new Vector3(1648.607f, 3810.293f, 38.65067f),new Vector3(1669.977f, 3743.251f, 34.86417f),new Vector3(1745.342f, 3700.265f, 34.34354f),new Vector3(1779.095f, 3642.883f, 34.47246f),new Vector3(1782.287f, 3745.965f, 34.65663f),new Vector3(1746.644f, 3785.375f, 34.83487f),new Vector3(1778.128f, 3802.267f, 38.36934f),new Vector3(1811.733f, 3853.763f, 34.53526f),new Vector3(1719.855f, 3851.263f, 34.79908f),new Vector3(1712.258f, 3844.736f, 35.09302f),new Vector3(1737.591f, 3899.409f, 35.559f),new Vector3(1781.677f, 3907.481f, 39.80395f),new Vector3(1815.851f, 3907.366f, 37.2175f),new Vector3(1885.031f, 3911.95f, 33.09767f),new Vector3(1920.32f, 3890.656f, 32.65907f),new Vector3(1903.048f, 3876.147f, 32.4305f),new Vector3(1859.193f, 3852.417f, 33.03402f),new Vector3(1871.298f, 3806.77f, 32.64043f),new Vector3(1894.649f, 3785.76f, 32.77509f),new Vector3(1947.112f, 3803.384f, 32.03712f),new Vector3(1915.621f, 3822.773f, 32.43993f),new Vector3(1939.32f, 3851.287f, 32.16716f),new Vector3(1975.69f, 3814.874f, 33.42525f)}, new List<string>()),
            new PrePack(5, false, true, new Vector3(1977.48f, 4653.158f, 40.45607f), new Vector4(1929.128f, 4645.529f, 39.35381f, 74.04933f), "Scrap", "None", -10, -10, 5, new List<Vector3> { new Vector3(2184.301f, 3503.538f, 45.41576f),new Vector3(2190.204f, 3340.191f, 45.70337f),new Vector3(2152.329f, 3390.411f, 45.40681f),new Vector3(2168.019f, 3379.724f, 46.43439f),new Vector3(2379.093f, 3350.109f, 47.95228f),new Vector3(2484.173f, 3446.39f, 51.06676f),new Vector3(2482.338f, 3722.635f, 43.92163f),new Vector3(2412.371f, 4034.768f, 36.81679f),new Vector3(2552.169f, 4281.502f, 41.61633f),new Vector3(2637.038f, 4245.829f, 44.80367f),new Vector3(2726.922f, 4143.099f, 44.28887f),new Vector3(2734.81f, 4274.33f, 48.5205f)}, new List<string>()),
            new PrePack(5, false, true, new Vector3(1977.48f, 4653.158f, 40.45607f), new Vector4(1929.128f, 4645.529f, 39.35381f, 74.04933f), "Scrap", "None", -10, -10, 5, new List<Vector3> { new Vector3(1541.871f, 2239.158f, 77.69897f),new Vector3(1379.956f, 2164.427f, 97.81518f),new Vector3(768.7703f, 2177.563f, 52.37225f),new Vector3(730.4855f, 2332.482f, 50.53867f),new Vector3(-264.924f, 2206.832f, 130.0993f),new Vector3(-33.62269f, 1943.332f, 190.1862f),new Vector3(201.6048f, 2437.004f, 60.46714f),new Vector3(380.8315f, 2574.337f, 43.51957f),new Vector3(470.6082f, 2607.824f, 44.47719f),new Vector3(498.1459f, 2605.617f, 43.69965f),new Vector3(995.9922f, 2719.427f, 40.08806f),new Vector3(982.1971f, 2669.811f, 40.06126f),new Vector3(1582.44f, 2906.777f, 56.95695f)}, new List<string>()),
            new PrePack(6, true, false, new Vector3(-422.5247f, 6061.337f, 30.88972f), new Vector4(-410.65f, 6064.71f, 31.08f, 182.5f), "Cruiser", "prop_cliff_paper", -10, -10, 0, new List<Vector3> { new Vector3(35.34615f, 6662.261f, 32.1904f),new Vector3(-8.791785f, 6652.338f, 31.11401f),new Vector3(-40.96972f, 6637.074f, 31.08753f),new Vector3(-130.0771f, 6551.079f, 29.52209f),new Vector3(-230.2176f, 6444.808f, 31.19743f),new Vector3(-247.7849f, 6412.838f, 31.19486f),new Vector3(-271.8068f, 6399.928f, 31.34099f),new Vector3(-368.535f, 6340.365f, 29.84361f),new Vector3(-406.8186f, 6313.565f, 28.94281f),new Vector3(-448.7317f, 6272.207f, 33.33007f),new Vector3(-454.3108f, 6198.265f, 29.55284f)}, new List<string>()),
            new PrePack(6, true, false, new Vector3(-422.5247f, 6061.337f, 30.88972f), new Vector4(-410.65f, 6064.71f, 31.08f, 182.5f), "Cruiser", "prop_cliff_paper", -10, -10, 0, new List<Vector3> { new Vector3(0.8270233f, 6613.946f, 31.87855f),new Vector3(-27.163f, 6597.772f, 31.86064f),new Vector3(-45.85287f, 6583.171f, 32.17552f),new Vector3(-105.2644f, 6528.991f, 30.16692f),new Vector3(-190.2481f, 6411.322f, 31.91249f),new Vector3(-214.6027f, 6396.603f, 33.08506f),new Vector3(-228.32f, 6378.578f, 31.759f),new Vector3(-249.2476f, 6371.27f, 31.48093f),new Vector3(-282.0695f, 6352.01f, 32.48915f),new Vector3(-303.2068f, 6329.105f, 32.48937f),new Vector3(-333.4198f, 6303.397f, 33.08813f),new Vector3(-358.663f, 6261.862f, 31.48751f),new Vector3(-379.498f, 6253.611f, 31.8508f)}, new List<string>()),
            new PrePack(6, true, false, new Vector3(-422.5247f, 6061.337f, 30.88972f), new Vector4(-410.65f, 6064.71f, 31.08f, 182.5f), "Cruiser", "prop_cliff_paper", -10, -10, 0, new List<Vector3> { new Vector3(32.80961f, 6595.813f, 32.47044f),new Vector3(13.30143f, 6577.16f, 32.73557f),new Vector3(-14.45749f, 6558.055f, 33.24044f),new Vector3(-163.1803f, 6390.546f, 31.47822f),new Vector3(-346.0628f, 6222.56f, 31.48944f),new Vector3(-355.9504f, 6206.227f, 31.4893f),new Vector3(-373.7543f, 6190.161f, 31.72942f)}, new List<string>()),
            new PrePack(6, true, false, new Vector3(-422.5247f, 6061.337f, 30.88972f), new Vector4(-410.65f, 6064.71f, 31.08f, 182.5f), "Cruiser", "prop_cliff_paper", -10, -10, 0, new List<Vector3> { new Vector3(-399.6143f, 6379.244f, 14.10481f),new Vector3(-454.451f, 6337.76f, 12.78236f),new Vector3(-482.027f, 6277.658f, 13.35727f)}, new List<string>())
        };

        private static readonly List<ConsOnParade> ConvictRoutes = new List<ConsOnParade>
        {
            new ConsOnParade(1, new Vector3(808.463f, -1292.11f, 26.20689f), new Vector4(859.1813f, -1350.158f, 26.32215f, 89.46764f), new List<Vector3>{new Vector3(228.6289f, -1394.52f, 30.494f),new Vector3(252.5324f, -1400.599f, 30.53424f),new Vector3(273.3281f, -1378.727f, 31.95101f),new Vector3(273.2798f, -1359.458f, 31.93511f),new Vector3(250.2143f, -1339.669f, 31.92071f),new Vector3(235.2781f, -1346.481f, 30.5051f),new Vector3(219.2509f, -1365.954f, 30.56017f)}),
            new ConsOnParade(1, new Vector3(808.463f, -1292.11f, 26.20689f), new Vector4(859.1813f, -1350.158f, 26.32215f, 89.46764f), new List<Vector3>{new Vector3(-227.1508f, -2023.395f, 27.75543f),new Vector3(-222.3802f, -2007.24f, 27.75543f),new Vector3(-219.4253f, -1989.297f, 27.75542f),new Vector3(-221.2715f, -1971.702f, 27.75571f),new Vector3(-224.2942f, -1960.297f, 27.75689f),new Vector3(-240.3955f, -1966.939f, 29.94605f),new Vector3(-239.069f, -1973.878f, 29.94605f),new Vector3(-237.4634f, -1992.5f, 29.94605f),new Vector3(-240.9862f, -2009.94f, 29.94605f),new Vector3(-249.9569f, -2026.076f, 29.94605f),new Vector3(-263.3784f, -2040.735f, 29.94605f),new Vector3(-277.9292f, -2048.336f, 29.94605f),new Vector3(-273.3261f, -2064.927f, 27.75543f),new Vector3(-246.0456f, -2048.949f, 27.75543f),new Vector3(-235.4299f, -2037.349f, 27.75543f)}),
            new ConsOnParade(1, new Vector3(808.463f, -1292.11f, 26.20689f), new Vector4(859.1813f, -1350.158f, 26.32215f, 89.46764f), new List<Vector3>{new Vector3(-924.767f, -2571.403f, 13.97616f),new Vector3(-943.3739f, -2565.557f, 13.93645f),new Vector3(-961.3f, -2544.967f, 13.98062f),new Vector3(-967.3834f, -2523.3f, 13.98103f),new Vector3(-965.3172f, -2502.885f, 13.98098f),new Vector3(-960.5615f, -2492.263f, 13.98057f),new Vector3(-947.3313f, -2478.542f, 13.9807f),new Vector3(-932.3168f, -2470.56f, 13.9807f),new Vector3(-913.9728f, -2467.62f, 13.98073f),new Vector3(-889.0792f, -2472.986f, 13.98049f),new Vector3(-872.939f, -2489.196f, 13.98072f),new Vector3(-866.3092f, -2501.952f, 13.98075f),new Vector3(-863.3466f, -2512.478f, 13.98059f),new Vector3(-863.6301f, -2528.947f, 13.98072f),new Vector3(-869.4406f, -2546.69f, 13.97835f),new Vector3(-884.2811f, -2561.323f, 13.98074f),new Vector3(-896.1907f, -2568.416f, 13.98074f),new Vector3(-903.6213f, -2570.235f, 13.98074f)}),
            new ConsOnParade(1, new Vector3(808.463f, -1292.11f, 26.20689f), new Vector4(859.1813f, -1350.158f, 26.32215f, 89.46764f), new List<Vector3>{new Vector3(-287.7649f, -1638.534f, 31.84882f),new Vector3(-298.8279f, -1656.257f, 31.84881f),new Vector3(-317.5655f, -1644.264f, 31.85344f),new Vector3(-303.9065f, -1622.695f, 31.84882f)}),
            new ConsOnParade(1, new Vector3(808.463f, -1292.11f, 26.20689f), new Vector4(859.1813f, -1350.158f, 26.32215f, 89.46764f), new List<Vector3>{new Vector3(1476.682f, -1984.691f, 70.69158f),new Vector3(1453.445f, -1972.131f, 70.44451f),new Vector3(1434.379f, -1986.595f, 65.75795f),new Vector3(1423.388f, -2007.92f, 61.90174f),new Vector3(1433.237f, -2031.683f, 57.47531f),new Vector3(1469.974f, -2042.295f, 57.02632f),new Vector3(1478.932f, -2002.187f, 68.38514f)}),
            new ConsOnParade(2, new Vector3(-550.1166f, -147.5585f, 38.26155f), new Vector4(-561.4053f, -163.2523f, 38.38601f, 112.3586f), new List<Vector3>{new Vector3(129.9129f, -988.9407f, 29.32248f), new Vector3(169.9703f, -880.6992f, 30.55882f), new Vector3(174.1833f, -881.5703f, 30.89416f), new Vector3(186.1561f, -849.1542f, 31.16665f), new Vector3(193.5296f, -847.7554f, 30.91245f), new Vector3(263.498f, -872.455f, 29.17216f), new Vector3(211.1392f, -1018.212f, 29.30549f) }),
            new ConsOnParade(2, new Vector3(-550.1166f, -147.5585f, 38.26155f), new Vector4(-561.4053f, -163.2523f, 38.38601f, 112.3586f), new List<Vector3>{new Vector3(356.3345f, 160.7301f, 103.0043f), new Vector3(222.6689f, 208.8755f, 105.5123f), new Vector3(266.2624f, 328.2007f, 105.5289f), new Vector3(339.1058f, 311.9287f, 104.5361f), new Vector3(404.6719f, 292.2426f, 102.9655f)}),
            new ConsOnParade(2, new Vector3(-550.1166f, -147.5585f, 38.26155f), new Vector4(-561.4053f, -163.2523f, 38.38601f, 112.3586f), new List<Vector3>{new Vector3(-68.89455f, -402.1517f, 37.29737f), new Vector3(-103.1039f, -389.6021f, 36.63163f), new Vector3(-108.889f, -409.1098f, 35.77497f), new Vector3(-127.2451f, -411.5541f, 34.58294f), new Vector3(-139.3882f, -421.2568f, 33.74562f), new Vector3(-148.7219f, -435.5255f, 33.47985f), new Vector3(-153.0547f, -451.4209f, 33.79173f), new Vector3(-145.8188f, -464.7188f, 33.17519f), new Vector3(-132.132f, -472.3099f, 33.07674f), new Vector3(-121.9619f, -474.8518f, 33.34896f), new Vector3(-89.17182f, -474.3718f, 34.96899f), new Vector3(-77.55576f, -466.7515f, 36.39326f), new Vector3(-67.24388f, -449.3546f, 38.11158f), new Vector3(-64.59761f, -437.8882f, 38.43552f), new Vector3(-64.19228f, -419.8323f, 38.09665f)}),
            new ConsOnParade(2, new Vector3(-550.1166f, -147.5585f, 38.26155f), new Vector4(-561.4053f, -163.2523f, 38.38601f, 112.3586f), new List<Vector3>{new Vector3(-736.3101f, 90.46006f, 55.58132f), new Vector3(-737.0633f, 69.59921f, 54.30896f), new Vector3(-734.0124f, 47.01559f, 47.47584f), new Vector3(-728.4005f, 29.74567f, 42.26787f), new Vector3(-703.6444f, 36.59576f, 43.22058f), new Vector3(-681.6513f, 46.41314f, 43.09964f), new Vector3(-661.1816f, 46.04203f, 41.12265f), new Vector3(-658.776f, 85.53405f, 52.46266f), new Vector3(-662.4477f, 103.3301f, 56.80659f), new Vector3(-662.0488f, 119.3575f, 57.01698f), new Vector3(-675.6852f, 115.9964f, 56.75283f), new Vector3(-709.5087f, 98.95238f, 56.07108f), new Vector3(-718.9947f, 95.15092f, 55.8739f)}),
            new ConsOnParade(2, new Vector3(-550.1166f, -147.5585f, 38.26155f), new Vector4(-561.4053f, -163.2523f, 38.38601f, 112.3586f), new List<Vector3>{new Vector3(-1765.645f, -1149.159f, 13.07916f), new Vector3(-1837.407f, -1227.053f, 13.01728f), new Vector3(-1869.622f, -1210.43f, 13.01711f), new Vector3(-1831.916f, -1162.537f, 13.01727f), new Vector3(-1806.807f, -1181.257f, 13.01744f), new Vector3(-1797.633f, -1177.67f, 13.01751f), new Vector3(-1786.751f, -1169.576f, 13.01768f), new Vector3(-1660.035f, -1023.637f, 13.01778f), new Vector3(-1652.489f, -1014.507f, 13.01739f), new Vector3(-1659.945f, -1009.417f, 13.01739f), new Vector3(-1709.898f, -1070.201f, 13.01735f), new Vector3(-1709.359f, -1083.783f, 13.10089f)}),
            new ConsOnParade(3, new Vector3(-1155.791f, -833.9677f, 14.30229f), new Vector4(-1066.42f, -855.1868f, 5.125729f, 215.7682f), new List<Vector3>{new Vector3(-2891.325f, -8.690169f, 7.963134f), new Vector3(-2910.282f, -37.03131f, 3.024998f), new Vector3(-2999.717f, 0.8205602f, 4.733732f), new Vector3(-2997.566f, 30.52503f, 7.300454f), new Vector3(-2995.444f, 36.81783f, 7.95881f), new Vector3(-2992.152f, 35.16978f, 8.5967f), new Vector3(-2987.468f, 42.83352f, 11.6085f), new Vector3(-2939.735f, 20.68083f, 11.60792f), new Vector3(-2943.227f, 12.65156f, 11.60476f), new Vector3(-2918.954f, 1.69491f, 11.60532f), new Vector3(-2891.381f, -6.391256f, 11.60316f), new Vector3(-2888.387f, 2.114674f, 11.608f), new Vector3(-2886.561f, 0.7008348f, 11.608f), new Vector3(-2888.892f, -7.902122f, 7.959469f)}),
            new ConsOnParade(3, new Vector3(-1155.791f, -833.9677f, 14.30229f), new Vector4(-1066.42f, -855.1868f, 5.125729f, 215.7682f), new List<Vector3>{new Vector3(-1486.228f, 875.5378f, 182.6471f), new Vector3(-1478.33f, 831.1494f, 181.7178f), new Vector3(-1514.694f, 814.3276f, 181.9242f), new Vector3(-1521.786f, 816.0013f, 181.8818f), new Vector3(-1532.458f, 826.3513f, 181.4863f), new Vector3(-1543.011f, 817.2687f, 182.2451f), new Vector3(-1549.201f, 782.2504f, 188.5506f), new Vector3(-1558.725f, 777.4117f, 189.1925f), new Vector3(-1584.688f, 765.293f, 189.1942f), new Vector3(-1592.872f, 784.2383f, 189.194f), new Vector3(-1578.12f, 790.5488f, 189.1929f), new Vector3(-1585.357f, 804.7038f, 185.9943f), new Vector3(-1575.385f, 809.5252f, 185.9944f), new Vector3(-1578.809f, 818.0173f, 185.9939f), new Vector3(-1534.582f, 848.1694f, 181.7705f), new Vector3(-1521.602f, 854.8638f, 181.5947f), new Vector3(-1496.966f, 870.4911f, 181.9422f)}),
            new ConsOnParade(3, new Vector3(-1155.791f, -833.9677f, 14.30229f), new Vector4(-1066.42f, -855.1868f, 5.125729f, 215.7682f), new List<Vector3>{new Vector3(-1893.8f, 1974.631f, 143.1386f), new Vector3(-1929.31f, 1969.096f, 148.8142f), new Vector3(-1966.108f, 1968.237f, 154.9804f), new Vector3(-1982.965f, 1961.467f, 160.8532f), new Vector3(-1987.9f, 1950.067f, 167.1869f), new Vector3(-1982.987f, 1941.103f, 171.1532f), new Vector3(-1945.131f, 1917.294f, 173.789f), new Vector3(-1938.31f, 1890.808f, 179.907f), new Vector3(-1954.827f, 1842.859f, 180.2473f), new Vector3(-1957.488f, 1830.848f, 178.8064f), new Vector3(-1945.764f, 1820.129f, 172.0853f), new Vector3(-1937.965f, 1823.133f, 170.6982f), new Vector3(-1920.848f, 1840.997f, 166.5749f), new Vector3(-1899.503f, 1851.748f, 160.8903f), new Vector3(-1879.112f, 1865.361f, 156.9021f), new Vector3(-1841.115f, 1891.895f, 146.2764f), new Vector3(-1836.474f, 1901.321f, 145.8237f), new Vector3(-1839.368f, 1912.564f, 147.3022f), new Vector3(-1853.069f, 1930.572f, 150.2391f), new Vector3(-1878.708f, 1956.751f, 145.8794f)}),
            new ConsOnParade(3, new Vector3(-1155.791f, -833.9677f, 14.30229f), new Vector4(-1066.42f, -855.1868f, 5.125729f, 215.7682f), new List<Vector3>{new Vector3(-319.6601f, 2786.814f, 59.43f), new Vector3(-337.5543f, 2800.789f, 58.15808f), new Vector3(-338.9051f, 2804.992f, 58.13386f), new Vector3(-327.3314f, 2822.454f, 58.19631f), new Vector3(-317.4219f, 2826.94f, 58.47928f), new Vector3(-312.7925f, 2831.25f, 58.25769f), new Vector3(-310.0566f, 2831.212f, 58.38048f), new Vector3(-297.7459f, 2823.444f, 59.15673f), new Vector3(-299.6138f, 2818.963f, 59.19112f), new Vector3(-295.6808f, 2811.254f, 58.98975f), new Vector3(-308.6064f, 2790.959f, 59.41709f), new Vector3(-316.4038f, 2787.014f, 59.56699f), new Vector3(-323.0881f, 2789.975f, 59.20899f)}),
            new ConsOnParade(3, new Vector3(-1155.791f, -833.9677f, 14.30229f), new Vector4(-1066.42f, -855.1868f, 5.125729f, 215.7682f), new List<Vector3>{new Vector3(-2768.271f, 2695.774f, 1.370201f), new Vector3(-2755.266f, 2703.515f, 1.416718f), new Vector3(-2735.553f, 2738.595f, 1.462122f), new Vector3(-2730.177f, 2799.426f, 1.757612f), new Vector3(-2717.147f, 2824.657f, 1.186048f), new Vector3(-2730.011f, 2855.175f, 1.459975f), new Vector3(-2720.936f, 2897.158f, 1.232428f), new Vector3(-2723.055f, 2915.156f, 1.214248f), new Vector3(-2717.156f, 2934.323f, 1.675791f), new Vector3(-2736.917f, 2953.923f, 2.776649f), new Vector3(-2746.004f, 2954.125f, 2.354859f), new Vector3(-2751.835f, 2943.838f, 2.075438f), new Vector3(-2752.229f, 2914.945f, 1.281913f), new Vector3(-2752.62f, 2887.3f, 1.572614f), new Vector3(-2756.117f, 2854.283f, 1.468493f), new Vector3(-2764.645f, 2779.508f, 2.047434f), new Vector3(-2769.536f, 2743.653f, 2.138904f), new Vector3(-2776.014f, 2720.484f, 2.238141f)}),
            new ConsOnParade(4, new Vector3(574.4177f, -65.24456f, 71.70435f), new Vector4(541.0709f, -43.40835f, 71.08759f, 208.7263f), new List<Vector3>{new Vector3(1061.091f, -558.9828f, 59.28479f), new Vector3(1066.203f, -597.2649f, 56.83318f), new Vector3(1062.106f, -610.6114f, 56.76826f), new Vector3(1022.904f, -655.5869f, 58.68858f), new Vector3(1020.39f, -657.876f, 58.61199f), new Vector3(1020.476f, -698.0944f, 56.81086f), new Vector3(1056.699f, -719.1822f, 56.815f), new Vector3(1088.558f, -738.0333f, 56.76314f), new Vector3(1132.372f, -738.0198f, 56.74362f), new Vector3(1143.484f, -710.3257f, 56.80364f), new Vector3(1127.766f, -660.5972f, 56.68017f), new Vector3(1126.506f, -644.8978f, 56.77164f), new Vector3(1119.372f, -633.5688f, 56.78326f), new Vector3(1118.719f, -612.4344f, 56.74827f), new Vector3(1124.979f, -604.9899f, 56.74682f), new Vector3(1139.324f, -591.7932f, 56.75398f), new Vector3(1142.248f, -582.8869f, 56.75351f), new Vector3(1133.203f, -563.3502f, 56.99999f), new Vector3(1125.851f, -551.4424f, 56.93082f), new Vector3(1105.572f, -540.5275f, 57.76503f), new Vector3(1105.599f, -540.5577f, 57.76052f), new Vector3(1100.637f, -540.5255f, 57.95548f), new Vector3(1100.362f, -527.494f, 63.07243f), new Vector3(1073.51f, -530.7902f, 62.03668f)}),
            new ConsOnParade(4, new Vector3(574.4177f, -65.24456f, 71.70435f), new Vector4(541.0709f, -43.40835f, 71.08759f, 208.7263f), new List<Vector3>{new Vector3(1163.911f, 280.2455f, 82.19042f), new Vector3(991.5728f, -11.44712f, 81.85177f), new Vector3(993.7879f, -40.10574f, 81.92294f), new Vector3(1011.639f, -65.61469f, 82.19008f), new Vector3(1038.523f, -82.89301f, 82.19008f), new Vector3(1072.831f, -82.7739f, 82.16786f), new Vector3(1095.682f, -69.53146f, 82.08484f), new Vector3(1265.938f, 178.9096f, 81.98807f), new Vector3(1273.632f, 195.978f, 81.91003f), new Vector3(1274.658f, 222.6223f, 81.90385f), new Vector3(1261.318f, 257.1254f, 82.07339f), new Vector3(1235.155f, 278.5591f, 82.08091f), new Vector3(1209.412f, 284.0538f, 82.0095f)}),
            new ConsOnParade(4, new Vector3(574.4177f, -65.24456f, 71.70435f), new Vector4(541.0709f, -43.40835f, 71.08759f, 208.7263f), new List<Vector3>{new Vector3(2493.767f, -317.9808f, 92.99265f), new Vector3(2465.75f, -331.269f, 92.99268f), new Vector3(2445.703f, -353.545f, 92.98891f), new Vector3(2446.853f, -417.4889f, 92.99274f), new Vector3(2474.773f, -444.7306f, 92.99303f), new Vector3(2480.923f, -437.5063f, 92.99287f), new Vector3(2479.751f, -420.7701f, 93.73516f), new Vector3(2481.842f, -406.8932f, 93.73528f), new Vector3(2494.202f, -390.2369f, 94.11994f), new Vector3(2493.491f, -374.688f, 94.11996f), new Vector3(2481.127f, -358.7106f, 93.73526f), new Vector3(2481.344f, -341.2011f, 93.00871f), new Vector3(2480.642f, -324.369f, 92.99266f)}),
            new ConsOnParade(4, new Vector3(574.4177f, -65.24456f, 71.70435f), new Vector4(541.0709f, -43.40835f, 71.08759f, 208.7263f), new List<Vector3>{new Vector3(1443.998f, 1032.925f, 114.2406f), new Vector3(1507.861f, 1033.247f, 114.2185f), new Vector3(1514.412f, 1043.134f, 114.2258f), new Vector3(1514.912f, 1101.076f, 114.2287f), new Vector3(1502.632f, 1178.213f, 114.2156f), new Vector3(1484.8f, 1185.216f, 114.1505f), new Vector3(1434.625f, 1186.282f, 114.1913f), new Vector3(1433.847f, 1092.753f, 114.2267f)}),
            new ConsOnParade(4, new Vector3(574.4177f, -65.24456f, 71.70435f), new Vector4(541.0709f, -43.40835f, 71.08759f, 208.7263f), new List<Vector3>{new Vector3(2692.736f, 1705.75f, 24.68079f), new Vector3(2806.105f, 1705.584f, 24.68113f), new Vector3(2818.727f, 1704.424f, 24.69106f), new Vector3(2823.846f, 1699.423f, 24.71452f), new Vector3(2824.438f, 1696.413f, 24.69556f), new Vector3(2824.696f, 1647.154f, 24.64242f), new Vector3(2782.65f, 1647.183f, 24.60208f), new Vector3(2780.294f, 1653.693f, 24.53028f), new Vector3(2711.461f, 1654.09f, 24.53372f), new Vector3(2711.587f, 1647.229f, 24.60396f), new Vector3(2698.269f, 1646.656f, 24.60472f), new Vector3(2695.426f, 1649.674f, 24.61012f), new Vector3(2694.013f, 1653.814f, 24.62069f), new Vector3(2694.363f, 1691.255f, 24.69635f), new Vector3(2696.989f, 1695.163f, 24.7006f), new Vector3(2702.095f, 1696.548f, 24.66678f)}),
            new ConsOnParade(5, new Vector3(1861.364f, 3670.887f, 33.91336f),  new Vector4(1863.648f, 3676.296f, 33.94254f, 120.0636f), new List<Vector3>{new Vector3(1623.121f, 3228.294f, 40.41154f), new Vector3(1548.318f, 3147.528f, 40.53161f), new Vector3(1099.019f, 3015.776f, 40.56151f), new Vector3(1074.616f, 3035.108f, 41.24891f), new Vector3(1085.017f, 3076.249f, 40.42923f)}),
            new ConsOnParade(5, new Vector3(1861.364f, 3670.887f, 33.91336f),  new Vector4(1863.648f, 3676.296f, 33.94254f, 120.0636f), new List<Vector3>{new Vector3(1090.78f, 3566.191f, 34.09589f), new Vector3(1091.477f, 3610.838f, 33.05823f), new Vector3(1047.076f, 3610.903f, 33.11738f), new Vector3(1012.615f, 3597.394f, 33.21322f), new Vector3(1017.906f, 3568.242f, 33.92956f)}),
            new ConsOnParade(5, new Vector3(1861.364f, 3670.887f, 33.91336f),  new Vector4(1863.648f, 3676.296f, 33.94254f, 120.0636f), new List<Vector3>{new Vector3(73.27388f, 3633.642f, 39.70792f), new Vector3(27.01976f, 3700.822f, 39.70713f), new Vector3(28.15174f, 3713.856f, 39.71289f), new Vector3(35.53751f, 3726.467f, 39.65743f), new Vector3(73.20634f, 3740.686f, 39.71008f), new Vector3(83.90422f, 3739.935f, 39.69468f), new Vector3(99.68319f, 3726.861f, 39.67576f), new Vector3(102.9181f, 3719.429f, 39.70041f), new Vector3(82.71038f, 3679.274f, 39.71919f), new Vector3(81.40222f, 3636.785f, 39.69534f)}),
            new ConsOnParade(5, new Vector3(1861.364f, 3670.887f, 33.91336f),  new Vector4(1863.648f, 3676.296f, 33.94254f, 120.0636f), new List<Vector3>{new Vector3(1041.883f, 2191.695f, 44.96709f), new Vector3(1066.888f, 2213.252f, 46.80863f), new Vector3(1031.368f, 2213.759f, 51.05772f), new Vector3(989.4823f, 2218.621f, 47.55013f), new Vector3(997.8649f, 2204.891f, 46.05443f), new Vector3(1021.423f, 2190.472f, 45.28568f)}),
            new ConsOnParade(5, new Vector3(1861.364f, 3670.887f, 33.91336f),  new Vector4(1863.648f, 3676.296f, 33.94254f, 120.0636f), new List<Vector3>{new Vector3(2440.191f, 4837.629f, 36.53263f), new Vector3(2428.567f, 4921.247f, 43.66103f), new Vector3(2472.179f, 4965.375f, 45.16649f), new Vector3(2480.896f, 4990.179f, 46.22219f), new Vector3(2478.137f, 5002.943f, 45.85592f), new Vector3(2466.199f, 5016.405f, 45.56878f), new Vector3(2416.468f, 4969.382f, 46.13856f), new Vector3(2386.791f, 4938.182f, 42.70732f), new Vector3(2363.594f, 4912.43f, 41.9899f), new Vector3(2373.377f, 4895.569f, 41.92224f), new Vector3(2394.373f, 4874.57f, 40.84945f)}),
            new ConsOnParade(6, new Vector3(-438.1813f, 6040.049f, 31.34058f), new Vector4(-460.7939f, 6020.269f, 31.6007f, 316.3787f), new List<Vector3>{new Vector3(234.6885f, 6418.486f, 30.96218f), new Vector3(248.8196f, 6415.337f, 31.88116f), new Vector3(269.739f, 6414.965f, 32.11745f), new Vector3(288.8002f, 6420.939f, 31.35575f), new Vector3(298.797f, 6432.084f, 31.80929f), new Vector3(301.9339f, 6444.203f, 32.29673f), new Vector3(306.1744f, 6493.814f, 29.37009f), new Vector3(250.2143f, 6489.353f, 30.67807f), new Vector3(171.8803f, 6482.01f, 31.94304f), new Vector3(175.2863f, 6475.943f, 31.89293f)}),
            new ConsOnParade(6, new Vector3(-438.1813f, 6040.049f, 31.34058f), new Vector4(-460.7939f, 6020.269f, 31.6007f, 316.3787f), new List<Vector3>{new Vector3(157.3289f, 7044.97f, 1.865713f), new Vector3(102.7529f, 7073.901f, 1.931986f), new Vector3(52.24357f, 7079.25f, 2.17193f), new Vector3(23.56722f, 7052.823f, 1.409035f), new Vector3(31.16364f, 7023.305f, 7.387625f), new Vector3(41.1493f, 7013.06f, 8.625368f), new Vector3(36.24067f, 6995.254f, 8.021345f), new Vector3(73.45621f, 6951.467f, 11.52127f), new Vector3(76.90339f, 6968.756f, 10.14844f), new Vector3(96.15324f, 6976.542f, 9.490364f), new Vector3(144.0458f, 6980.392f, 8.019959f), new Vector3(157.614f, 6990.637f, 4.969121f), new Vector3(158.9223f, 7011.254f, 3.681879f)}),
            new ConsOnParade(6, new Vector3(-438.1813f, 6040.049f, 31.34058f), new Vector4(-460.7939f, 6020.269f, 31.6007f, 316.3787f), new List<Vector3>{new Vector3(-576.4569f, 5452.922f, 60.71923f), new Vector3(-560.6669f, 5474.996f, 61.77381f), new Vector3(-552.685f, 5494.2f, 59.80086f), new Vector3(-550.2758f, 5515.276f, 59.87648f), new Vector3(-572.0354f, 5544.016f, 52.74706f), new Vector3(-601.4049f, 5515.799f, 49.60851f), new Vector3(-620.7578f, 5506.275f, 51.13645f), new Vector3(-634.4025f, 5477.448f, 53.29848f), new Vector3(-637.6897f, 5453.631f, 52.85682f), new Vector3(-595.5697f, 5458.982f, 59.10485f)}),
            new ConsOnParade(6, new Vector3(-438.1813f, 6040.049f, 31.34058f), new Vector4(-460.7939f, 6020.269f, 31.6007f, 316.3787f), new List<Vector3>{new Vector3(-334.3983f, 6183.464f, 31.42284f), new Vector3(-305.0548f, 6212.236f, 31.45675f), new Vector3(-302.0125f, 6213.075f, 31.39697f), new Vector3(-284.0596f, 6234.494f, 31.49339f), new Vector3(-237.9272f, 6281.979f, 31.45799f), new Vector3(-252.1601f, 6297.677f, 31.45717f), new Vector3(-301.6298f, 6251.044f, 31.51244f), new Vector3(-305.8697f, 6247.805f, 31.43438f), new Vector3(-318.1996f, 6232.045f, 31.48331f), new Vector3(-322.5253f, 6227.77f, 31.46884f), new Vector3(-360.4957f, 6191.922f, 31.48243f)}),
            new ConsOnParade(6, new Vector3(-438.1813f, 6040.049f, 31.34058f), new Vector4(-460.7939f, 6020.269f, 31.6007f, 316.3787f), new List<Vector3>{new Vector3(-1445.911f, 4228.153f, 49.88695f), new Vector3(-1437.855f, 4232.769f, 48.72689f), new Vector3(-1414.334f, 4225.317f, 42.9243f), new Vector3(-1406.202f, 4234.257f, 39.57491f), new Vector3(-1398.107f, 4235.384f, 37.1693f), new Vector3(-1381.473f, 4242.933f, 32.96693f), new Vector3(-1379.1f, 4227.457f, 27.85471f), new Vector3(-1375.508f, 4221.704f, 26.20435f), new Vector3(-1371.023f, 4221.62f, 24.55573f), new Vector3(-1369.318f, 4234.283f, 21.74896f), new Vector3(-1365.844f, 4237.374f, 20.58922f), new Vector3(-1362.55f, 4222.789f, 18.0125f), new Vector3(-1357.766f, 4223.158f, 16.33216f), new Vector3(-1355.488f, 4230.613f, 14.08321f), new Vector3(-1349.775f, 4261.309f, 7.204568f), new Vector3(-1350.807f, 4280.167f, 3.489815f), new Vector3(-1366.992f, 4291.422f, 2.879005f), new Vector3(-1375.258f, 4295.798f, 2.808748f), new Vector3(-1409.907f, 4301.811f, 5.031199f), new Vector3(-1511.659f, 4307.015f, 5.628844f), new Vector3(-1585.516f, 4343.747f, 3.159351f), new Vector3(-1610.404f, 4373.366f, 2.441379f), new Vector3(-1644.269f, 4431.979f, 3.232418f), new Vector3(-1677.754f, 4452.332f, 2.484089f), new Vector3(-1734.826f, 4452.425f, 4.763266f), new Vector3(-1783.387f, 4475.105f, 11.17609f), new Vector3(-1815.323f, 4479.708f, 17.87292f), new Vector3(-1842.674f, 4500.0f, 22.1328f), new Vector3(-1855.061f, 4500.765f, 22.36915f), new Vector3(-1878.805f, 4481.325f, 26.10547f), new Vector3(-1912.77f, 4482.177f, 29.16429f), new Vector3(-1927.905f, 4460.231f, 34.65511f), new Vector3(-1905.194f, 4437.292f, 42.7122f), new Vector3(-1870.033f, 4417.005f, 48.25819f), new Vector3(-1739.497f, 4344.018f, 62.30252f), new Vector3(-1701.276f, 4303.689f, 69.18857f), new Vector3(-1659.563f, 4215.886f, 82.93988f), new Vector3(-1637.42f, 4205.126f, 84.06075f), new Vector3(-1587.657f, 4200.398f, 81.1502f), new Vector3(-1567.076f, 4205.095f, 78.5675f), new Vector3(-1566.948f, 4205.121f, 78.53695f), new Vector3(-1489.583f, 4226.147f, 57.02686f), new Vector3(-1461.699f, 4225.801f, 52.18763f)}),
        };

        private static readonly List<FubarVectors> Area_01_BikerBiz = new List<FubarVectors>
        {
             new FubarVectors(1, new Vector4(-343.4586f, -2776.79f, 4.619501f,359.4937f), new Vector4(-331.1654f, -2778.882f, 5.145107f,91.96407f), "", 100),//Forg
             new FubarVectors(1, new Vector4(-269.3758f, -2581.877f, 5.619569f,181.7917f), new Vector4(-253.1123f, -2591.046f, 6.000631f,82.32009f), "", 101),//Coke
             new FubarVectors(1, new Vector4(151.9697f, -2495.044f, 5.640574f,235.2299f), new Vector4(136.7125f, -2472.684f, 5.999992f,234.9321f), "", 102),//Weed
             new FubarVectors(1, new Vector4(667.2778f, -2653.204f, 5.700295f,147.6484f), new Vector4(661.5711f, -2643.634f, 8.405517f,181.2969f), "", 103),//Cash
             new FubarVectors(1, new Vector4(1181.453f, -3098.825f, 5.467923f,92.65168f), new Vector4(1181.25f, -3113.758f, 6.028028f,80.94795f), "", 104)//Meth
        };
        private static readonly List<FubarVectors> Area_01_OnineApps = new List<FubarVectors>
        {
             new FubarVectors(1, new Vector4(-337.4651f, -1476.109f, 29.85095f,357.2774f), new Vector4(-342.5652f, -1468.523f, 30.61055f,269.7058f), "Innocence Blvd", 52),
             new FubarVectors(1, new Vector4(-8.415443f, -1642.825f, 28.44195f,225.8221f), new Vector4(-10.89472f, -1646.749f, 29.31074f,321.3156f), "1905 Davis Ave", 53),
             new FubarVectors(1, new Vector4(-1076.555f, -2220.362f, 12.55306f,221.8356f), new Vector4(-1089.145f, -2234.718f, 13.21776f,323.6268f), "Unit 76 Greenwich Parkway", 54),
             new FubarVectors(1, new Vector4(-677.3629f, -2383.381f, 13.07794f,318.7368f), new Vector4(-663.7839f, -2380.372f, 13.94453f,64.96823f), "1337 Exceptionalists Way", 54),
             new FubarVectors(1, new Vector4(1028.777f, -2399.222f, 29.03165f,354.6582f), new Vector4(1024.539f, -2398.414f, 30.12139f,259.3723f), "1623 South Shambles St", 54),
             new FubarVectors(1, new Vector4(858.534f, -2235.035f, 29.64784f,176.385f), new Vector4(870.585f, -2232.52f, 30.55808f,179.5602f), "4531 Dry Dock St", 53),
             new FubarVectors(1, new Vector4(483.8876f, -1540.438f, 28.51065f,231.4991f), new Vector4(473.8763f, -1545.991f, 29.28262f,320.4353f), "0432 Davis Av", 52),
             new FubarVectors(1, new Vector4(503.2369f, -1500.158f, 28.56153f,178.5078f), new Vector4(507.7902f, -1492.829f, 29.28802f,182.839f), "0552 Roy Lowenstein Ave", 53),
             new FubarVectors(1, new Vector4(573.6826f, -1565.718f, 27.82828f,227.8936f), new Vector4(569.9021f, -1569.931f, 28.5832f,317.976f), "12 Little Bighorn Ave", 52),
             new FubarVectors(1, new Vector4(520.6251f, -1597.04f, 28.48415f,321.7377f), new Vector4(528.7007f, -1603.125f, 29.31859f,51.90651f), "0754 Roy Lowenstein Ave", 52),
             new FubarVectors(1, new Vector4(730.2559f, -1194.549f, 23.54736f,269.2225f), new Vector4(724.8663f, -1190.149f, 24.27942f,179.586f), "Unit 124 Popular St", 52),
             new FubarVectors(1, new Vector4(843.9633f, -1154.463f, 24.52598f,271.5499f), new Vector4(842.0583f, -1164.756f, 25.26783f,0.1888612f), "Unit 1 Olympic Freeway", 53),
             new FubarVectors(1, new Vector4(978.7435f, -1018.694f, 40.64922f,183.0052f), new Vector4(963.5387f, -1019.961f, 40.84752f,270.8572f), "0120 Murrieta Heights", 54),
             new FubarVectors(1, new Vector4(882.4333f, -890.9539f, 25.49792f,88.7608f), new Vector4(895.2441f, -891.7256f, 27.19517f,88.96577f), "Unit 14 Popular St", 53),
             new FubarVectors(1, new Vector4(809.0405f, -913.5404f, 24.90523f,88.7878f), new Vector4(815.1923f, -924.9136f, 26.24699f,4.312748f), "Unit 2 Popular St", 54),
             new FubarVectors(1, new Vector4(763.0825f, -756.4301f, 25.97516f,359.2748f), new Vector4(758.9418f, -752.6591f, 27.0201f,254.0437f), "331 Supply St", 54),
             new FubarVectors(1, new Vector4(256.575f,-1799.826f,26.608f, 48.838f), new Vector4(252.927f, -1808.293f, 27.118f, 0f), "Rancho Clubhouse", 97)
        };
        private static readonly List<FubarVectors> Area_01_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(149.2404f, -1028.672f, 28.63033f,250.5138f), new Vector4(145.1532f, -1038.512f, 29.36785f, 269.5935f), "Legion Square Fleeca", 232),
            new FubarVectors(1, new Vector4(133.0356f, -1308.721f, 28.60576f,119.624f), new Vector4(127.9426f, -1296.037f, 29.26953f, 180.8935f), "Vanilla Unicorn", 200),
            new FubarVectors(1, new Vector4(87.59933f, -1391.104f, 28.82943f,179.3005f), new Vector4(77.36224f, -1391.059f, 29.37615f, 274.6103f), "Strawberry Discount Store", 201), 
            new FubarVectors(1, new Vector4(26.51636f, -1357.307f, 28.85752f,90.21033f), new Vector4(29.35406f, -1344.921f, 29.49702f, 178.0736f), "Strawberry 247", 202),
            new FubarVectors(1, new Vector4(-64.29047f, -1755.938f, 28.89316f,357.8452f), new Vector4(-50.65708f, -1753.66f, 29.42101f, 151.0862f), "Davis LTD", 203),
            new FubarVectors(1, new Vector4(129.8454f, -1716.654f, 28.68827f,51.20896f),new Vector4(136.0431f, -1709.106f, 29.29162f, 139.579f), "Davis Hurr Kutz Barber", 204),
            new FubarVectors(1, new Vector4(789.6224f, -2123.345f, 28.84297f,356.3875f), new Vector4(812.0836f, -2154.835f, 29.61901f, 358.3495f), "Cypress Flats Amunation", 205),
            new FubarVectors(1, new Vector4(839.6248f, -1010.42f, 27.06529f,272.411f), new Vector4(844.4253f, -1031.962f, 28.19486f, 0.812606f), "La Messa Amunation", 206),
            new FubarVectors(1, new Vector4(411.1922f, -810.241f, 28.7976f,359.0809f), new Vector4(425.2306f, -808.2446f, 29.48802f, 101.5617f), "Textile city Binco", 207),
            new FubarVectors(1, new Vector4(404.3505f, -978.7266f, 28.92775f,358.9452f), new Vector4(440.9073f, -982.1958f, 30.68961f, 85.89721f), "Mission Row Poilce Station", 208)
        }; 
        private static readonly List<FubarVectors> Area_01_Resurant = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(356.2659f, -1037.037f, 28.53647f,92.82713f), new Vector4(354.2294f, -1028.153f, 29.33102f,183.939f), "Rusty Browns", 0),
            new FubarVectors(1, new Vector4(370.0017f, -1037.018f, 28.52944f,92.78429f), new Vector4(370.234f, -1028.068f, 29.33352f,184.8339f), "Ground & Pound Cafe Mission Row", 0),
            new FubarVectors(1, new Vector4(281.025f, -956.4398f, 28.61995f,273.1376f), new Vector4(280.5565f, -963.7268f, 29.41863f,2.397845f), "Bean Machine Mission Row", 0),
            new FubarVectors(1, new Vector4(288.3607f, -956.153f, 28.64618f,271.3094f), new Vector4(287.3082f, -963.7783f, 29.41863f,333.2294f), "Pizza This Mission Row", 0),
            new FubarVectors(1, new Vector4(63.34894f, -1483.383f, 28.82791f,158.2023f), new Vector4(53.29582f, -1479.292f, 29.27994f,191.9055f), "Gabriela's Market Stawberry", 0),
            new FubarVectors(1, new Vector4(12.41413f, -1619.852f, 28.83006f,52.01779f), new Vector4(12.67301f, -1605.534f, 29.3969f,136.9659f), "Taco Farmer", 0),
            new FubarVectors(1, new Vector4(120.0448f, -1455.711f, 28.84293f,319.3315f), new Vector4(133.1322f, -1462.59f, 29.35705f,40.64439f), "Lucky Plucker", 0),
            new FubarVectors(1, new Vector4(162.1581f, -1456.309f, 28.76029f,323.3648f), new Vector4(166.4406f, -1451.162f, 29.24164f,136.562f), "Ring Of Fire", 0),
            new FubarVectors(1, new Vector4(101.5791f, -1414.394f, 28.79049f,231.5293f), new Vector4(99.14009f, -1419.271f, 29.42149f,330.8654f), "Aguila Burrito", 0),
            new FubarVectors(1, new Vector4(178.8171f, -1341.128f, 28.82316f,147.5899f), new Vector4(170.4847f, -1337.017f, 29.29482f,286.4955f), "Liquor Store Stawberry", 0),
            new FubarVectors(1, new Vector4(227.6325f, -1517.133f, 28.76189f,43.86306f), new Vector4(224.4509f, -1510.865f, 29.29166f,220.7558f), "Fowl Mouthed", 0),
            new FubarVectors(1, new Vector4(127.4156f, -1549.204f, 28.81196f,49.95243f), new Vector4(131.885f, -1542.654f, 29.17529f,136.3899f), "La Vaca Loco", 0),
            new FubarVectors(1, new Vector4(161.9446f, -1635.196f, 28.91058f,196.7886f), new Vector4(169.4445f, -1634.003f, 29.29167f,32.34769f), "Bishops Chicken Davis", 0),
            new FubarVectors(1, new Vector4(122.5958f, -1637.628f, 28.87321f,244.6442f), new Vector4(129.9635f, -1643.368f, 29.29157f,32.57319f), "Liquor Store Davis", 0),
            new FubarVectors(1, new Vector4(81.2529f, -1670.133f, 28.6323f,353.6321f), new Vector4(87.05326f, -1670.293f, 29.17428f,75.68929f), "Groceries Store Stawberry", 0),
            new FubarVectors(1, new Vector4(100.5478f, -1695.322f, 28.6868f,48.43034f), new Vector4(104.8998f, -1690.008f, 29.28583f,131.8633f), "Cosa Baratas", 0),
            new FubarVectors(1, new Vector4(90.97966f, -1687.588f, 28.73799f,49.39465f), new Vector4(95.8286f, -1682.444f, 29.25834f,138.2499f), "Yum Fish", 0),
            new FubarVectors(1, new Vector4(220.8297f, -1740.785f, 28.44929f,302.2923f), new Vector4(226.2618f, -1747.046f, 29.21539f,21.11411f), "Liquor Store Brouge Ave", 0),
            new FubarVectors(1, new Vector4(190.9958f, -1772.52f, 28.73424f,51.33232f), new Vector4(195.2352f, -1764.221f, 29.35803f,103.915f), "Sava A Cent", 0),
            new FubarVectors(1, new Vector4(176.7172f, -2033.813f, 17.80531f,85.5892f), new Vector4(174.7953f, -2025.382f, 18.32481f,131.5922f), "Mexican & American Rancho", 0),
            new FubarVectors(1, new Vector4(231.3702f, -1940.747f, 22.6864f,318.9818f), new Vector4(233.985f, -1946.724f, 22.93509f,11.75167f), "Liquor Store Roy Lowenstein Ave", 0),
            new FubarVectors(1, new Vector4(463.9674f, -2058.959f, 23.72085f,182.6471f), new Vector4(456.4185f, -2059.178f, 23.94516f,276.8619f), "South LS Liquor", 0),
            new FubarVectors(1, new Vector4(-13.61321f, -1833.167f, 24.8438f,49.1902f), new Vector4(-10.35018f, -1828.168f, 25.38836f,135.3515f), "Redwood Store Grove St", 0),
            new FubarVectors(1, new Vector4(-170.6131f, -1440.175f, 30.90944f,229.63f), new Vector4(-163.1972f, -1439.968f, 31.4238f,52.86668f), "Wok It Off", 0),
            new FubarVectors(1, new Vector4(798.8268f, -1072.124f, 27.74096f,5.028199f), new Vector4(807.4172f, -1073.597f, 28.92093f,136.9425f), "Liquor Market La Messa", 0),
            new FubarVectors(1, new Vector4(784.5165f, -736.7656f, 27.22341f,319.1929f), new Vector4(793.8783f, -735.6204f, 27.96289f,90.09853f), "Casey's Dinner", 0),
            new FubarVectors(1, new Vector4(984.7687f, -1405.682f, 30.97346f,29.78371f), new Vector4(980.1448f, -1396.95f, 31.68536f,203.8759f), "Taqueri", 0)
        };
        private static readonly List<FubarVectors> Area_01_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(-1161.642f, -2191.744f, 12.8148f,57.32962f), new Vector4(-1152.63f, -2170.918f, 13.26819f,129.6338f), "LSIA Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(-501.4268f, -2183.638f, 6.946587f,321.1457f), new Vector4(-514.537f, -2201.893f, 6.394023f,317.1665f), "Big House Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(-636.5945f, -1790.944f, 23.62133f,66.77604f), new Vector4(-632.8036f, -1779.659f, 24.01751f,133.0152f), "La Puerta Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(-55.26973f, -1838.358f, 26.16808f,318.1885f), new Vector4(-72.28735f, -1821.004f, 26.94203f,226.0149f), "Davis Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(131.8759f, -2987.817f, 6.638521f,269.7666f), new Vector4(144.5818f, -3005.692f, 7.030922f,4.00696f), "Elysian Island Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(823.5082f, -2126.997f, 28.91375f,84.27451f), new Vector4(820.3541f, -2115.163f, 29.37735f,178.5701f), "Cypress Flats Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(1006.479f, -1865.767f, 30.50913f,85.25732f), new Vector4(995.8566f, -1854.685f, 31.03982f,180.2448f), "La Messa Vehicle Warehouse", 5),
            new FubarVectors(1, new Vector4(-1062.604f, -2021.664f, 12.78076f,132.728f), new Vector4(-1048.011f, -2016.769f, 13.16157f,134.5906f), "Xero Gas Factory", 3),
            new FubarVectors(1, new Vector4(-891.0944f, -2734.081f, 13.44745f,150.3703f), new Vector4(-874.445f, -2734.251f, 13.89006f,66.68798f), "Bilgeco Warehouse", 3),
            new FubarVectors(1, new Vector4(98.10351f, -2193.174f, 5.653489f,89.89806f), new Vector4(108.7625f, -2203.42f, 7.653017f,2.042418f), "Walker & Sons Warehouse", 3),
            new FubarVectors(1, new Vector4(1004.175f, -2519.513f, 27.92308f,83.26608f), new Vector4(1008.982f, -2529.612f, 28.30333f,350.8603f), "Cypress Warehouses Warehouse", 3),
            new FubarVectors(1, new Vector4(1071.635f, -2171.634f, 31.53667f,353.9962f), new Vector4(1039.996f, -2178.126f, 31.47331f,271.269f), "Wholesale Furniture Warehouse", 3),
            new FubarVectors(1, new Vector4(906.0683f, -1561.211f, 30.34963f,91.20412f), new Vector4(924.6522f, -1563.925f, 30.71964f,91.05463f), "Logistics Depot Warehouse", 3),
            new FubarVectors(1, new Vector4(766.0025f, -880.819f, 24.59484f,359.1105f), new Vector4(761.6404f, -899.4816f, 25.18479f,294.6715f), "Darnel Bros Warehouse", 3),
            new FubarVectors(1, new Vector4(-541.9368f, -1767.85f, 21.15111f,330.4702f), new Vector4(-546.9995f, -1801.99f, 21.89087f,55.2292f), "Fridgit Annexe", 2),
            new FubarVectors(1, new Vector4(-344.285f, -1348.406f, 30.88845f,179.0238f), new Vector4(-326.9119f, -1348.385f, 31.34974f,90.31957f), "Disused Factory Outlet", 2),
            new FubarVectors(1, new Vector4(-303.7468f, -2719.221f, 5.619645f,133.8696f), new Vector4(-311.364f, -2686.786f, 6.005864f,224.6817f), "LS Marine Building 3", 2),
            new FubarVectors(1, new Vector4(550.4014f, -1924.716f, 24.42177f,305.7132f), new Vector4(541.1407f, -1944.385f, 24.9851f,304.675f), "Old Power Station", 2),
            new FubarVectors(1, new Vector4(512.8342f, -637.7836f, 24.37022f,178.8968f), new Vector4(496.4486f, -635.374f, 24.89808f,257.5809f), "Railyard Warehouse", 2),
            new FubarVectors(1, new Vector4(898.0537f, -1020.824f, 34.58628f,57.24908f), new Vector4(908.3679f, -1047.988f, 32.82803f,3.734426f), "Celltowa Unit", 1),
            new FubarVectors(1, new Vector4(261.068f, -1964.121f, 22.33982f,49.45914f), new Vector4(246.87f, -1968.605f, 21.96167f,224.0804f), "Convenience Store Lockup", 1),
            new FubarVectors(1, new Vector4(265.688f, -3004.435f, 5.353796f,358.4464f), new Vector4(280.4507f, -3042.298f, 5.873026f,93.42131f), "Pier 400 Utility Building", 1)
        };
        private static readonly List<FubarVectors> Area_01_Lesure = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(-107.2094f, -1768.818f, 29.44489f,231.5119f), new Vector4(-115.9799f, -1772.341f, 29.86f,38.84093f), "Warehouse Arcade", 15),
            new FubarVectors(1, new Vector4(766.5076f, -813.0089f, 25.71449f,177.6226f), new Vector4(758.6154f, -815.8661f, 26.29759f,276.056f), "Videogeddon Arcade", 15),
            new FubarVectors(1, new Vector4(-227.3509f, -2049.221f, 27.2388f,141.1996f), new Vector4(-254.2992f, -2027.195f, 29.94605f,226.5803f), "Maze Bank Arena", 0),
            new FubarVectors(1, new Vector4(387.5257f, -2146.93f, 15.78984f,120.8641f), new Vector4(368.6521f, -2118.896f, 16.37276f,163.8223f), "Rancho Towers", 0),
            new FubarVectors(1, new Vector4(-214.0043f, -1495.019f, 30.57932f,127.9526f), new Vector4(-238.822f, -1515.334f, 33.37285f,321.6545f), "B.J Smith Center", 0),
            new FubarVectors(1, new Vector4(277.3411f, -1553.783f, 28.33502f,119.7129f), new Vector4(251.847f, -1594.122f, 31.53222f,309.4576f), "Davis Courtyard Monument", 0),
            new FubarVectors(1, new Vector4(458.5075f, -1449.931f, 28.49267f,279.5134f), new Vector4(462.1605f, -1456.693f, 29.30482f,21.09414f), "Beacon Theater", 10),
            new FubarVectors(1, new Vector4(400.4842f, -1564.748f, 28.4916f,50.28472f), new Vector4(391.8f, -1541.922f, 29.25285f,241.9601f), "Rancho Park", 0),
            new FubarVectors(1, new Vector4(401.262f, -710.6935f, 28.48723f,180.4951f), new Vector4(393.7086f, -714.0088f, 29.28547f,266.0806f), "Ten Cent Theater", 10),
            new FubarVectors(1, new Vector4(353.6958f, -867.5635f, 28.48938f,270.8875f), new Vector4(356.1699f, -874.5022f, 29.29163f,3.704904f), "Los Santos Theater", 10),
            new FubarVectors(1, new Vector4(-775.9632f, -1282.329f, 4.417081f,354.5479f), new Vector4(-780.7544f, -1251.35f, 5.700295f,222.0349f), " La Puerta Marina", 0),
            new FubarVectors(1, new Vector4(-719.1398f, -1290.575f, 4.416236f,232.1511f), new Vector4(-712.0093f, -1299.308f, 5.2503f,55.43673f), "LSMYC", 0),
            new FubarVectors(1, new Vector4(-707.9506f, -1402.676f, 4.416663f,227.1951f), new Vector4(-696.3354f, -1386.641f, 5.49527f,58.39517f), "Higgins Helitours", 0),
            new FubarVectors(1, new Vector4(499.8172f, -1543.926f, 28.61629f,138.2767f), new Vector4(493.9582f, -1541.665f, 29.28772f,226.9635f), "Hi-Men", 0),
            new FubarVectors(1, new Vector4(-689.4636f, -2467.658f, 13.32106f,57.26832f), new Vector4(-676.8618f, -2458.505f, 13.94439f,140.4848f), "LSIA Nightclub", 300),
            new FubarVectors(1, new Vector4(183.415f, -3172.921f, 5.231539f,1.436009f), new Vector4(195.142f, -3167.259f, 5.790269f,82.91703f), "Elysian Island Nightclub", 301),
            new FubarVectors(1, new Vector4(867.4649f, -2091.307f, 29.77768f,175.274f), new Vector4(871.1814f, -2100.427f, 30.4692f,75.86678f), "Cypress Flats Nightclub", 302),
            new FubarVectors(1, new Vector4(767.7607f, -1341.249f, 25.7411f,89.70621f), new Vector4(758.3185f, -1332.611f, 27.27525f,195.966f), "La Mesa Nightclub", 303),
            new FubarVectors(1, new Vector4(-114.6708f, -1257.78f, 28.67939f,190.5026f), new Vector4(-121.2064f, -1258.58f, 29.30906f,267.1223f), "Stawberry Nightclub", 304)
        };
        private static readonly List<FubarVectors> Area_01_Hotel = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(299.4587f, -1095.923f, 28.56937f,0.196956f), new Vector4(288.8706f, -1095.107f, 29.41966f,265.9706f), "Templar Hotel", 11),
            new FubarVectors(1, new Vector4(-690.2049f, -2287.411f, 12.59679f,135.5929f), new Vector4(-704.7109f, -2276.806f, 13.45538f,227.6635f), "Opium Nights, East Entrance", 11),
            new FubarVectors(1, new Vector4(-753.5894f, -2292.686f, 12.47695f,44.88023f), new Vector4(-737.829f, -2274.829f, 13.43745f,135.4533f), "Opium Nights", 11),
            new FubarVectors(1, new Vector4(-885.2045f, -2189.678f, 8.131227f,43.59839f), new Vector4(-875.2037f, -2180.055f, 9.809036f,134.0295f), "Von Crastenburg Hotel LSIA", 11),
            new FubarVectors(1, new Vector4(-827.7642f, -1220.021f, 6.351738f,318.2779f), new Vector4(-822.72f, -1222.917f, 7.36541f,43.04561f), "The Viceroy Hotel", 11)
        };
        private static readonly List<FubarVectors> Area_01_ORP = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(-38.58185f, -1447.042f, 31.11786f,180.4345f), new Vector4(-32.69102f, -1446.299f, 31.89141f,92.93349f), "", 50),
            new FubarVectors(1, new Vector4(-55.59203f, -1785.176f, 27.46565f,135.7456f), new Vector4(-50.4203f, -1783.343f, 28.30082f,133.4054f), "", 50),
            new FubarVectors(1, new Vector4(-27.58285f, -1851.537f, 25.32663f,318.8048f), new Vector4(-34.17255f, -1847.338f, 26.19355f,221.1098f), "", 50),
            new FubarVectors(1, new Vector4(2.966005f, -1874.796f, 23.32661f,317.7646f), new Vector4(-5.009315f, -1872.022f, 24.15102f,43.48953f), "", 50),
            new FubarVectors(1, new Vector4(41.04702f, -1855.154f, 22.45056f,136.1201f), new Vector4(45.90803f, -1864.434f, 23.27828f,136.9859f), "", 50),
            new FubarVectors(1, new Vector4(53.37162f, -1877.428f, 21.92259f,134.9134f), new Vector4(54.29624f, -1873.232f, 22.80583f,129.4138f), "", 50),
            new FubarVectors(1, new Vector4(46.33907f, -1914.932f, 21.27094f,319.6206f), new Vector4(39.02694f, -1911.614f, 21.9535f,222.7011f), "", 50),
            new FubarVectors(1, new Vector4(92.06572f, -1964.331f, 20.36646f,320.8834f), new Vector4(85.83772f, -1959.654f, 21.12168f,49.18516f), "", 50),
            new FubarVectors(1, new Vector4(105.1436f, -1880.649f, 23.57489f,322.7626f), new Vector4(103.9861f, -1885.299f, 24.31878f,320.235f), "", 50),
            new FubarVectors(1, new Vector4(164.2681f, -1864.343f, 23.70184f,155.667f), new Vector4(171.5513f, -1871.345f, 24.40023f,68.41203f), "", 50),
            new FubarVectors(1, new Vector4(168.937f, -1930.692f, 20.62996f,229.5449f), new Vector4(179.0472f, -1924.073f, 21.37102f,138.9209f), "", 50),
            new FubarVectors(1, new Vector4(335.2253f, -1835.831f, 26.95012f,44.30309f), new Vector4(329.4572f, -1845.896f, 27.74809f,47.83199f), "", 50),
            new FubarVectors(1, new Vector4(424.3431f, -1729.366f, 28.86539f,50.20735f), new Vector4(418.6838f, -1735.682f, 29.6077f,148.2224f), "", 50),
            new FubarVectors(1, new Vector4(488.5052f, -1721.471f, 28.99154f,249.7533f), new Vector4(489.4659f, -1714.361f, 29.70688f,250.8587f), "", 50),
            new FubarVectors(1, new Vector4(475.7072f, -1744.061f, 28.5261f,251.4569f), new Vector4(479.6391f, -1735.673f, 29.15104f,157.5574f), "", 50),
            new FubarVectors(1, new Vector4(477.7349f, -1777.262f, 28.26374f,270.731f), new Vector4(472.0552f, -1775.294f, 29.07087f,259.6294f), "", 50),
            new FubarVectors(1, new Vector4(405.9705f, -1860.696f, 26.42558f,223.1872f), new Vector4(412.4088f, -1856.41f, 27.32313f,320.492f), "", 50),
            new FubarVectors(1, new Vector4(362.7894f, -1902.583f, 24.39289f,229.7933f), new Vector4(368.7201f, -1895.808f, 25.17853f,138.0717f), "", 50),
            new FubarVectors(1, new Vector4(317.0536f, -1943.915f, 24.26343f,231.5196f), new Vector4(324.2066f, -1937.158f, 25.01898f,153.2901f), "", 50),
            new FubarVectors(1, new Vector4(286.7917f, -1986.442f, 20.76287f,227.0554f), new Vector4(291.2271f, -1980.155f, 21.60053f,146.5357f), "", 50),
            new FubarVectors(1, new Vector4(284.5191f, -1990.111f, 20.08838f,227.9783f), new Vector4(279.8212f, -1993.77f, 20.80378f,312.2727f), "", 50)
        };
        private static readonly List<FubarVectors> Area_01_Houses = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(250.3579f, -2047.749f, 17.41286f,319.6846f), new Vector4(235.9958f, -2046.176f, 18.38f,313.5656f), "", 50),
            new FubarVectors(1, new Vector4(267.8863f, -2026.926f, 18.33104f,318.9834f), new Vector4(256.5352f, -2023.544f, 19.26631f,236.6336f), "", 50),
            new FubarVectors(1, new Vector4(306.6247f, -1980.731f, 21.83265f,319.5937f), new Vector4(295.8285f, -1971.845f, 22.90081f,223.5792f), "", 50),
            new FubarVectors(1, new Vector4(321.7571f, -1964.803f, 23.52196f,320.8356f), new Vector4(312.1227f, -1956.432f, 24.61674f,224.8413f), "", 50),
            new FubarVectors(1, new Vector4(394.7284f, -1891.762f, 24.7986f,314.8228f), new Vector4(385.1483f, -1881.594f, 26.03147f,221.0596f), "", 50),
            new FubarVectors(1, new Vector4(410.5653f, -1876.909f, 25.76488f,316.4956f), new Vector4(399.3457f, -1865.135f, 26.71636f,323.4842f), "", 50),
            new FubarVectors(1, new Vector4(437.1404f, -1851.891f, 27.22672f,314.9016f), new Vector4(427.1883f, -1842.152f, 28.46345f,305.2816f), "", 50),
            new FubarVectors(1, new Vector4(486.6533f, -1812.501f, 27.91593f,319.3661f), new Vector4(495.3808f, -1823.258f, 28.86971f,324.6991f), "", 50),
            new FubarVectors(1, new Vector4(501.8657f, -1790.351f, 28.03068f,350.299f), new Vector4(512.3093f, -1790.682f, 28.91949f,89.32567f), "", 50),
            new FubarVectors(1, new Vector4(501.7137f, -1781.011f, 28.03936f,12.00117f), new Vector4(514.1788f, -1780.768f, 28.91398f,91.54842f), "", 50),
            new FubarVectors(1, new Vector4(487.3299f, -1761.9f, 28.04054f,351.6709f), new Vector4(474.6787f, -1757.682f, 29.09263f,253.4104f), "", 50),
            new FubarVectors(1, new Vector4(506.4764f, -1708.284f, 28.77202f,333.4531f), new Vector4(500.5995f, -1697.077f, 29.78925f,151.6721f), "", 50),
            new FubarVectors(1, new Vector4(432.6962f, -1698.472f, 28.78743f,137.9898f), new Vector4(443.4574f, -1707.233f, 29.70921f,47.32077f), "", 50),
            new FubarVectors(1, new Vector4(419.6839f, -1713.985f, 28.74307f,140.064f), new Vector4(431.1263f, -1725.565f, 29.60144f,142.3404f), "", 50),
            new FubarVectors(1, new Vector4(394.5112f, -1743.99f, 28.78975f,141.6128f), new Vector4(405.742f, -1751.035f, 29.71033f,140.4009f), "", 50),
            new FubarVectors(1, new Vector4(395.6586f, -1742.548f, 28.78985f,141.5986f), new Vector4(405.8464f, -1751.292f, 29.71034f,139.2583f), "", 50),
            new FubarVectors(1, new Vector4(337.3443f, -1811.648f, 27.5831f,141.1033f), new Vector4(348.6555f, -1820.918f, 28.89412f,328.252f), "", 50),
            new FubarVectors(1, new Vector4(269.6592f, -1892.807f, 26.18324f,139.7238f), new Vector4(282.8831f, -1899.071f, 27.26757f,51.50258f), "", 50),
            new FubarVectors(1, new Vector4(257.5898f, -1908.562f, 25.32612f,316.1412f), new Vector4(270.2874f, -1917.188f, 26.18033f,130.0621f), "", 50),
            new FubarVectors(1, new Vector4(239.0827f, -1930.223f, 23.62132f,319.2469f), new Vector4(250.8885f, -1934.938f, 24.69927f,52.8901f), "", 50),
            new FubarVectors(1, new Vector4(154.055f, -1978.63f, 17.88783f,321.0213f), new Vector4(144.3585f, -1968.918f, 18.85763f,149.7268f), "", 50),
            new FubarVectors(1, new Vector4(159.9544f, -1969.221f, 18.1485f,319.1263f), new Vector4(148.8028f, -1960.568f, 19.4589f,220.6596f), "", 50),
            new FubarVectors(1, new Vector4(174.2294f, -1953.429f, 19.28316f,322.9076f), new Vector4(165.1405f, -1944.976f, 20.23543f,231.5193f), "", 50),
            new FubarVectors(1, new Vector4(185.7992f, -1894.405f, 23.42575f,64.90618f), new Vector4(192.1411f, -1883.335f, 25.05675f,150.2435f), "", 50),
            new FubarVectors(1, new Vector4(159.4355f, -1895.057f, 22.67791f,64.16712f), new Vector4(148.5828f, -1904.459f, 23.53167f,331.0221f), "", 50),
            new FubarVectors(1, new Vector4(140.4573f, -1872.99f, 23.49585f,66.2695f), new Vector4(150.0163f, -1864.94f, 24.59133f,165.4574f), "", 50),
            new FubarVectors(1, new Vector4(141.4925f, -1886.963f, 22.91924f,63.91896f), new Vector4(128.2937f, -1897.047f, 23.67422f,64.33575f), "", 50),
            new FubarVectors(1, new Vector4(116.3746f, -1874.919f, 23.51147f,65.38206f), new Vector4(115.394f, -1887.837f, 23.92823f,59.78061f), "", 50),
            new FubarVectors(1, new Vector4(116.7998f, -1863.284f, 24.25241f,246.6294f), new Vector4(130.6108f, -1853.299f, 25.2348f,151.5201f), "", 50),
            new FubarVectors(1, new Vector4(144.4216f, -1812.807f, 27.43347f,140.533f), new Vector4(152.5364f, -1823.573f, 27.86866f,49.41785f), "", 50),
            new FubarVectors(1, new Vector4(95.15026f, -1924.521f, 20.23433f,238.8979f), new Vector4(100.8966f, -1912.247f, 21.40743f,152.2248f), "", 50),
            new FubarVectors(1, new Vector4(114.6681f, -1933.449f, 20.30763f,211.6945f), new Vector4(126.6217f, -1930.047f, 21.38242f,33.96267f), "", 50),
            new FubarVectors(1, new Vector4(111.2963f, -1948.923f, 20.2622f,125.2755f), new Vector4(114.2872f, -1961.076f, 21.33418f,44.55952f), "", 50),
            new FubarVectors(1, new Vector4(90.9194f, -1939.91f, 20.25655f,23.40325f), new Vector4(76.57941f, -1948.256f, 21.17416f,234.7017f), "", 50),
            new FubarVectors(1, new Vector4(83.99518f, -1929.939f, 20.30043f,50.19352f), new Vector4(72.10247f, -1939.046f, 21.36916f,320.2626f), "", 50),
            new FubarVectors(1, new Vector4(69.50695f, -1917.466f, 20.90524f,53.09776f), new Vector4(56.5565f, -1922.811f, 21.91107f,322.2326f), "", 50),
            new FubarVectors(1, new Vector4(34.29631f, -1888.657f, 21.82459f,48.89f), new Vector4(23.19647f, -1896.708f, 22.96589f,318.965f), "", 50),
            new FubarVectors(1, new Vector4(20.23281f, -1876.728f, 22.58219f,48.52357f), new Vector4(5.228329f, -1884.242f, 23.69727f,41.54589f), "", 50),
            new FubarVectors(1, new Vector4(-15.06912f, -1847.066f, 24.56801f,49.60253f), new Vector4(-20.67916f, -1858.691f, 25.40868f,47.89343f), "", 50),
            new FubarVectors(1, new Vector4(10.87848f, -1853.179f, 23.54594f,229.4503f), new Vector4(21.23654f, -1844.627f, 24.60174f,46.55351f), "", 50),
            new FubarVectors(1, new Vector4(-65.64012f, -1462.517f, 31.59538f,286.6206f), new Vector4(-64.59702f, -1449.501f, 32.52492f,283.3147f), "", 50),
            new FubarVectors(1, new Vector4(-49.64009f, -1459.758f, 31.5235f,272.1921f), new Vector4(-45.58294f, -1445.368f, 32.4296f,89.81271f), "", 50),
            new FubarVectors(1, new Vector4(9.629698f, -1456.701f, 30.03289f,249.1075f), new Vector4(16.55038f, -1443.698f, 30.94945f,158.4256f), "", 50)
        };
        private static readonly List<Vector4> Area_01_MotelPark = new List<Vector4>
        {
            new Vector4(564.043f, -1758.564f, 28.73396f, 144.449f),
            new Vector4(355.183f, -1804.761f, 28.45638f, 231.0058f),
            new Vector4(407.4635f, -1786.49f, 28.53734f, 50.10332f)
        };
        private static readonly List<Vector4> Area_01_MotelDoor00 = new List<Vector4>
        {
            new Vector4(561.8203f, -1752.269f, 29.288f, 243.0668f),
            new Vector4(558.0323f, -1759.81f, 29.31371f, 253.0411f),
            new Vector4(554.9995f, -1766.487f, 29.31214f, 242.5642f),
            new Vector4(552.5132f, -1771.563f, 29.31199f, 250.823f),
            new Vector4(550.5521f, -1775.513f, 29.31202f, 251.4895f),
            new Vector4(566.2552f, -1777.936f, 29.35328f, 332.6465f),
            new Vector4(559.8361f, -1776.789f, 33.44262f, 62.29705f),
            new Vector4(559.2033f, -1777.009f, 33.44262f, 330.8163f),
            new Vector4(550.292f, -1772.838f, 33.44262f, 324.6054f),
            new Vector4(550.3577f, -1770.776f, 33.44262f, 238.7474f),
            new Vector4(552.7625f, -1765.38f, 33.44262f, 243.0984f),
            new Vector4(555.9849f, -1758.652f, 33.44262f, 239.9459f),
            new Vector4(559.6195f, -1750.779f, 33.44262f, 249.6146f),
            new Vector4(561.4752f, -1747.569f, 33.44262f, 158.9446f)
        };
        private static readonly List<Vector4> Area_01_MotelDoor01 = new List<Vector4>
        {
            new Vector4(372.1251f, -1791.44f, 29.09547f, 62.66883f),
            new Vector4(366.8529f, -1802.76f, 29.08733f, 135.5344f),
            new Vector4(379.0179f, -1812.238f, 29.05215f, 131.7613f),
            new Vector4(380.3817f, -1813.662f, 29.05634f, 136.3937f)
        };
        private static readonly List<Vector4> Area_01_MotelDoor02 = new List<Vector4>
        {
            new Vector4(405.1778f, -1795.555f, 29.09111f, 317.5866f),
            new Vector4(398.4097f, -1789.588f, 29.16263f, 312.9055f)
        };
        private static readonly List<Vector4> Area_01_AppPark = new List<Vector4>
        {
            new Vector4(281.6298f, -2084.469f, 16.35166f, 290.7606f),
            new Vector4(276.8926f, -2033.462f, 18.16816f, 320.7551f),
            new Vector4(334.1297f, -2039.538f, 20.69092f, 228.9603f),
            new Vector4(321.1824f, -1980.643f, 22.64873f, 320.2608f),
            new Vector4(369.7271f, -1977.898f, 23.76686f, 162.4525f),
            new Vector4(472.2678f, -1574.529f, 28.74213f, 49.67867f),
            new Vector4(-166.2606f, -1696.276f, 31.50836f, 49.7182f),
            new Vector4(-142.6077f, -1635.141f, 32.38818f, 323.381f),
            new Vector4(-141.5815f, -1559.423f, 34.04709f, 140.8511f),
            new Vector4(-177.7618f, -1633.308f, 32.85218f, 178.7312f),
            new Vector4(-188.6329f, -1672.489f, 33.08702f, 359.1886f),
            new Vector4(-188.754f, -1607.519f, 33.63618f, 353.8087f),
            new Vector4(-148.7522f, -1550.704f, 34.22133f, 323.7104f),
            new Vector4(-59.87205f, -1628.011f, 28.86864f, 139.9704f),
            new Vector4(-102.7107f, -1678.744f, 28.85073f, 140.4046f),
            new Vector4(-26.45156f, -1584.957f, 28.78423f, 91.24832f),
            new Vector4(-84.31429f, -1538.774f, 32.71443f, 50.9939f),
            new Vector4(-137.7021f, -1493.769f, 33.39972f, 52.79107f)
        };
        private static readonly List<Vector4> Area_01_AppDoor00 = new List<Vector4>
        {
            new Vector4(288.0881f, -2072.446f, 17.66357f, 106.6083f),
            new Vector4(289.5729f, -2077.163f, 17.66358f, 103.8723f),
            new Vector4(293.1721f, -2085.936f, 17.66358f, 105.6977f),
            new Vector4(293.7121f, -2087.809f, 17.66358f, 107.0208f),
            new Vector4(295.6873f, -2093.252f, 17.66357f, 108.0394f),
            new Vector4(297.521f, -2097.777f, 17.66358f, 101.8623f)
        };
        private static readonly List<Vector4> Area_01_AppDoor01 = new List<Vector4>
        {
            new Vector4(279.5616f, -2043.604f, 19.76757f, 51.48697f),
            new Vector4(281.0013f, -2042.143f, 19.76757f, 47.89005f),
            new Vector4(287.2568f, -2034.785f, 19.76757f, 48.40055f),
            new Vector4(289.9169f, -2030.908f, 19.76757f, 48.59494f)
        };
        private static readonly List<Vector4> Area_01_AppDoor02 = new List<Vector4>
        {
            new Vector4(313.4048f, -2040.677f, 20.9364f, 312.4617f),
            new Vector4(317.0564f, -2043.589f, 20.93639f, 314.3903f),
            new Vector4(324.5276f, -2049.719f, 20.9364f, 321.485f),
            new Vector4(325.7633f, -2050.738f, 20.9364f, 319.9163f),
            new Vector4(333.1129f, -2057.124f, 20.93639f, 324.0641f),
            new Vector4(334.5037f, -2058.189f, 20.93639f, 317.2841f),
            new Vector4(341.9326f, -2064.199f, 20.93641f, 324.5093f),
            new Vector4(345.5611f, -2067.574f, 20.93641f, 318.0851f),
            new Vector4(356.5523f, -2074.353f, 21.7445f, 44.61842f),
            new Vector4(357.8724f, -2073.366f, 21.7445f, 50.0993f),
            new Vector4(365.2285f, -2064.726f, 21.74449f, 55.57049f),
            new Vector4(371.4192f, -2057.244f, 21.74451f, 53.24276f),
            new Vector4(372.3423f, -2055.87f, 21.74451f, 55.31435f),
            new Vector4(364.3338f, -2045.629f, 22.3543f, 138.0992f),
            new Vector4(360.6859f, -2042.583f, 22.3543f, 138.1618f),
            new Vector4(353.5273f, -2036.262f, 22.3543f, 144.0208f),
            new Vector4(352.0767f, -2035.162f, 22.3543f, 140.5107f),
            new Vector4(344.5648f, -2028.887f, 22.3543f, 138.9868f),
            new Vector4(343.2806f, -2027.819f, 22.3543f, 150.0283f),
            new Vector4(335.9971f, -2021.638f, 22.35429f, 133.6053f),
            new Vector4(332.3294f, -2018.49f, 22.3543f, 149.2455f)
        };
        private static readonly List<Vector4> Area_01_AppDoor03 = new List<Vector4>
        {
            new Vector4(324.2805f, -1990.876f, 24.16728f, 51.60117f),
            new Vector4(325.2731f, -1989.636f, 24.16728f, 50.86519f),
            new Vector4(331.5278f, -1982.304f, 24.16729f, 46.07012f),
            new Vector4(334.3844f, -1978.351f, 24.16729f, 63.03723f)
        };
        private static readonly List<Vector4> Area_01_AppDoor04 = new List<Vector4>
        {
            new Vector4(362.2706f, -1987.048f, 24.23399f, 337.4959f),
            new Vector4(363.9159f, -1987.833f, 24.2337f, 338.5867f),
            new Vector4(374.5974f, -1991.554f, 24.23494f, 340.87f),
            new Vector4(383.6831f, -1994.904f, 24.23498f, 339.1976f),
            new Vector4(385.2216f, -1995.365f, 24.23498f, 335.9057f)
        };
        private static readonly List<Vector4> Area_01_AppDoor05 = new List<Vector4>
        {
            new Vector4(470.7589f, -1561.345f, 32.8263f, 231.7607f),
            new Vector4(465.6906f, -1567.357f, 32.82508f, 253.3353f),
            new Vector4(460.7023f, -1573.653f, 32.7923f, 231.6013f),
            new Vector4(454.9615f, -1580.029f, 32.79209f, 324.8198f),
            new Vector4(461.0227f, -1585.272f, 32.79213f, 326.3344f),
            new Vector4(467.195f, -1590.346f, 32.7923f, 318.2751f)
        };
        private static readonly List<Vector4> Area_01_AppDoor06 = new List<Vector4>
        {
            new Vector4(-157.8831f, -1679.81f, 33.83342f, 231.4444f),
            new Vector4(-141.5178f, -1693.579f, 33.06743f, 49.54147f),
            new Vector4(-141.7531f, -1692.86f, 32.87244f, 153.2541f),
            new Vector4(-148.0782f, -1687.418f, 33.06743f, 147.2833f),
            new Vector4(-146.8808f, -1688.43f, 33.06743f, 133.2055f),
            new Vector4(-141.6032f, -1693.611f, 36.16706f, 54.22722f),
            new Vector4(-141.7616f, -1692.965f, 36.16651f, 139.83f),
            new Vector4(-146.9352f, -1688.473f, 36.16632f, 145.0863f),
            new Vector4(-148.0491f, -1687.622f, 36.16643f, 136.9033f),
            new Vector4(-158.6362f, -1679.343f, 36.96656f, 220.1958f),
            new Vector4(-157.8868f, -1679.35f, 36.96671f, 138.9354f)
        };
        private static readonly List<Vector4> Area_01_AppDoor07 = new List<Vector4>
        {
            new Vector4(-146.0694f, -1614.557f, 36.0485f, 247.057f),
            new Vector4(-152.5175f, -1623.966f, 36.84831f, 238.912f),
            new Vector4(-150.4186f, -1625.451f, 36.84831f, 44.64316f),
            new Vector4(-151.2756f, -1622.318f, 33.64987f, 236.1247f),
            new Vector4(-150.2679f, -1625.616f, 33.65761f, 50.77521f)
        };
        private static readonly List<Vector4> Area_01_AppDoor08 = new List<Vector4>
        {
            new Vector4(-120.2041f, -1574.613f, 34.17648f, 128.709f),
            new Vector4(-114.11f, -1579.496f, 34.17712f, 136.7709f),
            new Vector4(-133.9962f, -1580.557f, 34.20803f, 234.7581f),
            new Vector4(-139.6986f, -1588.071f, 34.24365f, 220.1799f),
            new Vector4(-147.4937f, -1596.57f, 34.83135f, 250.0812f),
            new Vector4(-140.2354f, -1599.496f, 34.83135f, 332.7002f),
            new Vector4(-140.339f, -1599.562f, 38.21263f, 344.3773f),
            new Vector4(-147.334f, -1596.947f, 38.21263f, 325.5585f),
            new Vector4(-147.6081f, -1596.421f, 38.21263f, 241.9547f),
            new Vector4(-140.1836f, -1587.252f, 37.4078f, 224.642f),
            new Vector4(-134.2417f, -1580.546f, 37.4078f, 225.9547f),
            new Vector4(-119.9879f, -1574.488f, 37.40776f, 139.4787f),
            new Vector4(-114.1875f, -1579.509f, 37.40776f, 145.3338f),
            new Vector4(-118.9506f, -1586.196f, 37.40776f, 53.96056f),
            new Vector4(-123.1476f, -1591.288f, 37.40776f, 50.24197f)
        };
        private static readonly List<Vector4> Area_01_AppDoor09 = new List<Vector4>
        {
            new Vector4(-153.6336f, -1641.174f, 36.85108f, 142.4857f),
            new Vector4(-161.6777f, -1638.437f, 37.24594f, 323.8486f),
            new Vector4(-160.0375f, -1636.291f, 37.24594f, 139.7476f),
            new Vector4(-160.8604f, -1638.52f, 34.0289f, 324.8203f),
            new Vector4(-160.2334f, -1636.49f, 34.0289f, 148.0564f)
        };
        private static readonly List<Vector4> Area_01_AppDoor10 = new List<Vector4>
        {
            new Vector4(-216.5276f, -1674.5f, 34.46335f, 358.0927f),
            new Vector4(-224.3032f, -1674.336f, 34.46331f, 355.4249f),
            new Vector4(-224.9004f, -1666.426f, 34.46321f, 270.149f),
            new Vector4(-224.9689f, -1648.95f, 35.25456f, 268.5172f),
            new Vector4(-216.4393f, -1648.609f, 34.46321f, 175.1667f),
            new Vector4(-212.5325f, -1660.478f, 34.46321f, 84.9341f),
            new Vector4(-212.4246f, -1667.975f, 34.46322f, 95.86602f),
            new Vector4(-212.3401f, -1668.053f, 37.63696f, 100.0703f),
            new Vector4(-212.4093f, -1660.7f, 37.63696f, 90.88062f),
            new Vector4(-216.5219f, -1648.589f, 37.63694f, 187.0035f),
            new Vector4(-224.118f, -1648.549f, 38.44493f, 180.6826f),
            new Vector4(-224.5694f, -1653.804f, 37.63685f, 271.1275f),
            new Vector4(-224.94f, -1666.193f, 37.63695f, 273.0692f),
            new Vector4(-224.3898f, -1674.371f, 37.63671f, 3.388192f),
            new Vector4(-216.4192f, -1674.5f, 37.63671f, 11.76382f)
        };
        private static readonly List<Vector4> Area_01_AppDoor11 = new List<Vector4>
        {
            new Vector4(-208.8807f, -1600.684f, 34.8693f, 257.6242f),
            new Vector4(-215.6405f, -1576.341f, 34.86931f, 140.902f),
            new Vector4(-219.1553f, -1580.004f, 34.8693f, 226.562f),
            new Vector4(-223.0419f, -1585.817f, 34.8693f, 271.9609f),
            new Vector4(-222.8968f, -1601.145f, 34.87996f, 274.9853f),
            new Vector4(-223.0685f, -1617.555f, 34.86933f, 274.0373f),
            new Vector4(-212.9507f, -1618.114f, 34.86932f, 5.021047f),
            new Vector4(-212.0778f, -1617.522f, 34.86932f, 82.74075f),
            new Vector4(-210.1214f, -1607.032f, 34.8693f, 86.6795f),
            new Vector4(-205.6997f, -1585.531f, 38.05471f, 74.88187f),
            new Vector4(-215.8691f, -1576.461f, 38.05449f, 143.66f),
            new Vector4(-219.3826f, -1579.954f, 38.05449f, 240.0783f),
            new Vector4(-223.0453f, -1585.886f, 38.05449f, 270.9188f),
            new Vector4(-223.0513f, -1601.12f, 38.05449f, 277.0885f),
            new Vector4(-222.7573f, -1617.478f, 38.05642f, 284.5359f),
            new Vector4(-212.929f, -1618.177f, 38.05449f, 354.2167f),
            new Vector4(-212.044f, -1617.492f, 38.05449f, 88.48136f),
            new Vector4(-210.0232f, -1606.959f, 38.0493f, 79.57502f),
            new Vector4(-208.6289f, -1600.569f, 38.0493f, 86.96003f)
        };
        private static readonly List<Vector4> Area_01_AppDoor12 = new List<Vector4>
        {
            new Vector4(-167.5434f, -1534.44f, 35.09809f, 180.9823f),
            new Vector4(-174.585f, -1528.58f, 34.35387f, 157.4096f),
            new Vector4(-180.1855f, -1534.377f, 34.35802f, 233.7364f),
            new Vector4(-183.9134f, -1539.73f, 34.3578f, 234.6073f),
            new Vector4(-196.0406f, -1555.856f, 34.9554f, 230.8959f),
            new Vector4(-191.9102f, -1559.484f, 34.95459f, 318.5495f),
            new Vector4(-187.2642f, -1563.42f, 35.75513f, 45.84051f),
            new Vector4(-179.5034f, -1554.166f, 35.12589f, 54.12989f),
            new Vector4(-173.7457f, -1547.24f, 35.12734f, 47.78953f),
            new Vector4(-173.7311f, -1547.294f, 38.33431f, 61.16639f),
            new Vector4(-179.8927f, -1554.179f, 38.33079f, 46.37042f),
            new Vector4(-187.1998f, -1563.225f, 39.13039f, 44.57494f),
            new Vector4(-188.0962f, -1562.873f, 39.13202f, 319.6384f),
            new Vector4(-192.0846f, -1559.51f, 38.33504f, 317.1263f),
            new Vector4(-195.4426f, -1556.196f, 38.33498f, 229.5573f),
            new Vector4(-167.3674f, -1534.486f, 38.32979f, 141.6298f),
            new Vector4(-174.6109f, -1528.521f, 37.53503f, 145.6443f),
            new Vector4(-180.2486f, -1534.427f, 37.53503f, 234.2562f),
            new Vector4(-184.2959f, -1539.464f, 37.53503f, 224.1669f)
        };
        private static readonly List<Vector4> Area_01_AppDoor13 = new List<Vector4>
        {
            new Vector4(-80.36482f, -1607.802f, 31.48071f, 134.4956f),
            new Vector4(-87.88106f, -1601.524f, 32.31198f, 135.8372f),
            new Vector4(-93.50493f, -1607.265f, 32.31194f, 225.4778f),
            new Vector4(-97.72471f, -1612.448f, 32.31227f, 230.8636f),
            new Vector4(-109.5047f, -1628.565f, 32.90758f, 231.8593f),
            new Vector4(-105.3726f, -1632.51f, 32.90691f, 325.1131f),
            new Vector4(-97.55334f, -1638.68f, 32.10324f, 52.27797f),
            new Vector4(-89.54177f, -1629.902f, 31.50562f, 50.92158f),
            new Vector4(-83.7282f, -1622.899f, 31.47689f, 55.3524f),
            new Vector4(-109.6904f, -1628.518f, 36.28902f, 233.3222f),
            new Vector4(-105.5401f, -1632.517f, 36.28907f, 319.0049f),
            new Vector4(-98.17467f, -1638.797f, 35.48415f, 317.2677f),
            new Vector4(-97.35786f, -1638.884f, 35.48911f, 56.11509f),
            new Vector4(-89.60347f, -1629.958f, 34.6892f, 51.45573f),
            new Vector4(-83.54572f, -1623.042f, 34.6892f, 55.86382f),
            new Vector4(-80.39764f, -1607.897f, 34.68917f, 141.4541f),
            new Vector4(-87.98692f, -1601.518f, 35.48919f, 138.7999f),
            new Vector4(-93.46185f, -1607.203f, 35.48919f, 229.1447f),
            new Vector4(-97.82543f, -1612.38f, 35.48919f, 227.7428f)
        };
        private static readonly List<Vector4> Area_01_AppDoor14 = new List<Vector4>
        {
            new Vector4(-114.3474f, -1659.718f, 32.56437f, 54.81204f),
            new Vector4(-121.4748f, -1653.606f, 32.56432f, 146.824f),
            new Vector4(-128.9693f, -1647.31f, 33.28964f, 224.5156f),
            new Vector4(-138.6587f, -1658.874f, 33.33649f, 225.9563f),
            new Vector4(-131.5873f, -1665.546f, 32.56433f, 322.7212f),
            new Vector4(-124.0856f, -1671.081f, 32.56433f, 49.91695f),
            new Vector4(-130.8648f, -1679.44f, 34.91424f, 45.17841f),
            new Vector4(-123.9632f, -1671.267f, 35.7142f, 45.50016f),
            new Vector4(-131.4364f, -1665.431f, 35.71424f, 320.3313f),
            new Vector4(-138.3589f, -1659.072f, 36.51416f, 218.8195f),
            new Vector4(-107.3977f, -1651.41f, 34.88107f, 50.4087f),
            new Vector4(-114.4987f, -1659.54f, 35.71423f, 52.12929f),
            new Vector4(-121.298f, -1653.287f, 35.71423f, 140.9084f),
            new Vector4(-128.9899f, -1647.398f, 36.51421f, 228.8026f)
        };
        private static readonly List<Vector4> Area_01_AppDoor15 = new List<Vector4>
        {
            new Vector4(-35.6395f, -1555.083f, 30.67676f, 320.3778f),
            new Vector4(-44.33503f, -1547.226f, 31.24777f, 234.201f),
            new Vector4(-36.19032f, -1537.017f, 31.44851f, 232.9402f),
            new Vector4(-26.69999f, -1544.433f, 30.67676f, 133.9683f),
            new Vector4(-19.80826f, -1550.765f, 30.67675f, 44.94054f),
            new Vector4(-25.2005f, -1556.353f, 30.68685f, 59.8131f),
            new Vector4(-33.75809f, -1567.204f, 33.02135f, 51.74192f),
            new Vector4(-28.11848f, -1560.814f, 33.82142f, 253.5204f),
            new Vector4(-35.82493f, -1555.229f, 33.82142f, 310.9687f),
            new Vector4(-44.37337f, -1547.189f, 34.62143f, 223.989f),
            new Vector4(-14.12182f, -1544.02f, 33.02139f, 44.78683f),
            new Vector4(-19.7967f, -1550.721f, 33.82139f, 45.2869f),
            new Vector4(-26.51401f, -1544.353f, 33.82139f, 145.8846f),
            new Vector4(-36.04052f, -1537.016f, 34.62146f, 227.2898f)
        };
        private static readonly List<Vector4> Area_01_AppDoor16 = new List<Vector4>
        {
            new Vector4(-77.66776f, -1515.228f, 34.24531f, 228.8159f),
            new Vector4(-71.82516f, -1508.244f, 33.43612f, 228.5524f),
            new Vector4(-65.26344f, -1513.008f, 33.43609f, 139.1835f),
            new Vector4(-60.05282f, -1517.214f, 33.43614f, 138.3467f),
            new Vector4(-53.29351f, -1523.583f, 33.43613f, 46.03941f),
            new Vector4(-59.24172f, -1530.591f, 34.23521f, 46.55165f),
            new Vector4(-61.97739f, -1532.206f, 34.23523f, 316.4875f),
            new Vector4(-69.02783f, -1526.348f, 34.23523f, 317.3035f),
            new Vector4(-77.66993f, -1515.141f, 37.41958f, 222.6641f),
            new Vector4(-71.65851f, -1508.162f, 36.6249f, 229.8347f),
            new Vector4(-65.27235f, -1513.069f, 36.6249f, 140.7559f),
            new Vector4(-60.30402f, -1517.542f, 36.6249f, 140.4479f),
            new Vector4(-53.30389f, -1523.612f, 36.6249f, 48.95397f),
            new Vector4(-59.14006f, -1530.758f, 37.41961f, 49.60932f),
            new Vector4(-62.36468f, -1532.698f, 37.41961f, 317.5005f),
            new Vector4(-69.31495f, -1526.709f, 37.41961f, 317.1828f)
        };
        private static readonly List<Vector4> Area_01_AppDoor17 = new List<Vector4>
        {
            new Vector4(-112.6924f, -1479.282f, 33.82272f, 54.46892f),
            new Vector4(-107.6812f, -1473.255f, 33.82272f, 49.94418f),
            new Vector4(-113.4312f, -1467.9f, 33.82269f, 145.3804f),
            new Vector4(-123.1489f, -1459.994f, 33.8227f, 139.9742f),
            new Vector4(-126.7022f, -1456.795f, 34.50407f, 138.3093f),
            new Vector4(-132.1111f, -1462.96f, 33.82268f, 229.6945f),
            new Vector4(-125.6403f, -1473.509f, 33.8227f, 317.6729f),
            new Vector4(-119.7968f, -1477.853f, 33.8227f, 288.7377f),
            new Vector4(-119.3137f, -1486.508f, 36.98203f, 319.5407f),
            new Vector4(-112.5185f, -1479.382f, 36.99217f, 44.73256f),
            new Vector4(-107.6369f, -1473.354f, 36.99217f, 47.19739f),
            new Vector4(-113.4241f, -1467.826f, 36.99213f, 142.1096f),
            new Vector4(-122.7104f, -1459.977f, 36.99215f, 139.8741f),
            new Vector4(-127.4854f, -1457.011f, 37.79192f, 226.1762f),
            new Vector4(-132.2709f, -1462.701f, 36.99213f, 231.7981f),
            new Vector4(-138.0703f, -1470.553f, 36.99213f, 317.9042f),
            new Vector4(-125.944f, -1473.814f, 36.99209f, 316.9232f),
            new Vector4(-120.1112f, -1478.708f, 36.9921f, 320.1259f)
        };

        private static readonly List<FubarVectors> Area_02_BikerBiz = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(308.3347f, -762.0836f, 28.54117f,161.5521f), new Vector4(299.2875f, -759.1011f, 29.35226f,246.8127f), "", 100),//Forg
			new FubarVectors(2, new Vector4(106.578f, 164.7849f, 103.8213f,250.5189f), new Vector4(102.3799f, 175.6867f, 104.723f,160.0151f), "", 102),//Weed
			new FubarVectors(2, new Vector4(-1183.363f, -1384.89f, 4.307375f,203.1407f), new Vector4(-1171.099f, -1380.705f, 4.96929f,43.29512f), "", 103)//Cash
        };
        private static readonly List<FubarVectors> Area_02_OnineApps = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(391.1372f, 430.7655f, 143.3455f,263.3033f), new Vector4(373.8454f, 427.8694f, 145.6842f,86.8195f), "2045 North Conker Avenue", 62),
            new FubarVectors(2, new Vector4(353.6242f, 437.7651f, 146.4987f,295.0909f), new Vector4(346.5634f, 440.6315f, 147.7024f,301.3918f), "2044 North Conker Avenue", 61),
            new FubarVectors(2, new Vector4(131.4627f, 568.3471f, 183.2373f,273.4279f), new Vector4(128.1077f, 565.9875f, 183.9595f,7.40952f), "3677 Whispymound Drive", 66),
            new FubarVectors(2, new Vector4(-188.7043f, 502.1396f, 134.302f,105.5389f), new Vector4(-174.6972f, 502.5219f, 137.4202f,99.47465f), "3655 Wild Oats Drive", 60),
            new FubarVectors(2, new Vector4(-555.5865f, 665.2325f, 144.858f,345.7934f), new Vector4(-559.5379f, 663.8972f, 145.4869f,338.2878f), "2117 Milton Road", 68),
            new FubarVectors(2, new Vector4(-683.4403f, 604.8112f, 143.5365f,143.3412f), new Vector4(-685.8801f, 596.043f, 143.8559f,43.55814f), "2862 Hillcrest Avenue", 69),
            new FubarVectors(2, new Vector4(-742.8794f, 602.2574f, 141.7975f,34.69024f), new Vector4(-733.0906f, 593.6958f, 142.4776f,333.2375f), "2866 Hillcrest Avenue", 65),
            new FubarVectors(2, new Vector4(-752.9971f, 627.385f, 142.3257f,11.46253f), new Vector4(-753.2194f, 620.4108f, 142.7754f,290.5136f), "2868 Hillcrest Avenue", 64),
            new FubarVectors(2, new Vector4(-863.3615f, 699.5126f, 148.8364f,334.71f), new Vector4(-852.9528f, 695.2964f, 148.7888f,6.567395f), "2874 Hillcrest Avenue", 63),
            new FubarVectors(2, new Vector4(-1409.18f, 539.6423f, 122.6524f,95.03391f), new Vector4(-1405.57f, 526.9293f, 123.8312f,81.75223f), "4 Hangman Ave", 51),
            new FubarVectors(2, new Vector4(-1300.437f, 455.9947f, 97.42332f,273.7209f), new Vector4(-1294.251f, 454.5461f, 97.53577f,352.7717f), "2113 Mad Wayne Thunder Drive", 67),//hilllh
            new FubarVectors(2, new Vector4(280.8706f, -146.9761f, 64.39574f,72.70512f), new Vector4(285.7586f, -160.2631f, 64.61711f,67.66959f), "1162 Power Street", 51),
            new FubarVectors(2, new Vector4(-9.133142f, 38.01474f, 70.85339f,156.4133f), new Vector4(3.336215f, 37.03015f, 71.53041f,166.2114f), "0605 Spanish Avenue", 51),
            new FubarVectors(2, new Vector4(26.16544f, 82.39072f, 74.07111f,253.0272f), new Vector4(14.97062f, 84.64449f, 74.66554f,249.1399f), "0604 Las Lagunas Blvd", 51),
            new FubarVectors(2, new Vector4(-43.26082f, -49.57767f, 62.62751f,74.82602f), new Vector4(-41.18145f, -58.44262f, 63.66256f,68.21356f), "2143 Las Lagunas Blvd", 50),
            new FubarVectors(2, new Vector4(-215.4971f, 37.01777f, 58.85316f,76.82461f), new Vector4(-212.2844f, 32.61346f, 59.82467f,74.47293f), "The Royale", 51),
            new FubarVectors(2, new Vector4(-206.0992f, 193.274f, 79.76238f,88.4874f), new Vector4(-200.9697f, 186.2406f, 80.50385f,83.26008f), "1561 San Vitas St", 50),
            new FubarVectors(2, new Vector4(-500.2216f, 84.52251f, 55.46696f,87.52975f), new Vector4(-497.0152f, 79.44189f, 55.88134f,87.01096f), "0184 Milton Road", 51),
            new FubarVectors(2, new Vector4(-634.9193f, 56.58205f, 43.07878f,89.69731f), new Vector4(-635.941f, 44.26926f, 42.69791f,106.0194f), "Tinsel Towers", 59),
            new FubarVectors(2, new Vector4(-633.4327f, 152.4535f, 56.72532f,88.36077f), new Vector4(-628.3242f, 169.8089f, 61.15117f,92.87571f), "0504 South Mo Milton Drive", 51),
            new FubarVectors(2, new Vector4(-795.6973f, 307.4856f, 85.01926f,178.1151f), new Vector4(-775.0281f, 312.9397f, 85.69812f,213.0951f), "Eclipse Tower", 55),
            new FubarVectors(2, new Vector4(-825.234f, -439.0717f, 35.95693f,116.6401f), new Vector4(-881.5735f, -438.8008f, 39.59988f,287.7038f), "Weazel Plaza", 70),
            new FubarVectors(2, new Vector4(-870.299f, -375.0982f, 38.59563f,204.0324f), new Vector4(-902.8311f, -377.7642f, 38.96129f,210.9382f), "Richards Majestic", 58),
            new FubarVectors(2, new Vector4(-1459.378f, -499.3842f, 31.92451f,31.31658f), new Vector4(-1459.631f, -506.0213f, 32.07638f,26.80223f), "Del Perro Heights", 57),
            new FubarVectors(2, new Vector4(-1530.489f, -345.8115f, 44.63332f,133.9072f), new Vector4(-1533.574f, -326.8796f, 47.91115f,59.59607f), "0069 Cougar Ave", 50),
            new FubarVectors(2, new Vector4(-1555.569f, -401.4076f, 41.30507f,227.9156f), new Vector4(-1564.309f, -406.5165f, 42.38401f,238.9189f), "1237 Prosperity St", 50),
            new FubarVectors(2, new Vector4(-1608.521f, -451.1829f, 37.4748f,140.6755f), new Vector4(-1606.557f, -432.497f, 40.43135f,47.31475f), "1115 Blvd Del Perro", 50),
            new FubarVectors(2, new Vector4(-1243.243f, -255.8864f, 38.37408f,26.98708f), new Vector4(-1232.204f, -261.1794f, 38.73338f,315.3375f), "634 Blvd Del Perro", 52),
            new FubarVectors(2, new Vector4(-23.18966f, -625.4133f, 34.99584f,247.5235f), new Vector4(-15.42344f, -612.4637f, 35.86151f,242.3017f), "4 Integrity Way", 56),
            new FubarVectors(2, new Vector4(-256.4478f, -1006.518f, 27.90525f,249.5537f), new Vector4(-261.3062f, -971.3901f, 31.22001f,195.3577f), "3 Alta Street", 71),
            new FubarVectors(2, new Vector4(-668.0173f, -853.3813f, 23.59562f,0.3397407f), new Vector4(-662.5483f, -853.9982f, 24.46053f,354.8136f), "2057 Vespucci Boulevard", 50),
            new FubarVectors(2, new Vector4(-786.88f, -802.1656f, 19.97162f,178.6493f), new Vector4(-762.9339f, -753.6349f, 27.8686f,264.231f), "Dream Tower", 51),
            new FubarVectors(2, new Vector4(-759.1947f, -870.2823f, 20.94195f,268.0727f), new Vector4(-762.8513f, -865.3188f, 20.94106f,266.8922f), "0325 South Rockford Dr", 51),
            new FubarVectors(2, new Vector4(-811.8624f, -953.7927f, 14.74118f,95.76396f), new Vector4(-805.1839f, -959.5523f, 18.14205f,244.4298f), "0112 S Rockford Dr", 50),
            new FubarVectors(2, new Vector4(-986.4677f, -1451.889f, 4.313082f,109.341f), new Vector4(-970.0403f, -1431.494f, 7.679166f,110.412f), "0115 Bay City Avenue", 51),
            new FubarVectors(2, new Vector4(-1468.252f,-927.374f,9.604f, -40.306f), new Vector4(-1471.827f, -920.3f, 10.022f, -127.541f), "Dell Perro Beach Cluhouse", 97),
            new FubarVectors(2, new Vector4(55.47f,-1047.679f,28.955f, 158.39f), new Vector4(51.805f, -1043.854f, 29.533f, 164.013f), "Pillbox Hill Clubhouse", 97),
            new FubarVectors(2, new Vector4(-26.914f,-192.657f,51.852f, 158.746f), new Vector4(-22.198f, -192.294f, 52.368f, 159.527f), "Hawick Clubhouse", 98),
            new FubarVectors(2, new Vector4(178.187f,306.282f,104.868f, -174.345f), new Vector4(189.881f, 309.086f, 105.395f, -176.968f), "Downtown Clubhouse", 98),
            new FubarVectors(2, new Vector4(-1145.934f,-1579.522f,3.87f, -146.259f), new Vector4(-1156.163f, -1574.619f, 8.34f, -146.803f), "Vespucci Beach Clubhouse", 98)
        };
        private static readonly List<FubarVectors> Area_02_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(226.9892f, 200.1118f, 104.7482f,70.67568f), new Vector4(235.4941f, 216.964f, 106.2868f, 111.4458f), "Pacific Standard", 210),
            new FubarVectors(2, new Vector4(324.7301f, 164.8f, 102.8791f,70.78919f), new Vector4(321.9381f, 180.6811f, 103.5865f, 177.1404f), "Blazing Tattoo", 211),
            new FubarVectors(2, new Vector4(235.5962f, -41.89376f, 69.11172f,162.0652f), new Vector4(250.0451f, -47.25876f, 69.94103f, 69.72601f), "Hawick Amunation", 212),
            new FubarVectors(2, new Vector4(137.2234f, -200.9878f, 53.75822f,248.4023f), new Vector4(123.9142f, -220.2143f, 54.55784f, 345.0176f), "Hawick Suburban", 214),
            new FubarVectors(2, new Vector4(-32.23264f, -135.3476f, 56.48986f,183.2817f), new Vector4(-32.13033f, -151.3396f, 57.0765f, 330.7242f), "Hair on Hawick", 215),
            new FubarVectors(2, new Vector4(-147.4243f, -306.0661f, 38.21796f,160.6736f), new Vector4(-162.1964f, -301.9873f, 39.7333f, 253.1877f), "Burton Ponsonbys", 216),
            new FubarVectors(2, new Vector4(375.1748f, 315.8087f, 102.7154f,76.55219f),new Vector4(378.0046f, 327.4489f, 103.5665f, 168.7241f), "Downtown Vinewood 247", 217),
            new FubarVectors(2, new Vector4(-364.8643f, -21.49476f, 46.36693f,249.3106f), new Vector4(-355.1537f, -47.79618f, 49.03637f, 272.6797f), "Burton Fleeca", 218),
            new FubarVectors(2, new Vector4(-713.5596f, -174.4735f, 36.25768f,28.68805f), new Vector4(-710.1184f, -154.7847f, 37.41516f, 118.8819f), "Rockford Hills Ponsonbys", 219),
            new FubarVectors(2, new Vector4(-828.7138f, -193.7069f, 36.83593f,28.29967f), new Vector4(-817.2866f, -185.4618f, 37.56889f, 123.674f), "Bob Mulet", 220),
            new FubarVectors(2, new Vector4(-1215.797f, -315.5207f, 37.04801f,296.2815f), new Vector4(-1216.75f, -333.3016f, 37.78083f, 3.907923f), "Rockford Hills Fleeca", 221),
            new FubarVectors(2, new Vector4(-1458.021f, -227.8909f, 48.5702f,316.9551f),new Vector4(-1451.501f, -236.892f, 49.80813f, 46.6344f), "Morningwood Ponsonbys", 222),
            new FubarVectors(2, new Vector4(-1319.844f, -390.2357f, 35.86639f,345.8465f), new Vector4(-1307.536f, -391.9264f, 36.69582f, 74.42401f), "Morningwood Amunation", 223),
            new FubarVectors(2, new Vector4(-1507.86f, -382.1249f, 40.40653f,46.38361f), new Vector4(-1487.026f, -379.9144f, 40.16343f, 127.0988f), "Morningwood Robs Liquor", 224),
            new FubarVectors(2, new Vector4(-1224.814f, -892.837f, 11.78194f,304.0288f), new Vector4(-1223.797f, -906.7352f, 12.32636f, 30.319f), "Vespucci Robs Liquor", 225),
            new FubarVectors(2, new Vector4(-1296.928f, -1118.102f, 5.915605f,1.422517f), new Vector4(-1283.731f, -1117.594f, 6.990116f, 67.68818f), "Beach Comb Over ", 226),
            new FubarVectors(2, new Vector4(-1164.04f, -1419.653f, 4.05209f,248.0736f), new Vector4(-1153.619f, -1426.511f, 4.954462f, 358.4786f), "The Pit", 227),
            new FubarVectors(2, new Vector4(-818.5187f, -1091.302f, 10.38673f,299.5346f),new Vector4(-820.2014f, -1073.547f, 11.32811f, 213.3348f), "Vespucci Binco", 228),
            new FubarVectors(2, new Vector4(-661.6982f, -952.7162f, 20.75815f,88.29076f), new Vector4(-664.095f, -937.3063f, 21.82924f, 179.9123f), "Little Seoul Amunation", 229),
            new FubarVectors(2, new Vector4(-707.2881f, -921.782f, 18.42973f,0.4575365f), new Vector4(-711.3452f, -911.8076f, 19.21559f, 150.054f), "Little Seoul Ltd", 230),
            new FubarVectors(2, new Vector4(16.66657f, -1125.79f, 28.18048f,92.40207f), new Vector4(19.37551f, -1108.807f, 29.79703f, 158.676f), "Pillbox Hill Amunation", 231)
        }; 
        private static readonly List<FubarVectors> Area_02_Resurant = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(538.4594f, 87.52708f, 95.56678f,69.27296f), new Vector4(538.5647f, 101.3927f, 96.52599f,158.0895f), "Pizza This Vinewood Blvd", 0),
            new FubarVectors(2, new Vector4(452.4781f, 118.5189f, 98.45866f,69.21456f), new Vector4(456.3568f, 130.0719f, 99.27531f,159.2153f), "Vinewood Liquor", 0),
            new FubarVectors(2, new Vector4(437.8595f, 123.8854f, 99.28707f,66.62507f), new Vector4(443.7841f, 134.695f, 100.0071f,163.7448f), "Guido's Takeout", 0),
            new FubarVectors(2, new Vector4(80.19464f, 268.5551f, 109.0216f,230.1188f), new Vector4(81.34298f, 274.277f, 110.2102f,176.0539f), "Up n Atom Vinewood", 0),
            new FubarVectors(2, new Vector4(-27.14349f, 253.5577f, 106.5967f,274.8087f), new Vector4(-15.98969f, 239.797f, 109.5534f,351.0423f), "Haute Restaurant", 0),
            new FubarVectors(2, new Vector4(-81.63985f, 246.7964f, 100.0408f,273.2317f), new Vector4(-84.315f, 234.698f, 100.5634f,357.7657f), "Eclipse Lounge", 0),
            new FubarVectors(2, new Vector4(-169.8181f, 277.2538f, 92.78027f,84.79874f), new Vector4(-169.532f, 284.9517f, 93.76392f,176.8707f), "", 0),
            new FubarVectors(2, new Vector4(-230.6864f, 239.2204f, 90.75179f,176.6387f), new Vector4(-239.3676f, 244.4058f, 92.04383f,324.2243f), "Ellen's Liquor Lover", 0),
            new FubarVectors(2, new Vector4(-244.6248f, 273.2097f, 91.25437f,84.41698f), new Vector4(-242.2366f, 279.3205f, 92.03819f,224.4066f), "Spitroasters", 0),
            new FubarVectors(2, new Vector4(-363.4861f, 252.8218f, 83.79099f,92.3887f), new Vector4(-361.4898f, 275.2933f, 86.42198f,220.5279f), "Last Train In Los Santos", 0),
            new FubarVectors(2, new Vector4(-629.0597f, 254.7192f, 80.87107f,263.9572f), new Vector4(-628.015f, 239.1743f, 81.89254f,79.21803f), "Bean Machine West Vinewood", 0),
            new FubarVectors(2, new Vector4(-531.9665f, -24.32326f, 43.67522f,352.2102f), new Vector4(-509.2178f, -21.94697f, 45.60899f,355.4825f), "Little Teapot", 0),
            new FubarVectors(2, new Vector4(-65.43436f, -86.35959f, 57.03943f,343.0922f), new Vector4(-58.14101f, -91.8278f, 57.76619f,109.9192f), "Liquor Store Burton", 0),
            new FubarVectors(2, new Vector4(-16.59479f, -116.7578f, 56.15579f,67.22774f), new Vector4(-13.85119f, -110.2788f, 56.83836f,159.8341f), "Lettuce Be", 0),
            new FubarVectors(2, new Vector4(85.94667f, -212.9617f, 53.8646f,158.2934f), new Vector4(89.19517f, -221.9615f, 54.6367f,344.6104f), "Bite Alta", 0),
            new FubarVectors(2, new Vector4(-127.6669f, -248.8647f, 43.47805f,159.7269f), new Vector4(-132.0047f, -247.4509f, 44.22964f,244.6938f), "Cafe Austere", 0),
            new FubarVectors(2, new Vector4(-131.9311f, -260.0234f, 42.46017f,160.4961f), new Vector4(-138.3483f, -256.9931f, 43.59497f,291.5483f), "Cluckin Bell Rockford Plaza", 0),
            new FubarVectors(2, new Vector4(186.1229f, -218.3073f, 53.26535f,253.6089f), new Vector4(189.3318f, -231.0283f, 54.07308f,341.8489f), "Crucial Fix Alta", 0),
            new FubarVectors(2, new Vector4(218.8925f, -33.03009f, 69.09287f,255.8319f), new Vector4(215.2322f, -17.27869f, 74.9873f,180.8714f), "Pizza This Hawick", 0),
            new FubarVectors(2, new Vector4(224.4228f, -35.29259f, 69.09122f,247.1841f), new Vector4(229.556f, -22.65656f, 74.98734f,153.3675f), "Bite Hawick", 0),
            new FubarVectors(2, new Vector4(-1546.757f, -479.3918f, 34.74766f,120.2095f), new Vector4(-1546.594f, -467.3303f, 36.18837f,170.532f), "Up n Atom Del Perro", 0),
            new FubarVectors(2, new Vector4(-1531.878f, -444.6728f, 34.81515f,51.82134f), new Vector4(-1535.021f, -453.8101f, 35.92439f,309.6328f), "Wigwam Del Perro", 0),
            new FubarVectors(2, new Vector4(-1536.723f, -439.2456f, 34.81496f,22.98796f), new Vector4(-1552.6f, -440.3448f, 40.51905f,215.7485f), "Taco Bomb Del Perro", 0),
            new FubarVectors(2, new Vector4(-1535.003f, -435.3539f, 34.81527f,50.00441f), new Vector4(-1549.017f, -436.0092f, 35.88671f,233.6047f), "Bean Machine Del Perro", 0),
            new FubarVectors(2, new Vector4(-1535.003f, -435.3573f, 34.81529f,50.00097f), new Vector4(-1539.253f, -427.5753f, 35.59194f,220.1068f), "Bite Del Perro", 0),
            new FubarVectors(2, new Vector4(-1535.004f, -435.3546f, 34.81451f,49.97198f), new Vector4(-1535.125f, -422.6668f, 35.59194f,226.5025f), "Chinuahua Hotdogs", 0),
            new FubarVectors(2, new Vector4(-1465.923f, -312.781f, 44.93091f,220.3144f), new Vector4(-1472.761f, -328.8488f, 44.8179f,316.9998f), "Las Cuadras", 0),
            new FubarVectors(2, new Vector4(-1503.804f, -230.3273f, 50.24612f,39.57048f), new Vector4(-1497.542f, -225.657f, 51.31521f,118.2816f), "Chido!", 0),
            new FubarVectors(2, new Vector4(-1447.081f, -150.1342f, 48.42823f,216.4612f), new Vector4(-1460.543f, -155.0947f, 48.82668f,216.2012f), "Cafe Redemption Morninwood", 0),
            new FubarVectors(2, new Vector4(-1392.278f, -222.0454f, 43.92598f,219.7812f), new Vector4(-1395.539f, -229.7321f, 44.34838f,310.8404f), "Ground & Pound Morninwood", 0),
            new FubarVectors(2, new Vector4(-1228.857f, -293.8191f, 36.95246f,118.3363f), new Vector4(-1229.728f, -286.2531f, 37.73439f,208.9078f), "Noodle Exchange Del Perro", 0),
            new FubarVectors(2, new Vector4(-1245.555f, -302.5677f, 36.63088f,117.1571f), new Vector4(-1250.355f, -295.4168f, 37.34916f,203.4961f), "Bite Boulevard Del Perro", 0),
            new FubarVectors(2, new Vector4(-1325.934f, -287.1807f, 39.10888f,32.22031f), new Vector4(-1318.9f, -283.0023f, 39.87169f,120.0081f), "Dickies Bagels Del Perro", 0),
            new FubarVectors(2, new Vector4(-1346.798f, -252.4884f, 41.94956f,32.55232f), new Vector4(-1337.507f, -249.2274f, 42.66518f,123.6237f), "Viendemonte Morninwood", 0),
            new FubarVectors(2, new Vector4(-1351.864f, -245.9756f, 41.97754f,32.91863f), new Vector4(-1344.464f, -241.4573f, 42.69979f,131.8981f), "Cherry Popper Morningwood", 0),
            new FubarVectors(2, new Vector4(-1373.273f, -214.3877f, 43.6085f,33.86031f), new Vector4(-1366.889f, -208.8841f, 44.41915f,123.1994f), "Bean Machine Morningwood", 0),
            new FubarVectors(2, new Vector4(-732.9987f, -201.4265f, 36.4551f,206.2737f), new Vector4(-741.7888f, -205.9026f, 37.27527f,296.6303f), "Wup Et Dux", 0),
            new FubarVectors(2, new Vector4(-641.6041f, -307.6837f, 34.32437f,28.75718f), new Vector4(-628.6608f, -300.8252f, 35.34399f,122.0364f), "Cafe Redemption Rockford", 0),
            new FubarVectors(2, new Vector4(-239.0872f, -379.1317f, 29.20175f,51.61753f), new Vector4(-235.5136f, -372.4515f, 29.96478f,133.6524f), "Viendemonte Rockford Plaza", 0),
            new FubarVectors(2, new Vector4(-255.4297f, -339.5585f, 29.20034f,6.567483f), new Vector4(-241.3861f, -345.7486f, 30.02269f,46.86651f), "Bite Rockford Plaza", 0),
            new FubarVectors(2, new Vector4(-647.7058f, -685.4771f, 30.32428f,177.1451f), new Vector4(-657.8462f, -678.7858f, 31.48309f,310.6013f), "Taco Bomb Little Seoul", 0),
            new FubarVectors(2, new Vector4(-790.3741f, -647.569f, 28.26784f,89.70515f), new Vector4(-794.8264f, -633.4096f, 29.02696f,172.3108f), "Sho San Andreas Ave", 0),
            new FubarVectors(2, new Vector4(-855.8125f, -611.572f, 28.27586f,26.56078f), new Vector4(-838.4814f, -608.3878f, 29.02696f,134.6227f), "Bean Machine Movie Star Way", 0),
            new FubarVectors(2, new Vector4(-518.4117f, -668.2051f, 32.47387f,272.7874f), new Vector4(-519.9521f, -677.5922f, 33.67113f,2.053997f), "Snr. Buns", 0),
            new FubarVectors(2, new Vector4(-567.9141f, -668.2919f, 32.45552f,271.5312f), new Vector4(-576.8539f, -678.1107f, 32.36259f,329.1192f), "Hit n Run Coffee", 0),
            new FubarVectors(2, new Vector4(-648.2614f, -809.9727f, 24.14817f,166.7533f), new Vector4(-659.0911f, -814.3136f, 24.5431f,237.8959f), "Bean Machine Palomino Ave", 0),
            new FubarVectors(2, new Vector4(-705.2039f, -878.6642f, 22.95818f,40.19847f), new Vector4(-701.053f, -883.9796f, 23.7891f,42.12017f), "Sho Vespucci Blvd", 0),
            new FubarVectors(2, new Vector4(-648.1524f, -881.9581f, 23.97042f,180.3042f), new Vector4(-655.5258f, -880.5791f, 24.67752f,267.6298f), "Wook Noodle House", 0),
            new FubarVectors(2, new Vector4(-647.5699f, -886.1371f, 24.08495f,177.2366f), new Vector4(-654.5987f, -885.7209f, 24.68122f,262.2534f), "Park Jung Restaurant", 0),
            new FubarVectors(2, new Vector4(-647.7304f, -908.5671f, 23.55358f,177.5437f), new Vector4(-661.2415f, -907.5676f, 24.60215f,249.4144f), "Hwan Cafe", 0),
            new FubarVectors(2, new Vector4(-643.0793f, -1263.364f, 9.922843f,73.25079f), new Vector4(-638.8852f, -1249.868f, 11.81044f,165.7858f), "Sho Puerta", 0),
            new FubarVectors(2, new Vector4(-849.9955f, -1142.077f, 5.920348f,96.46621f), new Vector4(-860.9088f, -1140.817f, 7.192339f,181.8489f), "Wigwam Vespucci", 0),
            new FubarVectors(2, new Vector4(-878.7078f, -1166.286f, 4.379018f,122.2017f), new Vector4(-882.1713f, -1155.765f, 5.183126f,216.5249f), "Liquor Hole Vespucci", 0),
            new FubarVectors(2, new Vector4(-1043.789f, -1347.905f, 4.804594f,283.4934f), new Vector4(-1039.122f, -1352.958f, 5.553193f,10.70124f), "La Spada", 0),
            new FubarVectors(2, new Vector4(-1101.542f, -1370.111f, 4.492794f,113.3676f), new Vector4(-1108.536f, -1356.058f, 5.040562f,211.3108f), "Crucial Fix Vespucci", 0),
            new FubarVectors(2, new Vector4(-1122.524f, -1381.362f, 4.505213f,119.3225f), new Vector4(-1129.097f, -1374.446f, 5.121876f,178.0843f), "Marlins Cafe", 0),
            new FubarVectors(2, new Vector4(-1180.923f, -1415.644f, 3.73224f,123.3885f), new Vector4(-1185.012f, -1412.502f, 4.449267f,212.6461f), "Al Dente's", 0),
            new FubarVectors(2, new Vector4(-1167.766f, -1424.71f, 3.841892f,307.5438f), new Vector4(-1171.207f, -1434.596f, 4.437909f,21.75495f), "Ice Maiden", 0),
            new FubarVectors(2, new Vector4(-1191.114f, -1528.291f, 3.774212f,305.6349f), new Vector4(-1186.828f, -1536.354f, 4.379496f,9.615654f), "Muscle Peach", 0),
            new FubarVectors(2, new Vector4(-1208.898f, -1376.3f, 3.426727f,295.7585f), new Vector4(-1208.808f, -1384.291f, 4.074572f,48.0996f), "Steamboat Beers", 0),
            new FubarVectors(2, new Vector4(-1286.101f, -1392.589f, 3.776859f,291.807f), new Vector4(-1286.252f, -1386.164f, 4.447882f,197.5911f), "Mex On The Beach", 0),
            new FubarVectors(2, new Vector4(-1283.046f, -1210.802f, 4.050405f,19.18747f), new Vector4(-1271.785f, -1200.882f, 5.366249f,75.99395f), "Nut Boster", 0),
            new FubarVectors(2, new Vector4(-1284.068f, -1138.527f, 5.711693f,24.42763f), new Vector4(-1283.7f, -1130.839f, 6.792918f,149.0159f), "Bean Machine Vespucci", 0),
            new FubarVectors(2, new Vector4(-1247.887f, -1079.021f, 7.693732f,196.1291f), new Vector4(-1256.064f, -1079.248f, 8.421316f,333.737f), "Surfries", 0),
            new FubarVectors(2, new Vector4(-1239.682f, -1104.491f, 7.404526f,194.2676f), new Vector4(-1247.306f, -1105.905f, 8.107233f,285.2415f), "The Split Kipper", 0),
            new FubarVectors(2, new Vector4(-1236.931f, -1168.155f, 6.908636f,294.0179f), new Vector4(-1230.109f, -1174.392f, 7.700814f,334.6053f), "Pot-Heads", 0),
            new FubarVectors(2, new Vector4(-1123.751f, -1335.934f, 4.387213f,298.789f), new Vector4(-1121.003f, -1342.437f, 5.050136f,11.186f), "Major Organics", 0),
            new FubarVectors(2, new Vector4(-1180.106f, -1271.728f, 5.324938f,22.54414f), new Vector4(-1168.621f, -1267.214f, 6.202152f,84.65378f), "Taco Libre", 0),
            new FubarVectors(2, new Vector4(-1208.671f, -1163.997f, 7.047048f,11.85629f), new Vector4(-1197.767f, -1168.129f, 7.69622f,93.70429f), "Noodle Exchange Vespucci", 0),
            new FubarVectors(2, new Vector4(-1212.298f, -1149.61f, 7.042908f,14.20931f), new Vector4(-1204.576f, -1146.63f, 7.699422f,111.7881f), "Dickies Bagels Vespucci", 0),
            new FubarVectors(2, new Vector4(-1216.245f, -1132.687f, 7.031077f,18.23138f), new Vector4(-1206.977f, -1134.22f, 7.703513f,103.9074f), "Cool Beans Vespucci", 0),
            new FubarVectors(2, new Vector4(-1227.604f, -1096.871f, 7.389218f,18.90436f), new Vector4(-1221.369f, -1095.565f, 8.121229f,107.7673f), "Prawn Vivant", 0),
            new FubarVectors(2, new Vector4(-1286.722f, -882.9308f, 10.64006f,27.99952f), new Vector4(-1279.281f, -877.0118f, 11.93027f,134.7766f), "Cool Beans Del Perro", 0),
            new FubarVectors(2, new Vector4(-1362.538f, -800.3719f, 18.58821f,52.22369f), new Vector4(-1356.856f, -791.306f, 20.24218f,140.2221f), "Hedera", 0),
            new FubarVectors(2, new Vector4(-1331.208f, -665.5943f, 25.75952f,125.5355f), new Vector4(-1334.82f, -661.0286f, 26.51056f,218.7648f), "The Fish Net", 0),
            new FubarVectors(2, new Vector4(-1463.556f, -715.962f, 24.51004f,59.79084f), new Vector4(-1463.13f, -704.6888f, 26.79113f,139.5251f), "Sumac", 0)
        };
        private static readonly List<FubarVectors> Area_02_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(-258.6324f, 194.7045f, 84.54053f,268.0275f), new Vector4(-245.9067f, 201.331f, 83.62846f,81.38106f), "West Vinewood Backlot", 3),
            new FubarVectors(2, new Vector4(350.2894f, 320.1672f, 103.7689f,75.94923f), new Vector4(367.0773f, 336.9164f, 103.3512f,158.4115f), "Discount Retail Unit", 2),
            new FubarVectors(2, new Vector4(-1283.439f, -812.7316f, 16.85418f,36.85705f), new Vector4(-1266.397f, -817.1248f, 17.09918f,125.6402f), "Derriere Lingerie Backlot", 2),
            new FubarVectors(2, new Vector4(-1074.916f, -1253.214f, 5.177716f,212.0248f), new Vector4(-1083.556f, -1255.17f, 5.417806f,284.7776f), "White Widow Garage", 1),
            new FubarVectors(2, new Vector4(144.6222f, 159.8517f, 104.2794f,335.4177f), new Vector4(115.589f, 165.5703f, 104.5416f,253.3076f), "Foreclosed Garage", 1)
        };
        private static readonly List<FubarVectors> Area_02_Lesure = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(-599.8676f, 271.7939f, 81.4464f,85.45169f), new Vector4(-600.9938f, 279.2018f, 82.03982f,259.4916f), "Eight-Bit Arcade", 15),
            new FubarVectors(2, new Vector4(-1268.154f, -314.1594f, 36.3059f,116.0627f), new Vector4(-1269.957f, -305.3174f, 36.99113f,239.4322f), "Insert Coin Arcade", 15),
            new FubarVectors(2, new Vector4(227.7803f, 347.4229f, 104.8593f,248.8978f), new Vector4(224.8269f, 336.4694f, 105.5972f,328.7571f), "Pitchers", 0),
            new FubarVectors(2, new Vector4(232.5575f, 304.9915f, 104.9066f,96.44359f), new Vector4(220.0452f, 304.7705f, 105.58f,249.4854f), "Singletons", 0),
            new FubarVectors(2, new Vector4(545.1163f, 153.0471f, 98.32916f,339.947f), new Vector4(554.8564f, 151.3207f, 99.24667f,60.93895f), "Vinewood Plaza", 0),
            new FubarVectors(2, new Vector4(413.6547f, 107.5556f, 100.3252f,248.2753f), new Vector4(408.9741f, 90.79801f, 101.3001f,348.4134f), "Cini Areola", 0),
            new FubarVectors(2, new Vector4(339.7527f, 159.4495f, 102.5601f,67.62212f), new Vector4(339.8706f, 178.84f, 103.0347f,157.4767f), "Doppller Theater", 10),
            new FubarVectors(2, new Vector4(303.8174f, 143.9208f, 103.1234f,248.988f), new Vector4(298.5047f, 136.311f, 104.1122f,340.8582f), "Whirligig Theater", 10),
            new FubarVectors(2, new Vector4(289.7719f, 177.5454f, 103.5878f,72.25198f), new Vector4(301.326f, 202.2993f, 104.375f,159.5062f), "The Oriental Theater", 10),
            new FubarVectors(2, new Vector4(127.9204f, 209.0648f, 106.4594f,248.0694f), new Vector4(122.9292f, 199.8139f, 107.2205f,347.5729f), "Blarneys World Of Awesome", 0),
            new FubarVectors(2, new Vector4(113.9179f, 242.2098f, 107.1038f,69.96691f), new Vector4(119.1936f, 252.0568f, 107.917f,163.3384f), "Wax Haven", 0),
            new FubarVectors(2, new Vector4(65.53359f, 231.8264f, 108.5067f,247.0528f), new Vector4(58.82985f, 224.1814f, 109.3446f,340.7593f), "Bishop's WTF", 0),
            new FubarVectors(2, new Vector4(-145.4813f, 243.863f, 94.14417f,267.1799f), new Vector4(-143.6794f, 229.407f, 94.93378f,356.3349f), "Hardcore Comic Store", 0),
            new FubarVectors(2, new Vector4(-256.8069f, 253.5213f, 90.70728f,270.592f), new Vector4(-254.9978f, 245.1778f, 91.86018f,359.3836f), "The Dungeon Crawler", 0),
            new FubarVectors(2, new Vector4(-380.9499f, 230.0534f, 83.33204f,275.6721f), new Vector4(-379.254f, 217.9478f, 83.6597f,5.849146f), "Hornbills", 0),
            new FubarVectors(2, new Vector4(-428.4391f, 252.2975f, 82.43752f,83.42802f), new Vector4(-430.2177f, 261.4176f, 83.00622f,176.6636f), "Split Sides West", 0),
            new FubarVectors(2, new Vector4(-577.0341f, 269.2364f, 82.0406f,84.58323f), new Vector4(-576.3774f, 276.9326f, 82.75054f,178.9588f), "Full Moon Film", 0),
            new FubarVectors(2, new Vector4(-598.9429f, 252.5842f, 81.48907f,263.7144f), new Vector4(-602.1702f, 244.0103f, 82.30466f,355.7674f), "Liquor Hole West Vinewood", 0),
            new FubarVectors(2, new Vector4(-577.9646f, 249.1097f, 82.07367f,264.0999f), new Vector4(-577.0878f, 239.4642f, 82.63973f,352.4424f), "The Lust Resort", 0),
            new FubarVectors(2, new Vector4(-546.7243f, 199.937f, 74.84896f,176.7779f), new Vector4(-557.0035f, 199.6492f, 75.33001f,260.8677f), "The Lust Drop", 0),
            new FubarVectors(2, new Vector4(11.88346f, 177.0878f, 99.46635f,340.9445f), new Vector4(21.47109f, 174.1272f, 101.1136f,68.12672f), "Vinewood Museum", 0),
            new FubarVectors(2, new Vector4(-424.4175f, -23.76215f, 45.64375f,180.3581f), new Vector4(-430.567f, -24.43977f, 46.22874f,266.5289f), "Cockatoos Night Club", 0),
            new FubarVectors(2, new Vector4(-694.9179f, 39.87994f, 42.6233f,113.3858f), new Vector4(-698.6603f, 46.89344f, 44.03381f,211.1764f), "The Epsilon Grand Lodge", 0),
            new FubarVectors(2, new Vector4(-734.4417f, 5.077338f, 37.25613f,204.567f), new Vector4(-768.6093f, 14.3991f, 40.6468f,212.3584f), "Rockford Hills Chappel", 0),
            new FubarVectors(2, new Vector4(-941.0316f, 301.7534f, 70.31018f,91.59067f), new Vector4(-950.0242f, 321.4389f, 71.35194f,185.7915f), "Cottage Park", 0),
            new FubarVectors(2, new Vector4(-1380.725f, 55.11572f, 53.09065f,2.329019f), new Vector4(-1366.16f, 56.68597f, 54.09846f,98.07812f), "Los Santos Golf Club", 0),
            new FubarVectors(2, new Vector4(-1390.191f, -192.2963f, 46.25579f,32.33792f), new Vector4(-1369.941f, -176.3652f, 47.46554f,89.95979f), "Weazel Morningwood", 0),
            new FubarVectors(2, new Vector4(-1407.547f, -199.6018f, 46.43894f,218.887f), new Vector4(-1423.29f, -215.7507f, 46.5004f,359.5229f), "Tivoli Theater", 10),
            new FubarVectors(2, new Vector4(-1393.578f, -581.8541f, 29.5693f,299.5301f), new Vector4(-1388.438f, -587.0311f, 30.21894f,36.78379f), "Bahama Mamas West", 0),
            new FubarVectors(2, new Vector4(105.5498f, -807.4245f, 30.69767f,250.8654f), new Vector4(101.8338f, -819.0771f, 31.32337f,338.249f), "", 0),
            new FubarVectors(2, new Vector4(10.45672f, -972.2565f, 28.81958f,249.0387f), new Vector4(5.530529f, -986.1647f, 29.35737f,341.6119f), "Hookah Palace", 0),
            new FubarVectors(2, new Vector4(225.9878f, -854.5867f, 29.38589f,248.1305f), new Vector4(206.5f, -904.3871f, 30.98855f,278.3398f), "North Legion Square", 0),
            new FubarVectors(2, new Vector4(174.1386f, -1012.249f, 28.79522f,20.25295f), new Vector4(169.2887f, -973.4929f, 30.03575f,168.7917f), "South Legion Square", 0),
            new FubarVectors(2, new Vector4(-879.1643f, -1166.88f, 4.401611f,120.6704f), new Vector4(-882.5522f, -1155.937f, 5.170409f,208.5212f), "Liquor Hole Vespucci", 0),
            new FubarVectors(2, new Vector4(-1329.983f, -1093.397f, 6.333323f,115.7037f), new Vector4(-1340.38f, -1075.555f, 6.93902f,213.7292f), "Venetian", 0),
            new FubarVectors(2, new Vector4(351.0237f, -950.7453f, 29.40918f,115.7037f),new Vector4(345.5975f, -977.8932f, 29.38444f, 273.4947f), "Mission Row Nightclub", 305),
            new FubarVectors(2, new Vector4(395.7168f, 252.5639f, 102.9311f,115.7037f),new Vector4(371.5605f, 252.8112f, 103.0097f, 314.561f), "Downtown Vinewood Nightclub", 306),
            new FubarVectors(2, new Vector4(10.77269f, 214.7812f, 107.1411f,115.7037f),new Vector4(4.650625f, 220.1689f, 107.6984f, 245.6841f), "West Vinewood Nightclub", 307),
            new FubarVectors(2, new Vector4(-1178.25f, -1123.005f, 5.700791f,115.7037f),new Vector4(-1174.07f, -1153.289f, 5.658284f, 295.0855f), "Vespucci Canals Nightclub", 308),
            new FubarVectors(2, new Vector4(-1288.408f, -643.213f, 26.5635f,115.7037f),new Vector4(-1285.2f, -652.0067f, 26.63286f, 37.02723f), "Del Perro Nightclub", 309)
        };
        private static readonly List<FubarVectors> Area_02_Hotel = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(437.7907f, 221.3865f, 102.5827f,249.5652f), new Vector4(435.6819f, 214.9669f, 103.1661f,336.5261f), "Von Crastenburg Hotel Vinewood", 11),
            new FubarVectors(2, new Vector4(-56.13069f, 343.4792f, 111.5186f,155.9926f), new Vector4(-60.65593f, 360.4461f, 113.0564f,230.2873f), "Gentry Manor Hotel", 11),
            new FubarVectors(2, new Vector4(-312.0734f, 227.8943f, 87.25609f,288.1739f), new Vector4(-310.1121f, 221.7065f, 87.928f,10.32374f), "8398 West Vinewood", 11),
            new FubarVectors(2, new Vector4(-480.0637f, 224.1393f, 82.53575f,264.2929f), new Vector4(-476.8173f, 217.9437f, 83.70455f,352.4909f), "The Generic Hotel", 11),
            new FubarVectors(2, new Vector4(-74.77626f, 146.8481f, 80.76864f,302.7176f), new Vector4(-70.51574f, 142.0495f, 81.8622f,31.50013f), "Elgin House", 11),
            new FubarVectors(2, new Vector4(317.9163f, -86.3867f, 68.57369f,69.10757f), new Vector4(328.6383f, -69.454f, 73.03695f,162.9268f), "Vinewood Gardens Hotel", 11),
            new FubarVectors(2, new Vector4(402.5001f, -382.5633f, 46.16993f,116.8417f), new Vector4(381.2291f, -361.6271f, 46.81524f,260.3951f), "Elgin Ave", 11),
            new FubarVectors(2, new Vector4(-268.9729f, 27.03831f, 54.16841f,160.7473f), new Vector4(-273.8332f, 28.23296f, 54.75253f,260.437f), "Eclipse Lodge Apartments", 11),
            new FubarVectors(2, new Vector4(-1284.941f, 294.3028f, 64.27746f,57.83354f), new Vector4(-1273.948f, 315.731f, 65.5118f,160.5027f), "The Richman Hotel", 11),
            new FubarVectors(2, new Vector4(-1095.614f, -316.5215f, 37.07977f,263.9839f), new Vector4(-1095.161f, -325.5318f, 37.82365f,354.9847f), "The Archipelago Hotel", 11),
            new FubarVectors(2, new Vector4(-1228.636f, -182.6882f, 38.60246f,39.70615f), new Vector4(-1222.901f, -174.603f, 39.3252f,164.1033f), "Von Crastenburg Richman", 11),
            new FubarVectors(2, new Vector4(-571.3131f, -384.529f, 34.31267f,270.1787f), new Vector4(-570.3383f, -395.083f, 35.05662f,3.385895f), "Rockford Dorset", 11),
            new FubarVectors(2, new Vector4(-480.9139f, -388.0156f, 33.43898f,259.7604f), new Vector4(-480.9734f, -401.5962f, 34.5466f,358.0655f), "Weazel Dorset", 11),
            new FubarVectors(2, new Vector4(116.9196f, -937.354f, 29.12869f,159.7789f), new Vector4(104.9687f, -932.8539f, 29.81219f,251.5842f), "The Emissary", 11),
            new FubarVectors(2, new Vector4(10.45672f, -972.2565f, 28.81958f,249.0387f), new Vector4(5.530529f, -986.1647f, 29.35737f,341.6119f), "Hookah Palace", 11),
            new FubarVectors(2, new Vector4(273.9824f, -932.5346f, 28.49319f,337.4559f), new Vector4(285.8458f, -936.1149f, 29.46787f,137.5926f), "Elkridge Hotel", 11),
            new FubarVectors(2, new Vector4(312.6075f, -747.0664f, 28.60157f,159.2196f), new Vector4(308.2846f, -728.3017f, 29.31677f,242.059f), "Alesandro Hotel", 11),
        };
        private static readonly List<FubarVectors> Area_02_ORP01 = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(318.8127f, 496.3661f, 152.5035f,281.6071f), new Vector4(325.3149f, 513.2526f, 153.1802f,176.9303f), "", 51),
            new FubarVectors(2, new Vector4(215.3257f, 758.5961f, 204.4705f,54.70864f), new Vector4(228.7233f, 765.6225f, 204.9766f,60.57176f), "", 51),
            new FubarVectors(2, new Vector4(227.3211f, 680.8201f, 189.3211f,108.4066f), new Vector4(232.2005f, 672.3677f, 189.9457f,17.49693f), "", 51),
            new FubarVectors(2, new Vector4(64.58726f, 456.2051f, 146.6121f,38.19732f), new Vector4(57.70588f, 449.8846f, 147.0315f,330.7135f), "", 51),
            new FubarVectors(2, new Vector4(90.09676f, 486.9627f, 147.5335f,204.4576f), new Vector4(79.89433f, 486.2136f, 148.2015f,211.3625f), "", 51),
            new FubarVectors(2, new Vector4(113.6128f, 496.2102f, 146.943f,191.1292f), new Vector4(119.7328f, 494.3987f, 147.343f,96.75148f), "", 51),
            new FubarVectors(2, new Vector4(173.5254f, 482.3466f, 142.0656f,349.3443f), new Vector4(174.2039f, 466.5258f, 141.9075f,340.2406f), "", 51),
            new FubarVectors(2, new Vector4(-184.2236f, 420.0336f, 110.4789f,16.08652f), new Vector4(-176.1895f, 423.6454f, 111.2499f,112.1185f), "", 51),
            new FubarVectors(2, new Vector4(-202.1047f, 409.8227f, 110.3036f,16.04276f), new Vector4(-213.9507f, 399.727f, 111.3039f,16.8197f), "", 51),
            new FubarVectors(2, new Vector4(-353.7564f, 474.8524f, 112.5154f,285.6599f), new Vector4(-355.6916f, 458.2476f, 116.6474f,317.5224f), "", 51),
            new FubarVectors(2, new Vector4(-362.2122f, 514.9112f, 119.3604f,135.6201f), new Vector4(-348.6426f, 514.8634f, 120.6501f,132.31f), "", 51),
            new FubarVectors(2, new Vector4(-399.775f, 518.1522f, 120.145f,353.0008f), new Vector4(-386.6427f, 504.4515f, 120.4127f,336.3673f), "", 51),
            new FubarVectors(2, new Vector4(-408.2724f, 559.9554f, 124.1673f,154.2473f), new Vector4(-406.4761f, 567.3199f, 124.6036f,159.2473f), "", 51),
            new FubarVectors(2, new Vector4(-469.7041f, 541.201f, 120.8802f,356.8915f), new Vector4(-459.1455f, 537.1053f, 121.4599f,3.323273f), "", 51),
            new FubarVectors(2, new Vector4(-478.6201f, 597.3229f, 127.341f,92.0453f), new Vector4(-474.2755f, 586.0066f, 128.6839f,84.01727f), "", 51),
            new FubarVectors(2, new Vector4(-512.4046f, 577.1302f, 120.2451f,280.7281f), new Vector4(-520.4376f, 594.2043f, 120.8367f,271.7799f), "", 51),
            new FubarVectors(2, new Vector4(-543.3492f, 543.871f, 110.1703f,247.399f), new Vector4(-554.4238f, 541.1027f, 110.7071f,166.609f), "", 51),
            new FubarVectors(2, new Vector4(-525.6572f, 527.3201f, 111.9418f,45.30171f), new Vector4(-526.5902f, 517.1929f, 112.9406f,41.81937f), "", 51),
            new FubarVectors(2, new Vector4(-537.5423f, 485.6831f, 102.781f,53.94619f), new Vector4(-536.6965f, 477.2957f, 103.1936f,53.67907f), "", 51),
            new FubarVectors(2, new Vector4(-576.5366f, 400.8622f, 100.4606f,21.4386f), new Vector4(-561.1863f, 402.92f, 101.8053f,23.25938f), "", 51),
            new FubarVectors(2, new Vector4(-604.6118f, 397.7712f, 101.5185f,5.700022f), new Vector4(-595.7487f, 393.0933f, 101.8825f,5.97052f), "", 51),
            new FubarVectors(2, new Vector4(-520.4191f, 393.612f, 93.43296f,21.67514f), new Vector4(-500.6455f, 398.63f, 98.08712f,52.72701f), "", 51),
            new FubarVectors(2, new Vector4(-457.5839f, 393.2669f, 103.4656f,2.933417f), new Vector4(-451.1712f, 395.4468f, 104.7742f,85.61269f), "", 51),
            new FubarVectors(2, new Vector4(-392.0697f, 432.4407f, 111.9837f,246.8938f), new Vector4(-400.8264f, 427.5692f, 112.3414f,250.3701f), "", 51),
            new FubarVectors(2, new Vector4(-322.4262f, 431.2195f, 109.5666f,10.18072f), new Vector4(-305.0169f, 431.3801f, 110.4723f,12.44402f), "", 51),
            new FubarVectors(2, new Vector4(-305.3652f, 379.4485f, 110.1347f,16.26957f), new Vector4(-297.6968f, 380.0132f, 112.0954f,27.14002f), "", 51),
            new FubarVectors(2, new Vector4(-381.332f, 346.6836f, 108.9861f,7.034455f), new Vector4(-371.863f, 343.6674f, 109.9426f,5.457379f), "", 51),
            new FubarVectors(2, new Vector4(-404.2261f, 338.9417f, 108.5134f,0.3291996f), new Vector4(-409.3182f, 341.4418f, 108.9075f,269.5646f), "", 51),
            new FubarVectors(2, new Vector4(-473.7736f, 354.4996f, 103.6425f,334.2458f), new Vector4(-478.8647f, 352.0819f, 104.1457f,347.9644f), "", 51),
            new FubarVectors(2, new Vector4(-524.8502f, 645.942f, 137.9588f,326.1953f), new Vector4(-523.0588f, 628.2188f, 137.9739f,293.1599f), "", 51),
            new FubarVectors(2, new Vector4(-465.0109f, 643.8513f, 143.9835f,46.34229f), new Vector4(-476.7407f, 647.8394f, 144.3867f,15.64181f), "", 51),
            new FubarVectors(2, new Vector4(-395.1528f, 671.1686f, 162.8374f,359.6853f), new Vector4(-400.0963f, 664.945f, 163.8302f,359.3605f), "", 51),
            new FubarVectors(2, new Vector4(-344.9743f, 663.3989f, 169.2626f,171.1561f), new Vector4(-339.8586f, 669.1342f, 172.7843f,262.9623f), "", 51),
            new FubarVectors(2, new Vector4(-343.6224f, 634.3452f, 172.0965f,52.99996f), new Vector4(-339.922f, 625.514f, 171.3569f,56.90737f), "", 51),
            new FubarVectors(2, new Vector4(-302.5193f, 631.861f, 175.4442f,117.7551f), new Vector4(-299.0081f, 635.5462f, 175.6917f,111.2493f), "", 51),
            new FubarVectors(2, new Vector4(-274.5317f, 600.1389f, 181.5089f,356.5742f), new Vector4(-293.5075f, 600.8858f, 181.5756f,350.6989f), "", 51),
            new FubarVectors(2, new Vector4(-224.0718f, 592.1751f, 190.0356f,354.7806f), new Vector4(-232.5696f, 588.3168f, 190.5363f,350.4607f), "", 51),
            new FubarVectors(2, new Vector4(-197.6937f, 614.6669f, 196.7917f,182.0588f), new Vector4(-198.9457f, 636.6884f, 199.6429f,358.0923f), "", 51),
            new FubarVectors(2, new Vector4(-179.0646f, 592.517f, 197.4248f,356.2981f), new Vector4(-188.9543f, 591.7107f, 197.8231f,270.9746f), "", 51),
            new FubarVectors(2, new Vector4(-144.5513f, 595.9666f, 203.5569f,18.34551f), new Vector4(-126.5195f, 588.4652f, 204.7106f,355.9948f), "", 51),
            new FubarVectors(2, new Vector4(-494.8479f, 744.3373f, 162.7411f,248.4828f), new Vector4(-495.6496f, 738.6761f, 163.0311f,333.3955f), "", 51),
            new FubarVectors(2, new Vector4(-660.9177f, 807.1927f, 198.9049f,358.1064f), new Vector4(-655.1315f, 803.2078f, 198.9912f,358.0805f), "", 51),
            new FubarVectors(2, new Vector4(-595.5434f, 806.5671f, 190.1349f,150.7332f), new Vector4(-587.2784f, 806.5978f, 191.2476f,143.8838f), "", 51),
            new FubarVectors(2, new Vector4(-579.5834f, 740.6581f, 183.4856f,137.3068f), new Vector4(-579.5991f, 732.8576f, 184.2119f,12.34716f), "", 51),
            new FubarVectors(2, new Vector4(-670.3287f, 752.3672f, 173.657f,358.9892f), new Vector4(-646.1149f, 740.5093f, 174.2768f,29.26677f), "", 51),
            new FubarVectors(2, new Vector4(-614.6937f, 678.5223f, 149.3577f,350.7242f), new Vector4(-606.1802f, 672.3806f, 151.5968f,348.5289f), "", 51),
            new FubarVectors(2, new Vector4(-559.8077f, 685.6489f, 145.0379f,163.5413f), new Vector4(-551.9026f, 686.8129f, 146.0746f,160.0818f), "", 51),
            new FubarVectors(2, new Vector4(-711.7605f, 656.2303f, 154.8006f,347.2955f), new Vector4(-700.8209f, 647.2943f, 155.1797f,343.4536f), "", 51),
            new FubarVectors(2, new Vector4(-667.9805f, 670.0135f, 150.0492f,78.2793f), new Vector4(-661.8883f, 678.765f, 153.9105f,91.90803f), "", 51),
            new FubarVectors(2, new Vector4(-766.6292f, 665.9629f, 144.3472f,295.9562f), new Vector4(-765.5724f, 650.708f, 145.7009f,310.9063f), "", 51),
            new FubarVectors(2, new Vector4(-806.8042f, 705.327f, 146.6031f,19.24083f), new Vector4(-819.4746f, 696.8098f, 148.1098f,20.49006f), "", 51),
            new FubarVectors(2, new Vector4(-950.4979f, 688.0117f, 153.2586f,1.711245f), new Vector4(-931.5179f, 691.3855f, 153.4668f,0.1517567f), "", 51),
            new FubarVectors(2, new Vector4(-1022.999f, 694.4565f, 161.0156f,356.0608f), new Vector4(-1033.217f, 685.9224f, 161.3029f,82.47516f), "", 51),
            new FubarVectors(2, new Vector4(-1057.742f, 736.4571f, 165.0407f,295.9679f), new Vector4(-1065.144f, 726.8954f, 165.4747f,21.02359f), "", 51),
            new FubarVectors(2, new Vector4(-1052.495f, 768.1278f, 166.8871f,274.8205f), new Vector4(-1056.151f, 761.4487f, 167.3164f,267.1714f), "", 51),
            new FubarVectors(2, new Vector4(-812.8171f, 807.8094f, 201.3971f,18.17716f), new Vector4(-824.1274f, 806.2383f, 202.7845f,16.62208f), "", 51),
            new FubarVectors(2, new Vector4(-851.7211f, 792.0988f, 191.1466f,6.379981f), new Vector4(-867.3304f, 784.9983f, 191.9343f,2.053166f), "", 51),
            new FubarVectors(2, new Vector4(-905.2603f, 783.0583f, 185.3374f,10.43882f), new Vector4(-912.2769f, 777.4453f, 187.0112f,7.442374f), "", 51),
            new FubarVectors(2, new Vector4(-918.7078f, 806.9541f, 183.6067f,185.8774f), new Vector4(-921.1113f, 813.6768f, 184.3361f,194.3121f), "", 51),
            new FubarVectors(2, new Vector4(-955.9373f, 800.6656f, 177.1945f,184.6668f), new Vector4(-962.6827f, 813.8876f, 177.5658f,184.572f), "", 51),
            new FubarVectors(2, new Vector4(-970.3416f, 766.3366f, 174.4704f,46.66233f), new Vector4(-972.2784f, 752.2701f, 176.3808f,38.5029f), "", 51),
            new FubarVectors(2, new Vector4(-1000.281f, 785.6187f, 170.9521f,289.1853f), new Vector4(-998.4088f, 768.6085f, 171.5826f,295.0405f), "", 51),
            new FubarVectors(2, new Vector4(-1024.018f, 812.2822f, 171.3941f,185.676f), new Vector4(-1013.067f, 818.3909f, 172.3797f,135.8375f), "", 51),
            new FubarVectors(2, new Vector4(-1121.198f, 788.3663f, 162.3206f,232.7807f), new Vector4(-1130.642f, 784.4011f, 163.8875f,232.461f), "", 51),
            new FubarVectors(2, new Vector4(-1116.805f, 769.6484f, 162.7472f,27.5284f), new Vector4(-1117.804f, 761.6957f, 164.2888f,25.97767f), "", 51),
            new FubarVectors(2, new Vector4(-1160.398f, 741.2746f, 154.8455f,46.88651f), new Vector4(-1165.583f, 727.0689f, 155.6068f,332.7302f), "", 51),
            new FubarVectors(2, new Vector4(-1249.97f, 664.7272f, 142.2922f,216.816f), new Vector4(-1241.33f, 674.0937f, 142.8134f,174.5139f), "", 51),
            new FubarVectors(2, new Vector4(-1283.548f, 649.0323f, 139.2707f,195.7354f), new Vector4(-1291.867f, 650.233f, 141.5015f,195.6528f), "", 51),
            new FubarVectors(2, new Vector4(-1289.159f, 626.0635f, 138.1995f,42.20447f), new Vector4(-1277.768f, 629.8492f, 143.1888f,128.5902f), "", 51),
            new FubarVectors(2, new Vector4(-1346.258f, 610.5354f, 133.3745f,98.08596f), new Vector4(-1337.636f, 606.1381f, 134.3799f,85.66702f), "", 51),
            new FubarVectors(2, new Vector4(-1357.674f, 578.7719f, 130.9355f,248.7664f), new Vector4(-1364.308f, 570.2775f, 134.9729f,240.3346f), "", 51),
            new FubarVectors(2, new Vector4(-1452.525f, 534.3056f, 118.7793f,257.9918f), new Vector4(-1452.805f, 545.5567f, 120.7994f,259.8272f), "", 51),
            new FubarVectors(2, new Vector4(-1482.342f, 530.4329f, 117.7977f,213.1592f), new Vector4(-1500.594f, 522.8561f, 118.2721f,207.9011f), "", 51),
            new FubarVectors(2, new Vector4(-1471.884f, 514.642f, 117.5872f,15.8216f), new Vector4(-1453.886f, 512.446f, 117.7964f,70.62026f), "", 51),
            new FubarVectors(2, new Vector4(-1504.848f, 425.8355f, 110.832f,41.97743f), new Vector4(-1496.01f, 437.0359f, 112.4979f,53.20035f), "", 51),
            new FubarVectors(2, new Vector4(-1541.578f, 429.3669f, 109.0081f,271.6294f), new Vector4(-1540.04f, 420.9024f, 110.014f,1.374532f), "", 51),
            new FubarVectors(2, new Vector4(-1418.02f, 468.6653f, 108.8807f,345.707f), new Vector4(-1413.387f, 462.6624f, 109.2085f,334.4767f), "", 51),
            new FubarVectors(2, new Vector4(-1376.452f, 452.9557f, 104.6378f,82.44392f), new Vector4(-1371.408f, 444.057f, 105.8572f,82.7045f), "", 51),
            new FubarVectors(2, new Vector4(-1272.138f, 452.7144f, 94.775f,32.07218f), new Vector4(-1263.355f, 455.0761f, 94.77367f,41.70851f), "", 51),
            new FubarVectors(2, new Vector4(-1179.269f, 456.428f, 86.40733f,82.7791f), new Vector4(-1174.776f, 440.2753f, 86.84985f,83.48888f), "", 51),
            new FubarVectors(2, new Vector4(-1111.094f, 477.6239f, 81.88736f,170.295f), new Vector4(-1122.536f, 486.1293f, 82.35567f,171.3635f), "", 51),
            new FubarVectors(2, new Vector4(-1078.805f, 462.1515f, 77.29704f,147.5997f), new Vector4(-1087.607f, 479.4379f, 81.32063f,58.70352f), "", 51),
            new FubarVectors(2, new Vector4(-1092.437f, 438.9475f, 75.01263f,261.8433f), new Vector4(-1094.531f, 427.3982f, 75.88006f,263.4119f), "", 51),
            new FubarVectors(2, new Vector4(-1040.038f, 495.8495f, 82.34982f,233.2739f), new Vector4(-1059.639f, 515.5388f, 84.38102f,53.55426f), "", 51),
            new FubarVectors(2, new Vector4(-1012.415f, 489.8326f, 79.03043f,4.231028f), new Vector4(-1009.264f, 479.5622f, 79.4146f,327.7209f), "", 51),
            new FubarVectors(2, new Vector4(-993.8633f, 495.3938f, 81.06633f,354.9972f), new Vector4(-987.258f, 487.3222f, 82.46126f,13.29768f), "", 51),
            new FubarVectors(2, new Vector4(-976.9498f, 517.1743f, 81.19785f,143.4696f), new Vector4(-967.3892f, 510.278f, 82.06638f,153.4967f), "", 51),
            new FubarVectors(2, new Vector4(-1097.503f, 361.4458f, 68.29243f,356.7833f), new Vector4(-1130.32f, 361.0236f, 71.71848f,56.60651f), "", 51),
            new FubarVectors(2, new Vector4(-1051.329f, 316.0146f, 66.14833f,296.2429f), new Vector4(-1038.475f, 312.1982f, 67.27436f,19.25218f), "", 51),
            new FubarVectors(2, new Vector4(-1015.469f, 357.717f, 70.04961f,157.7254f), new Vector4(-1025.812f, 360.4001f, 71.36146f,252.449f), "", 51),
            new FubarVectors(2, new Vector4(-845.9332f, 460.2166f, 87.08342f,99.5103f), new Vector4(-842.9318f, 466.8084f, 87.59698f,102.3203f), "", 51),
            new FubarVectors(2, new Vector4(-871.2172f, 499.3638f, 89.37999f,283.7275f), new Vector4(-883.9303f, 518.0816f, 92.44287f,285.0275f), "", 51),
            new FubarVectors(2, new Vector4(-846.2355f, 514.9747f, 90.41426f,108.4869f), new Vector4(-848.6625f, 508.8511f, 90.81708f,10.45732f), "", 51),
            new FubarVectors(2, new Vector4(-909.2509f, 554.6064f, 96.15231f,315.8858f), new Vector4(-907.5173f, 545.0802f, 100.205f,313.1519f), "", 51),
            new FubarVectors(2, new Vector4(-916.2592f, 585.7996f, 100.4603f,152.0125f), new Vector4(-904.6435f, 587.8419f, 101.1908f,150.728f), "", 51),
            new FubarVectors(2, new Vector4(-951.5414f, 575.9009f, 100.8275f,341.1044f), new Vector4(-947.8389f, 567.7078f, 101.5077f,355.4088f), "", 51),
            new FubarVectors(2, new Vector4(-1095.902f, 598.5202f, 102.8574f,211.4888f), new Vector4(-1107.479f, 594.1757f, 104.4547f,213.5989f), "", 51),
            new FubarVectors(2, new Vector4(-1106.987f, 552.2368f, 102.3779f,29.54501f), new Vector4(-1090.422f, 548.3315f, 103.6333f,120.3299f), "", 51),
            new FubarVectors(2, new Vector4(-1209.008f, 557.5132f, 99.15355f,183.7141f), new Vector4(-1193.096f, 563.8548f, 100.3394f,182.2157f), "", 51),
            new FubarVectors(2, new Vector4(-1270.597f, 503.7831f, 97.02524f,179.3631f), new Vector4(-1277.653f, 497.0977f, 97.89041f,264.6013f), "", 51),
            new FubarVectors(2, new Vector4(-1236.806f, 486.4729f, 92.98049f,131.1081f), new Vector4(-1217.873f, 506.0433f, 95.66708f,180.517f), "", 51),
            new FubarVectors(2, new Vector4(-754.9761f, 441.7753f, 99.65048f,21.17248f), new Vector4(-762.2422f, 431.1789f, 100.1969f,19.54113f), "", 51),
            new FubarVectors(2, new Vector4(-766.1439f, 465.4737f, 99.84455f,214.9303f), new Vector4(-784.4272f, 459.1835f, 100.1791f,208.3917f), "", 51),
            new FubarVectors(2, new Vector4(-733.9666f, 446.2859f, 106.2041f,26.20407f), new Vector4(-717.9078f, 448.933f, 106.9092f,28.30388f), "", 51),
            new FubarVectors(2, new Vector4(-716.2523f, 494.0204f, 108.8374f,207.0717f), new Vector4(-721.3455f, 490.2122f, 109.3857f,210.3048f), "", 51),
            new FubarVectors(2, new Vector4(-687.3202f, 502.5805f, 109.6894f,199.9449f), new Vector4(-679.076f, 511.9479f, 113.526f,191.8366f), "", 51),
            new FubarVectors(2, new Vector4(-587.2115f, 529.0335f, 107.4421f,210.9947f), new Vector4(-586.7624f, 541.3615f, 110.3284f,276.6161f), "", 51),
            new FubarVectors(2, new Vector4(-575.4766f, 498.0202f, 105.8446f,11.15088f), new Vector4(-580.5882f, 492.2771f, 108.903f,8.991305f), "", 51),
            new FubarVectors(2, new Vector4(-826.2047f, 272.0132f, 85.87145f,351.0056f), new Vector4(-819.5183f, 267.857f, 86.39596f,71.20386f), "", 51),
            new FubarVectors(2, new Vector4(-869.1068f, 319.3342f, 83.29476f,186.0734f), new Vector4(-876.8299f, 306.3361f, 84.1543f,238.1838f), "", 51),
            new FubarVectors(2, new Vector4(-888.3319f, 364.8171f, 84.34824f,4.419883f), new Vector4(-881.5927f, 363.7405f, 85.3627f,57.2331f), "", 51),
            new FubarVectors(2, new Vector4(-978.6483f, -1200.687f, 4.028273f,300.2132f), new Vector4(-986.5679f, -1199.396f, 6.047775f,296.0049f), "", 51),
            new FubarVectors(2, new Vector4(-1036.361f, -1237.672f, 5.286499f,209.2803f), new Vector4(-1035.77f, -1228.016f, 6.346429f,113.4062f), "", 51),
            new FubarVectors(2, new Vector4(-1036.636f, -1599.48f, 4.240905f,37.49187f), new Vector4(-1037.267f, -1605.186f, 4.973884f,28.55429f), "", 51),
            new FubarVectors(2, new Vector4(-1044.919f, -1605.405f, 4.214279f,37.13557f), new Vector4(-1038.781f, -1610.055f, 4.996139f,309.5647f), "", 51),
            new FubarVectors(2, new Vector4(-1054.096f, -1594.601f, 3.974956f,215.3273f), new Vector4(-1056.945f, -1587.358f, 4.611769f,211.1144f), "", 51),
            new FubarVectors(2, new Vector4(-1064.465f, -1566.796f, 3.925897f,215.2828f), new Vector4(-1072.934f, -1561.893f, 4.692028f,116.2765f), "", 51),
            new FubarVectors(2, new Vector4(-1044.395f, -1571.362f, 4.338543f,34.36719f), new Vector4(-1043.264f, -1580.302f, 5.041376f,34.41164f), "", 51),
            new FubarVectors(2, new Vector4(-1037.087f, -1568.339f, 4.446574f,35.08035f), new Vector4(-1032.227f, -1582.888f, 5.13635f,128.5182f), "", 51),
            new FubarVectors(2, new Vector4(-1101.508f, -1497.694f, 4.160627f,216.5465f), new Vector4(-1102.456f, -1491.978f, 4.88708f,214.353f), "", 51),
            new FubarVectors(2, new Vector4(-1109.988f, -1504.075f, 3.984198f,211.9197f), new Vector4(-1111.039f, -1498.035f, 4.672972f,218.438f), "", 51),
            new FubarVectors(2, new Vector4(-1090.554f, -1631.604f, 4.080342f,126.4985f), new Vector4(-1082.602f, -1631.274f, 4.739912f,118.3442f), "", 51),
            new FubarVectors(2, new Vector4(-1081.945f, -1670.237f, 4.053997f,305.3939f), new Vector4(-1088.434f, -1672.304f, 4.699928f,297.9261f), "", 51),
            new FubarVectors(2, new Vector4(-1108.007f, -1228.391f, 1.936681f,119.0822f), new Vector4(-1103.736f, -1222.148f, 2.567274f,21.86139f), "", 51),
            new FubarVectors(2, new Vector4(-1133.214f, -1173.517f, 1.706819f,115.3653f), new Vector4(-1125.815f, -1171.82f, 2.355613f,108.8428f), "", 51),
            new FubarVectors(2, new Vector4(-1144.045f, -1153.354f, 2.160536f,121.8484f), new Vector4(-1135.558f, -1153.264f, 2.744727f,118.6349f), "", 51),
            new FubarVectors(2, new Vector4(-1149.098f, -1145.813f, 2.183599f,122.6256f), new Vector4(-1142.575f, -1144.144f, 2.848527f,115.1439f), "", 51),
            new FubarVectors(2, new Vector4(-1158.401f, -1126.026f, 1.755121f,122.3532f), new Vector4(-1143.73f, -1122.083f, 2.5961f,218.3322f), "", 51),
            new FubarVectors(2, new Vector4(-1189.225f, -1065.824f, 1.499536f,119.5338f), new Vector4(-1182.946f, -1064.361f, 2.150416f,117.8702f), "", 51),
            new FubarVectors(2, new Vector4(-1185.759f, -928.7217f, 2.090576f,209.7034f), new Vector4(-1179.527f, -929.2076f, 6.992926f,119.2376f), "", 51),
            new FubarVectors(2, new Vector4(-1185.571f, -948.7433f, 3.358301f,212.7497f), new Vector4(-1203.022f, -944.9437f, 8.114871f,134.0965f), "", 51),
            new FubarVectors(2, new Vector4(-1035.348f, -899.8041f, 3.612249f,29.06924f), new Vector4(-1031.14f, -902.8995f, 3.695777f,34.97942f), "", 51),
            new FubarVectors(2, new Vector4(-1022.112f, -890.0821f, 5.06163f,33.67837f), new Vector4(-1022.584f, -896.729f, 5.415418f,42.78962f), "", 51),
            new FubarVectors(2, new Vector4(-949.3619f, -899.3148f, 1.512146f,297.1637f), new Vector4(-950.8911f, -905.6533f, 2.759314f,294.0639f), "", 51),
            new FubarVectors(2, new Vector4(-938.354f, -927.7917f, 1.49428f,301.4236f), new Vector4(-947.825f, -928.0125f, 2.145313f,293.5189f), "", 51),
            new FubarVectors(2, new Vector4(-921.298f, -951.6708f, 1.51206f,299.7054f), new Vector4(-927.3926f, -949.5184f, 2.745368f,294.5931f), "", 51),
            new FubarVectors(2, new Vector4(-891.5771f, -1006.704f, 1.49878f,300.0399f), new Vector4(-892.8921f, -996.0531f, 2.24341f,303.004f), "", 51),
            new FubarVectors(2, new Vector4(-873.7162f, -1073.753f, 1.506729f,301.2325f), new Vector4(-884.2474f, -1072.572f, 2.525175f,34.02031f), "", 51),
            new FubarVectors(2, new Vector4(-864.4176f, -1090.45f, 1.511336f,299.6432f), new Vector4(-869.2363f, -1103.792f, 6.445571f,232.039f), "", 51),
            new FubarVectors(2, new Vector4(-948.1478f, -1095.93f, 1.499038f,30.76507f), new Vector4(-948.6233f, -1107.861f, 2.171846f,115.5819f), "", 51),
            new FubarVectors(2, new Vector4(-959.6019f, -1100.887f, 1.499249f,29.21922f), new Vector4(-959.7524f, -1109.692f, 2.150312f,20.53431f), "", 51),
            new FubarVectors(2, new Vector4(-1046.119f, -1151.479f, 1.507566f,32.19191f), new Vector4(-1045.882f, -1159.871f, 2.158599f,23.60791f), "", 51),
            new FubarVectors(2, new Vector4(-1064.915f, -1144.697f, 1.507192f,211.8922f), new Vector4(-1054.156f, -1143.676f, 2.158597f,216.1087f), "", 51),
            new FubarVectors(2, new Vector4(-1109.217f, -1049.216f, 1.498985f,209.683f), new Vector4(-1108.842f, -1040.977f, 2.150357f,202.6895f), "", 51),
            new FubarVectors(2, new Vector4(-1121.071f, -1053.575f, 1.499126f,211.4961f), new Vector4(-1122.203f, -1046.216f, 2.150357f,204.523f), "", 51),
            new FubarVectors(2, new Vector4(-1021.386f, -1015.118f, 1.498902f,31.22802f), new Vector4(-1022.295f, -1022.968f, 2.15036f,27.09616f), "", 51),
            new FubarVectors(2, new Vector4(-1009.645f, -1007.466f, 1.499278f,30.70059f), new Vector4(-1008.455f, -1015.352f, 2.150309f,18.27499f), "", 51),
            new FubarVectors(2, new Vector4(230.2194f, -160.4216f, 58.10718f,247.3503f), new Vector4(224.9709f, -160.9504f, 59.06062f,248.4403f), "", 51),
            new FubarVectors(2, new Vector4(238.0489f, -140.7968f, 63.11253f,247.6174f), new Vector4(231.0122f, -131.2872f, 63.76349f,345.2468f), "", 51),
            new FubarVectors(2, new Vector4(215.0969f, -85.35986f, 68.5939f,340.3171f), new Vector4(206.5384f, -85.87484f, 69.38208f,342.0331f), "", 51),
            new FubarVectors(2, new Vector4(196.1434f, -123.9325f, 62.84327f,69.58694f), new Vector4(202.1811f, -133.0024f, 63.49434f,158.0101f), "", 51),
            new FubarVectors(2, new Vector4(162.8428f, -111.4885f, 61.64407f,250.4696f), new Vector4(156.2838f, -117.0666f, 62.59745f,254.2728f), "", 51),
            new FubarVectors(2, new Vector4(132.2793f, -63.67412f, 67.02013f,73.82039f), new Vector4(137.0904f, -72.14262f, 68.06479f,148.126f), "", 51),
            new FubarVectors(2, new Vector4(118.5604f, -101.6884f, 60.06484f,72.65191f), new Vector4(127.1309f, -107.7606f, 60.7161f,155.2583f), "", 51),
            new FubarVectors(2, new Vector4(72.84455f, -101.6542f, 57.5042f,252.4982f), new Vector4(67.63523f, -103.6553f, 58.44378f,258.0023f), "", 51),
            new FubarVectors(2, new Vector4(83.47623f, -80.62891f, 61.6936f,256.6328f), new Vector4(76.42636f, -86.64355f, 62.81653f,255.5934f), "", 51),
            new FubarVectors(2, new Vector4(37.82995f, -62.58858f, 62.83085f,74.46173f), new Vector4(38.40622f, -71.52248f, 63.73074f,71.26472f), "", 51),
            new FubarVectors(2, new Vector4(1.24029f, -68.6165f, 60.61922f,254.8609f), new Vector4(-6.399803f, -74.44074f, 61.67424f,250.2828f), "", 51),
            new FubarVectors(2, new Vector4(15.70354f, -8.1376f, 69.46462f,340.8037f), new Vector4(17.69664f, -13.67813f, 70.11626f,352.4458f), "", 51),
            new FubarVectors(2, new Vector4(10.67354f, -6.838574f, 69.46469f,341.3873f), new Vector4(5.95322f, -9.303666f, 70.11619f,337.8993f), "", 51),
            new FubarVectors(2, new Vector4(-1045.552f, 221.6632f, 63.45662f,178.3034f), new Vector4(-1038.421f, 222.0945f, 64.37576f,101.7399f), "", 51),
            new FubarVectors(2, new Vector4(-929.1015f, 211.0671f, 67.04869f,160.508f), new Vector4(-940.0865f, 202.5357f, 67.85973f,265.7908f), "", 51),
            new FubarVectors(2, new Vector4(-912.4919f, 191.0148f, 69.02045f,175.5768f), new Vector4(-902.3611f, 191.5495f, 69.44602f,103.8158f), "", 51),
            new FubarVectors(2, new Vector4(-993.4126f, 143.9969f, 60.24857f,291.2359f), new Vector4(-998.2958f, 157.7819f, 62.31877f,203.2687f), "", 51),
            new FubarVectors(2, new Vector4(-961.9285f, 110.4381f, 55.89871f,302.7112f), new Vector4(-971.5331f, 122.0743f, 57.04857f,302.1059f), "", 51),
            new FubarVectors(2, new Vector4(-917.6478f, 111.73f, 54.89901f,173.1191f), new Vector4(-913.7607f, 108.373f, 55.51467f,77.4723f), "", 51),
            new FubarVectors(2, new Vector4(-839.1078f, 116.3889f, 54.98486f,184.1754f), new Vector4(-830.5832f, 115.2545f, 56.01638f,92.8595f), "", 51),
            new FubarVectors(2, new Vector4(-874.3297f, -51.5565f, 37.8f,295.6655f), new Vector4(-862.5923f, -33.26305f, 40.55947f,90.03361f), "", 51),
            new FubarVectors(2, new Vector4(-887.561f, -14.49451f, 42.69457f,300.4996f), new Vector4(-896.0683f, -4.812224f, 43.79892f,300.6788f), "", 51),
            new FubarVectors(2, new Vector4(-928.6014f, 15.05872f, 47.3377f,302.9328f), new Vector4(-929.8884f, 19.34689f, 48.32583f,214.9419f), "", 51),
            new FubarVectors(2, new Vector4(-1531.366f, 83.56633f, 56.30471f,316.3572f), new Vector4(-1535.95f, 97.68037f, 56.77564f,225.0239f), "", 51),
            new FubarVectors(2, new Vector4(-1491.08f, 21.53012f, 54.30249f,7.461652f), new Vector4(-1482.41f, 33.45013f, 54.73831f,67.48167f), "", 51),
            new FubarVectors(2, new Vector4(-1505.229f, 26.07533f, 55.68369f,0.5788527f), new Vector4(-1515.509f, 23.86928f, 56.82068f,345.3811f), "", 51),
            new FubarVectors(2, new Vector4(-1568.126f, 33.21057f, 58.68525f,75.32178f), new Vector4(-1570.556f, 22.58729f, 59.55393f,349.9645f), "", 51),
            new FubarVectors(2, new Vector4(-1612.722f, 25.84081f, 61.66789f,334.1264f), new Vector4(-1621.656f, 15.58023f, 62.54132f,338.0487f), "", 51),
            new FubarVectors(2, new Vector4(-1460.498f, -24.12371f, 54.22675f,47.59397f), new Vector4(-1464.954f, -34.40237f, 55.05045f,314.3598f), "", 51),
            new FubarVectors(2, new Vector4(-1573.916f, -59.76668f, 56.07469f,268.2455f), new Vector4(-1580.114f, -34.0481f, 57.5652f,266.531f), "", 51),
            new FubarVectors(2, new Vector4(-1562.867f, -86.90454f, 53.71671f,270.8474f), new Vector4(-1549.388f, -90.47054f, 54.92917f,5.372835f), "", 51),
            new FubarVectors(2, new Vector4(-1613.838f, -375.9868f, 42.95982f,225.3058f), new Vector4(-1622.614f, -379.8445f, 43.71574f,238.272f), "", 51),
            new FubarVectors(2, new Vector4(-1671.823f, -451.071f, 38.95443f,231.6969f), new Vector4(-1667.287f, -441.3857f, 40.3559f,223.16f), "", 51)
        };
        private static readonly List<FubarVectors> Area_02_Houses01 = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(333.21f, 475.0218f, 149.3529f,17.91355f), new Vector4(330.9852f, 465.8818f, 151.1841f,18.48944f), "", 51),
            new FubarVectors(2, new Vector4(315.8819f, 568.8044f, 153.7062f,38.93952f), new Vector4(318.2583f, 561.3439f, 154.6998f,20.40084f), "", 51),
            new FubarVectors(2, new Vector4(210.7023f, 620.6797f, 186.6594f,166.3902f), new Vector4(215.9742f, 620.532f, 187.6359f,73.53351f), "", 51),
            new FubarVectors(2, new Vector4(136.954f, 570.8902f, 182.8862f,91.19203f), new Vector4(150.3908f, 556.1036f, 183.7373f,119.2867f), "", 51),
            new FubarVectors(2, new Vector4(84.17553f, 569.2305f, 181.2376f,96.75426f), new Vector4(85.03445f, 561.9106f, 182.7731f,349.6458f), "", 51),
            new FubarVectors(2, new Vector4(25.34656f, 561.1235f, 177.6116f,113.4024f), new Vector4(45.88586f, 556.3442f, 180.0821f,21.73727f), "", 51),
            new FubarVectors(2, new Vector4(-108.1838f, 511.6396f, 142.7652f,258.6363f), new Vector4(-109.7326f, 502.2904f, 143.4779f,350.2635f), "", 51),
            new FubarVectors(2, new Vector4(-2.826291f, 472.2153f, 145.0461f,241.1859f), new Vector4(-7.722396f, 468.1208f, 145.8608f,325.2842f), "", 51),
            new FubarVectors(2, new Vector4(56.80629f, 465.9229f, 145.9901f,280.3399f), new Vector4(43.04835f, 468.678f, 148.0961f,181.0549f), "", 51),
            new FubarVectors(2, new Vector4(103.3493f, 479.0822f, 146.626f,288.9661f), new Vector4(106.781f, 467.1621f, 147.5605f,12.13363f), "", 51),
            new FubarVectors(2, new Vector4(220.6206f, 517.153f, 139.9833f,314.2072f), new Vector4(223.7048f, 513.811f, 140.767f,36.60655f), "", 51),
            new FubarVectors(2, new Vector4(68.87734f, 354.0555f, 112.6359f,148.6138f), new Vector4(40.16223f, 361.5115f, 116.041f,223.3171f), "", 51),
            new FubarVectors(2, new Vector4(16.48174f, 373.6613f, 111.5355f,53.22336f), new Vector4(-2.9235f, 397.9823f, 120.2925f,164.4525f), "", 51),
            new FubarVectors(2, new Vector4(-89.16286f, 423.0596f, 112.4214f,74.55498f), new Vector4(-73.31962f, 427.9318f, 113.0384f,158.8892f), "", 51),
            new FubarVectors(2, new Vector4(-445.8837f, 347.8948f, 103.9109f,278.3493f), new Vector4(-444.0325f, 343.5373f, 105.4972f,10.05623f), "", 51),
            new FubarVectors(2, new Vector4(-480.5319f, 549.8745f, 119.0322f,54.97802f), new Vector4(-500.4679f, 552.1115f, 120.5974f,336.5637f), "", 51),
            new FubarVectors(2, new Vector4(-441.9384f, 678.6889f, 151.7719f,116.2337f), new Vector4(-446.0141f, 685.8065f, 152.9558f,204.32f), "", 51),
            new FubarVectors(2, new Vector4(-241.6235f, 609.7061f, 186.6028f,212.3476f), new Vector4(-246.0328f, 621.3793f, 187.8103f,168.6382f), "", 51),
            new FubarVectors(2, new Vector4(-528.9923f, 701.9674f, 149.3835f,319.8007f), new Vector4(-532.8951f, 708.985f, 153.0369f,188.0077f), "", 51),
            new FubarVectors(2, new Vector4(-656.4206f, 903.9967f, 227.6667f,224.3937f), new Vector4(-658.7515f, 886.9637f, 229.2491f,15.18912f), "", 51),
            new FubarVectors(2, new Vector4(-746.7818f, 818.573f, 212.6537f,209.7732f), new Vector4(-747.2447f, 808.563f, 215.0303f,299.424f), "", 51),
            new FubarVectors(2, new Vector4(-589.4935f, 784.3679f, 187.7567f,278.2995f), new Vector4(-595.6224f, 780.9205f, 189.1105f,299.1235f), "", 51),
            new FubarVectors(2, new Vector4(-571.7066f, 763.3165f, 184.4617f,149.7966f), new Vector4(-566.4037f, 761.4697f, 185.4251f,49.24176f), "", 51),
            new FubarVectors(2, new Vector4(-581.4211f, 739.3374f, 182.8478f,108.391f), new Vector4(-579.78f, 733.0131f, 184.2121f,21.21325f), "", 51),
            new FubarVectors(2, new Vector4(-697.6797f, 709.2975f, 156.8156f,209.5788f), new Vector4(-708.7479f, 712.7052f, 162.2097f,270.4941f), "", 51),
            new FubarVectors(2, new Vector4(-629.6689f, 403.0194f, 100.4075f,279.1324f), new Vector4(-615.3179f, 398.5812f, 101.6268f,12.6454f), "", 51),
            new FubarVectors(2, new Vector4(-874.0812f, 539.3687f, 90.97028f,33.49527f), new Vector4(-873.5142f, 562.5955f, 96.61948f,128.1732f), "", 51),
            new FubarVectors(2, new Vector4(-928.1637f, 569.8798f, 98.63083f,57.09971f), new Vector4(-924.9971f, 561.6308f, 99.99965f,340.3492f), "", 51),
            new FubarVectors(2, new Vector4(-973.307f, 589.402f, 101.1317f,73.52359f), new Vector4(-974.2305f, 582.2309f, 102.759f,357.4712f), "", 51),
            new FubarVectors(2, new Vector4(-1021.565f, 594.9155f, 102.3203f,89.08907f), new Vector4(-1022.412f, 587.2204f, 103.2379f,348.2807f), "", 51),
            new FubarVectors(2, new Vector4(-1127.964f, 557.4341f, 101.4438f,112.589f), new Vector4(-1125.434f, 549.25f, 102.4227f,8.776328f), "", 51),
            new FubarVectors(2, new Vector4(-1147.232f, 551.2745f, 100.7653f,104.0749f), new Vector4(-1146.507f, 546.1739f, 101.5241f,5.572636f), "", 51),
            new FubarVectors(2, new Vector4(-1412.32f, 557.7536f, 123.3118f,279.6368f), new Vector4(-1405.055f, 561.7512f, 125.4062f,167.8474f), "", 51),
            new FubarVectors(2, new Vector4(-1244.73f, 651.9126f, 140.9338f,121.2099f), new Vector4(-1248.332f, 643.2799f, 142.6663f,302.1881f), "", 51),
            new FubarVectors(2, new Vector4(-1221.676f, 668.2861f, 143.3379f,314.3269f), new Vector4(-1219.192f, 665.8387f, 144.5303f,40.60362f), "", 51),
            new FubarVectors(2, new Vector4(-1200.595f, 693.2079f, 146.5084f,334.5356f), new Vector4(-1197.073f, 693.4171f, 147.4216f,59.0859f), "", 51),
            new FubarVectors(2, new Vector4(-987.7911f, 694.1574f, 157.1548f,276.4099f), new Vector4(-974.2622f, 684.7675f, 158.0345f,350.9344f), "", 51),
            new FubarVectors(2, new Vector4(-911.6199f, 697.9403f, 150.6463f,292.6368f), new Vector4(-908.8953f, 694.2032f, 151.4343f,2.039155f), "", 51),
            new FubarVectors(2, new Vector4(-888.5139f, 705.4763f, 149.4612f,270.2732f), new Vector4(-884.7784f, 699.5323f, 151.2712f,76.85469f), "", 51),
            new FubarVectors(2, new Vector4(-704.9294f, 593.3123f, 141.5244f,283.0835f), new Vector4(-704.5323f, 588.7691f, 141.9345f,357.1661f), "", 51),
            new FubarVectors(2, new Vector4(-959.3202f, 441.7766f, 79.04989f,19.68166f), new Vector4(-967.8698f, 436.7488f, 80.57148f,256.9317f), "", 51),
            new FubarVectors(2, new Vector4(-1215.828f, 467.437f, 89.74809f,276.1575f), new Vector4(-1215.853f, 458.093f, 92.06386f,354.0667f), "", 51),
            new FubarVectors(2, new Vector4(-1090.266f, -1552.004f, 3.647334f,300.4f), new Vector4(-1084.694f, -1559.033f, 4.584535f,48.5863f), "", 51),
            new FubarVectors(2, new Vector4(-1070.45f, -1538.748f, 4.071968f,304.332f), new Vector4(-1065.801f, -1545.831f, 4.902433f,36.17126f), "", 51),
            new FubarVectors(2, new Vector4(-1063.333f, -1533.899f, 4.208085f,305.6282f), new Vector4(-1057.916f, -1540.531f, 5.047055f,34.3056f), "", 51),
            new FubarVectors(2, new Vector4(-1111.058f, -1539.041f, 3.611673f,36.50002f), new Vector4(-1108.277f, -1527.281f, 6.779533f,130.2023f), "", 51),
            new FubarVectors(2, new Vector4(-1081.739f, -1535.77f, 3.962787f,123.8044f), new Vector4(-1087.111f, -1529.776f, 4.694689f,218.2304f), "", 51),
            new FubarVectors(2, new Vector4(-1074.125f, -1530.682f, 4.138926f,123.6743f), new Vector4(-1078.561f, -1524.034f, 5.090019f,206.0965f), "", 51),
            new FubarVectors(2, new Vector4(-1062.225f, -1510.697f, 4.374067f,214.3169f), new Vector4(-1070.262f, -1515.268f, 5.301328f,314.78f), "", 51),
            new FubarVectors(2, new Vector4(-1080.088f, -1598.039f, 3.658956f,216.1357f), new Vector4(-1093.423f, -1607.961f, 8.458806f,298.1418f), "", 51),
            new FubarVectors(2, new Vector4(-1066.72f, -1615.235f, 3.707842f,214.5825f), new Vector4(-1077.075f, -1620.927f, 4.467788f,319.0191f), "", 51),
            new FubarVectors(2, new Vector4(-1118.053f, -1186.132f, 1.49517f,300.3857f), new Vector4(-1113.855f, -1193.734f, 2.372723f,24.2789f), "", 51),
            new FubarVectors(2, new Vector4(-1117.727f, -1229.076f, 1.780209f,210.7522f), new Vector4(-1107.426f, -1222.912f, 2.561277f,192.6304f), "", 51),
            new FubarVectors(2, new Vector4(-1109.287f, -1244.627f, 1.787294f,208.9688f), new Vector4(-1100.971f, -1232.254f, 2.971726f,23.9239f), "", 51),
            new FubarVectors(2, new Vector4(-1140.722f, -1167.41f, 2.056757f,27.40231f), new Vector4(-1122.754f, -1156.928f, 2.692014f,162.5578f), "", 51),
            new FubarVectors(2, new Vector4(-1165.221f, -1092.328f, 1.372356f,302.6703f), new Vector4(-1161.289f, -1099.927f, 2.217415f,37.68119f), "", 51),
            new FubarVectors(2, new Vector4(-1198.563f, -1055.769f, 1.49867f,24.40097f), new Vector4(-1191.003f, -1054.797f, 2.15043f,119.2216f), "", 51),
            new FubarVectors(2, new Vector4(-1203.397f, -1046.202f, 1.491923f,31.10612f), new Vector4(-1188.701f, -1041.541f, 2.300482f,200.309f), "", 51),
            new FubarVectors(2, new Vector4(-1096.325f, -919.4227f, 2.242976f,301.0594f), new Vector4(-1090.627f, -926.233f, 3.134274f,26.31031f), "", 51),
            new FubarVectors(2, new Vector4(-940.9453f, -911.6255f, 1.512372f,27.33766f), new Vector4(-948.0229f, -910.4905f, 2.746016f,315.2483f), "", 51),
            new FubarVectors(2, new Vector4(-928.706f, -934.1456f, 1.553703f,211.1198f), new Vector4(-934.9145f, -939.3101f, 2.145313f,300.7444f), "", 51),
            new FubarVectors(2, new Vector4(-900.4125f, -978.4456f, 1.512298f,209.5555f), new Vector4(-908.5392f, -976.1187f, 2.150325f,226.2794f), "", 51),
            new FubarVectors(2, new Vector4(-942.4285f, -1083.626f, 1.42041f,123.0842f), new Vector4(-930.2081f, -1101.187f, 2.171849f,32.33736f), "", 51),
            new FubarVectors(2, new Vector4(-952.4161f, -1083.336f, 1.499375f,115.0011f), new Vector4(-952.2922f, -1077.6f, 2.673685f,207.7314f), "", 51),
            new FubarVectors(2, new Vector4(-972.1094f, -1099.693f, 1.477464f,118.2831f), new Vector4(-977.8149f, -1092.365f, 4.22256f,297.2751f), "", 51),
            new FubarVectors(2, new Vector4(-982.9766f, -1109.788f, 1.468125f,120.9254f), new Vector4(-970.631f, -1121.015f, 2.171849f,115.0729f), "", 51),
            new FubarVectors(2, new Vector4(-991.8918f, -1115.162f, 1.494659f,117.711f), new Vector4(-986.0299f, -1121.675f, 4.545539f,122.8889f), "", 51),
            new FubarVectors(2, new Vector4(-1024.177f, -1133.743f, 1.518156f,115.2345f), new Vector4(-1024.551f, -1139.454f, 2.745922f,33.01624f), "", 51),
            new FubarVectors(2, new Vector4(-1039.345f, -1138.422f, 1.447753f,122.7953f), new Vector4(-1048.052f, -1123.304f, 2.158598f,307.512f), "", 51),
            new FubarVectors(2, new Vector4(-1075.491f, -1162.514f, 1.442538f,297.185f), new Vector4(-1068.198f, -1163.21f, 2.745342f,27.57687f), "", 51),
            new FubarVectors(2, new Vector4(-1062.436f, -1154.68f, 1.444117f,295.0904f), new Vector4(-1063.672f, -1160.405f, 2.746023f,32.10666f), "", 51),
            new FubarVectors(2, new Vector4(-986.139f, -984.501f, 1.396664f,122.0778f), new Vector4(-990.3918f, -975.85f, 4.222694f,285.6119f), "", 51),
            new FubarVectors(2, new Vector4(-1037.76f, -1018.363f, 1.492833f,122.485f), new Vector4(-1041.673f, -1025.731f, 2.745223f,27.63703f), "", 51),
            new FubarVectors(2, new Vector4(-1072.381f, -1014.876f, 1.284768f,28.29836f), new Vector4(-1076.096f, -1027.093f, 4.544957f,306.2813f), "", 51),
            new FubarVectors(2, new Vector4(-1053.774f, -1048.166f, 1.357909f,29.48368f), new Vector4(-1063.573f, -1054.975f, 2.150359f,301.4305f), "", 51),
            new FubarVectors(2, new Vector4(-1102.752f, -1054.7f, 1.465605f,115.6961f), new Vector4(-1104.071f, -1059.857f, 2.732311f,27.71301f), "", 51),
            new FubarVectors(2, new Vector4(-1134.944f, -1073.298f, 1.47844f,115.1184f), new Vector4(-1128.124f, -1080.66f, 4.222684f,96.75744f), "", 51),
            new FubarVectors(2, new Vector4(359.3791f, -124.8609f, 65.27196f,249.0023f), new Vector4(352.9322f, -142.6158f, 66.68829f,340.9857f), "", 51),
            new FubarVectors(2, new Vector4(323.4894f, -111.7832f, 67.55373f,251.4085f), new Vector4(315.2789f, -128.1956f, 69.97696f,331.0622f), "", 51),
            new FubarVectors(2, new Vector4(40.556f, -22.22789f, 68.63571f,341.1599f), new Vector4(44.91244f, -30.09369f, 69.39476f,62.85649f), "", 51),
            new FubarVectors(2, new Vector4(-182.1554f, 102.2689f, 69.34201f,239.3398f), new Vector4(-188.2183f, 88.28151f, 69.92287f,349.6276f), "", 51),
            new FubarVectors(2, new Vector4(-171.914f, 95.11906f, 69.55611f,240.0706f), new Vector4(-176.7871f, 82.38955f, 70.19767f,346.3221f), "", 51),
            new FubarVectors(2, new Vector4(-160.6716f, 88.75747f, 69.77979f,242.6912f), new Vector4(-165.3334f, 75.15154f, 70.70455f,352.9706f), "", 51),
            new FubarVectors(2, new Vector4(-150.1111f, 83.14919f, 69.96049f,241.3708f), new Vector4(-154.1014f, 68.50557f, 70.77237f,349.7829f), "", 51),
            new FubarVectors(2, new Vector4(-137.5669f, 76.30418f, 70.21066f,241.411f), new Vector4(-142.7577f, 62.39283f, 70.84373f,341.466f), "", 51),
            new FubarVectors(2, new Vector4(-163.0767f, 105.0806f, 69.65303f,61.63179f), new Vector4(-150.0137f, 123.9803f, 70.22547f,143.8216f), "", 51),
            new FubarVectors(2, new Vector4(-200.0437f, 127.9778f, 68.85919f,71.72346f), new Vector4(-197.8559f, 143.0272f, 70.32339f,155.7681f), "", 51),
            new FubarVectors(2, new Vector4(-596.4658f, 137.1905f, 59.52371f,23.73367f), new Vector4(-598.9131f, 147.3457f, 61.67271f,180.8188f), "", 51)
        };
        private static readonly List<Vector4> Area_02_MotelPark = new List<Vector4>
        {
            new Vector4(-1319.019f, -923.6852f, 10.55009f, 109.3543f),
            new Vector4(-1468.26f, -656.7629f, 28.85079f, 304.6123f),
            new Vector4(55.9858f, -281.6007f, 46.761f, 69.72614f),
            new Vector4(327.4202f, -206.2081f, 53.43425f, 341.6428f)
        };
        private static readonly List<Vector4> Area_02_MotelDoor00 = new List<Vector4>
        {
            new Vector4(-1339.179f, -941.4098f, 12.35345f, 309.8403f),
            new Vector4(-1338.126f, -941.8181f, 12.35385f, 21.70737f),
            new Vector4(-1331.213f, -939.1833f, 12.3552f, 40.06303f),
            new Vector4(-1329.455f, -938.5066f, 12.35556f, 30.07493f),
            new Vector4(-1309.068f, -931.0979f, 13.35846f, 26.83074f),
            new Vector4(-1310.912f, -931.7645f, 13.35847f, 19.41228f),
            new Vector4(-1318.138f, -934.3528f, 13.35722f, 22.16863f),
            new Vector4(-1319.862f, -935.0142f, 13.35688f, 19.32525f),
            new Vector4(-1339.174f, -941.3729f, 15.3576f, 292.8411f),
            new Vector4(-1338.162f, -941.7781f, 15.35861f, 26.23176f),
            new Vector4(-1331.188f, -939.0479f, 15.35798f, 29.89742f),
            new Vector4(-1329.255f, -938.5402f, 15.35757f, 34.60739f),
            new Vector4(-1319.735f, -935.1144f, 16.35853f, 15.81201f),
            new Vector4(-1318.076f, -934.3954f, 16.35828f, 18.6943f),
            new Vector4(-1311.03f, -931.9415f, 16.35733f, 23.96756f),
            new Vector4(-1308.946f, -931.0899f, 16.35702f, 12.97976f)
        };
        private static readonly List<Vector4> Area_02_MotelDoor01 = new List<Vector4>
        {
            new Vector4(-1493.716f, -668.3877f, 29.02507f, 312.7233f),
            new Vector4(-1497.765f, -664.5845f, 29.02508f, 314.0597f),
            new Vector4(-1495.308f, -661.6093f, 29.02508f, 210.1529f),
            new Vector4(-1490.722f, -658.3549f, 29.02509f, 216.8488f),
            new Vector4(-1486.691f, -655.5491f, 29.58303f, 200.1837f),
            new Vector4(-1482.146f, -652.2135f, 29.58302f, 210.3627f),
            new Vector4(-1478.248f, -649.361f, 29.58302f, 216.6475f),
            new Vector4(-1473.475f, -645.8616f, 29.58303f, 210.2961f),
            new Vector4(-1469.666f, -643.0453f, 29.58305f, 219.0399f),
            new Vector4(-1465.087f, -639.5988f, 29.58306f, 216.4865f),
            new Vector4(-1461.322f, -640.8093f, 29.58313f, 129.451f),
            new Vector4(-1452.397f, -653.2645f, 29.58314f, 112.9767f),
            new Vector4(-1454.327f, -655.8851f, 29.58305f, 34.13163f),
            new Vector4(-1458.972f, -659.1453f, 29.58303f, 40.03558f),
            new Vector4(-1462.967f, -662.1296f, 29.58304f, 34.09904f),
            new Vector4(-1467.628f, -665.459f, 29.58304f, 40.69062f),
            new Vector4(-1471.667f, -668.3338f, 29.58311f, 4.681208f),
            new Vector4(-1489.8f, -671.4514f, 33.38122f, 317.6779f),
            new Vector4(-1493.604f, -668.1074f, 33.38122f, 321.8093f),
            new Vector4(-1497.884f, -664.5816f, 33.38122f, 322.3023f),
            new Vector4(-1495.243f, -661.8184f, 33.38122f, 224.2434f),
            new Vector4(-1490.69f, -658.4252f, 33.38122f, 218.8002f),
            new Vector4(-1486.713f, -655.6639f, 33.38122f, 209.6599f),
            new Vector4(-1482.099f, -652.0962f, 33.38122f, 218.6508f),
            new Vector4(-1478.084f, -649.3696f, 33.38122f, 219.0824f),
            new Vector4(-1473.599f, -645.9902f, 33.38122f, 193.2287f),
            new Vector4(-1469.571f, -643.2679f, 33.38122f, 216.0052f),
            new Vector4(-1465.13f, -639.625f, 33.38123f, 208.1046f),
            new Vector4(-1461.285f, -640.8585f, 33.38123f, 122.0783f),
            new Vector4(-1457.865f, -645.5033f, 33.38123f, 122.7726f),
            new Vector4(-1455.763f, -648.6252f, 33.38123f, 121.4526f),
            new Vector4(-1452.375f, -653.2344f, 33.38123f, 123.3439f),
            new Vector4(-1454.599f, -655.7338f, 33.38123f, 40.81481f),
            new Vector4(-1459.046f, -659.2411f, 33.38123f, 26.81419f),
            new Vector4(-1462.975f, -662.1034f, 33.38123f, 37.78196f),
            new Vector4(-1467.604f, -665.3513f, 33.38123f, 36.7108f),
            new Vector4(-1471.588f, -668.2812f, 33.38123f, 42.1333f),
            new Vector4(-1476.111f, -671.6596f, 33.38123f, 41.08788f)
        };
        private static readonly List<Vector4> Area_02_MotelDoor02 = new List<Vector4>
        {
            new Vector4(67.25875f, -253.7964f, 52.35388f, 68.66617f),
            new Vector4(66.58646f, -255.8062f, 52.35388f, 83.71789f),
            new Vector4(63.50804f, -261.7595f, 52.35388f, 345.8399f),
            new Vector4(64.72852f, -254.6599f, 48.18819f, 61.3502f)
        };
        private static readonly List<Vector4> Area_02_MotelDoor03 = new List<Vector4>
        {
            new Vector4(321.2181f, -196.9894f, 54.22648f, 167.0147f),
            new Vector4(319.3309f, -196.5417f, 54.22647f, 154.1425f),
            new Vector4(315.7049f, -194.7913f, 54.22647f, 154.6749f),
            new Vector4(313.4187f, -197.9903f, 54.22181f, 274.0506f),
            new Vector4(311.5114f, -203.4797f, 54.22181f, 253.8968f),
            new Vector4(309.5175f, -208.0334f, 54.22181f, 252.5592f),
            new Vector4(307.4438f, -213.401f, 54.22181f, 251.2664f),
            new Vector4(307.3582f, -216.7464f, 54.22181f, 334.8379f),
            new Vector4(310.9131f, -218.0021f, 54.22181f, 344.0088f),
            new Vector4(312.8561f, -218.7048f, 54.22181f, 336.2133f),
            new Vector4(329.4403f, -225.17f, 54.22177f, 353.9414f),
            new Vector4(331.3728f, -225.943f, 54.22177f, 345.1727f),
            new Vector4(334.9068f, -227.3087f, 54.22177f, 329.2677f),
            new Vector4(337.1959f, -224.6857f, 54.22177f, 73.10061f),
            new Vector4(339.0763f, -219.3757f, 54.22177f, 64.30142f),
            new Vector4(340.8805f, -214.7169f, 54.22177f, 65.73135f),
            new Vector4(342.873f, -209.577f, 54.22182f, 63.7473f),
            new Vector4(344.608f, -205.034f, 54.22182f, 66.23808f),
            new Vector4(346.6497f, -199.7205f, 54.22182f, 73.94955f),
            new Vector4(346.7943f, -199.6014f, 58.01925f, 65.66962f),
            new Vector4(344.5083f, -204.8386f, 58.01925f, 63.43808f),
            new Vector4(343.033f, -209.4874f, 58.01924f, 78.40641f),
            new Vector4(340.9055f, -214.845f, 58.01924f, 62.96635f),
            new Vector4(339.2024f, -219.4741f, 58.01924f, 66.11166f),
            new Vector4(337.1747f, -224.7894f, 58.01924f, 58.58597f),
            new Vector4(334.8913f, -227.3059f, 58.01924f, 335.4975f),
            new Vector4(331.4316f, -225.9262f, 58.01924f, 335.4583f),
            new Vector4(329.452f, -225.0434f, 58.01924f, 328.4946f),
            new Vector4(321.252f, -196.8492f, 58.01924f, 159.7643f),
            new Vector4(319.4497f, -196.2169f, 58.01924f, 152.7271f),
            new Vector4(315.6988f, -194.7904f, 58.01924f, 169.0346f),
            new Vector4(313.3201f, -198.248f, 58.01925f, 256.0068f),
            new Vector4(311.5159f, -203.5559f, 58.01924f, 238.3409f),
            new Vector4(309.6428f, -208.081f, 58.01924f, 247.3893f),
            new Vector4(307.7805f, -213.3756f, 58.01924f, 243.3015f),
            new Vector4(307.4363f, -216.8189f, 58.01924f, 344.364f),
            new Vector4(310.8618f, -217.8574f, 58.01924f, 340.3737f),
            new Vector4(312.9115f, -218.7647f, 58.01924f, 340.6415f)
        };
        private static readonly List<Vector4> Area_02_AppPark = new List<Vector4>
        {
            new Vector4(6.482605f, -262.5301f, 46.71632f, 69.78151f),
            new Vector4(-1260.457f, -1299.552f, 3.319362f, 25.93353f),
            new Vector4(-1311.96f, -1230.331f, 4.409662f, 200.6845f)
        };
        private static readonly List<Vector4> Area_02_AppDoor00 = new List<Vector4>
        {
            new Vector4(8.51612f, -243.3718f, 47.66061f, 159.8848f),
            new Vector4(2.375115f, -241.0314f, 47.66061f, 175.3669f),
            new Vector4(2.102939f, -241.0615f, 51.86053f, 145.6908f),
            new Vector4(8.875803f, -243.4133f, 51.86053f, 149.4664f),
            new Vector4(2.229207f, -241.1276f, 55.86056f, 156.1464f),
            new Vector4(8.470503f, -243.4743f, 55.86055f, 151.9831f)
        };
        private static readonly List<Vector4> Area_02_AppDoor01 = new List<Vector4>
        {
            new Vector4(-1269.763f, -1296.268f, 4.003946f, 266.8516f),
            new Vector4(-1272.18f, -1295.359f, 8.285891f, 286.0465f),
            new Vector4(-1271.58f, -1297.271f, 8.285891f, 302.6681f),
            new Vector4(-1268.991f, -1303.559f, 8.285891f, 14.72877f)
        };
        private static readonly List<Vector4> Area_02_AppDoor02 = new List<Vector4>
        {
            new Vector4(-1308.497f, -1227.62f, 4.901005f, 150.8784f),
            new Vector4(-1305.906f, -1228.571f, 8.980483f, 115.8161f),
            new Vector4(-1306.557f, -1226.61f, 8.980477f, 128.9074f),
            new Vector4(-1309.174f, -1220.713f, 8.980477f, 199.118f)
        };

        private static readonly List<FubarVectors> Area_03_Facility = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-2217.745f, 2315.103f, 32.09967f,114.3936f), new Vector4(-2229.854f, 2403.009f, 12.181f,186.681f), "", 253)
        };
        private static readonly List<FubarVectors> Area_03_BikerBiz = new List<FubarVectors>
        {
           new FubarVectors(3, new Vector4(-1457.086f, -383.6398f, 37.82375f,138.2296f), new Vector4(-1462.595f, -382.0304f, 38.82231f,225.3809f), "", 101)//Coke
        };
        private static readonly List<FubarVectors> Area_03_OnineApps = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-1132.333f, 2698.236f, 18.17968f,129.9304f), new Vector4(-1125.987f, 2694.598f, 18.80041f,49.06293f), "8754 Route 68", 53),
        };
        private static readonly List<FubarVectors> Area_03_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-2974.33f, 482.2889f, 14.78894f,355.784f), new Vector4(-2963.747f, 477.674f, 15.6969f, 4.606586f), "Banham Canyon Fleeca", 248),
            new FubarVectors(3, new Vector4(-1086.022f, 2700.238f, 19.91906f,125.0185f), new Vector4(-1099.092f, 2710.686f, 19.10787f, 224.2085f), "Route 68 Discount Store", 240),
            new FubarVectors(3, new Vector4(-1106.096f, 2684.478f, 18.63465f,128.4923f),new Vector4(-1117.696f, 2695.555f, 18.55415f, 223.7323f), "Route 68 Amunation", 241),
            new FubarVectors(3, new Vector4(-3157.575f, 1081.458f, 20.22575f,101.5012f), new Vector4(-3170.514f, 1084.955f, 20.83875f, 248.7598f), "Chumash Amunation", 242),
            new FubarVectors(3, new Vector4(-3161.174f, 1074.106f, 20.21378f,102.7419f), new Vector4(-3170.855f, 1075.039f, 20.82917f, 268.4587f), "Ink Inc", 243),
            new FubarVectors(3, new Vector4(-3164.191f, 1067.382f, 20.20772f,99.95131f), new Vector4(-3172.946f, 1045.963f, 20.86322f, 332.7778f), "Chumash Suburban", 244),
            new FubarVectors(3, new Vector4(-3235.694f, 1008.169f, 11.80919f,177.4009f), new Vector4(-3244.319f, 1005.208f, 12.83072f, 247.2974f), "Chumash Pier 247", 245),
            new FubarVectors(3, new Vector4(-3032.613f, 595.5668f, 7.239547f,202.2111f), new Vector4(-3043.219f, 588.0665f, 7.908934f, 275.4016f),"Banham Canyon 247", 246),
            new FubarVectors(3, new Vector4(-2982.066f, 386.5274f, 14.37716f,354.6449f), new Vector4(-2969.449f, 389.9995f, 15.04331f, 77.30482f), "Banham Canyon Robs", 247),
            new FubarVectors(3, new Vector4(-1814.227f, 789.615f, 137.3507f,131.6381f), new Vector4(-1824.978f, 791.3878f, 138.1984f, 209.0986f), "Richmond Glen LTD", 249),
            new FubarVectors(3, new Vector4(54.9f,2783.834f,57.372f, 142.971f), new Vector4(59.088f, 2795.078f, 57.882f, -44.416f), "Great Chaparral Clubhouse", 97)
        }; 
        private static readonly List<FubarVectors> Area_03_Resurant = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3039.546f, 615.6086f, 7.089927f,203.3143f), new Vector4(-3048.238f, 615.9161f, 7.575843f,250.0298f), "Moms Pie", 0),
            new FubarVectors(3, new Vector4(-2977.259f, 430.3637f, 14.5641f,356.1664f), new Vector4(-2963.688f, 432.4032f, 15.27755f,75.55036f), "Hang Ten", 0),
            new FubarVectors(3, new Vector4(-2982.857f, 379.9872f, 14.34624f,351.873f), new Vector4(-2974.497f, 384.39f, 15.01261f,88.70558f), "Banham Deli", 0),
            new FubarVectors(3, new Vector4(-2182.997f, -409.368f, 12.5824f,319.4505f), new Vector4(-2190.412f, -399.5971f, 13.31094f,221.9822f), "Pipeline Inn", 0),
            new FubarVectors(3, new Vector4(-1637.314f, -989.8784f, 12.54784f,171.6794f), new Vector4(-1655.482f, -999.5763f, 13.01751f,231.8897f), "Out Of Towners", 0),
            new FubarVectors(3, new Vector4(-1615.233f, -977.1567f, 12.54766f,319.2024f), new Vector4(-1606.502f, -982.4208f, 13.0174f,49.64945f), "The Big Puffa", 0)
        };
        private static readonly List<FubarVectors> Area_03_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3112.512f, 1325.861f, 19.42356f,88.64252f), new Vector4(-3159.915f, 1376.126f, 16.86525f,273.8727f), "Chumash Bunker", 4),
            new FubarVectors(3, new Vector4(-3016.994f, 3338.623f, 9.622828f,192.2166f), new Vector4(-3033.792f, 3333.714f, 10.3699f,280.0179f), "Zancuda Bunker", 4)
        };
        private static readonly List<FubarVectors> Area_03_Lesure = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3236.36f, 968.5662f, 12.50932f,186.1274f), new Vector4(-3282.27f, 971.0674f, 8.347163f,193.0927f), "Chumash Pier", 0),
            new FubarVectors(3, new Vector4(-2296.023f, 375.8086f, 173.9971f,293.9131f), new Vector4(-2292.913f, 345.6447f, 174.6018f,6.073081f), "Kortz Center", 0),
            new FubarVectors(3, new Vector4(-1888.216f, 2045.041f, 140.3965f,69.62865f), new Vector4(-1886.639f, 2050.296f, 140.9811f,165.969f), "Marlowe Vineyard", 0),
            new FubarVectors(3, new Vector4(-1507.993f, 1491.321f, 115.5825f,344.4138f), new Vector4(-1514.418f, 1512.535f, 115.2885f,159.2678f), "White Water Activity Center", 0),
            new FubarVectors(3, new Vector4(-1602.278f, -1044.485f, 12.56813f,229.9469f), new Vector4(-1607.252f, -1073.987f, 13.01849f,48.11461f), "Del Perro Pier", 0)
        };
        private static readonly List<FubarVectors> Area_03_Hotel = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3017.662f, 87.48171f, 11.13883f,229.8318f), new Vector4(-3024.301f, 80.2394f, 11.60812f,325.0588f), "Pacific Bluffs", 11),
            new FubarVectors(3, new Vector4(-1863.883f, -355.0975f, 48.7464f,49.82743f), new Vector4(-1857.106f, -348.1464f, 49.83775f,133.0385f), "Von Crastenburg Hotel Pacific Bluffs", 11),
            new FubarVectors(3, new Vector4(-1668.373f, -543.0901f, 34.49f,53.73345f), new Vector4(-1660.72f, -534.0923f, 36.02421f,140.1874f), "Banner Hotel", 11),
        };
        private static readonly List<FubarVectors> Area_03_ORP = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3180.658f, 1290.957f, 14.0592f,247.7512f), new Vector4(-3190.676f, 1297.731f, 19.0674f,245.0513f), "", 51),
            new FubarVectors(3, new Vector4(-3183.311f, 1270.346f, 12.17393f,254.9015f), new Vector4(-3187.064f, 1273.6f, 12.66133f,254.1247f), "", 51),
            new FubarVectors(3, new Vector4(-3236.842f, 1038.351f, 11.37313f,262.0938f), new Vector4(-3248.461f, 1042.195f, 11.7577f,342.4902f), "", 51),
            new FubarVectors(3, new Vector4(-3071.85f, 657.6034f, 10.67065f,310.6417f), new Vector4(-3077.758f, 659.0297f, 11.66709f,305.8495f), "", 51),
            new FubarVectors(3, new Vector4(-3031.909f, 554.9281f, 7.221505f,273.7011f), new Vector4(-3037.06f, 559.1101f, 7.507685f,262.9286f), "", 51),
            new FubarVectors(3, new Vector4(-3032.044f, 548.8285f, 7.222395f,273.0267f), new Vector4(-3036.783f, 544.8415f, 7.507689f,279.4198f), "", 51),
            new FubarVectors(3, new Vector4(-3028.466f, 529.1766f, 7.110633f,266.5662f), new Vector4(-3031.609f, 525.1259f, 7.418378f,293.1272f), "", 51),
            new FubarVectors(3, new Vector4(-3054.984f, 446.1913f, 6.078387f,241.2682f), new Vector4(-3059.439f, 453.4136f, 6.355f,308.1406f), "", 51),
            new FubarVectors(3, new Vector4(-3056.779f, 440.1962f, 6.078247f,244.6572f), new Vector4(-3071.112f, 442.2274f, 6.432204f,200.837f), "", 51),
            new FubarVectors(3, new Vector4(-3074.463f, 395.0111f, 6.68469f,250.7313f), new Vector4(-3088.022f, 392.052f, 11.44828f,245.008f), "", 51),
            new FubarVectors(3, new Vector4(-3081.795f, 367.2194f, 6.841104f,253.4775f), new Vector4(-3094.386f, 364.0299f, 7.11908f,212.237f), "", 51),
            new FubarVectors(3, new Vector4(-3078.729f, 371.1037f, 6.756917f,256.4778f), new Vector4(-3091.218f, 379.27f, 7.112116f,249.9387f), "", 51),
            new FubarVectors(3, new Vector4(-3088.71f, 339.0896f, 7.057094f,256.34f), new Vector4(-3093.62f, 349.5225f, 7.542557f,258.2035f), "", 51),
            new FubarVectors(3, new Vector4(-3090.359f, 323.5883f, 6.994868f,252.5663f), new Vector4(-3110.266f, 335.707f, 7.493345f,239.4375f), "", 51),
            new FubarVectors(3, new Vector4(-3100.997f, 286.9933f, 8.70353f,256.6824f), new Vector4(-3115.969f, 294.5186f, 8.972109f,343.9737f), "", 51),
            new FubarVectors(3, new Vector4(-3101.86f, 250.9796f, 11.79934f,283.5082f), new Vector4(-3115.135f, 253.3001f, 12.49199f,280.4746f), "", 51),
            new FubarVectors(3, new Vector4(-3083.172f, 221.4865f, 13.66574f,321.9735f), new Vector4(-3089.267f, 221.317f, 14.11646f,324.8273f), "", 51),
            new FubarVectors(3, new Vector4(-2981.23f, 612.3184f, 19.82067f,103.2088f), new Vector4(-2977.365f, 609.4474f, 20.24566f,117.3492f), "", 51),
            new FubarVectors(3, new Vector4(-2982.986f, 654.5662f, 24.62313f,102.9709f), new Vector4(-2972.843f, 642.5392f, 25.80846f,96.64449f), "", 51),
            new FubarVectors(3, new Vector4(-3002.513f, 687.8111f, 23.83623f,104.8339f), new Vector4(-2994.945f, 682.1981f, 25.04325f,105.6758f), "", 51),
            new FubarVectors(3, new Vector4(-3003.329f, 718.7411f, 27.93678f,109.5287f), new Vector4(-2986.688f, 720.377f, 28.49688f,280.5353f), "", 51),
            new FubarVectors(3, new Vector4(-3018.92f, 740.0507f, 27.20635f,108.2156f), new Vector4(-3017.154f, 746.4309f, 27.77834f,109.3754f), "", 51),
            new FubarVectors(3, new Vector4(-1890.317f, 625.6895f, 129.8048f,134.5031f), new Vector4(-1896.41f, 642.3912f, 130.2091f,135.6104f), "", 51),
            new FubarVectors(3, new Vector4(-1972.61f, 622.8682f, 122.0211f,249.3061f), new Vector4(-1974.167f, 630.8234f, 122.5363f,239.3418f), "", 51),
            new FubarVectors(3, new Vector4(-1940.914f, 582.2904f, 118.7524f,73.77197f), new Vector4(-1929.144f, 595.3513f, 122.2849f,73.76144f), "", 51),
            new FubarVectors(3, new Vector4(-1987.146f, 602.5629f, 117.7295f,255.3423f), new Vector4(-1995.914f, 591.3108f, 118.1018f,269.3795f), "", 51),
            new FubarVectors(3, new Vector4(-1942.445f, 553.5145f, 114.5114f,160.2522f), new Vector4(-1938.31f, 551.1836f, 114.8284f,70.85834f), "", 51),
            new FubarVectors(3, new Vector4(-2011.322f, 484.195f, 106.6195f,256.0873f), new Vector4(-2014.473f, 499.3258f, 107.1717f,244.5216f), "", 51),
            new FubarVectors(3, new Vector4(-1956.843f, 447.2014f, 100.5681f,192.2569f), new Vector4(-1942.926f, 449.446f, 102.9281f,95.02689f), "", 51),
            new FubarVectors(3, new Vector4(-2008.929f, 454.8618f, 102.3518f,288.5639f), new Vector4(-2011.005f, 445.3031f, 103.0159f,278.0325f), "", 51),
            new FubarVectors(3, new Vector4(-2002.379f, 378.7492f, 93.87296f,178.9765f), new Vector4(-2008.202f, 367.7929f, 94.81432f,280.081f), "", 51),
            new FubarVectors(3, new Vector4(-1939.113f, 361.9132f, 92.99133f,188.1561f), new Vector4(-1931.501f, 362.5919f, 93.78577f,100.4027f), "", 51),
            new FubarVectors(3, new Vector4(-1857.348f, 327.1342f, 88.17714f,11.79387f), new Vector4(-1839.171f, 314.4151f, 90.91705f,107.2775f), "", 51),
            new FubarVectors(3, new Vector4(-1795.378f, 347.3343f, 88.05728f,67.10529f), new Vector4(-1807.901f, 333.482f, 89.56721f,26.32763f), "", 51),
            new FubarVectors(3, new Vector4(-1751.036f, 365.346f, 89.19474f,119.8925f), new Vector4(-1741.989f, 365.0535f, 88.72823f,132.9538f), "", 51),
            new FubarVectors(3, new Vector4(-1669.214f, 396.9711f, 88.50093f,67.6088f), new Vector4(-1673.167f, 385.8703f, 89.34826f,334.4228f), "", 51),
            new FubarVectors(3, new Vector4(-1995.319f, 293.8503f, 91.49142f,285.6034f), new Vector4(-1995.287f, 300.1558f, 91.96467f,179.6584f), "", 51),
            new FubarVectors(3, new Vector4(-1926.644f, 292.5228f, 88.79985f,11.73591f), new Vector4(-1922.596f, 298.3171f, 89.2872f,92.09549f), "", 51),
            new FubarVectors(3, new Vector4(-1977.376f, 259.8421f, 86.94446f,288.032f), new Vector4(-1970.291f, 246.368f, 87.81214f,295.7983f), "", 51),
            new FubarVectors(3, new Vector4(-1906.842f, 243.9758f, 85.63078f,25.30107f), new Vector4(-1905.841f, 252.8489f, 86.45291f,125.6398f), "", 51),
            new FubarVectors(3, new Vector4(-1952.425f, 211.8754f, 85.2787f,205.6115f), new Vector4(-1960.469f, 212.1031f, 86.80087f,283.9886f), "", 51),
            new FubarVectors(3, new Vector4(-1895.115f, 138.9963f, 80.78864f,34.80264f), new Vector4(-1898.98f, 132.871f, 81.98471f,299.9321f), "", 51)
        };
        private static readonly List<FubarVectors> Area_03_Houses = new List<FubarVectors>
        {
            new FubarVectors(3, new Vector4(-3183.891f, 1224.599f, 9.433401f,170.2598f), new Vector4(-3195.354f, 1220.85f, 10.04831f,193.5196f), "", 51),
            new FubarVectors(3, new Vector4(-3187.201f, 1204.354f, 8.922867f,177.1308f), new Vector4(-3193.775f, 1208.647f, 9.42523f,358.8972f), "", 51),
            new FubarVectors(3, new Vector4(-3190.453f, 1179.197f, 8.747551f,168.8476f), new Vector4(-3205.812f, 1186.038f, 9.66468f,318.9196f), "", 51),
            new FubarVectors(3, new Vector4(-3202.891f, 1137.524f, 9.249828f,152.6324f), new Vector4(-3213.747f, 1136.524f, 9.895404f,157.595f), "", 51),
            new FubarVectors(3, new Vector4(-3217.663f, 1105.758f, 9.779224f,158.3197f), new Vector4(-3224.83f, 1113.489f, 10.57764f,332.5662f), "", 51),
            new FubarVectors(3, new Vector4(-3224.569f, 1085.73f, 10.08613f,162.4533f), new Vector4(-3228.446f, 1092.608f, 10.76498f,246.5182f), "", 51),
            new FubarVectors(3, new Vector4(-3228.753f, 1072.117f, 10.31669f,166.8275f), new Vector4(-3234.028f, 1076.106f, 11.0333f,350.2954f), "", 51),
            new FubarVectors(3, new Vector4(-3231.951f, 949.3207f, 12.74916f,191.7107f), new Vector4(-3237.807f, 952.7618f, 13.12868f,279.9219f), "", 51),
            new FubarVectors(3, new Vector4(-3230f, 938.006f, 13.10167f,195.6641f), new Vector4(-3243.193f, 932.0803f, 17.22136f,194.1774f), "", 51),
            new FubarVectors(3, new Vector4(-3224.341f, 926.804f, 13.30175f,211.2698f), new Vector4(-3238.864f, 922.3475f, 13.95989f,17.98883f), "", 51),
            new FubarVectors(3, new Vector4(-3027.608f, 571.6547f, 7.013496f,191.0665f), new Vector4(-3033.984f, 575.3383f, 7.823583f,6.801424f), "", 51)
        };

        private static readonly List<FubarVectors> Area_04_Facility = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(2085.382f, 1732.146f, 102.6249f,132.8946f), new Vector4(2083.435f, 1758.661f, 104.5141f,308.1033f), "", 253),
            new FubarVectors(4, new Vector4(1840.387f, 233.2798f, 163.5728f,146.7029f), new Vector4(1866.842f, 272.4055f, 164.3051f,149.3239f), "", 253)
        };
        private static readonly List<FubarVectors> Area_04_BikerBiz = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(1441.357f, -1649.455f, 63.55116f,116.0186f), new Vector4(1454.785f, -1651.951f, 66.99488f,34.56282f), "El Burro Meth Lab", 104)
        };
        private static readonly List<FubarVectors> Area_04_OnineApps = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(901.8161f, -144.379f, 75.92869f,329.3836f), new Vector4(896.3147f, -144.5494f, 76.79865f,329.3298f), "0897 Mirror Park Blvd", 52),
            new FubarVectors(4, new Vector4(1351.746f, -1574.612f, 53.35311f,210.4705f), new Vector4(1341.325f, -1578.102f, 54.44422f,222.5959f), "12 Sustancia Rd", 51),
            new FubarVectors(4, new Vector4(2465.288f, 1589.326f, 32.03141f,271.514f), new Vector4(2461.197f, 1574.861f, 33.1126f,285.0731f), "1920 Senora Way", 52),
            new FubarVectors(4, new Vector4(943.508f,-1456.301f,30.806f, 1.171f), new Vector4(939.629f, -1458.516f, 31.358f, -0.858f), "La Mesa Clubhouse", 98)
        };
        private static readonly List<FubarVectors> Area_04_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(314.3236f, -266.5568f, 53.20562f,247.4375f), new Vector4(310.351f, -276.8173f, 54.16456f, 264.8225f), "Alta Fleeca", 213),
            new FubarVectors(4, new Vector4(1165.573f, -331.4697f, 68.29663f,97.81928f), new Vector4(1158.897f, -322.7438f, 69.20513f, 183.9213f), "Mirror Park LTD", 250),
            new FubarVectors(4, new Vector4(1197.608f, -469.4901f, 65.4968f,344.9969f), new Vector4(1210.5f, -471.6405f, 66.20802f, 59.54907f), "Mirror Park Hurr Kutz Barber", 251),
            new FubarVectors(4, new Vector4(1149.183f, -980.9067f, 45.46523f,182.7907f), new Vector4(1136.286f, -981.2539f, 46.41584f, 283.1544f), "Mirror Park Robs", 252),
            new FubarVectors(4, new Vector4(1310.194f, -1654.759f, 50.73097f,32.05984f), new Vector4(1323.229f, -1652.007f, 52.27523f, 38.4056f), "Los Santos Tattoos", 253),
            new FubarVectors(4, new Vector4(2565.666f, 386.2085f, 107.8605f,177.2324f), new Vector4(2554.907f, 386.1674f, 108.6229f, 266.6938f), "Tataviam Mountains 247", 254),
            new FubarVectors(4, new Vector4(2571.055f, 312.9731f, 107.858f,180.6367f), new Vector4(2569.574f, 296.1903f, 108.7349f, 350.7863f), "Tataviam Mountains Amunation", 255)
        }; 
        private static readonly List<FubarVectors> Area_04_Resurant = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(2555.565f, 2617.525f, 37.3451f,293.8271f), new Vector4(2562.021f, 2590.572f, 38.0831f,299.4261f), "Rex's Dinner", 0),
            new FubarVectors(4, new Vector4(2576.133f, 458.2148f, 107.8524f,269.0501f), new Vector4(2581f, 464.4473f, 108.6201f,182.9569f), "Bishops Chicken Tataviam Mountains", 0),
            new FubarVectors(4, new Vector4(1340.779f, -1633.88f, 51.6213f,61.19807f), new Vector4(1331.799f, -1643.022f, 52.13689f,352.2116f), "Redwood Store El Burro", 0),
            new FubarVectors(4, new Vector4(1134.172f, -956.2366f, 47.03666f,274.0168f), new Vector4(1139.027f, -962.2093f, 47.53127f,319.3216f), "Mexican & American Murrieta", 0),
            new FubarVectors(4, new Vector4(1191.441f, -492.46f, 64.8763f,345.9292f), new Vector4(1199.634f, -501.3946f, 65.18021f,124.0721f), "Squeeze One Out", 0),
            new FubarVectors(4, new Vector4(1210.849f, -414.642f, 67.0273f,348.9667f), new Vector4(1217.873f, -416.4157f, 67.77608f,78.24648f), "Mirror Park Tavern", 0),
            new FubarVectors(4, new Vector4(1237.759f, -376.2266f, 68.38205f,253.8828f), new Vector4(1241.334f, -367.0416f, 69.08218f,165.097f), "Horny's", 0),
            new FubarVectors(4, new Vector4(1168.472f, -283.3015f, 68.43072f,185.9274f), new Vector4(1169.146f, -291.5579f, 69.0218f,332.8087f), "Gabriela's Market Mirror Park", 0),
            new FubarVectors(4, new Vector4(1102.638f, -367.2875f, 66.34692f,120.5197f), new Vector4(1093.336f, -363.5686f, 67.05246f,175.0839f), "Hearty Taco", 0)
        };
        private static readonly List<FubarVectors> Area_04_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(1209.959f, -1262.494f, 34.53808f,91.42775f), new Vector4(1213.652f, -1251.144f, 36.3258f,93.93678f), "Murrieta Heights", 5),
            new FubarVectors(4, new Vector4(1760.141f, -1650.94f, 111.9821f,185.9895f), new Vector4(1754.414f, -1649.225f, 112.6559f,278.0065f), "El Burro Heights", 5),
            new FubarVectors(4, new Vector4(1573.778f, 2205.523f, 78.27287f,91.86152f), new Vector4(1572.031f, 2226.861f, 78.24252f,176.3652f), "Farmhouse Bunker", 4),
            new FubarVectors(4, new Vector4(1555.701f, -2142.788f, 76.8575f,14.434f), new Vector4(1566.872f, -2135.622f, 77.56097f,93.25663f), "GEE Warehouse", 4)
        };
        private static readonly List<FubarVectors> Area_04_Lesure = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(1036.765f, 196.3893f, 80.25246f,328.3677f), new Vector4(1045.936f, 189.1658f, 84.9909f,59.55474f), "The Race Course", 0),
            new FubarVectors(4, new Vector4(908.5916f, -176.292f, 73.57787f,59.4864f), new Vector4(895.2514f, -178.9673f, 74.70034f,245.6316f), "Downtown Cab Company", 0),
            new FubarVectors(4, new Vector4(702.4254f, -296.2865f, 58.57488f,10.56232f), new Vector4(695.8276f, -305.4143f, 59.24822f,116.5238f), "Glory Way Park", 0),
            new FubarVectors(4, new Vector4(1172.077f, -640.0529f, 61.89499f,190.466f), new Vector4(1121.99f, -645.9218f, 56.81291f,303.4193f), "Mirror Park", 0),
            new FubarVectors(4, new Vector4(2779.071f, -712.5394f, 4.92429f,98.94309f), new Vector4(2820.113f, -685.7394f, 1.117868f,143.0404f), "Palamino Beach", 0),
            new FubarVectors(4, new Vector4(774.7673f, 596.6841f, 125.1777f,243.4236f), new Vector4(777.9766f, 569.0324f, 127.5204f,334.6658f), "Vinewood Bowl ", 0),
            new FubarVectors(4, new Vector4(230.6831f, 1173.933f, 224.8562f,16.26188f), new Vector4(224.7571f, 1173.221f, 225.9892f,292.4133f), "Sisyphus Theater ", 0),
            new FubarVectors(4, new Vector4(-411.867f, 1174.359f, 325.0383f,253.2032f), new Vector4(-430.3872f, 1109.845f, 327.682f,345.3308f), "Observatory", 0)
        };
        private static readonly List<FubarVectors> Area_04_Hotel = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(917.4914f, 49.54622f, 80.29544f,326.9893f), new Vector4(925.0522f, 46.43219f, 81.10635f,60.48177f), "Diamond Resort", 11),
        };
        private static readonly List<FubarVectors> Area_04_ORP01 = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(1295.376f, -567.9024f, 70.75495f,344.1851f), new Vector4(1301.253f, -573.5514f, 71.73225f,341.7915f), "", 51),
            new FubarVectors(4, new Vector4(1319.005f, -575.0912f, 72.48561f,338.2868f), new Vector4(1323.626f, -582.8721f, 73.24647f,338.9369f), "", 51),
            new FubarVectors(4, new Vector4(1348.813f, -603.4597f, 73.88947f,326.5587f), new Vector4(1341.663f, -597.4514f, 74.70089f,247.6048f), "", 51),
            new FubarVectors(4, new Vector4(1359.929f, -602.2659f, 73.86779f,357.5853f), new Vector4(1367.098f, -606.2906f, 74.71091f,2.989266f), "", 51),
            new FubarVectors(4, new Vector4(1379.085f, -596.9114f, 73.86754f,53.01553f), new Vector4(1386.105f, -593.3985f, 74.48546f,58.50755f), "", 51),
            new FubarVectors(4, new Vector4(1388.36f, -577.789f, 73.86846f,111.8918f), new Vector4(1388.947f, -569.5814f, 74.49652f,123.4853f), "", 51),
            new FubarVectors(4, new Vector4(1362.931f, -554.0172f, 73.86754f,156.5999f), new Vector4(1373.296f, -555.8261f, 74.68562f,68.44845f), "", 51),
            new FubarVectors(4, new Vector4(1354.012f, -552.6052f, 73.49485f,158.3126f), new Vector4(1348.199f, -547.2642f, 73.89163f,152.8504f), "", 51),
            new FubarVectors(4, new Vector4(1316.796f, -537.9033f, 71.47861f,161.5897f), new Vector4(1328.452f, -536.0343f, 72.44083f,71.44156f), "", 51),
            new FubarVectors(4, new Vector4(1308.672f, -534.2927f, 70.8349f,161.667f), new Vector4(1303.016f, -527.8336f, 71.46064f,161.5036f), "", 51),
            new FubarVectors(4, new Vector4(1262.95f, -715.1516f, 64.03774f,240.8946f), new Vector4(1264.701f, -702.7781f, 64.90907f,240.0456f), "", 51),
            new FubarVectors(4, new Vector4(1278.863f, -672.2916f, 65.61749f,275.1073f), new Vector4(1270.782f, -683.3943f, 66.03163f,348.3714f), "", 51),
            new FubarVectors(4, new Vector4(1277.071f, -656.444f, 67.14643f,290.0173f), new Vector4(1265.569f, -648.3455f, 67.92182f,43.03191f), "", 51),
            new FubarVectors(4, new Vector4(1259.367f, -622.5423f, 68.815f,295.2193f), new Vector4(1251.347f, -621.3013f, 69.41325f,216.018f), "", 51),
            new FubarVectors(4, new Vector4(1243.992f, -585.7985f, 68.79922f,272.6827f), new Vector4(1236.836f, -589.4675f, 69.78013f,6.338792f), "", 51),
            new FubarVectors(4, new Vector4(1244.244f, -578.3922f, 68.85719f,269.6844f), new Vector4(1241.927f, -566.3712f, 69.65741f,288.1931f), "", 51),
            new FubarVectors(4, new Vector4(1249.26f, -522.2668f, 68.50861f,256.182f), new Vector4(1250.788f, -515.5221f, 69.34905f,242.1898f), "", 51),
            new FubarVectors(4, new Vector4(1260.297f, -492.5744f, 68.91977f,256.9387f), new Vector4(1251.542f, -494.0509f, 69.90688f,250.3926f), "", 51),
            new FubarVectors(4, new Vector4(1259.068f, -419.8898f, 68.95522f,299.4943f), new Vector4(1262.366f, -429.9049f, 70.01472f,300.8087f), "", 51),
            new FubarVectors(4, new Vector4(1200.074f, -613.0391f, 64.55002f,94.95676f), new Vector4(1207.419f, -620.009f, 66.43862f,97.66859f), "", 51),
            new FubarVectors(4, new Vector4(1215.724f, -665.5594f, 62.25998f,105.1844f), new Vector4(1221.608f, -669.1736f, 63.49343f,13.46015f), "", 51),
            new FubarVectors(4, new Vector4(1222.419f, -704.3478f, 60.2279f,96.78835f), new Vector4(1222.887f, -696.9181f, 60.80474f,105.7308f), "", 51),
            new FubarVectors(4, new Vector4(1223.63f, -731.601f, 59.47527f,149.0665f), new Vector4(1229.317f, -725.6071f, 60.79803f,91.76685f), "", 51),
            new FubarVectors(4, new Vector4(981.3393f, -709.6439f, 57.15787f,310.0305f), new Vector4(979.1669f, -716.2917f, 58.22069f,310.7902f), "", 51),
            new FubarVectors(4, new Vector4(972.4129f, -685.7778f, 57.25153f,309.2305f), new Vector4(970.8255f, -701.52f, 58.48197f,354.5152f), "", 51),
            new FubarVectors(4, new Vector4(958.8745f, -661.8682f, 57.51588f,304.1452f), new Vector4(960.0464f, -669.7861f, 58.44978f,306.5766f), "", 51),
            new FubarVectors(4, new Vector4(949.5441f, -654.5562f, 57.52147f,309.1548f), new Vector4(943.4562f, -653.584f, 58.4287f,216.3886f), "", 51),
            new FubarVectors(4, new Vector4(926.4679f, -629.5486f, 57.3954f,319.9789f), new Vector4(928.9008f, -639.7322f, 58.24244f,312.6214f), "", 51),
            new FubarVectors(4, new Vector4(915.1364f, -628.0727f, 57.57964f,319.2966f), new Vector4(902.8493f, -615.579f, 58.4533f,246.7886f), "", 51),
            new FubarVectors(4, new Vector4(876.7163f, -595.7554f, 57.60468f,315.5723f), new Vector4(875.6384f, -602.271f, 58.44205f,48.01766f), "", 51),
            new FubarVectors(4, new Vector4(874.3272f, -587.4362f, 57.19896f,315.6563f), new Vector4(861.6575f, -583.5533f, 58.15649f,337.0353f), "", 51),
            new FubarVectors(4, new Vector4(848.7827f, -566.3721f, 57.23867f,279.6228f), new Vector4(844.2364f, -562.9039f, 57.83413f,190.2357f), "", 51),
            new FubarVectors(4, new Vector4(850.058f, -541.8986f, 56.85556f,264.3753f), new Vector4(850.2711f, -532.7251f, 57.92553f,268.921f), "", 51),
            new FubarVectors(4, new Vector4(859.718f, -522.5883f, 56.8409f,226.5662f), new Vector4(861.8169f, -509.5154f, 57.32895f,227.2639f), "", 51),
            new FubarVectors(4, new Vector4(875.5849f, -507.2527f, 56.9897f,228.1333f), new Vector4(878.6003f, -498.2205f, 58.10064f,228.1311f), "", 51),
            new FubarVectors(4, new Vector4(914.4882f, -490.0322f, 58.54957f,205.0751f), new Vector4(906.2788f, -489.4254f, 59.43626f,199.8672f), "", 51),
            new FubarVectors(4, new Vector4(932.5269f, -478.7095f, 60.27127f,204.433f), new Vector4(921.7753f, -478.077f, 61.08363f,201.9862f), "", 51),
            new FubarVectors(4, new Vector4(943.8246f, -470.6311f, 60.78315f,213.0169f), new Vector4(944.274f, -463.3413f, 61.51734f,140.1394f), "", 51),
            new FubarVectors(4, new Vector4(973.9123f, -451.6287f, 61.93366f,215.0411f), new Vector4(967.0895f, -451.6115f, 62.78954f,220.4082f), "", 51),
            new FubarVectors(4, new Vector4(997.0678f, -435.5168f, 63.55046f,264.8619f), new Vector4(987.5968f, -433.2158f, 63.89077f,205.1448f), "", 51),
            new FubarVectors(4, new Vector4(1023.098f, -419.4548f, 65.34373f,218.5261f), new Vector4(1029.05f, -408.7803f, 65.94938f,222.3555f), "", 51),
            new FubarVectors(4, new Vector4(1056.69f, -387.189f, 67.38435f,222.1012f), new Vector4(1060.556f, -378.2659f, 68.23121f,223.6127f), "", 51),
            new FubarVectors(4, new Vector4(1106.454f, -399.7615f, 67.50427f,72.72183f), new Vector4(1114.356f, -391.3941f, 68.94821f,67.15671f), "", 51),
            new FubarVectors(4, new Vector4(1100.32f, -418.7397f, 66.68211f,86.01027f), new Vector4(1101.103f, -411.3693f, 67.55517f,88.9761f), "", 51),
            new FubarVectors(4, new Vector4(1099.369f, -429.3362f, 66.89532f,83.01512f), new Vector4(1099.459f, -438.4716f, 67.7906f,353.4471f), "", 51),
            new FubarVectors(4, new Vector4(1091.125f, -471.4535f, 65.61601f,76.97134f), new Vector4(1098.569f, -464.5248f, 67.31943f,149.9425f), "", 51),
            new FubarVectors(4, new Vector4(1052.162f, -487.9549f, 63.41039f,258.7199f), new Vector4(1046.217f, -497.9194f, 64.07937f,346.5026f), "", 51),
            new FubarVectors(4, new Vector4(1055.993f, -483.0686f, 63.39307f,256.5244f), new Vector4(1051.741f, -470.7442f, 63.89892f,262.8094f), "", 51),
            new FubarVectors(4, new Vector4(1062.449f, -445.5917f, 65.4231f,257.3079f), new Vector4(1056.267f, -449.0076f, 66.25752f,346.4865f), "", 51),
            new FubarVectors(4, new Vector4(1019.49f, -460.5889f, 63.49864f,36.95961f), new Vector4(1014.657f, -469.23f, 64.50294f,36.86657f), "", 51),
            new FubarVectors(4, new Vector4(961.8917f, -502.6351f, 61.0839f,30.91768f), new Vector4(970.2992f, -502.3734f, 62.1409f,63.95373f), "", 51),
            new FubarVectors(4, new Vector4(947.2533f, -511.7283f, 59.7457f,29.79747f), new Vector4(945.79f, -518.9921f, 60.7491f,322.1016f), "", 51),
            new FubarVectors(4, new Vector4(888.6f, -552.6331f, 57.47837f,115.7793f), new Vector4(892.9021f, -540.6024f, 58.50665f,111.6948f), "", 51),
            new FubarVectors(4, new Vector4(927.5731f, -568.8168f, 57.31059f,206.4541f), new Vector4(919.8404f, -569.6871f, 58.36638f,197.9201f), "", 51),
            new FubarVectors(4, new Vector4(958.3226f, -552.3696f, 58.64332f,209.7552f), new Vector4(965.3028f, -542.1897f, 59.53446f,205.8423f), "", 51),
            new FubarVectors(4, new Vector4(982.9958f, -535.0028f, 59.38626f,211.3965f), new Vector4(987.8207f, -526.0056f, 60.69076f,211.1506f), "", 51),
            new FubarVectors(4, new Vector4(1004.337f, -517.0163f, 60.12453f,204.8713f), new Vector4(1006.223f, -511.052f, 60.83396f,120.5434f), "", 51),
            new FubarVectors(4, new Vector4(983.1898f, -573.9033f, 58.70306f,31.48137f), new Vector4(976.7343f, -580.5659f, 59.85005f,28.81238f), "", 51),
            new FubarVectors(4, new Vector4(954.9034f, -599.2274f, 58.80585f,28.27949f), new Vector4(964.1855f, -596.0289f, 59.90272f,83.6746f), "", 51),
            new FubarVectors(4, new Vector4(974.8517f, -619.3837f, 58.275f,125.435f), new Vector4(980.1414f, -627.6998f, 59.23585f,36.90541f), "", 51),
            new FubarVectors(4, new Vector4(1007.61f, -589.0872f, 58.51507f,258.1907f), new Vector4(999.6492f, -593.9169f, 59.63858f,262.3635f), "", 51),
            new FubarVectors(4, new Vector4(1009.365f, -562.7611f, 59.63181f,263.5792f), new Vector4(1009.797f, -572.4837f, 60.59442f,260.7605f), "", 51),
            new FubarVectors(4, new Vector4(946.2366f, -254.3581f, 67.11252f,144.8288f), new Vector4(952.6766f, -252.3817f, 67.96442f,74.69676f), "", 51),
            new FubarVectors(4, new Vector4(871.5029f, -204.2031f, 70.354f,150.321f), new Vector4(880.307f, -205.2603f, 71.97645f,155.9502f), "", 51),
            new FubarVectors(4, new Vector4(1373.176f, -1521.595f, 56.65441f,197.1799f), new Vector4(1379.385f, -1515.369f, 58.21299f,211.9685f), "", 51),
            new FubarVectors(4, new Vector4(1251.666f, -1617.034f, 52.81802f,32.56459f), new Vector4(1261.547f, -1616.846f, 54.74287f,45.56825f), "", 51),
            new FubarVectors(4, new Vector4(1302.72f, -1741.39f, 53.30978f,21.59027f), new Vector4(1295.516f, -1739.581f, 54.27173f,297.1445f), "", 51),
            new FubarVectors(4, new Vector4(1303.4f, -1708.492f, 54.53121f,200.613f), new Vector4(1289.201f, -1710.854f, 55.47483f,205.4635f), "", 51)
        };
        private static readonly List<FubarVectors> Area_04_Houses01 = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(1077.315f, -483.0781f, 63.17188f,349.1223f), new Vector4(1090.363f, -484.3336f, 65.66045f,83.36637f), "", 51),
            new FubarVectors(4, new Vector4(922.8597f, -508.0334f, 58.33526f,111.5277f), new Vector4(924.4144f, -525.9933f, 59.789f,32.63654f), "", 51),
            new FubarVectors(4, new Vector4(1007.376f, -720.7717f, 56.81048f,220.09f), new Vector4(997.0497f, -729.3624f, 57.81575f,307.6517f), "", 51),
            new FubarVectors(4, new Vector4(1186.47f, -602.5395f, 63.26411f,9.93148f), new Vector4(1203.51f, -598.7026f, 68.06358f,179.9252f), "", 51),
            new FubarVectors(4, new Vector4(1183.853f, -584.222f, 63.50164f,6.568177f), new Vector4(1201.036f, -575.5956f, 69.13913f,138.4204f), "", 51),
            new FubarVectors(4, new Vector4(1184.517f, -553.8195f, 63.86813f,357.2055f), new Vector4(1204.88f, -557.8184f, 69.61515f,86.45617f), "", 51),
            new FubarVectors(4, new Vector4(1272.792f, -455.6908f, 68.78747f,174.1581f), new Vector4(1265.833f, -458.094f, 70.517f,280.1007f), "", 51),
            new FubarVectors(4, new Vector4(1278.14f, -480.333f, 68.39219f,160.1243f), new Vector4(1259.548f, -480.0786f, 70.18879f,300.8748f), "", 51),
            new FubarVectors(4, new Vector4(768.9922f, -159.6989f, 74.02215f,56.90633f), new Vector4(773.5734f, -150.2127f, 75.62209f,147.2333f), "", 51),
            new FubarVectors(4, new Vector4(791.462f, -171.6557f, 73.15645f,63.11963f), new Vector4(798.3322f, -158.7401f, 74.89242f,242.9908f), "", 51),
            new FubarVectors(4, new Vector4(800.9214f, -176.4196f, 72.44189f,63.10062f), new Vector4(808.4719f, -163.9939f, 75.87946f,146.2302f), "", 51),
            new FubarVectors(4, new Vector4(829.0195f, -179.573f, 72.30473f,328.3878f), new Vector4(840.7205f, -182.2783f, 74.38826f,61.63657f), "", 51),
            new FubarVectors(4, new Vector4(925.477f, -254.9916f, 67.84925f,53.03957f), new Vector4(930.5647f, -245.2522f, 69.00269f,232.5208f), "", 51),
            new FubarVectors(4, new Vector4(915.517f, -248.0279f, 68.54739f,55.94276f), new Vector4(920.8428f, -238.2787f, 70.17599f,151.0997f), "", 51),
            new FubarVectors(4, new Vector4(1253.369f, -1749.538f, 47.21949f,297.5468f), new Vector4(1259.059f, -1761.728f, 49.65825f,25.62736f), "", 51),
            new FubarVectors(4, new Vector4(1257.504f, -1742.6f, 48.54551f,299.1154f), new Vector4(1250.797f, -1734.33f, 52.03196f,199.795f), "", 51),
            new FubarVectors(4, new Vector4(1315.895f, -1719.952f, 54.13153f,293.0896f), new Vector4(1314.54f, -1733.064f, 54.70005f,287.9806f), "", 51),
            new FubarVectors(4, new Vector4(1325.264f, -1709.962f, 55.14931f,290.795f), new Vector4(1316.718f, -1698.764f, 58.23663f,189.0215f), "", 51),
            new FubarVectors(4, new Vector4(1365.219f, -1700.023f, 61.01937f,283.4658f), new Vector4(1354.792f, -1690.705f, 60.49121f,252.9794f), "", 51),
            new FubarVectors(4, new Vector4(1361.429f, -1707.339f, 61.00024f,281.5523f), new Vector4(1365.421f, -1721.627f, 65.634f,7.105875f), "", 51),
            new FubarVectors(4, new Vector4(1305.634f, -1631.645f, 51.62403f,124.739f), new Vector4(1297.295f, -1618.539f, 54.22554f,222.2003f), "", 51),
            new FubarVectors(4, new Vector4(1281.946f, -1648.562f, 49.25118f,125.4761f), new Vector4(1276.622f, -1629.488f, 54.53824f,214.4592f), "", 51),
            new FubarVectors(4, new Vector4(1237.804f, -1675.572f, 41.78252f,119.3336f), new Vector4(1220.404f, -1658.839f, 48.64145f,202.3826f), "", 51),
            new FubarVectors(4, new Vector4(1212.625f, -1685.204f, 37.85319f,108.7075f), new Vector4(1203.221f, -1670.827f, 42.91134f,225.1005f), "", 51),
            new FubarVectors(4, new Vector4(1195.41f, -1635.496f, 43.30803f,304.2092f), new Vector4(1193.466f, -1622.243f, 45.22148f,116.9055f), "", 51),
            new FubarVectors(4, new Vector4(1218.586f, -1619.77f, 48.56711f,297.6543f), new Vector4(1210.624f, -1607.066f, 50.72899f,214.934f), "", 51),
            new FubarVectors(4, new Vector4(1238.856f, -1616.023f, 51.6504f,302.3475f), new Vector4(1245.445f, -1626.826f, 53.28234f,30.71065f), "", 51),
            new FubarVectors(4, new Vector4(1241.371f, -1606.351f, 52.43449f,301.8195f), new Vector4(1230.808f, -1591.042f, 53.76608f,212.9128f), "", 51),
            new FubarVectors(4, new Vector4(1315.702f, -1557.15f, 50.00427f,319.1902f), new Vector4(1322.65f, -1560.066f, 51.2249f,131.4509f), "", 51),
            new FubarVectors(4, new Vector4(1318.788f, -1541.765f, 49.60303f,278.8158f), new Vector4(1315.659f, -1526.8f, 51.80762f,198.4372f), "", 51),
            new FubarVectors(4, new Vector4(1336.78f, -1538.046f, 51.92155f,266.3006f), new Vector4(1338.13f, -1524.446f, 54.5816f,164.9051f), "", 51),
            new FubarVectors(4, new Vector4(1358.94f, -1544.026f, 54.30811f,279.8521f), new Vector4(1360.649f, -1556.194f, 56.34243f,6.97298f), "", 51),
            new FubarVectors(4, new Vector4(1380.684f, -1535.842f, 56.2311f,299.3591f), new Vector4(1382.021f, -1544.762f, 57.10717f,303.5031f), "", 51),
            new FubarVectors(4, new Vector4(1412.761f, -1501.996f, 59.42999f,205.9109f), new Vector4(1411.757f, -1490.408f, 60.65701f,139.163f), "", 51)
        };
        private static readonly List<FubarVectors> Area_04_Trailer = new List<FubarVectors>
        {
            new FubarVectors(4, new Vector4(2361.071f, 2526.605f, 46.16054f,43.09398f), new Vector4(2357.012f, 2519.038f, 47.60446f,298.4249f), "", 49),
            new FubarVectors(4, new Vector4(2354.516f, 2532.508f, 46.05946f,271.6932f), new Vector4(2355.09f, 2540.325f, 47.22219f,188.2417f), "", 49),
            new FubarVectors(4, new Vector4(2335.642f, 2514.642f, 46.16117f,343.4839f), new Vector4(2333.184f, 2523.869f, 46.54026f,236.6292f), "", 49),
            new FubarVectors(4, new Vector4(2314.277f, 2543.254f, 46.16099f,302.3943f), new Vector4(2314.211f, 2549.632f, 47.55754f,218.7161f), "", 49),
            new FubarVectors(4, new Vector4(2327.414f, 2538.904f, 46.04688f,154.488f), new Vector4(2320.536f, 2536.033f, 47.6574f,254.2645f), "", 49),
            new FubarVectors(4, new Vector4(2343.526f, 2562.856f, 46.16072f,323.1952f), new Vector4(2336.37f, 2566.407f, 47.53659f,247.4856f), "", 49),
            new FubarVectors(4, new Vector4(2353.464f, 2570.275f, 46.07547f,295.4305f), new Vector4(2356.039f, 2564.885f, 46.88408f,28.79648f), "", 49),
            new FubarVectors(4, new Vector4(2331.612f, 2583.166f, 46.15851f,271.9197f), new Vector4(2334.37f, 2589.112f, 47.62941f,168.1988f), "", 49),
            new FubarVectors(4, new Vector4(2326.48f, 2601.76f, 46.06208f,357.7852f), new Vector4(2337.591f, 2605.297f, 47.26322f,136.0408f), "", 49)
        };

        private static readonly List<FubarVectors> Area_05_Facility = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(2735.388f, 3884.856f, 42.89842f,235.8106f), new Vector4(2758.294f, 3909.598f, 45.81793f,127.8332f), "", 253),
            new FubarVectors(5, new Vector4(1272.411f, 2815.892f, 46.3297f,94.51208f), new Vector4(1275.265f, 2836.912f, 49.39413f,140.685f), "", 253),
            new FubarVectors(5, new Vector4(62.60934f, 3328.289f, 35.96255f,127.0811f), new Vector4(-3.648185f, 3341.294f, 41.63113f,353.9338f), "", 253),
            new FubarVectors(5, new Vector4(99.78214f, 2688.364f, 52.52273f,44.75583f), new Vector4(31.77179f, 2619.351f, 85.99998f,304.2384f), "", 253)
        };
        private static readonly List<FubarVectors> Area_05_BikerBiz = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(1661.678f, 4853.115f, 41.51831f,186.7074f), new Vector4(1657.078f, 4851.734f, 41.98793f,274.3726f), "", 100),//Forg
			new FubarVectors(5, new Vector4(389.68f, 3592.309f, 32.91478f,265.711f), new Vector4(387.4411f, 3584.843f, 33.29226f,356.9489f), "", 101),//Coke
			new FubarVectors(5, new Vector4(2841.12f, 4445.481f, 48.26614f,204.5074f), new Vector4(2848.281f, 4450.343f, 48.51295f,99.31353f), "", 102),//Weed
			new FubarVectors(5, new Vector4(648.8728f, 2784.034f, 41.52564f,181.7643f), new Vector4(635.2188f, 2774.894f, 42.00695f,281.0482f), "", 103),//Cash
			new FubarVectors(5, new Vector4(202.6039f, 2456.224f, 55.84687f,281.0482f), new Vector4(202.1441f, 2461.642f, 55.69265f,202.3564f), "", 104)//Meth
        };
        private static readonly List<FubarVectors> Area_05_OnineApps = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(189.5126f, 2787.098f, 44.9332f,279.5783f), new Vector4(182.724f, 2790.044f, 45.60722f,0.3589836f), "870 Route 68 Approach", 53),
            new FubarVectors(5, new Vector4(217.1832f, 2605.282f, 45.31407f,11.09799f), new Vector4(216.0146f, 2601.713f, 45.77259f,347.5827f), "197 Route 68", 52),
            new FubarVectors(5, new Vector4(639.1865f, 2774.203f, 41.31102f,3.246407f), new Vector4(635.1209f, 2774.743f, 42.00832f,276.5027f), "1200 Route 68", 52),
            new FubarVectors(5, new Vector4(1886.495f, 3771.943f, 32.12237f,209.2551f), new Vector4(1899.995f, 3772.98f, 32.87871f,210.7082f), "140 Zancudo Ave", 50),
            new FubarVectors(5, new Vector4(2552.869f, 4670.879f, 33.30706f,22.58625f), new Vector4(2555.189f, 4651.361f, 34.0768f,100.3086f), "1932 Grapeseed Ave", 52),
            new FubarVectors(5, new Vector4(1662.978f, 4768.379f, 41.31897f,278.218f), new Vector4(1662.564f, 4776.156f, 42.00757f,265.6299f), "1893 Grapeseed Ave", 50),
            new FubarVectors(5, new Vector4(1725.715f,3708.118f,33.704f, 20.017f), new Vector4(1737.778f, 3709.339f, 34.14f, 14.203f), "Sandy Shores Clubhouse", 97),
            new FubarVectors(5, new Vector4(2465.661f,4101.763f,37.56f, 66.018f), new Vector4(2471.683f, 4110.831f, 38.068f, 66.964f), "Grapeseed Clubhouse", 98)
        };
        private static readonly List<FubarVectors> Area_05_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(1178.757f, 2696.34f, 37.28358f,177.151f), new Vector4(1179.976f, 2707.157f, 38.08783f, 167.4428f), "Route 68 Fleesa", 260),
            new FubarVectors(5, new Vector4(2688.448f, 3285.239f, 54.55755f,150.8165f), new Vector4(2678.024f, 3285.313f, 55.24113f, 240.3584f), "Senora Fwy 247", 261),
            new FubarVectors(5, new Vector4(1164.823f, 2695.555f, 37.19798f,179.3348f), new Vector4(1166.723f, 2709.232f, 38.15771f, 179.4429f), "Scoops Liquor Barn", 262),
            new FubarVectors(5, new Vector4(538.7993f, 2679.049f, 41.61722f,272.015f), new Vector4(544.6658f, 2667.505f, 42.15654f, 2.221931f), "Route 68 247", 263),
            new FubarVectors(5, new Vector4(1968.535f, 3734.656f, 31.62889f,299.3237f), new Vector4(1962.75f, 3745.827f, 32.34375f, 210.6005f), "Sandy Shores 247", 264),
            new FubarVectors(5, new Vector4(1697.253f, 4938.027f, 41.39642f,145.131f), new Vector4(1702.204f, 4926.725f, 42.06367f, 42.73697f), "Grapeseed LTD", 265),
            new FubarVectors(5, new Vector4(1992.836f, 3058.78f, 46.37246f,236.6864f), new Vector4(1986.622f, 3054.385f, 47.21523f, 246.5357f), "Yellow Jack", 266),
            new FubarVectors(5, new Vector4(1193.792f, 2695.847f, 37.24526f,359.6774f), new Vector4(1198.456f, 2708.96f, 38.22264f, 183.6961f), "Route 68 Discount Store", 267),
            new FubarVectors(5, new Vector4(620.2941f, 2738.939f, 41.27623f,3.852415f), new Vector4(617.6826f, 2761.286f, 42.08809f, 185.6362f), "Route 68 Suburban", 268),
            new FubarVectors(5, new Vector4(1398.955f, 3592.339f, 34.18009f,290.7141f), new Vector4(1392.524f, 3604.308f, 34.98093f, 196.8476f), "Liquor Ace", 269),
            new FubarVectors(5, new Vector4(1705.3f, 3749.045f, 33.31833f,44.39492f), new Vector4(1693.749f, 3757.308f, 34.70536f, 231.1461f), "Sandy Shores Amunation", 270),
            new FubarVectors(5, new Vector4(1852.054f, 3746.01f, 32.38078f,211.8368f), new Vector4(1863.421f, 3751.065f, 33.03189f, 136.8399f), "Sandy Shores Tattoo", 271),
            new FubarVectors(5, new Vector4(1934.557f, 3717.021f, 31.66323f,297.4781f), new Vector4(1931.81f, 3729.641f, 32.84442f, 198.2637f), "O'Sheas Barbers", 272),
            new FubarVectors(5, new Vector4(1678.829f, 4824.646f, 41.29709f,187.1063f), new Vector4(1693.383f, 4820.753f, 42.06312f, 95.73136f), "Grapeseed Discount Stores", 273)
        }; 
        private static readonly List<FubarVectors> Area_05_Resurant = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(2573.632f, 4272.104f, 41.146f,323.2627f), new Vector4(2567.113f, 4273.775f, 41.98908f,230.8508f), "Grape Smugglers Liquor", 0),
            new FubarVectors(5, new Vector4(2483.885f, 4089.378f, 37.31764f,156.3787f), new Vector4(2481.91f, 4100.451f, 38.1349f,237.2685f), "Seaview Rd Liquor", 0),
            new FubarVectors(5, new Vector4(2463.577f, 4056.732f, 37.0986f,64.58132f), new Vector4(2456.095f, 4058.974f, 38.06471f,252.1516f), "Seaview Rd Liquor Market", 0),
            new FubarVectors(5, new Vector4(1958.44f, 3845.334f, 31.35936f,28.59671f), new Vector4(1952.241f, 3842.197f, 32.17766f,300.8427f), "Sandy Shores Liquor", 0),
            new FubarVectors(5, new Vector4(915.0198f, 3639.271f, 31.78067f,89.46872f), new Vector4(911.1982f, 3644.76f, 32.67596f,176.6918f), "Alamo Sea Liquor Market", 0),
            new FubarVectors(5, new Vector4(570.7592f, 2684.49f, 41.4832f,272.7449f), new Vector4(578.7737f, 2677.847f, 41.84618f,13.28776f), "Liquor J.R.Market", 0),
            new FubarVectors(5, new Vector4(657.2272f, 2729.075f, 41.49753f,183.294f), new Vector4(649.757f, 2728.518f, 41.9959f,265.4661f), "Route 68 Taco Farmer", 0),
            new FubarVectors(5, new Vector4(1800.968f, 4586.274f, 36.6058f,187.9535f), new Vector4(1791.199f, 4594.623f, 37.68294f,172.5256f), "Alamo Fruit Market", 0),
            new FubarVectors(5, new Vector4(1671.938f, 4886.831f, 41.62225f,5.653704f), new Vector4(1677.881f, 4880.863f, 42.04473f,45.64355f), "Farmers Market & Store", 0)
        };
        private static readonly List<FubarVectors> Area_05_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(64.04389f, 2854.463f, 53.03243f,289.4287f), new Vector4(38.61464f, 2931.662f, 55.99043f,205.6253f), "Route 68 Bunker", 4),
            new FubarVectors(5, new Vector4(513.9001f, 3048.316f, 39.19131f,212.7776f), new Vector4(492.2592f, 3013.255f, 40.91177f,327.937f), "Oilfields Bunker", 4),
            new FubarVectors(5, new Vector4(864.6389f, 3082.295f, 39.34605f,264.9445f), new Vector4(849.3412f, 3020.557f, 41.33721f,356.7075f), "Desert Bunker", 4),
            new FubarVectors(5, new Vector4(2054.58f, 3340.217f, 44.42887f,336.9905f), new Vector4(2110.587f, 3326.338f, 45.35321f,122.5319f), "Smoke Bunker", 4),
            new FubarVectors(5, new Vector4(2451.124f, 3111.103f, 47.08403f,277.6165f), new Vector4(2489.509f, 3160.779f, 49.04891f,16.81406f), "Thomson Bunker", 4),
            new FubarVectors(5, new Vector4(1762.311f, 4731.798f, 40.49058f,317.059f), new Vector4(1802.82f, 4705.561f, 39.91064f,92.13362f), "Grapeseed Bunker", 4)
        };
        private static readonly List<FubarVectors> Area_05_Lesure = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(1690.861f, 4782.232f, 41.41394f,91.20923f), new Vector4(1696.079f, 4785.149f, 42.02031f,94.81688f), "Wonderama Arcade", 15),
            new FubarVectors(5, new Vector4(2693.682f, 4329.551f, 45.17879f,314.0598f), new Vector4(2697.17f, 4324.528f, 45.85202f,47.20548f), "Park View Dinner", 0),
            new FubarVectors(5, new Vector4(2743.023f, 4400.764f, 48.07886f,107.4123f), new Vector4(2744.036f, 4415.992f, 48.62327f,296.9214f), "Big Juice Stand", 0),
            new FubarVectors(5, new Vector4(2426.81f, 3781.272f, 39.21531f,318.89f), new Vector4(2438.925f, 3761.03f, 41.64434f,24.52363f), "Murial thing", 0),
            new FubarVectors(5, new Vector4(1538.11f, 3770.144f, 33.36781f,121.5367f), new Vector4(1529.959f, 3779.147f, 34.51182f,195.6487f), "The Boathouse Sandy Shores", 0),
            new FubarVectors(5, new Vector4(561.875f, 2733.956f, 41.37694f,3.959938f), new Vector4(562.4641f, 2741.33f, 42.86887f,173.6979f), "Animal Ark", 0),
            new FubarVectors(5, new Vector4(1763.216f, 3287.923f, 40.49002f,71.36596f), new Vector4(1759.435f, 3298.968f, 41.96092f,144.6689f), "AirPort", 0)
        };
        private static readonly List<FubarVectors> Area_05_ORP01 = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(-60.07063f, 1959.315f, 189.5029f,118.714f), new Vector4(-43.83769f, 1960.149f, 190.3533f,21.36499f), "", 50),
            new FubarVectors(5, new Vector4(463.1003f, 2606.616f, 42.59025f,7.486252f), new Vector4(470.995f, 2607.702f, 44.4772f,8.536172f), "", 50),
            new FubarVectors(5, new Vector4(497.8976f, 2614.769f, 42.27741f,8.831396f), new Vector4(506.5158f, 2610.732f, 43.68818f,13.93271f), "", 50),
            new FubarVectors(5, new Vector4(968.9386f, 2715.708f, 38.80089f,175.5282f), new Vector4(984.1534f, 2718.711f, 39.50344f,172.3708f), "", 50),
            new FubarVectors(5, new Vector4(993.6621f, 2673.85f, 39.33046f,0.3766021f), new Vector4(980.5497f, 2666.548f, 40.04411f,356.6924f), "", 50),
            new FubarVectors(5, new Vector4(813.7386f, 2179.959f, 51.60617f,343.2384f), new Vector4(803.4117f, 2175.007f, 53.0708f,322.7184f), "", 50),
            new FubarVectors(5, new Vector4(720.6358f, 2339.233f, 49.66687f,90.30038f), new Vector4(722.5844f, 2331.195f, 51.75034f,352.5101f), "", 50),
            new FubarVectors(5, new Vector4(1523.582f, 2233.614f, 74.76787f,171.2222f), new Vector4(1535.616f, 2231.895f, 77.69904f,83.97175f), "", 50),
            new FubarVectors(5, new Vector4(236.3872f, 3105.419f, 41.73588f,184.8902f), new Vector4(241.0598f, 3107.748f, 42.48718f,92.22945f), "", 50),
            new FubarVectors(5, new Vector4(196.6732f, 3038.988f, 43.02736f,274.8384f), new Vector4(195.306f, 3030.964f, 43.88668f,277.7713f), "", 50),
            new FubarVectors(5, new Vector4(237.0881f, 3164.726f, 41.94236f,98.2386f), new Vector4(247.2576f, 3169.09f, 42.79127f,102.7627f), "", 50),
            new FubarVectors(5, new Vector4(-37.65726f, 2864.669f, 58.5313f,66.48999f), new Vector4(-35.49042f, 2871.262f, 59.59824f,156.7449f), "", 50),
            new FubarVectors(5, new Vector4(-263.7923f, 2188.784f, 129.155f,216.862f), new Vector4(-263.9079f, 2195.968f, 130.3988f,238.6304f), "", 50),
            new FubarVectors(5, new Vector4(-283.5657f, 2544.437f, 73.70554f,357.8858f), new Vector4(-287.4019f, 2535.703f, 75.47443f,278.7175f), "", 50),
            new FubarVectors(5, new Vector4(2635.17f, 3263.966f, 54.55294f,231.1293f), new Vector4(2632.344f, 3258.061f, 55.46336f,332.7899f), "", 50),
            new FubarVectors(5, new Vector4(2615.157f, 3267.511f, 54.54915f,250.2655f), new Vector4(2618.491f, 3274.824f, 55.7382f,231.0173f), "", 50),
            new FubarVectors(5, new Vector4(2626.032f, 3288.488f, 54.64927f,223.3137f), new Vector4(2634.398f, 3291.614f, 55.72837f,147.1315f), "", 50),
            new FubarVectors(5, new Vector4(2426.147f, 4010.396f, 36.02813f,243.4933f), new Vector4(2418.775f, 4020.591f, 36.83404f,246.7558f), "", 50),
            new FubarVectors(5, new Vector4(1832.03f, 3748.053f, 32.53752f,300.2946f), new Vector4(1830.884f, 3738.097f, 33.96191f,290.2749f), "", 50),
            new FubarVectors(5, new Vector4(1851.66f, 3768.838f, 32.32976f,122.7865f), new Vector4(1843.261f, 3778.095f, 33.58501f,61.49633f), "", 50),
            new FubarVectors(5, new Vector4(1893.687f, 3812.721f, 31.63893f,213.6467f), new Vector4(1881.175f, 3810.584f, 32.77881f,295.0231f), "", 50),
            new FubarVectors(5, new Vector4(1921.434f, 3815.156f, 31.36322f,122.5019f), new Vector4(1925.061f, 3824.4f, 32.43999f,213.7845f), "", 50),
            new FubarVectors(5, new Vector4(1449.517f, 3652.83f, 33.71304f,20.3736f), new Vector4(1435.8f, 3657.095f, 34.34364f,293.7834f), "", 50),
            new FubarVectors(5, new Vector4(3713.465f, 4522.436f, 20.95025f,149.0632f), new Vector4(3725.4f, 4525.177f, 22.4705f,178.5197f), "", 50),
            new FubarVectors(5, new Vector4(3696.032f, 4558.43f, 24.75818f,176.8189f), new Vector4(3688.897f, 4562.733f, 25.18305f,267.1775f), "", 50),
            new FubarVectors(5, new Vector4(3792.868f, 4469.359f, 5.038733f,71.94101f), new Vector4(3807.896f, 4478.277f, 6.365377f,210.3574f), "", 50),
            new FubarVectors(5, new Vector4(3333.444f, 5159.47f, 17.62036f,152.5844f), new Vector4(3310.9f, 5176.172f, 19.61458f,236.721f), "", 50),
            new FubarVectors(5, new Vector4(2213.701f, 5607.016f, 53.39285f,13.87942f), new Vector4(2221.507f, 5614.481f, 54.90165f,96.0819f), "", 50),
            new FubarVectors(5, new Vector4(1670.854f, 4751.54f, 41.19155f,290.69f), new Vector4(1664.081f, 4739.884f, 42.00737f,284.8084f), "", 50),
            new FubarVectors(5, new Vector4(1715.069f, 4668.863f, 42.41995f,84.59276f), new Vector4(1718.772f, 4677.138f, 43.6558f,90.96929f), "", 50),
            new FubarVectors(5, new Vector4(1685.134f, 4681.097f, 42.3722f,268.2254f), new Vector4(1683.134f, 4689.38f, 43.06541f,271.9297f), "", 50),
            new FubarVectors(5, new Vector4(1682.39f, 4651.135f, 42.68787f,267.54f), new Vector4(1674.162f, 4658.021f, 43.37114f,268.1052f), "", 50),
            new FubarVectors(5, new Vector4(1725.233f, 4630.789f, 42.60341f,117.9296f), new Vector4(1725.087f, 4642.037f, 43.87548f,116.2964f), "", 50),
            new FubarVectors(5, new Vector4(1971.284f, 4641.456f, 40.25161f,39.49141f), new Vector4(1966.769f, 4634.283f, 41.10112f,19.76906f), "", 50),
            new FubarVectors(5, new Vector4(1422.55f, 4379.623f, 43.32235f,335.7315f), new Vector4(1429.65f, 4377.926f, 44.59929f,41.46988f), "", 50),
            new FubarVectors(5, new Vector4(1368.005f, 4365.023f, 43.64425f,80.47865f), new Vector4(1365.839f, 4358.577f, 44.50069f,328.2971f), "", 50),
            new FubarVectors(5, new Vector4(1342.655f, 4366.59f, 43.6447f,268.793f), new Vector4(1338.447f, 4359.707f, 44.36736f,310.4155f), "", 50),
            new FubarVectors(5, new Vector4(766.3184f, 4182.986f, 39.97334f,10.9133f), new Vector4(775.9548f, 4183.997f, 41.78099f,91.86606f), "", 50),
            new FubarVectors(5, new Vector4(749.3324f, 4194.625f, 40.12261f,297.5035f), new Vector4(749.6724f, 4184.149f, 41.08787f,79.96129f), "", 50),
            new FubarVectors(5, new Vector4(711.0807f, 4178.596f, 40.02594f,272.4257f), new Vector4(710.9149f, 4185.534f, 41.08266f,82.2551f), "", 50)
        };
        private static readonly List<FubarVectors> Area_05_Houses01 = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(210.1642f, 3090.199f, 41.52552f,186.9827f), new Vector4(191.2667f, 3082.234f, 43.47282f,270.879f), "", 50),
            new FubarVectors(5, new Vector4(213.1609f, 2442.334f, 57.71969f,353.6272f), new Vector4(201.382f, 2442.185f, 60.44843f,259.5346f), "", 50),
            new FubarVectors(5, new Vector4(1410.965f, 2168.687f, 96.68143f,9.950741f), new Vector4(1401.1f, 2170.03f, 97.84595f,263.4691f), "", 50)
        };
        private static readonly List<FubarVectors> Area_05_Trailer = new List<FubarVectors>
        {
            new FubarVectors(5, new Vector4(1765.214f, 3735.817f, 33.21129f,25.05601f), new Vector4(1774.151f, 3742.661f, 34.65553f,98.51238f), "", 49),
            new FubarVectors(5, new Vector4(1736.423f, 3780.427f, 33.5139f,34.03711f), new Vector4(1745.964f, 3787.988f, 34.8349f,116.4466f), "", 49),
            new FubarVectors(5, new Vector4(1722.505f, 3805.334f, 34.20673f,32.39572f), new Vector4(1733.701f, 3809.047f, 35.11755f,45.40493f), "", 49),
            new FubarVectors(5, new Vector4(1686.589f, 3870.395f, 34.07032f,311.7021f), new Vector4(1691.737f, 3866.07f, 34.90733f,43.68911f), "", 49),
            new FubarVectors(5, new Vector4(1731.907f, 3906.927f, 34.13621f,302.4679f), new Vector4(1737.572f, 3898.144f, 35.55902f,29.18738f), "", 49),
            new FubarVectors(5, new Vector4(1754.658f, 3834.411f, 33.95748f,293.0675f), new Vector4(1763.853f, 3824.102f, 34.76783f,27.45279f), "", 49),
            new FubarVectors(5, new Vector4(1769.251f, 3789.531f, 33.15064f,210.4746f), new Vector4(1777.395f, 3799.745f, 34.52311f,122.6044f), "", 49),
            new FubarVectors(5, new Vector4(1908.883f, 3860.747f, 31.6411f,295.8202f), new Vector4(1908.295f, 3869.448f, 32.88734f,207.8917f), "", 49),
            new FubarVectors(5, new Vector4(1934.862f, 3879.749f, 31.55978f,294.2716f), new Vector4(1936.549f, 3891.254f, 32.74555f,216.7874f), "", 49),
            new FubarVectors(5, new Vector4(1932.039f, 3925.349f, 31.66261f,48.42825f), new Vector4(1915.996f, 3909.04f, 33.44162f,249.2993f), "", 49),
            new FubarVectors(5, new Vector4(2170.153f, 3505.418f, 44.81287f,240.46f), new Vector4(2178.876f, 3496.794f, 45.80801f,37.07502f), "", 49),
            new FubarVectors(5, new Vector4(2167.906f, 3366.573f, 44.741f,298.5942f), new Vector4(2163.077f, 3374.895f, 46.3445f,232.8837f), "", 49),
            new FubarVectors(5, new Vector4(2214.364f, 3309.185f, 45.32296f,274.5385f), new Vector4(2201.183f, 3317.959f, 46.77428f,295.7839f), "", 49),
            new FubarVectors(5, new Vector4(2389.193f, 3296.577f, 46.76574f,317.283f), new Vector4(2389.142f, 3309.994f, 47.64442f,102.5208f), "", 49),
            new FubarVectors(5, new Vector4(2365.944f, 3354.321f, 46.30186f,324.4272f), new Vector4(2379.967f, 3348.711f, 47.95235f,50.32929f), "", 49),
            new FubarVectors(5, new Vector4(2463.822f, 3449.051f, 49.06851f,7.313422f), new Vector4(2484.111f, 3446.059f, 51.06776f,319.3595f), "", 49),
            new FubarVectors(5, new Vector4(1583.336f, 2900.383f, 56.28606f,50.07235f), new Vector4(1585.965f, 2906.779f, 57.78031f,134.9216f), "", 49),
            new FubarVectors(5, new Vector4(880.8928f, 2846.48f, 56.02919f,197.9631f), new Vector4(890.5643f, 2855.02f, 57.0004f,59.97361f), "", 49),
            new FubarVectors(5, new Vector4(871.0219f, 2869.262f, 56.21397f,208.0969f), new Vector4(866.4968f, 2878.248f, 57.66219f,185.3217f), "", 49),
            new FubarVectors(5, new Vector4(856.77f, 2849.451f, 57.00512f,238.3338f), new Vector4(851.5347f, 2857.857f, 58.16793f,131.1327f), "", 49),
            new FubarVectors(5, new Vector4(401.2711f, 2970.299f, 40.29823f,313.8675f), new Vector4(412.2772f, 2965.316f, 41.88805f,44.31476f), "", 49),
            new FubarVectors(5, new Vector4(415.3914f, 2993.899f, 39.80676f,21.21057f), new Vector4(429.4552f, 2993.749f, 40.95049f,336.2627f), "", 49),
            new FubarVectors(5, new Vector4(356.9668f, 2959.126f, 40.34517f,278.5339f), new Vector4(361.6231f, 2976.848f, 41.62027f,135.0839f), "", 49),
            new FubarVectors(5, new Vector4(518.8219f, 3068.951f, 39.30341f,244.3655f), new Vector4(524.215f, 3080.348f, 40.66409f,144.7467f), "", 49),
            new FubarVectors(5, new Vector4(497.7601f, 3090.597f, 39.77259f,219.0439f), new Vector4(508.9041f, 3099.896f, 41.3079f,52.09034f), "", 49),
            new FubarVectors(5, new Vector4(2718.658f, 4280.65f, 46.56981f,15.36451f), new Vector4(2728.343f, 4280.497f, 48.96114f,94.36501f), "", 49),
            new FubarVectors(5, new Vector4(2647.277f, 4256.177f, 44.08927f,311.5473f), new Vector4(2639.269f, 4246.507f, 44.76425f,32.78054f), "", 49),
            new FubarVectors(5, new Vector4(339.8885f, 2568.616f, 43.01343f,209.9237f), new Vector4(347.9032f, 2565.829f, 43.51953f,154.1575f), "", 49),
            new FubarVectors(5, new Vector4(357.9027f, 2573.105f, 43.01195f,212.2821f), new Vector4(366.4412f, 2571.349f, 44.15535f,140.4081f), "", 49),
            new FubarVectors(5, new Vector4(374.7534f, 2578.578f, 43.01174f,200.3093f), new Vector4(382.4335f, 2576.571f, 44.31788f,103.3933f), "", 49),
            new FubarVectors(5, new Vector4(396.2495f, 2586.7f, 43.01234f,211.9296f), new Vector4(403.9676f, 2584.545f, 43.51953f,94.73278f), "", 49),
            new FubarVectors(5, new Vector4(558.5499f, 2597.517f, 42.32529f,27.80989f), new Vector4(564.1797f, 2598.489f, 43.65111f,118.6104f), "", 49),
            new FubarVectors(5, new Vector4(99.26064f, 3689.665f, 39.16183f,267.7242f), new Vector4(97.66538f, 3682.25f, 39.73311f,3.088732f), "", 49),
            new FubarVectors(5, new Vector4(98.72874f, 3739.19f, 39.10487f,351.1088f), new Vector4(90.83179f, 3745.28f, 40.77061f,243.4313f), "", 49),
            new FubarVectors(5, new Vector4(83.40933f, 3735.859f, 39.20393f,57.13585f), new Vector4(78.39098f, 3732.541f, 40.27309f,307.182f), "", 49),
            new FubarVectors(5, new Vector4(82.27306f, 3750.208f, 39.20332f,172.6217f), new Vector4(76.76093f, 3757.168f, 39.75488f,276.4821f), "", 49)
        };
        private static readonly List<Vector4> Area_05_MotelPark = new List<Vector4>
        {
            new Vector4(1137.536f, 2664.08f, 37.32592f, 181.0784f),
            new Vector4(323.5481f, 2625.84f, 43.81615f, 224.1798f)
        };
        private static readonly List<Vector4> Area_05_MotelDoor00 = new List<Vector4>
        {
            new Vector4(1141.901f, 2664.379f, 38.16087f, 83.64488f),
            new Vector4(1142.164f, 2654.711f, 38.15077f, 78.6659f),
            new Vector4(1142.053f, 2651.339f, 38.14091f, 88.07667f),
            new Vector4(1141.742f, 2643.745f, 38.1437f, 83.9623f),
            new Vector4(1141.241f, 2642.173f, 38.1437f, 8.256227f),
            new Vector4(1136.357f, 2641.996f, 38.14375f, 349.6029f),
            new Vector4(1132.836f, 2641.901f, 38.14375f, 50.77026f),
            new Vector4(1125.295f, 2642.275f, 38.14375f, 355.2648f),
            new Vector4(1121.719f, 2641.923f, 38.14375f, 341.4791f),
            new Vector4(1114.876f, 2642.008f, 38.14375f, 349.2509f),
            new Vector4(1107.261f, 2642.019f, 38.14375f, 356.7132f),
            new Vector4(1106.17f, 2648.989f, 38.14092f, 238.9385f),
            new Vector4(1106.621f, 2652.625f, 38.14092f, 275.6601f)
        };//The Motor Motel
        private static readonly List<Vector4> Area_05_MotelDoor01 = new List<Vector4>
        {
            new Vector4(317.0916f, 2623.098f, 44.45858f, 314.3125f),
            new Vector4(341.2312f, 2615.505f, 44.67187f, 26.89154f),
            new Vector4(346.59f, 2618.46f, 44.68267f, 33.18755f),
            new Vector4(354.1001f, 2620.098f, 44.67238f, 11.91594f),
            new Vector4(359.6617f, 2623.066f, 44.67698f, 32.11134f),
            new Vector4(367.0589f, 2624.98f, 44.67188f, 30.06653f),
            new Vector4(372.0863f, 2628.08f, 44.68298f, 43.04009f),
            new Vector4(379.3406f, 2629.705f, 44.67236f, 41.16113f),
            new Vector4(385.0788f, 2632.712f, 44.67915f, 24.36839f),
            new Vector4(392.1373f, 2634.773f, 44.66687f, 34.05609f),
            new Vector4(397.7713f, 2637.325f, 44.67674f, 31.84803f)
        };//Eastern Motel

        private static readonly List<FubarVectors> Area_06_Facility = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(80.28289f, 6793.423f, 19.18406f,114.3696f), new Vector4(16.7625f, 6826.294f, 15.81299f,245.8412f), "", 253),
            new FubarVectors(6, new Vector4(3357.027f, 5502.37f, 18.79266f,340.9354f), new Vector4(3392.028f, 5508.464f, 26.24716f,84.42635f), "", 253)
        };
        private static readonly List<FubarVectors> Area_06_BikerBiz = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-159.007f, 6338.24f, 31.12371f,226.2142f), new Vector4(-163.5544f, 6334.683f, 31.58081f,314.4818f), "", 100),//Forg
			new FubarVectors(6, new Vector4(60.25886f, 6463.389f, 30.94577f,134.9132f), new Vector4(51.73696f, 6486.035f, 31.42852f,298.242f), "", 101),//Coke
			new FubarVectors(6, new Vector4(425.2387f, 6531.069f, 27.33143f,355.1008f), new Vector4(412.9549f, 6539.131f, 27.73209f,337.2498f), "", 102),//Weed
			new FubarVectors(6, new Vector4(-412.0774f, 6177.574f, 31.09886f,226.4102f), new Vector4(-413.6765f, 6171.536f, 31.4782f,313.3743f), "", 103),//Cash
			new FubarVectors(6, new Vector4(84.82642f, 6326.077f, 30.85461f,27.7413f), new Vector4(90.75479f, 6340.379f, 31.37587f,115.5961f), "", 104)//Meth
        };
        private static readonly List<FubarVectors> Area_06_OnineApps = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-2205.945f, 4248.757f, 46.86387f,35.91669f), new Vector4(-2205.664f, 4242.877f, 48.2797f,48.22973f), "2000 Great Ocean Highway", 52),
            new FubarVectors(6, new Vector4(-244.0425f, 6237.475f, 30.80112f,226.1291f), new Vector4(-252.1004f, 6235.035f, 31.48921f,227.8413f), "1 Strawberry Ave", 52),
            new FubarVectors(6, new Vector4(-294.7468f, 6338.973f, 31.55339f,43.93359f), new Vector4(-302.3819f, 6327.095f, 32.8872f,38.04961f), "4401 Procopio Drv", 51),
            new FubarVectors(6, new Vector4(-104.2227f, 6533.657f, 29.12038f,47.80323f), new Vector4(-105.6748f, 6528.679f, 30.16694f,335.9423f), "4584 Procopio Drv", 51),
            new FubarVectors(6, new Vector4(-12.21089f, 6564.014f, 31.26414f,224.5186f), new Vector4(-15.11612f, 6557.34f, 33.24039f,314.2951f), "0232 Paleto Blvd", 50),
            new FubarVectors(6, new Vector4(-70.84333f, 6428.631f, 30.75062f,44.96909f), new Vector4(-72.89036f, 6422.281f, 31.49044f,32.35375f), "142 Paleto Blvd", 52),
            new FubarVectors(6, new Vector4(-33.614f,6422.542f,30.936f, -133.651f), new Vector4(-38.862f, 6420.109f, 31.495f, -137.457f), "Paleto Bay Clubhouse", 98),
            new FubarVectors(6, new Vector4(-355.844f,6067.92f,30.991f, 44.613f), new Vector4(-358.498f, 6061.767f, 31.503f, 45.702f), "Paleto Bay Clubhouse", 97)
        };
        private static readonly List<FubarVectors> Area_06_OpenDoors = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-115.4362f, 6457.042f, 30.88188f,47.08554f), new Vector4(-106.3606f, 6467.541f, 31.62671f, 133.0373f), "Blane County Savings Bank", 280),
            new FubarVectors(6, new Vector4(1728.684f, 6404.32f, 33.90487f,328.1208f), new Vector4(1733.94f, 6416.054f, 35.03723f, 151.134f), "Mount Chiliad 247", 281),
            new FubarVectors(6, new Vector4(-4.750896f, 6519.73f, 30.72139f,134.0989f), new Vector4(2.783439f, 6511.771f, 31.87785f, 46.42364f), "Paleto Discount Store", 282),
            new FubarVectors(6, new Vector4(-287.0311f, 6239.045f, 30.71052f,317.3276f), new Vector4(-278.0275f, 6228.142f, 31.69554f, 36.53393f), "Paleto Herr Cuts", 283),
            new FubarVectors(6, new Vector4(-286.9377f, 6203.463f, 30.76218f,225.9471f), new Vector4(-292.7247f, 6197.131f, 31.48898f, 303.4717f), "Paleto Tattoo", 284),
            new FubarVectors(6, new Vector4(-317.7563f, 6070.117f, 30.62072f,135.3976f), new Vector4(-330.332f, 6081.203f, 31.45477f, 222.2751f), "Paleto Amunation", 285)
        };
        private static readonly List<FubarVectors> Area_06_Resurant = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-401.8344f, 6053.771f, 30.92324f,316.7726f), new Vector4(-406.613f, 6062.742f, 31.5001f,140.1622f), "Paleto Liquor", 0),
            new FubarVectors(6, new Vector4(-294.5432f, 6211.214f, 30.75711f,223.52f), new Vector4(-302.463f, 6211.412f, 31.42391f,358.3274f), "Paleto Bakery", 0),
            new FubarVectors(6, new Vector4(-152.7778f, 6331.061f, 30.90351f,225.924f), new Vector4(-156.1602f, 6327.101f, 31.58083f,322.4745f), "Del Vecchio", 0),
            new FubarVectors(6, new Vector4(-130.6671f, 6395.042f, 30.78203f,312.637f), new Vector4(-122.8121f, 6389.807f, 32.17765f,46.02439f), "Mojito Inn", 0),
            new FubarVectors(6, new Vector4(1582.336f, 6448.078f, 24.50702f,334.9029f), new Vector4(1590.799f, 6450.771f, 25.31715f,146.4556f), "Paleto Up N Atom", 0)
        };
        private static readonly List<FubarVectors> Area_06_BunkerWare = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-398.1481f, 4291.621f, 53.20945f,264.4828f), new Vector4(-389.0248f, 4341.285f, 56.12383f,186.3475f), "Canyon Bunker", 4),
            new FubarVectors(6, new Vector4(-682.0676f, 5948.211f, 14.77343f,359.0253f), new Vector4(-756.9236f, 5943.083f, 19.95851f,287.1425f), "Paleto Bunker", 4)
        };
        private static readonly List<FubarVectors> Area_06_Lesure = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-255.6569f, 6208.085f, 30.98176f,225.2061f), new Vector4(-247.9378f, 6213.014f, 31.93902f,123.5019f), "Pixel Pete’s Arcade", 15),
            new FubarVectors(6, new Vector4(-294.1626f, 6249.164f, 30.72167f,134.9213f), new Vector4(-300.2277f, 6256.018f, 31.51536f,225.5349f), "The Hen House", 0),
            new FubarVectors(6, new Vector4(-772.0259f, 5582.968f, 32.90866f,353.3476f), new Vector4(-753.8062f, 5579.039f, 36.70966f,85.15111f), "Pala Springs", 0),
            new FubarVectors(6, new Vector4(-1577.345f, 5162.247f, 19.09356f,354.2f), new Vector4(-1570.877f, 5181.699f, 17.87541f,97.38361f), "Sonar Collections Dock", 0),
            new FubarVectors(6, new Vector4(-1506.972f, 4974.33f, 61.88164f,173.1442f), new Vector4(-1490.438f, 4981.577f, 63.35223f,104.2569f), "Raton Canyon Trails", 0),
            new FubarVectors(6, new Vector4(-2208.826f, 4285.978f, 47.60767f,354.5725f), new Vector4(-2193.241f, 4290.038f, 49.17439f,57.5366f), "Hookies", 0),
            new FubarVectors(6, new Vector4(1596.805f, 6567.973f, 13.04277f,195.728f), new Vector4(1564.031f, 6602.471f, 11.14433f,240.469f), "Paleto Cove", 0),
            new FubarVectors(6, new Vector4(-257.1559f, 6286.706f, 30.72035f,134.4333f), new Vector4(-262.7965f, 6291.057f, 31.49262f,216.0372f), "Bay Bar", 0)
        };
        private static readonly List<FubarVectors> Area_06_ORP = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-378.2895f, 6183.842f, 30.91386f,224.1558f), new Vector4(-374.3609f, 6191.076f, 31.72955f,213.7215f), "", 50),
            new FubarVectors(6, new Vector4(-365.457f, 6197.103f, 30.91161f,224.8345f), new Vector4(-356.9607f, 6207.465f, 31.84228f,217.4898f), "", 50),
            new FubarVectors(6, new Vector4(-348.5826f, 6216.824f, 30.9116f,223.0872f), new Vector4(-347.2804f, 6225.171f, 31.88411f,228.8832f), "", 50),
            new FubarVectors(6, new Vector4(-354.3269f, 6263.537f, 30.90641f,14.65497f), new Vector4(-359.9115f, 6260.599f, 31.91941f,323.9963f), "", 50),
            new FubarVectors(6, new Vector4(-382.342f, 6268.489f, 30.21799f,42.81025f), new Vector4(-379.9861f, 6252.66f, 31.85119f,329.2118f), "", 50),
            new FubarVectors(6, new Vector4(-439.0626f, 6204.78f, 28.98327f,273.5947f), new Vector4(-468.124f, 6206.047f, 29.55284f,19.22442f), "", 50),
            new FubarVectors(6, new Vector4(-432.1454f, 6265.637f, 29.70366f,250.108f), new Vector4(-437.9515f, 6272.258f, 30.06829f,350.2123f), "", 50),
            new FubarVectors(6, new Vector4(-434.3738f, 6260.266f, 29.63981f,252.5641f), new Vector4(-447.9078f, 6260.229f, 30.04783f,148.9435f), "", 50),
            new FubarVectors(6, new Vector4(-395.0632f, 6310.881f, 28.47791f,223.1733f), new Vector4(-407.3616f, 6314.171f, 28.94115f,215.9467f), "", 50),
            new FubarVectors(6, new Vector4(-355.2157f, 6335.14f, 29.25954f,223.3189f), new Vector4(-367.9648f, 6341.555f, 29.84363f,222.3839f), "", 50),
            new FubarVectors(6, new Vector4(-315.4155f, 6312.906f, 31.74133f,44.73646f), new Vector4(-332.5182f, 6302.069f, 33.09311f,32.35503f), "", 50),
            new FubarVectors(6, new Vector4(-269.8477f, 6357.037f, 31.82169f,42.61639f), new Vector4(-280.4556f, 6350.621f, 32.60081f,42.18668f), "", 50),
            new FubarVectors(6, new Vector4(-255.3885f, 6360.959f, 30.9038f,44.32188f), new Vector4(-247.6346f, 6370.081f, 31.84554f,56.12477f), "", 50),
            new FubarVectors(6, new Vector4(-265.0267f, 6405.287f, 30.37198f,206.1364f), new Vector4(-272.6486f, 6400.961f, 31.50496f,212.3271f), "", 50),
            new FubarVectors(6, new Vector4(-220.1924f, 6383.631f, 31.02857f,43.73579f), new Vector4(-227.2453f, 6377.636f, 31.75924f,42.31236f), "", 50),
            new FubarVectors(6, new Vector4(-233.0658f, 6420.51f, 30.6535f,220.3545f), new Vector4(-246.0963f, 6414.247f, 31.46059f,142.2568f), "", 50),
            new FubarVectors(6, new Vector4(-206.001f, 6406.523f, 31.24026f,42.05452f), new Vector4(-213.5712f, 6396.188f, 33.08514f,50.19847f), "", 50),
            new FubarVectors(6, new Vector4(-225.3319f, 6435.872f, 30.62032f,226.2794f), new Vector4(-229.7038f, 6445.498f, 31.19744f,141.6786f), "", 50),
            new FubarVectors(6, new Vector4(-192.2425f, 6415.839f, 31.28901f,312.2372f), new Vector4(-188.8396f, 6409.688f, 32.29678f,43.08266f), "", 50),
            new FubarVectors(6, new Vector4(-50.10324f, 6626.888f, 29.45157f,215.9371f), new Vector4(-41.61409f, 6637.372f, 31.08751f,221.6378f), "", 50),
            new FubarVectors(6, new Vector4(-37.89799f, 6589.47f, 30.19251f,38.65286f), new Vector4(-37.54647f, 6578.901f, 32.40085f,311.2406f), "", 50),
            new FubarVectors(6, new Vector4(-13.37525f, 6603.816f, 30.85353f,38.64811f), new Vector4(-26.40973f, 6597.367f, 31.86078f,43.14886f), "", 50),
            new FubarVectors(6, new Vector4(-4.842309f, 6616.701f, 30.89397f,31.55751f), new Vector4(1.710805f, 6612.73f, 32.07975f,26.80808f), "", 50),
            new FubarVectors(6, new Vector4(-16.48819f, 6646.774f, 30.54872f,206.0879f), new Vector4(-9.496887f, 6654.269f, 31.70242f,206.7057f), "", 50),
            new FubarVectors(6, new Vector4(21.86651f, 6660.181f, 30.94708f,184.5206f), new Vector4(35.40755f, 6663.105f, 32.19041f,157.8432f), "", 50),
            new FubarVectors(6, new Vector4(35.83234f, 6607.108f, 31.89514f,250.3097f), new Vector4(31.2813f, 6596.776f, 32.82225f,225.4272f), "", 50),
            new FubarVectors(6, new Vector4(13.81533f, 6585.716f, 31.89092f,223.9284f), new Vector4(11.62843f, 6578.257f, 33.0708f,230.5704f), "", 50),
            new FubarVectors(6, new Vector4(1504.038f, 6331.375f, 23.40549f,331.9838f), new Vector4(1510.509f, 6325.985f, 24.60712f,55.61734f), "", 50)
        };
        private static readonly List<FubarVectors> Area_06_Houses = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-158.0542f, 6387.678f, 30.74843f,314.7758f), new Vector4(-163.573f, 6391.004f, 31.49041f,235.8759f), "", 50),
            new FubarVectors(6, new Vector4(-123.7499f, 6551.424f, 28.85083f,131.8334f), new Vector4(-130.7302f, 6551.915f, 29.87156f,224.5959f), "", 50)
        };
        private static readonly List<FubarVectors> Area_06_Trailer = new List<FubarVectors>
        {
            new FubarVectors(6, new Vector4(-461.1739f, 6353.91f, 11.54082f,128.5604f), new Vector4(-453.3034f, 6337.092f, 12.90174f,36.97087f), "", 49),
            new FubarVectors(6, new Vector4(-498.0558f, 6266.711f, 10.86822f,69.41565f), new Vector4(-480.7773f, 6266.287f, 13.6347f,146.6928f), "", 49),
            new FubarVectors(6, new Vector4(1530.674f, 6331.024f, 23.78022f,242.9402f), new Vector4(1539.068f, 6322.357f, 24.62131f,3.718354f), "", 49)
        };
        private static readonly List<Vector4> Area_06_MotelPark = new List<Vector4>
        {
			new Vector4(-697.4598f, 5773.269f, 16.7534f, 245.2474f),
			new Vector4(-83.85841f, 6347.774f, 30.91297f, 311.4191f)
        };
        private static readonly List<Vector4> Area_06_MotelDoor00 = new List<Vector4>
        {
			new Vector4(-682.0905f, 5770.712f, 17.511f, 63.03827f),
			new Vector4(-684.0535f, 5767.05f, 17.51099f, 60.76522f),
			new Vector4(-686.1412f, 5763.157f, 17.511f, 68.21182f),
			new Vector4(-687.3856f, 5759.004f, 17.511f, 65.68383f),
			new Vector4(-690.1364f, 5759.421f, 17.511f, 333.1052f),
			new Vector4(-693.9597f, 5761.636f, 17.511f, 335.4544f),
			new Vector4(-698.0567f, 5763.238f, 17.511f, 333.4504f),
			new Vector4(-702.0898f, 5765.127f, 17.511f, 335.5873f),
			new Vector4(-706.0761f, 5766.91f, 17.511f, 344.3052f),
			new Vector4(-709.9121f, 5768.795f, 17.511f, 335.56f)
        };//Bayview Lodge Motel
        private static readonly List<Vector4> Area_06_MotelDoor01 = new List<Vector4>
        {
			new Vector4(-103.3542f, 6330.606f, 31.57619f, 321.4492f),
			new Vector4(-106.3932f, 6334.104f, 31.57619f, 309.546f),
			new Vector4(-107.6332f, 6339.684f, 31.57589f, 219.9751f),
			new Vector4(-98.88927f, 6348.512f, 31.57589f, 223.022f),
			new Vector4(-93.42107f, 6353.735f, 31.57589f, 230.1771f),
			new Vector4(-90.24675f, 6357.187f, 31.57589f, 236.2295f),
			new Vector4(-84.70812f, 6362.653f, 31.57589f, 218.2001f),
			new Vector4(-84.82089f, 6362.477f, 35.50074f, 226.2313f),
			new Vector4(-90.14465f, 6357.135f, 35.50074f, 216.084f),
			new Vector4(-93.55036f, 6353.894f, 35.50074f, 219.7831f),
			new Vector4(-99.01492f, 6348.434f, 35.50074f, 222.2154f),
			new Vector4(-102.2993f, 6345.122f, 35.50074f, 222.8366f),
			new Vector4(-107.6412f, 6339.703f, 35.50074f, 219.7248f),
			new Vector4(-106.4945f, 6333.821f, 35.50074f, 335.946f),
			new Vector4(-103.3255f, 6330.785f, 35.50074f, 315.0953f)
        };//Dream View Motel

        public static List<FubarVectors> Area_08_Resurant = new List<FubarVectors>();
        public static List<FubarVectors> Area_08_Lesure = new List<FubarVectors>();
        public static List<FubarVectors> Area_08_Houses = new List<FubarVectors>();

        public static List<FubarVectors> Area_09_Resurant = new List<FubarVectors>();
        public static List<FubarVectors> Area_09_Lesure = new List<FubarVectors>();
        public static List<FubarVectors> Area_09_Houses = new List<FubarVectors>();

        public static List<MuliRace> MyRacists = new List<MuliRace>
        {
            new MuliRace(99, 4, "StuntPlane", false, true, true, 40f, new Vector3(-808.957f, -1558.815f, 6.031153f), new Vector4(-810.1065f, -1603.461f, 0.21f, 131.772f), new Vector4(), new Vector4(), new Vector4(), new Vector4(), new List<RacePaths> { new RacePaths(12, new Vector3(-950.820f, -1735.458f, 22.489f), new Vector3(8.272f, -0.254f, 132.431f)), new RacePaths(39, new Vector3(-1275.255f, -1922.070f, 28.301f), new Vector3(8.000f, 86.000f, 83.621f)), new RacePaths(40, new Vector3(-1468.287f, -1490.143f, 18.771f), new Vector3(2.000f, 180.000f, 40.294f)), new RacePaths(37, new Vector3(-1679.912f, -1228.457f, 19.233f), new Vector3(-1.085f, -1.610f, 50.773f)), new RacePaths(37, new Vector3(-1796.581f, -1125.285f, 32.135f), new Vector3(28.001f, -0.236f, 49.891f)), new RacePaths(12, new Vector3(-1871.937f, -1063.460f, 155.259f), new Vector3(68.680f, -2.054f, 48.819f)), new RacePaths(12, new Vector3(-1849.807f, -1077.995f, 272.656f), new Vector3(44.093f, -179.432f, -131.301f)), new RacePaths(12, new Vector3(-1726.098f, -1181.471f, 299.550f), new Vector3(-7.196f, 179.837f, -128.353f)), new RacePaths(39, new Vector3(-1565.411f, -1280.330f, 195.168f), new Vector3(-27.030f, 92.005f, -141.914f)), new RacePaths(39, new Vector3(-1558.528f, -1492.128f, 119.338f), new Vector3(-25.030f, 92.005f, 156.452f)), new RacePaths(39, new Vector3(-1759.686f, -1646.097f, 65.351f), new Vector3(-25.030f, 92.005f, 62.986f)), new RacePaths(39, new Vector3(-1909.021f, -1429.437f, 36.931f), new Vector3(0.970f, 92.005f, -9.056f)), new RacePaths(38, new Vector3(-1799.171f, -1187.908f, 45.705f), new Vector3(5.711f, -88.000f, -36.602f)), new RacePaths(38, new Vector3(-1738.079f, -1111.885f, 42.603f), new Vector3(5.711f, -88.000f, -42.894f)), new RacePaths(38, new Vector3(-1699.320f, -886.933f, 41.742f), new Vector3(5.711f, -88.000f, 13.497f)), new RacePaths(38, new Vector3(-1936.271f, -649.050f, 32.022f), new Vector3(5.711f, -88.000f, 80.995f)), new RacePaths(38, new Vector3(-2108.346f, -736.160f, 20.703f), new Vector3(5.711f, -88.000f, 164.359f)), new RacePaths(40, new Vector3(-1887.449f, -1053.449f, 32.425f), new Vector3(0.000f, 179.999f, -132.072f)), new RacePaths(37, new Vector3(-1770.408f, -1149.919f, 32.101f), new Vector3(-0.903f, 1.494f, -128.503f)), new RacePaths(16, new Vector3(-1678.321f, -1231.946f, 29.172f), new Vector3(-6.504f, 178.914f, -126.308f)) }, new List<PropLists> { new PropLists("stt_prop_stunt_bblock_huge_02", new Vector3(-837.200867f, -1628.32861f, -0.25f), new Vector3(0.0f, 0.0f, -47.1415977f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1776.057f, -1191.622f, -1.361f), new Vector3(0f, 0f, -40.316f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1730.057f, -1139.622f, -1.361f), new Vector3(0f, 0f, -40.316f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1765.057f, -1110.622f, -1.361f), new Vector3(0f, 0f, 139.684f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1811.057f, -1162.622f, -1.361f), new Vector3(0f, 0f, 139.684f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1848.057f, -1040.622f, -1.361f), new Vector3(0f, 0f, -40.316f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1892.057f, -1089.622f, -1.361f), new Vector3(0f, 0f, -40.316f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1702.358f, -1254.521f, -1.361f), new Vector3(0f, 0f, 139.684f)), new PropLists("ar_prop_inflategates_cp_h2", new Vector3(-1658.858f, -1201.821f, -1.361f), new Vector3(0f, 0f, 139.684f)), new PropLists("prop_ind_barge_02", new Vector3(-819.915039f, -1612.55334f, -5.71f), new Vector3(0.0f, 179.99f, 132.76f)),new PropLists("lts_prop_lts_ramp_02", new Vector3(-864.004f, -1658.239f, -0.068f), new Vector3(0f, 0f, 133.107f)), new PropLists("lts_prop_lts_ramp_02", new Vector3(-866.689f, -1655.490f, -0.068f), new Vector3(0f, 0f, 133.107f)), new PropLists("lts_prop_lts_ramp_02", new Vector3(-869.257f, -1652.746f, -0.068f), new Vector3(0f, 0f, 133.107f))  }, new List<int> { 31 }, new RacingLines()),
            new MuliRace(98, 1, "FacBikes", false, false, false, 5f, new Vector3(472.929f,4791.097f,-58.899f), new Vector4(476.443f,4789.914f,-58.464f,13.619f), new Vector4(488.409f,4794.678f,-58.464f,15.434f), new Vector4(485.809f,4793.978f,-58.464f,15.434f), new Vector4(487.209f,4788.973f,-58.464f,15.434f), new Vector4(489.809f,4789.673f,-58.464f,15.434f),  new List<RacePaths> { new RacePaths(6, new Vector3(484.364f,4806.157f,-57.088f), new Vector3(0.870f,0.001f,15.967f)), new RacePaths(6, new Vector3(477.993f,4829.181f,-57.655f), new Vector3(0f,0f,14.400f)), new RacePaths(7, new Vector3(476.726f,4842.396f,-54.793f), new Vector3(1.259f,-0.003f,96.589f)), new RacePaths(6, new Vector3(459.428f,4823.196f,-54.856f), new Vector3(0.606f,0.002f,-164.933f)), new RacePaths(7, new Vector3(477.820f,4768.574f,-54.794f), new Vector3(0.965f,0.003f,-100.509f)), new RacePaths(7, new Vector3(504.707f,4775.921f,-54.795f), new Vector3(1.095f,0.021f,5.368f)), new RacePaths(6, new Vector3(493.096f,4825.248f,-59.258f), new Vector3(0.732f,0.005f,31.879f)), new RacePaths(7, new Vector3(475.732f,4835.286f,-59.795f), new Vector3(1.043f,-0.007f,114.990f)), new RacePaths(7, new Vector3(464.177f,4820.877f,-59.799f), new Vector3(1.504f,-0.001f,93.732f)), new RacePaths(6, new Vector3(431.603f,4821.399f,-58.464f), new Vector3(0.652f,-0.009f,91.074f)), new RacePaths(6, new Vector3(404.060f,4823.454f,-59.861f), new Vector3(0.797f,-0.001f,76.393f)), new RacePaths(6, new Vector3(371.690f,4830.628f,-59.861f), new Vector3(0.637f,-0.003f,85.907f)), new RacePaths(7, new Vector3(342.564f,4836.062f,-59.802f), new Vector3(1.027f,-0.001f,27.913f)), new RacePaths(7, new Vector3(335.990f,4850.230f,-59.803f), new Vector3(1.042f,0.001f,-36.038f)), new RacePaths(7, new Vector3(342.214f,4859.668f,-59.802f), new Vector3(1.552f,0.000f,53.082f)), new RacePaths(7, new Vector3(327.282f,4871.673f,-59.797f), new Vector3(1.469f,0.000f,131.718f)), new RacePaths(6, new Vector3(329.640f,4860.099f,-63.462f), new Vector3(0.635f,0.006f,-114.751f)), new RacePaths(6, new Vector3(356.018f,4850.417f,-63.463f), new Vector3(0.555f,-0.001f,-111.938f)), new RacePaths(8, new Vector3(414.690f,4839.476f,-63.449f), new Vector3(-1.750f,2.253f,108.143f)), new RacePaths(7, new Vector3(395.364f,4835.121f,-59.802f), new Vector3(0.874f,-0.008f,179.838f)), new RacePaths(7, new Vector3(396.168f,4825.157f,-59.802f), new Vector3(1.531f,0.004f,-101.620f)), new RacePaths(6, new Vector3(422.220f,4820.998f,-59.862f), new Vector3(0.614f,0.010f,-90.740f)), new RacePaths(6, new Vector3(438.318f,4820.791f,-59.862f), new Vector3(0.625f,0.010f,-90.740f)), new RacePaths(6, new Vector3(465.456f,4818.120f,-59.861f), new Vector3(0.788f,0.002f,-80.129f)), new RacePaths(8, new Vector3(490.666f,4814.463f,-55.026f), new Vector3(0.781f,0.001f,105.869f)), new RacePaths(6, new Vector3(475.716f,4810.514f,-54.926f), new Vector3(0.760f,0.000f,-74.427f)) }, new List<PropLists>{ new PropLists("lts_prop_lts_ramp_03", new Vector3(479.463f, 4823.661f, -59.345f), new Vector3(0f, 0f, 14.070f)), new PropLists("prop_pipe_single_01", new Vector3(476.561f, 4829.523f, -55.785f), new Vector3(28.350f, 0f, 14.584f)), new PropLists("prop_pipe_single_01", new Vector3(477.201f, 4829.689f, -55.785f), new Vector3(28.350f, 0f, 14.584f)), new PropLists("prop_pipe_single_01", new Vector3(477.832f, 4829.855f, -55.785f), new Vector3(28.350f, 0f, 14.584f)), new PropLists("prop_pipe_single_01", new Vector3(478.462f, 4830.031f, -55.785f), new Vector3(28.350f, 0f, 14.584f)), new PropLists("prop_pipe_single_01", new Vector3(479.093f, 4830.178f, -55.785f), new Vector3(28.360f, 0.000f, 14.584f)), new PropLists("prop_ld_cable", new Vector3(475.747f, 4832.692f, -53.429f), new Vector3(0f, 0f, 15.202f)), new PropLists("prop_ld_cable", new Vector3(478.275f, 4833.396f, -53.403f), new Vector3(0f, 0f, 15.202f)), new PropLists("prop_skate_halfpipe_cr", new Vector3(482.678f, 4812.400f, -59.979f), new Vector3(0f, 0f, -165f)), new PropLists("prop_skate_kickers_cr", new Vector3(484.659f, 4804.676f, -61.10f), new Vector3(0f, 0f, 15.122f)), new PropLists("prop_skate_funbox_cr", new Vector3(461.552f, 4799.221f, -54.945f), new Vector3(0f, 0f, -165.186f)), new PropLists("prop_tyre_wall_01b", new Vector3(507.289f, 4790.684f, -54.994f), new Vector3(0f, 0f, -23.880f)), new PropLists("prop_tyre_wall_01b", new Vector3(510.801f, 4790.404f, -54.994f), new Vector3(0f, 0f, 5.576f)), new PropLists("prop_tyre_wall_01b", new Vector3(514.467f, 4790.720f, -54.994f), new Vector3(0f, 0f, 9.644f)), new PropLists("prop_skate_funbox_cr", new Vector3(431.028f, 4821.423f, -59.951f), new Vector3(0f, 0f, 90.264f)), new PropLists("prop_tyre_wall_01b", new Vector3(378.787f, 4831.806f, -59.999f), new Vector3(0f, 0f, -9.496f)), new PropLists("prop_tyre_wall_01b", new Vector3(378.319f, 4827.122f, -59.999f), new Vector3(0f, 0f, 129.899f)), new PropLists("prop_tyre_wall_01b", new Vector3(354.512f, 4835.975f, -59.999f), new Vector3(0f, 0f, -32.733f)), new PropLists("prop_tyre_wall_01b", new Vector3(351.283f, 4838.171f, -59.999f), new Vector3(0f, 0f, -36.932f)), new PropLists("prop_tyre_wall_01b", new Vector3(348.359f, 4840.128f, -59.999f), new Vector3(0f, 0f, -38.343f)), new PropLists("prop_tyre_wall_01b", new Vector3(344.122f, 4844.176f, -59.999f), new Vector3(0f, 0f, -45.475f)), new PropLists("prop_tyre_wall_01b", new Vector3(336.092f, 4843.034f, -59.999f), new Vector3(0f, 0f, 98.605f)), new PropLists("prop_tyre_wall_01b", new Vector3(335.852f, 4839.104f, -59.999f), new Vector3(0f, 0f, 63.598f)), new PropLists("prop_tyre_wall_01b", new Vector3(343.241f, 4860.563f, -60.000f), new Vector3(0f, 0f, -34.545f)), new PropLists("prop_offroad_tyres02", new Vector3(327.130f, 4873.351f, -59.821f), new Vector3(0f, 0f, -137.976f)), new PropLists("prop_tyre_wall_01b", new Vector3(329.288f, 4862.634f, -63.599f), new Vector3(0f, 0f, 5.666f)), new PropLists("prop_tyre_wall_01b", new Vector3(334.904f, 4864.982f, -63.599f), new Vector3(0f, 0f, 31.769f)), new PropLists("prop_tyre_wall_01b", new Vector3(338.492f, 4866.335f, -63.599f), new Vector3(0f, 0f, 13.330f)), new PropLists("prop_offroad_tyres02", new Vector3(348.401f, 4846.239f, -63.421f), new Vector3(0f, 0f, -119.351f)), new PropLists("prop_skate_rail_cr", new Vector3(350.939f, 4855.262f, -63.592f), new Vector3(0f, 0f, -115.131f)), new PropLists("prop_offroad_tyres02", new Vector3(355.631f, 4853.594f, -63.421f), new Vector3(0f, 0f, -114.235f)), new PropLists("prop_offroad_tyres02", new Vector3(353.395f, 4848.629f, -63.421f), new Vector3(0f, 0f, -114.235f)), new PropLists("prop_skate_spiner_cr", new Vector3(380.879f, 4839.423f, -65.292f), new Vector3(0f, 0f, 83.799f)), new PropLists("prop_offroad_tyres02", new Vector3(396.195f, 4835.667f, -63.421f), new Vector3(0f, 0f, -89.774f)), new PropLists("prop_offroad_tyres02", new Vector3(393.257f, 4840f, -63.421f), new Vector3(0f, 0f, 90.974f)), new PropLists("prop_offroad_tyres02", new Vector3(393.207f, 4845.631f, -63.421f), new Vector3(0f, 0f, 90.633f)), new PropLists("prop_skate_quartpipe_cr", new Vector3(416.009f, 4839.686f, -64.533f), new Vector3(0f, 0f, -89.827f)), new PropLists("prop_offroad_tyres02", new Vector3(412.184f, 4844.176f, -63.421f), new Vector3(0f, 0f, -0.181f)), new PropLists("prop_offroad_tyres02", new Vector3(408.960f, 4844.187f, -63.421f), new Vector3(0f, 0f, -0.181f)), new PropLists("prop_offroad_tyres02", new Vector3(402.748f, 4838.164f, -63.421f), new Vector3(0f, 0f, 88.587f)), new PropLists("prop_offroad_tyres02", new Vector3(395.390f, 4837.662f, -59.821f), new Vector3(0f, 0f, 178.954f)) }, new List<int> { 21 }, new RacingLines("FacBikes", 21, 77503,new Vector3(485.809f, 4793.978f, -58.464f), new List<RaceRec>{ new RaceRec(6.60288572f, new Vector3(484.55954f, 4803.837f, -57.63575f)), new  RaceRec(6.810366f, new Vector3(482.91394f, 4813.2085f, -58.71592f)), new  RaceRec(9.926009f, new Vector3(479.374664f, 4822.76855f, -58.0980034f)), new  RaceRec(9.753051f, new Vector3(478.157532f, 4827.36f, -56.1031227f)), new  RaceRec(9.206915f, new Vector3(477.079773f, 4831.625f, -53.7186546f)), new  RaceRec(6.57452345f, new Vector3(476.416229f, 4836.48828f, -52.66934f)), new  RaceRec(7.48631144f, new Vector3(474.888733f, 4840.988f, -54.43063f)), new  RaceRec(8.116463f, new Vector3(469.8402f, 4841.3833f, -54.6258354f)), new  RaceRec(10.312541f, new Vector3(465.841827f, 4838.33838f, -54.6139641f)), new  RaceRec(11.8087883f, new Vector3(462.041931f, 4835.06348f, -54.61358f)), new  RaceRec(12.7790527f, new Vector3(458.635132f, 4831.22852f, -54.6222229f)), new  RaceRec(12.299943f, new Vector3(456.610168f, 4826.45459f, -54.6309f)), new  RaceRec(12.1913f, new Vector3(457.146179f, 4821.314f, -54.6279526f)), new  RaceRec(13.0194969f, new Vector3(458.955963f, 4816.594f, -54.6254044f)), new  RaceRec(13.55836f, new Vector3(460.889435f, 4811.86328f, -54.6148148f)), new  RaceRec(13.5562572f, new Vector3(462.275757f, 4807.03662f, -54.641304f)), new  RaceRec(13.9544678f, new Vector3(463.617767f, 4802.24365f, -53.7341652f)), new  RaceRec(12.6927347f, new Vector3(464.924255f, 4797.446f, -52.2041664f)), new  RaceRec(12.7940111f, new Vector3(466.2371f, 4792.57764f, -52.3147545f)), new  RaceRec(14.1710548f, new Vector3(467.522644f, 4787.95459f, -54.1044922f)), new  RaceRec(13.9987545f, new Vector3(469.435944f, 4782.608f, -54.6394424f)), new  RaceRec(14.4703541f, new Vector3(471.5497f, 4778.07031f, -54.6264343f)), new  RaceRec(14.6932487f, new Vector3(474.350983f, 4773.7876f, -54.6265f)), new  RaceRec(14.5892982f, new Vector3(477.9253f, 4770.141f, -54.630867f)), new  RaceRec(14.5301294f, new Vector3(482.30835f, 4767.588f, -54.6315f)), new  RaceRec(14.4362831f, new Vector3(487.206177f, 4766.438f, -54.6327553f)), new  RaceRec(14.0180693f, new Vector3(492.3833f, 4766.90967f, -54.632534f)), new  RaceRec(13.9468327f, new Vector3(496.899567f, 4769.221f, -54.6324844f)), new  RaceRec(13.9891033f, new Vector3(500.7421f, 4772.63428f, -54.63064f)), new  RaceRec(13.9030142f, new Vector3(503.328278f, 4777f, -54.6331f)), new  RaceRec(13.8462019f, new Vector3(504.205872f, 4781.958f, -54.6335f)), new  RaceRec(14.1955395f, new Vector3(503.786224f, 4787.07f, -54.640316f)), new  RaceRec(14.4071836f, new Vector3(503.035736f, 4792.038f, -54.6911278f)), new  RaceRec(14.7003231f, new Vector3(501.5319f, 4796.89648f, -54.925705f)), new  RaceRec(14.960948f, new Vector3(500.223755f, 4801.88135f, -55.66408f)), new  RaceRec(16.4753819f, new Vector3(499.1916f, 4806.72f, -56.5699f)), new  RaceRec(16.64891f, new Vector3(498.149628f, 4811.792f, -57.4864922f)), new  RaceRec(16.6436367f, new Vector3(497.107056f, 4816.87842f, -58.4016533f)), new  RaceRec(16.4958916f, new Vector3(496.0072f, 4821.72461f, -59.07264f)), new  RaceRec(16.0515614f, new Vector3(494.456757f, 4826.58252f, -59.03756f)), new  RaceRec(15.2129726f, new Vector3(491.889526f, 4831.13232f, -59.0282059f)), new  RaceRec(13.9319715f, new Vector3(488.091034f, 4834.727f, -59.0324974f)), new  RaceRec(13.41151f, new Vector3(483.2839f, 4836.618f, -59.0658569f)), new  RaceRec(13.6191912f, new Vector3(478.264923f, 4837.56934f, -59.5673256f)), new  RaceRec(12.9561872f, new Vector3(473.278778f, 4836.81152f, -59.639595f)), new  RaceRec(11.8346338f, new Vector3(469.2518f, 4833.647f, -59.63438f)), new  RaceRec(10.8356819f, new Vector3(467.076141f, 4829.13965f, -59.6181145f)), new  RaceRec(10.7312851f, new Vector3(464.4219f, 4824.8833f, -59.6268539f)), new  RaceRec(10.5509386f, new Vector3(460.00592f, 4822.19727f, -59.62226f)), new  RaceRec(10.037034f, new Vector3(455.2397f, 4820.38867f, -59.632885f)), new  RaceRec(11.1993961f, new Vector3(450.252045f, 4820.99756f, -59.6225548f)), new  RaceRec(12.1606045f, new Vector3(445.1711f, 4821.122f, -59.6272278f)), new  RaceRec(12.7855492f, new Vector3(440.0884f, 4820.04541f, -59.61927f)), new  RaceRec(13.27394f, new Vector3(434.896942f, 4820.11035f, -59.3720169f)), new  RaceRec(11.5518217f, new Vector3(430.167267f, 4821.355f, -57.81779f)), new  RaceRec(11.1741724f, new Vector3(425.252563f, 4822.47559f, -57.8302956f)), new  RaceRec(10.3116074f, new Vector3(420.5568f, 4823.485f, -59.6587677f)), new  RaceRec(10.6781111f, new Vector3(415.7017f, 4821.861f, -59.62816f)), new  RaceRec(11.65317f, new Vector3(410.67215f, 4821.69f, -59.626358f)), new  RaceRec(12.6287642f, new Vector3(405.6838f, 4822.29248f, -59.6259651f)), new  RaceRec(13.3183031f, new Vector3(400.798737f, 4823.837f, -59.6266975f)), new  RaceRec(13.8862734f, new Vector3(395.870819f, 4825.57f, -59.62077f)), new  RaceRec(14.3397532f, new Vector3(390.887573f, 4826.98242f, -59.6215363f)), new  RaceRec(14.6772881f, new Vector3(385.988251f, 4828.33936f, -59.622f)), new  RaceRec(14.8779354f, new Vector3(380.95813f, 4829.54932f, -59.6255455f)), new  RaceRec(14.8812895f, new Vector3(375.9193f, 4830.13428f, -59.632164f)), new  RaceRec(14.8738251f, new Vector3(370.871246f, 4829.55566f, -59.6267738f)), new  RaceRec(14.8730021f, new Vector3(365.6907f, 4829.564f, -59.62338f)), new  RaceRec(15.0804262f, new Vector3(360.4511f, 4829.82f, -59.62252f)), new  RaceRec(15.2241259f, new Vector3(355.405518f, 4830.10449f, -59.6233864f)), new  RaceRec(14.5935736f, new Vector3(350.372437f, 4831.43457f, -59.63625f)), new  RaceRec(13.1333218f, new Vector3(346.3292f, 4834.428f, -59.63419f)), new  RaceRec(12.48954f, new Vector3(342.765961f, 4838.061f, -59.6213951f)), new  RaceRec(10.5612268f, new Vector3(339.763123f, 4842.19531f, -59.632473f)), new  RaceRec(9.553254f, new Vector3(338.022675f, 4846.97168f, -59.619854f)), new  RaceRec(7.86879158f, new Vector3(338.34375f, 4851.97461f, -59.6259041f)), new  RaceRec(6.644776f, new Vector3(340.892548f, 4856.37256f, -59.61714f)), new  RaceRec(2.955863f, new Vector3(339.872284f, 4861.29443f, -59.6142769f)), new  RaceRec(6.66048241f, new Vector3(335.904633f, 4864.49756f, -59.6161346f)), new  RaceRec(6.052969f, new Vector3(332.367462f, 4868.14453f, -59.6163673f)), new  RaceRec(4.69424057f, new Vector3(328.485138f, 4871.316f, -59.6201744f)), new  RaceRec(4.36184931f, new Vector3(323.814484f, 4869.401f, -59.6143456f)), new  RaceRec(6.20188427f, new Vector3(324.549744f, 4864.43848f, -60.5624275f)), new  RaceRec(9.35222f, new Vector3(327.609222f, 4861.249f, -63.0900154f)), new  RaceRec(10.3478222f, new Vector3(332.393158f, 4859.52441f, -63.22776f)), new  RaceRec(11.86228f, new Vector3(337.258759f, 4858.24756f, -63.22106f)), new  RaceRec(12.88466f, new Vector3(342.0446f, 4856.707f, -63.22121f)), new  RaceRec(13.584918f, new Vector3(346.8061f, 4855.123f, -63.2219467f)), new  RaceRec(13.3801031f, new Vector3(351.2123f, 4852.661f, -63.23172f)), new  RaceRec(12.2905693f, new Vector3(355.569916f, 4850.109f, -63.22359f)), new  RaceRec(10.3315992f, new Vector3(360.553558f, 4849.605f, -63.2358131f)), new  RaceRec(9.320824f, new Vector3(365.612335f, 4850.19531f, -63.224575f)), new  RaceRec(10.5021658f, new Vector3(370.365082f, 4848.19434f, -63.2279129f)), new  RaceRec(10.97248f, new Vector3(374.900421f, 4845.859f, -63.2198448f)), new  RaceRec(10.1963654f, new Vector3(379.626129f, 4843.9f, -63.2218361f)), new  RaceRec(8.883924f, new Vector3(384.597168f, 4842.62549f, -63.2241631f)), new  RaceRec(8.586231f, new Vector3(389.602173f, 4842.643f, -63.21776f)), new  RaceRec(10.1180658f, new Vector3(394.692047f, 4842.284f, -63.21862f)), new  RaceRec(11.6156092f, new Vector3(399.761261f, 4842.53f, -63.2205658f)), new  RaceRec(11.8452559f, new Vector3(404.925354f, 4843.001f, -63.2199974f)), new  RaceRec(11.038743f, new Vector3(410.0686f, 4843.089f, -63.2239838f)), new  RaceRec(9.937561f, new Vector3(414.989929f, 4842.18164f, -62.9451675f)), new  RaceRec(6.45421267f, new Vector3(415.040924f, 4837.155f, -63.0888367f)), new  RaceRec(5.91453266f, new Vector3(410.055145f, 4836.535f, -63.2185478f)), new  RaceRec(8.682779f, new Vector3(404.955048f, 4836.61572f, -63.21984f)), new  RaceRec(6.006323f, new Vector3(400.306824f, 4835.949f, -61.4622765f)), new  RaceRec(1.964096f, new Vector3(395.6733f, 4835.7417f, -59.5727272f)), new  RaceRec(6.490314f, new Vector3(395.027f, 4830.75049f, -59.6150742f)), new  RaceRec(8.304976f, new Vector3(398.049469f, 4826.75049f, -59.6234741f)), new  RaceRec(10.3838f, new Vector3(402.560364f, 4824.51855f, -59.628624f)), new  RaceRec(11.8904266f, new Vector3(407.4466f, 4823.312f, -59.61902f)), new  RaceRec(12.7764282f, new Vector3(412.539978f, 4822.45264f, -59.6267f)), new  RaceRec(13.3528061f, new Vector3(417.581116f, 4822.51074f, -59.6283226f)), new  RaceRec(13.8242931f, new Vector3(422.700439f, 4823.34326f, -59.6211433f)), new  RaceRec(13.6313963f, new Vector3(427.713562f, 4823.315f, -59.1733932f)), new  RaceRec(11.86805f, new Vector3(432.586945f, 4821.997f, -57.9601f)), new  RaceRec(11.9395313f, new Vector3(437.436554f, 4820.572f, -58.5257721f)), new  RaceRec(9.943092f, new Vector3(442.273926f, 4819.74f, -59.6470528f)), new  RaceRec(11.4309053f, new Vector3(447.308533f, 4819.39f, -59.62453f)), new  RaceRec(12.4627085f, new Vector3(452.4173f, 4820.13574f, -59.62393f)), new  RaceRec(13.0986881f, new Vector3(457.50882f, 4820.19434f, -59.6245346f)), new  RaceRec(13.771925f, new Vector3(462.665863f, 4819.95947f, -59.6199226f)), new  RaceRec(14.177228f, new Vector3(467.7937f, 4819.602f, -59.61949f)), new  RaceRec(13.6077385f, new Vector3(472.8047f, 4818.84473f, -58.9123726f)), new  RaceRec(13.1316662f, new Vector3(477.749146f, 4817.665f, -58.9990234f)), new  RaceRec(12.6344042f, new Vector3(482.688019f, 4816.171f, -58.7025681f)), new  RaceRec(12.6428013f, new Vector3(487.68515f, 4815.90771f, -58.03283f)), new  RaceRec(4.16754341f, new Vector3(489.68277f, 4813.935f, -53.8693352f)), new  RaceRec(8.129792f, new Vector3(489.965637f, 4810.26563f, -57.3626671f)), new  RaceRec(2.87999678f, new Vector3(487.848816f, 4805.98975f, -58.9040337f)), new  RaceRec(5.72036648f, new Vector3(484.169647f, 4809.426f, -58.6846466f)) })),
        };
        public static List<AnimList> MyRaceAnims = new List<AnimList>
        {
            new AnimList("The Bird", "mp_player_int_upperfinger", "mp_player_int_finger_01_enter", "mp_player_int_finger_01", "mp_player_int_finger_01_exit"),
            new AnimList("Up Yours", "mp_player_int_upperfinger", "mp_player_int_finger_02_enter", "mp_player_int_finger_02", "mp_player_int_finger_02_exit"),
            new AnimList("Fist", "mp_player_int_upperup_yours", "mp_player_int_up_yours_enter", "mp_player_int_up_yours", "mp_player_int_up_yours_exit"),
            new AnimList("Rock", "mp_player_int_upperrock", "mp_player_int_rock_enter", "mp_player_int_rock", "mp_player_int_rock_exit"),
            new AnimList("Salute", "mp_player_int_uppersalute", "mp_player_int_salute_enter", "mp_player_int_salute", "mp_player_int_salute_exit"),
            new AnimList("Jerk", "mp_player_int_upperwank", "mp_player_int_wank_01_enter", "mp_player_int_wank_01", "mp_player_int_wank_01_exit"),
            new AnimList("Grab Crotch", "mp_player_int_uppergrab_crotch", "mp_player_int_grab_crotch_enter", "mp_player_int_grab_crotch", "mp_player_int_grab_crotch_exit"),
            new AnimList("Peace Sign", "mp_player_int_upperpeace_sign", "mp_player_int_peace_sign_enter", "mp_player_int_peace_sign", "mp_player_int_peace_sign_exit"),
            new AnimList("Smoke", "mp_player_int_uppersmoke", "mp_player_int_smoke_enter", "mp_player_int_smoke", "mp_player_int_smoke_exit"),
            new AnimList("Squeeze", "mp_player_int_uppertit_squeeze", "mp_player_int_tit_squeeze_enter", "mp_player_int_tit_squeeze", "mp_player_int_tit_squeeze_exit"),
            new AnimList("Victory Sign", "mp_player_int_upperv_sign", "mp_player_int_v_sign_enter", "mp_player_int_v_sign", "mp_player_int_v_sign_exit"),
            new AnimList("Crew:Bro Love", "mp_player_int_upperbro_love", "mp_player_int_bro_love_enter", "mp_player_int_bro_love", "mp_player_int_bro_love_exit")
        };

        public static readonly List<PropLists> HangerCrates = new List<PropLists>
        {
            new PropLists("prop_byard_rampold",new Vector3(-1268.60071f, -2989.09888f, -47.4413223f),new Vector3(0.00f, -15.99998f, 90.0000076f)),
            new PropLists("prop_byard_rampold",new Vector3(-1265.59998f, -2989.00122f, -47.4513245f),new Vector3(-1.62844391e-12f, -15.9999866f, 89.9999466f)),
            new PropLists("prop_byard_rampold",new Vector3(-1268.60071f, -2993.09888f, -49.6413193f),new Vector3(-2.03555488e-13f, -10.999958f, 90.0000076f)),
            new PropLists("prop_byard_rampold",new Vector3(-1265.59998f, -2993.00122f, -49.6513214f),new Vector3(-2.44266586e-12f, -10.9999733f, 89.9999466f)),
            new PropLists("xs_prop_arena_jump_s_01a_sf",new Vector3(-1269.00061f, -2987.99976f, -49.5800133f),new Vector3(0f, -0f, 90.0000305f)),
            new PropLists("xs_prop_arena_jump_s_01a_sf",new Vector3(-1265.00012f, -2988.00024f, -49.5800323f),new Vector3(0f, 0f, 89.9999847f)),
            new PropLists("sm_prop_smug_cont_01a",new Vector3(-1223.34656f, -2983.521f, -49.4882088f),new Vector3(0f, 0f, -86.9425354f)),
            new PropLists("sm_prop_smug_crate_l_antiques",new Vector3(-1237.84485f, -3017.78809f, -49.4900513f),new Vector3(0f, -0f, -179.749634f)),
            new PropLists("sm_prop_smug_crate_l_bones",new Vector3(-1240.39331f, -3017.87109f, -49.4900513f),new Vector3(0f, -0f, 178.602859f)),
            new PropLists("sm_prop_smug_crate_l_fake",new Vector3(-1237.14258f, -3011.97144f, -49.4900169f),new Vector3(0f, 0f, -89.7429733f)),
            new PropLists("sm_prop_smug_crate_l_hazard",new Vector3(-1237.15356f, -3009.50244f, -49.4899788f),new Vector3(0f, 0f, -89.7429733f)),
            new PropLists("sm_prop_smug_crate_l_jewellery",new Vector3(-1242.77014f, -3006.91821f, -49.4899979f),new Vector3(0f, -0f, 90.5718384f)),
            new PropLists("sm_prop_smug_crate_l_medical",new Vector3(-1242.93164f, -3009.39648f, -49.4900055f),new Vector3(0f, -0f, 90.8473129f)),
            new PropLists("sm_prop_smug_crate_l_narc",new Vector3(-1242.8949f, -3011.90527f, -49.4900513f),new Vector3(0f, -0f, 90.8473129f)),
            new PropLists("sm_prop_smug_crate_l_tobacco",new Vector3(-1236.98523f, -3006.91919f, -49.4897461f),new Vector3(0f, -0f, -90.2349396f)),
            new PropLists("sm_prop_smug_crate_m_antiques",new Vector3(-1239.61304f, -3001.05786f, -49.4898033f),new Vector3(0f, 0f, 0.0608037151f)),
            new PropLists("sm_prop_smug_crate_m_bones",new Vector3(-1236.90576f, -3001.05664f, -49.4896851f),new Vector3(0f, 0f, 0.0608037151f)),
            new PropLists("sm_prop_smug_crate_m_fake",new Vector3(-1234.37158f, -3001.05469f, -49.4896851f),new Vector3(0f, 0f, 0.356079221f)),
            new PropLists("sm_prop_smug_crate_m_hazard",new Vector3(-1230.43408f, -3005.19019f, -49.4896851f),new Vector3(0f, -0f, -90.4965286f)),
            new PropLists("sm_prop_smug_crate_m_jewellery",new Vector3(-1230.42468f, -3007.86548f, -49.4896851f),new Vector3(0f, 0f, -89.5708466f)),
            new PropLists("sm_prop_smug_crate_m_medical",new Vector3(-1229.60645f, -3013.51978f, -49.4896851f),new Vector3(0f, 0f, -89.6288147f)),
            new PropLists("sm_prop_smug_crate_m_narc",new Vector3(-1229.60522f, -3016.04346f, -49.4896851f),new Vector3(0f, 0f, -89.6288147f)),
            new PropLists("sm_prop_smug_crate_m_tobacco",new Vector3(-1224.99756f, -3014.08276f, -49.4896851f),new Vector3(0f, -0f, -90.3560791f))
        };
        public static readonly List<PropLists> GunsGunsGuns = new List<PropLists>
        {
            new PropLists("w_sg_assaultshotgun",new Vector3(2545.89355f, -275.365295f, -58.3848877f),new Vector3(90.00f, 93.8479309f, 0.00f)),
            new PropLists("w_sg_bullpupshotgun",new Vector3(2545.75317f, -274.823669f, -58.1840553f),new Vector3(-1.17f, -103.999596f, -4.15173674f)),
            new PropLists("w_sg_heavyshotgun",new Vector3(2545.91846f, -276.031555f, -58.4080276f),new Vector3(82.3188934f, 86.8486404f, -179.999893f)),
            new PropLists("w_sg_pumpshotgun",new Vector3(2545.74683f, -275.28479f, -58.3580399f),new Vector3(89.0116653f, 97.3485565f, -179.999893f)),
            new PropLists("w_sr_marksmanrifle_luxe",new Vector3(2546.19897f, -276.064301f, -58.4580803f),new Vector3(-90.00f, -88.3821411f, 0.00f)),
            new PropLists("w_sr_heavysniper",new Vector3(2545.74829f, -275.0495f, -58.3127403f),new Vector3(-1.7075f, -67.9997787f, 136.381866f)),
            new PropLists("w_sb_smg_luxe",new Vector3(2546.20142f, -274.816589f, -58.4481735f),new Vector3(89.0355072f, -165.617645f, -34.99897f)),
            new PropLists("w_sb_pdw",new Vector3(2545.72339f, -275.481598f, -58.3581886f),new Vector3(90.00f, 44.3887863f, 0.00f)),
            new PropLists("w_sb_microsmg_luxe",new Vector3(2546.10791f, -274.962585f, -58.3630333f),new Vector3(90.00f, 89.3884735f, 0.00f)),
            new PropLists("w_sb_gusenberg",new Vector3(2546.06055f, -275.701691f, -58.3607788f),new Vector3(-1.6008255e-07f, 4.99999905f, 86.3419571f)),
            new PropLists("w_sb_assaultsmg",new Vector3(2545.99243f, -275.792053f, -58.2390366f),new Vector3(82.0028381f, -112.999687f, -0.267053485f)),
            new PropLists("w_pi_stungun",new Vector3(2545.79565f, -275.031219f, -58.4463501f),new Vector3(85.9494247f, -127.26741f, -6.04322759e-06f)),
            new PropLists("w_pi_sns_pistol",new Vector3(2546.04272f, -274.99411f, -58.4657516f),new Vector3(-89.0000458f, -121.168396f, -180.00f)),
            new PropLists("w_pi_pistol_luxe",new Vector3(2545.82642f, -275.455688f, -58.445755f),new Vector3(90.00f, 127.488113f, 0.00f)),
            new PropLists("w_pi_pistol",new Vector3(2545.86401f, -275.164948f, -58.445755f),new Vector3(89.0043564f, -148.496658f, 174.000092f)),
            new PropLists("w_pi_heavypistol",new Vector3(2545.99316f, -275.525726f, -58.4336166f),new Vector3(79.0040894f, -90.0001831f, 14.5752745f)),
            new PropLists("w_pi_flaregun",new Vector3(2545.93604f, -275.049866f, -58.4563332f),new Vector3(89.0010223f, 0.999995351f, -23.1672688f)),
            new PropLists("w_pi_appistol",new Vector3(2545.93335f, -275.680267f, -58.4322815f),new Vector3(-81.6061096f, -98.0002213f, 9.91467857f)),
            new PropLists("w_mg_minigun",new Vector3(2545.86475f, -276.285889f, -58.3389816f),new Vector3(-40.0005836f, 12.9999914f, 13.7287359f)),
            new PropLists("w_mg_mg",new Vector3(2545.90796f, -274.775269f, -58.2189941f),new Vector3(8.53f, -115.999908f, -11.2055416f)),
            new PropLists("w_me_hatchet",new Vector3(2546.07715f, -275.347565f, -58.3256454f),new Vector3(89.4898605f, 122.000175f, 103.440681f)),
            new PropLists("w_me_bat",new Vector3(2545.79419f, -275.838562f, -58.5338631f),new Vector3(-5f, -23.0000687f, -3.62017989f)),
            new PropLists("w_lr_rpg",new Vector3(2545.81665f, -275.983185f, -58.2445793f),new Vector3(4.268868e-07f, 69.9999924f, -18.6529751f)),
            new PropLists("w_lr_grenadelauncher",new Vector3(2546.07056f, -275.628326f, -58.1718636f),new Vector3(-24f, -3.0f, 104.484489f)),
            new PropLists("w_ar_musket",new Vector3(2545.93994f, -275.265839f, -58.1728325f),new Vector3(33.9999847f, -64.9998779f, -74.9909821f))
        };

        private static readonly List<FubarVectors> Offices = new List<FubarVectors>
        {
            new FubarVectors(2, new Vector4(-75.10117f, -819.2855f, 326.1752f, 0f), new Vector4(-75.07004f, -824.8751f, 321.2919f, 0f), "", -1),
            new FubarVectors(2, new Vector4(-144.6091f, -593.4995f, 211.7752f, 0f), new Vector4(-136.1827f, -596.647f, 206.9157f, 0f), "", -1),
            new FubarVectors(2, new Vector4(-1391.722f, -477.6622f, 91.25081f, 0f), new Vector4(-1369.462f, -471.949f, 84.44692f, 0f), "", -1),
            new FubarVectors(2, new Vector4(-1582.136f, -569.4719f, 116.3276f, 0f), new Vector4(-1561.048f, -569.0844f, 114.4493f, 0f), "", -1)
        };
        
        private static readonly List<Vector4> HospArea01 = new List<Vector4>
        {
            new Vector4(-330.3919f, -1314.416f, 31.54471f, 273.0504f),
            new Vector4(-348.1886f, -1313.717f, 31.3999f, 5.583625f),
            new Vector4(-333.9348f, -1309.215f, 31.51347f, 175.482f),
            new Vector4(-56.17741f, -1222.86f, 28.70203f, 275.1887f),
            new Vector4(4.834901f, -1215.057f, 26.70304f, 269.816f),
            new Vector4(156.015f, -1222.109f, 29.5406f, 89.7547f),
            new Vector4(542.5222f, -1602.634f, 28.68385f, 116.9934f),
            new Vector4(-229.8488f, -1542.776f, 31.60123f, 317.7242f),
            new Vector4(-224.6034f, -1536.08f, 31.62743f, 129.4564f),
            new Vector4(-218.3718f, -1528.941f, 31.61087f, 46.66629f),
            new Vector4(-212.2172f, -1521.639f, 31.6046f, 226.4863f),
            new Vector4(-205.6834f, -1513.722f, 31.6342f, 155.3453f),
            new Vector4(-200.0519f, -1507.068f, 31.63043f, 230.4483f),
            new Vector4(8.273157f, -1727.652f, 29.30294f, 34.7168f),
            new Vector4(567.5504f, -1608.766f, 27.73029f, 298.1811f),
            new Vector4(97.80647f, -2064.521f, 18.68202f, 197.3699f),
            new Vector4(-107.2974f, -1849.014f, 5.748287f, 295.0405f),
            new Vector4(-569.3604f, -1693.863f, 20.03664f, 21.84582f),
            new Vector4(-1274.556f, -2033.714f, 2.610979f, 236.5781f),
            new Vector4(750.1906f, -1941.338f, 29.19142f, 352.0004f)
        };
        private static readonly List<Vector4> HospArea02 = new List<Vector4>
        {
            new Vector4(-1154.383f, 74.81805f, 57.36135f, 262.6662f),
            new Vector4(-1097.044f, 68.95171f, 54.0204f, 52.0006f),
            new Vector4(-952.0342f, -77.34787f, 40.06288f, 1.000772f),
            new Vector4(-1103.319f, -115.9167f, 41.55201f, 331.0004f),
            new Vector4(-1236.093f, -4.297109f, 48.25963f, 306.0004f),
            new Vector4(-1185.004f, -230.8945f, 37.9533f, 248.1033f),
            new Vector4(-1552.727f, -263.5375f, 48.26654f, 79.89304f),
            new Vector4(-2040.228f, -371.4984f, 44.10653f, 145.1251f),
            new Vector4(-1357.611f, -595.5609f, 29.25853f, 184.816f),
            new Vector4(-1663.957f, -1110.416f, 13.10031f, 358.8027f),
            new Vector4(-1812.771f, -1222.428f, 19.16961f, 222.9371f),
            new Vector4(-1843.724f, -585.0389f, 19.38138f, 135.7544f),
            new Vector4(-1645.842f, -1016.881f, 6.170813f, 117.794f),
            new Vector4(-1178.519f, -1661.696f, 4.373934f, 287.0045f),
            new Vector4(-1196.971f, -1572.906f, 4.612627f, 34.0125f),
            new Vector4(-1275.074f, -1530.884f, 4.313495f, 54.07441f),
            new Vector4(-1228.104f, -1233.672f, 7.044204f, 28.44425f),
            new Vector4(-950.2644f, -1482.073f, 1.595391f, 196.8771f),
            new Vector4(-931.744f, -724.6157f, 19.91779f, 178.4817f),
            new Vector4(-909.8406f, -716.9461f, 19.91238f, 103.0007f),
            new Vector4(-890.0864f, -854.4204f, 20.56614f, 106.5527f),
            new Vector4(-329.7076f, -444.579f, 33.05147f, 87.63102f),
            new Vector4(366.6699f, -1110.683f, 29.40621f, 221.0002f),
            new Vector4(470.8784f, -1059.474f, 29.21099f, 97.00045f),
            new Vector4(454.8645f, -861.613f, 27.6067f, 127.0002f),
            new Vector4(464.7896f, -530.8228f, 28.53051f, 167.0006f),
            new Vector4(180.8924f, -970.2389f, 29.57924f, 107.0002f),
            new Vector4(485.2414f, -224.6573f, 53.78136f, 167.727f),
            new Vector4(327.7412f, -195.3519f, 54.22644f, 106.4854f),
            new Vector4(-671.3141f, 102.4199f, 55.85542f, 268.2106f)
        };
        private static readonly List<Vector4> HospArea03 = new List<Vector4>
        {
            new Vector4(-1406.192f, 2513.731f, 32.96022f, 241.0171f),
            new Vector4(-1601.453f, 3045.789f, 33.66286f, 95.73833f),
            new Vector4(-2081.298f, 2608.146f, 3.083972f, 354.3986f),
            new Vector4(-1970.047f, 1932.224f, 172.0435f, 237.2855f),
            new Vector4(-1743.91f, 1992.474f, 117.2051f, 249.0004f),
            new Vector4(-1709.715f, 1884.546f, 161.3121f, 130.0006f),
            new Vector4(-1555.444f, 1376.918f, 126.8782f, 0.9996241f),
            new Vector4(-1680.208f, 494.1616f, 128.8704f, 250.0008f),
            new Vector4(-1755.332f, 185.6082f, 64.43859f, 147.0001f),
            new Vector4(-1736.217f, 204.3953f, 64.94281f, 45.0009f),
            new Vector4(-1713.108f, 141.3231f, 64.92459f, 307.0009f),
            new Vector4(-1629.256f, 268.9f, 59.54638f, 139.0005f),
            new Vector4(-2306.207f, 235.1367f, 167.5972f, 116.0008f),
            new Vector4(-1754.722f, -198.7339f, 57.47033f, 337.0007f),
            new Vector4(-2012.42f, -279.8792f, 32.09631f, 290.248f),
            new Vector4(-3034.772f, 32.37837f, 10.11784f, 260.0482f),
            new Vector4(-429.4247f, 1215.803f, 325.754f, 335.0007f),
            new Vector4(-341.2092f, 1305.813f, 336.8865f, 357.0007f),
            new Vector4(201.9303f, 1165.923f, 227.0033f, 133.0002f),
            new Vector4(705.3669f, 1199.944f, 325.1967f, 54.00067f)
        };
        private static readonly List<Vector4> HospArea04 = new List<Vector4>
        {
            new Vector4(1295.991f, -1588.85f, 52.19283f, 317.0007f),
            new Vector4(201.93f, 1165.923f, 227.0009f, 241f),
            new Vector4(705.3665f, 1199.943f, 325.1957f, 357.0005f),
            new Vector4(1220.598f, 1897.427f, 77.92328f, 109.9996f),
            new Vector4(1369.477f, 2184.939f, 97.81877f, 340f),
            new Vector4(2078.363f, 1696.763f, 105.9642f, 253f),
            new Vector4(2887.79f, 1524.084f, 24.96353f, 261f),
            new Vector4(2562.806f, 2574.354f, 37.86728f, 301f),
            new Vector4(1534.691f, 1702.348f, 109.7074f, 297f),
            new Vector4(1566.587f, 860.5251f, 77.51472f, 101f),
            new Vector4(1662.717f, -26.68935f, 173.7701f, 237f),
            new Vector4(2824.429f, -742.3856f, 1.611545f, 329f),
            new Vector4(1132.807f, -798.575f, 57.57723f, 192f),
            new Vector4(836.7168f, -575.6613f, 57.11777f, 130f),
            new Vector4(743.7562f, -220.7275f, 66.10963f, 92.99999f),
            new Vector4(1261.257f, 323.3363f, 81.9865f, 205f)
        };
        private static readonly List<Vector4> HospArea05 = new List<Vector4>
        {
            new Vector4(799.0942f, 4160.361f, 35.2197f, 330f),
            new Vector4(1335.921f, 4269.669f, 31.50255f, 65f),
            new Vector4(1900.041f, 4925.076f, 48.80726f, 131f),
            new Vector4(2381.871f, 5029.653f, 45.95636f, 208f),
            new Vector4(2144.68f, 4775.483f, 40.99186f, 339f),
            new Vector4(2589.505f, 5063.989f, 44.91873f, 297f),
            new Vector4(2853.658f, 4556.799f, 47.17466f, 207f),
            new Vector4(2340.908f, 3125.443f, 48.20813f, 53f),
            new Vector4(2428.426f, 3143.442f, 48.15196f, 159f),
            new Vector4(2057.75f, 3170.67f, 45.35998f, 232.0001f),
            new Vector4(2391.022f, 4297.019f, 35.08884f, 98.63023f),
            new Vector4(2507.502f, 3804.774f, 43.27218f, 42.28845f),
            new Vector4(2050.395f, 3683.347f, 34.58313f, 135f),
            new Vector4(1712.353f, 3844.636f, 35.08882f, 83f),
            new Vector4(1369.891f, 3651.806f, 33.97318f, 266f),
            new Vector4(1628.383f, 3656.517f, 35.12587f, 359f),
            new Vector4(78.56032f, 3706.695f, 41.07229f, 86.99999f),
            new Vector4(953.3123f, 2294.082f, 50.07941f, 299f)
        };
        private static readonly List<Vector4> HospArea06 = new List<Vector4>
        {
            new Vector4(1870.273f, 6408.297f, 46.56796f, 237f),
            new Vector4(1586.865f, 6520.422f, 16.9517f, 296f),
            new Vector4(1442.115f, 6333.458f, 23.89505f, 296f),
            new Vector4(1345.684f, 6387.137f, 33.40578f, 233f),
            new Vector4(176.6928f, 6419.251f, 32.35258f, 335f),
            new Vector4(-325.7654f, 6181.24f, 32.31167f, 193f),
            new Vector4(-436.3317f, 5983.188f, 31.48583f, 106f),
            new Vector4(-791.933f, 5481.721f, 26.55557f, 72f),
            new Vector4(-700.301f, 5448.565f, 40.45741f, 244f),
            new Vector4(-1027.445f, 4710.075f, 239.2366f, 223f),
            new Vector4(-853.9802f, 4830.626f, 297.7597f, 262f),
            new Vector4(-397.1013f, 4700.09f, 263.489f, 272f),
            new Vector4(-523.509f, 4503.75f, 79.59919f, 228f),
            new Vector4(-521.1319f, 4370.738f, 67.45934f, 330f),
            new Vector4(-1354.539f, 4289.695f, 1.940405f, 180f),
            new Vector4(-1564.575f, 4394.226f, 4.732573f, 37f),
            new Vector4(-2129.363f, 4505.476f, 29.58808f, 58f),
            new Vector4(-1014.172f, 4171.244f, 123.6953f, 74.99999f)
        };

        private static readonly List<Vector4> BinFire01 = new List<Vector4>
        {
            new Vector4(-895.383f, -2749.308f, 12.945f,149.430f),
            new Vector4(-870.368f, -2723.651f, 12.945f,-121.258f),
            new Vector4(-724.425f, -2531.304f, 12.946f,-30.636f),
            new Vector4(-705.319f, -2455.045f, 12.945f,-30.080f),
            new Vector4(-618.839f, -2361.132f, 12.956f,144.949f),
            new Vector4(-824.085f, -2095.645f, 7.812f,134.229f),
            new Vector4(-1059.454f, -2089.629f, 12.293f,132.811f),
            new Vector4(-1171.220f, -2042.866f, 12.923f,-149.097f),
            new Vector4(-720.722f, -1506.756f, 4.001f,111.600f),
            new Vector4(-605.097f, -1592.356f, 25.767f,-94.271f),
            new Vector4(-653.259f, -1775.998f, 23.678f,-54.564f),
            new Vector4(-602.789f, -1785.917f, 22.639f,31.886f),
            new Vector4(-591.905f, -1767.259f, 22.186f,124.017f),
            new Vector4(-531.370f, -1781.177f, 20.481f,149.528f),
            new Vector4(-561.894f, -1637.676f, 18.144f,149.454f),
            new Vector4(-548.181f, -2227.627f, 5.395f,-130.222f),
            new Vector4(-459.373f, -2282.676f, 6.609f,-0.544f),
            new Vector4(-357.396f, -2267.686f, 6.609f,178.249f),
            new Vector4(-100.922f, -2241.109f, 6.812f,-0.019f),
            new Vector4(127.002f, -2202.349f, 5.034f,-178.711f),
            new Vector4(401.266f, -2192.661f, 4.918f,117.778f),
            new Vector4(505.293f, -2127.800f, 4.918f,36.188f),
            new Vector4(721.466f, -2091.75f, 28.275f,83.991f),
            new Vector4(-500.913f, -2917.436f, 5.001f,43.857f),
            new Vector4(-77.765f, -2640.616f, 5.035f,-0.277f),
            new Vector4(51.935f, -2719.946f, 5.006f,89.312f),
            new Vector4(162.524f, -2659.655f, 4.997f,-179.062f),
            new Vector4(124.737f, -2857.195f, 5.001f,-90.438f),
            new Vector4(157.070f, -3012.840f, 5.023f,-0.009f),
            new Vector4(222.953f, -3101.135f, 4.791f,90.109f),
            new Vector4(159.955f, -3247.676f, 4.997f,89.166f),
            new Vector4(298.227f, -3251.213f, 4.809f,-94.448f),
            new Vector4(267.712f, -3214.244f, 4.791f,-1.916f),
            new Vector4(267.641f, -3143.441f, 4.791f,83.549f),
            new Vector4(154.592f, -2390.627f, 5.002f,171.509f),
            new Vector4(565.059f, -2723.537f, 5.057f,1.278f),
            new Vector4(579.491f, -2816.701f, 5.057f,55.301f),
            new Vector4(507.497f, -2807.342f, 5.043f,148.915f),
            new Vector4(760.393f, -3228.022f, 5.213f,-89.431f),
            new Vector4(867.773f, -3288.836f, 4.896f,-88.253f),
            new Vector4(795.628f, -2950.002f, 5.021f,-179.434f),
            new Vector4(1295.502f, -3345.195f, 5.028f,-58.795f),
            new Vector4(997.603f, -2543.553f, 27.467f,-94.384f),
            new Vector4(838.340f, -2486.393f, 23.843f,-95.157f),
            new Vector4(1023.632f, -2383.677f, 29.480f,82.361f),
            new Vector4(965.413f, -2366.824f, 29.527f,83.903f),
            new Vector4(985.260f, -2274.937f, 29.510f,85.280f),
            new Vector4(860.587f, -2257.916f, 29.423f,-95.228f),
            new Vector4(953.122f, -2180.851f, 29.552f,-5.289f),
            new Vector4(950.560f, -2102.744f, 29.674f,-1.936f),
            new Vector4(815.362f, -1982.828f, 28.258f,-9.286f),
            new Vector4(881.858f, -2004.198f, 29.469f,176.534f),
            new Vector4(869.974f, -1614.405f, 29.335f,-90.401f),
            new Vector4(919.965f, -1585.943f, 29.363f,-178.818f),
            new Vector4(943.991f, -1580.805f, 29.298f,179.299f),
            new Vector4(992.884f, -1544.221f, 29.812f,90.238f),
            new Vector4(947.729f, -1491.655f, 29.645f,-91.843f),
            new Vector4(774.277f, -1624.925f, 30.165f,-127.164f),
            new Vector4(532.376f, -1766.150f, 27.762f,-72.670f),
            new Vector4(566.024f, -1836.810f, 24.333f,-124.631f),
            new Vector4(446.346f, -1884.310f, 25.969f,44.763f),
            new Vector4(449.107f, -1906.826f, 23.824f,35.819f),
            new Vector4(416.235f, -1900.955f, 24.649f,134.645f),
            new Vector4(451.163f, -1977.669f, 22.187f,131.762f),
            new Vector4(573.680f, -1931.677f, 23.750f,-67.692f),
            new Vector4(389.239f, -1816.261f, 28.015f,39.709f),
            new Vector4(245.736f, -1772.665f, 27.744f,-40.447f),
            new Vector4(189.968f, -1842.925f, 26.206f,51.132f),
            new Vector4(218.370f, -2014.323f, 17.867f,-141.208f),
            new Vector4(117.497f, -1767.302f, 28.336f,139.120f),
            new Vector4(-40.563f, -1754.819f, 28.492f,49.611f),
            new Vector4(-32.191f, -1674.574f, 28.492f,47.221f),
            new Vector4(66.136f, -1625.391f, 28.423f,-42.733f),
            new Vector4(145.579f, -1661.644f, 28.371f,42.471f),
            new Vector4(161.577f, -1652.760f, 28.292f,122.926f),
            new Vector4(172.892f, -1702.640f, 28.292f,-40.222f),
            new Vector4(-361.186f, -1857.333f, 19.527f,-83.811f),
            new Vector4(-352.396f, -1547.976f, 26.721f,0.896f),
            new Vector4(-356.480f, -1489.156f, 29.154f,-89.864f),
            new Vector4(-329.101f, -1317.371f, 30.401f,2.040f),
            new Vector4(-155.785f, -1341.868f, 29.026f,-1.015f),
            new Vector4(-231.741f, -1299.844f, 30.297f,-0.832f),
            new Vector4(-76.104f, -1412.096f, 28.321f,-90.194f),
            new Vector4(-46.884f, -1415.878f, 28.323f,0.633f),
            new Vector4(-30.558f, -1295.313f, 28.317f,90.246f),
            new Vector4(164.989f, -1294.997f, 28.418f,-114.003f),
            new Vector4(67.224f, -1401.931f, 28.357f,-89.871f)
        };
        private static readonly List<Vector4> BinFire02 = new List<Vector4>
        {
            new Vector4(-4.889f, -1086.326f, 25.673f,161.238f),
            new Vector4(10.300f, -1114.388f, 27.858f,-20.474f),
            new Vector4(40.501f, -1017.635f, 28.493f,157.939f),
            new Vector4(-11.627f, -1038.493f, 27.915f,158.496f),
            new Vector4(-96.943f, -968.225f, 20.277f,-18.986f),
            new Vector4(158.386f, -1066.784f, 28.193f,-20.855f),
            new Vector4(118.334f, -1088.370f, 28.226f,-179.177f),
            new Vector4(342.668f, -1079.251f, 28.490f,-90.735f),
            new Vector4(291.579f, -994.964f, 28.282f,-1.130f),
            new Vector4(442.691f, -1060.685f, 28.213f,11.314f),
            new Vector4(454.274f, -935.096f, 27.503f,-91.191f),
            new Vector4(376.770f, -904.144f, 28.413f,90.206f),
            new Vector4(478.051f, -597.389f, 27.500f,-95.744f),
            new Vector4(369.426f, -794.307f, 28.287f,-89.891f),
            new Vector4(47.231f, -829.695f, 30.098f,-20.934f),
            new Vector4(-352.573f, -972.810f, 30.081f,161.142f),
            new Vector4(-453.657f, -969.440f, 22.546f,-89.512f),
            new Vector4(-546.406f, -1232.115f, 17.457f,154.038f),
            new Vector4(-636.273f, -1228.954f, 10.841f,-139.958f),
            new Vector4(-623.634f, -1090.275f, 21.179f,-89.609f),
            new Vector4(-605.097f, -1040.762f, 20.788f,179.696f),
            new Vector4(-595.695f, -979.913f, 21.330f,-179.656f),
            new Vector4(-712.593f, -1131.818f, 9.813f,32.847f),
            new Vector4(-832.049f, -1261.000f, 4.001f,49.056f),
            new Vector4(-711.491f, -973.571f, 19.390f,121.858f),
            new Vector4(-681.618f, -895.071f, 23.500f,-179.469f),
            new Vector4(-576.043f, -904.162f, 24.684f,-179.684f),
            new Vector4(-523.610f, -878.474f, 24.224f,-92.039f),
            new Vector4(-838.480f, -1068.119f, 10.028f,-146.585f),
            new Vector4(-851.991f, -1112.698f, 6.063f,-149.851f),
            new Vector4(-926.399f, -1160.860f, 3.764f,117.839f),
            new Vector4(-1194.066f, -1509.766f, 3.365f,34.367f),
            new Vector4(-1127.732f, -1457.705f, 3.929f,-143.789f),
            new Vector4(-1170.546f, -1400.814f, 3.802f,-147.122f),
            new Vector4(-1215.391f, -1419.771f, 3.284f,-54.870f),
            new Vector4(-1267.125f, -1370.787f, 3.299f,110.520f),
            new Vector4(-1217.282f, -1315.870f, 3.583f,-155.812f),
            new Vector4(-1293.312f, -1320.305f, 3.494f,18.755f),
            new Vector4(-1158.376f, -1267.663f, 5.494f,21.195f),
            new Vector4(-1301.750f, -1247.590f, 3.601f,-72.461f),
            new Vector4(-1224.812f, -1217.197f, 6.118f,-81.109f),
            new Vector4(-1160.542f, -1182.414f, 4.624f,-165.245f),
            new Vector4(-1216.422f, -1057.132f, 7.418f,109.347f),
            new Vector4(-1274.293f, -1100.961f, 6.229f,114.575f),
            new Vector4(-1477.383f, -901.875f, 9.024f,-120.996f),
            new Vector4(-1327.411f, -764.298f, 19.398f,125.937f),
            new Vector4(-1339.443f, -759.231f, 19.341f,35.628f),
            new Vector4(-1335.418f, -744.350f, 21.384f,-51.964f),
            new Vector4(-1279.244f, -838.410f, 15.152f,125.563f),
            new Vector4(-1163.102f, -752.609f, 18.053f,-142.546f),
            new Vector4(-1267.600f, -652.983f, 25.892f,127.819f),
            new Vector4(-1384.900f, -641.908f, 27.674f,34.531f),
            new Vector4(-1428.954f, -664.841f, 25.815f,-54.800f),
            new Vector4(-1314.624f, -595.633f, 27.495f,123.747f),
            new Vector4(-1676.723f, -1067.142f, 12.154f,-39.223f),
            new Vector4(-1645.286f, -985.803f, 6.357f,-132.424f),
            new Vector4(-1528.813f, -399.581f, 40.991f,48.194f),
            new Vector4(-1440.777f, -377.749f, 37.177f,-60.375f),
            new Vector4(-1396.388f, -448.644f, 33.482f,32.389f),
            new Vector4(-1374.834f, -319.436f, 38.573f,28.719f),
            new Vector4(-1414.728f, -245.412f, 45.380f,-48.413f),
            new Vector4(-1314.174f, -252.285f, 40.798f,-152.210f),
            new Vector4(-1340.612f, -209.549f, 42.694f,-144.087f),
            new Vector4(-1161.984f, -223.969f, 37.421f,43.904f),
            new Vector4(-1497.218f, -183.807f, 49.481f,39.766f),
            new Vector4(-982.043f, -272.297f, 37.286f,118.342f),
            new Vector4(-669.027f, -165.854f, 36.827f,31.482f),
            new Vector4(-464.019f, -450.303f, 33.202f,-7.054f),
            new Vector4(-496.878f, -48.753f, 38.973f,-3.150f),
            new Vector4(-355.967f, -109.049f, 37.703f,-19.887f),
            new Vector4(-463.619f, 68.577f, 57.662f,-92.688f),
            new Vector4(-589.801f, 203.129f, 70.542f,0.881f),
            new Vector4(-622.559f, 288.380f, 80.684f,-96.842f),
            new Vector4(-560.639f, 297.516f, 82.034f,174.409f),
            new Vector4(-260.703f, 289.622f, 90.501f,88.577f),
            new Vector4(-295.957f, 312.947f, 92.256f,89.612f),
            new Vector4(-392.962f, 292.207f, 83.892f,-0.192f),
            new Vector4(-280.706f, 204.219f, 84.731f,90.989f),
            new Vector4(-199.981f, 219.754f, 87.233f,-2.277f),
            new Vector4(-181.534f, 323.256f, 96.939f,1.689f),
            new Vector4(246.302f, 110.590f, 101.549f,158.703f),
            new Vector4(95.002f, 155.576f, 103.746f,68.426f),
            new Vector4(412.165f, 53.765f, 96.979f,-19.310f),
            new Vector4(657.671f, 279.225f, 102.294f,-32.603f),
            new Vector4(603.567f, 145.833f, 97.029f,159.450f),
            new Vector4(348.966f, 336.744f, 104.202f,-105.033f),
            new Vector4(371.841f, 360.335f, 101.526f,-5.761f),
            new Vector4(336.086f, 261.314f, 102.594f,-169.837f)
        };
        private static readonly List<Vector4> BinFire03 = new List<Vector4>
        {
            new Vector4(-3178.451f, 1118.437f, 19.880f,64.334f),
            new Vector4(-3250.307f, 996.116f, 11.490f,-93.739f),
            new Vector4(-3061.157f, 608.573f, 6.439f,19.399f),
            new Vector4(-2939.601f, 458.929f, 14.372f,176.704f),
            new Vector4(-2945.826f, 412.268f, 14.279f,-104.678f),
            new Vector4(-2954.838f, 394.393f, 14.022f,88.451f),
            new Vector4(-2957.857f, 62.706f, 10.609f,-23.997f),
            new Vector4(-2061.810f, -313.014f, 12.317f,172.473f),
            new Vector4(-1698.073f, -276.999f, 50.884f,-36.390f),
            new Vector4(-1819.518f, 801.450f, 137.247f,131.485f),
            new Vector4(-1925.005f, 2059.148f, 139.835f,166.017f),
            new Vector4(-2520.516f, 2315.344f, 32.217f,93.239f),
            new Vector4(-1133.037f, 2680.557f, 17.370f,-47.328f),
            new Vector4(-3178.451f, 1118.437f, 19.880f,64.334f),
            new Vector4(-1804.564f, -415.001f, 43.378f,-126.674f),
            new Vector4(-1806.745f, -361.238f, 48.240f,94.143f),
            new Vector4(-2039.669f, -254.251f, 22.529f,54.858f),
            new Vector4(-1780.957f, -496.459f, 37.774f,-44.739f)
        };
        private static readonly List<Vector4> BinFire04 = new List<Vector4>
        {
            new Vector4(993.320f, -99.002f, 73.354f,133.148f),
            new Vector4(785.478f, -88.315f, 79.599f,-120.230f),
            new Vector4(816.092f, -122.132f, 79.232f,154.067f),
            new Vector4(892.419f, -183.934f, 72.665f,-31.990f),
            new Vector4(712.381f, -300.055f, 58.249f,99.740f),
            new Vector4(798.074f, -488.275f, 28.920f,29.501f),
            new Vector4(1113.919f, -335.535f, 66.097f,-150.235f),
            new Vector4(1184.750f, -304.619f, 68.088f,-173.455f),
            new Vector4(1166.419f, -313.716f, 68.338f,100.698f),
            new Vector4(1154.171f, -376.030f, 66.303f,74.333f),
            new Vector4(1236.009f, -413.252f, 67.940f,73.344f),
            new Vector4(1119.376f, -473.261f, 65.442f,74.347f),
            new Vector4(1061.877f, -786.295f, 57.263f,2.865f),
            new Vector4(1101.240f, -783.096f, 57.263f,2.399f),
            new Vector4(1134.271f, -800.486f, 56.580f,91.395f),
            new Vector4(1130.970f, -976.915f, 45.539f,-171.524f),
            new Vector4(1210.782f, -1244.290f, 34.227f,-0.556f),
            new Vector4(1137.662f, -1315.791f, 33.655f,89.822f),
            new Vector4(1170.868f, -1377.859f, 33.950f,-177.994f),
            new Vector4(1232.004f, -1494.089f, 33.693f,0.019f),
            new Vector4(1157.970f, -1411.478f, 33.856f,-87.612f),
            new Vector4(1318.099f, -1659.662f, 50.237f,-53.413f),
            new Vector4(1457.269f, -1649.735f, 66.147f,-157.950f),
            new Vector4(1461.030f, -1731.172f, 67.168f,95.613f),
            new Vector4(1578.817f, -1724.508f, 87.152f,128.270f),
            new Vector4(1468.150f, -1933.778f, 70.197f,-5.975f),
            new Vector4(1558.140f, -2124.761f, 76.352f,-76.492f),
            new Vector4(1390.241f, -2221.933f, 60.049f,-70.481f),
            new Vector4(1281.616f, -2563.822f, 42.940f,85.956f),
            new Vector4(1745.036f, -1679.693f, 111.655f,6.576f),
            new Vector4(1776.375f, -1647.599f, 111.603f,-82.635f),
            new Vector4(1745.278f, -1476.236f, 111.854f,160.278f),
            new Vector4(2435.982f, -417.948f, 91.995f,42.063f),
            new Vector4(2558.300f, 281.356f, 107.610f,-89.595f),
            new Vector4(2543.179f, 397.107f, 107.616f,87.483f),
            new Vector4(2590.501f, 486.260f, 107.689f,93.165f),
            new Vector4(2755.757f, 1453.951f, 23.636f,76.024f),
            new Vector4(2773.687f, 1390.811f, 23.482f,82.880f),
            new Vector4(2786.556f, 1664.895f, 23.489f,-1.596f),
            new Vector4(2489.975f, 1568.067f, 31.721f,-179.248f),
            new Vector4(2563.916f, 2580.745f, 36.945f,22.038f),
            new Vector4(2526.839f, 2640.647f, 36.945f,-90.927f),
            new Vector4(2598.762f, 2803.282f, 32.923f,10.819f),
            new Vector4(2679.502f, 2759.377f, 36.946f,-60.092f),
            new Vector4(1665.968f, 0.181f, 172.776f,-60.289f),
            new Vector4(1906.809f, 576.745f, 174.840f,-118.725f),
            new Vector4(1487.053f, 1103.674f, 113.335f,-0.304f),
            new Vector4(1535.276f, 1720.089f, 108.784f,9.828f),
            new Vector4(1224.402f, 1869.964f, 77.882f,-138.196f),
            new Vector4(771.443f, 1282.427f, 359.297f,-90.691f)
        };
        private static readonly List<Vector4> BinFire05 = new List<Vector4>
        {
            new Vector4(1719.030f, 4811.679f, 40.711f,-2.205f),
            new Vector4(1637.656f, 4823.880f, 40.880f,98.405f),
            new Vector4(1687.746f, 4887.118f, 41.030f,-170.978f),
            new Vector4(1720.376f, 4937.502f, 41.081f,-36.436f),
            new Vector4(1707.426f, 4735.986f, 41.154f,-74.928f),
            new Vector4(2023.978f, 4978.895f, 40.181f,-45.262f),
            new Vector4(1775.918f, 4601.741f, 36.631f,4.835f),
            new Vector4(1822.083f, 4592.680f, 35.031f,-79.724f),
            new Vector4(1949.215f, 4622.808f, 39.584f,-51.495f),
            new Vector4(1338.649f, 4323.841f, 37.029f,84.948f),
            new Vector4(1377.615f, 4303.227f, 35.672f,-145.327f),
            new Vector4(2112.101f, 4777.237f, 39.891f,-36.270f),
            new Vector4(2323.340f, 4850.913f, 40.809f,-44.582f),
            new Vector4(2573.451f, 4690.318f, 33.101f,-134.148f),
            new Vector4(2948.951f, 4634.392f, 47.544f,-133.383f),
            new Vector4(2892.789f, 4487.944f, 47.144f,-122.909f),
            new Vector4(2869.235f, 4408.619f, 48.201f,-156.300f),
            new Vector4(2899.230f, 4368.531f, 49.332f,-157.289f),
            new Vector4(3793.409f, 4478.305f, 4.380f,-64.387f),
            new Vector4(2986.386f, 3472.192f, 70.443f,-7.811f),
            new Vector4(2670.644f, 3463.650f, 54.622f,-22.919f),
            new Vector4(2670.478f, 3294.261f, 54.245f,53.853f),
            new Vector4(2502.804f, 4084.528f, 37.602f,-117.704f),
            new Vector4(2520.261f, 4207.225f, 38.952f,55.695f),
            new Vector4(2448.646f, 4052.025f, 37.065f,158.626f),
            new Vector4(1986.023f, 3786.915f, 31.280f,-60.560f),
            new Vector4(1948.562f, 3829.344f, 31.160f,-59.805f),
            new Vector4(1901.479f, 3735.724f, 31.657f,26.593f),
            new Vector4(1693.040f, 3780.187f, 33.755f,-55.627f),
            new Vector4(1747.276f, 3710.932f, 33.133f,112.278f),
            new Vector4(1381.189f, 3618.689f, 33.893f,-70.402f),
            new Vector4(902.470f, 3657.028f, 31.681f,-93.507f),
            new Vector4(899.832f, 3580.313f, 32.389f,-89.630f),
            new Vector4(380.944f, 3565.280f, 32.293f,-8.260f),
            new Vector4(433.699f, 3563.673f, 32.239f,-15.969f),
            new Vector4(462.337f, 3553.531f, 32.239f,-10.581f),
            new Vector4(377.206f, 3412.980f, 35.416f,-141.105f),
            new Vector4(55.559f, 2798.189f, 57.042f,143.057f),
            new Vector4(181.988f, 2799.295f, 44.656f,98.511f),
            new Vector4(258.950f, 2877.733f, 42.611f,26.050f),
            new Vector4(309.582f, 2618.601f, 43.491f,-51.836f),
            new Vector4(251.675f, 2582.210f, 44.233f,100.946f),
            new Vector4(562.447f, 2666.587f, 41.143f,93.697f),
            new Vector4(567.545f, 2802.664f, 41.019f,-175.707f),
            new Vector4(802.548f, 2189.153f, 51.236f,155.145f),
            new Vector4(850.937f, 2189.749f, 51.290f,-115.066f),
            new Vector4(1010.639f, 2501.501f, 48.377f,87.206f),
            new Vector4(1119.753f, 2206.887f, 48.526f,104.351f),
            new Vector4(1213.006f, 2400.625f, 65.089f,-93.672f),
            new Vector4(1018.421f, 2653.114f, 38.618f,89.115f),
            new Vector4(1153.983f, 2659.140f, 36.997f,89.823f),
            new Vector4(1195.584f, 2631.799f, 36.811f,-81.101f),
            new Vector4(1184.869f, 2730.056f, 37.005f,-2.644f),
            new Vector4(1684.913f, 3279.413f, 40.049f,-56.200f),
            new Vector4(1963.311f, 3036.207f, 46.057f,56.689f),
            new Vector4(2351.533f, 3110.214f, 47.210f,-11.997f)
        };
        private static readonly List<Vector4> BinFire06 = new List<Vector4>
        {
            new Vector4(-309.242f, 6202.396f, 30.495f,-45.041f),
            new Vector4(-276.801f, 6173.585f, 30.482f,44.080f),
            new Vector4(-346.919f, 6070.924f, 30.485f,135.714f),
            new Vector4(-402.198f, 6082.969f, 30.501f,138.836f),
            new Vector4(-433.095f, 6164.737f, 30.479f,137.064f),
            new Vector4(-348.578f, 6239.886f, 30.489f,133.626f),
            new Vector4(-183.286f, 6317.054f, 30.465f,134.637f),
            new Vector4(-137.260f, 6268.094f, 30.339f,136.329f),
            new Vector4(-126.292f, 6342.955f, 30.491f,-134.971f),
            new Vector4(-46.712f, 6416.830f, 30.491f,-44.207f),
            new Vector4(-92.220f, 6389.510f, 30.638f,-135.524f),
            new Vector4(-49.010f, 6451.797f, 30.479f,-45.110f),
            new Vector4(-37.711f, 6432.966f, 30.455f,-136.173f),
            new Vector4(-12.072f, 6481.461f, 30.411f,44.575f),
            new Vector4(9.326f, 6501.850f, 30.520f,-135.497f),
            new Vector4(97.183f, 6515.600f, 30.314f,-48.967f),
            new Vector4(2.320f, 6409.585f, 30.424f,44.798f),
            new Vector4(175.577f, 6646.775f, 30.474f,134.167f),
            new Vector4(123.831f, 6651.908f, 30.728f,-134.670f),
            new Vector4(182.850f, 6440.728f, 30.238f,-49.112f),
            new Vector4(401.761f, 6595.649f, 27.163f,178.318f),
            new Vector4(400.766f, 6478.508f, 27.944f,92.078f),
            new Vector4(1465.267f, 6539.694f, 13.384f,-158.716f),
            new Vector4(1597.600f, 6457.345f, 24.318f,60.859f),
            new Vector4(1745.323f, 6416.106f, 33.933f,66.145f),
            new Vector4(1682.148f, 6441.792f, 31.104f,65.049f),
            new Vector4(30.527f, 6293.056f, 30.229f,29.019f),
            new Vector4(142.089f, 6386.469f, 30.316f,-150.561f),
            new Vector4(-118.200f, 6208.923f, 30.202f,-136.951f),
            new Vector4(-680.300f, 5795.633f, 16.332f,155.028f),
            new Vector4(-569.657f, 5237.961f, 69.470f,-113.713f),
            new Vector4(-839.594f, 5399.025f, 33.616f,118.698f),
            new Vector4(-2176.212f, 4276.218f, 48.094f,59.238f)
        };

        private static readonly List<Vector4> MadFire01 = new List<Vector4>
        {
            new Vector4(-994.2792f, -2520.325f, 13.41739f, 0f),
            new Vector4(1165.043f, -3222.609f, 5.385954f, 0f),
            new Vector4(933.6134f, -2081.24f, 30.13177f, 0f),
            new Vector4(101.8374f, -1864.978f, 23.94473f, 0f),
            new Vector4(68.45313f, -1497.742f, 28.89089f, 0f),
            new Vector4(783.5147f, -1000.46f, 25.71556f, 0f),
            new Vector4(464.176f, -1825.874f, 27.61972f, 0f),
            new Vector4(523.4406f, -2984.174f, 5.628889f, 0f),
            new Vector4(-172.0261f, -1920.919f, 24.72114f, 0f),
            new Vector4(-108.2467f, -1354.8f, 28.97163f, 0f)
        };
        private static readonly List<Vector4> MadFire02 = new List<Vector4>
        {
            new Vector4(-640.8735f, -838.8285f, 24.45141f, 0f),
            new Vector4(-1058.591f, -1024.118f, 1.774962f, 0f),
            new Vector4(-1153.756f, -1339.463f, 4.697246f, 0f),
            new Vector4(-1226.06f, -433.3082f, 33.18565f, 0f),
            new Vector4(-699.404f, -19.63133f, 37.53633f, 0f),
            new Vector4(-212.2905f, 127.8813f, 69.16212f, 0f),
            new Vector4(354.2812f, 134.1312f, 102.6729f, 0f),
            new Vector4(222.583f, -215.2652f, 53.6492f, 0f),
            new Vector4(166.6302f, -829.5413f, 30.7629f, 0f),
            new Vector4(-179.5928f, -885.489f, 28.94018f, 0f)
        };
        private static readonly List<Vector4> MadFire03 = new List<Vector4>
        {
            new Vector4(-2024.08f, -175.2686f, 26.76026f, 0f),
            new Vector4(-2960.124f, 98.36689f, 13.35277f, 0f),
            new Vector4(-2985.582f, 544.3261f, 16.4247f, 0f),
            new Vector4(-3100.223f, 1191.346f, 19.91869f, 0f),
            new Vector4(-2652.758f, 1501.169f, 118.0722f, 0f),
            new Vector4(-1514.433f, 2126.713f, 55.75016f, 0f),
            new Vector4(-1991.367f, 696.023f, 142.7182f, 0f),
            new Vector4(-2304.964f, 410.1695f, 174.0543f, 0f),
            new Vector4(-1567.98f, -173.0723f, 55.11384f, 0f),
            new Vector4(-2709.916f, 2291.146f, 18.22017f, 0f)
        };
        private static readonly List<Vector4> MadFire04 = new List<Vector4>
        {
            new Vector4(2604.583f, 2507.948f, 28.76816f, 0f),
            new Vector4(2576.702f, 418.3727f, 108.0408f, 0f),
            new Vector4(1331.708f, -1615.235f, 52.11648f, 0f),
            new Vector4(918.6093f, -593.2044f, 56.90709f, 0f),
            new Vector4(1269.138f, -540.7137f, 68.56045f, 0f),
            new Vector4(873.0724f, -111.8709f, 79.04739f, 0f),
            new Vector4(1233.344f, -1420.103f, 35.10855f, 0f),
            new Vector4(1161.572f, -949.0202f, 47.99375f, 0f),
            new Vector4(2589.429f, -371.2926f, 92.46644f, 0f),
            new Vector4(2690.265f, 1642.243f, 24.16985f, 0f)
        };
        private static readonly List<Vector4> MadFire05 = new List<Vector4>
        {
            new Vector4(1889.192f, 3834.451f, 32.01105f, 0f),
            new Vector4(1609.499f, 3675.907f, 34.07229f, 0f),
            new Vector4(1667.149f, 4874.436f, 41.66345f, 0f),
            new Vector4(2512.01f, 4135.024f, 38.16343f, 0f),
            new Vector4(2824.888f, 4413.539f, 48.57113f, 0f),
            new Vector4(1154.737f, 2684.383f, 37.74841f, 0f),
            new Vector4(420.9953f, 2673.239f, 43.63997f, 0f),
            new Vector4(860.386f, 2238.428f, 48.13387f, 0f),
            new Vector4(2061.712f, 2999.06f, 44.66584f, 0f),
            new Vector4(74.05325f, 3635.154f, 39.30263f, 0f)
        };
        private static readonly List<Vector4> MadFire06 = new List<Vector4>
        {
            new Vector4(-1505.434f, 5000.363f, 62.35179f, 0f),
            new Vector4(-945.9736f, 5415.901f, 38.02508f, 0f),
            new Vector4(-666.4794f, 5980.88f, 12.4952f, 0f),
            new Vector4(-223.158f, 6152.968f, 30.78292f, 0f),
            new Vector4(69.45302f, 6612.893f, 31.14452f, 0f),
            new Vector4(1351.396f, 6501.865f, 19.50821f, 0f),
            new Vector4(-2233.997f, 4280.964f, 46.50346f, 0f)
        };

        public static List<BombSquad> BsArea01 = new List<BombSquad>();
        public static List<BombSquad> BsArea02 = new List<BombSquad>();
        public static List<BombSquad> BsArea03 = new List<BombSquad>();
        public static List<BombSquad> BsArea04 = new List<BombSquad>();
        public static List<BombSquad> BsArea05 = new List<BombSquad>();
        public static List<BombSquad> BsArea06 = new List<BombSquad>();
        public static List<BombSquad> BsArea07 = new List<BombSquad>();
        public static List<BombSquad> BsArea08 = new List<BombSquad>();
        public static List<BombSquad> BsArea09 = new List<BombSquad>();

        public static readonly List<GreatestHits> HitList01 = new List<GreatestHits> 
        {
            new GreatestHits(14, new Vector3(1174.633f, -3086.502f, 5.347713f), new Vector3(1192.2f, -3067.692f, 4.987493f), new Vector4(1231.332f, -2917.555f, 26.45622f, 131.4427f), new Vector4(1222.668f, -2914.625f, 5.880469f, 131.4427f), new Vector4(1219.501f, -2915.277f, 5.866065f, 337.1597f), new List<Vector3> { new Vector3(1228.313f, -2924.687f, 9.319263f), new Vector3(1252.82f, -2923.144f, 9.319261f), new Vector3(1252.724f, -2950.048f, 9.319261f), new Vector3(1229.017f, -2950.106f, 9.319257f), new Vector3(1228.458f, -2939.91f, 9.319262f) }, new List<Vector3> { new Vector3(1253.167f, -2950.298f, 9.319255f), new Vector3(1228.614f, -2951.87f, 9.319256f), new Vector3(1228.804f, -3002.856f, 9.319259f), new Vector3(1252.686f, -3002.903f, 9.319256f), new Vector3(1252.763f, -2950.377f, 9.319261f) }, new List<Vector3> { new Vector3(1229.62f, -2921.219f, 17.33289f), new Vector3(1251.382f, -2921.088f, 17.33288f) }, new List<PropLists>()),
            new GreatestHits(6, new Vector3(59.46093f, -2619.733f, 5.504735f), new Vector3(59.60139f, -2637.591f, 5.029f), new Vector4(33.84007f, -2691.393f, 12.008f, 176.5982f), new Vector4(27.48125f, -2688.801f, 12.008f, 89.52501f), new Vector4(34.01345f, -2679.244f, 12.035f, 358.159f), new List<Vector3> { new Vector3(34.44283f, -2674.603f, 12.06331f), new Vector3(47.15094f, -2675.877f, 12.00943f), new Vector3(46.7704f, -2684.993f, 12.00943f), new Vector3(44.09134f, -2685.037f, 12.00943f), new Vector3(43.92788f, -2675.145f, 17.15017f), new Vector3(23.88951f, -2675.556f, 17.15017f), new Vector3(23.56731f, -2685.437f, 12.00879f), new Vector3(20.8575f, -2684.973f, 12.00879f), new Vector3(20.65493f, -2675.646f, 12.00879f) }, new List<Vector3> { new Vector3(43.55402f, -2745.357f, 13.51919f), new Vector3(48.22489f, -2745.141f, 12.0066f), new Vector3(47.78152f, -2719.32f, 12.00674f), new Vector3(19.62543f, -2719.374f, 12.00684f), new Vector3(19.58252f, -2744.939f, 12.00709f), new Vector3(24.58426f, -2745.261f, 13.51921f), new Vector3(24.58426f, -2745.261f, 13.51921f), new Vector3(19.58252f, -2744.939f, 12.00709f), new Vector3(19.62543f, -2719.374f, 12.00684f), new Vector3(47.78152f, -2719.32f, 12.00674f), new Vector3(48.22489f, -2745.141f, 12.0066f), new Vector3(43.55402f, -2745.357f, 13.51919f) }, new List<Vector3> { new Vector3(19.24374f, -2718.498f, 12.00685f), new Vector3(19.64524f, -2688.488f, 12.00685f), new Vector3(48.12241f, -2689.036f, 12.00683f), new Vector3(47.77153f, -2718.917f, 12.0066f) }, new List<PropLists> { new PropLists("prop_portasteps_02", new Vector3(45.138f, -2723.31f, 5.00f), new Vector3(0.00f, 0.00f, -91.0648f)) }),
            new GreatestHits(9, new Vector3(408.8784f, -1674.746f, 28.64179f), new Vector3(379.8796f, -1638.833f, 31.50078f), new Vector4(326.7136f, -1583.937f, 36.29747f, 138.74f), new Vector4(324.7176f, -1585.714f, 32.71544f, 138.8346f), new Vector4(346.4529f, -1569.449f, 36.27796f, 318.1562f), new List<Vector3> { new Vector3(309.5382f, -1565.522f, 36.28808f), new Vector3(330.5859f, -1582.785f, 36.28808f) }, new List<Vector3> { new Vector3(301.2746f, -1567.027f, 29.3291f), new Vector3(323.8167f, -1539.903f, 29.28773f), new Vector3(355.2028f, -1566.285f, 29.29217f), new Vector3(332.1236f, -1593.688f, 29.29193f) }, new List<Vector3> { new Vector3(346.3667f, -1569.814f, 36.27857f), new Vector3(335.5739f, -1582.018f, 36.28791f), new Vector3(345.8018f, -1569.149f, 36.27539f), new Vector3(322.4924f, -1549.453f, 36.29724f) }, new List<PropLists>()),
            new GreatestHits(8, new Vector3(239.7962f, -2096.332f, 16.64877f), new Vector3(231.6781f, -2188.885f, 7.87558f), new Vector4(166.1355f, -2213.007f, 13.38672f, 352.9091f), new Vector4(167.09f, -2221.467f, 13.38672f, 174.5936f), new Vector4(168.4527f, -2223.325f, 7.236109f, 150.681f), new List<Vector3> { new Vector3(175.1628f, -2189.65f, 6.219862f), new Vector3(95.33917f, -2190.859f, 5.997694f) }, new List<Vector3> { new Vector3(92.0293f, -2231.113f, 6.033323f), new Vector3(179.8964f, -2232.37f, 5.97946f) }, new List<Vector3> { new Vector3(179.9824f, -2191.904f, 6.513243f), new Vector3(180.4981f, -2234.048f, 5.980174f) }, new List<PropLists>()),
            new GreatestHits(1, new Vector3(764.6891f, -2490.405f, 19.42806f), new Vector3(801.6285f, -2496.214f, 21.14066f), new Vector4(866.3467f, -2506.64f, 48.31793f, 262.1452f), new Vector4(894.6924f, -2538.095f, 52.30277f, 225.5563f), new Vector4(874.5434f, -2500.339f, 48.28411f, 220.1823f), new List<Vector3> { new Vector3(951.6783f, -2507.288f, 48.29662f), new Vector3(881.1595f, -2501.313f, 48.29713f) }, new List<Vector3> { new Vector3(883.374f, -2516.431f, 48.2971f), new Vector3(949.2033f, -2522.715f, 48.29663f) }, new List<Vector3> { new Vector3(820.2464f, -2506.051f, 36.43614f), new Vector3(843.4808f, -2508.547f, 36.59108f), new Vector3(844.4509f, -2501.387f, 40.51944f), new Vector3(849.8228f, -2501.901f, 40.68602f), new Vector3(847.6412f, -2523.593f, 40.5252f), new Vector3(849.8228f, -2501.901f, 40.68602f), new Vector3(844.4509f, -2501.387f, 40.51944f), new Vector3(843.4808f, -2508.547f, 36.59108f) }, new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList02 = new List<GreatestHits>
        {
            new GreatestHits(7, new Vector3(400.7948f, -728.7968f, 28.64635f), new Vector3(416.3363f, -713.1559f, 28.354f), new Vector4(463.3673f, -730.1653f, 27.35761f, 88.53651f), new Vector4(462.9327f, -736.3919f, 27.3614f, 159.2728f), new Vector4(456.881f, -725.7477f, 27.35909f, 356.1181f), new List<Vector3> { new Vector3(456.7629f, -702.7166f, 27.36512f), new Vector3(455.6923f, -772.2094f, 27.35778f) }, new List<Vector3> { new Vector3(469.4762f, -737.4404f, 37.37773f), new Vector3(487.7828f, -737.6826f, 37.37757f), new Vector3(487.3804f, -750.106f, 37.37757f), new Vector3(469.6671f, -751.8098f, 37.37757f) }, new List<Vector3> { new Vector3(472.7426f, -786.6891f, 42.5186f), new Vector3(472.6585f, -808.6378f, 42.5186f) }, new List<PropLists>()),
            new GreatestHits(40, new Vector3(146.7832f, -350.9908f, 43.03316f), new Vector3(118.4199f, -362.7799f, 41.58885f), new Vector4(36.69075f, -368.9121f, 55.28428f, 341.8449f), new Vector4(45.11557f, -402.7439f, 55.28497f, 109.7192f), new Vector4(46.32808f, -417.696f, 45.55898f, 250.7595f), new List<Vector3> { new Vector3(46.80554f, -411.3244f, 73.94062f), new Vector3(59.13193f, -382.0238f, 73.94208f), new Vector3(54.37819f, -375.5727f, 73.94208f), new Vector3(58.97313f, -383.6569f, 73.94208f), new Vector3(47.5579f, -398.3995f, 73.94062f) }, new List<Vector3> { new Vector3(89.48793f, -355.7539f, 67.19714f), new Vector3(65.80093f, -345.8131f, 67.19714f) }, new List<Vector3> { new Vector3(52.64137f, -427.5997f, 39.9211f), new Vector3(33.33545f, -419.8749f, 39.92244f), new Vector3(47.21172f, -383.8306f, 39.92105f), new Vector3(65.09759f, -390.6096f, 39.92027f) }, new List<PropLists> { new PropLists("prop_portacabin01", new Vector3(44.1962852f, -375.137268f, 54.2930298f), new Vector3(0.00f, 0.00f, -109.909622f)), new PropLists("prop_const_fence03a_cr", new Vector3(67.2774124f, -357.792114f, 66.3006134f), new Vector3(-90.00f, -71.00f, 0.00f)), new PropLists("prop_const_fence03a_cr", new Vector3(61.1067352f, -370.916534f, 63.9689331f), new Vector3(-89.00f, 109.711678f, -180.00f)), new PropLists("prop_conc_blocks01a", new Vector3(58.0884781f, -375.2005f, 64.1185989f), new Vector3(0.00f, 0.00f, -19.1175747f)), new PropLists("prop_conc_blocks01a", new Vector3(68.0418549f, -351.828827f, 66.3754883f), new Vector3(-13.00f, -4.38115f, -18.9079647f)) }),
            new GreatestHits(28, new Vector3(-766.8001f, -1299.866f, 4.492908f), new Vector3(-821.5909f, -1267.316f, 4.150073f), new Vector4(-797.2293f, -1263.064f, 10.62328f, 267.6799f), new Vector4(-769.4945f, -1224.638f, 10.62638f, 196.7793f), new Vector4(-749.2515f, -1215.959f, 10.62637f, 250.1729f), new List<Vector3> { new Vector3(-750.7853f, -1242.718f, 10.62638f), new Vector3(-768.506f, -1226.165f, 10.62637f), new Vector3(-774.0214f, -1231.924f, 10.62399f), new Vector3(-771.0255f, -1234.603f, 10.62399f), new Vector3(-774.5523f, -1231.954f, 10.62399f), new Vector3(-768.0485f, -1226.437f, 10.62637f), new Vector3(-748.4064f, -1243.806f, 10.62637f) }, new List<Vector3> { new Vector3(-797.392f, -1258.829f, 15.55804f), new Vector3(-783.0823f, -1241.732f, 15.55848f), new Vector3(-796.5568f, -1259.465f, 15.55804f), new Vector3(-807.8983f, -1250.295f, 15.55804f) }, new List<Vector3> { new Vector3(-806.1038f, -1202.531f, 6.934639f), new Vector3(-823.16f, -1223.631f, 7.36058f), new Vector3(-838.9916f, -1241.554f, 6.933933f), new Vector3(-821.95f, -1221.632f, 7.329305f), new Vector3(-805.6579f, -1201.917f, 6.934637f), new Vector3(-830.2202f, -1181.61f, 6.563109f)}, new List<PropLists> { new PropLists("prop_lev_crate_01", new Vector3(-815.161377f, -1204.63574f, 5.95f), new Vector3(0.00f, 0.00f, -129.962433f)), new PropLists("prop_lev_crate_01", new Vector3(-817.414551f, -1207.32458f, 5.95f), new Vector3(0.00f, 0.00f, 129.962433f)), new PropLists("prop_lev_crate_01", new Vector3(-816.227905f, -1206.00659f, 8.26f), new Vector3(0.00f, 0.00f, -130.349335f)) }),
            new GreatestHits(9, new Vector3(-255.8934f, -334.3924f, 29.29095f), new Vector3(-246.1797f, -336.1305f, 28.97524f), new Vector4(-291.7663f, -292.7603f, 10.06316f, 199.104f), new Vector4(-285.6105f, -338.2589f, 18.28811f, 134.0289f), new Vector4(-296.5644f, -294.7615f, 10.06316f, 182.6955f), new List<Vector3> { new Vector3(-289.8233f, -297.2211f, 10.06316f), new Vector3(-290.0239f, -312.5032f, 10.06316f), new Vector3(-290.5504f, -353.0921f, 10.0631f), new Vector3(-292.1029f, -359.7104f, 10.0631f), new Vector3(-295.4711f, -361.8761f, 10.0631f), new Vector3(-298.9847f, -358.6346f, 10.0631f), new Vector3(-299.1021f, -311.0461f, 10.06316f), new Vector3(-297.4647f, -296.5092f, 10.06316f) }, new List<Vector3> { new Vector3(-295.0848f, -310.6173f, 10.06316f), new Vector3(-296.6198f, -310.4763f, 10.06316f), new Vector3(-296.5306f, -326.6769f, 18.28813f), new Vector3(-297.6626f, -332.7889f, 18.28813f), new Vector3(-296.6054f, -337.818f, 18.294f), new Vector3(-296.5121f, -353.4188f, 10.0631f), new Vector3(-292.8206f, -353.284f, 10.0631f), new Vector3(-292.6532f, -336.6879f, 18.28812f), new Vector3(-291.6863f, -331.7599f, 18.28812f), new Vector3(-292.7159f, -327.2827f, 18.28813f), new Vector3(-292.5435f, -304.275f, 10.06316f)}, new List<Vector3> { new Vector3(-278.4434f, -331.541f, 18.28813f), new Vector3(-285.9347f, -331.1507f, 18.28813f), new Vector3(-278.8092f, -330.1296f, 18.28813f), new Vector3(-278.6689f, -316.9438f, 18.28978f), new Vector3(-277.645f, -308.2796f, 18.29003f) }, new List<PropLists>()),
            new GreatestHits(10, new Vector3(-1637.61f, -990.769f, 12.50938f), new Vector3(-1749.522f, -1128.634f, 12.09095f), new Vector4(-1848.826f, -1200.298f, 19.14339f, 165.824f), new Vector4(-1821.772f, -1203.717f, 19.16464f, 132.5266f), new Vector4(-1837.848f, -1201.714f, 14.30476f, 166.2297f), new List<Vector3> { new Vector3(-1870.086f, -1215.344f, 13.01713f), new Vector3(-1858.132f, -1217.874f, 13.01717f), new Vector3(-1840.758f, -1231.264f, 13.01732f), new Vector3(-1833.656f, -1237.782f, 13.01729f), new Vector3(-1819.635f, -1239.65f, 13.01727f), new Vector3(-1788.522f, -1200.065f, 13.0173f), new Vector3(-1824.51f, -1168.362f, 13.01732f), new Vector3(-1836.096f, -1168.824f, 13.01725f), new Vector3(-1870.061f, -1208.122f, 13.01711f) }, new List<Vector3> { new Vector3(-1833.688f, -1231.561f, 13.01734f), new Vector3(-1836.393f, -1226.08f, 13.01728f), new Vector3(-1808.704f, -1197.679f, 13.01745f), new Vector3(-1803.548f, -1202.021f, 14.30476f), new Vector3(-1803.025f, -1206.546f, 14.30477f), new Vector3(-1799.925f, -1210.426f, 13.01728f), new Vector3(-1805.519f, -1216.99f, 16.06497f), new Vector3(-1812.613f, -1224.225f, 19.16972f), new Vector3(-1821.701f, -1230.137f, 16.07651f), new Vector3(-1830.23f, -1234.019f, 13.01734f) }, new List<Vector3> { new Vector3(-1849.402f, -1232.195f, 13.01728f), new Vector3(-1841.599f, -1238.597f, 13.01727f), new Vector3(-1829.071f, -1239.79f, 13.01727f), new Vector3(-1807.84f, -1244.064f, 13.01744f), new Vector3(-1823.396f, -1263.139f, 9.821608f), new Vector3(-1832.576f, -1255.504f, 8.615788f), new Vector3(-1851.096f, -1246.4f, 8.615793f), new Vector3(-1858.264f, -1242.085f, 8.620294f), new Vector3(-1849.297f, -1231.631f, 13.01728f) }, new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList03 = new List<GreatestHits>
        {
            new GreatestHits(13, new Vector3(-2289.002f, 382.1094f, 173.959f), new Vector3(-2292.242f, 368.3256f, 173.6016f), new Vector4(-2164.615f, 215.312f, 184.6018f, 194.0452f), new Vector4(-2175.842f, 230.6704f, 184.6018f, 91.44373f), new Vector4(-2182.791f, 225.1664f, 184.6018f, 117.0788f), new List<Vector3> { new Vector3(-2193.12f, 214.8187f, 194.6015f), new Vector3(-2187.273f, 200.6972f, 194.6015f), new Vector3(-2195.246f, 197.4945f, 194.6015f), new Vector3(-2202.147f, 211.6152f, 194.6015f) }, new List<Vector3> { new Vector3(-2205.943f, 284.1791f, 198.1042f), new Vector3(-2190.154f, 249.9319f, 198.1042f), new Vector3(-2193.155f, 248.5463f, 198.1042f), new Vector3(-2195.564f, 254.7708f, 198.1041f), new Vector3(-2211.713f, 247.9421f, 198.1041f), new Vector3(-2223.777f, 276.0439f, 198.1041f) }, new List<Vector3> { new Vector3(-2181.586f, 241.0944f, 184.6015f), new Vector3(-2183.65f, 247.7438f, 184.6018f), new Vector3(-2167.301f, 254.9386f, 184.6014f), new Vector3(-2162.183f, 251.9092f, 184.6014f), new Vector3(-2151.097f, 223.4035f, 184.6018f), new Vector3(-2158.881f, 219.6353f, 184.6018f), new Vector3(-2175.402f, 216.5356f, 184.6018f), new Vector3(-2181.213f, 225.0541f, 184.6017f), new Vector3(-2188.713f, 223.2862f, 184.6018f), new Vector3(-2192.207f, 230.9244f, 184.6018f), new Vector3(-2193.282f, 235.5259f, 184.6018f) }, new List<PropLists>()),
            new GreatestHits(4, new Vector3(-1842.027f, -237.2443f, 39.47428f), new Vector3(-1828.877f, -234.5518f, 39.79652f), new Vector4(-1719.305f, -235.0199f, 55.10064f, 0.00f), new Vector4(-1697.421f, -233.6458f, 55.70928f, 2.999983f), new Vector4(-1724.445f, -241.228f, 53.95118f, 98.57713f), new List<Vector3> { new Vector3(-1696.339f, -231.1925f, 56f), new Vector3(-1692.168f, -214.6881f, 57.5444f), new Vector3(-1716.279f, -215.0625f, 57.53803f), new Vector3(-1734.436f, -211.6512f, 57.45734f), new Vector3(-1738.01f, -242.2859f, 53.65525f), new Vector3(-1730.969f, -259.2317f, 51.58413f), new Vector3(-1707.515f, -241.5851f, 54.14204f), new Vector3(-1695.752f, -231.155f, 56.06041f), new Vector3(-1690.386f, -217.1109f, 57.54454f) }, new List<Vector3> { new Vector3(-1712.414f, -247.3833f, 53.19257f), new Vector3(-1733.539f, -259.792f, 51.58722f), new Vector3(-1738.586f, -236.0341f, 54.09969f), new Vector3(-1732.834f, -211.2153f, 57.50314f), new Vector3(-1741.738f, -203.749f, 57.49961f), new Vector3(-1754.511f, -192.491f, 57.54516f), new Vector3(-1785.649f, -219.863f, 52.15072f), new Vector3(-1771.741f, -230.7688f, 52.77929f), new Vector3(-1759.96f, -235.5635f, 53.00547f), new Vector3(-1745.87f, -239.4451f, 53.40018f), new Vector3(-1726.956f, -241.0094f, 53.91877f), new Vector3(-1708.826f, -240.1459f, 54.11729f) }, new List<Vector3> { new Vector3(-1685.734f, -209.1683f, 57.529f), new Vector3(-1700.192f, -214.8236f, 57.47515f), new Vector3(-1720.822f, -213.317f, 57.54206f), new Vector3(-1735.292f, -209.2518f, 57.47928f), new Vector3(-1742.708f, -203.6408f, 57.46876f), new Vector3(-1749.761f, -193.5887f, 57.54453f), new Vector3(-1749.049f, -186.0264f, 57.54453f), new Vector3(-1740.429f, -173.0496f, 57.811f), new Vector3(-1732.955f, -168.3997f, 58.54979f), new Vector3(-1716.589f, -166.9732f, 57.50301f), new Vector3(-1709.482f, -163.2827f, 57.4664f), new Vector3(-1702.274f, -152.3726f, 57.45462f), new Vector3(-1691.398f, -158.583f, 57.6211f), new Vector3(-1684.761f, -168.9742f, 57.49302f), new Vector3(-1679.721f, -185.9232f, 57.53905f), new Vector3(-1679.45f, -199.283f, 57.54282f), new Vector3(-1684.6f, -209.7332f, 57.53469f) }, new List<PropLists>()),
            new GreatestHits(2, new Vector3(-1321.412f, -32.89452f, 48.9683f), new Vector3(-1297.746f, -29.46151f, 47.84842f), new Vector4(-1338.219f, 40.63132f, 60.45979f, 225.7309f), new Vector4(-1326.336f, 59.92653f, 53.54417f, 270.3112f), new Vector4(-1335.88f, 44.74322f, 55.24566f, 281.351f), new List<Vector3> { new Vector3(-1399.9f, 66.3326f, 53.34227f), new Vector3(-1393.094f, 14.19838f, 53.2293f), new Vector3(-1382.317f, 16.93267f, 53.57621f), new Vector3(-1378.956f, 16.70747f, 53.51094f), new Vector3(-1373.589f, 13.51838f, 53.42646f), new Vector3(-1366.751f, 23.72099f, 53.77364f), new Vector3(-1355.669f, 21.30159f, 53.35223f), new Vector3(-1339.363f, 23.18568f, 53.33221f), new Vector3(-1334.062f, 24.8021f, 53.5796f), new Vector3(-1335.095f, 39.26785f, 53.56892f), new Vector3(-1337.551f, 44.55224f, 55.24564f), new Vector3(-1341.005f, 59.07327f, 55.24566f), new Vector3(-1339.755f, 57.23912f, 55.24565f), new Vector3(-1340.758f, 72.91788f, 55.24566f), new Vector3(-1338.594f, 73.87442f, 55.24635f), new Vector3(-1339.579f, 80.82087f, 54.30826f), new Vector3(-1341.292f, 83.82114f, 54.47037f), new Vector3(-1343.281f, 106.0034f, 56.14111f), new Vector3(-1345.647f, 126.3551f, 56.23872f), new Vector3(-1355.008f, 144.4275f, 56.2575f), new Vector3(-1379.028f, 142.8582f, 56.08464f), new Vector3(-1385.638f, 140.1001f, 55.89283f), new Vector3(-1384.781f, 108.8661f, 54.98751f), new Vector3(-1391.122f, 106.8313f, 54.66446f), new Vector3(-1394.105f, 105.338f, 54.43337f), new Vector3(-1397.381f, 102.0704f, 54.08099f), new Vector3(-1400.337f, 96.6853f, 53.79763f), new Vector3(-1400.993f, 90.64942f, 53.70214f) }, new List<Vector3> { new Vector3(-1359.25f, 109.761f, 60.62912f), new Vector3(-1358.956f, 100.3841f, 60.62912f), new Vector3(-1358.079f, 94.08092f, 60.62912f), new Vector3(-1364.079f, 94.70335f, 60.62912f), new Vector3(-1364.38f, 108.2094f, 60.62912f), new Vector3(-1362.258f, 111.99f, 60.62912f) }, new List<Vector3> { new Vector3(-1329.007f, 108.6033f, 56.48982f), new Vector3(-1322.103f, 31.90036f, 53.53466f) }, new List<PropLists>()),
            new GreatestHits(11, new Vector3(-1864.986f, 1959.259f, 143.7409f), new Vector3(-1885.544f, 1965.577f, 143.0124f), new Vector4(-1901.163f, 2092.905f, 140.3887f, 13.10736f), new Vector4(-1874.738f, 2089.304f, 140.9944f, 319.0304f), new Vector4(-1854.385f, 2068.078f, 141.0906f, 173.2433f), new List<Vector3> { new Vector3(-1917.044f, 2076.618f, 140.3836f), new Vector3(-1903.564f, 2092.86f, 140.3861f) }, new List<Vector3> { new Vector3(-1879.473f, 2091.383f, 140.9938f), new Vector3(-1863.216f, 2082.07f, 140.9942f), new Vector3(-1865.948f, 2071.529f, 140.9967f), new Vector3(-1883.579f, 2075.255f, 140.9974f), new Vector3(-1903.96f, 2091.038f, 140.3857f) }, new List<Vector3> { new Vector3(-1897.665f, 2058.754f, 140.9139f), new Vector3(-1917.792f, 2076.364f, 140.3837f) }, new List<PropLists>()),
            new GreatestHits(12, new Vector3(-2831.061f, 38.20364f, 14.14951f), new Vector3(-2890.587f, -6.512034f, 6.963f), new Vector4(-3029.618f, 60.41986f, 16.11314f, 111.0933f), new Vector4(-3035.323f, 61.27785f, 11.60313f, 67.78362f), new Vector4(-3017.087f, 47.91266f, 11.60312f, 150.8523f), new List<Vector3> { new Vector3(-3016.97f, 16.51763f, 6.705266f), new Vector3(-3031.105f, 23.01101f, 10.11841f), new Vector3(-3025.127f, 35.15769f, 10.11779f), new Vector3(-3026.633f, 37.19355f, 10.11778f), new Vector3(-3024.499f, 43.38901f, 10.11779f), new Vector3(-3020.429f, 52.10837f, 11.60314f), new Vector3(-3002.373f, 42.45235f, 11.6302f), new Vector3(-2999.926f, 45.96546f, 11.6085f), new Vector3(-2996.425f, 44.29176f, 11.606f), new Vector3(-2998.59f, 38.51485f, 8.603334f), new Vector3(-2995.228f, 37.27494f, 7.958846f), new Vector3(-3008.228f, 12.22274f, 7.085264f) }, new List<Vector3> { new Vector3(-2962.402f, 55.89622f, 11.6085f), new Vector3(-2967.744f, 64.93795f, 11.6085f), new Vector3(-2968.336f, 71.34634f, 11.53587f), new Vector3(-2963.681f, 74.33125f, 11.39804f), new Vector3(-2939.467f, 63.2231f, 12.27784f), new Vector3(-2924.334f, 55.33182f, 11.04195f), new Vector3(-2924.985f, 46.85469f, 11.60516f), new Vector3(-2930.876f, 34.74577f, 11.60752f), new Vector3(-2937.264f, 19.42201f, 11.61003f), new Vector3(-2987.228f, 42.28254f, 11.60849f), new Vector3(-2988.122f, 40.62498f, 11.60306f), new Vector3(-2999.879f, 45.80571f, 11.6085f), new Vector3(-3003.888f, 42.82432f, 11.62649f), new Vector3(-3033.602f, 59.71888f, 11.60313f), new Vector3(-3064.749f, 92.10178f, 11.60836f), new Vector3(-3060.458f, 97.07211f, 12.15885f), new Vector3(-3047.299f, 107.7877f, 12.34625f), new Vector3(-3026.591f, 90.21472f, 12.34663f), new Vector3(-3023.905f, 87.06458f, 11.65143f), new Vector3(-3017.124f, 81.91355f, 11.6752f), new Vector3(-3011.966f, 82.15981f, 11.68586f), new Vector3(-3003.249f, 83.73952f, 11.59328f), new Vector3(-2983.661f, 72.34309f, 11.57396f), new Vector3(-2975.731f, 63.75891f, 11.6085f), new Vector3(-2976.61f, 59.97843f, 11.6085f), new Vector3(-2963.148f, 52.59982f, 11.6085f) }, new List<Vector3> { new Vector3(-3035.562f, 61.8787f, 11.60313f), new Vector3(-3030.359f, 72.34447f, 12.90223f), new Vector3(-3032.417f, 75.52391f, 12.90223f), new Vector3(-3040.525f, 75.92637f, 12.81855f), new Vector3(-3061.576f, 96.1216f, 12.15868f), new Vector3(-3050.11f, 107.5771f, 12.34624f), new Vector3(-3064.66f, 91.81219f, 11.60813f), new Vector3(-3031.909f, 58.83051f, 11.60313f), new Vector3(-3023.458f, 53.66692f, 11.60313f) }, new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList04 = new List<GreatestHits>
        {
            new GreatestHits(2, new Vector3(1102.137f, 259.7896f, 80.34773f), new Vector3(1149.714f, 280.4417f, 80.12628f), new Vector4(1257.96f, 307.1272f, 85.99054f, 147.3938f), new Vector4(1266.325f, 331.7076f, 81.99087f, 141.3652f), new Vector4(1248.288f, 313.2198f, 85.99055f, 81.07424f), new List<Vector3> { new Vector3(1274.831f, 340.8813f, 81.99088f), new Vector3(1292.302f, 325.9212f, 81.99088f), new Vector3(1269.854f, 294.8071f, 81.99088f), new Vector3(1250.756f, 306.1347f, 81.99088f) }, new List<Vector3> { new Vector3(1250.677f, 306.6872f, 81.99088f), new Vector3(1229.07f, 320.3226f, 81.99088f), new Vector3(1252.581f, 352.3154f, 81.99088f), new Vector3(1272.008f, 340.5941f, 81.99088f) }, new List<Vector3> { new Vector3(1261.513f, 335.7514f, 85.99055f), new Vector3(1271.821f, 328.9999f, 85.99055f), new Vector3(1262.331f, 313.6626f, 85.99058f), new Vector3(1252.049f, 320.0551f, 85.9905f) }, new List<PropLists>()),
            new GreatestHits(12, new Vector3(2685.917f, 1610.47f, 24.07866f), new Vector3(2747.758f, 1559.025f, 23.50097f), new Vector4(2710.728f, 1513.976f, 44.46539f, 83.04913f), new Vector4(2739.402f, 1489.967f, 45.29512f, 72.30518f), new Vector4(2715.213f, 1502.91f, 42.24908f, 147.3279f), new List<Vector3> { new Vector3(2716.129f, 1504.041f, 42.24908f), new Vector3(2716.006f, 1500.687f, 42.24792f), new Vector3(2713.639f, 1490.468f, 42.24908f), new Vector3(2727.346f, 1486.386f, 42.24928f), new Vector3(2733.738f, 1484.581f, 45.29513f), new Vector3(2733.411f, 1481.977f, 45.29577f), new Vector3(2737.539f, 1481.092f, 45.29577f), new Vector3(2742.041f, 1498.155f, 45.31561f), new Vector3(2738.764f, 1504.34f, 45.29539f), new Vector3(2741.372f, 1514.76f, 45.29513f), new Vector3(2735.535f, 1516.769f, 42.24856f), new Vector3(2720.756f, 1520.449f, 42.24905f), new Vector3(2716.034f, 1503.323f, 42.24905f) }, new List<Vector3> { new Vector3(2742.201f, 1481.54f, 38.28428f), new Vector3(2742.236f, 1484.91f, 38.2868f), new Vector3(2744.685f, 1493.659f, 38.28878f), new Vector3(2745.892f, 1496.063f, 38.28703f), new Vector3(2750.488f, 1511.828f, 38.28703f), new Vector3(2746.019f, 1496.152f, 38.28718f), new Vector3(2744.494f, 1493.08f, 38.2868f), new Vector3(2741.634f, 1483.431f, 38.29844f), new Vector3(2742.239f, 1481.693f, 38.28377f), new Vector3(2737.501f, 1464.713f, 38.28245f) }, new List<Vector3> { new Vector3(2756.688f, 1486.927f, 30.79179f), new Vector3(2780.408f, 1575.894f, 30.79191f), new Vector3(2773.795f, 1577.714f, 30.79192f), new Vector3(2749.39f, 1487.837f, 30.79178f) }, new List<PropLists>()),
            new GreatestHits(4, new Vector3(2580.741f, -283.8819f, 92.48505f), new Vector3(2593.775f, -288.1873f, 91.88568f), new Vector4(2467.513f, -344.0601f, 109.5219f, 86.07456f), new Vector4(2495.181f, -401.2391f, 114.0868f, 28.69302f), new Vector4(2486.144f, -352.1967f, 114.0861f, 74.73852f), new List<Vector3> { new Vector3(2466.756f, -357.4921f, 109.5219f), new Vector3(2460.675f, -363.1433f, 109.522f), new Vector3(2461.143f, -373.9704f, 109.5218f), new Vector3(2463.292f, -376.8359f, 109.5218f), new Vector3(2463.404f, -396.2715f, 109.522f), new Vector3(2462.222f, -400.6283f, 109.5221f), new Vector3(2462.864f, -405.1978f, 109.5221f), new Vector3(2472.124f, -408.046f, 109.5221f), new Vector3(2479.847f, -399.734f, 109.5221f), new Vector3(2479.611f, -391.726f, 109.5221f), new Vector3(2472.891f, -391.7273f, 109.5221f), new Vector3(2473.624f, -376.7001f, 109.522f), new Vector3(2480.025f, -376.3521f, 109.5221f), new Vector3(2479.721f, -368.9119f, 109.5221f), new Vector3(2474.433f, -362.9229f, 109.5219f), new Vector3(2473.686f, -348.1714f, 109.5219f) }, new List<Vector3> { new Vector3(2512.194f, -358.8307f, 114.0873f), new Vector3(2506.969f, -364.6768f, 114.0872f), new Vector3(2492.725f, -365.5279f, 114.0866f), new Vector3(2487.476f, -360.584f, 114.0864f), new Vector3(2487.479f, -345.9434f, 114.086f), new Vector3(2492.106f, -341.3466f, 114.086f), new Vector3(2499.621f, -340.4717f, 114.0872f), new Vector3(2492.786f, -340.835f, 114.086f), new Vector3(2487.385f, -346.5126f, 114.086f), new Vector3(2487.315f, -359.8349f, 114.0864f), new Vector3(2492.966f, -365.4258f, 114.0867f), new Vector3(2505.558f, -365.2966f, 114.087f), new Vector3(2512.009f, -358.9853f, 114.0873f), new Vector3(2512.221f, -352.3284f, 114.0875f) }, new List<Vector3> { new Vector3(2492.715f, -427.4875f, 114.0879f), new Vector3(2486.577f, -421.6962f, 114.0877f), new Vector3(2486.688f, -408.6144f, 114.0873f), new Vector3(2492.931f, -402.5152f, 114.0871f), new Vector3(2506.004f, -402.6693f, 114.0865f), new Vector3(2512.103f, -408.8118f, 114.0866f), new Vector3(2512.263f, -417.2939f, 114.0884f), new Vector3(2512.247f, -409.3155f, 114.0866f), new Vector3(2504.904f, -402.1249f, 114.0867f), new Vector3(2493.43f, -401.8575f, 114.0871f), new Vector3(2487f, -408.6649f, 114.0874f), new Vector3(2486.758f, -421.5493f, 114.0878f), new Vector3(2492.532f, -427.3813f, 114.0879f), new Vector3(2502.197f, -428.9225f, 114.0905f) }, new List<PropLists>()),
            new GreatestHits(5, new Vector3(261.4789f, 1142.812f, 221.6532f), new Vector3(248.8441f, 1129.461f, 221.3617f), new Vector4(176.3479f, 1226.477f, 231.3266f, 172.7456f), new Vector4(185.3232f, 1212.812f, 231.3265f, 201.5691f), new Vector4(187.8561f, 1229.181f, 231.3266f, 282.6088f), new List<Vector3> { new Vector3(165.3706f, 1243.916f, 229.5994f), new Vector3(170.317f, 1244.953f, 229.5994f), new Vector3(162.8092f, 1243.388f, 229.5994f), new Vector3(166.5291f, 1231.856f, 229.5994f) }, new List<Vector3> { new Vector3(197.3412f, 1210.515f, 225.5948f), new Vector3(213.9503f, 1216.606f, 225.5947f), new Vector3(196.4233f, 1213.144f, 225.5947f), new Vector3(190.265f, 1242.596f, 225.5947f) }, new List<Vector3> { new Vector3(178.9831f, 1206.969f, 225.5954f), new Vector3(183.5664f, 1204.313f, 225.5954f), new Vector3(186.8263f, 1182.507f, 225.5946f), new Vector3(186.1802f, 1162.673f, 225.5944f), new Vector3(197.4359f, 1139.935f, 225.5943f), new Vector3(207.7782f, 1143.113f, 227.0093f), new Vector3(202.2832f, 1166.904f, 227.0045f), new Vector3(196.5689f, 1188.546f, 227.0101f), new Vector3(186.8285f, 1188.397f, 225.5941f), new Vector3(181.9728f, 1208.952f, 225.5955f), new Vector3(178.0035f, 1208.04f, 225.5955f), new Vector3(172.946f, 1228.402f, 231.3267f) }, new List<PropLists>()),
            new GreatestHits(12, new Vector3(790.1108f, 587.7974f, 125.2726f), new Vector3(773.4139f, 589.575f, 124.9152f), new Vector4(682.7437f, 567.4234f, 130.4613f, 157.7996f), new Vector4(652.8771f, 578.6671f, 129.051f, 356.1734f), new Vector4(714.191f, 556.9922f, 129.0508f, 253.2013f), new List<Vector3> { new Vector3(665.4657f, 570.3066f, 129.0466f), new Vector3(596.5162f, 484.8895f, 144.6454f), new Vector3(613.8167f, 472.9295f, 144.6454f), new Vector3(627.2529f, 464.7474f, 144.6454f), new Vector3(660.1801f, 452.9376f, 144.6453f), new Vector3(695.9135f, 448.863f, 144.6446f), new Vector3(697.3724f, 553.0838f, 129.0458f), new Vector3(677.7837f, 559.4578f, 129.0463f) }, new List<Vector3> { new Vector3(738.6559f, 582.8843f, 125.9198f), new Vector3(716.8008f, 590.9428f, 129.0509f), new Vector3(710.4515f, 571.093f, 129.0509f), new Vector3(716.4241f, 569.3599f, 129.0509f), new Vector3(711.1804f, 555.2366f, 129.0509f), new Vector3(715.435f, 569.7562f, 129.0509f), new Vector3(710.6652f, 572.7615f, 129.0509f), new Vector3(717.5749f, 590.2658f, 129.0509f), new Vector3(738.647f, 582.5916f, 125.9197f), new Vector3(746.0137f, 602.2731f, 125.9197f) }, new List<Vector3> { new Vector3(660.1697f, 606.0498f, 129.051f), new Vector3(650.3622f, 576.902f, 129.051f) }, new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList05 = new List<GreatestHits>
        {
            new GreatestHits(4, new Vector3(230.3268f, 2916.2f, 42.67411f), new Vector3(224.7818f, 2882.74f, 42.51745f), new Vector4(273.4961f, 2864.117f, 64.92805f, 157.7332f) ,new Vector4(315.1468f, 2884.779f, 49.57343f, 142.8985f), new Vector4(272.5177f, 2866.132f, 74.17432f, 256.3994f), new List<Vector3> { new Vector3(311.9371f, 2877.399f, 43.48515f), new Vector3(332.7512f, 2846.731f, 43.43607f), new Vector3(287.2278f, 2831.782f, 43.43173f), new Vector3(273.4195f, 2854.501f, 43.64209f) }, new List<Vector3> { new Vector3(263.0713f, 2876.522f, 43.61074f), new Vector3(295.9029f, 2891.116f, 43.60786f), new Vector3(306.0526f, 2875.568f, 43.50587f), new Vector3(265.6938f, 2852.161f, 43.61774f), new Vector3(305.3912f, 2875.516f, 43.50589f), new Vector3(295.8181f, 2892.656f, 43.60744f) }, new List<Vector3> { new Vector3(284.8827f, 2828.409f, 43.43379f), new Vector3(340.744f, 2854.836f, 43.43604f) }, new List<PropLists>()),
            new GreatestHits(11, new Vector3(1583.455f, 3646.516f, 33.97811f), new Vector3(1600.252f, 3601.43f, 34.24609f), new Vector4(1552.73f, 3587.81f, 38.73153f, 205.6844f), new Vector4(1501.693f, 3578.562f, 35.41425f, 249.7173f), new Vector4(1562.053f, 3612.89f, 38.73403f, 173.9365f), new List<Vector3> { new Vector3(1561.882f, 3612.627f, 35.43483f), new Vector3(1570.241f, 3598.013f, 35.34276f), new Vector3(1512.646f, 3564.601f, 35.34513f), new Vector3(1508.009f, 3568.101f, 35.43494f), new Vector3(1503.925f, 3577.993f, 35.42987f) }, new List<Vector3> { new Vector3(1570.469f, 3594.964f, 35.34573f), new Vector3(1542.851f, 3572.031f, 35.36273f), new Vector3(1513.98f, 3561.483f, 35.34253f), new Vector3(1505.999f, 3574.725f, 38.72665f), new Vector3(1504.937f, 3573.891f, 38.73009f), new Vector3(1510.527f, 3563.786f, 38.73009f), new Vector3(1569.854f, 3598.75f, 38.73285f), new Vector3(1564.839f, 3607.901f, 38.73139f), new Vector3(1563.257f, 3606.921f, 38.73143f), new Vector3(1567.208f, 3600.576f, 35.43183f) }, new List<Vector3> { new Vector3(1556.338f, 3602.33f, 38.77517f), new Vector3(1553.705f, 3606.639f, 38.73141f), new Vector3(1549.766f, 3605.031f, 38.73141f), new Vector3(1533.377f, 3594.701f, 38.73153f), new Vector3(1535.362f, 3590.602f, 38.76653f), new Vector3(1534.274f, 3586.417f, 38.7665f), new Vector3(1537.886f, 3579.533f, 38.73153f), new Vector3(1558.568f, 3592.217f, 38.73152f), new Vector3(1557.302f, 3600.265f, 38.77518f) }, new List<PropLists>()),
            new GreatestHits(8, new Vector3(2267.126f, 4997.805f, 42.06471f), new Vector3(2288.661f, 4979.157f, 40.81767f), new Vector4(2328.1f, 4846.455f, 41.80822f, 232.1723f), new Vector4(2306.544f, 4882.843f, 41.80826f, 45.17728f), new Vector4(2307.568f, 4832.615f, 48.176f, 226.672f), new List<Vector3> { new Vector3(2318.967f, 4838.601f, 41.80822f), new Vector3(2354.695f, 4873.283f, 41.80996f) }, new List<Vector3> { new Vector3(2298.175f, 4879.726f, 41.80826f), new Vector3(2304.109f, 4889.827f, 41.80826f), new Vector3(2324.028f, 4900.575f, 41.81262f), new Vector3(2348.52f, 4878.257f, 41.81926f), new Vector3(2353.455f, 4871.659f, 41.81401f), new Vector3(2323.628f, 4845.782f, 41.80827f), new Vector3(2297.261f, 4871.159f, 41.80822f) }, new List<Vector3> { new Vector3(2299.706f, 4869.14f, 41.80819f), new Vector3(2321.647f, 4847.645f, 41.80827f) }, new List<PropLists>()),
            new GreatestHits(17, new Vector3(1674.996f, 4842.517f, 41.52208f), new Vector3(1698.747f, 4881.217f, 41.0342f), new Vector4(1641.539f, 4851.53f, 45.50526f, 358.4285f), new Vector4(1647.802f, 4828.048f, 42.02239f, 22.90079f), new Vector4(1650.428f, 4867.372f, 41.88936f, 263.617f), new List<Vector3> { new Vector3(1644.147f, 4825.98f, 42.01594f), new Vector3(1635.695f, 4857.085f, 42.02081f), new Vector3(1644.741f, 4825.145f, 41.99265f), new Vector3(1661.448f, 4827.105f, 42.07011f) }, new List<Vector3> { new Vector3(1636.811f, 4890.342f, 42.04609f), new Vector3(1638.303f, 4867.082f, 42.02855f) }, new List<Vector3> { new Vector3(1649.929f, 4833.092f, 47.17131f), new Vector3(1657.862f, 4834.355f, 47.17301f) }, new List<PropLists>()),
            new GreatestHits(39, new Vector3(2555.999f, 2706.22f, 41.52115f), new Vector3(2586.596f, 2723.151f, 41.64703f), new Vector4(2712.72f, 2784.174f, 37.87799f, 295.9645f), new Vector4(2690.285f, 2760.773f, 37.84019f, 195.2845f), new Vector4(2677.376f, 2790.567f, 40.5186f, 256.1927f), new List<Vector3> { new Vector3(2759.709f, 2805.8f, 41.73897f), new Vector3(2758.911f, 2807.281f, 41.73896f), new Vector3(2755.162f, 2805.116f, 41.73896f), new Vector3(2759.09f, 2806.964f, 41.73893f), new Vector3(2760.083f, 2806.064f, 41.73896f), new Vector3(2761.239f, 2806.703f, 41.73893f) }, new List<Vector3> { new Vector3(2688.278f, 2770.796f, 37.878f), new Vector3(2692.782f, 2762.073f, 37.87238f), new Vector3(2684.776f, 2758.062f, 37.87803f), new Vector3(2678.576f, 2766.702f, 37.87803f), new Vector3(2671.472f, 2763.025f, 37.87803f) }, new List<Vector3> { new Vector3(2732.909f, 2843.75f, 38.53904f), new Vector3(2678.177f, 2841.705f, 40.0709f), new Vector3(2676.612f, 2799.527f, 40.43023f), new Vector3(2685.635f, 2798.989f, 40.23642f), new Vector3(2687.616f, 2816.012f, 40.36447f), new Vector3(2709.445f, 2821.631f, 40.00f) }, new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList06 = new List<GreatestHits>
        {
            new GreatestHits(11, new Vector3(-800.3827f, 5563.648f, 31.62369f), new Vector3(-823.821f, 5561.648f, 30.46187f), new Vector4(-737.0172f, 5567.404f, 36.70968f, 264.3277f), new Vector4(-736.4711f, 5588.167f, 41.65414f, 206.0923f), new Vector4(-741.9067f, 5557.609f, 36.70968f, 178.5684f), new List<Vector3> { new Vector3(-746.4897f, 5594.63f, 41.65459f), new Vector3(-748.2638f, 5587.582f, 41.65414f), new Vector3(-754.9839f, 5587.543f, 41.65474f), new Vector3(-755.6539f, 5602.023f, 41.66507f), new Vector3(-747.6964f, 5602.552f, 41.65459f), new Vector3(-747.2025f, 5595.154f, 41.65459f), new Vector3(-738.0662f, 5595.271f, 41.65459f) }, new List<Vector3> { new Vector3(-754.9137f, 5599.81f, 41.66511f), new Vector3(-749.9346f, 5600.047f, 40.64637f), new Vector3(-749.7846f, 5590.161f, 38.02629f), new Vector3(-756.705f, 5589.916f, 36.71615f), new Vector3(-758.0966f, 5588.067f, 36.70622f), new Vector3(-760.3561f, 5587.396f, 36.70622f), new Vector3(-760.1637f, 5601.39f, 36.70622f), new Vector3(-757.8819f, 5601.993f, 36.70622f), new Vector3(-757.6944f, 5591.96f, 36.70622f), new Vector3(-751.4635f, 5591.595f, 38.0263f), new Vector3(-751.5088f, 5598.002f, 40.64657f), new Vector3(-755.4155f, 5598.173f, 41.66508f) }, new List<Vector3> { new Vector3(-757.9305f, 5584.678f, 36.70965f), new Vector3(-757.6879f, 5600.951f, 36.70622f), new Vector3(-760.2615f, 5601.565f, 36.70622f), new Vector3(-759.8745f, 5584.589f, 36.70969f), new Vector3(-767.577f, 5584.732f, 33.60597f), new Vector3(-767.842f, 5582.199f, 33.60597f), new Vector3(-761.2136f, 5582.326f, 36.70964f), new Vector3(-754.5424f, 5583.642f, 36.70964f) }, new List<PropLists>()),
            new GreatestHits(17, new Vector3(-638.0407f, 5250.491f, 74.33782f), new Vector3(-665.6201f, 5244.412f, 75.6614f), new Vector4(-534.6129f, 5295.723f, 76.22177f, 163.9837f), new Vector4(-557.3286f, 5283.622f, 77.1786f, 280.9823f), new Vector4(-507.0502f, 5298.56f, 80.59415f, 125.2596f), new List<Vector3> { new Vector3(-507.8468f, 5303.367f, 80.23985f), new Vector3(-498.7983f, 5327.183f, 80.26272f), new Vector3(-507.5448f, 5302.066f, 80.23985f), new Vector3(-526.7314f, 5308.281f, 80.23985f) }, new List<Vector3> { new Vector3(-539.9435f, 5252.771f, 74.94093f), new Vector3(-518.7679f, 5244.862f, 79.98583f), new Vector3(-510.9202f, 5270.467f, 80.53647f), new Vector3(-520.3823f, 5246.012f, 79.83928f), new Vector3(-540.4612f, 5253.007f, 74.84053f), new Vector3(-527.8826f, 5291.014f, 74.17958f) }, new List<Vector3> { new Vector3(-568.4789f, 5291.338f, 75.39369f), new Vector3(-514.6453f, 5271.71f, 80.65714f) }, new List<PropLists>()),
            new GreatestHits(24, new Vector3(-131.1716f, 6322.359f, 30.90629f), new Vector3(-135.5479f, 6334.841f, 30.47937f), new Vector4(-81.57904f, 6364.71f, 35.41002f, 275.6308f), new Vector4(-84.6138f, 6361.315f, 31.5759f, 156.8777f), new Vector4(-87.35072f, 6371.907f, 35.12779f, 37.15335f), new List<Vector3> { new Vector3(-109.1785f, 6337.84f, 35.50075f), new Vector3(-88.0182f, 6358.469f, 35.50075f), new Vector3(-108.9201f, 6336.981f, 35.50075f), new Vector3(-99.96815f, 6328.335f, 35.50035f) }, new List<Vector3> { new Vector3(-100.9715f, 6310.309f, 31.49037f), new Vector3(-90.23823f, 6321.042f, 31.49037f), new Vector3(-103.6349f, 6308.77f, 31.49044f), new Vector3(-110.2449f, 6315.527f, 31.49036f) }, new List<Vector3> { new Vector3(-87.65194f, 6325.415f, 31.49036f), new Vector3(-90.99855f, 6339.509f, 31.49036f), new Vector3(-74.31131f, 6352.809f, 31.49036f), new Vector3(-66.301f, 6346.253f, 31.49036f) }, new List<PropLists>()),
            new GreatestHits(15, new Vector3(-420.1826f, 6124.761f, 30.82228f), new Vector3(-431.6277f, 6139.681f, 30.47821f), new Vector4(-368.007f, 6099.551f, 35.43965f, 137.4085f), new Vector4(-367.6535f, 6111.827f, 39.46238f, 302.0133f), new Vector4(-375.8508f, 6120.208f, 35.43965f, 348.0855f), new List<Vector3> { new Vector3(-380.4186f, 6119.364f, 31.54456f), new Vector3(-391.5671f, 6131.014f, 31.37105f) }, new List<Vector3> { new Vector3(-363.4133f, 6137.021f, 31.4421f), new Vector3(-342.4623f, 6115.922f, 31.44272f) }, new List<Vector3> { new Vector3(-369.2594f, 6090.41f, 31.45273f), new Vector3(-380.0799f, 6104.286f, 31.44447f), new Vector3(-364.4882f, 6091.61f, 31.44446f), new Vector3(-343.9828f, 6115.645f, 31.44182f) }, new List<PropLists>()),
            new GreatestHits(8, new Vector3(1544.126f, 6403.336f, 23.61435f), new Vector3(1625.025f, 6352.656f, 39.91281f), new Vector4(1414.122f, 6340.835f, 24.10848f, 94.37645f), new Vector4(1511.34f, 6328.012f, 24.60712f, 51.32638f), new Vector4(1434.69f, 6354.518f, 23.98501f, 120.5622f), new List<Vector3> { new Vector3(1438.554f, 6350.476f, 23.98502f), new Vector3(1464.721f, 6353.114f, 23.84916f), new Vector3(1439.869f, 6346.296f, 23.96572f), new Vector3(1439.893f, 6334.007f, 23.92226f) }, new List<Vector3> { new Vector3(1422.331f, 6354.054f, 23.985f), new Vector3(1418.82f, 6358.752f, 23.98615f), new Vector3(1425.885f, 6348.37f, 23.985f), new Vector3(1433.309f, 6330.135f, 23.9949f) }, new List<Vector3> { new Vector3(1485.165f, 6353.153f, 23.97673f), new Vector3(1511.616f, 6332.944f, 23.97563f) } , new List<PropLists>())
        };
        public static readonly List<GreatestHits> HitList07 = new List<GreatestHits>
        {
            new GreatestHits(38, new Vector3(4513.035f, -4451.502f, 3.732822f), new Vector3(4513.035f, -4451.502f, 3.732822f), new Vector4(4503.695f, -4553.788f, 4.1719f, 200.9265f), new Vector4(4523.792f, -4536.616f, 7.552061f, 21.41515f), new Vector4(4518.237f, -4550.28f, 7.56531f, 45.2341f), new List<Vector3> { new Vector3(4498.449f, -4538.28f, 4.171075f), new Vector3(4511.435f, -4529.924f, 4.219851f), new Vector3(4505.698f, -4511.168f, 3.960274f), new Vector3(4490.829f, -4513.242f, 4.124402f), new Vector3(4503.334f, -4509.995f, 4.092979f), new Vector3(4512.584f, -4529.077f, 4.193905f) }, new List<Vector3> { new Vector3(4527.535f, -4527.914f, 4.193107f), new Vector3(4521.755f, -4529.071f, 4.143321f), new Vector3(4509.937f, -4510.527f, 4.114697f), new Vector3(4526.833f, -4495.362f, 4.18601f), new Vector3(4512.508f, -4503.898f, 4.183725f), new Vector3(4517.468f, -4527.148f, 4.178466f) }, new List<Vector3> { new Vector3(4492.424f, -4570.478f, 5.6365f), new Vector3(4471.955f, -4513.821f, 4.187965f) },new List<PropLists>()),
            new GreatestHits(38, new Vector3(4988.147f, -4535.954f, 8.097687f), new Vector3(4988.147f, -4535.954f, 8.097687f), new Vector4(5123.886f, -4642.248f, 1.400684f, 164.0761f),new Vector4(5094.524f, -4655.409f, 1.757612f, 260.6545f),new Vector4(5033.615f, -4631.193f, 21.68073f, 256.7936f), new List<Vector3> { new Vector3(5084.328f, -4681.426f, 2.385362f), new Vector3(5072.037f, -4673.802f, 2.932216f), new Vector3(5059.477f, -4634.299f, 2.648646f), new Vector3(5035.237f, -4617.473f, 3.513743f), new Vector3(5057.626f, -4636.332f, 2.633209f), new Vector3(5069.723f, -4672.357f, 2.989979f), new Vector3(5085.625f, -4681.076f, 2.407427f) }, new List<Vector3> { new Vector3(5166.854f, -4698.667f, 2.178764f), new Vector3(5166.389f, -4671.986f, 2.766574f), new Vector3(5173.757f, -4644.004f, 2.853223f), new Vector3(5173.076f, -4635.888f, 2.819802f), new Vector3(5173.601f, -4644.069f, 2.85945f), new Vector3(5164.905f, -4674.674f, 2.70859f), new Vector3(5166.289f, -4703.957f, 2.079124f) }, new List<Vector3> { new Vector3(5053.102f, -4607.109f, 2.916398f), new Vector3(5079.043f, -4611.108f, 2.960062f), new Vector3(5130.677f, -4624.859f, 2.82174f), new Vector3(5153.719f, -4628.627f, 2.988436f), new Vector3(5155.554f, -4597.353f, 3.518908f), new Vector3(5139.344f, -4589.227f, 4.864506f), new Vector3(5107.482f, -4614.512f, 2.567264f), new Vector3(5068.46f, -4608.898f, 2.732914f) }, new List<PropLists>()),
            new GreatestHits(38, new Vector3(5257.43f, -5263.344f, 24.48767f), new Vector3(5257.43f, -5263.344f, 24.48767f),new Vector4(5330.616f, -5270.467f, 33.18246f, 121.288f),new Vector4(5329.722f, -5273.086f, 36.87106f, 161.2967f),new Vector4(5328.118f, -5263.481f, 37.27973f, 356.2472f), new List<Vector3> { new Vector3(5381.01f, -5303.126f, 35.70126f), new Vector3(5321.302f, -5249.752f, 32.57737f) }, new List<Vector3> { new Vector3(5280.464f, -5290.719f, 31.71746f), new Vector3(5386.142f, -5184.534f, 31.11724f) }, new List<Vector3> { new Vector3(5285.92f, -5215.083f, 30.47023f), new Vector3(5319.126f, -5247.02f, 32.57311f), new Vector3(5349.337f, -5217.763f, 31.12744f), new Vector3(5311.005f, -5179.859f, 29.67479f), new Vector3(5349.229f, -5218.341f, 31.14395f), new Vector3(5320.939f, -5247.692f, 32.56763f) }, new List<PropLists>()),
            new GreatestHits(38, new Vector3(5155.222f, -5128.624f, 1.295301f), new Vector3(5155.222f, -5128.624f, 1.295301f),new Vector4(5042.745f, -5114.8f, 22.93991f, 94.88478f),new Vector4(5046.298f, -5112.081f, 12.57241f, 359.2585f),new Vector4(5040.758f, -5117.302f, 18.13903f, 131.8663f), new List<Vector3> { new Vector3(5036.303f, -5116.772f, 5.737444f), new Vector3(5012.694f, -5129.415f, 2.9919f), new Vector3(5018.085f, -5152.899f, 2.65039f), new Vector3(5038.566f, -5195.042f, 2.682085f), new Vector3(5044.731f, -5215.362f, 3.057317f), new Vector3(5036.879f, -5194.092f, 2.545181f), new Vector3(5019.313f, -5157.417f, 2.574997f), new Vector3(5020.292f, -5132.826f, 3.109585f), new Vector3(5027.321f, -5120.981f, 4.317581f)}, new List<Vector3> { new Vector3(5119.485f, -5085.836f, 2.299197f), new Vector3(5114.708f, -5108.212f, 2.1675f), new Vector3(5112.895f, -5121.462f, 2.206454f), new Vector3(5112.96f, -5140.31f, 2.199696f), new Vector3(5112.614f, -5156.182f, 2.245853f), new Vector3(5112.858f, -5175.816f, 2.313444f), new Vector3(5113.223f, -5202.912f, 2.384449f), new Vector3(5121.214f, -5209.073f, 2.665782f), new Vector3(5134.446f, -5206.216f, 2.926885f), new Vector3(5130.966f, -5208.709f, 2.978797f), new Vector3(5117.441f, -5208.045f, 2.54545f), new Vector3(5114.211f, -5199.12f, 2.352396f), new Vector3(5112.896f, -5175.494f, 2.310411f), new Vector3(5113.439f, -5154.506f, 2.263836f), new Vector3(5113.521f, -5136.032f, 2.311946f), new Vector3(5113.716f, -5116.948f, 2.209894f) }, new List<Vector3> { new Vector3(5013.922f, -5135.069f, 2.982546f), new Vector3(4986.65f, -5151.049f, 2.530167f), new Vector3(4989.745f, -5169.334f, 2.545022f), new Vector3(5000.681f, -5182.458f, 2.514796f), new Vector3(5017.758f, -5184.628f, 2.520133f), new Vector3(5026.959f, -5173.516f, 2.783011f), new Vector3(5020.555f, -5144.618f, 2.671165f) }, new List<PropLists>()),
            new GreatestHits(38, new Vector3(4985.809f, -5713.806f, 18.8802f), new Vector3(4985.809f, -5713.806f, 18.8802f),new Vector4(5009.038f, -5754.581f, 28.84526f, 149.7885f),new Vector4(5023.134f, -5748.972f, 19.87768f, 276.0576f),new Vector4(5001.348f, -5754.646f, 19.87576f, 149.9054f), new List<Vector3> { new Vector3(5002.911f, -5752.313f, 28.68233f), new Vector3(5006.708f, -5746.745f, 28.68233f), new Vector3(5009.672f, -5741.836f, 26.49426f), new Vector3(5018.38f, -5747.015f, 24.2728f), new Vector3(5009.93f, -5741.321f, 26.49229f), new Vector3(5006.693f, -5746.122f, 28.68328f) }, new List<Vector3> { new Vector3(5013.232f, -5743.474f, 19.88034f), new Vector3(5005.97f, -5740.077f, 19.88021f), new Vector3(5003.674f, -5736.941f, 19.88022f), new Vector3(5002.887f, -5734.158f, 19.8803f), new Vector3(5004.678f, -5738.075f, 19.88023f), new Vector3(5007.891f, -5741.285f, 19.8802f) }, new List<Vector3> { new Vector3(5030.402f, -5749.088f, 16.27834f), new Vector3(5020.631f, -5762.595f, 16.27756f), new Vector3(5004.514f, -5774.552f, 16.27845f), new Vector3(5024.32f, -5745.851f, 16.28125f) }, new List<PropLists>())
        };
        public static List<GreatestHits> HitList08 = new List<GreatestHits>();
        public static List<GreatestHits> HitList09 = new List<GreatestHits>();

        private static readonly List<SnipSnip> Sniping01 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(-52.39356f, -1813.045f, 26.80028f), false, false, false, false, true, false, 1f, "patriot2", "", new Vector4(-237.30f, -1864.03f, 28.507f, -129.37f), new Vector4(-96.60f, -1819.89f, 39.66f, 133.99f), new Vector3(-99.45f, -1819.29f, 39.61f), new Vector3(1.173841f, -2084.533f, 10.27177f), new List<string> { "ig_lazlow", "s_f_y_hooker_01", "s_f_y_hooker_02" }, new List<Vector3> { new Vector3(-63.81522f, -1814.423f, 26.30946f), new Vector3(-76.04329f, -1826.519f, 25.96788f)}, new List<Vector3> { new Vector3(-283.6614f, -1920.319f, 29.94604f), new Vector3(-271.938f, -1906.55f, 27.75543f), new Vector3(-257.5812f, -1888.85f, 27.75542f), new Vector3(-240.9867f, -1869.194f, 28.72783f)}),
            new SnipSnip(new Vector3(-148.3239f, -2498.115f, 48.23492f), false, true, false, false, true, false,1.1f, "buzzard", "", new Vector4(-91.91f, -2366.00f, 14.19f, -90.00f), new Vector4(-142.49f, -2492.55f, 38.69f, 142.82f), new Vector3(-141.2386f, -2489.908f, 38.64299f), new Vector3(-91.22655f, -2128.627f, 172.1778f),new List<string> { "mp_m_boatstaff_01","s_m_m_dockwork_01","s_m_y_dockwork_01"},new List<Vector3> { new Vector3(-147.1746f, -2495.572f, 47.64235f),new Vector3(-142.8934f, -2489.257f, 43.43131f),new Vector3(-140.3822f, -2492.563f, 43.41021f)}, new List<Vector3> { new Vector3(-224.424f, -2378.809f, 13.32783f), new Vector3(-221.8366f, -2375.888f, 13.33286f), new Vector3(-230.9789f, -2376.082f, 9.319943f), new Vector3(-229.9068f, -2377.621f, 9.319208f), new Vector3(-217.1268f, -2378.097f, 9.319208f), new Vector3(-190.2658f, -2378.049f, 9.319207f), new Vector3(-163.6719f, -2378.149f, 9.319208f), new Vector3(-132.1169f, -2378.01f, 9.319206f), new Vector3(-105.5747f, -2375.241f, 9.348871f), new Vector3(-94.68478f, -2370.378f, 14.29715f) }),
            new SnipSnip(new Vector3(1626.753f, -2247.719f, 107.1201f), true, false, false, false, false, false, 12.1f, "baller4", "forklift", new Vector4(1525.31f, -2190.78f, 77.04f, -122.89f), new Vector4(1609.77f, -2244.16f, 131.90f, 91.684f), new Vector3(1611.449f, -2240.708f, 131.8374f), new Vector3(1510.977f, -2523.41f, 55.98611f), new List<string> { "ig_clay", "g_f_y_lost_01", "g_m_y_lost_01" }, new List<Vector3> { new Vector3(1617.064f, -2252.443f, 106.1618f), new Vector3(1614.131f, -2248.433f, 106.1782f), new Vector3(1613.277f, -2250.416f, 116.6229f), new Vector3(1619.174f, -2244.328f, 125.3414f) }, new List<Vector3> { new Vector3(1505.884f, -2051.74f, 77.12805f), new Vector3(1518.824f, -2039.351f, 77.53979f), new Vector3(1532.996f, -2060.174f, 77.23707f), new Vector3(1532.535f, -2095.141f, 77.06099f), new Vector3(1531.298f, -2129.96f, 76.86242f), new Vector3(1538.679f, -2166.652f, 77.56755f), new Vector3(1534.212f, -2182.944f, 77.32477f) }),
            new SnipSnip(new Vector3(522.9589f, -2121.328f, 5.986343f), false, false, false, false, true, false, 1.1f, "minivan2", "", new Vector4(290.39f, -2016.78f, 19.4f, -37.00f), new Vector4(486.62f, -2121.71f, 49.10f, 148.00f), new Vector3(482.3192f, -2123.41f, 49.03839f), new Vector3(200.0317f, -1786.101f, 28.69968f),new List<string> { "ig_benny_02", "g_f_y_vagos_01", "g_m_y_mexgoon_01" }, new List<Vector3> { new Vector3(499.7295f, -2116.985f, 4.917536f), new Vector3(488.3468f, -2120.284f, 5.375771f), new Vector3(482.974f, -2121.739f, 14.23045f), new Vector3(482.9576f, -2126.292f, 25.81391f), new Vector3(487.4316f, -2126.353f, 37.42408f) }, new List<Vector3> { new Vector3(315.3189f, -2097.129f, 17.50116f), new Vector3(302.5442f, -2063.688f, 18.2312f), new Vector3(303.086f, -2059.917f, 18.86057f), new Vector3(295.8217f, -2053.35f, 18.96108f), new Vector3(310.8098f, -2033.821f, 20.69437f), new Vector3(293.6351f, -2018.529f, 19.80344f) }),
            new SnipSnip(new Vector3(414.5399f, -1517.968f, 29.29162f), false, false, false, false, true, false, 1.1f, "policet", "", new Vector4(373.83f, -1575.09f, 29.71f, -130.52f), new Vector4(420.27f, -1517.90f, 39.98f, 158.53f), new Vector3(418.5329f, -1515.725f, 39.92151f), new Vector3(406.7181f, -1679.579f, 29.18816f),new List<string> { "csb_ary", "s_f_y_cop_01", "s_m_y_cop_01" }, new List<Vector3> { new Vector3(429.7804f, -1522.701f, 28.31102f), new Vector3(426.9528f, -1516.567f, 28.29379f) }, new List<Vector3> { new Vector3(337.1129f, -1595.743f, 29.31662f), new Vector3(342.6818f, -1599.789f, 29.29186f), new Vector3(363.1718f, -1575.907f, 29.29168f), new Vector3(368.7278f, -1574.266f, 29.21689f)})
        };
        private static readonly List<SnipSnip> Sniping02 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(-901.6092f, -1180.243f, 4.865562f), false, false, false, false, false, false, 1.6f, "stretch", "",new Vector4(-812.5729f, -1331.195f, 4.68f, -101.91f),new Vector4(-899.304932f, -1165.75439f, 31.8383083f, -64.7457047f),new Vector3(-899.452f, -1167.032f, 31.75019f),new Vector3(-533.8893f, -1074.366f, 21.99339f), new List<string> { "ig_celeb_01","g_m_y_ballaeast_01","g_m_y_ballasout_01"}, new List<Vector3> { new Vector3(-903.5526f, -1169.307f, 3.926487f),new Vector3(-914.2826f, -1149.552f, 1.036643f),new Vector3(-909.5115f, -1148.314f, 1.044488f),new Vector3(-902.5053f, -1161.428f, 21.12465f)}, new List<Vector3> { new Vector3(-704.1928f, -1286.686f, 5.070818f),new Vector3(-710.6364f, -1285.78f, 5.000392f),new Vector3(-726.6035f, -1301.622f, 5.0944f),new Vector3(-756.1138f, -1337.266f, 5.000381f),new Vector3(-761.2098f, -1339.402f, 5.060724f),new Vector3(-768.2056f, -1339.035f, 5.150265f),new Vector3(-796.9508f, -1338.635f, 5.150053f),new Vector3(-814.366f, -1335.805f, 5.15013f)}),
            new SnipSnip(new Vector3(-1142.996f, -709.1315f, 21.12931f), false, true, false, false, true, false, 1.1f, "supervolito2", "",new Vector4(-1219.82922f, -832.427917f, 30.0882244f, -143.067307f),new Vector4(-1251.14917f, -710.507446f, 41.0659637f, -142.008469f),new Vector3(-1256.44f, -713.6105f, 41.00478f),new Vector3(-772.4334f, -1080.924f, 234.9111f), new List<string> { "ig_moodyman_02","g_m_y_famdnf_01","g_m_y_famfor_01"},new List<Vector3> { new Vector3(-1206.049f, -728.9968f, 20.29629f),new Vector3(-1220.603f, -735.7182f, 29.12308f),new Vector3(-1232.487f, -720.4894f, 35.20114f),new Vector3(-1248.031f, -710.142f, 31.61778f)},new List<Vector3> { new Vector3(-1274.2f, -783.69f, 24.0265f),new Vector3(-1266.367f, -794.3172f, 25.83017f),new Vector3(-1259.713f, -802.4952f, 24.39178f),new Vector3(-1248.851f, -808.8292f, 26.24278f),new Vector3(-1243.325f, -818.8814f, 23.26458f),new Vector3(-1228.425f, -829.6564f, 29.41312f)}),
            new SnipSnip(new Vector3(-552.3256f, -160.1231f, 38.22237f), false, false, false, false, false, false,1.1f, "ambulance", "",  new Vector4(-517.164795f, -291.921753f, 34.9778481f, 21.147583f),new Vector4(-535.675476f, -189.751999f, 51.2642136f, 82.1137238f),new Vector3(-537.7788f, -197.8025f, 51.20306f),new Vector3(-211.8083f, -468.8962f, 33.91315f), new List<string> { "ig_tenniscoach","a_m_y_runner_01","a_m_y_runner_02"}, new List<Vector3> { new Vector3(-539.5616f, -172.7763f, 37.22472f),new Vector3(-530.9963f, -168.4125f, 45.18797f),new Vector3(-528.0113f, -180.5775f, 48.48454f)}, new List<Vector3> { new Vector3(-484.99f, -327.1964f, 34.50163f),new Vector3(-481.104f, -326.3269f, 34.50175f),new Vector3(-498.0943f, -287.0561f, 35.54318f),new Vector3(-511.712f, -293.5264f, 35.37545f)}),
            new SnipSnip(new Vector3(395.9652f, 251.7253f, 102.9583f), false, false, false, false, false,false,1.1f, "stafford", "",new Vector4(394.497467f, 111.11515f, 101.35421f, -110.337532f),new Vector4(326.212189f, 182.684525f, 140.552689f, 116.339424f),new Vector3(332.7156f, 169.2088f, 140.4917f),new Vector3(428.7456f, -68.80369f, 72.40679f),new List<string> { "cs_johnnyklebitz","s_m_m_highsec_01","s_m_m_highsec_01"}, new List<Vector3> { new Vector3(348.5934f, 263.42f, 101.9965f),new Vector3(371.7625f, 254.8226f, 113.5975f),new Vector3(370.0683f, 236.2339f, 111.8926f),new Vector3(361.5274f, 230.3621f, 114.3746f),new Vector3(349.5027f, 262.4113f, 132.5603f),new Vector3(333.5866f, 206.4837f, 132.5543f),new Vector3(325.1427f, 185.3306f, 126.7474f)},new List<Vector3> { new Vector3(409.1886f, 92.28789f, 101.2019f),new Vector3(408.1118f, 101.3323f, 101.133f),new Vector3(392.3976f, 107.645f, 102.0331f)}),
            new SnipSnip(new Vector3(728.1499f, 1204.013f, 325.9676f), false, true, false, false, false, false, 1.1f, "supervolito2", "", new Vector4(794.453857f, 1209.37341f, 339.844208f, -46.0405502f),new Vector4(723.039246f, 1197.38171f, 346.447906f, 165.174927f),new Vector3(724.4669f, 1197.652f, 346.3817f),new Vector3(1497.586f, 1268.98f, 498.4335f), new List<string> { "ig_rashcosvki","ig_mp_agent14","csb_mrs_r"},new List<Vector3> { new Vector3(721.8103f, 1201.43f, 325.0515f),new Vector3(721.4466f, 1198.325f, 325.079f)},new List<Vector3> { new Vector3(856.5098f, 1275.719f, 359.3414f),new Vector3(849.0818f, 1255.996f, 357.0718f),new Vector3(838.7529f, 1247.048f, 353.8336f),new Vector3(813.7178f, 1235.433f, 345.9107f),new Vector3(797.9383f, 1217.292f, 340.1477f)})
        };
        private static readonly List<SnipSnip> Sniping03 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(-3232.813f, 965.1881f, 13.08189f), false, false, true, false, false, false, 1.4f, "speeder", "", new Vector4(-3309.61f, 1089.70f, -0.4f, -13.00f), new Vector4(-3420.94482f, 976.996521f, 10.9691763f, -135.763382f), new Vector3(-3418.42f, 976.1917f, 14.18161f), new Vector3(-3058.482f, 2248.754f, 0.3360786f), new List<string> { "csb_englishdave", "g_m_y_strpunk_01", "g_m_y_strpunk_02" }, new List<Vector3> { new Vector3(-3241.899f, 967.6119f, 11.7305f), new Vector3(-3264.134f, 967.4985f, 7.832884f), new Vector3(-3284.675f, 967.6938f, 7.376719f), new Vector3(-3410.049f, 967.4825f, 7.346264f), new Vector3(-3411.612f, 977.9791f, 10.86504f) }, new List<Vector3> { new Vector3(-3253.177f, 1070.442f, 11.02895f), new Vector3(-3260.593f, 1071.885f, 7.850229f), new Vector3(-3270.668f, 1074.162f, 3.974665f), new Vector3(-3286.846f, 1081.408f, 2.21388f), new Vector3(-3297.667f, 1089.087f, 1.676091f) }),
            new SnipSnip(new Vector3(-2296.375f, 376.8973f, 174.4613f), false, false, false, false, true, true, 1.25f, "schafter2", "", new Vector4(-2316.23535f, 280.748199f, 168.793015f, 23.8686886f), new Vector4(-2234.87891f, 188.255219f, 193.672852f, -157.341675f), new Vector3(-2237.494f, 184.2923f, 193.60f), new Vector3(-2337.411f, 246.3529f, 2000.5959f), new List<string> { "csb_fos_rep", "s_m_m_scientist_01", "s_m_m_scientist_01" }, new List<Vector3> { new Vector3(-2291.548f, 366.649f, 173.6017f), new Vector3(-2287.745f, 357.8835f, 173.6017f), new Vector3(-2266.881f, 324.847f, 173.602f), new Vector3(-2209.648f, 224.2172f, 173.6018f), new Vector3(-2201.725f, 227.0897f, 176.1071f), new Vector3(-2205.865f, 215.1031f, 183.6019f), new Vector3(-2183.178f, 219.8145f, 183.6037f), new Vector3(-2186.547f, 219.4696f, 193.6064f), new Vector3(-2207.252f, 202.038f, 193.5965f) }, new List<Vector3> { new Vector3(-2311.173f, 206.41f, 167.5969f), new Vector3(-2311.235f, 211.4904f, 167.6017f), new Vector3(-2310.417f, 213.2059f, 167.6017f), new Vector3(-2312.768f, 219.6458f, 167.6017f), new Vector3(-2305.039f, 224.0858f, 167.6017f), new Vector3(-2306.807f, 229.2074f, 167.6017f), new Vector3(-2299.601f, 233.4502f, 167.6017f), new Vector3(-2300.395f, 235.62f, 167.6017f), new Vector3(-2304.117f, 234.3279f, 167.6017f), new Vector3(-2309.986f, 243.8612f, 169.6021f), new Vector3(-2332.097f, 237.3739f, 169.6021f) }),
            new SnipSnip(new Vector3(-1622.132f, -120.9671f, 57.74456f), false, false, false, false, false, false, 1.25f, "schafter3", "", new Vector4(-1842.36389f, -236.628036f, 39.5220337f, 35.6636963f), new Vector4(-1808.18347f, -121.532021f, 77.8477097f, -169.708588f), new Vector3(-1806.581f, -129.6314f, 77.78653f), new Vector3(-2217.39f, -335.537f, 13.36339f), new List<string> { "csb_miguelmadrazo", "g_f_y_vagos_01", "g_m_y_mexgang_01" }, new List<Vector3> { new Vector3(-1637.315f, -125.3697f, 57.53909f), new Vector3(-1673.316f, -131.1057f, 58.88385f), new Vector3(-1752.80f, -186.19f, 56.52758f), new Vector3(-1787.243f, -169.3512f, 64.69445f), new Vector3(-1792.759f, -139.7194f, 72.73838f) }, new List<Vector3> { new Vector3(-1761.541f, -293.1209f, 46.4999f), new Vector3(-1772.54f, -278.7695f, 45.97911f), new Vector3(-1801.59f, -256.062f, 44.18272f), new Vector3(-1810.234f, -241.7745f, 44.13151f), new Vector3(-1812.575f, -233.0101f, 45.68402f), new Vector3(-1816.75f, -231.2299f, 44.50526f), new Vector3(-1820.13f, -230.6422f, 43.36473f), new Vector3(-1823.719f, -231.3938f, 42.15359f), new Vector3(-1829.478f, -235.0016f, 40.76944f), new Vector3(-1835.322f, -238.0768f, 40.5193f) }),
            new SnipSnip(new Vector3(-3143.2f, 1096.435f, 20.69279f), false, false, false, false, false, false, 1.4f, "mesa", "", new Vector4(-3235.34f, 992.59f, 12.00f, 178.00f), new Vector4(-3176.80835f, 1088.31287f, 24.550312f, 110.126755f), new Vector3(-3192.182f, 1060.804f, 24.48411f), new Vector3(-3046.207f, 712.6321f, 22.73178f), new List<string> { "u_m_m_markfost", "a_f_y_beach_01", "a_f_y_beach_02" }, new List<Vector3> { new Vector3(-3154.447f, 1102.671f, 19.84902f), new Vector3(-3170.599f, 1092.957f, 19.86631f) }, new List<Vector3> { new Vector3(-3244.792f, 1026.782f, 11.7577f), new Vector3(-3237.509f, 1025.259f, 11.76523f), new Vector3(-3237.752f, 1014.913f, 12.23955f), new Vector3(-3238.266f, 1000.198f, 12.54148f) }),
            new SnipSnip(new Vector3(-2033.58f, 1993.53f, 189.9659f), false, false, false, false, false, false, 1.4f, "huntley", "", new Vector4(-1902.75366f, 2044.20801f, 140.096344f, 168.497162f), new Vector4(-2022.192f, 1996.33f, 188.26f, -9.5f), new Vector3(-2018.471f, 1993.52f, 187.5099f), new Vector3(-1646.351f, 2159.189f, 97.10601f), new List<string> { "csb_jackhowitzer", "a_m_m_golfer_01", "a_m_y_golfer_01" }, new List<Vector3> { new Vector3(-2030.423f, 1992.809f, 188.8718f), new Vector3(-2027.728f, 1993.304f, 188.6506f) }, new List<Vector3> { new Vector3(-1898.178f, 2088.017f, 140.3899f), new Vector3(-1906.812f, 2090.266f, 140.3851f), new Vector3(-1916.194f, 2077.79f, 140.3837f), new Vector3(-1913.411f, 2073.407f, 140.386f), new Vector3(-1905.494f, 2048.46f, 140.7386f) })
        };
        private static readonly List<SnipSnip> Sniping04 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(2076.883f, 1997.915f, 88.87595f), true, true, false, false, false, false, 8.6f, "frogger", "SCORCHER",new Vector4(2281.09f, 1861.35f, 108.56f, -161.64f),new Vector4(2052.02319f, 2004.14575f, 122.764038f, 89.9699478f),new Vector3(2052.261f, 2001.501f, 122.9283f),new Vector3(3004.673f, 1189.202f, 450.2762f),new List<string> { "a_m_y_roadcyc_01","a_m_y_runner_01","a_m_y_runner_02"},new List<Vector3> { new Vector3(2058.256f, 2011.307f, 85.35182f),new Vector3(2052.213f, 2012.029f, 85.22948f),new Vector3(2052.261f, 2007.708f, 87.98557f)},new List<Vector3> { new Vector3(2096.828f, 1645.54f, 95.58078f),new Vector3(2077.784f, 1654.302f, 96.36329f),new Vector3(2069.758f, 1689.132f, 101.4595f),new Vector3(2076.142f, 1714.179f, 102.4184f),new Vector3(2117.638f, 1754.95f, 102.2048f),new Vector3(2170.537f, 1790.896f, 106.6062f),new Vector3(2275.318f, 1861.597f, 109.1357f)}),
            new SnipSnip(new Vector3(1218.552f, -518.9406f, 66.30169f), false, false, false, false, false, false, 1.1f, "kamacho", "",new Vector4(1172.73816f, -640.469971f, 62.1788979f, -169.222076f),new Vector4(1215.61975f, -464.011414f, 77.959259f, 74.2277985f),new Vector3(1205.992f, -468.223f, 77.89313f),new Vector3(989.7267f, -682.0303f, 57.41417f),new List<string> { "csb_sessanta","a_m_y_hipster_01","a_f_y_hipster_01"}, new List<Vector3> { new Vector3(1222.57f, -512.8265f, 65.43675f),new Vector3(1230.575f, -465.3571f, 66.63378f)},new List<Vector3> { new Vector3(1110.886f, -636.3016f, 56.81605f),new Vector3(1112.473f, -633.6349f, 56.81398f),new Vector3(1119.226f, -632.5175f, 56.7912f),new Vector3(1126.365f, -642.436f, 56.74424f),new Vector3(1146.326f, -643.6757f, 56.75817f),new Vector3(1166.79f, -642.3821f, 62.28516f)}),
            new SnipSnip(new Vector3(956.524f, -145.9041f, 74.44567f), false, false, false, false, false, false, 1.5f, "btype2", "",new Vector4(1124.99109f, 46.3673706f, 80.5212097f, 167.18576f),new Vector4(995.745605f, -128.903366f, 85.5739822f, -120.037033f),new Vector3(998.5734f, -127.6664f, 85.50781f),new Vector3(954.7304f, 127.9832f, 80.85289f),new List<string> { "csb_avery","ig_thornton","ig_oneil"},new List<Vector3> { new Vector3(960.0708f, -140.4535f, 73.50088f),new Vector3(991.7795f, -145.3135f, 73.13991f),new Vector3(990.6913f, -128.6535f, 78.78584f),new Vector3(998.5751f, -125.3857f, 81.56245f)},new List<Vector3> { new Vector3(1123.581f, 75.60891f, 80.87496f),new Vector3(1126.437f, 71.40783f, 80.89035f),new Vector3(1121.096f, 62.37495f, 80.89035f),new Vector3(1124.498f, 55.11448f, 80.7554f)}),
            new SnipSnip(new Vector3(1286.203f, -1548.553f, 47.76793f), false, false, false, false, false, false, 1.1f, "cognoscenti", "",new Vector4(1210.94263f, -1410.87646f, 34.7695007f, 138.165878f),new Vector4(1254.52075f, -1570.81372f, 78.0307159f, 88.9085159f),new Vector3(1256.545f, -1569.676f, 77.96454f),new Vector3(805.2334f, -1382.855f, 26.852f),new List<string> { "ig_tonyprince","s_m_m_bouncer_01","s_m_m_bouncer_02"},  new List<Vector3> { new Vector3(1278.408f, -1554.986f, 47.30045f),new Vector3(1263.228f, -1572.007f, 53.55732f)}, new List<Vector3> { new Vector3(1211.441f, -1390.014f, 35.37524f),new Vector3(1215.483f, -1400.077f, 35.22415f)}),
            new SnipSnip(new Vector3(2726.141f, 1403.643f, 24.55361f), false, false, false, false, false, false, 1.4f, "guardian", "",new Vector4(2813.66187f, 1586.15735f, 24.8166599f, -11.5958929f),new Vector4(2755.62476f, 1470.2699f, 48.0948448f, 164.073914f),new Vector3(2761.95f, 1469.319f, 46.95405f),new Vector3(2544.561f, 1673.805f, 28.18913f),new List<string> { "ig_fbisuit_01","s_m_y_construct_01","s_m_y_construct_02"}, new List<Vector3> { new Vector3(2730.568f, 1427.775f, 23.51455f),new Vector3(2745.674f, 1473.261f, 29.80488f),new Vector3(2748.634f, 1470.974f, 39.82914f),new Vector3(2746.969f, 1473.484f, 43.85551f)}, new List<Vector3> { new Vector3(2863.09f, 1575.955f, 24.56751f),new Vector3(2846.485f, 1580.287f, 24.5554f),new Vector3(2828.764f, 1583.966f, 24.55527f),new Vector3(2821.306f, 1586.125f, 24.54044f)})
        };
        private static readonly List<SnipSnip> Sniping05 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(1139.493f, 2215.345f, 49.16407f), false, false, false, false, false, false, 1.1f, "everon", "",new Vector4(1174.81f, 1815.82f, 74.60f, 128.00f),new Vector4(1130.86316f, 2172.23828f, 78.3226013f, 78.8383942f),new Vector3(1121.024f, 2114.965f, 78.26711f), new Vector3(1295.396f, 1140.402f, 105.5388f),  new List<string> { "ig_clay","g_m_y_lost_01","g_m_y_lost_03"}, new List<Vector3> { new Vector3(1131.475f, 2193.84f, 47.81824f),new Vector3(1131.544f, 2177.431f, 48.3606f),new Vector3(1131.584f, 2172.776f, 51.1166f),new Vector3(1130.745f, 2175.282f, 74.79395f)}, new List<Vector3> { new Vector3(1276.342f, 1905.847f, 81.43682f),new Vector3(1262.113f, 1929.091f, 78.89088f),new Vector3(1239.143f, 1907.931f, 78.66519f),new Vector3(1216.177f, 1880.994f, 78.84123f),new Vector3(1188.013f, 1839.237f, 77.86327f)}),
            new SnipSnip(new Vector3(251.0527f, 2851.888f, 43.41971f), false, false, false, false, false, false,1.4f, "stockade", "",new Vector4(192.955704f, 2834.19067f, 43.962616f, -16.827879f),new Vector4(272.365906f, 2866.03906f, 73.2404633f, -108.794327f),new Vector3(264.6086f, 2865.739f, 73.17509f), new Vector3(219.0531f, 3190.328f, 42.56924f), new List<string> { "ig_popov","a_m_m_business_01","a_f_m_business_02"},new List<Vector3> { new Vector3(287.4804f, 2872.251f, 42.64397f),new Vector3(285.8709f, 2871.324f, 55.87041f),new Vector3(271.0566f, 2863.19f, 63.93239f)}, new List<Vector3> { new Vector3(182.4338f, 2794.511f, 45.64664f),new Vector3(187.1486f, 2794.306f, 45.65515f),new Vector3(188.0547f, 2807.043f, 45.51604f),new Vector3(189.016f, 2828.349f, 44.31848f)}),
            new SnipSnip(new Vector3(1579.818f, 3650.729f, 34.30716f), false, false, false, false, false, false, 1.2f, "paradise", "",new Vector4(1720.28796f, 3670.14868f, 34.7670364f, -158.827942f), new Vector4(1590.38525f, 3587.29102f, 41.1778564f, 120.766846f),new Vector3(1607.795f, 3583.198f, 41.11671f),new Vector3(1979.738f, 3730.211f, 32.35971f), new List<string> { "cs_terry","a_m_y_methhead_01","a_f_y_juggalo_01"},new List<Vector3> { new Vector3(1574.462f, 3617.685f, 34.39826f),new Vector3(1583.025f, 3594.613f, 37.73138f),new Vector3(1590.497f, 3582.093f, 40.82693f)}, new List<Vector3> { new Vector3(1711.339f, 3703.322f, 34.38177f),new Vector3(1712.055f, 3697.305f, 34.45498f),new Vector3(1714.793f, 3691.003f, 34.59098f),new Vector3(1717.826f, 3690.543f, 34.58323f),new Vector3(1720.347f, 3684.962f, 34.72052f),new Vector3(1718.131f, 3680.051f, 34.78809f)}),
            new SnipSnip(new Vector3(2020.779f, 5059.232f, 41.85213f), false, false, false, false, false, false,0f, "barracks3", "",new Vector4(1934.96985f, 5151.03711f, 43.7868233f, 101.970245f),new Vector4(1983.66821f, 5031.30273f, 60.6693344f, 123.221458f),new Vector3(1986.758f, 5033.327f, 60.6032f),new Vector3(1663.976f, 4875.834f, 42.05314f),new List<string> { "csb_avischwartzman_02","csb_paige","cs_lestercrest"},new List<Vector3> { new Vector3(1986.656f, 5038.968f, 39.69757f),new Vector3(1984.126f, 5035.815f, 39.913f)},new List<Vector3> { new Vector3(1976.973f, 5169.57f, 47.63911f),new Vector3(1966.561f, 5163.796f, 47.46595f),new Vector3(1939.84f, 5163.94f, 45.37885f),new Vector3(1932.936f, 5155.768f, 44.71569f)}),
            new SnipSnip(new Vector3(2909.745f, 4380.366f, 50.32943f), false, false, false, false, false, false,2f, "rancherxl","", new Vector4(2700.16309f, 4342.7793f, 45.5046501f, -43.7916985f),new Vector4(2894.32617f, 4336.23047f, 91.3731155f, -156.271927f),new Vector3(2888.865f, 4326.857f, 91.31193f),new Vector3(2460.763f, 4200.306f, 37.05989f),new List<string> { "csb_maude","a_c_shepherd","a_c_rottweiler"},new List<Vector3> { new Vector3(2907.176f, 4347.102f, 49.3002f),new Vector3(2882.727f, 4337.748f, 49.40207f),new Vector3(2885.741f, 4330.314f, 49.49098f)},new List<Vector3> { new Vector3(2711.254f, 4317.432f, 46.1567f),new Vector3(2717.727f, 4324.462f, 46.23235f),new Vector3(2717.315f, 4331.519f, 45.86073f),new Vector3(2707.996f, 4339.502f, 45.85198f)})
        };
        private static readonly List<SnipSnip> Sniping06 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(-280.5417f, 6050.088f, 31.5139f), false, false, false, true, false, false, 1.25f, "windsor2", "",new Vector4(-117.31765f, 6297.21777f, 30.8798523f, -137.249298f),new Vector4(-183.567657f, 6147.53906f, 41.9648361f, 134.807388f),new Vector3(-185.0842f, 6157.064f, 41.63742f),new Vector3(-591.868652f, 5653.53027f, 38.7417336f),new List<string> { "s_m_m_strpreach_01","s_m_y_swat_01","s_m_y_swat_01"}, new List<Vector3> { new Vector3(-237.3718f, 6057.516f, 30.96651f),new Vector3(-195.0831f, 6105.734f, 30.52495f),new Vector3(-192.8047f, 6113.26f, 41.41171f),new Vector3(-187.9255f, 6147.583f, 40.81758f)},new List<Vector3> { new Vector3(-124.9853f, 6290.322f, 31.35982f),new Vector3(-121.5634f, 6293.086f, 31.37133f)}),
            new SnipSnip(new Vector3(-401.5733f, 6127.641f, 31.51733f), false, false, false, false, false, false,1.45f, "fbi","", new Vector4(-461.737549f, 6021.31836f, 30.9902153f, -46.3355522f), new Vector4(-379.461365f, 6089.87549f, 43.3163986f, 28.465271f), new Vector3(-381.2637f, 6086.822f, 44.25523f), new Vector3(-586.0463f, 5667.988f, 38.24795f),new List<string> { "s_m_y_prisoner_01","s_m_y_sheriff_01","s_f_y_sheriff_01"},new List<Vector3> { new Vector3(-385.256f, 6109.671f, 30.44448f),new Vector3(-378.7403f, 6082.754f, 30.44684f),new Vector3(-378.0187f, 6084.908f, 42.69547f)},new List<Vector3> { new Vector3(-442.4243f, 6017.624f, 31.69086f),new Vector3(-438.6968f, 6021.306f, 31.49012f),new Vector3(-447.6462f, 6027.051f, 31.49011f),new Vector3(-455.067f, 6027.345f, 31.34055f),new Vector3(-457.7028f, 6022.072f, 31.34055f)}),
            new SnipSnip(new Vector3(-591.3151f, 5285.419f, 70.21516f), true, false, false, false, false, false, 4.4f, "sandking", "SCORCHER", new Vector4(-710.635681f, 5441.39844f, 44.6952705f, 96.2023315f), new Vector4(-553.473999f, 5291.3335f, 97.7395706f, 69.0066986f), new Vector3(-552.6372f, 5293.642f, 97.67506f), new Vector3(-975.8145f, 5404.442f, 39.94248f), new List<string> { "s_m_y_clown_01","u_m_y_zombie_01","u_m_y_pogo_01"}, new List<Vector3> { new Vector3(-534.4946f, 5269.197f, 73.17419f),new Vector3(-533.8962f, 5298.166f, 75.227f),new Vector3(-541.0539f, 5298.083f, 83.6f),new Vector3(-547.3981f, 5293.046f, 89.72654f)},new List<Vector3> { new Vector3(-690.1994f, 5262.041f, 76.52261f),new Vector3(-709.4228f, 5296.362f, 72.4118f),new Vector3(-695.436f, 5424.28f, 46.68988f)}),
            new SnipSnip(new Vector3(752.4249f, 6492.026f, 26.01547f), false, false, true, false, false, false, 1.8f, "longfin", "", new Vector4(688.861084f, 6692.92725f, 1.09297454f, -16.5960846f), new Vector4(755.927185f, 6466.67285f, 40.9411774f, 116.034897f), new Vector3(754.6096f, 6465.792f, 41.78326f), new Vector3(289.2018f, 7217.558f, -0.03686932f), new List<string> { "ig_devin","s_m_y_devinsec_01","s_m_y_devinsec_01"}, new List<Vector3> { new Vector3(752.0635f, 6480.111f, 27.67778f),new Vector3(757.7256f, 6465.869f, 30.21312f)}, new List<Vector3> { new Vector3(847.7941f, 6616.341f, 3.074279f),new Vector3(771.941f, 6618.07f, 1.997069f),new Vector3(709.3475f, 6635.099f, 4.316185f),new Vector3(679.0583f, 6684.412f, 2.119486f)}),
            new SnipSnip(new Vector3(-1057.275f, 4778.892f, 235.5499f), false, false, false, false, false, false,1.4f, "dubsta3","", new Vector4(-1157.10425f, 4854.16846f, 196.145416f, 86.18396f), new Vector4(-1005.03363f, 4845.73877f, 274.072845f, -85.1566391f), new Vector3(-1005.888f, 4841.278f, 274.0065f), new Vector3(-1509.863f, 4755.023f, 54.27087f),new List<string> { "cs_zimbor","csb_talcc","csb_talmm"},new List<Vector3> { new Vector3(-1038.695f, 4804.019f, 243.1185f),new Vector3(-1007.744f, 4837.717f, 268.55f),new Vector3(-1007.267f, 4842.289f, 271.3093f)},new List<Vector3> { new Vector3(-1126.69f, 4684.916f, 240.8452f),new Vector3(-1121.741f, 4738.288f, 235.8103f),new Vector3(-1123.031f, 4759.953f, 231.8705f),new Vector3(-1142.29f, 4813.015f, 214.95f),new Vector3(-1153.773f, 4844.478f, 199.1262f)})
        };
        private static readonly List<SnipSnip> Sniping07 = new List<SnipSnip>
        {
            new SnipSnip(new Vector3(4918.125f, -5352.302f, 10.25851f), false, false, false, false, false, false,1.5f, "vetir","", new Vector4(4940.49707f, -5200.64307f, 2.82069993f, -38.7803383f), new Vector4(4900.40186f, -5333.35107f, 34.7176895f, 39.164711f), new Vector3(4903.938f, -5332.561f, 34.6557f), new Vector3(5070.843f, -5260.296f, 5.402645f), new List<string> { "csb_isldj_00","g_m_m_cartelguards_01","g_m_m_cartelguards_01"},new List<Vector3> { new Vector3(4903.286f, -5341.033f, 9.18216f),new Vector3(4902.494f, -5343.015f, 19.4439f),new Vector3(4908.335f, -5336.941f, 28.1633f)},new List<Vector3> { new Vector3(4867.661f, -5166.859f, 2.438293f),new Vector3(4885.591f, -5182.025f, 2.438295f),new Vector3(4904.395f, -5194.634f, 2.438326f),new Vector3(4920.445f, -5213.067f, 2.513234f),new Vector3(4934.836f, -5208.531f, 2.544519f)}),
            new SnipSnip(new Vector3(4860.064f, -4491.113f, 9.860084f), false, false, false, false, false, false, 1.1f, "bodhi2","", new Vector4(4977.5625f, -4509.96094f, 8.73896217f, -123.265099f), new Vector4(4878.88037f, -4488.47754f, 25.9999695f, -89.6665192f), new Vector3(4880.474f, -4487.749f, 25.93383f), new Vector3(4999.181f, -4739.738f, 12.36393f),new List<string> { "csb_isldj_01","g_m_m_cartelguards_01","g_m_m_cartelguards_01"},new List<Vector3> { new Vector3(4875.329f, -4485.992f, 9.15356f),new Vector3(4880.081f, -4491.225f, 25.93383f)},new List<Vector3> { new Vector3(4964.611f, -4467.542f, 10.42239f),new Vector3(4971.77f, -4473.264f, 10.29147f),new Vector3(4975.188f, -4492.094f, 8.866542f),new Vector3(4976.655f, -4503.561f, 8.631977f)}),
            new SnipSnip(new Vector3(5275.811f, -5413.291f, 65.88566f), false, true, false, false, false, false,1.25f, "volatus","", new Vector4(5316.06396f, -5603.83496f, 65.7698059f, 111.732819f), new Vector4(5264.06055f, -5430.91504f, 89.7899475f, 144.643845f), new Vector3(5266.802f, -5431.747f, 89.72378f), new Vector3(5222.755f, -5827.017f, 164.9853f),new List<string> { "csb_isldj_02","g_m_m_cartelguards_01","g_m_m_cartelguards_01"}, new List<Vector3> { new Vector3(5271.762f, -5419.913f, 64.35625f),new Vector3(5265.645f, -5428.576f, 64.59984f)}, new List<Vector3> { new Vector3(5361.962f, -5554.056f, 52.52334f),new Vector3(5348.918f, -5547.39f, 54.32009f),new Vector3(5331.679f, -5543.681f, 55.27231f),new Vector3(5329.854f, -5554.987f, 58.61013f),new Vector3(5332.241f, -5575.511f, 61.99478f),new Vector3(5329.498f, -5589.746f, 64.25397f),new Vector3(5317.347f, -5598.604f, 65.05556f)}),
            new SnipSnip(new Vector3(5107.821f, -4564.00f, 4.231351f), false, false, true, false, false, false,1.4f, "dinghy","", new Vector4(5180.96484f, -4711.17236f, 0.193044782f, 136.78772f), new Vector4(5109.26025f, -4577.84277f, 29.5732708f, -36.3758011f), new Vector3(5106.926f, -4584.247f, 28.71778f), new Vector3(5545.144f, -5014.906f, 1.115574f),new List<string> { "csb_isldj_03","g_m_m_cartelguards_01","g_m_m_cartelguards_01"},new List<Vector3> { new Vector3(5110.189f, -4576.865f, 3.335268f),new Vector3(5112.181f, -4576.061f, 13.61059f),new Vector3(5103.792f, -4576.261f, 22.25639f)}, new List<Vector3> { new Vector3(5172.577f, -4643.942f, 2.535479f),new Vector3(5168.136f, -4659.119f, 2.52634f),new Vector3(5164.112f, -4682.983f, 2.338086f),new Vector3(5171.738f, -4707.279f, 2.19738f)}),
            new SnipSnip(new Vector3(5457.434f, -5229.966f, 27.20314f), false, false, false, false, false, false,1.2f, "mesa3","", new Vector4(5585.05322f, -5234.51318f, 14.9564409f, 106.253922f), new Vector4(5466.65381f, -5235.9502f, 43.0279236f, -80.2742386f), new Vector3(5468.799f, -5238.444f, 42.96178f), new Vector3(5335.834f, -5104.276f, 14.7518f), new List<string> { "csb_isldj_04","g_m_m_cartelguards_01","g_m_m_cartelguards_01"},new List<Vector3>{ new Vector3(5468.522f, -5237.397f, 26.18455f),new Vector3(5468.01f, -5233.212f, 29.15038f)},new List<Vector3> { new Vector3(5562.802f, -5188.538f, 11.63965f),new Vector3(5567.947f, -5192.957f, 11.92781f),new Vector3(5580.083f, -5196.754f, 12.71497f),new Vector3(5592.856f, -5206.394f, 14.21555f),new Vector3(5596.56f, -5219.373f, 14.23425f),new Vector3(5590.942f, -5231.093f, 14.77761f)})
        };
        public static List<SnipSnip> Sniping08 = new List<SnipSnip>();
        public static List<SnipSnip> Sniping09 = new List<SnipSnip>();

        public static readonly List<Vector3> YachMobs = new List<Vector3>
        {
            new Vector3(-2089.241f, -1017.131f, 12.77942f),
            new Vector3(-2084.963f, -1018.17f, 12.7819f),
            new Vector3(-2075.85f, -1023.987f, 11.90897f),
            new Vector3(-2057.141f, -1023.712f, 11.90752f),
            new Vector3(-2059.652f, -1029.798f, 11.90751f),
            new Vector3(-2038.46f, -1033.382f, 8.971486f),
            new Vector3(-2079.459f, -1026.553f, 8.971498f),
            new Vector3(-2050.709f, -1027.698f, 8.971485f),
            new Vector3(-2095.92f, -1014.094f, 8.980425f),
            new Vector3(-2088.441f, -1016.918f, 8.971198f),
            new Vector3(-2121.264f, -1007.252f, 7.992996f),
            new Vector3(-2101.255f, -1014.084f, 5.884184f),
            new Vector3(-2090.708f, -1016.646f, 5.88879f),
            new Vector3(-2075.17f, -1019.912f, 5.884132f),
            new Vector3(-2033.05f, -1039.868f, 5.882174f),
            new Vector3(-2029.334f, -1042.119f, 2.566328f),
            new Vector3(-2052.608f, -1035.781f, 2.563384f),
            new Vector3(-2053.243f, -1022.338f, 3.010738f),
            new Vector3(-2065.84f, -1027.916f, 3.061461f),
            new Vector3(-2069.564f, -1019.077f, 3.067517f),
        };
        private static readonly List<PhishingSpot> PhisherMen = new List<PhishingSpot>
        {
            new PhishingSpot(new Vector3(-2267.098f, 2718.057f, -0.1050927f),new Vector4(-2271.455f, 2710.373f, 1.795847f, 317.2858f)),
            new PhishingSpot(new Vector3(-2276.375f, 2800.253f, -0.02853893f),new Vector4(-2262.034f, 2797.965f, 1.158177f, 143.218f)),
            new PhishingSpot(new Vector3(-2452.397f, 2758.311f, -0.1024196f),new Vector4(-2443.822f, 2773.958f, 1.107026f, 162.8035f)),
            new PhishingSpot(new Vector3(-2520.441f, 2781.299f, 0.01976691f),new Vector4(-2534.851f, 2785.696f, 1.705645f, 3.788758f)),
            new PhishingSpot(new Vector3(-2692.24f, 2803.303f, 0.09795412f),new Vector4(-2686.559f, 2776.299f, 1.092641f, 16.96323f)),
            new PhishingSpot(new Vector3(-2675.768f, 2549.733f, 0.09234437f),new Vector4(-2679.578f, 2560.405f, 3.279952f, 62.12259f)),
            new PhishingSpot(new Vector3(-2512.779f, 2457.329f, -0.1280194f),new Vector4(-2502.054f, 2456.114f, 1.351156f, 84.93685f)),
            new PhishingSpot(new Vector3(-2405.962f, 2498.461f, -0.1005725f),new Vector4(-2423.841f, 2488.548f, 1.536321f, 282.6599f)),
            new PhishingSpot(new Vector3(-2350.739f, 2531.461f, 0.1267544f),new Vector4(-2335.076f, 2540.096f, 1.103614f, 70.49986f)),
            new PhishingSpot(new Vector3(-2192.352f, 2542.014f, 0.1361143f),new Vector4(-2187.082f, 2533.962f, 1.61509f, 344.4031f)),
            new PhishingSpot(new Vector3(-2122.215f, 2487.729f, 0.1340764f),new Vector4(-2135.926f, 2507.35f, 1.477846f, 174.1375f)),
            new PhishingSpot(new Vector3(-2058.875f, 2488.626f, 0.1319462f),new Vector4(-2077.144f, 2481.595f, 1.757198f, 261.1181f)),
            new PhishingSpot(new Vector3(-1972.177f, 2535.516f, -0.03703161f),new Vector4(-1959.703f, 2541.121f, 1.714661f, 75.94833f)),
            new PhishingSpot(new Vector3(-1862.23f, 2559.718f, 0.08299349f),new Vector4(-1855.056f, 2563.261f, 1.079439f, 63.00495f)),
            new PhishingSpot(new Vector3(-1741.274f, 2562.792f, -0.05941249f),new Vector4(-1746.728f, 2576.327f, 1.261585f, 273.4592f)),
            new PhishingSpot(new Vector3(-1615.856f, 2555.23f, 0.007432766f),new Vector4(-1630.159f, 2546.065f, 1.604008f, 302.6676f)),
            new PhishingSpot(new Vector3(-1452.784f, 2256.166f, 16.83186f),new Vector4(-1462.37f, 2249.08f, 22.67013f, 287.7927f)),
            new PhishingSpot(new Vector3(-1435.809f, 2133.348f, 29.95456f),new Vector4(-1424.021f, 2124.391f, 43.95115f, 62.98845f)),
            new PhishingSpot(new Vector3(-1447.689f, 2105.221f, 41.10828f),new Vector4(-1449.981f, 2121.201f, 43.7417f, 306.0093f)),
            new PhishingSpot(new Vector3(-1453.399f, 2061.905f, 53.68446f),new Vector4(-1446.47f, 2074.82f, 55.03326f, 97.05612f)),
            new PhishingSpot(new Vector3(-1439.854f, 2001.397f, 56.65691f),new Vector4(-1434.415f, 2021.363f, 58.56808f, 136.722f)),
            new PhishingSpot(new Vector3(-1476.355f, 1826.803f, 77.81793f),new Vector4(-1487.785f, 1819.803f, 81.04632f, 284.4136f)),
            new PhishingSpot(new Vector3(-1538.943f, 1693.724f, 92.91889f),new Vector4(-1549.853f, 1695.853f, 102.0555f, 232.9542f))
        };
        public static readonly List<Vector3> DropRubbish = new List<Vector3>
        {
            new Vector3(644.6057f, -1453.172f, 8.380302f),
            new Vector3(617.7773f, -1362.886f, 8.36958f),
            new Vector3(598.3756f, -1306.039f, 8.368834f),
            new Vector3(593.0373f, -1246.08f, 8.466216f),
            new Vector3(593.0325f, -1177.757f, 8.655041f),
            new Vector3(593.1477f, -1102.322f, 8.863312f),
            new Vector3(591.6036f, -1011.895f, 9.112757f),
            new Vector3(591.8387f, -907.4847f, 9.397379f),
            new Vector3(597.3967f, -854.2623f, 9.520418f),
            new Vector3(585.8411f, -850.317f, 9.540106f),
            new Vector3(593.5573f, -795.2447f, 9.708557f),
            new Vector3(594.1461f, -696.8318f, 11.49453f),
            new Vector3(609.5754f, -615.5567f, 13.03183f),
            new Vector3(650.6841f, -525.8651f, 13.7698f),
            new Vector3(740.8145f, -445.4544f, 16.7115f),
            new Vector3(815.7368f, -420.1507f, 24.94323f),
            new Vector3(853.3591f, -413.1623f, 28.1094f),
            new Vector3(890.9553f, -406.0472f, 31.22633f),
            new Vector3(926.817f, -398.8194f, 40.30638f),
            new Vector3(977.196f, -377.061f, 44.12959f),
            new Vector3(1019.552f, -331.3167f, 47.8512f),
            new Vector3(1048.574f, -286.2695f, 49.32551f),
            new Vector3(1141.052f, -148.9637f, 53.11688f),
            new Vector3(1153.834f, -131.8845f, 53.92586f),
            new Vector3(1182.161f, -115.118f, 55.40979f),
            new Vector3(1193.617f, -107.5604f, 55.85151f),
            new Vector3(1228.677f, -83.05925f, 58.0977f),
            new Vector3(1220.656f, -91.59956f, 57.3595f),
            new Vector3(1240.186f, -84.26402f, 58.30257f),
            new Vector3(1267.35f, -60.69587f, 59.6433f),
            new Vector3(1299.277f, -50.74736f, 62.17868f),
            new Vector3(1326.597f, -55.19455f, 66.49007f),
            new Vector3(1350.118f, -60.14297f, 70.46875f),
            new Vector3(1367.034f, -67.37091f, 74.93937f),
            new Vector3(1383.645f, -78.74095f, 80.77425f),
            new Vector3(1403.523f, -79.4838f, 86.1574f),
            new Vector3(1429.455f, -73.40284f, 91.33286f),
            new Vector3(1447.304f, -69.76672f, 93.72147f),
            new Vector3(1463.348f, -66.92113f, 97.12095f),
            new Vector3(1478.598f, -61.89777f, 101.4568f),
            new Vector3(1498.115f, -55.76527f, 106.721f),
            new Vector3(1520.315f, -43.57081f, 113.1369f),
            new Vector3(1537.892f, -45.18201f, 116.3369f),
            new Vector3(1555.162f, -41.50235f, 118.0891f),
            new Vector3(1580.393f, -34.48945f, 119.9327f),
            new Vector3(1596.361f, -28.97597f, 120.3855f),
            new Vector3(1614.301f, -27.9798f, 122.7313f),
            new Vector3(1628.417f, -30.19465f, 125.4519f),
            new Vector3(1642.442f, -32.26805f, 129.3114f),
            new Vector3(1655.088f, -19.52f, 133.676f)
        };
        public static readonly List<FubarVectors> BoatDelivery = new List<FubarVectors>
        {
            new FubarVectors(99, new Vector4(-843.493f, -1373.867f, 0.3533937f,288.6792f), new Vector4(-842.7202f, -1377.228f, 1.605168f,21.47575f), "", -1),
            new FubarVectors(99, new Vector4(-740.1697f, -1348.676f, 0.360813f,49.99689f), new Vector4(-737.5366f, -1346.35f, 1.595213f,136.5939f), "", -1),
            new FubarVectors(99, new Vector4(-732.9948f, -1379.052f, 0.355773f,138.1843f), new Vector4(-730.1036f, -1380.889f, 1.595219f,64.23289f), "", -1),
            new FubarVectors(99, new Vector4(-853.7703f, -1482.82f, 0.3543462f,288.1324f), new Vector4(-855.4145f, -1479.39f, 1.597912f,199.9915f), "", -1),
            new FubarVectors(99, new Vector4(-929.0731f, -1477.039f, 0.3477725f,200.4785f), new Vector4(-932.2585f, -1478.337f, 1.595391f,302.6615f), "", -1),
            new FubarVectors(99, new Vector4(-884.0178f, -1403.694f, 0.3641943f,290.1258f), new Vector4(-886.3292f, -1401.417f, 1.595391f,214.4681f), "", -1),
            new FubarVectors(99, new Vector4(-909.7039f, -1340.695f, 0.3928411f,114.9627f), new Vector4(-911.5654f, -1337.836f, 1.605166f,193.4325f), "", -1),
            new FubarVectors(99, new Vector4(-984.3565f, -1392.11f, 0.3352712f,200.4964f), new Vector4(-987.726f, -1393.757f, 1.595825f,289.9972f), "", -1),
            new FubarVectors(99, new Vector4(-933.917f, -1043.93f, -0.1470577f,210.4188f), new Vector4(-936.9321f, -1045.009f, 2.174368f,299.9776f), "", -1),
            new FubarVectors(99, new Vector4(-987.4423f, -951.5204f, -0.1263748f,209.6242f), new Vector4(-991.5593f, -952.9044f, 2.173635f,289.8998f), "", -1),
            new FubarVectors(99, new Vector4(-1055.757f, -967.7828f, -0.04778841f,299.5307f), new Vector4(-1054.793f, -971.9059f, 2.002102f,30.83708f), "", -1),
            new FubarVectors(99, new Vector4(-1004.518f, -1048.986f, -0.1252588f,123.3457f), new Vector4(-1004.918f, -1045.162f, 2.172446f,183.231f), "", -1),
            new FubarVectors(99, new Vector4(-1183.441f, -1019.096f, 0.087623f,29.84887f), new Vector4(-1187.074f, -1021.556f, 2.172045f,301.5792f), "", -1),
            new FubarVectors(99, new Vector4(-1103.585f, -1153.446f, -0.1111357f,212.6153f), new Vector4(-1101.269f, -1151.151f, 2.173172f,111.2132f), "", -1),
            new FubarVectors(99, new Vector4(-1010.237f, -1176.997f, -0.1388426f,119.2049f), new Vector4(-1011.743f, -1173.777f, 2.004155f,222.6845f), "", -1),
            new FubarVectors(99, new Vector4(-293.3935f, -2764.677f, 1.545074f,87.3997f), new Vector4(-306.0619f, -2763.796f, 4.994703f,252.3047f), "", -1),
            new FubarVectors(99, new Vector4(6.383169f, -2784.944f, 0.0955494f,0.07429508f), new Vector4(11.95894f, -2785.927f, 2.525951f,83.35914f), "", -1),
            new FubarVectors(99, new Vector4(-1591.636f, 5235.481f, 0.3243574f,204.2904f), new Vector4(-1596.137f, 5232.758f, 3.974099f,303.4466f), "", -1),
            new FubarVectors(99, new Vector4(3371.554f, 5186.638f, 0.3510039f,266.1928f), new Vector4(3369.385f, 5184.061f, 1.460242f,295.9111f), "", -1),
            new FubarVectors(99, new Vector4(3856.522f, 4468.477f, 0.3677569f,268.9125f), new Vector4(3855.394f, 4463.701f, 2.716226f,340.3032f), "", -1),
            new FubarVectors(99, new Vector4(707.9339f, 4113.358f, 30.28556f,177.9153f), new Vector4(712.3061f, 4109.932f, 31.30326f,90f), "", -1)
        };
        public static readonly List<Vector4> SubStandard = new List<Vector4>
        {
            new Vector4(514.5162f, 4817.99f, -68.99113f,358.4791f),
            new Vector4(515.1494f, 4833.569f, -68.99053f,147.967f),
            new Vector4(514.2175f, 4845.671f, -66.18684f,171.5724f),
            new Vector4(511.546f, 4839.045f, -66.18919f,277.5858f),
            new Vector4(514.0159f, 4826.606f, -62.58789f,281.0165f),
            new Vector4(516.7152f, 4835.981f, -62.58571f,285.4374f),
            new Vector4(512.8048f, 4834.631f, -62.58789f,39.10049f),
            new Vector4(512.0849f, 4847.815f, -62.58978f,315.7887f),
            new Vector4(514.315f, 4855.767f, -62.5621f,331.6915f),
            new Vector4(514.342f, 4862.028f, -62.5621f,81.839f),
            new Vector4(514.2056f, 4867.008f, -62.5621f,345.2088f),
            new Vector4(516.3999f, 4877.61f, -62.58648f,247.0659f),
            new Vector4(517.0668f, 4888.617f, -66.19463f,315.7018f),
            new Vector4(511.3239f, 4898.304f, -66.14313f,212.5531f),
            new Vector4(516.1567f, 4895.687f, -66.14314f,210.9975f),
            new Vector4(515.4485f, 4886.842f, -68.98938f,64.17663f),
            new Vector4(515.063f, 4874.99f, -68.99102f,134.8187f),
            new Vector4(514.2709f, 4868.423f, -68.99116f,169.0464f),
            new Vector4(514.1342f, 4857.547f, -68.99112f,179.0815f)
        };
        public static readonly List<FubarVectors> ClubHouses = new List<FubarVectors>
        {
            new FubarVectors(1, new Vector4(256.575f,-1799.826f,26.608f, 48.838f), new Vector4(252.927f, -1808.293f, 27.118f, 0f), "Rancho Clubhouse", 97),
            new FubarVectors(2, new Vector4(-1468.252f,-927.374f,9.604f, -40.306f), new Vector4(-1471.827f, -920.3f, 10.022f, -127.541f), "Dell Perro Beach Cluhouse", 97),
            new FubarVectors(2, new Vector4(55.47f,-1047.679f,28.955f, 158.39f), new Vector4(51.805f, -1043.854f, 29.533f, 164.013f), "Pillbox Hill Clubhouse", 97),
            new FubarVectors(3, new Vector4(54.9f,2783.834f,57.372f, 142.971f), new Vector4(59.088f, 2795.078f, 57.882f, -44.416f), "Great Chaparral Clubhouse", 97),
            new FubarVectors(5, new Vector4(1725.715f,3708.118f,33.704f, 20.017f), new Vector4(1737.778f, 3709.339f, 34.14f, 14.203f), "Sandy Shores Clubhouse", 97),
            new FubarVectors(6, new Vector4(-355.844f,6067.92f,30.991f, 44.613f), new Vector4(-358.498f, 6061.767f, 31.503f, 45.702f), "Paleto Bay Clubhouse", 97),
            new FubarVectors(4, new Vector4(943.508f,-1456.301f,30.806f, 1.171f), new Vector4(939.629f, -1458.516f, 31.358f, -0.858f), "La Mesa Clubhouse", 98),
            new FubarVectors(2, new Vector4(-26.914f,-192.657f,51.852f, 158.746f), new Vector4(-22.198f, -192.294f, 52.368f, 159.527f), "Hawick Clubhouse", 98),
            new FubarVectors(2, new Vector4(178.187f,306.282f,104.868f, -174.345f), new Vector4(189.881f, 309.086f, 105.395f, -176.968f), "Downtown Clubhouse", 98),
            new FubarVectors(2, new Vector4(-1145.934f,-1579.522f,3.87f, -146.259f), new Vector4(-1156.163f, -1574.619f, 8.34f, -146.803f), "Vespucci Beach Clubhouse", 98),
            new FubarVectors(5, new Vector4(2465.661f,4101.763f,37.56f, 66.018f), new Vector4(2471.683f, 4110.831f, 38.068f, 66.964f), "Grapeseed Clubhouse", 98),
            new FubarVectors(6, new Vector4(-33.614f,6422.542f,30.936f, -133.651f), new Vector4(-38.862f, 6420.109f, 31.495f, -137.457f), "Paleto Bay Clubhouse", 98)
        };

        public static List<LoanSharks> Sharky01 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky02 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky03 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky04 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky05 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky06 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky07 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky08 = new List<LoanSharks>();
        public static List<LoanSharks> Sharky09 = new List<LoanSharks>();

        public static readonly List<PropLists> CarBallProps = new List<PropLists>
        {
            new PropLists("xs_prop_arena_goal", new Vector3(-2108.10742f, 1098.08179f, 23.2970879f), new Vector3(0.00f, 0.00f, 90.3965073f)),
            new PropLists("xs_prop_arena_goal", new Vector3(-1863.65381f, 1099.26257f, 23.2574173f), new Vector3(0.00f, 0.00f, -90.3504639f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1866.50854f, 1071.6676f, 24.6705627f), new Vector3(0.00f, 0.00f, -90.5841675f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1880.58362f, 1036.46375f, 24.6705627f), new Vector3(0.00f, 0.00f, 179.409409f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1910.40039f, 1036.78064f, 24.6705627f), new Vector3(0.00f, 0.00f, -179.803619f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1941.83679f, 1036.98657f, 24.6705627f), new Vector3(0.00f, 0.00f, 179.940811f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1970.30664f, 1036.93835f, 24.6705627f), new Vector3(0.00f, 0.00f, 178.417297f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2001.75317f, 1036.45374f, 24.6705627f), new Vector3(0.00f, 0.00f, -179.856827f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2031.73193f, 1036.14661f, 24.6705208f), new Vector3(0.00f, 0.00f, 179.972244f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2061.04321f, 1035.94739f, 24.6705227f), new Vector3(0.00f, 0.00f, 179.118088f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2090.04956f, 1036.71191f, 24.6705208f), new Vector3(0.00f, 0.00f, 176.885681f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2105.36353f, 1047.81274f, 24.6705227f), new Vector3(0.00f, 0.00f, 89.9494095f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2106.07861f, 1071.63562f, 24.6906185f), new Vector3(0.00f, 0.00f, 89.9494095f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2106.4646f, 1126.07898f, 24.6704292f), new Vector3(0.00f, 0.00f, 86.8784409f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2106.03467f, 1148.0896f, 24.6704807f), new Vector3(0.00f, 0.00f, 87.1735458f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2090.90259f, 1161.09912f, 24.6705208f), new Vector3(0.00f, 0.00f, -1.38346684f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2060.55469f, 1161.34534f, 24.6705227f), new Vector3(0.00f, 0.00f, -0.628873169f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-2031.10046f, 1160.58984f, 24.6906185f), new Vector3(0.00f, 0.00f, -1.32440674f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1999.65234f, 1160.7179f, 24.6705627f), new Vector3(0.00f, 0.00f, -0.799470484f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1970.14722f, 1161.15833f, 24.6705627f), new Vector3(0.00f, 0.00f, -0.806029916f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1939.99878f, 1160.7334f, 24.6705627f), new Vector3(0.00f, 0.00f, -0.806029916f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1910.7478f, 1160.60864f, 24.6705627f), new Vector3(0.00f, 0.00f, 0.0863575488f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1880.94727f, 1161.03284f, 24.6705627f), new Vector3(0.00f, 0.00f, -1.14067221f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1866.349f, 1148.34021f, 24.6705627f), new Vector3(0.00f, 0.00f, -90.4448242f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1864.22278f, 1125.81921f, 24.6705627f), new Vector3(0.00f, 0.00f, -87.3606796f)),
            new PropLists("xs_prop_barrier_15m_01a", new Vector3(-1866.01367f, 1048.5166f, 24.6705627f), new Vector3(0.00f, 0.00f, -90.1225281f))
        };

        public static readonly List<PropLists> BarLitter = new List<PropLists>
        {
            new PropLists("ba_prop_battle_shot_glass_01", new Vector3(-1583.98523f, -3016.71533f, -75.9491653f),new Vector3(0.00f, 0.00f, -96.8662872f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1584.73206f, -3016.52368f, -75.949173f),new Vector3(0.00f, 0.00f, 143.048599f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1585.51367f, -3016.00903f, -75.9491653f),new Vector3(0.00f, 0.00f, 80.6335602f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1586.00891f, -3015.32324f, -75.9491653f),new Vector3(0.00f, 0.00f, 115.921707f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1585.7926f, -3013.59131f, -75.9491653f),new Vector3(0.00f, 0.00f, 18.9727402f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1586.13403f, -3012.81494f, -75.9491653f),new Vector3(0.00f, 0.00f, -54.0848656f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1585.92407f, -3011.28809f, -75.9491653f),new Vector3(0.00f, 0.00f, -129.28804f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1584.31152f, -3008.51416f, -75.9491653f),new Vector3(0.00f, 0.00f, -63.0016937f)),
            new PropLists("ba_prop_battle_shot_glass_01",new Vector3(-1585.77734f, -3009.64771f, -75.9491653f),new Vector3(0.00f, 0.00f, -152.712479f)),
            new PropLists("p_cs_shot_glass_2_s",new Vector3(-1585.53406f, -3009.63794f, -75.9491653f),new Vector3(0.00f, 0.00f, -143.138611f)),
            new PropLists("p_cs_shot_glass_2_s",new Vector3(-1584.78101f, -3008.72656f, -75.9491653f),new Vector3(0.00f, 0.00f, -138.262466f)),
            new PropLists("p_cs_shot_glass_2_s",new Vector3(-1585.88477f, -3011.08862f, -75.9491653f),new Vector3(0.00f, 0.00f, -130.736099f)),
            new PropLists("p_cs_shot_glass_2_s",new Vector3(-1586.01172f, -3014.18848f, -75.9491653f),new Vector3(0.00f, 0.00f, -178.557083f)),
            new PropLists("p_cs_shot_glass_s",new Vector3(-1586.02783f, -3013.85864f, -75.9491653f),new Vector3(0.00f, 0.00f, -178.97699f)),
            new PropLists("p_cs_shot_glass_s",new Vector3(-1585.33191f, -3015.98145f, -75.9491653f),new Vector3(0.00f, 0.00f, -158.262344f)),
            new PropLists("p_cs_shot_glass_s",new Vector3(-1585.60925f, -3009.83398f, -75.9491653f),new Vector3(0.00f, 0.00f, 53.6794548f)),
            new PropLists("p_cs_shot_glass_s",new Vector3(-1584.46558f, -3008.698f, -75.9491653f),new Vector3(0.00f, 0.00f, -10.3691416f)),
            new PropLists("p_wine_glass_s",new Vector3(-1584.33728f, -3008.82666f, -75.960083f),new Vector3(0.00f, 0.00f, -15.4872341f)),
            new PropLists("p_wine_glass_s",new Vector3(-1586.03381f, -3014.99707f, -75.960083f),new Vector3(0.00f, 0.00f, 52.7138176f)),
            new PropLists("prop_brandy_glass",new Vector3(-1585.78015f, -3015.50879f, -75.9600372f),new Vector3(0.00f, 0.00f, 113.467758f)),
            new PropLists("prop_brandy_glass",new Vector3(-1586.03796f, -3011.69312f, -75.9600372f),new Vector3(0.00f, 0.00f, 19.6289654f)),
            new PropLists("prop_brandy_glass",new Vector3(-1585.83862f, -3010.07568f, -75.9600372f),new Vector3(0.00f, 0.00f, -56.6631279f)),
            new PropLists("prop_cocktail_glass",new Vector3(-1585.79993f, -3012.87744f, -75.9600754f),new Vector3(0.00f, 0.00f, -163.696259f)),
            new PropLists("prop_cocktail_glass",new Vector3(-1586.12781f, -3009.74097f, -75.9600754f),new Vector3(0.00f, 0.00f, 68.2392654f)),
            new PropLists("prop_cocktail_glass",new Vector3(-1585.12024f, -3008.98804f, -75.9600754f),new Vector3(0.00f, 0.00f, 42.3008461f)),
            new PropLists("prop_cocktail_glass",new Vector3(-1584.97632f, -3016.07983f, -75.960083f),new Vector3(0.00f, 0.00f, 177.509796f)),
            new PropLists("prop_pint_glass_01",new Vector3(-1584.60779f, -3016.71997f, -75.9800568f),new Vector3(0.00f, 0.00f, 179.962463f)),
            new PropLists("prop_pint_glass_01",new Vector3(-1585.49084f, -3015.51416f, -75.9800491f),new Vector3(0.00f, 0.00f, 93.1313705f)),
            new PropLists("prop_pint_glass_02",new Vector3(-1586.09888f, -3011.41138f, -75.9801025f),new Vector3(0.00f, 0.00f, -99.5128555f)),
            new PropLists("prop_pint_glass_02",new Vector3(-1586.17786f, -3010.44067f, -75.9801025f),new Vector3(0.00f, 0.00f, -141.920822f)),
            new PropLists("prop_pint_glass_02",new Vector3(-1584.10864f, -3008.30176f, -75.9801025f),new Vector3(0.00f, 0.00f, -37.7863274f)),
            new PropLists("prop_pint_glass_tall",new Vector3(-1584.53113f, -3009.14795f, -75.9800262f),new Vector3(0.00f, 0.00f, -44.2298164f)),
            new PropLists("prop_pint_glass_tall",new Vector3(-1585.62329f, -3010.75f, -75.9800262f),new Vector3(0.00f, 0.00f, -171.978546f)),
            new PropLists("prop_pint_glass_tall",new Vector3(-1585.61572f, -3010.35132f, -75.9800262f),new Vector3(0.00f, 0.00f, -163.940384f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1586.23511f, -3010.96875f, -75.960083f),new Vector3(0.00f, 0.00f, -133.887009f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1585.30762f, -3009.11621f, -75.960083f),new Vector3(0.00f, 0.00f, -64.6151123f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1586.1123f, -3010.17896f, -75.960083f),new Vector3(0.00f, 0.00f, -116.891701f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1585.93164f, -3014.8501f, -75.960083f),new Vector3(0.00f, 0.00f, 176.414932f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1584.63062f, -3016.27515f, -75.9600906f),new Vector3(0.00f, 0.00f, 157.812119f)),
            new PropLists("prop_sh_wine_glass",new Vector3(-1584.18311f, -3017.10693f, -75.960083f),new Vector3(0.00f, 0.00f, -155.357132f)),
            new PropLists("prop_shot_glass",new Vector3(-1585.62952f, -3015.3103f, -75.9600372f),new Vector3(0.00f, 0.00f, 87.3853302f)),
            new PropLists("prop_shot_glass",new Vector3(-1584.84473f, -3016.30103f, -75.970047f),new Vector3(0.00f, 0.00f, -171.184128f)),
            new PropLists("prop_shot_glass",new Vector3(-1585.91162f, -3013.75562f, -75.9600372f),new Vector3(0.00f, 0.00f, 40.8036957f)),
            new PropLists("prop_shot_glass",new Vector3(-1586.12085f, -3013.17188f, -75.9600372f),new Vector3(0.00f, 0.00f, 34.8063011f)),
            new PropLists("prop_shot_glass",new Vector3(-1586.24683f, -3011.72363f, -75.9600372f),new Vector3(0.00f, 0.00f, 22.7787266f)),
            new PropLists("prop_shot_glass",new Vector3(-1585.7738f, -3011.56396f, -75.9600372f),new Vector3(0.00f, 0.00f, 14.5372477f)),
            new PropLists("prop_shot_glass",new Vector3(-1585.8103f, -3013.05884f, -75.9600372f),new Vector3(0.00f, 0.00f, 25.9479923f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1586.09912f, -3015.56201f, -75.9801178f),new Vector3(0.00f, 0.00f, -109.37986f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1586.30054f, -3014.76758f, -75.9801178f),new Vector3(0.00f, 0.00f, -109.694672f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1586.19751f, -3010.68213f, -75.9801178f),new Vector3(0.00f, 0.00f, -103.756172f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1585.81458f, -3009.91479f, -75.9801178f),new Vector3(0.00f, 0.00f, -147.975037f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1584.21301f, -3008.2644f, -75.9801178f),new Vector3(0.00f, 0.00f, -144.300232f)),
            new PropLists("prop_shots_glass_cs",new Vector3(-1583.90222f, -3008.59619f, -75.9801178f),new Vector3(0.00f, 0.00f, -140.546768f)),
            new PropLists("prop_wine_glass",new Vector3(-1584.55762f, -3008.43579f, -75.960083f),new Vector3(0.00f, 0.00f, 171.093491f)),
            new PropLists("prop_wine_glass",new Vector3(-1585.5957f, -3010.11987f, -75.960083f),new Vector3(0.00f, 0.00f, 153.173355f)),
            new PropLists("vw_prop_casino_wine_glass_01a",new Vector3(-1585.57434f, -3009.98999f, -75.9601135f),new Vector3(0.00f, 0.00f, 99.6810989f)),
            new PropLists("vw_prop_casino_wine_glass_01b",new Vector3(-1585.74231f, -3015.63477f, -75.960083f),new Vector3(0.00f, 0.00f, 81.9577408f)),
            new PropLists("ba_prop_club_tonic_bottle",new Vector3(-1585.76733f, -3014.62256f, -75.9801178f),new Vector3(0.00f, 0.00f, -129.66539f)),
            new PropLists("ng_proc_beerbottle_01a",new Vector3(-1586.24829f, -3015.10596f, -75.9800797f),new Vector3(0.00f, 0.00f, 176.069611f)),
            new PropLists("ng_proc_beerbottle_01a",new Vector3(-1585.79456f, -3014.05957f, -75.9800797f),new Vector3(0.00f, 0.00f, 155.761017f)),
            new PropLists("ng_proc_beerbottle_01a",new Vector3(-1585.99487f, -3012.36011f, -75.9800797f),new Vector3(0.00f, 0.00f, 74.5403671f)),
            new PropLists("ng_proc_beerbottle_01a",new Vector3(-1585.81177f, -3012.01416f, -75.9800797f),new Vector3(0.00f, 0.00f, 76.4104385f)),
            new PropLists("ng_proc_beerbottle_01a",new Vector3(-1585.37036f, -3009.45581f, -75.9800797f),new Vector3(0.00f, 0.00f, 24.927372f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1586.07361f, -3010.08105f, -75.95f),new Vector3(0.00f, 0.00f, -150.491852f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1585.99036f, -3009.66235f, -75.95f),new Vector3(0.00f, 0.00f, -130.668732f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1584.46985f, -3008.85864f, -75.95f),new Vector3(0.00f, 0.00f, -124.231575f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1585.79431f, -3011.74829f, -75.95f),new Vector3(0.00f, 0.00f, -83.6209183f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1586.16626f, -3014.33545f, -75.95f),new Vector3(0.00f, 0.00f, -54.6771965f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1586.15027f, -3013.46631f, -75.95f),new Vector3(0.00f, 0.00f, -99.0142517f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1585.15857f, -3015.84253f, -75.95f),new Vector3(0.00f, 0.00f, -15.8250694f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1584.39868f, -3016.97095f, -75.95f),new Vector3(0.00f, 0.00f, -50.9102287f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1585.35205f, -3016.22778f, -75.95f),new Vector3(0.00f, 0.00f, -84.5582428f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1585.84961f, -3012.62402f, -75.95f),new Vector3(0.00f, 0.00f, -56.0935249f)),
            new PropLists("prop_amb_beer_bottle",new Vector3(-1584.85767f, -3009.20239f, -75.95f),new Vector3(0.00f, 0.00f, -64.1179428f)),
            new PropLists("prop_beer_bottle",new Vector3(-1584.62659f, -3008.60034f, -75.9800797f),new Vector3(0.00f, 0.00f, -120.53466f)),
            new PropLists("prop_beer_bottle",new Vector3(-1585.66992f, -3009.36621f, -75.9800797f),new Vector3(0.00f, 0.00f, -123.395241f)),
            new PropLists("prop_beer_bottle",new Vector3(-1586.22375f, -3010.21167f, -75.9800797f),new Vector3(0.00f, 0.00f, -98.4339523f)),
            new PropLists("prop_beer_bottle",new Vector3(-1586.22156f, -3009.79736f, -75.9800797f),new Vector3(0.00f, 0.00f, -82.1805878f)),
            new PropLists("prop_beer_bottle",new Vector3(-1585.98877f, -3015.76685f, -75.9800797f),new Vector3(0.00f, 0.00f, -31.8521481f)),
            new PropLists("prop_beer_bottle",new Vector3(-1586.27441f, -3015.39355f, -75.9800797f),new Vector3(0.00f, 0.00f, -13.15133f)),
            new PropLists("prop_beer_bottle",new Vector3(-1586.29834f, -3015.58374f, -75.9800797f),new Vector3(0.00f, 0.00f, -111.307098f))
        };

        public static readonly List<Vector4> ParaVeh01 = new List<Vector4>
        {
            new Vector4(223.069641f, -1896.65125f, 24.2081623f, 138.758911f),
            new Vector4(207.738464f, -1820.0553f, 27.1213188f, -129.429886f),
            new Vector4(99.8504639f, -1695.01807f, 28.364357f, 47.7202759f),
            new Vector4(-3.79475117f, -1686.7771f, 28.5365658f, 110.861511f),
            new Vector4(-157.149078f, -1704.77222f, 30.1984634f, -140.375381f),
            new Vector4(-221.686096f, -1822.52649f, 29.2542477f, -59.9763527f),
            new Vector4(-50.9852448f, -2065.60449f, 20.5321617f, -70.9435272f),
            new Vector4(269.132996f, -2125.07324f, 15.2646103f, -133.749695f),
            new Vector4(466.723755f, -2022.37073f, 23.3443279f, 46.1792984f),
            new Vector4(385.206573f, -1937.49805f, 23.9206181f, 45.4935684f),
            new Vector4(387.483978f, -1701.9884f, 28.7558842f, 138.120178f),
            new Vector4(338.766693f, -2470.65381f, 5.1641326f, -3.28795528f),
            new Vector4(589.089355f, -2579.83789f, 5.52716589f, 39.4159546f),
            new Vector4(735.086792f, -2345.29297f, 23.8826599f, 174.996368f),
            new Vector4(678.722168f, -2044.76245f, 28.7802238f, 86.2545013f),
            new Vector4(795.435608f, -2234.91699f, 29.4625626f, 84.21772f),
            new Vector4(688.257446f, -1725.52515f, 29.1790619f, 84.514328f),
            new Vector4(939.507019f, -1754.05151f, 31.2762203f, 82.1573334f),
            new Vector4(504.658966f, -1654.62488f, 26.1815434f, 49.6371727f),
            new Vector4(440.733612f, -1802.92212f, 28.1295204f, 50.3501358f),
            new Vector4(416.99585f, -1873.16724f, 26.6898746f, 132.681717f),
            new Vector4(274.861053f, -2022.6582f, 19.1382599f, -37.8370514f),
            new Vector4(464.177765f, -1919.04626f, 24.8415298f, 112.671097f),
            new Vector4(445.328369f, -2090.68921f, 21.9599152f, 137.762085f),
            new Vector4(-45.4067879f, -1972.65039f, 14.9201756f, 72.015358f),
            new Vector4(-150.630936f, -2000.22852f, 22.3075256f, -6.43309832f),
            new Vector4(39.3238297f, -2050.41821f, 17.7456684f, -91.8154221f),
            new Vector4(28.4606133f, -1636.43359f, 29.134676f, -131.271942f),
            new Vector4(-48.3390236f, -1652.70544f, 29.0977077f, -39.8408966f),
            new Vector4(15.8145781f, -1541.12244f, 29.1025448f, 138.947433f)
        };
        public static readonly List<Vector4> ParaVeh02 = new List<Vector4>
        {
            new Vector4(-428.351501f, -192.857483f, 35.8732719f, 30.1970882f),
            new Vector4(-648.766357f, -157.515289f, 36.9013634f, -149.280411f),
            new Vector4(-645.855713f, -48.7235107f, 39.8795204f, 93.8861465f),
            new Vector4(-733.315002f, -200.724167f, 36.4026794f, -150.609467f),
            new Vector4(-732.631226f, -141.669968f, 36.638752f, 29.5830631f),
            new Vector4(-581.61853f, -383.577179f, 34.2407455f, -88.6676025f),
            new Vector4(-622.106384f, -518.909668f, 34.2426567f, -0.412145913f),
            new Vector4(-390.478119f, -311.58905f, 32.71101f, -125.45726f),
            new Vector4(-368.488953f, -401.721619f, 30.2422848f, -99.774437f),
            new Vector4(-890.428101f, -544.979736f, 33.1194267f, 25.9633427f),
            new Vector4(-855.020752f, -720.785645f, 25.4144363f, 0.275246561f),
            new Vector4(-1026.4032f, -788.869446f, 16.7456493f, 65.4763336f),
            new Vector4(-1028.70764f, -734.529663f, 19.0141373f, -49.3797874f),
            new Vector4(-1148.10022f, -665.019287f, 21.6073513f, 40.2602196f),
            new Vector4(-1175.01062f, -423.94931f, 34.2427711f, -81.2015839f),
            new Vector4(-1049.51111f, -390.217712f, 37.5714951f, -64.4462662f),
            new Vector4(-1015.26392f, -309.39798f, 37.7697983f, -153.168472f),
            new Vector4(-1332.10742f, -827.343445f, 16.9648018f, 47.5422058f),
            new Vector4(-1215.76184f, -886.454529f, 12.7156858f, -56.4302597f),
            new Vector4(-1191.14258f, -973.303894f, 4.96707916f, -59.384613f),
            new Vector4(-1349.4906f, -1115.76746f, 4.46442795f, -62.0137978f),
            new Vector4(-1615.25098f, -973.528076f, 13.0242643f, -39.361599f),
            new Vector4(-1649.99231f, -826.753113f, 10.0524092f, -129.611267f),
            new Vector4(-1589.46399f, -644.941772f, 30.1931934f, -128.93251f),
            new Vector4(-1594.03174f, -542.658691f, 34.5307007f, -49.6530647f),
            new Vector4(-1500.43103f, -412.92691f, 37.6136971f, -133.349701f),
            new Vector4(-1290.03699f, -646.275513f, 25.9803085f, -52.4793816f),
            new Vector4(-1110.34058f, -802.405151f, 17.6258774f, -48.1967316f),
            new Vector4(-898.992004f, -834.888611f, 17.2463932f, -91.5602417f),
            new Vector4(-1068.07251f, -1006.93774f, 1.96821249f, 29.8695049f)
        };
        public static readonly List<Vector4> ParaVeh03 = new List<Vector4>
        {
            new Vector4(-1800.07568f, 1837.06995f, 154.664764f, -68.233757f),
            new Vector4(-1666.15234f, 2227.47437f, 86.3855667f, 68.1683426f),
            new Vector4(-2051.99902f, 2272.71411f, 41.9171791f, -90.9059525f),
            new Vector4(-2058.13257f, 2330.30908f, 35.4738274f, 112.845627f),
            new Vector4(-2214.46411f, 2309.97925f, 32.3033867f, 116.539154f),
            new Vector4(-2048.09326f, 2002.83411f, 189.913437f, -124.661232f),
            new Vector4(-2207.3064f, 1919.59656f, 187.86795f, -67.5529404f),
            new Vector4(-2507.68433f, 2284.94922f, 31.8073463f, -85.0598602f),
            new Vector4(-2730.33984f, 2296.00757f, 18.2064095f, 153.622665f),
            new Vector4(-2540.20581f, 1904.81116f, 168.348633f, -16.2212677f),
            new Vector4(-2499.38232f, 1700.35583f, 153.684494f, -5.80199718f),
            new Vector4(-3049.8645f, 1720.85376f, 36.0555763f, -171.204269f),
            new Vector4(-3006.32837f, 1490.35718f, 27.2175083f, 149.751831f),
            new Vector4(-3002.49609f, 1292.83459f, 32.1535645f, -38.001873f),
            new Vector4(-2794.94727f, 1308.80676f, 72.8844452f, -42.6647873f),
            new Vector4(-2624.45117f, 1325.68994f, 143.285736f, -4.99323416f),
            new Vector4(-2205.45508f, 1061.06641f, 194.677277f, 47.852726f),
            new Vector4(-2027.08948f, 806.926331f, 160.712296f, 172.142197f),
            new Vector4(-1816.58521f, 779.807129f, 137.404388f, -137.027267f),
            new Vector4(-1624.74805f, 1044.64087f, 153.084152f, -16.9577122f),
            new Vector4(-1557.93872f, 1381.53931f, 126.817955f, -44.5004158f),
            new Vector4(-1501.04602f, 1488.25378f, 116.647606f, -15.2719383f),
            new Vector4(-1475.23853f, 2035.19775f, 64.1003571f, 26.1861362f),
            new Vector4(-1544.48755f, 2146.27881f, 55.4697609f, -60.3111801f),
            new Vector4(-1551.89465f, 2259.92676f, 53.5113297f, 19.2420406f),
            new Vector4(-1561.00464f, 2410.0083f, 25.4594707f, 80.8412094f),
            new Vector4(-1360.67944f, 2422.75879f, 27.9491825f, -132.838409f),
            new Vector4(-1336.87024f, 2174.41797f, 52.5123177f, 44.6206551f),
            new Vector4(-1441.78967f, 1830.66565f, 79.9013443f, -22.7745209f),
            new Vector4(-1497.10205f, 1661.78015f, 102.187004f, 18.1835804f)
        };
        public static readonly List<Vector4> ParaVeh04 = new List<Vector4>
        {
            new Vector4(1293.04028f, -639.247742f, 67.3089294f, -160.00592f),
            new Vector4(1336.90271f, -725.678223f, 65.7022476f, 74.0496902f),
            new Vector4(1374.04407f, -577.700562f, 73.6403046f, 31.6552315f),
            new Vector4(1291.1167f, -445.364319f, 68.3425446f, 5.17004633f),
            new Vector4(1134.76563f, -352.851257f, 66.3476639f, 95.3252945f),
            new Vector4(1038.37402f, -419.702301f, 65.3265686f, 129.386765f),
            new Vector4(893.166687f, -509.607513f, 56.9196739f, 109.451721f),
            new Vector4(918.720032f, -604.277344f, 56.6237488f, -126.057281f),
            new Vector4(994.023438f, -552.019348f, 58.9927483f, -55.6649704f),
            new Vector4(999.086243f, -711.068848f, 56.7126465f, -140.388535f),
            new Vector4(1088.24487f, -763.638855f, 57.2289314f, -89.8002319f),
            new Vector4(1169.02869f, -916.867371f, 49.9797173f, 0.0602228418f),
            new Vector4(1055.42529f, -851.438843f, 48.2726898f, -89.4318695f),
            new Vector4(1015.57806f, -323.957092f, 66.4333725f, -120.643372f),
            new Vector4(914.748047f, -262.143066f, 68.1364899f, -127.401314f),
            new Vector4(811.748535f, -79.0462646f, 80.5091705f, -123.653549f),
            new Vector4(1227.14636f, -287.862823f, 70.2237396f, 114.166794f),
            new Vector4(1000.89221f, 197.777679f, 81.0435867f, 141.590805f),
            new Vector4(1055.51917f, 468.039886f, 93.4352875f, -136.311127f),
            new Vector4(1295.70715f, 1094.79187f, 105.580887f, -174.084076f),
            new Vector4(1516.10547f, 890.901123f, 77.3401871f, 151.113098f),
            new Vector4(1301.04773f, 612.860535f, 80.0765686f, 133.435211f),
            new Vector4(2091.60449f, -589.134583f, 95.46698f, 128.667648f),
            new Vector4(1832.98132f, -792.189636f, 78.1664124f, 126.223038f),
            new Vector4(1198.84131f, -1085.81726f, 39.9602127f, 28.6088676f),
            new Vector4(1252.63867f, -1394.36389f, 34.5620117f, 21.1016884f),
            new Vector4(1109.62219f, -1426.16846f, 35.6369057f, -89.531662f),
            new Vector4(1045.35205f, -981.198242f, 43.6283455f, -73.3302307f),
            new Vector4(1196.18213f, -1446.73059f, 34.8982849f, -88.6941299f),
            new Vector4(1257.31897f, -1229.6095f, 35.8189087f, 5.13774633f)
        };
        public static readonly List<Vector4> ParaVeh05 = new List<Vector4>
        {
            new Vector4(1112.76807f, 2823.00732f, 37.241539f, -2.0165174f),
            new Vector4(1021.42004f, 2679.39819f, 38.808342f, -3.0690093f),
            new Vector4(926.64447f, 2710.0144f, 39.8323593f, 174.721359f),
            new Vector4(759.577637f, 2693.12207f, 39.3670921f, 90.6253281f),
            new Vector4(539.395691f, 2681.75195f, 41.7428093f, -82.7792892f),
            new Vector4(519.291992f, 3054.50903f, 39.3013687f, -136.585815f),
            new Vector4(814.267883f, 3104.15625f, 41.2202721f, -97.1857758f),
            new Vector4(1024.12366f, 3009.14868f, 40.5629196f, -160.508255f),
            new Vector4(1154.29675f, 3175.05566f, 40.7868767f, 93.6499634f),
            new Vector4(1565.50439f, 3088.29565f, 39.9761581f, 119.212685f),
            new Vector4(1593.05725f, 2886.80127f, 56.6610069f, 123.52623f),
            new Vector4(1718.36157f, 3065.1189f, 56.1258545f, 39.2216339f),
            new Vector4(1830.65332f, 3199.90356f, 44.4882355f, 116.012833f),
            new Vector4(1786.20496f, 3337.04858f, 40.4496193f, -150.776276f),
            new Vector4(1703.35742f, 3482.05347f, 36.7172508f, -152.290985f),
            new Vector4(1830.94592f, 3642.05322f, 34.240406f, 122.728249f),
            new Vector4(1950.29041f, 3741.18164f, 32.2453957f, -154.582809f),
            new Vector4(2061.12891f, 3426.73486f, 44.3040237f, -179.945328f),
            new Vector4(1995.83508f, 3847.05371f, 32.3076019f, 30.3217449f),
            new Vector4(1855.15967f, 3930.53149f, 33.0033379f, -166.915497f),
            new Vector4(1754.42346f, 3732.56079f, 34.089077f, -151.92717f),
            new Vector4(1675.77136f, 3535.7771f, 35.6052513f, -152.120621f),
            new Vector4(1686.47668f, 3632.16968f, 35.3143082f, 120.821793f),
            new Vector4(2128.87549f, 3764.00146f, 32.941185f, 118.36042f),
            new Vector4(2183.49512f, 3392.00073f, 45.356636f, -159.030106f),
            new Vector4(2163.85767f, 3514.82764f, 45.1197739f, 61.9365273f),
            new Vector4(2042.6416f, 3293.30615f, 44.7109451f, 76.7969818f),
            new Vector4(1885.57495f, 3308.02954f, 43.2658272f, 99.7826767f),
            new Vector4(1966.88098f, 3114.11816f, 46.5558205f, 27.4541321f),
            new Vector4(1486.82813f, 3370.62524f, 35.9536781f, 109.710831f)
        };
        public static readonly List<Vector4> ParaVeh06 = new List<Vector4>
        {
            new Vector4(-136.719666f, 6313.33643f, 30.6852398f, -135.357147f),
            new Vector4(-137.811646f, 6388.93799f, 30.6612949f, 130.22377f),
            new Vector4(-32.2639847f, 6362.9668f, 30.6258488f, 134.527451f),
            new Vector4(-193.223389f, 6460.18408f, 30.0988426f, 148.750397f),
            new Vector4(-235.023697f, 6307.99756f, 30.7104759f, 134.332413f),
            new Vector4(-286.357849f, 6203.17773f, 30.7224236f, -134.301422f),
            new Vector4(-418.566315f, 6202.72119f, 31.0649014f, -173.914688f),
            new Vector4(-439.440857f, 6094.07031f, 30.7960968f, -175.529449f),
            new Vector4(-546.740112f, 5771.18164f, 35.2364578f, 156.004959f),
            new Vector4(-724.950928f, 5798.79297f, 16.9191074f, 155.147125f),
            new Vector4(-774.818787f, 5667.9624f, 22.6893749f, 161.325928f),
            new Vector4(-652.735168f, 5502.28711f, 48.7729073f, -104.641518f),
            new Vector4(-715.282959f, 5432.98828f, 43.6404953f, -118.998718f),
            new Vector4(-939.325073f, 5402.89209f, 37.7439766f, -94.0981827f),
            new Vector4(-884.982483f, 5310.64404f, 78.5250931f, -78.194191f),
            new Vector4(-737.425049f, 5186.5542f, 107.735413f, 0.796692729f),
            new Vector4(-634.996399f, 5091.13965f, 131.181763f, 30.8269958f),
            new Vector4(-940.903198f, 5151.41162f, 158.647827f, -71.1649246f),
            new Vector4(-1037.03357f, 5334.53418f, 44.0614967f, -48.3000259f),
            new Vector4(-545.200806f, 5560.81885f, 59.8949852f, 167.474335f),
            new Vector4(-471.589081f, 5551.75586f, 75.0832214f, -177.389084f),
            new Vector4(-517.563721f, 5726.28809f, 46.2666855f, 167.234055f),
            new Vector4(-630.286804f, 6076.6333f, 8.11592579f, 144.101074f),
            new Vector4(-533.366882f, 6198.11523f, 7.34357357f, 166.485382f),
            new Vector4(-458.376526f, 6355.55273f, 11.783432f, 122.283752f),
            new Vector4(-334.592743f, 6341.72266f, 29.6717949f, 131.450623f),
            new Vector4(-331.014648f, 6267.03467f, 30.9012222f, -137.87706f),
            new Vector4(-305.875732f, 6437.72461f, 12.4501009f, 127.137367f),
            new Vector4(-148.333893f, 6522.42432f, 29.3302307f, 140.741165f),
            new Vector4(75.6379623f, 6613.3877f, 31.2831478f, 44.942276f)
        };
        public static readonly List<Vector4> ParaVeh07 = new List<Vector4>
        {
            new Vector4(5164.53174f, -5108.91162f, 1.78176606f, -140.760941f),
            new Vector4(5230.93506f, -5188.34521f, 12.9792423f, 178.291763f),
            new Vector4(5158.85547f, -5197.22803f, 2.91734219f, -162.34053f),
            new Vector4(5197.14502f, -4990.61523f, 13.6738758f, -142.329269f),
            new Vector4(5267.94775f, -5104.64404f, 13.1067448f, 170.919266f),
            new Vector4(5428.1875f, -5124.91602f, 12.6195211f, -133.494919f),
            new Vector4(5321.02637f, -5242.11475f, 32.1562195f, 86.2589722f),
            new Vector4(5320.729f, -5337.69385f, 37.0143356f, -133.231186f),
            new Vector4(5245.29102f, -5417.51221f, 64.4054184f, 157.901642f),
            new Vector4(5205.10205f, -5521.02051f, 46.1516457f, 156.355865f),
            new Vector4(5070.0957f, -5596.74609f, 33.697403f, 57.7547302f),
            new Vector4(4986.31982f, -5579.4458f, 24.1382027f, 6.5577507f),
            new Vector4(4909.29688f, -5473.39941f, 29.2757969f, 118.360245f),
            new Vector4(4910.3125f, -5383.09326f, 12.6768074f, -11.2319613f),
            new Vector4(4943.86621f, -5287.45361f, 4.3240695f, -2.31216884f),
            new Vector4(5385.77441f, -5686.93262f, 46.7793922f, -3.77865982f),
            new Vector4(5466.53076f, -5814.37354f, 20.1124859f, 5.96165514f),
            new Vector4(5367.15479f, -5553.71436f, 52.3266335f, 11.482358f),
            new Vector4(5494.56787f, -5295.37012f, 17.5160503f, 65.7412796f),
            new Vector4(5545.99268f, -5232.63232f, 13.3726654f, 136.043854f),
            new Vector4(5030.74707f, -4883.55371f, 15.1805925f, -124.099655f),
            new Vector4(5169.25098f, -4962.55859f, 13.978796f, -134.311905f),
            new Vector4(5069.94824f, -4664.79785f, 2.81808066f, 26.9353294f),
            new Vector4(5071.71436f, -4558.38525f, 5.60371399f, 80.8856506f),
            new Vector4(4924.3623f, -4495.59326f, 8.67020893f, -94.5364838f),
            new Vector4(4860.30322f, -4380.27979f, 5.69810772f, -129.974167f),
            new Vector4(4995.37695f, -4542.14502f, 8.45503902f, -139.90184f),
            new Vector4(5020.60693f, -4689.97656f, 8.22763634f, 173.681152f),
            new Vector4(5000.61133f, -4821.21094f, 13.9201279f, -163.206879f),
            new Vector4(4967.17334f, -4705.26855f, 8.09709454f, -38.3691483f)
        };

        public static readonly List<Vector3> CayoPackPl = new List<Vector3>
        {
            new Vector3(3901.277f, -4694.813f, 4.234453f), new Vector3(4495.951f, -4734.207f, 10.84465f), new Vector3(4873.813f, -4485.711f, 10.15341f), new Vector3(4863.543f, -4635.776f, 14.18864f), new Vector3(4895.215f, -4792.363f, 2.784456f), new Vector3(5107.291f, -4578.146f, 29.71777f), new Vector3(5130.018f, -4609.434f, 12.69085f), new Vector3(4866.521f, -5160.332f, 2.434262f), new Vector3(5140.08f, -5085.565f, 2.292881f), new Vector3(4903.876f, -5331.577f, 29.14107f), new Vector3(5266.809f, -5430.166f, 141.041f), new Vector3(5612.969f, -5651.019f, 10.05457f), new Vector3(5600.291f, -5459.215f, 10.72322f), new Vector3(5593.851f, -5224.01f, 14.34492f), new Vector3(5403.367f, -5174.496f, 31.46212f), new Vector3(4501.908f, -4522.904f, 4.412361f), new Vector3(4527.481f, -4535.834f, 7.552054f), new Vector3(4765.726f, -4777.026f, 4.855045f), new Vector3(5059.213f, -4591.081f, 2.906231f), new Vector3(5077.466f, -4630.137f, 2.390313f), new Vector3(5169.982f, -4675.766f, 2.435424f), new Vector3(5164.579f, -5049.855f, 4.335027f), new Vector3(5010.848f, -5201.055f, 2.516255f), new Vector3(4927.385f, -5272.393f, 5.658763f), new Vector3(4950.118f, -5321.06f, 8.083879f), new Vector3(4886.743f, -5460.385f, 30.73853f), new Vector3(5108.986f, -5522.397f, 54.2145f), new Vector3(5272.928f, -5425.16f, 65.59611f), new Vector3(4074.888f, -4664.603f, 4.288707f), new Vector3(4415.872f, -4478.275f, 4.334019f), new Vector3(4535.767f, -4543.152f, 4.970639f), new Vector3(4505.364f, -4654.637f, 11.63728f), new Vector3(5071.25f, -4634.065f, 2.359646f), new Vector3(4841.807f, -5171.894f, 2.265403f), new Vector3(4878.454f, -5114.993f, 2.197809f), new Vector3(5215.129f, -5126.617f, 6.260477f), new Vector3(5328.317f, -5265.676f, 33.18594f), new Vector3(5400.062f, -5172.845f, 31.38728f), new Vector3(5422.316f, -5239.97f, 35.46599f), new Vector3(5404.683f, -5170.87f, 31.43855f), new Vector3(5215.685f, -5131.827f, 6.293792f), new Vector3(4919.547f, -5273.42f, 5.646538f) 
        };
        public static readonly List<string> CayoPackIt = new List<string>
        { 
            "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_bag_hook_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_crate_cloth_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_bolt_cutter_01a", "h4_prop_h4_powdercleaner_01a", "h4_prop_h4_powdercleaner_01a", "h4_prop_h4_powdercleaner_01a" 
        };

        public static readonly List<Vector3> CayoFolStart01 = new List<Vector3>
        {
            new Vector3(4967.81f, -4668.752f, 11.41602f),
            new Vector3(4961.72f, -4823.566f, 5.969322f),
            new Vector3(4968.433f, -4710.264f, 8.319826f),
            new Vector3(5005.988f, -4715.379f, 10.74354f),
            new Vector3(5014.907f, -4768.094f, 17.62075f),
            new Vector3(5049.153f, -4835.865f, 19.09438f),
            new Vector3(5107.04f, -4888.757f, 15.08302f),
            new Vector3(5105.134f, -4946.161f, 17.234f),
            new Vector3(5132.717f, -4944.722f, 14.9087f),
            new Vector3(5139.033f, -4949.664f, 14.52732f),
            new Vector3(5138.216f, -4956.092f, 14.51503f),
            new Vector3(5148.449f, -4964.634f, 13.98844f),
            new Vector3(5150.176f, -4973.736f, 13.15734f),
            new Vector3(5198.056f, -5050.193f, 12.95233f)
        };
        public static readonly List<Vector3> CayoFolStart02 = new List<Vector3>
        {
            new Vector3(5022.979f, -4871.323f, 14.67111f),
            new Vector3(5007.773f, -4926.326f, 9.441853f),
            new Vector3(5052.629f, -4910.178f, 15.26108f),
            new Vector3(5071.191f, -4920.844f, 17.56548f),
            new Vector3(5112.578f, -4949.875f, 16.03908f),
            new Vector3(5132.667f, -4944.529f, 14.91733f),
            new Vector3(5138.29f, -4948.303f, 14.5717f),
            new Vector3(5139.203f, -4956.247f, 14.48044f),
            new Vector3(5148.311f, -4964.622f, 13.99567f),
            new Vector3(5149.051f, -4974.38f, 13.15724f),
            new Vector3(5159.524f, -5001.336f, 10.62832f),
            new Vector3(5166.199f, -5003.822f, 11.54279f),
            new Vector3(5195.089f, -5049.757f, 12.72364f)
        };
        public static readonly List<Vector3> CayoFolStart03 = new List<Vector3>
        {
            new Vector3(4523.574f, -4614.735f, 11.39894f),
            new Vector3(4511.16f, -4517.847f, 3.587658f),
            new Vector3(4515.872f, -4527.401f, 3.652275f),
            new Vector3(4543.808f, -4535.727f, 5.535728f),
            new Vector3(4629.189f, -4544.506f, 13.17307f),
            new Vector3(4725.248f, -4534.113f, 25.95804f),
            new Vector3(4803.674f, -4562.749f, 22.14445f),
            new Vector3(4908.089f, -4615.26f, 14.42918f),
            new Vector3(4951.479f, -4657.686f, 12.37331f),
            new Vector3(4964.315f, -4697.906f, 8.262118f),
            new Vector3(4999.572f, -4713.235f, 10.152f),
            new Vector3(5015.257f, -4751.375f, 14.55854f),
            new Vector3(5035.354f, -4785.92f, 17.62213f),
            new Vector3(5060.729f, -4837.399f, 18.13685f),
            new Vector3(5074.84f, -4883.288f, 16.71885f),
            new Vector3(5098.159f, -4917.585f, 16.05454f),
            new Vector3(5108.796f, -4947.615f, 15.96881f),
            new Vector3(5131.853f, -4944.349f, 14.43147f),
            new Vector3(5138.741f, -4949.731f, 14.01434f),
            new Vector3(5138.146f, -4955.658f, 13.98357f),
            new Vector3(5148.977f, -4964.736f, 13.43088f),
            new Vector3(5148.332f, -4978.535f, 12.0283f),
            new Vector3(5158.495f, -4999.322f, 10.34334f),
            new Vector3(5166.982f, -5004.785f, 11.12053f),
            new Vector3(5192.109f, -5050.282f, 11.95023f)
        };
        public static readonly List<Vector3> CayoFolEnd01 = new List<Vector3>
        {
            new Vector3(5233.71f, -5055.481f, 14.41616f),
            new Vector3(5269.771f, -5102.388f, 13.13458f),
            new Vector3(5278.364f, -5125.787f, 13.75129f),
            new Vector3(5287.151f, -5145.533f, 22.36536f),
            new Vector3(5308.764f, -5180.225f, 29.13452f),
            new Vector3(5346.964f, -5218.778f, 30.71546f),
            new Vector3(5333.356f, -5267.576f, 32.84147f)
        };
        public static readonly List<Vector3> CayoFolEnd02 = new List<Vector3>
        {
            new Vector3(5194.607f, -5067.506f, 11.8923f),
            new Vector3(5174.759f, -5130.188f, 2.333519f),
            new Vector3(5186.785f, -5133.329f, 3.339868f)
        };
        public static readonly List<Vector3> CayoFolEnd03 = new List<Vector3>
        {
            new Vector3(5203.195f, -5075.889f, 10.8781f),
            new Vector3(5224.331f, -5128.517f, 6.7265f),
            new Vector3(5198.844f, -5199.504f, 12.17268f),
            new Vector3(5158.8f, -5215.011f, 5.527559f),
            new Vector3(5143.752f, -5271.163f, 8.674473f),
            new Vector3(5096.204f, -5284.654f, 5.629894f),
            new Vector3(5016.943f, -5179.651f, 1.995464f),
            new Vector3(4995.838f, -5182.11f, 1.955377f),
            new Vector3(4991.229f, -5169.521f, 2.579536f),
            new Vector3(4975.339f, -5150.584f, 2.530874f),
            new Vector3(4969.555f, -5123.96f, 2.733868f),
            new Vector3(4959.88f, -5114.331f, 2.909248f)
        };
        public static readonly List<Vector3> CayoFolEnd04 = new List<Vector3>
        {
            new Vector3(5203.195f, -5075.889f, 10.8781f),
            new Vector3(5224.331f, -5128.517f, 6.7265f),
            new Vector3(5198.844f, -5199.504f, 12.17268f),
            new Vector3(5158.8f, -5215.011f, 5.527559f),
            new Vector3(5143.752f, -5271.163f, 8.674473f),
            new Vector3(5096.204f, -5284.654f, 5.629894f),
            new Vector3(5016.943f, -5179.651f, 1.995464f),
            new Vector3(4995.838f, -5182.11f, 1.955377f),
            new Vector3(4974.74f, -5198.996f, 2.475773f),
            new Vector3(4943.943f, -5217.656f, 2.516457f),
            new Vector3(4922.802f, -5216.061f, 2.440305f),
            new Vector3(4914.682f, -5227.528f, 2.52028f),
            new Vector3(4920.186f, -5238.085f, 2.522556f)
        };
        public static readonly List<Vector3> CayoFolEnd05 = new List<Vector3>
        {
            new Vector3(5203.195f, -5075.889f, 10.8781f),
            new Vector3(5224.331f, -5128.517f, 6.7265f),
            new Vector3(5198.844f, -5199.504f, 12.17268f),
            new Vector3(5158.8f, -5215.011f, 5.527559f),
            new Vector3(5143.752f, -5271.163f, 8.674473f),
            new Vector3(5096.204f, -5284.654f, 5.629894f),
            new Vector3(5016.943f, -5179.651f, 1.995464f),
            new Vector3(4995.838f, -5182.11f, 1.955377f),
            new Vector3(4995.05f, -5167.059f, 2.694044f)
        };

        public static readonly List<RaceRec> ThifeBoatMain = new List<RaceRec>
        {
            new RaceRec(0.00443956442f, new Vector3(4959.102f, -5165.904f, 0.296656281f)),
            new RaceRec(2.578928f, new Vector3(4958.459f, -5165.613f, 0.336533546f)),
            new RaceRec(10.6217194f, new Vector3(4952.604f, -5162.965f, 0.457043469f)),
            new RaceRec(17.6908f, new Vector3(4938.739f, -5158.05762f, 0.508368134f)),
            new RaceRec(21.2225189f, new Vector3(4919.62256f, -5154.14941f, 0.599316061f)),
            new RaceRec(23.12618f, new Vector3(4897.383f, -5150.83838f, 0.631747842f)),
            new RaceRec(21.9438782f, new Vector3(4874.33252f, -5147.828f, 0.748740733f)),
            new RaceRec(24.6535225f, new Vector3(4850.74f, -5147.228f, 0.962624967f)),
            new RaceRec(23.5906429f, new Vector3(4827.95361f, -5150.86035f, 0.8f)),
            new RaceRec(21.1170559f, new Vector3(4805.42725f, -5156.17969f, 0.8f)),
            new RaceRec(27.1961155f, new Vector3(4781.53369f, -5162.761f, 0.8f)),
            new RaceRec(22.8173161f, new Vector3(4757.672f, -5169.602f, 0.8f)),
            new RaceRec(26.8614769f, new Vector3(4732.571f, -5176.759f, 0.8f)),
            new RaceRec(24.6194763f, new Vector3(4709.329f, -5183.32031f, 0.8f)),
            new RaceRec(22.7911415f, new Vector3(4684.78369f, -5190.107f, 0.842966139f)),
            new RaceRec(25.5016766f, new Vector3(4662.17725f, -5196.159f, 0.8f)),
            new RaceRec(22.8150043f, new Vector3(4637.08057f, -5202.548f, 0.9300174f)),
            new RaceRec(25.3128757f, new Vector3(4613.04053f, -5208.433f, 0.6060994f)),
            new RaceRec(22.9676571f, new Vector3(4589.55566f, -5214.023f, 0.8f)),
            new RaceRec(28.628458f, new Vector3(4565.58057f, -5219.6626f, 0.8f)),
            new RaceRec(24.2479973f, new Vector3(4538.216f, -5226.02344f, -0.345161438f)),
            new RaceRec(20.61106f, new Vector3(4517.60938f, -5230.527f, 0.8f)),
            new RaceRec(22.780859f, new Vector3(4496.68555f, -5234.963f, 0.8f)),
            new RaceRec(20.8912945f, new Vector3(4476.516f, -5239.1167f, 0.8f))
        };
        public static readonly List<RaceRec> ThifeBoatNorth = new List<RaceRec>
        {
            new RaceRec(0.09934837f, new Vector3(5090.329f, -4638.302f, 0.3147217f)),
            new RaceRec(1.00157881f, new Vector3(5090.45947f, -4638.347f, 0.3317337f)),
            new RaceRec(8.086622f, new Vector3(5094.465f, -4639.73145f, 0.393228829f)),
            new RaceRec(16.3080482f, new Vector3(5106.52441f, -4643.9043f, 0.516812444f)),
            new RaceRec(19.67388f, new Vector3(5122.771f, -4652.361f, 0.541719258f)),
            new RaceRec(20.012907f, new Vector3(5134.955f, -4668.6333f, 0.429019034f)),
            new RaceRec(22.88432f, new Vector3(5143.33838f, -4688.91f, 0.697131753f)),
            new RaceRec(21.9878635f, new Vector3(5154.02f, -4708.682f, 0.9658855f)),
            new RaceRec(22.6162949f, new Vector3(5169.402f, -4725.604f, 0.9265666f)),
            new RaceRec(23.19864f, new Vector3(5188.72656f, -4737.292f, 0.8809127f)),
            new RaceRec(23.6488228f, new Vector3(5210.656f, -4747.395f, 0.5186897f)),
            new RaceRec(25.3910561f, new Vector3(5232.223f, -4756.111f, 0.8f)),
            new RaceRec(22.6850376f, new Vector3(5256.078f, -4765.386f, 0.9025404f)),
            new RaceRec(27.36069f, new Vector3(5278.848f, -4773.56836f, 0.8f)),
            new RaceRec(23.3537788f, new Vector3(5301.825f, -4780.893f, 0.8f)),
            new RaceRec(22.7001114f, new Vector3(5326.02051f, -4786.6333f, 0.8f)),
            new RaceRec(28.7410469f, new Vector3(5351.64f, -4791.56f, 0.8f)),
            new RaceRec(24.60375f, new Vector3(5378.80273f, -4796.51465f, 0.8f)),
            new RaceRec(25.98346f, new Vector3(5403.08545f, -4800.767f, 0.8f)),
            new RaceRec(20.3117256f, new Vector3(5425.91943f, -4805.318f, 0.774288356f)),
            new RaceRec(25.4162f, new Vector3(5446.91846f, -4809.5083f, 0.8f)),
            new RaceRec(26.087965f, new Vector3(5474.42725f, -4815.265f, 0.8f)),
            new RaceRec(22.0470448f, new Vector3(5498.9043f, -4821.28467f, 0.8f)),
            new RaceRec(26.3214455f, new Vector3(5522.524f, -4827.00439f, 0.8f)),
            new RaceRec(23.8826485f, new Vector3(5547.22559f, -4833.287f, 0.8f)),
            new RaceRec(21.803442f, new Vector3(5571.866f, -4839.579f, 0.8f)),
            new RaceRec(22.26153f, new Vector3(5593.85742f, -4845.052f, 0.8f))
        };
        /*
        public static readonly List<Vector4> SpPoint = new List<Vector4>
        {
            new Vector4(-1160.148f, -1607.229f, 4.282094f, 33.58816f),
            new Vector4(-1246.173f, -1578.978f, 4.075636f, 88.40285f),
            new Vector4(-1300.651f, -1693.796f, 2.652158f, 119.986f),
            new Vector4(-1197.284f, -1673.913f, 4.368378f, 336.6819f),
            new Vector4(-1231.23f, -1774.339f, 2.698436f, 307.819f),
            new Vector4(-1081.606f, -1699.635f, 4.51774f, 341.5313f),
            new Vector4(-1321.38f, -1803.161f, 0.5787229f, 338.6356f),
            new Vector4(-1277.734f, -1796.447f, -100.0f, 190.3f),
            new Vector4(-1329.865f, -1621.267f, 3.853039f, 125.3387f),
            new Vector4(-1368.747f, -1588.793f, 2.370532f, 177.0662f),
            new Vector4(-1380.893f, -1418.045f, 3.565593f, 323.6023f),
            new Vector4(-1279.822f, -1427.41f, 4.510245f, 212.68f),
            new Vector4(-1255.639f, -1592.376f, 4.094669f, 227.7035f),
            new Vector4(-1224.641f, -1502.119f, 4.337264f, 236.9933f),
            new Vector4(-1431.731f, -1508.598f, 3.715238f, 85.04395f),
            new Vector4(-1308.609f, -1529.277f, 4.314957f, 74.17694f),
            new Vector4(-1322.848f, -1734.16f, 1.786219f, 247.0966f),
            new Vector4(-1427.198f, -1658.383f, -0.3996229f, 276.3645f),
            new Vector4(-1270.877f, -1811.516f, 1.774477f, 192.7982f),
            new Vector4(-1178.216f, -1781.372f, 4.050908f, 319.6324f),
            new Vector4(-1153.027f, -1606.098f, 4.380119f, 56.83902f),
            new Vector4(-1109.917f, -1688.4f, 4.375373f, 119.264f),
            new Vector4(-1050.216f, -1619.146f, 4.389634f, 203.3658f),
            new Vector4(-1108.875f, -1527.476f, 6.779634f, 211.7134f),
            new Vector4(-1198.382f, -1673.201f, 4.36664f, 310.3611f),
            new Vector4(-1170.423f, -1433.136f, 4.453862f, 216.7254f),
            new Vector4(-1314.11f, -1352.265f, 4.469654f, 25.83949f),
            new Vector4(-1346.334f, -1276.67f, 4.897387f, 190.3171f),
            new Vector4(-1359.945f, -1193.812f, 4.450387f, 349.2703f),
            new Vector4(-1241.474f, -1253.23f, 5.328512f, 105.528f),
            new Vector4(-1369.884f, -1117.181f, 4.500574f, 260.4205f),
            new Vector4(-1290.337f, -1108.623f, 6.826903f, 50.96396f),
            new Vector4(-1423.398f, -1023.807f, 4.997945f, 239.7593f),
            new Vector4(-1332.74f, -1028.393f, 7.703401f, 32.42556f),
            new Vector4(-1484.517f, -960.1639f, 7.692502f, 45.27397f),
            new Vector4(-1384.187f, -944.0807f, 10.06455f, 333.1175f),
            new Vector4(-1577.719f, -970.7444f, 17.41236f, 134.7335f),
            new Vector4(-1589.911f, -1069.783f, 13.01727f, 66.19942f),
            new Vector4(-1526.156f, -1224.26f, 2.271887f, 198.1657f),
            new Vector4(-1647.783f, -1125.91f, 18.34311f, 226.7262f),
            new Vector4(-1817.684f, -1200.282f, 19.16987f, 272.2027f),
            new Vector4(-1722.691f, -1102.711f, 13.10247f, 232.1385f),
            new Vector4(-1741.421f, -1000.758f, 4.251456f, 283.4004f),
            new Vector4(-1656.441f, -1023.758f, 13.01742f, 134.6409f),
            new Vector4(-1789.288f, -867.3212f, 7.367817f, 26.9756f),
            new Vector4(-1766.264f, -710.6727f, 14.04142f, 128.1337f),
            new Vector4(-1840.649f, -786.7416f, 6.942594f, 209.3775f),
            new Vector4(-1928.198f, -787.6534f, 1.400905f, 124.8805f),
            new Vector4(-1853.948f, -643.4832f, 10.74218f, 51.13507f),
            new Vector4(-1693.429f, -782.542f, 10.15547f, 31.77343f),
            new Vector4(-2019.225f, -671.4921f, 1.732529f, 35.30247f),
            new Vector4(-2073.122f, -556.3633f, 4.322869f, 112.1614f),
            new Vector4(-1918.171f, -581.4932f, 11.82719f, 74.45322f),
            new Vector4(-1941.187f, -683.3286f, 6.042047f, 317.4851f),
            new Vector4(-2017.408f, -403.2584f, 10.99738f, 102.571f),
            new Vector4(-2073.494f, -322.6716f, 13.31618f, 110.8201f),
            new Vector4(-1920.867f, -395.7564f, 48.28661f, 144.3688f),
            new Vector4(-1932.222f, -256.2742f, 39.38351f, 163.2952f),
            new Vector4(-2006.573f, -292.1909f, 31.14633f, 32.56577f),
            new Vector4(-1830.16f, -393.1055f, 57.13855f, 341.9896f),
            new Vector4(-1812.373f, -487.2023f, 40.97498f, 99.4837f),
            new Vector4(-1801.349f, -284.9655f, 42.74314f, 49.44889f),
            new Vector4(-1750.369f, -388.2991f, 49.33112f, 306.9421f),
            new Vector4(-1733.029f, -542.143f, 37.22449f, 46.17191f),
            new Vector4(-1652.144f, -473.3973f, 38.76246f, 156.1328f),
            new Vector4(-1582.329f, -541.8163f, 35.48005f, 318.3726f),
            new Vector4(-1688.893f, -614.0651f, 32.71557f, 160.953f),
            new Vector4(-1590.418f, -652.4891f, 29.94338f, 234.872f),
            new Vector4(-1516.227f, -630.6576f, 29.60688f, 124.8291f),
            new Vector4(-1514.848f, -720.5037f, 27.28335f, 44.38182f),
            new Vector4(-1467.341f, -779.6733f, 23.88621f, 141.6295f),
            new Vector4(-1426.177f, -608.0167f, 30.68489f, 216.1941f),
            new Vector4(-1429.254f, -685.5729f, 30.09999f, 351.6236f),
            new Vector4(-1370.448f, -786.2045f, 19.34618f, 46.06882f),
            new Vector4(-1509.341f, -849.4481f, 23.72846f, 146.3204f),
            new Vector4(-1338.667f, -684.4074f, 25.90955f, 337.9835f),
            new Vector4(-1267.564f, -887.0582f, 11.46313f, 312.6759f),
            new Vector4(-1291.891f, -963.3849f, 10.90977f, 17.93775f),
            new Vector4(-1243.466f, -1037.107f, 8.533915f, 24.88162f),
            new Vector4(-1205.129f, -946.3865f, 8.115028f, 78.52157f),
            new Vector4(-1209.501f, -1145.148f, 7.699383f, 246.5961f),
            new Vector4(-1152.507f, -1092.617f, 2.150213f, 78.05627f),
            new Vector4(-1176.931f, -1326.262f, 5.043202f, 91.40005f),
            new Vector4(-1278.753f, -1280.306f, -100.0f, 286.1835f),
            new Vector4(-280.1419f, -2078.309f, 27.75568f, 120.8461f),
            new Vector4(-362.931f, -2096.714f, -100.0f, 249.8338f),
            new Vector4(-1233.953f, -2060.108f, 14.38426f, 322.4592f),
            new Vector4(-1177.911f, -1969.751f, 12.2126f, 245.5379f),
            new Vector4(-958.8653f, -2038.964f, 9.571634f, 275.1023f),
            new Vector4(-1065.295f, -2082.96f, 13.29153f, 124.204f),
            new Vector4(-1158.608f, -2165.972f, 13.38066f, 105.9783f),
            new Vector4(-990.8157f, -2278.67f, 8.95359f, 230.7598f),
            new Vector4(-878.8334f, -2183.131f, 8.937191f, 216.7394f),
            new Vector4(-891.5108f, -2402.83f, 14.02515f, 147.8056f),
            new Vector4(-893.0229f, -2317.104f, -3.507768f, 8.885142f),
            new Vector4(-978.1707f, -2465.764f, 13.75622f, 149.0023f),
            new Vector4(-900.1584f, -2491.51f, 14.54965f, 27.85674f),
            new Vector4(-1033.629f, -2381.482f, 14.0936f, 173.6633f),
            new Vector4(-955.9147f, -2386.496f, -100.0f, 149.8728f),
            new Vector4(1450.433f, -1731.397f, 68.03314f, 41.98439f),
            new Vector4(1600.253f, -1712.9f, 88.12589f, 185.5337f),
            new Vector4(1568.778f, -1595.55f, 90.31343f, 334.3277f),
            new Vector4(1715.997f, -1560.912f, 112.6362f, 265.2239f),
            new Vector4(1729.931f, -1664.9f, 112.5535f, 55.15057f),
            new Vector4(1677.571f, -1857.563f, 108.353f, 227.1044f),
            new Vector4(1544.524f, -2091.144f, 77.13461f, 115.2182f),
            new Vector4(1397.054f, -2203.803f, 61.26979f, 11.66307f),
            new Vector4(1432.708f, -2318.181f, 66.93765f, 0.1958369f),
            new Vector4(1090.301f, -2258.336f, 30.16828f, 154.4966f),
            new Vector4(1050.76f, -2359.522f, 30.58618f, 359.6519f),
            new Vector4(1257.031f, -2301.23f, 50.42583f, 297.5381f),
            new Vector4(1213.246f, -2201.788f, 41.42298f, 174.4906f),
            new Vector4(1181.73f, -2088.975f, 42.835f, 108.8092f),
            new Vector4(1075.413f, -2130.978f, 32.65754f, 356.5745f),
            new Vector4(1069.265f, -2051.669f, 30.54184f, 328.8749f),
            new Vector4(1253.046f, -1965.152f, 43.31088f, 277.0399f),
            new Vector4(1162.939f, -1835.688f, 37.32333f, 309.8178f),
            new Vector4(1253.974f, -1801.581f, 41.43707f, 101.9945f),
            new Vector4(1165.914f, -1757.395f, 36.09859f, 5.626177f),
            new Vector4(1211.297f, -1635.897f, 46.98957f, 15.0685f),
            new Vector4(1339.797f, -1769.144f, 58.84056f, 110.8002f),
            new Vector4(1299.746f, -1624.184f, 52.31812f, 219.0709f),
            new Vector4(1370.415f, -1683.915f, 59.39519f, 28.85051f),
            new Vector4(1338.409f, -1524.272f, 54.58279f, 175.8651f),
            new Vector4(1264.839f, -1511.525f, 40.75233f, 196.139f),
            new Vector4(1162.592f, -1484.728f, 34.84315f, 45.85416f),
            new Vector4(1215.056f, -1389.57f, 35.3749f, 298.4576f),
            new Vector4(1064.018f, -1447.581f, 36.74253f, 272.2317f),
            new Vector4(962.9564f, -1491.263f, 31.03523f, 283.0984f),
            new Vector4(811.0013f, -1355.856f, 26.39643f, 139.9369f),
            new Vector4(852.3708f, -1452.39f, 28.46454f, 153.5606f),
            new Vector4(782.0834f, -1276.112f, 26.38883f, 245.5533f),
            new Vector4(708.6996f, -1387.042f, 26.28415f, 95.50644f),
            new Vector4(729.1082f, -1202.147f, 27.59183f, 314.4826f),
            new Vector4(866.4579f, -1218.872f, 25.93666f, 150.9242f),
            new Vector4(812.4778f, -1108.296f, 22.87424f, 358.1263f),
            new Vector4(805.5677f, -992.9066f, 26.17185f, 93.29649f),
            new Vector4(719.1799f, -1068.157f, 22.22762f, 76.04496f),
            new Vector4(867.8777f, -949.1575f, 26.28246f, 284.0382f),
            new Vector4(799.3265f, -910.1976f, 25.25154f, 64.5854f),
            new Vector4(788.2667f, -779.5413f, 26.43379f, 76.76219f),
            new Vector4(676.5705f, -893.8166f, 23.46652f, 48.36354f),
            new Vector4(792.6351f, -680.9716f, 28.78763f, 182.0778f),
            new Vector4(712.2411f, -718.2731f, 26.09179f, 222.572f),
            new Vector4(871.4885f, -477.5969f, 57.6135f, 27.29279f),
            new Vector4(802.2733f, -487.6502f, 29.98962f, 66.31482f),
            new Vector4(762.3665f, -605.8344f, 29.01363f, 289.0056f),
            new Vector4(647.2089f, -405.4547f, 25.90333f, 141.224f),
            new Vector4(793.6388f, -251.5794f, 66.11258f, 262.0274f),
            new Vector4(740.2285f, -348.7549f, 44.64523f, 102.3112f),
            new Vector4(842.9829f, -326.1672f, 58.63135f, 78.39604f),
            new Vector4(774.1849f, -157.5243f, 74.47166f, 194.3f),
            new Vector4(717.7997f, -231.8359f, 66.49796f, 145.0598f),
            new Vector4(879.2205f, -133.0256f, 78.19176f, 321.4662f),
            new Vector4(954.9133f, -139.376f, 74.48351f, 261.024f),
            new Vector4(770.9991f, -20.69291f, 81.40639f, 55.6139f),
            new Vector4(918.6093f, -299.0002f, 65.7274f, 89.47182f),
            new Vector4(1075.878f, -221.7357f, 57.22911f, 100.7295f),
            new Vector4(1167.627f, -326.1849f, 69.27177f, 253.1378f),
            new Vector4(1182.85f, -419.4162f, 67.44855f, 160.1736f),
            new Vector4(1095.917f, -363.7542f, 67.05442f, 154.2719f),
            new Vector4(1241.207f, -370.6926f, 69.08267f, 357.5793f),
            new Vector4(1295.678f, -450.1477f, 69.11702f, 39.42892f),
            new Vector4(1196.354f, -500.0268f, 65.35512f, 239.1896f),
            new Vector4(1244.402f, -565.6254f, 69.36629f, 327.5226f),
            new Vector4(1358.867f, -507.7113f, 74.07481f, 238.6464f),
            new Vector4(1271.949f, -679.5294f, 65.78483f, 221.1033f),
            new Vector4(1170.739f, -673.777f, 60.85263f, 8.802817f),
            new Vector4(1157.536f, -826.6323f, 55.04485f, 261.9964f),
            new Vector4(1229.198f, -774.131f, 59.95905f, 111.6313f),
            new Vector4(1065.049f, -721.359f, 56.7688f, 251.442f),
            new Vector4(961.0184f, -668.5934f, 58.42073f, 252.7814f),
            new Vector4(944.5909f, -590.6015f, 57.93015f, 263.7933f),
            new Vector4(1065.475f, -587.393f, 56.98307f, 176.1875f),
            new Vector4(1087.19f, -483.9626f, 65.1468f, 43.63801f),
            new Vector4(990.569f, -528.5084f, 60.1135f, 187.5177f),
            new Vector4(1029.239f, -420.6697f, 65.71067f, 103.3361f),
            new Vector4(878.2419f, 536.1291f, 125.7603f, 256.0516f),
            new Vector4(780.4013f, 569.2122f, 127.5153f, 308.715f),
            new Vector4(-1652.492f, -268.9684f, 53.03486f, 238.35f),
            new Vector4(-1796.219f, -262.315f, 44.68269f, 225.691f),
            new Vector4(-1862.262f, -346.5329f, 49.84129f, 207.6463f),
            new Vector4(-1746.119f, -373.1069f, 46.04745f, 348.238f),
            new Vector4(-1758.126f, -177.5893f, 59.93489f, 53.74375f),
            new Vector4(-1851.886f, -211.0984f, 39.37838f, 30.06215f),
            new Vector4(-1647.251f, -157.372f, 57.61746f, 114.5786f),
            new Vector4(-1657.056f, -12.40816f, 61.96356f, 225.4638f),
            new Vector4(-1855.837f, 87.75642f, 79.74529f, 317.2931f),
            new Vector4(-2227.431f, 177.6394f, 174.6018f, 246.6147f),
            new Vector4(-2183.896f, 284.1322f, 169.6021f, 263.2045f),
            new Vector4(-2266.481f, 266.8381f, 184.6013f, 236.3674f),
            new Vector4(-2340.92f, 224.7503f, 169.6533f, 147.9599f),
            new Vector4(-2291.11f, 419.6725f, 174.6017f, 269.9671f),
            new Vector4(-2351.723f, 354.5746f, 174.5702f, 316.094f),
            new Vector4(-1992.776f, 597.1656f, 117.9074f, 244.9395f),
            new Vector4(-1918.98f, 427.659f, 102.579f, 288.3187f),
            new Vector4(-1942.294f, 537.5837f, 119.4511f, 71.42182f),
            new Vector4(-1863.526f, 663.243f, 129.1108f, 47.40017f),
            new Vector4(-1950.522f, 671.437f, 126.8631f, 49.11973f),
            new Vector4(-1821.452f, 805.2283f, 138.6922f, 350.8116f),
            new Vector4(-1596.12f, 763.6357f, 188.776f, 67.02236f),
            new Vector4(-1537.647f, 824.0611f, 181.5576f, 132.0971f),
            new Vector4(-1390.973f, 604.0109f, 130.5611f, 103.6059f),
            new Vector4(-1380.87f, 733.273f, 182.4565f, 346.0296f),
            new Vector4(-1273.141f, 606.6987f, 139.2841f, 177.0211f),
            new Vector4(-1208.797f, 648.6027f, 144.6223f, 184.7298f),
            new Vector4(-1187.657f, 561.1202f, 100.0236f, 282.7813f),
            new Vector4(-1061.68f, 732.2233f, 165.4498f, 328.4958f),
            new Vector4(-1123.518f, 796.3937f, 167.7469f, 256.4597f),
            new Vector4(-974.0649f, 689.8514f, 158.0351f, 36.62312f),
            new Vector4(-952.0835f, 799.6948f, 178.4169f, 358.3044f),
            new Vector4(-854.5779f, 790.907f, 191.7423f, 343.4804f),
            new Vector4(-800.5696f, 886.0236f, 203.1893f, 150.7404f),
            new Vector4(-757.3545f, 774.8885f, 212.2914f, 21.35574f),
            new Vector4(-679.4247f, 798.2404f, 198.0051f, 179.3822f),
            new Vector4(-668.9477f, 906.9561f, 230.1238f, 229.8917f),
            new Vector4(-538.2089f, 785.8329f, 196.6117f, 117.694f),
            new Vector4(-398.9189f, 666.7883f, 163.8354f, 90.2931f),
            new Vector4(-510.514f, 671.3224f, 150.273f, 163.8439f),
            new Vector4(-472.1857f, 537.1354f, 124.354f, 0.0f),
            new Vector4(-385.3415f, 515.0933f, 120.8225f, 227.8424f),
            new Vector4(-355.368f, 423.3936f, 110.8382f, 345.9255f),
            new Vector4(-506.4408f, 454.185f, 96.69381f, 276.8076f),
            new Vector4(-245.8695f, 393.0556f, 112.4406f, 260.9666f),
            new Vector4(-60.18164f, 494.9249f, 144.5688f, 247.2409f),
            new Vector4(-88.42611f, 889.886f, 236.1728f, 212.5896f),
            new Vector4(56.37422f, 1050.121f, 218.6296f, 295.7127f),
            new Vector4(-449.0672f, 1062.479f, 327.6815f, 175.8242f),
            new Vector4(-399.2907f, 1148.496f, 325.853f, 200.4087f),
            new Vector4(-480.5667f, 1133.815f, 320.0966f, 190.5652f),
            new Vector4(-294.9129f, 1429.549f, 339.3169f, 336.8831f),
            new Vector4(-407.2495f, 1581.665f, 353.7131f, 73.89459f),
            new Vector4(-149.5202f, 1453.246f, 292.8072f, 199.7669f),
            new Vector4(-266.3375f, 1547.674f, 336.4588f, 141.5186f),
            new Vector4(779.201f, 1187.419f, 325.5869f, 66.41692f),
            new Vector4(307.273f, 1108.102f, 216.9276f, 75.9652f),
            new Vector4(276.0082f, 1187.72f, 226.0305f, 14.18411f),
            new Vector4(191.0497f, 1224.417f, 225.5948f, 106.2378f),
            new Vector4(294.2169f, 953.3748f, 208.6888f, 254.3083f),
            new Vector4(229.4137f, 675.6113f, 189.6827f, 210.8005f),
            new Vector4(221.4684f, 513.708f, 140.7564f, 359.1328f),
            new Vector4(218.7429f, 302.6817f, 105.5856f, 248.4243f),
            new Vector4(336.653f, 312.7571f, 104.6787f, 170.513f),
            new Vector4(127.0963f, 341.097f, 111.944f, 32.08784f),
            new Vector4(2824.941f, -743.6797f, 1.471339f, 16.6061f),
            new Vector4(2835.425f, -626.2703f, 1.730462f, 227.3414f),
            new Vector4(2575.149f, -289.9889f, 93.07821f, 324.0676f),
            new Vector4(2521.409f, -414.0672f, 94.12376f, 222.7773f),
            new Vector4(2571.536f, 304.6294f, 108.6065f, 20.04023f),
            new Vector4(2572.306f, 478.2309f, 108.6772f, 91.36018f),
            new Vector4(2746.039f, 1453.321f, 24.48774f, 299.1059f),
            new Vector4(2757.865f, 1528.199f, 32.49879f, 87.19512f),
            new Vector4(2666.189f, 1508.934f, 24.50084f, 299.6714f),
            new Vector4(2853.234f, 1474.861f, 24.61952f, 107.3717f),
            new Vector4(2720.579f, 1647.611f, 24.57493f, 269.4894f),
            new Vector4(2473.841f, 1572.31f, 32.72038f, 354.3351f),
            new Vector4(2357.949f, 1845.58f, 101.2663f, 166.731f),
            new Vector4(2319.202f, 2551.041f, 47.69345f, 227.7995f),
            new Vector4(2526.939f, 2584.094f, 37.94465f, 8.938714f),
            new Vector4(2595.807f, 2801.963f, 34.00152f, 323.103f),
            new Vector4(2739.255f, 2782.027f, 35.73802f, 303.735f),
            new Vector4(2570.977f, 2720.95f, 42.9959f, 209.3307f),
            new Vector4(-2956.631f, 11.69463f, 6.931808f, 156.18f),
            new Vector4(-2876.279f, 21.03024f, 11.60808f, 41.72112f),
            new Vector4(-3012.55f, -51.12709f, 0.310649f, 38.1624f),
            new Vector4(-3038.164f, 38.733f, 8.971894f, 41.44547f),
            new Vector4(-3096.169f, 119.0552f, 6.728017f, 87.99979f),
            new Vector4(-3091.035f, 352.2566f, 7.519391f, 67.82193f),
            new Vector4(-3075.979f, 447.3828f, 6.362554f, 50.79964f),
            new Vector4(-2964.959f, 452.5694f, 15.30891f, 148.5125f),
            new Vector4(-3057.164f, 532.517f, 7.604911f, 255.576f),
            new Vector4(-3047.145f, 614.4224f, 7.323409f, 264.085f),
            new Vector4(-2982.056f, 719.5752f, 28.49753f, 22.28972f),
            new Vector4(-3165.79f, 762.5814f, 3.421354f, 180.3855f),
            new Vector4(-3237.243f, 914.8962f, 16.88076f, 110.9341f),
            new Vector4(-3295.146f, 984.6699f, 2.889409f, 0.8584108f),
            new Vector4(-3353.275f, 1037.395f, -0.4267793f, 0.1203664f),
            new Vector4(-3270.502f, 1210.821f, 2.343407f, 180.0034f),
            new Vector4(-3264.688f, 1110.545f, 2.304754f, 320.7578f),
            new Vector4(-3187.552f, 1221.516f, 9.986886f, 167.8331f),
            new Vector4(-2542.358f, 2317.119f, 33.21531f, 63.28617f),
            new Vector4(-1955.376f, 2367.43f, 32.54905f, 161.8323f),
            new Vector4(-1841.089f, 2195.876f, 97.38118f, 304.6146f),
            new Vector4(-1837.205f, 2270.878f, 73.74523f, 312.3881f),
            new Vector4(-1895.852f, 2143.426f, 121.225f, 65.59644f),
            new Vector4(-1859.108f, 2072.094f, 140.9959f, 129.7641f),
            new Vector4(-1790.499f, 2119.865f, 132.356f, 90.9618f),
            new Vector4(-1916.931f, 1944.778f, 158.3994f, 296.9663f),
            new Vector4(-1701.855f, 1957.936f, 131.0938f, 56.90914f),
            new Vector4(-1721.216f, 2029.074f, 112.8439f, 156.9609f),
            new Vector4(-1097.618f, 2700.906f, 18.90455f, 84.88656f),
            new Vector4(-328.0197f, 2825.509f, 58.02246f, 111.1101f),
            new Vector4(181.3483f, 2793.319f, 45.6552f, 24.21892f),
            new Vector4(331.855f, 2873.202f, 43.45045f, 156.6868f),
            new Vector4(361.1784f, 2976.71f, 40.4106f, 122.3371f),
            new Vector4(282.1306f, 2568.33f, 45.2464f, 241.7109f),
            new Vector4(203.8961f, 2702.276f, 42.54163f, 175.5621f),
            new Vector4(391.2553f, 2633.707f, 44.6586f, 32.33579f),
            new Vector4(470.7168f, 2610.214f, 42.72048f, 9.760907f),
            new Vector4(586.6243f, 2742.652f, 42.07542f, 275.8898f),
            new Vector4(754.2651f, 2783.679f, 66.97653f, 216.7942f),
            new Vector4(848.8434f, 2382.375f, 54.18682f, 285.6466f),
            new Vector4(914.1945f, 2294.065f, 48.86418f, 187.3512f),
            new Vector4(980.6591f, 2667.654f, 40.06087f, 354.2927f),
            new Vector4(1182.588f, 2701.389f, 38.15746f, 236.7878f),
            new Vector4(1116.655f, 2641.605f, 38.14867f, 2.974739f),
            new Vector4(1777.552f, 3325.553f, 41.43348f, 345.9209f),
            new Vector4(1832.452f, 3443.146f, 41.04421f, 354.7577f),
            new Vector4(1964.699f, 3257.751f, 45.65916f, 168.9078f),
            new Vector4(1987.721f, 3047.302f, 46.74506f, 237.7831f),
            new Vector4(2370.224f, 3156.767f, 48.20884f, 39.61424f),
            new Vector4(2343.113f, 3046.043f, 48.15176f, 273.6578f),
            new Vector4(2398.234f, 3315.428f, 47.70992f, 282.5903f),
            new Vector4(2164.31f, 3396.292f, 45.43284f, 295.356f),
            new Vector4(2259.422f, 3437.281f, 64.76982f, 128.1591f),
            new Vector4(2179.717f, 3498.747f, 45.46162f, 354.1017f),
            new Vector4(2062.606f, 3452.479f, 43.75446f, 37.58577f),
            new Vector4(2486.352f, 3760.736f, 42.24755f, 176.6024f),
            new Vector4(2616.738f, 3665.922f, 102.1075f, 62.15446f),
            new Vector4(2418.972f, 4019.551f, 36.7912f, 209.7724f),
            new Vector4(2483.769f, 4102.82f, 38.12365f, 182.0906f),
            new Vector4(2565.83f, 4244.567f, 41.4447f, 328.7588f),
            new Vector4(2702.66f, 4330.201f, 45.85205f, 10.36979f),
            new Vector4(2904.14f, 4593.71f, 48.02999f, 80.57688f),
            new Vector4(2859.294f, 4663.227f, 47.93969f, 195.7032f),
            new Vector4(2227.497f, 4790.701f, 40.40303f, 345.2054f),
            new Vector4(1684.557f, 4817.428f, 42.01131f, 117.5796f),
            new Vector4(1668.184f, 4897.533f, 42.05532f, 203.0841f),
            new Vector4(1717.725f, 4677.343f, 43.65575f, 290.9685f),
            new Vector4(1428.173f, 4379.375f, 44.27631f, 216.4638f),
            new Vector4(1370.321f, 4317.032f, 38.06339f, 42.11711f),
            new Vector4(1240.904f, 4350.808f, 34.24231f, 94.9155f),
            new Vector4(-271.7308f, 6400.089f, 31.30641f, 222.9104f),
            new Vector4(-335.076f, 6493.833f, 2.34665f, 119.0187f),
            new Vector4(-401.1573f, 6383.861f, 14.14575f, 136.2842f),
            new Vector4(-640.2075f, 6236.555f, 2.976151f, 172.2602f),
            new Vector4(-437.9801f, 6272.952f, 30.06834f, 249.4151f),
            new Vector4(-661.4758f, 6157.757f, 2.040393f, 141.1119f),
            new Vector4(-703.632f, 5802.625f, 17.31226f, 352.4189f),
            new Vector4(-739.5485f, 5602.697f, 41.65934f, 180.9679f),
            new Vector4(-594.1973f, 5364.056f, 70.43559f, 20.45568f),
            new Vector4(-630.548f, 5208.631f, 83.00797f, 80.07411f),
            new Vector4(-468.9976f, 5358.746f, 80.79279f, 4.032477f),
            new Vector4(-514.1689f, 5266.845f, 80.48373f, 212.6361f),
            new Vector4(-455.2321f, 6008.505f, 31.48877f, 260.9404f),
            new Vector4(-379.7126f, 6033.835f, 31.49892f, 100.5203f),
            new Vector4(-321.3374f, 6232.379f, 31.52865f, 281.4824f),
            new Vector4(-416.6474f, 6137.146f, 31.53211f, 227.9525f),
            new Vector4(-249.6663f, 6067.666f, 31.37034f, 140.0739f),
            new Vector4(-246.1973f, 6155.588f, 31.42052f, 184.0397f),
            new Vector4(-250.0735f, 6271.455f, 31.43178f, 146.0887f),
            new Vector4(-182.6544f, 6334.627f, 31.4791f, 137.9106f),
            new Vector4(-152.0446f, 6259.825f, 31.48942f, 321.7107f),
            new Vector4(-68.66537f, 6270.102f, 31.33991f, 153.4193f),
            new Vector4(-70.80379f, 6437.074f, 31.63992f, 149.3367f),
            new Vector4(-168.8526f, 6436.67f, 31.9113f, 33.98012f),
            new Vector4(-106.8976f, 6533.95f, 29.83228f, 22.53628f),
            new Vector4(-17.19193f, 6502.194f, 31.50745f, 277.7401f),
            new Vector4(107.219f, 6612.1f, 31.97963f, 176.6421f),
            new Vector4(155.6443f, 6508.133f, 31.7202f, 50.47895f),
            new Vector4(-97.19097f, 6350.258f, 31.58107f, 227.7804f),
            new Vector4(291.5666f, 6515.816f, 29.77631f, 240.3053f),
            new Vector4(381.5781f, 6526.341f, 28.18776f, 297.2371f),
            new Vector4(509.6346f, 6512.681f, 29.83138f, 358.1497f),
            new Vector4(1087.457f, 6511.739f, 20.55505f, 184.4623f),
            new Vector4(1300.798f, 6609.131f, 2.210964f, 166.6302f),
            new Vector4(1427.748f, 6551.687f, 15.48245f, 259.8033f),
            new Vector4(1581.274f, 6453.915f, 25.31938f, 146.6987f),
            new Vector4(1691.058f, 6427.246f, 32.54766f, 235.5572f),
            new Vector4(488.016f, 5586.718f, 794.0623f, 207.1104f),
            new Vector4(709.0751f, 4184.547f, 40.70778f, 34.69099f),
            new Vector4(713.3973f, 4092.791f, 34.72971f, 183.6691f),
            new Vector4(-18.10457f, 3768.18f, 31.31539f, 0.0f),
            new Vector4(396.4519f, 3578.591f, 33.29235f, 292.9981f),
            new Vector4(915.2141f, 3565.18f, 33.80116f, 296.1426f),
            new Vector4(915.4491f, 3643.504f, 32.65174f, 224.7724f),
            new Vector4(1361.951f, 3603.041f, 34.94891f, 248.2975f),
            new Vector4(1261.829f, 3548.285f, 34.62054f, 191.3703f),
            new Vector4(1229.425f, 3622.139f, 33.48791f, 194.691f),
            new Vector4(1431.933f, 3669.91f, 39.73352f, 21.39104f),
            new Vector4(1553.329f, 3801.798f, 34.25249f, 349.7805f),
            new Vector4(1691.517f, 3866.717f, 34.91164f, 110.7219f),
            new Vector4(1544.495f, 3722.99f, 34.59937f, 213.8932f),
            new Vector4(1795.776f, 3949.233f, 33.90714f, 275.9398f),
            new Vector4(1829.368f, 3833.267f, 33.35374f, 28.27547f),
            new Vector4(1904.727f, 3708.882f, 32.73225f, 290.9872f),
            new Vector4(1950.306f, 3845.622f, 32.18547f, 249.8298f),
            new Vector4(1985.265f, 3705.139f, 32.3974f, 332.6318f),
            new Vector4(2016.912f, 3773.148f, 32.20602f, 265.4035f),
            new Vector4(1825.867f, 3656.211f, 34.08326f, 253.2209f),
            new Vector4(1741.156f, 3710.271f, 34.1827f, 21.51038f),
            new Vector4(1632.203f, 3597.311f, 35.43903f, 211.6864f)
        };
        public static readonly List<Vector4> VhPoint = new List<Vector4>
        {
            new Vector4(1171.216f, -3098.73f, 5.368239f, 327.4246f),
            new Vector4(1164.484f, -3284.133f, 5.767469f, 359.8402f),
            new Vector4(1163.16f, -3253.975f, 5.567095f, 359.9801f),
            new Vector4(1128.764f, -3111.844f, 5.297089f, 90.09441f),
            new Vector4(1163.167f, -3219.17f, 5.557682f, 359.771f),
            new Vector4(1080.021f, -3092.358f, 5.3848f, 1.743847f),
            new Vector4(888.5657f, -3088.555f, 5.351525f, 315.2636f),
            new Vector4(914.8222f, -2953.489f, 6.100373f, 90.01085f),
            new Vector4(877.3307f, -3145.897f, 6.198364f, 156.4918f),
            new Vector4(801.0027f, -3167.345f, 5.526441f, 58.94756f),
            new Vector4(724.2718f, -3043.11f, 11.00597f, 175.3053f),
            new Vector4(761.4911f, -3005.259f, 5.160277f, 40.35048f),
            new Vector4(763.3686f, -3088.452f, 5.807722f, 356.68f),
            new Vector4(850.6256f, -3161.475f, 6.199687f, 93.73587f),
            new Vector4(808.5379f, -3321.443f, 14.75131f, 260.9731f),
            new Vector4(723.0933f, -3263.661f, 18.82045f, 205.3093f),
            new Vector4(744.0039f, -3111.426f, 6.172045f, 281.1273f),
            new Vector4(715.2537f, -3194.005f, 18.9327f, 180.1587f),
            new Vector4(780.2213f, -3134.218f, 5.540443f, 0.5188138f),
            new Vector4(770.0416f, -3312.969f, 17.17489f, 239.6496f),
            new Vector4(743.3619f, -2923.446f, 5.345036f, 0.9181983f),
            new Vector4(713.4546f, -2935.221f, 5.642299f, 178.9793f),
            new Vector4(671.8362f, -2829.776f, 5.889715f, 0.3156565f),
            new Vector4(742.3789f, -2860.765f, 5.611738f, 0.3380838f),
            new Vector4(728.5939f, -2823.553f, 6.507034f, 181.1793f),
            new Vector4(727.659f, -2744.424f, 6.18889f, 180.0377f),
            new Vector4(588.9675f, -2658.291f, 42.23003f, 100.2061f),
            new Vector4(672.2126f, -2799.741f, 5.706572f, 356.8794f),
            new Vector4(741.4243f, -2794.473f, 5.895126f, 0.2870225f),
            new Vector4(643.5969f, -2663.333f, 46.93395f, 282.8148f),
            new Vector4(555.3238f, -2677.796f, 38.85979f, 280.2316f),
            new Vector4(567.3817f, -2949.782f, 5.55663f, 269.9882f),
            new Vector4(180.4951f, -2664.218f, 18.33892f, 264.3251f),
            new Vector4(147.0338f, -2659.699f, 19.183f, 260.3914f),
            new Vector4(247.5086f, -2654.068f, 18.46486f, 89.88707f),
            new Vector4(99.31685f, -2639.914f, 20.86331f, 75.63136f),
            new Vector4(218.9233f, -2545.032f, 6.224019f, 98.985f),
            new Vector4(330.7603f, -2506.329f, 5.759934f, 101.2405f),
            new Vector4(177.4738f, -2562.87f, 5.921941f, 127.2502f),
            new Vector4(331.2676f, -2450.687f, 6.89115f, 158.8575f),
            new Vector4(390.312f, -2500.931f, 10.16538f, 91.82946f),
            new Vector4(252.4204f, -2543.684f, 6.110068f, 285.9441f),
            new Vector4(442.4916f, -2472.618f, 7.598723f, 33.18981f),
            new Vector4(510.9831f, -2500.758f, 15.56171f, 89.82838f),
            new Vector4(419.7526f, -2617.708f, 12.70292f, 90.06454f),
            new Vector4(388.9032f, -2617.682f, 12.43392f, 89.56305f),
            new Vector4(346.8639f, -2393.654f, 10.24919f, 178.3397f),
            new Vector4(284.1289f, -2523.301f, 5.988084f, 116.591f),
            new Vector4(421.3186f, -2500.223f, 14.21807f, 90.53958f),
            new Vector4(591.7843f, -2505.18f, 16.61795f, 270.2827f),
            new Vector4(480.6521f, -2500.755f, 15.06837f, 89.84077f),
            new Vector4(538.5758f, -2538.722f, 5.954999f, 57.39911f),
            new Vector4(626.196f, -2502.615f, 17.10596f, 276.5247f),
            new Vector4(912.4196f, -2457.71f, 28.65146f, 82.85508f),
            new Vector4(874.7397f, -2458.88f, 28.80325f, 262.9244f),
            new Vector4(727.8044f, -2430.849f, 20.14322f, 175.4162f),
            new Vector4(733.4936f, -2496.238f, 19.85888f, 1.287777f),
            new Vector4(772.3978f, -2458.038f, 20.57759f, 296.1097f),
            new Vector4(703.0165f, -2486.858f, 20.29158f, 291.793f),
            new Vector4(760.1448f, -2407.999f, 20.39512f, 355.2457f),
            new Vector4(733.8709f, -2568.756f, 19.35054f, 0.363411f),
            new Vector4(1009.919f, -2583.799f, 42.15023f, 99.58331f),
            new Vector4(1149.597f, -2551.388f, 33.28194f, 104.7849f),
            new Vector4(1064.049f, -2570.099f, 35.66734f, 100.2386f),
            new Vector4(1039.651f, -2396.715f, 29.89671f, 354.5434f),
            new Vector4(947.1188f, -2461.03f, 28.52306f, 85.72625f),
            new Vector4(1104.586f, -2579.771f, 31.71419f, 283.0798f),
            new Vector4(971.5063f, -2591.317f, 45.53347f, 100.2589f),
            new Vector4(1208.405f, -2537.82f, 37.94005f, 110.9535f),
            new Vector4(1377.747f, -2570.984f, 48.36106f, 100.3968f),
            new Vector4(1302.164f, -2459.057f, 48.11634f, 149.3266f),
            new Vector4(1281.003f, -2505.836f, 44.45955f, 314.3672f),
            new Vector4(1238.531f, -2522.655f, 40.99676f, 122.933f),
            new Vector4(1650.641f, -2524.091f, 75.22089f, 312.3635f),
            new Vector4(1689.156f, -2350.96f, 100.4612f, 152.0679f),
            new Vector4(1554.982f, -2255.55f, 82.36553f, 348.8223f),
            new Vector4(1703.449f, -2079.236f, 106.7722f, 155.7724f),
            new Vector4(1409.747f, -1962.825f, 63.89637f, 324.0725f),
            new Vector4(1378.852f, -1997.414f, 55.54765f, 311.9565f),
            new Vector4(1334.523f, -2008.157f, 49.19751f, 120.0823f),
            new Vector4(1433.692f, -1861.468f, 71.0359f, 357.0322f),
            new Vector4(1209.498f, -2001.754f, 43.0316f, 203.544f),
            new Vector4(1067.36f, -2094.143f, 32.81308f, 0.5456085f),
            new Vector4(1242.406f, -2105.172f, 45.416f, 200.2486f),
            new Vector4(1088.797f, -2069.628f, 35.38772f, 88.3737f),
            new Vector4(1231.678f, -2073.036f, 44.36795f, 200.8148f),
            new Vector4(1188.403f, -1967.078f, 40.65069f, 206.7372f),
            new Vector4(1228.718f, -2032.375f, 44.29909f, 203.5457f),
            new Vector4(920.144f, -2229.32f, 29.88178f, 354.9791f),
            new Vector4(779.1176f, -2133.441f, 29.1486f, 355.3622f),
            new Vector4(780.6519f, -2170.711f, 28.76998f, 353.9665f),
            new Vector4(777.4568f, -2207.185f, 28.77109f, 355.1785f),
            new Vector4(787.5181f, -2092.988f, 28.79393f, 354.3103f),
            new Vector4(774.262f, -2254.255f, 29.20016f, 355.2295f),
            new Vector4(739.6433f, -2067.341f, 29.24404f, 263.5246f),
            new Vector4(746.2582f, -2281.767f, 28.69206f, 175.3277f),
            new Vector4(767.4335f, -2005.428f, 28.75797f, 171.4757f),
            new Vector4(859.0829f, -2067.465f, 29.58775f, 82.96251f),
            new Vector4(947.3076f, -1865.224f, 31.06941f, 172.8275f),
            new Vector4(977.3386f, -1920.484f, 31.0523f, 254.0058f),
            new Vector4(1062.178f, -1734.428f, 35.15527f, 197.1599f),
            new Vector4(973.1912f, -1757.673f, 31.21098f, 85.08828f),
            new Vector4(937.7255f, -1765.045f, 31.1377f, 264.2594f),
            new Vector4(1091.558f, -1746.434f, 29.35876f, 198.6068f),
            new Vector4(1094.266f, -1821.214f, 36.59525f, 199.4832f),
            new Vector4(907.2383f, -1762.99f, 30.12536f, 264.6816f),
            new Vector4(850.3331f, -1633.293f, 30.61901f, 355.3171f),
            new Vector4(847.2507f, -1591.099f, 31.18837f, 4.367808f),
            new Vector4(821.7007f, -1723.386f, 28.82722f, 172.6679f),
            new Vector4(839.6514f, -1557.682f, 29.75682f, 17.45436f),
            new Vector4(733.0289f, -1346.555f, 39.42349f, 78.70354f),
            new Vector4(789.8036f, -1417.975f, 27.07444f, 180.4982f),
            new Vector4(815.1374f, -1524.568f, 28.98868f, 201.8198f),
            new Vector4(697.8835f, -1432.882f, 30.81415f, 89.95821f),
            new Vector4(811.7384f, -1445.232f, 26.7659f, 269.0989f),
            new Vector4(767.3574f, -1440.145f, 27.1608f, 270.4227f),
            new Vector4(804.3124f, -1348.631f, 40.00214f, 92.72272f),
            new Vector4(903.2299f, -1428.787f, 30.45287f, 89.3696f),
            new Vector4(891.2338f, -1217.553f, 42.85295f, 273.7095f),
            new Vector4(794.9196f, -1163.744f, 28.33584f, 2.005605f),
            new Vector4(982.176f, -1209.513f, 43.34753f, 287.1641f),
            new Vector4(956.6098f, -1226.514f, 42.3091f, 253.312f),
            new Vector4(969.8748f, -1181.482f, 51.59652f, 92.14094f),
            new Vector4(807.9194f, -1255.944f, 25.83256f, 356.8885f),
            new Vector4(941.6535f, -1153.866f, 39.56073f, 114.639f),
            new Vector4(791.6236f, -1221.49f, 45.47538f, 272.1067f),
            new Vector4(813.2012f, -1188.184f, 45.61077f, 92.41901f),
            new Vector4(744.456f, -1233.156f, 44.53249f, 299.3872f),
            new Vector4(791.6149f, -1132.244f, 28.56597f, 185.5589f),
            new Vector4(777.5609f, -1240.171f, 26.18651f, 272.7844f),
            new Vector4(828.4811f, -1140.236f, 28.99805f, 115.1843f),
            new Vector4(773.9606f, -1189.08f, 44.83276f, 91.59617f),
            new Vector4(921.3309f, -1200.406f, 47.92486f, 272.4194f),
            new Vector4(790.976f, -1288.597f, 26.18504f, 178.2265f),
            new Vector4(760.8929f, -1008.245f, 25.57243f, 274.5952f),
            new Vector4(803.1144f, -1044.503f, 41.39673f, 270.8797f),
            new Vector4(816.7121f, -1001.46f, 26.092f, 92.05911f),
            new Vector4(976.4799f, -999.51f, 41.13237f, 269.7766f),
            new Vector4(860.5325f, -1103.961f, 34.81452f, 171.2013f),
            new Vector4(788.5445f, -1100.158f, 28.42763f, 173.4881f),
            new Vector4(757.2133f, -1045.976f, 24.93712f, 269.5891f),
            new Vector4(859.593f, -761.2621f, 36.95139f, 215.3654f),
            new Vector4(913.09f, -779.9232f, 39.20697f, 220.0761f),
            new Vector4(781.9472f, -843.881f, 42.83506f, 89.95698f),
            new Vector4(688.3677f, -858.6276f, 43.1311f, 269.962f),
            new Vector4(874.7583f, -835.965f, 42.72097f, 97.12729f),
            new Vector4(900.6087f, -851.3497f, 43.4015f, 271.1537f),
            new Vector4(778.3138f, -731.1815f, 27.79232f, 0.07856689f),
            new Vector4(752.7659f, -858.6683f, 42.79988f, 269.9941f),
            new Vector4(814.4739f, -853.3607f, 43.48027f, 273.3114f),
            new Vector4(957.6394f, -823.3396f, 35.0155f, 212.9859f),
            new Vector4(990.5745f, -871.0651f, 30.99212f, 205.0655f),
            new Vector4(945.5461f, -767.9762f, 38.62864f, 39.5045f),
            new Vector4(997.8499f, -812.2778f, 48.02996f, 263.9888f),
            new Vector4(1015.749f, -954.8322f, 29.95236f, 196.7078f),
            new Vector4(1026.517f, -843.1522f, 48.00001f, 251.0663f),
            new Vector4(1008.948f, -916.0352f, 29.97203f, 200.6173f),
            new Vector4(943.1943f, -870.1537f, 43.2397f, 208.8142f),
            new Vector4(1051.166f, -957.6436f, 29.98598f, 15.61433f),
            new Vector4(1058.68f, -1031.177f, 28.36871f, 11.48553f),
            new Vector4(939.1163f, -995.0575f, 38.47545f, 92.85887f),
            new Vector4(998.7762f, -1021.315f, 41.73297f, 2.0927f),
            new Vector4(1043.808f, -1133.756f, 25.35915f, 178.3668f),
            new Vector4(1111.11f, -959.5657f, 46.49983f, 283.011f),
            new Vector4(1025.168f, -1072.434f, 36.60898f, 186.7815f),
            new Vector4(1043.232f, -990.8149f, 29.51513f, 15.71502f),
            new Vector4(1064.012f, -1068.065f, 26.39417f, 9.525152f),
            new Vector4(1107.982f, -1104.505f, 42.52697f, 36.81648f),
            new Vector4(1073.254f, -1105.897f, 42.4936f, 343.7805f),
            new Vector4(1067.871f, -1244.53f, 24.98396f, 2.386145f),
            new Vector4(1227.712f, -1177.237f, 36.62162f, 197.9092f),
            new Vector4(1084.184f, -1337.862f, 33.97547f, 3.087507f),
            new Vector4(1049.554f, -1295.052f, 25.98814f, 182.4817f),
            new Vector4(1164.984f, -1165.793f, 52.28354f, 98.65244f),
            new Vector4(1136.205f, -1174.251f, 53.89987f, 94.6117f),
            new Vector4(1121.452f, -1196.17f, 37.72921f, 249.0739f),
            new Vector4(1119.969f, -1251.682f, 38.80408f, 320.2994f),
            new Vector4(1045.205f, -1189.522f, 25.3514f, 182.0232f),
            new Vector4(1065.813f, -1160.616f, 24.99451f, 1.556337f),
            new Vector4(1043.074f, -1162.474f, 46.45432f, 316.3912f),
            new Vector4(1026.323f, -1196.194f, 55.3175f, 271.8785f),
            new Vector4(1237.831f, -1224.23f, 35.04412f, 187.3785f),
            new Vector4(1208.428f, -1146.606f, 47.20683f, 107.7434f),
            new Vector4(1077.603f, -1188.906f, 55.31006f, 272.3836f),
            new Vector4(1102.089f, -1277.97f, 37.79743f, 335.1097f),
            new Vector4(1168.5f, -1216.409f, 40.83168f, 293.8914f),
            new Vector4(1044.71f, -1245.412f, 44.22082f, 159.5011f),
            new Vector4(1140.241f, -1442.978f, 34.4943f, 269.9465f),
            new Vector4(1250.088f, -1282.031f, 34.69902f, 355.0325f),
            new Vector4(1244.668f, -1393.075f, 35.18659f, 15.31663f),
            new Vector4(1231.221f, -1347.724f, 34.96836f, 174.6513f),
            new Vector4(1256.568f, -1459.018f, 34.73781f, 203.1569f),
            new Vector4(1193.975f, -1439.265f, 35.1361f, 270.9886f),
            new Vector4(1244.048f, -1423.489f, 34.62576f, 197.1822f),
            new Vector4(1319.019f, -1624.484f, 51.84851f, 119.9758f),
            new Vector4(1274.443f, -1515.859f, 41.63277f, 197.8692f),
            new Vector4(1315.932f, -1590.207f, 52.21322f, 220.0553f),
            new Vector4(1163.598f, -1781.776f, 36.51003f, 19.53511f),
            new Vector4(1280.809f, -1651.315f, 49.05788f, 124.5177f),
            new Vector4(1153.447f, -1710.68f, 35.61198f, 111.2809f),
            new Vector4(1391.572f, -1773.192f, 65.51181f, 283.8078f),
            new Vector4(1353.792f, -1629.653f, 52.37382f, 37.0051f),
            new Vector4(1381.769f, -1668.916f, 57.59248f, 31.98674f),
            new Vector4(1411.83f, -1721.89f, 65.55905f, 17.10764f),
            new Vector4(1432.525f, -1809.802f, 68.09846f, 7.836211f),
            new Vector4(1808.761f, -1658.269f, 117.2735f, 162.9439f),
            new Vector4(1814.697f, -1510.207f, 116.8188f, 348.6596f),
            new Vector4(1909.286f, -1285.179f, 129.8719f, 9.5233f),
            new Vector4(1818.711f, -1462.051f, 120.3191f, 349.7572f),
            new Vector4(1903.898f, -1237.118f, 121.8223f, 357.7171f),
            new Vector4(1964.35f, -1047.333f, 90.68951f, 325.7014f),
            new Vector4(1944.667f, -940.7015f, 79.13421f, 307.278f),
            new Vector4(1973.46f, -922.1251f, 78.58881f, 68.6583f),
            new Vector4(1815.937f, -834.9902f, 75.02666f, 306.5281f),
            new Vector4(1757.727f, -879.2356f, 70.54249f, 305.7904f),
            new Vector4(1696.683f, -902.873f, 66.96306f, 123.3592f),
            new Vector4(1862.391f, -783.1428f, 80.48514f, 127.5441f),
            new Vector4(1591.518f, -967.103f, 60.70185f, 119.7468f),
            new Vector4(1565.59f, -992.6816f, 59.23853f, 300.8576f),
            new Vector4(1638.905f, -939.1395f, 63.53382f, 121.1931f),
            new Vector4(1534.04f, -1016.611f, 58.06668f, 299.2359f),
            new Vector4(1488.986f, -969.5565f, 64.92713f, 274.2104f),
            new Vector4(1524.043f, -961.699f, 66.73236f, 292.513f),
            new Vector4(1425.767f, -1076.806f, 53.68893f, 298.6379f),
            new Vector4(1502.55f, -1017.152f, 56.83007f, 119.1952f),
            new Vector4(1378.797f, -1102.034f, 52.70111f, 297.348f),
            new Vector4(1319.399f, -1133.722f, 51.75734f, 297.4081f),
            new Vector4(1458.448f, -1053.344f, 55.27607f, 299.0876f),
            new Vector4(1196.797f, -1116.697f, 38.07566f, 212.8566f),
            new Vector4(1169.375f, -1001.083f, 44.60685f, 7.406498f),
            new Vector4(1191.727f, -1180.265f, 51.28639f, 280.874f),
            new Vector4(1043.649f, -1102.663f, 24.97585f, 180.5249f),
            new Vector4(1162.21f, -1042.876f, 42.70849f, 196.9475f),
            new Vector4(859.0984f, -1197.914f, 45.36811f, 272.4363f),
            new Vector4(581.2803f, -1196.428f, 41.47665f, 90.4827f),
            new Vector4(705.4418f, -1187.338f, 43.71143f, 92.35767f),
            new Vector4(530.9454f, -1225.699f, 42.12867f, 272.2806f),
            new Vector4(696.0022f, -1271.666f, 42.64473f, 348.6436f),
            new Vector4(637.726f, -1210.113f, 41.30007f, 278.9502f),
            new Vector4(715.8566f, -1219.651f, 44.25269f, 272.4481f),
            new Vector4(616.5186f, -1178.878f, 40.92385f, 91.67727f),
            new Vector4(651.5791f, -1247.306f, 41.62545f, 263.5197f),
            new Vector4(383.1699f, -1186.088f, 39.25177f, 88.54337f),
            new Vector4(375.3206f, -1221.834f, 39.39338f, 272.5167f),
            new Vector4(468.925f, -1227.492f, 41.41846f, 270.4229f),
            new Vector4(328.3448f, -1319.663f, 31.46466f, 235.8662f),
            new Vector4(335.3448f, -1190.445f, 38.09117f, 89.09748f),
            new Vector4(499.5327f, -1263.753f, 29.42657f, 180.0478f),
            new Vector4(300.2407f, -1218.569f, 37.72556f, 269.843f),
            new Vector4(396.0754f, -1387.057f, 29.53429f, 226.7666f),
            new Vector4(432.6113f, -1409.715f, 28.85972f, 229.6788f),
            new Vector4(198.3447f, -1418.795f, 28.87905f, 67.38634f),
            new Vector4(182.3867f, -1217.798f, 37.68626f, 269.2535f),
            new Vector4(111.7981f, -1371.615f, 29.44617f, 247.073f),
            new Vector4(124.3961f, -1410.042f, 28.90876f, 162.1168f),
            new Vector4(164.6155f, -1372.038f, 29.14255f, 139.5021f),
            new Vector4(214.6536f, -1230.697f, 28.95231f, 183.377f),
            new Vector4(217.4902f, -1302.883f, 29.14552f, 342.2236f),
            new Vector4(222.86f, -1440.288f, 28.9649f, 234.8728f),
            new Vector4(190.1861f, -1330.258f, 28.95241f, 157.3246f),
            new Vector4(263.8976f, -1224.136f, 38.39335f, 269.9952f),
            new Vector4(152.1735f, -1228.227f, 37.33804f, 271.908f),
            new Vector4(108.842f, -1446.248f, 28.99165f, 154.938f),
            new Vector4(256.4784f, -1452.756f, 28.72821f, 48.63925f),
            new Vector4(206.4962f, -1571.178f, 28.88577f, 121.0178f),
            new Vector4(250.9126f, -1544.482f, 28.86597f, 119.3488f),
            new Vector4(298.4012f, -1497.122f, 28.99202f, 235.5008f),
            new Vector4(267.9455f, -1408.472f, 29.28293f, 139.8288f),
            new Vector4(299.2586f, -1535.786f, 28.86849f, 298.2629f),
            new Vector4(451.2305f, -1671.371f, 28.76412f, 319.9929f),
            new Vector4(473.8257f, -1599.569f, 28.86732f, 146.343f),
            new Vector4(290.9018f, -1677.243f, 28.84693f, 45.84619f),
            new Vector4(323.0848f, -1515.557f, 29.00266f, 267.2579f),
            new Vector4(372.6551f, -1475.672f, 29.40553f, 111.5468f),
            new Vector4(367.2085f, -1540.267f, 28.85337f, 50.29908f),
            new Vector4(383.1851f, -1580.007f, 28.75977f, 230.0849f),
            new Vector4(469.1425f, -1632.097f, 29.18983f, 48.94229f),
            new Vector4(443.8288f, -1806.721f, 27.64992f, 50.05436f),
            new Vector4(338.0572f, -1800.155f, 27.86342f, 321.3111f),
            new Vector4(491.4007f, -1757.942f, 28.13095f, 162.2004f),
            new Vector4(344.9782f, -1729.484f, 28.98576f, 229.942f),
            new Vector4(373.2214f, -1757.678f, 28.8519f, 320.9243f),
            new Vector4(394.6909f, -1736.213f, 28.88893f, 305.3687f),
            new Vector4(512.7777f, -1711.675f, 29.31829f, 327.107f),
            new Vector4(422.6576f, -1708.496f, 28.8826f, 314.972f),
            new Vector4(413.8333f, -1875.798f, 25.97168f, 133.7456f),
            new Vector4(471.7764f, -2085.906f, 23.06914f, 317.6666f),
            new Vector4(418.3074f, -2005.372f, 22.53056f, 222.0154f),
            new Vector4(498.702f, -2051.951f, 25.53287f, 110.6184f),
            new Vector4(584.7233f, -2053.431f, 29.59415f, 265.0727f),
            new Vector4(548.8487f, -2039.32f, 28.34982f, 85.04793f),
            new Vector4(474.3302f, -2031.88f, 24.0049f, 52.77704f),
            new Vector4(382.6591f, -2153.156f, 15.57926f, 111.2823f),
            new Vector4(305.7954f, -2144.155f, 14.451f, 231.5039f),
            new Vector4(334.969f, -2157.66f, 13.77345f, 249.9748f),
            new Vector4(234.858f, -2079.784f, 17.44658f, 229.5195f),
            new Vector4(379.7092f, -2191.129f, 13.60538f, 322.7939f),
            new Vector4(419.8026f, -2144.656f, 17.78636f, 319.0544f),
            new Vector4(266.1317f, -2116.36f, 15.75474f, 226.1173f),
            new Vector4(152.4328f, -2046.885f, 17.91657f, 266.7517f),
            new Vector4(165.8188f, -1972.435f, 18.21391f, 136.2917f),
            new Vector4(195.9646f, -2044.684f, 17.74071f, 66.94882f),
            new Vector4(77.66934f, -2044.518f, 17.86937f, 269.6667f),
            new Vector4(-131.236f, -2088.478f, 25.38221f, 290.0718f),
            new Vector4(-85.00861f, -2149.29f, 10.21006f, 109.1906f),
            new Vector4(35.86018f, -2045.202f, 17.85784f, 270.1237f),
            new Vector4(-162.6948f, -2093.92f, 24.87264f, 113.8288f),
            new Vector4(-14.15318f, -2036.298f, 18.40751f, 102.0944f),
            new Vector4(-31.46414f, -2136.044f, 9.973511f, 289.7406f),
            new Vector4(-47.472f, -2050.041f, 20.83182f, 109.4214f),
            new Vector4(-40.24047f, -1981.446f, 14.20393f, 247.5513f),
            new Vector4(-284.1851f, -2109.459f, 22.24253f, 64.77628f),
            new Vector4(-251.4017f, -2136.29f, 22.15273f, 267.8498f),
            new Vector4(-210.6464f, -2128.191f, 22.71041f, 292.5909f),
            new Vector4(-353.9225f, -2100.756f, 24.1045f, 249.3349f),
            new Vector4(-259.0896f, -2198.169f, 10.09874f, 250.7639f),
            new Vector4(-316.5679f, -2114.921f, 23.2373f, 249.1318f),
            new Vector4(-400.2964f, -2084.286f, 26.32782f, 249.2669f),
            new Vector4(-375.7576f, -2154.867f, 9.909986f, 274.9894f),
            new Vector4(-562.5331f, -1962.879f, 26.9303f, 81.42194f),
            new Vector4(-562.0114f, -2083.625f, 27.58838f, 266.3357f),
            new Vector4(-457.3788f, -2091.744f, 27.19717f, 265.1136f),
            new Vector4(-573.9484f, -2014.936f, 28.0251f, 255.2479f),
            new Vector4(-505.7379f, -1940.787f, 16.79622f, 317.5548f),
            new Vector4(-464.2305f, -2059.605f, 26.85684f, 247.6267f),
            new Vector4(-525.7502f, -1964.036f, 17.03246f, 322.0649f),
            new Vector4(-501.7325f, -2127.535f, 8.563015f, 53.40635f),
            new Vector4(-527.3175f, -2025.631f, 26.8841f, 239.1957f),
            new Vector4(-530.9657f, -2074.885f, 30.32685f, 265.9076f),
            new Vector4(-467.5145f, -1988.901f, 35.17732f, 32.893f),
            new Vector4(-459.9459f, -2022.878f, 36.76875f, 355.4319f),
            new Vector4(-459.011f, -1922.146f, 21.5161f, 1.320633f),
            new Vector4(-547.395f, -1995.349f, 27.03552f, 56.37074f),
            new Vector4(-352.5653f, -1830.24f, 22.61151f, 272.3451f),
            new Vector4(-409.6635f, -1847.873f, 20.04079f, 303.5484f),
            new Vector4(-476.963f, -1782.419f, 20.48911f, 270.8846f),
            new Vector4(-514.793f, -1815.25f, 21.98166f, 314.1167f),
            new Vector4(-432.4989f, -1881.587f, 18.32945f, 312.6349f),
            new Vector4(-439.1844f, -1610.619f, 39.10212f, 315.5117f),
            new Vector4(-318.4423f, -1590.718f, 21.74628f, 329.088f),
            new Vector4(-392.1342f, -1530.18f, 37.36388f, 339.6503f),
            new Vector4(-288.0781f, -1517.135f, 28.87111f, 163.3284f),
            new Vector4(-385.8019f, -1695.98f, 18.42516f, 149.5786f),
            new Vector4(-418.8782f, -1554.178f, 37.83681f, 336.7158f),
            new Vector4(-300.3f, -1548.187f, 26.04559f, 152.7038f),
            new Vector4(-359.6928f, -1651.063f, 19.04878f, 149.3467f),
            new Vector4(-449.5159f, -1581.097f, 38.85808f, 152.3636f),
            new Vector4(-269.6439f, -1453.408f, 30.92542f, 357.738f),
            new Vector4(-312.9925f, -1441.264f, 30.76749f, 270.3885f),
            new Vector4(-122.9436f, -1380.686f, 29.03335f, 280.8777f),
            new Vector4(-145.6161f, -1517.821f, 33.84818f, 232.5148f),
            new Vector4(-281.8531f, -1397.422f, 30.93503f, 179.5528f),
            new Vector4(-210.6475f, -1412.815f, 30.84524f, 108.893f),
            new Vector4(-198.3662f, -1443.826f, 31.19278f, 29.93162f),
            new Vector4(-281.5495f, -1366.768f, 31.46025f, 179.9994f),
            new Vector4(-104.7652f, -1507.99f, 33.4393f, 137.4134f),
            new Vector4(68.89209f, -1340.365f, 28.93866f, 164.2f),
            new Vector4(19.16805f, -1373.594f, 29.41089f, 278.6675f),
            new Vector4(-99.90739f, -1314.053f, 29.16162f, 188.3357f),
            new Vector4(-73.16882f, -1365.139f, 28.97964f, 90.27843f),
            new Vector4(50.74721f, -1293.593f, 29.09224f, 198.9966f),
            new Vector4(43.2535f, -1493.331f, 28.85343f, 227.8999f),
            new Vector4(-116.718f, -1345.586f, 28.63964f, 158.4214f),
            new Vector4(52.62303f, -1522.538f, 29.31496f, 322.084f),
            new Vector4(76.034f, -1494.106f, 28.72806f, 137.2338f),
            new Vector4(77.03565f, -1650.483f, 29.13714f, 121.5849f),
            new Vector4(-1.859092f, -1563.452f, 29.25339f, 139.5608f),
            new Vector4(24.23444f, -1634.277f, 29.36787f, 49.99225f),
            new Vector4(17.59954f, -1695.795f, 28.89328f, 292.1064f),
            new Vector4(88.6237f, -1688.875f, 28.77124f, 48.46663f),
            new Vector4(47.81152f, -1666.595f, 29.2671f, 7.465752f),
            new Vector4(-25.71696f, -1628.468f, 28.96262f, 256.5802f),
            new Vector4(-31.28967f, -1716.494f, 28.6726f, 292.0962f),
            new Vector4(-136.3304f, -1719.589f, 29.47826f, 105.438f),
            new Vector4(-115.1775f, -1745.266f, 30.04112f, 272.3484f),
            new Vector4(-72.76672f, -1788.152f, 27.70992f, 49.77762f),
            new Vector4(-49.86722f, -1597.878f, 28.99146f, 232.19f),
            new Vector4(-148.2429f, -1747.583f, 30.10153f, 314.3814f),
            new Vector4(-71.67123f, -1679.294f, 28.67731f, 328.0598f),
            new Vector4(-174.4344f, -1692.41f, 32.23392f, 44.47366f),
            new Vector4(-345.2406f, -1623.549f, 19.32813f, 150.1736f),
            new Vector4(-470.3492f, -1612.754f, 38.93472f, 142.141f),
            new Vector4(-477.0906f, -1675.977f, 36.74789f, 311.515f),
            new Vector4(-501.6157f, -1647.665f, 37.39868f, 131.7057f),
            new Vector4(-536.7145f, -1692.814f, 37.04831f, 302.6328f),
            new Vector4(-602.9788f, -1708.085f, 37.00294f, 108.7635f),
            new Vector4(-441.741f, -1771.312f, 20.51024f, 110.1451f),
            new Vector4(-607.27f, -1739.519f, 37.42657f, 287.0839f),
            new Vector4(-594.3844f, -1980.258f, 26.92443f, 235.8796f),
            new Vector4(-716.0905f, -1877.212f, 27.01011f, 211.72f),
            new Vector4(-625.8625f, -1953.575f, 27.00047f, 236.5813f),
            new Vector4(-684.2838f, -1924.715f, 36.52076f, 132.5181f),
            new Vector4(-690.0716f, -1895.151f, 27.07368f, 48.43314f),
            new Vector4(-654.8246f, -1934.321f, 26.9f, 234.8083f),
            new Vector4(-636.171f, -2180.192f, 51.62226f, 235.2488f),
            new Vector4(-746.9826f, -2086.111f, 35.87441f, 55.35458f),
            new Vector4(-721.8977f, -2129.222f, 13.11526f, 139.04f),
            new Vector4(-687.6484f, -2138.444f, 45.30978f, 235.496f),
            new Vector4(-625.9391f, -2031.059f, 16.7784f, 134.5002f),
            new Vector4(-687.2716f, -1983.155f, 35.95723f, 200.8922f),
            new Vector4(-601.8251f, -2198.594f, 54.58227f, 235.1194f),
            new Vector4(-652.5768f, -2046.603f, 26.96284f, 243.1297f),
            new Vector4(-675.5663f, -2077.703f, 15.32603f, 138.4089f),
            new Vector4(-587.4629f, -2045.485f, 23.98375f, 291.4241f),
            new Vector4(-702.7064f, -2027.208f, 23.88134f, 190.2117f),
            new Vector4(-712.468f, -2121.009f, 41.80373f, 235.4402f),
            new Vector4(-679.6199f, -2122.269f, 13.85052f, 313.5142f),
            new Vector4(-559.0136f, -2218.036f, 57.67778f, 54.92293f),
            new Vector4(-674.1468f, -2342.225f, 12.1334f, 318.428f),
            new Vector4(-601.6043f, -2259.099f, 5.779774f, 319.2904f),
            new Vector4(-655.3152f, -2150.857f, 49.18439f, 55.06609f),
            new Vector4(-523.3358f, -2253.534f, 60.30537f, 235.1001f),
            new Vector4(-574.5867f, -2227.868f, 5.527615f, 319.7407f),
            new Vector4(-797.8409f, -2317.416f, 14.33629f, 225.0164f),
            new Vector4(-746.8648f, -2369.347f, 14.39802f, 225.3062f),
            new Vector4(-713.8028f, -2388.028f, 14.13443f, 319.2635f),
            new Vector4(-891.1459f, -2652.301f, 13.32358f, 330.3531f),
            new Vector4(-892.518f, -2444.467f, 13.6427f, 138.9492f),
            new Vector4(-802.632f, -2535.452f, 13.30777f, 330.4482f),
            new Vector4(-852.8323f, -2456.868f, 19.76248f, 56.13327f),
            new Vector4(-845.4466f, -2594.117f, 19.71567f, 329.9059f),
            new Vector4(-812.3865f, -2498.473f, 13.47455f, 343.7493f),
            new Vector4(-941.5242f, -2574.76f, 13.63301f, 237.0129f),
            new Vector4(-1054.848f, -2588.016f, 13.70183f, 149.6951f),
            new Vector4(-1001.796f, -2725.296f, 13.77488f, 241.1624f),
            new Vector4(-1034.516f, -2706.357f, 13.52737f, 239.8293f),
            new Vector4(-1067.502f, -2671.216f, 13.30589f, 210.2433f),
            new Vector4(-932.3508f, -2720.438f, 13.40014f, 306.4721f),
            new Vector4(-959.1829f, -2621.659f, 13.64984f, 149.984f),
            new Vector4(-1074.888f, -2636.419f, 13.67393f, 170.242f),
            new Vector4(-1005.557f, -2462.938f, 20.15081f, 149.8459f),
            new Vector4(-1015.948f, -2510.258f, 13.60405f, 150.1438f),
            new Vector4(-954.4719f, -2372.898f, 20.10357f, 150.2158f),
            new Vector4(-977.3879f, -2453.754f, 13.3508f, 148.391f),
            new Vector4(-828.3807f, -2287.81f, 8.974926f, 225.524f),
            new Vector4(-933.2095f, -2347.369f, -80.44295f, 0.0f),
            new Vector4(-1248.799f, -613.3758f, 26.89397f, 306.5154f),
            new Vector4(-1203.002f, -703.095f, 11.04782f, 295.3179f),
            new Vector4(-1063.012f, -627.8139f, 16.89768f, 299.7274f),
            new Vector4(-1160.298f, -684.6233f, 11.03662f, 299.3488f),
            new Vector4(-1072.118f, -740.3129f, 18.97254f, 126.3368f),
            new Vector4(-1172.716f, -645.118f, 22.9424f, 39.34941f),
            new Vector4(-1077.767f, -599.8237f, 17.43213f, 117.8081f),
            new Vector4(-1102.283f, -745.8152f, 18.94053f, 221.0642f),
            new Vector4(-1115.01f, -706.1617f, 20.4155f, 41.1072f),
            new Vector4(-1105.136f, -626.3965f, 14.43573f, 119.1454f),
            new Vector4(-1037.134f, -608.1852f, 17.93973f, 298.3108f),
            new Vector4(-1137.105f, -634.8263f, 12.25958f, 120.6129f),
            new Vector4(-1316.474f, -743.4609f, 10.5148f, 285.4283f),
            new Vector4(-1206.972f, -613.2319f, 26.1376f, 44.51458f),
            new Vector4(-1260.168f, -567.5265f, 28.84572f, 220.5245f),
            new Vector4(-1237.186f, -714.5491f, 11.00221f, 292.6919f),
            new Vector4(-1281.487f, -736.8297f, 11.05274f, 287.9486f),
            new Vector4(-1434.546f, -469.3383f, 34.23737f, 33.46314f),
            new Vector4(-1331.4f, -471.373f, 33.50391f, 218.3793f),
            new Vector4(-1401.568f, -578.3053f, 30.31568f, 298.4205f),
            new Vector4(-1381.293f, -553.5513f, 29.9073f, 235.2997f),
            new Vector4(-1320.69f, -522.9363f, 32.92892f, 306.0998f),
            new Vector4(-1676.256f, -370.8633f, 48.53935f, 317.3371f),
            new Vector4(-1494.0f, -467.8306f, 35.23071f, 302.4403f),
            new Vector4(-1627.977f, -424.2828f, 39.39505f, 142.2059f),
            new Vector4(-1522.72f, -490.8107f, 35.10546f, 299.7719f),
            new Vector4(-1619.728f, -456.9606f, 37.73842f, 50.29243f),
            new Vector4(-1545.879f, -368.4237f, 44.26472f, 226.9563f),
            new Vector4(-1596.354f, -521.483f, 35.31074f, 128.5656f),
            new Vector4(-1505.838f, -397.7186f, 39.17905f, 227.3091f),
            new Vector4(-1573.553f, -350.5985f, 46.26675f, 152.3275f),
            new Vector4(-1561.771f, -497.5212f, 35.25471f, 124.3172f),
            new Vector4(-1654.698f, -466.0523f, 38.53509f, 317.8508f),
            new Vector4(-1636.338f, -548.1077f, 33.24503f, 127.5978f),
            new Vector4(-1469.733f, -429.3453f, 35.11341f, 234.5478f),
            new Vector4(-1704.043f, -401.2563f, 45.8438f, 321.8137f),
            new Vector4(-1821.227f, -598.5165f, 11.03042f, 230.3852f),
            new Vector4(-1724.699f, -524.6059f, 37.51044f, 230.1808f),
            new Vector4(-1829.514f, -509.1246f, 28.41798f, 236.3204f),
            new Vector4(-1906.873f, -515.3685f, 11.49277f, 50.15551f),
            new Vector4(-1877.199f, -534.2762f, 11.45227f, 50.73415f),
            new Vector4(-1894.352f, -464.8284f, 22.96705f, 235.9508f),
            new Vector4(-1735.833f, -390.566f, 44.98352f, 182.137f),
            new Vector4(-1753.455f, -558.6639f, 36.97381f, 241.4056f),
            new Vector4(-1740.74f, -458.3048f, 41.81542f, 354.656f),
            new Vector4(-1860.558f, -579.2693f, 11.25152f, 221.6484f),
            new Vector4(-1791.003f, -527.6799f, 31.90102f, 56.74361f),
            new Vector4(-2005.02f, -434.6842f, 11.1254f, 50.59244f),
            new Vector4(-2051.918f, -396.0827f, 10.83419f, 52.14117f),
            new Vector4(-1955.543f, -475.5316f, 11.56151f, 50.86115f),
            new Vector4(-2091.851f, -388.2781f, 12.28156f, 242.4931f),
            new Vector4(-2020.679f, -381.2409f, 10.42652f, 71.81129f),
            new Vector4(-1989.099f, -467.0479f, 11.28499f, 230.8647f),
            new Vector4(-2089.885f, -214.7409f, 20.48576f, 310.7848f),
            new Vector4(-2151.599f, -271.3545f, 13.42077f, 154.0622f),
            new Vector4(-2125.352f, -217.7121f, 17.93968f, 132.6695f),
            new Vector4(-1984.592f, -306.9846f, 47.78251f, 58.6669f),
            new Vector4(-2116.872f, -360.2062f, 13.03252f, 67.64803f),
            new Vector4(-2167.441f, -321.3849f, 13.22443f, 167.6305f),
            new Vector4(-2147.74f, -350.1072f, 12.91647f, 74.93874f),
            new Vector4(-1824.446f, -278.424f, 41.91399f, 34.27132f),
            new Vector4(-1903.203f, -202.7385f, 35.84574f, 235.6946f),
            new Vector4(-1870.385f, -213.2984f, 38.21812f, 43.86839f),
            new Vector4(-1786.282f, -320.8577f, 44.14938f, 51.07925f),
            new Vector4(-1942.339f, -189.4664f, 33.55165f, 251.9432f),
            new Vector4(-1824.942f, -317.0142f, 42.62147f, 247.2377f),
            new Vector4(-1574.25f, -199.037f, 55.5222f, 310.6612f),
            new Vector4(-1615.96f, -289.1957f, 52.20426f, 196.3425f),
            new Vector4(-1578.846f, -162.748f, 55.22204f, 219.7428f),
            new Vector4(-1535.431f, -150.7758f, 53.23308f, 128.3868f),
            new Vector4(-1436.532f, -195.5897f, 46.81662f, 318.0396f),
            new Vector4(-1627.708f, -318.9261f, 51.13265f, 325.2805f),
            new Vector4(-1542.554f, -310.3897f, 47.39162f, 143.7849f),
            new Vector4(-1589.561f, -318.9854f, 48.91231f, 227.0527f),
            new Vector4(-1481.864f, -238.084f, 50.09292f, 136.7655f),
            new Vector4(-1486.121f, -269.5048f, 49.70763f, 42.33116f),
            new Vector4(-1449.945f, -319.8075f, 44.44312f, 220.3085f),
            new Vector4(-1398.886f, -185.3409f, 47.08973f, 38.29284f),
            new Vector4(-1391.426f, -286.404f, 43.06213f, 310.5025f),
            new Vector4(-1321.332f, -330.0197f, 36.52061f, 208.3952f),
            new Vector4(-1421.818f, -306.8068f, 44.20781f, 130.2204f),
            new Vector4(-1361.756f, -403.391f, 36.54499f, 35.62213f),
            new Vector4(-1320.915f, -362.0148f, 36.43155f, 297.1462f),
            new Vector4(-1402.33f, -350.1827f, 39.28265f, 42.57893f),
            new Vector4(-1400.969f, -415.7328f, 36.19796f, 297.1525f),
            new Vector4(-1290.786f, -328.8179f, 36.36375f, 117.3337f),
            new Vector4(-1260.921f, -461.9648f, 33.60441f, 134.353f),
            new Vector4(-1233.665f, -439.4408f, 33.31463f, 127.0006f),
            new Vector4(-1116.688f, -406.9846f, 36.19281f, 289.1139f),
            new Vector4(-1227.975f, -301.2097f, 37.36867f, 117.9335f),
            new Vector4(-1283.564f, -377.5718f, 36.56372f, 28.39923f),
            new Vector4(-1189.398f, -421.9489f, 34.12074f, 285.1404f),
            new Vector4(-1017.272f, -328.9304f, 37.58891f, 205.4243f),
            new Vector4(-951.2866f, -444.6992f, 37.20504f, 28.683f),
            new Vector4(-1083.566f, -385.2086f, 36.78763f, 119.7624f),
            new Vector4(-972.6516f, -419.4191f, 37.64844f, 203.547f),
            new Vector4(-1038.632f, -372.7121f, 37.86421f, 296.9128f),
            new Vector4(-990.5458f, -366.3932f, 37.56123f, 26.72575f),
            new Vector4(-984.6052f, -448.2925f, 37.39866f, 297.3008f),
            new Vector4(-954.6581f, -198.0341f, 37.30575f, 116.9183f),
            new Vector4(-1070.588f, -178.7444f, 37.89938f, 243.7531f),
            new Vector4(-1061.078f, -257.5449f, 37.66449f, 118.6123f),
            new Vector4(-1023.11f, -206.2399f, 37.29088f, 236.0489f),
            new Vector4(-924.1216f, -186.932f, 37.63374f, 112.6537f),
            new Vector4(-1077.2f, -219.4808f, 37.24754f, 302.1001f),
            new Vector4(-1003.113f, -174.6064f, 37.58872f, 117.7787f),
            new Vector4(-1015.538f, -242.5024f, 37.44881f, 297.998f),
            new Vector4(-914.3191f, -283.0308f, 39.7798f, 189.7321f),
            new Vector4(-924.5313f, -238.5567f, 39.50145f, 60.08945f),
            new Vector4(-973.7048f, -158.8819f, 37.27509f, 117.5638f),
            new Vector4(-1086.749f, -277.4247f, 37.41888f, 272.3994f),
            new Vector4(-1111.289f, -245.1031f, 37.465f, 307.8767f),
            new Vector4(-1148.792f, -273.1339f, 37.74737f, 300.2971f),
            new Vector4(-1185.674f, -293.8836f, 37.84081f, 297.0223f),
            new Vector4(-1134.556f, -150.4767f, 39.10202f, 242.9626f),
            new Vector4(-1186.175f, -129.3679f, 40.02878f, 241.8611f),
            new Vector4(-1277.265f, -62.82111f, 45.72928f, 68.20929f),
            new Vector4(-1421.705f, -51.43813f, 52.85131f, 204.3224f),
            new Vector4(-1427.509f, -162.0294f, 47.51962f, 219.4205f),
            new Vector4(-1380.484f, -65.89499f, 52.10114f, 280.9263f),
            new Vector4(-1421.157f, -85.28648f, 52.20586f, 296.6645f),
            new Vector4(-1373.293f, -244.4287f, 42.94531f, 214.3639f),
            new Vector4(-1538.727f, -193.2925f, 55.20296f, 40.20165f),
            new Vector4(-1510.785f, -250.1679f, 50.12389f, 222.2084f),
            new Vector4(-1497.399f, -120.3966f, 51.36375f, 128.8658f),
            new Vector4(-1707.594f, -352.3433f, 47.49938f, 94.7736f),
            new Vector4(-1595.266f, -132.1284f, 56.54433f, 31.18641f),
            new Vector4(-1739.391f, 54.06282f, 67.41997f, 47.59616f),
            new Vector4(-1680.788f, -23.58035f, 62.21314f, 224.3715f),
            new Vector4(-1890.477f, 164.2768f, 81.40719f, 223.4675f),
            new Vector4(-1724.115f, 92.67092f, 66.0137f, 115.8663f),
            new Vector4(-1817.573f, 100.1033f, 73.99539f, 230.7591f),
            new Vector4(-1853.218f, 121.7216f, 77.9715f, 229.9565f),
            new Vector4(-1835.168f, 53.45591f, 75.35315f, 282.0515f),
            new Vector4(-1821.973f, 163.567f, 76.59439f, 156.1619f),
            new Vector4(-1915.196f, 193.0995f, 83.40147f, 214.0684f),
            new Vector4(-1964.671f, 362.5161f, 91.0565f, 4.53246f),
            new Vector4(-1943.466f, 240.9306f, 84.14818f, 204.3169f),
            new Vector4(-1965.044f, 320.8004f, 88.98364f, 187.7217f),
            new Vector4(-1966.036f, 393.2027f, 95.75481f, 4.231061f),
            new Vector4(-1976.647f, 516.1759f, 107.8305f, 334.5211f),
            new Vector4(-1971.047f, 425.634f, 98.79535f, 12.12071f),
            new Vector4(-1988.173f, 485.8254f, 104.4333f, 178.808f),
            new Vector4(-1965.015f, 585.6918f, 117.4879f, 167.9776f),
            new Vector4(-1937.776f, 653.2534f, 123.597f, 146.937f),
            new Vector4(-1915.62f, 497.1581f, 111.4663f, 218.3372f),
            new Vector4(-1897.994f, 463.0562f, 115.8442f, 22.53957f),
            new Vector4(-1974.107f, 546.8818f, 111.273f, 163.4095f),
            new Vector4(-1839.159f, 488.3822f, 131.8622f, 96.225f),
            new Vector4(-1803.114f, 488.8614f, 133.1731f, 87.92968f),
            new Vector4(-1602.765f, 540.3381f, 127.0503f, 243.1873f),
            new Vector4(-1496.974f, 492.6211f, 115.6022f, 349.7374f),
            new Vector4(-1704.594f, 274.4052f, 62.31633f, 293.2887f),
            new Vector4(-1619.572f, 302.6253f, 58.04443f, 83.2549f),
            new Vector4(-1506.866f, 53.13783f, 54.28842f, 102.459f),
            new Vector4(-1686.416f, 107.7447f, 63.70647f, 98.46579f),
            new Vector4(-1654.904f, 126.896f, 62.05583f, 301.9521f),
            new Vector4(-1570.03f, 50.85038f, 58.23209f, 77.72712f),
            new Vector4(-1424.779f, 97.41283f, 51.52944f, 2.45102f),
            new Vector4(-1439.3f, 27.37445f, 51.87404f, 189.029f),
            new Vector4(-1434.976f, -7.463359f, 52.02258f, 188.055f),
            new Vector4(-1439.056f, 63.35524f, 52.07509f, 184.5899f),
            new Vector4(-1510.883f, 209.3095f, 58.13485f, 137.9793f),
            new Vector4(-1415.043f, 150.5309f, 54.49638f, 336.6172f),
            new Vector4(-1407.217f, 180.641f, 57.36635f, 325.0237f),
            new Vector4(-1371.603f, 212.0653f, 58.15146f, 110.4508f),
            new Vector4(-1377.941f, 376.7315f, 63.66586f, 117.7019f),
            new Vector4(-1226.309f, 244.494f, 65.84643f, 106.1786f),
            new Vector4(-1315.726f, 457.386f, 98.64449f, 272.6242f),
            new Vector4(-1304.478f, 633.4326f, 136.8346f, 105.4683f),
            new Vector4(-964.3851f, 697.2469f, 154.503f, 277.87f),
            new Vector4(-1045.485f, 772.1263f, 166.9298f, 173.768f),
            new Vector4(-716.8188f, 848.6939f, 219.9271f, 318.6194f),
            new Vector4(-662.1913f, 814.8173f, 199.3212f, 264.4029f),
            new Vector4(-632.9372f, 905.3198f, 223.5907f, 56.16996f),
            new Vector4(-845.4319f, 813.143f, 195.1587f, 111.8936f),
            new Vector4(-629.0187f, 806.7782f, 194.205f, 251.0837f),
            new Vector4(-678.9234f, 688.0571f, 153.3331f, 4.015389f),
            new Vector4(-587.0952f, 739.3391f, 182.8255f, 297.5298f),
            new Vector4(-644.2802f, 753.3298f, 176.7773f, 251.0534f),
            new Vector4(-613.5546f, 688.2474f, 149.0089f, 78.50513f),
            new Vector4(-685.8297f, 762.8931f, 170.9389f, 295.7067f),
            new Vector4(-548.7178f, 470.3995f, 102.0143f, 19.30019f),
            new Vector4(-674.2841f, 494.3422f, 109.4161f, 105.5554f),
            new Vector4(-564.5703f, 509.6636f, 104.5305f, 272.3912f),
            new Vector4(-534.7849f, 286.1341f, 82.70108f, 353.9235f),
            new Vector4(-522.725f, 254.0038f, 82.48383f, 81.71088f),
            new Vector4(-544.1453f, 191.5492f, 72.69727f, 177.6398f),
            new Vector4(-671.837f, 251.2313f, 81.11633f, 292.8676f),
            new Vector4(-641.9121f, 267.2736f, 80.78649f, 96.09579f),
            new Vector4(-602.7694f, 131.5984f, 59.2127f, 90.03439f),
            new Vector4(-660.3303f, 131.7812f, 56.62735f, 72.99802f),
            new Vector4(-731.6846f, 233.7603f, 76.74256f, 116.4767f),
            new Vector4(-727.636f, -43.01656f, 37.34644f, 296.918f),
            new Vector4(-751.6769f, -97.67205f, 37.39594f, 118.1886f),
            new Vector4(-646.1285f, -58.61163f, 39.93919f, 276.8799f),
            new Vector4(-591.3216f, -65.6115f, 41.42068f, 246.7163f),
            new Vector4(-591.7946f, -6.65987f, 43.70151f, 277.3018f),
            new Vector4(-776.0531f, -51.12894f, 37.22986f, 116.9942f),
            new Vector4(-705.7256f, -79.50924f, 37.49719f, 298.5803f),
            new Vector4(-699.832f, -17.45971f, 37.33745f, 113.3563f),
            new Vector4(-663.4197f, 2.637311f, 38.60658f, 135.0305f),
            new Vector4(-627.7728f, 0.8154584f, 40.84042f, 96.92777f),
            new Vector4(-598.3007f, -369.9177f, 34.32506f, 91.2065f),
            new Vector4(-643.694f, -324.7465f, 34.21565f, 211.1694f),
            new Vector4(-649.1817f, -367.1123f, 34.25137f, 77.48608f),
            new Vector4(-612.4805f, -330.4642f, 34.52268f, 120.5023f),
            new Vector4(-548.5257f, -282.1145f, 34.85205f, 110.6303f),
            new Vector4(-546.7934f, -371.411f, 34.55228f, 268.8486f),
            new Vector4(-694.5397f, -231.9532f, 36.23923f, 56.3905f),
            new Vector4(-747.2255f, -325.8331f, 35.78193f, 68.76195f),
            new Vector4(-546.7354f, -314.422f, 34.48141f, 23.85309f),
            new Vector4(-369.7882f, -379.5543f, 30.68166f, 83.41034f),
            new Vector4(-464.8699f, -501.9499f, 24.73195f, 89.99995f),
            new Vector4(-462.6326f, -258.5771f, 35.39917f, 292.6147f),
            new Vector4(-496.6051f, -468.6599f, 31.80794f, 88.88703f),
            new Vector4(-491.0705f, -368.3782f, 33.96082f, 82.25604f),
            new Vector4(-510.7844f, -272.6969f, 35.20101f, 112.2826f),
            new Vector4(-384.7494f, -233.6273f, 35.51777f, 348.3767f),
            new Vector4(-288.2844f, -264.0296f, 31.59545f, 185.4401f),
            new Vector4(-405.0941f, -292.2271f, 34.1862f, 234.2481f),
            new Vector4(-290.5352f, -374.4867f, 29.62099f, 233.9067f),
            new Vector4(-310.7996f, -192.2386f, 38.57259f, 290.0311f),
            new Vector4(-317.4778f, -401.9865f, 29.53955f, 262.8467f),
            new Vector4(-341.9481f, -293.0415f, 31.36645f, 53.71906f),
            new Vector4(-279.8495f, -326.5548f, 29.57913f, 62.40281f),
            new Vector4(-279.6707f, -152.3383f, 41.48063f, 176.0048f),
            new Vector4(-262.1751f, -93.25648f, 47.31969f, 348.0725f),
            new Vector4(-460.6215f, -141.0548f, 37.7822f, 29.76324f),
            new Vector4(-274.4746f, -193.5151f, 38.43863f, 357.6471f),
            new Vector4(-462.6653f, -213.2262f, 35.69746f, 221.5514f),
            new Vector4(-439.0908f, -238.665f, 35.78039f, 123.8511f),
            new Vector4(-343.1729f, -5.792594f, 46.89619f, 68.97343f),
            new Vector4(-537.9633f, -18.76197f, 43.64649f, 270.4726f),
            new Vector4(-555.0685f, 38.0584f, 45.07135f, 172.9315f),
            new Vector4(-531.0909f, 13.13238f, 43.75682f, 86.99155f),
            new Vector4(-380.3418f, -10.04782f, 46.46635f, 260.3871f),
            new Vector4(-424.1063f, -4.974288f, 45.78656f, 266.5621f),
            new Vector4(-392.5193f, 35.12848f, 48.406f, 178.3191f),
            new Vector4(-463.9885f, -8.820004f, 45.16832f, 236.5371f),
            new Vector4(-547.8176f, -80.49238f, 40.97485f, 235.4064f),
            new Vector4(-464.5667f, 239.0388f, 82.41605f, 262.4363f),
            new Vector4(-480.9938f, 125.1827f, 63.28608f, 268.2728f),
            new Vector4(-562.0523f, 254.9636f, 82.77238f, 266.9878f),
            new Vector4(-490.0185f, 255.2091f, 82.48194f, 83.09618f),
            new Vector4(-432.3403f, 234.9024f, 82.55728f, 262.8037f),
            new Vector4(-543.9042f, 225.3955f, 81.07971f, 179.6476f),
            new Vector4(-447.0704f, 129.3773f, 64.06949f, 88.05417f),
            new Vector4(-609.0085f, 254.4599f, 81.30339f, 265.3084f),
            new Vector4(-473.5353f, 375.83f, 102.0717f, 183.6303f),
            new Vector4(-470.4789f, 553.9108f, 119.5041f, 71.95206f),
            new Vector4(-340.5016f, 651.3011f, 170.5841f, 50.53234f),
            new Vector4(-318.7918f, 629.239f, 173.6381f, 236.9394f),
            new Vector4(-264.1843f, 606.67f, 182.9278f, 252.9824f),
            new Vector4(-288.4887f, 501.8033f, 116.3738f, 278.565f),
            new Vector4(-147.3553f, 518.3848f, 139.8432f, 109.572f),
            new Vector4(-136.265f, 369.019f, 112.0866f, 340.0406f),
            new Vector4(-235.3596f, 498.8967f, 126.4381f, 265.9807f),
            new Vector4(45.22266f, 347.7715f, 111.7864f, 243.9706f),
            new Vector4(145.7527f, 364.0419f, 110.8229f, 101.7651f),
            new Vector4(140.2458f, 413.1621f, 116.5021f, 113.5975f),
            new Vector4(36.40841f, 278.6495f, 108.9016f, 158.5662f),
            new Vector4(61.72591f, 465.978f, 146.2251f, 110.7949f),
            new Vector4(245.6219f, 323.7137f, 104.9785f, 160.14f),
            new Vector4(225.2806f, 196.3877f, 104.9033f, 69.31732f),
            new Vector4(181.5264f, 202.5206f, 105.2015f, 252.7925f),
            new Vector4(270.1357f, 367.6949f, 106.2283f, 348.7789f),
            new Vector4(279.1788f, 336.1179f, 104.9213f, 73.52716f),
            new Vector4(208.2567f, 221.1366f, 105.0185f, 160.4524f),
            new Vector4(484.5915f, 342.0301f, 135.2798f, 227.3943f),
            new Vector4(424.5869f, 317.6586f, 102.7264f, 177.1912f),
            new Vector4(413.001f, 280.2573f, 102.5988f, 337.8584f),
            new Vector4(421.4986f, 357.8848f, 106.7816f, 43.93914f),
            new Vector4(554.9225f, 219.755f, 102.0188f, 161.9912f),
            new Vector4(545.7101f, 248.4077f, 102.7195f, 250.1091f),
            new Vector4(485.4799f, 270.242f, 102.6423f, 250.394f),
            new Vector4(754.9714f, 111.9766f, 78.49234f, 158.0829f),
            new Vector4(592.4885f, 237.0086f, 102.6792f, 74.42615f),
            new Vector4(769.3215f, 165.3006f, 80.8171f, 238.7108f),
            new Vector4(629.6143f, 228.6427f, 99.41006f, 73.87827f),
            new Vector4(554.3839f, 183.1801f, 100.1197f, 340.5518f),
            new Vector4(712.9985f, 200.1181f, 88.27689f, 69.02084f),
            new Vector4(784.9118f, 35.88406f, 65.02834f, 146.5852f),
            new Vector4(829.4234f, 110.311f, 70.00809f, 143.7717f),
            new Vector4(728.2263f, 69.73854f, 82.20018f, 143.2711f),
            new Vector4(887.8688f, 150.2264f, 72.7975f, 322.1653f),
            new Vector4(785.5448f, -3.23916f, 62.24918f, 327.8587f),
            new Vector4(910.1103f, 76.68214f, 78.46357f, 320.303f),
            new Vector4(804.4126f, -31.44044f, 80.088f, 149.2168f),
            new Vector4(819.8378f, 49.71209f, 65.86286f, 326.0208f),
            new Vector4(943.9033f, 125.4207f, 80.10155f, 140.455f),
            new Vector4(857.0712f, 130.2987f, 71.39359f, 142.5043f),
            new Vector4(1126.742f, -246.7753f, 68.63255f, 255.1163f),
            new Vector4(1035.898f, -210.8673f, 69.70057f, 238.8889f),
            new Vector4(1074.439f, -220.9008f, 69.31252f, 67.68129f),
            new Vector4(950.8541f, -165.3366f, 73.85628f, 237.8405f),
            new Vector4(880.5369f, -233.0069f, 68.96909f, 237.188f),
            new Vector4(797.2159f, -183.4976f, 72.4715f, 242.5223f),
            new Vector4(902.7545f, -116.2466f, 77.20721f, 57.46458f),
            new Vector4(814.5051f, -65.895f, 80.16195f, 56.51743f),
            new Vector4(911.7499f, -248.742f, 68.73689f, 53.6815f),
            new Vector4(905.7281f, -211.8518f, 69.90508f, 147.6579f),
            new Vector4(847.4512f, -144.9087f, 77.22359f, 327.4433f),
            new Vector4(868.1824f, -110.0055f, 79.1864f, 131.0044f),
            new Vector4(997.3698f, -193.1156f, 70.76038f, 232.652f),
            new Vector4(979.179f, -293.6017f, 66.47311f, 57.02325f),
            new Vector4(940.9926f, -275.1269f, 66.53604f, 235.4348f),
            new Vector4(984.3708f, -249.3065f, 67.84178f, 147.7514f),
            new Vector4(1078.605f, -394.8586f, 67.09069f, 310.418f),
            new Vector4(1216.073f, -335.6525f, 68.60818f, 3.986905f),
            new Vector4(1185.761f, -285.2286f, 68.5448f, 223.3498f),
            new Vector4(1287.575f, -462.1867f, 68.57883f, 353.3214f),
            new Vector4(1177.156f, -531.6691f, 64.83223f, 353.0229f),
            new Vector4(1181.184f, -581.3193f, 64.21468f, 5.848144f),
            new Vector4(1263.389f, -529.5255f, 68.74126f, 167.8024f),
            new Vector4(1181.746f, -494.1324f, 65.0406f, 168.8525f),
            new Vector4(1290.488f, -639.1838f, 67.64944f, 26.75439f),
            new Vector4(1174.648f, -613.0878f, 63.1927f, 189.9666f),
            new Vector4(1265.792f, -561.4096f, 68.40173f, 356.4321f),
            new Vector4(1241.423f, -748.8621f, 60.65913f, 117.8637f),
            new Vector4(1184.47f, -819.4753f, 54.97758f, 335.5414f),
            new Vector4(1195.412f, -742.8657f, 58.13315f, 177.6402f),
            new Vector4(1187.25f, -648.4356f, 61.7332f, 10.60079f),
            new Vector4(1162.508f, -865.4789f, 53.87332f, 346.8991f),
            new Vector4(1187.505f, -680.5829f, 60.48462f, 191.4077f),
            new Vector4(1171.258f, -761.4368f, 57.18582f, 269.8035f),
            new Vector4(1118.61f, -756.9263f, 57.23439f, 89.98205f),
            new Vector4(909.1993f, -726.004f, 41.25236f, 43.03382f),
            new Vector4(873.9367f, -687.0456f, 42.88605f, 47.71594f),
            new Vector4(980.8555f, -558.3409f, 58.81419f, 305.0469f),
            new Vector4(804.6171f, -651.3569f, 40.02763f, 55.56894f),
            new Vector4(830.3353f, -688.3561f, 42.24314f, 238.3931f),
            new Vector4(877.2381f, -584.2407f, 56.86787f, 321.8043f),
            new Vector4(885.1849f, -516.7332f, 56.93456f, 113.3721f),
            new Vector4(931.893f, -502.2746f, 59.48833f, 295.0407f),
            new Vector4(611.6895f, -586.8018f, 35.75634f, 245.5325f),
            new Vector4(670.4124f, -567.213f, 35.99604f, 63.77095f),
            new Vector4(663.0486f, -611.9166f, 35.79165f, 243.2988f),
            new Vector4(614.6118f, -537.9656f, 35.8917f, 62.00296f),
            new Vector4(697.2905f, -422.1397f, 40.21734f, 50.22357f),
            new Vector4(739.6042f, -616.8666f, 36.01068f, 63.94894f),
            new Vector4(784.2753f, -562.1902f, 31.42321f, 0.6105229f),
            new Vector4(755.5647f, -469.7597f, 36.38433f, 44.62441f),
            new Vector4(578.7509f, -524.3885f, 50.5926f, 334.923f),
            new Vector4(579.4024f, -482.5299f, 45.61116f, 13.4557f),
            new Vector4(646.1593f, -401.5412f, 42.15257f, 247.5204f),
            new Vector4(703.0239f, -619.6265f, 35.79305f, 244.8701f),
            new Vector4(580.7628f, -361.1129f, 43.56773f, 245.0116f),
            new Vector4(383.9719f, -401.731f, 46.29114f, 271.6643f),
            new Vector4(557.2532f, -340.6422f, 43.09655f, 31.86589f),
            new Vector4(484.6562f, -282.6593f, 46.93795f, 144.514f),
            new Vector4(515.8672f, -239.2395f, 48.8131f, 173.7095f),
            new Vector4(472.7477f, -316.7789f, 46.73656f, 325.7866f),
            new Vector4(400.0387f, -275.1713f, 52.47854f, 68.29079f),
            new Vector4(440.2185f, -302.4547f, 49.23735f, 250.1485f),
            new Vector4(489.9749f, -441.3477f, 29.67748f, 143.4603f),
            new Vector4(545.6844f, -374.4599f, 33.29431f, 143.7069f),
            new Vector4(590.6894f, -332.6219f, 36.15666f, 324.584f),
            new Vector4(195.9984f, -213.8144f, 54.03403f, 251.086f),
            new Vector4(308.6995f, -257.0469f, 53.99473f, 248.0355f),
            new Vector4(227.0915f, -244.1604f, 53.77253f, 336.08f),
            new Vector4(256.7301f, -220.2619f, 53.91996f, 66.8807f),
            new Vector4(355.925f, -275.2075f, 53.26875f, 247.906f),
            new Vector4(328.9635f, -111.1535f, 67.54218f, 253.2729f),
            new Vector4(374.8342f, -249.3374f, 53.7539f, 345.0941f),
            new Vector4(299.4734f, -83.96841f, 69.90607f, 65.58794f),
            new Vector4(161.8203f, -166.5582f, 53.86707f, 341.0973f),
            new Vector4(77.23621f, -5.453891f, 68.10929f, 69.73026f),
            new Vector4(39.02104f, -139.8721f, 54.76393f, 68.52326f),
            new Vector4(8.126485f, -101.772f, 56.95022f, 340.3641f),
            new Vector4(111.8497f, -55.6175f, 66.83141f, 159.7637f),
            new Vector4(75.78925f, -162.4999f, 54.64404f, 199.0575f),
            new Vector4(117.9009f, -17.52423f, 66.97152f, 108.216f),
            new Vector4(90.10928f, -130.1755f, 55.65035f, 341.5779f),
            new Vector4(-134.739f, -95.73859f, 55.80958f, 250.4854f),
            new Vector4(-44.64067f, -118.9915f, 57.61814f, 73.1236f),
            new Vector4(-96.00504f, -160.3191f, 53.4193f, 167.5015f),
            new Vector4(-85.9522f, -114.651f, 57.38033f, 165.7549f),
            new Vector4(23.2095f, -60.2039f, 63.22495f, 340.3126f),
            new Vector4(-65.81592f, -237.0123f, 45.0229f, 64.90363f),
            new Vector4(-54.78159f, -35.6099f, 64.63257f, 348.1767f),
            new Vector4(29.13917f, -272.5801f, 47.66055f, 294.4666f),
            new Vector4(-41.15519f, -258.6802f, 45.82863f, 250.4805f),
            new Vector4(1.944483f, -367.125f, 39.70816f, 338.003f),
            new Vector4(10.00561f, -336.9868f, 43.0213f, 345.9732f),
            new Vector4(2209.733f, 132.217f, 227.4109f, 324.4745f),
            new Vector4(2363.109f, 264.0811f, 188.3366f, 320.4686f),
            new Vector4(2575.525f, 128.5507f, 97.67904f, 343.6361f),
            new Vector4(2526.686f, 220.8831f, 105.0391f, 174.5009f),
            new Vector4(2534.082f, 310.7737f, 109.1445f, 177.0337f),
            new Vector4(2524.859f, 252.2778f, 106.2434f, 174.9845f),
            new Vector4(2511.758f, 140.6926f, 101.671f, 170.9557f),
            new Vector4(2614.219f, 314.3719f, 97.1946f, 350.543f),
            new Vector4(2597.115f, 229.0174f, 98.40055f, 347.2201f),
            new Vector4(2531.406f, 352.3351f, 110.7274f, 177.4529f),
            new Vector4(2629.969f, 491.4938f, 95.35138f, 1.963281f),
            new Vector4(2537.552f, 439.1716f, 112.9213f, 179.8896f),
            new Vector4(2612.432f, 279.4491f, 97.56738f, 349.0627f),
            new Vector4(2524.783f, 625.3181f, 107.1587f, 187.7115f),
            new Vector4(2532.457f, 476.6914f, 113.0645f, 181.3379f),
            new Vector4(2536.426f, 509.0778f, 113.0145f, 182.7308f),
            new Vector4(2616.574f, 598.6099f, 94.50494f, 11.2407f),
            new Vector4(2542.974f, 538.4647f, 232.4151f, 185.3453f),
            new Vector4(2526.51f, 560.9766f, 110.7383f, 185.3787f),
            new Vector4(2543.22f, 816.7948f, 87.87812f, 26.48083f),
            new Vector4(2520.781f, 857.2928f, 86.87137f, 29.91071f),
            new Vector4(2489.485f, 812.5588f, 94.46577f, 192.953f),
            new Vector4(2496.15f, 898.2628f, 86.43266f, 32.42573f),
            new Vector4(2587.362f, 709.1863f, 92.23175f, 17.99182f),
            new Vector4(2464.247f, 881.9277f, 90.47746f, 200.2045f),
            new Vector4(2509.691f, 690.5882f, 102.7387f, 189.9544f),
            new Vector4(2499.985f, 769.5857f, 97.21571f, 191.4442f),
            new Vector4(2481.279f, 1318.101f, 46.583f, 148.9162f),
            new Vector4(2505.087f, 1365.849f, 41.33935f, 157.139f),
            new Vector4(2525.008f, 1409.318f, 36.88371f, 345.0746f),
            new Vector4(2443.953f, 1263.938f, 52.55575f, 142.5824f),
            new Vector4(2540.654f, 1620.423f, 29.41046f, 180.2944f),
            new Vector4(2539.342f, 1538.918f, 30.06983f, 178.2434f),
            new Vector4(2535.184f, 1895.461f, 20.26841f, 179.9494f),
            new Vector4(2541.143f, 1966.469f, 19.88959f, 358.5352f),
            new Vector4(2562.35f, 2233.313f, 18.84712f, 165.5437f),
            new Vector4(2548.228f, 2140.033f, 19.10206f, 353.331f),
            new Vector4(2576.125f, 2284.785f, 19.26968f, 165.5563f),
            new Vector4(2611.188f, 2447.62f, 24.87503f, 356.8134f),
            new Vector4(2603.859f, 2383.141f, 21.56332f, 351.1897f),
            new Vector4(2519.351f, 2749.305f, 44.84911f, 208.9228f),
            new Vector4(2576.506f, 2608.33f, 35.87551f, 198.6982f),
            new Vector4(2544.283f, 2711.642f, 42.2863f, 24.67535f),
            new Vector4(2566.738f, 2652.114f, 38.46175f, 20.28756f),
            new Vector4(2499.892f, 2780.477f, 46.41373f, 212.3389f),
            new Vector4(2406.717f, 2847.666f, 47.42363f, 297.1097f),
            new Vector4(2451.377f, 2860.132f, 48.36862f, 37.58851f),
            new Vector4(2413.366f, 2923.773f, 39.61669f, 129.6383f),
            new Vector4(2491.441f, 2921.442f, 43.19451f, 320.5541f),
            new Vector4(2356.166f, 2878.722f, 40.0907f, 128.1919f),
            new Vector4(2364.207f, 2824.765f, 43.2396f, 298.9663f),
            new Vector4(2280.201f, 2847.174f, 41.55528f, 137.3741f),
            new Vector4(2312.8f, 2844.675f, 40.51515f, 127.046f),
            new Vector4(2282.121f, 2790.747f, 42.15365f, 307.421f),
            new Vector4(2387.279f, 2870.142f, 39.95407f, 308.5116f),
            new Vector4(2386.522f, 2901.885f, 39.80455f, 128.9576f),
            new Vector4(1701.742f, 2884.922f, 43.41687f, 121.3271f),
            new Vector4(1756.1f, 2909.003f, 45.37634f, 296.9947f),
            new Vector4(1503.062f, 2752.917f, 37.54802f, 124.1267f),
            new Vector4(1452.08f, 2721.93f, 36.83869f, 114.9265f),
            new Vector4(1597.794f, 2818.185f, 38.31738f, 123.6212f),
            new Vector4(1685.814f, 1295.248f, 85.99424f, 337.8953f),
            new Vector4(1681.793f, 1411.0f, 85.86982f, 169.8419f),
            new Vector4(1671.212f, 1353.558f, 86.5987f, 169.0972f),
            new Vector4(1649.579f, 1251.987f, 85.00512f, 166.8436f),
            new Vector4(1644.209f, 1159.184f, 83.47633f, 343.3784f),
            new Vector4(1646.331f, 1220.812f, 84.58939f, 165.967f),
            new Vector4(1638.411f, 1189.956f, 84.26482f, 164.9894f),
            new Vector4(1616.599f, 1132.667f, 82.65942f, 162.7568f),
            new Vector4(1302.952f, 1104.938f, 105.0986f, 5.138312f),
            new Vector4(1291.452f, 1224.801f, 107.8283f, 182.3704f),
            new Vector4(1299.277f, 1172.523f, 106.067f, 2.178879f),
            new Vector4(1162.061f, 1163.518f, 169.2305f, 331.4494f),
            new Vector4(1224.812f, 1301.871f, 143.4747f, 205.6034f),
            new Vector4(1202.844f, 1213.091f, 153.7624f, 134.6638f),
            new Vector4(1288.875f, 1276.67f, 107.9757f, 182.3274f),
            new Vector4(1153.139f, 1396.909f, 157.4132f, 31.96189f),
            new Vector4(1178.581f, 1344.859f, 148.2251f, 219.3666f),
            new Vector4(1112.652f, 1433.647f, 165.742f, 237.679f),
            new Vector4(1236.053f, 1267.153f, 143.0141f, 353.3276f),
            new Vector4(1076.771f, 1455.582f, 171.2513f, 238.422f),
            new Vector4(1049.693f, 1483.966f, 174.6703f, 40.84822f),
            new Vector4(724.9642f, 1707.966f, 181.9375f, 252.6018f),
            new Vector4(536.1918f, 1805.811f, 216.2028f, 89.88984f),
            new Vector4(651.6016f, 1752.901f, 191.5123f, 228.641f),
            new Vector4(440.266f, 1776.847f, 232.7036f, 303.6195f),
            new Vector4(593.8476f, 1792.205f, 203.1456f, 250.1996f),
            new Vector4(467.5666f, 1795.833f, 228.4505f, 109.2573f),
            new Vector4(384.2521f, 1731.63f, 238.9885f, 310.1941f),
            new Vector4(409.5539f, 1759.619f, 235.9535f, 128.793f),
            new Vector4(214.7182f, 1678.98f, 231.635f, 95.74806f),
            new Vector4(334.7421f, 1690.057f, 241.1994f, 306.5257f),
            new Vector4(181.3639f, 1669.083f, 229.3064f, 110.9029f),
            new Vector4(174.5287f, 1464.66f, 239.5605f, 38.97672f),
            new Vector4(147.0326f, 1497.095f, 238.617f, 200.6375f),
            new Vector4(148.8246f, 1547.716f, 232.4723f, 357.9115f),
            new Vector4(478.3025f, 1310.661f, 278.7451f, 98.58685f),
            new Vector4(412.0106f, 1166.244f, 242.701f, 188.2016f),
            new Vector4(526.5276f, 1008.098f, 213.084f, 154.9146f),
            new Vector4(459.5442f, 881.0067f, 197.3857f, 106.2982f),
            new Vector4(489.0171f, 869.3386f, 197.672f, 68.39874f),
            new Vector4(286.1162f, 824.5895f, 190.9086f, 357.5869f),
            new Vector4(416.1048f, 896.0391f, 198.3259f, 57.17114f),
            new Vector4(296.0432f, 886.1646f, 198.9687f, 159.1087f),
            new Vector4(279.7618f, 1000.869f, 209.6305f, 114.2667f),
            new Vector4(311.3694f, 1015.972f, 210.4296f, 179.4518f),
            new Vector4(248.0948f, 1228.62f, 230.1393f, 186.2644f),
            new Vector4(280.2593f, 1107.385f, 217.6179f, 210.0777f),
            new Vector4(275.5251f, 1145.586f, 221.5825f, 24.09893f),
            new Vector4(176.0554f, 1364.661f, 246.3946f, 228.5849f),
            new Vector4(215.7692f, 1414.764f, 239.4866f, 32.4923f),
            new Vector4(245.1666f, 1282.386f, 233.882f, 185.9833f),
            new Vector4(-228.262f, 1490.313f, 288.3032f, 105.5144f),
            new Vector4(-316.0062f, 1199.441f, 321.195f, 124.2885f),
            new Vector4(-273.3927f, 1223.815f, 316.0543f, 329.2446f),
            new Vector4(-451.9074f, 1376.884f, 298.7825f, 339.2332f),
            new Vector4(-803.4382f, 1400.777f, 245.4155f, 355.8184f),
            new Vector4(-810.3052f, 1357.203f, 252.039f, 180.9316f),
            new Vector4(-764.8218f, 1577.156f, 214.5795f, 167.9108f),
            new Vector4(-857.2825f, 1673.798f, 192.0861f, 258.7624f),
            new Vector4(-825.6808f, 2072.653f, 116.7306f, 162.0421f),
            new Vector4(-708.244f, 2412.259f, 62.82648f, 340.4291f),
            new Vector4(-576.6374f, 2640.776f, 44.86337f, 197.5645f),
            new Vector4(-423.4205f, 2834.077f, 38.39166f, 134.475f),
            new Vector4(189.7377f, 2100.689f, 122.247f, 262.748f),
            new Vector4(410.481f, 2113.02f, 92.87507f, 302.816f),
            new Vector4(722.563f, 2192.261f, 57.48515f, 283.3408f),
            new Vector4(617.6022f, 2179.653f, 66.74886f, 270.5267f),
            new Vector4(951.3539f, 2185.54f, 48.11063f, 48.96135f),
            new Vector4(1026.855f, 2102.21f, 49.56359f, 35.45526f),
            new Vector4(865.2236f, 2228.843f, 48.10395f, 248.4509f),
            new Vector4(1156.776f, 2686.77f, 37.73614f, 87.05775f),
            new Vector4(1091.355f, 2689.726f, 38.41179f, 87.2859f),
            new Vector4(983.6733f, 2695.761f, 39.51746f, 87.50854f),
            new Vector4(939.8824f, 2692.974f, 40.20329f, 267.8916f),
            new Vector4(633.705f, 2701.954f, 40.59883f, 93.15915f),
            new Vector4(764.5297f, 2702.82f, 39.58615f, 89.37788f),
            new Vector4(728.6912f, 2697.049f, 39.60524f, 269.9511f),
            new Vector4(399.5503f, 2664.496f, 43.89772f, 281.1457f),
            new Vector4(572.9213f, 2695.77f, 41.57658f, 97.50709f),
            new Vector4(442.0526f, 2677.363f, 43.33131f, 98.75503f),
            new Vector4(527.7551f, 2683.649f, 42.12896f, 277.91f),
            new Vector4(147.7164f, 2654.088f, 48.93785f, 232.884f),
            new Vector4(288.735f, 2621.48f, 44.03841f, 189.3406f),
            new Vector4(114.6915f, 2689.584f, 51.92338f, 45.9969f),
            new Vector4(-64.12786f, 2813.547f, 53.83102f, 252.0282f),
            new Vector4(-30.10185f, 2805.093f, 56.16378f, 64.71119f),
            new Vector4(64.57195f, 2740.128f, 56.1833f, 45.45519f),
            new Vector4(-380.1279f, 2869.741f, 41.00764f, 286.8207f),
            new Vector4(-231.6501f, 2880.132f, 46.14186f, 253.9761f),
            new Vector4(-324.1833f, 2893.049f, 44.74868f, 106.6079f),
            new Vector4(-550.8048f, 2850.968f, 34.03984f, 81.09386f),
            new Vector4(-627.9698f, 2850.382f, 32.68341f, 280.7192f),
            new Vector4(-540.6638f, 2745.781f, 40.46593f, 313.8028f),
            new Vector4(-671.7944f, 2836.774f, 29.51994f, 116.8662f),
            new Vector4(-491.98f, 2840.785f, 33.41104f, 213.238f),
            new Vector4(-978.9995f, 2756.122f, 24.93013f, 102.7596f),
            new Vector4(-839.5653f, 2751.757f, 22.77038f, 282.2956f),
            new Vector4(-1240.4f, 2547.877f, 16.9751f, 315.5663f),
            new Vector4(-1149.81f, 2631.005f, 15.54868f, 312.3514f),
            new Vector4(-1121.088f, 2663.647f, 17.44191f, 131.682f),
            new Vector4(-1066.154f, 2702.953f, 21.06235f, 307.3557f),
            new Vector4(-1357.051f, 2309.036f, 40.06788f, 177.666f),
            new Vector4(-1352.783f, 2439.587f, 27.06071f, 98.86178f),
            new Vector4(-1346.32f, 2379.928f, 33.28584f, 354.7993f),
            new Vector4(-1420.213f, 2411.087f, 26.89024f, 284.5268f),
            new Vector4(-1503.199f, 2091.961f, 58.08338f, 16.28551f),
            new Vector4(-1639.41f, 2208.9f, 90.07719f, 28.53751f),
            new Vector4(-1496.963f, 2143.366f, 55.63814f, 120.0455f),
            new Vector4(-1543.4f, 2241.68f, 54.6936f, 192.4396f),
            new Vector4(-1822.124f, 2037.618f, 131.0426f, 100.4123f),
            new Vector4(-1716.388f, 2108.428f, 111.8446f, 308.824f),
            new Vector4(-1812.735f, 1841.559f, 156.6688f, 95.34016f),
            new Vector4(-1875.839f, 1991.567f, 142.2404f, 357.6592f),
            new Vector4(-1854.194f, 1951.172f, 144.2541f, 225.004f),
            new Vector4(-1865.386f, 1834.131f, 162.191f, 115.604f),
            new Vector4(-1957.764f, 1761.824f, 175.7773f, 92.00068f),
            new Vector4(-1958.485f, 1877.541f, 183.7805f, 349.8728f),
            new Vector4(-2052.436f, 1944.029f, 187.8224f, 9.474176f),
            new Vector4(-2030.695f, 1915.567f, 186.3611f, 252.3603f),
            new Vector4(-2034.82f, 1994.535f, 189.519f, 358.2069f),
            new Vector4(-2222.803f, 2289.366f, 32.10748f, 299.797f),
            new Vector4(-2540.683f, 2285.78f, 32.39028f, 274.7949f),
            new Vector4(-2497.521f, 2296.375f, 31.64269f, 95.97191f),
            new Vector4(-2372.369f, 2259.475f, 32.63223f, 62.08182f),
            new Vector4(-2763.219f, 2226.696f, 23.1489f, 309.9032f),
            new Vector4(-2725.338f, 2287.58f, 18.59441f, 156.6945f),
            new Vector4(-2706.734f, 2348.935f, 16.50568f, 169.8493f),
            new Vector4(-2692.136f, 2287.921f, 19.43999f, 78.17873f),
            new Vector4(-2819.52f, 2204.584f, 28.93443f, 117.516f),
            new Vector4(-2923.657f, 2147.302f, 39.6062f, 125.3602f),
            new Vector4(-2889.241f, 2155.647f, 36.98457f, 302.2849f),
            new Vector4(-2995.915f, 2001.543f, 32.1203f, 171.8055f),
            new Vector4(-2961.012f, 2086.129f, 40.69109f, 327.5797f),
            new Vector4(-3014.635f, 1911.874f, 28.26701f, 339.0294f),
            new Vector4(-3048.038f, 1773.517f, 35.21213f, 182.5865f),
            new Vector4(-3025.217f, 1879.071f, 29.61488f, 345.5192f),
            new Vector4(-3005.2f, 1475.799f, 27.05014f, 151.8139f),
            new Vector4(-3024.178f, 1657.83f, 33.31538f, 200.798f),
            new Vector4(-2981.224f, 1496.669f, 27.67006f, 337.637f),
            new Vector4(-2984.769f, 1593.605f, 29.26893f, 19.81318f),
            new Vector4(-2745.362f, 1388.093f, 86.27592f, 346.8576f),
            new Vector4(-2941.56f, 1331.183f, 42.00987f, 281.6893f),
            new Vector4(-2822.288f, 1288.994f, 66.68177f, 295.7894f),
            new Vector4(-2634.632f, 1299.341f, 145.4768f, 175.8641f),
            new Vector4(-2629.49f, 1222.854f, 152.6628f, 2.727357f),
            new Vector4(-2632.416f, 1182.66f, 156.1274f, 184.9173f),
            new Vector4(-2771.702f, 1339.663f, 78.45363f, 317.8034f),
            new Vector4(-2621.182f, 1110.371f, 164.1167f, 208.6393f),
            new Vector4(-2470.77f, 1045.621f, 191.082f, 79.52336f),
            new Vector4(-2161.796f, 997.2507f, 187.2411f, 219.874f),
            new Vector4(-2285.168f, 1053.749f, 196.5931f, 133.0327f),
            new Vector4(-2118.586f, 965.4271f, 184.5145f, 58.2656f),
            new Vector4(-2029.574f, 762.5194f, 155.0574f, 176.7326f),
            new Vector4(-2019.317f, 842.4243f, 164.2121f, 173.8857f),
            new Vector4(-2023.023f, 925.6667f, 176.9773f, 30.49553f),
            new Vector4(-2027.002f, 722.1794f, 149.1451f, 194.0148f),
            new Vector4(-2284.942f, 537.0339f, 172.0862f, 148.7051f),
            new Vector4(-2166.388f, 515.4957f, 148.4329f, 22.30321f),
            new Vector4(-2242.332f, 567.1857f, 167.9975f, 289.8769f),
            new Vector4(-2637.959f, -104.818f, 18.45442f, 219.2749f),
            new Vector4(-2686.251f, -35.23096f, 15.31386f, 41.25777f),
            new Vector4(-2559.882f, -164.3875f, 19.80402f, 61.69453f),
            new Vector4(-2761.247f, 11.74958f, 14.82848f, 238.6768f),
            new Vector4(-2657.946f, -79.98379f, 16.98779f, 219.3363f),
            new Vector4(-2717.615f, -1.741454f, 15.03634f, 50.03399f),
            new Vector4(-2825.789f, 54.93704f, 14.52837f, 70.50763f),
            new Vector4(-2969.492f, 111.737f, 13.71373f, 50.32147f),
            new Vector4(-3018.347f, 148.4116f, 14.85494f, 211.9116f),
            new Vector4(-2919.525f, 84.21567f, 13.55411f, 71.40073f),
            new Vector4(-3022.177f, 191.3153f, 15.71386f, 15.37655f),
            new Vector4(-3024.148f, 290.9225f, 14.75623f, 161.2186f),
            new Vector4(-3042.325f, 230.6325f, 15.62866f, 107.7086f),
            new Vector4(-2990.409f, 367.9081f, 14.23617f, 350.4879f),
            new Vector4(-3007.871f, 340.8937f, 14.79404f, 167.26f),
            new Vector4(-2993.297f, 477.4653f, 15.43727f, 177.8258f),
            new Vector4(-2996.971f, 627.1772f, 20.60367f, 11.93975f),
            new Vector4(-2999.119f, 566.2831f, 17.64109f, 188.3095f),
            new Vector4(-2996.235f, 434.6468f, 14.93037f, 175.4512f),
            new Vector4(-3112.169f, 799.0991f, 17.96095f, 214.9291f),
            new Vector4(-3038.206f, 724.7161f, 22.54257f, 35.01971f),
            new Vector4(-3091.533f, 718.6886f, 20.21837f, 16.06813f),
            new Vector4(-3022.098f, 667.5359f, 22.27876f, 202.1872f),
            new Vector4(-3127.185f, 849.7214f, 15.53089f, 24.35567f),
            new Vector4(-3113.516f, 1058.298f, 19.79095f, 344.8239f),
            new Vector4(-3145.552f, 1009.992f, 17.41965f, 154.3873f),
            new Vector4(-3162.015f, 946.8335f, 14.07732f, 178.0918f),
            new Vector4(-3145.531f, 974.3537f, 15.1694f, 349.4025f),
            new Vector4(-3145.19f, 895.9677f, 14.12918f, 11.35599f),
            new Vector4(-3044.446f, 1205.664f, 23.18199f, 318.1493f),
            new Vector4(-3096.993f, 1221.696f, 19.77898f, 355.2683f),
            new Vector4(-3095.045f, 1319.243f, 19.7114f, 163.8741f),
            new Vector4(-3112.759f, 1172.019f, 20.04141f, 175.9215f),
            new Vector4(-3138.141f, 1314.157f, 17.95634f, 291.5071f),
            new Vector4(-3105.324f, 1113.506f, 19.83934f, 353.7387f),
            new Vector4(-2680.005f, 2447.819f, 16.20433f, 351.6474f),
            new Vector4(-2696.003f, 2411.086f, 16.06043f, 171.4326f),
            new Vector4(-2672.881f, 2577.11f, 16.17355f, 171.7008f),
            new Vector4(-2684.087f, 2495.285f, 16.11193f, 171.799f),
            new Vector4(-2694.271f, 2350.625f, 16.43025f, 348.9131f),
            new Vector4(-2636.398f, 2738.381f, 16.07618f, 351.8543f),
            new Vector4(-2658.272f, 2668.375f, 16.15497f, 171.6096f),
            new Vector4(-2666.039f, 2616.726f, 16.36126f, 171.806f),
            new Vector4(-2653.76f, 2702.543f, 16.147f, 171.6246f),
            new Vector4(-3169.161f, 3368.083f, 121.3265f, 357.9356f),
            new Vector4(-2473.586f, 3732.037f, 15.8169f, 167.3079f),
            new Vector4(-2451.523f, 3774.463f, 19.06055f, 341.4386f),
            new Vector4(-2435.252f, 3837.411f, 22.65085f, 152.2118f),
            new Vector4(-2470.483f, 3680.297f, 13.60682f, 354.0486f),
            new Vector4(-2410.83f, 3861.531f, 23.71287f, 334.9936f),
            new Vector4(-2330.527f, 4128.964f, 36.59243f, 159.4465f),
            new Vector4(-2346.637f, 4030.326f, 28.89823f, 343.3517f),
            new Vector4(-2388.453f, 3957.978f, 24.44778f, 157.2787f),
            new Vector4(-2368.418f, 4005.31f, 26.50771f, 158.6713f),
            new Vector4(-2404.007f, 3912.988f, 24.19202f, 161.998f),
            new Vector4(-2199.298f, 4339.825f, 50.12613f, 339.0387f),
            new Vector4(-2203.241f, 4371.024f, 53.03238f, 164.0596f),
            new Vector4(-2286.865f, 4192.089f, 40.19181f, 329.2221f),
            new Vector4(-2175.292f, 4411.012f, 58.53984f, 335.6044f),
            new Vector4(-2119.548f, 4458.67f, 62.35292f, 90.2115f),
            new Vector4(-2065.183f, 4471.6f, 57.47247f, 116.2931f),
            new Vector4(-1979.663f, 4546.112f, 56.54295f, 135.1958f),
            new Vector4(-2021.611f, 4489.247f, 56.53505f, 312.7196f),
            new Vector4(-1941.156f, 4569.973f, 56.68782f, 315.0208f),
            new Vector4(-1992.434f, 4518.746f, 56.63215f, 314.994f),
            new Vector4(-1514.468f, 4471.165f, 17.45366f, 259.4968f),
            new Vector4(-1627.272f, 4860.657f, 60.54851f, 312.7747f),
            new Vector4(-1764.029f, 4761.762f, 56.68133f, 132.7729f),
            new Vector4(-1722.104f, 4781.012f, 57.88047f, 308.3594f),
            new Vector4(-1696.908f, 4816.662f, 59.93837f, 126.8435f),
            new Vector4(-1597.005f, 4907.261f, 60.79286f, 132.3561f),
            new Vector4(-1652.296f, 4837.922f, 60.2491f, 312.4684f),
            new Vector4(-1493.352f, 5019.999f, 62.25902f, 135.2671f),
            new Vector4(-1534.041f, 4976.729f, 61.72534f, 138.8401f),
            new Vector4(-1427.978f, 5068.698f, 61.16201f, 123.4096f),
            new Vector4(-1290.448f, 5241.243f, 52.56904f, 326.7877f),
            new Vector4(-1337.682f, 5123.958f, 61.16357f, 313.4997f),
            new Vector4(-1318.116f, 5149.168f, 61.18853f, 334.8269f),
            new Vector4(-1315.218f, 5188.86f, 58.67366f, 169.7507f),
            new Vector4(-1170.468f, 5260.627f, 52.79151f, 290.2311f),
            new Vector4(-1099.302f, 5322.783f, 48.05014f, 111.6169f),
            new Vector4(-1040.373f, 5353.477f, 43.2707f, 137.3572f),
            new Vector4(-1235.439f, 5254.071f, 49.61826f, 258.5514f),
            new Vector4(-1133.414f, 5303.127f, 50.91839f, 130.8911f),
            new Vector4(-860.3947f, 5433.633f, 34.43429f, 296.9857f),
            new Vector4(-821.2098f, 5461.789f, 33.21459f, 301.3969f),
            new Vector4(-930.2794f, 5422.968f, 37.17746f, 105.8641f),
            new Vector4(-994.8339f, 5382.45f, 41.00949f, 306.4271f),
            new Vector4(-899.1841f, 5418.473f, 35.80783f, 286.7546f),
            new Vector4(-792.5188f, 5472.131f, 33.73322f, 301.6459f),
            new Vector4(-764.8546f, 5687.163f, 21.36058f, 159.4969f),
            new Vector4(-645.6857f, 5583.875f, 38.64117f, 131.243f),
            new Vector4(-785.1871f, 5551.032f, 32.64347f, 62.01466f),
            new Vector4(-726.1489f, 5527.25f, 36.32822f, 122.6459f),
            new Vector4(-597.676f, 5640.609f, 38.19688f, 149.3456f),
            new Vector4(-545.8519f, 5757.433f, 36.12662f, 157.1921f),
            new Vector4(-584.0942f, 5670.368f, 37.6837f, 153.8397f),
            new Vector4(-486.4556f, 5850.023f, 33.33875f, 327.8222f),
            new Vector4(-480.2897f, 5880.429f, 33.34431f, 145.0081f),
            new Vector4(-432.5207f, 5925.561f, 31.95141f, 321.8116f),
            new Vector4(-512.0601f, 5804.753f, 34.79547f, 334.2023f),
            new Vector4(-651.668f, 6032.835f, 8.419481f, 149.8366f),
            new Vector4(-582.1682f, 6084.668f, 11.36972f, 314.1472f),
            new Vector4(-581.1f, 6132.787f, 6.969433f, 141.4738f),
            new Vector4(-382.0875f, 6149.422f, 30.79968f, 316.9517f),
            new Vector4(-403.6294f, 5960.1f, 31.55883f, 318.9879f),
            new Vector4(-398.2205f, 6022.205f, 31.35476f, 224.927f),
            new Vector4(-393.7389f, 6180.487f, 30.86421f, 43.2252f),
            new Vector4(-268.4455f, 6116.392f, 31.21086f, 135.2966f),
            new Vector4(-381.0338f, 5986.012f, 30.84723f, 316.5331f),
            new Vector4(-318.3798f, 6052.084f, 30.66547f, 314.7759f),
            new Vector4(-433.6569f, 6093.05f, 30.92295f, 159.7265f),
            new Vector4(-355.2062f, 6030.128f, 31.01284f, 135.9604f),
            new Vector4(-237.7443f, 6167.052f, 31.19286f, 35.24292f),
            new Vector4(-409.5237f, 6230.014f, 30.6019f, 356.2961f),
            new Vector4(-300.851f, 6084.546f, 31.20853f, 132.4575f),
            new Vector4(-268.9138f, 6197.978f, 31.19254f, 41.16548f),
            new Vector4(-224.7654f, 6321.034f, 30.87887f, 31.82525f),
            new Vector4(-294.5683f, 6373.133f, 30.53953f, 126.6541f),
            new Vector4(-175.5536f, 6363.71f, 31.16647f, 134.7323f),
            new Vector4(-87.6205f, 6298.627f, 31.31095f, 134.9631f),
            new Vector4(-41.74535f, 6343.886f, 30.79032f, 135.0496f),
            new Vector4(-112.0755f, 6257.965f, 30.89339f, 315.065f),
            new Vector4(24.52893f, 6573.015f, 30.96265f, 211.193f),
            new Vector4(4.485375f, 6534.486f, 30.86324f, 315.6541f),
            new Vector4(-67.39725f, 6557.658f, 30.99351f, 112.495f),
            new Vector4(-22.52643f, 6628.819f, 30.23027f, 121.5678f),
            new Vector4(-101.2837f, 6559.128f, 29.53517f, 312.7047f),
            new Vector4(122.9171f, 6508.063f, 31.03071f, 132.2929f),
            new Vector4(161.1128f, 6524.653f, 31.41261f, 304.447f),
            new Vector4(75.47453f, 6600.777f, 30.92823f, 253.3012f),
            new Vector4(209.0208f, 6562.78f, 31.67883f, 106.6951f),
            new Vector4(399.9573f, 6576.914f, 27.17046f, 86.89232f),
            new Vector4(250.8416f, 6560.39f, 30.84986f, 282.7024f),
            new Vector4(463.9428f, 6570.116f, 26.49823f, 79.92712f),
            new Vector4(346.7732f, 6577.749f, 28.445f, 90.32857f),
            new Vector4(679.4227f, 6513.324f, 27.35744f, 257.6761f),
            new Vector4(520.2579f, 6554.49f, 27.10592f, 78.02583f),
            new Vector4(576.3926f, 6546.875f, 27.46981f, 77.95992f),
            new Vector4(609.5272f, 6632.997f, 103.0839f, 270.1263f),
            new Vector4(606.0927f, 6540.441f, 27.76912f, 74.84538f),
            new Vector4(741.5576f, 6499.871f, 26.12868f, 259.2237f),
            new Vector4(793.0634f, 6492.999f, 23.44184f, 263.7165f),
            new Vector4(988.0591f, 6492.988f, 20.61488f, 88.9491f),
            new Vector4(1043.589f, 6482.221f, 20.50986f, 269.8562f),
            new Vector4(857.0443f, 6493.988f, 21.9715f, 86.06816f),
            new Vector4(932.6531f, 6489.87f, 20.6074f, 87.78609f),
            new Vector4(1111.834f, 6491.187f, 20.77577f, 77.64928f),
            new Vector4(1239.038f, 6494.546f, 20.22038f, 91.19608f),
            new Vector4(1178.839f, 6483.344f, 20.51875f, 270.9655f),
            new Vector4(1323.207f, 6494.433f, 19.54181f, 84.93928f),
            new Vector4(1539.748f, 6416.561f, 23.36984f, 247.8667f),
            new Vector4(1465.574f, 6448.59f, 21.07042f, 246.6153f),
            new Vector4(1510.966f, 6452.0f, 22.1424f, 70.68448f),
            new Vector4(1438.335f, 6468.124f, 20.32279f, 74.69832f),
            new Vector4(1578.143f, 6424.599f, 24.3475f, 67.60191f),
            new Vector4(1628.072f, 6379.682f, 28.40544f, 247.6201f),
            new Vector4(1798.051f, 6363.667f, 38.64547f, 85.3422f),
            new Vector4(1756.984f, 6372.885f, 36.48491f, 81.12927f),
            new Vector4(1845.385f, 6362.659f, 40.20943f, 80.92149f),
            new Vector4(1894.978f, 6347.897f, 41.65322f, 66.03777f),
            new Vector4(1720.974f, 6349.555f, 33.94143f, 254.245f),
            new Vector4(1763.519f, 6339.942f, 36.35273f, 261.1383f),
            new Vector4(1662.588f, 6366.085f, 30.24022f, 251.7635f),
            new Vector4(2036.84f, 6162.549f, 47.99726f, 35.42499f),
            new Vector4(1955.323f, 6217.857f, 43.93726f, 202.0297f),
            new Vector4(1968.733f, 6290.198f, 44.21726f, 30.65921f),
            new Vector4(2030.812f, 6104.072f, 47.86931f, 225.3232f),
            new Vector4(2060.277f, 6136.68f, 48.81021f, 44.34423f),
            new Vector4(2008.43f, 6127.204f, 46.66328f, 222.8629f),
            new Vector4(2176.343f, 6059.542f, 51.63663f, 66.988f),
            new Vector4(2145.438f, 6068.151f, 51.73346f, 65.39436f),
            new Vector4(2260.289f, 5982.492f, 50.44656f, 34.0249f),
            new Vector4(2254.826f, 5915.042f, 49.02f, 225.9567f),
            new Vector4(2383.899f, 5821.332f, 46.08446f, 31.84397f),
            new Vector4(2374.074f, 5759.041f, 45.38128f, 211.5502f),
            new Vector4(2407.503f, 5778.444f, 45.31376f, 29.10253f),
            new Vector4(2421.142f, 5686.237f, 45.22676f, 206.9504f),
            new Vector4(2331.356f, 5830.062f, 46.50668f, 218.6143f),
            new Vector4(2348.526f, 5873.231f, 46.95246f, 36.17857f),
            new Vector4(2394.802f, 5723.769f, 45.00942f, 209.1496f),
            new Vector4(2488.291f, 5534.633f, 44.25416f, 201.3789f),
            new Vector4(2532.072f, 5404.458f, 44.1527f, 195.5615f),
            new Vector4(2459.729f, 5603.196f, 44.91294f, 203.4772f),
            new Vector4(2508.671f, 5464.938f, 44.03527f, 198.3038f),
            new Vector4(2522.418f, 5520.553f, 44.21039f, 19.9834f),
            new Vector4(2491.975f, 5585.403f, 44.47052f, 21.82102f),
            new Vector4(2540.59f, 5464.742f, 44.05755f, 18.22826f),
            new Vector4(2593.609f, 5151.142f, 44.14622f, 194.7047f),
            new Vector4(2615.036f, 5217.875f, 44.42789f, 18.63502f),
            new Vector4(2564.483f, 5280.634f, 44.2732f, 194.255f),
            new Vector4(2542.798f, 5347.226f, 44.07043f, 194.6707f),
            new Vector4(2585.992f, 5182.318f, 44.45719f, 195.1674f),
            new Vector4(2593.876f, 5289.408f, 44.11114f, 16.52709f),
            new Vector4(2583.608f, 5327.186f, 44.09462f, 16.51184f),
            new Vector4(2574.285f, 5243.394f, 44.2133f, 194.3261f),
            new Vector4(2721.316f, 5108.226f, 43.42286f, 210.9976f),
            new Vector4(2874.032f, 5029.679f, 31.24694f, 116.796f),
            new Vector4(2741.089f, 5030.99f, 38.63887f, 12.7612f),
            new Vector4(3201.638f, 5026.788f, 20.32933f, 69.37776f),
            new Vector4(3002.698f, 5047.373f, 27.47815f, 87.12064f),
            new Vector4(3442.015f, 4858.132f, 34.5517f, 27.98956f),
            new Vector4(3316.726f, 4984.915f, 25.54807f, 59.30244f),
            new Vector4(3043.897f, 4100.275f, 62.70562f, 18.69939f),
            new Vector4(2884.664f, 4085.555f, 50.1775f, 196.0299f),
            new Vector4(2879.978f, 4181.621f, 49.69279f, 18.80676f),
            new Vector4(2897.774f, 4051.036f, 50.39009f, 194.0704f),
            new Vector4(2891.82f, 4145.313f, 49.8238f, 18.19963f),
            new Vector4(2866.662f, 4234.511f, 49.54145f, 17.51316f),
            new Vector4(2862.606f, 4153.779f, 49.69168f, 198.5296f),
            new Vector4(2745.146f, 4391.339f, 48.4435f, 287.5675f),
            new Vector4(2845.316f, 4287.634f, 49.73956f, 17.69997f),
            new Vector4(2805.65f, 4415.423f, 48.66005f, 16.54485f),
            new Vector4(2842.738f, 4318.556f, 49.60687f, 5.402305f),
            new Vector4(2833.872f, 4234.192f, 49.64071f, 202.4114f),
            new Vector4(2777.381f, 4387.58f, 48.72691f, 195.4392f),
            new Vector4(2766.726f, 4427.365f, 47.83334f, 194.7608f),
            new Vector4(2800.429f, 4317.775f, 50.02152f, 199.8358f),
            new Vector4(2774.615f, 4524.818f, 46.32243f, 15.44765f),
            new Vector4(2736.954f, 4568.342f, 45.54398f, 189.5076f),
            new Vector4(2765.543f, 4579.108f, 45.10992f, 14.84976f),
            new Vector4(2742.754f, 4515.97f, 46.14607f, 193.2392f),
            new Vector4(2759.353f, 4469.702f, 47.04062f, 195.1027f),
            new Vector4(2430.792f, 4609.335f, 36.39118f, 223.946f),
            new Vector4(2470.023f, 4551.393f, 35.367f, 24.92611f),
            new Vector4(2498.197f, 4657.336f, 33.35616f, 135.272f),
            new Vector4(2481.619f, 4486.189f, 34.46214f, 184.0269f),
            new Vector4(2340.501f, 4707.327f, 35.50082f, 55.24286f),
            new Vector4(2219.803f, 4742.607f, 40.11759f, 78.31033f),
            new Vector4(2395.463f, 4646.753f, 36.2328f, 224.0265f),
            new Vector4(2108.362f, 4976.017f, 40.53662f, 44.99704f),
            new Vector4(2199.565f, 4943.499f, 40.73083f, 134.6188f),
            new Vector4(2182.04f, 4900.64f, 40.73156f, 43.24684f),
            new Vector4(1911.174f, 5133.907f, 44.34512f, 303.4811f),
            new Vector4(2060.499f, 5025.061f, 40.58274f, 42.09028f),
            new Vector4(2003.999f, 5168.1f, 46.60292f, 128.1665f),
            new Vector4(1881.213f, 5118.195f, 47.46408f, 127.7084f),
            new Vector4(2007.328f, 5078.551f, 42.06587f, 220.2917f),
            new Vector4(1846.902f, 5084.345f, 53.95401f, 309.3155f),
            new Vector4(1740.238f, 4987.34f, 47.41873f, 311.8548f),
            new Vector4(1679.783f, 4772.983f, 41.60228f, 8.129597f),
            new Vector4(1667.346f, 4844.721f, 41.76116f, 187.2528f),
            new Vector4(1943.575f, 4593.15f, 39.18748f, 284.9565f),
            new Vector4(1833.855f, 4575.043f, 35.67528f, 277.7674f),
            new Vector4(1893.633f, 4730.08f, 40.92976f, 24.78538f),
            new Vector4(1985.06f, 4609.715f, 40.66785f, 299.8128f),
            new Vector4(1901.558f, 4585.324f, 36.92405f, 279.4448f),
            new Vector4(1779.135f, 4569.985f, 37.09515f, 268.4801f),
            new Vector4(1629.009f, 4569.781f, 44.55161f, 268.1953f),
            new Vector4(1465.007f, 4506.614f, 50.52093f, 111.2581f),
            new Vector4(1547.627f, 4560.717f, 50.37349f, 294.879f),
            new Vector4(1409.672f, 4495.323f, 50.75882f, 89.08591f),
            new Vector4(1220.743f, 4463.449f, 54.10463f, 117.2646f),
            new Vector4(1334.664f, 4481.293f, 60.03261f, 137.2453f),
            new Vector4(1183.003f, 4431.697f, 57.64005f, 130.1531f),
            new Vector4(1091.776f, 4433.074f, 61.89602f, 237.8445f),
            new Vector4(835.5986f, 4391.31f, 51.69059f, 12.65068f),
            new Vector4(782.9872f, 4228.477f, 51.3567f, 278.7312f),
            new Vector4(670.5818f, 4240.214f, 54.6224f, 273.3176f),
            new Vector4(383.328f, 4436.347f, 62.35472f, 22.72325f),
            new Vector4(-0.3916552f, 4451.016f, 58.39985f, 103.6812f),
            new Vector4(-62.18644f, 4370.14f, 53.70876f, 347.2308f),
            new Vector4(-141.0932f, 4267.354f, 44.48914f, 313.7501f),
            new Vector4(-268.4115f, 3940.884f, 41.92686f, 41.71815f),
            new Vector4(41.21559f, 3611.496f, 39.25893f, 272.8996f),
            new Vector4(102.6349f, 3501.609f, 39.23885f, 330.5204f),
            new Vector4(219.3753f, 3154.472f, 41.89846f, 1.705356f),
            new Vector4(233.6105f, 3311.029f, 40.06429f, 343.1833f),
            new Vector4(559.6335f, 3576.388f, 32.48417f, 87.48158f),
            new Vector4(828.5527f, 3625.088f, 32.58926f, 286.1225f),
            new Vector4(712.0542f, 3584.751f, 32.66648f, 281.3927f),
            new Vector4(647.3332f, 3578.993f, 32.46778f, 97.45536f),
            new Vector4(745.8648f, 3598.898f, 32.49276f, 110.7987f),
            new Vector4(883.0028f, 3630.246f, 32.52864f, 269.3952f),
            new Vector4(962.9246f, 3634.774f, 31.91181f, 88.30496f),
            new Vector4(925.8058f, 3572.866f, 33.14218f, 180.4803f),
            new Vector4(1088.235f, 3630.286f, 33.48642f, 87.12433f),
            new Vector4(1350.831f, 3525.492f, 35.03093f, 77.35992f),
            new Vector4(1304.542f, 3647.821f, 32.66026f, 289.6967f),
            new Vector4(1234.168f, 3633.289f, 33.03377f, 102.1602f),
            new Vector4(1191.825f, 3621.697f, 33.27175f, 272.8768f),
            new Vector4(1556.499f, 3478.709f, 36.04647f, 264.4496f),
            new Vector4(1651.311f, 3484.38f, 36.08405f, 283.8114f),
            new Vector4(1606.873f, 3665.029f, 33.9831f, 189.8345f),
            new Vector4(1644.129f, 3835.672f, 34.4307f, 314.1047f),
            new Vector4(1685.9f, 3876.756f, 34.31292f, 313.6588f),
            new Vector4(1993.732f, 3844.809f, 32.12075f, 30.31729f),
            new Vector4(2238.351f, 3825.298f, 33.55273f, 119.8166f),
            new Vector4(2359.6f, 3895.097f, 34.83923f, 307.0748f),
            new Vector4(2450.693f, 3997.771f, 36.53984f, 329.1966f),
            new Vector4(2450.841f, 4235.743f, 36.54277f, 9.79839f),
            new Vector4(2471.359f, 4037.717f, 37.01623f, 334.9306f),
            new Vector4(2466.268f, 4173.652f, 36.96056f, 207.9115f),
            new Vector4(2557.39f, 4217.382f, 40.6874f, 148.172f),
            new Vector4(2497.678f, 4134.937f, 38.1741f, 235.7664f),
            new Vector4(2528.408f, 4168.993f, 39.1332f, 149.8543f),
            new Vector4(2326.97f, 3870.248f, 34.62669f, 302.6036f),
            new Vector4(1972.485f, 3297.682f, 45.02592f, 46.60917f),
            new Vector4(2245.929f, 3202.322f, 47.91808f, 194.5003f),
            new Vector4(2180.262f, 3253.565f, 46.90892f, 78.09666f),
            new Vector4(1879.367f, 3212.875f, 45.33972f, 40.12511f),
            new Vector4(1858.602f, 3304.811f, 42.87251f, 288.8463f),
            new Vector4(1850.248f, 3250.533f, 44.34697f, 35.14809f),
            new Vector4(1914.994f, 3167.601f, 46.55781f, 226.1504f),
            new Vector4(1703.373f, 3504.137f, 35.91473f, 31.07814f),
            new Vector4(1763.472f, 3549.792f, 35.71498f, 120.3492f),
            new Vector4(1774.223f, 3366.48f, 39.34251f, 209.0754f),
            new Vector4(1728.324f, 3458.769f, 38.70145f, 29.74847f)
        };
        */
        public static readonly List<Vector4> CayoVhPoint = new List<Vector4>{
		    new Vector4(5151.242f, -4988.032f, 11.07006f, 330.7662f),
		    new Vector4(5234.622f, -5044.32f, 14.78756f, 217.541f),
		    new Vector4(5395.034f, -5117.525f, 12.82211f, 260.8773f),
		    new Vector4(5480.951f, -5154.387f, 13.003f, 243.3344f),
		    new Vector4(5422.944f, -5336.357f, 29.1772f, 184.6251f),
		    new Vector4(5371.362f, -5443.372f, 47.44936f, 103.1909f),
		    new Vector4(5334.503f, -5356.212f, 39.44836f, 42.72601f),
		    new Vector4(5379.229f, -5581.523f, 51.64316f, 16.55149f),
		    new Vector4(5250.379f, -5440.512f, 63.21391f, 46.61808f),
		    new Vector4(5158.693f, -5564.97f, 41.48776f, 115.0785f),
		    new Vector4(4951.867f, -5668.801f, 20.83409f, 315.0575f),
		    new Vector4(5020.304f, -5659.498f, 19.54258f, 80.51956f),
		    new Vector4(4790.595f, -5569.141f, 23.19196f, 258.7796f),
		    new Vector4(4930.438f, -5462.304f, 30.63404f, 138.0855f),
		    new Vector4(4940.436f, -5306.102f, 5.363968f, 354.3278f),
		    new Vector4(4955.303f, -5191.416f, 1.901235f, 289.481f),
		    new Vector4(5062.519f, -5233.131f, 4.048297f, 201.6604f),
		    new Vector4(5165.552f, -5163.518f, 1.599737f, 0.206256f),
		    new Vector4(5140.043f, -5144.51f, 1.572914f, 267.457f),
		    new Vector4(5160.295f, -5081.718f, 2.027128f, 12.37001f),
		    new Vector4(5227.267f, -5128.13f, 6.823656f, 196.9126f),
		    new Vector4(5043.173f, -4884.606f, 14.96475f, 57.48603f),
		    new Vector4(4995.452f, -4753.767f, 12.47045f, 343.0041f),
		    new Vector4(4976.23f, -4700.542f, 7.567879f, 323.5304f),
		    new Vector4(5077.751f, -4680.26f, 2.163868f, 55.20174f),
		    new Vector4(5124.599f, -4623.691f, 2.020308f, 252.7671f),
		    new Vector4(5132.404f, -4582.143f, 4.136497f, 42.58467f),
		    new Vector4(4969.585f, -4511.583f, 8.316021f, 59.19208f),
		    new Vector4(4863.543f, -4406.074f, 6.154335f, 177.9412f),
		    new Vector4(4642.67f, -4471.657f, 3.802634f, 101.2704f),
		    new Vector4(4509.105f, -4608.875f, 7.677932f, 28.56013f)
        };
        public static FubarVectors PickUpApartmentBlocks(int iArea, int iType, bool bCorDrop)
        {
            LoggerLight.LogThis("PickUpApartmentBlocks, iArea == " + iArea + ", iType == " + iType + ", bCorDrop == " + bCorDrop);
            FubarVectors yourApp = null;
            Vector3 Here = Game.Player.Character.Position;
            float fDis = 9999.99f;
            int iPos = 0;
            int iRem = 0;

            if (iArea == 1)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock01", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01ax", 0, TruckStop01.Count - 1);
                    for (int i = 0;i < iList.Count; i++)
                    {
                        float f = TruckStop01[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01ax", iList);
                    Truckers TC = TruckStop01[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }                // TruckStop
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01a", 0, Area_01_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01a", iList);
                    yourApp = Area_01_BikerBiz[iPos];
             
                }           //BikerGrove
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01b", 0, Area_01_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01b", iList);
                    yourApp = Area_01_BunkerWare[iPos];
                }           //WhereHose
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01c", 0, Area_01_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01c", iList);
                    yourApp = Area_01_OpenDoors[iPos];
                }           //ShopsWithDoors
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01d", 0, Area_01_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01d", iList);
                    yourApp = Area_01_Resurant[iPos];
                }           //DeliverHow
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01e", 0, Area_01_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01e", iList);
                    yourApp = Area_01_Lesure[iPos];
                }           //ClubsParks
                else if (iType == 6)
                {
                    int iApps = RandomX.FindRandom("AppBlock01f", 1, 2);

                    if (iApps == 1)
                    {
                        int iRand = RandomX.FindRandom("AppBlock01f1", 0, 2);

                        if (iRand == 0)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor00[RandomX.FindRandom("AppBlock01f01", 0, Area_01_MotelDoor00.Count - 1)], "Bilingsgate Motel", 6);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor01[RandomX.FindRandom("AppBlock01f02", 0, Area_01_MotelDoor01.Count - 1)], "Rancho Motel", 6);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor02[RandomX.FindRandom("AppBlock01f03", 0, Area_01_MotelDoor02.Count - 1)], "Rancho Motel", 6);
                    }
                    else
                    {
                        int iRand = RandomX.FindRandom("AppBlock01f2", 0, Area_01_Hotel.Count - 1);
                        yourApp = Area_01_Hotel[iRand];
                    }
                }           //HotelMotelHolidayInn
                else if (iType == 7)
                {
                    int iRand = RandomX.FindRandom("AppBlock01g2", 0, 34);

                    if (iRand == 0)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor00[RandomX.FindRandom("AppBlock01g01", 0, Area_01_AppDoor00.Count - 1)], "", 50);
                    else if (iRand == 1)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor01[RandomX.FindRandom("AppBlock01g02", 0, Area_01_AppDoor01.Count - 1)], "", 50);
                    else if (iRand == 2)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor02[RandomX.FindRandom("AppBlock01g03", 0, Area_01_AppDoor02.Count - 1)], "", 50);
                    else if (iRand == 3)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor03[RandomX.FindRandom("AppBlock01g04", 0, Area_01_AppDoor03.Count - 1)], "", 50);
                    else if (iRand == 4)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor04[RandomX.FindRandom("AppBlock01g05", 0, Area_01_AppDoor04.Count - 1)], "", 50);
                    else if (iRand == 5)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor05[RandomX.FindRandom("AppBlock01g06", 0, Area_01_AppDoor05.Count - 1)], "", 50);
                    else if (iRand == 6)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor06[RandomX.FindRandom("AppBlock01g07", 0, Area_01_AppDoor06.Count - 1)], "", 50);
                    else if (iRand == 7)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor07[RandomX.FindRandom("AppBlock01g08", 0, Area_01_AppDoor07.Count - 1)], "", 50);
                    else if (iRand == 8)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor08[RandomX.FindRandom("AppBlock01g09", 0, Area_01_AppDoor08.Count - 1)], "", 50);
                    else if (iRand == 9)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor09[RandomX.FindRandom("AppBlock01g10", 0, Area_01_AppDoor09.Count - 1)], "", 50);
                    else if (iRand == 10)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor10[RandomX.FindRandom("AppBlock01g11", 0, Area_01_AppDoor10.Count - 1)], "", 50);
                    else if (iRand == 11)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor11[RandomX.FindRandom("AppBlock01g12", 0, Area_01_AppDoor11.Count - 1)], "", 50);
                    else if (iRand == 12)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor12[RandomX.FindRandom("AppBlock01g13", 0, Area_01_AppDoor12.Count - 1)], "", 50);
                    else if (iRand == 13)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor13[RandomX.FindRandom("AppBlock01g14", 0, Area_01_AppDoor13.Count - 1)], "", 50);
                    else if (iRand == 14)//GetsBlocked top flat..
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor14[RandomX.FindRandom("AppBlock01g15", 0, Area_01_AppDoor14.Count - 1)], "", 50);
                    else if (iRand == 15)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor15[RandomX.FindRandom("AppBlock01g16", 0, Area_01_AppDoor15.Count - 1)], "", 50);
                    else if (iRand == 16)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor16[RandomX.FindRandom("AppBlock01g17", 0, Area_01_AppDoor16.Count - 1)], "", 50);
                    else if (iRand == 17)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor17[RandomX.FindRandom("AppBlock01g18", 0, Area_01_AppDoor17.Count - 1)], "", 50);
                    else
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock01g19", 0, Area_01_Houses.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_01_Houses[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock01g19", iList);
                        yourApp = Area_01_Houses[iPos];
                    }
                }           //AppHouse
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01h", 0, Area_01_ORP.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_ORP[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01h", iList);
                    yourApp = Area_01_ORP[iPos];
                }           //OffRoadParking
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01i", 0, Area_01_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_01_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01i", iList);
                    yourApp = Area_01_OnineApps[iPos];
                }           //PlayHouses
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01j", 0, HospArea01.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea01[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01j", iList);

                    yourApp = new FubarVectors(iArea, HospArea01[iPos], HospArea01[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock01k", 0, BinFire01.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire01[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock01k", iList);

                    yourApp = new FubarVectors(iArea, BinFire01[iPos], BinFire01[iPos], "", 0);
                }       //BinPick
            }
            else if (iArea == 2)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock02", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02ax", 0, TruckStop02.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop02[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02ax", iList);
                    Truckers TC = TruckStop02[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02a", 0, Area_02_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02a", iList);
                    yourApp = Area_02_BikerBiz[iPos];
                }
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02b", 0, Area_02_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02b", iList);
                    yourApp = Area_02_BunkerWare[iPos];
                }
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02c", 0, Area_02_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02c", iList);
                    yourApp = Area_02_OpenDoors[iPos];
                }
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02d", 0, Area_02_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02d", iList);
                    yourApp = Area_02_Resurant[iPos];
                }
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02e", 0, Area_02_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02e", iList);
                    yourApp = Area_02_Lesure[iPos];
                }
                else if (iType == 6)
                {
                    int iApps = RandomX.FindRandom("AppBlock02f", 1, 2);

                    if (iApps == 1)
                    {
                        int iRand = RandomX.FindRandom("AppBlock02f1", 0, 3);

                        if (iRand == 0)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor00[RandomX.FindRandom("AppBlock02f01", 0, Area_02_MotelDoor00.Count - 1)], "", 6);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor01[RandomX.FindRandom("AppBlock02f02", 0, Area_02_MotelDoor01.Count - 1)], "", 6);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor02[RandomX.FindRandom("AppBlock02f02", 0, Area_02_MotelDoor02.Count - 1)], "", 6);
                        else if (iRand == 3)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor03[RandomX.FindRandom("AppBlock02f03", 0, Area_02_MotelDoor03.Count - 1)], "", 6);
                    }
                    else
                    {
                        int iRand = RandomX.FindRandom("AppBlock02f2", 0, Area_02_Hotel.Count - 1);
                        yourApp = Area_02_Hotel[iRand];
                    }
                }
                else if (iType == 7)
                {
                    int iApps = RandomX.FindRandom("AppBlock02g", 1, 2);

                    if (iApps == 1)
                    {
                        int iRand = RandomX.FindRandom("AppBlock02g1", 0, 2);

                        if (iRand == 0)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor00[RandomX.FindRandom("AppBlock02g01", 0, Area_02_AppDoor00.Count - 1)], "", 50);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor01[RandomX.FindRandom("AppBlock02g02", 0, Area_02_AppDoor01.Count - 1)], "", 50);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor02[RandomX.FindRandom("AppBlock02g03", 0, Area_02_AppDoor02.Count - 1)], "", 50);
                    }
                    else if (iApps == 2)
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock02g2", 0, Area_02_Houses01.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_02_Houses01[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock02g2", iList);
                        yourApp = Area_02_Houses01[iPos];
                    }
                }
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02h", 0, Area_02_ORP01.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_ORP01[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02h", iList);
                    yourApp = Area_02_ORP01[iPos];
                }
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02i", 0, Area_02_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_02_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02i", iList);
                    yourApp = Area_02_OnineApps[iPos];
                }
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02j", 0, HospArea02.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea02[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02j", iList);
                    yourApp = new FubarVectors(iArea, HospArea02[iPos], HospArea02[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock02k", 0, BinFire02.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire02[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock02k", iList);
                    yourApp = new FubarVectors(iArea, BinFire02[iPos], BinFire02[iPos], "", 0);
                }       //BinPick
                else if (iType == 15)
                {
                    int iRand = RandomX.FindRandom("AppBlock02l", 0, Offices.Count - 1);
                    yourApp = Offices[iRand];
                }
            }
            else if (iArea == 3)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock03", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03ax", 0, TruckStop03.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop03[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03ax", iList);
                    Truckers TC = TruckStop03[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03a", 0, Area_03_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03a", iList);
                    yourApp = Area_03_BikerBiz[iPos];
                }
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03b", 0, Area_03_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03b", iList);
                    yourApp = Area_03_BunkerWare[iPos];
                }
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03c", 0, Area_03_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03c", iList);
                    yourApp = Area_03_OpenDoors[iPos];
                }
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03d", 0, Area_03_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03d", iList);
                    yourApp = Area_03_Resurant[iPos];
                }
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03e", 0, Area_03_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03e", iList);
                    yourApp = Area_03_Lesure[iPos];
                }
                else if (iType == 6)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03f", 0, Area_03_Hotel.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_Hotel[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03f", iList);
                    yourApp = Area_03_Hotel[iPos];
                }
                else if (iType == 7)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03g", 0, Area_03_Houses.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_Houses[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03g", iList);
                    yourApp = Area_03_Houses[iPos];
                }
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03h", 0, Area_03_ORP.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_ORP[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03h", iList);
                    yourApp = Area_03_ORP[iPos];
                }
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03i", 0, Area_03_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03i", iList);
                    yourApp = Area_03_OnineApps[iPos];
                }
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03j", 0, HospArea03.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea03[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03j", iList);
                    yourApp = new FubarVectors(iArea, HospArea03[iPos], HospArea03[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03k", 0, BinFire03.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire03[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03k", iList);
                    yourApp = new FubarVectors(iArea, BinFire03[iPos], BinFire03[iPos], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock03l", 0, Area_03_Facility.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_03_Facility[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock03l", iList);
                    yourApp = Area_03_Facility[iPos];
                }
            }
            else if (iArea == 4)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock04", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04ax", 0, TruckStop04.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop04[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04ax", iList);
                    Truckers TC = TruckStop04[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04a", 0, Area_04_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04a", iList);
                    yourApp = Area_04_BikerBiz[iPos];
                }
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04b", 0, Area_04_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04b", iList);
                    yourApp = Area_04_BunkerWare[iPos];
                }
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04c", 0, Area_04_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04c", iList);
                    yourApp = Area_04_OpenDoors[iPos];
                }
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04d", 0, Area_04_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04d", iList);
                    yourApp = Area_04_Resurant[iPos];
                }
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04e", 0, Area_04_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04e", iList);
                    yourApp = Area_04_Lesure[iPos];
                }
                else if (iType == 6)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04f", 0, Area_04_Hotel.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_Hotel[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04f", iList);
                    yourApp = Area_04_Hotel[iPos];
                }
                else if (iType == 7)
                {
                    int iApps = RandomX.FindRandom("AppBlock04g", 1, 2);

                    if (iApps == 1)
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock04g1", 0, Area_04_Houses01.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_04_Houses01[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock04g1", iList);
                        yourApp = Area_04_Houses01[iPos];
                    }
                    else
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock04g2", 0, Area_04_Trailer.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_04_Trailer[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock04g2", iList);
                        yourApp = Area_04_Trailer[iPos];
                    }
                }
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04h", 0, Area_04_ORP01.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_ORP01[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04h", iList);
                    yourApp = Area_04_ORP01[iPos];
                }
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04i", 0, Area_04_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_04_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04i", iList);
                    yourApp = Area_04_OnineApps[iPos];
                }
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04j", 0, HospArea04.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea04[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04j", iList);
                    yourApp = new FubarVectors(iArea, HospArea04[iPos], HospArea04[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock04k", 0, BinFire04.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire04[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock04k", iList);
                    yourApp = new FubarVectors(iArea, BinFire04[iPos], BinFire04[iPos], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    int iRand = RandomX.FindRandom("AppBlock04l", 0, Area_04_Facility.Count - 1);
                    yourApp = Area_04_Facility[iRand];
                }
            }
            else if (iArea == 5)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock05", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05ax", 0, TruckStop05.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop05[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05ax", iList);
                    Truckers TC = TruckStop05[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05a", 0, Area_05_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05a", iList);
                    yourApp = Area_05_BikerBiz[iPos];
                }
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05b", 0, Area_05_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05b", iList);
                    yourApp = Area_05_BunkerWare[iPos];
                }
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05c", 0, Area_05_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05c", iList);
                    yourApp = Area_05_OpenDoors[iPos];
                }
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05d", 0, Area_05_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05d", iList);
                    yourApp = Area_05_Resurant[iPos];
                }
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05e", 0, Area_05_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05e", iList);
                    yourApp = Area_05_Lesure[iPos];
                }
                else if (iType == 6)
                {
                    int iRand = RandomX.FindRandom("AppBlock05f", 0, 1);

                    if (iRand == 0)
                        yourApp = new FubarVectors(5, Area_05_MotelPark[iRand], Area_05_MotelDoor00[RandomX.FindRandom("AppBlock05f01", 0, Area_05_MotelDoor00.Count - 1)], "", 6);
                    else
                        yourApp = new FubarVectors(5, Area_05_MotelPark[iRand], Area_05_MotelDoor01[RandomX.FindRandom("AppBlock05f02", 0, Area_05_MotelDoor01.Count - 1)], "", 6);
                }
                else if (iType == 7)
                {
                    int iApps = RandomX.FindRandom("AppBlock05g", 1, 2);

                    if (iApps == 1)
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock05g1", 0, Area_05_Houses01.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_05_Houses01[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock05g1", iList);
                        yourApp = Area_05_Houses01[iPos];
                    }
                    else
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock05g2", 0, Area_05_Trailer.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_05_Trailer[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock05g2", iList);
                        yourApp = Area_05_Trailer[iPos];
                    }
                }
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05h", 0, Area_05_ORP01.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_ORP01[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05h", iList);
                    yourApp = Area_05_ORP01[iPos];
                }
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05i", 0, Area_05_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_05_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05i", iList);
                    yourApp = Area_05_OnineApps[iPos];
                }
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05j", 0, HospArea05.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea05[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05j", iList);
                    yourApp = new FubarVectors(iArea, HospArea05[iPos], HospArea05[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock05k", 0, BinFire05.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire05[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock05k", iList);
                    yourApp = new FubarVectors(iArea, BinFire05[iPos], BinFire05[iPos], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    int iRand = RandomX.FindRandom("AppBlock05l", 0, Area_05_Facility.Count - 1);
                    yourApp = Area_05_Facility[iRand];
                }
            }
            else if (iArea == 6)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock06", 0, 9);

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06ax", 0, TruckStop06.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop06[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06ax", iList);
                    Truckers TC = TruckStop06[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 1)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06a", 0, Area_06_BikerBiz.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_BikerBiz[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06a", iList);
                    yourApp = Area_06_BikerBiz[iPos];
                }
                else if (iType == 2)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06b", 0, Area_06_BunkerWare.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_BunkerWare[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06b", iList);
                    yourApp = Area_06_BunkerWare[iPos];
                }
                else if (iType == 3)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06c", 0, Area_06_OpenDoors.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_OpenDoors[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06c", iList);
                    yourApp = Area_06_OpenDoors[iPos];
                }
                else if (iType == 4)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06d", 0, Area_06_Resurant.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_Resurant[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06d", iList);
                    yourApp = Area_06_Resurant[iPos];
                }
                else if (iType == 5)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06e", 0, Area_06_Lesure.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_Lesure[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06e", iList);
                    yourApp = Area_06_Lesure[iPos];
                }
                else if (iType == 6)
                {
                    int iRand = RandomX.FindRandom("AppBlock06f", 0, 1);

                    if (iRand == 0)
                        yourApp = new FubarVectors(6, Area_06_MotelPark[iRand], Area_06_MotelDoor00[RandomX.FindRandom("AppBlock06f01", 0, Area_06_MotelDoor00.Count - 1)], "", 6);
                    else
                        yourApp = new FubarVectors(6, Area_06_MotelPark[iRand], Area_06_MotelDoor01[RandomX.FindRandom("AppBlock06f02", 0, Area_06_MotelDoor01.Count - 1)], "", 6);
                }
                else if (iType == 7)
                {
                    int iApps = RandomX.FindRandom("AppBlock06g", 1, 2);

                    if (iApps == 1)
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock06g1", 0, Area_06_Houses.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_06_Houses[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock06g1", iList);
                        yourApp = Area_06_Houses[iPos];
                    }
                    else
                    {
                        List<int> iList = RandomX.ReturnRandList("AppBlock06g2", 0, Area_06_Trailer.Count - 1);
                        for (int i = 0; i < iList.Count; i++)
                        {
                            float f = Area_06_Trailer[iList[i]].ParkHere.V3.DistanceTo(Here);
                            if (f < fDis)
                            {
                                fDis = f;
                                iPos = iList[i];
                                iRem = i;
                            }
                        }
                        iList.RemoveAt(iRem);

                        RandomX.ReWiteXml("AppBlock06g2", iList);
                        yourApp = Area_06_Trailer[iPos];
                    }
                }
                else if (iType == 8)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06h", 0, Area_06_ORP.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_ORP[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06h", iList);
                    yourApp = Area_06_ORP[iPos];
                }
                else if (iType == 9)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06i", 0, Area_06_OnineApps.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = Area_06_OnineApps[iList[i]].ParkHere.V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06i", iList);
                    yourApp = Area_06_OnineApps[iPos];
                }
                else if (iType == 10)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06j", 0, HospArea06.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = HospArea06[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06j", iList);
                    yourApp = new FubarVectors(iArea, HospArea06[iPos], HospArea06[iPos], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock06k", 0, BinFire06.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = BinFire06[iList[i]].V3.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock06k", iList);
                    yourApp = new FubarVectors(iArea, BinFire06[iPos], BinFire06[iPos], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    int iRand = RandomX.FindRandom("AppBlock06l", 0, Area_06_Facility.Count - 1);
                    yourApp = Area_06_Facility[iRand];
                }
            }
            else if (iArea == 8)
            {
                if (iType < 0)
                    iType = RandomX.FindRandomList("AppBlock08", new List<int> { 0, 4, 5, 9 });

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock08ax", 0, TruckStop08.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop08[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock08ax", iList);
                    Truckers TC = TruckStop08[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 4)
                {
                    int iRand = RandomX.FindRandom("AppBlock08d", 0, Area_08_Resurant.Count - 1);
                    yourApp = Area_08_Resurant[iRand];
                }           //DeliverHow
                else if (iType == 5)
                {
                    int iRand = RandomX.FindRandom("AppBlock08e", 0, Area_08_Lesure.Count - 1);
                    yourApp = Area_08_Lesure[iRand];
                }           //ClubsParks
                else
                {
                    int iRand = RandomX.FindRandom("AppBlock08g1", 0, Area_08_Houses.Count - 1);
                    yourApp = Area_08_Houses[iRand];
                }           //PlayHouses
            }
            else if (iArea == 9)
            {
                if (iType < 0)
                    iType = RandomX.FindRandomList("AppBlock09", new List<int> { 0, 4, 5, 9 });

                if (iType == 0)
                {
                    List<int> iList = RandomX.ReturnRandList("AppBlock09ax", 0, TruckStop09.Count - 1);
                    for (int i = 0; i < iList.Count; i++)
                    {
                        float f = TruckStop09[iList[i]].FuStop.DistanceTo(Here);
                        if (f < fDis)
                        {
                            fDis = f;
                            iPos = iList[i];
                            iRem = i;
                        }
                    }
                    iList.RemoveAt(iRem);

                    RandomX.ReWiteXml("AppBlock09ax", iList);
                    Truckers TC = TruckStop09[iPos];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 4)
                {
                    int iRand = RandomX.FindRandom("AppBlock09d", 0, Area_09_Resurant.Count - 1);
                    yourApp = Area_09_Resurant[iRand];
                }           //DeliverHow
                else if (iType == 5)
                {
                    int iRand = RandomX.FindRandom("AppBlock09e", 0, Area_09_Lesure.Count - 1);
                    yourApp = Area_09_Lesure[iRand];
                }           //ClubsParks
                else
                {
                    int iRand = RandomX.FindRandom("AppBlock09g1", 0, Area_09_Houses.Count - 1);
                    yourApp = Area_09_Houses[iRand];
                }           //PlayHouses
            }

            if (bCorDrop)
            {
                Vector4 fIt = new Vector4(yourApp.ParkHere.X, yourApp.ParkHere.Y, yourApp.ParkHere.Z - 0.5f, yourApp.ParkHere.R);
                yourApp.ParkHere = fIt;
            }

            return yourApp;
        }
        public static FubarVectors AppartmentBlocks(int iArea, int iType, int iRand, int iApps, bool bCorDrop)
        {
            LoggerLight.LogThis("AppartmentBlocks, iArea == " + iArea + ", iType ==" + iType + ", iRand ==" + iRand + ", iApps ==" + iApps + ", bCorDrop ==" + bCorDrop);
            FubarVectors yourApp = null;

            if (iArea == 1)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock01", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop01.Count)
                        iRand = RandomX.FindRandom("AppBlock01ax", 0, TruckStop01.Count - 1);
                    Truckers TC = TruckStop01[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }                // TruckStop
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_01_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock01a", 0, Area_01_BikerBiz.Count - 1);
                    yourApp = Area_01_BikerBiz[iRand];
                }           //BikerGrove
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_01_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock01b", 0, Area_01_BunkerWare.Count - 1);
                    yourApp = Area_01_BunkerWare[iRand];
                }           //WhereHose
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_01_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock01c", 0, Area_01_OpenDoors.Count - 1);
                    yourApp = Area_01_OpenDoors[iRand];
                }           //ShopsWithDoors
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_01_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock01d", 0, Area_01_Resurant.Count - 1);
                    yourApp = Area_01_Resurant[iRand];
                }           //DeliverHow
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_01_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock01e", 0, Area_01_Lesure.Count - 1);
                    yourApp = Area_01_Lesure[iRand];
                }           //ClubsParks
                else if (iType == 6)
                {
                    if (iApps == -1 || iApps > 2)
                        iApps = RandomX.FindRandom("AppBlock01f", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand > 2)
                            iRand = RandomX.FindRandom("AppBlock01f1", 0, 2);

                        if (iRand == 0)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor00[RandomX.FindRandom("AppBlock01f01", 0, Area_01_MotelDoor00.Count - 1)], "Bilingsgate Motel", 6);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor01[RandomX.FindRandom("AppBlock01f02", 0, Area_01_MotelDoor01.Count - 1)], "Rancho Motel", 6);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(1, Area_01_MotelPark[iRand], Area_01_MotelDoor02[RandomX.FindRandom("AppBlock01f03", 0, Area_01_MotelDoor02.Count - 1)], "Rancho Motel", 6);
                    }
                    else
                    {
                        if (iRand == -1 || iRand >= Area_01_Hotel.Count)
                            iRand = RandomX.FindRandom("AppBlock01f2", 0, Area_01_Hotel.Count - 1);
                        yourApp = Area_01_Hotel[iRand];
                    }
                }           //HotelMotelHolidayInn
                else if (iType == 7)
                {
                    if (iRand == -1)
                        iRand = RandomX.FindRandom("AppBlock01g2", 0, 34);

                    if (iRand == 0)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor00[RandomX.FindRandom("AppBlock01g01", 0, Area_01_AppDoor00.Count - 1)], "", 50);
                    else if (iRand == 1)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor01[RandomX.FindRandom("AppBlock01g02", 0, Area_01_AppDoor01.Count - 1)], "", 50);
                    else if (iRand == 2)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor02[RandomX.FindRandom("AppBlock01g03", 0, Area_01_AppDoor02.Count - 1)], "", 50);
                    else if (iRand == 3)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor03[RandomX.FindRandom("AppBlock01g04", 0, Area_01_AppDoor03.Count - 1)], "", 50);
                    else if (iRand == 4)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor04[RandomX.FindRandom("AppBlock01g05", 0, Area_01_AppDoor04.Count - 1)], "", 50);
                    else if (iRand == 5)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor05[RandomX.FindRandom("AppBlock01g06", 0, Area_01_AppDoor05.Count - 1)], "", 50);
                    else if (iRand == 6)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor06[RandomX.FindRandom("AppBlock01g07", 0, Area_01_AppDoor06.Count - 1)], "", 50);
                    else if (iRand == 7)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor07[RandomX.FindRandom("AppBlock01g08", 0, Area_01_AppDoor07.Count - 1)], "", 50);
                    else if (iRand == 8)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor08[RandomX.FindRandom("AppBlock01g09", 0, Area_01_AppDoor08.Count - 1)], "", 50);
                    else if (iRand == 9)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor09[RandomX.FindRandom("AppBlock01g10", 0, Area_01_AppDoor09.Count - 1)], "", 50);
                    else if (iRand == 10)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor10[RandomX.FindRandom("AppBlock01g11", 0, Area_01_AppDoor10.Count - 1)], "", 50);
                    else if (iRand == 11)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor11[RandomX.FindRandom("AppBlock01g12", 0, Area_01_AppDoor11.Count - 1)], "", 50);
                    else if (iRand == 12)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor12[RandomX.FindRandom("AppBlock01g13", 0, Area_01_AppDoor12.Count - 1)], "", 50);
                    else if (iRand == 13)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor13[RandomX.FindRandom("AppBlock01g14", 0, Area_01_AppDoor13.Count - 1)], "", 50);
                    else if (iRand == 14)//GetsBlocked top flat..
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor14[RandomX.FindRandom("AppBlock01g15", 0, Area_01_AppDoor14.Count - 1)], "", 50);
                    else if (iRand == 15)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor15[RandomX.FindRandom("AppBlock01g16", 0, Area_01_AppDoor15.Count - 1)], "", 50);
                    else if (iRand == 16)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor16[RandomX.FindRandom("AppBlock01g17", 0, Area_01_AppDoor16.Count - 1)], "", 50);
                    else if (iRand == 17)
                        yourApp = new FubarVectors(1, Area_01_AppPark[iRand], Area_01_AppDoor17[RandomX.FindRandom("AppBlock01g18", 0, Area_01_AppDoor17.Count - 1)], "", 50);
                    else
                        yourApp = Area_01_Houses[RandomX.FindRandom("AppBlock01g19", 0, Area_01_Houses.Count - 1)];
                }           //AppHouse
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_01_ORP.Count)
                        iRand = RandomX.FindRandom("AppBlock01h", 0, Area_01_ORP.Count - 1);
                    yourApp = Area_01_ORP[iRand];
                }           //OffRoadParking
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_01_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock01i", 0, Area_01_OnineApps.Count - 1);
                    yourApp = Area_01_OnineApps[iRand];
                }           //PlayHouses
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea01.Count)
                        iRand = RandomX.FindRandom("AppBlock01j", 0, HospArea01.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea01[iRand], HospArea01[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire01.Count)
                        iRand = RandomX.FindRandom("AppBlock01k", 0, BinFire01.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire01[iRand], BinFire01[iRand], "", 0);
                }       //BinPick
            }
            else if (iArea == 2)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock02", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop02.Count)
                        iRand = RandomX.FindRandom("AppBlock02ax", 0, TruckStop02.Count - 1);
                    Truckers TC = TruckStop02[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }   
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_02_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock02a", 0, Area_02_BikerBiz.Count - 1);
                    yourApp = Area_02_BikerBiz[iRand];
                }
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_02_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock02b", 0, Area_02_BunkerWare.Count - 1);
                    yourApp = Area_02_BunkerWare[iRand];
                }
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_02_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock02c", 0, Area_02_OpenDoors.Count - 1);
                    yourApp = Area_02_OpenDoors[iRand];
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_02_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock02d", 0, Area_02_Resurant.Count - 1);
                    yourApp = Area_02_Resurant[iRand];
                }
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_02_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock02e", 0, Area_02_Lesure.Count - 1);
                    yourApp = Area_02_Lesure[iRand];
                }
                else if (iType == 6)
                {
                    if (iApps == -1 || iApps > 2)
                        iApps = RandomX.FindRandom("AppBlock02f", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand > 3)
                            iRand = RandomX.FindRandom("AppBlock02f1", 0, 3);

                        if (iRand == 0)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor00[RandomX.FindRandom("AppBlock02f01", 0, Area_02_MotelDoor00.Count - 1)], "", 6);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor01[RandomX.FindRandom("AppBlock02f02", 0, Area_02_MotelDoor01.Count - 1)], "", 6);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor02[RandomX.FindRandom("AppBlock02f02", 0, Area_02_MotelDoor02.Count - 1)], "", 6);
                        else if (iRand == 3)
                            yourApp = new FubarVectors(2, Area_02_MotelPark[iRand], Area_02_MotelDoor03[RandomX.FindRandom("AppBlock02f03", 0, Area_02_MotelDoor03.Count - 1)], "", 6);
                    }
                    else 
                    {
                        if (iRand == -1 || iRand >= Area_02_Hotel.Count)
                            iRand = RandomX.FindRandom("AppBlock02f2", 0, Area_02_Hotel.Count - 1);
                        yourApp = Area_02_Hotel[iRand];
                    }
                }
                else if (iType == 7)
                {
                    if (iApps == -1)
                        iApps = RandomX.FindRandom("AppBlock02g", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand > 2)
                            iRand = RandomX.FindRandom("AppBlock02g1", 0, 2);

                        if (iRand == 0)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor00[RandomX.FindRandom("AppBlock02g01", 0, Area_02_AppDoor00.Count - 1)], "", 50);
                        else if (iRand == 1)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor01[RandomX.FindRandom("AppBlock02g02", 0, Area_02_AppDoor01.Count - 1)], "", 50);
                        else if (iRand == 2)
                            yourApp = new FubarVectors(2, Area_02_AppPark[iRand], Area_02_AppDoor02[RandomX.FindRandom("AppBlock02g03", 0, Area_02_AppDoor02.Count - 1)], "", 50);
                    }
                    else if (iApps == 2)
                    {
                        if (iRand == -1 || iRand >= Area_02_Houses01.Count)
                            iRand = RandomX.FindRandom("AppBlock02g2", 0, Area_02_Houses01.Count - 1);
                        yourApp = Area_02_Houses01[iRand];
                    }
                }
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_02_ORP01.Count)
                        iRand = RandomX.FindRandom("AppBlock02h", 0, Area_02_ORP01.Count - 1);
                    yourApp = Area_02_ORP01[iRand];
                }
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_02_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock02i", 0, Area_02_OnineApps.Count - 1);
                    yourApp = Area_02_OnineApps[iRand];
                }
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea02.Count)
                        iRand = RandomX.FindRandom("AppBlock02j", 0, HospArea02.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea02[iRand], HospArea02[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire02.Count)
                        iRand = RandomX.FindRandom("AppBlock02k", 0, BinFire02.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire02[iRand], BinFire02[iRand], "", 0);
                }       //BinPick
                else if (iType == 15)
                {
                    if (iRand == -1 || iRand >= Offices.Count)
                        iRand = RandomX.FindRandom("AppBlock02l", 0, Offices.Count - 1);
                    yourApp = Offices[iRand];
                }
            }
            else if (iArea == 3)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock03", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop03.Count)
                        iRand = RandomX.FindRandom("AppBlock03ax", 0, TruckStop03.Count - 1);
                    Truckers TC = TruckStop03[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }        
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_03_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock03a", 0, Area_03_BikerBiz.Count - 1);
                    yourApp = Area_03_BikerBiz[iRand];
                }
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_03_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock03b", 0, Area_03_BunkerWare.Count - 1);
                    yourApp = Area_03_BunkerWare[iRand];
                }
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_03_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock03c", 0, Area_03_OpenDoors.Count - 1);
                    yourApp = Area_03_OpenDoors[iRand];
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_03_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock03d", 0, Area_03_Resurant.Count - 1);
                    yourApp = Area_03_Resurant[iRand];
                }
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_03_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock03e", 0, Area_03_Lesure.Count - 1);
                    yourApp = Area_03_Lesure[iRand];
                }
                else if (iType == 6)
                {
                    if (iRand == -1 || iRand >= Area_03_Hotel.Count)
                        iRand = RandomX.FindRandom("AppBlock03f", 0, Area_03_Hotel.Count - 1);
                    yourApp = Area_03_Hotel[iRand];
                }
                else if (iType == 7)
                {
                    if (iRand == -1 || iRand >= Area_03_Houses.Count)
                        iRand = RandomX.FindRandom("AppBlock03g", 0, Area_03_Houses.Count - 1);
                    yourApp = Area_03_Houses[iRand];
                }
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_03_ORP.Count)
                        iRand = RandomX.FindRandom("AppBlock03h", 0, Area_03_ORP.Count - 1);
                    yourApp = Area_03_ORP[iRand];
                }
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_03_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock03i", 0, Area_03_OnineApps.Count - 1);
                    yourApp = Area_03_OnineApps[iRand];
                }
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea03.Count)
                        iRand = RandomX.FindRandom("AppBlock03j", 0, HospArea03.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea03[iRand], HospArea03[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire03.Count)
                        iRand = RandomX.FindRandom("AppBlock03k", 0, BinFire03.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire03[iRand], BinFire03[iRand], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    if (iRand == -1 || iRand >= Area_03_Facility.Count)
                        iRand = RandomX.FindRandom("AppBlock03l", 0, Area_03_Facility.Count - 1);
                    yourApp = Area_03_Facility[iRand];
                }
            }
            else if (iArea == 4)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock04", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop04.Count)
                        iRand = RandomX.FindRandom("AppBlock04ax", 0, TruckStop04.Count - 1);
                    Truckers TC = TruckStop04[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }               
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_04_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock04a", 0, Area_04_BikerBiz.Count - 1);
                    yourApp = Area_04_BikerBiz[iRand];
                }
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_04_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock04b", 0, Area_04_BunkerWare.Count - 1);
                    yourApp = Area_04_BunkerWare[iRand];
                }
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_04_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock04c", 0, Area_04_OpenDoors.Count - 1);
                    yourApp = Area_04_OpenDoors[iRand];
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_04_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock04d", 0, Area_04_Resurant.Count - 1);
                    yourApp = Area_04_Resurant[iRand];
                }
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_04_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock04e", 0, Area_04_Lesure.Count - 1);
                    yourApp = Area_04_Lesure[iRand];
                }
                else if (iType == 6)
                {
                    if (iRand == -1 || iRand >= Area_04_Hotel.Count)
                        iRand = RandomX.FindRandom("AppBlock04f", 0, Area_04_Hotel.Count - 1);
                    yourApp = Area_04_Hotel[iRand];
                }
                else if (iType == 7)
                {
                    if (iApps == -1)
                        iApps = RandomX.FindRandom("AppBlock04g", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand >= Area_04_Houses01.Count)
                            iRand = RandomX.FindRandom("AppBlock04g1", 0, Area_04_Houses01.Count - 1);
                        yourApp = Area_04_Houses01[iRand];
                    }
                    else
                    {
                        if (iRand == -1 || iRand >= Area_04_Trailer.Count)
                            iRand = RandomX.FindRandom("AppBlock04g2", 0, Area_04_Trailer.Count - 1);
                        yourApp = Area_04_Trailer[iRand];
                    }
                }
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_04_ORP01.Count)
                        iRand = RandomX.FindRandom("AppBlock04h1", 0, Area_04_ORP01.Count - 1);
                    yourApp = Area_04_ORP01[iRand];
                }
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_04_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock04i", 0, Area_04_OnineApps.Count - 1);
                    yourApp = Area_04_OnineApps[iRand];
                }
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea04.Count)
                        iRand = RandomX.FindRandom("AppBlock04j", 0, HospArea04.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea04[iRand], HospArea04[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire04.Count)
                        iRand = RandomX.FindRandom("AppBlock04k", 0, BinFire04.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire04[iRand], BinFire04[iRand], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    if (iRand == -1 || iRand >= Area_04_Facility.Count)
                        iRand = RandomX.FindRandom("AppBlock04l", 0, Area_04_Facility.Count - 1);
                    yourApp = Area_04_Facility[iRand];
                }
            }
            else if (iArea == 5)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock05", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop05.Count)
                        iRand = RandomX.FindRandom("AppBlock05ax", 0, TruckStop05.Count - 1);
                    Truckers TC = TruckStop05[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }               
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_05_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock05a", 0, Area_05_BikerBiz.Count - 1);
                    yourApp = Area_05_BikerBiz[iRand];
                }
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_05_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock05b", 0, Area_05_BunkerWare.Count - 1);
                    yourApp = Area_05_BunkerWare[iRand];
                }
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_05_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock05c", 0, Area_05_OpenDoors.Count - 1);
                    yourApp = Area_05_OpenDoors[iRand];
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_05_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock05d", 0, Area_05_Resurant.Count - 1);
                    yourApp = Area_05_Resurant[iRand];
                }
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_05_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock05e", 0, Area_05_Lesure.Count - 1);
                    yourApp = Area_05_Lesure[iRand];
                }
                else if (iType == 6)
                {
                    if (iRand == -1 || iRand > 1)
                        iRand = RandomX.FindRandom("AppBlock05f", 0, 1);

                    if (iRand == 0)
                        yourApp = new FubarVectors(5, Area_05_MotelPark[iRand], Area_05_MotelDoor00[RandomX.FindRandom("AppBlock05f01", 0, Area_05_MotelDoor00.Count - 1)], "", 6);
                    else 
                        yourApp = new FubarVectors(5, Area_05_MotelPark[iRand], Area_05_MotelDoor01[RandomX.FindRandom("AppBlock05f02", 0, Area_05_MotelDoor01.Count - 1)], "", 6);
                }
                else if (iType == 7)
                {
                    if (iApps == -1)
                        iApps = RandomX.FindRandom("AppBlock05g", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand >= Area_05_Houses01.Count)
                            iRand = RandomX.FindRandom("AppBlock05g1", 0, Area_05_Houses01.Count - 1);
                        yourApp = Area_05_Houses01[iRand];
                    }
                    else
                    {
                        if (iRand == -1 || iRand >= Area_05_Trailer.Count)
                            iRand = RandomX.FindRandom("AppBlock05g2", 0, Area_05_Trailer.Count - 1);
                        yourApp = Area_05_Trailer[iRand];
                    }
                }
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_05_ORP01.Count)
                        iRand = RandomX.FindRandom("AppBlock05h1", 0, Area_05_ORP01.Count - 1);
                    yourApp = Area_05_ORP01[iRand];
                }
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_05_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock05i", 0, Area_05_OnineApps.Count - 1);
                    yourApp = Area_05_OnineApps[iRand];
                }
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea05.Count)
                        iRand = RandomX.FindRandom("AppBlock05j", 0, HospArea05.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea05[iRand], HospArea05[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire05.Count)
                        iRand = RandomX.FindRandom("AppBlock05k", 0, BinFire05.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire05[iRand], BinFire05[iRand], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    if (iRand == -1 || iRand >= Area_05_Facility.Count)
                        iRand = RandomX.FindRandom("AppBlock05l", 0, Area_05_Facility.Count - 1);
                    yourApp = Area_05_Facility[iRand];
                }
            }
            else if (iArea == 6)
            {
                if (iType < 0)
                    iType = RandomX.FindRandom("AppBlock06", 0, 9);

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop06.Count)
                        iRand = RandomX.FindRandom("AppBlock06ax", 0, TruckStop06.Count - 1);
                    Truckers TC = TruckStop06[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }                
                else if (iType == 1)
                {
                    if (iRand == -1 || iRand >= Area_06_BikerBiz.Count)
                        iRand = RandomX.FindRandom("AppBlock06a", 0, Area_06_BikerBiz.Count - 1);
                    yourApp = Area_06_BikerBiz[iRand];
                }
                else if (iType == 2)
                {
                    if (iRand == -1 || iRand >= Area_06_BunkerWare.Count)
                        iRand = RandomX.FindRandom("AppBlock06b", 0, Area_06_BunkerWare.Count - 1);
                    yourApp = Area_06_BunkerWare[iRand];
                }
                else if (iType == 3)
                {
                    if (iRand == -1 || iRand >= Area_06_OpenDoors.Count)
                        iRand = RandomX.FindRandom("AppBlock06c", 0, Area_06_OpenDoors.Count - 1);
                    yourApp = Area_06_OpenDoors[iRand];
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_06_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock06d", 0, Area_06_Resurant.Count - 1);
                    yourApp = Area_06_Resurant[iRand];
                }
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_06_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock06e", 0, Area_06_Lesure.Count - 1);
                    yourApp = Area_06_Lesure[iRand];
                }
                else if (iType == 6)
                {
                    if (iRand == -1 || iRand > 1)
                        iRand = RandomX.FindRandom("AppBlock06f", 0, 1);

                    if (iRand == 0)
                        yourApp = new FubarVectors(6, Area_06_MotelPark[iRand], Area_06_MotelDoor00[RandomX.FindRandom("AppBlock06f01", 0, Area_06_MotelDoor00.Count - 1)], "", 6);
                    else 
                        yourApp = new FubarVectors(6, Area_06_MotelPark[iRand], Area_06_MotelDoor01[RandomX.FindRandom("AppBlock06f02", 0, Area_06_MotelDoor01.Count - 1)], "", 6);
                }
                else if (iType == 7)
                {
                    if (iApps == -1)
                        iApps = RandomX.FindRandom("AppBlock06g", 1, 2);

                    if (iApps == 1)
                    {
                        if (iRand == -1 || iRand >= Area_06_Houses.Count)
                            iRand = RandomX.FindRandom("AppBlock06g1", 0, Area_06_Houses.Count - 1);
                        yourApp = Area_06_Houses[iRand];
                    }
                    else
                    {
                        if (iRand == -1 || iRand >= Area_06_Trailer.Count)
                            iRand = RandomX.FindRandom("AppBlock06g2", 0, Area_06_Trailer.Count - 1);
                        yourApp = Area_06_Trailer[iRand];
                    }
                }
                else if (iType == 8)
                {
                    if (iRand == -1 || iRand >= Area_06_ORP.Count)
                        iRand = RandomX.FindRandom("AppBlock06h", 0, Area_06_ORP.Count - 1);
                    yourApp = Area_06_ORP[iRand];
                }
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_06_OnineApps.Count)
                        iRand = RandomX.FindRandom("AppBlock06i", 0, Area_06_OnineApps.Count - 1);
                    yourApp = Area_06_OnineApps[iRand];
                }
                else if (iType == 10)
                {
                    if (iRand == -1 || iRand >= HospArea06.Count)
                        iRand = RandomX.FindRandom("AppBlock06j", 0, HospArea06.Count - 1);

                    yourApp = new FubarVectors(iArea, HospArea06[iRand], HospArea06[iRand], "", 0);
                }       //HospidalPick
                else if (iType == 11)
                {
                    if (iRand == -1 || iRand >= BinFire06.Count)
                        iRand = RandomX.FindRandom("AppBlock06k", 0, BinFire06.Count - 1);

                    yourApp = new FubarVectors(iArea, BinFire06[iRand], BinFire06[iRand], "", 0);
                }       //BinPick
                else if (iType == 20)
                {
                    if (iRand == -1 || iRand >= Area_06_Facility.Count)
                        iRand = RandomX.FindRandom("AppBlock06l", 0, Area_06_Facility.Count - 1);
                    yourApp = Area_06_Facility[iRand];
                }
            }
            else if (iArea == 8)
            {
                if (iType < 0)
                    iType = RandomX.FindRandomList("AppBlock08", new List<int> { 0, 4, 5, 9 });

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop08.Count)
                        iRand = RandomX.FindRandom("AppBlock08ax", 0, TruckStop08.Count - 1);
                    Truckers TC = TruckStop08[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_08_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock08d", 0, Area_08_Resurant.Count - 1);
                    yourApp = Area_08_Resurant[iRand];
                }           //DeliverHow
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_08_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock08e", 0, Area_08_Lesure.Count - 1);
                    yourApp = Area_08_Lesure[iRand];
                }           //ClubsParks
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_08_Houses.Count)
                        iRand = RandomX.FindRandom("AppBlock08g1", 0, Area_08_Houses.Count - 1);
                    yourApp = Area_08_Houses[iRand];
                }           //PlayHouses
            }
            else if (iArea == 9)
            {
                if (iType < 0)
                    iType = RandomX.FindRandomList("AppBlock09", new List<int> { 0, 4, 5, 9 });

                if (iType == 0)
                {
                    if (iRand == -1 || iRand >= TruckStop09.Count)
                        iRand = RandomX.FindRandom("AppBlock09ax", 0, TruckStop09.Count - 1);
                    Truckers TC = TruckStop09[iRand];
                    yourApp = new FubarVectors(iArea, TC.FuStop, TC.ExitDoor, "", 0);
                }
                else if (iType == 4)
                {
                    if (iRand == -1 || iRand >= Area_09_Resurant.Count)
                        iRand = RandomX.FindRandom("AppBlock09d", 0, Area_09_Resurant.Count - 1);
                    yourApp = Area_09_Resurant[iRand];
                }           //DeliverHow
                else if (iType == 5)
                {
                    if (iRand == -1 || iRand >= Area_09_Lesure.Count)
                        iRand = RandomX.FindRandom("AppBlock09e", 0, Area_09_Lesure.Count - 1);
                    yourApp = Area_09_Lesure[iRand];
                }           //ClubsParks
                else if (iType == 9)
                {
                    if (iRand == -1 || iRand >= Area_09_Houses.Count)
                        iRand = RandomX.FindRandom("AppBlock09g1", 0, Area_09_Houses.Count - 1);
                    yourApp = Area_09_Houses[iRand];
                }           //PlayHouses
            }

            if (bCorDrop)
            {
                Vector4 fIt = new Vector4(yourApp.ParkHere.X, yourApp.ParkHere.Y, yourApp.ParkHere.Z - 0.5f, yourApp.ParkHere.R);
                yourApp.ParkHere = fIt;
            }

            return yourApp;
        }
        public static Truckers FindTruckers(int iArea, int iTrail)
        {
            LoggerLight.LogThis("FindTruckers, iArea == " + iArea + ", iTrail ==" + iTrail);
            Truckers MyTruck = MyTrucker(iArea, iTrail);
            while (MyTruck == null)
            {
                MyTruck = MyTrucker(iArea, iTrail);
                Script.Wait(1);
            }
            return MyTruck;
        }
        private static Truckers MyTrucker(int iArea, int iTrail)
        {
            LoggerLight.LogThis("MyTrucker, iArea == " + iArea + ", iTrail ==" + iTrail);
            Truckers MyTruck = null;
            int AreaB = iArea;

            if (iTrail != -1)
            {
                AreaB = RandomX.FindRandom("MyTruckArea01", 1, 6);
                while (iArea == AreaB)
                {
                    AreaB = RandomX.FindRandom("MyTruckArea01", 1, 6);
                    Script.Wait(1);
                }
                iArea = AreaB;
            }

            if (iArea == 1)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop01", 0, TruckStop01.Count - 1);
                    MyTruck = TruckStop01[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop01.Count; i++)
                    {
                        if (TruckStop01[i].Type == iTrail)
                            myTrucks.Add(TruckStop01[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 2)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop02", 0, TruckStop02.Count - 1);
                    MyTruck = TruckStop02[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop02.Count; i++)
                    {
                        if (TruckStop02[i].Type == iTrail)
                            myTrucks.Add(TruckStop02[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 3)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop03", 0, TruckStop03.Count - 1);
                    MyTruck = TruckStop03[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop03.Count; i++)
                    {
                        if (TruckStop03[i].Type == iTrail)
                            myTrucks.Add(TruckStop03[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 4)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop04", 0, TruckStop04.Count - 1);
                    MyTruck = TruckStop04[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop04.Count; i++)
                    {
                        if (TruckStop04[i].Type == iTrail)
                            myTrucks.Add(TruckStop04[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 5)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop05", 0, TruckStop05.Count - 1);
                    MyTruck = TruckStop05[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop05.Count; i++)
                    {
                            if (TruckStop05[i].Type == iTrail)
                                myTrucks.Add(TruckStop05[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 6)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop06", 0, TruckStop06.Count - 1);
                    MyTruck = TruckStop06[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop06.Count; i++)
                    {
                        if (TruckStop06[i].Type == iTrail)
                            myTrucks.Add(TruckStop06[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 7)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop07", 0, TruckStop07.Count - 1);
                    MyTruck = TruckStop07[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop07.Count; i++)
                    {
                        if (TruckStop07[i].Type == iTrail)
                            myTrucks.Add(TruckStop07[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 8)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop08", 0, TruckStop08.Count - 1);
                    MyTruck = TruckStop08[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop08.Count; i++)
                    {
                        if (TruckStop08[i].Type == iTrail)
                            myTrucks.Add(TruckStop08[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }
            else if (iArea == 9)
            {
                if (iTrail == -1)
                {
                    int iPick = RandomX.FindRandom("TruckStop09", 0, TruckStop09.Count - 1);
                    MyTruck = TruckStop09[iPick];
                }
                else
                {
                    List<Truckers> myTrucks = new List<Truckers>();
                    for (int i = 0; i < TruckStop09.Count; i++)
                    {
                        if (TruckStop09[i].Type == iTrail)
                            myTrucks.Add(TruckStop09[i]);
                    }
                    if (myTrucks.Count > 0)
                    {
                        int iPick = RandomX.RandInt(0, myTrucks.Count - 1);
                        MyTruck = myTrucks[iPick];
                    }
                }
            }

            return MyTruck;
        }
        public static Getaways FindBank(int iArea)
        {
            LoggerLight.LogThis("FindBank, iArea == " + iArea);
            Getaways MyGet = null;
            for (int i = 0; i < BankRobberies.Count;i++)
            {
                if (BankRobberies[i].Zone == iArea)
                {
                    if (iArea == 2 && RandomX.FindRandom("FindBank01", 1, 4) > 2)
                        MyGet = BankRobberies[i + 1];
                    else
                        MyGet = BankRobberies[i];
                    break;
                }
            }
            return MyGet;
        }
        public static GetawaysEnd FindBankEnd()
        {
            LoggerLight.LogThis("FindBankEnd");
            
            return GetAwayEnds[RandomX.FindRandom("FindBankEnd", 0, GetAwayEnds.Count - 1)];
        }
        public static PrePack FindPack(int iArea)
        {
            LoggerLight.LogThis("FindPack, iArea == " + iArea);
            List<int> iPack = new List<int>();

            for (int i = 0; i < PackageDeliverys.Count; i++)
            {
                if (PackageDeliverys[i].Zone == iArea)
                    iPack.Add(i);
            }

            return PackageDeliverys[iPack[RandomX.FindRandom("FindPack0" + iArea, 0, iPack.Count - 1)]];
        }
        public static ConsOnParade FindCons(int iArea)
        {
            LoggerLight.LogThis("FindCons, iArea == " + iArea);
            List<int> iPack = new List<int>();

            for (int i = 0; i < ConvictRoutes.Count; i++)
            {
                if (ConvictRoutes[i].Zone == iArea)
                    iPack.Add(i);
            }
            return ConvictRoutes[iPack[RandomX.FindRandom("FindCons0" + iArea, 0, iPack.Count - 1)]];
        }
        public static List<int> FindRacists(int iArea)
        {
            LoggerLight.LogThis("FindRacists, iArea == " + iArea);
            List<int> iPack = new List<int>();

            for (int i = 0; i < MyRacists.Count; i++)
            {
                if (MyRacists[i].Zone == iArea)
                    iPack.Add(i);
            }
            return iPack;
        }
        public static List<Vector4> FindingFires(int iArea, int type)
        {
            List<Vector4> Fires = new List<Vector4>();

            if (iArea == 1)
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire01[RandomX.FindRandom("FindingFiresA01Wb",0, BinFire01.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA01Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(990.4315f, -2908.047f, 4.906881f, 0f));
                        Fires.Add(new Vector4(990.8276f, -2904.836f, 10.92457f, 0f));
                        Fires.Add(new Vector4(988.6428f, -2904.823f, 27.16458f, 0f));
                        Fires.Add(new Vector4(979.5891f, -2904.785f, 46.62289f, 0f));
                        Fires.Add(new Vector4(979.6679f, -2960.224f, 42.28537f, 0f));
                        Fires.Add(new Vector4(979.7318f, -2902.172f, 71.78313f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(329.991f, -2758.334f, 5.07591f, 0f));
                        Fires.Add(new Vector4(353.3759f, -2753.441f, 20.5707f, 0f));
                        Fires.Add(new Vector4(341.4529f, -2723.276f, 38.40429f, 0f));
                        Fires.Add(new Vector4(338.4341f, -2763.283f, 42.63232f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(563.7545f, -2204.024f, 8.781557f, 0f));
                        Fires.Add(new Vector4(560.7622f, -2204.463f, 12.89944f, 0f));
                        Fires.Add(new Vector4(551.6384f, -2216.125f, 68.98109f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(988.7126f, -1912.683f, 30.15284f, 0f));
                        Fires.Add(new Vector4(986.7842f, -1912.66f, 43.39808f, 0f));
                        Fires.Add(new Vector4(969.8815f, -1912.091f, 51.47533f, 0f));
                        Fires.Add(new Vector4(969.0193f, -1907.429f, 60.69697f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(171.3466f, -2132.272f, 11.3922f, 0f));
                        Fires.Add(new Vector4(170.6103f, -2133.501f, 19.15985f, 0f));
                        Fires.Add(new Vector4(171.555f, -2144.849f, 26.4754f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(-750.8582f, -2091.132f, 8.081368f, 0f));
                        Fires.Add(new Vector4(-726.4521f, -2087.394f, 19.41779f, 0f));
                        Fires.Add(new Vector4(-661.7372f, -2132.691f, 51.44682f, 0f));
                        Fires.Add(new Vector4(-564.0597f, -2201.186f, 98.58532f, 0f));
                        Fires.Add(new Vector4(-546.9232f, -2230.037f, 121.3655f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(-1013.224f, -1909.707f, 12.16505f, 0f));
                        Fires.Add(new Vector4(-1026.246f, -1969.08f, 18.76334f, 0f));
                        Fires.Add(new Vector4(-1050.061f, -1964.186f, 36.22753f, 0f));
                        Fires.Add(new Vector4(-1051.122f, -1958.896f, 41.63218f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(-611.5026f, -1642.726f, 24.9797f, 0f));
                        Fires.Add(new Vector4(-623.3297f, -1634.776f, 32.86921f, 0f));
                        Fires.Add(new Vector4(-613.2112f, -1623.635f, 40.04972f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(-63.11477f, -1312.831f, 28.27547f, 0f));
                        Fires.Add(new Vector4(-75.70776f, -1293.487f, 32.79663f, 0f));
                        Fires.Add(new Vector4(-65.95271f, -1280.114f, 46.6948f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(820.0727f, -2344.213f, 29.33858f, 0f));
                        Fires.Add(new Vector4(814.9317f, -2338.989f, 33.50211f, 0f));
                        Fires.Add(new Vector4(818.6331f, -2308.808f, 37.06253f, 0f));
                        Fires.Add(new Vector4(811.1056f, -2304.844f, 42.0081f, 0f));
                        Fires.Add(new Vector4(830.2932f, -2303.968f, 46.04805f, 0f));
                        Fires.Add(new Vector4(805.8372f, -2296.752f, 50.80018f, 0f));
                        Fires.Add(new Vector4(798.2391f, -2302.468f, 54.57926f, 0f));
                        Fires.Add(new Vector4(803.1917f, -2331.276f, 61.09147f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire01[RandomX.FindRandom("FindingFiresA01Mad", 0, MadFire01.Count - 1)]);
                }                            //chase driver throwing molitovs
            }
            else if (iArea == 2)
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire02[RandomX.FindRandom("FindingFiresA02Wb", 0, BinFire02.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA02Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(-447.7411f, -1079.003f, 22.54898f, 0f));
                        Fires.Add(new Vector4(-449.6465f, -1079.447f, 26.10633f, 0f));
                        Fires.Add(new Vector4(-452.262f, -1081.795f, 64.8438f, 0f));
                        Fires.Add(new Vector4(-409.3894f, -1070.397f, 68.31025f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(-114.9596f, -978.2042f, 26.69116f, 0f));
                        Fires.Add(new Vector4(-119.4298f, -976.4756f, 29.45085f, 0f));
                        Fires.Add(new Vector4(-117.6392f, -977.1044f, 55.35491f, 0f));
                        Fires.Add(new Vector4(-119.4345f, -976.474f, 62.44019f, 0f));
                        Fires.Add(new Vector4(-117.6436f, -977.1255f, 85.17181f, 0f));
                        Fires.Add(new Vector4(-119.4367f, -976.4696f, 92.26001f, 0f));
                        Fires.Add(new Vector4(-117.6443f, -977.1223f, 114.9898f, 0f));
                        Fires.Add(new Vector4(-119.4364f, -976.4659f, 122.0735f, 0f));
                        Fires.Add(new Vector4(-117.6396f, -977.1151f, 144.8024f, 0f));
                        Fires.Add(new Vector4(-119.4289f, -976.4747f, 151.8908f, 0f));
                        Fires.Add(new Vector4(-117.6443f, -977.1274f, 174.6152f, 0f));
                        Fires.Add(new Vector4(-119.4326f, -976.4718f, 181.6986f, 0f));
                        Fires.Add(new Vector4(-117.6429f, -977.1227f, 204.4289f, 0f));
                        Fires.Add(new Vector4(-119.4294f, -976.4729f, 211.515f, 0f));
                        Fires.Add(new Vector4(-117.6439f, -977.1269f, 234.2452f, 0f));
                        Fires.Add(new Vector4(-119.4327f, -976.4712f, 241.3287f, 0f));
                        Fires.Add(new Vector4(-117.6445f, -977.1221f, 264.0555f, 0f));
                        Fires.Add(new Vector4(-119.4281f, -976.4728f, 271.1439f, 0f));
                        Fires.Add(new Vector4(-118.256f, -973.5796f, 291.7375f, 0f));
                        Fires.Add(new Vector4(-120.9791f, -976.6447f, 295.2109f, 0f));
                        Fires.Add(new Vector4(-119.3349f, -977.0608f, 303.2495f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(47.63587f, -455.6017f, 39.17879f, 0f));
                        Fires.Add(new Vector4(47.24371f, -460.1096f, 41.93575f, 0f));
                        Fires.Add(new Vector4(48.78002f, -463.2804f, 95.35428f, 0f));
                        Fires.Add(new Vector4(51.11815f, -403.5366f, 98.8222f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(-664.4091f, 225.0738f, 81.32626f, 0f));
                        Fires.Add(new Vector4(-664.3094f, 229.5972f, 84.08173f, 0f));
                        Fires.Add(new Vector4(-664.3101f, 227.6925f, 109.9983f, 0f));
                        Fires.Add(new Vector4(-664.3095f, 229.5979f, 117.0815f, 0f));
                        Fires.Add(new Vector4(-664.3101f, 227.6923f, 139.812f, 0f));
                        Fires.Add(new Vector4(-664.3104f, 229.5985f, 146.897f, 0f));
                        Fires.Add(new Vector4(-666.0506f, 232.6609f, 152.5798f, 0f));
                        Fires.Add(new Vector4(-664.2935f, 248.1813f, 156.3605f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(-619.6422f, -155.1574f, 37.27605f, 0f));
                        Fires.Add(new Vector4(-590.7766f, -136.8396f, 38.63365f, 0f));
                        Fires.Add(new Vector4(-625.733f, -125.4332f, 46.36606f, 0f));
                        Fires.Add(new Vector4(-617.8801f, -85.96204f, 50.98095f, 0f));
                        Fires.Add(new Vector4(-608.0366f, -77.26147f, 57.40785f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(-255.5883f, -198.9922f, 39.20316f, 0f));
                        Fires.Add(new Vector4(-224.0681f, -189.7777f, 77.45409f, 0f));
                        Fires.Add(new Vector4(-186.5666f, -149.9927f, 84.22469f, 0f));
                        Fires.Add(new Vector4(-151.0828f, -140.7088f, 92.70245f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(52.03278f, 156.2182f, 103.6395f, 0f));
                        Fires.Add(new Vector4(33.67483f, 153.6316f, 116.5249f, 0f));
                        Fires.Add(new Vector4(46.28093f, 182.4599f, 125.2164f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(281.2852f, -1004.909f, 28.35802f, 0f));
                        Fires.Add(new Vector4(278.9556f, -1010.7f, 33.64793f, 0f));
                        Fires.Add(new Vector4(274.0553f, -1018.779f, 50.39609f, 0f));
                        Fires.Add(new Vector4(259.0381f, -1010.151f, 60.63672f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(166.7373f, -1069.914f, 28.19704f, 0f));
                        Fires.Add(new Vector4(160.4567f, -1067.88f, 33.77694f, 0f));
                        Fires.Add(new Vector4(161.8633f, -1061.519f, 40.9845f, 0f));
                        Fires.Add(new Vector4(163.9445f, -1061.368f, 65.08058f, 0f));
                        Fires.Add(new Vector4(178.6456f, -1060.949f, 70.73961f, 0f));
                        Fires.Add(new Vector4(175.9049f, -1071.798f, 76.54419f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(-1172.507f, -527.0783f, 29.37776f, 0f));
                        Fires.Add(new Vector4(-1200.487f, -495.5178f, 34.53702f, 0f));
                        Fires.Add(new Vector4(-1205.021f, -490.9817f, 37.79013f, 0f));
                        Fires.Add(new Vector4(-1205.385f, -489.4001f, 46.0639f, 0f));
                        Fires.Add(new Vector4(-1179.487f, -472.3701f, 54.1913f, 0f));
                        Fires.Add(new Vector4(-1175.412f, -472.3513f, 59.10122f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire02[RandomX.FindRandom("FindingFiresA02Mad", 0, MadFire02.Count - 1)]);
                }                            //chase driver throwing molitovs
            }
            else if (iArea == 3)//fort access
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire03[RandomX.FindRandom("FindingFiresA03Wb", 0, BinFire03.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA03Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(-3245.531f, 967.5728f, 11.73052f, 0f));
                        Fires.Add(new Vector4(-3411.661f, 971.7932f, 7.376493f, 0f));
                        Fires.Add(new Vector4(-3418.302f, 967.7336f, 10.93614f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(-1947.979f, 1780.116f, 174.0855f, 0f));
                        Fires.Add(new Vector4(-1955.495f, 1776.703f, 183.0402f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(-2263.28f, 206.7552f, 173.6016f, 0f));
                        Fires.Add(new Vector4(-2265.143f, 210.8193f, 173.6404f, 0f));
                        Fires.Add(new Vector4(-2265.085f, 220.6445f, 183.7005f, 0f));
                        Fires.Add(new Vector4(-2229.959f, 208.5015f, 193.6066f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(-2972.835f, 413.6099f, 14.22648f, 0f));
                        Fires.Add(new Vector4(-2990.377f, 417.0118f, 23.85259f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(-3170.601f, 1092.951f, 19.85954f, 0f));
                        Fires.Add(new Vector4(-3175.083f, 1058.582f, 24.48407f, 0f));
                        Fires.Add(new Vector4(-3169.532f, 1055.47f, 26.65624f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(-2952.258f, 39.01147f, 10.61715f, 0f));
                        Fires.Add(new Vector4(-2951.121f, 43.23766f, 18.24514f, 0f));
                        Fires.Add(new Vector4(-2938.926f, 45.65293f, 19.0999f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(-2043.044f, -131.8538f, 26.65075f, 0f));
                        Fires.Add(new Vector4(-2096.824f, -115.0337f, 39.50086f, 0f));
                        Fires.Add(new Vector4(-2211.156f, -0.8868051f, 91.96025f, 0f));
                        Fires.Add(new Vector4(-2289.029f, -2.836433f, 117.8311f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(-3094.541f, 757.3378f, 20.58059f, 0f));
                        Fires.Add(new Vector4(-3079.948f, 766.7496f, 30.36243f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(-3037.003f, 544.0945f, 6.507683f, 0f));
                        Fires.Add(new Vector4(-3048.037f, 550.2264f, 11.97215f, 0f));
                        Fires.Add(new Vector4(-3044.569f, 552.6439f, 12.55266f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(-2183.936f, 274.093f, 168.6071f, 0f));
                        Fires.Add(new Vector4(-2183.556f, 245.7094f, 183.6018f, 0f));
                        Fires.Add(new Vector4(-2210.163f, 287.6249f, 193.6047f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire03[RandomX.FindRandom("FindingFiresA03Mad", 0, MadFire03.Count - 1)]);
                }                            //chase driver throwing molitovs
            }
            else if (iArea == 4)
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire04[RandomX.FindRandom("FindingFiresA04Wb", 0, BinFire04.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA04Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(1176.709f, -401.3213f, 66.86218f, 0f));
                        Fires.Add(new Vector4(1172.744f, -389.3003f, 70.58459f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(1050.432f, 203.0428f, 80.00118f, 0f));
                        Fires.Add(new Vector4(1045.66f, 192.4007f, 83.99088f, 0f));
                        Fires.Add(new Vector4(1038.867f, 157.8588f, 89.24052f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(2543.799f, -433.5045f, 93.12083f, 0f));
                        Fires.Add(new Vector4(2540.221f, -438.1306f, 96.81189f, 0f));
                        Fires.Add(new Vector4(2538.54f, -438.1291f, 100.2687f, 0f));
                        Fires.Add(new Vector4(2522.876f, -438.5635f, 113.0892f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(2737.933f, 1522.518f, 23.50071f, 0f));
                        Fires.Add(new Vector4(2758.451f, 1527.956f, 31.50706f, 0f));
                        Fires.Add(new Vector4(2752.74f, 1541.158f, 39.33219f, 0f));
                        Fires.Add(new Vector4(2745.437f, 1520.103f, 41.88893f, 0f));
                        Fires.Add(new Vector4(2747.897f, 1525.129f, 47.15131f, 0f));
                        Fires.Add(new Vector4(2735.234f, 1537.351f, 49.69622f, 0f));
                        Fires.Add(new Vector4(2719.178f, 1541.375f, 49.53091f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(2747.737f, 1559.18f, 23.50095f, 0f));
                        Fires.Add(new Vector4(2768.139f, 1564.615f, 31.50669f, 0f));
                        Fires.Add(new Vector4(2761.064f, 1559.337f, 39.33364f, 0f));
                        Fires.Add(new Vector4(2755.404f, 1556.733f, 41.88876f, 0f));
                        Fires.Add(new Vector4(2757.495f, 1561.938f, 47.1517f, 0f));
                        Fires.Add(new Vector4(2745.225f, 1573.99f, 49.69639f, 0f));
                        Fires.Add(new Vector4(2735.578f, 1576.091f, 49.53191f, 0f));
                        Fires.Add(new Vector4(2728.982f, 1577.459f, 65.53811f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(2369.055f, 2197.838f, 101.866f, 0f));
                        Fires.Add(new Vector4(2368.969f, 2193.18f, 104.6187f, 0f));
                        Fires.Add(new Vector4(2368.872f, 2186.679f, 139.6358f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(2674.238f, 2794.201f, 31.81267f, 0f));
                        Fires.Add(new Vector4(2676.679f, 2791.165f, 39.51861f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(1911.586f, 578.1634f, 175.3678f, 0f));
                        Fires.Add(new Vector4(1902.479f, 612.1648f, 189.4232f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(1662.736f, -22.32487f, 172.5064f, 0f));
                        Fires.Add(new Vector4(1666.577f, -27.66433f, 183.7772f, 0f));
                        Fires.Add(new Vector4(1665.025f, -27.98582f, 195.9362f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(744.8895f, 603.6869f, 124.9338f, 0f));
                        Fires.Add(new Vector4(717.8181f, 594.5558f, 136.3117f, 0f));
                        Fires.Add(new Vector4(724.5558f, 592.4565f, 139.7948f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire04[RandomX.FindRandom("FindingFiresA04Mad", 0, MadFire04.Count - 1)]);
                }                            //chase driver throwing molitovs
            }
            else if (iArea == 5)
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire05[RandomX.FindRandom("FindingFiresA05Wb", 0, BinFire05.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA05Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(1131.608f, 2177.422f, 48.3606f, 0f));
                        Fires.Add(new Vector4(1131.583f, 2172.774f, 51.11588f, 0f));
                        Fires.Add(new Vector4(1130.349f, 2175.294f, 74.79888f, 0f));
                        Fires.Add(new Vector4(1131.086f, 2171.276f, 78.27214f, 0f));
                        Fires.Add(new Vector4(1132.542f, 2172.199f, 86.30864f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(1045.85f, 2280.369f, 49.70117f, 0f));
                        Fires.Add(new Vector4(1050.772f, 2280.446f, 51.45603f, 0f));
                        Fires.Add(new Vector4(1051.557f, 2283.604f, 75.13608f, 0f));
                        Fires.Add(new Vector4(1014.338f, 2236.634f, 78.60358f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(946.3651f, 2413.913f, 50.44973f, 0f));
                        Fires.Add(new Vector4(948.6259f, 2409.764f, 53.2018f, 0f));
                        Fires.Add(new Vector4(951.6443f, 2408.019f, 76.8914f, 0f));
                        Fires.Add(new Vector4(957.8938f, 2393.696f, 80.67262f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(287.476f, 2872.253f, 42.64721f, 0f));
                        Fires.Add(new Vector4(285.8731f, 2871.332f, 55.86985f, 0f));
                        Fires.Add(new Vector4(271.0888f, 2863.196f, 63.93308f, 0f));
                        Fires.Add(new Vector4(267.5765f, 2866.448f, 73.17478f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(2675.507f, 3468.64f, 55.55955f, 0f));
                        Fires.Add(new Vector4(2701.592f, 3492.359f, 62.76652f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(1574.704f, 3358.57f, 37.43276f, 0f));
                        Fires.Add(new Vector4(1574.83f, 3361.074f, 42.12829f, 0f));
                        Fires.Add(new Vector4(1574.762f, 3364.033f, 48.63499f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(2121.196f, 2918.85f, 47.65158f, 0f));
                        Fires.Add(new Vector4(2106.017f, 2928.885f, 59.93315f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(2368.762f, 4941.804f, 42.48777f, 0f));
                        Fires.Add(new Vector4(2370.867f, 4938.896f, 66.73099f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(2885.729f, 4330.319f, 49.41188f, 0f));
                        Fires.Add(new Vector4(2902.985f, 4331.645f, 91.31193f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(1987.044f, 5025.16f, 40.0343f, 0f));
                        Fires.Add(new Vector4(1990.572f, 5026.928f, 60.6032f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire05[RandomX.FindRandom("FindingFiresA05Mad", 0, MadFire05.Count - 1)]);
                }                            //chase driver throwing molitovs
            }
            else
            {
                if (type == 1)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 8, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                }                //Put out fire vehicle
                else if (type == 2)
                {
                    FubarVectors Fb = PickUpApartmentBlocks(iArea, 7, true);
                    Fires.Add(Fb.ParkHere);
                    Fires.Add(Fb.PedHere);
                    Fires.Add(new Vector4(Fb.PedNum, 0f, 0f, 0f));
                }           //Put out fire house
                else if (type == 3)
                {
                    Fires.Add(BinFire06[RandomX.FindRandom("FindingFiresA06Wb", 0, BinFire06.Count - 1)]);
                }           //Put out fire Weeley bin
                else if (type == 4)
                {
                    int iCat = RandomX.FindRandom("FindingFiresA06Cat", 1, 10);
                    if (iCat == 1)
                    {
                        Fires.Add(new Vector4(476.7609f, 5564.091f, 786.7924f, 0f));
                        Fires.Add(new Vector4(465.2097f, 5564.118f, 789.1517f, 0f));
                        Fires.Add(new Vector4(443.056f, 5571.859f, 793.0636f, 0f));
                    }
                    else if (iCat == 2)
                    {
                        Fires.Add(new Vector4(-529.29f, 5296.477f, 73.17416f, 0f));
                        Fires.Add(new Vector4(-533.8841f, 5298.164f, 75.22298f, 0f));
                        Fires.Add(new Vector4(-547.3457f, 5307.155f, 80.70724f, 0f));
                        Fires.Add(new Vector4(-549.8339f, 5308.257f, 113.1458f, 0f));
                    }
                    else if (iCat == 3)
                    {
                        Fires.Add(new Vector4(-378.7972f, 6082.82f, 30.44448f, 0f));
                        Fires.Add(new Vector4(-380.0973f, 6087.844f, 43.25361f, 0f));
                    }
                    else if (iCat == 4)
                    {
                        Fires.Add(new Vector4(-116.5642f, 6095.181f, 30.08812f, 0f));
                        Fires.Add(new Vector4(-114.667f, 6095.59f, 49.65103f, 0f));
                        Fires.Add(new Vector4(-120.6208f, 6103.851f, 65.39037f, 0f));
                    }
                    else if (iCat == 5)
                    {
                        Fires.Add(new Vector4(-133.8914f, 6153.745f, 30.33397f, 0f));
                        Fires.Add(new Vector4(-140.6442f, 6153.557f, 38.75406f, 0f));
                        Fires.Add(new Vector4(-178.2877f, 6156.795f, 41.53918f, 0f));
                        Fires.Add(new Vector4(-178.427f, 6146.682f, 41.63742f, 0f));
                    }
                    else if (iCat == 6)
                    {
                        Fires.Add(new Vector4(-211.7788f, 6119.181f, 30.46959f, 0f));
                        Fires.Add(new Vector4(-210.7851f, 6117.274f, 41.10376f, 0f));
                        Fires.Add(new Vector4(-211.6232f, 6125.68f, 49.80574f, 0f));
                        Fires.Add(new Vector4(-215.0806f, 6122.5f, 56.27292f, 0f));
                    }
                    else if (iCat == 7)
                    {
                        Fires.Add(new Vector4(106.5499f, 6322.443f, 30.39839f, 0f));
                        Fires.Add(new Vector4(107.8129f, 6330.101f, 43.49488f, 0f));
                    }
                    else if (iCat == 8)
                    {
                        Fires.Add(new Vector4(433.916f, 6462.895f, 27.76925f, 0f));
                        Fires.Add(new Vector4(421.8325f, 6471.436f, 36.08047f, 0f));
                    }
                    else if (iCat == 9)
                    {
                        Fires.Add(new Vector4(-45.65552f, 6185.589f, 30.0194f, 0f));
                        Fires.Add(new Vector4(-47.4403f, 6176.68f, 37.69144f, 0f));
                    }
                    else if (iCat == 10)
                    {
                        Fires.Add(new Vector4(-1007.743f, 4837.706f, 268.5457f, 0f));
                        Fires.Add(new Vector4(-1007.268f, 4842.294f, 271.2487f, 0f));
                        Fires.Add(new Vector4(-1000.971f, 4851.799f, 273.6058f, 0f));
                    }
                }           //save cat
                else
                {
                    Fires.Add(MadFire06[RandomX.FindRandom("FindingFiresA06Mad", 0, MadFire06.Count - 1)]);
                }                            //chase driver throwing molitovs
            }

            return Fires;
        }
        public static BombSquad SortOutBs(int iArea)
        {
            BombSquad YourBomb = null;

            if (iArea == 1)
            {
                int iRand = RandomX.FindRandom("SortOutBs01", 0, BsArea01.Count - 1);
                YourBomb = BsArea01[iRand];
            }
            else if (iArea == 2)
            {
                int iRand = RandomX.FindRandom("SortOutBs02", 0, BsArea02.Count - 1);
                YourBomb = BsArea02[iRand];
            }
            else if (iArea == 3)
            {
                int iRand = RandomX.FindRandom("SortOutBs03", 0, BsArea03.Count - 1);
                YourBomb = BsArea03[iRand];
            }
            else if (iArea == 4)
            {
                int iRand = RandomX.FindRandom("SortOutBs04", 0, BsArea04.Count - 1);
                YourBomb = BsArea04[iRand];
            }
            else if (iArea == 5)
            {
                int iRand = RandomX.FindRandom("SortOutBs02", 0, BsArea05.Count - 1);
                YourBomb = BsArea05[iRand];
            }
            else if (iArea == 6)
            {
                int iRand = RandomX.FindRandom("SortOutBs06", 0, BsArea06.Count - 1);
                YourBomb = BsArea06[iRand];
            }
            else if (iArea == 7)
            {
                int iRand = RandomX.FindRandom("SortOutBs07", 0, BsArea07.Count - 1);
                YourBomb = BsArea07[iRand];
            }
            else if (iArea == 8)
            {
                int iRand = RandomX.FindRandom("SortOutBs08", 0, BsArea08.Count - 1);
                YourBomb = BsArea08[iRand];
            }
            else if (iArea == 9)
            {
                int iRand = RandomX.FindRandom("SortOutBs09", 0, BsArea09.Count - 1);
                YourBomb = BsArea09[iRand];
            }

            return YourBomb;
        }
        public static SnipSnip Snippy(int iArea)
        {
            SnipSnip MySnip = null;
            if (iArea == 1)
                MySnip = Sniping01[RandomX.FindRandom("Snippy01", 0, Sniping01.Count)];
            else if (iArea == 2)
                MySnip = Sniping02[RandomX.FindRandom("Snippy02", 0, Sniping02.Count)];
            else if (iArea == 3)
                MySnip = Sniping03[RandomX.FindRandom("Snippy03", 0, Sniping03.Count)];
            else if (iArea == 4)
                MySnip = Sniping04[RandomX.FindRandom("Snippy04", 0, Sniping04.Count)];
            else if (iArea == 5)
                MySnip = Sniping05[RandomX.FindRandom("Snippy05", 0, Sniping05.Count)];
            else if (iArea == 6)
                MySnip = Sniping06[RandomX.FindRandom("Snippy06", 0, Sniping06.Count)];
            else if (iArea == 7)
                MySnip = Sniping07[RandomX.FindRandom("Snippy07", 0, Sniping07.Count)];
            else if (iArea == 8)
                MySnip = Sniping08[RandomX.FindRandom("Snippy08", 0, Sniping08.Count)];
            else if (iArea == 9)
                MySnip = Sniping09[RandomX.FindRandom("Snippy09", 0, Sniping09.Count)];

            return MySnip;
        }
        public static List<PhishingSpot> FindPhisherMen()
        {
            LoggerLight.LogThis("Water03_RandDest");

            int iDests = 8;
            List<PhishingSpot> YourSpots = new List<PhishingSpot>();
            List<int> numbers = new List<int>();
            while (numbers.Count < iDests)
            {
                int iBe = RandomX.FindRandom("FindPhisherMen", 0, PhisherMen.Count - 1);
                if (!numbers.Contains(iBe))
                    numbers.Add(iBe);
                Script.Wait(1);
            }
            numbers.Sort();

            for (int i = 0; i < numbers.Count; i++)
                YourSpots.Add(PhisherMen[numbers[i]]);
            YourSpots.Reverse();

            return YourSpots;
        }
        public static LoanSharks FindSharks(int iArea)
        {
            LoanSharks Sharky = null;
            if (iArea == 1)
                Sharky = Sharky01[RandomX.FindRandom("FindSharks01", 0, Sharky01.Count -1)];
            else if (iArea == 2)
                Sharky = Sharky02[RandomX.FindRandom("FindSharks02", 0, Sharky02.Count - 1)];
            else if (iArea == 3)
                Sharky = Sharky03[RandomX.FindRandom("FindSharks03", 0, Sharky03.Count - 1)];
            else if (iArea == 4)
                Sharky = Sharky04[RandomX.FindRandom("FindSharks04", 0, Sharky04.Count - 1)];
            else if (iArea == 5)
                Sharky = Sharky05[RandomX.FindRandom("FindSharks05", 0, Sharky05.Count - 1)];
            else if (iArea == 6)
                Sharky = Sharky06[RandomX.FindRandom("FindSharks06", 0, Sharky06.Count - 1)];
            else if (iArea == 7)
                Sharky = Sharky07[RandomX.FindRandom("FindSharks07", 0, Sharky07.Count - 1)];
            else if (iArea == 8)
                Sharky = Sharky08[RandomX.FindRandom("FindSharks08", 0, Sharky08.Count - 1)];
            else if (iArea == 9)
                Sharky = Sharky09[RandomX.FindRandom("FindSharks09", 0, Sharky09.Count - 1)];

            return Sharky;
        }
    }
}
