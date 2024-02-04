using UnityEngine;

namespace SpaceCape {
    public interface ITimeable {
        TimeScale timeScale { get; set; }
        AudioSource sfx { get; set; }
    }
}