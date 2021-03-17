using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Common
{
    public class CommonService : ICommonService
    {

        public CommonService()
        {

        }

        public List<string> GetEnumbyType(string enumType)
        {
            switch (enumType)
            {
                case "GameTopic":
                    return Enum.GetNames(typeof(GameTopic)).ToList();
                case "Difficulties":
                    return Enum.GetNames(typeof(Difficulties)).ToList();
                case "GameCharacters":
                    return Enum.GetNames(typeof(GameCharacters)).ToList();
                case "Role":
                    return Enum.GetNames(typeof(Role)).ToList();
                case "Gender":
                    return Enum.GetNames(typeof(Gender)).ToList();
            }
            return null;
        }
    }
}
