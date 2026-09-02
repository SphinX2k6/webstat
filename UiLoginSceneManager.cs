using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002C58 RID: 11352
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiLoginSceneManager : Singleton<UiLoginSceneManager>
{
	// Token: 0x06016C35 RID: 93237 RVA: 0x0065035C File Offset: 0x0064E55C
	public TsUiSceneRoleActor GetRoleObserver(int roleId)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor;
		if (!this.Observers.TryGetValue(roleId, out tsUiSceneRoleActor) && GlobalData.World != null)
		{
			tsUiSceneRoleActor = Singleton<UiSceneRoleActorManager>.Instance.CreateUiSceneRoleActor(EUiModelUseWay.RoleInLogin);
			this.Observers[roleId] = tsUiSceneRoleActor;
		}
		return tsUiSceneRoleActor;
	}

	// Token: 0x06016C36 RID: 93238 RVA: 0x0065039C File Offset: 0x0064E59C
	private void DestroyCreateCharacterObservers()
	{
		foreach (int taskId in this.HuluHandleList)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(taskId);
		}
		foreach (TsUiSceneRoleActor tsUiSceneRoleActor in this.Observers.Values)
		{
			int roleActorIndex = tsUiSceneRoleActor.GetRoleActorIndex();
			Singleton<UiSceneRoleActorManager>.Instance.DestroyUiSceneRoleActor(roleActorIndex);
		}
		this.RoleLoadingFinishList.Clear();
		this.Observers.Clear();
	}

	// Token: 0x06016C37 RID: 93239 RVA: 0x0065045C File Offset: 0x0064E65C
	public void InitCinematicTick()
	{
		this.CinematicTick = Singleton<ActorSystem>.Instance.Get<BP_Cinematics_Tick_C>(BP_Cinematics_Tick_C.StaticClass(), new FTransformDouble(), null, true);
		this.Spotlight1 = Singleton<ActorSystem>.Instance.Get<ASpotLight>(ASpotLight.StaticClass(), new FTransformDouble(), null, true);
		this.Spotlight2 = Singleton<ActorSystem>.Instance.Get<ASpotLight>(ASpotLight.StaticClass(), new FTransformDouble(), null, true);
	}

	// Token: 0x06016C38 RID: 93240 RVA: 0x006504C0 File Offset: 0x0064E6C0
	private void BindCinematicTick()
	{
		IReadOnlyList<int> initialRoles = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles();
		int roleId = initialRoles[0];
		int roleId2 = initialRoles[1];
		this.CinematicTick.UISceneRole_2 = this.GetActorMeshComponent(roleId2);
		this.CinematicTick.UISceneRole = this.GetActorMeshComponent(roleId);
		this.CinematicTick.Is_Tick = 1;
	}

	// Token: 0x06016C39 RID: 93241 RVA: 0x00650516 File Offset: 0x0064E716
	private USkeletalMeshComponent GetActorMeshComponent(int roleId)
	{
		UiModelBase model = this.Observers[roleId].Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return null;
		}
		return uiModelActorComponent.MainMeshComponent;
	}

	// Token: 0x06016C3A RID: 93242 RVA: 0x00650540 File Offset: 0x0064E740
	private void DestroyCinematicTick()
	{
		if (this.CinematicTick != null)
		{
			Singleton<ActorSystem>.Instance.Put("UiLoginSceneManager.DestroyCinematicTick1", this.CinematicTick, null);
			this.CinematicTick = null;
		}
		if (this.Spotlight1 != null)
		{
			Singleton<ActorSystem>.Instance.Put("UiLoginSceneManager.DestroyCinematicTick2", this.Spotlight1, null);
			this.Spotlight1 = null;
		}
		if (this.Spotlight2 != null)
		{
			Singleton<ActorSystem>.Instance.Put("UiLoginSceneManager.DestroyCinematicTick3", this.Spotlight2, null);
			this.Spotlight2 = null;
		}
	}

	// Token: 0x06016C3B RID: 93243 RVA: 0x006505C0 File Offset: 0x0064E7C0
	public void InitRoleObservers(Action delegateAction = null)
	{
		this.InitRoleFinishDelegate = delegateAction;
		this.DestroyCreateCharacterObservers();
		IReadOnlyList<int> initialRoles = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles();
		int roleId = initialRoles[0];
		this.CreateRoleObserver(roleId, "GirlCase");
		int roleId2 = initialRoles[1];
		this.CreateRoleObserver(roleId2, "BoyCase");
	}

	// Token: 0x06016C3C RID: 93244 RVA: 0x0065060C File Offset: 0x0064E80C
	private void CreateRoleObserver(int roleId, string tag)
	{
		TsUiSceneRoleActor observer = this.GetRoleObserver(roleId);
		UiModelBase model = observer.Model;
		UiModelBase model3 = model;
		UiRoleLoadComponent uiRoleLoadComponent = (model3 != null) ? model3.CheckGetComponent<UiRoleLoadComponent>() : null;
		if (uiRoleLoadComponent == null)
		{
			return;
		}
		Action <>9__1;
		uiRoleLoadComponent.LoadModelByRoleConfigId(roleId, -1, false, delegate
		{
			UiRoleHuluComponent uiRoleHuluComponent = model.CheckGetComponent<UiRoleHuluComponent>();
			object obj;
			if (uiRoleHuluComponent == null)
			{
				obj = null;
			}
			else
			{
				SkeletalObserverHandle huluHandle = uiRoleHuluComponent.GetHuluHandle();
				obj = ((huluHandle != null) ? huluHandle.Model : null);
			}
			object obj2 = obj;
			UiModelLoadComponent uiModelLoadComponent = (obj2 != null) ? obj2.CheckGetComponent<UiModelLoadComponent>() : null;
			TArray<USkeletalMesh> tarray = (uiModelLoadComponent != null) ? uiModelLoadComponent.GetModelAllMesh() : null;
			if (tarray != null)
			{
				MeshStreamTaskContext meshStreamTaskContext = new MeshStreamTaskContext();
				meshStreamTaskContext.SkeletalMeshes = tarray;
				MeshStreamTaskContext meshStreamTaskContext2 = meshStreamTaskContext;
				Action onTaskFinish;
				if ((onTaskFinish = <>9__1) == null)
				{
					onTaskFinish = (<>9__1 = delegate()
					{
						UiRoleHuluComponent uiRoleHuluComponent2 = model.CheckGetComponent<UiRoleHuluComponent>();
						if (uiRoleHuluComponent2 == null)
						{
							return;
						}
						uiRoleHuluComponent2.SetActive(true);
					});
				}
				meshStreamTaskContext2.OnTaskFinish = onTaskFinish;
				int item = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
				this.HuluHandleList.Add(item);
			}
			Singleton<UiModelUtil>.Instance.SetVisible(model, true);
			UiRoleStateMachineComponent uiRoleStateMachineComponent = model.CheckGetComponent<UiRoleStateMachineComponent>();
			if (uiRoleStateMachineComponent != null)
			{
				uiRoleStateMachineComponent.SetState(EPerformanceRoleState.CreateRole_Idle, false, false, false);
			}
			UiModelBase model2 = observer.Model;
			UiModelActorComponent uiModelActorComponent = (model2 != null) ? model2.CheckGetComponent<UiModelActorComponent>() : null;
			if (uiModelActorComponent != null)
			{
				uiModelActorComponent.SetTransformByTag(tag);
			}
			if (((uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null) != null)
			{
				uiModelActorComponent.MainMeshComponent.KuroLodMask = 1;
				uiModelActorComponent.MainMeshComponent.KuroAnimInstanceLod = 1;
			}
			this.RoleLoadingFinishList.Add(roleId);
			if (this.RoleLoadingFinishList.Count >= 2)
			{
				this.BindCinematicTick();
				Action initRoleFinishDelegate = this.InitRoleFinishDelegate;
				if (initRoleFinishDelegate != null)
				{
					initRoleFinishDelegate();
				}
				this.InitRoleFinishDelegate = null;
			}
		});
	}

	// Token: 0x06016C3D RID: 93245 RVA: 0x00650687 File Offset: 0x0064E887
	public void PlayRoleMontage(int roleId, EPerformanceRoleState roleState)
	{
		UiModelBase model = this.GetRoleObserver(roleId).Model;
		UiRoleStateMachineComponent uiRoleStateMachineComponent = (model != null) ? model.CheckGetComponent<UiRoleStateMachineComponent>() : null;
		if (uiRoleStateMachineComponent == null)
		{
			return;
		}
		uiRoleStateMachineComponent.SetState(roleState, false, false, false);
	}

	// Token: 0x06016C3E RID: 93246 RVA: 0x006506B0 File Offset: 0x0064E8B0
	public int SetRoleRenderingMaterial(int roleId, string effectId)
	{
		TsUiSceneRoleActor roleObserver = this.GetRoleObserver(roleId);
		return Singleton<UiModelUtil>.Instance.SetRenderingMaterial(roleObserver.Model, effectId);
	}

	// Token: 0x06016C3F RID: 93247 RVA: 0x006506D8 File Offset: 0x0064E8D8
	public void RemoveRoleRenderingMaterial(int roleId, int materialId)
	{
		TsUiSceneRoleActor roleObserver = this.GetRoleObserver(roleId);
		Singleton<UiModelUtil>.Instance.RemoveRenderingMaterial(roleObserver.Model, materialId);
	}

	// Token: 0x06016C40 RID: 93248 RVA: 0x006506FE File Offset: 0x0064E8FE
	public void RemoveRoleRenderingMaterialWithEnding(int roleId, int materialId)
	{
		UiModelBase model = this.GetRoleObserver(roleId).Model;
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = (model != null) ? model.CheckGetComponent<UiModelRenderingMaterialComponent>() : null;
		if (uiModelRenderingMaterialComponent == null)
		{
			return;
		}
		uiModelRenderingMaterialComponent.RemoveRenderingMaterialWithEnding(materialId);
	}

	// Token: 0x06016C41 RID: 93249 RVA: 0x00650724 File Offset: 0x0064E924
	public int SetHuluRenderingMaterial(int roleId, string materialId)
	{
		SkeletalObserverHandle huluHandle = this.GetRoleObserver(roleId).Model.CheckGetComponent<UiRoleHuluComponent>().GetHuluHandle();
		return Singleton<UiModelUtil>.Instance.SetRenderingMaterial(huluHandle.Model, materialId);
	}

	// Token: 0x06016C42 RID: 93250 RVA: 0x00650759 File Offset: 0x0064E959
	public void RemoveHuluRenderingMaterialWithEnding(int roleId, int materialId)
	{
		this.GetRoleObserver(roleId).Model.CheckGetComponent<UiRoleHuluComponent>().GetHuluHandle().Model.CheckGetComponent<UiModelRenderingMaterialComponent>().RemoveRenderingMaterialWithEnding(materialId);
	}

	// Token: 0x06016C43 RID: 93251 RVA: 0x00650781 File Offset: 0x0064E981
	public void SetBurstEyeMaterialId(int materialId)
	{
		this.BurstEyeMaterialId = materialId;
	}

	// Token: 0x06016C44 RID: 93252 RVA: 0x0065078A File Offset: 0x0064E98A
	public int GetBurstEyeMaterialId()
	{
		return this.BurstEyeMaterialId;
	}

	// Token: 0x06016C45 RID: 93253 RVA: 0x00650794 File Offset: 0x0064E994
	public void LoadSequenceAsync(string resourceId, Action callBack = null, bool playReverse = false, Action startCallBack = null)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(resourcePath, delegate([Nullable(2)] ULevelSequence levelSequenceObject, string path)
		{
			if (levelSequenceObject != null && levelSequenceObject.IsValid())
			{
				Action startCallBack2 = startCallBack;
				if (startCallBack2 != null)
				{
					startCallBack2();
				}
				ALevelSequenceActor alevelSequenceActor = new ALevelSequenceActor();
				ULevelSequencePlayer.CreateLevelSequencePlayer(GlobalData.World, levelSequenceObject, new FMovieSceneSequencePlaybackSettings(), ref alevelSequenceActor);
				ALevelSequenceActor alevelSequenceActor2 = alevelSequenceActor;
				alevelSequenceActor2.ResetBindings();
				ULevelSequence sequence = alevelSequenceActor2.GetSequence();
				if (sequence.HasBindingTag(this.SEQUENCE_CAMERA_TAG, true))
				{
					BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.GetComponent<WidgetCameraDisplayComponent>().CineCamera;
					alevelSequenceActor2.AddBindingByTag(this.SEQUENCE_CAMERA_TAG, cineCamera, false, false);
				}
				if (this.CinematicTick != null && sequence.HasBindingTag(this.CINEMATIC_TICK_TAG, true))
				{
					alevelSequenceActor2.AddBindingByTag(this.CINEMATIC_TICK_TAG, this.CinematicTick, false, false);
				}
				if (this.Spotlight1 != null && sequence.HasBindingTag(this.SPOT_LIGHT1_TAG, true))
				{
					alevelSequenceActor2.AddBindingByTag(this.SPOT_LIGHT1_TAG, this.Spotlight1, false, false);
				}
				if (this.Spotlight2 != null && sequence.HasBindingTag(this.SPOT_LIGHT2_TAG, true))
				{
					alevelSequenceActor2.AddBindingByTag(this.SPOT_LIGHT2_TAG, this.Spotlight2, false, false);
				}
				if (callBack != null)
				{
					alevelSequenceActor2.SequencePlayer.OnFinished.Add(callBack);
				}
				if (playReverse)
				{
					alevelSequenceActor2.SequencePlayer.PlayReverse();
				}
				else
				{
					alevelSequenceActor2.SequencePlayer.Play();
				}
				if (this.LoginLoopSequence != null)
				{
					this.LoginLoopSequence.SequencePlayer.StopAtCurrentTime();
					this.BlendCameraSequence();
				}
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiLoginSceneManager;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "登录场景Sequence异步加载失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action startCallBack3 = startCallBack;
			if (startCallBack3 != null)
			{
				startCallBack3();
			}
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 100, "js_undefined");
	}

	// Token: 0x06016C46 RID: 93254 RVA: 0x006507F0 File Offset: 0x0064E9F0
	public void PlayLoginLoopSequence()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("LevelSequence_Login");
		Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(resourcePath, delegate([Nullable(2)] ULevelSequence levelSequenceObject, string path)
		{
			if (levelSequenceObject == null || !levelSequenceObject.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiLoginSceneManager;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "登录场景Sequence异步加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ALevelSequenceActor loginLoopSequence = new ALevelSequenceActor();
			ULevelSequencePlayer.CreateLevelSequencePlayer(GlobalData.World, levelSequenceObject, new FMovieSceneSequencePlaybackSettings(), ref loginLoopSequence);
			this.LoginLoopSequence = loginLoopSequence;
			this.LoginLoopSequence.ResetBindings();
			BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.GetComponent<WidgetCameraDisplayComponent>().CineCamera;
			this.LoginLoopSequence.AddBindingByTag(this.SEQUENCE_CAMERA_TAG, cineCamera, false, false);
			this.LoginLoopSequence.SequencePlayer.PlayLooping(-1);
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
			Singleton<Log>.Instance.Info(ELogModule.UiLoginSceneManager, ELogAuthor.XXJ, "播放进入循环缓动镜头", default(ReadOnlySpan<ValueTuple<string, object>>));
		}, 100, "js_undefined");
	}

	// Token: 0x06016C47 RID: 93255 RVA: 0x0065082C File Offset: 0x0064EA2C
	private void BlendCameraSequence()
	{
		APlayerController playerController = UGameplayStatics.GetPlayerController(GlobalData.World, 0);
		if (playerController == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiLoginSceneManager, ELogAuthor.XXJ, "[BlendCameraSequence]混合相机动画失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.WidgetCamera.GetComponent<WidgetCameraDisplayComponent>().CineCamera;
		playerController.SetViewTargetWithBlend(cineCamera, 0.5f, EViewTargetBlendFunction.VTBlend_Linear, 0f, true, true);
	}

	// Token: 0x06016C48 RID: 93256 RVA: 0x00650896 File Offset: 0x0064EA96
	public void Destroy()
	{
		this.DestroyCreateCharacterObservers();
		this.DestroyCinematicTick();
		if (this.LoginLoopSequence != null)
		{
			this.LoginLoopSequence.K2_DestroyActor();
			this.LoginLoopSequence = null;
		}
	}

	// Token: 0x0400AF6B RID: 44907
	private readonly Dictionary<int, TsUiSceneRoleActor> Observers = new Dictionary<int, TsUiSceneRoleActor>();

	// Token: 0x0400AF6C RID: 44908
	private BP_Cinematics_Tick_C CinematicTick;

	// Token: 0x0400AF6D RID: 44909
	private ASpotLight Spotlight1;

	// Token: 0x0400AF6E RID: 44910
	private ASpotLight Spotlight2;

	// Token: 0x0400AF6F RID: 44911
	private int BurstEyeMaterialId;

	// Token: 0x0400AF70 RID: 44912
	private readonly List<int> RoleLoadingFinishList = new List<int>();

	// Token: 0x0400AF71 RID: 44913
	private readonly List<int> HuluHandleList = new List<int>();

	// Token: 0x0400AF72 RID: 44914
	private Action InitRoleFinishDelegate;

	// Token: 0x0400AF73 RID: 44915
	[Nullable(2)]
	private ALevelSequenceActor LoginLoopSequence;

	// Token: 0x0400AF74 RID: 44916
	private readonly FName SEQUENCE_CAMERA_TAG = new FName("SequenceCamera");

	// Token: 0x0400AF75 RID: 44917
	private readonly FName CINEMATIC_TICK_TAG = new FName("CinematicTick");

	// Token: 0x0400AF76 RID: 44918
	private readonly FName SPOT_LIGHT1_TAG = new FName("SpotLight1");

	// Token: 0x0400AF77 RID: 44919
	private readonly FName SPOT_LIGHT2_TAG = new FName("SpotLight2");
}
