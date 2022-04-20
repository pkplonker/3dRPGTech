using UnityEngine;

namespace Save
{
    public abstract class SaveableObject : MonoBehaviour, ISaveLoadInterface
    {
        protected virtual void OnEnable()
        {
            SavingSystem.instance.Subscribe(this);
        }

        protected virtual void OnDisable()
        {
            SavingSystem.instance.UnSubscribe(this);
        }

        public virtual void LoadState(GameData gameData)
        {
            Debug.LogWarning("No concrete implementation of interface " + gameObject.name);
        }

        public virtual void SaveState(GameData gameData)
        {
            Debug.LogWarning("No concrete implementation of interface "+ gameObject.name);

        }
    }
}
