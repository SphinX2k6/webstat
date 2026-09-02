using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001544 RID: 5444
public class ActivityRegressMainTabTitlePanel : UiPanelBase
{
	// Token: 0x060098C4 RID: 39108 RVA: 0x002803E8 File Offset: 0x0027E5E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBackBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060098C5 RID: 39109 RVA: 0x002804F4 File Offset: 0x0027E6F4
	[NullableContext(1)]
	public void UpdateIcon(string iconPath)
	{
		if (!StringUtils.IsEmpty(iconPath))
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, null);
		}
	}

	// Token: 0x060098C6 RID: 39110 RVA: 0x00280524 File Offset: 0x0027E724
	[NullableContext(2)]
	public void UpdateTitle(CommonTabTitleData titleData)
	{
		UUIText text = base.GetText(1);
		if (titleData != null)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleData.TextId, titleData.Args);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x060098C7 RID: 39111 RVA: 0x00280562 File Offset: 0x0027E762
	private void OnBackBtnClick()
	{
		Action onBackBtnCallBack = this.OnBackBtnCallBack;
		if (onBackBtnCallBack == null)
		{
			return;
		}
		onBackBtnCallBack();
	}

	// Token: 0x040046A5 RID: 18085
	[Nullable(2)]
	public Action OnBackBtnCallBack;

	// Token: 0x02007900 RID: 30976
	private class EComponents
	{
		// Token: 0x04029962 RID: 170338
		public const int SprTitleIcon = 0;

		// Token: 0x04029963 RID: 170339
		public const int TxtTitle = 1;

		// Token: 0x04029964 RID: 170340
		public const int BtnHelpInfo = 2;

		// Token: 0x04029965 RID: 170341
		public const int BtnBack = 3;

		// Token: 0x04029966 RID: 170342
		public const int PnlCost = 4;
	}
}
