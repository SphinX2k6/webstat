using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016AE RID: 5806
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerTeamSelectPanel : UiPanelBase
{
	// Token: 0x0600A18D RID: 41357 RVA: 0x002A7420 File Offset: 0x002A5620
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A18E RID: 41358 RVA: 0x002A74E8 File Offset: 0x002A56E8
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<WheelTowerTeamSelectItem, int>(base.GetScrollViewWithScrollbar(0), new Func<WheelTowerTeamSelectItem>(this.CreateTeamItem), null, false, null);
		for (int i = 1; i <= 10; i++)
		{
			this.TeamIdList.Add(i);
		}
		this.ScrollView.RefreshByData(this.TeamIdList, null, false);
	}

	// Token: 0x0600A18F RID: 41359 RVA: 0x002A7544 File Offset: 0x002A5744
	public void Refresh()
	{
		int selectedIndex = this.ScrollView.GetSelectedIndex();
		WheelTowerTeamSelectItem scrollItemByIndex = this.ScrollView.GetScrollItemByIndex(selectedIndex);
		if (scrollItemByIndex != null)
		{
			scrollItemByIndex.SetToggleForce(false, true);
		}
		this.ScrollView.RefreshByData(this.TeamIdList, null, false);
	}

	// Token: 0x0600A190 RID: 41360 RVA: 0x002A7589 File Offset: 0x002A5789
	private WheelTowerTeamSelectItem CreateTeamItem()
	{
		return new WheelTowerTeamSelectItem
		{
			OnToggleClickCallback = new Action<int, int>(this.OnTeamSelect)
		};
	}

	// Token: 0x0600A191 RID: 41361 RVA: 0x002A75A4 File Offset: 0x002A57A4
	private void OnTeamSelect(int teamId, int index)
	{
		Action<int> onTeamSelectCallback = this.OnTeamSelectCallback;
		if (onTeamSelectCallback != null)
		{
			onTeamSelectCallback(teamId);
		}
		GenericScrollViewNew<WheelTowerTeamSelectItem, int> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			GenericLayout<WheelTowerTeamSelectItem, int> genericLayout = scrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.RefreshWithoutDataSync();
			}
		}
		GenericScrollViewNew<WheelTowerTeamSelectItem, int> scrollView2 = this.ScrollView;
		if (scrollView2 == null)
		{
			return;
		}
		scrollView2.SelectGridProxy(index, false);
	}

	// Token: 0x0600A192 RID: 41362 RVA: 0x002A75F1 File Offset: 0x002A57F1
	private void OnBtnClick()
	{
		ControllerBase<EditFormationController>.Instance.OpenEditFormationView(false);
	}

	// Token: 0x04004B85 RID: 19333
	[Nullable(2)]
	public Action<int> OnTeamSelectCallback;

	// Token: 0x04004B86 RID: 19334
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<WheelTowerTeamSelectItem, int> ScrollView;

	// Token: 0x04004B87 RID: 19335
	private readonly List<int> TeamIdList = new List<int>();
}
