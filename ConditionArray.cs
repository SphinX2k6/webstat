using System;
using System.Runtime.CompilerServices;

// Token: 0x02003137 RID: 12599
[NullableContext(1)]
[Nullable(0)]
public class ConditionArray
{
	// Token: 0x0601A165 RID: 106853 RVA: 0x007A70F4 File Offset: 0x007A52F4
	public ConditionArray(bool[] conditions, ILogicalStructure structure)
	{
		this.Conditions = conditions;
		this.Structure = structure;
	}

	// Token: 0x0601A166 RID: 106854 RVA: 0x007A710A File Offset: 0x007A530A
	public bool EvaluateByConditions(bool[] conditions)
	{
		this.Conditions = conditions;
		return this.Evaluate();
	}

	// Token: 0x0601A167 RID: 106855 RVA: 0x007A7119 File Offset: 0x007A5319
	public bool Evaluate()
	{
		return this.EvaluateStructure(this.Structure);
	}

	// Token: 0x0601A168 RID: 106856 RVA: 0x007A7128 File Offset: 0x007A5328
	private bool EvaluateStructure(ILogicalStructure structure)
	{
		if (structure.Index != null)
		{
			return this.Conditions[structure.Index.Value];
		}
		if (structure.Or != null)
		{
			for (int i = 0; i < structure.Or.Length; i++)
			{
				if (this.EvaluateStructure(structure.Or[i]))
				{
					return true;
				}
			}
			return false;
		}
		if (structure.And != null)
		{
			for (int j = 0; j < structure.And.Length; j++)
			{
				if (!this.EvaluateStructure(structure.And[j]))
				{
					return false;
				}
			}
			return true;
		}
		return structure.Not != null && !this.EvaluateStructure(structure.Not);
	}

	// Token: 0x0400D153 RID: 53587
	private bool[] Conditions;

	// Token: 0x0400D154 RID: 53588
	private readonly ILogicalStructure Structure;
}
