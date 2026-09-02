using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0A RID: 15882
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleGrowthInfo.SRoleGrowthInfo")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SRoleGrowthInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027229 RID: 160297 RVA: 0x009EA918 File Offset: 0x009E8B18
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleGrowthInfo._ScriptStructPtr != 0) ? SRoleGrowthInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleGrowthInfo.SRoleGrowthInfo", ref SRoleGrowthInfo._ScriptStructPtr);
		}

		// Token: 0x17005B44 RID: 23364
		// (get) Token: 0x0602722A RID: 160298 RVA: 0x009EA93C File Offset: 0x009E8B3C
		// (set) Token: 0x0602722B RID: 160299 RVA: 0x009EA94C File Offset: 0x009E8B4C
		public unsafe int 增幅组Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B45 RID: 23365
		// (get) Token: 0x0602722C RID: 160300 RVA: 0x009EA95D File Offset: 0x009E8B5D
		// (set) Token: 0x0602722D RID: 160301 RVA: 0x009EA971 File Offset: 0x009E8B71
		public unsafe FName 增幅名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B46 RID: 23366
		// (get) Token: 0x0602722E RID: 160302 RVA: 0x009EA986 File Offset: 0x009E8B86
		// (set) Token: 0x0602722F RID: 160303 RVA: 0x009EA996 File Offset: 0x009E8B96
		public unsafe int 增幅等级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005B47 RID: 23367
		// (get) Token: 0x06027230 RID: 160304 RVA: 0x009EA9A8 File Offset: 0x009E8BA8
		// (set) Token: 0x06027231 RID: 160305 RVA: 0x009EA9EB File Offset: 0x009E8BEB
		public TArray<int> 增幅效果Id列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._增幅效果Id列表) == null)
				{
					result = (this._增幅效果Id列表 = new TArray<int>(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.增幅效果Id列表.CopyAssign(value);
			}
		}

		// Token: 0x17005B48 RID: 23368
		// (get) Token: 0x06027232 RID: 160306 RVA: 0x009EA9F9 File Offset: 0x009E8BF9
		// (set) Token: 0x06027233 RID: 160307 RVA: 0x009EAA0D File Offset: 0x009E8C0D
		public unsafe FName 增幅效果描述
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005B49 RID: 23369
		// (get) Token: 0x06027234 RID: 160308 RVA: 0x009EAA22 File Offset: 0x009E8C22
		// (set) Token: 0x06027235 RID: 160309 RVA: 0x009EAA32 File Offset: 0x009E8C32
		public unsafe int 增幅消耗Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleGrowthInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06027236 RID: 160310 RVA: 0x009EAA43 File Offset: 0x009E8C43
		public SRoleGrowthInfo()
		{
		}

		// Token: 0x06027237 RID: 160311 RVA: 0x009EAA4B File Offset: 0x009E8C4B
		public SRoleGrowthInfo(int 增幅组Id, FName 增幅名称, int 增幅等级, TArray<int> 增幅效果Id列表, FName 增幅效果描述, int 增幅消耗Id)
		{
			this.增幅组Id = 增幅组Id;
			this.增幅名称 = 增幅名称;
			this.增幅等级 = 增幅等级;
			this.增幅效果Id列表 = 增幅效果Id列表;
			this.增幅效果描述 = 增幅效果描述;
			this.增幅消耗Id = 增幅消耗Id;
		}

		// Token: 0x06027238 RID: 160312 RVA: 0x009EAA80 File Offset: 0x009E8C80
		protected override IntPtr GetUStructPtr()
		{
			return SRoleGrowthInfo.StaticStruct();
		}

		// Token: 0x06027239 RID: 160313 RVA: 0x009EAA8C File Offset: 0x009E8C8C
		[NullableContext(2)]
		public SRoleGrowthInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602723A RID: 160314 RVA: 0x009EAA96 File Offset: 0x009E8C96
		public SRoleGrowthInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602723B RID: 160315 RVA: 0x009EAAA1 File Offset: 0x009E8CA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleGrowthInfo(Pointer, false, true);
		}

		// Token: 0x0602723C RID: 160316 RVA: 0x009EAAAB File Offset: 0x009E8CAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleGrowthInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401472C RID: 83756
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleGrowthInfo.SRoleGrowthInfo";

		// Token: 0x0401472D RID: 83757
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401472E RID: 83758
		internal static int __PropertyOffset_0;

		// Token: 0x0401472F RID: 83759
		internal static int __PropertyOffset_1;

		// Token: 0x04014730 RID: 83760
		internal static int __PropertyOffset_2;

		// Token: 0x04014731 RID: 83761
		internal static int __PropertyOffset_3;

		// Token: 0x04014732 RID: 83762
		[Nullable(2)]
		private TArray<int> _增幅效果Id列表;

		// Token: 0x04014733 RID: 83763
		internal static int __PropertyOffset_4;

		// Token: 0x04014734 RID: 83764
		internal static int __PropertyOffset_5;
	}
}
