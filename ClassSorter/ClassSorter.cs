using CsvHelper;

public class ClassSorter
{
    Dictionary<string, string> DistributionMap = new Dictionary<string, string>();
    List<string> HU_list = new List<string>(){"CLARCH", "CLCIV","COMPLIT","ENGLISH","GTBOOKS","HISTART","INSTHUM","MUSICOL","RCHUMS","RELIGION","SLAVIC","THEORY"};
    List<string> NS_list = new List<string>(){"ANTHRBIO", "ASTRO","BIOLOGY", "BIOPHYS","CHEM","EARTH","EEB","MCDB","PHYSICS"};
    List<string> SS_list = new List<string>(){"ANTHRARC","ANTHRCUL","COMM","ECON","ORGSTUDY","POLSCI","RCSSCI","SOC"};
    List<string> CE_list = new List<string>(){"ARTDES","COMP","DANCE","MUSPERF","RCARTS"};
    List<string> MSA_list = new List<string>(){"MATH","STATS"};
    List<string> ID_list = new List<string>(){ "RCDIV"};
    List<Class> Classes = new List<Class>();
    Dictionary<string, List<Class>> SortedClasses = new Dictionary<string, List<Class>>();
    public ClassSorter()
    {
        foreach(string s in HU_list)
            this.DistributionMap.Add(s, "HU");
        foreach(string s in NS_list)
            this.DistributionMap.Add(s, "NS");
        foreach(string s in SS_list)
            this.DistributionMap.Add(s, "SS");
        foreach(string s in CE_list)
            this.DistributionMap.Add(s, "CE");
        foreach(string s in MSA_list)
            this.DistributionMap.Add(s, "MSA");
        foreach(string s in ID_list)
            this.DistributionMap.Add(s, "ID");
    }
    public void Sort(string csvPath)
    {
        using (var reader = new StreamReader(csvPath))
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.RegisterClassMap<ClassMapper>();
            this.Classes = csv.GetRecords<Class>().ToList();
        }
        
        foreach(var c in Classes)
        {
            string subject = c.Subject.Split('(', ')')[1];
            
            if(!this.DistributionMap.ContainsKey(subject))
            {
                Console.WriteLine("Unable to map subject " + c.Subject + " to a distribution! Writing to misc.");

                if(!this.SortedClasses.ContainsKey("misc"))
                    this.SortedClasses.Add("misc", new List<Class>(){ c });
                else
                    this.SortedClasses["misc"].Add(c);
                continue;
            }

            string distribution = this.DistributionMap[subject];
            
            if(!this.SortedClasses.ContainsKey(distribution))
                this.SortedClasses.Add(distribution, new List<Class>(){ c });
            else
                this.SortedClasses[distribution].Add(c);
        }

        foreach(string s in this.SortedClasses.Keys)
        {
            string filename = s + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
            Console.WriteLine("Writing file " + filename);
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(this.SortedClasses[s]);
            }
        }
    }
}
