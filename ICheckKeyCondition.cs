using System;
using CSharpScript.Game.Input;

// Token: 0x0200188B RID: 6283
public interface ICheckKeyCondition : IBaseCheckConditionInfo
{
	// Token: 0x17000EE9 RID: 3817
	// (get) Token: 0x0600B424 RID: 46116
	// (set) Token: 0x0600B425 RID: 46117
	EInputAction ActionKey { get; set; }

	// Token: 0x17000EEA RID: 3818
	// (get) Token: 0x0600B426 RID: 46118
	// (set) Token: 0x0600B427 RID: 46119
	EComboKeyType ActionType { get; set; }

	// Token: 0x17000EEB RID: 3819
	// (get) Token: 0x0600B428 RID: 46120
	// (set) Token: 0x0600B429 RID: 46121
	float? HoldTime { get; set; }
}
