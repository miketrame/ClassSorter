if(!args.Any())
{
    Console.WriteLine("Add csv file path(s) to as arguments to sort.");
    return 0;
}

Console.WriteLine("Starting to sort classes...");

foreach(var arg in args)
{
    if(!File.Exists(arg))
    {
        Console.WriteLine("File " + arg + " does not exist!");
        continue;
    }
    ClassSorter sorter = new ClassSorter();
    sorter.Sort(arg);
}

return 0;