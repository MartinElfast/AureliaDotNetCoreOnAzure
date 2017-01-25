using System.Collections.Generic;
using skeleton.Models;

namespace skeleton.Repository {
    public interface IArtistRepo {
        IList<Artist> GetAll();
        Artist GetById( int id );
        Artist GetByName( string name );
    }
}