using Newtonsoft.Json;
using System;

[Serializable]
public class CardJson
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    public int GuardianStarA { get; set; }
    public int GuardianStarB { get; set; }
    public int Level { get; set; }
    public int Type { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Stars { get; set; }
    public string CardCode { get; set; }
    public int Attribute { get; set; }
    public int NameColor { get; set; }
    public int DescColor { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
