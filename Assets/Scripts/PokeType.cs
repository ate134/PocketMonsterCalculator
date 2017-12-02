using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// I acknowledge that all the code in one place can be bad. This is not a project that I 
//    intend to need to touch afterwards with complexity.
public class PokeType : MonoBehaviour {

    private List<string> zeroList;
    private List<string> quarterList;
    private List<string> halfList;
    private List<string> normalList;
    private List<string> effectiveList;
    private List<string> superEffectiveList;

    public Text zeroText;
    public Text quarterText;
    public Text halfText;
    public Text normalText;
    public Text effectiveText;
    public Text superEffectiveText;

    public bool dualMode = false;
    public Button dualButton;
    public Text dualText;
    private string dualType1 = "";
    private string dualType2 = "";
    public Text dualTypesText;
    public Toggle toggle;

    private bool offensiveBool = true;
    public Text offDefText;

    //private int row;

    float[,] pokeType = new float[18, 18] { //The master list of comparing all the types against other types (Dont want to redo this ever) [GEN 6]

     //               Norma,Fight,Flyin,Poiso,Groun,Rock , Bug ,Ghost,Steel,Fire ,Water,Grass,Elect,Psych, Ice ,Drago,Dark ,Fairy
     /*NORMAL   */   {  1  ,  1  ,  1  ,  1  ,  1  , .5f ,  1  ,  0  , .5f ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  },
     /*FIGHTING */   {  2  ,  1  , .5f , .5f ,  1  ,  2  , .5f ,  0  ,  2  ,  1  ,  1  ,  1  ,  1  , .5f ,  2  ,  1  ,  2  , .5f },
     /*FLYING   */   {  1  ,  2  ,  1  ,  1  ,  1  , .5f ,  2  ,  1  , .5f ,  1  ,  1  ,  2  , .5f ,  1  ,  1  ,  1  ,  1  ,  1  },
     /*POISON   */   {  1  ,  1  ,  1  , .5f , .5f , .5f ,  1  , .5f ,  0  ,  1  ,  1  ,  2  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  },
     /*GROUND   */   {  1  ,  1  ,  0  ,  2  ,  1  ,  2  , .5f ,  1  ,  2  ,  2  ,  1  , .5f ,  2  ,  1  ,  1  ,  1  ,  1  ,  1  },
     /*ROCK     */   {  1  , .5f ,  2  ,  1  , .5f ,  1  ,  2  ,  1  , .5f ,  2  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  ,  1  },
     /*BUG      */   {  1  , .5f , .5f , .5f ,  1  ,  1  ,  1  , .5f , .5f , .5f ,  1  ,  2  ,  1  ,  2  ,  1  ,  1  ,  2  , .5f },
     /*GHOST    */   {  0  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  , .5f ,  1  },
     /*STEEL    */   {  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  , .5f , .5f , .5f ,  1  , .5f ,  1  ,  2  ,  1  ,  1  ,  2  },
     /*FIRE     */   {  1  ,  1  ,  1  ,  1  ,  1  , .5f ,  2  ,  1  ,  2  , .5f , .5f ,  2  ,  1  ,  1  ,  2  , .5f ,  1  ,  1  },
     /*WATER    */   {  1  ,  1  ,  1  ,  1  ,  2  ,  2  ,  1  ,  1  ,  1  ,  2  , .5f , .5f ,  1  ,  1  ,  1  , .5f ,  1  ,  1  },
     /*GRASS    */   {  1  ,  1  , .5f , .5f ,  2  ,  2  , .5f ,  1  , .5f , .5f ,  2  , .5f ,  1  ,  1  ,  1  , .5f ,  1  ,  1  },
     /*ELECTRIC */   {  1  ,  1  ,  2  ,  1  ,  0  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  , .5f , .5f ,  1  ,  1  , .5f ,  1  ,  1  },
     /*PSYCHIC  */   {  1  ,  2  ,  1  ,  2  ,  1  ,  1  ,  1  ,  1  , .5f ,  1  ,  1  ,  1  ,  1  , .5f ,  1  ,  1  ,  0  ,  1  },
     /*ICE      */   {  1  ,  1  ,  2  ,  1  ,  2  ,  1  ,  1  ,  1  , .5f , .5f , .5f ,  2  ,  1  ,  1  , .5f ,  2  ,  1  ,  1  },
     /*DRAGON   */   {  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  , .5f ,  1  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  0  },
     /*DARK     */   {  1  , .5f ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  1  ,  1  , .5f , .5f },
     /*FAIRY    */   {  1  ,  2  ,  1  , .5f ,  1  ,  1  ,  1  ,  1  , .5f , .5f ,  1  ,  1  ,  1  ,  1  ,  1  ,  2  ,  2  ,  1  }

    };

    void Start() {
        zeroList = new List<string>();
        quarterList = new List<string>();
        halfList = new List<string>();
        normalList = new List<string>();
        effectiveList = new List<string>();
        superEffectiveList = new List<string>();
        //var buttonColors = GetComponent<Button>().colors;
    }

