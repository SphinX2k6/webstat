using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC3 RID: 15555
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds_UI.BP_Clouds_UI_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1432)]
	public class BP_Clouds_UI_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024F1F RID: 151327 RVA: 0x009AC97B File Offset: 0x009AAB7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Clouds_UI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds_UI.BP_Clouds_UI_C");
			}
			return BP_Clouds_UI_C._ClassPtr;
		}

		// Token: 0x06024F20 RID: 151328 RVA: 0x009AC9A0 File Offset: 0x009AABA0
		public BP_Clouds_UI_C() : this(BuiltinUtils.AllocNativeUObject(BP_Clouds_UI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024F21 RID: 151329 RVA: 0x009AC9C8 File Offset: 0x009AABC8
		[NullableContext(1)]
		public BP_Clouds_UI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Clouds_UI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004EB4 RID: 20148
		// (get) Token: 0x06024F22 RID: 151330 RVA: 0x009AC9FC File Offset: 0x009AABFC
		// (set) Token: 0x06024F23 RID: 151331 RVA: 0x009ACA35 File Offset: 0x009AAC35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EB5 RID: 20149
		// (get) Token: 0x06024F24 RID: 151332 RVA: 0x009ACA56 File Offset: 0x009AAC56
		// (set) Token: 0x06024F25 RID: 151333 RVA: 0x009ACA6A File Offset: 0x009AAC6A
		[Nullable(2)]
		public unsafe UChildActorComponent Cloud02
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EB6 RID: 20150
		// (get) Token: 0x06024F26 RID: 151334 RVA: 0x009ACA7F File Offset: 0x009AAC7F
		// (set) Token: 0x06024F27 RID: 151335 RVA: 0x009ACA93 File Offset: 0x009AAC93
		[Nullable(2)]
		public unsafe UChildActorComponent Cloud01
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004EB7 RID: 20151
		// (get) Token: 0x06024F28 RID: 151336 RVA: 0x009ACAA8 File Offset: 0x009AACA8
		// (set) Token: 0x06024F29 RID: 151337 RVA: 0x009ACABC File Offset: 0x009AACBC
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004EB8 RID: 20152
		// (get) Token: 0x06024F2A RID: 151338 RVA: 0x009ACAD1 File Offset: 0x009AACD1
		// (set) Token: 0x06024F2B RID: 151339 RVA: 0x009ACAE5 File Offset: 0x009AACE5
		public unsafe TEnumAsByte<E_Cloud_Presents> 当前云预设_不要改_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004EB9 RID: 20153
		// (get) Token: 0x06024F2C RID: 151340 RVA: 0x009ACAFA File Offset: 0x009AACFA
		// (set) Token: 0x06024F2D RID: 151341 RVA: 0x009ACB0E File Offset: 0x009AAD0E
		[Nullable(2)]
		public unsafe PD_CloudPreset_C CloudData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPreset_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Clouds_UI_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004EBA RID: 20154
		// (get) Token: 0x06024F2E RID: 151342 RVA: 0x009ACB23 File Offset: 0x009AAD23
		// (set) Token: 0x06024F2F RID: 151343 RVA: 0x009ACB33 File Offset: 0x009AAD33
		public unsafe bool Counting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EBB RID: 20155
		// (get) Token: 0x06024F30 RID: 151344 RVA: 0x009ACB44 File Offset: 0x009AAD44
		// (set) Token: 0x06024F31 RID: 151345 RVA: 0x009ACB58 File Offset: 0x009AAD58
		public unsafe TEnumAsByte<E_Cloud_Presents> 默认进入云预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004EBC RID: 20156
		// (get) Token: 0x06024F32 RID: 151346 RVA: 0x009ACB6D File Offset: 0x009AAD6D
		// (set) Token: 0x06024F33 RID: 151347 RVA: 0x009ACB82 File Offset: 0x009AAD82
		[Nullable(1)]
		public TSoftObjectPtr<PD_CloudPrefab_C> CloudAsset
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_8, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004EBD RID: 20157
		// (get) Token: 0x06024F34 RID: 151348 RVA: 0x009ACBA8 File Offset: 0x009AADA8
		// (set) Token: 0x06024F35 RID: 151349 RVA: 0x009ACBE1 File Offset: 0x009AADE1
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
					result = (this._SortNumber = new TArray<int>(base.NativePtr + (IntPtr)BP_Clouds_UI_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SortNumber.CopyAssign(value);
			}
		}

		// Token: 0x06024F36 RID: 151350 RVA: 0x009ACBEF File Offset: 0x009AADEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 岁光()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__岁光_NativeFunctionPtr, null);
		}

		// Token: 0x06024F37 RID: 151351 RVA: 0x009ACC03 File Offset: 0x009AAE03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _012夜晚异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___012夜晚异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024F38 RID: 151352 RVA: 0x009ACC17 File Offset: 0x009AAE17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _011黄昏异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___011黄昏异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024F39 RID: 151353 RVA: 0x009ACC2B File Offset: 0x009AAE2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 北落野副本()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__北落野副本_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3A RID: 151354 RVA: 0x009ACC3F File Offset: 0x009AAE3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _010阴天异象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___010阴天异象_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3B RID: 151355 RVA: 0x009ACC53 File Offset: 0x009AAE53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _09鸣潮天气()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___09鸣潮天气_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3C RID: 151356 RVA: 0x009ACC67 File Offset: 0x009AAE67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _08漩涡云01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___08漩涡云01_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3D RID: 151357 RVA: 0x009ACC7B File Offset: 0x009AAE7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _07无音区05()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___07无音区05_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3E RID: 151358 RVA: 0x009ACC8F File Offset: 0x009AAE8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _06无音区04()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___06无音区04_NativeFunctionPtr, null);
		}

		// Token: 0x06024F3F RID: 151359 RVA: 0x009ACCA3 File Offset: 0x009AAEA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _05无音区03()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___05无音区03_NativeFunctionPtr, null);
		}

		// Token: 0x06024F40 RID: 151360 RVA: 0x009ACCB7 File Offset: 0x009AAEB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04无音区02()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___04无音区02_NativeFunctionPtr, null);
		}

		// Token: 0x06024F41 RID: 151361 RVA: 0x009ACCCB File Offset: 0x009AAECB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 原画测试用云()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__原画测试用云_NativeFunctionPtr, null);
		}

		// Token: 0x06024F42 RID: 151362 RVA: 0x009ACCE0 File Offset: 0x009AAEE0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCloudParameters(PD_CloudPrefab_C CloudPrefeb, UChildActorComponent CloudActorComponent, float ChangeSpeed, int TransSortNumber)
		{
			BP_Clouds_UI_C.__SetCloudParameters_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__SetCloudParameters_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Clouds_UI_C.__SetCloudParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPrefeb = ((CloudPrefeb != null) ? CloudPrefeb.NativePtr : IntPtr.Zero);
			ptr->CloudActorComponent = ((CloudActorComponent != null) ? CloudActorComponent.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->TransSortNumber = TransSortNumber;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__SetCloudParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F43 RID: 151363 RVA: 0x009ACD5A File Offset: 0x009AAF5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _04中曲台地()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___04中曲台地_NativeFunctionPtr, null);
		}

		// Token: 0x06024F44 RID: 151364 RVA: 0x009ACD6E File Offset: 0x009AAF6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Hidden_Old()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__Hidden_Old_NativeFunctionPtr, null);
		}

		// Token: 0x06024F45 RID: 151365 RVA: 0x009ACD84 File Offset: 0x009AAF84
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SwitchCloudsSub(PD_CloudPrefab_C CloudPresents, float ChangeSpeed)
		{
			BP_Clouds_UI_C.__SwitchCloudsSub_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__SwitchCloudsSub_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Clouds_UI_C.__SwitchCloudsSub_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__SwitchCloudsSub_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = ((CloudPresents != null) ? CloudPresents.NativePtr : IntPtr.Zero);
			ptr->ChangeSpeed = ChangeSpeed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__SwitchCloudsSub_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F46 RID: 151366 RVA: 0x009ACDE0 File Offset: 0x009AAFE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03无音区01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___03无音区01_NativeFunctionPtr, null);
		}

		// Token: 0x06024F47 RID: 151367 RVA: 0x009ACDF4 File Offset: 0x009AAFF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02无音区沉寂态()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___02无音区沉寂态_NativeFunctionPtr, null);
		}

		// Token: 0x06024F48 RID: 151368 RVA: 0x009ACE08 File Offset: 0x009AB008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01登录界面()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___01登录界面_NativeFunctionPtr, null);
		}

		// Token: 0x06024F49 RID: 151369 RVA: 0x009ACE1C File Offset: 0x009AB01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _03无光之森()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___03无光之森_NativeFunctionPtr, null);
		}

		// Token: 0x06024F4A RID: 151370 RVA: 0x009ACE30 File Offset: 0x009AB030
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _02遗落原乡()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___02遗落原乡_NativeFunctionPtr, null);
		}

		// Token: 0x06024F4B RID: 151371 RVA: 0x009ACE44 File Offset: 0x009AB044
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void _01天城()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.___01天城_NativeFunctionPtr, null);
		}

		// Token: 0x06024F4C RID: 151372 RVA: 0x009ACE58 File Offset: 0x009AB058
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024F4D RID: 151373 RVA: 0x009ACE6C File Offset: 0x009AB06C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_UI_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F4E RID: 151374 RVA: 0x009ACE84 File Offset: 0x009AB084
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_D7528C144F64E8F8F9F429A67D0EE541(UObject Loaded)
		{
			BP_Clouds_UI_C.__OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Clouds_UI_C.__OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F4F RID: 151375 RVA: 0x009ACED9 File Offset: 0x009AB0D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024F50 RID: 151376 RVA: 0x009ACEED File Offset: 0x009AB0ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_UI_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F51 RID: 151377 RVA: 0x009ACF04 File Offset: 0x009AB104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Clouds_UI_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_UI_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F52 RID: 151378 RVA: 0x009ACF4C File Offset: 0x009AB14C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Clouds_UI_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_UI_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_UI_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F53 RID: 151379 RVA: 0x009ACF94 File Offset: 0x009AB194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Clouds_UI_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_UI_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F54 RID: 151380 RVA: 0x009ACFDC File Offset: 0x009AB1DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Clouds_UI_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Clouds_UI_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_UI_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F55 RID: 151381 RVA: 0x009AD023 File Offset: 0x009AB223
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ChangeCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__ChangeCloud_NativeFunctionPtr, null);
		}

		// Token: 0x06024F56 RID: 151382 RVA: 0x009AD038 File Offset: 0x009AB238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Switch_Clouds(E_Cloud_Presents CloudPresents, float ChangeSpeed, bool IsInEditor)
		{
			BP_Clouds_UI_C.__Switch_Clouds_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__Switch_Clouds_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Clouds_UI_C.__Switch_Clouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudPresents = CloudPresents;
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__Switch_Clouds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024F57 RID: 151383 RVA: 0x009AD094 File Offset: 0x009AB294
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadAndSwitch(TSoftObjectPtr<UObject> Asset, float ChangeSpeed, bool IsInEditor)
		{
			BP_Clouds_UI_C.__LoadAndSwitch_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__LoadAndSwitch_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Clouds_UI_C.__LoadAndSwitch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
			if (Asset != null)
			{
				FSoftObjectPtr.NativeCopy(&ptr->Asset, Asset.NativePtr, 1);
			}
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsInEditor = IsInEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Clouds_UI_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_Clouds_UI_C.__LoadAndSwitch_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024F58 RID: 151384 RVA: 0x009AD110 File Offset: 0x009AB310
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Clouds_UI(int EntryPoint)
		{
			BP_Clouds_UI_C.__ExecuteUbergraph_BP_Clouds_UI_FunctionParams* ptr = stackalloc BP_Clouds_UI_C.__ExecuteUbergraph_BP_Clouds_UI_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Clouds_UI_C.__ExecuteUbergraph_BP_Clouds_UI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Clouds_UI_C.__ExecuteUbergraph_BP_Clouds_UI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Clouds_UI_C.__ExecuteUbergraph_BP_Clouds_UI_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F59 RID: 151385 RVA: 0x009AD15A File Offset: 0x009AB35A
		protected BP_Clouds_UI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012FA9 RID: 77737
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Clouds_UI.BP_Clouds_UI_C";

		// Token: 0x04012FAA RID: 77738
		private static IntPtr _ClassPtr;

		// Token: 0x04012FAB RID: 77739
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012FAC RID: 77740
		internal static int __PropertyOffset_0;

		// Token: 0x04012FAD RID: 77741
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012FAE RID: 77742
		internal static int __PropertyOffset_1;

		// Token: 0x04012FAF RID: 77743
		internal static int __PropertyOffset_2;

		// Token: 0x04012FB0 RID: 77744
		internal static int __PropertyOffset_3;

		// Token: 0x04012FB1 RID: 77745
		internal static int __PropertyOffset_4;

		// Token: 0x04012FB2 RID: 77746
		internal static int __PropertyOffset_5;

		// Token: 0x04012FB3 RID: 77747
		internal static int __PropertyOffset_6;

		// Token: 0x04012FB4 RID: 77748
		internal static int __PropertyOffset_7;

		// Token: 0x04012FB5 RID: 77749
		internal static int __PropertyOffset_8;

		// Token: 0x04012FB6 RID: 77750
		internal static int __PropertyOffset_9;

		// Token: 0x04012FB7 RID: 77751
		[Nullable(2)]
		private TArray<int> _SortNumber;

		// Token: 0x04012FB8 RID: 77752
		private static IntPtr __岁光_NativeFunctionPtr;

		// Token: 0x04012FB9 RID: 77753
		private static IntPtr ___012夜晚异象_NativeFunctionPtr;

		// Token: 0x04012FBA RID: 77754
		private static IntPtr ___011黄昏异象_NativeFunctionPtr;

		// Token: 0x04012FBB RID: 77755
		private static IntPtr __北落野副本_NativeFunctionPtr;

		// Token: 0x04012FBC RID: 77756
		private static IntPtr ___010阴天异象_NativeFunctionPtr;

		// Token: 0x04012FBD RID: 77757
		private static IntPtr ___09鸣潮天气_NativeFunctionPtr;

		// Token: 0x04012FBE RID: 77758
		private static IntPtr ___08漩涡云01_NativeFunctionPtr;

		// Token: 0x04012FBF RID: 77759
		private static IntPtr ___07无音区05_NativeFunctionPtr;

		// Token: 0x04012FC0 RID: 77760
		private static IntPtr ___06无音区04_NativeFunctionPtr;

		// Token: 0x04012FC1 RID: 77761
		private static IntPtr ___05无音区03_NativeFunctionPtr;

		// Token: 0x04012FC2 RID: 77762
		private static IntPtr ___04无音区02_NativeFunctionPtr;

		// Token: 0x04012FC3 RID: 77763
		private static IntPtr __原画测试用云_NativeFunctionPtr;

		// Token: 0x04012FC4 RID: 77764
		private static IntPtr __SetCloudParameters_NativeFunctionPtr;

		// Token: 0x04012FC5 RID: 77765
		private static IntPtr ___04中曲台地_NativeFunctionPtr;

		// Token: 0x04012FC6 RID: 77766
		private static IntPtr __Hidden_Old_NativeFunctionPtr;

		// Token: 0x04012FC7 RID: 77767
		private static IntPtr __SwitchCloudsSub_NativeFunctionPtr;

		// Token: 0x04012FC8 RID: 77768
		private static IntPtr ___03无音区01_NativeFunctionPtr;

		// Token: 0x04012FC9 RID: 77769
		private static IntPtr ___02无音区沉寂态_NativeFunctionPtr;

		// Token: 0x04012FCA RID: 77770
		private static IntPtr ___01登录界面_NativeFunctionPtr;

		// Token: 0x04012FCB RID: 77771
		private static IntPtr ___03无光之森_NativeFunctionPtr;

		// Token: 0x04012FCC RID: 77772
		private static IntPtr ___02遗落原乡_NativeFunctionPtr;

		// Token: 0x04012FCD RID: 77773
		private static IntPtr ___01天城_NativeFunctionPtr;

		// Token: 0x04012FCE RID: 77774
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012FCF RID: 77775
		private static IntPtr __OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_NativeFunctionPtr;

		// Token: 0x04012FD0 RID: 77776
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012FD1 RID: 77777
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012FD2 RID: 77778
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012FD3 RID: 77779
		private static IntPtr __ChangeCloud_NativeFunctionPtr;

		// Token: 0x04012FD4 RID: 77780
		private static IntPtr __Switch_Clouds_NativeFunctionPtr;

		// Token: 0x04012FD5 RID: 77781
		private static IntPtr __LoadAndSwitch_NativeFunctionPtr;

		// Token: 0x04012FD6 RID: 77782
		private static IntPtr __ExecuteUbergraph_BP_Clouds_UI_NativeFunctionPtr;

		// Token: 0x02009EA0 RID: 40608
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetCloudParameters_FunctionParams
		{
			// Token: 0x04032958 RID: 207192
			[FieldOffset(0)]
			public IntPtr CloudPrefeb;

			// Token: 0x04032959 RID: 207193
			[FieldOffset(8)]
			public IntPtr CloudActorComponent;

			// Token: 0x0403295A RID: 207194
			[FieldOffset(16)]
			public float ChangeSpeed;

			// Token: 0x0403295B RID: 207195
			[FieldOffset(20)]
			public int TransSortNumber;
		}

		// Token: 0x02009EA1 RID: 40609
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __SwitchCloudsSub_FunctionParams
		{
			// Token: 0x0403295C RID: 207196
			[FieldOffset(0)]
			public IntPtr CloudPresents;

			// Token: 0x0403295D RID: 207197
			[FieldOffset(8)]
			public float ChangeSpeed;
		}

		// Token: 0x02009EA2 RID: 40610
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_D7528C144F64E8F8F9F429A67D0EE541_FunctionParams
		{
			// Token: 0x0403295E RID: 207198
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009EA3 RID: 40611
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403295F RID: 207199
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EA4 RID: 40612
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032960 RID: 207200
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EA5 RID: 40613
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Switch_Clouds_FunctionParams
		{
			// Token: 0x04032961 RID: 207201
			[FieldOffset(0)]
			public TEnumAsByte<E_Cloud_Presents> CloudPresents;

			// Token: 0x04032962 RID: 207202
			[FieldOffset(4)]
			public float ChangeSpeed;

			// Token: 0x04032963 RID: 207203
			[FieldOffset(8)]
			public bool IsInEditor;
		}

		// Token: 0x02009EA6 RID: 40614
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __LoadAndSwitch_FunctionParams
		{
			// Token: 0x04032964 RID: 207204
			[FieldOffset(0)]
			public byte Asset;

			// Token: 0x04032965 RID: 207205
			[FieldOffset(48)]
			public float ChangeSpeed;

			// Token: 0x04032966 RID: 207206
			[FieldOffset(52)]
			public bool IsInEditor;
		}

		// Token: 0x02009EA7 RID: 40615
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_BP_Clouds_UI_FunctionParams
		{
			// Token: 0x04032967 RID: 207207
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
