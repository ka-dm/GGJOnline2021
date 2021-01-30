using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedNumberDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI seedNumbers;
    // Start is called before the first frame update
    void Start()
    {
        PlantSeedAction.updateSeedNumber += UpdateSeedNumber;
    }

    private void OnDestroy()
    {
        PlantSeedAction.updateSeedNumber -= UpdateSeedNumber;
    }

    public void UpdateSeedNumber(int num)
    {
        seedNumbers.text = string.Format("x{0}", num);
    }


}
