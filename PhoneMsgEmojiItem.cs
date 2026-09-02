using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200256A RID: 9578
public class PhoneMsgEmojiItem : GridProxyAbstract<int>
{
	// Token: 0x060129F9 RID: 76281 RVA: 0x00522296 File Offset: 0x00520496
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x060129FA RID: 76282 RVA: 0x005222CF File Offset: 0x005204CF
	protected override void OnStart()
	{
		base.OnStart();
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnClickToggle));
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x060129FB RID: 76283 RVA: 0x0052230C File Offset: 0x0052050C
	public override void Refresh(int emojiId, bool isSelected, int gridIndex)
	{
		this.Data = emojiId;
		UUITexture texture = base.GetTexture(1);
		string emojiTexturePathByEmojiId = ModelBase<PhoneMsgModel>.Instance.GetEmojiTexturePathByEmojiId(emojiId);
		base.SetTextureByPath(emojiTexturePathByEmojiId, texture, null, null);
	}

	// Token: 0x060129FC RID: 76284 RVA: 0x00522346 File Offset: 0x00520546
	private void OnClickToggle(EToggleState state)
	{
		Action<int> onClickDelegate = this.OnClickDelegate;
		if (onClickDelegate == null)
		{
			return;
		}
		onClickDelegate(base.GridIndex);
	}

	// Token: 0x060129FD RID: 76285 RVA: 0x0052235E File Offset: 0x0052055E
	private bool CanExecuteChange()
	{
		return false;
	}

	// Token: 0x04009186 RID: 37254
	protected int Data;

	// Token: 0x04009187 RID: 37255
	[Nullable(2)]
	public Action<int> OnClickDelegate;

	// Token: 0x02008882 RID: 34946
	private enum ETogEmojiComponent
	{
		// Token: 0x0402E1B8 RID: 188856
		TogEmoji,
		// Token: 0x0402E1B9 RID: 188857
		TexEmoji
	}
}
