using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    // Start is called before the first frame update
    public Vector2 initialValue;
    public Vector2 resetValue;

    public void OnAfterDeserialize() {
        initialValue = resetValue;
    }
    public void OnBeforeSerialize() {

    }
}
