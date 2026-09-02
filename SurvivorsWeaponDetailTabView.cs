using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B1B RID: 11035
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsWeaponDetailTabView : UiPanelBase
{
	// Token: 0x060160A0 RID: 90272 RVA: 0x0061D7D8 File Offset: 0x0061B9D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickIconMore))
		};
	}

	// Token: 0x060160A1 RID: 90273 RVA: 0x0061D8F4 File Offset: 0x0061BAF4
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsWeaponDetailTabView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsWeaponDetailTabView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060160A2 RID: 90274 RVA: 0x0061D938 File Offset: 0x0061BB38
	private UniTask InitializeWeaponTotalItemList()
	{
		SurvivorsWeaponDetailTabView.<InitializeWeaponTotalItemList>d__10 <InitializeWeaponTotalItemList>d__;
		<InitializeWeaponTotalItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeWeaponTotalItemList>d__.<>4__this = this;
		<InitializeWeaponTotalItemList>d__.<>1__state = -1;
		<InitializeWeaponTotalItemList>d__.<>t__builder.Start<SurvivorsWeaponDetailTabView.<InitializeWeaponTotalItemList>d__10>(ref <InitializeWeaponTotalItemList>d__);
		return <InitializeWeaponTotalItemList>d__.<>t__builder.Task;
	}

	// Token: 0x060160A3 RID: 90275 RVA: 0x0061D97B File Offset: 0x0061BB7B
	private SurvivorsAttributeItem CreateAttributeItemProxy()
	{
		return new SurvivorsAttributeItem();
	}

	// Token: 0x060160A4 RID: 90276 RVA: 0x0061D984 File Offset: 0x0061BB84
	protected override void OnStart()
	{
		this.WeaponEvolveScroll = new GenericScrollViewNew<SurvivorsWeaponDetailItem, int>(base.GetScrollViewWithScrollbar(1), new Func<SurvivorsWeaponDetailItem>(this.CreateWeaponGrid), null, false, null);
		this.WeaponAttributeIconLayout = new GenericLayout<SurvivorsWeaponAttributeIconItem, int>(base.GetHorizontalLayout(7), new Func<SurvivorsWeaponAttributeIconItem>(this.CreateWeaponAttributeIcon), null, false, true);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsRogueWeaponDetailTabViewShow, true);
	}

	// Token: 0x060160A5 RID: 90277 RVA: 0x0061D9E4 File Offset: 0x0061BBE4
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsRogueWeaponDetailTabViewShow, false);
	}

	// Token: 0x060160A6 RID: 90278 RVA: 0x0061D9F7 File Offset: 0x0061BBF7
	private SurvivorsWeaponDetailItem CreateWeaponGrid()
	{
		return new SurvivorsWeaponDetailItem();
	}

	// Token: 0x060160A7 RID: 90279 RVA: 0x0061D9FE File Offset: 0x0061BBFE
	private SurvivorsWeaponAttributeIconItem CreateWeaponAttributeIcon()
	{
		return new SurvivorsWeaponAttributeIconItem();
	}

	// Token: 0x060160A8 RID: 90280 RVA: 0x0061DA08 File Offset: 0x0061BC08
	public void RefreshByData(SurvivorsWeaponGainData weaponData)
	{
		this.WeaponData = weaponData;
		int configId = weaponData.ConfigId;
		int currentEvolveId = weaponData.GetCurrentEvolveId();
		this.RefreshWeaponCard(configId);
		this.RefreshEvolveInfo(configId, currentEvolveId);
		this.RefreshAttributeList(configId, weaponData.Data.Affixs.ToList<int>());
		this.RefreshWeaponTotalList(weaponData.Data.KillMonsterCount);
		this.RefreshAttributeIcon();
	}

	// Token: 0x060160A9 RID: 90281 RVA: 0x0061DA68 File Offset: 0x0061BC68
	public void RefreshWeaponCard(int weaponId)
	{
		SurvivorsRogueWeaponCard survivorsRogueWeaponCard = SurvivorsRogueCardDataFactory.CreateGeneralWeapon(weaponId);
		survivorsRogueWeaponCard.TagVisible = new bool?(false);
		SurvivorsRogueCardBase cardItem = this.CardItem;
		if (cardItem == null)
		{
			return;
		}
		cardItem.Apply(survivorsRogueWeaponCard);
	}

	// Token: 0x060160AA RID: 90282 RVA: 0x0061DA9C File Offset: 0x0061BC9C
	public void RefreshEvolveInfo(int weaponId, int weaponEvolveId)
	{
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponId);
		List<int> weaponEvolveIdList = new List<int>();
		for (int i = 0; i < survivorsWeapon.Value.EvolveIdsLength; i++)
		{
			DicIntInt? dicIntInt = survivorsWeapon.Value.EvolveIds(i);
			if (dicIntInt != null)
			{
				weaponEvolveIdList.Add(dicIntInt.Value.Key);
			}
		}
		GenericScrollViewNew<SurvivorsWeaponDetailItem, int> weaponEvolveScroll = this.WeaponEvolveScroll;
		if (weaponEvolveScroll == null)
		{
			return;
		}
		weaponEvolveScroll.RefreshByDataAsync(weaponEvolveIdList, true).ContinueWith(delegate()
		{
			this.RefreshCurrentEvolve(weaponEvolveIdList, weaponEvolveIdList, weaponEvolveId);
		});
	}

	// Token: 0x060160AB RID: 90283 RVA: 0x0061DB50 File Offset: 0x0061BD50
	public void RefreshCurrentEvolve(List<int> weaponEvolveIdList, List<int> unlockEvolveIdList, int currentEvolveId)
	{
		UUIItem uiitem = null;
		List<SurvivorsWeaponDetailItem> scrollItemList = this.WeaponEvolveScroll.GetScrollItemList();
		for (int i = 0; i < weaponEvolveIdList.Count; i++)
		{
			int num = weaponEvolveIdList[i];
			SurvivorsWeaponDetailItem survivorsWeaponDetailItem = scrollItemList[i];
			bool flag = unlockEvolveIdList.Contains(num);
			survivorsWeaponDetailItem.SetIsLocked(!flag);
			if (num == currentEvolveId)
			{
				uiitem = this.WeaponEvolveScroll.GetItemByIndex(i);
				survivorsWeaponDetailItem.SetIsCurrentState(true);
			}
			else
			{
				survivorsWeaponDetailItem.SetIsCurrentState(false);
			}
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		scrollViewWithScrollbar.ScrollTo(uiitem, true);
	}

	// Token: 0x060160AC RID: 90284 RVA: 0x0061DBD8 File Offset: 0x0061BDD8
	public void RefreshWeaponTotalList(int totalKillCount)
	{
		SurvivorsAttributeItem totalKillItem = this.TotalKillItem;
		if (totalKillItem == null)
		{
			return;
		}
		totalKillItem.SetValue((double)totalKillCount, false, false);
	}

	// Token: 0x060160AD RID: 90285 RVA: 0x0061DBF0 File Offset: 0x0061BDF0
	private void RefreshAttributeList(int weaponId, List<int> weaponAffixs)
	{
		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		foreach (int lvId in weaponAffixs)
		{
			SurvivorsWeaponLv? survivorsWeaponLv = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponLv(lvId);
			double num = dictionary.ContainsKey(survivorsWeaponLv.Value.PropertyId) ? dictionary[survivorsWeaponLv.Value.PropertyId] : 0.0;
			int num2 = survivorsWeaponLv.Value.PropertyValue / 10000;
			dictionary[survivorsWeaponLv.Value.PropertyId] = num + (double)num2;
		}
		SurvivorsRoleGainData roleGainData = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetRoleGainData();
		if (roleGainData != null)
		{
			foreach (int lvId2 in roleGainData.Data.Affixs)
			{
				SurvivorsRoleLv? survivorsRoleLv = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRoleLv(lvId2);
				if (survivorsRoleLv.Value.BuffCategoryType == 2)
				{
					double num3 = dictionary.ContainsKey(survivorsRoleLv.Value.PropertyId) ? dictionary[survivorsRoleLv.Value.PropertyId] : 0.0;
					int num4 = survivorsRoleLv.Value.PropertyValue / 10000;
					dictionary[survivorsRoleLv.Value.PropertyId] = num3 + (double)num4;
				}
			}
		}
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponId);
		HashSet<int> hashSet = new HashSet<int>(survivorsWeapon.Value.GetRecommendPropertyArray());
		List<ISurvivorsAttributeUiData> list = new List<ISurvivorsAttributeUiData>();
		foreach (int num5 in survivorsWeapon.Value.GetPropertyListArray())
		{
			if (dictionary.ContainsKey(num5))
			{
				double value = dictionary[num5];
				list.Add(new SurvivorsAttributeUiData
				{
					AttrId = num5,
					IsRecommend = hashSet.Contains(num5),
					Value = value,
					IsAddition = new bool?(true)
				});
			}
		}
		list.Sort(delegate(ISurvivorsAttributeUiData a, ISurvivorsAttributeUiData b)
		{
			if (a.IsRecommend == b.IsRecommend)
			{
				return a.AttrId - b.AttrId;
			}
			if (!a.IsRecommend)
			{
				return 1;
			}
			return -1;
		});
		this.AttributeScrollView.RefreshByData(list, false, null, false);
	}

	// Token: 0x060160AE RID: 90286 RVA: 0x0061DE84 File Offset: 0x0061C084
	private void RefreshAttributeIcon()
	{
		List<int> list = new List<int>();
		foreach (ISurvivorsWeaponAttributeData survivorsWeaponAttributeData in this.WeaponData.GetWeaponSpecialAttributeList())
		{
			list.Add(survivorsWeaponAttributeData.AttrId);
		}
		if (list.Count > 0)
		{
			int num = (list.Count > 5) ? 5 : list.Count;
			List<int> list2 = new List<int>();
			for (int i = 0; i < num; i++)
			{
				list2.Add(list[i]);
			}
			this.WeaponAttributeIconLayout.RefreshByData(list2, null, false);
		}
		base.GetItem(6).SetUIActive(list.Count > 0);
	}

	// Token: 0x060160AF RID: 90287 RVA: 0x0061DF50 File Offset: 0x0061C150
	private void OnClickIconMore()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsWeaponAttributeView, this.WeaponData, null);
	}

	// Token: 0x0400A96D RID: 43373
	private const int ATTRIBUTE_TOTAL_KILL_COUNT_ID = 267;

	// Token: 0x0400A96E RID: 43374
	private const int SPECIAL_ATTRIBUTE_COUNT = 5;

	// Token: 0x0400A96F RID: 43375
	[Nullable(2)]
	private SurvivorsWeaponGainData WeaponData;

	// Token: 0x0400A970 RID: 43376
	[Nullable(2)]
	private SurvivorsRogueCardBase CardItem;

	// Token: 0x0400A971 RID: 43377
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<SurvivorsWeaponDetailItem, int> WeaponEvolveScroll;

	// Token: 0x0400A972 RID: 43378
	[Nullable(2)]
	private SurvivorsAttributeItem TotalKillItem;

	// Token: 0x0400A973 RID: 43379
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<SurvivorsAttributeItem, ISurvivorsAttributeUiData> AttributeScrollView;

	// Token: 0x0400A974 RID: 43380
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SurvivorsWeaponAttributeIconItem, int> WeaponAttributeIconLayout;
}
