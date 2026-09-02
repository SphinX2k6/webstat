using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005947 RID: 22855
	public class MapRogueTitleItem : UiPanelBase
	{
		// Token: 0x06039F65 RID: 237413 RVA: 0x00EAB798 File Offset: 0x00EA9998
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
			};
		}

		// Token: 0x06039F66 RID: 237414 RVA: 0x00EAB818 File Offset: 0x00EA9A18
		protected override void OnStart()
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			RogueResInstGrid? insGridConfigByInstId = ConfigBase<MapRogueConfig>.Instance.GetInsGridConfigByInstId(gameInfo.InstanceId);
			if (insGridConfigByInstId == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, insGridConfigByInstId.Value.Title, Array.Empty<object>());
			this.RefreshProgress();
		}

		// Token: 0x06039F67 RID: 237415 RVA: 0x00EAB87C File Offset: 0x00EA9A7C
		public void RefreshProgress()
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			int num = gameInfo.ExplorationCurrentProgress();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RogueResExplore_3", new <>z__ReadOnlySingleElementList<object>(num));
		}

		// Token: 0x06039F68 RID: 237416 RVA: 0x00EAB8C0 File Offset: 0x00EA9AC0
		private void OnBtnClick()
		{
			if (this.CheckCanBtnClick != null && !this.CheckCanBtnClick())
			{
				return;
			}
			ControllerBase<MapRogueController>.Instance.OpenExplore();
		}

		// Token: 0x04020D8A RID: 134538
		[Nullable(2)]
		public Func<bool> CheckCanBtnClick;
	}
}
