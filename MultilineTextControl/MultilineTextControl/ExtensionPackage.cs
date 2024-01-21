using DocsVision.BackOffice.WinForms.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilineTextControl
{
    public sealed class ExtensionPackage : ControlExtensionInfoPackage
    {
        public override ControlExtensionInfo[] GetControlExtensions()
        {
            return new ControlExtensionInfo[]
            {
                new ControlExtensionInfo(typeof(MultilineLayoutItem))
            };
        }
    }
}
