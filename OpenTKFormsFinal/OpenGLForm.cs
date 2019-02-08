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
    public partial class OpenGLForm : Form
    {
        bool loaded = false;
        // Timer for animation
        public static Stopwatch sw = new Stopwatch();
        // Mouse setup
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
        float mouseSens = 0.05f;
        // Animation options
        public static bool ifTrue = true;
        public static int cycleTimes = 2;
        public static int animationTime = 3100;

        public OpenGLForm()
        {
            InitializeComponent();
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            Blocks.List.AddRange(new List<Blocks>
            {
                new IOBlock(),
                new ActionBlock(),
                new ForBlock(),
                new IOBlock(),
                new ForBlock(),
                new IfBlock(),
                new ActionBlock(),
                new EndIfBlock(),
                new EndForBlock(),
                new IOBlock(),
                new EndForBlock(),
                new IOBlock()
            });

            animationTimeForm.Value = animationTime;
            cycleRepeatForm.Value = cycleTimes;

            loaded = true;

            cameraX = (float)Math.Sin(cameraRotate) * cameraRadius;
            cameraZ = (float)Math.Cos(cameraRotate) * cameraRadius;

            // Turn on the light, set the screen background and activate the depth test
            Utils.LightOn();
            GL.ClearColor(Color.SkyBlue);
            GL.Enable(EnableCap.DepthTest);

            // Setting event handlers for pressing buttons and drawing
            glControl.KeyDown += new KeyEventHandler(glControl_KeyDown);
            glControl.KeyUp += new KeyEventHandler(glControl_KeyUp);
            glControl.Resize += new EventHandler(glControl_Resize);
            glControl.Paint += new PaintEventHandler(glControl_Paint);
            glControl.MouseDown += new MouseEventHandler(glControl_MouseDown);
            glControl.MouseUp += new MouseEventHandler(glControl_MouseUp);
            glControl.MouseMove += new MouseEventHandler(glControl_MouseMove);
            glControl.MouseWheel += new MouseEventHandler(glControl_MouseWheel);

            // Setting event handler for infinity render
            Application.Idle += Application_Idle;

            // Call the screen "resize" to make sure that the Viewport and projection matrix were set correctly
            glControl_Resize(glControl, EventArgs.Empty);
            sw.Start();
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
                Utils.Screenshot(glControl.Width, glControl.Height).Save(dateTime.ToString("dd-MM-yyyy-hh-mm-ss") + "-screenshot.png");
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
            Matrix4 mv = Matrix4.LookAt(new Vector3(cameraX, cameraY, cameraZ), new Vector3(mouseX, mouseY, 0f), Vector3.UnitY);
            GL.LoadMatrix(ref mv);

            Blocks.StartDrawing();

            Skybox.Instance.Draw();

            glControl.SwapBuffers();
        }

        private void ifButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new IfBlock());
            blockListForm.Items.Add("If");
        }

        private void endifButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new EndIfBlock());
            blockListForm.Items.Add("End If");
        }

        private void forButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new ForBlock());
            blockListForm.Items.Add("For");
        }

        private void endforButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new EndForBlock());
            blockListForm.Items.Add("End For");
        }

        private void whileButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new WhileBlock());
            blockListForm.Items.Add("While");
        }

        private void endwhileButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new EndWhileBlock());
            blockListForm.Items.Add("End While");
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new ActionBlock());
            blockListForm.Items.Add("Action");
        }

        private void ioButton_Click(object sender, EventArgs e)
        {
            Blocks.List.Add(new IOBlock());
            blockListForm.Items.Add("Input/Output");
        }

        private void clearBlockListButton_Click(object sender, EventArgs e)
        {
            blockListForm.Items.Clear();
            Blocks.ClearList();
        }

        private void deleteBlockButton_Click(object sender, EventArgs e)
        {
            if (blockListForm.SelectedIndex >= 0)
            {
                Blocks.List.RemoveAt(blockListForm.SelectedIndex);
                blockListForm.Items.RemoveAt(blockListForm.SelectedIndex);
            }
        }

        void FillBlockListForm()
        {
            for (int i = 0; i < Blocks.List.Count; i++)
                blockListForm.Items.Add(Blocks.List[i].ToString());
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Blocks.Animate();
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

        private void skyboxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skybox.Instance.SetTheme(skyboxTheme.SelectedIndex * 6);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Utils.LightOn();
            }
            else
            {
                Utils.LightOff();
            }
        }
    }
}
