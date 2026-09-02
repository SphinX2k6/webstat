using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C0B RID: 19467
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrBuildInfoPanel : UiPanelBase
	{
		// Token: 0x06032CA5 RID: 208037 RVA: 0x00CB96C0 File Offset: 0x00CB78C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText))
			};
		}

		// Token: 0x06032CA6 RID: 208038 RVA: 0x00CB9814 File Offset: 0x00CB7A14
		private InfrV2TreeBuild GetTreeConfig()
		{
			return ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId).Value;
		}

		// Token: 0x06032CA7 RID: 208039 RVA: 0x00CB983C File Offset: 0x00CB7A3C
		private InfrV2Level GetVillageConfig()
		{
			return ConfigBase<VillageInfrConfig>.Instance.GetInfrLevel(this.SelectId).Value;
		}

		// Token: 0x06032CA8 RID: 208040 RVA: 0x00CB9864 File Offset: 0x00CB7A64
		private string GetDescription()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				return this.GetTreeConfig().Description;
			}
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				return this.GetVillageConfig().Description;
			}
			return "";
		}

		// Token: 0x06032CA9 RID: 208041 RVA: 0x00CB98A8 File Offset: 0x00CB7AA8
		private string GetMapTexturePath()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				return this.GetTreeConfig().InfoPicturePath;
			}
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				return this.GetVillageConfig().InfoPicturePath;
			}
			return "";
		}

		// Token: 0x06032CAA RID: 208042 RVA: 0x00CB98EA File Offset: 0x00CB7AEA
		private bool GetIsLock()
		{
			return this.SelectType == EVillageInfrSelectType.Tree && !ModelBase<VillageInfrModel>.Instance.GetTreeIsUnlock(this.SelectId);
		}

		// Token: 0x06032CAB RID: 208043 RVA: 0x00CB990C File Offset: 0x00CB7B0C
		private void SetOpenParam()
		{
			IVillageInfrBuildInfoParam villageInfrBuildInfoParam = this.OpenParam as IVillageInfrBuildInfoParam;
			this.SelectType = villageInfrBuildInfoParam.SelectType;
			this.SelectId = villageInfrBuildInfoParam.SelectId;
		}

		// Token: 0x06032CAC RID: 208044 RVA: 0x00CB993D File Offset: 0x00CB7B3D
		private void CreateMissionList()
		{
			this.MissionList = new GenericLayout<VillageInfrMissionListItem, IVillageInfrBuildQuestParam>(base.GetVerticalLayout(5), () => new VillageInfrMissionListItem(), null, false, true);
		}

		// Token: 0x06032CAD RID: 208045 RVA: 0x00CB9973 File Offset: 0x00CB7B73
		private void CreateDescList()
		{
			this.DescList = new GenericLayout<VillageInfrBuildInfoDescItem, string>(base.GetVerticalLayout(9), () => new VillageInfrBuildInfoDescItem(), null, false, true);
		}

		// Token: 0x06032CAE RID: 208046 RVA: 0x00CB99AA File Offset: 0x00CB7BAA
		protected override void OnStart()
		{
			this.SetOpenParam();
			this.CreateMissionList();
			this.CreateDescList();
			this.Refresh(null);
		}

		// Token: 0x06032CAF RID: 208047 RVA: 0x00CB99C5 File Offset: 0x00CB7BC5
		[NullableContext(2)]
		public void Refresh(IVillageInfrBuildInfoParam param = null)
		{
			if (param != null)
			{
				this.OpenParam = param;
				this.SetOpenParam();
			}
			this.RefreshEmpty();
			this.RefreshTitle();
			this.RefreshMap();
			this.RefreshDesc();
			this.RefreshMissionList();
		}

		// Token: 0x06032CB0 RID: 208048 RVA: 0x00CB99F8 File Offset: 0x00CB7BF8
		private void RefreshEmpty()
		{
			base.GetItem(0).SetUIActive(this.GetIsLock());
			if (this.GetIsLock())
			{
				int lockJumpId = this.GetTreeConfig().LockJumpId;
				int questId = int.Parse(ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(lockJumpId).Value.Val1);
				string questName = ModelBase<QuestNewModel>.Instance.GetQuestName(questId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "VillageInfr_Tree_LockingTips", new <>z__ReadOnlySingleElementList<object>(questName));
			}
		}

		// Token: 0x06032CB1 RID: 208049 RVA: 0x00CB9A7A File Offset: 0x00CB7C7A
		private void RefreshTitle()
		{
			if (this.GetIsLock())
			{
				base.GetItem(3).SetUIActive(false);
				return;
			}
			base.GetItem(3).SetUIActive(true);
			base.GetText(4).ShowTextNew(this.GetDescription());
		}

		// Token: 0x06032CB2 RID: 208050 RVA: 0x00CB9AB4 File Offset: 0x00CB7CB4
		private void RefreshMap()
		{
			if (this.GetIsLock())
			{
				base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(false);
				return;
			}
			base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(true);
			base.SetTextureByPath(this.GetMapTexturePath(), base.GetTexture(2), null, null);
		}

		// Token: 0x06032CB3 RID: 208051 RVA: 0x00CB9B1C File Offset: 0x00CB7D1C
		private void RefreshMissionList()
		{
			if (this.GetIsLock() || this.SelectType == EVillageInfrSelectType.Village)
			{
				this.MissionList.SetActive(false);
				return;
			}
			this.MissionList.SetActive(true);
			List<IVillageInfrBuildQuestParam> list = new List<IVillageInfrBuildQuestParam>();
			foreach (int id in this.GetTreeConfig().QuestAccessPath())
			{
				list.Add(new VillageInfrBuildQuestParam
				{
					Id = id,
					SelectId = this.SelectId
				});
			}
			this.MissionList.RefreshByData(list, null, false);
		}

		// Token: 0x06032CB4 RID: 208052 RVA: 0x00CB9BA8 File Offset: 0x00CB7DA8
		private void RefreshDesc()
		{
			if (this.GetIsLock() || this.SelectType == EVillageInfrSelectType.Tree)
			{
				base.GetItem(7).SetUIActive(false);
				base.GetItem(11).SetUIActive(false);
				return;
			}
			VillageInfrConfig instance = ConfigBase<VillageInfrConfig>.Instance;
			List<IVillageInfrTreeData> allTreeData = ModelBase<VillageInfrModel>.Instance.GetAllTreeData();
			List<IVillageInfrTreeData> list = new List<IVillageInfrTreeData>();
			foreach (IVillageInfrTreeData villageInfrTreeData in allTreeData)
			{
				if (villageInfrTreeData.Status != InfrV2StatusPb.InfrV2StatusComplete)
				{
					list.Add(villageInfrTreeData);
				}
			}
			list.Sort((IVillageInfrTreeData a, IVillageInfrTreeData b) => a.Id - b.Id);
			if (list.Count > 0)
			{
				base.GetItem(7).SetUIActive(true);
				base.GetItem(11).SetUIActive(false);
				List<string> list2 = new List<string>();
				foreach (IVillageInfrTreeData villageInfrTreeData2 in list)
				{
					list2.Add(instance.GetInfrTreeBuild(villageInfrTreeData2.Id).Value.Name);
				}
				this.DescList.RefreshByData(list2, null, false);
				return;
			}
			base.GetItem(7).SetUIActive(false);
			base.GetItem(11).SetUIActive(true);
		}

		// Token: 0x0401D8E6 RID: 121062
		private int SelectId;

		// Token: 0x0401D8E7 RID: 121063
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D8E8 RID: 121064
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<VillageInfrMissionListItem, IVillageInfrBuildQuestParam> MissionList;

		// Token: 0x0401D8E9 RID: 121065
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<VillageInfrBuildInfoDescItem, string> DescList;
	}
}
