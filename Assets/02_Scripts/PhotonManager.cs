using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Game Version
    [SerializeField] private const string version = "1.0";

    private string nickname = "Cha";

    [Header("Text")]
    [SerializeField] private TMP_InputField nickNameIF;
    [SerializeField] private TMP_InputField roomNameIF;

    [Header("Button")]
    [SerializeField] private Button makeRoomButton;
    [SerializeField] private Button OptionButton;
    [SerializeField] private Button loginButton;

    [Header("Room List")]
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Transform contenTR;
    RoomOptions roomOptions = new RoomOptions
    {
        MaxPlayers = 5,
        IsOpen = true,
        IsVisible = true
    };


    private void Awake()
    {
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = nickname;
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    void Start()
    {
        nickname = PlayerPrefs.GetString("NICK_NAME", $"USER_{Random.Range(0, 1001):0000}");
        nickNameIF.text = nickname;

        loginButton.onClick.AddListener(() => OnLoginButtonClick());
        makeRoomButton.onClick.AddListener(() => OnMakeRoomButtonClick());
        // OptionButton.onClick.AddListener(() => VisibleOption());
        nickNameIF.onValueChanged.AddListener((Inputtext) =>
        {
            nickname = Inputtext;
            Debug.Log($" nick is {nickname}");
        });
    }


    private void OnLoginButtonClick()
    {
        //SetNickNam();
        PhotonNetwork.JoinRandomRoom();
    }
    private void OnMakeRoomButtonClick()
    {
        //SetNickNam();
        if (string.IsNullOrEmpty(roomNameIF.text))
        {
            roomNameIF.text = $"ROOM_{Random.Range(0, 1000)}";
        }

        PhotonNetwork.CreateRoom(roomNameIF.text, roomOptions);
    }
    private void SetNickNam()
    {
        if (string.IsNullOrEmpty(nickNameIF.text))
        {
            nickname = $"USER_{Random.Range(0, 1001):0000}";
            nickNameIF.text = nickname;
        }
        else
        {
            nickname = nickNameIF.text;
        }
        PhotonNetwork.NickName = nickname;
        PlayerPrefs.SetString("NICK_NAME", nickname);
    }

    #region 포톤 콜백 함수
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 입장");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장");

        if (PhotonNetwork.IsMasterClient)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Test_stage1");
        }
    }
    #endregion
}
