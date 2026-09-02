using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002511 RID: 9489
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AttrContent : GridProxyAbstract<RecommendItemData>
{
	// Token: 0x060126B2 RID: 75442 RVA: 0x00510964 File Offset: 0x0050EB64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTogOption))
		};
	}

	// Token: 0x060126B3 RID: 75443 RVA: 0x005109F7 File Offset: 0x0050EBF7
	private void OnClickTogOption(EToggleState toggleState)
	{
		if (this.CurrentData == null)
		{
			return;
		}
		if (this.CurrentData.OnSelectCallBack != null)
		{
			this.CurrentData.OnSelectCallBack(this.CurrentData);
		}
	}

	// Token: 0x060126B4 RID: 75444 RVA: 0x00510A28 File Offset: 0x0050EC28
	public override void Refresh(RecommendItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(true);
		base.GetTexture(1).SetUIActive(true);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.AttrId);
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(1), null, null);
		string key = (this.CurrentData.AddType != 2) ? propertyIndexInfo.Value.Name : ((propertyIndexInfo.Value.AnotherName != "") ? propertyIndexInfo.Value.AnotherName : propertyIndexInfo.Value.Name);
		base.GetText(2).ShowTextNew(key);
		base.GetText(3).SetText(data.UsageText, true);
		bool flag = false;
		foreach (VisionSelectRecommendData visionSelectRecommendData in data.CurrentSelectArray)
		{
			if (visionSelectRecommendData.AttrId == data.AttrId && visionSelectRecommendData.AddType == data.AddType)
			{
				flag = true;
				break;
			}
		}
		EToggleState state = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x04008FB2 RID: 36786
	[Nullable(2)]
	private RecommendItemData CurrentData;
}
