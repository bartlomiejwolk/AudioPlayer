// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the AudioPlayer extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using AudioPlayerEx.ReorderableList;

namespace AudioPlayerEx {

    [CustomEditor(typeof(AudioPlayer))]
    [CanEditMultipleObjects]
    public sealed class AudioPlayerEditor : Editor {
        #region FIELDS

        private AudioPlayer Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty audioSources;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawAudioClipsList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawAudioClipsList() {
            ReorderableListGUI.Title("Audio Sources");
            ReorderableListGUI.ListField(audioSources);
        }

        private void OnEnable() {
            Script = (AudioPlayer)target;

            description = serializedObject.FindProperty("description");
            audioSources = serializedObject.FindProperty("audioSources");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    AudioPlayer.Version,
                    AudioPlayer.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/AudioPlayer")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(AudioPlayer));
            }
        }

        #endregion METHODS
    }

}