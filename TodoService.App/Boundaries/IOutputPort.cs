namespace App.Boundaries
{
    public interface IOutputPort <in TUseCaseOutput>
    {
        void Output(TUseCaseOutput output);
    }
}
