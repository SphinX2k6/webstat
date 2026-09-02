using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroLocalVolumetricFog
{
	// Token: 0x02003C70 RID: 15472
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroLocalVolumetricFog/BP_KuroLocalVolumetricFog.BP_KuroLocalVolumetricFog_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1192)]
	public class BP_KuroLocalVolumetricFog_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E2E RID: 146990 RVA: 0x0098EDD4 File Offset: 0x0098CFD4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroLocalVolumetricFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroLocalVolumetricFog/BP_KuroLocalVolumetricFog.BP_KuroLocalVolumetricFog_C");
			}
			return BP_KuroLocalVolumetricFog_C._ClassPtr;
		}

		// Token: 0x06023E2F RID: 146991 RVA: 0x0098EDF8 File Offset: 0x0098CFF8
		public BP_KuroLocalVolumetricFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroLocalVolumetricFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E30 RID: 146992 RVA: 0x0098EE20 File Offset: 0x0098D020
		[NullableContext(1)]
		public BP_KuroLocalVolumetricFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroLocalVolumetricFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048D8 RID: 18648
		// (get) Token: 0x06023E31 RID: 146993 RVA: 0x0098EE54 File Offset: 0x0098D054
		// (set) Token: 0x06023E32 RID: 146994 RVA: 0x0098EE8D File Offset: 0x0098D08D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170048D9 RID: 18649
		// (get) Token: 0x06023E33 RID: 146995 RVA: 0x0098EEAE File Offset: 0x0098D0AE
		// (set) Token: 0x06023E34 RID: 146996 RVA: 0x0098EEC2 File Offset: 0x0098D0C2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170048DA RID: 18650
		// (get) Token: 0x06023E35 RID: 146997 RVA: 0x0098EED7 File Offset: 0x0098D0D7
		// (set) Token: 0x06023E36 RID: 146998 RVA: 0x0098EEEB File Offset: 0x0098D0EB
		public unsafe UStaticMesh Mesh_FogSphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170048DB RID: 18651
		// (get) Token: 0x06023E37 RID: 146999 RVA: 0x0098EF00 File Offset: 0x0098D100
		// (set) Token: 0x06023E38 RID: 147000 RVA: 0x0098EF10 File Offset: 0x0098D110
		public unsafe int FogScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170048DC RID: 18652
		// (get) Token: 0x06023E39 RID: 147001 RVA: 0x0098EF21 File Offset: 0x0098D121
		// (set) Token: 0x06023E3A RID: 147002 RVA: 0x0098EF35 File Offset: 0x0098D135
		public unsafe UMaterialInstance M_LocalVolumetricFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170048DD RID: 18653
		// (get) Token: 0x06023E3B RID: 147003 RVA: 0x0098EF4A File Offset: 0x0098D14A
		// (set) Token: 0x06023E3C RID: 147004 RVA: 0x0098EF5E File Offset: 0x0098D15E
		public unsafe FColor FogInColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170048DE RID: 18654
		// (get) Token: 0x06023E3D RID: 147005 RVA: 0x0098EF73 File Offset: 0x0098D173
		// (set) Token: 0x06023E3E RID: 147006 RVA: 0x0098EF87 File Offset: 0x0098D187
		public unsafe FColor FogOutColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170048DF RID: 18655
		// (get) Token: 0x06023E3F RID: 147007 RVA: 0x0098EF9C File Offset: 0x0098D19C
		// (set) Token: 0x06023E40 RID: 147008 RVA: 0x0098EFAC File Offset: 0x0098D1AC
		public unsafe float FogEnvLightBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170048E0 RID: 18656
		// (get) Token: 0x06023E41 RID: 147009 RVA: 0x0098EFBD File Offset: 0x0098D1BD
		// (set) Token: 0x06023E42 RID: 147010 RVA: 0x0098EFCD File Offset: 0x0098D1CD
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170048E1 RID: 18657
		// (get) Token: 0x06023E43 RID: 147011 RVA: 0x0098EFDE File Offset: 0x0098D1DE
		// (set) Token: 0x06023E44 RID: 147012 RVA: 0x0098EFEE File Offset: 0x0098D1EE
		public unsafe float FogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170048E2 RID: 18658
		// (get) Token: 0x06023E45 RID: 147013 RVA: 0x0098EFFF File Offset: 0x0098D1FF
		// (set) Token: 0x06023E46 RID: 147014 RVA: 0x0098F00F File Offset: 0x0098D20F
		public unsafe float FogHgX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170048E3 RID: 18659
		// (get) Token: 0x06023E47 RID: 147015 RVA: 0x0098F020 File Offset: 0x0098D220
		// (set) Token: 0x06023E48 RID: 147016 RVA: 0x0098F030 File Offset: 0x0098D230
		public unsafe float FogPhase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170048E4 RID: 18660
		// (get) Token: 0x06023E49 RID: 147017 RVA: 0x0098F041 File Offset: 0x0098D241
		// (set) Token: 0x06023E4A RID: 147018 RVA: 0x0098F051 File Offset: 0x0098D251
		public unsafe float FogHg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170048E5 RID: 18661
		// (get) Token: 0x06023E4B RID: 147019 RVA: 0x0098F062 File Offset: 0x0098D262
		// (set) Token: 0x06023E4C RID: 147020 RVA: 0x0098F072 File Offset: 0x0098D272
		public unsafe float FogPhaseG
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170048E6 RID: 18662
		// (get) Token: 0x06023E4D RID: 147021 RVA: 0x0098F083 File Offset: 0x0098D283
		// (set) Token: 0x06023E4E RID: 147022 RVA: 0x0098F093 File Offset: 0x0098D293
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170048E7 RID: 18663
		// (get) Token: 0x06023E4F RID: 147023 RVA: 0x0098F0A4 File Offset: 0x0098D2A4
		// (set) Token: 0x06023E50 RID: 147024 RVA: 0x0098F0B4 File Offset: 0x0098D2B4
		public unsafe bool EnableNoise
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048E8 RID: 18664
		// (get) Token: 0x06023E51 RID: 147025 RVA: 0x0098F0C5 File Offset: 0x0098D2C5
		// (set) Token: 0x06023E52 RID: 147026 RVA: 0x0098F0D5 File Offset: 0x0098D2D5
		public unsafe bool EnableObjectScreenUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048E9 RID: 18665
		// (get) Token: 0x06023E53 RID: 147027 RVA: 0x0098F0E6 File Offset: 0x0098D2E6
		// (set) Token: 0x06023E54 RID: 147028 RVA: 0x0098F0F6 File Offset: 0x0098D2F6
		public unsafe float NoiseInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170048EA RID: 18666
		// (get) Token: 0x06023E55 RID: 147029 RVA: 0x0098F107 File Offset: 0x0098D307
		// (set) Token: 0x06023E56 RID: 147030 RVA: 0x0098F117 File Offset: 0x0098D317
		public unsafe float NoiseOneTill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170048EB RID: 18667
		// (get) Token: 0x06023E57 RID: 147031 RVA: 0x0098F128 File Offset: 0x0098D328
		// (set) Token: 0x06023E58 RID: 147032 RVA: 0x0098F138 File Offset: 0x0098D338
		public unsafe float NoiseOneSpeedX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170048EC RID: 18668
		// (get) Token: 0x06023E59 RID: 147033 RVA: 0x0098F149 File Offset: 0x0098D349
		// (set) Token: 0x06023E5A RID: 147034 RVA: 0x0098F159 File Offset: 0x0098D359
		public unsafe float NoiseOneSpeedY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170048ED RID: 18669
		// (get) Token: 0x06023E5B RID: 147035 RVA: 0x0098F16A File Offset: 0x0098D36A
		// (set) Token: 0x06023E5C RID: 147036 RVA: 0x0098F17E File Offset: 0x0098D37E
		public unsafe UTexture2D NoiseOne
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170048EE RID: 18670
		// (get) Token: 0x06023E5D RID: 147037 RVA: 0x0098F193 File Offset: 0x0098D393
		// (set) Token: 0x06023E5E RID: 147038 RVA: 0x0098F1A3 File Offset: 0x0098D3A3
		public unsafe float NoiseTwoTill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170048EF RID: 18671
		// (get) Token: 0x06023E5F RID: 147039 RVA: 0x0098F1B4 File Offset: 0x0098D3B4
		// (set) Token: 0x06023E60 RID: 147040 RVA: 0x0098F1C4 File Offset: 0x0098D3C4
		public unsafe float NoiseTwoSpeedX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170048F0 RID: 18672
		// (get) Token: 0x06023E61 RID: 147041 RVA: 0x0098F1D5 File Offset: 0x0098D3D5
		// (set) Token: 0x06023E62 RID: 147042 RVA: 0x0098F1E5 File Offset: 0x0098D3E5
		public unsafe float NoiseTwoSpeedY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLocalVolumetricFog_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170048F1 RID: 18673
		// (get) Token: 0x06023E63 RID: 147043 RVA: 0x0098F1F6 File Offset: 0x0098D3F6
		// (set) Token: 0x06023E64 RID: 147044 RVA: 0x0098F20A File Offset: 0x0098D40A
		public unsafe UTexture2D NoiseTwo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170048F2 RID: 18674
		// (get) Token: 0x06023E65 RID: 147045 RVA: 0x0098F21F File Offset: 0x0098D41F
		// (set) Token: 0x06023E66 RID: 147046 RVA: 0x0098F233 File Offset: 0x0098D433
		public unsafe UMaterialInstance M_LocalVolumetricFogDisNoise
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x170048F3 RID: 18675
		// (get) Token: 0x06023E67 RID: 147047 RVA: 0x0098F248 File Offset: 0x0098D448
		// (set) Token: 0x06023E68 RID: 147048 RVA: 0x0098F25C File Offset: 0x0098D45C
		public unsafe UMaterialInstance M_LocalVolumetricFog_ObjScreenUV
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170048F4 RID: 18676
		// (get) Token: 0x06023E69 RID: 147049 RVA: 0x0098F271 File Offset: 0x0098D471
		// (set) Token: 0x06023E6A RID: 147050 RVA: 0x0098F285 File Offset: 0x0098D485
		public unsafe UMaterialInstanceDynamic DynMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLocalVolumetricFog_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x06023E6B RID: 147051 RVA: 0x0098F29A File Offset: 0x0098D49A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__UpdatePara_NativeFunctionPtr, null);
		}

		// Token: 0x06023E6C RID: 147052 RVA: 0x0098F2AE File Offset: 0x0098D4AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023E6D RID: 147053 RVA: 0x0098F2C2 File Offset: 0x0098D4C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E6E RID: 147054 RVA: 0x0098F2D7 File Offset: 0x0098D4D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023E6F RID: 147055 RVA: 0x0098F2EB File Offset: 0x0098D4EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E70 RID: 147056 RVA: 0x0098F300 File Offset: 0x0098D500
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroLocalVolumetricFog(int EntryPoint)
		{
			BP_KuroLocalVolumetricFog_C.__ExecuteUbergraph_BP_KuroLocalVolumetricFog_FunctionParams* ptr = stackalloc BP_KuroLocalVolumetricFog_C.__ExecuteUbergraph_BP_KuroLocalVolumetricFog_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLocalVolumetricFog_C.__ExecuteUbergraph_BP_KuroLocalVolumetricFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLocalVolumetricFog_C.__ExecuteUbergraph_BP_KuroLocalVolumetricFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLocalVolumetricFog_C.__ExecuteUbergraph_BP_KuroLocalVolumetricFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023E71 RID: 147057 RVA: 0x0098F347 File Offset: 0x0098D547
		protected BP_KuroLocalVolumetricFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012543 RID: 75075
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroLocalVolumetricFog/BP_KuroLocalVolumetricFog.BP_KuroLocalVolumetricFog_C";

		// Token: 0x04012544 RID: 75076
		private static IntPtr _ClassPtr;

		// Token: 0x04012545 RID: 75077
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012546 RID: 75078
		internal static int __PropertyOffset_0;

		// Token: 0x04012547 RID: 75079
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012548 RID: 75080
		internal static int __PropertyOffset_1;

		// Token: 0x04012549 RID: 75081
		internal static int __PropertyOffset_2;

		// Token: 0x0401254A RID: 75082
		internal static int __PropertyOffset_3;

		// Token: 0x0401254B RID: 75083
		internal static int __PropertyOffset_4;

		// Token: 0x0401254C RID: 75084
		internal static int __PropertyOffset_5;

		// Token: 0x0401254D RID: 75085
		internal static int __PropertyOffset_6;

		// Token: 0x0401254E RID: 75086
		internal static int __PropertyOffset_7;

		// Token: 0x0401254F RID: 75087
		internal static int __PropertyOffset_8;

		// Token: 0x04012550 RID: 75088
		internal static int __PropertyOffset_9;

		// Token: 0x04012551 RID: 75089
		internal static int __PropertyOffset_10;

		// Token: 0x04012552 RID: 75090
		internal static int __PropertyOffset_11;

		// Token: 0x04012553 RID: 75091
		internal static int __PropertyOffset_12;

		// Token: 0x04012554 RID: 75092
		internal static int __PropertyOffset_13;

		// Token: 0x04012555 RID: 75093
		internal static int __PropertyOffset_14;

		// Token: 0x04012556 RID: 75094
		internal static int __PropertyOffset_15;

		// Token: 0x04012557 RID: 75095
		internal static int __PropertyOffset_16;

		// Token: 0x04012558 RID: 75096
		internal static int __PropertyOffset_17;

		// Token: 0x04012559 RID: 75097
		internal static int __PropertyOffset_18;

		// Token: 0x0401255A RID: 75098
		internal static int __PropertyOffset_19;

		// Token: 0x0401255B RID: 75099
		internal static int __PropertyOffset_20;

		// Token: 0x0401255C RID: 75100
		internal static int __PropertyOffset_21;

		// Token: 0x0401255D RID: 75101
		internal static int __PropertyOffset_22;

		// Token: 0x0401255E RID: 75102
		internal static int __PropertyOffset_23;

		// Token: 0x0401255F RID: 75103
		internal static int __PropertyOffset_24;

		// Token: 0x04012560 RID: 75104
		internal static int __PropertyOffset_25;

		// Token: 0x04012561 RID: 75105
		internal static int __PropertyOffset_26;

		// Token: 0x04012562 RID: 75106
		internal static int __PropertyOffset_27;

		// Token: 0x04012563 RID: 75107
		internal static int __PropertyOffset_28;

		// Token: 0x04012564 RID: 75108
		private static IntPtr __UpdatePara_NativeFunctionPtr;

		// Token: 0x04012565 RID: 75109
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012566 RID: 75110
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012567 RID: 75111
		private static IntPtr __ExecuteUbergraph_BP_KuroLocalVolumetricFog_NativeFunctionPtr;

		// Token: 0x02009D5D RID: 40285
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_KuroLocalVolumetricFog_FunctionParams
		{
			// Token: 0x04032752 RID: 206674
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
