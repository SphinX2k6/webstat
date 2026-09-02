using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using UnrealEngine;

// Token: 0x02003431 RID: 13361
[NullableContext(1)]
[Nullable(0)]
public class SceneInteractionLevel
{
	// Token: 0x0601BFF5 RID: 114677 RVA: 0x00858C00 File Offset: 0x00856E00
	public void Init(ULevelStreamingDynamic levelStreamingDynamic, string inLevelName, FVectorDouble location, FRotator rotation, int handleId, EKuroSceneInteractionState? initState, [Nullable(2)] Action onLevelStreamingCompleteCallback, bool afterLoadVisible, bool isInitShow = false, int pbDataId = 0, [Nullable(2)] Action onLevelStreamingLoadedCompleteCallback = null)
	{
		this.LevelStreamingDynamic = levelStreamingDynamic;
		this.LevelName = inLevelName;
		this.Location = new FVectorDouble?(location);
		this.Rotation = new FRotator?(rotation);
		this.HandleId = handleId;
		this.CurrentState = initState;
		this.HasTempState = false;
		this.IsInitShow = isInitShow;
		this.PbDataId = pbDataId;
		this.LevelStreamingDynamic.bInitiallyLoaded = true;
		this.LevelStreamingDynamic.bInitiallyVisible = true;
		this.LevelStreamingDynamic.SetShouldBeLoaded(true);
		this.LevelStreamingDynamic.SetShouldBeVisible(afterLoadVisible);
		this.LoadingLevelComplete = false;
		this.IsDestroyed = false;
		this.OnLevelStreamingShowCallback = onLevelStreamingCompleteCallback;
		this.OnLevelStreamingLoadedCallback = onLevelStreamingLoadedCompleteCallback;
		bool enableSceneInteractionLog = SceneInteractionLevel.EnableSceneInteractionLog;
		this.LevelStreamingDynamic.OnLevelShown.Add(delegate()
		{
			this.OnLevelShow("Init");
		});
		this.LevelStreamingDynamic.OnLevelLoaded.Add(delegate()
		{
			this.OnLevelLoaded("Init");
		});
	}

	// Token: 0x0601BFF6 RID: 114678 RVA: 0x00858CE8 File Offset: 0x00856EE8
	public void ToggleLevelVisible(bool visible, bool needHidden, [Nullable(2)] Action onLevelStreamingShowOrHideCallback = null, string reason = "")
	{
		ULevelStreamingDynamic levelStreamingDynamic = this.LevelStreamingDynamic;
		if (levelStreamingDynamic == null || !levelStreamingDynamic.IsValid())
		{
			return;
		}
		TArray<AActor> allActorsInLevel = this.GetAllActorsInLevel();
		if (allActorsInLevel != null && !visible && needHidden)
		{
			int i = 0;
			int num = allActorsInLevel.Num();
			while (i < num)
			{
				AActor aactor = allActorsInLevel.Get(i);
				if (aactor != null)
				{
					aactor.SetActorHiddenInGame(true);
				}
				i++;
			}
		}
		this.LevelStreamingDynamic.SetShouldBeVisible(visible);
		if (visible)
		{
			this.OnLevelStreamingShowCallback = onLevelStreamingShowOrHideCallback;
			this.LevelStreamingDynamic.OnLevelShown.Clear();
			this.LevelStreamingDynamic.OnLevelShown.Add(delegate()
			{
				this.OnLevelShow(reason);
			});
			return;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor != null)
		{
			interactionActor.TryStopCurrentState();
		}
		SceneInteractionActor interactionActor2 = this.InteractionActor;
		if (interactionActor2 != null)
		{
			interactionActor2.Clear();
		}
		this.OnLevelStreamingHideCallback = onLevelStreamingShowOrHideCallback;
		this.LevelStreamingDynamic.OnLevelHidden.Clear();
		this.LevelStreamingDynamic.OnLevelHidden.Add(delegate()
		{
			this.OnLevelHide(reason);
		});
	}

