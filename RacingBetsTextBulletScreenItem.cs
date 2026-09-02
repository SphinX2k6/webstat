using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200272C RID: 10028
public class RacingBetsTextBulletScreenItem : GridProxyAbstract<RacingBetsBulletScreen>
{
	// Token: 0x06013C71 RID: 81009 RVA: 0x00580914 File Offset: 0x0057EB14
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBulletScreenButton))
		};
	}

	// Token: 0x06013C72 RID: 81010 RVA: 0x005809A8 File Offset: 0x0057EBA8
	public override void Refresh(RacingBetsBulletScreen data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(data.Name);
		}
		if (data.Type == 2)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(data.DangoId);
			base.SetTextureShowUntilLoaded(dangoData.DangoConfig.Value.IconSmall, base.GetTexture(1), null);
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
			return;
		}
		else
		{
			UUITexture texture2 = base.GetTexture(1);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(true);
			return;
		}
	}

	// Token: 0x06013C73 RID: 81011 RVA: 0x00580A5D File Offset: 0x0057EC5D
	[NullableContext(1)]
	public void BindClickBulletScreenCallBack(Action<RacingBetsBulletScreen> callBack)
	{
		this.ClickBulletScreenCallBack = callBack;
	}

	// Token: 0x06013C74 RID: 81012 RVA: 0x00580A66 File Offset: 0x0057EC66
	private void OnClickBulletScreenButton()
	{
		Action<RacingBetsBulletScreen> clickBulletScreenCallBack = this.ClickBulletScreenCallBack;
		if (clickBulletScreenCallBack == null)
		{
			return;
		}
		clickBulletScreenCallBack(this.Data);
	}

	// Token: 0x040099F8 RID: 39416
	private RacingBetsBulletScreen Data;

	// Token: 0x040099F9 RID: 39417
	[Nullable(2)]
	private Action<RacingBetsBulletScreen> ClickBulletScreenCallBack;

	// Token: 0x02008AD3 RID: 35539
	private enum EComponent
	{
		// Token: 0x0402ECD9 RID: 191705
		Button,
		// Token: 0x0402ECDA RID: 191706
		Icon,
		// Token: 0x0402ECDB RID: 191707
		Text,
		// Token: 0x0402ECDC RID: 191708
		NormalIcon
	}
}
