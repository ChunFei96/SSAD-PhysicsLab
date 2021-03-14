using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common
{
    public interface ICommonService
    {
        List<string> GetEnumbyType(string enumType);
    }
}
