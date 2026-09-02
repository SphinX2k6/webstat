using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x02006703 RID: 26371
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorDecalLinkQuestItem : GridProxyAbstract<MotorDecalLinkQuestViewModel>
	{
		// Token: 0x06041CF1 RID: 269553 RVA: 0x010E2904 File Offset: 0x010E0B04
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickReceive)),
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickSkip))
			};
		}

		// Token: 0x06041CF2 RID: 269554 RVA: 0x010E2A07 File Offset: 0x010E0C07
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(6), new Func<ActivitySmallItemGrid>(this.InitRewardGridItem), null, false, null);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x06041CF3 RID: 269555 RVA: 0x010E2A37 File Offset: 0x010E0C37
		private ActivitySmallItemGrid InitRewardGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x06041CF4 RID: 269556 RVA: 0x010E2A40 File Offset: 0x010E0C40
		private void OnClickReceive()
		{
			MotorDecalLinkUtil.Debug("OnClickReceive", default(ReadOnlySpan<ValueTuple<string, object>>));
			MotorDecalLinkQuestViewModel currentQuestViewModel = this.CurrentQuestViewModel;
			if (currentQuestViewModel == null)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(1);
			button.SetSelfInteractive(false);
			ControllerBase<MotorDecalLinkController>.Instance.ReceiveRewardByIpRequest(currentQuestViewModel.ActivityId, currentQuestViewModel.IpId).ContinueWith(delegate()
			{
				button.SetSelfInteractive(true);
			}).Forget();
		}

		// Token: 0x06041CF5 RID: 269557 RVA: 0x010E2AB8 File Offset: 0x010E0CB8
		private void OnClickSkip()
		{
			MotorDecalLinkQuestViewModel currentQuestViewModel = this.CurrentQuestViewModel;
			if (currentQuestViewModel == null || currentQuestViewModel.AccessId == 0)
			{
				return;
			}
			SkipTaskManager.RunByConfigId(currentQuestViewModel.AccessId, null);
			AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(currentQuestViewModel.AccessId);
			if (accessPathConfig != null && accessPathConfig.Value.SkipName == 17)
			{
				Singleton<UiManager>.Instance.CloseHistoryRingView(EUiViewName.CommonActivityView, null);
			}
		}

		// Token: 0x06041CF6 RID: 269558 RVA: 0x010E2B24 File Offset: 0x010E0D24
		public override void Refresh(MotorDecalLinkQuestViewModel questViewModel, bool isSelected, int gridIndex)
		{
			this.CurrentQuestViewModel = questViewModel;
			this.RefreshRewardPreview();
			this.RefreshQuestInfo(questViewModel);
			EMotorDecalQuestState motorDecalQuestState = this.GetMotorDecalQuestState(questViewModel);
			this.RefreshButtonState(motorDecalQuestState);
		}

		// Token: 0x06041CF7 RID: 269559 RVA: 0x010E2B54 File Offset: 0x010E0D54
		private void RefreshRewardPreview()
		{
			MotorDecalLinkQuestViewModel currentQuestViewModel = this.CurrentQuestViewModel;
			if (currentQuestViewModel == null)
			{
				return;
			}
			bool hasClaimed = currentQuestViewModel.Status == EActivityTaskState.FinishedAndClaimed;
			List<IItemGridData> rewardGridDataList = this.GetRewardGridDataList(currentQuestViewModel.RewardInfo, hasClaimed);
			GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView == null)
			{
				return;
			}
			rewardScrollView.RefreshByData(rewardGridDataList, null, false);
		}

		// Token: 0x06041CF8 RID: 269560 RVA: 0x010E2B98 File Offset: 0x010E0D98
		private List<IItemGridData> GetRewardGridDataList(Dictionary<int, int> rewardInfo, bool hasClaimed)
		{
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (KeyValuePair<int, int> keyValuePair in rewardInfo)
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
				list.Add(new ItemGridData
				{
					Item = item,
					HasClaimed = hasClaimed
				});
			}
			return list;
		}

		// Token: 0x06041CF9 RID: 269561 RVA: 0x010E2C1C File Offset: 0x010E0E1C
		private void RefreshQuestInfo(MotorDecalLinkQuestViewModel questViewModel)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), questViewModel.TaskName, Array.Empty<object>());
			if (questViewModel.Status == EActivityTaskState.FinishedAndClaimed)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "MotorLinkage_Quest_Completed", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "MotorLinkage_Quest_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				questViewModel.Current,
				questViewModel.Target
			}));
		}

		// Token: 0x06041CFA RID: 269562 RVA: 0x010E2CA8 File Offset: 0x010E0EA8
		private void RefreshButtonState(EMotorDecalQuestState state)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(state == EMotorDecalQuestState.Done);
			}
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == EMotorDecalQuestState.CanReceive);
			}
			UUIButtonComponent button2 = base.GetButton(0);
			if (button2 == null)
			{
				return;
			}
			button2.RootUIComp.Get().SetUIActive(state == EMotorDecalQuestState.ProgressCanSkip);
		}

		// Token: 0x06041CFB RID: 269563 RVA: 0x010E2D10 File Offset: 0x010E0F10
		private EMotorDecalQuestState GetMotorDecalQuestState(MotorDecalLinkQuestViewModel questViewModel)
		{
			if (questViewModel.Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				return EMotorDecalQuestState.CanReceive;
			}
			if (questViewModel.Status == EActivityTaskState.FinishedAndClaimed)
			{
				return EMotorDecalQuestState.Done;
			}
			if (questViewModel.AccessId != 0)
			{
				return EMotorDecalQuestState.ProgressCanSkip;
			}
			return EMotorDecalQuestState.Progress;
		}

		// Token: 0x04024B8F RID: 150415
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x04024B90 RID: 150416
		[Nullable(2)]
		private MotorDecalLinkQuestViewModel CurrentQuestViewModel;
	}
}
