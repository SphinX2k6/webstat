using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BB2 RID: 15282
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel_Broken.BP_CPP_bridge_doubleChain_realModel_Broken_C")]
	[UnrealStructLayout(1776, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1770)]
	public class BP_CPP_bridge_doubleChain_realModel_Broken_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060222B7 RID: 139959 RVA: 0x0095D763 File Offset: 0x0095B963
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CPP_bridge_doubleChain_realModel_Broken_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel_Broken.BP_CPP_bridge_doubleChain_realModel_Broken_C");
			}
			return BP_CPP_bridge_doubleChain_realModel_Broken_C._ClassPtr;
		}

		// Token: 0x060222B8 RID: 139960 RVA: 0x0095D788 File Offset: 0x0095B988
		public BP_CPP_bridge_doubleChain_realModel_Broken_C() : this(BuiltinUtils.AllocNativeUObject(BP_CPP_bridge_doubleChain_realModel_Broken_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060222B9 RID: 139961 RVA: 0x0095D7B0 File Offset: 0x0095B9B0
		public BP_CPP_bridge_doubleChain_realModel_Broken_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CPP_bridge_doubleChain_realModel_Broken_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003F63 RID: 16227
		// (get) Token: 0x060222BA RID: 139962 RVA: 0x0095D7E4 File Offset: 0x0095B9E4
		// (set) Token: 0x060222BB RID: 139963 RVA: 0x0095D81D File Offset: 0x0095BA1D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003F64 RID: 16228
		// (get) Token: 0x060222BC RID: 139964 RVA: 0x0095D83E File Offset: 0x0095BA3E
		// (set) Token: 0x060222BD RID: 139965 RVA: 0x0095D852 File Offset: 0x0095BA52
		[Nullable(2)]
		public unsafe USphereComponent Sphere1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003F65 RID: 16229
		// (get) Token: 0x060222BE RID: 139966 RVA: 0x0095D867 File Offset: 0x0095BA67
		// (set) Token: 0x060222BF RID: 139967 RVA: 0x0095D87B File Offset: 0x0095BA7B
		[Nullable(2)]
		public unsafe USphereComponent Sphere
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003F66 RID: 16230
		// (get) Token: 0x060222C0 RID: 139968 RVA: 0x0095D890 File Offset: 0x0095BA90
		// (set) Token: 0x060222C1 RID: 139969 RVA: 0x0095D8A4 File Offset: 0x0095BAA4
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003F67 RID: 16231
		// (get) Token: 0x060222C2 RID: 139970 RVA: 0x0095D8B9 File Offset: 0x0095BAB9
		// (set) Token: 0x060222C3 RID: 139971 RVA: 0x0095D8CD File Offset: 0x0095BACD
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003F68 RID: 16232
		// (get) Token: 0x060222C4 RID: 139972 RVA: 0x0095D8E4 File Offset: 0x0095BAE4
		// (set) Token: 0x060222C5 RID: 139973 RVA: 0x0095D91D File Offset: 0x0095BB1D
		public TArray<FVector> posArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr) == null)
				{
					result = (this._posArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.posArr.CopyAssign(value);
			}
		}

		// Token: 0x17003F69 RID: 16233
		// (get) Token: 0x060222C6 RID: 139974 RVA: 0x0095D92C File Offset: 0x0095BB2C
		// (set) Token: 0x060222C7 RID: 139975 RVA: 0x0095D965 File Offset: 0x0095BB65
		public TArray<FVector> volArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._volArr) == null)
				{
					result = (this._volArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.volArr.CopyAssign(value);
			}
		}

		// Token: 0x17003F6A RID: 16234
		// (get) Token: 0x060222C8 RID: 139976 RVA: 0x0095D974 File Offset: 0x0095BB74
		// (set) Token: 0x060222C9 RID: 139977 RVA: 0x0095D9AD File Offset: 0x0095BBAD
		public TArray<FVector> posArr_foe
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_foe) == null)
				{
					result = (this._posArr_foe = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.posArr_foe.CopyAssign(value);
			}
		}

		// Token: 0x17003F6B RID: 16235
		// (get) Token: 0x060222CA RID: 139978 RVA: 0x0095D9BB File Offset: 0x0095BBBB
		// (set) Token: 0x060222CB RID: 139979 RVA: 0x0095D9CB File Offset: 0x0095BBCB
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003F6C RID: 16236
		// (get) Token: 0x060222CC RID: 139980 RVA: 0x0095D9DC File Offset: 0x0095BBDC
		// (set) Token: 0x060222CD RID: 139981 RVA: 0x0095D9EC File Offset: 0x0095BBEC
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003F6D RID: 16237
		// (get) Token: 0x060222CE RID: 139982 RVA: 0x0095D9FD File Offset: 0x0095BBFD
		// (set) Token: 0x060222CF RID: 139983 RVA: 0x0095DA11 File Offset: 0x0095BC11
		public unsafe FVector emitterOriginPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003F6E RID: 16238
		// (get) Token: 0x060222D0 RID: 139984 RVA: 0x0095DA26 File Offset: 0x0095BC26
		// (set) Token: 0x060222D1 RID: 139985 RVA: 0x0095DA3A File Offset: 0x0095BC3A
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003F6F RID: 16239
		// (get) Token: 0x060222D2 RID: 139986 RVA: 0x0095DA4F File Offset: 0x0095BC4F
		// (set) Token: 0x060222D3 RID: 139987 RVA: 0x0095DA5F File Offset: 0x0095BC5F
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003F70 RID: 16240
		// (get) Token: 0x060222D4 RID: 139988 RVA: 0x0095DA70 File Offset: 0x0095BC70
		// (set) Token: 0x060222D5 RID: 139989 RVA: 0x0095DA80 File Offset: 0x0095BC80
		public unsafe long frameID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003F71 RID: 16241
		// (get) Token: 0x060222D6 RID: 139990 RVA: 0x0095DA91 File Offset: 0x0095BC91
		// (set) Token: 0x060222D7 RID: 139991 RVA: 0x0095DAA1 File Offset: 0x0095BCA1
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003F72 RID: 16242
		// (get) Token: 0x060222D8 RID: 139992 RVA: 0x0095DAB2 File Offset: 0x0095BCB2
		// (set) Token: 0x060222D9 RID: 139993 RVA: 0x0095DAC6 File Offset: 0x0095BCC6
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic DMI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003F73 RID: 16243
		// (get) Token: 0x060222DA RID: 139994 RVA: 0x0095DADB File Offset: 0x0095BCDB
		// (set) Token: 0x060222DB RID: 139995 RVA: 0x0095DAEF File Offset: 0x0095BCEF
		public unsafe FVector startPinPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003F74 RID: 16244
		// (get) Token: 0x060222DC RID: 139996 RVA: 0x0095DB04 File Offset: 0x0095BD04
		// (set) Token: 0x060222DD RID: 139997 RVA: 0x0095DB18 File Offset: 0x0095BD18
		public unsafe FVector endPinPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003F75 RID: 16245
		// (get) Token: 0x060222DE RID: 139998 RVA: 0x0095DB30 File Offset: 0x0095BD30
		// (set) Token: 0x060222DF RID: 139999 RVA: 0x0095DB69 File Offset: 0x0095BD69
		public TArray<UStaticMeshComponent> plankList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._plankList) == null)
				{
					result = (this._plankList = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.plankList.CopyAssign(value);
			}
		}

		// Token: 0x17003F76 RID: 16246
		// (get) Token: 0x060222E0 RID: 140000 RVA: 0x0095DB77 File Offset: 0x0095BD77
		// (set) Token: 0x060222E1 RID: 140001 RVA: 0x0095DB87 File Offset: 0x0095BD87
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003F77 RID: 16247
		// (get) Token: 0x060222E2 RID: 140002 RVA: 0x0095DB98 File Offset: 0x0095BD98
		// (set) Token: 0x060222E3 RID: 140003 RVA: 0x0095DBD1 File Offset: 0x0095BDD1
		public TArray<FVector> posArr_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_r) == null)
				{
					result = (this._posArr_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.posArr_r.CopyAssign(value);
			}
		}

		// Token: 0x17003F78 RID: 16248
		// (get) Token: 0x060222E4 RID: 140004 RVA: 0x0095DBE0 File Offset: 0x0095BDE0
		// (set) Token: 0x060222E5 RID: 140005 RVA: 0x0095DC19 File Offset: 0x0095BE19
		public TArray<FVector> volArr_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._volArr_r) == null)
				{
					result = (this._volArr_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.volArr_r.CopyAssign(value);
			}
		}

		// Token: 0x17003F79 RID: 16249
		// (get) Token: 0x060222E6 RID: 140006 RVA: 0x0095DC28 File Offset: 0x0095BE28
		// (set) Token: 0x060222E7 RID: 140007 RVA: 0x0095DC61 File Offset: 0x0095BE61
		public TArray<FVector> posArr_foe_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_foe_r) == null)
				{
					result = (this._posArr_foe_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				this.posArr_foe_r.CopyAssign(value);
			}
		}

		// Token: 0x17003F7A RID: 16250
		// (get) Token: 0x060222E8 RID: 140008 RVA: 0x0095DC6F File Offset: 0x0095BE6F
		// (set) Token: 0x060222E9 RID: 140009 RVA: 0x0095DC83 File Offset: 0x0095BE83
		public unsafe FVector startPinPos_r
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003F7B RID: 16251
		// (get) Token: 0x060222EA RID: 140010 RVA: 0x0095DC98 File Offset: 0x0095BE98
		// (set) Token: 0x060222EB RID: 140011 RVA: 0x0095DCAC File Offset: 0x0095BEAC
		public unsafe FVector endPinPos_r
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003F7C RID: 16252
		// (get) Token: 0x060222EC RID: 140012 RVA: 0x0095DCC1 File Offset: 0x0095BEC1
		// (set) Token: 0x060222ED RID: 140013 RVA: 0x0095DCD1 File Offset: 0x0095BED1
		public unsafe float percentage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003F7D RID: 16253
		// (get) Token: 0x060222EE RID: 140014 RVA: 0x0095DCE2 File Offset: 0x0095BEE2
		// (set) Token: 0x060222EF RID: 140015 RVA: 0x0095DCF2 File Offset: 0x0095BEF2
		public unsafe bool onBridge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003F7E RID: 16254
		// (get) Token: 0x060222F0 RID: 140016 RVA: 0x0095DD04 File Offset: 0x0095BF04
		// (set) Token: 0x060222F1 RID: 140017 RVA: 0x0095DD3D File Offset: 0x0095BF3D
		public TArray<float> foeDisList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._foeDisList) == null)
				{
					result = (this._foeDisList = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				this.foeDisList.CopyAssign(value);
			}
		}

		// Token: 0x17003F7F RID: 16255
		// (get) Token: 0x060222F2 RID: 140018 RVA: 0x0095DD4C File Offset: 0x0095BF4C
		// (set) Token: 0x060222F3 RID: 140019 RVA: 0x0095DD85 File Offset: 0x0095BF85
		public TArray<float> foeDisList_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._foeDisList_r) == null)
				{
					result = (this._foeDisList_r = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				this.foeDisList_r.CopyAssign(value);
			}
		}

		// Token: 0x17003F80 RID: 16256
		// (get) Token: 0x060222F4 RID: 140020 RVA: 0x0095DD94 File Offset: 0x0095BF94
		// (set) Token: 0x060222F5 RID: 140021 RVA: 0x0095DDCD File Offset: 0x0095BFCD
		public TArray<float> nxtDisList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._nxtDisList) == null)
				{
					result = (this._nxtDisList = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				this.nxtDisList.CopyAssign(value);
			}
		}

		// Token: 0x17003F81 RID: 16257
		// (get) Token: 0x060222F6 RID: 140022 RVA: 0x0095DDDC File Offset: 0x0095BFDC
		// (set) Token: 0x060222F7 RID: 140023 RVA: 0x0095DE15 File Offset: 0x0095C015
		public TArray<float> nxtDisList_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._nxtDisList_r) == null)
				{
					result = (this._nxtDisList_r = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				this.nxtDisList_r.CopyAssign(value);
			}
		}

		// Token: 0x17003F82 RID: 16258
		// (get) Token: 0x060222F8 RID: 140024 RVA: 0x0095DE23 File Offset: 0x0095C023
		// (set) Token: 0x060222F9 RID: 140025 RVA: 0x0095DE33 File Offset: 0x0095C033
		public unsafe float offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003F83 RID: 16259
		// (get) Token: 0x060222FA RID: 140026 RVA: 0x0095DE44 File Offset: 0x0095C044
		// (set) Token: 0x060222FB RID: 140027 RVA: 0x0095DE54 File Offset: 0x0095C054
		public unsafe float linkDisScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003F84 RID: 16260
		// (get) Token: 0x060222FC RID: 140028 RVA: 0x0095DE65 File Offset: 0x0095C065
		// (set) Token: 0x060222FD RID: 140029 RVA: 0x0095DE79 File Offset: 0x0095C079
		[Nullable(2)]
		public unsafe AActor bridgeModels
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_33);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003F85 RID: 16261
		// (get) Token: 0x060222FE RID: 140030 RVA: 0x0095DE8E File Offset: 0x0095C08E
		// (set) Token: 0x060222FF RID: 140031 RVA: 0x0095DE9E File Offset: 0x0095C09E
		public unsafe float BreakPushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003F86 RID: 16262
		// (get) Token: 0x06022300 RID: 140032 RVA: 0x0095DEAF File Offset: 0x0095C0AF
		// (set) Token: 0x06022301 RID: 140033 RVA: 0x0095DEBF File Offset: 0x0095C0BF
		public unsafe bool Broken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003F87 RID: 16263
		// (get) Token: 0x06022302 RID: 140034 RVA: 0x0095DED0 File Offset: 0x0095C0D0
		// (set) Token: 0x06022303 RID: 140035 RVA: 0x0095DEE4 File Offset: 0x0095C0E4
		public unsafe FVector Broken_Sim_Accel_Ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003F88 RID: 16264
		// (get) Token: 0x06022304 RID: 140036 RVA: 0x0095DEF9 File Offset: 0x0095C0F9
		// (set) Token: 0x06022305 RID: 140037 RVA: 0x0095DF09 File Offset: 0x0095C109
		public unsafe float Broken_Sim_Vol_Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003F89 RID: 16265
		// (get) Token: 0x06022306 RID: 140038 RVA: 0x0095DF1A File Offset: 0x0095C11A
		// (set) Token: 0x06022307 RID: 140039 RVA: 0x0095DF2A File Offset: 0x0095C12A
		public unsafe int BreakBothIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003F8A RID: 16266
		// (get) Token: 0x06022308 RID: 140040 RVA: 0x0095DF3B File Offset: 0x0095C13B
		// (set) Token: 0x06022309 RID: 140041 RVA: 0x0095DF4B File Offset: 0x0095C14B
		public unsafe int LeftBreakExtraStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003F8B RID: 16267
		// (get) Token: 0x0602230A RID: 140042 RVA: 0x0095DF5C File Offset: 0x0095C15C
		// (set) Token: 0x0602230B RID: 140043 RVA: 0x0095DF6C File Offset: 0x0095C16C
		public unsafe int LeftBreakExtraEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003F8C RID: 16268
		// (get) Token: 0x0602230C RID: 140044 RVA: 0x0095DF7D File Offset: 0x0095C17D
		// (set) Token: 0x0602230D RID: 140045 RVA: 0x0095DF8D File Offset: 0x0095C18D
		public unsafe int RightBreakExtraStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003F8D RID: 16269
		// (get) Token: 0x0602230E RID: 140046 RVA: 0x0095DF9E File Offset: 0x0095C19E
		// (set) Token: 0x0602230F RID: 140047 RVA: 0x0095DFAE File Offset: 0x0095C1AE
		public unsafe int RightBreakExtraEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17003F8E RID: 16270
		// (get) Token: 0x06022310 RID: 140048 RVA: 0x0095DFBF File Offset: 0x0095C1BF
		// (set) Token: 0x06022311 RID: 140049 RVA: 0x0095DFCF File Offset: 0x0095C1CF
		public unsafe float Plank_Rest_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003F8F RID: 16271
		// (get) Token: 0x06022312 RID: 140050 RVA: 0x0095DFE0 File Offset: 0x0095C1E0
		// (set) Token: 0x06022313 RID: 140051 RVA: 0x0095E019 File Offset: 0x0095C219
		public TArray<byte> Particle_Chain_Link_Mask
		{
			get
			{
				base.FastCheckIsValid();
				TArray<byte> result;
				if ((result = this._Particle_Chain_Link_Mask) == null)
				{
					result = (this._Particle_Chain_Link_Mask = new TArray<byte>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				this.Particle_Chain_Link_Mask.CopyAssign(value);
			}
		}

		// Token: 0x17003F90 RID: 16272
		// (get) Token: 0x06022314 RID: 140052 RVA: 0x0095E028 File Offset: 0x0095C228
		// (set) Token: 0x06022315 RID: 140053 RVA: 0x0095E061 File Offset: 0x0095C261
		public TArray<byte> Particle_Chain_Link_Mask_R
		{
			get
			{
				base.FastCheckIsValid();
				TArray<byte> result;
				if ((result = this._Particle_Chain_Link_Mask_R) == null)
				{
					result = (this._Particle_Chain_Link_Mask_R = new TArray<byte>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				this.Particle_Chain_Link_Mask_R.CopyAssign(value);
			}
		}

		// Token: 0x17003F91 RID: 16273
		// (get) Token: 0x06022316 RID: 140054 RVA: 0x0095E06F File Offset: 0x0095C26F
		// (set) Token: 0x06022317 RID: 140055 RVA: 0x0095E07F File Offset: 0x0095C27F
		public unsafe float GroundZOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17003F92 RID: 16274
		// (get) Token: 0x06022318 RID: 140056 RVA: 0x0095E090 File Offset: 0x0095C290
		// (set) Token: 0x06022319 RID: 140057 RVA: 0x0095E0A0 File Offset: 0x0095C2A0
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003F93 RID: 16275
		// (get) Token: 0x0602231A RID: 140058 RVA: 0x0095E0B4 File Offset: 0x0095C2B4
		// (set) Token: 0x0602231B RID: 140059 RVA: 0x0095E0ED File Offset: 0x0095C2ED
		public TArray<FKuroBridgeChunkMeshList> BridgeFractureSet
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroBridgeChunkMeshList> result;
				if ((result = this._BridgeFractureSet) == null)
				{
					result = (this._BridgeFractureSet = new TArray<FKuroBridgeChunkMeshList>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				this.BridgeFractureSet.CopyAssign(value);
			}
		}

		// Token: 0x17003F94 RID: 16276
		// (get) Token: 0x0602231C RID: 140060 RVA: 0x0095E0FB File Offset: 0x0095C2FB
		// (set) Token: 0x0602231D RID: 140061 RVA: 0x0095E10B File Offset: 0x0095C30B
		public unsafe bool bIsBreakable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003F95 RID: 16277
		// (get) Token: 0x0602231E RID: 140062 RVA: 0x0095E11C File Offset: 0x0095C31C
		// (set) Token: 0x0602231F RID: 140063 RVA: 0x0095E12C File Offset: 0x0095C32C
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_Broken_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022320 RID: 140064 RVA: 0x0095E13D File Offset: 0x0095C33D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RecoverSideBlock()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__RecoverSideBlock_NativeFunctionPtr, null);
		}

		// Token: 0x06022321 RID: 140065 RVA: 0x0095E154 File Offset: 0x0095C354
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void getTangent(ref TArray<FVector> posArr, ref TArray<FVector> posArrR, int index, ref FVector tangent)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FVector> tarray = posArr;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->posArr);
			}
			TArray<FVector> tarray2 = posArrR;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->posArrR);
			}
			ptr->index = index;
			ptr->tangent = tangent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_NativeFunctionPtr, (void*)ptr);
			TArray<FVector> tarray3 = posArr;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->posArr);
			}
			TArray<FVector> tarray4 = posArrR;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->posArrR);
			}
			tangent = ptr->tangent;
			UnrealReflectionUtils.DestroyStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__getTangent_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06022322 RID: 140066 RVA: 0x0095E218 File Offset: 0x0095C418
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__solve_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x06022323 RID: 140067 RVA: 0x0095E299 File Offset: 0x0095C499
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022324 RID: 140068 RVA: 0x0095E2AD File Offset: 0x0095C4AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022325 RID: 140069 RVA: 0x0095E2C4 File Offset: 0x0095C4C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_9ED3A0014CAE76088E4760B193BF3A56(int PlayingID)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_9ED3A0014CAE76088E4760B193BF3A56_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_9ED3A0014CAE76088E4760B193BF3A56_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_9ED3A0014CAE76088E4760B193BF3A56_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_9ED3A0014CAE76088E4760B193BF3A56_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_9ED3A0014CAE76088E4760B193BF3A56_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022326 RID: 140070 RVA: 0x0095E30C File Offset: 0x0095C50C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_D335450D4E966E00060072B19DB6B342(int PlayingID)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_D335450D4E966E00060072B19DB6B342_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_D335450D4E966E00060072B19DB6B342_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_D335450D4E966E00060072B19DB6B342_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_D335450D4E966E00060072B19DB6B342_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__Completed_D335450D4E966E00060072B19DB6B342_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022327 RID: 140071 RVA: 0x0095E352 File Offset: 0x0095C552
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022328 RID: 140072 RVA: 0x0095E366 File Offset: 0x0095C566
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022329 RID: 140073 RVA: 0x0095E37C File Offset: 0x0095C57C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602232A RID: 140074 RVA: 0x0095E3C4 File Offset: 0x0095C5C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602232B RID: 140075 RVA: 0x0095E40C File Offset: 0x0095C60C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602232C RID: 140076 RVA: 0x0095E4C8 File Offset: 0x0095C6C8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602232D RID: 140077 RVA: 0x0095E554 File Offset: 0x0095C754
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602232E RID: 140078 RVA: 0x0095E5B8 File Offset: 0x0095C7B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken(int EntryPoint)
		{
			BP_CPP_bridge_doubleChain_realModel_Broken_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_Broken_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_FunctionParams[(UIntPtr)2903] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_Broken_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_Broken_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602232F RID: 140079 RVA: 0x0095E602 File Offset: 0x0095C802
		protected BP_CPP_bridge_doubleChain_realModel_Broken_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011440 RID: 70720
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel_Broken.BP_CPP_bridge_doubleChain_realModel_Broken_C";

		// Token: 0x04011441 RID: 70721
		private static IntPtr _ClassPtr;

		// Token: 0x04011442 RID: 70722
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011443 RID: 70723
		internal static int __PropertyOffset_0;

		// Token: 0x04011444 RID: 70724
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011445 RID: 70725
		internal static int __PropertyOffset_1;

		// Token: 0x04011446 RID: 70726
		internal static int __PropertyOffset_2;

		// Token: 0x04011447 RID: 70727
		internal static int __PropertyOffset_3;

		// Token: 0x04011448 RID: 70728
		internal static int __PropertyOffset_4;

		// Token: 0x04011449 RID: 70729
		internal static int __PropertyOffset_5;

		// Token: 0x0401144A RID: 70730
		[Nullable(2)]
		private TArray<FVector> _posArr;

		// Token: 0x0401144B RID: 70731
		internal static int __PropertyOffset_6;

		// Token: 0x0401144C RID: 70732
		[Nullable(2)]
		private TArray<FVector> _volArr;

		// Token: 0x0401144D RID: 70733
		internal static int __PropertyOffset_7;

		// Token: 0x0401144E RID: 70734
		[Nullable(2)]
		private TArray<FVector> _posArr_foe;

		// Token: 0x0401144F RID: 70735
		internal static int __PropertyOffset_8;

		// Token: 0x04011450 RID: 70736
		internal static int __PropertyOffset_9;

		// Token: 0x04011451 RID: 70737
		internal static int __PropertyOffset_10;

		// Token: 0x04011452 RID: 70738
		internal static int __PropertyOffset_11;

		// Token: 0x04011453 RID: 70739
		internal static int __PropertyOffset_12;

		// Token: 0x04011454 RID: 70740
		internal static int __PropertyOffset_13;

		// Token: 0x04011455 RID: 70741
		internal static int __PropertyOffset_14;

		// Token: 0x04011456 RID: 70742
		internal static int __PropertyOffset_15;

		// Token: 0x04011457 RID: 70743
		internal static int __PropertyOffset_16;

		// Token: 0x04011458 RID: 70744
		internal static int __PropertyOffset_17;

		// Token: 0x04011459 RID: 70745
		internal static int __PropertyOffset_18;

		// Token: 0x0401145A RID: 70746
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _plankList;

		// Token: 0x0401145B RID: 70747
		internal static int __PropertyOffset_19;

		// Token: 0x0401145C RID: 70748
		internal static int __PropertyOffset_20;

		// Token: 0x0401145D RID: 70749
		[Nullable(2)]
		private TArray<FVector> _posArr_r;

		// Token: 0x0401145E RID: 70750
		internal static int __PropertyOffset_21;

		// Token: 0x0401145F RID: 70751
		[Nullable(2)]
		private TArray<FVector> _volArr_r;

		// Token: 0x04011460 RID: 70752
		internal static int __PropertyOffset_22;

		// Token: 0x04011461 RID: 70753
		[Nullable(2)]
		private TArray<FVector> _posArr_foe_r;

		// Token: 0x04011462 RID: 70754
		internal static int __PropertyOffset_23;

		// Token: 0x04011463 RID: 70755
		internal static int __PropertyOffset_24;

		// Token: 0x04011464 RID: 70756
		internal static int __PropertyOffset_25;

		// Token: 0x04011465 RID: 70757
		internal static int __PropertyOffset_26;

		// Token: 0x04011466 RID: 70758
		internal static int __PropertyOffset_27;

		// Token: 0x04011467 RID: 70759
		[Nullable(2)]
		private TArray<float> _foeDisList;

		// Token: 0x04011468 RID: 70760
		internal static int __PropertyOffset_28;

		// Token: 0x04011469 RID: 70761
		[Nullable(2)]
		private TArray<float> _foeDisList_r;

		// Token: 0x0401146A RID: 70762
		internal static int __PropertyOffset_29;

		// Token: 0x0401146B RID: 70763
		[Nullable(2)]
		private TArray<float> _nxtDisList;

		// Token: 0x0401146C RID: 70764
		internal static int __PropertyOffset_30;

		// Token: 0x0401146D RID: 70765
		[Nullable(2)]
		private TArray<float> _nxtDisList_r;

		// Token: 0x0401146E RID: 70766
		internal static int __PropertyOffset_31;

		// Token: 0x0401146F RID: 70767
		internal static int __PropertyOffset_32;

		// Token: 0x04011470 RID: 70768
		internal static int __PropertyOffset_33;

		// Token: 0x04011471 RID: 70769
		internal static int __PropertyOffset_34;

		// Token: 0x04011472 RID: 70770
		internal static int __PropertyOffset_35;

		// Token: 0x04011473 RID: 70771
		internal static int __PropertyOffset_36;

		// Token: 0x04011474 RID: 70772
		internal static int __PropertyOffset_37;

		// Token: 0x04011475 RID: 70773
		internal static int __PropertyOffset_38;

		// Token: 0x04011476 RID: 70774
		internal static int __PropertyOffset_39;

		// Token: 0x04011477 RID: 70775
		internal static int __PropertyOffset_40;

		// Token: 0x04011478 RID: 70776
		internal static int __PropertyOffset_41;

		// Token: 0x04011479 RID: 70777
		internal static int __PropertyOffset_42;

		// Token: 0x0401147A RID: 70778
		internal static int __PropertyOffset_43;

		// Token: 0x0401147B RID: 70779
		internal static int __PropertyOffset_44;

		// Token: 0x0401147C RID: 70780
		[Nullable(2)]
		private TArray<byte> _Particle_Chain_Link_Mask;

		// Token: 0x0401147D RID: 70781
		internal static int __PropertyOffset_45;

		// Token: 0x0401147E RID: 70782
		[Nullable(2)]
		private TArray<byte> _Particle_Chain_Link_Mask_R;

		// Token: 0x0401147F RID: 70783
		internal static int __PropertyOffset_46;

		// Token: 0x04011480 RID: 70784
		internal static int __PropertyOffset_47;

		// Token: 0x04011481 RID: 70785
		internal static int __PropertyOffset_48;

		// Token: 0x04011482 RID: 70786
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroBridgeChunkMeshList> _BridgeFractureSet;

		// Token: 0x04011483 RID: 70787
		internal static int __PropertyOffset_49;

		// Token: 0x04011484 RID: 70788
		internal static int __PropertyOffset_50;

		// Token: 0x04011485 RID: 70789
		private static IntPtr __RecoverSideBlock_NativeFunctionPtr;

		// Token: 0x04011486 RID: 70790
		private static IntPtr __getTangent_NativeFunctionPtr;

		// Token: 0x04011487 RID: 70791
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x04011488 RID: 70792
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011489 RID: 70793
		private static IntPtr __Completed_9ED3A0014CAE76088E4760B193BF3A56_NativeFunctionPtr;

		// Token: 0x0401148A RID: 70794
		private static IntPtr __Completed_D335450D4E966E00060072B19DB6B342_NativeFunctionPtr;

		// Token: 0x0401148B RID: 70795
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401148C RID: 70796
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401148D RID: 70797
		private static IntPtr __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401148E RID: 70798
		private static IntPtr __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401148F RID: 70799
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011490 RID: 70800
		private static IntPtr __ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_NativeFunctionPtr;

		// Token: 0x02009B94 RID: 39828
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __getTangent_FunctionParams
		{
			// Token: 0x040323A1 RID: 205729
			[FieldOffset(0)]
			public byte posArr;

			// Token: 0x040323A2 RID: 205730
			[FieldOffset(16)]
			public byte posArrR;

			// Token: 0x040323A3 RID: 205731
			[FieldOffset(32)]
			public int index;

			// Token: 0x040323A4 RID: 205732
			[FieldOffset(36)]
			public FVector tangent;
		}

		// Token: 0x02009B95 RID: 39829
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x040323A5 RID: 205733
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x040323A6 RID: 205734
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x040323A7 RID: 205735
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x040323A8 RID: 205736
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x040323A9 RID: 205737
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x040323AA RID: 205738
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009B96 RID: 39830
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_9ED3A0014CAE76088E4760B193BF3A56_FunctionParams
		{
			// Token: 0x040323AB RID: 205739
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009B97 RID: 39831
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_D335450D4E966E00060072B19DB6B342_FunctionParams
		{
			// Token: 0x040323AC RID: 205740
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009B98 RID: 39832
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323AD RID: 205741
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B99 RID: 39833
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040323AE RID: 205742
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040323AF RID: 205743
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040323B0 RID: 205744
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040323B1 RID: 205745
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040323B2 RID: 205746
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040323B3 RID: 205747
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B9A RID: 39834
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040323B4 RID: 205748
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040323B5 RID: 205749
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040323B6 RID: 205750
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040323B7 RID: 205751
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B9B RID: 39835
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040323B8 RID: 205752
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040323B9 RID: 205753
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040323BA RID: 205754
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009B9C RID: 39836
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2888)]
		protected ref struct __ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_Broken_FunctionParams
		{
			// Token: 0x040323BB RID: 205755
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
