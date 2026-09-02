using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007002 RID: 28674
	public class LanguageKeyTransUtils : IStaticVariableResetter
	{
		// Token: 0x06045697 RID: 284311 RVA: 0x01225F3E File Offset: 0x0122413E
		static LanguageKeyTransUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LanguageKeyTransUtils.CreateStaticDefaultValue), new Action(LanguageKeyTransUtils.ResetStaticDefaultValue));
		}

		// Token: 0x06045698 RID: 284312 RVA: 0x01225F5D File Offset: 0x0122415D
		private static void CreateKeyTransMap()
		{
			LanguageKeyTransUtils.KeyTransMap[EKeyboardPrimaryLangId.Default] = new DefaultLanguageKeyTrans();
			LanguageKeyTransUtils.KeyTransMap[EKeyboardPrimaryLangId.French] = new FrenchLanguageKeyTrans();
			LanguageKeyTransUtils.KeyTransMap[EKeyboardPrimaryLangId.Thai] = new ThaiLanguageKeyTrans();
		}

		// Token: 0x06045699 RID: 284313 RVA: 0x01225F9C File Offset: 0x0122419C
		private static void InitPcKeysByConfig()
		{
			IReadOnlyList<PcKey> pcKeyConfigList = ConfigBase<InputSettingsConfig>.Instance.GetPcKeyConfigList();
			if (pcKeyConfigList == null)
			{
				return;
			}
			for (int i = 0; i < pcKeyConfigList.Count; i++)
			{
				PcKey config = pcKeyConfigList[i];
				foreach (LanguageKeyTransBase languageKeyTransBase in LanguageKeyTransUtils.KeyTransMap.Values)
				{
					languageKeyTransBase.InitPcKeysByConfig(config);
				}
			}
		}

		// Token: 0x0604569A RID: 284314 RVA: 0x0122601C File Offset: 0x0122421C
		public static void Initialize()
		{
			LanguageKeyTransUtils.CreateKeyTransMap();
			LanguageKeyTransUtils.InitPcKeysByConfig();
		}

		// Token: 0x0604569B RID: 284315 RVA: 0x01226028 File Offset: 0x01224228
		[NullableContext(1)]
		public static LanguageKeyTransBase GetKeyTrans(EKeyboardPrimaryLangId langId)
		{
			LanguageKeyTransBase result;
			if (LanguageKeyTransUtils.KeyTransMap.TryGetValue(langId, out result))
			{
				return result;
			}
			return LanguageKeyTransUtils.KeyTransMap[EKeyboardPrimaryLangId.Default];
		}

		// Token: 0x0604569C RID: 284316 RVA: 0x01226055 File Offset: 0x01224255
		public static void CreateStaticDefaultValue()
		{
			LanguageKeyTransUtils.KeyTransMap = new Dictionary<EKeyboardPrimaryLangId, LanguageKeyTransBase>();
		}

		// Token: 0x0604569D RID: 284317 RVA: 0x01226061 File Offset: 0x01224261
		public static void ResetStaticDefaultValue()
		{
			LanguageKeyTransUtils.KeyTransMap = null;
		}

		// Token: 0x04026CD0 RID: 158928
		[Nullable(1)]
		private static Dictionary<EKeyboardPrimaryLangId, LanguageKeyTransBase> KeyTransMap;
	}
}
