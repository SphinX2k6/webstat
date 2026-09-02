using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006977 RID: 26999
	public static class EProgressTextColorHelper
	{
		// Token: 0x06042FC6 RID: 274374 RVA: 0x011325B8 File Offset: 0x011307B8
		[NullableContext(1)]
		public static string ToColorString(EProgressTextColor color)
		{
			string result;
			switch (color)
			{
			case EProgressTextColor.Zero:
				result = "ffffff";
				break;
			case EProgressTextColor.InProgress:
				result = "fefe22";
				break;
			case EProgressTextColor.Completed:
				result = "29ff98";
				break;
			default:
				result = "ffffff";
				break;
			}
			return result;
		}
	}
}
