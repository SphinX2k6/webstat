using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200343B RID: 13371
[NullableContext(1)]
[Nullable(0)]
public class UiBehaviorGachaSequence : IUiBehavior
{
	// Token: 0x0601C065 RID: 114789 RVA: 0x0085B180 File Offset: 0x00859380
	public UniTask OnUiCreateAsync()
	{
		UiBehaviorGachaSequence.<OnUiCreateAsync>d__8 <OnUiCreateAsync>d__;
		<OnUiCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnUiCreateAsync>d__.<>1__state = -1;
		<OnUiCreateAsync>d__.<>t__builder.Start<UiBehaviorGachaSequence.<OnUiCreateAsync>d__8>(ref <OnUiCreateAsync>d__);
		return <OnUiCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C066 RID: 114790 RVA: 0x0085B1BC File Offset: 0x008593BC
	public void OnAfterUiStart()
	{
		this.NeedProcessSkyBlending = (UKismetSystemLibrary.GetConsoleVariableIntValue("r.SkyBlending.AllowSettingLerpPerFrame") == 0);
		if (this.NeedProcessSkyBlending)
		{
			UKuroSequencePerformanceManager.SimpleExecuteCommand("r.SkyBlending.AllowSettingLerpPerFrame 1");
		}
		if (Singleton<Info>.Instance.IsMacPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.AllowHardwareOcclusion 0", null);
		}
		if (Singleton<Info>.Instance.IsLowMemoryDevice)
		{
			this.OriginDepthOfFieldQuality = UKismetSystemLibrary.GetConsoleVariableIntValue("r.DepthOfFieldQuality");
			if (this.OriginDepthOfFieldQuality != 0)
			{
				UKuroSequencePerformanceManager.SimpleExecuteCommand("r.DepthOfFieldQuality 0");
			}
		}
		ControllerBase<MenuController>.Instance.CloseAllFilter();
	}

	// Token: 0x0601C067 RID: 114791 RVA: 0x0085B242 File Offset: 0x00859442
	public void OnAfterUiShow()
	{
	}

	// Token: 0x0601C068 RID: 114792 RVA: 0x0085B244 File Offset: 0x00859444
	public void OnBeforeUiHide()
	{
	}

	// Token: 0x0601C069 RID: 114793 RVA: 0x0085B246 File Offset: 0x00859446
	public void BindUpdateInteractBp(BP_UpdateInteract_C bp)
	{
		this.UpdateInteractBp = bp;
		this.UpdateInteractBp.SetTickableWhenPaused(true);
	}

	// Token: 0x0601C06A RID: 114794 RVA: 0x0085B25B File Offset: 0x0085945B
	public void BindSceneSequenceCamera(AActor camera)
	{
		this.SceneSequenceCamera = camera;
	}

	// Token: 0x0601C06B RID: 114795 RVA: 0x0085B264 File Offset: 0x00859464
	public void BindEmptySequenceCamera(AActor camera)
	{
		this.SceneEmptyCamera = camera;
	}

	// Token: 0x0601C06C RID: 114796 RVA: 0x0085B270 File Offset: 0x00859470
	public UniTask PreloadLevelSequenceList(List<int> roleIdList)
	{
		UiBehaviorGachaSequence.<PreloadLevelSequenceList>d__15 <PreloadLevelSequenceList>d__;
		<PreloadLevelSequenceList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadLevelSequenceList>d__.<>4__this = this;
		<PreloadLevelSequenceList>d__.roleIdList = roleIdList;
		<PreloadLevelSequenceList>d__.<>1__state = -1;
		<PreloadLevelSequenceList>d__.<>t__builder.Start<UiBehaviorGachaSequence.<PreloadLevelSequenceList>d__15>(ref <PreloadLevelSequenceList>d__);
		return <PreloadLevelSequenceList>d__.<>t__builder.Task;
	}

	// Token: 0x0601C06D RID: 114797 RVA: 0x0085B2BC File Offset: 0x008594BC
	public UniTask PreLoadLevelSequence(int roleId)
	{
		UiBehaviorGachaSequence.<PreLoadLevelSequence>d__16 <PreLoadLevelSequence>d__;
		<PreLoadLevelSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreLoadLevelSequence>d__.<>4__this = this;
		<PreLoadLevelSequence>d__.roleId = roleId;
		<PreLoadLevelSequence>d__.<>1__state = -1;
		<PreLoadLevelSequence>d__.<>t__builder.Start<UiBehaviorGachaSequence.<PreLoadLevelSequence>d__16>(ref <PreLoadLevelSequence>d__);
		return <PreLoadLevelSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0601C06E RID: 114798 RVA: 0x0085B308 File Offset: 0x00859508
	public void PlayRoleSequence(int roleId, int releaseRoleIdAfterPlay = 0)
	{
		if (roleId <= 0)
		{
			return;
		}
		ALevelSequenceActor sequenceActor;
		if (!this.LevelSequenceActorCache.TryGetValue(roleId, out sequenceActor) || sequenceActor == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GachaSequencePlayer;
			ELogAuthor author = ELogAuthor.BB;
			string message = "UiBehaviorGachaSequence 未找到SequenceActor";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.RoleShowSequence != null)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.PersonalRootView, true);
			UAkComponent target = null;
			TTimerAction <>9__1;
			Singleton<AudioSystem>.Instance.PostEvent("stop_gacha_role_audio", target, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						ULevelSequencePlayer roleShowSequence = this.RoleShowSequence;
						if (roleShowSequence != null)
						{
							roleShowSequence.Pause();
						}
						ULevelSequencePlayer roleShowSequence2 = this.RoleShowSequence;
						if (roleShowSequence2 != null)
						{
							roleShowSequence2.GoToEndAndStop(EUpdatePositionMethod.Play);
						}
						TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
						TTimerAction action;
						if ((action = <>9__1) == null)
						{
							action = (<>9__1 = delegate(float _)
							{
								this.StartPlaySequence(roleId, sequenceActor);
								Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.PersonalRootView, false);
								if (releaseRoleIdAfterPlay > 0 && releaseRoleIdAfterPlay != roleId)
								{
									this.ReleaseLevelSequenceActor(releaseRoleIdAfterPlay);
								}
							});
						}
						gameplayTimeInstance.Next(action, null, null);
					}
				}
			}));
			return;
		}
		this.StartPlaySequence(roleId, sequenceActor);
		if (releaseRoleIdAfterPlay > 0 && releaseRoleIdAfterPlay != roleId)
		{
			this.ReleaseLevelSequenceActor(releaseRoleIdAfterPlay);
		}
	}

	// Token: 0x0601C06F RID: 114799 RVA: 0x0085B424 File Offset: 0x00859624
	private void StartPlaySequence(int roleId, ALevelSequenceActor sequenceActor)
	{
		if (this.SceneSequenceCamera == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GachaSequencePlayer, ELogAuthor.BB, "未设置SceneSequenceCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(roleId);
		if (gachaTextureInfo == null)
		{
			return;
		}
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("PlaySequence");
		ULevelSequence sequence = sequenceActor.GetSequence();
		UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
		UKuroSequencePerformanceManager.OpenKuroPerformanceMode(sequence);
		ControllerBase<CameraController>.Instance.SetViewTarget(this.SceneSequenceCamera, "UiBehaviorGachaSequence", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		sequenceActor.bOverrideInstanceData = true;
		sequenceActor.SetTickableWhenPaused(!ModelBase<GameModeModel>.Instance.IsMulti);
		sequenceActor.AddBindingByTag(GachaScanView.SCENE_CAMERA_TAG, this.SceneSequenceCamera, false, true);
		UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = sequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
		if (udefaultLevelSequenceInstanceData == null)
		{
			return;
		}
		FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
		udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
		if (gachaTextureInfo.Value.BindPoint != null && gachaTextureInfo.Value.BindPoint.Length > 0)
		{
			udefaultLevelSequenceInstanceData.TransformOriginActor = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(gachaTextureInfo.Value.BindPoint).Value, ECollectActorType.UI);
		}
		else
		{
			AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("KuroUiSceneRoot").Value, ECollectActorType.UI);
			if (actorWithTag != null)
			{
				FTransform transformOrigin2 = UKismetMathLibrary.Conv_TransformDoubleToTransform(actorWithTag.D_GetTransform());
				udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin2;
			}
		}
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(roleId);
		if (roleInfoById == null)
		{
			return;
		}
		BP_UpdateInteract_C updateInteractBp = this.UpdateInteractBp;
		if (updateInteractBp != null)
		{
			updateInteractBp.UpdateGachaShowItem(roleId, (byte)roleInfoById.Value.QualityId);
		}
		this.RoleShowSequence = sequenceActor.SequencePlayer;
		if (this.RoleShowSequence == null)
		{
			return;
		}
		FFrameTime time = this.RoleShowSequence.GetStartTime().Time;
		this.RoleShowSequence.SetPlaybackPosition(new FMovieSceneSequencePlaybackParams(time, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Jump));
		this.RoleShowSequence.PlayTo(new FMovieSceneSequencePlaybackParams(time, 0f, "A", EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play));
		PersonalUtil.ApplyTickableWhenPausedOnRuntimeBindings(sequenceActor, true);
	}

	// Token: 0x0601C070 RID: 114800 RVA: 0x0085B654 File Offset: 0x00859854
	public void PlayEmptySequence()
	{
		if (this.SceneEmptyCamera == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GachaSequencePlayer, ELogAuthor.BB, "未设置SceneEmptyCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.StopCurrentSequence();
		BP_UpdateInteract_C updateInteractBp = this.UpdateInteractBp;
		if (updateInteractBp != null)
		{
			updateInteractBp.UpdateGachaShowItem(3, 4);
		}
		ControllerBase<CameraController>.Instance.SetViewTarget(this.SceneEmptyCamera, "RoleNewJoinView.SceneEmptyCamera", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
	}

	// Token: 0x0601C071 RID: 114801 RVA: 0x0085B6D8 File Offset: 0x008598D8
	public void StopCurrentSequence()
	{
		if (this.RoleShowSequence != null)
		{
			this.RoleShowSequence.Pause();
			this.RoleShowSequence.GoToEndAndStop(EUpdatePositionMethod.Play);
			Singleton<AudioSystem>.Instance.PostEvent("stop_gacha_role_audio");
		}
	}

	// Token: 0x0601C072 RID: 114802 RVA: 0x0085B70C File Offset: 0x0085990C
	public void SetSequencePlayBackSetting(int roleId, FMovieSceneSequencePlaybackSettings setting)
	{
		ALevelSequenceActor alevelSequenceActor;
		if (!this.LevelSequenceActorCache.TryGetValue(roleId, out alevelSequenceActor) || alevelSequenceActor == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GachaSequencePlayer;
			ELogAuthor author = ELogAuthor.BB;
			string message = "UiBehaviorGachaSequence 未找到SequenceActor";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		alevelSequenceActor.PlaybackSettings = setting;
	}

	// Token: 0x0601C073 RID: 114803 RVA: 0x0085B760 File Offset: 0x00859960
	public void ReleaseLevelSequenceActor(int roleId)
	{
		ALevelSequenceActor alevelSequenceActor;
		this.LevelSequenceActorCache.TryGetValue(roleId, out alevelSequenceActor);
		if (alevelSequenceActor == null)
		{
			return;
		}
		ULevelSequence sequence = alevelSequenceActor.GetSequence();
		if (sequence != null)
		{
			UKuroSequenceRuntimeFunctionLibrary.HandleSeqTexStreaming(sequence, false, true);
		}
		UKuroActorManager.DestroyActor(alevelSequenceActor);
		this.LevelSequenceActorCache.Remove(roleId);
		if (this.MeshStreamTaskMap.ContainsKey(roleId))
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskMap.GetValueOrNull(roleId).Value);
			this.MeshStreamTaskMap.Remove(roleId);
		}
	}

	// Token: 0x0601C074 RID: 114804 RVA: 0x0085B7E0 File Offset: 0x008599E0
	public void OnBeforeDestroy()
	{
		this.StopCurrentSequence();
		BP_UpdateInteract_C updateInteractBp = this.UpdateInteractBp;
		if (updateInteractBp != null)
		{
			updateInteractBp.EndGachaScene();
		}
		foreach (ALevelSequenceActor alevelSequenceActor in this.LevelSequenceActorCache.Values)
		{
			if (alevelSequenceActor != null)
			{
				ULevelSequence sequence = alevelSequenceActor.GetSequence();
				if (sequence != null)
				{
					UKuroSequenceRuntimeFunctionLibrary.HandleSeqTexStreaming(sequence, false, true);
				}
				UKuroActorManager.DestroyActor(alevelSequenceActor);
			}
		}
		this.LevelSequenceActorCache.Clear();
		foreach (int taskId in this.MeshStreamTaskMap.Values)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(taskId);
		}
		this.MeshStreamTaskMap.Clear();
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("PlaySequence");
		UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
		if (this.NeedProcessSkyBlending)
		{
			UKuroSequencePerformanceManager.SimpleExecuteCommand("r.SkyBlending.AllowSettingLerpPerFrame 0");
		}
		if (Singleton<Info>.Instance.IsMacPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.AllowHardwareOcclusion 1", null);
		}
		if (Singleton<Info>.Instance.IsLowMemoryDevice && this.OriginDepthOfFieldQuality != 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.DepthOfFieldQuality ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.OriginDepthOfFieldQuality);
			UKuroSequencePerformanceManager.SimpleExecuteCommand(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ControllerBase<MenuController>.Instance.OpenAllFilter();
	}

	// Token: 0x0400E273 RID: 57971
	private bool NeedProcessSkyBlending;

	// Token: 0x0400E274 RID: 57972
	private int OriginDepthOfFieldQuality;

	// Token: 0x0400E275 RID: 57973
	[Nullable(2)]
	public ULevelSequencePlayer RoleShowSequence;

	// Token: 0x0400E276 RID: 57974
	[Nullable(2)]
	private BP_UpdateInteract_C UpdateInteractBp;

	// Token: 0x0400E277 RID: 57975
	[Nullable(2)]
	private AActor SceneEmptyCamera;

	// Token: 0x0400E278 RID: 57976
	[Nullable(2)]
	private AActor SceneSequenceCamera;

	// Token: 0x0400E279 RID: 57977
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, ALevelSequenceActor> LevelSequenceActorCache = new Dictionary<int, ALevelSequenceActor>();

	// Token: 0x0400E27A RID: 57978
	private readonly Dictionary<int, int> MeshStreamTaskMap = new Dictionary<int, int>();
}
