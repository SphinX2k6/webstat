using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200272B RID: 10027
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsRewardTabItem : GridProxyAbstract<RacingBetsGroupRewardData>
{
	// Token: 0x06013C66 RID: 80998 RVA: 0x00580724 File Offset: 0x0057E924
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTabToggle))
		};
	}

	// Token: 0x06013C67 RID: 80999 RVA: 0x005807A1 File Offset: 0x0057E9A1
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteToggleChange));
	}

	// Token: 0x06013C68 RID: 81000 RVA: 0x005807C5 File Offset: 0x0057E9C5
	public override void Refresh(RacingBetsGroupRewardData data, bool isSelected, int gridIndex)
	{
		this.GroupRewardData = data;
		this.RefreshItem();
	}

	// Token: 0x06013C69 RID: 81001 RVA: 0x005807D4 File Offset: 0x0057E9D4
	public void RefreshItem()
	{
		if (this.GroupRewardData == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(this.TabNameKeyList[this.GroupRewardData.Id - 1]);
		}
		this.RefreshRedDot();
	}

	// Token: 0x06013C6A RID: 81002 RVA: 0x0058080C File Offset: 0x0057EA0C
	private void RefreshRedDot()
	{
		bool uiactive = false;
		using (List<RacingBetsRewardData>.Enumerator enumerator = this.GroupRewardData.GetRewardDataList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanReceiveReward())
				{
					uiactive = true;
					break;
				}
			}
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06013C6B RID: 81003 RVA: 0x0058087C File Offset: 0x0057EA7C
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06013C6C RID: 81004 RVA: 0x00580893 File Offset: 0x0057EA93
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06013C6D RID: 81005 RVA: 0x005808AA File Offset: 0x0057EAAA
	public void BindClickToggleCallBack(Action<RacingBetsGroupRewardData> toggleCallBack)
	{
		this.ClickToggleCallBack = toggleCallBack;
	}

	// Token: 0x06013C6E RID: 81006 RVA: 0x005808B3 File Offset: 0x0057EAB3
	private void OnClickTabToggle(EToggleState toggleState)
	{
		Action<RacingBetsGroupRewardData> clickToggleCallBack = this.ClickToggleCallBack;
		if (clickToggleCallBack == null)
		{
			return;
		}
		clickToggleCallBack(this.GroupRewardData);
	}

	// Token: 0x06013C6F RID: 81007 RVA: 0x005808CB File Offset: 0x0057EACB
	private bool CanExecuteToggleChange()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		return extendToggle == null || extendToggle.GetToggleState() != EToggleState.ETT_Checked;
	}

	// Token: 0x040099F5 RID: 39413
	private RacingBetsGroupRewardData GroupRewardData;

	// Token: 0x040099F6 RID: 39414
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<RacingBetsGroupRewardData> ClickToggleCallBack;

	// Token: 0x040099F7 RID: 39415
	private readonly string[] TabNameKeyList = new string[]
	{
		"Dango_RewardPage_RewardType_1",
		"Dango_CurrencyPage_DailyTask",
		"Dango_RewardPage_RewardType_2"
	};

	// Token: 0x02008AD2 RID: 35538
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ECD5 RID: 191701
		public const int TabToggle = 0;

		// Token: 0x0402ECD6 RID: 191702
		public const int TabName = 1;

		// Token: 0x0402ECD7 RID: 191703
		public const int RedDotItem = 2;
	}
}
