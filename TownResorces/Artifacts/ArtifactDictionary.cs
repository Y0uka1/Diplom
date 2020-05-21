using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactDictionary 
{
    public struct Artifact
    {
        delegate void Effect();
        Effect addEffect;
        Effect removeEffect;
        string name;
        int id;
        public void AddEffect()
        {
            addEffect();
        }
        public void RemoveEffect()
        {
            removeEffect();
        }

        Artifact(string name, int id, Effect add, Effect remove)
        {
            this.name = name;
            this.id = id;
            addEffect = add;
            removeEffect = remove;
        }

        

        void Initialize()
        {
            List<Artifact> artifacts = new List<Artifact> { 
                new Artifact("Копье анального угнетения", 0, () => { }, () => { }),
            
            };
        }
    }
    
}
