using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private GameObject loliprefab;
    [SerializeField] private GameObject loliconprefab;
    [SerializeField] private int minLolipopCount;
    [SerializeField] private int maxLolipopCount;
    [SerializeField] private Color ActiveColor;
    [SerializeField] private Color DisableColor;
    [SerializeField] private Vector2 iconposition;
    private List<GameObject> lolipopiconlist = new List<GameObject>();
    private List<GameObject> lolipoplist = new List<GameObject>();
    private int index = 0;

    private void Start()
    {
        int lolicount = Random.Range(minLolipopCount, maxLolipopCount + 1);
        CreateLolipop(lolicount);
        lolipopiconposition(lolicount);
    }

    private void CreateLolipop(int lolicount)
    {
        for(int i = 0; i < lolicount; i++)
        {
            GameObject newlolipop = Instantiate(loliprefab, transform.position, Quaternion.identity);
            newlolipop.SetActive(false);
            lolipoplist.Add(newlolipop);
        }
        lolipoplist[0].SetActive(true);
    }

    private void lolipopiconposition(int lolicount)
    {
        for(int i = 0; i < lolicount; i++)
        {
            GameObject newicon = Instantiate(loliconprefab, iconposition, loliconprefab.transform.rotation);
            newicon.GetComponent<SpriteRenderer>().color = ActiveColor;
            iconposition.y += 0.5f;
            lolipopiconlist.Add(newicon);
        }
    }

    public void SetActiveLolipop()
    {
        if (index < lolipoplist.Count - 1)
        {
            index++;
            lolipoplist[index].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    public void SetDisableLolipop()
    {
        lolipopiconlist[(lolipopiconlist.Count - 1) - index].GetComponent<SpriteRenderer>().color = DisableColor;
    }
}
