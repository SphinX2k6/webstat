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
	// Token: 0x02003C24 RID: 15396
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_FootballNet.BP_FootballNet_C")]
	[UnrealStructLayout(1664, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1657)]
	public class BP_FootballNet_C : AKuroCSRpbd, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023246 RID: 143942 RVA: 0x0097A08F File Offset: 0x0097828F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FootballNet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_FootballNet.BP_FootballNet_C");
			}
			return BP_FootballNet_C._ClassPtr;
		}

		// Token: 0x06023247 RID: 143943 RVA: 0x0097A0B4 File Offset: 0x009782B4
		public BP_FootballNet_C() : this(BuiltinUtils.AllocNativeUObject(BP_FootballNet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023248 RID: 143944 RVA: 0x0097A0DC File Offset: 0x009782DC
		[NullableContext(1)]
		public BP_FootballNet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FootballNet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170044A0 RID: 17568
		// (get) Token: 0x06023249 RID: 143945 RVA: 0x0097A110 File Offset: 0x00978310
		// (set) Token: 0x0602324A RID: 143946 RVA: 0x0097A149 File Offset: 0x00978349
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170044A1 RID: 17569
		// (get) Token: 0x0602324B RID: 143947 RVA: 0x0097A16A File Offset: 0x0097836A
		// (set) Token: 0x0602324C RID: 143948 RVA: 0x0097A17E File Offset: 0x0097837E
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170044A2 RID: 17570
		// (get) Token: 0x0602324D RID: 143949 RVA: 0x0097A193 File Offset: 0x00978393
		// (set) Token: 0x0602324E RID: 143950 RVA: 0x0097A1A7 File Offset: 0x009783A7
		public unsafe UStaticMeshComponent SM_Old_Flo_01AL_ST
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170044A3 RID: 17571
		// (get) Token: 0x0602324F RID: 143951 RVA: 0x0097A1BC File Offset: 0x009783BC
		// (set) Token: 0x06023250 RID: 143952 RVA: 0x0097A1D0 File Offset: 0x009783D0
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170044A4 RID: 17572
		// (get) Token: 0x06023251 RID: 143953 RVA: 0x0097A1E5 File Offset: 0x009783E5
		// (set) Token: 0x06023252 RID: 143954 RVA: 0x0097A1F9 File Offset: 0x009783F9
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170044A5 RID: 17573
		// (get) Token: 0x06023253 RID: 143955 RVA: 0x0097A20E File Offset: 0x0097840E
		// (set) Token: 0x06023254 RID: 143956 RVA: 0x0097A222 File Offset: 0x00978422
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170044A6 RID: 17574
		// (get) Token: 0x06023255 RID: 143957 RVA: 0x0097A237 File Offset: 0x00978437
		// (set) Token: 0x06023256 RID: 143958 RVA: 0x0097A24B File Offset: 0x0097844B
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170044A7 RID: 17575
		// (get) Token: 0x06023257 RID: 143959 RVA: 0x0097A260 File Offset: 0x00978460
		// (set) Token: 0x06023258 RID: 143960 RVA: 0x0097A274 File Offset: 0x00978474
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170044A8 RID: 17576
		// (get) Token: 0x06023259 RID: 143961 RVA: 0x0097A289 File Offset: 0x00978489
		// (set) Token: 0x0602325A RID: 143962 RVA: 0x0097A299 File Offset: 0x00978499
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044A9 RID: 17577
		// (get) Token: 0x0602325B RID: 143963 RVA: 0x0097A2AA File Offset: 0x009784AA
		// (set) Token: 0x0602325C RID: 143964 RVA: 0x0097A2BE File Offset: 0x009784BE
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170044AA RID: 17578
		// (get) Token: 0x0602325D RID: 143965 RVA: 0x0097A2D3 File Offset: 0x009784D3
		// (set) Token: 0x0602325E RID: 143966 RVA: 0x0097A2E3 File Offset: 0x009784E3
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170044AB RID: 17579
		// (get) Token: 0x0602325F RID: 143967 RVA: 0x0097A2F4 File Offset: 0x009784F4
		// (set) Token: 0x06023260 RID: 143968 RVA: 0x0097A304 File Offset: 0x00978504
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044AC RID: 17580
		// (get) Token: 0x06023261 RID: 143969 RVA: 0x0097A315 File Offset: 0x00978515
		// (set) Token: 0x06023262 RID: 143970 RVA: 0x0097A325 File Offset: 0x00978525
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044AD RID: 17581
		// (get) Token: 0x06023263 RID: 143971 RVA: 0x0097A336 File Offset: 0x00978536
		// (set) Token: 0x06023264 RID: 143972 RVA: 0x0097A346 File Offset: 0x00978546
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170044AE RID: 17582
		// (get) Token: 0x06023265 RID: 143973 RVA: 0x0097A357 File Offset: 0x00978557
		// (set) Token: 0x06023266 RID: 143974 RVA: 0x0097A367 File Offset: 0x00978567
		public unsafe bool editorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044AF RID: 17583
		// (get) Token: 0x06023267 RID: 143975 RVA: 0x0097A378 File Offset: 0x00978578
		// (set) Token: 0x06023268 RID: 143976 RVA: 0x0097A388 File Offset: 0x00978588
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044B0 RID: 17584
		// (get) Token: 0x06023269 RID: 143977 RVA: 0x0097A399 File Offset: 0x00978599
		// (set) Token: 0x0602326A RID: 143978 RVA: 0x0097A3A9 File Offset: 0x009785A9
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170044B1 RID: 17585
		// (get) Token: 0x0602326B RID: 143979 RVA: 0x0097A3BA File Offset: 0x009785BA
		// (set) Token: 0x0602326C RID: 143980 RVA: 0x0097A3CA File Offset: 0x009785CA
		public unsafe bool ReadFromBPL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044B2 RID: 17586
		// (get) Token: 0x0602326D RID: 143981 RVA: 0x0097A3DB File Offset: 0x009785DB
		// (set) Token: 0x0602326E RID: 143982 RVA: 0x0097A3EF File Offset: 0x009785EF
		public unsafe UStaticMesh inputStaticMesh_ForBPL_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170044B3 RID: 17587
		// (get) Token: 0x0602326F RID: 143983 RVA: 0x0097A404 File Offset: 0x00978604
		// (set) Token: 0x06023270 RID: 143984 RVA: 0x0097A414 File Offset: 0x00978614
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044B4 RID: 17588
		// (get) Token: 0x06023271 RID: 143985 RVA: 0x0097A425 File Offset: 0x00978625
		// (set) Token: 0x06023272 RID: 143986 RVA: 0x0097A439 File Offset: 0x00978639
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170044B5 RID: 17589
		// (get) Token: 0x06023273 RID: 143987 RVA: 0x0097A44E File Offset: 0x0097864E
		// (set) Token: 0x06023274 RID: 143988 RVA: 0x0097A462 File Offset: 0x00978662
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FootballNet_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170044B6 RID: 17590
		// (get) Token: 0x06023275 RID: 143989 RVA: 0x0097A477 File Offset: 0x00978677
		// (set) Token: 0x06023276 RID: 143990 RVA: 0x0097A487 File Offset: 0x00978687
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044B7 RID: 17591
		// (get) Token: 0x06023277 RID: 143991 RVA: 0x0097A498 File Offset: 0x00978698
		// (set) Token: 0x06023278 RID: 143992 RVA: 0x0097A4A8 File Offset: 0x009786A8
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044B8 RID: 17592
		// (get) Token: 0x06023279 RID: 143993 RVA: 0x0097A4B9 File Offset: 0x009786B9
		// (set) Token: 0x0602327A RID: 143994 RVA: 0x0097A4C9 File Offset: 0x009786C9
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170044B9 RID: 17593
		// (get) Token: 0x0602327B RID: 143995 RVA: 0x0097A4DA File Offset: 0x009786DA
		// (set) Token: 0x0602327C RID: 143996 RVA: 0x0097A4EE File Offset: 0x009786EE
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170044BA RID: 17594
		// (get) Token: 0x0602327D RID: 143997 RVA: 0x0097A503 File Offset: 0x00978703
		// (set) Token: 0x0602327E RID: 143998 RVA: 0x0097A517 File Offset: 0x00978717
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170044BB RID: 17595
		// (get) Token: 0x0602327F RID: 143999 RVA: 0x0097A52C File Offset: 0x0097872C
		// (set) Token: 0x06023280 RID: 144000 RVA: 0x0097A53C File Offset: 0x0097873C
		public unsafe bool d1024
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FootballNet_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023281 RID: 144001 RVA: 0x0097A54D File Offset: 0x0097874D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023282 RID: 144002 RVA: 0x0097A561 File Offset: 0x00978761
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FootballNet_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023283 RID: 144003 RVA: 0x0097A576 File Offset: 0x00978776
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023284 RID: 144004 RVA: 0x0097A58A File Offset: 0x0097878A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023285 RID: 144005 RVA: 0x0097A5A0 File Offset: 0x009787A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FootballNet_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FootballNet_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FootballNet_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023286 RID: 144006 RVA: 0x0097A5E8 File Offset: 0x009787E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FootballNet_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FootballNet_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FootballNet_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023287 RID: 144007 RVA: 0x0097A630 File Offset: 0x00978830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_FootballNet_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_FootballNet_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_FootballNet_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023288 RID: 144008 RVA: 0x0097A67C File Offset: 0x0097887C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_FootballNet_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_FootballNet_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_FootballNet_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FootballNet_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023289 RID: 144009 RVA: 0x0097A6C8 File Offset: 0x009788C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_FootballNet_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FootballNet_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FootballNet_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602328A RID: 144010 RVA: 0x0097A77C File Offset: 0x0097897C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602328B RID: 144011 RVA: 0x0097A838 File Offset: 0x00978A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602328C RID: 144012 RVA: 0x0097A8C4 File Offset: 0x00978AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_FootballNet_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_FootballNet_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_FootballNet_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FootballNet_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602328D RID: 144013 RVA: 0x0097A928 File Offset: 0x00978B28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FootballNet(int EntryPoint)
		{
			BP_FootballNet_C.__ExecuteUbergraph_BP_FootballNet_FunctionParams* ptr = stackalloc BP_FootballNet_C.__ExecuteUbergraph_BP_FootballNet_FunctionParams[(UIntPtr)1871] + 15L / (long)sizeof(BP_FootballNet_C.__ExecuteUbergraph_BP_FootballNet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FootballNet_C.__ExecuteUbergraph_BP_FootballNet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FootballNet_C.__ExecuteUbergraph_BP_FootballNet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602328E RID: 144014 RVA: 0x0097A972 File Offset: 0x00978B72
		protected BP_FootballNet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011DED RID: 73197
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_FootballNet.BP_FootballNet_C";

		// Token: 0x04011DEE RID: 73198
		private static IntPtr _ClassPtr;

		// Token: 0x04011DEF RID: 73199
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011DF0 RID: 73200
		internal static int __PropertyOffset_0;

		// Token: 0x04011DF1 RID: 73201
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011DF2 RID: 73202
		internal static int __PropertyOffset_1;

		// Token: 0x04011DF3 RID: 73203
		internal static int __PropertyOffset_2;

		// Token: 0x04011DF4 RID: 73204
		internal static int __PropertyOffset_3;

		// Token: 0x04011DF5 RID: 73205
		internal static int __PropertyOffset_4;

		// Token: 0x04011DF6 RID: 73206
		internal static int __PropertyOffset_5;

		// Token: 0x04011DF7 RID: 73207
		internal static int __PropertyOffset_6;

		// Token: 0x04011DF8 RID: 73208
		internal static int __PropertyOffset_7;

		// Token: 0x04011DF9 RID: 73209
		internal static int __PropertyOffset_8;

		// Token: 0x04011DFA RID: 73210
		internal static int __PropertyOffset_9;

		// Token: 0x04011DFB RID: 73211
		internal static int __PropertyOffset_10;

		// Token: 0x04011DFC RID: 73212
		internal static int __PropertyOffset_11;

		// Token: 0x04011DFD RID: 73213
		internal static int __PropertyOffset_12;

		// Token: 0x04011DFE RID: 73214
		internal static int __PropertyOffset_13;

		// Token: 0x04011DFF RID: 73215
		internal static int __PropertyOffset_14;

		// Token: 0x04011E00 RID: 73216
		internal static int __PropertyOffset_15;

		// Token: 0x04011E01 RID: 73217
		internal static int __PropertyOffset_16;

		// Token: 0x04011E02 RID: 73218
		internal static int __PropertyOffset_17;

		// Token: 0x04011E03 RID: 73219
		internal static int __PropertyOffset_18;

		// Token: 0x04011E04 RID: 73220
		internal static int __PropertyOffset_19;

		// Token: 0x04011E05 RID: 73221
		internal static int __PropertyOffset_20;

		// Token: 0x04011E06 RID: 73222
		internal static int __PropertyOffset_21;

		// Token: 0x04011E07 RID: 73223
		internal static int __PropertyOffset_22;

		// Token: 0x04011E08 RID: 73224
		internal static int __PropertyOffset_23;

		// Token: 0x04011E09 RID: 73225
		internal static int __PropertyOffset_24;

		// Token: 0x04011E0A RID: 73226
		internal static int __PropertyOffset_25;

		// Token: 0x04011E0B RID: 73227
		internal static int __PropertyOffset_26;

		// Token: 0x04011E0C RID: 73228
		internal static int __PropertyOffset_27;

		// Token: 0x04011E0D RID: 73229
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011E0E RID: 73230
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011E0F RID: 73231
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011E10 RID: 73232
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011E11 RID: 73233
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E12 RID: 73234
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E13 RID: 73235
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E14 RID: 73236
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011E15 RID: 73237
		private static IntPtr __ExecuteUbergraph_BP_FootballNet_NativeFunctionPtr;

		// Token: 0x02009C9D RID: 40093
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040325C7 RID: 206279
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C9E RID: 40094
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040325C8 RID: 206280
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C9F RID: 40095
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325C9 RID: 206281
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040325CA RID: 206282
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325CB RID: 206283
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325CC RID: 206284
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040325CD RID: 206285
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009CA0 RID: 40096
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325CE RID: 206286
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325CF RID: 206287
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325D0 RID: 206288
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325D1 RID: 206289
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040325D2 RID: 206290
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040325D3 RID: 206291
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CA1 RID: 40097
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325D4 RID: 206292
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325D5 RID: 206293
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325D6 RID: 206294
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325D7 RID: 206295
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CA2 RID: 40098
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040325D8 RID: 206296
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040325D9 RID: 206297
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040325DA RID: 206298
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009CA3 RID: 40099
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1856)]
		protected ref struct __ExecuteUbergraph_BP_FootballNet_FunctionParams
		{
			// Token: 0x040325DB RID: 206299
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
