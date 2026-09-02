using System;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x02001A4B RID: 6731
public class PropSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FC8 RID: 4040
	// (get) Token: 0x0600C098 RID: 49304 RVA: 0x0032D56E File Offset: 0x0032B76E
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.Prop;
		}
	}

	// Token: 0x04005A23 RID: 23075
	public ERoleDevelopStateTagType? RoleDevelopStateTagType;

	// Token: 0x04005A24 RID: 23076
	public bool? IsLockVisible;

	// Token: 0x04005A25 RID: 23077
	public bool? IsLockVisibleBlack;

	// Token: 0x04005A26 RID: 23078
	public bool? IsReceivableVisible;

	// Token: 0x04005A27 RID: 23079
	public bool? IsStarReceivableVisible;

	// Token: 0x04005A28 RID: 23080
	public bool? IsReceivedVisible;

	// Token: 0x04005A29 RID: 23081
	public bool? IsNewVisible;

	// Token: 0x04005A2A RID: 23082
	public bool? IsNotFoundVisible;

	// Token: 0x04005A2B RID: 23083
	public int? CoolDownTime;

	// Token: 0x04005A2C RID: 23084
	public bool? IsBirthdayEffectVisible;

	// Token: 0x04005A2D RID: 23085
	public bool? IsOrnamentConflictVisible;

	// Token: 0x04005A2E RID: 23086
	public bool? IsTimeFlagVisible;
}
