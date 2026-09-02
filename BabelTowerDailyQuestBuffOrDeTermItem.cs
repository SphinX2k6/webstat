using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011E0 RID: 4576
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerDailyQuestBuffOrDeTermItem : GridProxyAbstract<IBabelTowerDailyQuestItem>
{
	// Token: 0x060078FD RID: 30973 RVA: 0x001FB910 File Offset: 0x001F9B10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060078FE RID: 30974 RVA: 0x001FB9B8 File Offset: 0x001F9BB8
	[NullableContext(1)]
	public override void Refresh(IBabelTowerDailyQuestItem data, bool isSelected, int gridIndex)
	{
		this.ConfigId = data.ConfigId;
		this.IsDeTerm = data.IsDeTerm;
		if (data.IsDeTerm)
		{
			base.SetTextureByPath(ConfigBabelTowerDeTermById.GetConfig(this.ConfigId, true).Value.Texture, base.GetTexture(0), null, null);
			return;
		}
		base.SetTextureByPath(ConfigBabelTowerBuffById.GetConfig(this.ConfigId, true).Value.Texture, base.GetTexture(0), null, null);
	}

	// Token: 0x060078FF RID: 30975 RVA: 0x001FBA50 File Offset: 0x001F9C50
	private void OnClickBtn()
	{
		bool showWays;
		if (this.IsDeTerm)
		{
			showWays = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetDeTermIsLock(this.ConfigId);
		}
		else
		{
			showWays = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetBuffIsLock(this.ConfigId);
		}
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = this.IsDeTerm,
			ConfigId = this.ConfigId,
			ShowWays = showWays
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x04003A44 RID: 14916
	private int ConfigId;

	// Token: 0x04003A45 RID: 14917
	private bool IsDeTerm;

	// Token: 0x0200754C RID: 30028
	private class EComponentDefine
	{
		// Token: 0x040287B0 RID: 165808
		public const int Texture = 0;

		// Token: 0x040287B1 RID: 165809
		public const int Btn = 3;
	}
}
