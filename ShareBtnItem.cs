using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025E9 RID: 9705
public class ShareBtnItem : UiPanelBase
{
	// Token: 0x06013041 RID: 77889 RVA: 0x005447EC File Offset: 0x005429EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickShare))
		};
	}

	// Token: 0x06013042 RID: 77890 RVA: 0x0054487F File Offset: 0x00542A7F
	private void OnClickShare()
	{
		if (this.ClickCallback != null)
		{
			this.ClickCallback();
		}
	}

	// Token: 0x06013043 RID: 77891 RVA: 0x00544894 File Offset: 0x00542A94
	[NullableContext(1)]
	public void SetClickCallBack(Action callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x06013044 RID: 77892 RVA: 0x0054489D File Offset: 0x00542A9D
	public void SetShareActionId(EShareActionId shareId)
	{
		this.ShareActionId = shareId;
		this.SetShareTips();
	}

	// Token: 0x06013045 RID: 77893 RVA: 0x005448AC File Offset: 0x00542AAC
	private void SetShareTips()
	{
		bool flag = ModelBase<ChannelModel>.Instance.CouldGetShareReward(this.ShareActionId);
		base.GetItem(1).SetUIActive(flag);
		if (flag)
		{
			ShareReward? config = ConfigShareRewardById.GetConfig((int)this.ShareActionId, true);
			base.GetText(3).SetText(config.Value.GetReward(1).ToString(), true);
			base.GetTexture(2).SetUIActive(true);
			string icon = ConfigBase<ItemConfig>.Instance.GetConfig(config.Value.GetReward(0).Value).Value.Icon;
			base.SetTextureByPath(icon, base.GetTexture(2), null, null);
		}
	}

	// Token: 0x0400944A RID: 37962
	private EShareActionId ShareActionId = EShareActionId.Photo;

	// Token: 0x0400944B RID: 37963
	[Nullable(2)]
	private Action ClickCallback;

	// Token: 0x0200897B RID: 35195
	private enum EChildType
	{
		// Token: 0x0402E63D RID: 190013
		ShareBtn,
		// Token: 0x0402E63E RID: 190014
		ShareTips,
		// Token: 0x0402E63F RID: 190015
		Icon,
		// Token: 0x0402E640 RID: 190016
		TxtCost
	}
}
