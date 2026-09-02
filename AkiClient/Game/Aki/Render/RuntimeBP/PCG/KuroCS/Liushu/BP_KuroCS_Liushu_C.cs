using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Liushu
{
	// Token: 0x02003BFA RID: 15354
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/BP_KuroCS_Liushu.BP_KuroCS_Liushu_C")]
	[UnrealStructLayout(1888, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1882)]
	public class BP_KuroCS_Liushu_C : AKuroCS_liuShu, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022B9B RID: 142235 RVA: 0x0096D234 File Offset: 0x0096B434
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCS_Liushu_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/BP_KuroCS_Liushu.BP_KuroCS_Liushu_C");
			}
			return BP_KuroCS_Liushu_C._ClassPtr;
		}

		// Token: 0x06022B9C RID: 142236 RVA: 0x0096D258 File Offset: 0x0096B458
		public BP_KuroCS_Liushu_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCS_Liushu_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022B9D RID: 142237 RVA: 0x0096D280 File Offset: 0x0096B480
		public BP_KuroCS_Liushu_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCS_Liushu_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700426B RID: 17003
		// (get) Token: 0x06022B9E RID: 142238 RVA: 0x0096D2B4 File Offset: 0x0096B4B4
		// (set) Token: 0x06022B9F RID: 142239 RVA: 0x0096D2ED File Offset: 0x0096B4ED
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700426C RID: 17004
		// (get) Token: 0x06022BA0 RID: 142240 RVA: 0x0096D30E File Offset: 0x0096B50E
		// (set) Token: 0x06022BA1 RID: 142241 RVA: 0x0096D322 File Offset: 0x0096B522
		[Nullable(2)]
		public unsafe UStaticMeshComponent PlantMeshXZ
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700426D RID: 17005
		// (get) Token: 0x06022BA2 RID: 142242 RVA: 0x0096D337 File Offset: 0x0096B537
		// (set) Token: 0x06022BA3 RID: 142243 RVA: 0x0096D34B File Offset: 0x0096B54B
		[Nullable(2)]
		public unsafe UBoxComponent ValidBox
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700426E RID: 17006
		// (get) Token: 0x06022BA4 RID: 142244 RVA: 0x0096D360 File Offset: 0x0096B560
		// (set) Token: 0x06022BA5 RID: 142245 RVA: 0x0096D374 File Offset: 0x0096B574
		[Nullable(2)]
		public unsafe UDataTable dataTable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Liushu_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700426F RID: 17007
		// (get) Token: 0x06022BA6 RID: 142246 RVA: 0x0096D389 File Offset: 0x0096B589
		// (set) Token: 0x06022BA7 RID: 142247 RVA: 0x0096D399 File Offset: 0x0096B599
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004270 RID: 17008
		// (get) Token: 0x06022BA8 RID: 142248 RVA: 0x0096D3AA File Offset: 0x0096B5AA
		// (set) Token: 0x06022BA9 RID: 142249 RVA: 0x0096D3BA File Offset: 0x0096B5BA
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004271 RID: 17009
		// (get) Token: 0x06022BAA RID: 142250 RVA: 0x0096D3CB File Offset: 0x0096B5CB
		// (set) Token: 0x06022BAB RID: 142251 RVA: 0x0096D3DB File Offset: 0x0096B5DB
		public unsafe float WindForceMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004272 RID: 17010
		// (get) Token: 0x06022BAC RID: 142252 RVA: 0x0096D3EC File Offset: 0x0096B5EC
		// (set) Token: 0x06022BAD RID: 142253 RVA: 0x0096D3FC File Offset: 0x0096B5FC
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004273 RID: 17011
		// (get) Token: 0x06022BAE RID: 142254 RVA: 0x0096D40D File Offset: 0x0096B60D
		// (set) Token: 0x06022BAF RID: 142255 RVA: 0x0096D41D File Offset: 0x0096B61D
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004274 RID: 17012
		// (get) Token: 0x06022BB0 RID: 142256 RVA: 0x0096D42E File Offset: 0x0096B62E
		// (set) Token: 0x06022BB1 RID: 142257 RVA: 0x0096D43E File Offset: 0x0096B63E
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004275 RID: 17013
		// (get) Token: 0x06022BB2 RID: 142258 RVA: 0x0096D44F File Offset: 0x0096B64F
		// (set) Token: 0x06022BB3 RID: 142259 RVA: 0x0096D45F File Offset: 0x0096B65F
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004276 RID: 17014
		// (get) Token: 0x06022BB4 RID: 142260 RVA: 0x0096D470 File Offset: 0x0096B670
		// (set) Token: 0x06022BB5 RID: 142261 RVA: 0x0096D480 File Offset: 0x0096B680
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004277 RID: 17015
		// (get) Token: 0x06022BB6 RID: 142262 RVA: 0x0096D494 File Offset: 0x0096B694
		// (set) Token: 0x06022BB7 RID: 142263 RVA: 0x0096D4CD File Offset: 0x0096B6CD
		public TMap<FName, float> Scalar_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004278 RID: 17016
		// (get) Token: 0x06022BB8 RID: 142264 RVA: 0x0096D4DC File Offset: 0x0096B6DC
		// (set) Token: 0x06022BB9 RID: 142265 RVA: 0x0096D515 File Offset: 0x0096B715
		public TArray<UMaterialInstanceDynamic> MDIMats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._MDIMats) == null)
				{
					result = (this._MDIMats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.MDIMats.CopyAssign(value);
			}
		}

		// Token: 0x17004279 RID: 17017
		// (get) Token: 0x06022BBA RID: 142266 RVA: 0x0096D523 File Offset: 0x0096B723
		// (set) Token: 0x06022BBB RID: 142267 RVA: 0x0096D533 File Offset: 0x0096B733
		public unsafe float CollisionWolrd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700427A RID: 17018
		// (get) Token: 0x06022BBC RID: 142268 RVA: 0x0096D544 File Offset: 0x0096B744
		// (set) Token: 0x06022BBD RID: 142269 RVA: 0x0096D57D File Offset: 0x0096B77D
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700427B RID: 17019
		// (get) Token: 0x06022BBE RID: 142270 RVA: 0x0096D58C File Offset: 0x0096B78C
		// (set) Token: 0x06022BBF RID: 142271 RVA: 0x0096D5C5 File Offset: 0x0096B7C5
		public TMap<FName, UTexture> Texture_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700427C RID: 17020
		// (get) Token: 0x06022BC0 RID: 142272 RVA: 0x0096D5D4 File Offset: 0x0096B7D4
		// (set) Token: 0x06022BC1 RID: 142273 RVA: 0x0096D60D File Offset: 0x0096B80D
		public TMap<TSoftObjectPtr<UStaticMesh>, S_LiushuPreset> MeshPreset
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_LiushuPreset> result;
				if ((result = this._MeshPreset) == null)
				{
					result = (this._MeshPreset = new TMap<TSoftObjectPtr<UStaticMesh>, S_LiushuPreset>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.MeshPreset.CopyAssign(value);
			}
		}

		// Token: 0x1700427D RID: 17021
		// (get) Token: 0x06022BC2 RID: 142274 RVA: 0x0096D61C File Offset: 0x0096B81C
		// (set) Token: 0x06022BC3 RID: 142275 RVA: 0x0096D655 File Offset: 0x0096B855
		public TArray<UMaterialInterface> MatCache
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MatCache) == null)
				{
					result = (this._MatCache = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.MatCache.CopyAssign(value);
			}
		}

		// Token: 0x1700427E RID: 17022
		// (get) Token: 0x06022BC4 RID: 142276 RVA: 0x0096D663 File Offset: 0x0096B863
		// (set) Token: 0x06022BC5 RID: 142277 RVA: 0x0096D673 File Offset: 0x0096B873
		public unsafe float FadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700427F RID: 17023
		// (get) Token: 0x06022BC6 RID: 142278 RVA: 0x0096D684 File Offset: 0x0096B884
		// (set) Token: 0x06022BC7 RID: 142279 RVA: 0x0096D694 File Offset: 0x0096B894
		public unsafe float LastCustomDeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004280 RID: 17024
		// (get) Token: 0x06022BC8 RID: 142280 RVA: 0x0096D6A5 File Offset: 0x0096B8A5
		// (set) Token: 0x06022BC9 RID: 142281 RVA: 0x0096D6B5 File Offset: 0x0096B8B5
		public unsafe int NowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004281 RID: 17025
		// (get) Token: 0x06022BCA RID: 142282 RVA: 0x0096D6C6 File Offset: 0x0096B8C6
		// (set) Token: 0x06022BCB RID: 142283 RVA: 0x0096D6D6 File Offset: 0x0096B8D6
		public unsafe float WorldScaleX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004282 RID: 17026
		// (get) Token: 0x06022BCC RID: 142284 RVA: 0x0096D6E7 File Offset: 0x0096B8E7
		// (set) Token: 0x06022BCD RID: 142285 RVA: 0x0096D6F7 File Offset: 0x0096B8F7
		public unsafe bool bOnlyForHighQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004283 RID: 17027
		// (get) Token: 0x06022BCE RID: 142286 RVA: 0x0096D708 File Offset: 0x0096B908
		// (set) Token: 0x06022BCF RID: 142287 RVA: 0x0096D718 File Offset: 0x0096B918
		public unsafe bool bInMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Liushu_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022BD0 RID: 142288 RVA: 0x0096D729 File Offset: 0x0096B929
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CenterBound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__CenterBound_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD1 RID: 142289 RVA: 0x0096D73D File Offset: 0x0096B93D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FillParticles()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__FillParticles_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD2 RID: 142290 RVA: 0x0096D754 File Offset: 0x0096B954
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadPreset(ref bool NewParam)
		{
			BP_KuroCS_Liushu_C.__LoadPreset_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__LoadPreset_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__LoadPreset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__LoadPreset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__LoadPreset_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06022BD3 RID: 142291 RVA: 0x0096D7A6 File Offset: 0x0096B9A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ApplyMDI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ApplyMDI_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD4 RID: 142292 RVA: 0x0096D7BA File Offset: 0x0096B9BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RevertMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__RevertMat_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD5 RID: 142293 RVA: 0x0096D7CE File Offset: 0x0096B9CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD6 RID: 142294 RVA: 0x0096D7E2 File Offset: 0x0096B9E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD7 RID: 142295 RVA: 0x0096D7F6 File Offset: 0x0096B9F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD8 RID: 142296 RVA: 0x0096D80A File Offset: 0x0096BA0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022BD9 RID: 142297 RVA: 0x0096D81E File Offset: 0x0096BA1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022BDA RID: 142298 RVA: 0x0096D833 File Offset: 0x0096BA33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022BDB RID: 142299 RVA: 0x0096D847 File Offset: 0x0096BA47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022BDC RID: 142300 RVA: 0x0096D85C File Offset: 0x0096BA5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022BDD RID: 142301 RVA: 0x0096D8A4 File Offset: 0x0096BAA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022BDE RID: 142302 RVA: 0x0096D8EC File Offset: 0x0096BAEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022BDF RID: 142303 RVA: 0x0096D938 File Offset: 0x0096BB38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022BE0 RID: 142304 RVA: 0x0096D984 File Offset: 0x0096BB84
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022BE1 RID: 142305 RVA: 0x0096DA40 File Offset: 0x0096BC40
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022BE2 RID: 142306 RVA: 0x0096DAC9 File Offset: 0x0096BCC9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06022BE3 RID: 142307 RVA: 0x0096DADD File Offset: 0x0096BCDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x06022BE4 RID: 142308 RVA: 0x0096DAF1 File Offset: 0x0096BCF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022BE5 RID: 142309 RVA: 0x0096DB06 File Offset: 0x0096BD06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x06022BE6 RID: 142310 RVA: 0x0096DB1A File Offset: 0x0096BD1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022BE7 RID: 142311 RVA: 0x0096DB30 File Offset: 0x0096BD30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCS_Liushu(int EntryPoint)
		{
			BP_KuroCS_Liushu_C.__ExecuteUbergraph_BP_KuroCS_Liushu_FunctionParams* ptr = stackalloc BP_KuroCS_Liushu_C.__ExecuteUbergraph_BP_KuroCS_Liushu_FunctionParams[(UIntPtr)1775] + 15L / (long)sizeof(BP_KuroCS_Liushu_C.__ExecuteUbergraph_BP_KuroCS_Liushu_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Liushu_C.__ExecuteUbergraph_BP_KuroCS_Liushu_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Liushu_C.__ExecuteUbergraph_BP_KuroCS_Liushu_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022BE8 RID: 142312 RVA: 0x0096DB7A File Offset: 0x0096BD7A
		protected BP_KuroCS_Liushu_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040119B1 RID: 72113
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/BP_KuroCS_Liushu.BP_KuroCS_Liushu_C";

		// Token: 0x040119B2 RID: 72114
		private static IntPtr _ClassPtr;

		// Token: 0x040119B3 RID: 72115
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040119B4 RID: 72116
		internal static int __PropertyOffset_0;

		// Token: 0x040119B5 RID: 72117
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040119B6 RID: 72118
		internal static int __PropertyOffset_1;

		// Token: 0x040119B7 RID: 72119
		internal static int __PropertyOffset_2;

		// Token: 0x040119B8 RID: 72120
		internal static int __PropertyOffset_3;

		// Token: 0x040119B9 RID: 72121
		internal static int __PropertyOffset_4;

		// Token: 0x040119BA RID: 72122
		internal static int __PropertyOffset_5;

		// Token: 0x040119BB RID: 72123
		internal static int __PropertyOffset_6;

		// Token: 0x040119BC RID: 72124
		internal static int __PropertyOffset_7;

		// Token: 0x040119BD RID: 72125
		internal static int __PropertyOffset_8;

		// Token: 0x040119BE RID: 72126
		internal static int __PropertyOffset_9;

		// Token: 0x040119BF RID: 72127
		internal static int __PropertyOffset_10;

		// Token: 0x040119C0 RID: 72128
		internal static int __PropertyOffset_11;

		// Token: 0x040119C1 RID: 72129
		internal static int __PropertyOffset_12;

		// Token: 0x040119C2 RID: 72130
		[Nullable(2)]
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x040119C3 RID: 72131
		internal static int __PropertyOffset_13;

		// Token: 0x040119C4 RID: 72132
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _MDIMats;

		// Token: 0x040119C5 RID: 72133
		internal static int __PropertyOffset_14;

		// Token: 0x040119C6 RID: 72134
		internal static int __PropertyOffset_15;

		// Token: 0x040119C7 RID: 72135
		[Nullable(2)]
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x040119C8 RID: 72136
		internal static int __PropertyOffset_16;

		// Token: 0x040119C9 RID: 72137
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x040119CA RID: 72138
		internal static int __PropertyOffset_17;

		// Token: 0x040119CB RID: 72139
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_LiushuPreset> _MeshPreset;

		// Token: 0x040119CC RID: 72140
		internal static int __PropertyOffset_18;

		// Token: 0x040119CD RID: 72141
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MatCache;

		// Token: 0x040119CE RID: 72142
		internal static int __PropertyOffset_19;

		// Token: 0x040119CF RID: 72143
		internal static int __PropertyOffset_20;

		// Token: 0x040119D0 RID: 72144
		internal static int __PropertyOffset_21;

		// Token: 0x040119D1 RID: 72145
		internal static int __PropertyOffset_22;

		// Token: 0x040119D2 RID: 72146
		internal static int __PropertyOffset_23;

		// Token: 0x040119D3 RID: 72147
		internal static int __PropertyOffset_24;

		// Token: 0x040119D4 RID: 72148
		private static IntPtr __CenterBound_NativeFunctionPtr;

		// Token: 0x040119D5 RID: 72149
		private static IntPtr __FillParticles_NativeFunctionPtr;

		// Token: 0x040119D6 RID: 72150
		private static IntPtr __LoadPreset_NativeFunctionPtr;

		// Token: 0x040119D7 RID: 72151
		private static IntPtr __ApplyMDI_NativeFunctionPtr;

		// Token: 0x040119D8 RID: 72152
		private static IntPtr __RevertMat_NativeFunctionPtr;

		// Token: 0x040119D9 RID: 72153
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x040119DA RID: 72154
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x040119DB RID: 72155
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x040119DC RID: 72156
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040119DD RID: 72157
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040119DE RID: 72158
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040119DF RID: 72159
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040119E0 RID: 72160
		private static IntPtr __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040119E1 RID: 72161
		private static IntPtr __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040119E2 RID: 72162
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x040119E3 RID: 72163
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x040119E4 RID: 72164
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x040119E5 RID: 72165
		private static IntPtr __ExecuteUbergraph_BP_KuroCS_Liushu_NativeFunctionPtr;

		// Token: 0x02009C1B RID: 39963
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __LoadPreset_FunctionParams
		{
			// Token: 0x04032486 RID: 205958
			[FieldOffset(0)]
			public bool NewParam;
		}

		// Token: 0x02009C1C RID: 39964
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032487 RID: 205959
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C1D RID: 39965
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032488 RID: 205960
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C1E RID: 39966
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032489 RID: 205961
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403248A RID: 205962
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403248B RID: 205963
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403248C RID: 205964
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403248D RID: 205965
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403248E RID: 205966
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C1F RID: 39967
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403248F RID: 205967
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032490 RID: 205968
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032491 RID: 205969
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032492 RID: 205970
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C20 RID: 39968
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1760)]
		protected ref struct __ExecuteUbergraph_BP_KuroCS_Liushu_FunctionParams
		{
			// Token: 0x04032493 RID: 205971
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
