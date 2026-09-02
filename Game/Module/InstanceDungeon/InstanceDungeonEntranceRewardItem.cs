using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBA RID: 23482
	public class InstanceDungeonEntranceRewardItem : UiPanelBase
	{
		// Token: 0x0603B6D0 RID: 243408 RVA: 0x00F0F580 File Offset: 0x00F0D780
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B6D1 RID: 243409 RVA: 0x00F0F6EC File Offset: 0x00F0D8EC
		protected override void OnStart()
		{
			this.RewardLoopScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(0), new Func<CommonItemSmallItemGrid>(this.CreateRewardGrid), null, false, null);
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.InstanceId);
			}
		}

		// Token: 0x0603B6D2 RID: 243410 RVA: 0x00F0F728 File Offset: 0x00F0D928
		protected override void OnBeforeDestroy()
		{
			this.RewardLoopScroll = null;
		}

		// Token: 0x0603B6D3 RID: 243411 RVA: 0x00F0F734 File Offset: 0x00F0D934
		public void RefreshItem(int instanceId)
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new IInstanceDungeonEntranceRewardItem
				{
					InstanceId = instanceId
				};
				return;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			ValueTuple<List<TItem>, bool> instanceDungeonReward = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstanceDungeonReward(instanceId);
			ExchangeReward? exchangeReward;
			Dictionary<int, int> dictionary = (ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig((config != null) ? new int?(config.GetValueOrDefault().RewardId) : null) != null) ? exchangeReward.GetValueOrDefault().RewardId() : null;
			this.SetRewardBtnActive(((dictionary != null) ? dictionary.Count : 0) > 1);
			ExchangeRewardModel instance = ModelBase<ExchangeRewardModel>.Instance;
			bool? flag = (instance != null) ? new bool?(instance.IsFinishInstance(instanceId)) : null;
			int num;
			if (!flag.GetValueOrDefault())
			{
				List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList((config != null) ? config.GetValueOrDefault().FirstRewardId : 0, null);
				num = ((exchangeRewardPreviewRewardList != null) ? exchangeRewardPreviewRewardList.Count : 0);
			}
			else
			{
				num = 0;
			}
			int firstRewardLength = num;
			List<TItem> exchangeRewardPreviewRewardList2 = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList((config != null) ? config.GetValueOrDefault().ExchangeRewardId : 0, null);
			int exchangeRewardLength = (exchangeRewardPreviewRewardList2 != null) ? exchangeRewardPreviewRewardList2.Count : 0;
			this.SetFirstRewardLength(firstRewardLength);
			this.SetExchangeRewardLength(exchangeRewardLength);
			int? instanceFirstRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceFirstRewardId(instanceId);
			bool value;
			if (!flag.GetValueOrDefault())
			{
				int? num2 = instanceFirstRewardId;
				int num3 = 0;
				value = !(num2.GetValueOrDefault() == num3 & num2 != null);
			}
			else
			{
				value = false;
			}
			this.RefreshRewardText(new bool?(value));
			this.RefreshReward(instanceDungeonReward.Item1, instanceDungeonReward.Item2 || ModelBase<ExchangeRewardModel>.Instance.IsFinishInstanceCompatible(instanceId));
			this.SetDoubleReward(instanceId);
		}

		// Token: 0x0603B6D4 RID: 243412 RVA: 0x00F0F8FF File Offset: 0x00F0DAFF
		[NullableContext(1)]
		public void RefreshReward(List<TItem> dataList, bool isFinishInstance)
		{
			this.CanExchangeReward = !isFinishInstance;
			this.RewardLoopScroll.RefreshByData(dataList, delegate
			{
				GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardLoopScroll = this.RewardLoopScroll;
				List<CommonItemSmallItemGrid> list = (rewardLoopScroll != null) ? rewardLoopScroll.GetScrollItemList() : null;
				int num = (list != null) ? list.Count : 0;
				for (int i = 0; i < num; i++)
				{
					CommonItemSmallItemGrid commonItemSmallItemGrid = list[i];
					commonItemSmallItemGrid.SetReceivedVisible(!this.CanExchangeReward);
					commonItemSmallItemGrid.SetFirstRewardVisible(i < this.FirstRewardLength);
					commonItemSmallItemGrid.SetExchangeRewardVisible(i >= this.FirstRewardLength && i < this.FirstRewardLength + this.ExchangeRewardLength);
				}
			}, false);
		}

		// Token: 0x0603B6D5 RID: 243413 RVA: 0x00F0F924 File Offset: 0x00F0DB24
		public void RefreshRewardText(bool? isFirstGet)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Text_RewardPreview_Text", Array.Empty<object>());
		}

		// Token: 0x0603B6D6 RID: 243414 RVA: 0x00F0F941 File Offset: 0x00F0DB41
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateRewardGrid()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603B6D7 RID: 243415 RVA: 0x00F0F948 File Offset: 0x00F0DB48
		private void OnClickBtnReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonReward, null, null);
		}

		// Token: 0x0603B6D8 RID: 243416 RVA: 0x00F0F95B File Offset: 0x00F0DB5B
		public void SetRewardBtnActive(bool isActive)
		{
			(base.GetButton(1).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(isActive);
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isActive);
		}

		// Token: 0x0603B6D9 RID: 243417 RVA: 0x00F0F98C File Offset: 0x00F0DB8C
		public void SetDoubleReward(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			ActivityDoubleRewardData dungeonUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetDungeonUpActivity(((config != null) ? config.GetValueOrDefault().GetCustomTypesArray() : null) ?? Array.Empty<int>(), true);
			bool flag = dungeonUpActivity != null && dungeonUpActivity.LeftUpCount > 0;
			ValueTuple<bool, int, int, string, string> dungeonDoubleDropTuple = ModelBase<ActivityRegressModel>.Instance.GetDungeonDoubleDropTuple(instanceId);
			bool item = dungeonDoubleDropTuple.Item1;
			int item2 = dungeonDoubleDropTuple.Item2;
			int item3 = dungeonDoubleDropTuple.Item3;
			string item4 = dungeonDoubleDropTuple.Item4;
			string item5 = dungeonDoubleDropTuple.Item5;
			bool uiactive = item || flag;
			base.GetItem(3).SetUIActive(uiactive);
			base.GetItem(5).SetUIActive(uiactive);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Double_reward_tips_02", Array.Empty<object>());
				ValueTuple<string, int, int> numTxtAndParam = dungeonUpActivity.GetNumTxtAndParam();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), numTxtAndParam.Item1, new <>z__ReadOnlyArray<object>(new object[]
				{
					numTxtAndParam.Item2,
					numTxtAndParam.Item3
				}));
			}
			if (item)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), item5, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), item4, new <>z__ReadOnlyArray<object>(new object[]
				{
					item2,
					item3
				}));
			}
		}

		// Token: 0x0603B6DA RID: 243418 RVA: 0x00F0FAEC File Offset: 0x00F0DCEC
		public void SetFirstRewardLength(int length)
		{
			this.FirstRewardLength = length;
		}

		// Token: 0x0603B6DB RID: 243419 RVA: 0x00F0FAF5 File Offset: 0x00F0DCF5
		public void SetExchangeRewardLength(int length)
		{
			this.ExchangeRewardLength = length;
		}

		// Token: 0x040217D0 RID: 137168
		[Nullable(2)]
		private IInstanceDungeonEntranceRewardItem ItemDataHandle;

		// Token: 0x040217D1 RID: 137169
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLoopScroll;

		// Token: 0x040217D2 RID: 137170
		private bool CanExchangeReward = true;

		// Token: 0x040217D3 RID: 137171
		private int FirstRewardLength;

		// Token: 0x040217D4 RID: 137172
		private int ExchangeRewardLength;

		// Token: 0x0200BC09 RID: 48137
		private enum EChildType
		{
			// Token: 0x0403A008 RID: 237576
			LoopScrollReward,
			// Token: 0x0403A009 RID: 237577
			BtnReward,
			// Token: 0x0403A00A RID: 237578
			RewardText,
			// Token: 0x0403A00B RID: 237579
			DoubleTip,
			// Token: 0x0403A00C RID: 237580
			DoubleTipTxt,
			// Token: 0x0403A00D RID: 237581
			DoubleIcon,
			// Token: 0x0403A00E RID: 237582
			RewardDesText,
			// Token: 0x0403A00F RID: 237583
			DoubleTitleText
		}
	}
}
