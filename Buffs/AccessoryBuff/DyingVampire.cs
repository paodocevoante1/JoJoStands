using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.AccessoryBuff
{
    public class DyingVampire : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Vampiro Morrendo");
            Description.SetDefault("Apenas sua cabeça permanece.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        private int SRSETimer = 0;
        private bool buried = false;

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            if (!buried && WorldGen.SolidTile((int)player.position.X / 16, ((int)player.position.Y / 16) + 4))
            {
                player.position.Y += 10f;
                buried = true;
            }

            player.lifeRegenCount -= 10;
            player.dash = 0;
            player.controlUseItem = false;
            player.bodyVelocity = Vector2.Zero;
            player.controlLeft = false;
            player.controlJump = false;
            player.controlRight = false;
            player.controlDown = false;
            player.controlQuickHeal = false;
            player.controlQuickMana = false;
            player.controlRight = false;
            player.controlUseTile = false;
            player.controlUp = false;
            player.maxRunSpeed = 0f;
            player.moveSpeed = 0f;

            mPlayer.dyingVampire = true;
            mPlayer.Vampire = true;
            player.buffTime[buffIndex] = 2;

            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.mouseLeft)
                {
                    SRSETimer++;
                    Dust.NewDust(player.Center + new Vector2(0f, -6f), 2, 2, 226);
                }
                if (SRSETimer >= 90)
                {
                    Vector2 shootVel = Main.MouseWorld - player.Center;
                    if (shootVel == Vector2.Zero)
                    {
                        shootVel = new Vector2(0f, 1f);
                    }
                    shootVel.Normalize();
                    shootVel *= 12f;
                    int proj = Projectile.NewProjectile(player.Center.X, player.Center.Y - 20f, shootVel.X, shootVel.Y, mod.ProjectileType("SpaceRipperStingyEyes"), 82, 4f, Main.myPlayer, 1f);
                    Main.projectile[proj].netUpdate = true;
                    SRSETimer = 0;
                }
            }
        }
    }
}
