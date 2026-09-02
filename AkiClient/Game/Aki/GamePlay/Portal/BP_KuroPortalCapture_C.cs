using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.Portal
{
	// Token: 0x02003DCB RID: 15819
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_KuroPortalCapture_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026BD6 RID: 158678 RVA: 0x009E0C30 File Offset: 0x009DEE30
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroPortalCapture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C");
			}
			return BP_KuroPortalCapture_C._ClassPtr;
		}

		// Token: 0x06026BD7 RID: 158679 RVA: 0x009E0C54 File Offset: 0x009DEE54
		public BP_KuroPortalCapture_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroPortalCapture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026BD8 RID: 158680 RVA: 0x009E0C7C File Offset: 0x009DEE7C
		[NullableContext(1)]
		public BP_KuroPortalCapture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroPortalCapture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058DA RID: 22746
		// (get) Token: 0x06026BD9 RID: 158681 RVA: 0x009E0CB0 File Offset: 0x009DEEB0
		// (set) Token: 0x06026BDA RID: 158682 RVA: 0x009E0CE9 File Offset: 0x009DEEE9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170058DB RID: 22747
		// (get) Token: 0x06026BDB RID: 158683 RVA: 0x009E0D0A File Offset: 0x009DEF0A
		// (set) Token: 0x06026BDC RID: 158684 RVA: 0x009E0D1E File Offset: 0x009DEF1E
		public unsafe UArrowComponent Arrow1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170058DC RID: 22748
		// (get) Token: 0x06026BDD RID: 158685 RVA: 0x009E0D33 File Offset: 0x009DEF33
		// (set) Token: 0x06026BDE RID: 158686 RVA: 0x009E0D47 File Offset: 0x009DEF47
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170058DD RID: 22749
		// (get) Token: 0x06026BDF RID: 158687 RVA: 0x009E0D5C File Offset: 0x009DEF5C
		// (set) Token: 0x06026BE0 RID: 158688 RVA: 0x009E0D70 File Offset: 0x009DEF70
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170058DE RID: 22750
		// (get) Token: 0x06026BE1 RID: 158689 RVA: 0x009E0D85 File Offset: 0x009DEF85
		// (set) Token: 0x06026BE2 RID: 158690 RVA: 0x009E0D99 File Offset: 0x009DEF99
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170058DF RID: 22751
		// (get) Token: 0x06026BE3 RID: 158691 RVA: 0x009E0DAE File Offset: 0x009DEFAE
		// (set) Token: 0x06026BE4 RID: 158692 RVA: 0x009E0DC2 File Offset: 0x009DEFC2
		public unsafe AActor Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroPortalCapture_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170058E0 RID: 22752
		// (get) Token: 0x06026BE5 RID: 158693 RVA: 0x009E0DD7 File Offset: 0x009DEFD7
		// (set) Token: 0x06026BE6 RID: 158694 RVA: 0x009E0DE7 File Offset: 0x009DEFE7
		public unsafe float offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170058E1 RID: 22753
		// (get) Token: 0x06026BE7 RID: 158695 RVA: 0x009E0DF8 File Offset: 0x009DEFF8
		// (set) Token: 0x06026BE8 RID: 158696 RVA: 0x009E0E08 File Offset: 0x009DF008
		public unsafe bool EnableCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170058E2 RID: 22754
		// (get) Token: 0x06026BE9 RID: 158697 RVA: 0x009E0E1C File Offset: 0x009DF01C
		// (set) Token: 0x06026BEA RID: 158698 RVA: 0x009E0E55 File Offset: 0x009DF055
		[Nullable(1)]
		public RoleTeleport RoleTeleport
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				RoleTeleport result;
				if ((result = this._RoleTeleport) == null)
				{
					result = (this._RoleTeleport = new RoleTeleport(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170058E3 RID: 22755
		// (get) Token: 0x06026BEB RID: 158699 RVA: 0x009E0E76 File Offset: 0x009DF076
		// (set) Token: 0x06026BEC RID: 158700 RVA: 0x009E0E86 File Offset: 0x009DF086
		public unsafe int PbdataId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170058E4 RID: 22756
		// (get) Token: 0x06026BED RID: 158701 RVA: 0x009E0E97 File Offset: 0x009DF097
		// (set) Token: 0x06026BEE RID: 158702 RVA: 0x009E0EA7 File Offset: 0x009DF0A7
		public unsafe float Hight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroPortalCapture_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06026BEF RID: 158703 RVA: 0x009E0EB8 File Offset: 0x009DF0B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ToggleDebug(bool Enable)
		{
			BP_KuroPortalCapture_C.__ToggleDebug_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__ToggleDebug_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__ToggleDebug_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__ToggleDebug_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ToggleDebug_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BF0 RID: 158704 RVA: 0x009E0F00 File Offset: 0x009DF100
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPair(ref BP_KuroPortalCapture_C Target)
		{
			BP_KuroPortalCapture_C.__GetPair_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__GetPair_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__GetPair_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__GetPair_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_KuroPortalCapture_C.__GetPair_FunctionParams ptr2 = ref *ptr;
			BP_KuroPortalCapture_C bp_KuroPortalCapture_C = Target;
			ptr2.Target = ((bp_KuroPortalCapture_C != null) ? bp_KuroPortalCapture_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__GetPair_NativeFunctionPtr, (void*)ptr);
			Target = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_KuroPortalCapture_C>(ptr->Target);
		}

		// Token: 0x06026BF1 RID: 158705 RVA: 0x009E0F64 File Offset: 0x009DF164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPortalTrans(ref FTransformDouble NewParam)
		{
			BP_KuroPortalCapture_C.__GetPortalTrans_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__GetPortalTrans_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__GetPortalTrans_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__GetPortalTrans_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__GetPortalTrans_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06026BF2 RID: 158706 RVA: 0x009E0FC0 File Offset: 0x009DF1C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPbDataId(int PbdataId)
		{
			BP_KuroPortalCapture_C.__SetPbDataId_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__SetPbDataId_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__SetPbDataId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__SetPbDataId_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PbdataId = PbdataId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__SetPbDataId_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BF3 RID: 158707 RVA: 0x009E1008 File Offset: 0x009DF208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPair(AActor Pair)
		{
			BP_KuroPortalCapture_C.__SetPair_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__SetPair_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__SetPair_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__SetPair_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pair = ((Pair != null) ? Pair.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__SetPair_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BF4 RID: 158708 RVA: 0x009E1060 File Offset: 0x009DF260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Teleport(FTransformDouble InTrans, AActor InActor, bool IsRole)
		{
			BP_KuroPortalCapture_C.__Teleport_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__Teleport_FunctionParams[(UIntPtr)3135] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__Teleport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__Teleport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTrans = InTrans;
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			ptr->IsRole = IsRole;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__Teleport_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BF5 RID: 158709 RVA: 0x009E10C6 File Offset: 0x009DF2C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026BF6 RID: 158710 RVA: 0x009E10DA File Offset: 0x009DF2DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026BF7 RID: 158711 RVA: 0x009E10F0 File Offset: 0x009DF2F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BF8 RID: 158712 RVA: 0x009E1138 File Offset: 0x009DF338
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026BF9 RID: 158713 RVA: 0x009E1180 File Offset: 0x009DF380
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroPortalCapture(int EntryPoint)
		{
			BP_KuroPortalCapture_C.__ExecuteUbergraph_BP_KuroPortalCapture_FunctionParams* ptr = stackalloc BP_KuroPortalCapture_C.__ExecuteUbergraph_BP_KuroPortalCapture_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_KuroPortalCapture_C.__ExecuteUbergraph_BP_KuroPortalCapture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroPortalCapture_C.__ExecuteUbergraph_BP_KuroPortalCapture_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroPortalCapture_C.__ExecuteUbergraph_BP_KuroPortalCapture_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026BFA RID: 158714 RVA: 0x009E11C7 File Offset: 0x009DF3C7
		protected BP_KuroPortalCapture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014340 RID: 82752
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C";

		// Token: 0x04014341 RID: 82753
		private static IntPtr _ClassPtr;

		// Token: 0x04014342 RID: 82754
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014343 RID: 82755
		public static IntPtr __RoleTeleport__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04014344 RID: 82756
		internal static int __PropertyOffset_0;

		// Token: 0x04014345 RID: 82757
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014346 RID: 82758
		internal static int __PropertyOffset_1;

		// Token: 0x04014347 RID: 82759
		internal static int __PropertyOffset_2;

		// Token: 0x04014348 RID: 82760
		internal static int __PropertyOffset_3;

		// Token: 0x04014349 RID: 82761
		internal static int __PropertyOffset_4;

		// Token: 0x0401434A RID: 82762
		internal static int __PropertyOffset_5;

		// Token: 0x0401434B RID: 82763
		internal static int __PropertyOffset_6;

		// Token: 0x0401434C RID: 82764
		internal static int __PropertyOffset_7;

		// Token: 0x0401434D RID: 82765
		internal static int __PropertyOffset_8;

		// Token: 0x0401434E RID: 82766
		private RoleTeleport _RoleTeleport;

		// Token: 0x0401434F RID: 82767
		internal static int __PropertyOffset_9;

		// Token: 0x04014350 RID: 82768
		internal static int __PropertyOffset_10;

		// Token: 0x04014351 RID: 82769
		private static IntPtr __ToggleDebug_NativeFunctionPtr;

		// Token: 0x04014352 RID: 82770
		private static IntPtr __GetPair_NativeFunctionPtr;

		// Token: 0x04014353 RID: 82771
		private static IntPtr __GetPortalTrans_NativeFunctionPtr;

		// Token: 0x04014354 RID: 82772
		private static IntPtr __SetPbDataId_NativeFunctionPtr;

		// Token: 0x04014355 RID: 82773
		private static IntPtr __SetPair_NativeFunctionPtr;

		// Token: 0x04014356 RID: 82774
		private static IntPtr __Teleport_NativeFunctionPtr;

		// Token: 0x04014357 RID: 82775
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04014358 RID: 82776
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014359 RID: 82777
		private static IntPtr __ExecuteUbergraph_BP_KuroPortalCapture_NativeFunctionPtr;

		// Token: 0x0200A0B3 RID: 41139
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ToggleDebug_FunctionParams
		{
			// Token: 0x04032D63 RID: 208227
			[FieldOffset(0)]
			public bool Enable;
		}

		// Token: 0x0200A0B4 RID: 41140
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetPair_FunctionParams
		{
			// Token: 0x04032D64 RID: 208228
			[FieldOffset(0)]
			public IntPtr Target;
		}

		// Token: 0x0200A0B5 RID: 41141
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __GetPortalTrans_FunctionParams
		{
			// Token: 0x04032D65 RID: 208229
			[FieldOffset(0)]
			public FTransformDouble NewParam;
		}

		// Token: 0x0200A0B6 RID: 41142
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetPbDataId_FunctionParams
		{
			// Token: 0x04032D66 RID: 208230
			[FieldOffset(0)]
			public int PbdataId;
		}

		// Token: 0x0200A0B7 RID: 41143
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetPair_FunctionParams
		{
			// Token: 0x04032D67 RID: 208231
			[FieldOffset(0)]
			public IntPtr Pair;
		}

		// Token: 0x0200A0B8 RID: 41144
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3120)]
		protected ref struct __Teleport_FunctionParams
		{
			// Token: 0x04032D68 RID: 208232
			[FieldOffset(0)]
			public FTransformDouble InTrans;

			// Token: 0x04032D69 RID: 208233
			[FieldOffset(64)]
			public IntPtr InActor;

			// Token: 0x04032D6A RID: 208234
			[FieldOffset(72)]
			public bool IsRole;
		}

		// Token: 0x0200A0B9 RID: 41145
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D6B RID: 208235
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0BA RID: 41146
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_KuroPortalCapture_FunctionParams
		{
			// Token: 0x04032D6C RID: 208236
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
