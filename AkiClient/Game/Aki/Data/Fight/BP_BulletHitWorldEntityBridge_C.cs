using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight
{
	// Token: 0x02003EB7 RID: 16055
	[UnrealObjectPath("/Game/Aki/Data/Fight/BP_BulletHitWorldEntityBridge.BP_BulletHitWorldEntityBridge_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 64)]
	public class BP_BulletHitWorldEntityBridge_C : UBulletHitWorldEntityBridge, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027DE2 RID: 163298 RVA: 0x009FC84F File Offset: 0x009FAA4F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BulletHitWorldEntityBridge_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/BP_BulletHitWorldEntityBridge.BP_BulletHitWorldEntityBridge_C");
			}
			return BP_BulletHitWorldEntityBridge_C._ClassPtr;
		}

		// Token: 0x06027DE3 RID: 163299 RVA: 0x009FC874 File Offset: 0x009FAA74
		public BP_BulletHitWorldEntityBridge_C() : this(BuiltinUtils.AllocNativeUObject(BP_BulletHitWorldEntityBridge_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027DE4 RID: 163300 RVA: 0x009FC89C File Offset: 0x009FAA9C
		[NullableContext(1)]
		public BP_BulletHitWorldEntityBridge_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BulletHitWorldEntityBridge_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005F4B RID: 24395
		// (get) Token: 0x06027DE5 RID: 163301 RVA: 0x009FC8D0 File Offset: 0x009FAAD0
		// (set) Token: 0x06027DE6 RID: 163302 RVA: 0x009FC909 File Offset: 0x009FAB09
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BulletHitWorldEntityBridge_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BulletHitWorldEntityBridge_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027DE7 RID: 163303 RVA: 0x009FC92C File Offset: 0x009FAB2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool HasTag(int EntityId, in FGameplayTag Tag)
		{
			BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__HasTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__HasTag_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06027DE8 RID: 163304 RVA: 0x009FC984 File Offset: 0x009FAB84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool HasTag_Implementation(int EntityId, in FGameplayTag Tag)
		{
			BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__HasTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__HasTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__HasTag_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06027DE9 RID: 163305 RVA: 0x009FC9E0 File Offset: 0x009FABE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override int GetCampRelationship(int Camp1, int Camp2)
		{
			BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Camp1 = Camp1;
			ptr->Camp2 = Camp2;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06027DEA RID: 163306 RVA: 0x009FCA34 File Offset: 0x009FAC34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetCampRelationship_Implementation(int Camp1, int Camp2)
		{
			BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Camp1 = Camp1;
			ptr->Camp2 = Camp2;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__GetCampRelationship_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06027DEB RID: 163307 RVA: 0x009FCA88 File Offset: 0x009FAC88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override int GetCamp(int EntityId)
		{
			BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__GetCamp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__GetCamp_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06027DEC RID: 163308 RVA: 0x009FCAD4 File Offset: 0x009FACD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetCamp_Implementation(int EntityId)
		{
			BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__GetCamp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__GetCamp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__GetCamp_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06027DED RID: 163309 RVA: 0x009FCB21 File Offset: 0x009FAD21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void NotifyExistedOperationList()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__NotifyExistedOperationList_NativeFunctionPtr, null);
		}

		// Token: 0x06027DEE RID: 163310 RVA: 0x009FCB35 File Offset: 0x009FAD35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void NotifyExistedOperationList_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__NotifyExistedOperationList_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027DEF RID: 163311 RVA: 0x009FCB4C File Offset: 0x009FAD4C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void NotifyExistedImmediatelyOperation(in FBulletHitWorldEntityOperation Operation)
		{
			BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_NativeFunctionPtr, (void*)ptr, 1);
			if (Operation != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FBulletHitWorldEntityOperation.StaticStruct(), &ptr->Operation, Operation.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06027DF0 RID: 163312 RVA: 0x009FCBB0 File Offset: 0x009FADB0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void NotifyExistedImmediatelyOperation_Implementation(in FBulletHitWorldEntityOperation Operation)
		{
			BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_NativeFunctionPtr, (void*)ptr, 1);
			if (Operation != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FBulletHitWorldEntityOperation.StaticStruct(), &ptr->Operation, Operation.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__NotifyExistedImmediatelyOperation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027DF1 RID: 163313 RVA: 0x009FCC14 File Offset: 0x009FAE14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BulletHitWorldEntityBridge(int EntryPoint)
		{
			BP_BulletHitWorldEntityBridge_C.__ExecuteUbergraph_BP_BulletHitWorldEntityBridge_FunctionParams* ptr = stackalloc BP_BulletHitWorldEntityBridge_C.__ExecuteUbergraph_BP_BulletHitWorldEntityBridge_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_BulletHitWorldEntityBridge_C.__ExecuteUbergraph_BP_BulletHitWorldEntityBridge_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletHitWorldEntityBridge_C.__ExecuteUbergraph_BP_BulletHitWorldEntityBridge_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BulletHitWorldEntityBridge_C.__ExecuteUbergraph_BP_BulletHitWorldEntityBridge_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027DF2 RID: 163314 RVA: 0x009FCC5B File Offset: 0x009FAE5B
		protected BP_BulletHitWorldEntityBridge_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014EC2 RID: 85698
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/BP_BulletHitWorldEntityBridge.BP_BulletHitWorldEntityBridge_C";

		// Token: 0x04014EC3 RID: 85699
		private static IntPtr _ClassPtr;

		// Token: 0x04014EC4 RID: 85700
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014EC5 RID: 85701
		internal static int __PropertyOffset_0;

		// Token: 0x04014EC6 RID: 85702
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014EC7 RID: 85703
		private static IntPtr __HasTag_NativeFunctionPtr;

		// Token: 0x04014EC8 RID: 85704
		private static IntPtr __GetCampRelationship_NativeFunctionPtr;

		// Token: 0x04014EC9 RID: 85705
		private static IntPtr __GetCamp_NativeFunctionPtr;

		// Token: 0x04014ECA RID: 85706
		private static IntPtr __NotifyExistedOperationList_NativeFunctionPtr;

		// Token: 0x04014ECB RID: 85707
		private static IntPtr __NotifyExistedImmediatelyOperation_NativeFunctionPtr;

		// Token: 0x04014ECC RID: 85708
		private static IntPtr __ExecuteUbergraph_BP_BulletHitWorldEntityBridge_NativeFunctionPtr;

		// Token: 0x0200A0DE RID: 41182
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected new ref struct __HasTag_FunctionParams
		{
			// Token: 0x04032D98 RID: 208280
			[FieldOffset(0)]
			public int EntityId;

			// Token: 0x04032D99 RID: 208281
			[FieldOffset(4)]
			public FGameplayTag Tag;

			// Token: 0x04032D9A RID: 208282
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A0DF RID: 41183
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __GetCampRelationship_FunctionParams
		{
			// Token: 0x04032D9B RID: 208283
			[FieldOffset(0)]
			public int Camp1;

			// Token: 0x04032D9C RID: 208284
			[FieldOffset(4)]
			public int Camp2;

			// Token: 0x04032D9D RID: 208285
			[FieldOffset(8)]
			public int __Result;
		}

		// Token: 0x0200A0E0 RID: 41184
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected new ref struct __GetCamp_FunctionParams
		{
			// Token: 0x04032D9E RID: 208286
			[FieldOffset(0)]
			public int EntityId;

			// Token: 0x04032D9F RID: 208287
			[FieldOffset(4)]
			public int __Result;
		}

		// Token: 0x0200A0E1 RID: 41185
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected new ref struct __NotifyExistedImmediatelyOperation_FunctionParams
		{
			// Token: 0x04032DA0 RID: 208288
			[FieldOffset(0)]
			public byte Operation;
		}

		// Token: 0x0200A0E2 RID: 41186
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_BulletHitWorldEntityBridge_FunctionParams
		{
			// Token: 0x04032DA1 RID: 208289
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
