using Assets.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Change : MonoBehaviour
{

    [SerializeField] private Material transparentMaterial;
    [SerializeField] public CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer cinemachineTransposer;

    public bool Is2D { get; set; }
    private bool isSphere = true;
    private bool canChange = true;

    public GameObject SpherePlayer;
    public GameObject CubePlayer;
    public ReloadScenePlaneManager reloadScenePlaneManager;

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
        List<GameObject> visualGameObjects = GameObject.FindGameObjectsWithTag(visualString).ToList();
        List<GameObject> transparentGameObjects = GameObject.FindGameObjectsWithTag(transparentString).ToList();

        foreach (GameObject item in transparentGameObjects)
        {
            string tmpNameVisual = item.name.Replace(transparentString, visualString);
            Transform visualTransform = item.transform.parent.Find(tmpNameVisual);
            Material tmpMaterial = visualTransform.gameObject.GetComponent<MeshRenderer>().material;
            item.GetComponent<MeshRenderer>().material = !Is2D ? transparentMaterial : tmpMaterial;
            visualTransform.gameObject.SetActive(!Is2D);
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

    IEnumerator SpawnNewCubePlayer(GameObject player, Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = Instantiate(player, position, Quaternion.identity);
        CubePlayer _player = obj.GetComponent<CubePlayer>();
        _player.InAnimation();
        virtualCamera.Follow = obj.transform;
        reloadScenePlaneManager._player = _player;
        canChange = true;
    }

    IEnumerator SpawnNewSpherePlayer(GameObject player, Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = Instantiate(player, position, Quaternion.identity);
        SpherePlayer _player = obj.GetComponent<SpherePlayer>();
        _player.InAnimation();
        virtualCamera.Follow = obj.transform;
        reloadScenePlaneManager._player = _player;
        canChange = true;
    }


}
