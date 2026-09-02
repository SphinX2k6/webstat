using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069CD RID: 27085
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class BossRushMainViewScrollItem : GridProxyAbstract<BossRushLevelDetailInfo>
	{
		// Token: 0x06043250 RID: 275024 RVA: 0x0113FE4C File Offset: 0x0113E04C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043251 RID: 275025 RVA: 0x0113FFB8 File Offset: 0x0113E1B8
		private void OnClickButton()
		{
			BossRushLevelDetailInfo currentData = this.CurrentData;
			if (currentData == null || !currentData.GetUnLockState())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushLevelLock", Array.Empty<object>());
				return;
			}
			BossRushTeamInfo bossRushTeamInfoByActivityId = ModelBase<BossRushModel>.Instance.GetBossRushTeamInfoByActivityId(ModelBase<BossRushModel>.Instance.CurrentSelectActivityId);
			bossRushTeamInfoByActivityId.Clear();
			bossRushTeamInfoByActivityId.SetCurrentSelectLevel(this.CurrentData);
			ModelBase<BossRushModel>.Instance.CurrentSelectLevelDetailData = this.CurrentData;
			ModelBase<BossRushModel>.Instance.CurrentTeamInfo = this.CurrentData.ConvertToTeamInfo();
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.RequestChangeBossRushView, EUiTabViewName.BossRushLevelDetailView);
		}

		// Token: 0x06043252 RID: 275026 RVA: 0x01140050 File Offset: 0x0113E250
		public override void Refresh(BossRushLevelDetailInfo data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			this.RefreshLockState(data);
			this.RefreshScore(data);
			this.RefreshUnlockTime(data);
			this.RefreshMonsterTexture(data);
		}

		// Token: 0x06043253 RID: 275027 RVA: 0x01140078 File Offset: 0x0113E278
		private void RefreshMonsterTexture(BossRushLevelDetailInfo data)
		{
			base.SetTextureByPath(data.GetMonsterTexturePath(), base.GetTexture(0), null, null);
			UUITexture texture = base.GetTexture(6);
			texture.SetUIActive(!data.GetUnLockState());
			base.SetTextureByPath(data.GetMonsterTexturePath(), texture, null, null);
		}

		// Token: 0x06043254 RID: 275028 RVA: 0x011400D0 File Offset: 0x0113E2D0
		private void RefreshLockState(BossRushLevelDetailInfo data)
		{
			bool unLockState = data.GetUnLockState();
			base.GetItem(1).SetUIActive(unLockState);
			base.GetItem(2).SetUIActive(!unLockState);
		}

		// Token: 0x06043255 RID: 275029 RVA: 0x01140104 File Offset: 0x0113E304
		private void RefreshScore(BossRushLevelDetailInfo data)
		{
			if (data.GetUnLockState())
			{
				int score = data.GetScore();
				bool flag = score > 0;
				UUIText text = base.GetText(3);
				text.SetUIActive(flag);
				text.SetText(score.ToString(), true);
				base.GetItem(7).SetUIActive(!flag);
			}
		}

		// Token: 0x06043256 RID: 275030 RVA: 0x01140150 File Offset: 0x0113E350
		private void RefreshUnlockTime(BossRushLevelDetailInfo data)
		{
			if (!data.GetUnLockState())
			{
				base.GetText(4).SetText(data.GetUnlockTimeText(), true);
			}
		}

		// Token: 0x06043257 RID: 275031 RVA: 0x01140170 File Offset: 0x0113E370
		public UUIItem GetButtonItem()
		{
			UUIButtonComponent button = base.GetButton(5);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x040256A3 RID: 153251
		[Nullable(2)]
		private BossRushLevelDetailInfo CurrentData;

		// Token: 0x0200C951 RID: 51537
		[NullableContext(0)]
		private class EBossRushMainViewScrollItemComponent
		{
			// Token: 0x0403DEA7 RID: 253607
			public const int MonsterTexture = 0;

			// Token: 0x0403DEA8 RID: 253608
			public const int LockPanelItem = 1;

			// Token: 0x0403DEA9 RID: 253609
			public const int UnLockPanelItem = 2;

			// Token: 0x0403DEAA RID: 253610
			public const int ScoreText = 3;

			// Token: 0x0403DEAB RID: 253611
			public const int UnlockTime = 4;

			// Token: 0x0403DEAC RID: 253612
			public const int Button = 5;

			// Token: 0x0403DEAD RID: 253613
			public const int LockTexture = 6;

			// Token: 0x0403DEAE RID: 253614
			public const int UnFinishItem = 7;
		}
	}
}
