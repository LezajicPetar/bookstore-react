namespace BookstoreApplication.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string item, int id) : base($"{item} with the ID: {id} could not be found.")
        {

        }

        public NotFoundException(string message) : base(message) 
        {

        }
    }
}
