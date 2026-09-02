using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm
{
	// Token: 0x02003C58 RID: 15448
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_1.BP_MagneticStorm_3_1_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_MagneticStorm_3_1_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023AF8 RID: 146168 RVA: 0x0098934C File Offset: 0x0098754C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MagneticStorm_3_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_1.BP_MagneticStorm_3_1_C");
			}
			return BP_MagneticStorm_3_1_C._ClassPtr;
		}

		// Token: 0x06023AF9 RID: 146169 RVA: 0x00989370 File Offset: 0x00987570
		public BP_MagneticStorm_3_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_3_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023AFA RID: 146170 RVA: 0x00989398 File Offset: 0x00987598
		[NullableContext(1)]
		public BP_MagneticStorm_3_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_3_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047CF RID: 18383
		// (get) Token: 0x06023AFB RID: 146171 RVA: 0x009893CC File Offset: 0x009875CC
		// (set) Token: 0x06023AFC RID: 146172 RVA: 0x00989405 File Offset: 0x00987605
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170047D0 RID: 18384
		// (get) Token: 0x06023AFD RID: 146173 RVA: 0x00989426 File Offset: 0x00987626
		// (set) Token: 0x06023AFE RID: 146174 RVA: 0x0098943A File Offset: 0x0098763A
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170047D1 RID: 18385
		// (get) Token: 0x06023AFF RID: 146175 RVA: 0x0098944F File Offset: 0x0098764F
		// (set) Token: 0x06023B00 RID: 146176 RVA: 0x00989463 File Offset: 0x00987663
		public unsafe UNiagaraComponent NS_Fx_SC3_MagneticStorm_Mobile_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170047D2 RID: 18386
		// (get) Token: 0x06023B01 RID: 146177 RVA: 0x00989478 File Offset: 0x00987678
		// (set) Token: 0x06023B02 RID: 146178 RVA: 0x0098948C File Offset: 0x0098768C
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170047D3 RID: 18387
		// (get) Token: 0x06023B03 RID: 146179 RVA: 0x009894A1 File Offset: 0x009876A1
		// (set) Token: 0x06023B04 RID: 146180 RVA: 0x009894B5 File Offset: 0x009876B5
		public unsafe UNiagaraComponent NS_Fx_MagneticStorm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170047D4 RID: 18388
		// (get) Token: 0x06023B05 RID: 146181 RVA: 0x009894CA File Offset: 0x009876CA
		// (set) Token: 0x06023B06 RID: 146182 RVA: 0x009894DE File Offset: 0x009876DE
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_1_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170047D5 RID: 18389
		// (get) Token: 0x06023B07 RID: 146183 RVA: 0x009894F3 File Offset: 0x009876F3
		// (set) Token: 0x06023B08 RID: 146184 RVA: 0x00989507 File Offset: 0x00987707
		public unsafe FVector WroldOriginLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170047D6 RID: 18390
		// (get) Token: 0x06023B09 RID: 146185 RVA: 0x0098951C File Offset: 0x0098771C
		// (set) Token: 0x06023B0A RID: 146186 RVA: 0x0098952C File Offset: 0x0098772C
		public unsafe bool DisplayShockwave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047D7 RID: 18391
		// (get) Token: 0x06023B0B RID: 146187 RVA: 0x0098953D File Offset: 0x0098773D
		// (set) Token: 0x06023B0C RID: 146188 RVA: 0x0098954D File Offset: 0x0098774D
		public unsafe bool DisplayParticle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047D8 RID: 18392
		// (get) Token: 0x06023B0D RID: 146189 RVA: 0x0098955E File Offset: 0x0098775E
		// (set) Token: 0x06023B0E RID: 146190 RVA: 0x0098956E File Offset: 0x0098776E
		public unsafe bool DisplayPointLattice
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047D9 RID: 18393
		// (get) Token: 0x06023B0F RID: 146191 RVA: 0x0098957F File Offset: 0x0098777F
		// (set) Token: 0x06023B10 RID: 146192 RVA: 0x0098958F File Offset: 0x0098778F
		public unsafe bool bInTheArea
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047DA RID: 18394
		// (get) Token: 0x06023B11 RID: 146193 RVA: 0x009895A0 File Offset: 0x009877A0
		// (set) Token: 0x06023B12 RID: 146194 RVA: 0x009895B4 File Offset: 0x009877B4
		[Nullable(0)]
		public unsafe TEnumAsByte<E_MagneticStorm_RegionType> RegionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170047DB RID: 18395
		// (get) Token: 0x06023B13 RID: 146195 RVA: 0x009895C9 File Offset: 0x009877C9
		// (set) Token: 0x06023B14 RID: 146196 RVA: 0x009895D9 File Offset: 0x009877D9
		public unsafe bool DisplaySphereMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047DC RID: 18396
		// (get) Token: 0x06023B15 RID: 146197 RVA: 0x009895EA File Offset: 0x009877EA
		// (set) Token: 0x06023B16 RID: 146198 RVA: 0x009895FA File Offset: 0x009877FA
		public unsafe float AttenuationDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170047DD RID: 18397
		// (get) Token: 0x06023B17 RID: 146199 RVA: 0x0098960B File Offset: 0x0098780B
		// (set) Token: 0x06023B18 RID: 146200 RVA: 0x0098961B File Offset: 0x0098781B
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170047DE RID: 18398
		// (get) Token: 0x06023B19 RID: 146201 RVA: 0x0098962C File Offset: 0x0098782C
		// (set) Token: 0x06023B1A RID: 146202 RVA: 0x0098963C File Offset: 0x0098783C
		public unsafe bool DisplayPrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047DF RID: 18399
		// (get) Token: 0x06023B1B RID: 146203 RVA: 0x0098964D File Offset: 0x0098784D
		// (set) Token: 0x06023B1C RID: 146204 RVA: 0x0098965D File Offset: 0x0098785D
		public unsafe float PointLatticeOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170047E0 RID: 18400
		// (get) Token: 0x06023B1D RID: 146205 RVA: 0x0098966E File Offset: 0x0098786E
		// (set) Token: 0x06023B1E RID: 146206 RVA: 0x0098967E File Offset: 0x0098787E
		public unsafe float ShockwaveFrequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170047E1 RID: 18401
		// (get) Token: 0x06023B1F RID: 146207 RVA: 0x0098968F File Offset: 0x0098788F
		// (set) Token: 0x06023B20 RID: 146208 RVA: 0x0098969F File Offset: 0x0098789F
		public unsafe float ShockwaveIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170047E2 RID: 18402
		// (get) Token: 0x06023B21 RID: 146209 RVA: 0x009896B0 File Offset: 0x009878B0
		// (set) Token: 0x06023B22 RID: 146210 RVA: 0x009896C0 File Offset: 0x009878C0
		public unsafe float ParticleOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170047E3 RID: 18403
		// (get) Token: 0x06023B23 RID: 146211 RVA: 0x009896D1 File Offset: 0x009878D1
		// (set) Token: 0x06023B24 RID: 146212 RVA: 0x009896E1 File Offset: 0x009878E1
		public unsafe bool UseColorParam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047E4 RID: 18404
		// (get) Token: 0x06023B25 RID: 146213 RVA: 0x009896F2 File Offset: 0x009878F2
		// (set) Token: 0x06023B26 RID: 146214 RVA: 0x00989702 File Offset: 0x00987902
		public unsafe float InTheAreaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170047E5 RID: 18405
		// (get) Token: 0x06023B27 RID: 146215 RVA: 0x00989713 File Offset: 0x00987913
		// (set) Token: 0x06023B28 RID: 146216 RVA: 0x00989723 File Offset: 0x00987923
		public unsafe bool bSetParamFromSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047E6 RID: 18406
		// (get) Token: 0x06023B29 RID: 146217 RVA: 0x00989734 File Offset: 0x00987934
		// (set) Token: 0x06023B2A RID: 146218 RVA: 0x00989748 File Offset: 0x00987948
		public unsafe FVector OriginLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170047E7 RID: 18407
		// (get) Token: 0x06023B2B RID: 146219 RVA: 0x0098975D File Offset: 0x0098795D
		// (set) Token: 0x06023B2C RID: 146220 RVA: 0x00989771 File Offset: 0x00987971
		public unsafe FLinearColor PointLatticeColor01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170047E8 RID: 18408
		// (get) Token: 0x06023B2D RID: 146221 RVA: 0x00989786 File Offset: 0x00987986
		// (set) Token: 0x06023B2E RID: 146222 RVA: 0x0098979A File Offset: 0x0098799A
		public unsafe FLinearColor PointLatticeColor02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170047E9 RID: 18409
		// (get) Token: 0x06023B2F RID: 146223 RVA: 0x009897AF File Offset: 0x009879AF
		// (set) Token: 0x06023B30 RID: 146224 RVA: 0x009897C3 File Offset: 0x009879C3
		public unsafe FLinearColor LightningColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170047EA RID: 18410
		// (get) Token: 0x06023B31 RID: 146225 RVA: 0x009897D8 File Offset: 0x009879D8
		// (set) Token: 0x06023B32 RID: 146226 RVA: 0x009897EC File Offset: 0x009879EC
		public unsafe FLinearColor ParticlesColor_Lizi_01_Mobile_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170047EB RID: 18411
		// (get) Token: 0x06023B33 RID: 146227 RVA: 0x00989801 File Offset: 0x00987A01
		// (set) Token: 0x06023B34 RID: 146228 RVA: 0x00989815 File Offset: 0x00987A15
		public unsafe FLinearColor ParticlesColor_Lizi_02_Mobile_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170047EC RID: 18412
		// (get) Token: 0x06023B35 RID: 146229 RVA: 0x0098982A File Offset: 0x00987A2A
		// (set) Token: 0x06023B36 RID: 146230 RVA: 0x0098983E File Offset: 0x00987A3E
		public unsafe FLinearColor ParticlesColor_Fire_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170047ED RID: 18413
		// (get) Token: 0x06023B37 RID: 146231 RVA: 0x00989853 File Offset: 0x00987A53
		// (set) Token: 0x06023B38 RID: 146232 RVA: 0x00989867 File Offset: 0x00987A67
		public unsafe FLinearColor ParticlesColor_FireEdge_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_1_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x06023B39 RID: 146233 RVA: 0x0098987C File Offset: 0x00987A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitNS()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__InitNS_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3A RID: 146234 RVA: 0x00989890 File Offset: 0x00987A90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FadeIn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__FadeIn_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3B RID: 146235 RVA: 0x009898A4 File Offset: 0x00987AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3C RID: 146236 RVA: 0x009898B8 File Offset: 0x00987AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateNS()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__UpdateNS_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3D RID: 146237 RVA: 0x009898CC File Offset: 0x00987ACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__RemoveParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3E RID: 146238 RVA: 0x009898E0 File Offset: 0x00987AE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseAllMagneticStorm()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__CloseAllMagneticStorm_NativeFunctionPtr, null);
		}

		// Token: 0x06023B3F RID: 146239 RVA: 0x009898F4 File Offset: 0x00987AF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InTheBox(FVector pos, ref bool IntheBox)
		{
			BP_MagneticStorm_3_1_C.__InTheBox_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__InTheBox_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__InTheBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__InTheBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->pos = pos;
			ptr->IntheBox = IntheBox;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__InTheBox_NativeFunctionPtr, (void*)ptr);
			IntheBox = ptr->IntheBox;
		}

		// Token: 0x06023B40 RID: 146240 RVA: 0x0098994A File Offset: 0x00987B4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenMagneticStorm()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__OpenMagneticStorm_NativeFunctionPtr, null);
		}

		// Token: 0x06023B41 RID: 146241 RVA: 0x0098995E File Offset: 0x00987B5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B42 RID: 146242 RVA: 0x00989972 File Offset: 0x00987B72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B43 RID: 146243 RVA: 0x00989986 File Offset: 0x00987B86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023B44 RID: 146244 RVA: 0x0098999A File Offset: 0x00987B9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B45 RID: 146245 RVA: 0x009899AF File Offset: 0x00987BAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023B46 RID: 146246 RVA: 0x009899C3 File Offset: 0x00987BC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B47 RID: 146247 RVA: 0x009899D8 File Offset: 0x00987BD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B48 RID: 146248 RVA: 0x00989A20 File Offset: 0x00987C20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B49 RID: 146249 RVA: 0x00989A67 File Offset: 0x00987C67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023B4A RID: 146250 RVA: 0x00989A7B File Offset: 0x00987C7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06023B4B RID: 146251 RVA: 0x00989A8F File Offset: 0x00987C8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B4C RID: 146252 RVA: 0x00989AA4 File Offset: 0x00987CA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B4D RID: 146253 RVA: 0x00989AF0 File Offset: 0x00987CF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B4E RID: 146254 RVA: 0x00989B3C File Offset: 0x00987D3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__SetParamFromSeq_NativeFunctionPtr, null);
		}

		// Token: 0x06023B4F RID: 146255 RVA: 0x00989B50 File Offset: 0x00987D50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MagneticStorm_3_1(int EntryPoint)
		{
			BP_MagneticStorm_3_1_C.__ExecuteUbergraph_BP_MagneticStorm_3_1_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_1_C.__ExecuteUbergraph_BP_MagneticStorm_3_1_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MagneticStorm_3_1_C.__ExecuteUbergraph_BP_MagneticStorm_3_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_1_C.__ExecuteUbergraph_BP_MagneticStorm_3_1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_1_C.__ExecuteUbergraph_BP_MagneticStorm_3_1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B50 RID: 146256 RVA: 0x00989B97 File Offset: 0x00987D97
		protected BP_MagneticStorm_3_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012322 RID: 74530
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_1.BP_MagneticStorm_3_1_C";

		// Token: 0x04012323 RID: 74531
		private static IntPtr _ClassPtr;

		// Token: 0x04012324 RID: 74532
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012325 RID: 74533
		internal static int __PropertyOffset_0;

		// Token: 0x04012326 RID: 74534
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012327 RID: 74535
		internal static int __PropertyOffset_1;

		// Token: 0x04012328 RID: 74536
		internal static int __PropertyOffset_2;

		// Token: 0x04012329 RID: 74537
		internal static int __PropertyOffset_3;

		// Token: 0x0401232A RID: 74538
		internal static int __PropertyOffset_4;

		// Token: 0x0401232B RID: 74539
		internal static int __PropertyOffset_5;

		// Token: 0x0401232C RID: 74540
		internal static int __PropertyOffset_6;

		// Token: 0x0401232D RID: 74541
		internal static int __PropertyOffset_7;

		// Token: 0x0401232E RID: 74542
		internal static int __PropertyOffset_8;

		// Token: 0x0401232F RID: 74543
		internal static int __PropertyOffset_9;

		// Token: 0x04012330 RID: 74544
		internal static int __PropertyOffset_10;

		// Token: 0x04012331 RID: 74545
		internal static int __PropertyOffset_11;

		// Token: 0x04012332 RID: 74546
		internal static int __PropertyOffset_12;

		// Token: 0x04012333 RID: 74547
		internal static int __PropertyOffset_13;

		// Token: 0x04012334 RID: 74548
		internal static int __PropertyOffset_14;

		// Token: 0x04012335 RID: 74549
		internal static int __PropertyOffset_15;

		// Token: 0x04012336 RID: 74550
		internal static int __PropertyOffset_16;

		// Token: 0x04012337 RID: 74551
		internal static int __PropertyOffset_17;

		// Token: 0x04012338 RID: 74552
		internal static int __PropertyOffset_18;

		// Token: 0x04012339 RID: 74553
		internal static int __PropertyOffset_19;

		// Token: 0x0401233A RID: 74554
		internal static int __PropertyOffset_20;

		// Token: 0x0401233B RID: 74555
		internal static int __PropertyOffset_21;

		// Token: 0x0401233C RID: 74556
		internal static int __PropertyOffset_22;

		// Token: 0x0401233D RID: 74557
		internal static int __PropertyOffset_23;

		// Token: 0x0401233E RID: 74558
		internal static int __PropertyOffset_24;

		// Token: 0x0401233F RID: 74559
		internal static int __PropertyOffset_25;

		// Token: 0x04012340 RID: 74560
		internal static int __PropertyOffset_26;

		// Token: 0x04012341 RID: 74561
		internal static int __PropertyOffset_27;

		// Token: 0x04012342 RID: 74562
		internal static int __PropertyOffset_28;

		// Token: 0x04012343 RID: 74563
		internal static int __PropertyOffset_29;

		// Token: 0x04012344 RID: 74564
		internal static int __PropertyOffset_30;

		// Token: 0x04012345 RID: 74565
		private static IntPtr __InitNS_NativeFunctionPtr;

		// Token: 0x04012346 RID: 74566
		private static IntPtr __FadeIn_NativeFunctionPtr;

		// Token: 0x04012347 RID: 74567
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04012348 RID: 74568
		private static IntPtr __UpdateNS_NativeFunctionPtr;

		// Token: 0x04012349 RID: 74569
		private static IntPtr __RemoveParam_NativeFunctionPtr;

		// Token: 0x0401234A RID: 74570
		private static IntPtr __CloseAllMagneticStorm_NativeFunctionPtr;

		// Token: 0x0401234B RID: 74571
		private static IntPtr __InTheBox_NativeFunctionPtr;

		// Token: 0x0401234C RID: 74572
		private static IntPtr __OpenMagneticStorm_NativeFunctionPtr;

		// Token: 0x0401234D RID: 74573
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x0401234E RID: 74574
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x0401234F RID: 74575
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012350 RID: 74576
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012351 RID: 74577
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012352 RID: 74578
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x04012353 RID: 74579
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04012354 RID: 74580
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012355 RID: 74581
		private static IntPtr __SetParamFromSeq_NativeFunctionPtr;

		// Token: 0x04012356 RID: 74582
		private static IntPtr __ExecuteUbergraph_BP_MagneticStorm_3_1_NativeFunctionPtr;

		// Token: 0x02009D1D RID: 40221
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __InTheBox_FunctionParams
		{
			// Token: 0x040326D8 RID: 206552
			[FieldOffset(0)]
			public FVector pos;

			// Token: 0x040326D9 RID: 206553
			[FieldOffset(12)]
			public bool IntheBox;
		}

		// Token: 0x02009D1E RID: 40222
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326DA RID: 206554
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D1F RID: 40223
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040326DB RID: 206555
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D20 RID: 40224
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_MagneticStorm_3_1_FunctionParams
		{
			// Token: 0x040326DC RID: 206556
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
