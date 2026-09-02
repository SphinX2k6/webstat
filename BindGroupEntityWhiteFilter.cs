using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003454 RID: 13396
[NullableContext(1)]
[Nullable(0)]
public sealed class BindGroupEntityWhiteFilter : EntityToLoadFilter
{
	// Token: 0x1700264D RID: 9805
	// (get) Token: 0x0601C186 RID: 115078 RVA: 0x00861F3A File Offset: 0x0086013A
	public override string DebugName
	{
		get
		{
			return "BindGroupEntityWhiteFilter";
		}
	}

	// Token: 0x1700264E RID: 9806
	// (get) Token: 0x0601C187 RID: 115079 RVA: 0x00861F41 File Offset: 0x00860141
	public override EFilterType FilterType
	{
		get
		{
			return EFilterType.BindGroup;
		}
	}

	// Token: 0x0601C188 RID: 115080 RVA: 0x00861F44 File Offset: 0x00860144
	public BindGroupEntityWhiteFilter()
	{
		this.TargetCriteriaInternal = new Func<EntityHandle, bool>(this.TargetCriteriaFunc);
	}

	// Token: 0x0601C189 RID: 115081 RVA: 0x00861F6C File Offset: 0x0086016C
	private unsafe bool TargetCriteriaFunc(EntityHandle entityHandle)
	{
		IReadOnlyList<long> bindGroup = ControllerBase<CreatureGroupController>.Instance.GetBindGroup(entityHandle.CreatureDataId);
		if (bindGroup == null)
		{
			return false;
		}
		foreach (long item in bindGroup)
		{
			this.WhiteListForBindGroups.Add(item);
		}
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.XY;
			string message = "预加载实体:加入实体组白名单";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", entityHandle.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("group", string.Join<long>(",", bindGroup));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("whiteList", this.WhiteListForBindGroups);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return this.WhiteListForBindGroups.Contains(entityHandle.CreatureDataId);
	}

	// Token: 0x0601C18A RID: 115082 RVA: 0x00862074 File Offset: 0x00860274
	public override void Init()
	{
		base.Init();
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<long>>(EEventName.RemoveEntityFromBindGroup, new Action<IReadOnlyList<long>>(this.OnEntityRemovedFromBindGroup));
	}

	// Token: 0x0601C18B RID: 115083 RVA: 0x00862098 File Offset: 0x00860298
	public override void Cleanup()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<long>>(EEventName.RemoveEntityFromBindGroup, new Action<IReadOnlyList<long>>(this.OnEntityRemovedFromBindGroup));
		base.Cleanup();
	}

	// Token: 0x0601C18C RID: 115084 RVA: 0x008620BC File Offset: 0x008602BC
	private unsafe void CleanWhitelist(long creatureDataId)
	{
		if (this.WhiteListForBindGroups.Remove(creatureDataId))
		{
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预加载实体:清除实体组白名单";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", creatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("whiteList", this.WhiteListForBindGroups);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			Singleton<EventSystem>.Instance.Emit<object>(EEventName.FilterCriteriaChanged, this);
		}
	}

	// Token: 0x0601C18D RID: 115085 RVA: 0x00862154 File Offset: 0x00860354
	private void OnEntityRemovedFromBindGroup(IReadOnlyList<long> creatureDataIds)
	{
		foreach (long creatureDataId in creatureDataIds)
		{
			this.CleanWhitelist(creatureDataId);
		}
	}

	// Token: 0x0400E2EA RID: 58090
	private readonly HashSet<long> WhiteListForBindGroups = new HashSet<long>();
}
