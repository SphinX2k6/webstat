using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000F3A RID: 3898
[NullableContext(2)]
[Nullable(0)]
public class KscEntityParam : IKscEntityParam
{
	// Token: 0x17000733 RID: 1843
	// (get) Token: 0x06006188 RID: 24968 RVA: 0x001869D1 File Offset: 0x00184BD1
	// (set) Token: 0x06006189 RID: 24969 RVA: 0x001869D9 File Offset: 0x00184BD9
	public long CreatureId { get; set; }

	// Token: 0x17000734 RID: 1844
	// (get) Token: 0x0600618A RID: 24970 RVA: 0x001869E2 File Offset: 0x00184BE2
	// (set) Token: 0x0600618B RID: 24971 RVA: 0x001869EA File Offset: 0x00184BEA
	public int SimpleCombatId { get; set; }

	// Token: 0x17000735 RID: 1845
	// (get) Token: 0x0600618C RID: 24972 RVA: 0x001869F3 File Offset: 0x00184BF3
	// (set) Token: 0x0600618D RID: 24973 RVA: 0x001869FB File Offset: 0x00184BFB
	[Nullable(1)]
	public string AssetPath { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000736 RID: 1846
	// (get) Token: 0x0600618E RID: 24974 RVA: 0x00186A04 File Offset: 0x00184C04
	// (set) Token: 0x0600618F RID: 24975 RVA: 0x00186A0C File Offset: 0x00184C0C
	public int PropertyId { get; set; }

	// Token: 0x17000737 RID: 1847
	// (get) Token: 0x06006190 RID: 24976 RVA: 0x00186A15 File Offset: 0x00184C15
	// (set) Token: 0x06006191 RID: 24977 RVA: 0x00186A1D File Offset: 0x00184C1D
	public FTransformDouble Transform { get; set; }

	// Token: 0x17000738 RID: 1848
	// (get) Token: 0x06006192 RID: 24978 RVA: 0x00186A26 File Offset: 0x00184C26
	// (set) Token: 0x06006193 RID: 24979 RVA: 0x00186A2E File Offset: 0x00184C2E
	public USplineComponent Spline { get; set; }

	// Token: 0x17000739 RID: 1849
	// (get) Token: 0x06006194 RID: 24980 RVA: 0x00186A37 File Offset: 0x00184C37
	// (set) Token: 0x06006195 RID: 24981 RVA: 0x00186A3F File Offset: 0x00184C3F
	public Dictionary<int, int> Buffs { get; set; }

	// Token: 0x1700073A RID: 1850
	// (get) Token: 0x06006196 RID: 24982 RVA: 0x00186A48 File Offset: 0x00184C48
	// (set) Token: 0x06006197 RID: 24983 RVA: 0x00186A50 File Offset: 0x00184C50
	public Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x1700073B RID: 1851
	// (get) Token: 0x06006198 RID: 24984 RVA: 0x00186A59 File Offset: 0x00184C59
	// (set) Token: 0x06006199 RID: 24985 RVA: 0x00186A61 File Offset: 0x00184C61
	public EKSC_Faction? Faction { get; set; }

	// Token: 0x1700073C RID: 1852
	// (get) Token: 0x0600619A RID: 24986 RVA: 0x00186A6A File Offset: 0x00184C6A
	// (set) Token: 0x0600619B RID: 24987 RVA: 0x00186A72 File Offset: 0x00184C72
	public AActor RenderActor { get; set; }

	// Token: 0x1700073D RID: 1853
	// (get) Token: 0x0600619C RID: 24988 RVA: 0x00186A7B File Offset: 0x00184C7B
	// (set) Token: 0x0600619D RID: 24989 RVA: 0x00186A83 File Offset: 0x00184C83
	public bool? IsPreview { get; set; }

	// Token: 0x1700073E RID: 1854
	// (get) Token: 0x0600619E RID: 24990 RVA: 0x00186A8C File Offset: 0x00184C8C
	// (set) Token: 0x0600619F RID: 24991 RVA: 0x00186A94 File Offset: 0x00184C94
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<AKSC_Entity> OnEntityAdd { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x1700073F RID: 1855
	// (get) Token: 0x060061A0 RID: 24992 RVA: 0x00186A9D File Offset: 0x00184C9D
	// (set) Token: 0x060061A1 RID: 24993 RVA: 0x00186AA5 File Offset: 0x00184CA5
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<AKSC_Entity> FinishCallback { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000740 RID: 1856
	// (get) Token: 0x060061A2 RID: 24994 RVA: 0x00186AAE File Offset: 0x00184CAE
	// (set) Token: 0x060061A3 RID: 24995 RVA: 0x00186AB6 File Offset: 0x00184CB6
	public UniTask? WaitToBegin { get; set; }
}
