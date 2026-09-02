using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA6 RID: 15014
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLight.BP_VolumetricLight_C")]
	[UnrealStructLayout(1208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1208)]
	public class BP_VolumetricLight_C : AKuroLightActorBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FE34 RID: 130612 RVA: 0x0091CC5D File Offset: 0x0091AE5D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLight.BP_VolumetricLight_C");
			}
			return BP_VolumetricLight_C._ClassPtr;
		}

		// Token: 0x0601FE35 RID: 130613 RVA: 0x0091CC84 File Offset: 0x0091AE84
		public BP_VolumetricLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FE36 RID: 130614 RVA: 0x0091CCAC File Offset: 0x0091AEAC
		[NullableContext(1)]
		public BP_VolumetricLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170032B5 RID: 12981
		// (get) Token: 0x0601FE37 RID: 130615 RVA: 0x0091CCE0 File Offset: 0x0091AEE0
		// (set) Token: 0x0601FE38 RID: 130616 RVA: 0x0091CD19 File Offset: 0x0091AF19
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170032B6 RID: 12982
		// (get) Token: 0x0601FE39 RID: 130617 RVA: 0x0091CD3A File Offset: 0x0091AF3A
		// (set) Token: 0x0601FE3A RID: 130618 RVA: 0x0091CD4E File Offset: 0x0091AF4E
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170032B7 RID: 12983
		// (get) Token: 0x0601FE3B RID: 130619 RVA: 0x0091CD63 File Offset: 0x0091AF63
		// (set) Token: 0x0601FE3C RID: 130620 RVA: 0x0091CD77 File Offset: 0x0091AF77
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170032B8 RID: 12984
		// (get) Token: 0x0601FE3D RID: 130621 RVA: 0x0091CD8C File Offset: 0x0091AF8C
		// (set) Token: 0x0601FE3E RID: 130622 RVA: 0x0091CDA0 File Offset: 0x0091AFA0
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170032B9 RID: 12985
		// (get) Token: 0x0601FE3F RID: 130623 RVA: 0x0091CDB5 File Offset: 0x0091AFB5
		// (set) Token: 0x0601FE40 RID: 130624 RVA: 0x0091CDC9 File Offset: 0x0091AFC9
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170032BA RID: 12986
		// (get) Token: 0x0601FE41 RID: 130625 RVA: 0x0091CDDE File Offset: 0x0091AFDE
		// (set) Token: 0x0601FE42 RID: 130626 RVA: 0x0091CDF2 File Offset: 0x0091AFF2
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170032BB RID: 12987
		// (get) Token: 0x0601FE43 RID: 130627 RVA: 0x0091CE07 File Offset: 0x0091B007
		// (set) Token: 0x0601FE44 RID: 130628 RVA: 0x0091CE1B File Offset: 0x0091B01B
		public unsafe UMaterialInstance MaterialInstanceBT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170032BC RID: 12988
		// (get) Token: 0x0601FE45 RID: 130629 RVA: 0x0091CE30 File Offset: 0x0091B030
		// (set) Token: 0x0601FE46 RID: 130630 RVA: 0x0091CE44 File Offset: 0x0091B044
		public unsafe UMaterialInstance MaterialInstanceT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170032BD RID: 12989
		// (get) Token: 0x0601FE47 RID: 130631 RVA: 0x0091CE59 File Offset: 0x0091B059
		// (set) Token: 0x0601FE48 RID: 130632 RVA: 0x0091CE69 File Offset: 0x0091B069
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032BE RID: 12990
		// (get) Token: 0x0601FE49 RID: 130633 RVA: 0x0091CE7A File Offset: 0x0091B07A
		// (set) Token: 0x0601FE4A RID: 130634 RVA: 0x0091CE8A File Offset: 0x0091B08A
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032BF RID: 12991
		// (get) Token: 0x0601FE4B RID: 130635 RVA: 0x0091CE9B File Offset: 0x0091B09B
		// (set) Token: 0x0601FE4C RID: 130636 RVA: 0x0091CEAB File Offset: 0x0091B0AB
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032C0 RID: 12992
		// (get) Token: 0x0601FE4D RID: 130637 RVA: 0x0091CEBC File Offset: 0x0091B0BC
		// (set) Token: 0x0601FE4E RID: 130638 RVA: 0x0091CECC File Offset: 0x0091B0CC
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170032C1 RID: 12993
		// (get) Token: 0x0601FE4F RID: 130639 RVA: 0x0091CEDD File Offset: 0x0091B0DD
		// (set) Token: 0x0601FE50 RID: 130640 RVA: 0x0091CEED File Offset: 0x0091B0ED
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170032C2 RID: 12994
		// (get) Token: 0x0601FE51 RID: 130641 RVA: 0x0091CEFE File Offset: 0x0091B0FE
		// (set) Token: 0x0601FE52 RID: 130642 RVA: 0x0091CF0E File Offset: 0x0091B10E
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170032C3 RID: 12995
		// (get) Token: 0x0601FE53 RID: 130643 RVA: 0x0091CF1F File Offset: 0x0091B11F
		// (set) Token: 0x0601FE54 RID: 130644 RVA: 0x0091CF2F File Offset: 0x0091B12F
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170032C4 RID: 12996
		// (get) Token: 0x0601FE55 RID: 130645 RVA: 0x0091CF40 File Offset: 0x0091B140
		// (set) Token: 0x0601FE56 RID: 130646 RVA: 0x0091CF54 File Offset: 0x0091B154
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170032C5 RID: 12997
		// (get) Token: 0x0601FE57 RID: 130647 RVA: 0x0091CF69 File Offset: 0x0091B169
		// (set) Token: 0x0601FE58 RID: 130648 RVA: 0x0091CF7D File Offset: 0x0091B17D
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170032C6 RID: 12998
		// (get) Token: 0x0601FE59 RID: 130649 RVA: 0x0091CF92 File Offset: 0x0091B192
		// (set) Token: 0x0601FE5A RID: 130650 RVA: 0x0091CFA2 File Offset: 0x0091B1A2
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170032C7 RID: 12999
		// (get) Token: 0x0601FE5B RID: 130651 RVA: 0x0091CFB3 File Offset: 0x0091B1B3
		// (set) Token: 0x0601FE5C RID: 130652 RVA: 0x0091CFC3 File Offset: 0x0091B1C3
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170032C8 RID: 13000
		// (get) Token: 0x0601FE5D RID: 130653 RVA: 0x0091CFD4 File Offset: 0x0091B1D4
		// (set) Token: 0x0601FE5E RID: 130654 RVA: 0x0091CFE4 File Offset: 0x0091B1E4
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170032C9 RID: 13001
		// (get) Token: 0x0601FE5F RID: 130655 RVA: 0x0091CFF5 File Offset: 0x0091B1F5
		// (set) Token: 0x0601FE60 RID: 130656 RVA: 0x0091D005 File Offset: 0x0091B205
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170032CA RID: 13002
		// (get) Token: 0x0601FE61 RID: 130657 RVA: 0x0091D016 File Offset: 0x0091B216
		// (set) Token: 0x0601FE62 RID: 130658 RVA: 0x0091D026 File Offset: 0x0091B226
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170032CB RID: 13003
		// (get) Token: 0x0601FE63 RID: 130659 RVA: 0x0091D037 File Offset: 0x0091B237
		// (set) Token: 0x0601FE64 RID: 130660 RVA: 0x0091D047 File Offset: 0x0091B247
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170032CC RID: 13004
		// (get) Token: 0x0601FE65 RID: 130661 RVA: 0x0091D058 File Offset: 0x0091B258
		// (set) Token: 0x0601FE66 RID: 130662 RVA: 0x0091D068 File Offset: 0x0091B268
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170032CD RID: 13005
		// (get) Token: 0x0601FE67 RID: 130663 RVA: 0x0091D079 File Offset: 0x0091B279
		// (set) Token: 0x0601FE68 RID: 130664 RVA: 0x0091D089 File Offset: 0x0091B289
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170032CE RID: 13006
		// (get) Token: 0x0601FE69 RID: 130665 RVA: 0x0091D09A File Offset: 0x0091B29A
		// (set) Token: 0x0601FE6A RID: 130666 RVA: 0x0091D0AA File Offset: 0x0091B2AA
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170032CF RID: 13007
		// (get) Token: 0x0601FE6B RID: 130667 RVA: 0x0091D0BB File Offset: 0x0091B2BB
		// (set) Token: 0x0601FE6C RID: 130668 RVA: 0x0091D0CB File Offset: 0x0091B2CB
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLight_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170032D0 RID: 13008
		// (get) Token: 0x0601FE6D RID: 130669 RVA: 0x0091D0DC File Offset: 0x0091B2DC
		// (set) Token: 0x0601FE6E RID: 130670 RVA: 0x0091D0F0 File Offset: 0x0091B2F0
		public unsafe UMaterialInstanceDynamic DynMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLight_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x0601FE6F RID: 130671 RVA: 0x0091D105 File Offset: 0x0091B305
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FE70 RID: 130672 RVA: 0x0091D119 File Offset: 0x0091B319
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FE71 RID: 130673 RVA: 0x0091D130 File Offset: 0x0091B330
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetLightIntensityScale(float ScaleFactor)
		{
			BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FE72 RID: 130674 RVA: 0x0091D178 File Offset: 0x0091B378
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void SetLightIntensityScale_Implementation(float ScaleFactor)
		{
			BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricLight_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLight_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FE73 RID: 130675 RVA: 0x0091D1C0 File Offset: 0x0091B3C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricLight(int EntryPoint)
		{
			BP_VolumetricLight_C.__ExecuteUbergraph_BP_VolumetricLight_FunctionParams* ptr = stackalloc BP_VolumetricLight_C.__ExecuteUbergraph_BP_VolumetricLight_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_VolumetricLight_C.__ExecuteUbergraph_BP_VolumetricLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricLight_C.__ExecuteUbergraph_BP_VolumetricLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLight_C.__ExecuteUbergraph_BP_VolumetricLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FE74 RID: 130676 RVA: 0x0091D207 File Offset: 0x0091B407
		protected BP_VolumetricLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FDF3 RID: 65011
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLight.BP_VolumetricLight_C";

		// Token: 0x0400FDF4 RID: 65012
		private static IntPtr _ClassPtr;

		// Token: 0x0400FDF5 RID: 65013
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FDF6 RID: 65014
		internal static int __PropertyOffset_0;

		// Token: 0x0400FDF7 RID: 65015
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FDF8 RID: 65016
		internal static int __PropertyOffset_1;

		// Token: 0x0400FDF9 RID: 65017
		internal static int __PropertyOffset_2;

		// Token: 0x0400FDFA RID: 65018
		internal static int __PropertyOffset_3;

		// Token: 0x0400FDFB RID: 65019
		internal static int __PropertyOffset_4;

		// Token: 0x0400FDFC RID: 65020
		internal static int __PropertyOffset_5;

		// Token: 0x0400FDFD RID: 65021
		internal static int __PropertyOffset_6;

		// Token: 0x0400FDFE RID: 65022
		internal static int __PropertyOffset_7;

		// Token: 0x0400FDFF RID: 65023
		internal static int __PropertyOffset_8;

		// Token: 0x0400FE00 RID: 65024
		internal static int __PropertyOffset_9;

		// Token: 0x0400FE01 RID: 65025
		internal static int __PropertyOffset_10;

		// Token: 0x0400FE02 RID: 65026
		internal static int __PropertyOffset_11;

		// Token: 0x0400FE03 RID: 65027
		internal static int __PropertyOffset_12;

		// Token: 0x0400FE04 RID: 65028
		internal static int __PropertyOffset_13;

		// Token: 0x0400FE05 RID: 65029
		internal static int __PropertyOffset_14;

		// Token: 0x0400FE06 RID: 65030
		internal static int __PropertyOffset_15;

		// Token: 0x0400FE07 RID: 65031
		internal static int __PropertyOffset_16;

		// Token: 0x0400FE08 RID: 65032
		internal static int __PropertyOffset_17;

		// Token: 0x0400FE09 RID: 65033
		internal static int __PropertyOffset_18;

		// Token: 0x0400FE0A RID: 65034
		internal static int __PropertyOffset_19;

		// Token: 0x0400FE0B RID: 65035
		internal static int __PropertyOffset_20;

		// Token: 0x0400FE0C RID: 65036
		internal static int __PropertyOffset_21;

		// Token: 0x0400FE0D RID: 65037
		internal static int __PropertyOffset_22;

		// Token: 0x0400FE0E RID: 65038
		internal static int __PropertyOffset_23;

		// Token: 0x0400FE0F RID: 65039
		internal static int __PropertyOffset_24;

		// Token: 0x0400FE10 RID: 65040
		internal static int __PropertyOffset_25;

		// Token: 0x0400FE11 RID: 65041
		internal static int __PropertyOffset_26;

		// Token: 0x0400FE12 RID: 65042
		internal static int __PropertyOffset_27;

		// Token: 0x0400FE13 RID: 65043
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FE14 RID: 65044
		private static IntPtr __SetLightIntensityScale_NativeFunctionPtr;

		// Token: 0x0400FE15 RID: 65045
		private static IntPtr __ExecuteUbergraph_BP_VolumetricLight_NativeFunctionPtr;

		// Token: 0x02009932 RID: 39218
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __SetLightIntensityScale_FunctionParams
		{
			// Token: 0x04031F91 RID: 204689
			[FieldOffset(0)]
			public float ScaleFactor;
		}

		// Token: 0x02009933 RID: 39219
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricLight_FunctionParams
		{
			// Token: 0x04031F92 RID: 204690
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
