using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.ItemBuff
{
    public class RUUUN : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("CORREE!");
            Description.SetDefault("A Tecnica Secreta Dos Joestar- não há vergonha!");
            Main.buffNoTimeDisplay[Type] = true;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 2f;
        }
    }
}
