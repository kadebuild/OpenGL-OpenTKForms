using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    class IfBlock : Blocks
    {
        protected override void StartDraw()
        {
            base.StartDraw();
            DrawIf();
            IfLevel++;
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            CurrentCount++;
            GL.Translate(0f, -1.1f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(3f, 1.8f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
            GL.Translate(0f, -1.05f, 0f);
            DrawConnectionLine(Textures.Instance.textureTrue);
        }

        private void DrawIf()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.Current);

            GL.Begin(PrimitiveType.Quads);

            // Back side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);

            // Bottom side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);

            // Left side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);

            // Forward side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);

            // Up side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);

            // Right side
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
            return "If";
        }
    }
}
