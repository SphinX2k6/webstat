using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002F44 RID: 12100
[NullableContext(1)]
[Nullable(0)]
public class SyncTimeScaleEffect : BuffEffect, IStaticVariableResetter
{
	// Token: 0x06018C2A RID: 101418 RVA: 0x006FFB02 File Offset: 0x006FDD02
	static SyncTimeScaleEffect()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SyncTimeScaleEffect.CreateStaticDefaultValue), new Action(SyncTimeScaleEffect.ResetStaticDefaultValue));
	}

	// Token: 0x17002185 RID: 8581
	// (get) Token: 0x06018C2B RID: 101419 RVA: 0x006FFB21 File Offset: 0x006FDD21
	private static Dictionary<int, SyncTimescaleGroup> AllGroups
	{
		get
		{
			return SyncTimeScaleEffect._allGroups;
		}
	}

	// Token: 0x06018C2C RID: 101420 RVA: 0x006FFB28 File Offset: 0x006FDD28
	public static void CreateStaticDefaultValue()
	{
		SyncTimeScaleEffect._allGroups = new Dictionary<int, SyncTimescaleGroup>();
	}

	// Token: 0x06018C2D RID: 101421 RVA: 0x006FFB34 File Offset: 0x006FDD34
	public static void ResetStaticDefaultValue()
	{
		SyncTimeScaleEffect._allGroups = null;
	}

	// Token: 0x06018C2E RID: 101422 RVA: 0x006FFB3C File Offset: 0x006FDD3C
	public SyncTimeScaleEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C2F RID: 101423 RVA: 0x006FFB58 File Offset: 0x006FDD58
	private bool CheckConflict()
	{
		using (Dictionary<int, SyncTimescaleGroup>.ValueCollection.Enumerator enumerator = SyncTimeScaleEffect.AllGroups.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasOwner(base.OwnerEntity.Id))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06018C30 RID: 101424 RVA: 0x006FFBC0 File Offset: 0x006FDDC0
	public unsafe override void OnCreated()
	{
		if (this.InstigatorEntityId != base.OwnerEntity.Id)
		{
			EntityHandle instigatorEntity = base.InstigatorEntity;
			if (instigatorEntity != null && instigatorEntity.Valid && !this.CheckConflict())
			{
				this.OwnerId = base.OwnerEntity.Id;
				SyncTimescaleGroup syncTimescaleGroup;
				if (!SyncTimeScaleEffect.AllGroups.TryGetValue(this.InstigatorEntityId, out syncTimescaleGroup))
				{
					syncTimescaleGroup = new SyncTimescaleGroup(base.InstigatorEntity, this.BuffId);
					SyncTimeScaleEffect.AllGroups[this.InstigatorEntityId] = syncTimescaleGroup;
				}
				this.Group = syncTimescaleGroup;
				syncTimescaleGroup.AddOwner(base.OwnerEntity);
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BuffItem;
		ELogAuthor author = ELogAuthor.HCW;
		string message = "顿帧同步效果 OnCreated";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff", this.BuffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Instigator", base.OwnerEntity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Owner", base.OwnerEntity.Id);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item = "Instigator.Valid";
		EntityHandle instigatorEntity2 = base.InstigatorEntity;
		ptr = new ValueTuple<string, object>(item, (instigatorEntity2 != null) ? new bool?(instigatorEntity2.Valid) : null);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		this.SameEntityError = true;
	}

	// Token: 0x06018C31 RID: 101425 RVA: 0x006FFD33 File Offset: 0x006FDF33
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C32 RID: 101426 RVA: 0x006FFD38 File Offset: 0x006FDF38
	public override void OnRemoved(bool bPremature)
	{
		if (this.Group == null || this.SameEntityError)
		{
			return;
		}
		foreach (int id in this.TimeScaleIdSet)
		{
			this.RemoveTimeScale(id, false);
		}
		this.TimeScaleIdSet.Clear();
		this.Group.RemoveOwner(this.OwnerId);
		if (this.Group.CanRelease())
		{
			this.Group.Release();
			SyncTimeScaleEffect.AllGroups.Remove(this.InstigatorEntityId);
		}
		this.Group = null;
	}

	// Token: 0x06018C33 RID: 101427 RVA: 0x006FFDEC File Offset: 0x006FDFEC
	[NullableContext(2)]
	public int SetTimeScale(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
	{
		SyncTimescaleGroup group = this.Group;
		bool flag;
		if (group == null)
		{
			flag = false;
		}
		else
		{
			CharacterTimeScaleComponent instigatorTimeScaleComp = group.InstigatorTimeScaleComp;
			flag = ((instigatorTimeScaleComp != null) ? new bool?(instigatorTimeScaleComp.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			int num = this.Group.InstigatorTimeScaleComp.SetTimeScale(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, immuneSelfCenter);
			this.TimeScaleIdSet.Add(num);
			return num;
		}
		return 0;
	}

	// Token: 0x06018C34 RID: 101428 RVA: 0x006FFE5A File Offset: 0x006FE05A
	public void RemoveTimeScale(int id, bool deleteTimeScaleId = true)
	{
		if (deleteTimeScaleId)
		{
			this.TimeScaleIdSet.Remove(id);
		}
		SyncTimescaleGroup group = this.Group;
		if (group == null)
		{
			return;
		}
		CharacterTimeScaleComponent instigatorTimeScaleComp = group.InstigatorTimeScaleComp;
		if (instigatorTimeScaleComp == null)
		{
			return;
		}
		instigatorTimeScaleComp.RemoveTimeScale(id);
	}

	// Token: 0x0400C0DA RID: 49370
	[Nullable(2)]
	public SyncTimescaleGroup Group;

	// Token: 0x0400C0DB RID: 49371
	private int OwnerId;

	// Token: 0x0400C0DC RID: 49372
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, SyncTimescaleGroup> _allGroups;

	// Token: 0x0400C0DD RID: 49373
	private bool SameEntityError;

	// Token: 0x0400C0DE RID: 49374
	private readonly HashSet<int> TimeScaleIdSet = new HashSet<int>();
}
