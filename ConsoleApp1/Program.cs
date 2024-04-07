
class Program
{
    static void Main()
    {
        StateTodo todo = new StateTodo();
        todo.AddTask("Mengerjakan tugas 1", PengerjaanState.BlmDikerjakan);
        todo.AddTask("Mengerjakan tugas 2", PengerjaanState.BlmDikerjakan);
        todo.DisplayTasks();

        todo.ChangeTaskState("Mengerjakan tugas 1", PengerjaanState.Dikerjakan);
        todo.DisplayTasks();
    }
}
