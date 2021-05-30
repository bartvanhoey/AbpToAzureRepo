using System;
using AbpToAzure.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpToAzure.Application.Contracts.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>  
    {
            
    }
}
