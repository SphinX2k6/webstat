using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using UnrealEngine;

// Token: 0x02003472 RID: 13426
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class HierarchyLoadingController : ControllerBase<HierarchyLoadingController>
{
	// Token: 0x0601C4E0 RID: 115936 RVA: 0x00878010 File Offset: 0x00876210
	private string[] GetHideDataLayerByImageQualityLevel(int level)
	{
		Dictionary<int, EQualityHierarchyLevel> dictionary = Singleton<Info>.Instance.IsPcOrGamepadPlatform() ? this.QualityLevelPCMap : this.QualityLevelMobileMap;
		if (!dictionary.ContainsKey(level))
		{
			return Array.Empty<string>();
		}
		EQualityHierarchyLevel key = dictionary[level];
		return this.DataLayerHideLevelMap.GetValueOrDefault(key, Array.Empty<string>());
	}

	// Token: 0x0601C4E1 RID: 115937 RVA: 0x00878060 File Offset: 0x00876260
	private void HookLoadDataLayers()
	{
		Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.RY, "触发datalayer切换", default(ReadOnlySpan<ValueTuple<string, object>>));
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		if (gameUserSettings == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.RY, "GetGameUserSettings失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int gameQualitySettingLevel = gameUserSettings.GetGameQualitySettingLevel();
		string[] hideDataLayerByImageQualityLevel = this.GetHideDataLayerByImageQualityLevel(gameQualitySettingLevel);
		foreach (string text in this.AllDataLayers)
		{
			if (hideDataLayerByImageQualityLevel.Contains(text))
			{
				ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(text, false, false);
			}
			else
			{
				ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(text, true, false);
			}
		}
	}

	// Token: 0x0601C4E2 RID: 115938 RVA: 0x0087810E File Offset: 0x0087630E
	protected override bool OnInit()
	{
		this.AddEvents();
		return true;
	}

	// Token: 0x0601C4E3 RID: 115939 RVA: 0x00878117 File Offset: 0x00876317
	protected override bool OnClear()
	{
		this.RemoveEvents();
		return true;
	}

	// Token: 0x0601C4E4 RID: 115940 RVA: 0x00878120 File Offset: 0x00876320
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SetImageQualityWithValue, new Action<int>(this.OnSetImageQuality));
		Singleton<EventSystem>.Instance.Add(EEventName.EndTravelMap, new Action(this.OnEndTravelMap));
	}

	// Token: 0x0601C4E5 RID: 115941 RVA: 0x0087815A File Offset: 0x0087635A
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SetImageQualityWithValue, new Action<int>(this.OnSetImageQuality));
		Singleton<EventSystem>.Instance.Remove(EEventName.EndTravelMap, new Action(this.OnEndTravelMap));
	}

	// Token: 0x0601C4E6 RID: 115942 RVA: 0x00878194 File Offset: 0x00876394
	private void OnSetImageQuality(int settingLevel)
	{
		this.HookLoadDataLayers();
	}

	// Token: 0x0601C4E7 RID: 115943 RVA: 0x0087819C File Offset: 0x0087639C
	private void OnEndTravelMap()
	{
		this.HookLoadDataLayers();
	}

	// Token: 0x0400E3A7 RID: 58279
	private readonly string[] AllDataLayers = new string[]
	{
		"DataLayerRuntime_HideInLow",
		"DataLayerRuntime_HideInMedium",
		"DataLayerRuntime_HideInHigh"
	};

	// Token: 0x0400E3A8 RID: 58280
	private readonly Dictionary<EQualityHierarchyLevel, string[]> DataLayerHideLevelMap = new Dictionary<EQualityHierarchyLevel, string[]>
	{
		{
			EQualityHierarchyLevel.Low,
			new string[]
			{
				"DataLayerRuntime_HideInLow",
				"DataLayerRuntime_HideInMedium",
				"DataLayerRuntime_HideInHigh"
			}
		},
		{
			EQualityHierarchyLevel.Medium,
			new string[]
			{
				"DataLayerRuntime_HideInMedium",
				"DataLayerRuntime_HideInHigh"
			}
		},
		{
			EQualityHierarchyLevel.High,
			new string[]
			{
				"DataLayerRuntime_HideInHigh"
			}
		}
	};

	// Token: 0x0400E3A9 RID: 58281
	private readonly Dictionary<int, EQualityHierarchyLevel> QualityLevelPCMap = new Dictionary<int, EQualityHierarchyLevel>
	{
		{
			0,
			EQualityHierarchyLevel.Low
		},
		{
			1,
			EQualityHierarchyLevel.Low
		},
		{
			2,
			EQualityHierarchyLevel.Low
		},
		{
			3,
			EQualityHierarchyLevel.Medium
		},
		{
			4,
			EQualityHierarchyLevel.High
		},
		{
			5,
			EQualityHierarchyLevel.Highest
		}
	};

	// Token: 0x0400E3AA RID: 58282
	private readonly Dictionary<int, EQualityHierarchyLevel> QualityLevelMobileMap = new Dictionary<int, EQualityHierarchyLevel>
	{
		{
			0,
			EQualityHierarchyLevel.Low
		},
		{
			1,
			EQualityHierarchyLevel.Low
		},
		{
			2,
			EQualityHierarchyLevel.Low
		},
		{
			3,
			EQualityHierarchyLevel.Medium
		},
		{
			4,
			EQualityHierarchyLevel.High
		}
	};
}
