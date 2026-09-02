using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200577F RID: 22399
	public class LanguageSettingViewBase : IStaticVariableResetter
	{
		// Token: 0x06038FF4 RID: 233460 RVA: 0x00E71413 File Offset: 0x00E6F613
		static LanguageSettingViewBase()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LanguageSettingViewBase.CreateStaticDefaultValue), new Action(LanguageSettingViewBase.ResetStaticDefaultValue));
		}

		// Token: 0x06038FF5 RID: 233461 RVA: 0x00E71432 File Offset: 0x00E6F632
		public static void CreateStaticDefaultValue()
		{
			LanguageSettingViewBase.BackToPrevLangSettingViewName = null;
			LanguageSettingViewBase.ApplyValueFunc = null;
		}

		// Token: 0x06038FF6 RID: 233462 RVA: 0x00E71445 File Offset: 0x00E6F645
		public static void ResetStaticDefaultValue()
		{
			LanguageSettingViewBase.BackToPrevLangSettingViewName = null;
			LanguageSettingViewBase.ApplyValueFunc = null;
		}

		// Token: 0x0402072B RID: 132907
		public static EUiViewName? BackToPrevLangSettingViewName;

		// Token: 0x0402072C RID: 132908
		[Nullable(2)]
		public static Action<int, float> ApplyValueFunc;
	}
}
