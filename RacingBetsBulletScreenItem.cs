using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002713 RID: 10003
public class RacingBetsBulletScreenItem : UiPanelBase
{
	// Token: 0x06013BAE RID: 80814 RVA: 0x0057D8FC File Offset: 0x0057BAFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISizeControlByOther)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06013BAF RID: 80815 RVA: 0x0057D984 File Offset: 0x0057BB84
	public void RefreshUi(int bulletScreenId, bool isShowFrame)
	{
		this.BulletConfig = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsBulletScreen(bulletScreenId);
		if (this.BulletConfig == null)
		{
			return;
		}
		this.IsShowFrame = isShowFrame;
		UUITexture texture = base.GetTexture(0);
		UUITexture texture2 = base.GetTexture(2);
		UUIText text = base.GetText(1);
		if (this.BulletConfig.Value.Type == 1)
		{
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (texture2 != null)
			{
				base.SetTextureShowUntilLoaded(this.BulletConfig.Value.Icon, texture2, null);
			}
		}
		else if (this.BulletConfig.Value.Type == 2)
		{
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(this.BulletConfig.Value.DangoId);
			if (texture != null)
			{
				base.SetTextureShowUntilLoaded(dangoData.DangoConfig.Value.IconSmall, texture, null);
			}
			if (text != null)
			{
				text.ShowTextNew(this.BulletConfig.Value.Name);
			}
		}
		else
		{
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			if (text != null)
			{
				text.ShowTextNew(this.BulletConfig.Value.Name);
			}
		}
		UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(3);
		if (uiSizeControlByOther == null)
		{
			return;
		}
		UUIItem uuiitem = uiSizeControlByOther.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(isShowFrame);
	}

	// Token: 0x06013BB0 RID: 80816 RVA: 0x0057DB58 File Offset: 0x0057BD58
	public float GetBulletScreenItemWidth()
	{
		float num;
		if (this.BulletConfig.Value.Type == 1)
		{
			UUITexture texture = base.GetTexture(2);
			num = ((texture != null) ? texture.GetWidth() : 0f) + 200f;
		}
		else if (this.BulletConfig.Value.Type == 2)
		{
			UUIText text = base.GetText(1);
			FVector2D? fvector2D = (text != null) ? new FVector2D?(text.GetTextRenderSize()) : null;
			UUITexture texture2 = base.GetTexture(0);
			float num2 = (texture2 != null) ? texture2.GetWidth() : 0f;
			num = ((fvector2D != null) ? fvector2D.GetValueOrDefault().X : 0f) + num2;
		}
		else
		{
			UUIText text2 = base.GetText(1);
			FVector2D? fvector2D2 = (text2 != null) ? new FVector2D?(text2.GetTextRenderSize()) : null;
			num = ((fvector2D2 != null) ? fvector2D2.GetValueOrDefault().X : 0f);
		}
		if (this.IsShowFrame)
		{
			UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(3);
			if (uiSizeControlByOther != null)
			{
				return num + uiSizeControlByOther.AdditionalWidth / 2f;
			}
		}
		return num;
	}

	// Token: 0x06013BB1 RID: 80817 RVA: 0x0057DC7C File Offset: 0x0057BE7C
	public float GetBulletScreenItemHeight()
	{
		UUITexture texture = base.GetTexture(0);
		float num = (texture != null) ? texture.GetHeight() : 0f;
		if (this.BulletConfig.Value.Type == 1)
		{
			UUITexture texture2 = base.GetTexture(2);
			num = ((texture2 != null) ? texture2.GetHeight() : 0f);
		}
		if (this.IsShowFrame)
		{
			UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(3);
			if (uiSizeControlByOther != null)
			{
				return num + uiSizeControlByOther.AdditionalHeight;
			}
		}
		return num;
	}

	// Token: 0x06013BB2 RID: 80818 RVA: 0x0057DCEC File Offset: 0x0057BEEC
	public void MoveLeft(float delta)
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			rootItem.SetAnchorOffsetX(rootItem.GetAnchorOffsetX() - delta);
		}
	}

	// Token: 0x040099AA RID: 39338
	private RacingBetsBulletScreen? BulletConfig;

	// Token: 0x040099AB RID: 39339
	private bool IsShowFrame;

	// Token: 0x040099AC RID: 39340
	[Nullable(1)]
	public List<int> OccupiedTracks = new List<int>();

	// Token: 0x02008AB1 RID: 35505
	private enum EComponent
	{
		// Token: 0x0402EC44 RID: 191556
		BulletIcon,
		// Token: 0x0402EC45 RID: 191557
		BulletText,
		// Token: 0x0402EC46 RID: 191558
		BulletBigIcon,
		// Token: 0x0402EC47 RID: 191559
		FrameItem,
		// Token: 0x0402EC48 RID: 191560
		TextBulletItem
	}
}
