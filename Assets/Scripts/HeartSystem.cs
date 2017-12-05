using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour {

    // If you want to use this to take damage, follow these steps:
    // 1) paste this with your variables:  private HeartSystem heartSystem;
    // 2) in the part where you want the person to take damage, type: heartSystem.TakeDamage();
    // 3) Put in the number (-1 for -1 health, 1 for +1 health, etc.)
    // 4) keep in mind with 4 heart containers, the max health int is 16.
    // use the EnergySystem versions of all that for energy equivalents.


    // IF YOU NEED TO CHANGE THESE, GOTO PLAYER GAME OBJECT.
    private int maxHeartAmount = 4; // max heart container hardcap
    public int startHearts = 4;  // starting number of heart containers
    public int curHealth; // its yo current health
    private int maxHealth; // current maximum health (different from maxHeart)
    private int healthPerHeart = 4; // number of pieces in each heart (ours has 4)

    public Image[] healthImages;
    public Sprite[] healthSprites;
    
	// Use this for initialization
	void Start ()
    {
        InitHP();
        CheckHealthAmount();
    }
    public void InitHP()
    {
        curHealth = startHearts * healthPerHeart; // number of health points is number of heart containters * pieces in each heart.
        maxHealth = maxHeartAmount * healthPerHeart; // hardcap on how much hp you can have, based on a similar equation as above.
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(-1);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(2);
        }*/
    }

    void CheckHealthAmount()
    {
        // used to check at start of game, and whenever we want to modify things
        for(int i = 0; i <maxHeartAmount; i++)
        {
            if(startHearts <= i) // if we start with 4, but the max is 10, disable the images of the hearts after 4.
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts() // update the hearts yo
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty) // if its empty, draw the empty heart container
            {
                image.sprite = healthSprites[0]; //  <= that is the EmptyHeart image in player, represented as 0 in array.
            }
            else
            {
                i++;
                if (curHealth >= i * healthPerHeart)  // if current health is bigger than that equation, create the full heart image
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else  // not full, but not empty hearts.
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);  // How many images our hearts are representing.
                    int imageIndex = currentHeartHealth / healthPerImage;  // represent the heart that is actually shown
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeDamage (int amount) // used to update the hp system when taken damage
    {
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, startHearts * healthPerHeart); // keeps health between 0 and max allowed
        UpdateHearts(); // after we do this, update the images please.
    }

    public void AddHeartContainer () // increasing max hearts; currently not really possible.
    {
        startHearts++; // heart plus one now
        startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount); // no going over the hard limit!

        // below is for refilling hp when collecting a new heart container
        //curHealth = startHearts * healthPerHeart;
        //maxHealth = maxHeartAmount * healthPerHeart;


        CheckHealthAmount(); // refresh the images
    }
}
