using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCue.POMs
{
    public class ChooseTypePage
    {
        AndroidDriver<AndroidElement> _driver;

        public ChooseTypePage(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }
    }
}
