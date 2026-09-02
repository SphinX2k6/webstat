using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002EB7 RID: 11959
[NullableContext(1)]
[Nullable(0)]
public class RecordDamageSum
{
	// Token: 0x06018886 RID: 100486 RVA: 0x006E2410 File Offset: 0x006E0610
	public string[] ToCsvForRole()
	{
		List<string> list = new List<string>();
		list.Add(this.ConfigId.ToString());
		list.Add(this.Name);
		list.Add(this.DamageSourceConfigId.ToString());
		list.Add(this.SourceName);
		list.Add(this.SourceUniqueId.ToString());
		list.Add(this.TotalDamage.ToString());
		for (int i = 0; i < 15; i++)
		{
			list.Add((this.RecordDamage.ContainsKey((ESkillGenre)i) ? this.RecordDamage[(ESkillGenre)i] : 0).ToString());
		}
		return list.ToArray();
	}

	// Token: 0x06018887 RID: 100487 RVA: 0x006E24C0 File Offset: 0x006E06C0
	public string[] ToCsvForMonster()
	{
		List<string> list = new List<string>();
		list.Add(this.ConfigId.ToString());
		list.Add(this.Name);
		list.Add(this.UniqueId.ToString());
		list.Add(this.DamageSourceConfigId.ToString());
		list.Add(this.SourceName);
		list.Add(this.TotalDamage.ToString());
		for (int i = 0; i < 15; i++)
		{
			list.Add((this.RecordDamage.ContainsKey((ESkillGenre)i) ? this.RecordDamage[(ESkillGenre)i] : 0).ToString());
		}
		return list.ToArray();
	}

	// Token: 0x0400BD9B RID: 48539
	public int ConfigId;

	// Token: 0x0400BD9C RID: 48540
	public string Name = "";

	// Token: 0x0400BD9D RID: 48541
	public int UniqueId;

	// Token: 0x0400BD9E RID: 48542
	public int DamageSourceConfigId;

	// Token: 0x0400BD9F RID: 48543
	public string SourceName = "";

	// Token: 0x0400BDA0 RID: 48544
	public int SourceUniqueId;

	// Token: 0x0400BDA1 RID: 48545
	public int TotalDamage;

	// Token: 0x0400BDA2 RID: 48546
	public Dictionary<ESkillGenre, int> RecordDamage = new Dictionary<ESkillGenre, int>();
}
