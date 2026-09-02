using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x02006254 RID: 25172
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TabItem : GridProxyAbstract<IActivityTab>
	{
		// Token: 0x0603F724 RID: 259876 RVA: 0x01043B94 File Offset: 0x01041D94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x0603F725 RID: 259877 RVA: 0x01043C14 File Offset: 0x01041E14
		protected override void OnStart()
		{
			UUIExtendToggle toggle = base.GetExtendToggle(0);
			toggle.CanExecuteChange.Bind(() => this.CanTabToggleExecuteChange(toggle.ToggleState));
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x0603F726 RID: 259878 RVA: 0x01043C64 File Offset: 0x01041E64
		private bool CanTabToggleExecuteChange(EToggleState state)
		{
			return this.TabCanExecuteChangedFunction == null || this.TabCanExecuteChangedFunction(state == EToggleState.ETT_Checked, base.GridIndex);
		}

		// Token: 0x0603F727 RID: 259879 RVA: 0x01043C85 File Offset: 0x01041E85
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<int> tabFunction = this.TabFunction;
			if (tabFunction != null)
			{
				tabFunction(base.GridIndex);
			}
			Action<int> tabClickExtraFunction = this.TabClickExtraFunction;
			if (tabClickExtraFunction == null)
			{
				return;
			}
			tabClickExtraFunction(base.GridIndex);
		}

		// Token: 0x0603F728 RID: 259880 RVA: 0x01043CB4 File Offset: 0x01041EB4
		[NullableContext(1)]
		public override void Refresh(IActivityTab data, bool isSelected, int gridIndex)
		{
			if (data.TabData.TabName != null && !StringUtils.IsEmpty(data.TabData.TabName))
			{
				base.GetText(1).SetText(data.TabData.TabName, true);
				this.SetActive(true);
			}
			else
			{
				this.SetActive(false);
			}
			bool uiactive = false;
			using (List<IActivityRewardData>.Enumerator enumerator = data.TabData.DataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == EActivityRewardState.Enable)
					{
						uiactive = true;
						break;
					}
				}
			}
			base.GetItem(2).SetUIActive(uiactive);
			if (data.TabData.TabExtraFunction != null)
			{
				this.TabClickExtraFunction = data.TabData.TabExtraFunction;
			}
			this.TabFunction = data.TabFunction;
			this.TabCanExecuteChangedFunction = data.TabCanExecuteFunction;
		}

		// Token: 0x0603F729 RID: 259881 RVA: 0x01043D9C File Offset: 0x01041F9C
		public void SetTabToggleState(bool state, bool? fireEvent = null)
		{
			base.GetExtendToggle(0).SetToggleState(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			if (state && fireEvent.GetValueOrDefault())
			{
				this.OnClickToggle(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
			}
		}

		// Token: 0x040239C3 RID: 145859
		private Action<int> TabFunction;

		// Token: 0x040239C4 RID: 145860
		private Action<int> TabClickExtraFunction;

		// Token: 0x040239C5 RID: 145861
		private Func<bool, int, bool> TabCanExecuteChangedFunction;
	}
}
