using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003903 RID: 14595
public class __AudioVisualizationInstanceBase_InheritProxy : AudioVisualizationInstanceBase
{
	// Token: 0x0601D792 RID: 120722 RVA: 0x008CE13C File Offset: 0x008CC33C
	[NullableContext(1)]
	public __AudioVisualizationInstanceBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AudioVisualizationInstanceBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D793 RID: 120723 RVA: 0x008CE16F File Offset: 0x008CC36F
	protected __AudioVisualizationInstanceBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D794 RID: 120724 RVA: 0x008CE178 File Offset: 0x008CC378
	protected override void __CPPCALL_StartInternal_Implementation()
	{
		base.StartInternal_Implementation();
	}

	// Token: 0x0601D795 RID: 120725 RVA: 0x008CE180 File Offset: 0x008CC380
	protected override void __CPPCALL_EndInternal_Implementation()
	{
		base.EndInternal_Implementation();
	}

	// Token: 0x0601D796 RID: 120726 RVA: 0x008CE188 File Offset: 0x008CC388
	protected unsafe override void __CPPCALL_CallBackInternal_Implementation(AudioVisualizationInstanceBase.__CallBackInternal_FunctionParams* __Params)
	{
		UAkCallbackInfo orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkCallbackInfo>(__Params->callbackInfo);
		EAkCallbackType callbackType = (EAkCallbackType)__Params->callbackType;
		string state = FString.ToString((void*)(&__Params->state));
		base.CallBackInternal_Implementation(orCreateUObjectByNativePointer, callbackType, state);
	}

	// Token: 0x0601D797 RID: 120727 RVA: 0x008CE1BE File Offset: 0x008CC3BE
	protected override void __CPPCALL_MidiBpm_Implementation()
	{
		base.MidiBpm_Implementation();
	}

