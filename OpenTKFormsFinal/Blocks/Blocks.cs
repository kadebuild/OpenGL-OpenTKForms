using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTKFormsFinal
{
    public class Blocks
    {
        protected static int CurrentCount { get; set; }
        protected static int IfLevel { get; set; }
        protected static int WhileLevel { get; set; }
        protected static float multiplyFigure = 3f;

        private static int currentAnimatedBlock = -1;
        private static bool blockWorkAnimation = false;
        private static List<int> cycleIndex = new List<int>();
        private static List<int> cycleRepeated = new List<int>();

        public static List<Blocks> List = new List<Blocks>();

        public virtual void Draw(int i)
        {
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            Textures.Instance.Current = Textures.Instance.textureStone;
            if (blockWorkAnimation && currentAnimatedBlock == i)
            {
                if (this is EndIfBlock || this is EndWhileBlock)
                {
                    NextBlockForAnimation();
                    return;
                }
                GL.Scale(1f + 0.25f * (float)Math.Sin(OpenGLForm.sw.Elapsed.TotalMilliseconds / 500), 
                         1f + 0.25f * (float)Math.Sin(OpenGLForm.sw.Elapsed.TotalMilliseconds / 500), 
                         1f + 0.25f * (float)Math.Sin(OpenGLForm.sw.Elapsed.TotalMilliseconds / 500));
                Textures.Instance.Current = Textures.Instance.textureAnimation;
                if (OpenGLForm.sw.Elapsed.TotalMilliseconds >= OpenGLForm.animationTime)
                    NextBlockForAnimation();
            }
        }

        public void EndDraw()
        {
            GL.PopMatrix();
            if (IfLevel > 0)
            {
                for (int j = 0; j < IfLevel; j++)
                {
                    GL.PushMatrix();
                    GL.Translate(5.0f * j, -CurrentCount * 3f, 0);
                    DrawConnectLine(Textures.Instance.textureFalse);
                    GL.PopMatrix();
                }
            }
            if (WhileLevel > 0)
            {
                GL.PushMatrix();
                GL.Translate(4.0f * WhileLevel + 1.0f * (IfLevel == WhileLevel ? 0 : IfLevel), -CurrentCount * 3f, 0);
                DrawConnectLine(Textures.Instance.textureFalse);
                GL.Translate(-8.0f, 1f, 0);
                DrawConnectLine(Textures.Instance.textureTrue);
                GL.PopMatrix();
            }
        }

        public static void StartDrawing()
        {
            GL.Translate(0, List.Count, 0);

            CurrentCount = 0;
            IfLevel = 0;
            WhileLevel = 0;

            for (int i = 0; i < List.Count; i++)
            {
                List[i].Draw(i);
                List[i].EndDraw();
            }
        }

        public static void Animate()
        {
            blockWorkAnimation = true;
            currentAnimatedBlock = -1;
            NextBlockForAnimation();
        }

        public static void ClearList()
        {
            List.Clear();
            IfLevel = 0;
            WhileLevel = 0;
        }

        private static void NextBlockForAnimation()
        {
            OpenGLForm.sw.Stop();
            currentAnimatedBlock++;
            if (List.Count > currentAnimatedBlock)
            {
                OpenGLForm.sw.Reset();
                OpenGLForm.sw.Start();
                if ((List[currentAnimatedBlock] is ForBlock || List[currentAnimatedBlock] is WhileBlock) && !cycleIndex.Contains(currentAnimatedBlock))
                {
                    cycleIndex.Add(currentAnimatedBlock);
                    cycleRepeated.Add(0);
                }
                if (List[currentAnimatedBlock] is EndForBlock || List[currentAnimatedBlock] is EndWhileBlock)
                {
                    if (cycleRepeated.Last() == OpenGLForm.cycleTimes - 1)
                    {
                        cycleIndex.RemoveAt(cycleIndex.Count - 1);
                        cycleRepeated.RemoveAt(cycleRepeated.Count - 1);
                        currentAnimatedBlock++;
                    }
                    else
                    {
                        cycleRepeated[cycleRepeated.Count - 1]++;
                        currentAnimatedBlock = cycleIndex.Last() + 1;
                    }
                }
                if (currentAnimatedBlock >= List.Count)
                    return;
                if (List[currentAnimatedBlock] is IfBlock)
                {
                    if (!OpenGLForm.ifTrue)
                    {
                        while (List[currentAnimatedBlock] is EndIfBlock)
                        {
                            currentAnimatedBlock++;
                            if (currentAnimatedBlock >= List.Count)
                                break;
                        }
                        currentAnimatedBlock--;
                    }
                }
            }
            else
            {
                currentAnimatedBlock = -1;
                blockWorkAnimation = false;
            }
        }

        protected void DrawConnectLine(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);
            // задняя грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, -0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, -0.25f);

            //нижняя грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(0.25f, -1.0f, -0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);

            //левая грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);

            //передняя грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, 0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);

            //верхняя грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, 1.0f, -0.25f);

            // правая грань
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, -0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, 0.25f);
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
