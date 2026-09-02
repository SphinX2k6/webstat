using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200600D RID: 24589
	public class FormationLevelUpItem : UiPanelBase
	{
		// Token: 0x0603DF3F RID: 253759 RVA: 0x00FCEABA File Offset: 0x00FCCCBA
		[NullableContext(1)]
		public FormationLevelUpItem(UUIItem rootUiItem)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_FormationLevelUpItem", rootUiItem, false).Forget();
		}

		// Token: 0x0603DF40 RID: 253760 RVA: 0x00FCEAD4 File Offset: 0x00FCCCD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DF41 RID: 253761 RVA: 0x00FCEB1C File Offset: 0x00FCCD1C
		protected override void OnStart()
		{
			if (this.LevelHandle != null)
			{
				base.GetText(0).SetText(this.LevelHandle, true);
			}
			this.LevelHandle = null;
		}

		// Token: 0x0603DF42 RID: 253762 RVA: 0x00FCEB40 File Offset: 0x00FCCD40
		[NullableContext(1)]
		public void SetLevelText(string level)
		{
			if (base.InAsyncLoading())
			{
				this.LevelHandle = level;
				return;
			}
			base.GetText(0).SetText(level, true);
		}

		// Token: 0x04022BF3 RID: 142323
		[Nullable(2)]
		public string LevelHandle;

		// Token: 0x0200C0A9 RID: 49321
		private enum EFormationLevelUpItem
		{
			// Token: 0x0403B51A RID: 242970
			LevelText
		}
	}
}
