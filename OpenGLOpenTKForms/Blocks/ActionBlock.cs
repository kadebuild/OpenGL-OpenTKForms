using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    public class ActionBlock : Blocks
    {
        protected override void StartDraw()
        {
            base.StartDraw();
            DrawActionBlock();
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            if ((List.Count - CurrentCount++) > 1)
            {
                GL.Translate(0, -2, 0);
                DrawConnectionLine(Textures.Instance.textureTrue);
            }
        }

        private void DrawActionBlock()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.Current);
            GL.Begin(PrimitiveType.Quads);
            // Back side
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);

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
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);

            // Forward side
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);

            // Up side
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);

            // Right side
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public override string ToString()
        {
            return "Action";
        }
    }
}
