using Assets.Scripts;
using Cinemachine;
using System.Collections;
using UnityEngine;

public class Change : MonoBehaviour
{

    private bool isSphere = true;
    private bool canChange = true;
    public CinemachineVirtualCamera VirtualCamera;

    public GameObject SpherePlayer;
    public GameObject CubePlayer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canChange)
        {
            canChange = false;
            GameObject liveObject = GameObject.FindGameObjectWithTag("Player");
            Vector3 position = new Vector3(liveObject.transform.position.x, liveObject.transform.position.y, liveObject.transform.position.z);
            if (isSphere)
            {
                liveObject.GetComponent<SpherePlayer>().OutAnimation();
                Destroy(liveObject, 0.9f);
                StartCoroutine(SpawnNewCubePlayer(CubePlayer, position));
                isSphere = false;
            }
            else
            {
                liveObject.GetComponent<CubePlayer>().OutAnimation();
                Destroy(liveObject, 0.9f);
                StartCoroutine(SpawnNewSpherePlayer(SpherePlayer, position));
                isSphere = true;
            }

        }

    }

    IEnumerator SpawnNewCubePlayer(GameObject player, Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = Instantiate(player, position, Quaternion.identity);
        obj.GetComponent<CubePlayer>().InAnimation();
        VirtualCamera.Follow = obj.transform;
        canChange = true;
    }

    IEnumerator SpawnNewSpherePlayer(GameObject player, Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = Instantiate(player, position, Quaternion.identity);
        obj.GetComponent<SpherePlayer>().InAnimation();
        VirtualCamera.Follow = obj.transform;
        canChange = true;
    }


}
