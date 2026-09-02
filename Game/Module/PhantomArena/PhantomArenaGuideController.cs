using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Prepare.Entrance;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x020054A1 RID: 21665
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class PhantomArenaGuideController : ActivityControllerBase<PhantomArenaGuideController>
	{
		// Token: 0x060371C6 RID: 225734 RVA: 0x00DFDB53 File Offset: 0x00DFBD53
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x060371C7 RID: 225735 RVA: 0x00DFDB55 File Offset: 0x00DFBD55
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_SoundRemnantArenaMainNew";
		}

		// Token: 0x060371C8 RID: 225736 RVA: 0x00DFDB5C File Offset: 0x00DFBD5C
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new PhantomArenaGuideSubView();
		}

		// Token: 0x060371C9 RID: 225737 RVA: 0x00DFDB63 File Offset: 0x00DFBD63
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new PhantomArenaGuideActivityData();
		}

		// Token: 0x060371CA RID: 225738 RVA: 0x00DFDB6A File Offset: 0x00DFBD6A
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060371CB RID: 225739 RVA: 0x00DFDB70 File Offset: 0x00DFBD70
		public static void RequestReward(int activityId)
		{
			PhantomBattleGuideRewardRequest message = PhantomBattleGuideRewardRequest.Create();
			Singleton<Net>.Instance.Call<PhantomBattleGuideRewardResponse>(ERequestMessageId.PhantomBattleGuideRewardRequest, message, delegate(PhantomBattleGuideRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20232, null, true, true);
					return;
				}
				PhantomArenaGuideActivityData phantomArenaGuideActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as PhantomArenaGuideActivityData;
				if (phantomArenaGuideActivityData == null)
				{
					return;
				}
				phantomArenaGuideActivityData.UpdateReceiveState(true);
			}, 0);
		}
	}
}
