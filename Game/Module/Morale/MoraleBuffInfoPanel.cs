using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005710 RID: 22288
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffInfoPanel : UiPanelBase
	{
		// Token: 0x06038BA0 RID: 232352 RVA: 0x00E5CEE8 File Offset: 0x00E5B0E8
		public UniTask Init(UUIItem item)
		{
			MoraleBuffInfoPanel.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleBuffInfoPanel.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038BA1 RID: 232353 RVA: 0x00E5CF34 File Offset: 0x00E5B134
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

		// Token: 0x06038BA2 RID: 232354 RVA: 0x00E5D070 File Offset: 0x00E5B270
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleBuffInfoPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleBuffInfoPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038BA3 RID: 232355 RVA: 0x00E5D0B4 File Offset: 0x00E5B2B4
		public void UpdateData(MoraleBuffData data)
		{
			this.BuffData = data;
			this.UpdateState();
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(data.Config.BuffName);
			}
			UUIText text2 = base.GetText(3);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(data.Config.BuffDescDetail);
		}

		// Token: 0x06038BA4 RID: 232356 RVA: 0x00E5D108 File Offset: 0x00E5B308
		public void UpdateState()
		{
			switch (this.BuffData.GetActiveState())
			{
			case EMoraleBuffState.TempActive:
				this.SetStateTempActive();
				return;
			case EMoraleBuffState.Active:
				this.SetStateActive();
				return;
			case EMoraleBuffState.NotActive:
				this.SetStateNotActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x06038BA5 RID: 232357 RVA: 0x00E5D148 File Offset: 0x00E5B348
		public void SetStateActive()
		{
			this.SetActiveStateText("Morale_title_11", false);
			this.SetActiveStateBg("SP_FrameActivated");
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetIconChangeColor(true);
			this.SetBg("T_MoraleBuffBgActivate");
			this.SetStateNiagaraShow(7);
			this.SetStateItemShow(null);
		}

		// Token: 0x06038BA6 RID: 232358 RVA: 0x00E5D1AC File Offset: 0x00E5B3AC
		public void SetStateTempActive()
		{
			this.SetActiveStateText("Morale_title_10", false);
			this.SetActiveStateBg("SP_FrameActivated");
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetIconChangeColor(true);
			this.SetBg("T_MoraleBuffBgActivateTemp");
			this.SetStateNiagaraShow(8);
			this.SetStateItemShow(new int?(9));
		}

		// Token: 0x06038BA7 RID: 232359 RVA: 0x00E5D20C File Offset: 0x00E5B40C
		public void SetStateNotActive()
		{
			this.SetActiveStateText("Morale_title_12", true);
			this.SetActiveStateBg("SP_FrameUnactivated");
			this.SetIcon(this.BuffData.Config.IconPathNormal);
			this.SetIconChangeColor(false);
			this.SetBg("T_MoraleBuffBgUnactivated");
			this.SetStateNiagaraShow(5);
			this.SetStateItemShow(new int?(6));
		}

		// Token: 0x06038BA8 RID: 232360 RVA: 0x00E5D26C File Offset: 0x00E5B46C
		private void SetActiveStateText(string key, bool useChangeColor = false)
		{
			UUIText text = base.GetText(12);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			if (text != null)
			{
				UUIItem uuiitem = text;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(useChangeColor, fcolor);
			}
		}

		// Token: 0x06038BA9 RID: 232361 RVA: 0x00E5D2A4 File Offset: 0x00E5B4A4
		private void SetActiveStateBg(string resId)
		{
			UUISprite sprite = base.GetSprite(11);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x06038BAA RID: 232362 RVA: 0x00E5D2DC File Offset: 0x00E5B4DC
		private void SetIcon(string path)
		{
			UUITexture texture = base.GetTexture(4);
			base.SetTextureByPath(path, texture, null, null);
		}

		// Token: 0x06038BAB RID: 232363 RVA: 0x00E5D304 File Offset: 0x00E5B504
		private void SetIconChangeColor(bool useChangeColor)
		{
			UUITexture texture = base.GetTexture(4);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(useChangeColor, fcolor);
		}

		// Token: 0x06038BAC RID: 232364 RVA: 0x00E5D330 File Offset: 0x00E5B530
		private void SetBg(string resId)
		{
			UUITexture texture = base.GetTexture(1);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x06038BAD RID: 232365 RVA: 0x00E5D364 File Offset: 0x00E5B564
		private void SetStateNiagaraShow(int index)
		{
			foreach (int num in new int[]
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

		// Token: 0x06038BAE RID: 232366 RVA: 0x00E5D3AC File Offset: 0x00E5B5AC
		private void SetStateItemShow(int? index = null)
		{
			foreach (int num in new int[]
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

		// Token: 0x0402053F RID: 132415
		public MoraleBuffData BuffData;

		// Token: 0x0200B7AA RID: 47018
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CEB RID: 232683
			public const int ItemDesc = 0;

			// Token: 0x04038CEC RID: 232684
			public const int TextureBg = 1;

			// Token: 0x04038CED RID: 232685
			public const int TextName = 2;

			// Token: 0x04038CEE RID: 232686
			public const int TextDesc = 3;

			// Token: 0x04038CEF RID: 232687
			public const int TextureIcon = 4;

			// Token: 0x04038CF0 RID: 232688
			public const int NiagaraLock = 5;

			// Token: 0x04038CF1 RID: 232689
			public const int ItemLock = 6;

			// Token: 0x04038CF2 RID: 232690
			public const int NiagaraActive = 7;

			// Token: 0x04038CF3 RID: 232691
			public const int NiagaraTempActive = 8;

			// Token: 0x04038CF4 RID: 232692
			public const int ItemTempActive = 9;

			// Token: 0x04038CF5 RID: 232693
			public const int ItemActiveStateTag = 10;

			// Token: 0x04038CF6 RID: 232694
			public const int SpriteActiveStateBg = 11;

			// Token: 0x04038CF7 RID: 232695
			public const int TextActiveState = 12;
		}
	}
}
