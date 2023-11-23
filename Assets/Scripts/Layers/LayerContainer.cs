public struct LayerContainer
{
    private Layer[] _layers;

    public Layer[] Layers => _layers;

    public LayerContainer(Layer[] layers)
    {
        _layers = layers;
    }
}
