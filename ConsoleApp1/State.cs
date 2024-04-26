using System;
using System.Collections.Generic;

public enum PengerjaanState { bersedia,SudahDipesan,Mengajar };
public enum Trigger { Pesan, cancel,mengajar,selesai };
class StateGuru
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

    public void AddTask(string guru, PengerjaanState taskState)
    {
        tasks.Add(guru, taskState);
        Console.WriteLine("tambah guru: " + guru + " (State: " + taskState + ")");
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
    public void TambahGuru()
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

   
    }
    public void PesanGuru()
    {
        Console.Write("Masukkan nama guru yang ingin dippesann: ");
        string guruYangDiubah = Console.ReadLine();
        ChangeTaskState(guruYangDiubah, PengerjaanState.SudahDipesan);
        Bayar();

        DisplayTasks();
    }

    public void Bayar()
    {
        BankTransferConfig config = new BankTransferConfig();
        Console.WriteLine("en/id:");

        Console.WriteLine("bayar");
        string Bahasa = Console.ReadLine();

        string langPrompt = Bahasa == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:";
        Console.WriteLine(langPrompt);
        int amount = int.Parse(Console.ReadLine());

        int totalAmount = amount;

        string feeOutput = Bahasa == "en" ? "Transfer fee = " : "Biaya transfer = ";
        string totalOutput = Bahasa == "en" ? "Total amount = " : "Total biaya = ";
        Console.WriteLine($"{totalOutput} {totalAmount}");

        string methodPrompt = Bahasa == "en" ? "Select transfer method:" : "Pilih metode transfer:";
        Console.WriteLine(methodPrompt);
        for (int i = 0; i < config.Methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        Console.Write("Select transfer method number: ");
        int selectedMethodIndex = int.Parse(Console.ReadLine());

        Console.WriteLine($"Selected transfer method: {config.Methods[selectedMethodIndex - 1]}");

        string confirmationPrompt = Bahasa == "en" ? $"Please type \"{config.Confirmation.En}\" to confirm the transaction:" : $"Ketik \"{config.Confirmation.Id}\" untuk mengkonfirmasi transaksi:";
        Console.WriteLine(confirmationPrompt);
        string confirmation = Console.ReadLine();

        string successMessage = Bahasa == "en" ? "The transfer is completed" : "Proses transfer berhasil";
        string failureMessage = Bahasa == "en" ? "Transfer is cancelled" : "Transfer dibatalkan";
        if (confirmation == config.Confirmation.En || confirmation == config.Confirmation.Id)
        {
            Console.WriteLine(successMessage);
        }
        else
        {
            Console.WriteLine(failureMessage);
        }
    }
}