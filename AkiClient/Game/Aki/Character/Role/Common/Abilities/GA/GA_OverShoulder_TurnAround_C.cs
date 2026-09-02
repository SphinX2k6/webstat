using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200409E RID: 16542
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_OverShoulder_TurnAround.GA_OverShoulder_TurnAround_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1508)]
	public class GA_OverShoulder_TurnAround_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B0E8 RID: 176360 RVA: 0x00A6EF78 File Offset: 0x00A6D178
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_OverShoulder_TurnAround_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_OverShoulder_TurnAround.GA_OverShoulder_TurnAround_C");
			}
			return GA_OverShoulder_TurnAround_C._ClassPtr;
		}

		// Token: 0x0602B0E9 RID: 176361 RVA: 0x00A6EF9C File Offset: 0x00A6D19C
		public GA_OverShoulder_TurnAround_C() : this(BuiltinUtils.AllocNativeUObject(GA_OverShoulder_TurnAround_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0EA RID: 176362 RVA: 0x00A6EFC4 File Offset: 0x00A6D1C4
		public GA_OverShoulder_TurnAround_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_OverShoulder_TurnAround_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700708E RID: 28814
		// (get) Token: 0x0602B0EB RID: 176363 RVA: 0x00A6EFF8 File Offset: 0x00A6D1F8
		// (set) Token: 0x0602B0EC RID: 176364 RVA: 0x00A6F031 File Offset: 0x00A6D231
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_OverShoulder_TurnAround_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_OverShoulder_TurnAround_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700708F RID: 28815
		// (get) Token: 0x0602B0ED RID: 176365 RVA: 0x00A6F052 File Offset: 0x00A6D252
		// (set) Token: 0x0602B0EE RID: 176366 RVA: 0x00A6F066 File Offset: 0x00A6D266
		[Nullable(2)]
		public unsafe TsBaseCharacter Owner
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_OverShoulder_TurnAround_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_OverShoulder_TurnAround_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007090 RID: 28816
		// (get) Token: 0x0602B0EF RID: 176367 RVA: 0x00A6F07B File Offset: 0x00A6D27B
		// (set) Token: 0x0602B0F0 RID: 176368 RVA: 0x00A6F08F File Offset: 0x00A6D28F
		public unsafe FRotator EndRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_OverShoulder_TurnAround_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_OverShoulder_TurnAround_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B0F1 RID: 176369 RVA: 0x00A6F0A4 File Offset: 0x00A6D2A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81F8B7F793()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__OnTick_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F2 RID: 176370 RVA: 0x00A6F0B8 File Offset: 0x00A6D2B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81F8B7F793()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__OnCancelled_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F3 RID: 176371 RVA: 0x00A6F0CC File Offset: 0x00A6D2CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81F8B7F793()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__OnInterrupted_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F4 RID: 176372 RVA: 0x00A6F0E0 File Offset: 0x00A6D2E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81F8B7F793()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__OnBlendOut_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F5 RID: 176373 RVA: 0x00A6F0F4 File Offset: 0x00A6D2F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81F8B7F793()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__OnCompleted_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F6 RID: 176374 RVA: 0x00A6F108 File Offset: 0x00A6D308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0F7 RID: 176375 RVA: 0x00A6F11C File Offset: 0x00A6D31C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B0F8 RID: 176376 RVA: 0x00A6F134 File Offset: 0x00A6D334
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_OverShoulder_TurnAround(int EntryPoint)
		{
			GA_OverShoulder_TurnAround_C.__ExecuteUbergraph_GA_OverShoulder_TurnAround_FunctionParams* ptr = stackalloc GA_OverShoulder_TurnAround_C.__ExecuteUbergraph_GA_OverShoulder_TurnAround_FunctionParams[(UIntPtr)775] + 15L / (long)sizeof(GA_OverShoulder_TurnAround_C.__ExecuteUbergraph_GA_OverShoulder_TurnAround_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_OverShoulder_TurnAround_C.__ExecuteUbergraph_GA_OverShoulder_TurnAround_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_OverShoulder_TurnAround_C.__ExecuteUbergraph_GA_OverShoulder_TurnAround_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0F9 RID: 176377 RVA: 0x00A6F17E File Offset: 0x00A6D37E
		protected GA_OverShoulder_TurnAround_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178C5 RID: 96453
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_OverShoulder_TurnAround.GA_OverShoulder_TurnAround_C";

		// Token: 0x040178C6 RID: 96454
		private static IntPtr _ClassPtr;

		// Token: 0x040178C7 RID: 96455
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178C8 RID: 96456
		internal new static int __PropertyOffset_0;

		// Token: 0x040178C9 RID: 96457
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178CA RID: 96458
		internal new static int __PropertyOffset_1;

		// Token: 0x040178CB RID: 96459
		internal new static int __PropertyOffset_2;

		// Token: 0x040178CC RID: 96460
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr;

		// Token: 0x040178CD RID: 96461
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr;

		// Token: 0x040178CE RID: 96462
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr;

		// Token: 0x040178CF RID: 96463
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr;

		// Token: 0x040178D0 RID: 96464
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81F8B7F793_NativeFunctionPtr;

		// Token: 0x040178D1 RID: 96465
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178D2 RID: 96466
		private static IntPtr __ExecuteUbergraph_GA_OverShoulder_TurnAround_NativeFunctionPtr;

		// Token: 0x0200A2DC RID: 41692
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 760)]
		protected ref struct __ExecuteUbergraph_GA_OverShoulder_TurnAround_FunctionParams
		{
			// Token: 0x0403309D RID: 209053
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
