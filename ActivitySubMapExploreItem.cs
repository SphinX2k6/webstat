using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200137B RID: 4987
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivitySubMapExploreItem : GridProxyAbstract<IActivitySubMapExploreItemData>
{
	// Token: 0x060088BD RID: 35005 RVA: 0x0024067C File Offset: 0x0023E87C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnGetReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060088BE RID: 35006 RVA: 0x00240788 File Offset: 0x0023E988
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubMapExploreItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubMapExploreItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060088BF RID: 35007 RVA: 0x002407CC File Offset: 0x0023E9CC
	public override void Refresh(IActivitySubMapExploreItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		string rewardDesc = this.ItemData.RewardDesc;
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(rewardDesc, rewardDesc);
		base.GetText(3).SetText(multiTextByKey, true);
		int? num;
		this.RewardItem.Apply<PropSmallItemGrid>(new PropSmallItemGrid
		{
			Data = this.ItemData,
			ItemConfigId = new int?(this.ItemData.RewardItemId),
			BottomText = (((this.ItemData.RewardItemCount != null) ? num.GetValueOrDefault().ToString() : null) ?? string.Empty),
			IsReceivedVisible = new bool?(this.ItemData.IsComplete),
			IsReceivableVisible = new bool?(this.ItemData.IsCanGet)
		});
		base.GetTexture(2).SetUIActive(this.ItemData.IsCanGet);
		base.GetItem(4).SetUIActive(this.ItemData.IsCanGet);
		EToggleState state = this.ItemData.IsComplete ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked;
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x060088C0 RID: 35008 RVA: 0x002408F0 File Offset: 0x0023EAF0
	private void OnClickReward(MediumItemGridExtendCallback _)
	{
		if (this.ItemData.IsCanGet)
		{
			this.OnGetReward(EToggleState.ETT_UnChecked);
			return;
		}
		int rewardItemId = this.ItemData.RewardItemId;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardItemId, true, null);
	}

	// Token: 0x060088C1 RID: 35009 RVA: 0x0024092C File Offset: 0x0023EB2C
	private void OnGetReward(EToggleState _)
	{
		if (this.ItemData.IsComplete)
		{
			return;
		}
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle != null)
		{
			itemToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		IScrollViewDelegate<IGridProxy<IActivitySubMapExploreItemData>, IActivitySubMapExploreItemData> scrollViewDelegate = base.ScrollViewDelegate;
		if (scrollViewDelegate != null)
		{
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
		if (this.ItemData.IsCanGet)
		{
			Action<IActivitySubMapExploreItemData> getRewardCallBack = this.GetRewardCallBack;
			if (getRewardCallBack == null)
			{
				return;
			}
			getRewardCallBack(this.ItemData);
		}
	}

	// Token: 0x060088C2 RID: 35010 RVA: 0x0024099D File Offset: 0x0023EB9D
	private UUIExtendToggle GetItemToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x060088C3 RID: 35011 RVA: 0x002409A6 File Offset: 0x0023EBA6
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060088C4 RID: 35012 RVA: 0x002409BC File Offset: 0x0023EBBC
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle itemToggle = this.GetItemToggle();
		if (itemToggle == null)
		{
			return;
		}
		itemToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04004039 RID: 16441
	private IActivitySubMapExploreItemData ItemData;

	// Token: 0x0400403A RID: 16442
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IActivitySubMapExploreItemData> ClickCallBack;

	// Token: 0x0400403B RID: 16443
	[Nullable(2)]
	private SmallItemGrid RewardItem;

	// Token: 0x0400403C RID: 16444
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IActivitySubMapExploreItemData> GetRewardCallBack;

	// Token: 0x0200771E RID: 30494
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x04029052 RID: 168018
		public const int ToggleGetBtn = 0;

		// Token: 0x04029053 RID: 168019
		public const int ItemCommonReward = 1;

		// Token: 0x04029054 RID: 168020
		public const int TextureCanGet = 2;

		// Token: 0x04029055 RID: 168021
		public const int TxtRewardDesc = 3;

		// Token: 0x04029056 RID: 168022
		public const int ItemRedDot = 4;
	}
}
