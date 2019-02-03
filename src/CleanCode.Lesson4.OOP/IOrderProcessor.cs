namespace CleanCode.Lesson4.OOP
{
    public interface IOrderProcessor
    {
        void Accept(Order order);
        void Decline(Order order);
    }
}