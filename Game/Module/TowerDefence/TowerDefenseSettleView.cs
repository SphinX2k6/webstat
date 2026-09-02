using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE3 RID: 20195
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseSettleView : UiViewBase
	{
		// Token: 0x06034288 RID: 213640 RVA: 0x00D0ADBE File Offset: 0x00D08FBE
		public TowerDefenseSettleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034289 RID: 213641 RVA: 0x00D0ADD4 File Offset: 0x00D08FD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603428A RID: 213642 RVA: 0x00D0AEA1 File Offset: 0x00D090A1
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FriendApplyReceived, new Action(this.OnRefreshFriendApply));
		}

		// Token: 0x0603428B RID: 213643 RVA: 0x00D0AEBF File Offset: 0x00D090BF
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FriendApplyReceived, new Action(this.OnRefreshFriendApply));
		}

		// Token: 0x0603428C RID: 213644 RVA: 0x00D0AEE0 File Offset: 0x00D090E0
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseSettleView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseSettleView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603428D RID: 213645 RVA: 0x00D0AF23 File Offset: 0x00D09123
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			TowerDefenceEndNotify notify = this.GetNotify();
			uiViewSequence.StartSequenceName = ((notify != null && notify.Success) ? "Success" : "Fail");
		}

		// Token: 0x0603428E RID: 213646 RVA: 0x00D0AF50 File Offset: 0x00D09150
		protected override void OnAfterShow()
		{
			this.OnRefreshFriendApply();
		}

		// Token: 0x0603428F RID: 213647 RVA: 0x00D0AF58 File Offset: 0x00D09158
		protected override void OnBeforeDestroy()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendApplyView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendApplyView, null);
			}
		}

		// Token: 0x06034290 RID: 213648 RVA: 0x00D0AF7C File Offset: 0x00D0917C
		private void OnRefreshFriendApply()
		{
			List<int> list = ControllerBase<ItemRewardController>.Instance.BuildExploreFriendIdList();
			if (ControllerBase<FriendController>.Instance.CheckHasAnyApplied(list.ToArray()) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendApplyView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendApplyView, list, null);
			}
		}

		// Token: 0x06034291 RID: 213649 RVA: 0x00D0AFC8 File Offset: 0x00D091C8
		[NullableContext(2)]
		private TowerDefenceEndNotify GetNotify()
		{
			return this.OpenParam as TowerDefenceEndNotify;
		}

		// Token: 0x06034292 RID: 213650 RVA: 0x00D0AFD8 File Offset: 0x00D091D8
		private UniTask InitButtonsAsync()
		{
			TowerDefenseSettleView.<InitButtonsAsync>d__14 <InitButtonsAsync>d__;
			<InitButtonsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonsAsync>d__.<>4__this = this;
			<InitButtonsAsync>d__.<>1__state = -1;
			<InitButtonsAsync>d__.<>t__builder.Start<TowerDefenseSettleView.<InitButtonsAsync>d__14>(ref <InitButtonsAsync>d__);
			return <InitButtonsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034293 RID: 213651 RVA: 0x00D0B01C File Offset: 0x00D0921C
		private UniTask CreateButtonAsync(int index, Action onClick)
		{
			TowerDefenseSettleView.<CreateButtonAsync>d__15 <CreateButtonAsync>d__;
			<CreateButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonAsync>d__.<>4__this = this;
			<CreateButtonAsync>d__.index = index;
			<CreateButtonAsync>d__.onClick = onClick;
			<CreateButtonAsync>d__.<>1__state = -1;
			<CreateButtonAsync>d__.<>t__builder.Start<TowerDefenseSettleView.<CreateButtonAsync>d__15>(ref <CreateButtonAsync>d__);
			return <CreateButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034294 RID: 213652 RVA: 0x00D0B070 File Offset: 0x00D09270
		private UniTask InitRecordPanelAsync()
		{
			TowerDefenseSettleView.<InitRecordPanelAsync>d__16 <InitRecordPanelAsync>d__;
			<InitRecordPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRecordPanelAsync>d__.<>4__this = this;
			<InitRecordPanelAsync>d__.<>1__state = -1;
			<InitRecordPanelAsync>d__.<>t__builder.Start<TowerDefenseSettleView.<InitRecordPanelAsync>d__16>(ref <InitRecordPanelAsync>d__);
			return <InitRecordPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034295 RID: 213653 RVA: 0x00D0B0B4 File Offset: 0x00D092B4
		private void RefreshTitle()
		{
			TowerDefenceEndNotify notify = this.GetNotify();
			UUIText text = base.GetText(1);
			if (notify == null)
			{
				text.SetText("", true);
				return;
			}
			string textStringId = notify.Success ? "Text_ChallengeSuccess_Text" : "TowerDefenceSettlement01";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
			if (notify.Success)
			{
				this.ApplySuccessTitleStyle(text);
			}
		}

		// Token: 0x06034296 RID: 213654 RVA: 0x00D0B118 File Offset: 0x00D09318
		private void ApplySuccessTitleStyle(UUIText titleText)
		{
			UUIEffectOutline uuieffectOutline = titleText.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			titleText.outlineColor = FColor.FromHex("C48B29FF");
			base.GetTexture(2).SetColor(FColor.FromHex("8C754D7F"));
			if (uuieffectOutline != null)
			{
				uuieffectOutline.SetOutlineColor(FColor.FromHex("C48B29FF"));
			}
			titleText.SetColor(FColor.FromHex("f2efd5"));
		}

		// Token: 0x06034297 RID: 213655 RVA: 0x00D0B18C File Offset: 0x00D0938C
		private void RefreshRecordPanel()
		{
			TowerDefenceEndNotify notify = this.GetNotify();
			if (notify == null || this.RecordPanel == null)
			{
				return;
			}
			TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(notify.InstId, true);
			bool flag = config != null && config.Value.IsDifficult;
			if (!notify.Success && flag)
			{
				this.RecordPanel.SetTitleOnly("TowerDefencelose");
				return;
			}
			this.RecordPanel.SetTitleById(flag ? "PrefabTextItem_3771425333_Text" : "PrefabTextItem_1350027209_Text");
			if (notify.Success && flag)
			{
				bool isNewRecord = notify.PassTime != 0 && notify.MinPassTime > notify.PassTime;
				this.RecordPanel.SetRecord(Singleton<TimeUtil>.Instance.GetTimeString((double)notify.PassTime), isNewRecord);
				return;
			}
			if (notify.Success && !flag)
			{
				bool isNewRecord2 = notify.Score > notify.MaxScore && notify.Score != 0;
				this.RecordPanel.SetRecordRolling(notify.Score, isNewRecord2);
				return;
			}
			this.RecordPanel.SetRecordRolling(notify.Score, false);
		}

		// Token: 0x06034298 RID: 213656 RVA: 0x00D0B2A0 File Offset: 0x00D094A0
		private void RefreshHighestScore()
		{
			TowerDefenceEndNotify notify = this.GetNotify();
			TowerDefenseSettleButton towerDefenseSettleButton;
			if (notify == null || !this.ButtonMap.TryGetValue(1, out towerDefenseSettleButton))
			{
				return;
			}
			TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(notify.InstId, true);
			if (config != null && config.Value.IsDifficult)
			{
				towerDefenseSettleButton.SetFloatText("TowerDefenceBestTime", new string[]
				{
					Singleton<TimeUtil>.Instance.GetTimeString((double)notify.MinPassTime)
				});
				return;
			}
			towerDefenseSettleButton.SetFloatText("TowerDefence_GPint", new string[]
			{
				notify.MaxScore.ToString()
			});
		}

		// Token: 0x06034299 RID: 213657 RVA: 0x00D0B33B File Offset: 0x00D0953B
		private void OnExitBtnClick()
		{
			ControllerBase<TowerDefenseController>.Instance.RequestChallengeQuit();
		}

		// Token: 0x0603429A RID: 213658 RVA: 0x00D0B347 File Offset: 0x00D09547
		private void OnRestartBtnClick()
		{
			ControllerBase<TowerDefenseController>.Instance.HandleSettleViewRestart(0);
		}

		// Token: 0x0401E1D1 RID: 123345
		private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

		// Token: 0x0401E1D2 RID: 123346
		private const string SUCCESS_TEXT_COLOR = "f2efd5";

		// Token: 0x0401E1D3 RID: 123347
		private readonly Dictionary<int, TowerDefenseSettleButton> ButtonMap = new Dictionary<int, TowerDefenseSettleButton>();

		// Token: 0x0401E1D4 RID: 123348
		[Nullable(2)]
		private TowerDefenseSettleRecordPanel RecordPanel;

		// Token: 0x0200AE97 RID: 44695
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036351 RID: 222033
			public const int TitleText = 1;

			// Token: 0x04036352 RID: 222034
			public const int TitleTexture = 2;

			// Token: 0x04036353 RID: 222035
			public const int ButtonHorizontalItem = 4;

			// Token: 0x04036354 RID: 222036
			public const int ButtonItem = 5;

			// Token: 0x04036355 RID: 222037
			public const int ContentItem = 20;
		}

		// Token: 0x0200AE98 RID: 44696
		[NullableContext(0)]
		private class EButton
		{
			// Token: 0x04036356 RID: 222038
			public const int Exit = 0;

			// Token: 0x04036357 RID: 222039
			public const int Restart = 1;
		}
	}
}
