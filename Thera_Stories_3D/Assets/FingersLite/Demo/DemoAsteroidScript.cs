using UnityEngine;
using System.Collections;

namespace DigitalRubyShared
{
	public class DemoAsteroidScript : MonoBehaviour
	{
		private void Start ()
		{
		
		}

		private void Update ()
		{
			
		}

		private void OnBecameInvisible()
		{
			GameObject.Destroy(gameObject);
		}
	}
}