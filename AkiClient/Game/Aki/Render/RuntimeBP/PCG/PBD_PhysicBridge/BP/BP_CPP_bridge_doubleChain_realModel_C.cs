using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BB3 RID: 15283
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel.BP_CPP_bridge_doubleChain_realModel_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_CPP_bridge_doubleChain_realModel_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022330 RID: 140080 RVA: 0x0095E60B File Offset: 0x0095C80B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CPP_bridge_doubleChain_realModel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel.BP_CPP_bridge_doubleChain_realModel_C");
			}
			return BP_CPP_bridge_doubleChain_realModel_C._ClassPtr;
		}

		// Token: 0x06022331 RID: 140081 RVA: 0x0095E630 File Offset: 0x0095C830
		public BP_CPP_bridge_doubleChain_realModel_C() : this(BuiltinUtils.AllocNativeUObject(BP_CPP_bridge_doubleChain_realModel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022332 RID: 140082 RVA: 0x0095E658 File Offset: 0x0095C858
		public BP_CPP_bridge_doubleChain_realModel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CPP_bridge_doubleChain_realModel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003F96 RID: 16278
		// (get) Token: 0x06022333 RID: 140083 RVA: 0x0095E68C File Offset: 0x0095C88C
		// (set) Token: 0x06022334 RID: 140084 RVA: 0x0095E6C5 File Offset: 0x0095C8C5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003F97 RID: 16279
		// (get) Token: 0x06022335 RID: 140085 RVA: 0x0095E6E6 File Offset: 0x0095C8E6
		// (set) Token: 0x06022336 RID: 140086 RVA: 0x0095E6FA File Offset: 0x0095C8FA
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003F98 RID: 16280
		// (get) Token: 0x06022337 RID: 140087 RVA: 0x0095E70F File Offset: 0x0095C90F
		// (set) Token: 0x06022338 RID: 140088 RVA: 0x0095E723 File Offset: 0x0095C923
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003F99 RID: 16281
		// (get) Token: 0x06022339 RID: 140089 RVA: 0x0095E738 File Offset: 0x0095C938
		// (set) Token: 0x0602233A RID: 140090 RVA: 0x0095E771 File Offset: 0x0095C971
		public TArray<FVector> posArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr) == null)
				{
					result = (this._posArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.posArr.CopyAssign(value);
			}
		}

		// Token: 0x17003F9A RID: 16282
		// (get) Token: 0x0602233B RID: 140091 RVA: 0x0095E780 File Offset: 0x0095C980
		// (set) Token: 0x0602233C RID: 140092 RVA: 0x0095E7B9 File Offset: 0x0095C9B9
		public TArray<FVector> volArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._volArr) == null)
				{
					result = (this._volArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.volArr.CopyAssign(value);
			}
		}

		// Token: 0x17003F9B RID: 16283
		// (get) Token: 0x0602233D RID: 140093 RVA: 0x0095E7C7 File Offset: 0x0095C9C7
		// (set) Token: 0x0602233E RID: 140094 RVA: 0x0095E7D7 File Offset: 0x0095C9D7
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003F9C RID: 16284
		// (get) Token: 0x0602233F RID: 140095 RVA: 0x0095E7E8 File Offset: 0x0095C9E8
		// (set) Token: 0x06022340 RID: 140096 RVA: 0x0095E7F8 File Offset: 0x0095C9F8
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003F9D RID: 16285
		// (get) Token: 0x06022341 RID: 140097 RVA: 0x0095E809 File Offset: 0x0095CA09
		// (set) Token: 0x06022342 RID: 140098 RVA: 0x0095E81D File Offset: 0x0095CA1D
		public unsafe FVector emitterOriginPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003F9E RID: 16286
		// (get) Token: 0x06022343 RID: 140099 RVA: 0x0095E832 File Offset: 0x0095CA32
		// (set) Token: 0x06022344 RID: 140100 RVA: 0x0095E846 File Offset: 0x0095CA46
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003F9F RID: 16287
		// (get) Token: 0x06022345 RID: 140101 RVA: 0x0095E85C File Offset: 0x0095CA5C
		// (set) Token: 0x06022346 RID: 140102 RVA: 0x0095E895 File Offset: 0x0095CA95
		public TArray<FVector> posArr_foe
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_foe) == null)
				{
					result = (this._posArr_foe = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.posArr_foe.CopyAssign(value);
			}
		}

		// Token: 0x17003FA0 RID: 16288
		// (get) Token: 0x06022347 RID: 140103 RVA: 0x0095E8A3 File Offset: 0x0095CAA3
		// (set) Token: 0x06022348 RID: 140104 RVA: 0x0095E8B3 File Offset: 0x0095CAB3
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003FA1 RID: 16289
		// (get) Token: 0x06022349 RID: 140105 RVA: 0x0095E8C4 File Offset: 0x0095CAC4
		// (set) Token: 0x0602234A RID: 140106 RVA: 0x0095E8D4 File Offset: 0x0095CAD4
		public unsafe long frameID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003FA2 RID: 16290
		// (get) Token: 0x0602234B RID: 140107 RVA: 0x0095E8E5 File Offset: 0x0095CAE5
		// (set) Token: 0x0602234C RID: 140108 RVA: 0x0095E8F5 File Offset: 0x0095CAF5
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003FA3 RID: 16291
		// (get) Token: 0x0602234D RID: 140109 RVA: 0x0095E906 File Offset: 0x0095CB06
		// (set) Token: 0x0602234E RID: 140110 RVA: 0x0095E91A File Offset: 0x0095CB1A
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic DMI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003FA4 RID: 16292
		// (get) Token: 0x0602234F RID: 140111 RVA: 0x0095E92F File Offset: 0x0095CB2F
		// (set) Token: 0x06022350 RID: 140112 RVA: 0x0095E943 File Offset: 0x0095CB43
		public unsafe FVector startPinPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003FA5 RID: 16293
		// (get) Token: 0x06022351 RID: 140113 RVA: 0x0095E958 File Offset: 0x0095CB58
		// (set) Token: 0x06022352 RID: 140114 RVA: 0x0095E96C File Offset: 0x0095CB6C
		public unsafe FVector endPinPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003FA6 RID: 16294
		// (get) Token: 0x06022353 RID: 140115 RVA: 0x0095E984 File Offset: 0x0095CB84
		// (set) Token: 0x06022354 RID: 140116 RVA: 0x0095E9BD File Offset: 0x0095CBBD
		public TArray<UStaticMeshComponent> plankList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._plankList) == null)
				{
					result = (this._plankList = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.plankList.CopyAssign(value);
			}
		}

		// Token: 0x17003FA7 RID: 16295
		// (get) Token: 0x06022355 RID: 140117 RVA: 0x0095E9CB File Offset: 0x0095CBCB
		// (set) Token: 0x06022356 RID: 140118 RVA: 0x0095E9DB File Offset: 0x0095CBDB
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003FA8 RID: 16296
		// (get) Token: 0x06022357 RID: 140119 RVA: 0x0095E9EC File Offset: 0x0095CBEC
		// (set) Token: 0x06022358 RID: 140120 RVA: 0x0095EA25 File Offset: 0x0095CC25
		public TArray<FVector> posArr_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_r) == null)
				{
					result = (this._posArr_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.posArr_r.CopyAssign(value);
			}
		}

		// Token: 0x17003FA9 RID: 16297
		// (get) Token: 0x06022359 RID: 140121 RVA: 0x0095EA34 File Offset: 0x0095CC34
		// (set) Token: 0x0602235A RID: 140122 RVA: 0x0095EA6D File Offset: 0x0095CC6D
		public TArray<FVector> volArr_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._volArr_r) == null)
				{
					result = (this._volArr_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.volArr_r.CopyAssign(value);
			}
		}

		// Token: 0x17003FAA RID: 16298
		// (get) Token: 0x0602235B RID: 140123 RVA: 0x0095EA7C File Offset: 0x0095CC7C
		// (set) Token: 0x0602235C RID: 140124 RVA: 0x0095EAB5 File Offset: 0x0095CCB5
		public TArray<FVector> posArr_foe_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_foe_r) == null)
				{
					result = (this._posArr_foe_r = new TArray<FVector>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.posArr_foe_r.CopyAssign(value);
			}
		}

		// Token: 0x17003FAB RID: 16299
		// (get) Token: 0x0602235D RID: 140125 RVA: 0x0095EAC3 File Offset: 0x0095CCC3
		// (set) Token: 0x0602235E RID: 140126 RVA: 0x0095EAD7 File Offset: 0x0095CCD7
		public unsafe FVector startPinPos_r
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003FAC RID: 16300
		// (get) Token: 0x0602235F RID: 140127 RVA: 0x0095EAEC File Offset: 0x0095CCEC
		// (set) Token: 0x06022360 RID: 140128 RVA: 0x0095EB00 File Offset: 0x0095CD00
		public unsafe FVector endPinPos_r
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003FAD RID: 16301
		// (get) Token: 0x06022361 RID: 140129 RVA: 0x0095EB15 File Offset: 0x0095CD15
		// (set) Token: 0x06022362 RID: 140130 RVA: 0x0095EB25 File Offset: 0x0095CD25
		public unsafe float percentage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003FAE RID: 16302
		// (get) Token: 0x06022363 RID: 140131 RVA: 0x0095EB36 File Offset: 0x0095CD36
		// (set) Token: 0x06022364 RID: 140132 RVA: 0x0095EB46 File Offset: 0x0095CD46
		public unsafe bool onBridge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FAF RID: 16303
		// (get) Token: 0x06022365 RID: 140133 RVA: 0x0095EB58 File Offset: 0x0095CD58
		// (set) Token: 0x06022366 RID: 140134 RVA: 0x0095EB91 File Offset: 0x0095CD91
		public TArray<float> foeDisList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._foeDisList) == null)
				{
					result = (this._foeDisList = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.foeDisList.CopyAssign(value);
			}
		}

		// Token: 0x17003FB0 RID: 16304
		// (get) Token: 0x06022367 RID: 140135 RVA: 0x0095EBA0 File Offset: 0x0095CDA0
		// (set) Token: 0x06022368 RID: 140136 RVA: 0x0095EBD9 File Offset: 0x0095CDD9
		public TArray<float> foeDisList_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._foeDisList_r) == null)
				{
					result = (this._foeDisList_r = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				this.foeDisList_r.CopyAssign(value);
			}
		}

		// Token: 0x17003FB1 RID: 16305
		// (get) Token: 0x06022369 RID: 140137 RVA: 0x0095EBE8 File Offset: 0x0095CDE8
		// (set) Token: 0x0602236A RID: 140138 RVA: 0x0095EC21 File Offset: 0x0095CE21
		public TArray<float> nxtDisList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._nxtDisList) == null)
				{
					result = (this._nxtDisList = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				this.nxtDisList.CopyAssign(value);
			}
		}

		// Token: 0x17003FB2 RID: 16306
		// (get) Token: 0x0602236B RID: 140139 RVA: 0x0095EC30 File Offset: 0x0095CE30
		// (set) Token: 0x0602236C RID: 140140 RVA: 0x0095EC69 File Offset: 0x0095CE69
		public TArray<float> nxtDisList_r
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._nxtDisList_r) == null)
				{
					result = (this._nxtDisList_r = new TArray<float>(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				this.nxtDisList_r.CopyAssign(value);
			}
		}

		// Token: 0x17003FB3 RID: 16307
		// (get) Token: 0x0602236D RID: 140141 RVA: 0x0095EC77 File Offset: 0x0095CE77
		// (set) Token: 0x0602236E RID: 140142 RVA: 0x0095EC87 File Offset: 0x0095CE87
		public unsafe float offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003FB4 RID: 16308
		// (get) Token: 0x0602236F RID: 140143 RVA: 0x0095EC98 File Offset: 0x0095CE98
		// (set) Token: 0x06022370 RID: 140144 RVA: 0x0095ECA8 File Offset: 0x0095CEA8
		public unsafe float linkDisScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003FB5 RID: 16309
		// (get) Token: 0x06022371 RID: 140145 RVA: 0x0095ECB9 File Offset: 0x0095CEB9
		// (set) Token: 0x06022372 RID: 140146 RVA: 0x0095ECCD File Offset: 0x0095CECD
		[Nullable(2)]
		public unsafe AActor bridgeModels
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_31);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CPP_bridge_doubleChain_realModel_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x06022373 RID: 140147 RVA: 0x0095ECE4 File Offset: 0x0095CEE4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void getTangent(ref TArray<FVector> posArr, ref TArray<FVector> posArrR, int index, ref FVector tangent)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__getTangent_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__getTangent_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__getTangent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__getTangent_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__getTangent_NativeFunctionPtr, (void*)ptr);
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
			UnrealReflectionUtils.DestroyStruct(BP_CPP_bridge_doubleChain_realModel_C.__getTangent_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06022374 RID: 140148 RVA: 0x0095EDA8 File Offset: 0x0095CFA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__solve_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x06022375 RID: 140149 RVA: 0x0095EE29 File Offset: 0x0095D029
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022376 RID: 140150 RVA: 0x0095EE3D File Offset: 0x0095D03D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022377 RID: 140151 RVA: 0x0095EE52 File Offset: 0x0095D052
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022378 RID: 140152 RVA: 0x0095EE66 File Offset: 0x0095D066
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022379 RID: 140153 RVA: 0x0095EE7C File Offset: 0x0095D07C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602237A RID: 140154 RVA: 0x0095EEC4 File Offset: 0x0095D0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602237B RID: 140155 RVA: 0x0095EF0C File Offset: 0x0095D10C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602237C RID: 140156 RVA: 0x0095EFC8 File Offset: 0x0095D1C8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602237D RID: 140157 RVA: 0x0095F054 File Offset: 0x0095D254
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel(int EntryPoint)
		{
			BP_CPP_bridge_doubleChain_realModel_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_FunctionParams* ptr = stackalloc BP_CPP_bridge_doubleChain_realModel_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_FunctionParams[(UIntPtr)1607] + 15L / (long)sizeof(BP_CPP_bridge_doubleChain_realModel_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CPP_bridge_doubleChain_realModel_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CPP_bridge_doubleChain_realModel_C.__ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602237E RID: 140158 RVA: 0x0095F09E File Offset: 0x0095D29E
		protected BP_CPP_bridge_doubleChain_realModel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011491 RID: 70801
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_CPP_bridge_doubleChain_realModel.BP_CPP_bridge_doubleChain_realModel_C";

		// Token: 0x04011492 RID: 70802
		private static IntPtr _ClassPtr;

		// Token: 0x04011493 RID: 70803
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011494 RID: 70804
		internal static int __PropertyOffset_0;

		// Token: 0x04011495 RID: 70805
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011496 RID: 70806
		internal static int __PropertyOffset_1;

		// Token: 0x04011497 RID: 70807
		internal static int __PropertyOffset_2;

		// Token: 0x04011498 RID: 70808
		internal static int __PropertyOffset_3;

		// Token: 0x04011499 RID: 70809
		[Nullable(2)]
		private TArray<FVector> _posArr;

		// Token: 0x0401149A RID: 70810
		internal static int __PropertyOffset_4;

		// Token: 0x0401149B RID: 70811
		[Nullable(2)]
		private TArray<FVector> _volArr;

		// Token: 0x0401149C RID: 70812
		internal static int __PropertyOffset_5;

		// Token: 0x0401149D RID: 70813
		internal static int __PropertyOffset_6;

		// Token: 0x0401149E RID: 70814
		internal static int __PropertyOffset_7;

		// Token: 0x0401149F RID: 70815
		internal static int __PropertyOffset_8;

		// Token: 0x040114A0 RID: 70816
		internal static int __PropertyOffset_9;

		// Token: 0x040114A1 RID: 70817
		[Nullable(2)]
		private TArray<FVector> _posArr_foe;

		// Token: 0x040114A2 RID: 70818
		internal static int __PropertyOffset_10;

		// Token: 0x040114A3 RID: 70819
		internal static int __PropertyOffset_11;

		// Token: 0x040114A4 RID: 70820
		internal static int __PropertyOffset_12;

		// Token: 0x040114A5 RID: 70821
		internal static int __PropertyOffset_13;

		// Token: 0x040114A6 RID: 70822
		internal static int __PropertyOffset_14;

		// Token: 0x040114A7 RID: 70823
		internal static int __PropertyOffset_15;

		// Token: 0x040114A8 RID: 70824
		internal static int __PropertyOffset_16;

		// Token: 0x040114A9 RID: 70825
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _plankList;

		// Token: 0x040114AA RID: 70826
		internal static int __PropertyOffset_17;

		// Token: 0x040114AB RID: 70827
		internal static int __PropertyOffset_18;

		// Token: 0x040114AC RID: 70828
		[Nullable(2)]
		private TArray<FVector> _posArr_r;

		// Token: 0x040114AD RID: 70829
		internal static int __PropertyOffset_19;

		// Token: 0x040114AE RID: 70830
		[Nullable(2)]
		private TArray<FVector> _volArr_r;

		// Token: 0x040114AF RID: 70831
		internal static int __PropertyOffset_20;

		// Token: 0x040114B0 RID: 70832
		[Nullable(2)]
		private TArray<FVector> _posArr_foe_r;

		// Token: 0x040114B1 RID: 70833
		internal static int __PropertyOffset_21;

		// Token: 0x040114B2 RID: 70834
		internal static int __PropertyOffset_22;

		// Token: 0x040114B3 RID: 70835
		internal static int __PropertyOffset_23;

		// Token: 0x040114B4 RID: 70836
		internal static int __PropertyOffset_24;

		// Token: 0x040114B5 RID: 70837
		internal static int __PropertyOffset_25;

		// Token: 0x040114B6 RID: 70838
		[Nullable(2)]
		private TArray<float> _foeDisList;

		// Token: 0x040114B7 RID: 70839
		internal static int __PropertyOffset_26;

		// Token: 0x040114B8 RID: 70840
		[Nullable(2)]
		private TArray<float> _foeDisList_r;

		// Token: 0x040114B9 RID: 70841
		internal static int __PropertyOffset_27;

		// Token: 0x040114BA RID: 70842
		[Nullable(2)]
		private TArray<float> _nxtDisList;

		// Token: 0x040114BB RID: 70843
		internal static int __PropertyOffset_28;

		// Token: 0x040114BC RID: 70844
		[Nullable(2)]
		private TArray<float> _nxtDisList_r;

		// Token: 0x040114BD RID: 70845
		internal static int __PropertyOffset_29;

		// Token: 0x040114BE RID: 70846
		internal static int __PropertyOffset_30;

		// Token: 0x040114BF RID: 70847
		internal static int __PropertyOffset_31;

		// Token: 0x040114C0 RID: 70848
		private static IntPtr __getTangent_NativeFunctionPtr;

		// Token: 0x040114C1 RID: 70849
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x040114C2 RID: 70850
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040114C3 RID: 70851
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040114C4 RID: 70852
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040114C5 RID: 70853
		private static IntPtr __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040114C6 RID: 70854
		private static IntPtr __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040114C7 RID: 70855
		private static IntPtr __ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_NativeFunctionPtr;

		// Token: 0x02009B9D RID: 39837
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __getTangent_FunctionParams
		{
			// Token: 0x040323BC RID: 205756
			[FieldOffset(0)]
			public byte posArr;

			// Token: 0x040323BD RID: 205757
			[FieldOffset(16)]
			public byte posArrR;

			// Token: 0x040323BE RID: 205758
			[FieldOffset(32)]
			public int index;

			// Token: 0x040323BF RID: 205759
			[FieldOffset(36)]
			public FVector tangent;
		}

		// Token: 0x02009B9E RID: 39838
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x040323C0 RID: 205760
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x040323C1 RID: 205761
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x040323C2 RID: 205762
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x040323C3 RID: 205763
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x040323C4 RID: 205764
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x040323C5 RID: 205765
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009B9F RID: 39839
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323C6 RID: 205766
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BA0 RID: 39840
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040323C7 RID: 205767
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040323C8 RID: 205768
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040323C9 RID: 205769
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040323CA RID: 205770
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040323CB RID: 205771
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040323CC RID: 205772
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009BA1 RID: 39841
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CPP_bridge_doubleChain_realModel_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040323CD RID: 205773
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040323CE RID: 205774
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040323CF RID: 205775
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040323D0 RID: 205776
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009BA2 RID: 39842
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1592)]
		protected ref struct __ExecuteUbergraph_BP_CPP_bridge_doubleChain_realModel_FunctionParams
		{
			// Token: 0x040323D1 RID: 205777
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
