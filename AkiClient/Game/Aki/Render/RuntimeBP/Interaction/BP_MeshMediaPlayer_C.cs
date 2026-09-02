using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C82 RID: 15490
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer.BP_MeshMediaPlayer_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1464)]
	public class BP_MeshMediaPlayer_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024062 RID: 147554 RVA: 0x00992B58 File Offset: 0x00990D58
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshMediaPlayer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer.BP_MeshMediaPlayer_C");
			}
			return BP_MeshMediaPlayer_C._ClassPtr;
		}

		// Token: 0x06024063 RID: 147555 RVA: 0x00992B7C File Offset: 0x00990D7C
		public BP_MeshMediaPlayer_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshMediaPlayer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024064 RID: 147556 RVA: 0x00992BA4 File Offset: 0x00990DA4
		[NullableContext(1)]
		public BP_MeshMediaPlayer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshMediaPlayer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700498E RID: 18830
		// (get) Token: 0x06024065 RID: 147557 RVA: 0x00992BD8 File Offset: 0x00990DD8
		// (set) Token: 0x06024066 RID: 147558 RVA: 0x00992C11 File Offset: 0x00990E11
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700498F RID: 18831
		// (get) Token: 0x06024067 RID: 147559 RVA: 0x00992C32 File Offset: 0x00990E32
		// (set) Token: 0x06024068 RID: 147560 RVA: 0x00992C46 File Offset: 0x00990E46
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004990 RID: 18832
		// (get) Token: 0x06024069 RID: 147561 RVA: 0x00992C5B File Offset: 0x00990E5B
		// (set) Token: 0x0602406A RID: 147562 RVA: 0x00992C6F File Offset: 0x00990E6F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004991 RID: 18833
		// (get) Token: 0x0602406B RID: 147563 RVA: 0x00992C84 File Offset: 0x00990E84
		// (set) Token: 0x0602406C RID: 147564 RVA: 0x00992C98 File Offset: 0x00990E98
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004992 RID: 18834
		// (get) Token: 0x0602406D RID: 147565 RVA: 0x00992CAD File Offset: 0x00990EAD
		// (set) Token: 0x0602406E RID: 147566 RVA: 0x00992CBD File Offset: 0x00990EBD
		public unsafe float MediaIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004993 RID: 18835
		// (get) Token: 0x0602406F RID: 147567 RVA: 0x00992CCE File Offset: 0x00990ECE
		// (set) Token: 0x06024070 RID: 147568 RVA: 0x00992CDE File Offset: 0x00990EDE
		public unsafe float MediaTransparency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004994 RID: 18836
		// (get) Token: 0x06024071 RID: 147569 RVA: 0x00992CEF File Offset: 0x00990EEF
		// (set) Token: 0x06024072 RID: 147570 RVA: 0x00992D03 File Offset: 0x00990F03
		public unsafe FColor MediaColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004995 RID: 18837
		// (get) Token: 0x06024073 RID: 147571 RVA: 0x00992D18 File Offset: 0x00990F18
		// (set) Token: 0x06024074 RID: 147572 RVA: 0x00992D2C File Offset: 0x00990F2C
		public unsafe PDA_MediaPlayDataAsset_C MediaPlayDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_MediaPlayDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004996 RID: 18838
		// (get) Token: 0x06024075 RID: 147573 RVA: 0x00992D41 File Offset: 0x00990F41
		// (set) Token: 0x06024076 RID: 147574 RVA: 0x00992D55 File Offset: 0x00990F55
		public unsafe UMaterialInstance MediaMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004997 RID: 18839
		// (get) Token: 0x06024077 RID: 147575 RVA: 0x00992D6A File Offset: 0x00990F6A
		// (set) Token: 0x06024078 RID: 147576 RVA: 0x00992D7E File Offset: 0x00990F7E
		public unsafe UMaterialInstanceDynamic MediaMaterial_Dynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004998 RID: 18840
		// (get) Token: 0x06024079 RID: 147577 RVA: 0x00992D93 File Offset: 0x00990F93
		// (set) Token: 0x0602407A RID: 147578 RVA: 0x00992DA7 File Offset: 0x00990FA7
		public unsafe UMediaTexture MediaTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004999 RID: 18841
		// (get) Token: 0x0602407B RID: 147579 RVA: 0x00992DBC File Offset: 0x00990FBC
		// (set) Token: 0x0602407C RID: 147580 RVA: 0x00992DD0 File Offset: 0x00990FD0
		public unsafe UMediaPlayer MeidaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700499A RID: 18842
		// (get) Token: 0x0602407D RID: 147581 RVA: 0x00992DE5 File Offset: 0x00990FE5
		// (set) Token: 0x0602407E RID: 147582 RVA: 0x00992DF9 File Offset: 0x00990FF9
		public unsafe FVector BackgroundUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700499B RID: 18843
		// (get) Token: 0x0602407F RID: 147583 RVA: 0x00992E0E File Offset: 0x0099100E
		// (set) Token: 0x06024080 RID: 147584 RVA: 0x00992E22 File Offset: 0x00991022
		public unsafe FVector BackgroundUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700499C RID: 18844
		// (get) Token: 0x06024081 RID: 147585 RVA: 0x00992E37 File Offset: 0x00991037
		// (set) Token: 0x06024082 RID: 147586 RVA: 0x00992E4B File Offset: 0x0099104B
		public unsafe UTexture2D MainTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700499D RID: 18845
		// (get) Token: 0x06024083 RID: 147587 RVA: 0x00992E60 File Offset: 0x00991060
		// (set) Token: 0x06024084 RID: 147588 RVA: 0x00992E74 File Offset: 0x00991074
		public unsafe FVector ScreenUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700499E RID: 18846
		// (get) Token: 0x06024085 RID: 147589 RVA: 0x00992E89 File Offset: 0x00991089
		// (set) Token: 0x06024086 RID: 147590 RVA: 0x00992E9D File Offset: 0x0099109D
		public unsafe FVector ScreenUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700499F RID: 18847
		// (get) Token: 0x06024087 RID: 147591 RVA: 0x00992EB2 File Offset: 0x009910B2
		// (set) Token: 0x06024088 RID: 147592 RVA: 0x00992EC2 File Offset: 0x009910C2
		public unsafe int NumberOfChunks
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170049A0 RID: 18848
		// (get) Token: 0x06024089 RID: 147593 RVA: 0x00992ED3 File Offset: 0x009910D3
		// (set) Token: 0x0602408A RID: 147594 RVA: 0x00992EE3 File Offset: 0x009910E3
		public unsafe int PlayingChunk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x0602408B RID: 147595 RVA: 0x00992EF4 File Offset: 0x009910F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LoadDA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__LoadDA_NativeFunctionPtr, null);
		}

		// Token: 0x0602408C RID: 147596 RVA: 0x00992F08 File Offset: 0x00991108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReplayMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ReplayMedia_NativeFunctionPtr, null);
		}

		// Token: 0x0602408D RID: 147597 RVA: 0x00992F1C File Offset: 0x0099111C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__CloseSound_NativeFunctionPtr, null);
		}

		// Token: 0x0602408E RID: 147598 RVA: 0x00992F30 File Offset: 0x00991130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__OpenSound_NativeFunctionPtr, null);
		}

		// Token: 0x0602408F RID: 147599 RVA: 0x00992F44 File Offset: 0x00991144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__CloseMedia_NativeFunctionPtr, null);
		}

		// Token: 0x06024090 RID: 147600 RVA: 0x00992F58 File Offset: 0x00991158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__OpenMedia_NativeFunctionPtr, null);
		}

		// Token: 0x06024091 RID: 147601 RVA: 0x00992F6C File Offset: 0x0099116C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024092 RID: 147602 RVA: 0x00992F80 File Offset: 0x00991180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024093 RID: 147603 RVA: 0x00992F95 File Offset: 0x00991195
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024094 RID: 147604 RVA: 0x00992FA9 File Offset: 0x009911A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024095 RID: 147605 RVA: 0x00992FC0 File Offset: 0x009911C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024096 RID: 147606 RVA: 0x00993008 File Offset: 0x00991208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024097 RID: 147607 RVA: 0x0099304F File Offset: 0x0099124F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__OpenSource_NativeFunctionPtr, null);
		}

		// Token: 0x06024098 RID: 147608 RVA: 0x00993063 File Offset: 0x00991263
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__CloseSource_NativeFunctionPtr, null);
		}

		// Token: 0x06024099 RID: 147609 RVA: 0x00993078 File Offset: 0x00991278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602409A RID: 147610 RVA: 0x009930C0 File Offset: 0x009912C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602409B RID: 147611 RVA: 0x00993108 File Offset: 0x00991308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshMediaPlayer(int EntryPoint)
		{
			BP_MeshMediaPlayer_C.__ExecuteUbergraph_BP_MeshMediaPlayer_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_C.__ExecuteUbergraph_BP_MeshMediaPlayer_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_MeshMediaPlayer_C.__ExecuteUbergraph_BP_MeshMediaPlayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_C.__ExecuteUbergraph_BP_MeshMediaPlayer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_C.__ExecuteUbergraph_BP_MeshMediaPlayer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602409C RID: 147612 RVA: 0x0099314F File Offset: 0x0099134F
		protected BP_MeshMediaPlayer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012699 RID: 75417
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer.BP_MeshMediaPlayer_C";

		// Token: 0x0401269A RID: 75418
		private static IntPtr _ClassPtr;

		// Token: 0x0401269B RID: 75419
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401269C RID: 75420
		internal static int __PropertyOffset_0;

		// Token: 0x0401269D RID: 75421
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401269E RID: 75422
		internal static int __PropertyOffset_1;

		// Token: 0x0401269F RID: 75423
		internal static int __PropertyOffset_2;

		// Token: 0x040126A0 RID: 75424
		internal static int __PropertyOffset_3;

		// Token: 0x040126A1 RID: 75425
		internal static int __PropertyOffset_4;

		// Token: 0x040126A2 RID: 75426
		internal static int __PropertyOffset_5;

		// Token: 0x040126A3 RID: 75427
		internal static int __PropertyOffset_6;

		// Token: 0x040126A4 RID: 75428
		internal static int __PropertyOffset_7;

		// Token: 0x040126A5 RID: 75429
		internal static int __PropertyOffset_8;

		// Token: 0x040126A6 RID: 75430
		internal static int __PropertyOffset_9;

		// Token: 0x040126A7 RID: 75431
		internal static int __PropertyOffset_10;

		// Token: 0x040126A8 RID: 75432
		internal static int __PropertyOffset_11;

		// Token: 0x040126A9 RID: 75433
		internal static int __PropertyOffset_12;

		// Token: 0x040126AA RID: 75434
		internal static int __PropertyOffset_13;

		// Token: 0x040126AB RID: 75435
		internal static int __PropertyOffset_14;

		// Token: 0x040126AC RID: 75436
		internal static int __PropertyOffset_15;

		// Token: 0x040126AD RID: 75437
		internal static int __PropertyOffset_16;

		// Token: 0x040126AE RID: 75438
		internal static int __PropertyOffset_17;

		// Token: 0x040126AF RID: 75439
		internal static int __PropertyOffset_18;

		// Token: 0x040126B0 RID: 75440
		private static IntPtr __LoadDA_NativeFunctionPtr;

		// Token: 0x040126B1 RID: 75441
		private static IntPtr __ReplayMedia_NativeFunctionPtr;

		// Token: 0x040126B2 RID: 75442
		private static IntPtr __CloseSound_NativeFunctionPtr;

		// Token: 0x040126B3 RID: 75443
		private static IntPtr __OpenSound_NativeFunctionPtr;

		// Token: 0x040126B4 RID: 75444
		private static IntPtr __CloseMedia_NativeFunctionPtr;

		// Token: 0x040126B5 RID: 75445
		private static IntPtr __OpenMedia_NativeFunctionPtr;

		// Token: 0x040126B6 RID: 75446
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040126B7 RID: 75447
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040126B8 RID: 75448
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040126B9 RID: 75449
		private static IntPtr __OpenSource_NativeFunctionPtr;

		// Token: 0x040126BA RID: 75450
		private static IntPtr __CloseSource_NativeFunctionPtr;

		// Token: 0x040126BB RID: 75451
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040126BC RID: 75452
		private static IntPtr __ExecuteUbergraph_BP_MeshMediaPlayer_NativeFunctionPtr;

		// Token: 0x02009D7F RID: 40319
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032774 RID: 206708
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D80 RID: 40320
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032775 RID: 206709
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D81 RID: 40321
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __ExecuteUbergraph_BP_MeshMediaPlayer_FunctionParams
		{
			// Token: 0x04032776 RID: 206710
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
