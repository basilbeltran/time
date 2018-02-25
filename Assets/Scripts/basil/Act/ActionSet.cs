
using UnityEngine;
using basil.util;

public class ActionSet : BasicBehaviour
{
    SecondFormBe sfb;


    void OnUpdate()
    {

    }

    void Awake()
    {
        sfb = GetComponent<SecondFormBe>();

    }

    void OnEnable()
    {
        if (dump) U.Log(gameObject.name + " ACTIVE" +gameObject.activeSelf);
    }

    void OnDisable()
    {
        if (dump)  U.Log(gameObject.name + " ACTIVE" + gameObject.activeSelf);
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