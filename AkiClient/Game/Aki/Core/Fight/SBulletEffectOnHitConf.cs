using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6B RID: 16235
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SBulletEffectOnHitConf.SBulletEffectOnHitConf")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SBulletEffectOnHitConf : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028884 RID: 166020 RVA: 0x00A0E40F File Offset: 0x00A0C60F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletEffectOnHitConf._ScriptStructPtr != 0) ? SBulletEffectOnHitConf._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SBulletEffectOnHitConf.SBulletEffectOnHitConf", ref SBulletEffectOnHitConf._ScriptStructPtr);
		}

		// Token: 0x170062B5 RID: 25269
		// (get) Token: 0x06028885 RID: 166021 RVA: 0x00A0E433 File Offset: 0x00A0C633
		// (set) Token: 0x06028886 RID: 166022 RVA: 0x00A0E447 File Offset: 0x00A0C647
		public unsafe TEnumAsByte<EBulletEffectOnHitType> 类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062B6 RID: 25270
		// (get) Token: 0x06028887 RID: 166023 RVA: 0x00A0E45C File Offset: 0x00A0C65C
		// (set) Token: 0x06028888 RID: 166024 RVA: 0x00A0E46C File Offset: 0x00A0C66C
		public unsafe bool 启用约束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062B7 RID: 25271
		// (get) Token: 0x06028889 RID: 166025 RVA: 0x00A0E47D File Offset: 0x00A0C67D
		// (set) Token: 0x0602888A RID: 166026 RVA: 0x00A0E491 File Offset: 0x00A0C691
		public unsafe FVector2D 高度约束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170062B8 RID: 25272
		// (get) Token: 0x0602888B RID: 166027 RVA: 0x00A0E4A6 File Offset: 0x00A0C6A6
		// (set) Token: 0x0602888C RID: 166028 RVA: 0x00A0E4BA File Offset: 0x00A0C6BA
		public unsafe FVector 大小缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletEffectOnHitConf.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602888D RID: 166029 RVA: 0x00A0E4CF File Offset: 0x00A0C6CF
		public SBulletEffectOnHitConf()
		{
		}

		// Token: 0x0602888E RID: 166030 RVA: 0x00A0E4D7 File Offset: 0x00A0C6D7
		public SBulletEffectOnHitConf(TEnumAsByte<EBulletEffectOnHitType> 类型, bool 启用约束, FVector2D 高度约束, FVector 大小缩放)
		{
			this.类型 = 类型;
			this.启用约束 = 启用约束;
			this.高度约束 = 高度约束;
			this.大小缩放 = 大小缩放;
		}

		// Token: 0x0602888F RID: 166031 RVA: 0x00A0E4FC File Offset: 0x00A0C6FC
		protected override IntPtr GetUStructPtr()
		{
			return SBulletEffectOnHitConf.StaticStruct();
		}

		// Token: 0x06028890 RID: 166032 RVA: 0x00A0E508 File Offset: 0x00A0C708
		[NullableContext(2)]
		public SBulletEffectOnHitConf(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028891 RID: 166033 RVA: 0x00A0E512 File Offset: 0x00A0C712
		public SBulletEffectOnHitConf(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028892 RID: 166034 RVA: 0x00A0E51D File Offset: 0x00A0C71D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletEffectOnHitConf(Pointer, false, true);
		}

		// Token: 0x06028893 RID: 166035 RVA: 0x00A0E527 File Offset: 0x00A0C727
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletEffectOnHitConf(Pointer, MemoryOwner);
		}

		// Token: 0x04015603 RID: 87555
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SBulletEffectOnHitConf.SBulletEffectOnHitConf";

		// Token: 0x04015604 RID: 87556
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015605 RID: 87557
		internal static int __PropertyOffset_0;

		// Token: 0x04015606 RID: 87558
		internal static int __PropertyOffset_1;

		// Token: 0x04015607 RID: 87559
		internal static int __PropertyOffset_2;

		// Token: 0x04015608 RID: 87560
		internal static int __PropertyOffset_3;
	}
}
