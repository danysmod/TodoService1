namespace App.Boundaries
{
    using System.Threading.Tasks;
    
    public interface IUseCase<in TUseCaseInput>
    {
        Task Handle(TUseCaseInput input);
    }
}
