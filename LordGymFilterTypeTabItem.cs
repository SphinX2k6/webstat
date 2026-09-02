using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020021F6 RID: 8694
[NullableContext(1)]
[Nullable(0)]
public class LordGymFilterTypeTabItem : GridProxyAbstract<LordGymFilterType>
{
	// Token: 0x06010658 RID: 67160 RVA: 0x0047AFD3 File Offset: 0x004791D3
	public LordGymFilterTypeTabItem(Action<int> onSelect)
	{
		this.OnSelect = onSelect;
	}

	// Token: 0x06010659 RID: 67161 RVA: 0x0047AFE4 File Offset: 0x004791E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x0601065A RID: 67162 RVA: 0x0047B077 File Offset: 0x00479277
	public override void Refresh(LordGymFilterType data, bool isSelected, int gridIndex)
	{
		this.FilterTypeId = data.Id;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
	}

	// Token: 0x0601065B RID: 67163 RVA: 0x0047B0A3 File Offset: 0x004792A3
	public int GetFilterTypeId()
	{
		return this.FilterTypeId;
	}

	// Token: 0x0601065C RID: 67164 RVA: 0x0047B0AB File Offset: 0x004792AB
	public void SetToggleActive(bool selected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0601065D RID: 67165 RVA: 0x0047B0C9 File Offset: 0x004792C9
	public override object GetKey(LordGymFilterType data, int gridIndex)
	{
		return data.Id;
	}

	// Token: 0x0601065E RID: 67166 RVA: 0x0047B0D7 File Offset: 0x004792D7
	private void OnToggleClick(EToggleState toggleState)
	{
		this.OnSelect(this.FilterTypeId);
	}

	// Token: 0x0400814C RID: 33100
	private int FilterTypeId;

	// Token: 0x0400814D RID: 33101
	private readonly Action<int> OnSelect;

	// Token: 0x020084B9 RID: 33977
	[NullableContext(0)]
	private class ETabComponents
	{
		// Token: 0x0402CF75 RID: 184181
		public const int Toggle = 0;

		// Token: 0x0402CF76 RID: 184182
		public const int SprIcon = 1;

		// Token: 0x0402CF77 RID: 184183
		public const int TxtTitle = 2;

		// Token: 0x0402CF78 RID: 184184
		public const int SprIconR = 3;
	}
}
