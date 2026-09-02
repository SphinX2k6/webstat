using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneCapturePlay
{
	// Token: 0x02003B33 RID: 15155
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneCapturePlay/BP_SceneCapture_Play.BP_SceneCapture_Play_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class BP_SceneCapture_Play_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020B41 RID: 133953 RVA: 0x00934910 File Offset: 0x00932B10
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneCapture_Play_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneCapturePlay/BP_SceneCapture_Play.BP_SceneCapture_Play_C");
			}
			return BP_SceneCapture_Play_C._ClassPtr;
		}

		// Token: 0x06020B42 RID: 133954 RVA: 0x00934934 File Offset: 0x00932B34
		public BP_SceneCapture_Play_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneCapture_Play_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020B43 RID: 133955 RVA: 0x0093495C File Offset: 0x00932B5C
		[NullableContext(1)]
		public BP_SceneCapture_Play_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneCapture_Play_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036C7 RID: 14023
		// (get) Token: 0x06020B44 RID: 133956 RVA: 0x00934990 File Offset: 0x00932B90
		// (set) Token: 0x06020B45 RID: 133957 RVA: 0x009349C9 File Offset: 0x00932BC9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036C8 RID: 14024
		// (get) Token: 0x06020B46 RID: 133958 RVA: 0x009349EA File Offset: 0x00932BEA
		// (set) Token: 0x06020B47 RID: 133959 RVA: 0x009349FE File Offset: 0x00932BFE
		public unsafe UStaticMeshComponent BottomLeft
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036C9 RID: 14025
		// (get) Token: 0x06020B48 RID: 133960 RVA: 0x00934A13 File Offset: 0x00932C13
		// (set) Token: 0x06020B49 RID: 133961 RVA: 0x00934A27 File Offset: 0x00932C27
		public unsafe UStaticMeshComponent BottomRight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036CA RID: 14026
		// (get) Token: 0x06020B4A RID: 133962 RVA: 0x00934A3C File Offset: 0x00932C3C
		// (set) Token: 0x06020B4B RID: 133963 RVA: 0x00934A50 File Offset: 0x00932C50
		public unsafe UStaticMeshComponent TopRight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170036CB RID: 14027
		// (get) Token: 0x06020B4C RID: 133964 RVA: 0x00934A65 File Offset: 0x00932C65
		// (set) Token: 0x06020B4D RID: 133965 RVA: 0x00934A79 File Offset: 0x00932C79
		public unsafe UStaticMeshComponent TopLeft
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170036CC RID: 14028
		// (get) Token: 0x06020B4E RID: 133966 RVA: 0x00934A8E File Offset: 0x00932C8E
		// (set) Token: 0x06020B4F RID: 133967 RVA: 0x00934AA2 File Offset: 0x00932CA2
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170036CD RID: 14029
		// (get) Token: 0x06020B50 RID: 133968 RVA: 0x00934AB7 File Offset: 0x00932CB7
		// (set) Token: 0x06020B51 RID: 133969 RVA: 0x00934ACB File Offset: 0x00932CCB
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170036CE RID: 14030
		// (get) Token: 0x06020B52 RID: 133970 RVA: 0x00934AE0 File Offset: 0x00932CE0
		// (set) Token: 0x06020B53 RID: 133971 RVA: 0x00934AF4 File Offset: 0x00932CF4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170036CF RID: 14031
		// (get) Token: 0x06020B54 RID: 133972 RVA: 0x00934B0C File Offset: 0x00932D0C
		// (set) Token: 0x06020B55 RID: 133973 RVA: 0x00934B45 File Offset: 0x00932D45
		[Nullable(1)]
		public TArray<AActor> HiddenActor
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._HiddenActor) == null)
				{
					result = (this._HiddenActor = new TArray<AActor>(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.HiddenActor.CopyAssign(value);
			}
		}

		// Token: 0x170036D0 RID: 14032
		// (get) Token: 0x06020B56 RID: 133974 RVA: 0x00934B54 File Offset: 0x00932D54
		// (set) Token: 0x06020B57 RID: 133975 RVA: 0x00934B8D File Offset: 0x00932D8D
		[Nullable(1)]
		public TArray<AActor> ActorPosition
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ActorPosition) == null)
				{
					result = (this._ActorPosition = new TArray<AActor>(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ActorPosition.CopyAssign(value);
			}
		}

		// Token: 0x170036D1 RID: 14033
		// (get) Token: 0x06020B58 RID: 133976 RVA: 0x00934B9B File Offset: 0x00932D9B
		// (set) Token: 0x06020B59 RID: 133977 RVA: 0x00934BAB File Offset: 0x00932DAB
		public unsafe bool Capture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170036D2 RID: 14034
		// (get) Token: 0x06020B5A RID: 133978 RVA: 0x00934BBC File Offset: 0x00932DBC
		// (set) Token: 0x06020B5B RID: 133979 RVA: 0x00934BCC File Offset: 0x00932DCC
		public unsafe float FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170036D3 RID: 14035
		// (get) Token: 0x06020B5C RID: 133980 RVA: 0x00934BDD File Offset: 0x00932DDD
		// (set) Token: 0x06020B5D RID: 133981 RVA: 0x00934BED File Offset: 0x00932DED
		public unsafe bool UIToSceneMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170036D4 RID: 14036
		// (get) Token: 0x06020B5E RID: 133982 RVA: 0x00934BFE File Offset: 0x00932DFE
		// (set) Token: 0x06020B5F RID: 133983 RVA: 0x00934C12 File Offset: 0x00932E12
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170036D5 RID: 14037
		// (get) Token: 0x06020B60 RID: 133984 RVA: 0x00934C27 File Offset: 0x00932E27
		// (set) Token: 0x06020B61 RID: 133985 RVA: 0x00934C3B File Offset: 0x00932E3B
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170036D6 RID: 14038
		// (get) Token: 0x06020B62 RID: 133986 RVA: 0x00934C50 File Offset: 0x00932E50
		// (set) Token: 0x06020B63 RID: 133987 RVA: 0x00934C60 File Offset: 0x00932E60
		public unsafe float Scale_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170036D7 RID: 14039
		// (get) Token: 0x06020B64 RID: 133988 RVA: 0x00934C71 File Offset: 0x00932E71
		// (set) Token: 0x06020B65 RID: 133989 RVA: 0x00934C81 File Offset: 0x00932E81
		public unsafe float Scale_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170036D8 RID: 14040
		// (get) Token: 0x06020B66 RID: 133990 RVA: 0x00934C92 File Offset: 0x00932E92
		// (set) Token: 0x06020B67 RID: 133991 RVA: 0x00934CA2 File Offset: 0x00932EA2
		public unsafe float Offset_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170036D9 RID: 14041
		// (get) Token: 0x06020B68 RID: 133992 RVA: 0x00934CB3 File Offset: 0x00932EB3
		// (set) Token: 0x06020B69 RID: 133993 RVA: 0x00934CC3 File Offset: 0x00932EC3
		public unsafe float Offset_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170036DA RID: 14042
		// (get) Token: 0x06020B6A RID: 133994 RVA: 0x00934CD4 File Offset: 0x00932ED4
		// (set) Token: 0x06020B6B RID: 133995 RVA: 0x00934CE8 File Offset: 0x00932EE8
		public unsafe UTexture2D UVToSceneTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170036DB RID: 14043
		// (get) Token: 0x06020B6C RID: 133996 RVA: 0x00934CFD File Offset: 0x00932EFD
		// (set) Token: 0x06020B6D RID: 133997 RVA: 0x00934D11 File Offset: 0x00932F11
		public unsafe FVector CameraLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170036DC RID: 14044
		// (get) Token: 0x06020B6E RID: 133998 RVA: 0x00934D26 File Offset: 0x00932F26
		// (set) Token: 0x06020B6F RID: 133999 RVA: 0x00934D3A File Offset: 0x00932F3A
		public unsafe FRotator CameraRotarion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170036DD RID: 14045
		// (get) Token: 0x06020B70 RID: 134000 RVA: 0x00934D4F File Offset: 0x00932F4F
		// (set) Token: 0x06020B71 RID: 134001 RVA: 0x00934D5F File Offset: 0x00932F5F
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_Play_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170036DE RID: 14046
		// (get) Token: 0x06020B72 RID: 134002 RVA: 0x00934D70 File Offset: 0x00932F70
		// (set) Token: 0x06020B73 RID: 134003 RVA: 0x00934D84 File Offset: 0x00932F84
		public unsafe UMaterialInstanceDynamic DynamicMaterial_SceneCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_Play_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x06020B74 RID: 134004 RVA: 0x00934D99 File Offset: 0x00932F99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Editor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__Editor_NativeFunctionPtr, null);
		}

		// Token: 0x06020B75 RID: 134005 RVA: 0x00934DAD File Offset: 0x00932FAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void runtime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__runtime_NativeFunctionPtr, null);
		}

		// Token: 0x06020B76 RID: 134006 RVA: 0x00934DC1 File Offset: 0x00932FC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020B77 RID: 134007 RVA: 0x00934DD5 File Offset: 0x00932FD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_Play_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B78 RID: 134008 RVA: 0x00934DEA File Offset: 0x00932FEA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020B79 RID: 134009 RVA: 0x00934DFE File Offset: 0x00932FFE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_Play_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B7A RID: 134010 RVA: 0x00934E14 File Offset: 0x00933014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_Play_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020B7B RID: 134011 RVA: 0x00934E5C File Offset: 0x0093305C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_Play_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_Play_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_Play_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B7C RID: 134012 RVA: 0x00934EA4 File Offset: 0x009330A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SceneCapture_Play_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneCapture_Play_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_Play_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_Play_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_Play_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020B7D RID: 134013 RVA: 0x00934EEC File Offset: 0x009330EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SceneCapture_Play_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneCapture_Play_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_Play_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_Play_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_Play_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B7E RID: 134014 RVA: 0x00934F34 File Offset: 0x00933134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneCapture_Play(int EntryPoint)
		{
			BP_SceneCapture_Play_C.__ExecuteUbergraph_BP_SceneCapture_Play_FunctionParams* ptr = stackalloc BP_SceneCapture_Play_C.__ExecuteUbergraph_BP_SceneCapture_Play_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_SceneCapture_Play_C.__ExecuteUbergraph_BP_SceneCapture_Play_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_Play_C.__ExecuteUbergraph_BP_SceneCapture_Play_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_Play_C.__ExecuteUbergraph_BP_SceneCapture_Play_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B7F RID: 134015 RVA: 0x00934F7E File Offset: 0x0093317E
		protected BP_SceneCapture_Play_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010627 RID: 67111
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneCapturePlay/BP_SceneCapture_Play.BP_SceneCapture_Play_C";

		// Token: 0x04010628 RID: 67112
		private static IntPtr _ClassPtr;

		// Token: 0x04010629 RID: 67113
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401062A RID: 67114
		internal static int __PropertyOffset_0;

		// Token: 0x0401062B RID: 67115
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401062C RID: 67116
		internal static int __PropertyOffset_1;

		// Token: 0x0401062D RID: 67117
		internal static int __PropertyOffset_2;

		// Token: 0x0401062E RID: 67118
		internal static int __PropertyOffset_3;

		// Token: 0x0401062F RID: 67119
		internal static int __PropertyOffset_4;

		// Token: 0x04010630 RID: 67120
		internal static int __PropertyOffset_5;

		// Token: 0x04010631 RID: 67121
		internal static int __PropertyOffset_6;

		// Token: 0x04010632 RID: 67122
		internal static int __PropertyOffset_7;

		// Token: 0x04010633 RID: 67123
		internal static int __PropertyOffset_8;

		// Token: 0x04010634 RID: 67124
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _HiddenActor;

		// Token: 0x04010635 RID: 67125
		internal static int __PropertyOffset_9;

		// Token: 0x04010636 RID: 67126
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ActorPosition;

		// Token: 0x04010637 RID: 67127
		internal static int __PropertyOffset_10;

		// Token: 0x04010638 RID: 67128
		internal static int __PropertyOffset_11;

		// Token: 0x04010639 RID: 67129
		internal static int __PropertyOffset_12;

		// Token: 0x0401063A RID: 67130
		internal static int __PropertyOffset_13;

		// Token: 0x0401063B RID: 67131
		internal static int __PropertyOffset_14;

		// Token: 0x0401063C RID: 67132
		internal static int __PropertyOffset_15;

		// Token: 0x0401063D RID: 67133
		internal static int __PropertyOffset_16;

		// Token: 0x0401063E RID: 67134
		internal static int __PropertyOffset_17;

		// Token: 0x0401063F RID: 67135
		internal static int __PropertyOffset_18;

		// Token: 0x04010640 RID: 67136
		internal static int __PropertyOffset_19;

		// Token: 0x04010641 RID: 67137
		internal static int __PropertyOffset_20;

		// Token: 0x04010642 RID: 67138
		internal static int __PropertyOffset_21;

		// Token: 0x04010643 RID: 67139
		internal static int __PropertyOffset_22;

		// Token: 0x04010644 RID: 67140
		internal static int __PropertyOffset_23;

		// Token: 0x04010645 RID: 67141
		private static IntPtr __Editor_NativeFunctionPtr;

		// Token: 0x04010646 RID: 67142
		private static IntPtr __runtime_NativeFunctionPtr;

		// Token: 0x04010647 RID: 67143
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010648 RID: 67144
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010649 RID: 67145
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401064A RID: 67146
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401064B RID: 67147
		private static IntPtr __ExecuteUbergraph_BP_SceneCapture_Play_NativeFunctionPtr;

		// Token: 0x02009A1B RID: 39451
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032109 RID: 205065
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A1C RID: 39452
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403210A RID: 205066
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A1D RID: 39453
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_SceneCapture_Play_FunctionParams
		{
			// Token: 0x0403210B RID: 205067
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
