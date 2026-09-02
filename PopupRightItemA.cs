using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D70 RID: 11632
public class PopupRightItemA : PopupTypeRightItem
{
	// Token: 0x060177A6 RID: 96166 RVA: 0x00681C28 File Offset: 0x0067FE28
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060177A7 RID: 96167 RVA: 0x00681CF0 File Offset: 0x0067FEF0
	protected override UniTask OnBeforeStartAsync()
	{
		PopupRightItemA.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PopupRightItemA.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060177A8 RID: 96168 RVA: 0x00681D33 File Offset: 0x0067FF33
	[NullableContext(1)]
	public void SetTitleIcon(string resourceId)
	{
		PopupCaption popupCaption = this.PopupCaption;
		if (popupCaption == null)
		{
			return;
		}
		popupCaption.SetTitleIcon(resourceId);
	}

	// Token: 0x060177A9 RID: 96169 RVA: 0x00681D46 File Offset: 0x0067FF46
	[NullableContext(1)]
	public void SetTitleLocalTxt(string txtId)
	{
		PopupCaption popupCaption = this.PopupCaption;
		if (popupCaption == null)
		{
			return;
		}
		popupCaption.SetTitleLocalTxt(txtId);
	}

	// Token: 0x0400B409 RID: 46089
	[Nullable(2)]
	private PopupCaption PopupCaption;

	// Token: 0x02009040 RID: 36928
	public static class EComponents
	{
		// Token: 0x04030626 RID: 198182
		public const int BackBtn = 0;

		// Token: 0x04030627 RID: 198183
		public const int Content = 1;

		// Token: 0x04030628 RID: 198184
		public const int Caption = 2;
	}
}
