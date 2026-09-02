using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E10 RID: 15888
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleSubSkeletalInfo.SRoleSubSkeletalInfo")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 108)]
	public class SRoleSubSkeletalInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060272A8 RID: 160424 RVA: 0x009EB4EA File Offset: 0x009E96EA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleSubSkeletalInfo._ScriptStructPtr != 0) ? SRoleSubSkeletalInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleSubSkeletalInfo.SRoleSubSkeletalInfo", ref SRoleSubSkeletalInfo._ScriptStructPtr);
		}

		// Token: 0x17005B6C RID: 23404
		// (get) Token: 0x060272A9 RID: 160425 RVA: 0x009EB50E File Offset: 0x009E970E
		// (set) Token: 0x060272AA RID: 160426 RVA: 0x009EB52D File Offset: 0x009E972D
		public TSoftObjectPtr<USkeletalMesh> 子骨骼模型
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B6D RID: 23405
		// (get) Token: 0x060272AB RID: 160427 RVA: 0x009EB552 File Offset: 0x009E9752
		// (set) Token: 0x060272AC RID: 160428 RVA: 0x009EB571 File Offset: 0x009E9771
		public TSoftClassPtr<UAnimInstance> 子骨骼动画蓝图
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B6E RID: 23406
		// (get) Token: 0x060272AD RID: 160429 RVA: 0x009EB596 File Offset: 0x009E9796
		// (set) Token: 0x060272AE RID: 160430 RVA: 0x009EB5AA File Offset: 0x009E97AA
		public unsafe FName 插槽名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSubSkeletalInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x060272AF RID: 160431 RVA: 0x009EB5BF File Offset: 0x009E97BF
		public SRoleSubSkeletalInfo()
		{
		}

		// Token: 0x060272B0 RID: 160432 RVA: 0x009EB5C7 File Offset: 0x009E97C7
		public SRoleSubSkeletalInfo(TSoftObjectPtr<USkeletalMesh> 子骨骼模型, TSoftClassPtr<UAnimInstance> 子骨骼动画蓝图, FName 插槽名称)
		{
			this.子骨骼模型 = 子骨骼模型;
			this.子骨骼动画蓝图 = 子骨骼动画蓝图;
			this.插槽名称 = 插槽名称;
		}

		// Token: 0x060272B1 RID: 160433 RVA: 0x009EB5E4 File Offset: 0x009E97E4
		protected override IntPtr GetUStructPtr()
		{
			return SRoleSubSkeletalInfo.StaticStruct();
		}

		// Token: 0x060272B2 RID: 160434 RVA: 0x009EB5F0 File Offset: 0x009E97F0
		[NullableContext(2)]
		public SRoleSubSkeletalInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060272B3 RID: 160435 RVA: 0x009EB5FA File Offset: 0x009E97FA
		public SRoleSubSkeletalInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060272B4 RID: 160436 RVA: 0x009EB605 File Offset: 0x009E9805
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleSubSkeletalInfo(Pointer, false, true);
		}

		// Token: 0x060272B5 RID: 160437 RVA: 0x009EB60F File Offset: 0x009E980F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleSubSkeletalInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014768 RID: 83816
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleSubSkeletalInfo.SRoleSubSkeletalInfo";

		// Token: 0x04014769 RID: 83817
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401476A RID: 83818
		internal static int __PropertyOffset_0;

		// Token: 0x0401476B RID: 83819
		internal static int __PropertyOffset_1;

		// Token: 0x0401476C RID: 83820
		internal static int __PropertyOffset_2;
	}
}
