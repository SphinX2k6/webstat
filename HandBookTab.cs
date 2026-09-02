using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001EB3 RID: 7859
internal class HandBookTab : GridProxyAbstract<int>
{
	// Token: 0x0600E875 RID: 59509 RVA: 0x003EDBD8 File Offset: 0x003EBDD8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x0600E876 RID: 59510 RVA: 0x003EDC58 File Offset: 0x003EBE58
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		if (data == 0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("WeaponHandBookTabSprite");
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, delegate(bool _)
			{
				(base.GetSprite(0).GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition).SetAllStateSprite(base.GetSprite(0).GetSprite());
			});
		}
		if (data == 1)
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("WeaponSkinHandBookTabSprite");
			this.SetSpriteByPath(resourcePath2, base.GetSprite(0), false, null, delegate(bool _)
			{
				(base.GetSprite(0).GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition).SetAllStateSprite(base.GetSprite(0).GetSprite());
			});
		}
		this.CurrentType = data;
	}

	// Token: 0x0600E877 RID: 59511 RVA: 0x003EDCDB File Offset: 0x003EBEDB
	private void OnToggleClick(EToggleState toggleState)
	{
		Action<UUIExtendToggle, int> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack(base.GetExtendToggle(1), this.CurrentType);
	}

	// Token: 0x0600E878 RID: 59512 RVA: 0x003EDCFA File Offset: 0x003EBEFA
	public void SelectToggle()
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x04007001 RID: 28673
	private int CurrentType;

	// Token: 0x04007002 RID: 28674
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickCallBack;

	// Token: 0x020081F8 RID: 33272
	private class EHandBookTabDefine
	{
		// Token: 0x0402C176 RID: 180598
		public const int Sprite = 0;

		// Token: 0x0402C177 RID: 180599
		public const int Toggle = 1;

		// Token: 0x0402C178 RID: 180600
		public const int RedDotItem = 2;
	}
}
