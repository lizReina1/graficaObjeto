using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;
using PlanoGenerico.Extras;
using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace PlanoGenerico
{
        public class Game : GameWindow
        {
        public Televisor tv;
        public Televisor tv1;
        public Televisor tv2;

        public Escenario escenario = new Escenario();
        public Florero florero; 
        public Parlante parlante;

        //movimiento
        private Vector3 cameraPosition = new Vector3(-5, 5, 20);
        private Vector3 cameraFront = Vector3.UnitZ;
        private Vector3 cameraUp = Vector3.UnitY;
        private float cameraSpeed = 0.1f;
        private float yaw = -90f; // Ángulo de rotación en yaw
        private float pitch = 0f; // Ángulo de rotación en pitch


        Shader shader;
        
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Capturar entrada del usuario para rotar la cámara
            if (Keyboard.GetState().IsKeyDown(Key.Left))
            {
                yaw -= 1f; // Girar a la izquierda
            }
            if (Keyboard.GetState().IsKeyDown(Key.Right))
            {
                yaw += 1f; // Girar a la derecha
            }
            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                pitch += 1f; // Inclinar hacia arriba
            }
            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                pitch -= 1f; // Inclinar hacia abajo
            }


            base.OnUpdateFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Gray);
            // Coordenada x,y,z
            // ancho, alto, profundidad, color
            tv = new Televisor(new Punto(-10, 0, 0), 10, 13, 3, Color.Black);

            tv1 = new Televisor(new Punto(15, 0, 0), 10, 13, 3, Color.Black);

            florero = new Florero(new Punto(15, 10, 0), 5, 5, 3, Color.Black);
            parlante = new Parlante(new Punto(-30, 0, 0), 5, 5, 3, Color.Black);

            this.escenario.setList(tv);
           // this.escenario.setList(tv1);
            //   tv2 = new Televisor(new Punto(5, 0, 20), 10, 13, 3, Color.Black);

            base.OnLoad(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //---------------------
            cameraFront = new Vector3(
                  (float)(Math.Cos(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch))),
                  (float)Math.Sin(MathHelper.DegreesToRadians(pitch)),
                  (float)(Math.Sin(MathHelper.DegreesToRadians(yaw)) * Math.Cos(MathHelper.DegreesToRadians(pitch)))
              );

            // Configurar la matriz de vista para el movimiento de la cámara
            Matrix4 viewMatrix = Matrix4.LookAt(cameraPosition, cameraPosition + cameraFront, cameraUp);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMatrix);
            /////////////////////////////////////////////////
            foreach (object recorro in this.escenario.getList())
            {
                if (recorro is Televisor)
                {
                    Televisor televisor = (Televisor)recorro;
                    televisor.Dibujar(); // Llama al método Dibujar() del objeto Televisor
                }
            }

            this.florero.Dibujar();
            this.parlante.Dibujar();
            //this.tv.Dibujar();
            //this.tv1.Dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
      


    }
}


