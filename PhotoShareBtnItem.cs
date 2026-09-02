using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020025E8 RID: 9704
public class PhotoShareBtnItem : GridProxyAbstract<EChannelShare>
{
	// Token: 0x06013037 RID: 77879 RVA: 0x00544608 File Offset: 0x00542808
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickShare))
		};
	}

	// Token: 0x06013038 RID: 77880 RVA: 0x00544670 File Offset: 0x00542870
	protected override void OnStart()
	{
		this.ShareGap = ConfigBase<CommonConfig>.Instance.GetShareGap().GetValueOrDefault(1);
		this.Transition = (base.GetSprite(0).GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition);
	}

	// Token: 0x06013039 RID: 77881 RVA: 0x005446BC File Offset: 0x005428BC
	private void OnClickShare()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (serverTime - this.LastClickTime < (double)this.ShareGap)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotShare", Array.Empty<object>());
			return;
		}
		this.LastClickTime = serverTime;
		int channelShareId = this.ChannelShareId;
		SharePlatform? config = ConfigSharePlatformById.GetConfig(channelShareId, true);
		if (config == null)
		{
			return;
		}
		int shareId = config.Value.ShareId;
		Action<EChannelShare, int> clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback((EChannelShare)shareId, channelShareId);
	}

	// Token: 0x0601303A RID: 77882 RVA: 0x0054473D File Offset: 0x0054293D
	[NullableContext(1)]
	public void SetClickCallBack(Action<EChannelShare, int> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0601303B RID: 77883 RVA: 0x00544746 File Offset: 0x00542946
	public override void Refresh(EChannelShare data, bool isSelected, int gridIndex)
	{
		this.Update((int)data);
		this.RefreshPanel();
	}

	// Token: 0x0601303C RID: 77884 RVA: 0x00544755 File Offset: 0x00542955
	public void Update(int channelShareId)
	{
		this.ChannelShareId = channelShareId;
	}

	// Token: 0x0601303D RID: 77885 RVA: 0x00544760 File Offset: 0x00542960
	public void RefreshPanel()
	{
		SharePlatform? config = ConfigSharePlatformById.GetConfig(this.ChannelShareId, true);
		if (config == null)
		{
			return;
		}
		this.SetSpriteByPath(config.Value.Icon, base.GetSprite(0), false, null, delegate(bool result)
		{
			UUISpriteTransition transition = this.Transition;
			if (transition == null)
			{
				return;
			}
			transition.SetAllTransitionSprite(base.GetSprite(0).GetSprite());
		});
	}

	// Token: 0x0601303E RID: 77886 RVA: 0x005447B6 File Offset: 0x005429B6
	protected override void OnBeforeDestroy()
	{
		this.Transition = null;
	}

	// Token: 0x04009445 RID: 37957
	private int ChannelShareId;

	// Token: 0x04009446 RID: 37958
	[Nullable(2)]
	private UUISpriteTransition Transition;

	// Token: 0x04009447 RID: 37959
	private double LastClickTime;

	// Token: 0x04009448 RID: 37960
	[Nullable(2)]
	private Action<EChannelShare, int> ClickCallback;

	// Token: 0x04009449 RID: 37961
	private int ShareGap = 1;

	// Token: 0x0200897A RID: 35194
	private enum EChildType
	{
		// Token: 0x0402E63A RID: 190010
		Icon,
		// Token: 0x0402E63B RID: 190011
		Button
	}
}
