using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CEC RID: 11500
[NullableContext(1)]
[Nullable(0)]
public class VolumeView : UiViewBase
{
	// Token: 0x060172F6 RID: 94966 RVA: 0x0066CC5F File Offset: 0x0066AE5F
	public VolumeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060172F7 RID: 94967 RVA: 0x0066CC70 File Offset: 0x0066AE70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(3, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<float>(this.SetMasterVolume)),
			new ValueTuple<int, Delegate>(1, new Action<float>(this.SetMusicVolume)),
			new ValueTuple<int, Delegate>(2, new Action<float>(this.SetVoiceVolume)),
			new ValueTuple<int, Delegate>(3, new Action<float>(this.SetSfxVolume)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnCloseView)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnPlayMusic)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnPlayVoice)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnPlaySfx)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnPlayAllEvent))
		};
	}

	// Token: 0x060172F8 RID: 94968 RVA: 0x0066CE31 File Offset: 0x0066B031
	protected override void OnStart()
	{
		this.InitVolumceSlider();
	}

	// Token: 0x060172F9 RID: 94969 RVA: 0x0066CE39 File Offset: 0x0066B039
	private void SetChildVolume(float value)
	{
		this.SetMusicVolume(value);
		this.SetVoiceVolume(value);
		this.SetSfxVolume(value);
	}

	// Token: 0x060172FA RID: 94970 RVA: 0x0066CE50 File Offset: 0x0066B050
	private void InitVolumceSlider()
	{
		base.GetSlider(0).SetValue((float)this.MaxVolume, true);
		base.GetSlider(1).SetValue((float)this.MaxVolume, true);
		base.GetSlider(2).SetValue((float)this.MaxVolume, true);
		base.GetSlider(3).SetValue((float)this.MaxVolume, true);
	}

	// Token: 0x060172FB RID: 94971 RVA: 0x0066CEAD File Offset: 0x0066B0AD
	private void SetMasterVolume(float value)
	{
		this.MasterVolume = (int)value;
		this.SetChildVolume(value);
	}

	// Token: 0x060172FC RID: 94972 RVA: 0x0066CEBE File Offset: 0x0066B0BE
	private void SetVoiceVolume(float value)
	{
		this.VoiceVolume = (int)value;
		if (this.VoiceVolume > this.MasterVolume)
		{
			this.VoiceVolume = this.MasterVolume;
		}
		UAkGameplayStatics.SetRTPCValue(null, (float)this.VoiceVolume, 0, null, VolumeView.Vocal_Audio_Bus_Volume);
	}

	// Token: 0x060172FD RID: 94973 RVA: 0x0066CEF6 File Offset: 0x0066B0F6
	private void SetMusicVolume(float value)
	{
		this.MusicVolume = (int)value;
		if (this.MusicVolume > this.MasterVolume)
		{
			this.MusicVolume = this.MasterVolume;
		}
		UAkGameplayStatics.SetRTPCValue(null, (float)this.MusicVolume, 0, null, VolumeView.Music_Audio_Bus_Volume);
	}

	// Token: 0x060172FE RID: 94974 RVA: 0x0066CF2E File Offset: 0x0066B12E
	private void SetSfxVolume(float value)
	{
		this.SfxVolume = (int)value;
		if (this.SfxVolume > this.MasterVolume)
		{
			this.SfxVolume = this.MasterVolume;
		}
		UAkGameplayStatics.SetRTPCValue(null, (float)this.SfxVolume, 0, null, VolumeView.SFX_Audio_Bus_Volume);
	}

	// Token: 0x060172FF RID: 94975 RVA: 0x0066CF66 File Offset: 0x0066B166
	private void OnCloseView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.VolumeView, null);
	}

	// Token: 0x06017300 RID: 94976 RVA: 0x0066CF78 File Offset: 0x0066B178
	private void OnPlayMusic()
	{
		this.PlayAudio("/Game/Aki/WwiseAudio/Events/Default_Work_Unit/Music_Event/Music_Play_Event/Test_Music.Test_Music");
	}

	// Token: 0x06017301 RID: 94977 RVA: 0x0066CF85 File Offset: 0x0066B185
	private void OnPlayVoice()
	{
		this.PlayAudio("/Game/Aki/WwiseAudio/Events/Default_Work_Unit/Vocal_Event/Play_Role_Atk_Vo_Test.Play_Role_Atk_Vo_Test");
	}

	// Token: 0x06017302 RID: 94978 RVA: 0x0066CF92 File Offset: 0x0066B192
	private void OnPlaySfx()
	{
		this.PlayAudio("/Game/Aki/WwiseAudio/Events/Default_Work_Unit/SFX_Event/SFX_Play_Event/Play_Swim_Stand.Play_Swim_Stand");
	}

	// Token: 0x06017303 RID: 94979 RVA: 0x0066CFA0 File Offset: 0x0066B1A0
	private void OnPlayAllEvent()
	{
		this.FileDisplay("/Game/Aki/WwiseAudio/Events");
		this.PlayNum = 0;
		this.FailNum = 0;
		Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.LRA, "开始进行音频播放检测!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.DoPlayAudio();
	}

	// Token: 0x06017304 RID: 94980 RVA: 0x0066CFE8 File Offset: 0x0066B1E8
	private unsafe void DoPlayAudio()
	{
		if (this.FileList != null && this.PlayNum < this.FileList.Num())
		{
			string path = this.FileList.Get(this.PlayNum);
			string audioEventPath = this.DoTruePath(path);
			this.PlayNum++;
			this.PlayAudio(audioEventPath);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LRA;
		string message = "音频播放检测完毕!!!";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("总数", this.FileList.Num().ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实际检测总数", this.PlayNum.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("失败总数", this.FailNum.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06017305 RID: 94981 RVA: 0x0066D0D4 File Offset: 0x0066B2D4
	[NullableContext(2)]
	private void PlayAudio(string audioEventPath)
	{
		AActor playerActor = Global.BaseCharacter;
		if (Singleton<AudioController>.Instance.GetAudioEvent(audioEventPath, false) != null)
		{
			int? num = Singleton<AudioController>.Instance.PlayAudioByEventPath(audioEventPath, playerActor, null, null, null, true, "");
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					goto IL_C3;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LRA;
			string message = "音频播放失败!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", audioEventPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FailNum++;
			IL_C3:
			Singleton<AudioController>.Instance.StopAudio(playerActor);
			this.DoPlayAudio();
			return;
		}
		Singleton<AudioController>.Instance.LoadAndAddCallback(audioEventPath, delegate
		{
			int? num4 = Singleton<AudioController>.Instance.PlayAudioByEventPath(audioEventPath, playerActor, null, null, null, true, "");
			if (num4 != null)
			{
				int? num5 = num4;
				int num6 = 0;
				if (!(num5.GetValueOrDefault() == num6 & num5 != null))
				{
					goto IL_97;
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.LRA;
			string message2 = "音频播放失败!!!";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", audioEventPath);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.FailNum++;
			IL_97:
			Singleton<AudioController>.Instance.StopAudio(playerActor);
			this.DoPlayAudio();
		}, null);
	}

	// Token: 0x06017306 RID: 94982 RVA: 0x0066D1D8 File Offset: 0x0066B3D8
	protected override void OnBeforeDestroy()
	{
		Singleton<AudioController>.Instance.StopAudio(base.GetRootActor());
	}

	// Token: 0x06017307 RID: 94983 RVA: 0x0066D1EC File Offset: 0x0066B3EC
	private void FileDisplay(string filePath)
	{
		this.FileList = UKuroStaticLibrary.FindFilesSorted(filePath, "*");
		List<int> list = new List<int>();
		for (int i = 0; i < this.FileList.Num(); i++)
		{
			if (this.FileList.Get(i).Contains("FOLDER"))
			{
				list.Add(i);
			}
		}
		list.Reverse();
		foreach (int index in list)
		{
			this.FileList.RemoveAt(index);
		}
	}

	// Token: 0x06017308 RID: 94984 RVA: 0x0066D294 File Offset: 0x0066B494
	[return: Nullable(2)]
	private string DoTruePath(string path)
	{
		int num = path.IndexOf('.');
		if (num == -1)
		{
			return null;
		}
		int num2 = path.LastIndexOf('/');
		if (num2 == -1)
		{
			return null;
		}
		string newValue = path.Substring(num2 + 1, num - num2 - 1);
		string text = path.Replace("uasset", newValue);
		int num3 = text.IndexOf("/Aki");
		if (num3 == -1)
		{
			return null;
		}
		string oldValue = text.Substring(0, num3);
		return text.Replace(oldValue, "/Game");
	}

	// Token: 0x0400B265 RID: 45669
	private static readonly FName Vocal_Audio_Bus_Volume = new FName("volume_voice");

	// Token: 0x0400B266 RID: 45670
	private static readonly FName Music_Audio_Bus_Volume = new FName("volume_music");

	// Token: 0x0400B267 RID: 45671
	private static readonly FName SFX_Audio_Bus_Volume = new FName("volume_sfx");

	// Token: 0x0400B268 RID: 45672
	private readonly int MaxVolume = 100;

	// Token: 0x0400B269 RID: 45673
	private int MasterVolume;

	// Token: 0x0400B26A RID: 45674
	private int VoiceVolume;

	// Token: 0x0400B26B RID: 45675
	private int MusicVolume;

	// Token: 0x0400B26C RID: 45676
	private int SfxVolume;

	// Token: 0x0400B26D RID: 45677
	private int PlayNum;

	// Token: 0x0400B26E RID: 45678
	private int FailNum;

	// Token: 0x0400B26F RID: 45679
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> FileList;

	// Token: 0x02008FB3 RID: 36787
	[NullableContext(0)]
	private class EVolumeViewComponent
	{
		// Token: 0x040303C3 RID: 197571
		public const int MasterVolumeSlider = 0;

		// Token: 0x040303C4 RID: 197572
		public const int MusicVolumeSlider = 1;

		// Token: 0x040303C5 RID: 197573
		public const int VoiceVolumeSlider = 2;

		// Token: 0x040303C6 RID: 197574
		public const int SfxVolumeSlider = 3;

		// Token: 0x040303C7 RID: 197575
		public const int CloseButton = 4;

		// Token: 0x040303C8 RID: 197576
		public const int MusicButton = 5;

		// Token: 0x040303C9 RID: 197577
		public const int VoiceButton = 6;

		// Token: 0x040303CA RID: 197578
		public const int SFXButton = 7;

		// Token: 0x040303CB RID: 197579
		public const int PlayAllEventButton = 8;
	}
}
