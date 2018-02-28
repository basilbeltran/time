using UnityEngine;
using System.Collections;

public class FindObjectsOfTypeAll : MonoBehaviour
{
    // This script displays the number of allocated Unity objects by type.
    // This is useful for finding leaks. Knowing the type of object
    // (mesh, texture, sound clip, game object) that is getting leaked is
    // the first step. You could then U.Log the names of all leaked assets of that type.

    void Start()
    {
        U.Log("All " + Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)).Length);
        U.Log("Textures " + Resources.FindObjectsOfTypeAll(typeof(Texture)).Length);
        U.Log("AudioClips " + Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length);
        U.Log("Meshes " + Resources.FindObjectsOfTypeAll(typeof(Mesh)).Length);
        U.Log("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        U.Log("GameObjects " + Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length);
        U.Log("Components " + Resources.FindObjectsOfTypeAll(typeof(Component)).Length);
    }
}
