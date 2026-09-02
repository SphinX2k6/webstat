using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B2F RID: 6959
[NullableContext(1)]
[Nullable(0)]
public class DynamicMaskButton : UiPanelBase
{
	// Token: 0x0600C8B9 RID: 51385 RVA: 0x0035326C File Offset: 0x0035146C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C8BA RID: 51386 RVA: 0x003532F4 File Offset: 0x003514F4
	protected override void OnAfterShow()
	{
		if (this.ChildItem == null || !this.ChildItem.IsValid())
		{
			return;
		}
		FTransformDouble ftransformDouble = this.RootItem.D_K2_GetComponentToWorld().Inverse();
		FVectorDouble fvectorDouble = UKismetMathLibrary.Conv_VectorToVectorDouble(this.ChildItem.RelativeLocation);
		FVectorDouble fvectorDouble2 = this.ChildItem.GetParentAsUIItem().D_K2_GetComponentToWorld().TransformPosition(fvectorDouble);
		FVectorDouble fvectorDouble3 = ftransformDouble.TransformPosition(fvectorDouble2);
		this.ChildItem.SetUIParent(this.RootItem, true);
		FHitResult fhitResult = new FHitResult();
		FVector newLocation = new FVector((float)fvectorDouble3.X, (float)fvectorDouble3.Y, (float)fvectorDouble3.Z);
		this.ChildItem.K2_SetRelativeLocation(newLocation, false, ref fhitResult, false);
	}

	// Token: 0x0600C8BB RID: 51387 RVA: 0x003533A9 File Offset: 0x003515A9
	private void ButtonClick()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction();
	}

	// Token: 0x0600C8BC RID: 51388 RVA: 0x003533BB File Offset: 0x003515BB
	public void SetButtonFunction(Action callback)
	{
		this.ButtonFunction = callback;
	}

	// Token: 0x0600C8BD RID: 51389 RVA: 0x003533C4 File Offset: 0x003515C4
	public UniTask Init(UUIItem parent = null)
	{
		DynamicMaskButton.<Init>d__9 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.parent = parent;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DynamicMaskButton.<Init>d__9>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8BE RID: 51390 RVA: 0x0035340F File Offset: 0x0035160F
	public void SetAttachChildItem(UUIItem uiItem)
	{
		this.ChildItem = uiItem;
		this.OriginalParentItem = uiItem.GetParentAsUIItem();
		this.OriginalRelativeTrans = uiItem.D_GetRelativeTransform();
	}

	// Token: 0x0600C8BF RID: 51391 RVA: 0x00353430 File Offset: 0x00351630
	public void ResetItemParent()
	{
		if (this.ChildItem == null || this.OriginalParentItem == null)
		{
			return;
		}
		this.ChildItem.SetUIParent(this.OriginalParentItem, false);
		FHitResult fhitResult = new FHitResult();
		this.ChildItem.D_K2_SetRelativeTransform(this.OriginalRelativeTrans, false, ref fhitResult, false);
	}

	// Token: 0x04006042 RID: 24642
	private Action ButtonFunction;

	// Token: 0x04006043 RID: 24643
	[Nullable(2)]
	private UUIItem ChildItem;

	// Token: 0x04006044 RID: 24644
	[Nullable(2)]
	private UUIItem OriginalParentItem;

	// Token: 0x04006045 RID: 24645
	private FTransformDouble OriginalRelativeTrans;

	// Token: 0x02007E1F RID: 32287
	[NullableContext(0)]
	private class ECompDefine
	{
		// Token: 0x0402AF43 RID: 175939
		public const int Button = 0;
	}
}
