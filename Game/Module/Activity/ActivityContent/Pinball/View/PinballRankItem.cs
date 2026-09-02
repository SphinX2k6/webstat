using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x0200659A RID: 26010
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballRankItem : GridProxyAbstract<PinballRankData>
	{
		// Token: 0x06040FE4 RID: 266212 RVA: 0x010AD428 File Offset: 0x010AB628
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040FE5 RID: 266213 RVA: 0x010AD579 File Offset: 0x010AB779
		protected override void OnStart()
		{
			this.FormationLayout = new GenericLayout<PinballRankRoleHeadItem, PinballRankRoleHeadData>(base.GetHorizontalLayout(6), new Func<PinballRankRoleHeadItem>(this.CreateRoleHeadItem), base.GetItem(8).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06040FE6 RID: 266214 RVA: 0x010AD5AC File Offset: 0x010AB7AC
		public override void Refresh(PinballRankData data, bool isSelected, int gridIndex)
		{
			int rank = gridIndex + 1;
			if (data.HasData)
			{
				this.RefreshRankDisplay(rank);
			}
			else
			{
				UUITexture texture = base.GetTexture(0);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			this.RefreshPlayerInfo(data);
			this.RefreshFormationList(data);
		}

		// Token: 0x06040FE7 RID: 266215 RVA: 0x010AD604 File Offset: 0x010AB804
		private void RefreshRankDisplay(int rank)
		{
			UUITexture texture = base.GetTexture(0);
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			if (rank <= 3)
			{
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
				if (text != null)
				{
					text.SetUIActive(false);
				}
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				if (texture != null)
				{
					string topRankIconPath = this.GetTopRankIconPath(rank);
					if (!string.IsNullOrEmpty(topRankIconPath))
					{
						base.SetTextureByPath(topRankIconPath, texture, null, null);
						return;
					}
					texture.SetUIActive(false);
					if (text != null)
					{
						text.SetUIActive(true);
					}
					if (text != null)
					{
						text.SetText(rank.ToString(), true);
						return;
					}
				}
			}
			else
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(true);
				}
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetText(rank.ToString(), true);
				}
			}
		}

		// Token: 0x06040FE8 RID: 266216 RVA: 0x010AD6C4 File Offset: 0x010AB8C4
		[NullableContext(2)]
		private string GetTopRankIconPath(int rank)
		{
			string text;
			if (!PinballDefine.pinballRankTopIconResourceKeys.TryGetValue(rank, out text))
			{
				return null;
			}
			if (!string.IsNullOrEmpty(text))
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
				if (!string.IsNullOrEmpty(resourcePath))
				{
					return resourcePath;
				}
			}
			return null;
		}

		// Token: 0x06040FE9 RID: 266217 RVA: 0x010AD704 File Offset: 0x010AB904
		private void RefreshPlayerInfo(PinballRankData data)
		{
			if (data.HasData)
			{
				UUIText text = base.GetText(3);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				UUIText text2 = base.GetText(2);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				UUIText text3 = base.GetText(3);
				if (text3 != null)
				{
					text3.SetText(data.Name, true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Pinball_Level_TowerLevelInfo", new <>z__ReadOnlySingleElementList<object>(data.TowerLevel));
				string timeDataFormatWithHour = Singleton<TimeUtil>.Instance.GetTimeDataFormatWithHour((double)data.CostTime);
				UUIText text4 = base.GetText(5);
				if (text4 == null)
				{
					return;
				}
				text4.SetText(timeDataFormatWithHour, true);
				return;
			}
			else
			{
				UUIText text5 = base.GetText(3);
				if (text5 != null)
				{
					text5.SetUIActive(true);
				}
				UUIText text6 = base.GetText(2);
				if (text6 != null)
				{
					text6.SetUIActive(true);
				}
				UUIText text7 = base.GetText(3);
				if (text7 != null)
				{
					text7.SetText(data.Name, true);
				}
				UUIText text8 = base.GetText(4);
				if (text8 != null)
				{
					text8.SetText("", true);
				}
				UUIText text9 = base.GetText(5);
				if (text9 != null)
				{
					text9.SetText("", true);
				}
				UUITexture texture = base.GetTexture(0);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				UUIText text10 = base.GetText(1);
				if (text10 == null)
				{
					return;
				}
				text10.SetUIActive(false);
				return;
			}
		}

		// Token: 0x06040FEA RID: 266218 RVA: 0x010AD83C File Offset: 0x010ABA3C
		private void RefreshFormationList(PinballRankData data)
		{
			List<ValueTuple<int, int>> formation = data.Formation;
			if (formation != null && formation.Count > 0)
			{
				GenericLayout<PinballRankRoleHeadItem, PinballRankRoleHeadData> formationLayout = this.FormationLayout;
				if (formationLayout != null)
				{
					UUIItem rootUiItem = formationLayout.GetRootUiItem();
					if (rootUiItem != null)
					{
						rootUiItem.SetUIActive(true);
					}
				}
				UUIText text = base.GetText(7);
				if (text != null)
				{
					text.SetUIActive(false);
				}
				List<PinballRankRoleHeadData> list = new List<PinballRankRoleHeadData>();
				foreach (ValueTuple<int, int> valueTuple in formation)
				{
					list.Add(new PinballRankRoleHeadData
					{
						RoleId = valueTuple.Item1,
						Level = valueTuple.Item2
					});
				}
				GenericLayout<PinballRankRoleHeadItem, PinballRankRoleHeadData> formationLayout2 = this.FormationLayout;
				if (formationLayout2 == null)
				{
					return;
				}
				formationLayout2.RefreshByData(list, null, false);
				return;
			}
			else
			{
				GenericLayout<PinballRankRoleHeadItem, PinballRankRoleHeadData> formationLayout3 = this.FormationLayout;
				if (formationLayout3 != null)
				{
					UUIItem rootUiItem2 = formationLayout3.GetRootUiItem();
					if (rootUiItem2 != null)
					{
						rootUiItem2.SetUIActive(false);
					}
				}
				if (data.IsMyRank && !data.HasData)
				{
					UUIText text2 = base.GetText(7);
					if (text2 == null)
					{
						return;
					}
					text2.SetUIActive(true);
					return;
				}
				else
				{
					UUIText text3 = base.GetText(7);
					if (text3 == null)
					{
						return;
					}
					text3.SetUIActive(false);
					return;
				}
			}
		}

		// Token: 0x06040FEB RID: 266219 RVA: 0x010AD95C File Offset: 0x010ABB5C
		private PinballRankRoleHeadItem CreateRoleHeadItem()
		{
			return new PinballRankRoleHeadItem();
		}

		// Token: 0x0402471D RID: 149277
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballRankRoleHeadItem, PinballRankRoleHeadData> FormationLayout;

		// Token: 0x0402471E RID: 149278
		private const int TOP_RANK_COUNT = 3;

		// Token: 0x0200C592 RID: 50578
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403CCE3 RID: 249059
			RankIcon,
			// Token: 0x0403CCE4 RID: 249060
			TxtNum,
			// Token: 0x0403CCE5 RID: 249061
			TxtNone,
			// Token: 0x0403CCE6 RID: 249062
			TxtName,
			// Token: 0x0403CCE7 RID: 249063
			TxtLevel,
			// Token: 0x0403CCE8 RID: 249064
			TxtTime,
			// Token: 0x0403CCE9 RID: 249065
			PhiPlaylist,
			// Token: 0x0403CCEA RID: 249066
			Empty,
			// Token: 0x0403CCEB RID: 249067
			RankRoleHead
		}
	}
}
