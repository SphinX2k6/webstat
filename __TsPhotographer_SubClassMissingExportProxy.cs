using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200385E RID: 14430
[NullableContext(1)]
[Nullable(0)]
public class __TsPhotographer_SubClassMissingExportProxy : __TsPhotographer_InheritProxy
{
	// Token: 0x0601D57C RID: 120188 RVA: 0x008C8F9C File Offset: 0x008C719C
	protected __TsPhotographer_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographer.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D57D RID: 120189 RVA: 0x008C8FCF File Offset: 0x008C71CF
	protected __TsPhotographer_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D57E RID: 120190 RVA: 0x008C8FD8 File Offset: 0x008C71D8
	public unsafe override void Initialize()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Initialize"), out num);
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

	// Token: 0x0601D57F RID: 120191 RVA: 0x008C9048 File Offset: 0x008C7248
	public unsafe override void RefreshPlayerLocation()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RefreshPlayerLocation"), out num);
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

	// Token: 0x0601D580 RID: 120192 RVA: 0x008C90B8 File Offset: 0x008C72B8
	public unsafe override void SetPlayerSourceLocation(FVectorDouble location)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetPlayerSourceLocation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetPlayerSourceLocation_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetPlayerSourceLocation_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetPlayerSourceLocation_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->location = location;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D581 RID: 120193 RVA: 0x008C9130 File Offset: 0x008C7330
	public unsafe override void SetCameraInitializeTransform(FTransformDouble transform)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraInitializeTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraInitializeTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraInitializeTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraInitializeTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->transform = transform;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D582 RID: 120194 RVA: 0x008C91A8 File Offset: 0x008C73A8
	public unsafe override FTransformDouble GetCameraInitializeTransform()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCameraInitializeTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetCameraInitializeTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetCameraInitializeTransform_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetCameraInitializeTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		FTransformDouble _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D583 RID: 120195 RVA: 0x008C9220 File Offset: 0x008C7420
	public unsafe override void SetCameraInitializeFov(float fov)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraInitializeFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraInitializeFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraInitializeFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraInitializeFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->fov = fov;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D584 RID: 120196 RVA: 0x008C9298 File Offset: 0x008C7498
	public unsafe override float GetCameraInitializeFov()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCameraInitializeFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetCameraInitializeFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetCameraInitializeFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetCameraInitializeFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D585 RID: 120197 RVA: 0x008C9310 File Offset: 0x008C7510
	public unsafe override void SetCameraArmTargetOffset(FVectorDouble cameraLocation, bool isInit)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraArmTargetOffset"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraArmTargetOffset_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraArmTargetOffset_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraArmTargetOffset_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->cameraLocation = cameraLocation;
			ptr2->isInit = isInit;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D586 RID: 120198 RVA: 0x008C9390 File Offset: 0x008C7590
	public unsafe override void MoveUp(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveUp"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveUp_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveUp_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveUp_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D587 RID: 120199 RVA: 0x008C9408 File Offset: 0x008C7608
	public unsafe override void MoveRight(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveRight"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveRight_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveRight_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveRight_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D588 RID: 120200 RVA: 0x008C9480 File Offset: 0x008C7680
	public unsafe override void MoveForward(float addValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MoveForward"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__MoveForward_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__MoveForward_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__MoveForward_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addValue = addValue;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D589 RID: 120201 RVA: 0x008C94F8 File Offset: 0x008C76F8
	public unsafe override void SetFov(float fov)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->fov = fov;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D58A RID: 120202 RVA: 0x008C9570 File Offset: 0x008C7770
	public unsafe override float GetFov()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetFov"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__GetFov_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__GetFov_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__GetFov_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D58B RID: 120203 RVA: 0x008C95E8 File Offset: 0x008C77E8
	public unsafe override void ResetCamera()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetCamera"), out num);
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

	// Token: 0x0601D58C RID: 120204 RVA: 0x008C9658 File Offset: 0x008C7858
	public unsafe override void SetCameraLUT(string texturePath)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCameraLUT"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsPhotographer.__SetCameraLUT_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsPhotographer.__SetCameraLUT_FunctionParams*)ptr + 15L / (long)sizeof(TsPhotographer.__SetCameraLUT_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->texturePath), texturePath);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
