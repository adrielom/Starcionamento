using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    private static Main instance = null;

    public static Main Instance () {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<Main> ();
        }
        return instance;
    }

    public int width, height, offset;

    void Start () {
        Grid.Instance ().InstantianteGrid(width, height, offset);
    }

}
