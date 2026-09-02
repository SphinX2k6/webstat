using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RacingBets.Data;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069DD RID: 27101
	public class AnniversarySubActivityDangoRunUiItem : AnniversaryActivityEnterItem
	{
		// Token: 0x060432DE RID: 275166 RVA: 0x0114326B File Offset: 0x0114146B
		public override void ChildUpdateStateInfo()
		{
			if (this.Data == null)
			{
				return;
			}
			this.SetDangoIcon();
		}

		// Token: 0x060432DF RID: 275167 RVA: 0x0114327C File Offset: 0x0114147C
		public override void ChildUpdateTips()
		{
			this.SetDangoIcon();
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
			AnniversarySubActivityDataBase data = this.Data;
			if (((data != null) ? new EAnniversaryActivityState?(data.GetCurrentState()) : null).GetValueOrDefault() != EAnniversaryActivityState.Unlock)
			{
				return;
			}
			AnniversarySubActivityDangoRun anniversarySubActivityDangoRun = this.Data as AnniversarySubActivityDangoRun;
			if (anniversarySubActivityDangoRun == null)
			{
				return;
			}
			string matchStateDisplayTextForEntranceActivityId = RacingBetsSeasonData.GetMatchStateDisplayTextForEntranceActivityId(anniversarySubActivityDangoRun.GetActivityId());
			if (matchStateDisplayTextForEntranceActivityId.Length == 0)
			{
				return;
			}
			text.SetUIActive(true);
			text.SetText(matchStateDisplayTextForEntranceActivityId, true);
		}

		// Token: 0x060432E0 RID: 275168 RVA: 0x01143304 File Offset: 0x01141504
		private void SetDangoIcon()
		{
			if (this.Data == null)
			{
				return;
			}
			AnniversarySubActivityDangoRun anniversarySubActivityDangoRun = this.Data as AnniversarySubActivityDangoRun;
			if (anniversarySubActivityDangoRun == null)
			{
				return;
			}
			string currentDangoIconStr = anniversarySubActivityDangoRun.GetCurrentDangoIconStr();
			bool uiactive = !string.IsNullOrEmpty(currentDangoIconStr);
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetUIActive(uiactive);
			}
			if (this.CachedDangoIconPath == currentDangoIconStr)
			{
				return;
			}
			this.CachedDangoIconPath = currentDangoIconStr;
			base.TrySetTextureByPath(currentDangoIconStr, base.GetTexture(5), null, null);
		}

		// Token: 0x04025703 RID: 153347
		[Nullable(2)]
		private string CachedDangoIconPath;
	}
}
