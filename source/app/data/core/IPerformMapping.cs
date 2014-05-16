namespace app.data.core
{
  public interface IPerformMapping
  {
    Output map<Source, Output>(Source input);
  }
}