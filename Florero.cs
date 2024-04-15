using OpenTK.Graphics;
using PlanoGenerico.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoGenerico
{
    public class Florero
    {
        private Punto origen;
        private float ancho;
        private float alto;
        private float profundidad;
        private Color4 color;

        private Cara formaFlorero;
        private Cara formaBase;
        private Cara formaFlor;
        private Cara formaTronco;
        private Cara formaSuperiorFlor;

        public Florero(Punto p, float ancho, float alto, float profundidad, Color4 color)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.color = color;

            // Calcula las dimensiones de las partes del florero
            float halfAncho = ancho / 2;
            float halfAlto = alto / 2;
            float halfProfundidad = profundidad / 2;

            // Crea la forma del florero
            formaFlorero = new Cara(
                new Punto(origen.x, origen.y + halfAlto, origen.z),
                ancho, alto, profundidad, color
            );

            // Crea la base del florero
            formaBase = new Cara(
                new Punto(origen.x, origen.y - halfAlto, origen.z),
                ancho, alto / 2, profundidad, Color4.Brown
            );

            float troncoAncho = ancho / 4;
            float troncoAlto = alto + alto/2 ;
            float troncoProfundidad = profundidad / 4;

            float florAncho = ancho / 3;
            float florAlto = alto; // Resta la altura del tronco
            float florProfundidad = profundidad / 3;

            // Calcula la posición del tronco
            Punto troncoOrigen = new Punto(origen.x, origen.y + halfAlto + florAlto / 2, origen.z);
            // Crea la forma del tronco (verde)
            formaTronco = new Cara(troncoOrigen, troncoAncho, troncoAlto, troncoProfundidad, Color4.Green);

            // Calcula la posición de la parte superior de la flor (cuadrado rojo)
            Punto florOrigen = new Punto(origen.x, origen.y + halfAlto + florAlto + troncoAlto , origen.z);
            // Crea la forma de la parte superior de la flor (rojo)
           formaSuperiorFlor = new Cara(florOrigen, florAncho, florAlto, florProfundidad, Color4.Red);


        }

        public void Dibujar()
        {
            // Aquí podrías implementar la lógica para dibujar el florero
            this.formaBase.DibujarT();
            this.formaFlorero.DibujarT();
        
            this.formaTronco.DibujarT();
            this.formaSuperiorFlor.DibujarT();
        }
    }
}
