using System;
using System.Collections.Generic;

public enum PengerjaanState { bersedia,SudahDipesan,Mengajar };
public enum Trigger { Pesan, cancel,mengajar,selesai };

class StateTodo
{
    public class Transition
    {
        public PengerjaanState StateAwal;
        public PengerjaanState StateAkhir;
        public Trigger Trigger;

        public Transition(PengerjaanState stateAwal, PengerjaanState stateAkhir, Trigger trigger)
        {
            this.StateAwal = stateAwal;
            this.StateAkhir = stateAkhir;
            this.Trigger = trigger;
        }
    }

    Transition[] transisi =
    {
        new Transition(PengerjaanState.bersedia, PengerjaanState.SudahDipesan, Trigger.Pesan),
        new Transition(PengerjaanState.SudahDipesan, PengerjaanState.bersedia, Trigger.cancel),
        new Transition(PengerjaanState.SudahDipesan, PengerjaanState.Mengajar, Trigger.mengajar),
        new Transition(PengerjaanState.Mengajar, PengerjaanState.bersedia, Trigger.selesai)
    };

    public PengerjaanState currentState = PengerjaanState.bersedia;
    public Dictionary<string, PengerjaanState> tasks = new Dictionary<string, PengerjaanState>(); // Dictionary to store tasks with their states

    public PengerjaanState GetNextState(PengerjaanState stateAwal, Trigger trigger)
    {
        foreach (Transition perubahan in transisi)
        {
            if (stateAwal == perubahan.StateAwal && trigger == perubahan.Trigger)
            {
                return perubahan.StateAkhir;
            }
        }
        return stateAwal; // Return current state if no transition found
    }

    public void ActivateTrigger(Trigger trigger)
    {
        currentState = GetNextState(currentState, trigger);
        Console.WriteLine("State Anda adalah: " + currentState);
    }

    public void AddTask(string task, PengerjaanState taskState)
    {
        tasks.Add(task, taskState);
        Console.WriteLine("tambah guru: " + task + " (State: " + taskState + ")");
    }

    public void DisplayTasks()
    {
        Console.WriteLine("Daftar guru:");
        foreach (var task in tasks)
        {
            Console.WriteLine("- " + task.Key + " (State: " + task.Value + ")");
        }
    }

    public void ChangeTaskState(string task, PengerjaanState newState)
    {
        if (tasks.ContainsKey(task))
        {
            tasks[task] = newState;
            Console.WriteLine("State guru '" + task + "' berhasil diubah menjadi: " + newState);
        }
        else
        {
            Console.WriteLine("Pekerjaan '" + task + "' tidak ditemukan.");
        }
    }
    public void Jalan()
    {

        Console.Write("Masukkan jumlah guru yang ingin ditambahkan: ");
        int jumlahGuru = int.Parse(Console.ReadLine());

        for (int i = 0; i < jumlahGuru; i++)
        {
            Console.Write("Masukkan nama guru ke-" + (i + 1) + ": ");
            string namaGuru = Console.ReadLine();
            AddTask(namaGuru, PengerjaanState.bersedia);
        }

        DisplayTasks();

        Console.Write("Masukkan nama guru yang ingin diubah statusnya menjadi SudahDipesan: ");
        string guruYangDiubah = Console.ReadLine();
        ChangeTaskState(guruYangDiubah, PengerjaanState.SudahDipesan);

        DisplayTasks();
    }
}
