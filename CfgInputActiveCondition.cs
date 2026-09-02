using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x0200308D RID: 12429
[NullableContext(1)]
[Nullable(0)]
public class CfgInputActiveCondition
{
	// Token: 0x1700227A RID: 8826
	// (get) Token: 0x060199F6 RID: 104950 RVA: 0x00772832 File Offset: 0x00770A32
	// (set) Token: 0x060199F7 RID: 104951 RVA: 0x0077283A File Offset: 0x00770A3A
	public EInputActiveConditionType ConditionType { get; set; }

	// Token: 0x1700227B RID: 8827
	// (get) Token: 0x060199F8 RID: 104952 RVA: 0x00772843 File Offset: 0x00770A43
	// (set) Token: 0x060199F9 RID: 104953 RVA: 0x0077284B File Offset: 0x00770A4B
	public ESkillBehaviorComparisonLogic ComparisonLogic { get; set; }

	// Token: 0x1700227C RID: 8828
	// (get) Token: 0x060199FA RID: 104954 RVA: 0x00772854 File Offset: 0x00770A54
	// (set) Token: 0x060199FB RID: 104955 RVA: 0x0077285C File Offset: 0x00770A5C
	public float Value { get; set; }

	// Token: 0x1700227D RID: 8829
	// (get) Token: 0x060199FC RID: 104956 RVA: 0x00772865 File Offset: 0x00770A65
	// (set) Token: 0x060199FD RID: 104957 RVA: 0x0077286D File Offset: 0x00770A6D
	public float RangeL { get; set; }

	// Token: 0x1700227E RID: 8830
	// (get) Token: 0x060199FE RID: 104958 RVA: 0x00772876 File Offset: 0x00770A76
	// (set) Token: 0x060199FF RID: 104959 RVA: 0x0077287E File Offset: 0x00770A7E
	public float RangeR { get; set; }

	// Token: 0x1700227F RID: 8831
	// (get) Token: 0x06019A00 RID: 104960 RVA: 0x00772887 File Offset: 0x00770A87
	// (set) Token: 0x06019A01 RID: 104961 RVA: 0x0077288F File Offset: 0x00770A8F
	public EAttributeType AttributeId1 { get; set; }

	// Token: 0x17002280 RID: 8832
	// (get) Token: 0x06019A02 RID: 104962 RVA: 0x00772898 File Offset: 0x00770A98
	// (set) Token: 0x06019A03 RID: 104963 RVA: 0x007728A0 File Offset: 0x00770AA0
	public EAttributeType AttributeId2 { get; set; }

	// Token: 0x17002281 RID: 8833
	// (get) Token: 0x06019A04 RID: 104964 RVA: 0x007728A9 File Offset: 0x00770AA9
	// (set) Token: 0x06019A05 RID: 104965 RVA: 0x007728B1 File Offset: 0x00770AB1
	public int AttributeRate { get; set; }

	// Token: 0x17002282 RID: 8834
	// (get) Token: 0x06019A06 RID: 104966 RVA: 0x007728BA File Offset: 0x00770ABA
	// (set) Token: 0x06019A07 RID: 104967 RVA: 0x007728C2 File Offset: 0x00770AC2
	public IList<int> TagToCheck { get; set; }

	// Token: 0x17002283 RID: 8835
	// (get) Token: 0x06019A08 RID: 104968 RVA: 0x007728CB File Offset: 0x00770ACB
	// (set) Token: 0x06019A09 RID: 104969 RVA: 0x007728D3 File Offset: 0x00770AD3
	public bool AnyTag { get; set; }

	// Token: 0x17002284 RID: 8836
	// (get) Token: 0x06019A0A RID: 104970 RVA: 0x007728DC File Offset: 0x00770ADC
	// (set) Token: 0x06019A0B RID: 104971 RVA: 0x007728E4 File Offset: 0x00770AE4
	public bool Reverse { get; set; }

	// Token: 0x06019A0C RID: 104972 RVA: 0x007728F0 File Offset: 0x00770AF0
	public CfgInputActiveCondition(SInputActiveCondition ueCondition)
	{
		this.ConditionType = ueCondition.ConditionType;
		this.ComparisonLogic = ueCondition.ComparisonLogic;
		this.Value = ueCondition.Value;
		this.RangeL = ueCondition.RangeL;
		this.RangeR = ueCondition.RangeR;
		this.AttributeId1 = (EAttributeType)ueCondition.AttributeId1;
		this.AttributeId2 = (EAttributeType)ueCondition.AttributeId2;
		this.AttributeRate = ueCondition.AttributeRate;
		this.TagToCheck = GameplayTagUtils.ConvertFromUeContainer(ueCondition.TagToCheck);
		this.AnyTag = ueCondition.AnyTag;
		this.Reverse = ueCondition.Reverse;
	}
}
