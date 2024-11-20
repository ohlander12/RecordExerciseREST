using Record_Exercise_REST.Models;
using System.Collections.Generic;
using System.Linq;

namespace Record_Exercise_REST.Repositories
{
    public class RecordsRepository
    {
        private readonly List<MusicRecord> _records;
        private int _nextId;

        public RecordsRepository()
        {
            _records = new List<MusicRecord>();
            _nextId = 1;

            // Tilføj nogle eksempler
            Add(new MusicRecord { Title = "Song 1", Artist = "Artist 1", Duration = 180, PublicationYear = 2000 });
            Add(new MusicRecord { Title = "Song 2", Artist = "Artist 2", Duration = 200, PublicationYear = 2005 });
        }

        public List<MusicRecord> GetAll(string? title = null, string? sortBy = null)
        {
            List<MusicRecord> musicrecords = new(_records);

            if (title != null)
            {
                musicrecords = musicrecords.FindAll(musicrecord => musicrecord.Title.StartsWith(title));
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        musicrecords = musicrecords.OrderBy(musicrecord => musicrecord.Id).ToList();
                        break;
                    case "title":
                        musicrecords = musicrecords.OrderBy(musicrecord => musicrecord.Title).ToList();
                        break;
                    case "artist":
                        musicrecords = musicrecords.OrderBy(musicrecord => musicrecord.Artist).ToList();
                        break;
                    case "duration":
                        musicrecords = musicrecords.OrderBy(musicrecord => musicrecord.Duration).ToList();
                        break;
                    case "publicationyear":
                        musicrecords = musicrecords.OrderBy(musicrecord => musicrecord.PublicationYear).ToList();
                        break;
                    case "durationdesc":
                        musicrecords = musicrecords.OrderByDescending(musicrecord => musicrecord.Duration).ToList();
                        break;
                    case "publicationyeardesc":
                        musicrecords = musicrecords.OrderByDescending(musicrecord => musicrecord.PublicationYear).ToList();
                        break;
                }
            }
            return musicrecords;
        }

        public MusicRecord? GetById(int id)
        {
            return _records.Find(musicrecord => musicrecord.Id == id);
        }

        public MusicRecord Add(MusicRecord newMusicRecord)
        {
            newMusicRecord.Id = _nextId++;
            _records.Add(newMusicRecord);
            return newMusicRecord;
        }

        public bool Update(int id, MusicRecord updatedRecord)
        {
            var existingRecord = GetById(id);
            if (existingRecord == null)
            {
                return false;
            }

            existingRecord.Title = updatedRecord.Title;
            existingRecord.Artist = updatedRecord.Artist;
            existingRecord.Duration = updatedRecord.Duration;
            existingRecord.PublicationYear = updatedRecord.PublicationYear;

            return true;
        }

        public bool Delete(int id)
        {
            var record = GetById(id);
            if (record == null)
            {
                return false;
            }

            _records.Remove(record);
            return true;
        }
    }
}
