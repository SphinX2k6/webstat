using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Debug;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

// Token: 0x02003468 RID: 13416
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AoiController : ControllerBase<AoiController>
{
	// Token: 0x0601C393 RID: 115603 RVA: 0x0086A7EC File Offset: 0x008689EC
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<LeaveAoiNotify>(ENotifyMessageId.LeaveAoiNotify, new Action<LeaveAoiNotify, Net.CallbackStatus>(this.LeaveAoiNotify));
		Singleton<Net>.Instance.Register<RemoveEntityAoiNotify>(ENotifyMessageId.RemoveEntityAoiNotify, new Action<RemoveEntityAoiNotify, Net.CallbackStatus>(this.RemoveEntityAoiNotify));
		Singleton<Net>.Instance.Register<PlayerAoiRangeNotify>(ENotifyMessageId.PlayerAoiRangeNotify, new Action<PlayerAoiRangeNotify, Net.CallbackStatus>(this.PlayerAoiRangeNotify));
		Singleton<Net>.Instance.Register<EntityAddNotify>(ENotifyMessageId.EntityAddNotify, new Action<EntityAddNotify, Net.CallbackStatus>(this.EntityAddNotify));
		Singleton<Net>.Instance.Register<EntityRemoveNotify>(ENotifyMessageId.EntityRemoveNotify, new Action<EntityRemoveNotify, Net.CallbackStatus>(this.EntityRemoveNotify));
		Singleton<Net>.Instance.Register<GmVoxelInfoNotify>(ENotifyMessageId.GmVoxelInfoNotify, new Action<GmVoxelInfoNotify, Net.CallbackStatus>(this.GmVoxelInfoNotify));
		Singleton<Net>.Instance.Register<GmIsOverlapNotify>(ENotifyMessageId.GmIsOverlapNotify, new Action<GmIsOverlapNotify, Net.CallbackStatus>(this.VoxelBoxNotify));
		return true;
	}

	// Token: 0x0601C394 RID: 115604 RVA: 0x0086A8C0 File Offset: 0x00868AC0
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LeaveAoiNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RemoveEntityAoiNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerAoiRangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GmVoxelInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GmIsOverlapNotify);
		return true;
	}

	// Token: 0x0601C395 RID: 115605 RVA: 0x0086A940 File Offset: 0x00868B40
	private void LeaveAoiNotify(LeaveAoiNotify data, Net.CallbackStatus status)
	{
		foreach (long creatureDataId in data.EntityIds)
		{
			ControllerBase<CreatureController>.Instance.RemoveEntity(creatureDataId, "LeaveAoiNotify", ERemoveEntityType.RemoveTypeForce);
		}
	}

	// Token: 0x0601C396 RID: 115606 RVA: 0x0086A998 File Offset: 0x00868B98
	private void RemoveEntityAoiNotify(RemoveEntityAoiNotify data, Net.CallbackStatus status)
	{
		foreach (EntityRemoveInfo entityRemoveInfo in data.RemoveInfos)
		{
			long entityId = entityRemoveInfo.EntityId;
			ControllerBase<CreatureController>.Instance.RemoveEntity(entityId, "RemoveEntityAoiNotify", entityRemoveInfo.Type);
		}
	}

	// Token: 0x0601C397 RID: 115607 RVA: 0x0086A9FC File Offset: 0x00868BFC
	private void PlayerAoiRangeNotify(PlayerAoiRangeNotify data, Net.CallbackStatus status)
	{
		ModelBase<AoiModel>.Instance.MinCoordinate = new FVector?(new FVector((float)data.MinX, (float)data.MinY));
		ModelBase<AoiModel>.Instance.MaxCoordinate = new FVector?(new FVector((float)data.MaxX, (float)data.MaxY));
	}

	// Token: 0x0601C398 RID: 115608 RVA: 0x0086AA4D File Offset: 0x00868C4D
	[NullableContext(1)]
	private void EntityAddNotify(EntityAddNotify data, [Nullable(2)] Net.CallbackStatus callbackStatus)
	{
		ControllerBase<AoiController>.Instance.AddEntityPb(data.EntityPbs, data.IsAdd, callbackStatus);
	}

	// Token: 0x0601C399 RID: 115609 RVA: 0x0086AA68 File Offset: 0x00868C68
	[NullableContext(1)]
	private void AddEntityPb(IList<EntityPb> entities, bool add, Net.CallbackStatus callbackStatus)
	{
		int num = 0;
		if (callbackStatus.CallbackCount == 0)
		{
			callbackStatus.IsFinished = false;
		}
		else
		{
			num = (int)callbackStatus.UserData;
		}
		if (num >= entities.Count)
		{
			callbackStatus.IsFinished = true;
			return;
		}
		EntityPb entityPb = entities[num];
		callbackStatus.UserData = num + 1;
		if (entityPb == null)
		{
			callbackStatus.IsFinished = true;
			return;
		}
		long id = entityPb.Id;
		ControllerBase<CreatureController>.Instance.CheckDelayRemove(id, entityPb.ConfigType, entityPb.ConfigId);
		ControllerBase<CreatureController>.Instance.CheckPendingRemove(id, entityPb.ConfigType, entityPb.ConfigId);
		if (ModelBase<CreatureModel>.Instance.RemoveCreaturePendingSet.Contains(id))
		{
			ModelBase<CreatureModel>.Instance.RemoveRemoveCreaturePending(id);
			return;
		}
		if (ModelBase<CreatureModel>.Instance.RemovePreCreature(id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[AoiController.AddEntityPb]更新先行创建实体的信息。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<CreatureModel>.Instance.GetEntity(id).Entity.GetComponent<CreatureDataComponent>().SetPbDataByProtocol(entityPb);
			return;
		}
		EntityHandle entityHandle = ControllerBase<CreatureController>.Instance.CreateEntity(entityPb, "AOI");
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.MapDone)
		{
			GameModeModel instance2 = ModelBase<GameModeModel>.Instance;
			ELoadingPhase loadingPhase = instance2.LoadingPhase;
			if (instance2.PreAwakeEntityDuringLoad && loadingPhase >= ELoadingPhase.CheckVoxelStreamingEnd && loadingPhase <= ELoadingPhase.CheckStreamingStart && ModelBase<CreatureModel>.Instance.IsEntityNeedPreAwake(entityHandle))
			{
				ControllerBase<CreatureController>.Instance.LoadEntityAsync(entityHandle, null, true);
			}
			return;
		}
		ControllerBase<CreatureController>.Instance.LoadEntityAsync(entityHandle, null, false);
	}

	// Token: 0x0601C39A RID: 115610 RVA: 0x0086ABEC File Offset: 0x00868DEC
	private void EntityRemoveNotify(EntityRemoveNotify data, Net.CallbackStatus status)
	{
		foreach (EntityRemoveInfo entityRemoveInfo in data.RemoveInfos)
		{
			long entityId = entityRemoveInfo.EntityId;
			ControllerBase<CreatureController>.Instance.RemoveEntity(entityId, "EntityRemoveNotify", entityRemoveInfo.Type);
		}
	}

	// Token: 0x0601C39B RID: 115611 RVA: 0x0086AC50 File Offset: 0x00868E50
	[NullableContext(1)]
	private void DrawDebugVoxel(VoxelSpan span, float cellSize, int interval, bool isOverlap = false)
	{
		double num = (double)cellSize * 0.5;
		FVectorDouble center = new FVectorDouble((double)span.X + num, (double)span.Y + num, (double)(span.Smax + span.Smin) * 0.5);
		FVectorDouble extent = new FVectorDouble(num, num, (double)(span.Smax - span.Smin) * 0.5);
		FRotator rotation = new FRotator(0f, 0f, 0f);
		FLinearColor lineColor = isOverlap ? new FLinearColor(1f, 0f, 0f, 1f) : new FLinearColor(0f, 1f, 0f, 1f);
		int num2 = 1;
		int num3 = interval / 1000;
		UKismetSystemLibrary.D_DrawDebugBox(GlobalData.World, center, extent, lineColor, rotation, (float)num3, (float)num2);
	}

	// Token: 0x0601C39C RID: 115612 RVA: 0x0086AD30 File Offset: 0x00868F30
	public void StopDrawDebugVoxel()
	{
		if (this.BoxDurationTimer != null)
		{
			if (TimerSystem.Instance.Has(this.BoxDurationTimer))
			{
				TimerSystem.Instance.Remove(this.BoxDurationTimer);
			}
			this.BoxDurationTimer = null;
		}
		if (this.VoxelDurationTimer != null)
		{
			if (TimerSystem.Instance.Has(this.VoxelDurationTimer))
			{
				TimerSystem.Instance.Remove(this.VoxelDurationTimer);
			}
			this.VoxelDurationTimer = null;
		}
	}

	// Token: 0x0601C39D RID: 115613 RVA: 0x0086ADA1 File Offset: 0x00868FA1
	private void VoxelBoxTimerCallback(float delta)
	{
		if (this.currentBox != null)
		{
			this.DrawDebugVoxel(this.currentBox, this.currentBoxCellSize, this.currentBoxInterval, this.currentBoxIsOverlap);
		}
	}

	// Token: 0x0601C39E RID: 115614 RVA: 0x0086ADCC File Offset: 0x00868FCC
	private void VoxelBoxNotify(GmIsOverlapNotify data, Net.CallbackStatus status)
	{
		int num = 2000;
		this.currentBox = data.Box;
		this.currentBoxCellSize = data.CellSize;
		this.currentBoxInterval = num;
		this.currentBoxIsOverlap = data.IsOverlap;
		TimerHandle timerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.VoxelBoxTimerCallback), (float)num, 1f, null, null, true);
		if (timerHandle != null)
		{
			if (this.BoxDurationTimer != null && TimerSystem.Instance.Has(this.BoxDurationTimer))
			{
				TimerSystem.Instance.Remove(this.BoxDurationTimer);
			}
			this.BoxDurationTimer = timerHandle;
		}
	}

	// Token: 0x0601C39F RID: 115615 RVA: 0x0086AE60 File Offset: 0x00869060
	private void GmVoxelTimerCallback(float delta)
	{
		if (this.currentSpans != null)
		{
			foreach (VoxelSpan span in this.currentSpans)
			{
				this.DrawDebugVoxel(span, this.currentSpansCellSize, this.currentSpansInterval, false);
			}
		}
	}

	// Token: 0x0601C3A0 RID: 115616 RVA: 0x0086AEC4 File Offset: 0x008690C4
	private void GmVoxelInfoNotify(GmVoxelInfoNotify data, Net.CallbackStatus status)
	{
		int num = 2000;
		this.currentSpans = data.Spans;
		this.currentSpansCellSize = data.CellSize;
		this.currentSpansInterval = num;
		TimerHandle timerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.GmVoxelTimerCallback), (float)num, 1f, null, null, true);
		if (timerHandle != null)
		{
			if (this.VoxelDurationTimer != null && TimerSystem.Instance.Has(this.VoxelDurationTimer))
			{
				TimerSystem.Instance.Remove(this.VoxelDurationTimer);
			}
			this.VoxelDurationTimer = timerHandle;
		}
	}

	// Token: 0x0601C3A1 RID: 115617 RVA: 0x0086AF4C File Offset: 0x0086914C
	[NullableContext(1)]
	public void AddMonsterSizeTag(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		int? num;
		if (component == null)
		{
			num = null;
		}
		else
		{
			MonsterComponent monsterComponent = component.GetMonsterComponent();
			num = ((monsterComponent != null) ? new int?(monsterComponent.FightConfigId) : null);
		}
		int? num2 = num;
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		if (num2 != null)
		{
			int? num3 = num2;
			int num4 = 0;
			if (!(num3.GetValueOrDefault() == num4 & num3 != null) && (component2 != null && component2.Valid))
			{
				MonsterBattleConf? config = ConfigMonsterBattleConfById.GetConfig(num2.Value, true);
				if (config == null)
				{
					return;
				}
				MonsterSizeId? config2 = ConfigMonsterSizeIdById.GetConfig(config.Value.MonsterSizeId, true);
				if (config2 == null)
				{
					return;
				}
				if (config2.Value.MonsterSizeTagLength > 0)
				{
					foreach (string tagName in config2.Value.MonsterSizeTagIter())
					{
						component2.AddTag(new int?(GameplayTagUtils.GetTagIdByName(tagName)));
					}
				}
				return;
			}
		}
	}

	// Token: 0x0400E345 RID: 58181
	private TimerHandle VoxelDurationTimer;

	// Token: 0x0400E346 RID: 58182
	private TimerHandle BoxDurationTimer;

	// Token: 0x0400E347 RID: 58183
	private const int MILLIONSECOND_PER_SECOND = 1000;

	// Token: 0x0400E348 RID: 58184
	private VoxelSpan currentBox;

	// Token: 0x0400E349 RID: 58185
	private float currentBoxCellSize;

	// Token: 0x0400E34A RID: 58186
	private int currentBoxInterval;

	// Token: 0x0400E34B RID: 58187
	private bool currentBoxIsOverlap;

	// Token: 0x0400E34C RID: 58188
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IList<VoxelSpan> currentSpans;

	// Token: 0x0400E34D RID: 58189
	private float currentSpansCellSize;

	// Token: 0x0400E34E RID: 58190
	private int currentSpansInterval;
}
