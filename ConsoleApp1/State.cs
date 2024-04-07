using System;
using System.Collections.Generic;

public enum PengerjaanState { Selesai, Stuck, Dikerjakan, BlmDikerjakan };
public enum Trigger { Progres, Masalah };

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
        new Transition(PengerjaanState.BlmDikerjakan, PengerjaanState.Dikerjakan, Trigger.Progres),
        new Transition(PengerjaanState.Dikerjakan, PengerjaanState.Selesai, Trigger.Progres),
        new Transition(PengerjaanState.Dikerjakan, PengerjaanState.Stuck, Trigger.Masalah),
        new Transition(PengerjaanState.Stuck, PengerjaanState.Dikerjakan, Trigger.Progres)
    };

    public PengerjaanState currentState = PengerjaanState.BlmDikerjakan;
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
        Console.WriteLine("Pekerjaan baru ditambahkan: " + task + " (State: " + taskState + ")");
    }

    public void DisplayTasks()
    {
        Console.WriteLine("Daftar Pekerjaan:");
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
            Console.WriteLine("State pekerjaan '" + task + "' berhasil diubah menjadi: " + newState);
        }
        else
        {
            Console.WriteLine("Pekerjaan '" + task + "' tidak ditemukan.");
        }
    }
}