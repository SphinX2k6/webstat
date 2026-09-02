using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001410 RID: 5136
public class RewardGrandItem : UiPanelBase
{
	// Token: 0x06008E52 RID: 36434 RVA: 0x00256398 File Offset: 0x00254598
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06008E53 RID: 36435 RVA: 0x00256484 File Offset: 0x00254684
	[NullableContext(1)]
	public void Refresh(TaskData data)
	{
		this.Data = data;
		List<TItem> rewardList = this.Data.RewardList;
		if (rewardList.Count == 0)
		{
			return;
		}
		this.RewardItemId = rewardList[0].ItemData.ItemId;
		base.SetItemIcon(base.GetTexture(4), this.RewardItemId, null, null);
		int count = rewardList[0].Count;
		base.GetText(0).SetText("x" + count.ToString(), true);
		base.GetSprite(3).SetFillAmount(Singleton<MathUtils>.Instance.Clamp((float)this.Data.Current / (float)this.Data.Target, 0f, 1f));
		string textStringId = "Moonfiesta_BigRewardState1";
		if (this.Data.IsTaken)
		{
			textStringId = "Moonfiesta_BigRewardState3";
		}
		else if (this.Data.IsFinished)
		{
			textStringId = "Moonfiesta_BigRewardState2";
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlySingleElementList<object>(this.Data.Target));
		base.GetItem(5).SetUIActive(this.Data.IsTaken);
		base.GetItem(6).SetUIActive(this.Data.IsFinished);
		base.GetItem(7).SetUIActive(this.Data.IsFinished);
	}

	// Token: 0x06008E54 RID: 36436 RVA: 0x002565E0 File Offset: 0x002547E0
	private void OnClickButton()
	{
		if (this.Data == null)
		{
			return;
		}
		if (!this.Data.IsFinished)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItemId, true, null);
			return;
		}
		TaskReceive receiveDelegate = this.Data.ReceiveDelegate;
		if (receiveDelegate == null)
		{
			return;
		}
		receiveDelegate(this.Data.TaskId);
	}

	// Token: 0x04004257 RID: 16983
	[Nullable(1)]
	private TaskData Data;

	// Token: 0x04004258 RID: 16984
	private int RewardItemId;

	// Token: 0x020077FE RID: 30718
	private class EComponentDefine
	{
		// Token: 0x0402947B RID: 169083
		public const int Count = 0;

		// Token: 0x0402947C RID: 169084
		public const int Content = 1;

		// Token: 0x0402947D RID: 169085
		public const int ItemButton = 2;

		// Token: 0x0402947E RID: 169086
		public const int SpriteBar = 3;

		// Token: 0x0402947F RID: 169087
		public const int Icon = 4;

		// Token: 0x04029480 RID: 169088
		public const int SpriteDone = 5;

		// Token: 0x04029481 RID: 169089
		public const int RedDot = 6;

		// Token: 0x04029482 RID: 169090
		public const int SpriteCanReceive = 7;
	}
}
