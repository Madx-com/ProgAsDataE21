// switch test

void main(int n, int y) {
	int month;
	month = n;
	int days;
	days = 0;
	switch (month) {
		case 1:
			{ days = 31; }
		case 2:
			{ if (y % 4 == 0) days = 29; }
		case 3:
			{ days = 31; }
	}
	print days;
}