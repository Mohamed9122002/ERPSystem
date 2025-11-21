using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using ERPSystem.DataAccessLayer.Modules.HR;

namespace ERPSystem.PresentationLayer.ViewModels.Profiles
{
    public class TrainingMappingProfilePre:Profile
    {
        public TrainingMappingProfilePre()
        {
            CreateMap<TrainingViewModel, CreateTrainingDto>();
            CreateMap<TrainingViewModel, UpdateTrainingDto>();
            CreateMap<TrainingDetailsDto, TrainingViewModel>();
          
        }
    }
}
