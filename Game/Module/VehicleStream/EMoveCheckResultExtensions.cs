using System;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4E RID: 19534
	public static class EMoveCheckResultExtensions
	{
		// Token: 0x06032E4F RID: 208463 RVA: 0x00CBF0A0 File Offset: 0x00CBD2A0
		public static string ToEnumString(this EMoveCheckResult value)
		{
			string result;
			switch (value)
			{
			case EMoveCheckResult.None:
				result = "None";
				break;
			case EMoveCheckResult.TraceBlock:
				result = "TraceBlock";
				break;
			case EMoveCheckResult.CheckPlayerBlock:
				result = "CheckPlayerBlock";
				break;
			case EMoveCheckResult.SameRoadwayVehicleBlock:
				result = "SameRoadwayVehicleBlock";
				break;
			case EMoveCheckResult.NextRoadwayVehicleBlock:
				result = "NextRoadwayVehicleBlock";
				break;
			case EMoveCheckResult.Intersection:
				result = "Intersection";
				break;
			case EMoveCheckResult.CrossPlayer:
				result = "CrossPlayer";
				break;
			case EMoveCheckResult.CrossSameRoadwayVehicle:
				result = "CrossSameRoadwayVehicle";
				break;
			case EMoveCheckResult.CrossNextRoadwayVehicle:
				result = "CrossNextRoadwayVehicle";
				break;
			case EMoveCheckResult.HeadOverRoadOnWaitIntersection:
				result = "HeadOverRoadOnWaitIntersection";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06032E50 RID: 208464 RVA: 0x00CBF13C File Offset: 0x00CBD33C
		public static EMoveCheckResult FromString(string name)
		{
			EMoveCheckResult result;
			if (!EMoveCheckResultExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EMoveCheckResult 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06032E51 RID: 208465 RVA: 0x00CBF168 File Offset: 0x00CBD368
		public static bool TryFromString(string name, out EMoveCheckResult value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EMoveCheckResult.None;
				return false;
			}
			if (name != null)
			{
				int length = name.Length;
				if (length <= 16)
				{
					if (length != 4)
					{
						switch (length)
						{
						case 10:
							if (name == "TraceBlock")
							{
								value = EMoveCheckResult.TraceBlock;
								return true;
							}
							break;
						case 11:
							if (name == "CrossPlayer")
							{
								value = EMoveCheckResult.CrossPlayer;
								return true;
							}
							break;
						case 12:
							if (name == "Intersection")
							{
								value = EMoveCheckResult.Intersection;
								return true;
							}
							break;
						case 16:
							if (name == "CheckPlayerBlock")
							{
								value = EMoveCheckResult.CheckPlayerBlock;
								return true;
							}
							break;
						}
					}
					else if (name == "None")
					{
						value = EMoveCheckResult.None;
						return true;
					}
				}
				else if (length != 23)
				{
					if (length == 30)
					{
						if (name == "HeadOverRoadOnWaitIntersection")
						{
							value = EMoveCheckResult.HeadOverRoadOnWaitIntersection;
							return true;
						}
					}
				}
				else
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c != 'N')
						{
							if (c == 'S')
							{
								if (name == "SameRoadwayVehicleBlock")
								{
									value = EMoveCheckResult.SameRoadwayVehicleBlock;
									return true;
								}
							}
						}
						else if (name == "NextRoadwayVehicleBlock")
						{
							value = EMoveCheckResult.NextRoadwayVehicleBlock;
							return true;
						}
					}
					else
					{
						if (name == "CrossSameRoadwayVehicle")
						{
							value = EMoveCheckResult.CrossSameRoadwayVehicle;
							return true;
						}
						if (name == "CrossNextRoadwayVehicle")
						{
							value = EMoveCheckResult.CrossNextRoadwayVehicle;
							return true;
						}
					}
				}
			}
			value = EMoveCheckResult.None;
			return false;
		}

		// Token: 0x06032E52 RID: 208466 RVA: 0x00CBF2D0 File Offset: 0x00CBD4D0
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"None",
				"TraceBlock",
				"CheckPlayerBlock",
				"SameRoadwayVehicleBlock",
				"NextRoadwayVehicleBlock",
				"Intersection",
				"CrossPlayer",
				"CrossSameRoadwayVehicle",
				"CrossNextRoadwayVehicle",
				"HeadOverRoadOnWaitIntersection"
			};
		}

		// Token: 0x06032E53 RID: 208467 RVA: 0x00CBF335 File Offset: 0x00CBD535
		public static EMoveCheckResult[] GetValues()
		{
			return new EMoveCheckResult[]
			{
				EMoveCheckResult.None,
				EMoveCheckResult.TraceBlock,
				EMoveCheckResult.CheckPlayerBlock,
				EMoveCheckResult.SameRoadwayVehicleBlock,
				EMoveCheckResult.NextRoadwayVehicleBlock,
				EMoveCheckResult.Intersection,
				EMoveCheckResult.CrossPlayer,
				EMoveCheckResult.CrossSameRoadwayVehicle,
				EMoveCheckResult.CrossNextRoadwayVehicle,
				EMoveCheckResult.HeadOverRoadOnWaitIntersection
			};
		}

		// Token: 0x06032E54 RID: 208468 RVA: 0x00CBF34C File Offset: 0x00CBD54C
		public static string[] GetNames()
		{
			return new string[]
			{
				"None",
				"TraceBlock",
				"CheckPlayerBlock",
				"SameRoadwayVehicleBlock",
				"NextRoadwayVehicleBlock",
				"Intersection",
				"CrossPlayer",
				"CrossSameRoadwayVehicle",
				"CrossNextRoadwayVehicle",
				"HeadOverRoadOnWaitIntersection"
			};
		}
	}
}
