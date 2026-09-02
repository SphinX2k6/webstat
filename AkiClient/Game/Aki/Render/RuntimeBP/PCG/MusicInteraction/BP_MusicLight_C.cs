using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MusicInteraction
{
	// Token: 0x02003BBC RID: 15292
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicLight.BP_MusicLight_C")]
	[UnrealStructLayout(2408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2408)]
	public class BP_MusicLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022458 RID: 140376 RVA: 0x0096095F File Offset: 0x0095EB5F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MusicLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicLight.BP_MusicLight_C");
			}
			return BP_MusicLight_C._ClassPtr;
		}

		// Token: 0x06022459 RID: 140377 RVA: 0x00960984 File Offset: 0x0095EB84
		public BP_MusicLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_MusicLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602245A RID: 140378 RVA: 0x009609AC File Offset: 0x0095EBAC
		[NullableContext(1)]
		public BP_MusicLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MusicLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FF9 RID: 16377
		// (get) Token: 0x0602245B RID: 140379 RVA: 0x009609E0 File Offset: 0x0095EBE0
		// (set) Token: 0x0602245C RID: 140380 RVA: 0x00960A19 File Offset: 0x0095EC19
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FFA RID: 16378
		// (get) Token: 0x0602245D RID: 140381 RVA: 0x00960A3A File Offset: 0x0095EC3A
		// (set) Token: 0x0602245E RID: 140382 RVA: 0x00960A4E File Offset: 0x0095EC4E
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FFB RID: 16379
		// (get) Token: 0x0602245F RID: 140383 RVA: 0x00960A63 File Offset: 0x0095EC63
		// (set) Token: 0x06022460 RID: 140384 RVA: 0x00960A77 File Offset: 0x0095EC77
		public unsafe UChildActorComponent BP_VolumetricLightMonitor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FFC RID: 16380
		// (get) Token: 0x06022461 RID: 140385 RVA: 0x00960A8C File Offset: 0x0095EC8C
		// (set) Token: 0x06022462 RID: 140386 RVA: 0x00960AA0 File Offset: 0x0095ECA0
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003FFD RID: 16381
		// (get) Token: 0x06022463 RID: 140387 RVA: 0x00960AB5 File Offset: 0x0095ECB5
		// (set) Token: 0x06022464 RID: 140388 RVA: 0x00960AC9 File Offset: 0x0095ECC9
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003FFE RID: 16382
		// (get) Token: 0x06022465 RID: 140389 RVA: 0x00960ADE File Offset: 0x0095ECDE
		// (set) Token: 0x06022466 RID: 140390 RVA: 0x00960AEE File Offset: 0x0095ECEE
		public unsafe bool 双拍触发
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FFF RID: 16383
		// (get) Token: 0x06022467 RID: 140391 RVA: 0x00960B00 File Offset: 0x0095ED00
		// (set) Token: 0x06022468 RID: 140392 RVA: 0x00960B39 File Offset: 0x0095ED39
		[Nullable(1)]
		public FKuroCurveFloat 灯光强度
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光强度) == null)
				{
					result = (this._灯光强度 = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004000 RID: 16384
		// (get) Token: 0x06022469 RID: 140393 RVA: 0x00960B5C File Offset: 0x0095ED5C
		// (set) Token: 0x0602246A RID: 140394 RVA: 0x00960B95 File Offset: 0x0095ED95
		[Nullable(1)]
		public FKuroCurveFloat 衰减半径
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._衰减半径) == null)
				{
					result = (this._衰减半径 = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004001 RID: 16385
		// (get) Token: 0x0602246B RID: 140395 RVA: 0x00960BB8 File Offset: 0x0095EDB8
		// (set) Token: 0x0602246C RID: 140396 RVA: 0x00960BF1 File Offset: 0x0095EDF1
		[Nullable(1)]
		public FKuroCurveLinearColor 灯光颜色
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._灯光颜色) == null)
				{
					result = (this._灯光颜色 = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004002 RID: 16386
		// (get) Token: 0x0602246D RID: 140397 RVA: 0x00960C12 File Offset: 0x0095EE12
		// (set) Token: 0x0602246E RID: 140398 RVA: 0x00960C22 File Offset: 0x0095EE22
		public unsafe float 光源衰减指数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004003 RID: 16387
		// (get) Token: 0x0602246F RID: 140399 RVA: 0x00960C33 File Offset: 0x0095EE33
		// (set) Token: 0x06022470 RID: 140400 RVA: 0x00960C43 File Offset: 0x0095EE43
		public unsafe bool 启用聚光灯
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004004 RID: 16388
		// (get) Token: 0x06022471 RID: 140401 RVA: 0x00960C54 File Offset: 0x0095EE54
		// (set) Token: 0x06022472 RID: 140402 RVA: 0x00960C64 File Offset: 0x0095EE64
		public unsafe bool 聚光灯投射阴影
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004005 RID: 16389
		// (get) Token: 0x06022473 RID: 140403 RVA: 0x00960C75 File Offset: 0x0095EE75
		// (set) Token: 0x06022474 RID: 140404 RVA: 0x00960C89 File Offset: 0x0095EE89
		public unsafe FVector 聚光灯体积光缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004006 RID: 16390
		// (get) Token: 0x06022475 RID: 140405 RVA: 0x00960C9E File Offset: 0x0095EE9E
		// (set) Token: 0x06022476 RID: 140406 RVA: 0x00960CAE File Offset: 0x0095EEAE
		public unsafe float 聚光灯椎体内部角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004007 RID: 16391
		// (get) Token: 0x06022477 RID: 140407 RVA: 0x00960CBF File Offset: 0x0095EEBF
		// (set) Token: 0x06022478 RID: 140408 RVA: 0x00960CCF File Offset: 0x0095EECF
		public unsafe float 聚光灯椎体外部角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004008 RID: 16392
		// (get) Token: 0x06022479 RID: 140409 RVA: 0x00960CE0 File Offset: 0x0095EEE0
		// (set) Token: 0x0602247A RID: 140410 RVA: 0x00960D19 File Offset: 0x0095EF19
		[Nullable(1)]
		public FKuroCurveFloat 聚光灯摆动
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._聚光灯摆动) == null)
				{
					result = (this._聚光灯摆动 = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004009 RID: 16393
		// (get) Token: 0x0602247B RID: 140411 RVA: 0x00960D3A File Offset: 0x0095EF3A
		// (set) Token: 0x0602247C RID: 140412 RVA: 0x00960D4A File Offset: 0x0095EF4A
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700400A RID: 16394
		// (get) Token: 0x0602247D RID: 140413 RVA: 0x00960D5B File Offset: 0x0095EF5B
		// (set) Token: 0x0602247E RID: 140414 RVA: 0x00960D6B File Offset: 0x0095EF6B
		public unsafe float 单拍时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700400B RID: 16395
		// (get) Token: 0x0602247F RID: 140415 RVA: 0x00960D7C File Offset: 0x0095EF7C
		// (set) Token: 0x06022480 RID: 140416 RVA: 0x00960D8C File Offset: 0x0095EF8C
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700400C RID: 16396
		// (get) Token: 0x06022481 RID: 140417 RVA: 0x00960D9D File Offset: 0x0095EF9D
		// (set) Token: 0x06022482 RID: 140418 RVA: 0x00960DAD File Offset: 0x0095EFAD
		public unsafe float BeatTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700400D RID: 16397
		// (get) Token: 0x06022483 RID: 140419 RVA: 0x00960DBE File Offset: 0x0095EFBE
		// (set) Token: 0x06022484 RID: 140420 RVA: 0x00960DCE File Offset: 0x0095EFCE
		public unsafe int BeatNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicLight_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700400E RID: 16398
		// (get) Token: 0x06022485 RID: 140421 RVA: 0x00960DDF File Offset: 0x0095EFDF
		// (set) Token: 0x06022486 RID: 140422 RVA: 0x00960DF3 File Offset: 0x0095EFF3
		public unsafe UPointLightComponent Light
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicLight_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x06022487 RID: 140423 RVA: 0x00960E08 File Offset: 0x0095F008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022488 RID: 140424 RVA: 0x00960E1C File Offset: 0x0095F01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022489 RID: 140425 RVA: 0x00960E34 File Offset: 0x0095F034
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MusicLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MusicLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602248A RID: 140426 RVA: 0x00960E7C File Offset: 0x0095F07C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MusicLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MusicLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602248B RID: 140427 RVA: 0x00960EC4 File Offset: 0x0095F0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MusicLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MusicLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602248C RID: 140428 RVA: 0x00960F0C File Offset: 0x0095F10C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MusicLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MusicLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602248D RID: 140429 RVA: 0x00960F54 File Offset: 0x0095F154
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MusicLight(int EntryPoint)
		{
			BP_MusicLight_C.__ExecuteUbergraph_BP_MusicLight_FunctionParams* ptr = stackalloc BP_MusicLight_C.__ExecuteUbergraph_BP_MusicLight_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_MusicLight_C.__ExecuteUbergraph_BP_MusicLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicLight_C.__ExecuteUbergraph_BP_MusicLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicLight_C.__ExecuteUbergraph_BP_MusicLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602248E RID: 140430 RVA: 0x00960F9E File Offset: 0x0095F19E
		protected BP_MusicLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011547 RID: 70983
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicLight.BP_MusicLight_C";

		// Token: 0x04011548 RID: 70984
		private static IntPtr _ClassPtr;

		// Token: 0x04011549 RID: 70985
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401154A RID: 70986
		internal static int __PropertyOffset_0;

		// Token: 0x0401154B RID: 70987
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401154C RID: 70988
		internal static int __PropertyOffset_1;

		// Token: 0x0401154D RID: 70989
		internal static int __PropertyOffset_2;

		// Token: 0x0401154E RID: 70990
		internal static int __PropertyOffset_3;

		// Token: 0x0401154F RID: 70991
		internal static int __PropertyOffset_4;

		// Token: 0x04011550 RID: 70992
		internal static int __PropertyOffset_5;

		// Token: 0x04011551 RID: 70993
		internal static int __PropertyOffset_6;

		// Token: 0x04011552 RID: 70994
		private FKuroCurveFloat _灯光强度;

		// Token: 0x04011553 RID: 70995
		internal static int __PropertyOffset_7;

		// Token: 0x04011554 RID: 70996
		private FKuroCurveFloat _衰减半径;

		// Token: 0x04011555 RID: 70997
		internal static int __PropertyOffset_8;

		// Token: 0x04011556 RID: 70998
		private FKuroCurveLinearColor _灯光颜色;

		// Token: 0x04011557 RID: 70999
		internal static int __PropertyOffset_9;

		// Token: 0x04011558 RID: 71000
		internal static int __PropertyOffset_10;

		// Token: 0x04011559 RID: 71001
		internal static int __PropertyOffset_11;

		// Token: 0x0401155A RID: 71002
		internal static int __PropertyOffset_12;

		// Token: 0x0401155B RID: 71003
		internal static int __PropertyOffset_13;

		// Token: 0x0401155C RID: 71004
		internal static int __PropertyOffset_14;

		// Token: 0x0401155D RID: 71005
		internal static int __PropertyOffset_15;

		// Token: 0x0401155E RID: 71006
		private FKuroCurveFloat _聚光灯摆动;

		// Token: 0x0401155F RID: 71007
		internal static int __PropertyOffset_16;

		// Token: 0x04011560 RID: 71008
		internal static int __PropertyOffset_17;

		// Token: 0x04011561 RID: 71009
		internal static int __PropertyOffset_18;

		// Token: 0x04011562 RID: 71010
		internal static int __PropertyOffset_19;

		// Token: 0x04011563 RID: 71011
		internal static int __PropertyOffset_20;

		// Token: 0x04011564 RID: 71012
		internal static int __PropertyOffset_21;

		// Token: 0x04011565 RID: 71013
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011566 RID: 71014
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011567 RID: 71015
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011568 RID: 71016
		private static IntPtr __ExecuteUbergraph_BP_MusicLight_NativeFunctionPtr;

		// Token: 0x02009BB5 RID: 39861
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040323E8 RID: 205800
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB6 RID: 39862
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323E9 RID: 205801
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB7 RID: 39863
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __ExecuteUbergraph_BP_MusicLight_FunctionParams
		{
			// Token: 0x040323EA RID: 205802
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
