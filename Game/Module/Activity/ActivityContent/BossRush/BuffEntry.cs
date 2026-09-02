using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069C6 RID: 27078
	public class BuffEntry : UiPanelBase
	{
		// Token: 0x0604320B RID: 274955 RVA: 0x0113EB28 File Offset: 0x0113CD28
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickEntryButton))
			};
		}

		// Token: 0x0604320C RID: 274956 RVA: 0x0113EC2C File Offset: 0x0113CE2C
		private void OnClickEntryButton()
		{
			BossRushBuffInfo currentSelectBuff = this.CurrentSelectBuff;
			if (currentSelectBuff != null && currentSelectBuff.State == BossRushBuffSelectionStatus.BuffLocked)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushLock", Array.Empty<object>());
				return;
			}
			BossRushBuffInfo currentSelectBuff2 = this.CurrentSelectBuff;
			if (currentSelectBuff2 != null && currentSelectBuff2.State == BossRushBuffSelectionStatus.BuffInactive)
			{
				return;
			}
			ModelBase<BossRushModel>.Instance.CurrentChangeBuffSlot = this.SlotIndex;
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.RequestChangeBossRushView, EUiTabViewName.BossRushBuffSelectView);
		}

		// Token: 0x0604320D RID: 274957 RVA: 0x0113ECA4 File Offset: 0x0113CEA4
		[NullableContext(1)]
		public void Refresh(BossRushBuffInfo buff)
		{
			this.CurrentSelectBuff = buff;
			if (buff.State == BossRushBuffSelectionStatus.BuffInactive)
			{
				UUIButtonComponent button = base.GetButton(0);
				if (button != null)
				{
					button.SetSelfInteractive(false);
				}
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(0);
				if (button2 != null)
				{
					button2.SetSelectionState(EUISelectableSelectionState.Normal);
				}
				UUIButtonComponent button3 = base.GetButton(0);
				if (button3 != null)
				{
					button3.SetSelfInteractive(true);
				}
			}
			this.RefreshNoneShow();
			this.RefreshBuffInfo();
			this.RefreshLockItemState();
			this.RefreshSwitchButton();
			this.RefreshBuffTips();
		}

		// Token: 0x0604320E RID: 274958 RVA: 0x0113ED1C File Offset: 0x0113CF1C
		private void RefreshBuffTips()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			string textStringId;
			if (this.CurrentSelectBuff.State == BossRushBuffSelectionStatus.BuffLocked)
			{
				textStringId = "BossRushLock";
			}
			else if (this.CurrentSelectBuff.State == BossRushBuffSelectionStatus.BuffInactive)
			{
				textStringId = "BossRushBuffDisableTips";
			}
			else
			{
				textStringId = "BossRushBuffSelectTips";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
		}

		// Token: 0x0604320F RID: 274959 RVA: 0x0113ED81 File Offset: 0x0113CF81
		private void RefreshLockItemState()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			base.GetItem(8).SetUIActive(this.CurrentSelectBuff.State == BossRushBuffSelectionStatus.BuffLocked);
		}

		// Token: 0x06043210 RID: 274960 RVA: 0x0113EDA6 File Offset: 0x0113CFA6
		private void RefreshSwitchButton()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			base.GetItem(7).SetUIActive(this.CurrentSelectBuff.BuffId != 0 && this.CurrentSelectBuff.State != BossRushBuffSelectionStatus.BuffLocked);
		}

		// Token: 0x06043211 RID: 274961 RVA: 0x0113EDDE File Offset: 0x0113CFDE
		private void RefreshNoneShow()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			base.GetItem(1).SetUIActive(this.CurrentSelectBuff.BuffId == 0);
			base.GetItem(2).SetUIActive(this.CurrentSelectBuff.BuffId != 0);
		}

		// Token: 0x06043212 RID: 274962 RVA: 0x0113EE1D File Offset: 0x0113D01D
		private void RefreshBuffInfo()
		{
			if (this.CurrentSelectBuff == null || this.CurrentSelectBuff.BuffId == 0)
			{
				return;
			}
			this.RefreshBuffName();
			this.RefreshBuffDesc();
			this.RefreshBuffTexture();
		}

		// Token: 0x06043213 RID: 274963 RVA: 0x0113EE48 File Offset: 0x0113D048
		private void RefreshBuffTexture()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentSelectBuff.BuffId);
			if (bossRushBuffConfigById == null)
			{
				return;
			}
			string texture = bossRushBuffConfigById.Value.Texture;
			base.SetTextureByPath(texture, base.GetTexture(4), null, null);
		}

		// Token: 0x06043214 RID: 274964 RVA: 0x0113EEA8 File Offset: 0x0113D0A8
		private void RefreshBuffDesc()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentSelectBuff.BuffId);
			if (bossRushBuffConfigById == null)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (string input in bossRushBuffConfigById.Value.DescriptionParam())
			{
				Match match = new Regex("\\[(.*?)\\]").Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					string[] collection = match.Groups[1].Value.Split(',', StringSplitOptions.None);
					list.AddRange(collection);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), bossRushBuffConfigById.Value.Description, list.ToArray());
		}

		// Token: 0x06043215 RID: 274965 RVA: 0x0113EF84 File Offset: 0x0113D184
		private void RefreshBuffName()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentSelectBuff.BuffId);
			if (bossRushBuffConfigById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), bossRushBuffConfigById.Value.Name, Array.Empty<object>());
		}

		// Token: 0x06043216 RID: 274966 RVA: 0x0113EFDF File Offset: 0x0113D1DF
		public bool HaveBuff()
		{
			BossRushBuffInfo currentSelectBuff = this.CurrentSelectBuff;
			return ((currentSelectBuff != null) ? currentSelectBuff.BuffId : 0) > 0;
		}

		// Token: 0x04025690 RID: 153232
		public int SlotIndex;

		// Token: 0x04025691 RID: 153233
		[Nullable(2)]
		private BossRushBuffInfo CurrentSelectBuff;
	}
}