	// Token: 0x17002635 RID: 9781
	// (get) Token: 0x0601BFF7 RID: 114679 RVA: 0x00858DF7 File Offset: 0x00856FF7
	[Nullable(2)]
	public AActor MainActor
	{
		[NullableContext(2)]
		get
		{
			return this.InteractionActor;
		}
	}

	// Token: 0x0601BFF8 RID: 114680 RVA: 0x00858DFF File Offset: 0x00856FFF
	public void SetStreamingPriority(int priority)
	{
		ULevelStreamingDynamic levelStreamingDynamic = this.LevelStreamingDynamic;
		if (levelStreamingDynamic != null && levelStreamingDynamic.IsValid())
		{
			this.LevelStreamingDynamic.SetPriority(priority);
		}
	}

	// Token: 0x0601BFF9 RID: 114681 RVA: 0x00858E24 File Offset: 0x00857024
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<AActor> GetAllActorsInLevel()
	{
		if (this.LevelStreamingDynamic == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderScene, ELogAuthor.HCS, "错误，流送关卡为空!!!!!!!!!!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		ULevel loadedLevel = this.LevelStreamingDynamic.GetLoadedLevel();
		if (loadedLevel != null)
		{
			return UKuroRenderingRuntimeBPPluginBPLibrary.GetLevelActors(loadedLevel);
		}
		return null;
	}

	// Token: 0x0601BFFA RID: 114682 RVA: 0x00858E6E File Offset: 0x0085706E
	public bool IsStreamingComplete()
	{
		return this.LoadingLevelComplete;
	}

	// Token: 0x0601BFFB RID: 114683 RVA: 0x00858E76 File Offset: 0x00857076
	public bool IsInfoDestroyed()
	{
		return this.IsDestroyed;
	}

	// Token: 0x0601BFFC RID: 114684 RVA: 0x00858E80 File Offset: 0x00857080
	public void Destroy()
	{
		this.IsDestroyed = true;
		this.SetCollisionActorsOwner(null);
		if (this.InteractionActor != null)
		{
			this.InteractionActor.Clear();
		}
		if (this.LevelStreamingDynamic != null)
		{
			this.LevelStreamingDynamic.OnLevelShown.Clear();
			this.LevelStreamingDynamic.OnLevelLoaded.Clear();
			this.LevelStreamingDynamic.SetShouldBeLoaded(false);
		}
		this.LevelStreamingDynamic = null;
		this.InteractionActor = null;
		this.OnLevelStreamingShowCallback = null;
		this.OnLevelStreamingHideCallback = null;
	}

	// Token: 0x0601BFFD RID: 114685 RVA: 0x00858F00 File Offset: 0x00857100
	public void Update(float deltaSeconds)
	{
		if (!this.Active)
		{
			return;
		}
		if (this.IsDestroyed)
		{
			return;
		}
		if (!this.LoadingLevelComplete)
		{
			return;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.Update(deltaSeconds);
	}

	// Token: 0x0601BFFE RID: 114686 RVA: 0x00858F4C File Offset: 0x0085714C
	public bool SwitchToState(EKuroSceneInteractionState targetState, bool needTransition, bool force, bool jumpToEnd)
	{
		if (!this.Active)
		{
			this.CurrentState = new EKuroSceneInteractionState?(targetState);
			return true;
		}
		if (this.InteractionActor != null)
		{
			return this.DoSwitchToState(targetState, needTransition, force, jumpToEnd);
		}
		this.HasTempState = true;
		this.TempTargetState = new EKuroSceneInteractionState?(targetState);
		this.TempNeedTransition = needTransition;
		this.TempForce = force;
		return true;
	}

	// Token: 0x0601BFFF RID: 114687 RVA: 0x00858FA5 File Offset: 0x008571A5
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public IReadOnlyDictionary<string, AActor> GetAllActor()
	{
		if (!this.LoadingLevelComplete)
		{
			return null;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetAllActor();
	}

	// Token: 0x0601C000 RID: 114688 RVA: 0x00858FD8 File Offset: 0x008571D8
	[return: Nullable(2)]
	public AActor GetActorByKey(string key)
	{
		if (!this.LoadingLevelComplete)
		{
			return null;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		AActor actorByKey = this.InteractionActor.GetActorByKey(key);
		if (actorByKey == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderScene, ELogAuthor.HCS, string.Concat(new string[]
			{
				"获取actor失败 level:",
				this.LevelName,
				" 不存在key=",
				key,
				" 的Actor"
			}), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return actorByKey;
	}

	// Token: 0x0601C001 RID: 114689 RVA: 0x00859064 File Offset: 0x00857264
	public FTransformDouble? GetActorOriginalRelTransform(AActor actor)
	{
		if (!this.LoadingLevelComplete)
		{
			return null;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetActorOriginalRelTransform(actor);
	}

	// Token: 0x0601C002 RID: 114690 RVA: 0x008590B0 File Offset: 0x008572B0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<AActor> GetRefActorsByTag(FGameplayTag tag)
	{
		if (!this.LoadingLevelComplete)
		{
			return null;
		}
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetRefActorsByTag(tag);
	}

	// Token: 0x0601C003 RID: 114691 RVA: 0x008590E4 File Offset: 0x008572E4
	private bool DoSwitchToState(EKuroSceneInteractionState targetState, bool needTransition, bool force, bool jumpToEnd)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return false;
		}
		if (!force)
		{
			EKuroSceneInteractionState? currentState = this.CurrentState;
			if (currentState.GetValueOrDefault() == targetState & currentState != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderScene;
				ELogAuthor author = ELogAuthor.MY;
				string message = "切换状态失败，无法切换到当前状态";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelName", this.LevelName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
		}
		this.CurrentState = new EKuroSceneInteractionState?(targetState);
		this.InteractionActor.SetState(targetState, needTransition, jumpToEnd);
		return true;
	}

	// Token: 0x0601C004 RID: 114692 RVA: 0x00859174 File Offset: 0x00857374
	public EKuroSceneInteractionState GetCurrentState()
	{
		if (this.InteractionActor != null)
		{
			return this.InteractionActor.GetCurrentState();
		}
		return EKuroSceneInteractionState.Error;
	}

	// Token: 0x0601C005 RID: 114693 RVA: 0x0085918C File Offset: 0x0085738C
	public void ChangePlayDirection(bool bPlayBack)
	{
		if (this.InteractionActor != null)
		{
			this.InteractionActor.ChangeDirection(bPlayBack);
		}
	}

	// Token: 0x0601C006 RID: 114694 RVA: 0x008591A2 File Offset: 0x008573A2
	public void PlaySceneEffect(ESceneInteractionEffect effectKey)
	{
		if (this.InteractionActor != null)
		{
			this.InteractionActor.PlayIndependentEffect(effectKey);
		}
	}

	// Token: 0x0601C007 RID: 114695 RVA: 0x008591B8 File Offset: 0x008573B8
	public void EndSceneEffect(ESceneInteractionEffect effectKey)
	{
		if (this.InteractionActor != null)
		{
			this.InteractionActor.EndIndependentEffect(effectKey);
		}
	}

	// Token: 0x0601C008 RID: 114696 RVA: 0x008591CE File Offset: 0x008573CE
	public void PlaySceneEndEffect(ESceneInteractionEffect effectKey)
	{
		if (this.InteractionActor != null)
		{
			this.InteractionActor.PlayIndependentEndEffect(effectKey);
		}
	}

	// Token: 0x0601C009 RID: 114697 RVA: 0x008591E4 File Offset: 0x008573E4
	[NullableContext(2)]
	private void ApplyCustomPrimitiveData(ULevel level)
	{
		Dictionary<int, LevelCustomPrimitiveData> levelCustomPrimitiveData = ConfigBase<RenderModuleConfig>.Instance.LevelCustomPrimitiveData;
		LevelCustomPrimitiveData? levelCustomPrimitiveData2 = (levelCustomPrimitiveData != null && levelCustomPrimitiveData.ContainsKey(this.PbDataId)) ? new LevelCustomPrimitiveData?(ConfigBase<RenderModuleConfig>.Instance.LevelCustomPrimitiveData[this.PbDataId]) : null;
		if (levelCustomPrimitiveData2 != null)
		{
			LevelCustomPrimitiveData value = levelCustomPrimitiveData2.Value;
			if (value.CustomPrimitiveDataIndex0() != null && value.CustomPrimitiveDataIndex0Length > 0)
			{
				TArray<AActor> levelActors = UKuroRenderingRuntimeBPPluginBPLibrary.GetLevelActors(level);
				if (levelActors != null)
				{
					int i = 0;
					int num = levelActors.Num();
					while (i < num)
					{
						AActor aactor = levelActors.Get(i);
						if (aactor.IsValid())
						{
							TArray<UActorComponent> tarray = aactor.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
							if (tarray != null)
							{
								for (int j = 0; j < tarray.Num(); j++)
								{
									UStaticMeshComponent ustaticMeshComponent = tarray.Get(j) as UStaticMeshComponent;
									if (ustaticMeshComponent == null || !ustaticMeshComponent.IsValid())
									{
										Log instance = Singleton<Log>.Instance;
										ELogModule module = ELogModule.Interaction;
										ELogAuthor author = ELogAuthor.XDW;
										string message = "[SceneInteractionLevel.OnLevelShow] Comp无效";
										ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelName", this.LevelName);
										instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
									}
									else
									{
										switch (value.CustomPrimitiveDataIndex0Length)
										{
										case 1:
											ustaticMeshComponent.SetCustomPrimitiveDataFloat(0, value.CustomPrimitiveDataIndex0()[0]);
											break;
										case 2:
											ustaticMeshComponent.SetCustomPrimitiveDataVector2(0, new FVector2D(value.CustomPrimitiveDataIndex0()[0], value.CustomPrimitiveDataIndex0()[1]));
											break;
										case 3:
											ustaticMeshComponent.SetCustomPrimitiveDataVector3(0, new FVector(value.CustomPrimitiveDataIndex0()[0], value.CustomPrimitiveDataIndex0()[1], value.CustomPrimitiveDataIndex0()[2]));
											break;
										case 4:
											ustaticMeshComponent.SetCustomPrimitiveDataVector4(0, new FVector4(value.CustomPrimitiveDataIndex0()[0], value.CustomPrimitiveDataIndex0()[1], value.CustomPrimitiveDataIndex0()[2], value.CustomPrimitiveDataIndex0()[3]));
											break;
										default:
										{
											Log instance2 = Singleton<Log>.Instance;
											ELogModule module2 = ELogModule.Interaction;
											ELogAuthor author2 = ELogAuthor.XDW;
											string message2 = "[SceneInteractionLevel.OnLevelShow] CustomPrimitiveData太长";
											ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CustomPrimitiveData0", value.CustomPrimitiveDataIndex0());
											instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
											break;
										}
										}
									}
								}
							}
						}
						i++;
					}
				}
			}
		}
	}

	// Token: 0x0601C00A RID: 114698 RVA: 0x00859424 File Offset: 0x00857624
	private void OnLevelLoaded(string reason)
	{
		bool enableSceneInteractionLog = SceneInteractionLevel.EnableSceneInteractionLog;
		Action onLevelStreamingLoadedCallback = this.OnLevelStreamingLoadedCallback;
		if (onLevelStreamingLoadedCallback != null)
		{
			onLevelStreamingLoadedCallback();
		}
		this.OnLevelStreamingLoadedCallback = null;
	}

	// Token: 0x0601C00B RID: 114699 RVA: 0x00859444 File Offset: 0x00857644
	private void OnLevelShow(string reason)
	{
		if (this.LevelStreamingDynamic == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderScene;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "错误，流送关卡为空!!!!!!!!!!!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.LevelName", this.LevelName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.LoadingLevelComplete = true;
		ULevel loadedLevel = this.LevelStreamingDynamic.GetLoadedLevel();
		AActor sceneInteractionLevelActor = UKuroRenderingRuntimeBPPluginBPLibrary.GetSceneInteractionLevelActor(loadedLevel);
		this.InteractionActor = (sceneInteractionLevelActor as SceneInteractionActor);
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderScene;
			ELogAuthor author2 = ELogAuthor.HCS;
			string message2 = "找不到关卡蓝图,查看prefab是否按照规范进行制作";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("LevelName", this.LevelName);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.LevelStreamingDynamic.OnLevelShown.Clear();
			return;
		}
		this.InteractionActor.Init(this.PbDataId, this.HandleId, this.LevelName, delegate
		{
			this.DoSwitchToState(this.CurrentState.GetValueOrDefault(), false, true, !this.IsInitShow);
			if (this.OnLevelStreamingShowCallback != null)
			{
				this.OnLevelStreamingShowCallback();
			}
			this.OnLevelStreamingShowCallback = null;
			if (this.HasTempState)
			{
				this.DoSwitchToState(this.TempTargetState.Value, this.TempNeedTransition, this.TempForce, !this.IsInitShow);
				this.HasTempState = false;
			}
			ULevelStreamingDynamic levelStreamingDynamic = this.LevelStreamingDynamic;
			if (levelStreamingDynamic == null)
			{
				return;
			}
			levelStreamingDynamic.OnLevelShown.Clear();
		});
		this.ApplyCustomPrimitiveData(loadedLevel);
		bool enableSceneInteractionLog = SceneInteractionLevel.EnableSceneInteractionLog;
	}

	// Token: 0x0601C00C RID: 114700 RVA: 0x00859536 File Offset: 0x00857736
	private void OnLevelHide(string reason)
	{
		if (this.OnLevelStreamingHideCallback != null)
		{
			this.OnLevelStreamingHideCallback();
		}
		this.OnLevelStreamingHideCallback = null;
		ULevelStreamingDynamic levelStreamingDynamic = this.LevelStreamingDynamic;
		if (levelStreamingDynamic != null)
		{
			levelStreamingDynamic.OnLevelHidden.Clear();
		}
		bool enableSceneInteractionLog = SceneInteractionLevel.EnableSceneInteractionLog;
	}

	// Token: 0x0601C00D RID: 114701 RVA: 0x0085956E File Offset: 0x0085776E
	[NullableContext(2)]
	public AActor GetAttachActor()
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetAttachParentActor();
	}

	// Token: 0x0601C00E RID: 114702 RVA: 0x00859594 File Offset: 0x00857794
	public void AttachToActor(AActor parentActor)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor != null && interactionActor.IsValid())
		{
			USceneComponent rootComponent = this.InteractionActor.RootComponent;
			if (rootComponent != null && rootComponent.IsValid())
			{
				if (this.InteractionActor.RootComponent.Mobility == EComponentMobility.Static)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderScene;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "Prefab根场景组件的移动性为Static, 将被强行设置为Movable, 后续请检查Prefab并修改";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelName", this.LevelName);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.InteractionActor.RootComponent.SetMobility(EComponentMobility.Movable);
				}
				ControllerBase<AttachToActorController>.Instance.AttachToActor(this.InteractionActor, parentActor, EDetachType.DestroyExternal, "AttachToActor", null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true, true, false, false, false);
				this.InteractionActor.D_K2_SetActorRelativeLocation(global::Vector.ZeroVectorDouble, false, ref WorldGlobal.SweepHitResult, false);
				this.InteractionActor.K2_SetActorRelativeRotation(Rotator.ZeroRotator, false, ref WorldGlobal.SweepHitResult, false);
				return;
			}
		}
	}

	// Token: 0x0601C00F RID: 114703 RVA: 0x00859688 File Offset: 0x00857888
	[NullableContext(2)]
	public void SetCollisionActorsOwner(AActor owner)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		if (this.InteractionActor.CollisionActors != null)
		{
			int num = this.InteractionActor.CollisionActors.Num();
			for (int i = 0; i < num; i++)
			{
				AActor aactor = this.InteractionActor.CollisionActors.Get(i);
				if (ObjectUtils.IsValid(aactor))
				{
					aactor.SetOwner(owner);
				}
			}
		}
		if (this.InteractionActor.PartCollisionActorsAndCorrespondingTags != null)
		{
			int num2 = this.InteractionActor.PartCollisionActorsAndCorrespondingTags.Num();
			for (int j = 0; j < num2; j++)
			{
				AActor key = this.InteractionActor.PartCollisionActorsAndCorrespondingTags.GetKey(j);
				if (ObjectUtils.IsValid(key))
				{
					key.SetOwner(owner);
				}
			}
		}
	}

