using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenGLOpenTKForms
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

        // Prepare and starts drawing all blocks from list
        // All drawing divided into three parts: 
        // 1 - StartDraw (Blocks class) 2 - StartDraw (Child class) 3 - EndDraw (Blocks class)
        public static void Draw()
        {
            GL.Translate(0, List.Count, 0);

            CurrentCount = 0;
            IfLevel = 0;
            WhileLevel = 0;

            foreach (Blocks block in List)
            {
                block.StartDraw();
                block.EndDraw();
            }
        }

        protected virtual void StartDraw()
        {
            GL.PushMatrix();
            GL.Translate(5.0f * IfLevel, -CurrentCount * 3, 0);
            Textures.Instance.Current = Textures.Instance.textureMain;
            if (blockWorkAnimation && currentAnimatedBlock == CurrentCount)
            {
                if (this is EndIfBlock || this is EndWhileBlock)
                {
                    NextBlockForAnimation();
                    return;
                }
                GL.Scale(1f + 0.25f * (float)Math.Sin(AnimationTimer.Instance.Elapsed.TotalMilliseconds / 500), 
                         1f + 0.25f * (float)Math.Sin(AnimationTimer.Instance.Elapsed.TotalMilliseconds / 500), 
                         1f + 0.25f * (float)Math.Sin(AnimationTimer.Instance.Elapsed.TotalMilliseconds / 500));
                Textures.Instance.Current = Textures.Instance.textureAnimation;
                if (AnimationTimer.Instance.Elapsed.TotalMilliseconds >= OpenGLForm.animationTime)
                    NextBlockForAnimation();
            }
        }

        public void EndDraw()
        {
            GL.PopMatrix();
            if (IfLevel > 0)
            {
                for (int i = 0; i < IfLevel; i++)
                {
                    GL.PushMatrix();
                    GL.Translate(5.0f * i, -CurrentCount * 3f, 0);
                    DrawConnectionLine(Textures.Instance.textureFalse);
                    GL.PopMatrix();
                }
            }
            if (WhileLevel > 0)
            {
                GL.PushMatrix();
                GL.Translate(4.0f * WhileLevel + 1.0f * (IfLevel == WhileLevel ? 0 : IfLevel), -CurrentCount * 3f, 0);
                DrawConnectionLine(Textures.Instance.textureFalse);
                GL.Translate(-8.0f, 1f, 0);
                DrawConnectionLine(Textures.Instance.textureTrue);
                GL.PopMatrix();
            }
        }

        // Start animating blocks
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

        // Calculating next block which needed to animate
        // Animation repeat based on number of loop iterations
        private static void NextBlockForAnimation()
        {
            AnimationTimer.Instance.Stop();
            currentAnimatedBlock++;
            if (List.Count > currentAnimatedBlock)
            {
                AnimationTimer.Instance.Restart();
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

        protected void DrawConnectionLine(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);
            // Back side
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, -0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, -0.25f);

            // Bottom side
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(0.25f, -1.0f, -0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);

            // Left side
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, -0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);

            // Forward side
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, -1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, 0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);

            // Up side
            GL.TexCoord2(-0.25f, -1.0f);
            GL.Vertex3(-0.25f, 1.0f, -0.25f);
            GL.TexCoord2(-0.25f, 1.0f);
            GL.Vertex3(-0.25f, 1.0f, 0.25f);
            GL.TexCoord2(0.25f, 1.0f);
            GL.Vertex3(0.25f, 1.0f, 0.25f);
            GL.TexCoord2(0.25f, -1.0f);
            GL.Vertex3(0.25f, 1.0f, -0.25f);

            // Right side
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
