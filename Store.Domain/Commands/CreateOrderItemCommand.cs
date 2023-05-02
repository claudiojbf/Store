using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interface;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable<Notification>,ICommand
    {

        public CreateOrderItemCommand() {}

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(HasLen(Product.ToString(), 32), "Product", "Produto Inválido")
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade inválida")
            );
        }

        private bool HasLen(string item, int len)
        {
            if(item.Length == len)
                return true;
            
            return false;
        }
    }
}