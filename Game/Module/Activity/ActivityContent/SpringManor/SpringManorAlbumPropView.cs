using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200633B RID: 25403
	public class SpringManorAlbumPropView : UiViewBase
	{
		// Token: 0x0603FCE1 RID: 261345 RVA: 0x0105CAAD File Offset: 0x0105ACAD
		[NullableContext(1)]
		public SpringManorAlbumPropView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FCE2 RID: 261346 RVA: 0x0105CAB8 File Offset: 0x0105ACB8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
			};
		}

		// Token: 0x0603FCE3 RID: 261347 RVA: 0x0105CB4B File Offset: 0x0105AD4B
		protected override void OnBeforeDestroy()
		{
			this.ClearAutoCloseTimer();
		}

		// Token: 0x0603FCE4 RID: 261348 RVA: 0x0105CB53 File Offset: 0x0105AD53
		protected override void OnBeforeShow()
		{
			this.RefreshView();
			this.AutoCloseTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnAutoClose), 4000f, null, null, true, 1f);
		}

		// Token: 0x0603FCE5 RID: 261349 RVA: 0x0105CB84 File Offset: 0x0105AD84
		private void RefreshView()
		{
			SpringManorAlbumPropViewOpenParam springManorAlbumPropViewOpenParam = this.OpenParam as SpringManorAlbumPropViewOpenParam;
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureById(springManorAlbumPropViewOpenParam.BrochureId) : null;
			if (brochure != null)
			{
				EBrochureType type = (EBrochureType)brochure.Value.Type;
				if (type == EBrochureType.Character)
				{
					UUIText text = base.GetText(2);
					if (text != null)
					{
						text.ShowTextNew("PrefabTextItem_1493464652_Text");
					}
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_AlbumPropIcon01");
					base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
				}
				else if (type == EBrochureType.EasterEggBook)
				{
					UUIText text2 = base.GetText(2);
					if (text2 != null)
					{
						text2.ShowTextNew("PrefabTextItem_3103733560_Text");
					}
					string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_AlbumPropIcon00");
					base.SetTextureByPath(resourcePath2, base.GetTexture(1), null, null);
				}
			}
			SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance2 != null) ? instance2.GetSpringManorBookItemById(springManorAlbumPropViewOpenParam.ConfigId) : null;
			if (bookItem != null)
			{
				UUIText text3 = base.GetText(3);
				if (text3 == null)
				{
					return;
				}
				text3.ShowTextNew((bookItem != null) ? bookItem.GetValueOrDefault().DescriptionTitle : null);
			}
		}

		// Token: 0x0603FCE6 RID: 261350 RVA: 0x0105CCC1 File Offset: 0x0105AEC1
		private void OnAutoClose(float _)
		{
			this.AutoCloseTimer = null;
			base.CloseMe(null);
		}

		// Token: 0x0603FCE7 RID: 261351 RVA: 0x0105CCD1 File Offset: 0x0105AED1
		private void ClearAutoCloseTimer()
		{
			TimerHandle autoCloseTimer = this.AutoCloseTimer;
			if (autoCloseTimer != null && autoCloseTimer.Valid())
			{
				TimerSystem.Instance.Remove(this.AutoCloseTimer);
				this.AutoCloseTimer = null;
			}
		}

		// Token: 0x0603FCE8 RID: 261352 RVA: 0x0105CD00 File Offset: 0x0105AF00
		private void OnClickButton()
		{
			SpringManorAlbumPropViewOpenParam springManorAlbumPropViewOpenParam = this.OpenParam as SpringManorAlbumPropViewOpenParam;
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureById(springManorAlbumPropViewOpenParam.BrochureId) : null;
			if (brochure != null)
			{
				SpringManorAlbumViewOpenParam param = new SpringManorAlbumViewOpenParam
				{
					OpenTab = (EBrochureType)brochure.Value.Type
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAlbumView, param, null);
				base.CloseMe(null);
			}
		}

		// Token: 0x04023D69 RID: 146793
		private const int DEFAULT_AUTO_CLOSE_TIME = 4000;

		// Token: 0x04023D6A RID: 146794
		[Nullable(2)]
		private TimerHandle AutoCloseTimer;
	}
}
