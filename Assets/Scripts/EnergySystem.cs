using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{


    // IF YOU NEED TO CHANGE THESE, GOTO PLAYER GAME OBJECT.
    private int maxCrystalAmount = 4; // max Crystal container hardcap
    public int startCrystals = 4;  // starting number of Crystal containers
    public int curEnergy; // its yo current energy
    private int maxEnergy; // current maximum energy (different from maxCrystal)
    private int energyPerCrystal = 4; // number of pieces in each Crystal (ours has 4)

    public Image[] energyImages;
    public Sprite[] energySprites;

    // Use this for initialization
    void Start()
    {
        curEnergy = startCrystals * energyPerCrystal; // number of health points is number of Crystal containters * pieces in each Crystal.
        maxEnergy = maxCrystalAmount * energyPerCrystal; // hardcap on how much hp you can have, based on a similar equation as above.
        CheckEnergyAmount();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeEDamage(-1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeEDamage(2);
        }
    }

    void CheckEnergyAmount()
    {
        // used to check at start of game, and whenever we want to modify things
        for (int i = 0; i < maxCrystalAmount; i++)
        {
            if (startCrystals <= i) // if we start with 4, but the max is 10, disable the images of the Crystals after 4.
            {
                energyImages[i].enabled = false;
            }
            else
            {
                energyImages[i].enabled = true;
            }
        }
        UpdateCrystals();
    }

    void UpdateCrystals() // update the Crystals yo
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in energyImages)
        {
            if (empty) // if its empty, draw the empty Crystal container
            {
                image.sprite = energySprites[0]; //  <= that is the EmptyCrystal image in player, represented as 0 in array.
            }
            else
            {
                i++;
                if (curEnergy >= i * energyPerCrystal)  // if current health is bigger than that equation, create the full Crystal image
                {
                    image.sprite = energySprites[energySprites.Length - 1];
                }
                else  // not full, but not empty Crystals.
                {
                    int currentCrystalHealth = (int)(energyPerCrystal - (energyPerCrystal * i - curEnergy));
                    int energyPerImage = energyPerCrystal / (energySprites.Length - 1);  // How many images our Crystals are representing.
                    int imageIndex = currentCrystalHealth / energyPerImage;  // represent the Crystal that is actually shown
                    image.sprite = energySprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeEDamage(int amount) // used to update the hp system when taken damage
    {
        curEnergy += amount;
        curEnergy = Mathf.Clamp(curEnergy, 0, startCrystals * energyPerCrystal); // keeps health between 0 and max allowed
        UpdateCrystals(); // after we do this, update the images please.

    }

    public void AddCrystalContainer() // increasing max Crystals; currently not really possible.
    {
        startCrystals++; // Crystal plus one now
        startCrystals = Mathf.Clamp(startCrystals, 0, maxCrystalAmount); // no going over the hard limit!

        // below is for refilling hp when collecting a new Crystal container
        //curEnergy = startCrystals * energyPerCrystal;
        //maxEnergy = maxCrystalAmount * energyPerCrystal;


        CheckEnergyAmount(); // refresh the images
    }
}
