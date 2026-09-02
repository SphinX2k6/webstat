using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.LifePlay
{
	// Token: 0x02003AB2 RID: 15026
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/LifePlay/BP_SceneLifePlay.BP_SceneLifePlay_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1473)]
	public class BP_SceneLifePlay_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602009E RID: 131230 RVA: 0x009208E8 File Offset: 0x0091EAE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneLifePlay_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/LifePlay/BP_SceneLifePlay.BP_SceneLifePlay_C");
			}
			return BP_SceneLifePlay_C._ClassPtr;
		}

		// Token: 0x0602009F RID: 131231 RVA: 0x0092090C File Offset: 0x0091EB0C
		public BP_SceneLifePlay_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneLifePlay_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060200A0 RID: 131232 RVA: 0x00920934 File Offset: 0x0091EB34
		[NullableContext(1)]
		public BP_SceneLifePlay_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneLifePlay_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700339C RID: 13212
		// (get) Token: 0x060200A1 RID: 131233 RVA: 0x00920968 File Offset: 0x0091EB68
		// (set) Token: 0x060200A2 RID: 131234 RVA: 0x009209A1 File Offset: 0x0091EBA1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700339D RID: 13213
		// (get) Token: 0x060200A3 RID: 131235 RVA: 0x009209C2 File Offset: 0x0091EBC2
		// (set) Token: 0x060200A4 RID: 131236 RVA: 0x009209D6 File Offset: 0x0091EBD6
		public unsafe UTextRenderComponent TextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700339E RID: 13214
		// (get) Token: 0x060200A5 RID: 131237 RVA: 0x009209EB File Offset: 0x0091EBEB
		// (set) Token: 0x060200A6 RID: 131238 RVA: 0x009209FF File Offset: 0x0091EBFF
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700339F RID: 13215
		// (get) Token: 0x060200A7 RID: 131239 RVA: 0x00920A14 File Offset: 0x0091EC14
		// (set) Token: 0x060200A8 RID: 131240 RVA: 0x00920A28 File Offset: 0x0091EC28
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170033A0 RID: 13216
		// (get) Token: 0x060200A9 RID: 131241 RVA: 0x00920A3D File Offset: 0x0091EC3D
		// (set) Token: 0x060200AA RID: 131242 RVA: 0x00920A51 File Offset: 0x0091EC51
		public unsafe UMaterialInstanceDynamic ShapeDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170033A1 RID: 13217
		// (get) Token: 0x060200AB RID: 131243 RVA: 0x00920A66 File Offset: 0x0091EC66
		// (set) Token: 0x060200AC RID: 131244 RVA: 0x00920A76 File Offset: 0x0091EC76
		public unsafe bool Open_LifePlay_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033A2 RID: 13218
		// (get) Token: 0x060200AD RID: 131245 RVA: 0x00920A87 File Offset: 0x0091EC87
		// (set) Token: 0x060200AE RID: 131246 RVA: 0x00920A9B File Offset: 0x0091EC9B
		public unsafe UMaterialInstanceDynamic ShapeDMI_ES3_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170033A3 RID: 13219
		// (get) Token: 0x060200AF RID: 131247 RVA: 0x00920AB0 File Offset: 0x0091ECB0
		// (set) Token: 0x060200B0 RID: 131248 RVA: 0x00920AC4 File Offset: 0x0091ECC4
		public unsafe FLinearColor Set_ParameterCollection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170033A4 RID: 13220
		// (get) Token: 0x060200B1 RID: 131249 RVA: 0x00920AD9 File Offset: 0x0091ECD9
		// (set) Token: 0x060200B2 RID: 131250 RVA: 0x00920AED File Offset: 0x0091ECED
		public unsafe UStaticMesh LifePlay_Sphere_Back
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170033A5 RID: 13221
		// (get) Token: 0x060200B3 RID: 131251 RVA: 0x00920B02 File Offset: 0x0091ED02
		// (set) Token: 0x060200B4 RID: 131252 RVA: 0x00920B12 File Offset: 0x0091ED12
		public unsafe float OuterRing_ShapeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170033A6 RID: 13222
		// (get) Token: 0x060200B5 RID: 131253 RVA: 0x00920B23 File Offset: 0x0091ED23
		// (set) Token: 0x060200B6 RID: 131254 RVA: 0x00920B33 File Offset: 0x0091ED33
		public unsafe float InternalRing_ColorChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170033A7 RID: 13223
		// (get) Token: 0x060200B7 RID: 131255 RVA: 0x00920B44 File Offset: 0x0091ED44
		// (set) Token: 0x060200B8 RID: 131256 RVA: 0x00920B54 File Offset: 0x0091ED54
		public unsafe float PlantGrowRing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170033A8 RID: 13224
		// (get) Token: 0x060200B9 RID: 131257 RVA: 0x00920B65 File Offset: 0x0091ED65
		// (set) Token: 0x060200BA RID: 131258 RVA: 0x00920B75 File Offset: 0x0091ED75
		public unsafe float Leaf_Grow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170033A9 RID: 13225
		// (get) Token: 0x060200BB RID: 131259 RVA: 0x00920B86 File Offset: 0x0091ED86
		// (set) Token: 0x060200BC RID: 131260 RVA: 0x00920B9A File Offset: 0x0091ED9A
		public unsafe FLinearColor SceneColorOverlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170033AA RID: 13226
		// (get) Token: 0x060200BD RID: 131261 RVA: 0x00920BAF File Offset: 0x0091EDAF
		// (set) Token: 0x060200BE RID: 131262 RVA: 0x00920BC3 File Offset: 0x0091EDC3
		public unsafe UStaticMesh LifePlay_Sphere_Fornt
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170033AB RID: 13227
		// (get) Token: 0x060200BF RID: 131263 RVA: 0x00920BD8 File Offset: 0x0091EDD8
		// (set) Token: 0x060200C0 RID: 131264 RVA: 0x00920BEC File Offset: 0x0091EDEC
		public unsafe FVectorDouble WorldCameraLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170033AC RID: 13228
		// (get) Token: 0x060200C1 RID: 131265 RVA: 0x00920C01 File Offset: 0x0091EE01
		// (set) Token: 0x060200C2 RID: 131266 RVA: 0x00920C11 File Offset: 0x0091EE11
		public unsafe bool Is_ES3_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033AD RID: 13229
		// (get) Token: 0x060200C3 RID: 131267 RVA: 0x00920C22 File Offset: 0x0091EE22
		// (set) Token: 0x060200C4 RID: 131268 RVA: 0x00920C36 File Offset: 0x0091EE36
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLifePlay_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170033AE RID: 13230
		// (get) Token: 0x060200C5 RID: 131269 RVA: 0x00920C4B File Offset: 0x0091EE4B
		// (set) Token: 0x060200C6 RID: 131270 RVA: 0x00920C5B File Offset: 0x0091EE5B
		public unsafe bool Unused_Fogging
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLifePlay_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x060200C7 RID: 131271 RVA: 0x00920C6C File Offset: 0x0091EE6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__Is_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x060200C8 RID: 131272 RVA: 0x00920C80 File Offset: 0x0091EE80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_MaterialInstance()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__Set_MaterialInstance_NativeFunctionPtr, null);
		}

		// Token: 0x060200C9 RID: 131273 RVA: 0x00920C94 File Offset: 0x0091EE94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Life_Play_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__Set_Life_Play_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x060200CA RID: 131274 RVA: 0x00920CA8 File Offset: 0x0091EEA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060200CB RID: 131275 RVA: 0x00920CBC File Offset: 0x0091EEBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLifePlay_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060200CC RID: 131276 RVA: 0x00920CD1 File Offset: 0x0091EED1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060200CD RID: 131277 RVA: 0x00920CE5 File Offset: 0x0091EEE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLifePlay_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060200CE RID: 131278 RVA: 0x00920CFC File Offset: 0x0091EEFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneLifePlay_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneLifePlay_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLifePlay_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLifePlay_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060200CF RID: 131279 RVA: 0x00920D44 File Offset: 0x0091EF44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneLifePlay_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneLifePlay_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLifePlay_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLifePlay_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLifePlay_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060200D0 RID: 131280 RVA: 0x00920D8C File Offset: 0x0091EF8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SceneLifePlay_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneLifePlay_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLifePlay_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLifePlay_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLifePlay_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060200D1 RID: 131281 RVA: 0x00920DD4 File Offset: 0x0091EFD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SceneLifePlay_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneLifePlay_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLifePlay_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLifePlay_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLifePlay_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060200D2 RID: 131282 RVA: 0x00920E1C File Offset: 0x0091F01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneLifePlay(int EntryPoint)
		{
			BP_SceneLifePlay_C.__ExecuteUbergraph_BP_SceneLifePlay_FunctionParams* ptr = stackalloc BP_SceneLifePlay_C.__ExecuteUbergraph_BP_SceneLifePlay_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneLifePlay_C.__ExecuteUbergraph_BP_SceneLifePlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLifePlay_C.__ExecuteUbergraph_BP_SceneLifePlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLifePlay_C.__ExecuteUbergraph_BP_SceneLifePlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060200D3 RID: 131283 RVA: 0x00920E63 File Offset: 0x0091F063
		protected BP_SceneLifePlay_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF53 RID: 65363
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/LifePlay/BP_SceneLifePlay.BP_SceneLifePlay_C";

		// Token: 0x0400FF54 RID: 65364
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF55 RID: 65365
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF56 RID: 65366
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF57 RID: 65367
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF58 RID: 65368
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF59 RID: 65369
		internal static int __PropertyOffset_2;

		// Token: 0x0400FF5A RID: 65370
		internal static int __PropertyOffset_3;

		// Token: 0x0400FF5B RID: 65371
		internal static int __PropertyOffset_4;

		// Token: 0x0400FF5C RID: 65372
		internal static int __PropertyOffset_5;

		// Token: 0x0400FF5D RID: 65373
		internal static int __PropertyOffset_6;

		// Token: 0x0400FF5E RID: 65374
		internal static int __PropertyOffset_7;

		// Token: 0x0400FF5F RID: 65375
		internal static int __PropertyOffset_8;

		// Token: 0x0400FF60 RID: 65376
		internal static int __PropertyOffset_9;

		// Token: 0x0400FF61 RID: 65377
		internal static int __PropertyOffset_10;

		// Token: 0x0400FF62 RID: 65378
		internal static int __PropertyOffset_11;

		// Token: 0x0400FF63 RID: 65379
		internal static int __PropertyOffset_12;

		// Token: 0x0400FF64 RID: 65380
		internal static int __PropertyOffset_13;

		// Token: 0x0400FF65 RID: 65381
		internal static int __PropertyOffset_14;

		// Token: 0x0400FF66 RID: 65382
		internal static int __PropertyOffset_15;

		// Token: 0x0400FF67 RID: 65383
		internal static int __PropertyOffset_16;

		// Token: 0x0400FF68 RID: 65384
		internal static int __PropertyOffset_17;

		// Token: 0x0400FF69 RID: 65385
		internal static int __PropertyOffset_18;

		// Token: 0x0400FF6A RID: 65386
		private static IntPtr __Is_ES3_NativeFunctionPtr;

		// Token: 0x0400FF6B RID: 65387
		private static IntPtr __Set_MaterialInstance_NativeFunctionPtr;

		// Token: 0x0400FF6C RID: 65388
		private static IntPtr __Set_Life_Play_Parameter_NativeFunctionPtr;

		// Token: 0x0400FF6D RID: 65389
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FF6E RID: 65390
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FF6F RID: 65391
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF70 RID: 65392
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FF71 RID: 65393
		private static IntPtr __ExecuteUbergraph_BP_SceneLifePlay_NativeFunctionPtr;

		// Token: 0x0200994F RID: 39247
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FB5 RID: 204725
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009950 RID: 39248
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031FB6 RID: 204726
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009951 RID: 39249
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SceneLifePlay_FunctionParams
		{
			// Token: 0x04031FB7 RID: 204727
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
