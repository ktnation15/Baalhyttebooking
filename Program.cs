using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Boernegruppe");
            BoerneGruppe gruppe1 = new BoerneGruppe("P1", "Pusling", "Over 12 år", 13);
            Console.WriteLine(gruppe1.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Reservation");
            BoerneGruppe gruppe2 = new BoerneGruppe("T1", "Tumling", "Over 8 år", 14);
            Reservation reservation1 = new Reservation(1, DateTime.Now, gruppe2);
            Console.WriteLine(reservation1.ToString());
            Console.WriteLine();
            //
            // Oprette en Reservation
            Reservationer reservationer = new Reservationer();

            // Oprette BoerneGruppe-objekter
            BoerneGruppe gruppe3 = new BoerneGruppe("P2", "Pilt", "Over 15 år", 15);
            BoerneGruppe gruppe4 = new BoerneGruppe("V1", "Væbner", "Over 10 år", 8);

            // Oprette Reservation-objekter
            Reservation reservation2 = new Reservation(1, DateTime.Now, gruppe3);
            Reservation reservation3 = new Reservation(2, DateTime.Now.AddDays(1), gruppe4);

            // Registrer reservationer
            reservationer.RegistrerReservation(reservation2);
            reservationer.RegistrerReservation(reservation3);

            // Print all reservationer - udskrive
            Console.WriteLine("Alle reservationer:");
            reservationer.PrintReservationer();
            Console.WriteLine();

            // Fjerne en reservation - remove
            Console.WriteLine("Fjern reservation 3:");
            reservationer.FjernReservation(reservation3);

            // Print all reservationer - after remove
            Console.WriteLine("Alle reservationer efter fjernelse:");
            reservationer.PrintReservationer();
            Console.WriteLine("-------------------------------------");

            BoerneGruppe gruppe5 = new BoerneGruppe("S3", "Seniorvæbner", "Over 16 år", 10);
            BoerneGruppe gruppe6 = new BoerneGruppe("JP1", "Jens Peters drenge", "Over 17 år", 8);

            Reservation reservation4 = new Reservation(2023, new DateTime(2023, 6, 15, 12, 0, 0), gruppe5); // Gyldig reservation
            Reservation reservation5 = new Reservation(2023, new DateTime(2023, 6, 15, 14, 0, 0), gruppe5); // Gyldig reservation
            Reservation reservation6 = new Reservation(2023, new DateTime(2023, 6, 15, 16, 0, 0), gruppe5); // Gyldig reservation
            Reservation reservation7 = new Reservation(2023, new DateTime(2023, 6, 15, 18, 0, 0), gruppe6); // Gyldig reservation

            // Oprette/tilføje Reservationer & registre dem i reservationer
            Reservationer Reservationer = new Reservationer();
            Reservationer.RegistrerReservation(reservation4);
            Reservationer.RegistrerReservation(reservation5);
            Reservationer.RegistrerReservation(reservation6);
            Reservationer.RegistrerReservation(reservation7);
            // ReservationOK med try and catch the wizard.
            try
            {
                Reservationer.ReservationOK(reservation1);
                Console.WriteLine($"Reservation {reservation1} er gyldig.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Reservation {reservation1} er ugyldig: {ex.Message}");
            }
            try
            {
                Reservationer.ReservationOK(reservation6);
                Console.WriteLine($"Reservation {reservation6} er gyldig.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Reservation {reservation6} er ugyldig: {ex.Message}");
            }
            try
            {
                Reservationer.ReservationOK(reservation7);
                Console.WriteLine($"Reservation {reservation7} er gyldig.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Reservation {reservation7} er ugyldig: {ex.Message}");
            }
        }
    }
}
