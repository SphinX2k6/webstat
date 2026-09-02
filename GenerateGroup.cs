using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F54 RID: 3924
public class GenerateGroup
{
	// Token: 0x06006299 RID: 25241 RVA: 0x00189B3C File Offset: 0x00187D3C
	public bool IsGenerateFinish()
	{
		return this.CurGenerateIndex >= this.GenerateList.Count;
	}

	// Token: 0x0600629A RID: 25242 RVA: 0x00189B54 File Offset: 0x00187D54
	public bool IsFinish()
	{
		return this.IsGenerateFinish() && this.AliveEntityMap.Count == 0;
	}

	// Token: 0x0600629B RID: 25243 RVA: 0x00189B70 File Offset: 0x00187D70
	public ValueTuple<EGenerateType, int, int> OnEntityRemove(long creatureId)
	{
		int index;
		if (!this.AliveEntityMap.TryGetValue(creatureId, out index))
		{
			return new ValueTuple<EGenerateType, int, int>(EGenerateType.None, 0, 0);
		}
		this.AliveEntityMap.Remove(creatureId);
		IGenerate generate = this.GenerateList[index];
		if (generate == null)
		{
			return new ValueTuple<EGenerateType, int, int>(EGenerateType.None, 0, 0);
		}
		return new ValueTuple<EGenerateType, int, int>(generate.GenerateType, generate.RefreshId, generate.BuffGateBornGroup);
	}

	// Token: 0x0600629C RID: 25244 RVA: 0x00189BD4 File Offset: 0x00187DD4
	public float GetEndDistance()
	{
		IGenerate generate = (this.GenerateList.Count > 0) ? this.GenerateList[this.GenerateList.Count - 1] : null;
		float num = (generate != null) ? generate.BornDistance : 0f;
		return this.GroupStartDistance + num;
	}

	// Token: 0x04002F29 RID: 12073
	[Nullable(1)]
	public List<IGenerate> GenerateList = new List<IGenerate>();

	// Token: 0x04002F2A RID: 12074
	public int CurGenerateIndex;

	// Token: 0x04002F2B RID: 12075
	public float GroupStartDistance;

	// Token: 0x04002F2C RID: 12076
	public float GroupEndDistance;

	// Token: 0x04002F2D RID: 12077
	public int WaveGroupIndex;

	// Token: 0x04002F2E RID: 12078
	public int WaveGroupId;

	// Token: 0x04002F2F RID: 12079
	public int BossFightTime;

	// Token: 0x04002F30 RID: 12080
	[Nullable(1)]
	public Dictionary<long, int> AliveEntityMap = new Dictionary<long, int>();
}
