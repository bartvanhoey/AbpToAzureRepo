using AbpToAzure.Books;
using AutoMapper;

namespace AbpToAzure
{
    public class AbpToAzureApplicationAutoMapperProfile : Profile
    {
        public AbpToAzureApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

             CreateMap<Book, BookDto>();
             CreateMap<CreateUpdateBookDto, Book>();
        }
    }
}
