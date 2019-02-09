using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    class EndIfBlock : Blocks
    {
        protected override void StartDraw()
        {
            base.StartDraw();
            CurrentCount++;
            IfLevel--;
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(0f, 0.75f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
            GL.Translate(0f, 2f, 0);
            DrawConnectionLine(Textures.Instance.textureTrue);
        }

        public override string ToString()
        {
            return "End If";
        }
    }
}
