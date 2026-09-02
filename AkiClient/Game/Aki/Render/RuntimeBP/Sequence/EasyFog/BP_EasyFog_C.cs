using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence.EasyFog
{
	// Token: 0x02003A64 RID: 14948
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/EasyFog/BP_EasyFog.BP_EasyFog_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1216)]
	public class BP_EasyFog_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F1BB RID: 127419 RVA: 0x009080B0 File Offset: 0x009062B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EasyFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/EasyFog/BP_EasyFog.BP_EasyFog_C");
			}
			return BP_EasyFog_C._ClassPtr;
		}

		// Token: 0x0601F1BC RID: 127420 RVA: 0x009080D4 File Offset: 0x009062D4
		public BP_EasyFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_EasyFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F1BD RID: 127421 RVA: 0x009080FC File Offset: 0x009062FC
		[NullableContext(1)]
		public BP_EasyFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EasyFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E1A RID: 11802
		// (get) Token: 0x0601F1BE RID: 127422 RVA: 0x00908130 File Offset: 0x00906330
		// (set) Token: 0x0601F1BF RID: 127423 RVA: 0x00908169 File Offset: 0x00906369
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E1B RID: 11803
		// (get) Token: 0x0601F1C0 RID: 127424 RVA: 0x0090818A File Offset: 0x0090638A
		// (set) Token: 0x0601F1C1 RID: 127425 RVA: 0x0090819E File Offset: 0x0090639E
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E1C RID: 11804
		// (get) Token: 0x0601F1C2 RID: 127426 RVA: 0x009081B3 File Offset: 0x009063B3
		// (set) Token: 0x0601F1C3 RID: 127427 RVA: 0x009081C7 File Offset: 0x009063C7
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002E1D RID: 11805
		// (get) Token: 0x0601F1C4 RID: 127428 RVA: 0x009081DC File Offset: 0x009063DC
		// (set) Token: 0x0601F1C5 RID: 127429 RVA: 0x009081F0 File Offset: 0x009063F0
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002E1E RID: 11806
		// (get) Token: 0x0601F1C6 RID: 127430 RVA: 0x00908205 File Offset: 0x00906405
		// (set) Token: 0x0601F1C7 RID: 127431 RVA: 0x00908219 File Offset: 0x00906419
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002E1F RID: 11807
		// (get) Token: 0x0601F1C8 RID: 127432 RVA: 0x0090822E File Offset: 0x0090642E
		// (set) Token: 0x0601F1C9 RID: 127433 RVA: 0x0090823E File Offset: 0x0090643E
		public unsafe float FlowmapDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002E20 RID: 11808
		// (get) Token: 0x0601F1CA RID: 127434 RVA: 0x0090824F File Offset: 0x0090644F
		// (set) Token: 0x0601F1CB RID: 127435 RVA: 0x0090825F File Offset: 0x0090645F
		public unsafe float FlowmapIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002E21 RID: 11809
		// (get) Token: 0x0601F1CC RID: 127436 RVA: 0x00908270 File Offset: 0x00906470
		// (set) Token: 0x0601F1CD RID: 127437 RVA: 0x00908280 File Offset: 0x00906480
		public unsafe float FlowmapSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002E22 RID: 11810
		// (get) Token: 0x0601F1CE RID: 127438 RVA: 0x00908291 File Offset: 0x00906491
		// (set) Token: 0x0601F1CF RID: 127439 RVA: 0x009082A1 File Offset: 0x009064A1
		public unsafe float FlowmapTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002E23 RID: 11811
		// (get) Token: 0x0601F1D0 RID: 127440 RVA: 0x009082B2 File Offset: 0x009064B2
		// (set) Token: 0x0601F1D1 RID: 127441 RVA: 0x009082C2 File Offset: 0x009064C2
		public unsafe float Wind___Yes_No
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002E24 RID: 11812
		// (get) Token: 0x0601F1D2 RID: 127442 RVA: 0x009082D3 File Offset: 0x009064D3
		// (set) Token: 0x0601F1D3 RID: 127443 RVA: 0x009082E3 File Offset: 0x009064E3
		public unsafe float Wind_Speed_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E25 RID: 11813
		// (get) Token: 0x0601F1D4 RID: 127444 RVA: 0x009082F4 File Offset: 0x009064F4
		// (set) Token: 0x0601F1D5 RID: 127445 RVA: 0x00908304 File Offset: 0x00906504
		public unsafe float Wind_Speed_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002E26 RID: 11814
		// (get) Token: 0x0601F1D6 RID: 127446 RVA: 0x00908315 File Offset: 0x00906515
		// (set) Token: 0x0601F1D7 RID: 127447 RVA: 0x00908325 File Offset: 0x00906525
		public unsafe float Wind_Noise_Tiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002E27 RID: 11815
		// (get) Token: 0x0601F1D8 RID: 127448 RVA: 0x00908336 File Offset: 0x00906536
		// (set) Token: 0x0601F1D9 RID: 127449 RVA: 0x00908346 File Offset: 0x00906546
		public unsafe float Wind_Noise_Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002E28 RID: 11816
		// (get) Token: 0x0601F1DA RID: 127450 RVA: 0x00908357 File Offset: 0x00906557
		// (set) Token: 0x0601F1DB RID: 127451 RVA: 0x00908367 File Offset: 0x00906567
		public unsafe float AddBorderMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002E29 RID: 11817
		// (get) Token: 0x0601F1DC RID: 127452 RVA: 0x00908378 File Offset: 0x00906578
		// (set) Token: 0x0601F1DD RID: 127453 RVA: 0x0090838C File Offset: 0x0090658C
		public unsafe UTexture Base_Color_Map
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002E2A RID: 11818
		// (get) Token: 0x0601F1DE RID: 127454 RVA: 0x009083A1 File Offset: 0x009065A1
		// (set) Token: 0x0601F1DF RID: 127455 RVA: 0x009083B5 File Offset: 0x009065B5
		public unsafe UTexture Opacity_Map
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002E2B RID: 11819
		// (get) Token: 0x0601F1E0 RID: 127456 RVA: 0x009083CA File Offset: 0x009065CA
		// (set) Token: 0x0601F1E1 RID: 127457 RVA: 0x009083DE File Offset: 0x009065DE
		public unsafe UTexture Normal_Map
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002E2C RID: 11820
		// (get) Token: 0x0601F1E2 RID: 127458 RVA: 0x009083F3 File Offset: 0x009065F3
		// (set) Token: 0x0601F1E3 RID: 127459 RVA: 0x00908407 File Offset: 0x00906607
		public unsafe UTexture Flowmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002E2D RID: 11821
		// (get) Token: 0x0601F1E4 RID: 127460 RVA: 0x0090841C File Offset: 0x0090661C
		// (set) Token: 0x0601F1E5 RID: 127461 RVA: 0x0090842C File Offset: 0x0090662C
		public unsafe float Use_Atmosphere_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002E2E RID: 11822
		// (get) Token: 0x0601F1E6 RID: 127462 RVA: 0x0090843D File Offset: 0x0090663D
		// (set) Token: 0x0601F1E7 RID: 127463 RVA: 0x00908451 File Offset: 0x00906651
		public unsafe FLinearColor Base_Color_Tint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002E2F RID: 11823
		// (get) Token: 0x0601F1E8 RID: 127464 RVA: 0x00908466 File Offset: 0x00906666
		// (set) Token: 0x0601F1E9 RID: 127465 RVA: 0x00908476 File Offset: 0x00906676
		public unsafe float BaseColorContrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002E30 RID: 11824
		// (get) Token: 0x0601F1EA RID: 127466 RVA: 0x00908487 File Offset: 0x00906687
		// (set) Token: 0x0601F1EB RID: 127467 RVA: 0x00908497 File Offset: 0x00906697
		public unsafe float Base_Color_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002E31 RID: 11825
		// (get) Token: 0x0601F1EC RID: 127468 RVA: 0x009084A8 File Offset: 0x009066A8
		// (set) Token: 0x0601F1ED RID: 127469 RVA: 0x009084B8 File Offset: 0x009066B8
		public unsafe float Emissive_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002E32 RID: 11826
		// (get) Token: 0x0601F1EE RID: 127470 RVA: 0x009084C9 File Offset: 0x009066C9
		// (set) Token: 0x0601F1EF RID: 127471 RVA: 0x009084D9 File Offset: 0x009066D9
		public unsafe float Normal_Map_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002E33 RID: 11827
		// (get) Token: 0x0601F1F0 RID: 127472 RVA: 0x009084EA File Offset: 0x009066EA
		// (set) Token: 0x0601F1F1 RID: 127473 RVA: 0x009084FA File Offset: 0x009066FA
		public unsafe float Fog_Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002E34 RID: 11828
		// (get) Token: 0x0601F1F2 RID: 127474 RVA: 0x0090850B File Offset: 0x0090670B
		// (set) Token: 0x0601F1F3 RID: 127475 RVA: 0x0090851B File Offset: 0x0090671B
		public unsafe float Geometry_Fading_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002E35 RID: 11829
		// (get) Token: 0x0601F1F4 RID: 127476 RVA: 0x0090852C File Offset: 0x0090672C
		// (set) Token: 0x0601F1F5 RID: 127477 RVA: 0x0090853C File Offset: 0x0090673C
		public unsafe float Camera_Fading_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002E36 RID: 11830
		// (get) Token: 0x0601F1F6 RID: 127478 RVA: 0x0090854D File Offset: 0x0090674D
		// (set) Token: 0x0601F1F7 RID: 127479 RVA: 0x0090855D File Offset: 0x0090675D
		public unsafe float View_Angle_Fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002E37 RID: 11831
		// (get) Token: 0x0601F1F8 RID: 127480 RVA: 0x0090856E File Offset: 0x0090676E
		// (set) Token: 0x0601F1F9 RID: 127481 RVA: 0x0090857E File Offset: 0x0090677E
		public unsafe float BlurIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002E38 RID: 11832
		// (get) Token: 0x0601F1FA RID: 127482 RVA: 0x0090858F File Offset: 0x0090678F
		// (set) Token: 0x0601F1FB RID: 127483 RVA: 0x009085A3 File Offset: 0x009067A3
		public unsafe UMaterialInstanceDynamic DYMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EasyFog_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17002E39 RID: 11833
		// (get) Token: 0x0601F1FC RID: 127484 RVA: 0x009085B8 File Offset: 0x009067B8
		// (set) Token: 0x0601F1FD RID: 127485 RVA: 0x009085C8 File Offset: 0x009067C8
		public unsafe bool AfterDof
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E3A RID: 11834
		// (get) Token: 0x0601F1FE RID: 127486 RVA: 0x009085D9 File Offset: 0x009067D9
		// (set) Token: 0x0601F1FF RID: 127487 RVA: 0x009085E9 File Offset: 0x009067E9
		public unsafe float MobileIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EasyFog_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x0601F200 RID: 127488 RVA: 0x009085FA File Offset: 0x009067FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Raster_Translucency()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EasyFog_C.__Raster_Translucency_NativeFunctionPtr, null);
		}

		// Token: 0x0601F201 RID: 127489 RVA: 0x0090860E File Offset: 0x0090680E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EasyFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F202 RID: 127490 RVA: 0x00908622 File Offset: 0x00906822
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EasyFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F203 RID: 127491 RVA: 0x00908638 File Offset: 0x00906838
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_EasyFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_EasyFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EasyFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EasyFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EasyFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F204 RID: 127492 RVA: 0x00908680 File Offset: 0x00906880
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_EasyFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_EasyFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EasyFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EasyFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EasyFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F205 RID: 127493 RVA: 0x009086C8 File Offset: 0x009068C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_EasyFog(int EntryPoint)
		{
			BP_EasyFog_C.__ExecuteUbergraph_BP_EasyFog_FunctionParams* ptr = stackalloc BP_EasyFog_C.__ExecuteUbergraph_BP_EasyFog_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_EasyFog_C.__ExecuteUbergraph_BP_EasyFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EasyFog_C.__ExecuteUbergraph_BP_EasyFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EasyFog_C.__ExecuteUbergraph_BP_EasyFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F206 RID: 127494 RVA: 0x0090870F File Offset: 0x0090690F
		protected BP_EasyFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F678 RID: 63096
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/EasyFog/BP_EasyFog.BP_EasyFog_C";

		// Token: 0x0400F679 RID: 63097
		private static IntPtr _ClassPtr;

		// Token: 0x0400F67A RID: 63098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F67B RID: 63099
		internal static int __PropertyOffset_0;

		// Token: 0x0400F67C RID: 63100
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F67D RID: 63101
		internal static int __PropertyOffset_1;

		// Token: 0x0400F67E RID: 63102
		internal static int __PropertyOffset_2;

		// Token: 0x0400F67F RID: 63103
		internal static int __PropertyOffset_3;

		// Token: 0x0400F680 RID: 63104
		internal static int __PropertyOffset_4;

		// Token: 0x0400F681 RID: 63105
		internal static int __PropertyOffset_5;

		// Token: 0x0400F682 RID: 63106
		internal static int __PropertyOffset_6;

		// Token: 0x0400F683 RID: 63107
		internal static int __PropertyOffset_7;

		// Token: 0x0400F684 RID: 63108
		internal static int __PropertyOffset_8;

		// Token: 0x0400F685 RID: 63109
		internal static int __PropertyOffset_9;

		// Token: 0x0400F686 RID: 63110
		internal static int __PropertyOffset_10;

		// Token: 0x0400F687 RID: 63111
		internal static int __PropertyOffset_11;

		// Token: 0x0400F688 RID: 63112
		internal static int __PropertyOffset_12;

		// Token: 0x0400F689 RID: 63113
		internal static int __PropertyOffset_13;

		// Token: 0x0400F68A RID: 63114
		internal static int __PropertyOffset_14;

		// Token: 0x0400F68B RID: 63115
		internal static int __PropertyOffset_15;

		// Token: 0x0400F68C RID: 63116
		internal static int __PropertyOffset_16;

		// Token: 0x0400F68D RID: 63117
		internal static int __PropertyOffset_17;

		// Token: 0x0400F68E RID: 63118
		internal static int __PropertyOffset_18;

		// Token: 0x0400F68F RID: 63119
		internal static int __PropertyOffset_19;

		// Token: 0x0400F690 RID: 63120
		internal static int __PropertyOffset_20;

		// Token: 0x0400F691 RID: 63121
		internal static int __PropertyOffset_21;

		// Token: 0x0400F692 RID: 63122
		internal static int __PropertyOffset_22;

		// Token: 0x0400F693 RID: 63123
		internal static int __PropertyOffset_23;

		// Token: 0x0400F694 RID: 63124
		internal static int __PropertyOffset_24;

		// Token: 0x0400F695 RID: 63125
		internal static int __PropertyOffset_25;

		// Token: 0x0400F696 RID: 63126
		internal static int __PropertyOffset_26;

		// Token: 0x0400F697 RID: 63127
		internal static int __PropertyOffset_27;

		// Token: 0x0400F698 RID: 63128
		internal static int __PropertyOffset_28;

		// Token: 0x0400F699 RID: 63129
		internal static int __PropertyOffset_29;

		// Token: 0x0400F69A RID: 63130
		internal static int __PropertyOffset_30;

		// Token: 0x0400F69B RID: 63131
		internal static int __PropertyOffset_31;

		// Token: 0x0400F69C RID: 63132
		internal static int __PropertyOffset_32;

		// Token: 0x0400F69D RID: 63133
		private static IntPtr __Raster_Translucency_NativeFunctionPtr;

		// Token: 0x0400F69E RID: 63134
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F69F RID: 63135
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F6A0 RID: 63136
		private static IntPtr __ExecuteUbergraph_BP_EasyFog_NativeFunctionPtr;

		// Token: 0x02009862 RID: 39010
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E97 RID: 204439
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009863 RID: 39011
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_EasyFog_FunctionParams
		{
			// Token: 0x04031E98 RID: 204440
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
