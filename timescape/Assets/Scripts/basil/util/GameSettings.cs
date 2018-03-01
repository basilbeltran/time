using UnityEngine;

class GameSettings : MonoBehaviour
{
  // Parameters, set via the inspector
  [SerializeField]
  private int difficulty;
 
  // Public interface
  public static int Difficulty
  {
    get { return Current.difficulty; }
  }
 
  // Current instance management
  private static GameSettings _current;
  private static GameSettings Current
  {
    get
    {
      if(_current == null)
        Debug.LogError("Attempting to access GameSettings before it's been created.");
      return _current;
    }
  }
 
  void Awake ()
  {
    if(_current != null)
      Debug.LogError("More than one copy of GameSettings exists.");
    _current = this;
  }
 
  void OnDestroy ()
  {
    _current = null;
  }
}
