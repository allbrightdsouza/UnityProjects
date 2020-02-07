using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public GameObject heart;
    private GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    // Update is called once per frame
    void InitHearts()
    {
        hearts = new GameObject[(int)heartContainers.initialValue];

        for (int i = 0; i < heartContainers.RuntimeValue; i++) {
            hearts[i] = Instantiate(heart,Vector2.zero,Quaternion.identity);
            hearts[i].transform.SetParent(this.transform);
        }
    }

    public void UpdateHearts() {
        float numhearts = playerHealth.RuntimeValue/2.0f;
        
        for(int i = 0; i < heartContainers.RuntimeValue; i++) {
            Image heartImage = hearts[i].GetComponent<Image> ();
            if(numhearts > 0.5f ) {
                heartImage.sprite = fullHeart;
            } else if (numhearts == 0.5f) {
                heartImage.sprite = halfHeart;
            } else {
                heartImage.sprite = emptyHeart;
            }
            numhearts--;
        }
    }
}
