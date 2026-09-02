using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200122F RID: 4655
public class BabelTowerLevelBuffItem : UiPanelBase
{
	// Token: 0x06007BD8 RID: 31704 RVA: 0x00207B88 File Offset: 0x00205D88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007BD9 RID: 31705 RVA: 0x00207D16 File Offset: 0x00205F16
	protected override void OnStart()
	{
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x06007BDA RID: 31706 RVA: 0x00207D25 File Offset: 0x00205F25
	private void OnClickButton()
	{
		Action<int> onClickBtnCallBack = this.OnClickBtnCallBack;
		if (onClickBtnCallBack == null)
		{
			return;
		}
		onClickBtnCallBack(this.BuffId);
	}

	// Token: 0x06007BDB RID: 31707 RVA: 0x00207D40 File Offset: 0x00205F40
	public void RefreshItem(bool isInactive, int buffId)
	{
		this.BuffId = buffId;
		base.GetItem(1).SetUIActive(isInactive || buffId == 0);
		base.GetItem(2).SetUIActive(!isInactive && buffId != 0);
		if (isInactive)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "BabelBuffDisableTips", Array.Empty<object>());
			base.GetButton(0).SetSelfInteractive(false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "BabelBuffSelectTips", Array.Empty<object>());
		if (buffId == 0)
		{
			return;
		}
		BabelTowerBuff babelTowerBuff = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerBuff(buffId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), babelTowerBuff.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), babelTowerBuff.DesText, Array.Empty<object>());
		base.SetTextureByPath(babelTowerBuff.Texture, base.GetTexture(4), null, null);
	}

	// Token: 0x04003B44 RID: 15172
	private int BuffId;

	// Token: 0x04003B45 RID: 15173
	[Nullable(2)]
	public Action<int> OnClickBtnCallBack;

	// Token: 0x02007595 RID: 30101
	private class EComponentDefine
	{
		// Token: 0x0402890C RID: 166156
		public const int EntryButton = 0;

		// Token: 0x0402890D RID: 166157
		public const int NoneItem = 1;

		// Token: 0x0402890E RID: 166158
		public const int NotNoneItem = 2;

		// Token: 0x0402890F RID: 166159
		public const int SelectBuffTipsText = 3;

		// Token: 0x04028910 RID: 166160
		public const int BuffTexture = 4;

		// Token: 0x04028911 RID: 166161
		public const int BuffName = 5;

		// Token: 0x04028912 RID: 166162
		public const int BuffDesc = 6;

		// Token: 0x04028913 RID: 166163
		public const int SwitchButton = 7;

		// Token: 0x04028914 RID: 166164
		public const int LockItem = 8;
	}
}
