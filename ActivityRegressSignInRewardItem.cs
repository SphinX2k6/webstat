using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200154D RID: 5453
public class ActivityRegressSignInRewardItem : UiPanelBase
{
	// Token: 0x0600990B RID: 39179 RVA: 0x00281474 File Offset: 0x0027F674
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardItem))
		};
	}

	// Token: 0x0600990C RID: 39180 RVA: 0x00281549 File Offset: 0x0027F749
	[NullableContext(1)]
	public void RegisterItemClickCallBack(Action<int> onRewardItemClick)
	{
		this.OnRewardItemClick = onRewardItemClick;
	}

	// Token: 0x0600990D RID: 39181 RVA: 0x00281554 File Offset: 0x0027F754
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(4).GetOwner());
		this.ItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.ItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnRewardItemClicked));
	}

	// Token: 0x0600990E RID: 39182 RVA: 0x002815C4 File Offset: 0x0027F7C4
	public void RefreshByData(int index)
	{
		this.Index = index;
		int num = index + 1;
		this.Day = num;
		UUIText text = base.GetText(5);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		bool uiactive = ModelBase<ActivityRegressModel>.Instance.CheckSignRewardState(this.Day, ERegressRewardState.Reached);
		bool uiactive2 = ModelBase<ActivityRegressModel>.Instance.CheckSignRewardState(this.Day, ERegressRewardState.Claim);
		ERegressRewardState signRewardState = ModelBase<ActivityRegressModel>.Instance.GetSignRewardState(num);
		string signRewardLocalTextKeyByState = ModelBase<ActivityRegressModel>.Instance.GetSignRewardLocalTextKeyByState(signRewardState);
		UUIText text2 = base.GetText(3);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, signRewardLocalTextKeyByState, Array.Empty<object>());
		base.GetItem(1).SetUIActive(uiactive);
		base.GetItem(2).SetUIActive(uiactive2);
		RegressSignReward? signRewardConfigByIndex = ModelBase<ActivityRegressModel>.Instance.GetSignRewardConfigByIndex(index);
		IRegressRewardItemInfo signRewardPreviewItemInfo = ModelBase<ActivityRegressModel>.Instance.GetSignRewardPreviewItemInfo(signRewardConfigByIndex.Value);
		ActivityRegressHelper.RefreshItemGridByData(this.ItemGrid, signRewardPreviewItemInfo);
	}

	// Token: 0x0600990F RID: 39183 RVA: 0x002816B4 File Offset: 0x0027F8B4
	[NullableContext(1)]
	private void OnRewardItemClicked(MediumItemGridExtendCallback _)
	{
		this.OnClickRewardItem();
	}

	// Token: 0x06009910 RID: 39184 RVA: 0x002816BC File Offset: 0x0027F8BC
	private void OnClickRewardItem()
	{
		if (!ModelBase<ActivityRegressModel>.Instance.CheckSignRewardState(this.Day, ERegressRewardState.Reached))
		{
			RegressSignReward? signRewardConfigByIndex = ModelBase<ActivityRegressModel>.Instance.GetSignRewardConfigByIndex(this.Index);
			int? item = ModelBase<ActivityRegressModel>.Instance.GetSignRewardPreviewReward(signRewardConfigByIndex.Value).Item1;
			if (item != null)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(item.Value, true, null);
			}
			return;
		}
		Action<int> onRewardItemClick = this.OnRewardItemClick;
		if (onRewardItemClick == null)
		{
			return;
		}
		onRewardItemClick(this.Index);
	}

	// Token: 0x040046BD RID: 18109
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x040046BE RID: 18110
	private int Index;

	// Token: 0x040046BF RID: 18111
	private int Day;

	// Token: 0x040046C0 RID: 18112
	[Nullable(2)]
	private Action<int> OnRewardItemClick;

	// Token: 0x0200790B RID: 30987
	private class EComponents
	{
		// Token: 0x04029992 RID: 170386
		public const int RootBtn = 0;

		// Token: 0x04029993 RID: 170387
		public const int PnlReceive = 1;

		// Token: 0x04029994 RID: 170388
		public const int PnlDone = 2;

		// Token: 0x04029995 RID: 170389
		public const int TxtNor = 3;

		// Token: 0x04029996 RID: 170390
		public const int ItemGrid = 4;

		// Token: 0x04029997 RID: 170391
		public const int TxtNum = 5;

		// Token: 0x04029998 RID: 170392
		public const int SprLight = 6;
	}
}
