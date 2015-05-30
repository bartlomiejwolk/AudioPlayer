// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the AudioPlayer extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

namespace AudioPlayerEx {

    public sealed class AudioPlayer : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "AudioPlayer";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "AudioPlayer";
#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        /// <summary>
        /// Audio source components with clips to be played.
        /// </summary>
        [SerializeField]
        private AudioSource[] audioSources;

        [SerializeField]
        private bool playOnStart;

        [SerializeField]
        private float delay;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Audio source components with clips to be played.
        /// </summary>
        public AudioSource[] AudioSources {
            get { return audioSources; }
            set { audioSources = value; }
        }

        /// <summary>
        /// Play sound on Awake.
        /// </summary>
        public bool PlayOnStart {
            get { return playOnStart; }
            set { playOnStart = value; }
        }

        /// <summary>
        /// Delay applied before playing clip in Start().
        /// </summary>
        public float Delay {
            get { return delay; }
            set { delay = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES
        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() {
            if (PlayOnStart) {
                Invoke("PlayRandomClip", Delay);
            }
        }

        private void Update() { }

        private void OnValidate() { }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS
        public void PlayRandomClip() {
            // Number of referenced AudioSource components.
            var audioSourceCount = AudioSources.Length;

            // Draw a random AudioSource.
            var randomFloat = Random.Range(0, audioSourceCount);
            var randomInt = Mathf.RoundToInt(randomFloat);

            // Play sound.
            audioSources[randomInt].Play();
        }

        #endregion METHODS

    }

}
