using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006310 RID: 25360
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorPhantomExhibitGrid : GridProxyAbstract<SpringManorPhantomDisplayItem>
	{
		// Token: 0x0603FBDE RID: 261086 RVA: 0x01057534 File Offset: 0x01055734
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick))
			};
		}

		// Token: 0x0603FBDF RID: 261087 RVA: 0x010575E0 File Offset: 0x010557E0
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(() => this.CanToggleChange == null || this.CanToggleChange(base.GridIndex));
			}
			this.MonsterItem = new SpringManorPhantomExhibitIconItem();
			this.MonsterItem.CreateThenShowByActor(base.GetItem(1).GetOwner());
			this.MonsterItem.SetToggleInteractive(false);
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603FBE0 RID: 261088 RVA: 0x01057650 File Offset: 0x01055850
		[NullableContext(1)]
		public override void Refresh(SpringManorPhantomDisplayItem data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.MonsterItem.Refresh(data);
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			PhantomItem? phantomItem;
			string key = ((ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(data.PhantomId) != null) ? phantomItem.GetValueOrDefault().MonsterName : null) ?? "";
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(state, false, false, false);
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.IsSelected);
		}

		// Token: 0x0603FBE1 RID: 261089 RVA: 0x010576EE File Offset: 0x010558EE
		private void ToggleClick(EToggleState state)
		{
			if (this.Data == null)
			{
				return;
			}
			Action<int, int> onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(this.Data.PhantomId, base.GridIndex);
		}

		// Token: 0x0603FBE2 RID: 261090 RVA: 0x0105771A File Offset: 0x0105591A
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603FBE3 RID: 261091 RVA: 0x0105772D File Offset: 0x0105592D
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x04023C73 RID: 146547
		private SpringManorPhantomExhibitIconItem MonsterItem;

		// Token: 0x04023C74 RID: 146548
		public Func<int, bool> CanToggleChange;

		// Token: 0x04023C75 RID: 146549
		public Action<int, int> OnToggleClick;

		// Token: 0x04023C76 RID: 146550
		private SpringManorPhantomDisplayItem Data;
	}
}
