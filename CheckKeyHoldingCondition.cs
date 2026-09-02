using System;
using System.Runtime.CompilerServices;

// Token: 0x02001889 RID: 6281
[NullableContext(1)]
[Nullable(0)]
public class CheckKeyHoldingCondition : BaseCheckCondition
{
	// Token: 0x0600B41B RID: 46107 RVA: 0x002FF823 File Offset: 0x002FDA23
	public CheckKeyHoldingCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Event;
		this.FailType = EComboTeachingFailCondition.HoldKey;
		this.SuccessType = EComboTeachingSuccessCondition.HoldKey;
	}

	// Token: 0x17000EE6 RID: 3814
	// (get) Token: 0x0600B41C RID: 46108 RVA: 0x002FF852 File Offset: 0x002FDA52
	// (set) Token: 0x0600B41D RID: 46109 RVA: 0x002FF85A File Offset: 0x002FDA5A
	public override EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EE7 RID: 3815
	// (get) Token: 0x0600B41E RID: 46110 RVA: 0x002FF863 File Offset: 0x002FDA63
	// (set) Token: 0x0600B41F RID: 46111 RVA: 0x002FF86B File Offset: 0x002FDA6B
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.HoldKey;

	// Token: 0x17000EE8 RID: 3816
	// (get) Token: 0x0600B420 RID: 46112 RVA: 0x002FF874 File Offset: 0x002FDA74
	// (set) Token: 0x0600B421 RID: 46113 RVA: 0x002FF87C File Offset: 0x002FDA7C
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.HoldKey;

	// Token: 0x0600B422 RID: 46114 RVA: 0x002FF888 File Offset: 0x002FDA88
	protected override bool CheckFail(IComboTeachingInfo node, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckKeyCondition checkKeyCondition = extra as ICheckKeyCondition;
		if (this.ParamsArray == null || checkKeyCondition == null)
		{
			return false;
		}
		string b;
		if (!ComboTeachingDefine.inputActionMap.TryGetValue(checkKeyCondition.ActionKey, out b))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ComboTeaching;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "未找到按键条件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionKey", checkKeyCondition.ActionKey);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return int.Parse(this.ParamsArray[1]) == 2 && this.ParamsArray[0] == b && float.Parse(this.ParamsArray[2]) <= checkKeyCondition.HoldTime.GetValueOrDefault();
	}

	// Token: 0x0600B423 RID: 46115 RVA: 0x002FF944 File Offset: 0x002FDB44
	protected override bool CheckSuccess(IComboTeachingInfo node, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckKeyCondition checkKeyCondition = extra as ICheckKeyCondition;
		if (checkKeyCondition == null)
		{
			return false;
		}
		string a;
		if (!ComboTeachingDefine.inputActionMap.TryGetValue(checkKeyCondition.ActionKey, out a))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ComboTeaching;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "未找到按键条件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionKey", checkKeyCondition.ActionKey);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return a == node.ActionInfo && node.HoldTotalTime <= checkKeyCondition.HoldTime.GetValueOrDefault();
	}
}
