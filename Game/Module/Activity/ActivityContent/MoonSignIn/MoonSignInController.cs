using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006723 RID: 26403
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MoonSignInController : ActivityControllerBase<MoonSignInController>
	{
		// Token: 0x06041DD4 RID: 269780 RVA: 0x010E5ECD File Offset: 0x010E40CD
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041DD5 RID: 269781 RVA: 0x010E5ECF File Offset: 0x010E40CF
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMoonPhase";
		}

		// Token: 0x06041DD6 RID: 269782 RVA: 0x010E5ED6 File Offset: 0x010E40D6
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new MoonSignInSubView();
		}

		// Token: 0x06041DD7 RID: 269783 RVA: 0x010E5EDD File Offset: 0x010E40DD
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new MoonSignInData();
		}

		// Token: 0x06041DD8 RID: 269784 RVA: 0x010E5EF0 File Offset: 0x010E40F0
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddSpecialItem));
		}

		// Token: 0x06041DD9 RID: 269785 RVA: 0x010E5F0E File Offset: 0x010E410E
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddSpecialItem));
		}

		// Token: 0x06041DDA RID: 269786 RVA: 0x010E5F2C File Offset: 0x010E412C
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041DDB RID: 269787 RVA: 0x010E5F2F File Offset: 0x010E412F
		[NullableContext(2)]
		public MoonSignInData GetData()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as MoonSignInData;
		}

		// Token: 0x06041DDC RID: 269788 RVA: 0x010E5F48 File Offset: 0x010E4148
		public void MoonPhaseRandomRequest(int activityId)
		{
			MoonPhaseRandomRequest message = Aki.Protocol.MoonPhaseRandomRequest.Create();
			Singleton<Net>.Instance.Call<MoonPhaseRandomResponse>(ERequestMessageId.MoonPhaseRandomRequest, message, delegate(MoonPhaseRandomResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18870, null, true, true);
					return;
				}
				MoonSignInData data = this.GetData();
				if (response.Result != null && data != null)
				{
					data.HaveSelectMoonPhaseSelectList.Add(response.Result);
					data.SelectMoonPhaseList.Add(response.Result.MoonPhaseId);
					data.CurrentMoonId = response.Result.MoonPhaseId;
				}
				MoonSignInDetailViewOpenData param = new MoonSignInDetailViewOpenData
				{
					MoonId = response.Result.MoonPhaseId,
					Wishing = new bool?(true)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonSignInDetailView, param, null);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
			}, 0);
		}

		// Token: 0x06041DDD RID: 269789 RVA: 0x010E5F8C File Offset: 0x010E418C
		public void MoonPhaseRewardRequest(int activityId)
		{
			MoonPhaseRewardRequest message = Aki.Protocol.MoonPhaseRewardRequest.Create();
			Singleton<Net>.Instance.Call<MoonPhaseRewardResponse>(ERequestMessageId.MoonPhaseRewardRequest, message, delegate(MoonPhaseRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27770, null, true, true);
				}
				MoonSignInData data = this.GetData();
				if (data != null)
				{
					data.MoonGrandReward = true;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.MoonSignRewardRefresh);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
			}, 0);
		}

		// Token: 0x06041DDE RID: 269790 RVA: 0x010E5FD0 File Offset: 0x010E41D0
		private void OnAddSpecialItem(IReadOnlyList<IProto_NormalItem> itemList)
		{
			MoonSignInData data = this.GetData();
			if (data == null)
			{
				return;
			}
			using (IEnumerator<IProto_NormalItem> enumerator = itemList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Id == data.UseItemId)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
					}
				}
			}
		}

		// Token: 0x04024C10 RID: 150544
		private int ActivityId;
	}
}
