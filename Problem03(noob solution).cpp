Question : This problem was asked by Stripe.

Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

You can modify the input array in-place.


Answer : 

void findResult( int a [], int size)
{

    
    bool ck = false;
    int ckn = 1;
    for (int i = 0;i < size;i++) {

        for (int j = 0;j < size;j++) {

            if (ckn == a[j]) {
                ck = true;
                break;
            }
            else {
                ck = false;
            }
        }

        if (!ck) {
            std :: cout << ckn << " is not found" ;
            break;
        }
        ckn++;
    }


}
int main()
{
    //std::cout << "Hello World!\n";
    /*int a[] = { 1, 2, 3, 4, 5 }, size = 5;
    findMul(a, size);*/
    int a[] = { 3, 4, -1, 1 };
    int arraySize = sizeof(a) / sizeof(a[0]);
    findResult(a,arraySize);

}
