using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.Consume;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018BB RID: 6331
[NullableContext(1)]
[Nullable(0)]
public class CommonMultipleConsumeComponent : UiPanelBase
{
	// Token: 0x0600B5E6 RID: 46566 RVA: 0x00305FE0 File Offset: 0x003041E0
	public CommonMultipleConsumeComponent(UUIItem uiItem, CommonMultipleConsumeFunction consumeFunction, bool needConditionFilter = true, EUiViewName? belongView = null)
	{
		this.ConsumeFunction = consumeFunction;
		this.NeedConditionFilter = needConditionFilter;
		this.BelongView = belongView;
		this.ConsumeList = new List<TCommonMultipleConsumeData>();
		this.MaxCount = 0;
		this.EnoughMoney = true;
		this.QualityId = 0;
		this.IsNeedShowMaterial = true;
		this.ButtonText = "WeaponLevelUpText";
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B5E7 RID: 46567 RVA: 0x00306048 File Offset: 0x00304248
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.AutoClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.ConditionClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B5E8 RID: 46568 RVA: 0x003062C6 File Offset: 0x003044C6
	private void AutoClick()
	{
		if (this.ConsumeFunction.AutoFunction != null)
		{
			this.ConsumeFunction.AutoFunction(this.QualityId);
		}
	}

	// Token: 0x0600B5E9 RID: 46569 RVA: 0x003062EB File Offset: 0x003044EB
	private void ConditionClick()
	{
		this.CommonConditionFilterComponent.UpdateComponent(this.QualityId);
	}

	// Token: 0x0600B5EA RID: 46570 RVA: 0x00306300 File Offset: 0x00304500
	protected override void OnStart()
	{
		this.StrengthItem = new ButtonItem(base.GetItem(7));
		this.StrengthItem.SetFunction(delegate(int data)
		{
			TCommonMultipleConsumeFunction strengthFunction = this.ConsumeFunction.StrengthFunction;
			if (strengthFunction == null)
			{
				return;
			}
			strengthFunction(data);
		});
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(4);
		AUIBaseActor gridActor = base.GetItem(8).GetOwner() as AUIBaseActor;
		this.LoopScrollView = new LoopScrollView<ConsumeItem, TCommonMultipleConsumeData>(loopScrollViewComponent, gridActor, new Func<ConsumeItem>(this.InitItem), false);
		base.GetButton(9).RootUIComp.Get().SetUIActive(this.NeedConditionFilter);
		if (this.NeedConditionFilter)
		{
			this.CommonConditionFilterComponent = new CommonConditionFilterComponent(base.GetItem(11), new CSharpScript.Game.Module.Common.Consume.TCommonConditionFilterFunction(this.ConditionFunction));
			this.CommonConditionFilterComponent.RefreshQualityList(ConfigBase<CommonConfig>.Instance.GetItemQualityList());
			this.CommonConditionFilterComponent.SetActive(false);
		}
		this.MaxCount = ConfigBase<WeaponConfig>.Instance.GetMaterialItemMaxCount();
	}

	// Token: 0x0600B5EB RID: 46571 RVA: 0x003063E2 File Offset: 0x003045E2
	private void ConditionFunction(int qualityId, string text)
	{
		this.QualityId = qualityId;
		base.GetText(10).ShowTextNew(text);
		if (this.ConditionFilterFunction != null)
		{
			this.ConditionFilterFunction(qualityId);
		}
	}

	// Token: 0x0600B5EC RID: 46572 RVA: 0x0030640D File Offset: 0x0030460D
	public void RefreshConditionFilter(int qualityId, string text)
	{
		this.QualityId = qualityId;
		base.GetText(10).ShowTextNew(text);
	}

	// Token: 0x0600B5ED RID: 46573 RVA: 0x00306424 File Offset: 0x00304624
	private ConsumeItem InitItem()
	{
		ConsumeItem consumeItem = new ConsumeItem(null, this.BelongView);
		consumeItem.SetButtonFunction(delegate(int? incId, int? itemId)
		{
			TCommonMultipleConsumeFunctionWithInt materialItemFunction = this.ConsumeFunction.MaterialItemFunction;
			if (materialItemFunction == null)
			{
				return;
			}
			materialItemFunction(incId, itemId);
		});
		return consumeItem;
	}

	// Token: 0x0600B5EE RID: 46574 RVA: 0x00306444 File Offset: 0x00304644
	private TCommonMultipleConsumeData UpdateItem(int gridIndex)
	{
		return this.ConsumeList[gridIndex];
	}

	// Token: 0x0600B5EF RID: 46575 RVA: 0x00306452 File Offset: 0x00304652
	protected override void OnBeforeDestroy()
	{
		if (this.StrengthItem != null)
		{
			this.StrengthItem.Destroy(null);
			this.StrengthItem = null;
		}
		if (this.CommonConditionFilterComponent != null)
		{
			this.CommonConditionFilterComponent.Destroy(null);
			this.CommonConditionFilterComponent = null;
		}
	}

	// Token: 0x0600B5F0 RID: 46576 RVA: 0x0030648C File Offset: 0x0030468C
	public void UpdateComponent(int moneyId, int costCount, List<TCommonMultipleConsumeData> consumeList)
	{
		this.SetMaxState(false);
		this.ConsumeList = consumeList;
		this.LoopScrollView.ReloadProxyData(new Func<int, TCommonMultipleConsumeData>(this.UpdateItem), this.MaxCount, true, false);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "WeaponMaterialLengthText", new <>z__ReadOnlyArray<object>(new object[]
		{
			consumeList.Count,
			this.MaxCount
		}));
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(3);
		int playerMoney = ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(moneyId);
		this.EnoughMoney = UiComponentUtil.SetMoneyState(text, text2, costCount, playerMoney);
	}

