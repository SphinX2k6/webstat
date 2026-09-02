using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D61 RID: 15713
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/BP_NpcCombinedMesh.BP_NpcCombinedMesh_C")]
	[UnrealStructLayout(1656, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1656)]
	public class BP_NpcCombinedMesh_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026358 RID: 156504 RVA: 0x009D0F7C File Offset: 0x009CF17C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NpcCombinedMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_NpcCombinedMesh.BP_NpcCombinedMesh_C");
			}
			return BP_NpcCombinedMesh_C._ClassPtr;
		}

		// Token: 0x06026359 RID: 156505 RVA: 0x009D0FA0 File Offset: 0x009CF1A0
		public BP_NpcCombinedMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_NpcCombinedMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602635A RID: 156506 RVA: 0x009D0FC8 File Offset: 0x009CF1C8
		[NullableContext(1)]
		public BP_NpcCombinedMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NpcCombinedMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005602 RID: 22018
		// (get) Token: 0x0602635B RID: 156507 RVA: 0x009D0FFC File Offset: 0x009CF1FC
		// (set) Token: 0x0602635C RID: 156508 RVA: 0x009D1035 File Offset: 0x009CF235
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005603 RID: 22019
		// (get) Token: 0x0602635D RID: 156509 RVA: 0x009D1056 File Offset: 0x009CF256
		// (set) Token: 0x0602635E RID: 156510 RVA: 0x009D106A File Offset: 0x009CF26A
		[Nullable(2)]
		public unsafe USkeletalMeshComponent Skel_Main
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005604 RID: 22020
		// (get) Token: 0x0602635F RID: 156511 RVA: 0x009D107F File Offset: 0x009CF27F
		// (set) Token: 0x06026360 RID: 156512 RVA: 0x009D1093 File Offset: 0x009CF293
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005605 RID: 22021
		// (get) Token: 0x06026361 RID: 156513 RVA: 0x009D10A8 File Offset: 0x009CF2A8
		// (set) Token: 0x06026362 RID: 156514 RVA: 0x009D10BC File Offset: 0x009CF2BC
		[Nullable(2)]
		public unsafe PD_NpcSetupData_C NpcData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_NpcSetupData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005606 RID: 22022
		// (get) Token: 0x06026363 RID: 156515 RVA: 0x009D10D1 File Offset: 0x009CF2D1
		// (set) Token: 0x06026364 RID: 156516 RVA: 0x009D10E1 File Offset: 0x009CF2E1
		public unsafe bool OriginalSkeletalVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005607 RID: 22023
		// (get) Token: 0x06026365 RID: 156517 RVA: 0x009D10F4 File Offset: 0x009CF2F4
		// (set) Token: 0x06026366 RID: 156518 RVA: 0x009D112D File Offset: 0x009CF32D
		[Nullable(1)]
		public TMap<FName, SNpcSetupPartInfo> AllSubSkeletalComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SNpcSetupPartInfo> result;
				if ((result = this._AllSubSkeletalComponents) == null)
				{
					result = (this._AllSubSkeletalComponents = new TMap<FName, SNpcSetupPartInfo>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AllSubSkeletalComponents.CopyAssign(value);
			}
		}

		// Token: 0x17005608 RID: 22024
		// (get) Token: 0x06026367 RID: 156519 RVA: 0x009D113B File Offset: 0x009CF33B
		// (set) Token: 0x06026368 RID: 156520 RVA: 0x009D114F File Offset: 0x009CF34F
		[Nullable(2)]
		public unsafe BP_NpcCombinedMesh_C Target
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_NpcCombinedMesh_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NpcCombinedMesh_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005609 RID: 22025
		// (get) Token: 0x06026369 RID: 156521 RVA: 0x009D1164 File Offset: 0x009CF364
		// (set) Token: 0x0602636A RID: 156522 RVA: 0x009D119D File Offset: 0x009CF39D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<FName, TEnumAsByte<EBodyPartName>> AllBodyPartName
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, TEnumAsByte<EBodyPartName>> result;
				if ((result = this._AllBodyPartName) == null)
				{
					result = (this._AllBodyPartName = new TMap<FName, TEnumAsByte<EBodyPartName>>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.AllBodyPartName.CopyAssign(value);
			}
		}

		// Token: 0x1700560A RID: 22026
		// (get) Token: 0x0602636B RID: 156523 RVA: 0x009D11AB File Offset: 0x009CF3AB
		// (set) Token: 0x0602636C RID: 156524 RVA: 0x009D11BF File Offset: 0x009CF3BF
		public unsafe FLinearColor ColorNPC01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700560B RID: 22027
		// (get) Token: 0x0602636D RID: 156525 RVA: 0x009D11D4 File Offset: 0x009CF3D4
		// (set) Token: 0x0602636E RID: 156526 RVA: 0x009D11E8 File Offset: 0x009CF3E8
		public unsafe FLinearColor ColorNPC02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700560C RID: 22028
		// (get) Token: 0x0602636F RID: 156527 RVA: 0x009D11FD File Offset: 0x009CF3FD
		// (set) Token: 0x06026370 RID: 156528 RVA: 0x009D120D File Offset: 0x009CF40D
		public unsafe int Forced_LOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700560D RID: 22029
		// (get) Token: 0x06026371 RID: 156529 RVA: 0x009D121E File Offset: 0x009CF41E
		// (set) Token: 0x06026372 RID: 156530 RVA: 0x009D1232 File Offset: 0x009CF432
		public unsafe FLinearColor SkinColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700560E RID: 22030
		// (get) Token: 0x06026373 RID: 156531 RVA: 0x009D1248 File Offset: 0x009CF448
		// (set) Token: 0x06026374 RID: 156532 RVA: 0x009D1281 File Offset: 0x009CF481
		[Nullable(1)]
		public TArray<USkeletalMeshComponent> SkelMeshArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._SkelMeshArray) == null)
				{
					result = (this._SkelMeshArray = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkelMeshArray.CopyAssign(value);
			}
		}

		// Token: 0x1700560F RID: 22031
		// (get) Token: 0x06026375 RID: 156533 RVA: 0x009D1290 File Offset: 0x009CF490
		// (set) Token: 0x06026376 RID: 156534 RVA: 0x009D12C9 File Offset: 0x009CF4C9
		[Nullable(1)]
		public TArray<UMaterialInstance> MINPCs
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._MINPCs) == null)
				{
					result = (this._MINPCs = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MINPCs.CopyAssign(value);
			}
		}

		// Token: 0x17005610 RID: 22032
		// (get) Token: 0x06026377 RID: 156535 RVA: 0x009D12D7 File Offset: 0x009CF4D7
		// (set) Token: 0x06026378 RID: 156536 RVA: 0x009D12E7 File Offset: 0x009CF4E7
		public unsafe bool AdaptMaterialController
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005611 RID: 22033
		// (get) Token: 0x06026379 RID: 156537 RVA: 0x009D12F8 File Offset: 0x009CF4F8
		// (set) Token: 0x0602637A RID: 156538 RVA: 0x009D1308 File Offset: 0x009CF508
		public unsafe bool Ticked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005612 RID: 22034
		// (get) Token: 0x0602637B RID: 156539 RVA: 0x009D131C File Offset: 0x009CF51C
		// (set) Token: 0x0602637C RID: 156540 RVA: 0x009D1355 File Offset: 0x009CF555
		[Nullable(1)]
		public TArray<UKuroNpcExtraDecorationConfig> DecorationData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UKuroNpcExtraDecorationConfig> result;
				if ((result = this._DecorationData) == null)
				{
					result = (this._DecorationData = new TArray<UKuroNpcExtraDecorationConfig>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DecorationData.CopyAssign(value);
			}
		}

		// Token: 0x17005613 RID: 22035
		// (get) Token: 0x0602637D RID: 156541 RVA: 0x009D1363 File Offset: 0x009CF563
		// (set) Token: 0x0602637E RID: 156542 RVA: 0x009D1373 File Offset: 0x009CF573
		public unsafe bool SkelTickableWhenPaused
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005614 RID: 22036
		// (get) Token: 0x0602637F RID: 156543 RVA: 0x009D1384 File Offset: 0x009CF584
		// (set) Token: 0x06026380 RID: 156544 RVA: 0x009D13BD File Offset: 0x009CF5BD
		[Nullable(1)]
		public TArray<UMaterialInstance> MINPCs_clean
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._MINPCs_clean) == null)
				{
					result = (this._MINPCs_clean = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_NpcCombinedMesh_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MINPCs_clean.CopyAssign(value);
			}
		}

		// Token: 0x06026381 RID: 156545 RVA: 0x009D13CB File Offset: 0x009CF5CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ApplySkelTickableWhenPaused()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ApplySkelTickableWhenPaused_NativeFunctionPtr, null);
		}

		// Token: 0x06026382 RID: 156546 RVA: 0x009D13E0 File Offset: 0x009CF5E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSkelTickableWhenPaused(bool bTickableWhenPaused)
		{
			BP_NpcCombinedMesh_C.__SetSkelTickableWhenPaused_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__SetSkelTickableWhenPaused_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__SetSkelTickableWhenPaused_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__SetSkelTickableWhenPaused_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bTickableWhenPaused = bTickableWhenPaused;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetSkelTickableWhenPaused_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026383 RID: 156547 RVA: 0x009D1428 File Offset: 0x009CF628
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupDecorations([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UKuroNpcExtraDecorationConfig> Decorations)
		{
			BP_NpcCombinedMesh_C.__SetupDecorations_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__SetupDecorations_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__SetupDecorations_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__SetupDecorations_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UKuroNpcExtraDecorationConfig> tarray = Decorations;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Decorations);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupDecorations_NativeFunctionPtr, (void*)ptr);
			TArray<UKuroNpcExtraDecorationConfig> tarray2 = Decorations;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Decorations);
			}
			UnrealReflectionUtils.DestroyStruct(BP_NpcCombinedMesh_C.__SetupDecorations_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026384 RID: 156548 RVA: 0x009D14A0 File Offset: 0x009CF6A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupCastShadow(bool bIgnoreCastShadow)
		{
			BP_NpcCombinedMesh_C.__SetupCastShadow_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__SetupCastShadow_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__SetupCastShadow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__SetupCastShadow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIgnoreCastShadow = bIgnoreCastShadow;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupCastShadow_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026385 RID: 156549 RVA: 0x009D14E6 File Offset: 0x009CF6E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupHiddenBones()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupHiddenBones_NativeFunctionPtr, null);
		}

		// Token: 0x06026386 RID: 156550 RVA: 0x009D14FA File Offset: 0x009CF6FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupChildParts()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupChildParts_NativeFunctionPtr, null);
		}

		// Token: 0x06026387 RID: 156551 RVA: 0x009D1510 File Offset: 0x009CF710
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Skeletal_Mesh_Material(UMaterialInterface ReplaceMaterial, USkeletalMeshComponent SkeletalMeshComp, FName ParamName01, FName ParamName02, FName SkinColorName, int NumSlots, int MaterialIndex)
		{
			BP_NpcCombinedMesh_C.__Set_Skeletal_Mesh_Material_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__Set_Skeletal_Mesh_Material_FunctionParams[(UIntPtr)815] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__Set_Skeletal_Mesh_Material_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__Set_Skeletal_Mesh_Material_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ReplaceMaterial = ((ReplaceMaterial != null) ? ReplaceMaterial.NativePtr : IntPtr.Zero);
			ptr->SkeletalMeshComp = ((SkeletalMeshComp != null) ? SkeletalMeshComp.NativePtr : IntPtr.Zero);
			ptr->ParamName01 = ParamName01;
			ptr->ParamName02 = ParamName02;
			ptr->SkinColorName = SkinColorName;
			ptr->NumSlots = NumSlots;
			ptr->MaterialIndex = MaterialIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__Set_Skeletal_Mesh_Material_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026388 RID: 156552 RVA: 0x009D15A5 File Offset: 0x009CF7A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 预览MorphTarget()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__预览MorphTarget_NativeFunctionPtr, null);
		}

		// Token: 0x06026389 RID: 156553 RVA: 0x009D15BC File Offset: 0x009CF7BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Test(USkeletalMeshComponent SKMesh, UMaterialInstance MI)
		{
			BP_NpcCombinedMesh_C.__Test_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__Test_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__Test_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__Test_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SKMesh = ((SKMesh != null) ? SKMesh.NativePtr : IntPtr.Zero);
			ptr->MI = ((MI != null) ? MI.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__Test_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602638A RID: 156554 RVA: 0x009D1628 File Offset: 0x009CF828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHeadTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetHeadTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetHeadTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetHeadTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetHeadTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetHeadTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x0602638B RID: 156555 RVA: 0x009D1690 File Offset: 0x009CF890
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Skeleton_Mesh_DI(USkeletalMeshComponent SKMesh, FName ParamName01, FName ParamName02, EBodyPartName BodyType, FName SkinColorName, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInterface> Materials)
		{
			BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SKMesh = ((SKMesh != null) ? SKMesh.NativePtr : IntPtr.Zero);
			ptr->ParamName01 = ParamName01;
			ptr->ParamName02 = ParamName02;
			ptr->BodyType = BodyType;
			ptr->SkinColorName = SkinColorName;
			TArray<UMaterialInterface> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInterface> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(BP_NpcCombinedMesh_C.__Set_Skeleton_Mesh_DI_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602638C RID: 156556 RVA: 0x009D1748 File Offset: 0x009CF948
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddSkeletalComponent(FName Name, USkeletalMeshComponent SkeletalComp)
		{
			BP_NpcCombinedMesh_C.__AddSkeletalComponent_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__AddSkeletalComponent_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__AddSkeletalComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__AddSkeletalComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			ptr->SkeletalComp = ((SkeletalComp != null) ? SkeletalComp.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__AddSkeletalComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602638D RID: 156557 RVA: 0x009D17A4 File Offset: 0x009CF9A4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Setup_Skeletal_Mesh_Component(USkeletalMesh InSkeletalMesh, EBodyPartName BodyType, int Index, ref bool Suc, ref USkeletalMeshComponent SkeletalComp)
		{
			BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_FunctionParams[(UIntPtr)623] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InSkeletalMesh = ((InSkeletalMesh != null) ? InSkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->BodyType = BodyType;
			ptr->Index = Index;
			ptr->Suc = Suc;
			ref BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_FunctionParams ptr2 = ref *ptr;
			USkeletalMeshComponent uskeletalMeshComponent = SkeletalComp;
			ptr2.SkeletalComp = ((uskeletalMeshComponent != null) ? uskeletalMeshComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__Setup_Skeletal_Mesh_Component_NativeFunctionPtr, (void*)ptr);
			Suc = ptr->Suc;
			SkeletalComp = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(ptr->SkeletalComp);
		}

		// Token: 0x0602638E RID: 156558 RVA: 0x009D1848 File Offset: 0x009CFA48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetWaistTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetWaistTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetWaistTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetWaistTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetWaistTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetWaistTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x0602638F RID: 156559 RVA: 0x009D18B0 File Offset: 0x009CFAB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBackTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetBackTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetBackTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetBackTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetBackTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetBackTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x06026390 RID: 156560 RVA: 0x009D1918 File Offset: 0x009CFB18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLegTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetLegTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetLegTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetLegTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetLegTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetLegTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x06026391 RID: 156561 RVA: 0x009D1980 File Offset: 0x009CFB80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetWeaponTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetWeaponTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetWeaponTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetWeaponTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetWeaponTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetWeaponTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x06026392 RID: 156562 RVA: 0x009D19E8 File Offset: 0x009CFBE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetArmTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_NpcCombinedMesh_C.__GetArmTransform_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__GetArmTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__GetArmTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__GetArmTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__GetArmTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x06026393 RID: 156563 RVA: 0x009D1A50 File Offset: 0x009CFC50
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Setup_Socket(FName SocketName, FTransform Transform, USkeletalMesh SkeletalMesh, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FMorphTargetPreviewItem> MorphTargets, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SNpcHookPartMaterial> Materials, int index, ref bool Suc, ref USkeletalMeshComponent SkeletalComp)
		{
			BP_NpcCombinedMesh_C.__Setup_Socket_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__Setup_Socket_FunctionParams[(UIntPtr)607] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__Setup_Socket_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SocketName = SocketName;
			ptr->Transform = Transform;
			ptr->SkeletalMesh = ((SkeletalMesh != null) ? SkeletalMesh.NativePtr : IntPtr.Zero);
			TArray<FMorphTargetPreviewItem> tarray = MorphTargets;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->MorphTargets);
			}
			TArray<SNpcHookPartMaterial> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->Materials);
			}
			ptr->index = index;
			ptr->Suc = Suc;
			ref BP_NpcCombinedMesh_C.__Setup_Socket_FunctionParams ptr2 = ref *ptr;
			USkeletalMeshComponent uskeletalMeshComponent = SkeletalComp;
			ptr2.SkeletalComp = ((uskeletalMeshComponent != null) ? uskeletalMeshComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr);
			TArray<FMorphTargetPreviewItem> tarray3 = MorphTargets;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->MorphTargets);
			}
			TArray<SNpcHookPartMaterial> tarray4 = Materials;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->Materials);
			}
			Suc = ptr->Suc;
			SkeletalComp = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(ptr->SkeletalComp);
			UnrealReflectionUtils.DestroyStruct(BP_NpcCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026394 RID: 156564 RVA: 0x009D1B5C File Offset: 0x009CFD5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupSockets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupSockets_NativeFunctionPtr, null);
		}

		// Token: 0x06026395 RID: 156565 RVA: 0x009D1B70 File Offset: 0x009CFD70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupSkeletalMeshComponents(ref bool Suc)
		{
			BP_NpcCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__SetupSkeletalMeshComponents_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupSkeletalMeshComponents_NativeFunctionPtr, (void*)ptr);
			Suc = ptr->Suc;
		}

		// Token: 0x06026396 RID: 156566 RVA: 0x009D1BBF File Offset: 0x009CFDBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetNpcMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ResetNpcMesh_NativeFunctionPtr, null);
		}

		// Token: 0x06026397 RID: 156567 RVA: 0x009D1BD4 File Offset: 0x009CFDD4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupNpcMesh(PD_NpcSetupData_C Data, bool bIgnoreSockets, bool bIgnoreCastShadow, ref bool IsSuc, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMeshComponent> SkleMain)
		{
			BP_NpcCombinedMesh_C.__SetupNpcMesh_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__SetupNpcMesh_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__SetupNpcMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__SetupNpcMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->bIgnoreSockets = bIgnoreSockets;
			ptr->bIgnoreCastShadow = bIgnoreCastShadow;
			ptr->IsSuc = IsSuc;
			TArray<USkeletalMeshComponent> tarray = SkleMain;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->SkleMain);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__SetupNpcMesh_NativeFunctionPtr, (void*)ptr);
			IsSuc = ptr->IsSuc;
			TArray<USkeletalMeshComponent> tarray2 = SkleMain;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->SkleMain);
			}
			UnrealReflectionUtils.DestroyStruct(BP_NpcCombinedMesh_C.__SetupNpcMesh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026398 RID: 156568 RVA: 0x009D1C84 File Offset: 0x009CFE84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026399 RID: 156569 RVA: 0x009D1C98 File Offset: 0x009CFE98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602639A RID: 156570 RVA: 0x009D1CAD File Offset: 0x009CFEAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602639B RID: 156571 RVA: 0x009D1CC1 File Offset: 0x009CFEC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602639C RID: 156572 RVA: 0x009D1CD8 File Offset: 0x009CFED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602639D RID: 156573 RVA: 0x009D1D20 File Offset: 0x009CFF20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602639E RID: 156574 RVA: 0x009D1D68 File Offset: 0x009CFF68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NpcCombinedMesh(int EntryPoint)
		{
			BP_NpcCombinedMesh_C.__ExecuteUbergraph_BP_NpcCombinedMesh_FunctionParams* ptr = stackalloc BP_NpcCombinedMesh_C.__ExecuteUbergraph_BP_NpcCombinedMesh_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_NpcCombinedMesh_C.__ExecuteUbergraph_BP_NpcCombinedMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NpcCombinedMesh_C.__ExecuteUbergraph_BP_NpcCombinedMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NpcCombinedMesh_C.__ExecuteUbergraph_BP_NpcCombinedMesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602639F RID: 156575 RVA: 0x009D1DAF File Offset: 0x009CFFAF
		protected BP_NpcCombinedMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013CC2 RID: 81090
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_NpcCombinedMesh.BP_NpcCombinedMesh_C";

		// Token: 0x04013CC3 RID: 81091
		private static IntPtr _ClassPtr;

		// Token: 0x04013CC4 RID: 81092
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013CC5 RID: 81093
		internal static int __PropertyOffset_0;

		// Token: 0x04013CC6 RID: 81094
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013CC7 RID: 81095
		internal static int __PropertyOffset_1;

		// Token: 0x04013CC8 RID: 81096
		internal static int __PropertyOffset_2;

		// Token: 0x04013CC9 RID: 81097
		internal static int __PropertyOffset_3;

		// Token: 0x04013CCA RID: 81098
		internal static int __PropertyOffset_4;

		// Token: 0x04013CCB RID: 81099
		internal static int __PropertyOffset_5;

		// Token: 0x04013CCC RID: 81100
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SNpcSetupPartInfo> _AllSubSkeletalComponents;

		// Token: 0x04013CCD RID: 81101
		internal static int __PropertyOffset_6;

		// Token: 0x04013CCE RID: 81102
		internal static int __PropertyOffset_7;

		// Token: 0x04013CCF RID: 81103
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<FName, TEnumAsByte<EBodyPartName>> _AllBodyPartName;

		// Token: 0x04013CD0 RID: 81104
		internal static int __PropertyOffset_8;

		// Token: 0x04013CD1 RID: 81105
		internal static int __PropertyOffset_9;

		// Token: 0x04013CD2 RID: 81106
		internal static int __PropertyOffset_10;

		// Token: 0x04013CD3 RID: 81107
		internal static int __PropertyOffset_11;

		// Token: 0x04013CD4 RID: 81108
		internal static int __PropertyOffset_12;

		// Token: 0x04013CD5 RID: 81109
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _SkelMeshArray;

		// Token: 0x04013CD6 RID: 81110
		internal static int __PropertyOffset_13;

		// Token: 0x04013CD7 RID: 81111
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _MINPCs;

		// Token: 0x04013CD8 RID: 81112
		internal static int __PropertyOffset_14;

		// Token: 0x04013CD9 RID: 81113
		internal static int __PropertyOffset_15;

		// Token: 0x04013CDA RID: 81114
		internal static int __PropertyOffset_16;

		// Token: 0x04013CDB RID: 81115
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UKuroNpcExtraDecorationConfig> _DecorationData;

		// Token: 0x04013CDC RID: 81116
		internal static int __PropertyOffset_17;

		// Token: 0x04013CDD RID: 81117
		internal static int __PropertyOffset_18;

		// Token: 0x04013CDE RID: 81118
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _MINPCs_clean;

		// Token: 0x04013CDF RID: 81119
		private static IntPtr __ApplySkelTickableWhenPaused_NativeFunctionPtr;

		// Token: 0x04013CE0 RID: 81120
		private static IntPtr __SetSkelTickableWhenPaused_NativeFunctionPtr;

		// Token: 0x04013CE1 RID: 81121
		private static IntPtr __SetupDecorations_NativeFunctionPtr;

		// Token: 0x04013CE2 RID: 81122
		private static IntPtr __SetupCastShadow_NativeFunctionPtr;

		// Token: 0x04013CE3 RID: 81123
		private static IntPtr __SetupHiddenBones_NativeFunctionPtr;

		// Token: 0x04013CE4 RID: 81124
		private static IntPtr __SetupChildParts_NativeFunctionPtr;

		// Token: 0x04013CE5 RID: 81125
		private static IntPtr __Set_Skeletal_Mesh_Material_NativeFunctionPtr;

		// Token: 0x04013CE6 RID: 81126
		private static IntPtr __预览MorphTarget_NativeFunctionPtr;

		// Token: 0x04013CE7 RID: 81127
		private static IntPtr __Test_NativeFunctionPtr;

		// Token: 0x04013CE8 RID: 81128
		private static IntPtr __GetHeadTransform_NativeFunctionPtr;

		// Token: 0x04013CE9 RID: 81129
		private static IntPtr __Set_Skeleton_Mesh_DI_NativeFunctionPtr;

		// Token: 0x04013CEA RID: 81130
		private static IntPtr __AddSkeletalComponent_NativeFunctionPtr;

		// Token: 0x04013CEB RID: 81131
		private static IntPtr __Setup_Skeletal_Mesh_Component_NativeFunctionPtr;

		// Token: 0x04013CEC RID: 81132
		private static IntPtr __GetWaistTransform_NativeFunctionPtr;

		// Token: 0x04013CED RID: 81133
		private static IntPtr __GetBackTransform_NativeFunctionPtr;

		// Token: 0x04013CEE RID: 81134
		private static IntPtr __GetLegTransform_NativeFunctionPtr;

		// Token: 0x04013CEF RID: 81135
		private static IntPtr __GetWeaponTransform_NativeFunctionPtr;

		// Token: 0x04013CF0 RID: 81136
		private static IntPtr __GetArmTransform_NativeFunctionPtr;

		// Token: 0x04013CF1 RID: 81137
		private static IntPtr __Setup_Socket_NativeFunctionPtr;

		// Token: 0x04013CF2 RID: 81138
		private static IntPtr __SetupSockets_NativeFunctionPtr;

		// Token: 0x04013CF3 RID: 81139
		private static IntPtr __SetupSkeletalMeshComponents_NativeFunctionPtr;

		// Token: 0x04013CF4 RID: 81140
		private static IntPtr __ResetNpcMesh_NativeFunctionPtr;

		// Token: 0x04013CF5 RID: 81141
		private static IntPtr __SetupNpcMesh_NativeFunctionPtr;

		// Token: 0x04013CF6 RID: 81142
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013CF7 RID: 81143
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013CF8 RID: 81144
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013CF9 RID: 81145
		private static IntPtr __ExecuteUbergraph_BP_NpcCombinedMesh_NativeFunctionPtr;

		// Token: 0x0200A01C RID: 40988
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetSkelTickableWhenPaused_FunctionParams
		{
			// Token: 0x04032C08 RID: 207880
			[FieldOffset(0)]
			public bool bTickableWhenPaused;
		}

		// Token: 0x0200A01D RID: 40989
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __SetupDecorations_FunctionParams
		{
			// Token: 0x04032C09 RID: 207881
			[FieldOffset(0)]
			public byte Decorations;
		}

		// Token: 0x0200A01E RID: 40990
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetupCastShadow_FunctionParams
		{
			// Token: 0x04032C0A RID: 207882
			[FieldOffset(0)]
			public bool bIgnoreCastShadow;
		}

		// Token: 0x0200A01F RID: 40991
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 800)]
		protected ref struct __Set_Skeletal_Mesh_Material_FunctionParams
		{
			// Token: 0x04032C0B RID: 207883
			[FieldOffset(0)]
			public IntPtr ReplaceMaterial;

			// Token: 0x04032C0C RID: 207884
			[FieldOffset(8)]
			public IntPtr SkeletalMeshComp;

			// Token: 0x04032C0D RID: 207885
			[FieldOffset(16)]
			public FName ParamName01;

			// Token: 0x04032C0E RID: 207886
			[FieldOffset(28)]
			public FName ParamName02;

			// Token: 0x04032C0F RID: 207887
			[FieldOffset(40)]
			public FName SkinColorName;

			// Token: 0x04032C10 RID: 207888
			[FieldOffset(52)]
			public int NumSlots;

			// Token: 0x04032C11 RID: 207889
			[FieldOffset(56)]
			public int MaterialIndex;
		}

		// Token: 0x0200A020 RID: 40992
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Test_FunctionParams
		{
			// Token: 0x04032C12 RID: 207890
			[FieldOffset(0)]
			public IntPtr SKMesh;

			// Token: 0x04032C13 RID: 207891
			[FieldOffset(8)]
			public IntPtr MI;
		}

		// Token: 0x0200A021 RID: 40993
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetHeadTransform_FunctionParams
		{
			// Token: 0x04032C14 RID: 207892
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C15 RID: 207893
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C16 RID: 207894
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A022 RID: 40994
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __Set_Skeleton_Mesh_DI_FunctionParams
		{
			// Token: 0x04032C17 RID: 207895
			[FieldOffset(0)]
			public IntPtr SKMesh;

			// Token: 0x04032C18 RID: 207896
			[FieldOffset(8)]
			public FName ParamName01;

			// Token: 0x04032C19 RID: 207897
			[FieldOffset(20)]
			public FName ParamName02;

			// Token: 0x04032C1A RID: 207898
			[FieldOffset(32)]
			public TEnumAsByte<EBodyPartName> BodyType;

			// Token: 0x04032C1B RID: 207899
			[FieldOffset(36)]
			public FName SkinColorName;

			// Token: 0x04032C1C RID: 207900
			[FieldOffset(48)]
			public byte Materials;
		}

		// Token: 0x0200A023 RID: 40995
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __AddSkeletalComponent_FunctionParams
		{
			// Token: 0x04032C1D RID: 207901
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04032C1E RID: 207902
			[FieldOffset(16)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A024 RID: 40996
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 608)]
		protected ref struct __Setup_Skeletal_Mesh_Component_FunctionParams
		{
			// Token: 0x04032C1F RID: 207903
			[FieldOffset(0)]
			public IntPtr InSkeletalMesh;

			// Token: 0x04032C20 RID: 207904
			[FieldOffset(8)]
			public TEnumAsByte<EBodyPartName> BodyType;

			// Token: 0x04032C21 RID: 207905
			[FieldOffset(12)]
			public int Index;

			// Token: 0x04032C22 RID: 207906
			[FieldOffset(16)]
			public bool Suc;

			// Token: 0x04032C23 RID: 207907
			[FieldOffset(24)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A025 RID: 40997
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetWaistTransform_FunctionParams
		{
			// Token: 0x04032C24 RID: 207908
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C25 RID: 207909
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C26 RID: 207910
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A026 RID: 40998
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetBackTransform_FunctionParams
		{
			// Token: 0x04032C27 RID: 207911
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C28 RID: 207912
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C29 RID: 207913
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A027 RID: 40999
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetLegTransform_FunctionParams
		{
			// Token: 0x04032C2A RID: 207914
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C2B RID: 207915
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C2C RID: 207916
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A028 RID: 41000
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetWeaponTransform_FunctionParams
		{
			// Token: 0x04032C2D RID: 207917
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C2E RID: 207918
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C2F RID: 207919
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A029 RID: 41001
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetArmTransform_FunctionParams
		{
			// Token: 0x04032C30 RID: 207920
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C31 RID: 207921
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C32 RID: 207922
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A02A RID: 41002
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 592)]
		protected ref struct __Setup_Socket_FunctionParams
		{
			// Token: 0x04032C33 RID: 207923
			[FieldOffset(0)]
			public FName SocketName;

			// Token: 0x04032C34 RID: 207924
			[FieldOffset(16)]
			public FTransform Transform;

			// Token: 0x04032C35 RID: 207925
			[FieldOffset(64)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032C36 RID: 207926
			[FieldOffset(72)]
			public byte MorphTargets;

			// Token: 0x04032C37 RID: 207927
			[FieldOffset(88)]
			public byte Materials;

			// Token: 0x04032C38 RID: 207928
			[FieldOffset(104)]
			public int index;

			// Token: 0x04032C39 RID: 207929
			[FieldOffset(108)]
			public bool Suc;

			// Token: 0x04032C3A RID: 207930
			[FieldOffset(112)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A02B RID: 41003
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __SetupSkeletalMeshComponents_FunctionParams
		{
			// Token: 0x04032C3B RID: 207931
			[FieldOffset(0)]
			public bool Suc;
		}

		// Token: 0x0200A02C RID: 41004
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetupNpcMesh_FunctionParams
		{
			// Token: 0x04032C3C RID: 207932
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04032C3D RID: 207933
			[FieldOffset(8)]
			public bool bIgnoreSockets;

			// Token: 0x04032C3E RID: 207934
			[FieldOffset(9)]
			public bool bIgnoreCastShadow;

			// Token: 0x04032C3F RID: 207935
			[FieldOffset(10)]
			public bool IsSuc;

			// Token: 0x04032C40 RID: 207936
			[FieldOffset(16)]
			public byte SkleMain;
		}

		// Token: 0x0200A02D RID: 41005
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032C41 RID: 207937
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A02E RID: 41006
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_NpcCombinedMesh_FunctionParams
		{
			// Token: 0x04032C42 RID: 207938
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
