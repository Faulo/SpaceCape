﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeable 
{
    TimeScale timeScale { get; set; }
    AudioSource sfx { get; set; }
}
