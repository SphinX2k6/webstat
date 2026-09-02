using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006344 RID: 25412
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelItem : AutoAttachItem<SpringLevelData>
	{
		// Token: 0x0603FD29 RID: 261417 RVA: 0x0105E8D4 File Offset: 0x0105CAD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnButtonClick))
			};
		}

		// Token: 0x0603FD2A RID: 261418 RVA: 0x0105EA31 File Offset: 0x0105CC31
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FD2B RID: 261419 RVA: 0x0105EA44 File Offset: 0x0105CC44
		protected override void OnRefreshItem(SpringLevelData data)
		{
			if (data == null)
			{
				return;
			}
			this.Data = data;
			this.RefreshPerformance();
		}

		// Token: 0x0603FD2C RID: 261420 RVA: 0x0105EA58 File Offset: 0x0105CC58
		public void RefreshPerformance()
		{
			SpringLevelData data = this.Data;
			int atmosphereLevel = ModelBase<SpringManorModel>.Instance.GetAtmosphereLevel();
			bool isLock = data.Level > atmosphereLevel;
			this.SetIsLock(isLock);
			UUIText selectText = this.GetSelectText();
			if (selectText != null)
			{
				selectText.SetText(data.Level.ToString(), true);
			}
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			bool flag = data.Level >= ModelBase<SpringManorModel>.Instance.GetMaxLevel();
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			UUISprite sprite = base.GetSprite(10);
			if (sprite != null)
			{
				sprite.SetUIActive(!flag);
			}
			if (!flag)
			{
				int atmosphere = ModelBase<SpringManorModel>.Instance.ActivityData.GetAtmosphere();
				int num = Singleton<MathUtils>.Instance.Clamp((atmosphere - data.ExpLevel) / data.ExpNext, 0, 1);
				sprite.SetFillAmount((float)num);
			}
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			bool? flag2 = (instance != null) ? new bool?(instance.ActivityData.IsLevelCanReceive(data.Level)) : null;
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(flag2.GetValueOrDefault());
			}
			Func<int, bool> getIsSelectLevel = this.GetIsSelectLevel;
			bool flag3 = getIsSelectLevel != null && getIsSelectLevel(data.Level);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayOrReplaySequenceByName(flag3 ? "NorToSle" : "SleToNor", false, null);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.StopCurrentSequence(false, true);
		}

		// Token: 0x0603FD2D RID: 261421 RVA: 0x0105EBD8 File Offset: 0x0105CDD8
		[NullableContext(1)]
		public void PlaySequence(string seqName)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopPlayingSequence(false, true);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.PlayOrReplaySequenceByName(seqName, false, null);
		}

		// Token: 0x0603FD2E RID: 261422 RVA: 0x0105EC13 File Offset: 0x0105CE13
		public override void OnSelect()
		{
			if (this.SelectCallback != null && this.Data != null)
			{
				this.SelectCallback(this.Data.Level, this);
			}
		}

		// Token: 0x0603FD2F RID: 261423 RVA: 0x0105EC3C File Offset: 0x0105CE3C
		protected override void OnUnSelect()
		{
		}

		// Token: 0x0603FD30 RID: 261424 RVA: 0x0105EC3E File Offset: 0x0105CE3E
		protected override void OnMoveItem()
		{
		}

		// Token: 0x0603FD31 RID: 261425 RVA: 0x0105EC40 File Offset: 0x0105CE40
		private void SetIsLock(bool isLock)
		{
			this.IsLock = isLock;
			base.GetItem(2).SetUIActive(!isLock);
			base.GetItem(4).SetUIActive(isLock);
			base.GetText(7).SetUIActive(!isLock);
			base.GetText(8).SetUIActive(isLock);
			base.GetItem(3).SetUIActive(!isLock);
			base.GetItem(5).SetUIActive(isLock);
		}

		// Token: 0x0603FD32 RID: 261426 RVA: 0x0105ECAB File Offset: 0x0105CEAB
		[NullableContext(1)]
		private UUIText GetSelectText()
		{
			if (this.IsLock)
			{
				return base.GetText(8);
			}
			return base.GetText(7);
		}

		// Token: 0x0603FD33 RID: 261427 RVA: 0x0105ECC4 File Offset: 0x0105CEC4
		private void OnButtonClick()
		{
			if (this.ClickCallback != null && this.Data != null)
			{
				this.ClickCallback(this.Data.Level);
			}
		}

		// Token: 0x0603FD34 RID: 261428 RVA: 0x0105ECEC File Offset: 0x0105CEEC
		public LevelItem() : base(null)
		{
		}

		// Token: 0x04023DC7 RID: 146887
		private SpringLevelData Data;

		// Token: 0x04023DC8 RID: 146888
		public Action<int> ClickCallback;

		// Token: 0x04023DC9 RID: 146889
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, LevelItem> SelectCallback;

		// Token: 0x04023DCA RID: 146890
		public Func<int, bool> GetIsSelectLevel;

		// Token: 0x04023DCB RID: 146891
		private bool IsLock = true;

		// Token: 0x04023DCC RID: 146892
		private LevelSequencePlayer SeqPlayer;
	}
}
