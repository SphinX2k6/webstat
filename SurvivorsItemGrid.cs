using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B06 RID: 11014
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsItemGrid : GridProxyAbstract<SurvivorsItemGainData>
{
	// Token: 0x0601603C RID: 90172 RVA: 0x0061B93C File Offset: 0x00619B3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnExtendToggleStateChanged))
		};
	}

	// Token: 0x0601603D RID: 90173 RVA: 0x0061BA3D File Offset: 0x00619C3D
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(6);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.CanExecuteChange.Bind(() => this.CanExecuteChange == null || this.CanExecuteChange(base.GridIndex));
	}

	// Token: 0x0601603E RID: 90174 RVA: 0x0061BA6D File Offset: 0x00619C6D
	public void SetClickCallback(Action<int, int> callback)
	{
		this.OnClick = callback;
	}

	// Token: 0x0601603F RID: 90175 RVA: 0x0061BA76 File Offset: 0x00619C76
	public void SetCanExecuteChange(Func<int, bool> callback)
	{
		this.CanExecuteChange = callback;
	}

	// Token: 0x06016040 RID: 90176 RVA: 0x0061BA7F File Offset: 0x00619C7F
	public void SetToggleStateForce(bool isSelected, bool bFire = false, bool bJumpToLastFrame = false)
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFire, false, bJumpToLastFrame);
	}

	// Token: 0x06016041 RID: 90177 RVA: 0x0061BA9B File Offset: 0x00619C9B
	private void OnExtendToggleStateChanged(EToggleState state)
	{
		if (this.OnClick != null)
		{
			this.OnClick(base.GridIndex, this.CachedItemId);
		}
	}

	// Token: 0x06016042 RID: 90178 RVA: 0x0061BABC File Offset: 0x00619CBC
	public override void Refresh(SurvivorsItemGainData data, bool isSelected, int gridIndex)
	{
		this.CachedItemId = data.ConfigId;
		SurvivorsItem? survivorsItem = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsItem(this.CachedItemId);
		base.SetTextureByPath(survivorsItem.Value.Icon, base.GetTexture(1), null, null);
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(survivorsItem.Value.Name);
		}
		base.SetQualityIconById(base.GetSprite(0), survivorsItem.Value.Quality, null, null, null);
		this.SetToggleStateForce(isSelected, false, true);
	}

	// Token: 0x06016043 RID: 90179 RVA: 0x0061BB65 File Offset: 0x00619D65
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleStateForce(false, false, false);
	}

	// Token: 0x0400A909 RID: 43273
	private int CachedItemId = -1;

	// Token: 0x0400A90A RID: 43274
	[Nullable(2)]
	private Action<int, int> OnClick;

	// Token: 0x0400A90B RID: 43275
	[Nullable(2)]
	private Func<int, bool> CanExecuteChange;

	// Token: 0x0400A90C RID: 43276
	[Nullable(2)]
	private UUIExtendToggle Toggle;

	// Token: 0x02008E52 RID: 36434
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402FDDB RID: 196059
		public const int QualitySprite = 0;

		// Token: 0x0402FDDC RID: 196060
		public const int ItemTexture = 1;

		// Token: 0x0402FDDD RID: 196061
		public const int BottomText = 2;

		// Token: 0x0402FDDE RID: 196062
		public const int BgSprite = 3;

		// Token: 0x0402FDDF RID: 196063
		public const int TopAdditionItem = 4;

		// Token: 0x0402FDE0 RID: 196064
		public const int BottomAdditionItem = 5;

		// Token: 0x0402FDE1 RID: 196065
		public const int ExtendToggle = 6;

		// Token: 0x0402FDE2 RID: 196066
		public const int UnderTextAdditionItem = 7;

		// Token: 0x0402FDE3 RID: 196067
		public const int SkinQualitySprite = 8;
	}
}
