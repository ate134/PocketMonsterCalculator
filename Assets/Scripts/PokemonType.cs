using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/*
 
     This is completly useless from what i can tell, looks like beginnings of something then i had a different idea
     
     
     */

public class PokemonType {
    public float normal;
    public float fighting;
    public float flying;
    public float poison;
    public float ground;
    public float rock;
    public float bug;
    public float ghost;
    public float steel;
    public float fire;
    public float water;
    public float grass;
    public float electric;
    public float psychic;
    public float ice;
    public float dragon;
    public float dark;
    public float fairy;

    List<string> zeroList;
    List<string> halfList;
    List<string> normalList;
    List<string> effectiveList;

    public PokemonType() {

        normal =     0;
        fighting =   0;
        flying =     0;
        poison =     0;
        ground =     0;
        rock =       0;
        bug =        0;
        ghost =      0;
        steel =      0;
        fire =       0;
        water =      0;
        grass =      0;
        electric =   0;
        psychic =    0;
        ice =        0;
        dragon =     0;
        dark =       0;
        fairy =      0;

    }


    public void Sort(float typ, string name) {

        if (typ == 0) {
            zeroList.Add(name);
        }
        else if (typ == .5f) {
            halfList.Add(name);
        }
        else if (typ == 1) {
            normalList.Add(name);
        }
        else {
            effectiveList.Add(name);
        }
    }


}
