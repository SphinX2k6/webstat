using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using UnrealEngine;

// Token: 0x02002C8C RID: 11404
[NullableContext(2)]
[Nullable(0)]
public class UiMorphId : IUiMorphId
{
	// Token: 0x17001E18 RID: 7704
	// (get) Token: 0x06016E21 RID: 93729 RVA: 0x00658FF1 File Offset: 0x006571F1
	// (set) Token: 0x06016E22 RID: 93730 RVA: 0x00658FF9 File Offset: 0x006571F9
	public string MainMeshPath { get; set; }

	// Token: 0x17001E19 RID: 7705
	// (get) Token: 0x06016E23 RID: 93731 RVA: 0x00659002 File Offset: 0x00657202
	// (set) Token: 0x06016E24 RID: 93732 RVA: 0x0065900A File Offset: 0x0065720A
	public string AnimPath { get; set; }

	// Token: 0x17001E1A RID: 7706
	// (get) Token: 0x06016E25 RID: 93733 RVA: 0x00659013 File Offset: 0x00657213
	// (set) Token: 0x06016E26 RID: 93734 RVA: 0x0065901B File Offset: 0x0065721B
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> ChildMeshPathList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001E1B RID: 7707
	// (get) Token: 0x06016E27 RID: 93735 RVA: 0x00659024 File Offset: 0x00657224
	// (set) Token: 0x06016E28 RID: 93736 RVA: 0x0065902C File Offset: 0x0065722C
	[Nullable(1)]
	public TArray<SModelDecorationConfig> DecorationMeshConfigArray { [NullableContext(1)] get; [NullableContext(1)] set; } = new TArray<SModelDecorationConfig>();

	// Token: 0x17001E1C RID: 7708
	// (get) Token: 0x06016E29 RID: 93737 RVA: 0x00659035 File Offset: 0x00657235
	// (set) Token: 0x06016E2A RID: 93738 RVA: 0x0065903D File Offset: 0x0065723D
	public string RoleBody { get; set; }
}
