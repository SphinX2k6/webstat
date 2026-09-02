using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F8 RID: 14840
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirds.BP_YangYangBirds_C")]
	[UnrealStructLayout(1424, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1424)]
	public class BP_YangYangBirds_C : AKuroYangYangBirds, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E2B1 RID: 123569 RVA: 0x008EE534 File Offset: 0x008EC734
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_YangYangBirds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirds.BP_YangYangBirds_C");
			}
			return BP_YangYangBirds_C._ClassPtr;
		}

		// Token: 0x0601E2B2 RID: 123570 RVA: 0x008EE558 File Offset: 0x008EC758
		public BP_YangYangBirds_C() : this(BuiltinUtils.AllocNativeUObject(BP_YangYangBirds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E2B3 RID: 123571 RVA: 0x008EE580 File Offset: 0x008EC780
		[NullableContext(1)]
		public BP_YangYangBirds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_YangYangBirds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028CB RID: 10443
		// (get) Token: 0x0601E2B4 RID: 123572 RVA: 0x008EE5B4 File Offset: 0x008EC7B4
		// (set) Token: 0x0601E2B5 RID: 123573 RVA: 0x008EE5ED File Offset: 0x008EC7ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028CC RID: 10444
		// (get) Token: 0x0601E2B6 RID: 123574 RVA: 0x008EE60E File Offset: 0x008EC80E
		// (set) Token: 0x0601E2B7 RID: 123575 RVA: 0x008EE61E File Offset: 0x008EC81E
		public unsafe float CharFrightenStrengthMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170028CD RID: 10445
		// (get) Token: 0x0601E2B8 RID: 123576 RVA: 0x008EE62F File Offset: 0x008EC82F
		// (set) Token: 0x0601E2B9 RID: 123577 RVA: 0x008EE63F File Offset: 0x008EC83F
		public unsafe float FrightenRadiusFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170028CE RID: 10446
		// (get) Token: 0x0601E2BA RID: 123578 RVA: 0x008EE650 File Offset: 0x008EC850
		// (set) Token: 0x0601E2BB RID: 123579 RVA: 0x008EE660 File Offset: 0x008EC860
		public unsafe float CharFrightenStrengthFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170028CF RID: 10447
		// (get) Token: 0x0601E2BC RID: 123580 RVA: 0x008EE671 File Offset: 0x008EC871
		// (set) Token: 0x0601E2BD RID: 123581 RVA: 0x008EE681 File Offset: 0x008EC881
		public unsafe bool PendingDisappear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028D0 RID: 10448
		// (get) Token: 0x0601E2BE RID: 123582 RVA: 0x008EE694 File Offset: 0x008EC894
		// (set) Token: 0x0601E2BF RID: 123583 RVA: 0x008EE6CD File Offset: 0x008EC8CD
		[Nullable(1)]
		public TMap<int, SYYBirdWeaponItem> WeaponItems
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<int, SYYBirdWeaponItem> result;
				if ((result = this._WeaponItems) == null)
				{
					result = (this._WeaponItems = new TMap<int, SYYBirdWeaponItem>(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.WeaponItems.CopyAssign(value);
			}
		}

		// Token: 0x170028D1 RID: 10449
		// (get) Token: 0x0601E2C0 RID: 123584 RVA: 0x008EE6DB File Offset: 0x008EC8DB
		// (set) Token: 0x0601E2C1 RID: 123585 RVA: 0x008EE6EF File Offset: 0x008EC8EF
		public unsafe FVector4 WeaponImpactionRangeMap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170028D2 RID: 10450
		// (get) Token: 0x0601E2C2 RID: 123586 RVA: 0x008EE704 File Offset: 0x008EC904
		// (set) Token: 0x0601E2C3 RID: 123587 RVA: 0x008EE714 File Offset: 0x008EC914
		public unsafe float FadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170028D3 RID: 10451
		// (get) Token: 0x0601E2C4 RID: 123588 RVA: 0x008EE725 File Offset: 0x008EC925
		// (set) Token: 0x0601E2C5 RID: 123589 RVA: 0x008EE739 File Offset: 0x008EC939
		public unsafe FVectorDouble LastActorLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170028D4 RID: 10452
		// (get) Token: 0x0601E2C6 RID: 123590 RVA: 0x008EE74E File Offset: 0x008EC94E
		// (set) Token: 0x0601E2C7 RID: 123591 RVA: 0x008EE75E File Offset: 0x008EC95E
		public unsafe float LastActorTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170028D5 RID: 10453
		// (get) Token: 0x0601E2C8 RID: 123592 RVA: 0x008EE76F File Offset: 0x008EC96F
		// (set) Token: 0x0601E2C9 RID: 123593 RVA: 0x008EE783 File Offset: 0x008EC983
		[Nullable(2)]
		public unsafe USceneComponent FollowComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirds_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirds_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170028D6 RID: 10454
		// (get) Token: 0x0601E2CA RID: 123594 RVA: 0x008EE798 File Offset: 0x008EC998
		// (set) Token: 0x0601E2CB RID: 123595 RVA: 0x008EE7D1 File Offset: 0x008EC9D1
		[Nullable(1)]
		public FKuroYangYangBirdsFrightenPoint DebugFrightenInfo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroYangYangBirdsFrightenPoint result;
				if ((result = this._DebugFrightenInfo) == null)
				{
					result = (this._DebugFrightenInfo = new FKuroYangYangBirdsFrightenPoint(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroYangYangBirdsFrightenPoint.StaticStruct(), base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028D7 RID: 10455
		// (get) Token: 0x0601E2CC RID: 123596 RVA: 0x008EE7F2 File Offset: 0x008EC9F2
		// (set) Token: 0x0601E2CD RID: 123597 RVA: 0x008EE802 File Offset: 0x008ECA02
		public unsafe bool Failed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YangYangBirds_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170028D8 RID: 10456
		// (get) Token: 0x0601E2CE RID: 123598 RVA: 0x008EE813 File Offset: 0x008ECA13
		// (set) Token: 0x0601E2CF RID: 123599 RVA: 0x008EE827 File Offset: 0x008ECA27
		[Nullable(2)]
		public unsafe UStaticMesh staticmesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirds_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangYangBirds_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x0601E2D0 RID: 123600 RVA: 0x008EE83C File Offset: 0x008ECA3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool ShouldDisappear()
		{
			BP_YangYangBirds_C.__ShouldDisappear_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldDisappear_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldDisappear_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldDisappear_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldDisappear_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E2D1 RID: 123601 RVA: 0x008EE884 File Offset: 0x008ECA84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool ShouldDisappear_Implementation()
		{
			BP_YangYangBirds_C.__ShouldDisappear_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldDisappear_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldDisappear_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldDisappear_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldDisappear_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E2D2 RID: 123602 RVA: 0x008EE8CA File Offset: 0x008ECACA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MarkPendingDisappear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__MarkPendingDisappear_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2D3 RID: 123603 RVA: 0x008EE8DE File Offset: 0x008ECADE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugFrighten()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__DebugFrighten_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2D4 RID: 123604 RVA: 0x008EE8F4 File Offset: 0x008ECAF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateFrighten(float DeltaTime)
		{
			BP_YangYangBirds_C.__UpdateFrighten_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__UpdateFrighten_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_YangYangBirds_C.__UpdateFrighten_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__UpdateFrighten_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__UpdateFrighten_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E2D5 RID: 123605 RVA: 0x008EE940 File Offset: 0x008ECB40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool ShouldTakeOff()
		{
			BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldTakeOff_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldTakeOff_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E2D6 RID: 123606 RVA: 0x008EE988 File Offset: 0x008ECB88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool ShouldTakeOff_Implementation()
		{
			BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldTakeOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldTakeOff_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldTakeOff_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E2D7 RID: 123607 RVA: 0x008EE9D0 File Offset: 0x008ECBD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool ShouldLand()
		{
			BP_YangYangBirds_C.__ShouldLand_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldLand_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldLand_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldLand_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldLand_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E2D8 RID: 123608 RVA: 0x008EEA18 File Offset: 0x008ECC18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool ShouldLand_Implementation()
		{
			BP_YangYangBirds_C.__ShouldLand_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldLand_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldLand_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldLand_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldLand_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E2D9 RID: 123609 RVA: 0x008EEA60 File Offset: 0x008ECC60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool ShouldAppear()
		{
			BP_YangYangBirds_C.__ShouldAppear_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldAppear_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldAppear_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldAppear_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldAppear_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E2DA RID: 123610 RVA: 0x008EEAA8 File Offset: 0x008ECCA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool ShouldAppear_Implementation()
		{
			BP_YangYangBirds_C.__ShouldAppear_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ShouldAppear_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_YangYangBirds_C.__ShouldAppear_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ShouldAppear_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ShouldAppear_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E2DB RID: 123611 RVA: 0x008EEAEE File Offset: 0x008ECCEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UpdateInterestPointGround()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__UpdateInterestPointGround_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2DC RID: 123612 RVA: 0x008EEB02 File Offset: 0x008ECD02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UpdateInterestPointGround_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__UpdateInterestPointGround_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E2DD RID: 123613 RVA: 0x008EEB17 File Offset: 0x008ECD17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UpdateInterestPointAir()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__UpdateInterestPointAir_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2DE RID: 123614 RVA: 0x008EEB2B File Offset: 0x008ECD2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UpdateInterestPointAir_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__UpdateInterestPointAir_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E2DF RID: 123615 RVA: 0x008EEB40 File Offset: 0x008ECD40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_YangYangBirds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E2E0 RID: 123616 RVA: 0x008EEB88 File Offset: 0x008ECD88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_YangYangBirds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangYangBirds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2E1 RID: 123617 RVA: 0x008EEBCF File Offset: 0x008ECDCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2E2 RID: 123618 RVA: 0x008EEBE3 File Offset: 0x008ECDE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E2E3 RID: 123619 RVA: 0x008EEBF8 File Offset: 0x008ECDF8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CustomEvent(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_YangYangBirds_C.__CustomEvent_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__CustomEvent_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_YangYangBirds_C.__CustomEvent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__CustomEvent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__CustomEvent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E2E4 RID: 123620 RVA: 0x008EEC5C File Offset: 0x008ECE5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveBirdsFail(EYangYangBirdsTendency FailedTendency)
		{
			BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ReceiveBirdsFail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FailedTendency = FailedTendency;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsFail_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E2E5 RID: 123621 RVA: 0x008EECA4 File Offset: 0x008ECEA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveBirdsFail_Implementation(EYangYangBirdsTendency FailedTendency)
		{
			BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_YangYangBirds_C.__ReceiveBirdsFail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ReceiveBirdsFail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FailedTendency = FailedTendency;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsFail_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2E6 RID: 123622 RVA: 0x008EECEB File Offset: 0x008ECEEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBirdsDisappear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsDisappear_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2E7 RID: 123623 RVA: 0x008EECFF File Offset: 0x008ECEFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBirdsDisappear_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsDisappear_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E2E8 RID: 123624 RVA: 0x008EED14 File Offset: 0x008ECF14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBirdsAppear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsAppear_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2E9 RID: 123625 RVA: 0x008EED28 File Offset: 0x008ECF28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBirdsAppear_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ReceiveBirdsAppear_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E2EA RID: 123626 RVA: 0x008EED40 File Offset: 0x008ECF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_YangYangBirds(int EntryPoint)
		{
			BP_YangYangBirds_C.__ExecuteUbergraph_BP_YangYangBirds_FunctionParams* ptr = stackalloc BP_YangYangBirds_C.__ExecuteUbergraph_BP_YangYangBirds_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_YangYangBirds_C.__ExecuteUbergraph_BP_YangYangBirds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangYangBirds_C.__ExecuteUbergraph_BP_YangYangBirds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangYangBirds_C.__ExecuteUbergraph_BP_YangYangBirds_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2EB RID: 123627 RVA: 0x008EED8A File Offset: 0x008ECF8A
		protected BP_YangYangBirds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ED27 RID: 60711
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangYangBirds.BP_YangYangBirds_C";

		// Token: 0x0400ED28 RID: 60712
		private static IntPtr _ClassPtr;

		// Token: 0x0400ED29 RID: 60713
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ED2A RID: 60714
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED2B RID: 60715
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ED2C RID: 60716
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED2D RID: 60717
		internal static int __PropertyOffset_2;

		// Token: 0x0400ED2E RID: 60718
		internal static int __PropertyOffset_3;

		// Token: 0x0400ED2F RID: 60719
		internal static int __PropertyOffset_4;

		// Token: 0x0400ED30 RID: 60720
		internal static int __PropertyOffset_5;

		// Token: 0x0400ED31 RID: 60721
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SYYBirdWeaponItem> _WeaponItems;

		// Token: 0x0400ED32 RID: 60722
		internal static int __PropertyOffset_6;

		// Token: 0x0400ED33 RID: 60723
		internal static int __PropertyOffset_7;

		// Token: 0x0400ED34 RID: 60724
		internal static int __PropertyOffset_8;

		// Token: 0x0400ED35 RID: 60725
		internal static int __PropertyOffset_9;

		// Token: 0x0400ED36 RID: 60726
		internal static int __PropertyOffset_10;

		// Token: 0x0400ED37 RID: 60727
		internal static int __PropertyOffset_11;

		// Token: 0x0400ED38 RID: 60728
		[Nullable(2)]
		private FKuroYangYangBirdsFrightenPoint _DebugFrightenInfo;

		// Token: 0x0400ED39 RID: 60729
		internal static int __PropertyOffset_12;

		// Token: 0x0400ED3A RID: 60730
		internal static int __PropertyOffset_13;

		// Token: 0x0400ED3B RID: 60731
		private static IntPtr __ShouldDisappear_NativeFunctionPtr;

		// Token: 0x0400ED3C RID: 60732
		private static IntPtr __MarkPendingDisappear_NativeFunctionPtr;

		// Token: 0x0400ED3D RID: 60733
		private static IntPtr __DebugFrighten_NativeFunctionPtr;

		// Token: 0x0400ED3E RID: 60734
		private static IntPtr __UpdateFrighten_NativeFunctionPtr;

		// Token: 0x0400ED3F RID: 60735
		private static IntPtr __ShouldTakeOff_NativeFunctionPtr;

		// Token: 0x0400ED40 RID: 60736
		private static IntPtr __ShouldLand_NativeFunctionPtr;

		// Token: 0x0400ED41 RID: 60737
		private static IntPtr __ShouldAppear_NativeFunctionPtr;

		// Token: 0x0400ED42 RID: 60738
		private static IntPtr __UpdateInterestPointGround_NativeFunctionPtr;

		// Token: 0x0400ED43 RID: 60739
		private static IntPtr __UpdateInterestPointAir_NativeFunctionPtr;

		// Token: 0x0400ED44 RID: 60740
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400ED45 RID: 60741
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400ED46 RID: 60742
		private static IntPtr __CustomEvent_NativeFunctionPtr;

		// Token: 0x0400ED47 RID: 60743
		private static IntPtr __ReceiveBirdsFail_NativeFunctionPtr;

		// Token: 0x0400ED48 RID: 60744
		private static IntPtr __ReceiveBirdsDisappear_NativeFunctionPtr;

		// Token: 0x0400ED49 RID: 60745
		private static IntPtr __ReceiveBirdsAppear_NativeFunctionPtr;

		// Token: 0x0400ED4A RID: 60746
		private static IntPtr __ExecuteUbergraph_BP_YangYangBirds_NativeFunctionPtr;

		// Token: 0x0200977B RID: 38779
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ShouldDisappear_FunctionParams
		{
			// Token: 0x04031D30 RID: 204080
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200977C RID: 38780
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __UpdateFrighten_FunctionParams
		{
			// Token: 0x04031D31 RID: 204081
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x0200977D RID: 38781
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected new ref struct __ShouldTakeOff_FunctionParams
		{
			// Token: 0x04031D32 RID: 204082
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200977E RID: 38782
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ShouldLand_FunctionParams
		{
			// Token: 0x04031D33 RID: 204083
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200977F RID: 38783
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected new ref struct __ShouldAppear_FunctionParams
		{
			// Token: 0x04031D34 RID: 204084
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x02009780 RID: 38784
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D35 RID: 204085
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009781 RID: 38785
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CustomEvent_FunctionParams
		{
			// Token: 0x04031D36 RID: 204086
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031D37 RID: 204087
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031D38 RID: 204088
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009782 RID: 38786
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveBirdsFail_FunctionParams
		{
			// Token: 0x04031D39 RID: 204089
			[FieldOffset(0)]
			public EYangYangBirdsTendency FailedTendency;
		}

		// Token: 0x02009783 RID: 38787
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __ExecuteUbergraph_BP_YangYangBirds_FunctionParams
		{
			// Token: 0x04031D3A RID: 204090
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
