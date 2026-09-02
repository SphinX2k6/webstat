using System;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4C RID: 19532
	public static class EObstructionCheckResultExtensions
	{
		// Token: 0x06032E46 RID: 208454 RVA: 0x00CBEEE8 File Offset: 0x00CBD0E8
		public static string ToEnumString(this EObstructionCheckResult value)
		{
			string result;
			switch (value)
			{
			case EObstructionCheckResult.None:
				result = "None";
				break;
			case EObstructionCheckResult.TraceBlock:
				result = "TraceBlock";
				break;
			case EObstructionCheckResult.CheckPlayerBlock:
				result = "CheckPlayerBlock";
				break;
			case EObstructionCheckResult.SameRoadwayVehicleBlock:
				result = "SameRoadwayVehicleBlock";
				break;
			case EObstructionCheckResult.NextRoadwayVehicleBlock:
				result = "NextRoadwayVehicleBlock";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06032E47 RID: 208455 RVA: 0x00CBEF48 File Offset: 0x00CBD148
		public static EObstructionCheckResult FromString(string name)
		{
			EObstructionCheckResult result;
			if (!EObstructionCheckResultExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EObstructionCheckResult 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06032E48 RID: 208456 RVA: 0x00CBEF74 File Offset: 0x00CBD174
		public static bool TryFromString(string name, out EObstructionCheckResult value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EObstructionCheckResult.None;
				return false;
			}
			if (name == "None")
			{
				value = EObstructionCheckResult.None;
				return true;
			}
			if (name == "TraceBlock")
			{
				value = EObstructionCheckResult.TraceBlock;
				return true;
			}
			if (name == "CheckPlayerBlock")
			{
				value = EObstructionCheckResult.CheckPlayerBlock;
				return true;
			}
			if (name == "SameRoadwayVehicleBlock")
			{
				value = EObstructionCheckResult.SameRoadwayVehicleBlock;
				return true;
			}
			if (!(name == "NextRoadwayVehicleBlock"))
			{
				value = EObstructionCheckResult.None;
				return false;
			}
			value = EObstructionCheckResult.NextRoadwayVehicleBlock;
			return true;
		}

		// Token: 0x06032E49 RID: 208457 RVA: 0x00CBEFEE File Offset: 0x00CBD1EE
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"None",
				"TraceBlock",
				"CheckPlayerBlock",
				"SameRoadwayVehicleBlock",
				"NextRoadwayVehicleBlock"
			};
		}

		// Token: 0x06032E4A RID: 208458 RVA: 0x00CBF01E File Offset: 0x00CBD21E
		public static EObstructionCheckResult[] GetValues()
		{
			return new EObstructionCheckResult[]
			{
				EObstructionCheckResult.None,
				EObstructionCheckResult.TraceBlock,
				EObstructionCheckResult.CheckPlayerBlock,
				EObstructionCheckResult.SameRoadwayVehicleBlock,
				EObstructionCheckResult.NextRoadwayVehicleBlock
			};
		}

		// Token: 0x06032E4B RID: 208459 RVA: 0x00CBF031 File Offset: 0x00CBD231
		public static string[] GetNames()
		{
			return new string[]
			{
				"None",
				"TraceBlock",
				"CheckPlayerBlock",
				"SameRoadwayVehicleBlock",
				"NextRoadwayVehicleBlock"
			};
		}
	}
}
