using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class SimpleRetryHelper
    {
        public static void Exec(Action action, int count = 3) {
            
            while (true) {

                try {
                    action();
                    return;
                }
                catch {

                    // TODO: Check for transient Exception

                    count--;
                    if (count == 0) {
                        throw;
                    }
                }

            }

        }


        public static T Exec<T>(Func<T> action, int count = 3)
        {

            while (true)
            {

                try
                {
                    var result = action();
                    return result;
                }
                catch
                {

                    // TODO: Check for transient Exception

                    count--;
                    if (count == 0)
                    {
                        throw;
                    }
                }

            }

        }
    }
}
