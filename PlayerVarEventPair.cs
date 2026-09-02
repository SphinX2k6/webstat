using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;

// Token: 0x02000D04 RID: 3332
[NullableContext(1)]
[Nullable(0)]
public class PlayerVarEventPair : LevelVarEventPair
{
	// Token: 0x060042A6 RID: 17062 RVA: 0x00077CF0 File Offset: 0x00075EF0
	public unsafe override bool Init(SAiLevelVar levelVar, UKuroBooleanEventBinder boolEventBinder)
	{
		base.Init(levelVar, boolEventBinder);
		OneOf<bool, string, double> worldState = ModelBase<WorldModel>.Instance.GetWorldState(levelVar.VarName);
		if (!worldState.HasValue || worldState.IsT2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加监听的玩家变量类型不正确或未找到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", levelVar.VarName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Value", worldState);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (worldState.IsT1)
		{
			base.CurrentValue = new OneOf<bool, int>(worldState.AsT1);
		}
		else if (worldState.IsT3)
		{
			base.CurrentValue = new OneOf<bool, int>((int)worldState.AsT3);
		}
		this.IsInit = true;
		return true;
	}

	// Token: 0x060042A7 RID: 17063 RVA: 0x00077DCC File Offset: 0x00075FCC
	public unsafe override bool Init(SAiLevelVar levelVar, UKuroIntEventBinder intEventBinder)
	{
		base.Init(levelVar, intEventBinder);
		OneOf<bool, string, double> worldState = ModelBase<WorldModel>.Instance.GetWorldState(levelVar.VarName);
		if (!worldState.HasValue || worldState.IsT2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加监听的玩家变量类型不正确或未找到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", levelVar.VarName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Value", worldState);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (worldState.IsT1)
		{
			base.CurrentValue = new OneOf<bool, int>(worldState.AsT1);
		}
		else if (worldState.IsT3)
		{
			base.CurrentValue = new OneOf<bool, int>((int)worldState.AsT3);
		}
		this.IsInit = true;
		return true;
	}

	// Token: 0x060042A8 RID: 17064 RVA: 0x00077EA8 File Offset: 0x000760A8
	public void OnReceivePlayerVar()
	{
		if (!this.IsInit)
		{
			return;
		}
		OneOf<bool, string, double> worldState = ModelBase<WorldModel>.Instance.GetWorldState(this.LevelVar.VarName);
		if (worldState.HasValue)
		{
			if (worldState.IsT3)
			{
				base.CurrentValue = new OneOf<bool, int>((int)worldState.AsT3);
				return;
			}
			if (worldState.IsT1)
			{
				base.CurrentValue = new OneOf<bool, int>(worldState.AsT1);
			}
		}
	}
}