	// Token: 0x0600B5F1 RID: 46577 RVA: 0x00306530 File Offset: 0x00304730
	public void SetMaxState(bool inMax)
	{
		base.GetItem(12).SetUIActive(!inMax);
		if (this.IsNeedShowMaterial)
		{
			base.GetItem(13).SetUIActive(!inMax);
		}
		this.SetStrengthItemEnable(!inMax);
		if (inMax)
		{
			this.SetStrengthItemText("LevelUpMax");
			return;
		}
		this.SetStrengthItemText(this.ButtonText);
	}

	// Token: 0x0600B5F2 RID: 46578 RVA: 0x0030658C File Offset: 0x0030478C
	public void SetStrengthItemText(string text)
	{
		this.StrengthItem.SetLocalText(text, Array.Empty<object>());
	}

	// Token: 0x0600B5F3 RID: 46579 RVA: 0x0030659F File Offset: 0x0030479F
	public void SetStrengthTextCode(string text)
	{
		this.ButtonText = text;
	}

	// Token: 0x0600B5F4 RID: 46580 RVA: 0x003065A8 File Offset: 0x003047A8
	public void SetStrengthItemEnable(bool state)
	{
		this.StrengthItem.SetEnableClick(state);
	}

	// Token: 0x0600B5F5 RID: 46581 RVA: 0x003065B6 File Offset: 0x003047B6
	public int GetConsumeListSize()
	{
		return this.ConsumeList.Count;
	}

	// Token: 0x0600B5F6 RID: 46582 RVA: 0x003065C3 File Offset: 0x003047C3
	public bool GetEnoughMoney()
	{
		return this.EnoughMoney;
	}

	// Token: 0x0600B5F7 RID: 46583 RVA: 0x003065CB File Offset: 0x003047CB
	public void SetIsNeedShowMaterial(bool isNeed)
	{
		this.IsNeedShowMaterial = isNeed;
	}

	// Token: 0x0600B5F8 RID: 46584 RVA: 0x003065D4 File Offset: 0x003047D4
	public void ShowMaterialItem(bool show)
	{
		base.GetItem(13).SetUIActive(show);
	}

	// Token: 0x0600B5F9 RID: 46585 RVA: 0x003065E4 File Offset: 0x003047E4
	public void ShowConditionViewItem(bool show)
	{
		base.GetItem(11).SetUIActive(show);
	}

