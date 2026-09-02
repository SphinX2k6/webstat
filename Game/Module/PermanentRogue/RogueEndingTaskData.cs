using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005664 RID: 22116
	public class RogueEndingTaskData
	{
		// Token: 0x060385FD RID: 230909 RVA: 0x00E45CF0 File Offset: 0x00E43EF0
		public RogueEndingTaskData(int id)
		{
			this.Id = id;
		}

		// Token: 0x060385FE RID: 230910 RVA: 0x00E45D06 File Offset: 0x00E43F06
		public bool IsFinished()
		{
			return this.Status == ActivityTaskState.ActivityTaskFinish;
		}

		// Token: 0x060385FF RID: 230911 RVA: 0x00E45D11 File Offset: 0x00E43F11
		public bool IsTaken()
		{
			return this.Status == ActivityTaskState.ActivityTaskTaken;
		}

		// Token: 0x06038600 RID: 230912 RVA: 0x00E45D1C File Offset: 0x00E43F1C
		[NullableContext(1)]
		public List<TItem> GetRewardList()
		{
			RogueResTask value = ConfigRogueResTaskById.GetConfig(this.Id, true).Value;
			DropPackage value2 = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(value.Award).Value;
			List<TItem> list = new List<TItem>();
			foreach (DicIntInt dicIntInt in value2.DropPreviewIter())
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(dicIntInt.Key, 0), dicIntInt.Value));
			}
			return list;
		}

		// Token: 0x0402025B RID: 131675
		public ActivityTaskState Status;

		// Token: 0x0402025C RID: 131676
		public readonly int Id;

		// Token: 0x0402025D RID: 131677
		public int Current;

		// Token: 0x0402025E RID: 131678
		public int Target = 1;
	}
}
