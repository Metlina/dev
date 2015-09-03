class Kompleksni
{
public:

	double _re, _im;
	Kompleksni(double re, double im) : _re(re), _im(im) { }

	Kompleksni operator+(double k)
	{
		return Kompleksni(_re + k, _im);
	}
};

