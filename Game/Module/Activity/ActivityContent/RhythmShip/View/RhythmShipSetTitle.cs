using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650B RID: 25867
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RhythmShipSetTitle : SyncGridProxyAbstract<RhythmShipSetData>
	{
		// Token: 0x06040B93 RID: 265107 RVA: 0x01098EF0 File Offset: 0x010970F0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtn))
			};
		}

		// Token: 0x06040B94 RID: 265108 RVA: 0x01098F58 File Offset: 0x01097158
		public override void Refresh(RhythmShipSetData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Text, Array.Empty<object>());
			base.GetButton(2).RootUIComp.Get().SetUIActive(data.Type == ERhythmShipSetDataType.TitleWithBtn);
		}

		// Token: 0x06040B95 RID: 265109 RVA: 0x01098FA3 File Offset: 0x010971A3
		private void OnClickBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipSetTipsView, null, null);
		}
	}
}
