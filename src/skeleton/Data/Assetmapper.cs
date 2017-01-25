using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using skeleton.Models;

namespace skeleton.Data {
    public class AssetMapper {

        public List<Artist> artists = new List<Artist>();

        public AssetMapper() {
            artists.Clear();
            string dirName = Path.GetDirectoryName( Directory.GetCurrentDirectory() + @"\wwwroot\Artists\" );
            //var imgPath = Path.GetDirectoryName( Directory.GetCurrentDirectory() + @"\Artists\" );
            //Test/Debug
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start(); //POC / testing out if optimization is needed
            int idx = 0;
            try {
                foreach ( string subDir in Directory.GetDirectories( dirName ) ) {
                    artists.Add( new Artist {
                        Id = idx,
                        Name = Path.GetFileName( subDir ),
                        ImgUrls = new List<string>()
                    } );
                    foreach ( string file in Directory.GetFiles( subDir ) ) {
                        if ( Path.GetFileNameWithoutExtension( file ).ToLower().Equals( "cv" ) ) {
                            artists[idx].CV = File.ReadAllText( file );
                        } else if ( Path.GetFileNameWithoutExtension( file ).ToLower().Equals( "portrait" ) ) {
                            artists[idx].PortraitImgUrl = @"Artists/" + artists[idx].Name + "/" + Path.GetFileName( file );
                        } else if ( Path.GetFileNameWithoutExtension( file ).ToLower().Equals( "front" ) ) {
                            artists[idx].FrontPageImgUrl = @"Artists/" + artists[idx].Name + "/" + Path.GetFileName( file );
                            artists[idx].ImgUrls.Add( @"Artists/" + artists[idx].Name + "/" + Path.GetFileName( file ) );
                        } else {
                            artists[idx].ImgUrls.Add( @"Artists/" + artists[idx].Name + "/" + Path.GetFileName( file ) );
                        }
                    }
                    if ( artists[idx].FrontPageImgUrl == null )
                        artists[idx].FrontPageImgUrl = artists[idx].ImgUrls[0];
                    idx++;
                }
            } catch ( Exception excpt ) {
                Console.WriteLine( "Message:" );
                Console.WriteLine( excpt.Message );
                Console.WriteLine( "InnerExcp:" );
                Console.WriteLine( excpt.InnerException );
                Console.WriteLine( "Just the good ol' excpt:" );
                Console.WriteLine( excpt );
            }
            sw.Stop();
            System.Diagnostics.Debug.WriteLine( $"Mapping artists took: { sw.ElapsedMilliseconds} ms. " );//Results: 6-8ms with 10 artists ~40 imgs, scales linearly with amount of content.            
        }
    }
}
