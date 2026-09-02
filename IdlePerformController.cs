using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;

// Token: 0x02001FD1 RID: 8145
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
[TickController(0)]
public class IdlePerformController : ControllerBase<IdlePerformController>
{
	// Token: 0x0600F5DF RID: 62943 RVA: 0x00435460 File Offset: 0x00433660
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return base.OnInit();
	}

	// Token: 0x0600F5E0 RID: 62944 RVA: 0x00435484 File Offset: 0x00433684
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		this.UnbindPlayerEvents(this.CurrentPlayerHandle);
		this.CurrentPlayerHandle = null;
		return true;
	}

	// Token: 0x0600F5E1 RID: 62945 RVA: 0x004354B8 File Offset: 0x004336B8
	protected override void OnTick(float delta)
	{
		EntityHandle currentPlayerHandle = this.CurrentPlayerHandle;
		if (currentPlayerHandle == null || !currentPlayerHandle.Valid)
		{
			return;
		}
		CharacterActorComponent component = currentPlayerHandle.Entity.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		ModelBase<IdlePerformModel>.Instance.OnTick(delta);
		if (component.InputDirectProxy.SizeSquared2D() > 1E-08)
		{
			ModelBase<IdlePerformModel>.Instance.ResetIdleTime();
		}
	}

	// Token: 0x0600F5E2 RID: 62946 RVA: 0x00435528 File Offset: 0x00433728
	public void ClearIdle()
	{
		Singleton<Log>.Instance.Info(ELogModule.Controller, ELogAuthor.ZJL, "[IdlePerform] 外部主动清空闲置时长", default(ReadOnlySpan<ValueTuple<string, object>>));
		IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ResetIdleTime();
	}

	// Token: 0x0600F5E3 RID: 62947 RVA: 0x00435564 File Offset: 0x00433764
	[NullableContext(2)]
	private void UnbindPlayerEvents(EntityHandle handle)
	{
		if (handle == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		WorldEntity entity = handle.Entity;
		if (entity == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, HitContext>(entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
		Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharMoveState, global::ECharMoveState>(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnUnifiedMoveStateChanged));
	}

	// Token: 0x0600F5E4 RID: 62948 RVA: 0x004355F0 File Offset: 0x004337F0
	private void BindPlayerEvents(EntityHandle handle)
	{
		WorldEntity entity = handle.Entity;
		Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
		Singleton<EventSystem>.Instance.AddWithTarget<global::ECharMoveState, global::ECharMoveState>(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnUnifiedMoveStateChanged));
	}

	// Token: 0x0600F5E5 RID: 62949 RVA: 0x00435674 File Offset: 0x00433874
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		this.UnbindPlayerEvents(this.CurrentPlayerHandle);
		this.CurrentPlayerHandle = null;
		IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
		if (instance != null)
		{
			instance.ResetIdleTime();
		}
		if (newEntity == null || !newEntity.Valid)
		{
			return;
		}
		CharacterActorComponent component = newEntity.Entity.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid || !component.IsAutonomousProxy)
		{
			return;
		}
		this.CurrentPlayerHandle = newEntity;
		this.BindPlayerEvents(newEntity);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Controller;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "[IdlePerform] 绑定本地受控玩家闲置事件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", newEntity.Id);
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600F5E6 RID: 62950 RVA: 0x00435720 File Offset: 0x00433920
	private unsafe void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle removedEntity)
	{
		EntityHandle currentPlayerHandle = this.CurrentPlayerHandle;
		if (currentPlayerHandle == null || currentPlayerHandle.Id != removedEntity.Id)
		{
			return;
		}
		this.UnbindPlayerEvents(removedEntity);
		this.CurrentPlayerHandle = null;
		IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
		if (instance != null)
		{
			instance.ResetIdleTime();
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Controller;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "[IdlePerform] 本地受控玩家实体移除，解绑闲置事件";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", removedEntity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RemoveType", removeType);
		instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600F5E7 RID: 62951 RVA: 0x004357C9 File Offset: 0x004339C9
	private void OnUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ResetIdleTime();
	}

	// Token: 0x0600F5E8 RID: 62952 RVA: 0x004357DA File Offset: 0x004339DA
	private void OnBeHit(global::HitInformation hitData, HitContext _)
	{
		IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ResetIdleTime();
	}

	// Token: 0x0600F5E9 RID: 62953 RVA: 0x004357EB File Offset: 0x004339EB
	private void OnUnifiedMoveStateChanged(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
	{
		if (!this.StopIdleMoveStates.Contains(newMoveState))
		{
			IdlePerformModel instance = ModelBase<IdlePerformModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ResetIdleTime();
		}
	}

	// Token: 0x040076E3 RID: 30435
	[Nullable(2)]
	private EntityHandle CurrentPlayerHandle;

	// Token: 0x040076E4 RID: 30436
	private readonly HashSet<global::ECharMoveState> StopIdleMoveStates = new HashSet<global::ECharMoveState>
	{
		global::ECharMoveState.Stand,
		global::ECharMoveState.Walk,
		global::ECharMoveState.WalkStop,
		global::ECharMoveState.RunStop,
		global::ECharMoveState.SprintStop
	};
}
