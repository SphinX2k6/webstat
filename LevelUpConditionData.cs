using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002D02 RID: 11522
public class LevelUpConditionData
{
	// Token: 0x0601742A RID: 95274 RVA: 0x006732AC File Offset: 0x006714AC
	public bool CheckAllCondition()
	{
		return this.HasHighQuality && this.HasBeStrength && this.HasResonance;
	}

	// Token: 0x0601742B RID: 95275 RVA: 0x006732C8 File Offset: 0x006714C8
	[NullableContext(1)]
	public string[] GetConditionTextList()
	{
		List<string> list = new List<string>();
		if (this.HasHighQuality)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHighQuality");
			list.Add(textById);
		}
		if (this.HasBeStrength)
		{
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHasLevelUp");
			list.Add(textById2);
		}
		if (this.HasResonance)
		{
			string textById3 = ConfigBase<TextConfig>.Instance.GetTextById("WeaponHasResonance");
			list.Add(textById3);
		}
		return list.ToArray();
	}

	// Token: 0x0400B2C3 RID: 45763
	public bool HasHighQuality;

	// Token: 0x0400B2C4 RID: 45764
	public bool HasBeStrength;

	// Token: 0x0400B2C5 RID: 45765
	public bool HasResonance;
}
