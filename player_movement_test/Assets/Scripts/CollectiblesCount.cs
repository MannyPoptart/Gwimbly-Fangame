using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesCount : MonoBehaviour
{

    TMPro.TMP_Text text;
    int count = 0;
    // Start is called before the first frame update
    void Awake() {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() {
        UpdateCount();
    }

    void OnEnable() {
        Collectible.OnCollected += HandleCollected;
    }

    void OnDisable() {
        Collectible.OnCollected -= HandleCollected;
    }

    void HandleCollected() {
        count++;
        UpdateCount();
    }

    void UpdateCount() {
        text.text = $"{count}";
    }
}
