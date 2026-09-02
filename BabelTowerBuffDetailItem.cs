using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011D7 RID: 4567
public class BabelTowerBuffDetailItem : UiPanelBase
{
	// Token: 0x0600788F RID: 30863 RVA: 0x001F9464 File Offset: 0x001F7664
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007890 RID: 30864 RVA: 0x001F9530 File Offset: 0x001F7730
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerBuffDetailItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerBuffDetailItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007891 RID: 30865 RVA: 0x001F9573 File Offset: 0x001F7773
	[NullableContext(1)]
	public void Update(IBabelTowerBuffItemData data)
	{
		this.Data = data;
		this.Refresh();
	}

	// Token: 0x06007892 RID: 30866 RVA: 0x001F9584 File Offset: 0x001F7784
	public void Refresh()
	{
		if (this.Data == null)
		{
			return;
		}
		string nameText;
		string texture;
		string desText;
		int star;
		if (this.Data.IsDeTerm)
		{
			BabelTowerDeTerm value = ConfigBabelTowerDeTermById.GetConfig(this.Data.Id, true).Value;
			nameText = value.NameText;
			texture = value.Texture;
			desText = value.DesText;
			star = value.Star;
		}
		else
		{
			BabelTowerBuff value2 = ConfigBabelTowerBuffById.GetConfig(this.Data.Id, true).Value;
			nameText = value2.NameText;
			texture = value2.Texture;
			desText = value2.DesText;
			star = value2.Star;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), nameText, Array.Empty<object>());
		this.StarAndDescItem.Refresh(star.ToString(), this.Data.ShowStar.GetValueOrDefault(), desText);
		base.SetTextureByPath(texture, base.GetTexture(2), null, null);
		int num = ModelBase<BabelTowerModel>.Instance.CoverStarNumToQualityId(star);
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
		defaultInterpolatedStringHandler.AppendLiteral("T_TipsQualityTypeLevel");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
		FColor color = FColor.FromHex(ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(num).Value.QualityColor);
		UUINiagara uiNiagara = base.GetUiNiagara(3);
		uiNiagara.SetColor(color);
		uiNiagara.ActivateSystem(true);
	}

	// Token: 0x04003A34 RID: 14900
	[Nullable(2)]
	private BabelTowerBuffStarAndDescItem StarAndDescItem;

	// Token: 0x04003A35 RID: 14901
	[Nullable(2)]
	private IBabelTowerBuffItemData Data;

	// Token: 0x02007531 RID: 30001
	private class EComponents
	{
		// Token: 0x0402873C RID: 165692
		public const int NameText = 0;

		// Token: 0x0402873D RID: 165693
		public const int QualityBgTexture = 1;

		// Token: 0x0402873E RID: 165694
		public const int ItemIconTexture = 2;

		// Token: 0x0402873F RID: 165695
		public const int QualityNiagara = 3;

		// Token: 0x04028740 RID: 165696
		public const int ContentItem = 4;
	}
}
