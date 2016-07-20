using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    private static Grid instance = null;
    public GameObject element;
    

    public static Grid Instance () {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<Grid> ();

            if (instance == null) {
                GameObject container = new GameObject ("Grid");
                instance = container.AddComponent<Grid> ();
            }
        }

        return instance;
    }

    public void InstantianteGrid (int w, int h, int offset) {

        GameObject[,] gridArray = new GameObject[w,h];
        for (int i = 0; i < w; i++) {
            for (int j = 0; j < h; j++) {
                Instantiate (element, new Vector3(i,j,0) * offset, Quaternion.identity);
                gridArray [i, j] = element;
                gridArray[i, j].gameObject.tag = "Grid Element";
            }
        }
    }
}
