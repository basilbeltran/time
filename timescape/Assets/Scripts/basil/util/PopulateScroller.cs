using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace basil.util
{
    public class PopulateScroller : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        [SerializeField]
        private GameObject buttonPrefab = null; // Assign button prefab in editor

        [SerializeField]
        private GameObject listContainer = null; // Assign Contents object in editor

        private List<GameObject> items; // initialise this and fill with content that will display in the scroller

        private void MakeScrollerButtons()
        {
            foreach (GameObject item in items)
            {
                // Create button and put it in the scroll rect
                GameObject button = Instantiate(buttonPrefab) as GameObject;
                button.transform.SetParent(listContainer.transform, false);

                // Customise the button with object from list
                GameObject captured = item;
                button.GetComponentInChildren<Text>().text = captured.GetInstanceID().ToString();
                //button.GetComponentInChildren<Text>().text = captured.name;

                button.GetComponent<Button>().onClick.AddListener(() => OnSelected(captured.GetInstanceID().ToString()));
            }
        }

        private void OnSelected(string name)
        {
            // What to do when button was clicked
            Debug.Log(name);
        }
    }
}