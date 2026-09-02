using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004883 RID: 18563
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemAttachTargetComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x17008289 RID: 33417
		// (get) Token: 0x060304CA RID: 197834 RVA: 0x00BC4732 File Offset: 0x00BC2932
		[Nullable(1)]
		public static Type[] Dependencies
		{
			[NullableContext(1)]
			get
			{
				return new Type[]
				{
					typeof(SceneItemActorComponent),
					typeof(CreatureDataComponent)
				};
			}
		}

		// Token: 0x060304CB RID: 197835 RVA: 0x00BC4754 File Offset: 0x00BC2954
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData createEntityData = (args != null) ? args.GetP1<CreateEntityData>() : null;
			object obj = (createEntityData != null) ? createEntityData.GetParam<SceneItemAttachTargetComponent>() : null;
			this.Config = (obj as AttachTargetComponent);
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			if (!this.IsSpecialRuleSwordRailAttachRule())
			{
				AttachTargetComponent config = this.Config;
				if (((config != null) ? config.AttachTarget : null) == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.YZH;
					string message = "[SceneItemAttachTargetComponent]附加目标配置无效，请联系对应策划检查配置";
					string item = "PbDataId:";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return true;
				}
			}
			this.AttachParam = new SceneItemDynamicAttachTargetComponent.AttachParam();
			EAttachRuleType? eattachRuleType = this.Config.PosRule;
			if (eattachRuleType != null)
			{
				switch (eattachRuleType.GetValueOrDefault())
				{
				case EAttachRuleType.Absolute:
					this.AttachParam.PosAbsolute = true;
					this.AttachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseCurrentRelation;
					goto IL_128;
				case EAttachRuleType.AlignTarget:
					this.AttachParam.PosAbsolute = false;
					this.AttachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.UseZeroRelativeTransform;
					goto IL_128;
				}
			}
			this.AttachParam.PosAbsolute = false;
			this.AttachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseInitialRelation;
			IL_128:
			eattachRuleType = this.Config.RotRule;
			if (eattachRuleType != null)
			{
				switch (eattachRuleType.GetValueOrDefault())
				{
				case EAttachRuleType.Absolute:
					this.AttachParam.RotAbsolute = true;
					this.AttachParam.RotAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseCurrentRelation;
					goto IL_1A8;
				case EAttachRuleType.AlignTarget:
					this.AttachParam.RotAbsolute = false;
					this.AttachParam.RotAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.UseZeroRelativeTransform;
					goto IL_1A8;
				}
			}
			this.AttachParam.RotAbsolute = false;
			this.AttachParam.RotAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseInitialRelation;
			IL_1A8:
			IAttachTarget attachTarget = this.Config.AttachTarget;
			EAttachType? eattachType = (attachTarget != null) ? new EAttachType?(attachTarget.Type) : null;
			if (eattachType != null)
			{
				EAttachType valueOrDefault = eattachType.GetValueOrDefault();
				if (valueOrDefault != EAttachType.Actor)
				{
					if (valueOrDefault == EAttachType.Entity)
					{
						IEntityAttachTarget entityAttachTarget = this.Config.AttachTarget as IEntityAttachTarget;
						this.TargetPbDataId = new int?(entityAttachTarget.EntityId);
						this.TargetAttachPoint = entityAttachTarget.AttachPoint;
						if (entityAttachTarget.PosOffset != null)
						{
							this.AttachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.UseZeroRelativeTransform;
							this.AttachParam.PosAttachOffset = Vector.Create((double)entityAttachTarget.PosOffset.X.GetValueOrDefault(), (double)entityAttachTarget.PosOffset.Y.GetValueOrDefault(), (double)entityAttachTarget.PosOffset.Z.GetValueOrDefault());
						}
					}
				}
				else
				{
					string[] array = (this.Config.AttachTarget as IActorAttachTarget).ActorRef.PathName.Split('.', StringSplitOptions.None);
					if (array.Length < 3)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.SceneItem;
						ELogAuthor author2 = ELogAuthor.ZYL;
						string message2 = "[SceneItemAttachTargetComponent] Invalid ActorRefConfig";
						string item2 = "PbDataId:";
						CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return false;
					}
					this.TargetActorRef = array[1] + "." + array[2];
				}
			}
			return true;
		}

		// Token: 0x060304CC RID: 197836 RVA: 0x00BC4A84 File Offset: 0x00BC2C84
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[SceneItemAttachTargetComponent] Invalid ActorComp";
				string item = "PbDataId:";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (this.IsOnMoveWithSplineEndAttachTiming())
			{
				this.MoveComp = base.Entity.GetComponent<SceneItemMoveComponent>();
				if (this.MoveComp == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.YZH;
					string message2 = "[SceneItemAttachTargetComponent] Invalid MoveComp";
					string item2 = "PbDataId:";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
			}
			if (this.IsSpecialRuleSwordRailAttachRule())
			{
				return true;
			}
			this.DynamicAttachComp = base.Entity.GetComponent<SceneItemDynamicAttachTargetComponent>();
			if (this.DynamicAttachComp == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.YZH;
				string message3 = "[SceneItemAttachTargetComponent] Invalid DynamicAttachComp";
				string item3 = "PbDataId:";
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			return true;
		}

		// Token: 0x060304CD RID: 197837 RVA: 0x00BC4BD0 File Offset: 0x00BC2DD0
		protected override void OnActivate()
		{
			if (this.IsOnMoveWithSplineEndAttachTiming())
			{
				this.RegisterSplineMoveEndEvents();
				return;
			}
			this.HandleAttachByRule();
		}

		// Token: 0x060304CE RID: 197838 RVA: 0x00BC4BE7 File Offset: 0x00BC2DE7
		protected override bool OnEnd()
		{
			if (this.IsSpecialRuleSwordRailAttached)
			{
				this.DetachBySpecialRuleSwordRail();
			}
			else if (this.DynamicAttachComp != null)
			{
				this.HandleTargetDetach();
			}
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			return true;
		}

		// Token: 0x060304CF RID: 197839 RVA: 0x00BC4C14 File Offset: 0x00BC2E14
		private bool IsOnMoveWithSplineEndAttachTiming()
		{
			AttachTargetComponent config = this.Config;
			if (config == null)
			{
				return false;
			}
			IAttachTiming attachTiming = config.AttachTiming;
			return ((attachTiming != null) ? new EAttachTimingType?(attachTiming.Type) : null).GetValueOrDefault() == EAttachTimingType.OnMoveWithSplineEnd;
		}

		// Token: 0x060304D0 RID: 197840 RVA: 0x00BC4C58 File Offset: 0x00BC2E58
		private bool IsSpecialRuleSwordRailAttachRule()
		{
			AttachTargetComponent config = this.Config;
			if (config == null || config.PosRule.GetValueOrDefault() != EAttachRuleType.SpecialRuleSwordRail)
			{
				AttachTargetComponent config2 = this.Config;
				return config2 != null && config2.RotRule.GetValueOrDefault() == EAttachRuleType.SpecialRuleSwordRail;
			}
			return true;
		}

		// Token: 0x060304D1 RID: 197841 RVA: 0x00BC4CA2 File Offset: 0x00BC2EA2
		private IOnMoveWithSplineEndAttachTiming GetOnMoveWithSplineEndAttachTiming()
		{
			if (!this.IsOnMoveWithSplineEndAttachTiming())
			{
				return null;
			}
			AttachTargetComponent config = this.Config;
			return ((config != null) ? config.AttachTiming : null) as IOnMoveWithSplineEndAttachTiming;
		}

		// Token: 0x060304D2 RID: 197842 RVA: 0x00BC4CC8 File Offset: 0x00BC2EC8
		private unsafe void RegisterSplineMoveEndEvents()
		{
			IOnMoveWithSplineEndAttachTiming onMoveWithSplineEndAttachTiming = this.GetOnMoveWithSplineEndAttachTiming();
			bool flag = (((onMoveWithSplineEndAttachTiming != null) ? new int?(onMoveWithSplineEndAttachTiming.SplineEntityId) : null) ?? 0) == 0;
			if (flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[SceneItemAttachTargetComponent] OnMoveWithSplineEnd AttachTiming SplineEntityId invalid";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "PbDataId:";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineEntityId", (onMoveWithSplineEndAttachTiming != null) ? new int?(onMoveWithSplineEndAttachTiming.SplineEntityId) : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.UpdateLastSplineMoveTaskId();
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveStarted, new Action<Entity>(this.OnSceneItemSplineMoveStarted)))
			{
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<Entity>(this, base.Entity, EEventName.OnSceneItemSplineMoveStarted, new Action<Entity>(this.OnSceneItemSplineMoveStarted));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveBroken, new Action<Entity>(this.OnSceneItemSplineMoveBroken)))
			{
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<Entity>(this, base.Entity, EEventName.OnSceneItemSplineMoveBroken, new Action<Entity>(this.OnSceneItemSplineMoveBroken));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveStopped, new Action<Entity>(this.OnSceneItemSplineMoveStopped)))
			{
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<Entity>(this, base.Entity, EEventName.OnSceneItemSplineMoveStopped, new Action<Entity>(this.OnSceneItemSplineMoveStopped));
			}
		}

		// Token: 0x060304D3 RID: 197843 RVA: 0x00BC4E80 File Offset: 0x00BC3080
		[NullableContext(1)]
		private void OnSceneItemSplineMoveStarted(Entity _)
		{
			this.UpdateLastSplineMoveTaskId();
		}

		// Token: 0x060304D4 RID: 197844 RVA: 0x00BC4E88 File Offset: 0x00BC3088
		[NullableContext(1)]
		private void OnSceneItemSplineMoveBroken(Entity _)
		{
			this.UpdateLastSplineMoveTaskId();
			this.IsSplineMoveBroken = true;
		}

		// Token: 0x060304D5 RID: 197845 RVA: 0x00BC4E98 File Offset: 0x00BC3098
		[NullableContext(1)]
		private void OnSceneItemSplineMoveStopped(Entity _)
		{
			this.UpdateLastSplineMoveTaskId();
			bool isSplineMoveBroken = this.IsSplineMoveBroken;
			this.IsSplineMoveBroken = false;
			if (isSplineMoveBroken || this.IsSpecialRuleSwordRailAttached)
			{
				return;
			}
			IOnMoveWithSplineEndAttachTiming onMoveWithSplineEndAttachTiming = this.GetOnMoveWithSplineEndAttachTiming();
			bool flag = (((onMoveWithSplineEndAttachTiming != null) ? new int?(onMoveWithSplineEndAttachTiming.SplineEntityId) : null) ?? 0) == 0;
			if (flag)
			{
				return;
			}
			int? lastSplineMoveTaskId = this.LastSplineMoveTaskId;
			int splineEntityId = onMoveWithSplineEndAttachTiming.SplineEntityId;
			if (!(lastSplineMoveTaskId.GetValueOrDefault() == splineEntityId & lastSplineMoveTaskId != null))
			{
				return;
			}
			this.HandleAttachByRule();
		}

		// Token: 0x060304D6 RID: 197846 RVA: 0x00BC4F2C File Offset: 0x00BC312C
		private void UpdateLastSplineMoveTaskId()
		{
			SceneItemMoveComponent moveComp = this.MoveComp;
			SceneItemSplineMoveTask sceneItemSplineMoveTask = (moveComp != null) ? moveComp.GetCurSplineMoveTask() : null;
			if (sceneItemSplineMoveTask != null)
			{
				this.LastSplineMoveTaskId = new int?(sceneItemSplineMoveTask.SplineEntityId);
			}
		}

		// Token: 0x060304D7 RID: 197847 RVA: 0x00BC4F60 File Offset: 0x00BC3160
		private void AttachBySpecialRuleSwordRail()
		{
			SceneItemActorComponent actorComp = this.ActorComp;
			AActor aactor = (actorComp != null) ? actorComp.Owner : null;
			if (aactor == null || !aactor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[SceneItemAttachTargetComponent] SceneItemActor invalid";
				string item = "PbDataId:";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			AActor aactor2;
			if (getCurrentEntity == null)
			{
				aactor2 = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				if (entity == null)
				{
					aactor2 = null;
				}
				else
				{
					BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
					aactor2 = ((component != null) ? component.Owner : null);
				}
			}
			AActor aactor3 = aactor2;
			if (aactor3 == null || !aactor3.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[SceneItemAttachTargetComponent] SpecialRuleSwordRail target actor invalid";
				string item2 = "PbDataId:";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.IsSpecialRuleSwordRailAttached = ControllerBase<AttachToActorController>.Instance.AttachToActor(aactor, aactor3, EDetachType.DestroyExternal, "SceneItemAttachTargetComponent.AttachBySpecialRuleSwordRail", null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true, false, true, false);
		}

		// Token: 0x060304D8 RID: 197848 RVA: 0x00BC5091 File Offset: 0x00BC3291
		private void HandleAttachByRule()
		{
			if (this.IsSpecialRuleSwordRailAttachRule())
			{
				this.AttachBySpecialRuleSwordRail();
				return;
			}
			this.HandleTargetAttach();
		}

		// Token: 0x060304D9 RID: 197849 RVA: 0x00BC50A8 File Offset: 0x00BC32A8
		private void DetachBySpecialRuleSwordRail()
		{
			SceneItemActorComponent actorComp = this.ActorComp;
			AActor aactor = (actorComp != null) ? actorComp.Owner : null;
			if (aactor == null || !aactor.IsValid())
			{
				return;
			}
			if (ControllerBase<AttachToActorController>.Instance.DetachActor(aactor, false, "SceneItemAttachTargetComponent.DetachBySpecialRuleSwordRail", EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld))
			{
				this.IsSpecialRuleSwordRailAttached = false;
			}
		}

		// Token: 0x060304DA RID: 197850 RVA: 0x00BC50F8 File Offset: 0x00BC32F8
		private void HandleTargetAttach()
		{
			AttachTargetComponent config = this.Config;
			EAttachType? eattachType;
			if (config == null)
			{
				eattachType = null;
			}
			else
			{
				IAttachTarget attachTarget = config.AttachTarget;
				eattachType = ((attachTarget != null) ? new EAttachType?(attachTarget.Type) : null);
			}
			EAttachType? eattachType2 = eattachType;
			if (eattachType2 != null)
			{
				EAttachType valueOrDefault = eattachType2.GetValueOrDefault();
				if (valueOrDefault != EAttachType.Actor)
				{
					if (valueOrDefault == EAttachType.Entity)
					{
						this.DynamicAttachComp.RegEntityTarget(this.TargetPbDataId.Value, this.TargetAttachPoint, this.AttachParam, "[SceneItemAttachTargetComponent] HandleTargetAttach");
						return;
					}
				}
				else
				{
					this.DynamicAttachComp.RegRefActorTarget(this.TargetActorRef, this.AttachParam, "[SceneItemAttachTargetComponent] HandleTargetAttach");
				}
			}
		}

		// Token: 0x060304DB RID: 197851 RVA: 0x00BC5198 File Offset: 0x00BC3398
		private void HandleTargetDetach()
		{
			AttachTargetComponent config = this.Config;
			EAttachType? eattachType;
			if (config == null)
			{
				eattachType = null;
			}
			else
			{
				IAttachTarget attachTarget = config.AttachTarget;
				eattachType = ((attachTarget != null) ? new EAttachType?(attachTarget.Type) : null);
			}
			EAttachType? eattachType2 = eattachType;
			if (eattachType2 != null)
			{
				EAttachType valueOrDefault = eattachType2.GetValueOrDefault();
				if (valueOrDefault <= EAttachType.Entity)
				{
					this.DynamicAttachComp.UnRegTarget("[SceneItemAttachTargetComponent] HandleTargetDetach");
				}
			}
		}

		// Token: 0x060304DC RID: 197852 RVA: 0x00BC5200 File Offset: 0x00BC3400
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemAttachTargetComponent sceneItemAttachTargetComponent = (SceneItemAttachTargetComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemAttachTargetComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AttachTargetComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemAttachTargetComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetPbDataId"))
			{
				this.TargetPbDataId = sceneItemAttachTargetComponent.TargetPbDataId;
			}
			if (base.CanResetComponentProperty("TargetAttachPoint"))
			{
				this.TargetAttachPoint = sceneItemAttachTargetComponent.TargetAttachPoint;
			}
			if (base.CanResetComponentProperty("TargetActorRef"))
			{
				this.TargetActorRef = sceneItemAttachTargetComponent.TargetActorRef;
			}
			if (base.CanResetComponentProperty("AttachParam"))
			{
				if (sceneItemAttachTargetComponent.AttachParam == null)
				{
					this.AttachParam = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemDynamicAttachTargetComponent.AttachParam>(this.AttachParam), "AttachParam"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DynamicAttachComp"))
			{
				if (sceneItemAttachTargetComponent.DynamicAttachComp == null)
				{
					this.DynamicAttachComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemDynamicAttachTargetComponent>(this.DynamicAttachComp), "DynamicAttachComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemAttachTargetComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (sceneItemAttachTargetComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsSplineMoveBroken"))
			{
				this.IsSplineMoveBroken = sceneItemAttachTargetComponent.IsSplineMoveBroken;
			}
			if (base.CanResetComponentProperty("IsSpecialRuleSwordRailAttached"))
			{
				this.IsSpecialRuleSwordRailAttached = sceneItemAttachTargetComponent.IsSpecialRuleSwordRailAttached;
			}
			if (base.CanResetComponentProperty("LastSplineMoveTaskId"))
			{
				this.LastSplineMoveTaskId = sceneItemAttachTargetComponent.LastSplineMoveTaskId;
			}
			return true;
		}

		// Token: 0x0401BBD8 RID: 113624
		private AttachTargetComponent Config;

		// Token: 0x0401BBD9 RID: 113625
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BBDA RID: 113626
		private int? TargetPbDataId;

		// Token: 0x0401BBDB RID: 113627
		private string TargetAttachPoint;

		// Token: 0x0401BBDC RID: 113628
		private string TargetActorRef;

		// Token: 0x0401BBDD RID: 113629
		private SceneItemDynamicAttachTargetComponent.AttachParam AttachParam;

		// Token: 0x0401BBDE RID: 113630
		private SceneItemDynamicAttachTargetComponent DynamicAttachComp;

		// Token: 0x0401BBDF RID: 113631
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401BBE0 RID: 113632
		private SceneItemMoveComponent MoveComp;

		// Token: 0x0401BBE1 RID: 113633
		private bool IsSplineMoveBroken;

		// Token: 0x0401BBE2 RID: 113634
		private bool IsSpecialRuleSwordRailAttached;

		// Token: 0x0401BBE3 RID: 113635
		private int? LastSplineMoveTaskId;
	}
}
