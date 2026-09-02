using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200272A RID: 10026
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsRewardItem : GridProxyAbstract<RacingBetsRewardData>
{
	// Token: 0x06013C5E RID: 80990 RVA: 0x00580404 File Offset: 0x0057E604
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickGetButton))
		};
	}

	// Token: 0x06013C5F RID: 80991 RVA: 0x0058051C File Offset: 0x0057E71C
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		RacingBetsRewardItem.<OnBeforeShowAsyncImplement>d__5 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RacingBetsRewardItem.<OnBeforeShowAsyncImplement>d__5>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06013C60 RID: 80992 RVA: 0x00580560 File Offset: 0x0057E760
	public override void Refresh(RacingBetsRewardData data, bool isSelected, int gridIndex)
	{
		this.RewardData = data;
		List<TItem> rewardList = this.RewardData.GetRewardList();
		if (rewardList.Count > 0)
		{
			CommonItemSmallItemGrid rewardIconItem = this.RewardIconItem;
			if (rewardIconItem != null)
			{
				rewardIconItem.Refresh(rewardList[0]);
			}
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(this.RewardData.GetRewardName());
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(this.RewardData.GetProgressText(), true);
		}
		ConditionTaskStatus taskStatus = this.RewardData.GetTaskStatus();
		this.RefreshState(taskStatus);
		UUIText text3 = base.GetText(7);
		if (text3 != null)
		{
			text3.ShowTextNew("Dango_CurrencyPage_Status_1");
		}
		UUIText text4 = base.GetText(5);
		if (text4 != null)
		{
			text4.ShowTextNew("Dango_CurrencyPage_Status_2");
		}
		UUIText text5 = base.GetText(8);
		if (text5 == null)
		{
			return;
		}
		text5.ShowTextNew("Dango_CurrencyPage_Status_3");
	}

	// Token: 0x06013C61 RID: 80993 RVA: 0x00580634 File Offset: 0x0057E834
	private void RefreshState(ConditionTaskStatus rewardStatus)
	{
		UUIButtonComponent button = base.GetButton(4);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(rewardStatus == ConditionTaskStatus.TaskFinish);
			}
		}
		UUIButtonComponent button2 = base.GetButton(3);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
		}
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetUIActive(rewardStatus == ConditionTaskStatus.Undone);
		}
		UUISprite sprite = base.GetSprite(6);
		if (sprite != null)
		{
			sprite.SetUIActive(rewardStatus == ConditionTaskStatus.Received);
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(rewardStatus == ConditionTaskStatus.TaskFinish);
	}

	// Token: 0x06013C62 RID: 80994 RVA: 0x005806D2 File Offset: 0x0057E8D2
	public void BindClickGetButtonCallBack(Action callback)
	{
		this.ClickGetButtonCallback = callback;
	}

	// Token: 0x06013C63 RID: 80995 RVA: 0x005806DB File Offset: 0x0057E8DB
	private void OnClickGetButton()
	{
		Action clickGetButtonCallback = this.ClickGetButtonCallback;
		if (clickGetButtonCallback == null)
		{
			return;
		}
		clickGetButtonCallback();
	}

	// Token: 0x040099F2 RID: 39410
	private RacingBetsRewardData RewardData;

	// Token: 0x040099F3 RID: 39411
	[Nullable(2)]
	private CommonItemSmallItemGrid RewardIconItem;

	// Token: 0x040099F4 RID: 39412
	private Action ClickGetButtonCallback = delegate()
	{
	};

	// Token: 0x02008ACF RID: 35535
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402ECC5 RID: 191685
		RewardItem,
		// Token: 0x0402ECC6 RID: 191686
		DescText,
		// Token: 0x0402ECC7 RID: 191687
		ProgressText,
		// Token: 0x0402ECC8 RID: 191688
		JumpBtn,
		// Token: 0x0402ECC9 RID: 191689
		ReceiveBtn,
		// Token: 0x0402ECCA RID: 191690
		DoingText,
		// Token: 0x0402ECCB RID: 191691
		ReceivedSprite,
		// Token: 0x0402ECCC RID: 191692
		JumpBtnText,
		// Token: 0x0402ECCD RID: 191693
		ReceiveBtnText,
		// Token: 0x0402ECCE RID: 191694
		RedDotItem
	}
}
