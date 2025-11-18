using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.DataAccessLayer.Repositories.RepositorieyGeneric;
using ERPSystem.DataAccessLayer.Repositories.UOW;


namespace ERPSystem.BusinessLogicLayer.HRServices.DepartmentS
{
    public class DepartmentService(IUnitOfWork unitOfWork ,IMapper mapper) : IDepartmentService
    {

        IGenericRepository<Department, int> repo = unitOfWork.CreateGenericRepository<Department, int>();
        public async Task<int> CreateDepartmentAsync(CreatedDepartmentDto departmentDto)
        {
            var department = mapper.Map<CreatedDepartmentDto, Department>(departmentDto); 
            await  repo.AddAsync(department);
            return await unitOfWork.SaveChangeAsync();
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            IEnumerable<Department> departments =  await repo.GetAllAsync();
            var departmentsDto = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departments);
            return departmentsDto;
        }

        public async Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await repo.GetByIdAsync(id);
            return mapper.Map<Department, DepartmentDetailsDto?>(department);
        }

        public async Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto)
        {
            var department = mapper.Map<UpdatedDepartmentDto,Department>(departmentDto);
            // Update Employee In Database
            repo.Update(department);
            return await  unitOfWork.SaveChangeAsync();
        }
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department =await repo.GetByIdAsync(id);
            if (department == null)
                throw new Exception($"Department with Id {id} not found.");
           repo.Remove(department);
            var result = await unitOfWork.SaveChangeAsync();
            return result > 0 ? true : false;
        }

    }
}
