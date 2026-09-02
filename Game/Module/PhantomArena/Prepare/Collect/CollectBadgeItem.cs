using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005511 RID: 21777
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectBadgeItem : GridProxyAbstract<int>
	{
		// Token: 0x060378D9 RID: 227545 RVA: 0x00E18034 File Offset: 0x00E16234
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickBadge))
			};
		}

		// Token: 0x060378DA RID: 227546 RVA: 0x00E180F3 File Offset: 0x00E162F3
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanChange));
		}

		// Token: 0x060378DB RID: 227547 RVA: 0x00E18114 File Offset: 0x00E16314
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.BadgeId = data;
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsBadgeUnlock(data);
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(flag);
			PhantomBattleBadge phantomBattleBadgeById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(data);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), phantomBattleBadgeById.Name, Array.Empty<object>());
			this.SetSpriteByPath(phantomBattleBadgeById.ShowIcon, base.GetSprite(4), false, null, null);
			this.SetSpriteByPath(phantomBattleBadgeById.ShowIcon, base.GetSprite(2), false, null, null);
			this.SetSelected(isSelected);
		}

		// Token: 0x060378DC RID: 227548 RVA: 0x00E181C1 File Offset: 0x00E163C1
		private void OnClickBadge(EToggleState toggleState)
		{
			if (this.CallbackClickBadge != null && this.BadgeId > 0)
			{
				this.CallbackClickBadge(this.BadgeId);
			}
		}

		// Token: 0x060378DD RID: 227549 RVA: 0x00E181E8 File Offset: 0x00E163E8
		private bool OnCanChange()
		{
			if (this.CallbackCanChange != null && this.BadgeId > 0)
			{
				EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
				return this.CallbackCanChange(this.BadgeId, toggleState);
			}
			return false;
		}

		// Token: 0x060378DE RID: 227550 RVA: 0x00E18227 File Offset: 0x00E16427
		private void SetSelected(bool isSelected)
		{
			if (isSelected)
			{
				this.OnSelected(false);
				return;
			}
			this.OnDeselected(false);
		}

		// Token: 0x060378DF RID: 227551 RVA: 0x00E1823B File Offset: 0x00E1643B
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060378E0 RID: 227552 RVA: 0x00E1824E File Offset: 0x00E1644E
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060378E1 RID: 227553 RVA: 0x00E18261 File Offset: 0x00E16461
		public override object GetKey(int data, int displayIndex)
		{
			return this.BadgeId;
		}

		// Token: 0x0401FDBC RID: 130492
		private int BadgeId;

		// Token: 0x0401FDBD RID: 130493
		public Action<int> CallbackClickBadge;

		// Token: 0x0401FDBE RID: 130494
		public Func<int, EToggleState, bool> CallbackCanChange;

		// Token: 0x0200B4A0 RID: 46240
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037E9E RID: 229022
			public const int ToggleBadge = 0;

			// Token: 0x04037E9F RID: 229023
			public const int PanelLock = 1;

			// Token: 0x04037EA0 RID: 229024
			public const int SpriteLock = 2;

			// Token: 0x04037EA1 RID: 229025
			public const int PanelUnlock = 3;

			// Token: 0x04037EA2 RID: 229026
			public const int SpriteUnlock = 4;

			// Token: 0x04037EA3 RID: 229027
			public const int TextName = 5;
		}
	}
}
