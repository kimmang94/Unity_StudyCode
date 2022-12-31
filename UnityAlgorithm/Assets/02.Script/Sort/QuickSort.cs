using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : CustomSort
{
    public override void Sort()
    {
        base.Sort();
        StartCoroutine("SortCoroutine");
    }

    IEnumerator SortCoroutine()
    {
        yield return StartCoroutine(QuickSortCoroutine(0,arr.Count-1));
        SortEnd();
    }

    IEnumerator QuickSortCoroutine(int start, int end)
    {
        if (start >= end)
        {
            yield return new WaitForSeconds(SortSpeed);
        }
        else
        {
            int key = start;
            int i = start + 1;
            int j = end;
            SortElement temp;
            while (i <= j)
            {
                // ���ʿ������� ���������� key���� ū �� ã��
                while (i <= end && arr[i].val <= arr[key].val)
                {
                    // Ž���� ��� Highlight
                    if (myCharacter)
                        myCharacter.transform.position = arr[i].elementObj.transform.position + Vector3.forward * -3f;
                    arr[i].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    arr[i].PlayAudio();
                    if (i - 1 >=0)
                        arr[i - 1].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[i - 1].val;
                    yield return new WaitForSeconds(SortSpeed);

                    i++;
                }
                // �����ʿ������� �������� key���� ���� �� ã��
                while (j>start&&arr[j].val >= arr[key].val)
                {
                    // Ž���� ��� Highlight
                    if (myCharacter)
                        myCharacter.transform.position = arr[j].elementObj.transform.position + Vector3.forward * -3f;
                    arr[j].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    arr[j].PlayAudio();
                    if (j+1 <arr.Count)
                        arr[j+1].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[j+1].val;
                    yield return new WaitForSeconds(SortSpeed);

                    j--;
                }

                // index ��� Highlight
                if (myCharacter)
                    myCharacter.transform.position = arr[Mathf.Min(i, arr.Count - 1)].elementObj.transform.position + Vector3.forward * -3f;
                arr[Mathf.Min(i, arr.Count - 1)].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.green;

                // index ��� Highlight
                if (myCharacter)
                    myCharacter.transform.position = arr[Mathf.Max(j, 0)].elementObj.transform.position + Vector3.forward * -3f;
                arr[Mathf.Max(j, 0)].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.green;

                yield return new WaitForSeconds(SortSpeed);
                if (i > j)
                {
                    // ���� ��������

                    // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                    Vector3 tmpPos = arr[j].elementObj.transform.position;
                    arr[j].elementObj.transform.position = arr[key].elementObj.transform.position;
                    arr[key].elementObj.transform.position = tmpPos;

                    // key�� j(�����ʿ������� ã�� ���� ��) ��ġ �ٲٱ�
                    temp = arr[j];
                    arr[j] = arr[key];
                    arr[key] = temp;
                }
                else
                {
                    // ���� �������� �ʾҴٸ�

                    // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                    Vector3 tmpPos = arr[i].elementObj.transform.position;
                    arr[i].elementObj.transform.position = arr[j].elementObj.transform.position;
                    arr[j].elementObj.transform.position = tmpPos;

                    // i�� j ��ġ �ٲٱ�
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }


                // ������ ��� Highlight
                if (myCharacter)
                    myCharacter.transform.position = arr[key].elementObj.transform.position + Vector3.forward * -3f;
                arr[Mathf.Min(i, arr.Count - 1)].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[Mathf.Min(i, arr.Count - 1)].val;
                arr[Mathf.Max(j, 0)].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[Mathf.Max(j, 0)].val;
                arr[key].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[key].val;

                yield return new WaitForSeconds(SortSpeed);
            }
            // j�� �̹� ���ĵǾ��ֱ⿡ start���� j-1���� ����
            yield return StartCoroutine(QuickSortCoroutine(start, j - 1));
            // j�� �̹� ���ĵǾ��ֱ⿡ j+1���� end���� ����
            yield return StartCoroutine(QuickSortCoroutine(j+1,end));
        }
    }
}
