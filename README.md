# Conversii

This script takes a number from base 2 to base 64 as input, and returns a number in base 2 to base 64, as indicated by the user.
The cipher is at the top, in a const string titled `digits`.

The code currently doesn't have any exception handling to handle invalid user input (such as inputting a base out of the range 2-64,
or handling characters outside of the cipher.

The number is first converted to base 10 via the "powers-of-10" method, where, for example, 4124.25 in base 5 is
4\*5^3 + 1\*5^2 + 2\*5^1 + 4\*5^0 + 2\*5^-1 + 5\*5^-2 = 539.6

The number in base 10 is then converted to the target base by repeated division with remainder significance.
539 / 13 = 41 remainder 6                      0.6 * 13 = 7.8
41 / 13 = 3 remainder 2                        0.8 * 13 = 10.4
3 / 13 = 0 remainder 3                         0.4 * 13 = 5.2
                                               0.2 * 13 = 0.6
                                               0.6 * 13 = 7.8
                                               ...

The result is 326.(7A50)
