using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C4 RID: 12484
[NullableContext(2)]
[Nullable(0)]
public class MorphData : IMorphData
{
	// Token: 0x170022AB RID: 8875
	// (get) Token: 0x06019BAE RID: 105390 RVA: 0x0077C964 File Offset: 0x0077AB64
	// (set) Token: 0x06019BAF RID: 105391 RVA: 0x0077C96C File Offset: 0x0077AB6C
	public int ModelId { get; set; }

	// Token: 0x170022AC RID: 8876
	// (get) Token: 0x06019BB0 RID: 105392 RVA: 0x0077C975 File Offset: 0x0077AB75
	// (set) Token: 0x06019BB1 RID: 105393 RVA: 0x0077C97D File Offset: 0x0077AB7D
	public USkeletalMesh SkeletalMesh { get; set; }

	// Token: 0x170022AD RID: 8877
	// (get) Token: 0x06019BB2 RID: 105394 RVA: 0x0077C986 File Offset: 0x0077AB86
	// (set) Token: 0x06019BB3 RID: 105395 RVA: 0x0077C98E File Offset: 0x0077AB8E
	public UClass AnimClass { get; set; }

	// Token: 0x170022AE RID: 8878
	// (get) Token: 0x06019BB4 RID: 105396 RVA: 0x0077C997 File Offset: 0x0077AB97
	// (set) Token: 0x06019BB5 RID: 105397 RVA: 0x0077C99F File Offset: 0x0077AB9F
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TSoftObjectPtr<UDataTable> DtBaseMovementSetting { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022AF RID: 8879
	// (get) Token: 0x06019BB6 RID: 105398 RVA: 0x0077C9A8 File Offset: 0x0077ABA8
	// (set) Token: 0x06019BB7 RID: 105399 RVA: 0x0077C9B0 File Offset: 0x0077ABB0
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TSoftObjectPtr<UDataTable> DtCameraConfig { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022B0 RID: 8880
	// (get) Token: 0x06019BB8 RID: 105400 RVA: 0x0077C9B9 File Offset: 0x0077ABB9
	// (set) Token: 0x06019BB9 RID: 105401 RVA: 0x0077C9C1 File Offset: 0x0077ABC1
	public FSoftClassPath InputComponentClass { get; set; }

	// Token: 0x170022B1 RID: 8881
	// (get) Token: 0x06019BBA RID: 105402 RVA: 0x0077C9CA File Offset: 0x0077ABCA
	// (set) Token: 0x06019BBB RID: 105403 RVA: 0x0077C9D2 File Offset: 0x0077ABD2
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public Dictionary<string, Dictionary<string, float>> ComponentFloatParams { [return: Nullable(new byte[]
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

	// Token: 0x170022B2 RID: 8882
	// (get) Token: 0x06019BBC RID: 105404 RVA: 0x0077C9DB File Offset: 0x0077ABDB
	// (set) Token: 0x06019BBD RID: 105405 RVA: 0x0077C9E3 File Offset: 0x0077ABE3
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	public Dictionary<string, Dictionary<string, Vector>> ComponentVectorParams { [return: Nullable(new byte[]
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

	// Token: 0x170022B3 RID: 8883
	// (get) Token: 0x06019BBE RID: 105406 RVA: 0x0077C9EC File Offset: 0x0077ABEC
	// (set) Token: 0x06019BBF RID: 105407 RVA: 0x0077C9F4 File Offset: 0x0077ABF4
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	public Dictionary<string, Dictionary<string, string>> ComponentStringParams { [return: Nullable(new byte[]
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
