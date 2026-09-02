using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C5A RID: 7258
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDungeonSettleItem : UiPanelBase
{
	// Token: 0x0600D3D6 RID: 54230 RVA: 0x00387388 File Offset: 0x00385588
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D3D7 RID: 54231 RVA: 0x003875C7 File Offset: 0x003857C7
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		this.RewardLayout = new GenericLayout<FloroRanchDungeonSettleRewardItem, FloroRanchSubInsSettleReward>(base.GetHorizontalLayout(12), new Func<FloroRanchDungeonSettleRewardItem>(this.CreateRewardItem), null, false, true);
	}

	// Token: 0x0600D3D8 RID: 54232 RVA: 0x003875F1 File Offset: 0x003857F1
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
	}

	// Token: 0x0600D3D9 RID: 54233 RVA: 0x0038760F File Offset: 0x0038580F
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
	}

	// Token: 0x0600D3DA RID: 54234 RVA: 0x0038762D File Offset: 0x0038582D
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600D3DB RID: 54235 RVA: 0x00387638 File Offset: 0x00385838
	public UniTask RefreshAsync(FloroRanchPlaySettleData data)
	{
		FloroRanchDungeonSettleItem.<RefreshAsync>d__8 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<FloroRanchDungeonSettleItem.<RefreshAsync>d__8>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D3DC RID: 54236 RVA: 0x00387684 File Offset: 0x00385884
	private void OnAnimEvent(string param)
	{
		if (param == EFloroRanchAnimEvent.TagShow.ToString())
		{
			if (this.SettleData.IsNewMaxDays)
			{
				new LevelSequencePlayer(base.GetItem(4)).PlayLevelSequenceByName("Start", false, null, false);
			}
			if (this.SettleData.IsNewMaxCoin)
			{
				new LevelSequencePlayer(base.GetItem(6)).PlayLevelSequenceByName("Start", false, null, false);
			}
			if (this.SettleData.AllowedTechUp)
			{
				new LevelSequencePlayer(base.GetItem(10)).PlayLevelSequenceByName("Start", false, null, false);
			}
		}
	}

	// Token: 0x0600D3DD RID: 54237 RVA: 0x00387736 File Offset: 0x00385936
	private FloroRanchDungeonSettleRewardItem CreateRewardItem()
	{
		return new FloroRanchDungeonSettleRewardItem();
	}

	// Token: 0x040064CA RID: 25802
	private GenericLayout<FloroRanchDungeonSettleRewardItem, FloroRanchSubInsSettleReward> RewardLayout;

	// Token: 0x040064CB RID: 25803
	[Nullable(2)]
	private FloroRanchPlaySettleData SettleData;

	// Token: 0x02007F6D RID: 32621
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402B617 RID: 177687
		public const int CardSpine = 0;

		// Token: 0x0402B618 RID: 177688
		public const int CardNameText = 1;

		// Token: 0x0402B619 RID: 177689
		public const int CardContributionText = 2;

		// Token: 0x0402B61A RID: 177690
		public const int TotalDayText = 3;

		// Token: 0x0402B61B RID: 177691
		public const int NewRecordDayItem = 4;

		// Token: 0x0402B61C RID: 177692
		public const int TotalCoinText = 5;

		// Token: 0x0402B61D RID: 177693
		public const int NewRecordCoinItem = 6;

		// Token: 0x0402B61E RID: 177694
		public const int DayMaxCoinText = 7;

		// Token: 0x0402B61F RID: 177695
		public const int RewardItem = 8;

		// Token: 0x0402B620 RID: 177696
		public const int TechnologyRewardText = 9;

		// Token: 0x0402B621 RID: 177697
		public const int TechnologyUpItem = 10;

		// Token: 0x0402B622 RID: 177698
		public const int UnlockRootItem = 11;

		// Token: 0x0402B623 RID: 177699
		public const int UnlockRewardLayout = 12;

		// Token: 0x0402B624 RID: 177700
		public const int WeekScoreItem = 13;

		// Token: 0x0402B625 RID: 177701
		public const int ScoreText = 14;

		// Token: 0x0402B626 RID: 177702
		public const int EndlessTipText = 15;
	}
}
