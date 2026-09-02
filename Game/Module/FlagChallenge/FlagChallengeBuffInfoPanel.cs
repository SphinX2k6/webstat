using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D5A RID: 23898
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffInfoPanel : UiPanelBase
	{
		// Token: 0x0603C394 RID: 246676 RVA: 0x00F4699C File Offset: 0x00F44B9C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUINiagara)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUINiagara)),
				new ValueTuple<int, Type>(8, typeof(UUINiagara)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUISprite)),
				new ValueTuple<int, Type>(12, typeof(UUIText))
			};
		}

		// Token: 0x0603C395 RID: 246677 RVA: 0x00F46AD6 File Offset: 0x00F44CD6
		protected override void OnStart()
		{
			base.GetItem(0).SetUIActive(false);
		}

		// Token: 0x0603C396 RID: 246678 RVA: 0x00F46AE8 File Offset: 0x00F44CE8
		public void RefreshView(FlagChallengeBuffData data)
		{
			this.BuffData = data;
			this.UpdateState();
			base.GetText(2).ShowTextNew(data.Config.BuffName);
			base.GetText(3).ShowTextNew(data.Config.BuffDescDetail);
		}

		// Token: 0x0603C397 RID: 246679 RVA: 0x00F46B38 File Offset: 0x00F44D38
		private void UpdateState()
		{
			switch (this.BuffData.GetBuffStatus())
			{
			case EFlagChallengeBuffStatus.NotActive:
				this.SetStateNotActive();
				return;
			case EFlagChallengeBuffStatus.Active:
				this.SetStateActive();
				return;
			case EFlagChallengeBuffStatus.TempActive:
				this.SetStateTempActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C398 RID: 246680 RVA: 0x00F46B78 File Offset: 0x00F44D78
		public void SetStateActive()
		{
			this.SetActiveStateText("Morale_32_Buff_Activated", false);
			this.SetActiveStateBg("SP_FrameActivated");
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetIconChangeColor(true);
			this.SetBg("T_FlagChallengeBuffBgActivate");
			this.SetStateNiagaraShow(7);
			this.SetStateItemShow(null);
		}

		// Token: 0x0603C399 RID: 246681 RVA: 0x00F46BE0 File Offset: 0x00F44DE0
		public void SetStateTempActive()
		{
			this.SetActiveStateText("Morale_32_Buff_TempActivated", false);
			this.SetActiveStateBg("SP_FrameActivated");
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetIconChangeColor(true);
			this.SetBg("T_FlagChallengeBuffBgActivateTemp");
			this.SetStateNiagaraShow(8);
			this.SetStateItemShow(new int?(9));
		}

		// Token: 0x0603C39A RID: 246682 RVA: 0x00F46C44 File Offset: 0x00F44E44
		public void SetStateNotActive()
		{
			this.SetActiveStateText("Morale_32_Buff_NotActivated", true);
			this.SetActiveStateBg("SP_FrameUnactivated");
			this.SetIcon(this.BuffData.Config.IconPathNormal);
			this.SetIconChangeColor(false);
			this.SetBg("T_FlagChallengeBuffBgUnactivated");
			this.SetStateNiagaraShow(5);
			this.SetStateItemShow(new int?(6));
		}

		// Token: 0x0603C39B RID: 246683 RVA: 0x00F46CA8 File Offset: 0x00F44EA8
		private void SetActiveStateText(string key, bool useChangeColor = false)
		{
			UUIText text = base.GetText(12);
			text.ShowTextNew(key);
			UUIItem uuiitem = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(useChangeColor, fcolor);
		}

		// Token: 0x0603C39C RID: 246684 RVA: 0x00F46CDC File Offset: 0x00F44EDC
		private void SetActiveStateBg(string resId)
		{
			UUISprite sprite = base.GetSprite(11);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x0603C39D RID: 246685 RVA: 0x00F46D14 File Offset: 0x00F44F14
		private void SetIcon(string path)
		{
			UUITexture texture = base.GetTexture(4);
			base.SetTextureByPath(path, texture, null, null);
		}

		// Token: 0x0603C39E RID: 246686 RVA: 0x00F46D3C File Offset: 0x00F44F3C
		private void SetIconChangeColor(bool useChangeColor)
		{
			UUITexture texture = base.GetTexture(4);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(useChangeColor, fcolor);
		}

		// Token: 0x0603C39F RID: 246687 RVA: 0x00F46D68 File Offset: 0x00F44F68
		private void SetBg(string resId)
		{
			UUITexture texture = base.GetTexture(1);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x0603C3A0 RID: 246688 RVA: 0x00F46D9C File Offset: 0x00F44F9C
		private void SetStateNiagaraShow(int index)
		{
			foreach (int num in new List<int>
			{
				7,
				8,
				5
			})
			{
				UUINiagara uiNiagara = base.GetUiNiagara(num);
				if (uiNiagara != null)
				{
					uiNiagara.SetUIActive(index == num);
				}
			}
		}

		// Token: 0x0603C3A1 RID: 246689 RVA: 0x00F46E14 File Offset: 0x00F45014
		private void SetStateItemShow(int? index = null)
		{
			foreach (int num in new List<int>
			{
				9,
				6
			})
			{
				UUIItem item = base.GetItem(num);
				if (item != null)
				{
					int? num2 = index;
					int num3 = num;
					item.SetUIActive(num2.GetValueOrDefault() == num3 & num2 != null);
				}
			}
		}

		// Token: 0x04021D56 RID: 138582
		[Nullable(2)]
		private FlagChallengeBuffData BuffData;
	}
}
