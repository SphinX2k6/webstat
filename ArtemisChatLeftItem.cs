using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011A8 RID: 4520
[NullableContext(2)]
[Nullable(0)]
public class ArtemisChatLeftItem : UiPanelBase
{
	// Token: 0x060076F8 RID: 30456 RVA: 0x001F2238 File Offset: 0x001F0438
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
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickPictureButton))
		};
	}

	// Token: 0x060076F9 RID: 30457 RVA: 0x001F2368 File Offset: 0x001F0568
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
		}
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

	// Token: 0x060076FA RID: 30458 RVA: 0x001F23F3 File Offset: 0x001F05F3
	protected override void OnBeforeDestroy()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x060076FB RID: 30459 RVA: 0x001F2423 File Offset: 0x001F0623
	[NullableContext(1)]
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Dele_M")
		{
			this.LoadTextMaterial(false);
			this.RefreshPlayerTextureCustomMaterial(this.TexturePath, false).Forget();
		}
	}

	// Token: 0x060076FC RID: 30460 RVA: 0x001F244C File Offset: 0x001F064C
	[NullableContext(1)]
	public void SetContent(IArtemisChatItemData data)
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("ArtemisChatHeadIconPath");
		this.CheckPathSetTexture(stringConfig, 1);
		string stringConfig2 = ConfigCommonParamById.GetStringConfig("ArtemisChatHeadName");
		if (stringConfig2 != null && stringConfig2.Length > 0)
		{
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(stringConfig2);
			}
		}
		base.GetUiSizeControlByOther(3).GetRootComponent().SetUIActive(data.Content.Length > 0);
		this.SetChatContent(data.Content);
		this.TexturePath = data.PicturePath;
		bool flag = data.PicturePath != null && data.PicturePath.Length > 0;
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		if (data.IsLock)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}
		this.LoadTextMaterial(data.IsLock);
		UUISprite sprite = base.GetSprite(10);
		if (sprite != null)
		{
			sprite.SetAlpha(data.IsShowEffect > false);
		}
		if (flag)
		{
			this.RefreshPlayerTextureCustomMaterial(this.TexturePath, data.IsShowEffect).Forget();
		}
	}

	// Token: 0x060076FD RID: 30461 RVA: 0x001F2574 File Offset: 0x001F0774
	[NullableContext(1)]
	private void SetChatContent(string content)
	{
		if (content != null && content.Length > 0)
		{
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(content);
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetAlpha(1f);
		}
	}

	// Token: 0x060076FE RID: 30462 RVA: 0x001F25AC File Offset: 0x001F07AC
	private void CheckPathSetTexture(string path, int componentIndex)
	{
		string path2 = (path != null && path.Length > 0) ? path : null;
		base.TrySetTextureByPath(path2, base.GetTexture(componentIndex), null, null);
	}

	// Token: 0x060076FF RID: 30463 RVA: 0x001F25E2 File Offset: 0x001F07E2
	private void OnClickPictureButton()
	{
		if (!string.IsNullOrEmpty(this.TexturePath))
		{
			ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(this.TexturePath);
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayImgView();
		}
	}

	// Token: 0x06007700 RID: 30464 RVA: 0x001F260C File Offset: 0x001F080C
	private UniTask RefreshPlayerTextureCustomMaterial(string picturePath, bool isLock)
	{
		ArtemisChatLeftItem.<RefreshPlayerTextureCustomMaterial>d__11 <RefreshPlayerTextureCustomMaterial>d__;
		<RefreshPlayerTextureCustomMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshPlayerTextureCustomMaterial>d__.<>4__this = this;
		<RefreshPlayerTextureCustomMaterial>d__.picturePath = picturePath;
		<RefreshPlayerTextureCustomMaterial>d__.isLock = isLock;
		<RefreshPlayerTextureCustomMaterial>d__.<>1__state = -1;
		<RefreshPlayerTextureCustomMaterial>d__.<>t__builder.Start<ArtemisChatLeftItem.<RefreshPlayerTextureCustomMaterial>d__11>(ref <RefreshPlayerTextureCustomMaterial>d__);
		return <RefreshPlayerTextureCustomMaterial>d__.<>t__builder.Task;
	}

	// Token: 0x06007701 RID: 30465 RVA: 0x001F2660 File Offset: 0x001F0860
	private void LoadTextMaterial(bool loadMaterial)
	{
		if (loadMaterial)
		{
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string text = (instance != null) ? instance.GetResourcePath("MI_GlitchAimisText") : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(text, delegate([Nullable(2)] UMaterialInterface material, string _)
			{
				UUIText text3 = base.GetText(4);
				if (text3 == null)
				{
					return;
				}
				text3.SetCustomUIMaterial(material);
			}, ResourceSystem.EResourceLoadPriority.Ui, this.MemoryTag);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetCustomUIMaterial(null);
			return;
		}
	}

	// Token: 0x06007702 RID: 30466 RVA: 0x001F26C4 File Offset: 0x001F08C4
	public void PlayFixDoneLevelSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Fix_Done", false, null, false);
	}

	// Token: 0x0400397F RID: 14719
	private string TexturePath;

	// Token: 0x04003980 RID: 14720
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007500 RID: 29952
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402864B RID: 165451
		public const int TxtTime = 0;

		// Token: 0x0402864C RID: 165452
		public const int TextureHead = 1;

		// Token: 0x0402864D RID: 165453
		public const int TxtPlayerName = 2;

		// Token: 0x0402864E RID: 165454
		public const int PnlChatContent = 3;

		// Token: 0x0402864F RID: 165455
		public const int TxtChat = 4;

		// Token: 0x04028650 RID: 165456
		public const int SpriteIconState = 5;

		// Token: 0x04028651 RID: 165457
		public const int TextureChatEmote = 6;

		// Token: 0x04028652 RID: 165458
		public const int PnlInput = 7;

		// Token: 0x04028653 RID: 165459
		public const int BtnPic = 8;

		// Token: 0x04028654 RID: 165460
		public const int TextPic = 9;

		// Token: 0x04028655 RID: 165461
		public const int TextMosaicSprite = 10;
	}
}
