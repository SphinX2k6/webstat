using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A0D RID: 14861
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancy.BP_WaterBuoyancy_C")]
	[UnrealStructLayout(1648, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1633)]
	public class BP_WaterBuoyancy_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E58F RID: 124303 RVA: 0x008F37E7 File Offset: 0x008F19E7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterBuoyancy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancy.BP_WaterBuoyancy_C");
			}
			return BP_WaterBuoyancy_C._ClassPtr;
		}

		// Token: 0x0601E590 RID: 124304 RVA: 0x008F380C File Offset: 0x008F1A0C
		public BP_WaterBuoyancy_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E591 RID: 124305 RVA: 0x008F3834 File Offset: 0x008F1A34
		[NullableContext(1)]
		public BP_WaterBuoyancy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029BF RID: 10687
		// (get) Token: 0x0601E592 RID: 124306 RVA: 0x008F3868 File Offset: 0x008F1A68
		// (set) Token: 0x0601E593 RID: 124307 RVA: 0x008F38A1 File Offset: 0x008F1AA1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170029C0 RID: 10688
		// (get) Token: 0x0601E594 RID: 124308 RVA: 0x008F38C2 File Offset: 0x008F1AC2
		// (set) Token: 0x0601E595 RID: 124309 RVA: 0x008F38D6 File Offset: 0x008F1AD6
		public unsafe BP_WaterInteractObjectRipple_Component_C WaterRippleComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WaterInteractObjectRipple_Component_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170029C1 RID: 10689
		// (get) Token: 0x0601E596 RID: 124310 RVA: 0x008F38EB File Offset: 0x008F1AEB
		// (set) Token: 0x0601E597 RID: 124311 RVA: 0x008F38FF File Offset: 0x008F1AFF
		public unsafe UStaticMeshComponent CollisionMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170029C2 RID: 10690
		// (get) Token: 0x0601E598 RID: 124312 RVA: 0x008F3914 File Offset: 0x008F1B14
		// (set) Token: 0x0601E599 RID: 124313 RVA: 0x008F3928 File Offset: 0x008F1B28
		public unsafe UStaticMesh BuoyancyStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170029C3 RID: 10691
		// (get) Token: 0x0601E59A RID: 124314 RVA: 0x008F3940 File Offset: 0x008F1B40
		// (set) Token: 0x0601E59B RID: 124315 RVA: 0x008F3979 File Offset: 0x008F1B79
		[Nullable(1)]
		public TArray<FVector4> sphereList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector4> result;
				if ((result = this._sphereList) == null)
				{
					result = (this._sphereList = new TArray<FVector4>(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.sphereList.CopyAssign(value);
			}
		}

		// Token: 0x170029C4 RID: 10692
		// (get) Token: 0x0601E59C RID: 124316 RVA: 0x008F3987 File Offset: 0x008F1B87
		// (set) Token: 0x0601E59D RID: 124317 RVA: 0x008F3997 File Offset: 0x008F1B97
		public unsafe float waterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170029C5 RID: 10693
		// (get) Token: 0x0601E59E RID: 124318 RVA: 0x008F39A8 File Offset: 0x008F1BA8
		// (set) Token: 0x0601E59F RID: 124319 RVA: 0x008F39B8 File Offset: 0x008F1BB8
		public unsafe float StaticHeightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170029C6 RID: 10694
		// (get) Token: 0x0601E5A0 RID: 124320 RVA: 0x008F39C9 File Offset: 0x008F1BC9
		// (set) Token: 0x0601E5A1 RID: 124321 RVA: 0x008F39D9 File Offset: 0x008F1BD9
		public unsafe float BuoyancyIntersity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170029C7 RID: 10695
		// (get) Token: 0x0601E5A2 RID: 124322 RVA: 0x008F39EA File Offset: 0x008F1BEA
		// (set) Token: 0x0601E5A3 RID: 124323 RVA: 0x008F39FA File Offset: 0x008F1BFA
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170029C8 RID: 10696
		// (get) Token: 0x0601E5A4 RID: 124324 RVA: 0x008F3A0B File Offset: 0x008F1C0B
		// (set) Token: 0x0601E5A5 RID: 124325 RVA: 0x008F3A1B File Offset: 0x008F1C1B
		public unsafe float LinearDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170029C9 RID: 10697
		// (get) Token: 0x0601E5A6 RID: 124326 RVA: 0x008F3A2C File Offset: 0x008F1C2C
		// (set) Token: 0x0601E5A7 RID: 124327 RVA: 0x008F3A3C File Offset: 0x008F1C3C
		public unsafe float AngularDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170029CA RID: 10698
		// (get) Token: 0x0601E5A8 RID: 124328 RVA: 0x008F3A4D File Offset: 0x008F1C4D
		// (set) Token: 0x0601E5A9 RID: 124329 RVA: 0x008F3A5D File Offset: 0x008F1C5D
		public unsafe float MinDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170029CB RID: 10699
		// (get) Token: 0x0601E5AA RID: 124330 RVA: 0x008F3A6E File Offset: 0x008F1C6E
		// (set) Token: 0x0601E5AB RID: 124331 RVA: 0x008F3A7E File Offset: 0x008F1C7E
		public unsafe float RippleRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170029CC RID: 10700
		// (get) Token: 0x0601E5AC RID: 124332 RVA: 0x008F3A8F File Offset: 0x008F1C8F
		// (set) Token: 0x0601E5AD RID: 124333 RVA: 0x008F3A9F File Offset: 0x008F1C9F
		public unsafe float RippleTickInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170029CD RID: 10701
		// (get) Token: 0x0601E5AE RID: 124334 RVA: 0x008F3AB0 File Offset: 0x008F1CB0
		// (set) Token: 0x0601E5AF RID: 124335 RVA: 0x008F3AC0 File Offset: 0x008F1CC0
		public unsafe float LastRippleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170029CE RID: 10702
		// (get) Token: 0x0601E5B0 RID: 124336 RVA: 0x008F3AD1 File Offset: 0x008F1CD1
		// (set) Token: 0x0601E5B1 RID: 124337 RVA: 0x008F3AE5 File Offset: 0x008F1CE5
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170029CF RID: 10703
		// (get) Token: 0x0601E5B2 RID: 124338 RVA: 0x008F3AFC File Offset: 0x008F1CFC
		// (set) Token: 0x0601E5B3 RID: 124339 RVA: 0x008F3B35 File Offset: 0x008F1D35
		[Nullable(1)]
		public TArray<FVector> RipplePointList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._RipplePointList) == null)
				{
					result = (this._RipplePointList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RipplePointList.CopyAssign(value);
			}
		}

		// Token: 0x170029D0 RID: 10704
		// (get) Token: 0x0601E5B4 RID: 124340 RVA: 0x008F3B43 File Offset: 0x008F1D43
		// (set) Token: 0x0601E5B5 RID: 124341 RVA: 0x008F3B53 File Offset: 0x008F1D53
		public unsafe double RippleDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170029D1 RID: 10705
		// (get) Token: 0x0601E5B6 RID: 124342 RVA: 0x008F3B64 File Offset: 0x008F1D64
		// (set) Token: 0x0601E5B7 RID: 124343 RVA: 0x008F3B74 File Offset: 0x008F1D74
		public unsafe float 产生水波时吃水比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170029D2 RID: 10706
		// (get) Token: 0x0601E5B8 RID: 124344 RVA: 0x008F3B85 File Offset: 0x008F1D85
		// (set) Token: 0x0601E5B9 RID: 124345 RVA: 0x008F3B99 File Offset: 0x008F1D99
		public unsafe FTransformDouble LastTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170029D3 RID: 10707
		// (get) Token: 0x0601E5BA RID: 124346 RVA: 0x008F3BAE File Offset: 0x008F1DAE
		// (set) Token: 0x0601E5BB RID: 124347 RVA: 0x008F3BBE File Offset: 0x008F1DBE
		public unsafe double DistforPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170029D4 RID: 10708
		// (get) Token: 0x0601E5BC RID: 124348 RVA: 0x008F3BCF File Offset: 0x008F1DCF
		// (set) Token: 0x0601E5BD RID: 124349 RVA: 0x008F3BDF File Offset: 0x008F1DDF
		public unsafe float V_total
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170029D5 RID: 10709
		// (get) Token: 0x0601E5BE RID: 124350 RVA: 0x008F3BF0 File Offset: 0x008F1DF0
		// (set) Token: 0x0601E5BF RID: 124351 RVA: 0x008F3C00 File Offset: 0x008F1E00
		public unsafe float V_inWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170029D6 RID: 10710
		// (get) Token: 0x0601E5C0 RID: 124352 RVA: 0x008F3C11 File Offset: 0x008F1E11
		// (set) Token: 0x0601E5C1 RID: 124353 RVA: 0x008F3C21 File Offset: 0x008F1E21
		public unsafe float FPSLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170029D7 RID: 10711
		// (get) Token: 0x0601E5C2 RID: 124354 RVA: 0x008F3C32 File Offset: 0x008F1E32
		// (set) Token: 0x0601E5C3 RID: 124355 RVA: 0x008F3C42 File Offset: 0x008F1E42
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170029D8 RID: 10712
		// (get) Token: 0x0601E5C4 RID: 124356 RVA: 0x008F3C53 File Offset: 0x008F1E53
		// (set) Token: 0x0601E5C5 RID: 124357 RVA: 0x008F3C63 File Offset: 0x008F1E63
		public unsafe double BuoyancyRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170029D9 RID: 10713
		// (get) Token: 0x0601E5C6 RID: 124358 RVA: 0x008F3C74 File Offset: 0x008F1E74
		// (set) Token: 0x0601E5C7 RID: 124359 RVA: 0x008F3C84 File Offset: 0x008F1E84
		public unsafe bool UseWaterRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x170029DA RID: 10714
		// (get) Token: 0x0601E5C8 RID: 124360 RVA: 0x008F3C95 File Offset: 0x008F1E95
		// (set) Token: 0x0601E5C9 RID: 124361 RVA: 0x008F3CA5 File Offset: 0x008F1EA5
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170029DB RID: 10715
		// (get) Token: 0x0601E5CA RID: 124362 RVA: 0x008F3CB6 File Offset: 0x008F1EB6
		// (set) Token: 0x0601E5CB RID: 124363 RVA: 0x008F3CC6 File Offset: 0x008F1EC6
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170029DC RID: 10716
		// (get) Token: 0x0601E5CC RID: 124364 RVA: 0x008F3CD7 File Offset: 0x008F1ED7
		// (set) Token: 0x0601E5CD RID: 124365 RVA: 0x008F3CEB File Offset: 0x008F1EEB
		public unsafe BP_WaterBuoyancyCollision_C BuoyancyCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WaterBuoyancyCollision_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancy_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170029DD RID: 10717
		// (get) Token: 0x0601E5CE RID: 124366 RVA: 0x008F3D00 File Offset: 0x008F1F00
		// (set) Token: 0x0601E5CF RID: 124367 RVA: 0x008F3D14 File Offset: 0x008F1F14
		public unsafe FVector Box_Extent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170029DE RID: 10718
		// (get) Token: 0x0601E5D0 RID: 124368 RVA: 0x008F3D29 File Offset: 0x008F1F29
		// (set) Token: 0x0601E5D1 RID: 124369 RVA: 0x008F3D3D File Offset: 0x008F1F3D
		public unsafe FVector Box_Origin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170029DF RID: 10719
		// (get) Token: 0x0601E5D2 RID: 124370 RVA: 0x008F3D52 File Offset: 0x008F1F52
		// (set) Token: 0x0601E5D3 RID: 124371 RVA: 0x008F3D62 File Offset: 0x008F1F62
		public unsafe bool InRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170029E0 RID: 10720
		// (get) Token: 0x0601E5D4 RID: 124372 RVA: 0x008F3D73 File Offset: 0x008F1F73
		// (set) Token: 0x0601E5D5 RID: 124373 RVA: 0x008F3D83 File Offset: 0x008F1F83
		public unsafe float Timer_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170029E1 RID: 10721
		// (get) Token: 0x0601E5D6 RID: 124374 RVA: 0x008F3D94 File Offset: 0x008F1F94
		// (set) Token: 0x0601E5D7 RID: 124375 RVA: 0x008F3DA8 File Offset: 0x008F1FA8
		public unsafe FVectorDouble BornLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170029E2 RID: 10722
		// (get) Token: 0x0601E5D8 RID: 124376 RVA: 0x008F3DBD File Offset: 0x008F1FBD
		// (set) Token: 0x0601E5D9 RID: 124377 RVA: 0x008F3DCD File Offset: 0x008F1FCD
		public unsafe double ResetDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170029E3 RID: 10723
		// (get) Token: 0x0601E5DA RID: 124378 RVA: 0x008F3DDE File Offset: 0x008F1FDE
		// (set) Token: 0x0601E5DB RID: 124379 RVA: 0x008F3DEE File Offset: 0x008F1FEE
		public unsafe bool IsVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancy_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E5DC RID: 124380 RVA: 0x008F3DFF File Offset: 0x008F1FFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WaterRipple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__WaterRipple_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5DD RID: 124381 RVA: 0x008F3E14 File Offset: 0x008F2014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void VolumeSphereInWater(float in_h, FVector in_c, float in_r, ref float out_V, ref float out_SpheveV)
		{
			BP_WaterBuoyancy_C.__VolumeSphereInWater_FunctionParams* ptr = stackalloc BP_WaterBuoyancy_C.__VolumeSphereInWater_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_WaterBuoyancy_C.__VolumeSphereInWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancy_C.__VolumeSphereInWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->in_h = in_h;
			ptr->in_c = in_c;
			ptr->in_r = in_r;
			ptr->out_V = out_V;
			ptr->out_SpheveV = out_SpheveV;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__VolumeSphereInWater_NativeFunctionPtr, (void*)ptr);
			out_V = ptr->out_V;
			out_SpheveV = ptr->out_SpheveV;
		}

		// Token: 0x0601E5DE RID: 124382 RVA: 0x008F3E8F File Offset: 0x008F208F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5DF RID: 124383 RVA: 0x008F3EA3 File Offset: 0x008F20A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5E0 RID: 124384 RVA: 0x008F3EB8 File Offset: 0x008F20B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5E1 RID: 124385 RVA: 0x008F3ECC File Offset: 0x008F20CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5E2 RID: 124386 RVA: 0x008F3EE1 File Offset: 0x008F20E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5E3 RID: 124387 RVA: 0x008F3EF5 File Offset: 0x008F20F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5E4 RID: 124388 RVA: 0x008F3F0A File Offset: 0x008F210A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5E5 RID: 124389 RVA: 0x008F3F1E File Offset: 0x008F211E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5E6 RID: 124390 RVA: 0x008F3F34 File Offset: 0x008F2134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E5E7 RID: 124391 RVA: 0x008F3F7C File Offset: 0x008F217C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancy_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E5E8 RID: 124392 RVA: 0x008F3FC3 File Offset: 0x008F21C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnVisible()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnVisible_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5E9 RID: 124393 RVA: 0x008F3FD7 File Offset: 0x008F21D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnVisible_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnVisible_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5EA RID: 124394 RVA: 0x008F3FEC File Offset: 0x008F21EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnInvisible()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnInvisible_NativeFunctionPtr, null);
		}

		// Token: 0x0601E5EB RID: 124395 RVA: 0x008F4000 File Offset: 0x008F2200
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnInvisible_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__OnInvisible_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E5EC RID: 124396 RVA: 0x008F4018 File Offset: 0x008F2218
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterBuoyancy(int EntryPoint)
		{
			BP_WaterBuoyancy_C.__ExecuteUbergraph_BP_WaterBuoyancy_FunctionParams* ptr = stackalloc BP_WaterBuoyancy_C.__ExecuteUbergraph_BP_WaterBuoyancy_FunctionParams[(UIntPtr)967] + 15L / (long)sizeof(BP_WaterBuoyancy_C.__ExecuteUbergraph_BP_WaterBuoyancy_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancy_C.__ExecuteUbergraph_BP_WaterBuoyancy_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancy_C.__ExecuteUbergraph_BP_WaterBuoyancy_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E5ED RID: 124397 RVA: 0x008F4062 File Offset: 0x008F2262
		protected BP_WaterBuoyancy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EEE7 RID: 61159
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancy.BP_WaterBuoyancy_C";

		// Token: 0x0400EEE8 RID: 61160
		private static IntPtr _ClassPtr;

		// Token: 0x0400EEE9 RID: 61161
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EEEA RID: 61162
		internal static int __PropertyOffset_0;

		// Token: 0x0400EEEB RID: 61163
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EEEC RID: 61164
		internal static int __PropertyOffset_1;

		// Token: 0x0400EEED RID: 61165
		internal static int __PropertyOffset_2;

		// Token: 0x0400EEEE RID: 61166
		internal static int __PropertyOffset_3;

		// Token: 0x0400EEEF RID: 61167
		internal static int __PropertyOffset_4;

		// Token: 0x0400EEF0 RID: 61168
		private TArray<FVector4> _sphereList;

		// Token: 0x0400EEF1 RID: 61169
		internal static int __PropertyOffset_5;

		// Token: 0x0400EEF2 RID: 61170
		internal static int __PropertyOffset_6;

		// Token: 0x0400EEF3 RID: 61171
		internal static int __PropertyOffset_7;

		// Token: 0x0400EEF4 RID: 61172
		internal static int __PropertyOffset_8;

		// Token: 0x0400EEF5 RID: 61173
		internal static int __PropertyOffset_9;

		// Token: 0x0400EEF6 RID: 61174
		internal static int __PropertyOffset_10;

		// Token: 0x0400EEF7 RID: 61175
		internal static int __PropertyOffset_11;

		// Token: 0x0400EEF8 RID: 61176
		internal static int __PropertyOffset_12;

		// Token: 0x0400EEF9 RID: 61177
		internal static int __PropertyOffset_13;

		// Token: 0x0400EEFA RID: 61178
		internal static int __PropertyOffset_14;

		// Token: 0x0400EEFB RID: 61179
		internal static int __PropertyOffset_15;

		// Token: 0x0400EEFC RID: 61180
		internal static int __PropertyOffset_16;

		// Token: 0x0400EEFD RID: 61181
		private TArray<FVector> _RipplePointList;

		// Token: 0x0400EEFE RID: 61182
		internal static int __PropertyOffset_17;

		// Token: 0x0400EEFF RID: 61183
		internal static int __PropertyOffset_18;

		// Token: 0x0400EF00 RID: 61184
		internal static int __PropertyOffset_19;

		// Token: 0x0400EF01 RID: 61185
		internal static int __PropertyOffset_20;

		// Token: 0x0400EF02 RID: 61186
		internal static int __PropertyOffset_21;

		// Token: 0x0400EF03 RID: 61187
		internal static int __PropertyOffset_22;

		// Token: 0x0400EF04 RID: 61188
		internal static int __PropertyOffset_23;

		// Token: 0x0400EF05 RID: 61189
		internal static int __PropertyOffset_24;

		// Token: 0x0400EF06 RID: 61190
		internal static int __PropertyOffset_25;

		// Token: 0x0400EF07 RID: 61191
		internal static int __PropertyOffset_26;

		// Token: 0x0400EF08 RID: 61192
		internal static int __PropertyOffset_27;

		// Token: 0x0400EF09 RID: 61193
		internal static int __PropertyOffset_28;

		// Token: 0x0400EF0A RID: 61194
		internal static int __PropertyOffset_29;

		// Token: 0x0400EF0B RID: 61195
		internal static int __PropertyOffset_30;

		// Token: 0x0400EF0C RID: 61196
		internal static int __PropertyOffset_31;

		// Token: 0x0400EF0D RID: 61197
		internal static int __PropertyOffset_32;

		// Token: 0x0400EF0E RID: 61198
		internal static int __PropertyOffset_33;

		// Token: 0x0400EF0F RID: 61199
		internal static int __PropertyOffset_34;

		// Token: 0x0400EF10 RID: 61200
		internal static int __PropertyOffset_35;

		// Token: 0x0400EF11 RID: 61201
		internal static int __PropertyOffset_36;

		// Token: 0x0400EF12 RID: 61202
		private static IntPtr __WaterRipple_NativeFunctionPtr;

		// Token: 0x0400EF13 RID: 61203
		private static IntPtr __VolumeSphereInWater_NativeFunctionPtr;

		// Token: 0x0400EF14 RID: 61204
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EF15 RID: 61205
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EF16 RID: 61206
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400EF17 RID: 61207
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400EF18 RID: 61208
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EF19 RID: 61209
		private static IntPtr __OnVisible_NativeFunctionPtr;

		// Token: 0x0400EF1A RID: 61210
		private static IntPtr __OnInvisible_NativeFunctionPtr;

		// Token: 0x0400EF1B RID: 61211
		private static IntPtr __ExecuteUbergraph_BP_WaterBuoyancy_NativeFunctionPtr;

		// Token: 0x020097AB RID: 38827
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __VolumeSphereInWater_FunctionParams
		{
			// Token: 0x04031D7B RID: 204155
			[FieldOffset(0)]
			public float in_h;

			// Token: 0x04031D7C RID: 204156
			[FieldOffset(4)]
			public FVector in_c;

			// Token: 0x04031D7D RID: 204157
			[FieldOffset(16)]
			public float in_r;

			// Token: 0x04031D7E RID: 204158
			[FieldOffset(20)]
			public float out_V;

			// Token: 0x04031D7F RID: 204159
			[FieldOffset(24)]
			public float out_SpheveV;
		}

		// Token: 0x020097AC RID: 38828
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D80 RID: 204160
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097AD RID: 38829
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 952)]
		protected ref struct __ExecuteUbergraph_BP_WaterBuoyancy_FunctionParams
		{
			// Token: 0x04031D81 RID: 204161
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
