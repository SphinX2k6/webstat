using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052E1 RID: 21217
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackMarkManager
	{
		// Token: 0x060362FE RID: 221950 RVA: 0x00DA5FE0 File Offset: 0x00DA41E0
		public void StartMark(EntityHandle entityHandle, double uploadTime, double duration, string iconPath)
		{
			int num = this.MarkId + 1;
			this.MarkId = num;
			int num2 = num;
			QuickHackMarkInstance quickHackMarkInstance = new QuickHackMarkInstance();
			quickHackMarkInstance.StartMark(num2, entityHandle, uploadTime, duration, iconPath);
			this.EntityMarksMap[num2] = quickHackMarkInstance;
			Singleton<EventSystem>.Instance.Emit<QuickHackMarkInstance>(EEventName.OnQuickHackStartMark, quickHackMarkInstance);
		}

		// Token: 0x060362FF RID: 221951 RVA: 0x00DA602F File Offset: 0x00DA422F
		public IEnumerable<QuickHackMarkInstance> GetMarks()
		{
			return this.EntityMarksMap.Values;
		}

		// Token: 0x06036300 RID: 221952 RVA: 0x00DA603C File Offset: 0x00DA423C
		public void Clear()
		{
			foreach (QuickHackMarkInstance quickHackMarkInstance in this.EntityMarksMap.Values)
			{
				quickHackMarkInstance.ClearMark();
			}
			this.EntityMarksMap.Clear();
		}

		// Token: 0x06036301 RID: 221953 RVA: 0x00DA609C File Offset: 0x00DA429C
		public void UpdateMarks()
		{
			if (this.EntityMarksMap.Count <= 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, QuickHackMarkInstance> keyValuePair in this.EntityMarksMap)
			{
				int num;
				QuickHackMarkInstance quickHackMarkInstance;
				keyValuePair.Deconstruct(out num, out quickHackMarkInstance);
				int item = num;
				QuickHackMarkInstance quickHackMarkInstance2 = quickHackMarkInstance;
				quickHackMarkInstance2.UpdateMark();
				if (quickHackMarkInstance2.IsFinish())
				{
					list.Add(item);
				}
			}
			foreach (int key in list)
			{
				this.EntityMarksMap.Remove(key);
			}
		}

		// Token: 0x0401F22E RID: 127534
		private int MarkId;

		// Token: 0x0401F22F RID: 127535
		private readonly Dictionary<int, QuickHackMarkInstance> EntityMarksMap = new Dictionary<int, QuickHackMarkInstance>();
	}
}
