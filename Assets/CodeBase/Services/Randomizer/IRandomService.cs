namespace CodeBase.Services.Randomizer
{
  public interface IRandomService : IService
  {
    float Next(float minValue, float maxValue);
  }
}