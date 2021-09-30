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

	int i;
	for(i = 0; i < 4; i = i + 1)
	{
		print freq[i];
	}
}

void histogram(int n, int ns[], int max, int freq[])
{
	int i;
	for(i = 0; i < n; i = i + 1)
	{
		freq[ns[i]] = freq[ns[i]] + 1;
	}
}