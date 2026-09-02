using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C18 RID: 11288
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBdBuffStrengthenView : UiViewBase
{
	// Token: 0x0601693D RID: 92477 RVA: 0x006442CD File Offset: 0x006424CD
	public TrapDefenseBdBuffStrengthenView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601693E RID: 92478 RVA: 0x006442D8 File Offset: 0x006424D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601693F RID: 92479 RVA: 0x006443E4 File Offset: 0x006425E4
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdBuffStrengthenView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdBuffStrengthenView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016940 RID: 92480 RVA: 0x00644427 File Offset: 0x00642627
	protected override void OnStart()
	{
	}

	// Token: 0x06016941 RID: 92481 RVA: 0x00644429 File Offset: 0x00642629
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x06016942 RID: 92482 RVA: 0x0064442B File Offset: 0x0064262B
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x06016943 RID: 92483 RVA: 0x0064442D File Offset: 0x0064262D
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x06016944 RID: 92484 RVA: 0x00644435 File Offset: 0x00642635
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06016945 RID: 92485 RVA: 0x00644437 File Offset: 0x00642637
	protected override void OnAfterDestroy()
	{
		ModelBase<TrapDefenseModel>.Instance.BdBuffSelectProcessFinish();
	}

	// Token: 0x06016946 RID: 92486 RVA: 0x00644443 File Offset: 0x00642643
	private void OnClickBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016947 RID: 92487 RVA: 0x0064444C File Offset: 0x0064264C
	public void UpdateData()
	{
		if (this.BdBuffData == null)
		{
			return;
		}
		this.PanelBdBuffDescLeft.SetActive(true);
		this.PanelBdBuffDescRight.SetActive(true);
		this.PanelBdBuffDescLeft.UpdateDataStrengthenModeBefore(this.BdBuffData);
		this.PanelBdBuffDescRight.UpdateDataStrengthenModeAfter(this.BdBuffData);
		this.UpdateBdProgressItem();
	}

	// Token: 0x06016948 RID: 92488 RVA: 0x006444A4 File Offset: 0x006426A4
	private void UpdateBdProgressItem()
	{
		TrapDefenseBdData belongBdData = this.BdBuffData.GetBelongBdData();
		bool flag = !belongBdData.IsZeroBdType();
		this.BdProgressItem.SetActive(flag);
		if (flag)
		{
			if (ModelBase<TrapDefenseModel>.Instance.RougeModeData.IsCheckBdProgress)
			{
				this.BdProgressItem.RefreshCheckProgress(belongBdData);
				return;
			}
			this.BdProgressItem.RefreshItem(belongBdData);
		}
	}

	// Token: 0x06016949 RID: 92489 RVA: 0x00644500 File Offset: 0x00642700
	protected override void OnAfterPlayStartSequence()
	{
		this.CheckBdUpStageEffect().Forget();
	}

	// Token: 0x0601694A RID: 92490 RVA: 0x00644510 File Offset: 0x00642710
	public UniTask CheckBdUpStageEffect()
	{
		TrapDefenseBdBuffStrengthenView.<CheckBdUpStageEffect>d__18 <CheckBdUpStageEffect>d__;
		<CheckBdUpStageEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckBdUpStageEffect>d__.<>4__this = this;
		<CheckBdUpStageEffect>d__.<>1__state = -1;
		<CheckBdUpStageEffect>d__.<>t__builder.Start<TrapDefenseBdBuffStrengthenView.<CheckBdUpStageEffect>d__18>(ref <CheckBdUpStageEffect>d__);
		return <CheckBdUpStageEffect>d__.<>t__builder.Task;
	}

	// Token: 0x0400AE5F RID: 44639
	public TrapDefenseBdSumBuffDescPanel PanelBdBuffDescLeft;

	// Token: 0x0400AE60 RID: 44640
	public TrapDefenseBdSumBuffDescPanel PanelBdBuffDescRight;

	// Token: 0x0400AE61 RID: 44641
	public TrapDefenseBdBuffData BdBuffData;

	// Token: 0x0400AE62 RID: 44642
	public TrapDefenseBdBuffSelectBdItem BdProgressItem;

	// Token: 0x02008F31 RID: 36657
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0403016F RID: 196975
		public const int BtnClose = 0;

		// Token: 0x04030170 RID: 196976
		public const int ItemBuffDescLeft = 1;

		// Token: 0x04030171 RID: 196977
		public const int ItemArrow = 2;

		// Token: 0x04030172 RID: 196978
		public const int ItemBuffDescRight = 3;

		// Token: 0x04030173 RID: 196979
		public const int ItemBdProgress = 4;
	}
}
