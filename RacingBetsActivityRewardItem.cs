using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002712 RID: 10002
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsActivityRewardItem : GridProxyAbstract<RacingBetsRewardData>
{
	// Token: 0x06013BA6 RID: 80806 RVA: 0x0057D5D4 File Offset: 0x0057B7D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickJump)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickGetButton))
		};
	}

	// Token: 0x06013BA7 RID: 80807 RVA: 0x0057D71C File Offset: 0x0057B91C
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		RacingBetsActivityRewardItem.<OnBeforeShowAsyncImplement>d__4 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RacingBetsActivityRewardItem.<OnBeforeShowAsyncImplement>d__4>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06013BA8 RID: 80808 RVA: 0x0057D760 File Offset: 0x0057B960
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
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(this.RewardData.GetRewardName());
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(this.RewardData.GetProgressText(), true);
		}
		ConditionTaskStatus taskStatus = this.RewardData.GetTaskStatus();
		this.RefreshState(taskStatus);
		UUIText text3 = base.GetText(8);
		if (text3 != null)
		{
			text3.ShowTextNew("Dango_CurrencyPage_Status_1");
		}
		UUIText text4 = base.GetText(4);
		if (text4 != null)
		{
			text4.ShowTextNew("Dango_CurrencyPage_Status_2");
		}
		UUIText text5 = base.GetText(9);
		if (text5 == null)
		{
			return;
		}
		text5.ShowTextNew("Dango_CurrencyPage_Status_3");
	}

	// Token: 0x06013BA9 RID: 80809 RVA: 0x0057D834 File Offset: 0x0057BA34
	public void RefreshState(ConditionTaskStatus rewardStatus)
	{
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(rewardStatus == ConditionTaskStatus.TaskFinish);
			}
		}
		UUIButtonComponent button2 = base.GetButton(2);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetUIActive(rewardStatus == ConditionTaskStatus.Undone);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(rewardStatus == ConditionTaskStatus.Received);
		}
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(rewardStatus == ConditionTaskStatus.TaskFinish);
	}

	// Token: 0x06013BAA RID: 80810 RVA: 0x0057D8D2 File Offset: 0x0057BAD2
	private void OnClickJump()
	{
	}

	// Token: 0x06013BAB RID: 80811 RVA: 0x0057D8D4 File Offset: 0x0057BAD4
	private void OnClickGetButton()
	{
		ControllerBase<RacingBetsController>.Instance.RacingBetsTaskRewardRequest(this.RewardData.Id);
	}

	// Token: 0x040099A8 RID: 39336
	private RacingBetsRewardData RewardData;

	// Token: 0x040099A9 RID: 39337
	[Nullable(2)]
	private CommonItemSmallItemGrid RewardIconItem;

	// Token: 0x02008AAF RID: 35503
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC34 RID: 191540
		DescText,
		// Token: 0x0402EC35 RID: 191541
		ProgressText,
		// Token: 0x0402EC36 RID: 191542
		JumpBtn,
		// Token: 0x0402EC37 RID: 191543
		ReceiveBtn,
		// Token: 0x0402EC38 RID: 191544
		DoingText,
		// Token: 0x0402EC39 RID: 191545
		ReceivedSprite,
		// Token: 0x0402EC3A RID: 191546
		RewardLayout,
		// Token: 0x0402EC3B RID: 191547
		RewardItem,
		// Token: 0x0402EC3C RID: 191548
		JumpBtnText,
		// Token: 0x0402EC3D RID: 191549
		ReceiveBtnText,
		// Token: 0x0402EC3E RID: 191550
		RedDotItem
	}
}
