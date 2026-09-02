using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005147 RID: 20807
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeListItem : UiPanelBase
	{
		// Token: 0x060358CC RID: 219340 RVA: 0x00D715F8 File Offset: 0x00D6F7F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060358CD RID: 219341 RVA: 0x00D71682 File Offset: 0x00D6F882
		protected override void OnStart()
		{
			this.BossItemLayout = new GenericLayout<RoguelikeBossChallengeBossItem, RoguelikeBossChallengeBossData>(base.GetHorizontalLayout(1), new Func<RoguelikeBossChallengeBossItem>(this.CreateBossItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060358CE RID: 219342 RVA: 0x00D716B8 File Offset: 0x00D6F8B8
		public void RefreshBossList(List<RoguelikeBossChallengeBossData> dataList, int currentBossId)
		{
			GenericLayout<RoguelikeBossChallengeBossItem, RoguelikeBossChallengeBossData> bossItemLayout = this.BossItemLayout;
			if (bossItemLayout == null)
			{
				return;
			}
			bossItemLayout.RefreshByData(dataList, delegate
			{
				this.OnBossListRefreshed(currentBossId);
			}, false);
		}

		// Token: 0x060358CF RID: 219343 RVA: 0x00D716F8 File Offset: 0x00D6F8F8
		private void OnBossListRefreshed(int currentBossId)
		{
			if (this.BossItemLayout == null)
			{
				return;
			}
			List<RoguelikeBossChallengeBossItem> layoutItemList = this.BossItemLayout.GetLayoutItemList();
			int num = layoutItemList.Count - 1;
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				layoutItemList[i].SetArrowVisible(i < num);
			}
			this.PlayCurrentBossSwitchSequence(layoutItemList, currentBossId);
		}

		// Token: 0x060358D0 RID: 219344 RVA: 0x00D7174C File Offset: 0x00D6F94C
		private void PlayCurrentBossSwitchSequence(List<RoguelikeBossChallengeBossItem> itemList, int currentBossId)
		{
			if (currentBossId == 0)
			{
				return;
			}
			foreach (RoguelikeBossChallengeBossItem roguelikeBossChallengeBossItem in itemList)
			{
				if (roguelikeBossChallengeBossItem.IsCurrentBoss(currentBossId))
				{
					roguelikeBossChallengeBossItem.PlaySwitchSequence();
					break;
				}
			}
		}

		// Token: 0x060358D1 RID: 219345 RVA: 0x00D717A8 File Offset: 0x00D6F9A8
		protected override void OnBeforeDestroy()
		{
			this.BossItemLayout = null;
		}

		// Token: 0x060358D2 RID: 219346 RVA: 0x00D717B1 File Offset: 0x00D6F9B1
		private RoguelikeBossChallengeBossItem CreateBossItem()
		{
			return new RoguelikeBossChallengeBossItem
			{
				ShowCurrentArrow = true
			};
		}

		// Token: 0x0401EC48 RID: 126024
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeBossChallengeBossItem, RoguelikeBossChallengeBossData> BossItemLayout;

		// Token: 0x0200B0E5 RID: 45285
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DF1 RID: 224753
			public const int TxtTitle = 0;

			// Token: 0x04036DF2 RID: 224754
			public const int PnlBossItemLayout = 1;

			// Token: 0x04036DF3 RID: 224755
			public const int UiItemRougueBossItem = 2;
		}
	}
}
