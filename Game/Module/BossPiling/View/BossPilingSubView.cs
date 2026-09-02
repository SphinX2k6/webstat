using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EFE RID: 24318
	public class BossPilingSubView : ActivitySubViewBase
	{
		// Token: 0x0603D16E RID: 250222 RVA: 0x00F840F0 File Offset: 0x00F822F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D16F RID: 250223 RVA: 0x00F8415C File Offset: 0x00F8235C
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D170 RID: 250224 RVA: 0x00F841A0 File Offset: 0x00F823A0
		protected override void OnRefreshView()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			bool functionRedDotVisible = ModelBase<BossPilingModel>.Instance.GetActivityData().CheckLevelRedDot();
			this.CommonInfoPanel.SetFunctionRedDotVisible(functionRedDotVisible);
			UiPanelBase btnReward = this.BtnReward;
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			btnReward.SetUiActive(activityBaseData != null && activityBaseData.IsUnLock());
			this.BtnReward.UnBindRedDot();
			this.BtnReward.BindRedDot(ERedDotName.BossPilingReward, 0);
			List<int> taskNumState = ModelBase<BossPilingModel>.Instance.GetActivityData().GetTaskNumState();
			ButtonItem btnReward2 = this.BtnReward;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskNumState[0]);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskNumState[1]);
			btnReward2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603D171 RID: 250225 RVA: 0x00F84281 File Offset: 0x00F82481
		protected override void OnBeforeHide()
		{
			this.BtnReward.UnBindRedDot();
		}

		// Token: 0x0603D172 RID: 250226 RVA: 0x00F8428E File Offset: 0x00F8248E
		private void OnClickedReward(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingTaskView, null, null);
		}

		// Token: 0x0603D173 RID: 250227 RVA: 0x00F842A4 File Offset: 0x00F824A4
		[NullableContext(2)]
		private void OnClickedConfirm(ActivityBaseData _)
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.BossPilingQuestClicked, true);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingMainView, null, null);
		}

		// Token: 0x0402243D RID: 140349
		[Nullable(1)]
		protected ButtonItem BtnReward;

		// Token: 0x0402243E RID: 140350
		[Nullable(1)]
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0200BEFF RID: 48895
		private enum EDefine
		{
			// Token: 0x0403AC8A RID: 240778
			CommonActivityInfoItem,
			// Token: 0x0403AC8B RID: 240779
			BtnCircle
		}
	}
}
