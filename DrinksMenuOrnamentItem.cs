using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200101D RID: 4125
public class DrinksMenuOrnamentItem : GridProxyAbstract<int>
{
	// Token: 0x06006B4B RID: 27467 RVA: 0x001C11C0 File Offset: 0x001BF3C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06006B4C RID: 27468 RVA: 0x001C121A File Offset: 0x001BF41A
	protected override void OnStart()
	{
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x06006B4D RID: 27469 RVA: 0x001C1239 File Offset: 0x001BF439
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOnCb != null && this.Id != 0)
		{
			this.SetSelected(this.IsSelectOnCb(this.Id), false);
		}
	}

	// Token: 0x06006B4E RID: 27470 RVA: 0x001C1264 File Offset: 0x001BF464
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.Id = data;
		DrinksOrnament? ornament = ConfigBase<DrinksConfig>.Instance.GetOrnament(data);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), ornament.Value.Name, Array.Empty<object>());
		base.SetTextureByPath(ornament.Value.Icon, base.GetTexture(1), null, null);
		if (this.IsSelectOnCb != null)
		{
			this.SetSelected(this.IsSelectOnCb(data), false);
		}
	}

	// Token: 0x06006B4F RID: 27471 RVA: 0x001C12EA File Offset: 0x001BF4EA
	private void SetSelected(bool bSelectOn, bool bFireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06006B50 RID: 27472 RVA: 0x001C1303 File Offset: 0x001BF503
	private void OnToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.OnToggleStateChangeFunction != null)
		{
			this.OnToggleStateChangeFunction(this.Id);
		}
	}

	// Token: 0x040032FB RID: 13051
	protected int Id;

	// Token: 0x040032FC RID: 13052
	[Nullable(2)]
	public Func<int, bool> IsSelectOnCb;

	// Token: 0x040032FD RID: 13053
	[Nullable(2)]
	public Action<int> OnToggleStateChangeFunction;

	// Token: 0x020073FF RID: 29695
	private static class EDefine
	{
		// Token: 0x040281EC RID: 164332
		public const int Toggle = 0;

		// Token: 0x040281ED RID: 164333
		public const int Icon = 1;

		// Token: 0x040281EE RID: 164334
		public const int Name = 2;
	}
}
