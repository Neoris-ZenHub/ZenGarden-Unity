using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using System.Collections;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject inventoryItemPrefab; // Prefab de InventoryItem
    public InventorySlot[] inventorySlots; // Arreglo de todos los slots del inventario
    /*private string userId = "7a267a8b-71e2-42c8-aaad-c8f7987efb33";
    private string apiUrl = "http://localhost:4000/sprite/user";

    [SerializeField] private AudioSource audioSource;
    private bool isFirstLoad = true;

    private void Start()
    {
<<<<<<< HEAD
        // Load all items from the "Items" folder in the Resources directory
        items = Resources.LoadAll<Item>("UnlockedItems");

        // Log the details of the items array
        Debug.Log(items);

        // Carga todos los items automáticamente al iniciar
        LoadAllItems();

        isFirstLoad = false; //Evitamos que el sonido se reproduzca la primera vez
=======
        Debug.Log("Iniciando petición para obtener sprites");
        StartCoroutine(GetSpritesCoroutine());
>>>>>>> cd8a76f7ab362d223fa83905a8d4b4be26746513
    }

    IEnumerator GetSpritesCoroutine()
    {
        Debug.Log("Preparando datos para la petición");
        var requestObject = new { _id_user = userId };
        string jsonBody = JsonConvert.SerializeObject(requestObject);
        Debug.Log("JSON enviado: " + jsonBody);

        var request = new UnityWebRequest(apiUrl, "POST");
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

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

    private void LoadSprites(SpriteInfo[] spriteInfos)
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
<<<<<<< HEAD
                if (slot.transform.childCount == 0) // Verifica si el slot está vacío
                {
                    SpawnItem(item, slot);
                    itemPlaced = true;
                    break; // Sale del bucle una vez que el item es colocado
                }
                if (!isFirstLoad && audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                }
=======
                Debug.Log("Sprite cargado correctamente: " + item.name);
                PlaceItemInInventory(item);
>>>>>>> cd8a76f7ab362d223fa83905a8d4b4be26746513
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
    }*/
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
