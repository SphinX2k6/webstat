using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDA RID: 24538
	public class BattleSkillSwitchInteractItem : UiPanelBase
	{
		// Token: 0x0603DBE5 RID: 252901 RVA: 0x00FBAA14 File Offset: 0x00FB8C14
		[NullableContext(1)]
		public void Init(UUIItem parentItem)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_HandleSkillSwitchIcon", parentItem, false).ContinueWith(new Action(this.RefreshVisible)).Forget();
		}

		// Token: 0x0603DBE6 RID: 252902 RVA: 0x00FBAA39 File Offset: 0x00FB8C39
		public void RefreshEnable(bool bEnable)
		{
			this.IsEnable = bEnable;
			this.RefreshVisible();
		}

		// Token: 0x0603DBE7 RID: 252903 RVA: 0x00FBAA48 File Offset: 0x00FB8C48
		public void RefreshVisible()
		{
			this.SetActive(this.IsEnable);
		}

		// Token: 0x04022A39 RID: 141881
		public bool IsEnable;
	}
}
