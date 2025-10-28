![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/1.PNG)
```csharp
// Enemy
Vector3 movment;
float timeDestroy = 4;

void Start()
    {
        movment = transform.position;
    }
    
void Update()
    {
	    movment.x -= 2 * Time.deltaTime;
        transform.position = movment;
        timeDestroy -= Time.deltaTime;
        
        if(timeDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
```
---
![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/2.PNG)
```csharp
// Enemy
void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("nowScore", PlayerPrefs.GetInt("nowScore")+1);
        }
    }
```
---
![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/4.PNG)
```csharp
// Game
public Transform markUp;
public Transform markDown;

public GameObject enemy;

Vector3 enemyPos;
float rnd;
float t = 2f;

void Start()
    {
        enemyPos.x = markUp.position.x;
    }

void Update()
    {
        t -= Time.deltaTime;

        if(t <= 0)
        {
            enemyPos.y = 
            Random.Range( markUp.position.y, markDown.position.y);

            Instantiate(enemy,enemyPos,Quaternion.identity);
            t = 2f;
        }
    }
```
---
![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/5.PNG)
```csharp
// Menu
public TextMeshProUGUI tmp;

void Awake()
    {
        Time.timeScale = 1;
        tmp.text = 
        "High Score : "+ PlayerPrefs.GetInt("highScore").ToString();
    }

public void play()
    {
        SceneManager.LoadScene(1);
    }
```
---
![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/6.PNG)
```csharp
// PlayerController
public Rigidbody2D rb;
public float speed;

Vector2 movement;
bool isJump = false;

void Awake()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("nowScore", 0);
    }

public void touched()
    {
        isJump = true;
    }

void FixedUpdate()
    {
        movement.y = speed;
        
        if(isJump)
        {  
            rb.velocity = movement;
            isJump = false;
        }
    }

void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            StartCoroutine(waitEnd());
        }
    }

IEnumerator waitEnd()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }
```
---
![](https://github.com/Poyamohamadi/HappyGhost/blob/main/image/7.PNG)
```csharp
// Score
public TextMeshProUGUI tmp;

void Update()
    {
        tmp.text = PlayerPrefs.GetInt("nowScore").ToString();
        
        if(PlayerPrefs.GetInt("highScore") < PlayerPrefs.GetInt("nowScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("nowScore"));
        }
    }
```
