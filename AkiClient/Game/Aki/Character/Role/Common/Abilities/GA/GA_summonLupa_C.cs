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
	// Token: 0x020040BA RID: 16570
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonLupa.GA_summonLupa_C")]
	[UnrealStructLayout(1648, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class GA_summonLupa_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B467 RID: 177255 RVA: 0x00A762B4 File Offset: 0x00A744B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_summonLupa_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonLupa.GA_summonLupa_C");
			}
			return GA_summonLupa_C._ClassPtr;
		}

		// Token: 0x0602B468 RID: 177256 RVA: 0x00A762D8 File Offset: 0x00A744D8
		public GA_summonLupa_C() : this(BuiltinUtils.AllocNativeUObject(GA_summonLupa_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B469 RID: 177257 RVA: 0x00A76300 File Offset: 0x00A74500
		public GA_summonLupa_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_summonLupa_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007159 RID: 29017
		// (get) Token: 0x0602B46A RID: 177258 RVA: 0x00A76334 File Offset: 0x00A74534
		// (set) Token: 0x0602B46B RID: 177259 RVA: 0x00A7636D File Offset: 0x00A7456D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700715A RID: 29018
		// (get) Token: 0x0602B46C RID: 177260 RVA: 0x00A76390 File Offset: 0x00A74590
		// (set) Token: 0x0602B46D RID: 177261 RVA: 0x00A763C9 File Offset: 0x00A745C9
		public TMap<int, bool> NewVar_0
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, bool> result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new TMap<int, bool>(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.NewVar_0.CopyAssign(value);
			}
		}

		// Token: 0x1700715B RID: 29019
		// (get) Token: 0x0602B46E RID: 177262 RVA: 0x00A763D7 File Offset: 0x00A745D7
		// (set) Token: 0x0602B46F RID: 177263 RVA: 0x00A763E7 File Offset: 0x00A745E7
		public unsafe bool NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700715C RID: 29020
		// (get) Token: 0x0602B470 RID: 177264 RVA: 0x00A763F8 File Offset: 0x00A745F8
		// (set) Token: 0x0602B471 RID: 177265 RVA: 0x00A7640C File Offset: 0x00A7460C
		[Nullable(2)]
		public unsafe TsBaseCharacter 露帕
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonLupa_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonLupa_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700715D RID: 29021
		// (get) Token: 0x0602B472 RID: 177266 RVA: 0x00A76421 File Offset: 0x00A74621
		// (set) Token: 0x0602B473 RID: 177267 RVA: 0x00A76435 File Offset: 0x00A74635
		[Nullable(2)]
		public unsafe TsBaseCharacter 辅助闪避的角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonLupa_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonLupa_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700715E RID: 29022
		// (get) Token: 0x0602B474 RID: 177268 RVA: 0x00A7644A File Offset: 0x00A7464A
		// (set) Token: 0x0602B475 RID: 177269 RVA: 0x00A7645E File Offset: 0x00A7465E
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_summonLupa_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602B476 RID: 177270 RVA: 0x00A76473 File Offset: 0x00A74673
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_958D05BD436AC6F4B6B69ABBFDAC7873()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonLupa_C.__OnFinish_958D05BD436AC6F4B6B69ABBFDAC7873_NativeFunctionPtr, null);
		}

		// Token: 0x0602B477 RID: 177271 RVA: 0x00A76488 File Offset: 0x00A74688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_summonLupa_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_summonLupa_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_summonLupa_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonLupa_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonLupa_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B478 RID: 177272 RVA: 0x00A764D0 File Offset: 0x00A746D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_summonLupa_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_summonLupa_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_summonLupa_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonLupa_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonLupa_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B479 RID: 177273 RVA: 0x00A76517 File Offset: 0x00A74717
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonLupa_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B47A RID: 177274 RVA: 0x00A7652B File Offset: 0x00A7472B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonLupa_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B47B RID: 177275 RVA: 0x00A76540 File Offset: 0x00A74740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_summonLupa(int EntryPoint)
		{
			GA_summonLupa_C.__ExecuteUbergraph_GA_summonLupa_FunctionParams* ptr = stackalloc GA_summonLupa_C.__ExecuteUbergraph_GA_summonLupa_FunctionParams[(UIntPtr)927] + 15L / (long)sizeof(GA_summonLupa_C.__ExecuteUbergraph_GA_summonLupa_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonLupa_C.__ExecuteUbergraph_GA_summonLupa_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonLupa_C.__ExecuteUbergraph_GA_summonLupa_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B47C RID: 177276 RVA: 0x00A7658A File Offset: 0x00A7478A
		protected GA_summonLupa_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B4E RID: 97102
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonLupa.GA_summonLupa_C";

		// Token: 0x04017B4F RID: 97103
		private static IntPtr _ClassPtr;

		// Token: 0x04017B50 RID: 97104
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B51 RID: 97105
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B52 RID: 97106
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B53 RID: 97107
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B54 RID: 97108
		[Nullable(2)]
		private TMap<int, bool> _NewVar_0;

		// Token: 0x04017B55 RID: 97109
		internal new static int __PropertyOffset_2;

		// Token: 0x04017B56 RID: 97110
		internal new static int __PropertyOffset_3;

		// Token: 0x04017B57 RID: 97111
		internal static int __PropertyOffset_4;

		// Token: 0x04017B58 RID: 97112
		internal static int __PropertyOffset_5;

		// Token: 0x04017B59 RID: 97113
		private static IntPtr __OnFinish_958D05BD436AC6F4B6B69ABBFDAC7873_NativeFunctionPtr;

		// Token: 0x04017B5A RID: 97114
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017B5B RID: 97115
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B5C RID: 97116
		private static IntPtr __ExecuteUbergraph_GA_summonLupa_NativeFunctionPtr;

		// Token: 0x0200A33F RID: 41791
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403311C RID: 209180
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A340 RID: 41792
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 912)]
		protected ref struct __ExecuteUbergraph_GA_summonLupa_FunctionParams
		{
			// Token: 0x0403311D RID: 209181
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
