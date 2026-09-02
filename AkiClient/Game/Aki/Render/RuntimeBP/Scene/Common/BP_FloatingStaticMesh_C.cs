using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AD8 RID: 15064
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh.BP_FloatingStaticMesh_C")]
	[UnrealStructLayout(2656, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2653)]
	public class BP_FloatingStaticMesh_C : AKuroFloatingStaticMesh, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060203AD RID: 132013 RVA: 0x00925FE7 File Offset: 0x009241E7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingStaticMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh.BP_FloatingStaticMesh_C");
			}
			return BP_FloatingStaticMesh_C._ClassPtr;
		}

		// Token: 0x060203AE RID: 132014 RVA: 0x0092600C File Offset: 0x0092420C
		public BP_FloatingStaticMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060203AF RID: 132015 RVA: 0x00926034 File Offset: 0x00924234
		public BP_FloatingStaticMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003485 RID: 13445
		// (get) Token: 0x060203B0 RID: 132016 RVA: 0x00926068 File Offset: 0x00924268
		// (set) Token: 0x060203B1 RID: 132017 RVA: 0x009260A1 File Offset: 0x009242A1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003486 RID: 13446
		// (get) Token: 0x060203B2 RID: 132018 RVA: 0x009260C2 File Offset: 0x009242C2
		// (set) Token: 0x060203B3 RID: 132019 RVA: 0x009260D6 File Offset: 0x009242D6
		[Nullable(2)]
		public unsafe UKuroVirtualAttachmentParentComponent KuroVirtualAttachmentParent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVirtualAttachmentParentComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003487 RID: 13447
		// (get) Token: 0x060203B4 RID: 132020 RVA: 0x009260EB File Offset: 0x009242EB
		// (set) Token: 0x060203B5 RID: 132021 RVA: 0x009260FF File Offset: 0x009242FF
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMeshComp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003488 RID: 13448
		// (get) Token: 0x060203B6 RID: 132022 RVA: 0x00926114 File Offset: 0x00924314
		// (set) Token: 0x060203B7 RID: 132023 RVA: 0x00926128 File Offset: 0x00924328
		[Nullable(2)]
		public unsafe USceneComponent Scene
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003489 RID: 13449
		// (get) Token: 0x060203B8 RID: 132024 RVA: 0x0092613D File Offset: 0x0092433D
		// (set) Token: 0x060203B9 RID: 132025 RVA: 0x0092614D File Offset: 0x0092434D
		public unsafe bool 使用材质参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700348A RID: 13450
		// (get) Token: 0x060203BA RID: 132026 RVA: 0x00926160 File Offset: 0x00924360
		// (set) Token: 0x060203BB RID: 132027 RVA: 0x00926199 File Offset: 0x00924399
		public TMap<FName, float> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700348B RID: 13451
		// (get) Token: 0x060203BC RID: 132028 RVA: 0x009261A8 File Offset: 0x009243A8
		// (set) Token: 0x060203BD RID: 132029 RVA: 0x009261E1 File Offset: 0x009243E1
		public TMap<FName, FLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700348C RID: 13452
		// (get) Token: 0x060203BE RID: 132030 RVA: 0x009261EF File Offset: 0x009243EF
		// (set) Token: 0x060203BF RID: 132031 RVA: 0x00926203 File Offset: 0x00924403
		public unsafe FLinearColor EmissionDayColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700348D RID: 13453
		// (get) Token: 0x060203C0 RID: 132032 RVA: 0x00926218 File Offset: 0x00924418
		// (set) Token: 0x060203C1 RID: 132033 RVA: 0x0092622C File Offset: 0x0092442C
		public unsafe FLinearColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700348E RID: 13454
		// (get) Token: 0x060203C2 RID: 132034 RVA: 0x00926241 File Offset: 0x00924441
		// (set) Token: 0x060203C3 RID: 132035 RVA: 0x00926251 File Offset: 0x00924451
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700348F RID: 13455
		// (get) Token: 0x060203C4 RID: 132036 RVA: 0x00926264 File Offset: 0x00924464
		// (set) Token: 0x060203C5 RID: 132037 RVA: 0x0092629D File Offset: 0x0092449D
		public TMap<AActor, FTransformDouble> ChildActors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FTransformDouble> result;
				if ((result = this._ChildActors) == null)
				{
					result = (this._ChildActors = new TMap<AActor, FTransformDouble>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.ChildActors.CopyAssign(value);
			}
		}

		// Token: 0x17003490 RID: 13456
		// (get) Token: 0x060203C6 RID: 132038 RVA: 0x009262AC File Offset: 0x009244AC
		// (set) Token: 0x060203C7 RID: 132039 RVA: 0x009262E5 File Offset: 0x009244E5
		public TArray<float> CustomData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TArray<float>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x17003491 RID: 13457
		// (get) Token: 0x060203C8 RID: 132040 RVA: 0x009262F3 File Offset: 0x009244F3
		// (set) Token: 0x060203C9 RID: 132041 RVA: 0x00926303 File Offset: 0x00924503
		public unsafe bool SpecialBlueprintActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003492 RID: 13458
		// (get) Token: 0x060203CA RID: 132042 RVA: 0x00926314 File Offset: 0x00924514
		// (set) Token: 0x060203CB RID: 132043 RVA: 0x00926324 File Offset: 0x00924524
		public unsafe bool OverrideSuperFarActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003493 RID: 13459
		// (get) Token: 0x060203CC RID: 132044 RVA: 0x00926335 File Offset: 0x00924535
		// (set) Token: 0x060203CD RID: 132045 RVA: 0x00926345 File Offset: 0x00924545
		public unsafe bool HiddenState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003494 RID: 13460
		// (get) Token: 0x060203CE RID: 132046 RVA: 0x00926356 File Offset: 0x00924556
		// (set) Token: 0x060203CF RID: 132047 RVA: 0x00926366 File Offset: 0x00924566
		public unsafe bool UseWasRecentlyPassVisibilityTest
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003495 RID: 13461
		// (get) Token: 0x060203D0 RID: 132048 RVA: 0x00926377 File Offset: 0x00924577
		// (set) Token: 0x060203D1 RID: 132049 RVA: 0x00926387 File Offset: 0x00924587
		public unsafe bool ForceSpecial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x060203D2 RID: 132050 RVA: 0x00926398 File Offset: 0x00924598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetCustomData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__SetCustomData_NativeFunctionPtr, null);
		}

		// Token: 0x060203D3 RID: 132051 RVA: 0x009263AC File Offset: 0x009245AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CopyCustomPrimitiveData(UStaticMeshComponent Target)
		{
			BP_FloatingStaticMesh_C.__CopyCustomPrimitiveData_FunctionParams* ptr = stackalloc BP_FloatingStaticMesh_C.__CopyCustomPrimitiveData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FloatingStaticMesh_C.__CopyCustomPrimitiveData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingStaticMesh_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060203D4 RID: 132052 RVA: 0x00926401 File Offset: 0x00924601
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshChildActors()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__RefreshChildActors_NativeFunctionPtr, null);
		}

		// Token: 0x060203D5 RID: 132053 RVA: 0x00926415 File Offset: 0x00924615
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__SetMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x060203D6 RID: 132054 RVA: 0x00926429 File Offset: 0x00924629
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060203D7 RID: 132055 RVA: 0x0092643D File Offset: 0x0092463D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060203D8 RID: 132056 RVA: 0x00926452 File Offset: 0x00924652
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060203D9 RID: 132057 RVA: 0x00926466 File Offset: 0x00924666
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060203DA RID: 132058 RVA: 0x0092647C File Offset: 0x0092467C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingStaticMesh(int EntryPoint)
		{
			BP_FloatingStaticMesh_C.__ExecuteUbergraph_BP_FloatingStaticMesh_FunctionParams* ptr = stackalloc BP_FloatingStaticMesh_C.__ExecuteUbergraph_BP_FloatingStaticMesh_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_FloatingStaticMesh_C.__ExecuteUbergraph_BP_FloatingStaticMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingStaticMesh_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060203DB RID: 132059 RVA: 0x009264C3 File Offset: 0x009246C3
		protected BP_FloatingStaticMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401012A RID: 65834
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh.BP_FloatingStaticMesh_C";

		// Token: 0x0401012B RID: 65835
		private static IntPtr _ClassPtr;

		// Token: 0x0401012C RID: 65836
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401012D RID: 65837
		internal static int __PropertyOffset_0;

		// Token: 0x0401012E RID: 65838
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401012F RID: 65839
		internal static int __PropertyOffset_1;

		// Token: 0x04010130 RID: 65840
		internal static int __PropertyOffset_2;

		// Token: 0x04010131 RID: 65841
		internal static int __PropertyOffset_3;

		// Token: 0x04010132 RID: 65842
		internal static int __PropertyOffset_4;

		// Token: 0x04010133 RID: 65843
		internal static int __PropertyOffset_5;

		// Token: 0x04010134 RID: 65844
		[Nullable(2)]
		private TMap<FName, float> _FloatParameters;

		// Token: 0x04010135 RID: 65845
		internal static int __PropertyOffset_6;

		// Token: 0x04010136 RID: 65846
		[Nullable(2)]
		private TMap<FName, FLinearColor> _ColorParameters;

		// Token: 0x04010137 RID: 65847
		internal static int __PropertyOffset_7;

		// Token: 0x04010138 RID: 65848
		internal static int __PropertyOffset_8;

		// Token: 0x04010139 RID: 65849
		internal static int __PropertyOffset_9;

		// Token: 0x0401013A RID: 65850
		internal static int __PropertyOffset_10;

		// Token: 0x0401013B RID: 65851
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<AActor, FTransformDouble> _ChildActors;

		// Token: 0x0401013C RID: 65852
		internal static int __PropertyOffset_11;

		// Token: 0x0401013D RID: 65853
		[Nullable(2)]
		private TArray<float> _CustomData;

		// Token: 0x0401013E RID: 65854
		internal static int __PropertyOffset_12;

		// Token: 0x0401013F RID: 65855
		internal static int __PropertyOffset_13;

		// Token: 0x04010140 RID: 65856
		internal static int __PropertyOffset_14;

		// Token: 0x04010141 RID: 65857
		internal static int __PropertyOffset_15;

		// Token: 0x04010142 RID: 65858
		internal static int __PropertyOffset_16;

		// Token: 0x04010143 RID: 65859
		private static IntPtr __SetCustomData_NativeFunctionPtr;

		// Token: 0x04010144 RID: 65860
		private static IntPtr __CopyCustomPrimitiveData_NativeFunctionPtr;

		// Token: 0x04010145 RID: 65861
		private static IntPtr __RefreshChildActors_NativeFunctionPtr;

		// Token: 0x04010146 RID: 65862
		private static IntPtr __SetMaterialParams_NativeFunctionPtr;

		// Token: 0x04010147 RID: 65863
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010148 RID: 65864
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010149 RID: 65865
		private static IntPtr __ExecuteUbergraph_BP_FloatingStaticMesh_NativeFunctionPtr;

		// Token: 0x0200997D RID: 39293
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CopyCustomPrimitiveData_FunctionParams
		{
			// Token: 0x04032003 RID: 204803
			[FieldOffset(0)]
			public IntPtr Target;
		}

		// Token: 0x0200997E RID: 39294
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_FloatingStaticMesh_FunctionParams
		{
			// Token: 0x04032004 RID: 204804
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
