using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x02004089 RID: 16521
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_Swinging.GA_Hook_Swinging_C")]
	[UnrealStructLayout(1888, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1888)]
	public class GA_Hook_Swinging_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF93 RID: 176019 RVA: 0x00A6BC8F File Offset: 0x00A69E8F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Hook_Swinging_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_Swinging.GA_Hook_Swinging_C");
			}
			return GA_Hook_Swinging_C._ClassPtr;
		}

		// Token: 0x0602AF94 RID: 176020 RVA: 0x00A6BCB4 File Offset: 0x00A69EB4
		public GA_Hook_Swinging_C() : this(BuiltinUtils.AllocNativeUObject(GA_Hook_Swinging_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF95 RID: 176021 RVA: 0x00A6BCDC File Offset: 0x00A69EDC
		public GA_Hook_Swinging_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Hook_Swinging_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007060 RID: 28768
		// (get) Token: 0x0602AF96 RID: 176022 RVA: 0x00A6BD10 File Offset: 0x00A69F10
		// (set) Token: 0x0602AF97 RID: 176023 RVA: 0x00A6BD49 File Offset: 0x00A69F49
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007061 RID: 28769
		// (get) Token: 0x0602AF98 RID: 176024 RVA: 0x00A6BD6A File Offset: 0x00A69F6A
		// (set) Token: 0x0602AF99 RID: 176025 RVA: 0x00A6BD7E File Offset: 0x00A69F7E
		[Nullable(2)]
		public unsafe UObject Rope
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Hook_Swinging_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Hook_Swinging_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007062 RID: 28770
		// (get) Token: 0x0602AF9A RID: 176026 RVA: 0x00A6BD93 File Offset: 0x00A69F93
		// (set) Token: 0x0602AF9B RID: 176027 RVA: 0x00A6BDA3 File Offset: 0x00A69FA3
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007063 RID: 28771
		// (get) Token: 0x0602AF9C RID: 176028 RVA: 0x00A6BDB4 File Offset: 0x00A69FB4
		// (set) Token: 0x0602AF9D RID: 176029 RVA: 0x00A6BDED File Offset: 0x00A69FED
		public FTimerHandle SwingingTimer
		{
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._SwingingTimer) == null)
				{
					result = (this._SwingingTimer = new FTimerHandle(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007064 RID: 28772
		// (get) Token: 0x0602AF9E RID: 176030 RVA: 0x00A6BE0E File Offset: 0x00A6A00E
		// (set) Token: 0x0602AF9F RID: 176031 RVA: 0x00A6BE22 File Offset: 0x00A6A022
		public unsafe FVector 移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007065 RID: 28773
		// (get) Token: 0x0602AFA0 RID: 176032 RVA: 0x00A6BE38 File Offset: 0x00A6A038
		// (set) Token: 0x0602AFA1 RID: 176033 RVA: 0x00A6BE71 File Offset: 0x00A6A071
		public SCameraModifier_Settings CameraModifySettings
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._CameraModifySettings) == null)
				{
					result = (this._CameraModifySettings = new SCameraModifier_Settings(base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)GA_Hook_Swinging_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602AFA2 RID: 176034 RVA: 0x00A6BE92 File Offset: 0x00A6A092
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SwingingRotaion()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__SwingingRotaion_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFA3 RID: 176035 RVA: 0x00A6BEA6 File Offset: 0x00A6A0A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_8D96293640861CE3D30811B2BF5219AD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__OnFinish_8D96293640861CE3D30811B2BF5219AD_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFA4 RID: 176036 RVA: 0x00A6BEBA File Offset: 0x00A6A0BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_8D96293640861CE3D30811B2BF5219AD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__OnTick_8D96293640861CE3D30811B2BF5219AD_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFA5 RID: 176037 RVA: 0x00A6BED0 File Offset: 0x00A6A0D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_5442B24C45E0D351ADA243874004C8BC(FGameplayEventData Payload)
		{
			GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_FunctionParams* ptr = stackalloc GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Hook_Swinging_C.__EventReceived_5442B24C45E0D351ADA243874004C8BC_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AFA6 RID: 176038 RVA: 0x00A6BF45 File Offset: 0x00A6A145
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFA7 RID: 176039 RVA: 0x00A6BF59 File Offset: 0x00A6A159
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_Swinging_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFA8 RID: 176040 RVA: 0x00A6BF70 File Offset: 0x00A6A170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_Swinging_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_Swinging_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFA9 RID: 176041 RVA: 0x00A6BFB8 File Offset: 0x00A6A1B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Hook_Swinging_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_Swinging_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_Swinging_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFAA RID: 176042 RVA: 0x00A6C000 File Offset: 0x00A6A200
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Hook_Swinging(int EntryPoint)
		{
			GA_Hook_Swinging_C.__ExecuteUbergraph_GA_Hook_Swinging_FunctionParams* ptr = stackalloc GA_Hook_Swinging_C.__ExecuteUbergraph_GA_Hook_Swinging_FunctionParams[(UIntPtr)1119] + 15L / (long)sizeof(GA_Hook_Swinging_C.__ExecuteUbergraph_GA_Hook_Swinging_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_Swinging_C.__ExecuteUbergraph_GA_Hook_Swinging_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_Swinging_C.__ExecuteUbergraph_GA_Hook_Swinging_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFAB RID: 176043 RVA: 0x00A6C04A File Offset: 0x00A6A24A
		protected GA_Hook_Swinging_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177C2 RID: 96194
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_Swinging.GA_Hook_Swinging_C";

		// Token: 0x040177C3 RID: 96195
		private static IntPtr _ClassPtr;

		// Token: 0x040177C4 RID: 96196
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177C5 RID: 96197
		internal new static int __PropertyOffset_0;

		// Token: 0x040177C6 RID: 96198
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177C7 RID: 96199
		internal new static int __PropertyOffset_1;

		// Token: 0x040177C8 RID: 96200
		internal new static int __PropertyOffset_2;

		// Token: 0x040177C9 RID: 96201
		internal new static int __PropertyOffset_3;

		// Token: 0x040177CA RID: 96202
		[Nullable(2)]
		private FTimerHandle _SwingingTimer;

		// Token: 0x040177CB RID: 96203
		internal static int __PropertyOffset_4;

		// Token: 0x040177CC RID: 96204
		internal static int __PropertyOffset_5;

		// Token: 0x040177CD RID: 96205
		[Nullable(2)]
		private SCameraModifier_Settings _CameraModifySettings;

		// Token: 0x040177CE RID: 96206
		private static IntPtr __SwingingRotaion_NativeFunctionPtr;

		// Token: 0x040177CF RID: 96207
		private static IntPtr __OnFinish_8D96293640861CE3D30811B2BF5219AD_NativeFunctionPtr;

		// Token: 0x040177D0 RID: 96208
		private static IntPtr __OnTick_8D96293640861CE3D30811B2BF5219AD_NativeFunctionPtr;

		// Token: 0x040177D1 RID: 96209
		private static IntPtr __EventReceived_5442B24C45E0D351ADA243874004C8BC_NativeFunctionPtr;

		// Token: 0x040177D2 RID: 96210
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177D3 RID: 96211
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040177D4 RID: 96212
		private static IntPtr __ExecuteUbergraph_GA_Hook_Swinging_NativeFunctionPtr;

		// Token: 0x0200A2AB RID: 41643
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_5442B24C45E0D351ADA243874004C8BC_FunctionParams
		{
			// Token: 0x0403305E RID: 208990
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2AC RID: 41644
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403305F RID: 208991
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2AD RID: 41645
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1104)]
		protected ref struct __ExecuteUbergraph_GA_Hook_Swinging_FunctionParams
		{
			// Token: 0x04033060 RID: 208992
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
