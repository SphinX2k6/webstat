using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x0200346F RID: 13423
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CreatureGroupController : ControllerBase<CreatureGroupController>
{
	// Token: 0x0601C48A RID: 115850 RVA: 0x00874A81 File Offset: 0x00872C81
	protected override bool OnClear()
	{
		this.BindEntityGroups.Clear();
		this.BindGroupEntityWhiteFilter.Cleanup();
		return base.OnClear();
	}

	// Token: 0x0601C48B RID: 115851 RVA: 0x00874AA0 File Offset: 0x00872CA0
	public unsafe void AddBindEntity(long creatureDataIdA, long creatureDataIdB)
	{
		this.BindEntityGroups.Union(creatureDataIdA, creatureDataIdB);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.ZQR;
		string message = "[实体生命周期:实体绑组] 建立实体绑定";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataIdA", creatureDataIdA);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataIdB", creatureDataIdB);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0601C48C RID: 115852 RVA: 0x00874B17 File Offset: 0x00872D17
	public bool HasBindGroup(long creatureDataId)
	{
		return this.BindEntityGroups.Has(creatureDataId);
	}

	// Token: 0x0601C48D RID: 115853 RVA: 0x00874B25 File Offset: 0x00872D25
	[NullableContext(2)]
	public IReadOnlyList<long> GetBindGroup(long creatureDataId)
	{
		return this.BindEntityGroups.GetSet(creatureDataId);
	}

	// Token: 0x0601C48E RID: 115854 RVA: 0x00874B34 File Offset: 0x00872D34
	private EExecutedFlag? GetHighestExecutedFlag(long creatureDataId)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		if (entity == null || !entity.Valid || entity.Entity == null)
		{
			return null;
		}
		EExecutedFlag flag = entity.Entity.Flag;
		if ((flag & EExecutedFlag.Clear) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.Clear);
		}
		if ((flag & EExecutedFlag.End) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.End);
		}
		if ((flag & EExecutedFlag.PostActivate) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.PostActivate);
		}
		if ((flag & EExecutedFlag.Activate) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.Activate);
		}
		if ((flag & EExecutedFlag.Start) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.Start);
		}
		if ((flag & EExecutedFlag.Init) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.Init);
		}
		if ((flag & EExecutedFlag.Create) != EExecutedFlag.None)
		{
			return new EExecutedFlag?(EExecutedFlag.Create);
		}
		return new EExecutedFlag?(EExecutedFlag.None);
	}

	// Token: 0x0601C48F RID: 115855 RVA: 0x00874BE4 File Offset: 0x00872DE4
	private EExecutedFlag GetHighestExecutedFlagInBindGroup(IReadOnlyList<long> bindGroup)
	{
		EExecutedFlag eexecutedFlag = EExecutedFlag.Start;
		foreach (long creatureDataId in bindGroup)
		{
			EExecutedFlag? highestExecutedFlag = this.GetHighestExecutedFlag(creatureDataId);
			if (highestExecutedFlag != null)
			{
				eexecutedFlag = (EExecutedFlag)Math.Max((int)eexecutedFlag, (int)highestExecutedFlag.Value);
			}
		}
		return eexecutedFlag;
	}

	// Token: 0x0601C490 RID: 115856 RVA: 0x00874C48 File Offset: 0x00872E48
	private EExecutedFlag GetLowestExecutedFlagInBindGroup(IReadOnlyList<long> bindGroup)
	{
		EExecutedFlag eexecutedFlag = EExecutedFlag.PostActivate;
		foreach (long creatureDataId in bindGroup)
		{
			EExecutedFlag? highestExecutedFlag = this.GetHighestExecutedFlag(creatureDataId);
			if (highestExecutedFlag != null)
			{
				eexecutedFlag = (EExecutedFlag)Math.Min((int)eexecutedFlag, (int)highestExecutedFlag.Value);
			}
		}
		return eexecutedFlag;
	}

	// Token: 0x0601C491 RID: 115857 RVA: 0x00874CAC File Offset: 0x00872EAC
	private void ReleaseRefreshBindGroupLock()
	{
		this.RefreshBindGroupLock = false;
		if (this.RefreshBindGroupCache.Count > 0)
		{
			long num = this.RefreshBindGroupCache.Keys.First<long>();
			string reason = this.RefreshBindGroupCache[num];
			this.RefreshBindGroupCache.Remove(num);
			this.RefreshBindGroup(num, reason);
		}
	}

	// Token: 0x0601C492 RID: 115858 RVA: 0x00874D04 File Offset: 0x00872F04
	public unsafe void RefreshBindGroup(long creatureDataId, string reason)
	{
		IReadOnlyList<long> bindGroup = this.GetBindGroup(creatureDataId);
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bindGroup", bindGroup);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", (entity != null) ? new int?(entity.Id) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("reason", reason);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4);
		if (bindGroup == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.ZQR, "[实体生命周期:实体绑组] 实体不在实体组中", readOnlySpan);
			this.ReleaseRefreshBindGroupLock();
			return;
		}
		EExecutedFlag highestExecutedFlagInBindGroup = this.GetHighestExecutedFlagInBindGroup(bindGroup);
		EExecutedFlag lowestExecutedFlagInBindGroup = this.GetLowestExecutedFlagInBindGroup(bindGroup);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan2 = readOnlySpan;
		int num = 0;
		ValueTuple<string, object>[] array = new ValueTuple<string, object>[2 + readOnlySpan2.Length];
		readOnlySpan2.CopyTo(new Span<ValueTuple<string, object>>(array).Slice(num, readOnlySpan2.Length));
		num += readOnlySpan2.Length;
		array[num] = new ValueTuple<string, object>("highestFlag", highestExecutedFlagInBindGroup);
		num++;
		array[num] = new ValueTuple<string, object>("lowestFlag", lowestExecutedFlagInBindGroup);
		readOnlySpan = new ReadOnlySpan<ValueTuple<string, object>>(array);
		if (lowestExecutedFlagInBindGroup >= EExecutedFlag.PostActivate)
		{
			Singleton<Log>.Instance.Info(ELogModule.Entity, ELogAuthor.ZQR, "[实体生命周期:实体绑组] 实体组激活完毕，删除实体组及相应缓存", readOnlySpan);
			foreach (long key in bindGroup)
			{
				this.RefreshBindGroupCache.Remove(key);
			}
			this.BindEntityGroups.DeleteSet(creatureDataId);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<long>>(EEventName.RemoveEntityFromBindGroup, bindGroup);
			this.ReleaseRefreshBindGroupLock();
			return;
		}
		if (this.RefreshBindGroupLock)
		{
			this.RefreshBindGroupCache[creatureDataId] = reason;
			return;
		}
		this.RefreshBindGroupLock = true;
		if (lowestExecutedFlagInBindGroup >= highestExecutedFlagInBindGroup)
		{
			Singleton<Log>.Instance.Info(ELogModule.Entity, ELogAuthor.ZQR, "[实体生命周期:实体绑组] 整组推进生命周期", readOnlySpan);
			using (IEnumerator<long> enumerator = bindGroup.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long creatureDataId2 = enumerator.Current;
					this.ForwardEntityLifeCycle(creatureDataId2);
				}
				goto IL_2B7;
			}
		}
		if (highestExecutedFlagInBindGroup > EExecutedFlag.Start)
		{
			Singleton<Log>.Instance.Info(ELogModule.Entity, ELogAuthor.ZQR, "[实体生命周期:实体绑组] 部分推进生命周期", readOnlySpan);
			using (IEnumerator<long> enumerator = bindGroup.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long creatureDataId3 = enumerator.Current;
					EExecutedFlag? highestExecutedFlag = this.GetHighestExecutedFlag(creatureDataId3);
					if (highestExecutedFlag != null && highestExecutedFlag.Value < highestExecutedFlagInBindGroup)
					{
						this.ForwardEntityLifeCycle(creatureDataId3);
					}
				}
				goto IL_2B7;
			}
		}
		Singleton<Log>.Instance.Info(ELogModule.Entity, ELogAuthor.ZQR, "[实体生命周期:实体绑组] 同组尚未start，暂时阻塞", readOnlySpan);
		IL_2B7:
		this.ReleaseRefreshBindGroupLock();
	}

	// Token: 0x0601C493 RID: 115859 RVA: 0x00874FF8 File Offset: 0x008731F8
	private unsafe void ForwardEntityLifeCycle(long creatureDataId)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		EExecutedFlag? highestExecutedFlag = this.GetHighestExecutedFlag(creatureDataId);
		if (entity == null || !entity.Valid || entity.Entity == null)
		{
			return;
		}
		if (highestExecutedFlag == null || highestExecutedFlag.Value == EExecutedFlag.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "[实体生命周期:实体绑组]实体Flag为空";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ExecutedFlag", highestExecutedFlag);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (highestExecutedFlag.Value >= EExecutedFlag.Start && highestExecutedFlag.Value < EExecutedFlag.PostActivate)
		{
			if (highestExecutedFlag.Value == EExecutedFlag.Start)
			{
				ControllerBase<CreatureController>.Instance.ActivateEntityRequest(entity);
				return;
			}
			if (highestExecutedFlag.Value == EExecutedFlag.Activate)
			{
				Singleton<EntitySystem>.Instance.PostActive(entity.Entity);
				this.RefreshBindGroup(creatureDataId, "postActive");
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.ZQR;
			string message2 = "[实体生命周期:实体绑组]预期外的flag类型";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityId", entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("ExecutedFlag", highestExecutedFlag);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
	}

	// Token: 0x0601C494 RID: 115860 RVA: 0x008751A0 File Offset: 0x008733A0
	public void RemoveFromBindGroup(long creatureDataId, string reason)
	{
		IReadOnlyList<long> bindGroup = this.GetBindGroup(creatureDataId);
		if (bindGroup == null)
		{
			return;
		}
		long? num = null;
		foreach (long num2 in bindGroup)
		{
			if (num2 != creatureDataId)
			{
				num = new long?(num2);
				break;
			}
		}
		this.BindEntityGroups.Delete(creatureDataId);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<long>>(EEventName.RemoveEntityFromBindGroup, new <>z__ReadOnlySingleElementList<long>(creatureDataId));
		if (num != null)
		{
			if (this.HasBindGroup(num.Value))
			{
				this.RefreshBindGroup(num.Value, reason);
				return;
			}
			this.ForwardEntityLifeCycle(num.Value);
		}
	}

	// Token: 0x0400E391 RID: 58257
	private readonly DisjointSet<long> BindEntityGroups = new DisjointSet<long>();

	// Token: 0x0400E392 RID: 58258
	private readonly BindGroupEntityWhiteFilter BindGroupEntityWhiteFilter = new BindGroupEntityWhiteFilter();

	// Token: 0x0400E393 RID: 58259
	private bool RefreshBindGroupLock;

	// Token: 0x0400E394 RID: 58260
	private readonly Dictionary<long, string> RefreshBindGroupCache = new Dictionary<long, string>();
}
