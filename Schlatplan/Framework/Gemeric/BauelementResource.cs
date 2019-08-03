using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;

namespace Schaltplan.Framework.Gemeric
{

    public sealed class BauelementResource : IDisposable
    {
        private static string bauelementDirectory = @".\Bauelemente";
        
        // The below line is for testing. Uncomment it for tests.
        // private static string bauelementDirectory = @"C:\Users\Ethar\Downloads\Schlatplan (1)\Schlatplan\Schlatplan\Bauelemente";

        // read the directory and connect it with the bauelements in order to be able to draw it on the render
        public string Name { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Image Image { get; private set; }
        private List<BauelementResource> _bauelemente = new List<BauelementResource>();
        public IEnumerable<BauelementResource> Bauelemente { get { return _bauelemente; } }
        public static List<BauelementResource> AllElements { get; set; }

        static BauelementResource()
        {

            // load xml datei+ imagne datei from the folder and write it into my directory
            AllElements = new List<BauelementResource>();

            //var bauelementDirectory = @".\Bauelemente";
            
            var rootDirectory = new DirectoryInfo(bauelementDirectory);
            var componentdirection = rootDirectory.GetDirectories();
            foreach (var dir in componentdirection)
            {

                var files = dir.GetFiles();
                var imageFile = files.Where((a) => string.Compare(a.Name, "bauelement.png", true) == 0).FirstOrDefault();
                var xmlFile = files.Where((a) => string.Compare(a.Name, "bauelement.xml", true) == 0).FirstOrDefault();

                if (imageFile != null &&
                    xmlFile != null)

                {
                    AllElements.Add(BauelementResource.Create(dir.Name));
                }
            }
        }
        public BauelementResource()
        {
            /*  Image = null;
             // load xml datei+ imagne datei from the folder and write it into my directory




             var bauelementDirectory = @"C:\Users\arsl9\Desktop\SVN\trunk\Sohaib\Schlatplan\Schlatplan\Bauelemente";
             var rootDirectory = new DirectoryInfo(bauelementDirectory);
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
            }*/
        }

        public void Dispose()
        {
            if (Image != null)
                Image.Dispose();
        }

        public static BauelementResource Create(string bauelementName)
        {
            var imageFile = bauelementDirectory + @"\" + bauelementName + @"\bauelement.png";
            var xmlFile = bauelementDirectory + @"\" + bauelementName + @"\bauelement.xml";
            var resource = new BauelementResource();

            resource.Image = Image.FromFile(imageFile);

            var doc = new XmlDocument();
            doc.Load(xmlFile);
            // read the bauelementXML
            var name = doc.SelectSingleNode("Bauelement/Name");
            var width = doc.SelectSingleNode("Bauelement/Width");
            var height = doc.SelectSingleNode("Bauelement/Height");
            // if succfessfully read then connect it to the resoruces 
            if (name != null &&
                width != null &&
                height != null)
            {
                resource.Name = name.InnerText;
                resource.Width = int.Parse(width.InnerText);
                resource.Height = int.Parse(height.InnerText);
            }

            return resource;
        }
    }
}
