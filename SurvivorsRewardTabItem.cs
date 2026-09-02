using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B24 RID: 11044
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRewardTabItem : GridProxyAbstract<SurvivorRewardTaskTabData>
{
	// Token: 0x060160CE RID: 90318 RVA: 0x0061E758 File Offset: 0x0061C958
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTabToggle))
		};
	}

	// Token: 0x060160CF RID: 90319 RVA: 0x0061E7D8 File Offset: 0x0061C9D8
	public void SetToggleState(bool bSelect, bool bFire)
	{
		EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x060160D0 RID: 90320 RVA: 0x0061E7FE File Offset: 0x0061C9FE
	private void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x060160D1 RID: 90321 RVA: 0x0061E810 File Offset: 0x0061CA10
	public void RefreshRedDot()
	{
		SurvivorRewardTaskTabData tabData = this.TabData;
		bool? flag;
		if (tabData == null)
		{
			flag = null;
		}
		else
		{
			Func<SurvivorRewardTaskTabData, bool> refreshRedDot = tabData.RefreshRedDot;
			flag = ((refreshRedDot != null) ? new bool?(refreshRedDot(this.TabData)) : null);
		}
		bool? flag2 = flag;
		bool valueOrDefault = flag2.GetValueOrDefault();
		this.SetRedDotVisible(valueOrDefault);
	}

	// Token: 0x060160D2 RID: 90322 RVA: 0x0061E866 File Offset: 0x0061CA66
	public override void Refresh(SurvivorRewardTaskTabData data, bool isSelected, int gridIndex)
	{
		this.TabData = data;
		if (data.NameTextId != null)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(data.NameTextId);
			}
		}
		this.RefreshRedDot();
	}

	// Token: 0x060160D3 RID: 90323 RVA: 0x0061E895 File Offset: 0x0061CA95
	private void OnTabToggle(EToggleState state)
	{
		SurvivorRewardTaskTabData tabData = this.TabData;
		if (tabData == null)
		{
			return;
		}
		Action<SurvivorRewardTaskTabData> clickedCallback = tabData.ClickedCallback;
		if (clickedCallback == null)
		{
			return;
		}
		clickedCallback(this.TabData);
	}

	// Token: 0x060160D4 RID: 90324 RVA: 0x0061E8B7 File Offset: 0x0061CAB7
	public override object GetKey(SurvivorRewardTaskTabData data, int displayIndex)
	{
		return data.Type;
	}

	// Token: 0x0400A9A2 RID: 43426
	[Nullable(2)]
	private SurvivorRewardTaskTabData TabData;
}
