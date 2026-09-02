using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005225 RID: 21029
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleSummaryRoleItem : UiPanelBase
	{
		// Token: 0x06035E1C RID: 220700 RVA: 0x00D8FB94 File Offset: 0x00D8DD94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickMore))
			};
		}

		// Token: 0x06035E1D RID: 220701 RVA: 0x00D8FC69 File Offset: 0x00D8DE69
		protected override void OnStart()
		{
			this.LoopScroll = new GenericScrollViewNew<RogueBattleMapRoleLayoutGrid, IRogueBattleMapRoleGridInfo>(base.GetScrollViewWithScrollbar(5), new Func<RogueBattleMapRoleLayoutGrid>(this.CreateLoopItem), null, false, null);
			this.InitAttributeItemList();
		}

		// Token: 0x06035E1E RID: 220702 RVA: 0x00D8FC92 File Offset: 0x00D8DE92
		protected override void OnBeforeShow()
		{
			this.UpdateAttribute();
			this.RefreshFormation();
		}

		// Token: 0x06035E1F RID: 220703 RVA: 0x00D8FCA0 File Offset: 0x00D8DEA0
		protected override void OnBeforeDestroy()
		{
			this.LoopScroll = null;
			foreach (AttributeItem attributeItem in this.AttributeItemList)
			{
				attributeItem.Destroy(null);
			}
			this.AttributeItemList.Clear();
		}

		// Token: 0x06035E20 RID: 220704 RVA: 0x00D8FD04 File Offset: 0x00D8DF04
		private RogueBattleMapRoleLayoutGrid CreateLoopItem()
		{
			return new RogueBattleMapRoleLayoutGrid();
		}

		// Token: 0x06035E21 RID: 220705 RVA: 0x00D8FD0C File Offset: 0x00D8DF0C
		private void RefreshFormation()
		{
			List<IRogueBattleMapRoleGridInfo> list = new List<IRogueBattleMapRoleGridInfo>();
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
			List<int> list2 = new List<int>
			{
				teamItems[0].GetConfigId
			};
			for (int i = 1; i < teamItems.Count; i++)
			{
				RogueBattleMapRoleGridInfo item = new RogueBattleMapRoleGridInfo
				{
					ConfigId = teamItems[i].GetConfigId,
					IsGain = true,
					NeedLevel = false
				};
				list.Add(item);
				list2.Add(teamItems[i].GetConfigId);
			}
			ModelBase<RogueBattleModel>.Instance.SummaryRoleList = list2;
			GenericScrollViewNew<RogueBattleMapRoleLayoutGrid, IRogueBattleMapRoleGridInfo> loopScroll = this.LoopScroll;
			if (loopScroll == null)
			{
				return;
			}
			loopScroll.RefreshByData(list, null, false);
		}

		// Token: 0x06035E22 RID: 220706 RVA: 0x00D8FDB4 File Offset: 0x00D8DFB4
		private void InitAttributeItemList()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			UUIItem item = base.GetItem(1);
			UUIItem item2 = base.GetItem(2);
			int count = intArrayConfig.Count;
			for (int i = 0; i < count; i++)
			{
				UUIItem uuiitem;
				if (i == 0)
				{
					uuiitem = item2;
				}
				else
				{
					uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item2, item);
				}
				int id = intArrayConfig[i];
				AttributeItem attributeItem = new AttributeItem();
				attributeItem.CreateThenShowByActor(uuiitem.GetOwner());
				attributeItem.UpdateParam(id, false);
				if (count > 2 && i % 2 == 0)
				{
					attributeItem.SetBgActive(true);
				}
				else
				{
					attributeItem.SetBgActive(false);
				}
				this.AttributeItemList.Add(attributeItem);
			}
		}

		// Token: 0x06035E23 RID: 220707 RVA: 0x00D8FE60 File Offset: 0x00D8E060
		protected void UpdateAttribute()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			SceneTeamItem sceneTeamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false)[0];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(sceneTeamItem.GetConfigId, true);
			for (int i = 0; i < this.AttributeItemList.Count; i++)
			{
				AttributeItem attributeItem = this.AttributeItemList[i];
				int id = intArrayConfig[i];
				float showAttributeValueById = roleDataById.GetShowAttributeValueById(id);
				attributeItem.SetCurrentValue(showAttributeValueById);
				attributeItem.SetActive(true);
			}
		}

		// Token: 0x06035E24 RID: 220708 RVA: 0x00D8FEE0 File Offset: 0x00D8E0E0
		private void OnClickMore()
		{
			SceneTeamItem sceneTeamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false)[0];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(sceneTeamItem.GetConfigId, true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleAttributeDetailView, roleDataById.GetShowAttrList(), null);
		}

		// Token: 0x0401EF53 RID: 126803
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueBattleMapRoleLayoutGrid, IRogueBattleMapRoleGridInfo> LoopScroll;

		// Token: 0x0401EF54 RID: 126804
		protected List<AttributeItem> AttributeItemList = new List<AttributeItem>();
	}
}
