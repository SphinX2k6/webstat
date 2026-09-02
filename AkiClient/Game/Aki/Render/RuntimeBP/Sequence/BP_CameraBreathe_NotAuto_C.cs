using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A57 RID: 14935
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe_NotAuto.BP_CameraBreathe_NotAuto_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1388)]
	public class BP_CameraBreathe_NotAuto_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F05C RID: 127068 RVA: 0x0090525C File Offset: 0x0090345C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraBreathe_NotAuto_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe_NotAuto.BP_CameraBreathe_NotAuto_C");
			}
			return BP_CameraBreathe_NotAuto_C._ClassPtr;
		}

		// Token: 0x0601F05D RID: 127069 RVA: 0x00905280 File Offset: 0x00903480
		public BP_CameraBreathe_NotAuto_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraBreathe_NotAuto_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F05E RID: 127070 RVA: 0x009052A8 File Offset: 0x009034A8
		[NullableContext(1)]
		public BP_CameraBreathe_NotAuto_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraBreathe_NotAuto_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DB6 RID: 11702
		// (get) Token: 0x0601F05F RID: 127071 RVA: 0x009052DC File Offset: 0x009034DC
		// (set) Token: 0x0601F060 RID: 127072 RVA: 0x00905315 File Offset: 0x00903515
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DB7 RID: 11703
		// (get) Token: 0x0601F061 RID: 127073 RVA: 0x00905336 File Offset: 0x00903536
		// (set) Token: 0x0601F062 RID: 127074 RVA: 0x0090534A File Offset: 0x0090354A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DB8 RID: 11704
		// (get) Token: 0x0601F063 RID: 127075 RVA: 0x0090535F File Offset: 0x0090355F
		// (set) Token: 0x0601F064 RID: 127076 RVA: 0x00905373 File Offset: 0x00903573
		public unsafe ACameraActor Camera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002DB9 RID: 11705
		// (get) Token: 0x0601F065 RID: 127077 RVA: 0x00905388 File Offset: 0x00903588
		// (set) Token: 0x0601F066 RID: 127078 RVA: 0x0090539C File Offset: 0x0090359C
		public unsafe AActor CameraAttachActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_NotAuto_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002DBA RID: 11706
		// (get) Token: 0x0601F067 RID: 127079 RVA: 0x009053B1 File Offset: 0x009035B1
		// (set) Token: 0x0601F068 RID: 127080 RVA: 0x009053C5 File Offset: 0x009035C5
		public unsafe FVectorDouble CameraMoveTransform_D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002DBB RID: 11707
		// (get) Token: 0x0601F069 RID: 127081 RVA: 0x009053DA File Offset: 0x009035DA
		// (set) Token: 0x0601F06A RID: 127082 RVA: 0x009053EA File Offset: 0x009035EA
		public unsafe float PositionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002DBC RID: 11708
		// (get) Token: 0x0601F06B RID: 127083 RVA: 0x009053FB File Offset: 0x009035FB
		// (set) Token: 0x0601F06C RID: 127084 RVA: 0x0090540B File Offset: 0x0090360B
		public unsafe float FOVIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002DBD RID: 11709
		// (get) Token: 0x0601F06D RID: 127085 RVA: 0x0090541C File Offset: 0x0090361C
		// (set) Token: 0x0601F06E RID: 127086 RVA: 0x00905430 File Offset: 0x00903630
		public unsafe FVector SequenceCenterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_NotAuto_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0601F06F RID: 127087 RVA: 0x00905445 File Offset: 0x00903645
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F070 RID: 127088 RVA: 0x00905459 File Offset: 0x00903659
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F071 RID: 127089 RVA: 0x0090546D File Offset: 0x0090366D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F072 RID: 127090 RVA: 0x00905484 File Offset: 0x00903684
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_NotAuto_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F073 RID: 127091 RVA: 0x009054CC File Offset: 0x009036CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_NotAuto_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_NotAuto_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F074 RID: 127092 RVA: 0x00905514 File Offset: 0x00903714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_NotAuto_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F075 RID: 127093 RVA: 0x0090555C File Offset: 0x0090375C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_NotAuto_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_NotAuto_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F076 RID: 127094 RVA: 0x009055A3 File Offset: 0x009037A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F077 RID: 127095 RVA: 0x009055B7 File Offset: 0x009037B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F078 RID: 127096 RVA: 0x009055CC File Offset: 0x009037CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CameraBreathe_NotAuto(int EntryPoint)
		{
			BP_CameraBreathe_NotAuto_C.__ExecuteUbergraph_BP_CameraBreathe_NotAuto_FunctionParams* ptr = stackalloc BP_CameraBreathe_NotAuto_C.__ExecuteUbergraph_BP_CameraBreathe_NotAuto_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CameraBreathe_NotAuto_C.__ExecuteUbergraph_BP_CameraBreathe_NotAuto_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_NotAuto_C.__ExecuteUbergraph_BP_CameraBreathe_NotAuto_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_NotAuto_C.__ExecuteUbergraph_BP_CameraBreathe_NotAuto_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F079 RID: 127097 RVA: 0x00905613 File Offset: 0x00903813
		protected BP_CameraBreathe_NotAuto_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F592 RID: 62866
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe_NotAuto.BP_CameraBreathe_NotAuto_C";

		// Token: 0x0400F593 RID: 62867
		private static IntPtr _ClassPtr;

		// Token: 0x0400F594 RID: 62868
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F595 RID: 62869
		internal static int __PropertyOffset_0;

		// Token: 0x0400F596 RID: 62870
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F597 RID: 62871
		internal static int __PropertyOffset_1;

		// Token: 0x0400F598 RID: 62872
		internal static int __PropertyOffset_2;

		// Token: 0x0400F599 RID: 62873
		internal static int __PropertyOffset_3;

		// Token: 0x0400F59A RID: 62874
		internal static int __PropertyOffset_4;

		// Token: 0x0400F59B RID: 62875
		internal static int __PropertyOffset_5;

		// Token: 0x0400F59C RID: 62876
		internal static int __PropertyOffset_6;

		// Token: 0x0400F59D RID: 62877
		internal static int __PropertyOffset_7;

		// Token: 0x0400F59E RID: 62878
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F59F RID: 62879
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F5A0 RID: 62880
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F5A1 RID: 62881
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F5A2 RID: 62882
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F5A3 RID: 62883
		private static IntPtr __ExecuteUbergraph_BP_CameraBreathe_NotAuto_NativeFunctionPtr;

		// Token: 0x02009840 RID: 38976
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E73 RID: 204403
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009841 RID: 38977
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E74 RID: 204404
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009842 RID: 38978
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_CameraBreathe_NotAuto_FunctionParams
		{
			// Token: 0x04031E75 RID: 204405
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
