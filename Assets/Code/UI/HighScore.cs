using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
//this section was written by chatgpt. was too much effort for a small joke
class ChineseNumberConverter
{
    // Chinese characters for digits 0-9
    private static readonly string[] ChineseDigits =
        { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };

    // Units for positions (ones, tens, hundreds, thousands)
    private static readonly string[] Units =
        { "", "十", "百", "千" };

    // Higher units (ten thousand, hundred million)
    private static readonly string[] HigherUnits =
        { "", "万", "亿" };

    public static string IntToChinese(int number)
    {
        if (number == 0)
            return ChineseDigits[0];

        if (number < 0)
            return "负" + IntToChinese(-number);

        string numStr = number.ToString();
        int len = numStr.Length;

        StringBuilder result = new StringBuilder();
        bool zeroFlag = false;
        int unitPos = 0;

        while (len > 0)
        {
            int sectionLen = Math.Min(4, len);
            string section = numStr.Substring(len - sectionLen, sectionLen);
            string sectionChinese = ConvertSectionToChinese(int.Parse(section));

            if (zeroFlag && sectionChinese.Length > 0)
            {
                result.Insert(0, ChineseDigits[0]);
                zeroFlag = false;
            }

            if (sectionChinese.Length > 0)
            {
                result.Insert(0, sectionChinese + HigherUnits[unitPos]);
            }
            else
            {
                zeroFlag = true;
            }

            unitPos++;
            len -= sectionLen;
        }

        string output = result.ToString();

        // Handle special case for numbers between 10 and 19 (e.g., "一十二" -> "十二")
        if (output.StartsWith("一十") && output.Length > 2)
            output = output.Substring(1);

        return output;
    }

    private static string ConvertSectionToChinese(int number)
    {
        StringBuilder section = new StringBuilder();
        int unit = 0;
        bool zero = false;

        while (number > 0)
        {
            int digit = number % 10;
            if (digit == 0)
            {
                if (!zero && section.Length > 0)
                {
                    section.Insert(0, ChineseDigits[0]);
                    zero = true;
                }
            }
            else
            {
                section.Insert(0, ChineseDigits[digit] + Units[unit]);
                zero = false;
            }

            unit++;
            number /= 10;
        }

        return section.ToString();
    }

    // Test
    static void Main()
    {
        int[] testNumbers = { 0, 5, 10, 11, 20, 101, 110, 1234, 10005, 100010001, -2024 };

        foreach (int number in testNumbers)
        {
            Console.WriteLine($"{number} => {IntToChinese(number)}");
        }
    }
}
public class HighScore : MonoBehaviour
{
    TMP_Text display;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        display = this.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //int.TryParse(display.text, out score);
        display.text = ChineseNumberConverter.IntToChinese(score);
    }
}
