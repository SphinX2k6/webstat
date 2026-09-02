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

// Token: 0x02002CEF RID: 11503
public class WeaponBreachSuccessView : UiViewBase
{
	// Token: 0x06017319 RID: 95001 RVA: 0x0066D6E4 File Offset: 0x0066B8E4
	[NullableContext(1)]
	public WeaponBreachSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601731A RID: 95002 RVA: 0x0066D6F0 File Offset: 0x0066B8F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
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
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601731B RID: 95003 RVA: 0x0066D7D8 File Offset: 0x0066B9D8
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponBreachSuccessView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponBreachSuccessView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601731C RID: 95004 RVA: 0x0066D81B File Offset: 0x0066BA1B
	[NullableContext(1)]
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x0601731D RID: 95005 RVA: 0x0066D822 File Offset: 0x0066BA22
	protected override void OnAfterPlayStartSequence()
	{
		CSharpScript.Game.Module.RoleUi.StarItem successStarItem = this.SuccessStarItem;
		if (successStarItem != null)
		{
			successStarItem.PlayActiveSequence();
		}
		this.UiViewSequence.PlaySequencePurely("Loop", false, false);
	}

	// Token: 0x0601731E RID: 95006 RVA: 0x0066D847 File Offset: 0x0066BA47
	private void ConfirmClick()
	{
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.WeaponBreach);
		if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0601731F RID: 95007 RVA: 0x0066D870 File Offset: 0x0066BA70
	protected UniTask UpdateStar(int breachLevel, int maxLevel)
	{
		WeaponBreachSuccessView.<UpdateStar>d__10 <UpdateStar>d__;
		<UpdateStar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateStar>d__.<>4__this = this;
		<UpdateStar>d__.breachLevel = breachLevel;
		<UpdateStar>d__.maxLevel = maxLevel;
		<UpdateStar>d__.<>1__state = -1;
		<UpdateStar>d__.<>t__builder.Start<WeaponBreachSuccessView.<UpdateStar>d__10>(ref <UpdateStar>d__);
		return <UpdateStar>d__.<>t__builder.Task;
	}

	// Token: 0x0400B273 RID: 45683
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x0400B274 RID: 45684
	[Nullable(2)]
	protected CSharpScript.Game.Module.RoleUi.StarItem SuccessStarItem;

	// Token: 0x0400B275 RID: 45685
	private int WeaponIncId;

	// Token: 0x02008FB5 RID: 36789
	private enum EComponent
	{
		// Token: 0x040303D0 RID: 197584
		StarHorizontalLayout,
		// Token: 0x040303D1 RID: 197585
		ConfirmButton,
		// Token: 0x040303D2 RID: 197586
		LastLevelText,
		// Token: 0x040303D3 RID: 197587
		CurLevelText
	}
}
