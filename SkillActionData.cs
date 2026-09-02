using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Utils;

// Token: 0x02002EC0 RID: 11968
[NullableContext(1)]
[Nullable(0)]
public class SkillActionData
{
	// Token: 0x0400BE21 RID: 48673
	public ESkillAction Action;

	// Token: 0x0400BE22 RID: 48674
	public string[] BulletRowNames = Array.Empty<string>();

	// Token: 0x0400BE23 RID: 48675
	public bool[] SummonChild = Array.Empty<bool>();

	// Token: 0x0400BE24 RID: 48676
	public long[] BuffId = Array.Empty<long>();

	// Token: 0x0400BE25 RID: 48677
	public int[] StackCount = Array.Empty<int>();

	// Token: 0x0400BE26 RID: 48678
	public int SkillId;

	// Token: 0x0400BE27 RID: 48679
	public bool IsHardLock;

	// Token: 0x0400BE28 RID: 48680
	public int LockOnConfigId;

	// Token: 0x0400BE29 RID: 48681
	public ESkillTargetPriority SkillTargetPriority = ESkillTargetPriority.系统设置;

	// Token: 0x0400BE2A RID: 48682
	public bool ShowTarget = true;

	// Token: 0x0400BE2B RID: 48683
	public bool GlobalTarget;

	// Token: 0x0400BE2C RID: 48684
	[Nullable(2)]
	public Formula Formula;

	// Token: 0x0400BE2D RID: 48685
	public long[] ReduceSkillId = Array.Empty<long>();

	// Token: 0x0400BE2E RID: 48686
	public ESkillCdReduceType[] CdResetType = Array.Empty<ESkillCdReduceType>();

	// Token: 0x0400BE2F RID: 48687
	public float[] DecreaseRatio = Array.Empty<float>();

	// Token: 0x0400BE30 RID: 48688
	public float[] DecreaseMagnitude = Array.Empty<float>();
}