	// Token: 0x0601D798 RID: 120728 RVA: 0x008CE1C6 File Offset: 0x008CC3C6
	protected unsafe override void __CPPCALL_MidiC3On_Implementation(AudioVisualizationInstanceBase.__MidiC3On_FunctionParams* __Params)
	{
		base.MidiC3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D799 RID: 120729 RVA: 0x008CE1D4 File Offset: 0x008CC3D4
	protected unsafe override void __CPPCALL_MidiCs3On_Implementation(AudioVisualizationInstanceBase.__MidiCs3On_FunctionParams* __Params)
	{
		base.MidiCs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79A RID: 120730 RVA: 0x008CE1E2 File Offset: 0x008CC3E2
	protected unsafe override void __CPPCALL_MidiD3On_Implementation(AudioVisualizationInstanceBase.__MidiD3On_FunctionParams* __Params)
	{
		base.MidiD3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79B RID: 120731 RVA: 0x008CE1F0 File Offset: 0x008CC3F0
	protected unsafe override void __CPPCALL_MidiDs3On_Implementation(AudioVisualizationInstanceBase.__MidiDs3On_FunctionParams* __Params)
	{
		base.MidiDs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79C RID: 120732 RVA: 0x008CE1FE File Offset: 0x008CC3FE
	protected unsafe override void __CPPCALL_MidiE3On_Implementation(AudioVisualizationInstanceBase.__MidiE3On_FunctionParams* __Params)
	{
		base.MidiE3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79D RID: 120733 RVA: 0x008CE20C File Offset: 0x008CC40C
	protected unsafe override void __CPPCALL_MidiF3On_Implementation(AudioVisualizationInstanceBase.__MidiF3On_FunctionParams* __Params)
	{
		base.MidiF3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79E RID: 120734 RVA: 0x008CE21A File Offset: 0x008CC41A
	protected unsafe override void __CPPCALL_MidiFs3On_Implementation(AudioVisualizationInstanceBase.__MidiFs3On_FunctionParams* __Params)
	{
		base.MidiFs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D79F RID: 120735 RVA: 0x008CE228 File Offset: 0x008CC428
	protected unsafe override void __CPPCALL_MidiG3On_Implementation(AudioVisualizationInstanceBase.__MidiG3On_FunctionParams* __Params)
	{
		base.MidiG3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A0 RID: 120736 RVA: 0x008CE236 File Offset: 0x008CC436
	protected unsafe override void __CPPCALL_MidiGs3On_Implementation(AudioVisualizationInstanceBase.__MidiGs3On_FunctionParams* __Params)
	{
		base.MidiGs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A1 RID: 120737 RVA: 0x008CE244 File Offset: 0x008CC444
	protected unsafe override void __CPPCALL_MidiA3On_Implementation(AudioVisualizationInstanceBase.__MidiA3On_FunctionParams* __Params)
	{
		base.MidiA3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A2 RID: 120738 RVA: 0x008CE252 File Offset: 0x008CC452
	protected unsafe override void __CPPCALL_MidiAs3On_Implementation(AudioVisualizationInstanceBase.__MidiAs3On_FunctionParams* __Params)
	{
		base.MidiAs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A3 RID: 120739 RVA: 0x008CE260 File Offset: 0x008CC460
	protected unsafe override void __CPPCALL_MidiB3On_Implementation(AudioVisualizationInstanceBase.__MidiB3On_FunctionParams* __Params)
	{
		base.MidiB3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A4 RID: 120740 RVA: 0x008CE26E File Offset: 0x008CC46E
	protected unsafe override void __CPPCALL_MidiC3Off_Implementation(AudioVisualizationInstanceBase.__MidiC3Off_FunctionParams* __Params)
	{
		base.MidiC3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A5 RID: 120741 RVA: 0x008CE27C File Offset: 0x008CC47C
	protected unsafe override void __CPPCALL_MidiCs3Off_Implementation(AudioVisualizationInstanceBase.__MidiCs3Off_FunctionParams* __Params)
	{
		base.MidiCs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A6 RID: 120742 RVA: 0x008CE28A File Offset: 0x008CC48A
	protected unsafe override void __CPPCALL_MidiD3Off_Implementation(AudioVisualizationInstanceBase.__MidiD3Off_FunctionParams* __Params)
	{
		base.MidiD3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A7 RID: 120743 RVA: 0x008CE298 File Offset: 0x008CC498
	protected unsafe override void __CPPCALL_MidiDs3Off_Implementation(AudioVisualizationInstanceBase.__MidiDs3Off_FunctionParams* __Params)
	{
		base.MidiDs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A8 RID: 120744 RVA: 0x008CE2A6 File Offset: 0x008CC4A6
	protected unsafe override void __CPPCALL_MidiE3Off_Implementation(AudioVisualizationInstanceBase.__MidiE3Off_FunctionParams* __Params)
	{
		base.MidiE3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7A9 RID: 120745 RVA: 0x008CE2B4 File Offset: 0x008CC4B4
	protected unsafe override void __CPPCALL_MidiF3Off_Implementation(AudioVisualizationInstanceBase.__MidiF3Off_FunctionParams* __Params)
	{
		base.MidiF3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AA RID: 120746 RVA: 0x008CE2C2 File Offset: 0x008CC4C2
	protected unsafe override void __CPPCALL_MidiFs3Off_Implementation(AudioVisualizationInstanceBase.__MidiFs3Off_FunctionParams* __Params)
	{
		base.MidiFs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AB RID: 120747 RVA: 0x008CE2D0 File Offset: 0x008CC4D0
	protected unsafe override void __CPPCALL_MidiG3Off_Implementation(AudioVisualizationInstanceBase.__MidiG3Off_FunctionParams* __Params)
	{
		base.MidiG3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AC RID: 120748 RVA: 0x008CE2DE File Offset: 0x008CC4DE
	protected unsafe override void __CPPCALL_MidiGs3Off_Implementation(AudioVisualizationInstanceBase.__MidiGs3Off_FunctionParams* __Params)
	{
		base.MidiGs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AD RID: 120749 RVA: 0x008CE2EC File Offset: 0x008CC4EC
	protected unsafe override void __CPPCALL_MidiA3Off_Implementation(AudioVisualizationInstanceBase.__MidiA3Off_FunctionParams* __Params)
	{
		base.MidiA3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AE RID: 120750 RVA: 0x008CE2FA File Offset: 0x008CC4FA
	protected unsafe override void __CPPCALL_MidiAs3Off_Implementation(AudioVisualizationInstanceBase.__MidiAs3Off_FunctionParams* __Params)
	{
		base.MidiAs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601D7AF RID: 120751 RVA: 0x008CE308 File Offset: 0x008CC508
	protected unsafe override void __CPPCALL_MidiB3Off_Implementation(AudioVisualizationInstanceBase.__MidiB3Off_FunctionParams* __Params)
	{
		base.MidiB3Off_Implementation(__Params->velocity);
	}
}
