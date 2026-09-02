using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x02002ED4 RID: 11988
[NullableContext(1)]
[Nullable(0)]
public class CharacterOperationRecord
{
	// Token: 0x060189F6 RID: 100854 RVA: 0x006F0449 File Offset: 0x006EE649
	public CharacterOperationRecord(string name, int entityId, int cfgId)
	{
		this.Name = name;
		this.EntityId = entityId;
		this.CfgId = cfgId;
	}

	// Token: 0x060189F7 RID: 100855 RVA: 0x006F0488 File Offset: 0x006EE688
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (SkillOperationRecord skillOperationRecord in this.SkillOperationMap.Values)
		{
			stringBuilder.Append(StringUtils.Format(CharacterOperationRecord.CHARACTER_RECORD_FMT, new string[]
			{
				this.EntityId.ToString(),
				this.Name,
				this.CfgId.ToString(),
				skillOperationRecord.ToString()
			}));
		}
		foreach (SkillOperationRecord skillOperationRecord2 in this.MoveOperationMap.Values)
		{
			stringBuilder.Append(StringUtils.Format(CharacterOperationRecord.CHARACTER_RECORD_FMT, new string[]
			{
				this.EntityId.ToString(),
				this.Name,
				this.CfgId.ToString(),
				skillOperationRecord2.ToString()
			}));
		}
		foreach (SkillOperationRecord skillOperationRecord3 in this.TagOperationMap.Values)
		{
			stringBuilder.Append(StringUtils.Format(CharacterOperationRecord.CHARACTER_RECORD_FMT, new string[]
			{
				this.EntityId.ToString(),
				this.Name,
				this.CfgId.ToString(),
				skillOperationRecord3.ToString()
			}));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0400BE97 RID: 48791
	private static readonly string CHARACTER_RECORD_FMT = "{0},{1},{2},{3}\n";

	// Token: 0x0400BE98 RID: 48792
	public readonly string Name;

	// Token: 0x0400BE99 RID: 48793
	public readonly int EntityId;

	// Token: 0x0400BE9A RID: 48794
	private readonly int CfgId;

	// Token: 0x0400BE9B RID: 48795
	public readonly Dictionary<int, SkillOperationRecord> SkillOperationMap = new Dictionary<int, SkillOperationRecord>();

	// Token: 0x0400BE9C RID: 48796
	public readonly Dictionary<ECharMoveState, SkillOperationRecord> MoveOperationMap = new Dictionary<ECharMoveState, SkillOperationRecord>();

	// Token: 0x0400BE9D RID: 48797
	public readonly Dictionary<int, SkillOperationRecord> TagOperationMap = new Dictionary<int, SkillOperationRecord>();
}
