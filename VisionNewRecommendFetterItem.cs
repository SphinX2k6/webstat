using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002537 RID: 9527
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionNewRecommendFetterItem : GridProxyAbstract<VisionFetterRecommendInfo>
{
	// Token: 0x06012891 RID: 75921 RVA: 0x0051B5E8 File Offset: 0x005197E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x06012892 RID: 75922 RVA: 0x0051B668 File Offset: 0x00519868
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		extendToggle.bLockStateOnSelect = true;
		this.ElementLayout = new GenericLayout<FetterIconItem, IVisionNewRecommendFetterItemData>(base.GetLayoutBase(1), new Func<FetterIconItem>(this.InitElementItem), null, false, true);
	}

	// Token: 0x06012893 RID: 75923 RVA: 0x0051B6B4 File Offset: 0x005198B4
	private FetterIconItem InitElementItem()
	{
		return new FetterIconItem();
	}

	// Token: 0x06012894 RID: 75924 RVA: 0x0051B6BB File Offset: 0x005198BB
	public override void Refresh(VisionFetterRecommendInfo data, bool isSelected, int gridIndex)
	{
		this.ElementLayout.RefreshByData(data.BuildFetterItemDataList(), null, false);
		this.RefreshUsage(data.GetUsageText());
	}

	// Token: 0x06012895 RID: 75925 RVA: 0x0051B6DC File Offset: 0x005198DC
	private void RefreshUsage(string txt)
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(txt, true);
	}

	// Token: 0x06012896 RID: 75926 RVA: 0x0051B6F1 File Offset: 0x005198F1
	private void OnToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onSelectedCallback = this.OnSelectedCallback;
			if (onSelectedCallback == null)
			{
				return;
			}
			onSelectedCallback(base.GridIndex);
		}
	}

	// Token: 0x06012897 RID: 75927 RVA: 0x0051B70D File Offset: 0x0051990D
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true, fireEvent);
	}

	// Token: 0x06012898 RID: 75928 RVA: 0x0051B717 File Offset: 0x00519917
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false, fireEvent);
	}

	// Token: 0x06012899 RID: 75929 RVA: 0x0051B721 File Offset: 0x00519921
	private void SetToggleState(bool isSelected, bool fireEvent = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601289A RID: 75930 RVA: 0x0051B73E File Offset: 0x0051993E
	public override object GetKey(VisionFetterRecommendInfo data, int displayIndex)
	{
		return data.GetPlanId();
	}

	// Token: 0x04009074 RID: 36980
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FetterIconItem, IVisionNewRecommendFetterItemData> ElementLayout;

	// Token: 0x04009075 RID: 36981
	[Nullable(2)]
	public Action<int> OnSelectedCallback;

	// Token: 0x0200885C RID: 34908
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E0F2 RID: 188658
		Toggle,
		// Token: 0x0402E0F3 RID: 188659
		ElementLayout,
		// Token: 0x0402E0F4 RID: 188660
		UsageText
	}
}
