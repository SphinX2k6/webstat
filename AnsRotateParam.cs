using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D6F RID: 3439
[NullableContext(2)]
[Nullable(0)]
internal class AnsRotateParam
{
	// Token: 0x06004A6F RID: 19055 RVA: 0x000A2717 File Offset: 0x000A0917
	public AnsRotateParam(float total)
	{
		this.NowTime = 0f;
		this.TotalDurationReciprocal = 1f / total;
	}

	// Token: 0x06004A70 RID: 19056 RVA: 0x000A2742 File Offset: 0x000A0942
	public void Update(float now, float total)
	{
		this.NowTime = now;
		this.TotalDurationReciprocal = 1f / total;
	}

	// Token: 0x06004A71 RID: 19057 RVA: 0x000A2758 File Offset: 0x000A0958
	public void SetRotateTarget(Vector target, ESkillRotateType type)
	{
		this.SkillRotateTarget.TargetVector = target;
		this.SkillRotateTarget.TargetString = null;
		this.SkillRotateTarget.Type = type;
	}

	// Token: 0x06004A72 RID: 19058 RVA: 0x000A277E File Offset: 0x000A097E
	public void SetRotateTarget(string target, ESkillRotateType type)
	{
		this.SkillRotateTarget.TargetString = target;
		this.SkillRotateTarget.TargetVector = null;
		this.SkillRotateTarget.Type = type;
	}

	// Token: 0x04001519 RID: 5401
	public EAnsRotateDetectionTypeLocal RotateDetectionType;

	// Token: 0x0400151A RID: 5402
	[Nullable(1)]
	public SkillRotateTarget SkillRotateTarget = new SkillRotateTarget();

	// Token: 0x0400151B RID: 5403
	public float NowTime;

	// Token: 0x0400151C RID: 5404
	public float TotalDurationReciprocal;
}
