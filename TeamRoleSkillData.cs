using System;
using System.Runtime.CompilerServices;

// Token: 0x020027A0 RID: 10144
[NullableContext(1)]
[Nullable(0)]
public class TeamRoleSkillData
{
	// Token: 0x04009C16 RID: 39958
	public string SkillIcon = "";

	// Token: 0x04009C17 RID: 39959
	public int SkillType;

	// Token: 0x04009C18 RID: 39960
	public string SkillTypeText = "";

	// Token: 0x04009C19 RID: 39961
	public string SkillName = "";

	// Token: 0x04009C1A RID: 39962
	[Nullable(2)]
	public int[] SkillTagList;

	// Token: 0x04009C1B RID: 39963
	public bool ShowSkillToggle = true;

	// Token: 0x04009C1C RID: 39964
	public string SkillDesc = "";

	// Token: 0x04009C1D RID: 39965
	public string[] SkillDescNum = new string[0];

	// Token: 0x04009C1E RID: 39966
	public string MultiSkillDesc = "";

	// Token: 0x04009C1F RID: 39967
	public string[] MultiSkillDescNum = new string[0];

	// Token: 0x04009C20 RID: 39968
	public string SkillResume = "";

	// Token: 0x04009C21 RID: 39969
	public string[] SkillResumeNum = new string[0];
}
