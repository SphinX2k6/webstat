using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020012D7 RID: 4823
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityDangoMonopolyConfig : ConfigBase<ActivityDangoMonopolyConfig>
{
	// Token: 0x06008204 RID: 33284 RVA: 0x002262A3 File Offset: 0x002244A3
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06008205 RID: 33285 RVA: 0x002262A6 File Offset: 0x002244A6
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06008206 RID: 33286 RVA: 0x002262A9 File Offset: 0x002244A9
	public DangoMonopoly? GetInfo(int activityId)
	{
		return ConfigDangoMonopolyByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x06008207 RID: 33287 RVA: 0x002262B2 File Offset: 0x002244B2
	public DangoMonopolyBoard? GetBoard(int id)
	{
		return ConfigDangoMonopolyBoardById.GetConfig(id, true);
	}

	// Token: 0x06008208 RID: 33288 RVA: 0x002262BB File Offset: 0x002244BB
	public DangoMonopolyBoard[] GetBoardList(int groupId)
	{
		if (ConfigDangoMonopolyBoardByGroup.GetConfigList(groupId, true) == null)
		{
			return Array.Empty<DangoMonopolyBoard>();
		}
		return ConfigDangoMonopolyBoardByGroup.GetConfigList(groupId, true).ToArray<DangoMonopolyBoard>();
	}

	// Token: 0x06008209 RID: 33289 RVA: 0x002262D8 File Offset: 0x002244D8
	public DangoMonopolyTask? GetTask(int id)
	{
		return ConfigDangoMonopolyTaskById.GetConfig(id, true);
	}

	// Token: 0x0600820A RID: 33290 RVA: 0x002262E1 File Offset: 0x002244E1
	public DangoMonopolyTask[] GetTaskList(int groupId)
	{
		if (ConfigDangoMonopolyTaskByGroup.GetConfigList(groupId, true) == null)
		{
			return Array.Empty<DangoMonopolyTask>();
		}
		return ConfigDangoMonopolyTaskByGroup.GetConfigList(groupId, true).ToArray<DangoMonopolyTask>();
	}

	// Token: 0x0600820B RID: 33291 RVA: 0x002262FE File Offset: 0x002244FE
	public DangoMonopolyGrid? GetGrid(int id)
	{
		return ConfigDangoMonopolyGridById.GetConfig(id, true);
	}

	// Token: 0x0600820C RID: 33292 RVA: 0x00226307 File Offset: 0x00224507
	public DangoMonopolyGrid[] GetGridList(int groupId)
	{
		if (ConfigDangoMonopolyGridByGroup.GetConfigList(groupId, true) == null)
		{
			return Array.Empty<DangoMonopolyGrid>();
		}
		return ConfigDangoMonopolyGridByGroup.GetConfigList(groupId, true).ToArray<DangoMonopolyGrid>();
	}

	// Token: 0x0600820D RID: 33293 RVA: 0x00226324 File Offset: 0x00224524
	public DangoMonopolyProperty? GetProperty(int id)
	{
		return ConfigDangoMonopolyPropertyById.GetConfig(id, true);
	}

	// Token: 0x0600820E RID: 33294 RVA: 0x0022632D File Offset: 0x0022452D
	public DangoMonopolyMapPoint[] GetGridPoint(int id)
	{
		if (ConfigDangoMonopolyMapPointByActivityId.GetConfigList(id, true) == null)
		{
			return Array.Empty<DangoMonopolyMapPoint>();
		}
		return ConfigDangoMonopolyMapPointByActivityId.GetConfigList(id, true).ToArray<DangoMonopolyMapPoint>();
	}

	// Token: 0x0600820F RID: 33295 RVA: 0x0022634A File Offset: 0x0022454A
	public string GetBattleConfigPath()
	{
		return "/Game/Aki/Character/NPC/Tuanzi/CommonConfig/DangoGlobalConfig_Monopoly.DangoGlobalConfig_Monopoly";
	}

	// Token: 0x06008210 RID: 33296 RVA: 0x00226351 File Offset: 0x00224551
	public int[] GetActiveDangoAniInfo()
	{
		if (ConfigCommonParamById.GetIntArrayConfig("DangoMonopolyActiveDangoAni") == null)
		{
			return Array.Empty<int>();
		}
		return ConfigCommonParamById.GetIntArrayConfig("DangoMonopolyActiveDangoAni").ToArray<int>();
	}

	// Token: 0x06008211 RID: 33297 RVA: 0x00226374 File Offset: 0x00224574
	public bool GetIsOpenHintShow()
	{
		if (this.IsOpenHintShow == null)
		{
			this.IsOpenHintShow = new bool?(ConfigCommonParamById.GetBoolConfig("DangoMonopolyIsOpenHintShow").GetValueOrDefault());
		}
		return this.IsOpenHintShow.Value;
	}

	// Token: 0x06008212 RID: 33298 RVA: 0x002263B6 File Offset: 0x002245B6
	public void SetPushHintState(bool state)
	{
		this.IsPushHint = state;
	}

	// Token: 0x06008213 RID: 33299 RVA: 0x002263BF File Offset: 0x002245BF
	public bool GetIsPushHintShow()
	{
		return this.IsPushHint && this.GetIsOpenHintShow();
	}

	// Token: 0x06008214 RID: 33300 RVA: 0x002263D8 File Offset: 0x002245D8
	public int GetDangoMoveInTime()
	{
		return ConfigCommonParamById.GetIntConfig("MonopolyDangoInTime").GetValueOrDefault();
	}

	// Token: 0x06008215 RID: 33301 RVA: 0x002263F8 File Offset: 0x002245F8
	public int GetDangoMoveOutTime()
	{
		return ConfigCommonParamById.GetIntConfig("MonopolyDangoOutTime").GetValueOrDefault();
	}

	// Token: 0x06008216 RID: 33302 RVA: 0x00226418 File Offset: 0x00224618
	public int GetDangoMoveOutDelayTime()
	{
		return ConfigCommonParamById.GetIntConfig("MonopolyDangoOutDelayTime").GetValueOrDefault();
	}

	// Token: 0x06008217 RID: 33303 RVA: 0x00226438 File Offset: 0x00224638
	public int GetDangoChangeCheckTime()
	{
		return ConfigCommonParamById.GetIntConfig("MonopolyDangoChangeCheckTime").GetValueOrDefault();
	}

	// Token: 0x04003DE1 RID: 15841
	private bool? IsOpenHintShow;

	// Token: 0x04003DE2 RID: 15842
	private bool IsPushHint;
}
