using System;
using System.Collections.Generic;
using System.Diagnostics;

// FILE UNTUK STATE MURID

// State Murid

namespace Utama.Enum
{
    class StateMurid
    {
        public class Transition
        {
            public StatusPemesanan StateAwal;
            public StatusPemesanan StateAkhir;
            public Trigger Trigger;

            public Transition(StatusPemesanan stateAwal, StatusPemesanan stateAkhir, Trigger trigger)
            {
                this.StateAwal = stateAwal;
                this.StateAkhir = stateAkhir;
                this.Trigger = trigger;
            }
        }

        Transition[] transisi =
        {
        new Transition(StatusPemesanan.Pending, StatusPemesanan.Ongoing, Trigger.Pesan),
        new Transition(StatusPemesanan.Ongoing, StatusPemesanan.Pending, Trigger.cancel),
        new Transition(StatusPemesanan.Ongoing, StatusPemesanan.Done, Trigger.mengajar),
        new Transition(StatusPemesanan.Done, StatusPemesanan.Pending, Trigger.selesai)
    };

        public StatusPemesanan currentState = StatusPemesanan.Pending;

        // Dictionary to store tasks with their states
        public Dictionary<string, StatusPemesanan> tasks = new Dictionary<string, StatusPemesanan>();

        public StatusPemesanan GetNextState(StatusPemesanan stateAwal, Trigger trigger)
        {
            foreach (Transition perubahan in transisi)
            {
                if (stateAwal == perubahan.StateAwal && trigger == perubahan.Trigger)
                {
                    return perubahan.StateAkhir;
                }
            }

            // Return current state if no transition found
            return stateAwal;
        }

        public void DisplayMataPelajaran()
        {
            Console.WriteLine("Daftar MataPelajaran:");
            foreach (var task in tasks)
            {
                Console.WriteLine("- " + task.Key + " (State: " + task.Value + ")");
            }
        }

        // State Awal
        public void ActivateTrigger(Trigger trigger)
        {
            currentState = GetNextState(currentState, trigger);
            Console.WriteLine("State Anda adalah: " + currentState);
        }

        public void ChangeTaskState(string task, StatusPemesanan newState)
        {
            if (tasks.ContainsKey(task))
            {
                tasks[task] = newState;
                Console.WriteLine("State Guru '" + task + "' berhasil diubah menjadi: " + newState);
            }
            else
            {
                Console.WriteLine("Pekerjaan '" + task + "' tidak ditemukan.");
            }
        }

        public void PesanGuru()
        {
            Console.Write("Masukkan nama Mata Pelajaran yang ingin dienroll: ");
            string MataPelajaran = Console.ReadLine();
            ChangeTaskState(MataPelajaran, StatusPemesanan.Ongoing);

            DisplayMataPelajaran();
        }
    }
}