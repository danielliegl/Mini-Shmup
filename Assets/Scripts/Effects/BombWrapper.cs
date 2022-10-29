using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWrapper : MonoBehaviour
{

  public float scale;

  // Start is called before the first frame update
  void Start()
  {
    gameObject.transform.localScale = new Vector3(scale, scale, scale);
  }

  // Update is called once per frame
  void Update()
  {
    Effect child = gameObject.GetComponentInChildren<Effect>();
    if(child = null)
    {
      Destroy(gameObject);
    }
  }
}
