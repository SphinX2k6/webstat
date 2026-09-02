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
	// Token: 0x02003C83 RID: 15491
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer_Extra.BP_MeshMediaPlayer_Extra_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1464)]
	public class BP_MeshMediaPlayer_Extra_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602409D RID: 147613 RVA: 0x00993158 File Offset: 0x00991358
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshMediaPlayer_Extra_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer_Extra.BP_MeshMediaPlayer_Extra_C");
			}
			return BP_MeshMediaPlayer_Extra_C._ClassPtr;
		}

		// Token: 0x0602409E RID: 147614 RVA: 0x0099317C File Offset: 0x0099137C
		public BP_MeshMediaPlayer_Extra_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshMediaPlayer_Extra_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602409F RID: 147615 RVA: 0x009931A4 File Offset: 0x009913A4
		[NullableContext(1)]
		public BP_MeshMediaPlayer_Extra_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshMediaPlayer_Extra_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049A1 RID: 18849
		// (get) Token: 0x060240A0 RID: 147616 RVA: 0x009931D8 File Offset: 0x009913D8
		// (set) Token: 0x060240A1 RID: 147617 RVA: 0x00993211 File Offset: 0x00991411
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049A2 RID: 18850
		// (get) Token: 0x060240A2 RID: 147618 RVA: 0x00993232 File Offset: 0x00991432
		// (set) Token: 0x060240A3 RID: 147619 RVA: 0x00993246 File Offset: 0x00991446
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170049A3 RID: 18851
		// (get) Token: 0x060240A4 RID: 147620 RVA: 0x0099325B File Offset: 0x0099145B
		// (set) Token: 0x060240A5 RID: 147621 RVA: 0x0099326F File Offset: 0x0099146F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170049A4 RID: 18852
		// (get) Token: 0x060240A6 RID: 147622 RVA: 0x00993284 File Offset: 0x00991484
		// (set) Token: 0x060240A7 RID: 147623 RVA: 0x00993298 File Offset: 0x00991498
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170049A5 RID: 18853
		// (get) Token: 0x060240A8 RID: 147624 RVA: 0x009932AD File Offset: 0x009914AD
		// (set) Token: 0x060240A9 RID: 147625 RVA: 0x009932BD File Offset: 0x009914BD
		public unsafe float MediaIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170049A6 RID: 18854
		// (get) Token: 0x060240AA RID: 147626 RVA: 0x009932CE File Offset: 0x009914CE
		// (set) Token: 0x060240AB RID: 147627 RVA: 0x009932DE File Offset: 0x009914DE
		public unsafe float MediaTransparency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049A7 RID: 18855
		// (get) Token: 0x060240AC RID: 147628 RVA: 0x009932EF File Offset: 0x009914EF
		// (set) Token: 0x060240AD RID: 147629 RVA: 0x00993303 File Offset: 0x00991503
		public unsafe FColor MediaColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170049A8 RID: 18856
		// (get) Token: 0x060240AE RID: 147630 RVA: 0x00993318 File Offset: 0x00991518
		// (set) Token: 0x060240AF RID: 147631 RVA: 0x0099332C File Offset: 0x0099152C
		public unsafe PDA_MediaPlayDataAsset_C MediaPlayDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_MediaPlayDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170049A9 RID: 18857
		// (get) Token: 0x060240B0 RID: 147632 RVA: 0x00993341 File Offset: 0x00991541
		// (set) Token: 0x060240B1 RID: 147633 RVA: 0x00993355 File Offset: 0x00991555
		public unsafe UMaterialInstance MediaMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170049AA RID: 18858
		// (get) Token: 0x060240B2 RID: 147634 RVA: 0x0099336A File Offset: 0x0099156A
		// (set) Token: 0x060240B3 RID: 147635 RVA: 0x0099337E File Offset: 0x0099157E
		public unsafe UMaterialInstanceDynamic MediaMaterial_Dynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170049AB RID: 18859
		// (get) Token: 0x060240B4 RID: 147636 RVA: 0x00993393 File Offset: 0x00991593
		// (set) Token: 0x060240B5 RID: 147637 RVA: 0x009933A7 File Offset: 0x009915A7
		public unsafe UMediaTexture MediaTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170049AC RID: 18860
		// (get) Token: 0x060240B6 RID: 147638 RVA: 0x009933BC File Offset: 0x009915BC
		// (set) Token: 0x060240B7 RID: 147639 RVA: 0x009933D0 File Offset: 0x009915D0
		public unsafe UMediaPlayer MeidaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170049AD RID: 18861
		// (get) Token: 0x060240B8 RID: 147640 RVA: 0x009933E5 File Offset: 0x009915E5
		// (set) Token: 0x060240B9 RID: 147641 RVA: 0x009933F9 File Offset: 0x009915F9
		public unsafe FVector BackgroundUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170049AE RID: 18862
		// (get) Token: 0x060240BA RID: 147642 RVA: 0x0099340E File Offset: 0x0099160E
		// (set) Token: 0x060240BB RID: 147643 RVA: 0x00993422 File Offset: 0x00991622
		public unsafe FVector BackgroundUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170049AF RID: 18863
		// (get) Token: 0x060240BC RID: 147644 RVA: 0x00993437 File Offset: 0x00991637
		// (set) Token: 0x060240BD RID: 147645 RVA: 0x0099344B File Offset: 0x0099164B
		public unsafe UTexture2D MainTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshMediaPlayer_Extra_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170049B0 RID: 18864
		// (get) Token: 0x060240BE RID: 147646 RVA: 0x00993460 File Offset: 0x00991660
		// (set) Token: 0x060240BF RID: 147647 RVA: 0x00993474 File Offset: 0x00991674
		public unsafe FVector ScreenUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170049B1 RID: 18865
		// (get) Token: 0x060240C0 RID: 147648 RVA: 0x00993489 File Offset: 0x00991689
		// (set) Token: 0x060240C1 RID: 147649 RVA: 0x0099349D File Offset: 0x0099169D
		public unsafe FVector ScreenUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170049B2 RID: 18866
		// (get) Token: 0x060240C2 RID: 147650 RVA: 0x009934B2 File Offset: 0x009916B2
		// (set) Token: 0x060240C3 RID: 147651 RVA: 0x009934C2 File Offset: 0x009916C2
		public unsafe int NumberOfChunks
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170049B3 RID: 18867
		// (get) Token: 0x060240C4 RID: 147652 RVA: 0x009934D3 File Offset: 0x009916D3
		// (set) Token: 0x060240C5 RID: 147653 RVA: 0x009934E3 File Offset: 0x009916E3
		public unsafe int PlayingChunk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshMediaPlayer_Extra_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x060240C6 RID: 147654 RVA: 0x009934F4 File Offset: 0x009916F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReplayMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ReplayMedia_NativeFunctionPtr, null);
		}

		// Token: 0x060240C7 RID: 147655 RVA: 0x00993508 File Offset: 0x00991708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LoadDA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__LoadDA_NativeFunctionPtr, null);
		}

		// Token: 0x060240C8 RID: 147656 RVA: 0x0099351C File Offset: 0x0099171C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__CloseSound_NativeFunctionPtr, null);
		}

		// Token: 0x060240C9 RID: 147657 RVA: 0x00993530 File Offset: 0x00991730
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__OpenSound_NativeFunctionPtr, null);
		}

		// Token: 0x060240CA RID: 147658 RVA: 0x00993544 File Offset: 0x00991744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__CloseMedia_NativeFunctionPtr, null);
		}

		// Token: 0x060240CB RID: 147659 RVA: 0x00993558 File Offset: 0x00991758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenMedia()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__OpenMedia_NativeFunctionPtr, null);
		}

		// Token: 0x060240CC RID: 147660 RVA: 0x0099356C File Offset: 0x0099176C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060240CD RID: 147661 RVA: 0x00993580 File Offset: 0x00991780
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060240CE RID: 147662 RVA: 0x00993595 File Offset: 0x00991795
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060240CF RID: 147663 RVA: 0x009935A9 File Offset: 0x009917A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060240D0 RID: 147664 RVA: 0x009935C0 File Offset: 0x009917C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_Extra_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060240D1 RID: 147665 RVA: 0x00993608 File Offset: 0x00991808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_Extra_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_Extra_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060240D2 RID: 147666 RVA: 0x0099364F File Offset: 0x0099184F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__OpenSource_NativeFunctionPtr, null);
		}

		// Token: 0x060240D3 RID: 147667 RVA: 0x00993663 File Offset: 0x00991863
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__CloseSource_NativeFunctionPtr, null);
		}

		// Token: 0x060240D4 RID: 147668 RVA: 0x00993678 File Offset: 0x00991878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060240D5 RID: 147669 RVA: 0x009936C0 File Offset: 0x009918C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshMediaPlayer_Extra_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060240D6 RID: 147670 RVA: 0x00993708 File Offset: 0x00991908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshMediaPlayer_Extra(int EntryPoint)
		{
			BP_MeshMediaPlayer_Extra_C.__ExecuteUbergraph_BP_MeshMediaPlayer_Extra_FunctionParams* ptr = stackalloc BP_MeshMediaPlayer_Extra_C.__ExecuteUbergraph_BP_MeshMediaPlayer_Extra_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_MeshMediaPlayer_Extra_C.__ExecuteUbergraph_BP_MeshMediaPlayer_Extra_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshMediaPlayer_Extra_C.__ExecuteUbergraph_BP_MeshMediaPlayer_Extra_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshMediaPlayer_Extra_C.__ExecuteUbergraph_BP_MeshMediaPlayer_Extra_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060240D7 RID: 147671 RVA: 0x0099374F File Offset: 0x0099194F
		protected BP_MeshMediaPlayer_Extra_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040126BD RID: 75453
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshMediaPlayer_Extra.BP_MeshMediaPlayer_Extra_C";

		// Token: 0x040126BE RID: 75454
		private static IntPtr _ClassPtr;

		// Token: 0x040126BF RID: 75455
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040126C0 RID: 75456
		internal static int __PropertyOffset_0;

		// Token: 0x040126C1 RID: 75457
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040126C2 RID: 75458
		internal static int __PropertyOffset_1;

		// Token: 0x040126C3 RID: 75459
		internal static int __PropertyOffset_2;

		// Token: 0x040126C4 RID: 75460
		internal static int __PropertyOffset_3;

		// Token: 0x040126C5 RID: 75461
		internal static int __PropertyOffset_4;

		// Token: 0x040126C6 RID: 75462
		internal static int __PropertyOffset_5;

		// Token: 0x040126C7 RID: 75463
		internal static int __PropertyOffset_6;

		// Token: 0x040126C8 RID: 75464
		internal static int __PropertyOffset_7;

		// Token: 0x040126C9 RID: 75465
		internal static int __PropertyOffset_8;

		// Token: 0x040126CA RID: 75466
		internal static int __PropertyOffset_9;

		// Token: 0x040126CB RID: 75467
		internal static int __PropertyOffset_10;

		// Token: 0x040126CC RID: 75468
		internal static int __PropertyOffset_11;

		// Token: 0x040126CD RID: 75469
		internal static int __PropertyOffset_12;

		// Token: 0x040126CE RID: 75470
		internal static int __PropertyOffset_13;

		// Token: 0x040126CF RID: 75471
		internal static int __PropertyOffset_14;

		// Token: 0x040126D0 RID: 75472
		internal static int __PropertyOffset_15;

		// Token: 0x040126D1 RID: 75473
		internal static int __PropertyOffset_16;

		// Token: 0x040126D2 RID: 75474
		internal static int __PropertyOffset_17;

		// Token: 0x040126D3 RID: 75475
		internal static int __PropertyOffset_18;

		// Token: 0x040126D4 RID: 75476
		private static IntPtr __ReplayMedia_NativeFunctionPtr;

		// Token: 0x040126D5 RID: 75477
		private static IntPtr __LoadDA_NativeFunctionPtr;

		// Token: 0x040126D6 RID: 75478
		private static IntPtr __CloseSound_NativeFunctionPtr;

		// Token: 0x040126D7 RID: 75479
		private static IntPtr __OpenSound_NativeFunctionPtr;

		// Token: 0x040126D8 RID: 75480
		private static IntPtr __CloseMedia_NativeFunctionPtr;

		// Token: 0x040126D9 RID: 75481
		private static IntPtr __OpenMedia_NativeFunctionPtr;

		// Token: 0x040126DA RID: 75482
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040126DB RID: 75483
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040126DC RID: 75484
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040126DD RID: 75485
		private static IntPtr __OpenSource_NativeFunctionPtr;

		// Token: 0x040126DE RID: 75486
		private static IntPtr __CloseSource_NativeFunctionPtr;

		// Token: 0x040126DF RID: 75487
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040126E0 RID: 75488
		private static IntPtr __ExecuteUbergraph_BP_MeshMediaPlayer_Extra_NativeFunctionPtr;

		// Token: 0x02009D82 RID: 40322
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032777 RID: 206711
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D83 RID: 40323
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032778 RID: 206712
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D84 RID: 40324
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __ExecuteUbergraph_BP_MeshMediaPlayer_Extra_FunctionParams
		{
			// Token: 0x04032779 RID: 206713
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
