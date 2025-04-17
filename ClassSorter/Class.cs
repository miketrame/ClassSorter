public class Class
{
    public string Name {get; set;}
    public string Section {get; set;}
    public string Title {get; set;}
    public string Subject {get; set;}
    public string SubjectCode
    {
        get
        {
            if(this.Subject.Contains('(') && this.Subject.Contains(')'))
                return this.Subject.Split('(', ')')[1];
            return this.Subject;
        }
    }
    public string DistributionArea 
    {
        get
        {
            if (SubjectCodeToDistributionMap.Map.ContainsKey(this.SubjectCode))
                return SubjectCodeToDistributionMap.Map[this.SubjectCode];
            return "MISC";
        }
    }
    public string Topic {get; set;}
    private string _OpenSeats = "0";
    public string OpenSeats
    {
        get
        {
            return this._OpenSeats;
        }
        set
        {
            if (value.Trim() == string.Empty)
                this._OpenSeats = "0";
            else
                this._OpenSeats = value.Trim();
        }
    }
    public string Credits {get; set;}
    public void AddOpenSeats(string openSeats)
    {
        try
        {
            if(openSeats.Trim() == string.Empty)
                openSeats = "0";

            if(!int.TryParse(this.OpenSeats.Trim(), out int total))
            {
                Console.WriteLine("Unable to add open seats to class: " + this.Title + "!");
                return;
            }
            if(!int.TryParse(openSeats.Trim(), out int added))
            {
                Console.WriteLine("Unable to add open seats to class: " + this.Title + "!");
                return;
            }
            this.OpenSeats = (total + added).ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine("Unable to add open seats to class: " + this.Title + "!");
        }
    }
}
