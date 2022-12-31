using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : CustomSort
{
    SortElement temp;
    public override void Sort()
    {
        base.Sort();
        StartCoroutine("SortCoroutine");
    }
    IEnumerator SortCoroutine()
    {
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr.Count-1-i; j++)
            {
                if (arr[j].val > arr[j + 1].val)
                {
                    // Index, Ž���� ��� Highlight
                    if (myCharacter)
                        myCharacter.transform.position = arr[j + 1].elementObj.transform.position + Vector3.forward * -3f;
                    arr[j + 1].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    arr[j+1].PlayAudio();
                    arr[j].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
                    yield return new WaitForSeconds(SortSpeed);

                    // arr������ ��ġ �ٲ��ֱ�
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                    Vector3 tmpPos = arr[j].elementObj.transform.position;
                    arr[j].elementObj.transform.position = arr[j + 1].elementObj.transform.position;
                    arr[j + 1].elementObj.transform.position = tmpPos;


                    // Highlight �ǵ�����
                    arr[j + 1].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[j+1].val;
                    arr[j].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[j].val;
                }

            }

            // ������ ��� Highlight
            if (myCharacter)
                myCharacter.transform.position = arr[arr.Count - 1 - i].elementObj.transform.position + Vector3.forward * -3f;
            yield return new WaitForSeconds(SortSpeed);
        }
        SortEnd();
    }
}
