using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001303 RID: 4867
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoMonopolyRoundRewardItem : GridProxyAbstract<IDangoMonopolyRoundRewardItemData>
{
	// Token: 0x0600845A RID: 33882 RVA: 0x0022EE30 File Offset: 0x0022D030
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyRoundRewardItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyRoundRewardItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600845B RID: 33883 RVA: 0x0022EE74 File Offset: 0x0022D074
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
	}

	// Token: 0x0600845C RID: 33884 RVA: 0x0022EEE4 File Offset: 0x0022D0E4
	public override void Refresh(IDangoMonopolyRoundRewardItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		bool isReceived = this.ItemData.IsReceived;
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		UUISprite sprite2 = base.GetSprite(3);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(isReceived);
		}
		UUIText text = base.GetText(2);
		text.SetText(this.ItemData.Position.ToString(), true);
		UUIItem uuiitem = text;
		bool bUseChangeColor = isReceived;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = this.ItemData,
			ItemConfigId = new int?(this.ItemData.ItemId),
			IsRedDotVisible = new bool?(this.ItemData.IsCanReceived),
			IsReceivedVisible = new bool?(this.ItemData.IsReceived),
			IsReceivableVisible = new bool?(this.ItemData.IsCanReceived),
			BottomText = this.GetCountStr()
		};
		this.RewardItem.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600845D RID: 33885 RVA: 0x0022EFE4 File Offset: 0x0022D1E4
	public string GetCountStr()
	{
		if (this.ItemData.Count > 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("x ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ItemData.Count);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return "";
	}

	// Token: 0x0600845E RID: 33886 RVA: 0x0022F033 File Offset: 0x0022D233
	private void OnClickReward(MediumItemGridExtendCallback _)
	{
		Action<IDangoMonopolyRoundRewardItemData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x04003ECD RID: 16077
	private IDangoMonopolyRoundRewardItemData ItemData;

	// Token: 0x04003ECE RID: 16078
	public SmallItemGrid RewardItem;

	// Token: 0x04003ECF RID: 16079
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IDangoMonopolyRoundRewardItemData> ClickCallBack;

	// Token: 0x020076AA RID: 30378
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E1F RID: 167455
		SpriteCurrent,
		// Token: 0x04028E20 RID: 167456
		ItemReward,
		// Token: 0x04028E21 RID: 167457
		TxtCount,
		// Token: 0x04028E22 RID: 167458
		SpriteFinish
	}
}
