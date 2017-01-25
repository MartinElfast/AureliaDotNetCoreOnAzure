using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using skeleton.Models;
using skeleton.Repository;
using skeleton.Data;

namespace skeleton.Controllers {
    [Route( "api/[controller]" )]
    public class ArtistsController : Controller {

        readonly private IArtistRepo ArtistRepo;

        public ArtistsController( [FromServices]IArtistRepo artistRepo ) {
            this.ArtistRepo = artistRepo;
        }

        [HttpGet]
        public IEnumerable<Artist> Get() {
            return ArtistRepo.GetAll();
        }

        [HttpGet( "{id}" )]
        [Route( "{id}", Name = "GetArtistByIdRoute" )]
        public Artist Get( int id ) {
            return ArtistRepo.GetById( id );
        }

        [HttpGet( "{name}" )]
        [Route( "{name}", Name = "GetArtistByNameRoute" )]
        public Artist Get( string name ) {
            return ArtistRepo.GetByName( name );
        }

        [HttpPost]
        public IEnumerable<Artist> Post() {
            return ArtistRepo.GetAll();
        }
    }
}
