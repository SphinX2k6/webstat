using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006858 RID: 26712
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityEncircleSubView : ActivitySubViewBase
	{
		// Token: 0x06042966 RID: 272742 RVA: 0x01117BFC File Offset: 0x01115DFC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06042967 RID: 272743 RVA: 0x01117C56 File Offset: 0x01115E56
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EncircleChallengePb>(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042968 RID: 272744 RVA: 0x01117C74 File Offset: 0x01115E74
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042969 RID: 272745 RVA: 0x01117C94 File Offset: 0x01115E94
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityEncircleSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityEncircleSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604296A RID: 272746 RVA: 0x01117CD7 File Offset: 0x01115ED7
		protected override void OnRefreshView()
		{
			this.RefreshRedDot();
		}

		// Token: 0x0604296B RID: 272747 RVA: 0x01117CDF File Offset: 0x01115EDF
		private void RefreshRedDot()
		{
			this.CommonInfoPanel.SetFunctionRedDotVisible(ControllerBase<ActivityEncircleController>.Instance.GetRedPointShow());
		}

		// Token: 0x0604296C RID: 272748 RVA: 0x01117CF8 File Offset: 0x01115EF8
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
			Singleton<UiManager>.Instance.OpenView(EUiViewName.EncircleSelectLevelView, null, null);
		}

		// Token: 0x0604296D RID: 272749 RVA: 0x01117D67 File Offset: 0x01115F67
		protected override void OnStart()
		{
			this.RefreshProgress();
		}

		// Token: 0x0604296E RID: 272750 RVA: 0x01117D70 File Offset: 0x01115F70
		private void RefreshProgress()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(encircleData.GetCompleteChallengeCount().ToString() + "/" + encircleData.GetCurrentChallengeCount().ToString(), true);
		}

		// Token: 0x0604296F RID: 272751 RVA: 0x01117DC0 File Offset: 0x01115FC0
		[NullableContext(1)]
		private void OnEncircleDataUpdate(EncircleChallengePb newData)
		{
			this.RefreshProgress();
		}

		// Token: 0x040250F8 RID: 151800
		protected ActivitySubViewGeneralInfo CommonInfoPanel;
	}
}
