using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E7 RID: 9191
[NullableContext(1)]
[Nullable(0)]
public class PayShopSwitchItem : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x06011C88 RID: 72840 RVA: 0x004E4078 File Offset: 0x004E2278
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnExtendToggleToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C89 RID: 72841 RVA: 0x004E41C4 File Offset: 0x004E23C4
	public override void Refresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.OnRefresh(data, isSelected, gridIndex);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(false);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06011C8A RID: 72842 RVA: 0x004E4213 File Offset: 0x004E2413
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06011C8B RID: 72843 RVA: 0x004E422C File Offset: 0x004E242C
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06011C8C RID: 72844 RVA: 0x004E4234 File Offset: 0x004E2434
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x06011C8D RID: 72845 RVA: 0x004E4242 File Offset: 0x004E2442
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x06011C8E RID: 72846 RVA: 0x004E425B File Offset: 0x004E245B
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x06011C8F RID: 72847 RVA: 0x004E426D File Offset: 0x004E246D
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon());
		}
	}

	// Token: 0x06011C90 RID: 72848 RVA: 0x004E4288 File Offset: 0x004E2488
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06011C91 RID: 72849 RVA: 0x004E428A File Offset: 0x004E248A
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x06011C92 RID: 72850 RVA: 0x004E4294 File Offset: 0x004E2494
	public void UpdateView(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		base.GetText(0).SetText((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Name : "", true);
		this.RootItem.SetUIActive(payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.Enable);
		this.RefreshSpriteBg(payShopId, tabId);
		this.RefreshTextureBg(payShopId, tabId);
		this.RefreshCountDown(payShopId, tabId);
	}

	// Token: 0x06011C93 RID: 72851 RVA: 0x004E42FC File Offset: 0x004E24FC
	private void RefreshSpriteBg(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		if (payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.SpriteBgPath != "")
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(payShopTabDataByPayShopIdAndTabId.SpriteBgPath);
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(resourcePath, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				if (sprite != null)
				{
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
					if (uiExtendToggleSpriteTransition != null)
					{
						uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_CheckedUnHover, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition2 = base.GetUiExtendToggleSpriteTransition(3);
					if (uiExtendToggleSpriteTransition2 != null)
					{
						uiExtendToggleSpriteTransition2.SetStateSprite(EToggleTransitionState.ETT_CheckedPressed, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition3 = base.GetUiExtendToggleSpriteTransition(3);
					if (uiExtendToggleSpriteTransition3 == null)
					{
						return;
					}
					uiExtendToggleSpriteTransition3.SetStateSprite(EToggleTransitionState.ETT_CheckedHover, sprite, false);
				}
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
		}
	}

	// Token: 0x06011C94 RID: 72852 RVA: 0x004E435C File Offset: 0x004E255C
	private void RefreshTextureBg(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		UUITexture texture = base.GetTexture(4);
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		if (payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.TextureBgPath != "")
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(payShopTabDataByPayShopIdAndTabId.TextureBgPath);
			base.SetTextureByPath(resourcePath, texture, null, null);
			texture.SetUIActive(true);
			return;
		}
		texture.SetUIActive(false);
	}

	// Token: 0x06011C95 RID: 72853 RVA: 0x004E43C8 File Offset: 0x004E25C8
	public void RefreshCountDown(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		UUIItem item = base.GetItem(5);
		UUIText text = base.GetText(6);
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		if (payShopTabDataByPayShopIdAndTabId == null)
		{
			item.SetUIActive(false);
			text.SetText("", true);
			return;
		}
		long beginTime = payShopTabDataByPayShopIdAndTabId.BeginTime;
		long endTime = payShopTabDataByPayShopIdAndTabId.EndTime;
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (serverTime >= (double)beginTime && serverTime <= (double)endTime)
		{
			item.SetUIActive(true);
			double remainTime = (double)endTime - serverTime;
			string countDownTextFormat = Singleton<TimeUtil>.Instance.GetCountDownTextFormat10(remainTime);
			text.SetText(countDownTextFormat, true);
			return;
		}
		item.SetUIActive(false);
		text.SetText("", true);
	}

	// Token: 0x06011C96 RID: 72854 RVA: 0x004E446B File Offset: 0x004E266B
	public void UpdateTitle(string title)
	{
		base.GetText(0).SetText(title, true);
	}

	// Token: 0x06011C97 RID: 72855 RVA: 0x004E447C File Offset: 0x004E267C
	public void BindRedDot(ERedDotName redDotName, int tabId = 0)
	{
		this.UnBindRedDot();
		UUIItem item = base.GetItem(2);
		this.RedDotName = new ERedDotName?(redDotName);
		this.TabId = tabId;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, tabId);
	}

	// Token: 0x06011C98 RID: 72856 RVA: 0x004E44B8 File Offset: 0x004E26B8
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), this.TabId);
			this.RedDotName = null;
			this.TabId = 0;
		}
	}

	// Token: 0x04008B35 RID: 35637
	private ERedDotName? RedDotName;

	// Token: 0x04008B36 RID: 35638
	private int TabId;

	// Token: 0x02008720 RID: 34592
	[NullableContext(0)]
	private class EPayShopSwitchItem
	{
		// Token: 0x0402DB4B RID: 187211
		public const int Name = 0;

		// Token: 0x0402DB4C RID: 187212
		public const int SwitchToggle = 1;

		// Token: 0x0402DB4D RID: 187213
		public const int RedDot = 2;

		// Token: 0x0402DB4E RID: 187214
		public const int SpriteTransitionNum = 3;

		// Token: 0x0402DB4F RID: 187215
		public const int TextureBg = 4;

		// Token: 0x0402DB50 RID: 187216
		public const int CountDownItem = 5;

		// Token: 0x0402DB51 RID: 187217
		public const int CountDownText = 6;
	}
}
