using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Framework.Interfaces;
using Game1.Framework.Interfaces.Managers;
using Game1.Framework.Interfaces.Sub_Entities;

namespace Game1.Framework.Managers
{
    class RenderManager : IRenderManager
    {
        protected ContentManager _Content;

        public RenderManager(ContentManager pContent)
        {
            _Content = pContent;
        }

        public void Draw(SpriteBatch pSprite, List<IGameObject> pEnts)
        {
            List<IGameObject> tempEnts  = pEnts.OrderBy(order => order.lowestPoint).ToList<IGameObject>();
            float layer = 0;
            pSprite.Begin();
            foreach (IGameObject temp in tempEnts)
            {
                
                    if(temp.Visible)
                    pSprite.Draw(temp.Texture, temp.Position, temp.Bounds, Color.White, temp.Angle, temp.Origin, temp.Scale, SpriteEffects.None, (layer + temp.RenderLayer));
               

                layer += 0.001f;
            }
            pSprite.End();
        }

        public void Draw(SpriteBatch pSprite, List<IMenuItem> pEnts)
        {
            foreach (IMenuItem temp in pEnts)
            {
                pSprite.Begin();
                    pSprite.Draw(temp.Texture, temp.Position, temp.Bounds, Color.White, temp.Angle, temp.Origin, temp.Scale, SpriteEffects.None, 0f);
                pSprite.End();
            }
        }

        public void DrawAxies(SpriteBatch pSprite, List<IGameObject> pEnts)
        {
            foreach (IGameObject temp in pEnts)
            {
                pSprite.Begin();
                    pSprite.Draw(temp.Texture, temp.ProjectedX, null, Color.White, temp.ProXAngle, new Vector2(0,0), SpriteEffects.None, 1);
                    pSprite.Draw(temp.Texture, temp.ProjectedY, null, Color.White, temp.ProYAngle, new Vector2(0,0), SpriteEffects.None, 1);
                pSprite.End();
            }
        }
        
        //the funciton of this method ius to srt the entities so that entites which have a lower y value are rendered first so that the layering of objects looks correct
      
        public void Update(GameTime gameTime)
        {

        }

    }
}
