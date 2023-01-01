using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Puzzle03 : MonoBehaviour
{
    public float animationSpeed = 1;
    private float currentKeyFrame = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    void OnMouseDown()
    {
        // Code here is called when the GameObject is clicked on.
        nextKeyFrame();
        
    }

    void nextKeyFrame()
    {

        // this allows the animation to advance

        currentKeyFrame += 0.1f;
        if (currentKeyFrame>=0.99f)
        {
            currentKeyFrame = 0.99f;
            anim.Play("Base Layer.Puzzle_03", 0, currentKeyFrame);
            AnimFineshed();
        }
        anim.Play("Base Layer.Puzzle_03", 0, currentKeyFrame);
        // print(currentKeyFrame);
        // anim.enabled = true;
        // anim.speed = 0;
        // anim.PlayInFixedTime("Base Layer.Puzzle_03", -1, 0.05f);
    }

    public void AnimFineshed()
    {
        PuzzleManager.Instance.PuzzleSolved();
        anim.enabled = false;
    }
    
}
