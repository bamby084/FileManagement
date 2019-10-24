using System;
using System.Xml.Serialization;

namespace FileManagement.Models
{
    [XmlType("User")]
    public class XmlUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
