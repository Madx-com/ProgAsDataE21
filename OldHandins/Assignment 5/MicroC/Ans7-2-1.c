
int a[4];

void main(int n) 
{
  a[0] = 7;
  a[1] = 13;
  a[2] = 9;
  a[3] = 8;

  int sum;
  sum = 0;

  arrsum(n, a, &sum);
  print sum;
}

void arrsum(int n, int arr[], int *sump)
{
  int i; i = 0;
  while(0 < n)
  {
    if(i == 4)
    {
	  i = 0;
    }
    *sump = *sump + arr[i];
    i = i + 1;
    n = n - 1;
  }
}
