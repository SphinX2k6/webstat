using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.InteractiveLighting
{
	// Token: 0x02003C0A RID: 15370
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis_Instance.BP_SimpleCollisionAxis_Instance_C")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1632)]
	public class BP_SimpleCollisionAxis_Instance_C : AKuroCSSimpleCollisionAxisInstanced, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022E66 RID: 142950 RVA: 0x00972753 File Offset: 0x00970953
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SimpleCollisionAxis_Instance_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis_Instance.BP_SimpleCollisionAxis_Instance_C");
			}
			return BP_SimpleCollisionAxis_Instance_C._ClassPtr;
		}

		// Token: 0x06022E67 RID: 142951 RVA: 0x00972778 File Offset: 0x00970978
		public BP_SimpleCollisionAxis_Instance_C() : this(BuiltinUtils.AllocNativeUObject(BP_SimpleCollisionAxis_Instance_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022E68 RID: 142952 RVA: 0x009727A0 File Offset: 0x009709A0
		[NullableContext(1)]
		public BP_SimpleCollisionAxis_Instance_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SimpleCollisionAxis_Instance_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004357 RID: 17239
		// (get) Token: 0x06022E69 RID: 142953 RVA: 0x009727D4 File Offset: 0x009709D4
		// (set) Token: 0x06022E6A RID: 142954 RVA: 0x0097280D File Offset: 0x00970A0D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004358 RID: 17240
		// (get) Token: 0x06022E6B RID: 142955 RVA: 0x0097282E File Offset: 0x00970A2E
		// (set) Token: 0x06022E6C RID: 142956 RVA: 0x00972842 File Offset: 0x00970A42
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004359 RID: 17241
		// (get) Token: 0x06022E6D RID: 142957 RVA: 0x00972857 File Offset: 0x00970A57
		// (set) Token: 0x06022E6E RID: 142958 RVA: 0x0097286B File Offset: 0x00970A6B
		public unsafe UTextureRenderTarget2D T_Particle_Pivot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700435A RID: 17242
		// (get) Token: 0x06022E6F RID: 142959 RVA: 0x00972880 File Offset: 0x00970A80
		// (set) Token: 0x06022E70 RID: 142960 RVA: 0x00972890 File Offset: 0x00970A90
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700435B RID: 17243
		// (get) Token: 0x06022E71 RID: 142961 RVA: 0x009728A1 File Offset: 0x00970AA1
		// (set) Token: 0x06022E72 RID: 142962 RVA: 0x009728B1 File Offset: 0x00970AB1
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700435C RID: 17244
		// (get) Token: 0x06022E73 RID: 142963 RVA: 0x009728C2 File Offset: 0x00970AC2
		// (set) Token: 0x06022E74 RID: 142964 RVA: 0x009728D6 File Offset: 0x00970AD6
		public unsafe UMaterialInterface CopyTexMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700435D RID: 17245
		// (get) Token: 0x06022E75 RID: 142965 RVA: 0x009728EC File Offset: 0x00970AEC
		// (set) Token: 0x06022E76 RID: 142966 RVA: 0x00972925 File Offset: 0x00970B25
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> RenderMID
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._RenderMID) == null)
				{
					result = (this._RenderMID = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RenderMID.CopyAssign(value);
			}
		}

		// Token: 0x1700435E RID: 17246
		// (get) Token: 0x06022E77 RID: 142967 RVA: 0x00972933 File Offset: 0x00970B33
		// (set) Token: 0x06022E78 RID: 142968 RVA: 0x00972947 File Offset: 0x00970B47
		public unsafe UStaticMesh SM_Ice1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700435F RID: 17247
		// (get) Token: 0x06022E79 RID: 142969 RVA: 0x0097295C File Offset: 0x00970B5C
		// (set) Token: 0x06022E7A RID: 142970 RVA: 0x00972970 File Offset: 0x00970B70
		public unsafe UStaticMesh SM_Ice2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004360 RID: 17248
		// (get) Token: 0x06022E7B RID: 142971 RVA: 0x00972985 File Offset: 0x00970B85
		// (set) Token: 0x06022E7C RID: 142972 RVA: 0x00972999 File Offset: 0x00970B99
		public unsafe UStaticMesh SM_Ice3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004361 RID: 17249
		// (get) Token: 0x06022E7D RID: 142973 RVA: 0x009729AE File Offset: 0x00970BAE
		// (set) Token: 0x06022E7E RID: 142974 RVA: 0x009729C2 File Offset: 0x00970BC2
		public unsafe UTexture2D Input_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004362 RID: 17250
		// (get) Token: 0x06022E7F RID: 142975 RVA: 0x009729D7 File Offset: 0x00970BD7
		// (set) Token: 0x06022E80 RID: 142976 RVA: 0x009729EB File Offset: 0x00970BEB
		public unsafe UTexture2D Input_Texture_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004363 RID: 17251
		// (get) Token: 0x06022E81 RID: 142977 RVA: 0x00972A00 File Offset: 0x00970C00
		// (set) Token: 0x06022E82 RID: 142978 RVA: 0x00972A14 File Offset: 0x00970C14
		public unsafe UTexture2D Input_Texture_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_Instance_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x06022E83 RID: 142979 RVA: 0x00972A29 File Offset: 0x00970C29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 重构ism()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__重构ism_NativeFunctionPtr, null);
		}

		// Token: 0x06022E84 RID: 142980 RVA: 0x00972A3D File Offset: 0x00970C3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 应用贴图材质()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__应用贴图材质_NativeFunctionPtr, null);
		}

		// Token: 0x06022E85 RID: 142981 RVA: 0x00972A51 File Offset: 0x00970C51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022E86 RID: 142982 RVA: 0x00972A65 File Offset: 0x00970C65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E87 RID: 142983 RVA: 0x00972A7A File Offset: 0x00970C7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022E88 RID: 142984 RVA: 0x00972A8E File Offset: 0x00970C8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E89 RID: 142985 RVA: 0x00972AA4 File Offset: 0x00970CA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E8A RID: 142986 RVA: 0x00972AEC File Offset: 0x00970CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E8B RID: 142987 RVA: 0x00972B34 File Offset: 0x00970D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E8C RID: 142988 RVA: 0x00972BF0 File Offset: 0x00970DF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E8D RID: 142989 RVA: 0x00972C7C File Offset: 0x00970E7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InstanceRebuilt(int InstanceCount)
		{
			BP_SimpleCollisionAxis_Instance_C.__InstanceRebuilt_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__InstanceRebuilt_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__InstanceRebuilt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__InstanceRebuilt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstanceCount = InstanceCount;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__InstanceRebuilt_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E8E RID: 142990 RVA: 0x00972CC4 File Offset: 0x00970EC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SimpleCollisionAxis_Instance(int EntryPoint)
		{
			BP_SimpleCollisionAxis_Instance_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_Instance_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(BP_SimpleCollisionAxis_Instance_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_Instance_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_Instance_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E8F RID: 142991 RVA: 0x00972D0E File Offset: 0x00970F0E
		protected BP_SimpleCollisionAxis_Instance_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011B8C RID: 72588
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis_Instance.BP_SimpleCollisionAxis_Instance_C";

		// Token: 0x04011B8D RID: 72589
		private static IntPtr _ClassPtr;

		// Token: 0x04011B8E RID: 72590
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011B8F RID: 72591
		internal static int __PropertyOffset_0;

		// Token: 0x04011B90 RID: 72592
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011B91 RID: 72593
		internal static int __PropertyOffset_1;

		// Token: 0x04011B92 RID: 72594
		internal static int __PropertyOffset_2;

		// Token: 0x04011B93 RID: 72595
		internal static int __PropertyOffset_3;

		// Token: 0x04011B94 RID: 72596
		internal static int __PropertyOffset_4;

		// Token: 0x04011B95 RID: 72597
		internal static int __PropertyOffset_5;

		// Token: 0x04011B96 RID: 72598
		internal static int __PropertyOffset_6;

		// Token: 0x04011B97 RID: 72599
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _RenderMID;

		// Token: 0x04011B98 RID: 72600
		internal static int __PropertyOffset_7;

		// Token: 0x04011B99 RID: 72601
		internal static int __PropertyOffset_8;

		// Token: 0x04011B9A RID: 72602
		internal static int __PropertyOffset_9;

		// Token: 0x04011B9B RID: 72603
		internal static int __PropertyOffset_10;

		// Token: 0x04011B9C RID: 72604
		internal static int __PropertyOffset_11;

		// Token: 0x04011B9D RID: 72605
		internal static int __PropertyOffset_12;

		// Token: 0x04011B9E RID: 72606
		private static IntPtr __重构ism_NativeFunctionPtr;

		// Token: 0x04011B9F RID: 72607
		private static IntPtr __应用贴图材质_NativeFunctionPtr;

		// Token: 0x04011BA0 RID: 72608
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011BA1 RID: 72609
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011BA2 RID: 72610
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011BA3 RID: 72611
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011BA4 RID: 72612
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011BA5 RID: 72613
		private static IntPtr __InstanceRebuilt_NativeFunctionPtr;

		// Token: 0x04011BA6 RID: 72614
		private static IntPtr __ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_NativeFunctionPtr;

		// Token: 0x02009C49 RID: 40009
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324F6 RID: 206070
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C4A RID: 40010
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324F7 RID: 206071
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324F8 RID: 206072
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324F9 RID: 206073
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324FA RID: 206074
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324FB RID: 206075
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324FC RID: 206076
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C4B RID: 40011
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324FD RID: 206077
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324FE RID: 206078
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324FF RID: 206079
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032500 RID: 206080
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C4C RID: 40012
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InstanceRebuilt_FunctionParams
		{
			// Token: 0x04032501 RID: 206081
			[FieldOffset(0)]
			public int InstanceCount;
		}

		// Token: 0x02009C4D RID: 40013
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_BP_SimpleCollisionAxis_Instance_FunctionParams
		{
			// Token: 0x04032502 RID: 206082
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
