using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnGO : MonoBehaviour
{
    [Inject] private DiContainer container;

    [SerializeField] 
    private GameObject go;

    // Start is called before the first frame update
    void Awake()
    {
        if(go.tag == "Enemy")
        {
            ZenjectInstantiate();
        }
        else
        {
            CommomInstantiate();
        }
    }

    private void CommomInstantiate()
    {
        Instantiate(go, transform.position, transform.rotation);
    }

    private void ZenjectInstantiate()
    {
        GameObject newEnemy = Instantiate(go, transform.position, transform.rotation);

        container.InjectGameObject(newEnemy);
    }
}
