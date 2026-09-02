using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A08 RID: 23048
	public class LoginOfficialStatusView : UiViewBase
	{
		// Token: 0x0603A5F4 RID: 239092 RVA: 0x00ECCF51 File Offset: 0x00ECB151
		[NullableContext(1)]
		public LoginOfficialStatusView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A5F5 RID: 239093 RVA: 0x00ECCF5A File Offset: 0x00ECB15A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LoginStatusChange, new Action(this.RefreshStatus));
		}

		// Token: 0x0603A5F6 RID: 239094 RVA: 0x00ECCF75 File Offset: 0x00ECB175
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LoginStatusChange, new Action(this.RefreshStatus));
		}

		// Token: 0x0603A5F7 RID: 239095 RVA: 0x00ECCF90 File Offset: 0x00ECB190
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

		// Token: 0x0603A5F8 RID: 239096 RVA: 0x00ECCFD8 File Offset: 0x00ECB1D8
		protected override void OnStart()
		{
			this.RefreshStatus();
		}

		// Token: 0x0603A5F9 RID: 239097 RVA: 0x00ECCFE0 File Offset: 0x00ECB1E0
		private void RefreshStatus()
		{
			int loginStatus = (int)ModelBase<LoginModel>.Instance.GetLoginStatus();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "ELoginStatus", new <>z__ReadOnlySingleElementList<object>(loginStatus));
		}
	}
}
