using System;
using CSharpScript.Game.Input;

// Token: 0x0200188C RID: 6284
public class CheckKeyCondition : IBaseCheckConditionInfo, ICheckKeyCondition
{
	// Token: 0x17000EEC RID: 3820
	// (get) Token: 0x0600B42A RID: 46122 RVA: 0x002FF9D0 File Offset: 0x002FDBD0
	// (set) Token: 0x0600B42B RID: 46123 RVA: 0x002FF9D8 File Offset: 0x002FDBD8
	public EInputAction ActionKey { get; set; }

	// Token: 0x17000EED RID: 3821
	// (get) Token: 0x0600B42C RID: 46124 RVA: 0x002FF9E1 File Offset: 0x002FDBE1
	// (set) Token: 0x0600B42D RID: 46125 RVA: 0x002FF9E9 File Offset: 0x002FDBE9
	public EComboKeyType ActionType { get; set; }

	// Token: 0x17000EEE RID: 3822
	// (get) Token: 0x0600B42E RID: 46126 RVA: 0x002FF9F2 File Offset: 0x002FDBF2
	// (set) Token: 0x0600B42F RID: 46127 RVA: 0x002FF9FA File Offset: 0x002FDBFA
	public float? HoldTime { get; set; }
}
