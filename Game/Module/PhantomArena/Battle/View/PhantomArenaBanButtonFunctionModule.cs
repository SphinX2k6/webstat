using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055A6 RID: 21926
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBanButtonFunctionModule
	{
		// Token: 0x06037CE4 RID: 228580 RVA: 0x00E2382C File Offset: 0x00E21A2C
		private void RefreshButtonState(UUIButtonComponent button)
		{
			HashSet<string> hashSet;
			if (this.ButtonMap.TryGetValue(button, out hashSet))
			{
				if (hashSet != null && hashSet.Count > 0)
				{
					button.SetSelfInteractive(false);
					return;
				}
				button.SetSelfInteractive(true);
			}
		}

		// Token: 0x06037CE5 RID: 228581 RVA: 0x00E23864 File Offset: 0x00E21A64
		private void OnBanButton(UUIButtonComponent button, string reason)
		{
			HashSet<string> hashSet;
			if (this.ButtonMap.TryGetValue(button, out hashSet) && hashSet != null)
			{
				hashSet.Add(reason);
				this.RefreshButtonState(button);
			}
		}

		// Token: 0x06037CE6 RID: 228582 RVA: 0x00E23894 File Offset: 0x00E21A94
		private void OnResumeButton(UUIButtonComponent button, string reason)
		{
			HashSet<string> hashSet;
			if (this.ButtonMap.TryGetValue(button, out hashSet) && hashSet != null)
			{
				hashSet.Remove(reason);
				this.RefreshButtonState(button);
			}
		}

		// Token: 0x06037CE7 RID: 228583 RVA: 0x00E238C3 File Offset: 0x00E21AC3
		public void RegisterButton(UUIButtonComponent button)
		{
			this.ButtonMap[button] = new HashSet<string>();
		}

		// Token: 0x06037CE8 RID: 228584 RVA: 0x00E238D8 File Offset: 0x00E21AD8
		public void BanButton(UUIButtonComponent button, string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "外部禁用单个按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnBanButton(button, reason);
		}

		// Token: 0x06037CE9 RID: 228585 RVA: 0x00E23918 File Offset: 0x00E21B18
		public void ResumeButton(UUIButtonComponent button, string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "外部恢复单个按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnResumeButton(button, reason);
		}

		// Token: 0x06037CEA RID: 228586 RVA: 0x00E23958 File Offset: 0x00E21B58
		public void BanButtonList(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "外部禁用全部按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (UUIButtonComponent button in this.ButtonMap.Keys)
			{
				this.OnBanButton(button, reason);
			}
		}

		// Token: 0x06037CEB RID: 228587 RVA: 0x00E239DC File Offset: 0x00E21BDC
		public void ResumeButtonList(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "外部恢复全部按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (UUIButtonComponent button in this.ButtonMap.Keys)
			{
				this.OnResumeButton(button, reason);
			}
		}

		// Token: 0x0401FF4C RID: 130892
		protected Dictionary<UUIButtonComponent, HashSet<string>> ButtonMap = new Dictionary<UUIButtonComponent, HashSet<string>>();
	}
}
