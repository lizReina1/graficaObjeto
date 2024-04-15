using OpenTK.Graphics;
using PlanoGenerico.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoGenerico
{
    public class Parlante
    {
        private Punto origen;
        private float ancho;
        private float alto;
        private float profundidad;
        private Color4 color;

        private Cara formaParlante;
        Cara frenteParlante;
        Cara cuerpoParlante;
        Cara formaBocina;
        public Parlante(Punto p, float ancho, float alto, float profundidad, Color4 color)
        {
            origen = p;
            this.ancho = ancho;
            this.alto = alto;
            this.profundidad = profundidad;
            this.color = color;

            // Calcula las dimensiones de las partes del parlante
            float halfAncho = ancho / 2;
            float halfAlto = alto / 2;
            float halfProfundidad = profundidad / 2;

            // Crea la forma del parlante como un prisma rectangular
            // Frente del parlante (plano)
            Punto frenteOrigen = new Punto(origen.x, origen.y, origen.z + halfProfundidad);
            frenteParlante = new Cara(frenteOrigen, ancho, alto, 0.1f, Color4.Blue); // Grosor del frente ajustable

            // Cuerpo del parlante (cubo)
            Punto cuerpoOrigen = new Punto(origen.x, origen.y, origen.z - halfProfundidad);
             cuerpoParlante = new Cara(cuerpoOrigen, ancho, alto, profundidad, color);

            float bocinaLado = ancho / 4; // Lado del cuadrado de la bocina

            // Calcula la posición de la bocina en el frente del parlante
            Punto bocinaOrigen = new Punto(origen.x, origen.y, origen.z + halfProfundidad + 0.1f); // Ajusta la posición para que esté en el frente
                                                                                                   // Crea la forma de la bocina (cubo)
            formaBocina = new Cara(bocinaOrigen, bocinaLado, bocinaLado, 0.1f, Color4.Silver); // Grosor de la bocina ajustable

        }

        public void Dibujar()
        {
            // Aquí podrías implementar la lógica para dibujar el florero
           // this.formaParlante.DibujarT();
            this.frenteParlante.DibujarT();

            this.cuerpoParlante.DibujarT();
            this.formaBocina.DibujarT();

        }
    }
  }
