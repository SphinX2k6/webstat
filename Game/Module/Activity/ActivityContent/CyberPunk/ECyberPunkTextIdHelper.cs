using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006979 RID: 27001
	public static class ECyberPunkTextIdHelper
	{
		// Token: 0x06042FC7 RID: 274375 RVA: 0x011325F8 File Offset: 0x011307F8
		[NullableContext(1)]
		public static string ToTextId(ECyberPunkTextId textId)
		{
			string result;
			if (textId != ECyberPunkTextId.REWARD)
			{
				if (textId != ECyberPunkTextId.QUESTFINISH)
				{
					result = string.Empty;
				}
				else
				{
					result = "Edgerunners_QuestFinish";
				}
			}
			else
			{
				result = "Cyberpunk_Reward";
			}
			return result;
		}
	}
}
