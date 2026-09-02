using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061CF RID: 25039
	[NullableContext(1)]
	[Nullable(0)]
	public class GuQinActivityMainView : UiViewBase
	{
		// Token: 0x0603F2DE RID: 258782 RVA: 0x010379AE File Offset: 0x01035BAE
		public GuQinActivityMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603F2DF RID: 258783 RVA: 0x010379D0 File Offset: 0x01035BD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnReceivedBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F2E0 RID: 258784 RVA: 0x01037CD8 File Offset: 0x01035ED8
		protected override UniTask OnBeforeStartAsync()
		{
			GuQinActivityMainView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GuQinActivityMainView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F2E1 RID: 258785 RVA: 0x01037D1C File Offset: 0x01035F1C
		protected override void OnStart()
		{
			int index = 0;
			int num = -1;
			foreach (KeyValuePair<int, GuQinActivityTabData> keyValuePair in this.Data.GetTabDataMap())
			{
				int num2;
				GuQinActivityTabData guQinActivityTabData;
				keyValuePair.Deconstruct(out num2, out guQinActivityTabData);
				int num3 = num2;
				GuQinActivityTabData guQinActivityTabData2 = guQinActivityTabData;
				if (guQinActivityTabData2.GetStatus() != EGuQinActivityTabStatus.Lock)
				{
					index = num3;
				}
				using (List<GuQinActivityTaskData>.Enumerator enumerator2 = guQinActivityTabData2.TaskList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GetStatus() == EGuQinActivityTaskStatus.Progressing)
						{
							num = num3;
						}
					}
				}
			}
			if (num >= 0)
			{
				index = num;
			}
			this.ToggleItems[index].SetToggleState(EToggleState.ETT_Checked, true);
		}

		// Token: 0x0603F2E2 RID: 258786 RVA: 0x01037DEC File Offset: 0x01035FEC
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => this.CurrentTaskData.Rewarded)
			};
		}

		// Token: 0x0603F2E3 RID: 258787 RVA: 0x01037E05 File Offset: 0x01036005
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityRefresh));
		}

		// Token: 0x0603F2E4 RID: 258788 RVA: 0x01037E23 File Offset: 0x01036023
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityRefresh));
		}

		// Token: 0x0603F2E5 RID: 258789 RVA: 0x01037E44 File Offset: 0x01036044
		private void OnActivityRefresh(int activityId)
		{
			if (activityId != this.Data.Id)
			{
				return;
			}
			foreach (GuQinActivityMainViewToggleItem guQinActivityMainViewToggleItem in this.ToggleItems)
			{
				guQinActivityMainViewToggleItem.RefreshDisplay(guQinActivityMainViewToggleItem == this.CurrentSelectToggleItem);
			}
			GuQinActivityMainViewToggleItem currentSelectToggleItem = this.CurrentSelectToggleItem;
			GuQinActivityTabData guQinActivityTabData = (currentSelectToggleItem != null) ? currentSelectToggleItem.Data : null;
			if (guQinActivityTabData != null)
			{
				this.RefreshSubToggles(guQinActivityTabData);
			}
			if (this.CurrentTaskData != null)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x0603F2E6 RID: 258790 RVA: 0x01037ED8 File Offset: 0x010360D8
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603F2E7 RID: 258791 RVA: 0x01037EE1 File Offset: 0x010360E1
		private void OnHelpBtnClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(655);
		}

		// Token: 0x0603F2E8 RID: 258792 RVA: 0x01037EF4 File Offset: 0x010360F4
		private void FocusBackToSelectedToggle()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			GuQinActivityMainViewToggleItem currentSelectToggleItem = this.CurrentSelectToggleItem;
			if (currentSelectToggleItem == null)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(currentSelectToggleItem.GetRootItem(), true, true, false);
		}

		// Token: 0x0603F2E9 RID: 258793 RVA: 0x01037F30 File Offset: 0x01036130
		private void OnToggleSelect(GuQinActivityMainViewToggleItem item, GuQinActivityTabData data)
		{
			GuQinActivityMainViewToggleItem currentSelectToggleItem = this.CurrentSelectToggleItem;
			if (currentSelectToggleItem != null)
			{
				currentSelectToggleItem.SetToggleState(EToggleState.ETT_UnChecked, true);
			}
			this.CurrentSelectToggleItem = item;
			this.CurrentSelectSubToggleItem = null;
			int index = 0;
			for (int i = 0; i < data.TaskList.Count; i++)
			{
				this.SubToggleItems[i].SetToggleState(EToggleState.ETT_UnChecked, true);
				if (data.TaskList[i].GetStatus() > EGuQinActivityTaskStatus.Lock)
				{
					index = i;
				}
			}
			this.RefreshSubToggles(data);
			this.SubToggleItems[index].SetToggleState(EToggleState.ETT_Checked, true);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x0603F2EA RID: 258794 RVA: 0x01037FD8 File Offset: 0x010361D8
		private void RefreshSubToggles(GuQinActivityTabData data)
		{
			for (int i = 0; i < data.TaskList.Count; i++)
			{
				this.SubToggleItems[i].Refresh(data.TaskList[i]);
			}
			if (data.TaskList.Count < 2)
			{
				base.GetItem(5).SetUIActive(false);
				return;
			}
			base.GetItem(5).SetUIActive(true);
			int openDay = data.TaskList[0].GetConfig().OpenDay;
			base.GetText(6).SetText(openDay.ToString(), true);
			base.GetText(7).SetText((openDay + 3).ToString(), true);
		}

		// Token: 0x0603F2EB RID: 258795 RVA: 0x01038088 File Offset: 0x01036288
		private void OnSubToggleSelect(GuQinActivityMainViewSubToggleItem item, GuQinActivityTaskData data)
		{
			GuQinActivityMainViewSubToggleItem currentSelectSubToggleItem = this.CurrentSelectSubToggleItem;
			if (currentSelectSubToggleItem != null)
			{
				currentSelectSubToggleItem.SetToggleState(EToggleState.ETT_UnChecked, true);
			}
			this.CurrentSelectSubToggleItem = item;
			this.CurrentTaskData = data;
			this.RefreshUi();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch2", false, null);
		}

		// Token: 0x0603F2EC RID: 258796 RVA: 0x010380DC File Offset: 0x010362DC
		private void RefreshUi()
		{
			GuQinActivityTask config = this.CurrentTaskData.GetConfig();
			Dictionary<int, int> dictionary = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(config.RewardId).Value.DropPreview();
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int itemId = num;
				int count = num2;
				TItem item = new TItem(new InventoryDefine.GetItemData(itemId, 0), count);
				list.Add(item);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				rewardLayout.RefreshByData(list, null, false);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(10), config.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(11), config.Desc, Array.Empty<object>());
			base.TrySetTextureByPath(config.BgPath, base.GetTexture(18), null, null);
			EGuQinActivityTaskStatus status = this.CurrentTaskData.GetStatus();
			base.GetItem(14).SetUIActive(this.CurrentTaskData.Rewarded);
			base.GetItem(15).SetUIActive(status == EGuQinActivityTaskStatus.Progressing);
			base.GetButton(16).RootUIComp.Get().SetUIActive(status == EGuQinActivityTaskStatus.Completed && !this.CurrentTaskData.Rewarded);
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent != null)
			{
				FunctionalPanelConditionActivate panelActivate = functionalComponent.PanelActivate;
				if (panelActivate != null)
				{
					panelActivate.SetUiActive(status == EGuQinActivityTaskStatus.Completed);
				}
			}
			ActivityFunctionalTypeA functionalComponent2 = this.FunctionalComponent;
			if (functionalComponent2 != null)
			{
				ActivityButtonItem functionButton = functionalComponent2.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetUiActive(status != EGuQinActivityTaskStatus.Completed);
				}
			}
			ActivityFunctionalTypeA functionalComponent3 = this.FunctionalComponent;
			if (functionalComponent3 == null)
			{
				return;
			}
			ActivityButtonItem functionButton2 = functionalComponent3.FunctionButton;
			if (functionButton2 == null)
			{
				return;
			}
			functionButton2.SetRedDotVisible(this.CurrentTaskData.GetIsUnlockRedDot());
		}

		// Token: 0x0603F2ED RID: 258797 RVA: 0x010382C4 File Offset: 0x010364C4
		private void OnReceivedBtnClick()
		{
			ControllerBase<GuQinActivityController>.Instance.RequestReward(this.CurrentTaskData, new Action(this.OnRewardSuccess));
		}

		// Token: 0x0603F2EE RID: 258798 RVA: 0x010382E2 File Offset: 0x010364E2
		private void OnRewardSuccess()
		{
			this.RefreshUi();
			this.RefreshRedDot();
		}

		// Token: 0x0603F2EF RID: 258799 RVA: 0x010382F0 File Offset: 0x010364F0
		private void OnGotoBtnClick()
		{
			int questId = this.CurrentTaskData.GetConfig().QuestId;
			this.Data.RemoveNewQuestRedDot(this.CurrentTaskData.Id);
			this.RefreshRedDot();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, questId, null);
		}

		// Token: 0x0603F2F0 RID: 258800 RVA: 0x01038344 File Offset: 0x01036544
		private void RefreshRedDot()
		{
			foreach (GuQinActivityMainViewToggleItem guQinActivityMainViewToggleItem in this.ToggleItems)
			{
				guQinActivityMainViewToggleItem.RefreshRedDot();
			}
			foreach (GuQinActivityMainViewSubToggleItem guQinActivityMainViewSubToggleItem in this.SubToggleItems)
			{
				guQinActivityMainViewSubToggleItem.RefreshRedDot();
			}
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functionalComponent.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetRedDotVisible(this.CurrentTaskData.GetIsUnlockRedDot());
		}

		// Token: 0x040237C6 RID: 145350
		private const int ToggleCount = 4;

		// Token: 0x040237C7 RID: 145351
		private const int SubToggleCount = 2;

		// Token: 0x040237C8 RID: 145352
		private GuQinActivityData Data;

		// Token: 0x040237C9 RID: 145353
		[Nullable(2)]
		private GuQinActivityMainViewToggleItem CurrentSelectToggleItem;

		// Token: 0x040237CA RID: 145354
		[Nullable(2)]
		private GuQinActivityMainViewSubToggleItem CurrentSelectSubToggleItem;

		// Token: 0x040237CB RID: 145355
		private GuQinActivityTaskData CurrentTaskData;

		// Token: 0x040237CC RID: 145356
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040237CD RID: 145357
		[Nullable(2)]
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x040237CE RID: 145358
		private readonly List<GuQinActivityMainViewToggleItem> ToggleItems = new List<GuQinActivityMainViewToggleItem>();

		// Token: 0x040237CF RID: 145359
		private readonly List<GuQinActivityMainViewSubToggleItem> SubToggleItems = new List<GuQinActivityMainViewSubToggleItem>();

		// Token: 0x040237D0 RID: 145360
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0200C30D RID: 49933
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C1E0 RID: 246240
			public const int CaptionItem = 0;

			// Token: 0x0403C1E1 RID: 246241
			public const int Toggle1 = 1;

			// Token: 0x0403C1E2 RID: 246242
			public const int Toggle2 = 2;

			// Token: 0x0403C1E3 RID: 246243
			public const int Toggle3 = 3;

			// Token: 0x0403C1E4 RID: 246244
			public const int Toggle4 = 4;

			// Token: 0x0403C1E5 RID: 246245
			public const int PnlBottom = 5;

			// Token: 0x0403C1E6 RID: 246246
			public const int TextNumLeft = 6;

			// Token: 0x0403C1E7 RID: 246247
			public const int TextNumRight = 7;

			// Token: 0x0403C1E8 RID: 246248
			public const int SubToggle1 = 8;

			// Token: 0x0403C1E9 RID: 246249
			public const int SubToggle2 = 9;

			// Token: 0x0403C1EA RID: 246250
			public const int TextTitle = 10;

			// Token: 0x0403C1EB RID: 246251
			public const int TextDesc = 11;

			// Token: 0x0403C1EC RID: 246252
			public const int RewardLayout = 12;

			// Token: 0x0403C1ED RID: 246253
			public const int RewardLayoutItem = 13;

			// Token: 0x0403C1EE RID: 246254
			public const int PnlDone = 14;

			// Token: 0x0403C1EF RID: 246255
			public const int PnlUnDone = 15;

			// Token: 0x0403C1F0 RID: 246256
			public const int BtnReceived = 16;

			// Token: 0x0403C1F1 RID: 246257
			public const int FunctionTypeItem = 17;

			// Token: 0x0403C1F2 RID: 246258
			public const int TexBg = 18;

			// Token: 0x0403C1F3 RID: 246259
			public const int RewardRedDot = 19;
		}
	}
}
