using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200229F RID: 8863
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MotorConfig : ConfigBase<MotorConfig>
{
	// Token: 0x06010C06 RID: 68614 RVA: 0x004971E0 File Offset: 0x004953E0
	public IReadOnlyList<MotorLvl> GetAllMotorLevelList()
	{
		IReadOnlyList<MotorLvl> configList = ConfigMotorLvlAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorLevel表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorLvl>();
		}
		return configList;
	}

	// Token: 0x06010C07 RID: 68615 RVA: 0x00497220 File Offset: 0x00495420
	public MotorLvl? GetMotorLevelConfig(int level)
	{
		MotorLvl? config = ConfigMotorLvlByLevel.GetConfig(level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorLevel表无效Level";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("level", level);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C08 RID: 68616 RVA: 0x00497278 File Offset: 0x00495478
	public IReadOnlyList<MotorLevelHint> GetAllMotorLevelHintList()
	{
		IReadOnlyList<MotorLevelHint> configList = ConfigMotorLevelHintAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorLevelHint表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorLevelHint>();
		}
		return configList;
	}

	// Token: 0x06010C09 RID: 68617 RVA: 0x004972B8 File Offset: 0x004954B8
	public MotorTechTree? GetMotorTechTreeConfig(int treeType)
	{
		MotorTechTree? config = ConfigMotorTechTreeById.GetConfig(treeType, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTechTree表无效TreeType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeType", treeType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C0A RID: 68618 RVA: 0x00497310 File Offset: 0x00495510
	public int[] GetAllMotorTreeIds()
	{
		List<int> list = new List<int>();
		IReadOnlyList<MotorTechTree> configList = ConfigMotorTechTreeAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorTechTree表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new int[0];
		}
		foreach (MotorTechTree motorTechTree in configList)
		{
			list.Add(motorTechTree.Id);
		}
		return list.ToArray();
	}

	// Token: 0x06010C0B RID: 68619 RVA: 0x0049739C File Offset: 0x0049559C
	public IReadOnlyList<MotorTech> GetMotorTechConfigList(int treeType)
	{
		IReadOnlyList<MotorTech> configList = ConfigMotorTechByTreeType.GetConfigList(treeType, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTech表无效TreeType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeType", treeType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<MotorTech>();
		}
		return configList;
	}

	// Token: 0x06010C0C RID: 68620 RVA: 0x004973EC File Offset: 0x004955EC
	public MotorTech? GetMotorTechConfig(int id)
	{
		MotorTech? config = ConfigMotorTechById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTech表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C0D RID: 68621 RVA: 0x00497444 File Offset: 0x00495644
	public MotorTechTag? GetMotorTechTagConfig(int tagId)
	{
		MotorTechTag? config = ConfigMotorTechTagById.GetConfig(tagId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTechTag表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", tagId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C0E RID: 68622 RVA: 0x0049749C File Offset: 0x0049569C
	public MotorTechLv? GetMotorTechLvConfig(int id)
	{
		MotorTechLv? config = ConfigMotorTechLvById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTechLv表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C0F RID: 68623 RVA: 0x004974F4 File Offset: 0x004956F4
	public MotorEffect? GetMotorEffectConfig(int id)
	{
		MotorEffect? config = ConfigMotorEffectById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorEffect表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C10 RID: 68624 RVA: 0x0049754C File Offset: 0x0049574C
	public MotorTask? GetMotorTaskConfig(int taskId)
	{
		MotorTask? config = ConfigMotorTaskById.GetConfig(taskId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTask表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", taskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C11 RID: 68625 RVA: 0x004975A4 File Offset: 0x004957A4
	public IReadOnlyList<MotorTask> GetMotorTaskConfigList(int treeType)
	{
		IReadOnlyList<MotorTask> configList = ConfigMotorTaskByTreeType.GetConfigList(treeType, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorTask表无效TreeType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeType", treeType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<MotorTask>();
		}
		return configList;
	}

	// Token: 0x06010C12 RID: 68626 RVA: 0x004975F4 File Offset: 0x004957F4
	public MotorAttr? GetMotorAttrConfig(int attrId)
	{
		MotorAttr? config = ConfigMotorAttrById.GetConfig(attrId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "MotorAttr表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", attrId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06010C13 RID: 68627 RVA: 0x0049764C File Offset: 0x0049584C
	public IReadOnlyList<MotorAttr> GetAllMotorAttrList()
	{
		IReadOnlyList<MotorAttr> configList = ConfigMotorAttrAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorAttr表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorAttr>();
		}
		return configList;
	}

	// Token: 0x06010C14 RID: 68628 RVA: 0x0049768C File Offset: 0x0049588C
	public TrialMotor? GetTrialMotorConfig(int id)
	{
		TrialMotor? config = ConfigTrialMotorById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Motor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "TrialMotor表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}
}
