using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E3 RID: 26851
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropCatchLevelItem : GridProxyAbstract<IDropCatchLevelItemData>
	{
		// Token: 0x06042BDA RID: 273370 RVA: 0x011210C0 File Offset: 0x0111F2C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClicked))
			};
		}

		// Token: 0x06042BDB RID: 273371 RVA: 0x011211AB File Offset: 0x0111F3AB
		public void SetClickCallback(Action<int, int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06042BDC RID: 273372 RVA: 0x011211B4 File Offset: 0x0111F3B4
		public override void Refresh(IDropCatchLevelItemData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.CfgId = data.CfgId;
			this.SetToggleSelect(isSelected);
			string text = (gridIndex + 1).ToString();
			int romaIndex = this.GetRomaIndex(data.State.GetValueOrDefault());
			this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}", new string[]
			{
				text,
				text
			}), base.GetSprite(romaIndex), false, null, null);
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				EDropCatchLevelState? state = data.State;
				EDropCatchLevelState edropCatchLevelState = EDropCatchLevelState.Lock;
				item.SetUIActive(state.GetValueOrDefault() == edropCatchLevelState & state != null);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 != null)
			{
				item2.SetUIActive(data.State.GetValueOrDefault() == EDropCatchLevelState.Unlock);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(data.State.GetValueOrDefault() == EDropCatchLevelState.Rewarded);
			}
			UUIItem item4 = base.GetItem(7);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(data.HasRedPoint);
		}

		// Token: 0x06042BDD RID: 273373 RVA: 0x011212B6 File Offset: 0x0111F4B6
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleSelect(true);
		}

		// Token: 0x06042BDE RID: 273374 RVA: 0x011212BF File Offset: 0x0111F4BF
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false);
		}

		// Token: 0x06042BDF RID: 273375 RVA: 0x011212C8 File Offset: 0x0111F4C8
		private void OnClicked(EToggleState state)
		{
			Action<int, int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.CfgId, base.GridIndex);
		}

		// Token: 0x06042BE0 RID: 273376 RVA: 0x011212E6 File Offset: 0x0111F4E6
		public void SetToggleSelect(bool select)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06042BE1 RID: 273377 RVA: 0x01121303 File Offset: 0x0111F503
		private int GetRomaIndex(EDropCatchLevelState state)
		{
			if (state == EDropCatchLevelState.Unlock)
			{
				return 1;
			}
			if (state != EDropCatchLevelState.Rewarded)
			{
				return 3;
			}
			return 5;
		}

		// Token: 0x040252E8 RID: 152296
		private int CfgId;

		// Token: 0x040252E9 RID: 152297
		private Action<int, int> ClickCallback = delegate(int configId, int index)
		{
		};

		// Token: 0x040252EA RID: 152298
		private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}";
	}
}
