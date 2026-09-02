using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;

// Token: 0x020032D8 RID: 13016
public class RedDotDirectTrainProEntry : RedDotBase
{
	// Token: 0x0601B4D2 RID: 111826 RVA: 0x00833780 File Offset: 0x00831980
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ActivityDirectTrainRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4D3 RID: 111827 RVA: 0x0083379E File Offset: 0x0083199E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActivityDirectTrainRedDotUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B4D4 RID: 111828 RVA: 0x008337BC File Offset: 0x008319BC
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B4D5 RID: 111829 RVA: 0x008337BF File Offset: 0x008319BF
	protected override bool OnCheck(int uId = 0)
	{
		if (!ActivityDirectTrainHelper.IsProOpen)
		{
			return false;
		}
		DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
		return instance != null && instance.HasUnReadSubActivity();
	}
}
