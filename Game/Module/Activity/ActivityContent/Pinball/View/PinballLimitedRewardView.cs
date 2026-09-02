using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006595 RID: 26005
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballLimitedRewardView : UiTickViewBase
	{
		// Token: 0x06040FAC RID: 266156 RVA: 0x010AC183 File Offset: 0x010AA383
		public PinballLimitedRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040FAD RID: 266157 RVA: 0x010AC18C File Offset: 0x010AA38C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnBigRewardBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnPreviewBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnBigRewardItemTipsClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040FAE RID: 266158 RVA: 0x010AC40C File Offset: 0x010AA60C
		protected override void OnStart()
		{
			this.ActivityData = (this.OpenParam as PinballActivityData);
			PopupCaptionItem popupCaptionItem = new PopupCaptionItem(base.GetItem(0));
			popupCaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			popupCaptionItem.SetHelpBtnActive(false);
			this.TaskLayout = new GenericScrollViewNew<PinballLimitedRewardTaskItem, PinballTaskData>(base.GetScrollViewWithScrollbar(1), new Func<PinballLimitedRewardTaskItem>(this.CreateTaskItem), null, false, null);
			this.RefreshView(true);
		}

		// Token: 0x06040FAF RID: 266159 RVA: 0x010AC478 File Offset: 0x010AA678
		protected override UniTask OnBeforeStartAsync()
		{
			PinballLimitedRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballLimitedRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FB0 RID: 266160 RVA: 0x010AC4B3 File Offset: 0x010AA6B3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040FB1 RID: 266161 RVA: 0x010AC4D1 File Offset: 0x010AA6D1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040FB2 RID: 266162 RVA: 0x010AC4F0 File Offset: 0x010AA6F0
		protected override void OnTick(float delta)
		{
			if (this.ActivityData == null)
			{
				base.CloseMe(null);
				return;
			}
			if (!this.ActivityData.CheckIfInRewardTime())
			{
				base.CloseMe(null);
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndRewardTime, localTextNew);
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x06040FB3 RID: 266163 RVA: 0x010AC558 File Offset: 0x010AA758
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (id != this.ActivityData.Id)
			{
				return;
			}
			this.RefreshView(false);
		}

		// Token: 0x06040FB4 RID: 266164 RVA: 0x010AC570 File Offset: 0x010AA770
		private void RefreshView(bool isPlayAnim = false)
		{
			List<PinballTaskData> timeLimitTaskList = this.ActivityData.GetTimeLimitTaskList();
			List<PinballTaskData> list = new List<PinballTaskData>();
			foreach (PinballTaskData pinballTaskData in timeLimitTaskList)
			{
				if (pinballTaskData.TaskTab != EPinballTaskTab.BigReward)
				{
					list.Add(pinballTaskData);
				}
			}
			this.TaskLayout.RefreshByData(list, delegate
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}, isPlayAnim);
			this.RefreshProgress();
			this.RefreshBigRewardTask();
			this.RefreshBigRewardHeader();
		}

		// Token: 0x06040FB5 RID: 266165 RVA: 0x010AC604 File Offset: 0x010AA804
		private void RefreshBigRewardHeader()
		{
			int bigRewardFirstItemConfigId = this.GetBigRewardFirstItemConfigId();
			UUITexture texture = base.GetTexture(5);
			UUIText text = base.GetText(6);
			if (bigRewardFirstItemConfigId <= 0)
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(bigRewardFirstItemConfigId);
			if (itemConfigData == null)
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, itemConfigData.Name, Array.Empty<object>());
			if (!string.IsNullOrEmpty(itemConfigData.Icon) && texture != null)
			{
				texture.SetUIActive(true);
				base.SetTextureByPath(itemConfigData.Icon, texture, null, null);
				return;
			}
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
		}

		// Token: 0x06040FB6 RID: 266166 RVA: 0x010AC6C0 File Offset: 0x010AA8C0
		private int GetBigRewardFirstItemConfigId()
		{
			PinballTaskData pinballTaskData = null;
			PinballActivityData activityData = this.ActivityData;
			List<PinballTaskData> list = (activityData != null) ? activityData.GetTimeLimitTaskList() : null;
			if (list != null)
			{
				foreach (PinballTaskData pinballTaskData2 in list)
				{
					if (pinballTaskData2.TaskTab == EPinballTaskTab.BigReward)
					{
						pinballTaskData = pinballTaskData2;
						break;
					}
				}
			}
			TItem? titem;
			if (pinballTaskData == null)
			{
				titem = null;
			}
			else
			{
				List<TItem> rewardList = pinballTaskData.RewardList;
				titem = ((rewardList != null) ? new TItem?(rewardList[0]) : null);
			}
			TItem? titem2 = titem;
			int? num;
			if (titem2 == null)
			{
				num = null;
			}
			else
			{
				InventoryDefine.IGetItemData itemData = titem2.GetValueOrDefault().ItemData;
				num = ((itemData != null) ? new int?(itemData.ItemId) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int? num3 = num2;
				int num4 = 0;
				if (num3.GetValueOrDefault() > num4 & num3 != null)
				{
					return num2.Value;
				}
			}
			return 0;
		}

		// Token: 0x06040FB7 RID: 266167 RVA: 0x010AC7CC File Offset: 0x010AA9CC
		private void RefreshBigRewardTask()
		{
			List<PinballTaskData> timeLimitTaskList = this.ActivityData.GetTimeLimitTaskList();
			PinballTaskData pinballTaskData = null;
			foreach (PinballTaskData pinballTaskData2 in timeLimitTaskList)
			{
				if (pinballTaskData2.TaskTab == EPinballTaskTab.BigReward)
				{
					pinballTaskData = pinballTaskData2;
					break;
				}
			}
			UUIItem item = base.GetItem(12);
			UUIText text = base.GetText(11);
			if (pinballTaskData != null)
			{
				UUIText text2 = base.GetText(7);
				if (!string.IsNullOrEmpty(pinballTaskData.QuestNameTextKey))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, pinballTaskData.QuestNameTextKey, Array.Empty<object>());
				}
				else if (text2 != null)
				{
					text2.SetText(pinballTaskData.QuestName, true);
				}
				UUIButtonComponent button = base.GetButton(9);
				if (item != null)
				{
					item.SetUIActive(pinballTaskData.IsFinished);
				}
				if (text != null)
				{
					text.SetUIActive(pinballTaskData.IsDoing);
				}
				if (pinballTaskData.IsDoing)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Pinball_Reward_Limited_bigaward", Array.Empty<object>());
				}
				if (button != null)
				{
					bool flag;
					if (pinballTaskData.IsUnclaimed)
					{
						ConditionTask data = pinballTaskData.Data;
						if (data == null)
						{
							flag = false;
						}
						else
						{
							int id = data.Id;
							flag = true;
						}
					}
					else
					{
						flag = false;
					}
					bool flag2 = flag;
					UUIItem uuiitem = button.RootUIComp.Get();
					if (uuiitem != null)
					{
						uuiitem.SetUIActive(flag2);
					}
					button.SetSelfInteractive(flag2);
					return;
				}
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(9);
				if (button2 != null)
				{
					UUIItem uuiitem2 = button2.RootUIComp.Get();
					if (uuiitem2 != null)
					{
						uuiitem2.SetUIActive(false);
					}
				}
				if (item != null)
				{
					item.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
		}

		// Token: 0x06040FB8 RID: 266168 RVA: 0x010AC958 File Offset: 0x010AAB58
		private void RefreshProgress()
		{
			PinballTaskData pinballTaskData = null;
			foreach (PinballTaskData pinballTaskData2 in this.ActivityData.GetTimeLimitTaskList())
			{
				if (pinballTaskData2.TaskTab == EPinballTaskTab.BigReward)
				{
					pinballTaskData = pinballTaskData2;
					break;
				}
			}
			int num = (pinballTaskData != null) ? pinballTaskData.Target : 0;
			int num2 = (pinballTaskData != null) ? pinballTaskData.Current : 0;
			int num3 = (num > 0) ? Math.Min(num2, num) : num2;
			UUIText text = base.GetText(8);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			float fillAmount = (num > 0) ? ((float)num3 / (float)num) : 0f;
			UUISprite sprite = base.GetSprite(10);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(fillAmount);
		}

		// Token: 0x06040FB9 RID: 266169 RVA: 0x010ACA4C File Offset: 0x010AAC4C
		private PinballLimitedRewardTaskItem CreateTaskItem()
		{
			return new PinballLimitedRewardTaskItem
			{
				OnTaskRewardClick = new Func<int, UniTask>(this.OnTaskRewardBtnClick)
			};
		}

		// Token: 0x06040FBA RID: 266170 RVA: 0x010ACA68 File Offset: 0x010AAC68
		private UniTask OnTaskRewardBtnClick(int taskId)
		{
			PinballLimitedRewardView.<OnTaskRewardBtnClick>d__17 <OnTaskRewardBtnClick>d__;
			<OnTaskRewardBtnClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnTaskRewardBtnClick>d__.<>4__this = this;
			<OnTaskRewardBtnClick>d__.<>1__state = -1;
			<OnTaskRewardBtnClick>d__.<>t__builder.Start<PinballLimitedRewardView.<OnTaskRewardBtnClick>d__17>(ref <OnTaskRewardBtnClick>d__);
			return <OnTaskRewardBtnClick>d__.<>t__builder.Task;
		}

		// Token: 0x06040FBB RID: 266171 RVA: 0x010ACAAC File Offset: 0x010AACAC
		private void OnBigRewardBtnClick()
		{
			UiAsyncTask task = new UiAsyncTask("PinballLimitedRewardView.RequestBigReward", delegate()
			{
				PinballLimitedRewardView.<<OnBigRewardBtnClick>b__18_0>d <<OnBigRewardBtnClick>b__18_0>d;
				<<OnBigRewardBtnClick>b__18_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnBigRewardBtnClick>b__18_0>d.<>4__this = this;
				<<OnBigRewardBtnClick>b__18_0>d.<>1__state = -1;
				<<OnBigRewardBtnClick>b__18_0>d.<>t__builder.Start<PinballLimitedRewardView.<<OnBigRewardBtnClick>b__18_0>d>(ref <<OnBigRewardBtnClick>b__18_0>d);
				return <<OnBigRewardBtnClick>b__18_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06040FBC RID: 266172 RVA: 0x010ACADD File Offset: 0x010AACDD
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040FBD RID: 266173 RVA: 0x010ACAE8 File Offset: 0x010AACE8
		private void OnPreviewBtnClick()
		{
			PinballActivityData activityData = this.ActivityData;
			int num = (activityData != null) ? activityData.GetTitleTipId() : 0;
			if (num > 0)
			{
				ControllerBase<ItemController>.Instance.OpenTitleTipsByItemId(num);
			}
		}

		// Token: 0x06040FBE RID: 266174 RVA: 0x010ACB18 File Offset: 0x010AAD18
		private void OnBigRewardItemTipsClick()
		{
			int bigRewardFirstItemConfigId = this.GetBigRewardFirstItemConfigId();
			if (bigRewardFirstItemConfigId > 0)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(bigRewardFirstItemConfigId, true, null);
			}
		}

		// Token: 0x04024715 RID: 149269
		[Nullable(2)]
		private PinballActivityData ActivityData;

		// Token: 0x04024716 RID: 149270
		private GenericScrollViewNew<PinballLimitedRewardTaskItem, PinballTaskData> TaskLayout;

		// Token: 0x0200C583 RID: 50563
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403CC99 RID: 248985
			ItemCaption,
			// Token: 0x0403CC9A RID: 248986
			RewardItemScroll,
			// Token: 0x0403CC9B RID: 248987
			RewardItem,
			// Token: 0x0403CC9C RID: 248988
			BtnCommon,
			// Token: 0x0403CC9D RID: 248989
			TxtTime,
			// Token: 0x0403CC9E RID: 248990
			TextureIcon,
			// Token: 0x0403CC9F RID: 248991
			TxName,
			// Token: 0x0403CCA0 RID: 248992
			TxMission,
			// Token: 0x0403CCA1 RID: 248993
			TxNum,
			// Token: 0x0403CCA2 RID: 248994
			BtnConfirmBase,
			// Token: 0x0403CCA3 RID: 248995
			SpBar,
			// Token: 0x0403CCA4 RID: 248996
			PanelBigRewardUndone,
			// Token: 0x0403CCA5 RID: 248997
			PanelBigRewardDone,
			// Token: 0x0403CCA6 RID: 248998
			BtnMonsterHead
		}
	}
}
