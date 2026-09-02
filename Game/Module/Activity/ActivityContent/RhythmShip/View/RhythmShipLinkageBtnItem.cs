using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064E0 RID: 25824
	internal class RhythmShipLinkageBtnItem : UiPanelBase
	{
		// Token: 0x06040B11 RID: 264977 RVA: 0x01096288 File Offset: 0x01094488
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickLinkageBtn))
			};
		}

		// Token: 0x06040B12 RID: 264978 RVA: 0x01096308 File Offset: 0x01094508
		public void RefreshItem(bool isToLinkage)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isToLinkage ? "T_IconRhythmShipLevelPic02" : "T_IconRhythmShipLevelPic01");
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), isToLinkage ? "RhythmShipLevelToLinkageArea" : "RhythmShipLevelToNormalArea", Array.Empty<object>());
		}

		// Token: 0x06040B13 RID: 264979 RVA: 0x0109636C File Offset: 0x0109456C
		private void OnClickLinkageBtn()
		{
			Action onClickLinkageBtnCallBack = this.OnClickLinkageBtnCallBack;
			if (onClickLinkageBtnCallBack == null)
			{
				return;
			}
			onClickLinkageBtnCallBack();
		}

		// Token: 0x040243EA RID: 148458
		[Nullable(2)]
		public Action OnClickLinkageBtnCallBack;
	}
}
