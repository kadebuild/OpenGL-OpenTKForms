using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKFormsFinal
{
    class EndWhileBlock : Blocks
    {
        public override void Draw(int i)
        {
            base.Draw(i);
            CurrentCount++;
            WhileLevel--;
            GL.Rotate(90, Vector3.UnitZ);
            GL.Translate(0f, 0.75f, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
            GL.Translate(0f, 2f, 0);
            DrawConnectLine(Textures.Instance.textureTrue);
            GL.Translate(-1f, -3.5f, 0);
            DrawConnectLine(Textures.Instance.textureFalse);
            GL.Translate(0f, -2f, 0);
            DrawConnectLine(Textures.Instance.textureFalse);
        }

        public override string ToString()
        {
            return "End While";
        }
    }
}
