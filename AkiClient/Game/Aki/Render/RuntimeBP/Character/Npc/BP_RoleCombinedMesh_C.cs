using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D63 RID: 15715
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/BP_RoleCombinedMesh.BP_RoleCombinedMesh_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_RoleCombinedMesh_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060263A6 RID: 156582 RVA: 0x009D1E69 File Offset: 0x009D0069
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RoleCombinedMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_RoleCombinedMesh.BP_RoleCombinedMesh_C");
			}
			return BP_RoleCombinedMesh_C._ClassPtr;
		}

		// Token: 0x060263A7 RID: 156583 RVA: 0x009D1E90 File Offset: 0x009D0090
		public BP_RoleCombinedMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_RoleCombinedMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060263A8 RID: 156584 RVA: 0x009D1EB8 File Offset: 0x009D00B8
		[NullableContext(1)]
		public BP_RoleCombinedMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RoleCombinedMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005616 RID: 22038
		// (get) Token: 0x060263A9 RID: 156585 RVA: 0x009D1EEB File Offset: 0x009D00EB
		// (set) Token: 0x060263AA RID: 156586 RVA: 0x009D1EFF File Offset: 0x009D00FF
		public unsafe USkeletalMeshComponent CharacterMesh0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005617 RID: 22039
		// (get) Token: 0x060263AB RID: 156587 RVA: 0x009D1F14 File Offset: 0x009D0114
		// (set) Token: 0x060263AC RID: 156588 RVA: 0x009D1F28 File Offset: 0x009D0128
		public unsafe USkeletalMeshComponent Skel_Main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005618 RID: 22040
		// (get) Token: 0x060263AD RID: 156589 RVA: 0x009D1F3D File Offset: 0x009D013D
		// (set) Token: 0x060263AE RID: 156590 RVA: 0x009D1F51 File Offset: 0x009D0151
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005619 RID: 22041
		// (get) Token: 0x060263AF RID: 156591 RVA: 0x009D1F66 File Offset: 0x009D0166
		// (set) Token: 0x060263B0 RID: 156592 RVA: 0x009D1F76 File Offset: 0x009D0176
		public unsafe bool OriginalSkeletalVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700561A RID: 22042
		// (get) Token: 0x060263B1 RID: 156593 RVA: 0x009D1F88 File Offset: 0x009D0188
		// (set) Token: 0x060263B2 RID: 156594 RVA: 0x009D1FC1 File Offset: 0x009D01C1
		[Nullable(1)]
		public TMap<FName, SRoleSetupPartInfo> AllSubSkeletalComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SRoleSetupPartInfo> result;
				if ((result = this._AllSubSkeletalComponents) == null)
				{
					result = (this._AllSubSkeletalComponents = new TMap<FName, SRoleSetupPartInfo>(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AllSubSkeletalComponents.CopyAssign(value);
			}
		}

		// Token: 0x1700561B RID: 22043
		// (get) Token: 0x060263B3 RID: 156595 RVA: 0x009D1FCF File Offset: 0x009D01CF
		// (set) Token: 0x060263B4 RID: 156596 RVA: 0x009D1FE3 File Offset: 0x009D01E3
		public unsafe BP_NpcCombinedMesh_C Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_NpcCombinedMesh_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700561C RID: 22044
		// (get) Token: 0x060263B5 RID: 156597 RVA: 0x009D1FF8 File Offset: 0x009D01F8
		// (set) Token: 0x060263B6 RID: 156598 RVA: 0x009D2031 File Offset: 0x009D0231
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<FName, TEnumAsByte<ERoleBodyPartName>> AllBodyPartName
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, TEnumAsByte<ERoleBodyPartName>> result;
				if ((result = this._AllBodyPartName) == null)
				{
					result = (this._AllBodyPartName = new TMap<FName, TEnumAsByte<ERoleBodyPartName>>(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_6, this));
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

		// Token: 0x1700561D RID: 22045
		// (get) Token: 0x060263B7 RID: 156599 RVA: 0x009D203F File Offset: 0x009D023F
		// (set) Token: 0x060263B8 RID: 156600 RVA: 0x009D2053 File Offset: 0x009D0253
		public unsafe FLinearColor ColorRole01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700561E RID: 22046
		// (get) Token: 0x060263B9 RID: 156601 RVA: 0x009D2068 File Offset: 0x009D0268
		// (set) Token: 0x060263BA RID: 156602 RVA: 0x009D207C File Offset: 0x009D027C
		public unsafe FLinearColor ColorRole02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700561F RID: 22047
		// (get) Token: 0x060263BB RID: 156603 RVA: 0x009D2091 File Offset: 0x009D0291
		// (set) Token: 0x060263BC RID: 156604 RVA: 0x009D20A1 File Offset: 0x009D02A1
		public unsafe int Forced_LOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005620 RID: 22048
		// (get) Token: 0x060263BD RID: 156605 RVA: 0x009D20B2 File Offset: 0x009D02B2
		// (set) Token: 0x060263BE RID: 156606 RVA: 0x009D20C6 File Offset: 0x009D02C6
		public unsafe FLinearColor SkinColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005621 RID: 22049
		// (get) Token: 0x060263BF RID: 156607 RVA: 0x009D20DC File Offset: 0x009D02DC
		// (set) Token: 0x060263C0 RID: 156608 RVA: 0x009D2115 File Offset: 0x009D0315
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
					result = (this._SkelMeshArray = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkelMeshArray.CopyAssign(value);
			}
		}

		// Token: 0x17005622 RID: 22050
		// (get) Token: 0x060263C1 RID: 156609 RVA: 0x009D2124 File Offset: 0x009D0324
		// (set) Token: 0x060263C2 RID: 156610 RVA: 0x009D215D File Offset: 0x009D035D
		[Nullable(1)]
		public TArray<UMaterialInstance> MIRoles
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._MIRoles) == null)
				{
					result = (this._MIRoles = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MIRoles.CopyAssign(value);
			}
		}

		// Token: 0x17005623 RID: 22051
		// (get) Token: 0x060263C3 RID: 156611 RVA: 0x009D216B File Offset: 0x009D036B
		// (set) Token: 0x060263C4 RID: 156612 RVA: 0x009D217B File Offset: 0x009D037B
		public unsafe bool AdaptMaterialController
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005624 RID: 22052
		// (get) Token: 0x060263C5 RID: 156613 RVA: 0x009D218C File Offset: 0x009D038C
		// (set) Token: 0x060263C6 RID: 156614 RVA: 0x009D21A0 File Offset: 0x009D03A0
		public unsafe PD_RoleSetupData_C RoleData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_RoleSetupData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005625 RID: 22053
		// (get) Token: 0x060263C7 RID: 156615 RVA: 0x009D21B5 File Offset: 0x009D03B5
		// (set) Token: 0x060263C8 RID: 156616 RVA: 0x009D21C5 File Offset: 0x009D03C5
		public unsafe bool IsWeaponLocal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005626 RID: 22054
		// (get) Token: 0x060263C9 RID: 156617 RVA: 0x009D21D6 File Offset: 0x009D03D6
		// (set) Token: 0x060263CA RID: 156618 RVA: 0x009D21EA File Offset: 0x009D03EA
		public unsafe FName ComponetLocal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005627 RID: 22055
		// (get) Token: 0x060263CB RID: 156619 RVA: 0x009D21FF File Offset: 0x009D03FF
		// (set) Token: 0x060263CC RID: 156620 RVA: 0x009D2213 File Offset: 0x009D0413
		public unsafe USkeletalMeshComponent TempParentSkelMeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005628 RID: 22056
		// (get) Token: 0x060263CD RID: 156621 RVA: 0x009D2228 File Offset: 0x009D0428
		// (set) Token: 0x060263CE RID: 156622 RVA: 0x009D2238 File Offset: 0x009D0438
		public unsafe bool FinAttach
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoleCombinedMesh_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005629 RID: 22057
		// (get) Token: 0x060263CF RID: 156623 RVA: 0x009D2249 File Offset: 0x009D0449
		// (set) Token: 0x060263D0 RID: 156624 RVA: 0x009D225D File Offset: 0x009D045D
		public unsafe UAnimBlueprint 动画蓝图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimBlueprint>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoleCombinedMesh_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x060263D1 RID: 156625 RVA: 0x009D2274 File Offset: 0x009D0474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSkeletalMeshMaterial(UMaterialInterface ReplaceMaterial, USkeletalMeshComponent SkeletalMeshComp, FName ParamName01, FName ParamName02, FName SkinColorName, int NumSlots, int MaterialIndex)
		{
			BP_RoleCombinedMesh_C.__SetSkeletalMeshMaterial_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__SetSkeletalMeshMaterial_FunctionParams[(UIntPtr)471] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__SetSkeletalMeshMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__SetSkeletalMeshMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ReplaceMaterial = ((ReplaceMaterial != null) ? ReplaceMaterial.NativePtr : IntPtr.Zero);
			ptr->SkeletalMeshComp = ((SkeletalMeshComp != null) ? SkeletalMeshComp.NativePtr : IntPtr.Zero);
			ptr->ParamName01 = ParamName01;
			ptr->ParamName02 = ParamName02;
			ptr->SkinColorName = SkinColorName;
			ptr->NumSlots = NumSlots;
			ptr->MaterialIndex = MaterialIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__SetSkeletalMeshMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060263D2 RID: 156626 RVA: 0x009D2309 File Offset: 0x009D0509
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 预览MorphTarget()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__预览MorphTarget_NativeFunctionPtr, null);
		}

		// Token: 0x060263D3 RID: 156627 RVA: 0x009D2320 File Offset: 0x009D0520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Test(USkeletalMeshComponent SKMesh, UMaterialInstance MI)
		{
			BP_RoleCombinedMesh_C.__Test_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__Test_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__Test_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__Test_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SKMesh = ((SKMesh != null) ? SKMesh.NativePtr : IntPtr.Zero);
			ptr->MI = ((MI != null) ? MI.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__Test_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060263D4 RID: 156628 RVA: 0x009D238C File Offset: 0x009D058C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHeadTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetHeadTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetHeadTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetHeadTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetHeadTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetHeadTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263D5 RID: 156629 RVA: 0x009D23F4 File Offset: 0x009D05F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSkeletonMeshDI(USkeletalMeshComponent SkelMesh, FName ParamName01, FName ParamName02, ERoleBodyPartName BodyType, FName SkinColorName, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInterface> Materials)
		{
			BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkelMesh = ((SkelMesh != null) ? SkelMesh.NativePtr : IntPtr.Zero);
			ptr->ParamName01 = ParamName01;
			ptr->ParamName02 = ParamName02;
			ptr->BodyType = BodyType;
			ptr->SkinColorName = SkinColorName;
			TArray<UMaterialInterface> tarray = Materials;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Materials);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInterface> tarray2 = Materials;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Materials);
			}
			UnrealReflectionUtils.DestroyStruct(BP_RoleCombinedMesh_C.__SetSkeletonMeshDI_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060263D6 RID: 156630 RVA: 0x009D24AC File Offset: 0x009D06AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddSkeletalComponent(FName Name, USkeletalMeshComponent SkeletalComp)
		{
			BP_RoleCombinedMesh_C.__AddSkeletalComponent_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__AddSkeletalComponent_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__AddSkeletalComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__AddSkeletalComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			ptr->SkeletalComp = ((SkeletalComp != null) ? SkeletalComp.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__AddSkeletalComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060263D7 RID: 156631 RVA: 0x009D2508 File Offset: 0x009D0708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupSkeletalMeshComponent(USkeletalMesh InSkeletalMesh, ERoleBodyPartName BodyType, int Index, bool RoleSetpuType3, ref bool Suc, ref USkeletalMeshComponent SkeletalComp)
		{
			BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_FunctionParams[(UIntPtr)639] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InSkeletalMesh = ((InSkeletalMesh != null) ? InSkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->BodyType = BodyType;
			ptr->Index = Index;
			ptr->RoleSetpuType3 = RoleSetpuType3;
			ptr->Suc = Suc;
			ref BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_FunctionParams ptr2 = ref *ptr;
			USkeletalMeshComponent uskeletalMeshComponent = SkeletalComp;
			ptr2.SkeletalComp = ((uskeletalMeshComponent != null) ? uskeletalMeshComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponent_NativeFunctionPtr, (void*)ptr);
			Suc = ptr->Suc;
			SkeletalComp = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(ptr->SkeletalComp);
		}

		// Token: 0x060263D8 RID: 156632 RVA: 0x009D25B4 File Offset: 0x009D07B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetWaistTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetWaistTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetWaistTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetWaistTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetWaistTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetWaistTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263D9 RID: 156633 RVA: 0x009D261C File Offset: 0x009D081C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBackTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetBackTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetBackTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetBackTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetBackTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetBackTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263DA RID: 156634 RVA: 0x009D2684 File Offset: 0x009D0884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLegTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetLegTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetLegTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetLegTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetLegTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetLegTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263DB RID: 156635 RVA: 0x009D26EC File Offset: 0x009D08EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetWeaponTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetWeaponTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetWeaponTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetWeaponTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetWeaponTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetWeaponTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263DC RID: 156636 RVA: 0x009D2754 File Offset: 0x009D0954
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetArmTransform(FTransform InTransform, int Index, ref FTransform OutTransform)
		{
			BP_RoleCombinedMesh_C.__GetArmTransform_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__GetArmTransform_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__GetArmTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__GetArmTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InTransform = InTransform;
			ptr->Index = Index;
			ptr->OutTransform = OutTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__GetArmTransform_NativeFunctionPtr, (void*)ptr);
			OutTransform = ptr->OutTransform;
		}

		// Token: 0x060263DD RID: 156637 RVA: 0x009D27BC File Offset: 0x009D09BC
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
			BP_RoleCombinedMesh_C.__Setup_Socket_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__Setup_Socket_FunctionParams[(UIntPtr)607] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__Setup_Socket_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr, 1);
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
			ref BP_RoleCombinedMesh_C.__Setup_Socket_FunctionParams ptr2 = ref *ptr;
			USkeletalMeshComponent uskeletalMeshComponent = SkeletalComp;
			ptr2.SkeletalComp = ((uskeletalMeshComponent != null) ? uskeletalMeshComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr);
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
			UnrealReflectionUtils.DestroyStruct(BP_RoleCombinedMesh_C.__Setup_Socket_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060263DE RID: 156638 RVA: 0x009D28C8 File Offset: 0x009D0AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupSockets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__SetupSockets_NativeFunctionPtr, null);
		}

		// Token: 0x060263DF RID: 156639 RVA: 0x009D28DC File Offset: 0x009D0ADC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupSkeletalMeshComponents(ref bool Suc)
		{
			BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponents_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponents_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__SetupSkeletalMeshComponents_NativeFunctionPtr, (void*)ptr);
			Suc = ptr->Suc;
		}

		// Token: 0x060263E0 RID: 156640 RVA: 0x009D292E File Offset: 0x009D0B2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetRoleMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__ResetRoleMesh_NativeFunctionPtr, null);
		}

		// Token: 0x060263E1 RID: 156641 RVA: 0x009D2944 File Offset: 0x009D0B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Setup_Role_Mesh(PD_RoleSetupData_C Data, bool bIgnoreSockets, ref bool IsSuc, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMeshComponent> SkleMain)
		{
			BP_RoleCombinedMesh_C.__Setup_Role_Mesh_FunctionParams* ptr = stackalloc BP_RoleCombinedMesh_C.__Setup_Role_Mesh_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_RoleCombinedMesh_C.__Setup_Role_Mesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoleCombinedMesh_C.__Setup_Role_Mesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->bIgnoreSockets = bIgnoreSockets;
			ptr->IsSuc = IsSuc;
			TArray<USkeletalMeshComponent> tarray = SkleMain;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->SkleMain);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoleCombinedMesh_C.__Setup_Role_Mesh_NativeFunctionPtr, (void*)ptr);
			IsSuc = ptr->IsSuc;
			TArray<USkeletalMeshComponent> tarray2 = SkleMain;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->SkleMain);
			}
			UnrealReflectionUtils.DestroyStruct(BP_RoleCombinedMesh_C.__Setup_Role_Mesh_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060263E2 RID: 156642 RVA: 0x009D29EB File Offset: 0x009D0BEB
		protected BP_RoleCombinedMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013CFE RID: 81150
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_RoleCombinedMesh.BP_RoleCombinedMesh_C";

		// Token: 0x04013CFF RID: 81151
		private static IntPtr _ClassPtr;

		// Token: 0x04013D00 RID: 81152
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013D01 RID: 81153
		internal static int __PropertyOffset_0;

		// Token: 0x04013D02 RID: 81154
		internal static int __PropertyOffset_1;

		// Token: 0x04013D03 RID: 81155
		internal static int __PropertyOffset_2;

		// Token: 0x04013D04 RID: 81156
		internal static int __PropertyOffset_3;

		// Token: 0x04013D05 RID: 81157
		internal static int __PropertyOffset_4;

		// Token: 0x04013D06 RID: 81158
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SRoleSetupPartInfo> _AllSubSkeletalComponents;

		// Token: 0x04013D07 RID: 81159
		internal static int __PropertyOffset_5;

		// Token: 0x04013D08 RID: 81160
		internal static int __PropertyOffset_6;

		// Token: 0x04013D09 RID: 81161
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<FName, TEnumAsByte<ERoleBodyPartName>> _AllBodyPartName;

		// Token: 0x04013D0A RID: 81162
		internal static int __PropertyOffset_7;

		// Token: 0x04013D0B RID: 81163
		internal static int __PropertyOffset_8;

		// Token: 0x04013D0C RID: 81164
		internal static int __PropertyOffset_9;

		// Token: 0x04013D0D RID: 81165
		internal static int __PropertyOffset_10;

		// Token: 0x04013D0E RID: 81166
		internal static int __PropertyOffset_11;

		// Token: 0x04013D0F RID: 81167
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _SkelMeshArray;

		// Token: 0x04013D10 RID: 81168
		internal static int __PropertyOffset_12;

		// Token: 0x04013D11 RID: 81169
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _MIRoles;

		// Token: 0x04013D12 RID: 81170
		internal static int __PropertyOffset_13;

		// Token: 0x04013D13 RID: 81171
		internal static int __PropertyOffset_14;

		// Token: 0x04013D14 RID: 81172
		internal static int __PropertyOffset_15;

		// Token: 0x04013D15 RID: 81173
		internal static int __PropertyOffset_16;

		// Token: 0x04013D16 RID: 81174
		internal static int __PropertyOffset_17;

		// Token: 0x04013D17 RID: 81175
		internal static int __PropertyOffset_18;

		// Token: 0x04013D18 RID: 81176
		internal static int __PropertyOffset_19;

		// Token: 0x04013D19 RID: 81177
		private static IntPtr __SetSkeletalMeshMaterial_NativeFunctionPtr;

		// Token: 0x04013D1A RID: 81178
		private static IntPtr __预览MorphTarget_NativeFunctionPtr;

		// Token: 0x04013D1B RID: 81179
		private static IntPtr __Test_NativeFunctionPtr;

		// Token: 0x04013D1C RID: 81180
		private static IntPtr __GetHeadTransform_NativeFunctionPtr;

		// Token: 0x04013D1D RID: 81181
		private static IntPtr __SetSkeletonMeshDI_NativeFunctionPtr;

		// Token: 0x04013D1E RID: 81182
		private static IntPtr __AddSkeletalComponent_NativeFunctionPtr;

		// Token: 0x04013D1F RID: 81183
		private static IntPtr __SetupSkeletalMeshComponent_NativeFunctionPtr;

		// Token: 0x04013D20 RID: 81184
		private static IntPtr __GetWaistTransform_NativeFunctionPtr;

		// Token: 0x04013D21 RID: 81185
		private static IntPtr __GetBackTransform_NativeFunctionPtr;

		// Token: 0x04013D22 RID: 81186
		private static IntPtr __GetLegTransform_NativeFunctionPtr;

		// Token: 0x04013D23 RID: 81187
		private static IntPtr __GetWeaponTransform_NativeFunctionPtr;

		// Token: 0x04013D24 RID: 81188
		private static IntPtr __GetArmTransform_NativeFunctionPtr;

		// Token: 0x04013D25 RID: 81189
		private static IntPtr __Setup_Socket_NativeFunctionPtr;

		// Token: 0x04013D26 RID: 81190
		private static IntPtr __SetupSockets_NativeFunctionPtr;

		// Token: 0x04013D27 RID: 81191
		private static IntPtr __SetupSkeletalMeshComponents_NativeFunctionPtr;

		// Token: 0x04013D28 RID: 81192
		private static IntPtr __ResetRoleMesh_NativeFunctionPtr;

		// Token: 0x04013D29 RID: 81193
		private static IntPtr __Setup_Role_Mesh_NativeFunctionPtr;

		// Token: 0x0200A02F RID: 41007
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 456)]
		protected ref struct __SetSkeletalMeshMaterial_FunctionParams
		{
			// Token: 0x04032C43 RID: 207939
			[FieldOffset(0)]
			public IntPtr ReplaceMaterial;

			// Token: 0x04032C44 RID: 207940
			[FieldOffset(8)]
			public IntPtr SkeletalMeshComp;

			// Token: 0x04032C45 RID: 207941
			[FieldOffset(16)]
			public FName ParamName01;

			// Token: 0x04032C46 RID: 207942
			[FieldOffset(28)]
			public FName ParamName02;

			// Token: 0x04032C47 RID: 207943
			[FieldOffset(40)]
			public FName SkinColorName;

			// Token: 0x04032C48 RID: 207944
			[FieldOffset(52)]
			public int NumSlots;

			// Token: 0x04032C49 RID: 207945
			[FieldOffset(56)]
			public int MaterialIndex;
		}

		// Token: 0x0200A030 RID: 41008
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Test_FunctionParams
		{
			// Token: 0x04032C4A RID: 207946
			[FieldOffset(0)]
			public IntPtr SKMesh;

			// Token: 0x04032C4B RID: 207947
			[FieldOffset(8)]
			public IntPtr MI;
		}

		// Token: 0x0200A031 RID: 41009
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetHeadTransform_FunctionParams
		{
			// Token: 0x04032C4C RID: 207948
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C4D RID: 207949
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C4E RID: 207950
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A032 RID: 41010
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __SetSkeletonMeshDI_FunctionParams
		{
			// Token: 0x04032C4F RID: 207951
			[FieldOffset(0)]
			public IntPtr SkelMesh;

			// Token: 0x04032C50 RID: 207952
			[FieldOffset(8)]
			public FName ParamName01;

			// Token: 0x04032C51 RID: 207953
			[FieldOffset(20)]
			public FName ParamName02;

			// Token: 0x04032C52 RID: 207954
			[FieldOffset(32)]
			public TEnumAsByte<ERoleBodyPartName> BodyType;

			// Token: 0x04032C53 RID: 207955
			[FieldOffset(36)]
			public FName SkinColorName;

			// Token: 0x04032C54 RID: 207956
			[FieldOffset(48)]
			public byte Materials;
		}

		// Token: 0x0200A033 RID: 41011
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __AddSkeletalComponent_FunctionParams
		{
			// Token: 0x04032C55 RID: 207957
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04032C56 RID: 207958
			[FieldOffset(16)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A034 RID: 41012
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 624)]
		protected ref struct __SetupSkeletalMeshComponent_FunctionParams
		{
			// Token: 0x04032C57 RID: 207959
			[FieldOffset(0)]
			public IntPtr InSkeletalMesh;

			// Token: 0x04032C58 RID: 207960
			[FieldOffset(8)]
			public TEnumAsByte<ERoleBodyPartName> BodyType;

			// Token: 0x04032C59 RID: 207961
			[FieldOffset(12)]
			public int Index;

			// Token: 0x04032C5A RID: 207962
			[FieldOffset(16)]
			public bool RoleSetpuType3;

			// Token: 0x04032C5B RID: 207963
			[FieldOffset(17)]
			public bool Suc;

			// Token: 0x04032C5C RID: 207964
			[FieldOffset(24)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A035 RID: 41013
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetWaistTransform_FunctionParams
		{
			// Token: 0x04032C5D RID: 207965
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C5E RID: 207966
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C5F RID: 207967
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A036 RID: 41014
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetBackTransform_FunctionParams
		{
			// Token: 0x04032C60 RID: 207968
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C61 RID: 207969
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C62 RID: 207970
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A037 RID: 41015
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetLegTransform_FunctionParams
		{
			// Token: 0x04032C63 RID: 207971
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C64 RID: 207972
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C65 RID: 207973
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A038 RID: 41016
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetWeaponTransform_FunctionParams
		{
			// Token: 0x04032C66 RID: 207974
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C67 RID: 207975
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C68 RID: 207976
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A039 RID: 41017
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetArmTransform_FunctionParams
		{
			// Token: 0x04032C69 RID: 207977
			[FieldOffset(0)]
			public FTransform InTransform;

			// Token: 0x04032C6A RID: 207978
			[FieldOffset(48)]
			public int Index;

			// Token: 0x04032C6B RID: 207979
			[FieldOffset(64)]
			public FTransform OutTransform;
		}

		// Token: 0x0200A03A RID: 41018
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 592)]
		protected ref struct __Setup_Socket_FunctionParams
		{
			// Token: 0x04032C6C RID: 207980
			[FieldOffset(0)]
			public FName SocketName;

			// Token: 0x04032C6D RID: 207981
			[FieldOffset(16)]
			public FTransform Transform;

			// Token: 0x04032C6E RID: 207982
			[FieldOffset(64)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032C6F RID: 207983
			[FieldOffset(72)]
			public byte MorphTargets;

			// Token: 0x04032C70 RID: 207984
			[FieldOffset(88)]
			public byte Materials;

			// Token: 0x04032C71 RID: 207985
			[FieldOffset(104)]
			public int index;

			// Token: 0x04032C72 RID: 207986
			[FieldOffset(108)]
			public bool Suc;

			// Token: 0x04032C73 RID: 207987
			[FieldOffset(112)]
			public IntPtr SkeletalComp;
		}

		// Token: 0x0200A03B RID: 41019
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __SetupSkeletalMeshComponents_FunctionParams
		{
			// Token: 0x04032C74 RID: 207988
			[FieldOffset(0)]
			public bool Suc;
		}

		// Token: 0x0200A03C RID: 41020
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __Setup_Role_Mesh_FunctionParams
		{
			// Token: 0x04032C75 RID: 207989
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04032C76 RID: 207990
			[FieldOffset(8)]
			public bool bIgnoreSockets;

			// Token: 0x04032C77 RID: 207991
			[FieldOffset(9)]
			public bool IsSuc;

			// Token: 0x04032C78 RID: 207992
			[FieldOffset(16)]
			public byte SkleMain;
		}
	}
}
