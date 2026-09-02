using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.RayTracing
{
	// Token: 0x02003B36 RID: 15158
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/RayTracing/BP_RaytracingFeatureTriggerVolume.BP_RaytracingFeatureTriggerVolume_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1080)]
	public class BP_RaytracingFeatureTriggerVolume_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020BA2 RID: 134050 RVA: 0x009352EB File Offset: 0x009334EB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RaytracingFeatureTriggerVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/RayTracing/BP_RaytracingFeatureTriggerVolume.BP_RaytracingFeatureTriggerVolume_C");
			}
			return BP_RaytracingFeatureTriggerVolume_C._ClassPtr;
		}

		// Token: 0x06020BA3 RID: 134051 RVA: 0x00935310 File Offset: 0x00933510
		public BP_RaytracingFeatureTriggerVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_RaytracingFeatureTriggerVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020BA4 RID: 134052 RVA: 0x00935338 File Offset: 0x00933538
		public BP_RaytracingFeatureTriggerVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RaytracingFeatureTriggerVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036EC RID: 14060
		// (get) Token: 0x06020BA5 RID: 134053 RVA: 0x0093536C File Offset: 0x0093356C
		// (set) Token: 0x06020BA6 RID: 134054 RVA: 0x009353A5 File Offset: 0x009335A5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036ED RID: 14061
		// (get) Token: 0x06020BA7 RID: 134055 RVA: 0x009353C6 File Offset: 0x009335C6
		// (set) Token: 0x06020BA8 RID: 134056 RVA: 0x009353DA File Offset: 0x009335DA
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036EE RID: 14062
		// (get) Token: 0x06020BA9 RID: 134057 RVA: 0x009353F0 File Offset: 0x009335F0
		// (set) Token: 0x06020BAA RID: 134058 RVA: 0x00935429 File Offset: 0x00933629
		public TArray<int> PreValues
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._PreValues) == null)
				{
					result = (this._PreValues = new TArray<int>(base.NativePtr + (IntPtr)BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.PreValues.CopyAssign(value);
			}
		}

		// Token: 0x170036EF RID: 14063
		// (get) Token: 0x06020BAB RID: 134059 RVA: 0x00935438 File Offset: 0x00933638
		// (set) Token: 0x06020BAC RID: 134060 RVA: 0x00935471 File Offset: 0x00933671
		public TArray<string> RaytracingCmd
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._RaytracingCmd) == null)
				{
					result = (this._RaytracingCmd = new TArray<string>(base.NativePtr + (IntPtr)BP_RaytracingFeatureTriggerVolume_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.RaytracingCmd.CopyAssign(value);
			}
		}

		// Token: 0x06020BAD RID: 134061 RVA: 0x00935480 File Offset: 0x00933680
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020BAE RID: 134062 RVA: 0x0093553C File Offset: 0x0093373C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RaytracingFeatureTriggerVolume_C.__BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020BAF RID: 134063 RVA: 0x009355C8 File Offset: 0x009337C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume(int EntryPoint)
		{
			BP_RaytracingFeatureTriggerVolume_C.__ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_FunctionParams* ptr = stackalloc BP_RaytracingFeatureTriggerVolume_C.__ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_FunctionParams[(UIntPtr)415] + 15L / (long)sizeof(BP_RaytracingFeatureTriggerVolume_C.__ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RaytracingFeatureTriggerVolume_C.__ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RaytracingFeatureTriggerVolume_C.__ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020BB0 RID: 134064 RVA: 0x00935612 File Offset: 0x00933812
		protected BP_RaytracingFeatureTriggerVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010661 RID: 67169
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/RayTracing/BP_RaytracingFeatureTriggerVolume.BP_RaytracingFeatureTriggerVolume_C";

		// Token: 0x04010662 RID: 67170
		private static IntPtr _ClassPtr;

		// Token: 0x04010663 RID: 67171
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010664 RID: 67172
		internal static int __PropertyOffset_0;

		// Token: 0x04010665 RID: 67173
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010666 RID: 67174
		internal static int __PropertyOffset_1;

		// Token: 0x04010667 RID: 67175
		internal static int __PropertyOffset_2;

		// Token: 0x04010668 RID: 67176
		[Nullable(2)]
		private TArray<int> _PreValues;

		// Token: 0x04010669 RID: 67177
		internal static int __PropertyOffset_3;

		// Token: 0x0401066A RID: 67178
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _RaytracingCmd;

		// Token: 0x0401066B RID: 67179
		private static IntPtr __BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401066C RID: 67180
		private static IntPtr __BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401066D RID: 67181
		private static IntPtr __ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_NativeFunctionPtr;

		// Token: 0x02009A1E RID: 39454
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403210C RID: 205068
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403210D RID: 205069
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403210E RID: 205070
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403210F RID: 205071
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032110 RID: 205072
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032111 RID: 205073
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A1F RID: 39455
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RaytracingFeatureTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032112 RID: 205074
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032113 RID: 205075
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032114 RID: 205076
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032115 RID: 205077
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A20 RID: 39456
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 400)]
		protected ref struct __ExecuteUbergraph_BP_RaytracingFeatureTriggerVolume_FunctionParams
		{
			// Token: 0x04032116 RID: 205078
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
