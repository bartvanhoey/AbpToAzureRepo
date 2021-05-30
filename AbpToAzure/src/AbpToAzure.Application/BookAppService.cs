using System;
using AbpToAzure.Application.Contracts.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpToAzure.Books
{
   public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
   {
       public BookAppService(IRepository<Book, Guid> repository): base(repository)
       {
           // GetPolicyName = AbpToAzureRepoPermissions.Books.Default;
           // GetListPolicyName = AbpToAzureRepoPermissions.Books.Default;
           // CreatePolicyName = AbpToAzureRepoPermissions.Books.Create;
           // UpdatePolicyName = AbpToAzureRepoPermissions.Books.Update;
           // DeletePolicyName = AbpToAzureRepoPermissions.Books.Delete;
       }
   }
}
