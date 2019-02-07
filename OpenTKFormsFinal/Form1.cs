using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace OpenTKFormsFinal
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        List<String> blockList = new List<String>();
        Stopwatch sw = new Stopwatch();
        float cameraRotate = 0f;
        float cameraUp = 0f;
        float cameraX = 0f;
        float cameraY = 0f;
        float cameraZ = 0f;
        float cameraRadius = 15f;
        float mouseX = 0f;
        float mouseY = 0f;
        float lastMouseX = 0f;
        float lastMouseY = 0f;
        bool drag = false;
        int textureStone;
        int textureTrue;
        int textureFalse;
        int textureAnimation;
        float multiplyFigure = 3f;
        int ifLevel = 0;
        int whileLevel = 0;
        bool blockWorkAnimation = false;
        int currentAnimatedBlock = 0;
        bool ifTrue = true;
        int cycleTimes = 2;
        int animationTime = 3100;
        List<int> cycleIndex = new List<int>();
        List<int> cycleRepeated = new List<int>();
        List<int> skyBoxTexture = new List<int>();
        int skyboxWidth = 256;
        int skyboxHeight = 256;
        int skyboxLength = 256;
        int skyboxIndex = 6;
        float mouseSens = 0.05f;
        List<int> animationList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            animationTimeForm.Value = animationTime;
            cycleRepeatForm.Value = cycleTimes;

            blockList.Add("Ввод/вывод");
            blockList.Add("Действие");
            blockList.Add("For");
            blockList.Add("Ввод/вывод");
            blockList.Add("For");
            blockList.Add("If");
            blockList.Add("Действие");
            blockList.Add("Endif");
            blockList.Add("Endfor");
            blockList.Add("Ввод/вывод");
            blockList.Add("Endfor");
            blockList.Add("Ввод/вывод");

            loaded = true;

            cameraX = (float)Math.Sin(cameraRotate) * cameraRadius;
            cameraZ = (float)Math.Cos(cameraRotate) * cameraRadius;

            // Включаем свет, задаем фон экрана и активируем глубинный тест
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            float[] lightPos = new float[3] { 1, 0.5F, 1 };
            GL.Light(LightName.Light0, LightParameter.Ambient, lightPos);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.ClearColor(Color.SkyBlue);
            GL.Enable(EnableCap.DepthTest);

            // Задаем обработчики событий по нажатию кнопок и отрисовки
            glControl.KeyDown += new KeyEventHandler(glControl_KeyDown);
            glControl.KeyUp += new KeyEventHandler(glControl_KeyUp);
            glControl.Resize += new EventHandler(glControl_Resize);
            glControl.Paint += new PaintEventHandler(glControl_Paint);
            glControl.MouseDown += new MouseEventHandler(glControl_MouseDown);
            glControl.MouseUp += new MouseEventHandler(glControl_MouseUp);
            glControl.MouseMove += new MouseEventHandler(glControl_MouseMove);
            glControl.MouseWheel += new MouseEventHandler(glControl_MouseWheel);

            // задаем обработчик события для включения бесконечного рендера
            Application.Idle += Application_Idle;

            // Вызываем "ресайз" экрана, чтобы убедиться что Viewport и матрица проекции были установлены правильно
            glControl_Resize(glControl, EventArgs.Empty);
            sw.Start();
            // Загрузка тесктур и скайбоксов
            textureStone = LoadTexture(@"Texture\stone.jpg");
            textureTrue = LoadTexture(@"Texture\grass.png");
            textureFalse = LoadTexture(@"Texture\stone.jpg");
            textureAnimation = LoadTexture(@"Texture\sand.jpg");
            // Skybox1
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\back1.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\front1.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\bottom1.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\top1.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\left1.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\right1.jpg"));
            // Skybox2
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\back2.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\front2.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\bottom2.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\top2.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\left2.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\right2.jpg"));
            // Skybox 3
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\back3.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\front3.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\bottom3.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\top3.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\left3.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\right3.jpg"));
            // Skybox 4
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\back4.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\front4.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\bottom4.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\top4.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\left4.jpg"));
            skyBoxTexture.Add(LoadTexture(@"Texture\skybox\right4.jpg"));
            FillBlockListForm();
        }

        void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            cameraRadius -= e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            cameraX = (float)Math.Sin(cameraRotate) * cameraRadius;
            cameraZ = (float)Math.Cos(cameraRotate) * cameraRadius;
            cameraY = (float)Math.Sin(cameraUp) * cameraRadius;
        }

        void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drag)
                {
                    float x = lastMouseX - e.X;
                    float y = lastMouseY - e.Y;
                    if (Math.Abs(x) > Math.Abs(y))
                    {
                        if (x < 0)
                            mouseX -= mouseSens * 5;
                        else
                            mouseX += mouseSens * 5;
                    }
                    else
                    {
                        if (y < 0)
                            mouseY += mouseSens * 5;
                        else
                            mouseY -= mouseSens * 5;
                    }
                    lastMouseX = e.X;
                    lastMouseY = e.Y;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (drag)
                {
                    float x = lastMouseX - e.X;
                    float y = lastMouseY - e.Y;
                    if (x < 0)
                        cameraRotate -= mouseSens;
                    else if (x > 0)
                        cameraRotate += mouseSens;
                    if (y < 0)
                        cameraUp += mouseSens;
                    else if (y > 0)
                        cameraUp -= mouseSens;
                    cameraX = (float)Math.Sin(cameraRotate) * cameraRadius;
                    cameraZ = (float)Math.Cos(cameraRotate) * cameraRadius;
                    cameraY = (float)Math.Sin(cameraUp) * cameraRadius;
                    lastMouseX = e.X;
                    lastMouseY = e.Y;
                }
            }
        }

        void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        void glControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                DateTime dateTime = DateTime.Now;
                GrabScreenshot().Save(dateTime.ToString("dd-MM-yyyy-hh-mm-ss") + "-screenshot.png");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Idle -= Application_Idle;

            base.OnClosing(e);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl.IsIdle)
            {
                Render();
            }
        }

        void glControl_Resize(object sender, EventArgs e)
        {
            OpenTK.GLControl c = sender as OpenTK.GLControl;

            if (c.ClientSize.Height == 0)
                c.ClientSize = new System.Drawing.Size(c.ClientSize.Width, 1);

            GL.Viewport(0, 0, c.ClientSize.Width, c.ClientSize.Height);

            float aspect_ratio = Width / (float)Height;
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 0.1f, 1000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        void glControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.A:
                    cameraRotate -= 0.1f;
                    break;
                case Keys.D:
                    cameraRotate += 0.1f;
                    break;
                case Keys.W:
                    cameraUp += 0.1f;
                    break;
                case Keys.S:
                    cameraUp -= 0.1f;
                    break;
                case Keys.Q:
                    cameraRadius -= 0.5f;
                    break;
                case Keys.E:
                    cameraRadius += 0.5f;
                    break;
            }
            cameraX = (float)Math.Sin(cameraRotate) * cameraRadius;
            cameraZ = (float)Math.Cos(cameraRotate) * cameraRadius;
            cameraY = (float)Math.Sin(cameraUp) * cameraRadius;
        }

        void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            Render();
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 mv = Matrix4.LookAt(new Vector3(cameraX, cameraY, cameraZ), new Vector3(mouseX, mouseY,0f), Vector3.UnitY);
            GL.LoadMatrix(ref mv);
            GL.Translate(0, blockList.Count, 0);
            int blockCount = 0;
            ifLevel = 0;
            whileLevel = 0;
            for (int i = 0; i < blockList.Count; i++)
            {
                GL.PushMatrix();
                GL.Translate(5.0f * ifLevel, -blockCount*3, 0);
                int currentTexture = textureStone;
                switch (blockList[i])
                {
                    case "Ввод/вывод":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        GL.Translate(-1.5f, 0, 0);
                        DrawIO(currentTexture);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        blockCount++;
                        if ((blockList.Count - i) > 1)
                        {
                            GL.Translate(0f, -2f, 0f);
                            DrawConnectLine(textureTrue);
                        }
                        break;
                    case "If":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        DrawIf(currentTexture);
                        ifLevel++;
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        blockCount++;
                        GL.Translate(0f, -1.1f, 0);
                        DrawConnectLine(textureTrue);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount*3, 0);
                        GL.Rotate(90, Vector3.UnitZ);
                        GL.Translate(3f, 1.8f, 0);
                        DrawConnectLine(textureTrue);
                        GL.Translate(0f, -1.05f, 0f);
                        DrawConnectLine(textureTrue);
                        break;
                    case "Действие":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        DrawAction(currentTexture);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        blockCount++;
                        if ((blockList.Count - i) > 1)
                        {
                            GL.Translate(0, -2, 0);
                            DrawConnectLine(textureTrue);
                        }
                        break;
                    case "Endif":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            NextBlockForAnimation();
                        }
                        blockCount++;
                        ifLevel--;
                        GL.Rotate(90, Vector3.UnitZ);
                        GL.Translate(0f, 0.75f, 0);
                        DrawConnectLine(textureTrue);
                        GL.Translate(0f, 2f, 0);
                        DrawConnectLine(textureTrue);
                        break;
                    case "For":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        DrawFor(currentTexture);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        blockCount++;
                        if ((blockList.Count - i) > 1)
                        {
                            GL.Translate(0, -2, 0);
                            DrawConnectLine(textureTrue);
                        }
                        break;
                    case "Endfor":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        GL.Rotate(180, Vector3.UnitZ);
                        DrawFor(currentTexture);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        blockCount++;
                        if ((blockList.Count - i) > 1)
                        {
                            GL.PopMatrix();
                            GL.PushMatrix();
                            GL.Translate(5.0f * ifLevel, -blockCount * 3f, 0);
                            GL.Translate(0, 1f, 0);
                            DrawConnectLine(textureTrue);
                        }
                        break;
                    case "While":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            GL.Scale(1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500), 1f + 0.25f * (float)Math.Sin(sw.Elapsed.TotalMilliseconds / 500));
                            currentTexture = textureAnimation;
                            if (sw.Elapsed.TotalMilliseconds >= animationTime)
                                NextBlockForAnimation();
                        }
                        DrawIf(currentTexture);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3, 0);
                        whileLevel = 1 + ifLevel;
                        blockCount++;
                        GL.Translate(0, -2, 0);
                        DrawConnectLine(textureTrue);
                        GL.PopMatrix();
                        GL.PushMatrix();
                        GL.Translate(5.0f * ifLevel, -blockCount * 3f, 0);
                        GL.Rotate(90, Vector3.UnitZ);
                        GL.Translate(3f, -3f, 0);
                        DrawConnectLine(textureFalse);
                        GL.Translate(0f, 6f, 0);
                        DrawConnectLine(textureTrue);
                        break;
                    case "Endwhile":
                        if (blockWorkAnimation && currentAnimatedBlock == i)
                        {
                            NextBlockForAnimation();
                        }
                        blockCount++;
                        whileLevel = 0;
                        GL.Rotate(90, Vector3.UnitZ);
                        GL.Translate(0f, 0.75f, 0);
                        DrawConnectLine(textureTrue);
                        GL.Translate(0f, 2f, 0);
                        DrawConnectLine(textureTrue);
                        GL.Translate(-1f, -3.5f, 0);
                        DrawConnectLine(textureFalse);
                        GL.Translate(0f, -2f, 0);
                        DrawConnectLine(textureFalse);
                        break;
                }
                GL.PopMatrix();
                if (ifLevel > 0)
                {
                    for (int j = 0; j < ifLevel; j++)
                    {
                        GL.PushMatrix();
                        GL.Translate(5.0f * j, -blockCount * 3f, 0);
                        DrawConnectLine(textureFalse);
                        GL.PopMatrix();
                    }
                }
                if (whileLevel > 0)
                {
                    GL.PushMatrix();
                    GL.Translate(4.0f * whileLevel + 1.0f * (ifLevel == whileLevel ? 0 : ifLevel), -blockCount * 3f, 0);
                    DrawConnectLine(textureFalse);
                    GL.Translate(-8.0f, 1f, 0);
                    DrawConnectLine(textureTrue);
                    GL.PopMatrix();
                }
            }

            CreateSkyBox(0, 0, 0, skyboxWidth, skyboxHeight, skyboxLength);

            glControl.SwapBuffers();
        }

        void DrawAction(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);
            // задняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);

            //передняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void DrawIO(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            // задняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(0.0f * multiplyFigure, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(2.0f * multiplyFigure, 1.0f);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);

            //передняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(2.0f * multiplyFigure, 1.0f);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(0.0f * multiplyFigure, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(2.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void DrawIf(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            // задняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);

            //передняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(2.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(0.0f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0f * multiplyFigure, -1.0f, 1.0f);

            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void DrawFor(int texture)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);

            //нижняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);

            //левая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            //верхняя грань
            GL.TexCoord2(-1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f * multiplyFigure);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f * multiplyFigure);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);

            // правая грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);

            // левая верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);

            // правая верхняя грань
            GL.TexCoord2(-1.0f, -1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(-1.0f, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            //передняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, 1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.TexCoord2(0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, 1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, 1.0f);
            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            // задняя грань
            GL.TexCoord2(-1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.TexCoord2(-1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(-1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(-0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(-0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(0.5f * multiplyFigure, 1.0f);
            GL.Vertex3(0.5f * multiplyFigure, 1.0f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, 1.0f);
            GL.Vertex3(1.0f * multiplyFigure, 0.5f, -1.0f);
            GL.TexCoord2(1.0f * multiplyFigure, -1.0f);
            GL.Vertex3(1.0f * multiplyFigure, -1.0f, -1.0f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void DrawConnectLine(int texture)
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

        private void button1_Click(object sender, EventArgs e)
        {
            blockList.Add("If");
            blockListForm.Items.Add("If");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            blockList.Add("Endif");
            blockListForm.Items.Add("Endif");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blockList.Add("For");
            blockListForm.Items.Add("For");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            blockList.Add("Endfor");
            blockListForm.Items.Add("Endfor");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            blockList.Add("While");
            blockListForm.Items.Add("While");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            blockList.Add("Endwhile");
            blockListForm.Items.Add("Endwhile");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            blockList.Add("Действие");
            blockListForm.Items.Add("Действие");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            blockList.Add("Ввод/вывод");
            blockListForm.Items.Add("Ввод/вывод");
        }

        public static int LoadTexture(string filename)
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
            catch (Exception ex)
            { }
            return texture;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            blockListForm.Items.Clear();
            blockList.Clear();
            ifLevel = 0;
            whileLevel = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (blockListForm.SelectedIndex >= 0)
            {
                blockList.RemoveAt(blockListForm.SelectedIndex);
                blockListForm.Items.RemoveAt(blockListForm.SelectedIndex);
            }
        }

        void FillBlockListForm()
        {
            for (int i = 0; i < blockList.Count; i++)
                blockListForm.Items.Add(blockList[i]);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            blockWorkAnimation = true;
            sw.Stop();
            sw.Reset();
            sw.Start();
            currentAnimatedBlock = -1;
            NextBlockForAnimation();
        }

        void NextBlockForAnimation()
        {
            sw.Stop();
            currentAnimatedBlock++;
            if (blockList.Count > currentAnimatedBlock)
            {
                sw.Reset();
                sw.Start();
                if ((blockList[currentAnimatedBlock] == "For" || blockList[currentAnimatedBlock] == "While") && !(cycleIndex.Find(q => q == currentAnimatedBlock) == currentAnimatedBlock))
                {
                    cycleIndex.Add(currentAnimatedBlock);
                    cycleRepeated.Add(0);
                }
                if (blockList[currentAnimatedBlock] == "Endfor" || blockList[currentAnimatedBlock] == "Endwhile")
                {
                    if (cycleRepeated.Last() == cycleTimes - 1)
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
                if (currentAnimatedBlock >= blockList.Count)
                    return;
                if (blockList[currentAnimatedBlock] == "If")
                {
                    if (!ifTrue)
                    {
                        while (blockList[currentAnimatedBlock] != "Endif")
                        {
                            currentAnimatedBlock++;
                            if (currentAnimatedBlock >= blockList.Count)
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

        private void ifTrueForm_CheckedChanged(object sender, EventArgs e)
        {
            ifTrue = ifTrueForm.Checked;
        }

        private void cycleRepeatForm_ValueChanged(object sender, EventArgs e)
        {
            cycleTimes = (int)cycleRepeatForm.Value;
        }

        private void animationTimeForm_ValueChanged(object sender, EventArgs e)
        {
            animationTime = (int)animationTimeForm.Value;
        }

        void CreateSkyBox(float x, float y, float z, float width, float height, float length)
        {
            // Так как мы хотим, чтобы скайбокс был с центром в x-y-z, мы производим
            // небольшие рассчеты. Просто изменяем X,Y и Z на нужные.

            // Это центрирует скайбокс на X,Y,Z
            x = x - width / 2;
            y = y - height / 2;
            z = z - length / 2;

            // забиндим заднюю текстуру на заднюю сторону
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[0 + skyboxIndex]);
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ЗАДНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Биндим ПЕРЕДНЮЮ текстуру на ПЕРЕДНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[1 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ПЕРЕДНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.End();

            // Биндим НИЖНЮЮ текстуру на НИЖНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[2 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины НИЖНЕЙ стороны
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.End();

            // Биндим ВЕРХНЮЮ текстуру на ВЕРХНЮЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[3 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ВЕРХНЕЙ стороны
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);

            GL.End();

            // Биндим ЛЕВУЮ текстуру на ЛЕВУЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[4 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ЛЕВОЙ стороны
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x, y + height, z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x, y + height, z + length);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x, y, z + length);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x, y, z);

            GL.End();

            // Биндим ПРАВУЮ текстуру на ПРАВУЮ сторону бокса
            GL.BindTexture(TextureTarget.Texture2D, skyBoxTexture[5 + skyboxIndex]);

            // Начинаем рисовать сторону
            GL.Begin(PrimitiveType.Quads);

            // Установим текстурные координаты и вершины ПРАВОЙ стороны
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(x + width, y, z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(x + width, y, z + length);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(x + width, y + height, z + length);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(x + width, y + height, z);
            GL.End();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            skyboxIndex = comboBox1.SelectedIndex * 6;
            skyboxLength = 512;
            skyboxWidth = 512;
            skyboxHeight = 512;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                float[] lightPos = new float[3] { 1, 0.5F, 1 };
                GL.Light(LightName.Light0, LightParameter.Ambient, lightPos);
                GL.ShadeModel(ShadingModel.Smooth);
            }
            else
            {
                GL.Disable(EnableCap.Lighting);
                GL.Disable(EnableCap.Light0);
            }
        }

        Bitmap GrabScreenshot()
        {
            Bitmap bmp = new Bitmap(this.glControl.Width, this.glControl.Height);
            System.Drawing.Imaging.BitmapData data =
            bmp.LockBits(new Rectangle(0,0, this.glControl.Width, this.glControl.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, this.glControl.Width, this.glControl.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte,
                data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }
    }
}
