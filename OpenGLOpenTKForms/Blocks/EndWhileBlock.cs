using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    class EndWhileBlock : Blocks
    {
        protected override void StartDraw()
        {
            base.StartDraw();
            CurrentCount++;
            WhileLevel--;
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(0f, 0.75f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
            GL.Translate(0f, 2f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
            GL.Translate(-1f, -3.5f, 0);
            DrawConnectionLine(Textures.Instance.textureFalse);
            GL.Translate(0f, -2f, 0);
            DrawConnectionLine(Textures.Instance.textureFalse);
        }

        public override string ToString()
        {
            return "End While";
        }
    }
}
