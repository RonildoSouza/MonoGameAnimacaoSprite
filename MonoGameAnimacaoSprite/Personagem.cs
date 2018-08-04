using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace MonoGameAnimacaoSprite
{
    public class Personagem : AnimacaoSprite
    {
        protected override int TotalLinhasNaSprite => 4;
        protected override int TotalColunasNaSprite => 4;

        public Vector2 Velocidade = new Vector2(300f);

        public void Mover(ref GameTime gameTime)
        {
            double tempoDecorridoJogo = gameTime.ElapsedGameTime.TotalSeconds;
            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                TouchLocation touch = touchCollection[0];
                bool moverNaHorizontal = Math.Abs(touch.Position.X - Posicao.X) > Math.Abs(touch.Position.Y - Posicao.Y);
                Ativado = true;

                if (moverNaHorizontal)
                {
                    // Direita
                    if (Posicao.X < touch.Position.X)
                    {
                        Animacao(ref gameTime, 899);
                        Posicao.X += (float)(Velocidade.X * tempoDecorridoJogo);
                    }
                    else
                    // Esquerda
                    {
                        Animacao(ref gameTime, 599);
                        Posicao.X -= (float)(Velocidade.X * tempoDecorridoJogo);
                    }
                }
                else
                {
                    // Para Baixo
                    if (Posicao.Y < touch.Position.Y)
                    {
                        Animacao(ref gameTime, 0);
                        Posicao.Y += (float)(Velocidade.Y * tempoDecorridoJogo);
                    }
                    else
                    // Para Cima
                    {
                        Animacao(ref gameTime, 299);
                        Posicao.Y -= (float)(Velocidade.Y * tempoDecorridoJogo);
                    }
                }
            }

            Ativado = false;
        }
    }
}