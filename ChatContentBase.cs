using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200184E RID: 6222
[NullableContext(1)]
[Nullable(0)]
public class ChatContentBase : UiPanelBase
{
	// Token: 0x0600B1F7 RID: 45559 RVA: 0x002F7939 File Offset: 0x002F5B39
	public ChatContentBase(string resourceId, UUIItem parentItem, ChatContentData chatContentData, [Nullable(new byte[]
	{
		2,
		1
	})] Action<ChatContentBase> onLoaded = null)
	{
		this.ChatContentData = chatContentData;
		this.OnLoadedCallback = onLoaded;
		base.CreateThenShowByResourceIdAsync(resourceId, parentItem, true).ContinueWith(delegate()
		{
			Action<ChatContentBase> onLoadedCallback = this.OnLoadedCallback;
			if (onLoadedCallback == null)
			{
				return;
			}
			onLoadedCallback(this);
		});
	}

	// Token: 0x04005459 RID: 21593
	protected readonly ChatContentData ChatContentData;

	// Token: 0x0400545A RID: 21594
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly Action<ChatContentBase> OnLoadedCallback;
}
