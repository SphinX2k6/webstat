using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200600F RID: 24591
	[NullableContext(1)]
	[Nullable(0)]
	public class FormationTrialItem : UiPanelBase
	{
		// Token: 0x0603DF52 RID: 253778 RVA: 0x00FCEFF0 File Offset: 0x00FCD1F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DF53 RID: 253779 RVA: 0x00FCF05C File Offset: 0x00FCD25C
		protected override void OnStart()
		{
			if (!string.IsNullOrEmpty(this.NameHandle))
			{
				this.SetNameTextInternal(this.NameHandle);
			}
			this.NameHandle = null;
			if (!string.IsNullOrEmpty(this.IconHandle))
			{
				this.SetTrialIconInternal(this.IconHandle);
			}
			this.IconHandle = null;
		}

		// Token: 0x0603DF54 RID: 253780 RVA: 0x00FCF0A9 File Offset: 0x00FCD2A9
		public void SetNameText(string name)
		{
			if (base.InAsyncLoading())
			{
				this.NameHandle = name;
				return;
			}
			this.SetNameTextInternal(name);
		}

		// Token: 0x0603DF55 RID: 253781 RVA: 0x00FCF0C2 File Offset: 0x00FCD2C2
		public void SetTrialIcon(string resourceId)
		{
			if (base.InAsyncLoading())
			{
				this.IconHandle = resourceId;
				return;
			}
			this.SetTrialIconInternal(resourceId);
		}

		// Token: 0x0603DF56 RID: 253782 RVA: 0x00FCF0DB File Offset: 0x00FCD2DB
		private void SetNameTextInternal(string name)
		{
			base.GetText(0).SetText(name, true);
		}

		// Token: 0x0603DF57 RID: 253783 RVA: 0x00FCF0EC File Offset: 0x00FCD2EC
		private void SetTrialIconInternal(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
		}

		// Token: 0x04022BFB RID: 142331
		[Nullable(2)]
		private string NameHandle;

		// Token: 0x04022BFC RID: 142332
		[Nullable(2)]
		private string IconHandle;

		// Token: 0x0200C0AD RID: 49325
		[NullableContext(0)]
		private enum EFormationTrialItem
		{
			// Token: 0x0403B52D RID: 242989
			NameText,
			// Token: 0x0403B52E RID: 242990
			IconImg
		}
	}
}
