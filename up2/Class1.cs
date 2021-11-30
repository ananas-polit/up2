using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Drawing;

namespace up2
{
    [Table(Name = "Service")]
    class service
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "ID")]
        public int ID { get; set; }
        [Column(Name = "Title")]
        public string Title { get; set; }
        [Column(Name = "Cost")]
        public decimal Cost { get; set; }
        [Column(Name = "DurationInSeconds")]
        public int DurationInSeconds { get; set; }
        [Column(Name = "Description")]
        public string Description { get; set; }
        [Column(Name = "Discount")]
        public double Discount { get; set; }
        [Column(Name = "MainImagePath")]
        public string MainImagePath { get; set; }

        public Image Image { get; set; }



    }
    [Table(Name = "ClientService")]
    class ClientServ
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "ID")]
        public int Id { get; set; }
        [Column(Name = "ClientID")]
        public int ClientID { get; set; }
        [Column(Name = "ServiceID")]
        public int ServiceID { get; set; }
        [Column(Name = "StartTime")]
        public DateTime StartTime { get; set; }
        [Column(Name = "Comment")]
        public string Comment { get; set; }
    }
}
