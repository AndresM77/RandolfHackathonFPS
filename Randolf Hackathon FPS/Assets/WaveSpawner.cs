using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum spawnState {SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave 
	{
		public string name;
		public int count;
		public Transform enemy;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public float timeBetweenWaves = 5;
	public float waveCountdown = 0;

	private spawnState state = spawnState.COUNTING;

	private float searchCountdown = 1f;

	void Start() 
	{
		waveCountdown = timeBetweenWaves;

	}

	void Update() 
	{
		if (state == spawnState.WAITING) 
		{
			//check if enemies are still alive
			if (!EnemyIsAlive ()) 
			{
				//Begin a new round
				Debug.Log("Wave Completed");

			} else {
				return;
			}

		}
			
		if (waveCountdown <= 0) 
		{
			if (state != spawnState.SPAWNING) 
			{
				//start spawning wave
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		} else 
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	bool EnemyIsAlive() 
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f) 
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null) 
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave) 
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		//spawning
		state = spawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++) 
		{
			SpawnEnemy (_wave.enemy);
			yield return new WaitForSeconds(1f/_wave.rate);
		}
		//waiting
		state = spawnState.WAITING;
		yield break;
	}

	void SpawnEnemy (Transform _enemy) 
	{
		//spawning enemy
		Instantiate(_enemy, transform.position, transform.rotation);
		Debug.Log("Spawning enemy: " + _enemy.name);
	}

}
