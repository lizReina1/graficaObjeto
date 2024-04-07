using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Security.Cryptography.X509Certificates;

using PlanoGenerico.Extras;
namespace PlanoGenerico
{
    public class Cara
    {
        private float ancho;
        private float alto;
        private float profundidad;
        public Punto origen;
        public Color4 color; // Utilizando Color4 de OpenTK

        public Cara(Punto p, float ancho, float alto, float profundidad, Color4 color)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.color = color;
        }
        public void DibujarT()
        {
            PrimitiveType primitiveType = PrimitiveType.Quads;

            back(primitiveType);  //rosado
            left(primitiveType);   //rojo
            right(primitiveType);  //amarillo
            top(primitiveType);  //celeste
            front(primitiveType);  //verde
            bottom(primitiveType); //azul

        }

        private void right(PrimitiveType primitiveType)
        {

            // Dibuja el relleno
            GL.Begin(primitiveType);
            GL.Color4(color);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.End();

            // Dibuja los bordes
            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black); // Color para los bordes (en este caso, negro)
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void left(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color4(color);//rojo
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void front(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color4(color);//verde
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();
        }

        private void back(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color4(color);//rosado
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.End();
        }

        private void bottom(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color4(color);//azul;
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y - alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y - alto, origen.z + profundidad);
            GL.End();
        }

        private void top(PrimitiveType primitiveType)
        {
            //
            GL.Begin(primitiveType);
            GL.Color4(color);//azul;
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop); // Aquí he asumido que quieres un loop de líneas para el borde
            GL.Color4(Color4.Black);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y + alto, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y + alto, origen.z + profundidad);
            GL.End();
        }

      
    }
}
