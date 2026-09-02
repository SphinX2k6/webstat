using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005679 RID: 22137
	public class RogueIllustratedEventItem : GridProxyAbstract<int>
	{
		// Token: 0x06038680 RID: 231040 RVA: 0x00E48D8C File Offset: 0x00E46F8C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06038681 RID: 231041 RVA: 0x00E48DE6 File Offset: 0x00E46FE6
		protected override void OnStartImplement()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.ExtendToggleStateChanged));
		}

		// Token: 0x06038682 RID: 231042 RVA: 0x00E48E0A File Offset: 0x00E4700A
		protected override void OnBeforeDestroyImplement()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.ExtendToggleStateChanged));
		}

		// Token: 0x06038683 RID: 231043 RVA: 0x00E48E30 File Offset: 0x00E47030
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.EventIdKey = data;
			RogueResCollection value = ConfigRogueResCollectionByIdKey.GetConfig(data, true).Value;
			this.State = ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(this.EventIdKey);
			base.GetItem(2).SetUIActive(this.State == SignState.Unlock);
			if (this.State == SignState.Lock)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueRes_CollectionEventLock", Array.Empty<object>());
			}
			else if (value.Type == 1)
			{
				RogueResGridEvent? config = ConfigRogueResGridEventById.GetConfig(value.Id, true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.Title, Array.Empty<object>());
			}
			else if (value.Type == 2)
			{
				RogueResGridEvent? config2 = ConfigRogueResGridEventById.GetConfig(value.Id, true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config2.Value.Title, Array.Empty<object>());
			}
			this.SetSelected(isSelected, false);
		}

		// Token: 0x06038684 RID: 231044 RVA: 0x00E48F29 File Offset: 0x00E47129
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x06038685 RID: 231045 RVA: 0x00E48F33 File Offset: 0x00E47133
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x06038686 RID: 231046 RVA: 0x00E48F40 File Offset: 0x00E47140
		public void SetSelected(bool bSelected, bool bForce = false)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (bSelected)
			{
				if (bForce)
				{
					extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				if (bForce)
				{
					extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x06038687 RID: 231047 RVA: 0x00E48F8B File Offset: 0x00E4718B
		[NullableContext(1)]
		public void BindOnItemButtonClickedCallback(Action<int, SignState> onItemButtonClicked)
		{
			this.OnItemButtonClickedCallback = onItemButtonClicked;
		}

		// Token: 0x06038688 RID: 231048 RVA: 0x00E48F94 File Offset: 0x00E47194
		private void ExtendToggleStateChanged(EToggleState state)
		{
			if (this.OnItemButtonClickedCallback != null)
			{
				this.OnItemButtonClickedCallback(this.EventIdKey, this.State);
			}
		}

		// Token: 0x040202EA RID: 131818
		private int EventIdKey;

		// Token: 0x040202EB RID: 131819
		private SignState State;

		// Token: 0x040202EC RID: 131820
		[Nullable(2)]
		private Action<int, SignState> OnItemButtonClickedCallback;
	}
}
