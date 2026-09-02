using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002044 RID: 8260
public class PhantomSmartDiscardPopupActivatePanel : UiPanelBase
{
	// Token: 0x0600FBA7 RID: 64423 RVA: 0x00451688 File Offset: 0x0044F888
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FBA8 RID: 64424 RVA: 0x00451714 File Offset: 0x0044F914
	protected override void OnStart()
	{
		string key = ModelBase<FunctionModel>.Instance.IsOpen(10096) ? "PrefabTextItem_18455432_Text" : "PhantomManagementLocked_Tips";
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(key);
	}

	// Token: 0x020083EC RID: 33772
	private enum EPanel
	{
		// Token: 0x0402CB88 RID: 183176
		SpriteLock,
		// Token: 0x0402CB89 RID: 183177
		TxtActivate,
		// Token: 0x0402CB8A RID: 183178
		BtnFunctionA
	}
}
