using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200134A RID: 4938
[NullableContext(1)]
[Nullable(0)]
public class LifePointDrawDetailView : UiViewBase
{
	// Token: 0x060086F0 RID: 34544 RVA: 0x00238469 File Offset: 0x00236669
	public LifePointDrawDetailView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060086F1 RID: 34545 RVA: 0x00238474 File Offset: 0x00236674
	protected unsafe override void OnRegisterComponent()
	{
		this.LifePointDrawDetailViewModel = (this.OpenParam as LifePointDrawViewModel);
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		if (lifePointDrawDetailViewModel != null)
		{
			lifePointDrawDetailViewModel.RegisterView(this);
		}
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060086F2 RID: 34546 RVA: 0x00238648 File Offset: 0x00236848
	private void OnClickBtn()
	{
		LifePointDrawActivityController instance = ControllerBase<LifePointDrawActivityController>.Instance;
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		int? num;
		if (lifePointDrawDetailViewModel == null)
		{
			num = null;
		}
		else
		{
			LifePointDrawActivityData lifePointDrawActivityData = lifePointDrawDetailViewModel.LifePointDrawActivityData;
			num = ((lifePointDrawActivityData != null) ? new int?(lifePointDrawActivityData.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		LifePointDrawViewModel lifePointDrawDetailViewModel2 = this.LifePointDrawDetailViewModel;
		instance.RequestStartChallenge(valueOrDefault, (lifePointDrawDetailViewModel2 != null) ? lifePointDrawDetailViewModel2.GetCurrentChallengeId() : 0);
	}

	// Token: 0x060086F3 RID: 34547 RVA: 0x002386AC File Offset: 0x002368AC
	protected override UniTask OnBeforeStartAsync()
	{
		LifePointDrawDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LifePointDrawDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060086F4 RID: 34548 RVA: 0x002386EF File Offset: 0x002368EF
	private LifePointDrawDetailItem CreateChallengeItem()
	{
		LifePointDrawDetailItem lifePointDrawDetailItem = new LifePointDrawDetailItem();
		lifePointDrawDetailItem.SetModel(this.LifePointDrawDetailViewModel);
		return lifePointDrawDetailItem;
	}

	// Token: 0x060086F5 RID: 34549 RVA: 0x00238702 File Offset: 0x00236902
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060086F6 RID: 34550 RVA: 0x0023870C File Offset: 0x0023690C
	public void RefreshLayout(List<int> list)
	{
		GenericLayout<LifePointDrawDetailItem, int> challengeLayout = this.ChallengeLayout;
		if (challengeLayout != null)
		{
			challengeLayout.RefreshByData(list, null, false);
		}
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(1);
		if (verticalLayout == null)
		{
			return;
		}
		verticalLayout.RootUIComp.Get().SetUIActive(list.Count > 1);
	}

	// Token: 0x060086F7 RID: 34551 RVA: 0x00238754 File Offset: 0x00236954
	public void RefreshRewardLayout(List<TItem> list)
	{
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x060086F8 RID: 34552 RVA: 0x00238769 File Offset: 0x00236969
	protected override void OnBeforeShow()
	{
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		if (lifePointDrawDetailViewModel == null)
		{
			return;
		}
		lifePointDrawDetailViewModel.OnShowView();
	}

	// Token: 0x060086F9 RID: 34553 RVA: 0x0023877B File Offset: 0x0023697B
	public void ShowRightUpTitle(string title)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), title, Array.Empty<object>());
	}

	// Token: 0x060086FA RID: 34554 RVA: 0x00238794 File Offset: 0x00236994
	public void ShowDescText(string desc)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), desc, Array.Empty<object>());
	}

	// Token: 0x060086FB RID: 34555 RVA: 0x002387B0 File Offset: 0x002369B0
	public void RefreshLevelNumSprite(string sprite)
	{
		this.SetSpriteByPath(sprite, base.GetSprite(8), false, null, null);
	}

	// Token: 0x060086FC RID: 34556 RVA: 0x002387D8 File Offset: 0x002369D8
	public void RefreshDifficultTexture(string texture)
	{
		base.SetTextureByPath(texture, base.GetTexture(7), null, null);
	}

	// Token: 0x060086FD RID: 34557 RVA: 0x002387FD File Offset: 0x002369FD
	public void PlaySwitchSequence()
	{
		base.PlaySequence("Switch", null, false);
	}

	// Token: 0x04003FAD RID: 16301
	[Nullable(2)]
	private LifePointDrawViewModel LifePointDrawDetailViewModel;

	// Token: 0x04003FAE RID: 16302
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003FAF RID: 16303
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<LifePointDrawDetailItem, int> ChallengeLayout;

	// Token: 0x04003FB0 RID: 16304
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x020076EB RID: 30443
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028F40 RID: 167744
		public const int CaptionItem = 0;

		// Token: 0x04028F41 RID: 167745
		public const int VerticalLayout = 1;

		// Token: 0x04028F42 RID: 167746
		public const int LayoutItem = 2;

		// Token: 0x04028F43 RID: 167747
		public const int RightUpTitleText = 3;

		// Token: 0x04028F44 RID: 167748
		public const int DescText = 4;

		// Token: 0x04028F45 RID: 167749
		public const int RewardLayout = 5;

		// Token: 0x04028F46 RID: 167750
		public const int RewardItem = 6;

		// Token: 0x04028F47 RID: 167751
		public const int DifficultTexture = 7;

		// Token: 0x04028F48 RID: 167752
		public const int LevelNumSprite = 8;

		// Token: 0x04028F49 RID: 167753
		public const int Btn = 9;
	}
}
