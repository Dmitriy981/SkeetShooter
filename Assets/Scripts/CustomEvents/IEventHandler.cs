namespace UIEvents
{
    public interface IEventHandler
    {
        void OnEvent(string eventKey, params object[] pars);
    }
}