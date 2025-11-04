using AcademyApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.Core.Models
{
    public class Student:BaseEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public StudentTypes StudentTypes { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public override string ToString()
        {
            return $"Student Id: {Id}, Name: {FirstName} {LastName}, Email: {Email}, DateOfBirth: {DateOfBirth}, GroupId: {Group}";
        }

    }
}
