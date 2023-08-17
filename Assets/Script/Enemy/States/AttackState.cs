using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public int minMoveTime = 3;
    public int maxMoveTime = 7;
    public float losePlayerTime = 5f;
    public float shotTime = 1f;

    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {
        shotTimer = shotTime;
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            enemy.transform.LookAt(enemy.player.transform);

            if (shotTimer > shotTime) Shoot();
            if (moveTimer > Random.Range(minMoveTime, maxMoveTime))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > losePlayerTime)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        if (enemy.gun != null && enemy.gun.TryGetComponent<GunItem>(out var currentGun))
        {
            currentGun.Shoot(enemy.transform);
            shotTimer = 0;
        }
    }
}
