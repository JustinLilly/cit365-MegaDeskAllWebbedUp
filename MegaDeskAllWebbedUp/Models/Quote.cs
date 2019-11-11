using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskAllWebbedUp.Models
{
    public class Quote
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [Range(24, 96)]
        [Display(Name = "Width")]
        public int DeskWidth { get; set; }
        [Range(12, 48)]
        [Display(Name = "Depth")]
        public int DeskDepth { get; set; }

        [Range(0, 7)]
        [Display(Name = "Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }
        [Display(Name = "Rush Days")]
        public int RushDays { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Total")]
        public int QuotePrice => BASECOST + CalcDrawerCost() + CalcSurfaceAreaCost() + GetMaterialCost() + GetRushOrder(); 

        public Quote() { DateAdded = DateTime.Now; }

        private const int BASECOST = 200;
        private const int SMALLDESK = 1000;
        private const int LARGEDESK = 2000;

        private int CalcDrawerCost() => NumberOfDrawers * 50;
        private int CalcSurfaceArea() => DeskWidth * DeskDepth;

        public int CalcSurfaceAreaCost()
        {
            var surfaceArea = CalcSurfaceArea();
            return (surfaceArea > SMALLDESK) ? surfaceArea + (surfaceArea - SMALLDESK) : surfaceArea;
        }
        private int GetMaterialCost()
        {
            switch (SurfaceMaterial)
            {
                case "Oak": return 200;
                case "Laminate": return 100;
                case "Pine": return 50;
                case "Rosewood": return 300;
                case "Veneer": return 125;
                default: return 50;
            }
        }
        private int GetRushOrder()
        {
            var price = 0;
            var surfaceArea = CalcSurfaceArea();
            if (surfaceArea < SMALLDESK) {
                if (RushDays == 3) { price = 60; }
                else if (RushDays == 5) { price = 40; }
                else if (RushDays == 7) { price = 30; }
            }
            else if (surfaceArea > SMALLDESK && surfaceArea < LARGEDESK) {
                if (RushDays == 3) { price = 70; }
                else if (RushDays == 5) { price = 50; }
                else if (RushDays == 7) { price = 35; }
            }
            else {
                if (RushDays == 3) { price = 80; }
                else if (RushDays == 5) { price = 60; }
                else if (RushDays == 7) { price = 40; }
            }
            return price;
        } 
    }
}
