using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002EB6 RID: 11958
[NullableContext(1)]
[Nullable(0)]
public class RecordMoveSum
{
	// Token: 0x06018884 RID: 100484 RVA: 0x006E2370 File Offset: 0x006E0570
	public string[] ToCsv()
	{
		List<string> list = new List<string>();
		list.Add(this.ConfigId.ToString());
		list.Add(this.Name);
		list.Add(this.TargetUniqueId.ToString());
		for (int i = 0; i < 15; i++)
		{
			list.Add((this.RecordNum.ContainsKey((ESkillGenre)i) ? this.RecordNum[(ESkillGenre)i] : 0).ToString());
		}
		return list.ToArray();
	}

	// Token: 0x0400BD97 RID: 48535
	public string Name = "";

	// Token: 0x0400BD98 RID: 48536
	public int ConfigId;

	// Token: 0x0400BD99 RID: 48537
	public int TargetUniqueId;

	// Token: 0x0400BD9A RID: 48538
	public Dictionary<ESkillGenre, int> RecordNum = new Dictionary<ESkillGenre, int>();
}
