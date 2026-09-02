using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D65 RID: 23909
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeLevelAreaItem : UiPanelBase
	{
		// Token: 0x0603C3D6 RID: 246742 RVA: 0x00F47C08 File Offset: 0x00F45E08
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIArtText)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
			};
		}

		// Token: 0x0603C3D7 RID: 246743 RVA: 0x00F47D20 File Offset: 0x00F45F20
		public void SetResIndex(int resIndex)
		{
			this.ResIndex = resIndex;
		}

		// Token: 0x0603C3D8 RID: 246744 RVA: 0x00F47D29 File Offset: 0x00F45F29
		public void Refresh(FlagChallengeAreaData data, int index)
		{
			this.Data = data;
			this.Index = new int?(index);
			this.RefreshView();
		}

		// Token: 0x0603C3D9 RID: 246745 RVA: 0x00F47D44 File Offset: 0x00F45F44
		public void RefreshView()
		{
			if (this.Data == null || this.Index == null)
			{
				return;
			}
			FlagChallengeAreaData data = this.Data;
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(data.ActivityId);
			EFlagChallengeUiStyleType uiStyle = flagChallengeData.GetLevelData(data.GetLevelId()).GetUiStyle();
			Dictionary<string, string> dictionary;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleRes.TryGetValue(uiStyle, out dictionary))
			{
				return;
			}
			string dynamicRes = FlagChallengeUtils.GetDynamicRes(uiStyle, "AreaItemMap", this.ResIndex);
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string resourcePath = instance.GetResourcePath(dynamicRes);
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			base.SetTextureByPath(resourcePath, base.GetTexture(9), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["AreaItemBg"]), base.GetTexture(2), null, null);
			base.SetTextureByPath(data.Config.IconPath, base.GetTexture(5), null, null);
			this.SetSpriteByPath(instance.GetResourcePath(dictionary["AreaItemLevelBg"]), base.GetSprite(3), false, null, null);
			UiResourceConfig uiResourceConfig = instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_MoraleRome");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Config.UiPos);
			this.SetSpriteByPath(uiResourceConfig.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear()), base.GetSprite(6), false, null, null);
			int[] recommendLevel = data.GetRecommendLevel();
			base.GetArtText(4).SetText(recommendLevel[1].ToString());
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(flagChallengeData.IsAreaAllBossStrongholdPass(this.Data.Id));
			}
			int num = 0;
			int[] strongholds = data.GetStrongholds();
			foreach (int strongholdId in strongholds)
			{
				FlagChallengeStrongholdData strongholdData = flagChallengeData.GetStrongholdData(strongholdId);
				if (strongholdData != null && strongholdData.IsPass)
				{
					num++;
				}
			}
			UUIText text = base.GetText(7);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(strongholds.Length);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603C3DA RID: 246746 RVA: 0x00F47F93 File Offset: 0x00F46193
		public void SetButtonClickCallback(Action<int> cb)
		{
			this.ButtonClickCallback = cb;
		}

		// Token: 0x0603C3DB RID: 246747 RVA: 0x00F47F9C File Offset: 0x00F4619C
		private void OnClickButton()
		{
			Action<int> buttonClickCallback = this.ButtonClickCallback;
			if (buttonClickCallback == null)
			{
				return;
			}
			buttonClickCallback(this.Data.Id);
		}

		// Token: 0x04021D95 RID: 138645
		[Nullable(2)]
		private FlagChallengeAreaData Data;

		// Token: 0x04021D96 RID: 138646
		private int? Index;

		// Token: 0x04021D97 RID: 138647
		private int ResIndex;

		// Token: 0x04021D98 RID: 138648
		[Nullable(2)]
		private Action<int> ButtonClickCallback;
	}
}
