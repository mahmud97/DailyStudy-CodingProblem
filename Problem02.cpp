Question : This problem was asked by Uber.

Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

Follow-up: what if you can't use division?

Solution : 

#include <iostream>

using namespace std;

void findMul(int a[], int size)
{
    int narray[size];

    for (int i = 0;i < size; i++) {

       
        narray[i] = 1;
        for (int j = 0; j < size; j++) {

            if (i != j)
                narray[i] *= a[j];
        }

       
        std :: cout << narray[i] << " ";
    }





}

int main()
{
    int a[]= {1, 2, 3, 4, 5}, size = 5;
    findMul(a,size );

    return 0;
}

