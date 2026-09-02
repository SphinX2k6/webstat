using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleLangCustomModel;

// Token: 0x02002871 RID: 10353
public class RoleFavorUtil
{
	// Token: 0x0601481B RID: 83995 RVA: 0x005B09AC File Offset: 0x005AEBAC
	[NullableContext(1)]
	public static string GetCurLanguageCvName(int roleId)
	{
		FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(roleId);
		if (favorRoleInfoConfig == null)
		{
			return "";
		}
		int roleLangType = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(roleId);
		string audioCode = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(roleLangType).AudioCode;
		if (audioCode == "zh")
		{
			return favorRoleInfoConfig.Value.CVNameCn;
		}
		if (audioCode == "ja")
		{
			return favorRoleInfoConfig.Value.CVNameJp;
		}
		if (audioCode == "en")
		{
			return favorRoleInfoConfig.Value.CVNameEn;
		}
		if (!(audioCode == "ko"))
		{
			return favorRoleInfoConfig.Value.CVNameCn;
		}
		return favorRoleInfoConfig.Value.CVNameKo;
	}
}
