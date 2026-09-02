using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006711 RID: 26385
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorQuestItem : GridProxyAbstract<int>
	{
		// Token: 0x1700A09E RID: 41118
		// (get) Token: 0x06041D57 RID: 269655 RVA: 0x010E4215 File Offset: 0x010E2415
		private ActivityMotorLinkageData ActivityData
		{
			get
			{
				return ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData;
			}
		}

		// Token: 0x06041D58 RID: 269656 RVA: 0x010E4224 File Offset: 0x010E2424
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickReceive)),
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickSkip))
			};
		}

		// Token: 0x06041D59 RID: 269657 RVA: 0x010E4327 File Offset: 0x010E2527
		protected override void OnStart()
		{
			this.ItemScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.ItemProxyCreate), null, false, null);
		}

		// Token: 0x06041D5A RID: 269658 RVA: 0x010E434C File Offset: 0x010E254C
		private void OnClickReceive()
		{
			UUIButtonComponent button = base.GetButton(1);
			button.SetSelfInteractive(false);
			int ip = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfig(this.QuestId).Ip;
			ControllerBase<ActivityMotorLinkageController>.Instance.ReceiveAllRewardRequest(ip).ContinueWith(delegate()
			{
				button.SetSelfInteractive(true);
			}).Forget();
		}

		// Token: 0x06041D5B RID: 269659 RVA: 0x010E43B4 File Offset: 0x010E25B4
		private void OnClickSkip()
		{
			SkipTaskManager.RunByConfigId(ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfig(this.QuestId).AccessId, null);
		}

		// Token: 0x06041D5C RID: 269660 RVA: 0x010E43E0 File Offset: 0x010E25E0
		public override void Refresh(int questId, bool isSelected, int gridIndex)
		{
			bool flag = this.QuestId == questId;
			this.QuestId = questId;
			if (!flag)
			{
				this.RefreshRewardPreview(questId);
			}
			EMotorQuestState motorQuestState = this.GetMotorQuestState(questId);
			this.RefreshQuestInfo(questId);
			this.RefreshButtonState(motorQuestState);
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.ActivityData.IsQuestCanReceive(questId));
		}

		// Token: 0x06041D5D RID: 269661 RVA: 0x010E443C File Offset: 0x010E263C
		private void RefreshRewardPreview(int questId)
		{
			List<TItem> displayRewardCommonInfo = this.GetDisplayRewardCommonInfo(questId);
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> itemScrollView = this.ItemScrollView;
			if (itemScrollView == null)
			{
				return;
			}
			itemScrollView.RefreshByData(displayRewardCommonInfo, null, false);
		}

		// Token: 0x06041D5E RID: 269662 RVA: 0x010E4464 File Offset: 0x010E2664
		private List<TItem> GetDisplayRewardCommonInfo(int questId)
		{
			MotorLinkageQuest questConfig = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfig(questId);
			List<TItem> list = new List<TItem>();
			for (int i = 0; i < questConfig.RewardInfoLength; i++)
			{
				DicIntInt? dicIntInt = questConfig.RewardInfo(i);
				if (dicIntInt != null)
				{
					list.Add(new TItem(new InventoryDefine.GetItemData(dicIntInt.Value.Key, 0), dicIntInt.Value.Value));
				}
			}
			return list;
		}

		// Token: 0x06041D5F RID: 269663 RVA: 0x010E44DC File Offset: 0x010E26DC
		private void RefreshQuestInfo(int questId)
		{
			MotorLinkageQuest questConfig = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfig(questId);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(questConfig.TaskName);
			}
			if (!this.ActivityData.IsQuestRewardReceived(questId))
			{
				int questCurrentProgress = this.ActivityData.GetQuestCurrentProgress(questId);
				int questTargetProgress = this.ActivityData.GetQuestTargetProgress(questId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "MotorLinkage_Quest_Progress", new <>z__ReadOnlyArray<object>(new object[]
				{
					questCurrentProgress,
					questTargetProgress
				}));
				return;
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("MotorLinkage_Quest_Completed");
		}

		// Token: 0x06041D60 RID: 269664 RVA: 0x010E4580 File Offset: 0x010E2780
		private void RefreshButtonState(EMotorQuestState state)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(state == EMotorQuestState.Progress);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(state == EMotorQuestState.Done);
			}
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == EMotorQuestState.CanReceive);
			}
			UUIButtonComponent button2 = base.GetButton(0);
			if (button2 == null)
			{
				return;
			}
			button2.RootUIComp.Get().SetUIActive(state == EMotorQuestState.ProgressCanSkip);
		}

		// Token: 0x06041D61 RID: 269665 RVA: 0x010E4600 File Offset: 0x010E2800
		private EMotorQuestState GetMotorQuestState(int questId)
		{
			if (this.ActivityData.IsQuestCanReceive(questId))
			{
				return EMotorQuestState.CanReceive;
			}
			if (this.ActivityData.IsQuestRewardReceived(questId))
			{
				return EMotorQuestState.Done;
			}
			if (ConfigBase<ActivityMotorLinkageConfig>.Instance.GetQuestConfig(questId).AccessId != 0)
			{
				return EMotorQuestState.ProgressCanSkip;
			}
			return EMotorQuestState.Progress;
		}

		// Token: 0x06041D62 RID: 269666 RVA: 0x010E4645 File Offset: 0x010E2845
		private CommonItemSmallItemGrid ItemProxyCreate()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x04024BCA RID: 150474
		private int QuestId = -1;

		// Token: 0x04024BCB RID: 150475
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ItemScrollView;
	}
}
