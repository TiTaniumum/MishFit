using MishFit.Contracts;

namespace MishFit.Entities;

public class Sleep
{
    public Guid Id { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int Duration { get; set; }
    
    public int SleepQlt { get; set; }
    
    public Sleep(){}

    public Sleep(CreateSleepContract contract)
    {
        Id = Guid.NewGuid();
        StartDate = contract.StartDate;
        EndDate = contract.EndDate;
        Duration = contract.Duration;
        SleepQlt = contract.SleepQlt;
    } 
}