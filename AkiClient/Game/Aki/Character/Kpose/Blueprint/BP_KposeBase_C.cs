using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Kpose.Blueprint
{
	// Token: 0x020041A2 RID: 16802
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Kpose/Blueprint/BP_KposeBase.BP_KposeBase_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1680)]
	public class BP_KposeBase_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C97E RID: 182654 RVA: 0x00AA763C File Offset: 0x00AA583C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KposeBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Kpose/Blueprint/BP_KposeBase.BP_KposeBase_C");
			}
			return BP_KposeBase_C._ClassPtr;
		}

		// Token: 0x0602C97F RID: 182655 RVA: 0x00AA7660 File Offset: 0x00AA5860
		public BP_KposeBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_KposeBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C980 RID: 182656 RVA: 0x00AA7688 File Offset: 0x00AA5888
		public BP_KposeBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KposeBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007832 RID: 30770
		// (get) Token: 0x0602C981 RID: 182657 RVA: 0x00AA76BC File Offset: 0x00AA58BC
		// (set) Token: 0x0602C982 RID: 182658 RVA: 0x00AA76F5 File Offset: 0x00AA58F5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007833 RID: 30771
		// (get) Token: 0x0602C983 RID: 182659 RVA: 0x00AA7716 File Offset: 0x00AA5916
		// (set) Token: 0x0602C984 RID: 182660 RVA: 0x00AA772A File Offset: 0x00AA592A
		[Nullable(2)]
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007834 RID: 30772
		// (get) Token: 0x0602C985 RID: 182661 RVA: 0x00AA773F File Offset: 0x00AA593F
		// (set) Token: 0x0602C986 RID: 182662 RVA: 0x00AA7753 File Offset: 0x00AA5953
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007835 RID: 30773
		// (get) Token: 0x0602C987 RID: 182663 RVA: 0x00AA7768 File Offset: 0x00AA5968
		// (set) Token: 0x0602C988 RID: 182664 RVA: 0x00AA77A1 File Offset: 0x00AA59A1
		public TArray<SKposeEffect> PermanentEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SKposeEffect> result;
				if ((result = this._PermanentEffects) == null)
				{
					result = (this._PermanentEffects = new TArray<SKposeEffect>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.PermanentEffects.CopyAssign(value);
			}
		}

		// Token: 0x17007836 RID: 30774
		// (get) Token: 0x0602C989 RID: 182665 RVA: 0x00AA77B0 File Offset: 0x00AA59B0
		// (set) Token: 0x0602C98A RID: 182666 RVA: 0x00AA77E9 File Offset: 0x00AA59E9
		public TArray<SKposeEffect> EffectsOnEnd
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SKposeEffect> result;
				if ((result = this._EffectsOnEnd) == null)
				{
					result = (this._EffectsOnEnd = new TArray<SKposeEffect>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.EffectsOnEnd.CopyAssign(value);
			}
		}

		// Token: 0x17007837 RID: 30775
		// (get) Token: 0x0602C98B RID: 182667 RVA: 0x00AA77F8 File Offset: 0x00AA59F8
		// (set) Token: 0x0602C98C RID: 182668 RVA: 0x00AA7831 File Offset: 0x00AA5A31
		public TArray<SKposeEffect> EffectsOnStart
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SKposeEffect> result;
				if ((result = this._EffectsOnStart) == null)
				{
					result = (this._EffectsOnStart = new TArray<SKposeEffect>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.EffectsOnStart.CopyAssign(value);
			}
		}

		// Token: 0x17007838 RID: 30776
		// (get) Token: 0x0602C98D RID: 182669 RVA: 0x00AA7840 File Offset: 0x00AA5A40
		// (set) Token: 0x0602C98E RID: 182670 RVA: 0x00AA7879 File Offset: 0x00AA5A79
		public TArray<FKuroRainMaterialFloatParameter> FloatParameterCurves
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroRainMaterialFloatParameter> result;
				if ((result = this._FloatParameterCurves) == null)
				{
					result = (this._FloatParameterCurves = new TArray<FKuroRainMaterialFloatParameter>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.FloatParameterCurves.CopyAssign(value);
			}
		}

		// Token: 0x17007839 RID: 30777
		// (get) Token: 0x0602C98F RID: 182671 RVA: 0x00AA7888 File Offset: 0x00AA5A88
		// (set) Token: 0x0602C990 RID: 182672 RVA: 0x00AA78C1 File Offset: 0x00AA5AC1
		public TArray<FKuroRainMaterialColorParameter> ColorParameterCurves
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroRainMaterialColorParameter> result;
				if ((result = this._ColorParameterCurves) == null)
				{
					result = (this._ColorParameterCurves = new TArray<FKuroRainMaterialColorParameter>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.ColorParameterCurves.CopyAssign(value);
			}
		}

		// Token: 0x1700783A RID: 30778
		// (get) Token: 0x0602C991 RID: 182673 RVA: 0x00AA78CF File Offset: 0x00AA5ACF
		// (set) Token: 0x0602C992 RID: 182674 RVA: 0x00AA78DF File Offset: 0x00AA5ADF
		public unsafe bool IsInEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700783B RID: 30779
		// (get) Token: 0x0602C993 RID: 182675 RVA: 0x00AA78F0 File Offset: 0x00AA5AF0
		// (set) Token: 0x0602C994 RID: 182676 RVA: 0x00AA7900 File Offset: 0x00AA5B00
		public unsafe float MaterialPlayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700783C RID: 30780
		// (get) Token: 0x0602C995 RID: 182677 RVA: 0x00AA7914 File Offset: 0x00AA5B14
		// (set) Token: 0x0602C996 RID: 182678 RVA: 0x00AA794D File Offset: 0x00AA5B4D
		public TArray<int> CachedHandles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._CachedHandles) == null)
				{
					result = (this._CachedHandles = new TArray<int>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.CachedHandles.CopyAssign(value);
			}
		}

		// Token: 0x1700783D RID: 30781
		// (get) Token: 0x0602C997 RID: 182679 RVA: 0x00AA795C File Offset: 0x00AA5B5C
		// (set) Token: 0x0602C998 RID: 182680 RVA: 0x00AA7995 File Offset: 0x00AA5B95
		public TArray<UMaterialInstanceDynamic> DynamicMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DynamicMaterials) == null)
				{
					result = (this._DynamicMaterials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.DynamicMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700783E RID: 30782
		// (get) Token: 0x0602C999 RID: 182681 RVA: 0x00AA79A3 File Offset: 0x00AA5BA3
		// (set) Token: 0x0602C99A RID: 182682 RVA: 0x00AA79B3 File Offset: 0x00AA5BB3
		public unsafe float PassTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700783F RID: 30783
		// (get) Token: 0x0602C99B RID: 182683 RVA: 0x00AA79C4 File Offset: 0x00AA5BC4
		// (set) Token: 0x0602C99C RID: 182684 RVA: 0x00AA79FD File Offset: 0x00AA5BFD
		public TMap<FName, float> TempFloatValue
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._TempFloatValue) == null)
				{
					result = (this._TempFloatValue = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.TempFloatValue.CopyAssign(value);
			}
		}

		// Token: 0x17007840 RID: 30784
		// (get) Token: 0x0602C99D RID: 182685 RVA: 0x00AA7A0C File Offset: 0x00AA5C0C
		// (set) Token: 0x0602C99E RID: 182686 RVA: 0x00AA7A45 File Offset: 0x00AA5C45
		public TMap<FName, FLinearColor> TempColorValue
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._TempColorValue) == null)
				{
					result = (this._TempColorValue = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.TempColorValue.CopyAssign(value);
			}
		}

		// Token: 0x17007841 RID: 30785
		// (get) Token: 0x0602C99F RID: 182687 RVA: 0x00AA7A53 File Offset: 0x00AA5C53
		// (set) Token: 0x0602C9A0 RID: 182688 RVA: 0x00AA7A63 File Offset: 0x00AA5C63
		public unsafe float TimeNormalized
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007842 RID: 30786
		// (get) Token: 0x0602C9A1 RID: 182689 RVA: 0x00AA7A74 File Offset: 0x00AA5C74
		// (set) Token: 0x0602C9A2 RID: 182690 RVA: 0x00AA7A88 File Offset: 0x00AA5C88
		[Nullable(2)]
		public unsafe UStaticMesh PlatformStaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17007843 RID: 30787
		// (get) Token: 0x0602C9A3 RID: 182691 RVA: 0x00AA7A9D File Offset: 0x00AA5C9D
		// (set) Token: 0x0602C9A4 RID: 182692 RVA: 0x00AA7AB1 File Offset: 0x00AA5CB1
		[Nullable(0)]
		public unsafe TEnumAsByte<BP_Enum_PlatformSize> Size
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_17);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007844 RID: 30788
		// (get) Token: 0x0602C9A5 RID: 182693 RVA: 0x00AA7AC6 File Offset: 0x00AA5CC6
		// (set) Token: 0x0602C9A6 RID: 182694 RVA: 0x00AA7ADA File Offset: 0x00AA5CDA
		public unsafe string MaterialPrefix1_不可修改_
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_KposeBase_C.__PropertyOffset_18)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_KposeBase_C.__PropertyOffset_18)), value);
			}
		}

		// Token: 0x17007845 RID: 30789
		// (get) Token: 0x0602C9A7 RID: 182695 RVA: 0x00AA7AEF File Offset: 0x00AA5CEF
		// (set) Token: 0x0602C9A8 RID: 182696 RVA: 0x00AA7AFF File Offset: 0x00AA5CFF
		public unsafe int CameraArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KposeBase_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007846 RID: 30790
		// (get) Token: 0x0602C9A9 RID: 182697 RVA: 0x00AA7B10 File Offset: 0x00AA5D10
		// (set) Token: 0x0602C9AA RID: 182698 RVA: 0x00AA7B24 File Offset: 0x00AA5D24
		[Nullable(2)]
		public unsafe UKuroWeatherDataAsset DA_UIWeather
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_20);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KposeBase_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x0602C9AB RID: 182699 RVA: 0x00AA7B39 File Offset: 0x00AA5D39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ChangePlatform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__ChangePlatform_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9AC RID: 182700 RVA: 0x00AA7B4D File Offset: 0x00AA5D4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__PlayEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9AD RID: 182701 RVA: 0x00AA7B61 File Offset: 0x00AA5D61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__PlayStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9AE RID: 182702 RVA: 0x00AA7B78 File Offset: 0x00AA5D78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayKposeEffects([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SKposeEffect> Data, float AutoScale)
		{
			BP_KposeBase_C.__PlayKposeEffects_FunctionParams* ptr = stackalloc BP_KposeBase_C.__PlayKposeEffects_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BP_KposeBase_C.__PlayKposeEffects_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__PlayKposeEffects_NativeFunctionPtr, (void*)ptr, 1);
			TArray<SKposeEffect> tarray = Data;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Data);
			}
			ptr->AutoScale = AutoScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__PlayKposeEffects_NativeFunctionPtr, (void*)ptr);
			TArray<SKposeEffect> tarray2 = Data;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_KposeBase_C.__PlayKposeEffects_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602C9AF RID: 182703 RVA: 0x00AA7BFC File Offset: 0x00AA5DFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayEffect(TSoftObjectPtr<UEffectModelBase> EffectData, [Nullable(2)] USkeletalMeshComponent Component, FName AttachSocket, FTransform Transform)
		{
			BP_KposeBase_C.__PlayEffect_FunctionParams* ptr = stackalloc BP_KposeBase_C.__PlayEffect_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_KposeBase_C.__PlayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__PlayEffect_NativeFunctionPtr, (void*)ptr, 1);
			if (EffectData != null)
			{
				FSoftObjectPtr.NativeCopy(&ptr->EffectData, EffectData.NativePtr, 1);
			}
			ptr->Component = ((Component != null) ? Component.NativePtr : IntPtr.Zero);
			ptr->AttachSocket = AttachSocket;
			ptr->Transform = Transform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__PlayEffect_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KposeBase_C.__PlayEffect_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602C9B0 RID: 182704 RVA: 0x00AA7C90 File Offset: 0x00AA5E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopEffects()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__StopEffects_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9B1 RID: 182705 RVA: 0x00AA7CA4 File Offset: 0x00AA5EA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9B2 RID: 182706 RVA: 0x00AA7CB8 File Offset: 0x00AA5EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C9B3 RID: 182707 RVA: 0x00AA7CCD File Offset: 0x00AA5ECD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9B4 RID: 182708 RVA: 0x00AA7CE1 File Offset: 0x00AA5EE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C9B5 RID: 182709 RVA: 0x00AA7CF6 File Offset: 0x00AA5EF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9B6 RID: 182710 RVA: 0x00AA7D0A File Offset: 0x00AA5F0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C9B7 RID: 182711 RVA: 0x00AA7D20 File Offset: 0x00AA5F20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KposeBase_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KposeBase_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KposeBase_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C9B8 RID: 182712 RVA: 0x00AA7D6C File Offset: 0x00AA5F6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KposeBase_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KposeBase_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KposeBase_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C9B9 RID: 182713 RVA: 0x00AA7DB8 File Offset: 0x00AA5FB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KposeBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KposeBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KposeBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C9BA RID: 182714 RVA: 0x00AA7E00 File Offset: 0x00AA6000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KposeBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KposeBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KposeBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C9BB RID: 182715 RVA: 0x00AA7E48 File Offset: 0x00AA6048
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KposeBase(int EntryPoint)
		{
			BP_KposeBase_C.__ExecuteUbergraph_BP_KposeBase_FunctionParams* ptr = stackalloc BP_KposeBase_C.__ExecuteUbergraph_BP_KposeBase_FunctionParams[(UIntPtr)983] + 15L / (long)sizeof(BP_KposeBase_C.__ExecuteUbergraph_BP_KposeBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KposeBase_C.__ExecuteUbergraph_BP_KposeBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KposeBase_C.__ExecuteUbergraph_BP_KposeBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C9BC RID: 182716 RVA: 0x00AA7E92 File Offset: 0x00AA6092
		protected BP_KposeBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018CFC RID: 101628
		public new const string __ObjectPath = "/Game/Aki/Character/Kpose/Blueprint/BP_KposeBase.BP_KposeBase_C";

		// Token: 0x04018CFD RID: 101629
		private static IntPtr _ClassPtr;

		// Token: 0x04018CFE RID: 101630
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018CFF RID: 101631
		internal static int __PropertyOffset_0;

		// Token: 0x04018D00 RID: 101632
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018D01 RID: 101633
		internal static int __PropertyOffset_1;

		// Token: 0x04018D02 RID: 101634
		internal static int __PropertyOffset_2;

		// Token: 0x04018D03 RID: 101635
		internal static int __PropertyOffset_3;

		// Token: 0x04018D04 RID: 101636
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SKposeEffect> _PermanentEffects;

		// Token: 0x04018D05 RID: 101637
		internal static int __PropertyOffset_4;

		// Token: 0x04018D06 RID: 101638
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SKposeEffect> _EffectsOnEnd;

		// Token: 0x04018D07 RID: 101639
		internal static int __PropertyOffset_5;

		// Token: 0x04018D08 RID: 101640
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SKposeEffect> _EffectsOnStart;

		// Token: 0x04018D09 RID: 101641
		internal static int __PropertyOffset_6;

		// Token: 0x04018D0A RID: 101642
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroRainMaterialFloatParameter> _FloatParameterCurves;

		// Token: 0x04018D0B RID: 101643
		internal static int __PropertyOffset_7;

		// Token: 0x04018D0C RID: 101644
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroRainMaterialColorParameter> _ColorParameterCurves;

		// Token: 0x04018D0D RID: 101645
		internal static int __PropertyOffset_8;

		// Token: 0x04018D0E RID: 101646
		internal static int __PropertyOffset_9;

		// Token: 0x04018D0F RID: 101647
		internal static int __PropertyOffset_10;

		// Token: 0x04018D10 RID: 101648
		[Nullable(2)]
		private TArray<int> _CachedHandles;

		// Token: 0x04018D11 RID: 101649
		internal static int __PropertyOffset_11;

		// Token: 0x04018D12 RID: 101650
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DynamicMaterials;

		// Token: 0x04018D13 RID: 101651
		internal static int __PropertyOffset_12;

		// Token: 0x04018D14 RID: 101652
		internal static int __PropertyOffset_13;

		// Token: 0x04018D15 RID: 101653
		[Nullable(2)]
		private TMap<FName, float> _TempFloatValue;

		// Token: 0x04018D16 RID: 101654
		internal static int __PropertyOffset_14;

		// Token: 0x04018D17 RID: 101655
		[Nullable(2)]
		private TMap<FName, FLinearColor> _TempColorValue;

		// Token: 0x04018D18 RID: 101656
		internal static int __PropertyOffset_15;

		// Token: 0x04018D19 RID: 101657
		internal static int __PropertyOffset_16;

		// Token: 0x04018D1A RID: 101658
		internal static int __PropertyOffset_17;

		// Token: 0x04018D1B RID: 101659
		internal static int __PropertyOffset_18;

		// Token: 0x04018D1C RID: 101660
		internal static int __PropertyOffset_19;

		// Token: 0x04018D1D RID: 101661
		internal static int __PropertyOffset_20;

		// Token: 0x04018D1E RID: 101662
		private static IntPtr __ChangePlatform_NativeFunctionPtr;

		// Token: 0x04018D1F RID: 101663
		private static IntPtr __PlayEnd_NativeFunctionPtr;

		// Token: 0x04018D20 RID: 101664
		private static IntPtr __PlayStart_NativeFunctionPtr;

		// Token: 0x04018D21 RID: 101665
		private static IntPtr __PlayKposeEffects_NativeFunctionPtr;

		// Token: 0x04018D22 RID: 101666
		private static IntPtr __PlayEffect_NativeFunctionPtr;

		// Token: 0x04018D23 RID: 101667
		private static IntPtr __StopEffects_NativeFunctionPtr;

		// Token: 0x04018D24 RID: 101668
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04018D25 RID: 101669
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018D26 RID: 101670
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x04018D27 RID: 101671
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04018D28 RID: 101672
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04018D29 RID: 101673
		private static IntPtr __ExecuteUbergraph_BP_KposeBase_NativeFunctionPtr;

		// Token: 0x0200A464 RID: 42084
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __PlayKposeEffects_FunctionParams
		{
			// Token: 0x04033267 RID: 209511
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04033268 RID: 209512
			[FieldOffset(16)]
			public float AutoScale;
		}

		// Token: 0x0200A465 RID: 42085
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __PlayEffect_FunctionParams
		{
			// Token: 0x04033269 RID: 209513
			[FieldOffset(0)]
			public byte EffectData;

			// Token: 0x0403326A RID: 209514
			[FieldOffset(48)]
			public IntPtr Component;

			// Token: 0x0403326B RID: 209515
			[FieldOffset(56)]
			public FName AttachSocket;

			// Token: 0x0403326C RID: 209516
			[FieldOffset(80)]
			public FTransform Transform;
		}

		// Token: 0x0200A466 RID: 42086
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403326D RID: 209517
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A467 RID: 42087
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403326E RID: 209518
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A468 RID: 42088
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 968)]
		protected ref struct __ExecuteUbergraph_BP_KposeBase_FunctionParams
		{
			// Token: 0x0403326F RID: 209519
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
