using MovieTime.Models;

namespace Interfaces
{
    public interface IFilmService
    {
        IEnumerable<Films> GetFilms();
    }
}
