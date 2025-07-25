using System.ComponentModel.DataAnnotations;

namespace APIcharacters.Models;

public class Character
{
    [Key]
    public Guid Id { get; init; }
    [Required(ErrorMessage = "Por favor, informe o nome do personagem.")]
    public string Name { get; set; }
    public string Birthplace { get; set; }
    public string Preferences { get; set; }
    public int Age { get; set; }
    public string Goals { get; set; }
    public string Fears { get; set; }
    public bool Active { get; set; }

    public DateTime CreatedDate { get; set; }
    
    public Character(string requestName) {}

    public Character(string name,string birthplace,string preferences,int age,string goals, string fears)
    {
        Id = Guid.NewGuid();
        Name = name;
        Birthplace = birthplace;
        Preferences = preferences;
        Age = age;
        Goals = goals;
        Fears = fears;
        Active = true;
        CreatedDate = DateTime.Now;
    }

    public void UpdateDescription(string name, string birthplace, string preferences, int age, string goals,
        string fears)
    {
        Name = name;
        Birthplace = birthplace;
        Preferences = preferences;
        Age = age;
        Goals = goals;
        Fears = fears;
    }
    public void Deactivate()
    {
        Active = false;
    }
    
    
}