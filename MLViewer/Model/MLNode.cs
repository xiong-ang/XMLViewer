using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLViewer.Model
{
    class MLNode
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string MLString { get; set; }
        public ObservableCollection<MLNode> ChildNodes { get; set; }
    }
}
