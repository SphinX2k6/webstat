using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006597 RID: 26007
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballLoadingTexView : UiPanelBase, ILoopAutoScrollItem<string>
	{
		// Token: 0x06040FCB RID: 266187 RVA: 0x010ACE08 File Offset: 0x010AB008
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040FCC RID: 266188 RVA: 0x010ACE50 File Offset: 0x010AB050
		public void Refresh(string data)
		{
			base.TrySetTextureByPath(data, base.GetTexture(0), new EUiViewName?(EUiViewName.PinballLoadingView), null);
		}

		// Token: 0x06040FCD RID: 266189 RVA: 0x010ACE6C File Offset: 0x010AB06C
		UniTask ILoopAutoScrollItem<string>.CreateByActorAsync(AActor actor)
		{
			PinballLoadingTexView.<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__3 <CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__;
			<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.<>4__this = this;
			<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.actor = actor;
			<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.<>1__state = -1;
			<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.<>t__builder.Start<PinballLoadingTexView.<CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__3>(ref <CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__);
			return <CSharpScript-Game-Module-Util-ILoopAutoScrollItem<System-String>-CreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FCE RID: 266190 RVA: 0x010ACEB7 File Offset: 0x010AB0B7
		public new UUIItem GetRootItem()
		{
			return this.RootItem;
		}

		// Token: 0x0200C58B RID: 50571
		[NullableContext(0)]
		private enum EItemComponent
		{
			// Token: 0x0403CCC3 RID: 249027
			Tex
		}
	}
}
