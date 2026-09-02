using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C25 RID: 15397
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33.BP_genCloth_33_C")]
	[UnrealStructLayout(1704, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1700)]
	public class BP_genCloth_33_C : AKuroCSGenericCloth_33, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602328F RID: 144015 RVA: 0x0097A97B File Offset: 0x00978B7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_genCloth_33_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33.BP_genCloth_33_C");
			}
			return BP_genCloth_33_C._ClassPtr;
		}

		// Token: 0x06023290 RID: 144016 RVA: 0x0097A9A0 File Offset: 0x00978BA0
		public BP_genCloth_33_C() : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_33_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023291 RID: 144017 RVA: 0x0097A9C8 File Offset: 0x00978BC8
		[NullableContext(1)]
		public BP_genCloth_33_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_33_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170044BC RID: 17596
		// (get) Token: 0x06023292 RID: 144018 RVA: 0x0097A9FC File Offset: 0x00978BFC
		// (set) Token: 0x06023293 RID: 144019 RVA: 0x0097AA35 File Offset: 0x00978C35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170044BD RID: 17597
		// (get) Token: 0x06023294 RID: 144020 RVA: 0x0097AA56 File Offset: 0x00978C56
		// (set) Token: 0x06023295 RID: 144021 RVA: 0x0097AA6A File Offset: 0x00978C6A
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170044BE RID: 17598
		// (get) Token: 0x06023296 RID: 144022 RVA: 0x0097AA7F File Offset: 0x00978C7F
		// (set) Token: 0x06023297 RID: 144023 RVA: 0x0097AA93 File Offset: 0x00978C93
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170044BF RID: 17599
		// (get) Token: 0x06023298 RID: 144024 RVA: 0x0097AAA8 File Offset: 0x00978CA8
		// (set) Token: 0x06023299 RID: 144025 RVA: 0x0097AABC File Offset: 0x00978CBC
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170044C0 RID: 17600
		// (get) Token: 0x0602329A RID: 144026 RVA: 0x0097AAD1 File Offset: 0x00978CD1
		// (set) Token: 0x0602329B RID: 144027 RVA: 0x0097AAE5 File Offset: 0x00978CE5
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170044C1 RID: 17601
		// (get) Token: 0x0602329C RID: 144028 RVA: 0x0097AAFA File Offset: 0x00978CFA
		// (set) Token: 0x0602329D RID: 144029 RVA: 0x0097AB0E File Offset: 0x00978D0E
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170044C2 RID: 17602
		// (get) Token: 0x0602329E RID: 144030 RVA: 0x0097AB23 File Offset: 0x00978D23
		// (set) Token: 0x0602329F RID: 144031 RVA: 0x0097AB37 File Offset: 0x00978D37
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170044C3 RID: 17603
		// (get) Token: 0x060232A0 RID: 144032 RVA: 0x0097AB4C File Offset: 0x00978D4C
		// (set) Token: 0x060232A1 RID: 144033 RVA: 0x0097AB5C File Offset: 0x00978D5C
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044C4 RID: 17604
		// (get) Token: 0x060232A2 RID: 144034 RVA: 0x0097AB6D File Offset: 0x00978D6D
		// (set) Token: 0x060232A3 RID: 144035 RVA: 0x0097AB81 File Offset: 0x00978D81
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170044C5 RID: 17605
		// (get) Token: 0x060232A4 RID: 144036 RVA: 0x0097AB96 File Offset: 0x00978D96
		// (set) Token: 0x060232A5 RID: 144037 RVA: 0x0097ABA6 File Offset: 0x00978DA6
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170044C6 RID: 17606
		// (get) Token: 0x060232A6 RID: 144038 RVA: 0x0097ABB7 File Offset: 0x00978DB7
		// (set) Token: 0x060232A7 RID: 144039 RVA: 0x0097ABC7 File Offset: 0x00978DC7
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044C7 RID: 17607
		// (get) Token: 0x060232A8 RID: 144040 RVA: 0x0097ABD8 File Offset: 0x00978DD8
		// (set) Token: 0x060232A9 RID: 144041 RVA: 0x0097ABE8 File Offset: 0x00978DE8
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044C8 RID: 17608
		// (get) Token: 0x060232AA RID: 144042 RVA: 0x0097ABF9 File Offset: 0x00978DF9
		// (set) Token: 0x060232AB RID: 144043 RVA: 0x0097AC09 File Offset: 0x00978E09
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170044C9 RID: 17609
		// (get) Token: 0x060232AC RID: 144044 RVA: 0x0097AC1A File Offset: 0x00978E1A
		// (set) Token: 0x060232AD RID: 144045 RVA: 0x0097AC2A File Offset: 0x00978E2A
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044CA RID: 17610
		// (get) Token: 0x060232AE RID: 144046 RVA: 0x0097AC3B File Offset: 0x00978E3B
		// (set) Token: 0x060232AF RID: 144047 RVA: 0x0097AC4B File Offset: 0x00978E4B
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044CB RID: 17611
		// (get) Token: 0x060232B0 RID: 144048 RVA: 0x0097AC5C File Offset: 0x00978E5C
		// (set) Token: 0x060232B1 RID: 144049 RVA: 0x0097AC6C File Offset: 0x00978E6C
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170044CC RID: 17612
		// (get) Token: 0x060232B2 RID: 144050 RVA: 0x0097AC7D File Offset: 0x00978E7D
		// (set) Token: 0x060232B3 RID: 144051 RVA: 0x0097AC8D File Offset: 0x00978E8D
		public unsafe bool ReadFromBPL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044CD RID: 17613
		// (get) Token: 0x060232B4 RID: 144052 RVA: 0x0097AC9E File Offset: 0x00978E9E
		// (set) Token: 0x060232B5 RID: 144053 RVA: 0x0097ACAE File Offset: 0x00978EAE
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044CE RID: 17614
		// (get) Token: 0x060232B6 RID: 144054 RVA: 0x0097ACBF File Offset: 0x00978EBF
		// (set) Token: 0x060232B7 RID: 144055 RVA: 0x0097ACD3 File Offset: 0x00978ED3
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170044CF RID: 17615
		// (get) Token: 0x060232B8 RID: 144056 RVA: 0x0097ACE8 File Offset: 0x00978EE8
		// (set) Token: 0x060232B9 RID: 144057 RVA: 0x0097ACFC File Offset: 0x00978EFC
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170044D0 RID: 17616
		// (get) Token: 0x060232BA RID: 144058 RVA: 0x0097AD11 File Offset: 0x00978F11
		// (set) Token: 0x060232BB RID: 144059 RVA: 0x0097AD21 File Offset: 0x00978F21
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044D1 RID: 17617
		// (get) Token: 0x060232BC RID: 144060 RVA: 0x0097AD32 File Offset: 0x00978F32
		// (set) Token: 0x060232BD RID: 144061 RVA: 0x0097AD42 File Offset: 0x00978F42
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044D2 RID: 17618
		// (get) Token: 0x060232BE RID: 144062 RVA: 0x0097AD53 File Offset: 0x00978F53
		// (set) Token: 0x060232BF RID: 144063 RVA: 0x0097AD63 File Offset: 0x00978F63
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170044D3 RID: 17619
		// (get) Token: 0x060232C0 RID: 144064 RVA: 0x0097AD74 File Offset: 0x00978F74
		// (set) Token: 0x060232C1 RID: 144065 RVA: 0x0097AD88 File Offset: 0x00978F88
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170044D4 RID: 17620
		// (get) Token: 0x060232C2 RID: 144066 RVA: 0x0097AD9D File Offset: 0x00978F9D
		// (set) Token: 0x060232C3 RID: 144067 RVA: 0x0097ADB1 File Offset: 0x00978FB1
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170044D5 RID: 17621
		// (get) Token: 0x060232C4 RID: 144068 RVA: 0x0097ADC6 File Offset: 0x00978FC6
		// (set) Token: 0x060232C5 RID: 144069 RVA: 0x0097ADDA File Offset: 0x00978FDA
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170044D6 RID: 17622
		// (get) Token: 0x060232C6 RID: 144070 RVA: 0x0097ADEF File Offset: 0x00978FEF
		// (set) Token: 0x060232C7 RID: 144071 RVA: 0x0097AE03 File Offset: 0x00979003
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170044D7 RID: 17623
		// (get) Token: 0x060232C8 RID: 144072 RVA: 0x0097AE18 File Offset: 0x00979018
		// (set) Token: 0x060232C9 RID: 144073 RVA: 0x0097AE28 File Offset: 0x00979028
		public unsafe bool UseStaticCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044D8 RID: 17624
		// (get) Token: 0x060232CA RID: 144074 RVA: 0x0097AE39 File Offset: 0x00979039
		// (set) Token: 0x060232CB RID: 144075 RVA: 0x0097AE4D File Offset: 0x0097904D
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170044D9 RID: 17625
		// (get) Token: 0x060232CC RID: 144076 RVA: 0x0097AE64 File Offset: 0x00979064
		// (set) Token: 0x060232CD RID: 144077 RVA: 0x0097AE9D File Offset: 0x0097909D
		[Nullable(1)]
		public TArray<FKuroCSUnifiedCollider_genericCloth_33> ColArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCSUnifiedCollider_genericCloth_33> result;
				if ((result = this._ColArr) == null)
				{
					result = (this._ColArr = new TArray<FKuroCSUnifiedCollider_genericCloth_33>(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ColArr.CopyAssign(value);
			}
		}

		// Token: 0x170044DA RID: 17626
		// (get) Token: 0x060232CE RID: 144078 RVA: 0x0097AEAB File Offset: 0x009790AB
		// (set) Token: 0x060232CF RID: 144079 RVA: 0x0097AEBB File Offset: 0x009790BB
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044DB RID: 17627
		// (get) Token: 0x060232D0 RID: 144080 RVA: 0x0097AECC File Offset: 0x009790CC
		// (set) Token: 0x060232D1 RID: 144081 RVA: 0x0097AEDC File Offset: 0x009790DC
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170044DC RID: 17628
		// (get) Token: 0x060232D2 RID: 144082 RVA: 0x0097AEED File Offset: 0x009790ED
		// (set) Token: 0x060232D3 RID: 144083 RVA: 0x0097AEFD File Offset: 0x009790FD
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044DD RID: 17629
		// (get) Token: 0x060232D4 RID: 144084 RVA: 0x0097AF0E File Offset: 0x0097910E
		// (set) Token: 0x060232D5 RID: 144085 RVA: 0x0097AF1E File Offset: 0x0097911E
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044DE RID: 17630
		// (get) Token: 0x060232D6 RID: 144086 RVA: 0x0097AF2F File Offset: 0x0097912F
		// (set) Token: 0x060232D7 RID: 144087 RVA: 0x0097AF3F File Offset: 0x0097913F
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044DF RID: 17631
		// (get) Token: 0x060232D8 RID: 144088 RVA: 0x0097AF50 File Offset: 0x00979150
		// (set) Token: 0x060232D9 RID: 144089 RVA: 0x0097AF60 File Offset: 0x00979160
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x060232DA RID: 144090 RVA: 0x0097AF71 File Offset: 0x00979171
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060232DB RID: 144091 RVA: 0x0097AF85 File Offset: 0x00979185
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060232DC RID: 144092 RVA: 0x0097AF9A File Offset: 0x0097919A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060232DD RID: 144093 RVA: 0x0097AFAE File Offset: 0x009791AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060232DE RID: 144094 RVA: 0x0097AFC4 File Offset: 0x009791C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_genCloth_33_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_33_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232DF RID: 144095 RVA: 0x0097B00C File Offset: 0x0097920C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_genCloth_33_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_33_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060232E0 RID: 144096 RVA: 0x0097B054 File Offset: 0x00979254
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232E1 RID: 144097 RVA: 0x0097B0A0 File Offset: 0x009792A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_33_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060232E2 RID: 144098 RVA: 0x0097B0EC File Offset: 0x009792EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_genCloth_33_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_33_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232E3 RID: 144099 RVA: 0x0097B1A0 File Offset: 0x009793A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232E4 RID: 144100 RVA: 0x0097B25C File Offset: 0x0097945C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232E5 RID: 144101 RVA: 0x0097B2E8 File Offset: 0x009794E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_genCloth_33_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_genCloth_33_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060232E6 RID: 144102 RVA: 0x0097B34B File Offset: 0x0097954B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060232E7 RID: 144103 RVA: 0x0097B35F File Offset: 0x0097955F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetDeadNode()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_C.__SetDeadNode_NativeFunctionPtr, null);
		}

		// Token: 0x060232E8 RID: 144104 RVA: 0x0097B374 File Offset: 0x00979574
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_genCloth_33(int EntryPoint)
		{
			BP_genCloth_33_C.__ExecuteUbergraph_BP_genCloth_33_FunctionParams* ptr = stackalloc BP_genCloth_33_C.__ExecuteUbergraph_BP_genCloth_33_FunctionParams[(UIntPtr)3743] + 15L / (long)sizeof(BP_genCloth_33_C.__ExecuteUbergraph_BP_genCloth_33_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_C.__ExecuteUbergraph_BP_genCloth_33_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_C.__ExecuteUbergraph_BP_genCloth_33_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060232E9 RID: 144105 RVA: 0x0097B3BE File Offset: 0x009795BE
		protected BP_genCloth_33_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011E16 RID: 73238
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33.BP_genCloth_33_C";

		// Token: 0x04011E17 RID: 73239
		private static IntPtr _ClassPtr;

		// Token: 0x04011E18 RID: 73240
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011E19 RID: 73241
		internal static int __PropertyOffset_0;

		// Token: 0x04011E1A RID: 73242
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011E1B RID: 73243
		internal static int __PropertyOffset_1;

		// Token: 0x04011E1C RID: 73244
		internal static int __PropertyOffset_2;

		// Token: 0x04011E1D RID: 73245
		internal static int __PropertyOffset_3;

		// Token: 0x04011E1E RID: 73246
		internal static int __PropertyOffset_4;

		// Token: 0x04011E1F RID: 73247
		internal static int __PropertyOffset_5;

		// Token: 0x04011E20 RID: 73248
		internal static int __PropertyOffset_6;

		// Token: 0x04011E21 RID: 73249
		internal static int __PropertyOffset_7;

		// Token: 0x04011E22 RID: 73250
		internal static int __PropertyOffset_8;

		// Token: 0x04011E23 RID: 73251
		internal static int __PropertyOffset_9;

		// Token: 0x04011E24 RID: 73252
		internal static int __PropertyOffset_10;

		// Token: 0x04011E25 RID: 73253
		internal static int __PropertyOffset_11;

		// Token: 0x04011E26 RID: 73254
		internal static int __PropertyOffset_12;

		// Token: 0x04011E27 RID: 73255
		internal static int __PropertyOffset_13;

		// Token: 0x04011E28 RID: 73256
		internal static int __PropertyOffset_14;

		// Token: 0x04011E29 RID: 73257
		internal static int __PropertyOffset_15;

		// Token: 0x04011E2A RID: 73258
		internal static int __PropertyOffset_16;

		// Token: 0x04011E2B RID: 73259
		internal static int __PropertyOffset_17;

		// Token: 0x04011E2C RID: 73260
		internal static int __PropertyOffset_18;

		// Token: 0x04011E2D RID: 73261
		internal static int __PropertyOffset_19;

		// Token: 0x04011E2E RID: 73262
		internal static int __PropertyOffset_20;

		// Token: 0x04011E2F RID: 73263
		internal static int __PropertyOffset_21;

		// Token: 0x04011E30 RID: 73264
		internal static int __PropertyOffset_22;

		// Token: 0x04011E31 RID: 73265
		internal static int __PropertyOffset_23;

		// Token: 0x04011E32 RID: 73266
		internal static int __PropertyOffset_24;

		// Token: 0x04011E33 RID: 73267
		internal static int __PropertyOffset_25;

		// Token: 0x04011E34 RID: 73268
		internal static int __PropertyOffset_26;

		// Token: 0x04011E35 RID: 73269
		internal static int __PropertyOffset_27;

		// Token: 0x04011E36 RID: 73270
		internal static int __PropertyOffset_28;

		// Token: 0x04011E37 RID: 73271
		internal static int __PropertyOffset_29;

		// Token: 0x04011E38 RID: 73272
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCSUnifiedCollider_genericCloth_33> _ColArr;

		// Token: 0x04011E39 RID: 73273
		internal static int __PropertyOffset_30;

		// Token: 0x04011E3A RID: 73274
		internal static int __PropertyOffset_31;

		// Token: 0x04011E3B RID: 73275
		internal static int __PropertyOffset_32;

		// Token: 0x04011E3C RID: 73276
		internal static int __PropertyOffset_33;

		// Token: 0x04011E3D RID: 73277
		internal static int __PropertyOffset_34;

		// Token: 0x04011E3E RID: 73278
		internal static int __PropertyOffset_35;

		// Token: 0x04011E3F RID: 73279
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011E40 RID: 73280
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011E41 RID: 73281
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011E42 RID: 73282
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011E43 RID: 73283
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E44 RID: 73284
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E45 RID: 73285
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E46 RID: 73286
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011E47 RID: 73287
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011E48 RID: 73288
		private static IntPtr __SetDeadNode_NativeFunctionPtr;

		// Token: 0x04011E49 RID: 73289
		private static IntPtr __ExecuteUbergraph_BP_genCloth_33_NativeFunctionPtr;

		// Token: 0x02009CA4 RID: 40100
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040325DC RID: 206300
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CA5 RID: 40101
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040325DD RID: 206301
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009CA6 RID: 40102
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325DE RID: 206302
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040325DF RID: 206303
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325E0 RID: 206304
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325E1 RID: 206305
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040325E2 RID: 206306
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009CA7 RID: 40103
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325E3 RID: 206307
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325E4 RID: 206308
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325E5 RID: 206309
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325E6 RID: 206310
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040325E7 RID: 206311
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040325E8 RID: 206312
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CA8 RID: 40104
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325E9 RID: 206313
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325EA RID: 206314
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325EB RID: 206315
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325EC RID: 206316
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CA9 RID: 40105
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040325ED RID: 206317
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040325EE RID: 206318
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040325EF RID: 206319
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009CAA RID: 40106
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3728)]
		protected ref struct __ExecuteUbergraph_BP_genCloth_33_FunctionParams
		{
			// Token: 0x040325F0 RID: 206320
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
