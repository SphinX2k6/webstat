using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F69 RID: 8041
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryTechnologyAreaItem : GridProxyAbstract<HonamiStoryTechAreaData>
{
	// Token: 0x1700125C RID: 4700
	// (get) Token: 0x0600F0D0 RID: 61648 RVA: 0x0041CEDE File Offset: 0x0041B0DE
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, HonamiStoryTechnologyNodeItem> GetNodeItemMap
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.NodeItemMap;
		}
	}

	// Token: 0x0600F0D1 RID: 61649 RVA: 0x0041CEE8 File Offset: 0x0041B0E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x0600F0D2 RID: 61650 RVA: 0x0041CFC8 File Offset: 0x0041B1C8
	protected override void OnStart()
	{
		this.NodeItemMap = new Dictionary<int, HonamiStoryTechnologyNodeItem>();
	}

	// Token: 0x0600F0D3 RID: 61651 RVA: 0x0041CFD5 File Offset: 0x0041B1D5
	protected override void OnBeforeDestroy()
	{
		this.NodeItemMap = null;
	}

	// Token: 0x0600F0D4 RID: 61652 RVA: 0x0041CFE0 File Offset: 0x0041B1E0
	public override void Refresh(HonamiStoryTechAreaData areaData, bool isSelected, int gridIndex)
	{
		List<int> nodeIds = areaData.NodeIds;
		string text = (gridIndex + 1).ToString();
		UUISprite sprite = base.GetSprite(14);
		string path = StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}", new string[]
		{
			text,
			text
		});
		this.SetSpriteByPath(path, sprite, true, null, null);
		List<int> list = new List<int>();
		List<HonamiStoryTechNodeData> list2 = new List<HonamiStoryTechNodeData>();
		foreach (int id in nodeIds)
		{
			HonamiStoryTechNodeData techNodeData = ModelBase<HonamiStoryModel>.Instance.GetTechNodeData(id);
			if (techNodeData != null)
			{
				list.Add(techNodeData.GetConfig.IndexId);
				list2.Add(techNodeData);
			}
		}
		for (int i = 0; i <= 6; i++)
		{
			bool uiactive = list.Contains(i + 1);
			base.GetItem(i).SetUIActive(uiactive);
		}
		this.RefreshArea(list2);
	}

	// Token: 0x0600F0D5 RID: 61653 RVA: 0x0041D0E8 File Offset: 0x0041B2E8
	public void RefreshArea(List<HonamiStoryTechNodeData> nodeDataList)
	{
		HonamiStoryTechnologyAreaItem.<>c__DisplayClass10_0 CS$<>8__locals1 = new HonamiStoryTechnologyAreaItem.<>c__DisplayClass10_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.nodeDataList = nodeDataList;
		UiAsyncTask task = new UiAsyncTask("RefreshArea", delegate()
		{
			HonamiStoryTechnologyAreaItem.<>c__DisplayClass10_0.<<RefreshArea>b__0>d <<RefreshArea>b__0>d;
			<<RefreshArea>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshArea>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshArea>b__0>d.<>1__state = -1;
			<<RefreshArea>b__0>d.<>t__builder.Start<HonamiStoryTechnologyAreaItem.<>c__DisplayClass10_0.<<RefreshArea>b__0>d>(ref <<RefreshArea>b__0>d);
			return <<RefreshArea>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600F0D6 RID: 61654 RVA: 0x0041D12C File Offset: 0x0041B32C
	private UniTask RefreshAreaItemAsync(List<HonamiStoryTechNodeData> nodeDataList)
	{
		HonamiStoryTechnologyAreaItem.<RefreshAreaItemAsync>d__11 <RefreshAreaItemAsync>d__;
		<RefreshAreaItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAreaItemAsync>d__.<>4__this = this;
		<RefreshAreaItemAsync>d__.nodeDataList = nodeDataList;
		<RefreshAreaItemAsync>d__.<>1__state = -1;
		<RefreshAreaItemAsync>d__.<>t__builder.Start<HonamiStoryTechnologyAreaItem.<RefreshAreaItemAsync>d__11>(ref <RefreshAreaItemAsync>d__);
		return <RefreshAreaItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0D7 RID: 61655 RVA: 0x0041D177 File Offset: 0x0041B377
	public void CloseLineRight()
	{
		base.GetItem(10).SetUIActive(false);
	}

	// Token: 0x040073AE RID: 29614
	private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}";

	// Token: 0x040073AF RID: 29615
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, HonamiStoryTechnologyNodeItem> NodeItemMap;

	// Token: 0x040073B0 RID: 29616
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<HonamiStoryTechnologyNodeItem> OnAfterRefreshOneNode;

	// Token: 0x020082FB RID: 33531
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C68A RID: 181898
		LeftSkillItem,
		// Token: 0x0402C68B RID: 181899
		TopSkillItem,
		// Token: 0x0402C68C RID: 181900
		MiddleSkillItem,
		// Token: 0x0402C68D RID: 181901
		BottomSkillItem,
		// Token: 0x0402C68E RID: 181902
		ExtraSkillItemA,
		// Token: 0x0402C68F RID: 181903
		ExtraSkillItemB,
		// Token: 0x0402C690 RID: 181904
		ExtraSkillItemC,
		// Token: 0x0402C691 RID: 181905
		line1,
		// Token: 0x0402C692 RID: 181906
		line2,
		// Token: 0x0402C693 RID: 181907
		line3,
		// Token: 0x0402C694 RID: 181908
		lineRight,
		// Token: 0x0402C695 RID: 181909
		line5,
		// Token: 0x0402C696 RID: 181910
		line6,
		// Token: 0x0402C697 RID: 181911
		line7,
		// Token: 0x0402C698 RID: 181912
		SprTopNum
	}
}
