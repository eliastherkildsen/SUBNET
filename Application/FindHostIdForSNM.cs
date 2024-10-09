using System.Collections;
using System.Diagnostics;
using System.Windows.Documents;

namespace WPF_MVVM_TEMPLATE.Application;

public class FindHostIdForSnm
{

    private int _subNetMask;

    public FindHostIdForSnm(int subNetMask)
    {
        _subNetMask = subNetMask;
    }
    
    public List<BitArray> GenerateBitValues(int flipBitCount)
    {
        
        List<BitArray> bitValues = new List<BitArray>();
        
        // Calculate the number of combinations, which is 2^flipBitCount
        int totalCombinations = (int)Math.Pow(2, flipBitCount);
        
        // Iterate over all possible combinations of the flip-able bits
        for (int i = 0; i < totalCombinations; i++)
        {
            // Convert 'i' to a binary string with the length of 'flipBitCount'
            string flippedBits = Convert.ToString(i, 2).PadLeft(flipBitCount, '0');
            
            // Combine the fixed part and the flipped bits
            string fullBitValue = flippedBits;
            
            // validating that the value matches subnet mask rules. 
            if (fullBitValue.Contains('0') && fullBitValue.Contains('1'))
            {
                // Ensures total length is 8 bits
                fullBitValue = fullBitValue.PadRight(8, '0'); 
                
                // converting to a bitarry. 
                BitArray bitArray = new BitArray(8);

                for (int j = 0; j < 8; j++)
                {
                    bitArray[j] = fullBitValue[j] == '1';
                }
                bitValues.Add(bitArray);
            }
               
        }
        
        return bitValues;
    }

    public int ConvertBitArrayToInt(BitArray bitArray)
    {

        string bitString = string.Empty; 
        
        // converting bit array to a string. 
        foreach (bool bit in bitArray)
        {
            bitString += bit ? "1" : "0";
        }
        
        int value = Convert.ToInt32(bitString, 2);
        return value;
    }
    
    
}