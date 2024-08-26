using System.Collections.Generic;
using basarsoft.Controllers;
using basarsoft.Data;
using basarsoft.Interfaces;
// using basarsoft.Migrations;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.UnitOfWork;

namespace basarsoft.Models
{
    public class Coordinates
    {
        public int Id { get; set; } // public key
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
