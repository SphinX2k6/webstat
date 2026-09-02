using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424F RID: 16975
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCounterAttack.SCounterAttack")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1149)]
	public class SCounterAttack : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CF45 RID: 184133 RVA: 0x00AB40DA File Offset: 0x00AB22DA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCounterAttack._ScriptStructPtr != 0) ? SCounterAttack._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCounterAttack.SCounterAttack", ref SCounterAttack._ScriptStructPtr);
		}

		// Token: 0x170079DC RID: 31196
		// (get) Token: 0x0602CF46 RID: 184134 RVA: 0x00AB4100 File Offset: 0x00AB2300
		// (set) Token: 0x0602CF47 RID: 184135 RVA: 0x00AB4143 File Offset: 0x00AB2343
		public TArray<FName> 弹反部位
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._弹反部位) == null)
				{
					result = (this._弹反部位 = new TArray<FName>(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.弹反部位.CopyAssign(value);
			}
		}

		// Token: 0x170079DD RID: 31197
		// (get) Token: 0x0602CF48 RID: 184136 RVA: 0x00AB4154 File Offset: 0x00AB2354
		// (set) Token: 0x0602CF49 RID: 184137 RVA: 0x00AB4197 File Offset: 0x00AB2397
		public SCounterAttackEffect 无弹反动作效果
		{
			get
			{
				base.FastCheckIsValid();
				SCounterAttackEffect result;
				if ((result = this._无弹反动作效果) == null)
				{
					result = (this._无弹反动作效果 = new SCounterAttackEffect(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCounterAttackEffect.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079DE RID: 31198
		// (get) Token: 0x0602CF4A RID: 184138 RVA: 0x00AB41B8 File Offset: 0x00AB23B8
		// (set) Token: 0x0602CF4B RID: 184139 RVA: 0x00AB41FB File Offset: 0x00AB23FB
		public SCounterAttackEffect 有弹反动作效果
		{
			get
			{
				base.FastCheckIsValid();
				SCounterAttackEffect result;
				if ((result = this._有弹反动作效果) == null)
				{
					result = (this._有弹反动作效果 = new SCounterAttackEffect(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCounterAttackEffect.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079DF RID: 31199
		// (get) Token: 0x0602CF4C RID: 184140 RVA: 0x00AB421C File Offset: 0x00AB241C
		// (set) Token: 0x0602CF4D RID: 184141 RVA: 0x00AB422C File Offset: 0x00AB242C
		public unsafe float 削韧倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170079E0 RID: 31200
		// (get) Token: 0x0602CF4E RID: 184142 RVA: 0x00AB423D File Offset: 0x00AB243D
		// (set) Token: 0x0602CF4F RID: 184143 RVA: 0x00AB424D File Offset: 0x00AB244D
		public unsafe float 最大触发距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170079E1 RID: 31201
		// (get) Token: 0x0602CF50 RID: 184144 RVA: 0x00AB425E File Offset: 0x00AB245E
		// (set) Token: 0x0602CF51 RID: 184145 RVA: 0x00AB426E File Offset: 0x00AB246E
		public unsafe float 最大触发夹角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170079E2 RID: 31202
		// (get) Token: 0x0602CF52 RID: 184146 RVA: 0x00AB427F File Offset: 0x00AB247F
		// (set) Token: 0x0602CF53 RID: 184147 RVA: 0x00AB428F File Offset: 0x00AB248F
		public unsafe long 被弹反者应用BuffID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170079E3 RID: 31203
		// (get) Token: 0x0602CF54 RID: 184148 RVA: 0x00AB42A0 File Offset: 0x00AB24A0
		// (set) Token: 0x0602CF55 RID: 184149 RVA: 0x00AB42B0 File Offset: 0x00AB24B0
		public unsafe long 攻击者应用BuffID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170079E4 RID: 31204
		// (get) Token: 0x0602CF56 RID: 184150 RVA: 0x00AB42C1 File Offset: 0x00AB24C1
		// (set) Token: 0x0602CF57 RID: 184151 RVA: 0x00AB42D1 File Offset: 0x00AB24D1
		public unsafe bool 受击动画忽略Buff检测
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079E5 RID: 31205
		// (get) Token: 0x0602CF58 RID: 184152 RVA: 0x00AB42E4 File Offset: 0x00AB24E4
		// (set) Token: 0x0602CF59 RID: 184153 RVA: 0x00AB4327 File Offset: 0x00AB2527
		public TArray<SCounterAttackBuff> 检测Buff列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCounterAttackBuff> result;
				if ((result = this._检测Buff列表) == null)
				{
					result = (this._检测Buff列表 = new TArray<SCounterAttackBuff>(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.检测Buff列表.CopyAssign(value);
			}
		}

		// Token: 0x170079E6 RID: 31206
		// (get) Token: 0x0602CF5A RID: 184154 RVA: 0x00AB4335 File Offset: 0x00AB2535
		// (set) Token: 0x0602CF5B RID: 184155 RVA: 0x00AB4345 File Offset: 0x00AB2545
		public unsafe long ANS期间被弹反者生效的BuffID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170079E7 RID: 31207
		// (get) Token: 0x0602CF5C RID: 184156 RVA: 0x00AB4356 File Offset: 0x00AB2556
		// (set) Token: 0x0602CF5D RID: 184157 RVA: 0x00AB436A File Offset: 0x00AB256A
		public unsafe FGameplayTag 结束事件Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170079E8 RID: 31208
		// (get) Token: 0x0602CF5E RID: 184158 RVA: 0x00AB437F File Offset: 0x00AB257F
		// (set) Token: 0x0602CF5F RID: 184159 RVA: 0x00AB438F File Offset: 0x00AB258F
		public unsafe bool QTE弹刀忽略角度距离检测
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttack.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CF60 RID: 184160 RVA: 0x00AB43A0 File Offset: 0x00AB25A0
		public SCounterAttack()
		{
		}

		// Token: 0x0602CF61 RID: 184161 RVA: 0x00AB43A8 File Offset: 0x00AB25A8
		public SCounterAttack(TArray<FName> 弹反部位, SCounterAttackEffect 无弹反动作效果, SCounterAttackEffect 有弹反动作效果, float 削韧倍率, float 最大触发距离, float 最大触发夹角, long 被弹反者应用BuffID, long 攻击者应用BuffID, bool 受击动画忽略Buff检测, TArray<SCounterAttackBuff> 检测Buff列表, long ANS期间被弹反者生效的BuffID, FGameplayTag 结束事件Tag, bool QTE弹刀忽略角度距离检测)
		{
			this.弹反部位 = 弹反部位;
			this.无弹反动作效果 = 无弹反动作效果;
			this.有弹反动作效果 = 有弹反动作效果;
			this.削韧倍率 = 削韧倍率;
			this.最大触发距离 = 最大触发距离;
			this.最大触发夹角 = 最大触发夹角;
			this.被弹反者应用BuffID = 被弹反者应用BuffID;
			this.攻击者应用BuffID = 攻击者应用BuffID;
			this.受击动画忽略Buff检测 = 受击动画忽略Buff检测;
			this.检测Buff列表 = 检测Buff列表;
			this.ANS期间被弹反者生效的BuffID = ANS期间被弹反者生效的BuffID;
			this.结束事件Tag = 结束事件Tag;
			this.QTE弹刀忽略角度距离检测 = QTE弹刀忽略角度距离检测;
		}

		// Token: 0x0602CF62 RID: 184162 RVA: 0x00AB4420 File Offset: 0x00AB2620
		protected override IntPtr GetUStructPtr()
		{
			return SCounterAttack.StaticStruct();
		}

		// Token: 0x0602CF63 RID: 184163 RVA: 0x00AB442C File Offset: 0x00AB262C
		[NullableContext(2)]
		public SCounterAttack(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CF64 RID: 184164 RVA: 0x00AB4436 File Offset: 0x00AB2636
		public SCounterAttack(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CF65 RID: 184165 RVA: 0x00AB4441 File Offset: 0x00AB2641
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCounterAttack(Pointer, false, true);
		}

		// Token: 0x0602CF66 RID: 184166 RVA: 0x00AB444B File Offset: 0x00AB264B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCounterAttack(Pointer, MemoryOwner);
		}

		// Token: 0x0401937C RID: 103292
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCounterAttack.SCounterAttack";

		// Token: 0x0401937D RID: 103293
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401937E RID: 103294
		internal static int __PropertyOffset_0;

		// Token: 0x0401937F RID: 103295
		[Nullable(2)]
		private TArray<FName> _弹反部位;

		// Token: 0x04019380 RID: 103296
		internal static int __PropertyOffset_1;

		// Token: 0x04019381 RID: 103297
		[Nullable(2)]
		private SCounterAttackEffect _无弹反动作效果;

		// Token: 0x04019382 RID: 103298
		internal static int __PropertyOffset_2;

		// Token: 0x04019383 RID: 103299
		[Nullable(2)]
		private SCounterAttackEffect _有弹反动作效果;

		// Token: 0x04019384 RID: 103300
		internal static int __PropertyOffset_3;

		// Token: 0x04019385 RID: 103301
		internal static int __PropertyOffset_4;

		// Token: 0x04019386 RID: 103302
		internal static int __PropertyOffset_5;

		// Token: 0x04019387 RID: 103303
		internal static int __PropertyOffset_6;

		// Token: 0x04019388 RID: 103304
		internal static int __PropertyOffset_7;

		// Token: 0x04019389 RID: 103305
		internal static int __PropertyOffset_8;

		// Token: 0x0401938A RID: 103306
		internal static int __PropertyOffset_9;

		// Token: 0x0401938B RID: 103307
		[Nullable(2)]
		private TArray<SCounterAttackBuff> _检测Buff列表;

		// Token: 0x0401938C RID: 103308
		internal static int __PropertyOffset_10;

		// Token: 0x0401938D RID: 103309
		internal static int __PropertyOffset_11;

		// Token: 0x0401938E RID: 103310
		internal static int __PropertyOffset_12;
	}
}
