using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004266 RID: 16998
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SHitInformation.SHitInformation")]
	[UnrealStructLayout(2272, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 2272)]
	public class SHitInformation : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D0EF RID: 184559 RVA: 0x00AB6670 File Offset: 0x00AB4870
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHitInformation._ScriptStructPtr != 0) ? SHitInformation._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SHitInformation.SHitInformation", ref SHitInformation._ScriptStructPtr);
		}

		// Token: 0x17007A57 RID: 31319
		// (get) Token: 0x0602D0F0 RID: 184560 RVA: 0x00AB6694 File Offset: 0x00AB4894
		// (set) Token: 0x0602D0F1 RID: 184561 RVA: 0x00AB66A8 File Offset: 0x00AB48A8
		[Nullable(2)]
		public unsafe TsBaseCharacter 攻击者
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007A58 RID: 31320
		// (get) Token: 0x0602D0F2 RID: 184562 RVA: 0x00AB66BD File Offset: 0x00AB48BD
		// (set) Token: 0x0602D0F3 RID: 184563 RVA: 0x00AB66D1 File Offset: 0x00AB48D1
		[Nullable(2)]
		public unsafe TsBaseCharacter 受击者
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007A59 RID: 31321
		// (get) Token: 0x0602D0F4 RID: 184564 RVA: 0x00AB66E8 File Offset: 0x00AB48E8
		// (set) Token: 0x0602D0F5 RID: 184565 RVA: 0x00AB672B File Offset: 0x00AB492B
		public SHitEffect 被击效果
		{
			get
			{
				base.FastCheckIsValid();
				SHitEffect result;
				if ((result = this._被击效果) == null)
				{
					result = (this._被击效果 = new SHitEffect(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitEffect.StaticStruct(), base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A5A RID: 31322
		// (get) Token: 0x0602D0F6 RID: 184566 RVA: 0x00AB674C File Offset: 0x00AB494C
		// (set) Token: 0x0602D0F7 RID: 184567 RVA: 0x00AB675C File Offset: 0x00AB495C
		public unsafe int 子弹ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A5B RID: 31323
		// (get) Token: 0x0602D0F8 RID: 184568 RVA: 0x00AB676D File Offset: 0x00AB496D
		// (set) Token: 0x0602D0F9 RID: 184569 RVA: 0x00AB6781 File Offset: 0x00AB4981
		public unsafe FVector 受击特效位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A5C RID: 31324
		// (get) Token: 0x0602D0FA RID: 184570 RVA: 0x00AB6796 File Offset: 0x00AB4996
		// (set) Token: 0x0602D0FB RID: 184571 RVA: 0x00AB67AA File Offset: 0x00AB49AA
		public unsafe FRotator 受击特效旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A5D RID: 31325
		// (get) Token: 0x0602D0FC RID: 184572 RVA: 0x00AB67BF File Offset: 0x00AB49BF
		// (set) Token: 0x0602D0FD RID: 184573 RVA: 0x00AB67CF File Offset: 0x00AB49CF
		public unsafe bool 是否震动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007A5E RID: 31326
		// (get) Token: 0x0602D0FE RID: 184574 RVA: 0x00AB67E0 File Offset: 0x00AB49E0
		// (set) Token: 0x0602D0FF RID: 184575 RVA: 0x00AB67F4 File Offset: 0x00AB49F4
		public unsafe FName 受击部位
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007A5F RID: 31327
		// (get) Token: 0x0602D100 RID: 184576 RVA: 0x00AB6809 File Offset: 0x00AB4A09
		// (set) Token: 0x0602D101 RID: 184577 RVA: 0x00AB681D File Offset: 0x00AB4A1D
		public unsafe FVector 受击位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007A60 RID: 31328
		// (get) Token: 0x0602D102 RID: 184578 RVA: 0x00AB6832 File Offset: 0x00AB4A32
		// (set) Token: 0x0602D103 RID: 184579 RVA: 0x00AB6842 File Offset: 0x00AB4A42
		public unsafe int 技能等级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007A61 RID: 31329
		// (get) Token: 0x0602D104 RID: 184580 RVA: 0x00AB6854 File Offset: 0x00AB4A54
		// (set) Token: 0x0602D105 RID: 184581 RVA: 0x00AB6897 File Offset: 0x00AB4A97
		public SReBulletDataMain 重构子弹数据
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataMain result;
				if ((result = this._重构子弹数据) == null)
				{
					result = (this._重构子弹数据 = new SReBulletDataMain(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMain.StaticStruct(), base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A62 RID: 31330
		// (get) Token: 0x0602D106 RID: 184582 RVA: 0x00AB68B8 File Offset: 0x00AB4AB8
		// (set) Token: 0x0602D107 RID: 184583 RVA: 0x00AB68CC File Offset: 0x00AB4ACC
		[Nullable(2)]
		public unsafe BulletLogicType_C 子弹逻辑预设
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BulletLogicType_C>(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHitInformation.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17007A63 RID: 31331
		// (get) Token: 0x0602D108 RID: 184584 RVA: 0x00AB68E1 File Offset: 0x00AB4AE1
		// (set) Token: 0x0602D109 RID: 184585 RVA: 0x00AB68F5 File Offset: 0x00AB4AF5
		public unsafe string 子弹表ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SHitInformation.__PropertyOffset_12)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SHitInformation.__PropertyOffset_12)), value);
			}
		}

		// Token: 0x17007A64 RID: 31332
		// (get) Token: 0x0602D10A RID: 184586 RVA: 0x00AB690A File Offset: 0x00AB4B0A
		// (set) Token: 0x0602D10B RID: 184587 RVA: 0x00AB691A File Offset: 0x00AB4B1A
		public unsafe int 伤害类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007A65 RID: 31333
		// (get) Token: 0x0602D10C RID: 184588 RVA: 0x00AB692B File Offset: 0x00AB4B2B
		// (set) Token: 0x0602D10D RID: 184589 RVA: 0x00AB693B File Offset: 0x00AB4B3B
		public unsafe long 伤害ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitInformation.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0602D10E RID: 184590 RVA: 0x00AB694C File Offset: 0x00AB4B4C
		public SHitInformation()
		{
		}

		// Token: 0x0602D10F RID: 184591 RVA: 0x00AB6954 File Offset: 0x00AB4B54
		public SHitInformation(TsBaseCharacter 攻击者, TsBaseCharacter 受击者, SHitEffect 被击效果, int 子弹ID, FVector 受击特效位置, FRotator 受击特效旋转, bool 是否震动, FName 受击部位, FVector 受击位置, int 技能等级, SReBulletDataMain 重构子弹数据, BulletLogicType_C 子弹逻辑预设, string 子弹表ID, int 伤害类型, long 伤害ID)
		{
			this.攻击者 = 攻击者;
			this.受击者 = 受击者;
			this.被击效果 = 被击效果;
			this.子弹ID = 子弹ID;
			this.受击特效位置 = 受击特效位置;
			this.受击特效旋转 = 受击特效旋转;
			this.是否震动 = 是否震动;
			this.受击部位 = 受击部位;
			this.受击位置 = 受击位置;
			this.技能等级 = 技能等级;
			this.重构子弹数据 = 重构子弹数据;
			this.子弹逻辑预设 = 子弹逻辑预设;
			this.子弹表ID = 子弹表ID;
			this.伤害类型 = 伤害类型;
			this.伤害ID = 伤害ID;
		}

		// Token: 0x0602D110 RID: 184592 RVA: 0x00AB69DC File Offset: 0x00AB4BDC
		protected override IntPtr GetUStructPtr()
		{
			return SHitInformation.StaticStruct();
		}

		// Token: 0x0602D111 RID: 184593 RVA: 0x00AB69E8 File Offset: 0x00AB4BE8
		[NullableContext(2)]
		public SHitInformation(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D112 RID: 184594 RVA: 0x00AB69F2 File Offset: 0x00AB4BF2
		public SHitInformation(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D113 RID: 184595 RVA: 0x00AB69FD File Offset: 0x00AB4BFD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHitInformation(Pointer, false, true);
		}

		// Token: 0x0602D114 RID: 184596 RVA: 0x00AB6A07 File Offset: 0x00AB4C07
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHitInformation(Pointer, MemoryOwner);
		}

		// Token: 0x04019447 RID: 103495
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SHitInformation.SHitInformation";

		// Token: 0x04019448 RID: 103496
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019449 RID: 103497
		internal static int __PropertyOffset_0;

		// Token: 0x0401944A RID: 103498
		internal static int __PropertyOffset_1;

		// Token: 0x0401944B RID: 103499
		internal static int __PropertyOffset_2;

		// Token: 0x0401944C RID: 103500
		[Nullable(2)]
		private SHitEffect _被击效果;

		// Token: 0x0401944D RID: 103501
		internal static int __PropertyOffset_3;

		// Token: 0x0401944E RID: 103502
		internal static int __PropertyOffset_4;

		// Token: 0x0401944F RID: 103503
		internal static int __PropertyOffset_5;

		// Token: 0x04019450 RID: 103504
		internal static int __PropertyOffset_6;

		// Token: 0x04019451 RID: 103505
		internal static int __PropertyOffset_7;

		// Token: 0x04019452 RID: 103506
		internal static int __PropertyOffset_8;

		// Token: 0x04019453 RID: 103507
		internal static int __PropertyOffset_9;

		// Token: 0x04019454 RID: 103508
		internal static int __PropertyOffset_10;

		// Token: 0x04019455 RID: 103509
		[Nullable(2)]
		private SReBulletDataMain _重构子弹数据;

		// Token: 0x04019456 RID: 103510
		internal static int __PropertyOffset_11;

		// Token: 0x04019457 RID: 103511
		internal static int __PropertyOffset_12;

		// Token: 0x04019458 RID: 103512
		internal static int __PropertyOffset_13;

		// Token: 0x04019459 RID: 103513
		internal static int __PropertyOffset_14;
	}
}
