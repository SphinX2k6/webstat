using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006403 RID: 25603
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeRogueLevelLineItem : GridProxyAbstract<IRoverlikeRogueLevelLineData>
	{
		// Token: 0x06040476 RID: 263286 RVA: 0x01079628 File Offset: 0x01077828
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040477 RID: 263287 RVA: 0x010797DF File Offset: 0x010779DF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06040478 RID: 263288 RVA: 0x010797F4 File Offset: 0x010779F4
		public void PlayCurrentNodeSequence(string sequenceName)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIItem item3 = base.GetItem(8);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName(sequenceName, false, null);
		}

		// Token: 0x06040479 RID: 263289 RVA: 0x01079858 File Offset: 0x01077A58
		public override void Refresh(IRoverlikeRogueLevelLineData data, bool isSelected, int gridIndex)
		{
			bool isPassed = data.IsPassed;
			bool uiactive = data.IsCurrent && data.ShowCurrent;
			bool uiactive2 = !data.IsPassed && !data.IsCurrent;
			bool uiactive3 = data.LayerType == ERoverlikeRoadLayerType.Normal;
			bool uiactive4 = data.LayerType == ERoverlikeRoadLayerType.Elite;
			bool uiactive5 = data.LayerType == ERoverlikeRoadLayerType.Boss;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(uiactive3);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive4);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(uiactive5);
			}
			UUIItem item4 = base.GetItem(2);
			if (item4 != null)
			{
				item4.SetUIActive(uiactive);
			}
			UUIItem item5 = base.GetItem(9);
			if (item5 != null)
			{
				item5.SetUIActive(isPassed);
			}
			UUIItem item6 = base.GetItem(5);
			if (item6 != null)
			{
				item6.SetUIActive(uiactive);
			}
			UUIItem item7 = base.GetItem(10);
			if (item7 != null)
			{
				item7.SetUIActive(isPassed);
			}
			UUIItem item8 = base.GetItem(4);
			if (item8 != null)
			{
				item8.SetUIActive(uiactive2);
			}
			UUIItem item9 = base.GetItem(8);
			if (item9 != null)
			{
				item9.SetUIActive(uiactive);
			}
			UUIItem item10 = base.GetItem(11);
			if (item10 != null)
			{
				item10.SetUIActive(isPassed);
			}
			UUIItem item11 = base.GetItem(7);
			if (item11 != null)
			{
				item11.SetUIActive(uiactive2);
			}
			UUIItem item12 = base.GetItem(0);
			if (item12 == null)
			{
				return;
			}
			item12.SetUIActive(data.IsPassed);
		}

		// Token: 0x0604047A RID: 263290 RVA: 0x010799A0 File Offset: 0x01077BA0
		public override object GetKey(IRoverlikeRogueLevelLineData data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0402408A RID: 147594
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C46A RID: 50282
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C754 RID: 247636
			public const int SpriteLight = 0;

			// Token: 0x0403C755 RID: 247637
			public const int PanelPos = 1;

			// Token: 0x0403C756 RID: 247638
			public const int SpritePosLight = 2;

			// Token: 0x0403C757 RID: 247639
			public const int PanelMonster = 3;

			// Token: 0x0403C758 RID: 247640
			public const int PanelMonsterDark = 4;

			// Token: 0x0403C759 RID: 247641
			public const int PanelMonsterLight = 5;

			// Token: 0x0403C75A RID: 247642
			public const int PanelMonsterBoss = 6;

			// Token: 0x0403C75B RID: 247643
			public const int PanelBossDark = 7;

			// Token: 0x0403C75C RID: 247644
			public const int PanelBossLight = 8;

			// Token: 0x0403C75D RID: 247645
			public const int SpritePosDone = 9;

			// Token: 0x0403C75E RID: 247646
			public const int PanelMonsterDone = 10;

			// Token: 0x0403C75F RID: 247647
			public const int PanelBossDone = 11;
		}
	}
}
