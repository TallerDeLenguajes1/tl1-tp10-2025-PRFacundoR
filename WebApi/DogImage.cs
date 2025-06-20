
namespace WebApi
{

public class DogImage
{
    public string message { get; set; }
    public string status { get; set; }

        public static implicit operator List<object>(DogImage v)
        {
            throw new NotImplementedException();
        }
    }

}