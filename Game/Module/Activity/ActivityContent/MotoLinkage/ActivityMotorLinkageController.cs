using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x0200670A RID: 26378
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityMotorLinkageController : ActivityControllerBase<ActivityMotorLinkageController>
	{
		// Token: 0x06041D19 RID: 269593 RVA: 0x010E33DD File Offset: 0x010E15DD
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041D1A RID: 269594 RVA: 0x010E33E0 File Offset: 0x010E15E0
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041D1B RID: 269595 RVA: 0x010E33E2 File Offset: 0x010E15E2
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMotoLinkage";
		}

		// Token: 0x06041D1C RID: 269596 RVA: 0x010E33E9 File Offset: 0x010E15E9
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityMotorLinkageSubView();
		}

		// Token: 0x06041D1D RID: 269597 RVA: 0x010E33F0 File Offset: 0x010E15F0
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.Id = data.Id;
			return new ActivityMotorLinkageData();
		}

		// Token: 0x1700A09C RID: 41116
		// (get) Token: 0x06041D1E RID: 269598 RVA: 0x010E3403 File Offset: 0x010E1603
		public int ActivityId
		{
			get
			{
				return this.Id;
			}
		}

		// Token: 0x1700A09D RID: 41117
		// (get) Token: 0x06041D1F RID: 269599 RVA: 0x010E340B File Offset: 0x010E160B
		[Nullable(2)]
		public ActivityMotorLinkageData ActivityData
		{
			[NullableContext(2)]
			get
			{
				ActivityModel instance = ModelBase<ActivityModel>.Instance;
				return ((instance != null) ? instance.GetActivityById(this.Id) : null) as ActivityMotorLinkageData;
			}
		}

		// Token: 0x06041D20 RID: 269600 RVA: 0x010E3429 File Offset: 0x010E1629
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MotorcycleTaskUpdateNotify>(ENotifyMessageId.MotorcycleTaskUpdateNotify, new Action<MotorcycleTaskUpdateNotify, Net.CallbackStatus>(this.HandleActivityDataNotify));
		}

		// Token: 0x06041D21 RID: 269601 RVA: 0x010E3447 File Offset: 0x010E1647
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorcycleTaskUpdateNotify);
		}

		// Token: 0x06041D22 RID: 269602 RVA: 0x010E3459 File Offset: 0x010E1659
		private void HandleActivityDataNotify(MotorcycleTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			this.ActivityData.OnQuestUpdateNotify(notify);
		}

		// Token: 0x06041D23 RID: 269603 RVA: 0x010E3468 File Offset: 0x010E1668
		public UniTask ReceiveAllRewardRequest(int ipId)
		{
			ActivityMotorLinkageController.<ReceiveAllRewardRequest>d__13 <ReceiveAllRewardRequest>d__;
			<ReceiveAllRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReceiveAllRewardRequest>d__.<>4__this = this;
			<ReceiveAllRewardRequest>d__.ipId = ipId;
			<ReceiveAllRewardRequest>d__.<>1__state = -1;
			<ReceiveAllRewardRequest>d__.<>t__builder.Start<ActivityMotorLinkageController.<ReceiveAllRewardRequest>d__13>(ref <ReceiveAllRewardRequest>d__);
			return <ReceiveAllRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x04024BA8 RID: 150440
		private int Id;
	}
}
