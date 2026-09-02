using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D7E RID: 19838
	public class SingleHotKeyItem : HotKeyItem
	{
		// Token: 0x06033611 RID: 210449 RVA: 0x00CD9FE0 File Offset: 0x00CD81E0
		protected override UniTask OnBeforeStartAsync()
		{
			SingleHotKeyItem.<OnBeforeStartAsync>d__1 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SingleHotKeyItem.<OnBeforeStartAsync>d__1>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033612 RID: 210450 RVA: 0x00CDA024 File Offset: 0x00CD8224
		private void RegisterLinkComponent()
		{
			TsUiHotKeyLinkListener tsUiHotKeyLinkListener = this.RootActor.GetComponentByClass(TsUiHotKeyLinkListener.StaticClass()) as TsUiHotKeyLinkListener;
			if (tsUiHotKeyLinkListener == null)
			{
				return;
			}
			foreach (HotKeyComponent hotKeyComponent in this.GetHotKeyComponentArray())
			{
				if (hotKeyComponent != null)
				{
					hotKeyComponent.SetLinkComponent(tsUiHotKeyLinkListener);
				}
			}
		}

		// Token: 0x06033613 RID: 210451 RVA: 0x00CDA09C File Offset: 0x00CD829C
		protected override void OnClear()
		{
			this.HotKeyTypeComponent.Clear();
		}

		// Token: 0x06033614 RID: 210452 RVA: 0x00CDA0A9 File Offset: 0x00CD82A9
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		public override List<HotKeyComponent> GetHotKeyComponentArray()
		{
			if (this.HotKeyTypeComponent != null)
			{
				return this.HotKeyTypeComponent.GetHotKeyComponents();
			}
			return new List<HotKeyComponent>();
		}

		// Token: 0x0401DC86 RID: 121990
		[Nullable(2)]
		private HotKeyTypeBase HotKeyTypeComponent;
	}
}
