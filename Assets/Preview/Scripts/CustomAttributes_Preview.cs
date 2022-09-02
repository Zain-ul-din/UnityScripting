﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAttributes_Preview : MonoBehaviour
{

    [SerializeField] private float test;
    // Start is called before the first frame update
    void Start() {
        MyClass myClass = new MyClass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    [MyAttribute (2)] 
    public class MyClass {
        public MyClass () {
            Debug.Log ("My Class!!");
        }
    }

}


[AttributeUsage (AttributeTargets.Class, AllowMultiple = false)]
public class MyAttribute : Attribute {
   public int val;

   public MyAttribute (int val) {
    Debug.Log ("MyVal"); 
    this.val = val; 
   }
}

