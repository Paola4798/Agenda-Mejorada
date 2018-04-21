using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaVec
{
    class Contactos
    {
        public Persona[] vec = new Persona[15]; //Creamos el vector
        public int _posicionActual;
      //  int _posicionBuscada = 2;

        public Contactos()
        {
            _posicionActual = 0;
        }

        public void agregar(Persona persona)
        {
            vec[_posicionActual] = persona;
            if (_posicionActual > 0)
            {
                ordenar();
            }
            _posicionActual++;
        }

        public void insertar(Persona persona, int posicionInsertar)
        {
            for (int i = _posicionActual; i > posicionInsertar - 1; i--)
                vec[i] = vec[i - 1];
            vec[posicionInsertar - 1] = persona;
            _posicionActual++;
        }

        public void eliminar(string nombre)
        {

            for (int i = 0; i < _posicionActual; i++)
                if (vec[i].Nombre == nombre)
                    for (int y = i; y < _posicionActual - 1; y++) vec[y] = vec[y + 1];
            vec[_posicionActual - 1] = null;
            _posicionActual--;
        }

        public Persona buscar(string nombre)
        {
            for (int i = 0; i < _posicionActual; i++)
                if (vec[i].Nombre == nombre)
                    return vec[i];

            return null;
        }

        public string listar()
        {
            string vecPersona = "";

            for(int i = 0; i < _posicionActual; i++)
            {
               vecPersona += vec[i].ToString() + Environment.NewLine;
            }
            return vecPersona;
        }

        public void ordenar()
        {
            Persona temp;
            for (int i = 0; i < _posicionActual; i++)
            {
                for (int j = 0; j < _posicionActual - i; j++)
                {
                    if (vec[j].Codigo > vec[j + 1].Codigo)
                    {
                        temp = vec[j];
                        vec[j] = vec[j + 1];
                        vec[j + 1] = temp;
                    }
                }
            }
        }
    }


}
