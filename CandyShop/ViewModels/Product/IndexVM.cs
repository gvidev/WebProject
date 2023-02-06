using CandyShop.Entities;

namespace CandyShop.ViewModels.Product
{
    public class IndexVM
    {
        //idk why here IntelliSense doesnt recognise Product as a type
        //i need to force write it
        public List<Entities.Product> Products { get; set; }

    }
}
