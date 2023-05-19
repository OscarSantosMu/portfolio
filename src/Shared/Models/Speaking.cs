// Speaking myDeserializedClass = JsonConvert.DeserializeObject<Speaking>(myJsonResponse);
    public class About
    {
        public string? additionalType { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Address
    {
        public string? addressCountry { get; set; }
        public string? addressLocality { get; set; }
        public string? addressRegion { get; set; }
        public string? postalCode { get; set; }
        public string? streetAddress { get; set; }
    }

    public class Duration
    {
        public string? description { get; set; }
    }

    public class EducationEvent
    {
        public string? assesses { get; set; }
        public string? educationalLevel { get; set; }
        public string? teaches { get; set; }
        public About? about { get; set; }
        public Duration? duration { get; set; }
        public string? endDate { get; set; }
        public string? eventAttendanceMode { get; set; }
        public Funder? funder { get; set; }
        public string? funding { get; set; }
        public string? inLanguage { get; set; }
        public string? keywords { get; set; }
        public Location? location { get; set; }
        public Organizer? organizer { get; set; }
        public Performer? performer { get; set; }
        public RecordedIn? recordedIn { get; set; }
        public string? startDate { get; set; }
        public SuperEvent? superEvent { get; set; }
        public WorkFeatured? workFeatured { get; set; }
        public WorkPerformed? workPerformed { get; set; }
    }

    public class Funder
    {
        public string? name { get; set; }
    }

    public class Location
    {
        public Address? address { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class Organizer
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Performer
    {
        public string? name { get; set; }
    }

    public class RecordedIn
    {
        public string? @abstract { get; set; }
    }

    public class SpeakingModel
    {
        public List<EducationEvent>? EducationEvent { get; set; }
}

    public class SuperEvent
    {
        public About? about { get; set; }
    }

    public class WorkFeatured
    {
        public string? @abstract { get; set; }
    }

    public class WorkPerformed
    {
        public string? @abstract { get; set; }
    }

