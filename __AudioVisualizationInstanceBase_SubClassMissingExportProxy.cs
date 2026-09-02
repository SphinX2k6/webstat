using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003904 RID: 14596
[NullableContext(1)]
[Nullable(0)]
public class __AudioVisualizationInstanceBase_SubClassMissingExportProxy : __AudioVisualizationInstanceBase_InheritProxy
{
	// Token: 0x0601D7B0 RID: 120752 RVA: 0x008CE318 File Offset: 0x008CC518
	protected __AudioVisualizationInstanceBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AudioVisualizationInstanceBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D7B1 RID: 120753 RVA: 0x008CE34B File Offset: 0x008CC54B
	protected __AudioVisualizationInstanceBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D7B2 RID: 120754 RVA: 0x008CE354 File Offset: 0x008CC554
	public unsafe override void StartInternal()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartInternal"), out num);
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

	// Token: 0x0601D7B3 RID: 120755 RVA: 0x008CE3C4 File Offset: 0x008CC5C4
	public unsafe override void EndInternal()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EndInternal"), out num);
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

	// Token: 0x0601D7B4 RID: 120756 RVA: 0x008CE434 File Offset: 0x008CC634
	public unsafe override void CallBackInternal([Nullable(2)] UAkCallbackInfo callbackInfo, EAkCallbackType callbackType, string state)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CallBackInternal"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__CallBackInternal_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__CallBackInternal_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__CallBackInternal_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->callbackInfo) = ((callbackInfo != null) ? callbackInfo.NativePtr : ((IntPtr)0));
			*(&ptr2->callbackType) = (byte)callbackType;
			FString.CopyFrom((void*)(&ptr2->state), state);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7B5 RID: 120757 RVA: 0x008CE4D0 File Offset: 0x008CC6D0
	public unsafe override void MidiBpm()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiBpm"), out num);
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

	// Token: 0x0601D7B6 RID: 120758 RVA: 0x008CE540 File Offset: 0x008CC740
	public unsafe override void MidiC3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiC3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiC3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiC3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiC3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7B7 RID: 120759 RVA: 0x008CE5B8 File Offset: 0x008CC7B8
	public unsafe override void MidiCs3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiCs3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiCs3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiCs3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiCs3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7B8 RID: 120760 RVA: 0x008CE630 File Offset: 0x008CC830
	public unsafe override void MidiD3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiD3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiD3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiD3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiD3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7B9 RID: 120761 RVA: 0x008CE6A8 File Offset: 0x008CC8A8
	public unsafe override void MidiDs3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiDs3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiDs3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiDs3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiDs3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BA RID: 120762 RVA: 0x008CE720 File Offset: 0x008CC920
	public unsafe override void MidiE3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiE3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiE3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiE3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiE3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BB RID: 120763 RVA: 0x008CE798 File Offset: 0x008CC998
	public unsafe override void MidiF3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiF3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiF3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiF3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiF3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BC RID: 120764 RVA: 0x008CE810 File Offset: 0x008CCA10
	public unsafe override void MidiFs3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiFs3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiFs3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiFs3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiFs3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BD RID: 120765 RVA: 0x008CE888 File Offset: 0x008CCA88
	public unsafe override void MidiG3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiG3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiG3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiG3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiG3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BE RID: 120766 RVA: 0x008CE900 File Offset: 0x008CCB00
	public unsafe override void MidiGs3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiGs3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiGs3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiGs3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiGs3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7BF RID: 120767 RVA: 0x008CE978 File Offset: 0x008CCB78
	public unsafe override void MidiA3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiA3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiA3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiA3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiA3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C0 RID: 120768 RVA: 0x008CE9F0 File Offset: 0x008CCBF0
	public unsafe override void MidiAs3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiAs3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiAs3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiAs3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiAs3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C1 RID: 120769 RVA: 0x008CEA68 File Offset: 0x008CCC68
	public unsafe override void MidiB3On(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiB3On"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiB3On_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiB3On_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiB3On_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C2 RID: 120770 RVA: 0x008CEAE0 File Offset: 0x008CCCE0
	public unsafe override void MidiC3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiC3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiC3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiC3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiC3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C3 RID: 120771 RVA: 0x008CEB58 File Offset: 0x008CCD58
	public unsafe override void MidiCs3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiCs3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiCs3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiCs3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiCs3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C4 RID: 120772 RVA: 0x008CEBD0 File Offset: 0x008CCDD0
	public unsafe override void MidiD3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiD3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiD3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiD3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiD3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C5 RID: 120773 RVA: 0x008CEC48 File Offset: 0x008CCE48
	public unsafe override void MidiDs3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiDs3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiDs3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiDs3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiDs3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C6 RID: 120774 RVA: 0x008CECC0 File Offset: 0x008CCEC0
	public unsafe override void MidiE3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiE3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiE3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiE3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiE3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C7 RID: 120775 RVA: 0x008CED38 File Offset: 0x008CCF38
	public unsafe override void MidiF3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiF3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiF3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiF3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiF3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C8 RID: 120776 RVA: 0x008CEDB0 File Offset: 0x008CCFB0
	public unsafe override void MidiFs3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiFs3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiFs3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiFs3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiFs3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7C9 RID: 120777 RVA: 0x008CEE28 File Offset: 0x008CD028
	public unsafe override void MidiG3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiG3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiG3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiG3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiG3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7CA RID: 120778 RVA: 0x008CEEA0 File Offset: 0x008CD0A0
	public unsafe override void MidiGs3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiGs3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiGs3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiGs3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiGs3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7CB RID: 120779 RVA: 0x008CEF18 File Offset: 0x008CD118
	public unsafe override void MidiA3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiA3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiA3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiA3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiA3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7CC RID: 120780 RVA: 0x008CEF90 File Offset: 0x008CD190
	public unsafe override void MidiAs3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiAs3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiAs3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiAs3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiAs3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D7CD RID: 120781 RVA: 0x008CF008 File Offset: 0x008CD208
	public unsafe override void MidiB3Off(byte velocity)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiB3Off"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AudioVisualizationInstanceBase.__MidiB3Off_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AudioVisualizationInstanceBase.__MidiB3Off_FunctionParams*)ptr + 15L / (long)sizeof(AudioVisualizationInstanceBase.__MidiB3Off_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->velocity = velocity;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
