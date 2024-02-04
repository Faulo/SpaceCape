namespace SpaceCape.Items {
    public interface ITransitionable {
        void OnReverse();
        void OnForward();
        void OnSlower();
    }
}