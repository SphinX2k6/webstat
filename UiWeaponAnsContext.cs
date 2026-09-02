using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C7B RID: 11387
public class UiWeaponAnsContext : UiAnsContextBase
{
	// Token: 0x17001E02 RID: 7682
	// (get) Token: 0x06016D7E RID: 93566 RVA: 0x00656673 File Offset: 0x00654873
	public int Index { get; }

	// Token: 0x17001E03 RID: 7683
	// (get) Token: 0x06016D7F RID: 93567 RVA: 0x0065667B File Offset: 0x0065487B
	public bool ShowMaterialController { get; }

	// Token: 0x17001E04 RID: 7684
	// (get) Token: 0x06016D80 RID: 93568 RVA: 0x00656683 File Offset: 0x00654883
	public bool HideEffect { get; }

	// Token: 0x17001E05 RID: 7685
	// (get) Token: 0x06016D81 RID: 93569 RVA: 0x0065668B File Offset: 0x0065488B
	public FTransform? Transform { get; }

	// Token: 0x17001E06 RID: 7686
	// (get) Token: 0x06016D82 RID: 93570 RVA: 0x00656693 File Offset: 0x00654893
	public FName HangSocketName { get; }

	// Token: 0x06016D83 RID: 93571 RVA: 0x0065669B File Offset: 0x0065489B
	public UiWeaponAnsContext(int index, bool showMaterialController, bool hideEffect, FTransform? transform, FName hangSocketName)
	{
		this.Index = index;
		this.ShowMaterialController = showMaterialController;
		this.HideEffect = hideEffect;
		this.Transform = transform;
		this.HangSocketName = hangSocketName;
	}

	// Token: 0x06016D84 RID: 93572 RVA: 0x006566C8 File Offset: 0x006548C8
	[NullableContext(1)]
	public override bool IsEqual(UiAnsContextBase inAnsContext)
	{
		UiWeaponAnsContext uiWeaponAnsContext = inAnsContext as UiWeaponAnsContext;
		return uiWeaponAnsContext != null && this.Index == uiWeaponAnsContext.Index && this.HangSocketName == uiWeaponAnsContext.HangSocketName;
	}
}
