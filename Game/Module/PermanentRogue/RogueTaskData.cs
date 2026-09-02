using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005663 RID: 22115
	public class RogueTaskData
	{
		// Token: 0x060385F9 RID: 230905 RVA: 0x00E45C1D File Offset: 0x00E43E1D
		public RogueTaskData(int id)
		{
			this.Id = id;
		}

		// Token: 0x060385FA RID: 230906 RVA: 0x00E45C33 File Offset: 0x00E43E33
		public bool IsFinished()
		{
			return this.Status == ActivityTaskState.ActivityTaskFinish;
		}

		// Token: 0x060385FB RID: 230907 RVA: 0x00E45C3E File Offset: 0x00E43E3E
		public bool IsTaken()
		{
			return this.Status == ActivityTaskState.ActivityTaskTaken;
		}

		// Token: 0x060385FC RID: 230908 RVA: 0x00E45C4C File Offset: 0x00E43E4C
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

		// Token: 0x04020257 RID: 131671
		public ActivityTaskState Status;

		// Token: 0x04020258 RID: 131672
		public readonly int Id;

		// Token: 0x04020259 RID: 131673
		public int Current;

		// Token: 0x0402025A RID: 131674
		public int Target = 1;
	}
}
