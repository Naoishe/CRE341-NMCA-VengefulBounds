using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    string Name { get; }
    int Health { get; }

}
public class EnemyBase : MonoBehaviour, IEnemy
{
    readonly string Name = "Enemy_Goblin";

    readonly int Health = 2;

    string IEnemy.Name => throw new System.NotImplementedException();

    int IEnemy.Health => throw new System.NotImplementedException();
}
