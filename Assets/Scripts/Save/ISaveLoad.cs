namespace Save
{
    
    public interface ISaveLoad
    {
        public void LoadState(object data);
        public object SaveState();

       

    }
}
