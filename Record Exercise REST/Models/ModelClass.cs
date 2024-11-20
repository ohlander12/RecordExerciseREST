using System;

namespace Record_Exercise_REST.Models
{
    public class MusicRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Artist { get; set; }
        public int Duration { get; set; }  // Duration in seconds
        public int PublicationYear { get; set; }

        
        public MusicRecord(int id, string title, string artist, int duration, int publicationYear)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }
        public MusicRecord()
        { 
        
        }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Duration: {Duration}, PublicationYear: {PublicationYear}";
        }
    }
}
