using System;

public class BuffStruct
{
   public int duration;
   public Action OnBuffAdd;  //(ICharacterStats character)
   public ICharacterStats character;
    public Action OnBuffRemove;
    public Action OnTurnPassed;
  
    public BuffStruct (int dura=1,ICharacterStats chara = null, Action onAdd = null, Action onPassed = null, Action onRemove = null)
    {
        duration = dura;
        character = chara;
        OnBuffAdd = onAdd;
        OnBuffRemove = onRemove;
        OnTurnPassed = onPassed;
    }
    
    public void TurnPassed()
    {
        OnTurnPassed?.Invoke();
        duration--;
        if (duration <= 0)
        {
            OnBuffRemove();
            character.BuffRemove(this);
        }
    }

}
