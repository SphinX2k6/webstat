using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing
{
	// Token: 0x02006566 RID: 25958
	internal static class TearType2AnimName
	{
		// Token: 0x06040DA5 RID: 265637 RVA: 0x010A1DD4 File Offset: 0x0109FFD4
		[NullableContext(1)]
		public static string GetAnimName(ETearType tearType)
		{
			string result;
			switch (tearType)
			{
			case ETearType.Single:
				result = "SkipC";
				break;
			case ETearType.SingleMultiple:
				result = "SkipB";
				break;
			case ETearType.Double:
				result = "SkipB";
				break;
			case ETearType.Super:
				result = "SkipA";
				break;
			default:
				result = "SkipC";
				break;
			}
			return result;
		}
	}
}
