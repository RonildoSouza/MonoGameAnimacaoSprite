using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameAnimacaoSprite
{
    public class Boy : SpriteAnimation
    {
        float _x = 0;
        float _y = 0;


        public void Move(ref TouchCollection touchCollection, ref GameTime gameTime)
        {
            double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;            

            foreach (var tc in touchCollection)
            {
                if (tc.State == TouchLocationState.Pressed)
                {
                    _x = tc.Position.X;
                    _y = tc.Position.Y;
                }
            }

            if(Position.X < _x)
            {
                IsActived = true;
                Animation(ref gameTime, 899);
                Position.X += (float)(Velocity.X * deltaTime);
            }

            if (Position.Y < _y)
            {
                IsActived = true;
                Animation(ref gameTime, 0);
                Position.Y += (float)(Velocity.Y * deltaTime);
            }

            //if (Position.X > _x)
            //{
            //    IsActived = true;
            //    Animation(ref gameTime, 599);
            //    Position.X -= (float)(Velocity.X * deltaTime);
            //}

            System.Diagnostics.Debug.WriteLine(_x);

            IsActived = false;
        }
    }

    //    public void Move(ref TouchCollection touchCollection, ref GameTime gameTime)
    //    {
    //        double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;

    //        foreach (var tc in touchCollection)
    //        {
    //            if(tc.State == TouchLocationState.Pressed || tc.State == TouchLocationState.Moved)
    //            {
    //                // RIGHT
    //                if(Position.X < tc.Position.X)
    //                {
    //                    IsActived = true;
    //                    Animation(ref gameTime, 899);
    //                    Position.X += (float)(Velocity.X * deltaTime);
    //                }

    //                // LEFT
    //                if (Position.X > tc.Position.X)
    //                {
    //                    IsActived = true;
    //                    Animation(ref gameTime, 599);
    //                    Position.X -= (float)(Velocity.X * deltaTime);
    //                }

    //                // UP
    //                if (Position.Y > tc.Position.Y)
    //                {
    //                    IsActived = true;
    //                    Animation(ref gameTime, 299);
    //                    Position.Y -= (float)(Velocity.Y * deltaTime);
    //                }

    //                // DOWN
    //                if (Position.Y < tc.Position.Y)
    //                {
    //                    IsActived = true;
    //                    Animation(ref gameTime, 0);
    //                    Position.Y += (float)(Velocity.Y * deltaTime);
    //                }

    //                System.Diagnostics.Debug.WriteLine(Position);
    //            }
    //        }

    //        IsActived = false;
    //    }
    //}
}