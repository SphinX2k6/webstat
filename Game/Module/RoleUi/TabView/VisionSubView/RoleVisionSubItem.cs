using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506E RID: 20590
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleVisionSubItem : RoleVisionCommonItem
	{
		// Token: 0x060350E2 RID: 217314 RVA: 0x00D4E43A File Offset: 0x00D4C63A
		[NullableContext(1)]
		public RoleVisionSubItem(UUIItem uiItem, EPhantomItemIndex index, [Nullable(2)] RoleDataBase roleData, bool needRedDot = false) : base(uiItem, index, roleData, needRedDot, false, ERoleViewSource.Normal)
		{
		}

		// Token: 0x060350E3 RID: 217315 RVA: 0x00D4E449 File Offset: 0x00D4C649
		protected override UUIItem GetPlusItem()
		{
			return base.GetItem(8);
		}

		// Token: 0x060350E4 RID: 217316 RVA: 0x00D4E452 File Offset: 0x00D4C652
		protected override UUITexture GetVisionTextureComponent()
		{
			return base.GetTexture(3);
		}

		// Token: 0x060350E5 RID: 217317 RVA: 0x00D4E45B File Offset: 0x00D4C65B
		protected override UUISprite GetVisionQualitySprite()
		{
			return base.GetSprite(5);
		}

		// Token: 0x060350E6 RID: 217318 RVA: 0x00D4E464 File Offset: 0x00D4C664
		protected UUIText GetVisionLevelText()
		{
			return base.GetText(4);
		}

		// Token: 0x060350E7 RID: 217319 RVA: 0x00D4E46D File Offset: 0x00D4C66D
		protected override UUIText GetVisionCostText()
		{
			return base.GetText(7);
		}

		// Token: 0x060350E8 RID: 217320 RVA: 0x00D4E476 File Offset: 0x00D4C676
		protected override UUIItem GetVisionCostItem()
		{
			return base.GetItem(6);
		}

		// Token: 0x060350E9 RID: 217321 RVA: 0x00D4E47F File Offset: 0x00D4C67F
		public override UUIDraggableComponent GetDragComponent()
		{
			return base.GetDraggable(2);
		}

		// Token: 0x060350EA RID: 217322 RVA: 0x00D4E488 File Offset: 0x00D4C688
		protected override UUIExtendToggle GetSelectToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x060350EB RID: 217323 RVA: 0x00D4E494 File Offset: 0x00D4C694
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, base.OnClickVision)
			};
		}

		// Token: 0x060350EC RID: 217324 RVA: 0x00D4E58F File Offset: 0x00D4C78F
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x060350ED RID: 217325 RVA: 0x00D4E5AE File Offset: 0x00D4C7AE
		private bool CanExecuteChange()
		{
			return false;
		}

		// Token: 0x0200B027 RID: 45095
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036A51 RID: 223825
			ToggleItem,
			// Token: 0x04036A52 RID: 223826
			BackSprite,
			// Token: 0x04036A53 RID: 223827
			CircleItem,
			// Token: 0x04036A54 RID: 223828
			CircleItemTexture,
			// Token: 0x04036A55 RID: 223829
			TextNum,
			// Token: 0x04036A56 RID: 223830
			QualitySprite,
			// Token: 0x04036A57 RID: 223831
			CostItem,
			// Token: 0x04036A58 RID: 223832
			CostNumText,
			// Token: 0x04036A59 RID: 223833
			PlusItem
		}
	}
}
