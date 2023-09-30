

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class CheckAttendance
    {
        public int IdWorker { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsChecked { get; set; }
        public bool IsIn { get; set; }
        public DateTime AttndncDT { get; set; }
        public string? Message { get; set; }
        public string? MessageBack { get; set; }
    }
    public class CAttendance
    {
        public int Id { get; set; }
        public DateTime? _date { get; set; }
        public TimeSpan? _input { get; set; }
        public TimeSpan? _output { get; set; }
        public string _desc { get; set; }
        public int _status { get; set; }
        public DateTime? _serverDate { get; set; } = null;
    }
}
