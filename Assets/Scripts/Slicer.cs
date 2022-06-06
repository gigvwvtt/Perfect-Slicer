using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicer.Samples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _delayBetweenCut;
    private float _timeAfterCut;

    private BzKnife _knife;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
    }

    private void Update()
    {
        _timeAfterCut += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterCut > _delayBetweenCut)
            {
                _knife.BeginNewSlice();

                _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration / 2.0f).SetLoops(2, LoopType.Yoyo);
                _timeAfterCut = 0;
            }
        }
    }
}
