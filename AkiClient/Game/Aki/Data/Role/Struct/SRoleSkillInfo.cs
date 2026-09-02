using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0E RID: 15886
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleSkillInfo.SRoleSkillInfo")]
	[UnrealStructLayout(328, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 324)]
	public class SRoleSkillInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602727B RID: 160379 RVA: 0x009EB078 File Offset: 0x009E9278
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleSkillInfo._ScriptStructPtr != 0) ? SRoleSkillInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleSkillInfo.SRoleSkillInfo", ref SRoleSkillInfo._ScriptStructPtr);
		}

		// Token: 0x17005B5D RID: 23389
		// (get) Token: 0x0602727C RID: 160380 RVA: 0x009EB09C File Offset: 0x009E929C
		// (set) Token: 0x0602727D RID: 160381 RVA: 0x009EB0B0 File Offset: 0x009E92B0
		public unsafe FName 技能名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B5E RID: 23390
		// (get) Token: 0x0602727E RID: 160382 RVA: 0x009EB0C5 File Offset: 0x009E92C5
		// (set) Token: 0x0602727F RID: 160383 RVA: 0x009EB0D5 File Offset: 0x009E92D5
		public unsafe int 技能组Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B5F RID: 23391
		// (get) Token: 0x06027280 RID: 160384 RVA: 0x009EB0E6 File Offset: 0x009E92E6
		// (set) Token: 0x06027281 RID: 160385 RVA: 0x009EB0F6 File Offset: 0x009E92F6
		public unsafe int 技能Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005B60 RID: 23392
		// (get) Token: 0x06027282 RID: 160386 RVA: 0x009EB107 File Offset: 0x009E9307
		// (set) Token: 0x06027283 RID: 160387 RVA: 0x009EB117 File Offset: 0x009E9317
		public unsafe int 技能类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005B61 RID: 23393
		// (get) Token: 0x06027284 RID: 160388 RVA: 0x009EB128 File Offset: 0x009E9328
		// (set) Token: 0x06027285 RID: 160389 RVA: 0x009EB138 File Offset: 0x009E9338
		public unsafe int 技能等级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005B62 RID: 23394
		// (get) Token: 0x06027286 RID: 160390 RVA: 0x009EB149 File Offset: 0x009E9349
		// (set) Token: 0x06027287 RID: 160391 RVA: 0x009EB159 File Offset: 0x009E9359
		public unsafe int 技能上限
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005B63 RID: 23395
		// (get) Token: 0x06027288 RID: 160392 RVA: 0x009EB16A File Offset: 0x009E936A
		// (set) Token: 0x06027289 RID: 160393 RVA: 0x009EB17A File Offset: 0x009E937A
		public unsafe bool 可升级标记
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B64 RID: 23396
		// (get) Token: 0x0602728A RID: 160394 RVA: 0x009EB18C File Offset: 0x009E938C
		// (set) Token: 0x0602728B RID: 160395 RVA: 0x009EB1CF File Offset: 0x009E93CF
		public TArray<int> 技能等级效果Id列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._技能等级效果Id列表) == null)
				{
					result = (this._技能等级效果Id列表 = new TArray<int>(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.技能等级效果Id列表.CopyAssign(value);
			}
		}

		// Token: 0x17005B65 RID: 23397
		// (get) Token: 0x0602728C RID: 160396 RVA: 0x009EB1DD File Offset: 0x009E93DD
		// (set) Token: 0x0602728D RID: 160397 RVA: 0x009EB1F1 File Offset: 0x009E93F1
		public unsafe FName 技能效果描述
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005B66 RID: 23398
		// (get) Token: 0x0602728E RID: 160398 RVA: 0x009EB208 File Offset: 0x009E9408
		// (set) Token: 0x0602728F RID: 160399 RVA: 0x009EB24B File Offset: 0x009E944B
		public TMap<FName, FName> 详细描述
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FName> result;
				if ((result = this._详细描述) == null)
				{
					result = (this._详细描述 = new TMap<FName, FName>(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.详细描述.CopyAssign(value);
			}
		}

		// Token: 0x17005B67 RID: 23399
		// (get) Token: 0x06027290 RID: 160400 RVA: 0x009EB259 File Offset: 0x009E9459
		// (set) Token: 0x06027291 RID: 160401 RVA: 0x009EB26D File Offset: 0x009E946D
		public unsafe FName 新增效果描述
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005B68 RID: 23400
		// (get) Token: 0x06027292 RID: 160402 RVA: 0x009EB282 File Offset: 0x009E9482
		// (set) Token: 0x06027293 RID: 160403 RVA: 0x009EB2A1 File Offset: 0x009E94A1
		public TSoftObjectPtr<UTexture2D> 技能Icon
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B69 RID: 23401
		// (get) Token: 0x06027294 RID: 160404 RVA: 0x009EB2C8 File Offset: 0x009E94C8
		// (set) Token: 0x06027295 RID: 160405 RVA: 0x009EB30B File Offset: 0x009E950B
		public TMap<int, int> 升到该等级所消耗的物品
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._升到该等级所消耗的物品) == null)
				{
					result = (this._升到该等级所消耗的物品 = new TMap<int, int>(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.升到该等级所消耗的物品.CopyAssign(value);
			}
		}

		// Token: 0x17005B6A RID: 23402
		// (get) Token: 0x06027296 RID: 160406 RVA: 0x009EB31C File Offset: 0x009E951C
		// (set) Token: 0x06027297 RID: 160407 RVA: 0x009EB35F File Offset: 0x009E955F
		public TArray<int> 升级到该等级的条件Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._升级到该等级的条件Id) == null)
				{
					result = (this._升级到该等级的条件Id = new TArray<int>(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.升级到该等级的条件Id.CopyAssign(value);
			}
		}

		// Token: 0x17005B6B RID: 23403
		// (get) Token: 0x06027298 RID: 160408 RVA: 0x009EB36D File Offset: 0x009E956D
		// (set) Token: 0x06027299 RID: 160409 RVA: 0x009EB381 File Offset: 0x009E9581
		public unsafe FName 条件描述
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleSkillInfo.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0602729A RID: 160410 RVA: 0x009EB396 File Offset: 0x009E9596
		public SRoleSkillInfo()
		{
		}

		// Token: 0x0602729B RID: 160411 RVA: 0x009EB3A0 File Offset: 0x009E95A0
		public SRoleSkillInfo(FName 技能名称, int 技能组Id, int 技能Id, int 技能类型, int 技能等级, int 技能上限, bool 可升级标记, TArray<int> 技能等级效果Id列表, FName 技能效果描述, TMap<FName, FName> 详细描述, FName 新增效果描述, TSoftObjectPtr<UTexture2D> 技能Icon, TMap<int, int> 升到该等级所消耗的物品, TArray<int> 升级到该等级的条件Id, FName 条件描述)
		{
			this.技能名称 = 技能名称;
			this.技能组Id = 技能组Id;
			this.技能Id = 技能Id;
			this.技能类型 = 技能类型;
			this.技能等级 = 技能等级;
			this.技能上限 = 技能上限;
			this.可升级标记 = 可升级标记;
			this.技能等级效果Id列表 = 技能等级效果Id列表;
			this.技能效果描述 = 技能效果描述;
			this.详细描述 = 详细描述;
			this.新增效果描述 = 新增效果描述;
			this.技能Icon = 技能Icon;
			this.升到该等级所消耗的物品 = 升到该等级所消耗的物品;
			this.升级到该等级的条件Id = 升级到该等级的条件Id;
			this.条件描述 = 条件描述;
		}

		// Token: 0x0602729C RID: 160412 RVA: 0x009EB428 File Offset: 0x009E9628
		protected override IntPtr GetUStructPtr()
		{
			return SRoleSkillInfo.StaticStruct();
		}

		// Token: 0x0602729D RID: 160413 RVA: 0x009EB434 File Offset: 0x009E9634
		[NullableContext(2)]
		public SRoleSkillInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602729E RID: 160414 RVA: 0x009EB43E File Offset: 0x009E963E
		public SRoleSkillInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602729F RID: 160415 RVA: 0x009EB449 File Offset: 0x009E9649
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleSkillInfo(Pointer, false, true);
		}

		// Token: 0x060272A0 RID: 160416 RVA: 0x009EB453 File Offset: 0x009E9653
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleSkillInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014750 RID: 83792
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleSkillInfo.SRoleSkillInfo";

		// Token: 0x04014751 RID: 83793
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014752 RID: 83794
		internal static int __PropertyOffset_0;

		// Token: 0x04014753 RID: 83795
		internal static int __PropertyOffset_1;

		// Token: 0x04014754 RID: 83796
		internal static int __PropertyOffset_2;

		// Token: 0x04014755 RID: 83797
		internal static int __PropertyOffset_3;

		// Token: 0x04014756 RID: 83798
		internal static int __PropertyOffset_4;

		// Token: 0x04014757 RID: 83799
		internal static int __PropertyOffset_5;

		// Token: 0x04014758 RID: 83800
		internal static int __PropertyOffset_6;

		// Token: 0x04014759 RID: 83801
		internal static int __PropertyOffset_7;

		// Token: 0x0401475A RID: 83802
		[Nullable(2)]
		private TArray<int> _技能等级效果Id列表;

		// Token: 0x0401475B RID: 83803
		internal static int __PropertyOffset_8;

		// Token: 0x0401475C RID: 83804
		internal static int __PropertyOffset_9;

		// Token: 0x0401475D RID: 83805
		[Nullable(2)]
		private TMap<FName, FName> _详细描述;

		// Token: 0x0401475E RID: 83806
		internal static int __PropertyOffset_10;

		// Token: 0x0401475F RID: 83807
		internal static int __PropertyOffset_11;

		// Token: 0x04014760 RID: 83808
		internal static int __PropertyOffset_12;

		// Token: 0x04014761 RID: 83809
		[Nullable(2)]
		private TMap<int, int> _升到该等级所消耗的物品;

		// Token: 0x04014762 RID: 83810
		internal static int __PropertyOffset_13;

		// Token: 0x04014763 RID: 83811
		[Nullable(2)]
		private TArray<int> _升级到该等级的条件Id;

		// Token: 0x04014764 RID: 83812
		internal static int __PropertyOffset_14;
	}
}
