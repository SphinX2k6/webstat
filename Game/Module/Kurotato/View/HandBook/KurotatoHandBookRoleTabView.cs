using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.HandBook
{
	// Token: 0x02005AB7 RID: 23223
	public class KurotatoHandBookRoleTabView : UiTabViewBase
	{
		// Token: 0x0603AB89 RID: 240521 RVA: 0x00EE2E68 File Offset: 0x00EE1068
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB8A RID: 240522 RVA: 0x00EE2EB0 File Offset: 0x00EE10B0
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoHandBookRoleTabView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoHandBookRoleTabView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB8B RID: 240523 RVA: 0x00EE2EF3 File Offset: 0x00EE10F3
		protected override void OnShowUiTabViewFromToggle()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			if (tabBehavior != null)
			{
				tabBehavior.PlaySequence("Change");
			}
			this.KurotatoHandBookRolePanel.RefreshRoleList();
		}

		// Token: 0x0603AB8C RID: 240524 RVA: 0x00EE2F16 File Offset: 0x00EE1116
		protected override void OnShowUiTabViewFromView()
		{
			this.KurotatoHandBookRolePanel.RefreshRoleList();
		}

		// Token: 0x0603AB8D RID: 240525 RVA: 0x00EE2F23 File Offset: 0x00EE1123
		protected override void OnHideUiTabViewBase(bool fromToggle)
		{
			ControllerBase<KurotatoActivityController>.Instance.GetActivityData().ReadRoleRedDot();
		}

		// Token: 0x04021346 RID: 136006
		[Nullable(1)]
		private readonly KurotatoHandBookRolePanel KurotatoHandBookRolePanel = new KurotatoHandBookRolePanel();

		// Token: 0x0200BABC RID: 47804
		private enum EHandBookRoleTabViewComponent
		{
			// Token: 0x04039A54 RID: 236116
			ItemRoleViewPanel
		}
	}
}
