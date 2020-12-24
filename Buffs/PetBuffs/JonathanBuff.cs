using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PetBuffs
{
    public class JonathanPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Jonathan Pet");
            Description.SetDefault("Ele acredita em você.");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("JonathanPet")] != 0)
            {
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}
