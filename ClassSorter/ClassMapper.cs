using CsvHelper.Configuration;

public class ClassMapper : CsvClassMap<Class>
{
    public ClassMapper()
    {
        Map(m => m.Name).Name("Course Title");
        Map(m => m.Section).Name("Section");
        Map(m => m.Title).Name("Course Title");
        Map(m => m.Subject).Name("Subject");
        Map(m => m.OpenSeats).Name("Seats Remaining");
        Map(m => m.Credits).Name("Units");
    }
}