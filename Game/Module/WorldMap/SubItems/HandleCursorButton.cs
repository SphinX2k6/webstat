using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubItems
{
	// Token: 0x02004BE7 RID: 19431
	[NullableContext(2)]
	[Nullable(0)]
	public class HandleCursorButton : UiPanelBase
	{
		// Token: 0x06032B4A RID: 207690 RVA: 0x00CB38E8 File Offset: 0x00CB1AE8
		[NullableContext(1)]
		public UniTask Initialize(UUIItem rootItem, Action onClickCall)
		{
			HandleCursorButton.<Initialize>d__3 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.rootItem = rootItem;
			<Initialize>d__.onClickCall = onClickCall;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<HandleCursorButton.<Initialize>d__3>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06032B4B RID: 207691 RVA: 0x00CB393C File Offset: 0x00CB1B3C
		protected override void OnStart()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetRaycastTarget(false);
			}
			this.Button = (base.GetRootActor().GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent);
			this.Button.OnClickCallBack.Bind(this.ClickCall);
		}

		// Token: 0x06032B4C RID: 207692 RVA: 0x00CB3991 File Offset: 0x00CB1B91
		protected override void OnBeforeDestroy()
		{
			this.Button.OnClickCallBack.Unbind();
		}

		// Token: 0x06032B4D RID: 207693 RVA: 0x00CB39A3 File Offset: 0x00CB1BA3
		public void SetSelected(bool isSet)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.IsSet == isSet)
			{
				return;
			}
			this.IsSet = isSet;
			if (isSet)
			{
				this.Button.SetSelectionState(EUISelectableSelectionState.Highlighted);
				return;
			}
			this.Button.SetSelectionState(EUISelectableSelectionState.Normal);
		}

		// Token: 0x06032B4E RID: 207694 RVA: 0x00CB39DF File Offset: 0x00CB1BDF
		public void SetCursorActive(bool value)
		{
			if (Singleton<Info>.Instance.IsInGamepad() && value)
			{
				this.SetActive(true);
				return;
			}
			this.SetActive(false);
		}

		// Token: 0x0401D846 RID: 120902
		private bool IsSet;

		// Token: 0x0401D847 RID: 120903
		private UUIButtonComponent Button;

		// Token: 0x0401D848 RID: 120904
		private Action ClickCall;
	}
}
