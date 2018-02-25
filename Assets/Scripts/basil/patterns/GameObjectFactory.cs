using System;
using UnityEngine;

namespace basil.patterns
{
    public struct ObjectFactory
    {
        private readonly bool _isObjectActive;
        private readonly Func<GameObject> _instantiator;

        public ObjectFactory(bool isObjectActive, Func<GameObject> instantiator)
        {
            _isObjectActive = isObjectActive;
            _instantiator = instantiator;
        }

        public bool IsObjectActive
        {
            get { return _isObjectActive; }
        }

        public Func<GameObject> Instantiator
        {
            get { return _instantiator; }
        }
    }

    public static class GameObjectFactory
    {
        //public static  Lazy<GameObject> EmptyInactivePrefab = new Lazy<GameObject>(() => (GameObject)Resources.Load("EmptyInactivePrefab"));

        public static ObjectFactory FactoryFromPrefab(GameObject prefab)
        {
            var isObjectActive = prefab.activeSelf;
            Func<GameObject> instantiator = () =>
            {
                // Turn off prefab
                prefab.SetActive(false);
                // Instantiate inactive GameObject so that Awake is not yet called
                var gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab);
                // Turn on prefab again
                prefab.SetActive(isObjectActive);

                return gameObject;
            };
            return new ObjectFactory(prefab.activeSelf, instantiator);
        }

        public static ObjectFactory Adapt(this ObjectFactory factory, Action<GameObject> adapter)
        {
            Func<GameObject> newInstantiator = () =>
            {
                var gameObject = factory.Instantiator();
                adapter(gameObject);
                return gameObject;
            };
            return new ObjectFactory(factory.IsObjectActive, newInstantiator);
        }

        public static GameObject InstantiateObject(this ObjectFactory factory)
        {
            var gameObject = factory.Instantiator();
            // Potentially activate the GameObject so that Awake is finally called
            gameObject.SetActive(factory.IsObjectActive);
            return gameObject;
        }

    }
}
