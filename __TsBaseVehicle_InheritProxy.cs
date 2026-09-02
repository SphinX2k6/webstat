using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038F5 RID: 14581
public class __TsBaseVehicle_InheritProxy : TsBaseVehicle
{
	// Token: 0x0601D752 RID: 120658 RVA: 0x008CD740 File Offset: 0x008CB940
	[NullableContext(1)]
	public __TsBaseVehicle_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D753 RID: 120659 RVA: 0x008CD773 File Offset: 0x008CB973
	protected __TsBaseVehicle_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D754 RID: 120660 RVA: 0x008CD77C File Offset: 0x008CB97C
	protected unsafe override void __CPPCALL_GetEntityId_Implementation(TsBaseVehicle.__GetEntityId_FunctionParams* __Params)
	{
		__Params->__Result = base.GetEntityId_Implementation();
	}

	// Token: 0x0601D755 RID: 120661 RVA: 0x008CD78A File Offset: 0x008CB98A
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}

	// Token: 0x0601D756 RID: 120662 RVA: 0x008CD794 File Offset: 0x008CB994
	protected unsafe override void __CPPCALL_SetDitherEffect_Implementation(TsBaseVehicle.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		base.SetDitherEffect_Implementation(__Params->dither, ditherType);
	}
}
