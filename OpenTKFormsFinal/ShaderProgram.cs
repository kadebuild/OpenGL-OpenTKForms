using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;

namespace OpenTKFormsFinal
{
    public sealed class ShaderProgram : IDisposable
    {
        private const int InvalidHandle = -1;

        public int Handle { get; private set; }

        public ShaderProgram()
        {
            AcquireHandle();
        }

        private void AcquireHandle()
        {
            Handle = GL.CreateProgram();
        }

        public void AttachShader(Shader shader)
        {
            //GL.AttachShader(Handle, shader.Handle);
        }

        public void Link()
        {
            GL.LinkProgram(Handle);

            int linkStatus;
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out linkStatus);

            if (linkStatus == 0)
                Console.WriteLine(GL.GetProgramInfoLog(Handle));
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        private void ReleaseHandle()
        {
            if (Handle == InvalidHandle)
                return;

            GL.DeleteProgram(Handle);

            Handle = InvalidHandle;
        }

        public void Dispose()
        {
            ReleaseHandle();
            GC.SuppressFinalize(this);
        }

        ~ShaderProgram()
        {
            if (GraphicsContext.CurrentContext != null && !GraphicsContext.CurrentContext.IsDisposed)
                ReleaseHandle();
        }

        // utility uniform functions
        // ------------------------------------------------------------------------
        public void setBool(string name, bool value)
        {
            GL.Uniform1(GL.GetUniformLocation(Handle, name), value ? 1 : 0);
        }
        // ------------------------------------------------------------------------
        public void setInt(string name, int value)
        {
            GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
        }
        // ------------------------------------------------------------------------
        public void setFloat(string name, float value)
        {
            GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
        }
        // ------------------------------------------------------------------------
        public void setVec2(string name, Vector2 value)
        {
            GL.Uniform2(GL.GetUniformLocation(Handle, name), 1, value[0]);
        }
        public void setVec2(string name, float x, float y)
        {
            GL.Uniform2(GL.GetUniformLocation(Handle, name), x, y);
        }
        // ------------------------------------------------------------------------
        public void setVec3(string name, Vector3d value)
        {
            GL.Uniform3(GL.GetUniformLocation(Handle, name), value.X, value.Y, value.Z);
        }
        public void setVec3(string name, float x, float y, float z)
        {
            GL.Uniform3(GL.GetUniformLocation(Handle, name), x, y, z);
        }
        // ------------------------------------------------------------------------
        public void setVec4(string name, Vector4 value)
        {
            GL.Uniform4(GL.GetUniformLocation(Handle, name), value.X, value.Y, value.Z, value.W);
        }
        public void setVec4(string name, float x, float y, float z, float w)
        {
            GL.Uniform4(GL.GetUniformLocation(Handle, name), x, y, z, w);
        }
        // ------------------------------------------------------------------------
        public void setMat2(string name, ref Matrix2 mat)
        {
            GL.UniformMatrix2(GL.GetUniformLocation(Handle, name), false, ref mat);
        }
        // ------------------------------------------------------------------------
        public void setMat3(string name, ref Matrix3 mat)
        {
            GL.UniformMatrix3(GL.GetUniformLocation(Handle, name), false, ref mat);
        }
        // ------------------------------------------------------------------------
        public void setMat4(string name, Matrix4 mat)
        {
            GL.UniformMatrix4(GL.GetUniformLocation(Handle, name), false, ref mat);
        }
    }
}
