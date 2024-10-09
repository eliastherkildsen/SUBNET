using System.Collections;
using System.Diagnostics;

namespace WPF_MVVM_TEMPLATE.Application;

public class FindHostIdForSnm
{

    private int _subNetMask;

    public FindHostIdForSnm(int subNetMask)
    {
        _subNetMask = subNetMask;
    }

    public List<string> GetAllValidHostIds(byte subNetMask)
    {
        
        List<string> validHostIds = new List<string>();
        
        // converting subNetMask to an array of 8 bits. 
        BitArray bitArray = new BitArray(new Byte[] { subNetMask });
        int bitCount = 0; 
        
        foreach (bool bit in bitArray)
        {
            if (bit) bitCount++;
            
            Debug.WriteLine(bit.ToString());
        }
        
        
        int numbers = 1 << bitCount; // equivalent of 2^n
        for(int i=0; i< numbers; i++)
        {
            string binary = Convert.ToString(i, 2);
            string leadingZeroes = "00000000".Substring(0,bitCount-binary.Length);
            string binaryString = leadingZeroes + binary;

            if (!IsAllCharsTheSame(binaryString))
            {
                Console.WriteLine(binaryString);
                validHostIds.Add(binaryString);
            }
            
        }


        foreach (var VARIABLE in validHostIds)
        {
            Console.WriteLine(VARIABLE.ToString());
            
        }

        return validHostIds;
    }

    private bool IsAllCharsTheSame(string binaryString)
    {


        bool hasZero = false; 
        bool hasOne = false; 
         
        
        foreach (var value in binaryString)
        {
            if (value == '0') hasZero = true;
            else if (value == '1') hasOne = true;
        }
        
        return !(hasZero && hasOne);
        
    }
}