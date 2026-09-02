using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011D1 RID: 4561
public class BabelTowerBattleTopPanel : BattleVisibleChildView
{
	// Token: 0x06007855 RID: 30805 RVA: 0x001F7EEC File Offset: 0x001F60EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnStarButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007856 RID: 30806 RVA: 0x001F7F92 File Offset: 0x001F6192
	[NullableContext(1)]
	public override void Initialize(object param = null)
	{
		base.Initialize(param);
		base.InitChildType(EBattleUiChild.MiniMap);
		base.SetVisible(1, false);
	}

	// Token: 0x06007857 RID: 30807 RVA: 0x001F7FAA File Offset: 0x001F61AA
	public override void Reset()
	{
		base.Reset();
	}

	// Token: 0x06007858 RID: 30808 RVA: 0x001F7FB2 File Offset: 0x001F61B2
	private void AddEventListeners()
	{
		if (this.HasAddEventListener)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnBabelActivityInstInfoUpdate, new Action(this.OnBabelTowerBattleTopPanelUpdate));
		this.HasAddEventListener = true;
	}

	// Token: 0x06007859 RID: 30809 RVA: 0x001F7FE0 File Offset: 0x001F61E0
	private void RemoveEventListeners()
	{
		if (!this.HasAddEventListener)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBabelActivityInstInfoUpdate, new Action(this.OnBabelTowerBattleTopPanelUpdate));
		this.HasAddEventListener = false;
	}

	// Token: 0x0600785A RID: 30810 RVA: 0x001F8010 File Offset: 0x001F6210
	private void OnStarButtonClick()
	{
		List<IBabelTowerBuffItemData> list = new List<IBabelTowerBuffItemData>();
		List<IBabelTowerBuffItemData> list2 = new List<IBabelTowerBuffItemData>();
		BabelTowerInstanceData currentChallengeInstData = ModelBase<BabelTowerModel>.Instance.CurrentChallengeInstData;
		List<int> list3 = (currentChallengeInstData != null) ? currentChallengeInstData.BuffSelection : null;
		if (list3 != null)
		{
			foreach (int id in list3)
			{
				BabelTowerBuffItemData item = new BabelTowerBuffItemData
				{
					Id = id,
					IsDeTerm = false,
					CanClick = true,
					ShowStar = new bool?(false)
				};
				list.Add(item);
			}
		}
		List<int> list4 = (currentChallengeInstData != null) ? currentChallengeInstData.DeTermIdList : null;
		if (list4 != null)
		{
			foreach (int id2 in list4)
			{
				BabelTowerBuffItemData item2 = new BabelTowerBuffItemData
				{
					Id = id2,
					IsDeTerm = true,
					CanClick = true,
					ShowStar = new bool?(true)
				};
				list2.Add(item2);
			}
		}
		BabelTowerBuffViewData param = new BabelTowerBuffViewData
		{
			BuffDataList = list,
			DeTermDataList = list2
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerBuffView, param, null);
	}

	// Token: 0x0600785B RID: 30811 RVA: 0x001F8154 File Offset: 0x001F6354
	private void OnBabelTowerBattleTopPanelUpdate()
	{
		int curStarNum = ModelBase<BabelTowerModel>.Instance.GetCurStarNum();
		this.Update(curStarNum);
	}

	// Token: 0x0600785C RID: 30812 RVA: 0x001F8173 File Offset: 0x001F6373
	public void Update(int starNum)
	{
		this.StarNum = starNum;
		this.Refresh();
	}

	// Token: 0x0600785D RID: 30813 RVA: 0x001F8182 File Offset: 0x001F6382
	public void Refresh()
	{
		base.GetText(1).SetText(this.StarNum.ToString(), true);
	}

	// Token: 0x0600785E RID: 30814 RVA: 0x001F819C File Offset: 0x001F639C
	public void StartShow()
	{
		BabelTowerInstanceData currentChallengeInstData = ModelBase<BabelTowerModel>.Instance.CurrentChallengeInstData;
		int starNum = (currentChallengeInstData != null) ? currentChallengeInstData.CurStarNum : 0;
		this.Update(starNum);
		base.SetVisible(1, true);
	}

	// Token: 0x0600785F RID: 30815 RVA: 0x001F81CF File Offset: 0x001F63CF
	public void EndShow()
	{
		base.SetVisible(1, false);
	}

	// Token: 0x06007860 RID: 30816 RVA: 0x001F81D9 File Offset: 0x001F63D9
	protected override void OnShowBattleChildView()
	{
		this.AddEventListeners();
	}

	// Token: 0x06007861 RID: 30817 RVA: 0x001F81E1 File Offset: 0x001F63E1
	protected override void OnHideBattleChildView()
	{
		this.RemoveEventListeners();
	}

	// Token: 0x04003A22 RID: 14882
	private int StarNum;

	// Token: 0x04003A23 RID: 14883
	private bool HasAddEventListener;

	// Token: 0x02007529 RID: 29993
	private enum EVisibleReason
	{
		// Token: 0x0402871A RID: 165658
		Default = 1
	}

	// Token: 0x0200752A RID: 29994
	private class EComponents
	{
		// Token: 0x0402871B RID: 165659
		public const int StarButton = 0;

		// Token: 0x0402871C RID: 165660
		public const int StarNumText = 1;
	}
}
