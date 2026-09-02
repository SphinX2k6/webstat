using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200253F RID: 9535
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionNewRecommendVisionView : GridProxyAbstract<VisionNewRecommendVisionItemData>
{
	// Token: 0x060128DA RID: 75994 RVA: 0x0051CB9C File Offset: 0x0051AD9C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x060128DB RID: 75995 RVA: 0x0051CC0C File Offset: 0x0051AE0C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendVisionView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendVisionView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060128DC RID: 75996 RVA: 0x0051CC4F File Offset: 0x0051AE4F
	private void SelectedCallback()
	{
		Action<int, VisionNewRecommendVisionItemData> onSelectedCallback = this.OnSelectedCallback;
		if (onSelectedCallback == null)
		{
			return;
		}
		onSelectedCallback(base.GridIndex, this.CurrentData);
	}

	// Token: 0x060128DD RID: 75997 RVA: 0x0051CC70 File Offset: 0x0051AE70
	public override void Refresh(VisionNewRecommendVisionItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		VisionNewRecommendVisionItem visionItem = this.VisionItem;
		if (visionItem != null)
		{
			visionItem.SetData(data);
		}
		this.RefreshUsageText(data.Usage);
		this.RefreshNotObtainedPanel(data.Obtained);
		VisionNewRecommendVisionItem visionItem2 = this.VisionItem;
		if (visionItem2 == null)
		{
			return;
		}
		visionItem2.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false);
	}

	// Token: 0x060128DE RID: 75998 RVA: 0x0051CCC8 File Offset: 0x0051AEC8
	private void RefreshUsageText(int usage)
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(usage > 0);
		}
		if (usage > 0)
		{
			float num = (float)(usage - usage % 10) / 100f;
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString("F1") + "%", true);
		}
	}

	// Token: 0x060128DF RID: 75999 RVA: 0x0051CD25 File Offset: 0x0051AF25
	private void RefreshNotObtainedPanel(bool obtained)
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!obtained);
	}

	// Token: 0x060128E0 RID: 76000 RVA: 0x0051CD3C File Offset: 0x0051AF3C
	public override void OnSelected(bool fireEvent)
	{
		VisionNewRecommendVisionItem visionItem = this.VisionItem;
		if (visionItem == null)
		{
			return;
		}
		visionItem.SetToggleState(EToggleState.ETT_Checked, fireEvent);
	}

	// Token: 0x060128E1 RID: 76001 RVA: 0x0051CD50 File Offset: 0x0051AF50
	public override void OnDeselected(bool fireEvent)
	{
		VisionNewRecommendVisionItem visionItem = this.VisionItem;
		if (visionItem == null)
		{
			return;
		}
		visionItem.SetToggleState(EToggleState.ETT_UnChecked, fireEvent);
	}

	// Token: 0x060128E2 RID: 76002 RVA: 0x0051CD64 File Offset: 0x0051AF64
	public override object GetKey(VisionNewRecommendVisionItemData data, int displayIndex)
	{
		return data.VisionMonsterId;
	}

	// Token: 0x04009095 RID: 37013
	[Nullable(2)]
	private VisionNewRecommendVisionItem VisionItem;

	// Token: 0x04009096 RID: 37014
	[Nullable(2)]
	private VisionNewRecommendVisionItemData CurrentData;

	// Token: 0x04009097 RID: 37015
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, VisionNewRecommendVisionItemData> OnSelectedCallback;

	// Token: 0x02008869 RID: 34921
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E141 RID: 188737
		VisionItem,
		// Token: 0x0402E142 RID: 188738
		PnlNoHave,
		// Token: 0x0402E143 RID: 188739
		PnlUsage,
		// Token: 0x0402E144 RID: 188740
		UsageText
	}
}
