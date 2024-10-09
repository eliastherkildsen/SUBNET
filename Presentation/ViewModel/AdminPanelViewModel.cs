using System.Diagnostics;
using System.Windows.Input;
using WPF_MVVM_TEMPLATE.Application;

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
    
    
    
    
    
    public ICommand CalculateSNM => new CommandBase((Object commandPara) =>
    {
        {
            
            Debug.WriteLine("Add Network was called");
            Debug.WriteLine($"NetIDCont {_netid1}");
            Debug.WriteLine($"NetIDCont {_netid2}");
            Debug.WriteLine($"num subnet {_numSubNet}");
            
            
            FindSubnetMask fsnm = new FindSubnetMask();
            byte _subnetMask = fsnm.GetSubnetMaskDec(int.Parse(_numSubNet));
            
            Debug.WriteLine($"{_netid1}.{_netid2}.{_subnetMask}");


            foreach (var VARIABLE in new FindHostIdForSnm(_subnetMask).GetAllValidHostIds(_subnetMask))
            {
                Debug.WriteLine($"{VARIABLE}");
            }
            
            
        }
    });   
}