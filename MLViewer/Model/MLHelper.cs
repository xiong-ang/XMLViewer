using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MLViewer.Model
{
    class MLHelper
    {
        public static XmlDocument GetMLDocument(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            if (xDoc == null)
                throw new Exception("Load File Failed!");

            return xDoc;
        }

        public static MLNode ParserML(XmlNode xNode)
        {
            if (xNode == null)
                return null;

            int childCount = xNode.ChildNodes.Count;

            string name = xNode.Name;

            string icon = string.Empty;
            if(childCount == 0)
                icon = "/Image/Content.png";
            else 
                icon = "/Image/Node.png";

            string mlString = xNode.OuterXml; 

            ObservableCollection<MLNode> childNodes = new ObservableCollection<MLNode>();
            foreach (XmlNode item in xNode.ChildNodes)
            {
                childNodes.Add(ParserML(item));
            }


            return new MLNode() { Name=name, Icon=icon, MLString=mlString, ChildNodes=childNodes};
        }
    }
}
