using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.GodRay
{
	// Token: 0x02003BF2 RID: 15346
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeLightSouce2D.BP_KuroVolumeLightSouce2D_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1476)]
	public class BP_KuroVolumeLightSouce2D_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022A5C RID: 141916 RVA: 0x0096AC7C File Offset: 0x00968E7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumeLightSouce2D_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeLightSouce2D.BP_KuroVolumeLightSouce2D_C");
			}
			return BP_KuroVolumeLightSouce2D_C._ClassPtr;
		}

		// Token: 0x06022A5D RID: 141917 RVA: 0x0096ACA0 File Offset: 0x00968EA0
		public BP_KuroVolumeLightSouce2D_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeLightSouce2D_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022A5E RID: 141918 RVA: 0x0096ACC8 File Offset: 0x00968EC8
		[NullableContext(1)]
		public BP_KuroVolumeLightSouce2D_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeLightSouce2D_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004201 RID: 16897
		// (get) Token: 0x06022A5F RID: 141919 RVA: 0x0096ACFC File Offset: 0x00968EFC
		// (set) Token: 0x06022A60 RID: 141920 RVA: 0x0096AD35 File Offset: 0x00968F35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004202 RID: 16898
		// (get) Token: 0x06022A61 RID: 141921 RVA: 0x0096AD56 File Offset: 0x00968F56
		// (set) Token: 0x06022A62 RID: 141922 RVA: 0x0096AD6A File Offset: 0x00968F6A
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004203 RID: 16899
		// (get) Token: 0x06022A63 RID: 141923 RVA: 0x0096AD7F File Offset: 0x00968F7F
		// (set) Token: 0x06022A64 RID: 141924 RVA: 0x0096AD93 File Offset: 0x00968F93
		public unsafe USceneComponent RangeRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004204 RID: 16900
		// (get) Token: 0x06022A65 RID: 141925 RVA: 0x0096ADA8 File Offset: 0x00968FA8
		// (set) Token: 0x06022A66 RID: 141926 RVA: 0x0096ADBC File Offset: 0x00968FBC
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004205 RID: 16901
		// (get) Token: 0x06022A67 RID: 141927 RVA: 0x0096ADD1 File Offset: 0x00968FD1
		// (set) Token: 0x06022A68 RID: 141928 RVA: 0x0096ADE5 File Offset: 0x00968FE5
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004206 RID: 16902
		// (get) Token: 0x06022A69 RID: 141929 RVA: 0x0096ADFA File Offset: 0x00968FFA
		// (set) Token: 0x06022A6A RID: 141930 RVA: 0x0096AE0A File Offset: 0x0096900A
		public unsafe int X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004207 RID: 16903
		// (get) Token: 0x06022A6B RID: 141931 RVA: 0x0096AE1B File Offset: 0x0096901B
		// (set) Token: 0x06022A6C RID: 141932 RVA: 0x0096AE2B File Offset: 0x0096902B
		public unsafe int Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004208 RID: 16904
		// (get) Token: 0x06022A6D RID: 141933 RVA: 0x0096AE3C File Offset: 0x0096903C
		// (set) Token: 0x06022A6E RID: 141934 RVA: 0x0096AE4C File Offset: 0x0096904C
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004209 RID: 16905
		// (get) Token: 0x06022A6F RID: 141935 RVA: 0x0096AE5D File Offset: 0x0096905D
		// (set) Token: 0x06022A70 RID: 141936 RVA: 0x0096AE6D File Offset: 0x0096906D
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700420A RID: 16906
		// (get) Token: 0x06022A71 RID: 141937 RVA: 0x0096AE7E File Offset: 0x0096907E
		// (set) Token: 0x06022A72 RID: 141938 RVA: 0x0096AE8E File Offset: 0x0096908E
		public unsafe float Far_Plane
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700420B RID: 16907
		// (get) Token: 0x06022A73 RID: 141939 RVA: 0x0096AE9F File Offset: 0x0096909F
		// (set) Token: 0x06022A74 RID: 141940 RVA: 0x0096AEB3 File Offset: 0x009690B3
		public unsafe UTexture LightSource2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700420C RID: 16908
		// (get) Token: 0x06022A75 RID: 141941 RVA: 0x0096AEC8 File Offset: 0x009690C8
		// (set) Token: 0x06022A76 RID: 141942 RVA: 0x0096AF01 File Offset: 0x00969101
		[Nullable(1)]
		public TArray<AStaticMeshActor> VolumeLightMesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._VolumeLightMesh) == null)
				{
					result = (this._VolumeLightMesh = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.VolumeLightMesh.CopyAssign(value);
			}
		}

		// Token: 0x1700420D RID: 16909
		// (get) Token: 0x06022A77 RID: 141943 RVA: 0x0096AF0F File Offset: 0x0096910F
		// (set) Token: 0x06022A78 RID: 141944 RVA: 0x0096AF23 File Offset: 0x00969123
		public unsafe UMaterialInstance SourceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700420E RID: 16910
		// (get) Token: 0x06022A79 RID: 141945 RVA: 0x0096AF38 File Offset: 0x00969138
		// (set) Token: 0x06022A7A RID: 141946 RVA: 0x0096AF4C File Offset: 0x0096914C
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700420F RID: 16911
		// (get) Token: 0x06022A7B RID: 141947 RVA: 0x0096AF61 File Offset: 0x00969161
		// (set) Token: 0x06022A7C RID: 141948 RVA: 0x0096AF75 File Offset: 0x00969175
		public unsafe UTextureRenderTarget2D LightSource2DPost
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004210 RID: 16912
		// (get) Token: 0x06022A7D RID: 141949 RVA: 0x0096AF8A File Offset: 0x0096918A
		// (set) Token: 0x06022A7E RID: 141950 RVA: 0x0096AF9E File Offset: 0x0096919E
		public unsafe UMaterialInterface PostMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004211 RID: 16913
		// (get) Token: 0x06022A7F RID: 141951 RVA: 0x0096AFB3 File Offset: 0x009691B3
		// (set) Token: 0x06022A80 RID: 141952 RVA: 0x0096AFC7 File Offset: 0x009691C7
		public unsafe UMaterialInstanceDynamic PostMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004212 RID: 16914
		// (get) Token: 0x06022A81 RID: 141953 RVA: 0x0096AFDC File Offset: 0x009691DC
		// (set) Token: 0x06022A82 RID: 141954 RVA: 0x0096AFEC File Offset: 0x009691EC
		public unsafe bool bUseMPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004213 RID: 16915
		// (get) Token: 0x06022A83 RID: 141955 RVA: 0x0096AFFD File Offset: 0x009691FD
		// (set) Token: 0x06022A84 RID: 141956 RVA: 0x0096B00D File Offset: 0x0096920D
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004214 RID: 16916
		// (get) Token: 0x06022A85 RID: 141957 RVA: 0x0096B01E File Offset: 0x0096921E
		// (set) Token: 0x06022A86 RID: 141958 RVA: 0x0096B032 File Offset: 0x00969232
		public unsafe UTextureRenderTarget2D Texture_Render_Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004215 RID: 16917
		// (get) Token: 0x06022A87 RID: 141959 RVA: 0x0096B047 File Offset: 0x00969247
		// (set) Token: 0x06022A88 RID: 141960 RVA: 0x0096B05B File Offset: 0x0096925B
		public unsafe AActor PlaneMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeLightSouce2D_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004216 RID: 16918
		// (get) Token: 0x06022A89 RID: 141961 RVA: 0x0096B070 File Offset: 0x00969270
		// (set) Token: 0x06022A8A RID: 141962 RVA: 0x0096B080 File Offset: 0x00969280
		public unsafe int LastQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeLightSouce2D_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x06022A8B RID: 141963 RVA: 0x0096B091 File Offset: 0x00969291
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateShadingRate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__UpdateShadingRate_NativeFunctionPtr, null);
		}

		// Token: 0x06022A8C RID: 141964 RVA: 0x0096B0A5 File Offset: 0x009692A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePlane()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__UpdatePlane_NativeFunctionPtr, null);
		}

		// Token: 0x06022A8D RID: 141965 RVA: 0x0096B0BC File Offset: 0x009692BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVolumeMeshVisibility(bool bNewVisibility)
		{
			BP_KuroVolumeLightSouce2D_C.__SetVolumeMeshVisibility_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__SetVolumeMeshVisibility_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__SetVolumeMeshVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bNewVisibility = bNewVisibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A8E RID: 141966 RVA: 0x0096B102 File Offset: 0x00969302
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PostProcessTex()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__PostProcessTex_NativeFunctionPtr, null);
		}

		// Token: 0x06022A8F RID: 141967 RVA: 0x0096B116 File Offset: 0x00969316
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__UpdateMat_NativeFunctionPtr, null);
		}

		// Token: 0x06022A90 RID: 141968 RVA: 0x0096B12A File Offset: 0x0096932A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Render()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__Render_NativeFunctionPtr, null);
		}

		// Token: 0x06022A91 RID: 141969 RVA: 0x0096B13E File Offset: 0x0096933E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022A92 RID: 141970 RVA: 0x0096B152 File Offset: 0x00969352
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A93 RID: 141971 RVA: 0x0096B167 File Offset: 0x00969367
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022A94 RID: 141972 RVA: 0x0096B17B File Offset: 0x0096937B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A95 RID: 141973 RVA: 0x0096B190 File Offset: 0x00969390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A96 RID: 141974 RVA: 0x0096B1D8 File Offset: 0x009693D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A97 RID: 141975 RVA: 0x0096B220 File Offset: 0x00969420
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A98 RID: 141976 RVA: 0x0096B268 File Offset: 0x00969468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A99 RID: 141977 RVA: 0x0096B2B0 File Offset: 0x009694B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumeLightSouce2D(int EntryPoint)
		{
			BP_KuroVolumeLightSouce2D_C.__ExecuteUbergraph_BP_KuroVolumeLightSouce2D_FunctionParams* ptr = stackalloc BP_KuroVolumeLightSouce2D_C.__ExecuteUbergraph_BP_KuroVolumeLightSouce2D_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_KuroVolumeLightSouce2D_C.__ExecuteUbergraph_BP_KuroVolumeLightSouce2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeLightSouce2D_C.__ExecuteUbergraph_BP_KuroVolumeLightSouce2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeLightSouce2D_C.__ExecuteUbergraph_BP_KuroVolumeLightSouce2D_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A9A RID: 141978 RVA: 0x0096B2F7 File Offset: 0x009694F7
		protected BP_KuroVolumeLightSouce2D_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040118E7 RID: 71911
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeLightSouce2D.BP_KuroVolumeLightSouce2D_C";

		// Token: 0x040118E8 RID: 71912
		private static IntPtr _ClassPtr;

		// Token: 0x040118E9 RID: 71913
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040118EA RID: 71914
		internal static int __PropertyOffset_0;

		// Token: 0x040118EB RID: 71915
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040118EC RID: 71916
		internal static int __PropertyOffset_1;

		// Token: 0x040118ED RID: 71917
		internal static int __PropertyOffset_2;

		// Token: 0x040118EE RID: 71918
		internal static int __PropertyOffset_3;

		// Token: 0x040118EF RID: 71919
		internal static int __PropertyOffset_4;

		// Token: 0x040118F0 RID: 71920
		internal static int __PropertyOffset_5;

		// Token: 0x040118F1 RID: 71921
		internal static int __PropertyOffset_6;

		// Token: 0x040118F2 RID: 71922
		internal static int __PropertyOffset_7;

		// Token: 0x040118F3 RID: 71923
		internal static int __PropertyOffset_8;

		// Token: 0x040118F4 RID: 71924
		internal static int __PropertyOffset_9;

		// Token: 0x040118F5 RID: 71925
		internal static int __PropertyOffset_10;

		// Token: 0x040118F6 RID: 71926
		internal static int __PropertyOffset_11;

		// Token: 0x040118F7 RID: 71927
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _VolumeLightMesh;

		// Token: 0x040118F8 RID: 71928
		internal static int __PropertyOffset_12;

		// Token: 0x040118F9 RID: 71929
		internal static int __PropertyOffset_13;

		// Token: 0x040118FA RID: 71930
		internal static int __PropertyOffset_14;

		// Token: 0x040118FB RID: 71931
		internal static int __PropertyOffset_15;

		// Token: 0x040118FC RID: 71932
		internal static int __PropertyOffset_16;

		// Token: 0x040118FD RID: 71933
		internal static int __PropertyOffset_17;

		// Token: 0x040118FE RID: 71934
		internal static int __PropertyOffset_18;

		// Token: 0x040118FF RID: 71935
		internal static int __PropertyOffset_19;

		// Token: 0x04011900 RID: 71936
		internal static int __PropertyOffset_20;

		// Token: 0x04011901 RID: 71937
		internal static int __PropertyOffset_21;

		// Token: 0x04011902 RID: 71938
		private static IntPtr __UpdateShadingRate_NativeFunctionPtr;

		// Token: 0x04011903 RID: 71939
		private static IntPtr __UpdatePlane_NativeFunctionPtr;

		// Token: 0x04011904 RID: 71940
		private static IntPtr __SetVolumeMeshVisibility_NativeFunctionPtr;

		// Token: 0x04011905 RID: 71941
		private static IntPtr __PostProcessTex_NativeFunctionPtr;

		// Token: 0x04011906 RID: 71942
		private static IntPtr __UpdateMat_NativeFunctionPtr;

		// Token: 0x04011907 RID: 71943
		private static IntPtr __Render_NativeFunctionPtr;

		// Token: 0x04011908 RID: 71944
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011909 RID: 71945
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401190A RID: 71946
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401190B RID: 71947
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401190C RID: 71948
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumeLightSouce2D_NativeFunctionPtr;

		// Token: 0x02009C02 RID: 39938
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetVolumeMeshVisibility_FunctionParams
		{
			// Token: 0x0403245C RID: 205916
			[FieldOffset(0)]
			public bool bNewVisibility;
		}

		// Token: 0x02009C03 RID: 39939
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403245D RID: 205917
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C04 RID: 39940
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403245E RID: 205918
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C05 RID: 39941
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumeLightSouce2D_FunctionParams
		{
			// Token: 0x0403245F RID: 205919
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
