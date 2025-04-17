using CsvHelper;

public class ClassSorter
{
    Dictionary<string, Class> Classes = new Dictionary<string, Class>();
    string OutputDirectory = string.Empty;
    string Prefix = string.Empty;
    public ClassSorter(){}
    public ClassSorter(string outputDirectory, string prefix = "")
    {
        this.Prefix = prefix;
        if (Directory.Exists(outputDirectory))
            this.OutputDirectory = outputDirectory;
        else
            Console.WriteLine("Output directory: " + outputDirectory + " does not exist. Writing to application location.");
    }
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

            string filename = this.Prefix + "-" + distribution + "-" + DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".csv";
            filename = Path.Combine(this.OutputDirectory, filename);
            
            Console.WriteLine("Writing file " + filename);
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(classByDistribution);
            }
        }
    }
}
