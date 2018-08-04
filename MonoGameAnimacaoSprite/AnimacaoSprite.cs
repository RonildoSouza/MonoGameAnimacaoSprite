using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameAnimacaoSprite
{
    public abstract class AnimacaoSprite
    {
        public bool Ativado = false;
        public Vector2 Posicao = Vector2.Zero;

        protected abstract int TotalLinhasNaSprite { get; }
        protected abstract int TotalColunasNaSprite { get; }

        private Texture2D _textura;
        private int _frameLargura;
        private int _frameAltura;
        private Rectangle _regiaoDaTextura = Rectangle.Empty;
        private int _frameAtualDaColuna;
        private TimeSpan _acumulaTempo = TimeSpan.Zero;

        /// <summary>
        /// Carrega a textura e define a largura, altura do frame e a 
        /// primeira região da textura que será renderizada na tela.
        /// </summary>
        /// <param name="content">Objeto gerenciador de conteudos</param>
        /// <param name="assetName">Nome do arquivo de sprite</param>
        public void LoadContent(ContentManager content, string assetName)
        {
            _textura = content.Load<Texture2D>(assetName);

            _frameLargura = _textura.Width / TotalColunasNaSprite;
            _frameAltura = _textura.Height / TotalLinhasNaSprite;

            _regiaoDaTextura = new Rectangle(0, 0, _frameLargura, _frameAltura);
        }

        /// <summary>
        /// Atualiza a posição X, Y da variavel _regiaoDaTextura para renderizar uma nova região da textura.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="regiaoPosY">Posição que define a direção do sprite.</param>
        public void Animacao(ref GameTime gameTime, int regiaoPosY)
        {
            if (!Ativado)
                return;

            // Acumula o tempo com o tempo decorrido do jogo
            // para mudar o frame da sprite a cada 100 milissegundos.
            _acumulaTempo += gameTime.ElapsedGameTime;

            if (_acumulaTempo >= TimeSpan.FromMilliseconds(100))
            {
                _frameAtualDaColuna++;

                if (_frameAtualDaColuna == TotalColunasNaSprite)
                    _frameAtualDaColuna = 0;

                _acumulaTempo = TimeSpan.Zero;
            }

            // Define a nova região da textura que será renderizada na tela.
            _regiaoDaTextura.X = _frameAtualDaColuna * _frameLargura;
            _regiaoDaTextura.Y = regiaoPosY;
        }

        /// <summary>
        /// Renderiza a textura com a nova posição e região.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textura, Posicao, _regiaoDaTextura, Color.White);
        }
    }
}