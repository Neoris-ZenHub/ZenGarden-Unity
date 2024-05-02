using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using System.Collections;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject inventoryItemPrefab; // Prefab de InventoryItem
    public InventorySlot[] inventorySlots; // Arreglo de todos los slots del inventario
    private string token;
    private string apiUrl = "http://localhost:4000/sprite/user";

    [SerializeField] private AudioSource audioSource;
    private bool isFirstLoad = true;
private void Start()
    {
        // Obtén el token desde el parámetro de la URL cuando la aplicación cargue
        token = GetTokenFromURL();
        Debug.Log("Token recibido: " + token);
        if (!string.IsNullOrEmpty(token))
        {
            StartCoroutine(GetSpritesCoroutine());
        }
        else
        {
            Debug.LogError("Token no encontrado en la URL");
        }
    }

    string GetTokenFromURL()
    {
        try
        {
            Url myUrl = new Url(Application.absoluteURL);
            string param = HttpUtility.ParseQueryString(myUrl.Query).Get("token");
            return param ?? string.Empty;
        }
        catch (Exception e)
        {
            Debug.LogError("Error parsing URL: " + e.Message);
            return string.Empty;
        }
    }

    IEnumerator GetSpritesCoroutine()
    {
        var request = new UnityWebRequest(apiUrl, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + token); // Añade el token como un Bearer token en la cabecera de autorización

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta recibida correctamente");
            SpritesResponse sprites = JsonConvert.DeserializeObject<SpritesResponse>(request.downloadHandler.text);
            Debug.Log("Sprites deserializados: " + sprites.sprites.Length + " sprites encontrados");
            LoadSprites(sprites.sprites);
        }
        else
        {
            Debug.LogError("Error en la petición: " + request.error);
        }
    }

    public void LoadSprites(SpriteInfo[] spriteInfos)
    {
        if (spriteInfos.Length == 0)
        {
            Debug.Log("No hay sprites para cargar según la API");
            return;
        }

        foreach (var spriteInfo in spriteInfos)
        {
            Debug.Log("Cargando sprite desde: " + spriteInfo.sprite_url);
            Item item = Resources.Load<Item>(spriteInfo.sprite_url);
            if (item != null)
            {
                Debug.Log("Sprite cargado correctamente: " + item.name);
                PlaceItemInInventory(item);
            }
            else
            {
                Debug.LogError("No se pudo cargar el sprite: " + spriteInfo.sprite_url);
            }
        }
    }

    private void PlaceItemInInventory(Item item)
    {
        bool itemPlaced = false;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.transform.childCount == 0)
            {
                Debug.Log("Colocando item en el slot disponible");
                SpawnItem(item, slot);
                itemPlaced = true;
                break;
            }
        }
        if (!itemPlaced)
        {
            Debug.LogError("No se encontró un slot disponible para colocar el item: " + item.name);
        }
    }

    // Método para crear un item específico en un slot específico
    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItemComponent = newItem.GetComponent<InventoryItem>();
        if (inventoryItemComponent != null)
        {
            inventoryItemComponent.InitialiseItem(item);
        }
    }
}

public class SpritesResponse
{
    public string message;
    public SpriteInfo[] sprites;
}

public class SpriteInfo
{
    public string name;
    public string sprite_url;
}
