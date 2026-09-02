using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS
{
	// Token: 0x02003BF7 RID: 15351
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSSkelPlant.BP_KuroCSSkelPlant_C")]
	[UnrealStructLayout(1304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1304)]
	public class BP_KuroCSSkelPlant_C : AKuroCSSkeltalPlant, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022B5E RID: 142174 RVA: 0x0096C93F File Offset: 0x0096AB3F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSSkelPlant_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSSkelPlant.BP_KuroCSSkelPlant_C");
			}
			return BP_KuroCSSkelPlant_C._ClassPtr;
		}

		// Token: 0x06022B5F RID: 142175 RVA: 0x0096C964 File Offset: 0x0096AB64
		public BP_KuroCSSkelPlant_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSSkelPlant_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022B60 RID: 142176 RVA: 0x0096C98C File Offset: 0x0096AB8C
		public BP_KuroCSSkelPlant_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSSkelPlant_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700425C RID: 16988
		// (get) Token: 0x06022B61 RID: 142177 RVA: 0x0096C9C0 File Offset: 0x0096ABC0
		// (set) Token: 0x06022B62 RID: 142178 RVA: 0x0096C9F9 File Offset: 0x0096ABF9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700425D RID: 16989
		// (get) Token: 0x06022B63 RID: 142179 RVA: 0x0096CA1A File Offset: 0x0096AC1A
		// (set) Token: 0x06022B64 RID: 142180 RVA: 0x0096CA2E File Offset: 0x0096AC2E
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700425E RID: 16990
		// (get) Token: 0x06022B65 RID: 142181 RVA: 0x0096CA43 File Offset: 0x0096AC43
		// (set) Token: 0x06022B66 RID: 142182 RVA: 0x0096CA57 File Offset: 0x0096AC57
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700425F RID: 16991
		// (get) Token: 0x06022B67 RID: 142183 RVA: 0x0096CA6C File Offset: 0x0096AC6C
		// (set) Token: 0x06022B68 RID: 142184 RVA: 0x0096CA80 File Offset: 0x0096AC80
		[Nullable(2)]
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSSkelPlant_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004260 RID: 16992
		// (get) Token: 0x06022B69 RID: 142185 RVA: 0x0096CA98 File Offset: 0x0096AC98
		// (set) Token: 0x06022B6A RID: 142186 RVA: 0x0096CAD1 File Offset: 0x0096ACD1
		public TArray<FTransform> Bone_List
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._Bone_List) == null)
				{
					result = (this._Bone_List = new TArray<FTransform>(base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Bone_List.CopyAssign(value);
			}
		}

		// Token: 0x17004261 RID: 16993
		// (get) Token: 0x06022B6B RID: 142187 RVA: 0x0096CAE0 File Offset: 0x0096ACE0
		// (set) Token: 0x06022B6C RID: 142188 RVA: 0x0096CB19 File Offset: 0x0096AD19
		public TArray<FName> Bone_Name_List
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._Bone_Name_List) == null)
				{
					result = (this._Bone_Name_List = new TArray<FName>(base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.Bone_Name_List.CopyAssign(value);
			}
		}

		// Token: 0x17004262 RID: 16994
		// (get) Token: 0x06022B6D RID: 142189 RVA: 0x0096CB28 File Offset: 0x0096AD28
		// (set) Token: 0x06022B6E RID: 142190 RVA: 0x0096CB61 File Offset: 0x0096AD61
		public TArray<int> Parent_Index_List
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Parent_Index_List) == null)
				{
					result = (this._Parent_Index_List = new TArray<int>(base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Parent_Index_List.CopyAssign(value);
			}
		}

		// Token: 0x17004263 RID: 16995
		// (get) Token: 0x06022B6F RID: 142191 RVA: 0x0096CB70 File Offset: 0x0096AD70
		// (set) Token: 0x06022B70 RID: 142192 RVA: 0x0096CBA9 File Offset: 0x0096ADA9
		public TArray<int> childIndexList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._childIndexList) == null)
				{
					result = (this._childIndexList = new TArray<int>(base.NativePtr + (IntPtr)BP_KuroCSSkelPlant_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.childIndexList.CopyAssign(value);
			}
		}

		// Token: 0x06022B71 RID: 142193 RVA: 0x0096CBB7 File Offset: 0x0096ADB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022B72 RID: 142194 RVA: 0x0096CBCB File Offset: 0x0096ADCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B73 RID: 142195 RVA: 0x0096CBE0 File Offset: 0x0096ADE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSSkelPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B74 RID: 142196 RVA: 0x0096CC28 File Offset: 0x0096AE28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSSkelPlant_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSSkelPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B75 RID: 142197 RVA: 0x0096CC6F File Offset: 0x0096AE6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Data()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__Set_Data_NativeFunctionPtr, null);
		}

		// Token: 0x06022B76 RID: 142198 RVA: 0x0096CC84 File Offset: 0x0096AE84
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B77 RID: 142199 RVA: 0x0096CD40 File Offset: 0x0096AF40
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B78 RID: 142200 RVA: 0x0096CDCC File Offset: 0x0096AFCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSSkelPlant(int EntryPoint)
		{
			BP_KuroCSSkelPlant_C.__ExecuteUbergraph_BP_KuroCSSkelPlant_FunctionParams* ptr = stackalloc BP_KuroCSSkelPlant_C.__ExecuteUbergraph_BP_KuroCSSkelPlant_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(BP_KuroCSSkelPlant_C.__ExecuteUbergraph_BP_KuroCSSkelPlant_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSSkelPlant_C.__ExecuteUbergraph_BP_KuroCSSkelPlant_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSSkelPlant_C.__ExecuteUbergraph_BP_KuroCSSkelPlant_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B79 RID: 142201 RVA: 0x0096CE16 File Offset: 0x0096B016
		protected BP_KuroCSSkelPlant_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011985 RID: 72069
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSSkelPlant.BP_KuroCSSkelPlant_C";

		// Token: 0x04011986 RID: 72070
		private static IntPtr _ClassPtr;

		// Token: 0x04011987 RID: 72071
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011988 RID: 72072
		internal static int __PropertyOffset_0;

		// Token: 0x04011989 RID: 72073
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401198A RID: 72074
		internal static int __PropertyOffset_1;

		// Token: 0x0401198B RID: 72075
		internal static int __PropertyOffset_2;

		// Token: 0x0401198C RID: 72076
		internal static int __PropertyOffset_3;

		// Token: 0x0401198D RID: 72077
		internal static int __PropertyOffset_4;

		// Token: 0x0401198E RID: 72078
		[Nullable(2)]
		private TArray<FTransform> _Bone_List;

		// Token: 0x0401198F RID: 72079
		internal static int __PropertyOffset_5;

		// Token: 0x04011990 RID: 72080
		[Nullable(2)]
		private TArray<FName> _Bone_Name_List;

		// Token: 0x04011991 RID: 72081
		internal static int __PropertyOffset_6;

		// Token: 0x04011992 RID: 72082
		[Nullable(2)]
		private TArray<int> _Parent_Index_List;

		// Token: 0x04011993 RID: 72083
		internal static int __PropertyOffset_7;

		// Token: 0x04011994 RID: 72084
		[Nullable(2)]
		private TArray<int> _childIndexList;

		// Token: 0x04011995 RID: 72085
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011996 RID: 72086
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011997 RID: 72087
		private static IntPtr __Set_Data_NativeFunctionPtr;

		// Token: 0x04011998 RID: 72088
		private static IntPtr __BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011999 RID: 72089
		private static IntPtr __BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401199A RID: 72090
		private static IntPtr __ExecuteUbergraph_BP_KuroCSSkelPlant_NativeFunctionPtr;

		// Token: 0x02009C15 RID: 39957
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032478 RID: 205944
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C16 RID: 39958
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032479 RID: 205945
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403247A RID: 205946
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403247B RID: 205947
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403247C RID: 205948
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403247D RID: 205949
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403247E RID: 205950
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C17 RID: 39959
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSSkelPlant_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403247F RID: 205951
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032480 RID: 205952
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032481 RID: 205953
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032482 RID: 205954
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C18 RID: 39960
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSSkelPlant_FunctionParams
		{
			// Token: 0x04032483 RID: 205955
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
