using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Vision
{
	// Token: 0x02003F8C RID: 16268
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vision/SVisionData.SVisionData")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 145)]
	public class SVisionData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028B34 RID: 166708 RVA: 0x00A133C8 File Offset: 0x00A115C8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SVisionData._ScriptStructPtr != 0) ? SVisionData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Vision/SVisionData.SVisionData", ref SVisionData._ScriptStructPtr);
		}

		// Token: 0x17006388 RID: 25480
		// (get) Token: 0x06028B35 RID: 166709 RVA: 0x00A133EC File Offset: 0x00A115EC
		// (set) Token: 0x06028B36 RID: 166710 RVA: 0x00A133FC File Offset: 0x00A115FC
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006389 RID: 25481
		// (get) Token: 0x06028B37 RID: 166711 RVA: 0x00A1340D File Offset: 0x00A1160D
		// (set) Token: 0x06028B38 RID: 166712 RVA: 0x00A13421 File Offset: 0x00A11621
		public unsafe string 说明
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVisionData.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVisionData.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x1700638A RID: 25482
		// (get) Token: 0x06028B39 RID: 166713 RVA: 0x00A13436 File Offset: 0x00A11636
		// (set) Token: 0x06028B3A RID: 166714 RVA: 0x00A13446 File Offset: 0x00A11646
		public unsafe int 实体配置表Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700638B RID: 25483
		// (get) Token: 0x06028B3B RID: 166715 RVA: 0x00A13457 File Offset: 0x00A11657
		// (set) Token: 0x06028B3C RID: 166716 RVA: 0x00A1346B File Offset: 0x00A1166B
		[Nullable(0)]
		public unsafe TEnumAsByte<EVisionType> 类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700638C RID: 25484
		// (get) Token: 0x06028B3D RID: 166717 RVA: 0x00A13480 File Offset: 0x00A11680
		// (set) Token: 0x06028B3E RID: 166718 RVA: 0x00A13490 File Offset: 0x00A11690
		public unsafe int 技能ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700638D RID: 25485
		// (get) Token: 0x06028B3F RID: 166719 RVA: 0x00A134A1 File Offset: 0x00A116A1
		// (set) Token: 0x06028B40 RID: 166720 RVA: 0x00A134B1 File Offset: 0x00A116B1
		public unsafe bool 空中能否释放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700638E RID: 25486
		// (get) Token: 0x06028B41 RID: 166721 RVA: 0x00A134C2 File Offset: 0x00A116C2
		// (set) Token: 0x06028B42 RID: 166722 RVA: 0x00A134D2 File Offset: 0x00A116D2
		public unsafe bool 出生隐藏
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700638F RID: 25487
		// (get) Token: 0x06028B43 RID: 166723 RVA: 0x00A134E4 File Offset: 0x00A116E4
		// (set) Token: 0x06028B44 RID: 166724 RVA: 0x00A13527 File Offset: 0x00A11727
		public TArray<long> 葫芦轨迹子弹列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._葫芦轨迹子弹列表) == null)
				{
					result = (this._葫芦轨迹子弹列表 = new TArray<long>(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.葫芦轨迹子弹列表.CopyAssign(value);
			}
		}

		// Token: 0x17006390 RID: 25488
		// (get) Token: 0x06028B45 RID: 166725 RVA: 0x00A13535 File Offset: 0x00A11735
		// (set) Token: 0x06028B46 RID: 166726 RVA: 0x00A13545 File Offset: 0x00A11745
		public unsafe bool 战时是否播放出生动画
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006391 RID: 25489
		// (get) Token: 0x06028B47 RID: 166727 RVA: 0x00A13558 File Offset: 0x00A11758
		// (set) Token: 0x06028B48 RID: 166728 RVA: 0x00A1359B File Offset: 0x00A1179B
		public TArray<FGameplayTagContainer> 生命中Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTagContainer> result;
				if ((result = this._生命中Tag) == null)
				{
					result = (this._生命中Tag = new TArray<FGameplayTagContainer>(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.生命中Tag.CopyAssign(value);
			}
		}

		// Token: 0x17006392 RID: 25490
		// (get) Token: 0x06028B49 RID: 166729 RVA: 0x00A135AC File Offset: 0x00A117AC
		// (set) Token: 0x06028B4A RID: 166730 RVA: 0x00A135EF File Offset: 0x00A117EF
		public TArray<int> 出生Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._出生Buff) == null)
				{
					result = (this._出生Buff = new TArray<int>(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.出生Buff.CopyAssign(value);
			}
		}

		// Token: 0x17006393 RID: 25491
		// (get) Token: 0x06028B4B RID: 166731 RVA: 0x00A13600 File Offset: 0x00A11800
		// (set) Token: 0x06028B4C RID: 166732 RVA: 0x00A13643 File Offset: 0x00A11843
		public TArray<int> 出生时给召唤者Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._出生时给召唤者Buff) == null)
				{
					result = (this._出生时给召唤者Buff = new TArray<int>(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.出生时给召唤者Buff.CopyAssign(value);
			}
		}

		// Token: 0x17006394 RID: 25492
		// (get) Token: 0x06028B4D RID: 166733 RVA: 0x00A13651 File Offset: 0x00A11851
		// (set) Token: 0x06028B4E RID: 166734 RVA: 0x00A13665 File Offset: 0x00A11865
		public unsafe FName 出生施放主动技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006395 RID: 25493
		// (get) Token: 0x06028B4F RID: 166735 RVA: 0x00A1367C File Offset: 0x00A1187C
		// (set) Token: 0x06028B50 RID: 166736 RVA: 0x00A136BF File Offset: 0x00A118BF
		public TArray<FGameplayTag> 同步Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._同步Tags) == null)
				{
					result = (this._同步Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.同步Tags.CopyAssign(value);
			}
		}

		// Token: 0x17006396 RID: 25494
		// (get) Token: 0x06028B51 RID: 166737 RVA: 0x00A136CD File Offset: 0x00A118CD
		// (set) Token: 0x06028B52 RID: 166738 RVA: 0x00A136DD File Offset: 0x00A118DD
		public unsafe bool buff是否转移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionData.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028B53 RID: 166739 RVA: 0x00A136EE File Offset: 0x00A118EE
		public SVisionData()
		{
		}

		// Token: 0x06028B54 RID: 166740 RVA: 0x00A136F8 File Offset: 0x00A118F8
		public SVisionData(int Id, string 说明, int 实体配置表Id, [Nullable(0)] TEnumAsByte<EVisionType> 类型, int 技能ID, bool 空中能否释放, bool 出生隐藏, TArray<long> 葫芦轨迹子弹列表, bool 战时是否播放出生动画, TArray<FGameplayTagContainer> 生命中Tag, TArray<int> 出生Buff, TArray<int> 出生时给召唤者Buff, FName 出生施放主动技能, TArray<FGameplayTag> 同步Tags, bool buff是否转移)
		{
			this.Id = Id;
			this.说明 = 说明;
			this.实体配置表Id = 实体配置表Id;
			this.类型 = 类型;
			this.技能ID = 技能ID;
			this.空中能否释放 = 空中能否释放;
			this.出生隐藏 = 出生隐藏;
			this.葫芦轨迹子弹列表 = 葫芦轨迹子弹列表;
			this.战时是否播放出生动画 = 战时是否播放出生动画;
			this.生命中Tag = 生命中Tag;
			this.出生Buff = 出生Buff;
			this.出生时给召唤者Buff = 出生时给召唤者Buff;
			this.出生施放主动技能 = 出生施放主动技能;
			this.同步Tags = 同步Tags;
			this.buff是否转移 = buff是否转移;
		}

		// Token: 0x06028B55 RID: 166741 RVA: 0x00A13780 File Offset: 0x00A11980
		protected override IntPtr GetUStructPtr()
		{
			return SVisionData.StaticStruct();
		}

		// Token: 0x06028B56 RID: 166742 RVA: 0x00A1378C File Offset: 0x00A1198C
		[NullableContext(2)]
		public SVisionData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028B57 RID: 166743 RVA: 0x00A13796 File Offset: 0x00A11996
		public SVisionData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028B58 RID: 166744 RVA: 0x00A137A1 File Offset: 0x00A119A1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SVisionData(Pointer, false, true);
		}

		// Token: 0x06028B59 RID: 166745 RVA: 0x00A137AB File Offset: 0x00A119AB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SVisionData(Pointer, MemoryOwner);
		}

		// Token: 0x040157AF RID: 87983
		public const string __ObjectPath = "/Game/Aki/Character/Vision/SVisionData.SVisionData";

		// Token: 0x040157B0 RID: 87984
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040157B1 RID: 87985
		internal static int __PropertyOffset_0;

		// Token: 0x040157B2 RID: 87986
		internal static int __PropertyOffset_1;

		// Token: 0x040157B3 RID: 87987
		internal static int __PropertyOffset_2;

		// Token: 0x040157B4 RID: 87988
		internal static int __PropertyOffset_3;

		// Token: 0x040157B5 RID: 87989
		internal static int __PropertyOffset_4;

		// Token: 0x040157B6 RID: 87990
		internal static int __PropertyOffset_5;

		// Token: 0x040157B7 RID: 87991
		internal static int __PropertyOffset_6;

		// Token: 0x040157B8 RID: 87992
		internal static int __PropertyOffset_7;

		// Token: 0x040157B9 RID: 87993
		[Nullable(2)]
		private TArray<long> _葫芦轨迹子弹列表;

		// Token: 0x040157BA RID: 87994
		internal static int __PropertyOffset_8;

		// Token: 0x040157BB RID: 87995
		internal static int __PropertyOffset_9;

		// Token: 0x040157BC RID: 87996
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FGameplayTagContainer> _生命中Tag;

		// Token: 0x040157BD RID: 87997
		internal static int __PropertyOffset_10;

		// Token: 0x040157BE RID: 87998
		[Nullable(2)]
		private TArray<int> _出生Buff;

		// Token: 0x040157BF RID: 87999
		internal static int __PropertyOffset_11;

		// Token: 0x040157C0 RID: 88000
		[Nullable(2)]
		private TArray<int> _出生时给召唤者Buff;

		// Token: 0x040157C1 RID: 88001
		internal static int __PropertyOffset_12;

		// Token: 0x040157C2 RID: 88002
		internal static int __PropertyOffset_13;

		// Token: 0x040157C3 RID: 88003
		[Nullable(2)]
		private TArray<FGameplayTag> _同步Tags;

		// Token: 0x040157C4 RID: 88004
		internal static int __PropertyOffset_14;
	}
}
