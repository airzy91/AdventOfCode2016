using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Services
{
    public class GetInputLines : IGetInputLines
    {
        public List<string> Get(string input)
        {
            return input.Split(new []{ "\n", "\r\n"}, StringSplitOptions.None).ToList();
        }
    }
}