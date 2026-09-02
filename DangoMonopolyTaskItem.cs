using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001307 RID: 4871
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoMonopolyTaskItem : GridProxyAbstract<global::DangoMonopolyTaskData>
{
	// Token: 0x0600847B RID: 33915 RVA: 0x0022F3CC File Offset: 0x0022D5CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickReceive)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickJump))
		};
	}

	// Token: 0x0600847C RID: 33916 RVA: 0x0022F4FC File Offset: 0x0022D6FC
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyTaskItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyTaskItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600847D RID: 33917 RVA: 0x0022F53F File Offset: 0x0022D73F
	protected override void OnStart()
	{
		base.GetText(5).ShowTextNew("DangoMonopoly_title_10");
	}

	// Token: 0x0600847E RID: 33918 RVA: 0x0022F552 File Offset: 0x0022D752
	private void OnClickReward(MediumItemGridExtendCallback _)
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemData.RewardItemId, true, null);
	}

	// Token: 0x0600847F RID: 33919 RVA: 0x0022F56B File Offset: 0x0022D76B
	public override void Refresh(global::DangoMonopolyTaskData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.GetText(1).ShowTextNew(this.ItemData.TaskDesc);
		this.UpdateProgressDesc();
		this.UpdateReward();
		this.UpdateState();
		data.LogInfo();
	}

	// Token: 0x06008480 RID: 33920 RVA: 0x0022F5A4 File Offset: 0x0022D7A4
	private void UpdateProgressDesc()
	{
		UUIText text = base.GetText(2);
		bool flag = this.ItemData.TotalProgress > 0;
		text.SetUIActive(flag);
		if (flag)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ItemData.Progress);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ItemData.TotalProgress);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			text.SetText(newText, true);
		}
	}

	// Token: 0x06008481 RID: 33921 RVA: 0x0022F634 File Offset: 0x0022D834
	private void UpdateReward()
	{
		int rewardItemCount = this.ItemData.RewardItemCount;
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = this.ItemData;
		propSmallItemGrid.ItemConfigId = new int?(this.ItemData.RewardItemId);
		string bottomText;
		if (rewardItemCount <= 0)
		{
			bottomText = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(rewardItemCount);
			bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		propSmallItemGrid.BottomText = bottomText;
		propSmallItemGrid.IsReceivedVisible = new bool?(this.ItemData.TaskState == DangoMonopolyTaskState.HasGet);
		PropSmallItemGrid parameters = propSmallItemGrid;
		this.RewardItem.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06008482 RID: 33922 RVA: 0x0022F6C4 File Offset: 0x0022D8C4
	private void UpdateState()
	{
		UUIText text = base.GetText(5);
		UUISprite sprite = base.GetSprite(6);
		UUIButtonComponent button = base.GetButton(4);
		UUIButtonComponent button2 = base.GetButton(3);
		UUIItem item = base.GetItem(9);
		bool flag = this.ItemData.Source != 0;
		sprite.SetUIActive(false);
		text.SetUIActive(false);
		button2.RootUIComp.Get().SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		item.SetUIActive(false);
		switch (this.ItemData.TaskState)
		{
		case DangoMonopolyTaskState.NotCompleted:
			text.SetUIActive(!flag);
			button2.RootUIComp.Get().SetUIActive(flag);
			return;
		case DangoMonopolyTaskState.Completed:
			button.RootUIComp.Get().SetUIActive(true);
			item.SetUIActive(true);
			return;
		case DangoMonopolyTaskState.HasGet:
			sprite.SetUIActive(true);
			return;
		default:
			return;
		}
	}

	// Token: 0x06008483 RID: 33923 RVA: 0x0022F7B3 File Offset: 0x0022D9B3
	private void OnClickReceive()
	{
		Action<global::DangoMonopolyTaskData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x06008484 RID: 33924 RVA: 0x0022F7CB File Offset: 0x0022D9CB
	private void OnClickJump()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.DangoMonopolyTaskView, null);
		this.ItemData.JumpSource();
	}

	// Token: 0x04003EE0 RID: 16096
	private global::DangoMonopolyTaskData ItemData;

	// Token: 0x04003EE1 RID: 16097
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<global::DangoMonopolyTaskData> ClickCallBack;

	// Token: 0x04003EE2 RID: 16098
	private SmallItemGrid RewardItem;

	// Token: 0x020076B0 RID: 30384
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E35 RID: 167477
		ItemReward,
		// Token: 0x04028E36 RID: 167478
		TxtDesc,
		// Token: 0x04028E37 RID: 167479
		TxtProgressDesc,
		// Token: 0x04028E38 RID: 167480
		BtnJump,
		// Token: 0x04028E39 RID: 167481
		BtnReceive,
		// Token: 0x04028E3A RID: 167482
		TxtProgress,
		// Token: 0x04028E3B RID: 167483
		SpriteCompleted,
		// Token: 0x04028E3C RID: 167484
		TxtJump,
		// Token: 0x04028E3D RID: 167485
		TxtReceive,
		// Token: 0x04028E3E RID: 167486
		ItemReceiveRedDot
	}
}
