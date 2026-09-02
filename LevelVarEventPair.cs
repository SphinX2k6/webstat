using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;

// Token: 0x02000D01 RID: 3329
public class LevelVarEventPair
{
	// Token: 0x1700031B RID: 795
	// (get) Token: 0x06004295 RID: 17045 RVA: 0x000772F2 File Offset: 0x000754F2
	// (set) Token: 0x06004294 RID: 17044 RVA: 0x00077290 File Offset: 0x00075490
	protected OneOf<bool, int> CurrentValue
	{
		get
		{
			return this.CurrentValueInternal;
		}
		set
		{
			if (this.CurrentValueInternal.Equals(value))
			{
				return;
			}
			this.CurrentValueInternal = value;
			if (this.BoolEventBinder != null)
			{
				this.BoolEventBinder.Callback.Broadcast(value.AsT1);
				return;
			}
			if (this.IntEventBinder != null)
			{
				this.IntEventBinder.Callback.Broadcast(value.AsT2);
			}
		}
	}

	// Token: 0x06004296 RID: 17046 RVA: 0x000772FA File Offset: 0x000754FA
	[NullableContext(1)]
	public virtual bool Init(SAiLevelVar levelVar, UKuroBooleanEventBinder boolEventBinder)
	{
		this.LevelVar = levelVar;
		this.BoolEventBinder = boolEventBinder;
		return true;
	}

	// Token: 0x06004297 RID: 17047 RVA: 0x0007730B File Offset: 0x0007550B
	[NullableContext(1)]
	public virtual bool Init(SAiLevelVar levelVar, UKuroIntEventBinder intEventBinder)
	{
		this.LevelVar = levelVar;
		this.IntEventBinder = intEventBinder;
		return true;
	}

	// Token: 0x06004298 RID: 17048 RVA: 0x0007731C File Offset: 0x0007551C
	public virtual void Clear()
	{
		this.LevelVar = null;
		this.BoolEventBinder = null;
		this.IntEventBinder = null;
	}

	// Token: 0x06004299 RID: 17049 RVA: 0x00077334 File Offset: 0x00075534
	[NullableContext(2)]
	protected unsafe bool ParseValue(VarDefinePb treeValue, bool isInit = true)
	{
		if (treeValue == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加监听的变量未找到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("QuestId", this.LevelVar.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (this.BoolEventBinder != null)
		{
			if (!treeValue.HasBoolean)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.AI;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "添加监听的变量类型不正确";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("QuestId", this.LevelVar.Id);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			bool value = Convert.ToBoolean(treeValue.Boolean);
			if (isInit)
			{
				this.CurrentValueInternal = value;
			}
			else
			{
				this.CurrentValue = new OneOf<bool, int>(value);
			}
			return true;
		}
		else
		{
			if (this.IntEventBinder == null)
			{
				return false;
			}
			if (!treeValue.HasInt)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.AI;
				ELogAuthor author3 = ELogAuthor.CH;
				string message3 = "添加监听的变量类型不正确";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Key", this.LevelVar.VarName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("QuestId", this.LevelVar.Id);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return false;
			}
			long @int = treeValue.Int;
			if (isInit)
			{
				this.CurrentValueInternal = (int)@int;
			}
			else
			{
				this.CurrentValue = new OneOf<bool, int>((int)@int);
			}
			return true;
		}
	}

	// Token: 0x040010E9 RID: 4329
	[Nullable(2)]
	public SAiLevelVar LevelVar;

	// Token: 0x040010EA RID: 4330
	[Nullable(2)]
	public UKuroBooleanEventBinder BoolEventBinder;

	// Token: 0x040010EB RID: 4331
	[Nullable(2)]
	public UKuroIntEventBinder IntEventBinder;

	// Token: 0x040010EC RID: 4332
	protected OneOf<bool, int> CurrentValueInternal;

	// Token: 0x040010ED RID: 4333
	protected bool IsInit;
}
