using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthosChronicle.Models
{
    public class VideographerInfo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name of the interviewee")]
        public string IntervieweeName { get; set; }

        [Required]
        [Display(Name = "Relationship")]
        public string Relationship { get; set; }

        [Required]
        [Display(Name = "Age")]
        public string AgeRange { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Any specific stories")]
        public string Stories { get; set; }

        [Display(Name = "Interviewer")]
        public string Interviewer { get; set; }


    }
}