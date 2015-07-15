using UnityEngine;
using System;
using System.Collections.Generic;

public class p : MonoBehaviour
{

	public Transform[] Points;
	public Transform[] enemiesInPath = new Transform[10];
	public enum LoopType{
		NoLoop, Loop
	}
	public LoopType Type = LoopType.NoLoop;

	public IEnumerator<Transform> GetPathEnumerator()
	{
		bool ended;
		if (Points == null || Points.Length < 1) {
			yield break;
				}
		var direction = 1;
		var index = 0;
		while (true)
		{
			if (Points.Length == 1){
				continue;
			}
			yield return Points[index];
			if(index <= 0)
			{
				direction = 1;
			}
			else if(index >= Points.Length - 1)
			{
				if(Type == LoopType.Loop){
				direction = -1;
				}else if(Type == LoopType.NoLoop){
					ended = true;
				break;
				}
			}
			index = index + direction;
		}
	}
	public void DitchPath(){
		currentEnemies--;
	}
	int currentEnemies;
	public void AddEnemy(Transform clone){
		enemiesInPath[currentEnemies] = clone;
		currentEnemies++;
	}

	public void OnDrawGizmos(){
		if (Points == null || Points.Length < 2) {
						return;
				}
	for(int i = 1; i < Points.Length; i++){
			Gizmos.DrawLine(Points[i-1].position, Points[i].position);
	}
		}
	}
