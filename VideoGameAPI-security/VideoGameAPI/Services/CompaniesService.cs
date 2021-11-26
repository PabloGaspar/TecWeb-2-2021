using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;
using VideoGameAPI.Data.Repository;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public class CompaniesService : ICompaniesService
    {
        ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        private HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "fundation-date",
            "country"
        };

        public CompaniesService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<CompanyModel> CreateCompanyAsync(CompanyModel companyModel)
        {
            var companyEntity = _mapper.Map<CompanyEntity>(companyModel);
            _libraryRepository.CreateCompany(companyEntity);
            var result = await _libraryRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<CompanyModel>(companyEntity);
            }

            throw new Exception("Database Error");
        }

        public async Task<DeleteModel> DeleteCompanyAsync(int companyId)
        {
            await GetCompanyAsync(companyId);

            var DeleteResult = await _libraryRepository.DeleteCompanyAsync(companyId);

            var saveResult = await _libraryRepository.SaveChangesAsync();

            if (!saveResult||!DeleteResult)
            {
                throw new Exception("Database Error");
            }


            if (saveResult)
            {
                return new DeleteModel()
                {
                    IsSuccess = saveResult,
                    Message = "The company was deleted."
                };
            } else
            {
                return new DeleteModel()
                {
                    IsSuccess = saveResult,
                    Message = "The company was not deleted."
                };
            }
        }

        public async Task<IEnumerable<CompanyModel>> GetCompaniesAsync(string orderBy, bool showVideogames)
        {
            if (!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field: {orderBy} is not supported, please use one of these {string.Join(",", allowedOrderByParameters)}");
            }

            var entityList = await _libraryRepository.GetCompaniesAsync(orderBy, showVideogames);
            var modelList = _mapper.Map<IEnumerable<CompanyModel>>(entityList);
            return modelList;
        }

        public async Task<CompanyModel> GetCompanyAsync(int companyID, bool showVideogames = false)
        {
            var company = await _libraryRepository.GetCompanyAsync(companyID, showVideogames);
            if (company == null)
            {
                throw new NotFoundOperationException($"The company with id:{companyID} does not exists");
            }

            return _mapper.Map<CompanyModel>(company);
        }

        public async Task<CompanyModel> UpdateCompanyAsync(int companyId, CompanyModel companyModel)
        {
            var companyEntity = _mapper.Map<CompanyEntity>(companyModel);
            await GetCompanyAsync(companyId);
            companyEntity.Id = companyId;
            _libraryRepository.UpdateCompany(companyEntity);
            
            var saveResult = await _libraryRepository.SaveChangesAsync();

            if (!saveResult)
            {
                throw new Exception("Database Error");
            }
            return companyModel;
        }
    }
}
