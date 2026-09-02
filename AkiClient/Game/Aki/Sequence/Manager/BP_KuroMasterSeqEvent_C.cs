using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Sequence.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043A5 RID: 17317
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class BP_KuroMasterSeqEvent_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602E091 RID: 188561 RVA: 0x00AD4AEC File Offset: 0x00AD2CEC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 启用剧情交互按钮(bool bEnable, string _lock)
		{
			BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_FunctionParams_Hotfix* ptr = stackalloc BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_FunctionParams_Hotfix[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_FunctionParams_Hotfix) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bEnable = bEnable;
			FString.CopyFrom((void*)(&ptr->_lock), _lock);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__启用剧情交互按钮_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E092 RID: 188562 RVA: 0x00AD4B50 File Offset: 0x00AD2D50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroMasterSeqEvent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C");
			}
			return BP_KuroMasterSeqEvent_C._ClassPtr;
		}

		// Token: 0x0602E093 RID: 188563 RVA: 0x00AD4B74 File Offset: 0x00AD2D74
		public BP_KuroMasterSeqEvent_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroMasterSeqEvent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602E094 RID: 188564 RVA: 0x00AD4B9C File Offset: 0x00AD2D9C
		[NullableContext(1)]
		public BP_KuroMasterSeqEvent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroMasterSeqEvent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007EB0 RID: 32432
		// (get) Token: 0x0602E095 RID: 188565 RVA: 0x00AD4BD0 File Offset: 0x00AD2DD0
		// (set) Token: 0x0602E096 RID: 188566 RVA: 0x00AD4C09 File Offset: 0x00AD2E09
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007EB1 RID: 32433
		// (get) Token: 0x0602E097 RID: 188567 RVA: 0x00AD4C2A File Offset: 0x00AD2E2A
		// (set) Token: 0x0602E098 RID: 188568 RVA: 0x00AD4C3E File Offset: 0x00AD2E3E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMasterSeqEvent_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMasterSeqEvent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007EB2 RID: 32434
		// (get) Token: 0x0602E099 RID: 188569 RVA: 0x00AD4C53 File Offset: 0x00AD2E53
		// (set) Token: 0x0602E09A RID: 188570 RVA: 0x00AD4C63 File Offset: 0x00AD2E63
		public unsafe bool ModifiedNearClipPlane
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EB3 RID: 32435
		// (get) Token: 0x0602E09B RID: 188571 RVA: 0x00AD4C74 File Offset: 0x00AD2E74
		// (set) Token: 0x0602E09C RID: 188572 RVA: 0x00AD4CAD File Offset: 0x00AD2EAD
		[Nullable(1)]
		public OnScreenShotFade OnScreenShotFade
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnScreenShotFade result;
				if ((result = this._OnScreenShotFade) == null)
				{
					result = (this._OnScreenShotFade = new OnScreenShotFade(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_3, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17007EB4 RID: 32436
		// (get) Token: 0x0602E09D RID: 188573 RVA: 0x00AD4CCE File Offset: 0x00AD2ECE
		// (set) Token: 0x0602E09E RID: 188574 RVA: 0x00AD4CDE File Offset: 0x00AD2EDE
		public unsafe int DelayMerge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007EB5 RID: 32437
		// (get) Token: 0x0602E09F RID: 188575 RVA: 0x00AD4CEF File Offset: 0x00AD2EEF
		// (set) Token: 0x0602E0A0 RID: 188576 RVA: 0x00AD4CFF File Offset: 0x00AD2EFF
		public unsafe float Icon透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007EB6 RID: 32438
		// (get) Token: 0x0602E0A1 RID: 188577 RVA: 0x00AD4D10 File Offset: 0x00AD2F10
		// (set) Token: 0x0602E0A2 RID: 188578 RVA: 0x00AD4D20 File Offset: 0x00AD2F20
		public unsafe float Icon遮罩透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007EB7 RID: 32439
		// (get) Token: 0x0602E0A3 RID: 188579 RVA: 0x00AD4D31 File Offset: 0x00AD2F31
		// (set) Token: 0x0602E0A4 RID: 188580 RVA: 0x00AD4D41 File Offset: 0x00AD2F41
		public unsafe int counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMasterSeqEvent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602E0A5 RID: 188581 RVA: 0x00AD4D54 File Offset: 0x00AD2F54
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 触发LGUI动效([Nullable(2)] AActor UIActor, string SequenceName)
		{
			BP_KuroMasterSeqEvent_C.__触发LGUI动效_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__触发LGUI动效_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__触发LGUI动效_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__触发LGUI动效_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UIActor = ((UIActor != null) ? UIActor.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->SequenceName), SequenceName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__触发LGUI动效_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__触发LGUI动效_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0A6 RID: 188582 RVA: 0x00AD4DC8 File Offset: 0x00AD2FC8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 相机振动(bool 启用, TSoftClassPtr<UMatineeCameraShake> 资产)
		{
			BP_KuroMasterSeqEvent_C.__相机振动_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__相机振动_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__相机振动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__相机振动_NativeFunctionPtr, (void*)ptr, 1);
			ptr->启用 = 启用;
			if (资产 != null)
			{
				FSoftObjectPtr.NativeCopy(&ptr->资产, 资产.NativePtr, 1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__相机振动_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__相机振动_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0A7 RID: 188583 RVA: 0x00AD4E3C File Offset: 0x00AD303C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 打开报幕界面(string uiPrefabId, float duration, string uiStartAnimName, string uiEndAnimName)
		{
			BP_KuroMasterSeqEvent_C.__打开报幕界面_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__打开报幕界面_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__打开报幕界面_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__打开报幕界面_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->uiPrefabId), uiPrefabId);
			ptr->duration = duration;
			FString.CopyFrom((void*)(&ptr->uiStartAnimName), uiStartAnimName);
			FString.CopyFrom((void*)(&ptr->uiEndAnimName), uiEndAnimName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__打开报幕界面_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__打开报幕界面_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0A8 RID: 188584 RVA: 0x00AD4EBC File Offset: 0x00AD30BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 绑定物品检视Actor(FMovieSceneObjectBindingID binding)
		{
			BP_KuroMasterSeqEvent_C.__绑定物品检视Actor_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__绑定物品检视Actor_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__绑定物品检视Actor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__绑定物品检视Actor_NativeFunctionPtr, (void*)ptr, 1);
			if (binding != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FMovieSceneObjectBindingID.StaticStruct(), &ptr->binding, binding.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__绑定物品检视Actor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0A9 RID: 188585 RVA: 0x00AD4F1D File Offset: 0x00AD311D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 额外Seq停止()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__额外Seq停止_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0AA RID: 188586 RVA: 0x00AD4F34 File Offset: 0x00AD3134
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 额外Seq播放(ULevelSequence Seq, FName componentName, FName boneName, float frame)
		{
			BP_KuroMasterSeqEvent_C.__额外Seq播放_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__额外Seq播放_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__额外Seq播放_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__额外Seq播放_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Seq = ((Seq != null) ? Seq.NativePtr : IntPtr.Zero);
			ptr->componentName = componentName;
			ptr->boneName = boneName;
			ptr->frame = frame;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__额外Seq播放_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0AB RID: 188587 RVA: 0x00AD4FA0 File Offset: 0x00AD31A0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 背景Icon(bool 显示, UTexture2D Icon)
		{
			BP_KuroMasterSeqEvent_C.__背景Icon_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__背景Icon_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__背景Icon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__背景Icon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->显示 = 显示;
			ptr->Icon = ((Icon != null) ? Icon.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__背景Icon_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0AC RID: 188588 RVA: 0x00AD4FFC File Offset: 0x00AD31FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 关闭Spine动画_数组_([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> spineArray)
		{
			BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__NativeFunctionPtr, (void*)ptr, 1);
			TArray<string> tarray = spineArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->spineArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__NativeFunctionPtr, (void*)ptr);
			TArray<string> tarray2 = spineArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->spineArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__关闭Spine动画_数组__NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0AD RID: 188589 RVA: 0x00AD5074 File Offset: 0x00AD3274
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 关闭Spine动画(string spineName)
		{
			BP_KuroMasterSeqEvent_C.__关闭Spine动画_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__关闭Spine动画_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__关闭Spine动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__关闭Spine动画_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->spineName), spineName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__关闭Spine动画_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__关闭Spine动画_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0AE RID: 188590 RVA: 0x00AD50D4 File Offset: 0x00AD32D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放Spine动画_数组_([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SpineThingsInfo> maleSpineArray, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SpineThingsInfo> femaleSpineArray)
		{
			BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__NativeFunctionPtr, (void*)ptr, 1);
			TArray<SpineThingsInfo> tarray = maleSpineArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->maleSpineArray);
			}
			TArray<SpineThingsInfo> tarray2 = femaleSpineArray;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->femaleSpineArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__NativeFunctionPtr, (void*)ptr);
			TArray<SpineThingsInfo> tarray3 = maleSpineArray;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->maleSpineArray);
			}
			TArray<SpineThingsInfo> tarray4 = femaleSpineArray;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->femaleSpineArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_数组__NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0AF RID: 188591 RVA: 0x00AD5174 File Offset: 0x00AD3374
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放Spine动画_性别_(string maleSpineName1, string femaleSpineName1, bool needLoop)
		{
			BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->maleSpineName1), maleSpineName1);
			FString.CopyFrom((void*)(&ptr->femaleSpineName1), femaleSpineName1);
			ptr->needLoop = needLoop;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_性别__NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B0 RID: 188592 RVA: 0x00AD51E8 File Offset: 0x00AD33E8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放Spine动画(string SpineName, bool needLoop)
		{
			BP_KuroMasterSeqEvent_C.__播放Spine动画_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__播放Spine动画_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__播放Spine动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SpineName), SpineName);
			ptr->needLoop = needLoop;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__播放Spine动画_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__播放Spine动画_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B1 RID: 188593 RVA: 0x00AD524C File Offset: 0x00AD344C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 执行实体帧事件(string Key, int EntityId)
		{
			BP_KuroMasterSeqEvent_C.__执行实体帧事件_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__执行实体帧事件_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__执行实体帧事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__执行实体帧事件_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Key), Key);
			ptr->EntityId = EntityId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__执行实体帧事件_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__执行实体帧事件_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B2 RID: 188594 RVA: 0x00AD52B0 File Offset: 0x00AD34B0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放预览图动画(string seqName)
		{
			BP_KuroMasterSeqEvent_C.__播放预览图动画_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__播放预览图动画_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__播放预览图动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__播放预览图动画_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->seqName), seqName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__播放预览图动画_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__播放预览图动画_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B3 RID: 188595 RVA: 0x00AD530D File Offset: 0x00AD350D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 关闭预览图()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__关闭预览图_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0B4 RID: 188596 RVA: 0x00AD5324 File Offset: 0x00AD3524
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 显示预览图_数组_(string MaleAssetPath, string FemaleAssetPath, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SpineThingsInfo> maleSpineArray, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SpineThingsInfo> femaleSpineArray, bool useFullscreenAdaptAnchor)
		{
			BP_KuroMasterSeqEvent_C.__显示预览图_数组__FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__显示预览图_数组__FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__显示预览图_数组__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__显示预览图_数组__NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaleAssetPath), MaleAssetPath);
			FString.CopyFrom((void*)(&ptr->FemaleAssetPath), FemaleAssetPath);
			TArray<SpineThingsInfo> tarray = maleSpineArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->maleSpineArray);
			}
			TArray<SpineThingsInfo> tarray2 = femaleSpineArray;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->femaleSpineArray);
			}
			ptr->useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__显示预览图_数组__NativeFunctionPtr, (void*)ptr);
			TArray<SpineThingsInfo> tarray3 = maleSpineArray;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->maleSpineArray);
			}
			TArray<SpineThingsInfo> tarray4 = femaleSpineArray;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->femaleSpineArray);
			}
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__显示预览图_数组__NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B5 RID: 188597 RVA: 0x00AD53E8 File Offset: 0x00AD35E8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 显示预览图(string MaleAssetPath, string FemaleAssetPath, string maleSpineName, string femaleSpineName, bool needLoop, bool useFullscreenAdaptAnchor)
		{
			BP_KuroMasterSeqEvent_C.__显示预览图_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__显示预览图_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__显示预览图_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__显示预览图_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaleAssetPath), MaleAssetPath);
			FString.CopyFrom((void*)(&ptr->FemaleAssetPath), FemaleAssetPath);
			FString.CopyFrom((void*)(&ptr->maleSpineName), maleSpineName);
			FString.CopyFrom((void*)(&ptr->femaleSpineName), femaleSpineName);
			ptr->needLoop = needLoop;
			ptr->useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__显示预览图_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__显示预览图_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0B6 RID: 188598 RVA: 0x00AD5480 File Offset: 0x00AD3680
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 展示游戏Logo(float time)
		{
			BP_KuroMasterSeqEvent_C.__展示游戏Logo_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__展示游戏Logo_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__展示游戏Logo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__展示游戏Logo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__展示游戏Logo_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0B7 RID: 188599 RVA: 0x00AD54C8 File Offset: 0x00AD36C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 打开章节提示(int ChapterState, int ChapterId)
		{
			BP_KuroMasterSeqEvent_C.__打开章节提示_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__打开章节提示_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__打开章节提示_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__打开章节提示_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ChapterState = ChapterState;
			ptr->ChapterId = ChapterId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__打开章节提示_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0B8 RID: 188600 RVA: 0x00AD5515 File Offset: 0x00AD3715
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 触发切镜()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__触发切镜_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0B9 RID: 188601 RVA: 0x00AD5529 File Offset: 0x00AD3729
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 开始叠化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__开始叠化_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0BA RID: 188602 RVA: 0x00AD5540 File Offset: 0x00AD3740
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 执行流程行为(string key)
		{
			BP_KuroMasterSeqEvent_C.__执行流程行为_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__执行流程行为_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__执行流程行为_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__执行流程行为_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->key), key);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__执行流程行为_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroMasterSeqEvent_C.__执行流程行为_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602E0BB RID: 188603 RVA: 0x00AD55A0 File Offset: 0x00AD37A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 开关人物飘带(bool enable)
		{
			BP_KuroMasterSeqEvent_C.__开关人物飘带_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__开关人物飘带_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__开关人物飘带_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__开关人物飘带_NativeFunctionPtr, (void*)ptr, 1);
			ptr->enable = enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__开关人物飘带_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0BC RID: 188604 RVA: 0x00AD55E6 File Offset: 0x00AD37E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 恢复镜头裁剪距离()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__恢复镜头裁剪距离_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0BD RID: 188605 RVA: 0x00AD55FC File Offset: 0x00AD37FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 调整镜头裁剪距离(int NearClip)
		{
			BP_KuroMasterSeqEvent_C.__调整镜头裁剪距离_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__调整镜头裁剪距离_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__调整镜头裁剪距离_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__调整镜头裁剪距离_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NearClip = NearClip;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__调整镜头裁剪距离_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0BE RID: 188606 RVA: 0x00AD5642 File Offset: 0x00AD3842
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 副触发切镜()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__副触发切镜_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0BF RID: 188607 RVA: 0x00AD5658 File Offset: 0x00AD3858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 主触发切镜(bool shouldBlend, float blendTime, EViewTargetBlendFunction blendFunction, float blendExp)
		{
			BP_KuroMasterSeqEvent_C.__主触发切镜_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__主触发切镜_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__主触发切镜_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__主触发切镜_NativeFunctionPtr, (void*)ptr, 1);
			ptr->shouldBlend = shouldBlend;
			ptr->blendTime = blendTime;
			ptr->blendFunction = blendFunction;
			ptr->blendExp = blendExp;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__主触发切镜_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0C0 RID: 188608 RVA: 0x00AD56B9 File Offset: 0x00AD38B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 启用动态模糊()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__启用动态模糊_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0C1 RID: 188609 RVA: 0x00AD56CD File Offset: 0x00AD38CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 禁用动态模糊()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__禁用动态模糊_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0C2 RID: 188610 RVA: 0x00AD56E4 File Offset: 0x00AD38E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602E0C3 RID: 188611 RVA: 0x00AD572C File Offset: 0x00AD392C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E0C4 RID: 188612 RVA: 0x00AD5773 File Offset: 0x00AD3973
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0602E0C5 RID: 188613 RVA: 0x00AD5787 File Offset: 0x00AD3987
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602E0C6 RID: 188614 RVA: 0x00AD579C File Offset: 0x00AD399C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroMasterSeqEvent(int EntryPoint)
		{
			BP_KuroMasterSeqEvent_C.__ExecuteUbergraph_BP_KuroMasterSeqEvent_FunctionParams* ptr = stackalloc BP_KuroMasterSeqEvent_C.__ExecuteUbergraph_BP_KuroMasterSeqEvent_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_KuroMasterSeqEvent_C.__ExecuteUbergraph_BP_KuroMasterSeqEvent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMasterSeqEvent_C.__ExecuteUbergraph_BP_KuroMasterSeqEvent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMasterSeqEvent_C.__ExecuteUbergraph_BP_KuroMasterSeqEvent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602E0C7 RID: 188615 RVA: 0x00AD57E3 File Offset: 0x00AD39E3
		protected BP_KuroMasterSeqEvent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401A03E RID: 106558
		private static IntPtr __启用剧情交互按钮_NativeFunctionPtr;

		// Token: 0x0401A03F RID: 106559
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C";

		// Token: 0x0401A040 RID: 106560
		private static IntPtr _ClassPtr;

		// Token: 0x0401A041 RID: 106561
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401A042 RID: 106562
		public static IntPtr __OnScreenShotFade__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401A043 RID: 106563
		internal static int __PropertyOffset_0;

		// Token: 0x0401A044 RID: 106564
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401A045 RID: 106565
		internal static int __PropertyOffset_1;

		// Token: 0x0401A046 RID: 106566
		internal static int __PropertyOffset_2;

		// Token: 0x0401A047 RID: 106567
		internal static int __PropertyOffset_3;

		// Token: 0x0401A048 RID: 106568
		[Nullable(2)]
		private OnScreenShotFade _OnScreenShotFade;

		// Token: 0x0401A049 RID: 106569
		internal static int __PropertyOffset_4;

		// Token: 0x0401A04A RID: 106570
		internal static int __PropertyOffset_5;

		// Token: 0x0401A04B RID: 106571
		internal static int __PropertyOffset_6;

		// Token: 0x0401A04C RID: 106572
		internal static int __PropertyOffset_7;

		// Token: 0x0401A04D RID: 106573
		private static IntPtr __触发LGUI动效_NativeFunctionPtr;

		// Token: 0x0401A04E RID: 106574
		private static IntPtr __相机振动_NativeFunctionPtr;

		// Token: 0x0401A04F RID: 106575
		private static IntPtr __打开报幕界面_NativeFunctionPtr;

		// Token: 0x0401A050 RID: 106576
		private static IntPtr __绑定物品检视Actor_NativeFunctionPtr;

		// Token: 0x0401A051 RID: 106577
		private static IntPtr __额外Seq停止_NativeFunctionPtr;

		// Token: 0x0401A052 RID: 106578
		private static IntPtr __额外Seq播放_NativeFunctionPtr;

		// Token: 0x0401A053 RID: 106579
		private static IntPtr __背景Icon_NativeFunctionPtr;

		// Token: 0x0401A054 RID: 106580
		private static IntPtr __关闭Spine动画_数组__NativeFunctionPtr;

		// Token: 0x0401A055 RID: 106581
		private static IntPtr __关闭Spine动画_NativeFunctionPtr;

		// Token: 0x0401A056 RID: 106582
		private static IntPtr __播放Spine动画_数组__NativeFunctionPtr;

		// Token: 0x0401A057 RID: 106583
		private static IntPtr __播放Spine动画_性别__NativeFunctionPtr;

		// Token: 0x0401A058 RID: 106584
		private static IntPtr __播放Spine动画_NativeFunctionPtr;

		// Token: 0x0401A059 RID: 106585
		private static IntPtr __执行实体帧事件_NativeFunctionPtr;

		// Token: 0x0401A05A RID: 106586
		private static IntPtr __播放预览图动画_NativeFunctionPtr;

		// Token: 0x0401A05B RID: 106587
		private static IntPtr __关闭预览图_NativeFunctionPtr;

		// Token: 0x0401A05C RID: 106588
		private static IntPtr __显示预览图_数组__NativeFunctionPtr;

		// Token: 0x0401A05D RID: 106589
		private static IntPtr __显示预览图_NativeFunctionPtr;

		// Token: 0x0401A05E RID: 106590
		private static IntPtr __展示游戏Logo_NativeFunctionPtr;

		// Token: 0x0401A05F RID: 106591
		private static IntPtr __打开章节提示_NativeFunctionPtr;

		// Token: 0x0401A060 RID: 106592
		private static IntPtr __触发切镜_NativeFunctionPtr;

		// Token: 0x0401A061 RID: 106593
		private static IntPtr __开始叠化_NativeFunctionPtr;

		// Token: 0x0401A062 RID: 106594
		private static IntPtr __执行流程行为_NativeFunctionPtr;

		// Token: 0x0401A063 RID: 106595
		private static IntPtr __开关人物飘带_NativeFunctionPtr;

		// Token: 0x0401A064 RID: 106596
		private static IntPtr __恢复镜头裁剪距离_NativeFunctionPtr;

		// Token: 0x0401A065 RID: 106597
		private static IntPtr __调整镜头裁剪距离_NativeFunctionPtr;

		// Token: 0x0401A066 RID: 106598
		private static IntPtr __副触发切镜_NativeFunctionPtr;

		// Token: 0x0401A067 RID: 106599
		private static IntPtr __主触发切镜_NativeFunctionPtr;

		// Token: 0x0401A068 RID: 106600
		private static IntPtr __启用动态模糊_NativeFunctionPtr;

		// Token: 0x0401A069 RID: 106601
		private static IntPtr __禁用动态模糊_NativeFunctionPtr;

		// Token: 0x0401A06A RID: 106602
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401A06B RID: 106603
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0401A06C RID: 106604
		private static IntPtr __ExecuteUbergraph_BP_KuroMasterSeqEvent_NativeFunctionPtr;

		// Token: 0x0200A60D RID: 42509
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __启用剧情交互按钮_FunctionParams_Hotfix
		{
			// Token: 0x040335DF RID: 210399
			[FieldOffset(0)]
			public bool bEnable;

			// Token: 0x040335E0 RID: 210400
			[FieldOffset(8)]
			public FString _lock;
		}

		// Token: 0x0200A60E RID: 42510
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __触发LGUI动效_FunctionParams
		{
			// Token: 0x040335E1 RID: 210401
			[FieldOffset(0)]
			public IntPtr UIActor;

			// Token: 0x040335E2 RID: 210402
			[FieldOffset(8)]
			public FString SequenceName;
		}

		// Token: 0x0200A60F RID: 42511
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __相机振动_FunctionParams
		{
			// Token: 0x040335E3 RID: 210403
			[FieldOffset(0)]
			public bool 启用;

			// Token: 0x040335E4 RID: 210404
			[FieldOffset(8)]
			public byte 资产;
		}

		// Token: 0x0200A610 RID: 42512
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __打开报幕界面_FunctionParams
		{
			// Token: 0x040335E5 RID: 210405
			[FieldOffset(0)]
			public FString uiPrefabId;

			// Token: 0x040335E6 RID: 210406
			[FieldOffset(16)]
			public float duration;

			// Token: 0x040335E7 RID: 210407
			[FieldOffset(24)]
			public FString uiStartAnimName;

			// Token: 0x040335E8 RID: 210408
			[FieldOffset(40)]
			public FString uiEndAnimName;
		}

		// Token: 0x0200A611 RID: 42513
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __绑定物品检视Actor_FunctionParams
		{
			// Token: 0x040335E9 RID: 210409
			[FieldOffset(0)]
			public byte binding;
		}

		// Token: 0x0200A612 RID: 42514
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __额外Seq播放_FunctionParams
		{
			// Token: 0x040335EA RID: 210410
			[FieldOffset(0)]
			public IntPtr Seq;

			// Token: 0x040335EB RID: 210411
			[FieldOffset(8)]
			public FName componentName;

			// Token: 0x040335EC RID: 210412
			[FieldOffset(20)]
			public FName boneName;

			// Token: 0x040335ED RID: 210413
			[FieldOffset(32)]
			public float frame;
		}

		// Token: 0x0200A613 RID: 42515
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __背景Icon_FunctionParams
		{
			// Token: 0x040335EE RID: 210414
			[FieldOffset(0)]
			public bool 显示;

			// Token: 0x040335EF RID: 210415
			[FieldOffset(8)]
			public IntPtr Icon;
		}

		// Token: 0x0200A614 RID: 42516
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __关闭Spine动画_数组__FunctionParams
		{
			// Token: 0x040335F0 RID: 210416
			[FieldOffset(0)]
			public byte spineArray;
		}

		// Token: 0x0200A615 RID: 42517
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __关闭Spine动画_FunctionParams
		{
			// Token: 0x040335F1 RID: 210417
			[FieldOffset(0)]
			public FString spineName;
		}

		// Token: 0x0200A616 RID: 42518
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __播放Spine动画_数组__FunctionParams
		{
			// Token: 0x040335F2 RID: 210418
			[FieldOffset(0)]
			public byte maleSpineArray;

			// Token: 0x040335F3 RID: 210419
			[FieldOffset(16)]
			public byte femaleSpineArray;
		}

		// Token: 0x0200A617 RID: 42519
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __播放Spine动画_性别__FunctionParams
		{
			// Token: 0x040335F4 RID: 210420
			[FieldOffset(0)]
			public FString maleSpineName1;

			// Token: 0x040335F5 RID: 210421
			[FieldOffset(16)]
			public FString femaleSpineName1;

			// Token: 0x040335F6 RID: 210422
			[FieldOffset(32)]
			public bool needLoop;
		}

		// Token: 0x0200A618 RID: 42520
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __播放Spine动画_FunctionParams
		{
			// Token: 0x040335F7 RID: 210423
			[FieldOffset(0)]
			public FString SpineName;

			// Token: 0x040335F8 RID: 210424
			[FieldOffset(16)]
			public bool needLoop;
		}

		// Token: 0x0200A619 RID: 42521
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __执行实体帧事件_FunctionParams
		{
			// Token: 0x040335F9 RID: 210425
			[FieldOffset(0)]
			public FString Key;

			// Token: 0x040335FA RID: 210426
			[FieldOffset(16)]
			public int EntityId;
		}

		// Token: 0x0200A61A RID: 42522
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __播放预览图动画_FunctionParams
		{
			// Token: 0x040335FB RID: 210427
			[FieldOffset(0)]
			public FString seqName;
		}

		// Token: 0x0200A61B RID: 42523
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __显示预览图_数组__FunctionParams
		{
			// Token: 0x040335FC RID: 210428
			[FieldOffset(0)]
			public FString MaleAssetPath;

			// Token: 0x040335FD RID: 210429
			[FieldOffset(16)]
			public FString FemaleAssetPath;

			// Token: 0x040335FE RID: 210430
			[FieldOffset(32)]
			public byte maleSpineArray;

			// Token: 0x040335FF RID: 210431
			[FieldOffset(48)]
			public byte femaleSpineArray;

			// Token: 0x04033600 RID: 210432
			[FieldOffset(64)]
			public bool useFullscreenAdaptAnchor;
		}

		// Token: 0x0200A61C RID: 42524
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __显示预览图_FunctionParams
		{
			// Token: 0x04033601 RID: 210433
			[FieldOffset(0)]
			public FString MaleAssetPath;

			// Token: 0x04033602 RID: 210434
			[FieldOffset(16)]
			public FString FemaleAssetPath;

			// Token: 0x04033603 RID: 210435
			[FieldOffset(32)]
			public FString maleSpineName;

			// Token: 0x04033604 RID: 210436
			[FieldOffset(48)]
			public FString femaleSpineName;

			// Token: 0x04033605 RID: 210437
			[FieldOffset(64)]
			public bool needLoop;

			// Token: 0x04033606 RID: 210438
			[FieldOffset(65)]
			public bool useFullscreenAdaptAnchor;
		}

		// Token: 0x0200A61D RID: 42525
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __展示游戏Logo_FunctionParams
		{
			// Token: 0x04033607 RID: 210439
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A61E RID: 42526
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __打开章节提示_FunctionParams
		{
			// Token: 0x04033608 RID: 210440
			[FieldOffset(0)]
			public int ChapterState;

			// Token: 0x04033609 RID: 210441
			[FieldOffset(4)]
			public int ChapterId;
		}

		// Token: 0x0200A61F RID: 42527
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __执行流程行为_FunctionParams
		{
			// Token: 0x0403360A RID: 210442
			[FieldOffset(0)]
			public FString key;
		}

		// Token: 0x0200A620 RID: 42528
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __开关人物飘带_FunctionParams
		{
			// Token: 0x0403360B RID: 210443
			[FieldOffset(0)]
			public bool enable;
		}

		// Token: 0x0200A621 RID: 42529
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __调整镜头裁剪距离_FunctionParams
		{
			// Token: 0x0403360C RID: 210444
			[FieldOffset(0)]
			public int NearClip;
		}

		// Token: 0x0200A622 RID: 42530
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __主触发切镜_FunctionParams
		{
			// Token: 0x0403360D RID: 210445
			[FieldOffset(0)]
			public bool shouldBlend;

			// Token: 0x0403360E RID: 210446
			[FieldOffset(4)]
			public float blendTime;

			// Token: 0x0403360F RID: 210447
			[FieldOffset(8)]
			public TEnumAsByte<EViewTargetBlendFunction> blendFunction;

			// Token: 0x04033610 RID: 210448
			[FieldOffset(12)]
			public float blendExp;
		}

		// Token: 0x0200A623 RID: 42531
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04033611 RID: 210449
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A624 RID: 42532
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_KuroMasterSeqEvent_FunctionParams
		{
			// Token: 0x04033612 RID: 210450
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
