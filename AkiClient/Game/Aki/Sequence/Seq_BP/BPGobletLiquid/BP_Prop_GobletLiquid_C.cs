using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP.BPGobletLiquid
{
	// Token: 0x0200439E RID: 17310
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BPGobletLiquid/BP_Prop_GobletLiquid.BP_Prop_GobletLiquid_C")]
	[UnrealStructLayout(1728, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1728)]
	public class BP_Prop_GobletLiquid_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DF1E RID: 188190 RVA: 0x00AD27F5 File Offset: 0x00AD09F5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Prop_GobletLiquid_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BPGobletLiquid/BP_Prop_GobletLiquid.BP_Prop_GobletLiquid_C");
			}
			return BP_Prop_GobletLiquid_C._ClassPtr;
		}

		// Token: 0x0602DF1F RID: 188191 RVA: 0x00AD281C File Offset: 0x00AD0A1C
		public BP_Prop_GobletLiquid_C() : this(BuiltinUtils.AllocNativeUObject(BP_Prop_GobletLiquid_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DF20 RID: 188192 RVA: 0x00AD2844 File Offset: 0x00AD0A44
		[NullableContext(1)]
		public BP_Prop_GobletLiquid_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Prop_GobletLiquid_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007E18 RID: 32280
		// (get) Token: 0x0602DF21 RID: 188193 RVA: 0x00AD2878 File Offset: 0x00AD0A78
		// (set) Token: 0x0602DF22 RID: 188194 RVA: 0x00AD28B1 File Offset: 0x00AD0AB1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007E19 RID: 32281
		// (get) Token: 0x0602DF23 RID: 188195 RVA: 0x00AD28D2 File Offset: 0x00AD0AD2
		// (set) Token: 0x0602DF24 RID: 188196 RVA: 0x00AD28E6 File Offset: 0x00AD0AE6
		public unsafe UKuroCollectActorComponent KuroCollectActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCollectActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007E1A RID: 32282
		// (get) Token: 0x0602DF25 RID: 188197 RVA: 0x00AD28FB File Offset: 0x00AD0AFB
		// (set) Token: 0x0602DF26 RID: 188198 RVA: 0x00AD290F File Offset: 0x00AD0B0F
		public unsafe UNiagaraComponent NS_Fx_DrinksIngredients_Fall
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007E1B RID: 32283
		// (get) Token: 0x0602DF27 RID: 188199 RVA: 0x00AD2924 File Offset: 0x00AD0B24
		// (set) Token: 0x0602DF28 RID: 188200 RVA: 0x00AD2938 File Offset: 0x00AD0B38
		public unsafe UNiagaraComponent NS_Fx_DrinkOrnament
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007E1C RID: 32284
		// (get) Token: 0x0602DF29 RID: 188201 RVA: 0x00AD294D File Offset: 0x00AD0B4D
		// (set) Token: 0x0602DF2A RID: 188202 RVA: 0x00AD2961 File Offset: 0x00AD0B61
		public unsafe UNiagaraComponent NS_Fx_DrinksBatching02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007E1D RID: 32285
		// (get) Token: 0x0602DF2B RID: 188203 RVA: 0x00AD2976 File Offset: 0x00AD0B76
		// (set) Token: 0x0602DF2C RID: 188204 RVA: 0x00AD298A File Offset: 0x00AD0B8A
		public unsafe UNiagaraComponent NS_Fx_DrinksBatching01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007E1E RID: 32286
		// (get) Token: 0x0602DF2D RID: 188205 RVA: 0x00AD299F File Offset: 0x00AD0B9F
		// (set) Token: 0x0602DF2E RID: 188206 RVA: 0x00AD29B3 File Offset: 0x00AD0BB3
		public unsafe UNiagaraComponent NS_Fx_Liquid
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007E1F RID: 32287
		// (get) Token: 0x0602DF2F RID: 188207 RVA: 0x00AD29C8 File Offset: 0x00AD0BC8
		// (set) Token: 0x0602DF30 RID: 188208 RVA: 0x00AD29DC File Offset: 0x00AD0BDC
		public unsafe USkeletalMeshComponent Liquid
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007E20 RID: 32288
		// (get) Token: 0x0602DF31 RID: 188209 RVA: 0x00AD29F1 File Offset: 0x00AD0BF1
		// (set) Token: 0x0602DF32 RID: 188210 RVA: 0x00AD2A05 File Offset: 0x00AD0C05
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Prop_GobletLiquid_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007E21 RID: 32289
		// (get) Token: 0x0602DF33 RID: 188211 RVA: 0x00AD2A1A File Offset: 0x00AD0C1A
		// (set) Token: 0x0602DF34 RID: 188212 RVA: 0x00AD2A2E File Offset: 0x00AD0C2E
		public unsafe FLinearColor MainColorPalette
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007E22 RID: 32290
		// (get) Token: 0x0602DF35 RID: 188213 RVA: 0x00AD2A43 File Offset: 0x00AD0C43
		// (set) Token: 0x0602DF36 RID: 188214 RVA: 0x00AD2A57 File Offset: 0x00AD0C57
		public unsafe FLinearColor WaterLineColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007E23 RID: 32291
		// (get) Token: 0x0602DF37 RID: 188215 RVA: 0x00AD2A6C File Offset: 0x00AD0C6C
		// (set) Token: 0x0602DF38 RID: 188216 RVA: 0x00AD2A80 File Offset: 0x00AD0C80
		public unsafe FLinearColor WaterColor_High
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007E24 RID: 32292
		// (get) Token: 0x0602DF39 RID: 188217 RVA: 0x00AD2A95 File Offset: 0x00AD0C95
		// (set) Token: 0x0602DF3A RID: 188218 RVA: 0x00AD2AA9 File Offset: 0x00AD0CA9
		public unsafe FLinearColor WaterColor_Middle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007E25 RID: 32293
		// (get) Token: 0x0602DF3B RID: 188219 RVA: 0x00AD2ABE File Offset: 0x00AD0CBE
		// (set) Token: 0x0602DF3C RID: 188220 RVA: 0x00AD2AD2 File Offset: 0x00AD0CD2
		public unsafe FLinearColor WaterColor_Down
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007E26 RID: 32294
		// (get) Token: 0x0602DF3D RID: 188221 RVA: 0x00AD2AE7 File Offset: 0x00AD0CE7
		// (set) Token: 0x0602DF3E RID: 188222 RVA: 0x00AD2AFB File Offset: 0x00AD0CFB
		public unsafe FLinearColor FresnelColorAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007E27 RID: 32295
		// (get) Token: 0x0602DF3F RID: 188223 RVA: 0x00AD2B10 File Offset: 0x00AD0D10
		// (set) Token: 0x0602DF40 RID: 188224 RVA: 0x00AD2B20 File Offset: 0x00AD0D20
		public unsafe float FresnelRangeWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007E28 RID: 32296
		// (get) Token: 0x0602DF41 RID: 188225 RVA: 0x00AD2B31 File Offset: 0x00AD0D31
		// (set) Token: 0x0602DF42 RID: 188226 RVA: 0x00AD2B41 File Offset: 0x00AD0D41
		public unsafe float RefractIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007E29 RID: 32297
		// (get) Token: 0x0602DF43 RID: 188227 RVA: 0x00AD2B52 File Offset: 0x00AD0D52
		// (set) Token: 0x0602DF44 RID: 188228 RVA: 0x00AD2B62 File Offset: 0x00AD0D62
		public unsafe float WaterRoughness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007E2A RID: 32298
		// (get) Token: 0x0602DF45 RID: 188229 RVA: 0x00AD2B73 File Offset: 0x00AD0D73
		// (set) Token: 0x0602DF46 RID: 188230 RVA: 0x00AD2B83 File Offset: 0x00AD0D83
		public unsafe float WaterMetallic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007E2B RID: 32299
		// (get) Token: 0x0602DF47 RID: 188231 RVA: 0x00AD2B94 File Offset: 0x00AD0D94
		// (set) Token: 0x0602DF48 RID: 188232 RVA: 0x00AD2BA8 File Offset: 0x00AD0DA8
		public unsafe FLinearColor UPColor_Add
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007E2C RID: 32300
		// (get) Token: 0x0602DF49 RID: 188233 RVA: 0x00AD2BBD File Offset: 0x00AD0DBD
		// (set) Token: 0x0602DF4A RID: 188234 RVA: 0x00AD2BD1 File Offset: 0x00AD0DD1
		public unsafe FLinearColor UpLighColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007E2D RID: 32301
		// (get) Token: 0x0602DF4B RID: 188235 RVA: 0x00AD2BE6 File Offset: 0x00AD0DE6
		// (set) Token: 0x0602DF4C RID: 188236 RVA: 0x00AD2BF6 File Offset: 0x00AD0DF6
		public unsafe float Water_HighProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007E2E RID: 32302
		// (get) Token: 0x0602DF4D RID: 188237 RVA: 0x00AD2C07 File Offset: 0x00AD0E07
		// (set) Token: 0x0602DF4E RID: 188238 RVA: 0x00AD2C17 File Offset: 0x00AD0E17
		public unsafe float Water_HighProcess_Seq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007E2F RID: 32303
		// (get) Token: 0x0602DF4F RID: 188239 RVA: 0x00AD2C28 File Offset: 0x00AD0E28
		// (set) Token: 0x0602DF50 RID: 188240 RVA: 0x00AD2C38 File Offset: 0x00AD0E38
		public unsafe float DrinkBatchPosHeighScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007E30 RID: 32304
		// (get) Token: 0x0602DF51 RID: 188241 RVA: 0x00AD2C49 File Offset: 0x00AD0E49
		// (set) Token: 0x0602DF52 RID: 188242 RVA: 0x00AD2C59 File Offset: 0x00AD0E59
		public unsafe float WaterMaskCenterOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17007E31 RID: 32305
		// (get) Token: 0x0602DF53 RID: 188243 RVA: 0x00AD2C6A File Offset: 0x00AD0E6A
		// (set) Token: 0x0602DF54 RID: 188244 RVA: 0x00AD2C7A File Offset: 0x00AD0E7A
		public unsafe float WaterMaskWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17007E32 RID: 32306
		// (get) Token: 0x0602DF55 RID: 188245 RVA: 0x00AD2C8B File Offset: 0x00AD0E8B
		// (set) Token: 0x0602DF56 RID: 188246 RVA: 0x00AD2C9B File Offset: 0x00AD0E9B
		public unsafe float WaterColor_MidHighProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007E33 RID: 32307
		// (get) Token: 0x0602DF57 RID: 188247 RVA: 0x00AD2CAC File Offset: 0x00AD0EAC
		// (set) Token: 0x0602DF58 RID: 188248 RVA: 0x00AD2CBC File Offset: 0x00AD0EBC
		public unsafe float WaterColor_MidHighWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007E34 RID: 32308
		// (get) Token: 0x0602DF59 RID: 188249 RVA: 0x00AD2CCD File Offset: 0x00AD0ECD
		// (set) Token: 0x0602DF5A RID: 188250 RVA: 0x00AD2CDD File Offset: 0x00AD0EDD
		public unsafe float WaterColor_DownMidProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17007E35 RID: 32309
		// (get) Token: 0x0602DF5B RID: 188251 RVA: 0x00AD2CEE File Offset: 0x00AD0EEE
		// (set) Token: 0x0602DF5C RID: 188252 RVA: 0x00AD2CFE File Offset: 0x00AD0EFE
		public unsafe float WaterColor_DownMidWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007E36 RID: 32310
		// (get) Token: 0x0602DF5D RID: 188253 RVA: 0x00AD2D0F File Offset: 0x00AD0F0F
		// (set) Token: 0x0602DF5E RID: 188254 RVA: 0x00AD2D1F File Offset: 0x00AD0F1F
		public unsafe float UpLightMask_Process
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17007E37 RID: 32311
		// (get) Token: 0x0602DF5F RID: 188255 RVA: 0x00AD2D30 File Offset: 0x00AD0F30
		// (set) Token: 0x0602DF60 RID: 188256 RVA: 0x00AD2D40 File Offset: 0x00AD0F40
		public unsafe float BubbleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17007E38 RID: 32312
		// (get) Token: 0x0602DF61 RID: 188257 RVA: 0x00AD2D51 File Offset: 0x00AD0F51
		// (set) Token: 0x0602DF62 RID: 188258 RVA: 0x00AD2D61 File Offset: 0x00AD0F61
		public unsafe float BubbleSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17007E39 RID: 32313
		// (get) Token: 0x0602DF63 RID: 188259 RVA: 0x00AD2D72 File Offset: 0x00AD0F72
		// (set) Token: 0x0602DF64 RID: 188260 RVA: 0x00AD2D82 File Offset: 0x00AD0F82
		public unsafe int DrinkOrnament_Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17007E3A RID: 32314
		// (get) Token: 0x0602DF65 RID: 188261 RVA: 0x00AD2D93 File Offset: 0x00AD0F93
		// (set) Token: 0x0602DF66 RID: 188262 RVA: 0x00AD2DA3 File Offset: 0x00AD0FA3
		public unsafe int DrinksBatching_Tag01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17007E3B RID: 32315
		// (get) Token: 0x0602DF67 RID: 188263 RVA: 0x00AD2DB4 File Offset: 0x00AD0FB4
		// (set) Token: 0x0602DF68 RID: 188264 RVA: 0x00AD2DC4 File Offset: 0x00AD0FC4
		public unsafe int DrinksBatching_Tag02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17007E3C RID: 32316
		// (get) Token: 0x0602DF69 RID: 188265 RVA: 0x00AD2DD5 File Offset: 0x00AD0FD5
		// (set) Token: 0x0602DF6A RID: 188266 RVA: 0x00AD2DE5 File Offset: 0x00AD0FE5
		public unsafe int DrinksIngredientsFall_Tag01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17007E3D RID: 32317
		// (get) Token: 0x0602DF6B RID: 188267 RVA: 0x00AD2DF6 File Offset: 0x00AD0FF6
		// (set) Token: 0x0602DF6C RID: 188268 RVA: 0x00AD2E06 File Offset: 0x00AD1006
		public unsafe int DrinksIngredientsFall_Tag02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17007E3E RID: 32318
		// (get) Token: 0x0602DF6D RID: 188269 RVA: 0x00AD2E17 File Offset: 0x00AD1017
		// (set) Token: 0x0602DF6E RID: 188270 RVA: 0x00AD2E2B File Offset: 0x00AD102B
		public unsafe FVector DrinksIngredientsFall_LocationStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17007E3F RID: 32319
		// (get) Token: 0x0602DF6F RID: 188271 RVA: 0x00AD2E40 File Offset: 0x00AD1040
		// (set) Token: 0x0602DF70 RID: 188272 RVA: 0x00AD2E50 File Offset: 0x00AD1050
		public unsafe float Liquid_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17007E40 RID: 32320
		// (get) Token: 0x0602DF71 RID: 188273 RVA: 0x00AD2E61 File Offset: 0x00AD1061
		// (set) Token: 0x0602DF72 RID: 188274 RVA: 0x00AD2E71 File Offset: 0x00AD1071
		public unsafe float DrinkOrnament_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17007E41 RID: 32321
		// (get) Token: 0x0602DF73 RID: 188275 RVA: 0x00AD2E82 File Offset: 0x00AD1082
		// (set) Token: 0x0602DF74 RID: 188276 RVA: 0x00AD2E96 File Offset: 0x00AD1096
		public unsafe FVector DrinkOrnament_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17007E42 RID: 32322
		// (get) Token: 0x0602DF75 RID: 188277 RVA: 0x00AD2EAB File Offset: 0x00AD10AB
		// (set) Token: 0x0602DF76 RID: 188278 RVA: 0x00AD2EBF File Offset: 0x00AD10BF
		public unsafe FRotator DrinkOrnament_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17007E43 RID: 32323
		// (get) Token: 0x0602DF77 RID: 188279 RVA: 0x00AD2ED4 File Offset: 0x00AD10D4
		// (set) Token: 0x0602DF78 RID: 188280 RVA: 0x00AD2EE4 File Offset: 0x00AD10E4
		public unsafe float DrinksBatching_Scale01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17007E44 RID: 32324
		// (get) Token: 0x0602DF79 RID: 188281 RVA: 0x00AD2EF5 File Offset: 0x00AD10F5
		// (set) Token: 0x0602DF7A RID: 188282 RVA: 0x00AD2F05 File Offset: 0x00AD1105
		public unsafe float DrinksBatching_Scale02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17007E45 RID: 32325
		// (get) Token: 0x0602DF7B RID: 188283 RVA: 0x00AD2F16 File Offset: 0x00AD1116
		// (set) Token: 0x0602DF7C RID: 188284 RVA: 0x00AD2F26 File Offset: 0x00AD1126
		public unsafe float DrinkBatchPosScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17007E46 RID: 32326
		// (get) Token: 0x0602DF7D RID: 188285 RVA: 0x00AD2F37 File Offset: 0x00AD1137
		// (set) Token: 0x0602DF7E RID: 188286 RVA: 0x00AD2F4B File Offset: 0x00AD114B
		public unsafe FVector DrinkBatchPosOnLiquid01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17007E47 RID: 32327
		// (get) Token: 0x0602DF7F RID: 188287 RVA: 0x00AD2F60 File Offset: 0x00AD1160
		// (set) Token: 0x0602DF80 RID: 188288 RVA: 0x00AD2F74 File Offset: 0x00AD1174
		public unsafe FVector DrinkBatchPosOnLiquid02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17007E48 RID: 32328
		// (get) Token: 0x0602DF81 RID: 188289 RVA: 0x00AD2F89 File Offset: 0x00AD1189
		// (set) Token: 0x0602DF82 RID: 188290 RVA: 0x00AD2F99 File Offset: 0x00AD1199
		public unsafe bool UseLiquidSocketPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E49 RID: 32329
		// (get) Token: 0x0602DF83 RID: 188291 RVA: 0x00AD2FAA File Offset: 0x00AD11AA
		// (set) Token: 0x0602DF84 RID: 188292 RVA: 0x00AD2FBA File Offset: 0x00AD11BA
		public unsafe bool IsUpdateMPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E4A RID: 32330
		// (get) Token: 0x0602DF85 RID: 188293 RVA: 0x00AD2FCB File Offset: 0x00AD11CB
		// (set) Token: 0x0602DF86 RID: 188294 RVA: 0x00AD2FDB File Offset: 0x00AD11DB
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E4B RID: 32331
		// (get) Token: 0x0602DF87 RID: 188295 RVA: 0x00AD2FEC File Offset: 0x00AD11EC
		// (set) Token: 0x0602DF88 RID: 188296 RVA: 0x00AD3000 File Offset: 0x00AD1200
		public unsafe FVectorDouble LiquidLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17007E4C RID: 32332
		// (get) Token: 0x0602DF89 RID: 188297 RVA: 0x00AD3015 File Offset: 0x00AD1215
		// (set) Token: 0x0602DF8A RID: 188298 RVA: 0x00AD3029 File Offset: 0x00AD1229
		public unsafe FName LiquidSocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17007E4D RID: 32333
		// (get) Token: 0x0602DF8B RID: 188299 RVA: 0x00AD303E File Offset: 0x00AD123E
		// (set) Token: 0x0602DF8C RID: 188300 RVA: 0x00AD3052 File Offset: 0x00AD1252
		public unsafe FName BatchSocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Prop_GobletLiquid_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x0602DF8D RID: 188301 RVA: 0x00AD3067 File Offset: 0x00AD1267
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLiquidAndFallTag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__UpdateLiquidAndFallTag_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF8E RID: 188302 RVA: 0x00AD307C File Offset: 0x00AD127C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBatchLiquidHeight(ref float LiquidHeight)
		{
			BP_Prop_GobletLiquid_C.__GetBatchLiquidHeight_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__GetBatchLiquidHeight_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__GetBatchLiquidHeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__GetBatchLiquidHeight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LiquidHeight = LiquidHeight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__GetBatchLiquidHeight_NativeFunctionPtr, (void*)ptr);
			LiquidHeight = ptr->LiquidHeight;
		}

		// Token: 0x0602DF8F RID: 188303 RVA: 0x00AD30CB File Offset: 0x00AD12CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLiquidMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__UpdateLiquidMPC_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF90 RID: 188304 RVA: 0x00AD30DF File Offset: 0x00AD12DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayBatchingFallNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__PlayBatchingFallNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF91 RID: 188305 RVA: 0x00AD30F3 File Offset: 0x00AD12F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayLiquidNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__PlayLiquidNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF92 RID: 188306 RVA: 0x00AD3107 File Offset: 0x00AD1307
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateGobletLiguid()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__UpdateGobletLiguid_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF93 RID: 188307 RVA: 0x00AD311B File Offset: 0x00AD131B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DF94 RID: 188308 RVA: 0x00AD312F File Offset: 0x00AD132F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DF95 RID: 188309 RVA: 0x00AD3144 File Offset: 0x00AD1344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DF96 RID: 188310 RVA: 0x00AD318C File Offset: 0x00AD138C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF97 RID: 188311 RVA: 0x00AD31D4 File Offset: 0x00AD13D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DF98 RID: 188312 RVA: 0x00AD321C File Offset: 0x00AD141C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF99 RID: 188313 RVA: 0x00AD3264 File Offset: 0x00AD1464
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Prop_GobletLiquid(int EntryPoint)
		{
			BP_Prop_GobletLiquid_C.__ExecuteUbergraph_BP_Prop_GobletLiquid_FunctionParams* ptr = stackalloc BP_Prop_GobletLiquid_C.__ExecuteUbergraph_BP_Prop_GobletLiquid_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_Prop_GobletLiquid_C.__ExecuteUbergraph_BP_Prop_GobletLiquid_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Prop_GobletLiquid_C.__ExecuteUbergraph_BP_Prop_GobletLiquid_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Prop_GobletLiquid_C.__ExecuteUbergraph_BP_Prop_GobletLiquid_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DF9A RID: 188314 RVA: 0x00AD32AE File Offset: 0x00AD14AE
		protected BP_Prop_GobletLiquid_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019F6B RID: 106347
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BPGobletLiquid/BP_Prop_GobletLiquid.BP_Prop_GobletLiquid_C";

		// Token: 0x04019F6C RID: 106348
		private static IntPtr _ClassPtr;

		// Token: 0x04019F6D RID: 106349
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019F6E RID: 106350
		internal static int __PropertyOffset_0;

		// Token: 0x04019F6F RID: 106351
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019F70 RID: 106352
		internal static int __PropertyOffset_1;

		// Token: 0x04019F71 RID: 106353
		internal static int __PropertyOffset_2;

		// Token: 0x04019F72 RID: 106354
		internal static int __PropertyOffset_3;

		// Token: 0x04019F73 RID: 106355
		internal static int __PropertyOffset_4;

		// Token: 0x04019F74 RID: 106356
		internal static int __PropertyOffset_5;

		// Token: 0x04019F75 RID: 106357
		internal static int __PropertyOffset_6;

		// Token: 0x04019F76 RID: 106358
		internal static int __PropertyOffset_7;

		// Token: 0x04019F77 RID: 106359
		internal static int __PropertyOffset_8;

		// Token: 0x04019F78 RID: 106360
		internal static int __PropertyOffset_9;

		// Token: 0x04019F79 RID: 106361
		internal static int __PropertyOffset_10;

		// Token: 0x04019F7A RID: 106362
		internal static int __PropertyOffset_11;

		// Token: 0x04019F7B RID: 106363
		internal static int __PropertyOffset_12;

		// Token: 0x04019F7C RID: 106364
		internal static int __PropertyOffset_13;

		// Token: 0x04019F7D RID: 106365
		internal static int __PropertyOffset_14;

		// Token: 0x04019F7E RID: 106366
		internal static int __PropertyOffset_15;

		// Token: 0x04019F7F RID: 106367
		internal static int __PropertyOffset_16;

		// Token: 0x04019F80 RID: 106368
		internal static int __PropertyOffset_17;

		// Token: 0x04019F81 RID: 106369
		internal static int __PropertyOffset_18;

		// Token: 0x04019F82 RID: 106370
		internal static int __PropertyOffset_19;

		// Token: 0x04019F83 RID: 106371
		internal static int __PropertyOffset_20;

		// Token: 0x04019F84 RID: 106372
		internal static int __PropertyOffset_21;

		// Token: 0x04019F85 RID: 106373
		internal static int __PropertyOffset_22;

		// Token: 0x04019F86 RID: 106374
		internal static int __PropertyOffset_23;

		// Token: 0x04019F87 RID: 106375
		internal static int __PropertyOffset_24;

		// Token: 0x04019F88 RID: 106376
		internal static int __PropertyOffset_25;

		// Token: 0x04019F89 RID: 106377
		internal static int __PropertyOffset_26;

		// Token: 0x04019F8A RID: 106378
		internal static int __PropertyOffset_27;

		// Token: 0x04019F8B RID: 106379
		internal static int __PropertyOffset_28;

		// Token: 0x04019F8C RID: 106380
		internal static int __PropertyOffset_29;

		// Token: 0x04019F8D RID: 106381
		internal static int __PropertyOffset_30;

		// Token: 0x04019F8E RID: 106382
		internal static int __PropertyOffset_31;

		// Token: 0x04019F8F RID: 106383
		internal static int __PropertyOffset_32;

		// Token: 0x04019F90 RID: 106384
		internal static int __PropertyOffset_33;

		// Token: 0x04019F91 RID: 106385
		internal static int __PropertyOffset_34;

		// Token: 0x04019F92 RID: 106386
		internal static int __PropertyOffset_35;

		// Token: 0x04019F93 RID: 106387
		internal static int __PropertyOffset_36;

		// Token: 0x04019F94 RID: 106388
		internal static int __PropertyOffset_37;

		// Token: 0x04019F95 RID: 106389
		internal static int __PropertyOffset_38;

		// Token: 0x04019F96 RID: 106390
		internal static int __PropertyOffset_39;

		// Token: 0x04019F97 RID: 106391
		internal static int __PropertyOffset_40;

		// Token: 0x04019F98 RID: 106392
		internal static int __PropertyOffset_41;

		// Token: 0x04019F99 RID: 106393
		internal static int __PropertyOffset_42;

		// Token: 0x04019F9A RID: 106394
		internal static int __PropertyOffset_43;

		// Token: 0x04019F9B RID: 106395
		internal static int __PropertyOffset_44;

		// Token: 0x04019F9C RID: 106396
		internal static int __PropertyOffset_45;

		// Token: 0x04019F9D RID: 106397
		internal static int __PropertyOffset_46;

		// Token: 0x04019F9E RID: 106398
		internal static int __PropertyOffset_47;

		// Token: 0x04019F9F RID: 106399
		internal static int __PropertyOffset_48;

		// Token: 0x04019FA0 RID: 106400
		internal static int __PropertyOffset_49;

		// Token: 0x04019FA1 RID: 106401
		internal static int __PropertyOffset_50;

		// Token: 0x04019FA2 RID: 106402
		internal static int __PropertyOffset_51;

		// Token: 0x04019FA3 RID: 106403
		internal static int __PropertyOffset_52;

		// Token: 0x04019FA4 RID: 106404
		internal static int __PropertyOffset_53;

		// Token: 0x04019FA5 RID: 106405
		private static IntPtr __UpdateLiquidAndFallTag_NativeFunctionPtr;

		// Token: 0x04019FA6 RID: 106406
		private static IntPtr __GetBatchLiquidHeight_NativeFunctionPtr;

		// Token: 0x04019FA7 RID: 106407
		private static IntPtr __UpdateLiquidMPC_NativeFunctionPtr;

		// Token: 0x04019FA8 RID: 106408
		private static IntPtr __PlayBatchingFallNiagara_NativeFunctionPtr;

		// Token: 0x04019FA9 RID: 106409
		private static IntPtr __PlayLiquidNiagara_NativeFunctionPtr;

		// Token: 0x04019FAA RID: 106410
		private static IntPtr __UpdateGobletLiguid_NativeFunctionPtr;

		// Token: 0x04019FAB RID: 106411
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04019FAC RID: 106412
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019FAD RID: 106413
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04019FAE RID: 106414
		private static IntPtr __ExecuteUbergraph_BP_Prop_GobletLiquid_NativeFunctionPtr;

		// Token: 0x0200A600 RID: 42496
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetBatchLiquidHeight_FunctionParams
		{
			// Token: 0x040335B3 RID: 210355
			[FieldOffset(0)]
			public float LiquidHeight;
		}

		// Token: 0x0200A601 RID: 42497
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040335B4 RID: 210356
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A602 RID: 42498
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040335B5 RID: 210357
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A603 RID: 42499
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __ExecuteUbergraph_BP_Prop_GobletLiquid_FunctionParams
		{
			// Token: 0x040335B6 RID: 210358
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
