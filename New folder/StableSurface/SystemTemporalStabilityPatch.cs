using HarmonyLib;
using System;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.ServerMods;

namespace StableSurface
{
    [HarmonyPatch(typeof(SystemTemporalStability))]
    [HarmonyPatch("GetTemporalStability",
    new Type[] { typeof(double), typeof(double), typeof(double) })] 
    //specifying which method of GetTemporalStability to change
    public class SystemTemporalStabilityPatch : ModSystem
    {       


        public static void Postfix(ref float __result, ref double x, ref double y, ref double z, SystemTemporalStability __instance)
        {


            TemporalStormRunTimeData instanceStormData = __instance.StormData; 
            //grabbing the SystemTemporalStability instance to use nowStormActive

            if (y >= TerraGenConfig.seaLevel - 10 && instanceStormData.nowStormActive == false) 
                //checking to see is the given y location is above the worlds sea level - 10. As well as Whether or not a temporal storm is active
            {
                __result = 1.5f; // Set the result to 1.5f when y is greater than or equal to seaLevel
            }
        }

    }



}

