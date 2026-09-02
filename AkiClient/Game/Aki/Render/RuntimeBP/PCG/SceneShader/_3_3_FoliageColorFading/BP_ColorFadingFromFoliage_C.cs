using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader._3_3_FoliageColorFading
{
	// Token: 0x02003B86 RID: 15238
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_3_FoliageColorFading/BP_ColorFadingFromFoliage.BP_ColorFadingFromFoliage_C")]
	[UnrealStructLayout(1424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1420)]
	public class BP_ColorFadingFromFoliage_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021B3C RID: 138044 RVA: 0x009507A0 File Offset: 0x0094E9A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ColorFadingFromFoliage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_3_FoliageColorFading/BP_ColorFadingFromFoliage.BP_ColorFadingFromFoliage_C");
			}
			return BP_ColorFadingFromFoliage_C._ClassPtr;
		}

		// Token: 0x06021B3D RID: 138045 RVA: 0x009507C4 File Offset: 0x0094E9C4
		public BP_ColorFadingFromFoliage_C() : this(BuiltinUtils.AllocNativeUObject(BP_ColorFadingFromFoliage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021B3E RID: 138046 RVA: 0x009507EC File Offset: 0x0094E9EC
		[NullableContext(1)]
		public BP_ColorFadingFromFoliage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ColorFadingFromFoliage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C98 RID: 15512
		// (get) Token: 0x06021B3F RID: 138047 RVA: 0x00950820 File Offset: 0x0094EA20
		// (set) Token: 0x06021B40 RID: 138048 RVA: 0x00950859 File Offset: 0x0094EA59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C99 RID: 15513
		// (get) Token: 0x06021B41 RID: 138049 RVA: 0x0095087A File Offset: 0x0094EA7A
		// (set) Token: 0x06021B42 RID: 138050 RVA: 0x0095088E File Offset: 0x0094EA8E
		public unsafe UStaticMeshComponent TranslucentFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C9A RID: 15514
		// (get) Token: 0x06021B43 RID: 138051 RVA: 0x009508A3 File Offset: 0x0094EAA3
		// (set) Token: 0x06021B44 RID: 138052 RVA: 0x009508B7 File Offset: 0x0094EAB7
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C9B RID: 15515
		// (get) Token: 0x06021B45 RID: 138053 RVA: 0x009508CC File Offset: 0x0094EACC
		// (set) Token: 0x06021B46 RID: 138054 RVA: 0x009508E0 File Offset: 0x0094EAE0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C9C RID: 15516
		// (get) Token: 0x06021B47 RID: 138055 RVA: 0x009508F5 File Offset: 0x0094EAF5
		// (set) Token: 0x06021B48 RID: 138056 RVA: 0x00950909 File Offset: 0x0094EB09
		public unsafe UMaterialInstanceDynamic ShapeDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C9D RID: 15517
		// (get) Token: 0x06021B49 RID: 138057 RVA: 0x0095091E File Offset: 0x0094EB1E
		// (set) Token: 0x06021B4A RID: 138058 RVA: 0x00950932 File Offset: 0x0094EB32
		public unsafe UMaterialInstanceDynamic ShapeDMI_ES3_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003C9E RID: 15518
		// (get) Token: 0x06021B4B RID: 138059 RVA: 0x00950947 File Offset: 0x0094EB47
		// (set) Token: 0x06021B4C RID: 138060 RVA: 0x00950957 File Offset: 0x0094EB57
		public unsafe bool Is_ES3_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C9F RID: 15519
		// (get) Token: 0x06021B4D RID: 138061 RVA: 0x00950968 File Offset: 0x0094EB68
		// (set) Token: 0x06021B4E RID: 138062 RVA: 0x0095097C File Offset: 0x0094EB7C
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003CA0 RID: 15520
		// (get) Token: 0x06021B4F RID: 138063 RVA: 0x00950991 File Offset: 0x0094EB91
		// (set) Token: 0x06021B50 RID: 138064 RVA: 0x009509A1 File Offset: 0x0094EBA1
		public unsafe bool Unused_Fogging
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CA1 RID: 15521
		// (get) Token: 0x06021B51 RID: 138065 RVA: 0x009509B2 File Offset: 0x0094EBB2
		// (set) Token: 0x06021B52 RID: 138066 RVA: 0x009509C6 File Offset: 0x0094EBC6
		public unsafe UStaticMesh TranslucentFoliageMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003CA2 RID: 15522
		// (get) Token: 0x06021B53 RID: 138067 RVA: 0x009509DB File Offset: 0x0094EBDB
		// (set) Token: 0x06021B54 RID: 138068 RVA: 0x009509EF File Offset: 0x0094EBEF
		public unsafe UMaterialInstance TranslucentFoliageMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003CA3 RID: 15523
		// (get) Token: 0x06021B55 RID: 138069 RVA: 0x00950A04 File Offset: 0x0094EC04
		// (set) Token: 0x06021B56 RID: 138070 RVA: 0x00950A18 File Offset: 0x0094EC18
		public unsafe UMaterialInstance TranslucentFoliageMaterial_LOD1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorFadingFromFoliage_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003CA4 RID: 15524
		// (get) Token: 0x06021B57 RID: 138071 RVA: 0x00950A2D File Offset: 0x0094EC2D
		// (set) Token: 0x06021B58 RID: 138072 RVA: 0x00950A3D File Offset: 0x0094EC3D
		public unsafe float SphereMeshScale_Mobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003CA5 RID: 15525
		// (get) Token: 0x06021B59 RID: 138073 RVA: 0x00950A4E File Offset: 0x0094EC4E
		// (set) Token: 0x06021B5A RID: 138074 RVA: 0x00950A5E File Offset: 0x0094EC5E
		public unsafe float SphereMeshScale_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003CA6 RID: 15526
		// (get) Token: 0x06021B5B RID: 138075 RVA: 0x00950A6F File Offset: 0x0094EC6F
		// (set) Token: 0x06021B5C RID: 138076 RVA: 0x00950A7F File Offset: 0x0094EC7F
		public unsafe float SphereMeshScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorFadingFromFoliage_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x06021B5D RID: 138077 RVA: 0x00950A90 File Offset: 0x0094EC90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set__TranslucentFoliageMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__Set__TranslucentFoliageMesh_NativeFunctionPtr, null);
		}

		// Token: 0x06021B5E RID: 138078 RVA: 0x00950AA4 File Offset: 0x0094ECA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__Is_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x06021B5F RID: 138079 RVA: 0x00950AB8 File Offset: 0x0094ECB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_TranslusentSphereMaterial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__Set_TranslusentSphereMaterial_NativeFunctionPtr, null);
		}

		// Token: 0x06021B60 RID: 138080 RVA: 0x00950ACC File Offset: 0x0094ECCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021B61 RID: 138081 RVA: 0x00950AE0 File Offset: 0x0094ECE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B62 RID: 138082 RVA: 0x00950AF5 File Offset: 0x0094ECF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021B63 RID: 138083 RVA: 0x00950B09 File Offset: 0x0094ED09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B64 RID: 138084 RVA: 0x00950B20 File Offset: 0x0094ED20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorFadingFromFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B65 RID: 138085 RVA: 0x00950B68 File Offset: 0x0094ED68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorFadingFromFoliage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorFadingFromFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B66 RID: 138086 RVA: 0x00950BB0 File Offset: 0x0094EDB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorFadingFromFoliage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B67 RID: 138087 RVA: 0x00950BF8 File Offset: 0x0094EDF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorFadingFromFoliage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorFadingFromFoliage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B68 RID: 138088 RVA: 0x00950C40 File Offset: 0x0094EE40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ColorFadingFromFoliage(int EntryPoint)
		{
			BP_ColorFadingFromFoliage_C.__ExecuteUbergraph_BP_ColorFadingFromFoliage_FunctionParams* ptr = stackalloc BP_ColorFadingFromFoliage_C.__ExecuteUbergraph_BP_ColorFadingFromFoliage_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_ColorFadingFromFoliage_C.__ExecuteUbergraph_BP_ColorFadingFromFoliage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorFadingFromFoliage_C.__ExecuteUbergraph_BP_ColorFadingFromFoliage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorFadingFromFoliage_C.__ExecuteUbergraph_BP_ColorFadingFromFoliage_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B69 RID: 138089 RVA: 0x00950C87 File Offset: 0x0094EE87
		protected BP_ColorFadingFromFoliage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010FDF RID: 69599
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_3_FoliageColorFading/BP_ColorFadingFromFoliage.BP_ColorFadingFromFoliage_C";

		// Token: 0x04010FE0 RID: 69600
		private static IntPtr _ClassPtr;

		// Token: 0x04010FE1 RID: 69601
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010FE2 RID: 69602
		internal static int __PropertyOffset_0;

		// Token: 0x04010FE3 RID: 69603
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010FE4 RID: 69604
		internal static int __PropertyOffset_1;

		// Token: 0x04010FE5 RID: 69605
		internal static int __PropertyOffset_2;

		// Token: 0x04010FE6 RID: 69606
		internal static int __PropertyOffset_3;

		// Token: 0x04010FE7 RID: 69607
		internal static int __PropertyOffset_4;

		// Token: 0x04010FE8 RID: 69608
		internal static int __PropertyOffset_5;

		// Token: 0x04010FE9 RID: 69609
		internal static int __PropertyOffset_6;

		// Token: 0x04010FEA RID: 69610
		internal static int __PropertyOffset_7;

		// Token: 0x04010FEB RID: 69611
		internal static int __PropertyOffset_8;

		// Token: 0x04010FEC RID: 69612
		internal static int __PropertyOffset_9;

		// Token: 0x04010FED RID: 69613
		internal static int __PropertyOffset_10;

		// Token: 0x04010FEE RID: 69614
		internal static int __PropertyOffset_11;

		// Token: 0x04010FEF RID: 69615
		internal static int __PropertyOffset_12;

		// Token: 0x04010FF0 RID: 69616
		internal static int __PropertyOffset_13;

		// Token: 0x04010FF1 RID: 69617
		internal static int __PropertyOffset_14;

		// Token: 0x04010FF2 RID: 69618
		private static IntPtr __Set__TranslucentFoliageMesh_NativeFunctionPtr;

		// Token: 0x04010FF3 RID: 69619
		private static IntPtr __Is_ES3_NativeFunctionPtr;

		// Token: 0x04010FF4 RID: 69620
		private static IntPtr __Set_TranslusentSphereMaterial_NativeFunctionPtr;

		// Token: 0x04010FF5 RID: 69621
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010FF6 RID: 69622
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010FF7 RID: 69623
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010FF8 RID: 69624
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010FF9 RID: 69625
		private static IntPtr __ExecuteUbergraph_BP_ColorFadingFromFoliage_NativeFunctionPtr;

		// Token: 0x02009B1D RID: 39709
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322D5 RID: 205525
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B1E RID: 39710
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322D6 RID: 205526
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B1F RID: 39711
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_ColorFadingFromFoliage_FunctionParams
		{
			// Token: 0x040322D7 RID: 205527
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
