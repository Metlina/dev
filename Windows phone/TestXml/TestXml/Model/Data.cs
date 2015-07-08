using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Data.Xml.Dom;

namespace TestXml.Model
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Data
    {
        private string oPERATORField;

        private ulong bROJField;

        private string sTATUSField;

        public Data(XmlDocument data)
        {
            oPERATORField = data.InnerText;
            bROJField = 2;
            sTATUSField = data.InnerText;
        }

        /// <remarks/>
        public string OPERATOR
        {
            get
            {
                return this.oPERATORField;
            }
            set
            {
                this.oPERATORField = value;
            }
        }

        /// <remarks/>
        public ulong BROJ
        {
            get
            {
                return this.bROJField;
            }
            set
            {
                this.bROJField = value;
            }
        }

        /// <remarks/>
        public string STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
            }
        }
    }
}
