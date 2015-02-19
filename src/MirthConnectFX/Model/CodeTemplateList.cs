using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MirthConnectFX.Model
{
    [Serializable, XmlRoot("list")]
    public class CodeTemplateList
    {
        [XmlElement("codeTemplate")]
        public List<CodeTemplate> CodeTemplates { get; set; }

        public CodeTemplateList()
        {
            CodeTemplates = new List<CodeTemplate>();
        }
    }
}