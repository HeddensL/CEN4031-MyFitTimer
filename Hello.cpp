#include <iostream>
#include <string>
using namespace std;

int main ()
{
    string word;
    
    while (word != "hello")
    {
        cout << "type hello: ";
        cin >> word;
    }
    return 0;
}