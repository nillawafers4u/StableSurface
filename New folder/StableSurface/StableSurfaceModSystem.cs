using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace StableSurface
{
    public class StableSurfaceModSystem : ModSystem
    {
        public override void StartServerSide(ICoreServerAPI api)
        {
            this.harmony = new Harmony("stablesurface");
            this.harmony.PatchAll();
        }

        public override void Dispose()
        {
            Harmony harmony = this.harmony;
            if (harmony != null)
            {
                harmony.UnpatchAll("stablesurface");
            }
        }

        private Harmony harmony;
    }
}
