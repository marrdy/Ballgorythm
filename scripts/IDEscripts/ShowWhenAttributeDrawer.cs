using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ShowWhenAttribute))]
public class ShowWhenAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowWhenAttribute showWhen = attribute as ShowWhenAttribute;
        bool enabled = GetPropertyValue<bool>(property, showWhen.ConditionPropertyName);

        if (showWhen.CheckEnabled == enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowWhenAttribute showWhen = attribute as ShowWhenAttribute;
        bool enabled = GetPropertyValue<bool>(property, showWhen.ConditionPropertyName);

        if (showWhen.CheckEnabled == enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        else
        {
            return 0f;
        }
    }

  private T GetPropertyValue<T>(SerializedProperty property, string propertyName)
{
    SerializedObject serializedObject = property.serializedObject;
    SerializedProperty conditionProperty = serializedObject.FindProperty(propertyName);

    return conditionProperty != null ? (T)GetTargetObjectOfProperty(conditionProperty) : default(T);
}

private object GetTargetObjectOfProperty(SerializedProperty property)
{
    if (property == null)
        return null;

    string path = property.propertyPath.Replace(".Array.data[", "[");
    object targetObject = property.serializedObject.targetObject;
    string[] elements = path.Split('.');

    foreach (string element in elements)
    {
        if (element.Contains("["))
        {
            string elementName = element.Substring(0, element.IndexOf("["));
            int index = System.Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
            targetObject = GetValue_Imp(targetObject, elementName, index);
        }
        else
        {
            targetObject = GetValue_Imp(targetObject, element);
        }
    }

    return targetObject;
}

private object GetValue_Imp(object source, string name)
{
    if (source == null)
        return null;

    System.Type type = source.GetType();

    while (type != null)
    {
        System.Reflection.FieldInfo fieldInfo = type.GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        if (fieldInfo != null)
            return fieldInfo.GetValue(source);

        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
        if (propertyInfo != null)
            return propertyInfo.GetValue(source, null);

        type = type.BaseType;
    }

    return null;
}

private object GetValue_Imp(object source, string name, int index)
{
    System.Collections.IEnumerable enumerable = GetValue_Imp(source, name) as System.Collections.IEnumerable;
    if (enumerable == null)
        return null;

    System.Collections.IEnumerator enumerator = enumerable.GetEnumerator();
    for (int i = 0; i <= index; i++)
    {
        if (!enumerator.MoveNext())
            return null;
    }

    return enumerator.Current;
}

}
