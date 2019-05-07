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
using Game1.GameCode.Obstacles;

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
                    if(temp.Type == "Enviroment")
                    pSprite.Draw(temp.Texture, temp.Position, temp.Bounds, Color.White, temp.Angle, temp.Origin, temp.Scale, SpriteEffects.None, (temp.RenderLayer + layer));


               
            }
           
            foreach (IGameObject temp in tempEnts)
            {

                if (temp.Visible)
                    if (!(temp.Type == "Enviroment"))
                        pSprite.Draw(temp.Texture, temp.Position, temp.Bounds, Color.White, temp.Angle, temp.Origin, temp.Scale, SpriteEffects.None, (temp.RenderLayer + layer));


                layer += 0.000001f;
            }
            pSprite.End();
        }

        public void Draw(SpriteBatch pSprite, List<IMenuItem> pEnts)
        {
            pSprite.Begin();
            foreach (IMenuItem temp in pEnts)
            {

                  
                    pSprite.Draw(temp.Texture, temp.Position, temp.Bounds, Color.White, temp.Angle, temp.Origin, temp.Scale, SpriteEffects.None, 1);


            }
            pSprite.End();
        }

        public void Draw(SpriteBatch pSprite, SpriteFont pFont, List<ITextElement> pText)
        {
            foreach (ITextElement temp in pText)
            {
                pSprite.Begin();
                pSprite.DrawString(pFont, "" + temp.getValue, new Vector2(temp.getParent.XPosition + temp.getXOffest, temp.getParent.YPosition + temp.getYOffest), Color.Black);
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
