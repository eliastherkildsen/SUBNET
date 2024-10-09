using System.Collections;

namespace WPF_MVVM_TEMPLATE.Application;





public class FindSubnetMask
{
    
    
    //| Max antal subnet | subnet mask |
    //| --- | --- |
    // 2 | 192 |
    //| 3-6 | 224 |
    //| 7-14 | 240 |
    //| 15-30 | 248 |
    //| 31-62 | 252 |
    //| 63-126 | 254 |
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="numberOfSubnets"></param>
    /// <returns> returns the subnet mask dec value.
    /// returns -1 if number of subnets excites the maximum amount of subnets. or is invalid</returns>
    public int GetSubnetMaskDec(int numberOfSubnets)
    {

        if (numberOfSubnets is >= 0 and <= 2)
        {
            return 192; 
        }
        else if (numberOfSubnets is >= 3 and <= 6)
        {
            return 224; 
        }      
        else if (numberOfSubnets is >= 7 and <= 14)
        {
            return 240; 
        }
        else if (numberOfSubnets is >= 15 and <= 30)
        {
            return 248; 
        }
        else if (numberOfSubnets is >= 31 and <= 62)
        {
            return 252; 
        }
        else if (numberOfSubnets is >= 63 and <= 126)
        {
            return 254; 
        }
        else if (numberOfSubnets is >= 127 and <= 256)
        {
            return 255; 
        }
        else
        {
            return 0; 
        }
        
    }

    public BitArray GetSubnetMaskBinary(int subnetMask)
    {
        BitArray bitArray = new BitArray(8);
        
        bitArray[0] = (subnetMask & 128) != 0;
        bitArray[1] = (subnetMask & 64)  != 0;
        bitArray[2] = (subnetMask & 32)  != 0;
        bitArray[3] = (subnetMask & 16)  != 0;
        bitArray[4] = (subnetMask & 8)   != 0;
        bitArray[5] = (subnetMask & 4)   != 0;
        bitArray[6] = (subnetMask & 2)   != 0;
        bitArray[7] = (subnetMask & 1)   != 0;

        return bitArray; 

    }
}