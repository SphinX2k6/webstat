using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011A9 RID: 4521
public class ArtemisChatRightItem : UiPanelBase
{
	// Token: 0x06007705 RID: 30469 RVA: 0x001F2710 File Offset: 0x001F0910
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISizeControlByOther)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickPictureButton))
		};
	}

	// Token: 0x06007706 RID: 30470 RVA: 0x001F2828 File Offset: 0x001F0A28
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUISprite sprite2 = base.GetSprite(6);
		if (sprite2 == null)
		{
			return;
		}
		sprite2.SetUIActive(false);
	}

	// Token: 0x06007707 RID: 30471 RVA: 0x001F2880 File Offset: 0x001F0A80
	[NullableContext(1)]
	public void SetContent(IArtemisChatItemData data)
	{
		this.SetPlayerHead();
		base.GetUiSizeControlByOther(3).GetRootComponent().SetUIActive(!string.IsNullOrEmpty(data.Content));
		if (!string.IsNullOrEmpty(data.Content))
		{
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(data.Content);
			}
		}
		bool flag = !string.IsNullOrEmpty(data.PicturePath);
		this.TexturePath = data.PicturePath;
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		string path = flag ? null : data.PicturePath;
		base.TrySetTextureByPath(path, base.GetTexture(9), null, null);
	}

	// Token: 0x06007708 RID: 30472 RVA: 0x001F2938 File Offset: 0x001F0B38
	private void SetPlayerHead()
	{
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(numberPropById.GetValueOrDefault(), true);
		UUITexture headTexture = base.GetTexture(1);
		UUITexture headTexture3 = headTexture;
		if (headTexture3 != null)
		{
			headTexture3.SetUIActive(false);
		}
		if (playerHeadData != null)
		{
			base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), headTexture, delegate(bool _)
			{
				UUITexture headTexture2 = headTexture;
				if (headTexture2 == null)
				{
					return;
				}
				headTexture2.SetUIActive(true);
			});
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("Activity_ArtemisChatRoverName");
		}
	}

	// Token: 0x06007709 RID: 30473 RVA: 0x001F29C0 File Offset: 0x001F0BC0
	private void OnClickPictureButton()
	{
		if (!string.IsNullOrEmpty(this.TexturePath))
		{
			ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(this.TexturePath);
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayImgView();
		}
	}

	// Token: 0x04003981 RID: 14721
	[Nullable(2)]
	private string TexturePath;

	// Token: 0x02007502 RID: 29954
	private class EComponents
	{
		// Token: 0x0402865C RID: 165468
		public const int TxtTime = 0;

		// Token: 0x0402865D RID: 165469
		public const int TextureHead = 1;

		// Token: 0x0402865E RID: 165470
		public const int TxtPlayerName = 2;

		// Token: 0x0402865F RID: 165471
		public const int PnlChatContent = 3;

		// Token: 0x04028660 RID: 165472
		public const int TxtChat = 4;

		// Token: 0x04028661 RID: 165473
		public const int SpriteIconState = 5;

		// Token: 0x04028662 RID: 165474
		public const int TextureChatEmote = 6;

		// Token: 0x04028663 RID: 165475
		public const int PnlInput = 7;

		// Token: 0x04028664 RID: 165476
		public const int BtnPic = 8;

		// Token: 0x04028665 RID: 165477
		public const int TextPic = 9;
	}
}
