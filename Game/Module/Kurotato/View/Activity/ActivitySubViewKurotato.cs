using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AD8 RID: 23256
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewKurotato : ActivitySubViewBase
	{
		// Token: 0x170095A8 RID: 38312
		// (get) Token: 0x0603ACC5 RID: 240837 RVA: 0x00EE9250 File Offset: 0x00EE7450
		protected new KurotatoActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as KurotatoActivityData;
			}
		}

		// Token: 0x0603ACC6 RID: 240838 RVA: 0x00EE9260 File Offset: 0x00EE7460
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ACC7 RID: 240839 RVA: 0x00EE92EC File Offset: 0x00EE74EC
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewKurotato.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewKurotato.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ACC8 RID: 240840 RVA: 0x00EE9330 File Offset: 0x00EE7530
		protected override void OnBeforeShow()
		{
			this.OnRefreshView();
			KurotatoNormalRewardButton normalRewardBtn = this.NormalRewardBtn;
			if (normalRewardBtn != null)
			{
				normalRewardBtn.BindRedDot();
			}
			KurotatoLimitTimeRewardButton limitedTimeRewardBtn = this.LimitedTimeRewardBtn;
			if (limitedTimeRewardBtn != null)
			{
				limitedTimeRewardBtn.BindRedDot();
			}
			bool flag = this.ActivityBaseData.IsUnLock();
			bool flag2 = this.ActivityBaseData.CheckIfInLimitTime();
			base.GetItem(1).SetUIActive(flag && flag2);
			base.GetItem(2).SetUIActive(flag);
		}

		// Token: 0x0603ACC9 RID: 240841 RVA: 0x00EE9399 File Offset: 0x00EE7599
		protected override void OnBeforeHide()
		{
			KurotatoNormalRewardButton normalRewardBtn = this.NormalRewardBtn;
			if (normalRewardBtn != null)
			{
				normalRewardBtn.UnBindRedDot();
			}
			KurotatoLimitTimeRewardButton limitedTimeRewardBtn = this.LimitedTimeRewardBtn;
			if (limitedTimeRewardBtn == null)
			{
				return;
			}
			limitedTimeRewardBtn.UnBindRedDot();
		}

		// Token: 0x0603ACCA RID: 240842 RVA: 0x00EE93BC File Offset: 0x00EE75BC
		protected override void OnTimer(float gap)
		{
			this.RefreshBottomTimeText();
		}

		// Token: 0x0603ACCB RID: 240843 RVA: 0x00EE93C4 File Offset: 0x00EE75C4
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
			if (commonInfoPanel2 != null)
			{
				commonInfoPanel2.SetFunctionRedDotVisible(this.GetFunctionRedDotState());
			}
			if (this.ActivityBaseData.GetUnFinishPreGuideQuestId() > 0)
			{
				this.CommonInfoPanel.SetBtnText("Kurotato_Task_Go_To", Array.Empty<object>());
			}
			else
			{
				this.CommonInfoPanel.SetBtnText("Kurotato_Go_To", Array.Empty<object>());
			}
			ValueTuple<int, int> normalRewardProgress = this.ActivityBaseData.GetNormalRewardProgress();
			int item = normalRewardProgress.Item1;
			int item2 = normalRewardProgress.Item2;
			this.NormalRewardBtn.SetProgressNumText(item, item2);
			ValueTuple<int, int> limitedTimeRewardProgress = this.ActivityBaseData.GetLimitedTimeRewardProgress();
			int item3 = limitedTimeRewardProgress.Item1;
			int item4 = limitedTimeRewardProgress.Item2;
			this.LimitedTimeRewardBtn.SetProgressNumText(item3, item4);
		}

		// Token: 0x0603ACCC RID: 240844 RVA: 0x00EE9480 File Offset: 0x00EE7680
		private void RefreshBottomTimeText()
		{
			bool flag = this.ActivityBaseData.CheckIfInLimitTime();
			bool flag2 = this.ActivityBaseData.IsUnLock();
			base.GetItem(1).SetUIActive(flag2 && flag);
			if (!flag)
			{
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndRewardTime, "{0}");
			this.LimitedTimeRewardBtn.SetLimitTimeText(remainTimeText ?? "");
		}

		// Token: 0x0603ACCD RID: 240845 RVA: 0x00EE94E8 File Offset: 0x00EE76E8
		private bool GetFunctionRedDotState()
		{
			return this.ActivityBaseData.IsActHaveRedDot();
		}

		// Token: 0x0603ACCE RID: 240846 RVA: 0x00EE94F8 File Offset: 0x00EE76F8
		private void OnEnterBtnClick(ActivityBaseData _)
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MowingTowerMultiTips", Array.Empty<object>());
				return;
			}
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoMainView, this.ActivityBaseData, null);
		}

		// Token: 0x0603ACCF RID: 240847 RVA: 0x00EE9573 File Offset: 0x00EE7773
		private void OnLimitedTimeRewardBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoLimitedTimeRewardView, null, null);
		}

		// Token: 0x0603ACD0 RID: 240848 RVA: 0x00EE9586 File Offset: 0x00EE7786
		private void OnNormalRewardBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoNormalRewardView, null, null);
		}

		// Token: 0x040213AC RID: 136108
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x040213AD RID: 136109
		protected KurotatoLimitTimeRewardButton LimitedTimeRewardBtn;

		// Token: 0x040213AE RID: 136110
		protected KurotatoNormalRewardButton NormalRewardBtn;

		// Token: 0x0200BB05 RID: 47877
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039B97 RID: 236439
			CommonActionInfo,
			// Token: 0x04039B98 RID: 236440
			LimitedTimeRewardBtn,
			// Token: 0x04039B99 RID: 236441
			NormalRewardBtn
		}
	}
}
