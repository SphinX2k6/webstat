using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006430 RID: 25648
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeEntranceButton : ButtonItem
	{
		// Token: 0x06040641 RID: 263745 RVA: 0x01081E3B File Offset: 0x0108003B
		public RoverlikeEntranceButton(UUIItem uiItem = null) : base(uiItem)
		{
		}

		// Token: 0x06040642 RID: 263746 RVA: 0x01081E44 File Offset: 0x01080044
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIText)));
		}

		// Token: 0x06040643 RID: 263747 RVA: 0x01081EA8 File Offset: 0x010800A8
		public void RefreshSaveInfo(RoverlikeActivityData activityData)
		{
			UUIItem item = base.GetItem(3);
			bool flag = activityData != null && activityData.HasSaveProgress();
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			UUIText text = base.GetText(4);
			RoverRogueHistoryInsInfo historyInsInfo = activityData.HistoryInsInfo;
			RoverRogueIns? roverRogueIns;
			string text2 = (ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(historyInsInfo.CurInsId) != null) ? roverRogueIns.GetValueOrDefault().Name : null;
			string text3 = (!string.IsNullOrEmpty(text2)) ? (ConfigMultiTextLang.GetLocalTextNew(text2, null) ?? "") : "";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(historyInsInfo.CurLayer);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(historyInsInfo.TotalLayer);
			string text4 = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoverRogue_GameProcessShow", new <>z__ReadOnlyArray<object>(new object[]
			{
				text3,
				text4
			}));
		}

		// Token: 0x06040644 RID: 263748 RVA: 0x01081F98 File Offset: 0x01080198
		public void RefreshNewLevelUnlockRedDot(RoverlikeActivityData activityData)
		{
			bool uiactive = activityData != null && activityData.HasNewLevelUnlockRedDot();
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0200C4A1 RID: 50337
		[NullableContext(0)]
		private class EEntranceButtonDefine
		{
			// Token: 0x0403C85E RID: 247902
			public const int RedDotItem = 2;

			// Token: 0x0403C85F RID: 247903
			public const int PnlSaveInfo = 3;

			// Token: 0x0403C860 RID: 247904
			public const int TxtSaveInfo = 4;
		}
	}
}
