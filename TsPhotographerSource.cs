using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020025BA RID: 9658
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/Photograph/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographerSource.TsPhotographerSource_C")]
public class TsPhotographerSource : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x06012DFA RID: 77306 RVA: 0x0053849D File Offset: 0x0053669D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsPhotographerSource._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographerSource.TsPhotographerSource_C");
		}
		return TsPhotographerSource._ClassPtr;
	}

	// Token: 0x06012DFB RID: 77307 RVA: 0x005384C4 File Offset: 0x005366C4
	public TsPhotographerSource() : this(BuiltinUtils.AllocNativeUObject(TsPhotographerSource.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06012DFC RID: 77308 RVA: 0x005384EC File Offset: 0x005366EC
	public TsPhotographerSource(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographerSource.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06012DFD RID: 77309 RVA: 0x0053851F File Offset: 0x0053671F
	protected TsPhotographerSource(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x170017B4 RID: 6068
	// (get) Token: 0x06012DFE RID: 77310 RVA: 0x00538528 File Offset: 0x00536728
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsPhotographerSource.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x170017B5 RID: 6069
	// (get) Token: 0x06012DFF RID: 77311 RVA: 0x00538538 File Offset: 0x00536738
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsPhotographerSource.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x04009393 RID: 37779
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographerSource.TsPhotographerSource_C";

	// Token: 0x04009394 RID: 37780
	private static IntPtr _ClassPtr;

	// Token: 0x04009395 RID: 37781
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04009396 RID: 37782
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x04009397 RID: 37783
	private static int __PropertyOffset_DefaultSceneRoot;
}
