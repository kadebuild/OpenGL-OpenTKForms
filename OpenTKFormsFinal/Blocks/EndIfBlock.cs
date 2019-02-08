using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKFormsFinal
{
    class EndIfBlock : Blocks
    {
        public override void Draw(int i)
        {
            base.Draw(i);
            CurrentCount++;
            IfLevel--;
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(0f, 0.75f, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
            GL.Translate(0f, 2f, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
        }

        public override string ToString()
        {
            return "End If";
        }
    }
}
