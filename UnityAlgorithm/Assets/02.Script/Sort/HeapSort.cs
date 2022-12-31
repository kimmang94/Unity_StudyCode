using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapSort : CustomSort
{
    public override void Sort()
    {
        base.Sort();
        StartCoroutine("SortCoroutine");
    }
    IEnumerator SortCoroutine()
    {
        //�� �����
        for(int i = 1; i < arr.Count; i++)
        {
            int child = i;
            do
            {
                int root = (child - 1) / 2;
                if (arr[root].val < arr[child].val)
                {
                    // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                    Vector3 tmpPos = arr[root].elementObj.transform.position;
                    arr[root].elementObj.transform.position = arr[child].elementObj.transform.position;
                    arr[child].elementObj.transform.position = tmpPos;

                    SortElement temp = arr[root];
                    arr[root] = arr[child];
                    arr[child] = temp;
                }
                child = root;
            } while (child != 0);
        }

        // �ϼ��� �� ����
        for (int i = arr.Count-1; i >=0; i--)
        {
            // ù��°�� ������ �ٲٱ�
            // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
            Vector3 tmpPos = arr[0].elementObj.transform.position;
            arr[0].elementObj.transform.position = arr[i].elementObj.transform.position;
            arr[i].elementObj.transform.position = tmpPos;

            SortElement temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;


            // index ��� Highlight
            arr[i].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
            yield return new WaitForSeconds(SortSpeed);

            int root = 0;
            int child = 1;
            do
            {
                // �ڽ� Ž��
                child = (2 * root) + 1;
                // ����(child)�� ������(child+1) �ڽ� �� ū �� ����
                // child < i-1�� ������ ���� �����ϱ� ����
                if (child < i - 1 && arr[child].val < arr[child + 1].val)
                {
                    child++;
                }
                // �ڽ��� Root���� ũ�ٸ� ��ȯ
                if (child < i && arr[root].val < arr[child].val)
                {
                    // Ž���� ��� Highlight
                    arr[child].elementObj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    arr[child].PlayAudio();
                    if (myCharacter)
                        myCharacter.transform.position = arr[child].elementObj.transform.position + Vector3.forward * -3f;

                    // �ð�ȭ�� ���� ���� ������Ʈ ��ġ �ٲ��ֱ�
                    Vector3 tmpPos2 = arr[root].elementObj.transform.position;
                    arr[root].elementObj.transform.position = arr[child].elementObj.transform.position;
                    arr[child].elementObj.transform.position = tmpPos2;

                    yield return new WaitForSeconds(SortSpeed);

                    temp = arr[root];
                    arr[root] = arr[child];
                    arr[child] = temp;


                    // Ž���� ��� Highlight
                    arr[root].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[i].val;
                }
                root = child;
            } while (child < i);
            // index ��� Highlight
            arr[i].elementObj.GetComponentInChildren<MeshRenderer>().material.color = unitColor * arr[i].val;
        }
        yield return new WaitForSeconds(SortSpeed);

        SortEnd();
    }
}
