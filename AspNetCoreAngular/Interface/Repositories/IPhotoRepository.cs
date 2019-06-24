using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAngular.DTO;

namespace AspNetCoreAngular.Interface.Repositories
{
    public interface IPhotoRepository
    {
        Task <IEnumerable<PhotoDTO>> getPhotos();          
    }

}