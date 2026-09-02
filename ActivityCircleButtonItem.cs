using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001601 RID: 5633
[NullableContext(1)]
[Nullable(0)]
public class ActivityCircleButtonItem : UiPanelBase
{
	// Token: 0x06009ECA RID: 40650 RVA: 0x002988E8 File Offset: 0x00296AE8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009ECB RID: 40651 RVA: 0x002989AF File Offset: 0x00296BAF
	public void SetOnClick(Action onClick)
	{
		this.OnClickInternal = onClick;
	}

	// Token: 0x06009ECC RID: 40652 RVA: 0x002989B8 File Offset: 0x00296BB8
	public void SetSubText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x06009ECD RID: 40653 RVA: 0x002989C8 File Offset: 0x00296BC8
	public void SetRedDotVisible(bool value)
	{
		base.GetItem(2).SetUIActive(value);
	}

	// Token: 0x06009ECE RID: 40654 RVA: 0x002989D8 File Offset: 0x00296BD8
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x06009ECF RID: 40655 RVA: 0x00298A20 File Offset: 0x00296C20
	public void BindGivenUid(ERedDotName redDotName, int uId)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x06009ED0 RID: 40656 RVA: 0x00298A60 File Offset: 0x00296C60
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), uId);
		}
	}

	// Token: 0x06009ED1 RID: 40657 RVA: 0x00298A8C File Offset: 0x00296C8C
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x06009ED2 RID: 40658 RVA: 0x00298ABC File Offset: 0x00296CBC
	private void OnClick()
	{
		this.OnClickInternal();
	}

	// Token: 0x040048F7 RID: 18679
	private Action OnClickInternal = delegate()
	{
	};

	// Token: 0x040048F8 RID: 18680
	private ERedDotName? RedDotName;

	// Token: 0x020079C1 RID: 31169
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029CDC RID: 171228
		public const int BtnCircle = 0;

		// Token: 0x04029CDD RID: 171229
		public const int TextSub = 1;

		// Token: 0x04029CDE RID: 171230
		public const int ItemRedDot = 2;
	}
}
