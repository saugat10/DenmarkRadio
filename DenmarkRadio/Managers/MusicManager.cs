using DenmarkRadio.Models;

namespace DenmarkRadio.Managers
{
    public class MusicManager
    {
        private static int _nextId = 1;

        private static readonly List<Music> Data = new List<Music>
        {
            new Music { Id = _nextId++, Artist = "The Script", Duration = 300, Title = "Hall of Fame", PublicationYear= 2012},
            new Music { Id = _nextId++, Artist = "Denmark", Duration = 210, Title = "Zealand", PublicationYear= 2010},
            new Music { Id = _nextId++, Artist = "Andres", Duration = 120, Title = "JavaScript", PublicationYear= 2022},
            new Music { Id = _nextId++, Artist = "The Script", Duration = 180, Title = "Paint the town green", PublicationYear= 2011}
        };

        public List<Music> GetAll()
        {
            return new List<Music>(Data);
        }

        public Music? GetById(int id)
        {
            return Data.Find(music => music.Id == id);
        }

        public Music Add(Music newMusic)
        {
            newMusic.Id = _nextId++;
            Data.Add(newMusic);
            return newMusic;
        }

        public Music? Delete(int id)
        {
            Music? music = Data.Find(music1 => music1.Id == id);
            if (music == null) return null;
            Data.Remove(music);
            return music;
        }

        public Music? Update(int id, Music updates)
        {
            Music? music = Data.Find(music1 => music1.Id == id);
            if (music == null) return null;

            music.Title = updates.Title;
            music.Artist = updates.Artist;
            music.Duration = updates.Duration;
            music.PublicationYear = updates.PublicationYear;
            return music;
        }
    }
}
