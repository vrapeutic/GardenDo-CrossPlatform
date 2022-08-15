using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReachCollidiers 
{
    void OnReachCollidier();
    void OnExitCollider();
    void ActiveNextCollider();
    void DectiveCurrentCollider();
   
}
