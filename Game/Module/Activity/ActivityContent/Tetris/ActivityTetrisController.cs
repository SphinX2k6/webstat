using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200628C RID: 25228
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityTetrisController : ActivityControllerBase<ActivityTetrisController>
	{
		// Token: 0x0603F825 RID: 260133 RVA: 0x01048A7F File Offset: 0x01046C7F
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603F826 RID: 260134 RVA: 0x01048A81 File Offset: 0x01046C81
		protected override void OnRegisterNetEvent()
		{
		}

		// Token: 0x0603F827 RID: 260135 RVA: 0x01048A83 File Offset: 0x01046C83
		protected override void OnUnRegisterNetEvent()
		{
		}

		// Token: 0x0603F828 RID: 260136 RVA: 0x01048A85 File Offset: 0x01046C85
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityCube";
		}

		// Token: 0x0603F829 RID: 260137 RVA: 0x01048A8C File Offset: 0x01046C8C
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityTetrisSubView();
		}

		// Token: 0x0603F82A RID: 260138 RVA: 0x01048A93 File Offset: 0x01046C93
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityTetrisData();
		}

		// Token: 0x0603F82B RID: 260139 RVA: 0x01048AA8 File Offset: 0x01046CA8
		public void SendCompleteRequest(TetrisUpdateRequest request, Action callback)
		{
			Singleton<Net>.Instance.Call<TetrisUpdateResponse>(ERequestMessageId.TetrisUpdateRequest, request, delegate(TetrisUpdateResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 15438, null, true, true);
				}
				if (callback != null)
				{
					callback();
				}
			}, 0);
		}

		// Token: 0x0603F82C RID: 260140 RVA: 0x01048AE0 File Offset: 0x01046CE0
		public bool GetRedPointShow()
		{
			int activityId = this.ActivityId;
			List<ITetrisSelectGroupData> allGroupByActivityId = ConfigBase<ActivityTetrisConfig>.Instance.GetAllGroupByActivityId(activityId);
			if (allGroupByActivityId == null)
			{
				return false;
			}
			ActivityTetrisData tetrisData = this.GetTetrisData();
			if (tetrisData == null)
			{
				return false;
			}
			foreach (ITetrisSelectGroupData tetrisSelectGroupData in allGroupByActivityId)
			{
				if (tetrisData.CheckGroupRedPointShow(tetrisSelectGroupData.ChallengeIds))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603F82D RID: 260141 RVA: 0x01048B64 File Offset: 0x01046D64
		[NullableContext(2)]
		public ActivityTetrisData GetTetrisData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.TetrisActivity);
			ActivityTetrisData result = null;
			if (currentActivitiesByType.Count > 0)
			{
				result = (currentActivitiesByType[0] as ActivityTetrisData);
			}
			return result;
		}

		// Token: 0x0603F82E RID: 260142 RVA: 0x01048B97 File Offset: 0x01046D97
		public List<ITetrisSelectGroupData> GetAllLevelSelectData()
		{
			return ConfigBase<ActivityTetrisConfig>.Instance.GetAllGroupByActivityId(this.ActivityId);
		}

		// Token: 0x0603F82F RID: 260143 RVA: 0x01048BA9 File Offset: 0x01046DA9
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603F830 RID: 260144 RVA: 0x01048BAC File Offset: 0x01046DAC
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			ActivityTetrisController.<OnOpenSubView>d__12 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<ActivityTetrisController.<OnOpenSubView>d__12>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x04023A67 RID: 146023
		public int ActivityId;
	}
}
