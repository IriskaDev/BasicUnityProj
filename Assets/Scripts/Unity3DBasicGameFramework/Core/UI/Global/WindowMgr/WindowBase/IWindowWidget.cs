
public interface IWindowWidget
{
    void Init();
    void StartUp(object param = null);
    void StartListener();
    void RemoveListener();
    void Clear();
}
