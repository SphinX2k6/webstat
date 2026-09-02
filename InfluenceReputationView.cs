using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FE6 RID: 8166
[NullableContext(1)]
[Nullable(0)]
public class InfluenceReputationView : UiViewBase
{
	// Token: 0x0600F66A RID: 63082 RVA: 0x00437527 File Offset: 0x00435727
	public InfluenceReputationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F66B RID: 63083 RVA: 0x00437548 File Offset: 0x00435748
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 6;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.SearchClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.SwitchClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.LeftArrowClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.RightArrowClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.DisActiveClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F66C RID: 63084 RVA: 0x004377EC File Offset: 0x004359EC
	private void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F66D RID: 63085 RVA: 0x004377F5 File Offset: 0x004359F5
	private void SearchClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InfluenceSearchView, this.CurrentCountryId, null);
	}

	// Token: 0x0600F66E RID: 63086 RVA: 0x00437812 File Offset: 0x00435A12
	private void SwitchClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InfluenceAreaSelectView, this.CurrentCountryId, null);
	}

	// Token: 0x0600F66F RID: 63087 RVA: 0x00437830 File Offset: 0x00435A30
	private void LeftArrowClick()
	{
		UUIItem uuiitem = this.ScrollView.ContentItem.Get();
		float width = uuiitem.GetWidth();
		float num = Math.Abs(uuiitem.GetAnchorOffsetX()) + this.ScrollView.ScrollWidth;
		int num2 = this.InfluenceList.Length;
		if (num > width)
		{
			this.ScrollView.ScrollToRight(num2 - 2);
			return;
		}
		float num3 = width / (float)num2;
		int num4;
		if (num % num3 < 10f)
		{
			num4 = (int)Math.Floor((double)(num / num3)) - 1 - 1;
		}
		else
		{
			num4 = (int)Math.Floor((double)(num / num3)) - 1;
		}
		this.ScrollView.ScrollToRight(num4);
	}

	// Token: 0x0600F670 RID: 63088 RVA: 0x004378D4 File Offset: 0x00435AD4
	private void RightArrowClick()
	{
		UUIItem uuiitem = this.ScrollView.ContentItem.Get();
		float width = uuiitem.GetWidth();
		float num = Math.Abs(uuiitem.GetAnchorOffsetX());
		if (num < 0f)
		{
			this.ScrollView.ScrollToLeft(1);
		}
		int num2 = this.InfluenceList.Length;
		float num3 = width / (float)num2;
		float num4 = num % num3;
		int num5;
		if (num3 - num4 < 10f)
		{
			num5 = (int)Math.Floor((double)(num / num3)) + 1 + 1;
		}
		else
		{
			num5 = (int)Math.Floor((double)(num / num3)) + 1;
		}
		this.ScrollView.ScrollToLeft(num5);
	}

	// Token: 0x0600F671 RID: 63089 RVA: 0x00437974 File Offset: 0x00435B74
	private void DisActiveClick()
	{
		this.ShowHideContentDisActiveButton(false);
		if (this.SelectedIndex != null)
		{
			this.ScrollView.GetScrollItemByKey(this.SelectedIndex.Value).SetDisActiveToggleState();
			this.SelectedIndex = null;
		}
	}

	// Token: 0x0600F672 RID: 63090 RVA: 0x004379C1 File Offset: 0x00435BC1
	protected override void OnBeforeCreate()
	{
		this.CurrentCountryId = (int)this.OpenParam;
	}

	// Token: 0x0600F673 RID: 63091 RVA: 0x004379D4 File Offset: 0x00435BD4
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<InfluenceDisplayItem>(base.GetScrollViewWithScrollbar(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<InfluenceDisplayItem>(this.InitItem), null);
		this.ScrollView.BindScrollValueChange(new Action<FVector2D>(this.ScrollValueChange));
		this.ScrollView.BindLateUpdate(new Action<float>(this.LateUpdate));
		string playerStand = ModelBase<PlayerInfoModel>.Instance.GetPlayerStand();
		base.SetTextureByPath(playerStand, base.GetTexture(6), null, null);
		this.LeftArrow = base.GetButton(2).RootUIComp.Get();
		this.RightArrow = base.GetButton(3).RootUIComp.Get();
		this.LeftArrow.SetUIActive(false);
		this.RightArrow.SetUIActive(false);
		this.LeftArrowActive = false;
		this.RightArrowActive = false;
	}

	// Token: 0x0600F674 RID: 63092 RVA: 0x00437AAC File Offset: 0x00435CAC
	private ILayoutItem<InfluenceDisplayItem> InitItem(object influenceId, UUIItem uiItem, int index)
	{
		InfluenceDisplayItem influenceDisplayItem = new InfluenceDisplayItem(uiItem);
		influenceDisplayItem.UpdateItem((int)influenceId, this.CurrentCountryId);
		influenceDisplayItem.SetToggleFunction(new TToggleFunction(this.ToggleCallBack));
		influenceDisplayItem.SetIndex(index);
		return new LayoutItem<InfluenceDisplayItem>
		{
			Key = index,
			Value = influenceDisplayItem
		};
	}

	// Token: 0x0600F675 RID: 63093 RVA: 0x00437B04 File Offset: 0x00435D04
	private void ToggleCallBack(EToggleState state, int index)
	{
		if (state == EToggleState.ETT_UnChecked)
		{
			int? selectedIndex = this.SelectedIndex;
			if (selectedIndex.GetValueOrDefault() == index & selectedIndex != null)
			{
				this.SelectedIndex = null;
				this.RefreshArrow();
				this.ShowHideContentDisActiveButton(false);
			}
			return;
		}
		int? selectedIndex2 = this.SelectedIndex;
		this.SelectedIndex = new int?(index);
		if (selectedIndex2 != null)
		{
			this.ScrollView.GetScrollItemByKey(selectedIndex2.Value).SetDisActiveToggleState();
		}
		else
		{
			this.RefreshArrow();
		}
		this.ScrollToDirty = true;
		this.ShowHideContentDisActiveButton(true);
	}

	// Token: 0x0600F676 RID: 63094 RVA: 0x00437B9C File Offset: 0x00435D9C
	private void ScrollValueChange(FVector2D progress)
	{
		if (!this.IsExpand)
		{
			return;
		}
		float num = Singleton<MathUtils>.Instance.Clamp(progress.X, 0f, 1f);
		if (this.ScrollValueX == num)
		{
			return;
		}
		this.ScrollValueX = num;
		this.RefreshArrow();
	}

	// Token: 0x0600F677 RID: 63095 RVA: 0x00437BE4 File Offset: 0x00435DE4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshInfluencePanel, new Action<int>(this.RefreshPanel));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.SearchInfluence, new Action<int, int>(this.SearchInfluence));
	}

	// Token: 0x0600F678 RID: 63096 RVA: 0x00437C1E File Offset: 0x00435E1E
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshInfluencePanel, new Action<int>(this.RefreshPanel));
		Singleton<EventSystem>.Instance.Remove(EEventName.SearchInfluence, new Action<int, int>(this.SearchInfluence));
	}

	// Token: 0x0600F679 RID: 63097 RVA: 0x00437C58 File Offset: 0x00435E58
	private void RefreshPanel(int countryId)
	{
		this.CurrentCountryId = countryId;
		this.RefreshView();
	}

	// Token: 0x0600F67A RID: 63098 RVA: 0x00437C67 File Offset: 0x00435E67
	private void SearchInfluence(int influenceId, int countryId)
	{
		this.CurrentCountryId = countryId;
		this.RefreshView();
		this.SelectInfluence(influenceId);
	}

	// Token: 0x0600F67B RID: 63099 RVA: 0x00437C7D File Offset: 0x00435E7D
	protected override void OnAfterShow()
	{
		this.RefreshView();
	}

	// Token: 0x0600F67C RID: 63100 RVA: 0x00437C85 File Offset: 0x00435E85
	protected override void OnBeforeDestroy()
	{
		this.ScrollView.ClearChildren();
		this.ScrollView = null;
		this.RightArrow = null;
		this.LeftArrow = null;
	}

	// Token: 0x0600F67D RID: 63101 RVA: 0x00437CA8 File Offset: 0x00435EA8
	private void RefreshView()
	{
		Country? countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(this.CurrentCountryId);
		if (countryConfig == null)
		{
			return;
		}
		Country value = countryConfig.Value;
		List<int> list = new List<int>();
		foreach (int num in value.Influences())
		{
			if (num != 0)
			{
				list.Add(num);
			}
		}
		this.InfluenceList = list.ToArray();
		this.RefreshScrollView();
		this.RefreshCountryName(value.Title);
		this.RefreshUnLock();
		this.RefreshSwitchRedDot();
		this.ShowHideContentDisActiveButton(false);
	}

	// Token: 0x0600F67E RID: 63102 RVA: 0x00437D3C File Offset: 0x00435F3C
	private void SelectInfluence(int influenceId)
	{
		int num = Array.IndexOf<int>(this.InfluenceList, influenceId);
		this.ScrollView.GetScrollItemByKey(num).SetToggleState(EToggleState.ETT_Checked, true);
	}

	// Token: 0x0600F67F RID: 63103 RVA: 0x00437D70 File Offset: 0x00435F70
	private void RefreshScrollView()
	{
		this.SelectedIndex = null;
		this.ScrollView.RefreshByData<int>(this.InfluenceList.ToList<int>(), null);
		this.RefreshArrowDirty = true;
	}

	// Token: 0x0600F680 RID: 63104 RVA: 0x00437DAF File Offset: 0x00435FAF
	private void RefreshCountryName(string title)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), title, Array.Empty<object>());
	}

	// Token: 0x0600F681 RID: 63105 RVA: 0x00437DC8 File Offset: 0x00435FC8
	private void RefreshUnLock()
	{
		int num = 0;
		using (Dictionary<object, InfluenceDisplayItem>.ValueCollection.Enumerator enumerator = this.ScrollView.GetScrollItemMap().Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsUnLock())
				{
					num++;
				}
			}
		}
		base.GetText(8).SetText(num.ToString(), true);
		base.GetText(9).SetText(this.InfluenceList.Length.ToString(), true);
	}

	// Token: 0x0600F682 RID: 63106 RVA: 0x00437E5C File Offset: 0x0043605C
	private void RefreshSwitchRedDot()
	{
		bool uiactive = ModelBase<InfluenceReputationModel>.Instance.HasRedDotExcludeCurrentCountry(this.CurrentCountryId);
		base.GetItem(11).SetUIActive(uiactive);
	}

	// Token: 0x0600F683 RID: 63107 RVA: 0x00437E88 File Offset: 0x00436088
	private void RefreshArrow()
	{
		if (!this.IsExpand || this.SelectedIndex != null)
		{
			if (this.LeftArrowActive)
			{
				this.LeftArrowActive = false;
				this.LeftArrow.SetUIActive(false);
			}
			if (this.RightArrowActive)
			{
				this.RightArrowActive = false;
				this.RightArrow.SetUIActive(false);
			}
			return;
		}
		bool flag = this.ScrollValueX < 0.95f;
		if (this.LeftArrowActive != flag)
		{
			this.LeftArrowActive = flag;
			this.LeftArrow.SetUIActive(flag);
		}
		bool flag2 = this.ScrollValueX > 0.05f;
		if (this.RightArrowActive != flag2)
		{
			this.RightArrowActive = flag2;
			this.RightArrow.SetUIActive(flag2);
		}
	}

	// Token: 0x0600F684 RID: 63108 RVA: 0x00437F38 File Offset: 0x00436138
	private void ShowHideContentDisActiveButton(bool bShow)
	{
		base.GetButton(10).RootUIComp.Get().SetUIActive(bShow);
	}

	// Token: 0x0600F685 RID: 63109 RVA: 0x00437F60 File Offset: 0x00436160
	private void ScrollTo()
	{
		int count = this.ScrollView.GetScrollItemMap().Count;
		int? selectedIndex = this.SelectedIndex;
		int num = count - 1;
		if (selectedIndex.GetValueOrDefault() == num & selectedIndex != null)
		{
			this.ScrollView.ScrollToLeft(this.SelectedIndex.Value - 1);
			return;
		}
		this.ScrollView.ScrollToLeft(this.SelectedIndex.Value);
	}

	// Token: 0x0600F686 RID: 63110 RVA: 0x00437FD4 File Offset: 0x004361D4
	private void LateUpdate(float deltaTime)
	{
		if (this.ScrollToDirty)
		{
			this.ScrollToDirty = false;
			this.ScrollTo();
		}
		if (this.RefreshArrowDirty)
		{
			this.RefreshArrowDirty = false;
			this.IsExpand = this.ScrollView.IsExpand;
			this.RefreshArrow();
		}
	}

	// Token: 0x04007719 RID: 30489
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<InfluenceDisplayItem> ScrollView;

	// Token: 0x0400771A RID: 30490
	private int CurrentCountryId;

	// Token: 0x0400771B RID: 30491
	private int? SelectedIndex = new int?(0);

	// Token: 0x0400771C RID: 30492
	private float ScrollValueX;

	// Token: 0x0400771D RID: 30493
	private bool IsExpand;

	// Token: 0x0400771E RID: 30494
	private bool LeftArrowActive;

	// Token: 0x0400771F RID: 30495
	private bool RightArrowActive;

	// Token: 0x04007720 RID: 30496
	[Nullable(2)]
	private UUIItem LeftArrow;

	// Token: 0x04007721 RID: 30497
	[Nullable(2)]
	private UUIItem RightArrow;

	// Token: 0x04007722 RID: 30498
	private int[] InfluenceList = new int[0];

	// Token: 0x04007723 RID: 30499
	private bool ScrollToDirty;

	// Token: 0x04007724 RID: 30500
	private bool RefreshArrowDirty;

	// Token: 0x02008365 RID: 33637
	[NullableContext(0)]
	private enum EInfluenceReputationView
	{
		// Token: 0x0402C909 RID: 182537
		CloseButton,
		// Token: 0x0402C90A RID: 182538
		InfluenceScrollView,
		// Token: 0x0402C90B RID: 182539
		LeftArrow,
		// Token: 0x0402C90C RID: 182540
		RightArrow,
		// Token: 0x0402C90D RID: 182541
		InfluenceSwitch,
		// Token: 0x0402C90E RID: 182542
		InfluenceSearch,
		// Token: 0x0402C90F RID: 182543
		CharacterTexture,
		// Token: 0x0402C910 RID: 182544
		CountryName,
		// Token: 0x0402C911 RID: 182545
		InfluenceUnLockText,
		// Token: 0x0402C912 RID: 182546
		InfluenceAllText,
		// Token: 0x0402C913 RID: 182547
		ContentDisActiveButton,
		// Token: 0x0402C914 RID: 182548
		SwitchRedDot
	}
}
