using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200385D RID: 14429
public class __TsPhotographer_InheritProxy : TsPhotographer
{
	// Token: 0x0601D569 RID: 120169 RVA: 0x008C8E6C File Offset: 0x008C706C
	[NullableContext(1)]
	public __TsPhotographer_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographer.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D56A RID: 120170 RVA: 0x008C8E9F File Offset: 0x008C709F
	protected __TsPhotographer_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D56B RID: 120171 RVA: 0x008C8EA8 File Offset: 0x008C70A8
	protected override void __CPPCALL_Initialize_Implementation()
	{
		base.Initialize_Implementation();
	}

	// Token: 0x0601D56C RID: 120172 RVA: 0x008C8EB0 File Offset: 0x008C70B0
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}

	// Token: 0x0601D56D RID: 120173 RVA: 0x008C8EB8 File Offset: 0x008C70B8
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D56E RID: 120174 RVA: 0x008C8EC6 File Offset: 0x008C70C6
	protected override void __CPPCALL_RefreshPlayerLocation_Implementation()
	{
		base.RefreshPlayerLocation_Implementation();
	}

	// Token: 0x0601D56F RID: 120175 RVA: 0x008C8ECE File Offset: 0x008C70CE
	protected unsafe override void __CPPCALL_SetPlayerSourceLocation_Implementation(TsPhotographer.__SetPlayerSourceLocation_FunctionParams* __Params)
	{
		base.SetPlayerSourceLocation_Implementation(__Params->location);
	}

	// Token: 0x0601D570 RID: 120176 RVA: 0x008C8EDC File Offset: 0x008C70DC
	protected unsafe override void __CPPCALL_SetCameraInitializeTransform_Implementation(TsPhotographer.__SetCameraInitializeTransform_FunctionParams* __Params)
	{
		base.SetCameraInitializeTransform_Implementation(__Params->transform);
	}

	// Token: 0x0601D571 RID: 120177 RVA: 0x008C8EEA File Offset: 0x008C70EA
	protected unsafe override void __CPPCALL_GetCameraInitializeTransform_Implementation(TsPhotographer.__GetCameraInitializeTransform_FunctionParams* __Params)
	{
		__Params->__Result = base.GetCameraInitializeTransform_Implementation();
	}

	// Token: 0x0601D572 RID: 120178 RVA: 0x008C8EF8 File Offset: 0x008C70F8
	protected unsafe override void __CPPCALL_SetCameraInitializeFov_Implementation(TsPhotographer.__SetCameraInitializeFov_FunctionParams* __Params)
	{
		base.SetCameraInitializeFov_Implementation(__Params->fov);
	}

	// Token: 0x0601D573 RID: 120179 RVA: 0x008C8F06 File Offset: 0x008C7106
	protected unsafe override void __CPPCALL_GetCameraInitializeFov_Implementation(TsPhotographer.__GetCameraInitializeFov_FunctionParams* __Params)
	{
		__Params->__Result = base.GetCameraInitializeFov_Implementation();
	}

	// Token: 0x0601D574 RID: 120180 RVA: 0x008C8F14 File Offset: 0x008C7114
	protected unsafe override void __CPPCALL_SetCameraArmTargetOffset_Implementation(TsPhotographer.__SetCameraArmTargetOffset_FunctionParams* __Params)
	{
		base.SetCameraArmTargetOffset_Implementation(__Params->cameraLocation, __Params->isInit);
	}

	// Token: 0x0601D575 RID: 120181 RVA: 0x008C8F28 File Offset: 0x008C7128
	protected unsafe override void __CPPCALL_MoveUp_Implementation(TsPhotographer.__MoveUp_FunctionParams* __Params)
	{
		base.MoveUp_Implementation(__Params->addValue);
	}

	// Token: 0x0601D576 RID: 120182 RVA: 0x008C8F36 File Offset: 0x008C7136
	protected unsafe override void __CPPCALL_MoveRight_Implementation(TsPhotographer.__MoveRight_FunctionParams* __Params)
	{
		base.MoveRight_Implementation(__Params->addValue);
	}

	// Token: 0x0601D577 RID: 120183 RVA: 0x008C8F44 File Offset: 0x008C7144
	protected unsafe override void __CPPCALL_MoveForward_Implementation(TsPhotographer.__MoveForward_FunctionParams* __Params)
	{
		base.MoveForward_Implementation(__Params->addValue);
	}

	// Token: 0x0601D578 RID: 120184 RVA: 0x008C8F52 File Offset: 0x008C7152
	protected unsafe override void __CPPCALL_SetFov_Implementation(TsPhotographer.__SetFov_FunctionParams* __Params)
	{
		base.SetFov_Implementation(__Params->fov);
	}

	// Token: 0x0601D579 RID: 120185 RVA: 0x008C8F60 File Offset: 0x008C7160
	protected unsafe override void __CPPCALL_GetFov_Implementation(TsPhotographer.__GetFov_FunctionParams* __Params)
	{
		__Params->__Result = base.GetFov_Implementation();
	}

	// Token: 0x0601D57A RID: 120186 RVA: 0x008C8F6E File Offset: 0x008C716E
	protected override void __CPPCALL_ResetCamera_Implementation()
	{
		base.ResetCamera_Implementation();
	}

	// Token: 0x0601D57B RID: 120187 RVA: 0x008C8F78 File Offset: 0x008C7178
	protected unsafe override void __CPPCALL_SetCameraLUT_Implementation(TsPhotographer.__SetCameraLUT_FunctionParams* __Params)
	{
		string cameraLUT_Implementation = FString.ToString((void*)(&__Params->texturePath));
		base.SetCameraLUT_Implementation(cameraLUT_Implementation);
	}
}
