using CsvHelper;

public class ClassSorter
{
    Dictionary<string, Class> Classes = new Dictionary<string, Class>();
    Dictionary<string, List<Class>> SortedClasses = new Dictionary<string, List<Class>>();
    public ClassSorter(){}
    public void Sort(string csvPath)
    {
        using (var reader = new StreamReader(csvPath))
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.RegisterClassMap<ClassMapper>();
            while(csv.Read())
            {
                Class c = csv.GetRecord<Class>();
                string key = c.SubjectCode + c.Section;

                if (!this.Classes.ContainsKey(key))
                    this.Classes.Add(key, c);
                else
                    this.Classes[key].AddOpenSeats(c.OpenSeats);
            }
        }

        List<string> distributions = this.Classes.Values.ToList().DistinctBy(c => c.DistributionArea).Select(c => c.DistributionArea).ToList();

        foreach(string distribution in distributions)
        {
            List<Class> classByDistribution = this.Classes.Values.Where(c => c.DistributionArea == distribution).ToList();
            string filename = distribution + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
            Console.WriteLine("Writing file " + filename);
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(classByDistribution);
            }
        }

        //foreach(var c in this.Classes.Values)
        //{
        //    string subject = c.SubjectCode;
            
        //    if(!SubjectCodeToDistributionMap.Map.ContainsKey(subject))
        //    {
        //        Console.WriteLine("Unable to map subject " + c.Subject + " to a distribution! Writing to misc.");

        //        if(!this.SortedClasses.ContainsKey("misc"))
        //            this.SortedClasses.Add("misc", new List<Class>(){ c });
        //        else
        //            this.SortedClasses["misc"].Add(c);
        //        continue;
        //    }

        //    string distribution = SubjectCodeToDistributionMap.Map[subject];
            
        //    if(!this.SortedClasses.ContainsKey(distribution))
        //        this.SortedClasses.Add(distribution, new List<Class>(){ c });
        //    else
        //        this.SortedClasses[distribution].Add(c);
        //}

        //foreach(string s in this.SortedClasses.Keys)
        //{
        //    string filename = s + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
        //    Console.WriteLine("Writing file " + filename);
        //    using (var writer = new StreamWriter(filename))
        //    using (var csv = new CsvWriter(writer))
        //    {
        //        csv.WriteRecords(this.SortedClasses[s]);
        //    }
        //}
    }
}
