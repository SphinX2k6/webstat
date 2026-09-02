using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Fight.Enum;
using AkiClient.Game.Aki.Data.Fight.FollowShooter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x0200495D RID: 18781
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleExploreComponent : BaseExploreComponent, IStaticVariableResetter
	{
		// Token: 0x060311B4 RID: 201140 RVA: 0x00C37C5E File Offset: 0x00C35E5E
		static MotorcycleExploreComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleExploreComponent.CreateStaticDefaultValue), new Action(MotorcycleExploreComponent.ResetStaticDefaultValue));
		}

		// Token: 0x060311B5 RID: 201141 RVA: 0x00C37C7D File Offset: 0x00C35E7D
		public static void CreateStaticDefaultValue()
		{
			MotorcycleExploreComponent.TraceDebug = false;
			MotorcycleExploreComponent._defaultStateTagId = GameplayTagDefine.EGameplayTagId["关卡.Common.状态.常态"];
		}

		// Token: 0x060311B6 RID: 201142 RVA: 0x00C37C99 File Offset: 0x00C35E99
		public static void ResetStaticDefaultValue()
		{
			MotorcycleExploreComponent.TraceDebug = false;
			MotorcycleExploreComponent._defaultStateTagId = 0;
		}

		// Token: 0x170083C9 RID: 33737
		// (get) Token: 0x060311B7 RID: 201143 RVA: 0x00C37CA8 File Offset: 0x00C35EA8
		// (set) Token: 0x060311B8 RID: 201144 RVA: 0x00C37D9C File Offset: 0x00C35F9C
		[Nullable(2)]
		public GrapplingHookPointComponent PullingTarget
		{
			[NullableContext(2)]
			get
			{
				BaseActorComponent actorComponent = this.ActorComponent;
				if (actorComponent == null || !actorComponent.IsAutonomousProxy)
				{
					if (this.SimulatePullingTarget != null && !this.SimulatePullingTarget.Valid)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Vehicle;
						ELogAuthor author = ELogAuthor.CK;
						string message = this.LogKey + "获取SimulatePullingTarget时钩锁点实体已失效, 重置为undefined";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.SimulatePullingTarget = null;
					}
					return this.SimulatePullingTarget;
				}
				if (this.PullingTargetInternal != null && !this.PullingTargetInternal.Valid)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Vehicle;
					ELogAuthor author2 = ELogAuthor.CK;
					string message2 = this.LogKey + "获取PullingTarget时钩锁点实体已失效, 重置为undefined";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					this.PullingTargetInternal = null;
				}
				return this.PullingTargetInternal;
			}
			[NullableContext(2)]
			set
			{
				GrapplingHookPointComponent pullingTargetInternal = this.PullingTargetInternal;
				if (pullingTargetInternal != null && pullingTargetInternal.Valid && value != this.PullingTargetInternal)
				{
					this.PullingTargetInternal.ChangeHookPointState(EHookPointState.Normal);
				}
				this.PullingTargetInternal = value;
				this.PullingTargetEntityId = ((value != null) ? new int?(value.Entity.Id) : null);
			}
		}

		// Token: 0x170083CA RID: 33738
		// (get) Token: 0x060311B9 RID: 201145 RVA: 0x00C37E00 File Offset: 0x00C36000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public new static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				Type[] array = BaseExploreComponent.Dependencies ?? Array.Empty<Type>();
				int num = 0;
				Type[] array2 = new Type[1 + array.Length];
				ReadOnlySpan<Type> readOnlySpan = new ReadOnlySpan<Type>(array);
				readOnlySpan.CopyTo(new Span<Type>(array2).Slice(num, readOnlySpan.Length));
				num += readOnlySpan.Length;
				array2[num] = typeof(BaseVehiclePerformComponent);
				return array2;
			}
		}

		// Token: 0x060311BA RID: 201146 RVA: 0x00C37E68 File Offset: 0x00C36068
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			base.OnInitData(args);
			this.AutoDetectDistance = (float)ConfigCommonParamById.GetIntConfig("MotorcycleAutoDetectDistance").GetValueOrDefault();
			this.AutoDetectInterval = ConfigCommonParamById.GetFloatConfig("MotorcycleAutoDetectInterval").GetValueOrDefault(0.5f);
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("DisableFollowShooterAutoDetectedAwakeTags");
			if (stringArrayConfig != null && stringArrayConfig.Count > 0)
			{
				foreach (string tagName in stringArrayConfig)
				{
					this.DisableAutoDetectTags.Add(GameplayTagUtils.GetTagIdByName(tagName));
				}
			}
			CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
			this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
			this.BatchCollectRangeEffectPath = ConfigCommonParamById.GetStringConfig("MotorcycleBatchPullRangeEffectPath");
			return true;
		}

		// Token: 0x060311BB RID: 201147 RVA: 0x00C37F40 File Offset: 0x00C36140
		protected override bool OnStart()
		{
			base.OnStart();
			this.LogKey = "(摩托车)探索组件";
			this.TargetSelector.InitForMotorcycle(this);
			RouletteListDataBase rouletteListDataBase;
			this.RouletteListDataMotor = (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Motor, out rouletteListDataBase) ? (rouletteListDataBase as RouletteListDataMotor) : null);
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			this.VehiclePerformComponent = base.Entity.GetComponent<BaseVehiclePerformComponent>();
			BaseVehiclePerformComponent vehiclePerformComponent = this.VehiclePerformComponent;
			if (((vehiclePerformComponent != null) ? vehiclePerformComponent.Driver : null) != null)
			{
				WorldEntity driver = this.VehiclePerformComponent.Driver;
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				if (driver == ((getCurrentEntity != null) ? getCurrentEntity.Entity : null))
				{
					this.OnExploreComponentEnable("(摩托车)探索组件OnStart时驾驶位为主控角色");
				}
			}
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnBeforeSkill));
			return true;
		}

		// Token: 0x060311BC RID: 201148 RVA: 0x00C38048 File Offset: 0x00C36248
		protected override bool OnEnd()
		{
			base.OnEnd();
			this.CancelInteraction();
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			this.OnExploreComponentDisable("OnEnd");
			foreach (int skillId in this.CurrentActiveSkillId)
			{
				BaseSkillComponent skillComponent = this.SkillComponent;
				if (skillComponent != null)
				{
					skillComponent.EndSkill(skillId, "(摩托车)探索组件OnEnd");
				}
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnBeforeSkill));
			return true;
		}

		// Token: 0x060311BD RID: 201149 RVA: 0x00C38128 File Offset: 0x00C36328
		protected override bool OnExploreComponentEnable(string reason)
		{
			if (!base.OnExploreComponentEnable(reason))
			{
				return false;
			}
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ChangeVisionSkillByTab, new Action<int>(this.OnChangeExploreVisionSkillByTab));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.CharBeforeInterruptWithTarget, new Action<int, int>(this.OnBeforeInterruptWithTarget));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CharInterruptSkill, new Action<int, int>(this.OnFixHookSkillInterrupt));
			RouletteListDataMotor rouletteListDataMotor = this.RouletteListDataMotor;
			if (rouletteListDataMotor != null)
			{
				rouletteListDataMotor.ChangeRouletteActivateStatus(true);
			}
			return true;
		}

		// Token: 0x060311BE RID: 201150 RVA: 0x00C381E8 File Offset: 0x00C363E8
		protected override bool OnExploreComponentDisable(string reason)
		{
			if (!base.OnExploreComponentDisable(reason))
			{
				return false;
			}
			this.CancelInteraction();
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.ChangeVisionSkillByTab, new Action<int>(this.OnChangeExploreVisionSkillByTab));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.CharBeforeInterruptWithTarget, new Action<int, int>(this.OnBeforeInterruptWithTarget));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.CharInterruptSkill, new Action<int, int>(this.OnFixHookSkillInterrupt));
			this.EjectInterruptingSkillId = null;
			RouletteListDataMotor rouletteListDataMotor = this.RouletteListDataMotor;
			if (rouletteListDataMotor != null)
			{
				rouletteListDataMotor.ChangeRouletteActivateStatus(false);
			}
			this.PlatformRotationDriver.End();
			return true;
		}

		// Token: 0x060311BF RID: 201151 RVA: 0x00C382C4 File Offset: 0x00C364C4
		protected override void OnExploreComponentTick(float delta)
		{
			this.TryDetectFollowShooterAutoEnable();
			this.TryDetectHookPoint();
			if (this.IsLockingTarget)
			{
				GrapplingHookPointComponent focusTarget = base.FocusTarget;
				if (focusTarget == null || !focusTarget.Valid)
				{
					base.CancelLockTarget("FocusTarget is Invalid", true);
				}
			}
			this.PlatformRotationDriver.Tick(delta);
		}

		// Token: 0x060311C0 RID: 201152 RVA: 0x00C38314 File Offset: 0x00C36514
		public override bool CheckAllowLevelEventHighlightSkill()
		{
			return !this.IsLockingTarget;
		}

		// Token: 0x060311C1 RID: 201153 RVA: 0x00C38320 File Offset: 0x00C36520
		public override void OnLevelEventHighlightSkillUpdate(bool enabled)
		{
			this.LevelEventHighlightingSkill = enabled;
			int? currentIconTagId = this.CurrentIconTagId;
			int? currentIconHighlightTagId = this.CurrentIconHighlightTagId;
			if (enabled)
			{
				if (currentIconTagId != null && currentIconTagId.GetValueOrDefault() != 0 && this.TagComponent.HasTag(currentIconTagId.Value))
				{
					this.TagComponent.RemoveTag(new int?(currentIconTagId.Value));
				}
				if (currentIconHighlightTagId != null && currentIconHighlightTagId.GetValueOrDefault() != 0 && this.TagComponent.HasTag(currentIconHighlightTagId.Value))
				{
					this.TagComponent.RemoveTag(new int?(currentIconHighlightTagId.Value));
					return;
				}
			}
			else
			{
				if (currentIconTagId != null && currentIconTagId.GetValueOrDefault() != 0 && !this.TagComponent.HasTag(currentIconTagId.Value))
				{
					this.TagComponent.AddTag(new int?(currentIconTagId.Value));
				}
				if (currentIconHighlightTagId != null && currentIconHighlightTagId.GetValueOrDefault() != 0 && !this.TagComponent.HasTag(currentIconHighlightTagId.Value))
				{
					this.TagComponent.AddTag(new int?(currentIconHighlightTagId.Value));
				}
			}
		}

		// Token: 0x060311C2 RID: 201154 RVA: 0x00C38448 File Offset: 0x00C36648
		public int GetSkillIdByCurrentTarget()
		{
			HighlightExploreSkillLogic highlightLogic = this.HighlightLogic;
			int num = (highlightLogic != null) ? highlightLogic.GetHighlightSkillId() : 0;
			if (num != 0)
			{
				return num;
			}
			if (!base.FocusTargetLegal || base.FocusTarget == null)
			{
				return 0;
			}
			if (!this.IsLockingTarget && (ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.IsDisabled() || this.IsFocusTypeDisabled()))
			{
				return 0;
			}
			IHookInteractType hookInteractConfig = base.FocusTarget.GetHookInteractConfig();
			EHookInteractType? ehookInteractType = (hookInteractConfig != null) ? new EHookInteractType?(hookInteractConfig.Type) : null;
			if (ehookInteractType != null)
			{
				EHookInteractType valueOrDefault = ehookInteractType.GetValueOrDefault();
				if (valueOrDefault == EHookInteractType.KiteHook)
				{
					return 10001035;
				}
				switch (valueOrDefault)
				{
				case EHookInteractType.PilotThrow:
					return 10001029;
				case EHookInteractType.CableWay:
					return 10001028;
				case EHookInteractType.MotorPullInteract:
					return 10001006;
				case EHookInteractType.MotorEject:
					return 10002001;
				}
			}
			return 10001027;
		}

		// Token: 0x060311C3 RID: 201155 RVA: 0x00C38534 File Offset: 0x00C36734
		public bool TryPullCollection()
		{
			GrapplingHookPointComponent pullingTarget = this.PullingTarget;
			return pullingTarget != null && pullingTarget.Valid && this.PullCollection(pullingTarget);
		}

		// Token: 0x060311C4 RID: 201156 RVA: 0x00C38564 File Offset: 0x00C36764
		private unsafe bool PullCollection(GrapplingHookPointComponent mainHook)
		{
			WorldEntity playerEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
			List<long> list = null;
			if (mainHook.AllowBatchCollect)
			{
				list = new List<long>();
				float valueOrDefault = ConfigCommonParamById.GetFloatConfig("MotorcycleBatchPullCollectionRadius").GetValueOrDefault(5000f);
				if (valueOrDefault > 5000f)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Vehicle;
					ELogAuthor author = ELogAuthor.CK;
					string message = "(摩托车)探索组件批量拉取采集物范围超过最大限制, 检查配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Radius", valueOrDefault);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("MotorcycleBatchPullCollectionCount").GetValueOrDefault(15);
				if (valueOrDefault2 > 15)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Vehicle;
					ELogAuthor author2 = ELogAuthor.CK;
					string message2 = "(摩托车)探索组件批量拉取采集物数量超过最大限制, 检查配置";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MaxCount", valueOrDefault2);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(mainHook.HookLocation, valueOrDefault, EEntityTypeQuery.SceneItem, this.TmpHandles, true);
				foreach (EntityHandle entityHandle in this.TmpHandles)
				{
					GrapplingHookPointComponent component = entityHandle.Entity.GetComponent<GrapplingHookPointComponent>();
					if (component != null && component.HookInteractType.GetValueOrDefault() == EHookInteractType.MotorPullInteract && entityHandle.Id != mainHook.Entity.Id && !component.PullCollectionWithProgress)
					{
						if (list.Count >= valueOrDefault2)
						{
							Singleton<Log>.Instance.Error(ELogModule.Vehicle, ELogAuthor.CK, "(摩托车)探索组件拉取采集物失败, 数量超过限制", default(ReadOnlySpan<ValueTuple<string, object>>));
							break;
						}
						list.Add(component.ServerEntityId);
						if (!component.DisableCollectEffect)
						{
							ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(playerEntity, "200300046", component.HookTransform, null, null, global::EBulletCreateSource.Others);
						}
					}
				}
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (mainHook.PullCollectionWithProgress)
			{
				Action onCollectFailed = delegate()
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Vehicle;
					ELogAuthor author3 = ELogAuthor.CK;
					string message3 = "(摩托车)探索组件拉取采集物失败, 回退采集客户端预表现的隐藏实体操作";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", mainHook.EntityConfigId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ServerEntityId", mainHook.ServerEntityId);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					mainHook.StopPullMove();
					LevelGeneralCommons.RollbackDestroyState(mainHook.EntityConfigId, MotorcycleExploreComponent._defaultStateTagId);
				};
				if (list != null)
				{
					this.RequestBatchCollect(instanceId, 0L, list, null);
				}
				return mainHook.StartPullMove(delegate
				{
					this.RequestBatchCollect(instanceId, mainHook.ServerEntityId, null, onCollectFailed);
					if (!mainHook.DisableCollectEffect)
					{
						ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(playerEntity, "200300046", mainHook.HookTransform, null, null, global::EBulletCreateSource.Others);
					}
				});
			}
			this.RequestBatchCollect(instanceId, mainHook.ServerEntityId, list, null);
			return true;
		}

		// Token: 0x060311C5 RID: 201157 RVA: 0x00C38810 File Offset: 0x00C36A10
		[NullableContext(2)]
		private void RequestBatchCollect(int instanceId, long mainTargetEntityId, List<long> batchTargetEntityIds = null, Action onCollectFailed = null)
		{
			HookLockBatchCollectRequest hookLockBatchCollectRequest = HookLockBatchCollectRequest.Create();
			hookLockBatchCollectRequest.InstId = instanceId;
			hookLockBatchCollectRequest.EntityId = mainTargetEntityId;
			if (batchTargetEntityIds != null)
			{
				hookLockBatchCollectRequest.BatchIds.AddRange(batchTargetEntityIds);
			}
			GrapplingHookPointComponent currentPullingTarget = this.PullingTarget;
			Singleton<Net>.Instance.Call<HookLockBatchCollectResponse>(ERequestMessageId.HookLockBatchCollectRequest, hookLockBatchCollectRequest, delegate(HookLockBatchCollectResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Vehicle;
					ELogAuthor author = ELogAuthor.CK;
					string message = "RequestBatchCollect失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					if (currentPullingTarget == this.PullingTarget)
					{
						this.PullingTarget = null;
					}
					Action onCollectFailed2 = onCollectFailed;
					if (onCollectFailed2 == null)
					{
						return;
					}
					onCollectFailed2();
				}
			}, 0);
		}

		// Token: 0x060311C6 RID: 201158 RVA: 0x00C38880 File Offset: 0x00C36A80
		private void CancelInteraction()
		{
			GrapplingHookPointComponent pullingTarget = this.PullingTarget;
			if (pullingTarget == null || !pullingTarget.Valid)
			{
				this.PullingTarget = null;
				return;
			}
			GrapplingHookPointComponent pullingTarget2 = this.PullingTarget;
			if (pullingTarget2 != null && pullingTarget2.GetHookInteractType().GetValueOrDefault() == EHookInteractType.MotorPullInteract)
			{
				this.PullingTarget.StopPullMove();
			}
			GrapplingHookPointComponent pullingTarget3 = this.PullingTarget;
			if (pullingTarget3 != null)
			{
				pullingTarget3.ChangeHookPointState(EHookPointState.Normal);
			}
			base.SendHookEndRequest(this.PullingTarget, null);
			this.PullingTarget = null;
		}

		// Token: 0x060311C7 RID: 201159 RVA: 0x00C38900 File Offset: 0x00C36B00
		private void TryDetectHookPoint()
		{
			if (this.IsLockingTarget)
			{
				return;
			}
			if (ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.IsDisabled())
			{
				if (base.FocusTarget != null)
				{
					this.ClearDetectedTarget("HookDetectDisabled");
				}
				return;
			}
			if (this.LevelEventHighlightingSkill)
			{
				base.SetFocusTarget(null, true);
				return;
			}
			this.TargetSelector.TraceDebugEnabled = MotorcycleExploreComponent.TraceDebug;
			this.TargetSelector.DetectBestTargetForMotorcycle(ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.GetEnabledTypes());
			bool flag = this.TargetSelector.DetectedTargetLegal && this.DetectedTargetLegalOnceFlag;
			GrapplingHookPointComponent detectedTarget = this.TargetSelector.DetectedTarget;
			if (base.FocusTarget != detectedTarget)
			{
				this.DetectedTargetLegalOnceFlag = true;
			}
			if (base.FocusTarget != detectedTarget || base.FocusTargetLegal != flag)
			{
				base.SetFocusTarget(detectedTarget, flag);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.CK;
				string message = "(摩托车)探索组件锁定钩锁点";
				string item = "PbDataId";
				int? num;
				if (detectedTarget == null)
				{
					num = null;
				}
				else
				{
					CreatureDataComponent component = detectedTarget.Entity.GetComponent<CreatureDataComponent>();
					num = ((component != null) ? new int?(component.GetPbDataId()) : null);
				}
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, num);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060311C8 RID: 201160 RVA: 0x00C38A24 File Offset: 0x00C36C24
		public override void ClearDetectedTarget(string reason)
		{
			if (this.IsLockingTarget)
			{
				return;
			}
			this.TargetSelector.ClearDetectionData();
			this.DetectedTargetLegalOnceFlag = true;
			base.SetFocusTarget(null, true);
			this.CurrentIconTagId = null;
			this.CurrentIconHighlightTagId = null;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.CK;
			string message = "(摩托车)探索组件清理已探测钩锁目标";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060311C9 RID: 201161 RVA: 0x00C38A96 File Offset: 0x00C36C96
		private bool IsTypeDisabled(EHookInteractType hookType)
		{
			return ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.IsTypeDisabled(hookType);
		}

		// Token: 0x060311CA RID: 201162 RVA: 0x00C38AA8 File Offset: 0x00C36CA8
		private bool IsFocusTypeDisabled()
		{
			GrapplingHookPointComponent focusTarget = base.FocusTarget;
			EHookInteractType? ehookInteractType = (focusTarget != null) ? focusTarget.GetHookInteractType() : null;
			return ehookInteractType != null && this.IsTypeDisabled(ehookInteractType.Value);
		}

		// Token: 0x060311CB RID: 201163 RVA: 0x00C38AE8 File Offset: 0x00C36CE8
		private void TryDetectFollowShooterAutoEnable()
		{
			if (Singleton<Time>.Instance.WorldTimeSeconds - (double)this.LastAutoDetectTimeStamp < (double)this.AutoDetectInterval)
			{
				return;
			}
			this.LastAutoDetectTimeStamp = (float)Singleton<Time>.Instance.WorldTimeSeconds;
			bool enable = false;
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasAnyTag(this.DisableAutoDetectTags))
			{
				EntityHandle playerFollowShooter = FollowUtils.GetPlayerFollowShooter(this.PlayerId);
				object obj;
				if (playerFollowShooter == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = playerFollowShooter.Entity;
					obj = ((entity != null) ? entity.CheckGetComponent<CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow.FollowShooterComponent>() : null);
				}
				object obj2 = obj;
				FGameplayTagContainer fgameplayTagContainer;
				if (obj2 == null)
				{
					fgameplayTagContainer = null;
				}
				else
				{
					BP_FollowShooterConfig_C followShooterConfig = obj2.FollowShooterConfig;
					fgameplayTagContainer = ((followShooterConfig != null) ? followShooterConfig.LockOnConfig.AutoDetectEnableTagContainer : null);
				}
				FGameplayTagContainer fgameplayTagContainer2 = fgameplayTagContainer;
				if (fgameplayTagContainer2 == null || fgameplayTagContainer2.GameplayTags.Num() == 0)
				{
					return;
				}
				enable = (this.TargetSelector.DetectEntityByRestrictTags(this.AutoDetectDistance, EEntityTypeQuery.SceneItemOrCharacter, fgameplayTagContainer2, true) != null);
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return;
			}
			FollowUtils.SetPlayerFollowShooterEnable(component.GetPlayerId(), enable, BPEEnableFollowShooter.AutoDetectedGamePartitionObject, "");
		}

		// Token: 0x060311CC RID: 201164 RVA: 0x00C38BD8 File Offset: 0x00C36DD8
		private void OnChangeExploreVisionSkillByTab(int id)
		{
			this.DetectedTargetLegalOnceFlag = false;
		}

		// Token: 0x060311CD RID: 201165 RVA: 0x00C38BE4 File Offset: 0x00C36DE4
		[NullableContext(2)]
		protected override void OnDetectedTargetChanged(GrapplingHookPointComponent prevTarget)
		{
			if (prevTarget != null && prevTarget.Valid && prevTarget != base.FocusTarget)
			{
				prevTarget.ChangeHookPointState(EHookPointState.Normal);
			}
			GrapplingHookPointComponent focusTarget = base.FocusTarget;
			if (focusTarget != null && focusTarget.Valid)
			{
				base.FocusTarget.ChangeHookPointState(base.FocusTargetLegal ? EHookPointState.Interactive : EHookPointState.NonInteractive);
			}
			if (base.FocusTarget != null && base.FocusTargetLegal)
			{
				base.HandleSkillIconLogic(true, "(摩托车)探索组件当前选中的钩锁点有效");
				this.CreateBatchCollectRangeEffect(base.FocusTarget);
				return;
			}
			base.HandleSkillIconLogic(false, "(摩托车)探索组件当前未选中点或者选中的点无效");
			this.DestroyBatchCollectRangeEffect("(摩托车)探索组件当前未选中点或者选中的点无效");
		}

		// Token: 0x060311CE RID: 201166 RVA: 0x00C38C78 File Offset: 0x00C36E78
		private void CreateBatchCollectRangeEffect(GrapplingHookPointComponent target)
		{
			this.DestroyBatchCollectRangeEffect("(摩托车)探索组件选中新目标时尝试移除旧目标的特效");
			if (target.HookInteractType.GetValueOrDefault() != EHookInteractType.MotorPullInteract)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.BatchCollectRangeEffectPath))
			{
				return;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject owner = target.ActorComp.Owner;
			FTransformDouble? ftransformDouble = new FTransformDouble?(target.ActorComp.ActorTransform);
			this.BatchCollectRangeEffectHandleId = new int?(instance.SpawnEffect(owner, ftransformDouble, this.BatchCollectRangeEffectPath, "[MotorcycleExploreComponent.OnDetectedTargetChanged]", new EffectContext(new int?(target.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false));
		}

		// Token: 0x060311CF RID: 201167 RVA: 0x00C38D0C File Offset: 0x00C36F0C
		private void DestroyBatchCollectRangeEffect(string reason)
		{
			bool flag = (this.BatchCollectRangeEffectHandleId ?? 0) == 0;
			if (flag)
			{
				return;
			}
			Singleton<EffectSystem>.Instance.StopEffectById(this.BatchCollectRangeEffectHandleId.Value, reason, true, null);
			this.BatchCollectRangeEffectHandleId = null;
		}

		// Token: 0x060311D0 RID: 201168 RVA: 0x00C38D6C File Offset: 0x00C36F6C
		private unsafe void OnBeforeSkill(int skillId, bool IsAutonomousProxy)
		{
			BaseActorComponent actorComponent = this.ActorComponent;
			if (actorComponent == null || !actorComponent.IsAutonomousProxy)
			{
				return;
			}
			if (!MotorcycleHookDetectRestriction.MotorcycleHookSkillIds.Contains(skillId))
			{
				return;
			}
			if (skillId == 10002001)
			{
				this.EjectInterruptingSkillId = null;
			}
			GrapplingHookPointComponent focusTarget2 = base.FocusTarget;
			if (focusTarget2 == null || !focusTarget2.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.CK;
				string message = "使用探索技能时(摩托车)探索组件当前目标为空, 请检查技能Id配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsHookEndByInterrupt = false;
			this.SimulateInteractingTarget = null;
			this.SimulateInteractingTargetLocation = null;
			GrapplingHookPointComponent focusTarget = base.FocusTarget;
			focusTarget.BeHooked(skillId);
			if (skillId == 10001006)
			{
				this.PullingTarget = focusTarget;
				this.SendPullCollectionPush();
			}
			else
			{
				base.InteractingTarget = focusTarget;
				base.SendHookMovePush();
			}
			ICompositeExploreSkillConfig compositeExploreSkillConfig;
			CompositeExploreSkillSession.CompositeExploreSkillConfigs.TryGetValue(skillId, out compositeExploreSkillConfig);
			if (compositeExploreSkillConfig != null)
			{
				ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.TryCleanStaleCompositeSession(skillId, ELogModule.Vehicle, "(摩托车)入口技能重新触发时检测到残留会话");
				ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.ActiveCompositeSession = new CompositeSkillSession
				{
					Config = compositeExploreSkillConfig,
					EnterSent = true,
					CreatedTime = Singleton<Time>.Instance.Now
				};
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Vehicle;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "(摩托车)复合探索技能会话已创建";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CompositeName", compositeExploreSkillConfig.Name);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.TryCleanStaleCompositeSession(skillId, ELogModule.Vehicle, "(摩托车)非入口技能触发时检测到残留会话");
			}
			base.SendHookTargetRequest(focusTarget, delegate
			{
				this.IsHookEndByInterrupt = true;
				foreach (int skillId2 in MotorcycleHookDetectRestriction.MotorcycleHookSkillIds)
				{
					BaseSkillComponent skillComponent = this.SkillComponent;
					if (skillComponent != null)
					{
						skillComponent.EndSkill(skillId2, "(摩托车)探索组件请求服务器返回错误码");
					}
				}
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Vehicle;
				ELogAuthor author3 = ELogAuthor.CK;
				string message3 = "(摩托车)探索组件请求服务器返回错误码";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityConfigId", focusTarget.EntityConfigId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}, (compositeExploreSkillConfig != null) ? compositeExploreSkillConfig.Name : null);
			this.CurrentActiveSkillId.Add(skillId);
			this.EnsureRemoveEntityListener(skillId);
		}

		// Token: 0x060311D1 RID: 201169 RVA: 0x00C38F78 File Offset: 0x00C37178
		private void EnsureRemoveEntityListener(int skillId)
		{
			if (Singleton<EventSystem>.Instance.Has<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove)))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.CK;
			string message = "(摩托车)探索组件添加RemoveEntity事件监听";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove));
		}

		// Token: 0x060311D2 RID: 201170 RVA: 0x00C38FF0 File Offset: 0x00C371F0
		private void TryRemoveEntityListener(int skillId)
		{
			if (this.CurrentActiveSkillId.Count > 0 || !Singleton<EventSystem>.Instance.Has<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove)))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.CK;
			string message = "(摩托车)探索组件移除RemoveEntity事件监听";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove));
		}

		// Token: 0x060311D3 RID: 201171 RVA: 0x00C39074 File Offset: 0x00C37274
		private unsafe void OnCharUseSkill(int entityId, int skillId, bool isAutonomousProxy)
		{
			if (skillId != 10002002 || !isAutonomousProxy)
			{
				return;
			}
			GrapplingHookPointComponent interactingTarget = base.InteractingTarget;
			if (interactingTarget == null || !interactingTarget.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "摩托弹射钩锁进入平台 idle 时,关联的钩锁目标失效或未缓存";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("hasInteractingTarget", base.InteractingTarget != null);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item = "interactingTargetValid";
				GrapplingHookPointComponent interactingTarget2 = base.InteractingTarget;
				ptr = new ValueTuple<string, object>(item, interactingTarget2 != null && interactingTarget2.Valid);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			this.PlatformRotationDriver.Begin(this, interactingTarget);
			this.CurrentActiveSkillId.Add(skillId);
			this.EnsureRemoveEntityListener(skillId);
		}

		// Token: 0x060311D4 RID: 201172 RVA: 0x00C39161 File Offset: 0x00C37361
		private void OnBeforeInterruptWithTarget(int newSkillId, int interruptedSkillId)
		{
			if (interruptedSkillId != 10002001)
			{
				return;
			}
			this.EjectInterruptingSkillId = new int?(newSkillId);
		}

		// Token: 0x060311D5 RID: 201173 RVA: 0x00C39178 File Offset: 0x00C37378
		private void OnSkillEnd(int entityId, int skillId)
		{
			BaseActorComponent actorComponent = this.ActorComponent;
			if (actorComponent == null || !actorComponent.IsAutonomousProxy)
			{
				return;
			}
			if (!MotorcycleHookDetectRestriction.MotorcycleHookSkillIds.Contains(skillId) && skillId != 10002002)
			{
				return;
			}
			if (skillId == 10001006)
			{
				if (this.PullingTarget == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Vehicle;
					ELogAuthor author = ELogAuthor.CK;
					string message = "使用探索技能时(摩托车)探索组件当前目标为空, 请检查技能Id配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
			}
			else if (skillId == 10002002)
			{
				if (base.InteractingTarget == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Vehicle;
					ELogAuthor author2 = ELogAuthor.WRY;
					string message2 = "摩托脱离弹射钩锁平台时，关联探索组件当前目标为空, 请检查技能Id配置";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SkillId", skillId);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			else if (base.InteractingTarget == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Vehicle;
				ELogAuthor author3 = ELogAuthor.CK;
				string message3 = "使用探索技能时(摩托车)探索组件当前目标为空, 请检查技能Id配置";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("SkillId", skillId);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			this.DoSkillEnd(skillId, "OnSkillEnd");
		}

		// Token: 0x060311D6 RID: 201174 RVA: 0x00C3927C File Offset: 0x00C3747C
		private unsafe void DoSkillEnd(int skillId, string reason)
		{
			if (!this.CurrentActiveSkillId.Contains(skillId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.CK;
				string message = "(摩托车)探索组件技能重复触发结束处理函数";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "(摩托车)探索组件技能结束";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("SkillId", skillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.CurrentActiveSkillId.Remove(skillId);
			GrapplingHookPointComponent grapplingHookPointComponent;
			if (skillId == 10001006)
			{
				grapplingHookPointComponent = this.PullingTarget;
				this.PullingTarget = null;
			}
			else if (skillId == 10002001)
			{
				VehicleCatapultComponent component = base.Entity.GetComponent<VehicleCatapultComponent>();
				bool flag;
				if (this.EjectInterruptingSkillId.GetValueOrDefault() == 10002002 && component != null && component.GetHasReachedTarget())
				{
					GrapplingHookPointComponent interactingTarget = base.InteractingTarget;
					flag = (interactingTarget != null && interactingTarget.Valid);
				}
				else
				{
					flag = false;
				}
				this.EjectInterruptingSkillId = null;
				if (flag)
				{
					return;
				}
				grapplingHookPointComponent = base.InteractingTarget;
				base.InteractingTarget = null;
			}
			else if (skillId == 10002002)
			{
				grapplingHookPointComponent = base.InteractingTarget;
				this.PlatformRotationDriver.End();
				base.InteractingTarget = null;
			}
			else
			{
				grapplingHookPointComponent = base.InteractingTarget;
				base.InteractingTarget = null;
			}
			if (grapplingHookPointComponent != null && grapplingHookPointComponent.Valid)
			{
				grapplingHookPointComponent.ChangeHookPointState(EHookPointState.Normal);
				ICompositeSkillSession activeCompositeSession = ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.ActiveCompositeSession;
				if (activeCompositeSession != null && activeCompositeSession.Config.EntrySkillId == skillId)
				{
					if (this.IsHookEndByInterrupt)
					{
						base.SendHookEndRequest(grapplingHookPointComponent, activeCompositeSession.Config.Name);
						ModelBase<CharacterExploreModel>.Instance.CompositeExploreSkillSession.ActiveCompositeSession = null;
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Vehicle;
						ELogAuthor author3 = ELogAuthor.CK;
						string message3 = "(摩托车)复合探索技能被打断, 入口技能保底发送Exit并清除会话";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("SkillId", skillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("CompositeName", activeCompositeSession.Config.Name);
						instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					}
					else
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Vehicle;
						ELogAuthor author4 = ELogAuthor.CK;
						string message4 = "(摩托车)复合探索技能: 入口技能正常结束, 跳过SendHookEndRequest";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("SkillId", skillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("CompositeName", activeCompositeSession.Config.Name);
						instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
				}
				else
				{
					base.SendHookEndRequest(grapplingHookPointComponent, null);
				}
			}
			base.CancelLockTarget("DoSkillEnd", false);
			this.TryRemoveEntityListener(skillId);
		}

		// Token: 0x060311D7 RID: 201175 RVA: 0x00C3956C File Offset: 0x00C3776C
		private void OnFixHookSkillInterrupt(int entityId, int skillId)
		{
			if (entityId != base.Entity.Id || !MotorcycleHookDetectRestriction.MotorcycleHookSkillIds.Contains(skillId) || skillId == 10002002)
			{
				return;
			}
			this.IsHookEndByInterrupt = true;
		}

		// Token: 0x060311D8 RID: 201176 RVA: 0x00C3959C File Offset: 0x00C3779C
		private unsafe void OnEntityRemove(ERemoveEntityType removeType, EntityHandle handle)
		{
			int? interactingTargetEntityId = this.InteractingTargetEntityId;
			int id = handle.Id;
			if (!(interactingTargetEntityId.GetValueOrDefault() == id & interactingTargetEntityId != null))
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.CK, "(摩托车)探索组件当前交互目标实体被移除", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.InteractingTarget = null;
			this.PlatformRotationDriver.End();
			this.IsHookEndByInterrupt = true;
			foreach (int num in this.CurrentActiveSkillId)
			{
				if (num != 10001006)
				{
					BaseSkillComponent skillComponent = this.SkillComponent;
					if (skillComponent != null)
					{
						skillComponent.EndSkill(num, "(摩托车)探索组件当前交互目标实体被移除");
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Vehicle;
					ELogAuthor author = ELogAuthor.CK;
					string message = "(摩托车)探索组件当前交互目标点在技能释放过程中被删除，请检查配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "EntityConfigId";
					CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
					ptr = new ValueTuple<string, object>(item, (component != null) ? new int?(component.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillId", num);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			this.TryRemoveEntityListener(0);
		}

		// Token: 0x060311D9 RID: 201177 RVA: 0x00C396FC File Offset: 0x00C378FC
		private void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsDriver || info.PassengerEntity == null || !info.IsRolePassenger(true))
			{
				return;
			}
			this.DriverEntityId = info.PassengerEntity.Id;
			Singleton<Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.CK, "主控角色进入摩托车激活(摩托车)探索组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnExploreComponentEnable("OnVehicleBeenEntered");
		}

		// Token: 0x060311DA RID: 201178 RVA: 0x00C39760 File Offset: 0x00C37960
		private void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (info.IsDriver)
			{
				int driverEntityId = this.DriverEntityId;
				Entity passengerEntity = info.PassengerEntity;
				int? num = (passengerEntity != null) ? new int?(passengerEntity.Id) : null;
				if (driverEntityId == num.GetValueOrDefault() & num != null)
				{
					Singleton<Log>.Instance.Info(ELogModule.Vehicle, ELogAuthor.CK, "主控角色离开摩托车关闭(摩托车)探索组件", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.OnExploreComponentDisable("OnVehicleBeenLeaved");
					return;
				}
			}
		}

		// Token: 0x060311DB RID: 201179 RVA: 0x00C397DC File Offset: 0x00C379DC
		private void SendPullCollectionPush()
		{
			GrapplingHookPointComponent pullingTarget = this.PullingTarget;
			if (pullingTarget != null && pullingTarget.Valid)
			{
				BaseActorComponent actorComponent = this.ActorComponent;
				if (actorComponent != null && actorComponent.IsAutonomousProxy)
				{
					RoleSceneInteractController.SendPullCollectionPush(base.Entity, pullingTarget);
					return;
				}
			}
		}

		// Token: 0x060311DC RID: 201180 RVA: 0x00C39828 File Offset: 0x00C37A28
		public unsafe long GetPullCollectionBuffIdByTarget()
		{
			GrapplingHookPointComponent pullingTarget = this.PullingTarget;
			if (pullingTarget == null || !pullingTarget.Valid)
			{
				return 640003034L;
			}
			long valueOrDefault = pullingTarget.GetMotorHookEffectBuffId().GetValueOrDefault(640003034L);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[MotorcycleExploreComponent] GetPullCollectionBuffIdByTarget";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", pullingTarget.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", valueOrDefault);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return valueOrDefault;
		}

		// Token: 0x060311DD RID: 201181 RVA: 0x00C398CC File Offset: 0x00C37ACC
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleExploreComponent motorcycleExploreComponent = (MotorcycleExploreComponent)componentTemplate;
			if (base.CanResetComponentProperty("VehiclePerformComponent"))
			{
				if (motorcycleExploreComponent.VehiclePerformComponent == null)
				{
					this.VehiclePerformComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.VehiclePerformComponent), "VehiclePerformComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetSelector") && motorcycleExploreComponent.TargetSelector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<InteractionTargetSelector>(this.TargetSelector), "TargetSelector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpHandles") && motorcycleExploreComponent.TmpHandles != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<EntityHandle>>(this.TmpHandles), "TmpHandles"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LevelEventHighlightingSkill"))
			{
				this.LevelEventHighlightingSkill = motorcycleExploreComponent.LevelEventHighlightingSkill;
			}
			if (base.CanResetComponentProperty("RouletteListDataMotor"))
			{
				if (motorcycleExploreComponent.RouletteListDataMotor == null)
				{
					this.RouletteListDataMotor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RouletteListDataMotor>(this.RouletteListDataMotor), "RouletteListDataMotor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DetectedTargetLegalOnceFlag"))
			{
				this.DetectedTargetLegalOnceFlag = motorcycleExploreComponent.DetectedTargetLegalOnceFlag;
			}
			if (base.CanResetComponentProperty("CurrentActiveSkillId") && motorcycleExploreComponent.CurrentActiveSkillId != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.CurrentActiveSkillId), "CurrentActiveSkillId"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EjectInterruptingSkillId"))
			{
				this.EjectInterruptingSkillId = motorcycleExploreComponent.EjectInterruptingSkillId;
			}
			if (base.CanResetComponentProperty("DriverEntityId"))
			{
				this.DriverEntityId = motorcycleExploreComponent.DriverEntityId;
			}
			if (base.CanResetComponentProperty("PlayerId"))
			{
				this.PlayerId = motorcycleExploreComponent.PlayerId;
			}
			if (base.CanResetComponentProperty("PlatformRotationDriver") && motorcycleExploreComponent.PlatformRotationDriver != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcyclePlatformRotationDriver>(this.PlatformRotationDriver), "PlatformRotationDriver"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("PullingTargetInternal"))
			{
				if (motorcycleExploreComponent.PullingTargetInternal == null)
				{
					this.PullingTargetInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.PullingTargetInternal), "PullingTargetInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PullingTargetEntityId"))
			{
				this.PullingTargetEntityId = motorcycleExploreComponent.PullingTargetEntityId;
			}
			if (base.CanResetComponentProperty("SimulatePullingTarget"))
			{
				if (motorcycleExploreComponent.SimulatePullingTarget == null)
				{
					this.SimulatePullingTarget = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.SimulatePullingTarget), "SimulatePullingTarget"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BatchCollectRangeEffectHandleId"))
			{
				this.BatchCollectRangeEffectHandleId = motorcycleExploreComponent.BatchCollectRangeEffectHandleId;
			}
			if (base.CanResetComponentProperty("BatchCollectRangeEffectPath"))
			{
				this.BatchCollectRangeEffectPath = motorcycleExploreComponent.BatchCollectRangeEffectPath;
			}
			if (base.CanResetComponentProperty("AutoDetectDistance"))
			{
				this.AutoDetectDistance = motorcycleExploreComponent.AutoDetectDistance;
			}
			if (base.CanResetComponentProperty("AutoDetectInterval"))
			{
				this.AutoDetectInterval = motorcycleExploreComponent.AutoDetectInterval;
			}
			if (base.CanResetComponentProperty("DisableAutoDetectTags"))
			{
				if (motorcycleExploreComponent.DisableAutoDetectTags == null)
				{
					this.DisableAutoDetectTags = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.DisableAutoDetectTags), "DisableAutoDetectTags"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastAutoDetectTimeStamp"))
			{
				this.LastAutoDetectTimeStamp = motorcycleExploreComponent.LastAutoDetectTimeStamp;
			}
			return true;
		}

		// Token: 0x0401C459 RID: 115801
		private static int _defaultStateTagId;

		// Token: 0x0401C45A RID: 115802
		private const float BATCH_PULL_COLLECTION_MAX_RADIUS = 5000f;

		// Token: 0x0401C45B RID: 115803
		private const int BATCH_PULL_COLLECTION_MAX_COUNT = 15;

		// Token: 0x0401C45C RID: 115804
		private const long DEFAULT_PULL_COLLECTION_BUFF_ID = 640003034L;

		// Token: 0x0401C45D RID: 115805
		public static bool TraceDebug;

		// Token: 0x0401C45E RID: 115806
		[Nullable(2)]
		protected BaseVehiclePerformComponent VehiclePerformComponent;

		// Token: 0x0401C45F RID: 115807
		private readonly InteractionTargetSelector TargetSelector = new InteractionTargetSelector();

		// Token: 0x0401C460 RID: 115808
		private readonly List<EntityHandle> TmpHandles = new List<EntityHandle>();

		// Token: 0x0401C461 RID: 115809
		private bool LevelEventHighlightingSkill;

		// Token: 0x0401C462 RID: 115810
		[Nullable(2)]
		private RouletteListDataMotor RouletteListDataMotor;

		// Token: 0x0401C463 RID: 115811
		public bool DetectedTargetLegalOnceFlag = true;

		// Token: 0x0401C464 RID: 115812
		private readonly HashSet<int> CurrentActiveSkillId = new HashSet<int>();

		// Token: 0x0401C465 RID: 115813
		private int? EjectInterruptingSkillId;

		// Token: 0x0401C466 RID: 115814
		private int DriverEntityId;

		// Token: 0x0401C467 RID: 115815
		private int PlayerId;

		// Token: 0x0401C468 RID: 115816
		private readonly MotorcyclePlatformRotationDriver PlatformRotationDriver = new MotorcyclePlatformRotationDriver();

		// Token: 0x0401C469 RID: 115817
		[Nullable(2)]
		private GrapplingHookPointComponent PullingTargetInternal;

		// Token: 0x0401C46A RID: 115818
		protected int? PullingTargetEntityId;

		// Token: 0x0401C46B RID: 115819
		[Nullable(2)]
		public GrapplingHookPointComponent SimulatePullingTarget;

		// Token: 0x0401C46C RID: 115820
		private int? BatchCollectRangeEffectHandleId;

		// Token: 0x0401C46D RID: 115821
		[Nullable(2)]
		private string BatchCollectRangeEffectPath;

		// Token: 0x0401C46E RID: 115822
		protected float AutoDetectDistance;

		// Token: 0x0401C46F RID: 115823
		protected float AutoDetectInterval = 0.5f;

		// Token: 0x0401C470 RID: 115824
		protected List<int> DisableAutoDetectTags = new List<int>();

		// Token: 0x0401C471 RID: 115825
		protected float LastAutoDetectTimeStamp;
	}
}
