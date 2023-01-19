using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI apetiteValue;
    private Animals pigRef;
    private Animals cowRef;
    private Animals selected = null;
    public Camera GameCamera;
    [SerializeField] Image selectionImage;


    // Start is called before the first frame update
    void Start()
    {
        pigRef = GameObject.Find("Pig").GetComponent<Animals>();
        cowRef = GameObject.Find("Cow").GetComponent<Animals>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            SelectAnimal();
        }
    }

    public void FeedButtonClicked()
    {
        GetRef(selected);
        selected.maxFeed = selected.feedCycle;
        UpdateLabels();
    }

    //ABSTRACTION - this method is used in the Start() Method, as well as in every methods that change a value in the Animals class
    public void UpdateLabels()
    {
        if (selected != null)
        {
            apetiteValue.text = selected.maxFeed.ToString();
        }
    }

    public void SelectAnimal()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var animal = hit.collider.GetComponent<Animals>();
            selected = animal;
            selectionImage.color = animal.GetComponent<Renderer>().material.GetColor("_Color");

            UpdateLabels();
        }
    }
    private Animals GetRef(Animals animalsRef)
    {
        if (selected.gameObject.name == "Pig")
        {
            animalsRef = pigRef;

        }
        else if (selected.gameObject.name == "Cow")
        {
            animalsRef = cowRef;
        }
        return animalsRef;
    }
}
