namespace WPF_MVVM_TEMPLATE.Entitys;

public class Subnet
{
    public int NetId1 { get; set; }
    public int NetId2 { get; set; }
    public int SubnetId { get; set; }
    public int HostID { get; set; }

    public Subnet(int netID1, int netID2, int subnetID, int? hostID)
    {
        NetId1 = netID1;
        NetId2 = netID2;
        SubnetId = subnetID;
        HostID = hostID ?? 0;
    }


    public override string ToString()
    {
        return $"{NetId1}.{NetId2}.{SubnetId}.{HostID}"; 
    }
}
