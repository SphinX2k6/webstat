using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi.Views;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F8D RID: 24461
	public class BuffItemInfo : IStaticVariableResetter
	{
		// Token: 0x0603D6A3 RID: 251555 RVA: 0x00FA02B7 File Offset: 0x00F9E4B7
		static BuffItemInfo()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(BuffItemInfo.CreateStaticDefaultValue), new Action(BuffItemInfo.ResetStaticDefaultValue));
		}

		// Token: 0x0603D6A4 RID: 251556 RVA: 0x00FA02D6 File Offset: 0x00F9E4D6
		public static void CreateStaticDefaultValue()
		{
			BuffItemInfo.Increment = 0;
		}

		// Token: 0x0603D6A5 RID: 251557 RVA: 0x00FA02DE File Offset: 0x00F9E4DE
		public static void ResetStaticDefaultValue()
		{
			BuffItemInfo.Increment = 0;
		}

		// Token: 0x0603D6A6 RID: 251558 RVA: 0x00FA02E6 File Offset: 0x00F9E4E6
		public static int GenSortId()
		{
			BuffItemInfo.Increment++;
			return BuffItemInfo.Increment;
		}

		// Token: 0x0603D6A7 RID: 251559 RVA: 0x00FA02FC File Offset: 0x00F9E4FC
		[NullableContext(1)]
		public static int Compare(BuffItemInfo a, BuffItemInfo b)
		{
			int num = b.Priority - a.Priority;
			if (num == 0)
			{
				return b.SortId - a.SortId;
			}
			return num;
		}

		// Token: 0x0603D6A8 RID: 251560 RVA: 0x00FA0329 File Offset: 0x00F9E529
		public void Clear()
		{
			this.SingleBuff = null;
			this.BuffHandleSet.Clear();
			this.BuffItem = null;
		}

		// Token: 0x0402282E RID: 141358
		public int SortId;

		// Token: 0x0402282F RID: 141359
		public int Priority;

		// Token: 0x04022830 RID: 141360
		public GameplayCue? BuffCueConfig;

		// Token: 0x04022831 RID: 141361
		[Nullable(2)]
		public IActiveBuff SingleBuff;

		// Token: 0x04022832 RID: 141362
		[Nullable(1)]
		public HashSet<long> BuffHandleSet = new HashSet<long>();

		// Token: 0x04022833 RID: 141363
		[Nullable(2)]
		public BuffItemBase BuffItem;

		// Token: 0x04022834 RID: 141364
		private static int Increment;
	}
}
