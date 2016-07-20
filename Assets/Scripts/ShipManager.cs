using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum shipSize { small = 1, medium = 2, large = 3 };

[RequireComponent (typeof(MouseDrag))]


public class ShipManager : MonoBehaviour{

    public shipSize size;
    public float destructionTime { get; set; }
    public float instantiationTime { get; set; }
    public GameObject canvas, timerHud;
    public float timer;
    bool inGrid, timerGo;
    public Sprite timerHudImage;

    public void SettingShipSize () {
        switch (size) {
            case shipSize.small:
                gameObject.transform.localScale = new Vector2 (1, 1);
            break;
            case shipSize.medium:
                gameObject.transform.localScale = new Vector2 (2, 2);
            break;
            case shipSize.large:
                gameObject.transform.localScale = new Vector2 (4, 4);
            break;
        }
    }

    public void TimerOverShip () {
         
    }
 
    public void SettingShipPositionInGrid () {
        switch (size) {
            case shipSize.small:
                PositionBoundries (0, Main.Instance ().width, Main.Instance ().height, 0);
            break;
            case shipSize.medium:
                PositionBoundries (1, Main.Instance ().width - 2, Main.Instance ().height - 2, 1);  
            break;
            case shipSize.large:
                PositionBoundries (2, Main.Instance ().width - 3, Main.Instance ().height - 3, 2);
            break;
        }
    }

    public void PositionBoundries (float l, float r, float u, float d) {
        if (gameObject.transform.position.x > r) {
            gameObject.transform.position = new Vector2 (r, transform.position.y);
        }
        if (gameObject.transform.position.x < l) {
            gameObject.transform.position = new Vector2 (l, transform.position.y);
        }
        if (gameObject.transform.position.y > u) {
            gameObject.transform.position = new Vector2 (transform.position.x, u);
        }
        if (gameObject.transform.position.y < d) {
            gameObject.transform.position = new Vector2 (transform.position.x, d);
        }
    }

    void Start () {
        inGrid = gameObject.GetComponent<MouseDrag> ().inGrig;
        timerHud.GetComponent<Image>().fillAmount = timer;
        timerGo = true;
    }

    public void Timer () {
        timerGo = false;
        timer -= Time.deltaTime; 
        if (timer > 0) {
            timerHud.GetComponent<Image> ().fillAmount -= timer / 10;
        }
        else {
            print ("Game Over");
        }
    }

    public void CreateTimerHud () {
        GameObject image = (GameObject)Instantiate (timerHud);
        image.transform.SetParent (canvas.transform);
        image.GetComponent<RectTransform> ().anchoredPosition = gameObject.transform.position;
        image.GetComponent<RectTransform> ().localScale = Vector3.one;
    }

    void Update () {
        SettingShipSize ();
        SettingShipPositionInGrid ();
        if (inGrid && timerGo) {
            CreateTimerHud ();
            Timer ();
        }
    }
}
