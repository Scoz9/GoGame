using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour, IMovable
{
    protected float speed;
    protected float range;
    protected int dir;
    protected float startingPosition;

    public virtual void Move() { }
}
