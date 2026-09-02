using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A0C RID: 14860
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyPanel.BP_WaterBuoyancyPanel_C")]
	[UnrealStructLayout(1272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1265)]
	public class BP_WaterBuoyancyPanel_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E549 RID: 124233 RVA: 0x008F315F File Offset: 0x008F135F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterBuoyancyPanel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyPanel.BP_WaterBuoyancyPanel_C");
			}
			return BP_WaterBuoyancyPanel_C._ClassPtr;
		}

		// Token: 0x0601E54A RID: 124234 RVA: 0x008F3184 File Offset: 0x008F1384
		public BP_WaterBuoyancyPanel_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancyPanel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E54B RID: 124235 RVA: 0x008F31AC File Offset: 0x008F13AC
		[NullableContext(1)]
		public BP_WaterBuoyancyPanel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancyPanel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029A2 RID: 10658
		// (get) Token: 0x0601E54C RID: 124236 RVA: 0x008F31E0 File Offset: 0x008F13E0
		// (set) Token: 0x0601E54D RID: 124237 RVA: 0x008F3219 File Offset: 0x008F1419
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170029A3 RID: 10659
		// (get) Token: 0x0601E54E RID: 124238 RVA: 0x008F323A File Offset: 0x008F143A
		// (set) Token: 0x0601E54F RID: 124239 RVA: 0x008F324E File Offset: 0x008F144E
		public unsafe UStaticMeshComponent PhysicsMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170029A4 RID: 10660
		// (get) Token: 0x0601E550 RID: 124240 RVA: 0x008F3263 File Offset: 0x008F1463
		// (set) Token: 0x0601E551 RID: 124241 RVA: 0x008F3277 File Offset: 0x008F1477
		public unsafe UStaticMeshComponent BlackMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170029A5 RID: 10661
		// (get) Token: 0x0601E552 RID: 124242 RVA: 0x008F328C File Offset: 0x008F148C
		// (set) Token: 0x0601E553 RID: 124243 RVA: 0x008F32A0 File Offset: 0x008F14A0
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170029A6 RID: 10662
		// (get) Token: 0x0601E554 RID: 124244 RVA: 0x008F32B5 File Offset: 0x008F14B5
		// (set) Token: 0x0601E555 RID: 124245 RVA: 0x008F32C9 File Offset: 0x008F14C9
		public unsafe UStaticMesh BuoyancyPanelStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyPanel_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170029A7 RID: 10663
		// (get) Token: 0x0601E556 RID: 124246 RVA: 0x008F32E0 File Offset: 0x008F14E0
		// (set) Token: 0x0601E557 RID: 124247 RVA: 0x008F3319 File Offset: 0x008F1519
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
					result = (this._sphereList = new TArray<FVector4>(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.sphereList.CopyAssign(value);
			}
		}

		// Token: 0x170029A8 RID: 10664
		// (get) Token: 0x0601E558 RID: 124248 RVA: 0x008F3327 File Offset: 0x008F1527
		// (set) Token: 0x0601E559 RID: 124249 RVA: 0x008F3337 File Offset: 0x008F1537
		public unsafe float BuoyancyIntersity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170029A9 RID: 10665
		// (get) Token: 0x0601E55A RID: 124250 RVA: 0x008F3348 File Offset: 0x008F1548
		// (set) Token: 0x0601E55B RID: 124251 RVA: 0x008F3358 File Offset: 0x008F1558
		public unsafe double BuoyancyRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170029AA RID: 10666
		// (get) Token: 0x0601E55C RID: 124252 RVA: 0x008F3369 File Offset: 0x008F1569
		// (set) Token: 0x0601E55D RID: 124253 RVA: 0x008F3379 File Offset: 0x008F1579
		public unsafe float WaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170029AB RID: 10667
		// (get) Token: 0x0601E55E RID: 124254 RVA: 0x008F338A File Offset: 0x008F158A
		// (set) Token: 0x0601E55F RID: 124255 RVA: 0x008F339A File Offset: 0x008F159A
		public unsafe float StaticHeightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170029AC RID: 10668
		// (get) Token: 0x0601E560 RID: 124256 RVA: 0x008F33AB File Offset: 0x008F15AB
		// (set) Token: 0x0601E561 RID: 124257 RVA: 0x008F33BB File Offset: 0x008F15BB
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170029AD RID: 10669
		// (get) Token: 0x0601E562 RID: 124258 RVA: 0x008F33CC File Offset: 0x008F15CC
		// (set) Token: 0x0601E563 RID: 124259 RVA: 0x008F33DC File Offset: 0x008F15DC
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170029AE RID: 10670
		// (get) Token: 0x0601E564 RID: 124260 RVA: 0x008F33ED File Offset: 0x008F15ED
		// (set) Token: 0x0601E565 RID: 124261 RVA: 0x008F33FD File Offset: 0x008F15FD
		public unsafe float LinearDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170029AF RID: 10671
		// (get) Token: 0x0601E566 RID: 124262 RVA: 0x008F340E File Offset: 0x008F160E
		// (set) Token: 0x0601E567 RID: 124263 RVA: 0x008F341E File Offset: 0x008F161E
		public unsafe float AngularDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170029B0 RID: 10672
		// (get) Token: 0x0601E568 RID: 124264 RVA: 0x008F342F File Offset: 0x008F162F
		// (set) Token: 0x0601E569 RID: 124265 RVA: 0x008F343F File Offset: 0x008F163F
		public unsafe float MinDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170029B1 RID: 10673
		// (get) Token: 0x0601E56A RID: 124266 RVA: 0x008F3450 File Offset: 0x008F1650
		// (set) Token: 0x0601E56B RID: 124267 RVA: 0x008F3460 File Offset: 0x008F1660
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170029B2 RID: 10674
		// (get) Token: 0x0601E56C RID: 124268 RVA: 0x008F3471 File Offset: 0x008F1671
		// (set) Token: 0x0601E56D RID: 124269 RVA: 0x008F3481 File Offset: 0x008F1681
		public unsafe float TempWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170029B3 RID: 10675
		// (get) Token: 0x0601E56E RID: 124270 RVA: 0x008F3492 File Offset: 0x008F1692
		// (set) Token: 0x0601E56F RID: 124271 RVA: 0x008F34A2 File Offset: 0x008F16A2
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170029B4 RID: 10676
		// (get) Token: 0x0601E570 RID: 124272 RVA: 0x008F34B3 File Offset: 0x008F16B3
		// (set) Token: 0x0601E571 RID: 124273 RVA: 0x008F34C7 File Offset: 0x008F16C7
		public unsafe FVectorDouble offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170029B5 RID: 10677
		// (get) Token: 0x0601E572 RID: 124274 RVA: 0x008F34DC File Offset: 0x008F16DC
		// (set) Token: 0x0601E573 RID: 124275 RVA: 0x008F34EC File Offset: 0x008F16EC
		public unsafe double dis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170029B6 RID: 10678
		// (get) Token: 0x0601E574 RID: 124276 RVA: 0x008F34FD File Offset: 0x008F16FD
		// (set) Token: 0x0601E575 RID: 124277 RVA: 0x008F350D File Offset: 0x008F170D
		public unsafe float PlayerImpulseLerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170029B7 RID: 10679
		// (get) Token: 0x0601E576 RID: 124278 RVA: 0x008F351E File Offset: 0x008F171E
		// (set) Token: 0x0601E577 RID: 124279 RVA: 0x008F352E File Offset: 0x008F172E
		public unsafe float LerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170029B8 RID: 10680
		// (get) Token: 0x0601E578 RID: 124280 RVA: 0x008F353F File Offset: 0x008F173F
		// (set) Token: 0x0601E579 RID: 124281 RVA: 0x008F354F File Offset: 0x008F174F
		public unsafe double DistforPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170029B9 RID: 10681
		// (get) Token: 0x0601E57A RID: 124282 RVA: 0x008F3560 File Offset: 0x008F1760
		// (set) Token: 0x0601E57B RID: 124283 RVA: 0x008F3574 File Offset: 0x008F1774
		public unsafe FVectorDouble MeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170029BA RID: 10682
		// (get) Token: 0x0601E57C RID: 124284 RVA: 0x008F3589 File Offset: 0x008F1789
		// (set) Token: 0x0601E57D RID: 124285 RVA: 0x008F359D File Offset: 0x008F179D
		public unsafe FVectorDouble PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170029BB RID: 10683
		// (get) Token: 0x0601E57E RID: 124286 RVA: 0x008F35B2 File Offset: 0x008F17B2
		// (set) Token: 0x0601E57F RID: 124287 RVA: 0x008F35C2 File Offset: 0x008F17C2
		public unsafe float MeshBoundRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170029BC RID: 10684
		// (get) Token: 0x0601E580 RID: 124288 RVA: 0x008F35D3 File Offset: 0x008F17D3
		// (set) Token: 0x0601E581 RID: 124289 RVA: 0x008F35E3 File Offset: 0x008F17E3
		public unsafe double X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170029BD RID: 10685
		// (get) Token: 0x0601E582 RID: 124290 RVA: 0x008F35F4 File Offset: 0x008F17F4
		// (set) Token: 0x0601E583 RID: 124291 RVA: 0x008F3604 File Offset: 0x008F1804
		public unsafe double Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170029BE RID: 10686
		// (get) Token: 0x0601E584 RID: 124292 RVA: 0x008F3615 File Offset: 0x008F1815
		// (set) Token: 0x0601E585 RID: 124293 RVA: 0x008F3625 File Offset: 0x008F1825
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyPanel_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E586 RID: 124294 RVA: 0x008F3638 File Offset: 0x008F1838
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void VolumeSphereInWater(float in_h, FVector in_c, float in_r, ref float out_V, ref float out_SpheveV)
		{
			BP_WaterBuoyancyPanel_C.__VolumeSphereInWater_FunctionParams* ptr = stackalloc BP_WaterBuoyancyPanel_C.__VolumeSphereInWater_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_WaterBuoyancyPanel_C.__VolumeSphereInWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyPanel_C.__VolumeSphereInWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->in_h = in_h;
			ptr->in_c = in_c;
			ptr->in_r = in_r;
			ptr->out_V = out_V;
			ptr->out_SpheveV = out_SpheveV;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__VolumeSphereInWater_NativeFunctionPtr, (void*)ptr);
			out_V = ptr->out_V;
			out_SpheveV = ptr->out_SpheveV;
		}

		// Token: 0x0601E587 RID: 124295 RVA: 0x008F36B3 File Offset: 0x008F18B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E588 RID: 124296 RVA: 0x008F36C7 File Offset: 0x008F18C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E589 RID: 124297 RVA: 0x008F36DC File Offset: 0x008F18DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyPanel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E58A RID: 124298 RVA: 0x008F3724 File Offset: 0x008F1924
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancyPanel_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyPanel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E58B RID: 124299 RVA: 0x008F376B File Offset: 0x008F196B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E58C RID: 124300 RVA: 0x008F377F File Offset: 0x008F197F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E58D RID: 124301 RVA: 0x008F3794 File Offset: 0x008F1994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterBuoyancyPanel(int EntryPoint)
		{
			BP_WaterBuoyancyPanel_C.__ExecuteUbergraph_BP_WaterBuoyancyPanel_FunctionParams* ptr = stackalloc BP_WaterBuoyancyPanel_C.__ExecuteUbergraph_BP_WaterBuoyancyPanel_FunctionParams[(UIntPtr)1007] + 15L / (long)sizeof(BP_WaterBuoyancyPanel_C.__ExecuteUbergraph_BP_WaterBuoyancyPanel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyPanel_C.__ExecuteUbergraph_BP_WaterBuoyancyPanel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyPanel_C.__ExecuteUbergraph_BP_WaterBuoyancyPanel_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E58E RID: 124302 RVA: 0x008F37DE File Offset: 0x008F19DE
		protected BP_WaterBuoyancyPanel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EEC0 RID: 61120
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyPanel.BP_WaterBuoyancyPanel_C";

		// Token: 0x0400EEC1 RID: 61121
		private static IntPtr _ClassPtr;

		// Token: 0x0400EEC2 RID: 61122
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EEC3 RID: 61123
		internal static int __PropertyOffset_0;

		// Token: 0x0400EEC4 RID: 61124
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EEC5 RID: 61125
		internal static int __PropertyOffset_1;

		// Token: 0x0400EEC6 RID: 61126
		internal static int __PropertyOffset_2;

		// Token: 0x0400EEC7 RID: 61127
		internal static int __PropertyOffset_3;

		// Token: 0x0400EEC8 RID: 61128
		internal static int __PropertyOffset_4;

		// Token: 0x0400EEC9 RID: 61129
		internal static int __PropertyOffset_5;

		// Token: 0x0400EECA RID: 61130
		private TArray<FVector4> _sphereList;

		// Token: 0x0400EECB RID: 61131
		internal static int __PropertyOffset_6;

		// Token: 0x0400EECC RID: 61132
		internal static int __PropertyOffset_7;

		// Token: 0x0400EECD RID: 61133
		internal static int __PropertyOffset_8;

		// Token: 0x0400EECE RID: 61134
		internal static int __PropertyOffset_9;

		// Token: 0x0400EECF RID: 61135
		internal static int __PropertyOffset_10;

		// Token: 0x0400EED0 RID: 61136
		internal static int __PropertyOffset_11;

		// Token: 0x0400EED1 RID: 61137
		internal static int __PropertyOffset_12;

		// Token: 0x0400EED2 RID: 61138
		internal static int __PropertyOffset_13;

		// Token: 0x0400EED3 RID: 61139
		internal static int __PropertyOffset_14;

		// Token: 0x0400EED4 RID: 61140
		internal static int __PropertyOffset_15;

		// Token: 0x0400EED5 RID: 61141
		internal static int __PropertyOffset_16;

		// Token: 0x0400EED6 RID: 61142
		internal static int __PropertyOffset_17;

		// Token: 0x0400EED7 RID: 61143
		internal static int __PropertyOffset_18;

		// Token: 0x0400EED8 RID: 61144
		internal static int __PropertyOffset_19;

		// Token: 0x0400EED9 RID: 61145
		internal static int __PropertyOffset_20;

		// Token: 0x0400EEDA RID: 61146
		internal static int __PropertyOffset_21;

		// Token: 0x0400EEDB RID: 61147
		internal static int __PropertyOffset_22;

		// Token: 0x0400EEDC RID: 61148
		internal static int __PropertyOffset_23;

		// Token: 0x0400EEDD RID: 61149
		internal static int __PropertyOffset_24;

		// Token: 0x0400EEDE RID: 61150
		internal static int __PropertyOffset_25;

		// Token: 0x0400EEDF RID: 61151
		internal static int __PropertyOffset_26;

		// Token: 0x0400EEE0 RID: 61152
		internal static int __PropertyOffset_27;

		// Token: 0x0400EEE1 RID: 61153
		internal static int __PropertyOffset_28;

		// Token: 0x0400EEE2 RID: 61154
		private static IntPtr __VolumeSphereInWater_NativeFunctionPtr;

		// Token: 0x0400EEE3 RID: 61155
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EEE4 RID: 61156
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EEE5 RID: 61157
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EEE6 RID: 61158
		private static IntPtr __ExecuteUbergraph_BP_WaterBuoyancyPanel_NativeFunctionPtr;

		// Token: 0x020097A8 RID: 38824
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __VolumeSphereInWater_FunctionParams
		{
			// Token: 0x04031D74 RID: 204148
			[FieldOffset(0)]
			public float in_h;

			// Token: 0x04031D75 RID: 204149
			[FieldOffset(4)]
			public FVector in_c;

			// Token: 0x04031D76 RID: 204150
			[FieldOffset(16)]
			public float in_r;

			// Token: 0x04031D77 RID: 204151
			[FieldOffset(20)]
			public float out_V;

			// Token: 0x04031D78 RID: 204152
			[FieldOffset(24)]
			public float out_SpheveV;
		}

		// Token: 0x020097A9 RID: 38825
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D79 RID: 204153
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097AA RID: 38826
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 992)]
		protected ref struct __ExecuteUbergraph_BP_WaterBuoyancyPanel_FunctionParams
		{
			// Token: 0x04031D7A RID: 204154
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
