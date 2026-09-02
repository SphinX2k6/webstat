using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using UnrealEngine;

// Token: 0x02002C8B RID: 11403
[NullableContext(2)]
public interface IUiMorphId
{
	// Token: 0x17001E13 RID: 7699
	// (get) Token: 0x06016E17 RID: 93719
	// (set) Token: 0x06016E18 RID: 93720
	string MainMeshPath { get; set; }

	// Token: 0x17001E14 RID: 7700
	// (get) Token: 0x06016E19 RID: 93721
	// (set) Token: 0x06016E1A RID: 93722
	string AnimPath { get; set; }

	// Token: 0x17001E15 RID: 7701
	// (get) Token: 0x06016E1B RID: 93723
	// (set) Token: 0x06016E1C RID: 93724
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<string> ChildMeshPathList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001E16 RID: 7702
	// (get) Token: 0x06016E1D RID: 93725
	// (set) Token: 0x06016E1E RID: 93726
	[Nullable(1)]
	TArray<SModelDecorationConfig> DecorationMeshConfigArray { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001E17 RID: 7703
	// (get) Token: 0x06016E1F RID: 93727
	// (set) Token: 0x06016E20 RID: 93728
	string RoleBody { get; set; }
}
