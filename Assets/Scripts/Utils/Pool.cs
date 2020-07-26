using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Garden
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] GameObject[] plantPrefabs;
        [SerializeField] int initialSize;

        List<GameObject> elements = new List<GameObject>();

        private void Start()
        {
            CreateElements(initialSize, 0);
        }

        /// <summary>
        /// Gets a element from the pool. If no one is available, it creates a new serie of elements
        /// </summary>
        /// <returns></returns>
        public GameObject GetFromPool(string type)
        {
            int i = 0;

            for (; i < elements.Count && elements[i].activeSelf; ++i)
            { }

            int plantIndex = GetPlantIndex(type);

            if (i >= elements.Count) CreateElements(initialSize, plantIndex);

            elements[i].SetActive(true);
            SpriteRenderer sp = elements[i].GetComponent<SpriteRenderer>();
            sp = plantPrefabs[plantIndex].GetComponent<SpriteRenderer>();

            Plant p = elements[i].GetComponent<Plant>();

            p.SetPlantType(type);
            // //Maybe we need to call restart to the plant attributes 
            //p.Start();
            p.RestartPlantState(type);

            return elements[i];
        }

        private int GetPlantIndex(string type)
        {
            switch (type)
            {
                case "Quintana quinae": return 0;  
                case "Sutcac siuquis": return 1; 
                case "Auch auchus": return 2; 
                case "Triqui tricae": return 3; 
                case "Alejandro alejandrus": return 4; 
                case "Siquis siqus": return 5; 
                case "Moru morus": return 6; 
                case "Sequa sacus": return 7; 

                default: return -1;
            }
        }

        /// <summary>
        /// Creates a given number of elements
        /// </summary>
        /// <param name="size"></param>
        private void CreateElements(int size, int typeID)
        {
            int i = 0;

            while (i < size)
            {
                GameObject go = Instantiate(plantPrefabs[typeID], transform);
                go.SetActive(true);
                go.GetComponent<Plant>().Awake();
                go.SetActive(false);
                elements.Add(go);
                ++i;
            }
        }

        /// <summary>
        /// Sends a element to the pool and deactives it
        /// </summary>
        /// <param name="element"></param>
        public void SendToPool(GameObject element)
        {
            element.SetActive(false);
            element.transform.parent = this.transform;
            element.transform.position = Vector3.zero;
        }

        public List<GameObject> GetElements() => elements;


    }
}
