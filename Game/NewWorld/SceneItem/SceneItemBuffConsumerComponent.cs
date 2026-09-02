using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Controller;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047EB RID: 18411
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemBuffConsumerComponent : EntityComponent
	{
		// Token: 0x0602FC45 RID: 195653 RVA: 0x00B740C4 File Offset: 0x00B722C4
		protected override bool OnInitData(IEntityArgs args = null)
		{
			BuffConsumerComponent buffConsumerComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemBuffConsumerComponent>() as BuffConsumerComponent;
			this.BuffId = buffConsumerComponent.BuffId;
			long? num = buffConsumerComponent.BulletId;
			if (num != null && num.GetValueOrDefault() != 0L)
			{
				this.BulletId = buffConsumerComponent.BulletId.ToString();
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			EntityComponentPb entityComponentPb = (component != null) ? component.ComponentDataMap.GetValueOrDefault("Proto_BuffConsumerComponentPb") : null;
			long? num2;
			if (entityComponentPb == null)
			{
				num2 = null;
			}
			else
			{
				BuffConsumerComponentPb buffConsumerComponentPb = entityComponentPb.BuffConsumerComponentPb;
				num2 = ((buffConsumerComponentPb != null) ? new long?(buffConsumerComponentPb.ContextId) : null);
			}
			num = num2;
			this.ContextMessageId = new long?(num.GetValueOrDefault());
			return true;
		}

		// Token: 0x0602FC46 RID: 195654 RVA: 0x00B74184 File Offset: 0x00B72384
		protected unsafe override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.CJH, "[SceneItemBuffConsumerComponent] 组件初始化失败 Actor Component Undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.CommonTagComp = base.Entity.GetComponent<LevelTagComponent>();
			if (this.CommonTagComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "[SceneItemBuffConsumerComponent] 组件初始化失败 实体缺少LevelTagComponent";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			this.StateComp = base.Entity.GetComponent<SceneItemStateComponent>();
			if (this.StateComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneGameplay;
				ELogAuthor author2 = ELogAuthor.CJH;
				string message2 = "[SceneItemBuffConsumerComponent] 组件初始化失败 实体缺少SceneItemStateComponent";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return false;
			}
			this.RangeComp = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			if (this.RangeComp == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.SceneGameplay;
				ELogAuthor author3 = ELogAuthor.CJH;
				string message3 = "[SceneItemBuffConsumerComponent] 组件初始化失败 实体缺少RangeComponent";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				return false;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
				if (!(id.GetValueOrDefault() == worldOwner & id != null))
				{
					return true;
				}
			}
			this.CreatureDataId = this.ActorComp.CreatureData.GetCreatureDataId();
			this.CommonTagComp.AddTag(new int?(SceneItemBuffConsumerComponent.HIT_CONDITION_TAGID));
			this.HitComp = base.Entity.GetComponent<SceneItemHitComponent>();
			this.HitComp.RegisterComponent(this, null);
			this.RangeComp.AddOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerInOutRange));
			return true;
		}

		// Token: 0x0602FC47 RID: 195655 RVA: 0x00B744B3 File Offset: 0x00B726B3
		protected override bool OnEnd()
		{
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent rangeComp = this.RangeComp;
			if (rangeComp != null)
			{
				rangeComp.RemoveOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerInOutRange));
			}
			if (this.BulletTimeOutTimerHandle != null && TimerSystem.Instance.Remove(this.BulletTimeOutTimerHandle))
			{
				this.OnBulletTimeOut();
			}
			return true;
		}

		// Token: 0x0602FC48 RID: 195656 RVA: 0x00B744F3 File Offset: 0x00B726F3
		private void OnPlayerInOutRange(bool isEnter)
		{
			if (isEnter && this.CheckCanConsume())
			{
				this.IsBusyConsuming = true;
				ControllerBase<SceneItemBuffController>.Instance.BuffOperate(base.Entity.Id, BuffOperateType.RemoveBuff, new Action<BuffOperateType, bool>(this.OnBuffOperateCallBack));
			}
		}

		// Token: 0x0602FC49 RID: 195657 RVA: 0x00B7452C File Offset: 0x00B7272C
		private bool CheckCanConsume()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
				if (!(id.GetValueOrDefault() == worldOwner & id != null))
				{
					return false;
				}
			}
			return !this.IsBusyConsuming && this.StateComp.IsInState(SceneItemStateComponent.ESceneItemState.Normal) && !ModelBase<SceneTeamModel>.Instance.IsPhantomTeam && this.CheckPlayerHasBuff();
		}

		// Token: 0x0602FC4A RID: 195658 RVA: 0x00B745A4 File Offset: 0x00B727A4
		private bool CheckPlayerHasBuff()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return false;
			}
			Entity entity = baseCharacter.CharacterActorComponent.Entity;
			CharacterBuffComponent characterBuffComponent = entity.CheckGetComponent<CharacterBuffComponent>();
			if (characterBuffComponent == null)
			{
				return false;
			}
			bool flag = characterBuffComponent.GetBuffTotalStackById(this.BuffId, false) > 0;
			RoleBuffComponent roleBuffComponent = entity.CheckGetComponent<RoleBuffComponent>();
			if (roleBuffComponent != null)
			{
				bool flag2;
				if (!flag)
				{
					PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
					flag2 = (((formationBuffComp != null) ? formationBuffComp.GetBuffTotalStackById(this.BuffId, false) : 0) > 0);
				}
				else
				{
					flag2 = true;
				}
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x0602FC4B RID: 195659 RVA: 0x00B74616 File Offset: 0x00B72816
		private void OnBuffOperateCallBack(BuffOperateType type, bool isSuccess)
		{
			if (type == BuffOperateType.RemoveBuff && isSuccess)
			{
				this.PlayPerformance();
				return;
			}
			this.IsBusyConsuming = false;
		}

		// Token: 0x0602FC4C RID: 195660 RVA: 0x00B7462E File Offset: 0x00B7282E
		private void PlayPerformance()
		{
			if (!string.IsNullOrEmpty(this.BulletId))
			{
				this.CreateBullet();
				return;
			}
			this.OnPerformanceComplete();
		}

		// Token: 0x0602FC4D RID: 195661 RVA: 0x00B7464C File Offset: 0x00B7284C
		private void CreateBullet()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			Entity entity = characterActorComponent.Entity;
			ModelBase<BulletModel>.Instance.SetEntityIdByCustomKey(entity.Id, "HeiShiSuo", base.Entity.Id);
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(Global.BaseCharacter, this.BulletId, new FTransformDouble?(characterActorComponent.ActorTransform), new BulletController.BulletCreateParams(), this.ContextMessageId, global::EBulletCreateSource.Others);
			Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnHit));
			this.BulletTimeOutTimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnBulletTimeOut), 5000f, null, null, true, 1f);
		}

		// Token: 0x0602FC4E RID: 195662 RVA: 0x00B74704 File Offset: 0x00B72904
		[NullableContext(1)]
		private void OnHit(global::HitInformation hitData)
		{
			if (hitData.ReBulletData.Base.HitConditionTagId != SceneItemBuffConsumerComponent.HIT_CONDITION_TAGID)
			{
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(hitData.BulletEntityId);
			if (entity != null && entity.Valid)
			{
				ControllerBase<BulletController>.Instance.DestroyBullet(hitData.BulletEntityId, false, EBulletDestroyReason.Normal, false);
			}
			if (this.BulletTimeOutTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.BulletTimeOutTimerHandle);
				this.BulletTimeOutTimerHandle = null;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnHit));
			this.OnPerformanceComplete();
		}

		// Token: 0x0602FC4F RID: 195663 RVA: 0x00B7479B File Offset: 0x00B7299B
		private void OnBulletTimeOut(float delta)
		{
			this.OnBulletTimeOut();
		}

		// Token: 0x0602FC50 RID: 195664 RVA: 0x00B747A4 File Offset: 0x00B729A4
		private void OnBulletTimeOut()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnHit)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation>(this, EEventName.OnSceneItemHitByHitData, new Action<global::HitInformation>(this.OnHit));
			}
			this.BulletTimeOutTimerHandle = null;
			this.OnPerformanceComplete();
		}

		// Token: 0x0602FC51 RID: 195665 RVA: 0x00B747F9 File Offset: 0x00B729F9
		private void OnPerformanceComplete()
		{
			ControllerBase<LevelGamePlayController>.Instance.EntityBuffProducerRequest(this.CreatureDataId, delegate(EntityBuffProducerResponse response, Net.CallbackStatus _)
			{
				this.IsBusyConsuming = false;
			});
		}

		// Token: 0x0602FC52 RID: 195666 RVA: 0x00B74818 File Offset: 0x00B72A18
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemBuffConsumerComponent sceneItemBuffConsumerComponent = (SceneItemBuffConsumerComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemBuffConsumerComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CommonTagComp"))
			{
				if (sceneItemBuffConsumerComponent.CommonTagComp == null)
				{
					this.CommonTagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.CommonTagComp), "CommonTagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (sceneItemBuffConsumerComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("HitComp"))
			{
				if (sceneItemBuffConsumerComponent.HitComp == null)
				{
					this.HitComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemHitComponent>(this.HitComp), "HitComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (sceneItemBuffConsumerComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataId"))
			{
				this.CreatureDataId = sceneItemBuffConsumerComponent.CreatureDataId;
			}
			if (base.CanResetComponentProperty("BulletId"))
			{
				this.BulletId = sceneItemBuffConsumerComponent.BulletId;
			}
			if (base.CanResetComponentProperty("BuffId"))
			{
				this.BuffId = sceneItemBuffConsumerComponent.BuffId;
			}
			if (base.CanResetComponentProperty("BulletTimeOutTimerHandle"))
			{
				if (sceneItemBuffConsumerComponent.BulletTimeOutTimerHandle == null)
				{
					this.BulletTimeOutTimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.BulletTimeOutTimerHandle), "BulletTimeOutTimerHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ContextMessageId"))
			{
				this.ContextMessageId = sceneItemBuffConsumerComponent.ContextMessageId;
			}
			if (base.CanResetComponentProperty("IsBusyConsuming"))
			{
				this.IsBusyConsuming = sceneItemBuffConsumerComponent.IsBusyConsuming;
			}
			return true;
		}

		// Token: 0x0401B5FA RID: 112122
		[Nullable(1)]
		private const string BLACKBOARD_KEY = "HeiShiSuo";

		// Token: 0x0401B5FB RID: 112123
		private static readonly int HIT_CONDITION_TAGID = GameplayTagDefine.EGameplayTagId["关卡.黑石锁.功能.命中判定"];

		// Token: 0x0401B5FC RID: 112124
		private const int MAX_BULLET_HIT_TIME = 5000;

		// Token: 0x0401B5FD RID: 112125
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B5FE RID: 112126
		private LevelTagComponent CommonTagComp;

		// Token: 0x0401B5FF RID: 112127
		private SceneItemStateComponent StateComp;

		// Token: 0x0401B600 RID: 112128
		private SceneItemHitComponent HitComp;

		// Token: 0x0401B601 RID: 112129
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComp;

		// Token: 0x0401B602 RID: 112130
		private long CreatureDataId;

		// Token: 0x0401B603 RID: 112131
		[Nullable(1)]
		private string BulletId = "";

		// Token: 0x0401B604 RID: 112132
		private long BuffId;

		// Token: 0x0401B605 RID: 112133
		private TimerHandle BulletTimeOutTimerHandle;

		// Token: 0x0401B606 RID: 112134
		private long? ContextMessageId;

		// Token: 0x0401B607 RID: 112135
		private bool IsBusyConsuming;
	}
}
