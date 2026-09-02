using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E7 RID: 27111
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AnniversaryWorldRewardItem : GridProxyAbstract<AnniversaryWorldRewardItemData>
	{
		// Token: 0x06043314 RID: 275220 RVA: 0x01144430 File Offset: 0x01142630
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x06043315 RID: 275221 RVA: 0x01144505 File Offset: 0x01142705
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06043316 RID: 275222 RVA: 0x01144510 File Offset: 0x01142710
		public override void Refresh(AnniversaryWorldRewardItemData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.Data = data;
			EAnniversaryProgressRewardState valueOrDefault = this.Data.State.GetValueOrDefault();
			bool flag = valueOrDefault == EAnniversaryProgressRewardState.Rewarded;
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(flag);
			}
			UUITexture texture2 = base.GetTexture(3);
			if (texture2 != null)
			{
				bool bUseChangeColor = !flag;
				FColor? fcolor = null;
				texture2.SetChangeColor(bUseChangeColor, fcolor);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(valueOrDefault == EAnniversaryProgressRewardState.CanReceive);
			}
			this.SetBgTexture(valueOrDefault);
			WorldProgressCurve? worldProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveById(this.Data.CfgId);
			if (worldProgressCurveById == null)
			{
				return;
			}
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(worldProgressCurveById.Value.Percent / 100);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06043317 RID: 275223 RVA: 0x01144608 File Offset: 0x01142808
		private void SetBgTexture(EAnniversaryProgressRewardState state)
		{
			string text = null;
			switch (state)
			{
			case EAnniversaryProgressRewardState.Lock:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_AnniversaryCelebrationRewardBgNor");
				break;
			case EAnniversaryProgressRewardState.CanReceive:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_AnniversaryCelebrationRewardGetTips");
				break;
			case EAnniversaryProgressRewardState.Rewarded:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_AnniversaaryCelebrationRewardBgFinished");
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				base.TrySetTextureByPath(text, base.GetTexture(1), null, null);
			}
		}

		// Token: 0x06043318 RID: 275224 RVA: 0x0114467F File Offset: 0x0114287F
		private void OnClick()
		{
			if (this.Data != null)
			{
				Action<int> clickCallback = this.ClickCallback;
				if (clickCallback == null)
				{
					return;
				}
				clickCallback(this.Data.CfgId);
			}
		}

		// Token: 0x04025713 RID: 153363
		[Nullable(2)]
		private AnniversaryWorldRewardItemData Data;

		// Token: 0x04025714 RID: 153364
		[Nullable(2)]
		private Action<int> ClickCallback;

		// Token: 0x0200C963 RID: 51555
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403DEF8 RID: 253688
			public const int BtnItem = 0;

			// Token: 0x0403DEF9 RID: 253689
			public const int TexBgFinished = 1;

			// Token: 0x0403DEFA RID: 253690
			public const int TexRewardIcon = 2;

			// Token: 0x0403DEFB RID: 253691
			public const int TexFinishedIcon = 3;

			// Token: 0x0403DEFC RID: 253692
			public const int PnlFinished = 4;

			// Token: 0x0403DEFD RID: 253693
			public const int TxtProgress = 5;

			// Token: 0x0403DEFE RID: 253694
			public const int FxEffect = 6;
		}
	}
}
