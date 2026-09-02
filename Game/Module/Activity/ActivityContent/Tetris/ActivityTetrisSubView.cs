using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200628F RID: 25231
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityTetrisSubView : ActivitySubViewBase
	{
		// Token: 0x0603F840 RID: 260160 RVA: 0x01048F7C File Offset: 0x0104717C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x0603F841 RID: 260161 RVA: 0x01048FEC File Offset: 0x010471EC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisDataUpdate));
		}

		// Token: 0x0603F842 RID: 260162 RVA: 0x0104900A File Offset: 0x0104720A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisDataUpdate));
		}

		// Token: 0x0603F843 RID: 260163 RVA: 0x01049028 File Offset: 0x01047228
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityTetrisSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityTetrisSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F844 RID: 260164 RVA: 0x0104906B File Offset: 0x0104726B
		protected override void OnRefreshView()
		{
			this.RefreshRedDot();
		}

		// Token: 0x0603F845 RID: 260165 RVA: 0x01049074 File Offset: 0x01047274
		private void RefreshRedDot()
		{
			bool functionRedDotVisible = this.ActivityBaseData.GetPreGuideQuestFinishState() && ControllerBase<ActivityTetrisController>.Instance.GetRedPointShow();
			this.CommonInfoPanel.SetFunctionRedDotVisible(functionRedDotVisible);
		}

		// Token: 0x0603F846 RID: 260166 RVA: 0x010490A8 File Offset: 0x010472A8
		protected override void OnStart()
		{
			this.RefreshProgress();
		}

		// Token: 0x0603F847 RID: 260167 RVA: 0x010490B0 File Offset: 0x010472B0
		private void RefreshProgress()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(3);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				text.SetText(tetrisData.GetCompleteChallengeCount().ToString() + "/" + tetrisData.GetDisplayChallengeCount().ToString(), true);
				return;
			}
		}

		// Token: 0x0603F848 RID: 260168 RVA: 0x01049134 File Offset: 0x01047334
		private void OnClickedMapButton(ActivityBaseData _)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
				return;
			}
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisSelectLevelView, null, null);
		}

		// Token: 0x0603F849 RID: 260169 RVA: 0x010491A3 File Offset: 0x010473A3
		private void OnTetrisDataUpdate(int challengeId)
		{
			this.RefreshProgress();
		}

		// Token: 0x04023A6E RID: 146030
		protected ActivitySubViewGeneralInfo CommonInfoPanel;
	}
}
