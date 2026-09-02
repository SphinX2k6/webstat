using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C8A RID: 11402
[NullableContext(2)]
[Nullable(0)]
public class UiMorphData : IUiMorphData
{
	// Token: 0x17001E0E RID: 7694
	// (get) Token: 0x06016E0C RID: 93708 RVA: 0x00658F89 File Offset: 0x00657189
	// (set) Token: 0x06016E0D RID: 93709 RVA: 0x00658F91 File Offset: 0x00657191
	public USkeletalMesh MainSkeletalMesh { get; set; }

	// Token: 0x17001E0F RID: 7695
	// (get) Token: 0x06016E0E RID: 93710 RVA: 0x00658F9A File Offset: 0x0065719A
	// (set) Token: 0x06016E0F RID: 93711 RVA: 0x00658FA2 File Offset: 0x006571A2
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<USkeletalMesh> ChildSkeletalMesh { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001E10 RID: 7696
	// (get) Token: 0x06016E10 RID: 93712 RVA: 0x00658FAB File Offset: 0x006571AB
	// (set) Token: 0x06016E11 RID: 93713 RVA: 0x00658FB3 File Offset: 0x006571B3
	[Nullable(1)]
	public List<UiModelDecorationParam> DecorationParamList { [NullableContext(1)] get; [NullableContext(1)] set; } = new List<UiModelDecorationParam>();

	// Token: 0x17001E11 RID: 7697
	// (get) Token: 0x06016E12 RID: 93714 RVA: 0x00658FBC File Offset: 0x006571BC
	// (set) Token: 0x06016E13 RID: 93715 RVA: 0x00658FC4 File Offset: 0x006571C4
	public UClass AnimClass { get; set; }

	// Token: 0x17001E12 RID: 7698
	// (get) Token: 0x06016E14 RID: 93716 RVA: 0x00658FCD File Offset: 0x006571CD
	// (set) Token: 0x06016E15 RID: 93717 RVA: 0x00658FD5 File Offset: 0x006571D5
	public string RoleBody { get; set; }
}
