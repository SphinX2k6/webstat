using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001D2D RID: 7469
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CollectionGridItemPanel : LoopScrollSmallItemGrid<MotorcycleArrowCollectionItemData>
{
	// Token: 0x0600DBF4 RID: 56308 RVA: 0x003B20AC File Offset: 0x003B02AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600DBF5 RID: 56309 RVA: 0x003B2181 File Offset: 0x003B0381
	protected override void OnRefresh(MotorcycleArrowCollectionItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0600DBF6 RID: 56310 RVA: 0x003B218C File Offset: 0x003B038C
	public void Refresh(MotorcycleArrowCollectionItemData data)
	{
		this.Data = data;
		MotorFightItem config = data.Config;
		this.SetSpriteByPath(ConfigMotorFightQualityById.GetConfig(config.Quality, true).Value.SmallGridBg, base.GetSprite(0), false, null, null);
		base.SetTextureByPath(config.Icon, base.GetTexture(1), null, null);
		base.GetText(3).SetText("x" + data.Num.ToString(), true);
		base.SetLeftTopIconVisible(ConfigMotorFightItemTypeById.GetConfig(config.Type, true).Value.Icon);
	}

	// Token: 0x0600DBF7 RID: 56311 RVA: 0x003B2242 File Offset: 0x003B0442
	private void OnClickToggle(EToggleState toggleState)
	{
		this.OnClickCallBack(this.Data as MotorcycleArrowCollectionItemData);
		if (!this.NeedSelectedState)
		{
			this.SetToggleState(false);
		}
	}

	// Token: 0x0600DBF8 RID: 56312 RVA: 0x003B226C File Offset: 0x003B046C
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(7).SetToggleState(state2, false, false, false);
	}

	// Token: 0x04006935 RID: 26933
	public bool NeedSelectedState = true;

	// Token: 0x04006936 RID: 26934
	public Action<MotorcycleArrowCollectionItemData> OnClickCallBack = delegate(MotorcycleArrowCollectionItemData _)
	{
	};

	// Token: 0x020080BB RID: 32955
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402BC7C RID: 179324
		public const int SpriteQuality = 0;

		// Token: 0x0402BC7D RID: 179325
		public const int TextureIcon = 1;

		// Token: 0x0402BC7E RID: 179326
		public const int ItemText = 2;

		// Token: 0x0402BC7F RID: 179327
		public const int TextName = 3;

		// Token: 0x0402BC80 RID: 179328
		public const int SpriteBg = 4;

		// Token: 0x0402BC81 RID: 179329
		public const int ItemAddPanel = 5;

		// Token: 0x0402BC82 RID: 179330
		public const int ItemBottomAddPanel = 6;

		// Token: 0x0402BC83 RID: 179331
		public const int ToggleRoot = 7;

		// Token: 0x0402BC84 RID: 179332
		public const int SpriteSkinQuality = 8;

		// Token: 0x0402BC85 RID: 179333
		public const int ItemAdditionBottomA = 9;
	}
}
