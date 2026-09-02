using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components
{
	// Token: 0x02006569 RID: 25961
	public class PrizeDrawingQuestItem : UiPanelBase
	{
		// Token: 0x06040DCE RID: 265678 RVA: 0x010A2B78 File Offset: 0x010A0D78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSkip));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040DCF RID: 265679 RVA: 0x010A2CE4 File Offset: 0x010A0EE4
		private void OnClickSkip()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.CachedQuestId, null);
			ControllerBase<ActivityPrizeDrawingController>.Instance.ActivityData.ReadQuestRedDot();
			this.RefreshRedDot();
		}

		// Token: 0x06040DD0 RID: 265680 RVA: 0x010A2D18 File Offset: 0x010A0F18
		protected override UniTask OnBeforeStartAsync()
		{
			PrizeDrawingQuestItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PrizeDrawingQuestItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040DD1 RID: 265681 RVA: 0x010A2D5C File Offset: 0x010A0F5C
		public void RefreshFinishState(bool isFinished)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(isFinished);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(!isFinished);
			}
			base.GetButton(3).RootUIComp.Get().SetUIActive(!isFinished);
			UUIItem item3 = base.GetItem(6);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(isFinished);
		}

		// Token: 0x06040DD2 RID: 265682 RVA: 0x010A2DC1 File Offset: 0x010A0FC1
		public void RefreshByQuestId(int questId, int currentProgress, int targetProgress)
		{
			this.CachedQuestId = questId;
			this.RefreshQuestName(questId);
			this.RefreshSkipButton(questId);
			this.RefreshRewardPreview(questId);
			this.RefreshProgress(currentProgress, targetProgress);
			this.RefreshRedDot();
		}

		// Token: 0x06040DD3 RID: 265683 RVA: 0x010A2DF0 File Offset: 0x010A0FF0
		private void RefreshQuestName(int questId)
		{
			IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(questId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), questConfig.TidName, Array.Empty<object>());
		}

		// Token: 0x06040DD4 RID: 265684 RVA: 0x010A2E28 File Offset: 0x010A1028
		private void RefreshSkipButton(int questId)
		{
			bool flag = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(questId);
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!flag);
			}
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag);
		}

		// Token: 0x06040DD5 RID: 265685 RVA: 0x010A2E78 File Offset: 0x010A1078
		private void RefreshRewardPreview(int questId)
		{
			List<TItem> displayRewardCommonInfoFromQuestConfig = ModelBase<QuestNewModel>.Instance.GetDisplayRewardCommonInfoFromQuestConfig(questId);
			if (displayRewardCommonInfoFromQuestConfig == null || displayRewardCommonInfoFromQuestConfig.Count == 0)
			{
				return;
			}
			TItem titem = displayRewardCommonInfoFromQuestConfig[0];
			int itemId = titem.ItemData.ItemId;
			int count = titem.Count;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId),
				ItemConfigId = new int?(itemId),
				BottomText = ((count == 0) ? "" : count.ToString())
			};
			SmallItemGrid previewItemGrid = this.PreviewItemGrid;
			if (previewItemGrid != null)
			{
				previewItemGrid.Apply<PropSmallItemGrid>(parameters);
			}
			this.CachedPreviewRewardItemId = itemId;
		}

		// Token: 0x06040DD6 RID: 265686 RVA: 0x010A2F0E File Offset: 0x010A110E
		private void RefreshProgress(int currentProgress, int totalProgress)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Ichiban_Kuji_Progress_Task", new <>z__ReadOnlyArray<object>(new object[]
			{
				currentProgress,
				totalProgress
			}));
		}

		// Token: 0x06040DD7 RID: 265687 RVA: 0x010A2F44 File Offset: 0x010A1144
		private void RefreshRedDot()
		{
			bool flag = ControllerBase<ActivityPrizeDrawingController>.Instance.ActivityData.IsCurQuestReaded();
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!flag);
		}

		// Token: 0x06040DD8 RID: 265688 RVA: 0x010A2F76 File Offset: 0x010A1176
		[NullableContext(1)]
		private void OnClickReward(MediumItemGridExtendCallback callbackParameter)
		{
			if (this.CachedPreviewRewardItemId != -1)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CachedPreviewRewardItemId, true, null);
			}
		}

		// Token: 0x0402464B RID: 149067
		private int CachedQuestId = -1;

		// Token: 0x0402464C RID: 149068
		private int CachedPreviewRewardItemId = -1;

		// Token: 0x0402464D RID: 149069
		[Nullable(2)]
		private SmallItemGrid PreviewItemGrid;

		// Token: 0x0200C554 RID: 50516
		private enum EComp
		{
			// Token: 0x0403CBA2 RID: 248738
			TxtName,
			// Token: 0x0403CBA3 RID: 248739
			TxtProgress,
			// Token: 0x0403CBA4 RID: 248740
			ItemGrid,
			// Token: 0x0403CBA5 RID: 248741
			BtnSkip,
			// Token: 0x0403CBA6 RID: 248742
			PnlNormal,
			// Token: 0x0403CBA7 RID: 248743
			PnlFinish,
			// Token: 0x0403CBA8 RID: 248744
			PnlChecked,
			// Token: 0x0403CBA9 RID: 248745
			RedDot
		}
	}
}
