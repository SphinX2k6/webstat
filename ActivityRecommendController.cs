using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x0200114E RID: 4430
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRecommendController : ControllerBase<ActivityRecommendController>
{
	// Token: 0x060074C4 RID: 29892 RVA: 0x001EA09C File Offset: 0x001E829C
	protected override bool OnInit()
	{
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x060074C5 RID: 29893 RVA: 0x001EA0A5 File Offset: 0x001E82A5
	protected override bool OnClear()
	{
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x060074C6 RID: 29894 RVA: 0x001EA0AE File Offset: 0x001E82AE
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ActivityRecommendNotify>(ENotifyMessageId.ActivityRecommendNotify, new Action<ActivityRecommendNotify, Net.CallbackStatus>(this.OnReceiveActivityRecommendNotify));
	}

	// Token: 0x060074C7 RID: 29895 RVA: 0x001EA0CC File Offset: 0x001E82CC
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActivityRecommendNotify);
	}

	// Token: 0x060074C8 RID: 29896 RVA: 0x001EA0DE File Offset: 0x001E82DE
	public void OpenView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRecommendView, null, null);
	}

	// Token: 0x060074C9 RID: 29897 RVA: 0x001EA0F4 File Offset: 0x001E82F4
	private void OnReceiveActivityRecommendNotify(ActivityRecommendNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		IReadOnlyList<ActivityRecommendOnePb> recommends = notify.Recommends;
		IReadOnlyList<ActivityRecommendOnePb> recommendFallback = recommends ?? new List<ActivityRecommendOnePb>();
		ActivityRecommendModel instance = ModelBase<ActivityRecommendModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetRecommendFallback(recommendFallback);
	}
}
