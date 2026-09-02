using System;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047D1 RID: 18385
	public static class EMotorcycleRailMoveDataTypeExtensions
	{
		// Token: 0x0602FB1C RID: 195356 RVA: 0x00B69164 File Offset: 0x00B67364
		public static string ToEnumString(this EMotorcycleRailMoveDataType value)
		{
			string result;
			switch (value)
			{
			case EMotorcycleRailMoveDataType.AccelerateAlongRail:
				result = "AccelerateAlongRail";
				break;
			case EMotorcycleRailMoveDataType.JumpToRail:
				result = "JumpToRail";
				break;
			case EMotorcycleRailMoveDataType.SwitchRail:
				result = "SwitchRail";
				break;
			case EMotorcycleRailMoveDataType.JumpAlongRail:
				result = "JumpAlongRail";
				break;
			case EMotorcycleRailMoveDataType.SimpleMoveToRail:
				result = "SimpleMoveToRail";
				break;
			case EMotorcycleRailMoveDataType.JumpFromRail:
				result = "JumpFromRail";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602FB1D RID: 195357 RVA: 0x00B691D0 File Offset: 0x00B673D0
		public static EMotorcycleRailMoveDataType FromString(string name)
		{
			EMotorcycleRailMoveDataType result;
			if (!EMotorcycleRailMoveDataTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EMotorcycleRailMoveDataType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602FB1E RID: 195358 RVA: 0x00B691FC File Offset: 0x00B673FC
		public static bool TryFromString(string name, out EMotorcycleRailMoveDataType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EMotorcycleRailMoveDataType.AccelerateAlongRail;
				return false;
			}
			if (name == "AccelerateAlongRail")
			{
				value = EMotorcycleRailMoveDataType.AccelerateAlongRail;
				return true;
			}
			if (name == "JumpToRail")
			{
				value = EMotorcycleRailMoveDataType.JumpToRail;
				return true;
			}
			if (name == "SwitchRail")
			{
				value = EMotorcycleRailMoveDataType.SwitchRail;
				return true;
			}
			if (name == "JumpAlongRail")
			{
				value = EMotorcycleRailMoveDataType.JumpAlongRail;
				return true;
			}
			if (name == "SimpleMoveToRail")
			{
				value = EMotorcycleRailMoveDataType.SimpleMoveToRail;
				return true;
			}
			if (!(name == "JumpFromRail"))
			{
				value = EMotorcycleRailMoveDataType.AccelerateAlongRail;
				return false;
			}
			value = EMotorcycleRailMoveDataType.JumpFromRail;
			return true;
		}

		// Token: 0x0602FB1F RID: 195359 RVA: 0x00B69288 File Offset: 0x00B67488
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"AccelerateAlongRail",
				"JumpToRail",
				"SwitchRail",
				"JumpAlongRail",
				"SimpleMoveToRail",
				"JumpFromRail"
			};
		}

		// Token: 0x0602FB20 RID: 195360 RVA: 0x00B692C0 File Offset: 0x00B674C0
		public static EMotorcycleRailMoveDataType[] GetValues()
		{
			return new EMotorcycleRailMoveDataType[]
			{
				EMotorcycleRailMoveDataType.AccelerateAlongRail,
				EMotorcycleRailMoveDataType.JumpToRail,
				EMotorcycleRailMoveDataType.SwitchRail,
				EMotorcycleRailMoveDataType.JumpAlongRail,
				EMotorcycleRailMoveDataType.SimpleMoveToRail,
				EMotorcycleRailMoveDataType.JumpFromRail
			};
		}

		// Token: 0x0602FB21 RID: 195361 RVA: 0x00B692D3 File Offset: 0x00B674D3
		public static string[] GetNames()
		{
			return new string[]
			{
				"AccelerateAlongRail",
				"JumpToRail",
				"SwitchRail",
				"JumpAlongRail",
				"SimpleMoveToRail",
				"JumpFromRail"
			};
		}
	}
}
