using Microsoft.Win32;
using MLViewer.Model;
using MLViewer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace MLViewer.ViewModel
{
    class ViewModel:NotificationObject
    {
        public ViewModel()
        {
            Open = new DelegateCommand();
            Open.ExecuteAction += OpenFile;

            About = new DelegateCommand();
            About.ExecuteAction += AboutMe;

            _MyNodes = new ObservableCollection<MLNode>();
        }

        private ObservableCollection<MLNode> _MyNodes;
        public ObservableCollection<MLNode> MyNodes
        {
            get { return _MyNodes; }
            set
            {
                if (_MyNodes != value)
                {
                    _MyNodes = value;
                    RaisePropertyChanged("MyNodes");
                }
            }
        }

        public DelegateCommand Open{get;set;}
        public DelegateCommand About { get; set; }

        private void OpenFile(object parameter)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "XML File *.xml|*.xml";

            try
            {
                if (opd.ShowDialog() == true)
                {
                    XmlDocument xDoc = MLHelper.GetMLDocument(opd.FileName);

                    MLNode retNode = MLHelper.ParserML(xDoc.DocumentElement);
                    MyNodes.Add(retNode); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Parser Error!");
            }
        }

        private void AboutMe(object parameter)
        {
            MessageBox.Show("A Viewer For ML~", "MLViewer");
        }
    }
}
