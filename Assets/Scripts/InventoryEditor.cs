using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    private Inventory inventory;

    public void OnEnable()
    {
        inventory = (Inventory)target;
    }

    public override void OnInspectorGUI()
    {
        if (inventory.Items.Count > 0)
        {
            foreach (var item in inventory.Items)
            {
                EditorGUILayout.BeginVertical("box");
                item.ID = EditorGUILayout.IntField("Идентификатор", item.ID);
                item.Name = EditorGUILayout.TextField("Имя предмета", item.Name);
                item.Image = (Sprite)EditorGUILayout.ObjectField("Спрайт", item.Image, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Инвентарь пустой! Предметов нет!");
        }
        if(GUILayout.Button("Добавить предмет",GUILayout.Width(300), GUILayout.Height(20)))
        {
            inventory.Items.Add(new Inventory.Item());
        }
        if (GUI.changed)
        {
            SetObjectDirty(inventory.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
}
