using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C89 RID: 11401
[NullableContext(2)]
public interface IUiMorphData
{
	// Token: 0x17001E09 RID: 7689
	// (get) Token: 0x06016E02 RID: 93698
	// (set) Token: 0x06016E03 RID: 93699
	USkeletalMesh MainSkeletalMesh { get; set; }

	// Token: 0x17001E0A RID: 7690
	// (get) Token: 0x06016E04 RID: 93700
	// (set) Token: 0x06016E05 RID: 93701
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<USkeletalMesh> ChildSkeletalMesh { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001E0B RID: 7691
	// (get) Token: 0x06016E06 RID: 93702
	// (set) Token: 0x06016E07 RID: 93703
	[Nullable(1)]
	List<UiModelDecorationParam> DecorationParamList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001E0C RID: 7692
	// (get) Token: 0x06016E08 RID: 93704
	// (set) Token: 0x06016E09 RID: 93705
	UClass AnimClass { get; set; }

	// Token: 0x17001E0D RID: 7693
	// (get) Token: 0x06016E0A RID: 93706
	// (set) Token: 0x06016E0B RID: 93707
	string RoleBody { get; set; }
}
