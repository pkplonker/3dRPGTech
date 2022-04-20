namespace Save
{
    public interface ISaveLoadInterface 
    {
        public void LoadState(GameData gameData);
        public void SaveState(GameData gameData);

        public void OnEnable()
        {
            SavingSystem.instance.Subscribe(this);
        }
    }
}
