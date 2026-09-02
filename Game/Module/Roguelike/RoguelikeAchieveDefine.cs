using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005123 RID: 20771
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveDefine : IStaticVariableResetter
	{
		// Token: 0x17008C5B RID: 35931
		// (get) Token: 0x060357D1 RID: 219089 RVA: 0x00D6DE15 File Offset: 0x00D6C015
		public static string RoguelikeAchieveSavedStateIconPath
		{
			get
			{
				if (RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPathInternal == null)
				{
					RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPathInternal = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_RoguelikeSavedFileRecordIcon");
				}
				return RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPathInternal;
			}
		}

		// Token: 0x17008C5C RID: 35932
		// (get) Token: 0x060357D2 RID: 219090 RVA: 0x00D6DE37 File Offset: 0x00D6C037
		public static string RoguelikeAchieveUnSavedStateIconPath
		{
			get
			{
				if (RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPathInternal == null)
				{
					RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPathInternal = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_RoguelikeUnSavedFileRecordIcon");
				}
				return RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPathInternal;
			}
		}

		// Token: 0x060357D3 RID: 219091 RVA: 0x00D6DE59 File Offset: 0x00D6C059
		static RoguelikeAchieveDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoguelikeAchieveDefine.CreateStaticDefaultValue), new Action(RoguelikeAchieveDefine.ResetStaticDefaultValue));
		}

		// Token: 0x060357D4 RID: 219092 RVA: 0x00D6DE78 File Offset: 0x00D6C078
		public static void CreateStaticDefaultValue()
		{
			RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPathInternal = null;
			RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPathInternal = null;
		}

		// Token: 0x060357D5 RID: 219093 RVA: 0x00D6DE86 File Offset: 0x00D6C086
		public static void ResetStaticDefaultValue()
		{
			RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPathInternal = null;
			RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPathInternal = null;
		}

		// Token: 0x0401EBF5 RID: 125941
		public const int ROGUELIKE_ACHIEVE_TOKEN_PANEL_MORE_THRESHOLD = 8;

		// Token: 0x0401EBF6 RID: 125942
		[Nullable(2)]
		private static string RoguelikeAchieveSavedStateIconPathInternal;

		// Token: 0x0401EBF7 RID: 125943
		[Nullable(2)]
		private static string RoguelikeAchieveUnSavedStateIconPathInternal;
	}
}
