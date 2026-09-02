using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200578C RID: 22412
	[NullableContext(2)]
	[Nullable(0)]
	public class MenuDetailPopViewItemView
	{
		// Token: 0x0603903D RID: 233533 RVA: 0x00E72ACB File Offset: 0x00E70CCB
		public MenuDetailPopViewItemView(UUIText textComponent, UUITexture textureComponent, [Nullable(1)] Action<string, UUITexture> setTextureHandler)
		{
			this.TextComponent = textComponent;
			this.TextureComponent = textureComponent;
			this.SetTextureHandler = setTextureHandler;
		}

		// Token: 0x0603903E RID: 233534 RVA: 0x00E72AF0 File Offset: 0x00E70CF0
		[NullableContext(1)]
		public void RefreshByData(MenuDetailPopItemData data)
		{
			UUIText textComponent = this.TextComponent;
			if (textComponent != null)
			{
				textComponent.SetUIActive(data.Title.Length > 0);
			}
			if (textComponent != null && data.Title.Length > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(textComponent, data.Title, Array.Empty<object>());
			}
			if (data.ShowType == EMenuDetailItemShowType.Picture)
			{
				this.SetTextureHandler(data.ResourcePath, this.TextureComponent);
				return;
			}
			if (data.ShowType == EMenuDetailItemShowType.Video || data.ShowType == EMenuDetailItemShowType.WideVideo)
			{
				this.MediaPlayer = (this.MediaPlayer ?? new MediaPlayer(this.TextureComponent));
				if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
				{
					this.LoadMaterial().ContinueWith(delegate()
					{
						MediaPlayer mediaPlayer2 = this.MediaPlayer;
						if (mediaPlayer2 == null)
						{
							return;
						}
						mediaPlayer2.PlayVideo("MenuDetailPopViewItemPanel", data.ResourcePath, true);
					}).Forget();
					return;
				}
				MediaPlayer mediaPlayer = this.MediaPlayer;
				if (mediaPlayer == null)
				{
					return;
				}
				mediaPlayer.PlayVideo("MenuDetailPopViewItemPanel", data.ResourcePath, true);
			}
		}

		// Token: 0x0603903F RID: 233535 RVA: 0x00E72C11 File Offset: 0x00E70E11
		public void Clear()
		{
			MediaPlayer mediaPlayer = this.MediaPlayer;
			if (mediaPlayer != null)
			{
				mediaPlayer.Clear();
			}
			this.MediaPlayer = null;
			this.CancelLoad();
		}

		// Token: 0x06039040 RID: 233536 RVA: 0x00E72C34 File Offset: 0x00E70E34
		private UniTask LoadMaterial()
		{
			MenuDetailPopViewItemView.<LoadMaterial>d__9 <LoadMaterial>d__;
			<LoadMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadMaterial>d__.<>4__this = this;
			<LoadMaterial>d__.<>1__state = -1;
			<LoadMaterial>d__.<>t__builder.Start<MenuDetailPopViewItemView.<LoadMaterial>d__9>(ref <LoadMaterial>d__);
			return <LoadMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x06039041 RID: 233537 RVA: 0x00E72C77 File Offset: 0x00E70E77
		private void CancelLoad()
		{
			if (this.HandleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
				this.HandleId = -1;
			}
		}

		// Token: 0x04020771 RID: 132977
		[Nullable(1)]
		private const string VIDEO_NAME = "MenuDetailPopViewItemPanel";

		// Token: 0x04020772 RID: 132978
		private readonly UUIText TextComponent;

		// Token: 0x04020773 RID: 132979
		private readonly UUITexture TextureComponent;

		// Token: 0x04020774 RID: 132980
		[Nullable(1)]
		private readonly Action<string, UUITexture> SetTextureHandler;

		// Token: 0x04020775 RID: 132981
		private MediaPlayer MediaPlayer;

		// Token: 0x04020776 RID: 132982
		private int HandleId = -1;
	}
}
