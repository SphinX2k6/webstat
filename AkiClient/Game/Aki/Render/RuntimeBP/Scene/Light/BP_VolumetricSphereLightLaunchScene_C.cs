using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA7 RID: 15015
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightLaunchScene.BP_VolumetricSphereLightLaunchScene_C")]
	[UnrealStructLayout(1176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1176)]
	public class BP_VolumetricSphereLightLaunchScene_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FE75 RID: 130677 RVA: 0x0091D210 File Offset: 0x0091B410
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricSphereLightLaunchScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightLaunchScene.BP_VolumetricSphereLightLaunchScene_C");
			}
			return BP_VolumetricSphereLightLaunchScene_C._ClassPtr;
		}

		// Token: 0x0601FE76 RID: 130678 RVA: 0x0091D234 File Offset: 0x0091B434
		public BP_VolumetricSphereLightLaunchScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLightLaunchScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FE77 RID: 130679 RVA: 0x0091D25C File Offset: 0x0091B45C
		[NullableContext(1)]
		public BP_VolumetricSphereLightLaunchScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLightLaunchScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170032D1 RID: 13009
		// (get) Token: 0x0601FE78 RID: 130680 RVA: 0x0091D290 File Offset: 0x0091B490
		// (set) Token: 0x0601FE79 RID: 130681 RVA: 0x0091D2C9 File Offset: 0x0091B4C9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170032D2 RID: 13010
		// (get) Token: 0x0601FE7A RID: 130682 RVA: 0x0091D2EA File Offset: 0x0091B4EA
		// (set) Token: 0x0601FE7B RID: 130683 RVA: 0x0091D2FE File Offset: 0x0091B4FE
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170032D3 RID: 13011
		// (get) Token: 0x0601FE7C RID: 130684 RVA: 0x0091D313 File Offset: 0x0091B513
		// (set) Token: 0x0601FE7D RID: 130685 RVA: 0x0091D327 File Offset: 0x0091B527
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170032D4 RID: 13012
		// (get) Token: 0x0601FE7E RID: 130686 RVA: 0x0091D33C File Offset: 0x0091B53C
		// (set) Token: 0x0601FE7F RID: 130687 RVA: 0x0091D350 File Offset: 0x0091B550
		public unsafe UStaticMesh SphereLightStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170032D5 RID: 13013
		// (get) Token: 0x0601FE80 RID: 130688 RVA: 0x0091D365 File Offset: 0x0091B565
		// (set) Token: 0x0601FE81 RID: 130689 RVA: 0x0091D379 File Offset: 0x0091B579
		public unsafe UMaterialInstance SphereLightMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170032D6 RID: 13014
		// (get) Token: 0x0601FE82 RID: 130690 RVA: 0x0091D38E File Offset: 0x0091B58E
		// (set) Token: 0x0601FE83 RID: 130691 RVA: 0x0091D39E File Offset: 0x0091B59E
		public unsafe bool IsReverseCulling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032D7 RID: 13015
		// (get) Token: 0x0601FE84 RID: 130692 RVA: 0x0091D3AF File Offset: 0x0091B5AF
		// (set) Token: 0x0601FE85 RID: 130693 RVA: 0x0091D3BF File Offset: 0x0091B5BF
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032D8 RID: 13016
		// (get) Token: 0x0601FE86 RID: 130694 RVA: 0x0091D3D0 File Offset: 0x0091B5D0
		// (set) Token: 0x0601FE87 RID: 130695 RVA: 0x0091D3E0 File Offset: 0x0091B5E0
		public unsafe bool OutDistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032D9 RID: 13017
		// (get) Token: 0x0601FE88 RID: 130696 RVA: 0x0091D3F1 File Offset: 0x0091B5F1
		// (set) Token: 0x0601FE89 RID: 130697 RVA: 0x0091D401 File Offset: 0x0091B601
		public unsafe bool ApplyFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032DA RID: 13018
		// (get) Token: 0x0601FE8A RID: 130698 RVA: 0x0091D412 File Offset: 0x0091B612
		// (set) Token: 0x0601FE8B RID: 130699 RVA: 0x0091D422 File Offset: 0x0091B622
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170032DB RID: 13019
		// (get) Token: 0x0601FE8C RID: 130700 RVA: 0x0091D433 File Offset: 0x0091B633
		// (set) Token: 0x0601FE8D RID: 130701 RVA: 0x0091D443 File Offset: 0x0091B643
		public unsafe float FogPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170032DC RID: 13020
		// (get) Token: 0x0601FE8E RID: 130702 RVA: 0x0091D454 File Offset: 0x0091B654
		// (set) Token: 0x0601FE8F RID: 130703 RVA: 0x0091D464 File Offset: 0x0091B664
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170032DD RID: 13021
		// (get) Token: 0x0601FE90 RID: 130704 RVA: 0x0091D475 File Offset: 0x0091B675
		// (set) Token: 0x0601FE91 RID: 130705 RVA: 0x0091D485 File Offset: 0x0091B685
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170032DE RID: 13022
		// (get) Token: 0x0601FE92 RID: 130706 RVA: 0x0091D496 File Offset: 0x0091B696
		// (set) Token: 0x0601FE93 RID: 130707 RVA: 0x0091D4AA File Offset: 0x0091B6AA
		public unsafe FLinearColor InsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170032DF RID: 13023
		// (get) Token: 0x0601FE94 RID: 130708 RVA: 0x0091D4BF File Offset: 0x0091B6BF
		// (set) Token: 0x0601FE95 RID: 130709 RVA: 0x0091D4D3 File Offset: 0x0091B6D3
		public unsafe FLinearColor OutSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170032E0 RID: 13024
		// (get) Token: 0x0601FE96 RID: 130710 RVA: 0x0091D4E8 File Offset: 0x0091B6E8
		// (set) Token: 0x0601FE97 RID: 130711 RVA: 0x0091D4F8 File Offset: 0x0091B6F8
		public unsafe float SphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170032E1 RID: 13025
		// (get) Token: 0x0601FE98 RID: 130712 RVA: 0x0091D509 File Offset: 0x0091B709
		// (set) Token: 0x0601FE99 RID: 130713 RVA: 0x0091D519 File Offset: 0x0091B719
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170032E2 RID: 13026
		// (get) Token: 0x0601FE9A RID: 130714 RVA: 0x0091D52A File Offset: 0x0091B72A
		// (set) Token: 0x0601FE9B RID: 130715 RVA: 0x0091D53A File Offset: 0x0091B73A
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170032E3 RID: 13027
		// (get) Token: 0x0601FE9C RID: 130716 RVA: 0x0091D54B File Offset: 0x0091B74B
		// (set) Token: 0x0601FE9D RID: 130717 RVA: 0x0091D55B File Offset: 0x0091B75B
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170032E4 RID: 13028
		// (get) Token: 0x0601FE9E RID: 130718 RVA: 0x0091D56C File Offset: 0x0091B76C
		// (set) Token: 0x0601FE9F RID: 130719 RVA: 0x0091D57C File Offset: 0x0091B77C
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170032E5 RID: 13029
		// (get) Token: 0x0601FEA0 RID: 130720 RVA: 0x0091D58D File Offset: 0x0091B78D
		// (set) Token: 0x0601FEA1 RID: 130721 RVA: 0x0091D5A1 File Offset: 0x0091B7A1
		public unsafe UMaterialInstanceDynamic MaterialInstanceDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170032E6 RID: 13030
		// (get) Token: 0x0601FEA2 RID: 130722 RVA: 0x0091D5B6 File Offset: 0x0091B7B6
		// (set) Token: 0x0601FEA3 RID: 130723 RVA: 0x0091D5CA File Offset: 0x0091B7CA
		public unsafe UMaterialInstance SphereLightMatWithOutDF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170032E7 RID: 13031
		// (get) Token: 0x0601FEA4 RID: 130724 RVA: 0x0091D5DF File Offset: 0x0091B7DF
		// (set) Token: 0x0601FEA5 RID: 130725 RVA: 0x0091D5F3 File Offset: 0x0091B7F3
		public unsafe UMaterialInstance SphereLightMatWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170032E8 RID: 13032
		// (get) Token: 0x0601FEA6 RID: 130726 RVA: 0x0091D608 File Offset: 0x0091B808
		// (set) Token: 0x0601FEA7 RID: 130727 RVA: 0x0091D61C File Offset: 0x0091B81C
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLightLaunchScene_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x0601FEA8 RID: 130728 RVA: 0x0091D631 File Offset: 0x0091B831
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumetricSphereLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__UpdateVolumetricSphereLight_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEA9 RID: 130729 RVA: 0x0091D645 File Offset: 0x0091B845
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEAA RID: 130730 RVA: 0x0091D659 File Offset: 0x0091B859
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FEAB RID: 130731 RVA: 0x0091D66E File Offset: 0x0091B86E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FEAC RID: 130732 RVA: 0x0091D682 File Offset: 0x0091B882
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FEAD RID: 130733 RVA: 0x0091D698 File Offset: 0x0091B898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene(int EntryPoint)
		{
			BP_VolumetricSphereLightLaunchScene_C.__ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_FunctionParams* ptr = stackalloc BP_VolumetricSphereLightLaunchScene_C.__ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLightLaunchScene_C.__ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLightLaunchScene_C.__ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLightLaunchScene_C.__ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FEAE RID: 130734 RVA: 0x0091D6DF File Offset: 0x0091B8DF
		protected BP_VolumetricSphereLightLaunchScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FE16 RID: 65046
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLightLaunchScene.BP_VolumetricSphereLightLaunchScene_C";

		// Token: 0x0400FE17 RID: 65047
		private static IntPtr _ClassPtr;

		// Token: 0x0400FE18 RID: 65048
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FE19 RID: 65049
		internal static int __PropertyOffset_0;

		// Token: 0x0400FE1A RID: 65050
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FE1B RID: 65051
		internal static int __PropertyOffset_1;

		// Token: 0x0400FE1C RID: 65052
		internal static int __PropertyOffset_2;

		// Token: 0x0400FE1D RID: 65053
		internal static int __PropertyOffset_3;

		// Token: 0x0400FE1E RID: 65054
		internal static int __PropertyOffset_4;

		// Token: 0x0400FE1F RID: 65055
		internal static int __PropertyOffset_5;

		// Token: 0x0400FE20 RID: 65056
		internal static int __PropertyOffset_6;

		// Token: 0x0400FE21 RID: 65057
		internal static int __PropertyOffset_7;

		// Token: 0x0400FE22 RID: 65058
		internal static int __PropertyOffset_8;

		// Token: 0x0400FE23 RID: 65059
		internal static int __PropertyOffset_9;

		// Token: 0x0400FE24 RID: 65060
		internal static int __PropertyOffset_10;

		// Token: 0x0400FE25 RID: 65061
		internal static int __PropertyOffset_11;

		// Token: 0x0400FE26 RID: 65062
		internal static int __PropertyOffset_12;

		// Token: 0x0400FE27 RID: 65063
		internal static int __PropertyOffset_13;

		// Token: 0x0400FE28 RID: 65064
		internal static int __PropertyOffset_14;

		// Token: 0x0400FE29 RID: 65065
		internal static int __PropertyOffset_15;

		// Token: 0x0400FE2A RID: 65066
		internal static int __PropertyOffset_16;

		// Token: 0x0400FE2B RID: 65067
		internal static int __PropertyOffset_17;

		// Token: 0x0400FE2C RID: 65068
		internal static int __PropertyOffset_18;

		// Token: 0x0400FE2D RID: 65069
		internal static int __PropertyOffset_19;

		// Token: 0x0400FE2E RID: 65070
		internal static int __PropertyOffset_20;

		// Token: 0x0400FE2F RID: 65071
		internal static int __PropertyOffset_21;

		// Token: 0x0400FE30 RID: 65072
		internal static int __PropertyOffset_22;

		// Token: 0x0400FE31 RID: 65073
		internal static int __PropertyOffset_23;

		// Token: 0x0400FE32 RID: 65074
		private static IntPtr __UpdateVolumetricSphereLight_NativeFunctionPtr;

		// Token: 0x0400FE33 RID: 65075
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FE34 RID: 65076
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FE35 RID: 65077
		private static IntPtr __ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_NativeFunctionPtr;

		// Token: 0x02009934 RID: 39220
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricSphereLightLaunchScene_FunctionParams
		{
			// Token: 0x04031F93 RID: 204691
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
