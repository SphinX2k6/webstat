using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02002F45 RID: 12101
[NullableContext(1)]
[Nullable(0)]
public class SyncTimescaleGroup
{
	// Token: 0x06018C35 RID: 101429 RVA: 0x006FFE88 File Offset: 0x006FE088
	public SyncTimescaleGroup(EntityHandle instigatorHandle, long buffId)
	{
		this.InstigatorHandle = instigatorHandle;
		this.BuffId = buffId;
		WorldEntity entity = this.InstigatorHandle.Entity;
		this.InstigatorTimeScaleComp = ((entity != null) ? entity.GetComponent<CharacterTimeScaleComponent>() : null);
		Singleton<EventSystem>.Instance.AddWithTarget(this.InstigatorHandle.Entity, EEventName.CharBeHitTimeScale, new Action<float, ETimeScaleSourceType>(this.OnInstigatorTimeScaleChanged));
	}

	// Token: 0x06018C36 RID: 101430 RVA: 0x006FFEF5 File Offset: 0x006FE0F5
	public void Release()
	{
		if (this.InstigatorHandle.Valid)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.InstigatorHandle.Entity, EEventName.CharBeHitTimeScale, new Action<float, ETimeScaleSourceType>(this.OnInstigatorTimeScaleChanged));
		}
	}

	// Token: 0x06018C37 RID: 101431 RVA: 0x006FFF28 File Offset: 0x006FE128
	public bool HasOwner(int ownerId)
	{
		return this.OwnerIds.ContainsKey(ownerId);
	}

	// Token: 0x06018C38 RID: 101432 RVA: 0x006FFF38 File Offset: 0x006FE138
	[NullableContext(2)]
	public unsafe void AddOwner(Entity ownerEntity = null)
	{
		if (ownerEntity == null)
		{
			return;
		}
		if (this.OwnerIds.ContainsKey(ownerEntity.Id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BuffItem;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "添加了多个Buff都有85号效果";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Instigator", this.InstigatorHandle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Owner", ownerEntity.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		CharacterTimeScaleComponent component = ownerEntity.GetComponent<CharacterTimeScaleComponent>();
		if (component != null)
		{
			this.OwnerIds[ownerEntity.Id] = component;
			if (component.Valid)
			{
				CharacterTimeScaleComponent instigatorTimeScaleComp = this.InstigatorTimeScaleComp;
				if (instigatorTimeScaleComp != null && instigatorTimeScaleComp.Valid)
				{
					component.AddForceTimeScale(this.InstigatorTimeScaleComp.CurrentTimeScale, "ExtraEffect.SyncTimeScale", true, ETimeScaleSourceType.InnerForceTimeScale);
				}
			}
		}
	}

	// Token: 0x06018C39 RID: 101433 RVA: 0x0070003F File Offset: 0x006FE23F
	public string GetOwnerInfo()
	{
		return string.Join<int>(",", this.OwnerIds.Keys);
	}

	// Token: 0x06018C3A RID: 101434 RVA: 0x00700058 File Offset: 0x006FE258
	public void RemoveOwner(int entityId)
	{
		CharacterTimeScaleComponent characterTimeScaleComponent;
		if (this.OwnerIds.TryGetValue(entityId, out characterTimeScaleComponent) && characterTimeScaleComponent.Valid)
		{
			characterTimeScaleComponent.RemoveForceTimeScale("ExtraEffect.SyncTimeScale", true);
		}
		this.OwnerIds.Remove(entityId);
	}

	// Token: 0x06018C3B RID: 101435 RVA: 0x00700098 File Offset: 0x006FE298
	public void OnInstigatorTimeScaleChanged(float timeScale, ETimeScaleSourceType sourceType)
	{
		foreach (CharacterTimeScaleComponent characterTimeScaleComponent in this.OwnerIds.Values)
		{
			if (characterTimeScaleComponent != null && characterTimeScaleComponent.Valid)
			{
				characterTimeScaleComponent.AddForceTimeScale(timeScale, "ExtraEffect.SyncTimeScale", true, sourceType);
			}
		}
	}

	// Token: 0x06018C3C RID: 101436 RVA: 0x00700104 File Offset: 0x006FE304
	public bool CanRelease()
	{
		return this.OwnerIds.Count <= 0;
	}

	// Token: 0x0400C0DF RID: 49375
	private const string ForceTimeScaleLockKey = "ExtraEffect.SyncTimeScale";

	// Token: 0x0400C0E0 RID: 49376
	private readonly Dictionary<int, CharacterTimeScaleComponent> OwnerIds = new Dictionary<int, CharacterTimeScaleComponent>();

	// Token: 0x0400C0E1 RID: 49377
	[Nullable(2)]
	public readonly CharacterTimeScaleComponent InstigatorTimeScaleComp;

	// Token: 0x0400C0E2 RID: 49378
	public readonly EntityHandle InstigatorHandle;

	// Token: 0x0400C0E3 RID: 49379
	private readonly long BuffId;
}
