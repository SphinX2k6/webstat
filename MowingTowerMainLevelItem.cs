using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001435 RID: 5173
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MowingTowerMainLevelItem : GridProxyAbstract<MowingTowerLevelDetailInfo>
{
	// Token: 0x06008FF4 RID: 36852 RVA: 0x0025CCE0 File Offset: 0x0025AEE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06008FF5 RID: 36853 RVA: 0x0025CE26 File Offset: 0x0025B026
	public override void Refresh(MowingTowerLevelDetailInfo data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.RefreshLockState(data);
		this.RefreshScore(data);
		this.RefreshUnlockTime(data);
		this.RefreshTexture(data);
		this.RefreshLevelDesc(data);
	}

	// Token: 0x06008FF6 RID: 36854 RVA: 0x0025CE54 File Offset: 0x0025B054
	private void RefreshTexture(MowingTowerLevelDetailInfo data)
	{
		bool unLockState = data.GetUnLockState();
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(unLockState);
		}
		base.SetTextureByPath(data.GetNormalTexturePath(), texture, null, null);
		UUITexture texture2 = base.GetTexture(3);
		texture2.SetUIActive(!unLockState);
		base.SetTextureByPath(data.GetLockTexturePath(), texture2, null, null);
		bool isInfinite = data.GetIsInfinite();
		if (data.GetId() % 2 == 0 || isInfinite)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
		}
		else
		{
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			UUIItem item4 = base.GetItem(5);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
		}
		if (!unLockState)
		{
			UUIItem item5 = base.GetItem(1);
			if (item5 != null)
			{
				item5.SetColor(MowingTowerColors.bgLockMowingTowerColor.Value);
			}
			UUIText text = base.GetText(6);
			if (text != null)
			{
				text.SetColor(MowingTowerColors.lockMowingTowerColor.Value);
			}
			UUIItem item6 = base.GetItem(5);
			if (item6 != null)
			{
				item6.SetColor(MowingTowerColors.lockMowingTowerColor.Value);
			}
			UUIItem item7 = base.GetItem(4);
			if (item7 == null)
			{
				return;
			}
			item7.SetColor(MowingTowerColors.lockMowingTowerColor.Value);
			return;
		}
		else if (isInfinite)
		{
			UUIItem item8 = base.GetItem(1);
			if (item8 != null)
			{
				item8.SetColor(MowingTowerColors.bgInfiniteMowingTowerColor.Value);
			}
			UUIText text2 = base.GetText(6);
			if (text2 != null)
			{
				text2.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			}
			UUIItem item9 = base.GetItem(4);
			if (item9 != null)
			{
				item9.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			}
			UUIItem item10 = base.GetItem(5);
			if (item10 == null)
			{
				return;
			}
			item10.SetColor(MowingTowerColors.infiniteMowingTowerColor.Value);
			return;
		}
		else
		{
			UUIItem item11 = base.GetItem(1);
			if (item11 != null)
			{
				item11.SetColor(MowingTowerColors.bgNormalMowingTowerColor.Value);
			}
			UUIText text3 = base.GetText(6);
			if (text3 != null)
			{
				text3.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			}
			UUIItem item12 = base.GetItem(4);
			if (item12 != null)
			{
				item12.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			}
			UUIItem item13 = base.GetItem(5);
			if (item13 == null)
			{
				return;
			}
			item13.SetColor(MowingTowerColors.normalMowingTowerColor.Value);
			return;
		}
	}

	// Token: 0x06008FF7 RID: 36855 RVA: 0x0025D078 File Offset: 0x0025B278
	private void RefreshLockState(MowingTowerLevelDetailInfo data)
	{
		bool unLockState = data.GetUnLockState();
		base.GetItem(10).SetUIActive(!unLockState);
		base.GetItem(7).SetUIActive(unLockState);
	}

	// Token: 0x06008FF8 RID: 36856 RVA: 0x0025D0AC File Offset: 0x0025B2AC
	private void RefreshScore(MowingTowerLevelDetailInfo data)
	{
		if (data.GetUnLockState())
		{
			int score = data.GetScore();
			bool flag = score > 0;
			UUIText text = base.GetText(8);
			text.SetUIActive(flag);
			text.SetText(score.ToString(), true);
			base.GetItem(9).SetUIActive(!flag);
			base.GetItem(7).SetUIActive(flag);
		}
	}

	// Token: 0x06008FF9 RID: 36857 RVA: 0x0025D108 File Offset: 0x0025B308
	private void RefreshUnlockTime(MowingTowerLevelDetailInfo data)
	{
		if (!data.GetUnLockState())
		{
			if (Singleton<TimeUtil>.Instance.GetServerTime() < data.GetUnLockTime())
			{
				base.GetText(11).SetText(data.GetUnlockTimeText(), true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "MowingTowerUnlockCondition", new <>z__ReadOnlySingleElementList<object>(data.GetConfig().Value.PassScore));
		}
	}

	// Token: 0x06008FFA RID: 36858 RVA: 0x0025D17B File Offset: 0x0025B37B
	private void RefreshLevelDesc(MowingTowerLevelDetailInfo data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.GetLevelDesc(), Array.Empty<object>());
	}

	// Token: 0x06008FFB RID: 36859 RVA: 0x0025D19C File Offset: 0x0025B39C
	private void OnClickButton()
	{
		if (this.CurrentData == null || !this.CurrentData.GetUnLockState())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushLevelLock", Array.Empty<object>());
			return;
		}
		ModelBase<MowingTowerModel>.Instance.CurrentSelectLevelDetailData = this.CurrentData;
		ModelBase<MowingTowerModel>.Instance.CurrentTeamInfo = this.CurrentData.ConvertToTeamInfo();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ChangeMowingTowerMainView, 1);
	}

	// Token: 0x06008FFC RID: 36860 RVA: 0x0025D209 File Offset: 0x0025B409
	public bool GetCurrentIsFinish()
	{
		return this.CurrentData != null && this.CurrentData.GetScore() > 0;
	}

	// Token: 0x040042C2 RID: 17090
	[Nullable(2)]
	private MowingTowerLevelDetailInfo CurrentData;

	// Token: 0x02007835 RID: 30773
	[NullableContext(0)]
	private static class EComponent
	{
		// Token: 0x04029561 RID: 169313
		public const int Button = 0;

		// Token: 0x04029562 RID: 169314
		public const int BgItem = 1;

		// Token: 0x04029563 RID: 169315
		public const int NormalTexture = 2;

		// Token: 0x04029564 RID: 169316
		public const int LockTexture = 3;

		// Token: 0x04029565 RID: 169317
		public const int SingleItem = 4;

		// Token: 0x04029566 RID: 169318
		public const int DoubleItem = 5;

		// Token: 0x04029567 RID: 169319
		public const int LevelText = 6;

		// Token: 0x04029568 RID: 169320
		public const int ScoreItem = 7;

		// Token: 0x04029569 RID: 169321
		public const int ScoreText = 8;

		// Token: 0x0402956A RID: 169322
		public const int NoneScoreItem = 9;

		// Token: 0x0402956B RID: 169323
		public const int LockScoreItem = 10;

		// Token: 0x0402956C RID: 169324
		public const int LockScoreText = 11;
	}
}
