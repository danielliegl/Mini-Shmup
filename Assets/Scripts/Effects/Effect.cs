using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

  public float length;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(DeathCountdown(length));
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  private IEnumerator DeathCountdown(float time)
  {
    yield return new WaitForSeconds(time);
    Destroy(gameObject);
  }
}
