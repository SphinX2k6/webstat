using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA8 RID: 23976
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkMainView : UiViewBase
	{
		// Token: 0x0603C5E7 RID: 247271 RVA: 0x00F52B56 File Offset: 0x00F50D56
		public DreamLinkMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C5E8 RID: 247272 RVA: 0x00F52B60 File Offset: 0x00F50D60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C5E9 RID: 247273 RVA: 0x00F52C90 File Offset: 0x00F50E90
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkMainView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkMainView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C5EA RID: 247274 RVA: 0x00F52CD4 File Offset: 0x00F50ED4
		protected override void OnStart()
		{
			int? num = this.OpenParam as int?;
			if (num != null && num.Value == 1)
			{
				this.UiViewSequence.StartSequenceName = "Start01";
				this.UiViewSequence.CloseSequenceName = "Close01";
				return;
			}
			this.UiViewSequence.StartSequenceName = "Start02";
			this.UiViewSequence.CloseSequenceName = "Close02";
		}

		// Token: 0x0603C5EB RID: 247275 RVA: 0x00F52D46 File Offset: 0x00F50F46
		protected override void OnBeforeShow()
		{
			this.LimitTimeRewardItem.RefreshActive();
			this.RefreshButtonState();
			this.RefreshStage();
		}

		// Token: 0x0603C5EC RID: 247276 RVA: 0x00F52D5F File Offset: 0x00F50F5F
		protected override void OnBeforeHide()
		{
			this.LimitTimeRewardItem.SetActive(false);
			this.ClearDelayHandle();
		}

		// Token: 0x0603C5ED RID: 247277 RVA: 0x00F52D73 File Offset: 0x00F50F73
		private void OnClickProgress1()
		{
			this.OpenFunctionView(1, EUiViewName.DreamLinkWorldRunView);
		}

		// Token: 0x0603C5EE RID: 247278 RVA: 0x00F52D81 File Offset: 0x00F50F81
		private void OnClickProgress2()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MowingTowerMultiTips", Array.Empty<object>());
				return;
			}
			this.OpenFunctionView(2, EUiViewName.DreamLinkDungeonView);
		}

		// Token: 0x0603C5EF RID: 247279 RVA: 0x00F52DB0 File Offset: 0x00F50FB0
		private void OnClickProgress3()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MowingTowerMultiTips", Array.Empty<object>());
				return;
			}
			this.OpenFunctionView(3, EUiViewName.DreamLinkWhiteCatView);
		}

		// Token: 0x0603C5F0 RID: 247280 RVA: 0x00F52DE0 File Offset: 0x00F50FE0
		private void OpenFunctionView(int id, EUiViewName viewName)
		{
			RogueWhiteCat activityConfig = this.Data.GetActivityConfig();
			bool flag = this.Data.IsDreamLinkFunctionUnlock(id);
			int num;
			int inConditionGroupId = activityConfig.OpenCondition().TryGetValue(id, out num) ? num : 0;
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(LevelGeneralCommons.GetConditionGroupHintText(inConditionGroupId), Array.Empty<object>());
				return;
			}
			base.PlaySequence("SwitchView", null, true);
			this.ClearDelayHandle();
			this.DelayOpenHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.OpenView(viewName, null, null);
				this.DelayOpenHandle = null;
			}, 320f, null, null, true, 1f);
		}

		// Token: 0x0603C5F1 RID: 247281 RVA: 0x00F52E83 File Offset: 0x00F51083
		private void ClearDelayHandle()
		{
			if (this.DelayOpenHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayOpenHandle);
				this.DelayOpenHandle = null;
			}
		}

		// Token: 0x0603C5F2 RID: 247282 RVA: 0x00F52EA8 File Offset: 0x00F510A8
		private void RefreshButtonState()
		{
			this.Data.GetActivityConfig();
			List<ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>>> list = new List<ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>>>();
			list.Add(new ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>>(1, this.MainButton1, () => this.Data.CheckHasRunRedDot(), () => this.Data.CheckHasRunFinished()));
			list.Add(new ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>>(2, this.MainButton2, () => this.Data.CheckDungeonRedDotState(), () => this.Data.IsAllInstFinished()));
			list.Add(new ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>>(3, this.MainButton3, () => this.Data.CheckHasBossReward() || this.Data.CheckAllBossInstRedDotState(), () => false));
			foreach (ValueTuple<int, DreamLinkButton, Func<bool>, Func<bool>> valueTuple in list)
			{
				int item = valueTuple.Item1;
				DreamLinkButton item2 = valueTuple.Item2;
				Func<bool> item3 = valueTuple.Item3;
				Func<bool> item4 = valueTuple.Item4;
				bool flag = this.Data.IsDreamLinkFunctionUnlock(item);
				item2.SetToggleEnable(flag);
				bool redDotState = false;
				if (flag)
				{
					redDotState = item3();
				}
				item2.SetRedDotState(redDotState);
				item2.SetFinishedState(item4());
			}
		}

		// Token: 0x0603C5F3 RID: 247283 RVA: 0x00F52FE8 File Offset: 0x00F511E8
		private void RefreshStage()
		{
			bool flag = this.Data.GetInstStage() == EDreamLinkStage.First;
			base.GetItem(6).SetUIActive(flag);
			base.GetItem(7).SetUIActive(!flag);
		}

		// Token: 0x04021F29 RID: 139049
		public PopupCaptionItem CaptionComponent;

		// Token: 0x04021F2A RID: 139050
		private DreamLinkScoreRewardItem RewardItem;

		// Token: 0x04021F2B RID: 139051
		private DreamLinkLimitTimeRewardItem LimitTimeRewardItem;

		// Token: 0x04021F2C RID: 139052
		private DreamLinkButton MainButton1;

		// Token: 0x04021F2D RID: 139053
		private DreamLinkButton MainButton2;

		// Token: 0x04021F2E RID: 139054
		private DreamLinkButton MainButton3;

		// Token: 0x04021F2F RID: 139055
		private DreamLinkData Data;

		// Token: 0x04021F30 RID: 139056
		private TimerHandle DelayOpenHandle;

		// Token: 0x0200BDE4 RID: 48612
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403A777 RID: 239479
			public const int CaptionItem = 0;

			// Token: 0x0403A778 RID: 239480
			public const int ButtonProgress1 = 1;

			// Token: 0x0403A779 RID: 239481
			public const int ButtonProgress2 = 2;

			// Token: 0x0403A77A RID: 239482
			public const int ButtonProgress3 = 3;

			// Token: 0x0403A77B RID: 239483
			public const int PermanentReward = 4;

			// Token: 0x0403A77C RID: 239484
			public const int LimitTimeReward = 5;

			// Token: 0x0403A77D RID: 239485
			public const int PanelStage1 = 6;

			// Token: 0x0403A77E RID: 239486
			public const int PanelStage2 = 7;
		}
	}
}
