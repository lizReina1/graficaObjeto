using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using PlanoGenerico.Extras;

namespace PlanoGenerico
{
    public class Televisor
    {
        private float ancho;
        private float alto;
        private float profundidad;
        public Punto origen;
        public Color4 color; // Utilizando Color4 de OpenTK
        Cara formaTele;

        Cara formaSoporte;
        Cara formaPantalla;

        public Televisor(Punto p, float ancho, float alto, float profundidad, Color4 color)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.color = color;

            float halfAncho = ancho / 2;
            float halfProfundidad = profundidad / 2;
            float halfAlto = alto / 2;

            this.formaTele = new Cara(
                new Punto(origen.x, origen.y + halfAlto, origen.z), // Punto superior
                ancho, alto, profundidad, color
            );

            float pantallaAncho = ancho - 2; 
            float pantallaAlto = alto - 2; 
            float pantallaProfundidad = profundidad +1; 

            Punto pantallaOrigen = new Punto(origen.x, origen.y + halfAlto , origen.z ); 
            this.formaPantalla = new Cara(pantallaOrigen, pantallaAncho, pantallaAlto, pantallaProfundidad, Color4.White);

            this.formaSoporte = new Cara(
                new Punto(origen.x, origen.y - halfAlto, origen.z),
                ancho/2, alto / 2 - 10, profundidad, Color4.Red
            );

          
        }

        public void Dibujar()
        {
            this.formaTele.DibujarT();
            this.formaPantalla.DibujarT();

            this.formaSoporte.DibujarT();
        }
    }
}
