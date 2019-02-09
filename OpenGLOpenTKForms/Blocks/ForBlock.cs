using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    class ForBlock : Blocks
    {
        protected override void StartDraw()
        {
            base.StartDraw();
            DrawFor();
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            if ((List.Count - CurrentCount++) > 1)
            {
                GL.Translate(0, -2, 0);
                DrawConnectionLine(Textures.Instance.textureTrue);
            }
        }

        private void DrawFor()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.Current);
            GL.Begin(PrimitiveType.Quads);

            // Bottom side
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);

            // Left side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            // Up side
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);

            // Right side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            // Left upper side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            // Right upper side
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
            // Forward side
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
            // Back side
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
