using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.GuideSpriteDecal
{
	// Token: 0x02003B7E RID: 15230
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1537)]
	public class BP_GuideSpriteDecal_PointLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021983 RID: 137603 RVA: 0x0094D8EB File Offset: 0x0094BAEB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GuideSpriteDecal_PointLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C");
			}
			return BP_GuideSpriteDecal_PointLight_C._ClassPtr;
		}

		// Token: 0x06021984 RID: 137604 RVA: 0x0094D910 File Offset: 0x0094BB10
		public BP_GuideSpriteDecal_PointLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_PointLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021985 RID: 137605 RVA: 0x0094D938 File Offset: 0x0094BB38
		[NullableContext(1)]
		public BP_GuideSpriteDecal_PointLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GuideSpriteDecal_PointLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BF6 RID: 15350
		// (get) Token: 0x06021986 RID: 137606 RVA: 0x0094D96C File Offset: 0x0094BB6C
		// (set) Token: 0x06021987 RID: 137607 RVA: 0x0094D9A5 File Offset: 0x0094BBA5
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

		// Token: 0x17003BF7 RID: 15351
		// (get) Token: 0x06021988 RID: 137608 RVA: 0x0094D9C6 File Offset: 0x0094BBC6
		// (set) Token: 0x06021989 RID: 137609 RVA: 0x0094D9DA File Offset: 0x0094BBDA
		public unsafe UDecalComponent Decal1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BF8 RID: 15352
		// (get) Token: 0x0602198A RID: 137610 RVA: 0x0094D9EF File Offset: 0x0094BBEF
		// (set) Token: 0x0602198B RID: 137611 RVA: 0x0094DA03 File Offset: 0x0094BC03
		public unsafe UTextRenderComponent GuideSpline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003BF9 RID: 15353
		// (get) Token: 0x0602198C RID: 137612 RVA: 0x0094DA18 File Offset: 0x0094BC18
		// (set) Token: 0x0602198D RID: 137613 RVA: 0x0094DA2C File Offset: 0x0094BC2C
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003BFA RID: 15354
		// (get) Token: 0x0602198E RID: 137614 RVA: 0x0094DA41 File Offset: 0x0094BC41
		// (set) Token: 0x0602198F RID: 137615 RVA: 0x0094DA55 File Offset: 0x0094BC55
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003BFB RID: 15355
		// (get) Token: 0x06021990 RID: 137616 RVA: 0x0094DA6A File Offset: 0x0094BC6A
		// (set) Token: 0x06021991 RID: 137617 RVA: 0x0094DA7E File Offset: 0x0094BC7E
		public unsafe UBoxComponent TriggerBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003BFC RID: 15356
		// (get) Token: 0x06021992 RID: 137618 RVA: 0x0094DA93 File Offset: 0x0094BC93
		// (set) Token: 0x06021993 RID: 137619 RVA: 0x0094DAA7 File Offset: 0x0094BCA7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003BFD RID: 15357
		// (get) Token: 0x06021994 RID: 137620 RVA: 0x0094DABC File Offset: 0x0094BCBC
		// (set) Token: 0x06021995 RID: 137621 RVA: 0x0094DAD0 File Offset: 0x0094BCD0
		public unsafe FVector Collision_Box_Extent
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

		// Token: 0x17003BFE RID: 15358
		// (get) Token: 0x06021996 RID: 137622 RVA: 0x0094DAE5 File Offset: 0x0094BCE5
		// (set) Token: 0x06021997 RID: 137623 RVA: 0x0094DAF5 File Offset: 0x0094BCF5
		public unsafe float Progress
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

		// Token: 0x17003BFF RID: 15359
		// (get) Token: 0x06021998 RID: 137624 RVA: 0x0094DB06 File Offset: 0x0094BD06
		// (set) Token: 0x06021999 RID: 137625 RVA: 0x0094DB16 File Offset: 0x0094BD16
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003C00 RID: 15360
		// (get) Token: 0x0602199A RID: 137626 RVA: 0x0094DB27 File Offset: 0x0094BD27
		// (set) Token: 0x0602199B RID: 137627 RVA: 0x0094DB37 File Offset: 0x0094BD37
		public unsafe bool bShouldMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C01 RID: 15361
		// (get) Token: 0x0602199C RID: 137628 RVA: 0x0094DB48 File Offset: 0x0094BD48
		// (set) Token: 0x0602199D RID: 137629 RVA: 0x0094DB5D File Offset: 0x0094BD5D
		[Nullable(1)]
		public TSoftObjectPtr<ADecalActor> Decal
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<ADecalActor>(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_11, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17003C02 RID: 15362
		// (get) Token: 0x0602199E RID: 137630 RVA: 0x0094DB82 File Offset: 0x0094BD82
		// (set) Token: 0x0602199F RID: 137631 RVA: 0x0094DB92 File Offset: 0x0094BD92
		public unsafe float Decal_ProgressSpeed
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

		// Token: 0x17003C03 RID: 15363
		// (get) Token: 0x060219A0 RID: 137632 RVA: 0x0094DBA3 File Offset: 0x0094BDA3
		// (set) Token: 0x060219A1 RID: 137633 RVA: 0x0094DBB3 File Offset: 0x0094BDB3
		public unsafe float Decal_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003C04 RID: 15364
		// (get) Token: 0x060219A2 RID: 137634 RVA: 0x0094DBC4 File Offset: 0x0094BDC4
		// (set) Token: 0x060219A3 RID: 137635 RVA: 0x0094DBD8 File Offset: 0x0094BDD8
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003C05 RID: 15365
		// (get) Token: 0x060219A4 RID: 137636 RVA: 0x0094DBED File Offset: 0x0094BDED
		// (set) Token: 0x060219A5 RID: 137637 RVA: 0x0094DBFD File Offset: 0x0094BDFD
		public unsafe float Debug_Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003C06 RID: 15366
		// (get) Token: 0x060219A6 RID: 137638 RVA: 0x0094DC0E File Offset: 0x0094BE0E
		// (set) Token: 0x060219A7 RID: 137639 RVA: 0x0094DC1E File Offset: 0x0094BE1E
		public unsafe bool Play_Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C07 RID: 15367
		// (get) Token: 0x060219A8 RID: 137640 RVA: 0x0094DC2F File Offset: 0x0094BE2F
		// (set) Token: 0x060219A9 RID: 137641 RVA: 0x0094DC3F File Offset: 0x0094BE3F
		public unsafe float MovementSpeed
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

		// Token: 0x17003C08 RID: 15368
		// (get) Token: 0x060219AA RID: 137642 RVA: 0x0094DC50 File Offset: 0x0094BE50
		// (set) Token: 0x060219AB RID: 137643 RVA: 0x0094DC60 File Offset: 0x0094BE60
		public unsafe float CurrentDistance
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

		// Token: 0x17003C09 RID: 15369
		// (get) Token: 0x060219AC RID: 137644 RVA: 0x0094DC71 File Offset: 0x0094BE71
		// (set) Token: 0x060219AD RID: 137645 RVA: 0x0094DC85 File Offset: 0x0094BE85
		public unsafe FLinearColor Light_Color
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

		// Token: 0x17003C0A RID: 15370
		// (get) Token: 0x060219AE RID: 137646 RVA: 0x0094DC9A File Offset: 0x0094BE9A
		// (set) Token: 0x060219AF RID: 137647 RVA: 0x0094DCAA File Offset: 0x0094BEAA
		public unsafe float Attenuation_Radius
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

		// Token: 0x17003C0B RID: 15371
		// (get) Token: 0x060219B0 RID: 137648 RVA: 0x0094DCBB File Offset: 0x0094BEBB
		// (set) Token: 0x060219B1 RID: 137649 RVA: 0x0094DCCB File Offset: 0x0094BECB
		public unsafe float LightIntensity
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

		// Token: 0x17003C0C RID: 15372
		// (get) Token: 0x060219B2 RID: 137650 RVA: 0x0094DCDC File Offset: 0x0094BEDC
		// (set) Token: 0x060219B3 RID: 137651 RVA: 0x0094DCEC File Offset: 0x0094BEEC
		public unsafe float PointLight_SpeedOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003C0D RID: 15373
		// (get) Token: 0x060219B4 RID: 137652 RVA: 0x0094DCFD File Offset: 0x0094BEFD
		// (set) Token: 0x060219B5 RID: 137653 RVA: 0x0094DD0D File Offset: 0x0094BF0D
		public unsafe bool Debug_One
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C0E RID: 15374
		// (get) Token: 0x060219B6 RID: 137654 RVA: 0x0094DD1E File Offset: 0x0094BF1E
		// (set) Token: 0x060219B7 RID: 137655 RVA: 0x0094DD2E File Offset: 0x0094BF2E
		public unsafe float Progress_Point
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

		// Token: 0x17003C0F RID: 15375
		// (get) Token: 0x060219B8 RID: 137656 RVA: 0x0094DD3F File Offset: 0x0094BF3F
		// (set) Token: 0x060219B9 RID: 137657 RVA: 0x0094DD4F File Offset: 0x0094BF4F
		public unsafe float LightColor
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

		// Token: 0x17003C10 RID: 15376
		// (get) Token: 0x060219BA RID: 137658 RVA: 0x0094DD60 File Offset: 0x0094BF60
		// (set) Token: 0x060219BB RID: 137659 RVA: 0x0094DD70 File Offset: 0x0094BF70
		public unsafe float Decal_EmissiveStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003C11 RID: 15377
		// (get) Token: 0x060219BC RID: 137660 RVA: 0x0094DD81 File Offset: 0x0094BF81
		// (set) Token: 0x060219BD RID: 137661 RVA: 0x0094DD95 File Offset: 0x0094BF95
		public unsafe UAkAudioEvent Play_Audio_Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003C12 RID: 15378
		// (get) Token: 0x060219BE RID: 137662 RVA: 0x0094DDAA File Offset: 0x0094BFAA
		// (set) Token: 0x060219BF RID: 137663 RVA: 0x0094DDBE File Offset: 0x0094BFBE
		public unsafe UAkAudioEvent Stop_Audio_Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003C13 RID: 15379
		// (get) Token: 0x060219C0 RID: 137664 RVA: 0x0094DDD3 File Offset: 0x0094BFD3
		// (set) Token: 0x060219C1 RID: 137665 RVA: 0x0094DDE3 File Offset: 0x0094BFE3
		public unsafe bool Play_Audio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuideSpriteDecal_PointLight_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x060219C2 RID: 137666 RVA: 0x0094DDF4 File Offset: 0x0094BFF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x060219C3 RID: 137667 RVA: 0x0094DE08 File Offset: 0x0094C008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060219C4 RID: 137668 RVA: 0x0094DE1C File Offset: 0x0094C01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060219C5 RID: 137669 RVA: 0x0094DE31 File Offset: 0x0094C031
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060219C6 RID: 137670 RVA: 0x0094DE45 File Offset: 0x0094C045
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060219C7 RID: 137671 RVA: 0x0094DE5C File Offset: 0x0094C05C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219C8 RID: 137672 RVA: 0x0094DEA4 File Offset: 0x0094C0A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219C9 RID: 137673 RVA: 0x0094DEEC File Offset: 0x0094C0EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060219CA RID: 137674 RVA: 0x0094DF34 File Offset: 0x0094C134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219CB RID: 137675 RVA: 0x0094DF7C File Offset: 0x0094C17C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GuideSpriteDecal_PointLight(int EntryPoint)
		{
			BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams* ptr = stackalloc BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuideSpriteDecal_PointLight_C.__ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060219CC RID: 137676 RVA: 0x0094DFC6 File Offset: 0x0094C1C6
		protected BP_GuideSpriteDecal_PointLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010EDB RID: 69339
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/GuideSpriteDecal/BP_GuideSpriteDecal_PointLight.BP_GuideSpriteDecal_PointLight_C";

		// Token: 0x04010EDC RID: 69340
		private static IntPtr _ClassPtr;

		// Token: 0x04010EDD RID: 69341
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010EDE RID: 69342
		internal static int __PropertyOffset_0;

		// Token: 0x04010EDF RID: 69343
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010EE0 RID: 69344
		internal static int __PropertyOffset_1;

		// Token: 0x04010EE1 RID: 69345
		internal static int __PropertyOffset_2;

		// Token: 0x04010EE2 RID: 69346
		internal static int __PropertyOffset_3;

		// Token: 0x04010EE3 RID: 69347
		internal static int __PropertyOffset_4;

		// Token: 0x04010EE4 RID: 69348
		internal static int __PropertyOffset_5;

		// Token: 0x04010EE5 RID: 69349
		internal static int __PropertyOffset_6;

		// Token: 0x04010EE6 RID: 69350
		internal static int __PropertyOffset_7;

		// Token: 0x04010EE7 RID: 69351
		internal static int __PropertyOffset_8;

		// Token: 0x04010EE8 RID: 69352
		internal static int __PropertyOffset_9;

		// Token: 0x04010EE9 RID: 69353
		internal static int __PropertyOffset_10;

		// Token: 0x04010EEA RID: 69354
		internal static int __PropertyOffset_11;

		// Token: 0x04010EEB RID: 69355
		internal static int __PropertyOffset_12;

		// Token: 0x04010EEC RID: 69356
		internal static int __PropertyOffset_13;

		// Token: 0x04010EED RID: 69357
		internal static int __PropertyOffset_14;

		// Token: 0x04010EEE RID: 69358
		internal static int __PropertyOffset_15;

		// Token: 0x04010EEF RID: 69359
		internal static int __PropertyOffset_16;

		// Token: 0x04010EF0 RID: 69360
		internal static int __PropertyOffset_17;

		// Token: 0x04010EF1 RID: 69361
		internal static int __PropertyOffset_18;

		// Token: 0x04010EF2 RID: 69362
		internal static int __PropertyOffset_19;

		// Token: 0x04010EF3 RID: 69363
		internal static int __PropertyOffset_20;

		// Token: 0x04010EF4 RID: 69364
		internal static int __PropertyOffset_21;

		// Token: 0x04010EF5 RID: 69365
		internal static int __PropertyOffset_22;

		// Token: 0x04010EF6 RID: 69366
		internal static int __PropertyOffset_23;

		// Token: 0x04010EF7 RID: 69367
		internal static int __PropertyOffset_24;

		// Token: 0x04010EF8 RID: 69368
		internal static int __PropertyOffset_25;

		// Token: 0x04010EF9 RID: 69369
		internal static int __PropertyOffset_26;

		// Token: 0x04010EFA RID: 69370
		internal static int __PropertyOffset_27;

		// Token: 0x04010EFB RID: 69371
		internal static int __PropertyOffset_28;

		// Token: 0x04010EFC RID: 69372
		internal static int __PropertyOffset_29;

		// Token: 0x04010EFD RID: 69373
		private static IntPtr __Initialize_NativeFunctionPtr;

		// Token: 0x04010EFE RID: 69374
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010EFF RID: 69375
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010F00 RID: 69376
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010F01 RID: 69377
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010F02 RID: 69378
		private static IntPtr __ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_NativeFunctionPtr;

		// Token: 0x02009B00 RID: 39680
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322A0 RID: 205472
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B01 RID: 39681
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322A1 RID: 205473
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B02 RID: 39682
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __ExecuteUbergraph_BP_GuideSpriteDecal_PointLight_FunctionParams
		{
			// Token: 0x040322A2 RID: 205474
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
