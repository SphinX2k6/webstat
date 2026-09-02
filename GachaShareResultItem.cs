using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D08 RID: 7432
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaShareResultItem : GridProxyAbstract<GachaResult>
{
	// Token: 0x0600DA50 RID: 55888 RVA: 0x003AACE0 File Offset: 0x003A8EE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600DA51 RID: 55889 RVA: 0x003AAD3C File Offset: 0x003A8F3C
	protected override UniTask OnBeforeStartAsync()
	{
		GachaShareResultItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaShareResultItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA52 RID: 55890 RVA: 0x003AAD80 File Offset: 0x003A8F80
	public void Refresh(GachaResult data)
	{
		GachaResultItemNew infoItem = this.InfoItem;
		if (infoItem != null)
		{
			infoItem.Update(data);
		}
		GachaResultItemNew infoItem2 = this.InfoItem;
		if (infoItem2 != null)
		{
			infoItem2.RefreshShare();
		}
		if (data.Proto_GachaReward == null)
		{
			return;
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.Proto_GachaReward.ItemId);
		if (itemConfigData == null)
		{
			return;
		}
		int qualityId = itemConfigData.QualityId;
		base.GetItem(1).SetUIActive(qualityId < 4);
		base.GetTexture(2).SetUIActive(qualityId >= 4);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath((qualityId == 5) ? "UiTexture_ShareFrameGold" : "UiTexture_ShareFramePurple");
		if (!string.IsNullOrEmpty(resourcePath))
		{
			base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
		}
	}

	// Token: 0x0600DA53 RID: 55891 RVA: 0x003AAE38 File Offset: 0x003A9038
	public override void Refresh(GachaResult data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x04006842 RID: 26690
	[Nullable(2)]
	private GachaResultItemNew InfoItem;

	// Token: 0x0200807E RID: 32894
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BB57 RID: 179031
		CommonItem,
		// Token: 0x0402BB58 RID: 179032
		CommonFrame,
		// Token: 0x0402BB59 RID: 179033
		TextureFrame
	}
}
