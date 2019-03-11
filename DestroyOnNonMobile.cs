using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNonMobile : MonoBehaviour {

	// Use this for initialization
	#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
	void Start () {
		Destroy(this.gameObject);
	}
	#endif
}
