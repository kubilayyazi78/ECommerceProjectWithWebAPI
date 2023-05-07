using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dtos.PageLanguages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPageLanguageDal : EfBaseRepository<PageLanguage, ECommerceDbContext>, IPageLanguageDal
    {
        public Task<List<PageLanguageDto>> GetListDetailAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}