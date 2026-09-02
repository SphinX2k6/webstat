using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004377 RID: 17271
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_AudioSpace.BP_AudioSpace_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1162)]
	public class BP_AudioSpace_C : AKuroEffectActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DBCF RID: 187343 RVA: 0x00ACA963 File Offset: 0x00AC8B63
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AudioSpace_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_AudioSpace.BP_AudioSpace_C");
			}
			return BP_AudioSpace_C._ClassPtr;
		}

		// Token: 0x0602DBD0 RID: 187344 RVA: 0x00ACA988 File Offset: 0x00AC8B88
		public BP_AudioSpace_C() : this(BuiltinUtils.AllocNativeUObject(BP_AudioSpace_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DBD1 RID: 187345 RVA: 0x00ACA9B0 File Offset: 0x00AC8BB0
		[NullableContext(1)]
		public BP_AudioSpace_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AudioSpace_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D30 RID: 32048
		// (get) Token: 0x0602DBD2 RID: 187346 RVA: 0x00ACA9E4 File Offset: 0x00AC8BE4
		// (set) Token: 0x0602DBD3 RID: 187347 RVA: 0x00ACAA1D File Offset: 0x00AC8C1D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D31 RID: 32049
		// (get) Token: 0x0602DBD4 RID: 187348 RVA: 0x00ACAA3E File Offset: 0x00AC8C3E
		// (set) Token: 0x0602DBD5 RID: 187349 RVA: 0x00ACAA52 File Offset: 0x00AC8C52
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D32 RID: 32050
		// (get) Token: 0x0602DBD6 RID: 187350 RVA: 0x00ACAA67 File Offset: 0x00AC8C67
		// (set) Token: 0x0602DBD7 RID: 187351 RVA: 0x00ACAA7B File Offset: 0x00AC8C7B
		public unsafe UAkComponent AkComponentRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D33 RID: 32051
		// (get) Token: 0x0602DBD8 RID: 187352 RVA: 0x00ACAA90 File Offset: 0x00AC8C90
		// (set) Token: 0x0602DBD9 RID: 187353 RVA: 0x00ACAAA4 File Offset: 0x00AC8CA4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007D34 RID: 32052
		// (get) Token: 0x0602DBDA RID: 187354 RVA: 0x00ACAAB9 File Offset: 0x00AC8CB9
		// (set) Token: 0x0602DBDB RID: 187355 RVA: 0x00ACAAC9 File Offset: 0x00AC8CC9
		public unsafe float 触发距离长_半径_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D35 RID: 32053
		// (get) Token: 0x0602DBDC RID: 187356 RVA: 0x00ACAADA File Offset: 0x00AC8CDA
		// (set) Token: 0x0602DBDD RID: 187357 RVA: 0x00ACAAEA File Offset: 0x00AC8CEA
		public unsafe float 触发距离宽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007D36 RID: 32054
		// (get) Token: 0x0602DBDE RID: 187358 RVA: 0x00ACAAFB File Offset: 0x00AC8CFB
		// (set) Token: 0x0602DBDF RID: 187359 RVA: 0x00ACAB0B File Offset: 0x00AC8D0B
		public unsafe float 触发高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007D37 RID: 32055
		// (get) Token: 0x0602DBE0 RID: 187360 RVA: 0x00ACAB1C File Offset: 0x00AC8D1C
		// (set) Token: 0x0602DBE1 RID: 187361 RVA: 0x00ACAB30 File Offset: 0x00AC8D30
		public unsafe FLinearColor 触发距离颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007D38 RID: 32056
		// (get) Token: 0x0602DBE2 RID: 187362 RVA: 0x00ACAB45 File Offset: 0x00AC8D45
		// (set) Token: 0x0602DBE3 RID: 187363 RVA: 0x00ACAB55 File Offset: 0x00AC8D55
		public unsafe bool 运行时显示区间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D39 RID: 32057
		// (get) Token: 0x0602DBE4 RID: 187364 RVA: 0x00ACAB66 File Offset: 0x00AC8D66
		// (set) Token: 0x0602DBE5 RID: 187365 RVA: 0x00ACAB76 File Offset: 0x00AC8D76
		public unsafe bool 编辑时显示区间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D3A RID: 32058
		// (get) Token: 0x0602DBE6 RID: 187366 RVA: 0x00ACAB87 File Offset: 0x00AC8D87
		// (set) Token: 0x0602DBE7 RID: 187367 RVA: 0x00ACAB97 File Offset: 0x00AC8D97
		public unsafe float 更新Editor文本框CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007D3B RID: 32059
		// (get) Token: 0x0602DBE8 RID: 187368 RVA: 0x00ACABA8 File Offset: 0x00AC8DA8
		// (set) Token: 0x0602DBE9 RID: 187369 RVA: 0x00ACABB8 File Offset: 0x00AC8DB8
		public unsafe float Editor检测间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007D3C RID: 32060
		// (get) Token: 0x0602DBEA RID: 187370 RVA: 0x00ACABC9 File Offset: 0x00AC8DC9
		// (set) Token: 0x0602DBEB RID: 187371 RVA: 0x00ACABD9 File Offset: 0x00AC8DD9
		public unsafe float 运行时绘制时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007D3D RID: 32061
		// (get) Token: 0x0602DBEC RID: 187372 RVA: 0x00ACABEA File Offset: 0x00AC8DEA
		// (set) Token: 0x0602DBED RID: 187373 RVA: 0x00ACABFE File Offset: 0x00AC8DFE
		public unsafe UAkAudioEvent 进入声音事件
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17007D3E RID: 32062
		// (get) Token: 0x0602DBEE RID: 187374 RVA: 0x00ACAC13 File Offset: 0x00AC8E13
		// (set) Token: 0x0602DBEF RID: 187375 RVA: 0x00ACAC27 File Offset: 0x00AC8E27
		public unsafe UAkAudioEvent 离开声音事件
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpace_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17007D3F RID: 32063
		// (get) Token: 0x0602DBF0 RID: 187376 RVA: 0x00ACAC3C File Offset: 0x00AC8E3C
		// (set) Token: 0x0602DBF1 RID: 187377 RVA: 0x00ACAC4C File Offset: 0x00AC8E4C
		public unsafe bool 是否进入触发范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D40 RID: 32064
		// (get) Token: 0x0602DBF2 RID: 187378 RVA: 0x00ACAC60 File Offset: 0x00AC8E60
		// (set) Token: 0x0602DBF3 RID: 187379 RVA: 0x00ACAC99 File Offset: 0x00AC8E99
		[Nullable(1)]
		public TArray<BP_SAudioCondition> 音效条件
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BP_SAudioCondition> result;
				if ((result = this._音效条件) == null)
				{
					result = (this._音效条件 = new TArray<BP_SAudioCondition>(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.音效条件.CopyAssign(value);
			}
		}

		// Token: 0x17007D41 RID: 32065
		// (get) Token: 0x0602DBF4 RID: 187380 RVA: 0x00ACACA7 File Offset: 0x00AC8EA7
		// (set) Token: 0x0602DBF5 RID: 187381 RVA: 0x00ACACB7 File Offset: 0x00AC8EB7
		public unsafe bool 是否在视界内
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D42 RID: 32066
		// (get) Token: 0x0602DBF6 RID: 187382 RVA: 0x00ACACC8 File Offset: 0x00AC8EC8
		// (set) Token: 0x0602DBF7 RID: 187383 RVA: 0x00ACACD8 File Offset: 0x00AC8ED8
		public unsafe bool 是否播放进入战斗音效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpace_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602DBF8 RID: 187384 RVA: 0x00ACACE9 File Offset: 0x00AC8EE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 离开重置播放标志()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__离开重置播放标志_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBF9 RID: 187385 RVA: 0x00ACAD00 File Offset: 0x00AC8F00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 战斗条件检测(ref UAkAudioEvent 指定进入音效, ref UAkAudioEvent 指定离开音效)
		{
			BP_AudioSpace_C.__战斗条件检测_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__战斗条件检测_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_AudioSpace_C.__战斗条件检测_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__战斗条件检测_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_AudioSpace_C.__战斗条件检测_FunctionParams ptr2 = ref *ptr;
			UAkAudioEvent uakAudioEvent = 指定进入音效;
			ptr2.指定进入音效 = ((uakAudioEvent != null) ? uakAudioEvent.NativePtr : IntPtr.Zero);
			ref BP_AudioSpace_C.__战斗条件检测_FunctionParams ptr3 = ref *ptr;
			UAkAudioEvent uakAudioEvent2 = 指定离开音效;
			ptr3.指定离开音效 = ((uakAudioEvent2 != null) ? uakAudioEvent2.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__战斗条件检测_NativeFunctionPtr, (void*)ptr);
			指定进入音效 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkAudioEvent>(ptr->指定进入音效);
			指定离开音效 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAkAudioEvent>(ptr->指定离开音效);
		}

		// Token: 0x0602DBFA RID: 187386 RVA: 0x00ACAD89 File Offset: 0x00AC8F89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 检测条件()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__检测条件_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBFB RID: 187387 RVA: 0x00ACADA0 File Offset: 0x00AC8FA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 玩家是否在矩形范围内(ref bool 玩家是否在范围内)
		{
			BP_AudioSpace_C.__玩家是否在矩形范围内_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__玩家是否在矩形范围内_FunctionParams[(UIntPtr)783] + 15L / (long)sizeof(BP_AudioSpace_C.__玩家是否在矩形范围内_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__玩家是否在矩形范围内_NativeFunctionPtr, (void*)ptr, 1);
			ptr->玩家是否在范围内 = 玩家是否在范围内;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__玩家是否在矩形范围内_NativeFunctionPtr, (void*)ptr);
			玩家是否在范围内 = ptr->玩家是否在范围内;
		}

		// Token: 0x0602DBFC RID: 187388 RVA: 0x00ACADF4 File Offset: 0x00AC8FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放指定音效(UAkAudioEvent 指定音效)
		{
			BP_AudioSpace_C.__播放指定音效_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__播放指定音效_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_AudioSpace_C.__播放指定音效_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__播放指定音效_NativeFunctionPtr, (void*)ptr, 1);
			ptr->指定音效 = ((指定音效 != null) ? 指定音效.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__播放指定音效_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DBFD RID: 187389 RVA: 0x00ACAE49 File Offset: 0x00AC9049
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 播放离开音效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__播放离开音效_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBFE RID: 187390 RVA: 0x00ACAE5D File Offset: 0x00AC905D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 播放进入音效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__播放进入音效_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBFF RID: 187391 RVA: 0x00ACAE71 File Offset: 0x00AC9071
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新触发范围()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__更新触发范围_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC00 RID: 187392 RVA: 0x00ACAE88 File Offset: 0x00AC9088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 玩家和音源点的距离(ref float 距离)
		{
			BP_AudioSpace_C.__玩家和音源点的距离_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__玩家和音源点的距离_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AudioSpace_C.__玩家和音源点的距离_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__玩家和音源点的距离_NativeFunctionPtr, (void*)ptr, 1);
			ptr->距离 = 距离;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__玩家和音源点的距离_NativeFunctionPtr, (void*)ptr);
			距离 = ptr->距离;
		}

		// Token: 0x0602DC01 RID: 187393 RVA: 0x00ACAED7 File Offset: 0x00AC90D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 绘制触发范围()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__绘制触发范围_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC02 RID: 187394 RVA: 0x00ACAEEC File Offset: 0x00AC90EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 绘制方形(FTransform 变换, float Duration)
		{
			BP_AudioSpace_C.__绘制方形_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__绘制方形_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_AudioSpace_C.__绘制方形_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__绘制方形_NativeFunctionPtr, (void*)ptr, 1);
			ptr->变换 = 变换;
			ptr->Duration = Duration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__绘制方形_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC03 RID: 187395 RVA: 0x00ACAF3C File Offset: 0x00AC913C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 绘制柱形(FTransform 变换, FLinearColor 颜色, float Duration)
		{
			BP_AudioSpace_C.__绘制柱形_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__绘制柱形_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(BP_AudioSpace_C.__绘制柱形_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__绘制柱形_NativeFunctionPtr, (void*)ptr, 1);
			ptr->变换 = 变换;
			ptr->颜色 = 颜色;
			ptr->Duration = Duration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__绘制柱形_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC04 RID: 187396 RVA: 0x00ACAF94 File Offset: 0x00AC9194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 绘制定点(FTransform 变换, float duration)
		{
			BP_AudioSpace_C.__绘制定点_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__绘制定点_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_AudioSpace_C.__绘制定点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__绘制定点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->变换 = 变换;
			ptr->duration = duration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__绘制定点_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC05 RID: 187397 RVA: 0x00ACAFE4 File Offset: 0x00AC91E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 描绘()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__描绘_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC06 RID: 187398 RVA: 0x00ACAFF8 File Offset: 0x00AC91F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool 判断是否需要描绘(float DeltaSeconds)
		{
			BP_AudioSpace_C.__判断是否需要描绘_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__判断是否需要描绘_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_AudioSpace_C.__判断是否需要描绘_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__判断是否需要描绘_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__判断是否需要描绘_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DC07 RID: 187399 RVA: 0x00ACB048 File Offset: 0x00AC9248
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AudioSpace_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioSpace_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC08 RID: 187400 RVA: 0x00ACB090 File Offset: 0x00AC9290
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AudioSpace_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioSpace_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioSpace_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC09 RID: 187401 RVA: 0x00ACB0D8 File Offset: 0x00AC92D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_AudioSpace_C.__EditorTick_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioSpace_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC0A RID: 187402 RVA: 0x00ACB120 File Offset: 0x00AC9320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_AudioSpace_C.__EditorTick_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioSpace_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioSpace_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC0B RID: 187403 RVA: 0x00ACB167 File Offset: 0x00AC9367
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 进入触发范围()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__进入触发范围_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC0C RID: 187404 RVA: 0x00ACB17B File Offset: 0x00AC937B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 离开触发范围()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpace_C.__离开触发范围_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC0D RID: 187405 RVA: 0x00ACB190 File Offset: 0x00AC9390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AudioSpace(int EntryPoint)
		{
			BP_AudioSpace_C.__ExecuteUbergraph_BP_AudioSpace_FunctionParams* ptr = stackalloc BP_AudioSpace_C.__ExecuteUbergraph_BP_AudioSpace_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_AudioSpace_C.__ExecuteUbergraph_BP_AudioSpace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpace_C.__ExecuteUbergraph_BP_AudioSpace_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioSpace_C.__ExecuteUbergraph_BP_AudioSpace_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC0E RID: 187406 RVA: 0x00ACB1D7 File Offset: 0x00AC93D7
		protected BP_AudioSpace_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019CF7 RID: 105719
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_AudioSpace.BP_AudioSpace_C";

		// Token: 0x04019CF8 RID: 105720
		private static IntPtr _ClassPtr;

		// Token: 0x04019CF9 RID: 105721
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019CFA RID: 105722
		internal static int __PropertyOffset_0;

		// Token: 0x04019CFB RID: 105723
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019CFC RID: 105724
		internal static int __PropertyOffset_1;

		// Token: 0x04019CFD RID: 105725
		internal static int __PropertyOffset_2;

		// Token: 0x04019CFE RID: 105726
		internal static int __PropertyOffset_3;

		// Token: 0x04019CFF RID: 105727
		internal static int __PropertyOffset_4;

		// Token: 0x04019D00 RID: 105728
		internal static int __PropertyOffset_5;

		// Token: 0x04019D01 RID: 105729
		internal static int __PropertyOffset_6;

		// Token: 0x04019D02 RID: 105730
		internal static int __PropertyOffset_7;

		// Token: 0x04019D03 RID: 105731
		internal static int __PropertyOffset_8;

		// Token: 0x04019D04 RID: 105732
		internal static int __PropertyOffset_9;

		// Token: 0x04019D05 RID: 105733
		internal static int __PropertyOffset_10;

		// Token: 0x04019D06 RID: 105734
		internal static int __PropertyOffset_11;

		// Token: 0x04019D07 RID: 105735
		internal static int __PropertyOffset_12;

		// Token: 0x04019D08 RID: 105736
		internal static int __PropertyOffset_13;

		// Token: 0x04019D09 RID: 105737
		internal static int __PropertyOffset_14;

		// Token: 0x04019D0A RID: 105738
		internal static int __PropertyOffset_15;

		// Token: 0x04019D0B RID: 105739
		internal static int __PropertyOffset_16;

		// Token: 0x04019D0C RID: 105740
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_SAudioCondition> _音效条件;

		// Token: 0x04019D0D RID: 105741
		internal static int __PropertyOffset_17;

		// Token: 0x04019D0E RID: 105742
		internal static int __PropertyOffset_18;

		// Token: 0x04019D0F RID: 105743
		private static IntPtr __离开重置播放标志_NativeFunctionPtr;

		// Token: 0x04019D10 RID: 105744
		private static IntPtr __战斗条件检测_NativeFunctionPtr;

		// Token: 0x04019D11 RID: 105745
		private static IntPtr __检测条件_NativeFunctionPtr;

		// Token: 0x04019D12 RID: 105746
		private static IntPtr __玩家是否在矩形范围内_NativeFunctionPtr;

		// Token: 0x04019D13 RID: 105747
		private static IntPtr __播放指定音效_NativeFunctionPtr;

		// Token: 0x04019D14 RID: 105748
		private static IntPtr __播放离开音效_NativeFunctionPtr;

		// Token: 0x04019D15 RID: 105749
		private static IntPtr __播放进入音效_NativeFunctionPtr;

		// Token: 0x04019D16 RID: 105750
		private static IntPtr __更新触发范围_NativeFunctionPtr;

		// Token: 0x04019D17 RID: 105751
		private static IntPtr __玩家和音源点的距离_NativeFunctionPtr;

		// Token: 0x04019D18 RID: 105752
		private static IntPtr __绘制触发范围_NativeFunctionPtr;

		// Token: 0x04019D19 RID: 105753
		private static IntPtr __绘制方形_NativeFunctionPtr;

		// Token: 0x04019D1A RID: 105754
		private static IntPtr __绘制柱形_NativeFunctionPtr;

		// Token: 0x04019D1B RID: 105755
		private static IntPtr __绘制定点_NativeFunctionPtr;

		// Token: 0x04019D1C RID: 105756
		private static IntPtr __描绘_NativeFunctionPtr;

		// Token: 0x04019D1D RID: 105757
		private static IntPtr __判断是否需要描绘_NativeFunctionPtr;

		// Token: 0x04019D1E RID: 105758
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019D1F RID: 105759
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04019D20 RID: 105760
		private static IntPtr __进入触发范围_NativeFunctionPtr;

		// Token: 0x04019D21 RID: 105761
		private static IntPtr __离开触发范围_NativeFunctionPtr;

		// Token: 0x04019D22 RID: 105762
		private static IntPtr __ExecuteUbergraph_BP_AudioSpace_NativeFunctionPtr;

		// Token: 0x0200A594 RID: 42388
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __战斗条件检测_FunctionParams
		{
			// Token: 0x040334E7 RID: 210151
			[FieldOffset(0)]
			public IntPtr 指定进入音效;

			// Token: 0x040334E8 RID: 210152
			[FieldOffset(8)]
			public IntPtr 指定离开音效;
		}

		// Token: 0x0200A595 RID: 42389
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 768)]
		protected ref struct __玩家是否在矩形范围内_FunctionParams
		{
			// Token: 0x040334E9 RID: 210153
			[FieldOffset(0)]
			public bool 玩家是否在范围内;
		}

		// Token: 0x0200A596 RID: 42390
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __播放指定音效_FunctionParams
		{
			// Token: 0x040334EA RID: 210154
			[FieldOffset(0)]
			public IntPtr 指定音效;
		}

		// Token: 0x0200A597 RID: 42391
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __玩家和音源点的距离_FunctionParams
		{
			// Token: 0x040334EB RID: 210155
			[FieldOffset(0)]
			public float 距离;
		}

		// Token: 0x0200A598 RID: 42392
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __绘制方形_FunctionParams
		{
			// Token: 0x040334EC RID: 210156
			[FieldOffset(0)]
			public FTransform 变换;

			// Token: 0x040334ED RID: 210157
			[FieldOffset(48)]
			public float Duration;
		}

		// Token: 0x0200A599 RID: 42393
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __绘制柱形_FunctionParams
		{
			// Token: 0x040334EE RID: 210158
			[FieldOffset(0)]
			public FTransform 变换;

			// Token: 0x040334EF RID: 210159
			[FieldOffset(48)]
			public FLinearColor 颜色;

			// Token: 0x040334F0 RID: 210160
			[FieldOffset(64)]
			public float Duration;
		}

		// Token: 0x0200A59A RID: 42394
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __绘制定点_FunctionParams
		{
			// Token: 0x040334F1 RID: 210161
			[FieldOffset(0)]
			public FTransform 变换;

			// Token: 0x040334F2 RID: 210162
			[FieldOffset(48)]
			public float duration;
		}

		// Token: 0x0200A59B RID: 42395
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __判断是否需要描绘_FunctionParams
		{
			// Token: 0x040334F3 RID: 210163
			[FieldOffset(0)]
			public float DeltaSeconds;

			// Token: 0x040334F4 RID: 210164
			[FieldOffset(4)]
			public bool __Result;
		}

		// Token: 0x0200A59C RID: 42396
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040334F5 RID: 210165
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A59D RID: 42397
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040334F6 RID: 210166
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A59E RID: 42398
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_AudioSpace_FunctionParams
		{
			// Token: 0x040334F7 RID: 210167
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
