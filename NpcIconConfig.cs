using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002330 RID: 9008
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class NpcIconConfig : ConfigBase<NpcIconConfig>
{
	// Token: 0x1700153A RID: 5434
	// (get) Token: 0x06011271 RID: 70257 RVA: 0x004B5C67 File Offset: 0x004B3E67
	public int NpcIconHeadInfoLimitMinDistanceSquared
	{
		get
		{
			return this.NpcIconHeadInfoLimitMinDistanceSquaredInternal;
		}
	}

	// Token: 0x1700153B RID: 5435
	// (get) Token: 0x06011272 RID: 70258 RVA: 0x004B5C6F File Offset: 0x004B3E6F
	public int NpcIconHeadInfoLimitMaxDistanceSquared
	{
		get
		{
			return this.NpcIconHeadInfoLimitMaxDistanceSquaredInternal;
		}
	}

	// Token: 0x06011273 RID: 70259 RVA: 0x004B5C77 File Offset: 0x004B3E77
	protected override bool OnInit()
	{
		this.GetNpcIconHeadInfoLimitMinDistance();
		this.GetNpcIconHeadInfoLimitMaxDistance();
		return true;
	}

	// Token: 0x06011274 RID: 70260 RVA: 0x004B5C88 File Offset: 0x004B3E88
	public float GetHeadStateScaleValue(float distance)
	{
		if (this.HeadStateScaleCurve == null)
		{
			this.HeadStateScaleCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/UI/UIResources/UiWorld/Curve/NPCHeadStateScaleCurve.NPCHeadStateScaleCurve");
		}
		UCurveFloat headStateScaleCurve = this.HeadStateScaleCurve;
		if (headStateScaleCurve == null)
		{
			return 1f;
		}
		return headStateScaleCurve.GetFloatValue(distance);
	}

	// Token: 0x06011275 RID: 70261 RVA: 0x004B5CBD File Offset: 0x004B3EBD
	public float GetDialogScaleValue(float distance)
	{
		if (this.DialogScaleCurve == null)
		{
			this.DialogScaleCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/UI/UIResources/UiWorld/Curve/NPCDialogScaleCurve.NPCDialogScaleCurve");
		}
		UCurveFloat dialogScaleCurve = this.DialogScaleCurve;
		if (dialogScaleCurve == null)
		{
			return 1f;
		}
		return dialogScaleCurve.GetFloatValue(distance);
	}

	// Token: 0x06011276 RID: 70262 RVA: 0x004B5CF2 File Offset: 0x004B3EF2
	[NullableContext(1)]
	public string GetNpcIconSocketName()
	{
		if (string.IsNullOrEmpty(this.NpcIconSocketName))
		{
			this.NpcIconSocketName = ConfigCommonParamById.GetStringConfig("npcicon_socketname");
		}
		return this.NpcIconSocketName;
	}

	// Token: 0x06011277 RID: 70263 RVA: 0x004B5D18 File Offset: 0x004B3F18
	public int GetNpcIconLocationOffsetZ()
	{
		if (this.NpcIconLocationOffsetZ == -1)
		{
			this.NpcIconLocationOffsetZ = ConfigCommonParamById.GetIntConfig("npcicon_location_offsetz").GetValueOrDefault();
		}
		return this.NpcIconLocationOffsetZ;
	}

	// Token: 0x06011278 RID: 70264 RVA: 0x004B5D4C File Offset: 0x004B3F4C
	public int GetNpcIconHeadInfoLimitMinDistance()
	{
		if (this.NpcIconHeadInfoLimitMinDistance == -1)
		{
			this.NpcIconHeadInfoLimitMinDistance = ConfigCommonParamById.GetIntConfig("npc_headinfo_limit_min_distance").GetValueOrDefault();
			this.NpcIconHeadInfoLimitMinDistanceSquaredInternal = this.NpcIconHeadInfoLimitMinDistance * this.NpcIconHeadInfoLimitMinDistance;
		}
		return this.NpcIconHeadInfoLimitMinDistance;
	}

	// Token: 0x06011279 RID: 70265 RVA: 0x004B5D94 File Offset: 0x004B3F94
	public int GetNpcIconHeadInfoLimitMaxDistance()
	{
		if (this.NpcIconHeadInfoLimitMaxDistance == -1)
		{
			this.NpcIconHeadInfoLimitMaxDistance = ConfigCommonParamById.GetIntConfig("npc_headinfo_limit_max_distance").GetValueOrDefault();
			this.NpcIconHeadInfoLimitMaxDistanceSquaredInternal = this.NpcIconHeadInfoLimitMaxDistance * this.NpcIconHeadInfoLimitMaxDistance;
		}
		return this.NpcIconHeadInfoLimitMaxDistance;
	}

	// Token: 0x0601127A RID: 70266 RVA: 0x004B5DDC File Offset: 0x004B3FDC
	public int GetNpcIconHeadInfoNameLimitDistance()
	{
		if (this.NpcIconHeadInfoNameLimitDistance == -1)
		{
			this.NpcIconHeadInfoNameLimitDistance = ConfigCommonParamById.GetIntConfig("npc_headinfo_name_limit_distance").GetValueOrDefault();
		}
		return this.NpcIconHeadInfoNameLimitDistance;
	}

	// Token: 0x0601127B RID: 70267 RVA: 0x004B5E10 File Offset: 0x004B4010
	public NpcHeadInfo GetNpcHeadInfo(int id)
	{
		NpcHeadInfo? config = ConfigNpcHeadInfoById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查找不到对应的NPC头顶信息数据，检查一下NPC头顶信息表格";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ID", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601127C RID: 70268 RVA: 0x004B5E64 File Offset: 0x004B4064
	public int GetPlayerInfoIconLocationOffsetZ()
	{
		if (this.PlayerInfoIconLocationOffsetZ == -1)
		{
			this.PlayerInfoIconLocationOffsetZ = ConfigCommonParamById.GetIntConfig("OnlinePlayerNameZOffset").GetValueOrDefault();
		}
		return this.PlayerInfoIconLocationOffsetZ;
	}

	// Token: 0x0601127D RID: 70269 RVA: 0x004B5E98 File Offset: 0x004B4098
	public int GetPlayerInfoNameLimitDistance()
	{
		if (this.PlayerInfoNameLimitDistance == -1)
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("OnlineTeammateDistanceThreshold");
			this.PlayerInfoNameLimitDistance = intArrayConfig[0] * 100;
			this.PlayerInfoIconLimitDistance = intArrayConfig[1] * 100;
		}
		return this.PlayerInfoNameLimitDistance;
	}

	// Token: 0x0601127E RID: 70270 RVA: 0x004B5EE0 File Offset: 0x004B40E0
	public int GetPlayerInfoIconLimitDistance()
	{
		if (this.PlayerInfoIconLimitDistance == -1)
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("OnlineTeammateDistanceThreshold");
			this.PlayerInfoNameLimitDistance = intArrayConfig[0] * 100;
			this.PlayerInfoIconLimitDistance = intArrayConfig[1] * 100;
		}
		return this.PlayerInfoIconLimitDistance;
	}

	// Token: 0x0601127F RID: 70271 RVA: 0x004B5F27 File Offset: 0x004B4127
	protected override bool OnClear()
	{
		this.NpcIconConfigMap.Clear();
		this.NpcIconSocketName = null;
		this.HeadStateScaleCurve = null;
		this.DialogScaleCurve = null;
		return true;
	}

	// Token: 0x040086E9 RID: 34537
	[Nullable(1)]
	private readonly Dictionary<int, NpcHeadInfo> NpcIconConfigMap = new Dictionary<int, NpcHeadInfo>();

	// Token: 0x040086EA RID: 34538
	private UCurveFloat HeadStateScaleCurve;

	// Token: 0x040086EB RID: 34539
	private UCurveFloat DialogScaleCurve;

	// Token: 0x040086EC RID: 34540
	private string NpcIconSocketName = "";

	// Token: 0x040086ED RID: 34541
	private int NpcIconLocationOffsetZ = -1;

	// Token: 0x040086EE RID: 34542
	private int NpcIconHeadInfoLimitMinDistance = -1;

	// Token: 0x040086EF RID: 34543
	private int NpcIconHeadInfoLimitMinDistanceSquaredInternal;

	// Token: 0x040086F0 RID: 34544
	private int NpcIconHeadInfoLimitMaxDistance = -1;

	// Token: 0x040086F1 RID: 34545
	private int NpcIconHeadInfoLimitMaxDistanceSquaredInternal;

	// Token: 0x040086F2 RID: 34546
	private int NpcIconHeadInfoNameLimitDistance = -1;

	// Token: 0x040086F3 RID: 34547
	private int PlayerInfoIconLocationOffsetZ = -1;

	// Token: 0x040086F4 RID: 34548
	private int PlayerInfoNameLimitDistance = -1;

	// Token: 0x040086F5 RID: 34549
	private int PlayerInfoIconLimitDistance = -1;
}
