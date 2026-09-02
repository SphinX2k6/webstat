using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AA RID: 27050
	public class CoopUpLevelTogItem : UiPanelBase
	{
		// Token: 0x0604315D RID: 274781 RVA: 0x0113B110 File Offset: 0x01139310
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIArtText)),
				new ValueTuple<int, Type>(5, typeof(UUIArtText)),
				new ValueTuple<int, Type>(6, typeof(UUIArtText))
			};
		}

		// Token: 0x0604315E RID: 274782 RVA: 0x0113B1C4 File Offset: 0x011393C4
		[NullableContext(1)]
		public void RefreshView(CoopLevelData levelData)
		{
			ECoopLevelStatus state = levelData.State;
			base.GetItem(3).SetUIActive(state == ECoopLevelStatus.Doing);
			base.GetItem(0).SetUIActive(state == ECoopLevelStatus.Doing);
			base.GetItem(1).SetUIActive(state == ECoopLevelStatus.Lock);
			base.GetItem(2).SetUIActive(state >= ECoopLevelStatus.Reward);
			this.SetRomaNumArtTxt(levelData.Level);
		}

		// Token: 0x0604315F RID: 274783 RVA: 0x0113B227 File Offset: 0x01139427
		public void SetRomaNumArtTxt(int num)
		{
			base.GetArtText(5).SetText(num.ToString());
			base.GetArtText(6).SetText(num.ToString());
			base.GetArtText(4).SetText(num.ToString());
		}
	}
}
