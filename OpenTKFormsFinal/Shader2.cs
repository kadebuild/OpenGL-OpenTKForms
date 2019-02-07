using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace OpenTKFormsFinal
{
    public class Shader
    {
        public int ID;
        // constructor generates the shader on the fly
        // ------------------------------------------------------------------------
        public Shader(string vertexPath, string fragmentPath)
        {
            // compile shaders
            int vertex, fragment;
            int success;
            string infoLog;
            // vertex shader
            vertex = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertex, File.ReadAllText(vertexPath));
            GL.CompileShader(vertex);
            //checkCompileErrors(vertex, "VERTEX");
            // fragment Shader
            fragment = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragment, File.ReadAllText(vertexPath));
            GL.CompileShader(fragment);
            //checkCompileErrors(fragment, "FRAGMENT");
            // shader Program
            ID = GL.CreateProgram();
            GL.AttachShader(ID, vertex);
            GL.AttachShader(ID, fragment);
            GL.LinkProgram(ID);
            //checkCompileErrors(ID, "PROGRAM");
            // delete the shaders as they're linked into our program now and no longer necessery
            GL.DeleteShader(vertex);
            GL.DeleteShader(fragment);
        }
        // activate the shader
        // ------------------------------------------------------------------------
        public void use()
        {
            GL.UseProgram(ID);
        }
        // utility uniform functions
        // ------------------------------------------------------------------------
        public void setBool(string name, bool value)
        {
            GL.Uniform1(GL.GetUniformLocation(ID, name), value ? 1 : 0);
        }
        // ------------------------------------------------------------------------
        public void setInt(string name, int value)
        {
            GL.Uniform1(GL.GetUniformLocation(ID, name), value);
        }
        // ------------------------------------------------------------------------
        public void setFloat(string name, float value)
        {
            GL.Uniform1(GL.GetUniformLocation(ID, name), value);
        }
        // ------------------------------------------------------------------------
        public void setVec2(string name, Vector2 value)
        {
            GL.Uniform2(GL.GetUniformLocation(ID, name), 1, value[0]);
        }
        public void setVec2(string name, float x, float y)
        {
            GL.Uniform2(GL.GetUniformLocation(ID, name), x, y);
        }
        // ------------------------------------------------------------------------
        public void setVec3(string name, Vector3d value)
        {
            GL.Uniform3(GL.GetUniformLocation(ID, name), value.X, value.Y, value.Z);
        }
        public void setVec3(string name, float x, float y, float z)
        {
            GL.Uniform3(GL.GetUniformLocation(ID, name), x, y, z);
        }
        // ------------------------------------------------------------------------
        public void setVec4(string name, Vector4 value)
        {
            GL.Uniform4(GL.GetUniformLocation(ID, name), value.X, value.Y, value.Z, value.W);
        }
        public void setVec4(string name, float x, float y, float z, float w)
        {
            GL.Uniform4(GL.GetUniformLocation(ID, name), x, y, z, w);
        }
        // ------------------------------------------------------------------------
        public void setMat2(string name, ref Matrix2 mat)
        {
            GL.UniformMatrix2(GL.GetUniformLocation(ID, name), false, ref mat);
        }
        // ------------------------------------------------------------------------
        public void setMat3(string name, ref Matrix3 mat)
        {
            GL.UniformMatrix3(GL.GetUniformLocation(ID, name), false, ref mat);
        }
        // ------------------------------------------------------------------------
        public void setMat4(string name, Matrix4 mat)
        {
            GL.UniformMatrix4(GL.GetUniformLocation(ID, name), false, ref mat);
        }

        // utility function for checking shader compilation/linking errors.
        // ------------------------------------------------------------------------
        /*private void checkCompileErrors(int shader, string type)
        {
            int success;
            int code;
            string infoLog;
            if (type != "PROGRAM")
            {
                GL.GetShader(shader, ShaderParameter.CompileStatus, out success);
                if (success < 0)
                {
                    GL.GetShaderInfoLog(shader, 1024, out code, out infoLog);
                    std::cout << "ERROR::SHADER_COMPILATION_ERROR of type: " << type << "\n" << infoLog << "\n -- --------------------------------------------------- -- " << std::endl;
                }
            }
            else
            {
                glGetProgramiv(shader, GL_LINK_STATUS, &success);
                if (!success)
                {
                    glGetProgramInfoLog(shader, 1024, NULL, infoLog);
                    std::cout << "ERROR::PROGRAM_LINKING_ERROR of type: " << type << "\n" << infoLog << "\n -- --------------------------------------------------- -- " << std::endl;
                }
            }
        }*/
    }
}
