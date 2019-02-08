using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKFormsFinal
{
    class WhileBlock : Blocks
    {
        public override void Draw(int i)
        {
            base.Draw(i);
            DrawIf();
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            WhileLevel = 1 + IfLevel;
            CurrentCount++;
            GL.Translate(0, -2, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3f, 0);
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(3f, -3f, 0);
            DrawConnectLine(Textures.Instance.textureFalse);
            GL.Translate(0f, 6f, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
        }

        protected void DrawIf()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.Current);

            GL.Begin(PrimitiveType.Quads);

            // задняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);

            //передняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);

            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public override string ToString()
        {
            return "While";
        }
    }
}
