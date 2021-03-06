using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Projectiles
{
    public class FireAnkh : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 20;
            projectile.aiStyle = 0;
            projectile.timeLeft = 360;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.penetrate = 2;
        }

        private bool playedSound = false;

        public override void AI()
        {
            if (!playedSound)
            {
                Main.PlaySound(SoundID.Item20);
                playedSound = true;
            }
            if (projectile.wet || projectile.honeyWet)
            {
                projectile.scale -= 0.05f;
            }
            if (projectile.scale <= 0f)
            {
                projectile.Kill();
            }
            int num109 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 3.5f);
            Main.dust[num109].noGravity = true;
            Main.dust[num109].velocity *= 1.4f;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            if (Main.rand.NextFloat(0, 101) <= mPlayer.standCritChangeBoosts)
            {
                crit = true;
            }
            if (Main.rand.Next(0, 101) < projectile.ai[0])
            {
                target.AddBuff(BuffID.OnFire, (int)projectile.ai[1]);
            }
            if (mPlayer.awakenedAmuletEquipped)
            {
                if (Main.rand.NextFloat(0, 101) >= 80)
                {
                    target.AddBuff(mod.BuffType("Infected"), 60 * 9);
                }
            }
            if (mPlayer.crackedPearlEquipped)
            {
                if (Main.rand.NextFloat(0, 101) >= 60)
                {
                    target.AddBuff(mod.BuffType("Infected"), 10 * 60);
                }
            }
        }
    }
}