using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAA RID: 27562
	internal class LeaveAreaItemInfo
	{
		// Token: 0x06043FDC RID: 278492 RVA: 0x0119E320 File Offset: 0x0119C520
		[NullableContext(1)]
		public static bool TryLeave(ILeaveAreaItem info)
		{
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(info.QuestId);
			if (quest == null || !quest.IsProgressing)
			{
				return false;
			}
			BehaviorNodeBase node = quest.GetNode(info.NodeId);
			if (node == null || node.Status != info.NodeState)
			{
				return false;
			}
			Area? area;
			int? num = (ModelBase<AreaModel>.Instance.AreaInfo != null) ? new int?(area.GetValueOrDefault().AreaId) : null;
			int leaveAreaId = info.LeaveAreaId;
			if (!(num.GetValueOrDefault() == leaveAreaId & num != null))
			{
				return false;
			}
			ControllerBase<AreaController>.Instance.EndOverlap(info.LeaveAreaId);
			return true;
		}
	}
}
