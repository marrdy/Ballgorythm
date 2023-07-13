using UnityEngine;

public class ShowWhenAttribute : PropertyAttribute
{
    public string ConditionPropertyName { get; private set; }
    public bool CheckEnabled { get; private set; }

    public ShowWhenAttribute(string conditionPropertyName, bool checkEnabled)
    {
        ConditionPropertyName = conditionPropertyName;
        CheckEnabled = checkEnabled;
    }
}
