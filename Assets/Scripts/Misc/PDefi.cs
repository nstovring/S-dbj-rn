using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PDefi : MonoBehaviour {



		public Transform[] Points;
		
		public IEnumerator<Transform> GetPathsEnumerator()
		{
			throw NotImplementedException();
		}
		
		public void OnDrawGizmos()
		{
			if (Points == null || Points.Length < 2) 
			{
				return;
			}
			
			for (int i = 1; i < Points.Length; i++) 
			{
				Gizmos.DrawLine(Points[i-1].position, Points[i].position);
				
			}
		}
	}


