using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_MVVM_TEMPLATE.Application;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Presentation.ViewModel;

public class AdminPanelViewModel : ViewModelBase
{

    private string _netidCnt; 
    private string _netid1;
    private string _netid2;
    private string _numSubNet;
    public string NetidCnt
    {
        get
        {
            return _netidCnt;
        }

        set
        {
            _netidCnt = value;
            OnPropertyChanged();
        }
    }
    public string Netid1
    {
        get
        {
            return _netid1;
        }

        set
        {
            _netid1 = value;
            OnPropertyChanged();
        }
    }
    public string Netid2
    {
        get
        {
            return _netid2;
        }

        set
        {
            _netid2 = value;
            OnPropertyChanged();
        }
    }
    public string NumSubNet
    {
        get
        {
            return _numSubNet;
        }

        set
        {
            _numSubNet = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<TreeViewItem> SbnList { get; set; }


    public AdminPanelViewModel()
    {
        SbnList = new ObservableCollection<TreeViewItem>(); 
    }
    
    
    
    
    
    public ICommand CalculateSNM => new CommandBase((Object commandPara) =>
    {
        {

            
            FindSubnetMask fsnm = new FindSubnetMask();
            int subnetMask = fsnm.GetSubnetMaskDec(int.Parse(_numSubNet));
            
            int cnt = 0;
            foreach (bool bit in fsnm.GetSubnetMaskBinary(subnetMask))
            {
                if (bit)
                {
                    cnt++; 
                }
            }

            FindHostIdForSnm idForSnm = new FindHostIdForSnm(subnetMask); 
            List<BitArray> bitArrays =  idForSnm.GenerateBitValues(cnt);
            
            
            for (int i = 0; i < int.Parse(NumSubNet); i++)
            {
                int hostID = idForSnm.ConvertBitArrayToInt(bitArrays.ElementAt(i));  
                var adress = new Subnet(int.Parse(Netid1), int.Parse(Netid2), subnetMask, hostID); 
                TreeViewItem treeViewItem = new TreeViewItem();
                treeViewItem.Header = adress.ToString(); 
                SbnList.Add(treeViewItem);
            }
            
            
            
        }
    });   
}