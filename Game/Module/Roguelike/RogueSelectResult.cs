using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200511D RID: 20765
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueSelectResult
	{
		// Token: 0x06035782 RID: 219010 RVA: 0x00D6BAD4 File Offset: 0x00D69CD4
		public RogueSelectResult([Nullable(1)] RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, RogueGainEntry selectRogueGainEntry, bool isShowCommon = false)
		{
			this.NewRogueGainEntry = newRogueGainEntry;
			this.OldRogueGainEntry = oldRogueGainEntry;
			this.SelectRogueGainEntry = selectRogueGainEntry;
			this.IsShowCommon = isShowCommon;
		}

		// Token: 0x06035783 RID: 219011 RVA: 0x00D6BAFC File Offset: 0x00D69CFC
		[NullableContext(1)]
		public HashSet<long> GetNewUnlockAffixEntry()
		{
			HashSet<long> hashSet = new HashSet<long>();
			List<AffixEntry> affixEntryList = this.NewRogueGainEntry.AffixEntryList;
			List<AffixEntry> affixEntryList2 = this.OldRogueGainEntry.AffixEntryList;
			if (affixEntryList != null && affixEntryList2 != null)
			{
				int num = Math.Min(affixEntryList.Count, affixEntryList2.Count);
				for (int i = 0; i < num; i++)
				{
					AffixEntry affixEntry = affixEntryList[i];
					AffixEntry affixEntry2 = affixEntryList2[i];
					if (affixEntry.IsUnlock.GetValueOrDefault() && !affixEntry2.IsUnlock.GetValueOrDefault())
					{
						hashSet.Add((long)affixEntry.Id.Value);
					}
				}
			}
			return hashSet;
		}

		// Token: 0x0401EBE1 RID: 125921
		[Nullable(1)]
		public RogueGainEntry NewRogueGainEntry;

		// Token: 0x0401EBE2 RID: 125922
		public RogueGainEntry OldRogueGainEntry;

		// Token: 0x0401EBE3 RID: 125923
		public RogueGainEntry SelectRogueGainEntry;

		// Token: 0x0401EBE4 RID: 125924
		public RogueGainEntry ExtraRogueGainEntry;

		// Token: 0x0401EBE5 RID: 125925
		public bool IsShowCommon;

		// Token: 0x0401EBE6 RID: 125926
		public Action CallBack;
	}
}
