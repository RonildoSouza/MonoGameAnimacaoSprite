using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameAnimacaoSprite
{
    public class SpriteAnimation
    {
        public Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Velocity = Vector2.Zero;
        public int FrameWidth;
        public int FrameHeight;
        public bool IsActived = false;

        private Rectangle _sourceRectangle = Rectangle.Empty;
        private int _totalRowFrame;
        private int _totalColumnFrame;
        private int _currentColumnFrame;
        private TimeSpan _frameTime;
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public void Initialize(int totalRowFrame, int totalColumnFrame, TimeSpan frameTime)
        {
            _totalRowFrame = totalRowFrame;
            _totalColumnFrame = totalColumnFrame;
            _frameTime = frameTime;
        }

        /// <summary>
        /// Carrega a textura e define a largura, altura do frame e seta a primeira imagem da sprite.
        /// </summary>
        /// <param name="content">Objeto gerenciador de conteudos</param>
        /// <param name="assetName">Nome do arquivo de sprite</param>
        public void LoadContent(ContentManager content, string assetName)
        {
            Texture = content.Load<Texture2D>(assetName);

            FrameWidth = Texture.Width / _totalColumnFrame;
            FrameHeight = Texture.Height / _totalRowFrame;

            _sourceRectangle = new Rectangle(0, 0, FrameWidth, FrameHeight);
        }

        /// <summary>
        /// Anima a sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sourcePosY"></param>
        public void Animation(ref GameTime gameTime, int sourcePosY)
        {
            if (!IsActived)
            {
                _sourceRectangle.X = _currentColumnFrame * FrameWidth;
                _sourceRectangle.Y = sourcePosY;
                return;
            }

            // Atualiza o tempo decorrido, com o tempo decorrido do jogo
            // para animar a sprite de acordo com o tempo de _framTime.
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime >= _frameTime)
            {
                _currentColumnFrame++;

                if (_currentColumnFrame == _totalColumnFrame)
                    _currentColumnFrame = 0;

                _elapsedTime = TimeSpan.Zero;
            }

            _sourceRectangle.X = _currentColumnFrame * FrameWidth;
            _sourceRectangle.Y = sourcePosY;
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, _sourceRectangle, Color.White);
        }
    }
}