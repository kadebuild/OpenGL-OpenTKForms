using OpenTK.Graphics.OpenGL;

namespace OpenTKFormsFinal
{
    class ForBlock : Blocks
    {
        public override void Draw(int i)
        {
            base.Draw(i);
            DrawFor();
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            CurrentCount++;
            if ((List.Count - i) > 1)
            {
                GL.Translate(0, -2, 0);
                DrawConnectLine(Textures.Instance.textureTrue);
            }
        }

        private void DrawFor()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.Current);
            GL.Begin(PrimitiveType.Quads);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            // левая верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            // правая верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            //передняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            // задняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(-0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public override string ToString()
        {
            return "For";
        }
    }
}
