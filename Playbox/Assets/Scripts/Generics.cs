using UnityEngine;
using System.Collections;

public class Generics : MonoBehaviour {

	// Very similar to templates to C++, I think.
	// To add contraints to this generic, type in after 
	// the (). 
	// e.g. public T blah<t> (T param) where T : <data types separated by commas>
	// The 4 data types are class, struct, new(), <some type of interface>
	// new() is a public constructor with no parameters
	public T GenericMethod<T> (T param)
	{
		return param;
	}
}
