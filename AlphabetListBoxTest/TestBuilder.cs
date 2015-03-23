using System.Collections.Generic;

namespace AlphabetListBoxTest
{
    public static class TestBuilder
    {
        private static readonly string[] techCompanyList = 
        {
            "Qihoo360",
            "Samsung",
            "Yahoo",
            "Nokia",
            "Google",
            "Microsoft",
            "Apple",
            "Facebook",
            "Foursquare",
            "Baidu",
            "Tencent",
            "Netease",
            "Sina",
            "Sohu",
            "Alibaba",
            "Motorola",
            "HTC",
            "Adobe",
            "LG",
            "Lenovo",
            "IBM",
            "HP",
            "Intel",
            "AMD",
            "Dell",
            "Oracle",
            "Qualcomm",
            "TI",
            "Amazon",
            "Ericsson",
            "Huawei",
            "ZET",
            "Lucent",
            "Siemens",
            "Sony",
            "Panasonic",
            "EPSON",
            "Sharp",
            "Canon",
            "SANYO",
            "Toshiba"
        };

        public static List<AlphabetListBoxItem> GetTestData()
        {
            List<AlphabetListBoxItem> list = new List<AlphabetListBoxItem>();

            foreach (string companyName in techCompanyList)
            {
                list.Add(new AlphabetListBoxItem(companyName));
            }

            list.Sort();

            char lastChar;
            if (list.Count > 0 && list[list.Count - 1].DisplayName.Length > 0)
            {
                lastChar = char.ToLower(list[list.Count - 1].DisplayName[0]);
            }
            else
            {
                lastChar = '#';
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].DisplayName.Length > 0)
                {
                    if (char.ToLower(list[i].DisplayName[0]) != lastChar)
                    {
                        char tempChar = lastChar;
                        
                        lastChar = char.ToLower(list[i].DisplayName[0]);

                        if (lastChar != '#')
                        {
                            list.Insert(i + 1, new AlphabetListBoxItem(tempChar));
                        }
                    }

                    if (i == 0)
                    {
                        list.Insert(0, new AlphabetListBoxItem(char.ToLower(list[i].DisplayName[0])));
                    }
                }
            }

            return list;
        }
    }
}
