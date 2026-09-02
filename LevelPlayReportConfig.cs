using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;

// Token: 0x020020B2 RID: 8370
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LevelPlayReportConfig : ConfigBase<LevelPlayReportConfig>
{
	// Token: 0x0600FF9A RID: 65434 RVA: 0x004627E4 File Offset: 0x004609E4
	protected override bool OnInit()
	{
		foreach (LevelPlayInfoMappingConfig levelPlayInfoMappingConfig in ConfigLevelPlayInfoMappingConfigAll.GetConfigList(true))
		{
			LevelPlayReportDefine.LevelPlayReportConfigData levelPlayReportConfigData = Json.Decode<LevelPlayReportDefine.LevelPlayReportConfigData>(levelPlayInfoMappingConfig.Data, null);
			if (!this.LevelPlayReportConfigMapping.ContainsKey(levelPlayReportConfigData.LevelPlayId))
			{
				if (levelPlayReportConfigData.Vars.Length > 1)
				{
					int num = levelPlayReportConfigData.Vars.Length - 1;
					string getBoxNumKey = levelPlayReportConfigData.Vars[num];
					levelPlayReportConfigData.GetBoxNumKey = getBoxNumKey;
					string[] array = new string[num];
					Array.Copy(levelPlayReportConfigData.Vars, 0, array, 0, num);
					levelPlayReportConfigData.Vars = array;
				}
				this.LevelPlayReportConfigMapping.Add(levelPlayReportConfigData.LevelPlayId, levelPlayReportConfigData);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlayReport;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "玩法信息映射设置失败,重复玩法Id,请联系策划检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelPlayId", levelPlayReportConfigData.LevelPlayId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return true;
	}

	// Token: 0x0600FF9B RID: 65435 RVA: 0x004628E8 File Offset: 0x00460AE8
	[NullableContext(2)]
	public LevelPlayReportDefine.ILevelPlayReportConfigData GetLevelPlayReportConfig(int levelPlayReportId)
	{
		LevelPlayReportDefine.ILevelPlayReportConfigData result;
		if (this.LevelPlayReportConfigMapping.TryGetValue(levelPlayReportId, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LevelPlayReport;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "获取玩法信息映设配置失败,请联系策划检查";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelPlayId", levelPlayReportId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600FF9C RID: 65436 RVA: 0x00462938 File Offset: 0x00460B38
	public HiddenBossWindow? GetHiddenBossWindowConfig(int id)
	{
		HiddenBossWindow? config = ConfigHiddenBossWindowById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlayReport;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "找不到隐藏Boss窗口配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HiddenBossWindow?(config.Value);
	}

	// Token: 0x04007A91 RID: 31377
	private readonly Dictionary<int, LevelPlayReportDefine.ILevelPlayReportConfigData> LevelPlayReportConfigMapping = new Dictionary<int, LevelPlayReportDefine.ILevelPlayReportConfigData>();
}
