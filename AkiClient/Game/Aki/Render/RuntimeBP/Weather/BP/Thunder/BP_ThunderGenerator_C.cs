using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A01 RID: 14849
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderGenerator.BP_ThunderGenerator_C")]
	[UnrealStructLayout(2080, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2072)]
	public class BP_ThunderGenerator_C : AThunderGenerator, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E3EF RID: 123887 RVA: 0x008F0991 File Offset: 0x008EEB91
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ThunderGenerator_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderGenerator.BP_ThunderGenerator_C");
			}
			return BP_ThunderGenerator_C._ClassPtr;
		}

		// Token: 0x0601E3F0 RID: 123888 RVA: 0x008F09B8 File Offset: 0x008EEBB8
		public BP_ThunderGenerator_C() : this(BuiltinUtils.AllocNativeUObject(BP_ThunderGenerator_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E3F1 RID: 123889 RVA: 0x008F09E0 File Offset: 0x008EEBE0
		[NullableContext(1)]
		public BP_ThunderGenerator_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ThunderGenerator_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700292A RID: 10538
		// (get) Token: 0x0601E3F2 RID: 123890 RVA: 0x008F0A14 File Offset: 0x008EEC14
		// (set) Token: 0x0601E3F3 RID: 123891 RVA: 0x008F0A4D File Offset: 0x008EEC4D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700292B RID: 10539
		// (get) Token: 0x0601E3F4 RID: 123892 RVA: 0x008F0A6E File Offset: 0x008EEC6E
		// (set) Token: 0x0601E3F5 RID: 123893 RVA: 0x008F0A82 File Offset: 0x008EEC82
		public unsafe UKuroPostProcessComponent KuroPostProcess_Vignette
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700292C RID: 10540
		// (get) Token: 0x0601E3F6 RID: 123894 RVA: 0x008F0A97 File Offset: 0x008EEC97
		// (set) Token: 0x0601E3F7 RID: 123895 RVA: 0x008F0AAB File Offset: 0x008EECAB
		public unsafe PDA_ThunderConfigMap_C ThunderConfigMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_ThunderConfigMap_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700292D RID: 10541
		// (get) Token: 0x0601E3F8 RID: 123896 RVA: 0x008F0AC0 File Offset: 0x008EECC0
		// (set) Token: 0x0601E3F9 RID: 123897 RVA: 0x008F0AD4 File Offset: 0x008EECD4
		public unsafe PDA_ThunderConfig_C ThunderConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_ThunderConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700292E RID: 10542
		// (get) Token: 0x0601E3FA RID: 123898 RVA: 0x008F0AE9 File Offset: 0x008EECE9
		// (set) Token: 0x0601E3FB RID: 123899 RVA: 0x008F0AFD File Offset: 0x008EECFD
		public unsafe UAkAudioEvent CachedAudioEvent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700292F RID: 10543
		// (get) Token: 0x0601E3FC RID: 123900 RVA: 0x008F0B12 File Offset: 0x008EED12
		// (set) Token: 0x0601E3FD RID: 123901 RVA: 0x008F0B22 File Offset: 0x008EED22
		public unsafe int CachedTransition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002930 RID: 10544
		// (get) Token: 0x0601E3FE RID: 123902 RVA: 0x008F0B33 File Offset: 0x008EED33
		// (set) Token: 0x0601E3FF RID: 123903 RVA: 0x008F0B43 File Offset: 0x008EED43
		public unsafe bool PartialCloudFlash
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002931 RID: 10545
		// (get) Token: 0x0601E400 RID: 123904 RVA: 0x008F0B54 File Offset: 0x008EED54
		// (set) Token: 0x0601E401 RID: 123905 RVA: 0x008F0B64 File Offset: 0x008EED64
		public unsafe float CloudThunderHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002932 RID: 10546
		// (get) Token: 0x0601E402 RID: 123906 RVA: 0x008F0B75 File Offset: 0x008EED75
		// (set) Token: 0x0601E403 RID: 123907 RVA: 0x008F0B89 File Offset: 0x008EED89
		public unsafe FTransform CachedCameraTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002933 RID: 10547
		// (get) Token: 0x0601E404 RID: 123908 RVA: 0x008F0B9E File Offset: 0x008EED9E
		// (set) Token: 0x0601E405 RID: 123909 RVA: 0x008F0BB2 File Offset: 0x008EEDB2
		public unsafe PDA_CloudThunderData_C CloudThunderConfigData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_CloudThunderData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderGenerator_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002934 RID: 10548
		// (get) Token: 0x0601E406 RID: 123910 RVA: 0x008F0BC7 File Offset: 0x008EEDC7
		// (set) Token: 0x0601E407 RID: 123911 RVA: 0x008F0BD7 File Offset: 0x008EEDD7
		public unsafe int PartialThunderIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002935 RID: 10549
		// (get) Token: 0x0601E408 RID: 123912 RVA: 0x008F0BE8 File Offset: 0x008EEDE8
		// (set) Token: 0x0601E409 RID: 123913 RVA: 0x008F0BF8 File Offset: 0x008EEDF8
		public unsafe float CachedPartialEmissionScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002936 RID: 10550
		// (get) Token: 0x0601E40A RID: 123914 RVA: 0x008F0C09 File Offset: 0x008EEE09
		// (set) Token: 0x0601E40B RID: 123915 RVA: 0x008F0C19 File Offset: 0x008EEE19
		public unsafe float CachedThunderPlaySpeedScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002937 RID: 10551
		// (get) Token: 0x0601E40C RID: 123916 RVA: 0x008F0C2A File Offset: 0x008EEE2A
		// (set) Token: 0x0601E40D RID: 123917 RVA: 0x008F0C3A File Offset: 0x008EEE3A
		public unsafe bool DebugPartitialThunder
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002938 RID: 10552
		// (get) Token: 0x0601E40E RID: 123918 RVA: 0x008F0C4B File Offset: 0x008EEE4B
		// (set) Token: 0x0601E40F RID: 123919 RVA: 0x008F0C5B File Offset: 0x008EEE5B
		public unsafe float DebugPartitialThunderDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002939 RID: 10553
		// (get) Token: 0x0601E410 RID: 123920 RVA: 0x008F0C6C File Offset: 0x008EEE6C
		// (set) Token: 0x0601E411 RID: 123921 RVA: 0x008F0C80 File Offset: 0x008EEE80
		public unsafe FVector ThunderVectorCameraSpace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ThunderGenerator_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0601E412 RID: 123922 RVA: 0x008F0C95 File Offset: 0x008EEE95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudThunderParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__UpdateCloudThunderParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601E413 RID: 123923 RVA: 0x008F0CAC File Offset: 0x008EEEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool CalculateThunderPosition_Cloud(in FTransform CameraTransform, bool bAttack, ref FVector OutPosition)
		{
			BP_ThunderGenerator_C.__CalculateThunderPosition_Cloud_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__CalculateThunderPosition_Cloud_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_ThunderGenerator_C.__CalculateThunderPosition_Cloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__CalculateThunderPosition_Cloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraTransform = CameraTransform;
			ptr->bAttack = bAttack;
			ptr->OutPosition = OutPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__CalculateThunderPosition_Cloud_NativeFunctionPtr, (void*)ptr);
			OutPosition = ptr->OutPosition;
			return ptr->__Result;
		}

		// Token: 0x0601E414 RID: 123924 RVA: 0x008F0D1F File Offset: 0x008EEF1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ForceUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__ForceUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x0601E415 RID: 123925 RVA: 0x008F0D34 File Offset: 0x008EEF34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool CalculateThunderPosition_Common(in FTransform CameraTransform, bool bAttack, ref FVector OutPosition)
		{
			BP_ThunderGenerator_C.__CalculateThunderPosition_Common_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__CalculateThunderPosition_Common_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_ThunderGenerator_C.__CalculateThunderPosition_Common_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__CalculateThunderPosition_Common_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraTransform = CameraTransform;
			ptr->bAttack = bAttack;
			ptr->OutPosition = OutPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__CalculateThunderPosition_Common_NativeFunctionPtr, (void*)ptr);
			OutPosition = ptr->OutPosition;
			return ptr->__Result;
		}

		// Token: 0x0601E416 RID: 123926 RVA: 0x008F0DA8 File Offset: 0x008EEFA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool CalculateThunderPosition(in FTransform CameraTransform, ref FVector OutPosition, bool bAttack)
		{
			BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__CalculateThunderPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraTransform = CameraTransform;
			ptr->OutPosition = OutPosition;
			ptr->bAttack = bAttack;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__CalculateThunderPosition_NativeFunctionPtr, (void*)ptr);
			OutPosition = ptr->OutPosition;
			return ptr->__Result;
		}

		// Token: 0x0601E417 RID: 123927 RVA: 0x008F0E18 File Offset: 0x008EF018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool CalculateThunderPosition_Implementation(in FTransform CameraTransform, ref FVector OutPosition, bool bAttack)
		{
			BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_ThunderGenerator_C.__CalculateThunderPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__CalculateThunderPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraTransform = CameraTransform;
			ptr->OutPosition = OutPosition;
			ptr->bAttack = bAttack;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__CalculateThunderPosition_NativeFunctionPtr, (void*)ptr, 0);
			OutPosition = ptr->OutPosition;
			return ptr->__Result;
		}

		// Token: 0x0601E418 RID: 123928 RVA: 0x008F0E89 File Offset: 0x008EF089
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearThunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__ClearThunder_NativeFunctionPtr, null);
		}

		// Token: 0x0601E419 RID: 123929 RVA: 0x008F0E9D File Offset: 0x008EF09D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateAudio2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__UpdateAudio2D_NativeFunctionPtr, null);
		}

		// Token: 0x0601E41A RID: 123930 RVA: 0x008F0EB1 File Offset: 0x008EF0B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E41B RID: 123931 RVA: 0x008F0EC5 File Offset: 0x008EF0C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E41C RID: 123932 RVA: 0x008F0EDC File Offset: 0x008EF0DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnReceiveThunderAttack(FVector Location, bool bAttack)
		{
			BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnReceiveThunderAttack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			ptr->bAttack = bAttack;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnReceiveThunderAttack_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E41D RID: 123933 RVA: 0x008F0F2C File Offset: 0x008EF12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnReceiveThunderAttack_Implementation(FVector Location, bool bAttack)
		{
			BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnReceiveThunderAttack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnReceiveThunderAttack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			ptr->bAttack = bAttack;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnReceiveThunderAttack_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E41E RID: 123934 RVA: 0x008F0F7C File Offset: 0x008EF17C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnUpdateThunderEffect(float DeltaSeconds)
		{
			BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnUpdateThunderEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnUpdateThunderEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E41F RID: 123935 RVA: 0x008F0FC4 File Offset: 0x008EF1C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnUpdateThunderEffect_Implementation(float DeltaSeconds)
		{
			BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnUpdateThunderEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnUpdateThunderEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnUpdateThunderEffect_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E420 RID: 123936 RVA: 0x008F100C File Offset: 0x008EF20C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E421 RID: 123937 RVA: 0x008F1058 File Offset: 0x008EF258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ThunderGenerator_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E422 RID: 123938 RVA: 0x008F10A4 File Offset: 0x008EF2A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnReceiveThunderTrigger(AThunderTrigger Trigger, in FTransform CameraTransform)
		{
			BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnReceiveThunderTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Trigger = ((Trigger != null) ? Trigger.NativePtr : IntPtr.Zero);
			ptr->CameraTransform = CameraTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnReceiveThunderTrigger_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E423 RID: 123939 RVA: 0x008F1108 File Offset: 0x008EF308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnReceiveThunderTrigger_Implementation(AThunderTrigger Trigger, in FTransform CameraTransform)
		{
			BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_ThunderGenerator_C.__OnReceiveThunderTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__OnReceiveThunderTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Trigger = ((Trigger != null) ? Trigger.NativePtr : IntPtr.Zero);
			ptr->CameraTransform = CameraTransform;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnReceiveThunderTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E424 RID: 123940 RVA: 0x008F116A File Offset: 0x008EF36A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnThunderTypeChanged()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnThunderTypeChanged_NativeFunctionPtr, null);
		}

		// Token: 0x0601E425 RID: 123941 RVA: 0x008F117E File Offset: 0x008EF37E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnThunderTypeChanged_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__OnThunderTypeChanged_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E426 RID: 123942 RVA: 0x008F1194 File Offset: 0x008EF394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ThunderGenerator(int EntryPoint)
		{
			BP_ThunderGenerator_C.__ExecuteUbergraph_BP_ThunderGenerator_FunctionParams* ptr = stackalloc BP_ThunderGenerator_C.__ExecuteUbergraph_BP_ThunderGenerator_FunctionParams[(UIntPtr)447] + 15L / (long)sizeof(BP_ThunderGenerator_C.__ExecuteUbergraph_BP_ThunderGenerator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ThunderGenerator_C.__ExecuteUbergraph_BP_ThunderGenerator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ThunderGenerator_C.__ExecuteUbergraph_BP_ThunderGenerator_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E427 RID: 123943 RVA: 0x008F11DE File Offset: 0x008EF3DE
		protected BP_ThunderGenerator_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EDEC RID: 60908
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderGenerator.BP_ThunderGenerator_C";

		// Token: 0x0400EDED RID: 60909
		private static IntPtr _ClassPtr;

		// Token: 0x0400EDEE RID: 60910
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EDEF RID: 60911
		internal static int __PropertyOffset_0;

		// Token: 0x0400EDF0 RID: 60912
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EDF1 RID: 60913
		internal static int __PropertyOffset_1;

		// Token: 0x0400EDF2 RID: 60914
		internal static int __PropertyOffset_2;

		// Token: 0x0400EDF3 RID: 60915
		internal static int __PropertyOffset_3;

		// Token: 0x0400EDF4 RID: 60916
		internal static int __PropertyOffset_4;

		// Token: 0x0400EDF5 RID: 60917
		internal static int __PropertyOffset_5;

		// Token: 0x0400EDF6 RID: 60918
		internal static int __PropertyOffset_6;

		// Token: 0x0400EDF7 RID: 60919
		internal static int __PropertyOffset_7;

		// Token: 0x0400EDF8 RID: 60920
		internal static int __PropertyOffset_8;

		// Token: 0x0400EDF9 RID: 60921
		internal static int __PropertyOffset_9;

		// Token: 0x0400EDFA RID: 60922
		internal static int __PropertyOffset_10;

		// Token: 0x0400EDFB RID: 60923
		internal static int __PropertyOffset_11;

		// Token: 0x0400EDFC RID: 60924
		internal static int __PropertyOffset_12;

		// Token: 0x0400EDFD RID: 60925
		internal static int __PropertyOffset_13;

		// Token: 0x0400EDFE RID: 60926
		internal static int __PropertyOffset_14;

		// Token: 0x0400EDFF RID: 60927
		internal static int __PropertyOffset_15;

		// Token: 0x0400EE00 RID: 60928
		private static IntPtr __UpdateCloudThunderParameter_NativeFunctionPtr;

		// Token: 0x0400EE01 RID: 60929
		private static IntPtr __CalculateThunderPosition_Cloud_NativeFunctionPtr;

		// Token: 0x0400EE02 RID: 60930
		private static IntPtr __ForceUpdate_NativeFunctionPtr;

		// Token: 0x0400EE03 RID: 60931
		private static IntPtr __CalculateThunderPosition_Common_NativeFunctionPtr;

		// Token: 0x0400EE04 RID: 60932
		private static IntPtr __CalculateThunderPosition_NativeFunctionPtr;

		// Token: 0x0400EE05 RID: 60933
		private static IntPtr __ClearThunder_NativeFunctionPtr;

		// Token: 0x0400EE06 RID: 60934
		private static IntPtr __UpdateAudio2D_NativeFunctionPtr;

		// Token: 0x0400EE07 RID: 60935
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EE08 RID: 60936
		private static IntPtr __OnReceiveThunderAttack_NativeFunctionPtr;

		// Token: 0x0400EE09 RID: 60937
		private static IntPtr __OnUpdateThunderEffect_NativeFunctionPtr;

		// Token: 0x0400EE0A RID: 60938
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400EE0B RID: 60939
		private static IntPtr __OnReceiveThunderTrigger_NativeFunctionPtr;

		// Token: 0x0400EE0C RID: 60940
		private static IntPtr __OnThunderTypeChanged_NativeFunctionPtr;

		// Token: 0x0400EE0D RID: 60941
		private static IntPtr __ExecuteUbergraph_BP_ThunderGenerator_NativeFunctionPtr;

		// Token: 0x02009793 RID: 38803
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __CalculateThunderPosition_Cloud_FunctionParams
		{
			// Token: 0x04031D4E RID: 204110
			[FieldOffset(0)]
			public FTransform CameraTransform;

			// Token: 0x04031D4F RID: 204111
			[FieldOffset(48)]
			public bool bAttack;

			// Token: 0x04031D50 RID: 204112
			[FieldOffset(52)]
			public FVector OutPosition;

			// Token: 0x04031D51 RID: 204113
			[FieldOffset(64)]
			public bool __Result;
		}

		// Token: 0x02009794 RID: 38804
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __CalculateThunderPosition_Common_FunctionParams
		{
			// Token: 0x04031D52 RID: 204114
			[FieldOffset(0)]
			public FTransform CameraTransform;

			// Token: 0x04031D53 RID: 204115
			[FieldOffset(48)]
			public bool bAttack;

			// Token: 0x04031D54 RID: 204116
			[FieldOffset(52)]
			public FVector OutPosition;

			// Token: 0x04031D55 RID: 204117
			[FieldOffset(64)]
			public bool __Result;
		}

		// Token: 0x02009795 RID: 38805
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected new ref struct __CalculateThunderPosition_FunctionParams
		{
			// Token: 0x04031D56 RID: 204118
			[FieldOffset(0)]
			public FTransform CameraTransform;

			// Token: 0x04031D57 RID: 204119
			[FieldOffset(48)]
			public FVector OutPosition;

			// Token: 0x04031D58 RID: 204120
			[FieldOffset(60)]
			public bool bAttack;

			// Token: 0x04031D59 RID: 204121
			[FieldOffset(61)]
			public bool __Result;
		}

		// Token: 0x02009796 RID: 38806
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnReceiveThunderAttack_FunctionParams
		{
			// Token: 0x04031D5A RID: 204122
			[FieldOffset(0)]
			public FVector Location;

			// Token: 0x04031D5B RID: 204123
			[FieldOffset(12)]
			public bool bAttack;
		}

		// Token: 0x02009797 RID: 38807
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnUpdateThunderEffect_FunctionParams
		{
			// Token: 0x04031D5C RID: 204124
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009798 RID: 38808
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031D5D RID: 204125
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009799 RID: 38809
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected new ref struct __OnReceiveThunderTrigger_FunctionParams
		{
			// Token: 0x04031D5E RID: 204126
			[FieldOffset(0)]
			public IntPtr Trigger;

			// Token: 0x04031D5F RID: 204127
			[FieldOffset(16)]
			public FTransform CameraTransform;
		}

		// Token: 0x0200979A RID: 38810
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 432)]
		protected ref struct __ExecuteUbergraph_BP_ThunderGenerator_FunctionParams
		{
			// Token: 0x04031D60 RID: 204128
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
