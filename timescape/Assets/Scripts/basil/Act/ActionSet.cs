
using UnityEngine;
using basil.patterns;
using basil.util;


namespace basil.Act
{

    public class ActionSet : BasicBehaviour
    {


        void OnUpdate()
        {

        }

        void Awake()
        {

        }

        void OnEnable()
        {
            if (dump) U.Log(gameObject.name + " ACTIVE" + gameObject.activeSelf);
        }

        void OnDisable()
        {
            if (dump) U.Log(gameObject.name + " ACTIVE" + gameObject.activeSelf);
        }

        public void explode()
        {
            transform.gameObject.SetActive(true);
            transform.localScale.Set(transform.localScale.x + 3, transform.localScale.y + 2, 1);
            transform.Translate(0, 1, 0);
        }

        public void implode()
        {
            gameObject.SetActive(true);
            transform.localScale.Set(transform.localScale.x - 3, transform.localScale.y - 2, 1);
            transform.Translate(0, -1, 0);
        }

    }
}