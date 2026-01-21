using GameConsoleBase.App;
using GameConsoleBase.DB;

namespace GameConsoleBase.Interfaces;

public interface IGamePlay
{
    public string Name { get; set; }
    public int Score { get; set; }

    public void Play();


   
}