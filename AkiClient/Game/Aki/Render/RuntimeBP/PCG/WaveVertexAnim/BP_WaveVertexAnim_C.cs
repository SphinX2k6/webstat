using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaveVertexAnim
{
	// Token: 0x02003B4B RID: 15179
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaveVertexAnim/BP_WaveVertexAnim.BP_WaveVertexAnim_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1341)]
	public class BP_WaveVertexAnim_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020ECA RID: 134858 RVA: 0x0093AFE8 File Offset: 0x009391E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaveVertexAnim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaveVertexAnim/BP_WaveVertexAnim.BP_WaveVertexAnim_C");
			}
			return BP_WaveVertexAnim_C._ClassPtr;
		}

		// Token: 0x06020ECB RID: 134859 RVA: 0x0093B00C File Offset: 0x0093920C
		public BP_WaveVertexAnim_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaveVertexAnim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020ECC RID: 134860 RVA: 0x0093B034 File Offset: 0x00939234
		[NullableContext(1)]
		public BP_WaveVertexAnim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaveVertexAnim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003802 RID: 14338
		// (get) Token: 0x06020ECD RID: 134861 RVA: 0x0093B068 File Offset: 0x00939268
		// (set) Token: 0x06020ECE RID: 134862 RVA: 0x0093B0A1 File Offset: 0x009392A1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003803 RID: 14339
		// (get) Token: 0x06020ECF RID: 134863 RVA: 0x0093B0C2 File Offset: 0x009392C2
		// (set) Token: 0x06020ED0 RID: 134864 RVA: 0x0093B0D6 File Offset: 0x009392D6
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaveVertexAnim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaveVertexAnim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003804 RID: 14340
		// (get) Token: 0x06020ED1 RID: 134865 RVA: 0x0093B0EB File Offset: 0x009392EB
		// (set) Token: 0x06020ED2 RID: 134866 RVA: 0x0093B0FF File Offset: 0x009392FF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaveVertexAnim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaveVertexAnim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003805 RID: 14341
		// (get) Token: 0x06020ED3 RID: 134867 RVA: 0x0093B114 File Offset: 0x00939314
		// (set) Token: 0x06020ED4 RID: 134868 RVA: 0x0093B124 File Offset: 0x00939324
		public unsafe float VertexWaveStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003806 RID: 14342
		// (get) Token: 0x06020ED5 RID: 134869 RVA: 0x0093B135 File Offset: 0x00939335
		// (set) Token: 0x06020ED6 RID: 134870 RVA: 0x0093B145 File Offset: 0x00939345
		public unsafe bool OnWavePlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaveVertexAnim_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020ED7 RID: 134871 RVA: 0x0093B156 File Offset: 0x00939356
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaveVertexAnim_C.__SetMPC_NativeFunctionPtr, null);
		}

		// Token: 0x06020ED8 RID: 134872 RVA: 0x0093B16A File Offset: 0x0093936A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaveVertexAnim_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020ED9 RID: 134873 RVA: 0x0093B17E File Offset: 0x0093937E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaveVertexAnim_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020EDA RID: 134874 RVA: 0x0093B194 File Offset: 0x00939394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaveVertexAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaveVertexAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020EDB RID: 134875 RVA: 0x0093B1DC File Offset: 0x009393DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaveVertexAnim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaveVertexAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaveVertexAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020EDC RID: 134876 RVA: 0x0093B224 File Offset: 0x00939424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaveVertexAnim(int EntryPoint)
		{
			BP_WaveVertexAnim_C.__ExecuteUbergraph_BP_WaveVertexAnim_FunctionParams* ptr = stackalloc BP_WaveVertexAnim_C.__ExecuteUbergraph_BP_WaveVertexAnim_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_WaveVertexAnim_C.__ExecuteUbergraph_BP_WaveVertexAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaveVertexAnim_C.__ExecuteUbergraph_BP_WaveVertexAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaveVertexAnim_C.__ExecuteUbergraph_BP_WaveVertexAnim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020EDD RID: 134877 RVA: 0x0093B26B File Offset: 0x0093946B
		protected BP_WaveVertexAnim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401086A RID: 67690
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaveVertexAnim/BP_WaveVertexAnim.BP_WaveVertexAnim_C";

		// Token: 0x0401086B RID: 67691
		private static IntPtr _ClassPtr;

		// Token: 0x0401086C RID: 67692
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401086D RID: 67693
		internal static int __PropertyOffset_0;

		// Token: 0x0401086E RID: 67694
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401086F RID: 67695
		internal static int __PropertyOffset_1;

		// Token: 0x04010870 RID: 67696
		internal static int __PropertyOffset_2;

		// Token: 0x04010871 RID: 67697
		internal static int __PropertyOffset_3;

		// Token: 0x04010872 RID: 67698
		internal static int __PropertyOffset_4;

		// Token: 0x04010873 RID: 67699
		private static IntPtr __SetMPC_NativeFunctionPtr;

		// Token: 0x04010874 RID: 67700
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010875 RID: 67701
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010876 RID: 67702
		private static IntPtr __ExecuteUbergraph_BP_WaveVertexAnim_NativeFunctionPtr;

		// Token: 0x02009A4F RID: 39503
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032150 RID: 205136
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A50 RID: 39504
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_WaveVertexAnim_FunctionParams
		{
			// Token: 0x04032151 RID: 205137
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
