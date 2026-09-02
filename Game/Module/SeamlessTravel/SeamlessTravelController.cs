using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02004FFE RID: 20478
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class SeamlessTravelController : ControllerBase<SeamlessTravelController>
	{
		// Token: 0x06034CA4 RID: 216228 RVA: 0x00D3ECF4 File Offset: 0x00D3CEF4
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnEnterTransitionMap, this.EnterTransitionMap);
			Singleton<EventSystem>.Instance.Add(EEventName.EndTravelMap, this.EnterDestinationMap);
			base.PauseTick();
			return true;
		}

		// Token: 0x06034CA5 RID: 216229 RVA: 0x00D3ED29 File Offset: 0x00D3CF29
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterTransitionMap, this.EnterTransitionMap);
			Singleton<EventSystem>.Instance.Remove(EEventName.EndTravelMap, this.EnterDestinationMap);
			return true;
		}

		// Token: 0x06034CA6 RID: 216230 RVA: 0x00D3ED58 File Offset: 0x00D3CF58
		protected override void OnTick(float delta)
		{
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (((instance != null) ? instance.SeamlessTravelTreadmill : null) != null)
			{
				SeamlessTravelModel instance2 = ModelBase<SeamlessTravelModel>.Instance;
				if (instance2 != null)
				{
					instance2.SeamlessTravelTreadmill.Tick(delta);
				}
			}
			SeamlessTravelModel instance3 = ModelBase<SeamlessTravelModel>.Instance;
			if (((instance3 != null) ? instance3.SeamlessTravelKeepKite : null) != null)
			{
				SeamlessTravelModel instance4 = ModelBase<SeamlessTravelModel>.Instance;
				if (instance4 != null)
				{
					instance4.SeamlessTravelKeepKite.Tick(delta);
				}
			}
			SeamlessTravelModel instance5 = ModelBase<SeamlessTravelModel>.Instance;
			if (((instance5 != null) ? instance5.SeamlessTravelKeepMovementMode : null) != null)
			{
				SeamlessTravelModel instance6 = ModelBase<SeamlessTravelModel>.Instance;
				if (instance6 != null)
				{
					instance6.SeamlessTravelKeepMovementMode.Tick(delta);
				}
			}
			SeamlessTravelModel instance7 = ModelBase<SeamlessTravelModel>.Instance;
			if (((instance7 != null) ? instance7.SeamlessTravelPostProcess : null) != null)
			{
				SeamlessTravelModel instance8 = ModelBase<SeamlessTravelModel>.Instance;
				if (instance8 == null)
				{
					return;
				}
				instance8.SeamlessTravelPostProcess.Tick(delta);
			}
		}

		// Token: 0x06034CA7 RID: 216231 RVA: 0x00D3EE08 File Offset: 0x00D3D008
		public bool StartTravel(string levelName)
		{
			if (!ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				return false;
			}
			APlayerController seamlessTravelController = ModelBase<SeamlessTravelModel>.Instance.SeamlessTravelController;
			if (seamlessTravelController == null || !seamlessTravelController.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[无缝加载:失败]PlayerController无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[无缝加载:开始]", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.ForceInGame, ELoadModeReason.SeamlessTravel);
			ModelBase<SeamlessTravelModel>.Instance.InSeamlessTraveling = true;
			if (ModelBase<SeamlessTravelModel>.Instance.SeamlessEndHandle != null)
			{
				TimerSystem.Instance.Remove(ModelBase<SeamlessTravelModel>.Instance.SeamlessEndHandle);
				ModelBase<SeamlessTravelModel>.Instance.SeamlessEndHandle = null;
			}
			WorldGlobal.PlayerClientTravel(seamlessTravelController, levelName);
			return true;
		}

		// Token: 0x06034CA8 RID: 216232 RVA: 0x00D3EECC File Offset: 0x00D3D0CC
		[NullableContext(0)]
		public UniTask<bool> EnableSeamlessTravel([Nullable(1)] SeamlessTravelContext context, bool isPreEnable = false)
		{
			SeamlessTravelController.<EnableSeamlessTravel>d__4 <EnableSeamlessTravel>d__;
			<EnableSeamlessTravel>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnableSeamlessTravel>d__.<>4__this = this;
			<EnableSeamlessTravel>d__.context = context;
			<EnableSeamlessTravel>d__.isPreEnable = isPreEnable;
			<EnableSeamlessTravel>d__.<>1__state = -1;
			<EnableSeamlessTravel>d__.<>t__builder.Start<SeamlessTravelController.<EnableSeamlessTravel>d__4>(ref <EnableSeamlessTravel>d__);
			return <EnableSeamlessTravel>d__.<>t__builder.Task;
		}

		// Token: 0x06034CA9 RID: 216233 RVA: 0x00D3EF20 File Offset: 0x00D3D120
		private void SetupSeamlessTravelEntity(EntityHandle entityHandle)
		{
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
			if (((component != null) ? component.Owner : null) == null || ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravelActor(component.Owner))
			{
				return;
			}
			this.AddSeamlessTravelActor(component.Owner);
			instance.SeamlessTravelPlayerTeamHandles.Add(entityHandle);
			TArray<UActorComponent> tarray = component.Owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				UActorComponent uactorComponent = tarray.Get(i);
				if (uactorComponent is USkeletalMeshComponent)
				{
					uactorComponent.PrimaryComponentTick.bStartWithTickEnabled = false;
				}
			}
			EEntityType? eentityType = (component != null) ? new EEntityType?(component.CreatureData.GetEntityType()) : null;
			if (eentityType.GetValueOrDefault() != EEntityType.SceneItem)
			{
				if (eentityType.GetValueOrDefault() == EEntityType.Monster)
				{
					CharacterAiComponent component2 = entityHandle.Entity.GetComponent<CharacterAiComponent>();
					instance.SeamlessTravelTeamDefaultController.Add(component2.TsAiController);
					this.AddSeamlessTravelActor(component2.TsAiController);
					return;
				}
				CharacterActorComponent component3 = entityHandle.Entity.GetComponent<CharacterActorComponent>();
				instance.SeamlessTravelTeamDefaultController.Add(component3.DefaultController);
				this.AddSeamlessTravelActor(component3.DefaultController);
			}
		}

		// Token: 0x06034CAA RID: 216234 RVA: 0x00D3F053 File Offset: 0x00D3D253
		[NullableContext(2)]
		public void AddSeamlessTravelActor(AActor actor)
		{
			ModelBase<SeamlessTravelModel>.Instance.AddSeamlessTravelActor(actor);
		}

		// Token: 0x06034CAB RID: 216235 RVA: 0x00D3F064 File Offset: 0x00D3D264
		public UniTask PreLeaveLevel()
		{
			SeamlessTravelController.<PreLeaveLevel>d__7 <PreLeaveLevel>d__;
			<PreLeaveLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreLeaveLevel>d__.<>4__this = this;
			<PreLeaveLevel>d__.<>1__state = -1;
			<PreLeaveLevel>d__.<>t__builder.Start<SeamlessTravelController.<PreLeaveLevel>d__7>(ref <PreLeaveLevel>d__);
			return <PreLeaveLevel>d__.<>t__builder.Task;
		}

		// Token: 0x06034CAC RID: 216236 RVA: 0x00D3F0A8 File Offset: 0x00D3D2A8
		public UniTask PreLeaveLevelWaitEnd()
		{
			SeamlessTravelController.<PreLeaveLevelWaitEnd>d__8 <PreLeaveLevelWaitEnd>d__;
			<PreLeaveLevelWaitEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreLeaveLevelWaitEnd>d__.<>4__this = this;
			<PreLeaveLevelWaitEnd>d__.<>1__state = -1;
			<PreLeaveLevelWaitEnd>d__.<>t__builder.Start<SeamlessTravelController.<PreLeaveLevelWaitEnd>d__8>(ref <PreLeaveLevelWaitEnd>d__);
			return <PreLeaveLevelWaitEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06034CAD RID: 216237 RVA: 0x00D3F0EC File Offset: 0x00D3D2EC
		public void PostLeaveLevel()
		{
			if (!ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[无缝加载:PostLeaveLevel完成]", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06034CAE RID: 216238 RVA: 0x00D3F125 File Offset: 0x00D3D325
		public bool PreOpenLevel()
		{
			return true;
		}

		// Token: 0x06034CAF RID: 216239 RVA: 0x00D3F128 File Offset: 0x00D3D328
		[NullableContext(0)]
		public UniTask<bool> PostOpenLevel()
		{
			SeamlessTravelController.<PostOpenLevel>d__11 <PostOpenLevel>d__;
			<PostOpenLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PostOpenLevel>d__.<>1__state = -1;
			<PostOpenLevel>d__.<>t__builder.Start<SeamlessTravelController.<PostOpenLevel>d__11>(ref <PostOpenLevel>d__);
			return <PostOpenLevel>d__.<>t__builder.Task;
		}

		// Token: 0x06034CB0 RID: 216240 RVA: 0x00D3F164 File Offset: 0x00D3D364
		public void PostLoadedLevel()
		{
			if (!ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[无缝加载:PostLoadedLevel完成]", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06034CB1 RID: 216241 RVA: 0x00D3F1A0 File Offset: 0x00D3D3A0
		public bool SetCurrentEntityAction(InstanceDungeon config)
		{
			if (!ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) == null)
			{
				return false;
			}
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			global::Vector vector = commonTempVector;
			FVectorDouble location = characterActorComponent.CreatureData.GetLocation();
			vector.DeepCopy(location);
			global::Rotator rotator = global::Rotator.Create((float)config.GetBornRotationArray()[0], (float)config.GetBornRotationArray()[2], (float)config.GetBornRotationArray()[1]);
			float num = rotator.Yaw - characterActorComponent.ActorRotationProxy.Yaw;
			characterActorComponent.SetInputRotator(rotator);
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (instance != null && instance.UseKeepMovementMode)
			{
				characterActorComponent.TeleportTo(commonTempVector.ToUeVector(false), rotator.ToUeRotator(), "[无缝加载SetCurrentEntityAction:传送玩家(不贴地修正)]");
			}
			else
			{
				characterActorComponent.TeleportAndFindStandLocation(commonTempVector, true);
				characterActorComponent.SetActorRotation(rotator.ToUeRotator(), "[无缝加载SetCurrentEntityAction:修正朝向]", false);
			}
			global::Vector vector2 = global::Vector.Create();
			global::Rotator.Create(0f, num, 0f).Quaternion(null).RotateVector(characterActorComponent.ActorVelocityProxy, vector2);
			characterActorComponent.MoveComp.SetForceSpeed(vector2);
			global::Rotator cameraRotation = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraRotation;
			float inYaw = Singleton<MathUtils>.Instance.WrapAngle(cameraRotation.Yaw + num);
			FRotator rotation = new FRotator(cameraRotation.Pitch, inYaw, cameraRotation.Roll);
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(rotation);
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ResetFightCameraLogic(false, true);
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.YJX, "[无缝加载:修正到目标位置和朝向]", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x06034CB2 RID: 216242 RVA: 0x00D3F358 File Offset: 0x00D3D558
		public UniTask EndSeamlessTravel()
		{
			SeamlessTravelController.<EndSeamlessTravel>d__14 <EndSeamlessTravel>d__;
			<EndSeamlessTravel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndSeamlessTravel>d__.<>4__this = this;
			<EndSeamlessTravel>d__.<>1__state = -1;
			<EndSeamlessTravel>d__.<>t__builder.Start<SeamlessTravelController.<EndSeamlessTravel>d__14>(ref <EndSeamlessTravel>d__);
			return <EndSeamlessTravel>d__.<>t__builder.Task;
		}

		// Token: 0x06034CB3 RID: 216243 RVA: 0x00D3F39C File Offset: 0x00D3D59C
		public UniTask EndSeamlessTravelWaitEnd()
		{
			SeamlessTravelController.<EndSeamlessTravelWaitEnd>d__15 <EndSeamlessTravelWaitEnd>d__;
			<EndSeamlessTravelWaitEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndSeamlessTravelWaitEnd>d__.<>1__state = -1;
			<EndSeamlessTravelWaitEnd>d__.<>t__builder.Start<SeamlessTravelController.<EndSeamlessTravelWaitEnd>d__15>(ref <EndSeamlessTravelWaitEnd>d__);
			return <EndSeamlessTravelWaitEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06034CB4 RID: 216244 RVA: 0x00D3F3D8 File Offset: 0x00D3D5D8
		public void FinishSeamlessTravel()
		{
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (instance != null)
			{
				List<EntityHandle> seamlessTravelPlayerTeamHandles = instance.SeamlessTravelPlayerTeamHandles;
				int? num = (seamlessTravelPlayerTeamHandles != null) ? new int?(seamlessTravelPlayerTeamHandles.Count) : null;
				int num2 = 0;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					return;
				}
			}
			foreach (EntityHandle entityHandle in instance.SeamlessTravelPlayerTeamHandles)
			{
				WorldEntity entity = entityHandle.Entity;
				TArray<UActorComponent> tarray = ((entity != null) ? entity.GetComponent<CharacterActorComponent>().Actor : null).K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
				int num3 = tarray.Num();
				for (int i = 0; i < num3; i++)
				{
					UActorComponent uactorComponent = tarray.Get(i);
					if (uactorComponent is USkeletalMeshComponent)
					{
						uactorComponent.PrimaryComponentTick.bStartWithTickEnabled = true;
					}
				}
			}
			instance.SeamlessEndHandle = null;
			instance.SeamlessTravelPlayerTeamHandles.Clear();
			instance.SeamlessTravelController.bUseSeamlessCameraActor = false;
			instance.SeamlessTravelController.SeamlessCameraActor = null;
			instance.SeamlessTravelController = null;
			instance.SeamlessTravelTeamDefaultController.Clear();
			instance.SeamlessTravelCamera = null;
			SeamlessTravelScreenEffect seamlessTravelScreenEffect = instance.SeamlessTravelScreenEffect;
			if (seamlessTravelScreenEffect != null)
			{
				seamlessTravelScreenEffect.Destroy();
			}
			instance.SeamlessTravelScreenEffect = null;
			SeamlessTravelTreadmill seamlessTravelTreadmill = instance.SeamlessTravelTreadmill;
			if (seamlessTravelTreadmill != null)
			{
				seamlessTravelTreadmill.Destroy();
			}
			instance.SeamlessTravelTreadmill = null;
			SeamlessTravelKeepKite seamlessTravelKeepKite = instance.SeamlessTravelKeepKite;
			if (seamlessTravelKeepKite != null)
			{
				seamlessTravelKeepKite.Destroy();
			}
			instance.SeamlessTravelKeepKite = null;
			SeamlessTravelKeepMovementMode seamlessTravelKeepMovementMode = instance.SeamlessTravelKeepMovementMode;
			if (seamlessTravelKeepMovementMode != null)
			{
				seamlessTravelKeepMovementMode.Destroy();
			}
			instance.SeamlessTravelKeepMovementMode = null;
			SeamlessTravelPostProcess seamlessTravelPostProcess = instance.SeamlessTravelPostProcess;
			if (seamlessTravelPostProcess != null)
			{
				seamlessTravelPostProcess.Destroy();
			}
			instance.SeamlessTravelPostProcess = null;
			SeamlessTravelSceneEffect seamlessTravelSceneEffect = instance.SeamlessTravelSceneEffect;
			if (seamlessTravelSceneEffect != null)
			{
				seamlessTravelSceneEffect.Destroy();
			}
			instance.SeamlessTravelSceneEffect = null;
			base.PauseTick();
			instance.Config = null;
			instance.HasPreEnableSeamlessTravel = false;
			instance.ClearPromise();
			instance.ClearSeamlessTravelActor();
			instance.SeamlessTravelInputDistributeTags.Clear();
			instance.InSeamlessTraveling = false;
			instance.IsSeamlessTravel = false;
			Singleton<EventSystem>.Instance.Emit(EEventName.SeamlessTravelUIRefresh);
			Singleton<EventSystem>.Instance.Emit(EEventName.SeamlessTravelFinishBeforeShowUI);
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.Seamless, 0);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.YJX, "[无缝加载:完成]", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06034CB5 RID: 216245 RVA: 0x00D3F630 File Offset: 0x00D3D830
		[NullableContext(2)]
		public bool WasRoleEntityInSeamlessTraveling(Entity entity)
		{
			if (entity == null)
			{
				return false;
			}
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (instance == null || !instance.IsSeamlessTravel)
			{
				return false;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			return component != null && this.WasRoleInSeamlessTraveling(component.GetCreatureDataId());
		}

		// Token: 0x06034CB6 RID: 216246 RVA: 0x00D3F674 File Offset: 0x00D3D874
		public bool WasRoleInSeamlessTraveling(long creatureDataId)
		{
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (instance == null || !instance.IsSeamlessTravel)
			{
				return false;
			}
			foreach (EntityHandle entityHandle in instance.SeamlessTravelPlayerTeamHandles)
			{
				if (!entityHandle.Valid)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SeamlessTravel;
					ELogAuthor author = ELogAuthor.YZ;
					string message = "[无缝加载:需要保留的实体被删除！]";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityHandle.Id);
					instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (entityHandle.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId() == creatureDataId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06034CB7 RID: 216247 RVA: 0x00D3F734 File Offset: 0x00D3D934
		public void SeamlessTravelingRefreshData(Entity entity)
		{
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			if (component != null)
			{
				component.SeamlessTravelingRefresh();
			}
			BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
			if (component2 == null)
			{
				return;
			}
			component2.SeamlessTravelingRefresh();
		}

		// Token: 0x0401E686 RID: 124550
		private readonly Action EnterTransitionMap = delegate()
		{
			SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
			if (!instance.IsSeamlessTravel)
			{
				return;
			}
			GameModePromise enterTransitionMapPromise = instance.EnterTransitionMapPromise;
			if (enterTransitionMapPromise == null)
			{
				return;
			}
			enterTransitionMapPromise.SetResult(true);
		};

		// Token: 0x0401E687 RID: 124551
		private readonly Action EnterDestinationMap = delegate()
		{
			SeamlessTravelModel seamlessTravelModel = ModelBase<SeamlessTravelModel>.Instance;
			if (!seamlessTravelModel.IsSeamlessTravel)
			{
				return;
			}
			GameModePromise enterDestinationMapPromise = seamlessTravelModel.EnterDestinationMapPromise;
			if (enterDestinationMapPromise != null)
			{
				enterDestinationMapPromise.SetResult(true);
			}
			Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.YJX, "[无缝加载]进入目标地图并重新设置位置", default(ReadOnlySpan<ValueTuple<string, object>>));
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				return;
			}
			if (seamlessTravelModel.UseTreadmill)
			{
				global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
				global::Vector vector = commonTempVector;
				FVectorDouble location = characterActorComponent.CreatureData.GetLocation();
				vector.DeepCopy(location);
				SeamlessTravelContext config = seamlessTravelModel.Config;
				if (config == null || !config.IsTeleportInPlace)
				{
					commonTempVector.Z += 2000000.0;
				}
				seamlessTravelModel.SeamlessTravelTreadmill.ResetLockOnLocation(commonTempVector, null);
				characterActorComponent.TeleportAndFindStandLocation(Singleton<MathUtils>.Instance.CommonTempVector, true);
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ResetFightCameraLogic(false, true);
				Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.YJX, "[无缝加载:地板隐形(开始)]", default(ReadOnlySpan<ValueTuple<string, object>>));
				seamlessTravelModel.SeamlessTravelTreadmill.DisappearEffect(delegate
				{
					Singleton<Log>.Instance.Info(ELogModule.SeamlessTravel, ELogAuthor.YJX, "[无缝加载:地板隐形(完成)]", default(ReadOnlySpan<ValueTuple<string, object>>));
					seamlessTravelModel.TransitionFloorUnloadedPromise.SetResult(true);
				});
			}
		};
	}
}
