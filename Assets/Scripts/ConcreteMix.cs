
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ConcreteMix : MonoBehaviour
{
    [SerializeField] private GameObject concreteMix; // The cube game object to be expanded
    public float expandTime = 2f; // The time it takes for the cube to expand

    [SerializeField] private Text cementUIText;
    [SerializeField] private Slider cementSlider;

    [SerializeField] private Text gravelUIText;
    [SerializeField] private Slider gravelSlider;

    [SerializeField] private Text waterUIText;
    [SerializeField] private Slider waterSlider;

    public UnityEvent onConcreteMixCompleted;
    public UnityEvent onConcreteMixValidated;

    // Start is called before the first frame update
    void Start()
    {
        //set slider val to output string
   
    }

    private void UpdateUI()
    {
        cementUIText.text = cementSlider.value.ToString();
        gravelUIText.text = gravelSlider.value.ToString();
        waterUIText.text = waterSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

    }

    /// <summary>
    /// Validates the mix of cement, gravel, and water.
    /// </summary>
    /// <returns>True if the mix is valid, false otherwise.</returns>
    public bool ValidateMix()
    {
        return cementSlider.value == 3 && waterSlider.value == 3 && gravelSlider.value == 2;
    }

    /// <summary>
    /// Starts the ExpandCubeCoroutine if the mix is valid.
    /// </summary>
    public void ExpandCube()
    {
        if (ValidateMix())
        {
            Debug.Log("Mix Validated... Pouring Concrete Mix!");

            onConcreteMixValidated.Invoke();

            //start mixer sound
            //delay couroutine for x secs
        
            StartCoroutine(ExpandCubeCoroutine());
        }
        else
        {
            Debug.Log("Incorrect Mix Ratio... Try again!");
        }
    }

    /// <summary>
    /// Coroutine to expand the cube in the vertical direction.
    /// </summary>
    private IEnumerator ExpandCubeCoroutine()
    {
        Vector3 initialScale = concreteMix.transform.localScale; // The initial scale of the cube
        Vector3 targetScale = new Vector3(initialScale.x, initialScale.y * 100, initialScale.z);

        float elapsedTime = 0f;
        while (elapsedTime < expandTime)
        {
            concreteMix.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / expandTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        concreteMix.transform.localScale = targetScale;

        onConcreteMixCompleted.Invoke();
    }
}