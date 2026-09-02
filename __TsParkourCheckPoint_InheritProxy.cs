using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384F RID: 14415
public class __TsParkourCheckPoint_InheritProxy : TsParkourCheckPoint
{
	// Token: 0x0601D53B RID: 120123 RVA: 0x008C8678 File Offset: 0x008C6878
	[NullableContext(1)]
	public __TsParkourCheckPoint_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsParkourCheckPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D53C RID: 120124 RVA: 0x008C86AB File Offset: 0x008C68AB
	protected __TsParkourCheckPoint_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D53D RID: 120125 RVA: 0x008C86B4 File Offset: 0x008C68B4
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D53E RID: 120126 RVA: 0x008C86BC File Offset: 0x008C68BC
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D53F RID: 120127 RVA: 0x008C86DC File Offset: 0x008C68DC
	protected unsafe override void __CPPCALL_SetDetectSphere_Implementation(TsParkourCheckPoint.__SetDetectSphere_FunctionParams* __Params)
	{
		base.SetDetectSphere_Implementation(__Params->inRadius);
	}

	// Token: 0x0601D540 RID: 120128 RVA: 0x008C86EC File Offset: 0x008C68EC
	protected unsafe override void __CPPCALL_GenerateFx_Implementation(TsParkourCheckPoint.__GenerateFx_FunctionParams* __Params)
	{
		UEffectModelBase orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UEffectModelBase>(__Params->inModelBase);
		base.GenerateFx_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D541 RID: 120129 RVA: 0x008C870C File Offset: 0x008C690C
	protected unsafe override void __CPPCALL_GenerateFxByPath_Implementation(TsParkourCheckPoint.__GenerateFxByPath_FunctionParams* __Params)
	{
		string effectPath = FString.ToString((void*)(&__Params->effectPath));
		base.GenerateFxByPath_Implementation(effectPath);
	}
}
