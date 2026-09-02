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
	// Token: 0x02003B26 RID: 15142
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel.MediaPlayForModel_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1440)]
	public class MediaPlayForModel_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_SceneBp_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602096B RID: 133483 RVA: 0x009311AC File Offset: 0x0092F3AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (MediaPlayForModel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel.MediaPlayForModel_C");
			}
			return MediaPlayForModel_C._ClassPtr;
		}

		// Token: 0x0602096C RID: 133484 RVA: 0x009311D0 File Offset: 0x0092F3D0
		public MediaPlayForModel_C() : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602096D RID: 133485 RVA: 0x009311F8 File Offset: 0x0092F3F8
		[NullableContext(1)]
		public MediaPlayForModel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003643 RID: 13891
		// (get) Token: 0x0602096E RID: 133486 RVA: 0x0093122C File Offset: 0x0092F42C
		// (set) Token: 0x0602096F RID: 133487 RVA: 0x00931265 File Offset: 0x0092F465
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003644 RID: 13892
		// (get) Token: 0x06020970 RID: 133488 RVA: 0x00931286 File Offset: 0x0092F486
		// (set) Token: 0x06020971 RID: 133489 RVA: 0x0093129A File Offset: 0x0092F49A
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003645 RID: 13893
		// (get) Token: 0x06020972 RID: 133490 RVA: 0x009312AF File Offset: 0x0092F4AF
		// (set) Token: 0x06020973 RID: 133491 RVA: 0x009312C3 File Offset: 0x0092F4C3
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003646 RID: 13894
		// (get) Token: 0x06020974 RID: 133492 RVA: 0x009312D8 File Offset: 0x0092F4D8
		// (set) Token: 0x06020975 RID: 133493 RVA: 0x009312EC File Offset: 0x0092F4EC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003647 RID: 13895
		// (get) Token: 0x06020976 RID: 133494 RVA: 0x00931301 File Offset: 0x0092F501
		// (set) Token: 0x06020977 RID: 133495 RVA: 0x00931315 File Offset: 0x0092F515
		public unsafe UMaterial ViedoMaterialTranSlucentTwoSide
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003648 RID: 13896
		// (get) Token: 0x06020978 RID: 133496 RVA: 0x0093132A File Offset: 0x0092F52A
		// (set) Token: 0x06020979 RID: 133497 RVA: 0x0093133E File Offset: 0x0092F53E
		public unsafe UMaterial ViedoMaterialTranSlucent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003649 RID: 13897
		// (get) Token: 0x0602097A RID: 133498 RVA: 0x00931353 File Offset: 0x0092F553
		// (set) Token: 0x0602097B RID: 133499 RVA: 0x00931367 File Offset: 0x0092F567
		public unsafe UMaterial ViedoMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700364A RID: 13898
		// (get) Token: 0x0602097C RID: 133500 RVA: 0x0093137C File Offset: 0x0092F57C
		// (set) Token: 0x0602097D RID: 133501 RVA: 0x0093138C File Offset: 0x0092F58C
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700364B RID: 13899
		// (get) Token: 0x0602097E RID: 133502 RVA: 0x0093139D File Offset: 0x0092F59D
		// (set) Token: 0x0602097F RID: 133503 RVA: 0x009313AD File Offset: 0x0092F5AD
		public unsafe float DarkIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700364C RID: 13900
		// (get) Token: 0x06020980 RID: 133504 RVA: 0x009313BE File Offset: 0x0092F5BE
		// (set) Token: 0x06020981 RID: 133505 RVA: 0x009313CE File Offset: 0x0092F5CE
		public unsafe int AoiDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700364D RID: 13901
		// (get) Token: 0x06020982 RID: 133506 RVA: 0x009313DF File Offset: 0x0092F5DF
		// (set) Token: 0x06020983 RID: 133507 RVA: 0x009313EF File Offset: 0x0092F5EF
		public unsafe bool Translucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700364E RID: 13902
		// (get) Token: 0x06020984 RID: 133508 RVA: 0x00931400 File Offset: 0x0092F600
		// (set) Token: 0x06020985 RID: 133509 RVA: 0x00931410 File Offset: 0x0092F610
		public unsafe bool TwoSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700364F RID: 13903
		// (get) Token: 0x06020986 RID: 133510 RVA: 0x00931421 File Offset: 0x0092F621
		// (set) Token: 0x06020987 RID: 133511 RVA: 0x00931431 File Offset: 0x0092F631
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003650 RID: 13904
		// (get) Token: 0x06020988 RID: 133512 RVA: 0x00931442 File Offset: 0x0092F642
		// (set) Token: 0x06020989 RID: 133513 RVA: 0x00931456 File Offset: 0x0092F656
		public unsafe PDA_MediaPlayDataAsset_C MediaPlayDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_MediaPlayDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003651 RID: 13905
		// (get) Token: 0x0602098A RID: 133514 RVA: 0x0093146B File Offset: 0x0092F66B
		// (set) Token: 0x0602098B RID: 133515 RVA: 0x0093147F File Offset: 0x0092F67F
		public unsafe UMediaPlayer ShareMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003652 RID: 13906
		// (get) Token: 0x0602098C RID: 133516 RVA: 0x00931494 File Offset: 0x0092F694
		// (set) Token: 0x0602098D RID: 133517 RVA: 0x009314A8 File Offset: 0x0092F6A8
		public unsafe UMediaTexture ShareMediaTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003653 RID: 13907
		// (get) Token: 0x0602098E RID: 133518 RVA: 0x009314BD File Offset: 0x0092F6BD
		// (set) Token: 0x0602098F RID: 133519 RVA: 0x009314CD File Offset: 0x0092F6CD
		public unsafe bool isOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003654 RID: 13908
		// (get) Token: 0x06020990 RID: 133520 RVA: 0x009314DE File Offset: 0x0092F6DE
		// (set) Token: 0x06020991 RID: 133521 RVA: 0x009314EE File Offset: 0x0092F6EE
		public unsafe bool DrawDebugAoi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003655 RID: 13909
		// (get) Token: 0x06020992 RID: 133522 RVA: 0x009314FF File Offset: 0x0092F6FF
		// (set) Token: 0x06020993 RID: 133523 RVA: 0x0093150F File Offset: 0x0092F70F
		public unsafe bool isStopOnHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003656 RID: 13910
		// (get) Token: 0x06020994 RID: 133524 RVA: 0x00931520 File Offset: 0x0092F720
		// (set) Token: 0x06020995 RID: 133525 RVA: 0x00931530 File Offset: 0x0092F730
		public unsafe bool enableQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003657 RID: 13911
		// (get) Token: 0x06020996 RID: 133526 RVA: 0x00931544 File Offset: 0x0092F744
		// (set) Token: 0x06020997 RID: 133527 RVA: 0x0093157D File Offset: 0x0092F77D
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
					result = (this._QualityDistanceList = new TArray<int>(base.NativePtr + (IntPtr)MediaPlayForModel_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.QualityDistanceList.CopyAssign(value);
			}
		}

		// Token: 0x06020998 RID: 133528 RVA: 0x0093158C File Offset: 0x0092F78C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldStopOnHide(ref bool ret)
		{
			MediaPlayForModel_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020999 RID: 133529 RVA: 0x009315DC File Offset: 0x0092F7DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAoiRange(ref int ret)
		{
			MediaPlayForModel_C.__GetAoiRange_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__GetAoiRange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x0602099A RID: 133530 RVA: 0x0093162B File Offset: 0x0092F82B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__ReInit_NativeFunctionPtr, null);
		}

		// Token: 0x0602099B RID: 133531 RVA: 0x0093163F File Offset: 0x0092F83F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ConstructionMediaPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__ConstructionMediaPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602099C RID: 133532 RVA: 0x00931653 File Offset: 0x0092F853
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__OpenSource_NativeFunctionPtr, null);
		}

		// Token: 0x0602099D RID: 133533 RVA: 0x00931667 File Offset: 0x0092F867
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__CloseSource_NativeFunctionPtr, null);
		}

		// Token: 0x0602099E RID: 133534 RVA: 0x0093167B File Offset: 0x0092F87B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x0602099F RID: 133535 RVA: 0x0093168F File Offset: 0x0092F88F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x060209A0 RID: 133536 RVA: 0x009316A3 File Offset: 0x0092F8A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x060209A1 RID: 133537 RVA: 0x009316B7 File Offset: 0x0092F8B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060209A2 RID: 133538 RVA: 0x009316CB File Offset: 0x0092F8CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060209A3 RID: 133539 RVA: 0x009316E0 File Offset: 0x0092F8E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			MediaPlayForModel_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060209A4 RID: 133540 RVA: 0x00931728 File Offset: 0x0092F928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			MediaPlayForModel_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209A5 RID: 133541 RVA: 0x0093176F File Offset: 0x0092F96F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x060209A6 RID: 133542 RVA: 0x00931783 File Offset: 0x0092F983
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060209A7 RID: 133543 RVA: 0x00931798 File Offset: 0x0092F998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x060209A8 RID: 133544 RVA: 0x009317AC File Offset: 0x0092F9AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x060209A9 RID: 133545 RVA: 0x009317C0 File Offset: 0x0092F9C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060209AA RID: 133546 RVA: 0x0093180C File Offset: 0x0092FA0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209AB RID: 133547 RVA: 0x00931858 File Offset: 0x0092FA58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlaySound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__PlaySound_NativeFunctionPtr, null);
		}

		// Token: 0x060209AC RID: 133548 RVA: 0x0093186C File Offset: 0x0092FA6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_C.__CloseSound_NativeFunctionPtr, null);
		}

		// Token: 0x060209AD RID: 133549 RVA: 0x00931880 File Offset: 0x0092FA80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_MediaPlayForModel(int EntryPoint)
		{
			MediaPlayForModel_C.__ExecuteUbergraph_MediaPlayForModel_FunctionParams* ptr = stackalloc MediaPlayForModel_C.__ExecuteUbergraph_MediaPlayForModel_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(MediaPlayForModel_C.__ExecuteUbergraph_MediaPlayForModel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_C.__ExecuteUbergraph_MediaPlayForModel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_C.__ExecuteUbergraph_MediaPlayForModel_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060209AE RID: 133550 RVA: 0x009318CA File Offset: 0x0092FACA
		protected MediaPlayForModel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040104F5 RID: 66805
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel.MediaPlayForModel_C";

		// Token: 0x040104F6 RID: 66806
		private static IntPtr _ClassPtr;

		// Token: 0x040104F7 RID: 66807
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040104F8 RID: 66808
		internal static int __PropertyOffset_0;

		// Token: 0x040104F9 RID: 66809
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040104FA RID: 66810
		internal static int __PropertyOffset_1;

		// Token: 0x040104FB RID: 66811
		internal static int __PropertyOffset_2;

		// Token: 0x040104FC RID: 66812
		internal static int __PropertyOffset_3;

		// Token: 0x040104FD RID: 66813
		internal static int __PropertyOffset_4;

		// Token: 0x040104FE RID: 66814
		internal static int __PropertyOffset_5;

		// Token: 0x040104FF RID: 66815
		internal static int __PropertyOffset_6;

		// Token: 0x04010500 RID: 66816
		internal static int __PropertyOffset_7;

		// Token: 0x04010501 RID: 66817
		internal static int __PropertyOffset_8;

		// Token: 0x04010502 RID: 66818
		internal static int __PropertyOffset_9;

		// Token: 0x04010503 RID: 66819
		internal static int __PropertyOffset_10;

		// Token: 0x04010504 RID: 66820
		internal static int __PropertyOffset_11;

		// Token: 0x04010505 RID: 66821
		internal static int __PropertyOffset_12;

		// Token: 0x04010506 RID: 66822
		internal static int __PropertyOffset_13;

		// Token: 0x04010507 RID: 66823
		internal static int __PropertyOffset_14;

		// Token: 0x04010508 RID: 66824
		internal static int __PropertyOffset_15;

		// Token: 0x04010509 RID: 66825
		internal static int __PropertyOffset_16;

		// Token: 0x0401050A RID: 66826
		internal static int __PropertyOffset_17;

		// Token: 0x0401050B RID: 66827
		internal static int __PropertyOffset_18;

		// Token: 0x0401050C RID: 66828
		internal static int __PropertyOffset_19;

		// Token: 0x0401050D RID: 66829
		internal static int __PropertyOffset_20;

		// Token: 0x0401050E RID: 66830
		private TArray<int> _QualityDistanceList;

		// Token: 0x0401050F RID: 66831
		private static IntPtr __ShouldStopOnHide_NativeFunctionPtr;

		// Token: 0x04010510 RID: 66832
		private static IntPtr __GetAoiRange_NativeFunctionPtr;

		// Token: 0x04010511 RID: 66833
		private static IntPtr __ReInit_NativeFunctionPtr;

		// Token: 0x04010512 RID: 66834
		private static IntPtr __ConstructionMediaPlay_NativeFunctionPtr;

		// Token: 0x04010513 RID: 66835
		private static IntPtr __OpenSource_NativeFunctionPtr;

		// Token: 0x04010514 RID: 66836
		private static IntPtr __CloseSource_NativeFunctionPtr;

		// Token: 0x04010515 RID: 66837
		private static IntPtr __TickOutside_NativeFunctionPtr;

		// Token: 0x04010516 RID: 66838
		private static IntPtr __Pause_NativeFunctionPtr;

		// Token: 0x04010517 RID: 66839
		private static IntPtr __Resume_NativeFunctionPtr;

		// Token: 0x04010518 RID: 66840
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010519 RID: 66841
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401051A RID: 66842
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x0401051B RID: 66843
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0401051C RID: 66844
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x0401051D RID: 66845
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0401051E RID: 66846
		private static IntPtr __PlaySound_NativeFunctionPtr;

		// Token: 0x0401051F RID: 66847
		private static IntPtr __CloseSound_NativeFunctionPtr;

		// Token: 0x04010520 RID: 66848
		private static IntPtr __ExecuteUbergraph_MediaPlayForModel_NativeFunctionPtr;

		// Token: 0x020099EF RID: 39407
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x040320CA RID: 205002
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x020099F0 RID: 39408
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x040320CB RID: 205003
			[FieldOffset(0)]
			public int ret;
		}

		// Token: 0x020099F1 RID: 39409
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040320CC RID: 205004
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099F2 RID: 39410
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040320CD RID: 205005
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020099F3 RID: 39411
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_MediaPlayForModel_FunctionParams
		{
			// Token: 0x040320CE RID: 205006
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
