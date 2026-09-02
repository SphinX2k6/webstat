using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020011AC RID: 4524
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ArtemisDaysItem : GridProxyAbstract<IArtemisDayItemData>
{
	// Token: 0x06007712 RID: 30482 RVA: 0x001F2A1C File Offset: 0x001F0C1C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIArtText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIArtText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
		};
	}

	// Token: 0x06007713 RID: 30483 RVA: 0x001F2ADC File Offset: 0x001F0CDC
	public override void Refresh(IArtemisDayItemData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		this.Day = data.Index;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Index + 1);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIArtText artText = base.GetArtText(3);
		if (artText != null)
		{
			artText.SetText(text);
		}
		UUIArtText artText2 = base.GetArtText(5);
		if (artText2 != null)
		{
			artText2.SetText(text);
		}
		this.UpdateState(data.State);
	}

	// Token: 0x06007714 RID: 30484 RVA: 0x001F2B57 File Offset: 0x001F0D57
	public void SetClickCallback(Action<int> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x06007715 RID: 30485 RVA: 0x001F2B60 File Offset: 0x001F0D60
	public void UpdateState(EArtemisState? state)
	{
		EArtemisState? eartemisState = state;
		EArtemisState eartemisState2 = EArtemisState.Lock;
		this.LockState = (eartemisState.GetValueOrDefault() == eartemisState2 & eartemisState != null);
		bool flag = !this.LockState && this.Day == ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex;
		base.GetExtendToggle(0).bLockStateOnSelect = !this.LockState;
		base.GetItem(4).SetUIActive(this.LockState);
		this.SetDayCountColor(flag, state.GetValueOrDefault());
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		this.LoadMaterial(state.GetValueOrDefault() == EArtemisState.Unlock);
	}

	// Token: 0x06007716 RID: 30486 RVA: 0x001F2C0C File Offset: 0x001F0E0C
	private void SetDayCountColor(bool isSelected, EArtemisState state)
	{
		bool flag = state == EArtemisState.Rewarded;
		bool flag2 = isSelected && state == EArtemisState.Unlock;
		UUIArtText artText = base.GetArtText(3);
		if (artText != null)
		{
			artText.SetUIActive(!flag2);
		}
		UUIArtText artText2 = base.GetArtText(5);
		if (artText2 != null)
		{
			artText2.SetUIActive(flag2);
		}
		base.GetTexture(2).SetUIActive(flag);
		FColor color = this.UnlockColor;
		if (isSelected)
		{
			color = this.ChoseColor;
		}
		else if (flag)
		{
			color = this.RewardColor;
		}
		else if (state == EArtemisState.Lock)
		{
			color = this.LockColor;
		}
		base.GetArtText(3).SetColor(color);
		base.GetArtText(5).SetColor(color);
		if (flag)
		{
			base.GetTexture(2).SetColor(color);
		}
	}

	// Token: 0x06007717 RID: 30487 RVA: 0x001F2CB2 File Offset: 0x001F0EB2
	private void OnClicked(EToggleState toggleState)
	{
		if (this.LockState)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.ClickCallback(this.Day);
	}

	// Token: 0x06007718 RID: 30488 RVA: 0x001F2CE4 File Offset: 0x001F0EE4
	public void LoadMaterial(bool loadMaterial)
	{
		if (loadMaterial)
		{
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string text = (instance != null) ? instance.GetResourcePath("MI_GlitchAimis") : null;
			if (text == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(text, delegate([Nullable(2)] UMaterialInterface material, string _)
			{
				UUIArtText artText3 = base.GetArtText(3);
				if (artText3 != null)
				{
					artText3.SetCustomUIMaterial(material);
				}
				UUIArtText artText4 = base.GetArtText(5);
				if (artText4 == null)
				{
					return;
				}
				artText4.SetCustomUIMaterial(material);
			}, ResourceSystem.EResourceLoadPriority.Ui, this.MemoryTag);
			return;
		}
		else
		{
			UUIArtText artText = base.GetArtText(3);
			if (artText != null)
			{
				artText.SetCustomUIMaterial(null);
			}
			UUIArtText artText2 = base.GetArtText(5);
			if (artText2 == null)
			{
				return;
			}
			artText2.SetCustomUIMaterial(null);
			return;
		}
	}

	// Token: 0x04003984 RID: 14724
	private int Day;

	// Token: 0x04003985 RID: 14725
	private bool LockState;

	// Token: 0x04003986 RID: 14726
	private Action<int> ClickCallback = delegate(int _)
	{
	};

	// Token: 0x04003987 RID: 14727
	private readonly FColor RewardColor = FColor.FromHex("838383");

	// Token: 0x04003988 RID: 14728
	private readonly FColor UnlockColor = FColor.FromHex("FFFFFF");

	// Token: 0x04003989 RID: 14729
	private readonly FColor ChoseColor = FColor.FromHex("212224");

	// Token: 0x0400398A RID: 14730
	private readonly FColor LockColor = FColor.FromHex("838383");

	// Token: 0x02007504 RID: 29956
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028667 RID: 165479
		public const int ToggleNode = 0;

		// Token: 0x04028668 RID: 165480
		public const int MainContentNode = 1;

		// Token: 0x04028669 RID: 165481
		public const int Completion = 2;

		// Token: 0x0402866A RID: 165482
		public const int DayCountText = 3;

		// Token: 0x0402866B RID: 165483
		public const int LockedState = 4;

		// Token: 0x0402866C RID: 165484
		public const int DayCountTextBlack = 5;
	}
}
