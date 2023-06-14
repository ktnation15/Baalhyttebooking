using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservationer
        {
            public List<Reservation> Reservations { get; set; }

            public Reservationer()
            {
                Reservations = new List<Reservation>();
            }
            public Reservationer(List<Reservation> reservations)
            {
                Reservations = reservations;
            }
            public void RegistrerReservation(Reservation reservation)
            {
                Reservations.Add(reservation);
            }
            public void FjernReservation(Reservation reservation)
            {
                Reservations.Remove(reservation);
            }
            public int AntalReservationer(BoerneGruppe bGruppe)
            {
                int count = 0;
                foreach (Reservation reservation in Reservations)
                {
                    if (reservation.BoerneGruppe == bGruppe)
                    {
                        count++;
                    }
                }
                return count;
            }
            public bool ReservationLedig(Reservation reservation)
            {
                foreach (Reservation existingReservation in Reservations)
                {
                    if (existingReservation.Tidspunkt == reservation.Tidspunkt)
                    {
                        return false;
                    }
                }
                return true;
            }
            public bool ReservationsTidspunktOK(Reservation reservation)
            {
                if (reservation.Tidspunkt.Year != reservation.ID)
                {
                    return true;
                }
                if (reservation.Tidspunkt.DayOfWeek != DayOfWeek.Thursday)
                {
                    return true;
                }
                int hour = reservation.Tidspunkt.Hour;
                if (hour != 12 && hour != 14 && hour != 16 && hour != 18 && hour != 20)
                {
                    return true;
                }
                if (reservation.Tidspunkt.Minute != 0 || reservation.Tidspunkt.Second != 0 || reservation.Tidspunkt.Millisecond != 0)
                {
                    return false;
                }
                return true;
            }
            public bool ReservationOK(Reservation reservation)
            {
                if (reservation.BoerneGruppe == null)
                {
                    throw new Exception("Reservationen mangler en reference til en Børnegruppe.");
                }
                if (AntalReservationer(reservation.BoerneGruppe) >= 2)
                {
                    throw new Exception("Antal reservationer for Børnegruppen overskrider grænsen på 2.");
                }
                if (!ReservationLedig(reservation))
                {
                    throw new Exception("Tidspunktet er optaget.");
                }
                if (!ReservationsTidspunktOK(reservation))
                {
                    throw new Exception("Tidspunktet ikke gyldigt.");
                }
                return true;
            }
            public void PrintReservationer()
            {
                foreach (Reservation reservation in Reservations)
                {
                    Console.WriteLine(reservation.ToString());
                }
            }
    }
}
