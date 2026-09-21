using System;
using System.Collections.Generic;
using System.Text;

namespace TLS_Examen_P1
{
	internal class Jugador
	{
		private int vida, daño;

		public Jugador(int vida, int daño)
		{
			this.vida = vida;
			this.daño = daño;
		}

		public void RecibirDaño(int daño)
		{
			vida = Math.Max(vida - daño, 0);
		}

		public int Daño()
		{
			return daño;
		}

		public bool EstáVivo()
		{
			return vida > 0;
		}
	}
}
