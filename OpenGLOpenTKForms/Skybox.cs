using OpenTK.Graphics.OpenGL;

namespace OpenGLOpenTKForms
{
    class Skybox
    {
        public static readonly Skybox Instance = new Skybox();

        int skyboxIndex = 6;
        int skyboxLength = 512;
        int skyboxWidth = 512;
        int skyboxHeight = 512;

        private Skybox() { }

        public void SetTheme(int index)
        {
            skyboxIndex = index;
        }

        public void Draw()
        {
            CreateSkyBox(0, 0, 0, skyboxWidth, skyboxHeight, skyboxLength);
        }

        private void CreateSkyBox(float x, float y, float z, float width, float height, float length)
        {
            // Since we want the skybox to be centered at x-y-z, we make small calculations. 
            // Simply change the X, Y and Z to the desired.

            // This centers the skybox at X,Y,Z
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;

            // Binding the back textures to the back side
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[0 + skyboxIndex]);
            GL.Begin(PrimitiveType.Quads);

            // Set texture coordinates and vertices of the rear side
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Binding the forward texture to the front side of the box
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[1 + skyboxIndex]);

            // Start drawing side
            GL.Begin(PrimitiveType.Quads);

            // Set the texture coordinates and vertices of the forward side
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.End();

            // Binding the bottom texture to the bottom side of the box
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[2 + skyboxIndex]);

            // Start drawing side
            GL.Begin(PrimitiveType.Quads);

            // Set the texture coordinates and vertices of the bottom side
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.End();

            // Binding the upper texture to the upper side of the box
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[3 + skyboxIndex]);

            // Start drawing side
            GL.Begin(PrimitiveType.Quads);

            // Set the texture coordinates and vertices of the upper side
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);

            GL.End();

            // Binding the left texture to the left side of the box
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[4 + skyboxIndex]);

            // Start drawing side
            GL.Begin(PrimitiveType.Quads);

            // Set the texture coordinates and vertices of the left side
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Binding the right texture to the right side of the box
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[5 + skyboxIndex]);

            // Start drawing side
            GL.Begin(PrimitiveType.Quads);

            // Set the texture coordinates and vertices of the right side
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.End();
        }
    }
}