	// Token: 0x0601C010 RID: 114704 RVA: 0x0085974C File Offset: 0x0085794C
	[NullableContext(2)]
	public AActor GetMainCollisionActor()
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		if (this.InteractionActor.CollisionActors != null)
		{
			TArray<AActor> collisionActors = this.InteractionActor.CollisionActors;
			if (collisionActors != null && collisionActors.Num() > 0)
			{
				return this.InteractionActor.CollisionActors.Get(0);
			}
		}
		return null;
	}

	// Token: 0x0601C011 RID: 114705 RVA: 0x008597B0 File Offset: 0x008579B0
	[NullableContext(2)]
	public ASkeletalMeshActor GetSkeletalMeshActor()
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		if (this.InteractionActor.AllSkeletalMeshActors != null)
		{
			TArray<ASkeletalMeshActor> allSkeletalMeshActors = this.InteractionActor.AllSkeletalMeshActors;
			if (allSkeletalMeshActors != null && allSkeletalMeshActors.Num() > 0)
			{
				return this.InteractionActor.AllSkeletalMeshActors.Get(0);
			}
		}
		return null;
	}

	// Token: 0x0601C012 RID: 114706 RVA: 0x00859814 File Offset: 0x00857A14
	public FGameplayTag? GetPartCollisionActorTag(AActor actor)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		TMap<AActor, FGameplayTag> partCollisionActorsAndCorrespondingTags = this.InteractionActor.PartCollisionActorsAndCorrespondingTags;
		if (partCollisionActorsAndCorrespondingTags == null)
		{
			return null;
		}
		return new FGameplayTag?(partCollisionActorsAndCorrespondingTags.Get(actor));
	}

	// Token: 0x0601C013 RID: 114707 RVA: 0x00859868 File Offset: 0x00857A68
	public int? GetPartCollisionActorsNum()
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		TMap<AActor, FGameplayTag> partCollisionActorsAndCorrespondingTags = this.InteractionActor.PartCollisionActorsAndCorrespondingTags;
		if (partCollisionActorsAndCorrespondingTags == null)
		{
			return null;
		}
		return new int?(partCollisionActorsAndCorrespondingTags.Num());
	}

	// Token: 0x0601C014 RID: 114708 RVA: 0x008598BC File Offset: 0x00857ABC
	[NullableContext(2)]
	public AActor GetPartCollisionActor(int index)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		if (this.InteractionActor.PartCollisionActorsAndCorrespondingTags == null)
		{
			return null;
		}
		int num = this.InteractionActor.PartCollisionActorsAndCorrespondingTags.Num();
		if (index >= num)
		{
			return null;
		}
		TMap<AActor, FGameplayTag> partCollisionActorsAndCorrespondingTags = this.InteractionActor.PartCollisionActorsAndCorrespondingTags;
		if (partCollisionActorsAndCorrespondingTags == null)
		{
			return null;
		}
		return partCollisionActorsAndCorrespondingTags.GetKey(index);
	}

	// Token: 0x0601C015 RID: 114709 RVA: 0x0085991F File Offset: 0x00857B1F
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<AActor> GetInteractionEffectHookActors()
	{
		if (this.InteractionActor.InteractionEffectHookActors != null)
		{
			return this.InteractionActor.InteractionEffectHookActors;
		}
		return null;
	}

	// Token: 0x0601C016 RID: 114710 RVA: 0x0085993B File Offset: 0x00857B3B
	public void PlayExtraEffect(FGameplayTag tag, bool jumpToEnd)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.PlayExtraEffectOnTagsChange(tag, jumpToEnd);
	}

	// Token: 0x0601C017 RID: 114711 RVA: 0x00859962 File Offset: 0x00857B62
	public void PlayKuroSkeletalMeshDestruction(AActor actor, bool jumpToEnd)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.PlayKuroSkeletalMeshDestruction(actor, jumpToEnd);
	}

	// Token: 0x0601C018 RID: 114712 RVA: 0x00859989 File Offset: 0x00857B89
	public void StopExtraEffect(FGameplayTag tag)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.StopExtraEffectOnTagsChange(tag);
	}

	// Token: 0x0601C019 RID: 114713 RVA: 0x008599AF File Offset: 0x00857BAF
	public void UpdateHitInfo(global::Vector pos, FVector dir)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.UpdateHitInfo(pos.ToUeVector(false), dir);
	}

	// Token: 0x0601C01A RID: 114714 RVA: 0x008599DC File Offset: 0x00857BDC
	public void UpdateRangeOverlapInfo(bool isEnter, AActor otherActor)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.UpdateRangeOverlapInfo(isEnter, otherActor);
	}

	// Token: 0x0601C01B RID: 114715 RVA: 0x00859A04 File Offset: 0x00857C04
	public float? GetActiveTagSequencePlaybackProgress(FGameplayTag tag)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetActiveTagSequencePlaybackProgress(tag);
	}

	// Token: 0x0601C01C RID: 114716 RVA: 0x00859A3E File Offset: 0x00857C3E
	public void SetActiveTagSequencePlaybackProgress(FGameplayTag tag, float progress)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.SetActiveTagSequencePlaybackProgress(tag, progress);
	}

	// Token: 0x0601C01D RID: 114717 RVA: 0x00859A68 File Offset: 0x00857C68
	public double? GetActiveTagSequenceDurationTime(FGameplayTag tag)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		float? activeTagSequenceDurationTime = this.InteractionActor.GetActiveTagSequenceDurationTime(tag);
		if (activeTagSequenceDurationTime == null)
		{
			return null;
		}
		return new double?((double)activeTagSequenceDurationTime.GetValueOrDefault());
	}

	// Token: 0x0601C01E RID: 114718 RVA: 0x00859AC3 File Offset: 0x00857CC3
	public void SetActiveTagSequenceDurationTime(FGameplayTag tag, float durationSecond)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.SetActiveTagSequenceDurationTime(tag, durationSecond);
	}

	// Token: 0x0601C01F RID: 114719 RVA: 0x00859AEA File Offset: 0x00857CEA
	public void PauseActiveTagSequence(FGameplayTag tag)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.PauseActiveTagSequence(tag);
	}

	// Token: 0x0601C020 RID: 114720 RVA: 0x00859B10 File Offset: 0x00857D10
	public void ResumeActiveTagSequence(FGameplayTag tag, bool bReverseFromConfig = false)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.ResumeActiveTagSequence(tag, bReverseFromConfig);
	}

	// Token: 0x0601C021 RID: 114721 RVA: 0x00859B38 File Offset: 0x00857D38
	public bool? GetIsActiveTagSequencePlayReverseFromConfig(FGameplayTag tag)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.GetIsActiveTagSequencePlayReverseFromConfig(tag);
	}

	// Token: 0x0601C022 RID: 114722 RVA: 0x00859B72 File Offset: 0x00857D72
	public void PlayActiveTagSequenceTo(FGameplayTag tag, float progress, bool bReverseFromConfig = false)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.PlayActiveTagSequenceTo(tag, progress, bReverseFromConfig);
	}

	// Token: 0x0601C023 RID: 114723 RVA: 0x00859B9A File Offset: 0x00857D9A
	public void SetOverrideSeqBindActor(AActor actorToBind, [Nullable(2)] string bindingName = null)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.SetOverrideSeqBindActor(actorToBind, bindingName);
	}

	// Token: 0x0601C024 RID: 114724 RVA: 0x00859BC1 File Offset: 0x00857DC1
	public void UnsetOverrideSeqBindActor(AActor actorToUnBind, [Nullable(2)] string bindingName = null)
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return;
		}
		this.InteractionActor.UnsetOverrideSeqBindActor(actorToUnBind, bindingName);
	}

	// Token: 0x0601C025 RID: 114725 RVA: 0x00859BE8 File Offset: 0x00857DE8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<AActor> GetReceivingDecalsActors()
	{
		SceneInteractionActor interactionActor = this.InteractionActor;
		if (interactionActor == null || !interactionActor.IsValid())
		{
			return null;
		}
		return this.InteractionActor.ReceivingDecalsActors;
	}

	// Token: 0x0601C026 RID: 114726 RVA: 0x00859C0E File Offset: 0x00857E0E
	public void Disable()
	{
		this.Active = false;
		if (this.InteractionActor != null)
		{
			this.InteractionActor.Active = false;
		}
	}

	// Token: 0x0601C027 RID: 114727 RVA: 0x00859C2B File Offset: 0x00857E2B
	public void Enable()
	{
		this.Active = true;
		if (this.InteractionActor != null)
		{
			this.InteractionActor.Active = true;
		}
	}

	// Token: 0x0400E241 RID: 57921
	[Nullable(2)]
	protected ULevelStreamingDynamic LevelStreamingDynamic;

	// Token: 0x0400E242 RID: 57922
	public string LevelName = "";

	// Token: 0x0400E243 RID: 57923
	protected FVectorDouble? Location;

	// Token: 0x0400E244 RID: 57924
	protected FRotator? Rotation;

	// Token: 0x0400E245 RID: 57925
	protected int PbDataId;

	// Token: 0x0400E246 RID: 57926
	protected int HandleId;

	// Token: 0x0400E247 RID: 57927
	protected EKuroSceneInteractionState? CurrentState;

	// Token: 0x0400E248 RID: 57928
	protected bool LoadingLevelComplete;

	// Token: 0x0400E249 RID: 57929
	[Nullable(2)]
	protected SceneInteractionActor InteractionActor;

	// Token: 0x0400E24A RID: 57930
	protected bool HasTempState;

	// Token: 0x0400E24B RID: 57931
	protected EKuroSceneInteractionState? TempTargetState;

	// Token: 0x0400E24C RID: 57932
	protected bool TempNeedTransition;

	// Token: 0x0400E24D RID: 57933
	protected bool IsDestroyed;

	// Token: 0x0400E24E RID: 57934
	protected bool Active = true;

	// Token: 0x0400E24F RID: 57935
	protected bool TempForce;

	// Token: 0x0400E250 RID: 57936
	[Nullable(2)]
	protected Action OnLevelStreamingShowCallback;

	// Token: 0x0400E251 RID: 57937
	[Nullable(2)]
	protected Action OnLevelStreamingLoadedCallback;

	// Token: 0x0400E252 RID: 57938
	[Nullable(2)]
	protected Action OnLevelStreamingHideCallback;

	// Token: 0x0400E253 RID: 57939
	private bool IsInitShow;

	// Token: 0x0400E254 RID: 57940
	private static readonly bool EnableSceneInteractionLog;
}
