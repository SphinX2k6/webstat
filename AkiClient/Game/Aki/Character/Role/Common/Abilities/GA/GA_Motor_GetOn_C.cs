using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.Vehicle.Motor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200409A RID: 16538
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_GetOn.GA_Motor_GetOn_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1500)]
	public class GA_Motor_GetOn_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B09F RID: 176287 RVA: 0x00A6E508 File Offset: 0x00A6C708
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_GetOn_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_GetOn.GA_Motor_GetOn_C");
			}
			return GA_Motor_GetOn_C._ClassPtr;
		}

		// Token: 0x0602B0A0 RID: 176288 RVA: 0x00A6E52C File Offset: 0x00A6C72C
		public GA_Motor_GetOn_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_GetOn_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0A1 RID: 176289 RVA: 0x00A6E554 File Offset: 0x00A6C754
		[NullableContext(1)]
		public GA_Motor_GetOn_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_GetOn_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700707F RID: 28799
		// (get) Token: 0x0602B0A2 RID: 176290 RVA: 0x00A6E588 File Offset: 0x00A6C788
		// (set) Token: 0x0602B0A3 RID: 176291 RVA: 0x00A6E5C1 File Offset: 0x00A6C7C1
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_GetOn_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_GetOn_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007080 RID: 28800
		// (get) Token: 0x0602B0A4 RID: 176292 RVA: 0x00A6E5E2 File Offset: 0x00A6C7E2
		// (set) Token: 0x0602B0A5 RID: 176293 RVA: 0x00A6E5F6 File Offset: 0x00A6C7F6
		[Nullable(2)]
		public unsafe BP_Motor_BaseVehicle_C 摩托车对象缓存
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Motor_BaseVehicle_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_GetOn_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_GetOn_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007081 RID: 28801
		// (get) Token: 0x0602B0A6 RID: 176294 RVA: 0x00A6E60B File Offset: 0x00A6C80B
		// (set) Token: 0x0602B0A7 RID: 176295 RVA: 0x00A6E61B File Offset: 0x00A6C81B
		public unsafe int 摩托车对象entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_GetOn_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_GetOn_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B0A8 RID: 176296 RVA: 0x00A6E62C File Offset: 0x00A6C82C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E817DB48968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__OnTick_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0A9 RID: 176297 RVA: 0x00A6E640 File Offset: 0x00A6C840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E817DB48968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__OnCancelled_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0AA RID: 176298 RVA: 0x00A6E654 File Offset: 0x00A6C854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E817DB48968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__OnInterrupted_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0AB RID: 176299 RVA: 0x00A6E668 File Offset: 0x00A6C868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E817DB48968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__OnBlendOut_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0AC RID: 176300 RVA: 0x00A6E67C File Offset: 0x00A6C87C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E817DB48968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__OnCompleted_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0AD RID: 176301 RVA: 0x00A6E690 File Offset: 0x00A6C890
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0AE RID: 176302 RVA: 0x00A6E6A4 File Offset: 0x00A6C8A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOn_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B0AF RID: 176303 RVA: 0x00A6E6BC File Offset: 0x00A6C8BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOn_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_GetOn_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B0B0 RID: 176304 RVA: 0x00A6E704 File Offset: 0x00A6C904
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_GetOn_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOn_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOn_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0B1 RID: 176305 RVA: 0x00A6E74C File Offset: 0x00A6C94C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_GetOn(int EntryPoint)
		{
			GA_Motor_GetOn_C.__ExecuteUbergraph_GA_Motor_GetOn_FunctionParams* ptr = stackalloc GA_Motor_GetOn_C.__ExecuteUbergraph_GA_Motor_GetOn_FunctionParams[(UIntPtr)863] + 15L / (long)sizeof(GA_Motor_GetOn_C.__ExecuteUbergraph_GA_Motor_GetOn_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_GetOn_C.__ExecuteUbergraph_GA_Motor_GetOn_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_GetOn_C.__ExecuteUbergraph_GA_Motor_GetOn_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0B2 RID: 176306 RVA: 0x00A6E796 File Offset: 0x00A6C996
		protected GA_Motor_GetOn_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017893 RID: 96403
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_GetOn.GA_Motor_GetOn_C";

		// Token: 0x04017894 RID: 96404
		private static IntPtr _ClassPtr;

		// Token: 0x04017895 RID: 96405
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017896 RID: 96406
		internal new static int __PropertyOffset_0;

		// Token: 0x04017897 RID: 96407
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017898 RID: 96408
		internal new static int __PropertyOffset_1;

		// Token: 0x04017899 RID: 96409
		internal new static int __PropertyOffset_2;

		// Token: 0x0401789A RID: 96410
		private static IntPtr __OnTick_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr;

		// Token: 0x0401789B RID: 96411
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr;

		// Token: 0x0401789C RID: 96412
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr;

		// Token: 0x0401789D RID: 96413
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr;

		// Token: 0x0401789E RID: 96414
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E817DB48968_NativeFunctionPtr;

		// Token: 0x0401789F RID: 96415
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178A0 RID: 96416
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040178A1 RID: 96417
		private static IntPtr __ExecuteUbergraph_GA_Motor_GetOn_NativeFunctionPtr;

		// Token: 0x0200A2D2 RID: 41682
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033090 RID: 209040
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2D3 RID: 41683
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 848)]
		protected ref struct __ExecuteUbergraph_GA_Motor_GetOn_FunctionParams
		{
			// Token: 0x04033091 RID: 209041
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
