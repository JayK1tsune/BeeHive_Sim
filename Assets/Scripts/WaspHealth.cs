using UnityEngine;
//simple health script for wasps that can be used for other enemies as well if needed
public class WaspHealth : MonoBehaviour
{
    [SerializeField]
    private int _healthpoints;


    public bool TakeHit()
    {
        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) Die();
        return isDead;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
