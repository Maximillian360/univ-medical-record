namespace UnivMedicalRecord.Models.Graphs;

public class BarGraphDatasets
{
    public string label { get; set; }
    public List<double> data { get; set; }
    public List<string> backgroundColor { get; set; }
    public List<string> borderColor { get; set; }
    public int borderWidth { get; set; }   
}