using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsView;
    private int _playerPoints = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
        {
            _pointsView.text = AddPoints(50).ToString();
            Destroy(other.gameObject);
        }
    }
    private int AddPoints(int points)
    {
        return _playerPoints += points;
    }
}
