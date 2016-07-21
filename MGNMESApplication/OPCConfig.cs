using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGNMESApplication
{
    public static class OPCConfig
    {
        public static string Server;
        public static string WorkStation1;
        public static string WorkStation2;

        public static string Channel;
        public static string Device;
        public static int TagCount;

        public static string Tag_Alarm;
        public static string Tag_Finish;
        public static string Tag_Start;
        public static string Tag_StepNumber;
        public static string Tag_Product_VIN;
        public static string Tag_Scan_Code_Gun;
        public static string Tag_Torque_Angle;
        public static string Tag_Torque_Value;
        public static string Tag_MatchResult;
        public static string Tag_TraceCode;

        public static string Addr_Alarm;
        public static string Addr_Finish;
        public static string Addr_Start;
        public static string Addr_StepNumber;
        public static string Addr_Product_VIN;
        public static string Addr_Scan_Code_Gun;
        public static string Addr_Torque_Angle;
        public static string Addr_Torque_Value;
        public static string Addr_MatchResult;
        public static string Addr_TraceCode;

        public static void SettingTagAddress(string WorkStation)
        {
            Addr_Alarm = Channel + "." + Device + "." + WorkStation + "." + Tag_Alarm;
            Addr_Finish = Channel + "." + Device + "." + WorkStation + "." + Tag_Finish;
            Addr_Start = Channel + "." + Device + "." + WorkStation + "." + Tag_Start;
            Addr_StepNumber = Channel + "." + Device + "." + WorkStation + "." + Tag_StepNumber;
            Addr_Product_VIN = Channel + "." + Device + "." + WorkStation + "." + Tag_Product_VIN;
            Addr_Scan_Code_Gun = Channel + "." + Device + "." + WorkStation + "." + Tag_Scan_Code_Gun;
            Addr_Torque_Angle = Channel + "." + Device + "." + WorkStation + "." + Tag_Torque_Angle;
            Addr_Torque_Value = Channel + "." + Device + "." + WorkStation + "." + Tag_Torque_Value;
            Addr_MatchResult = Channel + "." + Device + "." + WorkStation + "." + Tag_MatchResult;
            Addr_TraceCode = Channel + "." + Device + "." + WorkStation + "." + Tag_TraceCode;
        }
    }

    public  enum OPCConfigEnum:int
    {
        Alarm=1,
        Finish,
        Start,
        StepNumber,
        Product_VIN,
        Scan_Code_Gun,
        Torque_Angle,
        Torque_Value,
        MatchResult,
        TraceCode
    }
}
