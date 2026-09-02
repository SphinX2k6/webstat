using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C3 RID: 12483
[NullableContext(2)]
public interface IMorphData
{
	// Token: 0x170022A2 RID: 8866
	// (get) Token: 0x06019B9C RID: 105372
	// (set) Token: 0x06019B9D RID: 105373
	int ModelId { get; set; }

	// Token: 0x170022A3 RID: 8867
	// (get) Token: 0x06019B9E RID: 105374
	// (set) Token: 0x06019B9F RID: 105375
	USkeletalMesh SkeletalMesh { get; set; }

	// Token: 0x170022A4 RID: 8868
	// (get) Token: 0x06019BA0 RID: 105376
	// (set) Token: 0x06019BA1 RID: 105377
	UClass AnimClass { get; set; }

	// Token: 0x170022A5 RID: 8869
	// (get) Token: 0x06019BA2 RID: 105378
	// (set) Token: 0x06019BA3 RID: 105379
	[Nullable(new byte[]
	{
		2,
		1
	})]
	TSoftObjectPtr<UDataTable> DtBaseMovementSetting { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022A6 RID: 8870
	// (get) Token: 0x06019BA4 RID: 105380
	// (set) Token: 0x06019BA5 RID: 105381
	[Nullable(new byte[]
	{
		2,
		1
	})]
	TSoftObjectPtr<UDataTable> DtCameraConfig { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022A7 RID: 8871
	// (get) Token: 0x06019BA6 RID: 105382
	// (set) Token: 0x06019BA7 RID: 105383
	FSoftClassPath InputComponentClass { get; set; }

	// Token: 0x170022A8 RID: 8872
	// (get) Token: 0x06019BA8 RID: 105384
	// (set) Token: 0x06019BA9 RID: 105385
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	Dictionary<string, Dictionary<string, float>> ComponentFloatParams { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x170022A9 RID: 8873
	// (get) Token: 0x06019BAA RID: 105386
	// (set) Token: 0x06019BAB RID: 105387
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	Dictionary<string, Dictionary<string, Vector>> ComponentVectorParams { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})] set; }

	// Token: 0x170022AA RID: 8874
	// (get) Token: 0x06019BAC RID: 105388
	// (set) Token: 0x06019BAD RID: 105389
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	Dictionary<string, Dictionary<string, string>> ComponentStringParams { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})] set; }
}
