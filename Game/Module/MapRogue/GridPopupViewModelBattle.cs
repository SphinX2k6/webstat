using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599A RID: 22938
	[NullableContext(1)]
	[Nullable(0)]
	public class GridPopupViewModelBattle : GridPopupViewModelBase
	{
		// Token: 0x1700947F RID: 38015
		// (get) Token: 0x0603A13F RID: 237887 RVA: 0x00EB2CD2 File Offset: 0x00EB0ED2
		public override bool HasBtnDetail
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0603A140 RID: 237888 RVA: 0x00EB2CD5 File Offset: 0x00EB0ED5
		public GridPopupViewModelBattle(MapGridData gridData, MapRogueGameInfo gameInfo) : base(gridData, gameInfo)
		{
		}

		// Token: 0x0603A141 RID: 237889 RVA: 0x00EB2CE0 File Offset: 0x00EB0EE0
		public override UniTask Init()
		{
			GridPopupViewModelBattle.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<GridPopupViewModelBattle.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A142 RID: 237890 RVA: 0x00EB2D23 File Offset: 0x00EB0F23
		[NullableContext(2)]
		public override string GetSubTxtInfo()
		{
			if (this.GridData.Lv == 0)
			{
				return null;
			}
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueRes_Block_Level", null), new string[]
			{
				this.GridData.Lv.ToString()
			});
		}

		// Token: 0x0603A143 RID: 237891 RVA: 0x00EB2D5D File Offset: 0x00EB0F5D
		public override void RefreshBottom()
		{
			this.InfoList.Refresh(this.GridData);
			this.RewardList.Refresh(this.GridData);
		}

		// Token: 0x0603A144 RID: 237892 RVA: 0x00EB2D81 File Offset: 0x00EB0F81
		public override void RefreshTop()
		{
			this.EventCost.Refresh(this.GridData);
		}

		// Token: 0x0603A145 RID: 237893 RVA: 0x00EB2D94 File Offset: 0x00EB0F94
		public override void RefreshFunctional()
		{
			if (!this.GridData.IsExplore)
			{
				this.RecommendTip.SetActive(this.GridData.Lv != 0);
				this.RecommendTip.SetTextChangeColor(this.GameInfo.TeamLv < this.GridData.Lv);
				this.RecommendTip.SetDescriptionByTextId("RogueRes_Block_Recommend_Level", new string[]
				{
					this.GridData.Lv.ToString()
				});
			}
			bool flag = base.EventAvailable();
			this.Button.SetUiActive(flag);
			if (!flag)
			{
				return;
			}
			this.Button.SetButtonTextByTextId("RogueRes_Block_Move", Array.Empty<string>());
			this.Button.SetButtonFunction(new Action<int>(base.MoveButtonFunction));
		}

		// Token: 0x0603A146 RID: 237894 RVA: 0x00EB2E58 File Offset: 0x00EB1058
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "EventCost")
			{
				PopupComponentEventCost eventCost = this.EventCost;
				if (eventCost == null)
				{
					return null;
				}
				return eventCost.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else if (configParams[0] == "goto")
			{
				PopupComponentFunctionButton button = this.Button;
				UUIItem uuiitem = (button != null) ? button.GetRootItem() : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			else
			{
				if (!(configParams[0] == "InfoList"))
				{
					return null;
				}
				PopupComponentInfoList infoList = this.InfoList;
				UUIItem uuiitem2 = (infoList != null) ? infoList.GetRootItem() : null;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
		}

		// Token: 0x04020F17 RID: 134935
		protected PopupComponentRecommendTip RecommendTip;

		// Token: 0x04020F18 RID: 134936
		protected PopupComponentFunctionButton Button;

		// Token: 0x04020F19 RID: 134937
		protected PopupComponentInfoList InfoList;

		// Token: 0x04020F1A RID: 134938
		protected PopupComponentEventCost EventCost;

		// Token: 0x04020F1B RID: 134939
		protected PopupComponentRewardList RewardList;
	}
}
