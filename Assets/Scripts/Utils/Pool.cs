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
        [SerializeField] GameObject baseElement;
        [SerializeField] int initialSize;

        List<GameObject> elements;

        private void Start()
        {
            CreateElements(initialSize);
        }

        /// <summary>
        /// Gets a element from the pool. If no one is available, it creates a new serie of elements
        /// </summary>
        /// <returns></returns>
        public GameObject GetFromPool()
        {
            int i = 0;

            for (; i < elements.Count && elements[i].activeSelf; ++i)
            { }

            if (i >= elements.Count) CreateElements(initialSize);

            elements[i].SetActive(true);
            return elements[i];
        }

        /// <summary>
        /// Creates a given number of elements
        /// </summary>
        /// <param name="size"></param>
        private void CreateElements(int size)
        {
            int i = 0;

            while (i < size)
            {
                GameObject go = Instantiate(baseElement, transform);
                go.SetActive(false);

                --i;
            }
        }

        /// <summary>
        /// Sends a element to the pool and deactives it
        /// </summary>
        /// <param name="element"></param>
        public void SendToPool(GameObject element)
        {
            element.SetActive(false);
            element.transform.position = Vector3.zero;
        }

        public List<GameObject> GetElements() => elements;
    }
}
