using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x02005740 RID: 22336
	public class DarkCoastDeliveryTipPanel : UiPanelBase
	{
		// Token: 0x06038DA0 RID: 232864 RVA: 0x00E66C74 File Offset: 0x00E64E74
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickTrackBtn))
			};
		}

		// Token: 0x06038DA1 RID: 232865 RVA: 0x00E66D78 File Offset: 0x00E64F78
		[NullableContext(1)]
		public void RefreshUi(DarkCoastDeliveryLevelData data)
		{
			this.Data = data;
			base.SetTextureShowUntilLoaded(data.Config.TipIcon, base.GetTexture(0), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Config.TipName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Config.TipDesc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.Config.UnlockCondition, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "DarkShoreRewardNumber", new <>z__ReadOnlySingleElementList<object>(data.Config.RewardCount));
			MingSuDefine.EDarkCoastDeliveryLevelDataState darkCoastDeliveryGuardState = data.GetDarkCoastDeliveryGuardState();
			base.GetItem(5).SetUIActive(darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Lock);
			base.GetButton(4).RootUIComp.Get().SetUIActive(darkCoastDeliveryGuardState > MingSuDefine.EDarkCoastDeliveryLevelDataState.Lock);
			base.GetItem(7).SetUIActive(darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Passed);
			base.GetItem(8).SetUIActive(darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Received);
		}

		// Token: 0x06038DA2 RID: 232866 RVA: 0x00E66E98 File Offset: 0x00E65098
		private void OnClickTrackBtn()
		{
			SkipTaskManager.RunByConfigId(this.Data.Config.JumpId, null);
		}

		// Token: 0x04020609 RID: 132617
		[Nullable(2)]
		private DarkCoastDeliveryLevelData Data;

		// Token: 0x0200B7F2 RID: 47090
		private static class EComponent
		{
			// Token: 0x04038E50 RID: 233040
			public const int TipTexture = 0;

			// Token: 0x04038E51 RID: 233041
			public const int TipTitle = 1;

			// Token: 0x04038E52 RID: 233042
			public const int TipDesc = 2;

			// Token: 0x04038E53 RID: 233043
			public const int RewardCount = 3;

			// Token: 0x04038E54 RID: 233044
			public const int TrackBtn = 4;

			// Token: 0x04038E55 RID: 233045
			public const int LockItem = 5;

			// Token: 0x04038E56 RID: 233046
			public const int LockText = 6;

			// Token: 0x04038E57 RID: 233047
			public const int AchieveTip = 7;

			// Token: 0x04038E58 RID: 233048
			public const int ReceivedTip = 8;
		}
	}
}
