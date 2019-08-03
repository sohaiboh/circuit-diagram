using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Schaltplan.Framework.Gemeric
{
    public sealed class BauelementManger
    {

        // load xml datei+ imagne datei from the folder and write it into my directory
        private List<BauelementResource> _bauelemente = new List<BauelementResource>();
        public IEnumerable<BauelementResource> Bauelemente { get{ return _bauelemente; } }




        public void LoadDirectory(string directory)
        {
            var rootDirectory = new DirectoryInfo(directory);
            var componentdirection = rootDirectory.GetDirectories();
            foreach (var dir in componentdirection)
            {

                var files = dir.GetFiles();
                var imageFile = files.Where((a) => string.Compare(a.Name, "bauelement.png", true) == 0).FirstOrDefault();
                var xmlFile = files.Where((a) => string.Compare(a.Name, "bauelement.xml", true) == 0).FirstOrDefault();

                if (imageFile != null &&
                    xmlFile != null)
                    
                {
                    _bauelemente.Add(BauelementResource.Create(dir.Name));
                }
            }
        }
                

    }
}
