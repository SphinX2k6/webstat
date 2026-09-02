using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterFallSpray
{
	// Token: 0x02003B59 RID: 15193
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterFallSpray/BP_WaterfallSpray.BP_WaterfallSpray_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1082)]
	public class BP_WaterfallSpray_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021292 RID: 135826 RVA: 0x00941639 File Offset: 0x0093F839
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterfallSpray_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterFallSpray/BP_WaterfallSpray.BP_WaterfallSpray_C");
			}
			return BP_WaterfallSpray_C._ClassPtr;
		}

		// Token: 0x06021293 RID: 135827 RVA: 0x00941660 File Offset: 0x0093F860
		public BP_WaterfallSpray_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterfallSpray_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021294 RID: 135828 RVA: 0x00941688 File Offset: 0x0093F888
		[NullableContext(1)]
		public BP_WaterfallSpray_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterfallSpray_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700397F RID: 14719
		// (get) Token: 0x06021295 RID: 135829 RVA: 0x009416BC File Offset: 0x0093F8BC
		// (set) Token: 0x06021296 RID: 135830 RVA: 0x009416F5 File Offset: 0x0093F8F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003980 RID: 14720
		// (get) Token: 0x06021297 RID: 135831 RVA: 0x00941716 File Offset: 0x0093F916
		// (set) Token: 0x06021298 RID: 135832 RVA: 0x0094172A File Offset: 0x0093F92A
		public unsafe UBoxComponent Box_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003981 RID: 14721
		// (get) Token: 0x06021299 RID: 135833 RVA: 0x0094173F File Offset: 0x0093F93F
		// (set) Token: 0x0602129A RID: 135834 RVA: 0x00941753 File Offset: 0x0093F953
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003982 RID: 14722
		// (get) Token: 0x0602129B RID: 135835 RVA: 0x00941768 File Offset: 0x0093F968
		// (set) Token: 0x0602129C RID: 135836 RVA: 0x0094177C File Offset: 0x0093F97C
		public unsafe UNiagaraComponent NS_Fx_WaterfallSpray
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003983 RID: 14723
		// (get) Token: 0x0602129D RID: 135837 RVA: 0x00941791 File Offset: 0x0093F991
		// (set) Token: 0x0602129E RID: 135838 RVA: 0x009417A5 File Offset: 0x0093F9A5
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003984 RID: 14724
		// (get) Token: 0x0602129F RID: 135839 RVA: 0x009417BA File Offset: 0x0093F9BA
		// (set) Token: 0x060212A0 RID: 135840 RVA: 0x009417CE File Offset: 0x0093F9CE
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterfallSpray_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003985 RID: 14725
		// (get) Token: 0x060212A1 RID: 135841 RVA: 0x009417E3 File Offset: 0x0093F9E3
		// (set) Token: 0x060212A2 RID: 135842 RVA: 0x009417F3 File Offset: 0x0093F9F3
		public unsafe bool bPlayerOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003986 RID: 14726
		// (get) Token: 0x060212A3 RID: 135843 RVA: 0x00941804 File Offset: 0x0093FA04
		// (set) Token: 0x060212A4 RID: 135844 RVA: 0x00941814 File Offset: 0x0093FA14
		public unsafe bool bNPCWaterfall
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterfallSpray_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x060212A5 RID: 135845 RVA: 0x00941825 File Offset: 0x0093FA25
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x060212A6 RID: 135846 RVA: 0x00941839 File Offset: 0x0093FA39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060212A7 RID: 135847 RVA: 0x0094184D File Offset: 0x0093FA4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterfallSpray_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060212A8 RID: 135848 RVA: 0x00941862 File Offset: 0x0093FA62
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060212A9 RID: 135849 RVA: 0x00941876 File Offset: 0x0093FA76
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterfallSpray_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060212AA RID: 135850 RVA: 0x0094188C File Offset: 0x0093FA8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterfallSpray_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterfallSpray_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterfallSpray_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterfallSpray_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212AB RID: 135851 RVA: 0x009418D4 File Offset: 0x0093FAD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterfallSpray_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterfallSpray_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterfallSpray_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterfallSpray_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterfallSpray_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212AC RID: 135852 RVA: 0x0094191C File Offset: 0x0093FB1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212AD RID: 135853 RVA: 0x009419D8 File Offset: 0x0093FBD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterfallSpray_C.__BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212AE RID: 135854 RVA: 0x00941A64 File Offset: 0x0093FC64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterfallSpray(int EntryPoint)
		{
			BP_WaterfallSpray_C.__ExecuteUbergraph_BP_WaterfallSpray_FunctionParams* ptr = stackalloc BP_WaterfallSpray_C.__ExecuteUbergraph_BP_WaterfallSpray_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_WaterfallSpray_C.__ExecuteUbergraph_BP_WaterfallSpray_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterfallSpray_C.__ExecuteUbergraph_BP_WaterfallSpray_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterfallSpray_C.__ExecuteUbergraph_BP_WaterfallSpray_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212AF RID: 135855 RVA: 0x00941AAE File Offset: 0x0093FCAE
		protected BP_WaterfallSpray_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A98 RID: 68248
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterFallSpray/BP_WaterfallSpray.BP_WaterfallSpray_C";

		// Token: 0x04010A99 RID: 68249
		private static IntPtr _ClassPtr;

		// Token: 0x04010A9A RID: 68250
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A9B RID: 68251
		internal static int __PropertyOffset_0;

		// Token: 0x04010A9C RID: 68252
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010A9D RID: 68253
		internal static int __PropertyOffset_1;

		// Token: 0x04010A9E RID: 68254
		internal static int __PropertyOffset_2;

		// Token: 0x04010A9F RID: 68255
		internal static int __PropertyOffset_3;

		// Token: 0x04010AA0 RID: 68256
		internal static int __PropertyOffset_4;

		// Token: 0x04010AA1 RID: 68257
		internal static int __PropertyOffset_5;

		// Token: 0x04010AA2 RID: 68258
		internal static int __PropertyOffset_6;

		// Token: 0x04010AA3 RID: 68259
		internal static int __PropertyOffset_7;

		// Token: 0x04010AA4 RID: 68260
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04010AA5 RID: 68261
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010AA6 RID: 68262
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010AA7 RID: 68263
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010AA8 RID: 68264
		private static IntPtr __BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010AA9 RID: 68265
		private static IntPtr __BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010AAA RID: 68266
		private static IntPtr __ExecuteUbergraph_BP_WaterfallSpray_NativeFunctionPtr;

		// Token: 0x02009A85 RID: 39557
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040321D9 RID: 205273
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A86 RID: 39558
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321DA RID: 205274
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321DB RID: 205275
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321DC RID: 205276
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321DD RID: 205277
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040321DE RID: 205278
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321DF RID: 205279
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A87 RID: 39559
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterfallSpray_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321E0 RID: 205280
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321E1 RID: 205281
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321E2 RID: 205282
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321E3 RID: 205283
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A88 RID: 39560
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __ExecuteUbergraph_BP_WaterfallSpray_FunctionParams
		{
			// Token: 0x040321E4 RID: 205284
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
