
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAlongLine : MonoBehaviour
{

    [SerializeField]
    private GameObject placeholderG;

    [SerializeField]
    private GameObject placeholderA;

    [SerializeField]
    private GameObject placeholderC;

    [SerializeField]
    private GameObject placeholderU;

    [SerializeField]
    private int numberOfGenes;

    private GameObject[] placeholders;

    private string[] letters; 

    float x0, deltaX;

    void Start() {
        placeholders = new GameObject[] {placeholderG, placeholderA, placeholderC, placeholderU, 
        placeholderG, placeholderC, placeholderC, placeholderU, placeholderA, placeholderG, placeholderU,
        placeholderC, placeholderG, placeholderG, placeholderC, placeholderG, placeholderU, placeholderU,
        placeholderC};
        letters = new string[] {"G0", "A0", "C0", "U0", "G1", "C1", "C2", "U1", "A1", "G2", "U2",
        "C3", "G3", "G4", "C4", "G5", "U2", "U3", "C5"};
        x0 = transform.position.x;
        deltaX = 0.2f;
        //x-0.27f y-0.1f deltaX 0.08f for ios
        placeholders[0].transform.position = new Vector3(gameObject.transform.position.x-0.65f,
        gameObject.transform.position.y-0.5f, 0);    
        numberOfGenes = 5;    
    }


    void Update () {
        for (int i = 0; i < placeholders.Length; i++)
        {
            GameObject go = GameObject.FindGameObjectWithTag(letters[i]);
            DragToPlaceholder d = go.GetComponent<DragToPlaceholder>();
            bool onPlace = d.OnPlace();
            if (onPlace)
            {
                if (gameObject.transform.position.x < x0 + (i+1)*deltaX) {     
                    transform.position = new Vector3(transform.position.x + 0.005f, transform.position.y, transform.position.z);
                    placeholders[i].transform.position = new Vector3(0, 0, 0);
                    placeholders[i+1].transform.position = new Vector3(gameObject.transform.position.x-0.65f, 
                    gameObject.transform.position.y-0.5f, 0);  
                    if (i == numberOfGenes)
                    {
                        Destroy(GameObject.Find("Text"));
//                        SceneManager.LoadScene("TranslaatioScene");
                        GameObject gobj = GameObject.Find("arrow_right2");
                        gobj.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            } else {
                break;
            }       
        }
    }
}