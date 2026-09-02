using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006406 RID: 25606
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSettleReinforcementPanel : UiPanelBase, IRoverlikeSettleSelectablePanel
	{
		// Token: 0x0604048E RID: 263310 RVA: 0x01079D61 File Offset: 0x01077F61
		public void BindOnItemClick(Action<int, int> callback)
		{
			this.OnItemClick = callback;
		}

		// Token: 0x0604048F RID: 263311 RVA: 0x01079D6C File Offset: 0x01077F6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040490 RID: 263312 RVA: 0x01079E17 File Offset: 0x01078017
		protected override void OnStart()
		{
			this.ReinforcementLayout = new GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData>(base.GetGridLayout(1), new Func<RoverlikeEntrySmallGridItem>(this.CreateReinforcementItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06040491 RID: 263313 RVA: 0x01079E4C File Offset: 0x0107804C
		public void Refresh(List<int> configIdList)
		{
			base.GetText(0).SetText(configIdList.Count.ToString(), true);
			List<IRoverlikeEntrySmallGridData> list = new List<IRoverlikeEntrySmallGridData>();
			foreach (int configId in configIdList)
			{
				RoverlikeEntrySmallGridData item = new RoverlikeEntrySmallGridData
				{
					ConfigId = configId,
					Type = RoverRogueGainDataType.RoverRogueGainRoleEnhance
				};
				list.Add(item);
			}
			bool flag = list.Count > 0;
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> reinforcementLayout = this.ReinforcementLayout;
			if (reinforcementLayout != null)
			{
				reinforcementLayout.SetActive(flag);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag)
			{
				this.ReinforcementLayout.RefreshByData(list, null, true);
			}
		}

		// Token: 0x06040492 RID: 263314 RVA: 0x01079F18 File Offset: 0x01078118
		public void SelectByKey(int key)
		{
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> reinforcementLayout = this.ReinforcementLayout;
			if (reinforcementLayout == null)
			{
				return;
			}
			reinforcementLayout.SelectGridProxyByKey(key, false);
		}

		// Token: 0x06040493 RID: 263315 RVA: 0x01079F31 File Offset: 0x01078131
		public void ClearSelect()
		{
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> reinforcementLayout = this.ReinforcementLayout;
			if (reinforcementLayout == null)
			{
				return;
			}
			reinforcementLayout.DeselectCurrentGridProxy();
		}

		// Token: 0x06040494 RID: 263316 RVA: 0x01079F43 File Offset: 0x01078143
		private RoverlikeEntrySmallGridItem CreateReinforcementItem()
		{
			RoverlikeEntrySmallGridItem roverlikeEntrySmallGridItem = new RoverlikeEntrySmallGridItem();
			roverlikeEntrySmallGridItem.BindOnItemClick(new Action<IRoverlikeEntrySmallGridData, int>(this.OnGridItemClick));
			return roverlikeEntrySmallGridItem;
		}

		// Token: 0x06040495 RID: 263317 RVA: 0x01079F5C File Offset: 0x0107815C
		private void OnGridItemClick(IRoverlikeEntrySmallGridData data, int key)
		{
			Action<int, int> onItemClick = this.OnItemClick;
			if (onItemClick == null)
			{
				return;
			}
			onItemClick(data.ConfigId, key);
		}

		// Token: 0x0402408F RID: 147599
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> ReinforcementLayout;

		// Token: 0x04024090 RID: 147600
		[Nullable(2)]
		private Action<int, int> OnItemClick;

		// Token: 0x0200C46D RID: 50285
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C768 RID: 247656
			public const int TxtNum = 0;

			// Token: 0x0403C769 RID: 247657
			public const int LayoutReinforcement = 1;

			// Token: 0x0403C76A RID: 247658
			public const int ReinforcementItem = 2;

			// Token: 0x0403C76B RID: 247659
			public const int ItemEmpty = 3;
		}
	}
}
