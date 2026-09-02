using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020020ED RID: 8429
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LoginConfig : ConfigBase<LoginConfig>
{
	// Token: 0x06010182 RID: 65922 RVA: 0x0046A739 File Offset: 0x00468939
	[NullableContext(2)]
	public IReadOnlyList<InstanceDungeon> GetAllInstanceDungeon()
	{
		return ConfigInstanceDungeonAll.GetConfigList(true);
	}

	// Token: 0x06010183 RID: 65923 RVA: 0x0046A741 File Offset: 0x00468941
	public string GetInstanceDungeonNameById(string id)
	{
		return ConfigMultiTextLang.GetLocalTextNew(id, null) ?? "";
	}

	// Token: 0x06010184 RID: 65924 RVA: 0x0046A754 File Offset: 0x00468954
	public int? GetLoginFailResetTime()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("login_fail_reset_time");
		int? num = intConfig;
		int num2 = 0;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "登录失败次数重置参数错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("loginFailResetTime", intConfig);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return intConfig;
	}

	// Token: 0x06010185 RID: 65925 RVA: 0x0046A7B0 File Offset: 0x004689B0
	public int GetLoginFailParam(int loginFailCount)
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("login_fail_params");
		string[] array = (stringConfig != null) ? stringConfig.Split(RuntimeHelpers.CreateSpan<char>(fieldof(<PrivateImplementationDetails>.021830820ECA87353011E7C2ED9A7A72DBF58F2FD2958302244969DC3C07812C2).FieldHandle)) : null;
		if (array == null || array.Length == 0 || array.Length % 2 != 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "登录失败重试参数错误, 请检查个数";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("params", stringConfig);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		int result = 0;
		for (int i = 0; i < array.Length; i += 2)
		{
			int num;
			int num2;
			if (!int.TryParse(array[i], out num) || num <= 0 || !int.TryParse(array[i + 1], out num2) || num2 <= 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Login;
				ELogAuthor author2 = ELogAuthor.ZJC;
				string message2 = "登录失败重试参数错误, ";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("params", stringConfig);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return 0;
			}
			if (loginFailCount >= num)
			{
				result = num2;
			}
		}
		return result;
	}

	// Token: 0x06010186 RID: 65926 RVA: 0x0046A880 File Offset: 0x00468A80
	public int? GetDefaultSingleMapId()
	{
		return ConfigCommonParamById.GetIntConfig("default_single_map_id");
	}

	// Token: 0x06010187 RID: 65927 RVA: 0x0046A88C File Offset: 0x00468A8C
	public int? GetDefaultMultiMapId()
	{
		return ConfigCommonParamById.GetIntConfig("default_multi_map_id");
	}

	// Token: 0x06010188 RID: 65928 RVA: 0x0046A898 File Offset: 0x00468A98
	public int? GetSdkReloginTime()
	{
		return ConfigCommonParamById.GetIntConfig("sdk_relogin_time");
	}

	// Token: 0x06010189 RID: 65929 RVA: 0x0046A8A4 File Offset: 0x00468AA4
	[NullableContext(2)]
	public string GetDevLoginServerIp()
	{
		return ConfigCommonParamById.GetStringConfig("dev_sdk_loginserver_ip");
	}

	// Token: 0x0601018A RID: 65930 RVA: 0x0046A8B0 File Offset: 0x00468AB0
	[NullableContext(2)]
	public string GetMainlineLoginServerIp()
	{
		return ConfigCommonParamById.GetStringConfig("mainline_sdk_loginserver_ip");
	}

	// Token: 0x0601018B RID: 65931 RVA: 0x0046A8BC File Offset: 0x00468ABC
	public string[] GetLoginViewNoExitButtonPackageIdList()
	{
		return ConfigCommonParamById.GetStringConfig("LoginViewNoShowExitButtonPackageIdList").Split(',', StringSplitOptions.None);
	}

	// Token: 0x0601018C RID: 65932 RVA: 0x0046A8D0 File Offset: 0x00468AD0
	public string[] GetLoginViewNoAccountButtonPackageIdList()
	{
		return ConfigCommonParamById.GetStringConfig("LoginViewNoAccountButtonPackageIdList").Split(',', StringSplitOptions.None);
	}

	// Token: 0x0601018D RID: 65933 RVA: 0x0046A8E4 File Offset: 0x00468AE4
	public ServerLimit? GetServerLimitConfig(string region)
	{
		return ConfigServerLimitById.GetConfig(region, true);
	}
}
