using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002721 RID: 10017
public class RacingBetsIconBulletScreenItem : GridProxyAbstract<RacingBetsBulletScreen>
{
	// Token: 0x06013C21 RID: 80929 RVA: 0x0057F8E8 File Offset: 0x0057DAE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBulletScreenButton))
		};
	}

	// Token: 0x06013C22 RID: 80930 RVA: 0x0057F94F File Offset: 0x0057DB4F
	public override void Refresh(RacingBetsBulletScreen data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.SetTextureShowUntilLoaded(data.Icon, base.GetTexture(1), null);
	}

	// Token: 0x06013C23 RID: 80931 RVA: 0x0057F96D File Offset: 0x0057DB6D
	[NullableContext(1)]
	public void BindClickBulletScreenCallBack(Action<RacingBetsBulletScreen> callBack)
	{
		this.ClickBulletScreenCallBack = callBack;
	}

	// Token: 0x06013C24 RID: 80932 RVA: 0x0057F976 File Offset: 0x0057DB76
	private void OnClickBulletScreenButton()
	{
		Action<RacingBetsBulletScreen> clickBulletScreenCallBack = this.ClickBulletScreenCallBack;
		if (clickBulletScreenCallBack == null)
		{
			return;
		}
		clickBulletScreenCallBack(this.Data);
	}

	// Token: 0x040099E2 RID: 39394
	private RacingBetsBulletScreen Data;

	// Token: 0x040099E3 RID: 39395
	[Nullable(2)]
	private Action<RacingBetsBulletScreen> ClickBulletScreenCallBack;

	// Token: 0x02008AC8 RID: 35528
	private enum EComponent
	{
		// Token: 0x0402ECA6 RID: 191654
		Button,
		// Token: 0x0402ECA7 RID: 191655
		Icon
	}
}
