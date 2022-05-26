using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmap : MonoBehaviour
{
    public GameObject blockPrefab;
    public static int[,] array = new int[25, 25];
    int center = 10;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 placePosition3;
        Quaternion q = new Quaternion();
        q = Quaternion.identity;
        /*配列の初期化*/
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                array[i, j] = 0;
            }
        }


        array[10,10] = 1;//初期位置
        int r1;
        int r2;
        for (int i = 0; i < 45; i++)
        {
            while (true)
            {
                r1 = Random.Range(0, 20);
                r2 = Random.Range(0, 20);
                if (array[r1, r2] == 0) break;
            }

            placePosition3 = new Vector3(r1 - center, 0, r2 - center);
            var _obj = Instantiate(blockPrefab, placePosition3, q);
            array[r1, r2] = 1;//壁配置


            //1箇所をゴールとして色変更
            if (i == 0)
            {
                var _renderer = _obj.GetComponent<Renderer>();
                _renderer.material.color = Color.green;
                //色変更
                array[r1, r2] = 2;//壁配置ゴール
            }

        }

    }

}
