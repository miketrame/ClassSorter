using Microsoft.VisualBasic;

public static class SubjectCodeToDistributionMap
{
    public static Dictionary<string, string> Map;
    static SubjectCodeToDistributionMap()
    {
        Map = new Dictionary<string, string>();
        List<string> HU_list = new List<string>() { "CLARCH", "CLCIV", "COMPLIT", "ENGLISH", "GTBOOKS", "HISTART", "INSTHUM", "MUSICOL", "RCHUMS", "RELIGION", "SLAVIC", "THEORY" };
        List<string> NS_list = new List<string>() { "ANTHRBIO", "ASTRO", "BIOLOGY", "BIOPHYS", "CHEM", "EARTH", "EEB", "MCDB", "PHYSICS" };
        List<string> SS_list = new List<string>() { "ANTHRARC", "ANTHRCUL", "COMM", "ECON", "ORGSTUDY", "POLSCI", "RCSSCI", "SOC" };
        List<string> CE_list = new List<string>() { "ARTDES", "COMP", "DANCE", "MUSPERF", "RCARTS" };
        List<string> MSA_list = new List<string>() { "MATH", "STATS" };
        List<string> ID_list = new List<string>() { "RCDIV" };

        foreach (string s in HU_list)
            Map.Add(s, "HU");
        foreach (string s in NS_list)
            Map.Add(s, "NS");
        foreach (string s in SS_list)
            Map.Add(s, "SS");
        foreach (string s in CE_list)
            Map.Add(s, "CE");
        foreach (string s in MSA_list)
            Map.Add(s, "MSA");
        foreach (string s in ID_list)
            Map.Add(s, "ID");
    }
}
