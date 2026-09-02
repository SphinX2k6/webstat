using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC5 RID: 15557
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds.BP_FloatingBillboardClouds_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1524)]
	public class BP_FloatingBillboardClouds_C : AKuroFloatingBillboardCloudActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024F6C RID: 151404 RVA: 0x009AD370 File Offset: 0x009AB570
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingBillboardClouds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds.BP_FloatingBillboardClouds_C");
			}
			return BP_FloatingBillboardClouds_C._ClassPtr;
		}

		// Token: 0x06024F6D RID: 151405 RVA: 0x009AD394 File Offset: 0x009AB594
		public BP_FloatingBillboardClouds_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingBillboardClouds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024F6E RID: 151406 RVA: 0x009AD3BC File Offset: 0x009AB5BC
		public BP_FloatingBillboardClouds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingBillboardClouds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004EC2 RID: 20162
		// (get) Token: 0x06024F6F RID: 151407 RVA: 0x009AD3F0 File Offset: 0x009AB5F0
		// (set) Token: 0x06024F70 RID: 151408 RVA: 0x009AD429 File Offset: 0x009AB629
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EC3 RID: 20163
		// (get) Token: 0x06024F71 RID: 151409 RVA: 0x009AD44A File Offset: 0x009AB64A
		// (set) Token: 0x06024F72 RID: 151410 RVA: 0x009AD45E File Offset: 0x009AB65E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EC4 RID: 20164
		// (get) Token: 0x06024F73 RID: 151411 RVA: 0x009AD473 File Offset: 0x009AB673
		// (set) Token: 0x06024F74 RID: 151412 RVA: 0x009AD483 File Offset: 0x009AB683
		public unsafe int Number
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004EC5 RID: 20165
		// (get) Token: 0x06024F75 RID: 151413 RVA: 0x009AD494 File Offset: 0x009AB694
		// (set) Token: 0x06024F76 RID: 151414 RVA: 0x009AD4CD File Offset: 0x009AB6CD
		public TArray<BP_FloatingBillboardClouds_Prefab_C> Childs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_FloatingBillboardClouds_Prefab_C> result;
				if ((result = this._Childs) == null)
				{
					result = (this._Childs = new TArray<BP_FloatingBillboardClouds_Prefab_C>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Childs.CopyAssign(value);
			}
		}

		// Token: 0x17004EC6 RID: 20166
		// (get) Token: 0x06024F77 RID: 151415 RVA: 0x009AD4DB File Offset: 0x009AB6DB
		// (set) Token: 0x06024F78 RID: 151416 RVA: 0x009AD4EF File Offset: 0x009AB6EF
		[Nullable(2)]
		public unsafe UKuroPDFloatingBillboardCloudPrefab CloudPD
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPDFloatingBillboardCloudPrefab>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004EC7 RID: 20167
		// (get) Token: 0x06024F79 RID: 151417 RVA: 0x009AD504 File Offset: 0x009AB704
		// (set) Token: 0x06024F7A RID: 151418 RVA: 0x009AD514 File Offset: 0x009AB714
		public unsafe bool Reset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EC8 RID: 20168
		// (get) Token: 0x06024F7B RID: 151419 RVA: 0x009AD525 File Offset: 0x009AB725
		// (set) Token: 0x06024F7C RID: 151420 RVA: 0x009AD535 File Offset: 0x009AB735
		public unsafe int Trans_Sort_Number
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004EC9 RID: 20169
		// (get) Token: 0x06024F7D RID: 151421 RVA: 0x009AD548 File Offset: 0x009AB748
		// (set) Token: 0x06024F7E RID: 151422 RVA: 0x009AD581 File Offset: 0x009AB781
		public TArray<FVector2D> PoissonPositionList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._PoissonPositionList) == null)
				{
					result = (this._PoissonPositionList = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.PoissonPositionList.CopyAssign(value);
			}
		}

		// Token: 0x17004ECA RID: 20170
		// (get) Token: 0x06024F7F RID: 151423 RVA: 0x009AD590 File Offset: 0x009AB790
		// (set) Token: 0x06024F80 RID: 151424 RVA: 0x009AD5C9 File Offset: 0x009AB7C9
		public TArray<int> PositionIndex
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._PositionIndex) == null)
				{
					result = (this._PositionIndex = new TArray<int>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.PositionIndex.CopyAssign(value);
			}
		}

		// Token: 0x17004ECB RID: 20171
		// (get) Token: 0x06024F81 RID: 151425 RVA: 0x009AD5D7 File Offset: 0x009AB7D7
		// (set) Token: 0x06024F82 RID: 151426 RVA: 0x009AD5E7 File Offset: 0x009AB7E7
		public unsafe float CloudHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004ECC RID: 20172
		// (get) Token: 0x06024F83 RID: 151427 RVA: 0x009AD5F8 File Offset: 0x009AB7F8
		// (set) Token: 0x06024F84 RID: 151428 RVA: 0x009AD608 File Offset: 0x009AB808
		public unsafe int Threshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004ECD RID: 20173
		// (get) Token: 0x06024F85 RID: 151429 RVA: 0x009AD619 File Offset: 0x009AB819
		// (set) Token: 0x06024F86 RID: 151430 RVA: 0x009AD629 File Offset: 0x009AB829
		public unsafe int CloudRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004ECE RID: 20174
		// (get) Token: 0x06024F87 RID: 151431 RVA: 0x009AD63A File Offset: 0x009AB83A
		// (set) Token: 0x06024F88 RID: 151432 RVA: 0x009AD64A File Offset: 0x009AB84A
		public unsafe int Height_Layering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004ECF RID: 20175
		// (get) Token: 0x06024F89 RID: 151433 RVA: 0x009AD65B File Offset: 0x009AB85B
		// (set) Token: 0x06024F8A RID: 151434 RVA: 0x009AD66B File Offset: 0x009AB86B
		public unsafe float Height_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004ED0 RID: 20176
		// (get) Token: 0x06024F8B RID: 151435 RVA: 0x009AD67C File Offset: 0x009AB87C
		// (set) Token: 0x06024F8C RID: 151436 RVA: 0x009AD690 File Offset: 0x009AB890
		public unsafe FVector CloudScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004ED1 RID: 20177
		// (get) Token: 0x06024F8D RID: 151437 RVA: 0x009AD6A8 File Offset: 0x009AB8A8
		// (set) Token: 0x06024F8E RID: 151438 RVA: 0x009AD6E1 File Offset: 0x009AB8E1
		public TArray<FVector2D> TextureIndex
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._TextureIndex) == null)
				{
					result = (this._TextureIndex = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.TextureIndex.CopyAssign(value);
			}
		}

		// Token: 0x17004ED2 RID: 20178
		// (get) Token: 0x06024F8F RID: 151439 RVA: 0x009AD6EF File Offset: 0x009AB8EF
		// (set) Token: 0x06024F90 RID: 151440 RVA: 0x009AD703 File Offset: 0x009AB903
		public unsafe FVector2D TextureIndexRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004ED3 RID: 20179
		// (get) Token: 0x06024F91 RID: 151441 RVA: 0x009AD718 File Offset: 0x009AB918
		// (set) Token: 0x06024F92 RID: 151442 RVA: 0x009AD728 File Offset: 0x009AB928
		public unsafe float ChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004ED4 RID: 20180
		// (get) Token: 0x06024F93 RID: 151443 RVA: 0x009AD739 File Offset: 0x009AB939
		// (set) Token: 0x06024F94 RID: 151444 RVA: 0x009AD74D File Offset: 0x009AB94D
		public unsafe FVector2D CloudDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004ED5 RID: 20181
		// (get) Token: 0x06024F95 RID: 151445 RVA: 0x009AD762 File Offset: 0x009AB962
		// (set) Token: 0x06024F96 RID: 151446 RVA: 0x009AD772 File Offset: 0x009AB972
		public unsafe bool UseStoredPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ED6 RID: 20182
		// (get) Token: 0x06024F97 RID: 151447 RVA: 0x009AD784 File Offset: 0x009AB984
		// (set) Token: 0x06024F98 RID: 151448 RVA: 0x009AD7BD File Offset: 0x009AB9BD
		public TArray<FVector2D> StaticPositionList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._StaticPositionList) == null)
				{
					result = (this._StaticPositionList = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.StaticPositionList.CopyAssign(value);
			}
		}

		// Token: 0x17004ED7 RID: 20183
		// (get) Token: 0x06024F99 RID: 151449 RVA: 0x009AD7CB File Offset: 0x009AB9CB
		// (set) Token: 0x06024F9A RID: 151450 RVA: 0x009AD7DB File Offset: 0x009AB9DB
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004ED8 RID: 20184
		// (get) Token: 0x06024F9B RID: 151451 RVA: 0x009AD7EC File Offset: 0x009AB9EC
		// (set) Token: 0x06024F9C RID: 151452 RVA: 0x009AD800 File Offset: 0x009ABA00
		public unsafe FVectorDouble CloudPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004ED9 RID: 20185
		// (get) Token: 0x06024F9D RID: 151453 RVA: 0x009AD815 File Offset: 0x009ABA15
		// (set) Token: 0x06024F9E RID: 151454 RVA: 0x009AD825 File Offset: 0x009ABA25
		public unsafe int CloudDissolveDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x06024F9F RID: 151455 RVA: 0x009AD836 File Offset: 0x009ABA36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculatePoissonPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__CalculatePoissonPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA0 RID: 151456 RVA: 0x009AD84C File Offset: 0x009ABA4C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CloudPrefabParamIni(BP_FloatingBillboardClouds_Prefab_C CloudPrefab, int CloudIndex)
		{
			BP_FloatingBillboardClouds_C.__CloudPrefabParamIni_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__CloudPrefabParamIni_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__CloudPrefabParamIni_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__CloudPrefabParamIni_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPrefab = ((CloudPrefab != null) ? CloudPrefab.NativePtr : IntPtr.Zero);
			ptr->CloudIndex = CloudIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__CloudPrefabParamIni_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FA1 RID: 151457 RVA: 0x009AD8A8 File Offset: 0x009ABAA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StoreCurrentPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__StoreCurrentPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA2 RID: 151458 RVA: 0x009AD8BC File Offset: 0x009ABABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CaluateIndex()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__CaluateIndex_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA3 RID: 151459 RVA: 0x009AD8D0 File Offset: 0x009ABAD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__RefreshCloud_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA4 RID: 151460 RVA: 0x009AD8E4 File Offset: 0x009ABAE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MainParamsUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__MainParamsUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA5 RID: 151461 RVA: 0x009AD8F8 File Offset: 0x009ABAF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024FA6 RID: 151462 RVA: 0x009AD90C File Offset: 0x009ABB0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024FA7 RID: 151463 RVA: 0x009AD924 File Offset: 0x009ABB24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FA8 RID: 151464 RVA: 0x009AD96C File Offset: 0x009ABB6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FA9 RID: 151465 RVA: 0x009AD9B4 File Offset: 0x009ABBB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FAA RID: 151466 RVA: 0x009AD9FC File Offset: 0x009ABBFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FAB RID: 151467 RVA: 0x009ADA43 File Offset: 0x009ABC43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024FAC RID: 151468 RVA: 0x009ADA57 File Offset: 0x009ABC57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024FAD RID: 151469 RVA: 0x009ADA6C File Offset: 0x009ABC6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingBillboardClouds(int EntryPoint)
		{
			BP_FloatingBillboardClouds_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_FloatingBillboardClouds_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FAE RID: 151470 RVA: 0x009ADAB3 File Offset: 0x009ABCB3
		protected BP_FloatingBillboardClouds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012FE3 RID: 77795
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds.BP_FloatingBillboardClouds_C";

		// Token: 0x04012FE4 RID: 77796
		private static IntPtr _ClassPtr;

		// Token: 0x04012FE5 RID: 77797
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012FE6 RID: 77798
		internal static int __PropertyOffset_0;

		// Token: 0x04012FE7 RID: 77799
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012FE8 RID: 77800
		internal static int __PropertyOffset_1;

		// Token: 0x04012FE9 RID: 77801
		internal static int __PropertyOffset_2;

		// Token: 0x04012FEA RID: 77802
		internal static int __PropertyOffset_3;

		// Token: 0x04012FEB RID: 77803
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_FloatingBillboardClouds_Prefab_C> _Childs;

		// Token: 0x04012FEC RID: 77804
		internal static int __PropertyOffset_4;

		// Token: 0x04012FED RID: 77805
		internal static int __PropertyOffset_5;

		// Token: 0x04012FEE RID: 77806
		internal static int __PropertyOffset_6;

		// Token: 0x04012FEF RID: 77807
		internal static int __PropertyOffset_7;

		// Token: 0x04012FF0 RID: 77808
		[Nullable(2)]
		private TArray<FVector2D> _PoissonPositionList;

		// Token: 0x04012FF1 RID: 77809
		internal static int __PropertyOffset_8;

		// Token: 0x04012FF2 RID: 77810
		[Nullable(2)]
		private TArray<int> _PositionIndex;

		// Token: 0x04012FF3 RID: 77811
		internal static int __PropertyOffset_9;

		// Token: 0x04012FF4 RID: 77812
		internal static int __PropertyOffset_10;

		// Token: 0x04012FF5 RID: 77813
		internal static int __PropertyOffset_11;

		// Token: 0x04012FF6 RID: 77814
		internal static int __PropertyOffset_12;

		// Token: 0x04012FF7 RID: 77815
		internal static int __PropertyOffset_13;

		// Token: 0x04012FF8 RID: 77816
		internal static int __PropertyOffset_14;

		// Token: 0x04012FF9 RID: 77817
		internal static int __PropertyOffset_15;

		// Token: 0x04012FFA RID: 77818
		[Nullable(2)]
		private TArray<FVector2D> _TextureIndex;

		// Token: 0x04012FFB RID: 77819
		internal static int __PropertyOffset_16;

		// Token: 0x04012FFC RID: 77820
		internal static int __PropertyOffset_17;

		// Token: 0x04012FFD RID: 77821
		internal static int __PropertyOffset_18;

		// Token: 0x04012FFE RID: 77822
		internal static int __PropertyOffset_19;

		// Token: 0x04012FFF RID: 77823
		internal static int __PropertyOffset_20;

		// Token: 0x04013000 RID: 77824
		[Nullable(2)]
		private TArray<FVector2D> _StaticPositionList;

		// Token: 0x04013001 RID: 77825
		internal static int __PropertyOffset_21;

		// Token: 0x04013002 RID: 77826
		internal static int __PropertyOffset_22;

		// Token: 0x04013003 RID: 77827
		internal static int __PropertyOffset_23;

		// Token: 0x04013004 RID: 77828
		private static IntPtr __CalculatePoissonPosition_NativeFunctionPtr;

		// Token: 0x04013005 RID: 77829
		private static IntPtr __CloudPrefabParamIni_NativeFunctionPtr;

		// Token: 0x04013006 RID: 77830
		private static IntPtr __StoreCurrentPosition_NativeFunctionPtr;

		// Token: 0x04013007 RID: 77831
		private static IntPtr __CaluateIndex_NativeFunctionPtr;

		// Token: 0x04013008 RID: 77832
		private static IntPtr __RefreshCloud_NativeFunctionPtr;

		// Token: 0x04013009 RID: 77833
		private static IntPtr __MainParamsUpdate_NativeFunctionPtr;

		// Token: 0x0401300A RID: 77834
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401300B RID: 77835
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401300C RID: 77836
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401300D RID: 77837
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401300E RID: 77838
		private static IntPtr __ExecuteUbergraph_BP_FloatingBillboardClouds_NativeFunctionPtr;

		// Token: 0x02009EA9 RID: 40617
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __CloudPrefabParamIni_FunctionParams
		{
			// Token: 0x04032969 RID: 207209
			[FieldOffset(0)]
			public IntPtr CloudPrefab;

			// Token: 0x0403296A RID: 207210
			[FieldOffset(8)]
			public int CloudIndex;
		}

		// Token: 0x02009EAA RID: 40618
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403296B RID: 207211
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EAB RID: 40619
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403296C RID: 207212
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EAC RID: 40620
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_FloatingBillboardClouds_FunctionParams
		{
			// Token: 0x0403296D RID: 207213
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
