using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class UIPanelHierarchyHighlighter
{
    public static bool IsHierarchyFocused => EditorWindow.focusedWindow != null && EditorWindow.focusedWindow.titleContent.text == "Hierarchy";

    static UIPanelHierarchyHighlighter()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        UnityEngine.Object instance = EditorUtility.InstanceIDToObject(instanceID);

        if (instance != null)
        {
            UIPanel uiPanel = (instance as GameObject).GetComponent<UIPanel>();

            if (uiPanel != null)
            {
                UIPanelHierarchyItem item = new UIPanelHierarchyItem(instanceID, selectionRect, uiPanel);
                PaintBackground(item);
                PaintText(item);
            }
        }
    }

    private static void PaintBackground(UIPanelHierarchyItem item)
    {
        Color32 color;
        if (item.IsSelected) color = MyEditorColors.GetDefaultBackgroundColor(IsHierarchyFocused, item.IsSelected);
        else color = item.UIPanel.IsShowing ? item.UIPanel.ShowingColor : item.UIPanel.HidenColor;

        EditorGUI.DrawRect(item.BackgroundRect, color);
    }

    private static void PaintText(UIPanelHierarchyItem item)
    {
        Color32 color = MyEditorColors.GetDefaultTextColor(IsHierarchyFocused, item.IsSelected, item.GameObject.activeInHierarchy);

        GUIStyle labelGUIStyle = new GUIStyle
        {
            normal = new GUIStyleState { textColor = color },
        };

        EditorGUI.LabelField(item.TextRect, item.UIPanel.name, labelGUIStyle);
    }
}
