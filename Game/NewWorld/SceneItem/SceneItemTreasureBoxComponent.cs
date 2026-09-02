using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047DC RID: 18396
	public class SceneItemTreasureBoxComponent : EntityComponent
	{
		// Token: 0x0602FB83 RID: 195459 RVA: 0x00B6C9EC File Offset: 0x00B6ABEC
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			TreasureBoxComponent treasureBoxComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemTreasureBoxComponent>() as TreasureBoxComponent;
			int? num = (treasureBoxComponent != null) ? new int?(treasureBoxComponent.TypeId) : null;
			this.TreasureBoxType = ((num != null) ? new SceneItemTreasureBoxComponent.ETreasureBoxType?((SceneItemTreasureBoxComponent.ETreasureBoxType)num.GetValueOrDefault()) : null);
			return true;
		}

		// Token: 0x0602FB84 RID: 195460 RVA: 0x00B6CA4C File Offset: 0x00B6AC4C
		protected unsafe override bool OnStart()
		{
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			BaseInfoComponent baseInfoComponent = (component != null) ? component.GetBaseInfo() : null;
			if (baseInfoComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[SceneItemTreasureBoxComponent.OnStart] 宝箱组件初始化失败,没有基础信息配置(baseInfo)";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureGenID:", (component != null) ? new long?(component.GetOwnerId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId:", (component != null) ? new int?(component.GetPbDataId()) : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			this.EntityOnlineType = new EOnlineInteractType?(baseInfoComponent.OnlineInteractType);
			return true;
		}

		// Token: 0x0602FB85 RID: 195461 RVA: 0x00B6CB1C File Offset: 0x00B6AD1C
		protected override void OnActivate()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Temp;
				ELogAuthor author = ELogAuthor.CH;
				string message = "SceneItemTreasureBoxComponent.OnActivate: 重复添加事件";
				string item = "PbDataId";
				CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (component != null) ? new int?(component.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			if (this.TreasureBoxType.GetValueOrDefault() == SceneItemTreasureBoxComponent.ETreasureBoxType.Phantom)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.HandleLockPropChange));
				Singleton<EventSystem>.Instance.AddWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.HandlePreUpdateState));
			}
			this.CurPhantomPerformTag = null;
			if (!base.Entity.CheckGetComponent<SceneItemStateComponent>().IsInState(SceneItemStateComponent.ESceneItemState.Born))
			{
				this.HandleUpdateState();
			}
		}

		// Token: 0x0602FB86 RID: 195462 RVA: 0x00B6CC38 File Offset: 0x00B6AE38
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			if (this.TreasureBoxType.GetValueOrDefault() == SceneItemTreasureBoxComponent.ETreasureBoxType.Phantom)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.HandleLockPropChange));
				Singleton<EventSystem>.Instance.RemoveWithTarget<int>(base.Entity, EEventName.OnSceneItemStatePreChange, new Action<int>(this.HandlePreUpdateState));
			}
			return true;
		}

		// Token: 0x0602FB87 RID: 195463 RVA: 0x00B6CCBC File Offset: 0x00B6AEBC
		private void UpdatePhantomBoxPerform()
		{
			SceneItemStateComponent sceneItemStateComponent = base.Entity.CheckGetComponent<SceneItemStateComponent>();
			LevelTagComponent levelTagComponent = base.Entity.CheckGetComponent<LevelTagComponent>();
			int? num = null;
			int? num2 = null;
			SceneItemStateComponent.ESceneItemState state = sceneItemStateComponent.State;
			if (state != SceneItemStateComponent.ESceneItemState.Normal)
			{
				if (state == SceneItemStateComponent.ESceneItemState.Active)
				{
					num2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.解锁"]);
					num = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.开启"]);
				}
			}
			else if (base.Entity.CheckGetComponent<SceneItemPropertyComponent>().IsLocked)
			{
				num2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.解锁"]);
				num = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.封锁"]);
			}
			else
			{
				num2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.封锁"]);
				num = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.幻象宝箱.解锁"]);
			}
			if (num != null)
			{
				int? num3 = this.CurPhantomPerformTag;
				int? num4 = num;
				if (num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null))
				{
					return;
				}
				LevelTagComponent levelTagComponent2 = levelTagComponent;
				long notifyLock = levelTagComponent2.NotifyLock;
				levelTagComponent2.NotifyLock = notifyLock + 1L;
				if (num2 != null)
				{
					num4 = this.CurPhantomPerformTag;
					num3 = num2;
					if (num4.GetValueOrDefault() == num3.GetValueOrDefault() & num4 != null == (num3 != null))
					{
						levelTagComponent.RemoveTag(num2);
					}
				}
				this.CurPhantomPerformTag = num;
				levelTagComponent.AddTag(num);
				LevelTagComponent levelTagComponent3 = levelTagComponent;
				notifyLock = levelTagComponent3.NotifyLock;
				levelTagComponent3.NotifyLock = notifyLock - 1L;
			}
		}

		// Token: 0x0602FB88 RID: 195464 RVA: 0x00B6CE4B File Offset: 0x00B6B04B
		private void OnSceneItemStateChange(int stateId, bool isReady)
		{
			this.HandleUpdateState();
		}

		// Token: 0x0602FB89 RID: 195465 RVA: 0x00B6CE53 File Offset: 0x00B6B053
		private void HandleUpdateState()
		{
			this.UpdatePhantomBoxPerform();
			if (base.Entity.CheckGetComponent<SceneItemStateComponent>().IsInState(SceneItemStateComponent.ESceneItemState.Active))
			{
				this.DeathProcess();
			}
		}

		// Token: 0x0602FB8A RID: 195466 RVA: 0x00B6CE74 File Offset: 0x00B6B074
		private void HandlePreUpdateState(int stateId)
		{
			this.UpdatePhantomBoxPerform();
		}

		// Token: 0x0602FB8B RID: 195467 RVA: 0x00B6CE7C File Offset: 0x00B6B07C
		private void HandleLockPropChange(bool lockValue)
		{
			this.UpdatePhantomBoxPerform();
		}

		// Token: 0x0602FB8C RID: 195468 RVA: 0x00B6CE84 File Offset: 0x00B6B084
		private void DeathProcess()
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			if (!(id.GetValueOrDefault() == worldOwner & id != null))
			{
				return;
			}
			if (!ControllerBase<LevelGamePlayController>.Instance.MultiplayerLimitTypeCheck(this.EntityOnlineType.Value, true))
			{
				return;
			}
			ControllerBase<LevelGamePlayController>.Instance.GetRewardTreasureBoxRequest(base.Entity.Id);
		}

		// Token: 0x0602FB8D RID: 195469 RVA: 0x00B6CEEC File Offset: 0x00B6B0EC
		public void CloseAllCollisions()
		{
			SceneItemActorComponent component = base.Entity.GetComponent<SceneItemActorComponent>();
			SceneItemTreasureBoxComponent.CloseCollisionsByParentActor(component.Owner);
			TArray<AActor> sceneInteractionAllActorsInLevel = SceneInteractionManager.Get().GetSceneInteractionAllActorsInLevel(component.GetSceneInteractionLevelHandleId());
			if (sceneInteractionAllActorsInLevel != null)
			{
				int i = 0;
				int num = sceneInteractionAllActorsInLevel.Num();
				while (i < num)
				{
					SceneItemTreasureBoxComponent.CloseCollisionsByParentActor(sceneInteractionAllActorsInLevel.Get(i));
					i++;
				}
			}
		}

		// Token: 0x0602FB8E RID: 195470 RVA: 0x00B6CF44 File Offset: 0x00B6B144
		[NullableContext(1)]
		private static void CloseCollisionsByParentActor(AActor parentActor)
		{
			TArray<UActorComponent> tarray = parentActor.K2_GetComponentsByClass(UPrimitiveComponent.StaticClass());
			if (tarray != null)
			{
				int i = 0;
				int num = tarray.Num();
				while (i < num)
				{
					UPrimitiveComponent uprimitiveComponent = tarray.Get(i) as UPrimitiveComponent;
					uprimitiveComponent.CanCharacterStepUpOn = ECanBeCharacterBase.ECB_No;
					uprimitiveComponent.SetCollisionResponseToAllChannels(ECollisionResponse.ECR_Ignore);
					uprimitiveComponent.SetCollisionResponseToChannel(KuroCollisionChannel.Pawn, ECollisionResponse.ECR_Block);
					uprimitiveComponent.SetCollisionResponseToChannel(KuroCollisionChannel.PawnPlayer, ECollisionResponse.ECR_Block);
					uprimitiveComponent.SetCollisionResponseToChannel(KuroCollisionChannel.PawnMonster, ECollisionResponse.ECR_Block);
					i++;
				}
			}
		}

		// Token: 0x0602FB8F RID: 195471 RVA: 0x00B6CFBC File Offset: 0x00B6B1BC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemTreasureBoxComponent sceneItemTreasureBoxComponent = (SceneItemTreasureBoxComponent)componentTemplate;
			if (base.CanResetComponentProperty("EntityOnlineType"))
			{
				this.EntityOnlineType = sceneItemTreasureBoxComponent.EntityOnlineType;
			}
			if (base.CanResetComponentProperty("TreasureBoxType"))
			{
				this.TreasureBoxType = sceneItemTreasureBoxComponent.TreasureBoxType;
			}
			if (base.CanResetComponentProperty("CurPhantomPerformTag"))
			{
				this.CurPhantomPerformTag = sceneItemTreasureBoxComponent.CurPhantomPerformTag;
			}
			return true;
		}

		// Token: 0x0401B57C RID: 111996
		private EOnlineInteractType? EntityOnlineType;

		// Token: 0x0401B57D RID: 111997
		private SceneItemTreasureBoxComponent.ETreasureBoxType? TreasureBoxType;

		// Token: 0x0401B57E RID: 111998
		private int? CurPhantomPerformTag;

		// Token: 0x0200A8B2 RID: 43186
		private enum ETreasureBoxType
		{
			// Token: 0x0403454E RID: 214350
			Common = 1,
			// Token: 0x0403454F RID: 214351
			Phantom,
			// Token: 0x04034550 RID: 214352
			LevelPlayRefresh
		}
	}
}
