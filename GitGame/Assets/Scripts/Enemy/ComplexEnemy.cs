using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour, IMovable, IDamageable<int>
{
    protected Transform target;
    public int hp;
    public Slider healthBar;

    public virtual void Move() { }
    public virtual void takeDamage(int damageTaken) { }

}
