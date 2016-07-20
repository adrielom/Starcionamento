using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]
[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Rigidbody2D))]

public class MouseDrag : MonoBehaviour {

    
    Vector3 screenPoint, offset, scanPos, curPosition, curScreenPoint;
    public float gridSize, gridX, gridY;
    public bool inGrig;

    void Start () {
        inGrig = false;
        gridX = Main.Instance ().width - 1;
        gridY = Main.Instance ().height - 1;
        this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
        this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
    }

    void Update () {
        if (inGrig) {
            KeepInsideGrid ();
        }
    }

    public void KeepInsideGrid () {
        if (this.gameObject.transform.position.x > gridX) {
            this.gameObject.transform.position = new Vector2 (gridX, transform.position.y);
        }
        if (this.gameObject.transform.position.x < 0) {
            this.gameObject.transform.position = new Vector2 (0, transform.position.y);
        }
        if (this.gameObject.transform.position.y > gridY) {
            this.gameObject.transform.position = new Vector2 (transform.position.x, gridY);
        }
        if (this.gameObject.transform.position.y < 0) {
            this.gameObject.transform.position = new Vector2 (transform.position.x, 0);
        }
    }

    void OnMouseDown () {
        scanPos = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint (scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        GameObject.Find ("GridCollider").GetComponent<Collider2D> ().enabled = true;

    }

    void OnMouseUp () {
        GameObject.Find ("GridCollider").GetComponent<Collider2D>().enabled = false;
    }

    void OnMouseDrag () {

        curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;

        curPosition.x = (int)(Mathf.Round (curPosition.x) * gridSize);
        curPosition.y = (int)(Mathf.Round (curPosition.y) * gridSize);
        transform.position = curPosition;
        
    }


}
