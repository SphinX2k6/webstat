using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599D RID: 22941
	[NullableContext(1)]
	[Nullable(0)]
	public class GridPopupViewModelEvent : GridPopupViewModelBase
	{
		// Token: 0x17009482 RID: 38018
		// (get) Token: 0x0603A153 RID: 237907 RVA: 0x00EB317C File Offset: 0x00EB137C
		public override bool HasBtnDetail
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0603A154 RID: 237908 RVA: 0x00EB317F File Offset: 0x00EB137F
		public GridPopupViewModelEvent(MapGridData gridData, MapRogueGameInfo gameInfo) : base(gridData, gameInfo)
		{
		}

		// Token: 0x0603A155 RID: 237909 RVA: 0x00EB318C File Offset: 0x00EB138C
		public override UniTask Init()
		{
			GridPopupViewModelEvent.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<GridPopupViewModelEvent.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A156 RID: 237910 RVA: 0x00EB31CF File Offset: 0x00EB13CF
		public override void RefreshTop()
		{
			this.EventCost.Refresh(this.GridData);
		}

		// Token: 0x0603A157 RID: 237911 RVA: 0x00EB31E2 File Offset: 0x00EB13E2
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

		// Token: 0x0603A158 RID: 237912 RVA: 0x00EB321C File Offset: 0x00EB141C
		public override void RefreshBottom()
		{
			this.InfoList.Refresh(this.GridData);
		}

		// Token: 0x0603A159 RID: 237913 RVA: 0x00EB3230 File Offset: 0x00EB1430
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

		// Token: 0x0603A15A RID: 237914 RVA: 0x00EB32F4 File Offset: 0x00EB14F4
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
				if (button == null)
				{
					return null;
				}
				return button.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(configParams[0] == "InfoList"))
				{
					return null;
				}
				PopupComponentInfoList infoList = this.InfoList;
				UUIItem uuiitem = (infoList != null) ? infoList.GetRootItem() : null;
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
		}

		// Token: 0x04020F20 RID: 134944
		protected PopupComponentRecommendTip RecommendTip;

		// Token: 0x04020F21 RID: 134945
		protected PopupComponentFunctionButton Button;

		// Token: 0x04020F22 RID: 134946
		protected PopupComponentInfoList InfoList;

		// Token: 0x04020F23 RID: 134947
		protected PopupComponentEventCost EventCost;
	}
}
