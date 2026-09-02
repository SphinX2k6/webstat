using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.PostVolumeGlobal
{
	// Token: 0x02003BEC RID: 15340
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Local.BP_KuroVolumeCloud_Local_C")]
	[UnrealStructLayout(1912, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1908)]
	public class BP_KuroVolumeCloud_Local_C : BP_KuroVolumeCloud_Global_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022932 RID: 141618 RVA: 0x00968FD3 File Offset: 0x009671D3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumeCloud_Local_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Local.BP_KuroVolumeCloud_Local_C");
			}
			return BP_KuroVolumeCloud_Local_C._ClassPtr;
		}

		// Token: 0x06022933 RID: 141619 RVA: 0x00968FF8 File Offset: 0x009671F8
		public BP_KuroVolumeCloud_Local_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeCloud_Local_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022934 RID: 141620 RVA: 0x00969020 File Offset: 0x00967220
		[NullableContext(1)]
		public BP_KuroVolumeCloud_Local_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeCloud_Local_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004197 RID: 16791
		// (get) Token: 0x06022935 RID: 141621 RVA: 0x00969054 File Offset: 0x00967254
		// (set) Token: 0x06022936 RID: 141622 RVA: 0x0096908D File Offset: 0x0096728D
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004198 RID: 16792
		// (get) Token: 0x06022937 RID: 141623 RVA: 0x009690AE File Offset: 0x009672AE
		// (set) Token: 0x06022938 RID: 141624 RVA: 0x009690C2 File Offset: 0x009672C2
		[Nullable(2)]
		public unsafe UMaterialInstanceConstant HighCloudMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Local_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Local_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004199 RID: 16793
		// (get) Token: 0x06022939 RID: 141625 RVA: 0x009690D7 File Offset: 0x009672D7
		// (set) Token: 0x0602293A RID: 141626 RVA: 0x009690E7 File Offset: 0x009672E7
		public unsafe bool bTickInUI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700419A RID: 16794
		// (get) Token: 0x0602293B RID: 141627 RVA: 0x009690F8 File Offset: 0x009672F8
		// (set) Token: 0x0602293C RID: 141628 RVA: 0x00969108 File Offset: 0x00967308
		public unsafe bool bUseMPCRenderQueueOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700419B RID: 16795
		// (get) Token: 0x0602293D RID: 141629 RVA: 0x00969119 File Offset: 0x00967319
		// (set) Token: 0x0602293E RID: 141630 RVA: 0x00969129 File Offset: 0x00967329
		public unsafe bool bNoTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700419C RID: 16796
		// (get) Token: 0x0602293F RID: 141631 RVA: 0x0096913A File Offset: 0x0096733A
		// (set) Token: 0x06022940 RID: 141632 RVA: 0x0096914A File Offset: 0x0096734A
		public unsafe bool bUseMaterialSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Local_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022941 RID: 141633 RVA: 0x0096915B File Offset: 0x0096735B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06022942 RID: 141634 RVA: 0x0096916F File Offset: 0x0096736F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022943 RID: 141635 RVA: 0x00969183 File Offset: 0x00967383
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022944 RID: 141636 RVA: 0x00969198 File Offset: 0x00967398
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022945 RID: 141637 RVA: 0x009691AC File Offset: 0x009673AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022946 RID: 141638 RVA: 0x009691C4 File Offset: 0x009673C4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022947 RID: 141639 RVA: 0x0096921C File Offset: 0x0096741C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022948 RID: 141640 RVA: 0x00969274 File Offset: 0x00967474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Local_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022949 RID: 141641 RVA: 0x009692BC File Offset: 0x009674BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeCloud_Local_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Local_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602294A RID: 141642 RVA: 0x00969303 File Offset: 0x00967503
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeSave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeSave_NativeFunctionPtr, null);
		}

		// Token: 0x0602294B RID: 141643 RVA: 0x00969317 File Offset: 0x00967517
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeSave_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeSave_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602294C RID: 141644 RVA: 0x0096932C File Offset: 0x0096752C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x0602294D RID: 141645 RVA: 0x00969340 File Offset: 0x00967540
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602294E RID: 141646 RVA: 0x00969355 File Offset: 0x00967555
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x0602294F RID: 141647 RVA: 0x00969369 File Offset: 0x00967569
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022950 RID: 141648 RVA: 0x0096937E File Offset: 0x0096757E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022951 RID: 141649 RVA: 0x00969394 File Offset: 0x00967594
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumeCloud_Local(int EntryPoint)
		{
			BP_KuroVolumeCloud_Local_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Local_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Local_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Local_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_KuroVolumeCloud_Local_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Local_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Local_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Local_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Local_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Local_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022952 RID: 141650 RVA: 0x009693DB File Offset: 0x009675DB
		protected BP_KuroVolumeCloud_Local_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401183A RID: 71738
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Local.BP_KuroVolumeCloud_Local_C";

		// Token: 0x0401183B RID: 71739
		private static IntPtr _ClassPtr;

		// Token: 0x0401183C RID: 71740
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401183D RID: 71741
		internal new static int __PropertyOffset_0;

		// Token: 0x0401183E RID: 71742
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401183F RID: 71743
		internal new static int __PropertyOffset_1;

		// Token: 0x04011840 RID: 71744
		internal new static int __PropertyOffset_2;

		// Token: 0x04011841 RID: 71745
		internal new static int __PropertyOffset_3;

		// Token: 0x04011842 RID: 71746
		internal new static int __PropertyOffset_4;

		// Token: 0x04011843 RID: 71747
		internal new static int __PropertyOffset_5;

		// Token: 0x04011844 RID: 71748
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04011845 RID: 71749
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011846 RID: 71750
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011847 RID: 71751
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04011848 RID: 71752
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011849 RID: 71753
		private static IntPtr __BeforeSave_NativeFunctionPtr;

		// Token: 0x0401184A RID: 71754
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x0401184B RID: 71755
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x0401184C RID: 71756
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401184D RID: 71757
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumeCloud_Local_NativeFunctionPtr;

		// Token: 0x02009BF6 RID: 39926
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032450 RID: 205904
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009BF7 RID: 39927
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032451 RID: 205905
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BF8 RID: 39928
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumeCloud_Local_FunctionParams
		{
			// Token: 0x04032452 RID: 205906
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
