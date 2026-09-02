using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D9D RID: 23965
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkRunTaskData
	{
		// Token: 0x0603C57F RID: 247167 RVA: 0x00F5050E File Offset: 0x00F4E70E
		public DreamLinkRunTaskData(int id)
		{
			this.Id = id;
		}

		// Token: 0x0603C580 RID: 247168 RVA: 0x00F50544 File Offset: 0x00F4E744
		public string GetLockTxt()
		{
			string result = "";
			if ((double)this.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime())
			{
				if (this.ConditionGroupId != 0)
				{
					result = ConfigMultiTextLang.GetLocalTextNew(LevelGeneralCommons.GetConditionGroupHintText(this.ConditionGroupId) ?? "", null);
				}
			}
			else
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("DreamLinkWorldRunLockText", null);
				result = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.UnlockTime, localTextNew ?? "");
			}
			return result;
		}

		// Token: 0x0603C581 RID: 247169 RVA: 0x00F505B7 File Offset: 0x00F4E7B7
		public bool IsTimeLock()
		{
			return (double)this.UnlockTime > Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x0603C582 RID: 247170 RVA: 0x00F505CC File Offset: 0x00F4E7CC
		public List<IItemGridData> GetRewardData()
		{
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (TItem item in this.RewardList)
			{
				ItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = (this.Status == EDreamLinkRunTaskState.FinishedAndClaimed)
				};
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x0603C583 RID: 247171 RVA: 0x00F50644 File Offset: 0x00F4E844
		public void JumpDelegate()
		{
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, false, null, delegate(bool success, int viewId)
			{
				if (success)
				{
					ModelBase<MapModel>.Instance.CreateTempMapMark(this.MarkId);
					ControllerBase<WorldMapController>.Instance.FocalMarkItem(EMarkType.DreamLinkRun, this.MarkId);
				}
			});
		}

		// Token: 0x0603C584 RID: 247172 RVA: 0x00F5065F File Offset: 0x00F4E85F
		public void ReceiveDelegate()
		{
			ControllerBase<DreamLinkController>.Instance.RunTaskRewardRequest(this.Id);
		}

		// Token: 0x04021ED9 RID: 138969
		public int Id;

		// Token: 0x04021EDA RID: 138970
		public EDreamLinkRunTaskState Status = EDreamLinkRunTaskState.Active;

		// Token: 0x04021EDB RID: 138971
		public int ConditionGroupId;

		// Token: 0x04021EDC RID: 138972
		public string TitleTextId = "";

		// Token: 0x04021EDD RID: 138973
		public List<TItem> RewardList = new List<TItem>();

		// Token: 0x04021EDE RID: 138974
		public long UnlockTime;

		// Token: 0x04021EDF RID: 138975
		public int MarkId;

		// Token: 0x04021EE0 RID: 138976
		public int PlayTime = -1;
	}
}
