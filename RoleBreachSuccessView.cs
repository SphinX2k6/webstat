using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020027B0 RID: 10160
[NullableContext(1)]
[Nullable(0)]
public class RoleBreachSuccessView : UiViewBase
{
	// Token: 0x06014120 RID: 82208 RVA: 0x0059A64F File Offset: 0x0059884F
	public RoleBreachSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014121 RID: 82209 RVA: 0x0059A664 File Offset: 0x00598864
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnMaskClickInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014122 RID: 82210 RVA: 0x0059A74C File Offset: 0x0059894C
	protected void OnMaskClickInternal()
	{
		Action onMaskClick = this.OnMaskClick;
		if (onMaskClick == null)
		{
			return;
		}
		onMaskClick();
	}

	// Token: 0x06014123 RID: 82211 RVA: 0x0059A760 File Offset: 0x00598960
	protected override UniTask OnBeforeStartAsync()
	{
		RoleBreachSuccessView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleBreachSuccessView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014124 RID: 82212 RVA: 0x0059A7A3 File Offset: 0x005989A3
	protected override void OnAfterPlayStartSequence()
	{
		CSharpScript.Game.Module.RoleUi.StarItem successStarItem = this.SuccessStarItem;
		if (successStarItem == null)
		{
			return;
		}
		successStarItem.PlayActiveSequence();
	}

	// Token: 0x06014125 RID: 82213 RVA: 0x0059A7B5 File Offset: 0x005989B5
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x06014126 RID: 82214 RVA: 0x0059A7BC File Offset: 0x005989BC
	protected UniTask UpdateStar(int breachLevel, int maxLevel)
	{
		RoleBreachSuccessView.<UpdateStar>d__12 <UpdateStar>d__;
		<UpdateStar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateStar>d__.<>4__this = this;
		<UpdateStar>d__.breachLevel = breachLevel;
		<UpdateStar>d__.maxLevel = maxLevel;
		<UpdateStar>d__.<>1__state = -1;
		<UpdateStar>d__.<>t__builder.Start<RoleBreachSuccessView.<UpdateStar>d__12>(ref <UpdateStar>d__);
		return <UpdateStar>d__.<>t__builder.Task;
	}

	// Token: 0x04009C51 RID: 40017
	private int RoleId;

	// Token: 0x04009C52 RID: 40018
	[Nullable(2)]
	private Action OnMaskClick;

	// Token: 0x04009C53 RID: 40019
	[Nullable(2)]
	protected CSharpScript.Game.Module.RoleUi.StarItem SuccessStarItem;

	// Token: 0x04009C54 RID: 40020
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x04009C55 RID: 40021
	protected List<CSharpScript.Game.Module.RoleUi.StarItem> StarList = new List<CSharpScript.Game.Module.RoleUi.StarItem>();

	// Token: 0x02008B6F RID: 35695
	[NullableContext(0)]
	public enum ERoleBreachSuccessViewDefine
	{
		// Token: 0x0402F019 RID: 192537
		StarHorizontalLayout,
		// Token: 0x0402F01A RID: 192538
		MaskBtn,
		// Token: 0x0402F01B RID: 192539
		CurLevelText,
		// Token: 0x0402F01C RID: 192540
		MaxLevelText
	}
}
