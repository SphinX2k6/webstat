using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA7 RID: 24487
	public static class EMissionRuleIdExtensions
	{
		// Token: 0x0603D891 RID: 252049 RVA: 0x00FAAC28 File Offset: 0x00FA8E28
		[NullableContext(1)]
		public static string ToString(this EMissionRuleId ruleId)
		{
			string result;
			switch (ruleId)
			{
			case EMissionRuleId.Default:
				result = "default";
				break;
			case EMissionRuleId.HonamiStory:
				result = "honamiStory";
				break;
			case EMissionRuleId.SpringManor:
				result = "springManor";
				break;
			default:
				result = ruleId.ToString();
				break;
			}
			return result;
		}
	}
}
