using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022D8 RID: 8920
public class MotorcycleDiySkinTogItem : UiPanelBase
{
	// Token: 0x06010E06 RID: 69126 RVA: 0x0049F6D8 File Offset: 0x0049D8D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010E07 RID: 69127 RVA: 0x0049F781 File Offset: 0x0049D981
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(() => this.CanExecuteChange == null || this.CanExecuteChange(this.SkinId));
	}

	// Token: 0x06010E08 RID: 69128 RVA: 0x0049F7A0 File Offset: 0x0049D9A0
	public void Refresh(int skinId)
	{
		this.SkinId = skinId;
		MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(skinId);
		if (motorSkinConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorSkinConfig.Value.SkinIcon, base.GetTexture(1), null, null);
	}

	// Token: 0x06010E09 RID: 69129 RVA: 0x0049F7F0 File Offset: 0x0049D9F0
	public void SetEquippedStatus(bool isEquipped)
	{
		base.GetTexture(2).SetUIActive(isEquipped);
	}

	// Token: 0x06010E0A RID: 69130 RVA: 0x0049F7FF File Offset: 0x0049D9FF
	public void SetRedDotVisible(bool isVisible)
	{
		base.GetItem(4).SetUIActive(isVisible);
	}

	// Token: 0x06010E0B RID: 69131 RVA: 0x0049F80E File Offset: 0x0049DA0E
	public void SetLockedStatus(bool isLock)
	{
		base.GetItem(3).SetUIActive(isLock);
	}

	// Token: 0x06010E0C RID: 69132 RVA: 0x0049F81D File Offset: 0x0049DA1D
	public void SetToggleStateForce(EToggleState state, bool isFireEvent = true)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, isFireEvent, false, false);
	}

	// Token: 0x06010E0D RID: 69133 RVA: 0x0049F82F File Offset: 0x0049DA2F
	public int GetSkinId()
	{
		return this.SkinId;
	}

	// Token: 0x06010E0E RID: 69134 RVA: 0x0049F837 File Offset: 0x0049DA37
	public EToggleState GetToggleState()
	{
		return base.GetExtendToggle(0).ToggleState;
	}

	// Token: 0x06010E0F RID: 69135 RVA: 0x0049F845 File Offset: 0x0049DA45
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<int> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.SkinId);
	}

	// Token: 0x040084F7 RID: 34039
	private int SkinId;

	// Token: 0x040084F8 RID: 34040
	[Nullable(2)]
	public Func<int, bool> CanExecuteChange;

	// Token: 0x040084F9 RID: 34041
	[Nullable(2)]
	public Action<int> OnClickToggleBack;

	// Token: 0x020085B4 RID: 34228
	private class EMotorDiySkinTogItemComponent
	{
		// Token: 0x0402D3BF RID: 185279
		public const int TogSkin = 0;

		// Token: 0x0402D3C0 RID: 185280
		public const int TexIcon = 1;

		// Token: 0x0402D3C1 RID: 185281
		public const int TexDone = 2;

		// Token: 0x0402D3C2 RID: 185282
		public const int LockItem = 3;

		// Token: 0x0402D3C3 RID: 185283
		public const int RedDotItem = 4;
	}
}
