
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySystem : MonoBehaviour
{
	public static int gridSizeY = 5;
	public static int gridSizeX = 5;
	public float enemySize;
	[SerializeField] private RectTransform upRight;
	[SerializeField] private RectTransform downLeft;
	[SerializeField] private float enemySpeed;
	[SerializeField] private float updateRate;
	private Camera cam;
	bool isEntering = false;
	public GameObject[] enemys;
	bool Right = true;
	private Vector2 randomPosition;
	private Vector2 topRight;
	private Vector2 bottomLeft;
	private float timer = 0;
	public Vector2[,] grid = new Vector2[gridSizeY, gridSizeX];
	public GameObject[,] Enemygrid = new GameObject[gridSizeY,gridSizeX];
	public Vector3 target;
	private int realXSizde = 0;
	private int realYSize = 0;
	private void Start()
	{
		cam = Camera.main;
		topRight = cam.ScreenToWorldPoint(upRight.position);
		bottomLeft = cam.ScreenToWorldPoint(downLeft.position);
	}
	
	private void Update()
	{
		timer += Time.deltaTime;
		
		
		if (timer >= updateRate)
		{
			ChangeRandomTarget();
			timer = 0;
		}

		if (isEntering)
		{
			for (int i = 0; i < realYSize; i++)
			{
				for (int j = 0; j < realXSizde; j++)
				{
					if (Enemygrid[i, j] != null)
					{
						Enemygrid[i, j].transform.position = Vector2.MoveTowards(Enemygrid[i, j].transform.position, grid[i, j], Time.deltaTime * 5f);

						Vector3 viewPos = cam.WorldToViewportPoint(Enemygrid[i, j].transform.position);
						if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
						{
							Enemygrid[i,j].GetComponent<enemy>().SetCanFire(true);
						}
					}
				}
			}
			if (AllEnemiesReached())
			{
				isEntering = false;
			}
		}
		else
		{
			for (int i = 0; i < realYSize; i++)
			{	
				for (int j = 0; j < realXSizde; j++)
				{
					if (Enemygrid[i, j] != null)
					{
						Enemygrid[i, j].transform.position = Vector2.MoveTowards(Enemygrid[i, j].transform.position, target - Enemygrid[findFirstAlive()[0],findFirstAlive()[1]].transform.position + Enemygrid[i,j].transform.position ,
							Time.deltaTime * enemySpeed);
						if (Mathf.Abs(Enemygrid[i,j].transform.position.x - topRight.x) < 0.1f || Mathf.Abs(Enemygrid[i,j].transform.position.x - bottomLeft.x) < 0.1f ||
						    Mathf.Abs(Enemygrid[i,j].transform.position.y - topRight.y) < 0.1f)
						{
							ChangeRandomTarget();
						}
					}
					
				}
			}
		}
		
		if (isAllDead())
		{
			Generate();
			isEntering = true;
		}
	}


	

	public void Generate()
	{
		Array.Clear(grid, 0, grid.Length);
		Array.Clear(Enemygrid, 0, Enemygrid.Length);
		realXSizde = 0;
		realYSize = 0;
		float y = 0;
		float x = 0;
		randomPosition = new Vector2(Random.Range(bottomLeft.x , topRight.x ),
			Random.Range(bottomLeft.y , topRight.y ));
		for (int i = 0; i < gridSizeX; i++)
		{

			
			for (int j = 0; j < gridSizeY; j++)
			{


				if (!(randomPosition.x + x > topRight.x || randomPosition.y - y < bottomLeft.y) )
				{
					grid[i, j] = new Vector2(randomPosition.x + x, randomPosition.y - y);
					int randomIndex = Random.Range(0, enemys.Length);
					GameObject chosenEnemy = enemys[randomIndex];
					Vector2 randomposition = new Vector2(Random.Range(bottomLeft.x , topRight.x ), Random.Range(topRight.y+3 , topRight.y+5 ));
					GameObject e = Instantiate(chosenEnemy, randomposition, Quaternion.identity);
					Enemygrid[i, j] = e;
					e.transform.parent = this.transform;
					x += enemySize;
					realXSizde++;
				}
				   
					
				
				
				
			   
				
				
			}
			if (randomPosition.y - y >= bottomLeft.y)
			{
				realYSize++;
			}
			x = 0;
			y += enemySize;
			
		}

		realXSizde /= realYSize;
	}


	public void ChangeRandomTarget()
	{
		target = new Vector2(Random.Range(topRight.x , bottomLeft.x ), Random.Range(topRight.y , bottomLeft.y ));
	}


	private void OnDrawGizmos()
	{
		
		Gizmos.DrawSphere(bottomLeft, 0.5f);
		
		Gizmos.color = Color.red;
		for (int i = 0; i < realYSize; i++)
		{
			for (int j = 0; j < realXSizde; j++)
			{
				Gizmos.DrawSphere(grid[i, j], 0.1f);
			}
		}
	}

	private bool isAllDead()
	{
		for (int i = 0; i < gridSizeX; i++)
		{
			for (int j = 0; j < gridSizeY; j++)
			{
				if (Enemygrid[i,j]!=null&&Enemygrid[i, j].activeInHierarchy)
				{
					return false;
				}
			}
		}
		return true;
	}
	private bool AllEnemiesReached()
	{
		for (int i = 0; i < realYSize; i++)
		{
			for (int j = 0; j < realXSizde; j++)
			{
				if (Enemygrid[i, j] != null)
				{
					if (Vector2.Distance(Enemygrid[i, j].transform.position, grid[i, j]) > 0.05f)
					{
						return false;
					}
				}
			}
		}
		return true;
	}


	private int[] findFirstAlive()
	{
		int[] arr = new int[2];
		for (int i = 0; i < gridSizeX; i++)
		{
			for (int j = 0; j < gridSizeY; j++)
			{
				if (Enemygrid[i, j] != null)
				{
					arr[0] = i;
					arr[1] = j;
					return arr;
				}
					
			}
		}

		return null;
	}

}
