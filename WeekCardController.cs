using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020023F5 RID: 9205
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WeekCardController : UiControllerBase<WeekCardController>
{
	// Token: 0x06011D0C RID: 72972 RVA: 0x004E6F70 File Offset: 0x004E5170
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06011D0D RID: 72973 RVA: 0x004E6F73 File Offset: 0x004E5173
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<EffectiveWeekCardInfoNotify>(ENotifyMessageId.EffectiveWeekCardInfoNotify, new Action<EffectiveWeekCardInfoNotify, Net.CallbackStatus>(this.OnWeekCardInfoResponse));
	}

	// Token: 0x06011D0E RID: 72974 RVA: 0x004E6F91 File Offset: 0x004E5191
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EffectiveWeekCardInfoNotify);
	}

	// Token: 0x06011D0F RID: 72975 RVA: 0x004E6FA4 File Offset: 0x004E51A4
	[NullableContext(1)]
	private void OnWeekCardInfoResponse(EffectiveWeekCardInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		List<WeekCardInfo> weekCardInfos = (((response != null) ? response.WeekCardInfos : null) != null) ? new List<WeekCardInfo>(response.WeekCardInfos) : new List<WeekCardInfo>();
		ModelBase<WeekCardModel>.Instance.SetWeekCardInfos(weekCardInfos);
	}

	// Token: 0x06011D10 RID: 72976 RVA: 0x004E6FE0 File Offset: 0x004E51E0
	public UniTask<bool> RequestWeekCardInfo(int weekCardId)
	{
		WeekCardController.<RequestWeekCardInfo>d__4 <RequestWeekCardInfo>d__;
		<RequestWeekCardInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestWeekCardInfo>d__.weekCardId = weekCardId;
		<RequestWeekCardInfo>d__.<>1__state = -1;
		<RequestWeekCardInfo>d__.<>t__builder.Start<WeekCardController.<RequestWeekCardInfo>d__4>(ref <RequestWeekCardInfo>d__);
		return <RequestWeekCardInfo>d__.<>t__builder.Task;
	}

	// Token: 0x06011D11 RID: 72977 RVA: 0x004E7024 File Offset: 0x004E5224
	public UniTask<bool> RequestWeekCardReward(int contentId)
	{
		WeekCardController.<RequestWeekCardReward>d__5 <RequestWeekCardReward>d__;
		<RequestWeekCardReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestWeekCardReward>d__.contentId = contentId;
		<RequestWeekCardReward>d__.<>1__state = -1;
		<RequestWeekCardReward>d__.<>t__builder.Start<WeekCardController.<RequestWeekCardReward>d__5>(ref <RequestWeekCardReward>d__);
		return <RequestWeekCardReward>d__.<>t__builder.Task;
	}
}
