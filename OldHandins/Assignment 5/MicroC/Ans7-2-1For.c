
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
  int i;
  for(i = 0; 0 < n; i = i + 1)
  {
    if(i == 4)
    {
	  i = 0;
    }
    *sump = *sump + arr[i];
    n = n - 1;
  }
}
