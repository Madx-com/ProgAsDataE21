int a[7];

void main()
{
	a[0] = 1;
	a[1] = 2;
	a[2] = 1;
	a[3] = 1;
	a[4] = 1;
	a[5] = 2;
	a[6] = 0;

	int freq[4];
	freq[0] = 0;
	freq[1] = 0;
	freq[2] = 0;
	freq[3] = 0;

	histogram(7, a, 3, freq);

	int i; i = 0;
	while(i < 4)
	{
		print freq[i];
		i = i + 1;
	}
}

void histogram(int n, int ns[], int max, int freq[])
{
	int i; i = 0;
	while(i < n)
	{
		freq[ns[i]] = freq[ns[i]] + 1;
		i = i + 1;
	}
}