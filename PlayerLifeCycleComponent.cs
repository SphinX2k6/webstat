using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003241 RID: 12865
public class PlayerLifeCycleComponent : EntityComponent
{
	// Token: 0x0601AC94 RID: 109716 RVA: 0x007FBFCC File Offset: 0x007FA1CC
	[NullableContext(2)]
	protected unsafe override bool OnInitData(IEntityArgs args = null)
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
		if (this.PlayerId == 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Actor;
			Entity entity = base.Entity;
			string message = "初始化PlayerEntity时找不到合法的PlayerId";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerId", this.PlayerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(this.PlayerId);
		if (playerEntity != null)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Actor;
			Entity entity2 = base.Entity;
			string message2 = "PlayerId已经存在";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PlayerId", this.PlayerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("entityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("oldEntityId", playerEntity.Id);
			instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		ControllerBase<FormationDataController>.Instance.RegisterPlayerEntity(this.PlayerId, base.Entity as WorldEntity);
		return true;
	}

	// Token: 0x0601AC95 RID: 109717 RVA: 0x007FC16F File Offset: 0x007FA36F
	protected override bool OnStart()
	{
		Singleton<EventSystem>.Instance.Emit<int, Entity>(EEventName.PlayerEntityStarted, this.PlayerId, base.Entity);
		return true;
	}

	// Token: 0x0601AC96 RID: 109718 RVA: 0x007FC18E File Offset: 0x007FA38E
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.Emit<int, Entity>(EEventName.PlayerEntityEnded, this.PlayerId, base.Entity);
		return true;
	}

	// Token: 0x0601AC97 RID: 109719 RVA: 0x007FC1AD File Offset: 0x007FA3AD
	protected override bool OnClear()
	{
		ControllerBase<FormationDataController>.Instance.UnRegisterPlayerEntity(this.PlayerId);
		return true;
	}

	// Token: 0x0601AC98 RID: 109720 RVA: 0x007FC1C0 File Offset: 0x007FA3C0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PlayerLifeCycleComponent playerLifeCycleComponent = (PlayerLifeCycleComponent)componentTemplate;
		if (base.CanResetComponentProperty("PlayerId"))
		{
			this.PlayerId = playerLifeCycleComponent.PlayerId;
		}
		return true;
	}

	// Token: 0x0400D93A RID: 55610
	protected int PlayerId;
}
