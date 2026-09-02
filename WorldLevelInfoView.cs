using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D65 RID: 11621
public class WorldLevelInfoView : UiTickViewBase
{
	// Token: 0x17001EF0 RID: 7920
	// (get) Token: 0x0601775F RID: 96095 RVA: 0x00680D97 File Offset: 0x0067EF97
	// (set) Token: 0x06017760 RID: 96096 RVA: 0x00680DA0 File Offset: 0x0067EFA0
	public bool CanShowInteractCd
	{
		get
		{
			return this.ShowInteractCd;
		}
		set
		{
			if (this.ShowInteractCd != value)
			{
				this.ShowInteractCd = value;
				UUIItem item = base.GetItem(8);
				bool uiactive;
				if (!this.ShowInteractCd)
				{
					int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
					int? conditionLevel = this.ConditionLevel;
					uiactive = (originWorldLevel >= conditionLevel.GetValueOrDefault() & conditionLevel != null);
				}
				else
				{
					uiactive = false;
				}
				item.SetUIActive(uiactive);
				base.GetItem(4).SetUIActive(this.ShowInteractCd);
			}
		}
	}

	// Token: 0x06017761 RID: 96097 RVA: 0x00680E0B File Offset: 0x0067F00B
	[NullableContext(1)]
	public WorldLevelInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06017762 RID: 96098 RVA: 0x00680E14 File Offset: 0x0067F014
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnWorldLevelBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06017763 RID: 96099 RVA: 0x00680FA4 File Offset: 0x0067F1A4
	protected override void OnStart()
	{
		this.WorldLevelChangeCd = ConfigBase<WorldLevelConfig>.Instance.GetCommonValue("world_level_change_cd");
		this.ConditionLevel = ConfigBase<WorldLevelConfig>.Instance.GetCommonValue("world_level_change_conditon_level");
		base.GetItem(3).SetUIActive(true);
		base.GetItem(8).SetUIActive(true);
		this.SetTitleText();
		this.SetDescribeText();
		this.InitInteractNode();
	}

	// Token: 0x06017764 RID: 96100 RVA: 0x00681007 File Offset: 0x0067F207
	protected override void OnTick(float delta)
	{
		this.UpdateInteract();
	}

	// Token: 0x06017765 RID: 96101 RVA: 0x0068100F File Offset: 0x0067F20F
	private void SetTitleText()
	{
		base.GetText(0).SetText(ModelBase<WorldLevelModel>.Instance.WorldLevelMultilingualText, true);
	}

	// Token: 0x06017766 RID: 96102 RVA: 0x00681028 File Offset: 0x0067F228
	private void SetDescribeText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("WorldLevelIntro");
		base.GetText(2).SetText(textById, true);
	}

	// Token: 0x06017767 RID: 96103 RVA: 0x00681054 File Offset: 0x0067F254
	private void InitInteractNode()
	{
		int interactTimeToLast = this.GetInteractTimeToLast();
		bool flag = Math.Max(this.WorldLevelChangeCd.Value - interactTimeToLast, 0) > 0;
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		int? conditionLevel = this.ConditionLevel;
		if ((originWorldLevel < conditionLevel.GetValueOrDefault() & conditionLevel != null) || flag)
		{
			base.GetItem(8).SetUIActive(false);
			return;
		}
		this.UpdateInteract();
	}

	// Token: 0x06017768 RID: 96104 RVA: 0x006810BC File Offset: 0x0067F2BC
	private void UpdateInteract()
	{
		int interactTimeToLast = this.GetInteractTimeToLast();
		int num = Math.Max(this.WorldLevelChangeCd.Value - interactTimeToLast, 0);
		this.CanShowInteractCd = (num > 0);
		if (this.CanShowInteractCd)
		{
			base.GetText(6).SetText(ShopUtils.FormatTime(num), true);
			return;
		}
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		string newText = "";
		if (curWorldLevel == originWorldLevel)
		{
			ModelBase<WorldLevelModel>.Instance.WorldLevelChangeTarget = curWorldLevel - 1;
			newText = ConfigBase<TextConfig>.Instance.GetTextById("WorldLevelDown");
		}
		else if (curWorldLevel < originWorldLevel)
		{
			ModelBase<WorldLevelModel>.Instance.WorldLevelChangeTarget = curWorldLevel + 1;
			newText = ConfigBase<TextConfig>.Instance.GetTextById("WorldLevelRestore");
		}
		base.GetText(7).SetText(newText, true);
	}

	// Token: 0x06017769 RID: 96105 RVA: 0x0068117C File Offset: 0x0067F37C
	private int GetInteractTimeToLast()
	{
		return (int)Singleton<TimeUtil>.Instance.GetServerTime() - ModelBase<WorldLevelModel>.Instance.LastChangeWorldLevelTimeStamp;
	}

	// Token: 0x0601776A RID: 96106 RVA: 0x00681194 File Offset: 0x0067F394
	private void OnWorldLevelBtnClick()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("OnlineCantChangeLevel", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelInfoView, null);
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldLevelChangeConfirmView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldLevelChangeConfirmView, null, null);
		}
	}

	// Token: 0x0400B3F0 RID: 46064
	private bool ShowInteractCd;

	// Token: 0x0400B3F1 RID: 46065
	private int? ConditionLevel;

	// Token: 0x0400B3F2 RID: 46066
	private int? WorldLevelChangeCd;
}