	// Token: 0x0600B5FA RID: 46586 RVA: 0x003065F4 File Offset: 0x003047F4
	public void SetIsNeedShowTitleLayout(bool isNeed)
	{
		base.GetItem(14).SetUIActive(isNeed);
	}

	// Token: 0x0600B5FB RID: 46587 RVA: 0x00306604 File Offset: 0x00304804
	public void SetMaxCount(int count)
	{
		this.MaxCount = count;
	}

	// Token: 0x0600B5FC RID: 46588 RVA: 0x00306610 File Offset: 0x00304810
	public void SetConsumeTexture(int itemId)
	{
		base.SetItemIcon(base.GetTexture(0), itemId, null, null);
		base.SetItemIcon(base.GetTexture(2), itemId, null, null);
	}

	// Token: 0x0600B5FD RID: 46589 RVA: 0x0030664D File Offset: 0x0030484D
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public LoopScrollView<ConsumeItem, TCommonMultipleConsumeData> GetSelfLoopScroll()
	{
		return this.LoopScrollView;
	}

	// Token: 0x0600B5FE RID: 46590 RVA: 0x00306655 File Offset: 0x00304855
	public void SetConditionFilterFunction(global::TCommonConditionFilterFunction filterFunc)
	{
		this.ConditionFilterFunction = filterFunc;
	}

	// Token: 0x040055A7 RID: 21927
	[Nullable(2)]
	protected ButtonItem StrengthItem;

	// Token: 0x040055A8 RID: 21928
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected LoopScrollView<ConsumeItem, TCommonMultipleConsumeData> LoopScrollView;

	// Token: 0x040055A9 RID: 21929
	protected List<TCommonMultipleConsumeData> ConsumeList;

	// Token: 0x040055AA RID: 21930
	[Nullable(2)]
	protected CommonConditionFilterComponent CommonConditionFilterComponent;

	// Token: 0x040055AB RID: 21931
	protected int MaxCount;

	// Token: 0x040055AC RID: 21932
	protected bool EnoughMoney;

	// Token: 0x040055AD RID: 21933
	protected int QualityId;

	// Token: 0x040055AE RID: 21934
	private bool IsNeedShowMaterial;

	// Token: 0x040055AF RID: 21935
	private string ButtonText;

	// Token: 0x040055B0 RID: 21936
	[Nullable(2)]
	private global::TCommonConditionFilterFunction ConditionFilterFunction;

	// Token: 0x040055B1 RID: 21937
	protected CommonMultipleConsumeFunction ConsumeFunction;

	// Token: 0x040055B2 RID: 21938
	public bool NeedConditionFilter;

	// Token: 0x040055B3 RID: 21939
	public EUiViewName? BelongView;

	// Token: 0x02007C3A RID: 31802
	[NullableContext(0)]
	private class ECommonMultipleConsumeComponent
	{
		// Token: 0x0402A6CA RID: 173770
		public const int ConsumeTexture = 0;

		// Token: 0x0402A6CB RID: 173771
		public const int ConsumeText = 1;

		// Token: 0x0402A6CC RID: 173772
		public const int OwnTexture = 2;

		// Token: 0x0402A6CD RID: 173773
		public const int OwnText = 3;

		// Token: 0x0402A6CE RID: 173774
		public const int LoopScrollView = 4;

		// Token: 0x0402A6CF RID: 173775
		public const int AutoButton = 5;

		// Token: 0x0402A6D0 RID: 173776
		public const int AddMaterialText = 6;

		// Token: 0x0402A6D1 RID: 173777
		public const int StrengthItem = 7;

		// Token: 0x0402A6D2 RID: 173778
		public const int MaterialItem = 8;

		// Token: 0x0402A6D3 RID: 173779
		public const int ConditionButton = 9;

		// Token: 0x0402A6D4 RID: 173780
		public const int ConditionText = 10;

		// Token: 0x0402A6D5 RID: 173781
		public const int ConditionViewItem = 11;

		// Token: 0x0402A6D6 RID: 173782
		public const int CostRootItem = 12;

		// Token: 0x0402A6D7 RID: 173783
		public const int MaterialRootItem = 13;

		// Token: 0x0402A6D8 RID: 173784
		public const int TitleLayoutItem = 14;
	}
}
