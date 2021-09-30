void main(int n) 
{
  if(n > 20)
  {
	n = 20;
  }

  int a[20];
  int sum; sum = 0;

  squares(n, a);
  arrsum(n, a, &sum);
  print sum;
}

void squares(int n, int arr[])
{
  int i; i = 0;
  while(i < n)
  {
    arr[i] = i * i;
    i = i + 1;
  }
}

void arrsum(int n, int arr[], int *sump)
{
  int i; i = 0;
  while(i < n)
  {
    /*
	if(i == 4)
    {
	  i = 0;
    }
	*/
    *sump = *sump + arr[i];
    i = i + 1;
  }
}
