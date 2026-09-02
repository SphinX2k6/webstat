using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001642 RID: 5698
public class WheelTowerBossHandBookTitleItem : GridProxyAbstract<int>
{
	// Token: 0x17000D7D RID: 3453
	// (get) Token: 0x0600A03E RID: 41022 RVA: 0x0029E910 File Offset: 0x0029CB10
	// (set) Token: 0x0600A03F RID: 41023 RVA: 0x0029E918 File Offset: 0x0029CB18
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<NewTowerWave?, UUIExtendToggle> OnClickToggleBack { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x0600A040 RID: 41024 RVA: 0x0029E924 File Offset: 0x0029CB24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A041 RID: 41025 RVA: 0x0029E9EC File Offset: 0x0029CBEC
	public override void Refresh(int waveId, bool isSelected, int gridIndex)
	{
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(waveId);
		if (waveConfigById == null)
		{
			return;
		}
		this.WaveConfig = new NewTowerWave?(waveConfigById.Value);
		base.SetTextureByPath(waveConfigById.Value.SmallIconHandBook, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), waveConfigById.Value.Name, Array.Empty<object>());
	}

	// Token: 0x0600A042 RID: 41026 RVA: 0x0029EA6C File Offset: 0x0029CC6C
	public override void OnSelected(bool fireEvent)
	{
		this.OnToggleClick(EToggleState.ETT_Checked);
	}

	// Token: 0x0600A043 RID: 41027 RVA: 0x0029EA78 File Offset: 0x0029CC78
	private void OnToggleClick(EToggleState state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			Action<NewTowerWave?, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.WaveConfig, extendToggle);
		}
	}

	// Token: 0x040049BE RID: 18878
	private NewTowerWave? WaveConfig;
}
