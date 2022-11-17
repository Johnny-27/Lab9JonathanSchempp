//To-DO List for customer//

List<(string, string, DateTime)> CurrentItems = new List<(string, string, DateTime)>();
List<(string, string, DateTime, DateTime)> FinishedItems = new List<(string, string, DateTime, DateTime)>();
DateTime StartTime = new DateTime();
DateTime EndTime = new DateTime();
int TasksCreated = 0;
int TasksCompleted = 0;
Console.WriteLine("To-Do List");

void Adding()
{
    Console.WriteLine("Enter what you would like to add to your To-Do list:");
    string response = Console.ReadLine();
    string ToDo = response;
    Console.WriteLine("Add a description to this item");
    response = Console.ReadLine();
    string Description = response;
    Console.WriteLine($"You added: {ToDo}: {Description}");
    StartTime = DateTime.Now;
    (string, string, DateTime) AddedItem = (ToDo, Description, StartTime);
    CurrentItems.Add(AddedItem);
    TasksCreated++;
    TaskMenu();   
}

void Completing()
{
    Console.WriteLine("Select the item you wish to mark as complete");
    for(int x = 0; x <CurrentItems.Count; x++)
    {
        Console.WriteLine($" {x + 1}: {CurrentItems[x]}");
    }
    Console.WriteLine("(Type the number of the task)");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if(NumComp > CurrentItems.Count)
    {
        Console.WriteLine("Invalid Input");
        TaskMenu();
    }
    Console.WriteLine($"Here is the task you have marked as complete: {CurrentItems[NumComp]}");
    (string, string, DateTime) TaskCompleted = CurrentItems[NumComp];
    EndTime = DateTime.Now;
    CurrentItems.Remove(CurrentItems[NumComp]);
    FinishedItems.Add((TaskCompleted.Item1,TaskCompleted.Item2, TaskCompleted.Item3, EndTime));
    TasksCompleted++;
    TaskMenu();
}

void ToDoItems()
{
    Console.WriteLine("Here are your To-Do items");
    for(int x = 0; x <CurrentItems.Count; x++)
    {
        Console.WriteLine($" {x + 1}: {CurrentItems[x]}");
    }
    if(CurrentItems.Count == 0)
    Console.WriteLine("There are no To-Do items");
    Console.ReadLine();
    TaskMenu();
}

void CompletedItems()
{
    Console.WriteLine("Here are your completed items");
    for(int x = 0; x < FinishedItems.Count; x++)
    {
    Console.WriteLine($" {x + 1}: {FinishedItems[x]}");
    }
    if(FinishedItems.Count == 0)
    Console.WriteLine("There are no completed items");
    Console.ReadLine();
    TaskMenu();
}

void TaskMenu(){
    Console.WriteLine("Please select an option");
    Console.WriteLine("1) Add items to the To-Do list\n2) Mark an item as complete\n3) See your To-Do items\n4) See your completed items\n5) Finish");
    string response = Console.ReadLine();
    if(response == "1")
        Adding();
    if(response == "2")
        Completing();
    if(response == "3")
        ToDoItems();
    if(response == "4")
        CompletedItems();
    if(response == "5")
        System.Environment.Exit(0);
    else
    {
        TaskMenu();
    }
}
TaskMenu();