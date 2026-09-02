using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061F0 RID: 25072
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityInstanceEntranceView : UiTickViewBase
	{
		// Token: 0x0603F41F RID: 259103 RVA: 0x0103C31A File Offset: 0x0103A51A
		[NullableContext(1)]
		public ActivityInstanceEntranceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F420 RID: 259104 RVA: 0x0103C324 File Offset: 0x0103A524
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F421 RID: 259105 RVA: 0x0103C478 File Offset: 0x0103A678
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityInstanceEntranceView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityInstanceEntranceView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F422 RID: 259106 RVA: 0x0103C4BB File Offset: 0x0103A6BB
		[NullableContext(1)]
		private ActivityInstanceEntranceScrollItem CreateInstanceGrid(ActivityEntranceItemData data, UUIItem uiItem, int index)
		{
			return new ActivityInstanceEntranceScrollItem();
		}

		// Token: 0x0603F423 RID: 259107 RVA: 0x0103C4C2 File Offset: 0x0103A6C2
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent("Close01", new Action<string>(this.FinishCloseSequenceEvent), false);
		}

		// Token: 0x0603F424 RID: 259108 RVA: 0x0103C4E1 File Offset: 0x0103A6E1
		[NullableContext(1)]
		private void FinishCloseSequenceEvent(string _)
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
		}

		// Token: 0x0603F425 RID: 259109 RVA: 0x0103C4FC File Offset: 0x0103A6FC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshActivityEntranceScroller, new Action<int>(this.OnSelectActivityEntranceScrollItem));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshActivityEntranceItemContent, new Action<int>(this.OnRefreshActivityEntranceItemContent));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshInstancedRecommendLevel, new Action(this.OnRefreshInstancedRecommendLevel));
		}

		// Token: 0x0603F426 RID: 259110 RVA: 0x0103C560 File Offset: 0x0103A760
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshActivityEntranceScroller, new Action<int>(this.OnSelectActivityEntranceScrollItem));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshActivityEntranceItemContent, new Action<int>(this.OnRefreshActivityEntranceItemContent));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshInstancedRecommendLevel, new Action(this.OnRefreshInstancedRecommendLevel));
		}

		// Token: 0x0603F427 RID: 259111 RVA: 0x0103C5C1 File Offset: 0x0103A7C1
		private void OnRefreshInstancedRecommendLevel()
		{
			ActivityInstanceEntranceInfoItem activityInstanceEntranceInfoItem = this.ActivityInstanceEntranceInfoItem;
			if (activityInstanceEntranceInfoItem != null)
			{
				activityInstanceEntranceInfoItem.RefreshDropDownItem(this.ViewData).Forget();
			}
			ActivityInstanceEntranceInfoItem activityInstanceEntranceInfoItem2 = this.ActivityInstanceEntranceInfoItem;
			if (activityInstanceEntranceInfoItem2 == null)
			{
				return;
			}
			activityInstanceEntranceInfoItem2.RefreshRecommendLevelItem(this.ViewData).Forget();
		}

		// Token: 0x0603F428 RID: 259112 RVA: 0x0103C5FC File Offset: 0x0103A7FC
		private void OnRefreshActivityEntranceItemContent(int uiIndex)
		{
			this.CurrentSelectMainUiIndex = uiIndex;
			this.UpdateScrollView();
			this.CheckAndShowDungeonArchiveExpireTips();
			ActivityInstanceEntranceInfoItem activityInstanceEntranceInfoItem = this.ActivityInstanceEntranceInfoItem;
			if (activityInstanceEntranceInfoItem != null)
			{
				activityInstanceEntranceInfoItem.RefreshView(this.ViewData);
			}
			this.UiViewSequence.PlaySequence("Xz", false, null);
		}

		// Token: 0x0603F429 RID: 259113 RVA: 0x0103C650 File Offset: 0x0103A850
		private void OnSelectActivityEntranceScrollItem(int uiIndex)
		{
			this.CurrentSelectMainUiIndex = uiIndex;
			this.RefreshScrollView();
			ActivityInstanceEntranceInfoItem activityInstanceEntranceInfoItem = this.ActivityInstanceEntranceInfoItem;
			if (activityInstanceEntranceInfoItem != null)
			{
				activityInstanceEntranceInfoItem.RefreshView(this.ViewData);
			}
			this.UpdateInstanceBg(this.ViewData);
			this.UiViewSequence.PlaySequence("Xz", false, null);
		}

		// Token: 0x0603F42A RID: 259114 RVA: 0x0103C6A7 File Offset: 0x0103A8A7
		private void OnClickCaptionStateBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(242);
		}

		// Token: 0x0603F42B RID: 259115 RVA: 0x0103C6B8 File Offset: 0x0103A8B8
		protected override void OnBeforeShow()
		{
			this.RefreshScrollView();
		}

		// Token: 0x0603F42C RID: 259116 RVA: 0x0103C6C0 File Offset: 0x0103A8C0
		protected override void OnAfterShow()
		{
			this.CheckAndShowDungeonArchiveExpireTips();
		}

		// Token: 0x0603F42D RID: 259117 RVA: 0x0103C6C8 File Offset: 0x0103A8C8
		private void CheckAndShowDungeonArchiveExpireTips()
		{
			ActivityEntranceSelectItemData activityEntranceSelectItemData = this.ViewData.GetActivityEntranceSelectItemData();
			ActivityEntranceItemData activityEntranceItemData = (activityEntranceSelectItemData != null) ? activityEntranceSelectItemData.GetCurrentSelectData() : null;
			int dungeonId = (activityEntranceItemData != null) ? activityEntranceItemData.GetInstanceDungeonId() : 0;
			ControllerBase<InstanceDungeonController>.Instance.CheckAndShowDungeonArchiveExpireTips(dungeonId);
		}

		// Token: 0x0603F42E RID: 259118 RVA: 0x0103C704 File Offset: 0x0103A904
		private void RefreshCaptionItemByData(ActivityEntranceCaptionItemData captionData)
		{
			this.InstanceDungeonCaptionItem.SetCloseCallBack(new Action(this.OnClickBtnClose));
			if (captionData != null)
			{
				PopupCaptionItem instanceDungeonCaptionItem = this.InstanceDungeonCaptionItem;
				if (instanceDungeonCaptionItem != null)
				{
					instanceDungeonCaptionItem.SetUiActive(true);
				}
				PopupCaptionItem instanceDungeonCaptionItem2 = this.InstanceDungeonCaptionItem;
				if (instanceDungeonCaptionItem2 != null)
				{
					instanceDungeonCaptionItem2.SetTitleByTextIdAndArgNew(captionData.GetName(), Array.Empty<object>());
				}
				string titleSpritePath = captionData.GetTitleSpritePath();
				if (!string.IsNullOrEmpty(titleSpritePath))
				{
					this.InstanceDungeonCaptionItem.SetTitleIconVisible(true);
					this.InstanceDungeonCaptionItem.SetTitleIcon(titleSpritePath);
				}
				else
				{
					this.InstanceDungeonCaptionItem.SetTitleIconVisible(false);
				}
				int helpId = captionData.GetHelpId();
				this.InstanceDungeonCaptionItem.SetHelpBtnActive(helpId != 0);
				this.InstanceDungeonCaptionItem.SetHelpCallBack(delegate
				{
					int helpId2 = this.ViewData.GetActivityEntranceCaptionItemData().GetHelpId();
					ControllerBase<HelpController>.Instance.OpenHelpById(helpId2);
				});
				return;
			}
			PopupCaptionItem instanceDungeonCaptionItem3 = this.InstanceDungeonCaptionItem;
			if (instanceDungeonCaptionItem3 == null)
			{
				return;
			}
			instanceDungeonCaptionItem3.SetUiActive(false);
		}

		// Token: 0x0603F42F RID: 259119 RVA: 0x0103C7D0 File Offset: 0x0103A9D0
		private void RefreshCaptionStateItemByData(ActivityEntranceItemData entranceItemData)
		{
			int dungeonId = (entranceItemData != null) ? entranceItemData.GetInstanceDungeonId() : 0;
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveActivate(dungeonId);
			this.InstanceDungeonCaptionItem.SetCaptionStateActive(flag && entranceItemData != null);
			this.InstanceDungeonCaptionItem.SetCaptionChangeColor(false);
			if (flag)
			{
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.HasDungeonArchive(dungeonId))
				{
					this.InstanceDungeonCaptionItem.SetCaptionStateTip("instance_HaveRecord");
					this.InstanceDungeonCaptionItem.SetCaptionChangeColor(true);
					return;
				}
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonSupportAndWithoutArchive(dungeonId))
				{
					this.InstanceDungeonCaptionItem.SetCaptionStateTip("instance_Record_leave");
				}
			}
		}

		// Token: 0x0603F430 RID: 259120 RVA: 0x0103C864 File Offset: 0x0103AA64
		private void UpdateInstanceBg(ActivityInstanceEntranceData data)
		{
			if (data == null || data.GetActivityEntranceSelectItemData() == null)
			{
				UUITexture texture = base.GetTexture(3);
				if (texture == null)
				{
					return;
				}
				texture.SetUIActive(false);
				return;
			}
			else
			{
				ActivityEntranceItemData currentSelectData = data.GetActivityEntranceSelectItemData().GetCurrentSelectData();
				string text = (currentSelectData != null) ? currentSelectData.GetBgPath() : null;
				if (!string.IsNullOrEmpty(text))
				{
					base.SetTextureByPath(text, base.GetTexture(3), null, null);
					return;
				}
				UUITexture texture2 = base.GetTexture(3);
				if (texture2 == null)
				{
					return;
				}
				texture2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603F431 RID: 259121 RVA: 0x0103C8DA File Offset: 0x0103AADA
		private void RefreshScoreItem(ActivityEntrancePointData data)
		{
			if (data == null)
			{
				return;
			}
			ActivityInstanceEntranceScoreItem activityInstanceEntranceScoreItem = this.ActivityInstanceEntranceScoreItem;
			if (activityInstanceEntranceScoreItem != null)
			{
				activityInstanceEntranceScoreItem.SetActive(true);
			}
			ActivityInstanceEntranceScoreItem activityInstanceEntranceScoreItem2 = this.ActivityInstanceEntranceScoreItem;
			if (activityInstanceEntranceScoreItem2 == null)
			{
				return;
			}
			activityInstanceEntranceScoreItem2.RefreshView(data);
		}

		// Token: 0x0603F432 RID: 259122 RVA: 0x0103C903 File Offset: 0x0103AB03
		private void OnClickBtnClose()
		{
			this.UiViewSequence.PlaySequencePurely("Close01", true, false);
		}

		// Token: 0x0603F433 RID: 259123 RVA: 0x0103C918 File Offset: 0x0103AB18
		private void RefreshScrollView()
		{
			IReadOnlyList<ActivityEntranceItemData> showDataBySelectElement = this.ViewData.GetActivityEntranceSelectItemData().GetShowDataBySelectElement(this.CurrentSelectMainUiIndex, 0);
			foreach (ActivityEntranceItemData activityEntranceItemData in showDataBySelectElement)
			{
				if (activityEntranceItemData.GetSelectState())
				{
					Action<int> selectCallBack = activityEntranceItemData.GetSelectCallBack();
					if (selectCallBack != null)
					{
						selectCallBack(activityEntranceItemData.GetSelectDataIndex());
					}
				}
			}
			this.InstanceLoopScroll.RefreshByData(showDataBySelectElement, false, false);
		}

		// Token: 0x0603F434 RID: 259124 RVA: 0x0103C9A0 File Offset: 0x0103ABA0
		private void UpdateScrollView()
		{
			IReadOnlyList<ActivityEntranceItemData> showDataBySelectElement = this.ViewData.GetActivityEntranceSelectItemData().GetShowDataBySelectElement(this.CurrentSelectMainUiIndex, 0);
			for (int i = 0; i < this.InstanceLoopScroll.GetScrollItemCount(); i++)
			{
				DynamicScrollView<ActivityInstanceEntranceScrollItem, ActivityInstanceEntranceDynItem, ActivityEntranceItemData> instanceLoopScroll = this.InstanceLoopScroll;
				ActivityInstanceEntranceScrollItem activityInstanceEntranceScrollItem = (instanceLoopScroll != null) ? instanceLoopScroll.GetScrollItemFromIndex(i) : null;
				if (activityInstanceEntranceScrollItem != null)
				{
					activityInstanceEntranceScrollItem.Update(showDataBySelectElement[i], i);
				}
			}
		}

		// Token: 0x0603F435 RID: 259125 RVA: 0x0103CA01 File Offset: 0x0103AC01
		protected override void OnBeforeDestroy()
		{
			if (this.InstanceLoopScroll != null)
			{
				this.InstanceLoopScroll.ClearChildren();
				this.InstanceLoopScroll = null;
			}
		}

		// Token: 0x04023836 RID: 145462
		private ActivityInstanceEntranceData ViewData;

		// Token: 0x04023837 RID: 145463
		private ActivityInstanceEntranceInfoItem ActivityInstanceEntranceInfoItem;

		// Token: 0x04023838 RID: 145464
		private PopupCaptionItem InstanceDungeonCaptionItem;

		// Token: 0x04023839 RID: 145465
		private ActivityInstanceEntranceScoreItem ActivityInstanceEntranceScoreItem;

		// Token: 0x0402383A RID: 145466
		private int CurrentSelectMainUiIndex;

		// Token: 0x0402383B RID: 145467
		private ActivityInstanceEntranceDynItem InstanceDetectDynamicItem;

		// Token: 0x0402383C RID: 145468
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<ActivityInstanceEntranceScrollItem, ActivityInstanceEntranceDynItem, ActivityEntranceItemData> InstanceLoopScroll;

		// Token: 0x0200C333 RID: 49971
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403C294 RID: 246420
			DynScrollView,
			// Token: 0x0403C295 RID: 246421
			ScrollItem,
			// Token: 0x0403C296 RID: 246422
			UiItemEntrance,
			// Token: 0x0403C297 RID: 246423
			TextureInstanceBG,
			// Token: 0x0403C298 RID: 246424
			TopItem,
			// Token: 0x0403C299 RID: 246425
			ContentItem,
			// Token: 0x0403C29A RID: 246426
			CaptionItem,
			// Token: 0x0403C29B RID: 246427
			TimeAndCountItem,
			// Token: 0x0403C29C RID: 246428
			LeftRewardItem
		}
	}
}
