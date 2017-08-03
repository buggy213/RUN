using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BiomeSelect : MonoBehaviour {

    [System.Serializable]
    public struct Biome
    {
        public Sprite sprite;
        public string name;
        public string sceneName;
    }

    public Biome[] biomes;

    public Image left;
    public Image right;
    public Image middle;
    public Text text;

    public Button button;

    public MainMenu menuScript;

    int index;

	// Use this for initialization
	void Start ()
    {
	    if (biomes.Length == 0)
        {
            Debug.LogError("No biomes present");
        }
        else
        {
            UpdateVisual();
        }
	}
	
	void UpdateVisual()
    {
        int leftBiomeIndex = ArrayModulo(-1);
        int rightBiomeIndex = ArrayModulo(1);

        left.sprite = biomes[leftBiomeIndex].sprite;
        right.sprite = biomes[rightBiomeIndex].sprite;
        middle.sprite = biomes[index].sprite;
        text.text = biomes[index].name;

        button.onClick.AddListener(delegate { LoadSceneString(biomes[index].sceneName); });
    }

    void LoadSceneString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public int ArrayModulo(int offset)
    {
        int test = index + offset;
        if (test >= biomes.Length)
        {
            return test % biomes.Length;
        }
        else if (test < 0)
        {
            return biomes.Length + test;
        }

        return test;
    }

    public void Advance(bool forward)
    {
        index += forward ? 1 : -1;
        index = ArrayModulo(0);
        UpdateVisual();
    }
}
