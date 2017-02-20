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
        [Display(Name ="Name of Interviewee")]
        public string IntervieweeName { get; set; }

        [Required]
        [Display(Name = "Relationship to Interviewee")]
        public string Relationship { get; set; }

        [Required]
        [Display(Name = "Age of Interviewee")]
        public string AgeRange { get; set; }

        [Display(Name = "Location of Interview")]
        public string Location { get; set; }

        [Display(Name = "One story you would like recorded")]
        public string Stories { get; set; }

        [Display(Name = "Would you like to be the interviewer")]
        public string Interviewer { get; set; }

        [Display(Name = "Date of Interview")]
        public DateTime date { get; set; }

    }
}