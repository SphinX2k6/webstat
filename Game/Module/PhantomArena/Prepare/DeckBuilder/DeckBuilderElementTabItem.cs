using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005501 RID: 21761
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderElementTabItem : GridProxyAbstract<ICardTabItemData>
	{
		// Token: 0x06037796 RID: 227222 RVA: 0x00E111F8 File Offset: 0x00E0F3F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectInternal))
			};
		}

		// Token: 0x06037797 RID: 227223 RVA: 0x00E112CD File Offset: 0x00E0F4CD
		private void OnToggleSelectInternal(EToggleState toggleState)
		{
			Action<int> onToggleSelect = this.OnToggleSelect;
			if (onToggleSelect == null)
			{
				return;
			}
			onToggleSelect(base.GridIndex);
		}

		// Token: 0x06037798 RID: 227224 RVA: 0x00E112E8 File Offset: 0x00E0F4E8
		[NullableContext(1)]
		public override void Refresh(ICardTabItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.SetTextureShowUntilLoaded(data.TabTexturePath, base.GetTexture(1), null);
			FColor color = FColor.FromHex(data.TabElementColor);
			base.GetSprite(2).SetColor(color);
			base.GetSprite(3).SetColor(color);
			if (isSelected)
			{
				this.OnSelected(false);
			}
			else
			{
				this.OnDeselected(false);
			}
			this.RefreshRedDotState();
			this.RefreshDisableState();
			this.RefreshMaxState();
		}

		// Token: 0x06037799 RID: 227225 RVA: 0x00E1135B File Offset: 0x00E0F55B
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x0603779A RID: 227226 RVA: 0x00E11373 File Offset: 0x00E0F573
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0603779B RID: 227227 RVA: 0x00E1138B File Offset: 0x00E0F58B
		public void RefreshRedDotState()
		{
			base.GetItem(4).SetUIActive(this.Data.ShowRedDot);
		}

		// Token: 0x0603779C RID: 227228 RVA: 0x00E113A4 File Offset: 0x00E0F5A4
		public void RefreshDisableState()
		{
			base.GetItem(5).SetUIActive(this.Data.IsDisable);
		}

		// Token: 0x0603779D RID: 227229 RVA: 0x00E113BD File Offset: 0x00E0F5BD
		public void RefreshMaxState()
		{
			base.GetItem(6).SetUIActive(this.Data.IsArrivedMax);
		}

		// Token: 0x0401FD51 RID: 130385
		protected ICardTabItemData Data;

		// Token: 0x0401FD52 RID: 130386
		public Action<int> OnToggleSelect;

		// Token: 0x0200B478 RID: 46200
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DDE RID: 228830
			public const int ItemToggle = 0;

			// Token: 0x04037DDF RID: 228831
			public const int ElementTexture = 1;

			// Token: 0x04037DE0 RID: 228832
			public const int LightSprite1 = 2;

			// Token: 0x04037DE1 RID: 228833
			public const int LightSprite2 = 3;

			// Token: 0x04037DE2 RID: 228834
			public const int RedDotItem = 4;

			// Token: 0x04037DE3 RID: 228835
			public const int DisableItem = 5;

			// Token: 0x04037DE4 RID: 228836
			public const int MaxItem = 6;
		}
	}
}
