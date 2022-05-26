using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切替

public class Block : MonoBehaviour
{
    int center = 10;


    void OnCollisionEnter(Collision collision)
    {
        Transform myTransform = this.transform;//自分自身のポジション
        // 座標を取得
        Vector3 pos = myTransform.position;
        int x = (int)pos.x + center;
        int z = (int)pos.z + center;

        if (Blockmap.array[x, z] == 2)
        {   
            SceneManager.LoadScene("Goal");//ゴール処理
        }
    }
}
