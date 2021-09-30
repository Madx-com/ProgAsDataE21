void main(int i)
{
	int number;
	int number2;
	int number3;
	number = i;
	number2 = 2;

	number3 = number + number2;
	
	// Since char arrays is not handled in microC this is int array
	int ints[3];
	ints[3] = 1;

	int myint;

	myint = ints[number3];

	//I should be a pointer to number2; but I cannot function in microC
	// int *int_ptr;
		
	//*int_ptr = &number2;

	//int value;

	//value = &int_ptr + 1;
}