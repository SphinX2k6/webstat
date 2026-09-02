using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EFC RID: 24316
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingSettlePanel : UiPanelBase
	{
		// Token: 0x0603D166 RID: 250214 RVA: 0x00F83DA0 File Offset: 0x00F81FA0
		public BossPilingSettlePanel(BossPilingSettleNotify levelInfo)
		{
			this.LevelInfo = levelInfo;
		}

		// Token: 0x0603D167 RID: 250215 RVA: 0x00F83DB0 File Offset: 0x00F81FB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D168 RID: 250216 RVA: 0x00F83E7C File Offset: 0x00F8207C
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<BossPilingSettleScoreTabItem, BossPilingScoreTabInfo>(base.GetVerticalLayout(3), new Func<BossPilingSettleScoreTabItem>(this.CreateItem), null, false, true);
		}

		// Token: 0x0603D169 RID: 250217 RVA: 0x00F83EA0 File Offset: 0x00F820A0
		protected override void OnBeforeShow()
		{
			int challengeLevelId = this.LevelInfo.ChallengeLevelId;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(this.LevelInfo.IsUpdateBossHpNum);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew("BossPilingActivity_Dungeon14");
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.LevelInfo.BossHpNum);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			List<BossPilingScoreTabInfo> list = new List<BossPilingScoreTabInfo>();
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(challengeLevelId).Value;
			for (int i = 0; i < value.Achievement().Length; i++)
			{
				int num = value.Achievement()[i];
				BossPilingScoreTabInfo item2 = new BossPilingScoreTabInfo
				{
					BossHp = num,
					Quality = i + 1,
					IsAchieve = (this.LevelInfo.BossHpNum >= num)
				};
				list.Add(item2);
			}
			this.Layout.RefreshByData(list, null, true);
		}

		// Token: 0x0603D16A RID: 250218 RVA: 0x00F83FA8 File Offset: 0x00F821A8
		private BossPilingSettleScoreTabItem CreateItem()
		{
			return new BossPilingSettleScoreTabItem();
		}

		// Token: 0x0402243B RID: 140347
		protected GenericLayout<BossPilingSettleScoreTabItem, BossPilingScoreTabInfo> Layout;

		// Token: 0x0402243C RID: 140348
		protected BossPilingSettleNotify LevelInfo;

		// Token: 0x0200BEFD RID: 48893
		[NullableContext(0)]
		private enum EPanel
		{
			// Token: 0x0403AC80 RID: 240768
			TxtTitle,
			// Token: 0x0403AC81 RID: 240769
			TxtNum,
			// Token: 0x0403AC82 RID: 240770
			PanelNew,
			// Token: 0x0403AC83 RID: 240771
			PanelTarget,
			// Token: 0x0403AC84 RID: 240772
			TargetItem
		}
	}
}