    //All the buttons call on these different functions
    public void NormalType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Normal");
        }
        else {
            ArraySort("Normal");
        }
        PrintResults();
    }

    public void FightingType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Fighting");
        }
        else {
            ArraySort("Fighting");
        }
        PrintResults();

    }

    public void FlyingType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Flying");
        }
        else {
            ArraySort("Flying");
        }
        PrintResults();

    }

    public void PoisonType() {
       
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Poison");
        }
        else {
            ArraySort("Poison");
        }
        PrintResults();

    }

    public void GroundType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Ground");
        }
        else {
            ArraySort("Ground");
        }
        PrintResults();

    }

    public void RockType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Rock");
        }
        else {
            ArraySort("Rock");
        }
        PrintResults();

    }

    public void BugType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Bug");
        }
        else {
            ArraySort("Bug");
        }
        PrintResults();

    }

    public void GhostType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Ghost");
        }
        else {
            ArraySort("Ghost");
        }
        PrintResults();

    }

    public void SteelType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Steel");
        }
        else {
            ArraySort("Steel");
        }
        PrintResults();

    }

    public void FireType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Fire");
        }
        else {
            ArraySort("Fire");
        }
        PrintResults();

    }
    
    public void WaterType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Water");
        }
        else {
            ArraySort("Water");
        }
        PrintResults();

    }

    public void GrassType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Grass");
        }
        else {
            ArraySort("Grass");
        }
        PrintResults();

    }

    public void ElectricType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Electric");
        }
        else {
            ArraySort("Electric");
        }
        PrintResults();

    }

    public void PsychicType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Psychic");
        }
        else {
            ArraySort("Psychic");
        }
        PrintResults();

    }

    public void IceType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Ice");
        }
        else {
            ArraySort("Ice");
        }
        PrintResults();

    }

    public void DragonType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Dragon");
        }
        else {
            ArraySort("Dragon");
        }
        PrintResults();

    }

    public void DarkType() {
        
        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Dark");
        }
        else {
            ArraySort("Dark");
        }
        PrintResults();

    }

    public void FairyType() {

        ClearListsAndTexts();
        if (dualMode) {
            TestDualStatus("Fairy");
        }
        else {
            ArraySort("Fairy");
        }
        PrintResults();

    }



    public void DualSwitch() {
        dualMode = !dualMode;
        //swap dual mode button color                  Colors do not work well, cant access it
        //buttonColors.normalColor = Color.red;
        ClearListsAndTexts();
        dualType1 = "";
        dualType2 = "";
        dualTypesText.text = "";
        if (dualMode) {
            dualText.text = "ON";
        }
        else {
            dualText.text = "OFF";
        }
    } //should not be needed anymore

    //toggles dual mode functionality
    public void ToggleDual() {
        ClearListsAndTexts();
        dualType1 = "";
        dualType2 = "";
        dualTypesText.text = "";
        if (toggle.isOn) {
            dualMode = true;
        }
        else {
            dualMode = false;
        }
    }

    //switches toggle text and bool between Offensive and Defensive
    public void OffDefSwitch() {
        offensiveBool = !offensiveBool;
        ClearListsAndTexts();
        if (offensiveBool) {
            offDefText.text = "Offensive";
        }
        else {
            offDefText.text = "Defensive";
        }

    }

    public void ClearType() {

        ClearListsAndTexts();
        dualType1 = "";
        dualType2 = "";
        dualTypesText.text = "";
    }

    public void ExitButton() {
        Application.Quit();
    }



    private void ArraySort(string typeName) {
        float num;
        string name;
        int row = NameToArray(typeName);
        for (int i = 0; i < 18; i++) {
            //test for offensiveBool
            if (offensiveBool) {
                num = pokeType[row, i];
            }
            else { // defensive
                num = pokeType[i, row];
            }
            name = ArrayToName(i);

            if (num == 0) {
                zeroList.Add(name);
            }
            else if (num == .5f) {
                halfList.Add(name);
            }
            else if (num == 1) {
                normalList.Add(name);
            }
            else {
                effectiveList.Add(name);
            }   
        }
    }

    //Converts typeName to corresponding number
    private int NameToArray (string typeName) {
        switch (typeName) {
            case "NORMAL":
            case "Normal":
            case "normal":
                return 0;  
            case "FIGHTING":
            case "Fighting":
            case "fighting":
                return 1;
            case "FLYING":
            case "Flying":
            case "flying":
                return 2;
            case "POISON":
            case "Poison":
            case "poison":
                return 3;
            case "GROUND":
            case "Ground":
            case "ground":
                return 4;
            case "ROCK":
            case "Rock":
            case "rock":
                return 5;
            case "BUG":
            case "Bug":
            case "bug":
                return 6;
            case "GHOST":
            case "Ghost":
            case "ghost":
                return 7;
            case "STEEL":
            case "Steel":
            case "steel":
                return 8;
            case "FIRE":
            case "Fire":
            case "fire":
                return 9;
            case "WATER":
            case "Water":
            case "water":
                return 10;
            case "GRASS":
            case "Grass":
            case "grass":
                return 11;
            case "ELECTRIC":
            case "Electric":
            case "electric":
                return 12;
            case "PSYCHIC":
            case "Psychic":
            case "psychic":
                return 13;
            case "ICE":
            case "Ice":
            case "ice":
                return 14;
            case "DRAGON":
            case "Dragon":
            case "dragon":
                return 15;
            case "DARK":
            case "Dark":
            case "dark":
                return 16;
            case "FAIRY":
            case "Fairy":
            case "fairy":
                return 17;
            default:
                print("Invalid Type");
                return 99;
        }
    }
    
    //Converts the number back to a name
    private string ArrayToName(int i) {
        switch (i) {
                case 0:
                    return "Normal";
                case 1:
                    return "Fighting";
                case 2:
                    return "Flying";
                case 3:
                    return "Poison";
                case 4:
                    return "Ground";
                case 5:
                    return "Rock";
                case 6:
                    return "Bug";
                case 7:
                    return "Ghost";
                case 8:
                    return "Steel";
                case 9:
                    return "Fire";
                case 10:
                    return "Water";
                case 11:
                    return "Grass";
                case 12:
                    return "Electric";
                case 13:
                    return "Psychic";
                case 14:
                    return "Ice";
                case 15:
                    return "Dragon";
                case 16:
                    return "Dark";
                case 17:
                    return "Fairy";
                default:
                    return "ERROR";
            }
    }

    //tests dual status and names before proceeding to sorting
    private void TestDualStatus(string typeName) {
        if (dualType1.Equals("")) {
            dualType1 = typeName;
            dualTypesText.text = dualType1;
        }
        else if (dualType2.Equals("")) {
            if (!dualType1.Equals(typeName)) {
                dualType2 = typeName;
                dualTypesText.text = dualType1 + " + " + dualType2;
                DualSort(dualType1, dualType2);
            }
        }
        else {
            //Do Nothing
        }
    }


    private void DualSort(string type1, string type2) {
        float num;
        float typeNum1;
        float typeNum2;
        int row1 = NameToArray(type1);
        int row2 = NameToArray(type2);
        string name;
        

        for (int i = 0; i < 18; i++) {
            for (int j = 0; j <18; j++) {
                if (i == j) {

                    //test for offensiveBool
                    if (offensiveBool) {
                        typeNum1 = pokeType[row1, i];
                        typeNum2 = pokeType[row2, j];
                    }
                    else {
                        typeNum1 = pokeType[i, row1];
                        typeNum2 = pokeType[j, row2];
                    }
                    num = typeNum1 * typeNum2;
                    name = ArrayToName(i); //+ " " + ArrayToName(j);
                    
                    if (num == 0) {
                        zeroList.Add(name);
                    }
                    else if (num == .25f) {
                        quarterList.Add(name);
                    }
                    else if (num == .5f) {
                        halfList.Add(name);
                    }
                    else if (num == 1) {
                        normalList.Add(name);
                    }
                    else if (num == 2) {
                        effectiveList.Add(name);
                    }
                    else {
                        superEffectiveList.Add(name);
                    }
                }
                else {
                    /*
                    typeNum1 = pokeType[row1, i];
                    typeNum2 = pokeType[row2, j];
                    num = typeNum1 * typeNum2;
                    name = ArrayToName(i) + " " + ArrayToName(j);
                    
                    if (num == 0) {
                        zeroList.Add(name);
                    }
                    else if (num == .25f) {
                        quarterList.Add(name);
                    }
                    else if (num == .5f) {
                        halfList.Add(name);
                    }
                    else if (num == 1) {
                        normalList.Add(name);
                    }
                    else if (num == 2) {
                        effectiveList.Add(name);
                    }
                    else {
                        superEffectiveList.Add(name);
                    }
                    */
                }
            }
        }
    }

    //populates text objects
    private void PrintResults() {

        foreach (string types in zeroList) {
            zeroText.text = zeroText.text + types + "\n";
        }
        foreach (string types in quarterList) {
            quarterText.text = quarterText.text + types + "\n";
        }
        foreach (string types in halfList) {
            halfText.text = halfText.text + types + "\n";
        }
        foreach (string types in normalList) {
            normalText.text = normalText.text + types + "\n";
        }
        foreach (string types in effectiveList) {
            effectiveText.text = effectiveText.text + types + "\n";
        }
        foreach (string types in superEffectiveList) {
            superEffectiveText.text = superEffectiveText.text + types + "\n";
        }
    }

    //clears all text objects
    private void ClearListsAndTexts() {

        zeroText.text = "";
        quarterText.text = "";
        halfText.text = "";
        normalText.text = "";
        effectiveText.text = "";
        superEffectiveText.text = "";
        dualTypesText.text = "";

        zeroList.Clear();
        quarterList.Clear();
        halfList.Clear();
        normalList.Clear();
        effectiveList.Clear();
        superEffectiveList.Clear();
    }
}
