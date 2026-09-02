using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001AFB RID: 6907
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class OnlineItem : GridProxyAbstract<OnlineData>
{
	// Token: 0x0600C6ED RID: 50925 RVA: 0x00349AE7 File Offset: 0x00347CE7
	public OnlineItem(bool isShowInBottom)
	{
		this.IsShowInBottom = isShowInBottom;
	}

	// Token: 0x0600C6EE RID: 50926 RVA: 0x00349AF8 File Offset: 0x00347CF8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C6EF RID: 50927 RVA: 0x00349B64 File Offset: 0x00347D64
	private void RefreshName()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int playerId = this.Data.PlayerId;
		bool flag = id.GetValueOrDefault() == playerId & id != null;
		UUIText text = base.GetText(1);
		if (this.IsShowInBottom && flag)
		{
			string newText = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true) ?? "";
			text.SetText(newText, true);
			return;
		}
		string playerName = this.Data.PlayerName;
		if (StringUtils.IsBlank(playerName))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "OnlineGymnasium_AnonymityName", Array.Empty<object>());
			return;
		}
		text.SetText(playerName, true);
	}

	// Token: 0x0600C6F0 RID: 50928 RVA: 0x00349C04 File Offset: 0x00347E04
	private void RefreshPosTexture()
	{
		UUITexture texture = base.GetTexture(0);
		string posTexture = DangoAbyssRankItemHelper.GetPosTexture(base.GridIndex);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(posTexture);
		base.SetTextureByPath(resourcePath, texture, null, null);
	}

	// Token: 0x0600C6F1 RID: 50929 RVA: 0x00349C43 File Offset: 0x00347E43
	public override void Refresh(OnlineData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshName();
		this.RefreshPosTexture();
	}

	// Token: 0x04005F48 RID: 24392
	private OnlineData Data;

	// Token: 0x04005F49 RID: 24393
	private readonly bool IsShowInBottom;

	// Token: 0x02007DD0 RID: 32208
	[NullableContext(0)]
	private class EOnlineItem
	{
		// Token: 0x0402ADAC RID: 175532
		public const int PosTexture = 0;

		// Token: 0x0402ADAD RID: 175533
		public const int Name = 1;
	}
}
