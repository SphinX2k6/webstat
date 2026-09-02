using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033F4 RID: 13300
[UClass("/Game/Aki/TypeScript/Game/Render/AudioVisualization/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/AudioVisualization/AudioVisualizationInstanceBase.AudioVisualizationInstanceBase_C")]
public class AudioVisualizationInstanceBase : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700253A RID: 9530
	// (get) Token: 0x0601B9DD RID: 113117 RVA: 0x0083D6E2 File Offset: 0x0083B8E2
	// (set) Token: 0x0601B9DE RID: 113118 RVA: 0x0083D6F6 File Offset: 0x0083B8F6
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Identifier
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)AudioVisualizationInstanceBase.__PropertyOffset_Identifier)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)AudioVisualizationInstanceBase.__PropertyOffset_Identifier)), value);
		}
	}

	// Token: 0x0601B9DF RID: 113119 RVA: 0x0083D70B File Offset: 0x0083B90B
	public override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		Action<AudioVisualizationInstanceBase> actorEndPlayCallback = this.ActorEndPlayCallback;
		if (actorEndPlayCallback == null)
		{
			return;
		}
		actorEndPlayCallback(this);
	}

	// Token: 0x0601B9E0 RID: 113120 RVA: 0x0083D720 File Offset: 0x0083B920
	public unsafe void Start()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LSY;
		string message = "音频可视化实例开始";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("名称", this);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("标识符", this.Identifier);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.StartInternal();
	}

	// Token: 0x0601B9E1 RID: 113121 RVA: 0x0083D78C File Offset: 0x0083B98C
	public unsafe void End()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LSY;
		string message = "音频可视化实例结束";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("名称", this);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("标识符", this.Identifier);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.EndInternal();
	}

	// Token: 0x0601B9E2 RID: 113122 RVA: 0x0083D7F8 File Offset: 0x0083B9F8
	[NullableContext(1)]
	public void CallBack([Nullable(2)] UAkCallbackInfo callbackInfo, EAkCallbackType callbackType, string state)
	{
		if (callbackInfo is UAkMusicSyncCallbackInfo)
		{
			this.MidiBpm();
		}
		UAkMIDIEventCallbackInfo uakMIDIEventCallbackInfo = callbackInfo as UAkMIDIEventCallbackInfo;
		if (uakMIDIEventCallbackInfo != null)
		{
			EAkMidiEventType type = uakMIDIEventCallbackInfo.GetType();
			if (type != EAkMidiEventType.AkMidiEventTypeNoteOff)
			{
				if (type == EAkMidiEventType.AkMidiEventTypeNoteOn)
				{
					this.TriggerMidiNoteOn(uakMIDIEventCallbackInfo);
				}
			}
			else
			{
				this.TriggerMidiNoteOff(uakMIDIEventCallbackInfo);
			}
		}
		this.CallBackInternal(callbackInfo, callbackType, state);
	}

	// Token: 0x0601B9E3 RID: 113123 RVA: 0x0083D850 File Offset: 0x0083BA50
	[NullableContext(1)]
	private void TriggerMidiNoteOn(UAkMIDIEventCallbackInfo callbackInfo)
	{
		FAkMidiNoteOnOff fakMidiNoteOnOff = null;
		if (!callbackInfo.GetNoteOn(ref fakMidiNoteOnOff) || fakMidiNoteOnOff == null)
		{
			return;
		}
		byte velocity = fakMidiNoteOnOff.Velocity;
		switch (fakMidiNoteOnOff.Note)
		{
		case 60:
			this.MidiC3On(velocity);
			return;
		case 61:
			this.MidiCs3On(velocity);
			return;
		case 62:
			this.MidiD3On(velocity);
			return;
		case 63:
			this.MidiDs3On(velocity);
			return;
		case 64:
			this.MidiE3On(velocity);
			return;
		case 65:
			this.MidiF3On(velocity);
			return;
		case 66:
			this.MidiFs3On(velocity);
			return;
		case 67:
			this.MidiG3On(velocity);
			return;
		case 68:
			this.MidiGs3On(velocity);
			return;
		case 69:
			this.MidiA3On(velocity);
			return;
		case 70:
			this.MidiAs3On(velocity);
			return;
		case 71:
			this.MidiB3On(velocity);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601B9E4 RID: 113124 RVA: 0x0083D91C File Offset: 0x0083BB1C
	[NullableContext(1)]
	private void TriggerMidiNoteOff(UAkMIDIEventCallbackInfo callbackInfo)
	{
		FAkMidiNoteOnOff fakMidiNoteOnOff = null;
		if (!callbackInfo.GetNoteOff(ref fakMidiNoteOnOff) || fakMidiNoteOnOff == null)
		{
			return;
		}
		byte velocity = fakMidiNoteOnOff.Velocity;
		switch (fakMidiNoteOnOff.Note)
		{
		case 60:
			this.MidiC3Off(velocity);
			return;
		case 61:
			this.MidiCs3Off(velocity);
			return;
		case 62:
			this.MidiD3Off(velocity);
			return;
		case 63:
			this.MidiDs3Off(velocity);
			return;
		case 64:
			this.MidiE3Off(velocity);
			return;
		case 65:
			this.MidiF3Off(velocity);
			return;
		case 66:
			this.MidiFs3Off(velocity);
			return;
		case 67:
			this.MidiG3Off(velocity);
			return;
		case 68:
			this.MidiGs3Off(velocity);
			return;
		case 69:
			this.MidiA3Off(velocity);
			return;
		case 70:
			this.MidiAs3Off(velocity);
			return;
		case 71:
			this.MidiB3Off(velocity);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601B9E5 RID: 113125 RVA: 0x0083D9E8 File Offset: 0x0083BBE8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void StartInternal()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartInternal"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B9E6 RID: 113126 RVA: 0x0083DA58 File Offset: 0x0083BC58
	protected void StartInternal_Implementation()
	{
	}

	// Token: 0x0601B9E7 RID: 113127 RVA: 0x0083DA5C File Offset: 0x0083BC5C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void EndInternal()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EndInternal"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B9E8 RID: 113128 RVA: 0x0083DACC File Offset: 0x0083BCCC
	protected void EndInternal_Implementation()
	{
	}

	// Token: 0x0601B9E9 RID: 113129 RVA: 0x0083DAD0 File Offset: 0x0083BCD0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void CallBackInternal([Nullable(2)] UAkCallbackInfo callbackInfo, EAkCallbackType callbackType, string state)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9EA RID: 113130 RVA: 0x0083DB6A File Offset: 0x0083BD6A
	[NullableContext(1)]
	protected void CallBackInternal_Implementation([Nullable(2)] UAkCallbackInfo callbackInfo, EAkCallbackType callbackType, string state)
	{
	}

	// Token: 0x0601B9EB RID: 113131 RVA: 0x0083DB6C File Offset: 0x0083BD6C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiBpm()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("MidiBpm"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601B9EC RID: 113132 RVA: 0x0083DBDC File Offset: 0x0083BDDC
	protected void MidiBpm_Implementation()
	{
	}

	// Token: 0x0601B9ED RID: 113133 RVA: 0x0083DBE0 File Offset: 0x0083BDE0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiC3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9EE RID: 113134 RVA: 0x0083DC56 File Offset: 0x0083BE56
	protected void MidiC3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9EF RID: 113135 RVA: 0x0083DC58 File Offset: 0x0083BE58
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiCs3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9F0 RID: 113136 RVA: 0x0083DCCE File Offset: 0x0083BECE
	protected void MidiCs3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9F1 RID: 113137 RVA: 0x0083DCD0 File Offset: 0x0083BED0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiD3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9F2 RID: 113138 RVA: 0x0083DD46 File Offset: 0x0083BF46
	protected void MidiD3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9F3 RID: 113139 RVA: 0x0083DD48 File Offset: 0x0083BF48
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiDs3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9F4 RID: 113140 RVA: 0x0083DDBE File Offset: 0x0083BFBE
	protected void MidiDs3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9F5 RID: 113141 RVA: 0x0083DDC0 File Offset: 0x0083BFC0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiE3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9F6 RID: 113142 RVA: 0x0083DE36 File Offset: 0x0083C036
	protected void MidiE3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9F7 RID: 113143 RVA: 0x0083DE38 File Offset: 0x0083C038
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiF3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9F8 RID: 113144 RVA: 0x0083DEAE File Offset: 0x0083C0AE
	protected void MidiF3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9F9 RID: 113145 RVA: 0x0083DEB0 File Offset: 0x0083C0B0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiFs3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9FA RID: 113146 RVA: 0x0083DF26 File Offset: 0x0083C126
	protected void MidiFs3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9FB RID: 113147 RVA: 0x0083DF28 File Offset: 0x0083C128
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiG3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9FC RID: 113148 RVA: 0x0083DF9E File Offset: 0x0083C19E
	protected void MidiG3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9FD RID: 113149 RVA: 0x0083DFA0 File Offset: 0x0083C1A0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiGs3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B9FE RID: 113150 RVA: 0x0083E016 File Offset: 0x0083C216
	protected void MidiGs3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601B9FF RID: 113151 RVA: 0x0083E018 File Offset: 0x0083C218
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiA3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA00 RID: 113152 RVA: 0x0083E08E File Offset: 0x0083C28E
	protected void MidiA3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA01 RID: 113153 RVA: 0x0083E090 File Offset: 0x0083C290
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiAs3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA02 RID: 113154 RVA: 0x0083E106 File Offset: 0x0083C306
	protected void MidiAs3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA03 RID: 113155 RVA: 0x0083E108 File Offset: 0x0083C308
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiB3On(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA04 RID: 113156 RVA: 0x0083E17E File Offset: 0x0083C37E
	protected void MidiB3On_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA05 RID: 113157 RVA: 0x0083E180 File Offset: 0x0083C380
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiC3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA06 RID: 113158 RVA: 0x0083E1F6 File Offset: 0x0083C3F6
	protected void MidiC3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA07 RID: 113159 RVA: 0x0083E1F8 File Offset: 0x0083C3F8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiCs3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA08 RID: 113160 RVA: 0x0083E26E File Offset: 0x0083C46E
	protected void MidiCs3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA09 RID: 113161 RVA: 0x0083E270 File Offset: 0x0083C470
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiD3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA0A RID: 113162 RVA: 0x0083E2E6 File Offset: 0x0083C4E6
	protected void MidiD3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA0B RID: 113163 RVA: 0x0083E2E8 File Offset: 0x0083C4E8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiDs3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA0C RID: 113164 RVA: 0x0083E35E File Offset: 0x0083C55E
	protected void MidiDs3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA0D RID: 113165 RVA: 0x0083E360 File Offset: 0x0083C560
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiE3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA0E RID: 113166 RVA: 0x0083E3D6 File Offset: 0x0083C5D6
	protected void MidiE3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA0F RID: 113167 RVA: 0x0083E3D8 File Offset: 0x0083C5D8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiF3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA10 RID: 113168 RVA: 0x0083E44E File Offset: 0x0083C64E
	protected void MidiF3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA11 RID: 113169 RVA: 0x0083E450 File Offset: 0x0083C650
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiFs3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA12 RID: 113170 RVA: 0x0083E4C6 File Offset: 0x0083C6C6
	protected void MidiFs3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA13 RID: 113171 RVA: 0x0083E4C8 File Offset: 0x0083C6C8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiG3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA14 RID: 113172 RVA: 0x0083E53E File Offset: 0x0083C73E
	protected void MidiG3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA15 RID: 113173 RVA: 0x0083E540 File Offset: 0x0083C740
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiGs3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA16 RID: 113174 RVA: 0x0083E5B6 File Offset: 0x0083C7B6
	protected void MidiGs3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA17 RID: 113175 RVA: 0x0083E5B8 File Offset: 0x0083C7B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiA3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA18 RID: 113176 RVA: 0x0083E62E File Offset: 0x0083C82E
	protected void MidiA3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA19 RID: 113177 RVA: 0x0083E630 File Offset: 0x0083C830
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiAs3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA1A RID: 113178 RVA: 0x0083E6A6 File Offset: 0x0083C8A6
	protected void MidiAs3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA1B RID: 113179 RVA: 0x0083E6A8 File Offset: 0x0083C8A8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void MidiB3Off(byte velocity)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA1C RID: 113180 RVA: 0x0083E71E File Offset: 0x0083C91E
	protected void MidiB3Off_Implementation(byte velocity)
	{
	}

	// Token: 0x0601BA1D RID: 113181 RVA: 0x0083E720 File Offset: 0x0083C920
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AudioVisualizationInstanceBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/AudioVisualization/AudioVisualizationInstanceBase.AudioVisualizationInstanceBase_C");
		}
		return AudioVisualizationInstanceBase._ClassPtr;
	}

	// Token: 0x0601BA1E RID: 113182 RVA: 0x0083E744 File Offset: 0x0083C944
	public AudioVisualizationInstanceBase() : this(BuiltinUtils.AllocNativeUObject(AudioVisualizationInstanceBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BA1F RID: 113183 RVA: 0x0083E76C File Offset: 0x0083C96C
	[NullableContext(1)]
	public AudioVisualizationInstanceBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AudioVisualizationInstanceBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BA20 RID: 113184 RVA: 0x0083E79F File Offset: 0x0083C99F
	protected AudioVisualizationInstanceBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x1700253B RID: 9531
	// (get) Token: 0x0601BA21 RID: 113185 RVA: 0x0083E7A8 File Offset: 0x0083C9A8
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)AudioVisualizationInstanceBase.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x1700253C RID: 9532
	// (get) Token: 0x0601BA22 RID: 113186 RVA: 0x0083E7B8 File Offset: 0x0083C9B8
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + AudioVisualizationInstanceBase.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601BA23 RID: 113187 RVA: 0x0083E7CC File Offset: 0x0083C9CC
	protected virtual void __CPPCALL_StartInternal_Implementation()
	{
		this.StartInternal_Implementation();
	}

	// Token: 0x0601BA24 RID: 113188 RVA: 0x0083E7D4 File Offset: 0x0083C9D4
	protected virtual void __CPPCALL_EndInternal_Implementation()
	{
		this.EndInternal_Implementation();
	}

	// Token: 0x0601BA25 RID: 113189 RVA: 0x0083E7DC File Offset: 0x0083C9DC
	protected unsafe virtual void __CPPCALL_CallBackInternal_Implementation(AudioVisualizationInstanceBase.__CallBackInternal_FunctionParams* __Params)
	{
		UAkCallbackInfo orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkCallbackInfo>(__Params->callbackInfo);
		EAkCallbackType callbackType = (EAkCallbackType)__Params->callbackType;
		string state = FString.ToString((void*)(&__Params->state));
		this.CallBackInternal_Implementation(orCreateUObjectByNativePointer, callbackType, state);
	}

	// Token: 0x0601BA26 RID: 113190 RVA: 0x0083E812 File Offset: 0x0083CA12
	protected virtual void __CPPCALL_MidiBpm_Implementation()
	{
		this.MidiBpm_Implementation();
	}

	// Token: 0x0601BA27 RID: 113191 RVA: 0x0083E81A File Offset: 0x0083CA1A
	protected unsafe virtual void __CPPCALL_MidiC3On_Implementation(AudioVisualizationInstanceBase.__MidiC3On_FunctionParams* __Params)
	{
		this.MidiC3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA28 RID: 113192 RVA: 0x0083E828 File Offset: 0x0083CA28
	protected unsafe virtual void __CPPCALL_MidiCs3On_Implementation(AudioVisualizationInstanceBase.__MidiCs3On_FunctionParams* __Params)
	{
		this.MidiCs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA29 RID: 113193 RVA: 0x0083E836 File Offset: 0x0083CA36
	protected unsafe virtual void __CPPCALL_MidiD3On_Implementation(AudioVisualizationInstanceBase.__MidiD3On_FunctionParams* __Params)
	{
		this.MidiD3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2A RID: 113194 RVA: 0x0083E844 File Offset: 0x0083CA44
	protected unsafe virtual void __CPPCALL_MidiDs3On_Implementation(AudioVisualizationInstanceBase.__MidiDs3On_FunctionParams* __Params)
	{
		this.MidiDs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2B RID: 113195 RVA: 0x0083E852 File Offset: 0x0083CA52
	protected unsafe virtual void __CPPCALL_MidiE3On_Implementation(AudioVisualizationInstanceBase.__MidiE3On_FunctionParams* __Params)
	{
		this.MidiE3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2C RID: 113196 RVA: 0x0083E860 File Offset: 0x0083CA60
	protected unsafe virtual void __CPPCALL_MidiF3On_Implementation(AudioVisualizationInstanceBase.__MidiF3On_FunctionParams* __Params)
	{
		this.MidiF3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2D RID: 113197 RVA: 0x0083E86E File Offset: 0x0083CA6E
	protected unsafe virtual void __CPPCALL_MidiFs3On_Implementation(AudioVisualizationInstanceBase.__MidiFs3On_FunctionParams* __Params)
	{
		this.MidiFs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2E RID: 113198 RVA: 0x0083E87C File Offset: 0x0083CA7C
	protected unsafe virtual void __CPPCALL_MidiG3On_Implementation(AudioVisualizationInstanceBase.__MidiG3On_FunctionParams* __Params)
	{
		this.MidiG3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA2F RID: 113199 RVA: 0x0083E88A File Offset: 0x0083CA8A
	protected unsafe virtual void __CPPCALL_MidiGs3On_Implementation(AudioVisualizationInstanceBase.__MidiGs3On_FunctionParams* __Params)
	{
		this.MidiGs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA30 RID: 113200 RVA: 0x0083E898 File Offset: 0x0083CA98
	protected unsafe virtual void __CPPCALL_MidiA3On_Implementation(AudioVisualizationInstanceBase.__MidiA3On_FunctionParams* __Params)
	{
		this.MidiA3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA31 RID: 113201 RVA: 0x0083E8A6 File Offset: 0x0083CAA6
	protected unsafe virtual void __CPPCALL_MidiAs3On_Implementation(AudioVisualizationInstanceBase.__MidiAs3On_FunctionParams* __Params)
	{
		this.MidiAs3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA32 RID: 113202 RVA: 0x0083E8B4 File Offset: 0x0083CAB4
	protected unsafe virtual void __CPPCALL_MidiB3On_Implementation(AudioVisualizationInstanceBase.__MidiB3On_FunctionParams* __Params)
	{
		this.MidiB3On_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA33 RID: 113203 RVA: 0x0083E8C2 File Offset: 0x0083CAC2
	protected unsafe virtual void __CPPCALL_MidiC3Off_Implementation(AudioVisualizationInstanceBase.__MidiC3Off_FunctionParams* __Params)
	{
		this.MidiC3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA34 RID: 113204 RVA: 0x0083E8D0 File Offset: 0x0083CAD0
	protected unsafe virtual void __CPPCALL_MidiCs3Off_Implementation(AudioVisualizationInstanceBase.__MidiCs3Off_FunctionParams* __Params)
	{
		this.MidiCs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA35 RID: 113205 RVA: 0x0083E8DE File Offset: 0x0083CADE
	protected unsafe virtual void __CPPCALL_MidiD3Off_Implementation(AudioVisualizationInstanceBase.__MidiD3Off_FunctionParams* __Params)
	{
		this.MidiD3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA36 RID: 113206 RVA: 0x0083E8EC File Offset: 0x0083CAEC
	protected unsafe virtual void __CPPCALL_MidiDs3Off_Implementation(AudioVisualizationInstanceBase.__MidiDs3Off_FunctionParams* __Params)
	{
		this.MidiDs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA37 RID: 113207 RVA: 0x0083E8FA File Offset: 0x0083CAFA
	protected unsafe virtual void __CPPCALL_MidiE3Off_Implementation(AudioVisualizationInstanceBase.__MidiE3Off_FunctionParams* __Params)
	{
		this.MidiE3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA38 RID: 113208 RVA: 0x0083E908 File Offset: 0x0083CB08
	protected unsafe virtual void __CPPCALL_MidiF3Off_Implementation(AudioVisualizationInstanceBase.__MidiF3Off_FunctionParams* __Params)
	{
		this.MidiF3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA39 RID: 113209 RVA: 0x0083E916 File Offset: 0x0083CB16
	protected unsafe virtual void __CPPCALL_MidiFs3Off_Implementation(AudioVisualizationInstanceBase.__MidiFs3Off_FunctionParams* __Params)
	{
		this.MidiFs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA3A RID: 113210 RVA: 0x0083E924 File Offset: 0x0083CB24
	protected unsafe virtual void __CPPCALL_MidiG3Off_Implementation(AudioVisualizationInstanceBase.__MidiG3Off_FunctionParams* __Params)
	{
		this.MidiG3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA3B RID: 113211 RVA: 0x0083E932 File Offset: 0x0083CB32
	protected unsafe virtual void __CPPCALL_MidiGs3Off_Implementation(AudioVisualizationInstanceBase.__MidiGs3Off_FunctionParams* __Params)
	{
		this.MidiGs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA3C RID: 113212 RVA: 0x0083E940 File Offset: 0x0083CB40
	protected unsafe virtual void __CPPCALL_MidiA3Off_Implementation(AudioVisualizationInstanceBase.__MidiA3Off_FunctionParams* __Params)
	{
		this.MidiA3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA3D RID: 113213 RVA: 0x0083E94E File Offset: 0x0083CB4E
	protected unsafe virtual void __CPPCALL_MidiAs3Off_Implementation(AudioVisualizationInstanceBase.__MidiAs3Off_FunctionParams* __Params)
	{
		this.MidiAs3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0601BA3E RID: 113214 RVA: 0x0083E95C File Offset: 0x0083CB5C
	protected unsafe virtual void __CPPCALL_MidiB3Off_Implementation(AudioVisualizationInstanceBase.__MidiB3Off_FunctionParams* __Params)
	{
		this.MidiB3Off_Implementation(__Params->velocity);
	}

	// Token: 0x0400DF92 RID: 57234
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<AudioVisualizationInstanceBase> ActorEndPlayCallback;

	// Token: 0x0400DF93 RID: 57235
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/AudioVisualization/AudioVisualizationInstanceBase.AudioVisualizationInstanceBase_C";

	// Token: 0x0400DF94 RID: 57236
	private static IntPtr _ClassPtr;

	// Token: 0x0400DF95 RID: 57237
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DF96 RID: 57238
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400DF97 RID: 57239
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400DF98 RID: 57240
	private static int __PropertyOffset_Identifier;

	// Token: 0x02009480 RID: 38016
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __CallBackInternal_FunctionParams
	{
		// Token: 0x0403142D RID: 201773
		[FieldOffset(0)]
		public IntPtr callbackInfo;

		// Token: 0x0403142E RID: 201774
		[FieldOffset(8)]
		public byte callbackType;

		// Token: 0x0403142F RID: 201775
		[FieldOffset(16)]
		public FString state;
	}

	// Token: 0x02009481 RID: 38017
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiC3On_FunctionParams
	{
		// Token: 0x04031430 RID: 201776
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009482 RID: 38018
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiCs3On_FunctionParams
	{
		// Token: 0x04031431 RID: 201777
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009483 RID: 38019
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiD3On_FunctionParams
	{
		// Token: 0x04031432 RID: 201778
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009484 RID: 38020
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiDs3On_FunctionParams
	{
		// Token: 0x04031433 RID: 201779
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009485 RID: 38021
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiE3On_FunctionParams
	{
		// Token: 0x04031434 RID: 201780
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009486 RID: 38022
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiF3On_FunctionParams
	{
		// Token: 0x04031435 RID: 201781
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009487 RID: 38023
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiFs3On_FunctionParams
	{
		// Token: 0x04031436 RID: 201782
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009488 RID: 38024
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiG3On_FunctionParams
	{
		// Token: 0x04031437 RID: 201783
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009489 RID: 38025
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiGs3On_FunctionParams
	{
		// Token: 0x04031438 RID: 201784
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948A RID: 38026
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiA3On_FunctionParams
	{
		// Token: 0x04031439 RID: 201785
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948B RID: 38027
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiAs3On_FunctionParams
	{
		// Token: 0x0403143A RID: 201786
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948C RID: 38028
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiB3On_FunctionParams
	{
		// Token: 0x0403143B RID: 201787
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948D RID: 38029
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiC3Off_FunctionParams
	{
		// Token: 0x0403143C RID: 201788
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948E RID: 38030
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiCs3Off_FunctionParams
	{
		// Token: 0x0403143D RID: 201789
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x0200948F RID: 38031
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiD3Off_FunctionParams
	{
		// Token: 0x0403143E RID: 201790
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009490 RID: 38032
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiDs3Off_FunctionParams
	{
		// Token: 0x0403143F RID: 201791
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009491 RID: 38033
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiE3Off_FunctionParams
	{
		// Token: 0x04031440 RID: 201792
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009492 RID: 38034
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiF3Off_FunctionParams
	{
		// Token: 0x04031441 RID: 201793
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009493 RID: 38035
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiFs3Off_FunctionParams
	{
		// Token: 0x04031442 RID: 201794
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009494 RID: 38036
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiG3Off_FunctionParams
	{
		// Token: 0x04031443 RID: 201795
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009495 RID: 38037
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiGs3Off_FunctionParams
	{
		// Token: 0x04031444 RID: 201796
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009496 RID: 38038
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiA3Off_FunctionParams
	{
		// Token: 0x04031445 RID: 201797
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009497 RID: 38039
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiAs3Off_FunctionParams
	{
		// Token: 0x04031446 RID: 201798
		[FieldOffset(0)]
		public byte velocity;
	}

	// Token: 0x02009498 RID: 38040
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __MidiB3Off_FunctionParams
	{
		// Token: 0x04031447 RID: 201799
		[FieldOffset(0)]
		public byte velocity;
	}
}
