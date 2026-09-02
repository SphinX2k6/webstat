using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BCA RID: 23498
	public class InstanceDungeonRewardView : UiViewBase
	{
		// Token: 0x0603B7FB RID: 243707 RVA: 0x00F156A7 File Offset: 0x00F138A7
		[NullableContext(1)]
		public InstanceDungeonRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B7FC RID: 243708 RVA: 0x00F156B0 File Offset: 0x00F138B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B7FD RID: 243709 RVA: 0x00F1573A File Offset: 0x00F1393A
		protected override void OnStart()
		{
			this.RewardViewItemScroll = new GenericScrollViewNew<InstanceDungeonRewardItem, ValueTuple<int, int>>(base.GetScrollViewWithScrollbar(2), new Func<InstanceDungeonRewardItem>(this.InitItem), null, false, null);
		}

		// Token: 0x0603B7FE RID: 243710 RVA: 0x00F15760 File Offset: 0x00F13960
		protected override void OnBeforeShow()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "InstanceRewardTitle", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "InstanceRewardSubTitle", Array.Empty<object>());
			int rewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId).Value.RewardId;
			Dictionary<int, int> dictionary = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig(new int?(rewardId)).Value.RewardId();
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			int recommendLevel = 0;
			int selectIndex = 0;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
				if (recommendLevel < keyValuePair.Key && curWorldLevel >= keyValuePair.Key)
				{
					recommendLevel = keyValuePair.Key;
					selectIndex = list.Count - 1;
				}
			}
			TTimerAction <>9__1;
			this.RewardViewItemScroll.RefreshByData(list, delegate
			{
				foreach (InstanceDungeonRewardItem instanceDungeonRewardItem in this.RewardViewItemScroll.GetScrollItemList())
				{
					instanceDungeonRewardItem.SetCurrentItem(recommendLevel);
				}
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						this.RewardViewItemScroll.ScrollToTop(selectIndex);
					});
				}
				gameplayTimeInstance.Next(action, null, null);
			}, false);
		}

		// Token: 0x0603B7FF RID: 243711 RVA: 0x00F158BC File Offset: 0x00F13ABC
		[NullableContext(1)]
		private InstanceDungeonRewardItem InitItem()
		{
			return new InstanceDungeonRewardItem();
		}

		// Token: 0x04021834 RID: 137268
		[Nullable(new byte[]
		{
			2,
			1,
			0
		})]
		private GenericScrollViewNew<InstanceDungeonRewardItem, ValueTuple<int, int>> RewardViewItemScroll;

		// Token: 0x0200BC34 RID: 48180
		private static class EChildCom
		{
			// Token: 0x0403A0D0 RID: 237776
			public const int TitleText = 0;

			// Token: 0x0403A0D1 RID: 237777
			public const int SubTitleText = 1;

			// Token: 0x0403A0D2 RID: 237778
			public const int RewardLayout = 2;
		}
	}
}
