using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.CellLayer
{
	// Token: 0x02003B1E RID: 15134
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/CellLayer/BP_KuroCellLayerTrigger.BP_KuroCellLayerTrigger_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1076)]
	public class BP_KuroCellLayerTrigger_C : AWorldPartitionKuroCellLayerTrigger, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602085B RID: 133211 RVA: 0x0092E7B9 File Offset: 0x0092C9B9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCellLayerTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/CellLayer/BP_KuroCellLayerTrigger.BP_KuroCellLayerTrigger_C");
			}
			return BP_KuroCellLayerTrigger_C._ClassPtr;
		}

		// Token: 0x0602085C RID: 133212 RVA: 0x0092E7E0 File Offset: 0x0092C9E0
		public BP_KuroCellLayerTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCellLayerTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602085D RID: 133213 RVA: 0x0092E808 File Offset: 0x0092CA08
		[NullableContext(1)]
		public BP_KuroCellLayerTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCellLayerTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035F2 RID: 13810
		// (get) Token: 0x0602085E RID: 133214 RVA: 0x0092E83C File Offset: 0x0092CA3C
		// (set) Token: 0x0602085F RID: 133215 RVA: 0x0092E875 File Offset: 0x0092CA75
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035F3 RID: 13811
		// (get) Token: 0x06020860 RID: 133216 RVA: 0x0092E896 File Offset: 0x0092CA96
		// (set) Token: 0x06020861 RID: 133217 RVA: 0x0092E8AA File Offset: 0x0092CAAA
		public unsafe UBoxComponent LeaveBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCellLayerTrigger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCellLayerTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035F4 RID: 13812
		// (get) Token: 0x06020862 RID: 133218 RVA: 0x0092E8BF File Offset: 0x0092CABF
		// (set) Token: 0x06020863 RID: 133219 RVA: 0x0092E8D3 File Offset: 0x0092CAD3
		public unsafe UBoxComponent EnterBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCellLayerTrigger_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCellLayerTrigger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170035F5 RID: 13813
		// (get) Token: 0x06020864 RID: 133220 RVA: 0x0092E8E8 File Offset: 0x0092CAE8
		// (set) Token: 0x06020865 RID: 133221 RVA: 0x0092E8F8 File Offset: 0x0092CAF8
		public unsafe EKuroCellLayerType Enter
		{
			get
			{
				return (EKuroCellLayerType)(*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_3));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_3) = (byte)value;
			}
		}

		// Token: 0x170035F6 RID: 13814
		// (get) Token: 0x06020866 RID: 133222 RVA: 0x0092E909 File Offset: 0x0092CB09
		// (set) Token: 0x06020867 RID: 133223 RVA: 0x0092E919 File Offset: 0x0092CB19
		public unsafe EKuroCellLayerType Leave
		{
			get
			{
				return (EKuroCellLayerType)(*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_4));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_4) = (byte)value;
			}
		}

		// Token: 0x170035F7 RID: 13815
		// (get) Token: 0x06020868 RID: 133224 RVA: 0x0092E92A File Offset: 0x0092CB2A
		// (set) Token: 0x06020869 RID: 133225 RVA: 0x0092E93A File Offset: 0x0092CB3A
		public unsafe bool InSideEnterBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170035F8 RID: 13816
		// (get) Token: 0x0602086A RID: 133226 RVA: 0x0092E94B File Offset: 0x0092CB4B
		// (set) Token: 0x0602086B RID: 133227 RVA: 0x0092E95B File Offset: 0x0092CB5B
		public unsafe bool InSideLeaveBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170035F9 RID: 13817
		// (get) Token: 0x0602086C RID: 133228 RVA: 0x0092E96C File Offset: 0x0092CB6C
		// (set) Token: 0x0602086D RID: 133229 RVA: 0x0092E97C File Offset: 0x0092CB7C
		public unsafe bool OldInSideEnterBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170035FA RID: 13818
		// (get) Token: 0x0602086E RID: 133230 RVA: 0x0092E98D File Offset: 0x0092CB8D
		// (set) Token: 0x0602086F RID: 133231 RVA: 0x0092E99D File Offset: 0x0092CB9D
		public unsafe bool OldInSideLeaveBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170035FB RID: 13819
		// (get) Token: 0x06020870 RID: 133232 RVA: 0x0092E9AE File Offset: 0x0092CBAE
		// (set) Token: 0x06020871 RID: 133233 RVA: 0x0092E9BE File Offset: 0x0092CBBE
		public unsafe EStreamingSourcePriority StreamingSourcePriority
		{
			get
			{
				return (EStreamingSourcePriority)(*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_9));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_9) = (byte)value;
			}
		}

		// Token: 0x170035FC RID: 13820
		// (get) Token: 0x06020872 RID: 133234 RVA: 0x0092E9CF File Offset: 0x0092CBCF
		// (set) Token: 0x06020873 RID: 133235 RVA: 0x0092E9E3 File Offset: 0x0092CBE3
		public unsafe FName ExclusiveDatalayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCellLayerTrigger_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06020874 RID: 133236 RVA: 0x0092E9F8 File Offset: 0x0092CBF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnLeaveBoxEndOverlap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__OnLeaveBoxEndOverlap_NativeFunctionPtr, null);
		}

		// Token: 0x06020875 RID: 133237 RVA: 0x0092EA0C File Offset: 0x0092CC0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnterBoxBeginOverlap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__OnEnterBoxBeginOverlap_NativeFunctionPtr, null);
		}

		// Token: 0x06020876 RID: 133238 RVA: 0x0092EA20 File Offset: 0x0092CC20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnTeleportStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__OnTeleportStart_NativeFunctionPtr, null);
		}

		// Token: 0x06020877 RID: 133239 RVA: 0x0092EA34 File Offset: 0x0092CC34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnTeleportStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__OnTeleportStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020878 RID: 133240 RVA: 0x0092EA4C File Offset: 0x0092CC4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020879 RID: 133241 RVA: 0x0092EB08 File Offset: 0x0092CD08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602087A RID: 133242 RVA: 0x0092EB94 File Offset: 0x0092CD94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCellLayerTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602087B RID: 133243 RVA: 0x0092EBDC File Offset: 0x0092CDDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCellLayerTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCellLayerTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602087C RID: 133244 RVA: 0x0092EC23 File Offset: 0x0092CE23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602087D RID: 133245 RVA: 0x0092EC37 File Offset: 0x0092CE37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602087E RID: 133246 RVA: 0x0092EC4C File Offset: 0x0092CE4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCellLayerTrigger(int EntryPoint)
		{
			BP_KuroCellLayerTrigger_C.__ExecuteUbergraph_BP_KuroCellLayerTrigger_FunctionParams* ptr = stackalloc BP_KuroCellLayerTrigger_C.__ExecuteUbergraph_BP_KuroCellLayerTrigger_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_KuroCellLayerTrigger_C.__ExecuteUbergraph_BP_KuroCellLayerTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCellLayerTrigger_C.__ExecuteUbergraph_BP_KuroCellLayerTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCellLayerTrigger_C.__ExecuteUbergraph_BP_KuroCellLayerTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602087F RID: 133247 RVA: 0x0092EC96 File Offset: 0x0092CE96
		protected BP_KuroCellLayerTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401043E RID: 66622
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/CellLayer/BP_KuroCellLayerTrigger.BP_KuroCellLayerTrigger_C";

		// Token: 0x0401043F RID: 66623
		private static IntPtr _ClassPtr;

		// Token: 0x04010440 RID: 66624
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010441 RID: 66625
		internal static int __PropertyOffset_0;

		// Token: 0x04010442 RID: 66626
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010443 RID: 66627
		internal static int __PropertyOffset_1;

		// Token: 0x04010444 RID: 66628
		internal static int __PropertyOffset_2;

		// Token: 0x04010445 RID: 66629
		internal static int __PropertyOffset_3;

		// Token: 0x04010446 RID: 66630
		internal static int __PropertyOffset_4;

		// Token: 0x04010447 RID: 66631
		internal static int __PropertyOffset_5;

		// Token: 0x04010448 RID: 66632
		internal static int __PropertyOffset_6;

		// Token: 0x04010449 RID: 66633
		internal static int __PropertyOffset_7;

		// Token: 0x0401044A RID: 66634
		internal static int __PropertyOffset_8;

		// Token: 0x0401044B RID: 66635
		internal static int __PropertyOffset_9;

		// Token: 0x0401044C RID: 66636
		internal static int __PropertyOffset_10;

		// Token: 0x0401044D RID: 66637
		private static IntPtr __OnLeaveBoxEndOverlap_NativeFunctionPtr;

		// Token: 0x0401044E RID: 66638
		private static IntPtr __OnEnterBoxBeginOverlap_NativeFunctionPtr;

		// Token: 0x0401044F RID: 66639
		private static IntPtr __OnTeleportStart_NativeFunctionPtr;

		// Token: 0x04010450 RID: 66640
		private static IntPtr __BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010451 RID: 66641
		private static IntPtr __BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010452 RID: 66642
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010453 RID: 66643
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010454 RID: 66644
		private static IntPtr __ExecuteUbergraph_BP_KuroCellLayerTrigger_NativeFunctionPtr;

		// Token: 0x020099C5 RID: 39365
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCellLayerTrigger_EnterBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032068 RID: 204904
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032069 RID: 204905
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403206A RID: 204906
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403206B RID: 204907
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403206C RID: 204908
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403206D RID: 204909
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x020099C6 RID: 39366
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCellLayerTrigger_LeaveBox_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403206E RID: 204910
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403206F RID: 204911
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032070 RID: 204912
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032071 RID: 204913
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x020099C7 RID: 39367
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032072 RID: 204914
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099C8 RID: 39368
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __ExecuteUbergraph_BP_KuroCellLayerTrigger_FunctionParams
		{
			// Token: 0x04032073 RID: 204915
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
