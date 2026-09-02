using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using UnrealEngine;

// Token: 0x02000E3F RID: 3647
[NullableContext(1)]
public interface ICapabilityGameObject
{
	// Token: 0x06005752 RID: 22354
	string GetId();

	// Token: 0x06005753 RID: 22355
	[NullableContext(2)]
	AActor GetBoundActor();

	// Token: 0x06005754 RID: 22356
	bool IsValid();

	// Token: 0x06005755 RID: 22357
	T AddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData;

	// Token: 0x06005756 RID: 22358
	[return: Nullable(2)]
	T GetCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData;

	// Token: 0x06005757 RID: 22359
	bool HasCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData;

	// Token: 0x06005758 RID: 22360
	T GetOrAddCapabilityData<[Nullable(0)] T>(Type ctor) where T : CapabilityData;

	// Token: 0x06005759 RID: 22361
	T AddCapability<[Nullable(0)] T>(Type ctor) where T : Capability;

	// Token: 0x0600575A RID: 22362
	bool RemoveCapability<[Nullable(0)] T>(Type ctor) where T : Capability;

	// Token: 0x0600575B RID: 22363
	IReadOnlyDictionary<Type, Capability> GetCapabilities();

	// Token: 0x0600575C RID: 22364
	[return: Nullable(2)]
	T GetCapability<[Nullable(0)] T>(Type ctor) where T : Capability;

	// Token: 0x0600575D RID: 22365
	void BlockCapabilities(int tag, object instigator);

	// Token: 0x0600575E RID: 22366
	void UnblockCapabilities(int tag, object instigator);

	// Token: 0x0600575F RID: 22367
	bool IsCapabilityState(Capability cap, CapabilityCommonDefine.ECapabilityState state);
}
