using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC2 RID: 15554
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds.BP_Clouds_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1486)]
	public class BP_Clouds_C : AKuroCloudsActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024E67 RID: 151143 RVA: 0x009AB78B File Offset: 0x009A998B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Clouds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds.BP_Clouds_C");
			}
			return BP_Clouds_C._ClassPtr;
		}

		// Token: 0x06024E68 RID: 151144 RVA: 0x009AB7B0 File Offset: 0x009A99B0
		public BP_Clouds_C() : this(BuiltinUtils.AllocNativeUObject(BP_Clouds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024E69 RID: 151145 RVA: 0x009AB7D8 File Offset: 0x009A99D8
		[NullableContext(1)]
		public BP_Clouds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Clouds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004E9F RID: 20127
		// (get) Token: 0x06024E6A RID: 151146 RVA: 0x009AB80C File Offset: 0x009A9A0C
		// (set) Token: 0x06024E6B RID: 151147 RVA: 0x009AB845 File Offset: 0x009A9A45
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EA0 RID: 20128
		// (get) Token: 0x06024E6C RID: 151148 RVA: 0x009AB866 File Offset: 0x009A9A66
		// (set) Token: 0x06024E6D RID: 151149 RVA: 0x009AB87A File Offset: 0x009A9A7A
		public unsafe UChildActorComponent Cloud02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EA1 RID: 20129
		// (get) Token: 0x06024E6E RID: 151150 RVA: 0x009AB88F File Offset: 0x009A9A8F
		// (set) Token: 0x06024E6F RID: 151151 RVA: 0x009AB8A3 File Offset: 0x009A9AA3
		public unsafe UChildActorComponent Cloud01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004EA2 RID: 20130
		// (get) Token: 0x06024E70 RID: 151152 RVA: 0x009AB8B8 File Offset: 0x009A9AB8
		// (set) Token: 0x06024E71 RID: 151153 RVA: 0x009AB8CC File Offset: 0x009A9ACC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004EA3 RID: 20131
		// (get) Token: 0x06024E72 RID: 151154 RVA: 0x009AB8E1 File Offset: 0x009A9AE1
		// (set) Token: 0x06024E73 RID: 151155 RVA: 0x009AB8F5 File Offset: 0x009A9AF5
		[Nullable(0)]
		public unsafe TEnumAsByte<E_Cloud_Presents> 当前云预设_不要改_
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004EA4 RID: 20132
		// (get) Token: 0x06024E74 RID: 151156 RVA: 0x009AB90A File Offset: 0x009A9B0A
		// (set) Token: 0x06024E75 RID: 151157 RVA: 0x009AB91E File Offset: 0x009A9B1E
		public unsafe PD_CloudPreset_C CloudData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPreset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004EA5 RID: 20133
		// (get) Token: 0x06024E76 RID: 151158 RVA: 0x009AB933 File Offset: 0x009A9B33
		// (set) Token: 0x06024E77 RID: 151159 RVA: 0x009AB943 File Offset: 0x009A9B43
		public unsafe bool Counting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EA6 RID: 20134
		// (get) Token: 0x06024E78 RID: 151160 RVA: 0x009AB954 File Offset: 0x009A9B54
		// (set) Token: 0x06024E79 RID: 151161 RVA: 0x009AB968 File Offset: 0x009A9B68
		[Nullable(0)]
		public unsafe TEnumAsByte<E_Cloud_Presents> 默认进入云预设
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004EA7 RID: 20135
		// (get) Token: 0x06024E7A RID: 151162 RVA: 0x009AB97D File Offset: 0x009A9B7D
		// (set) Token: 0x06024E7B RID: 151163 RVA: 0x009AB992 File Offset: 0x009A9B92
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAsset
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_8, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004EA8 RID: 20136
		// (get) Token: 0x06024E7C RID: 151164 RVA: 0x009AB9B8 File Offset: 0x009A9BB8
		// (set) Token: 0x06024E7D RID: 151165 RVA: 0x009AB9F1 File Offset: 0x009A9BF1
		[Nullable(1)]
		public TArray<int> SortNumber
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SortNumber) == null)
				{
					result = (this._SortNumber = new TArray<int>(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SortNumber.CopyAssign(value);
			}
		}

		// Token: 0x17004EA9 RID: 20137
		// (get) Token: 0x06024E7E RID: 151166 RVA: 0x009AB9FF File Offset: 0x009A9BFF
		// (set) Token: 0x06024E7F RID: 151167 RVA: 0x009ABA13 File Offset: 0x009A9C13
		public unsafe PD_CloudPrefab_C As_PD_Cloud_Prefab
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPrefab_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004EAA RID: 20138
		// (get) Token: 0x06024E80 RID: 151168 RVA: 0x009ABA28 File Offset: 0x009A9C28
		// (set) Token: 0x06024E81 RID: 151169 RVA: 0x009ABA3C File Offset: 0x009A9C3C
		public unsafe UAkAudioEvent CachedAudioEvent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004EAB RID: 20139
		// (get) Token: 0x06024E82 RID: 151170 RVA: 0x009ABA51 File Offset: 0x009A9C51
		// (set) Token: 0x06024E83 RID: 151171 RVA: 0x009ABA61 File Offset: 0x009A9C61
		public unsafe bool IsSkyOcean
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EAC RID: 20140
		// (get) Token: 0x06024E84 RID: 151172 RVA: 0x009ABA72 File Offset: 0x009A9C72
		// (set) Token: 0x06024E85 RID: 151173 RVA: 0x009ABA86 File Offset: 0x009A9C86
		public unsafe UAkAudioEvent SkyOceanAudio
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004EAD RID: 20141
		// (get) Token: 0x06024E86 RID: 151174 RVA: 0x009ABA9B File Offset: 0x009A9C9B
		// (set) Token: 0x06024E87 RID: 151175 RVA: 0x009ABAAB File Offset: 0x009A9CAB
		public unsafe bool Override_Cloud_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EAE RID: 20142
		// (get) Token: 0x06024E88 RID: 151176 RVA: 0x009ABABC File Offset: 0x009A9CBC
		// (set) Token: 0x06024E89 RID: 151177 RVA: 0x009ABACC File Offset: 0x009A9CCC
		public unsafe float Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004EAF RID: 20143
		// (get) Token: 0x06024E8A RID: 151178 RVA: 0x009ABADD File Offset: 0x009A9CDD
		// (set) Token: 0x06024E8B RID: 151179 RVA: 0x009ABAED File Offset: 0x009A9CED
		public unsafe float Cloud_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004EB0 RID: 20144
		// (get) Token: 0x06024E8C RID: 151180 RVA: 0x009ABAFE File Offset: 0x009A9CFE
		// (set) Token: 0x06024E8D RID: 151181 RVA: 0x009ABB0E File Offset: 0x009A9D0E
		public unsafe bool IsReversed_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EB1 RID: 20145
		// (get) Token: 0x06024E8E RID: 151182 RVA: 0x009ABB1F File Offset: 0x009A9D1F
		// (set) Token: 0x06024E8F RID: 151183 RVA: 0x009ABB2F File Offset: 0x009A9D2F
		public unsafe float ReversedZHeightBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004EB2 RID: 20146
		// (get) Token: 0x06024E90 RID: 151184 RVA: 0x009ABB40 File Offset: 0x009A9D40
		// (set) Token: 0x06024E91 RID: 151185 RVA: 0x009ABB50 File Offset: 0x009A9D50
		public unsafe KuroFeatureLevel FeatureLevel
		{
			get
			{
				return (KuroFeatureLevel)(*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_19));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_19) = (byte)value;
			}
		}

		// Token: 0x17004EB3 RID: 20147
		// (get) Token: 0x06024E92 RID: 151186 RVA: 0x009ABB61 File Offset: 0x009A9D61
		// (set) Token: 0x06024E93 RID: 151187 RVA: 0x009ABB71 File Offset: 0x009A9D71
		public unsafe bool IsHiddenClouds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x06024E94 RID: 151188 RVA: 0x009ABB82 File Offset: 0x009A9D82
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _40_天演幻心二阶段()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___40_天演幻心二阶段_NativeFunctionPtr, null);
		}

		// Token: 0x06024E95 RID: 151189 RVA: 0x009ABB96 File Offset: 0x009A9D96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _39_天演幻心()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___39_天演幻心_NativeFunctionPtr, null);
		}

		// Token: 0x06024E96 RID: 151190 RVA: 0x009ABBAA File Offset: 0x009A9DAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _38_金匣()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___38_金匣_NativeFunctionPtr, null);
		}

		// Token: 0x06024E97 RID: 151191 RVA: 0x009ABBBE File Offset: 0x009A9DBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _37_水匣()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___37_水匣_NativeFunctionPtr, null);
		}

		// Token: 0x06024E98 RID: 151192 RVA: 0x009ABBD2 File Offset: 0x009A9DD2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _36_火匣()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___36_火匣_NativeFunctionPtr, null);
		}

		// Token: 0x06024E99 RID: 151193 RVA: 0x009ABBE8 File Offset: 0x009A9DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SwitchCloudsSub(PD_CloudPrefab_C CloudPresents, float ChangeSpeed, bool InstantHide)
		{
			BP_Clouds_C.__SwitchCloudsSub_FunctionParams* ptr = stackalloc BP_Clouds_C.__SwitchCloudsSub_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_Clouds_C.__SwitchCloudsSub_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__SwitchCloudsSub_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = ((CloudPresents != null) ? CloudPresents.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__SwitchCloudsSub_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E9A RID: 151194 RVA: 0x009ABC4B File Offset: 0x009A9E4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _35_心湖()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___35_心湖_NativeFunctionPtr, null);
		}

		// Token: 0x06024E9B RID: 151195 RVA: 0x009ABC5F File Offset: 0x009A9E5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _34_天境()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___34_天境_NativeFunctionPtr, null);
		}

		// Token: 0x06024E9C RID: 151196 RVA: 0x009ABC73 File Offset: 0x009A9E73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _33_地境()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___33_地境_NativeFunctionPtr, null);
		}

		// Token: 0x06024E9D RID: 151197 RVA: 0x009ABC87 File Offset: 0x009A9E87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _32_人境()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___32_人境_NativeFunctionPtr, null);
		}

		// Token: 0x06024E9E RID: 151198 RVA: 0x009ABC9B File Offset: 0x009A9E9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _31_梦州特殊2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___31_梦州特殊2_NativeFunctionPtr, null);
		}

		// Token: 0x06024E9F RID: 151199 RVA: 0x009ABCAF File Offset: 0x009A9EAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _30_梦州特殊1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___30_梦州特殊1_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA0 RID: 151200 RVA: 0x009ABCC3 File Offset: 0x009A9EC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _29_宅邸解谜后()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___29_宅邸解谜后_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA1 RID: 151201 RVA: 0x009ABCD7 File Offset: 0x009A9ED7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _28_宅邸解谜前()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___28_宅邸解谜前_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA2 RID: 151202 RVA: 0x009ABCEB File Offset: 0x009A9EEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _27_梦州初见()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___27_梦州初见_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA3 RID: 151203 RVA: 0x009ABCFF File Offset: 0x009A9EFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _26_梦州阴天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___26_梦州阴天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA4 RID: 151204 RVA: 0x009ABD13 File Offset: 0x009A9F13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _25_梦州夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___25_梦州夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA5 RID: 151205 RVA: 0x009ABD27 File Offset: 0x009A9F27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _24_梦州白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___24_梦州白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA6 RID: 151206 RVA: 0x009ABD3B File Offset: 0x009A9F3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _23_高达Boss三阶()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___23_高达Boss三阶_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA7 RID: 151207 RVA: 0x009ABD4F File Offset: 0x009A9F4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _22_高达Boss一阶()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___22_高达Boss一阶_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA8 RID: 151208 RVA: 0x009ABD63 File Offset: 0x009A9F63
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _21_日灵棺解密后()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___21_日灵棺解密后_NativeFunctionPtr, null);
		}

		// Token: 0x06024EA9 RID: 151209 RVA: 0x009ABD77 File Offset: 0x009A9F77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _20_日灵棺解密前()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___20_日灵棺解密前_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAA RID: 151210 RVA: 0x009ABD8B File Offset: 0x009A9F8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _19_拉海洛初见()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___19_拉海洛初见_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAB RID: 151211 RVA: 0x009ABD9F File Offset: 0x009A9F9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _18_星海BOSS三阶()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___18_星海BOSS三阶_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAC RID: 151212 RVA: 0x009ABDB3 File Offset: 0x009A9FB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _17_星海BOSS一阶()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___17_星海BOSS一阶_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAD RID: 151213 RVA: 0x009ABDC7 File Offset: 0x009A9FC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _16_罗伊初见()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___16_罗伊初见_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAE RID: 151214 RVA: 0x009ABDDB File Offset: 0x009A9FDB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _15_罗伊极光()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___15_罗伊极光_NativeFunctionPtr, null);
		}

		// Token: 0x06024EAF RID: 151215 RVA: 0x009ABDEF File Offset: 0x009A9FEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _14_罗伊夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___14_罗伊夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB0 RID: 151216 RVA: 0x009ABE03 File Offset: 0x009AA003
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _13_罗伊白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___13_罗伊白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB1 RID: 151217 RVA: 0x009ABE17 File Offset: 0x009AA017
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _24_不渲染BP_Cloud控制的云()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___24_不渲染BP_Cloud控制的云_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB2 RID: 151218 RVA: 0x009ABE2B File Offset: 0x009AA02B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _12_梵高()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___12_梵高_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB3 RID: 151219 RVA: 0x009ABE3F File Offset: 0x009AA03F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _11_拉海洛阴天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___11_拉海洛阴天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB4 RID: 151220 RVA: 0x009ABE53 File Offset: 0x009AA053
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _10_浮光林夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___10_浮光林夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB5 RID: 151221 RVA: 0x009ABE67 File Offset: 0x009AA067
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _09_浮光林白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___09_浮光林白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB6 RID: 151222 RVA: 0x009ABE7B File Offset: 0x009AA07B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08_炉芯领主()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___08_炉芯领主_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB7 RID: 151223 RVA: 0x009ABE8F File Offset: 0x009AA08F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07_炉芯内部()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___07_炉芯内部_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB8 RID: 151224 RVA: 0x009ABEA3 File Offset: 0x009AA0A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06_坠落炉芯()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___06_坠落炉芯_NativeFunctionPtr, null);
		}

		// Token: 0x06024EB9 RID: 151225 RVA: 0x009ABEB7 File Offset: 0x009AA0B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05_星门Boss()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___05_星门Boss_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBA RID: 151226 RVA: 0x009ABECB File Offset: 0x009AA0CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04_磁暴后置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___04_磁暴后置_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBB RID: 151227 RVA: 0x009ABEDF File Offset: 0x009AA0DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03_磁暴前置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___03_磁暴前置_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBC RID: 151228 RVA: 0x009ABEF3 File Offset: 0x009AA0F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02_拉海洛夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___02_拉海洛夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBD RID: 151229 RVA: 0x009ABF07 File Offset: 0x009AA107
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01_拉海落白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___01_拉海落白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBE RID: 151230 RVA: 0x009ABF1B File Offset: 0x009AA11B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _23_安全点夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___23_安全点夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EBF RID: 151231 RVA: 0x009ABF2F File Offset: 0x009AA12F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _22_安全点白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___22_安全点白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC0 RID: 151232 RVA: 0x009ABF43 File Offset: 0x009AA143
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _23_穗波阴天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___23_穗波阴天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC1 RID: 151233 RVA: 0x009ABF57 File Offset: 0x009AA157
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _22_穗波枯山水()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___22_穗波枯山水_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC2 RID: 151234 RVA: 0x009ABF6B File Offset: 0x009AA16B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _21_穗波夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___21_穗波夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC3 RID: 151235 RVA: 0x009ABF7F File Offset: 0x009AA17F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _20_穗波白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___20_穗波白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC4 RID: 151236 RVA: 0x009ABF93 File Offset: 0x009AA193
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _21_总督日月同辉()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___21_总督日月同辉_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC5 RID: 151237 RVA: 0x009ABFA7 File Offset: 0x009AA1A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _21_烈阳天气()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___21_烈阳天气_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC6 RID: 151238 RVA: 0x009ABFBB File Offset: 0x009AA1BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _20_黑潮风暴加强()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___20_黑潮风暴加强_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC7 RID: 151239 RVA: 0x009ABFCF File Offset: 0x009AA1CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _19_黑潮风暴()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___19_黑潮风暴_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC8 RID: 151240 RVA: 0x009ABFE3 File Offset: 0x009AA1E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _18_失亡彼岸()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___18_失亡彼岸_NativeFunctionPtr, null);
		}

		// Token: 0x06024EC9 RID: 151241 RVA: 0x009ABFF7 File Offset: 0x009AA1F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _17_隐海试验场()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___17_隐海试验场_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECA RID: 151242 RVA: 0x009AC00B File Offset: 0x009AA20B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _16_巡游天国()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___16_巡游天国_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECB RID: 151243 RVA: 0x009AC01F File Offset: 0x009AA21F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _15_光路幻境()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___15_光路幻境_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECC RID: 151244 RVA: 0x009AC033 File Offset: 0x009AA233
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _14_黑潮内里世界()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___14_黑潮内里世界_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECD RID: 151245 RVA: 0x009AC047 File Offset: 0x009AA247
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _13_黑潮内表世界()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___13_黑潮内表世界_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECE RID: 151246 RVA: 0x009AC05B File Offset: 0x009AA25B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _12_黑潮侵蚀()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___12_黑潮侵蚀_NativeFunctionPtr, null);
		}

		// Token: 0x06024ECF RID: 151247 RVA: 0x009AC06F File Offset: 0x009AA26F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _19_狄斯台地月相()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___19_狄斯台地月相_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED0 RID: 151248 RVA: 0x009AC083 File Offset: 0x009AA283
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _18_狄斯台地受蚀地()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___18_狄斯台地受蚀地_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED1 RID: 151249 RVA: 0x009AC097 File Offset: 0x009AA297
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _17_狄斯台地烈日天空()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___17_狄斯台地烈日天空_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED2 RID: 151250 RVA: 0x009AC0AB File Offset: 0x009AA2AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _16_狄斯台地日月同辉()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___16_狄斯台地日月同辉_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED3 RID: 151251 RVA: 0x009AC0BF File Offset: 0x009AA2BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _15_狄斯台地夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___15_狄斯台地夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED4 RID: 151252 RVA: 0x009AC0D3 File Offset: 0x009AA2D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _14_狄斯台地白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___14_狄斯台地白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED5 RID: 151253 RVA: 0x009AC0E7 File Offset: 0x009AA2E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _13_七丘夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___13_七丘夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED6 RID: 151254 RVA: 0x009AC0FB File Offset: 0x009AA2FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _12_观测塔()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___12_观测塔_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED7 RID: 151255 RVA: 0x009AC10F File Offset: 0x009AA30F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _11_尖刺山()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___11_尖刺山_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED8 RID: 151256 RVA: 0x009AC123 File Offset: 0x009AA323
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _10_残破竞技场()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___10_残破竞技场_NativeFunctionPtr, null);
		}

		// Token: 0x06024ED9 RID: 151257 RVA: 0x009AC137 File Offset: 0x009AA337
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _09_七丘阴天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___09_七丘阴天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDA RID: 151258 RVA: 0x009AC14B File Offset: 0x009AA34B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08_初见七丘()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___08_初见七丘_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDB RID: 151259 RVA: 0x009AC15F File Offset: 0x009AA35F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07_七丘()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___07_七丘_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDC RID: 151260 RVA: 0x009AC173 File Offset: 0x009AA373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _11_颠倒塔流星()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___11_颠倒塔流星_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDD RID: 151261 RVA: 0x009AC187 File Offset: 0x009AA387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _10_颠倒塔夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___10_颠倒塔夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDE RID: 151262 RVA: 0x009AC19B File Offset: 0x009AA39B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _09_颠倒塔白天()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___09_颠倒塔白天_NativeFunctionPtr, null);
		}

		// Token: 0x06024EDF RID: 151263 RVA: 0x009AC1AF File Offset: 0x009AA3AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08_彩虹天气()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___08_彩虹天气_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE0 RID: 151264 RVA: 0x009AC1C3 File Offset: 0x009AA3C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloudMainParamsUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__CloudMainParamsUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE1 RID: 151265 RVA: 0x009AC1D7 File Offset: 0x009AA3D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07_费洛洛出场()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___07_费洛洛出场_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE2 RID: 151266 RVA: 0x009AC1EB File Offset: 0x009AA3EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06_金库上解密后()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___06_金库上解密后_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE3 RID: 151267 RVA: 0x009AC1FF File Offset: 0x009AA3FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05_罗墓岛夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___05_罗墓岛夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE4 RID: 151268 RVA: 0x009AC213 File Offset: 0x009AA413
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06_黎娜夕塔阴()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___06_黎娜夕塔阴_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE5 RID: 151269 RVA: 0x009AC227 File Offset: 0x009AA427
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04_云海区()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___04_云海区_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE6 RID: 151270 RVA: 0x009AC23B File Offset: 0x009AA43B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03_槲生半岛解密后()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___03_槲生半岛解密后_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE7 RID: 151271 RVA: 0x009AC24F File Offset: 0x009AA44F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05_狂欢节()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___05_狂欢节_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE8 RID: 151272 RVA: 0x009AC263 File Offset: 0x009AA463
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显示云移动范围()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__显示云移动范围_NativeFunctionPtr, null);
		}

		// Token: 0x06024EE9 RID: 151273 RVA: 0x009AC277 File Offset: 0x009AA477
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 关闭云跟随摄像机移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__关闭云跟随摄像机移动_NativeFunctionPtr, null);
		}

		// Token: 0x06024EEA RID: 151274 RVA: 0x009AC28B File Offset: 0x009AA48B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 开启云跟随摄像机移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__开启云跟随摄像机移动_NativeFunctionPtr, null);
		}

		// Token: 0x06024EEB RID: 151275 RVA: 0x009AC29F File Offset: 0x009AA49F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04_金库上层()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___04_金库上层_NativeFunctionPtr, null);
		}

		// Token: 0x06024EEC RID: 151276 RVA: 0x009AC2B3 File Offset: 0x009AA4B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03_狄萨莱海脊永夜解密后()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___03_狄萨莱海脊永夜解密后_NativeFunctionPtr, null);
		}

		// Token: 0x06024EED RID: 151277 RVA: 0x009AC2C7 File Offset: 0x009AA4C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02_狄萨莱海脊永夜解密前()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___02_狄萨莱海脊永夜解密前_NativeFunctionPtr, null);
		}

		// Token: 0x06024EEE RID: 151278 RVA: 0x009AC2DB File Offset: 0x009AA4DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01_槲生半岛()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___01_槲生半岛_NativeFunctionPtr, null);
		}

		// Token: 0x06024EEF RID: 151279 RVA: 0x009AC2EF File Offset: 0x009AA4EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02_帕尔米罗墓地()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___02_帕尔米罗墓地_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF0 RID: 151280 RVA: 0x009AC303 File Offset: 0x009AA503
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01_黎娜汐塔()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___01_黎娜汐塔_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF1 RID: 151281 RVA: 0x009AC317 File Offset: 0x009AA517
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _020黑海岸天气_阴()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___020黑海岸天气_阴_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF2 RID: 151282 RVA: 0x009AC32B File Offset: 0x009AA52B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _019肉鸽月亮05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___019肉鸽月亮05_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF3 RID: 151283 RVA: 0x009AC33F File Offset: 0x009AA53F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _018肉鸽月亮04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___018肉鸽月亮04_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF4 RID: 151284 RVA: 0x009AC353 File Offset: 0x009AA553
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _017肉鸽月亮03()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___017肉鸽月亮03_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF5 RID: 151285 RVA: 0x009AC367 File Offset: 0x009AA567
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _016肉鸽月亮02()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___016肉鸽月亮02_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF6 RID: 151286 RVA: 0x009AC37B File Offset: 0x009AA57B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _015肉鸽月亮01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___015肉鸽月亮01_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF7 RID: 151287 RVA: 0x009AC38F File Offset: 0x009AA58F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _014黑海岸夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___014黑海岸夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF8 RID: 151288 RVA: 0x009AC3A3 File Offset: 0x009AA5A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08黑海岸下层()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___08黑海岸下层_NativeFunctionPtr, null);
		}

		// Token: 0x06024EF9 RID: 151289 RVA: 0x009AC3B7 File Offset: 0x009AA5B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07黑海岸上层()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___07黑海岸上层_NativeFunctionPtr, null);
		}

		// Token: 0x06024EFA RID: 151290 RVA: 0x009AC3CC File Offset: 0x009AA5CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_GIParams(float CurTime)
		{
			BP_Clouds_C.__Get_GIParams_FunctionParams* ptr = stackalloc BP_Clouds_C.__Get_GIParams_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_C.__Get_GIParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__Get_GIParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurTime = CurTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__Get_GIParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024EFB RID: 151291 RVA: 0x009AC412 File Offset: 0x009AA612
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06乘宵山()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___06乘宵山_NativeFunctionPtr, null);
		}

		// Token: 0x06024EFC RID: 151292 RVA: 0x009AC426 File Offset: 0x009AA626
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05怨鸟泽()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___05怨鸟泽_NativeFunctionPtr, null);
		}

		// Token: 0x06024EFD RID: 151293 RVA: 0x009AC43A File Offset: 0x009AA63A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _013乘宵山异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___013乘宵山异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024EFE RID: 151294 RVA: 0x009AC44E File Offset: 0x009AA64E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _012夜晚异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___012夜晚异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024EFF RID: 151295 RVA: 0x009AC462 File Offset: 0x009AA662
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _011黄昏异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___011黄昏异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024F00 RID: 151296 RVA: 0x009AC476 File Offset: 0x009AA676
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _010阴天异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___010阴天异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024F01 RID: 151297 RVA: 0x009AC48A File Offset: 0x009AA68A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _09鸣潮天气()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___09鸣潮天气_NativeFunctionPtr, null);
		}

		// Token: 0x06024F02 RID: 151298 RVA: 0x009AC49E File Offset: 0x009AA69E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08漩涡云01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___08漩涡云01_NativeFunctionPtr, null);
		}

		// Token: 0x06024F03 RID: 151299 RVA: 0x009AC4B2 File Offset: 0x009AA6B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07无音区05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___07无音区05_NativeFunctionPtr, null);
		}

		// Token: 0x06024F04 RID: 151300 RVA: 0x009AC4C6 File Offset: 0x009AA6C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06无音区04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___06无音区04_NativeFunctionPtr, null);
		}

		// Token: 0x06024F05 RID: 151301 RVA: 0x009AC4DA File Offset: 0x009AA6DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05无音区03()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___05无音区03_NativeFunctionPtr, null);
		}

		// Token: 0x06024F06 RID: 151302 RVA: 0x009AC4EE File Offset: 0x009AA6EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04无音区02()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___04无音区02_NativeFunctionPtr, null);
		}

		// Token: 0x06024F07 RID: 151303 RVA: 0x009AC502 File Offset: 0x009AA702
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 原画测试用云()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__原画测试用云_NativeFunctionPtr, null);
		}

		// Token: 0x06024F08 RID: 151304 RVA: 0x009AC518 File Offset: 0x009AA718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCloudParameters(PD_CloudPrefab_C CloudPrefeb, UChildActorComponent CloudActorComponent, float ChangeSpeed, int TransSortNumber, bool bInstantHide)
		{
			BP_Clouds_C.__SetCloudParameters_FunctionParams* ptr = stackalloc BP_Clouds_C.__SetCloudParameters_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Clouds_C.__SetCloudParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPrefeb = ((CloudPrefeb != null) ? CloudPrefeb.NativePtr : IntPtr.Zero);
			ptr->CloudActorComponent = ((CloudActorComponent != null) ? CloudActorComponent.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->TransSortNumber = TransSortNumber;
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F09 RID: 151305 RVA: 0x009AC59A File Offset: 0x009AA79A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04中曲台地()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___04中曲台地_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0A RID: 151306 RVA: 0x009AC5AE File Offset: 0x009AA7AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Hidden_Old()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__Hidden_Old_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0B RID: 151307 RVA: 0x009AC5C2 File Offset: 0x009AA7C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03无音区01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___03无音区01_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0C RID: 151308 RVA: 0x009AC5D6 File Offset: 0x009AA7D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02无音区沉寂态()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___02无音区沉寂态_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0D RID: 151309 RVA: 0x009AC5EA File Offset: 0x009AA7EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01登录界面()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___01登录界面_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0E RID: 151310 RVA: 0x009AC5FE File Offset: 0x009AA7FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03无光之森()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___03无光之森_NativeFunctionPtr, null);
		}

		// Token: 0x06024F0F RID: 151311 RVA: 0x009AC612 File Offset: 0x009AA812
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02遗落原乡()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___02遗落原乡_NativeFunctionPtr, null);
		}

		// Token: 0x06024F10 RID: 151312 RVA: 0x009AC626 File Offset: 0x009AA826
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01天城()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.___01天城_NativeFunctionPtr, null);
		}

		// Token: 0x06024F11 RID: 151313 RVA: 0x009AC63A File Offset: 0x009AA83A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024F12 RID: 151314 RVA: 0x009AC64E File Offset: 0x009AA84E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F13 RID: 151315 RVA: 0x009AC664 File Offset: 0x009AA864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A(UObject Loaded)
		{
			BP_Clouds_C.__OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_FunctionParams* ptr = stackalloc BP_Clouds_C.__OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Clouds_C.__OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F14 RID: 151316 RVA: 0x009AC6B9 File Offset: 0x009AA8B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024F15 RID: 151317 RVA: 0x009AC6CD File Offset: 0x009AA8CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F16 RID: 151318 RVA: 0x009AC6E4 File Offset: 0x009AA8E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Clouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Clouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F17 RID: 151319 RVA: 0x009AC72C File Offset: 0x009AA92C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Clouds_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Clouds_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F18 RID: 151320 RVA: 0x009AC774 File Offset: 0x009AA974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Clouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Clouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F19 RID: 151321 RVA: 0x009AC7BC File Offset: 0x009AA9BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Clouds_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Clouds_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F1A RID: 151322 RVA: 0x009AC803 File Offset: 0x009AAA03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ChangeCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__ChangeCloud_NativeFunctionPtr, null);
		}

		// Token: 0x06024F1B RID: 151323 RVA: 0x009AC818 File Offset: 0x009AAA18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Switch_Clouds(E_Cloud_Presents CloudPresents, float ChangeSpeed, bool IsInEditor, bool bOverrideCloudRotation, float CloudSpeed, float CloudOffset, bool ControlSeqCloud, bool InstantHide)
		{
			BP_Clouds_C.__Switch_Clouds_FunctionParams* ptr = stackalloc BP_Clouds_C.__Switch_Clouds_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Clouds_C.__Switch_Clouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = CloudPresents;
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			ptr->bOverrideCloudRotation = bOverrideCloudRotation;
			ptr->CloudSpeed = CloudSpeed;
			ptr->CloudOffset = CloudOffset;
			ptr->ControlSeqCloud = ControlSeqCloud;
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F1C RID: 151324 RVA: 0x009AC89C File Offset: 0x009AAA9C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadAndSwitch(TSoftObjectPtr<UObject> Asset, float ChangeSpeed, bool IsInEditor, bool IsAudio, bool InstantHide)
		{
			BP_Clouds_C.__LoadAndSwitch_FunctionParams* ptr = stackalloc BP_Clouds_C.__LoadAndSwitch_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Clouds_C.__LoadAndSwitch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
			if (Asset != null)
			{
				FSoftObjectPtr.NativeCopy(&ptr->Asset, Asset.NativePtr, 1);
			}
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			ptr->IsAudio = IsAudio;
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_Clouds_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024F1D RID: 151325 RVA: 0x009AC928 File Offset: 0x009AAB28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Clouds(int EntryPoint)
		{
			BP_Clouds_C.__ExecuteUbergraph_BP_Clouds_FunctionParams* ptr = stackalloc BP_Clouds_C.__ExecuteUbergraph_BP_Clouds_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_Clouds_C.__ExecuteUbergraph_BP_Clouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_C.__ExecuteUbergraph_BP_Clouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_C.__ExecuteUbergraph_BP_Clouds_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F1E RID: 151326 RVA: 0x009AC972 File Offset: 0x009AAB72
		protected BP_Clouds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012F09 RID: 77577
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds.BP_Clouds_C";

		// Token: 0x04012F0A RID: 77578
		private static IntPtr _ClassPtr;

		// Token: 0x04012F0B RID: 77579
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012F0C RID: 77580
		internal static int __PropertyOffset_0;

		// Token: 0x04012F0D RID: 77581
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012F0E RID: 77582
		internal static int __PropertyOffset_1;

		// Token: 0x04012F0F RID: 77583
		internal static int __PropertyOffset_2;

		// Token: 0x04012F10 RID: 77584
		internal static int __PropertyOffset_3;

		// Token: 0x04012F11 RID: 77585
		internal static int __PropertyOffset_4;

		// Token: 0x04012F12 RID: 77586
		internal static int __PropertyOffset_5;

		// Token: 0x04012F13 RID: 77587
		internal static int __PropertyOffset_6;

		// Token: 0x04012F14 RID: 77588
		internal static int __PropertyOffset_7;

		// Token: 0x04012F15 RID: 77589
		internal static int __PropertyOffset_8;

		// Token: 0x04012F16 RID: 77590
		internal static int __PropertyOffset_9;

		// Token: 0x04012F17 RID: 77591
		private TArray<int> _SortNumber;

		// Token: 0x04012F18 RID: 77592
		internal static int __PropertyOffset_10;

		// Token: 0x04012F19 RID: 77593
		internal static int __PropertyOffset_11;

		// Token: 0x04012F1A RID: 77594
		internal static int __PropertyOffset_12;

		// Token: 0x04012F1B RID: 77595
		internal static int __PropertyOffset_13;

		// Token: 0x04012F1C RID: 77596
		internal static int __PropertyOffset_14;

		// Token: 0x04012F1D RID: 77597
		internal static int __PropertyOffset_15;

		// Token: 0x04012F1E RID: 77598
		internal static int __PropertyOffset_16;

		// Token: 0x04012F1F RID: 77599
		internal static int __PropertyOffset_17;

		// Token: 0x04012F20 RID: 77600
		internal static int __PropertyOffset_18;

		// Token: 0x04012F21 RID: 77601
		internal static int __PropertyOffset_19;

		// Token: 0x04012F22 RID: 77602
		internal static int __PropertyOffset_20;

		// Token: 0x04012F23 RID: 77603
		private static IntPtr ___40_天演幻心二阶段_NativeFunctionPtr;

		// Token: 0x04012F24 RID: 77604
		private static IntPtr ___39_天演幻心_NativeFunctionPtr;

		// Token: 0x04012F25 RID: 77605
		private static IntPtr ___38_金匣_NativeFunctionPtr;

		// Token: 0x04012F26 RID: 77606
		private static IntPtr ___37_水匣_NativeFunctionPtr;

		// Token: 0x04012F27 RID: 77607
		private static IntPtr ___36_火匣_NativeFunctionPtr;

		// Token: 0x04012F28 RID: 77608
		private static IntPtr __SwitchCloudsSub_NativeFunctionPtr;

		// Token: 0x04012F29 RID: 77609
		private static IntPtr ___35_心湖_NativeFunctionPtr;

		// Token: 0x04012F2A RID: 77610
		private static IntPtr ___34_天境_NativeFunctionPtr;

		// Token: 0x04012F2B RID: 77611
		private static IntPtr ___33_地境_NativeFunctionPtr;

		// Token: 0x04012F2C RID: 77612
		private static IntPtr ___32_人境_NativeFunctionPtr;

		// Token: 0x04012F2D RID: 77613
		private static IntPtr ___31_梦州特殊2_NativeFunctionPtr;

		// Token: 0x04012F2E RID: 77614
		private static IntPtr ___30_梦州特殊1_NativeFunctionPtr;

		// Token: 0x04012F2F RID: 77615
		private static IntPtr ___29_宅邸解谜后_NativeFunctionPtr;

		// Token: 0x04012F30 RID: 77616
		private static IntPtr ___28_宅邸解谜前_NativeFunctionPtr;

		// Token: 0x04012F31 RID: 77617
		private static IntPtr ___27_梦州初见_NativeFunctionPtr;

		// Token: 0x04012F32 RID: 77618
		private static IntPtr ___26_梦州阴天_NativeFunctionPtr;

		// Token: 0x04012F33 RID: 77619
		private static IntPtr ___25_梦州夜晚_NativeFunctionPtr;

		// Token: 0x04012F34 RID: 77620
		private static IntPtr ___24_梦州白天_NativeFunctionPtr;

		// Token: 0x04012F35 RID: 77621
		private static IntPtr ___23_高达Boss三阶_NativeFunctionPtr;

		// Token: 0x04012F36 RID: 77622
		private static IntPtr ___22_高达Boss一阶_NativeFunctionPtr;

		// Token: 0x04012F37 RID: 77623
		private static IntPtr ___21_日灵棺解密后_NativeFunctionPtr;

		// Token: 0x04012F38 RID: 77624
		private static IntPtr ___20_日灵棺解密前_NativeFunctionPtr;

		// Token: 0x04012F39 RID: 77625
		private static IntPtr ___19_拉海洛初见_NativeFunctionPtr;

		// Token: 0x04012F3A RID: 77626
		private static IntPtr ___18_星海BOSS三阶_NativeFunctionPtr;

		// Token: 0x04012F3B RID: 77627
		private static IntPtr ___17_星海BOSS一阶_NativeFunctionPtr;

		// Token: 0x04012F3C RID: 77628
		private static IntPtr ___16_罗伊初见_NativeFunctionPtr;

		// Token: 0x04012F3D RID: 77629
		private static IntPtr ___15_罗伊极光_NativeFunctionPtr;

		// Token: 0x04012F3E RID: 77630
		private static IntPtr ___14_罗伊夜晚_NativeFunctionPtr;

		// Token: 0x04012F3F RID: 77631
		private static IntPtr ___13_罗伊白天_NativeFunctionPtr;

		// Token: 0x04012F40 RID: 77632
		private static IntPtr ___24_不渲染BP_Cloud控制的云_NativeFunctionPtr;

		// Token: 0x04012F41 RID: 77633
		private static IntPtr ___12_梵高_NativeFunctionPtr;

		// Token: 0x04012F42 RID: 77634
		private static IntPtr ___11_拉海洛阴天_NativeFunctionPtr;

		// Token: 0x04012F43 RID: 77635
		private static IntPtr ___10_浮光林夜晚_NativeFunctionPtr;

		// Token: 0x04012F44 RID: 77636
		private static IntPtr ___09_浮光林白天_NativeFunctionPtr;

		// Token: 0x04012F45 RID: 77637
		private static IntPtr ___08_炉芯领主_NativeFunctionPtr;

		// Token: 0x04012F46 RID: 77638
		private static IntPtr ___07_炉芯内部_NativeFunctionPtr;

		// Token: 0x04012F47 RID: 77639
		private static IntPtr ___06_坠落炉芯_NativeFunctionPtr;

		// Token: 0x04012F48 RID: 77640
		private static IntPtr ___05_星门Boss_NativeFunctionPtr;

		// Token: 0x04012F49 RID: 77641
		private static IntPtr ___04_磁暴后置_NativeFunctionPtr;

		// Token: 0x04012F4A RID: 77642
		private static IntPtr ___03_磁暴前置_NativeFunctionPtr;

		// Token: 0x04012F4B RID: 77643
		private static IntPtr ___02_拉海洛夜晚_NativeFunctionPtr;

		// Token: 0x04012F4C RID: 77644
		private static IntPtr ___01_拉海落白天_NativeFunctionPtr;

		// Token: 0x04012F4D RID: 77645
		private static IntPtr ___23_安全点夜晚_NativeFunctionPtr;

		// Token: 0x04012F4E RID: 77646
		private static IntPtr ___22_安全点白天_NativeFunctionPtr;

		// Token: 0x04012F4F RID: 77647
		private static IntPtr ___23_穗波阴天_NativeFunctionPtr;

		// Token: 0x04012F50 RID: 77648
		private static IntPtr ___22_穗波枯山水_NativeFunctionPtr;

		// Token: 0x04012F51 RID: 77649
		private static IntPtr ___21_穗波夜晚_NativeFunctionPtr;

		// Token: 0x04012F52 RID: 77650
		private static IntPtr ___20_穗波白天_NativeFunctionPtr;

		// Token: 0x04012F53 RID: 77651
		private static IntPtr ___21_总督日月同辉_NativeFunctionPtr;

		// Token: 0x04012F54 RID: 77652
		private static IntPtr ___21_烈阳天气_NativeFunctionPtr;

		// Token: 0x04012F55 RID: 77653
		private static IntPtr ___20_黑潮风暴加强_NativeFunctionPtr;

		// Token: 0x04012F56 RID: 77654
		private static IntPtr ___19_黑潮风暴_NativeFunctionPtr;

		// Token: 0x04012F57 RID: 77655
		private static IntPtr ___18_失亡彼岸_NativeFunctionPtr;

		// Token: 0x04012F58 RID: 77656
		private static IntPtr ___17_隐海试验场_NativeFunctionPtr;

		// Token: 0x04012F59 RID: 77657
		private static IntPtr ___16_巡游天国_NativeFunctionPtr;

		// Token: 0x04012F5A RID: 77658
		private static IntPtr ___15_光路幻境_NativeFunctionPtr;

		// Token: 0x04012F5B RID: 77659
		private static IntPtr ___14_黑潮内里世界_NativeFunctionPtr;

		// Token: 0x04012F5C RID: 77660
		private static IntPtr ___13_黑潮内表世界_NativeFunctionPtr;

		// Token: 0x04012F5D RID: 77661
		private static IntPtr ___12_黑潮侵蚀_NativeFunctionPtr;

		// Token: 0x04012F5E RID: 77662
		private static IntPtr ___19_狄斯台地月相_NativeFunctionPtr;

		// Token: 0x04012F5F RID: 77663
		private static IntPtr ___18_狄斯台地受蚀地_NativeFunctionPtr;

		// Token: 0x04012F60 RID: 77664
		private static IntPtr ___17_狄斯台地烈日天空_NativeFunctionPtr;

		// Token: 0x04012F61 RID: 77665
		private static IntPtr ___16_狄斯台地日月同辉_NativeFunctionPtr;

		// Token: 0x04012F62 RID: 77666
		private static IntPtr ___15_狄斯台地夜晚_NativeFunctionPtr;

		// Token: 0x04012F63 RID: 77667
		private static IntPtr ___14_狄斯台地白天_NativeFunctionPtr;

		// Token: 0x04012F64 RID: 77668
		private static IntPtr ___13_七丘夜晚_NativeFunctionPtr;

		// Token: 0x04012F65 RID: 77669
		private static IntPtr ___12_观测塔_NativeFunctionPtr;

		// Token: 0x04012F66 RID: 77670
		private static IntPtr ___11_尖刺山_NativeFunctionPtr;

		// Token: 0x04012F67 RID: 77671
		private static IntPtr ___10_残破竞技场_NativeFunctionPtr;

		// Token: 0x04012F68 RID: 77672
		private static IntPtr ___09_七丘阴天_NativeFunctionPtr;

		// Token: 0x04012F69 RID: 77673
		private static IntPtr ___08_初见七丘_NativeFunctionPtr;

		// Token: 0x04012F6A RID: 77674
		private static IntPtr ___07_七丘_NativeFunctionPtr;

		// Token: 0x04012F6B RID: 77675
		private static IntPtr ___11_颠倒塔流星_NativeFunctionPtr;

		// Token: 0x04012F6C RID: 77676
		private static IntPtr ___10_颠倒塔夜晚_NativeFunctionPtr;

		// Token: 0x04012F6D RID: 77677
		private static IntPtr ___09_颠倒塔白天_NativeFunctionPtr;

		// Token: 0x04012F6E RID: 77678
		private static IntPtr ___08_彩虹天气_NativeFunctionPtr;

		// Token: 0x04012F6F RID: 77679
		private static IntPtr __CloudMainParamsUpdate_NativeFunctionPtr;

		// Token: 0x04012F70 RID: 77680
		private static IntPtr ___07_费洛洛出场_NativeFunctionPtr;

		// Token: 0x04012F71 RID: 77681
		private static IntPtr ___06_金库上解密后_NativeFunctionPtr;

		// Token: 0x04012F72 RID: 77682
		private static IntPtr ___05_罗墓岛夜晚_NativeFunctionPtr;

		// Token: 0x04012F73 RID: 77683
		private static IntPtr ___06_黎娜夕塔阴_NativeFunctionPtr;

		// Token: 0x04012F74 RID: 77684
		private static IntPtr ___04_云海区_NativeFunctionPtr;

		// Token: 0x04012F75 RID: 77685
		private static IntPtr ___03_槲生半岛解密后_NativeFunctionPtr;

		// Token: 0x04012F76 RID: 77686
		private static IntPtr ___05_狂欢节_NativeFunctionPtr;

		// Token: 0x04012F77 RID: 77687
		private static IntPtr __显示云移动范围_NativeFunctionPtr;

		// Token: 0x04012F78 RID: 77688
		private static IntPtr __关闭云跟随摄像机移动_NativeFunctionPtr;

		// Token: 0x04012F79 RID: 77689
		private static IntPtr __开启云跟随摄像机移动_NativeFunctionPtr;

		// Token: 0x04012F7A RID: 77690
		private static IntPtr ___04_金库上层_NativeFunctionPtr;

		// Token: 0x04012F7B RID: 77691
		private static IntPtr ___03_狄萨莱海脊永夜解密后_NativeFunctionPtr;

		// Token: 0x04012F7C RID: 77692
		private static IntPtr ___02_狄萨莱海脊永夜解密前_NativeFunctionPtr;

		// Token: 0x04012F7D RID: 77693
		private static IntPtr ___01_槲生半岛_NativeFunctionPtr;

		// Token: 0x04012F7E RID: 77694
		private static IntPtr ___02_帕尔米罗墓地_NativeFunctionPtr;

		// Token: 0x04012F7F RID: 77695
		private static IntPtr ___01_黎娜汐塔_NativeFunctionPtr;

		// Token: 0x04012F80 RID: 77696
		private static IntPtr ___020黑海岸天气_阴_NativeFunctionPtr;

		// Token: 0x04012F81 RID: 77697
		private static IntPtr ___019肉鸽月亮05_NativeFunctionPtr;

		// Token: 0x04012F82 RID: 77698
		private static IntPtr ___018肉鸽月亮04_NativeFunctionPtr;

		// Token: 0x04012F83 RID: 77699
		private static IntPtr ___017肉鸽月亮03_NativeFunctionPtr;

		// Token: 0x04012F84 RID: 77700
		private static IntPtr ___016肉鸽月亮02_NativeFunctionPtr;

		// Token: 0x04012F85 RID: 77701
		private static IntPtr ___015肉鸽月亮01_NativeFunctionPtr;

		// Token: 0x04012F86 RID: 77702
		private static IntPtr ___014黑海岸夜晚_NativeFunctionPtr;

		// Token: 0x04012F87 RID: 77703
		private static IntPtr ___08黑海岸下层_NativeFunctionPtr;

		// Token: 0x04012F88 RID: 77704
		private static IntPtr ___07黑海岸上层_NativeFunctionPtr;

		// Token: 0x04012F89 RID: 77705
		private static IntPtr __Get_GIParams_NativeFunctionPtr;

		// Token: 0x04012F8A RID: 77706
		private static IntPtr ___06乘宵山_NativeFunctionPtr;

		// Token: 0x04012F8B RID: 77707
		private static IntPtr ___05怨鸟泽_NativeFunctionPtr;

		// Token: 0x04012F8C RID: 77708
		private static IntPtr ___013乘宵山异象_NativeFunctionPtr;

		// Token: 0x04012F8D RID: 77709
		private static IntPtr ___012夜晚异象_NativeFunctionPtr;

		// Token: 0x04012F8E RID: 77710
		private static IntPtr ___011黄昏异象_NativeFunctionPtr;

		// Token: 0x04012F8F RID: 77711
		private static IntPtr ___010阴天异象_NativeFunctionPtr;

		// Token: 0x04012F90 RID: 77712
		private static IntPtr ___09鸣潮天气_NativeFunctionPtr;

		// Token: 0x04012F91 RID: 77713
		private static IntPtr ___08漩涡云01_NativeFunctionPtr;

		// Token: 0x04012F92 RID: 77714
		private static IntPtr ___07无音区05_NativeFunctionPtr;

		// Token: 0x04012F93 RID: 77715
		private static IntPtr ___06无音区04_NativeFunctionPtr;

		// Token: 0x04012F94 RID: 77716
		private static IntPtr ___05无音区03_NativeFunctionPtr;

		// Token: 0x04012F95 RID: 77717
		private static IntPtr ___04无音区02_NativeFunctionPtr;

		// Token: 0x04012F96 RID: 77718
		private static IntPtr __原画测试用云_NativeFunctionPtr;

		// Token: 0x04012F97 RID: 77719
		private static IntPtr __SetCloudParameters_NativeFunctionPtr;

		// Token: 0x04012F98 RID: 77720
		private static IntPtr ___04中曲台地_NativeFunctionPtr;

		// Token: 0x04012F99 RID: 77721
		private static IntPtr __Hidden_Old_NativeFunctionPtr;

		// Token: 0x04012F9A RID: 77722
		private static IntPtr ___03无音区01_NativeFunctionPtr;

		// Token: 0x04012F9B RID: 77723
		private static IntPtr ___02无音区沉寂态_NativeFunctionPtr;

		// Token: 0x04012F9C RID: 77724
		private static IntPtr ___01登录界面_NativeFunctionPtr;

		// Token: 0x04012F9D RID: 77725
		private static IntPtr ___03无光之森_NativeFunctionPtr;

		// Token: 0x04012F9E RID: 77726
		private static IntPtr ___02遗落原乡_NativeFunctionPtr;

		// Token: 0x04012F9F RID: 77727
		private static IntPtr ___01天城_NativeFunctionPtr;

		// Token: 0x04012FA0 RID: 77728
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012FA1 RID: 77729
		private static IntPtr __OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_NativeFunctionPtr;

		// Token: 0x04012FA2 RID: 77730
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012FA3 RID: 77731
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012FA4 RID: 77732
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012FA5 RID: 77733
		private static IntPtr __ChangeCloud_NativeFunctionPtr;

		// Token: 0x04012FA6 RID: 77734
		private static IntPtr __Switch_Clouds_NativeFunctionPtr;

		// Token: 0x04012FA7 RID: 77735
		private static IntPtr __LoadAndSwitch_NativeFunctionPtr;

		// Token: 0x04012FA8 RID: 77736
		private static IntPtr __ExecuteUbergraph_BP_Clouds_NativeFunctionPtr;

		// Token: 0x02009E97 RID: 40599
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __SwitchCloudsSub_FunctionParams
		{
			// Token: 0x0403293E RID: 207166
			[FieldOffset(0)]
			public IntPtr CloudPresents;

			// Token: 0x0403293F RID: 207167
			[FieldOffset(8)]
			public float ChangeSpeed;

			// Token: 0x04032940 RID: 207168
			[FieldOffset(12)]
			public bool InstantHide;
		}

		// Token: 0x02009E98 RID: 40600
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Get_GIParams_FunctionParams
		{
			// Token: 0x04032941 RID: 207169
			[FieldOffset(0)]
			public float CurTime;
		}

		// Token: 0x02009E99 RID: 40601
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetCloudParameters_FunctionParams
		{
			// Token: 0x04032942 RID: 207170
			[FieldOffset(0)]
			public IntPtr CloudPrefeb;

			// Token: 0x04032943 RID: 207171
			[FieldOffset(8)]
			public IntPtr CloudActorComponent;

			// Token: 0x04032944 RID: 207172
			[FieldOffset(16)]
			public float ChangeSpeed;

			// Token: 0x04032945 RID: 207173
			[FieldOffset(20)]
			public int TransSortNumber;

			// Token: 0x04032946 RID: 207174
			[FieldOffset(24)]
			public bool bInstantHide;
		}

		// Token: 0x02009E9A RID: 40602
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_63FE5E2B437AFAD504FBCAB26242EB8A_FunctionParams
		{
			// Token: 0x04032947 RID: 207175
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009E9B RID: 40603
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032948 RID: 207176
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E9C RID: 40604
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032949 RID: 207177
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E9D RID: 40605
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Switch_Clouds_FunctionParams
		{
			// Token: 0x0403294A RID: 207178
			[FieldOffset(0)]
			public TEnumAsByte<E_Cloud_Presents> CloudPresents;

			// Token: 0x0403294B RID: 207179
			[FieldOffset(4)]
			public float ChangeSpeed;

			// Token: 0x0403294C RID: 207180
			[FieldOffset(8)]
			public bool IsInEditor;

			// Token: 0x0403294D RID: 207181
			[FieldOffset(9)]
			public bool bOverrideCloudRotation;

			// Token: 0x0403294E RID: 207182
			[FieldOffset(12)]
			public float CloudSpeed;

			// Token: 0x0403294F RID: 207183
			[FieldOffset(16)]
			public float CloudOffset;

			// Token: 0x04032950 RID: 207184
			[FieldOffset(20)]
			public bool ControlSeqCloud;

			// Token: 0x04032951 RID: 207185
			[FieldOffset(21)]
			public bool InstantHide;
		}

		// Token: 0x02009E9E RID: 40606
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __LoadAndSwitch_FunctionParams
		{
			// Token: 0x04032952 RID: 207186
			[FieldOffset(0)]
			public byte Asset;

			// Token: 0x04032953 RID: 207187
			[FieldOffset(48)]
			public float ChangeSpeed;

			// Token: 0x04032954 RID: 207188
			[FieldOffset(52)]
			public bool IsInEditor;

			// Token: 0x04032955 RID: 207189
			[FieldOffset(53)]
			public bool IsAudio;

			// Token: 0x04032956 RID: 207190
			[FieldOffset(54)]
			public bool InstantHide;
		}

		// Token: 0x02009E9F RID: 40607
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_Clouds_FunctionParams
		{
			// Token: 0x04032957 RID: 207191
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
