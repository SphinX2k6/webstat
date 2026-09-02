using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599C RID: 22940
	[NullableContext(1)]
	[Nullable(0)]
	public class GridPopupViewModelBoss : GridPopupViewModelBase
	{
		// Token: 0x17009481 RID: 38017
		// (get) Token: 0x0603A14C RID: 237900 RVA: 0x00EB2FCE File Offset: 0x00EB11CE
		public override bool HasBtnDetail
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0603A14D RID: 237901 RVA: 0x00EB2FD1 File Offset: 0x00EB11D1
		public GridPopupViewModelBoss(MapGridData gridData, MapRogueGameInfo gameInfo) : base(gridData, gameInfo)
		{
		}

		// Token: 0x0603A14E RID: 237902 RVA: 0x00EB2FDC File Offset: 0x00EB11DC
		public override UniTask Init()
		{
			GridPopupViewModelBoss.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<GridPopupViewModelBoss.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A14F RID: 237903 RVA: 0x00EB301F File Offset: 0x00EB121F
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

		// Token: 0x0603A150 RID: 237904 RVA: 0x00EB3059 File Offset: 0x00EB1259
		public override void RefreshTop()
		{
			this.EventCost.Refresh(this.GridData);
		}

		// Token: 0x0603A151 RID: 237905 RVA: 0x00EB306C File Offset: 0x00EB126C
		public override void RefreshFunctional()
		{
			this.RecommendTip.SetActive(this.GridData.Lv != 0);
			this.RecommendTip.SetTextChangeColor(this.GameInfo.TeamLv < this.GridData.Lv);
			this.RecommendTip.SetDescriptionByTextId("RogueRes_Block_Recommend_Level", new string[]
			{
				this.GridData.Lv.ToString()
			});
			bool flag = base.EventAvailable();
			this.Button.SetUiActive(flag);
			if (!flag)
			{
				return;
			}
			this.Button.SetButtonTextByTextId("RogueRes_Block_Move", Array.Empty<string>());
			this.Button.SetButtonFunction(new Action<int>(base.MoveButtonFunction));
		}

		// Token: 0x0603A152 RID: 237906 RVA: 0x00EB3124 File Offset: 0x00EB1324
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
			else
			{
				if (!(configParams[0] == "goto"))
				{
					return null;
				}
				PopupComponentFunctionButton button = this.Button;
				if (button == null)
				{
					return null;
				}
				return button.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x04020F1D RID: 134941
		protected PopupComponentRecommendTip RecommendTip;

		// Token: 0x04020F1E RID: 134942
		protected PopupComponentFunctionButton Button;

		// Token: 0x04020F1F RID: 134943
		protected PopupComponentEventCost EventCost;
	}
}
