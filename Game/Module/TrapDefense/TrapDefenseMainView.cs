using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E66 RID: 20070
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMainView : UiTickViewBase
	{
		// Token: 0x06033DF3 RID: 212467 RVA: 0x00CFA1CA File Offset: 0x00CF83CA
		public TrapDefenseMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06033DF4 RID: 212468 RVA: 0x00CFA1D4 File Offset: 0x00CF83D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnKeySettingClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033DF5 RID: 212469 RVA: 0x00CFA384 File Offset: 0x00CF8584
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033DF6 RID: 212470 RVA: 0x00CFA3C7 File Offset: 0x00CF85C7
		protected override void OnBeforeShow()
		{
			ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
			this.RefreshView();
		}

		// Token: 0x06033DF7 RID: 212471 RVA: 0x00CFA3DC File Offset: 0x00CF85DC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseLevelDataListUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseActivityDataUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseRewardUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x06033DF8 RID: 212472 RVA: 0x00CFA440 File Offset: 0x00CF8640
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseLevelDataListUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseActivityDataUpdate, new Action(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseRewardUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x06033DF9 RID: 212473 RVA: 0x00CFA4A4 File Offset: 0x00CF86A4
		protected override void OnBeforeDestroy()
		{
			TrapDefenseEntrySideBtnItem btnFixedReward = this.BtnFixedReward;
			if (btnFixedReward != null)
			{
				btnFixedReward.UnBindRedDot();
			}
			TrapDefenseEntrySideBtnItem btnLimitReward = this.BtnLimitReward;
			if (btnLimitReward != null)
			{
				btnLimitReward.UnBindRedDot();
			}
			TrapDefenseEntrySideBtnItem btnTalentTree = this.BtnTalentTree;
			if (btnTalentTree != null)
			{
				btnTalentTree.UnBindRedDot();
			}
			TrapDefenseEntrySideBtnItem btnWorkshop = this.BtnWorkshop;
			if (btnWorkshop == null)
			{
				return;
			}
			btnWorkshop.UnBindRedDot();
		}

		// Token: 0x06033DFA RID: 212474 RVA: 0x00CFA4F4 File Offset: 0x00CF86F4
		protected override void OnTick(float deltaTime)
		{
			TrapDefenseEntryBtnItem btnRogueMode = this.BtnRogueMode;
			if (btnRogueMode != null)
			{
				btnRogueMode.RefreshUnlockTimer();
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(ModelBase<TrapDefenseModel>.Instance.RewardData.GetLimitRewardRemainTimeStr(), true);
			}
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<TrapDefenseModel>.Instance.RewardData.IsOpenLimitReward());
		}

		// Token: 0x06033DFB RID: 212475 RVA: 0x00CFA558 File Offset: 0x00CF8758
		private void RefreshView()
		{
			ValueTuple<int, int> limitRewardTotalProgress = ModelBase<TrapDefenseModel>.Instance.RewardData.GetLimitRewardTotalProgress();
			int item = limitRewardTotalProgress.Item1;
			int item2 = limitRewardTotalProgress.Item2;
			TrapDefenseEntrySideBtnItem btnLimitReward = this.BtnLimitReward;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			btnLimitReward.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
			this.BtnLimitReward.SetUiActive(ModelBase<TrapDefenseModel>.Instance.RewardData.IsOpenLimitReward());
			ValueTuple<int, int> fixedRewardTotalProgress = ModelBase<TrapDefenseModel>.Instance.RewardData.GetFixedRewardTotalProgress();
			int item3 = fixedRewardTotalProgress.Item1;
			int item4 = fixedRewardTotalProgress.Item2;
			TrapDefenseEntrySideBtnItem btnFixedReward = this.BtnFixedReward;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item3);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item4);
			btnFixedReward.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
			this.BtnMainMode.RefreshByMode();
			this.BtnRogueMode.RefreshByMode();
		}

		// Token: 0x06033DFC RID: 212476 RVA: 0x00CFA63B File Offset: 0x00CF883B
		private void OnKeySettingClick()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewKeySetting();
		}

		// Token: 0x06033DFD RID: 212477 RVA: 0x00CFA647 File Offset: 0x00CF8847
		private void OnLimitRewardClick()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewLimitReward();
		}

		// Token: 0x06033DFE RID: 212478 RVA: 0x00CFA653 File Offset: 0x00CF8853
		private void OnFixedRewardClick()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewFixedReward();
		}

		// Token: 0x06033DFF RID: 212479 RVA: 0x00CFA65F File Offset: 0x00CF885F
		private void OnTalentTreeClick()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewTalentTree(null);
		}

		// Token: 0x06033E00 RID: 212480 RVA: 0x00CFA66C File Offset: 0x00CF886C
		private void OnWorkshopClick()
		{
			ControllerBase<TrapDefenseController>.Instance.OpenOrganDevelop(false, this, 0, null);
		}

		// Token: 0x06033E01 RID: 212481 RVA: 0x00CFA67C File Offset: 0x00CF887C
		private void OnDataUpdate()
		{
			this.RefreshView();
		}

		// Token: 0x0401E003 RID: 122883
		private PopupCaptionItem Caption;

		// Token: 0x0401E004 RID: 122884
		private TrapDefenseEntryBtnItem BtnMainMode;

		// Token: 0x0401E005 RID: 122885
		private TrapDefenseEntryBtnItem BtnRogueMode;

		// Token: 0x0401E006 RID: 122886
		private TrapDefenseEntrySideBtnItem BtnLimitReward;

		// Token: 0x0401E007 RID: 122887
		private TrapDefenseEntrySideBtnItem BtnFixedReward;

		// Token: 0x0401E008 RID: 122888
		private TrapDefenseEntrySideBtnItem BtnTalentTree;

		// Token: 0x0401E009 RID: 122889
		private TrapDefenseEntrySideBtnItem BtnWorkshop;

		// Token: 0x0200AE1C RID: 44572
		[NullableContext(0)]
		internal class EChildType
		{
			// Token: 0x04036120 RID: 221472
			public const int ItemCaption = 0;

			// Token: 0x04036121 RID: 221473
			public const int BtnKeySetting = 1;

			// Token: 0x04036122 RID: 221474
			public const int ItemBtnModeLeft = 2;

			// Token: 0x04036123 RID: 221475
			public const int ItemBtnModeRight = 3;

			// Token: 0x04036124 RID: 221476
			public const int TextTime = 4;

			// Token: 0x04036125 RID: 221477
			public const int ItemBtnLimitReward = 5;

			// Token: 0x04036126 RID: 221478
			public const int ItemBtnFixedReward = 6;

			// Token: 0x04036127 RID: 221479
			public const int ItemBtnTalentTree = 7;

			// Token: 0x04036128 RID: 221480
			public const int ItemBtnWorkshop = 8;

			// Token: 0x04036129 RID: 221481
			public const int ItemCountDown = 9;
		}
	}
}
