using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200136D RID: 4973
public class LordGymActivityData : ActivityBaseData
{
	// Token: 0x0600885D RID: 34909 RVA: 0x0023F66C File Offset: 0x0023D86C
	public void RefreshActivityRedDotState()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600885E RID: 34910 RVA: 0x0023F684 File Offset: 0x0023D884
	public void ReadRedDot()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600885F RID: 34911 RVA: 0x0023F6B1 File Offset: 0x0023D8B1
	public bool CheckRedDot()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0;
	}

	// Token: 0x06008860 RID: 34912 RVA: 0x0023F6CB File Offset: 0x0023D8CB
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckRedDot();
	}

	// Token: 0x04004010 RID: 16400
	private const int LORD_GYM_RED_DOT_CACHE_KEY = 100;
}
