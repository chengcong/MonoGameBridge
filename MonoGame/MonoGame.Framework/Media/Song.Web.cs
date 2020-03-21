// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using static Retyped.dom;

namespace Microsoft.Xna.Framework.Media
{
    public sealed partial class Song : IEquatable<Song>, IDisposable
    {
        private HTMLAudioElement _audio;

        private void PlatformInitialize(string fileName)
        {
            Content.ContentManager.BlockContentLoaading = true;

            _audio = new HTMLAudioElement();
            _audio.oncanplaythrough += (e) => Content.ContentManager.BlockContentLoaading = false;
            _audio.src = fileName;
            _audio.load();

            _duration = TimeSpan.FromSeconds(_audio.duration);

            _audio.onended += (e) => MediaPlayer.OnSongFinishedPlaying(null, null);
        }
        
        internal void SetEventHandler(FinishedPlayingHandler handler) { }
		
        void PlatformDispose(bool disposing)
        {

        }

        internal void Play(TimeSpan? startPosition)
        {
            if (startPosition.HasValue)
                _audio.currentTime = startPosition.Value.Seconds;

            _audio.play();
            _playCount++;
        }

        internal void Resume()
        {
            _audio.play();
        }

        internal void Pause()
        {
            _audio.pause();
        }

        internal void Stop()
        {
            _audio.currentTime = 0;
            _audio.pause();
            _playCount = 0;
        }

        internal float Volume
        {
            get => (float)_audio.volume;
            set => _audio.volume = value;
        }

        public TimeSpan Position
        {
            get => TimeSpan.FromSeconds(_audio.currentTime);
        }

        private Album PlatformGetAlbum()
        {
            return null;
        }

        private Artist PlatformGetArtist()
        {
            return null;
        }

        private Genre PlatformGetGenre()
        {
            return null;
        }

        private TimeSpan PlatformGetDuration()
        {
            return _duration;
        }

        private bool PlatformIsProtected()
        {
            return false;
        }

        private bool PlatformIsRated()
        {
            return false;
        }

        private string PlatformGetName()
        {
            return _name;
        }

        private int PlatformGetPlayCount()
        {
            return _playCount;
        }

        private int PlatformGetRating()
        {
            return 0;
        }

        private int PlatformGetTrackNumber()
        {
            return 0;
        }
    }
}