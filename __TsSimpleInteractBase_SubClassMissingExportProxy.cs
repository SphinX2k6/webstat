using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.World;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E2 RID: 14562
[NullableContext(1)]
[Nullable(0)]
public class __TsSimpleInteractBase_SubClassMissingExportProxy : __TsSimpleInteractBase_InheritProxy
{
	// Token: 0x0601D702 RID: 120578 RVA: 0x008CC69C File Offset: 0x008CA89C
	protected __TsSimpleInteractBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D703 RID: 120579 RVA: 0x008CC6CF File Offset: 0x008CA8CF
	protected __TsSimpleInteractBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D704 RID: 120580 RVA: 0x008CC6D8 File Offset: 0x008CA8D8
	public unsafe override SSimpleInteractResult GetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetBestTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsSimpleInteractBase.__GetBestTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsSimpleInteractBase.__GetBestTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsSimpleInteractBase.__GetBestTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actor) = ((actor != null) ? actor.NativePtr : ((IntPtr)0));
			ptr2->moveOffset = moveOffset;
			ptr2->halfHeight = halfHeight;
			ptr2->radius = radius;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		SSimpleInteractResult _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D705 RID: 120581 RVA: 0x008CC77C File Offset: 0x008CA97C
	public unsafe override void Draw()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Draw"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
