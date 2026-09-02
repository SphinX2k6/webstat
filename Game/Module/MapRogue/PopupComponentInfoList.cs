using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005990 RID: 22928
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentInfoList : UiPanelBase
	{
		// Token: 0x0603A105 RID: 237829 RVA: 0x00EB200C File Offset: 0x00EB020C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603A106 RID: 237830 RVA: 0x00EB2066 File Offset: 0x00EB0266
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<InfoItem, IItemInfoData>(base.GetVerticalLayout(1), new Func<InfoItem>(this.OnCreateInfoItem), null, false, true);
		}

		// Token: 0x0603A107 RID: 237831 RVA: 0x00EB2089 File Offset: 0x00EB0289
		public void SetTextByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x0603A108 RID: 237832 RVA: 0x00EB20A0 File Offset: 0x00EB02A0
		public void Refresh(MapGridData gridData)
		{
			if (gridData.OccupiedEffectIdList.Count == 0)
			{
				this.SetActive(false);
				return;
			}
			bool isExplore = gridData.IsExplore;
			string textId = isExplore ? "RogueRes_Block_Captured_Buff" : "RogueRes_Block_Capture_Buff";
			this.SetTextByTextId(textId, Array.Empty<string>());
			List<IItemInfoData> list = new List<IItemInfoData>();
			foreach (int id in gridData.OccupiedEffectIdList)
			{
				RogueResEffect? rogueEffectById = ConfigBase<MapRogueConfig>.Instance.GetRogueEffectById(id);
				if (rogueEffectById != null)
				{
					RogueResEffectTag? rogueEffectTagById = ConfigBase<MapRogueConfig>.Instance.GetRogueEffectTagById(rogueEffectById.Value.Tag);
					if (rogueEffectTagById != null)
					{
						string text;
						if (!rogueEffectTagById.Value.IsRatio)
						{
							text = rogueEffectById.Value.DescIntParam.ToString();
						}
						else
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
							defaultInterpolatedStringHandler.AppendFormatted<int>(rogueEffectById.Value.DescIntParam);
							defaultInterpolatedStringHandler.AppendLiteral("%");
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						string value = text;
						ItemInfoData item = new ItemInfoData
						{
							TitleId = rogueEffectTagById.Value.Text,
							Value = value,
							ValueChangeColor = isExplore
						};
						list.Add(item);
					}
				}
			}
			this.ItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603A109 RID: 237833 RVA: 0x00EB2218 File Offset: 0x00EB0418
		private InfoItem OnCreateInfoItem()
		{
			return new InfoItem();
		}

		// Token: 0x04020EF8 RID: 134904
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<InfoItem, IItemInfoData> ItemLayout;
	}
}
