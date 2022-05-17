using Skintific.Player;
using UnityEditor;
using UnityEngine;

namespace Skintific.Editor
{
    [CustomEditor(typeof(PlayerModel))]
    public class PlayerModelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (PlayerModel)target;
 
            if(GUILayout.Button("Notify", GUILayout.Height(20)))
            {
                script.Notify();
            }
        }
    }
}
