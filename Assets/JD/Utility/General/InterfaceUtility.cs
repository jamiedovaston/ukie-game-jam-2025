using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace JD.Utility.General
{
    public class InterfaceUtility : MonoBehaviour
    {
        /// <summary>
        /// Find an interface in scene.
        /// </summary>
        /// <typeparam name="T"> Interface trying to access.</typeparam>
        /// <param name="includeDisabled"> Include inactive interfaces.</param>
        /// <returns></returns>
        public static T FindObjectWithInterface<T>(bool includeDisabled = false) where T : class
        {
            GameObject[] allGameObjects = includeDisabled ? Resources.FindObjectsOfTypeAll<GameObject>() : GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject go in allGameObjects)
            {
                if (!includeDisabled && !go.activeInHierarchy)
                    continue;

                T component = go.GetComponent<T>();
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        /// <summary>
        /// Find interfaces in scene.
        /// </summary>
        /// <typeparam name="T"> Interface trying to access.</typeparam>
        /// <param name="includeDisabled"> Include inactive interfaces.</param>
        /// <returns></returns>
        public static List<T> FindObjectsWithInterface<T>(bool includeDisabled = false) where T : class
        {
            GameObject[] allGameObjects = includeDisabled ? Resources.FindObjectsOfTypeAll<GameObject>() : GameObject.FindObjectsOfType<GameObject>();
            List<T> all = new List<T>();

            foreach (GameObject go in allGameObjects)
            {
                if (!includeDisabled && !go.activeInHierarchy)
                    continue;

                T component = go.GetComponent<T>();
                if (component != null)
                {
                    all.Add(component);
                }
            }

            return all;
        }
    }
}
