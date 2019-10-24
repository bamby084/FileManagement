using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace FileManagement.Models
{
    [XmlRoot("Users")]
    public class UserCollection: Collection<XmlUser>
    {
        public UserCollection()
            :base()
        {

        }

        public UserCollection(IList<XmlUser> users)
            : base(users)
        {
        }
    }
}
