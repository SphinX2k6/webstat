using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F8F RID: 3983
public class TDPlayerDefine
{
	// Token: 0x0200737C RID: 29564
	public enum ESkillType
	{
		// Token: 0x04027FD0 RID: 163792
		KscSkill,
		// Token: 0x04027FD1 RID: 163793
		MontageSkill
	}

	// Token: 0x0200737D RID: 29565
	public enum EFollowerState
	{
		// Token: 0x04027FD3 RID: 163795
		None,
		// Token: 0x04027FD4 RID: 163796
		InCD,
		// Token: 0x04027FD5 RID: 163797
		CDReady
	}

	// Token: 0x0200737E RID: 29566
	[NullableContext(1)]
	public interface ISkill
	{
		// Token: 0x1700A7E9 RID: 42985
		// (get) Token: 0x06046C65 RID: 289893
		// (set) Token: 0x06046C66 RID: 289894
		TDPlayerDefine.ESkillType SkillType { get; set; }

		// Token: 0x1700A7EA RID: 42986
		// (get) Token: 0x06046C67 RID: 289895
		// (set) Token: 0x06046C68 RID: 289896
		int SkillId { get; set; }

		// Token: 0x1700A7EB RID: 42987
		// (get) Token: 0x06046C69 RID: 289897
		// (set) Token: 0x06046C6A RID: 289898
		float Time { get; set; }

		// Token: 0x1700A7EC RID: 42988
		// (get) Token: 0x06046C6B RID: 289899
		// (set) Token: 0x06046C6C RID: 289900
		int ChargeCueId { get; set; }

		// Token: 0x1700A7ED RID: 42989
		// (get) Token: 0x06046C6D RID: 289901
		// (set) Token: 0x06046C6E RID: 289902
		int ChargeFullCueId { get; set; }

		// Token: 0x1700A7EE RID: 42990
		// (get) Token: 0x06046C6F RID: 289903
		// (set) Token: 0x06046C70 RID: 289904
		string PsFeedback { get; set; }

		// Token: 0x1700A7EF RID: 42991
		// (get) Token: 0x06046C71 RID: 289905
		// (set) Token: 0x06046C72 RID: 289906
		EKSC_OperateType OperateType { get; set; }
	}

	// Token: 0x0200737F RID: 29567
	[NullableContext(1)]
	[Nullable(0)]
	public class Skill : TDPlayerDefine.ISkill
	{
		// Token: 0x1700A7F0 RID: 42992
		// (get) Token: 0x06046C73 RID: 289907 RVA: 0x012C4B8E File Offset: 0x012C2D8E
		// (set) Token: 0x06046C74 RID: 289908 RVA: 0x012C4B96 File Offset: 0x012C2D96
		public TDPlayerDefine.ESkillType SkillType { get; set; }

		// Token: 0x1700A7F1 RID: 42993
		// (get) Token: 0x06046C75 RID: 289909 RVA: 0x012C4B9F File Offset: 0x012C2D9F
		// (set) Token: 0x06046C76 RID: 289910 RVA: 0x012C4BA7 File Offset: 0x012C2DA7
		public int SkillId { get; set; }

		// Token: 0x1700A7F2 RID: 42994
		// (get) Token: 0x06046C77 RID: 289911 RVA: 0x012C4BB0 File Offset: 0x012C2DB0
		// (set) Token: 0x06046C78 RID: 289912 RVA: 0x012C4BB8 File Offset: 0x012C2DB8
		public float Time { get; set; }

		// Token: 0x1700A7F3 RID: 42995
		// (get) Token: 0x06046C79 RID: 289913 RVA: 0x012C4BC1 File Offset: 0x012C2DC1
		// (set) Token: 0x06046C7A RID: 289914 RVA: 0x012C4BC9 File Offset: 0x012C2DC9
		public int ChargeCueId { get; set; }

		// Token: 0x1700A7F4 RID: 42996
		// (get) Token: 0x06046C7B RID: 289915 RVA: 0x012C4BD2 File Offset: 0x012C2DD2
		// (set) Token: 0x06046C7C RID: 289916 RVA: 0x012C4BDA File Offset: 0x012C2DDA
		public int ChargeFullCueId { get; set; }

		// Token: 0x1700A7F5 RID: 42997
		// (get) Token: 0x06046C7D RID: 289917 RVA: 0x012C4BE3 File Offset: 0x012C2DE3
		// (set) Token: 0x06046C7E RID: 289918 RVA: 0x012C4BEB File Offset: 0x012C2DEB
		public string PsFeedback { get; set; } = "";

		// Token: 0x1700A7F6 RID: 42998
		// (get) Token: 0x06046C7F RID: 289919 RVA: 0x012C4BF4 File Offset: 0x012C2DF4
		// (set) Token: 0x06046C80 RID: 289920 RVA: 0x012C4BFC File Offset: 0x012C2DFC
		public EKSC_OperateType OperateType { get; set; }
	}
}
