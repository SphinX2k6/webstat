using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004513 RID: 17683
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixSceneManager : IStaticVariableResetter
	{
		// Token: 0x0602E970 RID: 190832 RVA: 0x00B09FD7 File Offset: 0x00B081D7
		static HotFixSceneManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(HotFixSceneManager.CreateStaticDefaultValue), new Action(HotFixSceneManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602E971 RID: 190833 RVA: 0x00B0A016 File Offset: 0x00B08216
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602E972 RID: 190834 RVA: 0x00B0A018 File Offset: 0x00B08218
		public static void ResetStaticDefaultValue()
		{
			HotFixSceneManager.Camera = null;
			HotFixSceneManager.BgmAudioId = null;
			HotFixSceneManager.AudioEvent = null;
		}

		// Token: 0x0602E973 RID: 190835 RVA: 0x00B0A034 File Offset: 0x00B08234
		public void SetupScene(UObject worldContext)
		{
			this.WorldContext = worldContext;
			int hour = UKismetMathLibrary.GetHour(UKismetMathLibrary.Now());
			UKuroRenderingRuntimeBPPluginBPLibrary.SetGlobalGITime(this.WorldContext, (float)hour);
			HotFixSceneManager.SpawnCamera(worldContext);
			HotFixSceneManager.SetViewTarget(worldContext);
			this.PlayHotPatchBgm();
		}

		// Token: 0x0602E974 RID: 190836 RVA: 0x00B0A073 File Offset: 0x00B08273
		public void Destroy()
		{
			this.DestroySequence();
		}

		// Token: 0x0602E975 RID: 190837 RVA: 0x00B0A07C File Offset: 0x00B0827C
		protected static void SpawnCamera(UObject worldContext)
		{
			TSubclassOf<AActor> actorClass = ACineCameraActor.StaticClass();
			FTransformDouble ftransformDouble = new FTransformDouble();
			ACineCameraActor acineCameraActor = UKuroRenderingRuntimeBPPluginBPLibrary.D_SpawnActorFromClass(worldContext, actorClass, ftransformDouble, ESpawnActorCollisionHandlingMethod.Undefined, null, null, true) as ACineCameraActor;
			acineCameraActor.CameraComponent.bConstrainAspectRatio = false;
			acineCameraActor.GetCineCameraComponent().SetFilmbackPresetByName("16:9 DSLR");
			HotFixSceneManager.Camera = acineCameraActor;
		}

		// Token: 0x0602E976 RID: 190838 RVA: 0x00B0A0CC File Offset: 0x00B082CC
		public static void SetViewTarget(UObject worldContext)
		{
			APlayerController playerController = UGameplayStatics.GetPlayerController(worldContext, 0);
			if (playerController == null)
			{
				Singleton<LauncherLog>.Instance.Error("PlayerController为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			playerController.SetViewTargetWithBlend(HotFixSceneManager.Camera, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, false, false);
		}

		// Token: 0x0602E977 RID: 190839 RVA: 0x00B0A118 File Offset: 0x00B08318
		[NullableContext(2)]
		public void PlayBlackSeq(Action finishCallback)
		{
			ULevelSequence ulevelSequence = Singleton<LauncherResourceLib>.Instance.Load<ULevelSequence>("/Game/Aki/HotPatch/Sequence/XuanJue1_Black.XuanJue1_Black", 100, "js_call_launch");
			if (ulevelSequence == null || !ulevelSequence.IsValid())
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "热更场景开幕黑屏Sequence加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/HotPatch/Sequence/XuanJue1_Black.XuanJue1_Black");
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (finishCallback != null)
				{
					finishCallback();
				}
				return;
			}
			ALevelSequenceActor alevelSequenceActor = new ALevelSequenceActor();
			ULevelSequencePlayer.CreateLevelSequencePlayer(this.WorldContext, ulevelSequence, new FMovieSceneSequencePlaybackSettings(), ref alevelSequenceActor);
			if (finishCallback != null)
			{
				alevelSequenceActor.SequencePlayer.OnFinished.Add(finishCallback);
			}
			alevelSequenceActor.SequencePlayer.Play();
			Singleton<LauncherLog>.Instance.Info("热更场景开幕黑屏Sequence播放", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E978 RID: 190840 RVA: 0x00B0A1CC File Offset: 0x00B083CC
		public void PlayStartLaunchSeq()
		{
			ULevelSequence ulevelSequence = Singleton<LauncherResourceLib>.Instance.Load<ULevelSequence>("/Game/Aki/HotPatch/Sequence/XuanJue1_Sky.XuanJue1_Sky", 100, "js_call_launch");
			if (ulevelSequence == null || !ulevelSequence.IsValid())
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "热更场景循环Sequence加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/HotPatch/Sequence/XuanJue1_Sky.XuanJue1_Sky");
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ALevelSequenceActor startSequence = new ALevelSequenceActor();
			ULevelSequencePlayer.CreateLevelSequencePlayer(this.WorldContext, ulevelSequence, new FMovieSceneSequencePlaybackSettings(), ref startSequence);
			this.StartSequence = startSequence;
			this.StartSequence.ResetBindings();
			this.StartSequence.AddBindingByTag(HotFixSceneManager.SEQUNCE_CAMERA_NAME, HotFixSceneManager.Camera, false, false);
			this.StartSequence.SequencePlayer.PlayLooping(-1);
			Singleton<LauncherLog>.Instance.Info("热更场景循环Sequence播放", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E979 RID: 190841 RVA: 0x00B0A290 File Offset: 0x00B08490
		private void DestroySequence()
		{
			Singleton<LauncherLog>.Instance.Info("热更场景结束", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E97A RID: 190842 RVA: 0x00B0A2B8 File Offset: 0x00B084B8
		public static void StopHotPatchBgm()
		{
			if (HotFixSceneManager.AudioEvent != null)
			{
				UAkGameplayStatics.ExecuteActionOnEvent(HotFixSceneManager.AudioEvent, EAkActionOnEventType.Stop, null, 1500, EAkCurveInterpolation.Linear, 0);
				HotFixSceneManager.AudioEvent = null;
			}
			if (HotFixSceneManager.BgmAudioId != null)
			{
				HotFixSceneManager.BgmAudioId = null;
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "背景音乐销毁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/WwiseAudio/Events/play_login_bgm.play_login_bgm");
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E97B RID: 190843 RVA: 0x00B0A323 File Offset: 0x00B08523
		public void PlayHotPatchBgm()
		{
			Singleton<LauncherResourceLib>.Instance.LoadAsync<UAkAudioEvent>("/Game/Aki/WwiseAudio/Events/play_login_bgm.play_login_bgm", delegate([Nullable(2)] UAkAudioEvent audioEvent, string path)
			{
				HotFixSceneManager.AudioEvent = audioEvent;
				if (audioEvent == null || !audioEvent.IsValid())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "背景音乐加载有问题";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/WwiseAudio/Events/play_login_bgm.play_login_bgm");
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				AActor actor = null;
				int callbackMask = 0;
				FOnAkPostEventCallback fonAkPostEventCallback = null;
				HotFixSceneManager.BgmAudioId = new int?(UAkGameplayStatics.PostEvent(audioEvent, actor, callbackMask, fonAkPostEventCallback, false, ""));
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "播放背景音乐";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", "/Game/Aki/WwiseAudio/Events/play_login_bgm.play_login_bgm");
				instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}, 0, "Launch.Audio");
		}

		// Token: 0x0401A772 RID: 108402
		private const string BLACK_SEQUENCE = "/Game/Aki/HotPatch/Sequence/XuanJue1_Black.XuanJue1_Black";

		// Token: 0x0401A773 RID: 108403
		private const string HOTPATCH_START_SEQUENCE = "/Game/Aki/HotPatch/Sequence/XuanJue1_Sky.XuanJue1_Sky";

		// Token: 0x0401A774 RID: 108404
		private const string HOTPATCH_BGM = "/Game/Aki/WwiseAudio/Events/play_login_bgm.play_login_bgm";

		// Token: 0x0401A775 RID: 108405
		[StaticVariableRuleIgnore]
		private static readonly FName SEQUNCE_CAMERA_NAME = new FName("SequenceCamera");

		// Token: 0x0401A776 RID: 108406
		private const int HOTPATCH_BGM_FADE_TIME = 1500;

		// Token: 0x0401A777 RID: 108407
		[Nullable(2)]
		private UObject WorldContext;

		// Token: 0x0401A778 RID: 108408
		[Nullable(2)]
		private static AActor Camera;

		// Token: 0x0401A779 RID: 108409
		[Nullable(2)]
		private ALevelSequenceActor StartSequence;

		// Token: 0x0401A77A RID: 108410
		private static int? BgmAudioId = null;

		// Token: 0x0401A77B RID: 108411
		[Nullable(2)]
		private static UAkAudioEvent AudioEvent = null;
	}
}
