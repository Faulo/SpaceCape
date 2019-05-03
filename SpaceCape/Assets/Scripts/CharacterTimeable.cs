using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTimeable : MonoBehaviour, ITimeable {
    public TimeScale timeScale {
        get {
            return sanitizedTime;
        }
        set {
            sanitizedTime = value;
        }
    }
    private TimeScale sanitizedTime;

    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (timeScale) {
            case TimeScale.Faster:
                character.Move(character.velocity * Time.deltaTime * 2);
                break;
            case TimeScale.Slower:
                character.Move(character.velocity * Time.deltaTime / -4);
                break;
        }
    }
}
