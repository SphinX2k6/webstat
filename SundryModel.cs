using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002ABB RID: 10939
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SundryModel : ModelBase<SundryModel>
{
	// Token: 0x06015E2E RID: 89646 RVA: 0x006142DF File Offset: 0x006124DF
	public void SetBlockTpDungeon(bool bBlock, SundryModel.EBlockTpDungeonReason reason)
	{
		if (bBlock)
		{
			this.BlockTpDungeonSet.Add(reason);
			return;
		}
		this.BlockTpDungeonSet.Remove(reason);
	}

	// Token: 0x06015E2F RID: 89647 RVA: 0x006142FF File Offset: 0x006124FF
	public void ForceSetBlockTpDungeon(bool bBlock)
	{
		if (bBlock)
		{
			this.BlockTpDungeonSet.Add(SundryModel.EBlockTpDungeonReason.ForceBlock);
			return;
		}
		this.BlockTpDungeonSet.Clear();
	}

	// Token: 0x06015E30 RID: 89648 RVA: 0x0061431D File Offset: 0x0061251D
	public bool IsBlockTpDungeon()
	{
		return this.BlockTpDungeonSet.Count > 0;
	}

	// Token: 0x06015E31 RID: 89649 RVA: 0x0061432D File Offset: 0x0061252D
	public bool HasBlockTpDungeonReason(SundryModel.EBlockTpDungeonReason reason)
	{
		return this.BlockTpDungeonSet.Contains(reason);
	}

	// Token: 0x06015E32 RID: 89650 RVA: 0x0061433B File Offset: 0x0061253B
	public void ChangeModuleDebugLevel(string key, int level)
	{
		if (level > 0)
		{
			this.ModuleDebugLevelMap[key] = level;
		}
		else
		{
			this.ModuleDebugLevelMap.Remove(key);
		}
		Singleton<EventSystem>.Instance.Emit<string, int>(EEventName.OnChangeModuleDebugLevel, key, level);
	}

	// Token: 0x06015E33 RID: 89651 RVA: 0x00614370 File Offset: 0x00612570
	public int GetModuleDebugLevel(string key)
	{
		int result;
		if (!this.ModuleDebugLevelMap.TryGetValue(key, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06015E34 RID: 89652 RVA: 0x00614390 File Offset: 0x00612590
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0400A80C RID: 43020
	public int AccountGmId;

	// Token: 0x0400A80D RID: 43021
	public bool SceneCheckOn;

	// Token: 0x0400A80E RID: 43022
	public bool RoleMoveDebugLogOn;

	// Token: 0x0400A80F RID: 43023
	public bool RoleFallingDebugLogOn;

	// Token: 0x0400A810 RID: 43024
	public string GuideTriggerName = "";

	// Token: 0x0400A811 RID: 43025
	public bool GmBlueprintGmIsOpen;

	// Token: 0x0400A812 RID: 43026
	public bool GmBlueprintGmWinDebugIsOpen;

	// Token: 0x0400A813 RID: 43027
	public bool CurrentGmRunState;

	// Token: 0x0400A814 RID: 43028
	public string RunningGmName = "";

	// Token: 0x0400A815 RID: 43029
	public bool CanOpenGmView;

	// Token: 0x0400A816 RID: 43030
	public bool IsBlockTips;

	// Token: 0x0400A817 RID: 43031
	private readonly HashSet<SundryModel.EBlockTpDungeonReason> BlockTpDungeonSet = new HashSet<SundryModel.EBlockTpDungeonReason>();

	// Token: 0x0400A818 RID: 43032
	public Dictionary<string, int> ModuleDebugLevelMap = new Dictionary<string, int>();

	// Token: 0x0400A819 RID: 43033
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TipsActorData> TipsActorDataMap;

	// Token: 0x0400A81A RID: 43034
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TipsSplineActorData> TipsSplineActorDataMap;

	// Token: 0x02008E2B RID: 36395
	[NullableContext(0)]
	public enum ELogVerbosity
	{
		// Token: 0x0402FD32 RID: 195890
		NoLogging,
		// Token: 0x0402FD33 RID: 195891
		Fatal,
		// Token: 0x0402FD34 RID: 195892
		Error,
		// Token: 0x0402FD35 RID: 195893
		Warning,
		// Token: 0x0402FD36 RID: 195894
		Display,
		// Token: 0x0402FD37 RID: 195895
		Log,
		// Token: 0x0402FD38 RID: 195896
		Verbose,
		// Token: 0x0402FD39 RID: 195897
		VeryVerbose
	}

	// Token: 0x02008E2C RID: 36396
	[NullableContext(0)]
	public enum EBlockTpDungeonReason
	{
		// Token: 0x0402FD3B RID: 195899
		GmAutoRun,
		// Token: 0x0402FD3C RID: 195900
		EditorStartConfig,
		// Token: 0x0402FD3D RID: 195901
		ForceBlock
	}
}
