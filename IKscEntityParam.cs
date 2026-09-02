using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000F39 RID: 3897
[NullableContext(2)]
public interface IKscEntityParam
{
	// Token: 0x17000725 RID: 1829
	// (get) Token: 0x0600616C RID: 24940
	// (set) Token: 0x0600616D RID: 24941
	long CreatureId { get; set; }

	// Token: 0x17000726 RID: 1830
	// (get) Token: 0x0600616E RID: 24942
	// (set) Token: 0x0600616F RID: 24943
	int SimpleCombatId { get; set; }

	// Token: 0x17000727 RID: 1831
	// (get) Token: 0x06006170 RID: 24944
	// (set) Token: 0x06006171 RID: 24945
	[Nullable(1)]
	string AssetPath { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000728 RID: 1832
	// (get) Token: 0x06006172 RID: 24946
	// (set) Token: 0x06006173 RID: 24947
	int PropertyId { get; set; }

	// Token: 0x17000729 RID: 1833
	// (get) Token: 0x06006174 RID: 24948
	// (set) Token: 0x06006175 RID: 24949
	FTransformDouble Transform { get; set; }

	// Token: 0x1700072A RID: 1834
	// (get) Token: 0x06006176 RID: 24950
	// (set) Token: 0x06006177 RID: 24951
	USplineComponent Spline { get; set; }

	// Token: 0x1700072B RID: 1835
	// (get) Token: 0x06006178 RID: 24952
	// (set) Token: 0x06006179 RID: 24953
	Dictionary<int, int> Buffs { get; set; }

	// Token: 0x1700072C RID: 1836
	// (get) Token: 0x0600617A RID: 24954
	// (set) Token: 0x0600617B RID: 24955
	Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x1700072D RID: 1837
	// (get) Token: 0x0600617C RID: 24956
	// (set) Token: 0x0600617D RID: 24957
	EKSC_Faction? Faction { get; set; }

	// Token: 0x1700072E RID: 1838
	// (get) Token: 0x0600617E RID: 24958
	// (set) Token: 0x0600617F RID: 24959
	AActor RenderActor { get; set; }

	// Token: 0x1700072F RID: 1839
	// (get) Token: 0x06006180 RID: 24960
	// (set) Token: 0x06006181 RID: 24961
	bool? IsPreview { get; set; }

	// Token: 0x17000730 RID: 1840
	// (get) Token: 0x06006182 RID: 24962
	// (set) Token: 0x06006183 RID: 24963
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Action<AKSC_Entity> OnEntityAdd { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000731 RID: 1841
	// (get) Token: 0x06006184 RID: 24964
	// (set) Token: 0x06006185 RID: 24965
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Action<AKSC_Entity> FinishCallback { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000732 RID: 1842
	// (get) Token: 0x06006186 RID: 24966
	// (set) Token: 0x06006187 RID: 24967
	UniTask? WaitToBegin { get; set; }
}
