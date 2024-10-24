using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dotweentext : MonoBehaviour

{
    [SerializeField] private GameObject ObjectA;
    [SerializeField] private GameObject PointP;

    private Tween TweenscaleobjectA;
    // Start is called before the first frame update
    void Start()
    {
        moveObjectA();
        scaleObjectA();

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void moveObjectA()
    {
        ObjectA.transform.DOMove(PointP.transform.position,2f).OnComplete(()=>
        {
            TweenscaleobjectA.Kill();
        }); //di chuyen tu diem A toi diem P 
        



    }
    private void scaleObjectA()
    {
        TweenscaleobjectA=  ObjectA.transform.DOScale(0.5f, 1f).OnComplete(()=>
                            {
                            ObjectA.transform.DOScale(1f, 1f);
                            }).SetLoops(-1,LoopType.Restart); // giam scale 1 xuong con 0.5 va quay tro lai thanh 1 ( co vong lap lien tuc )

    }    
}
