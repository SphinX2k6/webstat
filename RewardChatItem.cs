using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002584 RID: 9604
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RewardChatItem : SyncGridProxyAbstract<PhoneMsgChatData>
{
	// Token: 0x06012AC5 RID: 76485 RVA: 0x00525FD4 File Offset: 0x005241D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnGetRewardClick))
		};
	}

	// Token: 0x06012AC6 RID: 76486 RVA: 0x0052607D File Offset: 0x0052427D
	protected override void OnStart()
	{
		this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, null);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012AC7 RID: 76487 RVA: 0x005260B1 File Offset: 0x005242B1
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06012AC8 RID: 76488 RVA: 0x005260B8 File Offset: 0x005242B8
	public override void Refresh(PhoneMsgChatData data)
	{
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(data.DropId);
		if (dropPackage == null)
		{
			return;
		}
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dropPackage.Value.DropPreview())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
			list.Add(item);
		}
		this.RewardScroll.RefreshByData(list, null, false);
		base.GetButton(0).RootUIComp.Get().SetUIActive(!data.IsFinish);
		base.GetSprite(1).SetUIActive(data.IsFinish);
	}

	// Token: 0x06012AC9 RID: 76489 RVA: 0x005261A0 File Offset: 0x005243A0
	private void OnGetRewardClick()
	{
		Action onRewardClick = this.OnRewardClick;
		if (onRewardClick == null)
		{
			return;
		}
		onRewardClick();
	}

	// Token: 0x06012ACA RID: 76490 RVA: 0x005261B4 File Offset: 0x005243B4
	public UniTask PlayRewardAnimationAsync()
	{
		RewardChatItem.<PlayRewardAnimationAsync>d__9 <PlayRewardAnimationAsync>d__;
		<PlayRewardAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRewardAnimationAsync>d__.<>4__this = this;
		<PlayRewardAnimationAsync>d__.<>1__state = -1;
		<PlayRewardAnimationAsync>d__.<>t__builder.Start<RewardChatItem.<PlayRewardAnimationAsync>d__9>(ref <PlayRewardAnimationAsync>d__);
		return <PlayRewardAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012ACB RID: 76491 RVA: 0x005261F7 File Offset: 0x005243F7
	public void StopRewardAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("In", false, true);
	}

	// Token: 0x040091E0 RID: 37344
	[Nullable(2)]
	public Action OnRewardClick;

	// Token: 0x040091E1 RID: 37345
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

	// Token: 0x040091E2 RID: 37346
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020088A5 RID: 34981
	[NullableContext(0)]
	private enum EItemRewardComponent
	{
		// Token: 0x0402E25D RID: 189021
		BtnGet,
		// Token: 0x0402E25E RID: 189022
		SpriteFinish,
		// Token: 0x0402E25F RID: 189023
		RewardScroll,
		// Token: 0x0402E260 RID: 189024
		Content,
		// Token: 0x0402E261 RID: 189025
		RewardItemBox
	}
}
