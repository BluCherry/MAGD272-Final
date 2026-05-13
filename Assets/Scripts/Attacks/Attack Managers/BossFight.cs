using UnityEngine;

public class BossFight : MonoBehaviour
{
    private GameObject target;
    private ShootAllDirection shoot;
    private TimedSpawner spawn;

    [SerializeField]
    float agroDistance = 10f;

    bool isAgro = false;

    private void Start()
    {
        target = GameObject.Find("Player");
        shoot = GetComponent<ShootAllDirection>();
        spawn = GetComponent<TimedSpawner>();
        shoot.enabled = false;
        spawn.enabled = false;
    }

    void Update()
    {
        if (!isAgro && (target.transform.position - transform.position).magnitude <= agroDistance)
        {
            isAgro = true;
            ActivateFight();
        }
    }

    void ActivateFight()
    {
        shoot.enabled = true;
        spawn.enabled = true;
    }
}
