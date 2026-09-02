using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005862 RID: 22626
	public class AreaMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060398CF RID: 235727 RVA: 0x00E9A2F3 File Offset: 0x00E984F3
		[NullableContext(1)]
		public AreaMarkItemView(AreaMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060398D0 RID: 235728 RVA: 0x00E9A2FC File Offset: 0x00E984FC
		protected override void OnViewRefresh()
		{
			this.SetNameText();
		}

		// Token: 0x060398D1 RID: 235729 RVA: 0x00E9A304 File Offset: 0x00E98504
		public void SetNameText()
		{
			Aki.Config.Area? config = ConfigAreaByDeliveryMarkId.GetConfig(this.Holder.MarkId, true);
			if (config == null)
			{
				base.MarkItemNameHandle.SetVisible(false);
				return;
			}
			ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(config.Value.AreaId);
			string markTitle = ((AreaMarkItem)this.Holder).MarkConfig.Value.MarkTitle;
			int value = 36;
			string text = "";
			string id = "SmallAreaName";
			IReadOnlyList<int> source = ConfigCommonParamById.GetIntArrayConfig("MapAreaMarkDisableExploreDungeonList") ?? Array.Empty<int>();
			if (config.Value.Level == 2 && !config.Value.IsDisableInExplore && !source.Contains(ModelBase<CreatureModel>.Instance.GetInstanceId()) && ModelBase<WorldMapModel>.Instance.AreaMarkProgressVisible)
			{
				string text2 = ((exploreAreaData != null) ? exploreAreaData.GetProgress().ToString() : null) ?? "0";
				if (exploreAreaData != null && exploreAreaData.IsReachMaxProgress)
				{
					text = "<color=#ffd12f>" + text2 + "%</color>";
				}
				else
				{
					text = text2 + "%";
				}
				value = 48;
				id = "BigAreaName";
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(id, null);
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(markTitle, null);
			base.MarkItemNameHandle.SetName(new MarkItemParam
			{
				Txt = StringUtils.Format(localTextNew, new string[]
				{
					localTextNew2,
					text
				}),
				FontSize = new int?(value)
			});
			base.MarkItemNameHandle.SetVisible(true);
		}

		// Token: 0x060398D2 RID: 235730 RVA: 0x00E9A490 File Offset: 0x00E98690
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x04020AB3 RID: 133811
		private const int LEVEL_TWO_SIZE = 48;

		// Token: 0x04020AB4 RID: 133812
		private const int LEVEL_TREE_SIZE = 36;
	}
}
