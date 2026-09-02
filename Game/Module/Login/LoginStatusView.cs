using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A0F RID: 23055
	public class LoginStatusView : UiViewBase
	{
		// Token: 0x0603A61E RID: 239134 RVA: 0x00ECDA23 File Offset: 0x00ECBC23
		[NullableContext(1)]
		public LoginStatusView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A61F RID: 239135 RVA: 0x00ECDA2C File Offset: 0x00ECBC2C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LoginStatusChange, new Action(this.RefreshStatus));
		}

		// Token: 0x0603A620 RID: 239136 RVA: 0x00ECDA47 File Offset: 0x00ECBC47
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LoginStatusChange, new Action(this.RefreshStatus));
		}

		// Token: 0x0603A621 RID: 239137 RVA: 0x00ECDA64 File Offset: 0x00ECBC64
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

		// Token: 0x0603A622 RID: 239138 RVA: 0x00ECDAAC File Offset: 0x00ECBCAC
		protected override void OnStart()
		{
			this.RefreshStatus();
		}

		// Token: 0x0603A623 RID: 239139 RVA: 0x00ECDAB4 File Offset: 0x00ECBCB4
		private void RefreshStatus()
		{
			LoginDefine.ELoginStatus loginStatus = ModelBase<LoginModel>.Instance.GetLoginStatus();
			LoginDefine.ELoginStatus? lastFailStatus = ModelBase<LoginModel>.Instance.GetLastFailStatus();
			string newText;
			if (lastFailStatus != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
				defaultInterpolatedStringHandler.AppendLiteral("登录状态:");
				defaultInterpolatedStringHandler.AppendFormatted<LoginDefine.ELoginStatus>(loginStatus);
				defaultInterpolatedStringHandler.AppendLiteral(", 上一次失败:");
				defaultInterpolatedStringHandler.AppendFormatted<LoginDefine.ELoginStatus?>(lastFailStatus);
				newText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
				defaultInterpolatedStringHandler.AppendLiteral("登录状态:");
				defaultInterpolatedStringHandler.AppendFormatted<LoginDefine.ELoginStatus>(loginStatus);
				newText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0200B9DC RID: 47580
		public enum ELoginStatusCom
		{
			// Token: 0x040396EB RID: 235243
			MySelf
		}
	}
}
