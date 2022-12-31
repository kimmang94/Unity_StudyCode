using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : CustomSort
{
    SortElement temp;
    int index = -1;

    public override void Sort()
    {
        base.Sort();
        StartCoroutine("SortCoroutine");
    }
    IEnumerator SortCoroutine()
    {
        for (int i = 0; i < arr.Count-1; i++)
        {
            index = i;

            // Index ��� Highlight
            arr[index].elementObj.GetComponentInChildren<MeshRenderer>().material.color =Color.green;
            yield return new WaitForSeconds(SortSpeed);

            while (index >= 0 && arr[index].val > arr[index+1].val)
            {
                // arr������ ��ġ �ٲ��ֱ�
                temp = arr[index];
                arr[index] = arr[index+1];
                arr[index+1] = temp;

                // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                Vector3 tmpPos = arr[index].elementObj.transform.position;
                arr[index].elementObj.transform.position = arr[index+1].elementObj.transform.position;
                arr[index+1].elementObj.transform.position = tmpPos;

                // Ž���� ��� Highlight
                arr[index].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                arr[index+1].PlayAudio();

                if (myCharacter)
                    myCharacter.transform.position = arr[index].elementObj.transform.position + Vector3.forward * -3f;

                index--;

                yield return new WaitForSeconds(SortSpeed);
            }

            // ������ ��� Highlight
            if (myCharacter)
                myCharacter.transform.position = arr[i].elementObj.transform.position + Vector3.forward * -3f;
            for (int j = 0; j <= i; j++)
            {
                arr[j].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[j].val;
            }
            yield return new WaitForSeconds(SortSpeed);
        }


        // ������ ��� Highlight
        for (int j = arr.Count - 2; j < arr.Count; j++)
            arr[j].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[j].val;
        SortEnd();
    }
}
