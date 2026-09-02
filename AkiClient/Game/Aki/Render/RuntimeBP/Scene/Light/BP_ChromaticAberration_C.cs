using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A78 RID: 14968
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ChromaticAberration.BP_ChromaticAberration_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1680)]
	public class BP_ChromaticAberration_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F3B5 RID: 127925 RVA: 0x0090C4E4 File Offset: 0x0090A6E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ChromaticAberration_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ChromaticAberration.BP_ChromaticAberration_C");
			}
			return BP_ChromaticAberration_C._ClassPtr;
		}

		// Token: 0x0601F3B6 RID: 127926 RVA: 0x0090C508 File Offset: 0x0090A708
		public BP_ChromaticAberration_C() : this(BuiltinUtils.AllocNativeUObject(BP_ChromaticAberration_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F3B7 RID: 127927 RVA: 0x0090C530 File Offset: 0x0090A730
		[NullableContext(1)]
		public BP_ChromaticAberration_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ChromaticAberration_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002EA9 RID: 11945
		// (get) Token: 0x0601F3B8 RID: 127928 RVA: 0x0090C564 File Offset: 0x0090A764
		// (set) Token: 0x0601F3B9 RID: 127929 RVA: 0x0090C59D File Offset: 0x0090A79D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002EAA RID: 11946
		// (get) Token: 0x0601F3BA RID: 127930 RVA: 0x0090C5BE File Offset: 0x0090A7BE
		// (set) Token: 0x0601F3BB RID: 127931 RVA: 0x0090C5D2 File Offset: 0x0090A7D2
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EAB RID: 11947
		// (get) Token: 0x0601F3BC RID: 127932 RVA: 0x0090C5E7 File Offset: 0x0090A7E7
		// (set) Token: 0x0601F3BD RID: 127933 RVA: 0x0090C5FB File Offset: 0x0090A7FB
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EAC RID: 11948
		// (get) Token: 0x0601F3BE RID: 127934 RVA: 0x0090C610 File Offset: 0x0090A810
		// (set) Token: 0x0601F3BF RID: 127935 RVA: 0x0090C624 File Offset: 0x0090A824
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002EAD RID: 11949
		// (get) Token: 0x0601F3C0 RID: 127936 RVA: 0x0090C639 File Offset: 0x0090A839
		// (set) Token: 0x0601F3C1 RID: 127937 RVA: 0x0090C64D File Offset: 0x0090A84D
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002EAE RID: 11950
		// (get) Token: 0x0601F3C2 RID: 127938 RVA: 0x0090C662 File Offset: 0x0090A862
		// (set) Token: 0x0601F3C3 RID: 127939 RVA: 0x0090C672 File Offset: 0x0090A872
		public unsafe float CenterX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002EAF RID: 11951
		// (get) Token: 0x0601F3C4 RID: 127940 RVA: 0x0090C684 File Offset: 0x0090A884
		// (set) Token: 0x0601F3C5 RID: 127941 RVA: 0x0090C6BD File Offset: 0x0090A8BD
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EB0 RID: 11952
		// (get) Token: 0x0601F3C6 RID: 127942 RVA: 0x0090C6CC File Offset: 0x0090A8CC
		// (set) Token: 0x0601F3C7 RID: 127943 RVA: 0x0090C705 File Offset: 0x0090A905
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EB1 RID: 11953
		// (get) Token: 0x0601F3C8 RID: 127944 RVA: 0x0090C714 File Offset: 0x0090A914
		// (set) Token: 0x0601F3C9 RID: 127945 RVA: 0x0090C74D File Offset: 0x0090A94D
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EB2 RID: 11954
		// (get) Token: 0x0601F3CA RID: 127946 RVA: 0x0090C75B File Offset: 0x0090A95B
		// (set) Token: 0x0601F3CB RID: 127947 RVA: 0x0090C76B File Offset: 0x0090A96B
		public unsafe float CenterY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002EB3 RID: 11955
		// (get) Token: 0x0601F3CC RID: 127948 RVA: 0x0090C77C File Offset: 0x0090A97C
		// (set) Token: 0x0601F3CD RID: 127949 RVA: 0x0090C790 File Offset: 0x0090A990
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002EB4 RID: 11956
		// (get) Token: 0x0601F3CE RID: 127950 RVA: 0x0090C7A5 File Offset: 0x0090A9A5
		// (set) Token: 0x0601F3CF RID: 127951 RVA: 0x0090C7B5 File Offset: 0x0090A9B5
		public unsafe float BlurIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002EB5 RID: 11957
		// (get) Token: 0x0601F3D0 RID: 127952 RVA: 0x0090C7C6 File Offset: 0x0090A9C6
		// (set) Token: 0x0601F3D1 RID: 127953 RVA: 0x0090C7DA File Offset: 0x0090A9DA
		public unsafe UTexture SpectralLUT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002EB6 RID: 11958
		// (get) Token: 0x0601F3D2 RID: 127954 RVA: 0x0090C7EF File Offset: 0x0090A9EF
		// (set) Token: 0x0601F3D3 RID: 127955 RVA: 0x0090C7FF File Offset: 0x0090A9FF
		public unsafe float Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002EB7 RID: 11959
		// (get) Token: 0x0601F3D4 RID: 127956 RVA: 0x0090C810 File Offset: 0x0090AA10
		// (set) Token: 0x0601F3D5 RID: 127957 RVA: 0x0090C820 File Offset: 0x0090AA20
		public unsafe int ToonDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002EB8 RID: 11960
		// (get) Token: 0x0601F3D6 RID: 127958 RVA: 0x0090C831 File Offset: 0x0090AA31
		// (set) Token: 0x0601F3D7 RID: 127959 RVA: 0x0090C841 File Offset: 0x0090AA41
		public unsafe float Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002EB9 RID: 11961
		// (get) Token: 0x0601F3D8 RID: 127960 RVA: 0x0090C852 File Offset: 0x0090AA52
		// (set) Token: 0x0601F3D9 RID: 127961 RVA: 0x0090C862 File Offset: 0x0090AA62
		public unsafe bool bEnableActorPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002EBA RID: 11962
		// (get) Token: 0x0601F3DA RID: 127962 RVA: 0x0090C873 File Offset: 0x0090AA73
		// (set) Token: 0x0601F3DB RID: 127963 RVA: 0x0090C883 File Offset: 0x0090AA83
		public unsafe bool DisableStencilTest
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002EBB RID: 11963
		// (get) Token: 0x0601F3DC RID: 127964 RVA: 0x0090C894 File Offset: 0x0090AA94
		// (set) Token: 0x0601F3DD RID: 127965 RVA: 0x0090C8A8 File Offset: 0x0090AAA8
		public unsafe UMaterialInstance Material_DisableStencil
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChromaticAberration_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002EBC RID: 11964
		// (get) Token: 0x0601F3DE RID: 127966 RVA: 0x0090C8BD File Offset: 0x0090AABD
		// (set) Token: 0x0601F3DF RID: 127967 RVA: 0x0090C8CD File Offset: 0x0090AACD
		public unsafe float Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002EBD RID: 11965
		// (get) Token: 0x0601F3E0 RID: 127968 RVA: 0x0090C8DE File Offset: 0x0090AADE
		// (set) Token: 0x0601F3E1 RID: 127969 RVA: 0x0090C8EE File Offset: 0x0090AAEE
		public unsafe float ProtectCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002EBE RID: 11966
		// (get) Token: 0x0601F3E2 RID: 127970 RVA: 0x0090C8FF File Offset: 0x0090AAFF
		// (set) Token: 0x0601F3E3 RID: 127971 RVA: 0x0090C913 File Offset: 0x0090AB13
		public unsafe FName NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002EBF RID: 11967
		// (get) Token: 0x0601F3E4 RID: 127972 RVA: 0x0090C928 File Offset: 0x0090AB28
		// (set) Token: 0x0601F3E5 RID: 127973 RVA: 0x0090C938 File Offset: 0x0090AB38
		public unsafe float Falloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ChromaticAberration_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x0601F3E6 RID: 127974 RVA: 0x0090C949 File Offset: 0x0090AB49
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3E7 RID: 127975 RVA: 0x0090C95D File Offset: 0x0090AB5D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3E8 RID: 127976 RVA: 0x0090C971 File Offset: 0x0090AB71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3E9 RID: 127977 RVA: 0x0090C986 File Offset: 0x0090AB86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3EA RID: 127978 RVA: 0x0090C99A File Offset: 0x0090AB9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3EB RID: 127979 RVA: 0x0090C9B0 File Offset: 0x0090ABB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ChromaticAberration_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ChromaticAberration_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChromaticAberration_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChromaticAberration_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F3EC RID: 127980 RVA: 0x0090C9F8 File Offset: 0x0090ABF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ChromaticAberration_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ChromaticAberration_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChromaticAberration_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChromaticAberration_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3ED RID: 127981 RVA: 0x0090CA3F File Offset: 0x0090AC3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3EE RID: 127982 RVA: 0x0090CA53 File Offset: 0x0090AC53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3EF RID: 127983 RVA: 0x0090CA68 File Offset: 0x0090AC68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ChromaticAberration_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ChromaticAberration_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChromaticAberration_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChromaticAberration_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChromaticAberration_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F3F0 RID: 127984 RVA: 0x0090CAB0 File Offset: 0x0090ACB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ChromaticAberration_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ChromaticAberration_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChromaticAberration_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChromaticAberration_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3F1 RID: 127985 RVA: 0x0090CAF8 File Offset: 0x0090ACF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ChromaticAberration(int EntryPoint)
		{
			BP_ChromaticAberration_C.__ExecuteUbergraph_BP_ChromaticAberration_FunctionParams* ptr = stackalloc BP_ChromaticAberration_C.__ExecuteUbergraph_BP_ChromaticAberration_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_ChromaticAberration_C.__ExecuteUbergraph_BP_ChromaticAberration_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChromaticAberration_C.__ExecuteUbergraph_BP_ChromaticAberration_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChromaticAberration_C.__ExecuteUbergraph_BP_ChromaticAberration_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3F2 RID: 127986 RVA: 0x0090CB42 File Offset: 0x0090AD42
		protected BP_ChromaticAberration_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F7E1 RID: 63457
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ChromaticAberration.BP_ChromaticAberration_C";

		// Token: 0x0400F7E2 RID: 63458
		private static IntPtr _ClassPtr;

		// Token: 0x0400F7E3 RID: 63459
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F7E4 RID: 63460
		internal static int __PropertyOffset_0;

		// Token: 0x0400F7E5 RID: 63461
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F7E6 RID: 63462
		internal static int __PropertyOffset_1;

		// Token: 0x0400F7E7 RID: 63463
		internal static int __PropertyOffset_2;

		// Token: 0x0400F7E8 RID: 63464
		internal static int __PropertyOffset_3;

		// Token: 0x0400F7E9 RID: 63465
		internal static int __PropertyOffset_4;

		// Token: 0x0400F7EA RID: 63466
		internal static int __PropertyOffset_5;

		// Token: 0x0400F7EB RID: 63467
		internal static int __PropertyOffset_6;

		// Token: 0x0400F7EC RID: 63468
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F7ED RID: 63469
		internal static int __PropertyOffset_7;

		// Token: 0x0400F7EE RID: 63470
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F7EF RID: 63471
		internal static int __PropertyOffset_8;

		// Token: 0x0400F7F0 RID: 63472
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F7F1 RID: 63473
		internal static int __PropertyOffset_9;

		// Token: 0x0400F7F2 RID: 63474
		internal static int __PropertyOffset_10;

		// Token: 0x0400F7F3 RID: 63475
		internal static int __PropertyOffset_11;

		// Token: 0x0400F7F4 RID: 63476
		internal static int __PropertyOffset_12;

		// Token: 0x0400F7F5 RID: 63477
		internal static int __PropertyOffset_13;

		// Token: 0x0400F7F6 RID: 63478
		internal static int __PropertyOffset_14;

		// Token: 0x0400F7F7 RID: 63479
		internal static int __PropertyOffset_15;

		// Token: 0x0400F7F8 RID: 63480
		internal static int __PropertyOffset_16;

		// Token: 0x0400F7F9 RID: 63481
		internal static int __PropertyOffset_17;

		// Token: 0x0400F7FA RID: 63482
		internal static int __PropertyOffset_18;

		// Token: 0x0400F7FB RID: 63483
		internal static int __PropertyOffset_19;

		// Token: 0x0400F7FC RID: 63484
		internal static int __PropertyOffset_20;

		// Token: 0x0400F7FD RID: 63485
		internal static int __PropertyOffset_21;

		// Token: 0x0400F7FE RID: 63486
		internal static int __PropertyOffset_22;

		// Token: 0x0400F7FF RID: 63487
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F800 RID: 63488
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F801 RID: 63489
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F802 RID: 63490
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F803 RID: 63491
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F804 RID: 63492
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F805 RID: 63493
		private static IntPtr __ExecuteUbergraph_BP_ChromaticAberration_NativeFunctionPtr;

		// Token: 0x020098B3 RID: 39091
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F04 RID: 204548
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B4 RID: 39092
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F05 RID: 204549
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B5 RID: 39093
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_BP_ChromaticAberration_FunctionParams
		{
			// Token: 0x04031F06 RID: 204550
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
