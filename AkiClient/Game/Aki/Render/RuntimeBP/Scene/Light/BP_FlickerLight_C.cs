using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7F RID: 14975
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FlickerLight.BP_FlickerLight_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_FlickerLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F50C RID: 128268 RVA: 0x0090E950 File Offset: 0x0090CB50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FlickerLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FlickerLight.BP_FlickerLight_C");
			}
			return BP_FlickerLight_C._ClassPtr;
		}

		// Token: 0x0601F50D RID: 128269 RVA: 0x0090E974 File Offset: 0x0090CB74
		public BP_FlickerLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_FlickerLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F50E RID: 128270 RVA: 0x0090E99C File Offset: 0x0090CB9C
		[NullableContext(1)]
		public BP_FlickerLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FlickerLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F26 RID: 12070
		// (get) Token: 0x0601F50F RID: 128271 RVA: 0x0090E9D0 File Offset: 0x0090CBD0
		// (set) Token: 0x0601F510 RID: 128272 RVA: 0x0090EA09 File Offset: 0x0090CC09
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002F27 RID: 12071
		// (get) Token: 0x0601F511 RID: 128273 RVA: 0x0090EA2A File Offset: 0x0090CC2A
		// (set) Token: 0x0601F512 RID: 128274 RVA: 0x0090EA3E File Offset: 0x0090CC3E
		public unsafe UStaticMeshComponent FogMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002F28 RID: 12072
		// (get) Token: 0x0601F513 RID: 128275 RVA: 0x0090EA53 File Offset: 0x0090CC53
		// (set) Token: 0x0601F514 RID: 128276 RVA: 0x0090EA67 File Offset: 0x0090CC67
		public unsafe UStaticMeshComponent LightMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002F29 RID: 12073
		// (get) Token: 0x0601F515 RID: 128277 RVA: 0x0090EA7C File Offset: 0x0090CC7C
		// (set) Token: 0x0601F516 RID: 128278 RVA: 0x0090EA90 File Offset: 0x0090CC90
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002F2A RID: 12074
		// (get) Token: 0x0601F517 RID: 128279 RVA: 0x0090EAA8 File Offset: 0x0090CCA8
		// (set) Token: 0x0601F518 RID: 128280 RVA: 0x0090EAE1 File Offset: 0x0090CCE1
		[Nullable(1)]
		public TArray<float> LightsIntensity
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._LightsIntensity) == null)
				{
					result = (this._LightsIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightsIntensity.CopyAssign(value);
			}
		}

		// Token: 0x17002F2B RID: 12075
		// (get) Token: 0x0601F519 RID: 128281 RVA: 0x0090EAEF File Offset: 0x0090CCEF
		// (set) Token: 0x0601F51A RID: 128282 RVA: 0x0090EAFF File Offset: 0x0090CCFF
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002F2C RID: 12076
		// (get) Token: 0x0601F51B RID: 128283 RVA: 0x0090EB10 File Offset: 0x0090CD10
		// (set) Token: 0x0601F51C RID: 128284 RVA: 0x0090EB24 File Offset: 0x0090CD24
		public unsafe UStaticMesh LightModel
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002F2D RID: 12077
		// (get) Token: 0x0601F51D RID: 128285 RVA: 0x0090EB39 File Offset: 0x0090CD39
		// (set) Token: 0x0601F51E RID: 128286 RVA: 0x0090EB4D File Offset: 0x0090CD4D
		public unsafe UMaterialInstance LightMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002F2E RID: 12078
		// (get) Token: 0x0601F51F RID: 128287 RVA: 0x0090EB62 File Offset: 0x0090CD62
		// (set) Token: 0x0601F520 RID: 128288 RVA: 0x0090EB72 File Offset: 0x0090CD72
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002F2F RID: 12079
		// (get) Token: 0x0601F521 RID: 128289 RVA: 0x0090EB83 File Offset: 0x0090CD83
		// (set) Token: 0x0601F522 RID: 128290 RVA: 0x0090EB93 File Offset: 0x0090CD93
		public unsafe float Light
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002F30 RID: 12080
		// (get) Token: 0x0601F523 RID: 128291 RVA: 0x0090EBA4 File Offset: 0x0090CDA4
		// (set) Token: 0x0601F524 RID: 128292 RVA: 0x0090EBB4 File Offset: 0x0090CDB4
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002F31 RID: 12081
		// (get) Token: 0x0601F525 RID: 128293 RVA: 0x0090EBC5 File Offset: 0x0090CDC5
		// (set) Token: 0x0601F526 RID: 128294 RVA: 0x0090EBD5 File Offset: 0x0090CDD5
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002F32 RID: 12082
		// (get) Token: 0x0601F527 RID: 128295 RVA: 0x0090EBE6 File Offset: 0x0090CDE6
		// (set) Token: 0x0601F528 RID: 128296 RVA: 0x0090EBF6 File Offset: 0x0090CDF6
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002F33 RID: 12083
		// (get) Token: 0x0601F529 RID: 128297 RVA: 0x0090EC07 File Offset: 0x0090CE07
		// (set) Token: 0x0601F52A RID: 128298 RVA: 0x0090EC1B File Offset: 0x0090CE1B
		public unsafe FLinearColor EmissionDayColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002F34 RID: 12084
		// (get) Token: 0x0601F52B RID: 128299 RVA: 0x0090EC30 File Offset: 0x0090CE30
		// (set) Token: 0x0601F52C RID: 128300 RVA: 0x0090EC44 File Offset: 0x0090CE44
		public unsafe FLinearColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002F35 RID: 12085
		// (get) Token: 0x0601F52D RID: 128301 RVA: 0x0090EC59 File Offset: 0x0090CE59
		// (set) Token: 0x0601F52E RID: 128302 RVA: 0x0090EC69 File Offset: 0x0090CE69
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F36 RID: 12086
		// (get) Token: 0x0601F52F RID: 128303 RVA: 0x0090EC7A File Offset: 0x0090CE7A
		// (set) Token: 0x0601F530 RID: 128304 RVA: 0x0090EC8E File Offset: 0x0090CE8E
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002F37 RID: 12087
		// (get) Token: 0x0601F531 RID: 128305 RVA: 0x0090ECA3 File Offset: 0x0090CEA3
		// (set) Token: 0x0601F532 RID: 128306 RVA: 0x0090ECB7 File Offset: 0x0090CEB7
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002F38 RID: 12088
		// (get) Token: 0x0601F533 RID: 128307 RVA: 0x0090ECCC File Offset: 0x0090CECC
		// (set) Token: 0x0601F534 RID: 128308 RVA: 0x0090ECE0 File Offset: 0x0090CEE0
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002F39 RID: 12089
		// (get) Token: 0x0601F535 RID: 128309 RVA: 0x0090ECF5 File Offset: 0x0090CEF5
		// (set) Token: 0x0601F536 RID: 128310 RVA: 0x0090ED09 File Offset: 0x0090CF09
		public unsafe UMaterialInstance MaterialInstanceBT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17002F3A RID: 12090
		// (get) Token: 0x0601F537 RID: 128311 RVA: 0x0090ED1E File Offset: 0x0090CF1E
		// (set) Token: 0x0601F538 RID: 128312 RVA: 0x0090ED32 File Offset: 0x0090CF32
		public unsafe UMaterialInstance MaterialInstanceT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlickerLight_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17002F3B RID: 12091
		// (get) Token: 0x0601F539 RID: 128313 RVA: 0x0090ED47 File Offset: 0x0090CF47
		// (set) Token: 0x0601F53A RID: 128314 RVA: 0x0090ED57 File Offset: 0x0090CF57
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F3C RID: 12092
		// (get) Token: 0x0601F53B RID: 128315 RVA: 0x0090ED68 File Offset: 0x0090CF68
		// (set) Token: 0x0601F53C RID: 128316 RVA: 0x0090ED78 File Offset: 0x0090CF78
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F3D RID: 12093
		// (get) Token: 0x0601F53D RID: 128317 RVA: 0x0090ED89 File Offset: 0x0090CF89
		// (set) Token: 0x0601F53E RID: 128318 RVA: 0x0090ED99 File Offset: 0x0090CF99
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002F3E RID: 12094
		// (get) Token: 0x0601F53F RID: 128319 RVA: 0x0090EDAA File Offset: 0x0090CFAA
		// (set) Token: 0x0601F540 RID: 128320 RVA: 0x0090EDBA File Offset: 0x0090CFBA
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002F3F RID: 12095
		// (get) Token: 0x0601F541 RID: 128321 RVA: 0x0090EDCB File Offset: 0x0090CFCB
		// (set) Token: 0x0601F542 RID: 128322 RVA: 0x0090EDDB File Offset: 0x0090CFDB
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002F40 RID: 12096
		// (get) Token: 0x0601F543 RID: 128323 RVA: 0x0090EDEC File Offset: 0x0090CFEC
		// (set) Token: 0x0601F544 RID: 128324 RVA: 0x0090EDFC File Offset: 0x0090CFFC
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002F41 RID: 12097
		// (get) Token: 0x0601F545 RID: 128325 RVA: 0x0090EE0D File Offset: 0x0090D00D
		// (set) Token: 0x0601F546 RID: 128326 RVA: 0x0090EE21 File Offset: 0x0090D021
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002F42 RID: 12098
		// (get) Token: 0x0601F547 RID: 128327 RVA: 0x0090EE36 File Offset: 0x0090D036
		// (set) Token: 0x0601F548 RID: 128328 RVA: 0x0090EE4A File Offset: 0x0090D04A
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002F43 RID: 12099
		// (get) Token: 0x0601F549 RID: 128329 RVA: 0x0090EE5F File Offset: 0x0090D05F
		// (set) Token: 0x0601F54A RID: 128330 RVA: 0x0090EE6F File Offset: 0x0090D06F
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002F44 RID: 12100
		// (get) Token: 0x0601F54B RID: 128331 RVA: 0x0090EE80 File Offset: 0x0090D080
		// (set) Token: 0x0601F54C RID: 128332 RVA: 0x0090EE90 File Offset: 0x0090D090
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002F45 RID: 12101
		// (get) Token: 0x0601F54D RID: 128333 RVA: 0x0090EEA1 File Offset: 0x0090D0A1
		// (set) Token: 0x0601F54E RID: 128334 RVA: 0x0090EEB1 File Offset: 0x0090D0B1
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlickerLight_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x0601F54F RID: 128335 RVA: 0x0090EEC2 File Offset: 0x0090D0C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Flicker_Off()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__Flicker_Off_NativeFunctionPtr, null);
		}

		// Token: 0x0601F550 RID: 128336 RVA: 0x0090EED6 File Offset: 0x0090D0D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Flicker_ON()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__Flicker_ON_NativeFunctionPtr, null);
		}

		// Token: 0x0601F551 RID: 128337 RVA: 0x0090EEEC File Offset: 0x0090D0EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(float Speed, ref float ElapsedTime)
		{
			BP_FlickerLight_C.__Timer_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__Timer_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_FlickerLight_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x0601F552 RID: 128338 RVA: 0x0090EF44 File Offset: 0x0090D144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ToggleLights(float DeltaSeconds)
		{
			BP_FlickerLight_C.__ToggleLights_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__ToggleLights_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_FlickerLight_C.__ToggleLights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__ToggleLights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__ToggleLights_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F553 RID: 128339 RVA: 0x0090EF8D File Offset: 0x0090D18D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetLightIntensity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__GetLightIntensity_NativeFunctionPtr, null);
		}

		// Token: 0x0601F554 RID: 128340 RVA: 0x0090EFA1 File Offset: 0x0090D1A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F555 RID: 128341 RVA: 0x0090EFB5 File Offset: 0x0090D1B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlickerLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F556 RID: 128342 RVA: 0x0090EFCA File Offset: 0x0090D1CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F557 RID: 128343 RVA: 0x0090EFDE File Offset: 0x0090D1DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlickerLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F558 RID: 128344 RVA: 0x0090EFF4 File Offset: 0x0090D1F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FlickerLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlickerLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F559 RID: 128345 RVA: 0x0090F03C File Offset: 0x0090D23C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FlickerLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlickerLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlickerLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F55A RID: 128346 RVA: 0x0090F084 File Offset: 0x0090D284
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FlickerLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlickerLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F55B RID: 128347 RVA: 0x0090F0CC File Offset: 0x0090D2CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FlickerLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlickerLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlickerLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F55C RID: 128348 RVA: 0x0090F113 File Offset: 0x0090D313
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlickerLight_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x0601F55D RID: 128349 RVA: 0x0090F128 File Offset: 0x0090D328
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FlickerLight(int EntryPoint)
		{
			BP_FlickerLight_C.__ExecuteUbergraph_BP_FlickerLight_FunctionParams* ptr = stackalloc BP_FlickerLight_C.__ExecuteUbergraph_BP_FlickerLight_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_FlickerLight_C.__ExecuteUbergraph_BP_FlickerLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlickerLight_C.__ExecuteUbergraph_BP_FlickerLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlickerLight_C.__ExecuteUbergraph_BP_FlickerLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F55E RID: 128350 RVA: 0x0090F16F File Offset: 0x0090D36F
		protected BP_FlickerLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F8AC RID: 63660
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FlickerLight.BP_FlickerLight_C";

		// Token: 0x0400F8AD RID: 63661
		private static IntPtr _ClassPtr;

		// Token: 0x0400F8AE RID: 63662
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F8AF RID: 63663
		internal static int __PropertyOffset_0;

		// Token: 0x0400F8B0 RID: 63664
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F8B1 RID: 63665
		internal static int __PropertyOffset_1;

		// Token: 0x0400F8B2 RID: 63666
		internal static int __PropertyOffset_2;

		// Token: 0x0400F8B3 RID: 63667
		internal static int __PropertyOffset_3;

		// Token: 0x0400F8B4 RID: 63668
		internal static int __PropertyOffset_4;

		// Token: 0x0400F8B5 RID: 63669
		private TArray<float> _LightsIntensity;

		// Token: 0x0400F8B6 RID: 63670
		internal static int __PropertyOffset_5;

		// Token: 0x0400F8B7 RID: 63671
		internal static int __PropertyOffset_6;

		// Token: 0x0400F8B8 RID: 63672
		internal static int __PropertyOffset_7;

		// Token: 0x0400F8B9 RID: 63673
		internal static int __PropertyOffset_8;

		// Token: 0x0400F8BA RID: 63674
		internal static int __PropertyOffset_9;

		// Token: 0x0400F8BB RID: 63675
		internal static int __PropertyOffset_10;

		// Token: 0x0400F8BC RID: 63676
		internal static int __PropertyOffset_11;

		// Token: 0x0400F8BD RID: 63677
		internal static int __PropertyOffset_12;

		// Token: 0x0400F8BE RID: 63678
		internal static int __PropertyOffset_13;

		// Token: 0x0400F8BF RID: 63679
		internal static int __PropertyOffset_14;

		// Token: 0x0400F8C0 RID: 63680
		internal static int __PropertyOffset_15;

		// Token: 0x0400F8C1 RID: 63681
		internal static int __PropertyOffset_16;

		// Token: 0x0400F8C2 RID: 63682
		internal static int __PropertyOffset_17;

		// Token: 0x0400F8C3 RID: 63683
		internal static int __PropertyOffset_18;

		// Token: 0x0400F8C4 RID: 63684
		internal static int __PropertyOffset_19;

		// Token: 0x0400F8C5 RID: 63685
		internal static int __PropertyOffset_20;

		// Token: 0x0400F8C6 RID: 63686
		internal static int __PropertyOffset_21;

		// Token: 0x0400F8C7 RID: 63687
		internal static int __PropertyOffset_22;

		// Token: 0x0400F8C8 RID: 63688
		internal static int __PropertyOffset_23;

		// Token: 0x0400F8C9 RID: 63689
		internal static int __PropertyOffset_24;

		// Token: 0x0400F8CA RID: 63690
		internal static int __PropertyOffset_25;

		// Token: 0x0400F8CB RID: 63691
		internal static int __PropertyOffset_26;

		// Token: 0x0400F8CC RID: 63692
		internal static int __PropertyOffset_27;

		// Token: 0x0400F8CD RID: 63693
		internal static int __PropertyOffset_28;

		// Token: 0x0400F8CE RID: 63694
		internal static int __PropertyOffset_29;

		// Token: 0x0400F8CF RID: 63695
		internal static int __PropertyOffset_30;

		// Token: 0x0400F8D0 RID: 63696
		internal static int __PropertyOffset_31;

		// Token: 0x0400F8D1 RID: 63697
		private static IntPtr __Flicker_Off_NativeFunctionPtr;

		// Token: 0x0400F8D2 RID: 63698
		private static IntPtr __Flicker_ON_NativeFunctionPtr;

		// Token: 0x0400F8D3 RID: 63699
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x0400F8D4 RID: 63700
		private static IntPtr __ToggleLights_NativeFunctionPtr;

		// Token: 0x0400F8D5 RID: 63701
		private static IntPtr __GetLightIntensity_NativeFunctionPtr;

		// Token: 0x0400F8D6 RID: 63702
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F8D7 RID: 63703
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F8D8 RID: 63704
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F8D9 RID: 63705
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F8DA RID: 63706
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400F8DB RID: 63707
		private static IntPtr __ExecuteUbergraph_BP_FlickerLight_NativeFunctionPtr;

		// Token: 0x020098C7 RID: 39111
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04031F18 RID: 204568
			[FieldOffset(0)]
			public float Speed;

			// Token: 0x04031F19 RID: 204569
			[FieldOffset(4)]
			public float ElapsedTime;
		}

		// Token: 0x020098C8 RID: 39112
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ToggleLights_FunctionParams
		{
			// Token: 0x04031F1A RID: 204570
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098C9 RID: 39113
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F1B RID: 204571
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098CA RID: 39114
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F1C RID: 204572
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098CB RID: 39115
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_FlickerLight_FunctionParams
		{
			// Token: 0x04031F1D RID: 204573
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
