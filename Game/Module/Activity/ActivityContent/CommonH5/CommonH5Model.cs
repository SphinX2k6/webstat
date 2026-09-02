using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CommonH5
{
	// Token: 0x020069B3 RID: 27059
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CommonH5Model : ModelBase<CommonH5Model>
	{
		// Token: 0x06043192 RID: 274834 RVA: 0x0113BB00 File Offset: 0x01139D00
		[NullableContext(2)]
		public CommonH5Data GetActivityData()
		{
			List<ActivityBaseData> activitiesByType = ModelBase<ActivityModel>.Instance.GetActivitiesByType(84);
			if (activitiesByType.Count > 0)
			{
				return activitiesByType[0] as CommonH5Data;
			}
			return null;
		}

		// Token: 0x06043193 RID: 274835 RVA: 0x0113BB34 File Offset: 0x01139D34
		public void OnActivityDataNotify(H5ViewActivityDataNotify data)
		{
			CommonH5Data activityData = this.GetActivityData();
			if (activityData != null)
			{
				activityData.ChangeServerRedDotState(data.ActivityData.RedDot);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}
		}

		// Token: 0x06043194 RID: 274836 RVA: 0x0113BB74 File Offset: 0x01139D74
		public bool GetRedDotState()
		{
			CommonH5Data activityData = this.GetActivityData();
			return activityData != null && activityData.RedPointShowState;
		}

		// Token: 0x06043195 RID: 274837 RVA: 0x0113BB94 File Offset: 0x01139D94
		public void SaveClickRedDotState()
		{
			CommonH5Data activityData = this.GetActivityData();
			if (activityData != null)
			{
				activityData.SaveClickRedDotState();
			}
		}
	}
}
