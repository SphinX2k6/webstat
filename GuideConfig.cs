using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x02001E1F RID: 7711
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GuideConfig : ConfigBase<GuideConfig>
{
	// Token: 0x0600E391 RID: 58257 RVA: 0x003D41DF File Offset: 0x003D23DF
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600E392 RID: 58258 RVA: 0x003D41E2 File Offset: 0x003D23E2
	[NullableContext(2)]
	public IReadOnlyList<GuideTutorial> GetAllTutorial()
	{
		return ConfigGuideTutorialAll.GetConfigList(true);
	}

	// Token: 0x0600E393 RID: 58259 RVA: 0x003D41EC File Offset: 0x003D23EC
	public GuideStep? GetStep(int stepId)
	{
		return new GuideStep?(ConfigGuideStepById.GetConfig(stepId, true).Value);
	}

	// Token: 0x0600E394 RID: 58260 RVA: 0x003D4210 File Offset: 0x003D2410
	public GuideTutorialPage? GetGuideTutorialPage(int pageId)
	{
		return new GuideTutorialPage?(ConfigGuideTutorialPageById.GetConfig(pageId, true).Value);
	}

	// Token: 0x0600E395 RID: 58261 RVA: 0x003D4234 File Offset: 0x003D2434
	public int[] GetGuideTutorialPageIds(int stepId)
	{
		GuideTutorial value = this.GetGuideTutorial(stepId).Value;
		int pageReplaceConditionGroupId = value.PageReplaceConditionGroupId;
		if (pageReplaceConditionGroupId <= 0)
		{
			return value.PageId();
		}
		if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(pageReplaceConditionGroupId.ToString(), null, true, Array.Empty<object>()))
		{
			return value.PageId();
		}
		return value.ReplacePageId();
	}

	// Token: 0x0600E396 RID: 58262 RVA: 0x003D4290 File Offset: 0x003D2490
	public GuideTutorial? GetGuideTutorial(int stepId)
	{
		return new GuideTutorial?(ConfigGuideTutorialById.GetConfig(stepId, true).Value);
	}

	// Token: 0x0600E397 RID: 58263 RVA: 0x003D42B4 File Offset: 0x003D24B4
	public GuideFocusNew? GetGuideFocus(int stepId)
	{
		return new GuideFocusNew?(ConfigGuideFocusNewByGuideId.GetConfig(stepId, true).Value);
	}

	// Token: 0x0600E398 RID: 58264 RVA: 0x003D42D8 File Offset: 0x003D24D8
	public GuideTips? GetGuideTips(int stepId)
	{
		return new GuideTips?(ConfigGuideTipsByGuideId.GetConfig(stepId, true).Value);
	}

	// Token: 0x0600E399 RID: 58265 RVA: 0x003D42F9 File Offset: 0x003D24F9
	public string GetGuideText(string textId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(textId, null) ?? "";
	}

	// Token: 0x0600E39A RID: 58266 RVA: 0x003D430C File Offset: 0x003D250C
	public GuideDungeonSetDefine? GetGuideDungeonSet(string setId)
	{
		return new GuideDungeonSetDefine?(ConfigGuideDungeonSetDefineByStrId.GetConfig(setId, true).Value);
	}

	// Token: 0x0600E39B RID: 58267 RVA: 0x003D432D File Offset: 0x003D252D
	[NullableContext(2)]
	public IReadOnlyList<int> GetGuideTopMiddleOffset()
	{
		return ConfigCommonParamById.GetIntArrayConfig("guide_top_middle_offset");
	}

	// Token: 0x0600E39C RID: 58268 RVA: 0x003D4339 File Offset: 0x003D2539
	[NullableContext(2)]
	public IReadOnlyList<GuideGroup> GetAllGroup()
	{
		return ConfigGuideGroupAll.GetConfigList(true);
	}

	// Token: 0x0600E39D RID: 58269 RVA: 0x003D4341 File Offset: 0x003D2541
	public GuideGroup? GetGroup(int groupId)
	{
		return ConfigGuideGroupById.GetConfig(groupId, true);
	}

	// Token: 0x0600E39E RID: 58270 RVA: 0x003D434C File Offset: 0x003D254C
	public int[] GetOrderedStepIdsOfGroup(int groupId, EInputControllerMainType controllerType)
	{
		List<int> list = new List<int>();
		GuideGroup? group = this.GetGroup(groupId);
		int index;
		if (group != null && this.inputControllerType2IndexInConfig.TryGetValue(controllerType, out index))
		{
			foreach (int num in group.Value.Step())
			{
				if (this.GetStep(num).Value.Controller[index] == 'T')
				{
					list.Add(num);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E39F RID: 58271 RVA: 0x003D43DC File Offset: 0x003D25DC
	public HashSet<int> GetLimitRepeatStepSetOfGroup(int groupId)
	{
		HashSet<int> hashSet = new HashSet<int>();
		GuideGroup? group = this.GetGroup(groupId);
		if (group != null)
		{
			foreach (int item in group.Value.LimitRepeat())
			{
				hashSet.Add(item);
			}
		}
		return hashSet;
	}

	// Token: 0x0600E3A0 RID: 58272 RVA: 0x003D4430 File Offset: 0x003D2630
	[NullableContext(2)]
	public HashSet<int> GetBreakExcludeStepIdSetOfGroup(int groupId)
	{
		GuideGroup? group = this.GetGroup(groupId);
		if (group == null || group.Value.PriorityBreakExcludeLength == 0)
		{
			return null;
		}
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < group.Value.PriorityBreakExcludeLength; i++)
		{
			hashSet.Add(group.Value.PriorityBreakExclude(i));
		}
		return hashSet;
	}

	// Token: 0x0600E3A1 RID: 58273 RVA: 0x003D449C File Offset: 0x003D269C
	public FVectorDouble GetGuideFocusCenterTextPos()
	{
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("GuideFocusTextOffsetY").GetValueOrDefault();
		return new FVectorDouble(0.0, 0.0, (double)valueOrDefault);
	}

	// Token: 0x04006D81 RID: 28033
	public bool GmMuteTutorial;

	// Token: 0x04006D82 RID: 28034
	public readonly Dictionary<EInputControllerMainType, int> inputControllerType2IndexInConfig = new Dictionary<EInputControllerMainType, int>
	{
		{
			EInputControllerMainType.Keyboard,
			0
		},
		{
			EInputControllerMainType.Gamepad,
			1
		},
		{
			EInputControllerMainType.Touch,
			2
		}
	};

	// Token: 0x04006D83 RID: 28035
	public readonly string TabTag = "tab";

	// Token: 0x04006D84 RID: 28036
	public readonly string SlotTag = "slot";
}
