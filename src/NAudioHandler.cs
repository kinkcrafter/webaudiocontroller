using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WebAudioController
{
    public class NAudioHandler
    {
        // Audio/Voice out
        SampleChannel audioOutSampler;
        WaveOutEvent audioOut = new WaveOutEvent();
        SampleChannel voiceReplaySampler;
        WaveOutEvent voiceReplayOut = new WaveOutEvent();
        WaveOutEvent noiseOut = new WaveOutEvent();
        WaveOutEvent voiceOut = new WaveOutEvent();

        AudioFileReader audioFileReader;

        public bool muted = false;
        private bool busy = false;
        public bool liveVoice = false;

        private string audioPlaylist = string.Empty;
        private string playbackPlaylist = string.Empty;
        public static WACAudioFile currentSong;
        private WACAudioFile nextSong;
        public static WACAudioFile currentPlayback;

        public OutputMode currentOutputMode = OutputMode.stopped;
        private OutputMode nextOutputMode = OutputMode.stopped;
        
        // Signal Generators
        // todo: more generators if possible...
        #region Signal Generators
        double noiseGeneratorGains = 0.2f;

        SignalGenerator nextGenerator;

        SignalGenerator whiteGenerator = new SignalGenerator()
        {
            Gain = 0.2,
            Type = SignalGeneratorType.White
        };

        SignalGenerator pinkGenerator = new SignalGenerator()
        {
            Gain = 0.2,
            Type = SignalGeneratorType.Pink
        };
        #endregion

        public NAudioHandler()
        {
            timerFadeOut.Interval = 100;
            timerFadeOut.Elapsed += new ElapsedEventHandler(timerFadeOut_Tick);

            timerFadeIn.Interval = 100;
            timerFadeIn.Elapsed += new ElapsedEventHandler(timerFadeIn_Tick);
        }

        public string ProcessCommand(AudioCommand command, string argument1 = "", string argument2 = "")
        {
            if(muted && command != AudioCommand.Mute)
            {
                return "Muted";
            }

            switch (command)
            {
                case AudioCommand.Stop:
                    {
                        return Stop();
                    }
                case AudioCommand.Mute:
                    {
                        return ToggleMute();
                    }
                case AudioCommand.WhiteNoise:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return WhiteNoise();
                    }
                case AudioCommand.PinkNoise:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return PinkNoise();
                    }
                case AudioCommand.PlayAudio:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return PlayAudio(argument1, argument2);
                    }
                case AudioCommand.PlayVoice:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return PlayPlayback(argument1, argument2);
                    }
                case AudioCommand.PlayLiveVoice:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return PlayLiveVoice(argument1);
                    }
                case AudioCommand.SetVolume:
                    {
                        return SetVolume(argument1);
                    }
                case AudioCommand.SetAudioMode:
                    {
                        if (busy)
                        {
                            return $"Busy {MainForm.StatusText}";
                        }
                        return SetAudioMode(argument1);
                    }
                default:
                    break;
            }

            return "something";
        }

        private string SetAudioMode(string argument)
        {
            throw new NotImplementedException();
        }

        private string SetVolume(string argument)
        {
            throw new NotImplementedException();
        }

        public static string noiseColor = string.Empty;

        private string WhiteNoise()
        {
            noiseColor = "White";
            TransitionToGenerator(whiteGenerator);
            return "Playing White Noise";
        }

        private string PinkNoise()
        {
            noiseColor = "Pink";
            TransitionToGenerator(pinkGenerator);
            return "Playing Pink Noise";
        }

        private string Stop()
        {
            nextOutputMode = OutputMode.stopped;
            FadeOutSound();
            return "Stopped";
        }

        #region audio handling
        private string PlayAudio(string playlistName, string songName)
        {
            currentSong = MainForm.currentPreference.AudioPlaylists.First(x => x.PlaylistName == playlistName).Playlist.First(y => y.DisplayName == songName);

            string filePath = currentSong.FilePath;

            audioPlaylist = playlistName;

            if (File.Exists(filePath))
            {
                audioFileReader = new AudioFileReader(filePath);

                nextOutputMode = OutputMode.audio;

                FadeOutSound();

                return "Playing";
            }

            return "Could not find"; 
        }

        private string PlayLiveVoice(string filePath)
        {
            if (File.Exists(filePath))
            {
                WACAudioFile liveVoiceFile = new WACAudioFile(filePath, "Live Voice");

                currentPlayback = liveVoiceFile;

                liveVoice = true;

                FadeOutSound();

                MainForm.StatusText = $"Playing {liveVoiceFile.DisplayName}";

                audioFileReader = new AudioFileReader(filePath);

                voiceOut = new WaveOutEvent();

                voiceOut.PlaybackStopped += voiceOut_PlaybackStopped;

                voiceOut.Init(audioFileReader);

                voiceOut.Play();

                return "Playing";
            }

            return "Error Playing Live Voice";
        }

        private string PlayPlayback(string playlistName, string displayName)
        {
            // todo: do we need our own file reader????

            currentPlayback = MainForm.currentPreference.PlaybackPlaylists.First(x => x.PlaylistName == playlistName).Playlist.First(y => y.DisplayName == displayName);

            string filePath = currentPlayback.FilePath;

            playbackPlaylist = playlistName;

            if (File.Exists(filePath))
            {
                liveVoice = true;

                FadeOutSound();

                MainForm.StatusText = $"Playing {displayName}";

                audioFileReader = new AudioFileReader(filePath);

                voiceOut = new WaveOutEvent();

                voiceOut.PlaybackStopped += voiceOut_PlaybackStopped;

                voiceOut.Init(audioFileReader);

                voiceOut.Play();

                return "Playing";
            }

            return "Could not find";

        }

        // Basically continue playing whatever
        private void voiceOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            liveVoice = false;

            busy = false;

            if (currentOutputMode != OutputMode.stopped)
            {
                FadeInSound();
            }
        }

        #endregion

        #region Muting/Unmuting
        private string ToggleMute()
        {
            muted = !muted;

            if (muted)
            {
                if(audioOutSampler != null)
                    audioOutSampler.Volume = 0;
                if(voiceReplaySampler != null)
                    voiceReplaySampler.Volume = 0;
                noiseOut.Volume = 0;

                return "Muted";
            }
            else
            {
                if (audioOutSampler != null)
                    audioOutSampler.Volume = 1;
                if (voiceReplaySampler != null)
                    voiceReplaySampler.Volume = 1;
                noiseOut.Volume = 1;

                return "Unmuted";
            }
        }
        #endregion

        #region Audio Out Handling
        private void TransitionToGenerator(SignalGenerator newGenerator)
        {
            nextGenerator = newGenerator;

            nextOutputMode = OutputMode.noise;

            FadeOutSound();
        }

        int audioFadeOutSteps = 0;
        int audioFadeInSteps = 0;
        Timer timerFadeOut = new Timer();
        Timer timerFadeIn = new Timer();

        private void FadeOutSound()
        {
            busy = true;

            switch (currentOutputMode)
            {
                case OutputMode.audio:
                case OutputMode.noise:
                    //case OutputMode.voiceReplay:
                    {
                        audioFadeOutSteps = 20;
                        timerFadeOut.Start();
                        break;
                    }
                case OutputMode.stopped:
                    {
                        timerFadeOut.Start();
                        break;
                    }
                default:
                    break;
            }
        }

        private void FadeInSound()
        {
            if (liveVoice)
                return;

            currentOutputMode = nextOutputMode;

            switch (nextOutputMode)
            {
                case OutputMode.stopped:
                    {
                        //MainForm.StatusText = "Stopped";

                        // voiceOut.Stop();
                        audioOut.Stop();
                        voiceReplayOut.Stop();
                        noiseOut.Stop();
                        busy = false;
                        break;
                    }
                case OutputMode.audio:
                    {
                        //MainForm.StatusText = $"Playing {currentSong.DisplayName}";
                        //audioOut.Stop();
                        voiceReplayOut.Stop();
                        noiseOut.Stop();
                        busy = false;
                        break;
                    }
                case OutputMode.noise:
                    {
                        //MainForm.StatusText = $"Generating {noiseColor} Noise";
                        audioOut.Stop();
                        voiceReplayOut.Stop();
                        //noiseOut.Stop();
                        busy = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            switch (nextOutputMode)
            {
                case OutputMode.stopped:
                    {
                        break;
                    }
                case OutputMode.audio:
                case OutputMode.noise:
                    {
                        audioFadeInSteps = 20;

                        timerFadeIn.Start();
                        busy = false;
                        break;
                    };
                default:
                    {
                        break;
                    }
            }
        }

        private void PrepNextAudioType()
        {
            if (liveVoice)
            {
                return;
            }

            switch (nextOutputMode)
            {
                case OutputMode.audio:
                    {
                        Debug.WriteLine($"Changing Audio to {currentSong.DisplayName}");

                        audioOutSampler = new SampleChannel(audioFileReader);
                        audioOut.PlaybackStopped -= audioOut_PlaybackStopped;
                        audioOut = new WaveOutEvent();
                        audioOut.Init(audioOutSampler);
                        audioOut.PlaybackStopped -= audioOut_PlaybackStopped;
                        audioOut.PlaybackStopped += audioOut_PlaybackStopped;
                        audioOut.Play();
                        busy = false;

                        FadeInSound();

                        break;
                    }
                case OutputMode.noise:
                    {
                        noiseGeneratorGains = 0.0001f;
                        nextGenerator.Gain = noiseGeneratorGains;
                        pinkGenerator.Gain = noiseGeneratorGains;
                        whiteGenerator.Gain = noiseGeneratorGains;
                        noiseOut = new WaveOutEvent();
                        noiseOut.Init(nextGenerator);
                        noiseOut.Play();
                        busy = false;

                        FadeInSound();

                        break;
                    }
                default:
                    {
                        currentOutputMode = nextOutputMode;

                        busy = false;

                        FadeInSound();
                        break;
                    }
            }
        }

        private void timerFadeOut_Tick(object sender, ElapsedEventArgs e)
        {
            switch (currentOutputMode)
            {
                case OutputMode.audio:
                    {

                        if (audioFadeOutSteps != 0)
                        {
                            var newVolume = audioOutSampler.Volume * 0.7f;

                            audioOutSampler.Volume = newVolume;

                            audioFadeOutSteps--;
                        }
                        else
                        {
                            timerFadeOut.Stop();

                            PrepNextAudioType();
                        }

                        break;
                    }
                case OutputMode.noise:
                    {

                        if (audioFadeOutSteps != 0)
                        {
                            var newVolume = noiseGeneratorGains * 0.7f;

                            noiseGeneratorGains = newVolume;
                            whiteGenerator.Gain = noiseGeneratorGains;
                            pinkGenerator.Gain = noiseGeneratorGains;

                            audioFadeOutSteps--;
                        }
                        else
                        {
                            timerFadeOut.Stop();

                            PrepNextAudioType();
                        }

                        break;
                    }
                default:
                    {
                        timerFadeOut.Stop();
                        audioOut.Stop();
                        voiceReplayOut.Stop();
                        noiseOut.Stop();

                        audioFadeOutSteps = 0;

                        PrepNextAudioType();
                        break;
                    }
            }
        }

        private void timerFadeIn_Tick(object sender, ElapsedEventArgs e)
        {
            switch (nextOutputMode)
            {
                case OutputMode.audio:
                    {
                        if (audioFadeInSteps != 0)
                        {
                            var newVolume = audioOutSampler.Volume * 1.666f;

                            if (newVolume <= 1.0f)
                            {
                                audioOutSampler.Volume = newVolume;
                            }
                            else
                            {
                                timerFadeIn.Stop();
                                audioOutSampler.Volume = 1.0f;
                                MainForm.StatusText = $"Playing {currentSong.DisplayName}";
                                busy = false;
                            }

                            audioFadeInSteps--;
                        }
                        else
                        {
                            timerFadeIn.Stop();
                            audioOutSampler.Volume = 1.0f;
                            MainForm.StatusText = $"Playing {currentSong.DisplayName}";
                            busy = false;
                        }

                        break;
                    }
                case OutputMode.noise:
                    {
                        if (audioFadeInSteps != 0)
                        {
                            var newVolume = nextGenerator.Gain * 1.666f;

                            if (newVolume <= 0.2f)
                            {
                                noiseGeneratorGains = newVolume;
                                whiteGenerator.Gain = noiseGeneratorGains;
                                pinkGenerator.Gain = noiseGeneratorGains;
                            }
                            else
                            {
                                timerFadeIn.Stop();
                                noiseGeneratorGains = 0.2f;
                                whiteGenerator.Gain = noiseGeneratorGains;
                                pinkGenerator.Gain = noiseGeneratorGains;
                                MainForm.StatusText = $"Playing {noiseColor} Noise";
                                busy = false;
                            }

                            audioFadeInSteps--;
                        }
                        else
                        {
                            MainForm.StatusText = $"Playing {noiseColor} Noise";
                            busy = false;

                            timerFadeIn.Stop();
                            noiseGeneratorGains = 0.2f; ;
                            whiteGenerator.Gain = noiseGeneratorGains;
                            pinkGenerator.Gain = noiseGeneratorGains;
                        }

                        break;
                    }
                default:
                    {
                        timerFadeIn.Stop();
                        audioFadeInSteps = 0;
                        busy = false;
                        break;
                    }
            }
        }

        AudioPlayMode audioPlayMode = AudioPlayMode.normal;

        // Play next audio track
        private void audioOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Debug.WriteLine($"Playback Stopped for {currentSong.DisplayName}");

            PlayNextSong();
        }

        private void PlayNextSong()
        {
            if(nextOutputMode != OutputMode.audio)
            {
                return;
            }

            var currentPlaylist = MainForm.currentPreference.AudioPlaylists.First(x => x.PlaylistName == audioPlaylist).Playlist;
            var currentSongIndex =  Array.FindIndex(currentPlaylist, x => x == currentSong);

            // todo: remove this hack once the app is set up!
            audioPlayMode = AudioPlayMode.random;

            if (audioPlayMode == AudioPlayMode.repeat)
            {
                if (File.Exists(currentSong.FilePath))
                {
                    audioFileReader = new AudioFileReader(currentSong.FilePath);

                    nextOutputMode = OutputMode.audio;

                    FadeOutSound();

                    return;
                }
            }

            if (audioPlayMode == AudioPlayMode.random)
            {
                
                if (!string.IsNullOrEmpty(currentSong.FilePath) && MainForm.currentPreference.AudioPlaylists.First(x => x.PlaylistName == audioPlaylist).Playlist.Length > 1)
                {
                    Random rand = new Random();

                    var songIndex = rand.Next(0, currentPlaylist.Length - 1);

                    if (currentSongIndex == songIndex)
                    {
                        songIndex = rand.Next(0, currentPlaylist.Length - 1);
                    }

                    var song = currentPlaylist[songIndex];

                    if (File.Exists(song.FilePath))
                    {
                        currentSong = song;

                        audioFileReader = new AudioFileReader(song.FilePath);

                        nextOutputMode = OutputMode.audio;

                        FadeOutSound();
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentSong.FilePath) && currentPlaylist.Length > 1)
            {
                var songIndex = Array.FindIndex(currentPlaylist, x => x == currentSong);

                songIndex++;

                if (songIndex >= currentPlaylist.Length)
                {
                    songIndex = 0;
                }

                var song = currentPlaylist[songIndex];

                if (File.Exists(song.FilePath))
                {
                    currentSong = song;

                    audioFileReader = new AudioFileReader(song.FilePath);

                    nextOutputMode = OutputMode.audio;

                    FadeOutSound();
                }
            }
        }
        #endregion
    }

    public enum AudioPlayMode
    {
        normal,
        repeat,
        random
    }

    public enum OutputMode
    {
        stopped,
        audio,
        noise,
    }

    public enum AudioCommand
    {
        Stop,
        Mute,
        WhiteNoise,
        PinkNoise,
        PlayAudio,
        PlayVoice,
        PlayLiveVoice,
        SetVolume,
        SetAudioMode
    }
}