using OpenTK.Graphics.OpenGL;

namespace OpenTKFormsFinal
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
            // Так как мы хотим, чтобы скайбокс был с центром в x-y-z, мы производим
            // небольшие рассчеты. Просто изменяем X,Y и Z на нужные.

            // Это центрирует скайбокс на X,Y,Z
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;

            // забиндим заднюю текстуру на заднюю сторону
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[0 + skyboxIndex]);
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ЗАДНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Биндим ПЕРЕДНЮЮ текстуру на ПЕРЕДНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[1 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ПЕРЕДНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.End();

            // Биндим НИЖНЮЮ текстуру на НИЖНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[2 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины НИЖНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.End();

            // Биндим ВЕРХНЮЮ текстуру на ВЕРХНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[3 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ВЕРХНЕЙ стороны
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);

            GL.End();

            // Биндим ЛЕВУЮ текстуру на ЛЕВУЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[4 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ЛЕВОЙ стороны
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Биндим ПРАВУЮ текстуру на ПРАВУЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, Textures.Instance.skyBoxTexture[5 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ПРАВОЙ стороны
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.End();
        }
    }
}
