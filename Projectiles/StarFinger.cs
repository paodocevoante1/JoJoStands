using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace JoJoStands.Projectiles
{
    public class StarFinger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = 0;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        private Projectile ownerProj;
        private bool living = true;
        private bool playedSound = false;

        public override void AI()       //all this so that the other chain doesn't draw... yare yare. It was mostly just picking out types
        {
            //projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);     //aiStyle 13 without the types
            if (!playedSound && JoJoStands.SoundsLoaded)
            {
                Main.PlaySound(JoJoStands.JoJoStandsSounds.GetLegacySoundSlot(SoundType.Custom, "Sounds/SoundEffects/StarFinger"));
                playedSound = true;
            }
            ownerProj = Main.projectile[(int)projectile.ai[0]];
            if (Main.player[projectile.owner].dead || !ownerProj.active)
            {
                projectile.Kill();
                return;
            }
            float direction = ownerProj.Center.X - projectile.Center.X;
            if (direction > 0)
            {
                projectile.direction = -1;
                ownerProj.spriteDirection = ownerProj.direction = -1;
            }
            if (direction < 0)
            {
                projectile.direction = 1;
                ownerProj.spriteDirection = ownerProj.direction = 1;
            }
            //projectile.spriteDirection = projectile.direction;
            Vector2 rota = ownerProj.Center - projectile.Center;
            projectile.rotation = (-rota).ToRotation();
            if (projectile.alpha == 0)
            {
                if (projectile.position.X + (float)(projectile.width / 2) > ownerProj.position.X + (float)(ownerProj.width / 2))
                {
                    ownerProj.spriteDirection = ownerProj.direction = 1;
                }
                else
                {
                    ownerProj.spriteDirection = ownerProj.direction = -1;
                }
            }
            Vector2 vector14 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num166 = ownerProj.position.X + (float)(ownerProj.width / 2) - vector14.X;
            float num167 = ownerProj.position.Y + (float)(ownerProj.height / 2) - vector14.Y;
            float num168 = (float)Math.Sqrt((double)(num166 * num166 + num167 * num167));
            if (living)
            {
                if (num168 > 700f)
                {
                    living = false;
                }
                //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                projectile.ai[1] += 1f;
                if (projectile.ai[1] > 5f)
                {
                    projectile.alpha = 0;
                }
                if (projectile.ai[1] >= 10f)
                {
                    projectile.ai[1] = 15f;
                }
            }
            else if (!living)
            {
                projectile.tileCollide = false;
                //projectile.rotation = (float)Math.Atan2((double)num167, (double)num166) - 1.57f;
                float num169 = 20f;
                if (num168 < 50f)
                {
                    projectile.Kill();
                }
                num168 = num169 / num168;
                num166 *= num168;
                num167 *= num168;
                projectile.velocity.X = num166;
                projectile.velocity.Y = num167;
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            MyPlayer mPlayer = Main.player[projectile.owner].GetModPlayer<MyPlayer>();
            if (Main.rand.NextFloat(0, 101) <= mPlayer.standCritChangeBoosts)
            {
                crit = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            living = false;
            return false;
        }

        private Vector2 offset;
        private Texture2D starFingerPartTexture;

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (ownerProj == null)
                return false;

            if (ownerProj.direction == 1)
            {
                offset = new Vector2(20f, -2f);
            }
            if (ownerProj.direction == -1)
            {
                offset = new Vector2(-31f, -2f);
            }
            if (Main.netMode != NetmodeID.Server)
                starFingerPartTexture = mod.GetTexture("Projectiles/StarFingerPart");

            Vector2 linkCenter = ownerProj.Center + offset;
            Vector2 center = projectile.Center;
            float rotation = (linkCenter - center).ToRotation();

            for (float k = 0; k <= 1; k += 1 / (Vector2.Distance(center, linkCenter) / starFingerPartTexture.Width))     //basically, getting the amount of space between the 2 points, dividing it by the textures width, then making it a fraction, so saying you 'each takes 1/x space, make x of them to fill it up to 1'
            {
                Vector2 pos = Vector2.Lerp(center, linkCenter, k) - Main.screenPosition;       //getting the distance and making points by 'k', then bringing it into view
                spriteBatch.Draw(starFingerPartTexture, pos, new Rectangle(0, 0, starFingerPartTexture.Width, starFingerPartTexture.Height), lightColor, rotation, new Vector2(starFingerPartTexture.Width * 0.5f, starFingerPartTexture.Height * 0.5f), projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}