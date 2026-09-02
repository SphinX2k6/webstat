using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044DA RID: 17626
	public class ResourceUpdateUtils
	{
		// Token: 0x0602E7D5 RID: 190421 RVA: 0x00B02600 File Offset: 0x00B00800
		[NullableContext(1)]
		public static HashSet<int> ParseMp4FinishQuestFlagToSet([Nullable(2)] List<uint> flags)
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (flags == null || flags.Count == 0)
			{
				return hashSet;
			}
			for (int i = 0; i < flags.Count; i++)
			{
				uint num = flags[i];
				if (num != 0U)
				{
					for (int j = 0; j < 32; j++)
					{
						if ((num >> j & 1U) == 1U)
						{
							int item = i * 32 + j + 1;
							hashSet.Add(item);
						}
					}
				}
			}
			return hashSet;
		}
	}
}
