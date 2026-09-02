using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003170 RID: 12656
[NullableContext(1)]
[Nullable(0)]
public class EntityHandle
{
	// Token: 0x0601A3BC RID: 107452 RVA: 0x007B5E80 File Offset: 0x007B4080
	public EntityHandle(WorldEntity Entity)
	{
		this.Entity = Entity;
		this.Id = Entity.Id;
		this.Index = Entity.Index;
	}

	// Token: 0x0601A3BD RID: 107453 RVA: 0x007B5EBC File Offset: 0x007B40BC
	public unsafe bool AddHoldEntity(string reason)
	{
		int num;
		if (!this.HoldEntityMap.TryGetValue(reason, out num))
		{
			num = 1;
		}
		else
		{
			num++;
		}
		if (ControllerBase<CreatureController>.Instance.CheckEnableEntityLog(new OneOf<EEntityType, EntityHandle>?((EEntityType)this.EntityType)))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Engine;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AddHoldEntity";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Count", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		this.HoldEntityMap[reason] = num;
		return true;
	}

	// Token: 0x0601A3BE RID: 107454 RVA: 0x007B5FA8 File Offset: 0x007B41A8
	public unsafe bool RemoveHoldEntity(string reason)
	{
		int num;
		if (!this.HoldEntityMap.TryGetValue(reason, out num))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Engine;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "reason不存在，RemoveHoldEntity失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		num--;
		if (num <= 0)
		{
			this.HoldEntityMap.Remove(reason);
		}
		else
		{
			this.HoldEntityMap[reason] = num;
		}
		if (ControllerBase<CreatureController>.Instance.CheckEnableEntityLog(new OneOf<EEntityType, EntityHandle>?((EEntityType)this.EntityType)))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Engine;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "RemoveHoldEntity";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("EntityId", this.Id);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		return true;
	}

	// Token: 0x0601A3BF RID: 107455 RVA: 0x007B6104 File Offset: 0x007B4304
	public unsafe void ClearHoldEntity()
	{
		if (ControllerBase<CreatureController>.Instance.CheckEnableEntityLog(new OneOf<EEntityType, EntityHandle>?((EEntityType)this.EntityType)))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Engine;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "ClearHoldEntity";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.Id);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.HoldEntityMap.Clear();
	}

	// Token: 0x170023AB RID: 9131
	// (get) Token: 0x0601A3C0 RID: 107456 RVA: 0x007B619D File Offset: 0x007B439D
	public bool Valid
	{
		get
		{
			return ModelBase<CharacterModel>.Instance.IsValid(this.Id);
		}
	}

	// Token: 0x170023AC RID: 9132
	// (get) Token: 0x0601A3C1 RID: 107457 RVA: 0x007B61AF File Offset: 0x007B43AF
	public bool IsInit
	{
		get
		{
			return this.Valid && this.Entity.IsInit;
		}
	}

	// Token: 0x170023AD RID: 9133
	// (get) Token: 0x0601A3C2 RID: 107458 RVA: 0x007B61C6 File Offset: 0x007B43C6
	public bool AllowDestroy
	{
		get
		{
			return this.HoldEntityMap.Count == 0;
		}
	}

	// Token: 0x0601A3C3 RID: 107459 RVA: 0x007B61D6 File Offset: 0x007B43D6
	[NullableContext(2)]
	public static bool operator !([NotNullWhen(false)] EntityHandle handle)
	{
		return handle == null || !handle.Valid;
	}

	// Token: 0x0400D32A RID: 54058
	[Nullable(2)]
	public WorldEntity Entity;

	// Token: 0x0400D32B RID: 54059
	public readonly int Id;

	// Token: 0x0400D32C RID: 54060
	public long CreatureDataId;

	// Token: 0x0400D32D RID: 54061
	public int PbDataId;

	// Token: 0x0400D32E RID: 54062
	public EntityConfigType ConfigType;

	// Token: 0x0400D32F RID: 54063
	public int EntityType;

	// Token: 0x0400D330 RID: 54064
	public readonly int Index;

	// Token: 0x0400D331 RID: 54065
	public ResourceSystem.EResourceLoadPriority Priority = ResourceSystem.EResourceLoadPriority.Default;

	// Token: 0x0400D332 RID: 54066
	public bool PendingRemoving;

	// Token: 0x0400D333 RID: 54067
	public bool HasSendingRequest;

	// Token: 0x0400D334 RID: 54068
	public readonly Dictionary<string, int> HoldEntityMap = new Dictionary<string, int>();
}
