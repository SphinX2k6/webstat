using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP.BPSeqDissolve
{
	// Token: 0x0200439B RID: 17307
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BPSeqDissolve/BP_MediaDissolveManagea.BP_MediaDissolveManagea_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1441)]
	public class BP_MediaDissolveManagea_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DE91 RID: 188049 RVA: 0x00AD0FE4 File Offset: 0x00ACF1E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MediaDissolveManagea_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BPSeqDissolve/BP_MediaDissolveManagea.BP_MediaDissolveManagea_C");
			}
			return BP_MediaDissolveManagea_C._ClassPtr;
		}

		// Token: 0x0602DE92 RID: 188050 RVA: 0x00AD1008 File Offset: 0x00ACF208
		public BP_MediaDissolveManagea_C() : this(BuiltinUtils.AllocNativeUObject(BP_MediaDissolveManagea_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DE93 RID: 188051 RVA: 0x00AD1030 File Offset: 0x00ACF230
		[NullableContext(1)]
		public BP_MediaDissolveManagea_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MediaDissolveManagea_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007DF2 RID: 32242
		// (get) Token: 0x0602DE94 RID: 188052 RVA: 0x00AD1064 File Offset: 0x00ACF264
		// (set) Token: 0x0602DE95 RID: 188053 RVA: 0x00AD109D File Offset: 0x00ACF29D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DF3 RID: 32243
		// (get) Token: 0x0602DE96 RID: 188054 RVA: 0x00AD10BE File Offset: 0x00ACF2BE
		// (set) Token: 0x0602DE97 RID: 188055 RVA: 0x00AD10D2 File Offset: 0x00ACF2D2
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007DF4 RID: 32244
		// (get) Token: 0x0602DE98 RID: 188056 RVA: 0x00AD10E7 File Offset: 0x00ACF2E7
		// (set) Token: 0x0602DE99 RID: 188057 RVA: 0x00AD10FB File Offset: 0x00ACF2FB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007DF5 RID: 32245
		// (get) Token: 0x0602DE9A RID: 188058 RVA: 0x00AD1110 File Offset: 0x00ACF310
		// (set) Token: 0x0602DE9B RID: 188059 RVA: 0x00AD1124 File Offset: 0x00ACF324
		public unsafe UMediaSource MainMediaSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007DF6 RID: 32246
		// (get) Token: 0x0602DE9C RID: 188060 RVA: 0x00AD1139 File Offset: 0x00ACF339
		// (set) Token: 0x0602DE9D RID: 188061 RVA: 0x00AD114D File Offset: 0x00ACF34D
		public unsafe UMediaPlayer MediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007DF7 RID: 32247
		// (get) Token: 0x0602DE9E RID: 188062 RVA: 0x00AD1162 File Offset: 0x00ACF362
		// (set) Token: 0x0602DE9F RID: 188063 RVA: 0x00AD1176 File Offset: 0x00ACF376
		public unsafe UMediaTexture MediaPlayerTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007DF8 RID: 32248
		// (get) Token: 0x0602DEA0 RID: 188064 RVA: 0x00AD118B File Offset: 0x00ACF38B
		// (set) Token: 0x0602DEA1 RID: 188065 RVA: 0x00AD119F File Offset: 0x00ACF39F
		public unsafe UMaterial PostMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007DF9 RID: 32249
		// (get) Token: 0x0602DEA2 RID: 188066 RVA: 0x00AD11B4 File Offset: 0x00ACF3B4
		// (set) Token: 0x0602DEA3 RID: 188067 RVA: 0x00AD11C8 File Offset: 0x00ACF3C8
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaDissolveManagea_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007DFA RID: 32250
		// (get) Token: 0x0602DEA4 RID: 188068 RVA: 0x00AD11DD File Offset: 0x00ACF3DD
		// (set) Token: 0x0602DEA5 RID: 188069 RVA: 0x00AD11ED File Offset: 0x00ACF3ED
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007DFB RID: 32251
		// (get) Token: 0x0602DEA6 RID: 188070 RVA: 0x00AD11FE File Offset: 0x00ACF3FE
		// (set) Token: 0x0602DEA7 RID: 188071 RVA: 0x00AD120E File Offset: 0x00ACF40E
		public unsafe float MediaScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007DFC RID: 32252
		// (get) Token: 0x0602DEA8 RID: 188072 RVA: 0x00AD121F File Offset: 0x00ACF41F
		// (set) Token: 0x0602DEA9 RID: 188073 RVA: 0x00AD122F File Offset: 0x00ACF42F
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007DFD RID: 32253
		// (get) Token: 0x0602DEAA RID: 188074 RVA: 0x00AD1240 File Offset: 0x00ACF440
		// (set) Token: 0x0602DEAB RID: 188075 RVA: 0x00AD1250 File Offset: 0x00ACF450
		public unsafe float SphereSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007DFE RID: 32254
		// (get) Token: 0x0602DEAC RID: 188076 RVA: 0x00AD1261 File Offset: 0x00ACF461
		// (set) Token: 0x0602DEAD RID: 188077 RVA: 0x00AD1271 File Offset: 0x00ACF471
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007DFF RID: 32255
		// (get) Token: 0x0602DEAE RID: 188078 RVA: 0x00AD1282 File Offset: 0x00ACF482
		// (set) Token: 0x0602DEAF RID: 188079 RVA: 0x00AD1292 File Offset: 0x00ACF492
		public unsafe float OutSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007E00 RID: 32256
		// (get) Token: 0x0602DEB0 RID: 188080 RVA: 0x00AD12A3 File Offset: 0x00ACF4A3
		// (set) Token: 0x0602DEB1 RID: 188081 RVA: 0x00AD12B7 File Offset: 0x00ACF4B7
		public unsafe FVector2D CenterPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007E01 RID: 32257
		// (get) Token: 0x0602DEB2 RID: 188082 RVA: 0x00AD12CC File Offset: 0x00ACF4CC
		// (set) Token: 0x0602DEB3 RID: 188083 RVA: 0x00AD12DC File Offset: 0x00ACF4DC
		public unsafe bool IsMaterialTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E02 RID: 32258
		// (get) Token: 0x0602DEB4 RID: 188084 RVA: 0x00AD12ED File Offset: 0x00ACF4ED
		// (set) Token: 0x0602DEB5 RID: 188085 RVA: 0x00AD12FD File Offset: 0x00ACF4FD
		public unsafe bool IsChangeSceneColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E03 RID: 32259
		// (get) Token: 0x0602DEB6 RID: 188086 RVA: 0x00AD130E File Offset: 0x00ACF50E
		// (set) Token: 0x0602DEB7 RID: 188087 RVA: 0x00AD131E File Offset: 0x00ACF51E
		public unsafe bool Is_Open
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E04 RID: 32260
		// (get) Token: 0x0602DEB8 RID: 188088 RVA: 0x00AD132F File Offset: 0x00ACF52F
		// (set) Token: 0x0602DEB9 RID: 188089 RVA: 0x00AD133F File Offset: 0x00ACF53F
		public unsafe bool Sphere_Or_Full_Screen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007E05 RID: 32261
		// (get) Token: 0x0602DEBA RID: 188090 RVA: 0x00AD1350 File Offset: 0x00ACF550
		// (set) Token: 0x0602DEBB RID: 188091 RVA: 0x00AD1364 File Offset: 0x00ACF564
		[Nullable(1)]
		public unsafe string Name
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_19)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_19)), value);
			}
		}

		// Token: 0x17007E06 RID: 32262
		// (get) Token: 0x0602DEBC RID: 188092 RVA: 0x00AD1379 File Offset: 0x00ACF579
		// (set) Token: 0x0602DEBD RID: 188093 RVA: 0x00AD1389 File Offset: 0x00ACF589
		public unsafe float FadeinTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007E07 RID: 32263
		// (get) Token: 0x0602DEBE RID: 188094 RVA: 0x00AD139A File Offset: 0x00ACF59A
		// (set) Token: 0x0602DEBF RID: 188095 RVA: 0x00AD13AA File Offset: 0x00ACF5AA
		public unsafe float FadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007E08 RID: 32264
		// (get) Token: 0x0602DEC0 RID: 188096 RVA: 0x00AD13BB File Offset: 0x00ACF5BB
		// (set) Token: 0x0602DEC1 RID: 188097 RVA: 0x00AD13CB File Offset: 0x00ACF5CB
		public unsafe bool IsReadyToPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaDissolveManagea_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602DEC2 RID: 188098 RVA: 0x00AD13DC File Offset: 0x00ACF5DC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayEffect(string Name, FVector2D CenterPos, float MediaScale, float FadeinTime, float FadeOutTime, [Nullable(2)] UMediaSource MediaSource, bool SphereOrFullScreen)
		{
			BP_MediaDissolveManagea_C.__PlayEffect_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__PlayEffect_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__PlayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__PlayEffect_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Name), Name);
			ptr->CenterPos = CenterPos;
			ptr->MediaScale = MediaScale;
			ptr->FadeinTime = FadeinTime;
			ptr->FadeOutTime = FadeOutTime;
			ptr->MediaSource = ((MediaSource != null) ? MediaSource.NativePtr : IntPtr.Zero);
			ptr->SphereOrFullScreen = SphereOrFullScreen;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__PlayEffect_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_MediaDissolveManagea_C.__PlayEffect_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DEC3 RID: 188099 RVA: 0x00AD1478 File Offset: 0x00ACF678
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetOpacity(UMaterialInstanceDynamic MaterialInstanceDynamic, bool IsOpen)
		{
			BP_MediaDissolveManagea_C.__SetOpacity_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__SetOpacity_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__SetOpacity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__SetOpacity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialInstanceDynamic = ((MaterialInstanceDynamic != null) ? MaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			ptr->IsOpen = IsOpen;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__SetOpacity_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DEC4 RID: 188100 RVA: 0x00AD14D4 File Offset: 0x00ACF6D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Post_Material()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__Set_Post_Material_NativeFunctionPtr, null);
		}

		// Token: 0x0602DEC5 RID: 188101 RVA: 0x00AD14E8 File Offset: 0x00ACF6E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Play(UMediaSource MediaSource, ref UMediaPlayer MediaPlayer)
		{
			BP_MediaDissolveManagea_C.__Play_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__Play_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__Play_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__Play_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MediaSource = ((MediaSource != null) ? MediaSource.NativePtr : IntPtr.Zero);
			ref BP_MediaDissolveManagea_C.__Play_FunctionParams ptr2 = ref *ptr;
			UMediaPlayer umediaPlayer = MediaPlayer;
			ptr2.MediaPlayer = ((umediaPlayer != null) ? umediaPlayer.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__Play_NativeFunctionPtr, (void*)ptr);
			MediaPlayer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMediaPlayer>(ptr->MediaPlayer);
		}

		// Token: 0x0602DEC6 RID: 188102 RVA: 0x00AD1562 File Offset: 0x00ACF762
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DEC7 RID: 188103 RVA: 0x00AD1576 File Offset: 0x00ACF776
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DEC8 RID: 188104 RVA: 0x00AD158B File Offset: 0x00ACF78B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DEC9 RID: 188105 RVA: 0x00AD159F File Offset: 0x00ACF79F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DECA RID: 188106 RVA: 0x00AD15B4 File Offset: 0x00ACF7B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DECB RID: 188107 RVA: 0x00AD15FC File Offset: 0x00ACF7FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DECC RID: 188108 RVA: 0x00AD1643 File Offset: 0x00ACF843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnVideoEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__OnVideoEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602DECD RID: 188109 RVA: 0x00AD1658 File Offset: 0x00ACF858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MediaDissolveManagea_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DECE RID: 188110 RVA: 0x00AD16A0 File Offset: 0x00ACF8A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MediaDissolveManagea_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DECF RID: 188111 RVA: 0x00AD16E7 File Offset: 0x00ACF8E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0602DED0 RID: 188112 RVA: 0x00AD16FB File Offset: 0x00ACF8FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DED1 RID: 188113 RVA: 0x00AD1710 File Offset: 0x00ACF910
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnMediaOpened(string OpenedUrl)
		{
			BP_MediaDissolveManagea_C.__OnMediaOpened_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__OnMediaOpened_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__OnMediaOpened_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__OnMediaOpened_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->OpenedUrl), OpenedUrl);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__OnMediaOpened_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_MediaDissolveManagea_C.__OnMediaOpened_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DED2 RID: 188114 RVA: 0x00AD1770 File Offset: 0x00ACF970
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OpenFailed(string FailedUrl)
		{
			BP_MediaDissolveManagea_C.__OpenFailed_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__OpenFailed_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__OpenFailed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__OpenFailed_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->FailedUrl), FailedUrl);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__OpenFailed_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_MediaDissolveManagea_C.__OpenFailed_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DED3 RID: 188115 RVA: 0x00AD17D0 File Offset: 0x00ACF9D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MediaDissolveManagea(int EntryPoint)
		{
			BP_MediaDissolveManagea_C.__ExecuteUbergraph_BP_MediaDissolveManagea_FunctionParams* ptr = stackalloc BP_MediaDissolveManagea_C.__ExecuteUbergraph_BP_MediaDissolveManagea_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_MediaDissolveManagea_C.__ExecuteUbergraph_BP_MediaDissolveManagea_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaDissolveManagea_C.__ExecuteUbergraph_BP_MediaDissolveManagea_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaDissolveManagea_C.__ExecuteUbergraph_BP_MediaDissolveManagea_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DED4 RID: 188116 RVA: 0x00AD181A File Offset: 0x00ACFA1A
		protected BP_MediaDissolveManagea_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019F16 RID: 106262
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BPSeqDissolve/BP_MediaDissolveManagea.BP_MediaDissolveManagea_C";

		// Token: 0x04019F17 RID: 106263
		private static IntPtr _ClassPtr;

		// Token: 0x04019F18 RID: 106264
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019F19 RID: 106265
		internal static int __PropertyOffset_0;

		// Token: 0x04019F1A RID: 106266
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019F1B RID: 106267
		internal static int __PropertyOffset_1;

		// Token: 0x04019F1C RID: 106268
		internal static int __PropertyOffset_2;

		// Token: 0x04019F1D RID: 106269
		internal static int __PropertyOffset_3;

		// Token: 0x04019F1E RID: 106270
		internal static int __PropertyOffset_4;

		// Token: 0x04019F1F RID: 106271
		internal static int __PropertyOffset_5;

		// Token: 0x04019F20 RID: 106272
		internal static int __PropertyOffset_6;

		// Token: 0x04019F21 RID: 106273
		internal static int __PropertyOffset_7;

		// Token: 0x04019F22 RID: 106274
		internal static int __PropertyOffset_8;

		// Token: 0x04019F23 RID: 106275
		internal static int __PropertyOffset_9;

		// Token: 0x04019F24 RID: 106276
		internal static int __PropertyOffset_10;

		// Token: 0x04019F25 RID: 106277
		internal static int __PropertyOffset_11;

		// Token: 0x04019F26 RID: 106278
		internal static int __PropertyOffset_12;

		// Token: 0x04019F27 RID: 106279
		internal static int __PropertyOffset_13;

		// Token: 0x04019F28 RID: 106280
		internal static int __PropertyOffset_14;

		// Token: 0x04019F29 RID: 106281
		internal static int __PropertyOffset_15;

		// Token: 0x04019F2A RID: 106282
		internal static int __PropertyOffset_16;

		// Token: 0x04019F2B RID: 106283
		internal static int __PropertyOffset_17;

		// Token: 0x04019F2C RID: 106284
		internal static int __PropertyOffset_18;

		// Token: 0x04019F2D RID: 106285
		internal static int __PropertyOffset_19;

		// Token: 0x04019F2E RID: 106286
		internal static int __PropertyOffset_20;

		// Token: 0x04019F2F RID: 106287
		internal static int __PropertyOffset_21;

		// Token: 0x04019F30 RID: 106288
		internal static int __PropertyOffset_22;

		// Token: 0x04019F31 RID: 106289
		private static IntPtr __PlayEffect_NativeFunctionPtr;

		// Token: 0x04019F32 RID: 106290
		private static IntPtr __SetOpacity_NativeFunctionPtr;

		// Token: 0x04019F33 RID: 106291
		private static IntPtr __Set_Post_Material_NativeFunctionPtr;

		// Token: 0x04019F34 RID: 106292
		private static IntPtr __Play_NativeFunctionPtr;

		// Token: 0x04019F35 RID: 106293
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04019F36 RID: 106294
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019F37 RID: 106295
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019F38 RID: 106296
		private static IntPtr __OnVideoEnd_NativeFunctionPtr;

		// Token: 0x04019F39 RID: 106297
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04019F3A RID: 106298
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04019F3B RID: 106299
		private static IntPtr __OnMediaOpened_NativeFunctionPtr;

		// Token: 0x04019F3C RID: 106300
		private static IntPtr __OpenFailed_NativeFunctionPtr;

		// Token: 0x04019F3D RID: 106301
		private static IntPtr __ExecuteUbergraph_BP_MediaDissolveManagea_NativeFunctionPtr;

		// Token: 0x0200A5E8 RID: 42472
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __PlayEffect_FunctionParams
		{
			// Token: 0x0403358B RID: 210315
			[FieldOffset(0)]
			public FString Name;

			// Token: 0x0403358C RID: 210316
			[FieldOffset(16)]
			public FVector2D CenterPos;

			// Token: 0x0403358D RID: 210317
			[FieldOffset(24)]
			public float MediaScale;

			// Token: 0x0403358E RID: 210318
			[FieldOffset(28)]
			public float FadeinTime;

			// Token: 0x0403358F RID: 210319
			[FieldOffset(32)]
			public float FadeOutTime;

			// Token: 0x04033590 RID: 210320
			[FieldOffset(40)]
			public IntPtr MediaSource;

			// Token: 0x04033591 RID: 210321
			[FieldOffset(48)]
			public bool SphereOrFullScreen;
		}

		// Token: 0x0200A5E9 RID: 42473
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetOpacity_FunctionParams
		{
			// Token: 0x04033592 RID: 210322
			[FieldOffset(0)]
			public IntPtr MaterialInstanceDynamic;

			// Token: 0x04033593 RID: 210323
			[FieldOffset(8)]
			public bool IsOpen;
		}

		// Token: 0x0200A5EA RID: 42474
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Play_FunctionParams
		{
			// Token: 0x04033594 RID: 210324
			[FieldOffset(0)]
			public IntPtr MediaSource;

			// Token: 0x04033595 RID: 210325
			[FieldOffset(8)]
			public IntPtr MediaPlayer;
		}

		// Token: 0x0200A5EB RID: 42475
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04033596 RID: 210326
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5EC RID: 42476
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04033597 RID: 210327
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5ED RID: 42477
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnMediaOpened_FunctionParams
		{
			// Token: 0x04033598 RID: 210328
			[FieldOffset(0)]
			public FString OpenedUrl;
		}

		// Token: 0x0200A5EE RID: 42478
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OpenFailed_FunctionParams
		{
			// Token: 0x04033599 RID: 210329
			[FieldOffset(0)]
			public FString FailedUrl;
		}

		// Token: 0x0200A5EF RID: 42479
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_MediaDissolveManagea_FunctionParams
		{
			// Token: 0x0403359A RID: 210330
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
