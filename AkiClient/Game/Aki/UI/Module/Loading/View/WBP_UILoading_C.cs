using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Loading.View
{
	// Token: 0x0200397B RID: 14715
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/Loading/View/WBP_UILoading.WBP_UILoading_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1340)]
	public class WBP_UILoading_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DA23 RID: 121379 RVA: 0x008DBBF4 File Offset: 0x008D9DF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_UILoading_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Loading/View/WBP_UILoading.WBP_UILoading_C");
			}
			return WBP_UILoading_C._ClassPtr;
		}

		// Token: 0x0601DA24 RID: 121380 RVA: 0x008DBC18 File Offset: 0x008D9E18
		public WBP_UILoading_C() : this(BuiltinUtils.AllocNativeUObject(WBP_UILoading_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DA25 RID: 121381 RVA: 0x008DBC40 File Offset: 0x008D9E40
		[NullableContext(1)]
		public WBP_UILoading_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_UILoading_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170026F9 RID: 9977
		// (get) Token: 0x0601DA26 RID: 121382 RVA: 0x008DBC74 File Offset: 0x008D9E74
		// (set) Token: 0x0601DA27 RID: 121383 RVA: 0x008DBCAD File Offset: 0x008D9EAD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170026FA RID: 9978
		// (get) Token: 0x0601DA28 RID: 121384 RVA: 0x008DBCCE File Offset: 0x008D9ECE
		// (set) Token: 0x0601DA29 RID: 121385 RVA: 0x008DBCE2 File Offset: 0x008D9EE2
		public unsafe UImage Image
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170026FB RID: 9979
		// (get) Token: 0x0601DA2A RID: 121386 RVA: 0x008DBCF7 File Offset: 0x008D9EF7
		// (set) Token: 0x0601DA2B RID: 121387 RVA: 0x008DBD0B File Offset: 0x008D9F0B
		public unsafe UImage Image_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170026FC RID: 9980
		// (get) Token: 0x0601DA2C RID: 121388 RVA: 0x008DBD20 File Offset: 0x008D9F20
		// (set) Token: 0x0601DA2D RID: 121389 RVA: 0x008DBD34 File Offset: 0x008D9F34
		public unsafe UImage Image_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170026FD RID: 9981
		// (get) Token: 0x0601DA2E RID: 121390 RVA: 0x008DBD49 File Offset: 0x008D9F49
		// (set) Token: 0x0601DA2F RID: 121391 RVA: 0x008DBD5D File Offset: 0x008D9F5D
		public unsafe UImage Image_Background
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170026FE RID: 9982
		// (get) Token: 0x0601DA30 RID: 121392 RVA: 0x008DBD72 File Offset: 0x008D9F72
		// (set) Token: 0x0601DA31 RID: 121393 RVA: 0x008DBD86 File Offset: 0x008D9F86
		public unsafe UKuroUMGSafeZone KuroUMGSafeZone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroUMGSafeZone>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170026FF RID: 9983
		// (get) Token: 0x0601DA32 RID: 121394 RVA: 0x008DBD9B File Offset: 0x008D9F9B
		// (set) Token: 0x0601DA33 RID: 121395 RVA: 0x008DBDAF File Offset: 0x008D9FAF
		public unsafe UProgressBar ProgressBar
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProgressBar>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002700 RID: 9984
		// (get) Token: 0x0601DA34 RID: 121396 RVA: 0x008DBDC4 File Offset: 0x008D9FC4
		// (set) Token: 0x0601DA35 RID: 121397 RVA: 0x008DBDD8 File Offset: 0x008D9FD8
		public unsafe UTextBlock ProgressText
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002701 RID: 9985
		// (get) Token: 0x0601DA36 RID: 121398 RVA: 0x008DBDED File Offset: 0x008D9FED
		// (set) Token: 0x0601DA37 RID: 121399 RVA: 0x008DBE01 File Offset: 0x008DA001
		public unsafe UImage TexBg
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002702 RID: 9986
		// (get) Token: 0x0601DA38 RID: 121400 RVA: 0x008DBE16 File Offset: 0x008DA016
		// (set) Token: 0x0601DA39 RID: 121401 RVA: 0x008DBE2A File Offset: 0x008DA02A
		public unsafe UImage TexBgDeco
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002703 RID: 9987
		// (get) Token: 0x0601DA3A RID: 121402 RVA: 0x008DBE3F File Offset: 0x008DA03F
		// (set) Token: 0x0601DA3B RID: 121403 RVA: 0x008DBE53 File Offset: 0x008DA053
		public unsafe UImage TexProgressHandle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002704 RID: 9988
		// (get) Token: 0x0601DA3C RID: 121404 RVA: 0x008DBE68 File Offset: 0x008DA068
		// (set) Token: 0x0601DA3D RID: 121405 RVA: 0x008DBE7C File Offset: 0x008DA07C
		public unsafe UTextBlock Tips
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002705 RID: 9989
		// (get) Token: 0x0601DA3E RID: 121406 RVA: 0x008DBE91 File Offset: 0x008DA091
		// (set) Token: 0x0601DA3F RID: 121407 RVA: 0x008DBEA5 File Offset: 0x008DA0A5
		public unsafe UTextBlock Title
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_UILoading_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002706 RID: 9990
		// (get) Token: 0x0601DA40 RID: 121408 RVA: 0x008DBEBA File Offset: 0x008DA0BA
		// (set) Token: 0x0601DA41 RID: 121409 RVA: 0x008DBECA File Offset: 0x008DA0CA
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002707 RID: 9991
		// (get) Token: 0x0601DA42 RID: 121410 RVA: 0x008DBEDB File Offset: 0x008DA0DB
		// (set) Token: 0x0601DA43 RID: 121411 RVA: 0x008DBEEB File Offset: 0x008DA0EB
		public unsafe float FirstProgressRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002708 RID: 9992
		// (get) Token: 0x0601DA44 RID: 121412 RVA: 0x008DBEFC File Offset: 0x008DA0FC
		// (set) Token: 0x0601DA45 RID: 121413 RVA: 0x008DBF0C File Offset: 0x008DA10C
		public unsafe float SecondeLoadingRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002709 RID: 9993
		// (get) Token: 0x0601DA46 RID: 121414 RVA: 0x008DBF1D File Offset: 0x008DA11D
		// (set) Token: 0x0601DA47 RID: 121415 RVA: 0x008DBF2D File Offset: 0x008DA12D
		public unsafe float FirstSpeedRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700270A RID: 9994
		// (get) Token: 0x0601DA48 RID: 121416 RVA: 0x008DBF3E File Offset: 0x008DA13E
		// (set) Token: 0x0601DA49 RID: 121417 RVA: 0x008DBF4E File Offset: 0x008DA14E
		public unsafe float SecondSpeedRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700270B RID: 9995
		// (get) Token: 0x0601DA4A RID: 121418 RVA: 0x008DBF5F File Offset: 0x008DA15F
		// (set) Token: 0x0601DA4B RID: 121419 RVA: 0x008DBF6F File Offset: 0x008DA16F
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700270C RID: 9996
		// (get) Token: 0x0601DA4C RID: 121420 RVA: 0x008DBF80 File Offset: 0x008DA180
		// (set) Token: 0x0601DA4D RID: 121421 RVA: 0x008DBF90 File Offset: 0x008DA190
		public unsafe float ClampProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700270D RID: 9997
		// (get) Token: 0x0601DA4E RID: 121422 RVA: 0x008DBFA1 File Offset: 0x008DA1A1
		// (set) Token: 0x0601DA4F RID: 121423 RVA: 0x008DBFB1 File Offset: 0x008DA1B1
		public unsafe float SpeedRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700270E RID: 9998
		// (get) Token: 0x0601DA50 RID: 121424 RVA: 0x008DBFC4 File Offset: 0x008DA1C4
		// (set) Token: 0x0601DA51 RID: 121425 RVA: 0x008DBFFD File Offset: 0x008DA1FD
		[Nullable(1)]
		public FInputModeReply UIOnlyInputModeReply
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FInputModeReply result;
				if ((result = this._UIOnlyInputModeReply) == null)
				{
					result = (this._UIOnlyInputModeReply = new FInputModeReply(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_21, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FInputModeReply.StaticStruct(), base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700270F RID: 9999
		// (get) Token: 0x0601DA52 RID: 121426 RVA: 0x008DC01E File Offset: 0x008DA21E
		// (set) Token: 0x0601DA53 RID: 121427 RVA: 0x008DC02E File Offset: 0x008DA22E
		public unsafe float ProgressBarWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_UILoading_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x0601DA54 RID: 121428 RVA: 0x008DC03F File Offset: 0x008DA23F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MoveProgressHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__MoveProgressHandle_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA55 RID: 121429 RVA: 0x008DC053 File Offset: 0x008DA253
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshProgressBarWidth()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__RefreshProgressBarWidth_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA56 RID: 121430 RVA: 0x008DC067 File Offset: 0x008DA267
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RebootFinished()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__RebootFinished_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA57 RID: 121431 RVA: 0x008DC07C File Offset: 0x008DA27C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateOtherLoadingProgerss(float InProgress)
		{
			WBP_UILoading_C.__UpdateOtherLoadingProgerss_FunctionParams* ptr = stackalloc WBP_UILoading_C.__UpdateOtherLoadingProgerss_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(WBP_UILoading_C.__UpdateOtherLoadingProgerss_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_UILoading_C.__UpdateOtherLoadingProgerss_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InProgress = InProgress;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__UpdateOtherLoadingProgerss_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DA58 RID: 121432 RVA: 0x008DC0C4 File Offset: 0x008DA2C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetProgress(float InProgress, float ClampProgress, bool Forece)
		{
			WBP_UILoading_C.__SetProgress_FunctionParams* ptr = stackalloc WBP_UILoading_C.__SetProgress_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(WBP_UILoading_C.__SetProgress_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_UILoading_C.__SetProgress_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InProgress = InProgress;
			ptr->ClampProgress = ClampProgress;
			ptr->Forece = Forece;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__SetProgress_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DA59 RID: 121433 RVA: 0x008DC11C File Offset: 0x008DA31C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_UILoading_C.__Tick_FunctionParams* ptr = stackalloc WBP_UILoading_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_UILoading_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_UILoading_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DA5A RID: 121434 RVA: 0x008DC184 File Offset: 0x008DA384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_UILoading_C.__Tick_FunctionParams* ptr = stackalloc WBP_UILoading_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_UILoading_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_UILoading_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_UILoading_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DA5B RID: 121435 RVA: 0x008DC1ED File Offset: 0x008DA3ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA5C RID: 121436 RVA: 0x008DC201 File Offset: 0x008DA401
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Construct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_UILoading_C.__Construct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DA5D RID: 121437 RVA: 0x008DC216 File Offset: 0x008DA416
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Destruct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_UILoading_C.__Destruct_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA5E RID: 121438 RVA: 0x008DC22A File Offset: 0x008DA42A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Destruct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_UILoading_C.__Destruct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DA5F RID: 121439 RVA: 0x008DC240 File Offset: 0x008DA440
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_UILoading(int EntryPoint)
		{
			WBP_UILoading_C.__ExecuteUbergraph_WBP_UILoading_FunctionParams* ptr = stackalloc WBP_UILoading_C.__ExecuteUbergraph_WBP_UILoading_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(WBP_UILoading_C.__ExecuteUbergraph_WBP_UILoading_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_UILoading_C.__ExecuteUbergraph_WBP_UILoading_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_UILoading_C.__ExecuteUbergraph_WBP_UILoading_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DA60 RID: 121440 RVA: 0x008DC28A File Offset: 0x008DA48A
		protected WBP_UILoading_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E823 RID: 59427
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Loading/View/WBP_UILoading.WBP_UILoading_C";

		// Token: 0x0400E824 RID: 59428
		private static IntPtr _ClassPtr;

		// Token: 0x0400E825 RID: 59429
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E826 RID: 59430
		internal static int __PropertyOffset_0;

		// Token: 0x0400E827 RID: 59431
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E828 RID: 59432
		internal static int __PropertyOffset_1;

		// Token: 0x0400E829 RID: 59433
		internal static int __PropertyOffset_2;

		// Token: 0x0400E82A RID: 59434
		internal static int __PropertyOffset_3;

		// Token: 0x0400E82B RID: 59435
		internal static int __PropertyOffset_4;

		// Token: 0x0400E82C RID: 59436
		internal static int __PropertyOffset_5;

		// Token: 0x0400E82D RID: 59437
		internal static int __PropertyOffset_6;

		// Token: 0x0400E82E RID: 59438
		internal static int __PropertyOffset_7;

		// Token: 0x0400E82F RID: 59439
		internal static int __PropertyOffset_8;

		// Token: 0x0400E830 RID: 59440
		internal static int __PropertyOffset_9;

		// Token: 0x0400E831 RID: 59441
		internal static int __PropertyOffset_10;

		// Token: 0x0400E832 RID: 59442
		internal static int __PropertyOffset_11;

		// Token: 0x0400E833 RID: 59443
		internal static int __PropertyOffset_12;

		// Token: 0x0400E834 RID: 59444
		internal static int __PropertyOffset_13;

		// Token: 0x0400E835 RID: 59445
		internal static int __PropertyOffset_14;

		// Token: 0x0400E836 RID: 59446
		internal static int __PropertyOffset_15;

		// Token: 0x0400E837 RID: 59447
		internal static int __PropertyOffset_16;

		// Token: 0x0400E838 RID: 59448
		internal static int __PropertyOffset_17;

		// Token: 0x0400E839 RID: 59449
		internal static int __PropertyOffset_18;

		// Token: 0x0400E83A RID: 59450
		internal static int __PropertyOffset_19;

		// Token: 0x0400E83B RID: 59451
		internal static int __PropertyOffset_20;

		// Token: 0x0400E83C RID: 59452
		internal static int __PropertyOffset_21;

		// Token: 0x0400E83D RID: 59453
		private FInputModeReply _UIOnlyInputModeReply;

		// Token: 0x0400E83E RID: 59454
		internal static int __PropertyOffset_22;

		// Token: 0x0400E83F RID: 59455
		private static IntPtr __MoveProgressHandle_NativeFunctionPtr;

		// Token: 0x0400E840 RID: 59456
		private static IntPtr __RefreshProgressBarWidth_NativeFunctionPtr;

		// Token: 0x0400E841 RID: 59457
		private static IntPtr __RebootFinished_NativeFunctionPtr;

		// Token: 0x0400E842 RID: 59458
		private static IntPtr __UpdateOtherLoadingProgerss_NativeFunctionPtr;

		// Token: 0x0400E843 RID: 59459
		private static IntPtr __SetProgress_NativeFunctionPtr;

		// Token: 0x0400E844 RID: 59460
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x0400E845 RID: 59461
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x0400E846 RID: 59462
		private static IntPtr __Destruct_NativeFunctionPtr;

		// Token: 0x0400E847 RID: 59463
		private static IntPtr __ExecuteUbergraph_WBP_UILoading_NativeFunctionPtr;

		// Token: 0x020096A7 RID: 38567
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __UpdateOtherLoadingProgerss_FunctionParams
		{
			// Token: 0x04031B75 RID: 203637
			[FieldOffset(0)]
			public float InProgress;
		}

		// Token: 0x020096A8 RID: 38568
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __SetProgress_FunctionParams
		{
			// Token: 0x04031B76 RID: 203638
			[FieldOffset(0)]
			public float InProgress;

			// Token: 0x04031B77 RID: 203639
			[FieldOffset(4)]
			public float ClampProgress;

			// Token: 0x04031B78 RID: 203640
			[FieldOffset(8)]
			public bool Forece;
		}

		// Token: 0x020096A9 RID: 38569
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04031B79 RID: 203641
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04031B7A RID: 203642
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x020096AA RID: 38570
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_WBP_UILoading_FunctionParams
		{
			// Token: 0x04031B7B RID: 203643
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
