using System;
using System.Runtime.CompilerServices;

// Token: 0x02001888 RID: 6280
[NullableContext(1)]
[Nullable(0)]
public class CheckKeyInputCondition : BaseCheckCondition
{
	// Token: 0x0600B412 RID: 46098 RVA: 0x002FF68C File Offset: 0x002FD88C
	public CheckKeyInputCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Event;
		this.FailType = EComboTeachingFailCondition.PressKey;
		this.SuccessType = EComboTeachingSuccessCondition.PressKey;
	}

	// Token: 0x17000EE3 RID: 3811
	// (get) Token: 0x0600B413 RID: 46099 RVA: 0x002FF6BB File Offset: 0x002FD8BB
	// (set) Token: 0x0600B414 RID: 46100 RVA: 0x002FF6C3 File Offset: 0x002FD8C3
	public override EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EE4 RID: 3812
	// (get) Token: 0x0600B415 RID: 46101 RVA: 0x002FF6CC File Offset: 0x002FD8CC
	// (set) Token: 0x0600B416 RID: 46102 RVA: 0x002FF6D4 File Offset: 0x002FD8D4
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.PressKey;

	// Token: 0x17000EE5 RID: 3813
	// (get) Token: 0x0600B417 RID: 46103 RVA: 0x002FF6DD File Offset: 0x002FD8DD
	// (set) Token: 0x0600B418 RID: 46104 RVA: 0x002FF6E5 File Offset: 0x002FD8E5
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.PressKey;

	// Token: 0x0600B419 RID: 46105 RVA: 0x002FF6F0 File Offset: 0x002FD8F0
	protected override bool CheckFail(IComboTeachingInfo node, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckKeyCondition checkKeyCondition = extra as ICheckKeyCondition;
		if (this.ParamsArray == null || checkKeyCondition == null || checkKeyCondition.ActionType == EComboKeyType.Hold)
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
		return this.ParamsArray[0] == b;
	}

	// Token: 0x0600B41A RID: 46106 RVA: 0x002FF778 File Offset: 0x002FD978
	protected override bool CheckSuccess(IComboTeachingInfo node, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckKeyCondition checkKeyCondition = extra as ICheckKeyCondition;
		if (checkKeyCondition == null || checkKeyCondition.ActionType == EComboKeyType.Hold)
		{
			return false;
		}
		if (this.SuccessParamsArray == null)
		{
			if (checkKeyCondition.ActionType != EComboKeyType.Press)
			{
				return false;
			}
		}
		else if (checkKeyCondition.ActionType != (EComboKeyType)int.Parse(this.SuccessParamsArray[0][0]))
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
		return a == node.ActionInfo;
	}
}
