using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200631D RID: 25373
	public class SpringManorAlbumConfirmItem : UiPanelBase
	{
		// Token: 0x0603FC44 RID: 261188 RVA: 0x0105961C File Offset: 0x0105781C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
		}

		// Token: 0x0603FC45 RID: 261189 RVA: 0x010596B8 File Offset: 0x010578B8
		public void SetState(EBrochureState state, int conditionGroupId)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(state == EBrochureState.Unlock);
			}
			bool flag = ModelBase<SpringManorModel>.Instance.IsQuestTracking(conditionGroupId);
			if (state == EBrochureState.Lock)
			{
				if (flag)
				{
					UUIText text = base.GetText(5);
					if (text != null)
					{
						text.ShowTextNew("PictureAlbum_BtnName_UnTrack");
					}
				}
				else
				{
					UUIText text2 = base.GetText(5);
					if (text2 != null)
					{
						text2.ShowTextNew("PictureAlbum_BtnName_Track");
					}
				}
			}
			else if (state == EBrochureState.Unlock)
			{
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					text3.ShowTextNew("PictureAlbum_BtnName_Receive");
				}
			}
			this.SetBtnBg(state == EBrochureState.Lock);
		}

		// Token: 0x0603FC46 RID: 261190 RVA: 0x01059744 File Offset: 0x01057944
		public void SetBtnBg(bool isTrackBtn)
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(!isTrackBtn);
			}
			UUISprite sprite2 = base.GetSprite(4);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(isTrackBtn);
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(!isTrackBtn);
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(isTrackBtn);
		}
	}
}
