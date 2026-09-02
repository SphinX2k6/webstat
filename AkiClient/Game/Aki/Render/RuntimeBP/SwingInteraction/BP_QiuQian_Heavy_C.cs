using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A42 RID: 14914
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian_Heavy.BP_QiuQian_Heavy_C")]
	[UnrealStructLayout(1568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1561)]
	public class BP_QiuQian_Heavy_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601ED41 RID: 126273 RVA: 0x008FF92F File Offset: 0x008FDB2F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QiuQian_Heavy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian_Heavy.BP_QiuQian_Heavy_C");
			}
			return BP_QiuQian_Heavy_C._ClassPtr;
		}

		// Token: 0x0601ED42 RID: 126274 RVA: 0x008FF954 File Offset: 0x008FDB54
		public BP_QiuQian_Heavy_C() : this(BuiltinUtils.AllocNativeUObject(BP_QiuQian_Heavy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601ED43 RID: 126275 RVA: 0x008FF97C File Offset: 0x008FDB7C
		[NullableContext(1)]
		public BP_QiuQian_Heavy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QiuQian_Heavy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002CA9 RID: 11433
		// (get) Token: 0x0601ED44 RID: 126276 RVA: 0x008FF9B0 File Offset: 0x008FDBB0
		// (set) Token: 0x0601ED45 RID: 126277 RVA: 0x008FF9E9 File Offset: 0x008FDBE9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002CAA RID: 11434
		// (get) Token: 0x0601ED46 RID: 126278 RVA: 0x008FFA0A File Offset: 0x008FDC0A
		// (set) Token: 0x0601ED47 RID: 126279 RVA: 0x008FFA1E File Offset: 0x008FDC1E
		public unsafe UStaticMeshComponent SM_Old_Eff_02BS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002CAB RID: 11435
		// (get) Token: 0x0601ED48 RID: 126280 RVA: 0x008FFA33 File Offset: 0x008FDC33
		// (set) Token: 0x0601ED49 RID: 126281 RVA: 0x008FFA47 File Offset: 0x008FDC47
		public unsafe UStaticMeshComponent SM_SwingSingleRopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002CAC RID: 11436
		// (get) Token: 0x0601ED4A RID: 126282 RVA: 0x008FFA5C File Offset: 0x008FDC5C
		// (set) Token: 0x0601ED4B RID: 126283 RVA: 0x008FFA70 File Offset: 0x008FDC70
		public unsafe UStaticMeshComponent SM_SwingSingleRopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002CAD RID: 11437
		// (get) Token: 0x0601ED4C RID: 126284 RVA: 0x008FFA85 File Offset: 0x008FDC85
		// (set) Token: 0x0601ED4D RID: 126285 RVA: 0x008FFA99 File Offset: 0x008FDC99
		public unsafe UStaticMeshComponent SM_SwingTop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002CAE RID: 11438
		// (get) Token: 0x0601ED4E RID: 126286 RVA: 0x008FFAAE File Offset: 0x008FDCAE
		// (set) Token: 0x0601ED4F RID: 126287 RVA: 0x008FFAC2 File Offset: 0x008FDCC2
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002CAF RID: 11439
		// (get) Token: 0x0601ED50 RID: 126288 RVA: 0x008FFAD7 File Offset: 0x008FDCD7
		// (set) Token: 0x0601ED51 RID: 126289 RVA: 0x008FFAEB File Offset: 0x008FDCEB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002CB0 RID: 11440
		// (get) Token: 0x0601ED52 RID: 126290 RVA: 0x008FFB00 File Offset: 0x008FDD00
		// (set) Token: 0x0601ED53 RID: 126291 RVA: 0x008FFB39 File Offset: 0x008FDD39
		[Nullable(1)]
		public TArray<FName> NameList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._NameList) == null)
				{
					result = (this._NameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NameList.CopyAssign(value);
			}
		}

		// Token: 0x17002CB1 RID: 11441
		// (get) Token: 0x0601ED54 RID: 126292 RVA: 0x008FFB47 File Offset: 0x008FDD47
		// (set) Token: 0x0601ED55 RID: 126293 RVA: 0x008FFB57 File Offset: 0x008FDD57
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CB2 RID: 11442
		// (get) Token: 0x0601ED56 RID: 126294 RVA: 0x008FFB68 File Offset: 0x008FDD68
		// (set) Token: 0x0601ED57 RID: 126295 RVA: 0x008FFB78 File Offset: 0x008FDD78
		public unsafe bool bUseConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CB3 RID: 11443
		// (get) Token: 0x0601ED58 RID: 126296 RVA: 0x008FFB89 File Offset: 0x008FDD89
		// (set) Token: 0x0601ED59 RID: 126297 RVA: 0x008FFB99 File Offset: 0x008FDD99
		public unsafe float ConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002CB4 RID: 11444
		// (get) Token: 0x0601ED5A RID: 126298 RVA: 0x008FFBAA File Offset: 0x008FDDAA
		// (set) Token: 0x0601ED5B RID: 126299 RVA: 0x008FFBBE File Offset: 0x008FDDBE
		public unsafe FVector StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002CB5 RID: 11445
		// (get) Token: 0x0601ED5C RID: 126300 RVA: 0x008FFBD3 File Offset: 0x008FDDD3
		// (set) Token: 0x0601ED5D RID: 126301 RVA: 0x008FFBE3 File Offset: 0x008FDDE3
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002CB6 RID: 11446
		// (get) Token: 0x0601ED5E RID: 126302 RVA: 0x008FFBF4 File Offset: 0x008FDDF4
		// (set) Token: 0x0601ED5F RID: 126303 RVA: 0x008FFC04 File Offset: 0x008FDE04
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002CB7 RID: 11447
		// (get) Token: 0x0601ED60 RID: 126304 RVA: 0x008FFC15 File Offset: 0x008FDE15
		// (set) Token: 0x0601ED61 RID: 126305 RVA: 0x008FFC29 File Offset: 0x008FDE29
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002CB8 RID: 11448
		// (get) Token: 0x0601ED62 RID: 126306 RVA: 0x008FFC3E File Offset: 0x008FDE3E
		// (set) Token: 0x0601ED63 RID: 126307 RVA: 0x008FFC4E File Offset: 0x008FDE4E
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002CB9 RID: 11449
		// (get) Token: 0x0601ED64 RID: 126308 RVA: 0x008FFC5F File Offset: 0x008FDE5F
		// (set) Token: 0x0601ED65 RID: 126309 RVA: 0x008FFC6F File Offset: 0x008FDE6F
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002CBA RID: 11450
		// (get) Token: 0x0601ED66 RID: 126310 RVA: 0x008FFC80 File Offset: 0x008FDE80
		// (set) Token: 0x0601ED67 RID: 126311 RVA: 0x008FFC94 File Offset: 0x008FDE94
		public unsafe FVector startPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002CBB RID: 11451
		// (get) Token: 0x0601ED68 RID: 126312 RVA: 0x008FFCA9 File Offset: 0x008FDEA9
		// (set) Token: 0x0601ED69 RID: 126313 RVA: 0x008FFCBD File Offset: 0x008FDEBD
		public unsafe FVector endPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002CBC RID: 11452
		// (get) Token: 0x0601ED6A RID: 126314 RVA: 0x008FFCD2 File Offset: 0x008FDED2
		// (set) Token: 0x0601ED6B RID: 126315 RVA: 0x008FFCE6 File Offset: 0x008FDEE6
		public unsafe FVector leftPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002CBD RID: 11453
		// (get) Token: 0x0601ED6C RID: 126316 RVA: 0x008FFCFB File Offset: 0x008FDEFB
		// (set) Token: 0x0601ED6D RID: 126317 RVA: 0x008FFD0F File Offset: 0x008FDF0F
		public unsafe FVector rightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002CBE RID: 11454
		// (get) Token: 0x0601ED6E RID: 126318 RVA: 0x008FFD24 File Offset: 0x008FDF24
		// (set) Token: 0x0601ED6F RID: 126319 RVA: 0x008FFD38 File Offset: 0x008FDF38
		public unsafe FVector leftNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002CBF RID: 11455
		// (get) Token: 0x0601ED70 RID: 126320 RVA: 0x008FFD50 File Offset: 0x008FDF50
		// (set) Token: 0x0601ED71 RID: 126321 RVA: 0x008FFD89 File Offset: 0x008FDF89
		[Nullable(1)]
		public TArray<FParticle_QiuQian> particleArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FParticle_QiuQian> result;
				if ((result = this._particleArr) == null)
				{
					result = (this._particleArr = new TArray<FParticle_QiuQian>(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_22, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.particleArr.CopyAssign(value);
			}
		}

		// Token: 0x17002CC0 RID: 11456
		// (get) Token: 0x0601ED72 RID: 126322 RVA: 0x008FFD97 File Offset: 0x008FDF97
		// (set) Token: 0x0601ED73 RID: 126323 RVA: 0x008FFDAB File Offset: 0x008FDFAB
		public unsafe FVector rightNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002CC1 RID: 11457
		// (get) Token: 0x0601ED74 RID: 126324 RVA: 0x008FFDC0 File Offset: 0x008FDFC0
		// (set) Token: 0x0601ED75 RID: 126325 RVA: 0x008FFDD0 File Offset: 0x008FDFD0
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002CC2 RID: 11458
		// (get) Token: 0x0601ED76 RID: 126326 RVA: 0x008FFDE1 File Offset: 0x008FDFE1
		// (set) Token: 0x0601ED77 RID: 126327 RVA: 0x008FFDF1 File Offset: 0x008FDFF1
		public unsafe float endParticleMassScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002CC3 RID: 11459
		// (get) Token: 0x0601ED78 RID: 126328 RVA: 0x008FFE02 File Offset: 0x008FE002
		// (set) Token: 0x0601ED79 RID: 126329 RVA: 0x008FFE12 File Offset: 0x008FE012
		public unsafe float debugDrawDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002CC4 RID: 11460
		// (get) Token: 0x0601ED7A RID: 126330 RVA: 0x008FFE23 File Offset: 0x008FE023
		// (set) Token: 0x0601ED7B RID: 126331 RVA: 0x008FFE33 File Offset: 0x008FE033
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CC5 RID: 11461
		// (get) Token: 0x0601ED7C RID: 126332 RVA: 0x008FFE44 File Offset: 0x008FE044
		// (set) Token: 0x0601ED7D RID: 126333 RVA: 0x008FFE54 File Offset: 0x008FE054
		public unsafe bool IsPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CC6 RID: 11462
		// (get) Token: 0x0601ED7E RID: 126334 RVA: 0x008FFE65 File Offset: 0x008FE065
		// (set) Token: 0x0601ED7F RID: 126335 RVA: 0x008FFE79 File Offset: 0x008FE079
		public unsafe UMaterialInstanceDynamic DMI_RopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17002CC7 RID: 11463
		// (get) Token: 0x0601ED80 RID: 126336 RVA: 0x008FFE8E File Offset: 0x008FE08E
		// (set) Token: 0x0601ED81 RID: 126337 RVA: 0x008FFEA2 File Offset: 0x008FE0A2
		public unsafe UMaterialInstanceDynamic DMI_RopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_Heavy_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17002CC8 RID: 11464
		// (get) Token: 0x0601ED82 RID: 126338 RVA: 0x008FFEB7 File Offset: 0x008FE0B7
		// (set) Token: 0x0601ED83 RID: 126339 RVA: 0x008FFEC7 File Offset: 0x008FE0C7
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002CC9 RID: 11465
		// (get) Token: 0x0601ED84 RID: 126340 RVA: 0x008FFED8 File Offset: 0x008FE0D8
		// (set) Token: 0x0601ED85 RID: 126341 RVA: 0x008FFEE8 File Offset: 0x008FE0E8
		public unsafe float WarmTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002CCA RID: 11466
		// (get) Token: 0x0601ED86 RID: 126342 RVA: 0x008FFEF9 File Offset: 0x008FE0F9
		// (set) Token: 0x0601ED87 RID: 126343 RVA: 0x008FFF09 File Offset: 0x008FE109
		public unsafe bool IsWarm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_Heavy_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601ED88 RID: 126344 RVA: 0x008FFF1A File Offset: 0x008FE11A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParticleArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__InitializeParticleArr_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED89 RID: 126345 RVA: 0x008FFF30 File Offset: 0x008FE130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIOffsetEnable(bool OffsetEnable)
		{
			BP_QiuQian_Heavy_C.__SetDMIOffsetEnable_FunctionParams* ptr = stackalloc BP_QiuQian_Heavy_C.__SetDMIOffsetEnable_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_QiuQian_Heavy_C.__SetDMIOffsetEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_Heavy_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OffsetEnable = OffsetEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ED8A RID: 126346 RVA: 0x008FFF76 File Offset: 0x008FE176
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateaDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__UpdateaDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED8B RID: 126347 RVA: 0x008FFF8A File Offset: 0x008FE18A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__InitializeDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED8C RID: 126348 RVA: 0x008FFFA0 File Offset: 0x008FE1A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_QiuQian_Heavy_C.__solve_FunctionParams* ptr = stackalloc BP_QiuQian_Heavy_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_QiuQian_Heavy_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_Heavy_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x0601ED8D RID: 126349 RVA: 0x00900021 File Offset: 0x008FE221
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED8E RID: 126350 RVA: 0x00900035 File Offset: 0x008FE235
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED8F RID: 126351 RVA: 0x0090004A File Offset: 0x008FE24A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED90 RID: 126352 RVA: 0x0090005E File Offset: 0x008FE25E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED91 RID: 126353 RVA: 0x00900074 File Offset: 0x008FE274
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_Heavy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ED92 RID: 126354 RVA: 0x009000BC File Offset: 0x008FE2BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQian_Heavy_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_Heavy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ED93 RID: 126355 RVA: 0x00900103 File Offset: 0x008FE303
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void place_plank_event()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__place_plank_event_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED94 RID: 126356 RVA: 0x00900117 File Offset: 0x008FE317
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED95 RID: 126357 RVA: 0x0090012B File Offset: 0x008FE32B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED96 RID: 126358 RVA: 0x00900140 File Offset: 0x008FE340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED97 RID: 126359 RVA: 0x00900154 File Offset: 0x008FE354
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED98 RID: 126360 RVA: 0x0090016C File Offset: 0x008FE36C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QiuQian_Heavy(int EntryPoint)
		{
			BP_QiuQian_Heavy_C.__ExecuteUbergraph_BP_QiuQian_Heavy_FunctionParams* ptr = stackalloc BP_QiuQian_Heavy_C.__ExecuteUbergraph_BP_QiuQian_Heavy_FunctionParams[(UIntPtr)1967] + 15L / (long)sizeof(BP_QiuQian_Heavy_C.__ExecuteUbergraph_BP_QiuQian_Heavy_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_Heavy_C.__ExecuteUbergraph_BP_QiuQian_Heavy_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_Heavy_C.__ExecuteUbergraph_BP_QiuQian_Heavy_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ED99 RID: 126361 RVA: 0x009001B6 File Offset: 0x008FE3B6
		protected BP_QiuQian_Heavy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F39C RID: 62364
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian_Heavy.BP_QiuQian_Heavy_C";

		// Token: 0x0400F39D RID: 62365
		private static IntPtr _ClassPtr;

		// Token: 0x0400F39E RID: 62366
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F39F RID: 62367
		internal static int __PropertyOffset_0;

		// Token: 0x0400F3A0 RID: 62368
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F3A1 RID: 62369
		internal static int __PropertyOffset_1;

		// Token: 0x0400F3A2 RID: 62370
		internal static int __PropertyOffset_2;

		// Token: 0x0400F3A3 RID: 62371
		internal static int __PropertyOffset_3;

		// Token: 0x0400F3A4 RID: 62372
		internal static int __PropertyOffset_4;

		// Token: 0x0400F3A5 RID: 62373
		internal static int __PropertyOffset_5;

		// Token: 0x0400F3A6 RID: 62374
		internal static int __PropertyOffset_6;

		// Token: 0x0400F3A7 RID: 62375
		internal static int __PropertyOffset_7;

		// Token: 0x0400F3A8 RID: 62376
		private TArray<FName> _NameList;

		// Token: 0x0400F3A9 RID: 62377
		internal static int __PropertyOffset_8;

		// Token: 0x0400F3AA RID: 62378
		internal static int __PropertyOffset_9;

		// Token: 0x0400F3AB RID: 62379
		internal static int __PropertyOffset_10;

		// Token: 0x0400F3AC RID: 62380
		internal static int __PropertyOffset_11;

		// Token: 0x0400F3AD RID: 62381
		internal static int __PropertyOffset_12;

		// Token: 0x0400F3AE RID: 62382
		internal static int __PropertyOffset_13;

		// Token: 0x0400F3AF RID: 62383
		internal static int __PropertyOffset_14;

		// Token: 0x0400F3B0 RID: 62384
		internal static int __PropertyOffset_15;

		// Token: 0x0400F3B1 RID: 62385
		internal static int __PropertyOffset_16;

		// Token: 0x0400F3B2 RID: 62386
		internal static int __PropertyOffset_17;

		// Token: 0x0400F3B3 RID: 62387
		internal static int __PropertyOffset_18;

		// Token: 0x0400F3B4 RID: 62388
		internal static int __PropertyOffset_19;

		// Token: 0x0400F3B5 RID: 62389
		internal static int __PropertyOffset_20;

		// Token: 0x0400F3B6 RID: 62390
		internal static int __PropertyOffset_21;

		// Token: 0x0400F3B7 RID: 62391
		internal static int __PropertyOffset_22;

		// Token: 0x0400F3B8 RID: 62392
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FParticle_QiuQian> _particleArr;

		// Token: 0x0400F3B9 RID: 62393
		internal static int __PropertyOffset_23;

		// Token: 0x0400F3BA RID: 62394
		internal static int __PropertyOffset_24;

		// Token: 0x0400F3BB RID: 62395
		internal static int __PropertyOffset_25;

		// Token: 0x0400F3BC RID: 62396
		internal static int __PropertyOffset_26;

		// Token: 0x0400F3BD RID: 62397
		internal static int __PropertyOffset_27;

		// Token: 0x0400F3BE RID: 62398
		internal static int __PropertyOffset_28;

		// Token: 0x0400F3BF RID: 62399
		internal static int __PropertyOffset_29;

		// Token: 0x0400F3C0 RID: 62400
		internal static int __PropertyOffset_30;

		// Token: 0x0400F3C1 RID: 62401
		internal static int __PropertyOffset_31;

		// Token: 0x0400F3C2 RID: 62402
		internal static int __PropertyOffset_32;

		// Token: 0x0400F3C3 RID: 62403
		internal static int __PropertyOffset_33;

		// Token: 0x0400F3C4 RID: 62404
		private static IntPtr __InitializeParticleArr_NativeFunctionPtr;

		// Token: 0x0400F3C5 RID: 62405
		private static IntPtr __SetDMIOffsetEnable_NativeFunctionPtr;

		// Token: 0x0400F3C6 RID: 62406
		private static IntPtr __UpdateaDMI_NativeFunctionPtr;

		// Token: 0x0400F3C7 RID: 62407
		private static IntPtr __InitializeDMI_NativeFunctionPtr;

		// Token: 0x0400F3C8 RID: 62408
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x0400F3C9 RID: 62409
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F3CA RID: 62410
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F3CB RID: 62411
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F3CC RID: 62412
		private static IntPtr __place_plank_event_NativeFunctionPtr;

		// Token: 0x0400F3CD RID: 62413
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F3CE RID: 62414
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F3CF RID: 62415
		private static IntPtr __ExecuteUbergraph_BP_QiuQian_Heavy_NativeFunctionPtr;

		// Token: 0x0200980B RID: 38923
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __SetDMIOffsetEnable_FunctionParams
		{
			// Token: 0x04031E0F RID: 204303
			[FieldOffset(0)]
			public bool OffsetEnable;
		}

		// Token: 0x0200980C RID: 38924
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x04031E10 RID: 204304
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x04031E11 RID: 204305
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04031E12 RID: 204306
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x04031E13 RID: 204307
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x04031E14 RID: 204308
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x04031E15 RID: 204309
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x0200980D RID: 38925
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E16 RID: 204310
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200980E RID: 38926
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1952)]
		protected ref struct __ExecuteUbergraph_BP_QiuQian_Heavy_FunctionParams
		{
			// Token: 0x04031E17 RID: 204311
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
