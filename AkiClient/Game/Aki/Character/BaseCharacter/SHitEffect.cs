using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004265 RID: 16997
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SHitEffect.SHitEffect")]
	[UnrealStructLayout(164, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 164)]
	public class SHitEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D0B9 RID: 184505 RVA: 0x00AB61A2 File Offset: 0x00AB43A2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHitEffect._ScriptStructPtr != 0) ? SHitEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SHitEffect.SHitEffect", ref SHitEffect._ScriptStructPtr);
		}

		// Token: 0x17007A40 RID: 31296
		// (get) Token: 0x0602D0BA RID: 184506 RVA: 0x00AB61C6 File Offset: 0x00AB43C6
		// (set) Token: 0x0602D0BB RID: 184507 RVA: 0x00AB61DA File Offset: 0x00AB43DA
		public unsafe TEnumAsByte<EHitAnim> 被击动作
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A41 RID: 31297
		// (get) Token: 0x0602D0BC RID: 184508 RVA: 0x00AB61EF File Offset: 0x00AB43EF
		// (set) Token: 0x0602D0BD RID: 184509 RVA: 0x00AB61FF File Offset: 0x00AB43FF
		public unsafe float 受击朝向Z轴偏转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A42 RID: 31298
		// (get) Token: 0x0602D0BE RID: 184510 RVA: 0x00AB6210 File Offset: 0x00AB4410
		// (set) Token: 0x0602D0BF RID: 184511 RVA: 0x00AB6224 File Offset: 0x00AB4424
		public unsafe FVector 空中受击速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A43 RID: 31299
		// (get) Token: 0x0602D0C0 RID: 184512 RVA: 0x00AB6239 File Offset: 0x00AB4439
		// (set) Token: 0x0602D0C1 RID: 184513 RVA: 0x00AB6249 File Offset: 0x00AB4449
		public unsafe float 空中受击移动时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A44 RID: 31300
		// (get) Token: 0x0602D0C2 RID: 184514 RVA: 0x00AB625A File Offset: 0x00AB445A
		// (set) Token: 0x0602D0C3 RID: 184515 RVA: 0x00AB626A File Offset: 0x00AB446A
		public unsafe float 命中硬直时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A45 RID: 31301
		// (get) Token: 0x0602D0C4 RID: 184516 RVA: 0x00AB627B File Offset: 0x00AB447B
		// (set) Token: 0x0602D0C5 RID: 184517 RVA: 0x00AB628F File Offset: 0x00AB448F
		public unsafe FVector 地面受击速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A46 RID: 31302
		// (get) Token: 0x0602D0C6 RID: 184518 RVA: 0x00AB62A4 File Offset: 0x00AB44A4
		// (set) Token: 0x0602D0C7 RID: 184519 RVA: 0x00AB62B4 File Offset: 0x00AB44B4
		public unsafe float 地面受击移动时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007A47 RID: 31303
		// (get) Token: 0x0602D0C8 RID: 184520 RVA: 0x00AB62C5 File Offset: 0x00AB44C5
		// (set) Token: 0x0602D0C9 RID: 184521 RVA: 0x00AB62D9 File Offset: 0x00AB44D9
		public unsafe TEnumAsByte<EVelocityCurveType> 地面受击移动曲线
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007A48 RID: 31304
		// (get) Token: 0x0602D0CA RID: 184522 RVA: 0x00AB62EE File Offset: 0x00AB44EE
		// (set) Token: 0x0602D0CB RID: 184523 RVA: 0x00AB62FE File Offset: 0x00AB44FE
		public unsafe float 地面受击最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007A49 RID: 31305
		// (get) Token: 0x0602D0CC RID: 184524 RVA: 0x00AB630F File Offset: 0x00AB450F
		// (set) Token: 0x0602D0CD RID: 184525 RVA: 0x00AB631F File Offset: 0x00AB451F
		public unsafe float 地面受击最小速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007A4A RID: 31306
		// (get) Token: 0x0602D0CE RID: 184526 RVA: 0x00AB6330 File Offset: 0x00AB4530
		// (set) Token: 0x0602D0CF RID: 184527 RVA: 0x00AB6340 File Offset: 0x00AB4540
		public unsafe float 速度阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007A4B RID: 31307
		// (get) Token: 0x0602D0D0 RID: 184528 RVA: 0x00AB6351 File Offset: 0x00AB4551
		// (set) Token: 0x0602D0D1 RID: 184529 RVA: 0x00AB6361 File Offset: 0x00AB4561
		public unsafe float 上升标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007A4C RID: 31308
		// (get) Token: 0x0602D0D2 RID: 184530 RVA: 0x00AB6372 File Offset: 0x00AB4572
		// (set) Token: 0x0602D0D3 RID: 184531 RVA: 0x00AB6382 File Offset: 0x00AB4582
		public unsafe float 弧顶标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007A4D RID: 31309
		// (get) Token: 0x0602D0D4 RID: 184532 RVA: 0x00AB6393 File Offset: 0x00AB4593
		// (set) Token: 0x0602D0D5 RID: 184533 RVA: 0x00AB63A3 File Offset: 0x00AB45A3
		public unsafe float 下落标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007A4E RID: 31310
		// (get) Token: 0x0602D0D6 RID: 184534 RVA: 0x00AB63B4 File Offset: 0x00AB45B4
		// (set) Token: 0x0602D0D7 RID: 184535 RVA: 0x00AB63C4 File Offset: 0x00AB45C4
		public unsafe bool 到达弧顶清除速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007A4F RID: 31311
		// (get) Token: 0x0602D0D8 RID: 184536 RVA: 0x00AB63D5 File Offset: 0x00AB45D5
		// (set) Token: 0x0602D0D9 RID: 184537 RVA: 0x00AB63E9 File Offset: 0x00AB45E9
		public unsafe FVector 落地反弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007A50 RID: 31312
		// (get) Token: 0x0602D0DA RID: 184538 RVA: 0x00AB63FE File Offset: 0x00AB45FE
		// (set) Token: 0x0602D0DB RID: 184539 RVA: 0x00AB640E File Offset: 0x00AB460E
		public unsafe float 落地反弹上升重力标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007A51 RID: 31313
		// (get) Token: 0x0602D0DC RID: 184540 RVA: 0x00AB641F File Offset: 0x00AB461F
		// (set) Token: 0x0602D0DD RID: 184541 RVA: 0x00AB642F File Offset: 0x00AB462F
		public unsafe float 落地反弹弧顶重力标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007A52 RID: 31314
		// (get) Token: 0x0602D0DE RID: 184542 RVA: 0x00AB6440 File Offset: 0x00AB4640
		// (set) Token: 0x0602D0DF RID: 184543 RVA: 0x00AB6450 File Offset: 0x00AB4650
		public unsafe float 落地反弹下落重力标量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007A53 RID: 31315
		// (get) Token: 0x0602D0E0 RID: 184544 RVA: 0x00AB6461 File Offset: 0x00AB4661
		// (set) Token: 0x0602D0E1 RID: 184545 RVA: 0x00AB6471 File Offset: 0x00AB4671
		public unsafe float 落地反弹速度阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007A54 RID: 31316
		// (get) Token: 0x0602D0E2 RID: 184546 RVA: 0x00AB6482 File Offset: 0x00AB4682
		// (set) Token: 0x0602D0E3 RID: 184547 RVA: 0x00AB6492 File Offset: 0x00AB4692
		public unsafe float 落地反弹时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007A55 RID: 31317
		// (get) Token: 0x0602D0E4 RID: 184548 RVA: 0x00AB64A4 File Offset: 0x00AB46A4
		// (set) Token: 0x0602D0E5 RID: 184549 RVA: 0x00AB64E7 File Offset: 0x00AB46E7
		[Nullable(1)]
		public SHitWhirlpool 地面受击滞空
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SHitWhirlpool result;
				if ((result = this._地面受击滞空) == null)
				{
					result = (this._地面受击滞空 = new SHitWhirlpool(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_21, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitWhirlpool.StaticStruct(), base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A56 RID: 31318
		// (get) Token: 0x0602D0E6 RID: 184550 RVA: 0x00AB6508 File Offset: 0x00AB4708
		// (set) Token: 0x0602D0E7 RID: 184551 RVA: 0x00AB654B File Offset: 0x00AB474B
		[Nullable(1)]
		public SHitWhirlpool 空中受击滞空
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SHitWhirlpool result;
				if ((result = this._空中受击滞空) == null)
				{
					result = (this._空中受击滞空 = new SHitWhirlpool(base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_22, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitWhirlpool.StaticStruct(), base.NativePtr + (IntPtr)SHitEffect.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D0E8 RID: 184552 RVA: 0x00AB656C File Offset: 0x00AB476C
		public SHitEffect()
		{
		}

		// Token: 0x0602D0E9 RID: 184553 RVA: 0x00AB6574 File Offset: 0x00AB4774
		public SHitEffect(TEnumAsByte<EHitAnim> 被击动作, float 受击朝向Z轴偏转, FVector 空中受击速度, float 空中受击移动时间, float 命中硬直时间, FVector 地面受击速度, float 地面受击移动时间, TEnumAsByte<EVelocityCurveType> 地面受击移动曲线, float 地面受击最大速度, float 地面受击最小速度, float 速度阈值, float 上升标量, float 弧顶标量, float 下落标量, bool 到达弧顶清除速度, FVector 落地反弹, float 落地反弹上升重力标量, float 落地反弹弧顶重力标量, float 落地反弹下落重力标量, float 落地反弹速度阈值, float 落地反弹时长, [Nullable(1)] SHitWhirlpool 地面受击滞空, [Nullable(1)] SHitWhirlpool 空中受击滞空)
		{
			this.被击动作 = 被击动作;
			this.受击朝向Z轴偏转 = 受击朝向Z轴偏转;
			this.空中受击速度 = 空中受击速度;
			this.空中受击移动时间 = 空中受击移动时间;
			this.命中硬直时间 = 命中硬直时间;
			this.地面受击速度 = 地面受击速度;
			this.地面受击移动时间 = 地面受击移动时间;
			this.地面受击移动曲线 = 地面受击移动曲线;
			this.地面受击最大速度 = 地面受击最大速度;
			this.地面受击最小速度 = 地面受击最小速度;
			this.速度阈值 = 速度阈值;
			this.上升标量 = 上升标量;
			this.弧顶标量 = 弧顶标量;
			this.下落标量 = 下落标量;
			this.到达弧顶清除速度 = 到达弧顶清除速度;
			this.落地反弹 = 落地反弹;
			this.落地反弹上升重力标量 = 落地反弹上升重力标量;
			this.落地反弹弧顶重力标量 = 落地反弹弧顶重力标量;
			this.落地反弹下落重力标量 = 落地反弹下落重力标量;
			this.落地反弹速度阈值 = 落地反弹速度阈值;
			this.落地反弹时长 = 落地反弹时长;
			this.地面受击滞空 = 地面受击滞空;
			this.空中受击滞空 = 空中受击滞空;
		}

		// Token: 0x0602D0EA RID: 184554 RVA: 0x00AB663C File Offset: 0x00AB483C
		protected override IntPtr GetUStructPtr()
		{
			return SHitEffect.StaticStruct();
		}

		// Token: 0x0602D0EB RID: 184555 RVA: 0x00AB6648 File Offset: 0x00AB4848
		[NullableContext(2)]
		public SHitEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D0EC RID: 184556 RVA: 0x00AB6652 File Offset: 0x00AB4852
		public SHitEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D0ED RID: 184557 RVA: 0x00AB665D File Offset: 0x00AB485D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHitEffect(Pointer, false, true);
		}

		// Token: 0x0602D0EE RID: 184558 RVA: 0x00AB6667 File Offset: 0x00AB4867
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHitEffect(Pointer, MemoryOwner);
		}

		// Token: 0x0401942C RID: 103468
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SHitEffect.SHitEffect";

		// Token: 0x0401942D RID: 103469
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401942E RID: 103470
		internal static int __PropertyOffset_0;

		// Token: 0x0401942F RID: 103471
		internal static int __PropertyOffset_1;

		// Token: 0x04019430 RID: 103472
		internal static int __PropertyOffset_2;

		// Token: 0x04019431 RID: 103473
		internal static int __PropertyOffset_3;

		// Token: 0x04019432 RID: 103474
		internal static int __PropertyOffset_4;

		// Token: 0x04019433 RID: 103475
		internal static int __PropertyOffset_5;

		// Token: 0x04019434 RID: 103476
		internal static int __PropertyOffset_6;

		// Token: 0x04019435 RID: 103477
		internal static int __PropertyOffset_7;

		// Token: 0x04019436 RID: 103478
		internal static int __PropertyOffset_8;

		// Token: 0x04019437 RID: 103479
		internal static int __PropertyOffset_9;

		// Token: 0x04019438 RID: 103480
		internal static int __PropertyOffset_10;

		// Token: 0x04019439 RID: 103481
		internal static int __PropertyOffset_11;

		// Token: 0x0401943A RID: 103482
		internal static int __PropertyOffset_12;

		// Token: 0x0401943B RID: 103483
		internal static int __PropertyOffset_13;

		// Token: 0x0401943C RID: 103484
		internal static int __PropertyOffset_14;

		// Token: 0x0401943D RID: 103485
		internal static int __PropertyOffset_15;

		// Token: 0x0401943E RID: 103486
		internal static int __PropertyOffset_16;

		// Token: 0x0401943F RID: 103487
		internal static int __PropertyOffset_17;

		// Token: 0x04019440 RID: 103488
		internal static int __PropertyOffset_18;

		// Token: 0x04019441 RID: 103489
		internal static int __PropertyOffset_19;

		// Token: 0x04019442 RID: 103490
		internal static int __PropertyOffset_20;

		// Token: 0x04019443 RID: 103491
		internal static int __PropertyOffset_21;

		// Token: 0x04019444 RID: 103492
		[Nullable(2)]
		private SHitWhirlpool _地面受击滞空;

		// Token: 0x04019445 RID: 103493
		internal static int __PropertyOffset_22;

		// Token: 0x04019446 RID: 103494
		[Nullable(2)]
		private SHitWhirlpool _空中受击滞空;
	}
}
