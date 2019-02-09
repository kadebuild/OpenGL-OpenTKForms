using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenGLOpenTKForms
{
    class Textures
    {
        public static readonly Textures Instance = new Textures();

        public int Current { get; set; }

        public int textureMain;
        public int textureTrue;
        public int textureFalse;
        public int textureAnimation;
        public List<int> skyBoxTexture = new List<int>();

        private Textures()
        {
            // Loading textures and skyboxes
            textureMain = Load(@"Texture\stone.jpg");
            textureTrue = Load(@"Texture\grass.png");
            textureFalse = Load(@"Texture\stone.jpg");
            textureAnimation = Load(@"Texture\sand.jpg");
            // Skybox1
            skyBoxTexture.Add(Load(@"Texture\skybox\back1.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\front1.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\bottom1.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\top1.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\left1.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\right1.jpg"));
            // Skybox2
            skyBoxTexture.Add(Load(@"Texture\skybox\back2.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\front2.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\bottom2.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\top2.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\left2.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\right2.jpg"));
            // Skybox 3
            skyBoxTexture.Add(Load(@"Texture\skybox\back3.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\front3.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\bottom3.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\top3.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\left3.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\right3.jpg"));
            // Skybox 4
            skyBoxTexture.Add(Load(@"Texture\skybox\back4.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\front4.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\bottom4.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\top4.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\left4.jpg"));
            skyBoxTexture.Add(Load(@"Texture\skybox\right4.jpg"));
        }

        private static int Load(string filename)
        {
            TextureTarget Target = TextureTarget.Texture2D;
            int texture;
            GL.GenTextures(1, out texture);
            GL.BindTexture(Target, texture);
            try
            {
                Version version = new Version(GL.GetString(StringName.Version).Substring(0, 3));
                Version target = new Version(1, 4);
                if (version >= target)
                {
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.GenerateMipmap, (int)All.True);
                    GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
                }
                else
                {
                    GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                }
                GL.TexParameter(Target, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                GL.TexParameter(Target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(Target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                Bitmap bitmap = new Bitmap(filename);
                BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(Target, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                GL.Finish();
                bitmap.UnlockBits(data);

                if (GL.GetError() != ErrorCode.NoError)
                    throw new Exception("Error loading texture " + filename);
            }
            catch (Exception) { }
            return texture;

        }
    }
}
