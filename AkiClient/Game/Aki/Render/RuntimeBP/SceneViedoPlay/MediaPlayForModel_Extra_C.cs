using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay
{
	// Token: 0x02003B27 RID: 15143
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Extra.MediaPlayForModel_Extra_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1440)]
	public class MediaPlayForModel_Extra_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_SceneBp_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x060209AF RID: 133551 RVA: 0x009318D3 File Offset: 0x0092FAD3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (MediaPlayForModel_Extra_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Extra.MediaPlayForModel_Extra_C");
			}
			return MediaPlayForModel_Extra_C._ClassPtr;
		}

		// Token: 0x060209B0 RID: 133552 RVA: 0x009318F8 File Offset: 0x0092FAF8
		public MediaPlayForModel_Extra_C() : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_Extra_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060209B1 RID: 133553 RVA: 0x00931920 File Offset: 0x0092FB20
		[NullableContext(1)]
		public MediaPlayForModel_Extra_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_Extra_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003658 RID: 13912
		// (get) Token: 0x060209B2 RID: 133554 RVA: 0x00931954 File Offset: 0x0092FB54
		// (set) Token: 0x060209B3 RID: 133555 RVA: 0x0093198D File Offset: 0x0092FB8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003659 RID: 13913
		// (get) Token: 0x060209B4 RID: 133556 RVA: 0x009319AE File Offset: 0x0092FBAE
		// (set) Token: 0x060209B5 RID: 133557 RVA: 0x009319C2 File Offset: 0x0092FBC2
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700365A RID: 13914
		// (get) Token: 0x060209B6 RID: 133558 RVA: 0x009319D7 File Offset: 0x0092FBD7
		// (set) Token: 0x060209B7 RID: 133559 RVA: 0x009319EB File Offset: 0x0092FBEB
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700365B RID: 13915
		// (get) Token: 0x060209B8 RID: 133560 RVA: 0x00931A00 File Offset: 0x0092FC00
		// (set) Token: 0x060209B9 RID: 133561 RVA: 0x00931A14 File Offset: 0x0092FC14
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700365C RID: 13916
		// (get) Token: 0x060209BA RID: 133562 RVA: 0x00931A29 File Offset: 0x0092FC29
		// (set) Token: 0x060209BB RID: 133563 RVA: 0x00931A3D File Offset: 0x0092FC3D
		public unsafe UMaterial ViedoMaterialTranSlucentTwoSide
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700365D RID: 13917
		// (get) Token: 0x060209BC RID: 133564 RVA: 0x00931A52 File Offset: 0x0092FC52
		// (set) Token: 0x060209BD RID: 133565 RVA: 0x00931A66 File Offset: 0x0092FC66
		public unsafe UMaterial ViedoMaterialTranSlucent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700365E RID: 13918
		// (get) Token: 0x060209BE RID: 133566 RVA: 0x00931A7B File Offset: 0x0092FC7B
		// (set) Token: 0x060209BF RID: 133567 RVA: 0x00931A8F File Offset: 0x0092FC8F
		public unsafe UMaterial ViedoMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700365F RID: 13919
		// (get) Token: 0x060209C0 RID: 133568 RVA: 0x00931AA4 File Offset: 0x0092FCA4
		// (set) Token: 0x060209C1 RID: 133569 RVA: 0x00931AB4 File Offset: 0x0092FCB4
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003660 RID: 13920
		// (get) Token: 0x060209C2 RID: 133570 RVA: 0x00931AC5 File Offset: 0x0092FCC5
		// (set) Token: 0x060209C3 RID: 133571 RVA: 0x00931AD5 File Offset: 0x0092FCD5
		public unsafe float DarkIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003661 RID: 13921
		// (get) Token: 0x060209C4 RID: 133572 RVA: 0x00931AE6 File Offset: 0x0092FCE6
		// (set) Token: 0x060209C5 RID: 133573 RVA: 0x00931AF6 File Offset: 0x0092FCF6
		public unsafe int AoiDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003662 RID: 13922
		// (get) Token: 0x060209C6 RID: 133574 RVA: 0x00931B07 File Offset: 0x0092FD07
		// (set) Token: 0x060209C7 RID: 133575 RVA: 0x00931B17 File Offset: 0x0092FD17
		public unsafe bool Translucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003663 RID: 13923
		// (get) Token: 0x060209C8 RID: 133576 RVA: 0x00931B28 File Offset: 0x0092FD28
		// (set) Token: 0x060209C9 RID: 133577 RVA: 0x00931B38 File Offset: 0x0092FD38
		public unsafe bool TwoSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003664 RID: 13924
		// (get) Token: 0x060209CA RID: 133578 RVA: 0x00931B49 File Offset: 0x0092FD49
		// (set) Token: 0x060209CB RID: 133579 RVA: 0x00931B59 File Offset: 0x0092FD59
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003665 RID: 13925
		// (get) Token: 0x060209CC RID: 133580 RVA: 0x00931B6A File Offset: 0x0092FD6A
		// (set) Token: 0x060209CD RID: 133581 RVA: 0x00931B7E File Offset: 0x0092FD7E
		public unsafe PDA_MediaPlayDataAsset_C MediaPlayDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_MediaPlayDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003666 RID: 13926
		// (get) Token: 0x060209CE RID: 133582 RVA: 0x00931B93 File Offset: 0x0092FD93
		// (set) Token: 0x060209CF RID: 133583 RVA: 0x00931BA7 File Offset: 0x0092FDA7
		public unsafe UMediaPlayer ShareMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003667 RID: 13927
		// (get) Token: 0x060209D0 RID: 133584 RVA: 0x00931BBC File Offset: 0x0092FDBC
		// (set) Token: 0x060209D1 RID: 133585 RVA: 0x00931BD0 File Offset: 0x0092FDD0
		public unsafe UMediaTexture ShareMediaTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Extra_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003668 RID: 13928
		// (get) Token: 0x060209D2 RID: 133586 RVA: 0x00931BE5 File Offset: 0x0092FDE5
		// (set) Token: 0x060209D3 RID: 133587 RVA: 0x00931BF5 File Offset: 0x0092FDF5
		public unsafe bool isOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003669 RID: 13929
		// (get) Token: 0x060209D4 RID: 133588 RVA: 0x00931C06 File Offset: 0x0092FE06
		// (set) Token: 0x060209D5 RID: 133589 RVA: 0x00931C16 File Offset: 0x0092FE16
		public unsafe bool DrawDebugAoi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700366A RID: 13930
		// (get) Token: 0x060209D6 RID: 133590 RVA: 0x00931C27 File Offset: 0x0092FE27
		// (set) Token: 0x060209D7 RID: 133591 RVA: 0x00931C37 File Offset: 0x0092FE37
		public unsafe bool isStopOnHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700366B RID: 13931
		// (get) Token: 0x060209D8 RID: 133592 RVA: 0x00931C48 File Offset: 0x0092FE48
		// (set) Token: 0x060209D9 RID: 133593 RVA: 0x00931C58 File Offset: 0x0092FE58
		public unsafe bool enableQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700366C RID: 13932
		// (get) Token: 0x060209DA RID: 133594 RVA: 0x00931C6C File Offset: 0x0092FE6C
		// (set) Token: 0x060209DB RID: 133595 RVA: 0x00931CA5 File Offset: 0x0092FEA5
		[Nullable(1)]
		public TArray<int> QualityDistanceList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._QualityDistanceList) == null)
				{
					result = (this._QualityDistanceList = new TArray<int>(base.NativePtr + (IntPtr)MediaPlayForModel_Extra_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.QualityDistanceList.CopyAssign(value);
			}
		}

		// Token: 0x060209DC RID: 133596 RVA: 0x00931CB4 File Offset: 0x0092FEB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldStopOnHide(ref bool ret)
		{
			MediaPlayForModel_Extra_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x060209DD RID: 133597 RVA: 0x00931D04 File Offset: 0x0092FF04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAoiRange(ref int ret)
		{
			MediaPlayForModel_Extra_C.__GetAoiRange_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__GetAoiRange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x060209DE RID: 133598 RVA: 0x00931D53 File Offset: 0x0092FF53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ReInit_NativeFunctionPtr, null);
		}

		// Token: 0x060209DF RID: 133599 RVA: 0x00931D67 File Offset: 0x0092FF67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ConstructionMediaPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ConstructionMediaPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060209E0 RID: 133600 RVA: 0x00931D7B File Offset: 0x0092FF7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__OpenSource_NativeFunctionPtr, null);
		}

		// Token: 0x060209E1 RID: 133601 RVA: 0x00931D8F File Offset: 0x0092FF8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__CloseSource_NativeFunctionPtr, null);
		}

		// Token: 0x060209E2 RID: 133602 RVA: 0x00931DA3 File Offset: 0x0092FFA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x060209E3 RID: 133603 RVA: 0x00931DB7 File Offset: 0x0092FFB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x060209E4 RID: 133604 RVA: 0x00931DCB File Offset: 0x0092FFCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x060209E5 RID: 133605 RVA: 0x00931DDF File Offset: 0x0092FFDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060209E6 RID: 133606 RVA: 0x00931DF3 File Offset: 0x0092FFF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060209E7 RID: 133607 RVA: 0x00931E08 File Offset: 0x00930008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			MediaPlayForModel_Extra_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060209E8 RID: 133608 RVA: 0x00931E50 File Offset: 0x00930050
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			MediaPlayForModel_Extra_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209E9 RID: 133609 RVA: 0x00931E97 File Offset: 0x00930097
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x060209EA RID: 133610 RVA: 0x00931EAB File Offset: 0x009300AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x060209EB RID: 133611 RVA: 0x00931EC0 File Offset: 0x009300C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060209EC RID: 133612 RVA: 0x00931F0C File Offset: 0x0093010C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209ED RID: 133613 RVA: 0x00931F58 File Offset: 0x00930158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlaySound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__PlaySound_NativeFunctionPtr, null);
		}

		// Token: 0x060209EE RID: 133614 RVA: 0x00931F6C File Offset: 0x0093016C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__CloseSound_NativeFunctionPtr, null);
		}

		// Token: 0x060209EF RID: 133615 RVA: 0x00931F80 File Offset: 0x00930180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_MediaPlayForModel_Extra(int EntryPoint)
		{
			MediaPlayForModel_Extra_C.__ExecuteUbergraph_MediaPlayForModel_Extra_FunctionParams* ptr = stackalloc MediaPlayForModel_Extra_C.__ExecuteUbergraph_MediaPlayForModel_Extra_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(MediaPlayForModel_Extra_C.__ExecuteUbergraph_MediaPlayForModel_Extra_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Extra_C.__ExecuteUbergraph_MediaPlayForModel_Extra_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Extra_C.__ExecuteUbergraph_MediaPlayForModel_Extra_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209F0 RID: 133616 RVA: 0x00931FCA File Offset: 0x009301CA
		protected MediaPlayForModel_Extra_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010521 RID: 66849
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Extra.MediaPlayForModel_Extra_C";

		// Token: 0x04010522 RID: 66850
		private static IntPtr _ClassPtr;

		// Token: 0x04010523 RID: 66851
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010524 RID: 66852
		internal static int __PropertyOffset_0;

		// Token: 0x04010525 RID: 66853
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010526 RID: 66854
		internal static int __PropertyOffset_1;

		// Token: 0x04010527 RID: 66855
		internal static int __PropertyOffset_2;

		// Token: 0x04010528 RID: 66856
		internal static int __PropertyOffset_3;

		// Token: 0x04010529 RID: 66857
		internal static int __PropertyOffset_4;

		// Token: 0x0401052A RID: 66858
		internal static int __PropertyOffset_5;

		// Token: 0x0401052B RID: 66859
		internal static int __PropertyOffset_6;

		// Token: 0x0401052C RID: 66860
		internal static int __PropertyOffset_7;

		// Token: 0x0401052D RID: 66861
		internal static int __PropertyOffset_8;

		// Token: 0x0401052E RID: 66862
		internal static int __PropertyOffset_9;

		// Token: 0x0401052F RID: 66863
		internal static int __PropertyOffset_10;

		// Token: 0x04010530 RID: 66864
		internal static int __PropertyOffset_11;

		// Token: 0x04010531 RID: 66865
		internal static int __PropertyOffset_12;

		// Token: 0x04010532 RID: 66866
		internal static int __PropertyOffset_13;

		// Token: 0x04010533 RID: 66867
		internal static int __PropertyOffset_14;

		// Token: 0x04010534 RID: 66868
		internal static int __PropertyOffset_15;

		// Token: 0x04010535 RID: 66869
		internal static int __PropertyOffset_16;

		// Token: 0x04010536 RID: 66870
		internal static int __PropertyOffset_17;

		// Token: 0x04010537 RID: 66871
		internal static int __PropertyOffset_18;

		// Token: 0x04010538 RID: 66872
		internal static int __PropertyOffset_19;

		// Token: 0x04010539 RID: 66873
		internal static int __PropertyOffset_20;

		// Token: 0x0401053A RID: 66874
		private TArray<int> _QualityDistanceList;

		// Token: 0x0401053B RID: 66875
		private static IntPtr __ShouldStopOnHide_NativeFunctionPtr;

		// Token: 0x0401053C RID: 66876
		private static IntPtr __GetAoiRange_NativeFunctionPtr;

		// Token: 0x0401053D RID: 66877
		private static IntPtr __ReInit_NativeFunctionPtr;

		// Token: 0x0401053E RID: 66878
		private static IntPtr __ConstructionMediaPlay_NativeFunctionPtr;

		// Token: 0x0401053F RID: 66879
		private static IntPtr __OpenSource_NativeFunctionPtr;

		// Token: 0x04010540 RID: 66880
		private static IntPtr __CloseSource_NativeFunctionPtr;

		// Token: 0x04010541 RID: 66881
		private static IntPtr __TickOutside_NativeFunctionPtr;

		// Token: 0x04010542 RID: 66882
		private static IntPtr __Pause_NativeFunctionPtr;

		// Token: 0x04010543 RID: 66883
		private static IntPtr __Resume_NativeFunctionPtr;

		// Token: 0x04010544 RID: 66884
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010545 RID: 66885
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010546 RID: 66886
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x04010547 RID: 66887
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x04010548 RID: 66888
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010549 RID: 66889
		private static IntPtr __PlaySound_NativeFunctionPtr;

		// Token: 0x0401054A RID: 66890
		private static IntPtr __CloseSound_NativeFunctionPtr;

		// Token: 0x0401054B RID: 66891
		private static IntPtr __ExecuteUbergraph_MediaPlayForModel_Extra_NativeFunctionPtr;

		// Token: 0x020099F4 RID: 39412
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x040320CF RID: 205007
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x020099F5 RID: 39413
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x040320D0 RID: 205008
			[FieldOffset(0)]
			public int ret;
		}

		// Token: 0x020099F6 RID: 39414
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040320D1 RID: 205009
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099F7 RID: 39415
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040320D2 RID: 205010
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020099F8 RID: 39416
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_MediaPlayForModel_Extra_FunctionParams
		{
			// Token: 0x040320D3 RID: 205011
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
