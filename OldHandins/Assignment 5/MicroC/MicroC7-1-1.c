void main(int n)
{
	int *sumpointer;
	int input;
	input = n;
	int narray[3];
	narray[0] = 7;
	narray[1] = 13;
	narray[2] = 9;
	narray[3] = 8;

	sumpointer = NULL;

	void arrsum(input, narray, *sumpointer); 
	// Why the fucking fuck wont this compile?

	//print *sumpointer;
}

void arrsum(int n, int *arr, int *sum)
{
	int counter;
	counter = n;
	int sumvalue;
	sumvalue = arr[counter];
	while (counter > 0)
	{
		counter = counter - 1;
		sumvalue = arr[counter] + sumvalue;
	}
	*sum = sumvalue;
}