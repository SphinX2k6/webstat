using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038DB RID: 14555
public class __TsSimpleNpc_InheritProxy : TsSimpleNpc
{
	// Token: 0x0601D6D1 RID: 120529 RVA: 0x008CBE54 File Offset: 0x008CA054
	[NullableContext(1)]
	public __TsSimpleNpc_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleNpc.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6D2 RID: 120530 RVA: 0x008CBE87 File Offset: 0x008CA087
	protected __TsSimpleNpc_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D6D3 RID: 120531 RVA: 0x008CBE90 File Offset: 0x008CA090
	protected override void __CPPCALL_EditorInit_Implementation()
	{
		base.EditorInit_Implementation();
	}

	// Token: 0x0601D6D4 RID: 120532 RVA: 0x008CBE98 File Offset: 0x008CA098
	protected unsafe override void __CPPCALL_EditorTick_Implementation(AKuroEffectActor.__EditorTick_FunctionParams* __Params)
	{
		base.EditorTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D6D5 RID: 120533 RVA: 0x008CBEA6 File Offset: 0x008CA0A6
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D6D6 RID: 120534 RVA: 0x008CBEAE File Offset: 0x008CA0AE
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(TsSimpleNpc.__ReceiveEndPlay_FunctionParams* __Params)
	{
		base.ReceiveEndPlay_Implementation(__Params->endPlayReason);
	}

	// Token: 0x0601D6D7 RID: 120535 RVA: 0x008CBEBC File Offset: 0x008CA0BC
	protected override void __CPPCALL_LoadModel_Implementation()
	{
		base.LoadModel_Implementation();
	}

	// Token: 0x0601D6D8 RID: 120536 RVA: 0x008CBEC4 File Offset: 0x008CA0C4
	protected unsafe override void __CPPCALL_DebugSetNpcDitherValue_Implementation(TsSimpleNpc.__DebugSetNpcDitherValue_FunctionParams* __Params)
	{
		base.DebugSetNpcDitherValue_Implementation(__Params->value);
	}

	// Token: 0x0601D6D9 RID: 120537 RVA: 0x008CBED2 File Offset: 0x008CA0D2
	protected override void __CPPCALL_SetDefaultCollision_Implementation()
	{
		base.SetDefaultCollision_Implementation();
	}

	// Token: 0x0601D6DA RID: 120538 RVA: 0x008CBEDA File Offset: 0x008CA0DA
	protected override void __CPPCALL_ResetMeshLocation_Implementation()
	{
		base.ResetMeshLocation_Implementation();
	}

	// Token: 0x0601D6DB RID: 120539 RVA: 0x008CBEE2 File Offset: 0x008CA0E2
	protected override void __CPPCALL_FindFloor_Implementation()
	{
		base.FindFloor_Implementation();
	}

	// Token: 0x0601D6DC RID: 120540 RVA: 0x008CBEEC File Offset: 0x008CA0EC
	protected unsafe override void __CPPCALL_ShowDialog_Implementation(TsSimpleNpc.__ShowDialog_FunctionParams* __Params)
	{
		string text = FString.ToString((void*)(&__Params->text));
		base.ShowDialog_Implementation(text, __Params->removeSeconds);
	}

	// Token: 0x0601D6DD RID: 120541 RVA: 0x008CBF13 File Offset: 0x008CA113
	protected override void __CPPCALL_HideDialog_Implementation()
	{
		base.HideDialog_Implementation();
	}

	// Token: 0x0601D6DE RID: 120542 RVA: 0x008CBF1C File Offset: 0x008CA11C
	protected unsafe override void __CPPCALL_TryPlayMontage_Implementation(TsSimpleNpc.__TryPlayMontage_FunctionParams* __Params)
	{
		string montagePath = FString.ToString((void*)(&__Params->montagePath));
		__Params->__Result = base.TryPlayMontage_Implementation(montagePath);
	}

	// Token: 0x0601D6DF RID: 120543 RVA: 0x008CBF43 File Offset: 0x008CA143
	protected override void __CPPCALL_StopMontage_Implementation()
	{
		base.StopMontage_Implementation();
	}
}
