using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020017A9 RID: 6057
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AutoRunModel : ModelBase<AutoRunModel>
{
	// Token: 0x0600AADD RID: 43741 RVA: 0x002DA3A0 File Offset: 0x002D85A0
	protected override bool OnInit()
	{
		this.AutoRunMode = EAutoRunMode.Disabled;
		this.GmSkipTreeType = BtType.Invalid;
		this.GmSkipTreeConfigId = 0;
		this.GmSkipNodeId = 0;
		return true;
	}

	// Token: 0x0600AADE RID: 43742 RVA: 0x002DA3BF File Offset: 0x002D85BF
	protected override bool OnClear()
	{
		this.ClearAllOverrideTpInfo();
		this.ClearAllGuaranteeTpInfo();
		this.ClearCachedDataLayerInfo();
		return true;
	}

	// Token: 0x0600AADF RID: 43743 RVA: 0x002DA3D4 File Offset: 0x002D85D4
	public EAutoRunState GetAutoRunState()
	{
		return this.AutoRunState;
	}

	// Token: 0x0600AAE0 RID: 43744 RVA: 0x002DA3DC File Offset: 0x002D85DC
	public unsafe void SetAutoRunState(EAutoRunState autoRunState)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Gm;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "[Gm一键推进] AutoRunState改变";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原AutoRunState", this.AutoRunState);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("新AutoRunState", autoRunState);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.AutoRunState != autoRunState)
		{
			this.AutoRunState = autoRunState;
			ModelBase<SundryModel>.Instance.IsBlockTips = this.IsInLogicTreeGmMode();
			ModelBase<GuideModel>.Instance.SetGmLock(this.IsInLogicTreeGmMode());
			Singleton<EventSystem>.Instance.Emit<EAutoRunState>(EEventName.GmAutoModeChange, autoRunState);
		}
	}

	// Token: 0x0600AAE1 RID: 43745 RVA: 0x002DA491 File Offset: 0x002D8691
	public bool IsInLogicTreeGmMode()
	{
		return this.AutoRunMode != EAutoRunMode.Disabled && this.AutoRunState == EAutoRunState.Running;
	}

	// Token: 0x0600AAE2 RID: 43746 RVA: 0x002DA4A6 File Offset: 0x002D86A6
	public bool IsInAfterRunningState()
	{
		return this.AutoRunMode != EAutoRunMode.Disabled && this.AutoRunState == EAutoRunState.AfterRunning;
	}

	// Token: 0x0600AAE3 RID: 43747 RVA: 0x002DA4BB File Offset: 0x002D86BB
	public bool IsInServerControlGmMode()
	{
		return this.AutoRunMode == EAutoRunMode.ServerControlledSkip;
	}

	// Token: 0x0600AAE4 RID: 43748 RVA: 0x002DA4C6 File Offset: 0x002D86C6
	public EAutoRunMode GetAutoRunMode()
	{
		return this.AutoRunMode;
	}

	// Token: 0x0600AAE5 RID: 43749 RVA: 0x002DA4CE File Offset: 0x002D86CE
	public void SetAutoRunMode(EAutoRunMode gmAutoMode, BtType treeType = BtType.Invalid, int treeConfigId = 0, int nodeId = 0)
	{
		this.AutoRunMode = gmAutoMode;
		this.GmSkipTreeType = treeType;
		this.GmSkipTreeConfigId = treeConfigId;
		this.GmSkipNodeId = nodeId;
	}

	// Token: 0x0600AAE6 RID: 43750 RVA: 0x002DA4ED File Offset: 0x002D86ED
	public void StopAutoRunAndClearInfo()
	{
		this.SetAutoRunState(EAutoRunState.Stopped);
		this.ClearAutoRunInfo();
	}

	// Token: 0x0600AAE7 RID: 43751 RVA: 0x002DA4FC File Offset: 0x002D86FC
	public void ClearAutoRunInfo()
	{
		this.SetAutoRunMode(EAutoRunMode.Disabled, BtType.Invalid, 0, 0);
		this.ShouldFastSkip = false;
		this.ShouldTpAfterSkip = false;
		this.ShouldTpAfterSkip = false;
		this.ClearAllOverrideTpInfo();
		this.ClearAllGuaranteeTpInfo();
		this.ClearCachedDataLayerInfo();
	}

	// Token: 0x0600AAE8 RID: 43752 RVA: 0x002DA52F File Offset: 0x002D872F
	public BtType GetGmSkipTreeType()
	{
		return this.GmSkipTreeType;
	}

	// Token: 0x0600AAE9 RID: 43753 RVA: 0x002DA537 File Offset: 0x002D8737
	public int GetGmSkipTreeConfigId()
	{
		return this.GmSkipTreeConfigId;
	}

	// Token: 0x0600AAEA RID: 43754 RVA: 0x002DA53F File Offset: 0x002D873F
	public int GetGmSkipNodeId()
	{
		return this.GmSkipNodeId;
	}

	// Token: 0x0600AAEB RID: 43755 RVA: 0x002DA548 File Offset: 0x002D8748
	[NullableContext(2)]
	public TeleportInfo GetGuaranteeTpInfo(int? instanceId = null)
	{
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		TeleportInfo result;
		if (!this.GuaranteeTpInfos.TryGetValue(key, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600AAEC RID: 43756 RVA: 0x002DA588 File Offset: 0x002D8788
	[NullableContext(2)]
	public void SetGuaranteeTpInfo(TeleportInfo tpInfo, int? instanceId = null)
	{
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (tpInfo != null)
		{
			this.GuaranteeTpInfos[key] = tpInfo;
			return;
		}
		this.GuaranteeTpInfos.Remove(key);
	}

	// Token: 0x0600AAED RID: 43757 RVA: 0x002DA5D2 File Offset: 0x002D87D2
	public void ClearAllGuaranteeTpInfo()
	{
		this.GuaranteeTpInfos.Clear();
	}

	// Token: 0x0600AAEE RID: 43758 RVA: 0x002DA5E0 File Offset: 0x002D87E0
	[NullableContext(2)]
	public TeleportInfo GetOverrideTpInfo(int? instanceId = null)
	{
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		TeleportInfo result;
		if (!this.OverrideTpInfos.TryGetValue(key, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600AAEF RID: 43759 RVA: 0x002DA620 File Offset: 0x002D8820
	[NullableContext(2)]
	public void SetOverrideTpInfo(TeleportInfo tpInfo, int? instanceId = null)
	{
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (tpInfo != null)
		{
			this.OverrideTpInfos[key] = tpInfo;
			return;
		}
		this.OverrideTpInfos.Remove(key);
	}

	// Token: 0x0600AAF0 RID: 43760 RVA: 0x002DA66A File Offset: 0x002D886A
	public void ClearAllOverrideTpInfo()
	{
		this.OverrideTpInfos.Clear();
	}

	// Token: 0x0600AAF1 RID: 43761 RVA: 0x002DA678 File Offset: 0x002D8878
	[NullableContext(2)]
	public GmDataLayerInfo GetCachedDataLayerInfo(int? instanceId = null)
	{
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		GmDataLayerInfo result;
		if (!this.CachedDataLayerInfos.TryGetValue(key, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600AAF2 RID: 43762 RVA: 0x002DA6B8 File Offset: 0x002D88B8
	public void UpdateCachedDataLayerInfo(IList<int> newLoads, IList<int> newUnloads, int? instanceId = null)
	{
		if (newLoads.Count == 0 && newUnloads.Count == 0)
		{
			return;
		}
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		foreach (int p0Id in newLoads)
		{
			DataLayerConfig? config = ConfigDataLayerConfigById.GetConfig(p0Id, true);
			if (config != null)
			{
				list.Add(config.Value.DataLayer);
			}
		}
		foreach (int p0Id2 in newUnloads)
		{
			DataLayerConfig? config2 = ConfigDataLayerConfigById.GetConfig(p0Id2, true);
			if (config2 != null)
			{
				list2.Add(config2.Value.DataLayer);
			}
		}
		GmDataLayerInfo gmDataLayerInfo2;
		GmDataLayerInfo gmDataLayerInfo = this.CachedDataLayerInfos.TryGetValue(key, out gmDataLayerInfo2) ? gmDataLayerInfo2 : null;
		if (gmDataLayerInfo == null)
		{
			gmDataLayerInfo = new GmDataLayerInfo(new HashSet<string>(), new HashSet<string>());
			this.CachedDataLayerInfos[key] = gmDataLayerInfo;
		}
		foreach (string item in list)
		{
			gmDataLayerInfo.LoadDataLayers.Add(item);
			gmDataLayerInfo.UnloadDataLayers.Remove(item);
		}
		foreach (string item2 in list2)
		{
			gmDataLayerInfo.UnloadDataLayers.Add(item2);
			gmDataLayerInfo.LoadDataLayers.Remove(item2);
		}
	}

	// Token: 0x0600AAF3 RID: 43763 RVA: 0x002DA89C File Offset: 0x002D8A9C
	public void UpdateCachedDataLayerInfo(IList<string> newLoads, IList<string> newUnloads, int? instanceId = null)
	{
		if (newLoads.Count == 0 && newUnloads.Count == 0)
		{
			return;
		}
		int key = instanceId ?? ModelBase<CreatureModel>.Instance.GetInstanceId();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		foreach (string item in newLoads)
		{
			list.Add(item);
		}
		foreach (string item2 in newUnloads)
		{
			list2.Add(item2);
		}
		GmDataLayerInfo gmDataLayerInfo2;
		GmDataLayerInfo gmDataLayerInfo = this.CachedDataLayerInfos.TryGetValue(key, out gmDataLayerInfo2) ? gmDataLayerInfo2 : null;
		if (gmDataLayerInfo == null)
		{
			gmDataLayerInfo = new GmDataLayerInfo(new HashSet<string>(), new HashSet<string>());
			this.CachedDataLayerInfos[key] = gmDataLayerInfo;
		}
		foreach (string item3 in list)
		{
			gmDataLayerInfo.LoadDataLayers.Add(item3);
			gmDataLayerInfo.UnloadDataLayers.Remove(item3);
		}
		foreach (string item4 in list2)
		{
			gmDataLayerInfo.UnloadDataLayers.Add(item4);
			gmDataLayerInfo.LoadDataLayers.Remove(item4);
		}
	}

	// Token: 0x0600AAF4 RID: 43764 RVA: 0x002DAA44 File Offset: 0x002D8C44
	public void ClearCachedDataLayerInfo()
	{
		this.CachedDataLayerInfos.Clear();
	}

	// Token: 0x04005149 RID: 20809
	private EAutoRunState AutoRunState;

	// Token: 0x0400514A RID: 20810
	private EAutoRunMode AutoRunMode;

	// Token: 0x0400514B RID: 20811
	private BtType GmSkipTreeType;

	// Token: 0x0400514C RID: 20812
	private int GmSkipTreeConfigId;

	// Token: 0x0400514D RID: 20813
	private int GmSkipNodeId;

	// Token: 0x0400514E RID: 20814
	public bool ShouldTpAfterSkip;

	// Token: 0x0400514F RID: 20815
	public bool ShouldFastSkip;

	// Token: 0x04005150 RID: 20816
	private readonly Dictionary<int, TeleportInfo> OverrideTpInfos = new Dictionary<int, TeleportInfo>();

	// Token: 0x04005151 RID: 20817
	private readonly Dictionary<int, TeleportInfo> GuaranteeTpInfos = new Dictionary<int, TeleportInfo>();

	// Token: 0x04005152 RID: 20818
	private readonly Dictionary<int, GmDataLayerInfo> CachedDataLayerInfos = new Dictionary<int, GmDataLayerInfo>();
}
