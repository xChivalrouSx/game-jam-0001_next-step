using Assets.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Change : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private Material transparentMaterial;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer cinemachineTransposer;

    public bool Is2D { get; set; }
    private bool isSphere = true;
    private bool canChange = true;

    private void Awake()
    {
        cinemachineTransposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        Is2D = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canChange)
        {
            TransformPlayerCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.F) && canChange)
        {
            TransformGameWorld();
        }
    }

    private void TransformGameWorld()
    {
        canChange = false;
        string visualString = "Visual";
        string transparentString = "Transparent";
        List<GameObject> transparentGameObjects = GameObject.FindGameObjectsWithTag(transparentString).ToList();

        foreach (GameObject item in transparentGameObjects)
        {
            string tmpNameVisual = item.name.Replace(transparentString, visualString);
            Transform visualTransform = item.transform.parent.Find(tmpNameVisual);
            Material tmpMaterial = visualTransform.gameObject.GetComponent<MeshRenderer>().material;
            item.GetComponent<MeshRenderer>().material = !Is2D ? transparentMaterial : tmpMaterial;
            visualTransform.gameObject.SetActive(!Is2D);

            if (item.transform.parent.tag.Equals("Player"))
            {
                item.GetComponentInParent<Rigidbody>().constraints = Is2D ?
                    RigidbodyConstraints.FreezeRotation : RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            }
        }

        cinemachineTransposer.m_FollowOffset = Is2D ? new Vector3(-1, 4.5f, -8) : new Vector3(0, 0, -10);
        virtualCamera.transform.rotation = Is2D ? Quaternion.Euler(20, 10, 0) : Quaternion.Euler(0, 0, 0);

        GameObject livePlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        livePlayerGameObject.transform.position = new Vector3(livePlayerGameObject.transform.position.x, livePlayerGameObject.transform.position.y, 0);

        Is2D = !Is2D;
        canChange = true;
    }

    private void TransformPlayerCharacter()
    {
        canChange = false;
        PlayerCube playerCube = playerGameObject.transform.Find("PlayerCube").gameObject.GetComponent<PlayerCube>();
        PlayerSphere playerSphere = playerGameObject.transform.Find("PlayerSphere").gameObject.GetComponent<PlayerSphere>();

        if (Is2D)
        {
            playerCube.transform.Find("CubePlayerTransparent").gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
            playerCube.transform.Find("CubePlayerVisual").gameObject.SetActive(true);

            playerSphere.transform.Find("SpherePlayerTransparent").gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
            playerSphere.transform.Find("SpherePlayerVisual").gameObject.SetActive(true);
        }
        else
        {
            GameObject cubeVisualGameObject = playerCube.transform.Find("CubePlayerVisual").gameObject;
            Material cubeVisualMaterial = cubeVisualGameObject.GetComponent<MeshRenderer>().material;
            playerCube.transform.Find("CubePlayerTransparent").gameObject.GetComponent<MeshRenderer>().material = cubeVisualMaterial;
            cubeVisualGameObject.SetActive(false);

            GameObject sphereVisualGameObject = playerSphere.transform.Find("SpherePlayerVisual").gameObject;
            Material sphereVisualMaterial = sphereVisualGameObject.GetComponent<MeshRenderer>().material;
            playerSphere.transform.Find("SpherePlayerTransparent").gameObject.GetComponent<MeshRenderer>().material = sphereVisualMaterial;
            sphereVisualGameObject.SetActive(false);
        }

        if (isSphere)
        {
            playerSphere.OutAnimation();
            StartCoroutine(SpawnNewCubePlayer(playerSphere, playerCube));
            isSphere = false;
        }
        else
        {
            playerCube.OutAnimation();
            StartCoroutine(SpawnNewCubePlayer(playerCube, playerSphere));
            isSphere = true;
        }
    }

    private IEnumerator SpawnNewCubePlayer(Player playerToPassive, Player playerToActive)
    {
        yield return new WaitForSeconds(1f);
        playerToActive.transform.position = playerToPassive.transform.position;
        playerToPassive.gameObject.SetActive(false);
        playerToActive.gameObject.SetActive(true);
        playerToActive.InAnimation();
        virtualCamera.Follow = playerToActive.transform;
        canChange = true;
    }

}
