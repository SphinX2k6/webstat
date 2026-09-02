using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A03 RID: 27139
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelEventLockInputState : Singleton<LevelEventLockInputState>
	{
		// Token: 0x1700A204 RID: 41476
		// (get) Token: 0x060433C6 RID: 275398 RVA: 0x01149A4F File Offset: 0x01147C4F
		public bool RealLockInput
		{
			get
			{
				return this.InnerLockInput;
			}
		}

		// Token: 0x060433C7 RID: 275399 RVA: 0x01149A57 File Offset: 0x01147C57
		public void Lock(List<string> tagNames)
		{
			bool flag = !this.InnerLockInput;
			this.InnerLockInput = true;
			this.InputTagNames = tagNames;
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnLevelInputLockChanged, true);
			}
		}

		// Token: 0x060433C8 RID: 275400 RVA: 0x01149A83 File Offset: 0x01147C83
		public void Unlock()
		{
			bool innerLockInput = this.InnerLockInput;
			this.InnerLockInput = false;
			this.InputLimitEsc = false;
			this.InputTagNames.Clear();
			if (innerLockInput)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnLevelInputLockChanged, false);
			}
		}

		// Token: 0x060433C9 RID: 275401 RVA: 0x01149AB7 File Offset: 0x01147CB7
		public bool IsLockInput()
		{
			return !this.GmViewOpening && this.InnerLockInput;
		}

		// Token: 0x1700A205 RID: 41477
		// (get) Token: 0x060433CA RID: 275402 RVA: 0x01149AC9 File Offset: 0x01147CC9
		public bool IsInputTagHasUiInputRoot
		{
			get
			{
				return this.InputTagNames != null && this.InputTagNames.Count != 0 && this.InputTagNames.Contains("UiInputRoot");
			}
		}

		// Token: 0x040257B0 RID: 153520
		private bool InnerLockInput;

		// Token: 0x040257B1 RID: 153521
		public bool GmViewOpening;

		// Token: 0x040257B2 RID: 153522
		public List<string> InputTagNames = new List<string>();

		// Token: 0x040257B3 RID: 153523
		public List<EUiViewName> InputLimitView = new List<EUiViewName>();

		// Token: 0x040257B4 RID: 153524
		public bool InputLimitEsc;
	}
}
