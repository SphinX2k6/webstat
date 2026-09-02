using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.RoleSelect
{
	// Token: 0x02005A89 RID: 23177
	public class KurotatoRoleSelectView : UiViewBase
	{
		// Token: 0x0603AA50 RID: 240208 RVA: 0x00EDBCBF File Offset: 0x00ED9EBF
		[NullableContext(1)]
		public KurotatoRoleSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AA51 RID: 240209 RVA: 0x00EDBCC8 File Offset: 0x00ED9EC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AA52 RID: 240210 RVA: 0x00EDBD34 File Offset: 0x00ED9F34
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoRoleSelectView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoRoleSelectView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA53 RID: 240211 RVA: 0x00EDBD77 File Offset: 0x00ED9F77
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603AA54 RID: 240212 RVA: 0x00EDBD80 File Offset: 0x00ED9F80
		private void OnHelpBtnClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(574);
		}

		// Token: 0x040212BA RID: 135866
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040212BB RID: 135867
		[Nullable(2)]
		private KurotatoRoleSelectPanel RoleSelectPanel;

		// Token: 0x0200BA6B RID: 47723
		private enum EComponent
		{
			// Token: 0x040398FA RID: 235770
			ItemCaption,
			// Token: 0x040398FB RID: 235771
			ItemContent
		}
	}
}
