using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C8 RID: 13256
public class IntroductionRedDot : RedDotBase
{
	// Token: 0x0601B919 RID: 112921 RVA: 0x0083BE59 File Offset: 0x0083A059
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SdkIntroductionRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B91A RID: 112922 RVA: 0x0083BE77 File Offset: 0x0083A077
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkIntroductionRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B91B RID: 112923 RVA: 0x0083BE95 File Offset: 0x0083A095
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<KuroSdkModel>.Instance.IntroductionNoticeState;
	}
}
