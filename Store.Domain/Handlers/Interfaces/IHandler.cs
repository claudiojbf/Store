using Store.Domain.Commands.Interface;

namespace Store.Domain.Handelers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}