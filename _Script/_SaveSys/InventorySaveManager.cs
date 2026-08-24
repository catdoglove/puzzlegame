using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class InventoryData
{
    public int invetItem0;
    public int invetItem1;
    public int invetItem2;
    public int invetItem3;
    public int invetItem4;
    public int invetItem5;
    public int invetItem6;
}

public static class InventorySaveManager
{
    private const string FILE_NAME = "InventoryData_Chapter";

    private const string KEY_INVENT_DATA0 = "inventoryget0";
    private const string KEY_INVENT_DATA1 = "inventoryget1";
    private const string KEY_INVENT_DATA2 = "inventoryget2";
    private const string KEY_INVENT_DATA3 = "inventoryget3";
    private const string KEY_INVENT_DATA4 = "inventoryget4";
    private const string KEY_INVENT_DATA5 = "inventoryget5";
    private const string KEY_INVENT_DATA6 = "inventoryget6";


    // ==========================================
    // 챕터 번호 검사
    // ==========================================

    private static bool IsValidChapter(int chapter)
    {
        if (chapter < 1 || chapter > 10)
        {
            Debug.LogWarning("[InventorySave] 챕터 번호는 1~10만 사용할 수 있습니다.");
            return false;
        }

        return true;
    }


    // ==========================================
    // 챕터에 따른 파일 경로
    // ==========================================

    private static string GetFilePath(int chapter)
    {
        return Path.Combine(
            Application.persistentDataPath,
            FILE_NAME + chapter + ".json"
        );
    }


    // ==========================================
    // PlayerPrefs → JSON 파일 저장
    // ==========================================

    public static void SaveInventory(int chapter)
    {
        if (!IsValidChapter(chapter))
            return;

        InventoryData data = new InventoryData();

        data.invetItem0 = PlayerPrefs.GetInt(KEY_INVENT_DATA0, 0);
        data.invetItem1 = PlayerPrefs.GetInt(KEY_INVENT_DATA1, 0);
        data.invetItem2 = PlayerPrefs.GetInt(KEY_INVENT_DATA2, 0);
        data.invetItem3 = PlayerPrefs.GetInt(KEY_INVENT_DATA3, 0);
        data.invetItem4 = PlayerPrefs.GetInt(KEY_INVENT_DATA4, 0);
        data.invetItem5 = PlayerPrefs.GetInt(KEY_INVENT_DATA5, 0);
        data.invetItem6 = PlayerPrefs.GetInt(KEY_INVENT_DATA6, 0);

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(GetFilePath(chapter), json);

        Debug.Log(
            "[InventorySave] 챕터 " + chapter +
            " 인벤토리 저장 완료\n" +
            "저장 위치 : " + GetFilePath(chapter)
        );
    }


    // ==========================================
    // JSON 파일 → PlayerPrefs + Inventory
    // ==========================================

    public static void LoadInventory(int chapter)
    {
        if (!IsValidChapter(chapter))
            return;

        string path = GetFilePath(chapter);

        if (!File.Exists(path))
        {
            Debug.LogWarning(
                "[InventorySave] 챕터 " + chapter +
                " 인벤토리 저장 파일이 없습니다."
            );

            return;
        }

        string json = File.ReadAllText(path);

        InventoryData data = JsonUtility.FromJson<InventoryData>(json);


        // ==========================================
        // PlayerPrefs에 저장
        // ==========================================

        PlayerPrefs.SetInt(KEY_INVENT_DATA0, data.invetItem0);
        PlayerPrefs.SetInt(KEY_INVENT_DATA1, data.invetItem1);
        PlayerPrefs.SetInt(KEY_INVENT_DATA2, data.invetItem2);
        PlayerPrefs.SetInt(KEY_INVENT_DATA3, data.invetItem3);
        PlayerPrefs.SetInt(KEY_INVENT_DATA4, data.invetItem4);
        PlayerPrefs.SetInt(KEY_INVENT_DATA5, data.invetItem5);
        PlayerPrefs.SetInt(KEY_INVENT_DATA6, data.invetItem6);


        // ==========================================
        // 아이템 보유 여부 저장
        // ==========================================

        if (data.invetItem0 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem0, 1);
        }

        if (data.invetItem1 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem1, 1);
        }

        if (data.invetItem2 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem2, 1);
        }

        if (data.invetItem3 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem3, 1);
        }

        if (data.invetItem4 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem4, 1);
        }

        if (data.invetItem5 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem5, 1);
        }

        if (data.invetItem6 != 0)
        {
            PlayerPrefs.SetInt("itemnum" + data.invetItem6, 1);
        }

        PlayerPrefs.Save();


        // ==========================================
        // Inventory 스크립트 찾기
        // ==========================================

        Inventory inventory = Object.FindObjectOfType<Inventory>();

        if (inventory == null)
        {
            Debug.LogWarning(
                "[InventorySave] Inventory 스크립트를 찾을 수 없습니다."
            );

            return;
        }


        // ==========================================
        // Inventory에 적용
        // ==========================================

        if (data.invetItem0 != 0)
        {
            inventory.items_i[0] = data.invetItem0;
            inventory.invenItem_obj[0].SetActive(true);
            inventory.invenItem_obj[0].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem0];
        }

        if (data.invetItem1 != 0)
        {
            inventory.items_i[1] = data.invetItem1;
            inventory.invenItem_obj[1].SetActive(true);
            inventory.invenItem_obj[1].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem1];
        }

        if (data.invetItem2 != 0)
        {
            inventory.items_i[2] = data.invetItem2;
            inventory.invenItem_obj[2].SetActive(true);
            inventory.invenItem_obj[2].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem2];
        }

        if (data.invetItem3 != 0)
        {
            inventory.items_i[3] = data.invetItem3;
            inventory.invenItem_obj[3].SetActive(true);
            inventory.invenItem_obj[3].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem3];
        }

        if (data.invetItem4 != 0)
        {
            inventory.items_i[4] = data.invetItem4;
            inventory.invenItem_obj[4].SetActive(true);
            inventory.invenItem_obj[4].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem4];
        }

        if (data.invetItem5 != 0)
        {
            inventory.items_i[5] = data.invetItem5;
            inventory.invenItem_obj[5].SetActive(true);
            inventory.invenItem_obj[5].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem5];
        }

        if (data.invetItem6 != 0)
        {
            inventory.items_i[6] = data.invetItem6;
            inventory.invenItem_obj[6].SetActive(true);
            inventory.invenItem_obj[6].GetComponent<Image>().sprite =
                inventory.Item_spr[data.invetItem6];
        }


        Debug.Log(
            "[InventorySave] 챕터 " + chapter +
            " 인벤토리 불러오기 완료"
        );
    }
}