using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FCC RID: 28620
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EInputAction : IEquatable<EInputAction>
	{
		// Token: 0x06045402 RID: 283650 RVA: 0x012171F2 File Offset: 0x012153F2
		private EInputAction(string Name, byte Value)
		{
			this.Name = Name;
			this.Value = Value;
		}

		// Token: 0x06045403 RID: 283651 RVA: 0x01217202 File Offset: 0x01215402
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x06045404 RID: 283652 RVA: 0x0121720A File Offset: 0x0121540A
		public bool Equals(EInputAction other)
		{
			return this.Value == other.Value;
		}

		// Token: 0x06045405 RID: 283653 RVA: 0x0121721C File Offset: 0x0121541C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EInputAction)
			{
				EInputAction other = (EInputAction)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06045406 RID: 283654 RVA: 0x01217241 File Offset: 0x01215441
		public override int GetHashCode()
		{
			string name = this.Name;
			if (name == null)
			{
				return 0;
			}
			return name.GetHashCode();
		}

		// Token: 0x06045407 RID: 283655 RVA: 0x01217254 File Offset: 0x01215454
		public static bool operator ==(EInputAction left, EInputAction right)
		{
			return left.Value == right.Value;
		}

		// Token: 0x06045408 RID: 283656 RVA: 0x01217264 File Offset: 0x01215464
		public static bool operator !=(EInputAction left, EInputAction right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06045409 RID: 283657 RVA: 0x01217271 File Offset: 0x01215471
		public static implicit operator byte(EInputAction action)
		{
			return action.Value;
		}

		// Token: 0x0604540A RID: 283658 RVA: 0x01217279 File Offset: 0x01215479
		public static implicit operator EInputAction(EInputAction action)
		{
			return (EInputAction)action.Value;
		}

		// Token: 0x0604540B RID: 283659 RVA: 0x01217284 File Offset: 0x01215484
		public static explicit operator EInputAction(byte value)
		{
			switch (value)
			{
			case 0:
				return EInputAction.None;
			case 1:
				return EInputAction.跳跃;
			case 2:
				return EInputAction.攀爬;
			case 3:
				return EInputAction.走跑切换;
			case 4:
				return EInputAction.攻击;
			case 5:
				return EInputAction.闪避;
			case 6:
				return EInputAction.技能1;
			case 7:
				return EInputAction.幻象1;
			case 8:
				return EInputAction.大招;
			case 9:
				return EInputAction.幻象2;
			case 10:
				return EInputAction.切换角色1;
			case 11:
				return EInputAction.切换角色2;
			case 12:
				return EInputAction.切换角色3;
			case 13:
				return EInputAction.锁定目标;
			case 14:
				return EInputAction.瞄准;
			case 15:
				return EInputAction.通用交互;
			case 16:
				return EInputAction.下降;
			case 17:
				return EInputAction.移动输入按键事件;
			case 18:
				return EInputAction.MaxCount;
			default:
				return default(EInputAction);
			}
		}

		// Token: 0x0604540C RID: 283660 RVA: 0x01217360 File Offset: 0x01215560
		public static implicit operator EInputAction(EInputAction action)
		{
			switch (action)
			{
			case EInputAction.None:
				return EInputAction.None;
			case EInputAction.跳跃:
				return EInputAction.跳跃;
			case EInputAction.攀爬:
				return EInputAction.攀爬;
			case EInputAction.走跑切换:
				return EInputAction.走跑切换;
			case EInputAction.攻击:
				return EInputAction.攻击;
			case EInputAction.闪避:
				return EInputAction.闪避;
			case EInputAction.技能1:
				return EInputAction.技能1;
			case EInputAction.幻象1:
				return EInputAction.幻象1;
			case EInputAction.大招:
				return EInputAction.大招;
			case EInputAction.幻象2:
				return EInputAction.幻象2;
			case EInputAction.切换角色1:
				return EInputAction.切换角色1;
			case EInputAction.切换角色2:
				return EInputAction.切换角色2;
			case EInputAction.切换角色3:
				return EInputAction.切换角色3;
			case EInputAction.锁定目标:
				return EInputAction.锁定目标;
			case EInputAction.瞄准:
				return EInputAction.瞄准;
			case EInputAction.通用交互:
				return EInputAction.通用交互;
			case EInputAction.下降:
				return EInputAction.下降;
			case EInputAction.移动输入按键事件:
				return EInputAction.移动输入按键事件;
			default:
				return default(EInputAction);
			}
		}

		// Token: 0x04026A17 RID: 158231
		public readonly string Name;

		// Token: 0x04026A18 RID: 158232
		public readonly byte Value;

		// Token: 0x04026A19 RID: 158233
		public const byte NoneValue = 0;

		// Token: 0x04026A1A RID: 158234
		public static readonly EInputAction None = new EInputAction("None", 0);

		// Token: 0x04026A1B RID: 158235
		public const byte 跳跃Value = 1;

		// Token: 0x04026A1C RID: 158236
		public static readonly EInputAction 跳跃 = new EInputAction("跳跃", 1);

		// Token: 0x04026A1D RID: 158237
		public const byte 攀爬Value = 2;

		// Token: 0x04026A1E RID: 158238
		public static readonly EInputAction 攀爬 = new EInputAction("攀爬", 2);

		// Token: 0x04026A1F RID: 158239
		public const byte 走跑切换Value = 3;

		// Token: 0x04026A20 RID: 158240
		public static readonly EInputAction 走跑切换 = new EInputAction("走跑切换", 3);

		// Token: 0x04026A21 RID: 158241
		public const byte 攻击Value = 4;

		// Token: 0x04026A22 RID: 158242
		public static readonly EInputAction 攻击 = new EInputAction("攻击", 4);

		// Token: 0x04026A23 RID: 158243
		public const byte 闪避Value = 5;

		// Token: 0x04026A24 RID: 158244
		public static readonly EInputAction 闪避 = new EInputAction("闪避", 5);

		// Token: 0x04026A25 RID: 158245
		public const byte 技能1Value = 6;

		// Token: 0x04026A26 RID: 158246
		public static readonly EInputAction 技能1 = new EInputAction("技能1", 6);

		// Token: 0x04026A27 RID: 158247
		public const byte 幻象1Value = 7;

		// Token: 0x04026A28 RID: 158248
		public static readonly EInputAction 幻象1 = new EInputAction("幻象1", 7);

		// Token: 0x04026A29 RID: 158249
		public const byte 大招Value = 8;

		// Token: 0x04026A2A RID: 158250
		public static readonly EInputAction 大招 = new EInputAction("大招", 8);

		// Token: 0x04026A2B RID: 158251
		public const byte 幻象2Value = 9;

		// Token: 0x04026A2C RID: 158252
		public static readonly EInputAction 幻象2 = new EInputAction("幻象2", 9);

		// Token: 0x04026A2D RID: 158253
		public const byte 切换角色1Value = 10;

		// Token: 0x04026A2E RID: 158254
		public static readonly EInputAction 切换角色1 = new EInputAction("切换角色1", 10);

		// Token: 0x04026A2F RID: 158255
		public const byte 切换角色2Value = 11;

		// Token: 0x04026A30 RID: 158256
		public static readonly EInputAction 切换角色2 = new EInputAction("切换角色2", 11);

		// Token: 0x04026A31 RID: 158257
		public const byte 切换角色3Value = 12;

		// Token: 0x04026A32 RID: 158258
		public static readonly EInputAction 切换角色3 = new EInputAction("切换角色3", 12);

		// Token: 0x04026A33 RID: 158259
		public const byte 锁定目标Value = 13;

		// Token: 0x04026A34 RID: 158260
		public static readonly EInputAction 锁定目标 = new EInputAction("锁定目标", 13);

		// Token: 0x04026A35 RID: 158261
		public const byte 瞄准Value = 14;

		// Token: 0x04026A36 RID: 158262
		public static readonly EInputAction 瞄准 = new EInputAction("瞄准", 14);

		// Token: 0x04026A37 RID: 158263
		public const byte 通用交互Value = 15;

		// Token: 0x04026A38 RID: 158264
		public static readonly EInputAction 通用交互 = new EInputAction("通用交互", 15);

		// Token: 0x04026A39 RID: 158265
		public const byte 下降Value = 16;

		// Token: 0x04026A3A RID: 158266
		public static readonly EInputAction 下降 = new EInputAction("下降", 16);

		// Token: 0x04026A3B RID: 158267
		public const byte 移动输入按键事件Value = 17;

		// Token: 0x04026A3C RID: 158268
		public static readonly EInputAction 移动输入按键事件 = new EInputAction("移动输入按键事件", 17);

		// Token: 0x04026A3D RID: 158269
		public const byte MaxCountValue = 18;

		// Token: 0x04026A3E RID: 158270
		public static readonly EInputAction MaxCount = new EInputAction("MaxCount", 18);

		// Token: 0x04026A3F RID: 158271
		[StaticVariableRuleIgnore]
		public static IReadOnlyList<EInputAction> Defines = new List<EInputAction>
		{
			EInputAction.None,
			EInputAction.跳跃,
			EInputAction.攀爬,
			EInputAction.走跑切换,
			EInputAction.攻击,
			EInputAction.闪避,
			EInputAction.技能1,
			EInputAction.幻象1,
			EInputAction.大招,
			EInputAction.幻象2,
			EInputAction.切换角色1,
			EInputAction.切换角色2,
			EInputAction.切换角色3,
			EInputAction.锁定目标,
			EInputAction.瞄准,
			EInputAction.通用交互,
			EInputAction.下降,
			EInputAction.移动输入按键事件,
			EInputAction.MaxCount
		};
	}
}
