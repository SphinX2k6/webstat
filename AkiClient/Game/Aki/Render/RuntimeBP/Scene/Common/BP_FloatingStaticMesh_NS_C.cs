using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AD9 RID: 15065
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_NS.BP_FloatingStaticMesh_NS_C")]
	[UnrealStructLayout(2672, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2672)]
	public class BP_FloatingStaticMesh_NS_C : AKuroFloatingStaticMesh, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060203DC RID: 132060 RVA: 0x009264CC File Offset: 0x009246CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingStaticMesh_NS_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_NS.BP_FloatingStaticMesh_NS_C");
			}
			return BP_FloatingStaticMesh_NS_C._ClassPtr;
		}

		// Token: 0x060203DD RID: 132061 RVA: 0x009264F0 File Offset: 0x009246F0
		public BP_FloatingStaticMesh_NS_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_NS_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060203DE RID: 132062 RVA: 0x00926518 File Offset: 0x00924718
		[NullableContext(1)]
		public BP_FloatingStaticMesh_NS_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_NS_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003496 RID: 13462
		// (get) Token: 0x060203DF RID: 132063 RVA: 0x0092654C File Offset: 0x0092474C
		// (set) Token: 0x060203E0 RID: 132064 RVA: 0x00926585 File Offset: 0x00924785
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003497 RID: 13463
		// (get) Token: 0x060203E1 RID: 132065 RVA: 0x009265A6 File Offset: 0x009247A6
		// (set) Token: 0x060203E2 RID: 132066 RVA: 0x009265BA File Offset: 0x009247BA
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003498 RID: 13464
		// (get) Token: 0x060203E3 RID: 132067 RVA: 0x009265CF File Offset: 0x009247CF
		// (set) Token: 0x060203E4 RID: 132068 RVA: 0x009265E3 File Offset: 0x009247E3
		public unsafe UKuroVirtualAttachmentParentComponent KuroVirtualAttachmentParent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVirtualAttachmentParentComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003499 RID: 13465
		// (get) Token: 0x060203E5 RID: 132069 RVA: 0x009265F8 File Offset: 0x009247F8
		// (set) Token: 0x060203E6 RID: 132070 RVA: 0x0092660C File Offset: 0x0092480C
		public unsafe UStaticMeshComponent StaticMeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700349A RID: 13466
		// (get) Token: 0x060203E7 RID: 132071 RVA: 0x00926621 File Offset: 0x00924821
		// (set) Token: 0x060203E8 RID: 132072 RVA: 0x00926635 File Offset: 0x00924835
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700349B RID: 13467
		// (get) Token: 0x060203E9 RID: 132073 RVA: 0x0092664A File Offset: 0x0092484A
		// (set) Token: 0x060203EA RID: 132074 RVA: 0x0092665A File Offset: 0x0092485A
		public unsafe bool 使用材质参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700349C RID: 13468
		// (get) Token: 0x060203EB RID: 132075 RVA: 0x0092666C File Offset: 0x0092486C
		// (set) Token: 0x060203EC RID: 132076 RVA: 0x009266A5 File Offset: 0x009248A5
		[Nullable(1)]
		public TMap<FName, float> FloatParameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700349D RID: 13469
		// (get) Token: 0x060203ED RID: 132077 RVA: 0x009266B4 File Offset: 0x009248B4
		// (set) Token: 0x060203EE RID: 132078 RVA: 0x009266ED File Offset: 0x009248ED
		[Nullable(1)]
		public TMap<FName, FLinearColor> ColorParameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700349E RID: 13470
		// (get) Token: 0x060203EF RID: 132079 RVA: 0x009266FB File Offset: 0x009248FB
		// (set) Token: 0x060203F0 RID: 132080 RVA: 0x0092670F File Offset: 0x0092490F
		public unsafe FLinearColor EmissionDayColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700349F RID: 13471
		// (get) Token: 0x060203F1 RID: 132081 RVA: 0x00926724 File Offset: 0x00924924
		// (set) Token: 0x060203F2 RID: 132082 RVA: 0x00926738 File Offset: 0x00924938
		public unsafe FLinearColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170034A0 RID: 13472
		// (get) Token: 0x060203F3 RID: 132083 RVA: 0x0092674D File Offset: 0x0092494D
		// (set) Token: 0x060203F4 RID: 132084 RVA: 0x0092675D File Offset: 0x0092495D
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034A1 RID: 13473
		// (get) Token: 0x060203F5 RID: 132085 RVA: 0x00926770 File Offset: 0x00924970
		// (set) Token: 0x060203F6 RID: 132086 RVA: 0x009267A9 File Offset: 0x009249A9
		[Nullable(1)]
		public TMap<AActor, FTransformDouble> ChildActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FTransformDouble> result;
				if ((result = this._ChildActors) == null)
				{
					result = (this._ChildActors = new TMap<AActor, FTransformDouble>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ChildActors.CopyAssign(value);
			}
		}

		// Token: 0x170034A2 RID: 13474
		// (get) Token: 0x060203F7 RID: 132087 RVA: 0x009267B8 File Offset: 0x009249B8
		// (set) Token: 0x060203F8 RID: 132088 RVA: 0x009267F1 File Offset: 0x009249F1
		[Nullable(1)]
		public TArray<float> CustomData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TArray<float>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x170034A3 RID: 13475
		// (get) Token: 0x060203F9 RID: 132089 RVA: 0x009267FF File Offset: 0x009249FF
		// (set) Token: 0x060203FA RID: 132090 RVA: 0x0092680F File Offset: 0x00924A0F
		public unsafe bool SpecialBlueprintActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034A4 RID: 13476
		// (get) Token: 0x060203FB RID: 132091 RVA: 0x00926820 File Offset: 0x00924A20
		// (set) Token: 0x060203FC RID: 132092 RVA: 0x00926830 File Offset: 0x00924A30
		public unsafe bool OverrideSuperFarActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034A5 RID: 13477
		// (get) Token: 0x060203FD RID: 132093 RVA: 0x00926841 File Offset: 0x00924A41
		// (set) Token: 0x060203FE RID: 132094 RVA: 0x00926851 File Offset: 0x00924A51
		public unsafe bool HiddenState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_NS_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034A6 RID: 13478
		// (get) Token: 0x060203FF RID: 132095 RVA: 0x00926862 File Offset: 0x00924A62
		// (set) Token: 0x06020400 RID: 132096 RVA: 0x00926876 File Offset: 0x00924A76
		public unsafe UNiagaraSystem NiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_NS_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x06020401 RID: 132097 RVA: 0x0092688B File Offset: 0x00924A8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetCustomData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__SetCustomData_NativeFunctionPtr, null);
		}

		// Token: 0x06020402 RID: 132098 RVA: 0x009268A0 File Offset: 0x00924AA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CopyCustomPrimitiveData(UStaticMeshComponent Target)
		{
			BP_FloatingStaticMesh_NS_C.__CopyCustomPrimitiveData_FunctionParams* ptr = stackalloc BP_FloatingStaticMesh_NS_C.__CopyCustomPrimitiveData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FloatingStaticMesh_NS_C.__CopyCustomPrimitiveData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingStaticMesh_NS_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020403 RID: 132099 RVA: 0x009268F5 File Offset: 0x00924AF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshChildActors()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__RefreshChildActors_NativeFunctionPtr, null);
		}

		// Token: 0x06020404 RID: 132100 RVA: 0x00926909 File Offset: 0x00924B09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__SetMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06020405 RID: 132101 RVA: 0x0092691D File Offset: 0x00924B1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020406 RID: 132102 RVA: 0x00926931 File Offset: 0x00924B31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020407 RID: 132103 RVA: 0x00926946 File Offset: 0x00924B46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020408 RID: 132104 RVA: 0x0092695A File Offset: 0x00924B5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020409 RID: 132105 RVA: 0x00926970 File Offset: 0x00924B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingStaticMesh_NS(int EntryPoint)
		{
			BP_FloatingStaticMesh_NS_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NS_FunctionParams* ptr = stackalloc BP_FloatingStaticMesh_NS_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NS_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_FloatingStaticMesh_NS_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NS_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingStaticMesh_NS_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NS_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_NS_C.__ExecuteUbergraph_BP_FloatingStaticMesh_NS_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602040A RID: 132106 RVA: 0x009269B7 File Offset: 0x00924BB7
		protected BP_FloatingStaticMesh_NS_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401014A RID: 65866
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_NS.BP_FloatingStaticMesh_NS_C";

		// Token: 0x0401014B RID: 65867
		private static IntPtr _ClassPtr;

		// Token: 0x0401014C RID: 65868
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401014D RID: 65869
		internal static int __PropertyOffset_0;

		// Token: 0x0401014E RID: 65870
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401014F RID: 65871
		internal static int __PropertyOffset_1;

		// Token: 0x04010150 RID: 65872
		internal static int __PropertyOffset_2;

		// Token: 0x04010151 RID: 65873
		internal static int __PropertyOffset_3;

		// Token: 0x04010152 RID: 65874
		internal static int __PropertyOffset_4;

		// Token: 0x04010153 RID: 65875
		internal static int __PropertyOffset_5;

		// Token: 0x04010154 RID: 65876
		internal static int __PropertyOffset_6;

		// Token: 0x04010155 RID: 65877
		private TMap<FName, float> _FloatParameters;

		// Token: 0x04010156 RID: 65878
		internal static int __PropertyOffset_7;

		// Token: 0x04010157 RID: 65879
		private TMap<FName, FLinearColor> _ColorParameters;

		// Token: 0x04010158 RID: 65880
		internal static int __PropertyOffset_8;

		// Token: 0x04010159 RID: 65881
		internal static int __PropertyOffset_9;

		// Token: 0x0401015A RID: 65882
		internal static int __PropertyOffset_10;

		// Token: 0x0401015B RID: 65883
		internal static int __PropertyOffset_11;

		// Token: 0x0401015C RID: 65884
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<AActor, FTransformDouble> _ChildActors;

		// Token: 0x0401015D RID: 65885
		internal static int __PropertyOffset_12;

		// Token: 0x0401015E RID: 65886
		private TArray<float> _CustomData;

		// Token: 0x0401015F RID: 65887
		internal static int __PropertyOffset_13;

		// Token: 0x04010160 RID: 65888
		internal static int __PropertyOffset_14;

		// Token: 0x04010161 RID: 65889
		internal static int __PropertyOffset_15;

		// Token: 0x04010162 RID: 65890
		internal static int __PropertyOffset_16;

		// Token: 0x04010163 RID: 65891
		private static IntPtr __SetCustomData_NativeFunctionPtr;

		// Token: 0x04010164 RID: 65892
		private static IntPtr __CopyCustomPrimitiveData_NativeFunctionPtr;

		// Token: 0x04010165 RID: 65893
		private static IntPtr __RefreshChildActors_NativeFunctionPtr;

		// Token: 0x04010166 RID: 65894
		private static IntPtr __SetMaterialParams_NativeFunctionPtr;

		// Token: 0x04010167 RID: 65895
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010168 RID: 65896
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010169 RID: 65897
		private static IntPtr __ExecuteUbergraph_BP_FloatingStaticMesh_NS_NativeFunctionPtr;

		// Token: 0x0200997F RID: 39295
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CopyCustomPrimitiveData_FunctionParams
		{
			// Token: 0x04032005 RID: 204805
			[FieldOffset(0)]
			public IntPtr Target;
		}

		// Token: 0x02009980 RID: 39296
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_FloatingStaticMesh_NS_FunctionParams
		{
			// Token: 0x04032006 RID: 204806
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
