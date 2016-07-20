using UnityEngine;
using System.Collections;

public class GridCollider : MonoBehaviour {

    float width, height;

    void Start () {
       width = Main.Instance ().width;
       height = Main.Instance ().height;

        SettingScale ();
        MidPoints ();
    }

    public void SettingScale () {
        gameObject.transform.localScale = new Vector2 (width, height);
    }

    public void MidPoints () {
        width = width / 2 - .5f;
        height = height / 2 - .5f;
    }
	
	void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Ship") {
            other.gameObject.GetComponent<MouseDrag> ().inGrig = true;
            other.gameObject.GetComponent<ShipManager> ().enabled = true;
        }
    }
}
