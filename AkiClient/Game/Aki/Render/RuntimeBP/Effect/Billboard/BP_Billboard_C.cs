using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Billboard
{
	// Token: 0x02003D4B RID: 15691
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Billboard/BP_Billboard.BP_Billboard_C")]
	[UnrealStructLayout(232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 228)]
	public class BP_Billboard_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026183 RID: 156035 RVA: 0x009CDBB8 File Offset: 0x009CBDB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Billboard_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Billboard/BP_Billboard.BP_Billboard_C");
			}
			return BP_Billboard_C._ClassPtr;
		}

		// Token: 0x06026184 RID: 156036 RVA: 0x009CDBDC File Offset: 0x009CBDDC
		public BP_Billboard_C() : this(BuiltinUtils.AllocNativeUObject(BP_Billboard_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026185 RID: 156037 RVA: 0x009CDC04 File Offset: 0x009CBE04
		[NullableContext(1)]
		public BP_Billboard_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Billboard_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005573 RID: 21875
		// (get) Token: 0x06026186 RID: 156038 RVA: 0x009CDC38 File Offset: 0x009CBE38
		// (set) Token: 0x06026187 RID: 156039 RVA: 0x009CDC71 File Offset: 0x009CBE71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005574 RID: 21876
		// (get) Token: 0x06026188 RID: 156040 RVA: 0x009CDC92 File Offset: 0x009CBE92
		// (set) Token: 0x06026189 RID: 156041 RVA: 0x009CDCA6 File Offset: 0x009CBEA6
		public unsafe TEnumAsByte<E_BillboardMode> 广告版轴向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005575 RID: 21877
		// (get) Token: 0x0602618A RID: 156042 RVA: 0x009CDCBB File Offset: 0x009CBEBB
		// (set) Token: 0x0602618B RID: 156043 RVA: 0x009CDCCB File Offset: 0x009CBECB
		public unsafe bool 每帧更新
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005576 RID: 21878
		// (get) Token: 0x0602618C RID: 156044 RVA: 0x009CDCDC File Offset: 0x009CBEDC
		// (set) Token: 0x0602618D RID: 156045 RVA: 0x009CDCEC File Offset: 0x009CBEEC
		public unsafe bool 固定大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005577 RID: 21879
		// (get) Token: 0x0602618E RID: 156046 RVA: 0x009CDCFD File Offset: 0x009CBEFD
		// (set) Token: 0x0602618F RID: 156047 RVA: 0x009CDD0D File Offset: 0x009CBF0D
		public unsafe float 缩放尺寸
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005578 RID: 21880
		// (get) Token: 0x06026190 RID: 156048 RVA: 0x009CDD1E File Offset: 0x009CBF1E
		// (set) Token: 0x06026191 RID: 156049 RVA: 0x009CDD2E File Offset: 0x009CBF2E
		public unsafe float 最大距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Billboard_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06026192 RID: 156050 RVA: 0x009CDD40 File Offset: 0x009CBF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateScaleSize(float Scale, FVectorDouble CameraLocation, ref FVector NewParam)
		{
			BP_Billboard_C.__CalculateScaleSize_FunctionParams* ptr = stackalloc BP_Billboard_C.__CalculateScaleSize_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_Billboard_C.__CalculateScaleSize_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__CalculateScaleSize_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Scale = Scale;
			ptr->CameraLocation = CameraLocation;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__CalculateScaleSize_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06026193 RID: 156051 RVA: 0x009CDDA8 File Offset: 0x009CBFA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetActorScaleSize(FVector Scale, bool bRelativeScale)
		{
			BP_Billboard_C.__SetActorScaleSize_FunctionParams* ptr = stackalloc BP_Billboard_C.__SetActorScaleSize_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Billboard_C.__SetActorScaleSize_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__SetActorScaleSize_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Scale = Scale;
			ptr->bRelativeScale = bRelativeScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__SetActorScaleSize_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026194 RID: 156052 RVA: 0x009CDDF8 File Offset: 0x009CBFF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetActorRotation(FRotator Rotation)
		{
			BP_Billboard_C.__SetActorRotation_FunctionParams* ptr = stackalloc BP_Billboard_C.__SetActorRotation_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Billboard_C.__SetActorRotation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__SetActorRotation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Rotation = Rotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__SetActorRotation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026195 RID: 156053 RVA: 0x009CDE40 File Offset: 0x009CC040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateRotation(FVectorDouble CameraPosition, ref FRotator Rotation)
		{
			BP_Billboard_C.__CalculateRotation_FunctionParams* ptr = stackalloc BP_Billboard_C.__CalculateRotation_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_Billboard_C.__CalculateRotation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__CalculateRotation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraPosition = CameraPosition;
			ptr->Rotation = Rotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__CalculateRotation_NativeFunctionPtr, (void*)ptr);
			Rotation = ptr->Rotation;
		}

		// Token: 0x06026196 RID: 156054 RVA: 0x009CDEA1 File Offset: 0x009CC0A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026197 RID: 156055 RVA: 0x009CDEB5 File Offset: 0x009CC0B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Billboard_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026198 RID: 156056 RVA: 0x009CDECC File Offset: 0x009CC0CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Billboard_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Billboard_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Billboard_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026199 RID: 156057 RVA: 0x009CDF14 File Offset: 0x009CC114
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Billboard_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Billboard_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Billboard_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Billboard_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602619A RID: 156058 RVA: 0x009CDF5B File Offset: 0x009CC15B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Run()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Billboard_C.__Run_NativeFunctionPtr, null);
		}

		// Token: 0x0602619B RID: 156059 RVA: 0x009CDF70 File Offset: 0x009CC170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Billboard(int EntryPoint)
		{
			BP_Billboard_C.__ExecuteUbergraph_BP_Billboard_FunctionParams* ptr = stackalloc BP_Billboard_C.__ExecuteUbergraph_BP_Billboard_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_Billboard_C.__ExecuteUbergraph_BP_Billboard_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Billboard_C.__ExecuteUbergraph_BP_Billboard_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Billboard_C.__ExecuteUbergraph_BP_Billboard_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602619C RID: 156060 RVA: 0x009CDFB7 File Offset: 0x009CC1B7
		protected BP_Billboard_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B9D RID: 80797
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Billboard/BP_Billboard.BP_Billboard_C";

		// Token: 0x04013B9E RID: 80798
		private static IntPtr _ClassPtr;

		// Token: 0x04013B9F RID: 80799
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013BA0 RID: 80800
		internal static int __PropertyOffset_0;

		// Token: 0x04013BA1 RID: 80801
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013BA2 RID: 80802
		internal static int __PropertyOffset_1;

		// Token: 0x04013BA3 RID: 80803
		internal static int __PropertyOffset_2;

		// Token: 0x04013BA4 RID: 80804
		internal static int __PropertyOffset_3;

		// Token: 0x04013BA5 RID: 80805
		internal static int __PropertyOffset_4;

		// Token: 0x04013BA6 RID: 80806
		internal static int __PropertyOffset_5;

		// Token: 0x04013BA7 RID: 80807
		private static IntPtr __CalculateScaleSize_NativeFunctionPtr;

		// Token: 0x04013BA8 RID: 80808
		private static IntPtr __SetActorScaleSize_NativeFunctionPtr;

		// Token: 0x04013BA9 RID: 80809
		private static IntPtr __SetActorRotation_NativeFunctionPtr;

		// Token: 0x04013BAA RID: 80810
		private static IntPtr __CalculateRotation_NativeFunctionPtr;

		// Token: 0x04013BAB RID: 80811
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013BAC RID: 80812
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013BAD RID: 80813
		private static IntPtr __Run_NativeFunctionPtr;

		// Token: 0x04013BAE RID: 80814
		private static IntPtr __ExecuteUbergraph_BP_Billboard_NativeFunctionPtr;

		// Token: 0x02009FFD RID: 40957
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __CalculateScaleSize_FunctionParams
		{
			// Token: 0x04032BD8 RID: 207832
			[FieldOffset(0)]
			public float Scale;

			// Token: 0x04032BD9 RID: 207833
			[FieldOffset(8)]
			public FVectorDouble CameraLocation;

			// Token: 0x04032BDA RID: 207834
			[FieldOffset(32)]
			public FVector NewParam;
		}

		// Token: 0x02009FFE RID: 40958
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetActorScaleSize_FunctionParams
		{
			// Token: 0x04032BDB RID: 207835
			[FieldOffset(0)]
			public FVector Scale;

			// Token: 0x04032BDC RID: 207836
			[FieldOffset(12)]
			public bool bRelativeScale;
		}

		// Token: 0x02009FFF RID: 40959
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetActorRotation_FunctionParams
		{
			// Token: 0x04032BDD RID: 207837
			[FieldOffset(0)]
			public FRotator Rotation;
		}

		// Token: 0x0200A000 RID: 40960
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __CalculateRotation_FunctionParams
		{
			// Token: 0x04032BDE RID: 207838
			[FieldOffset(0)]
			public FVectorDouble CameraPosition;

			// Token: 0x04032BDF RID: 207839
			[FieldOffset(24)]
			public FRotator Rotation;
		}

		// Token: 0x0200A001 RID: 40961
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BE0 RID: 207840
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A002 RID: 40962
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_Billboard_FunctionParams
		{
			// Token: 0x04032BE1 RID: 207841
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
