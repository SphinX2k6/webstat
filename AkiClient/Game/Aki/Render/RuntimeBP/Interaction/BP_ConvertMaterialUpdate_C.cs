using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C77 RID: 15479
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_ConvertMaterialUpdate.BP_ConvertMaterialUpdate_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_ConvertMaterialUpdate_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023F26 RID: 147238 RVA: 0x00990680 File Offset: 0x0098E880
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ConvertMaterialUpdate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_ConvertMaterialUpdate.BP_ConvertMaterialUpdate_C");
			}
			return BP_ConvertMaterialUpdate_C._ClassPtr;
		}

		// Token: 0x06023F27 RID: 147239 RVA: 0x009906A4 File Offset: 0x0098E8A4
		public BP_ConvertMaterialUpdate_C() : this(BuiltinUtils.AllocNativeUObject(BP_ConvertMaterialUpdate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023F28 RID: 147240 RVA: 0x009906CC File Offset: 0x0098E8CC
		public BP_ConvertMaterialUpdate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ConvertMaterialUpdate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004930 RID: 18736
		// (get) Token: 0x06023F29 RID: 147241 RVA: 0x00990700 File Offset: 0x0098E900
		// (set) Token: 0x06023F2A RID: 147242 RVA: 0x00990739 File Offset: 0x0098E939
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004931 RID: 18737
		// (get) Token: 0x06023F2B RID: 147243 RVA: 0x0099075A File Offset: 0x0098E95A
		// (set) Token: 0x06023F2C RID: 147244 RVA: 0x0099076E File Offset: 0x0098E96E
		[Nullable(2)]
		public unsafe USceneComponent StartPoint
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004932 RID: 18738
		// (get) Token: 0x06023F2D RID: 147245 RVA: 0x00990783 File Offset: 0x0098E983
		// (set) Token: 0x06023F2E RID: 147246 RVA: 0x00990797 File Offset: 0x0098E997
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004933 RID: 18739
		// (get) Token: 0x06023F2F RID: 147247 RVA: 0x009907AC File Offset: 0x0098E9AC
		// (set) Token: 0x06023F30 RID: 147248 RVA: 0x009907C0 File Offset: 0x0098E9C0
		public unsafe FName StartPositionName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004934 RID: 18740
		// (get) Token: 0x06023F31 RID: 147249 RVA: 0x009907D5 File Offset: 0x0098E9D5
		// (set) Token: 0x06023F32 RID: 147250 RVA: 0x009907E9 File Offset: 0x0098E9E9
		public unsafe FName Diffusion_Size_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004935 RID: 18741
		// (get) Token: 0x06023F33 RID: 147251 RVA: 0x00990800 File Offset: 0x0098EA00
		// (set) Token: 0x06023F34 RID: 147252 RVA: 0x00990839 File Offset: 0x0098EA39
		public TArray<UMaterialInstance> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x17004936 RID: 18742
		// (get) Token: 0x06023F35 RID: 147253 RVA: 0x00990847 File Offset: 0x0098EA47
		// (set) Token: 0x06023F36 RID: 147254 RVA: 0x00990857 File Offset: 0x0098EA57
		public unsafe float Real_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004937 RID: 18743
		// (get) Token: 0x06023F37 RID: 147255 RVA: 0x00990868 File Offset: 0x0098EA68
		// (set) Token: 0x06023F38 RID: 147256 RVA: 0x00990878 File Offset: 0x0098EA78
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004938 RID: 18744
		// (get) Token: 0x06023F39 RID: 147257 RVA: 0x00990889 File Offset: 0x0098EA89
		// (set) Token: 0x06023F3A RID: 147258 RVA: 0x0099089D File Offset: 0x0098EA9D
		public unsafe FName Progress_name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004939 RID: 18745
		// (get) Token: 0x06023F3B RID: 147259 RVA: 0x009908B2 File Offset: 0x0098EAB2
		// (set) Token: 0x06023F3C RID: 147260 RVA: 0x009908C2 File Offset: 0x0098EAC2
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700493A RID: 18746
		// (get) Token: 0x06023F3D RID: 147261 RVA: 0x009908D3 File Offset: 0x0098EAD3
		// (set) Token: 0x06023F3E RID: 147262 RVA: 0x009908E3 File Offset: 0x0098EAE3
		public unsafe float Diffsuion_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700493B RID: 18747
		// (get) Token: 0x06023F3F RID: 147263 RVA: 0x009908F4 File Offset: 0x0098EAF4
		// (set) Token: 0x06023F40 RID: 147264 RVA: 0x00990908 File Offset: 0x0098EB08
		public unsafe FName DebugName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700493C RID: 18748
		// (get) Token: 0x06023F41 RID: 147265 RVA: 0x00990920 File Offset: 0x0098EB20
		// (set) Token: 0x06023F42 RID: 147266 RVA: 0x00990959 File Offset: 0x0098EB59
		public TArray<AStaticMeshActor> SwitchActor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SwitchActor) == null)
				{
					result = (this._SwitchActor = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.SwitchActor.CopyAssign(value);
			}
		}

		// Token: 0x1700493D RID: 18749
		// (get) Token: 0x06023F43 RID: 147267 RVA: 0x00990967 File Offset: 0x0098EB67
		// (set) Token: 0x06023F44 RID: 147268 RVA: 0x0099097B File Offset: 0x0098EB7B
		[Nullable(2)]
		public unsafe UMaterialInstance Material_Instance
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700493E RID: 18750
		// (get) Token: 0x06023F45 RID: 147269 RVA: 0x00990990 File Offset: 0x0098EB90
		// (set) Token: 0x06023F46 RID: 147270 RVA: 0x009909C9 File Offset: 0x0098EBC9
		public TArray<AStaticMeshActor> SpawnerMeshActor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SpawnerMeshActor) == null)
				{
					result = (this._SpawnerMeshActor = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.SpawnerMeshActor.CopyAssign(value);
			}
		}

		// Token: 0x1700493F RID: 18751
		// (get) Token: 0x06023F47 RID: 147271 RVA: 0x009909D8 File Offset: 0x0098EBD8
		// (set) Token: 0x06023F48 RID: 147272 RVA: 0x00990A11 File Offset: 0x0098EC11
		public TArray<AStaticMeshActor> SpawnedMeshActor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SpawnedMeshActor) == null)
				{
					result = (this._SpawnedMeshActor = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.SpawnedMeshActor.CopyAssign(value);
			}
		}

		// Token: 0x17004940 RID: 18752
		// (get) Token: 0x06023F49 RID: 147273 RVA: 0x00990A1F File Offset: 0x0098EC1F
		// (set) Token: 0x06023F4A RID: 147274 RVA: 0x00990A33 File Offset: 0x0098EC33
		public unsafe FName ReverseName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004941 RID: 18753
		// (get) Token: 0x06023F4B RID: 147275 RVA: 0x00990A48 File Offset: 0x0098EC48
		// (set) Token: 0x06023F4C RID: 147276 RVA: 0x00990A58 File Offset: 0x0098EC58
		public unsafe int Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004942 RID: 18754
		// (get) Token: 0x06023F4D RID: 147277 RVA: 0x00990A69 File Offset: 0x0098EC69
		// (set) Token: 0x06023F4E RID: 147278 RVA: 0x00990A79 File Offset: 0x0098EC79
		public unsafe bool NeedDestory
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004943 RID: 18755
		// (get) Token: 0x06023F4F RID: 147279 RVA: 0x00990A8C File Offset: 0x0098EC8C
		// (set) Token: 0x06023F50 RID: 147280 RVA: 0x00990AC5 File Offset: 0x0098ECC5
		public FKuroCurveFloat ProgressCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._ProgressCurve) == null)
				{
					result = (this._ProgressCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004944 RID: 18756
		// (get) Token: 0x06023F51 RID: 147281 RVA: 0x00990AE6 File Offset: 0x0098ECE6
		// (set) Token: 0x06023F52 RID: 147282 RVA: 0x00990AF6 File Offset: 0x0098ECF6
		public unsafe bool EnableDA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004945 RID: 18757
		// (get) Token: 0x06023F53 RID: 147283 RVA: 0x00990B07 File Offset: 0x0098ED07
		// (set) Token: 0x06023F54 RID: 147284 RVA: 0x00990B1B File Offset: 0x0098ED1B
		[Nullable(2)]
		public unsafe ItemMaterialControllerActorData DA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerActorData>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConvertMaterialUpdate_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004946 RID: 18758
		// (get) Token: 0x06023F55 RID: 147285 RVA: 0x00990B30 File Offset: 0x0098ED30
		// (set) Token: 0x06023F56 RID: 147286 RVA: 0x00990B40 File Offset: 0x0098ED40
		public unsafe int TEMP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004947 RID: 18759
		// (get) Token: 0x06023F57 RID: 147287 RVA: 0x00990B51 File Offset: 0x0098ED51
		// (set) Token: 0x06023F58 RID: 147288 RVA: 0x00990B61 File Offset: 0x0098ED61
		public unsafe bool EnableMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004948 RID: 18760
		// (get) Token: 0x06023F59 RID: 147289 RVA: 0x00990B72 File Offset: 0x0098ED72
		// (set) Token: 0x06023F5A RID: 147290 RVA: 0x00990B82 File Offset: 0x0098ED82
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004949 RID: 18761
		// (get) Token: 0x06023F5B RID: 147291 RVA: 0x00990B94 File Offset: 0x0098ED94
		// (set) Token: 0x06023F5C RID: 147292 RVA: 0x00990BCD File Offset: 0x0098EDCD
		public TArray<bool> Hidden
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._Hidden) == null)
				{
					result = (this._Hidden = new TArray<bool>(base.NativePtr + (IntPtr)BP_ConvertMaterialUpdate_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.Hidden.CopyAssign(value);
			}
		}

		// Token: 0x06023F5D RID: 147293 RVA: 0x00990BDB File Offset: 0x0098EDDB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReadAndSet()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReadAndSet_NativeFunctionPtr, null);
		}

		// Token: 0x06023F5E RID: 147294 RVA: 0x00990BEF File Offset: 0x0098EDEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReadAndSet_DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReadAndSet_DA_NativeFunctionPtr, null);
		}

		// Token: 0x06023F5F RID: 147295 RVA: 0x00990C03 File Offset: 0x0098EE03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__DisableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023F60 RID: 147296 RVA: 0x00990C17 File Offset: 0x0098EE17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__EnableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023F61 RID: 147297 RVA: 0x00990C2B File Offset: 0x0098EE2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreatAndChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__CreatAndChange_NativeFunctionPtr, null);
		}

		// Token: 0x06023F62 RID: 147298 RVA: 0x00990C3F File Offset: 0x0098EE3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023F63 RID: 147299 RVA: 0x00990C53 File Offset: 0x0098EE53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F64 RID: 147300 RVA: 0x00990C68 File Offset: 0x0098EE68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023F65 RID: 147301 RVA: 0x00990C7C File Offset: 0x0098EE7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F66 RID: 147302 RVA: 0x00990C94 File Offset: 0x0098EE94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConvertMaterialUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F67 RID: 147303 RVA: 0x00990CDC File Offset: 0x0098EEDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConvertMaterialUpdate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConvertMaterialUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F68 RID: 147304 RVA: 0x00990D24 File Offset: 0x0098EF24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F69 RID: 147305 RVA: 0x00990D70 File Offset: 0x0098EF70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F6A RID: 147306 RVA: 0x00990DBC File Offset: 0x0098EFBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ConvertMaterialUpdate(int EntryPoint)
		{
			BP_ConvertMaterialUpdate_C.__ExecuteUbergraph_BP_ConvertMaterialUpdate_FunctionParams* ptr = stackalloc BP_ConvertMaterialUpdate_C.__ExecuteUbergraph_BP_ConvertMaterialUpdate_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_ConvertMaterialUpdate_C.__ExecuteUbergraph_BP_ConvertMaterialUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConvertMaterialUpdate_C.__ExecuteUbergraph_BP_ConvertMaterialUpdate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConvertMaterialUpdate_C.__ExecuteUbergraph_BP_ConvertMaterialUpdate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F6B RID: 147307 RVA: 0x00990E03 File Offset: 0x0098F003
		protected BP_ConvertMaterialUpdate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040125D2 RID: 75218
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_ConvertMaterialUpdate.BP_ConvertMaterialUpdate_C";

		// Token: 0x040125D3 RID: 75219
		private static IntPtr _ClassPtr;

		// Token: 0x040125D4 RID: 75220
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040125D5 RID: 75221
		internal static int __PropertyOffset_0;

		// Token: 0x040125D6 RID: 75222
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040125D7 RID: 75223
		internal static int __PropertyOffset_1;

		// Token: 0x040125D8 RID: 75224
		internal static int __PropertyOffset_2;

		// Token: 0x040125D9 RID: 75225
		internal static int __PropertyOffset_3;

		// Token: 0x040125DA RID: 75226
		internal static int __PropertyOffset_4;

		// Token: 0x040125DB RID: 75227
		internal static int __PropertyOffset_5;

		// Token: 0x040125DC RID: 75228
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Materials;

		// Token: 0x040125DD RID: 75229
		internal static int __PropertyOffset_6;

		// Token: 0x040125DE RID: 75230
		internal static int __PropertyOffset_7;

		// Token: 0x040125DF RID: 75231
		internal static int __PropertyOffset_8;

		// Token: 0x040125E0 RID: 75232
		internal static int __PropertyOffset_9;

		// Token: 0x040125E1 RID: 75233
		internal static int __PropertyOffset_10;

		// Token: 0x040125E2 RID: 75234
		internal static int __PropertyOffset_11;

		// Token: 0x040125E3 RID: 75235
		internal static int __PropertyOffset_12;

		// Token: 0x040125E4 RID: 75236
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SwitchActor;

		// Token: 0x040125E5 RID: 75237
		internal static int __PropertyOffset_13;

		// Token: 0x040125E6 RID: 75238
		internal static int __PropertyOffset_14;

		// Token: 0x040125E7 RID: 75239
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SpawnerMeshActor;

		// Token: 0x040125E8 RID: 75240
		internal static int __PropertyOffset_15;

		// Token: 0x040125E9 RID: 75241
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SpawnedMeshActor;

		// Token: 0x040125EA RID: 75242
		internal static int __PropertyOffset_16;

		// Token: 0x040125EB RID: 75243
		internal static int __PropertyOffset_17;

		// Token: 0x040125EC RID: 75244
		internal static int __PropertyOffset_18;

		// Token: 0x040125ED RID: 75245
		internal static int __PropertyOffset_19;

		// Token: 0x040125EE RID: 75246
		[Nullable(2)]
		private FKuroCurveFloat _ProgressCurve;

		// Token: 0x040125EF RID: 75247
		internal static int __PropertyOffset_20;

		// Token: 0x040125F0 RID: 75248
		internal static int __PropertyOffset_21;

		// Token: 0x040125F1 RID: 75249
		internal static int __PropertyOffset_22;

		// Token: 0x040125F2 RID: 75250
		internal static int __PropertyOffset_23;

		// Token: 0x040125F3 RID: 75251
		internal static int __PropertyOffset_24;

		// Token: 0x040125F4 RID: 75252
		internal static int __PropertyOffset_25;

		// Token: 0x040125F5 RID: 75253
		[Nullable(2)]
		private TArray<bool> _Hidden;

		// Token: 0x040125F6 RID: 75254
		private static IntPtr __ReadAndSet_NativeFunctionPtr;

		// Token: 0x040125F7 RID: 75255
		private static IntPtr __ReadAndSet_DA_NativeFunctionPtr;

		// Token: 0x040125F8 RID: 75256
		private static IntPtr __DisableTick_NativeFunctionPtr;

		// Token: 0x040125F9 RID: 75257
		private static IntPtr __EnableTick_NativeFunctionPtr;

		// Token: 0x040125FA RID: 75258
		private static IntPtr __CreatAndChange_NativeFunctionPtr;

		// Token: 0x040125FB RID: 75259
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040125FC RID: 75260
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040125FD RID: 75261
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040125FE RID: 75262
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040125FF RID: 75263
		private static IntPtr __ExecuteUbergraph_BP_ConvertMaterialUpdate_NativeFunctionPtr;

		// Token: 0x02009D69 RID: 40297
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403275E RID: 206686
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D6A RID: 40298
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403275F RID: 206687
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D6B RID: 40299
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_ConvertMaterialUpdate_FunctionParams
		{
			// Token: 0x04032760 RID: 206688
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
