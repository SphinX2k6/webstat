using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.GuideSpriteDecal.Bak
{
	// Token: 0x02003B80 RID: 15232
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1508)]
	public class BP_GuideSpriteDecal_PointLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060219F7 RID: 137719 RVA: 0x0094E5DB File Offset: 0x0094C7DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GuideSpriteDecal_PointLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C");
			}
			return BP_GuideSpriteDecal_PointLight_C._ClassPtr;
		}

		// Token: 0x060219F8 RID: 137720 RVA: 0x0094E600 File Offset: 0x0094C800
		public BP_GuideSpriteDecal_PointLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_PointLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060219F9 RID: 137721 RVA: 0x0094E628 File Offset: 0x0094C828
		[NullableContext(1)]
		public BP_GuideSpriteDecal_PointLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_PointLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C20 RID: 15392
		// (get) Token: 0x060219FA RID: 137722 RVA: 0x0094E65C File Offset: 0x0094C85C
		// (set) Token: 0x060219FB RID: 137723 RVA: 0x0094E695 File Offset: 0x0094C895
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C21 RID: 15393
		// (get) Token: 0x060219FC RID: 137724 RVA: 0x0094E6B6 File Offset: 0x0094C8B6
		// (set) Token: 0x060219FD RID: 137725 RVA: 0x0094E6CA File Offset: 0x0094C8CA
		public unsafe UTextRenderComponent GuideSpline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C22 RID: 15394
		// (get) Token: 0x060219FE RID: 137726 RVA: 0x0094E6DF File Offset: 0x0094C8DF
		// (set) Token: 0x060219FF RID: 137727 RVA: 0x0094E6F3 File Offset: 0x0094C8F3
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C23 RID: 15395
		// (get) Token: 0x06021A00 RID: 137728 RVA: 0x0094E708 File Offset: 0x0094C908
		// (set) Token: 0x06021A01 RID: 137729 RVA: 0x0094E71C File Offset: 0x0094C91C
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C24 RID: 15396
		// (get) Token: 0x06021A02 RID: 137730 RVA: 0x0094E731 File Offset: 0x0094C931
		// (set) Token: 0x06021A03 RID: 137731 RVA: 0x0094E745 File Offset: 0x0094C945
		public unsafe UBoxComponent TriggerBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C25 RID: 15397
		// (get) Token: 0x06021A04 RID: 137732 RVA: 0x0094E75A File Offset: 0x0094C95A
		// (set) Token: 0x06021A05 RID: 137733 RVA: 0x0094E76E File Offset: 0x0094C96E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003C26 RID: 15398
		// (get) Token: 0x06021A06 RID: 137734 RVA: 0x0094E783 File Offset: 0x0094C983
		// (set) Token: 0x06021A07 RID: 137735 RVA: 0x0094E797 File Offset: 0x0094C997
		public unsafe FVector Collision_Box_Extent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003C27 RID: 15399
		// (get) Token: 0x06021A08 RID: 137736 RVA: 0x0094E7AC File Offset: 0x0094C9AC
		// (set) Token: 0x06021A09 RID: 137737 RVA: 0x0094E7BC File Offset: 0x0094C9BC
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003C28 RID: 15400
		// (get) Token: 0x06021A0A RID: 137738 RVA: 0x0094E7CD File Offset: 0x0094C9CD
		// (set) Token: 0x06021A0B RID: 137739 RVA: 0x0094E7DD File Offset: 0x0094C9DD
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003C29 RID: 15401
		// (get) Token: 0x06021A0C RID: 137740 RVA: 0x0094E7EE File Offset: 0x0094C9EE
		// (set) Token: 0x06021A0D RID: 137741 RVA: 0x0094E7FE File Offset: 0x0094C9FE
		public unsafe bool bShouldMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C2A RID: 15402
		// (get) Token: 0x06021A0E RID: 137742 RVA: 0x0094E80F File Offset: 0x0094CA0F
		// (set) Token: 0x06021A0F RID: 137743 RVA: 0x0094E824 File Offset: 0x0094CA24
		[Nullable(1)]
		public TSoftObjectPtr<ADecalActor> Decal
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<ADecalActor>(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_10, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17003C2B RID: 15403
		// (get) Token: 0x06021A10 RID: 137744 RVA: 0x0094E849 File Offset: 0x0094CA49
		// (set) Token: 0x06021A11 RID: 137745 RVA: 0x0094E859 File Offset: 0x0094CA59
		public unsafe float Decal_ProgressSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003C2C RID: 15404
		// (get) Token: 0x06021A12 RID: 137746 RVA: 0x0094E86A File Offset: 0x0094CA6A
		// (set) Token: 0x06021A13 RID: 137747 RVA: 0x0094E87A File Offset: 0x0094CA7A
		public unsafe float Decal_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003C2D RID: 15405
		// (get) Token: 0x06021A14 RID: 137748 RVA: 0x0094E88B File Offset: 0x0094CA8B
		// (set) Token: 0x06021A15 RID: 137749 RVA: 0x0094E89F File Offset: 0x0094CA9F
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003C2E RID: 15406
		// (get) Token: 0x06021A16 RID: 137750 RVA: 0x0094E8B4 File Offset: 0x0094CAB4
		// (set) Token: 0x06021A17 RID: 137751 RVA: 0x0094E8C4 File Offset: 0x0094CAC4
		public unsafe float Debug_Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003C2F RID: 15407
		// (get) Token: 0x06021A18 RID: 137752 RVA: 0x0094E8D5 File Offset: 0x0094CAD5
		// (set) Token: 0x06021A19 RID: 137753 RVA: 0x0094E8E5 File Offset: 0x0094CAE5
		public unsafe bool Play_Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C30 RID: 15408
		// (get) Token: 0x06021A1A RID: 137754 RVA: 0x0094E8F6 File Offset: 0x0094CAF6
		// (set) Token: 0x06021A1B RID: 137755 RVA: 0x0094E906 File Offset: 0x0094CB06
		public unsafe float MovementSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003C31 RID: 15409
		// (get) Token: 0x06021A1C RID: 137756 RVA: 0x0094E917 File Offset: 0x0094CB17
		// (set) Token: 0x06021A1D RID: 137757 RVA: 0x0094E927 File Offset: 0x0094CB27
		public unsafe float CurrentDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003C32 RID: 15410
		// (get) Token: 0x06021A1E RID: 137758 RVA: 0x0094E938 File Offset: 0x0094CB38
		// (set) Token: 0x06021A1F RID: 137759 RVA: 0x0094E94C File Offset: 0x0094CB4C
		public unsafe FLinearColor Light_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003C33 RID: 15411
		// (get) Token: 0x06021A20 RID: 137760 RVA: 0x0094E961 File Offset: 0x0094CB61
		// (set) Token: 0x06021A21 RID: 137761 RVA: 0x0094E971 File Offset: 0x0094CB71
		public unsafe float Attenuation_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003C34 RID: 15412
		// (get) Token: 0x06021A22 RID: 137762 RVA: 0x0094E982 File Offset: 0x0094CB82
		// (set) Token: 0x06021A23 RID: 137763 RVA: 0x0094E992 File Offset: 0x0094CB92
		public unsafe float LightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003C35 RID: 15413
		// (get) Token: 0x06021A24 RID: 137764 RVA: 0x0094E9A3 File Offset: 0x0094CBA3
		// (set) Token: 0x06021A25 RID: 137765 RVA: 0x0094E9B3 File Offset: 0x0094CBB3
		public unsafe float PointLight_SpeedOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003C36 RID: 15414
		// (get) Token: 0x06021A26 RID: 137766 RVA: 0x0094E9C4 File Offset: 0x0094CBC4
		// (set) Token: 0x06021A27 RID: 137767 RVA: 0x0094E9D4 File Offset: 0x0094CBD4
		public unsafe bool Debug_One
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C37 RID: 15415
		// (get) Token: 0x06021A28 RID: 137768 RVA: 0x0094E9E5 File Offset: 0x0094CBE5
		// (set) Token: 0x06021A29 RID: 137769 RVA: 0x0094E9F5 File Offset: 0x0094CBF5
		public unsafe float Progress_Point
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003C38 RID: 15416
		// (get) Token: 0x06021A2A RID: 137770 RVA: 0x0094EA06 File Offset: 0x0094CC06
		// (set) Token: 0x06021A2B RID: 137771 RVA: 0x0094EA16 File Offset: 0x0094CC16
		public unsafe float LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003C39 RID: 15417
		// (get) Token: 0x06021A2C RID: 137772 RVA: 0x0094EA27 File Offset: 0x0094CC27
		// (set) Token: 0x06021A2D RID: 137773 RVA: 0x0094EA37 File Offset: 0x0094CC37
		public unsafe float Decal_EmissiveStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06021A2E RID: 137774 RVA: 0x0094EA48 File Offset: 0x0094CC48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x06021A2F RID: 137775 RVA: 0x0094EA5C File Offset: 0x0094CC5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021A30 RID: 137776 RVA: 0x0094EA70 File Offset: 0x0094CC70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021A31 RID: 137777 RVA: 0x0094EA88 File Offset: 0x0094CC88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_47AF222149CCF672491DAAA954977259(UObject Loaded)
		{
			BP_GuideSpriteDecal_PointLight_C.__OnLoaded_47AF222149CCF672491DAAA954977259_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__OnLoaded_47AF222149CCF672491DAAA954977259_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__OnLoaded_47AF222149CCF672491DAAA954977259_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__OnLoaded_47AF222149CCF672491DAAA954977259_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__OnLoaded_47AF222149CCF672491DAAA954977259_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A32 RID: 137778 RVA: 0x0094EADD File Offset: 0x0094CCDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021A33 RID: 137779 RVA: 0x0094EAF1 File Offset: 0x0094CCF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021A34 RID: 137780 RVA: 0x0094EB08 File Offset: 0x0094CD08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A35 RID: 137781 RVA: 0x0094EB50 File Offset: 0x0094CD50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A36 RID: 137782 RVA: 0x0094EB98 File Offset: 0x0094CD98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A37 RID: 137783 RVA: 0x0094EBE0 File Offset: 0x0094CDE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A38 RID: 137784 RVA: 0x0094EC28 File Offset: 0x0094CE28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GuideSpriteDecal_PointLight(int EntryPoint)
		{
			BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A39 RID: 137785 RVA: 0x0094EC72 File Offset: 0x0094CE72
		protected BP_GuideSpriteDecal_PointLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010F1D RID: 69405
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/Bak/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C";

		// Token: 0x04010F1E RID: 69406
		private static IntPtr _ClassPtr;

		// Token: 0x04010F1F RID: 69407
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010F20 RID: 69408
		internal static int __PropertyOffset_0;

		// Token: 0x04010F21 RID: 69409
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010F22 RID: 69410
		internal static int __PropertyOffset_1;

		// Token: 0x04010F23 RID: 69411
		internal static int __PropertyOffset_2;

		// Token: 0x04010F24 RID: 69412
		internal static int __PropertyOffset_3;

		// Token: 0x04010F25 RID: 69413
		internal static int __PropertyOffset_4;

		// Token: 0x04010F26 RID: 69414
		internal static int __PropertyOffset_5;

		// Token: 0x04010F27 RID: 69415
		internal static int __PropertyOffset_6;

		// Token: 0x04010F28 RID: 69416
		internal static int __PropertyOffset_7;

		// Token: 0x04010F29 RID: 69417
		internal static int __PropertyOffset_8;

		// Token: 0x04010F2A RID: 69418
		internal static int __PropertyOffset_9;

		// Token: 0x04010F2B RID: 69419
		internal static int __PropertyOffset_10;

		// Token: 0x04010F2C RID: 69420
		internal static int __PropertyOffset_11;

		// Token: 0x04010F2D RID: 69421
		internal static int __PropertyOffset_12;

		// Token: 0x04010F2E RID: 69422
		internal static int __PropertyOffset_13;

		// Token: 0x04010F2F RID: 69423
		internal static int __PropertyOffset_14;

		// Token: 0x04010F30 RID: 69424
		internal static int __PropertyOffset_15;

		// Token: 0x04010F31 RID: 69425
		internal static int __PropertyOffset_16;

		// Token: 0x04010F32 RID: 69426
		internal static int __PropertyOffset_17;

		// Token: 0x04010F33 RID: 69427
		internal static int __PropertyOffset_18;

		// Token: 0x04010F34 RID: 69428
		internal static int __PropertyOffset_19;

		// Token: 0x04010F35 RID: 69429
		internal static int __PropertyOffset_20;

		// Token: 0x04010F36 RID: 69430
		internal static int __PropertyOffset_21;

		// Token: 0x04010F37 RID: 69431
		internal static int __PropertyOffset_22;

		// Token: 0x04010F38 RID: 69432
		internal static int __PropertyOffset_23;

		// Token: 0x04010F39 RID: 69433
		internal static int __PropertyOffset_24;

		// Token: 0x04010F3A RID: 69434
		internal static int __PropertyOffset_25;

		// Token: 0x04010F3B RID: 69435
		private static IntPtr __Initialize_NativeFunctionPtr;

		// Token: 0x04010F3C RID: 69436
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010F3D RID: 69437
		private static IntPtr __OnLoaded_47AF222149CCF672491DAAA954977259_NativeFunctionPtr;

		// Token: 0x04010F3E RID: 69438
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010F3F RID: 69439
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010F40 RID: 69440
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010F41 RID: 69441
		private static IntPtr __ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr;

		// Token: 0x02009B09 RID: 39689
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_47AF222149CCF672491DAAA954977259_FunctionParams
		{
			// Token: 0x040322B1 RID: 205489
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009B0A RID: 39690
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322B2 RID: 205490
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B0B RID: 39691
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322B3 RID: 205491
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B0C RID: 39692
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams
		{
			// Token: 0x040322B4 RID: 205492
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
