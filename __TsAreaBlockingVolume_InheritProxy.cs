using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003845 RID: 14405
public class __TsAreaBlockingVolume_InheritProxy : TsAreaBlockingVolume
{
	// Token: 0x0601D518 RID: 120088 RVA: 0x008C7F58 File Offset: 0x008C6158
	[NullableContext(1)]
	public __TsAreaBlockingVolume_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAreaBlockingVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D519 RID: 120089 RVA: 0x008C7F8B File Offset: 0x008C618B
	protected __TsAreaBlockingVolume_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D51A RID: 120090 RVA: 0x008C7F94 File Offset: 0x008C6194
	protected override void __CPPCALL_NotifyEnterArea_Implementation()
	{
		base.NotifyEnterArea_Implementation();
	}

	// Token: 0x0601D51B RID: 120091 RVA: 0x008C7F9C File Offset: 0x008C619C
	protected unsafe override void __CPPCALL_ReceiveHit_Implementation(AActor.__ReceiveHit_FunctionParams* __Params)
	{
		UPrimitiveComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UPrimitiveComponent>(__Params->MyComp);
		AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->Other);
		UPrimitiveComponent orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UPrimitiveComponent>(__Params->OtherComp);
		FHitResult fhitResult = new FHitResult(&__Params->Hit, true, true);
		base.ReceiveHit_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, orCreateUObjectByNativePointer3, __Params->bSelfMoved, __Params->HitLocation, __Params->HitNormal, __Params->NormalImpulse, fhitResult);
	}
}
