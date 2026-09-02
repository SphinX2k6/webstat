using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005984 RID: 22916
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentConditionBar : UiPanelBase
	{
		// Token: 0x0603A0DD RID: 237789 RVA: 0x00EB1B90 File Offset: 0x00EAFD90
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.ButtonCallBackInternal))
			};
		}

		// Token: 0x0603A0DE RID: 237790 RVA: 0x00EB1C0D File Offset: 0x00EAFE0D
		public void SetTextByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x0603A0DF RID: 237791 RVA: 0x00EB1C22 File Offset: 0x00EAFE22
		public void SetTextByText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0603A0E0 RID: 237792 RVA: 0x00EB1C32 File Offset: 0x00EAFE32
		public UUISprite GetIconSprite()
		{
			return base.GetSprite(0);
		}

		// Token: 0x0603A0E1 RID: 237793 RVA: 0x00EB1C3B File Offset: 0x00EAFE3B
		public void SetSpriteVisible(bool bVisible)
		{
			base.GetSprite(0).SetUIActive(bVisible);
		}

		// Token: 0x0603A0E2 RID: 237794 RVA: 0x00EB1C4C File Offset: 0x00EAFE4C
		public void SetButtonVisible(bool bVisible)
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x0603A0E3 RID: 237795 RVA: 0x00EB1C73 File Offset: 0x00EAFE73
		private void ButtonCallBackInternal()
		{
			Action buttonCallBack = this.ButtonCallBack;
			if (buttonCallBack == null)
			{
				return;
			}
			buttonCallBack();
		}

		// Token: 0x04020EE2 RID: 134882
		[Nullable(2)]
		public Action ButtonCallBack;
	}
}
