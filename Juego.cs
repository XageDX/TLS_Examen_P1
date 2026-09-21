using System;
using System.Collections.Generic;
using System.Text;

namespace TLS_Examen_P1
{
	internal class Juego
	{
		private Jugador jugador;
		private List<Enemigo> enemigos;

		public void Inicio()
		{
			CrearJugador();
			CrearEnemigos();
		}

		private void CrearJugador()
		{
			Console.WriteLine("CREACIÓN DEL JUGADOR");
			Console.WriteLine("=========================");
			Console.Write("Salud: ");
			int salud = Math.Clamp(int.Parse(Console.ReadLine()), 1, 100);
			Console.Write("Daño que puede inflingir: ");
			int daño = Math.Clamp(int.Parse(Console.ReadLine()), 1, 100);

			jugador = new Jugador(salud, daño);
			Console.WriteLine();
		}

		private void CrearEnemigos()
		{
			Console.WriteLine("CREACIÓN DE ENEMIGOS");
			Console.WriteLine("==============================");
			Console.Write("Cantidad de enemigos: ");
			int cantidad = Math.Max(int.Parse(Console.ReadLine()), 1);

			enemigos = new List<Enemigo>();
			for (int i = 0; i < cantidad; i++)
			{
				Console.WriteLine($"Enemigo {i + 1}");
				Console.Write("Salud: ");
				int salud = Math.Clamp(int.Parse(Console.ReadLine()), 1, 100);
				Console.Write("Daño que puede inflingir: ");
				int daño = Math.Clamp(int.Parse(Console.ReadLine()), 1, 100);

				enemigos.Add(new Enemigo(salud, daño));
			}
		}

		public  void Ejecutar()
		{
			int turno = 0;

			while (true)
			{
				switch (turno % 2)
				{
					case 0:
						TurnoJugador();
						break;
					case 1:
						TurnoEnemigos();
						break;
				}

				if (!jugador.EstáVivo() || !EnemigosVivos())
				{
					Console.WriteLine("- Juego terminado -");
					break;
				}

				turno++;
			}
		}

		private void TurnoJugador()
		{
			Console.WriteLine("============ JUGADOR ============");
			Console.Write($"Enemigo a atacar(0 - {enemigos.Count - 1}): ");
			int enemigoIdx = int.Parse(Console.ReadLine());

			if (!enemigos[enemigoIdx].EstáVivo())
			{
				Console.WriteLine("¡Ya déjalo, está muertoooo!");
				Console.WriteLine("=================================");
				return;
			}

			enemigos[enemigoIdx].RecibirDaño(jugador.Daño());
			Console.WriteLine($"El enemigo {enemigoIdx} recibió {jugador.Daño()} de daño");

			if (!enemigos[enemigoIdx].EstáVivo())
			{
				Console.WriteLine("¡Y... murió! XD");
			}
			Console.WriteLine("=================================");
		}

		private void TurnoEnemigos()
		{
			int enemigoIdx = new Random().Next(enemigos.Count);

			Console.WriteLine($"============ ENEMIGO {enemigoIdx} ============");

			jugador.RecibirDaño(enemigos[enemigoIdx].Daño());
			Console.WriteLine($"El jugador recibió {enemigos[enemigoIdx].Daño()} de daño");

			if (!jugador.EstáVivo())
			{
				Console.WriteLine("Pipipi...");
			}
			Console.WriteLine("=================================");
		}

		private bool EnemigosVivos()
		{
			bool vivos = false;
			foreach (Enemigo enemigo in enemigos)
			{
				if (enemigo.EstáVivo())
				{
					vivos = true;
					break;
				}
			}
			return vivos;
		}
	}
}
