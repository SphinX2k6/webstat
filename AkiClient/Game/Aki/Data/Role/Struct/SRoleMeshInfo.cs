using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Role.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0B RID: 15883
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleMeshInfo.SRoleMeshInfo")]
	[UnrealStructLayout(288, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 288)]
	public class SRoleMeshInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602723D RID: 160317 RVA: 0x009EAAB4 File Offset: 0x009E8CB4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleMeshInfo._ScriptStructPtr != 0) ? SRoleMeshInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleMeshInfo.SRoleMeshInfo", ref SRoleMeshInfo._ScriptStructPtr);
		}

		// Token: 0x17005B4A RID: 23370
		// (get) Token: 0x0602723E RID: 160318 RVA: 0x009EAAD8 File Offset: 0x009E8CD8
		// (set) Token: 0x0602723F RID: 160319 RVA: 0x009EAAEC File Offset: 0x009E8CEC
		public unsafe FName 模型名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B4B RID: 23371
		// (get) Token: 0x06027240 RID: 160320 RVA: 0x009EAB01 File Offset: 0x009E8D01
		// (set) Token: 0x06027241 RID: 160321 RVA: 0x009EAB11 File Offset: 0x009E8D11
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B4C RID: 23372
		// (get) Token: 0x06027242 RID: 160322 RVA: 0x009EAB22 File Offset: 0x009E8D22
		// (set) Token: 0x06027243 RID: 160323 RVA: 0x009EAB41 File Offset: 0x009E8D41
		public TSoftObjectPtr<USkeletalMesh> 角色骨骼模型
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B4D RID: 23373
		// (get) Token: 0x06027244 RID: 160324 RVA: 0x009EAB66 File Offset: 0x009E8D66
		// (set) Token: 0x06027245 RID: 160325 RVA: 0x009EAB85 File Offset: 0x009E8D85
		public TSoftClassPtr<UAnimInstance> 角色动画蓝图
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B4E RID: 23374
		// (get) Token: 0x06027246 RID: 160326 RVA: 0x009EABAC File Offset: 0x009E8DAC
		// (set) Token: 0x06027247 RID: 160327 RVA: 0x009EABEF File Offset: 0x009E8DEF
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ESubRoleSkeletalMeshType>, SRoleSubSkeletalInfo> 子骨骼信息
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ESubRoleSkeletalMeshType>, SRoleSubSkeletalInfo> result;
				if ((result = this._子骨骼信息) == null)
				{
					result = (this._子骨骼信息 = new TMap<TEnumAsByte<ESubRoleSkeletalMeshType>, SRoleSubSkeletalInfo>(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.子骨骼信息.CopyAssign(value);
			}
		}

		// Token: 0x17005B4F RID: 23375
		// (get) Token: 0x06027248 RID: 160328 RVA: 0x009EABFD File Offset: 0x009E8DFD
		// (set) Token: 0x06027249 RID: 160329 RVA: 0x009EAC1C File Offset: 0x009E8E1C
		public TSoftClassPtr<TsBaseCharacter> 角色类
		{
			get
			{
				return new TSoftClassPtr<TsBaseCharacter>(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B50 RID: 23376
		// (get) Token: 0x0602724A RID: 160330 RVA: 0x009EAC41 File Offset: 0x009E8E41
		// (set) Token: 0x0602724B RID: 160331 RVA: 0x009EAC60 File Offset: 0x009E8E60
		public TSoftObjectPtr<UAnimSequence> 预览时的动画
		{
			get
			{
				return new TSoftObjectPtr<UAnimSequence>(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleMeshInfo.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602724C RID: 160332 RVA: 0x009EAC85 File Offset: 0x009E8E85
		public SRoleMeshInfo()
		{
		}

		// Token: 0x0602724D RID: 160333 RVA: 0x009EAC8D File Offset: 0x009E8E8D
		public SRoleMeshInfo(FName 模型名称, int ID, TSoftObjectPtr<USkeletalMesh> 角色骨骼模型, TSoftClassPtr<UAnimInstance> 角色动画蓝图, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<ESubRoleSkeletalMeshType>, SRoleSubSkeletalInfo> 子骨骼信息, TSoftClassPtr<TsBaseCharacter> 角色类, TSoftObjectPtr<UAnimSequence> 预览时的动画)
		{
			this.模型名称 = 模型名称;
			this.ID = ID;
			this.角色骨骼模型 = 角色骨骼模型;
			this.角色动画蓝图 = 角色动画蓝图;
			this.子骨骼信息 = 子骨骼信息;
			this.角色类 = 角色类;
			this.预览时的动画 = 预览时的动画;
		}

		// Token: 0x0602724E RID: 160334 RVA: 0x009EACCA File Offset: 0x009E8ECA
		protected override IntPtr GetUStructPtr()
		{
			return SRoleMeshInfo.StaticStruct();
		}

		// Token: 0x0602724F RID: 160335 RVA: 0x009EACD6 File Offset: 0x009E8ED6
		[NullableContext(2)]
		public SRoleMeshInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027250 RID: 160336 RVA: 0x009EACE0 File Offset: 0x009E8EE0
		public SRoleMeshInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027251 RID: 160337 RVA: 0x009EACEB File Offset: 0x009E8EEB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleMeshInfo(Pointer, false, true);
		}

		// Token: 0x06027252 RID: 160338 RVA: 0x009EACF5 File Offset: 0x009E8EF5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleMeshInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014735 RID: 83765
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleMeshInfo.SRoleMeshInfo";

		// Token: 0x04014736 RID: 83766
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014737 RID: 83767
		internal static int __PropertyOffset_0;

		// Token: 0x04014738 RID: 83768
		internal static int __PropertyOffset_1;

		// Token: 0x04014739 RID: 83769
		internal static int __PropertyOffset_2;

		// Token: 0x0401473A RID: 83770
		internal static int __PropertyOffset_3;

		// Token: 0x0401473B RID: 83771
		internal static int __PropertyOffset_4;

		// Token: 0x0401473C RID: 83772
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ESubRoleSkeletalMeshType>, SRoleSubSkeletalInfo> _子骨骼信息;

		// Token: 0x0401473D RID: 83773
		internal static int __PropertyOffset_5;

		// Token: 0x0401473E RID: 83774
		internal static int __PropertyOffset_6;
	}
}
