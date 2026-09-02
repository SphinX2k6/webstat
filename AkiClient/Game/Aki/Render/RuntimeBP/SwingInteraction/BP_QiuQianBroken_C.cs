using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A40 RID: 14912
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQianBroken.BP_QiuQianBroken_C")]
	[UnrealStructLayout(1616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1612)]
	public class BP_QiuQianBroken_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EC8F RID: 126095 RVA: 0x008FE7C7 File Offset: 0x008FC9C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QiuQianBroken_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQianBroken.BP_QiuQianBroken_C");
			}
			return BP_QiuQianBroken_C._ClassPtr;
		}

		// Token: 0x0601EC90 RID: 126096 RVA: 0x008FE7EC File Offset: 0x008FC9EC
		public BP_QiuQianBroken_C() : this(BuiltinUtils.AllocNativeUObject(BP_QiuQianBroken_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EC91 RID: 126097 RVA: 0x008FE814 File Offset: 0x008FCA14
		[NullableContext(1)]
		public BP_QiuQianBroken_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QiuQianBroken_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C65 RID: 11365
		// (get) Token: 0x0601EC92 RID: 126098 RVA: 0x008FE848 File Offset: 0x008FCA48
		// (set) Token: 0x0601EC93 RID: 126099 RVA: 0x008FE881 File Offset: 0x008FCA81
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C66 RID: 11366
		// (get) Token: 0x0601EC94 RID: 126100 RVA: 0x008FE8A2 File Offset: 0x008FCAA2
		// (set) Token: 0x0601EC95 RID: 126101 RVA: 0x008FE8B6 File Offset: 0x008FCAB6
		public unsafe UStaticMeshComponent SM_SwingSingleRopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C67 RID: 11367
		// (get) Token: 0x0601EC96 RID: 126102 RVA: 0x008FE8CB File Offset: 0x008FCACB
		// (set) Token: 0x0601EC97 RID: 126103 RVA: 0x008FE8DF File Offset: 0x008FCADF
		public unsafe UStaticMeshComponent SM_SwingSingleRopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C68 RID: 11368
		// (get) Token: 0x0601EC98 RID: 126104 RVA: 0x008FE8F4 File Offset: 0x008FCAF4
		// (set) Token: 0x0601EC99 RID: 126105 RVA: 0x008FE908 File Offset: 0x008FCB08
		public unsafe UStaticMeshComponent SM_SwingTop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002C69 RID: 11369
		// (get) Token: 0x0601EC9A RID: 126106 RVA: 0x008FE91D File Offset: 0x008FCB1D
		// (set) Token: 0x0601EC9B RID: 126107 RVA: 0x008FE931 File Offset: 0x008FCB31
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002C6A RID: 11370
		// (get) Token: 0x0601EC9C RID: 126108 RVA: 0x008FE946 File Offset: 0x008FCB46
		// (set) Token: 0x0601EC9D RID: 126109 RVA: 0x008FE95A File Offset: 0x008FCB5A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002C6B RID: 11371
		// (get) Token: 0x0601EC9E RID: 126110 RVA: 0x008FE96F File Offset: 0x008FCB6F
		// (set) Token: 0x0601EC9F RID: 126111 RVA: 0x008FE97F File Offset: 0x008FCB7F
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C6C RID: 11372
		// (get) Token: 0x0601ECA0 RID: 126112 RVA: 0x008FE990 File Offset: 0x008FCB90
		// (set) Token: 0x0601ECA1 RID: 126113 RVA: 0x008FE9A0 File Offset: 0x008FCBA0
		public unsafe bool bUseConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C6D RID: 11373
		// (get) Token: 0x0601ECA2 RID: 126114 RVA: 0x008FE9B1 File Offset: 0x008FCBB1
		// (set) Token: 0x0601ECA3 RID: 126115 RVA: 0x008FE9C1 File Offset: 0x008FCBC1
		public unsafe float ConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002C6E RID: 11374
		// (get) Token: 0x0601ECA4 RID: 126116 RVA: 0x008FE9D2 File Offset: 0x008FCBD2
		// (set) Token: 0x0601ECA5 RID: 126117 RVA: 0x008FE9E2 File Offset: 0x008FCBE2
		public unsafe float GroundHeightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002C6F RID: 11375
		// (get) Token: 0x0601ECA6 RID: 126118 RVA: 0x008FE9F3 File Offset: 0x008FCBF3
		// (set) Token: 0x0601ECA7 RID: 126119 RVA: 0x008FEA07 File Offset: 0x008FCC07
		public unsafe FVector LeftPosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002C70 RID: 11376
		// (get) Token: 0x0601ECA8 RID: 126120 RVA: 0x008FEA1C File Offset: 0x008FCC1C
		// (set) Token: 0x0601ECA9 RID: 126121 RVA: 0x008FEA30 File Offset: 0x008FCC30
		public unsafe FVector StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002C71 RID: 11377
		// (get) Token: 0x0601ECAA RID: 126122 RVA: 0x008FEA45 File Offset: 0x008FCC45
		// (set) Token: 0x0601ECAB RID: 126123 RVA: 0x008FEA59 File Offset: 0x008FCC59
		public unsafe FVector RuntimeOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002C72 RID: 11378
		// (get) Token: 0x0601ECAC RID: 126124 RVA: 0x008FEA6E File Offset: 0x008FCC6E
		// (set) Token: 0x0601ECAD RID: 126125 RVA: 0x008FEA7E File Offset: 0x008FCC7E
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002C73 RID: 11379
		// (get) Token: 0x0601ECAE RID: 126126 RVA: 0x008FEA8F File Offset: 0x008FCC8F
		// (set) Token: 0x0601ECAF RID: 126127 RVA: 0x008FEA9F File Offset: 0x008FCC9F
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002C74 RID: 11380
		// (get) Token: 0x0601ECB0 RID: 126128 RVA: 0x008FEAB0 File Offset: 0x008FCCB0
		// (set) Token: 0x0601ECB1 RID: 126129 RVA: 0x008FEAC4 File Offset: 0x008FCCC4
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002C75 RID: 11381
		// (get) Token: 0x0601ECB2 RID: 126130 RVA: 0x008FEAD9 File Offset: 0x008FCCD9
		// (set) Token: 0x0601ECB3 RID: 126131 RVA: 0x008FEAE9 File Offset: 0x008FCCE9
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002C76 RID: 11382
		// (get) Token: 0x0601ECB4 RID: 126132 RVA: 0x008FEAFA File Offset: 0x008FCCFA
		// (set) Token: 0x0601ECB5 RID: 126133 RVA: 0x008FEB0A File Offset: 0x008FCD0A
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002C77 RID: 11383
		// (get) Token: 0x0601ECB6 RID: 126134 RVA: 0x008FEB1B File Offset: 0x008FCD1B
		// (set) Token: 0x0601ECB7 RID: 126135 RVA: 0x008FEB2F File Offset: 0x008FCD2F
		public unsafe FVector startPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002C78 RID: 11384
		// (get) Token: 0x0601ECB8 RID: 126136 RVA: 0x008FEB44 File Offset: 0x008FCD44
		// (set) Token: 0x0601ECB9 RID: 126137 RVA: 0x008FEB58 File Offset: 0x008FCD58
		public unsafe FVector endPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002C79 RID: 11385
		// (get) Token: 0x0601ECBA RID: 126138 RVA: 0x008FEB70 File Offset: 0x008FCD70
		// (set) Token: 0x0601ECBB RID: 126139 RVA: 0x008FEBA9 File Offset: 0x008FCDA9
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
					result = (this._NameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NameList.CopyAssign(value);
			}
		}

		// Token: 0x17002C7A RID: 11386
		// (get) Token: 0x0601ECBC RID: 126140 RVA: 0x008FEBB7 File Offset: 0x008FCDB7
		// (set) Token: 0x0601ECBD RID: 126141 RVA: 0x008FEBCB File Offset: 0x008FCDCB
		public unsafe FVector leftPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002C7B RID: 11387
		// (get) Token: 0x0601ECBE RID: 126142 RVA: 0x008FEBE0 File Offset: 0x008FCDE0
		// (set) Token: 0x0601ECBF RID: 126143 RVA: 0x008FEBF4 File Offset: 0x008FCDF4
		public unsafe FVector rightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002C7C RID: 11388
		// (get) Token: 0x0601ECC0 RID: 126144 RVA: 0x008FEC09 File Offset: 0x008FCE09
		// (set) Token: 0x0601ECC1 RID: 126145 RVA: 0x008FEC1D File Offset: 0x008FCE1D
		public unsafe FVector leftNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002C7D RID: 11389
		// (get) Token: 0x0601ECC2 RID: 126146 RVA: 0x008FEC34 File Offset: 0x008FCE34
		// (set) Token: 0x0601ECC3 RID: 126147 RVA: 0x008FEC6D File Offset: 0x008FCE6D
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
					result = (this._particleArr = new TArray<FParticle_QiuQian>(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_24, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.particleArr.CopyAssign(value);
			}
		}

		// Token: 0x17002C7E RID: 11390
		// (get) Token: 0x0601ECC4 RID: 126148 RVA: 0x008FEC7B File Offset: 0x008FCE7B
		// (set) Token: 0x0601ECC5 RID: 126149 RVA: 0x008FEC8F File Offset: 0x008FCE8F
		public unsafe FVector rightNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002C7F RID: 11391
		// (get) Token: 0x0601ECC6 RID: 126150 RVA: 0x008FECA4 File Offset: 0x008FCEA4
		// (set) Token: 0x0601ECC7 RID: 126151 RVA: 0x008FECB4 File Offset: 0x008FCEB4
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002C80 RID: 11392
		// (get) Token: 0x0601ECC8 RID: 126152 RVA: 0x008FECC5 File Offset: 0x008FCEC5
		// (set) Token: 0x0601ECC9 RID: 126153 RVA: 0x008FECD5 File Offset: 0x008FCED5
		public unsafe float endParticleMassScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002C81 RID: 11393
		// (get) Token: 0x0601ECCA RID: 126154 RVA: 0x008FECE6 File Offset: 0x008FCEE6
		// (set) Token: 0x0601ECCB RID: 126155 RVA: 0x008FECF6 File Offset: 0x008FCEF6
		public unsafe float debugDrawDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002C82 RID: 11394
		// (get) Token: 0x0601ECCC RID: 126156 RVA: 0x008FED08 File Offset: 0x008FCF08
		// (set) Token: 0x0601ECCD RID: 126157 RVA: 0x008FED41 File Offset: 0x008FCF41
		[Nullable(1)]
		public TArray<USplineMeshComponent> SplineMesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USplineMeshComponent> result;
				if ((result = this._SplineMesh) == null)
				{
					result = (this._SplineMesh = new TArray<USplineMeshComponent>(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SplineMesh.CopyAssign(value);
			}
		}

		// Token: 0x17002C83 RID: 11395
		// (get) Token: 0x0601ECCE RID: 126158 RVA: 0x008FED50 File Offset: 0x008FCF50
		// (set) Token: 0x0601ECCF RID: 126159 RVA: 0x008FED89 File Offset: 0x008FCF89
		[Nullable(1)]
		public TArray<USplineMeshComponent> SplineMeshR
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USplineMeshComponent> result;
				if ((result = this._SplineMeshR) == null)
				{
					result = (this._SplineMeshR = new TArray<USplineMeshComponent>(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_30, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SplineMeshR.CopyAssign(value);
			}
		}

		// Token: 0x17002C84 RID: 11396
		// (get) Token: 0x0601ECD0 RID: 126160 RVA: 0x008FED97 File Offset: 0x008FCF97
		// (set) Token: 0x0601ECD1 RID: 126161 RVA: 0x008FEDA7 File Offset: 0x008FCFA7
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C85 RID: 11397
		// (get) Token: 0x0601ECD2 RID: 126162 RVA: 0x008FEDB8 File Offset: 0x008FCFB8
		// (set) Token: 0x0601ECD3 RID: 126163 RVA: 0x008FEDC8 File Offset: 0x008FCFC8
		public unsafe bool IsPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C86 RID: 11398
		// (get) Token: 0x0601ECD4 RID: 126164 RVA: 0x008FEDD9 File Offset: 0x008FCFD9
		// (set) Token: 0x0601ECD5 RID: 126165 RVA: 0x008FEDED File Offset: 0x008FCFED
		public unsafe UMaterialInstanceDynamic DMI_RopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17002C87 RID: 11399
		// (get) Token: 0x0601ECD6 RID: 126166 RVA: 0x008FEE02 File Offset: 0x008FD002
		// (set) Token: 0x0601ECD7 RID: 126167 RVA: 0x008FEE16 File Offset: 0x008FD016
		public unsafe UMaterialInstanceDynamic DMI_RopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQianBroken_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17002C88 RID: 11400
		// (get) Token: 0x0601ECD8 RID: 126168 RVA: 0x008FEE2B File Offset: 0x008FD02B
		// (set) Token: 0x0601ECD9 RID: 126169 RVA: 0x008FEE3B File Offset: 0x008FD03B
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQianBroken_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x0601ECDA RID: 126170 RVA: 0x008FEE4C File Offset: 0x008FD04C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParticleArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__InitializeParticleArr_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECDB RID: 126171 RVA: 0x008FEE60 File Offset: 0x008FD060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIOffsetEnable(bool OffsetEnable)
		{
			BP_QiuQianBroken_C.__SetDMIOffsetEnable_FunctionParams* ptr = stackalloc BP_QiuQianBroken_C.__SetDMIOffsetEnable_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_QiuQianBroken_C.__SetDMIOffsetEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQianBroken_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OffsetEnable = OffsetEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ECDC RID: 126172 RVA: 0x008FEEA6 File Offset: 0x008FD0A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateaDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__UpdateaDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECDD RID: 126173 RVA: 0x008FEEBA File Offset: 0x008FD0BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__InitializeDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECDE RID: 126174 RVA: 0x008FEED0 File Offset: 0x008FD0D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_QiuQianBroken_C.__solve_FunctionParams* ptr = stackalloc BP_QiuQianBroken_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_QiuQianBroken_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQianBroken_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x0601ECDF RID: 126175 RVA: 0x008FEF51 File Offset: 0x008FD151
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECE0 RID: 126176 RVA: 0x008FEF65 File Offset: 0x008FD165
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ECE1 RID: 126177 RVA: 0x008FEF7A File Offset: 0x008FD17A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void place_plank_event()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__place_plank_event_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECE2 RID: 126178 RVA: 0x008FEF90 File Offset: 0x008FD190
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_QiuQianBroken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQianBroken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQianBroken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQianBroken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ECE3 RID: 126179 RVA: 0x008FEFD8 File Offset: 0x008FD1D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_QiuQianBroken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQianBroken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQianBroken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQianBroken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ECE4 RID: 126180 RVA: 0x008FF01F File Offset: 0x008FD21F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECE5 RID: 126181 RVA: 0x008FF033 File Offset: 0x008FD233
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ECE6 RID: 126182 RVA: 0x008FF048 File Offset: 0x008FD248
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECE7 RID: 126183 RVA: 0x008FF05C File Offset: 0x008FD25C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ECE8 RID: 126184 RVA: 0x008FF071 File Offset: 0x008FD271
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQianBroken_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ECE9 RID: 126185 RVA: 0x008FF085 File Offset: 0x008FD285
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ECEA RID: 126186 RVA: 0x008FF09C File Offset: 0x008FD29C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QiuQianBroken(int EntryPoint)
		{
			BP_QiuQianBroken_C.__ExecuteUbergraph_BP_QiuQianBroken_FunctionParams* ptr = stackalloc BP_QiuQianBroken_C.__ExecuteUbergraph_BP_QiuQianBroken_FunctionParams[(UIntPtr)2479] + 15L / (long)sizeof(BP_QiuQianBroken_C.__ExecuteUbergraph_BP_QiuQianBroken_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQianBroken_C.__ExecuteUbergraph_BP_QiuQianBroken_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQianBroken_C.__ExecuteUbergraph_BP_QiuQianBroken_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ECEB RID: 126187 RVA: 0x008FF0E6 File Offset: 0x008FD2E6
		protected BP_QiuQianBroken_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F332 RID: 62258
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQianBroken.BP_QiuQianBroken_C";

		// Token: 0x0400F333 RID: 62259
		private static IntPtr _ClassPtr;

		// Token: 0x0400F334 RID: 62260
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F335 RID: 62261
		internal static int __PropertyOffset_0;

		// Token: 0x0400F336 RID: 62262
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F337 RID: 62263
		internal static int __PropertyOffset_1;

		// Token: 0x0400F338 RID: 62264
		internal static int __PropertyOffset_2;

		// Token: 0x0400F339 RID: 62265
		internal static int __PropertyOffset_3;

		// Token: 0x0400F33A RID: 62266
		internal static int __PropertyOffset_4;

		// Token: 0x0400F33B RID: 62267
		internal static int __PropertyOffset_5;

		// Token: 0x0400F33C RID: 62268
		internal static int __PropertyOffset_6;

		// Token: 0x0400F33D RID: 62269
		internal static int __PropertyOffset_7;

		// Token: 0x0400F33E RID: 62270
		internal static int __PropertyOffset_8;

		// Token: 0x0400F33F RID: 62271
		internal static int __PropertyOffset_9;

		// Token: 0x0400F340 RID: 62272
		internal static int __PropertyOffset_10;

		// Token: 0x0400F341 RID: 62273
		internal static int __PropertyOffset_11;

		// Token: 0x0400F342 RID: 62274
		internal static int __PropertyOffset_12;

		// Token: 0x0400F343 RID: 62275
		internal static int __PropertyOffset_13;

		// Token: 0x0400F344 RID: 62276
		internal static int __PropertyOffset_14;

		// Token: 0x0400F345 RID: 62277
		internal static int __PropertyOffset_15;

		// Token: 0x0400F346 RID: 62278
		internal static int __PropertyOffset_16;

		// Token: 0x0400F347 RID: 62279
		internal static int __PropertyOffset_17;

		// Token: 0x0400F348 RID: 62280
		internal static int __PropertyOffset_18;

		// Token: 0x0400F349 RID: 62281
		internal static int __PropertyOffset_19;

		// Token: 0x0400F34A RID: 62282
		internal static int __PropertyOffset_20;

		// Token: 0x0400F34B RID: 62283
		private TArray<FName> _NameList;

		// Token: 0x0400F34C RID: 62284
		internal static int __PropertyOffset_21;

		// Token: 0x0400F34D RID: 62285
		internal static int __PropertyOffset_22;

		// Token: 0x0400F34E RID: 62286
		internal static int __PropertyOffset_23;

		// Token: 0x0400F34F RID: 62287
		internal static int __PropertyOffset_24;

		// Token: 0x0400F350 RID: 62288
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FParticle_QiuQian> _particleArr;

		// Token: 0x0400F351 RID: 62289
		internal static int __PropertyOffset_25;

		// Token: 0x0400F352 RID: 62290
		internal static int __PropertyOffset_26;

		// Token: 0x0400F353 RID: 62291
		internal static int __PropertyOffset_27;

		// Token: 0x0400F354 RID: 62292
		internal static int __PropertyOffset_28;

		// Token: 0x0400F355 RID: 62293
		internal static int __PropertyOffset_29;

		// Token: 0x0400F356 RID: 62294
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USplineMeshComponent> _SplineMesh;

		// Token: 0x0400F357 RID: 62295
		internal static int __PropertyOffset_30;

		// Token: 0x0400F358 RID: 62296
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USplineMeshComponent> _SplineMeshR;

		// Token: 0x0400F359 RID: 62297
		internal static int __PropertyOffset_31;

		// Token: 0x0400F35A RID: 62298
		internal static int __PropertyOffset_32;

		// Token: 0x0400F35B RID: 62299
		internal static int __PropertyOffset_33;

		// Token: 0x0400F35C RID: 62300
		internal static int __PropertyOffset_34;

		// Token: 0x0400F35D RID: 62301
		internal static int __PropertyOffset_35;

		// Token: 0x0400F35E RID: 62302
		private static IntPtr __InitializeParticleArr_NativeFunctionPtr;

		// Token: 0x0400F35F RID: 62303
		private static IntPtr __SetDMIOffsetEnable_NativeFunctionPtr;

		// Token: 0x0400F360 RID: 62304
		private static IntPtr __UpdateaDMI_NativeFunctionPtr;

		// Token: 0x0400F361 RID: 62305
		private static IntPtr __InitializeDMI_NativeFunctionPtr;

		// Token: 0x0400F362 RID: 62306
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x0400F363 RID: 62307
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F364 RID: 62308
		private static IntPtr __place_plank_event_NativeFunctionPtr;

		// Token: 0x0400F365 RID: 62309
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F366 RID: 62310
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F367 RID: 62311
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F368 RID: 62312
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F369 RID: 62313
		private static IntPtr __ExecuteUbergraph_BP_QiuQianBroken_NativeFunctionPtr;

		// Token: 0x02009803 RID: 38915
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __SetDMIOffsetEnable_FunctionParams
		{
			// Token: 0x04031DFD RID: 204285
			[FieldOffset(0)]
			public bool OffsetEnable;
		}

		// Token: 0x02009804 RID: 38916
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x04031DFE RID: 204286
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x04031DFF RID: 204287
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04031E00 RID: 204288
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x04031E01 RID: 204289
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x04031E02 RID: 204290
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x04031E03 RID: 204291
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009805 RID: 38917
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E04 RID: 204292
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009806 RID: 38918
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2464)]
		protected ref struct __ExecuteUbergraph_BP_QiuQianBroken_FunctionParams
		{
			// Token: 0x04031E05 RID: 204293
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
