using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GB
{
	// Token: 0x02004373 RID: 17267
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GB/BP_BulletLogicBase.BP_BulletLogicBase_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_BulletLogicBase_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB3A RID: 187194 RVA: 0x00AC7894 File Offset: 0x00AC5A94
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BulletLogicBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GB/BP_BulletLogicBase.BP_BulletLogicBase_C");
			}
			return BP_BulletLogicBase_C._ClassPtr;
		}

		// Token: 0x0602DB3B RID: 187195 RVA: 0x00AC78B8 File Offset: 0x00AC5AB8
		public BP_BulletLogicBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_BulletLogicBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB3C RID: 187196 RVA: 0x00AC78E0 File Offset: 0x00AC5AE0
		[NullableContext(1)]
		public BP_BulletLogicBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BulletLogicBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB3D RID: 187197 RVA: 0x00AC7914 File Offset: 0x00AC5B14
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 子弹范围内吸附(UObject 子弹, float 吸附速度)
		{
			BP_BulletLogicBase_C.__子弹范围内吸附_FunctionParams* ptr = stackalloc BP_BulletLogicBase_C.__子弹范围内吸附_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_BulletLogicBase_C.__子弹范围内吸附_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletLogicBase_C.__子弹范围内吸附_NativeFunctionPtr, (void*)ptr, 1);
			ptr->子弹 = ((子弹 != null) ? 子弹.NativePtr : IntPtr.Zero);
			ptr->吸附速度 = 吸附速度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletLogicBase_C.__子弹范围内吸附_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB3E RID: 187198 RVA: 0x00AC7970 File Offset: 0x00AC5B70
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 执行(TsBaseCharacter 攻击者, TsBaseCharacter 受击者, SBulletDataMain 子弹数据, UObject 子弹)
		{
			BP_BulletLogicBase_C.__执行_FunctionParams* ptr = stackalloc BP_BulletLogicBase_C.__执行_FunctionParams[(UIntPtr)743] + 15L / (long)sizeof(BP_BulletLogicBase_C.__执行_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BulletLogicBase_C.__执行_NativeFunctionPtr, (void*)ptr, 1);
			ptr->攻击者 = ((攻击者 != null) ? 攻击者.NativePtr : IntPtr.Zero);
			ptr->受击者 = ((受击者 != null) ? 受击者.NativePtr : IntPtr.Zero);
			if (子弹数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMain.StaticStruct(), &ptr->子弹数据, 子弹数据.NativePtr, 1, false);
			}
			ptr->子弹 = ((子弹 != null) ? 子弹.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BulletLogicBase_C.__执行_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_BulletLogicBase_C.__执行_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB3F RID: 187199 RVA: 0x00AC7A29 File Offset: 0x00AC5C29
		protected BP_BulletLogicBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C75 RID: 105589
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GB/BP_BulletLogicBase.BP_BulletLogicBase_C";

		// Token: 0x04019C76 RID: 105590
		private static IntPtr _ClassPtr;

		// Token: 0x04019C77 RID: 105591
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019C78 RID: 105592
		private static IntPtr __子弹范围内吸附_NativeFunctionPtr;

		// Token: 0x04019C79 RID: 105593
		private static IntPtr __执行_NativeFunctionPtr;

		// Token: 0x0200A533 RID: 42291
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __子弹范围内吸附_FunctionParams
		{
			// Token: 0x040333EF RID: 209903
			[FieldOffset(0)]
			public IntPtr 子弹;

			// Token: 0x040333F0 RID: 209904
			[FieldOffset(8)]
			public float 吸附速度;
		}

		// Token: 0x0200A534 RID: 42292
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 728)]
		protected ref struct __执行_FunctionParams
		{
			// Token: 0x040333F1 RID: 209905
			[FieldOffset(0)]
			public IntPtr 攻击者;

			// Token: 0x040333F2 RID: 209906
			[FieldOffset(8)]
			public IntPtr 受击者;

			// Token: 0x040333F3 RID: 209907
			[FieldOffset(16)]
			public byte 子弹数据;

			// Token: 0x040333F4 RID: 209908
			[FieldOffset(720)]
			public IntPtr 子弹;
		}
	}
}
