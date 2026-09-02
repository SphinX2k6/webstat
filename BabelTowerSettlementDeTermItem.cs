using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001242 RID: 4674
public class BabelTowerSettlementDeTermItem : GridProxyAbstract<int>
{
	// Token: 0x06007C8A RID: 31882 RVA: 0x0020C430 File Offset: 0x0020A630
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

	// Token: 0x06007C8B RID: 31883 RVA: 0x0020C4D8 File Offset: 0x0020A6D8
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.DeTermId = data;
		base.SetTextureByPath(ConfigBabelTowerDeTermById.GetConfig(data, true).Value.Texture, base.GetTexture(0), null, null);
	}

	// Token: 0x06007C8C RID: 31884 RVA: 0x0020C51C File Offset: 0x0020A71C
	private void OnClickBtn()
	{
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = true,
			ConfigId = this.DeTermId,
			ShowWays = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x04003B96 RID: 15254
	private int DeTermId;

	// Token: 0x020075B3 RID: 30131
	private class EComponents
	{
		// Token: 0x040289AF RID: 166319
		public const int IconTexture = 0;

		// Token: 0x040289B0 RID: 166320
		public const int BgSprite = 1;

		// Token: 0x040289B1 RID: 166321
		public const int NameText = 2;

		// Token: 0x040289B2 RID: 166322
		public const int Btn = 3;
	}
}
