namespace ECommerce.API.Customers.Profile
{
    public class CusomerProfile : AutoMapper.Profile
    {
        public CusomerProfile()
        {
            CreateMap<Db.Customer, Models.Customer>();
        }

    }
}
