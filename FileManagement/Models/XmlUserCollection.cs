using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace FileManagement.Models
{
    [XmlRoot("Users")]
    public class XmlUserCollection: Collection<XmlUser>
    {
        public XmlUserCollection()
            :base()
        {

        }

        public XmlUserCollection(IList<XmlUser> users)
            : base(users)
        {
        }
    }
}
