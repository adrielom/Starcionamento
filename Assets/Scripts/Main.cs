using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    public int width, height, offset;

    // Use this for initialization
    void Start () {
        Grid.Instance ().InstantianteGrid(width, height, offset);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
